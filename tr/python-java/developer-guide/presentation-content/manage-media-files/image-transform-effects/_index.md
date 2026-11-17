---
title: Python ile Sunumlarda Görüntü Dönüşüm Etkilerini Yönetme
linktitle: Görüntü Dönüşüm Etkileri
type: docs
weight: 11
url: /tr/python-java/image-transform-effects/
keywords:
- görüntü dönüşümü
- resim efekti
- parlaklık
- kontrast
- gri tonlama
- iki tonlu
- renk tonu
- HSL
- renk değiştirme
- bulanıklaştırma
- şeffaflık
- alfa etkisi
- etki zinciri
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Python için Aspose.Slides ile Java üzerinden resim çerçeveleri için görüntü dönüşüm etkilerini uygulayın, zincirleyin, inceleyin, kaldırın ve doğrulayın."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlamalarını sıralı bir görüntü dönüşüm işlemleri koleksiyonu olarak temsil eder. Bir resim çerçevesi için, çerçevenin [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) öğesiyle başlayın ve [Picture.getImageTransform](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#getImageTransform) metoduna erişin. Döndürülen [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/) size orijinal görüntü baytlarını yeniden yazmadan ekleme, sayma, inceleme, kaldırma ve temizleme etkileri yapma imkanı verir.

Bu makale, parlaklık ve kontrast, renk dönüşümleri, bulanıklık, saydamlık, sıralı etki zincirleri, etkili değerler, kaldırma ve PPTX yuvarlak dönüş doğrulaması için eksiksiz bir iş akışı gösterir.

## **Etki Sahipliğini ve Görüntü Yeniden Kullanımını Anlama**

Bir görüntü kaynağı ile onu gösteren resim farklı nesnelerdir:

- [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) sunumun sahip olduğu kaynak görüntü verisini depolar veya referans alır.
- [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) bir resim doldurmanın parçasıdır ve bir görüntü kaynağına işaret ederken görüntü dönüşüm koleksiyonunu saklar.
- [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) ilgili resim doldurmayı, geometriyi, kırpma ayarlarını ve diğer çerçeve‑düzeyi biçimlendirmeleri yöneten slayt şeklidir.

Bu nedenle, görüntü dönüşüm işlemleri [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) içindeki baytları değiştirmez. Aynı `PPImage` nesnesi [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) metoduna birden fazla kez geçirildiğinde, her yeni resim çerçevesi kendi `Picture` ve kendi dönüşüm koleksiyonuna sahip olur. Bir çerçeveye gri tonlama uygulanması diğer çerçeveleri gri tonlamaz, çünkü tüm çerçeveler aynı gömülü görüntü kaynağını yeniden kullanır.

Aynı `Picture.getImageTransform` modeli, şekil veya slayt arka planı gibi diğer resim doldurmaları tarafından da kullanılır. Aşağıdaki örnekler resim çerçevelerine odaklanır.

## **Geçerli Parametre Aralıklarını ve Birimlerini Kullanma**

Gösterilen yöntemler aşağıdaki anlamsal aralık ve birimleri kullanır. Belirli bir kütüphane sürümü hemen her out‑of‑range değeri reddetmese bile bu aralıkları koruyun; hedef sunum formatı kaydetme sırasında veya PowerPoint dosyayı açtığında geçersiz verileri normalleştirebilir, atabilir veya reddedebilir.

| İşlem | Parametreler | Geçerli aralık ve birim |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değiştirmez. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | Yok | Sayısal parametre yok. Alfa değişmez. |
| [addDuotoneEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Koyu ve açık pikseller için iki renk. `java.awt.Color` içinde RGB ve alfa kanalları `0` ile `255` arasındadır. |
| [addTintEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | `hue` `0` dahil `360` hariç derece; `amount` `-100` ile `100` arasında, yüzde. |
| [addHSLEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | `hue` `0` dahil `360` hariç derece; `saturation` ve `luminance` `-100` ile `100` arasında, yüzde. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Değiştirilen renk kanal değerleri `0` ile `255` arasındadır. Mevcut alfa değerleri değişmez. |
| [addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Yarıçap negatif olamaz ve puan cinsinden ölçülür; `grow` bulanık içeriğin orijinal sınırların dışına çıkıp çıkmayacağını kontrol eden Boolean değerdir. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeklemesi için `0` ile `100` kullanın: `0` tamamen şeffaf, `100` mevcut alfabı korur. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` ile `100` arasında, yüzde opaklık. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` ile `100` arasında, yüzde alfa eşiği. Eşiğin altındaki değerler şeffaf, eşiğe eşit veya üstündeki değerler opak olur. |

Sabit alfa modülasyonu için şeffaflık ve opaklık karşılıklıdır. Örneğin, %35 şeffaflık %65 alfa modülasyon miktarına eşittir.

## **Parlaklık ve Kontrast Uygulama**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) bir [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) işlemi döndürür. Skaler ayarlar işlem oluşturulurken sağlanır. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/#getEffective) hesaplanmış, yalnızca‑okunur değerleri döndürür; bu değerler incelenebilir veya günlüğe kaydedilebilir.

Aşağıdaki örnek parlaklığı %15, kontrastı %20 artırır ve gömülü görüntüyü değiştirmeden bir ön izleme oluşturur:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) bir Office 2010 resim‑etki uzantısıdır ve standart DrawingML ışıklılık etkisinden daha az taşınabilir. Parlaklık ve kontrastın PPTX yuvarlak dönüşünden sonra düzenlenebilir kalması gerekiyorsa, [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) kullanın ve dosyayı yeniden açtıktan sonra sonucu doğrulayın. Format sınırlamaları bölümü bu ayrımı daha ayrıntılı açıklar.

## **Renk Dönüşümlerini Uygulama**

Renk etkileri, aynı görüntü kaynağını yeniden kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve sırasıyla gri tonlama, duotone, renk tonu, HSL ayarı ve renk değiştirme uygular.

[Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) iki bağımsız olarak düzenlenebilir renk parametresi içerir: `color1` koyu pikselleri, `color2` ise açık pikselleri temsil eder. Bu, ayarları tek bir skaler değerden daha karmaşık bir etki örneği olduğu için kullanışlı bir örnek olur.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) her pikselin rengini sabit bir renkle değiştirirken alfabı korur. Bu, bir kaynak rengi başka bir renge eşleyen ve hem kaynak hem hedef renk biçimlerini ortaya çıkaran [addColorChangeEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect) işleminden farklıdır.

### **Bir Işıklılık Eşiği Uygulama**

Işıklılık eşiği, taranmış bir sayfada belirsiz işaretlerin arka plandan daha iyi ayırt edilmesini sağlar. [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) ara ton gri tonlarını korur. [addBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBiLevelEffect) ışıklılığı siyah ya da beyaza haritalar, [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) ise şeffaflığa bir eşik uygular.

Işıklılık eşiği %0 ile %100 arasında, iki uç dahil olmak üzere değişir. Eşikten düşük pikseller siyah, eşik ya da üzerindeki pikseller beyaz olur. Eşiği yükseltmek, daha fazla tonu siyaha çevirir çünkü daha fazla ton kesme değerinin altına düşer.

[grayscale-swatches.png](grayscale-swatches.png) dosyasını çalışma dizinine indirin. Her etiket, 0‑255 ölçeğindeki orijinal gri seviyesini gösterir. Örnek, orijinali iki kopya ile yan yana koyar ve her kopyanın eşik değerini sunuma kaydeder.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720.0, 150.0, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    image_data = Path("grayscale-swatches.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    frames = []
    for index, caption in enumerate(("Original", "Threshold 20%", "Threshold 60%")):
        x = 12 + 240 * index
        label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36)
        label.getTextFrame().setText(caption)
        frame = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image)
        frames.append(frame)

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20.0)
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60.0)

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Çıktı sunumunu PowerPoint’te açarak üç çerçeveyi karşılaştırın. 96 etiketli örnek yaklaşık %38 ışıklılığa (96/255) sahiptir. %20 eşiğinde beyaza, %60 eşiğinde ise siyaha dönüşür.

![Orijinal gri örnekler, 20% ve 60% ışıklılık eşiklerinde siyah‑beyaz sonuçların yanında](luminance-threshold.png)

## **Bulanık, Şeffaflık ve Alfa Etkileri Ekleme**

[addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) tüm renk kanallarını, alfa dahil, etkiler. Bulanık kenarın orijinal resim sınırlarının dışına çıkabileceği durumlarda `grow` parametresini `True` olarak ayarlayın.

Tekdüze şeffaflık için [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) kullanın. Bu, mevcut her alfa değerini çarpar; böylece kısmen şeffaf pikseller orantılı olarak farklı kalır. [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) ise tüm piksellere tek bir alfa değeri atar. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) alfa değerini bir eşiğe göre iki seviyeye dönüştürür.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Parametresiz diğer alfa işlemleri arasında [addAlphaCeilingEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect) (sıfır olmayan tüm alfabı tamamen opak yapar), [addAlphaFloorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect) (%100 altında kalan tüm alfabı tamamen şeffaf yapar) ve [addAlphaInverseEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect) (alfa değerini `100% - alfa` olarak değiştirir) bulunur.

## **Sıralı Bir Etki Zinciri Oluşturma**

Her `add...Effect` yöntemi yeni bir işlemi koleksiyonun sonuna ekler. Renderlayıcı koleksiyonu sıralı bir boru hattı gibi kullanır: işlem 0’ın çıktısı işlem 1’in girdisi olur ve bu şekilde devam eder. Dolayısıyla aynı işlemler farklı bir sırada bulunduğunda farklı bir görüntü elde edilebilir.

Örneğin, gri tonlama ardından renk tonu uygulamak önce renk bilgisini siler, ardından ışıklılığı yeniden renklendirir. Renk tonu ardından gri tonlama uygulamak ise renk tonunu tekrar kaldırır. Benzer şekilde, alfa değiştirme daha önceki işlemler tarafından hesaplanan alfa değerlerini geçersiz kılabilir, alfa modülasyonu ise göreceli farklarını korur.

Aşağıdaki örnek dört işlemden oluşan bir zincir oluşturur, PPTX olarak kaydeder, sunumu yeniden açar, hem işlem türlerini hem de sırasını kontrol eder ve yeniden açılan sonucu renderlar:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

Koleksiyon, renk, alfa ve bulanık işlemleri ayrı zincirlere sınırlayan bir uyumluluk matrisi dayatmaz. Birlikte kullanılabilir, ancak kombinasyonlar her zaman faydalı olmayabilir. Sabit renk değiştirme, önceki renk etkileriyle oluşturulan RGB varyasyonunu ortadan kaldırır; duotone’dan sonra gri tonlama iki seçili rengi siler; alfa tavan, taban, değiştirme veya iki‑seviyeli işlemler ise daha önce oluşturulan alfa detayını yok edebilir. Zinciri, istenen piksel‑işleme sırasına göre oluşturun; öğeleri sırasız biçimlendirme bayrakları gibi düşünmeyin.


<!-- visual-explanation:image-transform-effects:start -->
[![Aynı görüntü önce gri tonlamadan sonra renk tonuna, ardından renk tonundan sonra gri tonlamaya geçirilir. İki son gri tonlama görüntüsü farklı tonlardadır.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Bu açıklayıcı Aspose.Slides for .NET 26.11 render'ında, %25 şiddetinde 220° renk tonu gri tonlamayı değiştirmez. Aynı renk tonu gri tonlamadan önce uygulandığında farklı tonlar elde edilir.*
<!-- visual-explanation:image-transform-effects:end -->

## **Düzenlenebilir ve Etkili Değerleri İnceleme**

Düzenlenebilir bir işlem, `Picture.getImageTransform` içinde depolanan nesnedir. Etkiye bağlı olarak, doğrudan yazılabilir üyeler ortaya çıkabilir. Örneğin, [Blur](https://reference.aspose.com/slides/python-java/aspose.slides/blur/) `radius` ve `grow` değerlerini, [AlphaModulateFixed](https://reference.aspose.com/slides/python-java/aspose.slides/alphamodulatefixed/) `amount` değerini, [AlphaBiLevel](https://reference.aspose.com/slides/python-java/aspose.slides/alphabilevel/) `threshold` değerini yazılabilir olarak sunar. [Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) gibi renk etkileri, değiştirilebilir [ColorFormat](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/) nesnelerini ortaya çıkarır.

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/python-java/aspose.slides/tint/) ve [AlphaReplace](https://reference.aspose.com/slides/python-java/aspose.slides/alphareplace/) gibi bazı işlem sınıfları, oluşturma skalerlerini yazılabilir özellikler olarak sunmaz. Bu ayarları değiştirmek için işlemi kaldırıp, istenen konumda yeni bir işlem ekleyin.

`getEffective` tarafından döndürülen etkili veri hesaplanmış ve yalnızca‑okunurdur. Tema‑bağlı renkleri çözümlemek ve renderlayıcının kullandığı normalleştirilmiş değerleri okumak için yararlıdır, fakat başka bir düzenleme yüzeyi değildir. Aşağıdaki örnek zinciri sayar ve ilgili API sağlamışsa etkili değerleri inceler:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

Grayscale, alfa tavan ve alfa ters gibi parametresiz etkiler de bir etkili‑veri nesnesine sahiptir, fakat yazdırılacak skaler ayarları yoktur. Bunların koleksiyondaki varlığı ve konumu önemli bilgidir.

## **Görüntü Dönüşümlerini Kaldırma veya Temizleme**

Bir işlemi dizinle kaldırmak için [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) kullanın. Dizimler kaldırma sonrası kayar, bu nedenle önce hedefi bulun, sonra sayma sırasında kaldırın. Tüm zinciri kaldırmak için [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#clear) kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dönüşümleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Yeniden kullanılan [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) kaynağını silmez, yeniden sıkıştırmaz veya başka bir şekilde değiştirmez.

## **Sunum Formatlarını ve Dışa Aktarım Hedeflerini Düşünme**

Görüntü dönüşümleri DrawingML içinde ortaya çıkar, bu yüzden PPTX etkili zincirler için tercih edilen düzenlenebilir formattır. PPTX ile bile, her işlem aynı taşınabilirliğe sahip değildir:

- Luminance, grayscale, duotone, tint, HSL, blur ve yaygın alfa işlemleri gibi standart DrawingML işlemleri PPTX yuvarlak dönüşünden sonra hayatta kalma olasılığı en yüksek olandır. Oluşturulan dosyayı her zaman yeniden açın ve koleksiyonu inceleyin.
- [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) bir Office 2010 uzantısıdır, standart DrawingML luminance işlemi değildir. Bellek içinde renderlamak için kullanılabilir, fakat kaydedilip PPTX yeniden açıldıktan sonra düzenlenebilir bir [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) olarak kalması garanti değildir. Sürekli parlaklık‑kontrast ayarları için [addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) tercih edin.
- İkili PPT formatı, tam DrawingML etki modelinden önce gelmiştir. PPT’ye kaydetmek, desteklenmeyen işlemleri atabilir, zinciri desteklenen bir alt kümeye azaltabilir ya da görünümü yaklaşık olarak oluşturabilir. Karmaşık düzenlenebilir bir zincir doğrulaması için PPT’yi kullanmayın.
- PNG, JPEG, TIFF, PDF, SVG, HTML gibi görsel çıktı formatları, zinciri renderlanan görünüme uygular. Bu çıktılar düzenlenebilir bir `ImageTransformOperationCollection` içermez; raster formatları sonuçları piksellere dönüştürür, belge/vetor dışa aktarımları ise kendi render temsillerini depolar.
- Etkiler, bağlanmış bir görüntüyü kendine yeterli hâle getirmez. Bağlantılı bir resmin renderlanması, sunum yüklendiğinde bağlı kaynağın mevcut olmasına hâlâ bağlıdır.

Farklı sunum tüketicileri, özellikle birkaç alfa veya renk‑kuantizasyon işlemi bir arada kullanıldığında, kenar durumlarını farklı şekilde işleyebilir. Kritik çıktılar için, üretimde kullanılan aynı Aspose.Slides sürümüyle hem düzenlenebilir yuvarlak dönüşü hem de nihai dışa aktarım formatını test edin.

## **SSS**

**Görüntü dönüşüm etkileri gömülü görüntü verisini değiştirir mi?**

Hayır. İşlemler, resim doldurması tarafından kullanılan `Picture` nesnesine aittir. Alttaki `PPImage` baytları değişmez.

**Aynı görüntüyü yeniden kullanan iki resim çerçevesi etkilerini paylaşır mı?**

Hayır. `PPImage` yeniden kullanımı veri tekrarını önler, ancak her resim çerçevesi genellikle ayrı bir `Picture` ve ayrı bir görüntü dönüşüm koleksiyonuna sahiptir.

**Renk, bulanık ve alfa etkileri bir arada kullanılabilir mi?**

Evet. Koleksiyon bunları tek bir sıralı zincirde kabul eder. Önceki bir işlemin çıktısını değiştirebilecekleri için, her işlemin bir sonrakine ne yaptığını dikkate alın; özellikle değiştirme ve eşik işlemleri önceki renk ya da alfa detayını yok edebilir.

**Etkili değerler neden yalnızca‑okunur?**

Etkili veri, renderlamada kullanılan hesaplanmış değerleri (çözülmüş renkler dahil) temsil eder. Yazılabilir üyeleri olan işlemi, koleksiyondaki nesneyi düzenleyin; aksi takdirde işlemi kaldırıp yeni oluşturma parametreleriyle bir yenisini ekleyin.

**Bir dönüşüm zincirini korumak için hangi formatı kullanmalıyım?**

PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Eski PPT tam DrawingML etki modelini temsil edemez; render çıktıları ise yalnızca görsel görünümü korur, düzenlenebilir dönüşüm operasyonlarını içermez.