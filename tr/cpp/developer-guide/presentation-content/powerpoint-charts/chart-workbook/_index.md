---
title: Sunumlarda C++ Kullanarak Grafik Çalışma Kitaplarını Yönetme
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
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ı keşfedin: PowerPoint ve OpenDocument biçimlerinde grafik çalışma kitaplarını zahmetsizce yönetin ve sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini nasıl okuyup yazacağınızı, çalışma kitabı hücrelerini grafik veri etiketi olarak nasıl kullanacağınızı, çalışma sayfası koleksiyonlarına nasıl erişeceğinizi ve grafik değerleri için veri kaynağı türünü nasıl belirteceğinizi gösterir.

Ayrıca dış çalışma kitaplarının grafik veri kaynakları olarak kullanılmasını da kapsar. Örnekler, dış bir çalışma kitabı oluşturup atamayı, bir grafikle ilişkili dış çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemeyi göstermektedir.

## **Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides, grafik veri çalışma kitaplarını (Aspose.Cells ile düzenlenmiş grafik verilerini içeren) okuma ve yazma imkanı sunan [ReadWorkbookStream](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) ve [WriteWorkbookStream](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) metodlarını sağlar. **Not** grafik verilerinin aynı şekilde düzenlenmiş olması ya da kaynağa benzer bir yapıya sahip olması gerekir.

``` cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

Bu C++ kodu, bir grafik veri çalışma kitabı ayarlama işlemini gösterir:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Charts::ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

intrusive_ptr<Aspose::Cells::IWorkbook> workbook;
try
{
    workbook = Aspose::Cells::Factory::CreateIWorkbook(new String("a1.xlsx"));
}
catch (Aspose::Cells::Systems::Exception& ex)
{
    System::Console::Write(System::String::FromWCS(ex.GetMessageExp()->value()));
}

intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. Presentation sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını indeksine göre alın.
1. Birkaç veriyle bir Kabarcık grafiği ekleyin.
1. Grafik serisine erişin.
1. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.
1. Sunumu kaydedin.

Bu C++ kodu, bir çalışma kitabı hücresini grafik veri etiketi olarak ayarlamayı gösterir:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Bir sunum dosyasını temsil eden Presentation sınıfını örnekler 
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
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Veri Kaynağı Türünü Belirleme**

Bu C++ kodu, bir veri kaynağı için tür nasıl belirtilir gösterir:

```c++
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

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen biçimleri algılamak ve bu grafikleri atlamak için [IChartData](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdata/) üzerindeki `get_EmbeddedWorkbookType` metodunu ve [WorkbookType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/workbooktype/) enumarasyonunu kullanabilirsiniz.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
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
        // Gömülü çalışma kitabı .xlsb formatında, bu format desteklenmiyor.
        continue;
    }

    // Burada grafik çalışma kitabı verilerini okuyabilir veya değiştirebilirsiniz.
}
```

## **Harici Çalışma Kitabı**

{{% alert color="primary" %}} 
[Aspose.Slides](https://releases.aspose.com/slides/tr/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4'te, grafikler için veri kaynağı olarak harici çalışma kitaplarının desteğini uyguladık.
{{% /alert %}} 

### **Harici Bir Çalışma Kitabı Oluşturma**

**`ReadWorkbookStream`** ve **`SetExternalWorkbook`** metodlarını kullanarak, ya sıfırdan bir harici çalışma kitabı oluşturabilir ya da iç bir çalışma kitabını harici hâle getirebilirsiniz.

Bu C++ kodu, harici çalışma kitabı oluşturma sürecini gösterir:

```c++
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

### **Harici Bir Çalışma Kitabını Ayarlama**

**`IChartData::SetExternalWorkbook`** metodunu kullanarak, bir harici çalışma kitabını grafik için veri kaynağı olarak atayabilirsiniz. Bu metod aynı zamanda harici çalışma kitabının yolunu güncellemek için de kullanılabilir (eğer çalışma kitabı taşınmışsa).

Uzak konumlarda veya kaynaklarda depolanan çalışma kitaplarının verilerini düzenleyemezsiniz, ancak bu çalışma kitaplarını hâlâ harici bir veri kaynağı olarak kullanabilirsiniz. Harici bir çalışma kitabı için göreceli bir yol sağlanırsa, otomatik olarak tam bir yola dönüştürülür.

Bu C++ kodu, harici bir çalışma kitabını nasıl ayarlayacağınızı gösterir:

```c++
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

* `updateChartData` değeri `false` olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir—grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Bu ayarı, hedef çalışma kitabı mevcut olmadığında veya erişilemez olduğunda kullanmak isteyebilirsiniz.
* `updateChartData` değeri `true` olarak ayarlandığında, grafik verileri hedef çalışma kitabından güncellenir.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Alma**

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını indeksine göre alın.
1. Grafik şekli için bir nesne oluşturun.
1. Kaynak (`ChartDataSourceType`) türü için, grafiğin veri kaynağını temsil eden bir nesne oluşturun.
1. Kaynak türünün harici çalışma kitabı veri kaynağı türüyle aynı olmasına göre ilgili koşulu belirtin.

Bu C++ kodu, bu işlemi gösterir:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Saves the presentation
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Grafik Verisini Düzenleme**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarının içeriklerini değiştirdiğiniz şekilde düzenleyebilirsiniz. Bir harici çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu C++ kodu, açıklanan sürecin bir uygulamasıdır:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) ve bir [harici çalışma kitabı yolu](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) vardır; kaynak bir harici çalışma kitabı ise, harici bir dosyanın kullanıldığını doğrulamak için tam yolu okuyabilirsiniz.

**Harici çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreceli bir yol belirttiğinizde, otomatik olarak mutlak bir yola dönüştürülür. Bu, proje taşınabilirliği açısından uygundur; ancak, sunumun PPTX dosyasında mutlak yolu depolayacağını unutmayın.

**Ağ kaynaklarında/paylaşımlarda bulunan çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides'tan uzaktaki çalışma kitaplarını doğrudan düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Hayır. Sunum bir [harici dosyaya bağlantı](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) saklar ve verileri okurken bunu kullanır. Sunum kaydedildiğinde harici dosya kendisi değiştirilmez.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides bağlanırken şifre kabul etmez. Yaygın bir yaklaşım, şifre korumasını önceden kaldırmak veya şifresi çözülmüş bir kopya hazırlamaktır (örneğin, [Aspose.Cells](/cells/cpp/) kullanarak) ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklendiğinde her grafikte de yansıtılır.