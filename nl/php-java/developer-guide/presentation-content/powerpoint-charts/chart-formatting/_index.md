---
title: Diagrammen in presentaties opmaken in PHP
linktitle: Diagramopmaak
type: docs
weight: 60
url: /nl/php-java/chart-formatting/
keywords:
- diagram opmaken
- diagramopmaak
- diagramonderdeel
- diagram-eigenschappen
- diagraminstellingen
- diagramopties
- lettertype-eigenschappen
- afgeronde rand
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer diagramopmaak in Aspose.Slides voor PHP via Java en verbeter uw PowerPoint-presentatie met aangepaste assen, lettertypen, getalformaten en afgeronde diagramranden."
---
## **Overzicht**

Dit artikel legt uit hoe diagrammen in PowerPoint‑presentaties op te maken met Aspose.Slides. Het laat zien hoe belangrijke diagramonderdelen, zoals assen, rasterlijnen, titels, legenda’s, het plotgebied en wandvullingen, kunnen worden aangepast om het uiterlijk en de leesbaarheid van diagramgegevens te verbeteren.

Het toont ook hoe de lettertype‑eigenschappen voor diagramtekst in te stellen, vooringestelde numerieke opmaak toe te passen op diagramgegevens, en afgeronde hoeken voor het diagramgebied in te schakelen. Samen laten deze voorbeelden zien hoe zowel de visuele stijl als de gegevenspresentatie van diagrammen in een presentatie te beheersen.

Voor afzonderlijke vullingen en omtreklijnen op stijgende en dalende intervallen, zie het [voorbeeld van een aandelengrafiek](/slides/nl/php-java/create-chart/#create-stock-charts).

## **Diagramonderdelen opmaken**

Gebruik [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) om diagramtitels, assen, rasterlijnen, legenda’s en het plotgebied op te maken. Dit voorbeeld maakt een lijndiagram met markeringen en standaardgegevens, en past vervolgens afzonderlijke tekst‑ en lijnstijlen toe op de waardenas en de categorienas. Lettergrootten en lijndiktes worden opgegeven in punten; categorielabels worden gedraaid met 45 graden.

De waardenas gebruikt [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setNumberFormat) onafhankelijk van de broncellen. De schaal loopt van -2 tot 15, met hoofdintervallen van 2 en subintervallen van 0,5. Het voorbeeld combineert ook procentopmaak met [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setDisplayUnit) ingesteld op duizenden, pas deze instellingen dus aan de betekenis en omvang van uw gegevens aan. De legenda blijft buiten het plotgebied omdat [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#setOverlay) wordt aangeroepen met `false`. Achterwand‑ en vloer‑vullingen worden geconfigureerd via [getBackWall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getBackWall) en [getFloor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getFloor), maar deze oppervlakken zijn alleen zichtbaar in 3D‑diagrammen.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LineDashStyle;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\TickLabelPositionType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle::DashDot);

    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");

    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);

    $chart->getAxes()->getVerticalAxis()->setMaxValue(15);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);

    $valueAxisText = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $valueAxisText->setFontBold(NullableBool::True);
    $valueAxisText->setFontHeight(16);
    $valueAxisText->setFontItalic(NullableBool::True);
    $valueAxisText->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkGreen);
    $valueAxisText->setLatinFont(new FontData("Times New Roman"));

    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valueAxisTitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valueAxisTitle->setText("Primary Axis");
    $valueAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valueAxisTitle->getPortionFormat()->setFontHeight(20);
    $valueAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valueAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 128, 0));
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);

    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $categoryAxisText = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $categoryAxisText->setFontBold(NullableBool::True);
    $categoryAxisText->setFontHeight(16);
    $categoryAxisText->setFontItalic(NullableBool::True);
    $categoryAxisText->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisText->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $categoryAxisText->setLatinFont(new FontData("Arial"));

    $chart->getAxes()->getHorizontalAxis()->setTitle(true);
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");

    $categoryAxisTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $categoryAxisTitle->setText("Sample Category");
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $categoryAxisTitle->getPortionFormat()->setFontHeight(20);
    $categoryAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $categoryAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);

    $legendText = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $legendText->setFontBold(NullableBool::True);
    $legendText->setFontHeight(16);
    $legendText->setFontItalic(NullableBool::True);
    $legendText->getFillFormat()->setFillType(FillType::Solid);
    $legendText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkRed);

    $chart->getLegend()->setOverlay(false);

    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setPresetColor(PresetColor::LightCyan);

    $presentation->save("FormattedChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lettertype‑eigenschappen instellen voor een diagram**

Stel de standaardlettergrootte voor diagramtekst in via [Chart::getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getTextFormat). Het voorbeeld maakt een gegroepeerd kolomdiagram met een lettertype van 20 punten en schakelt waardelabels in voor de eerste reeks via [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue). Tekstelementen met hun eigen expliciete lettertype‑instellingen kunnen de standaard van het diagram overschrijven.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tekstkaderopmaak hergebruiken voor een diagramlegenda**

Om een legenda overeen te laten komen met een dia‑kop, stel het lettertype van de kop in via [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) op de eerste alinea. Roep [copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyFrom) aan op het formaat dat wordt geretourneerd door de legenda’s [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#getTextFormat). Het kopieert de instellingen van het tekstkader, de opmaak van de eerste alinea en de standaardlettertype‑eigenschappen van die alinea. Opmaak die rechtstreeks op individuele delen of op latere alinea’s wordt toegepast, blijft lokaal voor de bron.

Het voorbeeld gebruikt een vet, 26‑punt Calibri‑kop in marineblauw als sjabloon. Na het opmaken van de legenda, roept het [copyTo](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyTo) aan om dezelfde opmaak toe te passen op een aparte bijschrift.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LegendPositionType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\StyleType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $heading = $shapes->addAutoShape(ShapeType::Rectangle, 40, 20, 640, 40, false);
    $sourceTextFrame = $heading->addTextFrame("Quarterly sales");
    $font = $sourceTextFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $font->setLatinFont(new FontData("Calibri"));
    $font->setFontHeight(26);
    $font->setFontBold(NullableBool::True);
    $font->getFillFormat()->setFillType(FillType::Solid);
    $font->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 32, 64, 96));

    $chart = $shapes->addChart(ChartType::ClusteredColumn, 40, 75, 640, 360);
    $chart->setStyle(StyleType::Style3);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->getCell(0, 0, 1)->setValue("Retail");
    $workbook->getCell(0, 0, 2)->setValue("Online");
    $workbook->getCell(0, 0, 3)->setValue("Wholesale");
    for ($quarter = 1; $quarter <= 4; $quarter++) {
        $workbook->getCell(0, $quarter, 0)->setValue("Q" . $quarter);
    }

    $chart->setLegend(true);
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $legendFormat = $chart->getLegend()->getTextFormat();
    $legendFormat->copyFrom($sourceTextFrame);

    $caption = $shapes->addAutoShape(ShapeType::Rectangle, 40, 460, 640, 40, false);
    $captionTextFrame = $caption->addTextFrame("Sales in millions of dollars");
    $legendFormat->copyTo($captionTextFrame);

    $presentation->save("legend-formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

In de opgeslagen presentatie komen de legenda en het bijschrift overeen met de kop qua grootte, dikte en kleur. De legenda toont nog steeds de reeksnamen, en het bijschrift behoudt zijn eigen tekst. Als een deel in het bijschrift al een expliciete lettergrootte heeft, heeft die grootte voorrang op de gekopieerde alinea‑standaard.

| Voor het kopiëren | Na het kopiëren |
| --- | --- |
| ![Kwartaalverkoopgrafiek met gewone zwarte legenda‑labels en een zwart bijschrift](legend-formatting-before.png) | ![Dezelfde grafiek met grotere, vet marineblauwe legenda‑labels en een passend bijschrift](legend-formatting.png) |

## **Numeriek formaat instellen**

Gebruik [ChartDataCell::setPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setPresetNumberFormat) om een ingebouwd getalformaat toe te passen op werkmapcellen van het diagram. Dit voorbeeld maakt een gegroepeerd kolomdiagram met standaard, cel‑ondersteunde gegevens en past formaatindex 10 (`0.00%`) toe op elke reeks‑waardecel. Dit verandert de weergave van de waarden in de werkmap zonder de onderliggende getallen te wijzigen; bijvoorbeeld wordt 0,25 weergegeven als 25,00 %. As‑ en gegevens‑label‑formaten kunnen afzonderlijk worden geconfigureerd.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries();

    for ($i = 0; $i < java_values($series->size()); $i++) {
        $chartSeries = $series->get_Item($i);
        $dataPoints = $chartSeries->getDataPoints();
        for ($j = 0; $j < java_values($dataPoints->size()); $j++) {
            $dataPoint = $dataPoints->get_Item($j);
            $dataPoint->getValue()->getAsCell()->setPresetNumberFormat(10); // 0,00%
        }
    }

    $presentation->save("PresetNumberFormat_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

De onderstaande tabel geeft ingebouwde getalformaat‑indices weer met representatieve Excel‑formaten voor de Engelse (Verenigde Staten) locale. De exacte opmaak‑strings en hun weergave kunnen per applicatie en locale verschillen, met name voor valuta en datums. Sommige Excel‑formaten wijken ook af van de standaardwaarden in de OOXML‑norm, zoals beschreven in [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

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

## **Afgeronde randen van diagramgebied instellen**

Roep [Chart::setRoundedCorners](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setRoundedCorners) aan met `true` om de hoeken van het diagramgebied af te ronden. Het voorbeeld maakt een gegroepeerd kolomdiagram en gebruikt [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) om de omtrek een effen grijze kleur en een enkellijn‑stijl te geven vóór het opslaan van de presentatie.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chart->getLineFormat()->setStyle(LineStyle::Single);
    $chart->setRoundedCorners(true);

    $presentation->save("out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bestaande diagramannotaties bewerken**

Een diagram kan aangepaste vormen bevatten, zoals een tekstaanduiding die de status van een verslag uitlegt. Toegang tot deze vormen is via [Chart::getUserShapes](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getUserShapes). De collectie die door [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) wordt geretourneerd, bevat de diagram‑eigen vormen.

Een gewone tekstvak die boven een diagram wordt geplaatst, behoort tot de dia, zelfs als het lijkt op een onderdeel van het diagram. Door te itereren over [Slide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) worden het diagram en gewone dia‑vormen gevonden, maar worden de afzonderlijke vormen binnen het diagram niet opgesomd. Diagramtitels en gegevens‑labels zijn afzonderlijke diagramonderdelen, geen aangepaste annotaties in deze collectie.

Download [chart-annotations.pptx](chart-annotations.pptx) en plaats deze in de werkmap van de applicatie. De eerste dia bevat een diagram met een niet‑gegroepeerde annotatie met de tekst “Preliminary results”, een diagram‑eigen lijn, en een gewoon dia‑tekstvak met de tekst “Slide overlay”. Het voorbeeld vindt het eerste diagram op die dia en verandert de annotatie in “Final results” wanneer het verslag klaar is om te publiceren. Het controleert op een lege collectie en bewerkt alleen een [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) met een niet‑null tekstkader dat wordt geretourneerd door [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) en de verwachte tekst.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-annotations.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chartType = new JavaClass("com.aspose.slides.IChart");
    $autoShapeType = new JavaClass("com.aspose.slides.IAutoShape");
    $chart = null;
    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++) {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartType)) {
            $chart = $shape;
            break;
        }
    }

    if ($chart === null || java_values($chart->getUserShapes()->getShapes()->size()) == 0) {
        echo "No chart or chart-owned shapes found." . PHP_EOL;
        return;
    }

    $updated = false;
    $userShapes = $chart->getUserShapes()->getShapes();
    for ($i = 0; $i < java_values($userShapes->size()); $i++) {
        $shape = $userShapes->get_Item($i);
        if (java_instanceof($shape, $autoShapeType)) {
            $annotation = $shape;
            if (!java_is_null($annotation->getTextFrame()) && java_values($annotation->getTextFrame()->getText()) === "Preliminary results") {
                $annotation->getTextFrame()->setText("Final results");
                $updated = true;
                break;
            }
        }
    }

    if ($updated) {
        $presentation->save("chart-annotations-updated.pptx", SaveFormat::Pptx);
    } else {
        echo "No matching text annotation found." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

De lijn en het dia‑tekstvak blijven ongewijzigd. De volgende afbeeldingen tonen de invoer en het opgeslagen, heropende resultaat:

| Voor het bewerken | Na het bewerken |
| --- | --- |
| ![Diagramannotatie met de tekst Preliminary results](chart-annotations-before.png) | ![Diagramannotatie met de tekst Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Het voorbeeld inspecteert alleen de diagram‑eigen vormen op het hoogste niveau. Als een annotatie zich binnen een [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) bevindt, inspecteer dan ook de [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes)‑collectie van die groep. Herhaal dit recursief voor geneste groepen, en pas dezelfde tekstcontroles toe op hun onderliggende vormen. Een groep zelf is een container; behandel deze niet als een tekstvak.
{{% /alert %}}

## **FAQ**

**Kan ik halftransparante vullingen voor kolommen/gebieden instellen terwijl de rand ondoorzichtig blijft?**

Ja. Vullings‑transparantie en de omtreklijn worden afzonderlijk geconfigureerd. Dit is nuttig om de leesbaarheid van het raster en de gegevens in dichte visualisaties te verbeteren.

**Hoe kan ik omgaan met gegevens‑labels wanneer ze overlappen?**

Verminder de lettergrootte, schakel niet‑essentiële labelcomponenten uit (bijvoorbeeld categorieën), pas de labelpositie aan, toon labels alleen voor geselecteerde punten indien nodig, of wissel het formaat naar "waarde + legenda".

**Kan ik verloop‑ of patroonvullingen op reeksen toepassen?**

Ja. Reeksen ondersteunen effen, verloop‑ en patroonvullingen. Gebruik in de praktijk verlopen spaarzaam en vermijd combinaties die het contrast met het raster en de tekst verminderen.