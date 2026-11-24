---
title: Python'da PowerPoint Sunum Temalarını Yönetme
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/python-net/presentation-theme/
keywords:
- PowerPoint teması
- sunum teması
- slayt teması
- tema ayarla
- tema değiştir
- tema yönet
- harici tema
- THMX
- tema rengi
- ek palet
- tema yazı tipi
- tema stili
- tema efekti
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint dosyalarını tutarlı marka kimliğiyle oluşturmak, özelleştirmek ve dönüştürmek için ana sunum temalarını yönetin."
---
## **Giriş**

Bir sunum teması, koordineli bir renk, yazı tipi, arka plan stili, dolgu, çizgi ve efekt kümesi tanımlar. Tema‑bilinçli nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur; bu sayede bir tema değişikliği bir kerede birçok nesneyi güncelleyebilir.

Aspose.Slides içinde, sunum düzeyindeki tema, [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) özelliği aracılığıyla kullanılabilir. Bir sunum ayrıca daha alt seviyelerde tema geçersiz kılmaları içerebilir. Bir master, temayı [MasterThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/masterthememanager/override_theme/) üzerinden geçersiz kılabilir, bir düzen, miras aldığı temayı [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) ile geçersiz kılabilir ve bireysel bir slayt da aynı şeyi yapabilir. Pratikte, bir slayt için etkili tema, şu kalıtım zinciri üzerinden çözülür: sunum teması, master geçersiz kılması, düzen geçersiz kılması ve slayt geçersiz kılması.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler, en yaygın tema iş akışlarını gösterir: bir temayı incelemek, renk ve yazı tiplerini değiştirmek, bir temayı kopyalamak veya uygulamak, arka plan ve efekt stillerini güncellemek ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okumak.

## **Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/) nesnesi, temanın [color_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/font_scheme/) ve [format_scheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/mastertheme/format_scheme/) özelliklerini ortaya çıkarır. Bu koleksiyonları değiştirmeden önce incelemek, sunum dış bir kaynaktan geldiğinde stil girdilerinin sayısı ve içeriği değişebileceği için özellikle faydalıdır.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç adet arka plan, dolgu, çizgi ve efekt stilinin depolandığını rapor eder:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    theme = presentation.master_theme

    print(f"Theme name: {theme.name}")
    print(f"Accent 1: {theme.color_scheme.accent1.color}")
    print(f"Major Latin font: {theme.font_scheme.major.latin_font.font_name}")
    print(f"Minor Latin font: {theme.font_scheme.minor.latin_font.font_name}")
    print(f"Background fill styles: {len(theme.format_scheme.background_fill_styles)}")
    print(f"Fill styles: {len(theme.format_scheme.fill_styles)}")
    print(f"Line styles: {len(theme.format_scheme.line_styles)}")
    print(f"Effect styles: {len(theme.format_scheme.effect_styles)}")
```

Bir dosya birden fazla master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slayt ile ilişkili masterı inceleyin ve düzen veya slayt geçersiz kılmaları olabileceğinde makalenin ilerleyen kısmında gösterilen etkili tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema‑bilinçli dolgular, çizgiler ve metinler, [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) numaralandırmasından mantıksal bir renge başvurabilir. Temanın [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) içindeki ilgili girdiyi değiştirdiğinizde, o tema rengine hâlen başvuran tüm nesneler yeni değere göre çözümlenir. Doğrudan RGB rengi kullanan nesneler, tema‑rengi güncellemesinden etkilenmez.

Aşağıdaki uçtan uca örnek, `ACCENT4` kullanan bir şekil oluşturur, temanın `accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili dolgu rengini yazdırır:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    presentation.master_theme.color_scheme.accent4.color = draw.Color.red

    presentation.save("theme-color.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("theme-color.pptx") as saved_presentation:
    saved_slide = saved_presentation.slides[0]
    saved_shape = saved_slide.shapes[0]
    effective_fill = saved_shape.fill_format.get_effective()
    print(f"Effective fill color: {effective_fill.solid_fill_color}")
```

Dikdörtgen `ACCENT4` ile bağlantılı kaldığı için tema değiştirildiğinde görünür rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renk ile değiştirirseniz, `accent4` üzerindeki sonraki değişiklikler artık bu dolguyu etkilemez.

### **Ek Paletten Renkleri Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantları renk dönüşümleri uygulayarak türetir. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/python-net/aspose.slides/colortransformoperation/) numaralandırması aracılığıyla ortaya çıkarır.

![Ana tema renkleri ve ek paletten oluşturulan daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** - Ana tema renkleri.

**2** - Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `ACCENT4` temelli altı dikdörtgen oluşturur, beşine parlaklık dönüşümleri uygular ve sonucu kaydeder:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)
    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)
    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)
    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)
    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)
    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)
    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("theme-color-palette.pptx", slides.export.SaveFormat.PPTX)
```

Bu varyantlar tema rengine dayalı kalır. `accent4` daha sonra değişirse, dönüştürülmüş renkler yeni `accent4` değerinden yeniden hesaplanır.

### **`SchemeColor` Değerlerini `ColorScheme` Yuvalarına Eşleme**

[SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) numaralandırması `TEXT1`, `BACKGROUND1`, `TEXT2` ve `BACKGROUND2` değerlerini kullanırken, [ColorScheme](https://reference.aspose.com/slides/python-net/aspose.slides.theme/colorscheme/) aynı tema yuvalarını `dark1`, `light1`, `dark2` ve `light2` olarak ortaya çıkarır. Eşleme sabittir:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Bunlar aynı tema yuvaları için alternatif adlardır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için bir ana yazı tipi kümesi ve gövde metni için bir yan (minor) yazı tipi kümesi içerir. [FontScheme.major](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/major/) ve [FontScheme.minor](https://reference.aspose.com/slides/python-net/aspose.slides.theme/fontscheme/minor/) özellikleri bu kümeleri ortaya çıkarır.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları, metin biçimlendirmesinde şu şekilde kullanılabilir:

* `+mn-lt` - Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj-lt` - Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn-ea` - Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj-ea` - Başlık Yazı Tipi Doğu Asya (Major East Asian Font)
* `+mn-cs` - Gövde Yazı Tipi Karmaşık Betik (Minor Complex Script Font)
* `+mj-cs` - Başlık Yazı Tipi Karmaşık Betik (Major Complex Script Font)

Aşağıdaki örnek, ana Latin tema yazı tipini kullanan bir başlık ve yan Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 500, 60)
    heading.text_frame.text = "Theme heading"
    heading.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mj-lt")

    body = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 120, 500, 60)
    body.text_frame.text = "Theme body text"
    body.text_frame.paragraphs[0].portions[0].portion_format.latin_font = slides.FontData("+mn-lt")

    presentation.master_theme.font_scheme.major.latin_font = slides.FontData("Aptos Display")
    presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")

    presentation.save("theme-fonts.pptx", slides.export.SaveFormat.PPTX)
```

Başlık ana yazı tipini, gövde metni ise yan yazı tipini izler. Tema tanımlayıcısı yerine açık bir yazı tipi adı belirten metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

Ana ve yan yazı tipi koleksiyonları, Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemelerini de içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script-Specific Theme Fonts](/slides/tr/python-net/script-specific-font-mappings/) sayfasına bakın.

{{% alert color="info" title="Tip" %}}
Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/python-net/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

### **Tema Yazı Tipi Referanslarını Çözme**

Metni incelerken, [FontData.font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/font_name/) bir yazı tipi ailesi adı yerine `+mn-lt` gibi bir tema referansı içerebilir. Bu referansı çözmek için uygun [IThemeEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides.theme/ithemeeffectivedata/) ile [FontData.get_font_name](https://reference.aspose.com/slides/python-net/aspose.slides/fontdata/get_font_name/) çağırın. `+mj` ve `+mn` ön ekleri ana ve yan yazı tipi setlerini seçer; `-lt`, `-ea` ve `-cs` ekleri sırasıyla Latin, Doğu Asya ve Karmaşık Betik yazı tiplerini seçer.

İncelenen metne temasını uygulayan nesne üzerinde [Slide.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides/slide/create_theme_effective/) aracılığıyla etkili temayı elde edin. Bir slayttaki sıradan metin için, bağlamın slaydın miras aldığı teması ve yerel geçersiz kılmaları içermesi için `slide.create_theme_effective` kullanın. Bir düzeni veya masterı incelerken, kendi etkili temasını kullanın. İlk masterın temasının her slayta uygulandığını varsaymayın.

Aşağıdaki örnek, yan Latin yazı tipine açıkça başvuran bir metin bölümü oluşturur. [OverrideTheme.init_font_scheme_from_inherited](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from_inherited/) aracılığıyla bir slayt yazı tipi şeması başlatır ve ana ve yan Latin ailelerini `Arial` ve `Calibri` olarak ayarlar; böylece sonuç giriş dosyası olmadan tekrar üretilebilir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    theme = slide.theme_manager.override_theme
    theme.init_font_scheme_from_inherited()
    theme.font_scheme.major.latin_font = slides.FontData("Arial")
    theme.font_scheme.minor.latin_font = slides.FontData("Calibri")

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Text using the minor theme font"

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.latin_font = slides.FontData("+mn-lt")

    font = portion.portion_format.latin_font
    effective_theme = slide.create_theme_effective()
    print(f"{font.font_name} -> {font.get_font_name(effective_theme)}")

    explicit_font = slides.FontData("Verdana")
    print(f"{explicit_font.font_name} -> {explicit_font.get_font_name(effective_theme)}")
```

Çıktı, `+mn-lt -> Calibri` ardından `Verdana -> Verdana` şeklindedir. Depolanan referans değişmeden kalır, açık bir aile adı olduğu gibi döndürülür. Bölüm `+mj-lt` kullansaydı, bu temada `Arial` olarak çözülürdü.

Bir tema referansını çözmek, tema tarafından belirtilen yazı tipi ailesini tanımlar. Yazı tipinin kullanılabilirliğini kontrol etmez veya render sırasında ikame veya glif geri dönüşümünden sonra nihai olarak kullanılan yazı tipi dosyasını belirlemez. Bu ayrı adımlar için [Font Selection Sequence](/slides/tr/python-net/font-selection-sequence/) ve [Font Substitution](/slides/tr/python-net/font-substitution/) sayfalarına bakın.

## **Tema Kopyalama veya Uygulama**

Aşağıdaki iş akışları, farklı tema ile ilgili sorunları çözer.

### **Harici Bir Temayı Bir Master'ın Bağımlı Slaytlarına Uygulama**

[MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) yöntemini, bir PowerPoint tema dosyanız (`.thmx`) olduğunda ve belirli bir master'a bağlı tüm slaytların stilini değiştirmek istediğinizde kullanın. Master'ı [Presentation.masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) koleksiyonundan ([MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/)) seçin ve tema dosyası yolunu metoda iletin.

Yöntem aşağıdaki işlemleri gerçekleştirir:

1. Seçilen master temel alınarak yeni bir master slayt oluşturur.
2. Harici temayı yeni mastera uygular.
3. Yeni masterı daha önce seçilen mastera bağlı olan tüm slaytlara atar.
4. Yeni oluşturulan [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) nesnesini döndürür.

Aşağıdaki örnek, ilk mastera bağımlı slaytlara harici bir tema uygular ve sunumu kaydeder:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]

    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")
    print(f"Created master: {themed_master.name}")

    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Geçersiz, bozuk veya desteklenmeyen bir tema, [PptxException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxexception/) veya onun format‑ile ilgili bir alt sınıfına neden olabilir. Kullanıcıların sağladığı yolları doğrulayın, dosya sistemi erişim hatalarını yönetin ve temayı başarıyla uyguladıktan sonra sunumu kaydedin.

Yalnızca seçilen mastera bağımlı slaytlar yeniden atanır. Diğer masterlarla ilişkili slaytlar mevcut master ve temalarını korur. Tema‑bilinçli renkler, yazı tipleri, dolgular, çizgiler, arka planlar ve efektler harici temaya göre çözülür. Doğrudan atanmış renkler, yazı tipleri, dolgular ve diğer açık biçimlendirmeler değişmeden kalabilir. Düzen‑seviyesi ve slayt‑seviyesi geçersiz kılmalar da yeni masterdan miras alınan değerlere üstünlük sağlayabilir.

Tema, çalışma zamanı ortamında bulunmayan yazı tiplerine başvurabilir. Tutarlı render ve dışa aktarma için gereken yazı tiplerini kurun, onları [custom font sources](/slides/tr/python-net/custom-font/) aracılığıyla sağlayın veya [font substitution](/slides/tr/python-net/font-substitution/) yapılandırın.

Bu, doğrudan master‑seviyesi bir iş akışıdır: yöntem bir `.thmx` dosya yolunu kabul eder ve slayt‑seviyesi veya düzen‑seviyesi tema geçersiz kılmaları manuel olarak oluşturmayı gerektirmez.

### **Çok‑Masterli Sunumda Farklı Harici Temalar Uygulama**

İlgili master önceden bilinmiyorsa, onu temsilci bir slayttan [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) ve [LayoutSlide.master_slide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/master_slide/) aracılığıyla elde edin. Tema uygulamadan önce orijinal master referanslarını saklayın; çünkü her çağrı sunumda yeni bir master oluşturur.

Aşağıdaki örnek, iki bölümden slaytları kullanarak masterlarını bulur ve her gruba farklı bir harici tema uygular:

```python
import aspose.slides as slides

with slides.Presentation("multi-master-presentation.pptx") as presentation:
    if len(presentation.slides) < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.slides[0].layout_slide.master_slide
        second_group_master = presentation.slides[4].layout_slide.master_slide

        if first_group_master.slide_id == second_group_master.slide_id:
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.apply_external_theme_to_depending_slides("blue-theme.thmx")
            second_themed_master = second_group_master.apply_external_theme_to_depending_slides("green-theme.thmx")

            print(f"First themed master: {first_themed_master.name}")
            print(f"Second themed master: {second_themed_master.name}")

            presentation.save("multi-master-with-external-themes.pptx", slides.export.SaveFormat.PPTX)
```

İlk çağrı yalnızca `first_group_master`a bağımlı slaytları etkiler, ikinci çağrı ise yalnızca `second_group_master`a bağımlı slaytları etkiler. Diğer masterlara ait slaytların stili değiştirilmez.

### **Slaytları Taşırken Kaynak Temasını Korumak**

Bir slaytı başka bir sunuma taşımak ve özgün tasarımını korumak istiyorsanız, kaynak masterı hedef sunuma [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) ile klonlayın, ardından slaytı [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) ve klonlanmış master ile klonlayın. Bu, masterı, düzenlerini ve ilişkili temayı birlikte taşır.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        source_slide = source.slides[0]

        source_master = source_slide.layout_slide.master_slide
        cloned_master = target.masters.add_clone(source_master)
        target.slides.add_clone(source_slide, cloned_master, True)

        target.save("theme-preserved.pptx", slides.export.SaveFormat.PPTX)
```

Bu, kaynak slaytın hedefte aynı görünmesi gerektiğinde tercih edilen iş akışıdır. İçeriği ilgisiz bir hedef mastera klonlamak, tema‑tabanlı renkleri, yazı tiplerini, arka planları ve efektleri değiştirebilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygulama**

Hedef slayt mevcut master ve düzeninde kalacaksa, kaynak temadan bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) ve [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) yöntemleri üç ana tema bileşenini geçersiz kılmaya kopyalar.

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]

        override_theme = target_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)

        target.save("theme-applied-to-slide.pptx", slides.export.SaveFormat.PPTX)
```

Bu, o slaytın kullandığı temayı diğer slaytların miras aldığı temayı değiştirmeden değiştirir. Yerel geçersiz kılmayı kaldırmak ve miras alınan değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/python-net/aspose.slides.theme/overridetheme/clear/) çağırın.

### **Bir Düzeni Tema Geçersiz Kılmasıyla Uygulama**

Düzen‑seviyesi bir geçersiz kılma, o düzeni kullanan slaytlara uygulanır; belirli bir slaytın kendi geçersiz kılması varsa bu durum değişir. Aynı başlatma yöntemleri, düzenin [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/layoutslidethememanager/) aracılığıyla kullanılabilir:

```python
import aspose.slides as slides

with slides.Presentation("source-theme.pptx") as source:
    with slides.Presentation("target.pptx") as target:
        target_slide = target.slides[0]
        
        override_theme = target_slide.layout_slide.theme_manager.override_theme
        override_theme.init_color_scheme_from(source.master_theme.color_scheme)
        override_theme.init_font_scheme_from(source.master_theme.font_scheme)
        override_theme.init_format_scheme_from(source.master_theme.format_scheme)

        target.save("theme-applied-to-layout.pptx", slides.export.SaveFormat.PPTX)
```

Birçok düzen ve slaytın aynı temel tasarımı paylaşması gerektiğinde master veya sunum‑seviyesi tema kullanın; bir düzen ailesinin farklı stil ihtiyacı olduğunda düzen geçersiz kılmasını, yalnızca gerçek istisnalar için slayt geçersiz kılmasını kullanın. Aşırı slayt‑seviyesi geçersiz kılmalar, sonraki genel tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan dolguları, [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) içinde depolanır. PowerPoint, UI'da bu koleksiyonda fiziksel olarak depolanan dolgu tanımlarının sayısından daha fazla arka plan seçeneği sunabilir; çünkü UI tema dolgularını tema renkleri ve diğer stil referanslarıyla birleştirebilir.

![Sunum teması için PowerPoint arka plan stil galerisii](presentation-design_8.png)

Bir arka plan stili kullanmadan önce, depolanmış koleksiyonu ve mevcut [Background.style_index](https://reference.aspose.com/slides/python-net/aspose.slides/background/style_index/) değerini inceleyin. `style_index`, temalı dolgu yoksa `0` kullanır; pozitif değerler tema arka plan‑stil referanslarıdır. Bu, Python koleksiyonuna doğrudan indeksleme yaparken `[0]` ilk depolanmış öğeyi ifade etmesinden farklıdır. Her sunumun aynı sayıda arka plan dolgu stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek, kullanılabilir arka plan dolgu sayısını rapor eder, ilk mastera temalı bir arka plan referansı atar ve sunumu kaydeder:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:

    background_styles = presentation.master_theme.format_scheme.background_fill_styles
    print(f"Background fill styles: {len(background_styles)}")

    if len(background_styles) == 0:
        raise RuntimeError("The presentation theme does not contain background fill styles.")

    master_slide = presentation.masters[0]
    master_slide.background.type = slides.BackgroundType.THEMED
    master_slide.background.style_index = 1

    presentation.save("theme-background.pptx", slides.export.SaveFormat.PPTX)
```

Görünür sonuç, master tarafından referans verilen tema girişine ve düzen veya slayt seviyesindeki arka plan geçersiz kılmalarına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemeyebilir. Kalıtım uygulandıktan sonra nihai arka planı öğrenmek için [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) kullanın.

{{% alert color="warning" title="Warning" %}}
`style_index`'i sıfır‑tabanlı bir koleksiyon indeksi gibi işlemeyin. Ayrıca bir dosyadan stil numarasını sabit kodlamaktan ve başka bir dosyada aynı görünümde olacağını varsaymaktan kaçının; tema stil tanımları sunuma özgüdür.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Presentation Background](/slides/tr/python-net/presentation-background/) sayfasına bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema biçim şeması, ayrı ayrı [FormatScheme.fill_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/line_styles/) ve [FormatScheme.effect_styles](https://reference.aspose.com/slides/python-net/aspose.slides.theme/formatscheme/effect_styles/) koleksiyonlarını içerir. Tipik Office temaları genellikle görsel olarak hafif, orta ve yoğun biçimlendirmeye karşılık gelen üç ana stil girişi içerir, ancak kod sabit bir sayı varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanan hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

Python'da bu koleksiyonlara eriştiğinizde, koleksiyon indeksi sıfır‑tabanlıdır: `[0]` ilk depolanmış stil, `[2]` üçüncüdür. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [ShapeStyle](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/) aracılığıyla ortaya çıkar. Bir tema stilini değiştirmek, o tema stiline başvuran şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girişlerinin mevcut olduğunu kontrol eder, ilk çizgi stilini değiştirir, üçüncü dolgu stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Subtle_Moderate_Intense.pptx") as presentation:
    format_scheme = presentation.master_theme.format_scheme
    if len(format_scheme.line_styles) < 1 or len(format_scheme.fill_styles) < 3 or len(format_scheme.effect_styles) < 3:
        raise RuntimeError("The theme does not contain the style entries required by this example.")

    format_scheme.line_styles[0].fill_format.fill_type = slides.FillType.SOLID
    format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    format_scheme.effect_styles[2].effect_format.enable_outer_shadow_effect()
    format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("theme-effects.pptx", slides.export.SaveFormat.PPTX)
```

Bu yuvalara başvuran şekiller için, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili ve üçüncü efekt stili 10 puan mesafeli bir dış gölge kazanır. Tam görsel sonuç, her şeklin hangi stil yuvalarına başvurduğuna ve doğrudan biçimlendirme temayı geçersiz kılıyor mu olduğuna bağlıdır.

![Çizgi, dolgu ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Bir Şekil İçin Tema Dolgu ve Çizgi Stillerini Seçme**

Bir şekil, [ShapeStyle.fill_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/fill_style_index/) ve [ShapeStyle.line_style_index](https://reference.aspose.com/slides/python-net/aspose.slides/shapestyle/line_style_index/) aracılığıyla dolgu ve dış hatlarını bağımsız olarak seçebilir. Her iki özellik için, indeks `1` karşılık gelen tema koleksiyonundaki ilk girdiyi (`fill_styles[0]` veya `line_styles[0]`) seçer, indeks `2` ikinci girdiyi seçer.

Aşağıdaki örnek, yeni bir sunumun varsayılan temasında iki dolgu (altın ve gökyüzü mavisi) ve iki dış hat (6 pt'de koyu mavi ve 12 pt'de koyu kırmızı) tanımlar. Sonuçları PowerPoint'te karşılaştırabilmeniz için slaytı üç aşamada kaydeder.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    styles = presentation.master_theme.format_scheme

    gold_fill = styles.fill_styles[0]
    gold_fill.fill_type = slides.FillType.SOLID
    gold_fill.solid_fill_color.preset_color = slides.PresetColor.GOLD
    blue_fill = styles.fill_styles[1]
    blue_fill.fill_type = slides.FillType.SOLID
    blue_fill.solid_fill_color.preset_color = slides.PresetColor.SKY_BLUE

    thin_line = styles.line_styles[0]
    thin_line.fill_format.fill_type = slides.FillType.SOLID
    thin_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_BLUE
    thin_line.width = 6
    thick_line = styles.line_styles[1]
    thick_line.fill_format.fill_type = slides.FillType.SOLID
    thick_line.fill_format.solid_fill_color.preset_color = slides.PresetColor.DARK_RED
    thick_line.width = 12

    shapes = presentation.slides[0].shapes
    left = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 205, 200, 130)
    right = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 420, 205, 200, 130)
    left.shape_style.fill_style_index = 1
    right.shape_style.fill_style_index = 2
    left.shape_style.line_style_index = 1
    right.shape_style.line_style_index = 1
    presentation.save("01-initial.pptx", slides.export.SaveFormat.PPTX)

    right.shape_style.line_style_index = 2
    presentation.save("02-line-changed.pptx", slides.export.SaveFormat.PPTX)

    gold_fill.solid_fill_color.preset_color = slides.PresetColor.SEA_GREEN
    presentation.save("03-theme-changed.pptx", slides.export.SaveFormat.PPTX)
```

| İlk stiller | Sağ dış hatı değiştir | İlk tema dolgusunu düzenle |
|:---:|:---:|:---:|
| ![Altın ve gökyüzü mavisi dikdörtgenler, eşleşen ince koyu mavi dış hatlarla](theme-style-initial.png) | ![Gökyüzü mavisi dikdörtgen şimdi kalın koyu kırmızı dış hat var](theme-style-line-changed.png) | ![Sol dikdörtgen şimdi yeşil ve her iki dış hat da değişmedi](theme-style-fill-changed.png) |

Farklı bir çizgi stili seçmek yalnızca sağ dikdörtgenin dış hattını değiştirir. İlk tema dolgusunu düzenlemek, onu kullanan tüm şekilleri günceller. Burada, yalnızca sol dikdörtgen yeşile döner.

Mevcut bir şekil üzerinde, yerel bir dolgu rengi, çizgi rengi veya çizgi genişliği, tema stilinin o bölümünü geçersiz kılabilir. Stil indeksini değiştirmenin görünür bir etkisi yoksa, şeklin [direct formatting](/slides/tr/python-net/shape-formatting/) ayarlarını kontrol edin.

## **Etkili Katı Dolgunun Tema Rengi Kullanıp Kullanmadığını Belirleme**

Bir dolgu, doğrudan bir nesne üzerinde depolanabilir veya paragraftan, düzenden, masterdan, tema stilinden veya başka bir biçimlendirme seviyesinden miras alınabilir. Bu hiyerarşiyi değişmez [IFillFormatEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/) nesnesine çözmek için [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) çağırın. Önce [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/fill_type/) kontrol edin. Yalnızca `FillType.SOLID` olduğunda katı dolgu özelliklerini okuyun.

Katı bir dolgu için, [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) kalıtım, tema araması ve renk dönüşümleri uygulandıktan sonra son işlenmiş RGB değerini döndürür. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) karşılık gelen mantıksal [SchemeColor](https://reference.aspose.com/slides/python-net/aspose.slides/schemecolor/) yuvasını (örneğin `TEXT1` veya `ACCENT6`) döndürür. `SchemeColor.NOT_DEFINED` değeri, etkili katı dolgunun bir şema rengine dayalı olmadığını gösterir. Dolguların tema renkleri veya doğrudan RGB renkleri olduğu bir iş akışında, bu değer doğrudan RGB dolgu olduğunu belirler.

Bir dolguyu sınıflandırmak için yalnızca yerel [ColorFormat.scheme_color](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/scheme_color/) değerini kullanmayın. Örneğin, bir metin bölümü yerel olarak tanımlı bir şema rengine sahip olmayabilir; bu yüzden yerel değeri `NOT_DEFINED` olur, ancak etkili dolgusu bir tema rengini miras alır ve `TEXT1` veya `ACCENT6` olarak çözülür. Öte yandan, `solid_fill_scheme_color` size etkili rengi üreten mantıksal tema yuvasını söyler, ancak bu yavanın nesneden, paragraftan, düzenden, masterdan ya da başka bir biçimlendirme seviyesinden gelip gelmediğini söylemez.

Aşağıdaki örnek bir sunumu yükler, şekil dolgularını ve metin bölümü dolgularını denetler, her birinin son RGB değerini ve ilgili şema rengini yazdırır ve tema renk değişikliklerini takip etmeyecek katı dolguları işaretler:

```python
import aspose.slides as slides


def audit_fill(object_name, local_fill):
    effective_fill = local_fill.get_effective()

    if effective_fill.fill_type != slides.FillType.SOLID:
        print(f"{object_name}: fill type = {effective_fill.fill_type}; not a solid fill.")
        return

    rgb = effective_fill.solid_fill_color
    effective_scheme_color = effective_fill.solid_fill_scheme_color
    local_scheme_color = local_fill.solid_fill_color.scheme_color

    print(f"{object_name}: RGB = #{rgb.r:02X}{rgb.g:02X}{rgb.b:02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")

    if effective_scheme_color == slides.SchemeColor.NOT_DEFINED:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


with slides.Presentation("input.pptx") as presentation:
    for slide_index, slide in enumerate(presentation.slides):
        for shape_index, shape in enumerate(slide.shapes):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.fill_format)

            if isinstance(shape, slides.AutoShape):
                for paragraph_index, paragraph in enumerate(shape.text_frame.paragraphs):
                    for portion_index, portion in enumerate(paragraph.portions):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.portion_format.fill_format)
```

`NOT_DEFINED` dalı, tema renk yuvalarındaki değişikliklere yanıt vermeyecek katı dolguların bir denetim listesini sağlar. Sunumun yeni bir marka paletine uyması gerektiğinde bu nesneleri gözden geçirin. Bildirilen RGB değeri hâlâ mevcut görünümü gösterir, şema değeri ise bu görünümün temayla bağlantılı olup olmadığını açıklar.

Etkili‑format nesneleri anlık görüntülerdir. Sunum temasını, bir tema geçersiz kılmasını veya herhangi bir miras alınan biçimlendirmeyi değiştirdikten sonra, karşılaştırma veya raporlama yapmadan önce `get_effective` tekrar çağırın ve yeni bir `IFillFormatEffectiveData` nesnesi okuyun.

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri, belirli bir seviyede neyin tanımlı olduğunu söyler. Etkili değerler, kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slayt ya da şeklin gerçekte ne kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) çağırın. Bir arka plan için [Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/), bir dolgu için ise [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) kullanın.

Aşağıdaki örnek, bir slayttan etkili temayı, arka planı ve ilk şekil dolgusunu okur:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slide = presentation.slides[0]

    effective_theme = slide.theme_manager.create_theme_effective()
    effective_background = slide.background.get_effective()

    print(f"Effective major Latin font: {effective_theme.font_scheme.major.latin_font.font_name}")
    print(f"Effective minor Latin font: {effective_theme.font_scheme.minor.latin_font.font_name}")
    print(f"Effective background fill type: {effective_background.fill_format.fill_type}")

    if len(slide.shapes) > 0:
        effective_fill = slide.shapes[0].fill_format.get_effective()
        print(f"First shape effective fill type: {effective_fill.fill_type}")
        if effective_fill.fill_type == slides.FillType.SOLID:
            print(f"First shape effective fill color: {effective_fill.solid_fill_color}")
```

Render teşhisleri, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation.master_theme](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/master_theme/) incelemeniz, final görüntüyü değiştiren bir master, düzen, slayt veya şekil geçersiz kılmasını kaçırmanıza neden olabilir.

## **SSS**

**Does applying an external theme affect every slide in the presentation?**  
Hayır. [MasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/apply_external_theme_to_depending_slides/) yalnızca seçilen mastera bağımlı slaytları yeniden atar. Diğer masterları kullanan slaytlar mevcut temalarını korur.

**Can I apply a theme to a single slide without changing the master?**  
Evet. Slaydın [SlideThemeManager](https://reference.aspose.com/slides/python-net/aspose.slides.theme/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik sadece o slayda yerel kalır; diğer slaytlar mevcut temalarını miras almaya devam eder.

**What is the safest way to carry a theme from one presentation to another?**  
Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak masterı hedefe klonlayın ve slaytı o master ile [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) ve [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) kullanarak klonlayın. Bu, masterı, düzenleri ve temayı bir arada tutar.

**How can I see the effective values after inheritance and overrides?**  
[BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) yöntemini bir slayt veya düzen temasında ve format nesneleri için ilgili etkili‑veri yöntemlerini ([Background.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/background/get_effective/) ve [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/) gibi) kullanın. Bu API'ler, kalıtım ve geçersiz kılmalar uygulandıktan sonraki çözümlenmiş değerleri döndürür.