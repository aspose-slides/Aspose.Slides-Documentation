---
title: Excel Grafiklerini Oluşturun ve Sunumlarda OLE Nesneleri Olarak Yerleştirin
type: docs
weight: 30
url: /tr/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel grafiği
- grafiği yerleştir
- OLE nesnesi
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Java üzerinden PHP için Aspose.Cells ile bir Excel grafiği oluşturun ve Java üzerinden PHP için Aspose.Slides ile çalışma kitabını bir PowerPoint sunumuna yerleştirin, grafik önizlemesi dahil."
---
## **Genel Bakış**

Bu makale, Java üzerinden PHP için Aspose.Cells ile bir Excel sütun grafiği oluşturmayı ve bu çalışma kitabını Java üzerinden PHP için Aspose.Slides ile bir PowerPoint sunumuna yerleştirmeyi gösterir. Yerleştirilen çalışma kitabı hem kaynak veriyi hem de grafiği içerir. Ayrı bir PNG önizlemesi, OLE nesnesi etkinleştirilmeden önce grafiği slaytta gösterir.

Sonuç, yerel bir PowerPoint grafiği değil, yerleştirilmiş bir Excel nesnesidir. OLE üzerinden çalışma kitabını düzenlemek, OLE etkinleştirmesini destekleyen bir masaüstü uygulaması ve uyumlu bir Excel kurulumunu gerektirir.

## **Önkoşullar**

Aspose.Cells for PHP via Java ve Aspose.Slides for PHP via Java'ı aynı PHP/Java Bridge örneğiyle yapılandırın. Her iki PHP sarmalayıcısını yükleyin ve her iki ürünün Java kütüphanelerini köprüye erişilebilir hâle getirin. Microsoft Office, bu kütüphanelerle sunumu oluşturmak için gerekli değildir.

Hiçbir girdi dosyasına ihtiyaç yoktur: örnek, veri ve grafiği bellek içinde oluşturur, ardından `OutputChart.pptx` dosyasını geçerli çalışma dizinine yazar. Değerlendirme modunun dışındayken her iki ürün için de lisansları uygulayın.

## **Gömme Nasıl Çalışır**

1. Veri çalışma sayfası ve grafik sayfası içeren bir çalışma kitabı oluşturun.  
1. Grafik sayfasını etkinleştirerek çalışma kitabının grafik üzerinde açılmasını sağlayın.  
1. Çalışma kitabının OLE görüntüleme aralığını ayarlayın ve grafiği PNG olarak render edin.  
1. Çalışma kitabını bellek içinde XLSX olarak kaydedin ve bu baytları bir slayta yerleştirin.  
1. PNG'yi OLE nesnesinin önizlemesi olarak atayın ve sunumu PPTX olarak kaydedin.

Çalışma kitabının görüntüleme aralığı ile slayttaki çerçeve farklı görevler üstlenir. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) sıfır temelli başlangıç/bitiş satır ve sütun indekslerini alır. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) ise üst satır, sol sütun, alt satır ve sağ sütunu alır. Örnek, alt sağ sınır olarak satır indeksi 55 ve sütun indeksi 25'i kullanır; bu değerler düzen seçimleridir, veri satır veya sütun sayısını göstermez.

Slayt çerçevesi nokta birimini kullanır. Örnek, çerçeveyi slayt içinde sığdırır ve PNG'nin en‑boy oranını koruyarak ortalar; önizlemeyi slaytı dolduracak şekilde uzatmaz.

## **Grafiği Oluşturma ve Yerleştirme**

Aşağıdaki tam örnek, `DataSheet`i dört satır ve beş sütun değerle doldurur. Her satır bir grafik serisi olur. `ChartSheet`, çalışma kitabı kaydedilmeden önce aktif sayfa olarak seçilir.

Çalışma kitabı, [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) öğesine geçirilen `xlsx` uzantısıyla eşleşecek şekilde açıkça XLSX olarak kaydedilir. Java sayısal sonuçları, PHP aritmetik işlemi yapmadan önce `java_values` ile dönüştürülür, iken ikili veri Java bayt dizilerinde kalır. PNG, ara bir bitmap dönüşümü olmadan doğrudan baytlarından yüklenir. [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) aracılığıyla atanması, varsayılan OLE yer tutucusunu değiştirir.

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // PNG ve XLSX'i Slides'a aktarırken Java bayt dizileri olarak tutun.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // Önizlemeyi, en-boy oranını koruyarak sığdır ve ortala.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Beklenen Sonuç**

`OutputChart.pptx`, içine yerleştirilmiş bir Excel çalışma kitabı ve bir grafik önizlemesi içeren bir slayt içerir. Çalışma kitabı orijinal verileri ve dört serili bir sütun grafiğini barındırır. Önizleme slayt üzerinde ortalanır ve oranlarını korur.

![Yerleştirilmiş bir çalışma kitabının önizlemesi olarak gösterilen Excel sütun grafiği](excel-chart-ole-preview.png)

Excel'in yüklü olduğu uyumlu bir masaüstü PowerPoint ortamında, nesneyi çift tıklayarak yerleştirilmiş çalışma kitabını etkinleştirebilir ve düzenleyebilirsiniz. Etkinleştirme ve düzenleme, host uygulamanın OLE desteği ve güvenlik ayarlarına bağlıdır.

## **SSS**

**Önizleme görseli neden gereklidir?**

Yerleştirilmiş çalışma kitabı ve slayt önizlemesi ayrı içeriklerdir. Slaytın varsayılan "EMBEDDED OLE OBJECT" yer tutucusu yerine grafiği göstermesi için bir grafik resmi sağlayın. Bkz. [OleObjectFrame Eklerken Nesne Önizleme Sorunu](/slides/tr/php-java/object-preview-issue-when-adding-oleobjectframe/).

**Kod içinde çalışma kitabını değiştirdiğimde önizleme otomatik olarak güncellenir mi?**

Önizlemeyi bir anlık görüntü olarak düşünün. Çalışma kitabı verileri programlı olarak güncellendiğinde, grafiği yeniden oluşturun ve önizlemeyi ve yerleştirilmiş çalışma kitabı verilerini değiştirin.

**XLSX yerine XLS kullanabilir miyim?**

Evet. Çalışma kitabını XLS formatında kaydedin ve embed edilen veri uzantısı olarak `xls` kullanın. Uzantı gerçek çalışma kitabı formatıyla eşleşmelidir; yalnızca uzantıyı değiştirmek veri dönüşümünü sağlamaz.

**Nesne etkinleştirme sonrası boyutunu neden değiştirebilir?**

Host uygulama, çalışma kitabını etkinleştirdiğinde OLE nesnesinin sunumunu güncelleyebilir. Çalışma kitabının OLE görüntüleme aralığı ve slayt çerçevesi boyutları her ikisi de önemlidir. Bkz. [PPTX'te Grafik Yeniden Boyutlandırma için Çalışan Çözüm](/slides/tr/java/working-solution-for-chart-resizing-in-pptx/).

## **İlgili Bölümler**

- [PPTX'te Grafik Yeniden Boyutlandırma için Çalışan Çözüm](/slides/tr/java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame Eklerken Nesne Önizleme Sorunu](/slides/tr/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [OLE Nesnelerini Yönet](/slides/tr/php-java/manage-ole/)