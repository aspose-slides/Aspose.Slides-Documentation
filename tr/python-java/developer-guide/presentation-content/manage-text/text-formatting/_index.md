---
title: Python üzerinden Java ile Sunum Metni Biçimlendirme
linktitle: Metin Biçimlendirme
type: docs
weight: 50
url: /tr/python-java/text-formatting/
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
- metin çerçevesi sabitlemesi
- metin sekmesi
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument sunumlarında metni biçimlendirin ve stilize edin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument sunumlarında metni nasıl biçimlendireceğinizi gösterir. Arka plan renkleri, saydamlık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin sabitleme, sekme durakları ve dil ayarlarını kapsar.

Aşağıdaki örneklerde, ilk slaytta tek bir metin kutusu içeren ve aşağıdaki metni barındıran "sample.pptx" adlı dosyayı kullanacağız:

![Örnek metin](sample_text.png)

Gerçek metinleri veya düzenli ifade eşleşmelerini bulup vurgulamak için, [Metin Arama ve Değiştirme](/slides/tr/python-java/search-and-replace-text/) sayfasına bakın.

## **Metin Arka Plan Rengini Ayarla**

Bir paragraf için varsayılan vurgulama rengini ayarlamak üzere [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) kullanın veya tek tek metin bölümleri için [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/) kullanın.

Aşağıdaki kod örneği **tüm paragraf** için arka plan renginin nasıl ayarlanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Paragrafın tamamı için vurgulama rengini ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği **kalın yazı tipine sahip metin bölümleri** için arka plan renginin nasıl ayarlanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Metin bölümü için vurgulama rengini ayarla.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizala**

Bir metin çerçevesi içinde paragraf hizalamasını ayarlamak için [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setAlignment) kullanın. Değerler ortalanmış, sola hizalanmış, sağa hizalanmış, iki yana yaslanmış vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalamanın yolunu gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Paragrafın hizalamasını ortaya ayarla.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Metin İçin Saydamlık Ayarla**

Metin saydamlığı, [PortionFormat.getFillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/) üzerinden atanan rengin alfa bileşeniyle kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, 0–255 ölçeğinde bir ARGB alfa kanalı değeridir, yüzde olarak saydamlık değildir.

Aşağıdaki kod örneği **tüm paragraf** için saydamlık uygulamasını gösterir:

```python
import jpype
import asposeslides

if not jpime.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Metnin doldurma rengini saydam bir renge ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Saydam paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği **kalın yazı tipine sahip metin bölümleri** için saydamlık uygulamasını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Metin bölümünün saydamlığını ayarla.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Saydam metin bölümleri](transparent_text_portions.png)

## **Metin İçin Karakter Aralığını Ayarla**

Bir metin kutusundaki karakterler arasındaki aralığı genişletmek veya sıkıştırmak için [PortionFormat.setSpacing](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/) kullanın.

Aşağıdaki Python kodu **tüm paragraf** için karakter aralığını genişletmeyi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Karakter aralığını genişlet.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Paragraftaki karakter aralığı](character_spacing_in_paragraph.png)

Aşağıdaki kod örneği **kalın yazı tipine sahip metin bölümleri** için karakter aralığını genişletir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Not: Karakter aralığını sıkıştırmak için negatif değerler kullanın.
            portion.getPortionFormat().setSpacing(3) # Karakter aralığını genişlet.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Metin bölümlerindeki karakter aralığı](character_spacing_in_text_portions.png)

### **Belirli Yazı Tipleri İçin Kerning’i Devre Dışı Bırak**

Bazı durumlarda Aspose.Slides tarafından işlenen metin, aynı metnin PowerPoint’te görüntülenmesinden biraz daha sıkı görünebilir. Bu, PowerPoint’in belirli yazı tipleri için kerning verilerini görmezden gelmesinden kaynaklanabilir; yazı tipi geçerli kerning bilgisine sahip olsa ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu durumlarda çıktıyı PowerPoint’e daha yakın hâle getirmek için, ilgili yazı tipini kullanan metin bölümleri için kerning’i devre dışı bırakabilirsiniz. [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/) değerini gerçek yazı tipi boyutundan belirgin şekilde büyük bir değere ayarlayın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bu ayar, eşleşen metin bölümlerine kerning uygulanmasını engeller ve bu PowerPoint’e özgü davranıştan etkilenen yazı tipleri için Aspose.Slides’ın render çıktısını PowerPoint’in görsel çıktısıyla hizalamaya yardımcı olabilir.

## **Metin Yazı Tipi Özelliklerini Yönet**

Yazı tipi özellikleri, [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) aracılığıyla paragraf düzeyinde veya [PortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/) aracılığıyla tek tek bölümlerde ayarlanabilir.

Aşağıdaki kod, tüm paragraf için yazı tipini ve metin stilini ayarlar: yazı tipi boyutu, kalın, italik, noktalı alt çizgi ve Times New Roman tüm bölümlere uygulanır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Paragraf için yazı tipi özelliklerini ayarla.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Paragrafın yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki kod örneği **kalın yazı tipine sahip metin bölümleri** için benzer özellikleri uygular:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Metin bölümü için yazı tipi özelliklerini ayarla.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Metin bölümlerinin yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Döndürmeyi Ayarla**

Bir şekil içinde önceden tanımlanmış bir metin yönünü ayarlamak için [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setTextVerticalType) kullanın.

Aşağıdaki kod örneği şekil içindeki metin yönünü `Vertical270` olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Metin döndürme](text_rotation.png)

## **Metin Çerçeveleri İçin Özel Döndürme Ayarla**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setRotationAngle) kullanarak bir [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) için özel bir döndürme açısı ayarlayabilirsiniz.

Aşağıdaki kod örneği şekil içinde metin çerçevesini 3 derece saat yönünde döndürür:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Özel metin döndürme](custom_text_rotation.png)

## **Paragrafların Satır Aralığını Ayarla**

Aspose.Slides, paragraf aralığını kontrol etmek için [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setSpaceBefore) ve [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setSpaceWithin) sağlar. Bu özellikler şu şekilde kullanılır:

* Satır aralığını satır yüksekliğinin yüzdesi olarak belirtmek için pozitif bir değer kullanın.
* Satır aralığını puan cinsinden belirtmek için negatif bir değer kullanın.

Aşağıdaki kod örneği paragraf içindeki satır aralığını nasıl belirleyeceğinizi gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Paragraftaki satır aralığı](line_spacing.png)

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarla**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setAutofitType), metin kapsayıcının sınırlarını aştığında nasıl davranacağını belirler. Metnin küçülüp küçülmeyeceğini, taşma yapıp yapmayacağını veya şeklin otomatik olarak yeniden boyutlandırılıp boyutlandırılmayacağını kontrol etmek için kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Metin Çerçevelerinin Sabitlemesini Ayarla**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setAnchoringType), metnin bir şekil içinde dikey olarak nasıl konumlandırılacağını tanımlar; örneğin üstte, ortada veya altta.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Metin Sekme Ayarını Yap**

Paragrafta sekme duraklarını yapılandırmak için [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) ve [ParagraphFormat.getTabs](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#getTabs) kullanın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Paragraf sekmeleri](paragraph_tabs.png)

## **Düzeltme Dilini Ayarla**

Aspose.Slides, bir metin bölümü için düzeltme dilini ayarlamanızı sağlayan [PortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/) sunar. Düzeltme dili, PowerPoint’te imla ve dilbilgisi denetimlerinde kullanılan dili belirler.

Aşağıdaki kod örneği bir metin bölümü için düzeltme dilinin nasıl ayarlanacağını gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # Düzeltme dilinin kimliğini ayarla.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Varsayılan Dili Ayarla**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) kullanarak bir sunum yüklenirken veya oluşturulurken üretilen metin için varsayılan dili tanımlayın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # Metin içeren bir dikdörtgen şekil ekle.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # İlk bölümün dilini kontrol et.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Varsayılan Metin Stilini Ayarla**

Sunum düzeyinde varsayılan metin biçimlendirmesini uygulamak için [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getDefaultTextStyle) kullanın.

Aşağıdaki kod örneği yeni bir sunumda tüm slaytlardaki metinler için 14 pt boyutunda kalın bir yazı tipini varsayılan olarak ayarlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Üst seviye paragraf biçimini al.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Büyük Harf Etkisi ile Metin Çıkar**

PowerPoint’te **All Caps** (Tüm Büyük Harf) yazı tipi etkisini uyguladığınızda, metin slaytta büyük harf olarak görünür, ancak aslında küçük harf olarak girilmiştir. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni tam girildiği gibi geri döndürür. Görüntülenen metinle eşleşmesi için [TextCapType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textcaptype/) kontrol edin ve değer `All` olduğunda döndürülen dizeyi büyük harfe çevirin.

Örnek olarak sample2.pptx dosyasının ilk slaydındaki aşağıdaki metin kutusunu ele alalım.

![All Caps etkisi](all_caps_effect.png)

Aşağıdaki kod örneği **All Caps** etkisi uygulanmış metni nasıl çıkaracağınızı gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

Çıktı:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **SSS**

**Bir slayttaki tablo içinde metni nasıl değiştiririm?**

Bir slayttaki tablo içinde metni değiştirmek için [Table](https://reference.aspose.com/slides/tr/python-java/aspose.slides/table/) kullanın. Hücreler arasında döngü kurarak her hücreyi [Cell.getTextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cell/#getTextFrame) ve paragraf biçimlendirmesini [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/#getParagraphFormat) aracılığıyla güncelleyin.

**PowerPoint slaytında metne geçişli (gradient) renk nasıl uygularım?**

Metne geçişli renk uygulamak için [PortionFormat.getFillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/) kullanın. [FillFormat.setFillType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fillformat/#setFillType) değerini [FillType.Gradient](https://reference.aspose.com/slides/tr/python-java/aspose.slides/filltype/#Gradient) olarak ayarlayın ve geçiş duraklarını, yönünü ve saydamlığını yapılandırın.