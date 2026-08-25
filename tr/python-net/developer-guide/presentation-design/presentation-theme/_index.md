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
description: "Aspose.Slides for Python via .NET ile tutarlı marka kimliğiyle PowerPoint dosyaları oluşturmak, özelleştirmek ve dönüştürmek için ana sunum temalarını yönetin."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, doldurmalar, çizgiler ve efektlerden oluşan koordineli bir set tanımlar. Tema farkındalığına sahip nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımları referans alır, böylece bir tema değişikliği bir seferde birçok nesneyi güncelleyebilir.

Aspose.Slides'te, sunum düzeyindeki tema, [Presentation.master_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/master_theme/) özelliğiyle kullanılabilir. Bir sunum ayrıca alt seviyelerde tema geçersiz kılmaları içerebilir. Bir master, [MasterThemeManager.override_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/masterthememanager/override_theme/) aracılığıyla sunum temasını geçersiz kılabilir, bir düzen, [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) aracılığıyla kalıtılan temasını geçersiz kılabilir ve bireysel bir slayt da aynı şeyi yapabilir. Pratikte, bir slayt için etkili tema, şu kalıtım zinciri üzerinden çözülür: sunum teması, master geçersiz kılma, düzen geçersiz kılma ve slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/) nesnesi, temanın [color_scheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/font_scheme/) ve [format_scheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/format_scheme/) özelliklerini ortaya çıkarır. Bu koleksiyonları değiştirmeden önce incelemek, sunum dış bir kaynaktan geldiğinde stil girişlerinin sayısı ve içeriği değişebileceği için özellikle faydalıdır.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç adet arka plan, doldurma, çizgi ve efekt stilinin depolandığını raporlar:

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

Bir dosya birden çok master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsamamalısınız. Slaytla ilişkili masterı inceleyin ve düzen ya da slayt geçersiz kılmaları mevcut olduğunda bu makalenin ilerleyen kısmında gösterilen etkili tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema farkındalığına sahip doldurmalar, çizgiler ve metin, [SchemeColor](https://reference.aspose.com/slides/tr/python-net/aspose.slides/schemecolor/) enum'undan mantıksal bir renge başvurabilir. Tema'nın [ColorScheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/colorscheme/) içindeki ilgili girdiyi değiştirdiğinizde, hâlâ o tema rengini referans eden tüm nesneler yeni değere göre çözümlenir. Doğrudan bir RGB rengi kullanan nesneler, tema rengi güncellemesinden etkilenmez.

Aşağıdaki uçtan uca örnek, `ACCENT4` kullanan bir şekil oluşturur, temanın `accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili doldurma rengini yazdırır:

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

Dikdörtgen `ACCENT4` ile bağlı kaldığı için tema değiştirildiğinde görünen rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renkle değiştirirseniz, sonraki `accent4` değişiklikleri artık o doldurmayı etkilemez.

### **Ek Paletten Renkleri Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar türetmek için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/colortransformoperation/) enum'ı aracılığıyla sunar.

![Ana tema renkleri ve ek paletten oluşturulan daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** - Ana tema renkleri.

**2** - Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `ACCENT4` temelinde altı dikdörtgen oluşturur, beşine parlaklık dönüşümleri uygular ve sonucu kaydeder:

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

Bu varyantlar tema rengine dayanır. `accent4` daha sonra değişirse, dönüştürülmüş renkler yeni `accent4` değerinden yeniden hesaplanır.

### **`SchemeColor` Değerlerini `ColorScheme` Yuvalarına Haritalama**

[SchemeColor](https://reference.aspose.com/slides/tr/python-net/aspose.slides/schemecolor/) enum'ı `TEXT1`, `BACKGROUND1`, `TEXT2` ve `BACKGROUND2` kullanırken, [ColorScheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/colorscheme/) aynı tema yuvalarını `dark1`, `light1`, `dark2` ve `light2` olarak ortaya koyar. Eşleme sabittir:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için ana bir yazı tipi seti ve gövde metni için ikincil bir yazı tipi seti içerir. [FontScheme.major](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/fontscheme/major/) ve [FontScheme.minor](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/fontscheme/minor/) özellikleri bu setleri ortaya çıkarır.

PowerPoint uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

* `+mn-lt` - Gövde Yazı Tipi Latin (Küçük Latin Yazı Tipi)
* `+mj-lt` - Başlık Yazı Tipi Latin (Büyük Latin Yazı Tipi)
* `+mn-ea` - Gövde Yazı Tipi Doğu Asya (Küçük Doğu Asya Yazı Tipi)
* `+mj-ea` - Başlık Yazı Tipi Doğu Asya (Büyük Doğu Asya Yazı Tipi)

Aşağıdaki örnek, ana Latin tema yazı tipini kullanan bir başlık ve ikincil Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

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

Başlık ana yazı tipini, gövde metni ise ikincil yazı tipini izler. Tema kimliği yerine doğrudan bir yazı tipi adı kullanılmış bir metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

Ana ve ikincil yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşleştirmeleri içerebilir. Bu eşleştirmeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Script-Specific Theme Fonts](/slides/tr/python-net/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="Tip" %}}
Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/python-net/powerpoint-fonts/) sayfasına bakabilirsiniz.
{{% /alert %}}

## **Tema Kopyalama veya Uygulama**

İki yaygın iş akışı vardır ve farklı sorunları çözerler.

### **Kaynak Temayı Slaytları Taşırken Korumak**

Bir slaytı başka bir sunuma taşımak ve orijinal tasarımını korumak istiyorsanız, kaynak masterı [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/add_clone/) ile hedef sunuma klonlayın, ardından [SlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) ve klonlanmış master ile slaytı klonlayın. Bu, master, düzenleri ve ilişkili temayı birlikte taşır.

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

Bu, kaynak slaytın hedefte aynı şekilde görünmesi gerektiğinde tercih edilen iş akışıdır. İçeriği alakasız bir hedef master üzerine klonlamak, tema odaklı renkleri, yazı tiplerini, arka planları ve efektleri değiştirebilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygulama**

Hedef slayt mevcut master ve düzeninde kalmalıysa, kaynak temadan bir slayt düzeyi geçersiz kılma başlatın. [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) ve [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) yöntemleri üç ana tema bileşenini geçersiz kılamaya kopyalar.

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

Bu, diğer slaytların kalıtıldığı temayı değiştirmeden o slaytın kullandığı temayı değiştirir. Yerel geçersiz kılmayı kaldırmak ve kalıtılan değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/clear/) yöntemini çağırın.

### **Bir Düzene Tema Geçersiz Kılmasını Uygulama**

Düzen düzeyinde bir geçersiz kılma, o düzeni kullanan slaytlara uygulanır; yalnızca belirli bir slayt kendi geçersiz kılamasını yapmadıysa. Aynı başlatma yöntemleri, düzenin [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/layoutslidethememanager/) aracılığıyla kullanılabilir:

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

Birçok düzen ve slayt aynı temel tasarımı paylaşmalıysa master veya sunum düzeyinde tema kullanın, bir düzen ailesi farklı stil gerektiriyorsa düzen geçersiz kılması ve yalnızca gerçek istisnalar için slayt geçersiz kılması kullanın. Aşırı slayt düzeyi geçersiz kılmalar, daha sonraki global tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan doldurmaları, [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) içinde depolanır. PowerPoint, UI'da temanın doldurmalarını tema renkleri ve diğer stil referanslarıyla birleştirerek, bu koleksiyonda fiziksel olarak depolanan doldurma tanımlarından daha fazla arka plan seçeneği sunabilir.

![PowerPoint arka plan stil galerisinin bir sunum teması için gösterimi](presentation-design_8.png)

Bir arka plan stili kullanmadan önce, depolanmış koleksiyonu ve mevcut [Background.style_index](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/style_index/) değerini inceleyin. `style_index` temalı doldurma yoksa `0` kullanır; pozitif değerler tema arka plan stil referanslarıdır. Bu, Python koleksiyonunu doğrudan indekslemede `[0]` ilk öğeyi gösterir anlamından farklıdır. Her sunumun aynı sayıda arka plan doldurma stiline sahip olduğunu varsamamalısınız.

Aşağıdaki örnek, kullanılabilir arka plan doldurma sayısını raporlar, ilk mastera temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, master tarafından referans edilen tema girdisine ve düzen ya da slayt düzeyindeki herhangi bir arka plan geçersiz kılmasına bağlıdır. Sadece master arka planını değiştirirseniz, kendi arka planını kullanan bir slayt etkilenmeyebilir. Kalıtım uygulandıktan sonra nihai arka planı öğrenmek için [Background.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/get_effective/) kullanın.

{{% alert color="warning" title="Uyarı" %}}
`style_index` değerini sıfır tabanlı bir koleksiyon indeksi olarak ele almayın. Ayrıca bir dosyadan sabit bir stil numarası kodlayıp başka bir dosyada aynı görünüme sahip olduğunu varsamaktan kaçının; tema stil tanımları sunuma özeldir.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Presentation Background](/slides/tr/python-net/presentation-background/) sayfasına bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema format şeması, ayrı ayrı [FormatScheme.fill_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/line_styles/) ve [FormatScheme.effect_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/effect_styles/) koleksiyonları içerir. Tipik Office temaları, görsel olarak ince, orta ve yoğun biçimlendirmelere karşılık gelen üç temel stil girdisi içerir, ancak kod her koleksiyonu incelemeli, sabit bir sayı varsaymamalıdır.

![Aynı şekle uygulanan ince, orta ve yoğun tema efektleri](presentation-design_10.png)

Python'da bu koleksiyonlara eriştiğinizde, koleksiyon indeksi sıfır tabanlıdır: `[0]` ilk depolanmış stil, `[2]` üçüncü stildir. Bir şeklin stil referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ishapestyle/) aracılığıyla ortaya çıkar. Bir tema stilini değiştirmek, o tema stilini referans eden şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girişlerinin varlığını kontrol eder, ilk çizgi stilini değiştirir, üçüncü doldurma stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

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

Bu yuvalara referans veren şekillerde, ilk tema çizgi stili kırmızı, üçüncü tema doldurma stili katı orman yeşili ve üçüncü efekt stili 10 puan uzaklıkta bir dış gölge kazanır. Kesin görsel sonuç, her şeklin hangi stil yuvasına referans verdiğine ve doğrudan biçimlendirmenin temayı geçersiz kılıp kılmadığına bağlıdır.

![Çizgi, doldurma ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri, belirli bir seviyede neyin tanımlandığını gösterir. Etkili değerler, kalıtım ve yerel geçersiz kılmalar çözüldükten sonra bir slayt veya şeklin gerçekte ne kullandığını söyler. Bir slayt için [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) çağırın. Bir arka plan için [Background.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/get_effective/) ve bir doldurma için [FillFormat.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/get_effective/) kullanın.

Aşağıdaki örnek, bir slayttan etkili temayı, arka planı ve ilk şekil doldurmasını okur:

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

Render tanılamaları, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation.master_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/master_theme/) incelerseniz, final görünümeyi değiştiren bir master, düzen, slayt veya şekil geçersiz kılmasını kaçırabilirsiniz.

## **SSS**

**Bir temayı master'ı değiştirmeden tek bir slayta uygulayabilir miyim?**  
Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/slidethememanager/) kullanın ve geçersiz tema başlatın. Değişiklik yalnızca o slayta uygulanır; diğer slaytlar mevcut temalarını kalıtım yoluyla almaya devam eder.

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**  
Slaytı taşırken ve kaynak görünümünü korurken, kaynak masterı hedefteki master koleksiyonuna [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/add_clone/) ile klonlayın ve ardından slaytı aynı master ile [SlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) kullanarak klonlayın. Bu, master, düzenler ve temayı birlikte tutar.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**  
Bir slayt veya düzen teması için [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) yöntemini, format nesneleri için (ör. [Background.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/get_effective/) ve [FillFormat.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/get_effective/)) ilgili etkili‑veri yöntemlerini kullanın. Bu API'ler, kalıtım ve geçersiz kılmalar uygulandıktan sonra çözümlenmiş değerleri döndürür.