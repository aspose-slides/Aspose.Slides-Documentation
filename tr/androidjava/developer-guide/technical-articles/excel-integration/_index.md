---
title: Excel Verilerini PowerPoint Sunumlarına Entegre Et
linktitle: Excel Entegrasyonu
type: docs
weight: 330
url: /tr/androidjava/excel-integration/
keywords:
- Excel
- çalışma kitabı
- Excel'i oku
- Excel'i entegre et
- veri kaynağı
- posta birleştirme
- tablo içe aktar
- Excel'i PowerPoint'e
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides'ta ExcelDataWorkbook API'sini kullanarak Excel çalışma kitaplarından veri okuyun. Sayfaları ve hücreleri yükleyin ve değerleri veri odaklı PowerPoint sunumları oluşturmak için kullanın."
---
## **Giriş**

PowerPoint sunumları, bilgiyi gösterme ve iletişim kurma konusunda güçlü bir yoldur. Genellikle Excel çalışma kitaplarıyla birlikte kullanılır; Excel yapılandırılmış veri için mükemmel bir kaynak sağlar ve PowerPoint bu veriyi izleyiciler için görselleştirmede başarılıdır.

Excel ve PowerPoint’i birleştirmenin gerekli olduğu pek çok pratik senaryo vardır: posta birleştirme, veri tablolarını doldurma, her veri kaydı için bir slayt oluşturma (toplu slayt üretimi), eğitim materyalleri hazırlama ve birden çok Excel raporunu tek bir sunumda birleştirme gibi.

Şimdiye kadar, bu özellikleri Aspose.Slides API’siyle uygulamak, Aspose.Cells gibi üçüncü‑taraf çözümlerine dayanmayı gerektiriyordu. Bu araçlar sağlam olsa da, yalnızca temel veri entegrasyonu işlevine ihtiyacı olan kullanıcılar için aşırı karmaşık ve maliyetli olabiliyor.

## **Nasıl Çalışır**

Excel verileriyle çalışmayı daha kolay ve akıcı hale getirmek için Aspose.Slides, Excel çalışma kitaplarından veri okuma ve içeriği bir sunuma içe aktarma için yeni sınıflar tanıttı. Bu özellik, sunum iş akışları içinde Excel’i bir veri kaynağı olarak kullanmak isteyen API kullanıcıları için güçlü yeni olanaklar sunuyor.

Yeni işlevsellik, genel amaçlı veri erişimi için tasarlanmış olup, Presentation Document Object Model (DOM) ile bütünleşik değildir. Bu, *Excel dosyalarını düzenleme veya kaydetme* imkanı sağlamadığı anlamına gelir — tek amacı, çalışma kitaplarını açmak ve içeriğinde gezinerek hücre verilerini almaktır.

Bu özelliğin çekirdeğinde yeni [ExcelDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/exceldataworkbook/) sınıfı bulunur. Bu sınıf, bir Excel çalışma kitabını yerel bir dosyadan veya akıştan yüklemenizi sağlar. Yüklendikten sonra, [getCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) yönteminin çeşitli aşırı yüklemelerini kullanarak belirli hücreleri konumları (ör. satır ve sütun indisleri veya adlandırılmış aralıklar) ile alabilirsiniz.

[getCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) çağrısı, [ExcelDataCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/exceldatacell/) sınıfının bir örneğini döndürür. Bu nesne, Excel çalışma kitabındaki tek bir hücreyi temsil eder ve değerine basit ve sezgisel bir şekilde erişmenizi sağlar.

#### **Bir Excel Grafiği İçe Aktarma**

İşlevselliği genişletmenin bir sonraki adımı, [ExcelWorkbookImporter](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/excelworkbookimporter/) sınıfıdır. Bu yardımcı sınıf, bir Excel çalışma kitabından içeriği bir sunuma içe aktarma işlevi sunar. [addChartFromWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) yönteminin çeşitli aşırı yüklemeleri, belirtilen Excel çalışma kitabından seçilen grafiği alıp, verilen şekil koleksiyonunun sonuna belirli koordinatlarda eklemenize yardımcı olur.

Kısacası, bu hafif ve doğrudan API, Excel verilerini okumak için tam bir elektronik tablo işleme kütüphanesinin getirdiği yük olmadan tam ihtiyacınızı karşılar.

## **Kod Yazalım**

### **Posta Birleştirme Senaryosu Örneği**

Aşağıdaki örnekte, bir Excel çalışma kitabında depolanan verilere dayanarak birden çok sunum oluşturarak basit bir Posta Birleştirme senaryosu gerçekleştireceğiz.

Başlamak için iki şeye ihtiyacımız var:
1. Verileri içeren bir Excel çalışma kitabı

![Excel veri örneği](example1_image0.png)

2. PowerPoint sunum şablonu

![PowerPoint şablon örneği](example1_image1.png)

```java
// Çalışan verileri içeren Excel çalışma kitabını yükle.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Sunum şablonunu yükle.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Excel satırları üzerinde döngü (satır 0'daki başlığı hariç).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Her çalışan kaydı için yeni bir sunum oluştur.
        Presentation employeePresentation = new Presentation();

        try {
            // Varsayılan boş slaytı kaldır.
            employeePresentation.getSlides().removeAt(0);

            // Şablon slaytı yeni sunuma kopyala.
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

İkinci örnekte, bir Excel tablosundaki verileri kopyalayıp daha görsel açıdan çekici bir biçimde bir PowerPoint slaytında gösteriyoruz.

Bu örnekte, ilk örnekteki aynı Excel çalışma kitabını yeniden kullanıyoruz; içinde basit bir çalışan tablosu bulunuyor.

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

    // PowerPoint tablosunu Excel çalışma kitabındaki verilerle doldur.
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

### **Excel Grafiği İçe Aktarma Örneği**

Bu örnekte, önceki örnekte kullanılan Excel çalışma kitabının birinci çalışma sayfasından bir grafiği içe aktarıyoruz. Grafik, sonuç sunumda dış çalışma kitabına bağlanacak.

Öncelikle, çalışan tablosuna dayanarak Excel çalışma kitabına bir Pasta grafiği ekliyoruz.

![Excel grafik örneği](example3_image0.png)

```java
// Yeni bir PowerPoint sunumu oluştur.
Presentation presentation = new Presentation();
try {
    // İlk slaydın şekil koleksiyonunu al.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Çalışma kitabının ilk sayfasındaki "Chart 1" adlı grafiği içe aktar ve şekil koleksiyonuna ekle.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Oluşturulan sunumu bir dosyaya kaydet.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Sonuç](example3_image1.png)

### **Tüm Excel Grafiklerini İçe Aktarma Örneği**

Bir Excel çalışma kitabının içinde çok sayıda grafik olduğunu ve bunların hepsini bir sunuma içe aktarmanız gerektiğini hayal edin. Her grafik yeni bir slayta yerleştirilecek.

Aşağıdaki kod, kaynak Excel dosyasındaki tüm çalışma sayfalarını dolaşır, her birinden grafikleri çıkarır ve her grafiği boş bir slayt düzeni kullanarak ayrı bir slayta ekler. Oluşturulan sunumda yalnızca grafik verileri gömülür; bütün çalışma kitabı eklenmez.

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
        // Çalışma sayfası için grafik dizinlerini grafik adlarına eşleyen bir harita al.
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

Aspose.Slides içinde doğrudan mevcut bu mekanizma, Excel verileriyle ve sunumlarla tek bir yerden çalışmayı birleştirir. Görsel grafikler ve Excel tabloları olarak sunulan verilerle slaytlar oluşturmanızı sağlar — ek kütüphanelere veya karmaşık entegrasyonlara gerek kalmadan.