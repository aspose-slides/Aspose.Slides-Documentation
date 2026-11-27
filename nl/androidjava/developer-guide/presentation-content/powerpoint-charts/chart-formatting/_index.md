---
title: Grafieken in presentaties op Android opmaken
linktitle: Grafiekopmaak
type: docs
weight: 60
url: /nl/androidjava/chart-formatting/
keywords:
- grafiek opmaken
- grafiekopmaak
- grafiekonderdeel
- grafiekeigenschappen
- grafiekinstellingen
- grafiekopties
- lettertype‑eigenschappen
- afgeronde rand
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer grafiekopmaak in Aspose.Slides voor Android via Java en verbeter uw PowerPoint‑presentatie met aangepaste assen, lettertypen, getalopmaken en afgeronde grafiekranden."
---
## **Overzicht**

Dit artikel legt uit hoe je grafieken in PowerPoint‑presentaties kunt opmaken met Aspose.Slides. Het toont hoe je belangrijke grafiekelementen zoals assen, rasterlijnen, titels, legenden, het plotgebied en wand‑vullingen kunt aanpassen om het uiterlijk en de leesbaarheid van grafiekgegevens te verbeteren.

Het laat ook zien hoe je lettertype‑eigenschappen voor grafiektetekst instelt, vooraf gedefinieerde numerieke opmaak toepast op grafiekgegevens en afgeronde hoeken voor het grafiekgebied inschakelt. Samen laten deze voorbeelden zien hoe je zowel de visuele stijl als de gegevenspresentatie van grafieken in een presentatie kunt beheersen.

Voor afzonderlijke vullingen en contouren op stijgende en dalende intervallen, zie het [voorbeeld van beursgrafiek](/slides/nl/androidjava/create-chart/#create-stock-charts).

## **Grafiekonderdelen opmaken**

Gebruik [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) om grafiektitels, assen, rasterlijnen, legenden en het plotgebied op te maken. Dit voorbeeld maakt een lijngrafiek met markeringen en standaardgegevens, waarna afzonderlijke tekst‑ en lijnstijlen worden toegepast op de waardenas en de categorienas. Lettergrootten en lijndiktes worden opgegeven in punten; categorielabels worden 45 graden geroteerd.

De waardenas gebruikt [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) onafhankelijk van de broncellen. De schaal loopt van -2 tot 15, met hoofdintervallen van 2 en subintervallen van 0,5. Het voorbeeld combineert bovendien procent‑opmaak met [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setDisplayUnit-int-) ingesteld op duizenden, dus pas deze instellingen aan op de betekenis en omvang van je gegevens. De legende blijft buiten het plotgebied omdat [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegend/#setOverlay-boolean-) wordt aangeroepen met `false`. Vullingen voor de achterwand en de vloer worden geconfigureerd via [getBackWall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) en [getFloor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--), maar deze oppervlakken zijn alleen zichtbaar in 3D‑grafieken.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lettertype‑eigenschappen voor een grafiek instellen**

Stel de standaardlettergrootte voor grafiektetekst in via [Chart.getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getTextFormat--). Het voorbeeld maakt een gegroepeerde kolomgrafiek met een lettergrootte van 20 punten en schakelt waardelabels in voor de eerste serie via [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Tekstelementen met hun eigen expliciete lettertype‑instellingen kunnen de standaard van de grafiek overschrijven.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tekstkader‑opmaak hergebruiken voor een grafieklegende**

Om een legende af te stemmen op een dia‑kop, stel je het lettertype van de kop in via [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) op de eerste alinea. Roep [copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) aan op het formaat dat wordt geretourneerd door de legende‑[getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformattedtextcontainer/#getTextFormat--). Het kopieert de tekstkader‑instellingen, de opmaak van de eerste alinea en de standaardlettertype‑eigenschappen van die alinea. Opmaak die rechtstreeks op individuele delen of op latere alinea’s wordt toegepast, blijft lokaal voor de bron.

Het voorbeeld gebruikt een vette, 26‑punten Calibri‑kop in marineblauw als sjabloon. Na het stijlen van de legende, roept het [copyTo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) aan om dezelfde opmaak toe te passen op een apart bijschrift.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(Color.rgb(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In de opgeslagen presentatie komen legende en bijschrift overeen met de kop in grootte, gewicht en kleur. De legende toont nog steeds de serienaam, en het bijschrift behoudt zijn eigen tekst. Als een deel in het bijschrift al een expliciete lettergrootte heeft, heeft die grootte voorrang boven de gekopieerde alinea‑standaard.

| Voor het kopiëren | Na het kopiëren |
| --- | --- |
| ![Grafiek van kwartaalverkoop met gewone zwarte legendarlabels en een zwart bijschrift](legend-formatting-before.png) | ![Dezelfde grafiek met grotere, vette marineblauwe legendarlabels en een bijschrift dat overeenkomt](legend-formatting.png) |

## **Numerieke opmaak instellen**

Gebruik [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) om een ingebouwde getalopmaak toe te passen op grafiek‑werkboekcellen. Dit voorbeeld maakt een gegroepeerde kolomgrafiek met standaard‑, cel‑ondersteunde gegevens en past opmaak‑index 10 (`0.00%`) toe op elke waardecel van de serie. Hierdoor verandert de weergave van de waarden in het werkboek zonder de onderliggende getallen te wijzigen; bijvoorbeeld, 0,25 wordt weergegeven als 25,00 %. As‑ en gegevens‑label‑opmaken kunnen afzonderlijk worden geconfigureerd.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0,00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De volgende tabel geeft de ingebouwde getalopmaak‑indices weer met representatieve Excel‑opmaken voor de Engelse (Verenigde Staten) locale. De exacte opmaak‑strings en hun weergave kunnen per toepassing en locale verschillen, vooral voor valuta en datums. Sommige Excel‑opmaken wijken ook af van de standaarden in OOXML, zoals beschreven in [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Formaat |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Afgeronde hoeken voor het grafiekgebied instellen**

Roep [IChart.setRoundedCorners](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setRoundedCorners-boolean-) aan met `true` om de hoeken van het grafiekgebied af te ronden. Het voorbeeld maakt een gegroepeerde kolomgrafiek en gebruikt [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) om de omtrek een egale grijze kleur en een enkele lijnstijl te geven voordat de presentatie wordt opgeslagen.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bestaande grafiekannotaties bewerken**

Een grafiek kan aangepaste vormen bevatten, zoals een tekst‑annotatie die de status van een rapport uitlegt. Benader deze vormen via [IChart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getUserShapes--), ook vermeld onder [Chart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getUserShapes--) in de Chart‑API‑referentie. De collectie die wordt geretourneerd door [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) bevat de grafiek‑eigendom‑vormen.

Een gewone tekstvak dat boven een grafiek wordt geplaatst, behoort tot de dia, zelfs als het eruitziet als onderdeel van de grafiek. Door te itereren over [Slide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) vindt men de grafiek en de gewone dia‑vormen, maar de individuele vormen binnen de grafiek worden niet opgesomd. Grafiektitels en gegevens‑labels zijn afzonderlijke grafiekelementen, geen aangepaste annotaties in deze collectie.

Download [chart-annotations.pptx](chart-annotations.pptx) en plaats het in de werkmap van de applicatie. De eerste dia bevat een grafiek met een niet‑gegroepeerde annotatie met de tekst “Preliminary results”, een grafiek‑eigendom‑lijn, en een gewoon dia‑tekstvak met de tekst “Slide overlay”. Het voorbeeld vindt de eerste grafiek op die dia en wijzigt de annotatie naar “Final results” zodra het rapport klaar is om te publiceren. Het controleert op een lege collectie en bewerkt alleen een [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) met een niet‑null tekstkader dat wordt geretourneerd door [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) en de verwachte tekst.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

De lijn en het dia‑tekstvak blijven ongewijzigd. De volgende afbeeldingen tonen de invoer en het opgeslagen, opnieuw geopende resultaat:

| Voor het bewerken | Na het bewerken |
| --- | --- |
| ![Grafiekannotatie met de tekst Preliminary results](chart-annotations-before.png) | ![Grafiekannotatie met de tekst Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Het voorbeeld inspecteert alleen de top‑level grafiek‑eigendom‑vormen. Als een annotatie zich binnen een [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/) bevindt, inspecteer dan ook de [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--)‑collectie van die groep. Herhaal dit recursief voor geneste groepen en pas dezelfde tekstcontroles toe op hun kind‑vormen. Een groep zelf is een container; behandel het niet als een tekstvak.
{{% /alert %}}

## **FAQ**

**Kan ik halfdoorzichtige vullingen voor kolommen/gebieden instellen terwijl de rand ondoorzichtig blijft?**

Ja. Transparantie van de vulling en de omtrek worden afzonderlijk geconfigureerd. Dit is nuttig om de leesbaarheid van het raster en de gegevens in drukke visualisaties te verbeteren.

**Hoe ga ik om met gegevens‑labels die overlappen?**

Verminder de lettergrootte, schakel niet‑essentiële labelonderdelen uit (bijvoorbeeld categorieën), pas de labelpositie aan, toon alleen labels voor geselecteerde punten indien nodig, of schakel over naar het formaat “waarde + legende”.

**Kan ik verloop‑ of patroonvullingen op series toepassen?**

Ja. Series ondersteunen solide, verloop‑ en patroonvullingen. Gebruik verloopbescheiden en vermijd combinaties die het contrast met het raster en de tekst verminderen.