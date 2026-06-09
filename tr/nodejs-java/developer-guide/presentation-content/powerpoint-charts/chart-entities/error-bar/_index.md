---
title: JavaScript Kullanarak Sunum Grafiklerinde Hata Çubuklarını Özelleştirme
linktitle: Hata Çubuğu
type: docs
url: /tr/nodejs-java/error-bar/
keywords:
- hata çubuğu
- özel değer
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js via Java kullanarak grafiklerde hata çubuklarını eklemeyi ve özelleştirmeyi öğrenin—PowerPoint sunumlarındaki veri görsellerini optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerinde hata çubuklarıyla nasıl çalışılacağını açıklar. Bir grafik serisine hata çubuğu ekleme, X ve Y hata çubuğu ayarlarını yapılandırma ve sabit, yüzde ve özel değerler gibi farklı değer türlerini uygulama yollarını gösterir.

Ayrıca, bir serideki ayrı veri noktalarına özel hata çubuğu değerleri atamayı ilgili veri noktası koleksiyonu kullanarak nasıl yapacağınızı gösterir. Buna ek olarak, hata çubuklarının dışa aktarım sırasında davranışı, işaretçiler ve veri etiketleriyle uyumluluğu ve ilgili API referans sınıfları ve enumlarının nerede bulunacağına dair kısa notlar içerir.

## **Hata Çubuğu Ekle**

Aspose.Slides for Node.js via Java, hata çubuğu değerlerini yönetmek için basit bir API sağlar. Örnek kod, özel bir değer türü kullanıldığında uygulanır. Bir değeri belirtmek için, serinin [**DataPoints**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartSeriesCollection) koleksiyonundaki belirli bir veri noktasının **ErrorBarCustomValues** özelliğini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İstenen slayta bir balon grafik ekleyin.
1. İlk grafik serisine erişin ve hata çubuğu X formatını ayarlayın.
1. İlk grafik serisine erişin ve hata çubuğu Y formatını ayarlayın.
1. Çubuk değerlerini ve formatını ayarlama.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```javascript
// Presentation sınıfının bir örneğini oluştur
var pres = new aspose.slides.Presentation();
try {
    // Balon grafik oluşturma
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Hata çubukları ekleme ve biçimini ayarlama
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // Sunumu kaydetme
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Özel Hata Çubuğu Değeri Ekle**

Aspose.Slides for Node.js via Java, özel hata çubuğu değerlerini yönetmek için basit bir API sağlar. Örnek kod, [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) özelliği **Custom** olduğunda uygulanır. Bir değeri belirtmek için, serinin [**DataPoints**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartSeriesCollection) koleksiyonundaki belirli bir veri noktasının **ErrorBarCustomValues** özelliğini kullanın:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
1. İstenen slayta bir balon grafik ekleyin.
1. İlk grafik serisine erişin ve hata çubuğu X formatını ayarlayın.
1. İlk grafik serisine erişin ve hata çubuğu Y formatını ayarlayın.
1. Grafik serisinin ayrı veri noktalarına erişin ve bireysel seri veri noktası için Hata Çubuğu değerlerini ayarlayın.
1. Çubuk değerlerini ve formatını ayarlama.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```javascript
// Presentation sınıfının bir örneğini oluştur
var pres = new aspose.slides.Presentation();
try {
    // Balon grafik oluşturma
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // Özel hata çubukları ekleme ve biçimini ayarlama
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // Grafik serisi veri noktasına erişme ve hata çubukları değerlerini ayarlama
    // bireysel nokta için
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // Grafik serisi noktaları için hata çubuklarını ayarlama
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // Sunumu kaydetme
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**Bir sunumu PDF veya görüntülere dışa aktarırken hata çubukları ne olur?**

Grafiğin bir parçası olarak işlenir ve dönüştürme sırasında grafik biçimlendirmesinin geri kalanıyla birlikte korunur, uyumlu bir sürüm veya renderlayıcı varsayıldığında.

**Hata çubukları işaretçiler ve veri etiketleriyle birleştirilebilir mi?**

Evet. Hata çubukları ayrı bir öğedir ve işaretçiler ve veri etiketleriyle uyumludur; öğeler çakışırsa biçimlendirmeyi ayarlamanız gerekebilir.

**API'de hata çubuklarıyla çalışmak için özellikler ve enumların listesini nerede bulabilirim?**

API belgelerinde: [ErrorBarsFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/errorbarsformat/) sınıfı ve ilgili enumlar [ErrorBarType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/errorbartype/) ve [ErrorBarValueType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/errorbarvaluetype/).