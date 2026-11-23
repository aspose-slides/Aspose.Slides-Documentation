---
title: Python'da Sunum Metni Biçimlendirme
linktitle: Metin Biçimlendirme
type: docs
weight: 50
url: /tr/python-net/text-formatting/
keywords:
- paragraf hizala
- metin stili
- metin arka planı
- metin şeffaflığı
- karakter aralığı
- yazı tipi özellikleri
- yazı tipi ailesi
- metin döndürmesi
- döndürme açısı
- metin çerçevesi
- satır aralığı
- otomatik sığdırma özelliği
- metin çerçevesi çapası
- metin sekmesi
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin yerleşimi, sek durakları ve dil ayarlarını kapsar.

Özel bir durum belirtilmedikçe, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slaytındaki ilk şekil bir metin kutusudur ve onun ilk paragrafı aşağıda gösterilen metni içerir. Slayt ve şekil dizinleri sıfır tabanlıdır. Kalın bölümleri seçen örnekler, kalıtılmış kalın biçimlendirme dahil olmak üzere etkili biçimlendirme kullanır:

![Örnek metin](sample_text.png)

Literal metni veya düzenli ifadelerle eşleşenleri bulmak ve vurgulamak için, [Metin Arama ve Değiştirme](/slides/tr/python-net/search-and-replace-text/) sayfasına bakın.

## **Metin Arka Plan Rengini Ayarla**

Bir paragraf için varsayılan vurgulama rengini ayarlamak için [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) kullanın; bireysel metin bölümleri için ise [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Bireysel bölümlerde belirtilen vurgulama renkleri bu varsayılanın üzerine yazar:

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

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için arka plan rengini nasıl ayarlayacağınızı gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Metin bölümünün vurgulama rengini ayarla.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizala**

Bir metin çerçevesi içinde paragraf hizalamasını ayarlamak için [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) kullanın. Değer, ortalanmış, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği, paragrafı **ortaya** hizalamanın yolunu gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Paragraf hizalamasını ortaya ayarla.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Satır İçinde Yazı Tiplerini Hizala**

Satır içindeki farklı yazı tipi boyutlarına sahip metin bölümlerini dikey olarak hizalamak için [ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) kullanın. Bu ayar tüm paragraf için geçerlidir ve her satırındaki hizalamayı kontrol eder.

Aşağıdaki bağımsız örnek, tek bir slaytta dört etiketli metin kutusu oluşturur. Her paragraf aynı metni 18, 36 ve 54 puan boyutlarıyla, farklı yazı tipi hizalamasıyla içerir. Arial kullanır, otomatik sığdırma ve satır kaydırmayı devre dışı bırakır ve metin çerçevelerini tek satır için yeterince büyük tutar.

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

![Alt ve Üst, Orta ve Alt yazı tipi hizalamasının karışık yazı tipi boyutlarıyla karşılaştırması](font_alignment.png)

Yazı tipi hizalaması yazı tipi metriklerini kullanır, bu nedenle bireysel harflerin görünen kenarları mutlaka tam olarak hizalanmaz. Örnek, farkı göstermek için bir büyük harf ve bir düşen karakter (descender) içerir. Yazı tipi bulunabilirliği ve ikamesi, kullanılan karakterler ve yazı tipi boyutları farkı etkiler. Çerçeve boyutları, kenar boşlukları, satır aralığı, kaydırma ve otomatik sığdırma da yerleşimi etkiler; modları karşılaştırırken aynı yazı tiplerini ve yerleşim ayarlarını kullanın.

Bu ayar, yatay paragraf hizalamasını kontrol eden [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) ve şekil içinde metin bloğunu dikey konumlandıran [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) ayarlarından farklıdır. [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) aracılığıyla üst simge ve alt simge biçimlendirmesi, bireysel bölümleri temel çizgiye göre kaydırır, paragraf satırları için yazı tipi hizalaması ayarlamaz.

## **Metin Şeffaflığını Ayarla**

Metin şeffaflığı, [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/)’e atanan rengin alfa bileşeni aracılığıyla kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, 0–255 ölçeğinde bir ARGB alfa kanalı değeridir, yüzde şeffaflık değildir.

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

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için şeffaflığın nasıl uygulanacağını gösterir:

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

## **Metin Karakter Aralığını Ayarla**

Metin kutusundaki karakterler arasındaki boşluğu genişletmek veya daraltmak için [BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) kullanın. Örnekler 3 puan aralık ekler; negatif değerler metni sıkıştırır.

Aşağıdaki Python kodu, **tüm paragraf** içinde karakter aralığını nasıl genişleteceğinizi gösterir:

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

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** içinde karakter aralığını nasıl genişleteceğinizi gösterir:

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

### **Belirli Yazı Tipleri İçin Kerning’i Devre Dışı Bırak**

Bazen, Aspose.Slides tarafından oluşturulan metin, PowerPoint’teki aynı metinden biraz daha sık görünebilir. Bu, PowerPoint’in bazı yazı tipleri için kerning verisini görmezden gelmesinden kaynaklanabilir; yazı tipi geçerli kerning bilgisine sahip olsa ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu gibi durumlarda, etkilenen yazı tipini kullanan metin bölümleri için kerning’i devre dışı bırakarak çıktıyı PowerPoint’e yakınlaştırabilirsiniz. [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) değerini gerçek yazı tipi boyutundan büyük bir değere ayarlayın. Bu örnek, ilk slaytın ilk şekli olarak bir metin kutusu içeren "presentation.pptx" dosyasını gerektirir. Etkili yazı tipi adlarını, kalıtılmış yazı tipleri dahil, kontrol eder ve Roboto kullanan bölümler için 100 puan eşiği belirler. Bu, 100 puandan küçük bir yazı tipine sahip eşleşen bölümler için kerning’i devre dışı bırakır:

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

Eşiğin altında kalan eşleşen metin için bu ayar kerning’i önler ve bu PowerPoint’e özgü davranıştan etkilenen yazı tipleri için Aspose.Slides rendering’ini PowerPoint’in görsel çıktısına daha yakınlaştırabilir.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) aracılığıyla paragraf düzeyinde veya bireysel bölümler için [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) aracılığıyla ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 puan Times New Roman olarak ayarlar ve kalın, italik ve noktalı alt çizgi biçimlendirmesi ekler. Bireysel bölümlerdeki açık biçimlendirme bu varsayılanların üzerine yazar:

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

Aşağıdaki örnek, etkili biçimlendirmesi kalın olan bölümlere 13 puan Times New Roman, italik biçimlendirme ve noktalı alt çizgi uygular:

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

## **Metin Yüksekliği Normalizasyonunu Kontrol Et**

Şablon tipografisini yeniden oluştururken veya karakter yüksekliği farklarını incelerken [BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) kullanın. PowerPoint’te, normalizasyonun etkinleştirilmesi, bireysel karakterleri dikey olarak uzatır veya sıkıştırır ve metin bölümü içinde görünür yüksekliği eşit hale getirir. Farklı yazı tipleri arasında eşit metin yüksekliği garantilemez.

Özelliği, [NullableBool.TRUE veya FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) olarak ayarlayarak normalizasyonu açıkça etkinleştirebilir veya devre dışı bırakabilirsiniz. `NullableBool.NOT_DEFINED` yerel ayarı ayarlamaz, böylece bölüm değerini örneğin paragrafın [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) üzerinden devralır. Bu, `False` anlamına gelmez. Çözümlenen Boolean değeri elde etmek için [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) ve [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) kullanın.

Aşağıdaki bağımsız örnek, **Arial** yüklü olmasını gerektirir. 54 puan boyutunda aynı büyük harfler, küçük harfler, düşen karakterler ve aksanlı karakterler içeren iki metin bloğu oluşturur. Her iki paragraf da varsayılan olarak normalizasyonu etkinleştirir. Üst bölüm bunu açıkça devre dışı bırakır; alt bölüm devralır. Çerçeve boyutları, kenar boşlukları ve paragraf aralığı aynı olup, kaydırma ve otomatik sığdırma devre dışı bırakılarak karşılaştırma tutarlı tutulur. Örnek `FALSE: False` ve `NOT_DEFINED: True` çıktılar verir, ardından "text_height_normalization.pptx" dosyasını kaydeder.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    settings = [slides.NullableBool.FALSE, slides.NullableBool.NOT_DEFINED]

    for i, setting in enumerate(settings):
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 30, 60 + i * 200, 660, 150)
        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        text_frame = shape.text_frame
        text_frame.text = "Hxgjpq ÅÉ 0123"
        text_frame.text_frame_format.autofit_type = slides.TextAutofitType.NONE
        text_frame.text_frame_format.wrap_text = slides.NullableBool.FALSE
        text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        text_frame.text_frame_format.margin_top = 0
        text_frame.text_frame_format.margin_left = 0

        paragraph = text_frame.paragraphs[0]
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        paragraph.paragraph_format.space_within = 100
        paragraph.paragraph_format.default_portion_format.normalise_height = slides.NullableBool.TRUE

        portion = paragraph.portions[0]
        portion.portion_format.latin_font = slides.FontData("Arial")
        portion.portion_format.font_height = 54
        portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion.portion_format.fill_format.solid_fill_color.color = "black"
        portion.portion_format.normalise_height = setting

        print(f"{setting.name}: {portion.portion_format.get_effective().normalise_height}")

    presentation.save("text_height_normalization.pptx", slides.export.SaveFormat.PPTX)
```

Aşağıdaki karşılaştırma, kaydedilen sunumdan dışa aktarılmıştır. Üst satırda normalizasyon devre dışı bırakılmıştır (`FALSE`); alt satırda etkin ayar (`NOT_DEFINED` → `True`) devralınmıştır. Bu görünümü yeniden üretmek için Arial yüklü olmalıdır.

![Arial 54-puan metin, üstte normalizasyon devre dışı ve altta devralınmış normalizasyon etkin](text_height_normalization.png)

Normalizasyon, atanan [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) değerini değiştirmeden karakter yüksekliğini değiştirir; bu değer puan cinsinden yazı tipi boyutunu belirtir. Paragraf [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) satır aralığını kontrol ederken, metin çerçevesi [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) metnin veya kapsayıcının nasıl ayarlanacağını belirler. Bu ayarlar farklı amaçlar taşır ve genel yerleşimi bağımsız olarak etkileyebilir. Paragraf biçimlendirme ve kalıtım hakkında daha fazla bilgi için [Manage Paragraph](/slides/tr/python-net/manage-paragraph/) sayfasına bakın.

## **Üstü Çizgiyi Uygula ve Kaldır**

Bir metin bölümünde düzeltmeleri, iptal edilen terimleri veya önceki fiyatları silmeden göstermek için [BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/) kullanın. Metnin üzerinden tek veya çift çizgi çizmek için [TextStrikethroughType.SINGLE veya DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) ayarlayın.

Üstü çizgiyi kaldırmak için `TextStrikethroughType.NONE` atayın. Bu, çevreleyen biçimlendirme üstü çizgiyi içeriyor olsa bile etkisini açıkça devre dışı bırakır. Bunun aksine, `TextStrikethroughType.NOT_DEFINED` yerel ayarı tanımsız bırakır ve bölümün örneğin paragraftan biçimlendirme devralmasına izin verir. Bu, üstü çizginin kaldırılmasını garantilemez. Sonuç biçimlendirmeyi, kalıtılmış değerler dahil, okumak için [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) kullanın.

Aşağıdaki bağımsız örnek, üç fiyat karşılaştırması oluşturur. Her paragraf etiket, önceki fiyat ve güncel fiyat için ayrı bölümler içerir; böylece yalnızca önceki fiyat etkilenir. İlk satır üstü çizgiyi uygular ve ardından kaldırır; diğer satırlar tek ve çift üstü çizgiyi korur. Bu özelliği değiştirmek, metni ve diğer biçimlendirmeleri, kalın önceki fiyat dahil, korur.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 620, 220)
    shape.fill_format.fill_type = slides.FillType.NO_FILL
    shape.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    shape.text_frame.paragraphs.clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = slides.Paragraph()
        paragraph.paragraph_format.alignment = slides.TextAlignment.LEFT
        paragraph.paragraph_format.space_after = 20

        portion_format = paragraph.paragraph_format.default_portion_format
        portion_format.font_height = 28
        portion_format.latin_font = slides.FontData("Arial")
        portion_format.fill_format.fill_type = slides.FillType.SOLID
        portion_format.fill_format.solid_fill_color.color = draw.Color.black

        paragraph.portions.add(slides.Portion(label))

        previous_price = slides.Portion("$100")
        previous_price.portion_format.font_bold = slides.NullableBool.TRUE
        paragraph.portions.add(previous_price)
        paragraph.portions.add(slides.Portion(" → $80"))

        shape.text_frame.paragraphs.add(paragraph)

    paragraphs = shape.text_frame.paragraphs

    # Üstü çizgiyi uygula, ardından ilk önceki fiyatın üzerindeki üstü çizgiyi açıkça kaldır.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç, üstten aşağıya: üstü çizgi yok, tek üstü çizgi ve çift üstü çizgi.

![Üstü çizgi olmayan, tek üstü çizgili ve çift üstü çizgili önceki fiyatlar](strikethrough.png)

## **Metin Döndürmeyi Ayarla**

Şekil içinde önceden tanımlı bir metin yönelimi ayarlamak için [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) kullanın.

Aşağıdaki kod örneği, şekil içindeki metin yönelimini [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

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

## **Dikey Metinde Rakamları Yan Yana Göster**

Dikey bir Japon etikette iki basamaklı bir sayıyı birlikte tutmak için, her iki rakamı tek bir metin bölümü içinde yerleştirin ve o bölümde [BasePortionFormat.kumimoji](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kumimoji/) ayarlayın. Örnek, [TextVerticalType.EAST_ASIAN_VERTICAL](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) ve 40 puan MS Gothic kullanan yeni bir sunumda iki etiket oluşturur. Sayısal bölüme atanan [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) değeri farklıdır.

```python
import aspose.slides as slides


def add_label(slide, x, kumimoji):
    label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 48, 120, 420)
    label.fill_format.fill_type = slides.FillType.NO_FILL
    label.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    frame = label.add_text_frame("")
    frame.text_frame_format.text_vertical_type = slides.TextVerticalType.EAST_ASIAN_VERTICAL

    paragraph = frame.paragraphs[0]
    portion_format = paragraph.paragraph_format.default_portion_format
    font = slides.FontData("MS Gothic")
    portion_format.latin_font = font
    portion_format.east_asian_font = font
    portion_format.font_height = 40
    portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion_format.fill_format.solid_fill_color.color = "black"

    digits = slides.Portion("12")
    digits.portion_format.kumimoji = kumimoji

    paragraph.portions.clear()
    paragraph.portions.add(slides.Portion("令和"))
    paragraph.portions.add(digits)
    paragraph.portions.add(slides.Portion("年"))


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    add_label(slide, 120, slides.NullableBool.TRUE)
    add_label(slide, 360, slides.NullableBool.FALSE)
    
    presentation.save("vertical_date.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint’te sol etiket (`TRUE`) rakamları dik ve 和 ile 年 arasına yan yana gösterirken, sağ etiket (`FALSE`) rakamları 90 derece saat yönünde döndürür. Çevreleyen Japon karakterler her iki etikette de dik kalır.

![Dikey tarih etiketlerinin PowerPoint karşılaştırması; solda dik rakamlar, sağda döndürülmüş rakamlar.](vertical_date.png)

## **Metin Çerçeveleri İçin Özel Döndürme Ayarla**

[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) kullanarak bir [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) için özel bir döndürme açısı ayarlayın.

Aşağıdaki kod örneği, metin çerçevesini şekil içinde 3 derece saat yönünde döndürür:

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

Aspose.Slides, paragraf aralığını kontrol etmek için [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) ve [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) özelliklerini sağlar. Bu özellikler şu şekilde kullanılır:

- Pozitif bir değer, satır aralığını satır yüksekliğinin yüzdesi olarak belirtir.
- Negatif bir değer, satır aralığını puan cinsinden belirtir.

Aşağıdaki örnek, ilk paragraftaki boşluğu satır yüksekliğinin %200’üne (çift satır aralığı) ayarlar:

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

Paragraf satır kesme kuralları, dar metin bloklarında ve Latin ile Doğu Asya metinlerinin karıştığı sunumlarda faydalıdır. Aşağıdaki özellikler [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/)’a aittir, bu nedenle tüm paragraf için geçerlidir:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) Latin satır kesme kurallarını kontrol eder. Karışık metinde değiştirilmesi, bitişik Doğu Asya metin ve noktalama işaretlerinin kaydırılma noktalarını da etkileyebilir.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) Doğu Asya satır kesme kurallarını kontrol eder; satır başı ve sonundaki karakterlere yönelik kısıtlamaları içerir.

Bu kurallar, otomatik kaydırmayı etkinleştiren [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) işlevinin yerini almaz; sadece kaydırma gerçekleştiğinde yerleşimi etkiler, yeni satır karakterleri eklemez. Açık bir satır kesmesi, paragraf içinde mevcut genişliğinden bağımsız olarak yeni bir satır başlatır.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesme özelliğini açıkça ayarlar ve "line_breaking.pptx" dosyasını kaydeder. Herhangi bir kuralı denemek için, diğer ayarları sabit tutarak o özelliğin değerini değiştirin. Örnek, 24 puan Arial ve SimSun, 160 puan çerçeve genişliği ve sıfır yatay metin çerçeve kenar boşluğu kullanır. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) olarak ayarlanmıştır, böylece metin boyutu ve çerçeve boyutları sabit kalır.

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

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) uygun noktalama işaretlerinin metin satırının sağ kenarının ötesine uzanmasını sağlar; bir asılı girinti değildir ve tüm paragraf için geçerlidir.

Aşağıdaki bağımsız örnek, 100 puan genişliğindeki bir metin çerçevesinde asılı noktalama işaretlerini etkinleştirir ve "hanging_punctuation.pptx" dosyasını kaydeder. 24 puan Arial ve sıfır yatay metin çerçeve kenar boşluğu ile, son nokta "sentence" kelimesinden sonra kalır ve sağ metin kenarının ötesine uzanır. Özelliği [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) olarak ayarlayarak karşılaştırma yapılabilir: bu ayarlarla nokta ayrı bir satırda yer alır. Kaydırma etkin ve otomatik sığdırma devre dışı bırakılmıştır, böylece kullanılabilir genişlik sabit kalır.

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

Her noktalama işareti asılı kalamaz. Görünür sonuç, [yazı tipi ve yerleşim koşullarına](#control-line-breaking) bağlıdır; yazı tipini, kullanılabilir genişliği, kenar boşluklarını veya otomatik sığdırma ayarlarını değiştirmek görünür farkı ortadan kaldırabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Tipini Ayarla**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) metnin kapsayıcısının sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülmesi, taşması veya şeklin otomatik olarak yeniden boyutlandırılması gibi davranışları kontrol etmek için kullanılır. Aşağıdaki örnek, şekli metnine göre yeniden boyutlandıracak şekilde yapılandırır ve sonucu "autofit_type.pptx" dosyasına kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Otomatik kaydırmadan sonra satırları saymak ve metin veya şekil genişliğinin sonucu nasıl etkilediğini görmek için, [Render Edilen Satırları Say](/slides/tr/python-net/manage-paragraph/) sayfasına bakın. Tek başına satır sayısı, metnin kapsayıcısını aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Çapasını Ayarla**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) bir şekil içinde metnin dikey konumlandırılmasını tanımlar; örneğin üst, orta veya alt gibi. Aşağıdaki örnek, metni ilk şeklin altına çapa yapar ve sonucu "text_anchor.pptx" dosyasına kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Metin Sekme Ayarını Yap**

[ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) ve [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) kullanarak bir paragrafta sek duraklarını yapılandırabilirsiniz. Aşağıdaki örnek, varsayılan sek aralığını 100 puana ayarlar ve 30 puanda sol hizalı bir sek durak ekler. Bu ayarlar sek karakteri içeren metni etkiler.

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

## **Düzeltme Dilini Ayarla**

Aspose.Slides, bir metin bölümünün düzeltme dilini ayarlamanızı sağlayan [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) özelliğini sunar. Düzeltme dili, PowerPoint’te imla ve dilbilgisi denetimi için kullanılan dili belirler.

Aşağıdaki örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren "presentation.pptx" dosyasını ve en az bir paragrafı gerektirir. İlk paragrafın içeriğini "1。" olarak değiştirir, fontunu SimSun olarak ayarlar ve basitleştirilmiş Çince düzeltme dilini (`zh-CN`) atar. Sonucu "proofing_language.pptx" dosyasına kaydeder:

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

    # Düzeltme dilini Basitleştirilmiş Çince olarak ayarla.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Dil Metaverisini Kopyala**

Bir şablondan çok dilli metin kopyalarken, hem [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) hem de [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/) değerlerini koruyun. Aşağıdaki bağımsız örnek, kaynak bölümde US English dilini ve French alternatif dilini ayarlar ve metni ve tanımlayıcıları yeni bir sunumdaki bir bölüme kopyalar.

```python
import aspose.slides as slides

source = slides.Portion("Hello! Bonjour!")
source.portion_format.language_id = "en-US"
source.portion_format.alternative_language_id = "fr-FR"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    destination = slides.Portion()
    destination.text = source.text
    destination.portion_format.language_id = source.portion_format.language_id
    # Eğer kaynakta alternatif dil yoksa, None hedef değerini temizler.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

Alternatif dil olmadan bir kaynağı denemek için, "fr-FR" atamasını atlayın. Alternatif tanımlayıcı o zaman `None` olur ve aynı kopya ifadesi, hedefte daha önce bir alternatif dil atanmış olsa bile, varsayılan bir değer eklemeden yokluğunu korur.

Bu tanımlayıcılar dil metaverisi olarak saklanır. Bunların korunması, PowerPoint’in hangi sözlükle imla veya dilbilgisi denetimi yapacağını belirlemez.

## **Varsayılan Dili Ayarla**

Sunum yüklenirken veya oluşturulurken oluşturulan metin için varsayılan dili tanımlamak üzere [LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) kullanın. Aşağıdaki örnek, varsayılan metin dili olarak US English ayarlayan bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümünün `en-US` değerini yazdırır.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Yeni bir dikdörtgen şekil ve metin ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # İlk bölüm dilini kontrol et.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Varsayılan Metin Stili Ayarla**

Sunum düzeyinde varsayılan metin biçimlendirmesini uygulamak için [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/) kullanın.

Aşağıdaki örnek, yeni bir sunumda üst düzey paragraflar için varsayılan olarak 14 puan kalın bir yazı tipi ayarlar ve "default_text_style.pptx" dosyasına kaydeder. Metin, daha spesifik bir biçimlendirme bunların üzerine yazmadıkça bu varsayılanları devralabilir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Üst düzey paragraf biçimini al.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **All-Caps Efektiyle Metni Çıkar**

PowerPoint’te **All Caps** (Tüm Büyük Harfler) yazı tipi etkisi uygulandığında, metin slaytta büyük harf olarak görünür, ancak orijinal olarak küçük harfle girilmiş olabilir. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni tam olarak girildiği gibi döndürür. Görüntülenen metinle eşleşmek için [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) kontrol edilmeli ve değer `ALL` olduğunda döndürülen dize büyük harfe dönüştürülmelidir.

Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren "sample2.pptx" dosyasını gerektirir. İlk paragrafın ilk bölümü, aşağıda gösterildiği gibi All Caps etkisi uygulanmış "Hello, Aspose!" içerir.

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

**Bir slayttaki tabloda metni nasıl değiştiririm?**

Bir slayttaki tabloda metni değiştirmek için [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) kullanın. Hücreler arasında döngü yapın ve her hücreyi [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) aracılığıyla güncelleyin; paragraf biçimlendirmesini ise [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) ile yapın.

**PowerPoint slaytındaki metne degrade (gradient) renk nasıl uygularım?**

Metne degrade renk uygulamak için [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) kullanın. [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) değerini [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığı yapılandırın.

İlgili özellik: [Slayt içinde metin biçimlendirme](/slides/tr/features/text-formatting/).