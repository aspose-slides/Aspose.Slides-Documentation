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
description: "Aspose.Slides for Android via Java'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yönetin ve sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme yöntemlerini gösterir.

Ayrıca, harici çalışma kitaplarının grafik veri kaynakları olarak kullanılmasını da kapsar. Örnekler, harici bir çalışma kitabı oluşturup atamayı, bir grafiğe bağlanan harici çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemeyi gösterir.

Eksik veri temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve kullanılabilir gösterim modlarının bir çizgi grafiği karşılaştırmasını görmek üzere [Control the Display of Empty Cells](/slides/tr/androidjava/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Et**

[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) yöntemini kullanarak bir grafiğin gizli çalışma sayfası satır ve sütunlarından veri çizip çizmeyeceğini kontrol edin. Görünür hücreleri çizmek için `true`, hem görünür hem de gizli hücreleri dahil etmek için `false` olarak ayarlayın. Bu ayar yalnızca grafiğin çizilmesini etkiler; çalışma sayfası satır veya sütunlarını gizlemez veya göstermez.

[örnek sunum](hidden-source-data.pptx) ilk slaytının ilk şekli olarak bir sütun grafiği içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` kaynak aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) üzerinden erişin ve gizli durumlarını incelemek için [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) yöntemini okuyun. Bu yöntem gizli durumunu değiştirmeden raporlar. Bu dosyada B2 görünür, B3 gizli satıra ait ve C2 gizli sütuna ait; örnek sırasıyla `false`, `true` ve `true` değerlerini yazdırır.

Bu örnek için, çizim ayarı değiştirildikten sonra grafik verisini yenileyin: gömülü çalışma kitabını [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) ile tutun ve [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de içerecek şekilde tam aralığı geri yüklemek için [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) kullanın. Sadece bayrağı değiştirmek, bu örnek için önbelleğe alınmış grafik verisi ve kategori etiketlerini yenilemek için yeterli değildir.

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

Örnek, sunumun iki sürümünü kaydeder: yalnızca görünür Perakende değerleri (10 ve 20) içeren bir sürüm ve tüm altı değeri içeren bir sürüm. Aşağıdaki görseller iki çizim modunu gösterir. Satır 3 ve C sütunu her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. Eksik değerlerin nasıl gösterileceğini kontrol eden [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) yöntemi, gizli kaynak verilerini dahil etmez veya hariç tutmaz. Örnek için bakınız [Control the Display of Empty Cells](/slides/tr/androidjava/chart-series/#control-the-display-of-empty-cells).

## **Bir Grafiğin Veri Aralığını Al**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, her bir grafiğin kullandığı çalışma sayfası hücrelerini belirlemek amacıyla kaynak aralıklarını inceleyin. [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) yöntemi, `Sheet1!$A$1:$D$5` gibi bir çalışma sayfası nitelikli formülü mevcut veri aralığı olarak döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1‑D5 hücrelerini kapsar. `$` işaretleri mutlak satır ve sütun referanslarını gösterir.

Yöntem, grafiği veya onun çalışma kitabını değiştirmeden mevcut aralığı okur. Grafik bir çalışma kitabını veri kaynağı olarak kullanmıyorsa, `InvalidOperationException` hatası verir. Daha fazla bilgi için [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/) bölümüne bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan kontrol ederek grafik olup olmadığını belirler. Her grafiğin adını ve kaynak aralığını yazdırır. Grafik bir çalışma kitabı kullanmıyorsa, bir mesaj yazdırıp bir sonraki grafiğe geçer.

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

Aspose.Slides for Android via Java, grafik verileri (Aspose.Cells ile düzenlenmiş) içeren çalışma kitaplarını okumanıza ve yazmanıza olanak tanıyan [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) ve [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) yöntemlerini sunar. **Not** grafik verileri aynı biçimde düzenlenmiş ya da kaynağa benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaytının ilk şekli olarak bir grafiği olan bir sunum kullanır. Gömülü çalışma kitabını bir bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellek içinde kalır; örnek sunumu kaydetmez.

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

### **Çalışma Kitabı Değişikliklerinden Sonra Grafik Düzenini Doğrula**

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal serileri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) yönteminin indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaytın ilk şekli olarak bir grafiği kullanır. Yorum, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini işaret eder; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve bellekte düzeni doğrular.

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

        // Çalışma kitabı baytlarını burada değiştirin, örneğin Aspose.Cells kullanarak.

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

Koleksiyonların temizlenmesi, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli serileri ve kategori eşlemelerini yeniden oluşturun.

## **Çalışma Kitabı Hücreleri İçin Özel Sayı Biçimleri Ayarla**

[IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) yöntemini kullanarak bir grafiğin gömülü çalışma kitabındaki sayısal değerlerin nasıl görüneceğini kontrol edin. Örneğin, bir rapor yüzde olarak dört ondalık basamak ve bir katsayı beş ondalık basamakla görüntülenmek isteyebilir. Her iki değeri de sayısal tutun, böylece hesaplamalar ve grafik çizimi için kullanılabilir.

Bir sayı biçimi gösterimi değiştirir, saklanan değeri değiştirmez. `0.0000%` biçimi `0.125` değerini `12.5000%` olarak gösterir; saklanan sayı `12.5` ile değiştirilmez. Benzer şekilde, `0.00000` biçimi `0.1234567` değerini `0.12346` olarak gösterir ve saklanan değer yuvarlanmaz. Özel biçim boş bir dizge (`""`) ise, [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) tarafından döndürülen biçim kullanılır.

Aşağıdaki örnek bir sütun grafiği oluşturur ve hücrelerine [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) üzerinden erişir. Çalışma sayfası 0'da B2 dönüşüm oranını, C2 ise katsayıyı içerir. Her iki hücre de grafik değerleri sağlar. Örnek ayrıca kaynak biçimlere bağlı veri etiketlerini etkinleştirir.

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

Çalışma kitabı hücre biçimleri, doğrudan eksenlere veya veri etiketlerine ayarlanan biçimlerden ayrıdır. Bu örnekte her etiket, [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) `true` olduğu için kaynak hücresinin değerini gösterir ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) `true` olduğu için kaynak sayı biçimini takip eder. Sunumu kaydedip yeniden açtıktan sonra etiketler `12.5000%` ve `0.12346` olarak görüntülenir. Dikey eksen, kendi sayı biçimini [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) `0.00` olarak ayarlar ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) `false` olarak ayarlanır.

Bir veri etiketini bağımsız biçimlendirmek için kaynak‑bağlantı bayrağını `false` yapın ve [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) ile bir biçim atayın. Bu, çalışma kitabı hücresinin biçimini değiştirmez. Örneğin, bağımsız bir etiket biçimi `0.00` ilk değeri `0.13` olarak gösterirken B2 hâlâ `12.5000%` gösterir. Doğrudan etiket biçimlendirme için [Chart Data Labels](/slides/tr/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) bölümüne bakın.

Aşağıdaki görsel, sunum kaydedildikten ve yeniden açıldıktan sonra render edilmiştir:

![Kaynak‑bağlantılı etiketlerin 12.5000% ve 0.12346 gösterdiği ve bağımsız biçimlendirilmiş sayısal eksenin bulunduğu sütun grafiği.](custom-cell-formats.png)

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarla**

Çalışma kitabı hücrelerinden gelen metni grafik veri etiketleri olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına varsayılan verili bir balon grafiği ekler. İlk serinin ilk üç etiketi için çalışma sayfası 0'da A10:A12 hücrelerini kullanır, hücrelerden etiketleri etkinleştirir ve güncellenmiş sunumu kaydeder.

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

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) yöntemi, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan verili bir pasta grafiği oluşturur ve her bir çalışma sayfasının adını konsola yazar.

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

Bu örnek, varsayılan verili bir 3D sütun grafiği oluşturur ve iki serinin adını farklı veri kaynaklarıyla ayarlar. İlk ad bir dize sabiti iken, ikinci ad çalışma sayfası 0'da C1 hücresinden alınır. [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) enum​ı her bir ad için kaynağı seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

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

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) biçimini desteklemez. [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) üzerindeki [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) yöntemini, [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) enum​u ile birlikte kullanarak desteklenmeyen biçimleri tespit edebilir ve bu grafikleri atlayabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaytındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü çalışma kitabına sahip her grafik için tanılayıcı bir mesaj yazar.

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

### **Harici Çalışma Kitabı Oluştur**

[readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) ve [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) yöntemlerini kullanarak gömülü bir grafik çalışma kitabını bir dosyaya aktarabilir ve grafiği o harici çalışma kitabına bağlayabilirsiniz.

Bu örnek, varsayılan verili bir pasta grafiği oluşturur ve çalışma kitabını dışa aktarır. Dosya yazma işlemini tamamladıktan sonra harici çalışma kitabını grafik veri kaynağı olarak atar ve bağlantılı sunumu kaydeder.

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

### **Harici Çalışma Kitabı Ayarla**

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) yöntemini kullanarak bir grafiğe harici bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem aynı zamanda harici çalışma kitabının yolunu güncellemek için de kullanılabilir (dosya taşındıysa).

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri doğrudan düzenleyemezsiniz, ancak bu çalışma kitaplarını harici veri kaynağı olarak kullanabilirsiniz. Bir harici çalışma kitabının göreli yolu sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1'de bir seri adı, A2:A4'te kategori adları ve B2:B4'te sayısal değerler bulunan bir harici çalışma kitabı kullanır. Pasta grafiği oluşturur, çalışma kitabını bağlar ve [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlantılı grafiği içeren sunumu kaydeder.

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

[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) yönteminin `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini denetler.

* `updateChartData` `false` olduğunda yalnızca çalışma kitabı yolu güncellenir. Grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez, bu nedenle çalışma kitabı mevcut olmayabilir.
* `updateChartData` `true` olduğunda grafik verisi hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` `false` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verisini korur ve mevcut olmayan çalışma kitabını yüklemeden sunumu kaydeder.

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

Bu örnek, bir sunumun ilk slaytındaki ilk şekli harici bir çalışma kitabına bağlanmış bir grafik olup olmadığını inceler. Eğer öyleyse, [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) metodunu konsola yazar ve ardından sunumun bir kopyasını kaydeder.

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

### **Grafik Verilerini Düzenle**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki verileri düzenlediğiniz gibi değiştirebilirsiniz. Harici bir çalışma kitabı yüklenemezse bir istisna fırlatılır.

Bu örnek, ilk slaytın ilk şekli olarak bir grafiği kullanır ve erişilebilir bir harici çalışma kitabına bağlanır. İlk serinin ilk veri noktasının hücre‑destekli değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlı harici XLSX dosyasını güncelleyebilir; bu nedenle orijinal çalışma kitabını korumak istiyorsanız bir kopya kullanın.

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

### **Grafik Önbelleğinden Bir Çalışma Kitabını Kurtar**

Bir grafik, eksik veya erişilemeyen bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınan veriden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) oluşturun, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) çağırın ve [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) özelliğini `true` olarak ayarlayın; ardından sunumu açın.

Aşağıdaki Java örneği, ilk slaytın ilk şekli olarak bir grafiği ve erişilemeyen bir harici çalışma kitabını referans alan bir senaryoda çalışma kitabı verilerini kurtarır. Kurtarılan verilere [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) ve [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) aracılığıyla erişir:

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

        // Geri kurtarılan çalışma kitabı verilerini burada okuyun veya değiştirin.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Harici çalışma kitabı mevcut değilse ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Ön bellekten gelen grafik verisinin kullanılabilir bir geri dönüş seçeneği olduğu durumlarda yalnızca kurtarmayı etkinleştirin; çünkü ön bellek, sunum en son güncellendiğinden sonra harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin [veri kaynağı türü](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) ve bir [harici çalışma kitabı yolu](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) vardır; kaynak harici bir çalışma kitabı ise tam yolu okuyarak bir harici dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu ve nasıl saklanıyor?**

Evet. Göreli bir yol belirtirseniz, otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu nedenle çalışma kitabını taşıdığınızda bağlantıyı güncellemeniz gerekebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides'tan doğrudan uzak çalışma kitaplarını düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Sunum, harici dosyaya bir [bağlantı](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) saklar. Hücre‑destekli grafik verilerini düzenlemek, bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinal dosyanın değişmemesi gerekiyorsa bir kopya kullanın.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlanma sırasında şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak veya şifresiz bir kopya (örneğin, [Aspose.Cells](https://reference.aspose.com/cells/java/)) hazırlamaktır ve bu kopyaya bağlanmaktır.

**Birden çok grafik aynı harici çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklemede her grafiğe yansır.