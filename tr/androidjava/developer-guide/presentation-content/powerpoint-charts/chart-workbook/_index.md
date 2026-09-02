---
title: Android'de Sunumlarda Grafik Çalışma Kitaplarını Yönetme
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/androidjava/chart-workbook/
keywords:
- grafik çalışma kitabı
- grafik veri
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
description: "Java üzerinden Android için Aspose.Slides'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını sorunsuz bir şekilde yönetin ve sunum verilerinizi kolaylaştırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini nasıl okunup yazılacağını, çalışma kitabı hücrelerini grafik veri etiketleri olarak nasıl kullanılacağını, çalışma sayfası koleksiyonlarına nasıl erişileceğini ve grafik değerleri için veri kaynağı türünün nasıl belirleneceğini gösterir.

Ayrıca, dış çalışma kitaplarının grafik veri kaynakları olarak nasıl kullanılacağını kapsar. Örnekler, dış bir çalışma kitabının nasıl oluşturulup atanacağını, bir grafik ile ilişkilendirilmiş dış çalışma kitabının yolunun nasıl alınacağını ve çalışma kitabı mevcut olduğunda grafik verilerinin nasıl düzenleneceğini gösterir.

## **Grafik Verilerini Çalışma Kitabından Okuma ve Yazma**

Aspose.Slides, grafik verileri çalışma kitaplarını (Aspose.Cells ile düzenlenmiş grafik verilerini içeren) okuma ve yazma imkanı sağlayan [ReadWorkbookStream](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) ve [WriteWorkbookStream](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) yöntemlerini sunar. **Not**: grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu Java kodu örnek bir işlemi gösterir:

```java
Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. Bir [Presentation](https://apireference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının örneğini oluşturun.  
1. İndeksi aracılığıyla bir slaytın referansını alın.  
1. Bazı veri içeren bir Balon grafiği ekleyin.  
1. Grafik serisine erişin.  
1. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
1. Sunumu kaydedin.

Bu Java kodu, çalışma kitabı hücresini grafik veri etiketi olarak nasıl ayarlayacağınızı gösterir:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Sunum dosyasını temsil eden bir sunum sınıfının örneğini oluşturur
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Çalışma Sayfalarını Yönetme**

Bu Java kodu, [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) yönteminin bir çalışma sayfası koleksiyonuna erişmek için kullanıldığı bir işlemi gösterir:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Veri Kaynağı Türünü Belirleme**

Bu Java kodu, bir veri kaynağı için tür nasıl belirleneceğini gösterir:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Desteklenmeyen Gömülü Çalışma Kitabı Formatlarını Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları algılamak ve bu grafiklerden kaçınmak için [IChartData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartData) üzerindeki `getEmbeddedWorkbookType` metodunu [WorkbookType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/WorkbookType) enumerasyonu ile birlikte kullanabilirsiniz.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Gömülü çalışma kitabı .xlsb formatında, desteklenmemektedir.
            continue;
        }

        // Burada grafik çalışma kitabı verilerini okuyun veya değiştirin.
    }
} finally {
    presentation.dispose();
}
```

## **Harici Çalışma Kitabı**

Aspose.Slides, grafikler için veri kaynağı olarak harici çalışma kitaplarını destekler.

### **Harici Çalışma Kitabı Oluşturma**

**`readWorkbookStream`** ve **`setExternalWorkbook`** yöntemlerini kullanarak, sıfırdan bir harici çalışma kitabı oluşturabilir veya dahili bir çalışma kitabını harici hâle getirebilirsiniz.

Bu Java kodu, harici çalışma kitabı oluşturma sürecini gösterir:

```java
Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Harici Çalışma Kitabını Ayarlama**

**`setExternalWorkbook`** yöntemini kullanarak, bir grafiğe veri kaynağı olarak harici bir çalışma kitabı atayabilirsiniz. Bu yöntem ayrıca harici çalışma kitabının yolunu (eğer taşınmışsa) güncellemek için de kullanılabilir.

Uzak konumlarda veya kaynaklarda depolanan çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu çalışma kitaplarını hâlâ harici veri kaynağı olarak kullanabilirsiniz. Harici bir çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu Java kodu, harici bir çalışma kitabının nasıl ayarlanacağını gösterir:

```java
// Sunum sınıfının bir örneğini oluşturur
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

`setExternalWorkbook` yönteminin altındaki `ChartData` parametresi, bir Excel çalışma kitabının yüklenip yüklenmeyeceğini belirtmek için kullanılır.

* `ChartData` değeri `false` olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir—grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Hedef çalışma kitabı mevcut olmadığında veya erişilemez olduğunda bu ayarı kullanmak isteyebilirsiniz.  
* `ChartData` değeri `true` olarak ayarlandığında, grafik verileri hedef çalışma kitabından güncellenir.

```java
// Sunum sınıfının bir örneğini oluşturur
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Almak**

1. Bir [Presentation](https://apireference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation) sınıfının örneğini oluşturun.  
1. İndeksi aracılığıyla bir slaytın referansını alın.  
1. Grafik şekli için bir nesne oluşturun.  
1. Grafiğin veri kaynağını temsil eden kaynak (`ChartDataSourceType`) türü için bir nesne oluşturun.  
1. Kaynak türünün harici çalışma kitabı veri kaynağı türüyle aynı olmasına göre ilgili koşulu belirtin.

Bu Java kodu, işlemi gösterir:

```java
// Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// Sunumu kaydeder
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Grafik Verilerini Düzenleme**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarının içeriğinde yaptığınız değişiklikler gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu Java kodu, açıklanan sürecin bir uygulamasıdır:

```java
// Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Grafik Önbelleğinden Çalışma Kitabını Geri Yükleme**

Bir grafik, eksik veya kullanılabilir olmayan harici bir çalışma kitabı kullanıyorsa, Aspose.Slides, sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/) oluşturun, onu [SpreadsheetOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/spreadsheetoptions/) ile yapılandırın ve sunumu açmadan önce `true` ile [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) yöntemini çağırın.

Aşağıdaki Java örneği, grafiği erişilemeyen bir harici çalışma kitabına referans veren bir sunumu açar ve kurtarılan verilere [IChart.getChartData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/#getChartData--) ve [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) aracılığıyla erişir:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Kurtarılmış çalışma kitabı verilerini burada okuyun veya değiştirin.
} finally {
    presentation.dispose();
}
```

Harici çalışma kitabı erişilemez ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Önbellekteki grafik verilerini kullanmak kabul edilebilir bir geri dönüş olduğunda yalnızca kurtarmayı etkinleştirin; çünkü önbellek, sunum son güncellendikten sonra harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**

Evet. Bir grafiğin bir [data source type](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) ve bir [path to an external workbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) vardır; kaynak bir harici çalışma kitabıysa, tam yolu okuyarak bir harici dosyanın kullanıldığından emin olabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreli bir yol belirttiğinizde, otomatik olarak mutlak bir yola dönüştürülür. Bu, projenin taşınabilirliği için kullanışlıdır; ancak, sunumun PPTX dosyasında mutlak yolu depolayacağını unutmayın.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, uzak çalışma kitaplarını doğrudan Aspose.Slides üzerinden düzenlemek desteklenmez; yalnızca bir kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Hayır. Sunum, harici dosyaya bir [link to the external file](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) saklar ve verileri okumak için bunu kullanır. Sunum kaydedildiğinde harici dosya kendisi değişmez.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, ilişkilendirirken şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak veya şifresi çözülmüş bir kopya hazırlamaktır (örneğin, [Aspose.Cells](/cells/androidjava/) kullanarak) ve bu kopyaya bağlamaktır.

**Birden çok grafik aynı harici çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklendiğinde her grafiğe yansır.