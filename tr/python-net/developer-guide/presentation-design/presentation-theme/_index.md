---
title: PowerPoint Sunum Temalarını Python'da Yönet
linktitle: Sunum Teması
type: docs
weight: 10
url: /tr/python-net/presentation-theme/
keywords:
- PowerPoint teması
- sunum teması
- slayt teması
- temayı ayarla
- temayı değiştir
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
description: "Tutarlı marka oluşturma amacıyla PowerPoint dosyalarını oluşturmak, özelleştirmek ve dönüştürmek için .NET üzerinden Python için Aspose.Slides içinde ana sunum temalarını yönetin."
---
## **Giriş**

Bir sunum teması, renkler, yazı tipleri, arka plan stilleri, doldurmalar, çizgiler ve efektlerden oluşan koordine bir küme tanımlar. Tema‑bilinçli nesneler, her görsel özelliği sabit bir değer olarak depolamak yerine bu ortak tanımlara başvurur, böylece bir tema değişikliği birden çok nesneyi aynı anda güncelleyebilir.

Aspose.Slides'da, sunum seviyesindeki tema, [Presentation.master_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/master_theme/) özelliği aracılığıyla kullanılabilir. Bir sunum, daha düşük seviyelerde tema geçersizlikleri (overrides) de içerebilir. Bir ana slayt, [MasterThemeManager.override_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/masterthememanager/override_theme/) aracılığıyla sunum temasını geçersiz kılabilir, bir düzen kendi kalıtılan temasını [BaseOverrideThemeManager.override_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/baseoverridethememanager/override_theme/) ile geçersiz kılabilir ve bireysel bir slayt da aynı şekilde davranabilir. Pratikte, bir slayt için etkili tema, şu kalıtım zinciri üzerinden çözülür: sunum teması, ana slayt geçersiz kılma, düzen geçersiz kılma ve slayt geçersiz kılma.

![Tema bileşenleri: renkler, yazı tipleri, arka plan stilleri ve efektler](theme-constituents.png)

Aşağıdaki bölümler en yaygın tema iş akışlarını gösterir: bir temayı denetleme, renk ve yazı tiplerini değiştirme, bir temayı kopyalama veya uygulama, arka plan ve efekt stillerini güncelleme ve kalıtım ve geçersizlikler uygulandıktan sonra etkili değerleri okuma.

## **Temayı İncele**

[MasterTheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/) nesnesi, temanın [color_scheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/color_scheme/), [font_scheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/font_scheme/) ve [format_scheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/mastertheme/format_scheme/) özelliklerini ortaya koyar. Bu koleksiyonları değiştirmeden önce incelemek, özellikle sunum dış bir kaynaktan geldiğinde stil girişlerinin sayısı ve içeriği değişebileceği için faydalıdır.

Aşağıdaki örnek, ana tema özelliklerini okur ve temada kaç tane arka plan, doldurma, çizgi ve efekt stilinin depolandığını raporlar:

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

Bir dosya birden fazla ana slayt kullanıyorsa, her slaytın aynı etkili temaya sahip olduğunu varsaymayın. Slayt ile ilişkili ana slaytı inceleyin ve düzen veya slayt geçersizliklerinin mevcut olabileceği durumlarda bu makalenin ilerleyen kısmında gösterilen etkili tema iş akışını kullanın.

## **Tema Renklerini Değiştir**

Tema‑bilinçli doldurmalar, çizgiler ve metin, [SchemeColor](https://reference.aspose.com/slides/tr/python-net/aspose.slides/schemecolor/) enum'undan mantıksal bir renge başvurabilir. Tema’nın [ColorScheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/colorscheme/) içindeki ilgili girişi değiştirdiğinizde, hâlâ o tema rengini referans eden tüm nesneler yeni değer üzerinden çözümlenir. Doğrudan bir RGB rengi kullanan nesneler tema‑renk güncellemesinden etkilenmez.

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

Dikdörtgen `ACCENT4` ile bağlı kalmaya devam ettiği için, tema değiştirildiğinde görünen rengi kırmızı olur. Şekildeki şema rengini doğrudan bir renkle değiştirirseniz, sonraki `accent4` değişiklikleri o doldurmayı etkilemez.

### **Ek Paletten Renkleri Kullan**

PowerPoint, bir tema renginden daha açık ve daha koyu varyantları renk dönüşümleri uygulayarak türetir. Aspose.Slides bu dönüşümleri [ColorTransformOperation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/colortransformoperation/) enum'u aracılığıyla sunar.

![Ana tema renkleri ve ek paletten üretilen daha açık ve daha koyu renkler](additional-palette-colors.png)

**1** - Ana tema renkleri.

**2** - Ana tema renklerinden üretilen daha açık ve daha koyu varyantlar.

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

Bu varyantlar tema rengine göre kalır. `accent4` daha sonra değişirse, dönüştürülmüş renkler yeni `accent4` değerinden yeniden hesaplanır.

### **`SchemeColor` Değerlerini `ColorScheme` Yuvalarına Haritalama**

[SchemeColor](https://reference.aspose.com/slides/tr/python-net/aspose.slides/schemecolor/) enum'u `TEXT1`, `BACKGROUND1`, `TEXT2` ve `BACKGROUND2` değerlerini kullanırken, [ColorScheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/colorscheme/) aynı tema yuvalarını `dark1`, `light1`, `dark2` ve `light2` olarak sunar. Haritalama sabittir:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

Bunlar aynı tema yuvalarının farklı adlarıdır; bir formdan diğerine dinamik olarak dönüştürülen değerler değildir.

## **Tema Yazı Tiplerini Değiştir**

Bir tema yazı tipi şeması, başlıklar için bir ana yazı tipi seti ve gövde metni için bir yan (minor) yazı tipi seti içerir. [FontScheme.major](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/fontscheme/major/) ve [FontScheme.minor](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/fontscheme/minor/) özellikleri bu setleri açığa çıkarır.

PowerPoint‑uyumlu tema yazı tipi tanımlayıcıları metin biçimlendirmesinde kullanılabilir:

* `+mn-lt` - Gövde Yazı Tipi Latin (Minor Latin Font)
* `+mj-lt` - Başlık Yazı Tipi Latin (Major Latin Font)
* `+mn-ea` - Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
* `+mj-ea` - Başlık Yazı Tipi Doğu Asya (Major East Asian Font)

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

Başlık ana yazı tipini, gövde metni ise yan yazı tipini izler. Tema tanımlayıcısı yerine açık bir yazı tipi adı belirtilmişse, tema yazı tipi şeması değişse bile bu metin otomatik olarak geçiş yapmaz.

Ana ve yan yazı tipi koleksiyonları ayrıca Kiril, Arapça, Japonca, Gürcüce ve Thaana gibi bireysel yazı sistemleri için yazı tipi eşlemeleri içerebilir. Bu eşlemeleri denetlemek, eklemek, değiştirmek veya kaldırmak için [Script‑Specific Theme Fonts](/slides/tr/python-net/script-specific-font-mappings/) bölümüne bakın.

{{% alert color="info" title="Tip" %}}
Sunum yazı tipleri hakkında daha fazla bilgi için, [PowerPoint Yazı Tipleri](/slides/tr/python-net/powerpoint-fonts/) sayfasına bakın.
{{% /alert %}}

## **Bir Temayı Kopyala veya Uygula**

Aşağıdaki iş akışları farklı tema‑ile ilgili sorunları çözer.

### **Harici Bir Temayı Ana Slayta Bağlı Slaytlara Uygula**

PowerPoint tema dosyası (`.thmx`) elinizde ve belirli bir ana slayta bağlı tüm slaytların stilini yeniden düzenlemek istediğinizde [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) kullanın. [Presentation.masters](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/masters/) koleksiyonundan (bu koleksiyon [MasterSlideCollection](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/) uygular) ana slaytı seçin ve tema dosya yolunu metoda geçirin.

Metod aşağıdaki işlemleri yapar:

1. Seçilen ana slayta dayalı yeni bir ana slayt oluşturur.
1. Dış temayı yeni ana slayta uygular.
1. Yeni ana slaytı, önceden seçilen ana slayta bağlı olan tüm slaytlara atar.
1. Yeni oluşturulan [IMasterSlide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imasterslide/) nesnesini döner.

Aşağıdaki örnek, ilk ana slayta bağlı slaytlara dış temayı uygular ve sunumu kaydeder:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    selected_master = presentation.masters[0]
    themed_master = selected_master.apply_external_theme_to_depending_slides("corporate-theme.thmx")

    print(f"Created master: {themed_master.name}")
    presentation.save("presentation-with-external-theme.pptx", slides.export.SaveFormat.PPTX)
```

Geçersiz, bozuk veya desteklenmeyen bir tema, [PptxException](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pptxexception/) veya formatla ilgili bir alt sınıfa neden olabilir. Kullanıcıların sağladığı yolları doğrulayın, dosya sistemi erişim hatalarını yönetin ve temayı başarıyla uyguladıktan sonra sunumu kaydedin.

Yalnızca seçilen ana slayta bağlı slaytlar yeniden atanır. Diğer ana slaytlara bağlı slaytlar mevcut ana slayt ve temalarını korur. Tema‑bilinçli renkler, yazı tipleri, doldurmalar, çizgiler, arka planlar ve efektler dış tema üzerinden çözülür. Doğrudan atanmış renkler, yazı tipleri, doldurmalar ve diğer açık biçimlendirmeler değişmeden kalabilir. Düzen‑seviyesi ve slayt‑seviyesi geçersizlikler, yeni ana slayttan miras alınan değerlere öncelik tanıyabilir.

Tema, çalışma zamanında bulunmayan yazı tiplerine başvurabilir. Tutarlı render ve dışa aktarım için gerekli yazı tiplerini kurun, [özel yazı tipi kaynakları](/slides/tr/python-net/custom-font/) aracılığıyla sağlayın veya [yazı tipi ikamesi](/slides/tr/python-net/font-substitution/) yapılandırın.

Bu doğrudan ana‑seviyesi bir iş akışıdır: metod bir `.thmx` dosya yolunu alır ve slayt‑seviyesi veya düzen‑seviyesi tema geçersizlikleri oluşturmayı gerektirmez.

### **Çoklu Ana Slayt Sunumunda Farklı Harici Temalar Uygula**

İlgili ana slayt önceden bilinmiyorsa, onu bir temsilci slayttan [Slide.layout_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slide/layout_slide/) ve [LayoutSlide.master_slide](https://reference.aspose.com/slides/tr/python-net/aspose.slides/layoutslide/master_slide/) aracılığıyla elde edin. Her çağrı sunuma yeni bir ana slayt eklediği için, temaları uygulamaya başlamadan önce orijinal ana slayt referanslarını saklayın.

Aşağıdaki örnek, iki bölümden slaytları alır, ana slaytlarını bulur ve her grup için farklı bir harici tema uygular:

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

İlk çağrı yalnızca `first_group_master` üzerine bağlı slaytları etkiler, ikinci çağrı yalnızca `second_group_master` üzerine bağlı slaytları etkiler. Diğer ana slaytlara bağlı slaytlar yeniden biçimlendirilmez.

### **Slaytları Taşırken Kaynak Temasını Koru**

Bir slaytı başka bir sunuma taşımak ve özgün tasarımını korumak istiyorsanız, kaynak ana slaytı hedef sunuma [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/add_clone/) ile klonlayın, ardından klonlanmış ana slaytı kullanarak slaytı [SlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) ile klonlayın. Bu, ana slaytı, düzenlerini ve ilişkili temayı birlikte taşır.

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

Bu, kaynak slaytın hedefte aynı görünmesi gerektiğinde tercih edilen iş akışıdır. İçeriği alakasız bir hedef ana slayta doğrudan kopyalamak tema‑temelli renk, yazı tipi, arka plan ve efektlerin değişmesine neden olabilir.

### **Mevcut Bir Slayta Tema Değerlerini Uygula**

Hedef slayt mevcut ana slaytı ve düzeni korumalıysa, kaynağın temasından bir slayt‑seviyesi geçersizlik başlatın. [OverrideTheme.init_color_scheme_from](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/init_color_scheme_from/), [OverrideTheme.init_font_scheme_from](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/init_font_scheme_from/) ve [OverrideTheme.init_format_scheme_from](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/init_format_scheme_from/) metodları üç ana tema bileşenini geçersiz kılmaya kopyalar.

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

Bu, o slaytın kullandığı temayı diğer slaytların miras aldığı temayı değiştirmeden değiştirir. Yerel geçersiz kılmayı kaldırıp miras alınan değerlere geri dönmek için [OverrideTheme.clear](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/overridetheme/clear/) çağırın.

### **Bir Düzeni Tema Geçersiz Kılması ile Uygula**

Düzen‑seviyesi bir geçersizlik, o düzeni kullanan slaytlara uygulanır; özel bir slayt kendi geçersiz kılmasına sahipse o tercih edilir. Aynı başlatma metodları, düzenin [LayoutSlideThemeManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/layoutslidethememanager/) üzerinden kullanılabilir:

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

Birden çok düzen ve slayt aynı temel tasarımı paylaşmalıysa ana veya sunum‑seviyesi temayı, tek bir düzen ailesi farklı stil gerektiriyorsa düzen geçersiz kılmasını ve yalnızca gerçek istisnalar için slayt geçersiz kılmasını kullanın. Aşırı slayt‑seviyesi geçersizlikler, sonraki küresel tema değişikliklerini tahmin etmeyi zorlaştırır.

## **Tema Arka Plan Stillerini Güncelle**

Temanın arka plan doldurmaları, [FormatScheme.background_fill_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/background_fill_styles/) içinde depolanır. PowerPoint, kullanıcı arabiriminde temaya ait doldurmaları tema renkleri ve diğer stil referanslarıyla birleştirerek, fiziksel olarak bu koleksiyonda depolanan doldurma tanımlarının ötesinde daha fazla arka plan seçeneği sunabilir.

![Sunum temasına ait PowerPoint arka plan stil galerisini gösterir](presentation-design_8.png)

Bir arka plan stili kullanmadan önce, depolanmış koleksiyonu ve geçerli [Background.style_index](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/style_index/) değerini denetleyin. `style_index` değeri, temalı doldurma yoksa `0`; pozitif değerler tema arka plan‑stil referanslarıdır. Bu, Python koleksiyonunu doğrudan indekslemeden `[0]` ilk depolanmış öğeyi ifade eder. Her sunumun aynı sayıda arka plan doldurma stiline sahip olduğunu varsaymayın.

Aşağıdaki örnek, mevcut arka plan doldurma sayısını raporlar, ilk ana slayta temalı bir arka plan referansı atar ve sunumu kaydeder:

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

Görünür sonuç, ana slayt tarafından referans verilen tema girişine ve düzen ya da slayt seviyesindeki arka plan geçersizliklerine bağlıdır. Bir slayt kendi arka planını kullanıyorsa, yalnızca ana slayt arka planını değiştirmek o slaytı etkilemeyebilir. Kalıtım uygulandıktan sonra nihai arka planı öğrenmek için [Background.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/get_effective/) kullanın.

{{% alert color="warning" title="Uyarı" %}}
`style_index` değerini sıfır‑tabanlı bir koleksiyon indeksi gibi kullanmayın. Ayrıca bir dosyadan bir stil numarasını sabit kodlamaktan ve başka bir dosyada aynı görünüme sahip olduğunu varsaymaktan kaçının; tema stil tanımları sunuma özgüdür.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Doğrudan arka plan biçimlendirme ve arka plan mirası için, [Sunum Arka Planı](/slides/tr/python-net/presentation-background/) sayfasına bakın.
{{% /alert %}}

## **Tema Efektlerini Güncelle**

Tema format şeması, ayrı ayrı [FormatScheme.fill_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/fill_styles/), [FormatScheme.line_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/line_styles/) ve [FormatScheme.effect_styles](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/effect_styles/) koleksiyonları içerir. Tipik Office temaları, görsel olarak ince, orta ve yoğun biçimlendirmelere karşılık gelen üç temel stil girişi bulundurur; ancak kod, sabit bir sayıyı varsaymak yerine her koleksiyonu denetlemelidir.

![Aynı şekle uygulanmış ince, orta ve yoğun tema efektleri](presentation-design_10.png)

Python’da bu koleksiyonlara eriştiğinizde, koleksiyon indeksi sıfır‑tabanlıdır: `[0]` ilk depolanmış stil, `[2]` üçüncü stildir. Bir şeklin stil‑referans indeksleri ayrı bir kavram olup, [IShapeStyle](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ishapestyle/) üzerinden sunulur. Bir tema stilini değiştirmek, o tema stilini referans eden şekilleri etkiler; doğrudan biçimlendirme kullanılan şekiller değişmeden kalabilir.

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

Bu yuvalara başvuran şekiller için, ilk tema çizgi stili kırmızı, üçüncü tema doldurma stili katı orman yeşili ve üçüncü efekt stili 10 puan mesafeli bir dış gölge kazanır. Tam görsel sonuç, her şeklin hangi stil yuvalarını referans aldığına ve doğrudan biçimlendirmenin temayı geçersiz kılıp kılmadığına bağlıdır.

![Çizgi, doldurma ve gölge ayarları değiştirildikten sonraki tema efekt stilleri](presentation-design_11.png)

## **Etkili Tema Değerlerini Oku**

Ham tema nesneleri, belirli bir seviyede tanımlananları gösterir. Etkili değerler, kalıtım ve yerel geçersizlikler çözüldükten sonra bir slayt veya şeklin gerçekte ne kullandığını gösterir. Bir slayt için [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) çağırın. Bir arka plan için [Background.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/get_effective/), bir doldurma için ise [FillFormat.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/get_effective/) kullanın.

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

Render tanılamaları, doğrulama ve karşılaştırmalar için etkili verileri kullanın. Yalnızca [Presentation.master_theme](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/master_theme/) denetlerseniz, final görünümü değiştiren bir ana, düzen, slayt veya şekil geçersiz kılmasını kaçırabilirsiniz.

## **SSS**

**Harici bir tema uygulamak sunumdaki her slaytı etkiler mi?**

Hayır. [IMasterSlide.apply_external_theme_to_depending_slides](https://reference.aspose.com/slides/tr/python-net/aspose.slides/imasterslide/apply_external_theme_to_depending_slides/) yalnızca seçilen ana slayta bağlı slaytları yeniden atar. Diğer ana slaytları kullanan slaytlar mevcut temalarını korur.

**Bir temayı tek bir slayta, ana slaytı değiştirmeden uygulayabilir miyim?**

Evet. Slaytın [SlideThemeManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/slidethememanager/) kullanın ve geçersizlik temasını başlatın. Değişiklik yalnızca o slayda yerel kalır; diğer slaytlar mevcut temalarını miras almaya devam eder.

**Bir temayı bir sunumdan diğerine taşımanın en güvenli yolu nedir?**

Bir slaytı taşırken ve kaynak görünümünü korurken, kaynak ana slaytı hedefe [MasterSlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/masterslidecollection/add_clone/) ile klonlayın, ardından klonlanmış ana slaytı kullanarak slaytı [SlideCollection.add_clone](https://reference.aspose.com/slides/tr/python-net/aspose.slides/slidecollection/add_clone/) ile klonlayın. Bu, ana slaytı, düzenleri ve temayı birlikte tutar.

**Kalıtım ve geçersizliklerden sonra etkili değerleri nasıl görebilirim?**

Bir slayt veya düzen temasının etkili halini almak için [BaseOverrideThemeManager.create_theme_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/baseoverridethememanager/create_theme_effective/) metodunu, format nesneleri (ör. [Background.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/background/get_effective/) ve [FillFormat.get_effective](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/get_effective/)) için ilgili etkili‑veri metodlarını kullanın. Bu API’ler, kalıtım ve geçersizlikler uygulandıktan sonra çözülmüş değerleri döndürür.