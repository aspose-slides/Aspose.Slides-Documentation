---
title: Python Kullanarak Sunum Grafiklerinde Hata Çubuklarını Özelleştirme
linktitle: Hata Çubuğu
type: docs
url: /tr/python-java/error-bar/
keywords:
- hata çubuğu
- özel değer
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile grafiklerde hata çubuklarını eklemeyi ve özelleştirmeyi öğrenin—PowerPoint sunumlarında veri görsellerini optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerinde hata çubuklarıyla nasıl çalışılacağını açıklar. Bir grafik serisine hata çubuğu eklemeyi, X ve Y hata çubuğu ayarlarını yapılandırmayı ve sabit, yüzde ve özel değer gibi farklı değer türlerini uygulamayı gösterir.

Ayrıca, ilgili veri noktası koleksiyonunu kullanarak bir serideki ayrı veri noktalarına özel hata çubuğu değerleri nasıl atanacağını gösterir. Makalede, hata çubuklarının dışa aktarım sırasında nasıl davrandığı, işaretçiler ve veri etiketleriyle uyumluluğu ve ilgili API referans sınıfları ve enumlarının nerede bulunacağına dair kısa notlar da yer alır.

## **Hata Çubukları Ekle**

Aspose.Slides for Python via Java, hata çubuğu değerlerini yönetmek için basit bir API sağlar. Aşağıdaki örnek kod sabit ve yüzde değer türlerini kullanır.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İstenen slayta bir balon grafik ekleyin.
1. İlk grafik serisine erişin ve hata çubuğu X biçimini ayarlayın.
1. İlk grafik serisine erişin ve hata çubuğu Y biçimini ayarlayın.
1. Hata çubuğu değerlerini ve biçimlendirmesini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    # Bir balon grafik oluştur.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Hata çubukları ekleyin ve biçimlendirmelerini ayarlayın.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()

    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Fixed)
    error_bar_x.setValue(0.1)
    error_bar_y.setValueType(ErrorBarValueType.Percentage)
    error_bar_y.setValue(5)
    error_bar_x.setType(ErrorBarType.Plus)
    error_bar_y.getFormat().getLine().setWidth(2.0)
    error_bar_x.setEndCap(True)

    # Sunumu kaydedin.
    presentation.save("ErrorBars.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Özel Hata Çubuğu Değerleri Ekle**

Aspose.Slides for Python via Java, özel hata çubuğu değerlerini yönetmek için basit bir API sağlar. Aşağıdaki örnek kod, [getValueType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/errorbarsformat/#getValueType) metodunun [ErrorBarValueType.Custom](https://reference.aspose.com/slides/tr/python-java/aspose.slides/errorbarvaluetype/#Custom) döndürdüğü durumlarda uygulanır. Bir değeri belirtmek için, serinin [getDataPoints](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartseries/#getDataPoints) metodundan dönen koleksiyondaki belirli bir veri noktası için [getErrorBarsCustomValues](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatapoint/#getErrorBarsCustomValues) metodunu kullanın.

1. [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İstenen slayta bir balon grafik ekleyin.
1. İlk grafik serisine erişin ve hata çubuğu X biçimini ayarlayın.
1. İlk grafik serisine erişin ve hata çubuğu Y biçimini ayarlayın.
1. Grafik serisindeki ayrı veri noktalarına erişin ve bunların hata çubuğu değerlerini ayarlayın.
1. Hata çubuğu değerlerini ve biçimlendirmesini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, ErrorBarType, ErrorBarValueType, Presentation, SaveFormat

# Presentation sınıfının bir örneğini oluştur.
presentation = Presentation()
try:
    # Bir balon grafik oluştur.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, True)

    # Özel hata çubukları ekleyin ve biçimlendirmelerini ayarlayın.
    series = chart.getChartData().getSeries().get_Item(0)
    error_bar_x = series.getErrorBarsXFormat()
    error_bar_y = series.getErrorBarsYFormat()
    error_bar_x.setVisible(True)
    error_bar_y.setVisible(True)
    error_bar_x.setValueType(ErrorBarValueType.Custom)
    error_bar_y.setValueType(ErrorBarValueType.Custom)

    # Grafik serisinin veri noktalarına erişin ve hata çubuğu değer kaynaklarını yapılandırın.
    points = series.getDataPoints()
    data_source = points.getDataSourceTypeForErrorBarsCustomValues()
    data_source.setDataSourceTypeForXPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForXMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYPlusValues(jpype.JByte(DataSourceType.DoubleLiterals))
    data_source.setDataSourceTypeForYMinusValues(jpype.JByte(DataSourceType.DoubleLiterals))

    # Grafik serisi veri noktaları için hata çubuğu değerlerini ayarlayın.
    for i in range(points.size()):
        custom_values = points.get_Item(i).getErrorBarsCustomValues()
        custom_values.getXMinus().setAsLiteralDouble(i + 1)
        custom_values.getXPlus().setAsLiteralDouble(i + 1)
        custom_values.getYMinus().setAsLiteralDouble(i + 1)
        custom_values.getYPlus().setAsLiteralDouble(i + 1)

    # Sunumu kaydedin.
    presentation.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Bir sunumu PDF veya görüntülere dışa aktarırken hata çubukları ne olur?**

Hata çubukları grafiğin bir parçası olarak işlenir ve dönüşüm sırasında grafik biçimlendirmesinin geri kalanıyla birlikte korunur; uyumlu bir sürüm veya renderlayıcı varsayıldığında.

**Hata çubukları işaretçiler ve veri etiketleriyle birleştirilebilir mi?**

Evet. Hata çubukları ayrı bir öğedir ve işaretçiler ve veri etiketleriyle uyumludur; öğeler çakışırsa biçimlendirmeyi ayarlamanız gerekebilir.

**API'de hata çubuklarıyla çalışmak için özellikler ve sınıflar listesini nerede bulabilirim?**

API referansında: [ErrorBarsFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/errorbarsformat/) sınıfı ve ilgili sınıflar [ErrorBarType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/errorbartype/) ve [ErrorBarValueType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/errorbarvaluetype/).