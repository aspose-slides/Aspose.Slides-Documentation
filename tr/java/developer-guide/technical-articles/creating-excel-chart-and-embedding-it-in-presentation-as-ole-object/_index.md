---
title: Excel Grafiklerini Oluşturun ve Sunumlarda OLE Nesneleri Olarak Gömün
type: docs
weight: 30
url: /tr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel grafik
- grafik göm
- OLE nesnesi
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Cells for Java ile bir Excel grafiği oluşturun ve Aspose.Slides ile bir PowerPoint sunumuna çalışma kitabını gömün, grafik önizlemesi dahil."
---
## **Genel Bakış**

Bu makale, Aspose.Cells for Java ile bir Excel sütun grafiği oluşturmayı ve bu çalışma kitabını Aspose.Slides for Java ile bir PowerPoint sunumuna yerleştirmeyi göstermektedir. Gömülmüş çalışma kitabı hem kaynak verileri hem de grafiği içerir. Ayrı bir PNG önizlemesi, OLE nesnesi etkinleştirilmeden önce grafiği slaytta gösterir.

Sonuç, yerel bir PowerPoint grafiği değil, gömülü bir Excel nesnesidir. OLE aracılığıyla çalışma kitabını düzenlemek, OLE etkinleştirmesini destekleyen bir masaüstü uygulaması ve uyumlu bir Excel kurulumuna ihtiyaç duyar.

## **Ön Koşullar**

Aspose.Cells for Java ve Aspose.Slides for Java'ı proje bağımlılıklarınıza ekleyin. Örneği bir Java yöntemi içinde çalıştırın. Bu kütüphanelerle sunumu oluşturmak için Microsoft Office gerekli değildir.

Girdi dosyası gerekmez: örnek, veriyi ve grafiği bellekte oluşturur, ardından `OutputChart.pptx` dosyasını geçerli çalışma dizinine yazar. Değerlendirme modunun dışındaysanız iki ürün için de lisansları uygulayın.

## **Gömmenin Nasıl Çalıştığı**

1. Veri çalışma sayfası ve bir grafik sayfası içeren bir çalışma kitabı oluşturun.  
1. Grafik sayfasını aktif hâle getirin, böylece çalışma kitabı grafik üzerinde açılır.  
1. Çalışma kitabının OLE görüntüleme aralığını ayarlayın ve grafiği PNG olarak render edin.  
1. Çalışma kitabını bellek içinde XLSX olarak kaydedin ve bu baytları bir slayta gömün.  
1. PNG'yi OLE nesnesinin önizlemesi olarak atayın ve sunumu PPTX olarak kaydedin.

Çalışma kitabı görüntüleme aralığı ile slayttaki çerçeve farklı rollere sahiptir. [setOleSize](https://reference.aspose.com/cells/java/com.aspose.cells/worksheetcollection/#setOleSize-int-int-int-int-) sıfır tabanlı başlangıç/bitiş satır ve sütun indekslerini alır. [ChartCollection.add](https://reference.aspose.com/cells/java/com.aspose.cells/chartcollection/#add-int-int-int-int-int-) ise üst satır, sol sütun, alt satır ve sağ sütunu alır. Örnek, alt sağ sınır olarak satır indeksi 55 ve sütun indeksi 25'i kullanır; bu değerler veri satırı ya da sütun sayısı değil, düzen seçimi içerir.

Slayt çerçevesi nokta birimi kullanır. Örnek, çerçeveyi slayt içinde sığdırır ve PNG'nin en‑boy oranını koruyarak ortalar; önizlemeyi slaytı dolduracak şekilde uzatmaktan kaçınır.

## **Grafiği Oluşturma ve Gömme**

Aşağıdaki tam örnek, `DataSheet`'i dört satır ve beş sütun değerle doldurur. Her satır bir grafik serisi haline gelir. `ChartSheet`, çalışma kitabı kaydedilmeden önce aktif sayfa olarak seçilir.

Çalışma kitabı, [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/oleembeddeddatainfo/) içerisine geçirilen `xlsx` uzantısıyla eşleşecek şekilde açıkça XLSX olarak kaydedilir. PNG, ara bir bitmap dönüşümü olmadan doğrudan baytlarından yüklenir. [getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) aracılığıyla atanması, varsayılan OLE yer tutucusunu değiştirir.

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

        // Grafiğin önizlemesini oluştur ve düzenlenebilir çalışma kitabını ayrı olarak serileştir.
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

                // Önizlemeyi slayt içinde, en-boy oranını değiştirmeden sığdır.
                double scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
                float frameWidth = (float) (chartImage.getWidth() * scale);
                float frameHeight = (float) (chartImage.getHeight() * scale);
                float frameX = (float) ((slideWidth - frameWidth) / 2);
                float frameY = (float) ((slideHeight - frameHeight) / 2);

                OleEmbeddedDataInfo embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
                IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
                IPPImage previewImage = presentation.getImages().addImage(chartImage);
                oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

                presentation.save("OutputChart.pptx", Pptx);
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
```

## **Beklenen Sonuç**

`OutputChart.pptx`, gömülü bir Excel çalışma kitabı ve bir grafik önizlemesi içeren bir slayt içerir. Çalışma kitabı orijinal verileri ve dört serili bir sütun grafiği barındırır. Önizleme slayt üzerinde ortalanmış ve oranını korur.

![Gömülü bir çalışma kitabının önizlemesi olarak gösterilen Excel sütun grafiği](excel-chart-ole-preview.png)

Excel'in yüklü olduğu uyumlu bir masaüstü PowerPoint ortamında, nesneyi çift tıklayarak gömülü çalışma kitabını etkinleştirebilir ve düzenleyebilirsiniz. Etkinleştirme ve düzenleme, ana uygulamanın OLE desteği ve güvenlik ayarlarına bağlıdır.

## **SSS**

**Neden bir önizleme resmi gerekir?**

Gömülü çalışma kitabı ve slayt önizlemesi ayrı içeriklerdir. Slaytın varsayılan "EMBEDDED OLE OBJECT" yer tutucusu yerine grafiği göstermesi için bir grafik resmi sağlayın. Bkz. [OleObjectFrame Ekleme Sırasında Nesne Önizleme Sorunu](/slides/tr/java/object-preview-issue-when-adding-oleobjectframe/).

**Kod içinde çalışma kitabını değiştirdiğimde önizleme otomatik olarak güncellenir mi?**

Önizlemeyi bir anlık görüntü olarak düşünün. Çalışma kitabı verilerini programlı olarak güncellediğinizde, grafik resmini yeniden oluşturun ve önizlemeyi, ayrıca gömülü çalışma kitabı verisini de değiştirin.

**XLSX yerine XLS kullanabilir miyim?**

Evet. Çalışma kitabını XLS formatında kaydedin ve gömülü veri uzantısı olarak `xls` kullanın. Uzantı, gerçek çalışma kitabı formatıyla eşleşmelidir; yalnızca uzantıyı değiştirmek veriyi dönüştürmez.

**Neden nesne etkinleştirme sonrasında boyutu değişir?**

Ana uygulama, çalışma kitabını etkinleştirdiğinde OLE nesnesinin sunumunu güncelleyebilir. Çalışma kitabının OLE görüntüleme aralığı ve slayt çerçevesinin boyutları her ikisi de önemlidir. Bkz. [PPTX'te Grafik Yeniden Boyutlandırma için Çalışan Çözüm](/slides/tr/java/working-solution-for-chart-resizing-in-pptx/).

## **İlgili Bölümler**

- [PPTX'te Grafik Yeniden Boyutlandırma için Çalışan Çözüm](/slides/tr/java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame Ekleme Sırasında Nesne Önizleme Sorunu](/slides/tr/java/object-preview-issue-when-adding-oleobjectframe/)
- [PowerPoint Eklentisi ile OLE Nesnelerini Otomatik Güncelleme](/slides/tr/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)