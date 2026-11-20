---
title: Python'da Sunum Metnini Biçimlendirme
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
- metin döndürmesi
- döndürme açısı
- metin çerçevesi
- satır aralığı
- otomatik sığdırma özelliği
- metin çerçevesi sabitleme
- metin sekme
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarında Aspose.Slides for Python via .NET kullanarak metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin yerleştirme, sekme durakları ve dil ayarlarını kapsar.

Özel olarak belirtilmedikçe, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slaydındaki ilk şekil bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Slayt ve şekil dizinleri sıfır temellidir. Kalın bölümleri seçen örnekler, kalıtılmış kalın biçimlendirme dahil olmak üzere etkili biçimlendirme kullanır:

![Örnek metin](sample_text.png)

Metin Ara ve Değiştir için bkz. [Metin Ara ve Değiştir](/slides/tr/python-net/search-and-replace-text/).

## **Metin Arka Plan Rengini Ayarlama**

[ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) kullanarak bir paragraf için varsayılan vurgulama rengini ayarlayabilir, veya bireysel metin bölümleri için [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/highlight_color/) kullanabilirsiniz.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Bireysel bölümler üzerindeki açık vurgulama renkleri bu varsayılanın üzerine öncelik alır:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Paragrafın tamamı için vurgulama rengini ayarlayın.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için arka plan renginin nasıl ayarlanacağını gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Metin bölümünün vurgulama rengini ayarlayın.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizalama**

[ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) kullanarak bir metin çerçevesi içinde paragraf hizalamasını ayarlayabilirsiniz. Değer; ortalanmış, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamayı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Paragrafın hizalamasını ortaya ayarlayın.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Satır İçinde Yazı Tiplerini Hizalama**

[ParagraphFormat.font_alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/font_alignment/) kullanarak bir satır içinde farklı yazı tipi boyutlarına sahip metin bölümlerini dikey olarak hizalayabilirsiniz. Bu ayar tüm paragrafı etkiler ve her satırdaki hizalamayı kontrol eder.

Aşağıdaki bağımsız örnek, bir slaytta dört etiketli metin kutusu oluşturur. Her paragraf aynı metni 18, 36 ve 54 puan boyutunda içerir ve farklı bir yazı tipi hizalaması kullanır. Arial kullanır, otomatik sığdırma ve kaydırmayı devre dışı bırakır ve metin çerçevelerini tek satır için yeterli büyüklükte tutar.

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

![Karışık yazı tipi boyutlarıyla Alt Çizgi, Üst, Orta ve Alt yazı tipi hizalamasının karşılaştırması](font_alignment.png)

Yazı tipi hizalaması yazı tipi metriklerini kullanır, bu nedenle bireysel harflerin görünür kenarları tam olarak hizalanmayabilir. Örnek, büyük harf ve bir alt karakter içerir ve alt çizgi ile alt hizalama arasındaki farkı göstermek için tasarlanmıştır. Yazı tipi kullanılabilirliği ve yer değiştirme, kullanılan karakterler ve yazı tipi boyutları farkı etkiler. Çerçeve boyutları, kenar boşlukları, satır aralığı, kaydırma ve otomatik sığdırma da yerleşimi etkiler; modları karşılaştırırken aynı yazı tiplerini ve yerleşim ayarlarını kullanın.

Bu ayar, yatay paragraf hizalamasını kontrol eden [ParagraphFormat.alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) ve şeklin içinde metin bloğunu dikey konumlandıran [TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) ayarlarından farklıdır. [BasePortionFormat.escapement](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/escapement/) aracılığıyla üst simge ve alt simge biçimlendirmesi, paragrafın satırları için yazı tipi hizalaması ayarlamak yerine, bireysel bölümleri alt çizgisine göre kaydırır.

## **Metin Şeffaflığını Ayarlama**

Metin şeffaflığı, [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/)’a atanan rengin alfa bileşeniyle kontrol edilir. Aşağıdaki örneklerde `alpha = 50` 0–255 ölçeğinde bir ARGB alfa kanalı değeridir, yüzde olarak şeffaflık değildir.

Aşağıdaki kod örneği, **tüm paragraf** için şeffaflığın nasıl uygulanacağını gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Metin için yarı saydam siyah doldurma ayarlayın.
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
            # Metin bölümünün şeffaflığını ayarlayın.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Şeffaf metin bölümleri](transparent_text_portions.png)

## **Metin Karakter Aralığını Ayarlama**

[BasePortionFormat.spacing](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/spacing/) kullanarak bir metin kutusundaki karakterler arasındaki boşluğu genişletebilir veya sıkıştırabilirsiniz. Örnekler 3 puan boşluk ekler; negatif değerler metni sıkıştırır.

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

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için karakter aralığını nasıl genişleteceğinizi gösterir:

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

### **Belirli Yazı Tipleri İçin Kerning'i Devre Dışı Bırakma**

Bazi durumlarda, Aspose.Slides tarafından işlenen metin, PowerPoint'te gösterilen aynı metinden biraz daha sık görünebilir. Bu, PowerPoint'in belirli yazı tipleri için kerning verilerini görmezden gelmesinden kaynaklanabilir; hatta yazı tipinde geçerli kerning bilgileri ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu durumlarda işlenen çıktıyı PowerPoint'e daha yakın hâle getirmek için, etkilenen yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) değerini gerçek yazı tipi boyutundan daha büyük bir değere ayarlayın. Bu örnek, ilk slaytın ilk şekli olarak bir metin kutusu içeren "presentation.pptx" gerektirir. Etkili yazı tipi adlarını (kalıtılanları da) kontrol eder ve Roboto kullanan bölümler için 100 puan eşik değeri belirler. Bu, 100 puanın altında boyuta sahip eşleşen bölümler için kerning'i devre dışı bırakır:

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

Eşik değerinin altında eşleşen metinler için bu ayar kerning'i engeller ve PowerPoint'e özgü bu davranıştan etkilenen yazı tipleri için Aspose.Slides işleme çıktısını PowerPoint'in görsel çıktısıyla hizalamaya yardımcı olur.

## **Metin Yazı Tipi Özelliklerini Yönetme**

Yazı tipi özellikleri, paragraf seviyesinde [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/) aracılığıyla veya bireysel bölümler için [PortionFormat](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/) aracılığıyla ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 puan Times New Roman olarak, kalın, italik ve noktalı alt çizgi biçimlendirmesiyle ayarlar. Bireysel bölümlerdeki açık biçimlendirme, bu varsayılanların üzerine öncelik alır.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Paragraf için yazı tipi özelliklerini ayarlayın.
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
            # Metin bölümü için yazı tipi özelliklerini ayarlayın.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Metin bölümleri için yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Yüksekliği Normalizasyonunu Kontrol Etme**

[BasePortionFormat.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/normalise_height/) kullanarak şablon tipografisini yeniden üretirken veya karakter yüksekliği farklarını incelerken normalizasyonu uygulayın. PowerPoint'te normalizasyonun etkinleştirilmesi, metin bölümü içinde karakterlerin görünür yüksekliğini tekdüze hâle getirmek için bireysel karakterleri dikey olarak gerer veya sıkıştırır. Bu, farklı yazı tiplerinde eşit metin yüksekliği garantilemez.

Özelliği, normalizasyonu açıkça etkinleştirmek veya devre dışı bırakmak için [NullableBool.TRUE or FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) olarak ayarlayın. `NullableBool.NOT_DEFINED` yerel ayarı bırakmaz, böylece bölüm değerini, örneğin paragrafın [default_portion_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_portion_format/)’ından devralır. Bu, `False` anlamına gelmez. Çözülmüş Boolean değeri elde etmek için [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) ve [IBasePortionFormatEffectiveData.normalise_height](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseportionformateffectivedata/normalise_height/) okuyun.

Aşağıdaki bağımsız örnek, **Arial**'ın yüklü olmasını gerektirir. 54 puanda aynı büyük harfler, küçük harfler, alt karakterler ve aksanlı karakterleri içeren iki metin bloğu oluşturur. Her iki paragraf da varsayılan olarak normalizasyonu etkinleştirir. Üst bölüm bunu açıkça devre dışı bırakır; alt bölüm devralır. Çerçeve boyutları, kenar boşlukları ve paragraf aralıkları aynı olup, karşılaştırmanın tutarlı kalması için kaydırma ve otomatik sığdırma devre dışı bırakılmıştır. Örnek `FALSE: False` ve `NOT_DEFINED: True` çıktısını verir, ardından "text_height_normalization.pptx" dosyasını kaydeder.

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

Aşağıdaki karşılaştırma, kaydedilen sunumdan dışa aktarılmıştır. Üst satırda normalizasyon devre dışı bırakılmıştır (`FALSE`); alt satır ise etkin ayarı devralır (`NOT_DEFINED` → `True`). Bu görünümü yeniden üretmek için Arial'ı kurulu tutun.

![Arial 54 puan metin, üstte normalizasyon devre dışı, altta devralınan normalizasyon etkin](text_height_normalization.png)

Normalizasyon, atanan [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) değerini (yazı tipi boyutunu puan olarak belirten) değiştirmeden karakter yüksekliğini değiştirir. Paragraf [space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) satır aralığını kontrol eder, metin çerçevesi [autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) ise metnin veya kapsayıcısının nasıl sığdırılacağını kontrol eder. Bu ayarlar farklı amaçlara hizmet eder ve genel yerleşimi bağımsız olarak etkileyebilir. Paragraf biçimlendirme ve kalıtım hakkında daha fazla bilgi için [Paragrafı Yönet](/slides/tr/python-net/manage-paragraph/) bölümüne bakın.

## **Üstü Çizili Biçimini Uygulama ve Kaldırma**

[BasePortionFormat.strikethrough_type](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/strikethrough_type/)'ı bir metin bölümünde değişiklikleri, iptal edilen terimleri veya önceki fiyatları, orijinal metni silmeden göstermek için kullanın. Metnin üzerinden bir veya iki satır çizmek için [TextStrikethroughType.SINGLE or DOUBLE](https://reference.aspose.com/slides/python-net/aspose.slides/textstrikethroughtype/) ayarlayın.

Üstü çizili özelliğini kaldırmak için `TextStrikethroughType.NONE` atayın. Bu, çevre biçimlendirme üstü çizili belirtiyor olsa bile etkisi açıkça devre dışı bırakır. Buna karşılık, `TextStrikethroughType.NOT_DEFINED` yerel ayarı tanımsız bırakır ve bölümün, örneğin paragraftan, biçimlendirmeyi devralmasına izin verir. Bu, üstü çiziliğin kaldırılacağını garanti etmez. Sonuç biçimlendirmeyi, kalıtılan değerler dahil, okumak için [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) kullanın.

Aşağıdaki bağımsız örnek üç fiyat karşılaştırması oluşturur. Her paragrafta etiket, önceki fiyat ve mevcut fiyat için ayrı bölümler bulunur; böylece sadece önceki fiyat etkilenir. İlk satır üstü çizili uygular ve ardından kaldırır; diğer satırlar tek ve çift üstü çiziliyi korur. Bu özelliği değiştirmek, metni ve diğer biçimlendirmelerini, kalın önceki fiyat dahil, korur.

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

    # Üstü çizili uygulayın, ardından ilk önceki fiyatın üzerindeki üstü çiziliyi açıkça kaldırın.
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[0].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.NONE

    paragraphs[1].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.SINGLE
    paragraphs[2].portions[1].portion_format.strikethrough_type = slides.TextStrikethroughType.DOUBLE

    presentation.save("strikethrough.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç, üstten alta: üstü çizili olmayan, tek çizili ve çift çizili.

![Üstü çizili olmayan önceki fiyatlar, tek üstü çizili ve çift üstü çizili](strikethrough.png)

## **Metin Döndürmeyi Ayarlama**

[TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/) kullanarak bir şekil içinde önceden tanımlı bir metin yönelimi ayarlayın.

Aşağıdaki kod örneği, şekildeki metin yönelimini [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/python-net/aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

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

## **Metin Çerçeveleri İçin Özel Döndürmeyi Ayarlama**

[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) kullanarak bir [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) için özel bir döndürme açısı ayarlayın.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini 3 derece saat yönünde döndürür:

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

## **Paragrafların Satır Aralığını Ayarlama**

Aspose.Slides, paragraf aralığını kontrol etmek için [ParagraphFormat.space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) ve [ParagraphFormat.space_within](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_within/) sağlar. Bu özellikler şu şekilde kullanılır:

* Satır aralığını satır yüksekliğinin yüzdesi olarak belirlemek için pozitif bir değer kullanın.
* Satır aralığını puan cinsinden belirlemek için negatif bir değer kullanın.

Aşağıdaki örnek, ilk paragrafta satır aralığını satır yüksekliğinin %200’ü (çift satır aralığı) olarak ayarlar:

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

## **Satır Kesintisini Kontrol Etme**

Paragraf satır kesintisi kuralları, dar metin bloklarında ve Latin ile Doğu Asya metninin karıştığı sunumlarda kullanışlıdır. Aşağıdaki özellikler [ParagraphFormat](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/)’a aittir, bu yüzden tüm paragrafı etkiler:

- [latin_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/latin_line_break/) Latin satır kesintisi kurallarını kontrol eder. Karışık metinde değiştirilmesi, bitişik Doğu Asya metni ve noktalama işaretlerinin kaydırılma yerini de etkileyebilir.
- [east_asian_line_break](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/east_asian_line_break/) Doğu Asya satır kesintisi kurallarını kontrol eder, satır başı ve sonundaki karakterlerle ilgili kısıtlamaları içerir.

Bu kurallar, bir metin çerçevesi içinde otomatik kaydırmayı etkinleştiren [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/wrap_text/) yerine geçmez. Kaydırma gerçekleştiğinde yerleşimi etkiler; satır sonu karakteri eklemezler. Açık bir satır sonu, mevcut genişlikten bağımsız olarak paragrafta yeni bir satır oluşturur.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesintisi özelliğini açıkça ayarlar ve "line_breaking.pptx" olarak kaydeder. Herhangi bir kuralla deneme yapmak için, diğer ayarları aynı tutarak o özelliğin değerini değiştirin. Örnek, 24 puan Arial ve SimSun kullanır, 160 puan çerçeve genişliği ve sıfır yatay metin çerçevesi kenar boşluğu ile. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) [TextAutofitType.NONE](https://reference.aspose.com/slides/python-net/aspose.slides/textautofittype/) olarak ayarlanmıştır, böylece metin boyutu ve çerçeve boyutları sabit kalır.

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

## **Asılı Noktalama İşaretlerini Kontrol Etme**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/hanging_punctuation/) uygun noktalama işaretlerinin bir sonraki satırı işgal etmek yerine metin satırının sağ kenarını aşmasına izin verir. Tüm paragrafta uygulanır ve asılı girintiden farklıdır.

Aşağıdaki bağımsız örnek, 100 puan genişliğinde bir metin çerçevesinde asılı noktalama işaretini etkinleştirir ve "hanging_punctuation.pptx" olarak kaydeder. 24 puan Arial ve sıfır yatay metin çerçevesi kenar boşluğu ile, son nokta "sentence" kelimesinin ardından kalır ve sağ metin kenarını aşar. Karşılaştırmak için özelliği [NullableBool.FALSE](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/) olarak ayarlayın; bu ayarlarla nokta ayrı bir satır alır. Kaydırma etkin, otomatik sığdırma devre dışı bırakılmıştır, böylece kullanılabilir genişlik sabit kalır.

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

Her noktalama işareti asılı kalamaz. Görünür sonuç [yazı tipi ve yerleşim koşullarına](#control-line-breaking) bağlıdır; yazı tipini, kullanılabilir genişliği, kenar boşluklarını veya otomatik sığdırma ayarlarını değiştirmek görünür farkı ortadan kaldırabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarlama**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/autofit_type/) bir metin konteyner sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülüp küçülmeyeceğini, taşma yapıp yapmayacağını veya şeklin otomatik olarak yeniden boyutlandırılıp boyutlandırılmayacağını kontrol etmek için kullanın. Aşağıdaki örnek, şekli metnine sığacak şekilde yeniden boyutlandırır ve sonucu "autofit_type.pptx" olarak kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Otomatik kaydırma sonrası satırları saymak ve metin ya da şekil genişliğinin sonucu nasıl etkilediğini görmek için [Oluşturulan Satırları Sayma](/slides/tr/python-net/manage-paragraph/) bölümüne bakın. Satır sayısı tek başına metnin konteyneri aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Sabit Noktasını Ayarlama**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/anchoring_type/) bir şekil içinde metnin dikey konumunu tanımlar; örneğin üst, orta veya alt. Aşağıdaki örnek, metni ilk şeklin altına sabitler ve sonucu "text_anchor.pptx" olarak kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Metin Sekme Duraklarını Ayarlama**

[ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/default_tab_size/) ve [ParagraphFormat.tabs](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/tabs/) kullanarak bir paragrafta sekme duraklarını yapılandırın. Aşağıdaki örnek, varsayılan sekme aralığını 100 puana ayarlar ve 30 puanda sola hizalı bir sekme durak ekler. Bu ayarlar, sekme karakteri içeren metni etkiler.

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

## **Denetleme Dilini Ayarlama**

Aspose.Slides, bir metin bölümü için denetleme dilini ayarlamanızı sağlayan [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) sunar. Denetleme dili, PowerPoint'te imla ve dilbilgisi denetiminde kullanılan dili belirler.

Aşağıdaki örnek, ilk slaytın ilk şekli olarak bir metin kutusu ve en az bir paragraf içeren "presentation.pptx" dosyasını gerektirir. İlk paragrafın içeriğini "1。" ile değiştirir, yazı tipini SimSun olarak ayarlar ve Basitleştirilmiş Çince denetleme dilini (`zh-CN`) atar. Sonucu "proofing_language.pptx" olarak kaydeder:

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

    # Denetleme dilini Basitleştirilmiş Çince olarak ayarlayın.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

### **Dil Meta Verilerini Kopyala**

Bir şablondan çok dilli metni kopyalarken, hem [BasePortionFormat.language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/language_id/) hem de [BasePortionFormat.alternative_language_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/alternative_language_id/) koruyun. Aşağıdaki bağımsız örnek, dili ABD İngilizcesi ve alternatif dili Fransızca olarak ayarlanan bir kaynak bölümü oluşturur ve metni ve tanımlayıcıları yeni bir sunumdaki bir bölüme kopyalar.

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
    # Kaynağın alternatif dili yoksa, None hedef değerini temizler.
    destination.portion_format.alternative_language_id = source.portion_format.alternative_language_id
    paragraph.portions.add(destination)

    presentation.save("copied_language_metadata.pptx", slides.export.SaveFormat.PPTX)
```

Alternatif dil olmayan bir kaynak denemek için "fr-FR" atamasını atlayın. Alternatif tanımlayıcı o zaman `None` olur ve aynı kopyalama ifadesi, hedefte önceden bir alternatif dil atanmış olsa bile, varsayılan bir değer eklemeden eksikliğini korur.

Bu tanımlayıcılar dil meta verisi olarak saklanır. Korunmaları, PowerPoint'in hangi sözlüğü imla veya dilbilgisi denetimi için seçeceğini belirlemez.

## **Varsayılan Dili Ayarlama**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/default_text_language/) bir sunum yüklenirken veya oluşturulurken oluşturulan metin için varsayılan dili tanımlamak için kullanın. Aşağıdaki örnek, varsayılan metin dili ABD İngilizcesi olan bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümü için `en-US` yazdırır.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Metin içeren yeni bir dikdörtgen şekil ekleyin.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # İlk bölüm dilini kontrol edin.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Varsayılan Metin Stili Ayarlama**

Sunum düzeyinde varsayılan metin biçimlendirmesini uygulamak için [Presentation.default_text_style](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/default_text_style/) kullanın.

Aşağıdaki örnek, yeni bir sunumda üst düzey paragraflar için varsayılan olarak 14 puan kalın bir yazı tipi ayarlar ve "default_text_style.pptx" olarak kaydeder. Metin, daha belirgin bir biçimlendirme onu geçersiz kılmadıkça bu varsayılanları devralabilir.

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

## **Tüm Büyük Harf Etkisiyle Metni Çıkarma**

PowerPoint'te **All Caps** (Tüm Büyük Harf) yazı tipi efekti uygulandığında, metin küçük harfle girilmiş olsa bile slaytta büyük harfle görünür. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni tam olarak girildiği şekliyle döndürür. Görüntülenen metinle eşleşmek için [TextCapType](https://reference.aspose.com/slides/python-net/aspose.slides/textcaptype/) kontrol edin ve değer `ALL` olduğunda dönen dizeyi büyük harfe çevirin.

Bu örnek, ilk slaytın ilk şekli olarak bir metin kutusu içeren "sample2.pptx" dosyasını gerektirir. İlk paragrafın ilk bölümü, aşağıdaki gibi All Caps etkisi uygulanmış "Hello, Aspose!" içerir.

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

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **SSS**

**Bir slayttaki tablo içindeki metni nasıl değiştiririm?**

Bir slayttaki tablodaki metni değiştirmek için [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) kullanın. Hücreler arasında döngü yaparak her hücreyi [Cell.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) üzerinden ve paragraf biçimlendirmesini [Paragraph.paragraph_format](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/paragraph_format/) aracılığıyla güncelleyin.

**PowerPoint slaytında metne bir degrade (gradient) renk nasıl uygularım?**

Metne bir degrade renk uygulamak için [BasePortionFormat.fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/fill_format/) kullanın. [FillFormat.fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) değerini [FillType.GRADIENT](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.

İlgili özellik: [Slaytlar içinde metin biçimlendirme](/slides/tr/features/text-formatting/).