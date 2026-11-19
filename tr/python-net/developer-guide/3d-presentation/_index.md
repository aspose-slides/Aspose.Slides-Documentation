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
description: "Aspose.Slides ile Python'da PowerPoint şekilleri ve metni için 3D efektleri uygulayın ve renderlayın. Kamera, aydınlatma, malzeme, ekstrüzyon, doldurmalar ve 3D metni yapılandırın."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, şekiller ve metinler için PowerPoint benzeri 3D biçimlendirmeyi oluşturabilir, düzenleyebilir, koruyabilir ve renderlayabilir. Bu makale, döndürme, ekstrüzyon, eğim, aydınlatma, malzeme, degrade veya resim doldurma ve 3D metin gibi 3D efektlerini kapsar.

{{% alert color="info" title="Note" %}}

Bu makale, PowerPoint şekilleri ve metni üzerindeki 3D biçimlendirme efektleriyle ilgilidir. Ayrı bir 3D model dosyası ekleme veya düzenleme konusunu ele almaz. Bir slaytı görüntüye, PDF'ye veya HTML'ye dışa aktardığınızda, Aspose.Slides bu 3D efektlerini dışa aktarılan 2D çıktıya renderlar.

{{% /alert %}}

## **3D Biçimlendirme Kavramları**

[Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) özelliğini kullanarak bir şekle 3D biçimlendirme uygulayın. Bu özellik, o şekil için 3D sahneyi kontrol eden [ThreeDFormat](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/) nesnesini ortaya çıkarır.

Metin için, [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) özelliğini kullanın. Bu, şekil gövdesi yerine metin çerçevesine 3D biçimlendirme uygular.

En önemli özellikler şunlardır:

| Özellik | Ne kontrol eder | Ne zaman kullanılır |
|---|---|---|
| [camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) | Görüş noktası, önceden ayarlanmış kamera türü, döndürme, yakınlaştırma ve perspektif. | Nesneyi 3B uzayda döndürün veya bir PowerPoint 3B döndürme ön ayarıyla eşleştirin. |
| [light_rig](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/light_rig/) | Işık ön ayarı, yön ve ışık döndürmesi. | 3D yüzeydeki vurguların ve gölgelerin nasıl göründüğünü değiştirin. |
| [material](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/material/) | Düz, mat, plastik veya metal gibi yüzey malzemesi. | Aynı geometriyi daha düz, daha yumuşak, parlak veya metalik görünür kılın. |
| [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) | Şeklin ön yüzünden geriye doğru ne kadar uzandığı. | Düz bir şekli gözle görülür kalın bir 3D nesneye dönüştürün. |
| [extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) | Ekstrüde edilen yanların rengi. | Derinliği görünür kılın veya yan rengi ön doldurma ile eşleştirin. |
| [depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) | PowerPoint 3D biçimlendirmesinde kullanılan ek 3D derinlik. | Şekil veya metin için derinliği ince ayarlayın, özellikle eğim ve malzeme ayarlarıyla birlikte. |
| [bevel_top](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_top/) ve [bevel_bottom](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/bevel_bottom/) | Ön ve arka yüzlerde yükseltilmiş veya yuvarlatılmış kenarlar. | Keskin düz bir yüz yerine yumuşatılmış veya kalıplanmış bir kenar ekleyin. |
| [contour_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_color/) ve [contour_width](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/contour_width/) | 3D nesnenin etrafındaki kontur. | Renderlenen çıktıdaki nesne sınırını vurgulayın. |

## **3D Bir Şekil Oluşturma**

Bir şeklin ikna edici bir şekilde 3D görünmesi için genellikle dört tür ayara ihtiyaç duyar:

- Kamera ayarları, çünkü varsayılan ön görünüm ekstrüzyonu gizleyebilir.
- Işık ayarları, çünkü aydınlatma yüzeylerin ve yanların okunabilir olmasını sağlar.
- Malzeme ayarları, çünkü yüzey ışığın nasıl renderlanacağını etkiler.
- Ekstrüzyon veya derinlik ayarları, çünkü düz bir şeklin kalınlığa ihtiyacı vardır.

Aşağıdaki örnek bir dikdörtgen oluşturur, ön yüzüne metin ekler ve 3D biçimlendirme uygular. Kamera döndürme değerleri derecedir ve ekstrüzyon yüksekliği 100 puandır. Örnek, slaytı iki katı varsayılan boyutlarda PNG görüntüsü olarak renderlar ve sunumu PPTX olarak kaydeder.

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

Renderlanan slayt görüntüsü, dikdörtgeni kalın bir 3D blok olarak gösterir:

![Ön yüzde beyaz 3D metinli mavi 3D dikdörtgen render edilmiştir](img_01_01.png)

## **Kamera ile Bir Şekli Döndürme**

PowerPoint'te 3D döndürme, 3‑D Döndürme bölmesinden yapılandırılır. X, Y ve Z döndürme değerleri, kamera API'si üzerinden ayarladığınız döndürmeye karşılık gelir.

![PowerPoint 3‑D Döndürme bölmesi, X, Y ve Z döndürme değerleri vurgulanmış](img_02_01.png)

Aspose.Slides'te kameraya [ThreeDFormat.camera](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/camera/) üzerinden erişilir. Bu örnek bir dikdörtgen oluşturur, ortografik ön görünüm seçer ve X, Y, Z döndürmelerini sırasıyla 20, 30 ve 40 derece olarak ayarlar. Şekli bellekte yapılandırır, dosya kaydetmez:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 150, 200, 200)

    shape.three_d_format.camera.camera_type = slides.CameraPresetType.ORTHOGRAPHIC_FRONT
    shape.three_d_format.camera.set_rotation(20, 30, 40)
```

Kamerayı, izleyicinin nesneyi nasıl gördüğünü değiştirmek istediğinizde kullanın. Bu, slayttaki 2D şekil geometrisini değiştirmez. PowerPoint ve Aspose.Slides tarafından render edilirken kullanılan 3D bakış noktasını değiştirir.

### **Şablon Şekilden Kamera Yönelimi Kopyalama**

Şablon şeklinin yönelimini eşleştirmek için, onun [camera_type](https://reference.aspose.com/slides/python-net/aspose.slides/camera/camera_type/) ön ayarını kopyalayın ve [get_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/get_rotation/) ile döndürmesini okuyun. Örnek `template.pptx` dosyasını açar ve ilk slaydın ilk şeklinin kamera yönelimini ikinci şekle kopyalar. Her iki şeklin de zaten 3D aydınlatması vardır ve ikinci şeklin açık bir kamera döndürmesi yoktur.

Açı değerleri derecedir. `0`, `1` ve `2` indisleri sırasıyla enlem, boylam ve devri tutar. Bu sırayla [set_rotation](https://reference.aspose.com/slides/python-net/aspose.slides/camera/set_rotation/) metoduna gönderin. Kaynakta açık bir döndürme yoksa, `get_rotation` `None` döndürür; bu durumda hedef açıları ayarlamayın. Kaynak tüm üç açıyı sıfıra ayarlamışsa, bu sıfırları kopyalayın.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    shapes = presentation.slides[0].shapes
    
    source_camera = shapes[0].three_d_format.camera
    destination_camera = shapes[1].three_d_format.camera

    destination_camera.camera_type = source_camera.camera_type
    angles = source_camera.get_rotation()
    if angles is not None:
        destination_camera.set_rotation(angles[0], angles[1], angles[2])

    presentation.save("camera-copy.pptx", slides.export.SaveFormat.PPTX)
```

`camera-copy.pptx` dosyasını PowerPoint'te yeniden açtığınızda, her iki şeklin de aynı kamera ön ayarı ve döndürmesi olur. Sağdaki ok, soldaki dikdörtgenden kopyalanan yönelimle gösterilir. Her iki şekil de aynı aydınlatma ve ekstrüzyon derinliğine sahiptir.

![Sol taraftaki dikdörtgenden kopyalanan yönelimle sağdaki ok, üstten ve sağdan bakıldığında aynı kamera yönelimini gösterir](camera-orientation.png)

## **Ekstrüzyon ve Derinlik Ekleme**

Ekstrüzyon, bir şeklin ön yüzünün arkasına uzanarak kalın görünmesini sağlar. PowerPoint'te derinlik kontrolü bu görünür kalınlığı ayarlar ve renk kontrolü yan yüzlerin rengini belirler.

![PowerPoint derinlik kontrolleri, ekstrüzyon rengi ve ekstrüzyon yüksekliği özelliklerine eşlenmiştir](img_02_02.png)

Kalınlık için [ThreeDFormat.extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/), yan renk için ise [ThreeDFormat.extrusion_color](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_color/) ayarlayın. Bu örnek, dikdörtgene 100 puanlık ekstrüzyon, mor yanlar verir ve kalınlığını göstermek için kamerayı döndürür. Şekli bellekte yapılandırır, dosya kaydetmez:

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

[ThreeDFormat.depth](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/depth/) özelliği, bir 3D şeklin derinliğini ayarlar. [extrusion_height](https://reference.aspose.com/slides/python-net/aspose.slides/threedformat/extrusion_height/) özelliği ise ekstrüzyon etkisinin yüksekliğini kontrol eder; bu örnekte gösterildiği gibi.

## **3D Efektlerle Degrade veya Resim Doldurma Kullanma**

3D biçimlendirme, şekil doldurmasından bağımsızdır. Ön yüze katı renk, degrade, desen veya resim doldurma uygulayabilir ve aynı kamera, ışık, malzeme ve ekstrüzyon ayarlarını tutabilirsiniz.

Bu örnek, ön yüze mavi‑turuncu bir degrade ve 150 puanlık ekstrüzyona koyu turuncu bir renk uygular. Degrade durakları 0 ve 100, başlangıç ve bitişi işaret eder. Kamera döndürme değerleri derecedir. Slayt iki katı varsayılan boyutta PNG olarak renderlanır:

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

Renderlanan çıktı, ön yüze degradeyi korur ve ekstrüzyonu ayrı olarak renderlar:

![Mavi‑turuncu degrade doldurmaya ve turuncu ekstrüzyona sahip 3D dikdörtgen render edilmiştir](img_02_03.png)

Resim doldurma kullanmak için, resmi sunuma ekleyin ve şekil doldurmasına atayın. Bu örnek, çalışma dizininde "image.jpg" adlı bir dosyanın mevcut olduğunu varsayar. Resmi dikdörtgeni dolduracak şekilde uzatır, 150 puanlık ekstrüzyon uygular ve kamera döndürmesini derece cinsinden ayarlar. Şekli bellekte yapılandırır, dosya kaydetmez veya renderlamaz:

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

Resim ön yüze renderlanırken, ekstrüzyon 3D yan yüz olarak renderlanır:

![Ön yüzde fotoğraf doldurmalı ve turuncu ekstrüzyona sahip 3D dikdörtgen render edilmiştir](img_02_04.png)

## **Metne 3D Biçimlendirme Uygulama**

Şekil 3D biçimlendirmesi şekil gövdesini etkiler. Metin 3D biçimlendirmesi ise metin çerçevesini etkiler. Bu, harflerin kendisinin ekstrüzyon, malzeme, aydınlatma ve kamera ayarlarına ihtiyaç duyduğu WordArt benzeri efektler için kullanışlıdır.

Aşağıdaki örnek, turuncu‑beyaz ızgara deseniyle bir metin oluşturur, yukarı doğru bir yay ekler ve [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) üzerinden 3D ayarlarını yapılandırır. Ekstrüzyon yüksekliği ve derinlik puan cinsindedir, ışık döndürmesi derecedir. Şekil doldurma ve kenarlık gizlenir, böylece sadece metin görünür. Örnek iki katı varsayılan slayt boyutunda PNG renderlar ve sunumu PPTX olarak kaydeder:

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

Metin, kavisli, ekstrüde 3D harfler olarak renderlanmıştır:

![Yaylı WordArt dönüşümüne, turuncu desen doldurmasına ve koyu ekstrüzyona sahip 3D metin render edilmiştir](img_02_05.png)

## **3D Şekilde Metni Düz Tutma**

Metnin okunabilirliğini korurken şeklin 3D görünümünü korumak için, [TextFrameFormat.keep_text_flat](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/keep_text_flat/) özelliğini [TextFrame.text_frame_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text_frame_format/) üzerinden ayarlayın. Değer `True` olduğunda, metin 3D sahnenin dışındadır. `False` olduğunda, metin sahneye katılır ve 3D yönelimini izler.

Bu ayar, şeklin [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/) üzerinden yapılandırılmış kamera, aydınlatma, malzeme ve ekstrüzyon gibi 3D biçimlendirmesini kaldırmaz. Ayrıca normal döndürmeden farklıdır. [Shape.rotation](https://reference.aspose.com/slides/python-net/aspose.slides/shape/rotation/) slayd düzleminde şekli döndürürken, [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) metnin sınırlayıcı kutusu içinde özelleştirilmiş döndürmesini kontrol eder. Metni 3D sahneden dışarıda tutmak bu açıları sıfırlamaz.

Aşağıdaki bağımsız örnek, metinli mavi bir dikdörtgen oluşturur ve onu orijinalin yanına kopyalar. Her iki şeklin de aynı 3D biçimlendirmesi vardır; sadece metin ayarı farklıdır: solda `False`, sağda `True`. Kamera açıları derecedir, ekstrüzyon yüksekliği 40 puandır. Örnek sunumu PPTX olarak kaydeder ve karşılaştırma slaydını iki katı varsayılan boyutta PNG olarak renderlar.

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

Solda metin 3D yönelime uyar. Sağda ise metin düz kalır ve okunması daha kolaydır. Her iki dikdörtgen de aynı görünür ekstrüzyon ve 3D yönelime sahiptir.

![Yan yana 3D dikdörtgenler: solda keep_text_flat `False`, sağda `True`](keep_text_flat.png)

## **Dışa Aktarma ve Render Davranışı**

Aspose.Slides, PPTX gibi PowerPoint formatlarına kaydederken 3D biçimlendirmeyi korur. Sabit sayfa formatlarına renderlarken veya dışa aktarırken 3D sahne rasterleştirir veya çıktıya 2D sonuç olarak çizer. Bu, slaytları [PNG](/slides/tr/python-net/convert-powerpoint-to-png/), [PDF](/slides/tr/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/tr/python-net/convert-powerpoint-to-html/) olarak renderladığınızda veya [video dönüşümü](/slides/tr/python-net/convert-powerpoint-to-video/) için kareler oluşturduğunuzda geçerlidir.

Şu noktalara dikkat edin:

- Dışa aktarılan görüntüler ve PDF'ler etkileşimli değildir. Nesne dışa aktarıldıktan sonra izleyici tarafından döndürülmez.
- Son görünüm, kamera, ışık seti, malzeme, ekstrüzyon, doldurma ve slayt ölçeklemesinin birleşimine bağlıdır.
- Kalıtlara veya tema tabanlı biçimlendirme değerlerine bakmanız gerekiyorsa, [etkili şekil özelliklerini](/slides/tr/python-net/shape-effective-properties/) okuyun.
- Bazı çıktı formatları düzenlenebilir PowerPoint 3D biçimlendirmesini saklayamaz. Bu formatlarda görsel sonuç, düzenlenebilir 3D ayarları yerine renderlanmış olarak kaydedilir.

## **SSS**

**Aspose.Slides etkileşimli 3D sunumlar oluşturabilir mi?**

Aspose.Slides, şekiller ve metinler için PowerPoint 3D efektlerini oluşturur ve renderlar. Dışa aktarılan görüntüler, PDF'ler veya HTML sayfaları, izleyicinin döndürebileceği etkileşimli 3D sahneler haline getirmez. PPTX içinde, format destekliyorsa 3D biçimlendirme PowerPoint'te düzenlenebilir kalır.

**3D model ile 3D efekt arasındaki fark nedir?**

3D model, bir sunuma eklenen ayrı bir 3D nesnedir. 3D efekt, bir normal PowerPoint şekline veya metnine uygulanan, döndürme, ekstrüzyon, eğim, aydınlatma ve malzeme gibi biçimlendirmedir. Bu makale 3D efektleri kapsar.

**Görünür bir 3D şekil için hangi ayarlar gereklidir?**

En az bir kamera döndürmesi ve ekstrüzyon ya da derinlik ayarı gerekir. Uygulamada ayrıca ışık seti ve malzeme de ayarlanmalıdır; böylece renderlanan yüzler net vurgular ve gölgeler alır.

**Hem şekillere hem de metne 3D efektleri uygulayabilir miyim?**

Evet. Şekil gövdesi için [Shape.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/shape/three_d_format/), metin için ise [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/three_d_format/) kullanın.

**3D efektler görüntülere, PDF'ye, HTML'ye veya video karelerine dışa aktarılırken görünür mü?**

Evet. Aspose.Slides, slayt görüntüleri, PDF çıktısı, HTML çıktısı ve video dönüşümü için kullanılan kareler üretildiğinde 3D efektleri renderlar. Dışa aktarılan çıktı renderlanmış görünümü içerir, düzenlenebilir bir 3D nesne değil.

**Kalıtım ve tema ayarları uygulandıktan sonra nihai 3D değerlerini okuyabilir miyim?**

Evet. Nihai kamera, ışık seti, eğim ve ilgili 3D değerlerini okumak için [Şekil Etkili Özellikleri](/slides/tr/python-net/shape-effective-properties/) açıklanan etkili biçimlendirme API'larını kullanın.