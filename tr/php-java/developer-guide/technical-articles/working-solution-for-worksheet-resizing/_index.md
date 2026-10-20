---
title: Çalışma Sayfası Yeniden Boyutlandırma İçin Çözüm
type: docs
weight: 20
url: /tr/php-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- önizleme resmi
- görüntü yeniden boyutlandırma
- Excel
- çalışma sayfası
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Sunumlarda Excel çalışma sayfası OLE yeniden boyutlandırmasını düzeltin: nesne çerçevelerini tutarlı tutmak için iki yöntem—çerçeveyi ya da sayfayı ölçeklendirin—PPT ve PPTX formatlarında."
---
{{% alert color="info" title="Note" %}}
Excel çalışma sayfalarının Aspose bileşenleri kullanılarak PowerPoint sunumuna OLE nesneleri olarak gömülmesi, ilk etkinleştirmelerinden sonra beklenmedik şekilde yeniden boyutlandırılmasına neden olabilir. Bu davranış, OLE nesnesinin etkinleştirme öncesi ve sonrası arasında belirgin bir görsel fark yaratır. Bu makale sorunu açıklar ve iki çözüm yolunu tanımlar.
{{% /alert %}}

## **Arka Plan**

Makalenin [OLE'yi Yönet](/slides/tr/php-java/manage-ole/) bölümünde, Aspose.Slides for PHP via Java kullanarak bir PowerPoint sunumuna OLE çerçevesi eklemenin nasıl yapılacağını açıkladık. [nesne önizleme sorunu](/slides/tr/php-java/object-preview-issue-when-adding-oleobjectframe/) adresini ele almak için, seçilen çalışma sayfası alanının bir görüntüsünü OLE nesne çerçevesine atadık. Çıktı sunumunda, çalışma sayfası görüntüsünü gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çalışma kitabı etkinleştirilir. Son kullanıcılar gerçek Excel çalışma kitabında istedikleri değişiklikleri yapıp etkinleştirilen Excel çalışma kitabının dışına tıklayarak slayta geri dönebilirler. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişecektir. Yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının boyutuna bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğu için, ilk etkinleştirildiğinde orijinal boyutunu korumaya çalışır. Öte yandan OLE nesne çerçevesinin de kendi boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint gömme işleminin bir parçası olarak doğru oranları korumasını sağlamak için boyutu müzakere eder. Yeniden boyutlandırma, Excel pencere boyutu ile OLE nesne çerçevesinin boyut ve konumu arasındaki farklara dayanarak gerçekleşir.

## **Çalışan Çözüm**

Yeniden boyutlandırma etkisini önlemek için iki olası çözüm bulunmaktadır.

- PowerPoint sunumundaki OLE çerçevesini, seçilen satır ve sütunların toplam yüksekliği ve genişliğiyle eşleşecek şekilde ölçeklendirin.
- OLE çerçevesinin boyutunu sabit tutun ve seçilen satır ve sütunları içine sığacak şekilde ölçeklendirin.

### **OLE Çerçeve Boyutunu Ölçeklendirme**

Bu yaklaşım, gömülü Excel çalışma sayfasındaki seçilen satır ve sütunların toplam yüksekliği ve genişliğiyle eşleşecek şekilde OLE çerçeve boyutunu ayarlar.

Örnek, mevcut bir Excel çalışma kitabını yükler ve sıfır tabanlı indeksler kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) gösterilen aralığı tanımlar. Önizleme 96 DPI'da renderlanır ve piksel boyutları inç başına 72 puan kullanılarak puana dönüştürülür. [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) değiştirilmiş çalışma kitabını bu boyutlarda bir çerçeveye gömer. Önizleme, kaydedilen sunumdaki "EMBEDDED OLE OBJECT" yer tutucusunu değiştirmek için [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) aracılığıyla atanır.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Değiştirilmiş çalışma kitabını gömün ve ikili verileri Java bayt dizilerinde tutun.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $frameWidth = java_values($image->getWidth()) * 72.0 / $imageResolution;
        $frameHeight = java_values($image->getHeight()) * 72.0 / $imageResolution;
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

Önizleme yardımcı programı, seçilen aralığı [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) ile ayarlar ve kenar boşluklarını, üst bilgi ve alt bilgi bölümlerini kaldırır. [ImageOrPrintOptions::setOnlyArea](https://reference.aspose.com/cells/php/aspose.cells/imageorprintoptions/#onlyarea) etkinleştirildiğinde, [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) aralığı PNG görüntüsü olarak renderlar. Yardımcı, sunumda kullanılmak üzere PNG görüntüsünü içeren yeni bir giriş akışı döndürür ve akışı başına konumlandırır.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

### **Hücre Aralığı Boyutunu Ölçeklendirme**

Bu yaklaşım, seçilen satırların yüksekliklerini ve seçilen sütunların genişliklerini özel bir OLE çerçeve boyutuna eşit olacak şekilde ölçeklendirir.

Örnek, mevcut bir Excel çalışma kitabını yükler ve sıfır tabanlı indeksler kullanarak ilk çalışma sayfasının ilk 10 satırını ve 13 sütununu seçer. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) gösterilen aralığı tanımlar ve aşağıdaki yardımcı program bu aralığı 400 puan genişliğinde ve 100 puan yüksekliğinde bir çerçeveye sığacak şekilde ölçeklendirir. Değiştirilmiş çalışma kitabı bir akıma kaydedildikten sonra, [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) belirtilen boyutta gömülür. 96 DPI'da renderlanan bir önizleme, kaydedilen sunumda varsayılan yer tutucu yerine seçilen hücreleri göstermek için [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) aracılığıyla atanır.

```php
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook("sample.xlsx");
try {
    $worksheet = $workbook->getWorksheets()->get(0);
    $startRow = 0;
    $rowCount = 10;
    $startColumn = 0;
    $columnCount = 13;
    $lastRow = $startRow + $rowCount - 1;
    $lastColumn = $startColumn + $columnCount - 1;
    $workbook->getWorksheets()->setOleSize($startRow, $lastRow, $startColumn, $lastColumn);
    $cellRange = $worksheet->getCells()->createRange($startRow, $startColumn, $rowCount, $columnCount);
    $frameWidth = 400;
    $frameHeight = 100;
    ScaleCellRange($cellRange, $frameWidth, $frameHeight);

    $imageResolution = 96;
    $imageStream = CreateOleImage($cellRange, $imageResolution);

    // Değiştirilmiş çalışma kitabını gömün ve ikili verileri Java bayt dizilerinde tutun.
    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();
    $image = Images::fromStream($imageStream);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame(10, 10, $frameWidth, $frameHeight, $dataInfo);
            $previewImage = $presentation->getImages()->addImage($image);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $oleFrame->setObjectIcon(false);
            $presentation->save("output.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $image->dispose();
        $imageStream->close();
    }
} finally {
    $workbook->dispose();
}
```

Ölçekleme yardımcı programı, seçilen aralık için ayrı genişlik ve yükseklik oranları hesaplar, sütunların göreli genişliklerini ve satırların göreli yüksekliklerini korur. Hesaplanan boyutları inç'e dönüştürür ve ardından [Cells::setColumnWidthInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setcolumnwidthinch) ve [Cells::setRowHeightInch](https://reference.aspose.com/cells/php/aspose.cells/cells/#setrowheightinch) ile uygular. Seçilen aralığın sıfır olmayan bir genişliği ve yüksekliği olmalıdır.

```php
use aspose\cells\CellsUnitType;

// Width and height are the expected dimensions of the cell range in points.
function ScaleCellRange($cellRange, $width, $height) {
    $rangeWidth = java_values($cellRange->getWidth());
    $rangeHeight = java_values($cellRange->getHeight());
    $cells = $cellRange->getWorksheet()->getCells();
    $columnCount = java_values($cellRange->getColumnCount());
    $rowCount = java_values($cellRange->getRowCount());
    $firstColumn = java_values($cellRange->getFirstColumn());
    $firstRow = java_values($cellRange->getFirstRow());

    for ($i = 0; $i < $columnCount; $i++) {
        $columnIndex = $firstColumn + $i;
        $columnWidth = java_values($cells->getColumnWidth($columnIndex, false, CellsUnitType::POINT));
        $newColumnWidth = $columnWidth * $width / $rangeWidth;
        $widthInInches = $newColumnWidth / 72.0;
        $cells->setColumnWidthInch($columnIndex, $widthInInches);
    }

    for ($i = 0; $i < $rowCount; $i++) {
        $rowIndex = $firstRow + $i;
        $rowHeight = java_values($cells->getRowHeight($rowIndex, false, CellsUnitType::POINT));
        $newRowHeight = $rowHeight * $height / $rangeHeight;
        $heightInInches = $newRowHeight / 72.0;
        $cells->setRowHeightInch($rowIndex, $heightInInches);
    }
}
```

Bu önizleme yardımcı programı, yeniden boyutlandırılmış aralığı [SheetRender::toImage](https://reference.aspose.com/cells/php/aspose.cells/sheetrender/#toimage) kullanarak renderlar. [PageSetup::setPrintArea](https://reference.aspose.com/cells/php/aspose.cells/pagesetup/#printarea) bu aralığa sınırlanır, kenar boşlukları, üst bilgi ve alt bilgi bölümleri kaldırılır ve PNG akışı başına konumlandırılarak döndürülür.

```php
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SheetRender;
use Java as JavaObject;

function CreateOleImage($cellRange, $imageResolution) {
    $pageSetup = $cellRange->getWorksheet()->getPageSetup();
    $pageSetup->setPrintArea($cellRange->getAddress());
    $pageSetup->setLeftMargin(0);
    $pageSetup->setRightMargin(0);
    $pageSetup->setTopMargin(0);
    $pageSetup->setBottomMargin(0);
    $pageSetup->clearHeaderFooter();

    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $imageOptions->setVerticalResolution($imageResolution);
    $imageOptions->setHorizontalResolution($imageResolution);
    $imageOptions->setOnePagePerSheet(true);
    $imageOptions->setOnlyArea(true);

    $worksheet = $cellRange->getWorksheet();
    $sheetRender = new SheetRender($worksheet, $imageOptions);
    $imageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $sheetRender->toImage(0, $imageStream);
    $imageBytes = $imageStream->toByteArray();
    return new JavaObject("java.io.ByteArrayInputStream", $imageBytes);
}
```

## **Sonuç**
{{% alert color="info" title="Note" %}}
Yeniden boyutlandırma sorununu düzeltmek için iki yaklaşım bulunmaktadır. Gereksinimlerinize ve kullanım senaryonuza en uygun yaklaşımı seçin. Her iki yaklaşım da sunumlar şablondan ya da sıfırdan oluşturulmuş olsun aynı şekilde çalışır. Ayrıca bu çözümlerde OLE nesne çerçevesinin boyutu konusunda bir sınırlama yoktur.
{{% /alert %}}

## **SSS**

**PowerPoint'te ilk kez etkinleştirildiğinde gömülü bir Excel çalışma sayfası neden boyutunu değiştirir?**

Bu, Excel'in etkinleştirildiğinde orijinal pencere boyutunu korumaya çalışması, PowerPoint'teki OLE nesne çerçevenin ise kendi boyutlarına sahip olması nedeniyle olur. PowerPoint ve Excel, en-boy oranını korumak için boyutu müzakere eder ve bu da yeniden boyutlandırmaya yol açar.

**Bu yeniden boyutlandırma sorunu tamamen önlenebilir mi?**

Evet. OLE çerçevesini Excel hücre aralığı boyutuna göre ölçeklendirebilir veya hücre aralığını istediğiniz OLE çerçeve boyutuna göre ölçeklendirebilirsiniz; böylece istenmeyen yeniden boyutlandırmayı önleyebilirsiniz.

**Hangi ölçekleme yöntemini kullanmalıyım, OLE çerçeve ölçeklendirme mi yoksa hücre aralığı ölçeklendirme mi?**

**OLE çerçeve ölçeklendirme**yi seçin eğer orijinal Excel satır ve sütun boyutlarını korumak istiyorsanız. **Hücre aralığı ölçeklendirme**yi seçin eğer sunumunuzda OLE çerçevesinin sabit bir boyutu olmasını istiyorsanız.

**Bu çözümler sunumum bir şablona dayalıysa çalışır mı?**

Evet. Her iki çözüm de şablondan oluşturulan ve sıfırdan oluşturulan sunumlarda çalışır.

**Bu yöntemleri kullanırken OLE çerçevesinin boyutu konusunda bir limit var mı?**

Hayır. Ölçeği uygun şekilde ayarladığınız sürece OLE nesne çerçevesini istediğiniz kadar büyük yapabilirsiniz.

**PowerPoint'te "EMBEDDED OLE OBJECT" yer tutucu metninden kaçınmanın bir yolu var mı?**

Evet. Hedef Excel hücre aralığının bir ekran görüntüsünü alıp bunu OLE çerçevesinin yer tutucu resmi olarak ayarlayarak varsayılan yer tutucu metni yerine özel bir önizleme resmi gösterebilirsiniz.

## **İlgili Makaleler**

[Bir Excel Grafiği Oluşturma ve Sunuma OLE Nesnesi Olarak Gömme](/slides/tr/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint Eklentisi Kullanarak OLE Nesnelerini Otomatik Güncelleme](/slides/tr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)