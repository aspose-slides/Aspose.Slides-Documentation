---
title: C++ ile Sunumlarda Pasta Grafikleri Özelleştirme
linktitle: Pasta Grafiği
type: docs
url: /tr/cpp/pie-chart/
keywords:
- pasta grafik
- grafik yönetimi
- grafik özelleştirme
- grafik seçenekleri
- grafik ayarları
- çizim seçenekleri
- dilim rengi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides ile C++ içinde pasta grafikler oluşturun ve özelleştirin. İkincil çizimleri yapılandırın, veri etiketlerini görüntüleyin ve PowerPoint'te otomatik dilim renkleri uygulayın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde pasta grafiklerle nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafikleri için ikincil çizim seçeneklerini nasıl yapılandıracağınızı ve standart bir pasta grafik için otomatik dilim renklendirmesini nasıl etkinleştireceğinizi gösterir.

Örnekler, bir slayta grafik ekleme, serileri ve etiket ayarlarını düzenleme, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenmiş sunumu kaydetme gibi grafik özelleştirme görevlerine odaklanır.

## **Pie of Pie ve Bar of Pie Grafikler için İkincil Çizim Seçenekleri**

Aspose.Slides for C++ Pie of Pie ve Bar of Pie grafikleri için ikincil çizim seçeneklerini destekler. Bu seçenekler, ikincil çizimin boyutunu ve veri noktalarının iki çizim arasında nasıl bölündüğünü kontrol eder.

Aşağıdaki örnek, yeni bir sunumda bir Pie of Pie grafiği oluşturur ve veri noktası değerlerini etiket olarak gösterir. [set_SecondPieSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_secondpiesize/) yöntemi ikincil çizim boyutunu ana çizimin %149’una ayarlar. [set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitby/) yüzde bazlı bölmeyi seçer ve [set_PieSplitPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_piesplitposition/) eşik değerini %53’a ayarlar.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 500, 400);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

// Display values and configure the secondary plot.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_SecondPieSize(149);
seriesGroup->set_PieSplitBy(PieSplitType::ByPercentage);
seriesGroup->set_PieSplitPosition(53);

presentation->Save(u"pie_of_pie.pptx", SaveFormat::Pptx);
```

### **İkincil Çizim için Kategorileri Seçme**

Yüzde değerlerinden bağımsız olarak belirli kategorileri ikincil çizimde gruplamak istediğinizde özel bölmeyi kullanın. Örneğin, bir satış raporu Online ve Events’i birlikte gösterebilir, böylece okuyucular bu iki kanalı karşılaştırabilir, toplam satışın %35 ve %10’una sahip olmalarına rağmen.

[set_PieSplitBy](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/set_piesplitby/) metodunu [PieSplitType::Custom](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplittype/) ile çağırın ve noktaları [get_PieSplitCustomPoints](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartseriesgroup/get_piesplitcustompoints/) aracılığıyla seçin. Koleksiyonun [Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/add/) yöntemi seride sıfır tabanlı bir indeks kabul eder. Bu örnekte, indeks 1 Online’ı, indeks 3 Events’i seçer. Partners da geçici olarak eklenir ve ardından [Remove](https://reference.aspose.com/slides/cpp/aspose.slides.charts/piesplitcustompointcollection/remove/) ile dışlanır.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/PieSplitType.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IPieSplitCustomPointCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::PieOfPie, 50, 50, 600, 200);

// Varsayılan verileri kanal bazında satış verileriyle değiştirin.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"Retail", u"Online", u"Partners", u"Events" };
auto values = std::vector<int>{ 40, 35, 15, 10 };
auto seriesNameCell = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
auto seriesGroup = series->get_ParentSeriesGroup();
seriesGroup->set_PieSplitBy(PieSplitType::Custom);
seriesGroup->set_IsColorVaried(true);

// Serideki sıfır tabanlı indekslerine göre Online ve Events'i seçin.
seriesGroup->get_PieSplitCustomPoints()->Add(1);
seriesGroup->get_PieSplitCustomPoints()->Add(3);

// Partners'ı seçimden dışlayın, ancak kaynak verisini silmeyin.
seriesGroup->get_PieSplitCustomPoints()->Add(2);
seriesGroup->get_PieSplitCustomPoints()->Remove(2);

presentation->Save(u"pie_of_pie_custom.pptx", SaveFormat::Pptx);
```

Online (35) ve Events (10) ikincil çizimde ayrı dilimler olarak görünür. Birincil çizimde, bunlar 45 değerinde tek bir birleşik dilim olarak temsil edilir, Retail (40) ve Partners (15) ile birlikte. Partners’ı özel seçimden kaldırmak, onu birincil çizimde tutar; kategori ya da değeri grafik kaynağı verilerinden silmez.

Aşağıdaki görsel, kaydedilmiş sunumu PowerPoint'te gösterir:
![İkincil çizimde Online ve Events bulunan Pie of Pie grafik ve birincil çizimde birleşik 45 değerine sahip](pie_of_pie_custom.png)

## **Otomatik Pasta Grafiği Dilim Renklerini Ayarla**

Aspose.Slides for C++ pasta grafik dilimlerine otomatik olarak farklı renkler atayabilir. Aşağıdaki örnek, ortalanmış bir başlıklı pasta grafik oluşturur ve varsayılan verileri üç çeyrek kategorisi ve değerleriyle değiştirir. [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) yöntemi 20, 50 ve 30 değerlerini etiket olarak gösterir, [set_IsColorVaried](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_iscolorvaried/) ise her dilim için farklı bir renk etkinleştirir.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <Export/SaveFormat.h>
#include <vector>
#include <system/object_ext.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartTitle.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/NullableBool.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 100, 100, 400, 400);

// Ortalanmış bir grafik başlığı ekleyin.
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Sample Title");
chart->get_ChartTitle()->get_TextFrameForOverriding()->get_TextFrameFormat()->set_CenterText(NullableBool::True);
chart->get_ChartTitle()->set_Height(20);
chart->set_HasTitle(true);

// Varsayılan verileri ilk çalışma sayfasını kullanarak değiştirin.
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;
chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();
auto categoryNames = std::vector<System::String>{ u"First Qtr", u"2nd Qtr", u"3rd Qtr" };
auto values = std::vector<int>{ 20, 50, 30 };
auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 1, System::ObjectExt::Box(System::String(u"Series 1")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chart->get_Type());

for (auto i = 0; i < static_cast<int>(categoryNames.size()); i++)
{
    auto categoryCell = workbook->GetCell(worksheetIndex, i + 1, 0, System::ObjectExt::Box(categoryNames[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(worksheetIndex, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForPieSeries(valueCell);
}

// Değerleri gösterin ve dilimlere farklı renkler atayın.
series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);

presentation->Save(u"pie.pptx", SaveFormat::Pptx);
```

## **SSS**

**Pie of Pie ve Bar of Pie varyasyonları destekleniyor mu?**

Evet, kütüphane [destekler](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) bir ikincil çizimi, Pie of Pie ve Bar of Pie tipleri dahil, pasta grafikler için.

**Grafiği sadece bir resim (örneğin PNG) olarak dışa aktarabilir miyim?**

Evet, [grafiği doğrudan bir resim olarak dışa aktar](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) (örneğin PNG) tüm sunumu dışa aktarmadan yapabilirsiniz.