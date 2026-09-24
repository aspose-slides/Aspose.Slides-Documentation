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
description: "Aspose.Slides for Java'yı keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını sorunsuz bir şekilde yönetin ve sunum verilerinizi düzenleyin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketi olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirtme konularını gösterir.

Ayrıca harici çalışma kitaplarını grafik veri kaynağı olarak kullanma konusunu da kapsar. Örnekler, harici bir çalışma kitabını oluşturup atamayı, bir grafik ile ilişkilendirilmiş harici çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verisini düzenlemeyi gösterir.

Eksik veriyi temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki fark ve kullanılabilir gösterim modlarının bir çizgi grafik karşılaştırması için [Boş Hücrelerin Görüntülenmesini Kontrol Et](/slides/tr/java/chart-series/) bölümüne bakın.

## **Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**
Aspose.Slides, grafik verileri çalışma kitaplarını (Aspose.Cells ile düzenlenmiş grafik verilerini içeren) okumanıza ve yazmanıza olanak tanıyan [ReadWorkbookStream](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData#readWorkbookStream--) ve [WriteWorkbookStream](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) yöntemlerini sunar. **Not** grafik verileri aynı şekilde düzenlenmiş veya kaynağa benzer bir yapıya sahip olmalıdır.

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

### **Çalışma Kitabı Değişikliğinden Sonra Grafik Düzenini Doğrulama**
Gömülü bir çalışma kitabını değiştirilmiş bir sürümle değiştirdiğinizde, grafik orijinal seri ve kategori koleksiyonlarını korur. Bu tutarsızlık, [IChart.validateChartLayout](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/#validateChartLayout--) yönteminin `ArgumentOutOfRangeException` (parametre: index) hatası atmasına neden olabilir. Bu hatayı önlemek için, güncellenmiş çalışma kitabını grafik'e geri yazmadan önce mevcut serileri ve kategorileri **önce** temizleyin.

```java
// Çalışma kitabı akışı (örneğin Aspose.Cells kullanarak) değiştirildikten sonra
byte[] updatedWorkbook = baos.toByteArray();

// Mevcut veri referanslarını temizle.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Koleksiyonları temizlemek, grafik veri yapısının yeni çalışma kitabı ile uyumlu olmasını sağlar ve `validateChartLayout` hatasız bir şekilde tamamlanır.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**
1. [Presentation](https://apireference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Kaydırmanın (slide) indeksine göre referansını alın.  
1. Biraz veriyle bir Bubble (Balon) grafik ekleyin.  
1. Grafik serisine erişin.  
1. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
1. Sunumu kaydedin.  

Bu Java kodu bir çalışma kitabı hücresini grafik veri etiketi olarak ayarlamayı gösterir:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Sunum dosyasını temsil eden bir sunum sınıfını oluşturur
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
Bu Java kodu, [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) yönteminin bir çalışma sayfası koleksiyonuna erişmek için kullanıldığı bir işlemi gösterir:

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
Bu Java kodu bir veri kaynağı için tür nasıl belirtilir gösterir:

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

## **Desteklenmeyen Gömülü Çalışma Kitabı Biçimlerini Tespit Etme**
Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. Desteklenmeyen biçimleri tespit etmek ve bu grafikleri atlamak için [IChartData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData) üzerindeki `getEmbeddedWorkbookType` yöntemini ve [WorkbookType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/WorkbookType) enumunu kullanabilirsiniz.

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

## **Harici Çalışma Kitabı**
Aspose.Slides, harici çalışma kitaplarını grafikler için veri kaynağı olarak kullanmayı destekler.

### **Harici Çalışma Kitabı Oluşturma**
**`readWorkbookStream`** ve **`setExternalWorkbook`** yöntemlerini kullanarak, ya sıfırdan bir harici çalışma kitabı oluşturabilir ya da bir iç çalışma kitabını harici hâle getirebilirsiniz.

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

### **Harici Çalışma Kitabı Ayarlama**
**`setExternalWorkbook`** yöntemini kullanarak, bir harici çalışma kitabını bir grafiğin veri kaynağı olarak atayabilirsiniz. Bu yöntem ayrıca harici çalışma kitabının yolunu (eğer taşınmışsa) güncellemek için de kullanılabilir.

Uzak konumda veya kaynağa depolanmış çalışma kitaplarının verilerini düzenleyemezseniz de, bu çalışma kitaplarını hâlâ harici veri kaynağı olarak kullanabilirsiniz. Harici bir çalışma kitabı için göreceli bir yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu Java kodu bir harici çalışma kitabını nasıl ayarlayacağınızı gösterir:

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

`setExternalWorkbook` yönteminin ikinci (`boolean`) parametresi, bir Excel çalışma kitabının yüklenip yüklenmeyeceğini belirlemek için kullanılır. 
* Değeri `false` olarak ayarlandığında, yalnızca çalışma kitabı yolu güncellenir — grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez. Bu ayarı, hedef çalışma kitabı mevcut olmadığında veya erişilemez olduğunda kullanmak isteyebilirsiniz. 
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

### **Bir Grafiğin Harici Veri Kaynağı Çalışma Kitabı Yolunu Almak**
1. [Presentation](https://apireference.aspose.com/slides/tr/java/com.aspose.slides/presentation) sınıfının bir örneğini oluşturun.  
1. Kaydırmanın indeksine göre referansını alın.  
1. Grafik şekli için bir nesne oluşturun.  
1. Grafiğin veri kaynağını temsil eden kaynak (`ChartDataSourceType`) türü için bir nesne oluşturun.  
1. Kaynak türünün harici çalışma kitabı veri kaynağı türüyle aynı olmasına göre ilgili koşulu belirtin.  

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
Harici çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki içerikleri değiştirmeniz gibi düzenleyebilirsiniz. Harici bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

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

### **Grafik Önbelleğinden Bir Çalışma Kitabını Kurtarma**
Bir grafik, eksik veya erişilemez bir harici çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) oluşturun, onu [SpreadsheetOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/spreadsheetoptions/) ile yapılandırın ve sunumu açmadan önce `true` ile [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) yöntemini çağırın.

Aşağıdaki Java örneği, grafiği mevcut olmayan bir harici çalışma kitabına başvuran bir sunumu açar ve kurtarılan verilere [IChart.getChartData](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichart/#getChartData--) ve [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) aracılığıyla erişir:

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

Harici çalışma kitabı erişilemez ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Önbellekteki grafik verilerini kullanmak kabul edilebilir bir geri dönüş olduğunda yalnızca kurtarmayı etkinleştirin; çünkü önbellek, sunumun son güncellenmesinden sonra harici çalışma kitabına yapılan değişiklikleri içermeyebilir.

## **SSS**
**Belirli bir grafiğin harici bir çalışma kitabına mı yoksa gömülü bir çalışma kitabına mı bağlandığını belirleyebilir miyim?**  
Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getDataSourceType--) ve bir [harici çalışma kitabı yolu](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) vardır; kaynak bir harici çalışma kitabı ise, harici bir dosyanın kullanıldığından emin olmak için tam yolu okuyabilirsiniz.

**Harici çalışma kitapları için göreceli yollar destekleniyor mu ve nasıl depolanıyor?**  
Evet. Göreceli bir yol belirttiğinizde, otomatik olarak mutlak yola dönüştürülür. Bu, proje taşınabilirliği için uygundur; ancak sunumun bu mutlak yolu PPTX dosyasında depolayacağını unutmayın.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**  
Evet, bu tür çalışma kitapları harici veri kaynağı olarak kullanılabilir. Ancak, uzaktaki çalışma kitaplarını Aspose.Slides'ten doğrudan düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides sunumu kaydederken harici XLSX dosyasını üzerine yazar mı?**  
Hayır. Sunum, bir [harici dosyaya bağ](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) linkini depolar ve verileri okumak için bu bağlantıyı kullanır. Sunum kaydedildiğinde harici dosya kendisi değiştirilmez.

**Harici dosya şifre korumalıysa ne yapmalıyım?**  
Aspose.Slides bağlantı sırasında bir şifre kabul etmez. Yaygın bir yaklaşım, korumayı önceden kaldırmak veya şifresi çözülmüş bir kopya hazırlamaktır (örneğin, [Aspose.Cells](/cells/java/) kullanarak) ve bu kopyaya bağlamaktır.

**Birden fazla grafik aynı harici çalışma kitabına başvurabilir mi?**  
Evet. Her grafik kendi bağlantısını depolar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklendiğinde her grafikte de yansıtılır.