---
title: "PPTX'te Grafik Yeniden Boyutlandırma İçin Çalışan Çözüm"
type: docs
weight: 40
url: /tr/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafik yeniden boyutlandırma
- Excel grafiği
- OLE nesnesi
- grafik gömme
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile gömülü Excel OLE nesneleri kullanıldığında PPTX içinde beklenmeyen grafik yeniden boyutlandırmayı düzeltin. Grafik ve OLE çerçevesi boyutlarının tutarlı kalması için sabit grafik boyutları ayarlayın."
---
## **Arka Plan**

Aspose bileşenleri kullanılarak PowerPoint sunumlarına OLE nesneleri olarak gömülen Excel grafikleri, ilk etkinleştirmelerinden sonra boyut değiştirebilir. Bu, grafiğin etkinleştirme öncesi ve sonrası görünümünde belirgin bir fark oluşmasına neden olabilir. Bu makale, yeniden boyutlandırmanın neden gerçekleştiğini açıklar ve sabit grafik boyutlarını OLE çerçevesiyle eşleştirerek nasıl önlenebileceğini gösterir.

[Excel Grafiklerini Oluşturun ve Sunumlarda OLE Nesneleri Olarak Gömün](/slides/tr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) bölümünde, Aspose.Cells for Java ile bir Excel grafiği oluşturup Aspose.Slides for Java kullanarak bir PowerPoint sunumuna nasıl gömeceğimizi açıkladık. [nesne önizleme sorunu](/slides/tr/java/object-preview-issue-when-adding-oleobjectframe/) çözmek için grafiğin görüntüsünü grafiğin OLE nesne çerçevesine atadık. Çıktı sunumunda, grafik görüntüsünü gösteren OLE nesne çerçevesine çift‑tıkladığınızda Excel grafiği etkinleştirilir. Kullanıcılar gömülü Excel çalışma kitabını düzenleyebilir ve etkinleştirilen çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişir ve yeniden boyutlandırma faktörü, OLE nesne çerçevesi ve gömülü Excel çalışma kitabının orijinal boyutlarına bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Gömülü Excel çalışma kitabının kendi pencere boyutları vardır ve Excel, nesne ilk kez etkinleştirildiğinde bu boyutları korumaya çalışır. Slayttaki OLE çerçevesi ise bağımsız olarak tanımlanmış boyutlara sahiptir. Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint nesnenin boyutunu orantılı tutmak için bir uzlaşma sağlar. Çalışma kitabı penceresi ile OLE çerçevesi arasındaki farklar bu nedenle nesnenin yeniden boyutlandırılmasına yol açabilir.

## **Çözüm**

Grafik boyutunu slayttaki OLE çerçevesiyle eşleştirin ve grafik boyutlarını çalışma kitabı penceresinden bağımsız tutun. Bu çözüm yeni bir sunumda ya da mevcut bir şablonda çalışır.

Örnek, Aspose.Cells for Java ve Aspose.Slides for Java gerektirir. Aktif bir grafik sayfasında basit bir sütun grafik oluşturur ve çalışma kitabını XLS biçiminde gömer. Grafik önizleme görüntüsü atanmaz; grafik, PowerPoint’te OLE nesnesi etkinleştirildiğinde görünür hale gelir.

Örnek, soldan 0,5 inç, üstten 1 inç uzaklıkta konumlandırılmış 9,5 × 4 inç OLE çerçevesiyle yeni bir sunum oluşturur. Slayt koordinatları ve boyutları nokta cinsindendir (inç başına 72 nokta). Mevcut bir sunum için [Şablon Kullanma](#use-a-template) bölümüne bakın.

## **Sabit Bir Grafik Boyutu Ayarlama**

[setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) değerini false yapın, böylece grafik boyutları çalışma kitabı penceresinden bağımsız olur. [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) boyutlarını [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) ve [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-) ile ayarlayın; nokta birimini inç başına 96 piksele çevirerek: 684 × 288 nokta ölçüsündeki bir çerçeve, 912 × 384 piksel ölçüsündeki bir grafik anlamına gelir. [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) değerini [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/) içinde CUSTOM olarak ayarlayın. Örnek, çalışma kitabını [addOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) ile gömer ve 9,5 × 4 inç OLE çerçevesine sahip bir sunumu kaydeder.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.FileFormatType;
import com.aspose.cells.PrintSizeType;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Workbook workbook = new Workbook();
try {
    Worksheet dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
    Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10);
    Chart chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Slayt koordinatları ve boyutları nokta cinsindendir (inç başına 72 nokta).
        float width = 684f; // 9.5 inç.
        float height = 288f; // 4 inç.

        chart.setSizeWithWindow(false);
        // Noktaları, inç başına 96 piksel kullanarak grafik piksellerine dönüştür.
        chart.getChartObject().setWidth((int)(width / 72f * 96f));
        chart.getChartObject().setHeight((int)(height / 72f * 96f));
        chart.setPrintSize(PrintSizeType.CUSTOM);

        ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
        workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
        OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
        slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    workbook.dispose();
}
```

## **Şablon Kullanma**

Mevcut bir sunum için boyutlandırma mantığı aynıdır. Örneği uyarlamak için:

1. Boş bir sunum oluşturmak yerine şablon sunumu yükleyin.  
1. İlk slaytın en az üç şekli olduğunu doğrulayın, ardından 2. indeksteki şekli yer tutucu olarak kullanın.  
1. Sabit değerler 684 ve 288 yerine bu şekilden çerçeve genişliği ve yüksekliğini alın. Boyutlandırma hesaplamalarını aynı tutun.  
1. Sabit koordinatlar 36 ve 72 yerine yer tutucunun konumuna OLE çerçevesi ekleyin.  
1. Sunumu kaydetmeden önce yer tutucuyu kaldırın.

## **SSS**

**Neden gömülü Excel grafiğim PowerPoint’te etkinleştirildikten sonra boyut değiştiriyor?**  
Bu, Excel’in ilk etkinleştirildiğinde orijinal pencere boyutunu geri yüklemeye çalışması, ancak PowerPoint’te OLE nesne çerçevesinin kendi boyutlarına sahip olması nedeniyle olur. PowerPoint ve Excel, en-boy oranını korumak için boyutu uzlaşır ve bu da yeniden boyutlandırmaya yol açabilir.

**Grafik ve OLE çerçevesi boyutlarını nasıl tutarlı hâle getirebilirim?**  
OLE çerçevesiyle eşleşen sabit grafik boyutları ayarlayın ve çalışma kitabını gömmeden önce özel bir grafik yazdırma boyutu kullanın. Yukarıdaki örnek gerekli ayarları ve birim dönüşümlerini gösterir.

**Çalışma kitabı pencere boyutunu eşleştirmek yeterli mi?**  
Yalnızca çalışma kitabı pencere boyutunu eşleştirmek, OLE çerçevesinin etkinleştirmeden sonra boyut değiştirmesini güvenilir bir şekilde önlemez. Örnekte gösterildiği gibi sabit grafik boyutları kullanın.

**Bu çözüm şablon tabanlı sunumlar ve yeni sunumlar için de çalışıyor mu?**  
Evet. Şablon kullanıyorsanız yer tutucunun boyut ve konumunu kullanın. Yeni bir sunum oluşturuyorsanız çerçeve boyutlarını ve konumunu doğrudan belirtin.

**Bu örneği diğer elektronik tablo programlarında oluşturulan grafiklerle kullanabilir miyim?**  
Örnek, Aspose.Cells ile oluşturulan bir Excel çalışma kitabı kullanır. Diğer elektronik tablo programları için etkinleştirme davranışı gösterilmez.

## **İlgili Bölümler**

- [Excel Grafiklerini Oluşturun ve Sunumlarda OLE Nesneleri Olarak Gömün](/slides/tr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)