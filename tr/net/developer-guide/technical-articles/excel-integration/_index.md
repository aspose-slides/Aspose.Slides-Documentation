---
title: Excel Verilerini PowerPoint Sunumlarına Bütünleştirin
linktitle: Excel Entegrasyonu
type: docs
weight: 330
url: /tr/net/excel-integration/
keywords:
- Excel
- çalışma kitabı
- Excel oku
- Excel'i bütünleştir
- veri kaynağı
- posta birleştirme
- tablo içe aktar
- Excel'i PowerPoint'e
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Excel çalışma kitaplarından verileri Aspose.Slides içinde ExcelDataWorkbook API'si kullanarak okuyun. Sayfaları ve hücreleri yükleyin ve değerleri veri odaklı PowerPoint sunumları oluşturmak için kullanın."
---
## **Giriş**

PowerPoint sunumları, bilgiyi görüntülemek ve iletmek için güçlü bir yoldur. Genellikle Excel çalışma kitaplarıyla birlikte kullanılırlar; Excel yapılandırılmış veriler için mükemmel bir kaynak sağlar ve PowerPoint bu verileri izleyicilere görselleştirme konusunda üstünlük gösterir.

Excel ve PowerPoint'i birleştirmenin hayati olduğu birçok pratik senaryo vardır: posta birleştirme, veri tablolarını doldurma, her veri kaydı için bir slayt oluşturma (toplu slayt üretimi), eğitim materyalleri hazırlama ve çoklu Excel raporlarını tek bir sunumda birleştirme gibi.

Şimdiye kadar, bu özellikleri Aspose.Slides API'siyle uygulamak, Aspose.Cells gibi üçüncü taraf çözümlerine dayanmayı gerektiriyordu. Bu araçlar güçlü olsa da, yalnızca temel veri bütünleştirme işlevine ihtiyaç duyan kullanıcılar için gereğinden fazla karmaşık ve maliyetli olabilir.

## **Nasıl Çalışır**

Excel verileriyle çalışmayı daha kolay ve sorunsuz hale getirmek için Aspose.Slides, Excel çalışma kitaplarından veri okuyan ve içeriği bir sunuma içe aktaran yeni sınıflar ekledi. Bu özellik, API kullanıcılarının sunum iş akışlarında Excel'i veri kaynağı olarak kullanmalarına güçlü yeni imkanlar sunar.

Yeni işlevsellik, genel amaçlı veri erişimi için tasarlanmıştır ve Sunum Belge Nesne Modeli (DOM)'a entegre edilmemiştir. Bu, *Excel dosyalarını düzenleme veya kaydetme izni vermediği* anlamına gelir — tek amacı, çalışma kitaplarını açmak ve içeriklerinde gezerek hücre verilerini almaktır.

Bu özelliğin çekirdeğinde yeni [ExcelDataWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.excel/exceldataworkbook/) sınıfı bulunur. Bu sınıf, bir Excel çalışma kitabını yerel dosyadan veya bir akıştan yüklemenizi sağlar. Yüklendikten sonra, [GetCell](https://reference.aspose.com/slides/tr/net/aspose.slides.excel/exceldataworkbook/getcell/) metodunun çeşitli aşırı yüklemelerini sunar; bu metodla hücreleri konumlarına göre (ör. satır ve sütun indeksleri veya adlandırılmış aralıklar) alabilirsiniz.

[GetCell](https://reference.aspose.com/slides/tr/net/aspose.slides.excel/exceldataworkbook/getcell/) her çağrısı, [ExcelDataCell](https://reference.aspose.com/slides/tr/net/aspose.slides.excel/exceldatacell/) sınıfının bir örneğini döndürür. Bu nesne, Excel çalışma kitabındaki tek bir hücreyi temsil eder ve değerine basit ve sezgisel bir şekilde erişmenizi sağlar.

#### **Bir Excel Grafiği İçe Aktarma**

İşlevselliği genişletmek için sonraki adım, [ExcelWorkbookImporter](https://reference.aspose.com/slides/tr/net/aspose.slides.import/excelworkbookimporter/) sınıfıdır. Bu yardımcı sınıf, bir Excel çalışma kitabından içeriği bir sunuma içe aktarma işlevi sağlar. [AddChartFromWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) metodunun çeşitli aşırı yüklemelerini içerir; bu metod, belirtilen Excel çalışma kitabından seçilen grafiği alıp, verilen şekil koleksiyonunun sonuna belirtilen koordinatlarda eklemenize yardımcı olur.

#### **Bir Excel Tablosu İçe Aktarma**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/tr/net/aspose.slides.import/excelworkbookimporter/) sınıfı ayrıca [AddTableFromWorkbook](https://reference.aspose.com/slides/tr/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) metodunun çeşitli aşırı yüklemelerini içerir. Bu metodlar, belirtilen çalışma sayfasından belirli bir hücre aralığını içe aktararak, verilen şekil koleksiyonunun sonuna belirtilen koordinatlarda tablo olarak eklemenizi sağlar.

Kısacası, Excel verilerini okumak için hafif ve doğrudan bir API'dir — tam bir elektronik tablo işleme kütüphanesinin getirdiği yük olmadan birçok geliştiricinin tam istediği şey.

## **Kodlayalım**

### **Posta Birleştirme Senaryosu Örneği**

Aşağıdaki örnekte, bir Excel çalışma kitabında depolanan verilerle birden çok sunum üreterek basit bir posta birleştirme senaryosu uygulayacağız.

Başlamak için iki şeye ihtiyacımız var:
1. Verileri içeren bir Excel çalışma kitabı

![Excel veri örneği](example1_image0.png)

2. PowerPoint sunum şablonu

![PowerPoint şablon örneği](example1_image1.png)

```csharp
// Çalışan verileri içeren Excel çalışma kitabını yükleyin.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Sunum şablonunu yükleyin.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Excel satırları üzerinde dolaşın (satır 0'daki başlığı dışarıda tutarak).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Her çalışan kaydı için yeni bir sunum oluşturun.
    using Presentation employeePresentation = new Presentation();

    // Varsayılan boş slaytı kaldırın.
    employeePresentation.Slides.RemoveAt(0);

    // Şablon slaytını yeni sunuma klonlayın.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Hedef şekilden paragrafları alın (şekil indeksi 1'in kullanıldığı varsayılır).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Yer tutucuları Excel'den gelen verilerle değiştirin.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Kişiselleştirilmiş sunumu ayrı bir dosyaya kaydedin.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Sonuç](example1_image2.png)

### **Excel Tablo Örneği**

İkinci örnekte, bir Excel tablosundaki verileri kopyalayıp PowerPoint slaytında daha görsel açıdan çekici bir formatta gösteriyoruz.

Bu örnekte, basit bir çalışan tablosu içeren ilk örnekten aynı Excel çalışma kitabını yeniden kullanıyoruz.

```csharp
// Çalışan verilerini içeren Excel çalışma kitabını yükleyin.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Yeni bir PowerPoint sunumu oluşturun.
using Presentation presentation = new Presentation();

// İlk slayda bir tablo şekli ekleyin.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// PowerPoint tablosunu Excel çalışma kitabından gelen verilerle doldurun.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Oluşturulan sunumu bir dosyaya kaydedin.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Sonuç](example2_image0.png)

### **Bir Excel Grafiği İçe Aktarma Örneği**

Bu örnekte, önceki örnekte kullanılan Excel çalışma kitabının ilk çalışma sayfasından bir grafik içe aktarıyoruz. Grafik, oluşan sunumda dış çalışma kitabına bağlanacaktır.

İlk olarak, çalışan tablosuna dayanarak Excel çalışma kitabına bir Pasta grafiği ekliyoruz.

![Excel Grafik örneği](example3_image0.png)

```csharp
// Yeni bir PowerPoint sunumu oluşturun.
using Presentation presentation = new Presentation();

// İlk slaytın şekil koleksiyonunu alın.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Çalışma kitabının ilk sayfasından "Chart 1" adlı grafiği içe aktarın ve şekil koleksiyonuna ekleyin.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Oluşturulan sunumu bir dosyaya kaydedin.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Sonuç](example3_image1.png)

### **Tüm Excel Grafiklerini İçe Aktarma Örneği**

Bir Excel çalışma kitabınızın içinde birçok grafik olduğunu ve bunların hepsini bir sunuma içe aktarmanız gerektiğini hayal edin. Her grafik yeni bir slayta yerleştirilmeli.

Aşağıdaki kod, kaynak Excel dosyasındaki tüm çalışma sayfalarını dolaşır, her çalışma sayfasından grafikleri çıkarır ve her bir grafiği boş bir slayt düzeni kullanarak ayrı bir slayta ekler. Oluşturulan sunumda yalnızca grafik verileri gömülür, tüm çalışma kitabı eklenmez.

```csharp
// Çalışan verilerini içeren Excel çalışma kitabını yükleyin.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Yeni bir PowerPoint sunumu oluşturun.
using Presentation presentation = new Presentation();

// Boş slayt düzenini alın.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Excel çalışma kitabında bulunan tüm çalışma sayfalarının adlarını alın.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Çalışma sayfası için grafik indekslerini grafik adlarına eşleyen bir sözlük alın.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Boş düzeni kullanarak yeni bir slayt ekleyin.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Belirtilen grafiği Excel çalışma kitabından slaytın şekil koleksiyonuna içe aktar.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Oluşturulan sunumu bir dosyaya kaydedin.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Bir Excel Tablosu İçe Aktarma Örneği**

Bu örnekte, Excel çalışma sayfasındaki biçimlendirilmiş bir tabloyu doğrudan bir PowerPoint sunumuna içe aktarıyoruz.

Kaynak Excel çalışma sayfası, çalışan verileri içeren biçimlendirilmiş bir tablo içerir:

![Excel Tablo örneği](example4_image0.png)

```csharp
// Yeni bir PowerPoint sunumu oluşturun.
using Presentation presentation = new Presentation();

// İlk slaytın şekil koleksiyonunu alın.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Çalışma kitabının ilk sayfasından tabloyu içe aktarın ve şekil koleksiyonuna ekleyin.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Oluşturulan sunumu bir dosyaya kaydedin.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```
![Sonuç](example4_image1.png)


## **Özet**

Aspose.Slides içinde doğrudan bulunan bu mekanizma, Excel verileriyle çalışma ve sunumları tek bir yerde birleştirir. Görsel grafikler ve Excel tabloları olarak sunulan verilerle slaytlar oluşturmanıza olanak tanır — ek kütüphaneler veya karmaşık entegrasyonlar olmadan.