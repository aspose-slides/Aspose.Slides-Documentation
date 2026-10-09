---
title: Android'de Sunumlarda Grafik Çalışma Kitaplarını Yönetme
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/androidjava/chart-workbook/
keywords:
- grafik çalışma kitabı
- grafik verisi
- çalışma kitabı hücresi
- veri etiketi
- çalışma sayfası
- veri kaynağı
- harici çalışma kitabı
- harici veri
- grafik önbelleği
- çalışma kitabı kurtarma
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'ı keşfedin: PowerPoint ve OpenDocument formatlarındaki grafik çalışma kitaplarını zahmetsizce yöneterek sunum verilerinizi kolaylaştırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları üzerinden grafik verilerini nasıl okuyup yazacağınızı, çalışma kitabı hücrelerini grafik veri etiketleri olarak nasıl kullanacağınızı, çalışma sayfası koleksiyonlarına nasıl erişileceğini ve grafik değerleri için veri kaynağı türünün nasıl belirtileceğini gösterir.

Ayrıca harici çalışma kitaplarının grafik veri kaynakları olarak kullanılmasını da kapsar. Örnekler, harici bir çalışma kitabının nasıl oluşturulup atanacağını, bir grafiğe bağlanan harici çalışma kitabının yolunun nasıl alınacağını ve çalışma kitabı kullanılabilir olduğunda grafik verisinin nasıl düzenleneceğini gösterir.

Eksik veri temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve mevcut görüntüleme modlarının bir çizgi grafiği karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/androidjava/chart-series/) sayfasına bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Et**

[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) metodunu kullanarak bir grafiğin gizli çalışma sayfası satır ve sütunlarından veri çizip çizmeyeceğini kontrol edin. Görünür hücreleri çizmek için `true`, hem görünür hem de gizli hücreleri dahil etmek için `false` olarak ayarlayın. Bu ayar, grafik çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez/göstermez.

[örnek sunum](hidden-source-data.pptx) ilk slaytındaki ilk şekil olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` kaynak aralığını içerir. Satır 3 ve sütun C gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma Sayfası Satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (gizli satır) | February | 40 | 60 |
| 4 | March | 20 | 50 |

[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) aracılığıyla kaynak hücrelere erişin ve gizli durumlarını incelemek için [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) metodunu okuyun. Bu yöntem gizli durumunu değiştirmeden raporlar. Bu dosyada B2 görünür, B3 gizli satıra ait ve C2 gizli sütuna ait; örnek sırasıyla `false`, `true` ve `true` yazdırır.

Bu örnek için, çizim ayarı değiştirildikten sonra grafik verisini yenileyin: gömülü çalışma kitabını [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) ile tutun ve [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de içerecek tam aralığı geri yüklemek için [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) metodunu da kullanın. Sadece bayrağı değiştirmek, bu örneğin önbelleğe alınmış grafik verisini ve kategori etiketlerini yenilemek için yetersizdir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Gömülü çalışma kitabından grafik verilerini yenile.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Gizli kategorileri de içerecek şekilde tam kaynak aralığını geri yükle.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Örnek, sunumun iki sürümünü kaydeder: yalnızca görünür Perakende değerleri (10 ve 20) içeren bir sürüm ve tüm altı değeri içeren bir sürüm. Aşağıdaki görseller iki çizim modunu gösterir. Satır 3 ve sütun C, her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) eksik değerlerin nasıl görüntüleneceğini kontrol eder; gizli kaynak verisini dahil etmez/çıkartmaz. Bir örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/androidjava/chart-series/#control-the-display-of-empty-cells) sayfasına bakın.

## **Bir Grafiğin Veri Aralığını Almak**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, her bir grafiğin hangi çalışma sayfası hücrelerini kullandığını belirlemek için kaynak aralıklarını inceleyin. [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) metodu, `Sheet1!$A$1:$D$5` gibi bir çalışma sayfası nitelikli formül olarak mevcut veri aralığını döndürür. Burada `Sheet1` çalışma sayfasının adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1’den D5’e kadar (dahil) hücreleri belirtir. `$` işaretleri mutlak satır ve sütun referanslarını gösterir.

Bu metod, grafiği veya onun çalışma kitabını değiştirmeden mevcut aralığı okur. Grafik veri kaynağı olarak bir çalışma kitabı kullanmıyorsa `InvalidOperationException` fırlatır. Daha fazla bilgi için [ChartData API Referansı](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/) sayfasına bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan kontrol ederek grafik olup olmadığını denetler. Her grafiğin adını ve kaynak aralığını yazdırır. Grafik bir çalışma kitabı kullanmıyorsa bir mesaj yazdırıp bir sonraki grafiğe geçer.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides for Android via Java, [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) ve [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) metodlarını sağlar; bu metodlar grafik verileri içeren çalışma kitaplarını (Aspose.Cells ile düzenlenmiş) okumanıza ve yazmanıza izin verir. **Not**: Grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynakla benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaytının ilk şekli olarak bir grafiği içeren bir sunum kullanır. Gömülü çalışma kitabını bir bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Çalışma Kitabı Değişikliğinden Sonra Grafik Düzenini Doğrulama**

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) metodunun indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slayttaki ilk şekil olarak bir grafiği kullanır. Yorum, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini gösterir; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve bellekteki düzeni doğrular.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Burada çalışma kitabı baytlarını değiştirin, örneğin Aspose.Cells kullanarak.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Koleksiyonların temizlenmesi, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli seri ve kategori eşlemelerini yeniden oluşturun ve ardından grafiği kullanın.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

Çalışma kitabı hücrelerindeki metni grafik veri etiketi olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına varsayılan veri içeren bir balon grafiği ekler. Çalışma sayfası 0’da A10:A12 hücrelerini ilk serinin ilk üç etiketi olarak kullanır, hücrelerden etiketleri etkinleştirir ve güncellenmiş sunumu kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Çalışma Sayfalarını Yönetme**

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) metodu, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan veri ile bir pasta grafiği oluşturur ve her bir çalışma sayfasının adını konsola yazdırır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Veri Kaynağı Türünü Belirleme**

Bu örnek, varsayılan veri ile bir 3B sütun grafiği oluşturur ve iki farklı veri kaynağı kullanarak iki seri adı ayarlar. İlk isim sabit bir dize kullanır; ikincisi ise çalışma sayfası 0’da C1 hücresini kullanır. [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) enumı, her isim için kaynağı seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) üzerindeki [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) metodunu, [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) enumı ile birlikte kullanarak desteklenmeyen biçimleri tespit edip bu grafikleri atlayabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü çalışma kitabına sahip her grafik için tanılayıcı bir mesaj yazdırır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Desteklenen grafik çalışma kitabı verilerini burada okuyun veya değiştirin.
    }
} finally {
    presentation.dispose();
}
```

## **Harici Çalışma Kitabı**

Aspose.Slides, harici çalışma kitaplarını grafikler için veri kaynağı olarak kullanmayı destekler.

### **Harici Çalışma Kitabı Oluşturma**

[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) ve [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metodlarını kullanarak gömülü bir grafik çalışma kitabını bir dosyaya dışa aktarabilir ve grafiği o harici çalışma kitabına bağlayabilirsiniz.

Bu örnek, varsayılan veri ile bir pasta grafiği oluşturur ve çalışmasını dışa aktarır. Dosya yazımı tamamlandıktan sonra harici çalışma kitabını veri kaynağı olarak atar, ardından bağlantılı sunumu kaydeder.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Harici Çalışma Kitabı Ayarlama**

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metodunu kullanarak bir grafiğe dışarıdan bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu metod aynı zamanda dış çalışma kitabının yolunu (dış çalışma kitabı taşınmışsa) güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarının verileri düzenlenemez, ancak bu çalışma kitapları dış veri kaynağı olarak kullanılabilir. Harici çalışma kitabı için bir göreli yol verilirse, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1 hücresinde bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler bulunan bir harici çalışma kitabı kullanır. Örnek bir pasta grafiği oluşturur, çalışma kitabını bağlar ve [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) metoduyla A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlantılı grafiği içeren sunumu kaydeder.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) metodunun `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` **false** olduğunda, yalnızca çalışma kitabı yolu güncellenir. Grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez, bu yüzden çalışma kitabı mevcut olmayabilir.
* `updateChartData` **true** olduğunda, grafik verisi hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` **false** olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verisini korur ve bulunamayan çalışma kitabını yüklemeden sunumu kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Almak**

Bir grafiğe bağlı olan çalışma kitabını belirlemek için, grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, bir dış çalışma kitabına bağlı olan bir grafiği içeren bir sunumun ilk slaydındaki ilk şekli inceler. Grafik dış bir çalışma kitabına bağlıysa, [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) metodunu konsola yazdırır. Ardından sunumun bir kopyasını kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Grafik Verilerini Düzenleme**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki verileri düzenlediğiniz gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu örnek, ilk slaydın ilk şekli olan ve erişilebilir bir harici çalışma kitabına bağlanmış bir grafiği kullanır. İlk serinin ilk veri noktasının hücre tabanlı değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlı harici XLSX dosyasını güncelleyebilir; bu yüzden orijinal çalışma kitabını korumak istiyorsanız bir kopya kullanın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Grafik Önbelleğinden Çalışma Kitabını Kurtarma**

Bir grafik, eksik veya kullanılamayan bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumdaki önbelleğe alınmış veriden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) oluşturun, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) metodunu çağırın ve [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) özelliğini `true` olarak ayarlayın; ardından sunumu açın.

Aşağıdaki Java örneği, ilk slaydın ilk şekli olarak bir grafiği içeren ve kullanılamayan bir dış çalışma kitabına başvuran bir grafiğin çalışma kitabı verilerini kurtarır. Kurtarılan verilere [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) ve [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) aracılığıyla erişir:

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Kurtarılan çalışma kitabı verilerini burada okuyun veya değiştirin.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Harici çalışma kitabı kullanılamaz ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Ön bellek verisinin kullanılmasının kabul edilebilir bir geri dönüş yolu olduğu durumlarda kurtarmayı etkinleştirin; ön bellek, sunum son güncellendiğinden beri dış çalışma kitabına yapılan değişiklikleri içermeyebilir.

## **SSS**

**Bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin [veri kaynağı türü](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) ve bir [harici çalışma kitabı yolu](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) vardır; kaynak bir harici çalışma kitabı ise tam yolu okuyarak bir dış dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu, nasıl depolanıyor?**

Evet. Göreli bir yol belirtirseniz, otomatik olarak mutlak bir yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu yüzden çalışma kitabını taşıdığınızda bağlantıyı güncellemeniz gerekebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides tarafından uzaktaki çalışma kitaplarını doğrudan düzenlemek desteklenmez; yalnızca veri kaynağı olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazıyor mu?**

Sunum, dış dosyaya bir [bağlantı](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) saklar. Hücre tabanlı grafik verilerini düzenlemek aynı zamanda bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinal çalışma kitabının değişmemesi gerekiyorsa bir kopyasını kullanın.

**Harici dosya şifre korumalıysa ne yapmalı?**

Aspose.Slides, bağlanırken şifre kabul etmez. Yaygın bir yaklaşım, önce korumayı kaldırmak ya da bir şifre çözülmüş kopya (örneğin, [Aspose.Cells](https://reference.aspose.com/cells/java/)) hazırlamaktır ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, o dosyada yapılan güncellemeler bir sonraki veri yüklemesinde her grafiğe yansır.