---
title: Python üzerinden Java ile Sunum Yerelleştirmesini Otomatikleştir
linktitle: Sunum Yerelleştirmesi
type: docs
weight: 100
url: /tr/python-java/presentation-localization/
keywords:
- dil değiştir
- imla denetimi
- imla denetimini devre dışı bırak
- denetleme dili
- dil kimliği
- çok dilli metin
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides ile Python üzerinden Java kullanarak PowerPoint ve OpenDocument sunum metinleri için proofing dillerini ayarlayın, varsayılanlar ve çok dilli paragraflar dahil."
---
## **Genel Bakış**

Aspose.Slides for Python via Java, bireysel metin bölümleri için denetleme üst verilerini yapılandırmanıza olanak tanır. Proofing dilini belirlemek için **[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setLanguageId)**, imla denetimini etkinleştirmek veya devre dışı bırakmak için **[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setSpellCheck)** ve daha geniş “proof” durumunu kontrol etmek için **[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setProofDisabled)** kullanın. Bu ayarlar bölüm (portion) seviyesinde uygulandığından, tek bir paragrafta birden çok dil ve farklı denetleme kuralları bulunabilir.

Bu makale, belirli bir metne nasıl dil atanacağını, **[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage)** ile yeni metin için varsayılan dilin nasıl ayarlanacağını, çok dilli paragrafların nasıl oluşturulacağını, **[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setSpellCheck)** ve **[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setProofDisabled)** arasında nasıl tercih yapılacağını ve **[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting)** kullanılırken istenen ayarların nasıl korunacağını açıklar. Bu özellikler, sunum uygulamaları için üst veri depolar; metni çevremez, sözlük tabanlı imla denetimi yapmaz ve yanlış yazılmış kelimeleri döndürmez.

## **Metin İçin Proofing Dilini Ayarlama**

Bir **[Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/)** oluşturun veya yükleyin, **[Portion.getPortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#getPortionFormat)** aracılığıyla gerekli metin bölümüne erişin ve dil tanımlayıcısını atayın. Aşağıdaki örnek bir şekil oluşturur, proofing dili olarak Britanya İngilizcesi ayarlar ve sonucu **[Presentation.save](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#save)** ile kaydeder:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Set the proofing language for this text.")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setLanguageId("en-GB")

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Yeni Metin İçin Varsayılan Dili Ayarlama**

**[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage)**, Aspose.Slides'in yeni oluşturulan metne atayacağı proofing dilini belirlemenizi sağlar. Çoğu veya tüm yeni metin aynı dili kullanıyorsa faydalıdır. Zaten açık bir dili olan metnin üst verisini değiştirmez.

Aşağıdaki örnek, yeni metnin Almanca proofing kurallarını kullanacağı bir sunum oluşturur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("de-DE")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80)
    shape.getTextFrame().setText("Willkommen zur Präsentation")

    presentation.save("default_text_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Tek Bir Paragrafta Birden Çok Dil Kullanma**

Bir **[Paragraph](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/)**, metin bölümlerinin bir koleksiyonunu içerir. Her dil için ayrı bir **[Portion](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/)** oluşturun ve **[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setLanguageId)** özelliğini bağımsız olarak ayarlayın.

Bu örnek, İngilizce ve Fransızca bölümleri olan tek bir paragraf oluşturur:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    english_portion = Portion("Welcome")
    english_portion.getPortionFormat().setLanguageId("en-US")
    paragraph.getPortions().add(english_portion)

    french_portion = Portion(" — Bienvenue")
    french_portion.getPortionFormat().setLanguageId("fr-FR")
    paragraph.getPortions().add(french_portion)

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bireysel Bölümler İçin İmla Denetimini Açma veya Kapatma**

**[PortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/)**, **[BasePortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/)** tarafından tanımlanan ortak metin özelliklerini devralır. Bir bölümün biçimine **[Portion.getPortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portion/#getPortionFormat)** ile erişin ve **[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setSpellCheck)** kullanarak sunum uygulamasının o bölüm için imla denetimi yapıp yapmayacağını kontrol edin. Varsayılan değer `False` tır: `True` imla denetimine izin verir, `False` ise engeller.

Ayar, bireysel metin bölümlerine uygulanır. Aynı paragraftaki farklı bölümler farklı değerler kullanabilir. **[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setLanguageId)** ve **[setSpellCheck](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setSpellCheck)** tamamlayıcı amaçlara hizmet eder: **[setLanguageId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setLanguageId)** proofing dilini belirlerken, **[setSpellCheck](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setSpellCheck)** bölümün imla denetimine izin verilip verilmeyeceğini belirler.

**[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setProofDisabled)** da proofing’i kontrol eder, ancak daha geniş “proof yapılmasın” durumunu **[NullableBool](https://reference.aspose.com/slides/tr/python-java/aspose.slides/nullablebool/)** olarak temsil eder. Yalnızca imla denetimi için doğrudan bir Boolean anahtarına ihtiyacınız olduğunda **[setSpellCheck](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setSpellCheck)** kullanın. Sunumun “proof yapılmasın” üst verisini korumak veya açıkça kontrol etmek istediğinizde **[setProofDisabled](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setProofDisabled)** kullanın; bu, **[NullableBool.NotDefined](https://reference.aspose.com/slides/tr/python-java/aspose.slides/nullablebool/#NotDefined)** durumunu da kapsar. İki özelliği aynı anda ayarlıyorsanız değerlerini tutarlı tutun; **[setSpellCheck](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setSpellCheck)** `True` iken **[setProofDisabled](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setProofDisabled)** `NullableBool.True` durumunda olmamalıdır.

Bu özellikler, PowerPoint ve diğer sunum uygulamaları tarafından kullanılan proofing üst verilerini yapılandırır. Aspose.Slides bu verileri sözlük tabanlı imla denetimi yapmak veya yanlış yazılmış kelimelerin listesini döndürmek için kullanmaz.

Aşağıdaki tam örnek, bir giriş sunumu oluşturur, yükler, aynı paragraftaki iki bölüm için farklı imla denetimi ayarları ve proofing dilleri atar, sonucu kaydeder, yeniden açar ve kaydedilen değerleri doğrular:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

input_file = "spell_check_input.pptx"
output_file = "spell_check_settings.pptx"

source_presentation = Presentation()
try:
    source_slide = source_presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80)
    source_paragraph = source_shape.getTextFrame().getParagraphs().get_Item(0)
    source_paragraph.getPortions().clear()

    source_english_portion = Portion("Check this text. ")
    source_english_portion.getPortionFormat().setLanguageId("en-US")
    source_paragraph.getPortions().add(source_english_portion)

    source_french_portion = Portion("Ignorer ce code : ZX-81.")
    source_french_portion.getPortionFormat().setLanguageId("fr-FR")
    source_paragraph.getPortions().add(source_french_portion)

    source_presentation.save(input_file, SaveFormat.Pptx)
finally:
    source_presentation.dispose()

presentation = Presentation(input_file)
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    checked_portion = portions.get_Item(0)
    checked_portion.getPortionFormat().setLanguageId("en-US")
    checked_portion.getPortionFormat().setSpellCheck(True)

    suppressed_portion = portions.get_Item(1)
    suppressed_portion.getPortionFormat().setLanguageId("fr-FR")
    suppressed_portion.getPortionFormat().setSpellCheck(False)

    presentation.save(output_file, SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation(output_file)
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    stored_portions = reopened_shape.getTextFrame().getParagraphs().get_Item(0).getPortions()

    first_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(0).getPortionFormat().getLanguageId() == "en-US" and stored_portions.get_Item(0).getPortionFormat().getSpellCheck()

    second_portion_stored = stored_portions.getCount() == 2 and stored_portions.get_Item(1).getPortionFormat().getLanguageId() == "fr-FR" and not stored_portions.get_Item(1).getPortionFormat().getSpellCheck()

    if first_portion_stored and second_portion_stored:
        print("The proofing settings were stored correctly.")
    else:
        print("The proofing settings could not be verified.")

finally:
    reopened_presentation.dispose()
```

**[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting)**, aynı biçimlendirmeye sahip komşu bölümleri birleştirir. Sadece **[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setSpellCheck)** farkı, bölümleri ayrı tutmaz; birleştirildikten sonra oluşan bölüm, ilk bölümün **[BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setSpellCheck)** değerini korur. Bölümlerin farklı imla denetimi ayarlarına ihtiyacı varsa, bu ayarları atamadan önce **[joinPortionsWithSameFormatting](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#joinPortionsWithSameFormatting)** metodunu çağırın veya sonuçta oluşan bölüm sınırlarını inceleyip ayarları sonradan yeniden uygulayın. **[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setLanguageId)** değerleri farklı olan bölümler, proofing‑dil biçimlendirmeleri farklı olduğu için ayrı kalır.

## **SSS**

**Bir dil kimliği metni çevirir mi?**

Hayır. **[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setLanguageId)**, imla ve dilbilgisi için proofing üst verilerini depolar; metin içeriğini değiştirmez. Metni ayrı olarak çevirin ve ardından her çevrilmiş bölüm için uygun dil tanımlayıcısını ayarlayın.

**Proofing dili yazı tiplerini, hecelemeyi veya satır kaydırmayı kontrol eder mi?**

Hayır. Dil tanımlayıcısı yalnızca proofing içindir. Metin renderleme ve yerleşim, öncelikle mevcut **[fonts](/slides/tr/python-java/powerpoint-fonts/)**, yazı sistemi ve metin‑çerçeve ayarlarına bağlıdır. Güvenilir renderleme için gerekli yazı tiplerini sağlayın, **[font substitution](/slides/tr/python-java/font-substitution/)** yapılandırın veya **[embed fonts](/slides/tr/python-java/embedded-font/)** ekleyin.

**Bir paragrafta birden çok proofing dili kullanılabilir mi?**

Evet. Çok dilli paragraf örneğinde gösterildiği gibi, her dili ayrı bir bölüme atayın.

**[setDefaultTextLanguage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) mi yoksa [setLanguageId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setLanguageId) mi kullanılmalı?**

Yeni oluşturulan metin için bir varsayılan istiyorsanız **[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage)** kullanın. Belirli bir bölüm için açık bir proofing dili gerekiyorsa veya bir paragrafta birden çok dil varsa **[BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setLanguageId)** kullanın.