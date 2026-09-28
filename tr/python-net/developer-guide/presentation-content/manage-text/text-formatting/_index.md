---
title: Python'da Sunum Metnini Biçimlendir
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
- metin çerçevesi sabitleme noktası
- metin sekmeleri
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarındaki metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via .NET kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sek durakları ve dil ayarlarını kapsar.

Aksi belirtilmedikçe, örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slaytındaki ilk şekil bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Slayt ve şekil indeksleri sıfır tabanlıdır. Kalın bölümleri seçen örnekler, kalıtılan kalın biçimlendirme dahil, etkili biçimlendirme kullanır:

![Örnek metin](sample_text.png)

Metin arama ve değiştirme örneklerini görmek için [Metin Arama ve Değiştirme](/slides/tr/python-net/search-and-replace-text/) sayfasına bakın.

## **Metin Arka Plan Rengini Ayarla**

Bir paragraf için varsayılan vurgulama rengini ayarlamak için [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/default_portion_format/) kullanın veya bireysel metin bölümleri için [BasePortionFormat.highlight_color](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/highlight_color/) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Bireysel bölümlerdeki açık vurgulama renkleri bu varsayılanın üzerine yazar:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]

    # Paragrafın tamamı için vurgulama rengini ayarla.
    paragraph.paragraph_format.default_portion_format.highlight_color.color = draw.Color.light_gray

    presentation.save("gray_paragraph.pptx", slides.export.SaveFormat.PPTX)
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için arka plan rengini nasıl ayarlayacağını gösterir:

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

Bir metin çerçevesi içinde paragraf hizalamasını ayarlamak için [ParagraphFormat.alignment](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/alignment/) kullanın. Değerler ortalanmış, sola hizalı, sağa hizalı, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği, paragrafı **ortaya** hizalamayı gösterir:

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

## **Metin İçin Şeffaflığı Ayarla**

Metin şeffaflığı, [BasePortionFormat.fill_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/fill_format/) üzerinden atanan rengin alfa bileşeniyle kontrol edilir. Aşağıdaki örneklerde `alpha = 50` 0–255 ölçeğinde bir ARGB alfa kanalı değeridir, yüzde olarak şeffaflık değildir.

Aşağıdaki kod örneği, **tüm paragraf** için şeffaflık uygulamayı gösterir:

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

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** için şeffaflık uygulamayı gösterir:

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

Karakterler arasındaki boşluğu genişletmek veya sıkıştırmak için [BasePortionFormat.spacing](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/spacing/) kullanın. Örnekler 3 puan boşluk ekler; negatif değerler metni sıkıştırır.

Aşağıdaki Python kodu, **tüm paragraf** içinde karakter aralığını nasıl genişleteceğini gösterir:

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

Aşağıdaki kod örneği, **kalın bir yazı tipine sahip metin bölümleri** içinde karakter aralığını nasıl genişleteceğini gösterir:

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

Bazı durumlarda, Aspose.Slides tarafından oluşturulan metin, PowerPoint'te gösterilen aynı metinden biraz daha sıkı görünebilir. Bu, PowerPoint'in bazı yazı tipleri için kerning verilerini görmezden gelmesinden kaynaklanabilir; hatta yazı tipi geçerli kerning bilgisine sahipse ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu durumlarda çıktıyı PowerPoint'e daha yakın hale getirmek için, etkilenen yazı tipini kullanan metin bölümleri için kerning'i devre dışı bırakabilirsiniz. [BasePortionFormat.kerning_minimal_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/kerning_minimal_size/) değerini gerçek yazı tipi boyutundan büyük bir değerle ayarlayın. Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren \"presentation.pptx\" gerektirir. Etkili yazı tipi adlarını, kalıtılan yazı tipleri dahil, kontrol eder ve Roboto kullanan bölümler için 100 puan eşik değeri ayarlar. Bu, 100 puanın altındaki yazı boyutuna sahip eşleşen bölümler için kerning'i devre dışı bırakır:

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

Bu eşik altındaki eşleşen metinler için ayar, kerning'i önler ve bu PowerPoint'e özgü davranıştan etkilenen yazı tipleri için Aspose.Slides Rendering'i PowerPoint'in görsel çıktısıyla hizalamaya yardımcı olabilir.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, [ParagraphFormat.default_portion_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/default_portion_format/) aracılığıyla paragraf seviyesinde veya bireysel bölümlerde [PortionFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/) aracılığıyla ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 puan Times New Roman, kalın, italik ve noktalı alt çizgi biçimlendirmesiyle ayarlar. Bireysel bölümlerdeki açık biçimlendirme bu varsayılanların üzerine yazar:

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

## **Metin Döndürmesini Ayarla**

Metin yönelimini şekil içinde önceden tanımlı bir konuma ayarlamak için [TextFrameFormat.text_vertical_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/text_vertical_type/) kullanın.

Aşağıdaki kod örneği, şekildeki metin yönelimini [TextVerticalType.VERTICAL270](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

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

[TextFrameFormat.rotation_angle](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/rotation_angle/) kullanarak bir [TextFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframe/) için özel bir döndürme açısı ayarlayabilirsiniz.

Aşağıdaki kod örneği, şekil içinde metin çerçevesini **3 derece saat yönünde** döndürür:

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

Aspose.Slides, paragraf aralığını kontrol etmek için [ParagraphFormat.space_after](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/space_after/), [ParagraphFormat.space_before](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/space_before/) ve [ParagraphFormat.space_within](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/space_within/) sağlar. Bu özellikler şu şekilde kullanılır:

* Pozitif bir değer, satır yüksekliğinin yüzde olarak satır aralığını belirtir.
* Negatif bir değer, satır aralığını puan cinsinden belirtir.

Aşağıdaki örnek, ilk paragraftaki aralığı satır yüksekliğinin %200'ü (çift satır aralığı) olarak ayarlar:

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

## **Satır Kesilmesini Kontrol Et**

Paragraf satır kesme kuralları, dar metin bloklarında ve Latin ile Doğu Asya metinlerinin karıştığı sunumlarda faydalıdır. Aşağıdaki özellikler [ParagraphFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/) aittir, bu yüzden bütün paragrafı etkiler:

- [latin_line_break](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/latin_line_break/) Latin satır kesme kurallarını kontrol eder. Karışık metinde değiştirmek, bitişik Doğu Asya metin ve noktalama işaretlerinin nerede sarılacağını da etkileyebilir.
- [east_asian_line_break](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/east_asian_line_break/) Doğu Asya satır kesme kurallarını kontrol eder; bir satırın başı ve sonundaki karakterlerle ilgili kısıtlamaları içerir.

Bu kurallar, bir metin çerçevesi içinde otomatik sarma sağlayan [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/wrap_text/) işlevinin yerine geçmez. Sarma gerçekleştiğinde düzeni etkiler; satır sonu karakteri eklemezler. Açık bir satır sonu, paragraf içinde mevcut genişliğe bakılmaksızın yeni bir satır başlatır.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. İki satır kesme özelliğini açıkça ayarlar ve \"line_breaking.pptx\" olarak kaydeder. Her iki kuralı da denemek için, diğer ayarları sabit tutarak ilgili özelliğin değerini değiştirin. Örnek, 24 puan Arial ve SimSun, 160 puan çerçeve genişliği ve sıfır yatay metin çerçevesi kenar boşluğu kullanır. [TextFrameFormat.autofit_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/autofit_type/) [TextAutofitType.NONE](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textautofittype/) olarak ayarlanmıştır; böylece metin boyutu ve çerçeve ölçüleri sabit kalır.

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

## **Sarkan Noktalama İşaretlerini Kontrol Et**

[ParagraphFormat.hanging_punctuation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/hanging_punctuation/) uygun noktalama işaretlerinin sonraki satıra yerleşmek yerine metin satırının sağ kenarının dışına uzanmasına izin verir. Tüm paragrafı etkiler ve sarkan girintiden farklıdır.

Aşağıdaki bağımsız örnek, 100 puan genişliğinde bir metin çerçevesinde sarkan noktalama işaretlerini etkinleştirir ve \"hanging_punctuation.pptx\" olarak kaydeder. 24 puan Arial ve sıfır yatay metin çerçevesi kenar boşluğu ile son nokta \"sentence\" kelimesinin ardından kalır ve sağ metin kenarının dışına uzanır. Karşılaştırma için özelliği [NullableBool.FALSE](https://reference.aspose.com/slides/tr/python-net/aspose.slides/nullablebool/) olarak ayarlayın: bu ayarlarla nokta ayrı bir satır alır. Sarma açıktır ve otomatik sığdırma devre dışı bırakılmıştır; böylece kullanılabilir genişlik sabit kalır.

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

Her noktalama işareti sarkan olarak ayarlanamaz. Görülen sonuç, yazı tipi ve düzen koşullarına bağlıdır: yazı tipini, kullanılabilir genişliği, kenar boşluklarını veya otomatik sığdırma ayarlarını değiştirmek görünür farkı ortadan kaldırabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarla**

[TextFrameFormat.autofit_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/autofit_type/) bir metin kapsayıcısının sınırlarını aştığında metnin nasıl davranacağını belirler. Metnin küçülüp küçülmeyeceğini, taşma yapıp yapmayacağını veya şeklin otomatik olarak yeniden boyutlandırılıp boyutlandırılmayacağını kontrol etmek için kullanın. Aşağıdaki örnek, şekli metnine göre yeniden boyutlandıracak şekilde yapılandırır ve sonucu \"autofit_type.pptx\" olarak kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.autofit_type = slides.TextAutofitType.SHAPE

    presentation.save("autofit_type.pptx", slides.export.SaveFormat.PPTX)
```

Otomatik sarma sonrasında satırları saymak ve metin ya da şekil genişliğinin sonucu nasıl etkilediğini görmek için [İşlenen Satırları Say](/slides/tr/python-net/manage-paragraph/) sayfasına bakın. Satır sayısı yalnız başına, metnin kapsayıcısının dışına taşması durumunu göstermez.

## **Metin Çerçevelerinin Sabitleme Noktasını Ayarla**

[TextFrameFormat.anchoring_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textframeformat/anchoring_type/) bir metnin bir şekil içinde düşey olarak nasıl konumlandırılacağını tanımlar; örneğin üst, orta veya alt. Aşağıdaki örnek, metni ilk şeklin alt kısmına sabitler ve sonucu \"text_anchor.pptx\" olarak kaydeder.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes[0]

    auto_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.BOTTOM

    presentation.save("text_anchor.pptx", slides.export.SaveFormat.PPTX)
```

## **Metin Sekmelerini Ayarla**

Paragrafta sek duraklarını yapılandırmak için [ParagraphFormat.default_tab_size](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/default_tab_size/) ve [ParagraphFormat.tabs](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraphformat/tabs/) kullanın. Aşağıdaki örnek, varsayılan sek aralığını 100 puan olarak ayarlar ve 30 puanda sola hizalı bir sek durak ekler. Bu ayarlar, sek karakteri içeren metni etkiler.

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

Aspose.Slides, bir metin bölümü için denetleme dilini ayarlamanızı sağlayan [BasePortionFormat.language_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/language_id/) sunar. Denetleme dili, PowerPoint'te yazım ve dilbilgisi denetimi için kullanılan dili belirler.

Aşağıdaki örnek, ilk slayttaki ilk şekil olarak bir metin kutusu ve en az bir paragraf içeren \"presentation.pptx\" gerektirir. İlk paragrafın içeriğini \"1。\" ile değiştirir, SimSun'u yazı tipi olarak ayarlar ve basitleştirilmiş Çince denetleme dilini (`zh-CN`) atar. Sonucu \"proofing_language.pptx\" olarak kaydeder:

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

    # Doğrulama dilini Basitleştirilmiş Çince olarak ayarla.
    text_portion.portion_format.language_id = "zh-CN"

    text_portion.text = "1。"
    paragraph.portions.add(text_portion)

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Varsayılan Dili Ayarla**

[LoadOptions.default_text_language](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/default_text_language/) kullanarak bir sunum yüklenirken ya da oluşturulurken oluşturulan metin için varsayılan dili tanımlayabilirsiniz. Aşağıdaki örnek, varsayılan metin dili olarak ABD İngilizcesi ayarlanmış bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümünün dilini `en-US` olarak yazdırır.

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

Sunum düzeyinde varsayılan metin biçimlendirmesi uygulamak için [Presentation.default_text_style](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/default_text_style/) kullanın.

Aşağıdaki örnek, yeni bir sunumda üst düzey paragraflar için varsayılan olarak 14 puan kalın bir yazı tipi ayarlar ve \"default_text_style.pptx\" olarak kaydeder. Metin, daha belirgin biçimlendirme tarafından geçersiz kılınmadıkça bu varsayılanları devralabilir.

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

## **Tüm Büyük Harf Efektiyle Metni Çıkar**

PowerPoint'te **Tüm Büyük Harf** yazı tipi efekti uygulamak, metni slaytta büyük harfle gösterir; metin aslında düşük harflerle yazılmış olsa bile. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni girildiği gibi döndürür. Görünen metinle eşleşmesi için [TextCapType](https://reference.aspose.com/slides/tr/python-net/aspose.slides/textcaptype/) kontrol edip, değer `ALL` ise döndürülen dizeyi büyük harfe çevirebilirsiniz.

Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren \"sample2.pptx\" gerektirir. İlk paragrafın ilk bölümü, aşağıda gösterildiği gibi **Tüm Büyük Harf** etkisi uygulanmış \"Hello, Aspose!\" içerir.

![Tüm Büyük Harf etkisi](all_caps_effect.png)

Aşağıdaki kod örneği, **Tüm Büyük Harf** etkisi uygulanmış metni nasıl çıkaracağını gösterir:

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

**Bir slayttaki tablo içinde metni nasıl değiştirebilirim?**

Bir slayttaki tablo içinde metni değiştirmek için [Table](https://reference.aspose.com/slides/tr/python-net/aspose.slides/table/) kullanın. Hücreleri dolaşın ve her hücreyi [Cell.text_frame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/cell/text_frame/) üzerinden güncelleyin; paragraf biçimlendirmesini ise [Paragraph.paragraph_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/paragraph_format/) aracılığıyla ayarlayın.

**PowerPoint slaytında metne degrade renk nasıl uygulayabilirim?**

Metne degrade renk uygulamak için [BasePortionFormat.fill_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/fill_format/) kullanın. [FillFormat.fill_type](https://reference.aspose.com/slides/tr/python-net/aspose.slides/fillformat/fill_type/) değerini [FillType.GRADIENT](https://reference.aspose.com/slides/tr/python-net/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.