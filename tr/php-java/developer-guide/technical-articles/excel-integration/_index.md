---
title: Excel Verilerini PowerPoint Sunumlarına Entegre Et
linktitle: Excel Entegrasyonu
type: docs
weight: 330
url: /tr/php-java/excel-integration/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak Excel çalışma kitaplarından veri okuyun. Sayfaları ve hücreleri yükleyin ve değerleri veri odaklı PowerPoint sunumları oluşturmak için kullanın."
---
## **Giriş**

PowerPoint sunumları bilgiyi görüntülemek ve iletmek için güçlü bir yöntemdir. Genellikle Excel çalışma kitaplarıyla birlikte kullanılır; Excel yapılandırılmış verilerin mükemmel bir kaynağı olurken PowerPoint, bu verileri izleyiciye görselleştirir.

Excel ve PowerPoint'in birleştirilmesinin hayati olduğu birçok pratik senaryo vardır: posta birleştirme, veri tablolarını doldurma, her veri kaydı için bir slayt oluşturma (toplu slayt üretimi), eğitim materyalleri hazırlama ve birden çok Excel raporunu tek bir sunumda birleştirme gibi.

Şimdiye kadar, bu özellikleri Aspose.Slides API'siyle uygulamak, Aspose.Cells gibi üçüncü taraf çözümlerine dayanmayı gerektiriyordu. Bu araçlar güçlü olsa da, yalnızca temel veri entegrasyonu işlevselliğine ihtiyaç duyan kullanıcılar için aşırı karmaşık ve maliyetli olabilir.

## **Nasıl Çalışır**

Excel verileriyle çalışmayı daha kolay ve sorunsuz hale getirmek için Aspose.Slides, Excel çalışma kitaplarından veri okumak ve içeriği bir sunuma aktarmak için yeni sınıflar ekledi. Bu özellik, sunum iş akışlarında Excel'i veri kaynağı olarak kullanmak isteyen API kullanıcıları için güçlü yeni olanaklar sunar.

Yeni işlevsellik, genel amaçlı veri erişimi için tasarlanmıştır ve Sunum Belge Nesne Modeli (DOM) ile bütünleşmez. Bu, *Excel dosyalarını düzenleme veya kaydetme imkanı sağlamadığı* anlamına gelir — tek amacı, çalışma kitaplarını açmak ve içeriklerinde gezerek hücre verilerini almaktır.

Bu özelliğin çekirdeğinde yeni [ExcelDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/exceldataworkbook/) sınıfı bulunur. Bu sınıf, bir Excel çalışma kitabını yerel bir dosyadan veya akıştan yüklemenizi sağlar. Yüklendikten sonra, [getCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/exceldataworkbook/#getCell) metodunun çeşitli aşırı yüklemelerini sunar; bu metodla konumlarına göre (ör. satır ve sütun indisleri ya da adlandırılmış aralıklar) belirli hücreleri alabilirsiniz.

[getCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/exceldataworkbook/#getCell) metodunun her çağrısı, [ExcelDataCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/exceldatacell/) sınıfının bir örneğini döndürür. Bu nesne, Excel çalışma kitabındaki tek bir hücreyi temsil eder ve değerine basit ve sezgisel bir şekilde erişmenizi sağlar.

#### **Bir Excel Grafik İçe Aktarın**

Fonksiyonu genişletmek için bir sonraki adım, [ExcelWorkbookImporter](https://reference.aspose.com/slides/tr/php-java/aspose.slides/excelworkbookimporter/) sınıfıdır. Bu yardımcı sınıf, bir Excel çalışma kitabından içeriği bir sunuma aktarma işlevi sağlar. [addChartFromWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) metodunun çeşitli aşırı yüklemelerini içerir; bu metodlarla belirtilen Excel çalışma kitabından seçilen grafiği alıp, verilen şekil koleksiyonunun sonuna belirtilen koordinatlarda ekleyebilirsiniz.

Kısacası, Excel verilerini okumak için hafif ve basit bir API'dir — tam bir elektronik tablo işleme kütüphanesinin getirdiği ek yük olmadan birçok geliştiricinin ihtiyacı olan şey.

## **Kodlayalım**

### **Posta Birleştirme Senaryosu Örneği**

Aşağıdaki örnekte, bir Excel çalışma kitabında depolanan verilere dayanarak birden çok sunum oluşturarak basit bir Posta Birleştirme senaryosu uygulayacağız.

Başlamak için iki şeye ihtiyacımız var:
1. Verileri içeren bir Excel çalışma kitabı

![Excel veri örneği](example1_image0.png)

2. PowerPoint sunum şablonu

![PowerPoint şablon örneği](example1_image1.png)

```php
// Çalışan verileri içeren Excel çalışma kitabını yükle.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Sunum şablonunu yükle.
$templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Excel satırları içinde döngü (satır 0'daki başlığı hariç).
    for ($rowIndex = 1; $rowIndex <= 4; $rowIndex++) {

        // Her çalışan kaydı için yeni bir sunum oluştur.
        $employeePresentation = new Presentation();

        try {
            // Varsayılan boş slaytı kaldır.
            $employeePresentation->getSlides()->removeAt(0);

            // Şablon slaytı yeni sunuma kopyala.
            $slide = $employeePresentation->getSlides()->addClone($templatePresentation->getSlides()->get_Item(0));

            // Hedef şekilden paragrafları al (şekil indeksinin 1 olduğu varsayılır).
            $paragraphs = $slide->getShapes()->get_Item(1)->getTextFrame()->getParagraphs();

            // Yer tutucuları Excel verileriyle değiştir.
            $employeeName = $workbook->getCell($worksheetIndex, $rowIndex, 0)->getValue()->toString();
            $namePortion = $paragraphs->get_Item(0)->getPortions()->get_Item(0);
            $namePortion->setText($namePortion->getText()->replace("{{EmployeeName}}", $employeeName));

            $department = $workbook->getCell($worksheetIndex, $rowIndex, 1)->getValue()->toString();
            $departmentPortion = $paragraphs->get_Item(1)->getPortions()->get_Item(0);
            $departmentPortion->setText($departmentPortion->getText()->replace("{{Department}}", $department));

            $yearsOfService = $workbook->getCell($worksheetIndex, $rowIndex, 2)->getValue()->toString();
            $yearsPortion = $paragraphs->get_Item(2)->getPortions()->get_Item(0);
            $yearsPortion->setText($yearsPortion->getText()->replace("{{YearsOfService}}", $yearsOfService));

            // Kişiselleştirilmiş sunumu ayrı bir dosyaya kaydet.
            $employeePresentation->save(sprintf("%s Report.pptx", $employeeName), SaveFormat::Pptx);
        } finally {
            $employeePresentation->dispose();
        }
    }
} finally {
    $templatePresentation->dispose();
}
```

![Sonuç](example1_image2.png)

### **Excel Tablo Örneği**

İkinci örnekte, bir Excel tablosundan verileri kopyalayıp daha görsel açıdan çekici bir formatta PowerPoint slaytında gösteriyoruz.

Bu örnekte, bir çalışan tablosu içeren ilk örnekteki aynı Excel çalışma kitabını yeniden kullanıyoruz.

```php
// Çalışan verilerini içeren Excel çalışma kitabını yükle.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Yeni bir PowerPoint sunumu oluştur.
$presentation = new Presentation();

try {
    // İlk slayta bir tablo şekli ekle.
    $table = $presentation->getSlides()->get_Item(0)->getShapes()->addTable(
            50, 200,
            array(200, 200, 200),
            array(30, 30, 30, 30, 30)
    );

    // PowerPoint tablosunu Excel çalışma kitabındaki verilerle doldur.
    for ($rowIndex = 0; $rowIndex < 5; $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < 3; $columnIndex++) {
            $cellValue = $workbook->getCell($worksheetIndex, $rowIndex, $columnIndex)->getValue()->toString();
            $table->getColumns()->get_Item($columnIndex)->get_Item($rowIndex)->getTextFrame()->setText($cellValue);
        }
    }

    // Oluşan sunumu bir dosyaya kaydet.
    $presentation->save("Table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Sonuç](example2_image0.png)

### **Bir Excel Grafik İçe Aktarma Örneği**

Bu örnekte, önceki örnekte kullanılan Excel çalışma kitabının ilk çalışma sayfasından bir grafik içe aktarıyoruz. Grafik, oluşan sunumda dış çalışma kitabına bağlanacaktır.

İlk olarak, çalışan tablosuna dayalı bir Pasta grafik ekliyoruz.

![Excel Grafik örneği](example3_image0.png)

```php
// Yeni bir PowerPoint sunumu oluştur.
$presentation = new Presentation();
try {
    // İlk slaytın şekiller koleksiyonunu al.
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    // Çalışma kitabının ilk sayfasından "Chart 1" adlı grafiği içe aktar ve şekiller koleksiyonuna ekle.
    ExcelWorkbookImporter::addChartFromWorkbook($shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Oluşan sunumu bir dosyaya kaydet.
    $presentation->save("Chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Sonuç](example3_image1.png)

### **Tüm Excel Grafiklerini İçe Aktarma Örneği**

Diyelim ki içinde pek çok grafik bulunan bir Excel çalışma kitabınız var ve hepsini bir sunuma aktarmanız gerekiyor. Her bir grafik yeni bir slayta yerleştirilmeli.

Aşağıdaki kod, kaynak Excel dosyasındaki tüm çalışma sayfalarını dolaşır, her sayfadan grafikleri çıkarır ve her bir grafiği boş bir slayt düzeni kullanarak ayrı bir slayta ekler. Oluşan sunumda sadece grafik verileri gömülür, tüm çalışma kitabı eklenmez.

```php
// Çalışan verilerini içeren Excel çalışma kitabını yükle.
$workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Yeni bir PowerPoint sunumu oluştur.
$presentation = new Presentation();
try {
    // Boş slayt düzenini al.
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Excel çalışma kitabında bulunan tüm çalışma sayfalarının adlarını al.
    $worksheetNames = $workbook->getWorksheetNames()->iterator();

    while (java_values($worksheetNames->hasNext())) {
        $name = $worksheetNames->next();
        // Çalışma sayfası için grafik indekslerini grafik adlarına eşleyen bir harita al.
        $worksheetCharts = $workbook->getChartsFromWorksheet($name)->iterator();

        while (java_values($worksheetCharts->hasNext())) {
            $chart = $worksheetCharts->next();
            // Boş düzeni kullanarak yeni bir slayt ekle.
            $slide = $presentation->getSlides()->addEmptySlide($blankLayout);

            // Belirtilen grafiği Excel çalışma kitabından slaytın şekil koleksiyonuna içe aktar.
            ExcelWorkbookImporter::addChartFromWorkbook(
                    $slide->getShapes(), 10, 10, $workbook, $name, $chart->getKey(), false);
        }
    }

    // Oluşan sunumu bir dosyaya kaydet.
    $presentation->save("Charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Özet**

Aspose.Slides içinde doğrudan kullanılabilen bu mekanizma, Excel verileriyle ve sunumlarla tek bir yerde çalışmayı birleştirir. Görsel grafikler ve Excel tabloları şeklinde sunulan verilerle slaytlar oluşturmanıza olanak tanır — ek kütüphanelere veya karmaşık entegrasyonlara gerek kalmadan.