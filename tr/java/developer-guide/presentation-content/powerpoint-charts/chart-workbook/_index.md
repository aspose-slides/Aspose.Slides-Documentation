---
title: Java Kullanarak Sunumlarda Grafik Çalışma Kitaplarını Yönetin
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/java/chart-workbook/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yönetin ve sunum verilerinizi sadeleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini nasıl okunup yazılacağını, çalışma kitabı hücrelerini grafik veri etiketleri olarak nasıl kullanılacağını, çalışma sayfası koleksiyonlarına nasıl erişileceğini ve grafik değerleri için veri kaynağı tipinin nasıl belirleneceğini gösterir.

Ayrıca, dış çalışma kitaplarının grafik veri kaynakları olarak kullanılmasını kapsar. Örnekler, dış bir çalışma kitabı oluşturup atamanın, bir grafik ile ilişkilendirilmiş dış çalışma kitabının yolunu almanın ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemenin nasıl yapılacağını gösterir.

Eksik veri temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve mevcut görüntüleme modlarının bir çizgi grafiği karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/java/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardan Veri İçer**

Gizli çalışma sayfası satır ve sütunlarından veri çizip çizmeyeceğini kontrol etmek için [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) metodunu kullanın. Görünür hücreleri çizmek için `true`, hem görünür hem de gizli hücreleri dahil etmek için `false` değerini ayarlayın. Bu ayar grafik çizimini yönlendirir; çalışma sayfası satır veya sütunlarını gizlemez veya göstermez.

[örnek sunum](hidden-source-data.pptx) ilk slaytındaki ilk şekil olarak bir sütun grafiği içerir. Gömülü çalışma sayfası `Sheet1`, aşağıdaki kaynak aralığını (`A1:C4`) barındırır. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) üzerinden erişin ve gizli durumlarını incelemek için [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) metodunu okuyun. Bu yöntem gizli durumunu değiştirmeden raporlar. Bu dosyada B2 görünür, B3 gizli satıra aittir ve C2 gizli sütuna aittir; örnek sırasıyla `false`, `true` ve `true` yazdırır.

Bu örnek için çizim ayarı değiştirildikten sonra grafik verisini yenileyin: gömülü çalışma kitabını [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) ile tutun ve [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de geri getirmek için [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) metodunu kullanın. Bayrağı sadece değiştirmek, bu örneğin önbelleğe alınmış grafik verisini ve kategori etiketlerini yenilemek için yeterli değildir.

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

Örnek, sunumu iki sürüm olarak kaydeder: yalnızca görünür Perakende değerleri (10 ve 20) içeren bir sürüm ve tüm altı değeri içeren bir sürüm. Aşağıdaki görseller iki çizim modunu gösterir. Satır 3 ve C sütunu her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. Eksik değerlerin nasıl görüntüleneceğini kontrol etmek için [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metodunu kullanın; bu, gizli kaynak verileri ekleyip çıkarmaz. Örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/java/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Bir Grafiğin Veri Aralığını Al**

Mevcut bir sunumda çalışma kitabı verisini güncellemeden önce, her grafiğin kullandığı çalışma sayfası hücrelerini belirlemek üzere kaynak aralıklarını inceleyin. [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) metodu, `Sheet1!$A$1:$D$5` gibi çalışma sayfası nitelikli bir formül olarak mevcut veri aralığını döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1’den D5’e kadar (dahil) hücreleri gösterir. Dolar işaretleri mutlak satır ve sütun referanslarını belirtir.

Metod, grafiği veya çalışma kitabını değiştirmeden mevcut aralığı okur. Grafik bir çalışma kitabını veri kaynağı olarak kullanmıyorsa, `InvalidOperationException` fırlatır. Daha fazla bilgi için [ChartData API Referansı](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/) bölümüne bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan kontrol ederek grafik olup olmadığını belirler. Her grafiğin adını ve kaynak aralığını yazdırır. Grafik bir çalışma kitabı kullanmıyorsa, bir mesaj yazdırır ve bir sonraki grafik ile devam eder.

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

## **Bir Çalışma Kitabından Grafik Verilerini Oku ve Yaz**

Aspose.Slides for Java, [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) ve [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) metodlarıyla grafik veri çalışma kitaplarını (Aspose.Cells ile düzenlenmiş) okuyup yazmanıza olanak tanır. **Not**: grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaydındaki ilk şekil olarak bir grafik içeren bir sunum kullanır. Gömülü çalışma kitabını bir bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını tekrar yazar. Değişiklikler bellek içinde kalır; örnek sunumu kaydetmez.

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

### **Çalışma Kitabı Değiştirildikten Sonra Grafik Düzenini Doğrula**

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını tutar. Bu tutarsızlık, [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) metodunun indeks dışı hatası vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaydın ilk şekli olarak bir grafik kullanır. Yorum satırı, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini gösterir; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve düzeni bellek içinde doğrular.

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

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarla**

Çalışma kitabı hücrelerinden gelen metni grafik veri etiketi olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaydına varsayılan verilerle bir balon grafiği ekler. Çalışma sayfası 0 üzerindeki A10:A12 hücrelerini ilk serinin ilk üç etiketi olarak kullanır, hücrelerden etiketleri etkinleştirir ve güncellenmiş sunumu kaydeder.

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

## **Çalışma Sayfalarını Yönet**

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) metodu, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan verilerle bir pasta grafiği oluşturur ve her çalışma sayfasının adını konsola yazar.

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

## **Veri Kaynağı Tipini Belirle**

Bu örnek, varsayılan verilerle bir 3B sütun grafiği oluşturur ve iki seri ismini farklı veri kaynaklarıyla ayarlar. İlk isim bir metin sabiti; ikinci isim çalışma sayfası 0 üzerindeki C1 hücresinden alınır. [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) enum’u, her isim için kaynağı seçer. Örnek, güncellenmiş seri isimleriyle sunumu kaydeder.

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Formatlarını Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) üzerindeki [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) metodunu, [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) enum’u ile birlikte kullanarak desteklenmeyen formatları tespit edebilir ve bu grafikleri atlayabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü çalışma kitabı olan her grafik için tanı mesajı yazdırır.

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

Aspose.Slides, grafikler için veri kaynağı olarak harici çalışma kitaplarını kullanmayı destekler.

### **Harici Bir Çalışma Kitabı Oluştur**

[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) ve [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metodlarını kullanarak gömülü bir grafik çalışma kitabını dosyaya dışarı aktarabilir ve grafiği bu harici çalışma kitabına bağlayabilirsiniz.

Bu örnek, varsayılan verilerle bir pasta grafiği oluşturur ve çalışma kitabını dışa aktarır. Dosya yazma işlemi tamamlandıktan sonra harici çalışma kitabını veri kaynağı olarak atar ve bağlanmış sunumu kaydeder.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Harici Bir Çalışma Kitabı Ata**

[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metodunu kullanarak bir grafiğe harici bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu metod, harici çalışma kitabının yolunu güncellemek (çalışma kitabı taşınmışsa) için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri doğrudan düzenleyemezsiniz, ancak bu çalışma kitaplarını harici veri kaynağı olarak yine de kullanabilirsiniz. Harici çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1 hücresinde seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler bulunan bir harici çalışma kitabı kullanır. Pasta grafiği oluşturur, çalışma kitabını bağlar ve [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlı grafik ile sunumu kaydeder.

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) metodunun `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` **false** olduğunda, yalnızca çalışma kitabı yolu güncellenir. Grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez; bu nedenle çalışma kitabı mevcut olmayabilir.
* `updateChartData` **true** olduğunda, grafik verisi hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` **false** olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verileri korunur ve mevcut olmayan çalışma kitabı yüklenmeden sunum kaydedilir.

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

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Al**

Bir grafiğe bağlı çalışma kitabını belirlemek için, grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, bağlanmış harici bir çalışma kitabı bulunan bir sunumun ilk slaydındaki ilk şekli inceler. Eğer şekil bir harici çalışma kitabına bağlanmış bir grafikse, [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) metodunu konsola yazdırır. Ardından sunumun bir kopyasını kaydeder.

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

### **Grafik Verisini Düzenle**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemezse bir istisna fırlatılır.

Bu örnek, ilk slaydın ilk şekli olan ve erişilebilir bir harici çalışma kitabına bağlanmış bir grafik kullanır. İlk serinin ilk veri noktasının hücre tabanlı değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlı harici XLSX dosyasını güncelleyebilir; bu nedenle orijinal çalışma kitabını korumak istiyorsanız bir kopya kullanın.

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

### **Grafik Önbelleğinden Çalışma Kitabını Kurtar**

Bir grafik, eksik veya kullanılamayan bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbellekte tutulan veriden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) oluşturun, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) metodunu çağırın ve [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) özelliğini `true` olarak ayarlayın; ardından sunumu açın.

Aşağıdaki Java örneği, ilk slaydın ilk şekli olan ve kullanılamayan bir harici çalışma kitabına başvuran bir grafiğin çalışma kitabı verilerini kurtarır. Kurtarılan verilere [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) ve [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) aracılığıyla erişir:

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

Harici çalışma kitabı kullanılamaz ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Ön belleklenmiş grafik verisini bir geri dönüş yolu olarak kabul edebiliyorsanız kurtarmayı etkinleştirin; çünkü önbellek, dış çalışma kitabında son sunum güncellemesinden sonra yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**

Evet. Bir grafiğin bir [veri kaynağı tipi](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) ve bir [harici çalışma kitabı yolu](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) vardır; kaynak bir harici çalışma kitabı ise, tam yolu okuyarak bir harici dosyanın kullanıldığını teyit edebilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreli bir yol belirtirseniz, otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu nedenle çalışma kitabını taşımak, bağlantının güncellenmesini gerektirebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides doğrudan uzak çalışma kitaplarını düzenlemeyi desteklemez; yalnızca veri kaynağı olarak kullanılabilirler.

**Aspose.Slides sunumu kaydederken harici XLSX dosyasını üzerine yazıyor mu?**

Sunum, [harici dosyaya bir bağlantı](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) saklar. Hücre tabanlı grafik verisini düzenlemek, bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinal çalışma kitabının değişmemesi gerekiyorsa bir kopyasını kullanın.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides bağlantı sırasında şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak ya da [Aspose.Cells](https://reference.aspose.com/cells/java/) gibi bir araçla şifresi çözülmüş bir kopya hazırlamaktır.

**Birden çok grafik aynı harici çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde her grafik bir sonraki veri yüklemesinde bu güncellemeyi yansıtır.