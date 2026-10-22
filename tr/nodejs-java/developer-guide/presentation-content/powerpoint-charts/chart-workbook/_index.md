---
title: JavaScript kullanarak Sunumlarda Grafik Çalışma Kitaplarını Yönetme
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
description: "Aspose.Slides for Node.js via Java'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını sorunsuz yönetin ve sunum verilerinizi basitleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca harici çalışma kitaplarını grafik veri kaynakları olarak kullanmayı da kapsar. Örnekler, harici bir çalışma kitabı oluşturup atamayı, bir grafikle ilişkilendirilmiş harici çalışma kitabının yolunu almayı ve çalışma kitabı kullanılabilir olduğunda grafik verisini düzenlemeyi gösterir.

Eksik veri temsil eden çalışma kitabı hücreleri için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/nodejs-java/chart-series/) sayfasına bakın; boş bir hücre ile sıfır arasındaki farkı ve mevcut gösterim modlarının bir çizgi grafik karşılaştırmasını öğrenebilirsiniz.

## **Gizli Satır ve Sütunlardan Veri Dahil Et**

[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) yöntemini kullanarak bir grafiğin gizli çalışma sayfası satırları ve sütunlarından veri çizip çizmeyeceğini kontrol edin. Yalnızca görünür hücreleri çizmek için `true`, hem görünür hem de gizli hücreleri dahil etmek için `false` olarak ayarlayın. Bu ayar grafiğin çizimini kontrol eder; çalışma sayfası satırlarını veya sütunlarını gizlemez veya göstermez.

[örnek sunum](hidden-source-data.pptx) içinde ilk slaytının ilk şekli olarak bir sütun grafik bulunur. Gömülü çalışma sayfası `Sheet1`, `A1:C4` aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) ile erişin ve gizli durumlarını incelemek için [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) özelliğini okuyun. Bu yöntem gizli durumu değiştirmeden raporlar. Bu dosyada B2 görünür, B3 gizli satıra, C2 ise gizli sütuna aittir; örnek sırasıyla `false`, `true` ve `true` değerlerini yazdırır.

Bu örnek için çizim ayarı değiştirildikten sonra grafik verisini yenileyin: gömülü çalışma kitabını [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) ile tutun ve [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) ile yeniden yükleyin. Tüm hücreleri dahil ederken gizli Şubat kategorisini de içerecek şekilde tam aralığı geri yüklemek için [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) kullanın. Bayrağı yalnızca değiştirmek bu örneğin önbelleğe alınmış grafik verisini ve kategori etiketlerini yenilemek için yeterli değildir. Örnek, yazma metoduna geçmeden önce döndürülen Node.js tamponunu bir Java bayt dizisine dönüştürür.

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

            // Grafik verilerini gömülü çalışma kitabından yenileyin.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Gizli kategoriler dahil olmak üzere tam kaynak aralığını geri yükleyin.
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

Örnek, yalnızca görünür Perakende değerlerini (10 ve 20) içeren bir sürüm ve tüm altı değeri içeren bir sürüm olmak üzere iki sunum versiyonu kaydeder. Aşağıdaki görseller iki çizim modunu gösterir. 3. satır ve C sütunu her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart ayları için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart ayları için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) eksik değerlerin nasıl görüntüleneceğini kontrol eder; gizli kaynak veriyi içermez veya dışlamaz. Örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/nodejs-java/chart-series/#control-the-display-of-empty-cells) sayfasına bakın.

## **Grafiğin Veri Aralığını Al**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, her grafiğin kullandığı çalışma sayfası hücrelerini belirlemek üzere kaynak aralıklarını inceleyin. [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) yöntemi, mevcut veri aralığını `Sheet1!$A$1:$D$5` gibi bir çalışma sayfası nitelikli formül olarak döndürür. Burada `Sheet1` çalışma sayfası adıdır, `!` hücre aralığından ayırır ve `$A$1:$D$5` A1'den D5'e kadar (dahil) hücreleri tanımlar. Dolar işaretleri mutlak satır ve sütun referanslarını gösterir.

Bu yöntem grafiği veya çalışma kitabını değiştirmeden mevcut aralığı okur. Grafik bir çalışma kitabını veri kaynağı olarak kullanmıyorsa `InvalidOperationException` fırlatır. Daha fazla bilgi için [ChartData API Referansı](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) sayfasına bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan grafikleri için inceler. Her grafiğin adını ve kaynak aralığını yazdırır. Bir grafik çalışma kitabı kullanmıyorsa bir mesaj yazdırır ve bir sonraki grafiğe geçer.

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

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides for Node.js via Java, [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) ve [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) yöntemlerini sunar; bu yöntemler grafik verileri (Aspose.Cells ile düzenlenen) içeren çalışma kitaplarını okumanıza ve yazmanıza olanak tanır. **Not** grafik verilerinin aynı biçimde ya da kaynağa benzer bir yapıda düzenlenmiş olması gerekir.

Bu örnek, ilk slaytının ilk şekli olarak bir grafik içeren bir sunum kullanır. Gömülü çalışma kitabını bir bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

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

Gömülü bir çalışma kitabını değiştirilmiş bir kitapla değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) metodunun indeks dışı hata vermesine yol açabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaytın ilk şekli olarak bir grafik kullanır. Yorum, çalışma kitabı düzenlemenin nerede gerçekleşeceğini işaret eder; çalışan örnek orijinal çalışma kitabını geri yazar ve bellekteki düzeni doğrular.

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

        // Burada çalışma kitabı baytlarını değiştirin, örneğin Aspose.Cells kullanarak.

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

Koleksiyonların temizlenmesi, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli seri ve kategori eşlemeleri yeniden oluşturulmalıdır.

## **Çalışma Kitabı Hücreleri İçin Özel Sayı Formatları Ayarla**

[ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) yöntemini kullanarak bir grafiğin gömülü çalışma kitabındaki sayısal değerlerin nasıl görüneceğini kontrol edin. Örneğin bir rapor, dönüşüm oranını yüzde olarak dört ondalık basamak ve katsayısını beş ondalık basamak ile gösterebilir. Her iki değeri de sayısal tutun; böylece hesaplamalar ve grafik çizimi için kullanılabilir.

Sayı formatı, görüntüyü değiştirir, saklanan değeri değil. `0.0000%` formatı `0.125` değerini `12,5000%` olarak gösterir; saklanan sayı `12.5` olmaz. Benzer şekilde, `0.00000` `0.1234567` değerini `0.12346` olarak gösterir, fakat saklanan değeri yuvarlamaz. Özel format boş bir dize (`""`) ise, [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) tarafından döndürülen format kullanılır.

Aşağıdaki örnek bir sütun grafik oluşturur ve hücrelerine [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) ile erişir. Çalışma sayfası 0'da B2 dönüşüm oranını, C2 ise katsayısını içerir. Her iki hücre de grafik değerlerini sağlar. Örnek ayrıca kaynak formatlara bağlı veri etiketlerini etkinleştirir.

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

Çalışma kitabı hücre formatları, doğrudan eksenlere veya veri etiketlerine ayarlanan formatlardan ayrı tutulur. Bu örnekte her etiket, [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) `true` olduğundan kaynak hücrenin değerini gösterir ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) `true` olduğundan kaynak sayı formatını izler. Sunumu kaydedip tekrar açtıktan sonra etiketler `12,5000%` ve `0,12346` biçiminde görüntülenir, aşağıda gösterildiği gibi. Dikey eksen kendi sayı formatını, [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) `0.00` olarak ayarlandı ve [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) `false` olarak ayarlandı.

Bağımsız bir veri etiketini biçimlendirmek için kaynak‑bağlantı bayrağını `false` yapın ve [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) ile bir format atayın. Bu, çalışma kitabı hücresinin formatını değiştirmez. Örneğin `0.00` bağımsız etiket formatı ilk değeri `0,13` olarak gösterirken B2 hâlâ `12,5000%` gösterir. Doğrudan etiket biçimlendirme için [Grafik Veri Etiketleri](/slides/tr/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) sayfasına bakın.

![Kaynak bağlantılı etiketlerle 12,5000% ve 0,12346 gösteren sütun grafik ve bağımsız biçimlendirilmiş sayısal eksen.](custom-cell-formats.png)

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarla**

Grafik veri etiketleri olarak çalışma kitabı hücrelerindeki metni kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaydına varsayılan verilerle bir balon grafik ekler. İlk serideki ilk üç etiket için çalışma sayfası 0'da A10:A12 aralığını kullanır, hücrelerden etiketleri etkinleştirir ve güncellenmiş sunumu kaydeder.

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

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) yöntemi, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve her çalışma sayfasının adını konsola yazar.

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

Seri nokta değerleri doğrudan sayısal sabitler olarak da depolanabilir. Kaydetme ve okuma örnekleri için [Seri Değerlerini Sayısal Sabitler Kullanarak Ayarlama](/slides/tr/nodejs-java/chart-series/#set-series-values-using-numeric-literals) sayfasına bakın. Nokta değerlerinin kaynak türü, grafiğin iç veya dış çalışma kitabı yapılandırmasından bağımsızdır; sayısal sabitler kullanmak tek başına gömülü çalışma kitabını kaldırmaz.

Bu örnek, varsayılan verilerle bir 3B sütun grafik oluşturur ve iki seri adını farklı veri kaynaklarıyla ayarlar. İlk ad bir dize sabiti; ikincisi ise çalışma sayfası 0'da C1 hücresidir. [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) enumu, her ad için kaynağı seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Formatlarını Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) üzerindeki `getEmbeddedWorkbookType` metodunu ve [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) enumunu kullanarak desteklenmeyen formatları tespit edebilir ve bu grafikleri atlayabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaydındaki şekilleri inceler, grafik olmayanları atlar ve .xlsb gömülü çalışma kitabı bulunan her grafik için tanılayıcı bir mesaj yazar.

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

        // Desteklenen grafik çalışma kitabı verilerini burada okuyun veya değiştirin.
    }
} finally {
    presentation.dispose();
}
```

## **Harici Çalışma Kitabı**

Aspose.Slides, grafikler için veri kaynağı olarak harici çalışma kitaplarını kullanmayı destekler.

### **Harici Çalışma Kitabı Oluştur**

[readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) ve [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) kullanarak bir gömülü grafik çalışma kitabını bir dosyaya dışa aktarın ve grafiği bu harici çalışma kitabına bağlayın.

Bu örnek, varsayılan verilerle bir pasta grafik oluşturur ve çalışma kitabını dışa aktarır. Dosya yazma işlemi tamamlandıktan sonra harici çalışma kitabını veri kaynağı olarak atar, ardından bağlantılı sunumu kaydeder.

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

### **Harici Çalışma Kitabı Ayarla**

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) yöntemiyle bir grafiğe harici bir çalışma kitabı veri kaynağı olarak atayabilirsiniz. Bu yöntem, harici çalışma kitabının konumu (dosya taşındıysa) güncellenmek istendiğinde de kullanılabilir.

Uzaktaki konumlarda veya kaynaklarda saklanan çalışma kitaplarındaki verileri doğrudan düzenleyemezsiniz, ancak bu çalışma kitapları harici veri kaynağı olarak kullanılabilir. Bir harici çalışma kitabının göreli yolu sağlanırsa, tam yola otomatik olarak dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1'de bir seri adı, A2:A4'te kategori adları ve B2:B4'te sayısal değerler içeren bir harici çalışma kitabı kullanır. Pasta grafik oluşturur, çalışma kitabını bağlar ve [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Bağlantılı grafiği içeren sunumu kaydeder.

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

* `updateChartData` **false** olduğunda, yalnızca çalışma kitabı yolu güncellenir. Grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez; bu nedenle çalışma kitabı mevcut olmayabilir.
* `updateChartData` **true** olduğunda, grafik verisi hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` **false** olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verileri korunur ve kullanılabilir olmayan çalışma kitabı yüklenmeden sunum kaydedilir.

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

Bir grafiğin bağlı olduğu çalışma kitabını belirlemek için, grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, harici bir çalışma kitabına bağlanmış bir grafiğin bulunduğu bir sunumun ilk slaydındaki ilk şekli inceler. Eğer grafik harici bir çalışma kitabına bağlandıysa, [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) konsola yazdırır. Ardından sunumun bir kopyasını kaydeder.

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

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki verileri düzenlediğiniz gibi değiştirebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu örnek, ilk slaydın ilk şekli olan ve erişilebilir bir harici çalışma kitabına bağlanmış bir grafiği kullanır. İlk serideki ilk veri noktasının hücre‑temelli değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlı harici XLSX dosyasını güncelleyebilir; orijinal çalışma kitabını korumanız gerekiyorsa bir kopya kullanın.

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

Bir grafik, eksik ya da kullanılamayan bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) oluşturun, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/) çağırın ve [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) özelliğini `true` yapın; ardından sunumu açın.

Aşağıdaki JavaScript örneği, ilk slaydın ilk şekli olan ve kullanılabilir olmayan harici bir çalışma kitabına referans veren bir grafiğin çalışma kitabı verilerini kurtarır. Kurtarılan verilere [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) ve [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) aracılığıyla erişir:

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

        // Burada kurtarılan çalışma kitabı verilerini okuyun veya değiştirin.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Harici çalışma kitabı kullanılabilir değilse ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Ön bellekteki grafik verilerini kullanmak kabul edilebilir bir geri dönüş ise kurtarmayı etkinleştirin; çünkü önbellek, sunum son güncellendiğinde harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin [veri kaynağı türü](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) ve bir [harici çalışma kitabına yolu](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) vardır; kaynak harici bir çalışma kitabıysa, tam yolu okuyarak dış bir dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreli bir yol belirttiğinizde otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu yüzden çalışma kitabını taşıdığınızda bağlantıyı güncellemeniz gerekebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak Aspose.Slides, uzak çalışma kitaplarını doğrudan düzenlemeyi desteklemez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Sunum, harici dosyaya bir [bağlantı](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) saklar. Hücre‑temelli grafik verilerini düzenlemek, bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinal dosyanın değişmemesi gerekiyorsa çalışma kitabının bir kopyasını kullanın.

**Harici dosya parola korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlarken şifre kabul etmez. Yaygın bir yaklaşım, şifre korumasını önceden kaldırmak ya da [Aspose.Cells](https://reference.aspose.com/cells/java/) kullanarak şifresi çözülmüş bir kopya hazırlamak ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına başvurabilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosyayı güncellemek her grafik için bir sonraki veri yüklemesinde yansır.