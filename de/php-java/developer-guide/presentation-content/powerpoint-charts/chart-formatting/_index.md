---
title: Formatieren von Präsentationsdiagrammen in PHP
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/php-java/chart-formatting/
keywords:
- Diagramm formatieren
- Diagrammformatierung
- Diagramm-Entität
- Diagrammeigenschaften
- Diagrammeinstellungen
- Diagrammoptionen
- Schrifteigenschaften
- Abgerundeter Rand
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie mehr über die Diagrammformatierung in Aspose.Slides für PHP via Java und verbessern Sie Ihre PowerPoint-Präsentation mit benutzerdefinierten Achsen, Schriften, Zahlenformaten und abgerundeten Diagrammrändern."
---
## **Übersicht**

Dieser Artikel erklärt, wie Diagramme in PowerPoint‑Präsentationen mit Aspose.Slides formatiert werden. Er zeigt, wie wichtige Diagrammelemente wie Achsen, Gitternetzlinien, Titel, Legenden, der Plot‑Bereich und Wandfüllungen angepasst werden können, um das Erscheinungsbild und die Lesbarkeit von Diagrammdaten zu verbessern.

Er demonstriert außerdem, wie Schriftarteigenschaften für Diagrammtext festgelegt, vordefinierte Zahlenformate auf Diagrammdaten angewendet und abgerundete Ecken für den Diagrammbereich aktiviert werden. Zusammen zeigen diese Beispiele, wie sowohl der visuelle Stil als auch die Datenpräsentation von Diagrammen in einer Präsentation gesteuert werden können.

Für getrennte Füllungen und Konturen bei steigenden und fallenden Intervallen siehe das [Beispiel für Aktiendiagramm](/slides/de/php-java/create-chart/#create-stock-charts).

## **Diagramm‑Entitäten formatieren**

Verwenden Sie [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) um Diagrammtitel, Achsen, Gitternetzlinien, Legenden und den Plot‑Bereich zu formatieren. Dieses Beispiel erstellt ein Liniendiagramm mit Markern und Standarddaten und wendet dann separate Text‑ und Linienstile auf seine Werte‑ und Kategorienachsen an. Schriftgrößen und Linienbreiten werden in Punkten angegeben; Kategorienbeschriftungen werden um 45 Grad gedreht.

Die Werteachse verwendet [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setNumberFormat) unabhängig von den Quellzellen. Ihr Wertebereich reicht von -2 bis 15, mit Hauptintervallen von 2 und Nebenintervallen von 0,5. Das Beispiel kombiniert außerdem Prozentformatierung mit [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setDisplayUnit), das auf Tausend eingestellt ist; passen Sie diese Einstellungen an die Bedeutung und Größe Ihrer Daten an. Die Legende bleibt außerhalb des Plot‑Bereichs, weil [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#setOverlay) mit `false` aufgerufen wird. Rückwand‑ und Bodenfüllungen werden über [getBackWall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getBackWall) und [getFloor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getFloor) konfiguriert, aber diese Flächen sind nur in 3D‑Diagrammen sichtbar.

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

## **Schriftarteigenschaften für ein Diagramm festlegen**

Legen Sie die Standardschriftgröße für Diagrammtext über [Chart::getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getTextFormat) fest. Das Beispiel erstellt ein gruppiertes Säulendiagramm mit einer 20‑Punkt‑Schrift und aktiviert Wertbeschriftungen für die erste Serie über [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue). Textelemente mit eigenen expliziten Schrifteinstellungen können den Diagramm‑Standard überschreiben.

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

## **Textfeldformatierung für eine Diagrammlegende wiederverwenden**

Um eine Legende an eine Folienüberschrift anzupassen, setzen Sie die Schrift der Überschrift über [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) im ersten Absatz. Rufen Sie [copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyFrom) auf dem Format auf, das von der Legende über [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#getTextFormat) zurückgegeben wird. Damit werden die Textrahmen‑Einstellungen, die Formatierung des ersten Absatzes und die Standard‑Schrifteigenschaften dieses Absatzes kopiert. Direkt auf einzelne Textabschnitte oder auf spätere Absätze angewendete Formatierungen bleiben auf die Quelle beschränkt.

Das Beispiel verwendet als Vorlage eine fette, 26‑Punkt‑Calibri‑Überschrift in Marineblau. Nach dem Stylen der Legende ruft es [copyTo](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyTo) auf, um dieselbe Formatierung auf eine separate Beschriftung anzuwenden.

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

In der gespeicherten Präsentation entsprechen Legende und Beschriftung der Überschrift in Größe, Stärke und Farbe. Die Legende zeigt weiterhin die Seriennamen an, und die Beschriftung behält ihren eigenen Text. Hat ein Abschnitt in der Beschriftung bereits eine explizite Schriftgröße, so hat diese Vorrang vor dem kopierten Absatz‑Standard.

| Vor dem Kopieren | Nach dem Kopieren |
| --- | --- |
| ![Quartalsverkaufsdiagramm mit normalen schwarzen Legendenbeschriftungen und einer schwarzen Beschriftung](legend-formatting-before.png) | ![Dasselbe Diagramm mit größeren, fetten, marineblauen Legendenbeschriftungen und einer passenden Beschriftung](legend-formatting.png) |

## **Numerisches Format festlegen**

Verwenden Sie [ChartDataCell::setPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setPresetNumberFormat), um ein integriertes Zahlenformat auf Diagramm‑Arbeitsmappenzellen anzuwenden. Dieses Beispiel erstellt ein gruppiertes Säulendiagramm mit Standard‑, zellbasierten Daten und wendet das Format‑Index 10 (`0.00%`) auf jede Werte‑Zelle der Serie an. Dadurch ändert sich die Anzeige der Werte in der Arbeitsmappe, ohne die zugrunde liegenden Zahlen zu ändern; zum Beispiel wird 0,25 als 25,00 % angezeigt. Achsen‑ und Datenbeschriftungsformate können separat konfiguriert werden.

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

Die folgende Tabelle listet integrierte Zahlenformat‑Indizes mit repräsentativen Excel‑Formaten für das englische (USA‑) Gebietsschema auf. Die genauen Formatzeichenketten und deren Anzeige können je nach Anwendung und Gebietsschema variieren, insbesondere bei Währungen und Datumsangaben. Einige Excel‑Formate unterscheiden sich außerdem von den Vorgaben des OOXML‑Standards, wie in den [Hinweisen zur Implementierung von Microsofts Zahlenformaten](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) beschrieben.

| Index | Format |
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

## **Abgerundete Ränder für den Diagrammbereich festlegen**

Rufen Sie [Chart::setRoundedCorners](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setRoundedCorners) mit `true` auf, um die Ecken des Diagrammbereichs abzurunden. Das Beispiel erstellt ein gruppiertes Säulendiagramm und verwendet [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat), um seiner Kontur eine einfarbige graue Farbe und einen einlinigen Stil zu geben, bevor die Präsentation gespeichert wird.

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

## **Vorhandene Diagramm‑Anmerkungen bearbeiten**

Ein Diagramm kann benutzerdefinierte Formen enthalten, z. B. eine Textanmerkung, die den Status eines Berichts erklärt. Greifen Sie über [Chart::getUserShapes](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getUserShapes) auf diese Formen zu. Die von [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) zurückgegebene Sammlung enthält die diagrammeigenen Formen.

Ein normales Textfeld, das über ein Diagramm platziert wird, gehört zur Folie, selbst wenn es wie ein Teil des Diagramms aussieht. Das Durchlaufen von [Slide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) findet das Diagramm und reguläre Folienformen, enumeriert jedoch nicht die einzelnen Formen im Diagramm. Diagrammtitel und Datenbeschriftungen sind separate Diagrammelemente, keine benutzerdefinierten Anmerkungen in dieser Sammlung.

Download [chart-annotations.pptx](chart-annotations.pptx) und legen Sie sie im Arbeitsverzeichnis der Anwendung ab. Die erste Folie enthält ein Diagramm mit einer nicht gruppierten Anmerkung „Vorläufige Ergebnisse“, einer diagrammeigenen Linie und einem normalen Folientextfeld mit dem Text „Folienüberlagerung“. Das Beispiel findet das erste Diagramm auf dieser Folie und ändert die Anmerkung zu „Endergebnisse“, wenn der Bericht zur Veröffentlichung bereit ist. Es prüft, ob die Sammlung leer ist, und bearbeitet nur ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) mit einem nicht‑null‑Textrahmen, der von [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) zurückgegeben wird, und den erwarteten Text.

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

Die Linie und das Folientextfeld bleiben unverändert. Die folgenden Bilder zeigen die Eingabe und das gespeicherte, erneut geöffnete Ergebnis:

| Vor dem Bearbeiten | Nach dem Bearbeiten |
| --- | --- |
| ![Diagramm‑Anmerkung mit dem Text Vorläufige Ergebnisse](chart-annotations-before.png) | ![Diagramm‑Anmerkung mit dem Text Endergebnisse](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Das Beispiel untersucht nur die diagrammeigenen Formen der obersten Ebene. Befindet sich eine Anmerkung innerhalb einer [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), prüfen Sie zudem die [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes)-Sammlung dieser Gruppe. Wiederholen Sie dies rekursiv für verschachtelte Gruppen und wenden Sie dieselben Textprüfungen auf deren Kindformen an. Eine Gruppe selbst ist ein Container; behandeln Sie sie nicht als Textfeld.
{{% /alert %}}

## **FAQ**

**Kann ich halbtransparente Füllungen für Spalten/Bereiche verwenden, während die Kontur undurchsichtig bleibt?**

Ja. Fülltransparenz und Kontur werden separat konfiguriert. Das ist nützlich, um die Lesbarkeit des Gitternetzes und der Daten in dicht gepackten Visualisierungen zu verbessern.

**Wie kann ich mit überlappenden Datenbeschriftungen umgehen?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungskomponenten (z. B. Kategorien), passen Sie die Beschriftungsposition an, zeigen Sie Beschriftungen nur für ausgewählte Punkte an, falls nötig, oder wechseln Sie das Format zu „Wert + Legende“.

**Kann ich Farbverlauf‑ oder Musterfüllungen auf Serien anwenden?**

Ja. Serien unterstützen einheitliche, verlaufende und Musterfüllungen. Verwenden Sie Verläufe sparsam und vermeiden Sie Kombinationen, die den Kontrast zum Gitter und Text verringern.