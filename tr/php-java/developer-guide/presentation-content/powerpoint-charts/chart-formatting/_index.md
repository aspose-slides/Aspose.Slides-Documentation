---
title: PHP'de Sunum Grafiklerini Biçimlendir
linktitle: Grafik Biçimlendirme
type: docs
weight: 60
url: /tr/php-java/chart-formatting/
keywords:
- grafik biçimlendirme
- grafik formatlama
- grafik varlığı
- grafik özellikleri
- grafik ayarları
- grafik seçenekleri
- yazı tipi özellikleri
- yuvarlatılmış kenar
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Java aracılığıyla PHP için Aspose.Slides'te grafik biçimlendirmeyi öğrenin ve özel eksenler, yazı tipleri, sayı biçimleri ve yuvarlatılmış grafik kenarlarıyla PowerPoint sunumunuzu yükseltin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarındaki grafikleri nasıl biçimlendireceğinizi açıklar. Eksenler, ızgara çizgileri, başlıklar, açıklamalar, çizim alanı ve duvar doldurmaları gibi ana grafik öğelerini özelleştirerek grafik verilerinin görünümünü ve okunabilirliğini artırmayı gösterir.

Ayrıca grafik metni için yazı tipi özelliklerini nasıl ayarlayacağınızı, grafik verilerine önceden tanımlı sayı biçimlerini nasıl uygulayacağınızı ve grafik alanı için yuvarlatılmış köşeleri nasıl etkinleştireceğinizi gösterir. Bu örnekler birlikte, bir sunumdaki grafiklerin hem görsel stilini hem de veri sunumunu nasıl kontrol edeceğinizi gösterir.

For separate fills and outlines on rising and falling intervals, see the [stok grafik örneği](/slides/tr/php-java/create-chart/#create-stock-charts).

## **Grafik Öğelerini Biçimlendir**

Grafik başlıklarını, eksenleri, ızgara çizgilerini, açıklamaları ve çizim alanını biçimlendirmek için [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) kullanın. Bu örnek, işaretleyiciler ve varsayılan verilerle bir çizgi grafik oluşturur ve ardından değer ve kategori eksenlerine ayrı metin ve çizgi stilleri uygular. Yazı tipi boyutları ve çizgi kalınlıkları puan cinsinden belirtilir; kategori etiketleri 45 derece döndürülür.

Değer ekseni, kaynak hücrelerden bağımsız olarak [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setNumberFormat) kullanır. Ölçeği -2 ile 15 arasında olup, büyük aralıklar 2 ve küçük aralıklar 0,5 olarak ayarlanmıştır. Örnek ayrıca yüzde biçimlendirmesini binler biriminde gösterim için [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setDisplayUnit) ile birleştirir; bu ayarları verinizin anlamına ve büyüklüğüne göre uyarlayın. Açıklama, [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#setOverlay) `false` ile çağrıldığı için çizim alanının dışında kalır. Arka duvar ve zemin doldurmaları, [getBackWall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getBackWall) ve [getFloor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getFloor) aracılığıyla yapılandırılır, ancak bu yüzeyler yalnızca 3B grafiklerde görülür.

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

## **Grafik İçin Yazı Tipi Özelliklerini Ayarla**

Grafik metni için varsayılan yazı tipi boyutunu [Chart::getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getTextFormat) aracılığıyla ayarlayın. Örnek, 20 puanlık bir yazı tipiyle bir gruplanmış sütun grafik oluşturur ve [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) ile ilk seri için değer etiketlerini etkinleştirir. Kendi belirgin yazı tipi ayarlarına sahip metin öğeleri, grafik varsayılanını geçersiz kılabilir.

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

## **Grafik Açıklaması İçin Metin Çerçevesi Biçimlendirmesini Yeniden Kullan**

Bir açıklamayı slayt başlığıyla eşleştirmek için, ilk paragrafta başlığın yazı tipini [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) aracılığıyla ayarlayın. Açıklamanın [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#getTextFormat) tarafından döndürülen format üzerinde [copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyFrom) metodunu çağırın. Bu, metin çerçevesi ayarlarını, ilk paragrafın biçimlendirmesini ve o paragrafın varsayılan yazı tipi özelliklerini kopyalar. Bireysel bölümlere veya sonraki paragraflara doğrudan uygulanan biçimlendirme, kaynağa özgü kalır.

Örnek, koyu renkli, 26 puan Calibri başlığını lacivert olarak şablon kullanır. Açıklamayı biçimlendirdikten sonra, aynı biçimlendirmeyi ayrı bir alt başlığa uygulamak için [copyTo](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyTo) metodunu çağırır.

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

Kayıtlı sunumda, açıklama ve alt başlık boyut, kalınlık ve renk açısından başlıkla eşleşir. Açıklama hâlâ seri adlarını gösterir ve alt başlık kendi metnini korur. Alt başlıktaki bir bölümün zaten belirgin bir yazı tipi boyutu varsa, bu boyut kopyalanan paragraf varsayılanının üzerine yazılır.

| Kopyalamadan Önce | Kopyalamadan Sonra |
| --- | --- |
| ![Üç aylık satış grafiği, düzenli siyah açıklama etiketleri ve siyah alt başlıkla](legend-formatting-before.png) | ![Aynı grafik, daha büyük, koyu lacivert açıklama etiketleri ve eşleşen bir alt başlıkla](legend-formatting.png) |

## **Sayısal Biçimi Ayarla**

[ChartDataCell::setPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setPresetNumberFormat) kullanarak grafik çalışma kitabı hücrelerine yerleşik bir sayı biçimi uygulayın. Bu örnek, varsayılan hücre tabanlı verilerle bir gruplanmış sütun grafik oluşturur ve her seri değer hücresine biçim indeksi 10 (`0.00%`) uygular. Bu, temel sayıları değiştirmeden değerlerin çalışma kitabında nasıl göründüğünü değiştirir; örneğin 0,25 değeri %25,00 olarak gösterilir. Eksen ve veri etiketi biçimleri ayrı ayrı yapılandırılabilir.

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

Aşağıdaki tablo, İngilizce (ABD) yereli için temsili Excel biçimleriyle birlikte yerleşik sayı biçimi indekslerini listeler. Tam biçim dizgeleri ve gösterimleri uygulama ve yerel ayara göre değişebilir, özellikle para birimi ve tarih formatları için. Bazı Excel biçimleri, [Microsoft'un sayı biçimi uygulama notlarında](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) açıklandığı gibi OOXML standardındaki varsayılanlardan da farklılık gösterebilir.

| İndeks | Biçim |
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

## **Grafik Alanı Yuvarlak Kenarlıkları Ayarla**

[Chart::setRoundedCorners](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setRoundedCorners) metodunu `true` ile çağırarak grafik alanının köşelerini yuvarlatın. Örnek, bir gruplanmış sütun grafik oluşturur ve sunumu kaydetmeden önce kenarlığına katı gri bir renk ve tek çizgi stili vermek için [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) kullanır.

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

## **Mevcut Grafik Açıklamalarını Düzenle**

Bir grafik, rapor durumunu açıklayan bir metin açıklaması gibi özel şekiller içerebilir. Bu şekillere [Chart::getUserShapes](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getUserShapes) aracılığıyla erişin. [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) tarafından döndürülen koleksiyon, grafik tarafından sahip olunan şekilleri içerir.

Grafiğin üzerine yerleştirilen sıradan bir metin kutusu, grafik parçası gibi görünse de slayta aittir. [Slide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) üzerinden dolaşmak grafik ve sıradan slayt şekillerini bulur, ancak grafiğin içindeki ayrı şekilleri listelemez. Grafik başlıkları ve veri etiketleri ayrı grafik öğeleridir, bu koleksiyondaki özel açıklamalar değildir.

[chart-annotations.pptx](chart-annotations.pptx) dosyasını indirin ve uygulamanın çalışma dizinine yerleştirin. İlk slaytı, "Preliminary results" (Ön Çıktılar) metnini içeren gruplanmamış bir açıklama, grafik sahipliğinde bir çizgi ve "Slide overlay" (Slayt üzerine) metnini içeren sıradan bir slayt metin kutusu bulunan bir grafik içerir. Örnek, bu slayttaki ilk grafik bulur ve rapor yayımlamaya hazır olduğunda açıklamayı "Final results" (Sonuçlar) olarak değiştirir. Boş bir koleksiyon olup olmadığını kontrol eder ve yalnızca [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) içinde, [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) tarafından döndürülen null olmayan bir metin çerçevesi ve beklenen metin bulunanı düzenler.

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

Çizgi ve slayt metin kutusu aynı kalır. Aşağıdaki görseller giriş ve kaydedilip tekrar açılmış sonucu gösterir:

| Düzenlemeden Önce | Düzenlemeden Sonra |
| --- | --- |
| ![Grafik açıklaması, Preliminary results metnini gösteriyor](chart-annotations-before.png) | ![Grafik açıklaması, Final results metnini gösteriyor](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Örnek yalnızca üst düzey grafik sahipliğindeki şekilleri inceler. Bir açıklama bir [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) içinde ise, o grubun [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) koleksiyonunu da inceleyin. İç içe gruplar için bunu yineleyin ve aynı metin kontrollerini alt şekillere uygulayın. Bir grup kendisi bir kapsayıcıdır; onu bir metin kutusu olarak ele almayın.
{{% /alert %}}

## **FAQ**

**Sütunlar/alanlar için yarı saydam doldurmalar ayarlayabilirken kenarlığı opak tutabilir miyim?**

Evet. Doldurma şeffaflığı ve kenarlık ayrı ayrı yapılandırılır. Bu, yoğun görselleştirmelerde ızgara ve verilerin okunabilirliğini artırmak için faydalıdır.

**Veri etiketleri çakıştığında nasıl başa çıkabilirim?**

Yazı tipi boyutunu küçültün, gerekli olmayan etiket bileşenlerini devre dışı bırakın (örneğin, kategorileri), etiket konumunu ayarlayın, gerekirse yalnızca seçili noktalar için etiket gösterin veya biçimi "değer + açıklama" olarak değiştirin.

**Serilere degrade veya desen doldurmaları uygulayabilir miyim?**

Evet. Seriler katı, degrade ve desen doldurmalarını destekler. Pratikte, degradeleri ölçülü kullanın ve ızgara ve metinle kontrastı azaltan kombinasyonlardan kaçının.