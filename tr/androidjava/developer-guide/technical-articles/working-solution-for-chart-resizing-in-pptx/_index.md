---
title: PPTX'te Grafik Yeniden Boyutlandırma İçin Çalışan Çözüm
type: docs
weight: 40
url: /tr/androidjava/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafik yeniden boyutlandırma
- Excel grafiği
- OLE nesnesi
- grafiği gömme
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile gömülü Excel OLE nesneleri kullanıldığında PPTX'te beklenmeyen grafik yeniden boyutlandırmayı düzeltin. Grafik ve OLE çerçevesi boyutlarının tutarlı kalması için sabit grafik boyutları ayarlayın."
---
## **Genel Bakış**

Excel grafiklerini OLE nesneleri olarak PowerPoint sunumlarına Aspose bileşenleriyle gömmek, ilk etkinleştirilmelerinden sonra boyutlarını değiştirebilir. Bu, grafiğin etkinleştirme öncesi ve sonrası görünümünde belirgin bir fark oluşturur. Bu makale, yeniden boyutlandırmanın neden gerçekleştiğini açıklar ve sabit grafik boyutlarını OLE çerçevesiyle eşleştirerek nasıl önlenebileceğini gösterir.

[Excel Grafiklerini Oluştur ve Sunumlarda OLE Nesneleri Olarak Göm](/slides/tr/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) makalesinde, Aspose.Cells for Android via Java kullanarak bir Excel grafiği oluşturup, Aspose.Slides for Android via Java ile bir PowerPoint sunumuna nasıl gömeceğinizi açıkladık. [nesne önizleme sorunu](/slides/tr/androidjava/object-preview-issue-when-adding-oleobjectframe/) çözmek için grafiğin resmini grafiğin OLE nesne çerçevesine atadık. Çıktı sunumunda, OLE nesne çerçevesine çift tıkladığınızda grafik resmi görüntülenir ve Excel grafiği etkinleştirilir. Kullanıcı gömülü Excel çalışma kitabını düzenleyebilir ve etkinleştirilen çalışma kitabının dışına tıklayarak slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişir ve yeniden boyutlandırma faktörü, hem OLE nesne çerçevesinin hem de gömülü Excel çalışma kitabının orijinal boyutlarına bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Gömülü Excel çalışma kitabının kendi pencere boyutları vardır ve Excel bu pencereyi nesne ilk etkinleştirildiğinde korumaya çalışır. Slayt üzerindeki OLE çerçevesi ise bağımsız olarak tanımlanmış boyutlara sahiptir. Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint nesnenin boyutunu orantılarını koruyacak şekilde müzakere eder. Çalışma kitabı penceresi ile OLE çerçevesi arasındaki farklar bu nedenle nesnenin yeniden boyutlandırılmasına yol açar.

## **Çalışan Çözüm**

Grafik boyutunu slayttaki OLE çerçevesiyle eşleştirin ve grafik boyutlarının çalışma kitabı penceresinden bağımsız olmasını sağlayın. Bu çözüm yeni bir sunumda ya da mevcut bir şablonda işe yarar.

Örnek, Aspose.Cells for Android via Java ve Aspose.Slides for Android via Java gerektirir. Aktif bir grafik sayfasında basit bir sütun grafiği oluşturur ve çalışma kitabını XLS formatında gömer. Android aktivitesinden `FixedChartSize.createPresentation(getFilesDir())` çağırarak çıktıyı uygulamanın dahili dosya dizinine kaydedin. OLE etkinleştirme masaüstü PowerPoint ve uyumlu bir Excel kurulumunu gerektirir. Grafik önizleme resmi atanmamıştır; grafik, PowerPoint'te OLE nesnesi etkinleştirildiğinde görünür.

Örnek, sol kenardan 0,5 inç, üstten 1 inç uzaklıkta konumlandırılmış 9,5 × 4 inçlik bir OLE çerçevesiyle yeni bir sunum oluşturur. Slayt koordinatları ve boyutları puan cinsindendir (inç başına 72 puan). Mevcut bir sunum için, [Şablon Kullan](#use-a-template) bölümüne bakın.

## **Sabit Grafik Boyutu Ayarla**

[setSizeWithWindow](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setSizeWithWindow-boolean-) değerini false olarak ayarlayın; böylece grafik boyutları çalışma kitabı penceresinden bağımsız olur. [getChartObject](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#getChartObject--) boyutlarını [setWidth](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setWidth-int-) ve [setHeight](https://reference.aspose.com/cells/java/com.aspose.cells/shape/#setHeight-int-) ile ayarlayın; puanları inç başına 96 piksel kullanarak piksellere dönüştürün: 684 × 288 puan ölçüsündeki bir çerçeve, 912 × 384 piksel ölçüsündeki bir grafik anlamına gelir. [setPrintSize](https://reference.aspose.com/cells/java/com.aspose.cells/chart/#setPrintSize-int-) değerini [PrintSizeType](https://reference.aspose.com/cells/java/com.aspose.cells/printsizetype/) sınıfının CUSTOM değeriyle ayarlayın. Örnek, çalışma kitabını [addOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addOleObjectFrame-float-float-float-float-com.aspose.slides.IOleEmbeddedDataInfo-) ile gömer ve 9,5 × 4 inçlik bir OLE çerçevesiyle sunumu kaydeder.

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
import java.io.File;

public class FixedChartSize {
    public static void createPresentation(File filesDirectory) {
        try {
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

                    // Slayt koordinatları ve boyutları puan cinsindendir (inç başına 72 puan).
                    float width = 684f; // 9,5 inç.
                    float height = 288f; // 4 inç.

                    chart.setSizeWithWindow(false);
                    // Puanları inç başına 96 piksel kullanarak grafik piksellerine dönüştür.
                    chart.getChartObject().setWidth((int)(width / 72f * 96f));
                    chart.getChartObject().setHeight((int)(height / 72f * 96f));
                    chart.setPrintSize(PrintSizeType.CUSTOM);

                    ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                    workbook.save(workbookStream, FileFormatType.EXCEL_97_TO_2003);
                    OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
                    slide.getShapes().addOleObjectFrame(36, 72, width, height, dataInfo);

                    File outputFile = new File(filesDirectory, "chart-fixed-size.pptx");
                    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
                } finally {
                    presentation.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Unable to create the presentation: " + exception.getMessage());
        }
    }
}
```

## **Şablon Kullan**

Mevcut bir sunumda boyutlandırma mantığı aynıdır. Örneği uyarlamak için:

1. Boş bir sunum oluşturmak yerine şablon sunumu yükleyin.  
2. İlk slaytın en az üç şekli olduğundan emin olun ve 2. indeksteki şekli yer tutucu olarak kullanın.  
3. Sabit değerler 684 ve 288 yerine bu şekilden çerçeve genişliğini ve yüksekliğini alın. Boyut hesaplamalarını aynı tutun.  
4. Sabit koordinatlar 36 ve 72 yerine yer tutucunun konumunda OLE çerçevesini ekleyin.  
5. Sunumu kaydetmeden önce yer tutucuyu kaldırın.

## **SSS**

**Yerleştirilmiş Excel grafiğim PowerPoint'te etkinleştirildikten sonra neden boyut değiştiriyor?**  
Bu, Excel'in ilk etkinleştirildiğinde özgün pencere boyutunu geri yüklemeye çalışmasından kaynaklanır; PowerPoint'teki OLE nesne çerçevesi ise kendi boyutlarına sahiptir. PowerPoint ve Excel, en boy oranını korumak için boyutu müzakere eder ve bu da yeniden boyutlandırmaya yol açar.

**Grafik ve OLE çerçevesi boyutlarını tutarlı nasıl tutabilirim?**  
OLE çerçevesiyle eşleşen sabit grafik boyutları ayarlayın ve gömmeden önce özel bir grafik baskı boyutu kullanın. Yukarıdaki örnek gerekli ayarları ve birim dönüşümlerini gösterir.

**Çalışma kitabı pencere boyutunu eşleştirmek yeterli mi?**  
Sadece çalışma kitabı pencere boyutunu eşleştirmek, OLE çerçevesinin etkinleştirme sonrası boyut değiştirmesini güvenilir şekilde engellemez. Örnekte gösterildiği gibi sabit grafik boyutları kullanın.

**Bu çözüm hem şablon tabanlı hem de yeni sunumlarla çalışıyor mu?**  
Evet. Şablon için yer tutucunun boyut ve konumunu kullanın. Yeni bir sunum için çerçeve boyutlarını ve konumunu doğrudan belirtin.

**Bu örneği başka elektronik tablo programlarıyla oluşturulan grafiklerle kullanabilir miyim?**  
Örnek, Aspose.Cells ile oluşturulmuş bir Excel çalışma kitabı kullanır. Diğer elektronik tablo programları için etkinleştirme davranışını göstermez.

## **İlgili Bölümler**

- [Excel Grafiklerini Oluştur ve Sunumlarda OLE Nesneleri Olarak Göm](/slides/tr/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)