---
title: C++ Kullanarak Sunumlarda Grafik Çalışma Kitaplarını Yönet
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/cpp/chart-workbook/
keywords:
- grafik çalışma kitabı
- grafik verisi
- çalışma kitabı hücresi
- veri etiketi
- çalışma sayfası
- veri kaynağı
- harici çalışma kitabı
- harici veri
- grafik önbelleği
- çalışma kitabı kurtarma
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yönetin ve sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı tipini belirtme konularını gösterir.

Ayrıca dış çalışma kitaplarını grafik veri kaynağı olarak kullanmayı da kapsar. Örnekler, dış bir çalışma kitabı oluşturup atamayı, bir grafikle ilişkilendirilmiş dış çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verisini düzenlemeyi gösterir.

Eksik veri temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve kullanılabilir görüntüleme modlarının çizgi grafik karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/cpp/chart-series/) adresine bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Et**

[IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) kullanılarak bir grafiğin gizli çalışma sayfası satır ve sütunlarından veri çizip çizmeyeceği kontrol edilir. Görünür hücreleri çizmek için `true`, hem görünür hem de gizli hücreleri dahil etmek için `false` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satır ve sütunlarını gizlemez veya göstermez.

[örnek sunum](hidden-source-data.pptx) ilk slaydındaki ilk şekil olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` aralığını içerir. Satır 3 ve sütun C gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (gizli satır) | February | 40 | 60 |
| 4 | March | 20 | 50 |

[IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) aracılığıyla kaynak hücrelere erişin ve gizli durumlarını incelemek için [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) okuyun. Bu özellik yalnızca okunur. Bu dosyada B2 görünür, B3 gizli satıra, C2 gizli sütuna aittir; örnek sırasıyla `False`, `True` ve `True` değerlerini yazdırır.

Bu örnek için, çizim ayarı değiştirildikten sonra grafik verisini yenileyin: gömülü çalışma kitabını [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) ile tutun ve [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de içeren tam aralığı geri yüklemek için [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) kullanın. Yalnızca bayrağı değiştirmek, bu örneğin önbelleğe alınmış grafik verisini ve kategori etiketlerini yenilemek için yeterli değildir.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"hidden-source-data.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    Console::WriteLine(u"B2 hidden: {0}", workbook->GetCell(0, u"B2")->get_IsHidden());
    Console::WriteLine(u"B3 hidden: {0}", workbook->GetCell(0, u"B3")->get_IsHidden());
    Console::WriteLine(u"C2 hidden: {0}", workbook->GetCell(0, u"C2")->get_IsHidden());

    auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
    for (auto visibleOnly : {true, false})
    {
        chart->set_PlotVisibleCellsOnly(visibleOnly);

        // Gömülü çalışma kitabından grafik verisini yenile.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Gizli kategorileri de içerecek şekilde tam kaynak aralığını geri yükle.
            chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$C$4");
        }

        auto outputPath = visibleOnly ? u"hidden_cells_True.pptx" : u"hidden_cells_False.pptx";
        presentation->Save(outputPath, Export::SaveFormat::Pptx);
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Örnek, sunumun iki sürümünü kaydeder: yalnızca görünür Perakende değerleri (10 ve 20) olan bir sürüm ve tüm altı değeri içeren bir sürüm. Aşağıdaki görseller iki çizim modunu gösterir. Satır 3 ve sütun C, her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünür hücreler: January ve March için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: January, February ve March için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) eksik değerlerin nasıl görüntüleneceğini kontrol eder; gizli kaynak veriyi içermez veya hariç tutmaz. Bir örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/cpp/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Grafiğin Veri Aralığını Al**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, her bir grafiğin kullandığı çalışma sayfası hücrelerini belirlemek için kaynak aralıklarını inceleyin. [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) yöntemi, `Sheet1!$A$1:$D$5` gibi bir çalışma sayfası nitelikli formül olarak geçerli veri aralığını döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1’den D5’e kadar olan hücreleri (dahil) belirtir. Dolar işaretleri mutlak satır ve sütun referanslarını gösterir.

Bu yöntem, grafiği veya çalışma kitabını değiştirmeden geçerli aralığı okur. Grafik veri kaynağı olarak bir çalışma kitabı kullanmıyorsa, [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) fırlatır. Daha fazla bilgi için [ChartData API Reference](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/) bölümüne bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan grafikler için kontrol eder. Her grafiğin adını ve kaynak aralığını yazdırır. Bir grafik çalışma kitabı kullanmıyorsa bir mesaj yazdırır ve bir sonraki grafiğe geçer.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

for (auto slide : IterateOver(presentation->get_Slides()))
{
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        auto chart = AsCast<IChart>(shape);
        if (chart != nullptr)
        {
            try
            {
                auto range = chart->get_ChartData()->GetRange();
                Console::WriteLine(u"{0}: {1}", chart->get_Name(), range);
            }
            catch (const InvalidOperationException&)
            {
                Console::WriteLine(u"{0}: The chart does not use a workbook as its data source.", chart->get_Name());
            }
        }
    }
}
```

## **Bir Çalışma Kitabından Grafik Verisini Oku ve Yaz**

Aspose.Slides for C++ , grafik verisi çalışma kitaplarını (Aspose.Cells ile düzenlenmiş) okumanıza ve yazmanıza olanak tanıyan [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) ve [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) yöntemlerini sunar. **Not** grafik verisinin aynı şekilde düzenlenmiş olması veya kaynağa benzer bir yapıya sahip olması gerekir.

Bu örnek, ilk slaydındaki ilk şekil olarak bir grafik içeren bir sunum kullanır. Gömülü çalışma kitabını bir akısa okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **Çalışma Kitabı Değiştirildikten Sonra Grafik Düzenini Doğrula**

Gömülü bir çalışma kitabını değiştirilmiş bir tane ile değiştirirken, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) yönteminin dizin dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafik içine yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaydın ilk şekli olarak bir grafik kullanır. Yorum, çalışma kitabı düzenlemesinin nerede yapılacağını gösterir; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve düzeni bellek içinde doğrular.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    // Çalışma kitabı akışını burada değiştirin, örneğin Aspose.Cells kullanarak.

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
    chart->ValidateChartLayout();
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Koleksiyonların temizlenmesi, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli seri ve kategori eşleştirmelerini yeniden oluşturun ve ardından grafiği kullanın.

## **Çalışma Kitabı Hücreleri İçin Özel Sayı Biçimleri Ayarla**

[IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) kullanılarak sayısal değerlerin bir grafiğin gömülü çalışma kitabında nasıl görüneceği kontrol edilir. Örneğin, bir raporda dönüşüm oranı yüzde olarak dört ondalık basamak ve katsayı beş ondalık basamakla gösterilebilir. Her iki değerin de sayısal kalması, hesaplamalar ve grafik çizimi için kullanılabilir olmasını sağlar.

Bir sayı biçimi sadece görüntüyü değiştirir, depolanan değeri değiştirmez. `0.0000%` biçimi `0.125` değerini `12.5000%` olarak gösterir; `12.5` sayısını depolanan sayı olarak değiştirmez. Benzer şekilde, `0.00000` `0.1234567` değerini `0.12346` olarak gösterir ve depolanan değeri yuvarlamaz. Özel biçim boş bir dize (`""`) ise, [set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) ile atanmış önceden tanımlı biçim kullanılır.

Aşağıdaki örnek bir sütun grafik oluşturur ve hücrelerine [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) aracılığıyla erişir. Çalışma sayfası 0’da B2 dönüşüm oranını, C2 ise katsayıyı içerir. Her iki hücre de grafik değerlerini sağlar. Örnek ayrıca kaynak biçimlerine bağlı değer etiketlerini etkinleştirir.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 270, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
chart->set_HasTitle(false);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00");
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(0);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto categoryCell = workbook->GetCell(0, u"A2", ObjectExt::Box<String>(u"Sample"));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto percentageCell = workbook->GetCell(0, u"B2", ObjectExt::Box<double>(0.125));
percentageCell->set_CustomNumberFormat(u"0.0000%");
auto percentageName = workbook->GetCell(0, u"B1", ObjectExt::Box<String>(u"Conversion rate"));
auto percentageSeries = chart->get_ChartData()->get_Series()->Add(percentageName, chart->get_Type());
percentageSeries->get_DataPoints()->AddDataPointForBarSeries(percentageCell);

auto precisionCell = workbook->GetCell(0, u"C2", ObjectExt::Box<double>(0.1234567));
precisionCell->set_CustomNumberFormat(u"0.00000");
auto precisionName = workbook->GetCell(0, u"C1", ObjectExt::Box<String>(u"Coefficient"));
auto precisionSeries = chart->get_ChartData()->get_Series()->Add(precisionName, chart->get_Type());
precisionSeries->get_DataPoints()->AddDataPointForBarSeries(precisionCell);

for (auto series : IterateOver(chart->get_ChartData()->get_Series()))
{
    auto labelFormat = series->get_DataPoint(0)->get_Label()->get_DataLabelFormat();
    labelFormat->set_ShowValue(true);
    labelFormat->set_IsNumberFormatLinkedToSource(true);
}

presentation->Save(u"CustomCellFormats.pptx", Export::SaveFormat::Pptx);
```

Çalışma kitabı hücre biçimleri, doğrudan eksenlerde veya veri etiketlerinde ayarlanan biçimlerden ayrıdır. Bu örnekte, her etiket kaynak hücresinin değerini gösterir çünkü [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) `true` olarak çağrılmış ve [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) `true` olarak ayarlanmıştır. Sunumu kaydedip yeniden açtıktan sonra etiketler `12.5000%` ve `0.12346` olarak gösterilir. Dikey eksen, [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/) ile atanmış `0.00` biçimini kendi içinde kullanır; [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) `false` olarak ayarlanmıştır.

Bir veri etiketini bağımsız biçimlendirmek için, kaynak‑bağlantı bayrağını `false` yapın ve biçimini [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) ile atayın. Bu, çalışma kitabı hücresinin biçimini değiştirmez. Örneğin, bağımsız bir etiket biçimi `0.00` ilk değeri `0.13` olarak gösterirken B2 hâlâ `12.5000%` gösterir. Doğrudan etiket biçimlendirme için [Chart Data Labels](/slides/tr/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels) bölümüne bakın.

Aşağıdaki görsel, sunumu kaydedip yeniden açtıktan sonra oluşturulmuştur:

![Kaynak‑bağlantılı etiketlerin 12.5000% ve 0.12346 gösterdiği, bağımsız biçimli sayısal ekseni olan sütun grafik.](custom-cell-formats.png)

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarla**

Grafik veri etiketleri olarak çalışma kitabı hücrelerinden metin kullanılabilir.

Bu örnek, mevcut bir sunumun ilk slaydına varsayılan verilerle bir balon grafik ekler. İlk seri için etiketlerin bulunduğu hücreler `A10:A12` (çalışma sayfası 0) kullanılır, hücrelerden etiketler etkinleştirilir ve güncellenmiş sunum kaydedilir.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart2.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Bubble, 50, 50, 600, 400, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);
auto firstLabelCell = workbook->GetCell(0, u"A10", ObjectExt::Box<String>(u"Label 0 cell value"));
auto secondLabelCell = workbook->GetCell(0, u"A11", ObjectExt::Box<String>(u"Label 1 cell value"));
auto thirdLabelCell = workbook->GetCell(0, u"A12", ObjectExt::Box<String>(u"Label 2 cell value"));
series->get_Labels()->idx_get(0)->set_ValueFromCell(firstLabelCell);
series->get_Labels()->idx_get(1)->set_ValueFromCell(secondLabelCell);
series->get_Labels()->idx_get(2)->set_ValueFromCell(thirdLabelCell);

presentation->Save(u"resultchart.pptx", Export::SaveFormat::Pptx);
```

## **Çalışma Sayfalarını Yönet**

[IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) yöntemi, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve her çalışma sayfasının adını konsola yazdırır.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 500);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

for (auto i = 0; i < workbook->get_Worksheets()->get_Count(); i++)
{
    Console::WriteLine(workbook->get_Worksheets()->idx_get(i)->get_Name());
}
```

## **Veri Kaynağı Tipini Belirle**

Seri nokta değerleri doğrudan sayısal sabitler olarak da saklanabilir. Kaydedip okuyabileceğiniz tam bir örnek için [Set Series Values Using Numeric Literals](/slides/tr/cpp/chart-series/#set-series-values-using-numeric-literals) bölümüne bakın. Nokta değerlerinin veri kaynağı tipi, grafiğin iç veya dış çalışma kitabı yapılandırmasından ayrıdır; sayısal sabitler kullanmak, gömülü çalışma kitabını otomatik olarak kaldırmaz.

Bu örnek, varsayılan verilerle bir 3D sütun grafik oluşturur ve iki seri adını farklı veri kaynaklarıyla ayarlar. İlk ad bir dize sabiti, ikincisi çalışma sayfası 0’da `C1` hücresi kullanır. [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) enumı, her bir ad için kaynağı seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 600, 400, true);
auto literalName = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

literalName->set_DataSourceType(DataSourceType::StringLiterals);
literalName->set_Data(ObjectExt::Box<String>(u"LiteralString"));

auto cellName = chart->get_ChartData()->get_Series()->idx_get(1)->get_Name();
auto nameCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, u"C1", ObjectExt::Box<String>(u"NewCell"));
cellName->set_DataSourceType(DataSourceType::Worksheet);
cellName->set_Data(nameCell);

presentation->Save(u"pres.pptx", Export::SaveFormat::Pptx);
```

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen biçimleri algılamak ve bu grafikleri atlamak için [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) üzerindeki [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) yöntemini, [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) enumı ile birlikte kullanabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü çalışma kitabı olan her grafik için bir tanı mesajı yazdırır.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto shape : IterateOver(slide->get_Shapes()))
{
    auto chart = AsCast<IChart>(shape);
    if (chart == nullptr)
    {
        continue;
    }

    auto chartData = chart->get_ChartData();
    auto isInternalWorkbook = chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook;
    auto isBinaryMacro = chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console::WriteLine(u"Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Desteklenen grafik çalışma kitabı verilerini burada okuyun veya değiştirin.
}
```

## **Dış Çalışma Kitabı**

Aspose.Slides, grafikler için dış çalışma kitaplarını veri kaynağı olarak kullanmayı destekler.

### **Bir Dış Çalışma Kitabı Oluştur**

[ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) ve [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) kullanılarak gömülü grafik çalışma kitabı bir dosyaya dışa aktarılır ve grafik bu dış çalışma kitabına bağlanır.

Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve çalışma kitabını dışa aktarır. Dış çalışma kitabını grafik veri kaynağı olarak atamadan önce çıkış akışını kapatır, ardından bağlı sunumu kaydeder.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600);
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook1.xlsx");
auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
auto fileStream = IO::File::Create(workbookPath);
workbookStream->CopyTo(fileStream);
fileStream->Close();

chart->get_ChartData()->SetExternalWorkbook(workbookPath);

presentation->Save(u"externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

### **Bir Dış Çalışma Kitabı Ata**

[SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) yöntemiyle bir grafik için dış çalışma kitabı veri kaynağı olarak atanabilir. Bu yöntem aynı zamanda dış çalışma kitabının yolunu (dosya taşınmışsa) güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri doğrudan düzenleyemezsiniz, ancak bu çalışma kitaplarını dış veri kaynağı olarak kullanabilirsiniz. Bir dış çalışma kitabı için göreceli yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1’de bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler bulunan bir dış çalışma kitabı kullanır. Bir pasta grafik oluşturur, çalışma kitabını bağlar ve [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) ile A1:B4 aralığını bir seri ve üç kategoriye eşleştirir. Bağlı grafikle sunumu kaydeder.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);
auto chartData = chart->get_ChartData();
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook.xlsx");

chartData->SetExternalWorkbook(workbookPath);
chartData->SetRange(u"Sheet1!$A$1:$B$4");

presentation->Save(u"Presentation_with_externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

[SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) yönteminin `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` `false` olduğunda yalnızca çalışma kitabı yolu güncellenir. Grafik verisi, hedef çalışma kitabından yüklenmez veya güncellenmez; bu nedenle çalışma kitabı mevcut olmayabilir.
* `updateChartData` `true` olduğunda grafik verisi hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` `false` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verileri korunur ve mevcut olmayan çalışma kitabı yüklenmeden sunum kaydedilir.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);

chart->get_ChartData()->SetExternalWorkbook(u"https://example.com/unavailable-workbook.xlsx", false);
presentation->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", Export::SaveFormat::Pptx);
```

### **Bir Grafiğin Dış Veri Kaynağı Çalışma Kitabı Yolunu Al**

Bir grafikle ilişkilendirilmiş çalışma kitabını belirlemek için, grafiğin dış veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, bir dış çalışma kitabına bağlanmış bir grafik içerip içermediğini kontrol etmek için bir sunumun ilk slaydındaki ilk şekli inceler. Eğer bir dış çalışma kitabına bağlanmış bir grafikse, [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) konsola yazdırılır. Ardından sunumun bir kopyası kaydedilir.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"externalWorkbook.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    if (chartData->get_DataSourceType() == ChartDataSourceType::ExternalWorkbook)
    {
        Console::WriteLine(chartData->get_ExternalWorkbookPath());
    }
    else
    {
        Console::WriteLine(u"The chart does not use an external workbook.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}

presentation->Save(u"Result.pptx", Export::SaveFormat::Pptx);
```

### **Grafik Verisini Düzenle**

Dış çalışma kitaplarındaki verileri, iç çalışma kitapları üzerindeki değişiklikler gibi düzenleyebilirsiniz. Dış çalışma kitabı yüklenemezse bir istisna fırlatılır.

Bu örnek, ilk slaydın ilk şekli olarak bir grafik kullanır ve erişilebilir bir dış çalışma kitabına bağlanır. İlk serideki ilk veri noktasının hücre tabanlı değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlı dış XLSX dosyasını güncelleyebilir; orijinal çalışma kitabını korumak istiyorsanız bir kopya kullanın.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto series = chart->get_ChartData()->get_Series();
    if (series->get_Count() > 0 && series->idx_get(0)->get_DataPoints()->get_Count() > 0)
    {
        auto valueCell = series->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell();
        if (valueCell != nullptr)
        {
            valueCell->set_Value(ObjectExt::Box<int32_t>(100));
            presentation->Save(u"presentation_out.pptx", Export::SaveFormat::Pptx);
        }
        else
        {
            Console::WriteLine(u"The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console::WriteLine(u"The chart has no data points to edit.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **Grafik Önbelleğinden Çalışma Kitabını Geri Yükle**

Bir grafik, eksik veya kullanılamayan bir dış çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınmış veriden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) oluşturup, [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) ile yapılandırın ve sunumu açmadan önce [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) `true` olarak ayarlayın.

Aşağıdaki C++ örneği, ilk slaydın ilk şekli olarak bir grafik için dış çalışma kitabı bulunmadığında çalışma kitabı verisini geri yükler. Geri yüklenen verilere [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) ve [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) aracılığıyla erişir:

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // Kurtarılan çalışma kitabı verilerini burada okuyun veya değiştirin.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Dış çalışma kitabı kullanılamaz ve geri yükleme devre dışı bırakılmışsa, Aspose.Slides bir [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) fırlatır. Önbellek verisinin kabul edilebilir bir geri dönüş olduğundan emin olduğunuzda yalnızca geri yüklemeyi etkinleştirin; önbellek, dış çalışma kitabında sunum son güncellendiğinden sonraki değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin dış veya gömülü bir çalışma kitabına bağlanıp bağlanmadığını nasıl belirleyebilirim?**

Evet. Bir grafiğin [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) ve [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) vardır; kaynak dış bir çalışma kitabı ise tam yolu okuyarak bir dış dosyanın kullanıldığını doğrulayabilirsiniz.

**Dış çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreceli bir yol belirtirseniz otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında depolar; bu nedenle çalışma kitabını taşıdığınızda bağlantıyı güncellemeniz gerekebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak Aspose.Slides ile uzaktaki çalışma kitaplarını doğrudan düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken dış XLSX dosyasını üzerine yazıyor mu?**

Sunum, dış dosyaya bir [link to the external file](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) saklar. Hücre tabanlı grafik verisini düzenlemek aynı zamanda bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinalin değişmemesi gerekiyorsa çalışma kitabının bir kopyasını kullanın.

**Dış dosya parola korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlanırken bir parola kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak veya bir şifre çözülmüş kopya (örneğin [Aspose.Cells](https://reference.aspose.com/cells/cpp/) kullanarak) hazırlamaktır ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı dış çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklemede her grafik için yansıtılır.