using Il2Cpp;
using HarmonyLib;
using UnityEngine;
using Il2CppSteamworks;
using Il2CppTLD.Gear;

namespace Toolbelts
{
    internal class Patches
    {
        [HarmonyPatch(typeof(Panel_Inventory), nameof(Panel_Inventory.Initialize))]
        internal class ToolbeltsInitialization
        {
            private static void Postfix(Panel_Inventory __instance)
            {
                ToolbeltsUtils.inventory = __instance;
                TBFunctionalities.InitializeMTB(__instance.m_ItemDescriptionPage);
            }
        }
        [HarmonyPatch(typeof(ItemDescriptionPage), nameof(ItemDescriptionPage.UpdateGearItemDescription))]
        internal class UpdateInventoryButton
        {
            private static void Postfix(ItemDescriptionPage __instance, GearItem gi)
            {
                if (__instance != InterfaceManager.GetPanel<Panel_Inventory>()?.m_ItemDescriptionPage) return;
                TBFunctionalities.beltItem = gi?.GetComponent<GearItem>();
                TBFunctionalities.pantsItem = gi?.GetComponent<GearItem>();
                TBFunctionalities.cramponItem = gi?.GetComponent<GearItem>();
                TBFunctionalities.bootsItem = gi?.GetComponent<GearItem>();
                TBFunctionalities.scabbardItem = gi?.GetComponent<GearItem>();
                TBFunctionalities.bagItem = gi?.GetComponent<GearItem>();

                if (gi != null && ToolbeltsUtils.IsPants(gi.name) == true)
                {
                    TBFunctionalities.SetAttachBeltActive(true);
                }
                else
                {
                    TBFunctionalities.SetAttachBeltActive(false);
                }

                if (gi != null && ToolbeltsUtils.IsPantsBelt(gi.name) == true)
                {
                    TBFunctionalities.SetDetachBeltActive(true);
                }
                else
                {
                    TBFunctionalities.SetDetachBeltActive(false);
                }

                if (gi != null && ToolbeltsUtils.IsBoots(gi.name) == true)
                {
                    TBFunctionalities.SetAttachCramponsActive(true);
                }
                else
                {
                    TBFunctionalities.SetAttachCramponsActive(false);
                }

                if (gi != null && ToolbeltsUtils.IsBootsCrampons(gi.name) == true)
                {
                    TBFunctionalities.SetDetachCramponsActive(true);
                }
                else
                {
                    TBFunctionalities.SetDetachCramponsActive(false);
                }

                if (gi.name == "GEAR_MooseHideBag")
                {
                    TBFunctionalities.SetAttachScabbardActive(true);
                }
                else
                {
                    TBFunctionalities.SetAttachScabbardActive(false);
                }

                if (gi.name == "GEAR_MooseBagPlusScabbard")
                {
                    TBFunctionalities.SetDetachScabbardActive(true);
                }
                else
                {
                    TBFunctionalities.SetDetachScabbardActive(false);
                }
            }
        }

    }
}
    