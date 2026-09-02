---
title: Python ile Sunum Metnini Biçimlendir
linktitle: Metin Biçimlendirme
type: docs
weight: 50
url: /tr/python-net/text-formatting/
keywords:
- paragraf hizalama
- metin stili
- metin arka planı
- metin şeffaflığı
- karakter aralığı
- yazı tipi özellikleri
- yazı tipi ailesi
- metin döndürme
- döndürme açısı
- metin çerçevesi
- satır aralığı
- otomatik sığdırma özelliği
- metin çerçevesi sabitlemesi
- metin sekleme
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında metin biçimlendirmeyi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sek durakları ve dil ayarlarını kapsar.

Aşağıdaki örneklerde, ilk slaytta aşağıdaki metni içeren tek bir metin kutusu bulunan "sample.pptx" adlı bir dosya kullanacağız:

![Örnek metin](sample_text.png)

Literal metni veya düzenli ifade eşleşmelerini bulmak ve vurgulamak için, [Metin Arama ve Değiştirme](/slides/tr/python-net/search-and-replace-text/) sayfasına bakın.

## **Metin Arka Plan Rengini Ayarla**

[ParagraphFormat.default_portion_format] kullanarak bir paragraf için varsayılan vurgulama rengi ayarlanabilir veya bireysel metin bölümleri için [PortionFormat.highlight_color] kullanılabilir.

Aşağıdaki kod örneği **tüm paragraf** için arka plan rengini nasıl ayarlayacağınızı gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Tüm paragraf için vurgulama rengini ayarla.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için arka plan rengini nasıl ayarlayacağınızı gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Metin bölümü için vurgulama rengini ayarla.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizala**

[ParagraphFormat.alignment] kullanarak bir metin çerçevesi içinde paragraf hizalamasını ayarlayabilirsiniz. Değer, ortalanmış, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamayı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Paragraf hizalamasını ortaya ayarla.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Metin İçin Şeffaflığı Ayarla**

Metin şeffaflığı, [PortionFormat.fill_format]‑a atanan rengin alfa bileşeni üzerinden kontrol edilir. Aşağıdaki örneklerde `alpha =  50` 0‑255 ölçeğinde bir ARGB alfa kanalı değeridir, yüzde şeffaflık değildir.

Aşağıdaki kod örneği **tüm paragraf** için şeffaflığı uygulamayı gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Metnin dolgu rengini şeffaf renk olarak ayarla.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için şeffaflığı uygulamayı gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Metin bölümünün şeffaflığını ayarla.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Şeffaf metin bölümleri](transparent_text_portions.png)

## **Metin İçin Karakter Aralığını Ayarla**

[BasePortionFormat.spacing] kullanarak bir metin kutusundaki karakterler arasındaki aralığı genişletebilir veya sıkıştırabilirsiniz.

Aşağıdaki Python kodu **tüm paragraf** içinde karakter aralığını genişletmeyi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Karakter aralığını genişlet.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Paragraftaki karakter aralığı](character_spacing_in_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** içinde karakter aralığını genişletmeyi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
            portion.portion_format.spacing = 3  # Karakter aralığını genişlet.

    presentation.save("character_spacing_in_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Metin bölümlerindeki karakter aralığı](character_spacing_in_text_portions.png)

### **Belirli Yazı Tipleri İçin Kerning'i Devre Dışı Bırak**

Bazı durumlarda Aspose.Slides tarafından oluşturulan metin, PowerPoint'te görülen metinden biraz daha sık görünür. Bu, PowerPoint'in bazı yazı tipleri için kerning verilerini görmezden gelmesinden kaynaklanabilir, hatta yazı tipi geçerli kerning bilgisine sahip ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu gibi durumlarda çıktıyı PowerPoint'e daha yakın hale getirmek için, etkilenen yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [BasePortionFormat.kerning_minimal_size] değerini gerçek yazı tipi boyutundan belirgin şekilde daha büyük bir değere ayarlayın:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            latin_font = portion.portion_format.latin_font
            east_asian_font = portion.portion_format.east_asian_font
            complex_script_font = portion.portion_format.complex_script_font

            if ((latin_font is not None and latin_font.font_name == target_font) or
                    (east_asian_font is not None and east_asian_font.font_name == target_font) or
                    (complex_script_font is not None and complex_script_font.font_name == target_font)):
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, [ParagraphFormat.default_portion_format] aracılığıyla paragraf düzeyinde veya [PortionFormat] aracılığıyla tek tek bölümler için ayarlanabilir.

Aşağıdaki kod, tüm paragraf için yazı tipini ve metin stilini ayarlar: Yazı tipi boyutu, kalın, italik, noktalı alt çizgi ve Times New Roman yazı tipini paragraftaki tüm bölümlere uygular.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Paragraf için yazı tipi özelliklerini ayarla.
    paragraph.paragraph_format.default_portion_format.font_height = 12
    paragraph.paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_italic = slides.NullableBool.TRUE
    paragraph.paragraph_format.default_portion_format.font_underline = slides.TextUnderlineType.DOTTED
    paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Paragraf için yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için benzer özellikleri uygular:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Metin bölümü için yazı tipi özelliklerini ayarla.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Metin bölümleri için yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Döndürmeyi Ayarla**

[TextFrameFormat.text_vertical_type] kullanarak bir şekil içinde önceden tanımlanmış bir metin yönelimi ayarlanabilir.

Aşağıdaki kod örneği şeklin içindeki metin yönelimini `VERTICAL270` olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Metin döndürmesi](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürmeyi Ayarla**

[TextFrameFormat.rotation_angle] kullanarak bir [TextFrame] için özel bir dönüş açısı ayarlanabilir.

Aşağıdaki kod örneği şeklin içinde metin çerçevesini saat yönünde 3 derece döndürür:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Özel metin döndürmesi](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [ParagraphFormat.space_after], [ParagraphFormat.space_before] ve [ParagraphFormat.space_within] sağlar. Bu özellikler aşağıdaki şekilde kullanılır:

* Pozitif bir değer, satır yüksekliğinin yüzde olarak satır aralığını belirtmek için kullanılır.
* Negatif bir değer, satır aralığını puan olarak belirtmek için kullanılır.

Aşağıdaki kod örneği paragraf içinde satır aralığını nasıl belirteceğinizi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Paragraftaki satır aralığı](line_spacing.png)

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarla**

[TextFrameFormat.autofit_type], metin konteyner sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülüp küçülmeyeceğini, taşacağını ya da şeklin otomatik olarak yeniden boyutlandırılacağını kontrol etmek için kullanın.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Metin Çerçevelerinin Sabitlemesini Ayarla**

[TextFrameFormat.anchoring_type], metnin bir şekil içinde dikey olarak nasıl konumlandırılacağını tanımlar; örneğin üstte, ortada veya altta.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Metin Sekmelerini Ayarla**

[ParagraphFormat.default_tab_size] ve [ParagraphFormat.tabs] kullanarak bir paragrafta sek duraklarını yapılandırabilirsiniz.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Paragraf sekmeleri](paragraph_tabs.png)

## **Denetleme Dilini Ayarla**

Aspose.Slides, bir metin bölümü için denetleme dilini ayarlamanızı sağlayan [PortionFormat.language_id] sunar. Denetleme dili, PowerPoint'te imla ve dilbilgisi denetiminde kullanılan dili belirler.

Aşağıdaki kod örneği bir metin bölümü için denetleme dilini nasıl ayarlayacağınızı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Denetleme dilinin kimliğini ayarla.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Varsayılan Dili Ayarla**

[LoadOptions.default_text_language] kullanarak bir sunum yüklenirken veya oluşturulurken oluşturulan metin için varsayılan dili tanımlayabilirsiniz.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Metin içeren yeni bir dikdörtgen şekil ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # İlk bölümün dilini kontrol et.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Varsayılan Metin Stilini Ayarla**

Sunum seviyesinde varsayılan metin biçimlendirmesi uygulamak için [Presentation.default_text_style] kullanın.

Aşağıdaki kod örneği yeni bir sunumda tüm slaytlardaki metin için 14 pt boyutunda varsayılan kalın bir yazı tipi ayarlar.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Üst seviyedeki paragraf biçimini al.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **Tüm Büyük Harf Efektiyle Metin Çıkar**

PowerPoint'te **All Caps** yazı tipi efekti uygulandığında, metin küçük harfle girilmiş olsa bile slaytta büyük harf olarak görünür. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni girildiği gibi döndürür. Görünen metinle eşleşmesi için [TextCapType] kontrol edin ve değer `ALL` olduğunda döndürülen dizeyi büyük harfe çevirin.

sample2.pptx dosyasının ilk slaydındaki aşağıdaki metin kutusunu ele alalım.

![Tüm Büyük Harf efekti](all_caps_effect.png)

Aşağıdaki kod örneği **All Caps** efekti uygulanmış metni nasıl çıkaracağınızı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    text_portion = auto_shape.text_frame.paragraphs[0].portions[0]

    print("Original text:", text_portion.text)

    text_format = text_portion.portion_format.get_effective()
    if text_format.text_cap_type == slides.TextCapType.ALL:
        text = text_portion.text.upper()
        print("All-Caps effect:", text)
```

Çıktı:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **SSS**

**Bir slayttaki tabloda metni nasıl değiştiririm?**

Bir slayttaki tabloda metni değiştirmek için [Table] kullanın. Hücreler arasında dönün ve her hücreyi [Cell.text_frame] aracılığıyla güncelleyin ve paragraf biçimlendirmesini [Paragraph.paragraph_format] aracılığıyla ayarlayın.

**PowerPoint slaytındaki metne degrade renk nasıl uygulanır?**

Metne degrade renk uygulamak için [PortionFormat.fill_format] kullanın. [FillFormat.fill_type] değerini [FillType.GRADIENT] olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.