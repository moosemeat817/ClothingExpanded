using UnityEngine.AddressableAssets;
using UnityEngine;
using Il2Cpp;
using MelonLoader;

namespace Toolbelts
{
    internal static class ToolbeltsUtils
    {
        public static Panel_Inventory inventory;

        
        public static GearItem belt = Addressables.LoadAssetAsync<GameObject>("GEAR_Toolbelt").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem crampons = Addressables.LoadAssetAsync<GameObject>("GEAR_Crampons").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem cramponsimprov = Addressables.LoadAssetAsync<GameObject>("GEAR_ImprovisedCrampons").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem bag = Addressables.LoadAssetAsync<GameObject>("GEAR_MooseHideBag").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem scabbard = Addressables.LoadAssetAsync<GameObject>("GEAR_RifleScabbardA").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem bagscabbard = Addressables.LoadAssetAsync<GameObject>("GEAR_MooseBagPlusScabbard").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem jeans = Addressables.LoadAssetAsync<GameObject>("GEAR_Jeans").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem jeansbelt = Addressables.LoadAssetAsync<GameObject>("GEAR_JeansToolbelt").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem cargo = Addressables.LoadAssetAsync<GameObject>("GEAR_CargoPants").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem cargobelt = Addressables.LoadAssetAsync<GameObject>("GEAR_CargoToolbelt").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem miner = Addressables.LoadAssetAsync<GameObject>("GEAR_MinersPants").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem minerbelt = Addressables.LoadAssetAsync<GameObject>("GEAR_MinerToolbelt").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem combat = Addressables.LoadAssetAsync<GameObject>("GEAR_CombatPants").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem combatbelt = Addressables.LoadAssetAsync<GameObject>("GEAR_CombatToolbelt").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem deerskin = Addressables.LoadAssetAsync<GameObject>("GEAR_DeerskinPants").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem deerskinbelt = Addressables.LoadAssetAsync<GameObject>("GEAR_DeerskinToolbelt").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem insulated = Addressables.LoadAssetAsync<GameObject>("GEAR_InsulatedPants").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem insulatedbelt = Addressables.LoadAssetAsync<GameObject>("GEAR_InsulatedToolbelt").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem work = Addressables.LoadAssetAsync<GameObject>("GEAR_WorkPants").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem workbelt = Addressables.LoadAssetAsync<GameObject>("GEAR_WorkToolbelt").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem workBoots = Addressables.LoadAssetAsync<GameObject>("GEAR_WorkBoots").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem workBootsCramp = Addressables.LoadAssetAsync<GameObject>("GEAR_WorkNCrampons").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem workBootsImprov = Addressables.LoadAssetAsync<GameObject>("GEAR_WorkICrampons").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem skiBoots = Addressables.LoadAssetAsync<GameObject>("GEAR_SkiBoots").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem skiBootsCramp = Addressables.LoadAssetAsync<GameObject>("GEAR_SkiNCrampons").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem skiBootsImprov = Addressables.LoadAssetAsync<GameObject>("GEAR_SkiICrampons").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem combatBoots = Addressables.LoadAssetAsync<GameObject>("GEAR_CombatBoots").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem combatBootsCramp = Addressables.LoadAssetAsync<GameObject>("GEAR_CombatNCrampons").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem combatBootsImprov = Addressables.LoadAssetAsync<GameObject>("GEAR_CombatICrampons").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem deerBoots = Addressables.LoadAssetAsync<GameObject>("GEAR_DeerskinBoots").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem deerBootsCramp = Addressables.LoadAssetAsync<GameObject>("GEAR_DeerskinNCrampons").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem deerBootsImprov = Addressables.LoadAssetAsync<GameObject>("GEAR_DeerskinICrampons").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem dressingBoots = Addressables.LoadAssetAsync<GameObject>("GEAR_LeatherShoes").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem dressingBootsCramp = Addressables.LoadAssetAsync<GameObject>("GEAR_DressingNCrampons").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem dressingBootsImprov = Addressables.LoadAssetAsync<GameObject>("GEAR_DressingICrampons").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem insulatedBoots = Addressables.LoadAssetAsync<GameObject>("GEAR_InsulatedBoots").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem insulatedBootsCramp = Addressables.LoadAssetAsync<GameObject>("GEAR_InsulatedNCrampons").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem insulatedBootsImprov = Addressables.LoadAssetAsync<GameObject>("GEAR_InsulatedICrampons").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem muklukBoots = Addressables.LoadAssetAsync<GameObject>("GEAR_MuklukBoots").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem muklukBootsCramp = Addressables.LoadAssetAsync<GameObject>("GEAR_MuklukNCrampons").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem muklukBootsImprov = Addressables.LoadAssetAsync<GameObject>("GEAR_MuklukICrampons").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem trailBoots = Addressables.LoadAssetAsync<GameObject>("GEAR_BasicBoots").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem trailBootsCramp = Addressables.LoadAssetAsync<GameObject>("GEAR_TrailNCrampons").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem trailBootsImprov = Addressables.LoadAssetAsync<GameObject>("GEAR_TrailICrampons").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem runningBoots = Addressables.LoadAssetAsync<GameObject>("GEAR_BasicShoes").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem runningBootsCramp = Addressables.LoadAssetAsync<GameObject>("GEAR_RunningNCrampons").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem runningBootsImprov = Addressables.LoadAssetAsync<GameObject>("GEAR_RunningICrampons").WaitForCompletion().GetComponent<GearItem>();

        public static GearItem chemicalBoots = Addressables.LoadAssetAsync<GameObject>("GEAR_MinersBoots").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem chemicalBootsCramp = Addressables.LoadAssetAsync<GameObject>("GEAR_ChemicalNCrampons").WaitForCompletion().GetComponent<GearItem>();
        public static GearItem chemicalBootsImprov = Addressables.LoadAssetAsync<GameObject>("GEAR_ChemicalICrampons").WaitForCompletion().GetComponent<GearItem>();

        public static GameObject GetPlayer()
        {
            return GameManager.GetPlayerObject();
        }

        public static bool IsPants(string gearItemName)
        {
            string[] pants = { "GEAR_Jeans" , "GEAR_CargoPants" , "GEAR_MinersPants" , "GEAR_CombatPants" , "GEAR_DeerSkinPants" , "GEAR_InsulatedPants" , "GEAR_WorkPants" };
            for (int i = 0; i < pants.Length; i++)
            {
                if (gearItemName == pants[i]) return true;
            }
            return false;
        }

        public static bool IsBoots(string gearItemName)
        {
            string[] boots = { "GEAR_WorkBoots" , "GEAR_InsulatedBoots" , "GEAR_BasicBoots" , "GEAR_DeerSkinBoots" , "GEAR_SkiBoots" , "GEAR_CombatBoots" , "GEAR_LeatherShoes" , "GEAR_MuklukBoots" , "GEAR_BasicShoes" , "GEAR_MinersBoots" };
            for (int i = 0; i < boots.Length; i++)
            {
                if (gearItemName == boots[i]) return true;
            }
            return false;
        }

        public static bool IsPantsBelt(string gearItemName)
        {
            string[] pantsBelt = { "GEAR_JeansToolbelt" , "GEAR_CargoToolbelt" , "GEAR_MinerToolbelt" , "GEAR_CombatToolbelt" , "GEAR_DeerskinToolbelt" , "GEAR_InsulatedToolbelt" , "GEAR_WorkToolbelt" };
            for (int i = 0; i < pantsBelt.Length; i++)
            {
                if (gearItemName == pantsBelt[i]) return true;
            }
            return false;
        }

        public static bool IsBootsCrampons(string gearItemName)
        {
            string[] bootsCramp = { "GEAR_WorkNCrampons" , "GEAR_WorkICrampons", "GEAR_InsulatedNCrampons", "GEAR_InsulatedICrampons" , "GEAR_TrailNCrampons", "GEAR_TrailICrampons" , "GEAR_DeerskinNCrampons", "GEAR_DeerskinICrampons" , "GEAR_SkiNCrampons", "GEAR_SkiICrampons" , "GEAR_CombatNCrampons", "GEAR_CombatICrampons" , "GEAR_DressingNCrampons", "GEAR_DressingICrampons" , "GEAR_MuklukNCrampons", "GEAR_MuklukICrampons" , "GEAR_RunningNCrampons", "GEAR_RunningICrampons" , "GEAR_ChemicalNCrampons" , "GEAR_ChemicalICrampons" };
            for (int i = 0; i < bootsCramp.Length; i++)
            {
                if (gearItemName == bootsCramp[i]) return true;
            }
            return false;
        }

        public static bool IsScenePlayable()
        {
            return !(string.IsNullOrEmpty(GameManager.m_ActiveScene) || GameManager.m_ActiveScene.Contains("MainMenu") || GameManager.m_ActiveScene == "Boot" || GameManager.m_ActiveScene == "Empty");
        }

        public static bool IsScenePlayable(string scene)
        {
            return !(string.IsNullOrEmpty(scene) || scene.Contains("MainMenu") || scene == "Boot" || scene == "Empty");
        }
        public static bool IsMainMenu(string scene)
        {
            return !string.IsNullOrEmpty(scene) && scene.Contains("MainMenu");
        }

    }

}
