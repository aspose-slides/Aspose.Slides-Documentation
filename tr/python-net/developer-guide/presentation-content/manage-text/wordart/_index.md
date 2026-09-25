---
title: Python'da WordArt Efektleri Oluşturma ve Uygulama
linktitle: WordArt
type: docs
weight: 110
url: /tr/python-net/wordart/
keywords:
- WordArt
- WordArt oluştur
- WordArt şablonu
- WordArt efekti
- gölge efekti
- yansıma efekti
- parıltı efekti
- WordArt dönüşümü
- 3B efekti
- dış gölge efekti
- iç gölge efekti
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET içinde WordArt efektlerini oluşturun ve özelleştirin. Bu adım adım rehber, geliştiricilerin Python'da profesyonel metinle sunumları geliştirmesine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri, metni dolgu, kenarlık, gölgeler, yansımalar, parlaklık, dönüşümler ve 3B biçimlendirme ile stilize etmenizi sağlar. Bu makale, Microsoft Office yüklü olmadan, Aspose.Slides for Python via .NET kullanarak PowerPoint sunumlarında bu efektleri nasıl oluşturup özelleştireceğinizi açıklar.

## **Basit bir WordArt Şablonu Oluşturun ve Metne Uygulayın**

Aşağıdaki örnekler, metni, yazı tipini, desen doldurmayı ve kenarlığı ayarlayarak basit bir WordArt stili oluşturur.

Her örnek yeni bir sunum oluşturur ve ilk slaytına bir dikdörtgen ekler; girdi dosyasına gerek yoktur. İlk örnek metni "Aspose.Slides" olarak ayarlar. Şeklin konumu ve boyutları puan cinsinden ölçülür:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame

    portion = text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
```

Biçimlendirmeyi daha belirgin hale getirmek için yazı tipini 36 puan Arial Black olarak ayarlayın:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36
```

Karanlık turuncu ön plan ve beyaz arka plan ile bir [SMALL_GRID](https://reference.aspose.com/slides/tr/python-net/aspose.slides/patternstyle/) deseni uygulayın, ardından 1 puan genişliğinde siyah bir metin kenarlığı ekleyin:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID

    portion.portion_format.line_format.width = 1
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Ortaya çıkan metin:

![Basit WordArt şablonu](WordArt_template.png)

## **Diğer WordArt Efektlerini Uygula**

Aşağıdaki örnekler, metne gölgeler, yansımalar, parıltı, dönüşümler ve 3B efektler uygulamanın yollarını gösterir.

### **Dış Gölge Efektlerini Uygula**

Bir dış gölge, metnin arkasına gölge ekleyerek derinlik kazandırır. Rengini, yönünü, mesafesini, bulanıklaştırma yarıçapını, ölçeğini ve eğimini özelleştirebilirsiniz.

Bu örnek [enable_outer_shadow_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides/effectformat/enable_outer_shadow_effect/) metodunu çağırır ve 4 puan bulanık yarıçap, 230 derece yön ve 30 puan mesafe ile siyah bir gölge ayarlar. Ölçek değeri 100 gölgenin boyutunu korur, yatay eğim ise 20 derece döndürür. Alfa dönüşümü gölgenin opaklığını %32 olarak belirler:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 100
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 20
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Ortaya çıkan metin:

![Dış Gölge efekti](outer_shadow_effect.png)

{{% alert color="info" title="Not" %}}
- Dış ve önceden ayarlanmış gölgeler birlikte kullanıldığında, yalnızca dış gölge uygulanır.
- Dış ve iç gölgeler aynı anda kullanılırsa, ortaya çıkan efekt PowerPoint sürümüne bağlıdır. Örneğin, PowerPoint 2013'te efekt iki katına çıkar, PowerPoint 2007'de ise yalnızca dış gölge uygulanır.
{{% /alert %}}

### **Yansıma Efektlerini Uygula**

Yansıma, metnin ayna gibi bir kopyasını oluşturur. Görünümünü kontrol etmek için konumunu, ölçeğini, bulanıklığını ve opaklığını ayarlayın.

Bu örnek [enable_reflection_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides/effectformat/enable_reflection_effect/) metodunu çağırır ve yansımayı -100% ölçekle dikey olarak çevirir. 0.5 puan bulanık yarıçap ve 4.72 puan mesafe kullanır. Opaklık, yansımanın 0% ve 60% konumları arasında %60'tan %0.9'a azalır:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5
    portion.portion_format.effect_format.reflection_effect.distance = 4.72
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT
```

Ortaya çıkan metin:

![Yansıma efekti](reflection_effect.png)

### **Parıltı Efektlerini Uygula**

Parıltı, metnin etrafına yumuşak renkli bir kenarlık ekler. Etkiyi kontrol etmek için rengini, opaklığını ve yarıçapını ayarlayın.

Bu örnek [enable_glow_effect](https://reference.aspose.com/slides/tr/python-net/aspose.slides/effectformat/enable_glow_effect/) metodunu çağırır ve %54 opaklıkta ve 7 puan yarıçapta kırmızı bir parıltı uygular:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    portion = auto_shape.text_frame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"
    portion.portion_format.latin_font = slides.FontData("Arial Black")
    portion.portion_format.font_height = 36

    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.color = draw.Color.red
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

Ortaya çıkan metin:

![Parıltı efekti](glow_effect.png)

### **WordArt Dönüşümlerini Uygula**

WordArt dönüşümleri, bir metin bloğunu bükebilir, uzatabilir veya şekillendirebilir.

[transform](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/transform/) özelliğini [ARCH_UP_POUR](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textshapetype/) olarak ayarlayarak tüm metin çerçevesini yukarı doğru kıvrımlı hâle getirin:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)

    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"
    text_frame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Ortaya çıkan metin:

![WordArt dönüşümü](transform_effect.png)

{{% alert color="info" title="Not" %}}
Aspose.Slides for Python via .NET, önceden tanımlı bir dizi [dönüşüm tipi](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textshapetype/) sağlar.
{{% /alert %}}

### **Şekillere ve Metne 3B Efektler Uygula**

Bir şekle ya da şeklin metnine 3B efektler uygulayabilirsiniz. Kemer, ekstrüzyon, aydınlatma ve kamera ayarları ortaya çıkan görünümü kontrol eder.

Aşağıdaki örnek, dikdörtgene dairesel kenar, turuncu ekstrüzyon ve koyu kırmızı kontur eklemek için [ThreeDFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/) kullanır. Kemer boyutları, ekstrüzyon yüksekliği, kontur genişliği ve derinlik puan cinsinden ölçülür. Plastik bir malzeme, Z ekseni etrafında 40 derece döndürülmüş dengeli aydınlatma ve bir perspektif kamera görünümünü tanımlar:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    auto_shape.text_frame.text = "Aspose.Slides"

    auto_shape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_bottom.height = 10.5
    auto_shape.three_d_format.bevel_bottom.width = 10.5

    auto_shape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    auto_shape.three_d_format.bevel_top.height = 12.5
    auto_shape.three_d_format.bevel_top.width = 11

    auto_shape.three_d_format.extrusion_color.color = draw.Color.orange
    auto_shape.three_d_format.extrusion_height = 6

    auto_shape.three_d_format.contour_color.color = draw.Color.dark_red
    auto_shape.three_d_format.contour_width = 1.5

    auto_shape.three_d_format.depth = 3

    auto_shape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    auto_shape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    auto_shape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    auto_shape.three_d_format.light_rig.set_rotation(0, 0, 40)

    auto_shape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Ortaya çıkan şekil:

![Şekil 3B efekti](shape_3D_effect.png)

Bu örnek, metne benzer bir 3B biçimlendirme uygulamak için [TextFrameFormat.three_d_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/three_d_format/) kullanır. Daha küçük kemerler harf kenarlarını şekillendirirken, ekstrüzyon ve aydınlatma metne derinlik katar:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 200)
    text_frame = auto_shape.text_frame
    text_frame.text = "Aspose.Slides"

    text_frame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    text_frame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    text_frame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    text_frame.text_frame_format.three_d_format.bevel_top.height = 4
    text_frame.text_frame_format.three_d_format.bevel_top.width = 4

    text_frame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    text_frame.text_frame_format.three_d_format.extrusion_height = 6

    text_frame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    text_frame.text_frame_format.three_d_format.contour_width = 1.5

    text_frame.text_frame_format.three_d_format.depth = 3

    text_frame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    text_frame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    text_frame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    text_frame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    text_frame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Ortaya çıkan metin:

![Metin 3B efekti](text_3D_effect.png)

{{% alert color="info" title="Not" %}}
Metne veya şekline 3B efektlerin uygulanması ve bu efektler arasındaki etkileşim, belirli kurallara göre yönetilir. Metin ve onu içeren şekli kapsayan bir sahneyi düşünün. 3B efekt, nesnenin 3B temsili ve yer aldığı sahneyi içerir.

- Şekil ve metin için her ikisinde de bir sahne ayarlanmışsa, şeklin sahnesi öncelikli olur ve metnin sahnesi yok sayılır.
- Şeklin kendi sahnesi yok ancak bir 3B temsili varsa, metnin sahnesi kullanılır.
- Şeklin hiç 3B etkisi yoksa, düz olarak değerlendirilir ve 3B efekt yalnızca metne uygulanır.

Bu davranışlar, [ThreeDFormat.light_rig](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/light_rig/) ve [ThreeDFormat.camera](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/camera/) özellikleriyle ilgilidir.
{{% /alert %}}

Metni düz ve okunabilir tutarken şeklin 3B biçimlendirmesini korumak için, her iki ayarın karşılaştırmasını ve tam bir Python örneğini içeren [Keep Text Flat on a 3D Shape](/slides/tr/python-net/3d-presentation/) sayfasına bakın.

## **SSS**

**Farklı yazı tipleri veya diller (ör. Arapça, Çince) ile WordArt efektlerini kullanabilir miyim?**

Evet, Aspose.Slides for Python via .NET Unicode desteği sağlar ve tüm büyük yazı tipleri ve dillerle çalışır. WordArt efektleri (gölge, doldurma, kenarlık vb.) dil bağımsız olarak uygulanabilir, ancak yazı tipi bulunabilirliği ve renderlama sistem yazı tiplerine bağlı olabilir.

**WordArt efektlerini slayt ana düzeni öğelerine uygulayabilir miyim?**

Evet, WordArt efektlerini ana slaytlardaki şekillere, başlık yer tutucularına, altbilgilere veya arka plan metnine uygulayabilirsiniz. Ana düzen üzerindeki değişiklikler, ilişkili tüm slaytlara yansır.

**WordArt efektleri sunum dosya boyutunu etkiler mi?**

Biraz. Gölgeler, parıltılar ve degrade doldurmalar gibi WordArt efektleri, ek formatlama meta verileri nedeniyle dosya boyutunu biraz artırabilir, ancak fark genellikle ihmal edilebilir düzeydedir.

**WordArt efektlerinin sonucunu sunumu kaydetmeden önizleyebilir miyim?**

Evet, WordArt içeren slaytları görüntülere (ör. PNG, JPEG) [Slide.get_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/get_image/) ile renderlayabilir veya bireysel şekilleri [Shape.get_image](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/get_image/) ile renderlayabilirsiniz. Bu sayede tam sunumu kaydetmeden veya dışa aktarmadan önce sonucu bellekte ya da ekranda önizleyebilirsiniz.