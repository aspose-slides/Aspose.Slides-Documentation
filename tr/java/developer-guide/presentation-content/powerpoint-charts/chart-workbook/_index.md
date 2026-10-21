---
title: Sunumlarda Java Kullanarak Grafik Çalışma Kitaplarını Yönetme
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
description: "Aspose.Slides for Java’yı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale Aspose.Slides'ta grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları üzerinden grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketi olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca dış çalışma kitaplarını grafik veri kaynakları olarak kullanmayı kapsar. Örnekler, dış bir çalışma kitabı oluşturup atamayı, bir grafiğe bağlı dış çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemeyi gösterir.

Eksik veriyi temsil eden çalışma kitabı hücreleri için, bir boş hücre ile sıfır arasındaki farkı ve mevcut gösterim modlarının bir çizgi grafik karşılaştırmasını görmek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/java/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardaki Veriyi Dahil Et**

[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) kullanarak bir grafiğin gizli çalışma sayfası satır ve sütunlarından veri çizip çizmeyeceğini kontrol edin. Yalnızca görünür hücreleri çizmek için `true`, hem görünür hem de gizli hücreleri dahil etmek için `false` ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez/göstermez.

[örnek sunum](hidden-source-data.pptx) ilk slaytındaki ilk şekil olarak bir sütun grafiği içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` kaynak aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma Sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) ile erişin ve gizli durumlarını incelemek için [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) okuyun. Bu yöntem gizli durumunu değiştirmeden raporlar. Bu dosyada B2 görünür, B3 gizli satıra ait ve C2 gizli sütuna ait; örnek sırasıyla `false`, `true` ve `true` yazdırır.

Bu örnek için çizim ayarı değiştirildikten sonra grafik verisini yenileyin: gömülü çalışma kitabını [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) ile tutun ve [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) ile yeniden yükleyin. Tüm hücreleri dahil ederken gizli Şubat kategorisini de geri yüklemek için [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) kullanın. Sadece bayrağı değiştirmek, bu örnek için önbelleğe alınmış grafik verisini ve kategori etiketlerini yenilemek için yetersizdir.

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

            // Gömülü çalışma kitabından grafik verisini yenileyin.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Gizli kategoriler dahil tam kaynak aralığını geri yükleyin.
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

Örnek, yalnızca görünür Perakende değerlerini (10 ve 20) içeren bir sürüm ve tüm altı değeri içeren bir sürüm kaydeder. Aşağıdaki görseller iki çizim kipini gösterir. Satır 3 ve sütun C her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Gizli bir hücredeki değer boş bir hücreden farklıdır. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) eksik değerlerin nasıl gösterileceğini kontrol eder; gizli kaynak veriyi ekleyip çıkartmaz. Örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/java/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Grafiğin Veri Aralığını Al**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, her grafiğin kullandığı çalışma sayfası hücrelerini belirlemek için kaynak aralıklarını inceleyin. [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) yöntemi, `Sheet1!$A$1:$D$5` gibi çalışma sayfası nitelikli bir formül olarak mevcut veri aralığını döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1’den D5’e kadar (dahil) hücreleri tanımlar. `$` işaretleri mutlak satır ve sütun referanslarını gösterir.

Yöntem grafiği veya onun çalışma kitabını değiştirmeden mevcut aralığı okur. Grafik bir çalışma kitabını veri kaynağı olarak kullanmıyorsa `InvalidOperationException` fırlatır. Daha fazla bilgi için [ChartData API Referansı](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/) bölümüne bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan grafikler için kontrol eder. Her grafiğin adını ve kaynak aralığını yazdırır. Bir grafik çalışma kitabı kullanmıyorsa bir mesaj yazdırır ve bir sonraki grafa devam eder.

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

Aspose.Slides for Java, grafik verileri (Aspose.Cells ile düzenlenmiş) içeren çalışma kitaplarını okumanıza ve yazmanıza olanak tanıyan [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) ve [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) yöntemleri sağlar. **Not** grafik verileri aynı biçimde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaytındaki ilk şekil olarak bir grafik içeren bir sunum kullanır. Gömülü çalışma kitabını bir bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellek içinde kalır; örnek sunumu kaydetmez.

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

### **Çalışma Kitabı Değişikliği Sonrası Grafik Düzenini Doğrulama**

Gömülü bir çalışma kitabını değiştirilmiş bir kitapla değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) metodunun dizin dışı hatasıyla başarısız olmasına neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik kullanır. Yorum, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini işaret eder; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve bellekte düzeni doğrular.

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

Koleksiyonları temizlemek, çalışma kitabı geri yazılmadan önce bayat veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli seri ve kategori eşlemelerini yeniden oluşturun ve ardından grafiği kullanın.

## **Çalışma Kitabı Hücreleri için Özel Sayı Biçimleri Ayarlama**

[IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) kullanarak sayısal değerlerin bir grafiğin gömülü çalışma kitabında nasıl görüneceğini kontrol edin. Örneğin, bir rapor dönüşüm oranını yüzde olarak dört ondalık basamakla ve katsayıyı beş ondalık basamakla gösterebilir. Her iki değeri de sayısal tutun, böylece hesaplamalar ve grafik çizimi için kullanılabilir kalır.

Bir sayı biçimi değeri gösterimi değiştirir, saklanan değeri değiştirmez. `0.0000%` biçimi `0.125` değerini `12.5000%` olarak gösterir; saklanan sayı `12.5` ile değiştirilmez. Benzer şekilde, `0.00000` `0.1234567` değerini `0.12346` olarak gösterir, saklanan değeri yuvarlamaz. Özel biçim boş bir dize (`""`) ise, [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) tarafından döndürülen biçim kullanılır.

Aşağıdaki örnek bir sütun grafiği oluşturur ve hücrelerine [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) üzerinden erişir. Çalışma sayfası 0'da B2 dönüşüm oranını ve C2 katsayısını içerir. İki hücre de grafik değerlerini sağlar. Örnek aynı zamanda kaynak biçimlerine bağlı değer etiketlerini etkinleştirir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Çalışma kitabı hücre biçimleri, doğrudan grafik eksenlerine veya veri etiketlerine ayarlanan biçimlerden ayrıdadır. Bu örnekte, her etiket [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) `true` olduğu için kaynak hücre değerini gösterir ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) `true` olduğu için kaynak sayı biçimini takip eder. Sunumu kaydedip yeniden açtıktan sonra etiketler `12.5000%` ve `0.12346` gösterir, aşağıda gösterildiği gibi. Düşey eksen kendi sayı biçimini [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) `0.00` olarak ayarlar ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) `false` olur.

Bir veri etiketini bağımsız biçimlendirmek için kaynak‑bağlantı bayrağını `false` yapın ve [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) ile bir biçim atayın. Bu, çalışma kitabı hücresinin biçimini değiştirmez. Örneğin, bağımsız `0.00` etiketi ilk değeri `0.13` olarak gösterirken B2 hâlâ `12.5000%` gösterir. Doğrudan etiket biçimlendirme için [Grafik Veri Etiketleri](/slides/tr/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) bölümüne bakın.

Aşağıdaki resim, sunumu kaydedip yeniden açtıktan sonra oluşturulmuştur:

![Kaynakla bağlanmış etiketleri gösteren sütun grafik, %12,5000 ve 0,12346 ve bağımsız biçimlendirilmiş sayısal eksen.](custom-cell-formats.png)

## **Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

Çalışma kitabı hücrelerindeki metni grafik veri etiketleri olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaydına varsayılan verili bir balon grafiği ekler. İlk serideki ilk üç etiket için çalışma sayfası 0'da A10:A12 hücrelerini kullanır, hücrelerden etiketleri etkinleştirir ve güncellenmiş sunumu kaydeder.

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

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) yöntemi, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek bir pasta grafiği oluşturur, varsayılan veriyi ekler ve her çalışma sayfası adını konsola yazar.

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

## **Veri Kaynağı Türünü Belirtme**

Bu örnek, varsayılan verili bir 3D sütun grafiği oluşturur ve iki seri adını farklı veri kaynakları kullanarak ayarlar. İlk ad bir dize sabiti; ikincisi çalışma sayfası 0'da C1 hücresini kullanır. [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) enum'ı her ad için kaynağı seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) biçimini desteklemez. [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) üzerindeki [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) yöntemini ve [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) enum'ını kullanarak desteklenmeyen biçimleri tespit edip bu grafikleri atlayabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü çalışma kitabı olan her grafiğe tanı teşhisi mesajı yazar.

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

Aspose.Slides, grafikler için harici çalışma kitaplarını veri kaynağı olarak kullanmayı destekler.

### **Harici Çalışma Kitabı Oluşturma**

[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) ve [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) kullanarak gömülü grafik çalışma kitabını bir dosyaya dışa aktarabilir ve grafiği bu harici çalışma kitabına bağlayabilirsiniz.

Bu örnek bir pasta grafiği oluşturur, varsayılan veriyi ekler ve çalışma kitabını dışa aktarır. Dosya yazma işlemi tamamlandıktan sonra harici çalışma kitabını grafik veri kaynağı olarak atar, ardından bağlantılı sunumu kaydeder.

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

### **Harici Çalışma Kitabı Ayarlama**

[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) yöntemiyle bir grafiğe harici bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem, harici çalışma kitabının yolu taşındıysa güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri doğrudan düzenleyemesiniz de, bu çalışma kitaplarını hâlâ harici veri kaynağı olarak kullanabilirsiniz. Bir harici çalışma kitabı için göreceli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1 hücresinde bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler içeren bir harici çalışma kitabı kullanır. Bir pasta grafiği oluşturur, çalışma kitabını bağlar ve [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlantılı grafiği içeren sunumu kaydeder.

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

[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) yönteminin `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` `false` olduğunda, yalnızca çalışma kitabı yolu güncellenir. Grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez, bu yüzden çalışma kitabı mevcut olmayabilir.
* `updateChartData` `true` olduğunda, grafik verileri hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` `false` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verisini korur ve bulunmayan çalışma kitabını yüklemeden sunumu kaydeder.

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

Bu örnek, bir sunumda bağlanmış harici çalışma kitabı olan ilk slaydın ilk şekline bakar. Eğer dış çalışma kitabına bağlanmış bir grafik ise, [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) konsola yazar. Ardından sunumun bir kopyasını kaydeder.

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

Harici çalışma kitaplarındaki verileri, dahili çalışma kitaplarındaki verileri düzenlediğiniz gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemezse bir istisna fırlatılır.

Bu örnek, ilk slayttaki ilk şekil olarak bir grafik kullanır ve erişilebilir bir harici çalışma kitabına bağlanır. İlk serinin ilk veri noktasının hücre‑destekli değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlı harici XLSX dosyasını güncelleyebilir; bu yüzden orijinali korumak istiyorsanız bir kopya kullanın.

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

Bir grafik, eksik veya bulunamayan harici bir çalışma kitabı kullanıyorsa, Aspose.Slides grafik çalışma kitabını sunumda önbelleğe alınan veriden yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) oluşturun, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) çağırın ve [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) `true` olarak ayarlayın, ardından sunumu açın.

Aşağıdaki Java örneği, ilk slayttaki ilk şekil olarak bir grafik için harici çalışma kitabı bulunamadığında çalışma kitabı verilerini kurtarır. Kurtarılan verilere [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) ve [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) aracılığıyla erişir:

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

        // Burada kurtarılan çalışma kitabı verilerini okuyun veya değiştirin.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Harici çalışma kitabı bulunamaz ve kurtarma devre dışı bırakılırsa, Aspose.Slides bir istisna fırlatır. Ön bellekli grafik verilerini kullanmak kabul edilebilir bir geri dönüşümse, kurtarmayı etkinleştirin; çünkü önbellek, sunum son güncellendiğinden sonra harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafik, [veri kaynağı türü](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) ve bir [harici çalışma kitabı yolu](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) içerir; kaynak bir harici çalışma kitabı ise, dış bir dosyanın kullanıldığını doğrulamak için tam yolu okuyabilirsiniz.

**Harici çalışma kitapları için göreceli yollar destekleniyor mu, nasıl depolanıyor?**

Evet. Bir göreceli yol belirtirseniz, otomatik olarak mutlak yola dönüştürülür. Sunum bu mutlak yolu PPTX dosyasında saklar, bu yüzden çalışma kitabını taşımak bağlantının güncellenmesini gerektirebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides'tan uzaktaki çalışma kitaplarını doğrudan düzenlemek desteklenmez—sadece bir kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazıyor mu?**

Sunum, harici dosyaya bir [bağlantı](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) saklar. Hücre‑destekli grafik verilerini düzenlemek, bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinalin değiştirilmemesi gerekiyorsa, çalışma kitabının bir kopyasını kullanın.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlanırken şifre kabul etmez. Yaygın bir yaklaşım, şifreyi önceden kaldırmak veya bir [Aspose.Cells](https://reference.aspose.com/cells/java/) kullanarak şifresi çözülmüş bir kopya hazırlamaktır ve bu kopyaya bağlanmaktır.

**Birden çok grafik aynı harici çalışma kitabına referans gösterebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki kez yüklendiğinde her grafiğe yansır.