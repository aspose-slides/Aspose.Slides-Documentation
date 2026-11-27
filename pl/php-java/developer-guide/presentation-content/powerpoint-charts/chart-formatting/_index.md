---
title: Formatowanie wykresów prezentacji w PHP
linktitle: Formatowanie wykresów
type: docs
weight: 60
url: /pl/php-java/chart-formatting/
keywords:
- format wykresu
- formatowanie wykresu
- element wykresu
- właściwości wykresu
- ustawienia wykresu
- opcje wykresu
- właściwości czcionki
- zaokrąglone obramowanie
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Poznaj formatowanie wykresów w Aspose.Slides dla PHP przy użyciu Java i podnieś swoją prezentację PowerPoint dzięki niestandardowym osiom, czcionkom, formatom liczb i zaokrąglonym obramowaniom wykresu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak formatować wykresy w prezentacjach PowerPoint przy użyciu Aspose.Slides. Pokazuje, jak dostosować kluczowe elementy wykresu, takie jak osie, linie siatki, tytuły, legendy, obszar wykresu oraz wypełnienia ścian, aby poprawić wygląd i czytelność danych wykresu.

Pokazuje również, jak ustawić właściwości czcionki dla tekstu wykresu, zastosować wstępnie zdefiniowane formaty liczbowe do danych wykresu oraz włączyć zaokrąglone rogi obszaru wykresu. Razem te przykłady pokazują, jak kontrolować zarówno styl wizualny, jak i prezentację danych wykresów w prezentacji.

Aby uzyskać oddzielne wypełnienia i kontury w rosnących i spadających przedziałach, zobacz [przykład wykresu akcji](/slides/pl/php-java/create-chart/#create-stock-charts).

## **Formatuj elementy wykresu**

Użyj [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/), aby formatować tytuły wykresu, osie, linie siatki, legendy oraz obszar wykresu. Ten przykład tworzy wykres liniowy z znacznikami i danymi domyślnymi, a następnie stosuje oddzielne style tekstu i linii dla osi wartości i osi kategorii. Rozmiary czcionek i szerokości linii są podawane w punktach; etykiety kategorii są obrócone o 45 stopni.

Oś wartości używa [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setNumberFormat) niezależnie od komórek źródłowych. Jej skala rozciąga się od -2 do 15, z głównymi interwałami co 2 i mniejszymi co 0,5. Przykład łączy także formatowanie procentowe z [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setDisplayUnit) ustawionym na tysiące, więc dostosuj te ustawienia do znaczenia i wielkości swoich danych. Legenda pozostaje poza obszarem wykresu, ponieważ [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#setOverlay) jest wywoływana z wartością `false`. Wypełnienia tylnej ściany i podłogi są konfigurowane za pomocą [getBackWall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getBackWall) oraz [getFloor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getFloor), ale te powierzchnie są widoczne tylko w wykresach 3D.

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

## **Ustaw właściwości czcionki dla wykresu**

Ustaw domyślny rozmiar czcionki dla tekstu wykresu za pomocą [Chart::getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getTextFormat). Przykład tworzy wykres słupkowy grupowany z czcionką 20 punktów i włącza etykiety wartości dla pierwszej serii za pomocą [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue). Elementy tekstowe z własnymi wyraźnymi ustawieniami czcionki mogą nadpisać domyślne ustawienie wykresu.

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

## **Ponowne użycie formatowania ramki tekstowej dla legendy wykresu**

Aby dopasować legendę do nagłówka slajdu, ustaw czcionkę nagłówka za pomocą [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) w pierwszym paragrafie. Wywołaj [copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyFrom) na formacie zwróconym przez [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#getTextFormat) legendy. Kopiuje to ustawienia ramki tekstowej, formatowanie pierwszego paragrafu oraz domyślne właściwości czcionki tego paragrafu. Formatowanie zastosowane bezpośrednio do poszczególnych fragmentów lub późniejszych paragrafów pozostaje lokalne dla źródła.

Przykład używa pogrubionego nagłówka Calibri 26‑punktowego w kolorze granatowym jako szablonu. Po sformatowaniu legendy wywołuje [copyTo](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyTo), aby zastosować to samo formatowanie do oddzielnego podpisu.

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

W zapisanej prezentacji legenda i podpis odpowiadają nagłówkowi pod względem rozmiaru, grubości i koloru. Legenda nadal wyświetla nazwy serii, a podpis zachowuje własny tekst. Jeśli fragment w podpisie ma już określony rozmiar czcionki, ten rozmiar ma pierwszeństwo przed skopiowanym domyślnym rozmiarem paragrafu.

| Przed kopiowaniem | Po kopiowaniu |
| --- | --- |
| ![Wykres sprzedaży kwartalnej z regularnymi czarnymi etykietami legendy i czarnym podpisem](legend-formatting-before.png) | ![Ten sam wykres z większymi, pogrubionymi, granatowymi etykietami legendy i dopasowanym podpisem](legend-formatting.png) |

## **Ustaw format liczbowy**

Użyj [ChartDataCell::setPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setPresetNumberFormat), aby zastosować wbudowany format liczbowy do komórek skoroszytu wykresu. Ten przykład tworzy wykres słupkowy grupowany z domyślnymi danymi opartymi na komórkach i stosuje indeks formatu 10 (`0.00%`) do każdej komórki wartości serii. Zmienia to sposób wyświetlania wartości w skoroszycie bez zmiany rzeczywistych liczb; na przykład 0,25 jest wyświetlane jako 25,00%. Formaty osi i etykiet danych można konfigurować osobno.

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

Poniższa tabela zawiera wbudowane indeksy formatów liczbowych wraz z przykładowymi formatami Excel dla ustawień języka angielskiego (Stany Zjednoczone). Dokładne ciągi formatów i ich wyświetlanie mogą się różnić w zależności od aplikacji i regionu, zwłaszcza dla walut i dat. Niektóre formaty Excel różnią się również od domyślnych w standardzie OOXML, jak opisano w [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Indeks | Format |
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

## **Ustaw zaokrąglone krawędzie obszaru wykresu**

Wywołaj [Chart::setRoundedCorners](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setRoundedCorners) z wartością `true`, aby zaokrąglić rogi obszaru wykresu. Przykład tworzy wykres słupkowy grupowany i używa [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat), aby nadać jego konturowi jednolity szary kolor oraz styl pojedynczej linii przed zapisaniem prezentacji.

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

## **Edytuj istniejące adnotacje wykresu**

Wykres może zawierać własne kształty, takie jak adnotacja tekstowa wyjaśniająca status raportu. Uzyskaj dostęp do tych kształtów poprzez [Chart::getUserShapes](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getUserShapes). Kolekcja zwracana przez [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) zawiera kształty należące do wykresu.

Zwykłe pole tekstowe umieszczone nad wykresem należy do slajdu, nawet jeśli wygląda jak część wykresu. Iterowanie przez [Slide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) znajduje wykres oraz zwykłe kształty slajdu, ale nie wylicza poszczególnych kształtów wewnątrz wykresu. Tytuły wykresów i etykiety danych są oddzielnymi elementami wykresu, a nie własnymi adnotacjami w tej kolekcji.

Pobierz [chart-annotations.pptx](chart-annotations.pptx) i umieść go w katalogu roboczym aplikacji. Jej pierwszy slajd zawiera wykres z niegrupowaną adnotacją o treści „Preliminary results”, linią należącą do wykresu oraz zwykłym polem tekstowym slajdu o treści „Slide overlay”. Przykład znajduje pierwszy wykres na tym slajdzie i zmienia adnotację na „Final results”, gdy raport jest gotowy do publikacji. Sprawdza, czy kolekcja nie jest pusta i edytuje jedynie [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) z nie‑nullową ramką tekstową zwróconą przez [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) oraz oczekiwanym tekstem.

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

Linia i pole tekstowe slajdu pozostają niezmienione. Poniższe obrazy pokazują wejściowy plik i zapisany, ponownie otwarty wynik:

| Przed edycją | Po edycji |
| --- | --- |
| ![Adnotacja wykresu z napisem "Preliminary results"](chart-annotations-before.png) | ![Adnotacja wykresu z napisem "Final results"](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Przykład sprawdza tylko kształty na najwyższym poziomie należące do wykresu. Jeśli adnotacja znajduje się wewnątrz [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), należy również przejrzeć kolekcję [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) tego grupy. Powtarzaj to rekurencyjnie dla zagnieżdżonych grup, stosując te same kontrole tekstu do ich podrzędnych kształtów. Grupa sama w sobie jest kontenerem; nie traktuj jej jako pola tekstowego.
{{% /alert %}}

## **FAQ**

**Czy mogę ustawić półprzezroczyste wypełnienia dla kolumn/obszarów, zachowując nieprzezroczyste obramowanie?**

Tak. Przezroczystość wypełnienia i kontur są konfigurowane osobno. Jest to przydatne do zwiększenia czytelności siatki i danych w gęstych wizualizacjach.

**Jak mogę poradzić sobie z nakładającymi się etykietami danych?**

Zredukuj rozmiar czcionki, wyłącz nieistotne elementy etykiet (na przykład kategorie), dostosuj położenie etykiet, wyświetlaj etykiety tylko dla wybranych punktów w razie potrzeby lub przełącz format na „wartość + legenda”.

**Czy mogę zastosować wypełnienia gradientowe lub wzorcowe do serii?**

Tak. Serie obsługują wypełnienia jednorodne, gradientowe i wzorcowe. W praktyce stosuj gradienty oszczędnie i unikaj kombinacji, które obniżają kontrast względem siatki i tekstu.