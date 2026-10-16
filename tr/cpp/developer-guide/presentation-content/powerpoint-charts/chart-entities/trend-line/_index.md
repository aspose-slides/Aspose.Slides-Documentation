---
title: C++ Sunum Grafiklerine Trend Çizgileri Ekle
linktitle: Trend Çizgisi
type: docs
url: /tr/cpp/trend-line/
keywords:
- grafik
- trend çizgisi
- üstel trend çizgisi
- doğrusal trend çizgisi
- logaritmik trend çizgisi
- hareketli ortalama trend çizgisi
- polinom trend çizgisi
- güç trend çizgisi
- özel trend çizgisi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint grafiklerine trend çizgileri hızlıca ekleyin ve özelleştirin - izleyicilerinizi etkilemek için pratik bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine trend çizgileri eklemeyi açıklar. Bir grafik oluşturmayı, grafik serilerine trend çizgileri eklemeyi ve üstel, doğrusal, logaritmik, hareketli ortalama, polinom ve güç gibi çeşitli trend çizgisi türleriyle çalışmayı gösterir.

Ayrıca, bir çizgi şekli ekleyerek grafiğe özel bir çizgi eklemeyi ve PDF veya SVG'ye dışa aktarırken ve grafikler görüntülere dönüştürülürken trend çizgilerinin korunup korunmadığı gibi konularda kısa bir SSS içerir.

## **Trend Çizgisi Ekle**

[ ITrendlineCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendlinecollection/add/) kullanarak bir grafik serisine trend çizgisi ekleyin ve tipini [TrendlineType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/trendlinetype/) ile seçin. Örnek, varsayılan verilerle bir küme sütun grafiği oluşturur ve her üç serisine iki trend çizgisi ekler.

Üstel trend çizgisi, denklemini ve R-kare değerini [ITrendline::set_DisplayEquation](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayequation/) ve [ITrendline::set_DisplayRSquaredValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_displayrsquaredvalue/) ile gizler, doğrusal trend çizgisi kırmızıdır. Logaritmik trend çizgisi, özel bir etiket için [IOverridableText::AddTextFrameForOverriding](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ioverridabletext/addtextframeforoverriding/) kullanır. Hareketli ortalama, üç veri noktasını ortalamak için [ITrendline::set_Period](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_period/) ve özel bir ad için [ITrendline::set_TrendlineName](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_trendlinename/) kullanır.

Polinom trend çizgisi, derecesini üç olarak ayarlamak için [ITrendline::set_Order](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_order/) kullanır ve bir kategori ileriye uzatılırken [ITrendline::set_Forward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_forward/) kullanılır. Güç trend çizgisi bir kategori geriye uzatılırken [ITrendline::set_Backward](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_backward/) kullanır.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <DOM/Chart/IFormat.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

auto firstSeries = chart->get_ChartData()->get_Series()->idx_get(0);

auto exponentialTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Exponential);
exponentialTrendline->set_DisplayEquation(false);
exponentialTrendline->set_DisplayRSquaredValue(false);

auto linearTrendline = firstSeries->get_TrendLines()->Add(TrendlineType::Linear);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->set_FillType(FillType::Solid);
linearTrendline->get_Format()->get_Line()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto secondSeries = chart->get_ChartData()->get_Series()->idx_get(1);

auto logarithmicTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::Logarithmic);
logarithmicTrendline->AddTextFrameForOverriding(u"New log trend line");

auto movingAverageTrendline = secondSeries->get_TrendLines()->Add(TrendlineType::MovingAverage);
movingAverageTrendline->set_Period(3);
movingAverageTrendline->set_TrendlineName(u"New TrendLine Name");

auto thirdSeries = chart->get_ChartData()->get_Series()->idx_get(2);

auto polynomialTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Polynomial);
polynomialTrendline->set_Forward(1);
polynomialTrendline->set_Order(3);

auto powerTrendline = thirdSeries->get_TrendLines()->Add(TrendlineType::Power);
powerTrendline->set_Backward(1);

presentation->Save(u"ChartTrendLines.pptx", SaveFormat::Pptx);
```

## **Trend Çizgisi Kesiti Ayarla**

[ ITrendline::set_Intercept](https://reference.aspose.com/slides/cpp/aspose.slides.charts/itrendline/set_intercept/) kullanarak bir trend çizgisinin Y değerini X = 0’da sabitleyin. Bu ayar doğrusal, üstel ve polinom trend çizgileri için desteklenir.

Örneğin, bir üretim maliyeti modeli, ölçümler sıfır olmayan üretim hacimlerinde farklı bir temel gösterse bile, bilinen sabit maliyet 100 ile başlamalıdır. Doğrusal bir trend çizgisinde, kesiti sabitlemek `y = ax + b` denklemini `b = 100` olarak kısıtlar; eğim bu kısıtlama altında verilere uyarlanır. Bu, zaten uyarlanmış bir çizgiyi basitçe taşımaz. Ekseni kesişim ayarları, grafik eksenlerinin nerede buluştuğunu kontrol eder, uyarlanmış trend çizgisinin katsayılarını değil.

Aşağıdaki örnek, 1’den 4’e kadar üretim hacimleri ve 170, 200, 230 ve 260 maliyetleriyle bir dağılım (XY) grafiği oluşturur. Grafik, varsayılan otomatik kesitle kaydedilir, kesit 100’e ayarlanır ve ikinci bir PPTX olarak kaydedilir. İki dosya yalnızca kesit ayarında farklıdır. Trend çizgisi denklemini gösterir ve X = 0’a kadar geri uzanır.

```cpp
#include <system/shared_ptr.h>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/ITrendline.h>
#include <DOM/Chart/ITrendlineCollection.h>
#include <DOM/Chart/TrendlineType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto nameCell = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Production cost"));
auto series = chart->get_ChartData()->get_Series()->Add(nameCell, ChartType::ScatterWithMarkers);
const double costs[] = { 170, 200, 230, 260 };

for (auto i = 0; i < 4; i++)
{
    auto xCell = workbook->GetCell(0, i + 1, 0, ObjectExt::Box<int32_t>(i + 1));
    auto yCell = workbook->GetCell(0, i + 1, 1, ObjectExt::Box<double>(costs[i]));
    series->get_DataPoints()->AddDataPointForScatterSeries(xCell, yCell);
}

auto trendline = series->get_TrendLines()->Add(TrendlineType::Linear);
trendline->set_DisplayEquation(true);
trendline->set_Backward(1);

presentation->Save(u"AutomaticIntercept.pptx", SaveFormat::Pptx);

trendline->set_Intercept(100);
presentation->Save(u"FixedIntercept.pptx", SaveFormat::Pptx);
```

Otomatik hesaplama ile bu veriler `y = 30x + 140` üretir. Kesiti 100 olarak ayarlamak ise yaklaşık olarak `y = 43.33x + 100` üretir: sıfırdaki uyarlanmış değer bilinen temele eşit olur, ancak çizgi artık her veri noktasından geçmez.

| Otomatik kesit | 100 Birimi Sabit Kesit |
| --- | --- |
| ![Linear trend line with an automatically calculated intercept of 140](intercept-automatic.png) | ![Linear trend line with a fixed intercept of 100](intercept-fixed.png) |

Her iki görsel aynı veri ve eksen ölçeklerini kullanır. Trend çizgileri, kesitlerini göstermek için X = 0’a kadar geri uzatılmıştır.

Varsayılan olarak, özellik `std::numeric_limits<double>::quiet_NaN()` içerir; bu, sıfır yerine belirtilmemiş bir kesiti temsil eder. Kesit daha sonra verilerden otomatik olarak hesaplanır.

## **Özel Çizgi Ekle**

Özel bir çizgi, serilerden hesaplanan bir trend çizgisi yerine grafiğin üzerinde çizilen bir şekildir. Bu örnek, grafiğin üzerindeki slayda yatay bir çizgi eklemek için [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) kullanır. Çizginin konumu, slayt koordinatlarında puan cinsinden belirtilir, bu nedenle grafiğin sol kenarından başlar ve grafiğin ortasına kadar uzanır. Genişliği grafiğin genişliğiyle eşleşir. [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) tarafından döndürülen çizgi biçimi, çizgiye katı kırmızı bir renk verir.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ILineFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

auto line = slide->get_Shapes()->AddAutoShape(ShapeType::Line, chart->get_X(), chart->get_Y() + chart->get_Height() / 2, chart->get_Width(), 0);
line->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
line->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"AddCustomLines.pptx", SaveFormat::Pptx);
```

## **SSS**

**Bir trend çizgisi için 'ileri' ve 'geri' ne anlama gelir?**

Bunlar, trend çizgisinin ileri/geri yönünde projekte edildiği uzunluklardır: dağılım (XY) grafiklerinde – eksen birimlerinde; dağılım dışı grafiklerde – kategori sayısı olarak. Sadece negatif olmayan değerler kabul edilir.

**Trend çizgisi, sunumu PDF veya SVG olarak dışa aktarırken veya bir slaytı görüntü olarak render ederken korunur mu?**

Evet. Aspose.Slides sunumları [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/) veya [SVG](/slides/tr/cpp/render-a-slide-as-an-svg-image/) formatına dönüştürür ve grafikleri görüntülere render eder; trend çizgileri, grafiğin bir parçası olarak bu işlemler sırasında korunur. Ayrıca grafiğin kendisinin bir görüntüsünü [dışa aktarmak](/slides/tr/cpp/shape-thumbnails/) için bir yöntem de mevcuttur.