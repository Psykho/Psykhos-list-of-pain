﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitchToolkit.IRC;
using TwitchToolkit.Settings;
using TwitchToolkit.Store;
using Verse;

namespace TwitchToolkit.Incidents
{
    public class StoreIncident : Def
    {
        public string abbreviation;

        public int cost;

        public int eventCap;

        public Type incidentHelper = typeof(IncidentHelper);

        public KarmaType karmaType;
    }

    public class StoreIncidentSimple : StoreIncident
    {
    }

    public class StoreIncidentVariables : StoreIncident
    {
        public void RegisterCustomSettings()
        {
            bool ScanningFloats = false;
            int index = 0;

            foreach(string key in customSettingKeys)
            {
                if (customSettingStringValues != null && customSettingStringValues.Count > index && CustomSettings.LookupStringSetting(key) == null)
                {
                    Log.Warning("Registering custom setting from " + LabelCap + " " + key + " " + customSettingStringValues[index]);
                    CustomSettings.SetStringSetting(key, customSettingStringValues[index]);
                    index++;
                    continue;
                }
                else
                {
                    index = 0;
                    ScanningFloats = true;
                }

                if (ScanningFloats && customSettingFloatValues != null && customSettingFloatValues.Count > index && CustomSettings.LookupFloatSetting(key) <= 0)
                {
                    Log.Warning("Registering custom setting from " + LabelCap + " " + key + " " + customSettingFloatValues[index]);
                    CustomSettings.SetFloatSetting(key, customSettingFloatValues[index]);
                    index++;
                    continue;
                }
            }
        }

        public int minPointsToFire = 0;

        public int maxWager = 0;

        public int variables = 0;

        public string syntax = null;

        public new Type incidentHelper = typeof(IncidentHelperVariables);

        public List<string> customSettingKeys = new List<string>();

        public List<string> customSettingStringValues = new List<string>();

        public List<float> customSettingFloatValues = new List<float>();
    }

    public static class StoreIncidentMaker
    {
        public static IncidentHelper MakeIncident(StoreIncidentSimple def)
        {
            IncidentHelper helper = (IncidentHelper)Activator.CreateInstance(def.incidentHelper);
            helper.storeIncident = def;
            return helper;
        }

        public static IncidentHelperVariables MakeIncidentVariables(StoreIncidentVariables def)
        {
            IncidentHelperVariables helper = (IncidentHelperVariables)Activator.CreateInstance(def.incidentHelper);
            helper.storeIncident = def;
            return helper;
        }      
    }

    [DefOf]
    public class StoreIncidentDefOf
    {
        public static StoreIncidentVariables Item;
    }
}
{
	"incitems" : [
	{
		"abr": "tornado",
		"price": 800,
		"karmatype": "Bad"
	},
	{
		"abr": "tornados",
		"price": 2600,
		"karmatype": "Bad"
	},
	{
		"abr": "clearweather",
		"price": 400,
		"karmatype": "Good"
	},
	{
		"abr": "rain",
		"price": 350,
		"karmatype": "Good"
	},
	{
		"abr": "vomitrain",
		"price": 650,
		"karmatype": "Neutral"
	},
	{
		"abr": "foggyrain",
		"price": 300,
		"karmatype": "Neutral"
	},
	{
		"abr": "rainythunderstorm",
		"price": 250,
		"karmatype": "Neutral"
	},
	{
		"abr": "drythunderstorm",
		"price": 450,
		"karmatype": "Bad"
	},
	{
		"abr": "snowgentle",
		"price": 350,
		"karmatype": "Neutral"
	},
	{
		"abr": "snowhard",
		"price": 450,
		"karmatype": "Bad"
	},
	{
		"abr": "fog",
		"price": 300,
		"karmatype": "Neutral"
	},
	{
		"abr": "heatwave",
		"price": 750,
		"karmatype": "Bad"
	},
	{
		"abr": "flashstorm",
		"price": 400,
		"karmatype": "Bad"
	},
	{
		"abr": "coldsnap",
		"price": 800,
		"karmatype": "Bad"
	},
	{
		"abr": "solarflare",
		"price": 500,
		"karmatype": "Bad"
	},
	{
		"abr": "shortcircuit",
		"price": 500,
		"karmatype": "Bad"
	},
	{
		"abr": "toxicfallout",
		"price": 6500,
		"karmatype": "Doom"
	},
	{
		"abr": "volcanicwinter",
		"price": 3200,
		"karmatype": "Doom"
	},
	{
		"abr": "eclipse",
		"price": 450,
		"karmatype": "Bad"
	},
	{
		"abr": "aurora",
		"price": 200,
		"karmatype": "Good"
	},
	{
		"abr": "blight",
		"price": 700,
		"karmatype": "Bad"
	},
	{
		"abr": "refugeechased",
		"price": 650,
		"karmatype": "Neutral"
	},
	{
		"abr": "animaltame",
		"price": 150,
		"karmatype": "Good"
	},
	{
		"abr": "resourcepodcrash",
		"price": 300,
		"karmatype": "Good"
	},
	{
		"abr": "transportpodcrash",
		"price": 600,
		"karmatype": "Good"
	},
	{
		"abr": "tradercaravan",
		"price": 275,
		"karmatype": "Good"
	},
	{
		"abr": "orbitaltraderarrival",
		"price": 350,
		"karmatype": "Good"
	},
	{
		"abr": "meteor",
		"price": 150,
		"karmatype": "Neutral"
	},
	{
		"abr": "maninblack",
		"price": 350,
		"karmatype": "Good"
	},
	{
		"abr": "madanimal",
		"price": 200,
		"karmatype": "Bad"
	},
	{
		"abr": "psychicdrone",
		"price": 400,
		"karmatype": "Bad"
	},
	{
		"abr": "psychicsoothe",
		"price": 250,
		"karmatype": "Good"
	},
	{
		"abr": "ambrosiasprout",
		"price": 150,
		"karmatype": "Good"
	},
	{
		"abr": "herdmigration",
		"price": 200,
		"karmatype": "Good"
	},
	{
		"abr": "farmanimals",
		"price": 400,
		"karmatype": "Good"
	},
	{
		"abr": "wildman",
		"price": 300,
		"karmatype": "Good"
	},
	{
		"abr": "rarethrumbos",
		"price": 500,
		"karmatype": "Good"
	},
	{
		"abr": "shipchunkdrop",
		"price": 300,
		"karmatype": "Good"
	},
	{
		"abr": "travelergroup",
		"price": 80,
		"karmatype": "Good"
	},
	{
		"abr": "visitorgroup",
		"price": 200,
		"karmatype": "Good"
	},
	{
		"abr": "skillincrease",
		"price": 200,
		"karmatype": "Good"
	},
	{
		"abr": "party",
		"price": 400,
		"karmatype": "Good"
	},
	{
		"abr": "alphabeavers",
		"price": 600,
		"karmatype": "Bad"
	},
	{
		"abr": "shippartpoison",
		"price": 1900,
		"karmatype": "Bad"
	},
	{
		"abr": "shippartpsychic",
		"price": 2400,
		"karmatype": "Bad"
	},
	{
		"abr": "militaryaid",
		"price": 700,
		"karmatype": "Good"
	},
	{
		"abr": "raid",
		"price": 1500,
		"karmatype": "Bad"
	},
	{
		"abr": "dropraid",
		"price": 1500,
		"karmatype": "Bad"
	},
	{
		"abr": "sapperraid",
		"price": 1500,
		"karmatype": "Bad"
	},
	{
		"abr": "siegeraid",
		"price": 2500,
		"karmatype": "Bad"
	},
	{
		"abr": "mechanoidraid",
		"price": 2500,
		"karmatype": "Bad"
	},
	{
		"abr": "infestation",
		"price": 2500,
		"karmatype": "Bad"
	},
	{
		"abr": "manhunterpack",
		"price": 1500,
		"karmatype": "Bad"
	},
	{
		"abr": "predators",
		"price": 2500,
		"karmatype": "Bad"
	},
	{
		"abr": "randomdisease",
		"price": 1000,
		"karmatype": "Bad"
	},
	{
		"abr": "disease",
		"price": 1000,
		"karmatype": "Bad"
	},
	{
		"abr": "reviveanypawn",
		"price": 1200,
		"karmatype": "Good"
	},
	{
		"abr": "pawn",
		"price": 1500,
		"karmatype": "Good"
	},
	{
		"abr": "levelskill",
		"price": 1500,
		"karmatype": "Good"
	},
	{
		"abr": "trait",
		"price": 3500,
		"karmatype": "Good"
	},
	{
		"abr": "removetrait",
		"price": 5500,
		"karmatype": "Good"
	},
	{
		"abr": "genderswap",
		"price": 600,
		"karmatype": "Neutral"
	},
	{
		"abr": "prisoner",
		"price": 800,
		"karmatype": "Good"
	},
	{
		"abr": "visitcolony",
		"price": 300,
		"karmatype": "Good"
	},
	{
		"abr": "berescued",
		"price": 900,
		"karmatype": "Good"
	},
	{
		"abr": "randominspire",
		"price": 450,
		"karmatype": "Good"
	},
	{
		"abr": "torytalkervote",
		"price": 750,
		"karmatype": "Neutral"
	},
	{
		"abr": "hodlbotvote",
		"price": 600,
		"karmatype": "Neutral"
	},
	{
		"abr": "taskforce141",
		"price": 1500,
		"karmatype": "Good"
	},
	{
		"abr": "theghosts",
		"price": 1500,
		"karmatype": "Good"
	},
	{
		"abr": "umbracompany",
		"price": 1500,
		"karmatype": "Good"
	},
	{
		"abr": "MSF",
		"price": 1500,
		"karmatype": "Good"
	},
	{
		"abr": "reversetraderequest",
		"price": 700,
		"karmatype": "Good"
	},
	{
		"abr": "woundedcombatants",
		"price": 1500,
		"karmatype": "Neutral"
	},
	{
		"abr": "pirateextortion",
		"price": 2500,
		"karmatype": "Bad"
	},
	{
		"abr": "roadworks",
		"price": 1000,
		"karmatype": "Good"
	},
	{
		"abr": "diplomaticmarriage",
		"price": 1000,
		"karmatype": "Neutral"
	},
	{
		"abr": "mysticalshaman",
		"price": 1000,
		"karmatype": "Good"
	},
	{
		"abr": "annualexpo",
		"price": 1000,
		"karmatype": "Good"
	},
	{
		"abr": "peacetalks",
		"price": 1000,
		"karmatype": "Good"
	},
	{
		"abr": "piratecamp",
		"price": 1000,
		"karmatype": "Bad"
	},
	{
		"abr": "bumpercrops",
		"price": 1000,
		"karmatype": "Neutral"
	},
	{
		"abr": "hunterslodge",
		"price": 1000,
		"karmatype": "Neutral"
	},
	{
		"abr": "baseattack",
		"price": 1000,
		"karmatype": "Neutral"
	},
	{
		"abr": "supernova",
		"price": 1500,
		"karmatype": "Good"
	},
	{
		"abr": "superheatwave",
		"price": 1800,
		"karmatype": "Bad"
	},
	{
		"abr": "bouldermasshit",
		"price": 500,
		"karmatype": "Bad"
	},
	{
		"abr": "leanatmosphere",
		"price": 6000,
		"karmatype": "Bad"
	},
	{
		"abr": "icestorm",
		"price": 2400,
		"karmatype": "Bad"
	},
	{
		"abr": "heavyair",
		"price": 6000,
		"karmatype": "Bad"
	},
	{
		"abr": "mechanoidportal",
		"price": 3200,
		"karmatype": "Bad"
	},
	{
		"abr": "beetlerush",
		"price": 12000,
		"karmatype": "Bad"
	}
	],
	"total": 92
}
