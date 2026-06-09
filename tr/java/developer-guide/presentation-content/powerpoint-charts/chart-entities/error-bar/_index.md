---
title: Java Kullanarak Sunum Grafiklerinde Hata Çubuklarını Özelleştirme
linktitle: Hata Çubuğu
type: docs
url: /tr/java/error-bar/
keywords:
- hata çubuğu
- özel değer
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile grafiklere hata çubuğu eklemeyi ve özelleştirmeyi öğrenin—PowerPoint sunumlarındaki veri görsellerini optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerinde hata çubuklarıyla nasıl çalışılacağını açıklar. Bir grafik serisine hata çubukları eklemeyi, X ve Y hata çubuğu ayarlarını yapılandırmayı ve sabit, yüzde ve özel değerler gibi farklı değer türlerini uygulamayı gösterir.

Ayrıca, bir serideki bireysel veri noktaları için ilgili veri noktası koleksiyonunu kullanarak özel hata çubuğu değerlerinin nasıl atanacağını gösterir. Ek olarak, makalede hata çubuklarının dışa aktarım sırasında nasıl davrandığına, işaretçiler ve veri etiketleriyle uyumluluğuna ve ilgili API referans sınıfları ve enum'larının nerede bulunacağına dair kısa notlar yer alır.

## **Hata Çubukları Ekle**
Aspose.Slides for Java, hata çubuğu değerlerini yönetmek için basit bir API sağlar. Örnek kod, özel bir değer türü kullanıldığında uygulanır. Bir değeri belirtmek için, serinin [**DataPoints**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartSeriesCollection) koleksiyonundaki belirli bir veri noktasının **ErrorBarCustomValues** özelliğini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İstenilen slayta bir balon grafik ekleyin.
1. İlk grafik serisine erişin ve hata çubuğu X biçimini ayarlayın.
1. İlk grafik serisine erişin ve hata çubuğu Y biçimini ayarlayın.
1. Çubuk değerlerini ve biçimini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```java
// Presentation sınıfının bir örneğini oluşturun
Presentation pres = new Presentation();
try {
    // Bir balon grafik oluşturma
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Hata çubukları ekleme ve biçimini ayarlama
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // Sunumu kaydetme
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Özel Hata Çubuğu Değerleri Ekle**
Aspose.Slides for Java, özel hata çubuğu değerlerini yönetmek için basit bir API sağlar. Örnek kod, [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IErrorBarsFormat#getValue--) özelliği **Custom** olduğunda uygulanır. Bir değeri belirtmek için, serinin [**DataPoints**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartSeriesCollection) koleksiyonundaki belirli bir veri noktasının **ErrorBarCustomValues** özelliğini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İstenilen slayta bir balon grafik ekleyin.
1. İlk grafik serisine erişin ve hata çubuğu X biçimini ayarlayın.
1. İlk grafik serisine erişin ve hata çubuğu Y biçimini ayarlayın.
1. Grafik serisinin bireysel veri noktalarına erişin ve her bir seri veri noktası için Hata Çubuğu değerlerini ayarlayın.
1. Çubuk değerlerini ve biçimini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```java
// Presentation sınıfının bir örneğini oluşturun
Presentation pres = new Presentation();
try {
    // Bir balon grafik oluşturma
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // Özel hata çubukları ekleme ve biçimini ayarlama
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // Grafik serisi veri noktasına erişme ve hata çubuğu değerlerini ayarlama için
    // tekil nokta
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // Grafik serisi noktaları için hata çubuklarını ayarlama
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // Sunumu kaydetme
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Sunumu PDF veya görüntülere dışa aktardığınızda hata çubukları ne olur?**

Grafiğin bir parçası olarak işlenir ve dönüştürme sırasında, uyumlu bir sürüm veya renderlayıcı varsayıldığında, grafik biçimlendirmesinin geri kalanıyla birlikte korunur.

**Hata çubukları işaretçiler ve veri etiketleriyle birleştirilebilir mi?**

Evet. Hata çubukları ayrı bir öğedir ve işaretçiler ile veri etiketleriyle uyumludur; öğeler çakışırsa biçimlendirmeyi ayarlamanız gerekebilir.

**API'de hata çubuklarıyla çalışmak için özellik ve sınıf listesini nerede bulabilirim?**

API referansında: [ErrorBarsFormat](https://reference.aspose.com/slides/tr/java/com.aspose.slides/errorbarsformat/) sınıfı ve ilgili sınıflar [ErrorBarType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/errorbartype/) ve [ErrorBarValueType](https://reference.aspose.com/slides/tr/java/com.aspose.slides/errorbarvaluetype/).