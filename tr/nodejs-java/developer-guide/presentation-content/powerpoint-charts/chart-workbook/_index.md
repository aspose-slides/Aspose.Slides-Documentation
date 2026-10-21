---
title: JavaScript Kullanarak Sunumlarda Grafik Çalışma Kitaplarını Yönet
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/nodejs-java/chart-workbook/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketi olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme adımlarını gösterir.

Ayrıca harici çalışma kitaplarını grafik veri kaynakları olarak kullanmayı kapsar. Örnekler, harici bir çalışma kitabı oluşturma ve atama, bir grafiğe bağlı harici çalışma kitabının yolunu alma ve çalışma kitabı kullanılabilir olduğunda grafik verisini düzenleme süreçlerini gösterir.

Eksik verileri temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve mevcut görüntüleme modlarının bir çizgi grafiği karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/nodejs-java/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardaki Verileri Dahil Et**

Gizli çalışma sayfası satır ve sütunlarından veri çizdirilip çizdirilmeyeceğini kontrol etmek için [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) yöntemini kullanın. Yalnızca görünür hücreleri çizdirmek için `true`, hem görünür hem de gizli hücreleri dahil etmek için `false` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez veya göstermez.

[örnek sunum](hidden-source-data.pptx) ilk slaytındaki ilk şekil olarak bir sütun grafik içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` kaynak aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) ile erişin ve gizli durumlarını incelemek için [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) yöntemini okuyun. Bu metod gizli durumunu değiştirmeden bildirir. Bu dosyada B2 görünür, B3 gizli satıra ait ve C2 gizli sütuna aittir; örnek sırasıyla `false`, `true` ve `true` değerlerini yazdırır.

Bu örnek için çizim ayarı değiştirildikten sonra grafik verisini yenileyin: gömülü çalışma kitabını [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) ile tutun ve [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) ile yeniden yükleyin. Tüm hücreleri içerirken, gizli Şubat kategorisini de geri yüklemek için [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) yöntemini kullanın; yalnızca bayrağı değiştirmek bu örneğin önbelleğe alınmış grafik verisini ve kategori etiketlerini yenilemek için yeterli değildir. Örnek, döndürülen Node.js tamponunu Java bayt dizisine çevirerek yazma metoduna iletir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Gömülü çalışma kitabından grafik verisini yenile.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Gizli kategoriler dahil olmak üzere tam kaynak aralığını geri yükle.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Örnek, sunumu iki sürüm olarak kaydeder: sadece görünür Perakende değerleri (10 ve 20) içeren bir sürüm ve tüm altı değeri içeren bir diğer sürüm. Aşağıdaki görseller iki çizim modunu gösterir. Satır 3 ve C sütunu her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart ayları için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart ayları için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değeri olan bir gizli hücre, boş bir hücreden farklıdır. Eksik değerlerin nasıl gösterileceğini kontrol eden [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) yöntemi, gizli kaynak verilerini dahil etmez ya da hariç tutmaz. Örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/nodejs-java/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Bir Grafiğin Veri Aralığını Al**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, her grafiğin kullandığı çalışma sayfası hücrelerini belirlemek amacıyla kaynak aralıklarını inceleyin. [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) metodu, `Sheet1!$A$1:$D$5` gibi bir çalışma sayfası nitelikli formül olarak geçerli veri aralığını döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1‑D5 aralığını kapsar. `$` işaretleri mutlak satır ve sütun referanslarını gösterir.

Metod, grafiği veya çalışma kitabını değiştirmeden geçerli aralığı okur. Grafik veri kaynağı olarak bir çalışma kitabı kullanmıyorsa `InvalidOperationException` fırlatır. Daha fazla bilgi için [ChartData API Referansı](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) sayfasına bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan kontrol ederek grafik olup olmadığını denetler. Her grafiğin adını ve kaynak aralığını yazdırır. Grafik bir çalışma kitabı kullanmıyorsa bir mesaj verir ve bir sonraki grafiğe geçer.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Bir Çalışma Kitabından Grafik Verisini Oku ve Yaz**

Aspose.Slides for Node.js via Java, grafik verisi (Aspose.Cells ile düzenlenmiş) içeren çalışma kitaplarını okuma ve yazma imkanı sağlayan [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) ve [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) yöntemlerini sunar. **Not**: Grafik verisi aynı biçimde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaytının ilk şekli olarak bir grafik içeren bir sunum kullanır. Gömülü çalışma kitabını bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler hafızada kalır; örnek sunumu kaydetmez.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Çalışma Kitabı Değiştirildikten Sonra Grafik Düzenini Doğrula**

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını tutar. Bu uyumsuzluk, [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) metodunun indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaytın ilk şekli olarak bir grafik kullanır. Yorum satırı, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini işaret eder; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve hafızada düzeni doğrular.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // Workbook baytlarını burada değiştirin, örneğin Aspose.Cells kullanarak.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Koleksiyonları temizlemek, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli seri ve kategori eşlemelerini yeniden oluşturun ve ardından grafiği kullanın.

## **Çalışma Kitabı Hücreleri İçin Özel Sayı Biçimleri Belirle**

[ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) yöntemi, grafiğin gömülü çalışma kitabındaki sayısal değerlerin nasıl görüneceğini kontrol eder. Örneğin bir rapor, dönüşüm oranını yüzde olarak dört ondalık basamak ve katsayısını beş ondalık basamakla gösterebilir. Her iki değeri de sayısal tutun; böylece hesaplamalar ve grafik çizimi için kullanılabilir kalırlar.

Sayı biçimi yalnızca gösterimi değiştirir, saklanan değeri etkilemez. `0.0000%` biçimi `0.125` sayısını `12.5000%` olarak gösterir; saklanan sayı `12.5` olarak değiştirilmez. Benzer şekilde `0.00000` biçimi `0.1234567` sayısını `0.12346` olarak gösterir, ancak saklanan değeri yuvarlamaz. Özel biçim boş bir dize (`""`) ise, [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) tarafından döndürülen biçim kullanılır.

Aşağıdaki örnek bir sütun grafik oluşturur ve hücrelerine [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) üzerinden erişir. Çalışma sayfası 0’da, B2 dönüşüm oranını ve C2 katsayısını içerir. Her iki hücre de grafik değerini sağlar. Örnek ayrıca, kaynak biçimlere bağlı değer etiketlerini etkinleştirir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Çalışma kitabı hücre biçimleri, doğrudan eksenlere veya veri etiketlerine uygulanan biçimlerden ayrıdır. Bu örnekte, her etiket [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) `true` olduğu için kaynak hücre değerini gösterir ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) `true` olduğu için kaynak sayı biçimini izler. Sunumu kaydedip yeniden açtıktan sonra etiketler `12.5000%` ve `0.12346` olarak görüntülenir. Dikey eksen, kendi sayı biçimini [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) `0.00` ile belirler; [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) `false` olarak ayarlanmıştır.

Bir veri etiketini bağımsız biçimlendirmek için, kaynak‑bağlantı bayrağını `false` yapın ve [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) ile bir biçim atayın. Bu, çalışma kitabı hücresinin biçimini değiştirmez. Örneğin, bağımsız bir etiket biçimi `0.00` ilk değeri `0.13` olarak gösterirken B2 hâlâ `12.5000%` gösterir. Doğrudan etiket biçimlendirmesi için [Grafik Veri Etiketleri](/slides/tr/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) bölümüne bakın.

Aşağıdaki görsel, sunumu kaydedip yeniden açtıktan sonra render edilmiştir:

![Kaynak‑bağlantılı etiketleri ile 12.5000% ve 0.12346 gösteren sütun grafik, ayrıca bağımsız biçimlendirilmiş sayısal eksen.](custom-cell-formats.png)

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarla**

Çalışma kitabı hücrelerindeki metni grafik veri etiketi olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına varsayılan veriyle bir balon grafik ekler. İlk serideki ilk üç etiketi oluşturmak için çalışma sayfası 0’da A10:A12 hücrelerini kullanır, hücrelerden etiketleri etkinleştirir ve güncellenmiş sunumu kaydeder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Çalışma Sayfalarını Yönet**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) yöntemi, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan veriyle bir pasta grafik oluşturur ve her çalışma sayfasının adını konsola yazar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Veri Kaynağı Türünü Belirle**

Bu örnek, varsayılan veriyle bir 3B sütun grafik oluşturur ve iki seri ismini farklı veri kaynakları kullanarak ayarlar. İlk isim bir dize literalidir; ikincisi çalışma sayfası 0’da C1 hücresinden alınır. [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) enum’u, her isim için kaynağı seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) üzerindeki `getEmbeddedWorkbookType` yöntemi ile [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) enum’u birleştirilerek desteklenmeyen biçimler tespit edilebilir ve bu grafikler atlanabilir. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü çalışma kitabı içeren her grafik için bir tanı mesajı yazar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Burada desteklenen grafik çalışma kitabı verilerini okuyun veya değiştirin.
    }
} finally {
    presentation.dispose();
}
```

## **Harici Çalışma Kitabı**

Aspose.Slides, grafikler için harici çalışma kitaplarını veri kaynağı olarak kullanmayı destekler.

### **Harici Çalışma Kitabı Oluştur**

[readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) ve [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) yöntemlerini kullanarak gömülü bir grafik çalışma kitabını bir dosyaya dışa aktarabilir ve grafiği bu harici çalışma kitabına bağlayabilirsiniz.

Bu örnek, varsayılan veriyle bir pasta grafik oluşturur ve çalışma kitabını dışa aktarır. Harici çalışma kitabını grafik veri kaynağı olarak atamadan önce dosya yazımını tamamlar, ardından bağlantılı sunumu kaydeder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **Harici Çalışma Kitabı Ata**

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) yöntemiyle bir grafiğe harici bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem aynı zamanda harici çalışma kitabının yolu değiştiğinde güncellemek için de kullanılabilir (dosya taşınmışsa).

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarının verileri düzenlenemez, ancak hâlâ harici veri kaynağı olarak kullanılabilir. Bir harici çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1’de seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler bulunan bir harici çalışma kitabı kullanır. Pasta grafik oluşturur, çalışma kitabını bağlar ve [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlantılı grafikle birlikte sunumu kaydeder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) metodundaki `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` `false` olduğunda yalnızca çalışma kitabı yolu güncellenir. Grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez; bu nedenle çalışma kitabı mevcut olmayabilir.
* `updateChartData` `true` olduğunda grafik verisi hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` `false` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verileri korunur ve kullanılabilir olmayan çalışma kitabı yüklenmeden sunum kaydedilir.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Al**

Bir grafiğe bağlı çalışma kitabını belirlemek için, grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, harici bir çalışma kitabına bağlı bir grafik içeren bir sunumun ilk slaydındaki ilk şekli inceler. Eğer grafik harici bir çalışma kitabına bağlıysa, [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) metodunu konsola yazar ve ardından sunumun bir kopyasını kaydeder.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Grafik Verisini Düzenle**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu örnek, ilk slaydın ilk şekli olarak bir grafik kullanır ve erişilebilir bir harici çalışma kitabına bağlıdır. İlk serideki ilk veri noktasının hücre‑tabanlı değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlantılı harici XLSX dosyasını güncelleyebilir; bu nedenle orijinali korumak istiyorsanız bir kopya kullanın.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Grafik Önbelleğinden Çalışma Kitabını Kurtar**

Bir grafik, eksik veya kullanılamayan bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınmış verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) oluşturun, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/) çağırın ve [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) özelliğini `true` yaparak sunumu açmadan önce ayarlayın.

Aşağıdaki JavaScript örneği, ilk slaydın ilk şekli olarak bir grafik ve kullanılamayan bir harici çalışma kitabına referans içeren bir senaryoda çalışma kitabı verilerini kurtarır. Kurtarılan verilere [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) ve [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) üzerinden erişir:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Kurtarılan çalışma kitabı verilerini burada okuyun veya değiştirin.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Harici çalışma kitabı kullanılamaz ve kurtarma devre dışı bırakıldıysa, Aspose.Slides bir istisna fırlatır. Önbellekten grafik verisini kullanmak kabul edilebilecek bir geri dönüş ise, kurtarmayı etkinleştirin; çünkü önbellek, sunum son güncellendiğinde harici çalışma kitabında yapılmış değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin [veri kaynağı türü](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) ve [harici çalışma kitabı yolu](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) vardır; kaynak harici bir çalışma kitabıysa, tam yolu okuyarak bir harici dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreli bir yol belirtirseniz, otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu yüzden çalışma kitabını taşımak, bağlantının güncellenmesini gerektirebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak Aspose.Slides'ten uzaktaki çalışma kitaplarını doğrudan düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides sunumu kaydederken harici XLSX dosyasını üzerine yazıyor mu?**

Sunum, [harici dosyaya bir bağlantı](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) saklar. Hücre‑tabanlı grafik verisini düzenlemek, bağlantılı yerel XLSX dosyasını da güncelleyebilir. Orijinal dosyanın değişmemesini istiyorsanız, çalışma kitabının bir kopyasını kullanın.

**Harici dosya parola korumalıysa ne yapmalıyım?**

Aspose.Slides bağlantı sırasında bir parola kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak veya bir şifre çözülmüş kopya hazırlamaktır (örneğin [Aspose.Cells](https://reference.aspose.com/cells/java/) kullanarak) ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosyadaki bir güncelleme tüm grafiklerde bir sonraki veri yüklemesinde yansır.