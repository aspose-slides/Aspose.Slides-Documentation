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

PowerPoint'teki etkiler, bir şeklin öne çıkmasını sağlamak için kullanılabilir, ancak [dolgulardan](/slides/tr/python-java/shape-formatting/#gradient-fill) veya kenarlıklardan farklıdır. PowerPoint efektlerini kullanarak bir şekil üzerinde ikna edici yansımalar oluşturabilir, şeklin parıltısını yayabilirsiniz vb.

![Gölge efekti](shape-effect.png)

PowerPoint, şekillere uygulanabilen altı efekt sunar. Bir şekle bir veya daha fazla efekt uygulayabilirsiniz.

Bazı efekt kombinasyonları diğerlerinden daha iyi görünür. Bu nedenle, PowerPoint **Ön Tanımlı** altında seçenekler sunar. Ön Tanımlı seçenekler, iyi göründüğü bilinen iki veya daha fazla efektin kombinasyonlarıdır. Böylece bir ön tanımlı seçerek farklı efektleri deneme veya birleştirme konusunda zaman harcamazsınız.

Aspose.Slides, PowerPoint sunumlarındaki şekillere aynı efektleri uygulamanızı sağlayan [EffectFormat](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/) sınıfı altında özellikler ve yöntemler sunar.

## **Gölge Efekti Uygulama**

Aspose.Slides for Python via Java, şekiller için dış ve iç gölgeleri destekler. Renk, yön, mesafe ve bulanıklaştırma yarıçapını sunum tasarımınıza uygun şekilde özelleştirebilirsiniz.

### **Dış Gölge Uygula**

Bir kartın veya panelin slayt arka planına karşı öne çıkmasını sağlamak için dış gölge kullanın. Gölge, şeklin kenarlarının ötesine uzanarak şeklin slayt üzerinde yükselmiş gibi görünmesini yaratır. Şablonunuzun ışıklandırma ve stiline uygun şekilde renk, yön, mesafe ve bulanıklaştırma yarıçapını ayarlayın.

Bu Python kodu, bir dikdörtgene [outer shadow effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getOuterShadowEffect) nasıl uygulanacağını gösterir:

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

#### **Şekil Döndürülürken Gölge Yönünü Kontrol Etme**

Varsayılan olarak dış gölge, şekil ile birlikte döner. Farklı döndürmelere sahip şekillerin aynı yönden aydınlatılmış gibi görünmesini sağlamak için [setRotateShadowWithShape](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setRotateShadowWithShape) metodunu `False` olarak çağırın ve gölgelerine aynı yönü vermek için [setDirection](https://reference.aspose.com/slides/python-java/aspose.slides/outershadow/#setDirection) metodunu kullanın.

Örnek, 42 puan sağa kaydırılmış gri gölgeli iki mavi ok oluşturur (0°). Ardından slaytı kopyalar ve her iki oku saat yönünde 90° döndürür.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    before = presentation.getSlides().get_Item(0)
    
    left = before.getShapes().addAutoShape(ShapeType.RightArrow, 55, 130, 110, 60)
    left.getFillFormat().setFillType(FillType.Solid)
    left.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    left.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    left.getEffectFormat().enableOuterShadowEffect()
    shadow = left.getEffectFormat().getOuterShadowEffect()
    shadow.getShadowColor().setColor(Color.GRAY)
    shadow.setDirection(0)
    shadow.setDistance(42)
    shadow.setBlurRadius(0)
    shadow.setRotateShadowWithShape(True)

    right = before.getShapes().addClone(left)
    right.setX(395)
    right.getEffectFormat().getOuterShadowEffect().setRotateShadowWithShape(False)

    after = presentation.getSlides().addClone(before)
    for arrow in after.getShapes():
        arrow.setRotation(90)

    presentation.save("arrow_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

İkinci slaytta sol ok gölgesini aşağı doğru verirken, sağ ok gölgesini hâlâ sağa verir. Yapılandırılmış yön her iki gölge için de 0° olarak kalır.

![PowerPoint renderi 90° döndürmeden önce ve sonra. Her iki gölge de sağda başlar. Döndürmeden sonra gölge sol okun altında ve sağ okun sağında kalır.](arrow-shadow-rotation.png)

### **İç Gölge Uygula**

Bir şablonun görsel stilini yeniden oluştururken, bir kartın veya panelin içe gömmüş bir görünüm kazanması için iç gölge kullanın. Dış gölge şeklin dışına uzanarak yükselmiş görünüm sağlarken, iç gölge kenarların içini gölgelendirir.

[enableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enableInnerShadowEffect) metodunu çağırın, ardından [getInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getInnerShadowEffect) tarafından döndürülen gölgeyi yapılandırın. Daha büyük bulanıklaştırma yarıçapı değerleri daha yumuşak kenarlar üretir.

Bu Python örneği, koyu gri bir iç gölgeye sahip açık mavi bir kart oluşturur ve bir PPTX dosyası olarak kaydeder. Gölge yönü 225 derecedir, mesafesi 7 puan, bulanıklaştırma yarıçapı 6 puandır:

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

İç gölgeyi kaldırmak için, şeklin effect formatı üzerinde [disableInnerShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableInnerShadowEffect) metodunu çağırın.

### **Ön Tanımlı Gölge Uygulama, Değiştirme ve Kaldırma**

[enablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#enablePresetShadowEffect) metodunu çağırın, ardından bir [PresetShadowType](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadowtype/) seçmek için [setPreset](https://reference.aspose.com/slides/python-java/aspose.slides/presetshadow/#setPreset) metodunu kullanın. Stil değiştirmek için aynı şekil üzerindeki ön tanımlıyı değiştirin. Gölgeyi doldurma ve kenarlığı koruyarak kaldırmak için [disablePresetShadowEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disablePresetShadowEffect) metodunu çağırın.

Örnek, her aşamada dikdörtgeni klonlayarak dört durumu yan yana karşılaştırabilmeniz için tek bir slaytta gösterir. Her iki gölge de 10 puan kaydırılmıştır. 225° yön, ilk gölgeyi dikdörtgenin üst soluna yerleştirir. 45° yön ise ikinci gölgeyi alt sağa yerleştirir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, PresetShadowType, SaveFormat, ShapeType, SlideSizeScaleType
from java.awt import Color

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color(70, 130, 180))
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    text_frame = shape.getTextFrame()
    text_frame.setText("No shadow")
    paragraph_format = text_frame.getParagraphs().get_Item(0).getParagraphFormat()
    paragraph_format.getDefaultPortionFormat().setFontHeight(14)
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().enablePresetShadowEffect()
    shadow = shape.getEffectFormat().getPresetShadowEffect()
    shadow.setPreset(PresetShadowType.TopLeftDropShadow)
    shadow.setDistance(10)
    shadow.setDirection(225)
    text_frame.setText("TopLeftDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shadow.setPreset(PresetShadowType.BottomRightDropShadow)
    shadow.setDirection(45)
    text_frame.setText("BottomRightDropShadow")
    shapes.addClone(shape)

    shape.setX(shape.getX() + 200)
    shape.getEffectFormat().disablePresetShadowEffect()
    text_frame.setText("No shadow")

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Orijinal | İlk ön tanımlı | İkinci ön tanımlı | Kaldırıldıktan sonra |
| :---: | :---: | :---: | :---: |
| ![Gölge yok](preset_shadow_original.png) | ![ÜstSol Düşüş Gölgesi](preset_shadow_top_left.png) | ![AltSağ Düşüş Gölgesi](preset_shadow_bottom_right.png) | ![Kaldırma sonrası gölge yok](preset_shadow_removed.png) |

## **Yansıma Efekti Uygulama**

Aspose.Slides for Python via Java'da bir yansıma efekti uygulamak için şekillere ayna gibi bir yansıma ekleyebilir, mesafe, saydamlık ve boyut gibi parametreleri ayarlayabilirsiniz. Bu efekt, şekillere daha cilalı ve sofistike bir görünüm kazandırarak sunumlarınızın estetiğini artırır. Basit kodla kolayca uygulanabilir ve birden çok öğeye tutarlı bir tasarım getirir.

Bu Python kodu, bir şekle [reflection effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getReflectionEffect) nasıl uygulanacağını gösterir:

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

## **Parıltı Efekti Uygulama**

Aspose.Slides for Python via Java'da bir şekle parıltı efekti uygulamak için şeklin etrafına yumuşak, ışıklı bir aura ekleyebilir, renk ve boyut gibi özellikleri ayarlayabilirsiniz. Bu efekt, şekilleri öne çıkarır ve sunumunuza çekici, göz alıcı bir görsel öğe ekler. Minimal kodla uygulanır ve slaytların genel görünümünü geliştirir.

Bu Python kodu, bir şekle [glow effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getGlowEffect) nasıl uygulanacağını gösterir:

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

## **Yumuşak Kenarlar Efekti Uygulama**

Aspose.Slides for Python via Java'da yumuşak kenarlar efekti uygulamak için bir şeklin kenarları etrafında pürüzsüz, bulanık bir geçiş oluşturabilirsiniz. Bu efekt, daha ince ve rafine bir görünüm ekler; özellikle nazik, daha yumuşak bir görünüm gerektiren tasarımlar için idealdir. Yarıçap gibi parametreleri kolayca ayarlayarak istediğiniz etkiyi çeşitli şekillerde elde edebilirsiniz.

Bu Python kodu, bir şekle [soft edges effect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#getSoftEdgeEffect) nasıl uygulanacağını gösterir:

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

## **Bulanıklaştırma Efekti Uygulama**

Şekil bulanıklaştırma, şeklin doldurmasını ve kenarlığını yumuşatırken şekli düzenlenebilir tutar. Şeklin effect formatı üzerinde [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) metodunu çağırın. Yarıçap puan cinsindendir (1/72 inç): negatif olmayan bir değer kullanın; büyük değerler daha güçlü bulanıklık üretir. Yarıçap sıfır olduğunda görünüm değişmez.

[getGrow](https://reference.aspose.com/slides/python-java/aspose.slides/blur/#getGrow) ayarı, etkinin görünen sınırlarını kontrol eder. `False` ise bulanıklık, çerçeve dahil orijinal boyalı sınırlara kırpılır. `True` ise bulanıklık bu sınırlardan dışarı uzanabilir. Hiçbir ayar şeklin konumunu veya boyutunu değiştirmez.

Aşağıdaki karşılaştırma, aynı doldurma, kenarlık ve şekil boyutlarını tüm süreçte kullanır. Üst satır `grow = False`; alt satır `grow = True`.

![5 ve 15 puan bulanıklaştırma yarıçaplarıyla, büyüme devre dışı ve etkin olarak karşılaştırılan orijinal dikdörtgen](shape_blur_comparison.png)

Bu Python örneği, turuncu bir dikdörtgen oluşturur, koyu mavi bir kenarlık ekler, 5 puanlık bir bulanıklık uygular ve ardından aynı dikdörtgene tekrar [setBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#setBlurEffect) çağırarak 15 puanlık bir bulanıklık verir. Her iki bulanıklaştırılmış durumu kaydeder, ardından [disableBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/effectformat/#disableBlurEffect) metodunu çağırarak bulanıklaştırmasız şekli kaydeder.

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

Şekil bulanıklığı doldurma ve kenarlığı birlikte etkiler. Yumuşak kenarlar efekti şeklin kenarlarını kararırken, gölge bulanıklığı yalnızca gölgeyi yumuşatır. Görüntü dönüşüm efektleri görüntü içeriği üzerinde çalışır; bu örnek şekli bir görüntüye dönüştürmeden doğrudan şeklin effect formatına bulanıklık uygular.

## **SSS**

**Aynı şekle birden fazla efekt uygulayabilir miyim?**

Evet, gölge, yansıma ve parıltı gibi farklı efektleri tek bir şekle birleştirerek daha dinamik bir görünüm oluşturabilirsiniz.

**Hangi şekillere efekt uygulayabilirim?**

Otomatik şekiller, grafikler, tablolar, resimler, SmartArt nesneleri, OLE nesneleri ve daha fazlası dahil olmak üzere çeşitli şekillere efekt uygulayabilirsiniz.

**Gruplandırılmış şekillere efekt uygulayabilir miyim?**

Evet, grup içindeki tüm şekillere aynı anda efekt uygulanır. Etki, tüm grup için geçerli olur.