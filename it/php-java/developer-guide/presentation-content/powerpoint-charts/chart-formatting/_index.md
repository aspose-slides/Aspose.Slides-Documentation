---
title: Formattare i grafici delle presentazioni in PHP
linktitle: Formattazione del grafico
type: docs
weight: 60
url: /it/php-java/chart-formatting/
keywords:
- formattare grafico
- formattazione grafico
- entità del grafico
- proprietà del grafico
- impostazioni del grafico
- opzioni del grafico
- proprietà del carattere
- bordo arrotondato
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Impara la formattazione dei grafici in Aspose.Slides per PHP via Java e migliora la tua presentazione PowerPoint con assi personalizzati, caratteri, formati numerici e bordi arrotondati del grafico."
---
## **Panoramica**

Questo articolo spiega come formattare i grafici nelle presentazioni PowerPoint utilizzando Aspose.Slides. Mostra come personalizzare gli elementi chiave del grafico, come assi, linee della griglia, titoli, legende, area del grafico e riempimenti delle pareti, per migliorare l’aspetto e la leggibilità dei dati del grafico.

Dimostra inoltre come impostare le proprietà del carattere per il testo del grafico, applicare formati numerici predefiniti ai dati del grafico e abilitare gli angoli arrotondati per l’area del grafico. Insieme, questi esempi mostrano come controllare sia lo stile visivo sia la presentazione dei dati dei grafici in una presentazione.

Per riempimenti e contorni separati su intervalli in aumento e diminuzione, vedere l’[esempio di grafico azionario](/slides/it/php-java/create-chart/#create-stock-charts).

## **Formattare le Entità del Grafico**

Usa [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) per formattare titoli del grafico, assi, linee della griglia, legende e area del grafico. Questo esempio crea un grafico a linee con marcatori e dati predefiniti, quindi applica stili di testo e di linea separati ai suoi assi dei valori e delle categorie. Le dimensioni dei caratteri e gli spessori delle linee sono specificati in punti; le etichette delle categorie sono ruotate di 45 gradi.

L’asse dei valori utilizza [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setNumberFormat) in modo indipendente dalle celle di origine. La sua scala va da -2 a 15, con intervalli principali di 2 e intervalli secondari di 0,5. L’esempio combina anche la formattazione percentuale con [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setDisplayUnit) impostata su migliaia, quindi adatta queste impostazioni al significato e alla grandezza dei tuoi dati. La legenda rimane fuori dall’area del grafico perché [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#setOverlay) è chiamato con `false`. I riempimenti del retro-parete e del pavimento sono configurati tramite [getBackWall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getBackWall) e [getFloor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getFloor), ma queste superfici sono visibili solo nei grafici 3D.

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

## **Impostare le Proprietà del Carattere per un Grafico**

Imposta la dimensione predefinita del carattere per il testo del grafico tramite [Chart::getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getTextFormat). L’esempio crea un grafico a colonne raggruppate con un carattere da 20 punti e abilita le etichette dei valori per la prima serie tramite [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue). Gli elementi di testo con impostazioni di carattere esplicite possono sovrascrivere il valore predefinito del grafico.

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

## **Riutilizzare la Formattazione del Riquadro di Testo per la Legenda del Grafico**

Per far corrispondere una legenda al titolo diapositive, imposta il carattere del titolo tramite [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) sul primo paragrafo. Chiama [copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyFrom) sul formato restituito da [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#getTextFormat) della legenda. Copia le impostazioni del riquadro di testo, la formattazione del primo paragrafo e le proprietà di carattere predefinite di quel paragrafo. La formattazione applicata direttamente a singole porzioni o a paragrafi successivi rimane locale alla sorgente.

L’esempio utilizza un titolo in grassetto, Calibri da 26 punti, color navy come modello. Dopo aver stilizzato la legenda, chiama [copyTo](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyTo) per applicare la stessa formattazione a una didascalia separata.

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

Nella presentazione salvata, la legenda e la didascalia corrispondono al titolo per dimensione, peso e colore. La legenda continua a mostrare i nomi delle serie, e la didascalia mantiene il proprio testo. Se una porzione nella didascalia ha già una dimensione del carattere esplicita, tale dimensione ha la precedenza sul valore predefinito del paragrafo copiato.

| Prima della copia | Dopo la copia |
| --- | --- |
| ![Grafico vendite trimestrali con etichette legenda nere regolari e didascalia nera](legend-formatting-before.png) | ![Lo stesso grafico con etichette legenda navy più grandi, in grassetto, e didascalia corrispondente](legend-formatting.png) |

## **Impostare il Formato Numerico**

Usa [ChartDataCell::setPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setPresetNumberFormat) per applicare un formato numerico incorporato alle celle del foglio di lavoro del grafico. Questo esempio crea un grafico a colonne raggruppate con dati predefiniti basati su celle e applica l’indice di formato 10 (`0.00%`) a ciascuna cella del valore della serie. Questo modifica il modo in cui i valori sono visualizzati nel foglio di lavoro senza alterare i numeri sottostanti; ad esempio, 0,25 viene visualizzato come 25,00 %. I formati degli assi e delle etichette dati possono essere configurati separatamente.

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
            $dataPoint->getValue()->getAsCell()->setPresetNumberFormat(10); // 0.00%
        }
    }

    $presentation->save("PresetNumberFormat_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La tabella seguente elenca gli indici dei formati numerici incorporati con i formati Excel rappresentativi per la locale English (United States). Le stringhe di formato esatte e la loro visualizzazione possono variare in base all’applicazione e alla locale, in particolare per valuta e date. Alcuni formati Excel differiscono anche dai valori predefiniti nello standard OOXML, come descritto nelle [note di implementazione del formato numerico di Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Indice | Formato |
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

## **Impostare Bordi Arrotondati per l’Area del Grafico**

Chiama [Chart::setRoundedCorners](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setRoundedCorners) con `true` per arrotondare gli angoli dell’area del grafico. L’esempio crea un grafico a colonne raggruppate e utilizza [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) per dare al suo contorno un colore grigio solido e uno stile a linea singola prima di salvare la presentazione.

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

## **Modificare le Annotazioni Esistenti del Grafico**

Un grafico può contenere forme personalizzate, ad esempio un’annotazione di testo che spiega lo stato di un report. Accedi a queste forme tramite [Chart::getUserShapes](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getUserShapes). La collezione restituita da [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) contiene le forme di proprietà del grafico.

Una casella di testo ordinaria posizionata sopra un grafico appartiene alla diapositiva, anche se sembra parte del grafico. Iterare attraverso [Slide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) trova il grafico e le forme della diapositiva ordinaria, ma non elenca le singole forme all’interno del grafico. Titoli del grafico ed etichette dati sono elementi distinti del grafico, non annotazioni personalizzate in questa collezione.

Scarica [chart-annotations.pptx](chart-annotations.pptx) e posizionalo nella directory di lavoro dell’applicazione. La sua prima diapositiva contiene un grafico con un’annotazione non raggruppata che recita “Preliminary results”, una linea di proprietà del grafico e una casella di testo della diapositiva che recita “Slide overlay”. L’esempio trova il primo grafico su quella diapositiva e cambia l’annotazione in “Final results” quando il report è pronto per la pubblicazione. Controlla se la collezione è vuota e modifica solo un [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) con un riquadro di testo non nullo restituito da [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) e con il testo previsto.

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

La linea e la casella di testo della diapositiva rimangono inalterate. Le immagini seguenti mostrano l’input e il risultato salvato e riaperto:

| Prima della modifica | Dopo la modifica |
| --- | --- |
| ![Annotazione del grafico con “Preliminary results”](chart-annotations-before.png) | ![Annotazione del grafico con “Final results”](chart-annotations-after.png) |

{{% alert color="info" title="Nota" %}}
L’esempio esamina solo le forme di proprietà del grafico di livello superiore. Se un’annotazione si trova all’interno di un [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), ispeziona anche la collezione [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) di quel gruppo. Ripeti ricorsivamente per i gruppi nidificati, applicando gli stessi controlli di testo alle forme figlie. Un gruppo è un contenitore; non trattarlo come una casella di testo.
{{% /alert %}}

## **FAQ**

**Posso impostare riempimenti semi‑trasparenti per colonne/aree mantenendo il contorno opaco?**

Sì. La trasparenza del riempimento e il contorno sono configurati separatamente. È utile per migliorare la leggibilità della griglia e dei dati in visualizzazioni dense.

**Come posso gestire le etichette dei dati quando si sovrappongono?**

Riduci la dimensione del carattere, disabilita componenti dell’etichetta non essenziali (ad esempio le categorie), regola la posizione dell’etichetta, mostra le etichette solo per i punti selezionati se necessario, oppure passa al formato “valore + legenda”.

**Posso applicare riempimenti a gradiente o a motivo alle serie?**

Sì. Le serie supportano riempimenti solidi, a gradiente e a motivo. In pratica, utilizza i gradienti con parsimonia e evita combinazioni che riducono il contrasto con la griglia e il testo.