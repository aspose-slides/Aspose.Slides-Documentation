---
title: Java Kullanarak Sunumlarda Grafik Çalışma Kitaplarını Yönet
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
description: "Aspose.Slides for Java'ı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme yöntemlerini gösterir.

Ayrıca dış çalışma kitaplarını grafik veri kaynağı olarak kullanmayı da kapsar. Örnekler, bir dış çalışma kitabının nasıl oluşturulup atandığını, bir grafikle ilişkili dış çalışma kitabının yolunun nasıl alındığını ve çalışma kitabı mevcut olduğunda grafik verisinin nasıl düzenleneceğini gösterir.

## **Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides, grafik verilerini (Aspose.Cells ile düzenlenmiş grafik verilerini içeren) çalışma kitaplarını okuma ve yazma imkanı sağlayan [ReadWorkbookStream](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData#readWorkbookStream--) ve [WriteWorkbookStream](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) yöntemlerini sunar. **Not**: grafik verileri aynı şekilde düzenlenmiş olmalı ya da kaynağa benzer bir yapıya sahip olmalıdır.

```java
import com.aspose.slides.*;

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

### **Çalışma Kitabı Değiştirildikten Sonra Grafik Düzenini Doğrulama**

Bir gömülü çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu tutarsızlık, [IChart.validateChartLayout](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/#validateChartLayout--) metodunun `ArgumentOutOfRangeException` (parametre: index) atmasına neden olabilir. Bu istisna oluşmasını önlemek için, güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri **önce** temizleyin.

```java
// Çalışma kitabı akışını değiştirdikten sonra (örn., Aspose.Cells kullanarak)
byte[] updatedWorkbook = baos.toByteArray();

// Mevcut veri referanslarını temizle.

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Koleksiyonları temizlemek, grafik veri yapısının yeni çalışma kitabıyla hizalanmasını sağlar ve `validateChartLayout`'un hatasız tamamlanmasına olanak verir.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. ​[Presentation](https://apireference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksi aracılığıyla bir slaytın referansını alın.
1. Bazı verilerle bir Balon grafiği ekleyin.
1. Grafik serisine erişin.
1. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.
1. Sunumu kaydedin.

Bu Java kodu bir çalışma kitabı hücresini grafik veri etiketi olarak ayarlamayı gösterir:

```java
// Bir sunum dosyasını temsil eden sunum sınıfının bir örneğini oluşturur
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Instantiates a presentation class that represents a presentation file
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

Bu Java kodu, bir çalışma sayfası koleksiyonuna erişmek için [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) metodunun kullanıldığı bir işlemi göstermektedir:

```java
import com.aspose.slides.*;

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

## **Veri Kaynağı Türünü Belirtme**

Bu Java kodu, bir veri kaynağı için türün nasıl belirleneceğini gösterir:

```java
import com.aspose.slides.*;

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

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen biçimleri algılamak ve bu grafiklerden kaçınmak için [IChartData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData) üzerindeki `getEmbeddedWorkbookType` metodunu ve [WorkbookType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/WorkbookType) enumlarını kullanabilirsiniz.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Gömülü çalışma kitabı .xlsb formatında ve desteklenmiyor.
            continue;
        }

        // Grafik çalışma kitabı verilerini burada okuyun veya değiştirin.
    }
} finally {
    presentation.dispose();
}
```

## **Dış Çalışma Kitabı**

{{% alert color="info" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/tr/java/aspose-slides-for-java-19-4-release-notes/) sürümünde, grafikler için veri kaynağı olarak dış çalışma kitapları desteği ekledik.
{{% /alert %}} 

### **Dış Çalışma Kitabı Oluşturma**

**`readWorkbookStream`** ve **`setExternalWorkbook`** yöntemlerini kullanarak, sıfırdan bir dış çalışma kitabı oluşturabilir veya iç bir çalışma kitabını dışa dönüştürebilirsiniz.

Bu Java kodu dış çalışma kitabı oluşturma sürecini gösterir:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

### **Dış Çalışma Kitabı Ayarlama**

**`setExternalWorkbook`** metodunu kullanarak, bir grafiğe dış çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem, dış çalışma kitabının yolunu (eğer taşıldıysa) güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemesiniz de, bu çalışma kitaplarını hâlâ dış veri kaynağı olarak kullanabilirsiniz. Bir dış çalışma kitabı için göreceli yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu Java kodu bir dış çalışma kitabı ayarlamayı gösterir:

```java
import com.aspose.slides.*;

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

`setExternalWorkbook` metodunun ikinci (`boolean`) parametresi, bir Excel çalışma kitabının yüklenip yüklenmeyeceğini belirtmek için kullanılır. 

* Değeri `false` olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir—grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Bu ayar, hedef çalışma kitabı mevcut olmadığında veya erişilemez olduğunda kullanılabilir. 
* Değeri `true` olarak ayarlandığında, grafik verileri hedef çalışma kitabından güncellenir.

```java
import com.aspose.slides.*;

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

1. ​[Presentation](https://apireference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İndeksi aracılığıyla bir slaytın referansını alın.
1. Grafik şekli için bir nesne oluşturun.
1. Grafiğin veri kaynağını temsil eden kaynak (`ChartDataSourceType`) türü için bir nesne oluşturun.
1. Kaynak türünün dış çalışma kitabı veri kaynağı türüyle aynı olmasına dayalı ilgili koşulu belirtin.

Bu Java kodu işlemi gösterir:

```java
import com.aspose.slides.*;

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

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarının içeriğinde yaptığınız değişiklikler gibi düzenleyebilirsiniz. Bir dış çalışma kitabı yüklenemediğinde istisna fırlatılır.

```java
import com.aspose.slides.*;

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

Bir grafik eksik veya mevcut olmayan bir dış çalışma kitabını kullanıyorsa, Aspose.Slides sunumda önbelleğe alınmış verilerden grafik çalışma kitabını yeniden oluşturabilir. Sunumu açmadan önce [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) oluşturun, [SpreadsheetOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/spreadsheetoptions/) ile yapılandırın ve `true` ile [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) metodunu çağırın.

Aşağıdaki Java örneği, grafiği mevcut olmayan bir dış çalışma kitabına referans veren bir sunumu açar ve geri alınan verilere [IChart.getChartData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/#getChartData--) ve [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) aracılığıyla erişir:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Kurtarılan çalışma kitabı verilerini burada okuyun veya değiştirin.
} finally {
    presentation.dispose();
}
```

Harici çalışma kitabı mevcut değilse ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Önbellekteki grafik verilerini kullanmak kabul edilebilir bir geri dönüş olduğunda yalnızca kurtarmayı etkinleştirin; çünkü önbellek, sunum son güncellendiğinden beri harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin dış bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getDataSourceType--) ve bir [dış çalışma kitabı yolu](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) vardır; eğer kaynak dış bir çalışma kitabı ise, dış bir dosyanın kullanıldığını doğrulamak için tam yolu okuyabilirsiniz.

**Dış çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreceli bir yol belirttiğinizde, otomatik olarak mutlak bir yola dönüştürülür. Bu, proje taşınabilirliği için elverişlidir; ancak, sunumun PPTX dosyasında mutlak yolu depolayacağını unutmayın.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak, uzaktaki çalışma kitaplarını doğrudan Aspose.Slides üzerinden düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Sunumu kaydederken Aspose.Slides dış XLSX dosyasını üzerine yazar mı?**

Hayır. Sunum, bir [dış dosyaya bağlantı](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) saklar ve verileri okurken bu bağlantıyı kullanır. Sunum kaydedildiğinde dış dosya kendisi değiştirilmez.

**Dış dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlantı kurarken şifre kabul etmez. Yaygın bir yaklaşım, önceden korumayı kaldırmak ya da şifresi çözülmüş bir kopya hazırlamaktır (örneğin, [Aspose.Cells](/cells/java/) kullanarak) ve bu kopyaya bağlantı vermektir.

**Birden fazla grafik aynı dış çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklendiğinde her grafikte de yansır.