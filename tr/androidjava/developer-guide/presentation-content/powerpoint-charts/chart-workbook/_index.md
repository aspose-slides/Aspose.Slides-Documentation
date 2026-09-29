---
title: Android'de Sunumlarda Grafik Çalışma Kitaplarını Yönetme
linktitle: Grafik Çalışma Kitabı
type: docs
weight: 70
url: /tr/androidjava/chart-workbook/
keywords:
- grafik çalışma kitabı
- grafik verileri
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java'yi keşfedin: PowerPoint ve OpenDocument formatlarında grafik çalışma kitaplarını sorunsuz bir şekilde yönetin ve sunum verilerinizi kolaylaştırın."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te grafik çalışma kitaplarıyla nasıl çalışılacağını açıklar. Çalışma kitabı akışları aracılığıyla grafik verilerini okuma ve yazma, çalışma kitabı hücrelerini grafik veri etiketleri olarak kullanma, çalışma sayfası koleksiyonlarına erişme ve grafik değerleri için veri kaynağı türünü belirleme konularını gösterir.

Ayrıca dış çalışma kitaplarını grafik veri kaynakları olarak kullanmayı kapsar. Örnekler, dış bir çalışma kitabı oluşturup atamayı, bir grafik ile ilişkili dış çalışma kitabının yolunu almayı ve çalışma kitabı mevcut olduğunda grafik verilerini düzenlemeyi gösterir.

Eksik verileri temsil eden çalışma kitabı hücreleri için, boş bir hücre ile sıfır arasındaki farkı ve mevcut görüntüleme modlarının bir çizgi grafiği karşılaştırmasını görmek üzere [Control the Display of Empty Cells](/slides/tr/androidjava/chart-series/) bölümüne bakın.

## **Gizli Satır ve Sütunlardaki Verileri Dahil Etme**

[Görünür Hücreleri Sadece Çiz] (https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) yöntemini kullanarak bir grafiğin gizli çalışma sayfası satır ve sütunlarından veri çizinip çizmeyeceğini kontrol edin. Görünür hücreleri yalnızca çizmek için `true`, hem görünür hem de gizli hücreleri dahil etmek için `false` ayarlayın. Bu ayar grafik çizimini kontrol eder; çalışma sayfası satır veya sütunlarını gizlemez ya da görünür kılmaz.

[hidden-source-data.pptx](hidden-source-data.pptx) dosyasını indirin ve çalışma dizinine koyun. İlk slaytı, ilk şekil olarak bir sütun grafiği içerir. Gömülü çalışma sayfası `Sheet1`, `A1:C4` aralığını içerir. 3. satır ve C sütunu gizlidir, ancak hücreleri hâlâ değer içerir.

| Çalışma sayfası satırı | A: Ay | B: Perakende | C: Toptan (gizli sütun) |
| --- | --- | --- | --- |
| 2 | Ocak | 10 | 30 |
| 3 (gizli satır) | Şubat | 40 | 60 |
| 4 | Mart | 20 | 50 |

Kaynak hücrelere [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) üzerinden erişin ve gizli durumlarını denetlemek için [IChartDataCell.isHidden](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) metodunu okuyun. Bu yöntem gizli durumunu değiştirmenize gerek kalmadan raporlar. Bu dosyada B2 görünür, B3 gizli satıra, C2 ise gizli sütuna aittir; örnek sırasıyla `false`, `true` ve `true` değerlerini yazdırır.

Bu örnek için, çizim ayarını değiştirdikten sonra grafik verilerini yenileyin: gömülü çalışma kitabını [readWorkbookStream](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) ile alın ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) ile yeniden yükleyin. Tüm hücreleri dahil ederken, gizli Şubat kategorisini de içerecek şekilde tam aralığı geri yüklemek için [setRange](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) kullanın. Sadece bayrağı değiştirmek bu örnek için önbelleğe alınmış grafik verilerini ve kategori etiketlerini yenilemek için yeterli değildir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Gömülü çalışma kitabından grafik verilerini yenile.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Gizli kategorileri dahil ederek tam kaynak aralığını geri yükle.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Örnek, yalnızca görünür Perakende değerleri (10 ve 20) ile `hidden_cells_true.pptx` ve tüm altı değerle `hidden_cells_false.pptx` dosyalarını kaydeder. Aşağıdaki görüntüler iki çizim modunu gösterir. 3. satır ve C sütunu her iki gömülü çalışma kitabında da gizli kalır.

| Yalnızca görünür hücreler (`true`) | Tüm hücreler (`false`) |
| --- | --- |
| ![Yalnızca görünür hücreler: Ocak ve Mart için Perakende değerleri 10 ve 20.](hidden_cells_True.png) | ![Tüm hücreler: Ocak, Şubat ve Mart için Perakende ve Toptan değerleri.](hidden_cells_False.png) |

Değeri olan gizli bir hücre, boş bir hücreden farklıdır. Eksik değerlerin nasıl görüntüleneceğini kontrol eden [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) yöntemi, gizli kaynak verilerini dahil etmez veya hariç tutmaz. Örnek için [Control the Display of Empty Cells](/slides/tr/androidjava/chart-series/#control-the-display-of-empty-cells) bölümüne bakın.

## **Bir Çalışma Kitabından Grafik Verilerini Okuma ve Yazma**

Aspose.Slides for Android via Java, [readWorkbookStream](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) ve [writeWorkbookStream](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) metodlarını sağlar; bu metodlar, Aspose.Cells ile düzenlenmiş grafik verilerini içeren çalışma kitaplarını okumanıza ve yazmanıza olanak tanır. **Not**: Grafik verileri aynı biçimde düzenlenmelidir veya kaynağa benzer bir yapıya sahip olmalıdır.

Bu örnek, ilk slaydının ilk şekli olarak bir grafik içermesi gereken `chart.pptx` dosyasını açar. Gömülü çalışma kitabını bir bayt dizisine okur, mevcut serileri ve kategorileri temizler ve aynı çalışma kitabını geri yazar. Değişiklikler bellek içinde kalır; örnek sunumu kaydetmez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Çalışma Kitabı Değiştirildikten Sonra Grafik Düzenini Doğrulama**

Gömülü bir çalışma kitabını değiştirilmiş bir tane ile değiştirdiğinizde, grafik orijinal serileri ve kategori koleksiyonlarını korur. Bu uyumsuzluk, [IChart.validateChartLayout](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/#validateChartLayout--) metodunun dizin dışı hata vermesine neden olabilir. Güncellenmiş çalışma kitabını grafiğe geri yazmadan önce mevcut serileri ve kategorileri temizleyin. Bu örnek, ilk slaydının ilk şekli olarak bir grafik içeren `chart.pptx` gerektirir. Yorum satırları, çalışma kitabı düzenlemesinin nerede gerçekleşeceğini gösterir; çalışan örnek, orijinal çalışma kitabını geri yazar ve düzeni bellek içinde doğrular.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Burada çalışma kitabı baytlarını değiştirin, örneğin Aspose.Cells kullanarak.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Koleksiyonları temizlemek, çalışma kitabı geri yazılmadan önce eski veri referanslarını kaldırır. Güncellenmiş çalışma kitabı için gerekli tüm serileri ve kategori eşlemelerini yeniden oluşturun ve ardından grafiği kullanın.

## **Bir Çalışma Kitabı Hücresini Grafik Veri Etiketi Olarak Ayarlama**

Çalışma kitabı hücrelerinden metinleri grafik veri etiketleri olarak kullanabilirsiniz. Aşağıdaki adımlar, bir kabarcık grafiğindeki etiketleri veri çalışma kitabındaki hücrelere nasıl bağlayacağınızı gösterir.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Sıfır‑tabanlı indeksiyle ilk slayta erişin.  
3. Varsayılan veri ile bir kabarcık grafik ekleyin.  
4. Grafik serisine erişin.  
5. Çalışma kitabı hücresini veri etiketi olarak ayarlayın.  
6. Sunumu kaydedin.

Bu örnek, en az bir slaytı olan `chart2.pptx` dosyasını açar ve varsayılan veri ile bir kabarcık grafik ekler. İlk serideki ilk üç etiket için çalışma sayfası 0 üzerindeki A10:A12 hücrelerini kullanır, hücrelerden etiketleri etkinleştirir ve sonucu `resultchart.pptx` olarak kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Çalışma Sayfalarını Yönetme**

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) metodu, bir grafik çalışma kitabındaki çalışma sayfalarına erişim sağlar. Bu örnek, varsayılan veri ile bir pasta grafiği oluşturur ve her bir çalışma sayfası adını konsola yazdırır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Veri Kaynağı Türünü Belirtme**

Bu örnek, varsayılan veri ile bir 3B sütun grafiği oluşturur ve iki seri adını farklı veri kaynakları kullanarak ayarlar. İlk ad bir dize sabiti, ikinci ad ise çalışma sayfası 0 üzerindeki C1 hücresidir. [DataSourceType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/datasourcetype/) enum'ı, her bir ad için kaynağı seçer. Sonuç `pres.pptx` olarak kaydedilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Desteklenmeyen Gömülü Çalışma Kitabı Formatlarını Algılama**

Aspose.Slides, bazı grafiklerde gömülebilen Excel ikili çalışma kitabı (.xlsb) formatını desteklemez. [IChartData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/) üzerindeki [getEmbeddedWorkbookType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) metodunu, [WorkbookType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/workbooktype/) enum'ı ile birlikte kullanarak desteklenmeyen formatları tespit edebilir ve bu grafikleri atlayabilirsiniz. Bu örnek, `sample.pptx` dosyasının ilk slaydındaki şekilleri inceler, grafik olmayan şekilleri atlar ve gömülü .xlsb çalışma kitabı olan her grafik için tanı mesajı yazdırır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Desteklenen grafik çalışma kitabı verilerini burada okuyun veya değiştirin.
    }
} finally {
    presentation.dispose();
}
```

## **Dış Çalışma Kitabı**

Aspose.Slides, grafikler için dış çalışma kitaplarını veri kaynağı olarak kullanmayı destekler.

### **Dış Çalışma Kitabı Oluşturma**

Gömülü bir grafik çalışma kitabını bir dosyaya dışa aktarmak ve grafiği bu dış çalışma kitabına bağlamak için [readWorkbookStream](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) ve [setExternalWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) yöntemlerini kullanın.

Bu örnek, varsayılan veri ile bir pasta grafiği oluşturur, çalışma kitabını `externalWorkbook1.xlsx` dosyasına yazar, dosya yazma işlemini tamamlar ve ardından dosyayı grafik veri kaynağı olarak atar. Bağlantılı sunum `externalWorkbook.pptx` olarak kaydedilir.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Dış Çalışma Kitabı Atama**

[setExternalWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metodunu kullanarak bir dış çalışma kitabını grafik veri kaynağı olarak atayabilirsiniz. Bu metod, dış çalışma kitabının yolu değiştirildiğinde (dosya taşındıysa) yolu güncellemek için de kullanılabilir.

Uzak konumlardaki veya kaynaklardaki çalışma kitaplarının verileri düzenlenemez, ancak bu çalışma kitapları dış veri kaynağı olarak kullanılabilir. Bir dış çalışma kitabı için göreli yol sağlanırsa, otomatik olarak tam yola dönüştürülür.

Bu örnek, çalışma dizininde `externalWorkbook.xlsx` dosyasının bulunmasını gerektirir. `Sheet1` adlı çalışma sayfası B1 hücresinde bir seri adı, A2:A4 aralığında kategori adları ve B2:B4 aralığında sayısal değerler içermelidir. Örnek bir pasta grafiği oluşturur, çalışma kitabını bağlar ve [setRange](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) ile A1:B4 aralığını bir seri ve üç kategoriye eşler. Sonuç `Presentation_with_externalWorkbook.pptx` olarak kaydedilir.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) yönteminin `updateChartData` parametresi, çalışma kitabının yüklenip yüklenmeyeceğini kontrol eder.

* `updateChartData` `false` olduğunda, sadece çalışma kitabı yolu güncellenir. Grafik verileri hedef çalışma kitabından yüklenmez veya güncellenmez; bu nedenle çalışma kitabı mevcut olmayabilir.  
* `updateChartData` `true` olduğunda, grafik verileri hedef çalışma kitabından güncellenir.

Aşağıdaki örnek, `updateChartData` değeri `false` olarak ayarlanmış bir yer tutucu URL atar. Pasta grafiğinin varsayılan verileri korunur ve sunum, mevcut olmayan çalışma kitabı yüklenmeden kaydedilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Bir Grafiğin Dış Veri Kaynağı Çalışma Kitabı Yolunu Alma**

Bir grafiğe bağlı çalışma kitabını belirlemek için önce grafiğin dış veri kaynağı kullanıp kullanmadığını kontrol edin. Kullanıyorsa, aşağıdaki adımları izleyerek çalışma kitabı yolunu alabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Sıfır‑tabanlı indeksiyle ilk slayta erişin.  
3. İlk şeklin bir grafik olduğundan emin olun.  
4. Grafik veri kaynağı türünü okuyun.  
5. Kaynak bir dış çalışma kitabı ise, yolunu okuyun.

Bu örnek, önceki örnekte oluşturulan `externalWorkbook.pptx` dosyasını açar ve ilk slaydın ilk şekline bakar. Eğer şekil bir dış çalışma kitabına bağlı bir grafikse, [getExternalWorkbookPath](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) metodunu konsola yazdırır. Ardından sunumun bir kopyasını `Result.pptx` olarak kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Grafik Verilerini Düzenleme**

Dış çalışma kitaplarındaki verileri, iç çalışma kitaplarındaki gibi düzenleyebilirsiniz. Dış bir çalışma kitabı yüklenemediğinde bir istisna fırlatılır.

Bu örnek, ilk slaydının ilk şekli olarak bir grafik içeren `presentation.pptx` ve erişilebilir bir dış çalışma kitabı gerektirir. İlk serideki ilk veri noktasının hücre destekli değerini 100 olarak ayarlar ve sunumu `presentation_out.pptx` olarak kaydeder. Hücre değerlerini düzenlemek, bağlanan dış XLSX dosyasını güncelleyebilir; bu nedenle orijinal çalışma kitabını korumak istiyorsanız bir kopya kullanın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Grafik Önbelleğinden Çalışma Kitabını Kurtarma**

Bir grafik, eksik veya erişilemez bir dış çalışma kitabı kullanıyorsa, Aspose.Slides sunumda önbelleğe alınan verilerden grafik çalışma kitabını yeniden oluşturabilir. [LoadOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/) oluşturun, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) çağırın ve [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) özelliğini `true` yapın; ardından sunumu açın.

Aşağıdaki Java örneği, ilk slaydının ilk şekli bir grafik olan ve erişilemez bir dış çalışma kitabına referans veren `presentation.pptx` dosyasını açar ve verileri [IChart.getChartData](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichart/#getChartData--) ve [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) aracılığıyla elde eder:

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Kurtarılan çalışma kitabı verilerini burada okuyun veya değiştirin.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Dış çalışma kitabı mevcut değil ve kurtarma devre dışı bırakılmışsa, Aspose.Slides bir istisna fırlatır. Yalnızca önbellekteki grafik verilerini kullanmak kabul edilebilir bir geri dönüş yoluysa kurtarmayı etkinleştirin; ancak önbellek, dış çalışma kitabında sunumun son güncellemesinden sonra yapılmış değişiklikleri içermeyebilir.

## **SSS**

**Belirli bir grafiğin dış mı yoksa gömülü bir çalışma kitabına mı bağlı olduğunu nasıl anlayabilirim?**

Evet. Bir grafiğin bir [veri kaynağı türü](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) ve bir [dış çalışma kitabı yolu](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) vardır; kaynak dış bir çalışma kitabı ise tam yolu okuyarak bir dış dosyanın kullanıldığını doğrulayabilirsiniz.

**Dış çalışma kitapları için göreli yollar destekleniyor mu, nasıl depolanıyor?**

Evet. Göreli bir yol belirtirseniz, otomatik olarak mutlak yola dönüştürülür. Sunum, mutlak yolu PPTX dosyasında saklar; bu nedenle çalışma kitabını taşımak, bağlantının güncellenmesini gerektirebilir.

**Ağ kaynakları/paylaşımları üzerindeki çalışma kitaplarını kullanabilir miyim?**

Evet, bu tür çalışma kitapları dış veri kaynağı olarak kullanılabilir. Ancak, Aspose.Slides ile uzak çalışma kitaplarını doğrudan düzenlemek desteklenmez; yalnızca kaynak olarak kullanılabilirler.

**Aspose.Slides, sunumu kaydederken dış XLSX dosyasını üzerine yazar mı?**

Sunum, dış dosyaya bir [bağlantı](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) saklar. Hücre‑destekli grafik verilerini düzenlemek, bağlı yerel XLSX dosyasını da güncelleyebilir. Orijinal dosyanın değişmemesi gerekiyorsa bir kopya kullanın.

**Dış dosya şifre korumalıysa ne yapmalıyım?**

Aspose.Slides, bağlantı sırasında şifre kabul etmez. Yaygın bir çözüm, bağlantıdan önce korumayı kaldırmak veya [Aspose.Cells](https://reference.aspose.com/cells/java/) gibi bir araçla şifresi çözülmüş bir kopya hazırlamaktır.

**Birden çok grafik aynı dış çalışma kitabına referans verebilir mi?**

Evet. Her grafik kendi bağlantısını saklar. Hepsi aynı dosyaya işaret ediyorsa, dosya güncellendiğinde veri bir sonraki yüklemede tüm grafiklerde yansır.