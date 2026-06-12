---
title: Formátování grafů v prezentaci v C++
linktitle: Formátování grafu
type: docs
weight: 60
url: /cs/cpp/chart-formatting/
keywords:
- formát grafu
- formátování grafu
- entita grafu
- vlastnosti grafu
- nastavení grafu
- možnosti grafu
- vlastnosti písma
- zaoblený okraj
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se formátovat grafy v Aspose.Slides pro C++ a vylepšete svou PowerPoint prezentaci profesionálním, poutavým stylem."
---
## **Přehled**

Tento článek vysvětluje, jak formátovat grafy v prezentacích PowerPoint pomocí Aspose.Slides. Ukazuje, jak přizpůsobit klíčové prvky grafu, jako jsou osy, mřížkové čáry, názvy, legendy, oblast vykreslování a výplně stěn, aby se zlepšil vzhled a čitelnost dat v grafu.

Dále demonstruje, jak nastavit vlastnosti písma pro text v grafu, použít předdefinované i vlastní číselné formáty pro data grafu a povolit zaoblené rohy oblasti grafu. Tyto příklady ukazují, jak kontrolovat jak vizuální styl, tak i prezentaci dat v grafu v prezentaci.

## **Formátování entit grafu**
Aspose.Slides for C++ umožňuje vývojářům přidávat vlastní grafy do snímků od nuly. Tento článek vysvětluje, jak formátovat různé entity grafu včetně kategoriové a hodnotové osy grafu.

Aspose.Slides for C++ poskytuje jednoduché API pro správu různých entit grafu a jejich formátování pomocí vlastních hodnot:

1. Vytvořte instanci třídy **Presentation**.
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty a libovolným požadovaným typem (v tomto příkladu použijeme ChartType.LineWithMarkers).
1. Získejte přístup k hodnotové ose grafu a nastavte následující vlastnosti:
   1. Nastavení **Line format** pro hlavní mřížkové čáry hodnotové osy
   1. Nastavení **Line format** pro vedlejší mřížkové čáry hodnotové osy
   1. Nastavení **Number Format** pro hodnotovou osu
   1. Nastavení **Min, Max, Major and Minor units** pro hodnotovou osu
   1. Nastavení **Text Properties** pro data hodnotové osy
   1. Nastavení **Title** pro hodnotovou osu
   1. Nastavení **Line Format** pro hodnotovou osu
1. Získejte přístup k kategoriové ose grafu a nastavte následující vlastnosti:
   1. Nastavení **Line format** pro hlavní mřížkové čáry kategoriové osy
   1. Nastavení **Line format** pro vedlejší mřížkové čáry kategoriové osy
   1. Nastavení **Text Properties** pro data kategoriové osy
   1. Nastavení **Title** pro kategoriovou osu
   1. Nastavení **Label Positioning** pro kategoriovou osu
   1. Nastavení **Rotation Angle** pro popisky kategoriové osy
1. Získejte přístup k legendě grafu a nastavte **Text Properties** pro ni
1. Zobrazte legendy grafu tak, aby se nepřekrývaly s grafem
1. Získejte přístup k **Secondary Value Axis** grafu a nastavte následující vlastnosti:
   1. Povolení sekundární **Value Axis**
   1. Nastavení **Line Format** pro sekundární hodnotovou osu
   1. Nastavení **Number Format** pro sekundární hodnotovou osu
   1. Nastavení **Min, Max, Major and Minor units** pro sekundární hodnotovou osu
1. Vykreslete první datovou řadu na sekundární hodnotové ose
1. Nastavte výplň zadního stěny grafu
1. Nastavte výplň oblasti vykreslování grafu
1. Zapište upravenou prezentaci do souboru PPTX

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Nastavení vlastností písma pro graf**
Aspose.Slides for C++ poskytuje podporu pro nastavení vlastností písma souvisejících s grafem. Postupujte podle následujících kroků pro nastavení vlastností písma grafu.

- Vytvořte objekt třídy Presentation.
- Přidejte graf na snímek.
- Nastavte výšku písma.
- Uložte upravenou prezentaci.

Níže je uveden ukázkový příklad.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Nastavení vlastností písma pro tabulku dat grafu**
Aspose.Slides for C++ poskytuje podporu pro změnu barvy kategorií v sériovém grafu.

1. Vytvořte objekt třídy Presentation.
1. Přidejte graf na snímek.
1. Nastavte tabulku grafu.
1. Nastavte výšku písma.
1. Uložte upravenou prezentaci.

Níže je uveden ukázkový příklad.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Nastavení zaoblených okrajů oblasti grafu**
Aspose.Slides for C++ podporuje nastavení oblasti grafu. V Aspose.Slides byly přidány vlastnosti **IChart.HasRoundedCorners** a **Chart.HasRoundedCorners**.

1. Vytvořte objekt třídy Presentation.
1. Přidejte graf na snímek.
1. Nastavte typ výplně a barvu výplně grafu
1. Nastavte vlastnost zaoblených rohů na True.
1. Uložte upravenou prezentaci.

Níže je uveden ukázkový příklad.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Nastavení číselného formátu**
Aspose.Slides for C++ poskytuje jednoduché API pro správu formátu dat v grafu:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty a libovolným požadovaným typem (v tomto příkladu použijeme **ChartType.ClusteredColumn**).
1. Nastavte předdefinovaný číselný formát z možných předdefinovaných hodnot.
1. Procházejte buňky dat v každé řadě grafu a nastavte číselný formát dat grafu.
1. Uložte prezentaci.
1. Nastavte vlastní číselný formát.
1. Procházejte buňky dat v každé řadě grafu a nastavte odlišný číselný formát dat grafu.
1. Uložte prezentaci.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Možné předdefinované hodnoty číselného formátu spolu s jejich indexy, které lze použít, jsou uvedeny níže:**|
| :- | :- |
|**0**|General|
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |

## **Časté dotazy**

**Mohu nastavit poloprůhlednou výplň pro sloupce/oblasti a zároveň mít neprůhledný okraj?**

Ano. Průhlednost výplně a obrys jsou nastaveny samostatně. To je užitečné pro zlepšení čitelnosti mřížky a dat v hustých vizualizacích.

**Jak mohu řešit popisky dat, když se překrývají?**

Zmenšte velikost písma, vypněte nepodstatné komponenty popisku (například kategorie), nastavte posun/pozici popisku, zobrazte popisky jen pro vybrané body podle potřeby nebo přepněte formát na „hodnota + legenda“.

**Mohu použít gradientní nebo vzorové výplně pro sérii?**

Ano. Obvykle jsou k dispozici jak plné, tak gradientní/vzorové výplně. V praxi používejte gradienty střídmě a vyhněte se kombinacím, které snižují kontrast vůči mřížce a textu.