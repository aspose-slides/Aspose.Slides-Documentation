---
title: Python'da Sunum Metnini Biçimlendirme
linktitle: Metin Biçimlendirme
type: docs
weight: 50
url: /tr/python-net/text-formatting/
keywords:
- metni vurgulama
- düzenli ifade
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
- metin çerçevesi sabitlemesi
- metin sekleme
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarındaki metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Vurgulama, arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sek durakları ve dil ayarlarını kapsar.

Aşağıdaki örneklerde, ilk slaytta aşağıdaki metni içeren tek bir metin kutusu bulunan "sample.pptx" adlı dosyayı kullanacağız:

![Örnek metin](sample_text.png)

## **Metni Vurgulama**

Bir metin çerçevesi içinde belirli bir örnekle eşleşen metni vurgulamanız gerektiğinde [TextFrame.highlight_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/highlight_text/) yöntemini kullanın. Bu yöntem, eşleşen metin parçalarına vurgulama rengi uygular ve aramanın nasıl gerçekleştirileceğini kontrol etmek için, örneğin yalnızca tam kelimelerle eşleşecek şekilde, [TextSearchOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textsearchoptions/) ile birlikte kullanılabilir.

Aşağıdaki kod örneği, **"try"** karakterlerinin tüm oluşumlarını vurgular ve ardından yalnızca tam **"to"** kelimesini vurgular.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # İlk slayttan ilk şekli al.
    shape = presentation.slides[0].shapes[0]

    # "try" kelimesini şekil içinde vurgula.
    shape.text_frame.highlight_text("try", draw.Color.light_blue)

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True

    # "to" kelimesini şekil içinde vurgula.
    shape.text_frame.highlight_text("to", draw.Color.violet, search_options, None)

    presentation.save("highlighted_text.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Vurgulanan metin](highlighted_text.png)

## **Düzenli İfadeler Kullanarak Metni Vurgulama**

[TextFrame.highlight_regex](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/highlight_regex/) yöntemi, düzenli ifadeyle bulunan metin eşleşmelerini vurgular. Python'da bu API, [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) üzerinde sunulur.

Aşağıdaki kod örneği, **yedi veya daha fazla karakter** içeren tüm kelimeleri vurgular:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    regex = r"\b[^\s]{7,}\b"

    # Yedi veya daha fazla karaktere sahip tüm kelimeleri vurgula.
    shape.text_frame.highlight_regex(regex, draw.Color.yellow, None)

    presentation.save("highlighted_text_using_regex.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Düzenli ifade kullanılarak vurgulanan metin](highlighted_text_using_regex.png)

## **Metin Arka Plan Rengini Ayarlama**

Bir paragraf için varsayılan vurgulama rengini ayarlamak için [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/default_portion_format/) kullanın, ya da tek tek metin parçaları için [PortionFormat.highlight_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/highlight_color/) kullanın.

Aşağıdaki kod örneği, **tüm paragraf** için arka plan rengini nasıl ayarlayacağınızı gösterir:

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

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin parçaları** için arka plan rengini nasıl ayarlayacağınızı gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Metin parçası için vurgulama rengini ayarla.
            portion.portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Gri metin parçaları](gray_text_portions.png)

## **Metin Paragraflarını Hizalama**

Metin çerçevesi içinde paragraf hizalamasını ayarlamak için [ParagraphFormat.alignment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/alignment/) kullanın. Değer merkezi, sola hizalı, sağa hizalı, iki yana yaslı vb. olabilir.

Aşağıdaki kod örneği, paragrafı **ortaya** hizalamanın nasıl yapılacağını gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Paragraf hizalamasını merkeze ayarla.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Metin Şeffaflığını Ayarlama**

Metin şeffaflığı, [PortionFormat.fill_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/fill_format/)’a atanan rengin alfa bileşeni üzerinden kontrol edilir. Aşağıdaki örneklerde, `alpha = 50` %0‑255 skalasında bir ARGB alfa kanalı değeridir, yüzde şeffaflık değildir.

Aşağıdaki kod örneği, **tüm paragraf** için şeffaflık uygulanmasını gösterir:

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

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin parçaları** için şeffaflık uygulanmasını gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Metin parçasının şeffaflığını ayarla.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Şeffaf metin parçaları](transparent_text_portions.png)

## **Metin Karakter Aralığını Ayarlama**

Bir metin kutusundaki karakterler arasındaki aralığı genişletmek veya sıkıştırmak için [BasePortionFormat.spacing](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/spacing/) kullanın.

Aşağıdaki Python kodu, **tüm paragrafta** karakter aralığını nasıl genişleteceğinizi gösterir:

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

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin parçalarında** karakter aralığını nasıl genişleteceğinizi gösterir:

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

![Metin parçalarındaki karakter aralığı](character_spacing_in_text_portions.png)

### **Belirli Yazı Tipleri İçin Kerning'i Devre Dışı Bırakma**

Bazı durumlarda, Aspose.Slides tarafından render edilen metin, PowerPoint'te görüntülenen aynı metinden biraz daha sık görünebilir. Bu, PowerPoint'in belirli yazı tipleri için kerning verilerini görmezden gelmesinden kaynaklanabilir; hatta yazı tipi geçerli kerning bilgisine sahip olsa ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu gibi durumlarda render edilen çıktıyı PowerPoint'e daha yakın hâle getirmek için, etkilenen yazı tipini kullanan metin parçaları için kerning'i devre dışı bırakabilirsiniz. [PortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) değerini gerçek yazı tipi boyutundan çok daha büyük bir değere ayarlayın:

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

Bu ayar, eşleşen metin parçalarına kerning uygulanmasını engeller ve bu PowerPoint'e özgü davranıştan etkilenen yazı tipleri için Aspose.Slides render'ını PowerPoint'in görsel çıktısına yaklaştırmaya yardımcı olabilir.

## **Metin Yazı Tipi Özelliklerini Yönetme**

Yazı tipi özellikleri, [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/default_portion_format/) aracılığıyla paragraf seviyesinde veya tek tek parçalar için [PortionFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/) üzerinden ayarlanabilir.

Aşağıdaki kod, tüm paragraf için yazı tipi ve metin stilini ayarlar: yazı tipi boyutu, kalın, italik, noktalı alt çizgi ve Times New Roman yazı tipini paragraftaki tüm parçalara uygular.

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

Aşağıdaki kod örneği, **kalın yazı tipine sahip metin parçalarına** benzer özellikler uygular:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Metin parçası için yazı tipi özelliklerini ayarla.
            portion.portion_format.font_height = 13
            portion.portion_format.font_italic = slides.NullableBool.TRUE
            portion.portion_format.font_underline = slides.TextUnderlineType.DOTTED
            portion.portion_format.latin_font = slides.FontData("Times New Roman")

    presentation.save("font_properties_for_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Metin parçaları için yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Döndürmeyi Ayarlama**

Bir şekil içinde önceden tanımlı bir metin yönelimini ayarlamak için [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/text_vertical_type/) kullanın.

Aşağıdaki kod örneği, şeklin içindeki metin yönelimini `VERTICAL270` olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Metin döndürmesi](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürmeyi Ayarlama**

Bir [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) için özel bir döndürme açısı ayarlamak üzere [TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/rotation_angle/) kullanın.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini 3 derece saat yönünde döndürür:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Özel metin döndürmesi](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarlama**

Aspose.Slides, paragraf aralığını kontrol etmek için [ParagraphFormat.space_after](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/space_before/) ve [ParagraphFormat.space_within](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/space_within/) sağlar. Bu özellikler aşağıdaki gibi kullanılır:

* Satır aralığını satır yüksekliğinin yüzdesi olarak belirtmek için pozitif bir değer kullanın.
* Satır aralığını puan cinsinden belirtmek için negatif bir değer kullanın.

Aşağıdaki kod örneği, paragraftaki satır aralığını nasıl belirleyeceğinizi gösterir:

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

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarlama**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/autofit_type/) bir metin kapsayıcısının sınırlarını aştığında metnin nasıl davranacağını belirler. Metnin küçülüp küçülmeyeceğini, taşma yapıp yapmayacağını veya şeklin otomatik olarak yeniden boyutlandırılıp boyutlandırılmayacağını kontrol etmek için kullanın.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

## **Metin Çerçevelerinin Sabitlemesini (Anchor) Ayarlama**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/anchoring_type/) bir şekil içinde metnin dikey olarak nerede konumlandırılacağını tanımlar; örneğin üstte, ortada veya altta.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Metin Sekmelerini Ayarlama**

Bir paragrafta sek duraklarını yapılandırmak için [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/default_tab_size/) ve [ParagraphFormat.tabs](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/tabs/) kullanın.

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

## **Denetleme Dilini Ayarlama**

Aspose.Slides, bir metin parçası için denetleme dilini ayarlamanızı sağlayan [PortionFormat.language_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/language_id/) sunar. Denetleme dili, PowerPoint'te imla ve dilbilgisi denetimlerinde kullanılan dili belirler.

Aşağıdaki kod örneği, bir metin parçası için denetleme dilinin nasıl ayarlanacağını gösterir:

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

    # Denetleme dilinin Id'sini ayarla.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1."
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Varsayılan Dili Ayarlama**

Bir sunumu yüklerken veya oluştururken oluşturulan metin için varsayılan dili tanımlamak üzere [LoadOptions.default_text_language](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/default_text_language/) kullanın.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Metin içeren yeni bir dikdörtgen şekil ekle.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # İlk bölüm dilini kontrol et.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Varsayılan Metin Stili Ayarlama**

Sunum seviyesinde varsayılan metin biçimlendirmesini uygulamak için [Presentation.default_text_style](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/default_text_style/) kullanın.

Aşağıdaki kod örneği, yeni bir sunumdaki tüm slaytlardaki metinler için 14 pt boyutunda varsayılan kalın bir yazı tipi ayarlamayı gösterir.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Üst seviye paragraf formatını al.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **All Caps Etkisiyle Metin Çıkarma**

PowerPoint'te **All Caps** (Tüm Büyük Harf) yazı tipi etkisini uygulamak, metin küçük harfle girilmiş olsa bile slaytta büyük harfle görünmesini sağlar. Aspose.Slides ile böyle bir metin parçasını aldığınızda, kütüphane metni tam olarak girildiği gibi döndürür. Görüntülenen metinle eşleşmek için [TextCapType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textcaptype/) kontrol edin ve değer `ALL` olduğunda döndürülen dizeyi büyük harfe çevirin.

sample2.pptx dosyasının ilk slaytında aşağıdaki metin kutusunun olduğunu varsayalım.

![All Caps etkisi](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** etkisi uygulanmış metnin nasıl çıkarılacağını gösterir:

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

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **SSS**

**Bir slayttaki tabloda metni nasıl değiştirebilirim?**

Bir slayttaki tabloda metni değiştirmek için [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) kullanın. Hücreler arasında dolaşın ve her hücreyi [Cell.text_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cell/text_frame/) aracılığıyla ve paragraf biçimlendirmesini [Paragraph.paragraph_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/paragraph_format/) üzerinden güncelleyin.

**PowerPoint slaytında metne degradeli renk nasıl uygulanır?**

Metne degradeli bir renk uygulamak için [PortionFormat.fill_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/fill_format/) kullanın. [FillFormat.fill_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/fill_type/) değerini [FillType.GRADIENT](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.