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
description: "Java üzerinden Node.js için Aspose.Slides'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını sorunsuz bir şekilde yönetin ve sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketi olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca dış çalışma kitaplarının grafik veri kaynakları olarak kullanımını da kapsar. Örnekler, bir dış çalışma kitabı oluşturup atamayı, bir grafikle ilişkilendirilmiş dış çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verisini düzenlemeyi gösterir.

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides, [readWorkbookStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) yöntemlerini sağlar; bu yöntemler, Aspose.Cells ile düzenlenmiş grafik verilerini içeren çalışma kitaplarını okumanıza ve yazmanıza olanak tanır. **Not**: grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu JavaScript kodu örnek bir işlemi gösterir:

```javascript
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

## **Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. [Presentation](https://apireference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. İndeksi aracılığıyla bir slaytın referansını alın.  
3. Bir Bubble grafiği bazı verilerle ekleyin.  
4. Grafik serisine erişin.  
5. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
6. Sunumu kaydedin.  

Bu JavaScript kodu, bir çalışma kitabı hücresini grafik veri etiketi olarak nasıl ayarlayacağınızı gösterir:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Bir sunum dosyasını temsil eden bir sunum sınıfının örneğini oluşturur
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

Bu JavaScript kodu, [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) yönteminin bir çalışma sayfası koleksiyonuna erişmek için nasıl kullanıldığını gösterir:

```javascript
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

Bu JavaScript kodu, bir veri kaynağı için tür nasıl belirtileceğini gösterir:

```javascript
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

## **Desteklenmeyen Gömülü Çalışma Kitabı Formatlarını Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları algılamak ve bu grafikleri atlamak için [ChartData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/) üzerindeki `getEmbeddedWorkbookType` metodunu [WorkbookType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/workbooktype/) enumu ile birlikte kullanabilirsiniz.

```js
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
            // Gömülü çalışma kitabı .xlsb formatında ve desteklenmiyor.
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

**`readWorkbookStream`** ve **`setExternalWorkbook`** yöntemlerini kullanarak ya sıfırdan bir dış çalışma kitabı oluşturabilir ya da iç bir çalışma kitabını dışa dönüştürebilirsiniz.

Bu JavaScript kodu dış çalışma kitabı oluşturma sürecini gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
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

**`setExternalWorkbook`** yöntemiyle bir grafiğin veri kaynağı olarak dış bir çalışma kitabı atayabilirsiniz. Bu yöntem aynı zamanda dış çalışma kitabının yolu (taşınmışsa) güncellenmek istendiğinde de kullanılabilir.

Uzak konumlardaki ya da kaynaklardaki çalışma kitaplarındaki verileri doğrudan düzenleyemezsiniz, ancak bu çalışma kitaplarını dış veri kaynağı olarak kullanabilirsiniz. Bir dış çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu JavaScript kodu dış bir çalışma kitabını nasıl ayarlayacağınızı gösterir:

```javascript
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

`ChartData` parametresi (`setExternalWorkbook` metodunun altında) bir Excel çalışma kitabının yükleneceğini belirlemek için kullanılır.

* `ChartData` değeri `false` olarak ayarlandığında yalnızca çalışma kitabı yolu güncellenir—grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez. Hedef çalışma kitabı mevcut değilse ya da erişilemiyorsa bu ayarı kullanabilirsiniz.  
* `ChartData` değeri `true` olarak ayarlandığında grafik verisi hedef çalışma kitabından güncellenir.

```javascript
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
2. İndeksi aracılığıyla bir slaytın referansını alın.  
3. Grafik şekli için bir nesne oluşturun.  
4. Grafiğin veri kaynağını temsil eden (`ChartDataSourceType`) nesneyi oluşturun.  
5. Kaynak türü dış çalışma kitabı veri kaynağı türüyle aynı olduğunda ilgili koşulu belirtin.  

Bu JavaScript kodu işlemi gösterir:

```javascript
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

### **Grafik Verisini Düzenleme**

Dış çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki içeriklerde yaptığınız değişiklikler gibi düzenleyebilirsiniz. Bir dış çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu JavaScript kodu açıklanan sürecin uygulanmasını gösterir:

```javascript
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

### **Grafik Önbelleğinden Çalışma Kitabını Geri Kazanma**

Bir grafik, eksik ya da erişilemeyen bir dış çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/) oluşturun, onu [SpreadsheetOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/spreadsheetoptions/) ile yapılandırın ve sunumu açmadan önce `true` ile [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) metodunu çağırın.

Aşağıdaki JavaScript örneği, bir dış çalışma kitabına başvurusu olmayan bir sunumu açar ve geri kazanılan verileri [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) üzerinden erişir:

```javascript
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

Dış çalışma kitabı kullanılabilir değilse ve geri kazanma devre dışı bırakıldıysa, Aspose.Slides bir istisna fırlatır. Önbellekteki grafik verilerini bir yedek olarak kullanmak kabul edilebilir olduğunda yalnızca geri kazanma etkinleştirilmelidir; çünkü önbellek, dış çalışma kitabının son güncellemesinden sonraki değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin dış mı yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**  
Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) ve bir [dış çalışma kitabı yolu](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) vardır; kaynak dış bir çalışma kitabıysa tam yolu okuyarak dış bir dosyanın kullanıldığını doğrulayabilirsiniz.

**Dış çalışma kitapları için göreli yollar destekleniyor mu, nasıl depolanıyor?**  
Evet. Göreli bir yol belirtirseniz otomatik olarak mutlak yola dönüştürülür. Bu, proje taşınabilirliği için kullanışlıdır; ancak sunum, mutlak yolu PPTX dosyasında saklayacaktır.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**  
Evet, bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak, uzak çalışma kitaplarını doğrudan Aspose.Slides ile düzenlemek desteklenmez—yalnızca kaynak olarak kullanılabilirler.

**Sunumu kaydederken Aspose.Slides dış XLSX dosyasını üzerine yazar mı?**  
Hayır. Sunum, dış dosyaya bir [bağlantı](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) saklar ve veri okurken bu bağlantıyı kullanır. Sunum kaydedildiğinde dış dosya değiştirilmez.

**Dış dosya şifre korumalıysa ne yapmalıyım?**  
Aspose.Slides, bağlanırken şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak ya da bir [Aspose.Cells](/cells/nodejs-java/) kullanarak şifresiz bir kopya hazırlamak ve bu kopyaya bağlamaktır.

**Birden fazla grafik aynı dış çalışma kitabına başvurabilir mi?**  
Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklemede her grafikte de yansıtılır.