using Il2Cpp;
using Il2CppHoloville.HOTween.Core.Easing;
using Toolbelts;
using MelonLoader;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Il2CppTLD.Gear;
using Il2CppTLD.Gameplay.Condition;
using Il2CppNodeCanvas.BehaviourTrees;
using JetBrains.Annotations;
using Il2CppMS.Internal.Xml.XPath;

namespace ModNamespace
{
    internal sealed class LWMain : MelonMod
    {
        public static bool isLoaded;

        private static bool addedCustomComponents; 

        public override void OnInitializeMelon()
        {
            MelonLoader.MelonLogger.Msg(System.ConsoleColor.Green, "Clothing Expanded Loaded!");
        }
        public override void OnSceneWasInitialized(int level, string name)
        {


            if (ToolbeltsUtils.IsScenePlayable(name))
            {
                isLoaded = true;

                DoStuffWithGear();

            }

        }

        private static void DoStuffWithGear()
        {
            if (!addedCustomComponents)
            {
                GameObject gear;
                GearItem itemGear;
                var validtools = GearItem.LoadGearItemPrefab("GEAR_ToolBelt").GetComponent<WeightReductionBuff>().m_ValidTargets;
                var tools = GearItem.LoadGearItemPrefab("GEAR_ToolBelt").GetComponent<WeightReductionBuff>().m_Targets;
                var tools2 = GearItem.LoadGearItemPrefab("GEAR_ToolBelt").GetComponent<WeightReductionBuff>().m_OperationHandle;

                var cramponssprain = GearItem.LoadGearItemPrefab("GEAR_Crampons").GetComponent<ClimbingBuff>().m_SprainModifier;
                var cramponssprainroll = GearItem.LoadGearItemPrefab("GEAR_Crampons").GetComponent<ClimbingBuff>().m_SprainRollOddsModifier;
                var cramponsstamina = GearItem.LoadGearItemPrefab("GEAR_Crampons").GetComponent<ClimbingBuff>().m_StaminaModifier;
                var cramponsstaminasec = GearItem.LoadGearItemPrefab("GEAR_Crampons").GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier;
                var cramponsice = GearItem.LoadGearItemPrefab("GEAR_Crampons").GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier;

                var Icramponssprain = GearItem.LoadGearItemPrefab("GEAR_ImprovisedCrampons").GetComponent<ClimbingBuff>().m_SprainModifier;
                var Icramponssprainroll = GearItem.LoadGearItemPrefab("GEAR_ImprovisedCrampons").GetComponent<ClimbingBuff>().m_SprainRollOddsModifier;
                var Icramponsstamina = GearItem.LoadGearItemPrefab("GEAR_ImprovisedCrampons").GetComponent<ClimbingBuff>().m_StaminaModifier;
                var Icramponsstaminasec = GearItem.LoadGearItemPrefab("GEAR_ImprovisedCrampons").GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier;
                var Icramponsice = GearItem.LoadGearItemPrefab("GEAR_ImprovisedCrampons").GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier;

                var scabbardvtarget = GearItem.LoadGearItemPrefab("GEAR_RifleScabbardA").GetComponent<WeightReductionBuff>().m_ValidTargets;
                var scabbardtargets = GearItem.LoadGearItemPrefab("GEAR_RifleScabbardA").GetComponent<WeightReductionBuff>().m_Targets;
                var scabbardophandle = GearItem.LoadGearItemPrefab("GEAR_RifleScabbardA").GetComponent<WeightReductionBuff>().m_OperationHandle;
                var moosebag = GearItem.LoadGearItemPrefab("GEAR_MooseHideBag").GetComponent<CarryingCapacityBuff>().m_CarryingCapacityBuffValues;

                string gear13u = "JeansToolbelt";
                string gear14u = "CombatToolbelt";
                string gear15u = "CargoToolbelt";
                string gear16u = "WorkToolbelt";
                string gear17u = "InsulatedToolbelt";
                string gear18u = "MinerToolbelt";
                string gear19u = "DeerskinToolbelt";

                string gear21 = "WorkNCrampons";
                string gear21i = "WorkICrampons";
                string gear22 = "CombatNCrampons";
                string gear22i = "CombatICrampons";
                string gear23 = "DeerskinNCrampons";
                string gear23i = "DeerskinICrampons";
                string gear24 = "InsulatedNCrampons";
                string gear24i = "InsulatedICrampons";
                string gear25 = "DressingNCrampons";
                string gear25i = "DressingICrampons";
                string gear26 = "MuklukNCrampons";
                string gear26i = "MuklukICrampons";
                string gear27 = "RunningNCrampons";
                string gear27i = "RunningICrampons";
                string gear28 = "SkiNCrampons";
                string gear28i = "SkiICrampons";
                string gear29 = "TrailNCrampons";
                string gear29i = "TrailICrampons";
                string gear31 = "ChemicalNCrampons";
                string gear31i = "ChemicalICrampons";

                string gear30 = "MooseBagPlusScabbard";


                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear13u).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear13u);

                gear.AddComponent<WeightReductionBuff>();
                gear.GetComponent<WeightReductionBuff>().m_GearItem = itemGear;
                gear.GetComponent<WeightReductionBuff>().m_ValidTargets = validtools;
                gear.GetComponent<WeightReductionBuff>().m_Targets = tools;
                gear.GetComponent<WeightReductionBuff>().m_OperationHandle = tools2;
                gear.GetComponent<WeightReductionBuff>().m_AffectedItems = 3;
                gear.GetComponent<WeightReductionBuff>().m_WeightReduction = 0.5f;


                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear14u).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear14u);

                gear.AddComponent<WeightReductionBuff>();
                gear.GetComponent<WeightReductionBuff>().m_GearItem = itemGear;
                gear.GetComponent<WeightReductionBuff>().m_ValidTargets = validtools;
                gear.GetComponent<WeightReductionBuff>().m_Targets = tools;
                gear.GetComponent<WeightReductionBuff>().m_OperationHandle = tools2;
                gear.GetComponent<WeightReductionBuff>().m_AffectedItems = 3;
                gear.GetComponent<WeightReductionBuff>().m_WeightReduction = 0.5f;


                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear15u).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear15u);

                gear.AddComponent<WeightReductionBuff>();
                gear.GetComponent<WeightReductionBuff>().m_GearItem = itemGear;
                gear.GetComponent<WeightReductionBuff>().m_ValidTargets = validtools;
                gear.GetComponent<WeightReductionBuff>().m_Targets = tools;
                gear.GetComponent<WeightReductionBuff>().m_OperationHandle = tools2;
                gear.GetComponent<WeightReductionBuff>().m_AffectedItems = 3;
                gear.GetComponent<WeightReductionBuff>().m_WeightReduction = 0.5f;


                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear16u).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear16u);

                gear.AddComponent<WeightReductionBuff>();
                gear.GetComponent<WeightReductionBuff>().m_GearItem = itemGear;
                gear.GetComponent<WeightReductionBuff>().m_ValidTargets = validtools;
                gear.GetComponent<WeightReductionBuff>().m_Targets = tools;
                gear.GetComponent<WeightReductionBuff>().m_OperationHandle = tools2;
                gear.GetComponent<WeightReductionBuff>().m_AffectedItems = 3;
                gear.GetComponent<WeightReductionBuff>().m_WeightReduction = 0.5f;


                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear17u).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear17u);

                gear.AddComponent<WeightReductionBuff>();
                gear.GetComponent<WeightReductionBuff>().m_GearItem = itemGear;
                gear.GetComponent<WeightReductionBuff>().m_ValidTargets = validtools;
                gear.GetComponent<WeightReductionBuff>().m_Targets = tools;
                gear.GetComponent<WeightReductionBuff>().m_OperationHandle = tools2;
                gear.GetComponent<WeightReductionBuff>().m_AffectedItems = 3;
                gear.GetComponent<WeightReductionBuff>().m_WeightReduction = 0.5f;


                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear18u).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear18u);

                gear.AddComponent<WeightReductionBuff>();
                gear.GetComponent<WeightReductionBuff>().m_GearItem = itemGear;
                gear.GetComponent<WeightReductionBuff>().m_ValidTargets = validtools;
                gear.GetComponent<WeightReductionBuff>().m_Targets = tools;
                gear.GetComponent<WeightReductionBuff>().m_OperationHandle = tools2;
                gear.GetComponent<WeightReductionBuff>().m_AffectedItems = 3;
                gear.GetComponent<WeightReductionBuff>().m_WeightReduction = 0.5f;


                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear19u).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear19u);

                gear.AddComponent<WeightReductionBuff>();
                gear.GetComponent<WeightReductionBuff>().m_GearItem = itemGear;
                gear.GetComponent<WeightReductionBuff>().m_ValidTargets = validtools;
                gear.GetComponent<WeightReductionBuff>().m_Targets = tools;
                gear.GetComponent<WeightReductionBuff>().m_OperationHandle = tools2;
                gear.GetComponent<WeightReductionBuff>().m_AffectedItems = 3;
                gear.GetComponent<WeightReductionBuff>().m_WeightReduction = 0.5f;


                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear21).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear21);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = cramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = cramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = cramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = cramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = cramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear21i).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear21i);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = Icramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = Icramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = Icramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = Icramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = Icramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear22).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear22);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = cramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = cramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = cramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = cramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = cramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear22i).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear22i);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = Icramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = Icramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = Icramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = Icramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = Icramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear23).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear23);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = cramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = cramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = cramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = cramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = cramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear23i).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear23i);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = Icramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = Icramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = Icramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = Icramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = Icramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear24).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear24);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = cramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = cramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = cramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = cramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = cramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear24i).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear24i);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = Icramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = Icramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = Icramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = Icramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = Icramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear25).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear25);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = cramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = cramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = cramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = cramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = cramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear25i).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear25i);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = Icramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = Icramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = Icramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = Icramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = Icramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear26).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear26);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = cramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = cramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = cramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = cramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = cramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear26i).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear26i);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = Icramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = Icramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = Icramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = Icramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = Icramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear27).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear27);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = cramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = cramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = cramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = cramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = cramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear27i).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear27i);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = Icramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = Icramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = Icramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = Icramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = Icramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear28).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear28);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = cramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = cramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = cramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = cramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = cramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear28i).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear28i);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = Icramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = Icramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = Icramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = Icramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = Icramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear29).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear29);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = cramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = cramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = cramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = cramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = cramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear29i).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear29i);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = Icramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = Icramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = Icramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = Icramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = Icramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear31).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear31);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = cramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = cramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = cramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = cramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = cramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear31i).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear31i);

                gear.AddComponent<ClimbingBuff>();
                gear.GetComponent<ClimbingBuff>().m_SprainModifier = Icramponssprain;
                gear.GetComponent<ClimbingBuff>().m_SprainRollOddsModifier = Icramponssprainroll;
                gear.GetComponent<ClimbingBuff>().m_StaminaModifier = Icramponsstamina;
                gear.GetComponent<ClimbingBuff>().m_StaminaPerSecondModifier = Icramponsstaminasec;
                gear.GetComponent<ClimbingBuff>().m_WeakIceTimeSecondsModifier = Icramponsice;

                gear = GearItem.LoadGearItemPrefab("GEAR_" + gear30).gameObject;
                itemGear = GearItem.LoadGearItemPrefab("GEAR_" + gear30);

                gear.AddComponent<WeightReductionBuff>();
                gear.GetComponent<WeightReductionBuff>().m_GearItem = itemGear;
                gear.GetComponent<WeightReductionBuff>().m_ValidTargets = scabbardvtarget;
                gear.GetComponent<WeightReductionBuff>().m_Targets = scabbardtargets;
                gear.GetComponent<WeightReductionBuff>().m_OperationHandle = scabbardophandle;
                gear.GetComponent<WeightReductionBuff>().m_AffectedItems = 1;
                gear.GetComponent<WeightReductionBuff>().m_WeightReduction = 0.5f;

                gear.AddComponent<CarryingCapacityBuff>();
                gear.GetComponent<CarryingCapacityBuff>().m_IsWorn = true;
                gear.GetComponent<CarryingCapacityBuff>().m_CarryingCapacityBuffValues = moosebag;

                addedCustomComponents = true;
            }

        }

    }
}

