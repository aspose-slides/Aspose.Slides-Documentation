---
title: JavaScript Kullanarak Sunumlarda Grafik Çalışma Kitaplarını Yönetme
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
description: "Aspose.Slides for Node.js via Java'yı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca, harici çalışma kitaplarını grafik veri kaynakları olarak kullanmayı kapsar. Örnekler, harici bir çalışma kitabı oluşturup atamayı, bir grafikle ilişkilendirilmiş harici çalışma kitabının yolunu almaya ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemeye nasıl yapılacağını gösterir.

Eksik verileri temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve kullanılabilir gösterim modlarının bir çizgi grafik karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/nodejs-java/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Etme**

[Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) yöntemini, bir grafiğin gizli çalışma sayfası satırları ve sütunlarından veri çizip çizmeyeceğini denetlemek için kullanın. Yalnızca görünür hücreleri çizmek için `true`, hem görünür hem gizli hücreleri dahil etmek için `false` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satırlarını veya sütunlarını gizlemez veya göstermez.

[örnek sunum](hidden-source-data.pptx), ilk slaytındaki ilk şekil olarak bir sütun grafiği içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` kaynak aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) üzerinden erişin ve gizli durumlarını denetlemek için [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#isHidden) özelliğini okuyun. Bu yöntem gizli durumunu değiştirmeden raporlar. Bu dosyada B2 görünür, B3 gizli satıra ait ve C2 gizli sütuna aittir; örnek sırasıyla `false`, `true` ve `true` değerlerini yazdırır.

Bu örnek için, çizim ayarı değiştirildikten sonra grafik verisini yenileyin: gömülü çalışma kitabını [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) ile tutun ve [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de kapsayan tam aralığı yeniden oluşturmak için [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange) kullanın. Sadece bayrağı değiştirmek, bu örneğin önbelleğe alınmış grafik verilerini ve kategori etiketlerini yenilemek için yeterli değildir. Örnek, geri yazma yöntemi öncesinde döndürülen Node.js tamponunu bir Java bayt dizisine dönüştürür.

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

            // Gömülü çalışma kitabından grafik verilerini yenile.
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

Örnek, sadece görünür Perakende değerleri (10 ve 20) içeren bir sürüm ve tüm altı değeri içeren bir sürüm olmak üzere iki sunum versiyonu kaydeder. Aşağıdaki görseller iki çizim modunu gösterir. Satır 3 ve sütun C, her iki gömülü çalışma kitabında da gizli kalır.

| Sadece görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Sadece görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) eksik değerlerin nasıl görüntüleneceğini kontrol eder; gizli kaynak verileri dahil etmez veya hariç tutmaz. Bir örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/nodejs-java/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Bir Grafik Veri Aralığını Almak**

Mevcut bir sunumda çalışma kitabı verilerini güncellemeden önce, her bir grafiğin hangi çalışma sayfası hücrelerini kullandığını belirlemek için kaynak aralıklarını inceleyin. [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getRange) yöntemi, örneğin `Sheet1!$A$1:$D$5` gibi bir çalışma sayfası nitelikli formül olarak geçerli veri aralığını döndürür. Burada `Sheet1` çalışma sayfası adını, `!` onu hücre aralığından ayırır ve `$A$1:$D$5` A1’den D5’e kadar (dahil) hücreleri gösterir. Dolar işaretleri mutlak satır ve sütun referanslarını gösterir.

Yöntem, grafiği veya onun çalışma kitabını değiştirmeden mevcut aralığı okur. Grafik bir çalışma kitabını veri kaynağı olarak kullanmıyorsa `InvalidOperationException` hatası atar. Daha fazla bilgi için [ChartData API Referansı](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) sayfasına bakın.

Bu örnek bir sunumu açar ve her slayttaki şekilleri doğrudan grafikler için kontrol eder. Her grafiğin adını ve kaynak aralığını yazdırır. Bir grafik çalışma kitabı kullanmıyorsa bir mesaj yazdırır ve bir sonraki grafik ile devam eder.

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

Aspose.Slides for Node.js via Java, [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) ve [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) yöntemlerini sağlar; bu yöntemler grafik verileri çalışma kitaplarını (Aspose.Cells ile düzenlenen) okumanıza ve yazmanıza olanak tanır. **Note** grafik verisinin aynı şekilde düzenlenmiş olması veya kaynağa benzer bir yapıya sahip olması gerekir.

Bu örnek, ilk slaytındaki ilk şekil olarak bir grafik içeren bir sunum kullanır. Gömülü çalışma kitabını bir bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

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

### **Çalışma Kitabı Değişikliği Sonrası Grafik Düzenini Doğrulama**

Gömülü bir çalışma kitabını değiştirilmiş bir versiyonla değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını tutar. Bu uyumsuzluk, [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#validateChartLayout) yönteminin indeks dışı hata vermesine yol açabilir. Güncellenmiş çalışma kitabını geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slayttaki ilk şekil olarak bir grafik kullanır. Yorum, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini işaret eder; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve düzeni bellek içinde doğrular.

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

Koleksiyonları temizlemek, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli seri ve kategori eşlemelerini yeniden oluşturun ve ardından grafiği kullanın.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

Çalışma kitabı hücrelerindeki metni grafik veri etiketi olarak kullanabilirsiniz.

Bu örnek, mevcut bir sunumun ilk slaytına varsayılan verileri olan bir balon grafiği ekler. Çalışma sayfası 0’da A10:A12 hücrelerini ilk serinin ilk üç etiketi olarak kullanır, hücrelerden etiketleri etkinleştirir ve güncellenmiş sunumu kaydeder.

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

## **Çalışma Sayfalarını Yönetme**

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) yöntemi, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan verileri olan bir pasta grafiği oluşturur ve her çalışma sayfasının adını konsola yazar.

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

## **Veri Kaynağı Türünü Belirleme**

Bu örnek, varsayılan verileri olan bir 3D sütun grafiği oluşturur ve iki seri adını farklı veri kaynaklarıyla ayarlar. İlk ad bir dize sabiti kullanır; ikincisi çalışma sayfası 0’da C1 hücresini kullanır. [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) enumı, her ad için kaynağı seçer. Örnek, güncellenmiş seri adlarıyla sunumu kaydeder.

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Formatlarını Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları algılamak ve bu grafikleri atlamak için [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) üzerindeki [getEmbeddedWorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) yöntemini, [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) enumı ile birlikte kullanabilirsiniz. Bu örnek, mevcut bir sunumun ilk slaytındaki şekilleri inceler, grafik olmayan şekilleri atlar ve .xlsb gömülü çalışma kitabı olan her grafik için tanı mesajı yazar.

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

Aspose.Slides, harici çalışma kitaplarını grafikler için veri kaynağı olarak kullanmayı destekler.

### **Harici Çalışma Kitabı Oluşturma**

[readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) ve [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) yöntemlerini kullanarak gömülü bir grafik çalışma kitabını bir dosyaya dışa aktarabilir ve grafiği o harici çalışma kitabına bağlayabilirsiniz.

Bu örnek, varsayılan verileri olan bir pasta grafiği oluşturur ve çalışma kitabını dışa aktarır. Harici çalışma kitabını grafik veri kaynağı olarak atamadan önce dosya yazma işlemini tamamlar, ardından bağlanmış sunumu kaydeder.

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

### **Harici Çalışma Kitabını Ayarlama**

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) yöntemiyle bir grafiğe harici bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem aynı zamanda harici çalışma kitabının yolunu (dosya taşınmışsa) güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu çalışma kitaplarını harici bir veri kaynağı olarak yine de kullanabilirsiniz. Harici çalışma kitabı için bir göreli yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, `Sheet1` adlı çalışma sayfasında B1’de bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler içeren bir harici çalışma kitabı kullanır. Örnek bir pasta grafiği oluşturur, çalışma kitabını bağlar ve A1:B4 aralığını bir seri ve üç kategoriye eşlemek için [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange) kullanır. Bağlantılı grafiği içeren sunumu kaydeder.

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

[setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) yönteminin `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini denetler.

* `updateChartData` `false` olduğunda yalnızca çalışma kitabı yolu güncellenir. Grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez, bu yüzden çalışma kitabı mevcut olmayabilir.
* `updateChartData` `true` olduğunda grafik verisi hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` `false` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verilerini korur ve mevcut olmayan çalışma kitabını yüklemeden sunumu kaydeder.

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

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Almak**

Bir grafiğin hangi çalışma kitabına bağlandığını belirlemek için grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin ve çalışma kitabı yolunu alın.

Bu örnek, bağlantılı harici bir çalışma kitabı içeren bir sunumun ilk slaytındaki ilk şekli inceler. Eğer şekil harici bir çalışma kitabına bağlanmış bir grafikse, [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) konsola yazdırılır. Ardından sunumun bir kopyasını kaydeder.

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

### **Grafik Verilerini Düzenleme**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki değişiklikleri yapar gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemezse bir istisna fırlatılır.

Bu örnek, ilk slayttaki ilk şekil olarak bir grafik kullanır ve erişilebilir bir harici çalışma kitabına bağlanmıştır. İlk serinin ilk veri noktasının hücre tabanlı değerini 100 olarak ayarlar ve güncellenmiş sunumu kaydeder. Hücre değerlerini düzenlemek, bağlantılı harici XLSX dosyasını güncelleyebilir; bu yüzden orijinali korumak istiyorsanız bir kopya kullanın.

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

### **Grafik Önbelleğinden Çalışma Kitabını Kurtarma**

Bir grafik, eksik veya mevcut olmayan bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) oluşturun, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) çağırın ve [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) değerini `true` yapın, ardından sunumu açın.

Aşağıdaki JavaScript örneği, ilk slayttaki ilk şekil olarak bir grafik ve mevcut olmayan bir harici çalışma kitabına referans veren bir senaryoda çalışma kitabı verilerini kurtarır. Kurtarılan verilere [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getChartData) ve [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) aracılığıyla erişir:

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

Harici çalışma kitabı mevcut değil ve kurtarma devre dışı bırakıldıysa, Aspose.Slides bir istisna fırlatır. Ön bellekli grafik verilerini kullanmak kabul edilebilir bir geri dönüş ise yalnızca kurtarmayı etkinleştirin; önbellek, sunum en son güncellendiğinden sonra harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getDataSourceType) ve bir [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) vardır; kaynak harici bir çalışma kitabıysa, tam yolu okuyarak bir harici dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreli bir yol belirtirseniz, otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu nedenle çalışma kitabını taşıdığınızda bağlantıyı güncellemeniz gerekebilir.

**Ağ kaynaklarında/ paylaşımlarda bulunan çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, uzak çalışma kitaplarını Aspose.Slides üzerinden doğrudan düzenlemek desteklenmez; yalnızca bir kaynak olarak kullanılabilirler.

**Aspose.Slides sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Sunum, harici dosyaya bir [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) saklar. Hücre temelli grafik verilerini düzenlemek, bağlanan yerel XLSX dosyasını da güncelleyebilir. Orijinal çalışma kitabının değişmemesi gerekiyorsa bir kopyasını kullanın.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides bağlantı sırasında şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak veya bir şifre çözülmüş kopya (örneğin [Aspose.Cells](https://reference.aspose.com/cells/java/)) hazırlamaktır ve o kopyaya bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, o dosyadaki bir güncelleme her grafik için bir sonraki veri yüklemesinde yansıtılır.