---
title: Formátování grafů v prezentaci v JavaScriptu
linktitle: Formátování grafu
type: docs
weight: 60
url: /cs/nodejs-java/chart-formatting/
keywords:
- formát grafu
- formátování grafu
- entita grafu
- vlastnosti grafu
- nastavení grafu
- možnosti grafu
- vlastnosti písma
- zakulacený okraj
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se formátovat grafy v Aspose.Slides pro Node.js v JavaScriptu a pozvedněte svou PowerPoint prezentaci profesionálním a poutavým stylováním."
---
## **Přehled**

Tento článek vysvětluje, jak formátovat grafy v prezentacích PowerPoint pomocí Aspose.Slides. Ukazuje, jak přizpůsobit klíčové prvky grafu, jako jsou osy, mřížkové čáry, názvy, legendy, oblast vykreslení a výplně stěn, aby se zlepšil vzhled a čitelnost dat v grafu. Také ukazuje, jak nastavit vlastnosti písma pro text v grafu, použít předdefinované a vlastní číselné formáty pro data v grafu a povolit zakulacené rohy pro oblast grafu. Tyto příklady společně ukazují, jak ovládat jak vizuální styl, tak prezentaci dat v grafech v prezentaci.

## **Formátování entit grafu**

Aspose.Slides pro Node.js přes Java umožňuje vývojářům přidávat vlastní grafy do svých snímků od začátku. Tento článek vysvětluje, jak formátovat různé entity grafu, včetně osy kategorií a osy hodnot. Aspose.Slides pro Node.js přes Java poskytuje jednoduché API pro správu různých entit grafu a jejich formátování pomocí vlastních hodnot:

1. Vytvořte instanci třídy [**Presentation**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty a libovolným požadovaným typem (v tomto příkladu použijeme ChartType.LineWithMarkers).
1. Přistupte k ose hodnot grafu a nastavte následující vlastnosti:
   1. Nastavení **Line format** pro hlavní mřížkové čáry osy hodnot
   1. Nastavení **Line format** pro vedlejší mřížkové čáry osy hodnot
   1. Nastavení **Number Format** pro osu hodnot
   1. Nastavení **Min, Max, Major and Minor units** pro osu hodnot
   1. Nastavení **Text Properties** pro data osy hodnot
   1. Nastavení **Title** pro osu hodnot
   1. Nastavení **Line Format** pro osu hodnot
1. Přistupte k ose kategorií grafu a nastavte následující vlastnosti:
   1. Nastavení **Line format** pro hlavní mřížkové čáry osy kategorií
   1. Nastavení **Line format** pro vedlejší mřížkové čáry osy kategorií
   1. Nastavení **Text Properties** pro data osy kategorií
   1. Nastavení **Title** pro osu kategorií
   1. Nastavení **Label Positioning** pro osu kategorií
   1. Nastavení **Rotation Angle** pro popisky osy kategorií
1. Přistupte k legendě grafu a nastavte pro ni **Text Properties**
1. Nastavte zobrazování legend grafu bez překrývání grafu
1. Přistupte k **Secondary Value Axis** grafu a nastavte následující vlastnosti:
   1. Povolte sekundární **Value Axis**
   1. Nastavení **Line Format** pro sekundární osu hodnot
   1. Nastavení **Number Format** pro sekundární osu hodnot
   1. Nastavení **Min, Max, Major and Minor units** pro sekundární osu hodnot
1. Nyní vykreslete první řadu grafu na sekundární osu hodnot
1. Nastavte barvu výplně zadní stěny grafu
1. Nastavte barvu výplně oblasti vykreslení grafu
1. Zapište upravenou prezentaci do souboru PPTX

```javascript
    // Vytvořte instanci třídy Presentation
    var pres = new aspose.slides.Presentation();
    try {
        // Přistupování k prvnímu snímku
        var slide = pres.getSlides().get_Item(0);
        // Přidání ukázkového grafu
        var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
        // Nastavení názvu grafu
        chart.hasTitle();
        chart.getChartTitle().addTextFrameForOverriding("");
        var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
        chartTitle.setText("Sample Chart");
        chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
        chartTitle.getPortionFormat().setFontHeight(20);
        chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
        chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
        // Nastavení formátu hlavních mřížkových čar pro osu hodnot
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
        // Nastavení formátu vedlejších mřížkových čar pro osu hodnot
        chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
        chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
        // Nastavení číselného formátu osy hodnot
        chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
        chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
        chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
        // Nastavení maximálních a minimálních hodnot grafu
        chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
        chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
        chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
        chart.getAxes().getVerticalAxis().isAutomaticMinValue();
        chart.getAxes().getVerticalAxis().setMaxValue(15.0);
        chart.getAxes().getVerticalAxis().setMinValue(-2.0);
        chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
        chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
        // Nastavení vlastností textu osy hodnot
        var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
        txtVal.setFontBold(aspose.slides.NullableBool.True);
        txtVal.setFontHeight(16);
        txtVal.setFontItalic(aspose.slides.NullableBool.True);
        txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
        txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        // Nastavení názvu osy hodnot
        chart.getAxes().getVerticalAxis().hasTitle();
        chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
        var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
        valtitle.setText("Primary Axis");
        valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
        valtitle.getPortionFormat().setFontHeight(20);
        valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
        valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
        // Nastavení formátu hlavních mřížkových čar pro osu kategorií
        chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
        chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
        // Nastavení formátu vedlejších mřížkových čar pro osu kategorií
        chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setFillFormat(java.newByte(aspose.slides.FillType.Solid));
        chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
        // Nastavení vlastností textu osy kategorií
        var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
        txtCat.setFontBold(aspose.slides.NullableBool.True);
        txtCat.setFontHeight(16);
        txtCat.setFontItalic(aspose.slides.NullableBool.True);
        txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
        txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
        // Nastavení názvu osy kategorií
        chart.getAxes().getHorizontalAxis().hasTitle();
        chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
        var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
        catTitle.setText("Sample Category");
        catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
        catTitle.getPortionFormat().setFontHeight(20);
        catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
        catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
        // Nastavení pozice popisků osy kategorií
        chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
        // Nastavení úhlu otočení popisků osy kategorií
        chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
        // Nastavení vlastností textu legendy
        var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
        txtleg.setFontBold(aspose.slides.NullableBool.True);
        txtleg.setFontHeight(16);
        txtleg.setFontItalic(aspose.slides.NullableBool.True);
        txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
        // Nastavte zobrazení legend grafu bez překrývání grafu
        chart.getLegend().setOverlay(true);
        // chart.ChartData.Series[0].PlotOnSecondAxis=true;
        chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
        // Nastavení sekundární osy hodnot
        chart.getAxes().getSecondaryVerticalAxis().isVisible();
        chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
        chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
        // Nastavení číselného formátu sekundární osy hodnot
        chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
        chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
        chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
        // Nastavení maximálních a minimálních hodnot grafu
        chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
        chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
        chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
        chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
        chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
        chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
        chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
        chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
        // Nastavení barvy zadní stěny grafu
        chart.getBackWall().setThickness(1);
        chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
        chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
        // Nastavení barvy oblasti vykreslení
        chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
        // Uložení prezentace
        pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Nastavení vlastností písma pro graf**

Aspose.Slides pro Node.js přes Java poskytuje podporu pro nastavení vlastností písma souvisejících s grafem. Postupujte podle níže uvedených kroků pro nastavení vlastností písma pro graf.

- Vytvořte objekt třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
- Přidejte graf na snímek.
- Nastavte výšku písma.
- Uložte upravenou prezentaci.

Níže je uveden ukázkový příklad.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení formátu čísel**

Aspose.Slides pro Node.js přes Java poskytuje jednoduché API pro správu formátu dat grafu:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty a libovolným požadovaným typem (v tomto příkladu používáme **ChartType.ClusteredColumn**).
1. Nastavte předdefinovaný číselný formát ze seznamu možných předdefinovaných hodnot.
1. Projděte buňky dat grafu v každé řadě grafu a nastavte číselný formát dat grafu.
1. Uložte prezentaci.
1. Nastavte vlastní číselný formát.
1. Projděte buňky dat grafu v každé řadě grafu a nastavte odlišný číselný formát dat.
1. Uložte prezentaci.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Přistupte k prvnímu snímku prezentace
    var slide = pres.getSlides().get_Item(0);
    // Přidání výchozího sloupcového grafu
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // Přístup ke sbírce sérií grafu
    var series = chart.getChartData().getSeries();
    // Procházení každé série grafu
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Procházení každé datové buňky v sérii
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // Nastavení číselného formátu
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // Uložení prezentace
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Níže jsou uvedeny možné předdefinované hodnoty číselného formátu spolu s jejich indexem, které lze použít:

|**0**|General|
| :- | :- |
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
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Nastavení zakulacených okrajů oblasti grafu**

Aspose.Slides pro Node.js přes Java poskytuje podporu pro nastavení oblasti grafu. Metody [**hasRoundedCorners**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) a [**setRoundedCorners**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) byly přidány do třídy [Chart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Chart).

1. Vytvořte objekt třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Přidejte graf na snímek.
1. Nastavte typ výplně a barvu výplně grafu
1. Nastavte vlastnost zakulacených rohů na True.
1. Uložte upravenou prezentaci.

Níže je uveden ukázkový příklad.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Mohu nastavit poloprůhledné výplně pro sloupce/oblasti a zároveň zachovat okraj neprůhledný?**

Ano. Průhlednost výplně a obrys jsou konfigurovány odděleně. To je užitečné pro zlepšení čitelnosti mřížky a dat v hustých vizualizacích.

**Jak mohu řešit popisky dat, když se překrývají?**

Zmenšete velikost písma, deaktivujte nepodstatné součásti popisků (například kategorie), nastavte odsazení/pozici popisku, zobrazte popisky jen pro vybrané body, pokud je to nutné, nebo přepněte formát na „value + legend“.

**Mohu použít gradientní nebo vzorové výplně pro řady?**

Ano. Obvykle jsou k dispozici jak plné, tak gradientní/vzorové výplně. V praxi používejte gradienty střídmě a vyhněte se kombinacím, které snižují kontrast s mřížkou a textem.