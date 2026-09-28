---
title: Python aracılığıyla Java ile Sunum Metnini Biçimlendirin
linktitle: Metin Biçimlendirme
type: docs
weight: 50
url: /tr/python-java/text-formatting/
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
- metin sekmesi
- varsayılan dil
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument sunumlarındaki metni biçimlendirin ve stil verin. Yazı tiplerini, renkleri, hizalamayı ve daha fazlasını özelleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Python via Java kullanarak PowerPoint ve OpenDocument sunumlarında metin biçimlendirmeyi gösterir. Arka plan renkleri, şeffaflık, karakter aralığı, yazı tipi özellikleri, döndürme, paragraf aralığı, otomatik sığdırma davranışı, metin sabitlemesi, sekme durakları ve dil ayarları ele alınır.

Aksi belirtilmedikçe örnekler [sample.pptx](sample.pptx) dosyasını kullanır. İlk slayttaki ilk şekil bir metin kutusudur ve ilk paragrafı aşağıda gösterilen metni içerir. Hem slayt hem de şekil indeksleri sıfır‑tabanlıdır. Kalın bölümleri seçen örnekler, kalıtsal kalın biçimlendirme dahil, etkili biçimlendirme kullanır:

![Örnek metin](sample_text.png)

Literal metin veya düzenli ifade eşleşmelerini bulmak ve vurgulamak için [Metin Arama ve Değiştirme](/slides/tr/python-java/search-and-replace-text/) bölümüne bakın.

## **Metin Arka Plan Rengini Ayarlama**

Bir paragrafın varsayılan vurgulama rengini ayarlamak için [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) kullanın veya tek tek metin bölümleri için [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#getHighlightColor) kullanın.

Aşağıdaki örnek, ilk paragraf için varsayılan olarak açık gri bir vurgulama ayarlar. Tek tek bölümlerde açıkça belirtilen vurgulama renkleri bu varsayılanın üzerine yazar:

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

    # Tüm paragraf için vurgulama rengini ayarlayın.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Gri paragraf](gray_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için arka plan rengini nasıl ayarlayacağınızı gösterir:

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
            # Metin bölümünün vurgulama rengini ayarlayın.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Gri metin bölümleri](gray_text_portions.png)

## **Metin Paragraflarını Hizalama**

Bir metin çerçevesindeki paragraf hizalamasını ayarlamak için [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setAlignment) kullanın. Değerler ortalanmış, sola hizalı, sağa hizalı, iki yana yaslı vb. olabilir.

Aşağıdaki kod örneği paragrafı **ortaya** hizalar:

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

    # Paragrafın hizalamasını ortala.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Hizalanmış paragraf](aligned_paragraph.png)

## **Metin Şeffaflığını Ayarlama**

Metin şeffaflığı, [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#getFillFormat) aracılığıyla atanan rengin alfa bileşeniyle kontrol edilir. Aşağıdaki örneklerde `alpha = 50`, 0–255 ölçeğinde bir ARGB alfa değerdir, yüzde şeffaflık değildir.

Aşağıdaki kod örneği **tüm paragraf** için şeffaflık uygular:

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

    # Metnin doldurma rengini şeffaf olarak ayarlayın.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Şeffaf paragraf](transparent_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için şeffaflık uygular:

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
            # Metin bölümünün şeffaflığını ayarlayın.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Şeffaf metin bölümleri](transparent_text_portions.png)

## **Metin Karakter Aralığını Ayarlama**

Bir metin kutusundaki karakterler arasındaki aralığı genişletmek veya sıkıştırmak için [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setSpacing) kullanın. Örnekler 3 puanlık bir ekleme yapar; negatif değerler metni sıkıştırır.

Aşağıdaki Python kodu **tüm paragraf** için karakter aralığını genişletir:

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

    # Not: karakter aralığını sıkıştırmak için negatif değerleri kullanın.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Karakter aralığını genişlet.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Paragraftaki karakter aralığı](character_spacing_in_paragraph.png)

Aşağıdaki kod örneği **kalın bir yazı tipine sahip metin bölümleri** için karakter aralığını genişletir:

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
            # Not: karakter aralığını sıkıştırmak için negatif değerleri kullanın.
            portion.getPortionFormat().setSpacing(3) # Karakter aralığını genişlet.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Sonuç:

![Metin bölümlerindeki karakter aralığı](character_spacing_in_text_portions.png)

### **Belirli Yazı Tipleri İçin Kerning'i Devre Dışı Bırakma**

Bazı durumlarda Aspose.Slides tarafından render edilen metin, PowerPoint’teki aynı metinden biraz daha sık görünebilir. Bu, PowerPoint’in bazı yazı tipleri için kerning verisini görmezden gelmesinden kaynaklanabilir, hatta yazı tipinde geçerli kerning bilgisi olsa ve PowerPoint ayarlarında kerning etkin olsa bile.

Bu durumlarda render çıktısını PowerPoint’e daha yakın hâle getirmek için, etkilenen yazı tipini kullanan metin bölümleri için kerning’i devre dışı bırakabilirsiniz. [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) değerini gerçek yazı tipi boyutundan büyük bir değere ayarlayın. Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren “presentation.pptx” dosyasını gerektirir. Etkili yazı tipi adlarını (kalıtsal yazı tipleri dahil) kontrol eder ve Roboto kullanan bölümler için 100 puanlık bir eşik ayarlar. Bu, 100 puandan küçük yazı tipi boyutuna sahip eşleşen bölümler için kerning’i devre dışı bırakır:

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
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Eşiğin altındaki eşleşen metinler için bu ayar kerning’i önler ve PowerPoint’in bu yazı tipleri için gösterdiği davranışa daha yakın bir görünüm elde etmeye yardımcı olabilir.

## **Metin Yazı Tipi Özelliklerini Yönetme**

Yazı tipi özellikleri, [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) aracılığıyla paragraf düzeyinde veya bireysel bölümler için [PortionFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/portionformat/) aracılığıyla ayarlanabilir.

Aşağıdaki örnek, ilk paragrafın varsayılan yazı tipini 12 puan Times New Roman, kalın, italik ve noktalı alt çizgi olarak ayarlar. Tek tek bölümlerdeki açık biçimlendirme bu varsayılanların üzerine yazılır:

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

    # Paragraf için yazı tipi özelliklerini ayarlayın.
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

![Paragraf için yazı tipi özellikleri](font_properties_for_paragraph.png)

Aşağıdaki örnek, etkili biçimlendirmesi kalın olan bölümlere 13 puan Times New Roman, italik ve noktalı alt çizgi uygular:

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
            # Metin bölümü için yazı tipi özelliklerini ayarlayın.
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

![Metin bölümleri için yazı tipi özellikleri](font_properties_for_text_portions.png)

## **Metin Döndürme**

Bir şekil içinde önceden tanımlı bir metin yönelimi ayarlamak için [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setTextVerticalType) kullanın.

Aşağıdaki kod örneği, şeklin içindeki metin yönelimini [TextVerticalType.Vertical270](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textverticaltype/) olarak ayarlar; bu, metni **90 derece saat yönünün tersine** döndürür:

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

## **Metin Çerçeveleri İçin Özel Döndürme**

Bir [TextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframe/) için özel bir döndürme açısı ayarlamak için [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setRotationAngle) kullanın.

Aşağıdaki kod örneği, şeklin içinde metin çerçevesini 3 derece saat yönünde döndürür:

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

## **Paragrafların Satır Aralığını Ayarlama**

Aspose.Slides, paragraf aralığını kontrol etmek için [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setSpaceBefore) ve [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setSpaceWithin) metodlarını sunar. Bu özellikler şu şekilde kullanılır:

* Pozitif bir değer, satır aralığını satır yüksekliğinin yüzdesi olarak belirtir.
* Negatif bir değer, satır aralığını puan cinsinden belirtir.

Aşağıdaki örnek, ilk paragrafta satır aralığını satır yüksekliğinin %200’ü (çift satır aralığı) olarak ayarlar:

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

## **Satır Kesilmesini Kontrol Etme**

Paragraf satır kesme kuralları, dar metin bloklarında ve Latin ile Doğu Asya metninin karıştığı sunumlarda yararlıdır. Aşağıdaki yöntemler [ParagraphFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/)’a aittir, bu yüzden tüm paragraf için geçerlidir:

- [setLatinLineBreak](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) Latin satır kesme kurallarını kontrol eder. Karışık metinde değiştirilmesi, bitişik Doğu Asya metni ve noktalama işaretlerinin nerede kaydırılacağını da etkileyebilir.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) Doğu Asya satır kesme kurallarını, satırın başı ve sonundaki karakter kısıtlamalarını içerir.

Bu kurallar, bir metin çerçevesi içinde otomatik sarma sağlayan [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setWrapText) yerine geçmez; sadece sarma gerçekleştiğinde düzeni etkiler, satır sonu karakteri eklemezler. Açık bir satır sonu, paragrafta mevcut genişliğe bakılmaksızın yeni bir satır başlatır.

Aşağıdaki bağımsız örnek, Çince ve Latin metin içeren dar bir metin bloğu oluşturur. Her iki satır kesme seçeneğini de açıkça ayarlar ve “line_breaking.pptx” olarak kaydeder. Herhangi bir kuralı denemek için diğer ayarları sabit tutarken ilgili değeri değiştirin. Örnek, 24 puan Arial ve SimSun yazı tipini, 160 puan çerçeve genişliğini ve yatay metin çerçevesi kenar boşluklarını sıfır olarak kullanır. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setAutofitType) [TextAutofitType.None_](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textautofittype/) ile çağrılarak metin boyutu ve çerçeve boyutları sabit kalır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Asılı Noktalama İşaretlerini Kontrol Etme**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setHangingPunctuation), uygun noktalama işaretlerinin bir sonraki satırı işgal etmeden metin satırının sağ kenarının ötesine uzanmasına izin verir. Tüm paragraf için geçerlidir ve asılı girintiden farklıdır.

Aşağıdaki bağımsız örnek, 100 puan genişliğinde bir metin çerçevesinde asılı noktalama işaretlerini etkinleştirir ve “hanging_punctuation.pptx” olarak kaydeder. 24 puan Arial ve sıfır yatay çerçeve kenar boşluklarıyla, son nokta “sentence” kelimesinden sonra kalır ve sağ kenarın ötesine uzanır. Özelliği [NullableBool.False_](https://reference.aspose.com/slides/tr/python-java/aspose.slides/nullablebool/) olarak ayarlayarak karşılaştırın: bu ayarlarda nokta ayrı bir satırda yer alır. Sarma etkin ve otomatik sığdırma devre dışı bırakılmıştır, böylece kullanılabilir genişlik sabit kalır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Her noktalama işareti asılı olamaz. Görünen sonuç, yazı tipi kullanılabilirliğine ve düzenine bağlıdır: yazı tipini, kullanılabilir genişliği, kenar boşluklarını veya otomatik sığdırma ayarlarını değiştirmek farkı ortadan kaldırabilir.

## **Metin Çerçeveleri İçin Otomatik Sığdırma Türünü Ayarlama**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setAutofitType), metin kapsayıcısının sınırlarını aştığında metnin nasıl davranacağını belirler. Metnin küçülmesini, taşmasını veya şeklin otomatik olarak yeniden boyutlandırılmasını kontrol etmek için kullanın. Aşağıdaki örnek, şekli metnine göre yeniden boyutlandıracak şekilde yapılandırır ve sonucu “autofit_type.pptx” olarak kaydeder:

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

Otomatik sarma sonrası satır sayısını saymak ve metin ya da şekil genişliğinin sonucu nasıl etkilediğini görmek için [Render Edilen Satırları Sayma](/slides/tr/python-java/manage-paragraph/) bölümüne bakın. Satır sayısı yalnız başına, metnin kapsayıcıyı aşıp aşmadığını göstermez.

## **Metin Çerçevelerinin Sabitlemesini Ayarlama**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textframeformat/#setAnchoringType), metnin bir şekil içinde dikey konumlandırılmasını tanımlar; örneğin üst, orta veya alt. Aşağıdaki örnek, metni ilk şeklin alt kısmına sabitler ve sonucu “text_anchor.pptx” olarak kaydeder:

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

## **Metin Sekme Ayarlarını Yapma**

Bir paragrafta sekme duraklarını yapılandırmak için [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) ve [ParagraphFormat.getTabs](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraphformat/#getTabs) kullanın. Aşağıdaki örnek, varsayılan sekme aralığını 100 puan olarak ayarlar ve 30 puanda sola hizalı bir sekme durak ekler. Bu ayarlar sekme karakteri içeren metni etkiler:

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

## **Dil Denetimi Ayarını Yapma**

Aspose.Slides, bir metin bölümü için denetim dilini ayarlamanıza izin veren [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#setLanguageId) sağlar. Denetim dili, PowerPoint’te imla ve gramer denetimi için kullanılan dili belirler.

Aşağıdaki örnek, “presentation.pptx” dosyasında ilk slayttaki ilk şekil olarak bir metin kutusu ve en az bir paragraf gerektirir. İlk paragrafın içeriğini “1。” ile değiştirir, SimSun’u yazı tipi olarak ayarlar ve Basitleştirilmiş Çince denetim dilini (`zh-CN`) atar. Sonucu “proofing_language.pptx” olarak kaydeder:

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

    # Denetim dilinin kimliğini ayarlayın.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Varsayılan Dili Ayarlama**

Yükleme veya sunum oluşturma sırasında oluşturulan metin için varsayılan dili tanımlamak amacıyla [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) kullanın. Aşağıdaki örnek, varsayılan metin dili olarak ABD İngilizcesi ayarlayan bir sunum oluşturur, bir metin kutusu ekler ve ilk metin bölümü için `en-US` yazdırır:

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

## **Varsayılan Metin Stili Ayarlama**

Sunum düzeyinde varsayılan metin biçimlendirmesini uygulamak için [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/#getDefaultTextStyle) kullanın.

Aşağıdaki örnek, yeni bir sunumdaki üst düzey paragraflar için 14 puanlık kalın bir yazı tipi varsayılanı ayarlar ve “default_text_style.pptx” olarak kaydeder. Metin, daha belirgin bir biçimlendirme üzerine yazılmadıkça bu varsayılanları devralabilir.

```python
import jpype
import asposeslides

if not jpay

e.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Üst seviyedeki paragraf formatını al.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **All‑Caps Efektiyle Metin Çıkarma**

PowerPoint’te **All Caps** yazı tipi efekti, metni slaytta büyük harf olarak gösterir, ancak metin aslen küçük harfle girildiyse bile. Aspose.Slides ile böyle bir metin bölümü alındığında, kütüphane metni girildiği gibi döndürür. Görünen metinle eşleşmek için [TextCapType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/textcaptype/) kontrol edilip değer `All` olduğunda döndürülen dize büyük harfe çevrilir.

Bu örnek, ilk slayttaki ilk şekil olarak bir metin kutusu içeren “sample2.pptx” dosyasını gerektirir. İlk paragrafının ilk bölümü “Hello, Aspose!” metnini **All Caps** efektiyle içerir, aşağıda gösterildiği gibi.

![All Caps efekti](all_caps_effect.png)

Aşağıdaki kod örneği, **All Caps** efekti uygulanmış metni nasıl çıkaracağınızı gösterir:

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

Tablo içindeki metni değiştirmek için [Table](https://reference.aspose.com/slides/tr/python-java/aspose.slides/table/) kullanın. Hücreler üzerinde döngü yaparak her hücreyi [Cell.getTextFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cell/#getTextFrame) ve paragraf biçimlendirmesini [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/paragraph/#getParagraphFormat) ile güncelleyin.

**PowerPoint slaytındaki metne nasıl bir degrade (gradient) renk uygularım?**

Metne degrade renk uygulamak için [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseportionformat/#getFillFormat) kullanın. [FillFormat.setFillType](https://reference.aspose.com/slides/tr/python-java/aspose.slides/fillformat/#setFillType) değerini [FillType.Gradient](https://reference.aspose.com/slides/tr/python-java/aspose.slides/filltype/) olarak ayarlayın ve degrade duraklarını, yönünü ve şeffaflığını yapılandırın.