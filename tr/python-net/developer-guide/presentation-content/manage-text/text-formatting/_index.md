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
- metin saydamlığı
- karakter aralığı
- yazı tipi özellikleri
- yazı tipi ailesi
- metin döndürme
- döndürme açısı
- metin çerçevesi
- satır aralığı
- otomatik sığdırma özelliği
- metin çerçevesi bağlantı noktası
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

Bu makale, Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında metin biçimlendirmeyi gösterir. Arka plan renkleri, saydama, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin tutturma, sekme durakları ve dil ayarları ele alınmaktadır.

Aşağıdaki örneklerde, ilk slaytta tek bir metin kutusu içeren ve aşağıdaki metni barındıran “sample.pptx” adlı dosyayı kullanacağız:

![Örnek metin](sample_text.png)

Literal metin veya düzenli ifade eşleşmelerini bulmak ve vurgulamak için [Metin Ara ve Değiştir](/slides/tr/python-net/search-and-replace-text/) bölümüne bakınız.

## **Metin Arka Plan Rengini Ayarla**

Bir paragraf için varsayılan vurgulama rengini ayarlamak için [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/default_portion_format/) kullanabilir veya bireysel metin bölümleri için [PortionFormat.highlight_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/highlight_color/) kullanabilirsiniz.

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

Metin çerçevesi içinde paragraf hizalamasını ayarlamak için [ParagraphFormat.alignment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/alignment/) kullanın. Değer, ortalanmış, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamayı gösterir:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Paragrafın hizalamasını ortaya ayarla.
    paragraph.paragraph_format.alignment = slides.TextAlignment.CENTER

    presentation.save("aligned_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Metin İçin Saydamlığı Ayarla**

Metin saydamlığı, [PortionFormat.fill_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/fill_format/) üzerine atanan rengin alfa bileşeni üzerinden kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, 0‑255 ölçeğinde bir ARGB alfa kanalı değeridir, yüzde olarak bir saydamlık değildir.

Aşağıdaki kod örneği **tüm paragraf** için saydamlık uygulamayı gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Metnin dolgu rengini saydam renge ayarla.
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Saydam paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için saydamlık uygulamayı gösterir:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

alpha = 50

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    for portion in paragraph.portions:
        if portion.portion_format.get_effective().font_bold:
            # Metin bölümünün saydamlığını ayarla.
            portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
            portion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(alpha, draw.Color.black)

    presentation.save("transparent_text_portions.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Saydam metin bölümleri](transparent_text_portions.png)

## **Metin İçin Karakter Aralığını Ayarla**

Metin kutusundaki karakterler arasındaki aralığı genişletmek veya daraltmak için [BasePortionFormat.spacing](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/spacing/) kullanın.

Aşağıdaki Python kodu **tüm paragraf** içinde karakter aralığını nasıl genişleteceğinizi gösterir:

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

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** içinde karakter aralığını nasıl genişleteceğinizi gösterir:

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

### **Belirli Yazı Tipleri İçin Kerning’i Devre Dışı Bırak**

Bazı durumlarda Aspose.Slides tarafından oluşturulan metin, PowerPoint’te aynı metnin görüntülendiği kadar geniş olmayabilir. PowerPoint, belirli yazı tipleri için kerning verilerini göz ardı edebilir; bu da yazı tipinde geçerli kerning bilgisi olsa ve PowerPoint ayarlarında kerning etkin olsa bile oluşur.

Böyle bir durumda, etkilenen yazı tipini kullanan metin bölümleri için kerning’i devre dışı bırakabilirsiniz. [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) değerini gerçek yazı tipi boyutundan çok daha büyük bir değere ayarlayın:

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

Bu ayar, eşleşen metin bölümlerine kerning uygulanmasını engeller ve PowerPoint’e özgü bu davranıştan etkilenen yazı tipleri için Aspose.Slides render’ını PowerPoint’in görsel çıktısına daha yakın hâle getirebilir.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/default_portion_format/) üzerinden paragraf düzeyinde veya bireysel bölümler için [PortionFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/) aracılığıyla ayarlanabilir.

Aşağıdaki kod, tüm paragraftaki tüm bölümlere yazı tipi boyutu, kalın, italik, noktalı alt çizgi ve Times New Roman yazı tipini uygular:

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

Şekil içinde önceden tanımlı bir metin yönlendirmesi ayarlamak için [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/text_vertical_type/) kullanın.

Aşağıdaki kod örneği şekildeki metin yönlendirmesini `VERTICAL270` olarak ayarlar; bu da metni **90 derece saat yönünün tersine** döndürür:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Metin döndürme](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürme Ayarla**

[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/rotation_angle/) kullanarak bir [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) için özel bir döndürme açısı ayarlayabilirsiniz.

Aşağıdaki kod örneği metin çerçevesini şekil içinde saat yönünde 3 derece döndürür:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.rotation_angle = 3

    presentation.save("custom_text_rotation.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Özel metin döndürme](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [ParagraphFormat.space_after](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/space_before/) ve [ParagraphFormat.space_within](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/space_within/) özelliklerini sunar. Bu özellikler şu şekilde kullanılır:

* Pozitif bir değer, satır yüksekliğinin yüzde olarak satır aralığını belirtir.
* Negatif bir değer, satır aralığını puan cinsinden belirtir.

Aşağıdaki kod örneği paragraftaki satır aralığını nasıl belirteceğinizi gösterir:

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

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/autofit_type/) metin, kapsayıcısının sınırlarını aştığında nasıl davranacağını belirler. Metnin şekli otomatik olarak küçülmesi, taşması veya şeklin yeniden boyutlandırılması gibi durumları kontrol edebilirsiniz.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Otomatik satır bölünmesinden sonra satır sayısını ve metin veya şekil genişliğinin sonucu nasıl etkilediğini görmek için [Render Edilen Satırları Say](/slides/tr/python-net/manage-paragraph/) bölümüne bakınız. Yalnızca satır sayısı, metnin kapsayıcısını aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Bağlantı Noktasını Ayarla**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/anchoring_type/) bir şekil içinde metnin dikey olarak nasıl konumlandırılacağını tanımlar; örneğin üstte, ortada veya altta.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    auto_shape = presentation.slides[0].shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Metin Sekme Ayarlarını Yapılandır**

Paragraftaki sekme duraklarını yapılandırmak için [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/default_tab_size/) ve [ParagraphFormat.tabs](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/tabs/) kullanın.

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

## **Düzeltme Dilini Ayarla**

Aspose.Slides, bir metin bölümü için düzeltme dilini ayarlamanızı sağlayan [PortionFormat.language_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/language_id/) özelliğini sunar. Düzeltme dili, PowerPoint’te imla ve dilbilgisi denetimlerinde kullanılan dili belirler.

Aşağıdaki kod örneği bir metin bölümü için düzeltme dilini nasıl ayarlayacağınızı gösterir:

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

    # Düzeltme dilinin kimliğini ayarla.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Varsayılan Dili Ayarla**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/default_text_language/) kullanarak bir sunum yüklenirken veya oluşturulurken oluşturulan metnin varsayılan dilini tanımlayabilirsiniz.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en-US"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]

    # Yeni bir dikdörtgen şekil ekle ve metin ata.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 50)
    shape.text_frame.text = "Sample text"

    # İlk bölümün dilini kontrol et.
    portion = shape.text_frame.paragraphs[0].portions[0]
    print(portion.portion_format.language_id)
```

## **Varsayılan Metin Stilini Ayarla**

Sunum düzeyinde varsayılan metin biçimlendirmesi uygulamak için [Presentation.default_text_style](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/default_text_style/) kullanın.

Aşağıdaki kod örneği yeni bir sunumda tüm slaytlardaki metinler için 14 pt boyutunda kalın bir yazı tipi varsayılanı ayarlar.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Üst düzey paragraf formatını al.
    paragraph_format = presentation.default_text_style.get_level(0)

    if paragraph_format is not None:
        paragraph_format.default_portion_format.font_height = 14
        paragraph_format.default_portion_format.font_bold = slides.NullableBool.TRUE

    presentation.save("default_text_style.pptx", slides.export.SaveFormat.PPTX)
```

## **BÜYÜK HARF (All-Caps) Etkisiyle Metin Çıkar**

PowerPoint’te **All Caps** (Tüm Büyük Harf) yazı tipi etkisini uygulamak, metni büyük harf olarak gösterir; metin aslında küçük harfle girilmiş olsa bile. Aspose.Slides ile böyle bir metin bölümü alındığında kütüphane metni girildiği gibi döndürür. Görüntülenen metinle eşleşmesi için [TextCapType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textcaptype/) kontrol edilmeli ve değer `ALL` olduğunda döndürülen dize büyük harfe çevrilmelidir.

Örnek olarak sample2.pptx dosyasının ilk slaydındaki aşağıdaki metin kutusunu ele alalım.

![All Caps efekti](all_caps_effect.png)

Aşağıdaki kod örneği **All Caps** etkisiyle metni nasıl çıkaracağınızı gösterir:

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

**Bir slaydın üzerindeki tablo içinde metni nasıl değiştiririm?**

Bir slayttaki tabloda metni değiştirmek için [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) kullanın. Hücreler arasında döngü yaparak her hücreyi [Cell.text_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cell/text_frame/) ve paragraf biçimlendirmesini [Paragraph.paragraph_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/paragraph_format/) üzerinden güncelleyin.

**PowerPoint slaytında metne nasıl degrade (gradient) renk uygulanır?**

Metne degrade renk uygulamak için [PortionFormat.fill_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/fill_format/) kullanın. [FillFormat.fill_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/fill_type/) özelliğini [FillType.GRADIENT](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve saydamlığını yapılandırın.