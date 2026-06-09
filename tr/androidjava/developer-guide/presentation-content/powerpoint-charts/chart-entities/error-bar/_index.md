---
title: Android'de Sunum Grafiklerinde Hata Çubuklarını Özelleştirme
linktitle: Hata Çubuğu
type: docs
url: /tr/androidjava/error-bar/
keywords:
- hata çubuğu
- özel değer
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile grafiklere hata çubuğu eklemeyi ve özelleştirmeyi öğrenin—PowerPoint sunumlarında veri görsellerini optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerinde hata çubuklarıyla nasıl çalışılacağını açıklar. Bir grafik serisine hata çubuğu ekleme, X ve Y hata çubuğu ayarlarını yapılandırma ve sabit, yüzde ve özel değerler gibi farklı değer tiplerini uygulama konularını gösterir.

Ayrıca, bir serideki bireysel veri noktaları için ilgili veri noktası koleksiyonunu kullanarak özel hata çubuğu değerlerinin nasıl atanacağını gösterir. Makalede, hata çubuklarının dışa aktarım sırasında nasıl davrandığına, işaretçiler ve veri etiketleriyle uyumluluğuna ve ilgili API referans sınıfları ve enum'larının nerede bulunacağına dair kısa notlar da bulunmaktadır.

## **Add Error Bars**
Aspose.Slides for Android via Java, hata çubuğu değerlerini yönetmek için basit bir API sağlar. Örnek kod, özel bir değer tipi kullanıldığında uygulanır. Bir değer belirtmek için serinin [**DataPoints**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartSeriesCollection) koleksiyonundaki belirli bir veri noktasının **ErrorBarCustomValues** özelliğini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İstenen slayta bir balon grafik ekleyin.
1. İlk grafik serisine erişin ve hata çubuğu X formatını ayarlayın.
1. İlk grafik serisine erişin ve hata çubuğu Y formatını ayarlayın.
1. Çubuk değerlerini ve formatını ayarlayın.
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

## **Add Custom Error Bar Values**
Aspose.Slides for Android via Java, özel hata çubuğu değerlerini yönetmek için basit bir API sağlar. Örnek kod, [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IErrorBarsFormat#getValue--) özelliği **Custom** olduğunda uygulanır. Bir değer belirtmek için serinin [**DataPoints**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartSeriesCollection) koleksiyonundaki belirli bir veri noktasının **ErrorBarCustomValues** özelliğini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İstenen slayta bir balon grafik ekleyin.
1. İlk grafik serisine erişin ve hata çubuğu X formatını ayarlayın.
1. İlk grafik serisine erişin ve hata çubuğu Y formatını ayarlayın.
1. Grafik serisinin bireysel veri noktalarına erişin ve bireysel seri veri noktası için Hata Çubuğu değerlerini ayarlayın.
1. Çubuk değerlerini ve formatını ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```java
// Presentation sınıfının bir örneğini oluşturma
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
    // bireysel nokta
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

## **FAQ**

**Bir sunumu PDF veya görüntülere dışa aktarırken hata çubuklarına ne olur?**

Hata çubukları grafiğin bir parçası olarak işlenir ve dönüşüm sırasında grafik biçimlendirmesinin geri kalanıyla birlikte korunur; uyumlu bir sürüm veya renderlayıcı varsayılan olarak kabul edilir.

**Hata çubukları işaretçiler ve veri etiketleriyle birleştirilebilir mi?**

Evet. Hata çubukları ayrı bir öğedir ve işaretçiler ve veri etiketleriyle uyumludur; öğeler çakışırsa biçimlendirmeyi ayarlamanız gerekebilir.

**API'de hata çubuklarıyla çalışmak için özellik ve sınıf listesini nerede bulabilirim?**

API referansında: [ErrorBarsFormat](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/errorbarsformat/) sınıfı ve ilgili sınıflar [ErrorBarType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/errorbartype/) ve [ErrorBarValueType](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/errorbarvaluetype/).