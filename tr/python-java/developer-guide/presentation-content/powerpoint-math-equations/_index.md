---
title: Python ile PowerPoint Sunumlarına Matematik Denklemleri Ekleme
linktitle: PowerPoint Matematik Denklemleri
type: docs
weight: 80
url: /tr/python-java/powerpoint-math-equations/
keywords:
- matematik denklemi
- matematik sembolü
- matematik formülü
- matematik metni
- matematik denklemi ekle
- matematik sembolü ekle
- matematik formülü ekle
- matematik metni ekle
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java kullanarak PowerPoint PPT ve PPTX dosyalarına matematik denklemleri ekleyin ve düzenleyin; OMML'yi destekler, biçimlendirme kontrolleri sağlar ve açık Python kod örnekleri sunar."
---
## **Genel Bakış**

PowerPoint, denklemleri Office Math Markup Language (OMML) olarak depolar. Aspose.Slides for Python via Java ile aynı türde matematik içeriğini programlı olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N‑ary operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint’te kullanıcılar genellikle **Ekle > Denklem** menüsünden denklemler ekler:

![PowerPoint Ekle sekmesi, Denklem komutu seçili](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir bir matematik metnidir:

![Düzenlenebilir bir matematik denklemi içeren PowerPoint slaytı](powerpoint-math-equations_2.png)

Aspose.Slides bu matematik metnini üç ana nesne aracılığıyla oluşturur:

- [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) ile oluşturulan bir matematik şekli, denklemi içeren şekildir.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) şeklin metin çerçevesi içinde matematik içeriğini depolar.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) nesnesi içerir.

Aşağıdaki çoğu örnek, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) ve [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) sınıflarının akıcı yöntemlerini kullanır.

MathML dışa aktarma senaryoları için [Export Math Equations from Presentations in Python](/slides/tr/python-java/exporting-math-equations/) bölümüne bakın.

## **Denklem Oluşturma**

Bu örnek, [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) kullanarak bir matematik şekli oluşturur ve Pisagor teoremini ekler:

![c² = a² + b² denklemi](powerpoint-math-equations_3.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    equation = MathematicalText("c").setSuperscript("2").join("=").join(a_squared).join("+").join(b_squared)

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) zaten bir matematik paragrafı içeren bir şekil oluşturur. İlk [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) alın, [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) çağırın ve ona matematik blokları veya elemanları ekleyin.
{{% /alert %}}

## **Kesir Ekleme**

Bir kesir oluşturmak için [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) kullanın. Kesir stilini [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/) ile seçebilirsiniz.

![x’e bölünmüş bir kesiri gösteren eğimli kesir](powerpoint-math-equations_4.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFractionTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    fraction = MathematicalText("1").divide("x", MathFractionTypes.Skewed)

    math_block = MathBlock(fraction)
    math_paragraph.add(math_block)

    presentation.save("fraction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Yığılmış (stacked) bir kesir için [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar) kullanın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **Kök Ekleme**

Karekök, küpkök veya başka bir kök oluşturmak için [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) kullanın. Mevcut eleman taban olur, argüman ise derecedir.

![x kök işareti altında bulunan n‑inci kök ifadesi](powerpoint-math-equations_5.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    radical = MathematicalText("x").radical("n")

    math_block = MathBlock(radical)
    math_paragraph.add(math_block)

    presentation.save("radical.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Fonksiyon ve Limit Ekleme**

`sin(x)`, `log(x)` gibi fonksiyonlar için [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) veya [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) kullanın. Limitler için `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) içine koyun veya [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit) kullanın.

![x sonsuza yaklaştıkça limit ifadesi](powerpoint-math-equations_8.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    limit = MathematicalText("lim").setLowerLimit("x\u2192\u221E").function("x")

    math_block = MathBlock(limit)
    math_paragraph.add(math_block)

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Özel bir fonksiyon adı için, fonksiyon adını mevcut eleman yapın ve argümanıyla birlikte [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) çağırın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **N‑ary Operatörler ve İntegraller Ekleme**

Toplamalar, birleşimler, kesişimler ve diğer büyük operatörler için [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) kullanın. İntegraller için [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) kullanın. Her iki yöntem de alt ve üst limitleri ayarlamanıza izin verir.

![Alt ve üst limitli bir toplam ifadesi](powerpoint-math-equations_7.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathNaryOperatorTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_power = MathematicalText("a").setSuperscript("n-k")
    summation_base = MathematicalText("x").setSuperscript("k").join(a_power)

    summation = summation_base.nary(MathNaryOperatorTypes.Summation, "k=0", "n")

    math_block = MathBlock(summation)
    math_paragraph.add(math_block)

    presentation.save("nary-operators.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

N‑ary operatörler, isteğe bağlı limitli büyük operatörler içindir. `+`, `-`, `=` gibi basit operatörler genellikle [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) ile eklenir ve ifadeye katılır.

Bir integral için [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) kullanın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathIntegralTypes, MathematicalText

differential = MathematicalText("dx").toBox()
integral_base = MathematicalText("x").join(differential)
integral = integral_base.integral(MathIntegralTypes.Simple, "0", "1")
```

## **Matris Ekleme**

Satır ve sütunlar için [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) kullanın. Matrisler varsayılan olarak köşeli parantez içermez; parantez, köşeli parantez veya süslü parantez gerektiğinde matrisinizi bu işaretlerle sarın.

![Bir boş hücreli iki satırlı matris](powerpoint-math-equations_10.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathMatrix, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    matrix = MathMatrix(2, 3)
    cell_0_0 = MathematicalText("1")
    matrix.set_Item(0, 0, cell_0_0)
    cell_0_1 = MathematicalText("x")
    matrix.set_Item(0, 1, cell_0_1)
    cell_1_0 = MathematicalText("x")
    matrix.set_Item(1, 0, cell_1_0)
    cell_1_1 = MathematicalText("2")
    matrix.set_Item(1, 1, cell_1_1)
    cell_1_2 = MathematicalText("y")
    matrix.set_Item(1, 2, cell_1_2)

    math_block = MathBlock(matrix)
    math_paragraph.add(math_block)

    presentation.save("matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Denklem Dizileri Ekleme**

Hizalanmış denklemler veya dikey yığın ifadeler için [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) kullanın.

![x üstünde y bulunan dikey bir matematik dizisi](powerpoint-math-equations_11.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 140)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    equation_array = MathematicalText("x").join("y").toMathArray()

    math_block = MathBlock(equation_array)
    math_paragraph.add(math_block)

    presentation.save("equation-array.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Diziyi Çevreleyen Elemanlarla Hizalama**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) bir dizinin, yanındaki matematik elemanlarına göre dikey hizasını kontrol eder. Aşağıdaki örnek, ilk satır, dizi merkezi ve son satır hizalarını karşılaştırır.

Aşağıdaki örnek, `A=` ve `=B` komşu elemanlarıyla aynı üç satırlı diziyi üç kez oluşturur. Tüm matematik metni Cambria Math 24 punto kullanır. Sadece dizi hizalaması değişir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathVerticalAlignment, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)
    
    alignments = (("Top", MathVerticalAlignment.Top), ("Center", MathVerticalAlignment.Center), ("Bottom", MathVerticalAlignment.Bottom))
    for index, (name, alignment) in enumerate(alignments):
        x = 20 + index * 260
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 10, 240, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(16)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        math_shape = slide.getShapes().addMathShape(x, 60, 240, 130)
        math_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(alignment)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Aşağıdaki karşılaştırma, PowerPoint’te kaydedilen sunumu gösterir. `A=` ve `=B` konumuna dikkat edin.

![Üst, orta ve alt hizalı denklem dizileri ve aynı komşu elemanlar](equation-array-alignment.png)

### **Satır Boşluğunu Yapılandırma**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) dizi içindeki satırların boşluk kuralını seçer. [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) sayısal bir değer sağlar ve önceden tanımlı kurallar tarafından göz ardı edilir.

Kesin boşluk için değer puan cinsindendir. Orantılı boşluk için yarı‑satır cinsindedir: örnekteki `3` değeri 1,5 satır demektir. Açık bir değer belirtirken her iki özelliği de ayarlayın; yalnızca sayısal değeri değiştirmek boşluk kuralını seçmez.

Aşağıdaki örnek, aynı denklemler, hizalama ve yazı tipi ayarlarıyla beş sunum kaydeder. İlk üçü ön tanımlı; son ikisi açık değerleri gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathRowSpacingRule, MathVerticalAlignment, Presentation, SaveFormat

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


settings = (("SingleLineGap", MathRowSpacingRule.SingleLineGap, 0), ("OneAndAHalfLineGap", MathRowSpacingRule.OneAndAHalfLineGap, 0), ("TwoLineGap", MathRowSpacingRule.TwoLineGap, 0), ("Exactly", MathRowSpacingRule.Exactly, 20), ("Multiple", MathRowSpacingRule.Multiple, 3))
for name, rule, spacing in settings:
    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        math_shape = slide.getShapes().addMathShape(20, 20, 600, 300)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(MathVerticalAlignment.Center)
        equation_array.setRowSpacingRule(rule)
        equation_array.setRowSpacing(spacing)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

        presentation.save(f"equation-array-{name}.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Dizi satır boşluğu, paragraf boşluğundan ayrıdır. [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) ve [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) içeren paragrafın etrafına boşluk ekler, dizi satırları arasına değil. Aynı şekilde, [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) tüm matematik paragrafını yatay olarak konumlandırır; dizi dikey hizalama ayarını değiştirmez.

## **Trigonometrik Fonksiyonlar Ekleme**

Argüman mevcut eleman olduğunda ve fonksiyon adı bilindiğinde [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) kullanın.

![cos(2x) trigonometrik fonksiyonu](powerpoint-math-equations_6.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFunctionsOfOneArgument, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    cosine = MathematicalText("2x").asArgumentOfFunction(MathFunctionsOfOneArgument.Cos)

    math_block = MathBlock(cosine)
    math_paragraph.add(math_block)

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Alt ve Üst İndeks Ekleme**

İndeks ve üstler için alt ve üst indis yardımcılarını kullanın. İndeksler temel elemanın sol tarafında görünmeliyse [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) kullanın.

![Sol tarafta alt indis 1 ve üst indis n olan büyük Y](powerpoint-math-equations_9.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    scripts = MathematicalText("Y").setSubSuperscriptOnTheLeft("1", "n")

    math_block = MathBlock(scripts)
    math_paragraph.add(math_block)

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ayraçlar Ekleme**

[enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) kullanarak bir ifadeyi ayraç içine koyun. Birden çok eleman içeren ayraç ifadelerinde ayırıcı karakter de ayarlayabilirsiniz.

![x, y ve z’nin dikey çubuklarla ayrıldığı bir ayraç ifadesi](powerpoint-math-equations_13.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    delimiter = MathematicalText("x").join("y").join("z").enclose('<', '>')
    delimiter.setSeparatorCharacter('|')

    math_block = MathBlock(delimiter)
    math_paragraph.add(math_block)

    presentation.save("delimiters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ayraçların Boyutu ve Hizalanması**

Parantezlerin yüksek bir işleme göre büyümesi için [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) metoduna `True` geçirin; `False` verirseniz normal boyutta kalırlar. [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) yöntemini iki [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) değerinden biriyle kullanın. `Centered` parantezleri matematik eksenine, yani eşittir işaretinin ortasına ortalar. `Match` ise içerdiği içerikle hizalar. Bu ayarlar yalnızca ayraçları etkiler; içteki ifade aynı kalır.

Örnek, `x` üssüne bir kesir koyar, böylece ifade tabandan daha çok yukarıya uzanır. Dört denklemin de aynı parantez ve yazı tipi ayarları vardır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathDelimiterShape, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    for row, grow in enumerate((True, False)):
        for column, shape in enumerate((MathDelimiterShape.Centered, MathDelimiterShape.Match)):
            fraction = MathematicalText("a + b").divide("c + d")
            power = MathematicalText("x").setSuperscript(fraction)
            delimiter = power.enclose("(", ")")
            delimiter.setGrowToMatchOperandHeight(grow)
            delimiter.setDelimiterShape(shape)

            math_shape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100)
            portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            portion.getPortionFormat().setFontHeight(32)
            equation = MathematicalText("y = ").join(delimiter)
            portion.getMathParagraph().add(equation)

    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

PowerPoint’te satırları karşılaştırarak büyüme etkisini görebilirsiniz. Üst satırda parantezler büyür ve iki şekil de aynı görünür. Alt satırda büyüme kapalıdır; sol taraftaki daha küçük parantez (`Centered`) eşittir işaretiyle hizalı, sağ taraftaki (`Match`) ise ifadeyi daha yukarıda tutar.

![Parantez büyümesi etkin ve devre dışı olan dört denklem, solda Centered sağda Match](delimiter-sizing.png)

## **Kenar Kutusu Ekleme**

Bir kesirin tüm ifadesini çerçevelemek için kesire [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) uygulayın. Dönen [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) varsayılan olarak dört kenarı gösterir. Tek tek kenarları kaldırmak için [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) ve [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) kullanın.

Örnek, aynı kesirin altı kopyasını bir slaytta gösterir. İptal işareti için tüm kenarları gizleyin ve yükselen diyagonal (`↗`) için [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight), düşen diyagonal (`↘`) için [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) `True` gönderin. Ayrıca, görünür kenar kombinasyonlarıyla [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) veya [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) kullanabilirsiniz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    def add_fraction(x, y, hide_border):
        fraction = MathematicalText("x+1").divide("y+2")
        box = fraction.toBorderBox()
        box.setHideTop(hide_border)
        box.setHideBottom(hide_border)
        box.setHideLeft(hide_border)
        box.setHideRight(hide_border)

        shape = slide.getShapes().addMathShape(x, y, 160, 90)
        portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        portion.getPortionFormat().setFontHeight(28)
        math_block = MathBlock(box)
        portion.getMathParagraph().add(math_block)
        return box

    add_fraction(10, 10, False)

    partial = add_fraction(190, 10, False)
    partial.setHideTop(True)
    partial.setHideRight(True)

    add_fraction(370, 10, True).setStrikethroughBottomLeftToTopRight(True)
    add_fraction(10, 120, True).setStrikethroughTopLeftToBottomRight(True)
    add_fraction(190, 120, True).setStrikethroughHorizontal(True)
    add_fraction(370, 120, False).setStrikethroughVertical(True)

    presentation.save("border-box.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![PowerPoint’te altı düzenlenebilir kesir. Üst satır: tam kenar, alt ve sol kenar, yükselen diyagonal. Alt satır: düşen diyagonal, yatay çizgi, dikey çizgi ve tam kenar.](border-box-fractions.png)

Bu kesirde, yatay çizgi kesir çubuğunun üzerine gelir. Dikey çizgi hem payı hem de paydayı keserken etrafındaki kenar görünür kalır. Bu çizgiler tüm ifadeyi süsler. Normal metin üzeri çizgi yalnızca metin koşulları için geçerlidir. Sunumu PowerPoint’te yeniden açtığınızda pay ve payda bağımsız olarak düzenlenebilir.

## **Terim Gruplama**

[group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) kullanarak bir ifadeyi üstüne veya altına bir gruplama karakteri koyun. Gruplanan terimleri etiketlemek için bir limit ekleyin.

![x + y ifadesi, altında “any text” etiketiyle gruplanmış](powerpoint-math-equations_15.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathTopBotPositions, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    grouped = MathematicalText("x + y").group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top).setLowerLimit("any text")

    math_block = MathBlock(grouped)
    math_paragraph.add(math_block)

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Matematik Elemanlarını Biçimlendirme**

Biçimlendirme yardımcılarını yalnızca formülü netleştirdiğinde kullanın. Örneğin, [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) bir matematik elemanının üzerine bir çubuk koyar.

![Üstünde bir çubuk bulunan ABC matematik ifadesi](powerpoint-math-equations_14.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    overbar = MathematicalText("ABC").overbar()

    math_block = MathBlock(overbar)
    math_paragraph.add(math_block)

    presentation.save("overbar.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Mevcut Bir Denklemi Biçimlendirme**

Mevcut bir denklemin tamamını biçimlendirmek için her matematik bloğunun eleman ağacını dolaşın. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) yalnızca doğrudan çocukları döndürür; bu nedenle kesirler, üst/alt indisler, kökler ve diğer iç içe yapılar içinde metne ulaşmak için yinelemeli olarak çağırın. Başlangıç elemanı da [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) ise onu da dahil edin.

Bu örnek, `input.pptx` dosyasının `z = xᵢ / ∛y` gibi bir denklem içerdiğini varsayar; payda bir kök, payda bir alt indis içerir. Sadece bloğun üst düzey elemanlarını işlemek, kesir içindeki metni kaçırır. Örnek, slayt metin çerçevelerindeki matematik parçalarını bulur, bloklarına [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) üzerinden ulaşır ve her metin elemanının [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) metodunu kullanarak [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) ile yazı tipi boyutunu 28 punto olarak ayarlar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathematicalText, MathPortion, Presentation, SaveFormat


def format_math_text(element):
    if isinstance(element, MathematicalText):
        element.getFormat().setFontHeight(28)

    for child in element.getChildren():
        format_math_text(child)


presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    if isinstance(portion, MathPortion):
                        for block in portion.getMathParagraph():
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Kaydedilen sunum, işlenen her denklemdeki tüm seviyelerde güncellenmiş metin biçimlendirmesini içerirken, metin içeriğini ve matematik yapısını korur.

## **Hızlı Referans**

| Görev | Ana API |
| --- | --- |
| Matematik metni oluşturma | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| Elemanları birleştirme | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| Kesir oluşturma | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| Üst/alt indis ekleme | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| Fonksiyon ekleme | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| Kök ekleme | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| Limit ekleme | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| Sol‑taraflı üst/alt indis ekleme | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| Toplam ve integraller ekleme | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| Matris ekleme | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| Denklem dizileri ekleme | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| Ayraç ekleme | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| Çubuk ve kenar ekleme | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| Terim gruplama | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **SSS**

**Mevcut bir PowerPoint denklemindeki metni düzenleyebilir miyim?**

Evet. Sunumu açın, bir [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) içeren şekli bulun, [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) çağırın ve o paragraftaki matematik bloklarını güncelleyin.

**Deneklemler düzenlenebilir PowerPoint matematiği olarak kaydediliyor mu?**

Evet. PPTX olarak kaydettiğinizde Aspose.Slides denklemi düzenlenebilir Office math içeriği olarak yazar.

**Deneklemleri LaTeX’e dışa aktarabilir miyim?**

Evet. Denklemin [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) nesnesini, ona bağlı [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) üzerinden alın ve doğrudan dışa aktarmak için [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) çağırın. Tam örnek için **[Export Math Equations from Presentations in Python](/slides/tr/python-java/exporting-math-equations/#export-math-equations-to-latex)** bölümüne bakın.