---
title: Python Kullanarak Sunumlarda 3D Efektler Oluşturma
linktitle: 3D Sunum
type: docs
weight: 232
url: /tr/python-net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D sunum
- 3D döndürme
- 3D derinlik
- 3D ekstrüzyon
- 3D degrade
- 3D metin
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python’da PowerPoint şekilleri ve metni için 3D efektler uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, doldurmalar ve 3D metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, şekiller ve metinler için PowerPoint tarzı 3D biçimlendirmeyi oluşturabilir, düzenleyebilir, koruyabilir ve renderlayabilir. Bu makale döndürme, ekstrüzyon, köşe yuvarlamaları, aydınlatma, malzeme, degrade veya resim doldurmaları ve 3D metin gibi 3D etkileri kapsar.

{{% alert color="info" title="Note" %}}
Bu makale, PowerPoint şekilleri ve metni üzerindeki 3D biçimlendirme efektleriyle ilgilidir. Bağımsız 3D model dosyalarının eklenmesi veya düzenlenmesiyle ilgili değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3D efektleri dışa aktarılan 2D çıktı içinde renderlar.
{{% /alert %}}

## **3D Biçimlendirme Kavramları**

Bir şekle 3D biçimlendirme uygulamak için [Shape.three_d_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/three_d_format/) özelliğini kullanın. Bu özellik, o şekil için 3D sahneyi kontrol eden [ThreeDFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/) nesnesini ortaya çıkarır.

Metin için, [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/three_d_format/) özelliğini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3D biçimlendirme uygular.

En önemli özellikler şunlardır:

| Özellik | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [camera](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/camera/) | Görüş noktası, önceden ayarlanmış kamera tipi, döndürme, yakınlaştırma ve perspektif. | Objeyi 3D uzayda döndürün veya bir PowerPoint 3D döndürme ön ayarıyla eşleştirin. |
| [light_rig](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/light_rig/) | Işık ön ayarı, yön ve ışık döndürmesi. | 3D yüzeydeki vurguların ve gölgelerin nasıl göründüğünü değiştirin. |
| [material](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/material/) | Yüzey malzemesi, örneğin düz, mat, plastik veya metal. | Aynı geometrinin daha düz, daha yumuşak, parlak veya metalik görünmesini sağlayın. |
| [extrusion_height](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/extrusion_height/) | Şeklin ön yüzünden geriye ne kadar uzadığı. | Düz bir şekli görünür kalın bir 3D nesneye dönüştürün. |
| [extrusion_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/extrusion_color/) | Ekstrüde edilmiş yan yüzlerin rengi. | Derinliği görünür kılın veya yan renklerini ön doldurma ile koordine edin. |
| [depth](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/depth/) | PowerPoint 3D biçimlendirmesi tarafından kullanılan ek 3D derinlik. | Şekiller veya metinler için derinliği ince ayarlayın, özellikle köşe yuvarlaması ve malzeme ayarlarıyla birlikte. |
| [bevel_top](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/bevel_top/) ve [bevel_bottom](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/bevel_bottom/) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüzey yerine yumuşak veya kalıplanmış bir kenar ekleyin. |
| [contour_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/contour_color/) ve [contour_width](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/contour_width/) | 3D nesnenin etrafındaki kontur. | Renderlanan çıktıda nesne sınırını vurgulayın. |

## **3D Şekil Oluşturma**

Bir şekil genellikle ikna edici bir 3D görünüm elde etmeden önce dört tür ayara ihtiyaç duyar:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeylerin ve yanların okunabilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl yansıtıldığını etkiler.
- Ekstrüzyon ya da derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler ve 3D biçimlendirme uygular. Kamera döndürme değerleri derece cinsindendir ve ekstrüzyon yüksekliği 100 puandır. Örnek, slaytı iki katı varsayılan boyutta PNG görüntüsü olarak renderlar ve sunumu PPTX olarak kaydeder.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.text_frame.text = "3D"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.blue

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("shape_3d.png")

    presentation.save("shape_3d.pptx", slides.export.SaveFormat.PPTX)
```

Renderlanan slayt görüntüsü dikdörtgeni kalın bir 3D blok olarak gösterir:

![Ön yüzünde beyaz 3D metinli mavi 3D dikdörtgen](img_01_01.png)

## **Kamerayla Bir Şekli Döndürme**

PowerPoint'te 3D döndürme, 3‑D Rotation bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si üzerinden ayarladığınız döndürmeye karşılık gelir.

![X, Y ve Z döndürme değerlerinin vurgulandığı PowerPoint 3‑D Döndürme bölmesi](img_02_01.png)

Aspose.Slides'te kameraya [ThreeDFormat.camera](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/camera/) üzerinden erişilir. Bu örnek bir dikdörtgen oluşturur, ortografik ön görünüm seçer ve X, Y, Z döndürmelerini sırasıyla 20, 30 ve 40 derece olarak ayarlar. Şekli dosya kaydetmeden bellekte yapılandırır:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Görüntüleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kamerayı kullanın. Bu, slayttaki 2D şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides render ederken kullanılan 3D bakış açısını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şekli ön yüzünden geriye uzatarak kalın görünmesini sağlar. PowerPoint'te derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![Ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenen PowerPoint derinlik kontrolleri](img_02_02.png)

Kalınlık için [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/extrusion_height/), yan renk için ise [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/extrusion_color/) ayarlayın. Bu örnek, dikdörtgene 100 puanluk bir ekstrüzyon ve mor yanlar verir, kalınlığını göstermek için kamerayı döndürür. Şekli dosya kaydetmeden bellekte yapılandırır:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 100
    shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

[ThreeDFormat.depth](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/depth/) özelliği bir 3D şeklin derinliğini ayarlar. [extrusion_height](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/extrusion_height/) özelliği ekstrüzyon etkisinin yüksekliğini kontrol eder; bu örnekte gösterildiği gibi.

## **3D Efektlerle Degrade veya Resim Doldurmaları Kullanma**

3D biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüzeye katı renk, degrade, desen veya resim doldurması uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını kullanabilirsiniz.

Bu örnek, ön yüze mavi‑turuncu bir degrade ve 150 puanlık ekstrüzyona koyu turuncu bir renk uygular. Degrade durakları 0 ve 100, degrade başlangıç ve bitişini belirler. Kamera döndürme değerleri derece cinsindendir. Slayt iki katı varsayılan boyutta PNG olarak renderlanır:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    shape.text_frame.text = "3D Gradient"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 64

    shape.fill_format.fill_type = slides.FillType.GRADIENT
    shape.fill_format.gradient_format.gradient_stops.add(0, drawing.Color.blue)
    shape.fill_format.gradient_format.gradient_stops.add(100, drawing.Color.orange)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("gradient_3d.png")
```

Renderlanan çıktı, ön yüze degrade uygular ve ekstrüzyonu ayrı olarak renderlar:

![Mavi‑turuncu degrade doldurma ve turuncu ekstrüzyonlu renderlanmış 3D dikdörtgen](img_02_03.png)

Resim doldurması kullanmak için, resmi sunuma ekleyin ve şekil doldurmasına atayın. Bu örnek, çalışma dizininde "image.jpg" adlı bir dosyanın var olduğunu varsayar. Resmi dikdörtgene yayar, 150 puanlık ekstrüzyon uygular ve kamera döndürmesini derece olarak ayarlar. Şekli dosya kaydetmeden veya renderlamadan bellekte yapılandırır:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)

    image = presentation.images.add_image(image_data)

    shape.fill_format.fill_type = slides.FillType.PICTURE
    shape.fill_format.picture_fill_format.picture.image = image
    shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(10, 20, 30)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 150
    shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

Resim ön yüzde renderlanırken, ekstrüzyon 3D yan yüz olarak renderlanır:

![Ön yüzünde fotoğraf doldurma ve turuncu ekstrüzyonlu renderlanmış 3D dikdörtgen](img_02_04.png)

## **Metne 3D Biçimlendirme Uygulama**

Şekil 3D biçimlendirmesi şekil gövdesini etkiler. Metin 3D biçimlendirmesi ise metin çerçevesini etkiler. Harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için kullanışlıdır.

Aşağıdaki örnek, turuncu‑beyaz bir ızgara deseniyle metin oluşturur, yukarı doğru bir yay ekler ve 3D ayarları [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/three_d_format/) üzerinden yapılandırır. Ekstrüzyon yüksekliği ve derinlik puan cinsindendir, ışık döndürmesi derece cinsindendir. Şekil doldurma ve kontur gizlenir, böylece yalnızca metin görünür. Örnek, PNG görüntüsünü iki katı varsayılan slayt boyutunda renderlar ve sunumu PPTX olarak kaydeder:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

image_scale = 2

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 250, 250)
    
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.text = "3D Text"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = drawing.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = drawing.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.LARGE_GRID

    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 128

    text_frame_format = shape.text_frame.text_frame_format
    text_frame_format.transform = slides.TextShapeType.ARCH_UP
    text_frame_format.three_d_format.extrusion_height = 3.5
    text_frame_format.three_d_format.depth = 3
    text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC
    text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)
    text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING

    with slide.get_image(image_scale, image_scale) as thumbnail:
        thumbnail.save("text_3d.png")

    presentation.save("text_3d.pptx", slides.export.SaveFormat.PPTX)
```

Metin, eğimli, ekstrüde edilmiş 3D harfler olarak renderlanır:

![Eğik WordArt dönüşümü, turuncu desen doldurma ve koyu ekstrüzyonlu renderlanmış 3D metin](img_02_05.png)

## **3D Şekilde Metni Düz Tutma**

Bir şeklin 3D görünümünü korurken metni okunabilir tutmak için, [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/keep_text_flat/) özelliğini [TextFrame.text_frame_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/text_frame/text_frame_format/) üzerinden ayarlayın. Değer `True` olduğunda metin 3D sahneden çıkar. `False` olduğunda metin sahneye katılır ve 3D yönelimini izler.

Bu ayar, şeklin kamera, ışık, malzeme ve ekstrüzyon ayarlarıyla yapılandırılmış 3D biçimlendirmesini kaldırmaz; bu ayarlar hâlâ [Shape.three_d_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/three_d_format/) üzerinden yapılır. Ayrıca sıradan döndürmeden farklıdır. [Shape.rotation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/rotation/) şekli slayt düzleminde döndürürken, [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/rotation_angle/) metnin bağlam kutusu içindeki özel dönüşünü kontrol eder. Metni 3D sahneden çıkarmak bu açıları sıfırlamaz.

Aşağıdaki bağımsız örnek, metinli bir mavi dikdörtgen oluşturur ve orijinalin yanına bir kopyasını ekler. İki şekil aynı 3D biçimlendirmeye sahiptir; sadece metin ayarı farklıdır: solda `False`, sağda `True`. Kamera açıları derece cinsindedir, ekstrüzyon yüksekliği 40 puandır. Örnek sunumu PPTX olarak kaydeder ve karşılaştırma slaytını iki katı varsayılan boyutta PNG olarak renderlar.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 70, 160, 240, 140)

    shape.text_frame.text = "Readable text"
    shape.text_frame.paragraphs[0].paragraph_format.default_portion_format.font_height = 28
    shape.text_frame.paragraphs[0].paragraph_format.alignment = slides.TextAlignment.CENTER
    shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.CENTER
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = drawing.Color.cornflower_blue

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(30, 30, 0)
    shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.FLAT
    shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    shape.three_d_format.material = slides.MaterialPresetType.FLAT
    shape.three_d_format.extrusion_height = 40
    shape.three_d_format.extrusion_color.color = drawing.Color.royal_blue
    shape.text_frame.text_frame_format.keep_text_flat = False

    flat_text_shape = slide.shapes.add_clone(shape, 400, 160)
    flat_text_shape.text_frame.text_frame_format.keep_text_flat = True

    presentation.save("keep_text_flat.pptx", slides.export.SaveFormat.PPTX)
    with slide.get_image(2, 2) as image:
        image.save("keep_text_flat.png")
```

Solda, metin 3D yönelimi takip eder. Sağda ise düz kalır ve daha okunaklıdır. Her iki dikdörtgen de aynı görünür ekstrüzyon ve 3D yönelimine sahiptir.

![Yan yana 3D dikdörtgenler: keep_text_flat sol tarafta False, sağ tarafta True](keep_text_flat.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3D biçimlendirmeyi korur. Sabit‑sayfa formatlarına renderlarken veya dışa aktarırken, 3D sahne rasterleştirilir ve çıktı içinde 2D sonuç olarak çizilir. Bu, slaytları [PNG](/slides/tr/python-net/convert-powerpoint-to-png/), [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/tr/python-net/convert-powerpoint-to-html/) formatlarına renderladığınızda veya [video dönüşümü](/slides/tr/python-net/convert-powerpoint-to-video/) için kareler ürettiğinizde geçerlidir.

Şunları aklınızda bulundurun:

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne dışa aktarıldıktan sonra izleyici tarafından döndürülemez.
- Son görünüm, kamera, ışık rig'i, malzeme, ekstrüzyon, doldurma ve slayt ölçeklemesinin birleşimine bağlıdır.
- Kalıtılmış veya tema‑bazlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [etkin şekil özelliklerini](/slides/tr/python-net/shape-effective-properties/) okuyun.
- Bazı çıktı formatları düzenlenebilir PowerPoint 3D biçimlendirmesini depolayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3D ayarları olarak değil, renderlanmış bir görüntü olarak saklanır.

## **SSS**

**Aspose.Slides etkileşimli 3D sunumlar oluşturabilir mi?**

Aspose.Slides, şekiller ve metin için PowerPoint 3D efektlerini oluşturur ve renderlar. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfaları izleyicinin döndürebileceği etkileşimli 3D sahneler haline getirmez. PPTX içinde format destekliyorsa 3D biçimlendirme PowerPoint'te düzenlenebilir kalır.

**3D model ile 3D efekt arasındaki fark nedir?**

3D model, sunuma eklenen ayrı bir 3D nesnedir. 3D efekt, bir PowerPoint şekli veya metnine uygulanan döndürme, ekstrüzyon, köşe yuvarlaması, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3D efektleri ele alır.

**Görünür bir 3D şekil için hangi ayarlar gereklidir?**

En az bir kamera döndürmesi ve ekstrüzyon ya da derinlik ayarı gerekir. Pratikte, renderlanan yüzeylerin net vurgular ve gölgeler alması için bir ışık rig'i ve malzeme de ayarlanmalıdır.

**3D efektleri hem şekillere hem de metne uygulayabilir miyim?**

Evet. Şekil gövdesi için [Shape.three_d_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/three_d_format/), metin için ise [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/three_d_format/) kullanın.

**3D efektler görüntülere, PDF, HTML veya video karelerine dışa aktarılırken görünür mü?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler üretilirken 3D efektleri renderlar. Dışa aktarılan çıktı renderlanmış görünümü içerir, düzenlenebilir bir 3D nesne değil.

**Kalıtım ve tema ayarları uygulandıktan sonra nihai 3D değerlerini okuyabilir miyim?**

Evet. Nihai kamera, ışık rig'i, köşe yuvarlaması ve ilgili 3D değerlerini okumak için [Şekil Etkin Özellikleri](/slides/tr/python-net/shape-effective-properties/) API'lerini kullanın.