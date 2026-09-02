---
title: Python ile Sunumlarda Görüntü Dönüştürme Efektlerini Yönetme
linktitle: Görüntü Dönüştürme Efektleri
type: docs
weight: 11
url: /tr/python-net/image-transform-effects/
keywords:
- görüntü dönüştürme
- resim efekti
- parlaklık
- kontrast
- gri tonlama
- çift ton
- renk tonu
- HSL
- renk değiştirme
- bulanıklaştırma
- şeffaflık
- alfa efekti
- etki zinciri
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile resim çerçeveleri için görüntü dönüştürme efektlerini uygulayın, zincirleyin, inceleyin, kaldırın ve doğrulayın."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlarını sıralı bir görüntü dönüştürme işlemleri koleksiyonu olarak temsil eder. Bir resim çerçevesi için, çerçevenin [Resim](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picture/) ile başlayın ve onun [image_transform](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picture/image_transform/) özelliğine erişin. Döndürülen [ImageTransformOperationCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/) yeni etkiler eklemenizi, saymanı, incelemenizi, kaldırmanızı ve temizlemenizi, orijinal görüntü baytlarını yeniden yazmadan sağlar.

Bu makale, parlaklık ve kontrast, renk dönüşümleri, bulanıklaştırma, şeffaflık, sıralı etki zincirleri, etkili değerler, kaldırma ve PPTX turu doğrulaması için eksiksiz bir iş akışını gösterir.

## **Etki Sahipliğini ve Görüntü Yeniden Kullanımını Anlamak**

Bir görüntü kaynağı ile onu görüntüleyen resim farklı nesnelerdir:

- [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) sunumun sahip olduğu kaynak görüntü verilerini depolar veya başvurur.
- [Picture](https://reference.aspose.com/slides/tr/python-net/aspose.slides/picture/) bir resim doldurmanın parçasıdır ve bir görüntü kaynağına başvururken görüntü dönüştürme koleksiyonunu saklar.
- [PictureFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframe/) ilgili resim doldurmayı, geometrileri, kırpma ayarlarını ve diğer çerçeve‑seviyesi biçimlendirmeyi sahip olan slayt şeklidir.

Bu yüzden, görüntü dönüştürme işlemleri [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) içerisindeki baytları değiştirmez. Aynı `PPImage` birden fazla kez [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_picture_frame/) metoduna verildiğinde, her yeni resim çerçevesi kendi `Picture` ve dönüştürme koleksiyonuna sahip olur. Bir çerçeveye gri tonlamayı uygulamak, diğer çerçeveleri gri tonlamaz; tüm çerçeveler aynı gömülü görüntü kaynağını yinelemeye devam eder.

Aynı `Picture.image_transform` modeli, şekil ya da slayt arka planı gibi diğer resim doldurmaları tarafından da kullanılır. Aşağıdaki örnekler yalnızca resim çerçevelerine odaklanır.

## **Geçerli Parametre Aralıklarını ve Birimleri Kullanma**

Gösterilen yöntemler aşağıdaki anlamsal aralıkları ve birimleri kullanır. Belirli bir kütüphane sürümü hemen her sınır dışı değeri reddetmese bile, hedef sunum biçimi kaydetme sırasında ya da PowerPoint dosyayı açtığında geçersiz verileri normalleştirebilir, atabilir veya reddedebilir.

| İşlem | Parametreler | Geçerli aralık ve birim |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değiştirmez. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | Yok | Sayısal parametre yok. Alfa değişmez. |
| [add_duotone_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Koyu ve açık pikseller için iki renk. RGB ve alfa kanalları `0` ile `255` arasında değer alır. |
| [add_tint_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Renk tonu `0` dahil `360` hariç derece; miktar `-100` ile `100` arasında yüzde. |
| [add_hsl_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Renk tonu `0` dahil `360` hariç derece; doygunluk ve parlaklık `-100` ile `100` arasında yüzde. |
| [add_color_replace_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | Yerine konulan renk kanal değerlerini `0` ile `255` arasında kullanır. Mevcut alfa değerleri değişmez. |
| [add_blur_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | Yarıçap negatif olmayan ve puan cinsinden ölçülür; `grow` bulanık içeriğin orijinal sınırların dışına çıkıp çıkmayacağını belirleyen Boolean bir değerdir. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeklemesi için `0` ile `100` kullanın: `0` tamamen transparan, `100` mevcut alfabayı korur. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` ile `100` arasında, yüzde opaklık. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` ile `100` arasında, yüzde alfa eşiği. Bu değerin altındaki değerler transparan, eşit veya üzerindekiler opak olur. |

Sabit alfa modülasyonu için şeffaflık ve opaklık tamamlayıcıdır. Örneğin, %35 şeffaflık alfa modülasyonu miktarı %65’e eşittir.

## **Parlaklık ve Kontrast Uygulama**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) bir [BrightnessContrast](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/brightnesscontrast/) işlemi döndürür. Skaler ayarlar işlem oluşturulurken sağlanır. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) hesaplanmış, yalnızca okunabilen değerleri verir; bu değerler incelenebilir veya kaydedilebilir.

Aşağıdaki örnek parlaklığı %15, kontrastı %20 artırır ve gömülü görüntüyü değiştirmeden bir önizleme oluşturur:

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

[BrightnessContrast](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/brightnesscontrast/) bir Office 2010 resim‑etki uzantısıdır ve standart DrawingML parlaklık etkisine göre daha az taşınabilir. Parlaklık ve kontrastın PPTX turu sonrası düzenlenebilir kalması gerekiyorsa, [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) kullanın ve dosyayı yeniden açtıktan sonra sonucu doğrulayın. Biçim sınırlamaları bölümü bu ayrımı daha ayrıntılı açıklar.

## **Renk Dönüşümlerini Uygulama**

Renk etkileri, aynı görüntü kaynağını kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve gri tonlama, duotone, tonlama, HSL ayarı ve renk değişimini uygular.

[Duotone](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/duotone/) iki bağımsız düzenlenebilir renk parametresi içerir: `color1` koyu pikselleri, `color2` açık pikselleri eşler. Bu, ayarları tek bir skaler değerden daha karmaşık bir etki örneği olduğu için faydalı bir örnektir.

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

[add_color_replace_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) her pikselin rengini sabit bir renkle değiştirirken alfabayı korur. Bu, bir kaynak rengi başka bir renge eşleyen ve hem kaynak hem hedef renk biçimlerini ortaya çıkaran [add_color_change_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/) yönteminden farklıdır.

## **Bulanıklaştırma, Şeffaflık ve Alfa Etkileri Ekleme**

[add_blur_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) tüm renk kanallarını, alfabı da dahil, etkiler. Bulanık kenarın orijinal resim sınırlarının dışına çıkabileceği durumlarda `grow` parametresini `True` yapın.

Tekdüze şeffaflık için [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) kullanın. Bu yöntem mevcut alfa değerlerini çarparak, yarı saydam piksellerin orantılı olarak farklı kalmasını sağlar. [add_alpha_replace_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) ise tüm piksellere tek bir alfa değeri atar. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) ise bir eşik temelinde alfabı iki seviyeye dönüştürür.

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

Diğer parametresiz alfa işlemleri şunlardır: [add_alpha_ceiling_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/) – sıfır olmayan tüm alfaları tamamen opak yapar; [add_alpha_floor_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/) – %100 altındaki tüm alfaları tamamen transparan yapar; ve [add_alpha_inverse_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/) – alfabı `100% - alpha` olarak değiştirir.

## **Sıralı Bir Etki Zinciri Oluşturma**

Her `add_..._effect` yöntemi yeni bir işlemi koleksiyonun sonuna ekler. İşleyici koleksiyonu sıralı bir boru hattı olarak kullanır: işlem 0’ın çıktısı işlem 1’in girdisi olur ve böyle devam eder. Bu nedenle aynı işlemler farklı bir sırada uygulanırsa farklı bir görüntü elde edilebilir.

Örneğin, önce gri tonlama ardından tonlama, önce renk bilgisini siler, ardından parlaklık sonucunu yeniden renklendirir. Tonlamadan sonra gri tonlama tekrar tonu kaldırır. Benzer şekilde, alfa değiştirme, önceki işlemler tarafından hesaplanan alfa değerlerini geçersiz kılabilir; alfa modülasyonu ise göreceli farkları korur.

Aşağıdaki örnek dört işlemlik bir zincir oluşturur, PPTX olarak kaydeder, sunumu yeniden açar, hem işlem türlerini hem de sıralarını kontrol eder ve yeniden açılan sonucu işler:

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

Koleksiyon, renk, alfa ve bulanıklaştırma işlemlerini ayrı zincirlere sınırlayan bir uyumluluk matrisi zorunluluğu getirmez. Kombine edilebilirler, ancak kombinasyonlar her zaman faydalı olmayabilir. Sabit bir renk değiştirme, önceki renk etkileriyle oluşan RGB varyasyonunu kaldırır; duotone’dan sonra gri tonlama iki seçili rengi ortadan kaldırır; alfa tavan, taban, değiştirme veya iki‑seviyeli işlemler ise daha önce oluşturulan alfa detayını yok edebilir. Zinciri, istenen piksel‑işleme sırasına göre oluşturun; öğeleri sırasız biçimlendirme bayrakları gibi değerlendirmeyin.

## **Düzenlenebilir ve Etkili Değerleri İnceleme**

Düzenlenebilir bir işlem, `Picture.image_transform` içinde depolanan nesnedir. Etkiye bağlı olarak, yazılabilir üyeler doğrudan erişilebilir olabilir. Örneğin, [Blur](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/blur/) `radius` ve `grow` özelliklerini, [AlphaModulateFixed](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/alphamodulatefixed/) `amount` özelliğini, [AlphaBiLevel](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/alphabilevel/) `threshold` özelliğini sunar. [Duotone](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/duotone/) gibi renk etkileri değiştirilebilir [ColorFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/colorformat/) nesnelerini ortaya çıkarır.

[BrightnessContrast](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/tint/) ve [AlphaReplace](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/alphareplace/) gibi bazı işlemler, oluşturma skalerlerini yazılabilir özellikler olarak sunmaz. Bu ayarları değiştirmek için işlemi kaldırıp istenen konumda yeni bir işlem ekleyin.

`get_effective()` tarafından döndürülen etkili veri hesaplanmış ve yalnızca okunabilir bir nesnedir. Tema‑bağımlı renklerin çözülmesi ve işleyicinin kullandığı normalleştirilmiş değerlerin okunması için faydalıdır; ancak başka bir düzenleme yüzeyi değildir. Aşağıdaki örnek zinciri sayar ve ilgili API sağlıyorsa etkili değerleri inceler:

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

Parametresiz etkiler (gri tonlama, alfa tavan, alfa tersine) da bir etkili veri nesnesine sahiptir, ancak yazdırılacak skaler ayarları yoktur. Koleksiyondaki varlıkları ve konumları önemli bilgidir.

## **Görüntü Dönüştürmelerini Kaldırma veya Temizleme**

Bir işlemi indeksle kaldırmak için [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) kullanın. Kaldırma sonrası indeksler kaydığı için önce hedefi bulun, ardından sayma işlemi sonrasında kaldırın. Tüm zinciri silmek için `clear()` kullanın.

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

Dönüştürmeleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Yeniden kullanılan [PPImage](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ppimage/) kaynağını silmez, yeniden sıkıştırmaz veya başka bir şekilde etkilemez.

## **Sunum Biçimlerini ve Dışa Aktarım Hedeflerini Düşünme**

Görüntü dönüştürmeleri DrawingML’den gelir, bu yüzden PPTX, etki zincirleri için tercih edilen düzenlenebilir formattır. PPTX içinde bile her işlem aynı taşınabilirliğe sahip değildir:

- Luminance, grayscale, duotone, tint, HSL, blur ve yaygın alfa işlemleri gibi standart DrawingML işlemleri PPTX turu sonrası hayatta kalma ihtimali en yüksek olanlardır. Kalıcılık bir gereksinimse, oluşturulan dosyayı her zaman yeniden açın ve koleksiyonu inceleyin.
- [BrightnessContrast](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/brightnesscontrast/) bir Office 2010 uzantısıdır; standart DrawingML luminance etkisi değildir. Bellek içi işleme için kullanılabilir, ancak PPTX kaydedilip yeniden açıldıktan sonra düzenlenebilir bir `BrightnessContrast` işlemi olarak kalması garanti edilmez. Kalıcı parlaklık ve kontrast ayarları için [add_luminance_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) tercih edin.
- İkili PPT formatı, tam DrawingML etki modelinden önce ortaya çıkmıştır. PPT’ye kaydetmek, desteklenmeyen işlemleri atabilir, zinciri desteklenen bir alt kümeye indirebilir veya görünümü yaklaştırabilir. Karmaşık, düzenlenebilir bir zincir için PPT’yi doğrulama formatı olarak kullanmayın.
- PNG, JPEG, TIFF, PDF, SVG, HTML gibi görsel çıktılar, zinciri işlenmiş görünüm üzerine uygular. Bu çıktılar düzenlenebilir bir `ImageTransformOperationCollection` içermez; raster formatlar sonucu piksellere dönüştürür, belge ya da vektör dışa aktarımları ise kendi işleme temsillerini saklar.
- Etkiler, bağlanmış bir görüntüyü kendi içinde barındırılabilir hâle getirmez. Bağlantılı bir resmi işlemek, sunum yüklendiğinde bağlanmış kaynağın erişilebilir olmasına bağlıdır.

Farklı sunum tüketicileri, özellikle birkaç alfa veya renk‑kuantizasyon işlemi bir araya geldiğinde, kenar durumlarını farklı yorumlayabilir. Kritik çıktı için, üretimde kullanılan aynı Aspose.Slides sürümüyle düzenlenebilir turu ve nihai dışa aktarma formatını test edin.

## **SSS**

**Görüntü dönüştürme etkileri gömülü görüntü verilerini değiştirir mi?**

Hayır. İşlemler, resim doldurmanın kullandığı `Picture` nesnesine aittir. Alttaki `PPImage` baytları değişmez.

**Aynı görüntüyü kullanan iki resim çerçevesi etkilerini paylaşır mı?**

Hayır. `PPImage` yeniden kullanmak veri çoğaltmayı önler, ancak her resim çerçevesi genellikle ayrı bir `Picture` ve kendi görüntü dönüştürme koleksiyonuna sahiptir.

**Renk, bulanıklaştırma ve alfa etkileri birleştirilebilir mi?**

Evet. Koleksiyon, tek bir sıralı zincirde bunları kabul eder. Her bir işlemin önceki çıktıyı nasıl etkilediğini göz önünde bulundurun; değiştirme ve eşik işlemleri önceki renk ya da alfa detayını yok edebilir.

**Etkili değerler neden yalnızca okunabilir?**

Etkili veri, renderlama için kullanılan, hesaplanmış değerleri temsil eder; çözülmüş renkler dahildir. Yazılabilir üyeleri olan işlemleri doğrudan düzenleyin; aksi takdirde işlemi kaldırıp yeni oluşturma parametreleriyle bir yenisini ekleyin.

**Bir dönüştürme zincirini korumak için hangi formatı kullanmalıyım?**

PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Eski PPT, tam DrawingML etki modelini temsil edemez; renderlanan dışa aktarma formatları ise yalnızca görünümü korur, düzenlenebilir dönüştürme işlemlerini içermez.