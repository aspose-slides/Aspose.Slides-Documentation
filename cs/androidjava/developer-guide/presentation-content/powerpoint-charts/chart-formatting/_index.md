---
title: Formátování grafů v prezentaci na Androidu
linktitle: Formátování grafu
type: docs
weight: 60
url: /cs/androidjava/chart-formatting/
keywords:
- formát grafu
- formátování grafu
- entita grafu
- vlastnosti grafu
- nastavení grafu
- volby grafu
- vlastnosti písma
- zaoblený okraj
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se formátovat grafy v Aspose.Slides pro Android přes Java a vylepšete svou PowerPoint prezentaci profesionálním, poutavým stylem."
---
## **Přehled**

Tento článek vysvětluje, jak formátovat grafy v prezentacích PowerPoint pomocí Aspose.Slides. Ukazuje, jak přizpůsobit klíčové prvky grafu, jako jsou osy, čáry mřížky, názvy, legendy, oblast vykreslování a výplně stěn, aby se zlepšil vzhled a čitelnost dat v grafu. Také ukazuje, jak nastavit vlastnosti písma pro text grafu, použít předdefinované a vlastní číselné formáty na data grafu a povolit zaoblené rohy pro oblast grafu. Tyto příklady dohromady ukazují, jak řídit jak vizuální styl, tak prezentaci dat v grafech v prezentaci.

## **Formátování entit grafu**
Aspose.Slides pro Android přes Java umožňuje vývojářům přidávat vlastní grafy do snímků od nuly. Tento článek vysvětluje, jak formátovat různé entity grafu, včetně kategoriální a hodnotové osy grafu.  
Aspose.Slides pro Android přes Java poskytuje jednoduché API pro správu různých entit grafu a jejich formátování pomocí vlastních hodnot:

1. Vytvořte instanci třídy [**Presentation**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) class.
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty a libovolným požadovaným typem (v tomto příkladu použijeme ChartType.LineWithMarkers).
1. Přistupujte k hodnotové ose grafu a nastavte následující vlastnosti:
   1. Nastavení **Line format** pro hlavní mřížkové čáry hodnotové osy
   1. Nastavení **Line format** pro vedlejší mřížkové čáry hodnotové osy
   1. Nastavení **Number Format** pro hodnotovou osu
   1. Nastavení **Min, Max, Major and Minor units** pro hodnotovou osu
   1. Nastavení **Text Properties** pro data hodnotové osy
   1. Nastavení **Title** pro hodnotovou osu
   1. Nastavení **Line Format** pro hodnotovou osu
1. Přistupujte k osu kategorie grafu a nastavte následující vlastnosti:
   1. Nastavení **Line format** pro hlavní mřížkové čáry osy kategorie
   1. Nastavení **Line format** pro vedlejší mřížkové čáry osy kategorie
   1. Nastavení **Text Properties** pro data osy kategorie
   1. Nastavení **Title** pro osu kategorie
   1. Nastavení **Label Positioning** pro osu kategorie
   1. Nastavení **Rotation Angle** pro popisky osy kategorie
1. Přistupujte k legendě grafu a nastavte **Text Properties** pro ni
1. Nastavte zobrazení legend grafu bez překrytí grafu
1. Přistupujte k **Secondary Value Axis** grafu a nastavte následující vlastnosti:
   1. Aktivujte sekundární **Value Axis**
   1. Nastavení **Line Format** pro sekundární Value Axis
   1. Nastavení **Number Format** pro sekundární Value Axis
   1. Nastavení **Min, Max, Major and Minor units** pro sekundární Value Axis
1. Nyní vykreslete první sérii grafu na sekundární hodnotové ose
1. Nastavte barvu výplně zadní stěny grafu
1. Nastavte barvu výplně oblasti vykreslování grafu
1. Zapište upravenou prezentaci do souboru PPTX

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Přístup k prvnímu snímku
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidání ukázkového grafu
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Nastavení názvu grafu
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Nastavení formátu hlavních čar mřížky pro hodnotovou osu
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Nastavení formátu vedlejších čar mřížky pro hodnotovou osu
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Nastavení číselného formátu hodnotové osy
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Nastavení maximálních a minimálních hodnot grafu
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Nastavení vlastností textu hodnotové osy
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Nastavení názvu hodnotové osy
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Nastavení formátu hlavních čar mřížky pro osu kategorie
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Nastavení formátu vedlejších čar mřížky pro osu kategorie
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Nastavení vlastností textu osy kategorie
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Nastavení názvu kategorie
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Nastavení pozice popisků osy kategorie
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Nastavení úhlu otáčení popisků osy kategorie
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Nastavení vlastností textu legendy
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Nastavte zobrazení legend grafu bez překrytí grafu

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Nastavení sekundární hodnotové osy
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Nastavení číselného formátu sekundární hodnotové osy
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Nastavení maximálních a minimálních hodnot grafu
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Nastavení barvy zadní stěny grafu
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Nastavení barvy oblasti vykreslování
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Uložení prezentace
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavení vlastností písma pro graf**
Aspose.Slides pro Android přes Java poskytuje podporu pro nastavení vlastností písma souvisejících s grafem. Postupujte podle níže uvedených kroků pro nastavení vlastností písma grafu.

- Vytvořte objekt třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .
- Přidejte graf na snímek.
- Nastavte výšku písma.
- Uložte upravenou prezentaci.

Níže je uveden ukázkový příklad.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavení číselného formátu**
Aspose.Slides pro Android přes Java poskytuje jednoduché API pro správu formátu dat grafu:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte graf s výchozími daty a libovolným požadovaným typem (v tomto příkladu se používá **ChartType.ClusteredColumn**).
1. Nastavte předdefinovaný číselný formát z možných předdefinovaných hodnot.
1. Procházejte buňky dat grafu v každé sérii grafu a nastavte číselný formát dat grafu.
1. Uložte prezentaci.
1. Nastavte vlastní číselný formát.
1. Procházejte buňky dat grafu v každé sérii grafu a nastavujte odlišný číselný formát dat grafu.
1. Uložte prezentaci.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    // Přístup k prvnímu snímku prezentace
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidání výchozího seskupeného sloupcového grafu
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Přístup ke kolekci sérií grafu
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Procházení všech sérií grafu
    for (IChartSeries ser : series) 
    {
        // Procházení každé datové buňky v sérii
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Nastavení číselného formátu
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0,00%
        }
    }

    // Ukládání prezentace
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Možné předdefinované hodnoty číselného formátu spolu s jejich indexem, které lze použít, jsou uvedeny níže:

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
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Nastavení zaoblených okrajů oblasti grafu**
Aspose.Slides pro Android přes Java poskytuje podporu pro nastavení oblasti grafu. Metody [**hasRoundedCorners**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChart#hasRoundedCorners--) a [**setRoundedCorners**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChart#setRoundedCorners-boolean-) byly přidány do rozhraní [IChart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChart) a třídy [Chart](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Chart) .

1. Vytvořte objekt třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) .
1. Přidejte graf na snímek.
1. Nastavte typ výplně a barvu výplně grafu
1. Nastavte vlastnost zaoblených rohů na True.
1. Uložte upravenou prezentaci.

Níže je uveden ukázkový příklad.  

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Mohu nastavit poloprůhledné výplně pro sloupce/oblasti a přitom zachovat okraj neprůhledný?**  
Ano. Průhlednost výplně a obrys jsou nastaveny samostatně. To je užitečné pro zlepšení čitelnosti mřížky a dat v hustých vizualizacích.

**Jak mohu zacházet s popisky dat, když se překrývají?**  
Zmenšete velikost písma, deaktivujte nepodstatné komponenty popisků (například kategorie), nastavte posun/umístění popisku, zobrazte popisky pouze pro vybrané body, pokud je to nutné, nebo změňte formát na „hodnota + legenda“.

**Mohu použít přechodové nebo vzorové výplně na série?**  
Ano. Obvykle jsou k dispozici jak jednotné, tak přechodové/vzorové výplně. V praxi používejte přechody střídmě a vyhýbejte se kombinacím, které snižují kontrast s mřížkou a textem.