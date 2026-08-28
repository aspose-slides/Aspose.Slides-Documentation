---
title: "Python'da PowerPoint Sunum Temalarını Yönetme"
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
- temayı yönet
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
description: "Aspose.Slides for Python via .NET ile sunum temalarını yöneterek, tutarlı marka kimliği sağlamak için PowerPoint dosyalarını oluşturun, özelleştirin ve dönüştürün."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, dolgu, çizgi ve efektlerden oluşan koordineli bir set tanımlar. Tema‑bilinçli nesneler, her görsel özelliği sabit bir değer olarak saklamak yerine bu ortak tanımlara başvurur, bu sayede bir tema değişikliği birden çok nesneyi aynı anda güncelleyebilir.

Aspose.Slides içinde, sunum seviyesindeki tema, [Presentation.master_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/master_theme/) özelliği aracılığıyla erişilebilir. Bir sunum, daha düşük seviyelerde de tema geçersiz kılmaları içerebilir. Bir master, [MasterThemeManager.override_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/masterthememanager/override_theme/) aracılığıyla sunum temasını geçersiz kılabilir, bir düzen (layout) [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) ile devralınan temayı geçersiz kılabilir ve bireysel bir slayt da aynı şeyi yapabilir. Pratikte, bir slayt için geçerli tema, şu kalıtım zinciri üzerinden çözülür: sunum teması, master geçersiz kılma, düzen geçersiz kılma ve slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı inceleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersiz kılmalar çözüldükten sonra etkili değerleri okuma.

## **Bir Temayı İnceleyin**

[MasterTheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/) nesnesi, temanın [color_scheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/font_scheme/) ve [format_scheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/format_scheme/) özelliklerini ortaya koyar. Bu koleksiyonları değiştirmeden önce incelemek, özellikle bir sunum dış bir kaynaktan geldiğinde faydalıdır; çünkü stil girişlerinin sayısı ve içeriği değişkenlik gösterebilir.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç adet arka plan, dolgu, çizgi ve efekt stilinin depolandığını raporlar:

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

Bir dosya birden fazla master kullanıyorsa, her slaytın aynı geçerli temaya sahip olduğunu varsaymayın. Slayt ile ilişkili master’ı inceleyin ve düzen veya slayt geçersiz kılmaları mevcut olduğunda bu makalenin ilerleyen kısmında gösterilen geçerli‑tema iş akışını kullanın.

## **Tema Renklerini Değiştirin**

Tema‑bilinçli dolgu, çizgi ve metin, [SchemeColor](https://reference.aspose.com/slides/tr/python-net/aspose.slides/schemecolor/) enum’undan mantıksal bir renge başvurabilir. Tema’nın [ColorScheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/colorscheme/)’indeki ilgili girdiyi değiştirdiğinizde, hâlâ o tema rengini referans eden tüm nesneler yeni değere göre çözülür. Doğrudan bir RGB rengi kullanan nesneler tema‑renk güncellemesinden etkilenmez.

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

Dikdörtgen `ACCENT4`e bağlı kaldığı için tema değiştirildiğinde görünür rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renk ile değiştirirseniz, sonraki `accent4` değişiklikleri o dolguya artık etki etmez.

### **Ek Paletten Renkleri Kullanın**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantlar türetmek için renk dönüşümleri uygular. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/colortransformoperation/) enum’u aracılığıyla sunar.

![Ek paletten üretilen ana tema renkleri ve daha açık‑daha koyu renkler](additional-palette-colors.png)

**1** – Ana tema renkleri.

**2** – Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

Aşağıdaki örnek, `ACCENT4` temelli altı dikdörtgen oluşturur, beş tanesine parlaklık dönüşümleri uygular ve sonucu kaydeder:

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

### **`SchemeColor` Değerlerini `ColorScheme` Yuvalarına Eşleştirin**

[SchemeColor](https://reference.aspose.com/slides/tr/python-net/aspose.slides/schemecolor/) enum’u `TEXT1`, `BACKGROUND1`, `TEXT2` ve `BACKGROUND2` kullanırken, [ColorScheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/colorscheme/) aynı tema yuvalarını `dark1`, `light1`, `dark2` ve `light2` olarak ortaya koyar. Eşleme sabittir:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Bunlar aynı tema yuvalarının alternatif adlarıdır; bir formdan diğerine dinamik bir dönüşüm değildir.

## **Tema Yazı Tiplerini Değiştirin**

Bir tema yazı tipi şeması, başlıklar için bir ana (major) yazı tipi seti ve gövde metni için bir yan (minor) set içerir. [FontScheme.major](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/fontscheme/major/) ve [FontScheme.minor](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/fontscheme/minor/) özellikleri bu setleri ortaya koyar.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmede kullanılabilir:

* `+mn‑lt` – Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj‑lt` – Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn‑ea` – Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj‑ea` – Başlık Yazı Tipi Doğu Asya (Major East Asian Font)

Aşağıdaki örnek, büyük Latin tema yazı tipini kullanan bir başlık ve küçük Latin tema yazı tipini kullanan bir gövde satırı oluşturur. Ardından tema yazı tiplerini değiştirir ve sonucu kaydeder:

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

Başlık büyük yazı tipini, gövde metni ise küçük yazı tipini takip eder. Açıkça bir yazı tipi adı belirtilen metin, tema yazı tipi şeması değiştiğinde otomatik olarak değişmez.

Ana ve yan yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi ayrı ayrı yazı sistemleri için eşlemeler içerebilir. Bu eşlemeleri incelemek, eklemek, değiştirmek veya kaldırmak için [Betik‑Spesifik Tema Yazı Tipleri](/slides/tr/python-net/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="Tip" %}}
PowerPoint yazı tipleri hakkında daha fazla bilgi için [PowerPoint Fonts](/slides/tr/python-net/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

## **Bir Temayı Kopyalayın veya Uygulayın**

Aşağıdaki iş akışları farklı tema‑ilişkili sorunları çözer.

### **Bir Master’a Bağlı Slaytlara Dış Tema Uygulayın**

Bir PowerPoint tema dosyanız (`.thmx`) varsa ve belirli bir master’a bağlı tüm slaytları yeniden stillendirmek istiyorsanız [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) yöntemini kullanın. [Presentation.masters](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/masters/) koleksiyonundan master’ı seçin (bu koleksiyon [MasterSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/)’ı uygular) ve tema dosyasının yolunu metoda geçin.

Yöntem şu adımları gerçekleştirir:

1. Seçilen master’a dayalı yeni bir master slayt oluşturur.
1. Dış temayı yeni master’a uygular.
1. Yeni master’ı daha önce seçilen master’a bağlı olan tüm slaytlara atar.
1. Yeni oluşturulan [IMasterSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imasterslide/) nesnesini döndürür.

Aşağıdaki örnek, ilk master’a bağlı slaytlara dış temayı uygular ve sunumu kaydeder:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Geçersiz, bozuk veya desteklenmeyen bir tema, [PptxException](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pptxexception/) veya format‑ilişkili alt sınıflarından birine neden olabilir. Kullanıcıların sağladığı yolları doğrulayın, dosya sistemi erişim hatalarını yönetin ve temayı başarılı bir şekilde uyguladıktan sonra sunumu kaydedin.

Yalnızca seçilen master’a bağlı slaytlar yeniden atanır. Diğer master’lara ait slaytlar mevcut master ve temalarını korur. Tema‑bilinçli renkler, yazı tipleri, dolgu, çizgi, arka plan ve efektler dış temaya göre çözülür. Doğrudan atanmış renkler, yazı tipleri, dolgu ve diğer açık biçimlendirmeler değişmeden kalabilir. Düzen‑seviyesi ve slayt‑seviyesi geçersiz kılmalar da yeni master’dan devralınan değerlerin üzerine gelebilir.

Tema, çalışma zamanında mevcut olmayan yazı tiplerine referans verebilir. Tutarlı render ve dışa aktarma için gerekli yazı tiplerini kurun, [özel yazı tipi kaynakları](/slides/tr/python-net/custom-font/) aracılığıyla sağlayın veya [yazı tipi ikamesi](/slides/tr/python-net/font-substitution/) yapılandırın.

Bu, doğrudan master‑seviyesi bir iş akışıdır: yöntem bir `.thmx` dosya yolu alır ve slayt‑seviyesi veya düzen‑seviyesi tema geçersiz kılmaları oluşturmayı gerektirmez.

### **Çok‑Masterlı Sunumda Farklı Dış Temalar Uygulayın**

İlgili master önceden bilinmiyorsa, bir temsilci slayttan [Slide.layout_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/layout_slide/) ve [LayoutSlide.master_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/master_slide/) aracılığıyla alın. Tema uygulamadan önce orijinal master referanslarını saklayın; çünkü her çağrı sunumda yeni bir master oluşturur.

Aşağıdaki örnek, iki bölümden gelen slaytların master’larını bulur ve her grup için farklı bir dış tema uygular:

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

İlk çağrı yalnızca `first_group_master`’a bağlı slaytları etkiler, ikinci çağrı ise yalnızca `second_group_master`’a bağlı slaytları etkiler. Diğer master’lara bağlı slaytlar yeniden stillendirilmez.

### **Slaytları Taşırken Kaynak Temasını Koru**

Bir slaytı başka bir sunuma taşımak ve orijinal tasarımını korumak istiyorsanız, kaynak master’ı hedef sunuma [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/add_clone/) ile klonlayın, ardından slaytı [SlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) ve klonlanmış master ile klonlayın. Böylece master, onun düzenleri ve ilişkili tema birlikte taşınır.

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

Bu, kaynak slaytın hedefte aynı şekilde görünmesi gerektiğinde tercih edilen iş akışıdır. Bağlantısız bir hedef master üzerine yalnızca içeriği klonlamak tema‑destekli renk, yazı tipi, arka plan ve efektlerde değişikliklere yol açabilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygulayın**

Hedef slayt mevcut master ve düzeni korumalıysa, kaynak temadan bir slayt‑seviyesi geçersiz kılma başlatın. [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) ve [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) yöntemleri üç ana tema bileşenini geçersiz kılmaya kopyalar.

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

Bu, diğer slaytların devraldığı temayı değiştirmeden o slaytın temasını değiştirir. Yerel geçersiz kılmayı kaldırıp devralınan değerlere dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/clear/) yöntemini çağırın.

### **Bir Düzeni Tema Geçersiz Kılamasıyla Kullanma**

Düzen‑seviyesi bir geçersiz kılma, o düzeni kullanan slaytlara uygulanır; ancak belirli bir slayt kendi geçersiz kılmasına sahipse o önceliği alır. Aynı başlatma yöntemleri, düzenin [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/layoutslidethememanager/) aracılığıyla kullanılabilir:

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

Bir master veya sunum‑seviyesi tema, birçok düzen ve slaytın aynı temel tasarımı paylaşması gerektiğinde tercih edilir; bir düzen geçersiz kılma, bir düzen ailesinin farklı bir stil gerektirdiği durumlarda; bir slayt geçersiz kılma yalnızca gerçek istisnalar için kullanılmalıdır. Aşırı slayt‑seviyesi geçersiz kılmalar, sonraki global tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stilini Güncelleyin**

Temanın arka plan dolgu stilleri, [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) içinde saklanır. PowerPoint, UI’da temalı dolgu ile tema renklerini ve diğer stil referanslarını birleştirerek, bu koleksiyonda fiziksel olarak tanımlı dolgu sayısından daha fazla arka plan seçeneği sunabilir.

![Sunum temasının arka plan stil galerisini gösteren PowerPoint ekranı](presentation-design_8.png)

Bir arka plan stilini kullanmadan önce, saklanan koleksiyonu ve mevcut [Background.style_index](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/style_index/) değerini inceleyin. `style_index` temalı dolgu yoksa `0` kullanır; pozitif değerler tema arka plan‑stil referanslarıdır. Bu, Python koleksiyonuna doğrudan indeksleme yapıp `[0]` ilk öğeyi gösterdiği durumdan farklıdır. Her sunumun aynı sayıda arka plan dolgu stiline sahip olduğunu varsaymayın.

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

Görünür sonuç, master tarafından referans verilen tema girişine ve düzen ya da slayt seviyesindeki varsa arka plan geçersiz kılmalarına bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca master arka planını değiştirmek o slaytı etkilemez. Kalıtım uygulanmış nihai arka planı öğrenmek için [Background.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/get_effective/) kullanın.

{{% alert color="warning" title="Uyarı" %}}
`style_index`i sıfır‑ temelli bir koleksiyon indeksi gibi davranmayın. Ayrıca bir dosyadan alınan stil numarasını sabit kodlayıp başka bir dosyada aynı görünüme sahip olacağını varsaymayın; tema stil tanımlamaları sunuma özeldir.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Doğrudan arka plan biçimlendirmesi ve arka plan kalıtımı için [Presentation Background](/slides/tr/python-net/presentation-background/) bölümüne bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelleyin**

Bir tema format şeması, ayrı ayrı [FormatScheme.fill_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/line_styles/) ve [FormatScheme.effect_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/effect_styles/) koleksiyonlarını içerir. Tipik Office temaları, görsel olarak ince, orta ve yoğun biçimlendirmeyi karşılayan üç temel stil girişi barındırabilir, ancak kod sabit bir sayı varsaymak yerine her koleksiyonu kontrol etmelidir.

![Aynı şekle uygulanan ince, orta ve yoğun tema efektleri](presentation-design_10.png)

Python’da bu koleksiyonlara erişirken indeksleme sıfır‑temellidir: `[0]` ilk depolanmış stil, `[2]` üçüncü stildir. Bir şeklin stil‑referans indeksleri ayrı bir kavramdır ve [IShapeStyle](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ishapestyle/) aracılığıyla ortaya konur. Bir tema stilini değiştirmek, o temayı referans eden şekilleri etkiler; doğrudan biçimlendirilmiş şekiller değişmeden kalabilir.

Aşağıdaki örnek, gerekli stil girişlerinin varlığını doğrular, ilk çizgi stilini değiştirir, üçüncü dolgu stilini değiştirir, üçüncü efekt stilinde dış gölgeyi etkinleştirir ve sonucu kaydeder:

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

Bu slotları referans eden şekillerde, ilk tema çizgi stili kırmızı, üçüncü tema dolgu stili katı orman yeşili ve üçüncü efekt stili 10 puan uzaklıkta bir dış gölge kazanır. Görsel sonuç hâlâ hangi stil slotlarını hangi şekillerin referans aldığına ve doğrudan biçimlendirmelerin temayı geçersiz kılıp kılmadığına bağlıdır.

![Çizgi, dolgu ve gölge ayarları değiştirildikten sonra tema efekt stilleri](presentation-design_11.png)

## **Etkili Katı Dolgunun Tema Rengini Kullanıp Kullanmadığını Belirleyin**

Bir dolgu nesne üzerinde doğrudan depolanabilir veya bir paragraftan, düzenten, master’dan, tema stilinden veya başka bir biçimleme seviyesinden kalıtılabilir. Bu hiyerarşiyi değişmez bir [IFillFormatEffectiveData](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ifillformateffectivedata/) nesnesine dönüştürmek için [FillFormat.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/get_effective/) çağrılır. İlk olarak [IFillFormatEffectiveData.fill_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ifillformateffectivedata/fill_type/) kontrol edilmelidir. Sadece `FillType.SOLID` olduğunda katı‑dolgu özelliklerini okumak gerekir.

Katı dolgu için, [IFillFormatEffectiveData.solid_fill_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ifillformateffectivedata/solid_fill_color/) kalıtım, tema araması ve renk dönüşümleri uygulanmış son RGB değerini verir. [IFillFormatEffectiveData.solid_fill_scheme_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ifillformateffectivedata/solid_fill_scheme_color/) ise ilgili mantıksal [SchemeColor](https://reference.aspose.com/slides/tr/python-net/aspose.slides/schemecolor/) yuvasını döndürür; örneğin `TEXT1` ya da `ACCENT6`. `SchemeColor.NOT_DEFINED` değeri, etkili katı dolgunun bir şema rengine dayalı olmadığını gösterir. Tema renkleri veya doğrudan RGB renkleri kullanan bir iş akışında bu değer, doğrudan RGB dolgu olduğunu belirler.

Yerel [IColorFormat.scheme_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/icolorformat/scheme_color/) değerine yalnızca bakarak bir dolguyu sınıflandırmayın. Örneğin, bir metin parçasının yerel şema rengi tanımlı olmayabilir, bu yüzden yerel değeri `NOT_DEFINED` olur; ancak etkili dolgu bir tema rengine devralınmış ve `TEXT1` ya da `ACCENT6` olabilir. Öte yandan, `solid_fill_scheme_color` hangi mantıksal tema yuvasının etkili rengi ürettiğini söyler, ancak bu yuva nesneden, paragraftan, düzenden, master’dan veya başka bir seviyeden mi geldiğini göstermez.

Aşağıdaki örnek bir sunumu yükler, şekil dolgu ve metin‑parçası dolgularını denetler, her bir son RGB değerini ve ilişkili şema rengini yazar, ve tema rengi değişikliklerini takip etmeyecek katı dolguları işaretler:

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

`NOT_DEFINED` dalı, tema rengi yuvalarındaki değişikliklere yanıt vermeyecek katı dolguların bir denetim listesini sağlar. Bir sunumun yeni bir marka paletine geçmesi gerektiğinde bu nesneleri gözden geçirin. Raporlanan RGB değeri hâlâ mevcut görünümü gösterirken, şema değeri o görünümün tema ile bağlantılı olup olmadığını açıklar.

Etkili‑format nesneleri anlık görüntüdür. Sunum temasını, bir tema geçersiz kılmasını veya kalıtılan herhangi bir biçimlemeyi değiştirdikten sonra, renkleri karşılaştırmadan veya raporlamadan önce `get_effective` tekrar çağrılıp yeni bir `IFillFormatEffectiveData` nesnesi okunmalıdır.

## **Etkili Tema Değerlerini Okuyun**

Ham tema nesneleri, belirli bir seviyede ne tanımlı olduğunu gösterir. Etkili değerler ise bir slayt veya şeklin kalıtım ve yerel geçersiz kılmalar çözüldükten sonra gerçekte ne kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) çağırın. Bir arka plan için [Background.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/get_effective/), bir dolgu için ise [FillFormat.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/get_effective/) kullanın.

Aşağıdaki örnek, bir slayttan etkili tema, arka plan ve ilk şekil dolgusunu okur:

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

Render tanılamaları, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation.master_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/master_theme/) incelerseniz, bir master, düzen, slayt veya şekil geçersiz kılmasının nihai görünümü değiştirdiğini kaçırabilirsiniz.

## **SSS**

**Harici bir tema uygulamak sunumdaki tüm slaytları etkiler mi?**

Hayır. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) yalnızca seçilen master’a bağımlı slaytları yeniden atar. Diğer master’ları kullanan slaytlar mevcut temalarını korur.

**Bir temayı master’ı değiştirmeden tek bir slayta uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/slidethememanager/) kullanın ve geçersiz kılma temasını başlatın. Değişiklik yalnızca o slayta yerel olur; diğer slaytlar mevcut temalarını devralmaya devam eder.

**Bir temayı bir sunumdan diğerine taşırken en güvenli yol nedir?**

Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak master’ı hedefe klonlayın ve ardından slaytı [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/add_clone/) ve [SlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) ile klonlayın. Böylece master, düzenleri ve tema birlikte korunur.

**Kalıtım ve geçersiz kılmalardan sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya düzen teması için [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) ve format nesneleri (ör. [Background.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/get_effective/) ve [FillFormat.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/get_effective/)) ilgili etkili‑veri metodlarını kullanın. Bu API’lar, kalıtım ve geçersiz kılmalar uygulandıktan sonra çözümlenmiş değerleri döndürür.