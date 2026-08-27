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
- harici çalışma kitabı
- harici veri
- grafik önbelleği
- çalışma kitabı kurtarma
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'yı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını zahmetsizce yöneterek sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca, harici çalışma kitaplarını grafik veri kaynakları olarak kullanmayı kapsar. Örnekler, harici bir çalışma kitabı oluşturma ve atama, bir grafikle ilişkilendirilmiş harici çalışma kitabının yolunu alma ve çalışma kitabı mevcut olduğunda grafik verisini düzenleme yöntemlerini göstermektedir.

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**
Aspose.Slides, [ReadWorkbookStream](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData#readWorkbookStream--) ve [WriteWorkbookStream](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) yöntemlerini sağlar; bu yöntemler, Aspose.Cells ile düzenlenen grafik verilerini içeren çalışma kitaplarını okumanıza ve yazmanıza olanak tanır. **Not**: Grafik verileri aynı şekilde düzenlenmiş olmalı veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu Java kodu örnek bir işlemi göstermektedir:

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

Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu tutarsızlık, `chart.validateChartLayout()` çağrısının `ArgumentOutOfRangeException` (parametre: index) hatası fırlatmasına neden olabilir. Bu hatayı önlemek için, güncellenmiş çalışma kitabını grafik'e geri yazmadan **önce** mevcut serileri ve kategorileri temizleyin.

```java
// Çalışma kitabı akışı (ör. Aspose.Cells kullanarak) değiştirildikten sonra
byte[] updatedWorkbook = baos.toByteArray();

// Mevcut veri referanslarını temizle.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

// Güncellenen çalışma kitabını tekrar grafiğe yaz.
chart.getChartData().writeWorkbookStream(updatedWorkbook);

// Şimdi doğrulama başarılı.
chart.validateChartLayout();
```

Koleksiyonların temizlenmesi, grafik veri yapısının yeni çalışma kitabıyla uyumlu olmasını sağlar ve `validateChartLayout()` hatasız tamamlanır.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

1. [Presentation](https://apireference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. İndeksi üzerinden bir slayt referansı alın.  
1. Bir Bubble grafiği bazı verilerle ekleyin.  
1. Grafik serilerine erişin.  
1. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
1. Sunumu kaydedin.

Bu Java kodu, bir çalışma kitabı hücresini grafik veri etiketi olarak ayarlamayı gösterir:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Bir sunum dosyasını temsil eden bir sunum sınıfı örnekler
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

Bu Java kodu, [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) yönteminin bir çalışma sayfası koleksiyonuna erişmek için nasıl kullanıldığını gösterir:

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

Bu Java kodu, bir veri kaynağı için türün nasıl belirtileceğini gösterir:

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

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen biçimleri algılamak ve bu grafikleri atlamak için [IChartData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData) üzerindeki `getEmbeddedWorkbookType` yöntemini ve [WorkbookType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/WorkbookType) enumarasyonunu kullanabilirsiniz.

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
            // Gömülü çalışma kitabı .xlsb formatında, bu format desteklenmemektedir.
            continue;
        }

        // Burada grafik çalışma kitabı verisini okuyabilir veya değiştirebilirsiniz.
    }
} finally {
    presentation.dispose();
}
```

## **Harici Çalışma Kitabı**

{{% alert color="info" %}} 
[Aspose.Slides 19.4](https://docs.aspose.com/slides/tr/java/aspose-slides-for-java-19-4-release-notes/) sürümünde, grafikler için veri kaynağı olarak harici çalışma kitapları desteği eklenmiştir.
{{% /alert %}} 

### **Harici Çalışma Kitabı Oluşturma**

**`readWorkbookStream`** ve **`setExternalWorkbook`** yöntemlerini kullanarak ya sıfırdan bir harici çalışma kitabı oluşturabilir ya da iç bir çalışma kitabını harici hale getirebilirsiniz.

Bu Java kodu, harici çalışma kitabı oluşturma sürecini gösterir:

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

### **Harici Çalışma Kitabını Ayarlama**

**`setExternalWorkbook`** yöntemiyle bir harici çalışma kitabını grafik için veri kaynağı olarak atayabilirsiniz. Bu yöntem aynı zamanda harici çalışma kitabının yolunu (dosya taşındıysa) güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarındaki verileri düzenleyemezsiniz, ancak bu çalışma kitaplarını harici veri kaynağı olarak kullanabilirsiniz. Bir harici çalışma kitabı için göreli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu Java kodu, harici bir çalışma kitabının nasıl ayarlanacağını gösterir:

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

`setExternalWorkbook` yönteminin ikinci (`boolean`) parametresi, Excel çalışma kitabının yüklenip yüklenmeyeceğini belirler.

* Değeri `false` olduğunda, yalnızca çalışma kitabı yolu güncellenir – grafik verisi hedef çalışma kitabından yüklenmez veya güncellenmez. Hedef çalışma kitabı mevcut değilse veya erişilemezse bu ayar kullanılabilir.  
* Değeri `true` olduğunda, grafik verisi hedef çalışma kitabından güncellenir.

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

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Alma**

1. [Presentation](https://apireference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. İndeksi üzerinden bir slayt referansı alın.  
1. Grafik şekli için bir nesne oluşturun.  
1. Grafiğin veri kaynağını temsil eden (`ChartDataSourceType`) bir nesne oluşturun.  
1. Kaynak tipi harici çalışma kitabı veri kaynağı tipine eşit olduğunda ilgili koşulu belirtin.

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

### **Grafik Verisini Düzenleme**

Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu Java kodu, açıklanan sürecin bir uygulamasıdır:

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

Bir grafik, eksik veya erişilemeyen bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) oluşturun, [SpreadsheetOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/spreadsheetoptions/) ile yapılandırın ve sunumu açmadan önce `true` ile `ISpreadsheetOptions.setRecoverWorkbookFromChartCache` metodunu çağırın.

Aşağıdaki Java örneği, erişilemeyen bir harici çalışma kitabına referans veren bir sunumu açar ve kurtarılan veriye [IChart.getChartData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/#getChartData--) ve [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) aracılığıyla erişir:

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

Harici çalışma kitabı bulunamaz ve kurtarma devre dışı bırakılırsa, Aspose.Slides bir istisna fırlatır. Önceden önbellekteki grafik verilerinin kullanılmasının kabul edilebilir bir geri dönüş olduğu durumlarda kurtarmayı etkinleştirin; çünkü önbellek, sunum en son güncellendiğinden beri harici çalışma kitabında yapılan değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin harici mi yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**

Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getDataSourceType--) ve bir [harici çalışma kitabı yolu](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) vardır; kaynak harici bir çalışma kitabı ise tam yolu okuyarak dış bir dosyanın kullanıldığını doğrulayabilirsiniz.

**Harici çalışma kitapları için göreli yollar destekleniyor mu, nasıl depolanıyor?**

Evet. Göreli bir yol belirtirseniz otomatik olarak mutlak yola dönüştürülür. Bu, proje taşınabilirliği için kullanışlıdır; ancak sunum PPTX dosyasında mutlak yolu saklar.

**Ağ kaynakları/paylaşımlarındaki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, uzak çalışma kitaplarını doğrudan Aspose.Slides ile düzenleme desteklenmez – yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**

Hayır. Sunum, [harici dosyaya bir bağlantı](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) saklar ve veriyi okurken bu bağlantıyı kullanır. Sunum kaydedildiğinde harici dosya değişmez.

**Harici dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides bağlanırken şifre kabul etmez. Yaygın bir yaklaşım, şifreyi önceden kaldırmak ya da şifresiz bir kopya (örneğin [Aspose.Cells](/cells/java/) kullanarak) hazırlayıp ona bağlamaktır.

**Birden fazla grafik aynı harici çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosyada yapılan güncellemeler bir sonraki veri yüklemesinde her grafiğe yansır.