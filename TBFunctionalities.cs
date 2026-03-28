using Il2Cpp;
using Il2CppNodeCanvas.Tasks.Actions;
using Il2CppProCore.Decals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Il2CppMono.Security.X509.X520;

namespace Toolbelts
{
    internal class TBFunctionalities
    {

        internal static string attachBeltText;
        private static GameObject attachBeltButton;
        internal static GearItem beltItem;
        internal static string beltName;

        internal static string detachBeltText;
        private static GameObject detachBeltButton;
        internal static GearItem pantsItem;
        internal static string pantsName;

        internal static string attachCramponsText;
        private static GameObject attachCramponsButton;
        internal static GearItem cramponItem;
        internal static string cramponName;

        internal static string detachCramponsText;
        private static GameObject detachCramponsButton;
        internal static GearItem bootsItem;
        internal static string bootsName;

        internal static string attachScabbardText;
        private static GameObject attachScabbardButton;
        internal static GearItem scabbardItem;
        internal static string scabbardName;

        internal static string detachScabbardText;
        private static GameObject detachScabbardButton;
        internal static GearItem bagItem;
        internal static string bagName;

        internal static void InitializeMTB(ItemDescriptionPage itemDescriptionPage)
        {
            attachBeltText = Localization.Get("GAMEPLAY_TB_AttachBeltLabel");
            detachBeltText = Localization.Get("GAMEPLAY_TB_DetachBeltLabel");
            attachCramponsText = Localization.Get("GAMEPLAY_TB_AttachCramponsLabel");
            detachCramponsText = Localization.Get("GAMEPLAY_TB_DetachCramponsLabel");
            attachScabbardText = Localization.Get("GAMEPLAY_TB_AttachScabbardLabel");
            detachScabbardText = Localization.Get("GAMEPLAY_TB_DetachScabbardLabel");

            GameObject equipButton = itemDescriptionPage.m_MouseButtonEquip;
            attachBeltButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            attachBeltButton.transform.Translate(0, 0, 0);
            Utils.GetComponentInChildren<UILabel>(attachBeltButton).text = attachBeltText;

            detachBeltButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            detachBeltButton.transform.Translate(0, 0, 0);
            Utils.GetComponentInChildren<UILabel>(detachBeltButton).text = detachBeltText;

            attachCramponsButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            attachCramponsButton.transform.Translate(0, 0, 0);
            Utils.GetComponentInChildren<UILabel>(attachCramponsButton).text = attachCramponsText;

            detachCramponsButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            detachCramponsButton.transform.Translate(0, 0, 0);
            Utils.GetComponentInChildren<UILabel>(detachCramponsButton).text = detachCramponsText;

            attachScabbardButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            attachScabbardButton.transform.Translate(0, 0, 0);
            Utils.GetComponentInChildren<UILabel>(attachScabbardButton).text = attachScabbardText;

            detachScabbardButton = UnityEngine.Object.Instantiate<GameObject>(equipButton, equipButton.transform.parent, true);
            detachScabbardButton.transform.Translate(0, 0, 0);
            Utils.GetComponentInChildren<UILabel>(detachScabbardButton).text = detachScabbardText;


            AddAction(attachBeltButton, new System.Action(OnAttachBelt));
            AddAction(detachBeltButton, new System.Action(OnDetachBelt));

            AddAction(attachCramponsButton, new System.Action(OnAttachCrampons));
            AddAction(detachCramponsButton, new System.Action(OnDetachCrampons));

            AddAction(attachScabbardButton, new System.Action(OnAttachScabbard));
            AddAction(detachScabbardButton, new System.Action(OnDetachScabbard));

            SetAttachBeltActive(false);
            SetDetachBeltActive(false);

            SetAttachCramponsActive(false);
            SetDetachCramponsActive(false);

            SetAttachScabbardActive(false);
            SetDetachScabbardActive(false);

        }
        private static void AddAction(GameObject button, System.Action action)
        {
            Il2CppSystem.Collections.Generic.List<EventDelegate> placeHolderList = new Il2CppSystem.Collections.Generic.List<EventDelegate>();
            placeHolderList.Add(new EventDelegate(action));
            Utils.GetComponentInChildren<UIButton>(button).onClick = placeHolderList;
        }
        internal static void SetAttachBeltActive(bool active)
        {
            NGUITools.SetActive(attachBeltButton, active);
        }

        internal static void SetDetachBeltActive(bool active)
        {
            NGUITools.SetActive(detachBeltButton, active);
        }

        internal static void SetAttachCramponsActive(bool active)
        {
            NGUITools.SetActive(attachCramponsButton, active);
        }

        internal static void SetDetachCramponsActive(bool active)
        {
            NGUITools.SetActive(detachCramponsButton, active);
        }

        internal static void SetAttachScabbardActive(bool active)
        {
            NGUITools.SetActive(attachScabbardButton, active);
        }

        internal static void SetDetachScabbardActive(bool active)
        {
            NGUITools.SetActive(detachScabbardButton, active);
        }

        private static void OnAttachCrampons()
        {
            var thisGearItem = cramponItem;
            GearItem crampon = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_Crampons");
            GearItem cramponimprov = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_ImprovisedCrampons");

            if (thisGearItem == null) return;
            if (crampon == null && cramponimprov == null)
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_TB_NoCrampons"));
                GameAudioManager.PlayGUIError();
                return;
            }
            if (thisGearItem.name == "GEAR_WorkBoots" || thisGearItem.name == "GEAR_BasicBoots" || thisGearItem.name == "GEAR_CombatBoots" || thisGearItem.name == "GEAR_InsulatedBoots" || thisGearItem.name == "GEAR_BasicShoes" || thisGearItem.name == "GEAR_SkiBoots" || thisGearItem.name == "GEAR_LeatherShoes" || thisGearItem.name == "GEAR_DeerSkinBoots" || thisGearItem.name == "GEAR_MuklukBoots" || thisGearItem.name == "GEAR_MinersBoots")
            {
                cramponName = thisGearItem.name;
                if (crampon)
                {
                    GameAudioManager.PlayGuiConfirm();
                    InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_TB_AttachingProgressBar"), 1f, 0f, 0f,
                                    "PLAY_CRACCESSORIES_LEATHERBELT_EQUIP", null, false, true, new System.Action<bool, bool, float>(OnAttachCramponsFinished));
                    GameManager.GetInventoryComponent().RemoveGearFromInventory(crampon.name, 1);
                }
                else if (cramponimprov)
                {
                    GameAudioManager.PlayGuiConfirm();
                    InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_TB_AttachingProgressBar"), 1f, 0f, 0f,
                                    "PLAY_CRACCESSORIES_LEATHERBELT_EQUIP", null, false, true, new System.Action<bool, bool, float>(OnAttachCramponsUFinished));
                    GameManager.GetInventoryComponent().RemoveGearFromInventory(cramponimprov.name, 1);
                }
            }
            else
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_TB_NoCrampons"));
                GameAudioManager.PlayGUIError();
            }

        }
        private static void OnAttachCramponsFinished(bool success, bool playerCancel, float progress)
        {
            GearItem pants;

            if (cramponName.ToLowerInvariant().Contains("workboots"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.workBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.workBootsCramp, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.workBootsCramp.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("combatboots"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.combatBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.combatBootsCramp, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.combatBootsCramp.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("deerskinboots"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.deerBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.deerBootsCramp, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.deerBootsCramp.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("insulatedboots"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.insulatedBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.insulatedBootsCramp, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.insulatedBootsCramp.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("leathershoes"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.dressingBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.dressingBootsCramp, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.dressingBootsCramp.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("mukluk"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.muklukBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.muklukBootsCramp, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.muklukBootsCramp.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("basicshoes"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.runningBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.runningBootsCramp, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.runningBootsCramp.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("skiboots"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.skiBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.skiBootsCramp, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.skiBootsCramp.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("basicboots"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.trailBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.trailBootsCramp, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.trailBootsCramp.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("minersboots"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.chemicalBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.chemicalBootsCramp, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.chemicalBootsCramp.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }

        }

        private static void OnAttachCramponsUFinished(bool success, bool playerCancel, float progress)
        {
            GearItem pants;

            if (cramponName.ToLowerInvariant().Contains("workboots"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.workBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.workBootsImprov, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.workBootsImprov.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("combatboots"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.combatBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.combatBootsImprov, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.combatBootsImprov.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("deerskinboots"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.deerBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.deerBootsImprov, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.deerBootsImprov.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("insulatedboots"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.insulatedBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.insulatedBootsImprov, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.insulatedBootsImprov.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("leathershoes"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.dressingBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.dressingBootsImprov, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.dressingBootsImprov.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("mukluk"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.muklukBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.muklukBootsImprov, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.muklukBootsImprov.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("basicshoes"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.runningBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.runningBootsImprov, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.runningBootsImprov.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("skiboots"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.skiBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.skiBootsImprov, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.skiBootsImprov.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("basicboots"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.trailBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.trailBootsImprov, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.trailBootsImprov.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (cramponName.ToLowerInvariant().Contains("minersboots"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.chemicalBoots.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.chemicalBootsImprov, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.chemicalBootsImprov.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
        }

        private static void OnDetachCrampons()
        {
            var thisGearItem = bootsItem;
            var crampon = ToolbeltsUtils.crampons;
            var cramponI = ToolbeltsUtils.cramponsimprov;

            if (thisGearItem == null) return;

            if (thisGearItem.name == "GEAR_WorkNCrampons" || thisGearItem.name == "GEAR_CombatNCrampons" || thisGearItem.name == "GEAR_DeerskinNCrampons" || thisGearItem.name == "GEAR_InsulatedNCrampons" || thisGearItem.name == "GEAR_DressingNCrampons" || thisGearItem.name == "GEAR_MuklukNCrampons" || thisGearItem.name == "GEAR_RunningNCrampons" || thisGearItem.name == "GEAR_SkiNCrampons" || thisGearItem.name == "GEAR_TrailNCrampons" || thisGearItem.name == "GEAR_ChemicalNCrampons")
            {
                bootsName = thisGearItem.name;
                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_TB_DetachingProgressBar"), 1f, 0f, 0f,
                                "PLAY_CRACCESSORIES_LEATHERBELT_UNQUIP", null, false, true, new System.Action<bool, bool, float>(OnDetachCramponsFinished));
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.crampons, 1);
            }
            else if (thisGearItem.name == "GEAR_WorkICrampons" || thisGearItem.name == "GEAR_CombatICrampons" || thisGearItem.name == "GEAR_DeerskinICrampons" || thisGearItem.name == "GEAR_InsulatedICrampons" || thisGearItem.name == "GEAR_DressingICrampons" || thisGearItem.name == "GEAR_MuklukICrampons" || thisGearItem.name == "GEAR_RunningICrampons" || thisGearItem.name == "GEAR_SkiICrampons" || thisGearItem.name == "GEAR_TrailICrampons" || thisGearItem.name == "GEAR_ChemicalICrampons")
            {
                bootsName = thisGearItem.name;
                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_TB_DetachingProgressBar"), 1f, 0f, 0f,
                    "PLAY_CRACCESSORIES_LEATHERBELT_UNQUIP", null, false, true, new System.Action<bool, bool, float>(OnDetachCramponsFinished));
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.cramponsimprov, 1);
            }

        }
        private static void OnDetachCramponsFinished(bool success, bool playerCancel, float progress)
        {
            GearItem pants;

            if (bootsName.ToLowerInvariant().Contains("workncrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.workBootsCramp.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.workBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.workBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("workicrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.workBootsImprov.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.workBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.workBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("combatncrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.combatBootsCramp.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.combatBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.combatBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("combaticrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.combatBootsImprov.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.combatBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.combatBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("deerskinncrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.deerBootsCramp.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.deerBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.deerBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("deerskinicrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.deerBootsImprov.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.deerBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.deerBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("insulatedncrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.insulatedBootsCramp.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.insulatedBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.insulatedBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("insulatedicrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.insulatedBootsImprov.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.insulatedBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.insulatedBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("dressingncrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.dressingBootsCramp.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.dressingBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.dressingBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("dressingicrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.dressingBootsImprov.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.dressingBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.dressingBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("muklukncrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.muklukBootsCramp.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.muklukBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.muklukBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("muklukicrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.muklukBootsImprov.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.muklukBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.muklukBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("runningncrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.runningBootsCramp.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.runningBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.runningBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("runningicrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.runningBootsImprov.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.runningBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.runningBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("skincrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.skiBootsCramp.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.skiBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.skiBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("skiicrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.skiBootsImprov.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.skiBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.skiBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("trailncrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.trailBootsCramp.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.trailBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.trailBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("trailicrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.trailBootsImprov.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.trailBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.trailBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("chemicalncrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.chemicalBootsCramp.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.chemicalBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.chemicalBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (bootsName.ToLowerInvariant().Contains("chemicalicrampons"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.chemicalBootsImprov.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.chemicalBoots, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.chemicalBoots.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }

        }
        private static void OnAttachBelt()
        {
            var thisGearItem = TBFunctionalities.beltItem;
            GearItem beltU = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_Toolbelt");

            if (thisGearItem == null) return;
            if (beltU == null)
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_TB_NoBelt"));
                GameAudioManager.PlayGUIError();
                return;
            }
            if (thisGearItem.name == "GEAR_Jeans" || thisGearItem.name == "GEAR_CargoPants" || thisGearItem.name == "GEAR_CombatPants" || thisGearItem.name == "GEAR_DeerSkinPants" || thisGearItem.name == "GEAR_InsulatedPants" || thisGearItem.name == "GEAR_MinersPants" || thisGearItem.name == "GEAR_WorkPants")
            {
                beltName = thisGearItem.name;
                if (beltU)
                {
                    GameAudioManager.PlayGuiConfirm();
                    InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_TB_AttachingProgressBar"), 1f, 0f, 0f,
                                    "PLAY_CRACCESSORIES_LEATHERBELT_EQUIP", null, false, true, new System.Action<bool, bool, float>(OnAttachBeltUFinished));
                    GameManager.GetInventoryComponent().RemoveGearFromInventory(beltU.name, 1);
                }

            }
            else
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_TB_NoBelt"));
                GameAudioManager.PlayGUIError();
            }

        }
        private static void OnAttachBeltUFinished(bool success, bool playerCancel, float progress)
        {
            GearItem pants;

            if (beltName.ToLowerInvariant().Contains("jeans"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.jeans.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.jeansbelt, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.jeansbelt.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (beltName.ToLowerInvariant().Contains("cargo"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.cargo.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.cargobelt, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.cargobelt.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (beltName.ToLowerInvariant().Contains("combat"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.combat.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.combatbelt, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.combatbelt.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (beltName.ToLowerInvariant().Contains("deerskin"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.deerskin.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.deerskinbelt, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.deerskinbelt.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (beltName.ToLowerInvariant().Contains("insulated"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.insulated.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.insulatedbelt, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.insulatedbelt.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (beltName.ToLowerInvariant().Contains("miner"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.miner.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.minerbelt, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.minerbelt.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (beltName.ToLowerInvariant().Contains("work"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.work.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.workbelt, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.workbelt.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }

        }

        private static void OnDetachBelt()
        {
            var thisGearItem = pantsItem;

            if (thisGearItem == null) return;

            if (thisGearItem.name == "GEAR_JeansToolbelt" || thisGearItem.name == "GEAR_CargoToolbelt" || thisGearItem.name == "GEAR_MinerToolbelt" || thisGearItem.name == "GEAR_CombatToolbelt" || thisGearItem.name == "GEAR_DeerskinToolbelt" || thisGearItem.name == "GEAR_InsulatedToolbelt" || thisGearItem.name == "GEAR_WorkToolbelt")
            {
                pantsName = thisGearItem.name;
                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_TB_DetachingProgressBar"), 1f, 0f, 0f,
                    "PLAY_CRACCESSORIES_LEATHERBELT_UNQUIP", null, false, true, new System.Action<bool, bool, float>(OnDetachBeltFinished));
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.belt, 1);
            }


        }
        private static void OnDetachBeltFinished(bool success, bool playerCancel, float progress)
        {
            GearItem pants;

            if (pantsName.ToLowerInvariant().Contains("jeanstoolbelt"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.jeansbelt.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.jeans, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.jeans.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (pantsName.ToLowerInvariant().Contains("cargotoolbelt"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.cargobelt.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.cargo, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.cargo.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (pantsName.ToLowerInvariant().Contains("minertoolbelt"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.minerbelt.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.miner, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.miner.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (pantsName.ToLowerInvariant().Contains("combattoolbelt"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.combatbelt.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.combat, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.combat.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (pantsName.ToLowerInvariant().Contains("deerskintoolbelt"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.deerskinbelt.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.deerskin, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.deerskin.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (pantsName.ToLowerInvariant().Contains("insulatedtoolbelt"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.insulatedbelt.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.insulated, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.insulated.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
            else if (pantsName.ToLowerInvariant().Contains("worktoolbelt"))
            {
                pants = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.workbelt.name, 1);

                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.work, 1);

                GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.work.name, 1).m_CurrentHP = pants.m_CurrentHP;

                GameManager.GetInventoryComponent().RemoveGearFromInventory(pants.name, 1);
            }
        }

        private static void OnAttachScabbard()
        {
            var thisGearItem = TBFunctionalities.scabbardItem;
            GearItem scab = GameManager.GetInventoryComponent().GetBestGearItemWithName("GEAR_RifleScabbardA");

            if (thisGearItem == null) return;
            if (scab == null)
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_TB_NoScabbard"));
                GameAudioManager.PlayGUIError();
                return;
            }
            if (thisGearItem.name == "GEAR_MooseHideBag")
            {
                beltName = thisGearItem.name;
                if (scab)
                {
                    GameAudioManager.PlayGuiConfirm();
                    InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_TB_AttachingProgressBar"), 1f, 0f, 0f,
                                    "PLAY_CRACCESSORIES_LEATHERBELT_EQUIP", null, false, true, new System.Action<bool, bool, float>(OnAttachScabbardFinished));
                    GameManager.GetInventoryComponent().RemoveGearFromInventory(scab.name, 1);
                }

            }
            else
            {
                HUDMessage.AddMessage(Localization.Get("GAMEPLAY_TB_NoScabbard"));
                GameAudioManager.PlayGUIError();
            }

        }
        private static void OnAttachScabbardFinished(bool success, bool playerCancel, float progress)
        {
            GearItem bag;

            bag = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.bag.name, 1);

            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.bagscabbard, 1);

            GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.bagscabbard.name, 1).m_CurrentHP = bag.m_CurrentHP;

            GameManager.GetInventoryComponent().RemoveGearFromInventory(bag.name, 1);


        }

        private static void OnDetachScabbard()
        {
            var thisGearItem = bagItem;

            if (thisGearItem == null) return;

            if (thisGearItem.name == "GEAR_MooseBagPlusScabbard")
            {
                bagName = thisGearItem.name;
                GameAudioManager.PlayGuiConfirm();
                InterfaceManager.GetPanel<Panel_GenericProgressBar>().Launch(Localization.Get("GAMEPLAY_TB_DetachingProgressBar"), 1f, 0f, 0f,
                    "PLAY_CRACCESSORIES_LEATHERBELT_UNQUIP", null, false, true, new System.Action<bool, bool, float>(OnDetachScabbardFinished));
                GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.scabbard, 1);
            }


        }
        private static void OnDetachScabbardFinished(bool success, bool playerCancel, float progress)
        {
            GearItem bag;

            bag = GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.bagscabbard.name, 1);

            GameManager.GetPlayerManagerComponent().InstantiateItemInPlayerInventory(ToolbeltsUtils.bag, 1);

            GameManager.GetInventoryComponent().GearInInventory(ToolbeltsUtils.bag.name, 1).m_CurrentHP = bag.m_CurrentHP;

            GameManager.GetInventoryComponent().RemoveGearFromInventory(bag.name, 1);
        }

    }
}