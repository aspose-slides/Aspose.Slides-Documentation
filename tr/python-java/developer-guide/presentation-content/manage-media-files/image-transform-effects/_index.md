---
title: Presentasyonlarda Python ile Görüntü Dönüşüm Efektlerini Yönetme
linktitle: Görüntü Dönüşüm Efektleri
type: docs
weight: 11
url: /tr/python-java/image-transform-effects/
keywords:
- görüntü dönüşümü
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
- efekt zinciri
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile resim çerçeveleri için görüntü dönüşüm etkilerini uygulayın, zincirleyin, inceleyin, kaldırın ve doğrulayın."
---
## **Genel Bakış**

Aspose.Slides, resim ayarlamalarını sıralı bir görüntü dönüşüm işlemleri koleksiyonu olarak temsil eder. Bir resim çerçevesi için, çerçevenin [Picture](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picture/) öğesiyle başlayın ve [Picture.getImageTransform](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picture/#getImageTransform) öğesine erişin. Döndürülen [ImageTransformOperationCollection](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/) size efekti ekleme, listeleme, inceleme, kaldırma ve temizleme imkanı verir; orijinal görüntü baytlarını yeniden yazmanız gerekmez.

Bu makale parlaklık ve kontrast, renk dönüşümleri, bulanıklık, şeffaflık, sıralı efekt zincirleri, etkili değerler, kaldırma ve PPTX tam döngü doğrulaması için tam bir iş akışı gösterir.

## **Etkilerin Sahipliğini ve Görüntü Yeniden Kullanımını Anlama**

Bir görüntü kaynağı ile bunu gösteren resim farklı nesnelerdir:

- [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) sunum tarafından sahip olunan kaynak görüntü verilerini depolar veya referans verir.
- [Picture](https://reference.aspose.com/slides/tr/python-java/aspose.slides/picture/) bir resim doldurmanın parçasıdır ve bir görüntü kaynağına başvururken görüntü dönüşüm koleksiyonunu saklar.
- [PictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframe/) ilgili resim doldurmayı, geometriyi, kırpma ayarlarını ve diğer çerçeve seviyesi biçimlendirmeyi yöneten slayt şeklidir.

Bu nedenle görüntü dönüşüm işlemleri [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) baytlarını değiştirmez. Aynı `PPImage` nesnesi birden fazla kez [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shapecollection/#addPictureFrame) metoduna geçirildiğinde, her yeni resim çerçevesi kendi `Picture` nesnesini ve kendi dönüşüm koleksiyonunu alır. Bir çerçeveye gri tonlama uygulanması diğer çerçeveleri etkilemez; tüm çerçeveler aynı gömülü görüntü kaynağını kullanıyor olsa da.

Aynı `Picture.getImageTransform` modeli şekil doldurması veya slayt arka planı gibi diğer resim doldurmaları tarafından da kullanılır. Aşağıdaki örnekler resim çerçevelerine odaklanır.

## **Geçerli Parametre Aralıkları ve Birimlerini Kullanma**

Gösterilen yöntemler aşağıdaki anlamsal aralıkları ve birimleri kullanır. Bir kütüphane sürümü hemen her hatalı değeri reddetmese bile bu aralıkları koruyun; hedef sunum formatı kaydetme sırasında veya PowerPoint dosyayı açtığında geçersiz verileri normalleştirebilir, atabilir veya reddedebilir.

| İşlem | Parametreler | Geçerli aralık ve birim |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` ile `100` arasında, yüzde; `0` bileşeni değiştirmez. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | Yok | Sayısal parametre yok. Alfa değişmez. |
| [addDuotoneEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Koyu ve açık pikseller için iki renk. `java.awt.Color` içinde RGB ve alfa kanalları `0` ile `255` arasındadır. |
| [addTintEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | Ton `0` dahil, `360` hariç derece cinsinden; miktar `-100` ile `100` arasında, yüzde. |
| [addHSLEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | Ton `0` dahil, `360` hariç derece cinsinden; doygunluk ve parlaklık `-100` ile `100` arasında, yüzde. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | Yerine konulan renk kanalları `0` ile `255` arasındadır. Mevcut alfa değerleri değişmez. |
| [addBlurEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Yarıçap negatif olamaz ve puan cinsindendir; `grow` bulanık içeriğin orijinal sınırların dışına çıkıp çıkmayacağını kontrol eden Boolean değerdir. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Negatif olmayan yüzde. Normal opaklık ölçeklemesi için `0` ile `100` kullanın: `0` tamamen şeffaf, `100` mevcut alfade değeri korur. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` ile `100` arasında, yüzde opaklık. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` ile `100` arasında, yüzde alfa eşiği. Bu değerin altındaki pikseller şeffaf, eşit veya üstündekiler opak olur. |

Sabit alfa modülasyonu için şeffaflık ve opaklık tamamlayıcıdır. Örneğin %35 şeffaflık, %65 alfa modülasyonu miktarına eşittir.

## **Parlaklık ve Kontrast Uygulama**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) bir [BrightnessContrast](https://reference.aspose.com/slides/tr/python-java/aspose.slides/brightnesscontrast/) işlemi döndürür. İşlem oluşturulurken skaler ayarları sağlanır. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/tr/python-java/aspose.slides/brightnesscontrast/#getEffective) hesaplanmış, salt okunur değerleri verir; bu değerler incelenebilir veya kaydedilebilir.

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

[BrightnessContrast](https://reference.aspose.com/slides/tr/python-java/aspose.slides/brightnesscontrast/) bir Office 2010 resim‑efekti uzantısıdır ve standart DrawingML parlaklık etkisine göre daha az taşınabilirdir. Parlaklık ve kontrastın PPTX tam döngüden sonra da düzenlenebilir kalması gerekiyorsa, [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) kullanın ve dosyayı yeniden açtıktan sonra sonucu doğrulayın. Format sınırlamaları bölümü bu ayrımı daha ayrıntılı olarak açıklar.

## **Renk Dönüşümleri Uygulama**

Renk efektleri aynı görüntü kaynağını kullanan farklı resim çerçevelerine bağımsız olarak uygulanabilir. Aşağıdaki örnek beş çerçeve oluşturur ve gri tonlama, duotone, tonlama, HSL ayarı ve renk değiştirme uygular.

[Duotone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/duotone/) iki bağımsız düzenlenebilir renk parametresi içerir: `color1` koyu pikselleri, `color2` ise açık pikselleri haritalar. Bu, ayarları tek bir skaler değerden daha karmaşık olan bir efekt örneği olarak yararlıdır.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) her pikselin rengini sabit bir renk ile değiştirir, alfa değerini korur. Bu, bir kaynak rengi başka bir renge eşleyen ve hem kaynak hem hedef renk formatlarını ortaya çıkaran [addColorChangeEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect) yönteminden farklıdır.

## **Bulanıklaştırma, Şeffaflık ve Alfa Efektleri Ekleme**

[addBlurEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) tüm renk kanallarını, alfa dahil, etkiler. Bulanıklaştırılmış kenar orijinal resim sınırlarını aşabilecekse `grow` değerini `True` yapın.

Tekdüzen şeffaflık için [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) kullanın. Bu, mevcut her alfa değerini çarpar; böylece kısmen şeffaf pikseller orantılı olarak farklı kalır. [addAlphaReplaceEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) ise tüm piksellere tek bir alfa değeri atar. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) ise alfa değerini bir eşik temelinde iki seviyeye dönüştürür.

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

Parametresiz diğer alfa işlemleri şunlardır: [addAlphaCeilingEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect) – sıfır olmayan her alfa değeri tamamen opak hâle gelir; [addAlphaFloorEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect) – %100’ün altındaki her alfa tamamen şeffaf hâle gelir; ve [addAlphaInverseEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect) – alfa değeri `100% - alpha` olarak değişir.

## **Sıralı Bir Etki Zinciri Oluşturma**

Her `add...Effect` yöntemi yeni bir işlemi koleksiyonun sonuna ekler. Renderlayıcı koleksiyonu sıralı bir işlem hattı olarak kullanır: işlem 0’ın çıktısı işlem 1’in girdisi olur, vb. Dolayısıyla aynı işlemler farklı bir sırada uygulandığında farklı bir görüntü elde edilebilir.

Örneğin, önce gri tonlama ardından tonlama uygularsanız önce kromatik bilgi kaldırılır, ardından parlaklık yeniden renklendirilir. Tonlamadan sonra gri tonlama uygulanırsa tonlama etkisi kaldırılır. Benzer şekilde, alfa değiştirme (replace) daha önceki işlemler tarafından hesaplanan alfa değerlerini geçersiz kılabilir, alfa modülasyonu ise göreceli farkları korur.

Aşağıdaki örnek dört işlemden oluşan bir zincir oluşturur, PPTX olarak kaydeder, sunumu yeniden açar, hem işlem tiplerini hem de sırasını kontrol eder ve yeniden açılan sonucu renderlar:

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

Koleksiyon, renk, alfa ve bulanıklaştırma işlemlerinin ayrı zincirlere sınırlı olduğu bir uyumluluk matrisi dayatmaz. Birlikte kullanılabilirler, fakat kombinasyonlar her zaman yararlı değildir. Sabit bir renk değiştirme, önceki renk efektleriyle üretilen RGB varyasyonunu kaldırır; duotone’dan sonra gri tonlama iki seçili rengi ortadan kaldırır; ve alfa tavan, taban, değiştirme veya çift seviyeli işlemler, önceden oluşturulan alfa detayını silebilir. Zinciri, istenen piksel işleme sırasına göre inşa edin; öğeleri sırasız biçim bayrakları olarak değerlendirmeyin.

## **Düzenlenebilir ve Etkili Değerleri İnceleme**

Düzenlenebilir bir işlem, `Picture.getImageTransform` içinde saklanan nesnedir. Etkiye bağlı olarak, yazılabilir üyeleri doğrudan ortaya çıkarabilir. Örneğin, [Blur](https://reference.aspose.com/slides/tr/python-java/aspose.slides/blur/) `radius` ve `grow` değerlerini, [AlphaModulateFixed](https://reference.aspose.com/slides/tr/python-java/aspose.slides/alphamodulatefixed/) `amount` değerini, [AlphaBiLevel](https://reference.aspose.com/slides/tr/python-java/aspose.slides/alphabilevel/) `threshold` değerini yazılabilir olarak sunar. [Duotone](https://reference.aspose.com/slides/tr/python-java/aspose.slides/duotone/) gibi renk efektleri ise değiştirilebilir [ColorFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/colorformat/) nesneleri sağlar.

[BrightnessContrast](https://reference.aspose.com/slides/tr/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/tr/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/tr/python-java/aspose.slides/tint/) ve [AlphaReplace](https://reference.aspose.com/slides/tr/python-java/aspose.slides/alphareplace/) gibi bazı işlem sınıfları, yaratma skalerlerini yazılabilir özellik olarak ortaya koymaz. Bu ayarları değiştirmek için işlemi kaldırıp istenen konuma yeni bir tane eklemek gerekir.

`getEffective` tarafından döndürülen etkili veri hesaplanmış ve salt okunurdur. Tema‑bağımlı renklerin çözülmesi ve renderlayıcının kullandığı normalleştirilmiş değerlerin okunması için faydalıdır, ancak başka bir düzenleme yüzeyi değildir. Aşağıdaki örnek zinciri listeleyerek, ilgili API’nin sağladığı yerde etkili değerleri inceler:

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

Grayscale, alfa tavan ve alfa tersine çevirme gibi parametresiz efektlerin hâlâ bir etkili‑veri nesnesi vardır, ancak yazdırılacak skaler ayarları yoktur. Koleksiyondaki varlıkları ve konumları önemli bilgidir.

## **Görüntü Dönüşümlerini Kaldırma veya Temizleme**

Bir işlemi indeksle kaldırmak için [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) kullanın. Kaldırma sonrası indeksler kayar, bu yüzden önce hedefi bulun ve listeleme sonrasında kaldırın. Tüm zinciri kaldırmak için [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#clear) kullanın.

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

Dönüşümleri kaldırmak veya temizlemek yalnızca resim biçimlendirmesini değiştirir. Yeniden kullanılan [PPImage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/ppimage/) kaynağını silmez, yeniden sıkıştırmaz veya başka bir şekilde değiştirmez.

## **Sunum Formatlarını ve Dışa Aktarım Hedeflerini Düşünme**

Görüntü dönüşümleri DrawingML içinde ortaya çıkar, bu yüzden PPTX efekt zincirleri için tercih edilen düzenlenebilir formattır. PPTX’de bile her işlem aynı taşınabilirliğe sahip değildir:

- Luminance, grayscale, duotone, tint, HSL, blur ve yaygın alfa işlemleri gibi standart DrawingML işlemleri PPTX tam döngüsünde hayatta kalma olasılığı en yüksek olanlardır. Kalıcı olma gereksinimi varsa oluşturulan dosyayı her zaman yeniden açın ve koleksiyonu inceleyin.
- [BrightnessContrast](https://reference.aspose.com/slides/tr/python-java/aspose.slides/brightnesscontrast/) bir Office 2010 uzantısıdır, standart DrawingML luminance işlemine göre daha az taşınabilir. Bellek içi renderlama için kullanılabilir, fakat PPTX kaydedilip yeniden açıldıktan sonra düzenlenebilir bir [BrightnessContrast] olarak kalması garanti değildir. Kalıcı parlaklık ve kontrast ayarları için [addLuminanceEffect](https://reference.aspose.com/slides/tr/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) tercih edin.
- Eski PPT formatı tam DrawingML efekt modelinden önce gelmiştir. PPT’ye kaydetmek desteklenmeyen işlemleri atabilir, zinciri desteklenen bir alt küme ile sınırlayabilir veya görünümü yaklaşık olarak oluşturabilir. Karmaşık düzenlenebilir zincirler için PPT’yi doğrulama formatı olarak kullanmayın.
- PNG, JPEG, TIFF, PDF, SVG, HTML gibi görsel çıktılar desteklenen zinciri render eder, ancak bu çıktılar düzenlenebilir bir `ImageTransformOperationCollection` içermez; raster formatları sonucu piksellere dönüştürür, belge/vektör dışa aktarımları ise kendi render temsillerini saklar.
- Efektler bir bağlanan resmi kendi içinde kapsülleyemez. Bağlanan bir resmi renderlamak, sunum yüklendiğinde bağlanan kaynağın erişilebilir olmasına bağlıdır.

Farklı sunum tüketicileri kenar durumlarını farklı şekilde işleyebilir, özellikle birden fazla alfa veya renk‑kuantizasyon işlemi bir arada kullanıldığında. Kritik çıktılar için hem düzenlenebilir tam döngüyü hem de nihai dışa aktarım formatını üretimde kullanılan aynı Aspose.Slides sürümüyle test edin.

## **SSS**

**Görüntü dönüşüm efektleri gömülü görüntü verilerini değiştirir mi?**

Hayır. İşlemler, resim doldurması tarafından kullanılan `Picture` nesnesine aittir. Alttaki `PPImage` baytları değişmeden kalır.

**Aynı görüntüyü yeniden kullanan iki resim çerçevesi efektleri paylaşır mı?**

Hayır. `PPImage` yeniden kullanımı görsel veri tekrarını önler, fakat her resim çerçevesi genellikle ayrı bir `Picture` ve ayrı bir görüntü dönüşüm koleksiyonu içerir.

**Renk, bulanıklaştırma ve alfa efektleri birleştirilebilir mi?**

Evet. Koleksiyon, bunları tek bir sıralı zincirde kabul eder. Bir işlemin önceki çıktısını nasıl etkilediğini göz önünde bulundurun; değiştirme ve eşik işlemleri önceki renk veya alfa detayını silebilir.

**Etkili değerler neden salt okunur?**

Etkili veri, renderlama için kullanılan hesaplanmış değerleri (çözülmüş renkler dahil) temsil eder. Yazılabilir üyeleri olan dönüşüm koleksiyonundaki işlemi düzenleyin; aksi takdirde işlemi kaldırıp yeni yaratma parametreleriyle bir yenisini ekleyin.

**Bir dönüşüm zincirini korumak için hangi format kullanılmalı?**

PPTX kullanın ve dosyayı yeniden açarak doğrulayın. Eski PPT tam DrawingML efekt modelini temsil edemez; render çıktısı formatları ise yalnızca görünümü korur, düzenlenebilir dönüşüm işlemlerini içermez.