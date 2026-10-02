---
title: Python ile Sunum Metnini Biçimlendirme
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
- metin çerçevesi çapası
- metin sekleme
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında Aspose.Slides for Python via .NET kullanarak metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, saydamlık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin yerleştirme, sek durakları ve dil ayarları gibi konuları kapsar.

Aksi belirtilmedikçe, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slaydının ilk şekli bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Slayt ve şekil indeksleri sıfır-tabanlıdır. Kalın bölümleri seçen örnekler, kalıtılan kalın biçimlendirme dahil olmak üzere etkili biçimlendirmeyi kullanır:

![Örnek metin](sample_text.png)

Metin ve düzenli ifade eşleşmelerini bulmak ve vurgulamak için, [Metin Arama ve Değiştirme](/slides/tr/python-net/search-and-replace-text/) sayfasına bakın.

## **Metin Arka Plan Rengini Ayarla**

Bir paragraf için varsayılan vurgulama rengini ayarlamak için [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) kullanın, ya da tek tek metin bölümleri için [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Tek tek bölümlerde belirtilen vurgulama renkleri bu varsayılanın üzerine geçer:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Tüm paragraf için vurgulama rengini ayarla.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümleri** için arka plan rengini nasıl ayarlayacağını gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) kullanarak bir metin çerçevesindeki paragraf hizalamasını ayarlayın. Değerler ortalanmış, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamayı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Paragrafın hizalamasını ortaya ayarla.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Satır İçinde Yazı Tiplerini Hizala**

[ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) kullanarak aynı satırda farklı yazı tipi boyutlarına sahip metin bölümlerini dikey olarak hizalayabilirsiniz. Bu ayar bütün paragrafı etkiler ve satırlarının içindeki hizalamayı kontrol eder.

Aşağıdaki bağımsız örnek, tek bir slaytta dört etiketli metin kutusu oluşturur. Her paragraf, 18, 36 ve 54 punto aynı metni, farklı bir yazı tipi hizalamasıyla içerir. Arial kullanır, otomatik sığdırma ve kaydırmayı devre dışı bırakır ve metin çerçevelerini tek satır için yeterince büyük tutar.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    alignments = [slides.FontAlignment.BASELINE, slides.FontAlignment.TOP, slides.FontAlignment.CENTER, slides.FontAlignment.BOTTOM]
    font_sizes = [18, 36, 54]

    for i, alignment in enumerate(alignments):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 20 + i * 130, 660, 120)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE

        label = text_frame.paragraphs[0]
        label.text = alignment.name.title()
        label.paragraph_format.alignment = slides.TextAlignment.LEFT
        label.paragraph_format.default_portion_format.font_height = 14
        label.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        label.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        label.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.gray

        paragraph = slides.Paragraph()
        paragraph.paragraph_format.font_alignment = alignment
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
        paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black

        for font_size in font_sizes:
            portion = slides.Portion("Ag ")
            portion.portion_format.font_height = font_size
            paragraph.portions.add(portion)

        text_frame.paragraphs.add(paragraph)

    presentation.save("font_alignment.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Alt Çizgi, Üst, Orta ve Alt hizalamaların karışık yazı tipi boyutlarıyla karşılaştırması](font_alignment.png)

Yazı tipi hizalaması yazı tipi metriklerine dayandığından, bireysel harflerin görünen kenarları mutlaka tam hizalanmaz. Örnek, bir büyük harf ve bir alt karakter içerir; bu, alt çizgi ve alt hizalama arasındaki farkı göstermeye yardımcı olur. Yazı tipi bulunabilirliği ve ikamesi, kullanılan karakterler ve yazı tipi boyutlarındaki fark sonuçları etkiler. Çerçeve boyutları, kenar boşlukları, satır aralığı, kaydırma ve otomatik sığdırma da düzeni etkiler; modları karşılaştırırken aynı yazı tiplerini ve düzen ayarlarını kullanın.

Bu ayar, yatay paragraf hizalamasını kontrol eden [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/), ve şekil içinde metin bloğunu dikey konumlandıran [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) ayarlarından farklıdır. [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) aracılığıyla üst ve alt simge biçimlendirmesi, paragraf satırlarının yazı tipi hizalamasını ayarlamak yerine, bireysel bölümleri alt çizgiye göre kaydırır.

## **Metin İçin Şeffaflığı Ayarla**

Metin şeffaflığı, [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/)’a atanan rengin alfa bileşeni üzerinden kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, %0‑255 ölçeğinde bir ARGB alfa kanalı değeridir, şeffaflık yüzdesi değildir.

Aşağıdaki kod örneği, **tüm paragraf** için şeffaflığın nasıl uygulanacağını gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Metin için yarı saydam siyah dolgu ayarla.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümleri** için şeffaflığın nasıl uygulanacağını gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

[BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) kullanarak bir metin kutusundaki karakterler arasındaki boşluğu artırabilir veya azaltabilirsiniz. Örneklerde 3 puan eklenir; negatif değerler metni sıkıştırır.

Aşağıdaki Python kodu, **tüm paragrafta** karakter aralığını nasıl genişleteceğinizi gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
    paragraph.paragraph_format.default_portion_format.spacing = 3  # Karakter aralığını genişlet.

    presentation.save("character_spacing_in_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Paragraftaki karakter aralığı](character_spacing_in_paragraph.png)

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin bölümlerinde** karakter aralığını nasıl artıracağınızı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

Bazı durumlarda, Aspose.Slides tarafından işlenen metin, PowerPoint'te görüntülenen aynı metinden biraz daha sıkı görünebilir. Bu, PowerPoint'in bazı yazı tipleri için kerning verilerini görmezden gelmesi nedeniyle olabilir; yazı tipinde geçerli kerning bilgisi bulunup PowerPoint ayarlarında kerning etkin olsa bile.

Böyle durumlarda işlenen çıktıyı PowerPoint'e yakınlaştırmak için, etkilenen yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) ayarını gerçek yazı tipi boyutundan daha büyük bir değere ayarlayın. Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusu içeren "presentation.pptx" dosyasını gerektirir. Etkili (kalıtılan) yazı tipi adlarını kontrol eder ve Roboto kullanan bölümler için 100 puanlık bir eşik belirler. Bu, 100 puandan küçük yazı tipi boyutuna sahip eşleşen bölümler için kerning'i devre dışı bırakır:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    target_font = "Roboto"

    for paragraph in auto_shape.text_frame.paragraphs:
        for portion in paragraph.portions:
            text_format = portion.portion_format.get_effective()
            fonts = (text_format.latin_font, text_format.east_asian_font, text_format.complex_script_font)
            uses_target_font = any(font is not None and font.font_name == target_font for font in fonts)

            if uses_target_font:
                portion.portion_format.kerning_minimal_size = 100

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Eşik altındaki eşleşen metinler için bu ayar kerning'i önler ve bu PowerPoint'e özgü davranıştan etkilenen yazı tiplerinin Aspose.Slides render'ının PowerPoint’in görsel çıktısına daha yakın olmasını sağlayabilir.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, paragraf seviyesinde [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) aracılığıyla ya da tek tek bölümler için [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) kullanılarak ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 punto Times New Roman olarak, kalın, italik ve noktalı alt çizgi formatıyla ayarlar. Tek tek bölümlerde belirtilen açık biçimlendirme bu varsayılanların üzerine yazar:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Paragraf için yazı tipi özelliklerini ayarla.
    portion_format = paragraph.paragraph_format.default_portion_format
    portion_format.font_height = 12
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_italic = slides.NullableBool.TRUE
    portion_format.font_underline = slides.TextUnderlineType.DOTTED
    portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Paragraf için yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki örnek, etkili biçimlendirmesi kalın olan bölümlere 13 punto Times New Roman, italik format ve noktalı alt çizgi uygular:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

## **Metin Döndürmesini Ayarla**

Bir şekil içinde önceden tanımlı metin yönünü ayarlamak için [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) kullanın.

Aşağıdaki kod örneği, şeklin içinde metin yönünü [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Metin döndürmesi](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürmeyi Ayarla**

Bir [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) için özel bir döndürme açısı ayarlamak amacıyla [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) kullanın.

Aşağıdaki kod örneği, şeklin içinde metin çerçevesini 3 derece saat yönünde döndürür:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Özel metin döndürmesi](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) ve [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) sağlar. Bu özellikler şu şekilde kullanılır:
* Pozitif bir değer kullanarak satır aralığını satır yüksekliğinin yüzde olarak belirtin.
* Negatif bir değer kullanarak satır aralığını puan cinsinden belirtin.

Aşağıdaki örnek, ilk paragraftaki satır aralığını satır yüksekliğinin %200'ü (çift satır aralığı) olarak ayarlar:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.space_within = 200

    presentation.save("line_spacing.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Paragraftaki satır aralığı](line_spacing.png)

## **Satır Kesintisini Kontrol Et**

Paragraf satır kesme kuralları, dar metin bloklarında ve Latin ile Doğu Asya metninin karıştığı sunumlarda faydalıdır. Aşağıdaki özellikler [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/) içinde bulunduğu için tüm paragrafı etkiler:
- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) Latin satır kesme kurallarını kontrol eder. Karma metinde değiştirilmesi, komşu Doğu Asya metni ve noktalama işaretlerinin kaydırılma yerini de etkileyebilir.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) Doğu Asya satır kesme kurallarını kontrol eder; bu, bir satırın başındaki ve sonundaki karakterler üzerindeki kısıtlamaları içerir.

Bu kurallar, [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) özelliğinin yerini almaz; bu özellik bir metin çerçevesinde otomatik kaydırmayı etkinleştirir. Bu kurallar, kaydırma gerçekleştiğinde düzeni etkiler; satır sonu karakterleri eklemezler. Açık bir satır sonu, mevcut genişliğe bakılmaksızın paragrafta yeni bir satır oluşturur.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesme özelliğini de açıkça ayarlar ve "line_breaking.pptx" olarak kaydeder. Herhangi bir kuralla deneme yapmak için, diğer ayarları sabit tutarak ilgili özelliğin değerini değiştirin. Örnek, 24 punto Arial ve SimSun kullanır, 160 punto çerçeve genişliği ve sıfır yatay metin çerçevesi kenar boşluğu ayarlar. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) özelliği, metin boyutu ve çerçeve boyutlarının sabit kalmasını sağlamak için [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) olarak ayarlanmıştır.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 160, 300)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "中文排版测试，PowerPoint 中文演示。"

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.east_asian_font = slides.FontData("SimSun")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.latin_line_break = slides.NullableBool.FALSE
    paragraph_format.east_asian_line_break = slides.NullableBool.TRUE

    presentation.save("line_breaking.pptx", slides.export.SaveFormat.PPTX)
```

## **Asılı Noktalama İşaretlerini Kontrol Et**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) uygun noktalama işaretlerinin, bir sonraki satırı doldurmak yerine, metin satırının sağ kenarını aşmasına izin verir. Bu ayar tüm paragrafı etkiler ve asılı girintiden farklıdır.

Aşağıdaki bağımsız örnek, 100 punto genişliğinde bir metin çerçevesinde asılı noktalama işaretlerini etkinleştirir ve "hanging_punctuation.pptx" olarak kaydeder. 24 punto Arial ve sıfır yatay metin çerçevesi kenar boşluğu ile, son nokta "sentence" kelimesinden sonra kalır ve sağ metin kenarını aşar. Özelliği [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) olarak ayarlayarak karşılaştırabilirsiniz: bu ayarla nokta ayrı bir satırda yer alır. Kaydırma etkin ve otomatik sığdırma devre dışı bırakılmıştır, böylece mevcut genişlik sabit kalır.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 100, 200)
    shape.fill_format.fill_type = slides.FillType.NO_FILL

    text_frame = shape.text_frame
    text_frame.text_frame_format.wrap_text = slides.NullableBool.TRUE
    text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
    text_frame.text_frame_format.margin_left = 0
    text_frame.text_frame_format.margin_right = 0

    paragraph = text_frame.paragraphs[0]
    paragraph.text = "Simple text, next sentence."

    paragraph_format = paragraph.paragraph_format
    paragraph_format.alignment = slides.TextAlignment.LEFT
    paragraph_format.default_portion_format.font_height = 24
    paragraph_format.default_portion_format.latin_font = slides.FontData("Arial")
    paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph_format.hanging_punctuation = slides.NullableBool.TRUE

    presentation.save("hanging_punctuation.pptx", slides.export.SaveFormat.PPTX)
```

Her noktalama işareti asılı olamaz. Görünür sonuç, [font ve düzen koşullarına](#control-line-breaking) bağlıdır; yazı tipini, kullanılabilir genişliği, kenar boşluklarını veya otomatik sığdırma ayarlarını değiştirerek görünür fark ortadan kalkabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarla**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) metin, kapsayıcısının sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülüp küçülmeyeceğini, taşma yapıp yapmayacağını veya şeklin otomatik olarak yeniden boyutlandırılıp boyutlandırılmayacağını kontrol etmek için kullanın. Aşağıdaki örnek, şekli metnine uyacak şekilde yeniden boyutlandırır ve sonucu "autofit_type.pptx" olarak kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Otomatik kaydırmadan sonra satırları saymak ve metin ya da şekil genişliğinin sonucu nasıl etkilediğini görmek için, [Count Rendered Lines](/slides/tr/python-net/manage-paragraph/) sayfasına bakın. Satır sayısı yalnızca metnin kapsayıcısını aşmadığını göstermez.

## **Metin Çerçevelerinin Sabitlemesini Ayarla**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) bir şeklin içinde metnin dikey konumunu, örneğin üst, orta veya alt gibi, tanımlar. Aşağıdaki örnek, metni ilk şeklin altına sabitler ve sonucu "text_anchor.pptx" olarak kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Metin Sekmelerini Ayarla**

[ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) ve [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) kullanarak bir paragraftaki sek duraklarını yapılandırabilirsiniz. Aşağıdaki örnek varsayılan sek aralığını 100 punto olarak ayarlar ve 30 punto konumunda sola hizalı bir sek durak ekler. Bu ayarlar, sek karakteri içeren metni etkiler.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    paragraph.paragraph_format.default_tab_size = 100
    paragraph.paragraph_format.tabs.add(30, slides.TabAlignment.LEFT)

    presentation.save("paragraph_tabs.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Paragraf sekmeleri](paragraph_tabs.png)

## **Denetleme Dilini Ayarla**

Aspose.Slides, bir metin bölümü için denetleme dilini ayarlamanızı sağlayan [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) sunar. Denetleme dili, PowerPoint'teki yazım ve dilbilgisi denetimlerinde kullanılan dili belirler.

Aşağıdaki örnek, "presentation.pptx" içinde ilk slaydın ilk şekli olarak bir metin kutusu ve en az bir paragraf gerektirir. İlk paragrafın içeriğini "1。" ile değiştirir, SimSun yazı tipini ayarlar ve Basitleştirilmiş Çince denetleme dilini (`zh-CN`) atar. Sonucu "proofing_language.pptx" olarak kaydeder:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    font = slides.FontData("SimSun")

    text_portion = slides.Portion()
    text_portion.portion_format.complex_script_font = font
    text_portion.portion_format.east_asian_font = font
    text_portion.portion_format.latin_font = font

    # Denetim dilini Basitleştirilmiş Çince olarak ayarla.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Varsayılan Dili Ayarla**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) kullanarak bir sunum yüklenirken veya oluşturulurken oluşturulan metinlerin varsayılan dilini tanımlayabilirsiniz. Aşağıdaki örnek, varsayılan metin dili olarak ABD İngilizcesi kullanan bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümünün dilini `en-US` olarak yazdırır.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Yeni bir dikdörtgen şekil ekle ve metin ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # İlk bölümün dilini kontrol et.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Varsayılan Metin Stilini Ayarla**

Sunum düzeyinde varsayılan metin biçimlendirmesini uygulamak için [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/) kullanın.

Aşağıdaki örnek, yeni bir sunumda üst‑seviye paragraflar için varsayılan olarak 14 punto kalın bir yazı tipi ayarlar ve "default_text_style.pptx" olarak kaydeder. Metin, daha spesifik bir biçimlendirme üzerine yazılmadıkça bu varsayılanları miras alabilir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Üst seviye paragraf biçimini al.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **All-Caps (Tam Büyük Harf) Etkisiyle Metni Çıkar**

PowerPoint'te **All Caps** (Tam Büyük Harf) yazı tipi etkisini uygulamak, metnin slaytta büyük harf olarak görünmesini sağlar; orijinal olarak küçük harfle yazılmış olsa bile. Aspose.Slides ile bu tür bir metin bölümü alındığında, kütüphane metni tam olarak girildiği gibi döndürür. Görüntülenen metni eşleştirmek için [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) kontrol edin ve değer `ALL` olduğunda dönen dizeyi büyük harfe dönüştürün.

Bu örnek, ilk slaydın ilk şekli olarak bir metin kutusu içeren "sample2.pptx" dosyasını gerektirir. İlk paragrafın ilk bölümü, aşağıda gösterildiği gibi All Caps etkisi uygulanmış "Hello, Aspose!" içerir.

![All Caps etkisi](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** etkisi uygulanmış metni nasıl çıkaracağınızı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample2.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
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

**Bir slayttaki tablo içinde metni nasıl değiştiririm?**

Bir slayttaki tablodaki metni değiştirmek için [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) kullanın. Hücreler üzerinden döngü yapın ve her hücreyi [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) aracılığıyla güncelleyin; ayrıca paragraf biçimlendirmesini [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) ile ayarlayın.

**PowerPoint slaydındaki metne bir degrade (gradient) renk nasıl uygularım?**

Metne degrade renk uygulamak için [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) kullanın. [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) özelliğini [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) olarak ayarlayın ve ardından degrade duraklarını, yönünü ve şeffaflığını yapılandırın.