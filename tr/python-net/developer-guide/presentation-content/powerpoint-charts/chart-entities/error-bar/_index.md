---
title: Python ile Sunum Grafiklerinde Hata Çubuklarını Özelleştirme
linktitle: Hata Çubuğu
type: docs
url: /tr/python-net/error-bar/
keywords:
- hata çubuğu
- özel değer
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak grafiklerde hata çubuklarını eklemeyi ve özelleştirmeyi öğrenin—PowerPoint ve OpenDocument sunumlarında veri görselliğini optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerinde hata çubuklarıyla nasıl çalışılacağını açıklar. Bir grafik serisine hata çubuğu eklemeyi, X ve Y hata çubuğu ayarlarını yapılandırmayı ve sabit, yüzde ve özel değerler gibi farklı değer tiplerini uygulamayı gösterir.

Ayrıca, bir serideki tek tek veri noktalarına karşılık gelen veri noktası koleksiyonunu kullanarak özel hata çubuğu değerlerinin nasıl atanacağını gösterir. Ek olarak, makalede hata çubuklarının dışa aktarım sırasında nasıl davrandığı, işaretçiler ve veri etiketleriyle uyumluluğu ve ilgili API referans sınıfları ve enumlarının nerede bulunabileceği hakkında kısa notlar yer alır.

## **Hata Çubuğu Ekle**
Aspose.Slides for Python via .NET, hata çubuğu değerlerini yönetmek için basit bir API sağlar. Örnek kod, özel bir değer türü kullanıldığında uygulanır. Bir değeri belirtmek için, serinin **DataPoints** koleksiyonundaki belirli bir veri noktasının **ErrorBarCustomValues** özelliğini kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İstediğiniz slayta bir balon grafiği ekleyin.
1. İlk grafik serisine erişin ve hata çubuğu X biçimini ayarlayın.
1. İlk grafik serisine erişin ve hata çubuğu Y biçimini ayarlayın.
1. Çubuk değerlerini ve biçimini ayarlama.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Boş sunum oluşturma
with slides.Presentation() as presentation:
    # Balon grafik oluşturma
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Hata çubuklarını ekleme ve biçimini ayarlama
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # Sunumu kaydetme
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Özel Hata Çubuğu Değeri Ekle**
Aspose.Slides for Python via .NET, özel hata çubuğu değerlerini yönetmek için basit bir API sağlar. Örnek kod, **IErrorBarsFormat.ValueType** özelliği **Custom** değerine eşit olduğunda uygulanır. Bir değeri belirtmek için, serinin **DataPoints** koleksiyonundaki belirli bir veri noktasının **ErrorBarCustomValues** özelliğini kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İstediğiniz slayta bir balon grafiği ekleyin.
1. İlk grafik serisine erişin ve hata çubuğu X biçimini ayarlayın.
1. İlk grafik serisine erişin ve hata çubuğu Y biçimini ayarlayın.
1. Grafik serisinin tek tek veri noktalarına erişin ve bireysel seri veri noktası için Hata Çubuğu değerlerini ayarlayın.
1. Çubuk değerlerini ve biçimini ayarlama.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Boş sunum oluşturma
with slides.Presentation() as presentation:
    # Balon grafik oluşturma
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Özel hata çubuklarını ekleme ve biçimini ayarlama
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Grafik serisi veri noktasına erişme ve bireysel nokta için hata çubuğu değerlerini ayarlama
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Grafik serisi noktaları için hata çubuklarını ayarlama
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Sunumu kaydetme
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Bir sunum PDF ya da görüntü olarak dışa aktarıldığında hata çubukları ne olur?**

Hata çubukları, grafiğin bir parçası olarak render edilir ve dönüştürme sırasında grafik biçimlendirmesinin geri kalanıyla birlikte, uyumlu bir sürüm veya işleyici varsayıldığında korunur.

**Hata çubukları işaretçiler ve veri etiketleriyle birleştirilebilir mi?**

Evet. Hata çubukları ayrı bir öğedir ve işaretçiler ve veri etiketleriyle uyumludur; öğeler çakışıyorsa biçimlendirmeyi ayarlamanız gerekebilir.

**API'de hata çubuklarıyla çalışmak için özellikler ve enumların listesini nerede bulabilirim?**

API referansında: [ErrorBarsFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/errorbarsformat/) sınıfı ve ilgili enumlar [ErrorBarType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/errorbartype/) ve [ErrorBarValueType](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/errorbarvaluetype/).