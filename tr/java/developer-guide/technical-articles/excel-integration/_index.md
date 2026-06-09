---
title: Excel Verilerini PowerPoint Sunumlarına Entegre Et
linktitle: Excel Entegrasyonu
type: docs
weight: 330
url: /tr/java/excel-integration/
keywords:
- Excel
- çalışma kitabı
- Excel oku
- Excel'i entegre et
- veri kaynağı
- posta birleştirme
- tablo içe aktar
- Excel'den PowerPoint'e
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides içinde ExcelDataWorkbook API'si kullanarak Excel çalışma kitaplarından veri okuyun. Sayfaları ve hücreleri yükleyin ve değerleri veri odaklı PowerPoint sunumları oluşturmak için kullanın."
---
## **Giriş**

PowerPoint sunumları, bilgiyi görüntülemek ve iletmek için güçlü bir yoldur. Genellikle Excel çalışma kitaplarıyla birlikte kullanılır; Excel yapılandırılmış veri kaynağı olarak mükemmel bir hizmet verirken, PowerPoint bu verileri bir izleyiciye görselleştirmede üstünlük sağlar.

Excel ve PowerPoint'i birleştirmenin önemli olduğu birçok pratik senaryo vardır: posta birleştirme, veri tablolarını doldurma, her veri kaydı için bir slayt oluşturma (toplu slayt oluşturma), eğitim materyalleri hazırlama ve birden fazla Excel raporunu tek bir sunumda birleştirme gibi.

Şimdiye kadar, bu özellikleri Aspose.Slides API'siyle uygulamak, Aspose.Cells gibi üçüncü taraf çözümlere dayanmayı gerektiriyordu. Bu araçlar sağlam olsa da, yalnızca temel veri entegrasyonu işlevselliğine ihtiyaç duyan kullanıcılar için gereksiz derecede karmaşık ve maliyetli olabilir.

## **Nasıl Çalışır**

Excel verileriyle çalışmayı daha kolay ve akıcı hâle getirmek için Aspose.Slides, Excel çalışma kitaplarından veri okuma ve içeriği bir sunuma içe aktarma için yeni sınıflar tanıttı. Bu özellik, sunum iş akışları içinde Excel'i bir veri kaynağı olarak kullanmak isteyen API kullanıcıları için güçlü yeni olasılıklar açar.

Yeni işlevsellik, genel amaçlı veri erişimi için tasarlanmıştır ve Sunum Belge Nesne Modeli (DOM) içine entegre edilmemiştir. Bu, *Excel dosyalarını düzenlemenize veya kaydetmenize izin vermez* — tek amacı, çalışma kitaplarını açmak ve içeriklerinde gezinerek hücre verilerini almaktır.

Bu özelliğin çekirdeğinde yeni [ExcelDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/exceldataworkbook/) sınıfı bulunur. Bu sınıf, bir Excel çalışma kitabını yerel bir dosyadan veya akıştan yüklemenizi sağlar. Yüklendikten sonra, konumlarına (ör. satır ve sütun dizinleri veya adlandırılmış aralıklar) göre belirli hücreleri almanıza olanak tanıyan [getCell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) metodunun çeşitli aşırı yüklemelerini sunar.

Her [getCell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) çağrısı, [ExcelDataCell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/exceldatacell/) sınıfının bir örneğini döndürür. Bu nesne, Excel çalışma kitabındaki tek bir hücreyi temsil eder ve değerine basit ve sezgisel bir şekilde erişmenizi sağlar.

#### **Excel Grafik İçe Aktarma**

İşlevselliği genişletmenin bir sonraki adımı, [ExcelWorkbookImporter](https://reference.aspose.com/slides/tr/java/com.aspose.slides/excelworkbookimporter/) sınıfıdır. Bu yardımcı sınıf, bir Excel çalışma kitabından içeriği bir sunuma aktarma işlevselliği sağlar. Belirtilen Excel çalışma kitabından seçilen grafiği alıp verilen şekil koleksiyonunun sonuna belirtilen koordinatlarda eklemenize yardımcı olan [addChartFromWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) metodunun çeşitli aşırı yüklemelerini içerir.

Kısacası, bu, tam bir elektronik tablo işleme kütüphanesinin getirdiği yük olmadan, birçok geliştiricinin ihtiyaç duyduğu Excel verilerini okuma için hafif ve doğrudan bir API'dir.

## **Kodlayalım**

### **Posta Birleştirme Senaryosu Örneği**

Aşağıdaki örnekte, bir Excel çalışma kitabında depolanan verilere dayanarak birden çok sunum üreten basit bir Posta Birleştirme senaryosu uygulayacağız.

Başlamak için iki şeye ihtiyacımız var:
1. Verileri içeren bir Excel çalışma kitabı

![Excel veri örneği](example1_image0.png)

2. PowerPoint sunum şablonu

![PowerPoint şablon örneği](example1_image1.png)

```java
// Çalışan verileriyle Excel çalışma kitabını yükle.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Sunum şablonunu yükle.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Excel satırları üzerinde döngü (satır 0'daki başlık hariç).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Her çalışan kaydı için yeni bir sunum oluştur.
        Presentation employeePresentation = new Presentation();

        try {
            // Varsayılan boş slaytı kaldır.
            employeePresentation.getSlides().removeAt(0);

            // Şablon slaytını yeni sunuma klonla.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Hedef şekilden paragrafları al (şekil indeksi 1'in kullanıldığı varsayılır).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // Yer tutucuları Excel'den gelen verilerle değiştir.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Kişiselleştirilmiş sunumu ayrı bir dosyaya kaydet.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Sonuç](example1_image2.png)

### **Excel Tablo Örneği**

İkinci örnekte, bir Excel tablosundaki verileri kopyalayıp daha görsel açıdan çekici bir formatta bir PowerPoint slaytına gösteriyoruz.

Bu örnekte, ilk örnekten aynı Excel çalışma kitabını yeniden kullanıyoruz; bu kitap basit bir çalışan tablosu içerir.

```java
// Çalışan verilerini içeren Excel çalışma kitabını yükle.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Yeni bir PowerPoint sunumu oluştur.
Presentation presentation = new Presentation();

try {
    // İlk slayta bir tablo şekli ekle.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Excel çalışma kitabından veriyle PowerPoint tablosunu doldur.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Oluşturulan sunumu bir dosyaya kaydet.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Sonuç](example2_image0.png)

### **Excel Grafik İçe Aktarma Örneği**

Bu örnekte, önceki örnekte kullanılan Excel çalışma kitabının ilk çalışma sayfasından bir grafiği içe aktarıyoruz. Grafik, sonuçtaki sunumda dış çalışma kitabına bağlanacaktır.

İlk olarak, çalışan tablosuna dayalı bir Pasta grafiği ekliyoruz.

![Excel Grafik örneği](example3_image0.png)

```java
// Yeni bir PowerPoint sunumu oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaydın şekil koleksiyonunu al.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Çalışma kitabının ilk sayfasından "Chart 1" adlı grafiği içe aktar ve şekil koleksiyonuna ekle.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Oluşturulan sunumu bir dosyaya kaydet.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Sonuç](example3_image1.png)

### **Tüm Excel Grafiklerini İçe Aktarma Örneği**

Bir Excel çalışma kitabınızın içinde çok sayıda grafik olduğunu ve bunların tümünü bir sunuma içe aktarmanız gerektiğini hayal edin. Her grafik yeni bir slayta yerleştirilecektir.

Aşağıdaki kod, kaynak Excel dosyasındaki tüm çalışma sayfalarını döngüye alır, her çalışma sayfasından grafikleri çıkarır ve her grafiği boş bir slayt düzeni kullanarak ayrı bir slayta ekler. Oluşturulan sunumda yalnızca grafik verileri gömülü olur, tüm çalışma kitabı eklenmez.

```java
// Çalışan verilerini içeren Excel çalışma kitabını yükle.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Yeni bir PowerPoint sunumu oluştur.
Presentation presentation = new Presentation();
try {
    // Boş slayt düzenini al.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Excel çalışma kitabında bulunan tüm çalışma sayfalarının adlarını al.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // Çalışma sayfası için grafik indekslerini grafik adlarına eşleyen bir harita al.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // Boş düzeni kullanarak yeni bir slayt ekle.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // Belirtilen grafiği Excel çalışma kitabından slaytın şekil koleksiyonuna içe aktar.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Oluşturulan sunumu bir dosyaya kaydet.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Özet**

Aspose.Slides içinde doğrudan bulunan bu mekanizma, Excel verileriyle ve sunumlarla tek bir yerden çalışmayı birleştirir. Ek kütüphaneler veya karmaşık entegrasyonlar olmadan, Excel tabloları olarak sunulan veriler ve görsel grafikler içeren slaytlar oluşturmanıza olanak tanır.