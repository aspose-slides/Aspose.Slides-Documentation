---
title: Python ile Sunum Yerelleştirmesini Otomatikleştir
linktitle: Sunum Yerelleştirmesi
type: docs
weight: 100
url: /tr/python-net/presentation-localization/
keywords:
- dil değiştir
- yazım denetimi
- yazım denetimini bastır
- düzeltme dili
- dil kimliği
- çok dilli metin
- PowerPoint
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides ile Python'da PowerPoint ve OpenDocument sunum metinleri için düzeltme dillerini ayarlayın, varsayılanları ve çok dilli paragrafları dahil ederek."
---
## **Genel Bakış**

Aspose.Slides for Python via .NET, bireysel metin bölümleri için düzeltme meta verilerini yapılandırmanıza olanak tanır. Düzeltme dilini belirlemek için [BasePortionFormat.language_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/language_id/) kullanın, yazım denetimlerini izin vermek veya engellemek için [BasePortionFormat.spell_check](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/spell_check/) ve daha geniş kanıtlamama durumunu kontrol etmek için [BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/proof_disabled/) kullanın. Bu ayarlar bölüm seviyesinde uygulandığı için bir paragraf birden fazla dil ve farklı düzeltme kuralları içerebilir.

Bu makale, belirli metne bir dil atamanın, yeni metin için varsayılan dili [LoadOptions.default_text_language](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/default_text_language/) ile ayarlamanın, çok dilli paragraflar oluşturmanın, `spell_check` ile `proof_disabled` arasında seçim yapmanın ve [Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) kullanırken istenen ayarları korumanın nasıl yapılacağını açıklar. Bu özellikler, sunum uygulamaları için meta verileri depolar; metni çevirmez, sözlük tabanlı yazım denetimi yapmaz veya hatalı yazılmış kelimeleri döndürmez.

## **Metin İçin Düzeltme Dilini Ayarlama**

Bir [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) oluşturun veya yükleyin, gerekli metin bölümüne [Portion.portion_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/portion_format/) aracılığıyla erişin ve dil tanımlayıcısını atayın. Aşağıdaki örnek bir şekil oluşturur, İngiliz İngilizcesi'ni düzeltme dili olarak ayarlar ve sonucu [Presentation.save](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/save/) ile kaydeder:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Set the proofing language for this text."

    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.language_id = "en-GB"

    presentation.save("proofing_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Yeni Metin İçin Varsayılan Dili Ayarlama**

Yeni oluşturulan metne Aspose.Slides'in atadığı düzeltme dilini belirtmek için [LoadOptions.default_text_language](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/default_text_language/) kullanın. Bu ayar, bir sunumdaki yeni metnin çoğu veya tamamı aynı dili kullandığında yararlıdır. Zaten açık bir dili olan metnin dil meta verilerini değiştirmez.

Aşağıdaki örnek, yeni metnin Almanca düzeltme kurallarını kullandığı bir sunum oluşturur:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "de-DE"

with slides.Presentation(load_options) as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 320, 80)
    shape.text_frame.text = "Willkommen zur Präsentation"

    presentation.save("default_text_language.pptx", slides.export.SaveFormat.PPTX)
```

## **Tek Bir Paragraflarda Birden Çok Dil Kullanma**

[Paragraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides/paragraph/) bir metin bölümü koleksiyonu içerir. Her dil için ayrı bir [Portion](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/) oluşturun ve `language_id` değerini bağımsız olarak ayarlayın.

Bu örnek, İngilizce ve Fransızca bölümler içeren bir paragraf oluşturur:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    paragraph = shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    english_portion = slides.Portion("Welcome")
    english_portion.portion_format.language_id = "en-US"
    paragraph.portions.add(english_portion)

    french_portion = slides.Portion(" — Bienvenue")
    french_portion.portion_format.language_id = "fr-FR"
    paragraph.portions.add(french_portion)

    presentation.save("multilingual_text.pptx", slides.export.SaveFormat.PPTX)
```

## **Bireysel Bölümler İçin Yazım Denetimini Etkinleştirme veya Bastırma**

[PortionFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portionformat/) [BasePortionFormat](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/) tarafından tanımlanan ortak metin özelliklerini devralır. Bir bölümün biçimine [Portion.portion_format](https://reference.aspose.com/slides/tr/python-net/aspose.slides/portion/portion_format/) aracılığıyla erişin ve bir sunum uygulamasının o bölüm için yazım denetimi yapıp yapmayacağını kontrol etmek için [BasePortionFormat.spell_check](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/spell_check/) ayarlayın. Varsayılan değer `False`'tur: `True` yazım denetimine izin verir, `False` ise bastırır.

Bu ayar bireysel metin bölümlerine uygulanır. Aynı paragraftaki farklı bölümler bu nedenle farklı değerler kullanabilir. [BasePortionFormat.language_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/language_id/) ve `spell_check` tamamlayıcı amaçlara hizmet eder: `language_id` düzeltme dilini belirler, `spell_check` ise bölüm için yazım denetiminin izin verilip verilmediğini belirler.

[BasePortionFormat.proof_disabled](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/proof_disabled/) ayrıca düzeltmeyi kontrol eder, ancak daha geniş "kanıtlanmasın" durumunu bir [NullableBool](https://reference.aspose.com/slides/tr/python-net/aspose.slides/nullablebool/) olarak temsil eder. Yalnızca yazım denetimi için doğrudan bir Boolean anahtarı gerektiğinde `spell_check` kullanın. Sunumun kanıtlama meta verilerini, `NOT_DEFINED` durumu da dahil olmak üzere korumak veya açıkça kontrol etmek istediğinizde `proof_disabled` kullanın. Her iki özelliği de ayarlarsanız, değerlerin tutarlı olmasını sağlayın; `spell_check = True` ile `proof_disabled = slides.NullableBool.TRUE` kombinasyonunu yapmayın.

Bu özellikler, PowerPoint ve diğer sunum uygulamaları tarafından kullanılan düzeltme meta verilerini yapılandırır. Aspose.Slides bunları sözlük tabanlı yazım denetimi yapmak veya hatalı kelimelerin bir listesini döndürmek için kullanmaz.

Aşağıdaki tam örnek bir giriş sunumu oluşturur, yükler, aynı paragraftaki iki bölüme farklı yazım denetimi ayarları ve düzeltme dilleri atar, sonucu kaydeder, yeniden açar ve kayıtlı değerleri doğrular:

```python
import aspose.slides as slides

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

with slides.Presentation() as source_presentation:
    source_slide = source_presentation.slides[0]
    source_shape = source_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 420, 80)
    source_paragraph = source_shape.text_frame.paragraphs[0]
    source_paragraph.portions.clear()

    source_english_portion = slides.Portion("Check this text. ")
    source_english_portion.portion_format.language_id = "en-US"
    source_paragraph.portions.add(source_english_portion)

    source_french_portion = slides.Portion("Ignorer ce code : ZX-81.")
    source_french_portion.portion_format.language_id = "fr-FR"
    source_paragraph.portions.add(source_french_portion)

    source_presentation.save(input_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(input_file) as presentation:
    shape = presentation.slides[0].shapes[0]
    portions = shape.text_frame.paragraphs[0].portions

    checked_portion = portions[0]
    checked_portion.portion_format.language_id = "en-US"
    checked_portion.portion_format.spell_check = True

    suppressed_portion = portions[1]
    suppressed_portion.portion_format.language_id = "fr-FR"
    suppressed_portion.portion_format.spell_check = False

    presentation.save(output_file, slides.export.SaveFormat.PPTX)

with slides.Presentation(output_file) as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]
    stored_portions = reopened_shape.text_frame.paragraphs[0].portions

    has_two_portions = stored_portions.count == 2

    first_portion_stored = (
        has_two_portions 
        and stored_portions[0].portion_format.language_id == "en-US" 
        and stored_portions[0].portion_format.spell_check
    )

    second_portion_stored = (
        has_two_portions
        and stored_portions[1].portion_format.language_id == "fr-FR" 
        and not stored_portions[1].portion_format.spell_check
    )

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")
```

[Presentation.join_portions_with_same_formatting](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/join_portions_with_same_formatting/) aynı biçime sahip bitişik bölümleri birleştirir. Sadece `spell_check` farkı bu bölümlerin ayrı kalmasını sağlamaz; birleştirildikten sonra oluşan bölüm, ilk bölümün `spell_check` değerini korur. Bölümlerin farklı yazım denetimi ayarlarına ihtiyacı varsa, bu ayarları atamadan önce `join_portions_with_same_formatting` metodunu çağırın veya oluşan bölüm sınırlarını inceleyip ayarları sonradan yeniden uygulayın. Farklı `language_id` değerlerine sahip bölümler, düzeltme dili biçimleri farklı olduğundan ayrı kalır.

## **SSS**

**Bir dil kimliği metni çevirir mi?**

Hayır. [BasePortionFormat.language_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/language_id/) yazım ve dil bilgisi düzeltmesi için meta veri depolar; metin içeriğini değiştirmez. Metni ayrı olarak çevirin ve ardından her çevrilen bölüm için uygun dil tanımlayıcısını ayarlayın.

**Düzeltme dili yazı tiplerini, tirelemeyi veya satır kırmayı kontrol eder mi?**

Hayır. Dil tanımlayıcısı yalnızca düzeltme içindir. Metin renderleme ve yerleşim esas olarak mevcut [fonts](/slides/tr/python-net/powerpoint-fonts/), yazı sistemi ve metin çerçevesi ayarlarına bağlıdır. Güvenilir renderleme için gerekli yazı tiplerini sağlayın, [font substitution](/slides/tr/python-net/font-substitution/) yapılandırın veya sunuma [embed fonts](/slides/tr/python-net/embedded-font/) ekleyin.

**Bir paragraf birden fazla düzeltme dili kullanabilir mi?**

Evet. Çok dilli paragraf örneğinde gösterildiği gibi, her dili ayrı bir bölüme atayın.

**`default_text_language` mı yoksa `language_id` mi kullanmalıyım?**

Yeni oluşturulan metin için bir varsayılan istiyorsanız [LoadOptions.default_text_language](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/default_text_language/) kullanın. Belirli bir bölümün açık bir düzeltme diline ihtiyacı olduğunda veya bir paragrafta birden fazla dil bulunduğunda [BasePortionFormat.language_id](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseportionformat/language_id/) kullanın.