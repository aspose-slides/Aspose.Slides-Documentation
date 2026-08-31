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
- dış çalışma kitabı
- dış veri
- grafik önbelleği
- çalışma kitabı kurtarma
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Java aracılığıyla Node.js için Aspose.Slides'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını sorunsuz bir şekilde yönetin ve sunum verilerinizi kolaylaştırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketi olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme yöntemlerini gösterir.

Grafik veri kaynağı olarak dış çalışma kitaplarıyla çalışmayı da kapsar. Örnekler, bir dış çalışma kitabı oluşturup atamayı, bir grafikle ilişkilendirilmiş dış çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemeyi gösterir.

## **Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides, grafik verileri çalışma kitaplarını (Aspose.Cells ile düzenlenmiş grafik verilerini içeren) okumanıza ve yazmanıza olanak tanıyan [readWorkbookStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) yöntemlerini sağlar. **Not** grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

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

### **Çalışma Kitabı Değiştirildikten Sonra Grafik Düzenini Doğrulama**

Yerleşik bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal serileri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [Chart.validateChartLayout](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Chart#validateChartLayout--) metodunun dizin dışı bir hata ile başarısız olmasına neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin.

```javascript
// Çalışma kitabı akışını (örneğin Aspose.Cells kullanarak) değiştirdikten sonra
var updatedWorkbook = chartData.readWorkbookStream();

// Mevcut veri referanslarını temizle.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Koleksiyonların temizlenmesi, grafik veri yapısının yeni çalışma kitabı ile tutarlı olmasını sağlar ve `validateChartLayout`'un hatasız tamamlanmasına olanak tanır.

## **Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. [Presentation](https://apireference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaytın referansını indeks aracılığıyla alın.  
3. Bazı verilerle bir Kabarcık grafik ekleyin.  
4. Grafik serisine erişin.  
5. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
6. Sunumu kaydedin.

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

Bu JavaScript kodu, [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) metodunun bir çalışma sayfası koleksiyonuna erişmek için kullanıldığı bir işlemi gösterir:

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

## **Veri Kaynağı Türünü Belirleme**

Bu JavaScript kodu, bir veri kaynağı için tür nasıl belirlenir gösterir:

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları tespit etmek ve bu grafikleri atlamak için [ChartData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/) üzerindeki `getEmbeddedWorkbookType` metodunu ve [WorkbookType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/workbooktype/) enum değerini kullanabilirsiniz.

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
            // .xlsb formatında gömülü çalışma kitabı desteklenmemektedir.
            continue;
        }

        // Burada grafik çalışma kitabı verilerini okuyabilir veya değiştirebilirsiniz.
    }
} finally {
    presentation.dispose();
}
```

## **Dış Çalışma Kitabı**

Aspose.Slides, grafikler için veri kaynağı olarak dış çalışma kitaplarını destekler.

### **Dış Çalışma Kitabı Oluşturma**

**`readWorkbookStream`** ve **`setExternalWorkbook`** yöntemlerini kullanarak, ya baştan bir dış çalışma kitabı oluşturabilir ya da iç bir çalışma kitabını dışa dönüştürebilirsiniz.

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

**`setExternalWorkbook`** metodunu kullanarak, bir grafiğin veri kaynağı olarak dış bir çalışma kitabını atayabilirsiniz. Bu yöntem, dış çalışma kitabının yolunu güncellemek için de kullanılabilir (eğer dış çalışma kitabı taşınmışsa).

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemesiniz de, bu çalışma kitaplarını hâlâ dış bir veri kaynağı olarak kullanabilirsiniz. Dış bir çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam bir yola dönüştürülür.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation sınıfının bir örneğini oluşturur
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

`setExternalWorkbook` metodunun ikinci parametresi olan `updateChartData`, Excel çalışma kitabının yüklenip yüklenmeyeceğini belirler.

* `updateChartData` `false` olarak ayarlandığında, sadece çalışma kitabı yolu güncellenir—grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Bu ayarı, hedef çalışma kitabı mevcut olmadığında veya erişilemediğinde kullanmak isteyebilirsiniz.  
* `updateChartData` `true` olarak ayarlandığında, grafik verileri hedef çalışma kitabından güncellenir.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation sınıfının bir örneğini oluşturur
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
2. Bir slaytın referansını indeks aracılığıyla alın.  
3. Grafik şekli için bir nesne oluşturun.  
4. Grafiğin veri kaynağını temsil eden kaynak (`ChartDataSourceType`) türü için bir nesne oluşturun.  
5. Kaynak türünün dış çalışma kitabı veri kaynağı türüyle aynı olması durumuna göre ilgili koşulu belirtin.

Bu JavaScript kodu işlemi gösterir:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation sınıfının bir örneğini oluşturur
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

Dış çalışma kitaplarındaki verileri, iç çalışma kitaplarının içeriğinde yaptığınız değişiklikler gibi düzenleyebilirsiniz. Dış bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation sınıfının bir örneğini oluşturur
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

### **Grafik Önbelleğinden Çalışma Kitabını Geri Getirme**

Bir grafik, eksik veya mevcut olmayan bir dış çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınmış verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/) oluşturun, [SpreadsheetOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/spreadsheetoptions/) ile yapılandırın ve sunumu açmadan önce `true` ile [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) metodunu çağırın.

Aşağıdaki JavaScript örneği, grafiği mevcut olmayan bir dış çalışma kitabına referans veren bir sunumu açar ve geri alınan verilere [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) aracılığıyla erişir:

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

    // Kurtarılmış çalışma kitabı verilerini burada okuyabilir veya değiştirebilirsiniz.
} finally {
    presentation.dispose();
}
```

Eğer dış çalışma kitabı mevcut değil ve geri getirme devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Önbelleğe alınmış grafik verilerini kullanmak kabul edilebilir bir alternatif olduğunda yalnızca geri getirmeyi etkinleştirin, çünkü önbellek sunum en son güncellendiğinden sonra dış çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin dış bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**  
Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) ve bir [dış çalışma kitabı yolu](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) vardır; kaynak dış bir çalışma kitabıysa, dış bir dosyanın kullanıldığından emin olmak için tam yolu okuyabilirsiniz.

**Dış çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**  
Evet. Göreli bir yol belirtirseniz, otomatik olarak mutlak bir yola dönüştürülür. Bu, projenin taşınabilirliği için uygundur; ancak, sunumun PPTX dosyasında mutlak yolu saklayacağını unutmayın.

**Ağ kaynaklarında/paylaşımlarda bulunan çalışma kitaplarını kullanabilir miyim?**  
Evet, bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak, uzak çalışma kitaplarını Aspose.Slides üzerinden doğrudan düzenlemek desteklenmez—yalnızca bir kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken dış XLSX dosyasını üzerine yazar mı?**  
Hayır. Sunum, dış dosyaya bir [bağlantı](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) saklar ve verileri okumak için bu bağlantıyı kullanır. Sunum kaydedildiğinde dış dosya kendisi değişmez.

**Dış dosya şifre korumalıysa ne yapmalıyım?**  
Aspose.Slides, bağlanırken şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak ya da şifresiz bir kopya hazırlamaktır (örneğin, [Aspose.Cells](/cells/nodejs-java/) kullanarak) ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı dış çalışma kitabına referans verebilir mi?**  
Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklendiğinde her grafikte de yansıtılır.