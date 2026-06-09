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
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Java aracılığıyla Node.js için Aspose.Slides'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklamaktadır. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme yöntemlerini gösterir.

Ayrıca, harici çalışma kitaplarını grafik veri kaynağı olarak kullanmayı da kapsar. Örnekler, harici bir çalışma kitabı oluşturup atamayı, bir grafikle ilişkili harici çalışma kitabının yolunu almayı ve çalışma kitabı kullanılabilir olduğunda grafik verilerini düzenlemeyi göstermektedir.

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides, grafik veri çalışma kitaplarını (Aspose.Cells ile düzenlenen grafik verilerini içeren) okuma ve yazma imkanı sağlayan [readWorkbookStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) metodlarını sunar. **Not** grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

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

1. Bir [Presentation](https://apireference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının örneğini oluşturun.  
2. İndeksi üzerinden bir slaytın referansını alın.  
3. Bazı verilerle bir Bubble grafiği ekleyin.  
4. Grafik serilerine erişin.  
5. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
6. Sunumu kaydedin.

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Sunum dosyasını temsil eden bir sunum sınıfını örnekler
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

Bu JavaScript kodu, [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) metodunun bir çalışma sayfası koleksiyonuna erişmek için kullanıldığı bir işlemi göstermektedir:

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

Bu JavaScript kodu, bir veri kaynağı için tür nasıl belirtilir gösterir:

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Formatlarını Algıla**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları algılamak ve bu grafikleri atlamak için [ChartData](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/) üzerindeki `getEmbeddedWorkbookType` metodunu, [WorkbookType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/workbooktype/) enumuyla birlikte kullanabilirsiniz.

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
            // .xlsb formatındaki gömülü çalışma kitabı desteklenmiyor.
            continue;
        }

        // Burada grafik çalışma kitabı verilerini okuyabilir veya değiştirebilirsiniz.
    }
} finally {
    presentation.dispose();
}
```

## **Harici Çalışma Kitabı**

Aspose.Slides, grafikler için veri kaynağı olarak harici çalışma kitaplarını destekler.

### **Harici Çalışma Kitabı Oluşturma**

**`readWorkbookStream`** ve **`setExternalWorkbook`** metodlarını kullanarak ya sıfırdan bir harici çalışma kitabı oluşturabilir ya da iç çalışma kitabını harici hâle getirebilirsiniz.

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

### **Harici Çalışma Kitabını Ayarlama**

**`setExternalWorkbook`** metodunu kullanarak, bir grafiğe veri kaynağı olarak harici bir çalışma kitabı atayabilirsiniz. Bu metod, harici çalışma kitabının yolunu güncellemek için de kullanılabilir (eğer çalışma kitabı taşınmışsa).

Uzak konumlarda veya kaynaklarda depolanan çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu çalışma kitaplarını hâlâ harici veri kaynağı olarak kullanabilirsiniz. Harici bir çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam bir yola dönüştürülür.

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

`setExternalWorkbook` metodundaki `ChartData` parametresi, bir Excel çalışma kitabının yüklenip yüklenmeyeceğini belirlemek için kullanılır.

* `ChartData` değeri `false` olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir—grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Bu ayarı, hedef çalışma kitabı mevcut olmadığında veya erişilemediğinde kullanmak isteyebilirsiniz.  
* `ChartData` değeri `true` olarak ayarlandığında, grafik verileri hedef çalışma kitabından güncellenir.

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

### **Grafik Harici Veri Kaynağı Çalışma Kitabı Yolunu Al**

1. Bir [Presentation](https://apireference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının örneğini oluşturun.  
2. İndeksi üzerinden bir slaytın referansını alın.  
3. Grafik şekli için bir nesne oluşturun.  
4. Grafiğin veri kaynağını temsil eden kaynak (`ChartDataSourceType`) türü için bir nesne oluşturun.  
5. Kaynak türünün harici çalışma kitabı veri kaynağı türüyle aynı olması koşulunu belirtin.

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

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki içeriklerde yaptığınız değişiklikler gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

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

## **SSS**

**Belirli bir grafiğin harici bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**  
**Evet.** Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) ve bir [harici çalışma kitabı yolu](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) vardır; kaynak harici bir çalışma kitabı ise, harici bir dosyanın kullanıldığını doğrulamak için tam yolu okuyabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**  
**Evet.** Göreli bir yol belirttiğinizde, otomatik olarak mutlak bir yola dönüştürülür. Bu, proje taşınabilirliği için kullanışlıdır; ancak sunumun PPTX dosyasında mutlak yolu depoladığını unutmayın.

**Ağ kaynaklarında/paylaşımlarda bulunan çalışma kitaplarını kullanabilir miyim?**  
**Evet**, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, uzaktaki çalışma kitaplarını doğrudan Aspose.Slides ile düzenlemek desteklenmez—yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**  
**Hayır.** Sunum, bir [harici dosyaya bağ](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) linki depolar ve verileri okurken bu linki kullanır. Sunum kaydedildiğinde harici dosya kendisi değiştirilmez.

**Harici dosya şifre korumalıysa ne yapmalıyım?**  
Aspose.Slides, bağlantı oluştururken şifre kabul etmez. Yaygın bir yaklaşım, şifreyi önceden kaldırmak ya da şifresi çözülmüş bir kopya hazırlamaktır (örneğin, [Aspose.Cells](/cells/nodejs-java/) kullanarak) ve bu kopyaya bağlamaktır.

**Birden fazla grafik aynı harici çalışma kitabına referans verebilir mi?**  
**Evet.** Her grafik kendi bağlantısını depolar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklendiğinde her grafikte de yansıtılır.