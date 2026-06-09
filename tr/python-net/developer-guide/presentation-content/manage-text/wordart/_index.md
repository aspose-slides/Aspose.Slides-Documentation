---
title: Python'da WordArt Efektlerini Oluşturma ve Uygulama
linktitle: WordArt
type: docs
weight: 110
url: /tr/python-net/wordart/
keywords:
- WordArt
- WordArt Oluştur
- WordArt Şablonu
- WordArt Efekti
- Gölge Efekti
- Görünüm Efekti
- Parıltı Efekti
- WordArt Dönüşümü
- 3D Efekti
- Dış Gölge Efekti
- İç Gölge Efekti
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'te WordArt efektlerini nasıl oluşturup özelleştireceğinizi öğrenin. Bu adım adım rehber, geliştiricilerin Python'da şık ve profesyonel metinlerle sunumları geliştirmesine yardımcı olur."
---
## **Genel Bakış**

WordArt efektleri, PowerPoint sunumlarınıza görsel açıdan çekici, stilize metin eklemenizi sağlar. Aspose.Slides ile geliştiriciler, Microsoft PowerPoint'te olduğu gibi WordArt'ı programlı olarak oluşturabilir, özelleştirebilir ve yönetebilir—Office kurulu olmasa bile. Bu makale, WordArt ile çalışmanın bir genel bakışını sunar; metin dönüşümleri, doldurma stilleri, kenarlıklar, gölgeler ve daha fazla biçimlendirme seçeneği nasıl uygulanır, sunum içeriğinizi daha etkileyici ve çekici hale getirmek için açıklanır. WordArt, metni bir grafik nesnesi gibi ele almanızı sağlar. Metni daha çekici veya fark edilir kılmak için uygulanan efektler veya özel değişikliklerden oluşur.

**Microsoft PowerPoint'te WordArt**

Microsoft PowerPoint'te WordArt kullanmak için ön tanımlı WordArt şablonlarından birini seçmeniz gerekir. WordArt şablonu, bir metne veya şekline uygulanan efektlerden oluşan bir settir.

**Aspose.Slides'ta WordArt**

Aspose.Slides for Python via .NET 20.10'da WordArt desteğini uyguladık ve sonraki Aspose.Slides for Python via .NET sürümlerinde özelliği geliştirdik.  
Aspose.Slides for Python via .NET ile Python'da kendi WordArt şablonunuzu (tek bir efekt ya da efekt kombinasyonu) kolayca oluşturabilir ve metinlere uygulayabilirsiniz.

## Basit Bir WordArt Şablonu Oluşturma ve Metne Uygulama

**Aspose.Slides Kullanarak** 

İlk olarak, bu Python kodu ile basit bir metin oluşturuyoruz: 

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
Şimdi, bu kod ile metnin yazı tipi yüksekliğini daha büyük bir değere ayarlayarak efekti daha belirgin hâle getiriyoruz:

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Microsoft PowerPoint Kullanarak**

Microsoft PowerPoint'te WordArt efektleri menüsüne gidin:

![todo:image_alt_text](image-20200930113926-1.png)

Sağdaki menüden ön tanımlı bir WordArt efekti seçebilirsiniz. Soldaki menüden yeni bir WordArt için ayarları belirleyebilirsiniz.  

Bunlar mevcut parametrelerden veya seçeneklerden bazılarıdır:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides Kullanarak**

Burada, bu kod ile metne SmallGrid desen rengini uygular ve 1 genişliğinde siyah bir metin kenarlığı ekleriz:

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

Ortaya çıkan metin:

![todo:image_alt_text](image-20200930114108-4.png)

## Diğer WordArt Efektlerini Uygulama

**Microsoft PowerPoint Kullanarak**

Program arayüzünden bu efektleri bir metne, metin bloğuna, şekle veya benzer bir elemana uygulayabilirsiniz:

![todo:image_alt_text](image-20200930114129-5.png)

Örneğin, Gölge, Yansıma ve Parıltı efektleri bir metne uygulanabilir; 3D Biçim ve 3D Döndürme efektleri bir metin bloğuna uygulanabilir; Yumuşak Kenarlar özelliği bir Şekil Nesnesine uygulanabilir (3D Biçim özelliği ayarlı değilse bile etkisi vardır).

### Gölge Efektlerini Uygulama

Burada, yalnızca bir metinle ilgili özellikleri ayarlamayı amaçlıyoruz. Python'da bu kodu kullanarak metne gölge efektini uyguluyoruz:

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Aspose.Slides API, üç tür gölgeyi destekler: OuterShadow, InnerShadow ve PresetShadow.  
PresetShadow ile bir metne (ön ayarlı değerler kullanarak) gölge uygulayabilirsiniz.

**Microsoft PowerPoint Kullanarak**

PowerPoint'te tek bir gölge türü kullanabilirsiniz. İşte bir örnek:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides Kullanarak**

Aspose.Slides, aslında aynı anda iki gölge türünü uygulamanıza izin verir: InnerShadow ve PresetShadow.

**Notlar:**

- OuterShadow ve PresetShadow birlikte kullanıldığında, yalnızca OuterShadow efekti uygulanır.  
- OuterShadow ve InnerShadow aynı anda kullanılırsa, ortaya çıkan veya uygulanan efekt PowerPoint sürümüne bağlıdır. Örneğin, PowerPoint 2013'te efekt iki katına çıkar. Ancak PowerPoint 2007'de OuterShadow efekti uygulanır.

### Metinlere Görünüm Uygulama

Python'daki bu kod örneği ile metne görünüm ekliyoruz:

```py 
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

### Metinlere Parıltı Efekti Uygulama

Bu kodu kullanarak metne parıltı efekti uygulayarak parlak veya öne çıkmasını sağlarız:

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

İşlemin sonucu:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Gölge, görünüm ve parıltı parametrelerini değiştirebilirsiniz. Efektlerin özellikleri metnin her bölümüne ayrı ayrı ayarlanır. 
{{% /alert %}} 

### WordArt'ta Dönüşümleri Kullanma

Bu kod ile Transform özelliğini (metnin tamamındaki blokta yer alan) kullanıyoruz:

```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

Sonuç:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint ve Aspose.Slides for Python via .NET, belirli sayıda ön tanımlı dönüşüm türü sağlar. 
{{% /alert %}} 

**PowerPoint Kullanarak**

Ön tanımlı dönüşüm türlerine erişmek için şu yolu izleyin: **Format** -> **TextEffect** -> **Transform**

**Aspose.Slides Kullanarak**

Bir dönüşüm türü seçmek için TextShapeType enumeration'ını kullanın.

### Metinlere ve Şekillere 3D Efektleri Uygulama

Bu örnek kod ile bir metin şekline 3D efekti ayarlıyoruz:

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

Ortaya çıkan metin ve şekli:

![todo:image_alt_text](image-20200930114816-9.png)

Bu Python kodu ile metne 3D efekti uyguluyoruz:

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

İşlemin sonucu:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
Metinlere veya şekillerine 3D efektlerin uygulanması ve efektler arasındaki etkileşimler belirli kurallara dayanır.  
Metin ve onu içeren şekil için bir sahne düşünün. 3D efekt, 3D nesne temsili ve nesnenin yerleştirildiği sahneyi içerir.  

- Şekil ve metin için sahne her ikisi için de ayarlandığında, şekil sahnesi daha yüksek öncelik alır—metin sahnesi yok sayılır.  
- Şeklin kendi sahnesi yok fakat 3D temsili varsa, metin sahnesi kullanılır.  
- Aksi takdirde—şeklin başta 3D efekti olmadığında—şekil düz olur ve 3D efekt yalnızca metne uygulanır.  

Açıklamalar, [ThreeDFormat.LightRig](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/) ve [ThreeDFormat.Camera](https://reference.aspose.com/slides/tr/python-net/aspose.slides/threedformat/) özelliklerine bağlanmıştır. 
{{% /alert %}} 

## **Metinlere Dış Gölge Efektleri Uygulama**
Aspose.Slides for Python via .NET, TextFrame içinde taşınan bir metne gölge efektleri uygulamanızı sağlayan [**IOuterShadow**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/ioutershadow/) ve [**IInnerShadow**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.effects/iinnershadow/) sınıflarını sunar. Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Slaytın indeksini kullanarak referansını alın.  
3. Slayta Rectangle tipinde bir AutoShape ekleyin.  
4. AutoShape ile ilişkili TextFrame'e erişin.  
5. AutoShape'in FillType'ını NoFill olarak ayarlayın.  
6. OuterShadow sınıfını oluşturun  
7. Gölgenin BlurRadius değerini ayarlayın.  
8. Gölgenin Direction değerini ayarlayın  
9. Gölgenin Distance değerini ayarlayın.  
10. RectanglelAlign'i TopLeft olarak ayarlayın.  
11. Gölgenin PresetColor'ını Black olarak ayarlayın.  
12. Sunumu PPTX dosyası olarak kaydedin.  

Python'da bu örnek kod—yukarıdaki adımların bir uygulaması—metne dış gölge efektini nasıl uygulayacağınızı gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # Slaytın referansını al
    sld = pres.slides[0]

    # Dikdörtgen tipinde bir AutoShape ekle
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # Dikdörtgene TextFrame ekle
    ashp.add_text_frame("Aspose TextBox")

    # Metnin gölgesini alabilmek için şekil dolgusunu devre dışı bırak
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Dış gölge ekle ve tüm gerekli parametreleri ayarla
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    # Sunumu diske kaydet
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Şekillere İç Gölge Efekti Uygulama**
Aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Slaytın bir referansını alın.  
3. Rectangle tipinde bir AutoShape ekleyin.  
4. InnerShadowEffect'i etkinleştirin.  
5. Gerekli tüm parametreleri ayarlayın.  
6. ColorType'ı Scheme olarak ayarlayın.  
7. Scheme rengini ayarlayın.  
8. Sunumu bir [PPTX](https://docs.fileformat.com/presentation/pptx/) dosyası olarak kaydedin.  

Bu örnek kod (yukarıdaki adımlara dayalı) iki şekil arasında bir bağlayıcı eklemeyi Python'da nasıl yapacağınızı gösterir:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # Bir slaytın referansını al
    slide = presentation.slides[0]

    # Dikdörtgen tipinde bir AutoShape ekle
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # Dikdörtgene TextFrame ekle
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # Enable inner_shadow_effect    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # Gerekli tüm parametreleri ayarla
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # ColorType'ı Scheme olarak ayarla
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Scheme rengini ayarla
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # Sunumu kaydet
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SSS**

**Farklı yazı tipleri veya betikler (ör. Arapça, Çince) ile WordArt efektleri kullanabilir miyim?**  
Evet, Aspose.Slides Unicode'ı destekler ve tüm büyük yazı tipleri ve betiklerle çalışır. Gölge, doldurma ve kenarlık gibi WordArt efektleri dil fark etmeksizin uygulanabilir; ancak yazı tipi erişilebilirliği ve renderleme sistem yazı tiplerine bağlı olabilir.

**Slide master öğelerine WordArt efektleri uygulayabilir miyim?**  
Evet, başlık yer tutucuları, altbilgiler veya arka plan metni gibi master slaytlardaki şekillere WordArt efektleri uygulayabilirsiniz. Master düzeninde yapılan değişiklikler tüm ilişkili slaytlara yansıtılır.

**WordArt efektleri sunum dosyasının boyutunu etkiler mi?**  
Biraz. Gölge, parıltı ve gradient doldurmalar gibi WordArt efektleri ek biçimlendirme meta verileri nedeniyle dosya boyutunu hafifçe artırabilir, ancak fark genellikle önemsizdir.

**Sunumu kaydetmeden WordArt efektlerinin sonucunu önizleyebilir miyim?**  
Evet, WordArt içeren slaytları [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) veya [Slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/) sınıflarının `get_image` yöntemiyle PNG, JPEG gibi görüntülere render edebilirsiniz. Bu, tam sunumu kaydetmeden veya dışa aktarmadan önce sonucu bellekte veya ekranda önizlemenizi sağlar.