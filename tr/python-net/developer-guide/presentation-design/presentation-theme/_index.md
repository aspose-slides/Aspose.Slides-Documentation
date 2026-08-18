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
description: ".NET üzerinden Python için Aspose.Slides'te ana sunum temalarını kullanarak, tutarlı marka kimliğiyle PowerPoint dosyalarını oluşturun, özelleştirin ve dönüştürün."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, dolgu, çizgi ve efektlerden oluşan koordine bir küme tanımlar. Tema farkındalığına sahip nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur, bu nedenle tema değişikliği bir anda birçok nesneyi güncelleyebilir.

Aspose.Slides’da sunum‑seviyesi tema, [Presentation.master_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/master_theme/) özelliğiyle erişilebilir. Bir sunum ayrıca alt seviyelerde tema geçersiz kılmalarına da sahip olabilir. Bir master, [MasterThemeManager.override_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/masterthememanager/override_theme/) ile sunum temasını geçersiz kılabilir, bir yerleşim (layout) kendi miras aldığı temayı [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) ile geçersiz kılabilir ve bireysel bir slayt da aynı işlemi yapabilir. Pratikte bir slayt için etkili tema, şu kalıtım zinciri üzerinden çözülür: sunum teması → master geçersiz kılma → layout geçersiz kılma → slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Bir Temayı İnceleme**

[MasterTheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/) nesnesi, temanın [color_scheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/font_scheme/) ve [format_scheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/format_scheme/) özelliklerini ortaya çıkarır. Bu koleksiyonları değiştirmeden önce incelemek, özellikle bir sunum dış bir kaynaktan geldiğinde stil girişi sayısı ve içeriği değişebileceği için yararlıdır.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç tane arka plan, dolgu, çizgi ve efekt stilinin saklandığını raporlar:

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

Bir dosya birden çok master kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slaytla ilişkili master’ı inceleyin ve yerleşim veya slayt geçersiz kılmalarının mevcut olabileceği durumlarda bu makalede daha sonra gösterilen etkili‑tema iş akışını kullanın.

## **Tema Renklerini Değiştirme**

Tema‑farkındalıklı dolgular, çizgiler ve metinler, [SchemeColor](https://reference.aspose.com/slides/tr/python-net/aspose.slides/schemecolor/) enum’undan mantıksal bir renk başvurusunda bulunabilir. Tema’nın [ColorScheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/colorscheme/) içindeki ilgili girişi değiştirdiğinizde, hâlâ o tema rengine başvuran tüm nesneler yeni değerle çözülür. Doğrudan RGB rengi kullanan nesneler bir tema‑renk güncellemesinden etkilenmez.

Aşağıdaki uçtan‑uça örnek, `ACCENT4` kullanan bir şekil oluşturur, temadaki `accent4` rengini kırmızıya değiştirir, sunumu kaydeder, yeniden açar ve etkili dolgu rengini yazdırır:

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

Dikdörtgen hâlâ `ACCENT4`e bağlı olduğundan, tema değiştirildiğinde görünen rengi kırmızı olur. Şekilde şema rengini doğrudan bir renk ile değiştirirseniz, sonraki `accent4` değişiklikleri o dolguyu etkilemez.

### **Ek Paletten Renk Kullanma**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar türetmek için renk dönüşümleri uygular. Aspose.Slides, bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/colortransformoperation/) enum’u aracılığıyla sunar.

![Ana tema renkleri ve ek paletten oluşturulan daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** – Ana tema renkleri.

**2** – Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `ACCENT4` tabanlı altı dikdörtgen oluşturur, beş tanesine parlaklık dönüşümleri uygular ve sonucu kaydeder:

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

[SchemeColor](https://reference.aspose.com/slides/tr/python-net/aspose.slides/schemecolor/) enum’u `TEXT1`, `BACKGROUND1`, `TEXT2` ve `BACKGROUND2` değerlerini kullanırken, [ColorScheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/colorscheme/) aynı tema yuvalarını `dark1`, `light1`, `dark2` ve `light2` olarak sunar. Eşleme sabittir:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Bunlar aynı tema yuvalarının farklı adlarıdır; bir formdan diğerine dinamik dönüşüm yapılan değerler değildir.

## **Tema Yazı Tiplerini Değiştirme**

Bir tema yazı tipi şeması, başlıklar için bir ana (major) yazı tipi kümesi ve gövde metni için bir yan (minor) yazı tipi kümesi içerir. [FontScheme.major](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/fontscheme/major/) ve [FontScheme.minor](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/fontscheme/minor/) özellikleri bu kümeleri ortaya çıkarır.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

* `+mn-lt` – Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj-lt` – Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn-ea` – Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj-ea` – Başlık Yazı Tipi Doğu Asya (Major East Asian Font)

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

Başlık ana yazı tipini, gövde metni ise yan yazı tipini izler. Tema yazı tipi şeması değiştiğinde, açıkça bir yazı tipi adı belirtilen metin otomatik olarak geçiş yapmaz.

{{% alert color="info" title="Tip" %}}
Sunum yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/python-net/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

## **Bir Temayı Kopyalama veya Uygulama**

İki yaygın iş akışı vardır ve farklı sorunları çözerler.

### **Kaynak Temayı Slayt Taşırken Koruma**

Bir slaytı başka bir sunuma taşırken orijinal tasarımını korumak istiyorsanız, kaynak master’ı [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/add_clone/) ile hedef sunuma klonlayın, ardından slaytı [SlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) ve klonlanmış master ile klonlayın. Bu, master’ı, yerleşimlerini ve ilişkili temayı birlikte taşır.

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

Bu, kaynak slaytın hedefte aynı görünmesi gerektiğinde tercih edilen iş akışıdır. İçeriği alakasız bir hedef master üzerine sadece klonlamak, tema‑türü renkleri, yazı tiplerini, arka planları ve efektleri değiştirebilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygulama**

Hedef slayt mevcut master ve yerleşiminde kalmalıysa, kaynak temadan bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) ve [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) yöntemleri üç ana tema bileşenini geçersiz kılamaya kopyalar.

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

Bu, diğer slaytların miras aldığı temayı değiştirmeden yalnızca bu slaytın kullandığı temayı değiştirir. Yerel geçersiz kılmayı kaldırıp miras alınan değerlere dönüşmek için [OverrideTheme.clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/clear/) çağırın.

### **Bir Yerleşime Tema Geçersiz Kılma Uygulama**

Yerleşim‑seviyesi bir geçersiz kılma, o yerleşimi kullanan slaytlara uygulanır; ancak belirli bir slayt kendi geçersiz kılamasını yapmışsa o geçerli olur. Aynı başlatma yöntemleri, yerleşimin [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/layoutslidethememanager/) aracılığıyla kullanılabilir:

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

Birçok yerleşim ve slayt aynı temel tasarımı paylaşmalıysa sunum‑seviyesi veya master‑seviyesi temayı kullanın; bir yerleşim ailesi farklı bir stil gerektiriyorsa yerleşim geçersiz kılmasını, yalnızca istisnai durumlarda slayt geçersiz kılmasını tercih edin. Aşırı slayt‑seviyesi geçersiz kılmalar, ilerideki global tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelleme**

Temanın arka plan dolgu stilleri, [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) içinde depolanır. PowerPoint, UI’da temayı dolgu renkleri, tema renkleri ve diğer stil referanslarıyla birleştirerek, fiziksel olarak bu koleksiyonda tanımlı dolgu sayısından daha fazla arka plan seçeneği sunabilir.

![Sunum teması için PowerPoint arka plan stili galerisi](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce saklanan koleksiyonu ve geçerli [Background.style_index](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/style_index/) değerini inceleyin. `style_index` temalı dolgu yoksa `0` kullanır; pozitif değerler tema arka plan‑stil referanslarıdır. Bu, Python koleksiyonunda doğrudan dizinleme yaparken `[0]` ilk öğeyi gösterir anlamından farklıdır. Her sunumun aynı sayıda arka plan dolgu stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek, mevcut arka plan dolgu sayısını raporlar, ilk master’a temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, master’ın referans verdiği tema girdisine ve yerleşim ya da slayt seviyesindeki olası arka plan geçersiz kılmalarına bağlıdır. Sadece master arka planını değiştirirseniz, kendi arka planını tanımlamış bir slayt etkilenmeyebilir. Kalıtım uygulandıktan sonra nihai arka planı öğrenmek için [Background.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/get_effective/) kullanın.

{{% alert color="warning" title="Warning" %}}
`style_index`i sıfır‑bazlı bir koleksiyon indeksi gibi ele almayın. Ayrıca bir dosyadan stil numarasını sabitleyip başka bir dosyada aynı görünüme sahip olacağını varsaymayın; tema stil tanımları sunuma özgüdür.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Doğrudan arka plan biçimlendirme ve arka plan kalıtımı için [Presentation Background](/slides/tr/python-net/presentation-background/) sayfasına bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleme**

Bir tema format şeması, ayrı ayrı [FormatScheme.fill_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/line_styles/) ve [FormatScheme.effect_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/effect_styles/) koleksiyonları içerir. Tipik Office temaları genellikle görsel olarak hafif, orta ve yoğun biçimlendirmeye karşılık gelen üç temel stil girdisi barındırır, ancak kod sabit bir sayıyı varsaymak yerine her koleksiyonu incelemelidir.

![Aynı şekle uygulanmış hafif, orta ve yoğun tema efektleri](presentation-design_10.png)

Python’da bu koleksiyonlara eriştiğinizde indeksleme sıfır‑bazlıdır: `[0]` ilk saklanan stil, `[2]` üçüncüdür. Bir şeklin stil‑referans indeksleri farklı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ishapestyle/) aracılığıyla ortaya çıkar. Bir tema stilini değiştirmek, o temayı referanslayan şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girdilerinin varlığını kontrol eder, ilk çizgi stilini değiştirir, üçüncü dolgu stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

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

Bu yuvaları referanslayan şekillerde, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili ve üçüncü efekt stili 10 puanlık bir mesafeye sahip dış gölge kazanır. Tam görsel sonuç yine her şeklin hangi stil yuvalarını referansladığına ve doğrudan biçimlendirmenin temayı geçersiz kılıp kılmadığına bağlıdır.

![Çizgi, dolgu ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Etkili Tema Değerlerini Okuma**

Ham tema nesneleri, belirli bir seviyede neyin tanımlandığını gösterir. Etkili değerler ise bir slayt ya da şeklin kalıtım ve yerel geçersiz kılmalar çözüldükten sonra gerçekte ne kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) çağırın. Bir arka plan için [Background.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/get_effective/), bir dolgu için ise [FillFormat.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/get_effective/) kullanın.

Aşağıdaki örnek, bir slayttan etkili temayı, arka planı ve ilk şekil dolgusu okur:

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

Raporlama, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation.master_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/master_theme/) inceleyerek, final görünümü değiştiren bir master, yerleşim, slayt ya da şekil geçersiz kılmasını gözden kaçırabilirsiniz.

## **SSS**

**Bir slayta master’ı değiştirmeden tek bir slayta tema uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/slidethememanager/)’ını kullanın ve geçersiz kılma temasını başlatın. Değişiklik yalnızca o slayt için yerel kalır; diğer slaytlar mevcut temalarını miras almaya devam eder.

**Bir temayı bir sunumdan diğerine taşımak için en güvenli yol nedir?**

Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak master’ı hedefe [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/add_clone/) ile klonlayın ve ardından slaytı aynı master ile [SlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) kullanarak klonlayın. Bu, master, yerleşimler ve temayı birlikte tutar.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt ya da yerleşim teması için [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) ve format nesneleri için ilgili etkili‑veri yöntemlerini (ör. [Background.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/get_effective/) ve [FillFormat.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/get_effective/)) kullanın. Bu API’ler, kalıtım ve geçersiz kılmalar uygulandıktan sonra çözümlenmiş değerleri döndürür.