---
title: Python ile Sunumlarda Görüntü Dönüşüm Efektlerini Yönetin
linktitle: Görüntü Dönüşüm Efektleri
type: docs
weight: 11
url: /tr/python-net/image-transform-effects/
keywords:
- görüntü dönüşümü
- resim efekti
- parlaklık
- kontrast
- gri tonlama
- ikoton
- renk tonu
- HSL
- renk değiştirme
- bulanıklaştırma
- şeffaflık
- alfa efekti
- efekt zinciri
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile resim çerçeveleri için görüntü dönüşüm efektlerini uygula, zincirle, incele, kaldır ve doğrula."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlamalarını görüntü dönüşüm işlemlerinin sıralı bir koleksiyonu olarak temsil eder. Bir resim çerçevesi için, çerçevenin [Resim](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) ile başlayın ve onun [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/) özelliğine erişin. Döndürülen [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) eklemenize, sıralamanıza, incelemenize, kaldırmanıza ve efektleri temizlemenize olanak tanır; orijinal görüntü baytlarını yeniden yazmadan.

Bu makale, parlaklık ve kontrast, renk dönüşümleri, bulanıklaştırma, şeffaflık, sıralı efekt zincirleri, etkili değerler, kaldırma ve PPTX tam döndürme doğrulaması için tam bir iş akışını göstermektedir.

## **Efekt Sahipliğini ve Görüntü Yeniden Kullanımını Anlayın**

Bir görüntü kaynağı ve onu görüntüleyen resim farklı nesnelerdir:

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) sunumun sahip olduğu kaynak görüntü verilerini depolar veya referans verir.
- [Resim](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) bir resim doldurmanın parçasıdır ve bir görüntü kaynağına referans verir; aynı zamanda görüntü dönüşüm koleksiyonunu depolar.
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) ilgili resim doldurmayı, geometriyi, kırpma ayarlarını ve diğer çerçeve düzeyinde biçimlendirmeleri sahip olan slayt şeklidir.

Bu nedenle, görüntü dönüşüm işlemleri [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) içindeki baytları değiştirmez. Aynı `PPImage` birden fazla kez [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) metoduna geçirilirse, her yeni resim çerçevesi kendi `Resim` ve kendi dönüşüm koleksiyonunu alır. Bir çerçeveye gri tonlama uygulamak diğer çerçeveleri gri tonlamaz, çünkü tüm çerçeveler aynı gömülü görüntü kaynağını yeniden kullanır ancak her biri kendi `Resim` nesnesine sahiptir.

Aynı `Picture.image_transform` modeli şekil doldurması ya da slayt arka planı gibi diğer resim doldurmaları tarafından da kullanılır. Aşağıdaki örnekler yalnızca resim çerçevelerine odaklanır.

## **Geçerli Parametre Aralıkları ve Birimlerini Kullanın**

Gösterilen yöntemler aşağıdaki anlamsal aralıkları ve birimleri kullanır. Bir kütüphane sürümü hemen her geçersiz değeri reddetmese bile bu aralıklarda kalın; hedef sunum formatı kaydetme sırasında veya PowerPoint dosyayı açtığında geçersiz verileri normalleştirebilir, atabilir veya reddedebilir.

| İşlem | Parametreler | Geçerli aralık ve birim |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değişmeden bırakır. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | Sayısal parametre yok. Alfa değişmez. |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Karanlık ve açık pikseller için iki renk. RGB ve alfa kanalları `0` ile `255` arasında kullanılır. |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Ton, derece cinsinden `0` dahil ve `360` hariç; miktar `-100` ile `100` arasında, yüzde. |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Ton, derece cinsinden `0` dahil ve `360` hariç; doygunluk ve ışıklılık `-100` ile `100` arasında, yüzde. |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Değiştirme rengi kanal değerlerini `0` ile `255` arasında kullanır. Mevcut alfa değerleri değişmez. |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Yarıçap negatif değildir ve puan olarak ölçülür; `grow` bulanık içeriğin orijinal sınırların dışına çıkıp çıkmayacağını kontrol eden bir Boolean'dır. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeklemesi için `0` ile `100` kullanın: `0` tamamen şeffaf, `100` mevcut alfanı korur. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` ile `100` arasında, yüzde opaklık. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` ile `100` arasında, yüzde alfa eşiği. Bu değerin altındaki değerler şeffaf, eşit veya üstündekiler opak olur. |

Sabit alfa modülasyonu için şeffaflık ve opaklık birbirini tamamlar. Örneğin, %35 şeffaflık %65 alfa modülasyonu miktarına karşılık gelir.

## **Parlaklık ve Kontrast Uygula**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) bir [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) işlemi döndürür. İşlem oluşturulduğunda skaler ayarlar sağlanır. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) hesaplanmış, yalnızca okunabilir değerleri döndürür; bu değerler incelenebilir veya günlüğe kaydedilebilir.

Aşağıdaki örnek parlaklığı %15, kontrastı %20 artırır ve ardından gömülü görüntüyü değiştirmeden bir ön izleme render eder:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) bir Office 2010 resim‑efekti uzantısıdır ve standart DrawingML ışıklılık efektine göre daha az taşınabilirdir. Parlaklık ve kontrastın bir PPTX tam dönüşünden sonra düzenlenebilir kalması gerekiyorsa, [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) kullanın ve dosyayı yeniden açtıktan sonra sonucu doğrulayın. Biçim sınırlamaları bölümü bu ayrımı daha ayrıntılı açıklar.

## **Renk Dönüşümlerini Uygula**

Renk efektleri, aynı görüntü kaynağını yeniden kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve gri tonlama, ikitonu, renk tonu, HSL ayarı ve renk değiştirmeyi uygular.

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) iki bağımsız olarak düzenlenebilir renk parametresi içerir: `color1` koyu pikselleri, `color2` ise açık pikselleri eşler. Bu, ayarları tek bir skaler değerden daha karmaşık bir etki örneği olduğu için yararlı bir örnek oluşturur.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) her pikselin rengini sabit bir renkle değiştirirken alfa değerini korur. Bu, bir kaynak rengi başka bir renge eşleyen ve hem kaynak hem hedef renk biçimlerini ortaya çıkaran [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/) metodundan farklıdır.

### **Luminans Eşiği Uygula**

Bir luminans eşiği, taranmış bir sayfadaki hafif izlerin arka plandan daha kolay ayırt edilmesini sağlar. [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) ara gri tonları korur. [add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) luminansı siyah veya beyaza eşler, [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) ise opaklığa bir eşik uygular.

Luminans eşiği %0 ile %100 arasında, dahil olmak üzere değişir. Eşiğin altındaki pikseller siyah olur. Eşiğe eşit veya üstteki pikseller beyaz olur. Eşiği yükseltmek daha fazla tonu siyaha çevirir çünkü daha fazla ton kesim noktasının altına düşer.

[grayscale-swatches.png](grayscale-swatches.png) dosyasını çalışma dizinine indirin. Her etiket, 0‑255 ölçeğindeki orijinal gri seviyesini gösterir. Örnek, orijinali iki kopyasının yanına koyar ve her kopyanın eşik değerini sunuma kaydeder.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 150, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    with slides.Images.from_file("grayscale-swatches.png") as source_image:
        image = presentation.images.add_image(source_image)

    def add_frame(x, caption):
        label = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 12, 216, 36)
        label.text_frame.text = caption
        return shapes.add_picture_frame(slides.ShapeType.RECTANGLE, x, 60, 216, 72, image)

    add_frame(12, "Original")

    low_threshold = add_frame(252, "Threshold 20%")
    low_threshold.picture_format.picture.image_transform.add_bi_level_effect(20)
    
    high_threshold = add_frame(492, "Threshold 60%")
    high_threshold.picture_format.picture.image_transform.add_bi_level_effect(60)

    presentation.save("luminance-threshold.pptx", slides.export.SaveFormat.PPTX)
```

Üç çerçeveyi karşılaştırmak için çıktıyı PowerPoint’te açın. 96 etiketli örnek yaklaşık %38 luminansa sahiptir (255 içinde 96). %20 eşiğinde beyaza, %60 eşiğinde ise siyaha dönüşür.

![Orijinal gri ton örnekleri, %20 ve %60 luminans eşikleriyle siyah‑beyaz sonuçların yanında](luminance-threshold.png)

## **Bulanıklık, Şeffaflık ve Alfa Efektleri Ekle**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) tüm renk kanallarını, alfab dahil, etkiler. Bulanık kenar orijinal resim sınırlarının dışına çıkabilecekse `grow` değerini `True` olarak ayarlayın.

Tek tip şeffaflık için [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) kullanın. Bu, mevcut tüm alfa değerlerini çarpar; bu sayede kısmen şeffaf pikseller göreceli olarak farklı kalır. [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) ise tüm piksellere tek bir alfa değeri atar. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) alfa değerini bir eşik temelinde iki seviyeye dönüştürür.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

Diğer parametresiz alfa işlemleri şunları içerir: [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), sıfır olmayan tüm alfa değerlerini tamamen opak yapar; [add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), %100’ün altındaki tüm alfabı tamamen şeffaf yapar; ve [add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), alfabı `100% - alpha` şeklinde tersine çevirir.

## **Sıralı Bir Efekt Zinciri Oluştur**

Her `add_..._effect` metodu yeni bir işlemi koleksiyonun sonuna ekler. Renderlayıcı koleksiyonu sıralı bir boru hattı olarak kullanır: işlem 0’ın çıktısı işlem 1’in girdisi olur, vb. Sonuç olarak aynı işlemler farklı bir sırada verildiğinde farklı bir görüntü elde edilir.

Örneğin, önce gri tonlama ardından renk tonu eklemek önce renk bilgisini kaldırır, ardından luminans sonucunu yeniden renklendirir. Renk tonu ardından gri tonlama ise renk tonunu tekrar kaldırır. Benzer şekilde, alfa değiştirme daha erken işlemler tarafından hesaplanan alfa değerlerini geçersiz kılabilir, alfa modülasyonu ise göreceli farklılıkları korur.

Aşağıdaki örnek dört işlemden oluşan bir zincir oluşturur, PPTX olarak kaydeder, sunumu yeniden açar, hem işlem türlerini hem de sıralarını kontrol eder ve yeniden açılan sonucu render eder:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

Koleksiyon, renk, alfa ve bulanık işlemleri ayrı zincirlere sınırlayan bir uyumluluk matrisi dayatmaz. İşlemler birleştirilebilir, ancak birleşimler her zaman yararlı olmayabilir. Sabit bir renk değişimi önceki renk efektleri tarafından üretilen RGB varyasyonunu kaldırır; duoton sonrası gri tonlama iki seçilmiş rengi kaldırır; alfa tavan, taban, değiştirme veya iki‑seviye işlemleri önceki alfa detaylarını yok edebilir. Zinciri, istenen piksel işleme sırasına göre oluşturun; öğelerini sırasız biçimleme bayrakları gibi düşünmeyin.

<!-- visual-explanation:image-transform-effects:start -->
[![Aynı görüntü önce gri tonlamadan sonra renk tonuna, ardından renk tonu önce gri tonlamaya geçer. İki son gri tonlama görüntüsü farklı tonlara sahiptir.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Bu görsel, Aspose.Slides for .NET 26.11 tarafından oluşturulmuş bir örnek olup, %25 oranında 220° renk tonu gri tonlama sonrası görüntüyü değiştirmez. Aynı renk tonu gri tonlamadan önce uygulanırsa farklı tonlar elde edilir.*
<!-- visual-explanation:image-transform-effects:end -->

## **Düzenlenebilir ve Etkili Değerleri İncele**

Düzenlenebilir bir işlem, `Picture.image_transform` içinde saklanan nesnedir. Etkiye bağlı olarak, yazılabilir üyeleri doğrudan ortaya çıkarabilir. Örneğin, [Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) `radius` ve `grow` özelliklerini, [AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) `amount` özelliğini ve [AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) `threshold` özelliğini yazılabilir olarak sunar. [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) gibi renk efektleri ise değiştirilebilir [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/) nesnelerini ortaya çıkarır.

Bazı işlemler, [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/) ve [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/) gibi, oluşturma skalerlerini yazılabilir özellikler olarak sunmaz. Bu ayarları değiştirmek için işlemi kaldırın ve gereken konumda yerine yeni bir işlem ekleyin.

`get_effective()` tarafından döndürülen etkili veri hesaplanmış ve yalnızca okunabilir durumdadır. Tema‑bağımlı renkleri çözmek ve renderlayıcının kullandığı normalleştirilmiş değerleri okumak için faydalıdır; ancak başka bir düzenleme yüzeyi değildir. Aşağıdaki örnek zinciri sayar ve ilgili API’nın sağladığı yerde etkili değerleri inceler:

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

Grayscale, alfa tavan ve alfa ters gibi parametresiz efektlerin hâlâ bir etkili‑veri nesnesi vardır, ancak yazdırılacak skaler ayarları yoktur. Bulunmaları ve koleksiyondaki konumları önemli bilgidir.

## **Görüntü Dönüşümlerini Kaldır veya Temizle**

Bir işlemi indeksle kaldırmak için [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) metodunu kullanın. Kaldırma sonrası indeksler kaydığı için önce hedefi arayın ve sayma bitiminde kaldırın. Tüm zinciri kaldırmak için `clear()` kullanın.

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

Dönüşümleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Yeniden kullanılan [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) kaynağını silmez, yeniden sıkıştırmaz veya başka bir şekilde değiştirmez.

## **Sunum Formatlarını ve Dışa Aktarım Hedeflerini Düşünün**

Görüntü dönüşümleri DrawingML’den türemiştir; bu yüzden PPTX, efekt zincirleri için tercih edilen düzenlenebilir formattır. PPTX ile bile, her işlem aynı taşınabilirliğe sahip değildir:

- Luminans, gri tonlama, duotone, renk tonu, HSL, bulanıklaştırma ve yaygın alfa işlemleri gibi standart DrawingML işlemleri PPTX tam dönüşünden sonra en yüksek hayatta kalma şansına sahiptir. Koruma bir gereklilikse, oluşturulan dosyayı her zaman yeniden açın ve koleksiyonu inceleyin.
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) standart DrawingML luminans işlemi yerine bir Office 2010 uzantısıdır. Bellek içi renderlamada kullanılabilir, ancak PPTX kaydedilip yeniden açıldıktan sonra düzenlenebilir bir `BrightnessContrast` işlemi olarak kalması garanti değildir. Kalıcı parlaklık ve kontrast ayarlamaları için [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) tercih edin.
- İkili PPT formatı tam DrawingML efekt modelinden önce gelmiştir. PPT’ye kaydetmek, desteklenmeyen işlemleri atabilir, zinciri desteklenen bir alt kümeye indirebilir veya görünümü yaklaşık olarak oluşturabilir. Karmaşık bir düzenlenebilir zincir için doğrulama formatı olarak PPT kullanmayın.
- PNG, JPEG, TIFF, PDF, SVG, HTML veya diğer görsel çıktılara renderlamak, desteklenen zinciri renderlanan görünüme uygular. Bu çıktılar düzenlenebilir bir `ImageTransformOperationCollection` içermez; raster formatları sonucu piksellere dönüştürür, belge ya da vektör dışa aktarımları kendi render temsillerini saklar.
- Efektler, bağlantılı bir görüntüyü kendi içinde bağımlı hâle getirmez. Bağlantılı bir resim renderlandığında, sunum yüklendiğinde bağlantılı kaynağın mevcut olması gerekir.

Farklı sunum tüketicileri kenar durumlarını farklı şekilde renderlayabilir, özellikle birkaç alfa veya renk‑kuantizasyon işlemi birleştirildiğinde. Kritik çıktılar için, üretimde kullanılan aynı Aspose.Slides sürümüyle hem düzenlenebilir tam dönüşümü hem de nihai dışa aktarma formatını test edin.

## **SSS**

**Görüntü dönüşüm efektleri gömülü görüntü verilerini değiştirir mi?**

Hayır. İşlemler, resim doldurma tarafından kullanılan `Picture` nesnesine aittir. Alttaki `PPImage` baytları değişmez.

**Aynı görüntüyü kullanan iki resim çerçevesi efektlerini paylaşacak mı?**

Hayır. Aynı `PPImage` kullanmak görüntü verisinin kopyalanmasını önler, ancak her resim çerçevesi genellikle ayrı bir `Picture` ve ayrı bir görüntü dönüşüm koleksiyonuna sahiptir.

**Renk, bulanıklaştırma ve alfa efektleri birleştirilebilir mi?**

Evet. Koleksiyon bunları tek bir sıralı zincirde kabul eder. Önceki işlemin çıktısına ne yaptığını göz önünde bulundurun; değiştirme ve eşik işlemleri önceki renk veya alfa detayını yok edebilir.

**Neden etkili değerler yalnızca okunabilir?**

Etkili veri, renderlama sırasında kullanılan hesaplanmış değerleri temsil eder; çözülmüş renkler dahil. Yazılabilir üyeleri olan işlemleri doğrudan düzenleyin; aksi takdirde işlemi kaldırın ve yeni oluşturma parametreleriyle yerine bir işlem ekleyin.

**Bir dönüşüm zincirini korumak için hangi formatı kullanmalıyım?**

PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Eski PPT tam DrawingML efekt modelini temsil edemez; render çıktıları yalnızca görünümü korur, düzenlenebilir dönüşüm işlemlerini içermez.