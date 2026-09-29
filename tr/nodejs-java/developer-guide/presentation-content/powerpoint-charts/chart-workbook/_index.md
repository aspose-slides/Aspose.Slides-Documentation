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
description: "Aspose.Slides for Node.js via Java'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını sorunsuz bir şekilde yönetin ve sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca, harici çalışma kitaplarını grafik veri kaynakları olarak kullanmayı da kapsar. Örnekler, bir harici çalışma kitabı oluşturup atamayı, bir grafikle ilişkilendirilmiş harici çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemeyi gösterir.

Boş hücreleri temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve mevcut gösterim modlarının bir çizgi grafiği karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/nodejs-java/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardan Veri Dahil Et**

Gizli çalışma sayfası satır ve sütunlarından veri çizerken kontrol etmek için [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) kullanın. Sadece görünür hücreleri çizmek için `true`, görünür ve gizli hücreleri birlikte dahil etmek için `false` olarak ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez veya göstermez.

İndirilen [hidden-source-data.pptx](hidden-source-data.pptx) dosyasını çalışma dizinine koyun. İlk slaytı, ilk şekil olarak bir sütun grafiği içerir. Gömülü çalışma sayfası `Sheet1`, aşağıdaki kaynak aralığını (`A1:C4`) içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) üzerinden erişin ve gizli durumlarını incelemek için [ChartDataCell.isHidden](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#isHidden) okuyun. Bu yöntem gizli durumunu değiştirmeden raporlar. Bu dosyada, B2 görünür, B3 gizli satıra, C2 gizli sütuna aittir; örnek sırasıyla `false`, `true` ve `true` değerlerini yazdırır.

Bu örnek için, çizim ayarını değiştirdikten sonra grafik verilerini yenileyin: gömülü çalışma kitabını [readWorkbookStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) ile tutun ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de geri yüklemek için [setRange](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#setRange) kullanın. Sadece bayrağı değiştirmek bu örnek için önbellekteki grafik verilerini ve kategori etiketlerini yenilemek için yeterli değildir. Örnek, döndürülen Node.js tamponunu Java bayt dizisine dönüştürüp yazma metoduna gönderir.

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

Örnek, sadece görünür Perakende değerleri (10 ve 20) içeren `hidden_cells_true.pptx` ve tüm altı değeri içeren `hidden_cells_false.pptx` dosyalarını kaydeder. Aşağıdaki görseller iki çizim modunu gösterir. Satır 3 ve sütun C her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değer içeren bir gizli hücre, boş bir hücreden farklıdır. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) eksik değerlerin nasıl gösterileceğini kontrol eder; gizli kaynak verileri dahil etmez veya hariç tutmaz. Örnek için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/nodejs-java/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides for Node.js via Java, [readWorkbookStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) metodlarını sağlar; bu metodlar, Aspose.Cells ile düzenlenmiş grafik verilerini içeren çalışma kitabı akışlarını okumanıza ve yazmanıza olanak tanır. **Not** grafik verileri aynı şekilde organize edilmiş olmalıdır veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaytının ilk şekli olarak bir grafik içermesi gereken `chart.pptx` dosyasını açar. Gömülü çalışma kitabını bir bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellekte kalır; örnek sunumu kaydetmez.

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

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [Chart.validateChartLayout](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/#validateChartLayout) metodunun indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafik üzerine yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaytının ilk şekli olarak bir grafik içeren `chart.pptx` gerektirir. Yorum, çalışma kitabı düzenlemesinin nerede yapılacağını gösterir; çalıştırılabilir örnek orijinal çalışma kitabını geri yazar ve bellekte düzeni doğrular.

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

        // Burada workbook baytlarını değiştirin, örneğin Aspose.Cells kullanarak.

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

Koleksiyonların temizlenmesi, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Grafiği kullanmadan önce güncellenmiş çalışma kitabı için gerekli seri ve kategori eşlemelerini yeniden oluşturun.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

Çalışma kitabı hücrelerindeki metni grafik veri etiketleri olarak kullanabilirsiniz. Aşağıdaki adımlar, bir balon grafiğindeki etiketleri veri çalışma kitabındaki hücrelere nasıl bağlayacağınızı gösterir.

1. Presentation sınıfının bir örneğini oluşturun.  
2. İlk slayta sıfır tabanlı indeksiyle erişin.  
3. Varsayılan veri ile bir balon grafiği ekleyin.  
4. Grafik serisine erişin.  
5. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
6. Sunumu kaydedin.  

Bu örnek, en az bir slayt içeren `chart2.pptx` dosyasını açar ve varsayılan veri ile bir balon grafiği ekler. Çalışma sayfası 0'da A10:A12 hücrelerini ilk serinin ilk üç etiketi olarak kullanır, hücrelerden etiketleri etkinleştirir ve sonucu `resultchart.pptx` olarak kaydeder.

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

[ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) metodu, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan veri ile bir pasta grafiği oluşturur ve her çalışma sayfası adını konsola yazdırır.

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

Bu örnek, varsayılan veri ile bir 3B sütun grafiği oluşturur ve iki serinin adını farklı veri kaynakları kullanarak ayarlar. İlk ad bir dize sabiti, ikincisi ise çalışma sayfası 0'daki C1 hücresi ile belirlenir. [DataSourceType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/datasourcetype/) enum'ı her ad için kaynağı seçer. Sonuç `pres.pptx` olarak kaydedilir.

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. [getEmbeddedWorkbookType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) metodunu, [ChartData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/) ve [WorkbookType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/workbooktype/) enum'larıyla birlikte kullanarak desteklenmeyen biçimleri tespit edebilir ve bu grafikleri atlayabilirsiniz. Bu örnek, `sample.pptx` dosyasının ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve gömülü .xlsb çalışma kitabına sahip her grafik için tanı mesajı yazdırır.

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

Aspose.Slides, harici çalışma kitaplarını grafikler için veri kaynağı olarak kullanmayı destekler.

### **Harici Bir Çalışma Kitabı Oluşturma**

[readWorkbookStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) ve [setExternalWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) metodlarını kullanarak gömülü bir grafik çalışma kitabını dosyaya dışa aktarabilir ve grafiği bu harici çalışma kitabına bağlayabilirsiniz.

Bu örnek, varsayılan veri ile bir pasta grafiği oluşturur, çalışma kitabını `externalWorkbook1.xlsx` dosyasına yazar ve dosya yazımını tamamladıktan sonra dosyayı grafik veri kaynağı olarak atar. Bağlantılı sunumu `externalWorkbook.pptx` olarak kaydeder.

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

### **Harici Bir Çalışma Kitabı Ayarlama**

[setExternalWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) metodunu kullanarak, bir harici çalışma kitabını grafik için veri kaynağı olarak atayabilirsiniz. Bu metod aynı zamanda harici çalışma kitabının yolunu (çalışma kitabı taşınmışsa) güncellemek için de kullanılabilir.

Uzak konumlarda veya kaynaklarda depolanan çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu çalışma kitaplarını hâlâ harici veri kaynağı olarak kullanabilirsiniz. Harici bir çalışma kitabı için göreceli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, çalışma dizininde `externalWorkbook.xlsx` gerektirir. `Sheet1` adlı çalışma sayfası, B1 hücresinde bir seri adı, A2:A4 hücrelerinde kategori adları ve B2:B4 hücrelerinde sayısal değerler içermelidir. Örnek bir pasta grafiği oluşturur, çalışma kitabını bağlar ve [setRange](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#setRange) metodunu kullanarak A1:B4 aralığını bir seri ve üç kategoriye eşler. Sonucu `Presentation_with_externalWorkbook.pptx` olarak kaydeder.

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

[setExternalWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) metodunun `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` `false` olduğunda, yalnızca çalışma kitabı yolu güncellenir. Grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez, böylece çalışma kitabı bulunmayabilir.  
* `updateChartData` `true` olduğunda, grafik verisi hedef çalışma kitabından güncellenir.  

Aşağıdaki örnek, `updateChartData` `false` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verisini korur ve mevcut olmayan çalışma kitabını yüklemeden sunumu kaydeder.

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

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Alma**

Bir grafiğe bağlı çalışma kitabını belirlemek için önce grafiğin harici bir veri kaynağı kullanıp kullanmadığını kontrol edin. Kullanıyorsa, aşağıdaki adımları izleyerek çalışma kitabı yolunu alabilirsiniz.

1. Presentation sınıfının bir örneğini oluşturun.  
2. İlk slayta sıfır tabanlı indeksiyle erişin.  
3. İlk şeklin bir grafik olduğunu kontrol edin.  
4. Grafik veri kaynağı türünü okuyun.  
5. Kaynak bir harici çalışma kitabı ise, yolunu okuyun.  

Bu örnek, önceki örnekte oluşturulan `externalWorkbook.pptx` dosyasını açar ve ilk slayttaki ilk şekli inceler. Eğer bu şekil bir harici çalışma kitabına bağlı bir grafik ise, örnek [getExternalWorkbookPath](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) metodunu konsola yazdırır. Ardından sunumun bir kopyasını `Result.pptx` olarak kaydeder.

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

Harici çalışma kitaplarındaki verileri, dahili çalışma kitaplarının içeriğini değiştirmeniz gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu örnek, ilk slaydının ilk şekli olarak bir grafik içeren `presentation.pptx` ve erişilebilir bir harici çalışma kitabı gerektirir. İlk serideki ilk veri noktasının hücre tabanlı değerini 100 olarak ayarlar ve sunumu `presentation_out.pptx` olarak kaydeder. Hücre değerlerini düzenlemek, bağlı harici XLSX dosyasını güncelleyebilir; bu yüzden orijinal çalışma kitabını korumanız gerekiyorsa bir kopya kullanın.

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

### **Grafik Önbelleğinden Bir Çalışma Kitabını Kurtarma**

Eğer bir grafik, eksik veya mevcut olmayan bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınmış veriden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/) oluşturun, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) çağırın ve [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) metodunu `true` olarak ayarlayın, ardından sunumu açın.

Aşağıdaki JavaScript örneği, ilk slaydının ilk şekli olarak mevcut olmayan bir harici çalışma kitabına başvuran bir grafik içermesi gereken `presentation.pptx` dosyasını açar ve kurtarılan verilere [Chart.getChartData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/#getChartData) ve [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) aracılığıyla erişir:

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

Harici çalışma kitabı mevcut değilse ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Önbellekteki grafik verilerini kullanmak kabul edilebilir bir geri dönüş olduğunda yalnızca kurtarmayı etkinleştirin; çünkü önbellek, sunum son güncellendiğinden sonra harici çalışma kitabına yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**  
Evet. Bir grafik, bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#getDataSourceType) ve bir [harici çalışma kitabına yol](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) içerir; kaynak bir harici çalışma kitabı ise, tam yolu okuyarak bir harici dosyanın kullanıldığından emin olabilirsiniz.

**Harici çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**  
Evet. Göreceli bir yol belirtirseniz, otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu nedenle çalışma kitabını taşıdığınızda bağlantıyı güncellemeniz gerekebilir.

**Ağ kaynakları/ paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**  
Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, uzak çalışma kitaplarını doğrudan Aspose.Slides üzerinden düzenlemek desteklenmez; sadece veri kaynağı olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX'i üzerine yazar mı?**  
Sunum, bir [harici dosyaya bağlantı](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) saklar. Hücre tabanlı grafik verilerini düzenlemek, bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinalin değişmemesi gerekiyorsa çalışma kitabının bir kopyasını kullanın.

**Harici dosya şifre korumalıysa ne yapmalıyım?**  
Aspose.Slides, bağlantı sırasında şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak veya şifresi çözülmüş bir kopya hazırlamaktır (örneğin, [Aspose.Cells](https://reference.aspose.com/cells/java/) kullanarak) ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına başvurabilir mi?**  
Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklendiğinde her grafikte de yansır.