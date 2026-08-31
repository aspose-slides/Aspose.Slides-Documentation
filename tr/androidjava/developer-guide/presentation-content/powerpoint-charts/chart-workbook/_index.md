---
title: Android'de Sunumlarda Grafik Çalışma Kitaplarını Yönetme
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/androidjava/chart-workbook/
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
- Android
- Java
- Aspose.Slides
description: "Java aracılığıyla Android için Aspose.Slides'i keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını sorunsuz bir şekilde yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı tipini belirtme yollarını gösterir.

Ayrıca dış çalışma kitaplarını grafik veri kaynakları olarak kullanmayı da kapsar. Örnekler, dış bir çalışma kitabı nasıl oluşturulup atanacağını, bir grafikle ilişkilendirilmiş dış çalışma kitabının yolunun nasıl alınacağını ve çalışma kitabı mevcut olduğunda grafik verilerinin nasıl düzenleneceğini gösterir.

## **Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides, grafik veri kitaplarını (Aspose.Cells ile düzenlenmiş grafik verileri içeren) okumanıza ve yazmanıza olanak tanıyan [ReadWorkbookStream](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) ve [WriteWorkbookStream](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) yöntemlerini sağlar. **Not** grafik verileri aynı şekilde düzenlenmeli veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu Java kodu örnek bir işlemi gösterir:

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

### **Çalışma Kitabını Değiştirdikten Sonra Grafik Düzenini Doğrulama**

Gömülü bir çalışma kitabını değiştirilmiş bir çalışma kitabı ile değiştirdiğinizde, grafik orijinal serilerini ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [IChart.validateChartLayout](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChart#validateChartLayout--) yönteminin indeks dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafik üzerine yazmadan önce mevcut serileri ve kategorileri temizleyin.

```java
// Çalışma kitabı akışı düzenlendikten sonra (örneğin, Aspose.Cells kullanarak)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// Mevcut veri referanslarını temizleyin.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Koleksiyonların temizlenmesi, grafik veri yapısının yeni çalışma kitabıyla tutarlı olmasını sağlar ve `validateChartLayout` hatasız bir şekilde tamamlanır.

## **Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. Presentation sınıfının bir örneğini oluşturun.
1. Dizin üzerinden slaytın referansını alın.
1. Bazı verilerle bir Bubble grafik ekleyin.
1. Grafik serisine erişin.
1. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.
1. Sunumu kaydedin.

Bu Java kodu, çalışma kitabı hücresini grafik veri etiketi olarak ayarlamayı gösterir:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Sunum dosyasını temsil eden bir Presentation sınıfı örnekler
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

Bu Java kodu, [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) metodunu kullanarak bir çalışma sayfası koleksiyonuna erişim örneğini gösterir:

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

## **Veri Kaynağı Türünü Belirleme**

Bu Java kodu, bir veri kaynağı için tür nasıl belirtilir gösterir:

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Formatlarını Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen formatları algılamak ve bu grafiklerden kaçınmak için [IChartData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartData) üzerindeki `getEmbeddedWorkbookType` metodunu ve [WorkbookType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/WorkbookType) enumunu kullanabilirsiniz.

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
            // Gömülü çalışma kitabı .xlsb formatında, bu format desteklenmiyor.
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

**`readWorkbookStream`** ve **`setExternalWorkbook`** yöntemlerini kullanarak sıfırdan bir dış çalışma kitabı oluşturabilir veya iç bir çalışma kitabını dışa dönüştürebilirsiniz.

Bu Java kodu, dış çalışma kitabı oluşturma sürecini gösterir:

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

### **Dış Çalışma Kitabını Ayarlama**

**`setExternalWorkbook`** yöntemini kullanarak bir grafiğe dış çalışma kitabını veri kaynağı olarak atayabilirsiniz. Bu yöntem, dış çalışma kitabının yolu taşındıysa yolu güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemezseniz de bu çalışma kitaplarını dış veri kaynağı olarak kullanabilirsiniz. Dış çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu Java kodu, dış bir çalışma kitabı nasıl ayarlanır gösterir:

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

`setExternalWorkbook` metodundaki `updateChartData` parametresi, bir Excel çalışma kitabının yüklenip yüklenmeyeceğini belirtmek için kullanılır.

* `updateChartData` değeri `false` olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir—grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Hedef çalışma kitabı mevcut değilse veya erişilemezse bu ayar kullanılabilir.
* `updateChartData` değeri `true` olarak ayarlandığında, grafik verileri hedef çalışma kitabından güncellenir.

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

1. Presentation sınıfının bir örneğini oluşturun.
1. Dizin üzerinden slaytın referansını alın.
1. Grafik şekli için bir nesne oluşturun.
1. Grafiğin veri kaynağını temsil eden (`ChartDataSourceType`) kaynak tipine bir nesne oluşturun.
1. Kaynak tipinin dış çalışma kitabı veri kaynağı tipiyle aynı olduğuna göre ilgili koşulu belirtin.

Bu Java kodu işlemi göstermektedir:

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

Dış çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki gibi düzenleyebilirsiniz. Dış bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

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

### **Grafik Önbelleğinden Çalışma Kitabını Geri Yükleme**

Bir grafik, eksik veya kullanılamayan bir dış çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınmış verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/) oluşturun, onu [SpreadsheetOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/spreadsheetoptions/) ile yapılandırın ve sunumu açmadan önce `true` ile [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) metodunu çağırın.

Aşağıdaki Java örneği, grafiği kullanılamayan bir dış çalışma kitabına referans veren bir sunumu açar ve geri yüklenmiş verilere [IChart.getChartData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/#getChartData--) ve [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) aracılığıyla erişir:

```java
import com.aspose.slides.*;

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

Dış çalışma kitabı kullanılamaz ve geri yükleme devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Önbellekten gelen grafik verilerini kullanmak kabul edilebilir bir yedekse sadece geri yüklemeyi etkinleştirin; çünkü önbellek, sunum son güncellendiğinden itibaren dış çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlı olduğunu belirleyebilir miyim?**

Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) ve bir [harici çalışma kitabı yoluna](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) vardır; kaynak harici bir çalışma kitabı ise, tam yolu okuyarak bir harici dosyanın kullanıldığından emin olabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu ve nasıl depolanıyor?**

Evet. Göreli bir yol belirtirseniz, otomatik olarak mutlak bir yola dönüştürülür. Bu, proje taşınabilirliği açısından kullanışlıdır; ancak sunum, PPTX dosyasında mutlak yolu saklayacaktır.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak, uzak çalışma kitaplarını doğrudan Aspose.Slides ile düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Hayır. Sunum, dış dosyaya bir [bağlantı](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) saklar ve veri okuma sırasında bu bağlantıyı kullanır. Sunum kaydedildiğinde dış dosya değişmez.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlantı sırasında şifre kabul etmez. Yaygın bir yaklaşım, şifreyi önceden kaldırmak veya şifresi çözülmüş bir kopya (örneğin, [Aspose.Cells](/cells/androidjava/) kullanarak) hazırlayıp o kopyaya bağlamaktır.

**Birden fazla grafik aynı dış çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, o dosya güncellendiğinde her grafik de bir sonraki veri yüklemesinde güncellenir.