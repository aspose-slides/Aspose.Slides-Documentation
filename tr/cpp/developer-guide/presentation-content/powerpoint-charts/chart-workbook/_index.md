---
title: C++ ile Sunumlarda Grafik Çalışma Kitaplarını Yönetme
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
description: "C++ için Aspose.Slides'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını sorunsuz bir şekilde yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verisini nasıl okuyup yazabileceğinizi, çalışma kitabı hücrelerini grafik veri etiketi olarak nasıl kullanabileceğinizi, çalışma sayfası koleksiyonlarına nasıl erişebileceğinizi ve grafik değerleri için veri kaynağı türünü nasıl belirtebileceğinizi gösterir.

Ayrıca, harici çalışma kitaplarının grafik veri kaynakları olarak kullanılmasını da kapsar. Örnekler, bir harici çalışma kitabının nasıl oluşturulup atanacağını, bir grafikle ilişkilendirilmiş harici çalışma kitabının yolunun nasıl alınacağını ve çalışma kitabı mevcut olduğunda grafik verisinin nasıl düzenleneceğini gösterir.

## **Bir Çalışma Kitabından Grafik Verisini Okuma ve Yazma**

Aspose.Slides, grafik veri çalışma kitaplarını (Aspose.Cells ile düzenlenmiş grafik verisi içeren) okumanıza ve yazmanıza olanak tanıyan [ReadWorkbookStream](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) ve [WriteWorkbookStream](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) yöntemlerini sağlar. **Not** grafik verisinin aynı şekilde düzenlenmiş olması ya da kaynakla benzer bir yapıya sahip olması gerekir.

``` cpp
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slide(0)->get_Shape(0));
auto data = chart->get_ChartData();

auto = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

### **Çalışma Kitabı Değiştirildikten Sonra Grafik Düzenini Doğrulama**

Yerleşik bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [IChart::ValidateChartLayout](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/validatechartlayout/) metodunun dizin dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin.

```cpp
// Çalışma kitabı akışı değiştirildikten sonra (ör., Aspose.Cells kullanarak)
auto updatedWorkbook = chartData->ReadWorkbookStream();

// Mevcut veri referanslarını temizle.
chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

updatedWorkbook->set_Position(0);
chartData->WriteWorkbookStream(updatedWorkbook);

chart->ValidateChartLayout();
```

Koleksiyonların temizlenmesi, grafik veri yapısının yeni çalışma kitabıyla tutarlı olmasını sağlar ve `ValidateChartLayout`ın hatasız tamamlanmasına olanak tanır.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını indeks üzerinden alın.
3. Bazı verilerle bir Balon (Bubble) grafiği ekleyin.
4. Grafik serisine erişin.
5. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.
6. Sunumu kaydedin.

Bu C++ kodu, bir çalışma kitabı hücresini grafik veri etiketi olarak nasıl ayarlayacağınızı gösterir:

``` cpp
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
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Bir sunum dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
auto pres = System::MakeObject<Presentation>(u"chart2.pptx");

auto slide = pres->get_Slides()->idx_get(0);

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Bubble, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto series = chart->get_ChartData()->get_Series();

series->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

series->idx_get(0)->get_Labels()->idx_get(0)->set_ValueFromCell(wb->GetCell(0, u"A10", System::ObjectExt::Box<System::String>(lbl0)));
series->idx_get(0)->get_Labels()->idx_get(1)->set_ValueFromCell(wb->GetCell(0, u"A11", System::ObjectExt::Box<System::String>(lbl1)));
series->idx_get(0)->get_Labels()->idx_get(2)->set_ValueFromCell(wb->GetCell(0, u"A12", System::ObjectExt::Box<System::String>(lbl2)));

pres->Save(u"resultchart.pptx", SaveFormat::Pptx);
```

## **Çalışma Sayfalarını Yönetme**

Bu C++ kodu, [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) metodunun bir çalışma sayfası koleksiyonuna erişmek için kullanıldığı bir işlemi gösterir:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Veri Kaynağı Türünü Belirleme**

Bu C++ kodu, bir veri kaynağı için türün nasıl belirtileceğini gösterir:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"LiteralString"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NewCell")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Desteklenmeyen Yerleşik Çalışma Kitabı Formatlarını Algılamak**

Aspose.Slides, bazı grafiklerde yerleştirilebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları algılamak ve bu grafiklerin atlanması için [IChartData](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdata/) üzerindeki `get_EmbeddedWorkbookType` metodunu [WorkbookType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/workbooktype/) enum'ı ile birlikte kullanabilirsiniz.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/ISlide.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : System::IterateOver(slide->get_Shapes()))
{
    if (!System::ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = System::ExplicitCast<IChart>(shape);
    auto chartData = chart->get_ChartData();

    if (chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook &&
        chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro)
    {
        // Gömülü çalışma kitabı .xlsb formatında ve desteklenmiyor.
        continue;
    }

    // Burada grafik çalışma kitabı verisini okuyun veya değiştirin.
}
```

## **Harici Çalışma Kitabı**

{{% alert color="info" %}} 
Aspose.Slides 19.4'te, grafikler için veri kaynağı olarak harici çalışma kitaplarını desteklemeye başladık.
{{% /alert %}} 

### **Harici Bir Çalışma Kitabı Oluşturma**

**`ReadWorkbookStream`** ve **`SetExternalWorkbook`** yöntemlerini kullanarak ya sıfırdan bir harici çalışma kitabı oluşturabilir ya da iç bir çalışma kitabını harici hâle getirebilirsiniz.

Bu C++ kodu, harici çalışma kitabı oluşturma sürecini gösterir:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

const System::String workbookPath = u"externalWorkbook1.xlsx";

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f);
auto chartData = chart->get_ChartData();

{
    System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(workbookPath, System::IO::FileMode::Create);

    System::ArrayPtr<uint8_t> workbookData = chartData->ReadWorkbookStream()->ToArray();
    fileStream->Write(workbookData, 0, workbookData->get_Length());
}

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(workbookPath));

pres->Save(u"externalWorkbook.pptx", SaveFormat::Pptx);
```

### **Harici Bir Çalışma Kitabı Ayarlama**

**`IChartData::SetExternalWorkbook`** metodunu kullanarak, bir harici çalışma kitabını grafik için veri kaynağı olarak atayabilirsiniz. Bu yöntem aynı zamanda harici çalışma kitabının yolunu güncellemek için de kullanılabilir (eğer çalışma kitabı taşınmışsa).

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu çalışma kitaplarını hâlâ harici veri kaynağı olarak kullanabilirsiniz. Harici bir çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam bir yola dönüştürülür.

Bu C++ kodu, bir harici çalışma kitabının nasıl ayarlanacağını gösterir:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, false);
auto chartData = chart->get_ChartData();

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(u"externalWorkbook.xlsx"));

chartData->get_Series()->Add(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1"), ChartType::Pie);
auto dataPoints = chartData->get_Series()->idx_get(0)->get_DataPoints();
auto workbook = chartData->get_ChartDataWorkbook();
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B2"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B3"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B4"));

auto categories = chartData->get_Categories();
categories->Add(workbook->GetCell(0, u"A2"));
categories->Add(workbook->GetCell(0, u"A3"));
categories->Add(workbook->GetCell(0, u"A4"));
pres->Save(u"Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
```

`updateChartData` parametresi (`SetExternalWorkbook` metodunda) bir Excel çalışma kitabının yüklenip yüklenmeyeceğini belirtmek için kullanılır.

* `updateChartData` değeri `false` olduğunda, yalnızca çalışma kitabı yolu güncellenir—grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez. Bu ayar, hedef çalışma kitabı mevcut olmadığında veya erişilemez olduğunda kullanılabilir.
* `updateChartData` değeri `true` olduğunda, grafik verisi hedef çalışma kitabından güncellenir.

```c++
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Almak**

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını indeks üzerinden alın.
3. Grafik şekli için bir nesne oluşturun.
4. Grafiğin veri kaynağını temsil eden kaynak (`ChartDataSourceType`) türü için bir nesne oluşturun.
5. Kaynak türünün harici çalışma kitabı veri kaynağı türüyle aynı olmasına göre ilgili koşulu belirtin.

Bu C++ kodu işlemi gösterir:

```c++
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Sunumu kaydeder
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Grafik Verisini Düzenleme**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarının içeriğini değiştirdiğiniz şekilde düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu C++ kodu, tanımlanan sürecin bir uygulamasını gösterir:

```c++
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Grafik Önbelleğinden Bir Çalışma Kitabını Kurtarma**

Eğer bir grafik, eksik veya erişilemez bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. Sunumu açmadan önce [LoadOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/) oluşturun, [set_SpreadsheetOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) ile yapılandırın ve `true` ile [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) metodunu çağırın.

Aşağıdaki C++ örneği, bir grafiğin kullanılabilir olmayan harici çalışma kitabına başvurduğu bir sunumu açar ve geri kazanılan verilere [IChart::get_ChartData](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/get_chartdata/) ve [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) aracılığıyla erişir:

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Kurtarılan çalışma kitabı verisini burada okuyun veya değiştirin.

presentation->Dispose();
```

Eğer harici çalışma kitabı mevcut değil ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir `System::InvalidOperationException` fırlatır. Önbellekteki grafik verilerini kullanmak kabul edilebilir bir geri dönüş olduğunda yalnızca kurtarmayı etkinleştirin; çünkü önbellek, sunumun en son güncellenmesinden sonra harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici bir çalışma kitabına mı yoksa yerleşik bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) ve bir [harici çalışma kitabı yolu](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) vardır; kaynak bir harici çalışma kitabıysa, tam yolu okuyarak bir harici dosyanın kullanıldığından emin olabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Eğer göreli bir yol belirlerseniz, otomatik olarak mutlak bir yola dönüştürülür. Bu, proje taşınabilirliği açısından kullanışlıdır; ancak sunumun PPTX dosyasında mutlak yolu depolayacağını unutmayın.

**Ağ kaynakları/paylaşımlarındaki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, uzaktaki çalışma kitaplarını Aspose.Slides üzerinden doğrudan düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Hayır. Sunum, bir [harici dosyaya bağlantı](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) depolar ve veriyi okurken bunu kullanır. Sunum kaydedildiğinde harici dosya kendisi değiştirilmez.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlantı oluştururken bir şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak veya şifresi çözülmüş bir kopya (örneğin, [Aspose.Cells](/cells/cpp/)) hazırlamak ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını depolar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklendiğinde her grafikte de yansıtılır.