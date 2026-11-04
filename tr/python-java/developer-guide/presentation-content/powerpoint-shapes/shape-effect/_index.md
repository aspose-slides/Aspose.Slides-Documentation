---
title: Python ile Java Kullanarak Sunumlarda Şekil Efektleri Uygula
linktitle: Şekil Efekti
type: docs
weight: 30
url: /tr/python-java/shape-effect/
keywords:
- şekil efekti
- gölge efekti
- yansıma efekti
- parıltı efekti
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

PowerPoint'te efektler bir şeklin öne çıkmasını sağlamak için kullanılabilir, ancak [doldurmaları](/slides/tr/python-java/shape-formatting/#gradient-fill) ya da anahatlardan farklıdır. PowerPoint efektlerini kullanarak bir şeklin üzerinde ikna edici yansımalar oluşturabilir, şeklin parıltısını yayabilir vb.

![Şekil efekti](shape-effect.png)

PowerPoint altı efekt sunar ve bunları şekillere uygulayabilirsiniz. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyidir. Bu nedenle PowerPoint **Preset** altında seçenekler sunar. Preset seçenekleri, iki veya daha fazla etkiden oluşan ve iyi göründüğü bilinen kombinasyonlardır. Böylece bir preset seçerek farklı efektleri deneme veya birleştirme zahmetine girmezsiniz.

Aspose.Slides, [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) sınıfı altında, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan özellikler ve yöntemler sunar.

## **Gölge Efekti Uygula**

Aspose.Slides for Python via Java, şekiller için dış ve iç gölgeleri destekler. Renk, yön, mesafe ve bulanıklık yarıçapını sunum tasarımınıza uygun şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygula**

Dış gölgeyi, bir kartın veya panelin slayt arka planına karşı öne çıkmasını sağlamak için kullanın. Gölge, şeklin kenarlarının ötesine uzanarak şeklin slayt üzerinde yükselmiş izlenimini verir. Renk, yön, mesafe ve bulanıklık yarıçapını şablonunuzun aydınlatması ve stiline uygun şekilde ayarlayın.

Bu Python kodu, bir dikdörtgene [dış gölge efekti](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) uygulamayı gösterir:

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

Bir şablonun görsel stilini yeniden üretirken, bir kartın veya panelin gömülü bir görünüm kazanması için iç gölgeyi kullanın. Dış gölge şeklin dışına uzanırken yükselmiş görünür; iç gölge ise kenarların içini gölgeler.

[enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) yöntemini çağırın, ardından [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) tarafından döndürülen gölgeyi yapılandırın. Daha büyük bulanıklık yarıçapı değerleri daha yumuşak kenarlar üretir.

Bu Python örneği, açık mavi bir kart oluşturur, koyu gri bir iç gölge ekler ve PPTX dosyası olarak kaydeder. Gölge yönü 225 derece, mesafesi 7 nokta ve bulanıklık yarıçapı 6 noktadır:

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

![İç gölgelendirilmiş açık mavi dikdörtgen](inner_shadow_effect.png)

İç gölgeyi kaldırmak için, şeklin efekt formatında [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) yöntemini çağırın.

## **Yansıma Efekti Uygula**

Aspose.Slides for Python via Java'da yansıma efekti uygulamak için, şekillere bir ayna gibi yansıma ekleyebilir, mesafe, şeffaflık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm kazandırarak sunumlarınızın estetiğini artırır. Basit kod ile kolayca uygulanabilir ve tutarlı bir tasarım için birden çok öğeye hızlı bir şekilde uygulanabilir.

Bu Python kodu, bir şekle [yansıma efekti](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) uygulamayı gösterir:

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

## **Parıltı Efekti Uygula**

Aspose.Slides for Python via Java'da bir şekle parıltı efekti uygulamak için, şekillerin etrafına yumuşak, ışıldayan bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekillerin öne çıkmasını sağlar ve sunumunuza çekici, göz alıcı bir görsel öğe ekler. Minimum kodla kolayca uygulanır ve slaytlarınızın genel görünümünü geliştirir.

Bu Python kodu, bir şekle [parıltı efekti](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) uygulamayı gösterir:

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

![Parıltı efekti](glow_effect.png)

## **Yumuşak Kenarlar Efekti Uygula**

Aspose.Slides for Python via Java'da yumuşak kenarlar efekti uygulamak için, bir şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha ince ve zarif bir görünüm kazandırır, hafif ve daha yumuşak bir dış görünüm isteyen tasarımlar için mükemmeldir. İstediğiniz etkiyi elde etmek için yarıçap gibi parametreleri kolayca ayarlayabilirsiniz.

Bu Python kodu, bir şekle [yumuşak kenarlar efekti](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) uygulamayı gösterir:

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

## **Bulanıklaştırma Efekti Uygula**

Şekil bulanıklığı, bir şeklin dolgu ve anahattını yumuşatarak şekli düzenlenebilir tutar. Şeklin efekt formatında [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) yöntemini çağırın. Yarıçap, nokta cinsinden ölçülür (1/72 inç): negatif olmayan bir değer kullanın, daha büyük değerler daha güçlü bulanıklık üretir. Sıfır yarıçap görünümü değiştirmez.

[getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) ayarı, efektin görünen sınırlarını kontrol eder. `False` olduğunda, bulanıklaştırma orijinal boyanmış sınırlarla, anahat dahil, sınırlanır. `True` olduğunda, bulanıklaştırma bu sınırların ötesine uzanabilir. Hiçbir ayar şeklin konumunu veya boyutlarını değiştirmez.

Aşağıdaki karşılaştırma, aynı dolgu, anahat ve şekil boyutlarıyla tüm örneklerde aynı koşulları kullanır. Üst satır `grow = False`; alt satır `grow = True` kullanır.

![Orijinal dikdörtgen, 5 ve 15 nokta bulanıklaştırma yarıçaplarıyla, büyüme devre dışı ve etkin durumlarıyla karşılaştırma](shape_blur_comparison.png)

Bu Python örneği, turuncu bir dikdörtgen oluşturur, koyu mavi bir anahat ekler, 5 nokta bulanıklık uygular ve ardından [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) tekrar çağrılarak 15 nokta bulanıklığa günceller. Her iki bulanıklaştırılmış durumu kaydeder, ardından [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) çağrısıyla bulanıklık olmadan şekli kaydeder.

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

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(255, 165, 0))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    shape.getLineFormat().setWidth(8)

    shape.getEffectFormat().setBlurEffect(5, False)
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().setBlurEffect(15, True)
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx)

    shape.getEffectFormat().disableBlurEffect()
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Şekil bulanıklığı, dolgu ve anahattı birlikte etkiler. Yumuşak kenarlar efekti şeklin kenarlarını soluklaştırırken, gölge bulanıklığı yalnızca gölgeyi yumuşatır. Görüntü dönüşüm efektleri görüntü içeriği üzerinde çalışır; bu örnek, şekli bir görüntüye dönüştürmeden doğrudan şeklin efekt formatına bulanıklık uygular.

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, bir şekle gölge, yansıma ve parıltı gibi farklı efektleri birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Otomatik şekiller, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplandırılmış şekillere efekt uygulayabilir miyim?**

Evet, gruplandırılmış şekillere efekt uygulayabilirsiniz. Efekt tüm grup üzerine uygulanır.