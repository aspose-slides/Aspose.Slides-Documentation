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
- diagrameigenschappen
- diagraminstellingen
- diagramopties
- lettertype-eigenschappen
- afgeronde rand
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer diagramopmaak in Aspose.Slides for PHP via Java en verbeter uw PowerPoint-presentatie met professionele, opvallende styling."
---
## **Overzicht**

Dit artikel legt uit hoe u diagrammen in PowerPoint‑presentaties kunt opmaken met behulp van Aspose.Slides. Het laat zien hoe u belangrijke diagramelementen zoals assen, rasterlijnen, titels, legenda’s, het plotgebied en wandvullingen kunt aanpassen om het uiterlijk en de leesbaarheid van diagramgegevens te verbeteren.

Het laat ook zien hoe u lettertype‑eigenschappen voor diagramtekst kunt instellen, vooraf‑ingestelde en aangepaste numerieke opmaak op diagramgegevens kunt toepassen, en afgeronde hoeken voor het diagramgebied kunt inschakelen. Samen tonen deze voorbeelden hoe u zowel de visuele stijl als de weergave van gegevens in diagrammen binnen een presentatie kunt beheersen.

## **Diagramonderdelen opmaken**
Aspose.Slides for PHP via Java stelt ontwikkelaars in staat aangepaste diagrammen vanaf nul aan hun dia’s toe te voegen. Dit artikel legt uit hoe u verschillende diagramonderdelen kunt opmaken, waaronder de categorische en de waardenas.

Aspose.Slides for PHP via Java biedt een eenvoudige API voor het beheren van verschillende diagramonderdelen en het opmaken ervan met aangepaste waarden:

1. Maak een instantie van de [**Presentation**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse aan.
1. Haal een referentie naar een dia op via de index.
1. Voeg een diagram toe met standaardgegevens en een gewenst type (in dit voorbeeld gebruiken we ChartType::LineWithMarkers).
1. Benader de waardenas van het diagram en stel de volgende eigenschappen in:
   1. Instelling **Line format** voor de grote rasterlijnen van de waardenas
   1. Instelling **Line format** voor de kleine rasterlijnen van de waardenas
   1. Instelling **Number Format** voor de waardenas
   1. Instelling **Min, Max, Major and Minor units** voor de waardenas
   1. Instelling **Text Properties** voor waardenas‑gegevens
   1. Instelling **Title** voor de waardenas
   1. Instelling **Line Format** voor de waardenas
1. Benader de categorische as van het diagram en stel de volgende eigenschappen in:
   1. Instelling **Line format** voor de grote rasterlijnen van de categorische as
   1. Instelling **Line format** voor de kleine rasterlijnen van de categorische as
   1. Instelling **Text Properties** voor categorische as‑gegevens
   1. Instelling **Title** voor de categorische as
   1. Instelling **Label Positioning** voor de categorische as
   1. Instelling **Rotation Angle** voor de labels van de categorische as
1. Benader de legenda van het diagram en stel de **Text Properties** in.
1. Zet weergave van diagramlegenda’s zonder dat ze het diagram overlappen.
1. Benader de **Secondary Value Axis** van het diagram en stel de volgende eigenschappen in:
   1. Schakel de secundaire **Value Axis** in.
   1. Instelling **Line Format** voor de secundaire waardenas
   1. Instelling **Number Format** voor de secundaire waardenas
   1. Instelling **Min, Max, Major and Minor units** voor de secundaire waardenas
1. Plot nu de eerste diagramreeks op de secundaire waardenas.
1. Stel de vulkleur van de achterwand van het diagram in.
1. Stel de vulkleur van het plotgebied van het diagram in.
1. Schrijf de aangepaste presentatie weg naar een PPTX‑bestand.

```php
  # Maak een instantie van de Presentation‑klasse
  $pres = new Presentation();
  try {
    # De eerste dia benaderen
    $slide = $pres->getSlides()->get_Item(0);
    # Voorbeeld‑diagram toevoegen
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # Titel van het diagram instellen
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Opmaak van grote rasterlijnen voor de waardenas instellen
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Opmaak van kleine rasterlijnen voor de waardenas instellen
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Numeriek formaat van de waardenas instellen
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # Maximale en minimale waarden van het diagram instellen
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # Teksteigenschappen van de waardenas instellen
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Titel van de waardenas instellen
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Opmaak van grote rasterlijnen voor de categorische as instellen
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Opmaak van kleine rasterlijnen voor de categorische as instellen
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Teksteigenschappen van de categorische as instellen
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Titel van de categorische as instellen
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Positie van de labels op de categorische as instellen
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Rotatie‑hoek van de labels op de categorische as instellen
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Teksteigenschappen van de legenda’s instellen
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # De legenda’s tonen zonder dat ze het diagram overlappen
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # Secundaire waardenas instellen
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Numeriek formaat van de secundaire waardenas instellen
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # Maximale en minimale waarden van het diagram instellen
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # Kleur van de achterwand van het diagram instellen
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Kleur van het plot‑gebied instellen
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # Presentatie opslaan
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lettertype‑eigenschappen voor een diagram instellen**
Aspose.Slides for PHP via Java ondersteunt het instellen van lettertype‑gerelateerde eigenschappen voor het diagram. Volg de onderstaande stappen om de lettertype‑eigenschappen voor een diagram in te stellen.

- Maak een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/)‑klasse‑object aan.
- Voeg een diagram toe op de dia.
- Stel de letterhoogte in.
- Sla de aangepaste presentatie op.

Hieronder staat een voorbeeld.

```php
  # Maak een instantie van de Presentation‑klasse
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Numerieke opmaak instellen**
Aspose.Slides for PHP via Java biedt een eenvoudige API voor het beheren van de opmaak van diagramgegevens:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse.
1. Haal een referentie naar een dia op via de index.
1. Voeg een diagram toe met standaardgegevens en een gewenst type (in dit voorbeeld gebruiken we **ChartType::ClusteredColumn**).
1. Stel de vooraf ingestelde numerieke opmaak in vanuit de mogelijke vooraf ingestelde waarden.
1. Loop door de diagramdatacel in elke diagramreeks en stel de numerieke opmaak van de diagramgegevens in.
1. Sla de presentatie op.
1. Stel de aangepaste numerieke opmaak in.
1. Loop door de diagramdatacel in elke diagramreeks en stel een andere numerieke opmaak in.
1. Sla de presentatie op.

```php
  # Maak een instantie van de Presentation‑klasse
  $pres = new Presentation();
  try {
    # De eerste dia van de presentatie benaderen
    $slide = $pres->getSlides()->get_Item(0);
    # Een standaard gegroepeerde kolomdiagram toevoegen
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # De verzameling van diagramreeksen benaderen
    $series = $chart->getChartData()->getSeries();
    # Door alle diagramreeksen itereren
    foreach($series as $ser) {
      # Door alle datacellen in de reeks itereren
      foreach($ser->getDataPoints() as $cell) {
        # Het getalformaat instellen
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%
      }
    }
    # Presentatie opslaan
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

De mogelijke vooraf ingestelde numerieke opmaakwaarden samen met hun index worden hieronder weergegeven:

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

## **Afgeronde randen van diagramgebied instellen**
Aspose.Slides for PHP via Java ondersteunt het instellen van het diagramgebied. De methoden [**hasRoundedCorners**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/hasroundedcorners/) en [**setRoundedCorners**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/setroundedcorners/) zijn toegevoegd aan de [Chart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Chart)‑klasse.

1. Maak een [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse‑object aan.
1. Voeg een diagram toe op de dia.
1. Stel het vultype en de vulkleur van het diagram in.
1. Zet de eigenschap voor afgeronde hoeken op True.
1. Sla de aangepaste presentatie op.

Hieronder staat een voorbeeld.

```php
  # Maak een instantie van de Presentation‑klasse
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan ik halftransparante vullingen voor kolommen/gebieden instellen terwijl de rand ondoorzichtig blijft?**

Ja. De transparantie van de vulling en de omlijning worden afzonderlijk geconfigureerd. Dit is nuttig om de leesbaarheid van het raster en de gegevens in dichte visualisaties te verbeteren.

**Hoe kan ik omgaan met datalabels wanneer ze overlappen?**

Verminder de lettergrootte, schakel niet‑essentiële labelonderdelen uit (bijvoorbeeld categorieën), stel de offset/positie van het label in, toon labels alleen voor geselecteerde punten indien nodig, of wijzig de opmaak naar "waarde + legenda".

**Kan ik een verloop‑ of patroonvulling toepassen op reeksen?**

Ja. Zowel effen als verloop‑/patroonvullingen zijn doorgaans beschikbaar. Gebruik in de praktijk verlopen spaarzaam en vermijd combinaties die het contrast met het raster en de tekst verminderen.