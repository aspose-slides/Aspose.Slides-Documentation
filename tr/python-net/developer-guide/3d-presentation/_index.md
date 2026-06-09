---
title: Python Kullanarak Sunumlarda 3B Efektler Oluşturma
linktitle: 3B Sunum
type: docs
weight: 232
url: /tr/python-net/3d-presentation/
keywords:
- 3B PowerPoint
- 3B sunum
- 3B döndürme
- 3B derinlik
- 3B ekstrüzyon
- 3B degrade
- 3B metin
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python'da PowerPoint şekilleri ve metni için 3B efektler uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, dolgu ve 3B metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, şekil ve metinler için PowerPoint tarzı 3B biçimlendirme oluşturabilir, düzenleyebilir, koruyabilir ve renderleyebilir. Bu makale, döndürme, ekstrüzyon, açılma kenarları, aydınlatma, malzeme, degrade veya resim dolgu ve 3B metin gibi 3B efektleri kapsar.

{{% alert color="primary" %}}
Bu makale, PowerPoint şekilleri ve metinleri üzerindeki 3B biçimlendirme efektleriyle ilgilidir. Ayrı 3B model dosyalarını ekleme veya düzenleme ile ilgili değildir. Bir slaytı görüntü, PDF veya HTML olarak dışa aktardığınızda, Aspose.Slides bu 3B efektleri dışa aktarılan 2B çıktıya renderlar.
{{% /alert %}}

## **3B Biçimlendirme Kavramları**

Bir şekle 3B biçimlendirme uygulamak için [Shape.three_d_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/three_d_format/) özelliğini kullanın. Bu özellik, şekil için 3B sahneyi kontrol eden [ThreeDFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/)’ı açığa çıkar.

Metin için ise [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/three_d_format/) özelliğini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3B biçimlendirme uygular.

En önemli özellikler şunlardır:

| Özellik | Ne kontrol eder | Ne zaman kullanılmalı |
|---|---|---|
| [camera](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/camera/) | Görüş noktası, ön ayarlı kamera türü, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3B uzayda döndürmek veya PowerPoint 3B döndürme ön ayarına uymak için. |
| [light_rig](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/light_rig/) | Işık ön ayarı, yönü ve ışık dönüşü. | 3B yüzeydeki vurguların ve gölgelerin nasıl göründüğünü değiştirmek için. |
| [material](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/material/) | Düz, mat, plastik veya metal gibi yüzey malzemesi. | Aynı geometrinin daha düz, daha yumuşak, parlak veya metalik görünmesini sağlamak için. |
| [extrusion_height](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/extrusion_height/) | Şeklin ön yüzünden geriye ne kadar uzandığını belirler. | Düz bir şekli görünür şekilde kalın bir 3B nesne haline getirmek için. |
| [extrusion_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/extrusion_color/) | Ekstrüde edilmiş yan yüzlerin rengi. | Derinliği görünür kılar veya yan renkleri ön dolgu ile eşleştirir. |
| [depth](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/depth/) | PowerPoint 3B biçimlendirmesi tarafından kullanılan ek 3B derinlik. | Şekiller veya metinler için derinliği, özellikle açılma kenarı ve malzeme ayarlarıyla birlikte hassas ayarlamak için. |
| [bevel_top](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/bevel_top/) ve [bevel_bottom](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/bevel_bottom/) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüz yerine yumuşak veya kalıplı bir kenar eklemek için. |
| [contour_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/contour_color/) ve [contour_width](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/contour_width/) | 3B nesnenin çevresindeki kontur. | Renderlenmiş çıktıda nesne sınırını vurgulamak için. |

## **3B Şekil Oluşturma**

Bir şekil genellikle ikna edici bir 3B görünüm kazanması için dört tür ayara ihtiyaç duyar:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeylerin ve yanların okunabilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl renderlendiğini etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler, 3B biçimlendirme uygular, sunumu PPTX olarak kaydeder ve slaytı PNG görüntüsü olarak renderlar.

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

Renderlanan slayt görüntüsü, dikdörtgeni kalın bir 3B blok olarak gösterir:

![Renderlanmış mavi 3B dikdörtgenin ön yüzünde beyaz 3B metin](img_01_01.png)

## **Kamerayı Kullanarak Şekli Döndürme**

PowerPoint’te 3B döndürme, 3‑D Rotation panelinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API’si üzerinden ayarladığınız döndürmeye karşılık gelir.

![PowerPoint 3‑D Rotation paneli, X, Y ve Z döndürme değerleri vurgulanmış](img_02_01.png)

Aspose.Slides’te kameranın türünü ve döndürmesini [ThreeDFormat.camera](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/camera/) aracılığıyla ayarlayın:

```py
shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Kamerayı, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanın. Bu, slayttaki 2D şekil geometrisini değiştirmez; PowerPoint ve Aspose.Slides’in renderleme sırasında kullandığı 3B bakış noktasını değiştirir.

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şekli ön yüzünden geriye uzatarak kalın gösterir. PowerPoint’te derinlik kontrolü bu görünür kalınlığı ayarlar, renk kontrolü ise yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrolleri ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiş](img_02_02.png)

Kalınlık için [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/extrusion_height/), yan renk için [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/extrusion_color/) ayarlayın:

```py
shape.three_d_format.camera.set_rotation(20, 30, 40)
shape.three_d_format.extrusion_height = 100
shape.three_d_format.extrusion_color.color = drawing.Color.purple
```

PowerPoint’in derinlik değerini doğrudan kullanmak veya derinliği açılma, malzeme ve metin efektleriyle birleştirmek istediğinizde [ThreeDFormat.depth](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/depth/) kullanın. Çoğu şekil senaryosunda, görünür ekstrüzyonu doğrudan ifade ettiği için [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/extrusion_height/) daha açıklayıcı bir ayardır.

## **3B Efektlerle Degrade veya Resim Dolguları Kullanma**

3B biçimlendirme, şekil dolgusundan bağımsızdır. Ön yüze katı renk, degrade, desen veya resim dolgu uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını koruyabilirsiniz.

Bu örnek, şekle bir degrade dolgu ve yanlara daha koyu bir ekstrüzyon rengi uygular:

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

![Renderlanmış 3B dikdörtgen, mavi‑turuncu degrade dolgu ve turuncu ekstrüzyon](img_02_03.png)

Resim dolgu kullanmak isterseniz, resmi sunuma ekleyin ve şekil dolgusuna atayın:

```py
with open("image.jpg", "rb") as image_file:
    image_data = image_file.read()

image = presentation.images.add_image(image_data)

shape.fill_format.fill_type = slides.FillType.PICTURE
shape.fill_format.picture_fill_format.picture.image = image
shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

shape.three_d_format.camera.set_rotation(10, 20, 30)
shape.three_d_format.extrusion_height = 150
shape.three_d_format.extrusion_color.color = drawing.Color.dark_orange
```

Resim ön yüzde renderlanırken, ekstrüzyon 3B yan yüz olarak renderlanır:

![Renderlanmış 3B dikdörtgen, ön yüzde fotoğraf dolgu ve turuncu ekstrüzyon](img_02_04.png)

## **Metne 3B Biçimlendirme Uygulama**

Şekil 3B biçimlendirmesi şekil gövdesini etkiler. Metin 3B biçimlendirmesi ise metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için kullanışlıdır.

Aşağıdaki örnek, desen dolgu ile metin oluşturur, bir WordArt dönüşümü uygular ve [TextFrameFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/) üzerinde 3B ayarları yapılandırır:

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

Metin, kavisli, ekstrüde edilmiş 3B harfler olarak renderlanır:

![Renderlanmış 3B metin, kemerli WordArt dönüşümü, turuncu desen dolgu ve koyu ekstrüzyon](img_02_05.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3B biçimlendirmeyi korur. Sabit‑sayfa formatlarına renderlarken veya dışa aktarırken 3B sahne rasterleştirilir ve çıktı 2B bir sonuç olarak çizilir. Bu durum, slaytları [PNG](/slides/tr/python-net/convert-powerpoint-to-png/), [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/tr/python-net/convert-powerpoint-to-html/) olarak renderladığınızda veya [video dönüştürme](/slides/tr/python-net/convert-powerpoint-to-video/) için kareler oluşturduğunuzda geçerlidir.

Aşağıdaki noktaları akılda tutun:

- Dışa aktarılan görüntüler ve PDF’ler etkileşimli değildir. Nesne dışa aktarımdan sonra izleyici tarafından döndürülemez.
- Nihai görünüm, kamera, ışık rigi, malzeme, ekstrüzyon, dolgu ve slayt ölçeklemesinin kombinasyonuna bağlıdır.
- Kalıtılmış veya tema‑tabanlı biçimlendirme değerlerini incelemeniz gerekiyorsa, [etkin şekil özelliklerini](/slides/tr/python-net/shape-effective-properties/) okuyun.
- Bazı çıktı formatları düzenlenebilir PowerPoint 3B biçimlendirmesini saklayamaz. Bu formatlarda görsel sonuç renderlanır, düzenlenebilir 3B ayarlar korunmaz.

## **SSS**

**Aspose.Slides etkileşimli 3B sunumlar oluşturabilir mi?**

Aspose.Slides, şekil ve metinler için PowerPoint 3B efektlerini oluşturur ve renderlar. Dışa aktarılan görüntüler, PDF’ler veya HTML sayfaları, izleyicinin döndürebileceği etkileşimli 3B sahneler haline getirmez. PPTX içinde, 3B biçimlendirme PowerPoint’te düzenlenebilir durumda kalır.

**3B model ile 3B efekt arasındaki fark nedir?**

3B model, sunuma eklenen ayrı bir 3B nesnedir. 3B efekt ise, bir PowerPoint şekli veya metnine uygulanan döndürme, ekstrüzyon, açılma, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale, 3B efektleri ele alır.

**Görünür bir 3B şekil için hangi ayarlar gereklidir?**

En az bir kamera döndürmesi ve ya ekstrüzyon ya da derinlik ayarı gerekir. Pratikte, yüzeylerin belirgin vurgular ve gölgeler alması için bir ışık rigi ve malzeme de ayarlanmalıdır.

**Hem şekillere hem de metne 3B efektler uygulayabilir miyim?**

Evet. Şekil gövdesi için [Shape.three_d_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/three_d_format/), metin için ise [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/three_d_format/) kullanın.

**3B efektler görüntülere, PDF, HTML veya video karelerine dışa aktarılırken görünecek mi?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler üretilirken 3B efektleri renderlar. Dışa aktarılan çıktı renderlanmış görünümü içerir, düzenlenebilir bir 3B nesne içermez.

**Kalıtım ve tema ayarları uygulandıktan sonra nihai 3B değerlerini okuyabilir miyim?**

Evet. Nihai kamera, ışık rigi, açılma ve ilgili 3B değerlerini okumak için [Şekil Etkin Özellikleri](/slides/tr/python-net/shape-effective-properties/) API’lerini kullanın.