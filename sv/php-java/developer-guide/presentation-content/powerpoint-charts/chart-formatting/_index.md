---
title: Formatera presentationsdiagram i PHP
linktitle: Diagramformatering
type: docs
weight: 60
url: /sv/php-java/chart-formatting/
keywords:
- formatera diagram
- diagramformatering
- diagramobjekt
- diagramegenskaper
- diagraminställningar
- diagramalternativ
- teckensnittsegenskaper
- runda kanter
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig diagramformatering i Aspose.Slides för PHP via Java och lyft din PowerPoint-presentation med professionell, iögonfallande stil."
---
## **Översikt**

Denna artikel förklarar hur man formaterar diagram i PowerPoint‑presentationer med Aspose.Slides. Den visar hur man anpassar viktiga diagram‑element som axlar, rutnätlinjer, titlar, legender, plotområdet och väggfyllningar för att förbättra utseendet och läsbarheten för diagramdata.

Den demonstrerar också hur man anger teckensnittsegenskaper för diagramtext, tillämpar fördefinierade och anpassade numeriska format på diagramdata samt aktiverar runda hörn för diagramområdet. Tillsammans visar dessa exempel hur man styr både den visuella stilen och datapresentationen i diagram i en presentation.

## **Formatera diagram‑entiteter**
Aspose.Slides för PHP via Java låter utvecklare lägga till anpassade diagram på sina bilder från grunden. Denna artikel förklarar hur man formaterar olika diagram‑entiteter inklusive diagram‑kategorial axel och värdeaxel.

Aspose.Slides för PHP via Java tillhandahåller ett enkelt API för att hantera olika diagram‑entiteter och formatera dem med anpassade värden:

1. Skapa en instans av klassen [**Presentation**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata samt någon av önskade typer (i detta exempel använder vi ChartType::LineWithMarkers).
1. Åtkomst till diagrammets **värdeaxel** och ange följande egenskaper:
   1. Ställ in **Linjeformat** för värdeaxelns huvudrutnätlinjer
   1. Ställ in **Linjeformat** för värdeaxelns delrutnätlinjer
   1. Ställ in **Nummerformat** för värdeaxeln
   1. Ställ in **Min, Max, Huvud‑ och delenheter** för värdeaxeln
   1. Ställ in **Textegenskaper** för värdeaxelns data
   1. Ställ in **Titel** för värdeaxeln
   1. Ställ in **Linjeformat** för värdeaxeln
1. Åtkomst till diagrammets **kategorialaxel** och ange följande egenskaper:
   1. Ställ in **Linjeformat** för huvudrutnätlinjer på kategorialaxeln
   1. Ställ in **Linjeformat** för delrutnätlinjer på kategorialaxeln
   1. Ställ in **Textegenskaper** för kategorialaxelns data
   1. Ställ in **Titel** för kategorialaxeln
   1. Ställ in **Etikettspositionering** för kategorialaxeln
   1. Ställ in **Rotationsvinkel** för etiketter på kategorialaxeln
1. Åtkomst till diagrammets legend och ange **Textegenskaper** för dem
1. Visa diagramlegender utan att de överlappar diagrammet
1. Åtkomst till diagrammets **sekundära värdeaxel** och ange följande egenskaper:
   1. Aktivera den sekundära **värdeaxeln**
   1. Ställ in **Linjeformat** för den sekundära värdeaxeln
   1. Ställ in **Nummerformat** för den sekundära värdeaxeln
   1. Ställ in **Min, Max, Huvud‑ och delenheter** för den sekundära värdeaxeln
1. Plotta nu den första diagramserien på den sekundära värdeaxeln
1. Ange färg för diagrammets bakre väggfyllning
1. Ange färg för diagrammets plotområdefyllning
1. Skriv den modifierade presentationen till en PPTX‑fil

```php
  # Skapa en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    # Åtkomst till den första bilden
    $slide = $pres->getSlides()->get_Item(0);
    # Lägger till exempeldiagrammet
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # Ställer in diagramtitel
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Ställer in format för huvudrutnätlinjer för värdeaxeln
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # Ställer in format för delrutnätlinjer för värdeaxeln
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Ställer in värdeaxelns talformat
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # Ställer in diagrammets maximala och minimala värden
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # Ställer in textegenskaper för värdeaxeln
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # Ställer in värdeaxelns titel
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Ställer in format för huvudrutnätlinjer för kategorialaxeln
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # Ställer in format för delrutnätlinjer för kategorialaxeln
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # Ställer in textegenskaper för kategorialaxeln
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # Ställer in kategori‑titel
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # Ställer in position för kategori‑axelns etiketter
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # Ställer in rotationsvinkel för kategori‑axelns etiketter
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # Ställer in textegenskaper för legender
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # Ställ in att visa diagramlegender utan att överlappa diagrammet
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # Ställer in sekundär värdeaxel
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # Ställer in nummerformat för sekundär värdeaxel
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # Ställer in diagrammets maximala och minimala värden
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # Ställer in diagrammets bakre väggfärg
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # Ställer in plotområdets färg
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # Spara presentationen
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange teckensnittsegenskaper för ett diagram**
Aspose.Slides för PHP via Java erbjuder stöd för att ange teckensnittsegenskaper för diagrammet. Följ stegen nedan för att ange teckensnittsegenskaper för diagrammet.

- Instansiera objektet för klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
- Lägg till ett diagram på bilden.
- Ange teckensnittshöjd.
- Spara den modifierade presentationen.

Nedan följer ett exempel.

```php
  # Skapa en instans av Presentation-klassen
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

## **Ange numeriskt format**
Aspose.Slides för PHP via Java tillhandahåller ett enkelt API för att hantera diagramdatats format:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
1. Hämta en bilds referens via dess index.
1. Lägg till ett diagram med standarddata samt någon av önskade typer (detta exempel använder **ChartType::ClusteredColumn**).
1. Ange det fördefinierade nummerformatet från de möjliga fördefinierade värdena.
1. Gå igenom diagramdatacellerna i varje diagramserie och ange diagramdatans nummerformat.
1. Spara presentationen.
1. Ange det anpassade nummerformatet.
1. Gå igenom diagramdatacellerna i varje diagramserie och ange ett annat nummerformat för diagramdata.
1. Spara presentationen.

```php
  # Skapa en instans av Presentation-klassen
  $pres = new Presentation();
  try {
    # Åtkomst till den första presentationsbilden
    $slide = $pres->getSlides()->get_Item(0);
    # Lägger till ett standardklustrat kolumndiagram
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # Åtkomst till diagramseriens samling
    $series = $chart->getChartData()->getSeries();
    # Gå igenom varje diagramserie
    foreach($series as $ser) {
      # Gå igenom varje datacell i serien
      foreach($ser->getDataPoints() as $cell) {
        # Ställer in talformatet
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0,00%
      }
    }
    # Sparar presentationen
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

De möjliga fördefinierade nummerformatvärdena tillsammans med deras index som kan användas visas nedan:

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

## **Ange rundade kanter för diagramområde**
Aspose.Slides för PHP via Java erbjuder stöd för att ange diagramområde. Metoderna [**hasRoundedCorners**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/hasroundedcorners/) och [**setRoundedCorners**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/chart/setroundedcorners/) har lagts till i klassen [Chart](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Chart).

1. Instansiera objektet för klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
1. Lägg till ett diagram på bilden.
1. Ange fyllningstyp och fyllningsfärg för diagrammet
1. Ställ in egenskapen för rundade hörn till **True**.
1. Spara den modifierade presentationen.

Nedan följer ett exempel.

```php
  # Skapa en instans av Presentation-klassen
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

**Kan jag ange halvtransparenta fyllningar för kolumner/områden samtidigt som kanten förblir opak?**

Ja. Fyllningens transparens och konturen konfigureras separat. Detta är användbart för att förbättra läsbarheten i rutnätet och data i täta visualiseringar.

**Hur kan jag hantera datalabels när de överlappar?**

Minska teckensnittsstorleken, inaktivera icke‑nödvändiga labelkomponenter (t.ex. kategorier), justera etikettens förskjutning/position, visa etiketter endast för valda punkter vid behov, eller byt format till "värde + legend".

**Kan jag applicera gradient‑ eller mönsterfyllningar på serier?**

Ja. Både solida och gradient‑/mönsterfyllningar är vanligtvis tillgängliga. I praktiken bör gradienter användas sparsamt och undvika kombinationer som minskar kontrasten mot rutnätet och texten.