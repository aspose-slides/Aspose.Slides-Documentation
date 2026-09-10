---
title: Python Kullanarak Sunumlarda Grafik Lejantlarını Özelleştirme
linktitle: Grafik Lejantı
type: docs
url: /tr/python-java/chart-legend/
keywords:
- grafik lejantı
- lejant konumu
- yazı tipi boyutu
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "PowerPoint sunumlarını özelleştirilmiş lejant biçimlendirmesiyle optimize etmek için Java aracılığıyla Python için Aspose.Slides ile grafik lejantlarını özelleştirin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında grafik lejantlarını özelleştirme seçenekleri sunar. Bu makalede lejantın konumlandırılması ve boyutlandırılması, tüm lejant için yazı tipi boyutunun ayarlanması ve tek bir lejant girişine biçimlendirme uygulanması gösterilmektedir.

Ayrıca SSS bölümünde, lejant için alan ayırmak amacıyla bindirme (overlay) modunun devre dışı bırakılması, uzun lejant etiketlerinin satır sonu eklenerek veya satır sonu karakterleriyle bölünmesi ve açık renk, dolgu ve yazı tipi ayarları yapılmadığında lejant biçimlendirmesinin sunum temasından devralınması gibi ilgili davranışlar ele alınmaktadır.

## **Lejant Konumlandırma**

Lejant özelliklerini ayarlamak için aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği oluşturun.
1. Slayta bir referans edinin.
1. Slayta bir grafik ekleyin.
1. Lejant özelliklerini ayarlayın.
1. Sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnek, bir grafik lejantının konumunu ve boyutunu ayarlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Boş bir sunum oluştur.
presentation = Presentation()
try:
    # Slayta bir referans alın.
    slide = presentation.getSlides().get_Item(0)

    # Slayta bir kümelenmiş sütun grafiği ekleyin.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Lejant özelliklerini ayarlayın.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # Sunumu diske kaydedin.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bir Leyjantın Yazı Tipi Boyutunu Ayarlama**

Aspose.Slides for Python via Java, bir lejantın yazı tipi boyutunu ayarlamanıza olanak tanır. Aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği oluşturun.
1. Varsayılan grafiği oluşturun.
1. Yazı tipi boyutunu ayarlayın.
1. Minimum eksen değerini ayarlayın.
1. Maksimum eksen değerini ayarlayın.
1. Sunumu disk üzerine kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Boş bir sunum oluştur.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bireysel Leyjant Girişinin Yazı Tipi Boyutunu Ayarlama**

Aspose.Slides for Python via Java, bireysel lejant girişlerinin yazı tipi boyutunu ayarlamanıza olanak tanır. Aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneği oluşturun.
1. Varsayılan grafiği oluşturun.
1. Bir lejant girişine erişin.
1. Yazı tipi boyutunu ayarlayın.
1. Sunumu disk üzerine kaydedin.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Boş bir sunum oluştur.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SSS**

**Leyjantı etkinleştirerek grafiğin üzerine bindirmek yerine otomatik olarak ona yer ayırmasını sağlayabilir miyim?**

Evet. `False` ile `setOverlay` kullanarak bindirme olmayan modu etkinleştirin; bu durumda çizim alanı lejantı barındıracak şekilde küçülür.

**Çok satırlı lejant etiketleri oluşturabilir miyim?**

Evet. Uzun etiketler alan yetersiz olduğunda otomatik olarak satır atlar; zorunlu satır sonları, seri adındaki yeni satır karakterleriyle desteklenir.

**Leyjantın sunum temasının renk şemasını izlemesini nasıl sağlarım?**

Lejant ya da metni için açık renk, dolgu veya yazı tipi ayarlamayın. Böylece tema tarafından devralınır ve tasarım değiştiğinde doğru şekilde güncellenir.