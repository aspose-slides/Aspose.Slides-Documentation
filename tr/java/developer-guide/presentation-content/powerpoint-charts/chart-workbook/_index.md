---
title: Java Kullanarak Sunumlarda Grafik Çalışma Kitaplarını Yönetme
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/java/chart-workbook/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'yı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yöneterek sunum verilerinizi düzene sokun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı tipini belirtme yöntemlerini gösterir.

Ayrıca dış çalışma kitaplarını grafik veri kaynakları olarak kullanmayı da kapsar. Örnekler, dış bir çalışma kitabı oluşturup atamayı, bir grafiğe bağlı dış çalışma kitabının yolunu elde etmeyi ve çalışma kitabı mevcutken grafik verilerini düzenlemeyi göstermektedir.

## **Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**
Aspose.Slides, grafik verilerini (Aspose.Cells ile düzenlenmiş grafik verilerini içeren) çalışma kitaplarını okumanıza ve yazmanıza izin veren [ReadWorkbookStream](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData#readWorkbookStream--) ve [WriteWorkbookStream](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) yöntemlerini sağlar. **Not** grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu Java kodu örnek bir işlemi göstermektedir:

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

## **Bir WorkBook Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. Bir [Presentation](https://apireference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaytın referansını indeks üzerinden alın.  
3. Bazı verilerle bir Bubble (Kabarcık) grafiği ekleyin.  
4. Grafik serisine erişin.  
5. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
6. Sunumu kaydedin.  

Bu Java kodu, bir çalışma kitabı hücresini grafik veri etiketi olarak ayarlamayı gösterir:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Bir sunum dosyasını temsil eden bir sunum sınıfını örnekler
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

Bu Java kodu, [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) yönteminin bir çalışma sayfası koleksiyonuna erişmek için kullanıldığı bir işlemi göstermektedir:

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

## **Veri Kaynağı Tipini Belirtme**

Bu Java kodu, bir veri kaynağı için tip nasıl belirtilir gösterir:

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

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları algılamak ve bu grafikleri atlamak için [IChartData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData) üzerindeki `getEmbeddedWorkbookType` metodunu ve [WorkbookType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/WorkbookType) enumarasyonunu kullanabilirsiniz.

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
            // Gömülü çalışma kitabı .xlsb formatında, desteklenmiyor.
            continue;
        }

        // Burada grafik çalışma kitabı verilerini okuyabilir veya değiştirebilirsiniz.
    }
} finally {
    presentation.dispose();
}
```

## **Dış Çalışma Kitabı**

{{% alert color="primary" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/tr/java/aspose-slides-for-java-19-4-release-notes/) sürümünde, grafikler için veri kaynağı olarak dış çalışma kitaplarını desteklemeye başladık. 
{{% /alert %}} 

### **Dış Çalışma Kitabı Oluşturma**

**`readWorkbookStream`** ve **`setExternalWorkbook`** yöntemlerini kullanarak ya sıfırdan bir dış çalışma kitabı oluşturabilir ya da iç bir çalışma kitabını dışa dönüştürebilirsiniz.

Bu Java kodu, dış çalışma kitabı oluşturma sürecini göstermektedir:

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

### **Dış Çalışma Kitabını Atama**

**`setExternalWorkbook`** metodunu kullanarak bir grafiğe dış bir çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu metod aynı zamanda dış çalışma kitabının yolunu (dosya taşınmışsa) güncellemek için de kullanılabilir.

Uzak konumlarda veya kaynaklarda depolanan çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu çalışma kitaplarını dış veri kaynağı olarak kullanabilirsiniz. Bir dış çalışma kitabı için göreceli yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu Java kodu, bir dış çalışma kitabının nasıl atanacağını gösterir:

```java
// Presentation sınıfının bir örneğini oluşturur
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

`setExternalWorkbook` metodundaki `ChartData` parametresi, bir Excel çalışma kitabının yüklenip yüklenmeyeceğini belirtmek için kullanılır. 

* `ChartData` değeri `false` olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir—grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Hedef çalışma kitabı mevcut değilse veya erişilemiyorsa bu ayarı kullanmak isteyebilirsiniz.  
* `ChartData` değeri `true` olarak ayarlandığında, grafik verileri hedef çalışma kitabından güncellenir.  

```java
// Presentation sınıfının bir örneğini oluşturur
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

### **Bir Grafiğin Dış Veri Kaynağı Çalışma Kitabı Yolunu Almak**

1. Bir [Presentation](https://apireference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaytın referansını indeks üzerinden alın.  
3. Grafik şekli için bir nesne oluşturun.  
4. Grafik veri kaynağını temsil eden (`ChartDataSourceType`) kaynak türü nesnesini oluşturun.  
5. Kaynak türünün dış çalışma kitabı veri kaynağı türüyle aynı olması durumunda ilgili koşulu belirtin.  

Bu Java kodu, işlemi göstermektedir:

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

### **Grafik Verisini Düzenleme**

Dış çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki içerikleri değiştirdiğiniz gibi düzenleyebilirsiniz. Dış bir çalışma kitabı yüklenemezse bir istisna fırlatılır.

Bu Java kodu, açıklanan sürecin bir uygulamasını gösterir:

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

### **Grafik Önbelleğinden Çalışma Kitabını Kurtarma**

Bir grafik, eksik veya erişilemeyen bir dış çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbellekte tutulan verilerden grafiğin çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) oluşturun, [SpreadsheetOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/spreadsheetoptions/) ile yapılandırın ve sunumu açmadan önce `true` ile [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) metodunu çağırın.

Aşağıdaki Java örneği, grafiği erişilemeyen bir dış çalışma kitabına referans veren bir sunumu açar ve [IChart.getChartData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/#getChartData--) ve [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) aracılığıyla kurtarılmış verilere erişir:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Kurtarılan çalışma kitabı verilerini burada okuyabilir veya değiştirebilirsiniz.
} finally {
    presentation.dispose();
}
```

Dış çalışma kitabı erişilemez ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Önbellekteki grafik verilerini kullanmak kabul edilebilir bir geri dönüş ise yalnızca kurtarmayı etkinleştirin; çünkü önbellek, sunum son güncellendiğinde dış çalışma kitabına yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin dış bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin bir [data source type](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getDataSourceType--) ve bir [path to an external workbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) vardır; kaynak dış bir çalışma kitabı ise tam yolu okuyarak dış bir dosyanın kullanıldığını doğrulayabilirsiniz.

**Dış çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreceli bir yol belirttiğinizde otomatik olarak mutlak yola dönüştürülür. Bu, proje taşınabilirliği için uygundur; ancak PPTX dosyasında mutlak yol saklanır.

**Ağ kaynakları/paylaşımlarında bulunan çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides'tan doğrudan uzak çalışma kitaplarını düzenlemek desteklenmez—yalnızca kaynak olarak kullanılabilirler.

**Sunumu kaydederken Aspose.Slides dış XLSX dosyasını üzerine yazar mı?**

Hayır. Sunum, dış dosyaya bir [link to the external file](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) saklar ve verileri okurken bu bağlantıyı kullanır. Sunum kaydedildiğinde dış dosya değiştirilmez.

**Dış dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlanma sırasında şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak ya da şifresiz bir kopya (örneğin [Aspose.Cells](/cells/java/) kullanarak) hazırlayıp ona bağlamaktır.

**Birden fazla grafik aynı dış çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde bu değişiklik her grafik için bir sonraki veri yüklemesinde yansır.