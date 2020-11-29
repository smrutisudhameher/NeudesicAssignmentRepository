using Neudesic.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Neudesic.Functionalities
{
    public static class CommonFunctions
    {
        public static void ArraytoStringValueInsertion(MyArray item, bool isMainPage = false)
        {
            try
            {
                if(isMainPage)
                {
                    if (item.currencies.Count > 0)
                    {
                        foreach (var child in item.currencies)
                            item.currenciesStr = (child != null && child.code != null && !child.code.Contains("none") && child.code.Length > 0) ?
                                item.currenciesStr + child.code + "," : item.currenciesStr;
                        if (item.currenciesStr.Contains(","))
                            item.currenciesStr = item.currenciesStr.Remove(item.currenciesStr.Length - 1);
                    }
                    else
                        item.currenciesStr = "-";
                }
                else
                {
                    if (item.topLevelDomain.Count > 0)
                    {
                        foreach (var child in item.topLevelDomain)
                            item.topLevelDomainStr = (child != null && !child.Contains("none") && child.Length > 0) ?
                                item.topLevelDomainStr + child + "," : item.topLevelDomainStr;
                        if (item.topLevelDomainStr.Contains(","))
                            item.topLevelDomainStr = item.topLevelDomainStr.Remove(item.topLevelDomainStr.Length - 1);
                    }
                    else
                        item.topLevelDomainStr = "-";
                    if (item.callingCodes.Count > 0)
                    {
                        foreach (var child in item.callingCodes)
                            item.callingCodesStr = (child != null && !child.Contains("none") && child.Length > 0) ?
                                item.callingCodesStr + child + "," : item.callingCodesStr;
                        if (item.callingCodesStr.Contains(","))
                            item.callingCodesStr = item.callingCodesStr.Remove(item.callingCodesStr.Length - 1);
                    }
                    else
                        item.callingCodesStr = "-";
                    if (item.altSpellings.Count > 0)
                    {
                        foreach (var child in item.altSpellings)
                            item.altSpellingsStr = (child != null && !child.Contains("none") && child.Length > 0) ?
                                item.altSpellingsStr + child + "," : item.altSpellingsStr;
                        if (item.altSpellingsStr.Contains(","))
                            item.altSpellingsStr = item.altSpellingsStr.Remove(item.altSpellingsStr.Length - 1);
                    }
                    else
                        item.altSpellingsStr = "-";
                    if (item.latlng.Count > 0)
                    {
                        foreach (var child in item.latlng)
                            item.latlngStr = item.latlngStr + child + ",";
                        if (item.latlngStr.Contains(","))
                            item.latlngStr = item.latlngStr.Remove(item.latlngStr.Length - 1);
                    }
                    else
                        item.latlngStr = "-";
                    if (item.timezones.Count > 0)
                    {
                        foreach (var child in item.timezones)
                            item.timezonesStr = (child != null && !child.Contains("none") && child.Length > 0) ?
                                item.timezonesStr + child + "," : item.timezonesStr;
                        if (item.timezonesStr.Contains(","))
                            item.timezonesStr = item.timezonesStr.Remove(item.timezonesStr.Length - 1);
                    }
                    else
                        item.timezonesStr = "-";
                    if (item.borders.Count > 0)
                    {
                        foreach (var child in item.borders)
                            item.bordersStr = (child != null && !child.Contains("none") && child.Length > 0) ?
                                item.bordersStr + child + "," : item.bordersStr;
                        if (item.bordersStr.Contains(","))
                            item.bordersStr = item.bordersStr.Remove(item.bordersStr.Length - 1);
                    }
                    else
                        item.bordersStr = "-";
                    if (item.currencies.Count > 0)
                    {
                        foreach (var child in item.currencies)
                            item.currenciesStr = (child != null && child.code != null && !child.code.Contains("none") && child.code.Length > 0) ?
                                item.currenciesStr + child.code + "," : item.currenciesStr;
                        if (item.currenciesStr.Contains(","))
                            item.currenciesStr = item.currenciesStr.Remove(item.currenciesStr.Length - 1);
                    }
                    else
                        item.currenciesStr = "-";
                    if (item.languages.Count > 0)
                    {
                        foreach (var child in item.languages)
                            item.languagesStr = (child != null && !child.nativeName.Contains("none") && child.nativeName.Length > 0) ?
                                item.languagesStr + child.nativeName + "," : item.languagesStr;
                        if (item.languagesStr.Contains(","))
                            item.languagesStr = item.languagesStr.Remove(item.languagesStr.Length - 1);
                    }
                    else
                        item.languagesStr = "-";
                    if (item.regionalBlocs.Count > 0)
                    {
                        foreach (var child in item.regionalBlocs)
                            item.regionalBlocsStr = (child != null && !child.acronym.Contains("none") && child.acronym.Length > 0) ?
                                item.regionalBlocsStr + child.acronym + "," : item.regionalBlocsStr;
                        if (item.regionalBlocsStr.Contains(","))
                            item.regionalBlocsStr = item.regionalBlocsStr.Remove(item.regionalBlocsStr.Length - 1);
                    }
                    else
                        item.regionalBlocsStr = "-";
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
