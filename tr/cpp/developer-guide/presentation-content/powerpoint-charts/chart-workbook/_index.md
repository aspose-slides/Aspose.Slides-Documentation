---
title: C++ Kullanarak Sunumlarda Grafik Çalışma Kitaplarını Yönetme
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
- dış çalışma kitabı
- dış veri
- grafik önbelleği
- çalışma kitabı kurtarma
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları üzerinden grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketi olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca dış çalışma kitaplarını veri kaynağı olarak kullanma konusunu da kapsar. Örnekler, dış bir çalışma kitabı oluşturup atamayı, bir grafikle ilişkilendirilmiş dış çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemeyi gösterir.

## **Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides, grafik verileri çalışma kitaplarını (Aspose.Cells ile düzenlenmiş) okumanıza ve yazmanıza izin veren [ReadWorkbookStream](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) ve [WriteWorkbookStream](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) yöntemlerini sağlar. **Not**: Grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

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

Bu C++ kodu bir grafik veri çalışma kitabını ayarlama işlemini gösterir:

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

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeks üzerinden bir slaytın referansını alın.  
3. Bazı verilerle bir Balon grafiği ekleyin.  
4. Grafik serisine erişin.  
5. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
6. Sunumu kaydedin.

Bu C++ kodu bir çalışma kitabı hücresini grafik veri etiketi olarak ayarlamayı gösterir:

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

Bu C++ kodu, [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) yönteminin bir çalışma sayfası koleksiyonuna erişmek için nasıl kullanıldığını gösterir:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Veri Kaynağı Türünü Belirtme**

Bu C++ kodu bir veri kaynağı için türün nasıl belirtileceğini gösterir:

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen biçimleri algılamak ve bu grafikleri atlamak için [IChartData](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdata/) üzerindeki `get_EmbeddedWorkbookType` yöntemini ve [WorkbookType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/workbooktype/) enumını kullanabilirsiniz.

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

    // Grafik çalışma kitabı verilerini burada okuyabilir veya değiştirebilirsiniz.
}
```

## **Dış Çalışma Kitabı**

{{% alert color="primary" %}} 
Aspose.Slides 19.4 sürümünde ([Aspose.Slides for C++ 19.4 sürüm notları](https://releases.aspose.com/slides/tr/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/)) grafikler için veri kaynağı olarak dış çalışma kitapları desteği ekledik.
{{% /alert %}} 

### **Dış Çalışma Kitabı Oluşturma**

**`ReadWorkbookStream`** ve **`SetExternalWorkbook`** yöntemlerini kullanarak sıfırdan bir dış çalışma kitabı oluşturabilir veya dahili bir çalışma kitabını dışa çevirebilirsiniz.

Bu C++ kodu dış çalışma kitabı oluşturma sürecini gösterir:

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

### **Dış Çalışma Kitabı Ayarlama**

**`IChartData::SetExternalWorkbook`** yöntemini kullanarak bir dış çalışma kitabını grafik için veri kaynağı olarak atayabilirsiniz. Bu yöntem aynı zamanda dış çalışma kitabının yolu (dosya taşındıysa) güncellenmek istendiğinde de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarının verileri düzenlenemez, ancak bu çalışma kitapları dış veri kaynağı olarak kullanılabilir. Bir dış çalışma kitabı için göreli yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu C++ kodu dış çalışma kitabını nasıl ayarlayacağınızı gösterir:

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

`SetExternalWorkbook` yöntemindeki `updateChartData` parametresi, bir Excel çalışma kitabının yüklenip yüklenmeyeceğini belirtmek için kullanılır.  

* `updateChartData` değeri **false** olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir – grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Hedef çalışma kitabı mevcut değilse veya erişilemezse bu ayar kullanılabilir.  
* `updateChartData` değeri **true** olduğunda, grafik verileri hedef çalışma kitabından güncellenir.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Bir Grafiğin Dış Veri Kaynağı Çalışma Kitabı Yolunu Alma**

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeks üzerinden bir slaytın referansını alın.  
3. Grafik şekli için bir nesne oluşturun.  
4. Grafiğin veri kaynağını temsil eden (`ChartDataSourceType`) nesneyi oluşturun.  
5. Kaynak türünün dış çalışma kitabı veri kaynağı türüyle aynı olup olmadığına göre ilgili koşulu belirtin.

Bu C++ kodu işlemi gösterir:

```c++
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

### **Grafik Verilerini Düzenleme**

Dış çalışma kitaplarındaki verileri, dahili çalışma kitaplarındaki gibi düzenleyebilirsiniz. Bir dış çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu C++ kodu açıklanan sürecin bir uygulamasıdır:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Grafik Önbelleğinden Çalışma Kitabını Kurtarma**

Bir grafik, eksik veya erişilemeyen bir dış çalışma kitabı kullandığında, Aspose.Slides sunumdaki önbelleğe alınmış verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/) oluşturun, [set_SpreadsheetOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) ile yapılandırın ve sunumu açmadan önce `true` ile [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) metodunu çağırın.

Aşağıdaki C++ örneği, bir grafiğin mevcut olmayan bir dış çalışma kitabına referans verdiği bir sunumu açar ve kurtarılan verilere [IChart::get_ChartData](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichart/get_chartdata/) ve [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) üzerinden erişir:

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Read or modify the recovered workbook data here.

presentation->Dispose();
```

Dış çalışma kitabı mevcut değilse ve kurtarma devre dışı bırakıldıysa, Aspose.Slides bir `System::InvalidOperationException` fırlatır. Önbellekten grafik verilerini kullanmak kabul edilebilir bir geri dönüş ise kurtarmayı etkinleştirin; çünkü önbellek, dış çalışma kitabında sunum son güncellendiğinden sonraki değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin dış bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**  
Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) ve bir [dış çalışma kitabı yolu](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) vardır; kaynak bir dış çalışma kitabı ise tam yolu okuyarak dış bir dosyanın kullanıldığını doğrulayabilirsiniz.

**Dış çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**  
Evet. Göreli bir yol belirtildiğinde otomatik olarak mutlak yola dönüştürülür. Bu, proje taşınabilirliği için uygundur; ancak sunum bu mutlak yolu PPTX dosyasında saklar.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**  
Evet, bu çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak Aspose.Slides üzerinden uzak çalışma kitaplarını doğrudan düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Sunumu kaydederken Aspose.Slides dış XLSX dosyasını üzerine yazıyor mu?**  
Hayır. Sunum, dış dosyaya bir [bağlantı](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) saklar ve veri okuma için bu bağlantıyı kullanır. Sunum kaydedildiğinde dış dosya değiştirilmez.

**Dış dosya şifre korumalıysa ne yapmalıyım?**  
Aspose.Slides bağlanırken şifre kabul etmez. Yaygın bir yaklaşım, şifre korumasını önceden kaldırmak veya şifrelenmemiş bir kopya hazırlayıp (örneğin [Aspose.Cells](/cells/cpp/) kullanarak) ona bağlamaktır.

**Birden çok grafik aynı dış çalışma kitabına referans verebilir mi?**  
Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosyada yapılan bir güncelleme bir sonraki veri yüklemesinde tüm grafiklerde yansır.