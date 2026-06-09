---
title: Excel Verilerini PowerPoint Sunumlarına Entegre Et
linktitle: Excel Entegrasyonu
type: docs
weight: 330
url: /tr/net/excel-integration/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides'ta ExcelDataWorkbook API'sini kullanarak Excel çalışma kitaplarından veri okuyun. Sayfaları ve hücreleri yükleyin ve değerleri veri odaklı PowerPoint sunumları oluşturmak için kullanın."
---
## **Giriş**

PowerPoint sunumları, bilgiyi görüntüleme ve iletme konusunda güçlü bir yoldur. Genellikle Excel çalışma kitaplarıyla birlikte kullanılır; Excel, yapılandırılmış verilerin mükemmel bir kaynağı olarak hizmet verirken, PowerPoint bu verileri izleyiciler için görselleştirmede üstünlük gösterir.

Excel ve PowerPoint'i birleştirmenin gerekli olduğu birçok pratik senaryo vardır: posta birleştirme, veri tablolarını doldurma, her veri kaydı için bir slayt oluşturma (toplu slayt üretimi), eğitim materyalleri oluşturma ve birden fazla Excel raporunu tek bir sunumda birleştirme, bunlardan sadece birkaçıdır.

Şimdiye kadar, Aspose.Slides API'si ile bu özellikleri uygulamak, Aspose.Cells gibi üçüncü taraf çözümlere dayanmayı gerektiriyordu. Bu araçlar güçlü olsa da, yalnızca temel veri entegrasyonu işlevselliğine ihtiyaç duyan kullanıcılar için aşırı karmaşık ve maliyetli olabilir.

## **Nasıl Çalışır**

Excel verileriyle çalışmayı daha kolay ve sorunsuz hâle getirmek için Aspose.Slides, Excel çalışma kitaplarından veri okuma ve içeriği bir sunuma aktarma için yeni sınıflar tanıttı. Bu özellik, API kullanıcılarının sunum iş akışları içinde Excel'i bir veri kaynağı olarak kullanmak istediklerinde güçlü yeni olanaklar sunar.

Yeni işlevsellik, genel amaçlı veri erişimi için tasarlanmıştır ve Sunum Belge Nesne Modeli (DOM)'ye entegre değildir. Bu, *Excel dosyalarını düzenlemeye veya kaydetmeye izin vermez* — yalnızca çalışma kitaplarını açmak ve içeriklerinde gezinerek hücre verilerini almak için tasarlanmıştır.

Bu özelliğin çekirdeğinde yeni [ExcelDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.excel/exceldataworkbook/) sınıfı bulunur. Bu sınıf, bir Excel çalışma kitabını yerel bir dosyadan veya bir akıştan yüklemenizi sağlar. Yüklendikten sonra, konumlarına göre (örneğin satır ve sütun indeksleri veya adlandırılmış aralıklar) belirli hücreleri almanıza imkan tanıyan [GetCell](https://reference.aspose.com/slides/tr/net/aspose.slides.excel/exceldataworkbook/getcell/) yönteminin çeşitli aşırı yüklemelerini sunar.

Her [GetCell](https://reference.aspose.com/slides/tr/net/aspose.slides.excel/exceldataworkbook/getcell/) çağrısı, [ExcelDataCell](https://reference.aspose.com/slides/tr/net/aspose.slides.excel/exceldatacell/) sınıfının bir örneğini döndürür. Bu nesne, Excel çalışma kitabındaki tek bir hücreyi temsil eder ve değerine basit ve sezgisel bir şekilde erişmenizi sağlar.

#### **Excel Grafik İçe Aktar**

İşlevselliği genişletmek için bir sonraki adım, [ExcelWorkbookImporter](https://reference.aspose.com/slides/tr/net/aspose.slides.import/excelworkbookimporter/) sınıfıdır. Bu yardımcı sınıf, bir Excel çalışma kitabından bir sunuma içerik aktarma işlevi sağlar. Belirtilen Excel çalışma kitabından seçilen grafiği alıp verilen şekil koleksiyonunun sonuna belirtilen koordinatlarda eklemenize yardımcı olan [AddChartFromWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) yönteminin çeşitli aşırı yüklemelerini içerir.

Kısacası, Excel verilerini okumak için hafif ve basit bir API'dir — tam bir elektronik tablo işleme kütüphanesinin getirdiği ek yüke ihtiyaç duymayan birçok geliştiricinin tam olarak aradığı şeydir.

## **Haydi Kodlayalım**

### **Posta Birleştirme Senaryosu Örneği**

Aşağıdaki örnekte, bir Excel çalışma kitabında saklanan verileri temel alarak birden fazla sunum oluşturan basit bir posta birleştirme senaryosunu uygulayacağız.

Başlamak için iki şeye ihtiyacımız var:
1. Verileri içeren bir Excel çalışma kitabı

![Excel veri örneği](example1_image0.png)

2. PowerPoint sunum şablonu

![PowerPoint şablon örneği](example1_image1.png)

```csharp
// Çalışan verileriyle Excel çalışma kitabını yükle.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Sunum şablonunu yükle.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Excel satırlarını döngüye al (satır 0'daki başlığı hariç).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Her çalışan kaydı için yeni bir sunum oluştur.
    using Presentation employeePresentation = new Presentation();

    // Varsayılan boş slaytı kaldır.
    employeePresentation.Slides.RemoveAt(0);

    // Şablon slaytı yeni sunuma kopyala.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Hedef şekilden paragrafları al (şekil indeksi 1'in kullanıldığı varsayılır).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Yer tutucuları Excel'den gelen verilerle değiştir.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Kişiselleştirilmiş sunumu ayrı bir dosyaya kaydet.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Sonuç](example1_image2.png)

### **Excel Tablo Örneği**

İkinci örnekte, bir Excel tablosundan verileri kopyalayıp daha görsel açıdan çekici bir formatta PowerPoint slaytında gösteriyoruz.

Bu örnekte, basit bir çalışan tablosu içeren birinci örnekten aynı Excel çalışma kitabını yeniden kullanıyoruz.

```csharp
// Çalışan verilerini içeren Excel çalışma kitabını yükle.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Yeni bir PowerPoint sunumu oluştur.
using Presentation presentation = new Presentation();

// İlk slayta bir tablo şekli ekle.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// PowerPoint tablosunu Excel çalışma kitabından gelen verilerle doldur.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Sonuç sunumu bir dosyaya kaydet.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Sonuç](example2_image0.png)

### **Excel Grafik İçe Aktarma Örneği**

Bu örnekte, önceki örnekte kullanılan Excel çalışma kitabının ilk çalışma sayfasından bir grafik içe aktarıyoruz. Grafik, sonuç sunumda dış çalışma kitabına bağlanacaktır.

İlk olarak, çalışan tablosuna dayanarak Excel çalışma kitabına bir Pasta grafik ekliyoruz.

![Excel Grafik örneği](example3_image0.png)

```csharp
// Yeni bir PowerPoint sunumu oluştur.
using Presentation presentation = new Presentation();

// İlk slaydın şekil koleksiyonunu al.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Çalışma kitabının ilk sayfasından "Chart 1" adlı grafiği içe aktar ve şekil koleksiyonuna ekle.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Ortaya çıkan sunumu bir dosyaya kaydet.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Sonuç](example3_image1.png)

### **Tüm Excel Grafiklerini İçe Aktarma Örneği**

Bir Excel çalışma kitabının içinde birçok grafik olduğunu ve bunların hepsini bir sunuma aktarmanız gerektiğini hayal edin. Her grafik yeni bir slayta yerleştirilmeli.

Aşağıdaki kod, kaynak Excel dosyasındaki tüm çalışma sayfalarını dolaşır, her çalışma sayfasından grafikleri çıkarır ve her bir grafiği boş bir slayt düzeni kullanarak ayrı bir slayta ekler. Sonuç sunumda yalnızca grafik verileri gömülür, tüm çalışma kitabı eklenmez.

```csharp
// Çalışan verilerini içeren Excel çalışma kitabını yükle.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Yeni bir PowerPoint sunumu oluştur.
using Presentation presentation = new Presentation();

// Boş slayt düzenini al.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Excel çalışma kitabında bulunan tüm çalışma sayfalarının adlarını al.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Çalışma sayfası için grafik indekslerini grafik adlarıyla eşleyen bir sözlük al.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Boş düzeni kullanarak yeni bir slayt ekle.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Belirtilen grafiği Excel çalışma kitabından slaydın şekil koleksiyonuna içe aktar.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Ortaya çıkan sunumu bir dosyaya kaydet.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

## **Özet**

Aspose.Slides içinde doğrudan kullanılabilen bu mekanizma, Excel verileriyle ve sunumlarla tek bir yerde çalışmayı birleştirir. Görsel grafikler ve Excel tabloları şeklinde sunulan verilerle slaytlar oluşturmanıza olanak tanır — ek kütüphaneler veya karmaşık entegrasyonlar olmadan.