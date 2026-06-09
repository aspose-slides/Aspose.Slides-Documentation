---
title: Python'da PowerPoint Sunum Temalarını Yönetin
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
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile tutarlı markalaşma sağlayarak PowerPoint dosyalarını oluşturmak, özelleştirmek ve dönüştürmek için ana sunum temalarını yönetin."
---
## **Giriş**

Bir sunum teması, tasarım öğelerinin özelliklerini tanımlar. Bir tema seçtiğinizde, görsel öğeler ve bunların özelliklerinden oluşan koordineli bir set seçmiş olursunuz.

PowerPoint'te bir tema, renkler, [yazı tipleri](/slides/tr/python-net/powerpoint-fonts/), [arka plan stilleri](/slides/tr/python-net/presentation-background/), ve efektleri içerir.

![tema-bileşenleri](theme-constituents.png)

## **Temanın Rengini Değiştir**

PowerPoint teması, bir slayttaki farklı öğeler için belirli bir renk seti kullanır. Varsayılanları beğenmezseniz, yeni tema renkleri uygulayarak değiştirebilirsiniz. Yeni bir tema rengi seçmenize olanak tanımak için Aspose.Slides, [SchemeColor](https://reference.aspose.com/slides/tr/python-net/aspose.slides/schemecolor/) adlı dizideki değerleri sağlar.

Bu Python kodu, bir temanın vurgu rengini nasıl değiştireceğinizi gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
```

Aşağıdaki gibi elde edilen rengin etkili değerini belirleyebilirsiniz:

```python
fill_effective = shape.fill_format.get_effective()
print("{0} ({1})".format(fill_effective.solid_fill_color.name, fill_effective.solid_fill_color))

# Örnek çıktı:
#
# ff8064a2 (Renk [A=255, R=128, G=100, B=162])
```

Renk değişimini daha iyi göstermek için başka bir öğe oluşturup, başlangıç adımındaki vurgu rengini atıyoruz ve ardından tema rengini güncelliyoruz:

```python
other_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 120, 100, 100)
other_shape.fill_format.fill_type = slides.FillType.SOLID
other_shape.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

presentation.master_theme.color_scheme.accent4.color = draw.Color.red
```

Yeni renk otomatik olarak her iki öğeye de uygulanır.

### **Ek Paletten Bir Tema Rengi Ayarla**

Ana tema rengine (1) parlaklık dönüşümleri uygulandığında, ek paletten (2) renkler üretilir. Bu tema renklerini daha sonra ayarlayıp alabilirsiniz.

![ek-palet-renkleri](additional-palette-colors.png)

**1** — Ana tema renkleri

**2** — Ek paletten renkler

Bu Python kodu, ek palet renklerinin ana tema renginden nasıl türetildiğini ve şekillerde nasıl kullanıldığını gösterir:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Vurgu 4
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 50, 50)

    shape1.fill_format.fill_type = slides.FillType.SOLID
    shape1.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4

    # Vurgu 4, %80 Daha Açık
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 70, 50, 50)

    shape2.fill_format.fill_type = slides.FillType.SOLID
    shape2.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.2)
    shape2.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.8)

    # Vurgu 4, %60 Daha Açık
    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 130, 50, 50)

    shape3.fill_format.fill_type = slides.FillType.SOLID
    shape3.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.4)
    shape3.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.6)

    # Vurgu 4, %40 Daha Açık
    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 190, 50, 50)

    shape4.fill_format.fill_type = slides.FillType.SOLID
    shape4.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.6)
    shape4.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.ADD_LUMINANCE, 0.4)

    # Vurgu 4, %25 Daha Koyu
    shape5 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 250, 50, 50)

    shape5.fill_format.fill_type = slides.FillType.SOLID
    shape5.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape5.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.75)

    # Vurgu 4, %50 Daha Koyu
    shape6 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 50, 50)

    shape6.fill_format.fill_type = slides.FillType.SOLID
    shape6.fill_format.solid_fill_color.scheme_color = slides.SchemeColor.ACCENT4
    shape6.fill_format.solid_fill_color.color_transform.add(slides.ColorTransformOperation.MULTIPLY_LUMINANCE, 0.5)

    presentation.save("example.pptx", slides.export.SaveFormat.PPTX)
```

### **`SchemeColor`ı `ColorScheme` Renklerine Eşleştir**

[SchemeColor](https://reference.aspose.com/slides/tr/python-net/aspose.slides/schemecolor/) ile çalışırken aşağıdaki tema rengi değerlerini içerdiğini görebilirsiniz:

`BACKGROUND1`, `BACKGROUND2`, `TEXT1` ve `TEXT2`.

Ancak `Presentation.master_theme.color_scheme` [ColorScheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/colorscheme/) döndürür; bu da ilgili renkleri şu şekilde sunar:

`dark1`, `dark2`, `light1` ve `light2`.

Bu fark yalnızca isimlendirmededir. Bu değerler aynı tema rengi yuvalarına karşılık gelir ve eşleme sabittir:

* `TEXT1` = `dark1`
* `BACKGROUND1` = `light1`
* `TEXT2` = `dark2`
* `BACKGROUND2` = `light2`

`TEXT`/`BACKGROUND` ile `dark`/`light` arasında dinamik bir dönüşüm yoktur. Aynı tema renklerinin alternatif adlarıdır.

Bu isim farklılığı Microsoft Office terminolojisinden gelir. Eski Office sürümleri `Dark 1`, `Light 1`, `Dark 2` ve `Light 2` kullanırken, yeni UI sürümleri aynı yuvaları `Text 1`, `Background 1`, `Text 2` ve `Background 2` olarak gösterir.

## **Temanın Yazı Tipini Değiştir**

Tema ve diğer amaçlar için yazı tipleri seçmenizi sağlamak amacıyla Aspose.Slides, PowerPoint'teki özel tanımlayıcılara benzer şu tanımlayıcıları kullanır:

- **+mn-lt** — Gövde Yazı Tipi Latin (Minor Latin Font)
- **+mj-lt** — Başlık Yazı Tipi Latin (Major Latin Font)
- **+mn-ea** — Gövde Yazı Tipi Doğu Asya (Minor East Asian Font)
- **+mj-ea** — Başlık Yazı Tipi Doğu Asya (Major East Asian Font)

Bu Python kodu, Latin yazı tipini bir tema öğesine nasıl atayacağınızı gösterir:

```python
portion = slides.Portion("Theme text format")
portion.portion_format.latin_font = slides.FontData("+mn-lt")

paragraph = slides.Paragraph()
paragraph.portions.add(portion)

shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
shape.text_frame.paragraphs.add(paragraph)
```

Bu Python örneği, sunumun tema yazı tipini nasıl değiştireceğinizi gösterir:

```python
presentation.master_theme.font_scheme.minor.latin_font = slides.FontData("Arial")
```

Tüm metin kutuları yeni yazı tipine güncellenir.

{{% alert color="primary" title="TIP" %}}
Daha fazla bilgi için [Master PowerPoint Fonts with Python](/slides/tr/python-net/powerpoint-fonts/) bölümüne bakın.
{{% /alert %}}

## **Temanın Arka Plan Stilini Değiştir**

Varsayılan olarak PowerPoint 12 önceden tanımlı arka plan sunar, ancak tipik bir sunum yalnızca 3 tanesini depolar.

![todo:image_alt_text](presentation-design_8.png)

Örneğin, ardından bir sunumu PowerPoint’te kaydettikten sonra, içinde kaç önceden tanımlı arka plan bulunduğunu belirlemek için aşağıdaki Python kodunu çalıştırabilirsiniz:

```python
with slides.Presentation() as presentation:
    number_of_background_fills = len(presentation.master_theme.format_scheme.background_fill_styles)
    print(f"Number of theme background fill styles: {number_of_background_fills}")
```

{{% alert color="warning" %}}
[FormatScheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/) sınıfının `background_fill_styles` özelliğini kullanarak bir PowerPoint temasına arka plan stilleri ekleyebilir veya erişebilirsiniz.
{{% /alert %}}

Bu Python örneği, sunum arka planını nasıl ayarlayacağınızı gösterir:

```python
presentation.masters[0].background.style_index = 2  # 0, doldurma olmadığını gösterir; indeksleme 1'den başlar.
```

{{% alert color="primary" title="TIP" %}}
Daha fazla bilgi için [Manage Presentation Backgrounds in Python](/slides/tr/python-net/presentation-background/) bölümüne bakın.
{{% /alert %}}

## **Temanın Efektlerini Değiştir**

PowerPoint teması genellikle her stil dizisinde üç değer içerir. Bu diziler, ince, orta ve yoğun olmak üzere üç efekt seviyesine birleşir. Örneğin, bu efektler belirli bir şekle uygulandığında ortaya çıkan sonuç şöyledir:

![todo:image_alt_text](presentation-design_10.png)

[FormatScheme](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/formatscheme/) sınıfının `FillStyles`, `LineStyles` ve `EffectStyles` adlı üç özelliğini kullanarak tema öğelerini (PowerPoint’teki kadar esnek olmayan) değiştirebilirsiniz.

Bu Python kodu, tema etkisini bu öğelerin bölümlerini değiştirerek nasıl değiştireceğinizi gösterir:

```python
with slides.Presentation("sample.pptx") as presentation:
    presentation.master_theme.format_scheme.line_styles[0].fill_format.solid_fill_color.color = draw.Color.red
    presentation.master_theme.format_scheme.fill_styles[2].fill_type = slides.FillType.SOLID
    presentation.master_theme.format_scheme.fill_styles[2].solid_fill_color.color = draw.Color.forest_green
    presentation.master_theme.format_scheme.effect_styles[2].effect_format.outer_shadow_effect.distance = 10

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Sonuçtaki değişiklikler, dolgu rengi, dolgu tipi, gölge efekti ve diğer özelliklerdeki güncellemeleri içerir:

![todo:image_alt_text](presentation-design_11.png)

## **SSS**

**Bir temayı, master'ı değiştirmeden tek bir slayta uygulayabilir miyim?**

Evet. Aspose.Slides, slayt düzeyinde tema geçersiz kılmalarını destekler; böylece sadece o slayta yerel bir tema uygulayabilir, master temayı bozmadan ( [SlideThemeManager](https://reference.aspose.com/slides/tr/python-net/aspose.slides.theme/slidethememanager/) aracılığıyla) bırakabilirsiniz.

**Bir temayı bir sunumdan diğerine en güvenli şekilde nasıl taşıyabilirim?**

[Slide'ları klonlayarak](/slides/tr/python-net/clone-slides/) master'larıyla birlikte hedef sunuma taşıyın. Bu, orijinal master, düzenler ve ilişkili temayı korur, böylece görünüm tutarlı kalır.

**Tüm kalıtım ve geçersiz kılmalar sonrasında “etkili” değerleri nasıl görebilirim?**

Tema/rengi/yazı tipi/efekti için API’nin ["etkili" görünümlerini](/slides/tr/python-net/shape-effective-properties/) kullanın. Bu, master ve yerel geçersiz kılmalar uygulandıktan sonra çözümlenmiş son özellikleri döndürür.