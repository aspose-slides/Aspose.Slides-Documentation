---
title: PPTX'te Grafik Yeniden Boyutlandırma için Çalışan Çözüm
type: docs
weight: 40
url: /tr/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafik yeniden boyutlandırma
- Excel grafiği
- OLE nesnesi
- grafik gömme
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile gömülü Excel OLE nesneleri kullanırken PPTX'te beklenmedik grafik yeniden boyutlandırmayı düzeltin. Grafik ve OLE çerçevesi boyutlarının tutarlı kalması için sabit grafik boyutları ayarlayın."
---
## **Genel Bakış**

Aspose bileşenleri kullanılarak PowerPoint sunumlarına OLE nesnesi olarak gömülü Excel grafiklerinin ilk etkinleştirilmesinden sonra boyutu değişebilir. Bu durum, etkinleştirme öncesi ve sonrası grafiğin görünümünde fark yaratabilir. Bu makale, yeniden boyutlandırmanın neden oluştuğunu açıklar ve sabit grafik boyutlarını OLE çerçevesiyle eşleştirerek nasıl önlenebileceğini gösterir.

In [Excel Grafiklerini Oluşturma ve Sunumlarda OLE Nesneleri Olarak Gömme](/slides/tr/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for PHP via Java and embed it in a PowerPoint presentation using Aspose.Slides for PHP via Java. To address the [nesne önizleme sorunu](/slides/tr/php-java/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **Yeniden Boyutlandırmanın Nedeni**

Gömülü Excel çalışma kitabının kendi pencere boyutları vardır ve Excel nesne ilk etkinleştirildiğinde bu boyutları korumaya çalışır. Slayttaki OLE çerçevesinin ise bağımsız olarak tanımlanmış boyutları vardır. Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint nesnenin boyutunu orantılı tutmak için bir müzakere yapar. Çalışma kitabı penceresi ile OLE çerçevesi arasındaki farklar bu nedenle nesnenin yeniden boyutlandırılmasına yol açabilir.

## **Çalışan Çözüm**

Grafik boyutunu slayttaki OLE çerçevesiyle eşleştirin ve grafik boyutlarını çalışma kitabı penceresinden bağımsız tutun. Bu çözüm yeni bir sunumda ya da mevcut bir şablonda çalışır.

Örnek, Aspose.Cells for PHP via Java ve Aspose.Slides for PHP via Java gerektirir. Her iki ürün aynı PHP/Java Bridge örneğiyle yapılandırılır, her iki PHP sarmalayıcı yüklenir ve iki Java kütüphanesi köprüye sunulur. Girdi dosyası gerekmez. Aktif bir grafik sayfasında basit bir kolon grafik oluşturur ve çalışma kitabını XLS formatında gömer. Grafik önizleme resmi atanmaz; grafik, PowerPoint’te OLE nesnesi aktif edildiğinde görünür hâle gelir.

Örnek, soldan 0,5 inç, üstten 1 inç konumlandırılmış 9,5 × 4 inç boyutunda bir OLE çerçevesiyle yeni bir sunum oluşturur. Slayt koordinatları ve boyutları puan cinsindendir (inç başına 72 puan). Mevcut bir sunum için, [Şablon Kullanma](#use-a-template) bölümüne bakın.

## **Sabit Bir Grafik Boyutu Belirleme**

Set [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) to false so that the chart dimensions are independent of the workbook window. Set the [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) dimensions through [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) and [Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height), converting points to pixels using 96 pixels per inch: a frame measuring 684 × 288 points corresponds to a chart measuring 912 × 384 pixels. Set [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) to the CUSTOM value of [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/). The example embeds the workbook with [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) and saves a presentation with a 9.5 × 4‑inch OLE frame.

Java numeric results are converted with `java_values` before they are used as PHP indices. The workbook bytes remain in a Java byte array when passed to [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/).

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayt koordinatları ve boyutları puan cinsindendir (inç başına 72 puan).
        $width = 684; // 9.5 inç.
        $height = 288; // 4 inç.

        $chart->setSizeWithWindow(false);
        // Puanları inç başına 96 piksel kullanarak grafik piksellerine dönüştür.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **Şablon Kullanma**

The sizing logic is the same for an existing presentation. To adapt the example:

1. Load the template presentation instead of creating an empty presentation.  
1. Check that the first slide contains at least three shapes, then use the shape at index 2 as the placeholder.  
1. Take the frame width and height from that shape instead of using the fixed values 684 and 288. Keep the sizing calculations unchanged.  
1. Add the OLE frame at the placeholder's position instead of the fixed coordinates 36 and 72.  
1. Remove the placeholder before saving the presentation.

## **SSS**

**Gömülü Excel grafiğim PowerPoint’te etkinleştirildikten sonra neden boyut değiştiriyor?**

Bu, Excel’in ilk etkinleştirildiğinde orijinal pencere boyutunu geri getirmeye çalışması, PowerPoint’teki OLE nesne çerçevesinin ise kendi boyutlarına sahip olması nedeniyle olur. PowerPoint ve Excel, en boy oranını korumak için bir boyut müzakeresi yapar ve bu da yeniden boyutlandırmaya yol açabilir.

**Grafik ve OLE çerçevesi boyutlarını nasıl tutarlı hâle getirebilirim?**

OLE çerçevesiyle eşleşen sabit grafik boyutları belirleyin ve çalışma kitabını gömmeden önce özel bir grafik baskı boyutu kullanın. Yukarıdaki örnek gerekli ayarları ve birim dönüşümlerini göstermektedir.

**Çalışma kitabı pencere boyutunu eşleştirmek yeterli midir?**

Sadece çalışma kitabı pencere boyutunu eşleştirmek, OLE çerçevesinin etkinleştirme sonrası boyut değişimini güvenilir şekilde önlemez. Örnekte gösterildiği gibi sabit grafik boyutları kullanılmalıdır.

**Bu çözüm hem şablon tabanlı hem de yeni sunumlarla çalışır mı?**

Evet. Şablon için yer tutucunun boyutları ve konumu kullanılır. Yeni bir sunum için çerçeve boyutları ve konumu doğrudan belirtilir.

**Bu örneği diğer elektronik tablo programlarıyla oluşturulan grafiklerle kullanabilir miyim?**

Örnek, Aspose.Cells ile oluşturulmuş bir Excel çalışma kitabı kullanır. Diğer elektronik tablo programları için aktivasyon davranışı gösterilmemiştir.

## **İlgili Bölümler**

- [Excel Grafiklerini Oluşturma ve Sunumlarda OLE Nesneleri Olarak Gömme](/slides/tr/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)