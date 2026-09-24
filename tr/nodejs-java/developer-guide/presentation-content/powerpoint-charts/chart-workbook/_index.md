---
title: Sunumlarda Grafik Çalışma Kitaplarını JavaScript Kullanarak Yönetme
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
- dış çalışma kitabı
- dış veri
- grafik önbelleği
- çalışma kitabı kurtarma
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Java aracılığıyla Node.js için Aspose.Slides keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını sorunsuz bir şekilde yönetin ve sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketi olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca dış çalışma kitaplarının grafik veri kaynakları olarak kullanımını da kapsar. Örnekler, dış bir çalışma kitabı oluşturup ona atama, bir grafik ile ilişkili dış çalışma kitabının yolunu alma ve çalışma kitabı mevcut olduğunda grafik verilerini düzenleme yöntemlerini gösterir.

Eksik veri temsil eden çalışma kitabı hücreleri için, boş bir hücrenin sıfırla farkını ve kullanılabilir görüntüleme modlarının bir çizgi grafiği karşılaştırmasını görmek üzere [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/nodejs-java/chart-series/) bölümüne bakın.

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides, grafik verilerini (Aspose.Cells ile düzenlenmiş) içeren çalışma kitaplarını okumanıza ve yazmanıza olanak tanıyan [readWorkbookStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) metodlarını sağlar. **Not**: grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu JavaScript kodu örnek bir işlemi gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Çalışma Kitabı Değişikliği Sonrası Grafik Düzenini Doğrulama**

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [Chart.validateChartLayout](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Chart#validateChartLayout--) metodunun indeks dışı hata vermesine neden olabilir. Güncellenen çalışma kitabını grafiğe yazmadan önce mevcut serileri ve kategorileri temizleyin.

```javascript
// Çalışma kitabı akışı değiştirildikten sonra (örn., Aspose.Cells kullanarak)
var updatedWorkbook = chartData.readWorkbookStream();

// Mevcut veri referanslarını temizle.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Koleksiyonların temizlenmesi, grafik veri yapısının yeni çalışma kitabı ile tutarlı olmasını sağlar ve `validateChartLayout` hatasız tamamlanır.

## **Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. [Presentation](https://apireference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. İndeksiyle bir slaytın referansını alın.  
1. Bir Bubble grafiği bazı verilerle ekleyin.  
1. Grafik serisine erişin.  
1. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
1. Sunumu kaydedin.

Bu JavaScript kodu, bir çalışma kitabı hücresini grafik veri etiketi olarak ayarlamayı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Bir sunum dosyasını temsil eden sunum sınıfını örnekler
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Çalışma Sayfalarını Yönetme**

Bu JavaScript kodu, [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) metodunu kullanarak bir çalışma sayfası koleksiyonuna erişim örneğini gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Veri Kaynağı Türünü Belirtme**

Bu JavaScript kodu, bir veri kaynağı için tür belirtmenin nasıl yapılacağını gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Desteklenmeyen Gömülü Çalışma Kitabı Formatlarını Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları tespit etmek ve bu grafikleri atlamak için [ChartData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/) üzerindeki `getEmbeddedWorkbookType` metodunu, [WorkbookType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/workbooktype/) enumu ile birlikte kullanabilirsiniz.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // .xlsb formatında gömülü çalışma kitabı desteklenmiyor.
            continue;
        }

        // Burada grafik çalışma kitabı verilerini okuyun veya değiştirin.
    }
} finally {
    presentation.dispose();
}
```

## **Dış Çalışma Kitabı**

Aspose.Slides, grafikler için veri kaynağı olarak dış çalışma kitaplarını destekler.

### **Dış Çalışma Kitabı Oluşturma**

**`readWorkbookStream`** ve **`setExternalWorkbook`** metodlarını kullanarak ya sıfırdan bir dış çalışma kitabı oluşturabilir ya da iç bir çalışma kitabını dışa dönüştürebilirsiniz.

Bu JavaScript kodu, dış çalışma kitabı oluşturma sürecini gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream çalışma kitabı baytlarını bir Node Buffer olarak döndürür.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Dış Çalışma Kitabını Ayarlama**

**`setExternalWorkbook`** metodunu kullanarak bir grafiğe dış çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu metod aynı zamanda dış çalışma kitabının yolunu (taşınmışsa) güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu çalışma kitaplarını dış veri kaynağı olarak yine de kullanabilirsiniz. Bir dış çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu JavaScript kodu, dış bir çalışma kitabını nasıl ayarlayacağınızı gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunum sınıfının bir örneğini oluşturur
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

`setExternalWorkbook` metodunun ikinci parametresi `updateChartData`, Excel çalışma kitabının yüklenip yüklenmeyeceğini belirler.

* `updateChartData` **false** olduğunda, yalnızca çalışma kitabı yolu güncellenir – grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Hedef çalışma kitabı mevcut değilse veya kullanılamıyorsa bu ayar tercih edilebilir.  
* `updateChartData` **true** olduğunda, grafik verileri hedef çalışma kitabından güncellenir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunum sınıfının bir örneğini oluşturur
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Grafik Dış Veri Kaynağı Çalışma Kitabı Yolunu Alma**

1. [Presentation](https://apireference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. İndeksiyle bir slaytın referansını alın.  
1. Grafik şekli için bir nesne oluşturun.  
1. Grafiğin veri kaynağını temsil eden (`ChartDataSourceType`) nesneyi oluşturun.  
1. Kaynak türünün dış çalışma kitabı veri kaynağı türüyle aynı olması durumunda ilgili koşulu belirtin.

Bu JavaScript kodu işlemi gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunum sınıfının bir örneğini oluşturur
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // Sunumu kaydeder
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Grafik Verilerini Düzenleme**

Dış çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki gibi düzenleyebilirsiniz. Dış bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu JavaScript kodu, açıklanan sürecin bir uygulamasıdır:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Sunum sınıfının bir örneğini oluşturur
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Grafik Önbelleğinden Çalışma Kitabını Kurtarma**

Bir grafik, eksik veya kullanılamayan bir dış çalışma kitabı kullandığında, Aspose.Slides sunumdaki önbellekteki verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/) oluşturun, onu [SpreadsheetOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/spreadsheetoptions/) ile yapılandırın ve sunumu açmadan önce `true` ile [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) metodunu çağırın.

Aşağıdaki JavaScript örneği, mevcut olmayan bir dış çalışma kitabına referans veren bir sunumu açar ve kurtarılan verilere [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) üzerinden erişir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Burada kurtarılan çalışma kitabı verilerini okuyun veya değiştirin.
} finally {
    presentation.dispose();
}
```

Dış çalışma kitabı kullanılamaz ve kurtarma kapalıysa, Aspose.Slides bir istisna fırlatır. Önbellekten gelen grafik verilerini kullanmak kabul edilebilir bir geri dönüş ise kurtarmayı etkinleştirin; çünkü önbellek, dış çalışma kitabına son eklenen değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin dış veya gömülü bir çalışma kitabına bağlı olup olmadığını nasıl belirleyebilirim?**

Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) ve bir [dış çalışma kitabı yolu](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) vardır; kaynak dış bir çalışma kitabı ise tam yolu okuyarak dış dosyanın kullanıldığını doğrulayabilirsiniz.

**Dış çalışma kitapları için göreli yollar destekleniyor mu, nasıl saklanıyor?**

Evet. Göreli bir yol belirttiğinizde otomatik olarak mutlak yola dönüştürülür. Bu, proje taşınabilirliği açısından kullanışlıdır; ancak sunum bu mutlak yolu PPTX dosyasında saklar.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak Aspose.Slides üzerinden uzak çalışma kitaplarını doğrudan düzenleme desteklenmez – sadece kaynak olarak kullanılabilirler.

**Sunumu kaydederken Aspose.Slides dış XLSX dosyasını üzerine yazar mı?**

Hayır. Sunum, dış dosyaya bir [bağlantı](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) saklar ve veri okuma için bu bağlantıyı kullanır. Sunum kaydedildiğinde dış dosya değiştirilmez.

**Dış dosya parola korumalıysa ne yapmalıyım?**

Aspose.Slides bağlanırken parola kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak veya [Aspose.Cells](/cells/nodejs-java/) gibi bir araçla şifresiz bir kopya hazırlamak ve o kopyaya bağlanmaktır.

**Birden fazla grafik aynı dış çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, o dosya güncellendiğinde veri bir sonraki yüklemede her grafikte yansıtılır.