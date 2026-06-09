---
title: Excel Verilerini PowerPoint Sunumlarına Entegre Et
linktitle: Excel Entegrasyonu
type: docs
weight: 330
url: /tr/cpp/excel-integration/
keywords:
- Excel
- çalışma kitabı
- Excel oku
- Excel'i entegre et
- veri kaynağı
- posta birleştirme
- tablo içe aktar
- Excel'i PowerPoint'e
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides içinde ExcelDataWorkbook API'sini kullanarak Excel çalışma kitaplarından veri okuyun. Sayfaları ve hücreleri yükleyin ve değerleri kullanarak veri odaklı PowerPoint sunumları oluşturun."
---
## **Giriş**

PowerPoint sunumları, bilgiyi görüntülemek ve iletmek için güçlü bir yoldur. Genellikle Excel çalışma kitaplarıyla birlikte kullanılır; Excel yapılandırılmış verilerin mükemmel bir kaynağını sağlar ve PowerPoint bu verileri izleyicilere görselleştirmede üstünlük gösterir.

Excel ve PowerPoint'in birleştirilmesinin gerekli olduğu birçok pratik senaryo vardır: postalar birleştirme, veri tablolarını doldurma, veri kaydı başına bir slayt oluşturma (toplu slayt oluşturma), eğitim materyalleri oluşturma ve birden fazla Excel raporunu tek bir sunumda birleştirme gibi.

Şimdiye kadar, bu özellikleri Aspose.Slides API'siyle uygulamak, Aspose.Cells gibi üçüncü taraf çözümlere dayanmayı gerektiriyordu. Bu araçlar sağlam olsa da, yalnızca temel veri entegrasyonu işlevselliğine ihtiyaç duyan kullanıcılar için aşırı karmaşık ve maliyetli olabiliyor.

## **Nasıl Çalışır**

Excel verileriyle çalışmayı daha kolay ve sorunsuz hale getirmek için Aspose.Slides, Excel çalışma kitaplarından veri okumak ve içeriği bir sunuma aktarmak için yeni sınıflar ekledi. Bu özellik, Excel'i sunum iş akışlarında veri kaynağı olarak kullanmak isteyen API kullanıcıları için güçlü yeni olasılıklar sunar.

Yeni işlevsellik, genel amaçlı veri erişimi için tasarlanmıştır ve Presentation Document Object Model (DOM)'a entegre değildir. Bu, *Excel dosyalarını düzenlemeye veya kaydetmeye izin vermediği* anlamına gelir — tek amacı, çalışma kitaplarını açmak ve içeriklerinde gezinerek hücre verilerini almaktır.

Bu özelliğin çekirdeğinde yeni [ExcelDataWorkbook](https://reference.aspose.com/slides/tr/cpp/aspose.slides.excel/exceldataworkbook/) sınıfı bulunur. Bu sınıf, bir Excel çalışma kitabını yerel bir dosyadan veya bir akıştan yüklemenizi sağlar. Yüklemeden sonra, konumlarına göre belirli hücreleri (ör. satır ve sütun indeksleri veya adlandırılmış aralıklar) almanıza olanak tanıyan [GetCell](https://reference.aspose.com/slides/tr/cpp/aspose.slides.excel/exceldataworkbook/getcell/) metodunun çeşitli aşırı yüklemelerini sunar.

[GetCell](https://reference.aspose.com/slides/tr/cpp/aspose.slides.excel/exceldataworkbook/getcell/) her çağrısı, [ExcelDataCell](https://reference.aspose.com/slides/tr/cpp/aspose.slides.excel/exceldatacell/) sınıfının bir örneğini döndürür. Bu nesne, Excel çalışma kitabındaki tek bir hücreyi temsil eder ve değerine basit ve sezgisel bir şekilde erişmenizi sağlar.

#### **Excel Grafik İçe Aktarma**

Fonksiyonelliği genişletmenin bir sonraki adımı, [ExcelWorkbookImporter](https://reference.aspose.com/slides/tr/cpp/aspose.slides.import/excelworkbookimporter/) sınıfıdır. Bu yardımcı sınıf, bir Excel çalışma kitabından içeriği bir sunuma aktarma işlevi sağlar. Belirtilen koordinatlarda, verilen şekil koleksiyonunun sonuna seçilen grafiği eklemenize yardımcı olan [AddChartFromWorkbook](https://reference.aspose.com/slides/tr/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) metodunun çeşitli aşırı yüklemelerini içerir.

Kısacası, Excel verilerini okumak için hafif ve anlaşılır bir API'dir — tam da birçok geliştiricinin tam bir elektronik tablo işleme kütüphanesinin yükü olmadan ihtiyacı olduğu şey.

## **Kodlayalım**

### **Posta Birleştirme Senaryosu Örneği**

Aşağıdaki örnekte, bir Excel çalışma kitabında saklanan veriler temelinde birden fazla sunum oluşturarak basit bir posta birleştirme senaryosu uygulayacağız.

Başlamak için iki şeye ihtiyacımız var:
1. Verileri içeren bir Excel çalışma kitabı

![Excel data example](example1_image0.png)

2. PowerPoint sunum şablonu

![PowerPoint template example](example1_image1.png)

```cpp
// Çalışan verileriyle Excel çalışma kitabını yükle.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Sunum şablonunu yükle.
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // Excel satırları üzerinde döngü (satır 0'daki başlığı hariç).
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // Her çalışan kaydı için yeni bir sunum oluştur.
    auto employeePresentation = MakeObject<Presentation>();

    // Varsayılan boş slaytı kaldır.
    employeePresentation->get_Slides()->RemoveAt(0);

    // Şablon slaytı yeni sunuma klonla.
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // Hedef şekilden paragrafları al (şekil indeksi 1'in kullanıldığı varsayılır).
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // Yer tutucuları Excel'den gelen verilerle değiştir.
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // Kişiselleştirilmiş sunumu ayrı bir dosyaya kaydet.
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![Result](example1_image2.png)

### **Excel Tablosu Örneği**

İkinci örnekte, bir Excel tablosundan verileri kopyalayıp daha görsel olarak çekici bir formatta PowerPoint slaytında gösteriyoruz.

Bu örnekte, basit bir çalışan tablosu içeren ilk örnekten aynı Excel çalışma kitabını yeniden kullanıyoruz.

```cpp
// Çalışan verilerini içeren Excel çalışma kitabını yükle.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Yeni bir PowerPoint sunumu oluştur.
auto presentation = MakeObject<Presentation>();

// İlk slayta bir tablo şekli ekle.
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// PowerPoint tablosunu Excel çalışma kitabındaki verilerle doldur.
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// Oluşturulan sunumu bir dosyaya kaydet.
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Result](example2_image0.png)

### **Excel Grafiği İçe Aktarma Örneği**

Bu örnekte, önceki örnekte kullanılan Excel çalışma kitabının ilk çalışma sayfasındaki bir grafiği içe aktarıyoruz. Grafik, sonuç sunumda dış çalışma kitabına bağlanacaktır.

İlk olarak, çalışan tablosuna dayanarak Excel çalışma kitabına bir Pasta grafiği ekliyoruz.

![Excel Chart example](example3_image0.png)

```cpp
// Yeni bir PowerPoint sunumu oluştur.
auto presentation = MakeObject<Presentation>();

// İlk slaydın şekil koleksiyonunu al.
auto shapes = presentation->get_Slide(0)->get_Shapes();

// Çalışma kitabının ilk sayfasından "Chart 1" adlı grafiği içe aktar ve şekil koleksiyonuna ekle.
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// Oluşturulan sunumu bir dosyaya kaydet.
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Result](example3_image1.png)

### **Tüm Excel Grafiklerini İçe Aktarma Örneği**

Diyelim ki içinde birçok grafik bulunan bir Excel çalışma kitabınız var ve bunların tümünü bir sunuma aktarmanız gerekiyor. Her grafik yeni bir slayta yerleştirilmeli.

Aşağıdaki kod, kaynak Excel dosyasındaki tüm çalışma sayfalarını dolaşır, her bir çalışma sayfasından grafikleri ayıklar ve her grafiği boş bir slayt düzeni kullanarak ayrı bir slayta ekler. Sonuç sunumda yalnızca grafik verileri gömülü olacaktır, tüm çalışma kitabı değil.

```cpp
// Çalışan verilerini içeren Excel çalışma kitabını yükle.
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// Yeni bir PowerPoint sunumu oluştur.
auto presentation = MakeObject<Presentation>();

// Boş slayt düzenini al.
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Excel çalışma kitabında bulunan tüm çalışma sayfalarının adlarını al.
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // Çalışma sayfası için grafik indekslerini grafik adlarıyla eşleyen bir sözlük al.
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // Boş düzeni kullanarak yeni bir slayt ekle.
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // Belirtilen grafiği Excel çalışma kitabından slaydın şekil koleksiyonuna içe aktar.
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// Oluşturulan sunumu bir dosyaya kaydet.
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Özet**

Aspose.Slides içinde doğrudan mevcut olan bu mekanizma, Excel verileriyle ve sunumlarla tek bir yerde çalışmayı birleştirir. Görsel grafikler ve Excel tabloları şeklinde sunulan verilerle slaytlar oluşturmanızı sağlar - ekstra kütüphaneler veya karmaşık entegrasyonlar olmadan.