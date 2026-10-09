---
title: Python via Java kullanarak Sunumlarda Şekil Efektleri Uygulama
linktitle: Şekil Efekti
type: docs
weight: 30
url: /tr/python-java/shape-effect/
keywords:
- şekil efekti
- gölge efekti
- yansıma efekti
- parlama efekti
- yumuşak kenarlar efekti
- efekt formatı
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak gelişmiş şekil efektleriyle PPT ve PPTX dosyalarınızı dönüştürün—saniyeler içinde çarpıcı, profesyonel slaytlar oluşturun."
---
## **Giriş**

PowerPoint'teki efektler bir şekli öne çıkarmak için kullanılabilirken, [dolgu](/slides/tr/python-java/shape-formatting/#gradient-fill) veya kenarlıklardan farklıdır. PowerPoint efektlerini kullanarak bir şekil üzerinde ikna edici yansımalar oluşturabilir, şeklin parlamasını yayabilirsiniz vb.

![Şekil efekti](shape-effect.png)

PowerPoint, şekillere uygulanabilen altı efekt sağlar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle, PowerPoint **Ön Ayar** altında seçenekler sunar. Ön Ayar seçenekleri iki veya daha fazla etkili bir şekilde görülen kombinasyonlardır. Böylece bir ön ayar seçerek, güzel bir kombinasyon bulmak için farklı efektleri test etmek veya birleştirmek için zaman kaybetmezsiniz.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanıza olanak tanıyan [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sağlar.

## **Gölge Efekti Uygulama**

Aspose.Slides for Python via Java, şekiller için dış ve iç gölgeleri destekler. Renk, yön, mesafe ve bulanıklaştırma yarıçapını sunum tasarımınıza uyacak şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygula**

Bir kartın veya panelin slayt arka planına karşı öne çıkmasını sağlamak için dış gölge kullanın. Gölge, şeklin kenarlarının ötesine uzanır ve şeklin slayt üzerinde yükselmiş gibi bir izlenim yaratır. Renk, yön, mesafe ve bulanıklaştırma yarıçapını şablonunuzun aydınlatması ve stiline uyacak şekilde ayarlayın.

Bu Python kodu, bir dikdörtgene [dış gölge efekti](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) nasıl uygulanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableOuterShadowEffect()
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color(169, 169, 169))
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10)
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45)

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Gölge efekti](shadow_effect.png)

### **İç Gölge Uygula**

Bir şablonun görsel stilini yeniden üretirken, bir kartın veya panelin gömülü bir görünüm kazanması için iç gölge kullanın. Dış gölge şeklin dışına uzanır ve yükselmiş görünürken, iç gölge kenarlarının içini gölgeler.

[enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) metodunu çağırın, ardından [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) tarafından döndürülen gölgeyi yapılandırın. Daha büyük bulanıklaştırma yarıçapı değerleri daha yumuşak kenarlar üretir.

Bu Python örneği, iç gölgeli açık mavi bir kart oluşturur ve bir PPTX dosyası olarak kaydeder. Gölge yönü 225 derece, mesafesi 7 puan ve bulanıklaştırma yarıçapı 6 puandır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(173, 216, 230))
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    shape.getEffectFormat().enableInnerShadowEffect()
    shadow = shape.getEffectFormat().getInnerShadowEffect()
    shadow.getShadowColor().setColor(Color(105, 105, 105))
    shadow.setDirection(225)
    shadow.setDistance(7)
    shadow.setBlurRadius(6)

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![İç gölgelikli açık mavi dikdörtgen](inner_shadow_effect.png)

İç gölgeyi kaldırmak için şeklin efekt formatı üzerinde [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) metodunu çağırın.

## **Yansıma Efekti Uygulama**

Aspose.Slides for Python via Java'da bir yansıma efekti uygulamak için, şekillere ayna gibi bir yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm kazandırarak sunumlarınızın estetiğini artırır. Basit kodla kolayca uygulanır ve tutarlı bir tasarım için birden çok öğeye hızlıca uygulanabilir.

Bu Python kodu, bir şekle [yansıma efekti](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) nasıl uygulanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RectangleAlignment, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableReflectionEffect()
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom)
    shape.getEffectFormat().getReflectionEffect().setDirection(90)
    shape.getEffectFormat().getReflectionEffect().setDistance(40)
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2)

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Yansıma efekti](reflection_effect.png)

## **Parlama Efekti Uygulama**

Aspose.Slides for Python via Java'da bir şekle parlama efekti uygulamak için, şekillerin etrafına yumuşak, ışıklı bir aura ekleyebilir ve renk ile boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekilleri öne çıkarmaya yardımcı olur ve sunumunuza çekici, göz alıcı bir görsel öğe ekler. Minimum kodla kolayca uygulanır ve slaytlarınızın genel görünümünü iyileştirir.

Bu Python kodu, bir şekle [parlama efekti](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) nasıl uygulanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100)
    shape.getEffectFormat().enableGlowEffect()
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA)
    shape.getEffectFormat().getGlowEffect().setRadius(15)

    presentation.save("glow_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Parlama efekti](glow_effect.png)

## **Yumuşak Kenarlar Efekti Uygulama**

Aspose.Slides for Python via Java'da bir yumuşak kenarlar efekti uygulamak için, bir şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş yaratabilirsiniz. Bu efekt, daha ince ve zarif bir görünüm ekler; hafif ve daha yumuşak bir görünüm gerektiren tasarımlar için mükemmeldir. Yarıçap gibi parametreleri kolayca ayarlayarak, sunumunuzdaki çeşitli şekillerde istenen etkiyi elde edebilirsiniz.

Bu Python kodu, bir şekle [yumuşak kenarlar efekti](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) nasıl uygulanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150)
    shape.getEffectFormat().enableSoftEdgeEffect()
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8)

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Yumuşak kenarlar efekti](soft_edges_effect.png)

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, bir şekle gölge, yansıma ve parlama gibi farklı efektleri birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Autoshape'ler, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplandırılmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Efekt tüm grup üzerinde uygulanır.