---
title: Excel Verilerini PowerPoint Sunumlarına Entegre Edin
linktitle: Excel Entegrasyonu
type: docs
weight: 330
url: /tr/nodejs-java/excel-integration/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides ile JavaScript'te Excel çalışma kitaplarından veri okuyun. Sayfaları ve hücreleri yükleyin ve değerleri veri odaklı PowerPoint sunumları oluşturmak için kullanın."
---
## **Giriş**

PowerPoint sunumları, bilgiyi göstermek ve iletmek için güçlü bir yoldur. Çoğu zaman Excel çalışma kitaplarıyla birlikte kullanılır; Excel yapılandırılmış verinin mükemmel bir kaynağı iken PowerPoint bu veriyi izleyiciye görselleştirmede üstün performans gösterir.

Excel ve PowerPoint'i birleştirmenin birçok pratik senaryosu vardır: posta birleştirme, veri tablolarını doldurma, her veri kaydı için bir slayt oluşturma (toplu slayt oluşturma), eğitim materyalleri hazırlama ve birden fazla Excel raporunu tek bir sunuya birleştirme, sadece bunlarla sınırlı değildir.

Şimdiye kadar, bu özelliklerin Aspose.Slides API'siyle uygulanması Aspose.Cells gibi üçüncü taraf çözümlere dayanmayı gerektiriyordu. Bu araçlar güçlü olsa da, yalnızca temel veri entegrasyonu işlevselliğine ihtiyaç duyan kullanıcılar için gereksiz derecede karmaşık ve maliyetli olabilir.

## **Nasıl Çalışır**

Excel verileriyle çalışmayı daha kolay ve akıcı hâle getirmek için Aspose.Slides, Excel çalışma kitaplarından veri okuma ve içeriği bir sunuma içe aktarma için yeni sınıflar ekledi. Bu özellik, sunum iş akışlarında Excel'i veri kaynağı olarak kullanmak isteyen API kullanıcıları için güçlü yeni olasılıklar sunar.

Yeni işlevsellik genel amaçlı veri erişimi için tasarlanmıştır ve Sunum Belge Nesne Modeli (DOM) içine entegre edilmemiştir. Bu, *Excel dosyalarını düzenleme veya kaydetme izni vermez* — tek amacı, çalışma kitaplarını açmak ve içeriklerinde gezinerek hücre verilerini almaktır.

Bu özelliğin çekirdeğinde yeni [ExcelDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/exceldataworkbook/) sınıfı bulunur. Bu sınıf, bir Excel çalışma kitabını yerel bir dosyadan veya bir akıştan yüklemenizi sağlar. Yüklendikten sonra, [getCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/exceldataworkbook/#getCell) metodunun birkaç aşırı yüklemesini kullanarak belirli hücreleri konumlarına göre (ör. satır ve sütun indeksleri veya adlandırılmış aralıklar) alabilirsiniz.

Her [getCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/exceldataworkbook/#getCell) çağrısı, [ExcelDataCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/exceldatacell/) sınıfının bir örneğini döndürür. Bu nesne, Excel çalışma kitabındaki tek bir hücreyi temsil eder ve değerine basit ve sezgisel bir şekilde erişmenizi sağlar.

#### **Excel Grafiği İçe Aktarma**

İşlevselliği genişletmenin bir sonraki adımı [ExcelWorkbookImporter](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/excelworkbookimporter/) sınıfıdır. Bu yardımcı sınıf, bir Excel çalışma kitabından bir sunuma içerik içe aktarma işlevi sağlar. Belirtilen Excel çalışma kitabından seçilen grafiği alıp belirtilen koordinatlarda verilen şekil koleksiyonunun sonuna eklemenize yardımcı olan [addChartFromWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) metodunun birkaç aşırı yüklemesi bulunur.

Kısacası, bu hafif ve doğrudan bir API'dir — birçok geliştiricinin tam bir elektronik tablo işleme kütüphanesinin karmaşası olmadan ihtiyaç duyduğu şey.

## **Kodlayalım**

### **Posta Birleştirme Senaryosu Örneği**

Aşağıdaki örnekte, bir Excel çalışma kitabında depolanan verilere dayanarak birden fazla sunum oluşturacak basit bir Posta Birleştirme senaryosu uygulayacağız.

1. Verileri içeren bir Excel çalışma kitabı

![Excel veri örneği](example1_image0.png)

2. PowerPoint sunum şablonu

![PowerPoint şablon örneği](example1_image1.png)

```js
// Çalışan verileri içeren Excel çalışma kitabını yükle.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Sunum şablonunu yükle.
let templatePresentation = new aspose.slides.Presentation("PresentationTemplate.pptx");

try {
    // Excel satırlarını dolaş (satır 0'daki başlığı hariç).
    for (let rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Her çalışan kaydı için yeni bir sunum oluştur.
        let employeePresentation = new aspose.slides.Presentation();

        try {
            // Varsayılan boş slaytı kaldır.
            employeePresentation.getSlides().removeAt(0);

            // Şablon slaytını yeni sunuma kopyala.
            let slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Hedef şekilden paragrafları al (şekil indeksi 1'in kullanıldığı varsayılır).
            let paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs();

            // Yer tutucuları Excel'den gelen veriyle değiştir.
            let employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            let namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            let department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            let departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            let yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            let yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Kişiselleştirilmiş sunumu ayrı bir dosyaya kaydet.
            employeePresentation.save(`${employeeName} Report.pptx`, aspose.slides.SaveFormat.Pptx);
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

İkinci örnekte, bir Excel tablosundaki verileri kopyalayıp bir PowerPoint slaytında daha görsel olarak çekici bir formatta gösteriyoruz.

Bu örnekte, birinci örnekten aynı Excel çalışma kitabını yeniden kullanıyoruz; bu kitap basit bir çalışan tablosu içeriyor.

```js
// Çalışan verilerini içeren Excel çalışma kitabını yükle.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Yeni bir PowerPoint sunumu oluştur.
let presentation = new aspose.slides.Presentation();

try {
    // İlk slayta bir tablo şekli ekle.
    let table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            java.newArray("double", [200, 200, 200]),
            java.newArray("double", [30, 30, 30, 30, 30])
    );

    // PowerPoint tablosunu Excel çalışma kitabındaki verilerle doldur.
    for (let rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (let columnIndex = 0; columnIndex < 3; columnIndex++) {
            let cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Oluşan sunumu bir dosyaya kaydet.
    presentation.save("Table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Sonuç](example2_image0.png)

### **Excel Grafiği İçe Aktarma Örneği**

Bu örnekte, önceki örnekte kullanılan Excel çalışma kitabının ilk çalışma sayfasından bir grafik içe aktarıyoruz. Grafik, sonuç sunumunda dış çalışma kitabına bağlanacak.

İlk olarak, çalışanlar tablosuna dayalı bir Pasta grafiği ekliyoruz.

![Excel Grafik örneği](example3_image0.png)

```js
// Yeni bir PowerPoint sunumu oluştur.
let presentation = new aspose.slides.Presentation();
try {
    // İlk slayttaki şekil koleksiyonunu al.
    let shapes = presentation.getSlides().get_Item(0).getShapes();

    // Çalışma kitabının ilk sayfasından "Chart 1" adlı grafiği içe aktar ve şekil koleksiyonuna ekle.
    aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Oluşan sunumu bir dosyaya kaydet.
    presentation.save("Chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Sonuç](example3_image1.png)

### **Tüm Excel Grafiklerini İçe Aktarma Örneği**

Bir Excel çalışma kitabında bir sürü grafik olduğunu ve hepsini bir sunuma içe aktarmanız gerektiğini hayal edin. Her grafik yeni bir slayta yerleştirilmeli.

Aşağıdaki kod, kaynak Excel dosyasındaki tüm çalışma sayfalarını döner, her sayfadan grafikleri çıkarır ve boş bir slayt düzeni kullanarak her grafiği ayrı bir slayta ekler. Sonuç sunumda yalnızca grafik verileri yer alır, bütün çalışma kitabı eklenmez.

```js
// Çalışan verilerini içeren Excel çalışma kitabını yükle.
let workbook = new aspose.slides.ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Yeni bir PowerPoint sunumu oluştur.
let presentation = new aspose.slides.Presentation();
try {
    // Boş slayt düzenini al.
    let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

    // Excel çalışma kitabında bulunan tüm çalışma sayfalarının adlarını al.
    let worksheetNames = workbook.getWorksheetNames().iterator();

    while (worksheetNames.hasNext()) {
        let name = worksheetNames.next();
        // Çalışma sayfası için grafik indekslerini grafik adlarına eşleyen bir harita al.
        let worksheetCharts = workbook.getChartsFromWorksheet(name).iterator();

        while (worksheetCharts.hasNext()) {
            let chart = worksheetCharts.next();
            // Boş düzeni kullanarak yeni bir slayt ekle.
            let slide = presentation.getSlides().addEmptySlide(layoutSlide);

            // Belirtilen grafiği Excel çalışma kitabından slaydın şekil koleksiyonuna içe aktar.
            aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Oluşan sunumu bir dosyaya kaydet.
    presentation.save("Charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Özet**

Bu mekanizma, doğrudan Aspose.Slides içinde mevcuttur ve Excel verileriyle sunumları tek bir yerde birleştirir. Görsel grafikler ve Excel tabloları olarak sunulan verilerle slaytlar oluşturmanızı sağlar — ek kütüphanelere veya karmaşık entegrasyonlara gerek kalmadan.