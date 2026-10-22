---
title: Java Kullanarak Sunumlarda Grafik İş Kitaplarını Yönet
linktitle: Grafik İş Kitabı
type: docs
weight: 70
url: /tr/java/chart-workbook/
keywords:
- grafik iş kitabı
- grafik verisi
- iş kitabı hücresi
- veri etiketi
- çalışma sayfası
- veri kaynağı
- harici iş kitabı
- harici veri
- grafik önbelleği
- iş kitabı kurtarma
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik iş kitaplarını zahmetsizce yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grafik iş kitaplarıyla nasıl çalışılacağını açıklar. İş kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, iş kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca, harici iş kitaplarının grafik veri kaynağı olarak kullanılmasını da kapsar. Örnekler, dış bir iş kitabı oluşturma ve atama, bir grafiğe bağlı dış iş kitabının yolunu alma ve iş kitabı mevcut olduğunda grafik verisini düzenleme yöntemlerini gösterir.

Eksik veriyi temsil eden iş kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve mevcut görüntüleme modlarının satır grafik karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/java/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Et**

[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) kullanarak bir grafiğin gizli çalışma sayfası satır ve sütunlarından veri çizip çizmeyeceğini kontrol edin. Yalnızca görünen hücreleri çizmek için `true`, hem görünen hem de gizli hücreleri dahil etmek için `false` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez veya göstermez.

[örnek sunum](hidden-source-data.pptx) ilk slaytının ilk şekli olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) aracılığıyla kaynak hücrelere erişin ve gizli durumlarını incelemek için [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) kullanın. Bu yöntem gizli durumunu değiştirmeden rapor eder. Bu dosyada B2 görünüyor, B3 gizli satıra ait ve C2 gizli sütuna ait; örnek sırasıyla `false`, `true` ve `true` değerlerini basar.

Bu örnek için, çizim ayarı değiştirildikten sonra grafik verisini yenileyin: gömülü iş kitabını [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) ile koruyun ve [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de içeren tam aralığı geri yüklemek için [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) kullanın. Bayrağı yalnızca değiştirmek, bu örneğin önbelleğe alınmış grafik verisini ve kategori etiketlerini yenilemek için yeterli değildir.

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

            // Gömülü iş kitabından grafik verilerini yenile.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Gizli kategoriler dahil olmak üzere tam kaynak aralığını geri yükle.
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

Örnek, sunumun iki sürümünü kaydeder: yalnızca görünen Perakende değerleri (10 ve 20) içeren bir sürüm ve tüm altı değeri içeren bir sürüm. Aşağıdaki görseller iki çizim modunu gösterir. 3. satır ve C sütunu her iki gömülü iş kitabında da gizli kalır.

| Yalnızca görünen hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünen hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) eksik değerlerin nasıl görüntüleneceğini kontrol eder; gizli kaynak veriyi ekleyip çıkartmaz. Örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/java/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Bir Grafiğin Veri Aralığını Al**

Mevcut bir sunumda iş kitabı verisini güncellemeden önce, her grafiğin hangi çalışma sayfası hücrelerini kullandığını belirlemek amacıyla kaynak aralıklarını inceleyin. [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) yöntemi, `Sheet1!$A$1:$D$5` gibi çalışma sayfası nitelikli bir formül olarak mevcut veri aralığını döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1'den D5'e kadar olan hücreleri (dahil) tanımlar. Dolar işaretleri mutlak satır ve sütun referanslarını gösterir.

Bu yöntem, grafiği veya iş kitabını değiştirmeden mevcut aralığı okur. Grafik, veri kaynağı olarak bir iş kitabı kullanmıyorsa `InvalidOperationException` fırlatır. Daha fazla bilgi için [ChartData API Referansı](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/) bölümüne bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan kontrol ederek grafik olup olmadığını denetler. Her grafiğin adını ve kaynak aralığını yazar. Bir grafik iş kitabı kullanmıyorsa bir mesaj basar ve bir sonraki grafiğe geçer.

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

## **İş Kitabından Grafik Verilerini Oku ve Yaz**

Aspose.Slides for Java, grafik verileri (Aspose.Cells ile düzenlenmiş) içeren iş kitaplarını okumanıza ve yazmanıza olanak tanıyan [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) ve [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) yöntemlerini sağlar. **Not** grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaytının ilk şekli olarak bir grafik içeren bir sunum kullanır. Gömülü iş kitabını bir bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı iş kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

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

### **İş Kitabı Değişikliği Sonrası Grafik Düzenini Doğrula**

Gömülü bir iş kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal serileri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) yönteminin indeks dışı hata vermesine neden olabilir. Güncellenmiş iş kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaytın ilk şekli olarak bir grafik kullanır. Yorum, iş kitabı düzenlemesinin nerede gerçekleşeceğini işaret eder; çalıştırılabilir örnek orijinal iş kitabını geri yazar ve düzeni bellekte doğrular.

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

        // Gömülü iş kitabı baytlarını burada değiştirin, örneğin Aspose.Cells kullanarak.

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

Serileri temizlemek, iş kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş iş kitabı için gerekli olabilecek serileri ve kategori eşlemelerini yeniden oluşturun.

## **İş Kitabı Hücreleri için Özel Sayı Biçimleri Ayarla**

[IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) kullanarak bir grafiğin gömülü iş kitabındaki sayısal değerlerin nasıl görüneceğini kontrol edin. Örneğin, bir rapor yüzde işaretiyle dört ondalık basamak ve bir katsayıyı beş ondalık basamakla gösterebilir. Her iki değeri de sayısal tutun, böylece hesaplamalar ve grafik çizimi için kullanılabilir kalır.

Bir sayı biçimi gösterimi değiştirir, depolanan değeri değiştirmez. `0.0000%` biçimi `0.125` sayısını `12.5000%` olarak gösterir; sayıyı `12.5` ile değiştirmez. Benzer şekilde, `0.00000` `0.1234567` sayısını `0.12346` olarak gösterir, depolanan değeri yuvarlamaz. Özel biçim boş bir dize (`""`) ise, [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) tarafından döndürülen biçim kullanılır.

Aşağıdaki örnek bir sütun grafik oluşturur ve hücrelerine [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) aracılığıyla erişir. Çalışma sayfası 0'da B2 dönüşüm oranını, C2 katsayısını içerir. Her iki hücre de grafik değerleri sağlar. Örnek ayrıca kaynak biçimlerine bağlı değer etiketlerini etkinleştirir.

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

İş kitabı hücre biçimleri, doğrudan eksenlere veya veri etiketlerine uygulanan biçimlerden ayrıdır. Bu örnekte, her etiket kaynak hücresinin değerini gösterir çünkü [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) `true` olarak ayarlanmıştır ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) `true` olduğu için kaynak sayı biçimini izler. Sunumu kaydedip yeniden açtıktan sonra etiketler `12.5000%` ve `0.12346` olarak gösterilir. Dikey eksen, kendi sayı biçimini [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) ile `0.00` olarak belirler ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) `false` olarak ayarlanır.

Bağımsız bir veri etiketi biçimlendirmek için, kaynak‑bağlantı bayrağını `false` yapıp [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) ile bir biçim atayın. Bu, iş kitabı hücresinin biçimini değiştirmez. Örneğin, bağımsız `0.00` biçimi ilk değeri `0.13` olarak gösterirken B2 hâlâ `12.5000%` gösterir. Doğrudan etiket biçimlendirmesi için [Chart Data Labels](/slides/tr/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) bölümüne bakın.

![Kaynak-bağlantılı etiketleri gösteren sütun grafiği: 12.5000% ve 0.12346 ve bağımsız olarak biçimlendirilmiş sayısal eksen.](custom-cell-formats.png)

## **Bir İş Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarla**

İş kitabı hücrelerinden gelen metni grafik veri etiketleri olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaydına varsayılan verilerle bir balon grafik ekler. İlk serideki ilk üç etiketi oluşturmak için çalışma sayfası 0'da A10:A12 hücrelerini kullanır, hücrelerden etiketleri etkinleştirir ve güncellenen sunumu kaydeder.

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

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) yöntemi bir grafik iş kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve her çalışma sayfasının adını konsola yazar.

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

## **Veri Kaynağı Türünü Belirle**

Seri nokta değerleri doğrudan sayısal sabitler olarak da depolanabilir. Tam bir örnek ve kaydetme/okuma işlemleri için [Seri Değerlerini Sayısal Sabitler Kullanarak Ayarla](/slides/tr/java/chart-series/#set-series-values-using-numeric-literals) bölümüne bakın. Nokta değerlerinin veri kaynağı türü, grafiğin iç veya dış iş kitabı yapılandırmasından ayrı bir kavramdır; sayısal sabitler kullanmak tek başına gömülü iş kitabını kaldırmaz.

Bu örnek, varsayılan verilerle bir 3D sütun grafik oluşturur ve iki seri adını farklı veri kaynaklarıyla ayarlar. İlk ad bir dize sabiti kullanır; ikincisi çalışma sayfası 0'da C1 hücresini kullanır. [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) enumı her ad için kaynağı seçer. Örnek, güncellenen seri adlarıyla sunumu kaydeder.

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

## **Desteklenmeyen Gömülü İş Kitabı Biçimlerini Algıla**

Aspose.Slides, bazı grafiklerde gömülü olabilen Excel ikili iş kitabı (.xlsb) biçimini desteklemez. Desteklenmeyen biçimleri tespit etmek ve bu grafikleri atlamak için [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) üzerindeki [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) yöntemini ve [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) enumını kullanabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü iş kitabı olan her grafik için bir tanı mesajı yazar.

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

        // Desteklenen grafik iş kitabı verilerini burada okuyun veya değiştirin.
    }
} finally {
    presentation.dispose();
}
```

## **Harici İş Kitabı**

Aspose.Slides, grafikler için veri kaynağı olarak harici iş kitaplarını destekler.

### **Harici Bir İş Kitabı Oluştur**

[readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) ve [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) kullanarak gömülü bir grafik iş kitabını dosyaya dışarı aktarabilir ve grafiği bu harici iş kitabına bağlayabilirsiniz.

Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve iş kitabını dışa aktarır. Dosya yazma işlemi tamamlandıktan sonra harici iş kitabını grafik veri kaynağı olarak atar ve bağlantılı sunumu kaydeder.

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

### **Harici Bir İş Kitabı Ayarla**

[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) yöntemiyle bir grafiğe harici bir iş kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem, harici iş kitabının konumu değiştirildiğinde yolu da güncellemek için kullanılabilir.

Uzak konumlardaki veya kaynaklardaki iş kitaplarının verileri doğrudan düzenlenemez, ancak bu iş kitapları harici veri kaynağı olarak kullanılabilir. Bir harici iş kitabı için göreceli bir yol verilirse, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1'de bir seri adı, A2:A4'te kategori adları ve B2:B4'te sayısal değerler bulunan bir harici iş kitabı kullanır. Pasta grafik oluşturur, iş kitabını bağlar ve [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlantılı grafikle sunumu kaydeder.

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

[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) yönteminin `updateChartData` parametresi iş kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` `false` olduğunda yalnızca iş kitabı yolu güncellenir. Grafik verisi hedef iş kitabından yüklenmez veya güncellenmez, bu yüzden iş kitabı mevcut olmayabilir.
* `updateChartData` `true` olduğunda grafik verisi hedef iş kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` `false` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verileri korunur ve kullanılabilir olmayan iş kitabı yüklenmeden sunum kaydedilir.

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

### **Bir Grafiğin Harici Veri Kaynağı İş Kitabı Yolunu Al**

Bir grafiğin bağlı olduğu iş kitabını belirlemek için, grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin ve iş kitabı yolunu alın.

Bu örnek, bir sunumun ilk slaydındaki ilk şekli inceler; eğer bu şekil harici bir iş kitabına bağlı bir grafikse, [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) değerini konsola yazar. Ardından sunumun bir kopyasını kaydeder.

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

Harici iş kitaplarındaki verileri, dahili iş kitaplarındaki gibi düzenleyebilirsiniz. Harici bir iş kitabı yüklenemediğinde bir istisna fırlatılır.

Bu örnek, ilk slaytın ilk şekli olan ve erişilebilir bir harici iş kitabına bağlı bir grafiği kullanır. İlk serideki ilk veri noktasının hücre‑temelli değerini 100 olarak ayarlar ve güncellenen sunumu kaydeder. Hücre değerlerini düzenlemek, bağlı harici XLSX dosyasını güncelleyebilir; bu yüzden orijinali korumak için bir kopya kullanın.

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

### **Grafik Önbelleğinden Bir İş Kitabını Kurtar**

Bir grafik, eksik veya kullanılamayan bir harici iş kitabı kullanıyorsa, Aspose.Slides sunumdaki önbelleğe alınmış veriden grafik iş kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) oluşturun, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) çağırın ve [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) özelliğini `true` yapın; ardından sunumu açın.

Aşağıdaki Java örneği, ilk slaytın ilk şekli olan ve kullanılamayan bir harici iş kitabına başvuran bir grafik için iş kitabı verilerini kurtarır. Kurtarılan verilere [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) ve [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) aracılığıyla erişir:

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

        // Kurtarılan iş kitabı verilerini burada okuyun veya değiştirin.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Harici iş kitabı kullanılamaz ve kurtarma devre dışı bırakılırsa Aspose.Slides bir istisna fırlatır. Önbellekten grafik verisinin kullanılması kabul edilebilir bir geri dönüş ise yalnızca kurtarmayı etkinleştirin; çünkü önbellek, sunum son güncellendiğinden beri harici iş kitabında yapılmış değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir iş kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) ve bir [harici iş kitabı yolu](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) vardır; kaynak harici bir iş kitabı ise tam yolu okuyarak dış bir dosyanın kullanıldığını teyit edebilirsiniz.

**Harici iş kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreceli bir yol belirtirseniz otomatik olarak mutlak yola dönüştürülür. Sunum bu mutlak yolu PPTX dosyasında saklar; bu yüzden iş kitabını taşıdığınızda bağlantının güncellenmesi gerekebilir.

**Ağ kaynakları/paylaşımları üzerindeki iş kitaplarını kullanabilir miyim?**

Evet, bu tür iş kitapları harici veri kaynağı olarak kullanılabilir. Ancak Aspose.Slides'den uzak iş kitaplarını doğrudan düzenlemek desteklenmez; yalnızca bir kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX'i üzerine yazar mı?**

Sunum, harici dosyaya bir [bağlantı](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) saklar. Hücre‑temelli grafik verilerini düzenlemek, bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinal iş kitabının değişmemesi gerekiyorsa bir kopyasını kullanın.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlantı sırasında şifre kabul etmez. Yaygın bir yaklaşım, şifreyi önceden kaldırmak veya bir şifre çözülmüş kopya hazırlamaktır (örneğin, [Aspose.Cells](https://reference.aspose.com/cells/java/) kullanarak) ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı harici iş kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, o dosyanın güncellenmesi her grafiğin bir sonraki veri yüklemesinde yansıtılır.