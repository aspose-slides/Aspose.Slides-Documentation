---
title: Java Kullanarak Sunumlarda Grafik Çalışma Kitaplarını Yönetme
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/java/chart-workbook/
keywords:
- grafik çalışma kitabı
- grafik veri
- çalışma kitabı hücresi
- veri etiketi
- çalışma sayfası
- veri kaynağı
- harici çalışma kitabı
- harici veri
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'yı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yönetin ve sunum verilerinizi kolaylaştırın."
---
## **Genel Bakış**

Bu makale Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme işlemlerini gösterir.

Ayrıca dış çalışma kitaplarının grafik veri kaynağı olarak kullanılmasını da kapsar. Örnekler, bir dış çalışma kitabının nasıl oluşturulup atanacağını, bir grafiğe bağlı dış çalışma kitabının yolunun nasıl alınacağını ve çalışma kitabı mevcut olduğunda grafik verilerinin nasıl düzenleneceğini gösterir.

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides, grafik veri çalışma kitaplarını (Aspose.Cells ile düzenlenen grafik verilerini içeren) okumanıza ve yazmanıza olanak tanıyan [ReadWorkbookStream](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData#readWorkbookStream--) ve [WriteWorkbookStream](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) metodlarını sağlar. **Not** grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

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

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. [Presentation](https://apireference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaytın referansını indeksine göre alın.  
3. Bir balon grafiği ve bazı verileri ekleyin.  
4. Grafik serisine erişin.  
5. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
6. Sunumu kaydedin.  

Bu Java kodu, bir çalışma kitabı hücresini grafik veri etiketi olarak ayarlamayı gösterir:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Sunum dosyasını temsil eden bir sunum sınıfı örnekler
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

Bu Java kodu, bir çalışma sayfası koleksiyonuna erişmek için [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) metodunun kullanıldığı bir işlemi gösterir:

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

Bu Java kodu, bir veri kaynağı için tür nasıl belirtilir gösterir:

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen biçimleri algılamak ve bu grafikleri atlamak için [IChartData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData) üzerindeki `getEmbeddedWorkbookType` metodunu ve [WorkbookType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/WorkbookType) enum değerini kullanabilirsiniz.

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
            // Gömülü çalışma kitabı .xlsb formatında, bu format desteklenmiyor.
            continue;
        }

        // Burada grafik çalışma kitabı verilerini okuyabilir veya değiştirebilirsiniz.
    }
} finally {
    presentation.dispose();
}
```

## **Harici Çalışma Kitabı**

{{% alert color="primary" %}} 
Aspose.Slides 19.4 sürümünde ([Aspose.Slides 19.4](https://docs.aspose.com/slides/tr/java/aspose-slides-for-java-19-4-release-notes/)), grafikler için veri kaynağı olarak harici çalışma kitapları desteğini uyguladık. 
{{% /alert %}} 

### **Harici Çalışma Kitabı Oluşturma**

**`readWorkbookStream`** ve **`setExternalWorkbook`** metodlarını kullanarak ya sıfırdan bir harici çalışma kitabı oluşturabilir ya da dahili bir çalışma kitabını harici hâle getirebilirsiniz.

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

### **Harici Çalışma Kitabı Ayarlama**

**`setExternalWorkbook`** metodunu kullanarak bir grafiğe veri kaynağı olarak harici bir çalışma kitabı atayabilirsiniz. Bu yöntem, harici çalışma kitabının yolunu (eğer taşındıysa) güncellemek için de kullanılabilir.

Uzak konumlarda veya kaynaklarda depolanan çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu çalışma kitaplarını hâlâ harici veri kaynağı olarak kullanabilirsiniz. Harici bir çalışma kitabı için göreceli bir yol verilirse, otomatik olarak tam bir yola dönüştürülür.

Bu Java kodu, bir harici çalışma kitabının nasıl ayarlanacağını gösterir:

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

`ChartData` parametresi (`setExternalWorkbook` metodunda) bir Excel çalışma kitabının yüklenip yüklenmeyeceğini belirtmek için kullanılır. 

* `ChartData` değeri `false` olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir—grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Hedef çalışma kitabı mevcut değilse veya erişilemezse bu ayarı kullanmak isteyebilirsiniz.  
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

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Almak**

1. [Presentation](https://apireference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaytın referansını indeksine göre alın.  
3. Grafik şekli için bir nesne oluşturun.  
4. Grafiğin veri kaynağını temsil eden kaynak (`ChartDataSourceType`) türü için bir nesne oluşturun.  
5. Kaynak türünün harici çalışma kitabı veri kaynağı türüyle aynı olması koşulunu belirleyin.  

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

Harici çalışma kitaplarındaki verileri, dahili çalışma kitaplarındaki gibi düzenleyebilirsiniz. Bir harici çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

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

## **SSS**

**Belirli bir grafiğin harici bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin [veri kaynağı türü](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getDataSourceType--) ve [harici çalışma kitabı yolu](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) vardır; kaynak harici bir çalışma kitabıysa, tam yolu okuyarak dış dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreceli bir yol belirttiğinizde otomatik olarak mutlak bir yola dönüştürülür. Bu, projenin taşınabilirliği için uygundur; ancak sunum, PPTX dosyasında mutlak yolu saklar.

**Ağ kaynaklarında/paylaşımlarda bulunan çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, uzaktan çalışan kitapları Aspose.Slides'tan doğrudan düzenlemek desteklenmez—yalnızca kaynak olarak kullanılabilir.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Hayır. Sunum, harici dosyaya bir [bağlantı](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) saklar ve verileri okurken bunu kullanır. Sunum kaydedildiğinde harici dosya değiştirilmez.

**Harici dosya şifreliyse ne yapmalıyım?**

Aspose.Slides, bağlanırken şifre kabul etmez. Yaygın bir yaklaşım, şifre korumasını önceden kaldırmak veya şifresiz bir kopya hazırlamaktır (örneğin, [Aspose.Cells](/cells/java/) kullanarak) ve bu kopyaya bağlanmaktır.

**Birden fazla grafik aynı harici çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklendiğinde her grafikte yansıtılır.