---
title: Excel Grafiklerini Oluşturun ve Sunumlarda OLE Nesneleri Olarak Yerleştirin
type: docs
weight: 30
url: /tr/androidjava/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel grafik
- grafik yerleştir
- OLE nesnesi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Cells for Android via Java ile bir Excel grafik oluşturun ve çalışma kitabını Aspose.Slides for Android via Java ile bir PowerPoint sunumuna, grafik önizlemesi dahil, yerleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Cells for Android via Java kullanarak bir Excel sütun grafik oluşturmayı ve bu çalışma kitabını Aspose.Slides for Android via Java ile bir PowerPoint sunumuna yerleştirmeyi gösterir. Yerleştirilen çalışma kitabı hem kaynak verileri hem de grafiği içerir. Ayrı bir PNG önizlemesi, OLE nesnesi etkinleştirilmeden önce slaytta grafiği görüntüler.

Sonuç, yerel bir PowerPoint grafiği değil, yerleştirilmiş bir Excel nesnesidir. OLE aracılığıyla çalışma kitabını düzenlemek, OLE etkinleştirmesini ve uyumlu bir Excel kurulumunu destekleyen bir masaüstü uygulaması gerektirir.

## **Önkoşullar**

Aspose.Cells for Android via Java ve Aspose.Slides for Android via Java’yı proje bağımlılıklarınıza ekleyin. Bir Android etkinliğinden `ExcelChartEmbedding.createPresentation(getFilesDir())` metodunu çağırın. Bu kütüphanelerle sunumu oluşturmak için Microsoft Office gerekli değildir.

Giriş dosyası gerekmez: örnek, verileri ve grafiği bellekte oluşturur, ardından `OutputChart.pptx` dosyasını uygulamanın iç dosya dizinine yazar. Değerlendirme modunun dışındaysa her iki ürün için de lisansları uygulayın.

## **Yerleştirmenin Nasıl Çalıştığı**

1. Veri çalışma sayfası ve grafik sayfası içeren bir çalışma kitabı oluşturun.  
2. Grafik sayfasını etkinleştirerek çalışma kitabının grafik üzerinde açılmasını sağlayın.  
3. Çalışma kitabının OLE görüntüleme aralığını ayarlayın ve grafiği PNG’ye renderlayın.  
4. Çalışma kitabını bellek içinde XLSX olarak kaydedin ve bu baytları bir slayta yerleştirin.  
5. PNG’yi OLE nesnesinin önizlemesi olarak atayın ve sunumu PPTX olarak kaydedin.

Çalışma kitabı görüntüleme aralığı ve slayt çerçevesi farklı rollere sahiptir. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) sıfır tabanlı başlangıç/bitiş satır ve sütun indeksleri alırken, [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) üst satır, sol sütun, alt satır ve sağ sütunu kabul eder. Örnek, alt‑sağ sınırlar için satır indeksi 55 ve sütun indeksi 25’i kullanır; bu değerler düzenleme tercihidir, veri satır veya sütun sayısını ifade etmez.

Slayt çerçevesi puan cinsindendir. Örnek, çerçeveyi slayt içinde sığdırır ve PNG’nin en‑boy oranını koruyarak ortalar; önizlemeyi slaytı dolduracak şekilde uzatmaz.

## **Grafiği Oluşturma ve Yerleştirme**

Aşağıdaki tam örnek, `DataSheet`i dört satır ve beş sütun değerle doldurur. Her satır bir grafik serisi olur. `ChartSheet` çalışma kitabı kaydedilmeden önce aktif sayfa olarak seçilir.

Çalışma kitabı açıkça XLSX olarak kaydedilir; bu, [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleembeddeddatainfo/)’ye geçirilen `xlsx` uzantısına karşılık gelir. PNG, ara bir bitmap dönüşümü olmadan baytlarından doğrudan yüklenir. [getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) aracılığıyla atandığında varsayılan OLE yer tutucusunun yerini alır.

```java
import com.aspose.cells.Chart;
import com.aspose.cells.ChartType;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import static com.aspose.cells.SaveFormat.XLSX;
import static com.aspose.slides.SaveFormat.Pptx;
import com.aspose.cells.SheetType;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import com.aspose.slides.IImage;
import com.aspose.slides.Images;
import com.aspose.slides.IOleObjectFrame;
import com.aspose.slides.IPPImage;
import com.aspose.slides.ISlide;
import com.aspose.slides.OleEmbeddedDataInfo;
import com.aspose.slides.Presentation;
import java.io.ByteArrayOutputStream;
import java.io.File;

public class ExcelChartEmbedding {
    public static void createPresentation(File filesDirectory) {
        try {
            Workbook workbook = new Workbook();
            try {
                Worksheet dataSheet = workbook.getWorksheets().get(0);
                dataSheet.setName("DataSheet");

                int[][] values = {
                    { 67, 44, 46, 43, 24 },
                    { 86, 64, 97, 29, 40 },
                    { 68, 89, 78, 69, 38 },
                    { 91, 48, 60, 26, 25 }
                };

                for (int row = 0; row < values.length; row++) {
                    for (int column = 0; column < values[row].length; column++) {
                        dataSheet.getCells().get(row, column).putValue(values[row][column]);
                    }
                }

                int chartSheetIndex = workbook.getWorksheets().add(SheetType.CHART);
                Worksheet chartSheet = workbook.getWorksheets().get(chartSheetIndex);
                chartSheet.setName("ChartSheet");

                int lastChartRow = 55;
                int lastChartColumn = 25;
                int chartIndex = chartSheet.getCharts().add(ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
                Chart chart = chartSheet.getCharts().get(chartIndex);
                for (int row = 1; row <= values.length; row++) {
                    chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
                }

                workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
                workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

                // Grafik önizlemesini oluştur ve düzenlenebilir çalışma kitabını ayrı olarak serileştir.
                ImageOrPrintOptions imageOptions = new ImageOrPrintOptions();
                imageOptions.setImageType(ImageType.PNG);
                ByteArrayOutputStream chartImageStream = new ByteArrayOutputStream();
                chart.toImage(chartImageStream, imageOptions);
                byte[] chartImageBytes = chartImageStream.toByteArray();

                ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
                workbook.save(workbookStream, XLSX);
                byte[] workbookBytes = workbookStream.toByteArray();

                IImage chartImage = Images.fromData(chartImageBytes);
                try {
                    Presentation presentation = new Presentation();
                    try {
                        ISlide slide = presentation.getSlides().get_Item(0);
                        double slideWidth = presentation.getSlideSize().getSize().getWidth();
                        double slideHeight = presentation.getSlideSize().getSize().getHeight();

                        // Önizlemeyi slayt içinde, en‑boy oranını değiştirmeden sığdır.
                        double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                        float frameWidth = (float) (chartImage.getWidth() * scale);
                        float frameHeight = (float) (chartImage.getHeight() * scale);
                        float frameX = (float) ((slideWidth - frameWidth) / 2);
                        float frameY = (float) ((slideHeight - frameHeight) / 2);

                        OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                        IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                        IPPImage previewImage = presentation.getImages().addImage(chartImage);
                        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                        File outputFile = new File(filesDirectory, "OutputChart.pptx");
                        presentation.save(outputFile.getAbsolutePath(), Pptx);
                    } finally {
                        presentation.dispose();
                    }
                } finally {
                    chartImage.dispose();
                }
            } finally {
                workbook.dispose();
            }
        } catch (Exception exception) {
            System.err.println("Could not create the presentation: " + exception.getMessage());
        }
    }
}
```

## **Beklenen Sonuç**

`OutputChart.pptx` bir slayt içerir; bu slaytta yerleştirilmiş bir Excel çalışma kitabı ve bir grafik önizlemesi bulunur. Çalışma kitabı orijinal verileri ve dört serili bir sütun grafiği barındırır. Önizleme slayt üzerinde ortalanmış ve oranları korunmuş olarak gösterilir.

![Excel column chart displayed as the preview of an embedded workbook](excel-chart-ole-preview.png)

Uygun bir masaüstü PowerPoint ortamında Excel kuruluysa, nesneye çift tıklayarak yerleştirilmiş çalışma kitabını etkinleştirebilir ve düzenleyebilirsiniz. Etkinleştirme ve düzenleme, ana uygulamanın OLE desteği ve güvenlik ayarlarına bağlıdır.

## **SSS**

**Neden bir önizleme resmi gerekir?**

Yerleştirilmiş çalışma kitabı ve slayt önizlemesi ayrı içeriklerdir. Slaytta varsayılan “EMBEDDED OLE OBJECT” yer tutucusu yerine grafiği göstermek için bir grafik resmi sağlayın. Ayrıntılar için [Object Preview Issue when Adding OleObjectFrame](/slides/tr/androidjava/object-preview-issue-when-adding-oleobjectframe/) sayfasına bakın.

**Kod içinde çalışma kitabını değiştirdiğimde önizleme otomatik olarak güncellenir mi?**

Önizleme bir anlık görüntüdür. Çalışma kitabı verilerini programlı olarak güncellediğinizde, grafik resmini yeniden oluşturun ve önizlemeyi ve yerleştirilmiş çalışma kitabı verisini aynı anda değiştirin.

**XLS yerine XLSX kullanabilir miyim?**

Evet. Çalışma kitabını XLS formatında kaydedebilir ve gömülü veri uzantısı olarak `xls` kullanabilirsiniz. Uzantı, gerçek çalışma kitabı biçimiyle eşleşmelidir; yalnızca uzantıyı değiştirmek veri dönüşümünü gerçekleştirmez.

**Nesne etkinleştirildikten sonra boyutu neden değişebilir?**

Ana uygulama, çalışma kitabını etkinleştirirken OLE nesnesinin sunumunu güncelleyebilir. Çalışma kitabının OLE görüntüleme aralığı ve slayt çerçevesi boyutları her ikisi de önem taşır. Ayrıntılar için [Working Solution for Worksheet Resizing](/slides/tr/androidjava/working-solution-for-worksheet-resizing/) sayfasına bakın.

## **İlgili Bölümler**

- [Working Solution for Worksheet Resizing](/slides/tr/androidjava/working-solution-for-worksheet-resizing/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/tr/androidjava/object-preview-issue-when-adding-oleobjectframe/)
- [Manage OLE](/slides/tr/androidjava/manage-ole/)