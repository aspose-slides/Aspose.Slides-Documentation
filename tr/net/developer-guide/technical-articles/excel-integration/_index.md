---
title: Excel Verilerini PowerPoint Sunumlarına Entegre Edin
linktitle: Excel Entegrasyonu
type: docs
weight: 330
url: /tr/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
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

PowerPoint sunumları, bilgiyi görüntülemek ve iletmek için güçlü bir yoldur. Genellikle Excel çalışma kitaplarıyla birlikte kullanılır; Excel yapılandırılmış veri kaynağı olarak mükemmel bir hizmet verirken, PowerPoint bu verileri izleyiciler için görselleştirmede başarılıdır.

Excel ve PowerPoint'i birleştirmenin gerekli olduğu birçok pratik senaryo vardır: birleştirme (mail merge), veri tablolarını doldurma, her veri kaydı için bir slayt oluşturma (toplu slayt oluşturma), eğitim materyalleri hazırlama ve birden fazla Excel raporunu tek bir sunumda birleştirme gibi.

Şu ana kadar, bu özellikleri Aspose.Slides API'siyle uygulamak, Aspose.Cells gibi üçüncü taraf çözümlere dayanmayı gerektiriyordu. Bu araçlar sağlam olsa da, yalnızca temel veri entegrasyonu işlevselliğine ihtiyaç duyan kullanıcılar için aşırı karmaşık ve maliyetli olabiliyor.

## **Nasıl Çalışır**

Excel verileriyle çalışmayı daha kolay ve akıcı hale getirmek için Aspose.Slides, Excel çalışma kitaplarından veri okuma ve içeriği bir sunuma içe aktarma için yeni sınıflar tanıttı. Bu özellik, sunum iş akışları içinde veri kaynağı olarak Excel'i kullanmak isteyen API kullanıcıları için güçlü yeni olasılıklar sunar.

Yeni işlevsellik, genel amaçlı veri erişimi için tasarlanmıştır ve Presentation Document Object Model (DOM)’a entegre edilmemiştir. Bu, *Excel dosyalarını düzenlemeye veya kaydetmeye izin vermediği* anlamına gelir — tek amacı, çalışma kitaplarını açmak ve içeriklerinde gezinerek hücre verilerini almaktır.

Bu özelliğin kalbinde yeni [ExcelDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.excel/exceldataworkbook/) sınıfı bulunur. Bu sınıf, bir Excel çalışma kitabını yerel bir dosyadan ya da bir akıştan yüklemenizi sağlar. Yüklendikten sonra, [GetCell](https://reference.aspose.com/slides/tr/net/aspose.slides.excel/exceldataworkbook/getcell/) metodunun birkaç aşırı yüklemesini kullanarak belirli hücreleri (ör. satır ve sütun indeksleri ya da adlandırılmış aralıklar) alabilirsiniz.

[GetCell](https://reference.aspose.com/slides/tr/net/aspose.slides.excel/exceldataworkbook/getcell/) metodunun her çağrısı, [ExcelDataCell](https://reference.aspose.com/slides/tr/net/aspose.slides.excel/exceldatacell/) sınıfının bir örneğini döndürür. Bu nesne, Excel çalışma kitabındaki tek bir hücreyi temsil eder ve değerine basit ve sezgisel bir şekilde erişmenizi sağlar.

#### **Bir Excel Grafiği İçe Aktarma**

İşlevselliği genişletmek için bir sonraki adım, [ExcelWorkbookImporter](https://reference.aspose.com/slides/tr/net/aspose.slides.import/excelworkbookimporter/) sınıfıdır. Bu yardımcı sınıf, bir Excel çalışma kitabından bir sunuma içerik içe aktarma işlevi sağlar. Belirtilen Excel çalışma kitabından seçilen grafiği almak ve verilen şekil koleksiyonunun sonuna belirtilen koordinatlarda eklemek için [AddChartFromWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) metodunun birkaç aşırı yüklemesini içerir.

#### **Bir Excel Tablosu İçe Aktarma**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/tr/net/aspose.slides.import/excelworkbookimporter/) sınıfı ayrıca [AddTableFromWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) metodunun birkaç aşırı yüklemesini içerir. Bu metodlar, belirli bir çalışma sayfasından belirtilen hücre aralığını içe aktarmanıza ve verilen şekil koleksiyonunun sonuna belirtilen koordinatlarda bir tablo olarak eklemenize olanak tanır.

Kısacası, bu hafif ve doğrudan API, Excel verilerini okumak için tam bir elektronik tablo işleme kütüphanesinin getirdiği yük olmadan tam olarak ihtiyacı olan geliştiriciler için idealdir.

## **Kodlayalım**

### **Mail Merge Senaryo Örneği**

Aşağıdaki örnekte, bir Excel çalışma kitabında saklanan veriye dayanarak birden çok sunum oluşturarak basit bir Mail Merge senaryosu uygulayacağız.

Başlamak için iki şeye ihtiyacımız var:
1. Veriyi içeren bir Excel çalışma kitabı

![Excel data example](example1_image0.png)

2. PowerPoint sunum şablonu

![PowerPoint template example](example1_image1.png)

```csharp
// Çalışan verileri içeren Excel çalışma kitabını yükle.
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

    // Yer tutucuları Excel'den verilerle değiştir.
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

![Result](example1_image2.png)

### **Excel Tablo Örneği**

İkinci örnekte, bir Excel tablosundaki veriyi kopyalayıp daha görsel açıdan çekici bir formatta bir PowerPoint slaytında gösteriyoruz.

Bu örnekte, birinci örnekten aynı Excel çalışma kitabını tekrar kullanıyoruz; bu kitap basit bir çalışan tablosu içeriyor.

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

// PowerPoint tablosunu Excel çalışma kitabındaki verilerle doldur.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Oluşturulan sunumu bir dosyaya kaydet.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Result](example2_image0.png)

### **Bir Excel Grafiği İçe Aktarma Örneği**

Bu örnekte, önceki örnekte kullanılan Excel çalışma kitabının ilk çalışma sayfasından bir grafik içe aktarıyoruz. Grafik, sonuç sunumda harici çalışma kitabına bağlanacaktır.

İlk olarak, çalışan tablosuna dayalı bir Pasta (Pie) grafiği Excel çalışma kitabına ekliyoruz.

![Excel Chart example](example3_image0.png)

```csharp
// Yeni bir PowerPoint sunumu oluştur.
using Presentation presentation = new Presentation();

// İlk slaydın şekil koleksiyonunu al.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Çalışma kitabının ilk sayfasından "Chart 1" adlı grafiği içe aktar ve şekil koleksiyonuna ekle.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Oluşturulan sunumu bir dosyaya kaydet.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Result](example3_image1.png)

### **Tüm Excel Grafiklerini İçe Aktarma Örneği**

Diyelim ki içinde çok sayıda grafik bulunan bir Excel çalışma kitabınız var ve bunların hepsini bir sunuma içe aktarmanız gerekiyor. Her grafik yeni bir slayta yerleştirilmeli.

Aşağıdaki kod, kaynak Excel dosyasındaki tüm çalışma sayfalarını döngüyle dolaşır, her sayfadan grafikleri çıkarır ve her bir grafiği boş bir slayt düzeni kullanarak ayrı bir slayta ekler. Sonuç sunumda yalnızca grafik verileri gömülür, tüm çalışma kitabı eklenmez.

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

        // Belirtilen grafiği Excel çalışma kitabından slaytın şekil koleksiyonuna içe aktar.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Oluşturulan sunumu bir dosyaya kaydet.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Bir Excel Tablosu İçe Aktarma Örneği**

Bu örnekte, bir Excel çalışma sayfasındaki biçimlendirilmiş bir tabloyu doğrudan bir PowerPoint sunumuna içe aktarıyoruz.

Kaynak Excel çalışma sayfası, çalışan verileri içeren biçimlendirilmiş bir tablo içerir:

![Excel Table example](example4_image0.png)

```csharp
// Yeni bir PowerPoint sunumu oluştur.
using Presentation presentation = new Presentation();

// İlk slaydın şekil koleksiyonunu al.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Çalışma kitabının ilk sayfasından tabloyu içe aktar ve şekil koleksiyonuna ekle.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Oluşturulan sunumu bir dosyaya kaydet.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![Result](example4_image1.png)


## **Özet**

Aspose.Slides içinde doğrudan mevcut olan bu mekanizma, Excel verileri ve sunumlarla tek bir noktada çalışmayı birleştirir. Ek kütüphanelere veya karmaşık entegrasyonlara ihtiyaç duymadan, görsel grafikler ve Excel tabloları olarak sunulan verilerle slaytlar oluşturmanıza olanak tanır.