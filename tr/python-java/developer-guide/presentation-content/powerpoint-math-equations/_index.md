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
description: "Aspose.Slides for Python via Java ile PowerPoint PPT ve PPTX içinde matematik denklemlerini ekleyin ve düzenleyin, OMML desteği, biçimlendirme kontrolleri ve net Python kod örnekleri sağlar."
---
## **Genel Bakış**

PowerPoint, denklemleri Office Math Markup Language (OMML) olarak depolar. Aspose.Slides for Python via Java ile aynı tür matematik içeriğini programlı olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N‑ary operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint’te kullanıcılar genellikle **Ekle > Denklem** menüsünden denklemler ekler:

![PowerPoint Ekle sekmesi, Denklem komutu seçili halde](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir bir matematik metni olur:

![Düzenlenebilir bir matematik denklemi içeren PowerPoint slaytı](powerpoint-math-equations_2.png)

Aspose.Slides bu matematik metnini üç ana nesne üzerinden oluşturur:

- [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) ile oluşturulan bir matematik şekli, denklemi içerir.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) şeklin metin çerçevesinde matematik içeriğini saklar.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/) nesnesi içerir.

Aşağıdaki çoğu örnek, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) ve [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/)‘nin akıcı metodlarını kullanır.

MathML dışa aktarma senaryoları için, [Export Math Equations from Presentations in Python](/slides/tr/python-java/exporting-math-equations/) bölümüne bakın.

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
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) zaten bir matematik paragrafı içeren bir şekil oluşturur. İlk [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) öğesine erişin, [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) metodunu çağırın ve ona matematik blokları veya matematik öğeleri ekleyin.
{{% /alert %}}

## **Kesir Ekleme**

Kesir oluşturmak için [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) metodunu kullanın. Kesir stilini [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/) ile seçebilirsiniz.

![x ile bölünen bir kesir](powerpoint-math-equations_4.png)

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

Yığılmış bir kesir için [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar) kullanın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **Kök Ekleme**

Kare kök, küp kök ya da başka bir kök oluşturmak için [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) metodunu kullanın. Mevcut öğe taban olur, argüman ise derece olur.

![x altında kök işareti olan n‑inci kök ifadesi](powerpoint-math-equations_5.png)

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

### **Kare Kökün Derecesini Gösterme veya Gizleme**

Kare kök, açık bir 2 gösterebilir veya geleneksel √x gösterimini kullanabilir. [MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/)‘nin [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree) metodu hangi formun görüneceğini denetler. Her iki form da derecesi 2 ve radikand x’i düzenlenebilir denklemde tutar.

![Sol tarafta derecesi görünür, sağ tarafta gizli aynı kare kök](square-root-degree.png)

Örnek aynı kare kökü iki kez kaydeder. `visible-degree.pptx` dosyasında 2 görünür; `hidden-degree.pptx` dosyasında gizlidir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    radical = MathematicalText("x").radical("2")
    math_block = MathBlock(radical)

    math_shape = slide.getShapes().addMathShape(20, 20, 200, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()
    math_paragraph.add(math_block)

    radical.setHideDegree(False)
    presentation.save("visible-degree.pptx", SaveFormat.Pptx)

    radical.setHideDegree(True)
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Fonksiyon ve Limit Ekleme**

`sin(x)`, `log(x)` gibi fonksiyonlar için [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) veya [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) metodunu kullanın. Limitler için `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) içine koyun veya [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit) metodunu kullanın.

![x → ∞ limit ifadesi](powerpoint-math-equations_8.png)

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

Özel bir fonksiyon adı için, fonksiyon adını mevcut öğe yapın ve argümanı ile birlikte [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) metodunu çağırın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **N‑ary Operatörler ve İntegraller Ekleme**

Toplamalar, birleşimler, kesişimler ve diğer büyük operatörler için [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) metodunu kullanın. İntegraller için [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) metodunu kullanın. Her iki metod da alt ve üst limitleri ayarlamanıza izin verir.

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

N‑ary operatörler, isteğe bağlı limitli büyük operatörler içindir. `+`, `-` ve `=` gibi basit operatörler genellikle [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) ile eklenir ve ifadeye katılır.

İntegral için [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) metodunu kullanın:

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

Satır ve sütunlar için [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) kullanın. Matrisler varsayılan olarak köşeli parantez içermez; parantez, köşeli parantez veya süslü parantez gerektiğinde matrisi bu karakterlerle sarın.

![Bir boş hücreli iki satırlı matematik matrisi](powerpoint-math-equations_10.png)

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

### **Mevcut Bir Matrisi Düzenleme**

`matrix.pptx` dosyasında katsayı matrisi bulunan bir lineer cebir dersi olduğunu varsayalım; bu dosya önceki örnek tarafından kaydedildi. Sonraki alıştırmada, ilk denklemi koruyun, ikinciyi iki yeni denklemle değiştirin ve değişken kümesini yeniden düzenleyin. Katkı hâlâ geçerli olan katsayıları korumak için mevcut matrisi [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) aracılığıyla açın.

![İlk satırda 1, x ve boş hücre, ikinci satırda x, 2 ve y bulunan orijinal iki satırlı katsayı matrisi](matrix-before-edit.png)

Satır ve sütun indeksleri sıfırdan başlar ve her çağrıda matrisin o anki durumuna referans verir. 1 indeksinden önce bir satır eklemek, orijinal ikinci satırı 2 indeksine taşır. 2 indeksinden sonra eklemek ise bir satır ekler. 2 indeksindeki satırı silmek, orijinal ikinci denklemi kaldırır ve eklenen satırı bir konuma yükseltir. Sütunlar da aynı şekilde kayar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathHorizontalAlignment, MathematicalText, Presentation, SaveFormat

presentation = Presentation("matrix.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    matrix = portion.getMathParagraph().get_Item(0).get_Item(0)

    matrix.insertRowBefore(1)
    matrix.insertRowAfter(2)
    matrix.deleteRow(2)

    matrix.insertColumnBefore(1)
    matrix.insertColumnAfter(3)
    matrix.deleteColumn(3)

    # Yeni hücreler başlangıçta boştur. Sıfır olmayan katsayıları önce ayarlayın.
    matrix.set_Item(1, 0, MathematicalText("12"))
    matrix.set_Item(1, 1, MathematicalText("1"))
    matrix.set_Item(2, 2, MathematicalText("10"))
    matrix.set_Item(2, 3, MathematicalText("1"))
    for row in range(matrix.getRowCount()):
        for column in range(matrix.getColumnCount()):
            if matrix.get_Item(row, column) is None:
                matrix.set_Item(row, column, MathematicalText("0"))

    matrix.setColumnAlignment(0, MathHorizontalAlignment.Left)
    matrix.setColumnsAlignment(1, 3, MathHorizontalAlignment.Right)
    
    presentation.save("updated-matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setColumnAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnAlignment) ilk sütunu sola hizalar. [setColumnsAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnsAlignment) kalan üç sütunu sağa hizalar; indeks 1’den başlar. `updated-matrix.pptx` dosyasında matris üç denklem ve dört değişken içerir. Orijinal ilk satır katsayıları `1` ve `x` artık ilk ve üçüncü sütunlarda görünür.

![Güncellenmiş üç satırlı matris; satırlar: 1, 0, x, 0; 12, 1, 0, 0; ve 0, 0, 10, 1](matrix-after-edit.png)

## **Denklem Dizileri Ekleme**

Hizalanmış denklemler veya dikey yığın ifadeler gerektiğinde [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) metodunu kullanın.

![x üstünde y bulunan dikey matematik dizisi](powerpoint-math-equations_11.png)

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

### **Diziyi Çevreleyen Öğelerle Hizalama**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) bir dizinin, yanındaki matematik öğelerine göre dikey hizalanmasını denetler. Aşağıdaki örnek, birinci satır, dizi ortası ve son satır hizalamalarını karşılaştırır.

Aşağıdaki örnek üç aynı diziyi oluşturur; her biri üç satır ve komşu öğeler `A=` ve `=B` içerir. Tüm matematik metni Cambria Math ile 24 puan büyüklüğündedir. Sadece dizi hizalaması değişir.

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

Aşağıdaki karşılaştırma PowerPoint’te kaydedilen sunumu gösterir. `A=` ve `=B` öğelerinin her dizi yanındaki konumuna dikkat edin.

![Üst, orta ve alt hizalama ile aynı yan öğelere sahip PowerPoint denklem dizileri](equation-array-alignment.png)

### **Satır Aralığını Yapılandırma**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) dizideki satırlar için aralık kuralını seçer. [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) sayısal bir değer sağlar; önceden ayarlanmış kurallar tarafından yok sayılır.

Kesin aralık için değer puan cinsindendir. Orantılı aralık için yarım satır cinsindendir: örnekteki `3` değeri 1,5 satır demektir. Kesin bir değer belirtirken her iki özelliği de ayarlayın; sadece sayısal değeri değiştirmek aralık kuralını seçmez.

Aşağıdaki örnek aynı denklemler, hizalama ve yazı tipi ayarlarıyla beş sunum kaydeder. İlk üçü ön ayarları, son ikisi ise kesin değerleri gösterir.

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

Dizi satır aralığı, paragraf aralığından ayrı tutulur. [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) ve [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) kapsayan paragrafın çevresine boşluk ekler, dizi satırları arasına değil. Benzer şekilde, [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) tüm matematik paragrafını yatay olarak konumlandırır; dizi dikey hizalama ayarını değiştirmez.

## **Trigonometrik Fonksiyonlar Ekleme**

Argüman mevcut öğe olduğunda ve fonksiyon adı bilindiğinde [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) metodunu kullanın.

![cos fonksiyonunun 2x üzerine uygulanması](powerpoint-math-equations_6.png)

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

İndeksler ve üsler için alt ve üst indeks yardımcılarını kullanın. İndeksler tabanın sol tarafında görünmeli ise [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) metodunu kullanın.

![Sol tarafta alt indeks 1 ve üst indeks n olan büyük Y harfi](powerpoint-math-equations_9.png)

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

## **Ayırıcılar Ekleme**

Bir ifadeyi ayırıcıların içine koymak için [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) metodunu kullanın. Birden çok öğe içeren ayırıcı ifadeler için bir ayırıcı karakteri de belirleyebilirsiniz.

![x, y ve z öğeleri dikey çubuklarla ayrılmış bir ayırıcı ifadesi](powerpoint-math-equations_13.png)

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

### **Ayırıcıları Boyutlandırma ve Hizalama**

Parantezlerin yüksek bir operanda göre büyümesi için [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) metoduna `True` gönderin; normal boyutta kalması için `False` gönderin. [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) metodunu iki [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/) değerinden biriyle kullanın. `Centered` parantezleri matematik eksenine (eşittir işaretinin ortasına) ortalar; `Match` ise içeriğe göre hizalar. Her iki ayar da yalnızca ayırıcıları etkiler; içteki ifade aynı kalır.

Örnek, `x` üssünde bir kesir yerleştirir; böylece ifade altına göre daha yüksek bir baz çizgisi oluşturur. Dört denklem de aynı parantez ve yazı tipi ayarlarını kullanır.

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

PowerPoint’te satırları karşılaştırarak büyümenin etkisini görebilirsiniz. Üst satırda parantezler üssü kapsayacak şekilde büyür ve iki şekil de benzer görünür. Alt satırda büyüme kapalıdır; sol taraftaki daha küçük parantez (`Centered`) eşittir işaretiyle hizalanır, sağ taraftaki (`Match`) ise ifadeyi daha yüksek bir seviyede tutar.

![Üstte büyütülmüş, altta büyütülmemiş ayırıcılarla dört denklem; sol tarafta Centered, sağ tarafta Match](delimiter-sizing.png)

## **Köşe Kutusu Ekleme**

Bir kesiri çerçevelemek için kesir üzerinde [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) metodunu çağırın. Döndürülen [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) varsayılan olarak dört kenarı gösterir. Tek tek kenarları kaldırmak için [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) ve [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) metodlarını kullanın.

Örnek, aynı kesirin altı kopyasını bir slayda yerleştirir. İptal göstermek için tüm dört kenarı gizleyin ve yükselen bir diyagonal (↗) için [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) metoduna `True` gönderin; düşen bir diyagonal (↘) için ise [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) metodunu kullanın. Ayrıca herhangi bir kenar kombinasyonu ile görünebilir kenarlar üzerinde [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) veya [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) metodlarını da kullanabilirsiniz.

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

![Üst satır: tam çerçeve, alt ve sol kenarlar, yükselen diyagonal. Alt satır: düşen diyagonal, yatay çizgi, dikey çizgi ve tam çerçeve](border-box-fractions.png)

Bu kesirde, yatay çizgi kesir çubuğunun üzerine çıkar. Dikey çizgi hem sayıyı hem de paydayı keser; çevre çerçeve hâlâ görünür. Bu çizgiler bütün ifadeyi süsler. Normal metin üzeri çizgisi sadece metin yürütmesindeki karakterlere uygulanır. Sunumu PowerPoint’te tekrar açtıktan sonra payda ve payı bağımsız olarak düzenlemeye devam edebilirsiniz.

## **Hayalet (Phantom) Öğelerle Görünürlük ve Yerleşim Kontrolü**

Bir ifadeyi [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) ile sararak, görünürlüğünü ve denkleme katkı sağladığı alanı bağımsız olarak kontrol edebilirsiniz. [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) metodları şunları denetler:

| Metod | Etki |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | `False` verilirse ifade gizlenir. Boyutları hâlâ yerleşime katkı sağlar, alt metodlar `True` almazsa. |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | İfadenin yatay genişliği sıfır olarak kabul edilir, komşu öğeler daha yakınlaşır. |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | Üst yükselişi (baseline üzerindeki yükseklik) sıfır kabul edilir; üstteki öğeler için ayrılan alan azalır. |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | Alçak düşüş (baseline altındaki derinlik) sıfır kabul edilir; kesir çubuğu gibi öğeler komşulara daha yakınlaşır. |

Baseline, sıradan matematiksel harflerin oturduğu referans çizgisidir. İçeriği gizlemek boyutlarını kaldırmaz; bir boyutu sıfır olarak ayarlamak ifadeyi silmez. Alt ifade [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase) ile hâlâ erişilebilir. Tekrar göstermek için [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) metoduna `True` verin; boyut ayarları değişmeden kalır.

Aşağıdaki örnek beş yan yana varyant oluşturur: görünür bir kesir, alan ayıran gizli bir kesir ve bir boyutu sıfır olarak ayarlanan üç gizli kesir. Her varyant aynı dış ifadeyi ve 24 puan Cambria Math’ı kullanır. Tüm denklem şekilleri aynı üst konuma sahiptir; gri kılavuzla işaretlenmiştir. Hayalet öğeyi dış kesirin paydasına koymak, dikey yerleşim değişikliklerini görmeyi kolaylaştırır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathBlock, MathFraction, MathematicalText, MathPhantom, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color


def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    labels = ("Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc")

    guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0)
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)

    for index, name in enumerate(labels):
        left = 10 + index * 200
        
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(14)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = MathFraction(fraction_numerator, fraction_denominator)
        phantom = MathPhantom(fraction)
        phantom.setShow(index == 0)
        phantom.setZeroWidth(index == 2)
        phantom.setZeroAsc(index == 3)
        phantom.setZeroDesc(index == 4)

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = MathFraction(numerator, denominator)

        shape = slide.getShapes().addMathShape(left, 60, 190, 100)
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        math_portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        math_paragraph = math_portion.getMathParagraph()
        math_block = MathBlock(equation)
        math_paragraph.add(math_block)

    presentation.save("math-phantom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Görünür kesir, alan ayıran gizli kesir ve ZeroWidth, ZeroAsc veya ZeroDesc etkinleştirilmiş gizli kesirleri karşılaştıran beş PowerPoint denklemi](math-phantom.png)

## **Terimleri Gruplama**

[group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) metodunu kullanarak bir ifadenin üzerine veya altına grup karakteri yerleştirebilirsiniz. Gruplanan terimleri etiketlemek için bir limit ekleyin.

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

## **Matematik Öğelerini Biçimlendirme**

Biçimlendirme yardımcılarını yalnızca formülü netleştirdiğinde kullanın. Örneğin, [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) bir matematik öğesinin üzerine bir çubuk ekler.

![Üstünde overbar olan ABC matematik ifadesi](powerpoint-math-equations_14.png)

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

Mevcut bir denklemin tüm metnini biçimlendirmek için her matematik bloğunun öğe ağacını dolaşın. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) yalnızca doğrudan çocukları döndürür; bu yüzden kesirler, üst/alt indeksler, kökler ve diğer iç içe yapılar içinde metin bulmak için yöntemi yinelemeli olarak çağırın. Başlangıç öğesi de dahil olmak üzere, öğeyi ve çocuklarını kontrol edin; [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) olduğunda da dahil edin.

Bu örnek, `input.pptx` dosyasının `z = xᵢ / ∛y` gibi bir denklem içerdiğini varsayar; burada payda bir radikal, payda bir kesir ve payda bir alt indeks bulunur. Yalnızca bloğun üst düzey öğelerini işlemek kesrin içindeki metni kaçırır. Örnek, slayt metin çerçevelerindeki matematik bölümlerini bulur, bloklara [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) ile erişir ve her metin öğesinin [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) metodunu kullanarak [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) ile yazı tipi yüksekliğini 28 puana ayarlar.

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

Kaydedilen sunum, işlenen her denklemin her seviyesinde güncellenmiş metin biçimlendirmesini içerir; metin içeriği ve matematiksel yapısı korunur.

## **Hızlı Başvuru**

| Görev | Ana API |
| --- | --- |
| Matematik metni oluşturma | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| Öğeleri birleştirme | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| Kesir oluşturma | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| Üst/alt indeks ekleme | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| Fonksiyon ekleme | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| Kök ekleme | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| Limit ekleme | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| Sol‑taraflı üst/alt indeks ekleme | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| Toplamlar ve integraller ekleme | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| Matris ekleme | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| Denklem dizileri ekleme | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| Ayırıcı ekleme | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| Çubuk ve kenarlık ekleme | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| Terimleri gruplama | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **SSS**

**Mevcut bir PowerPoint denklemine düzenleme yapabilir miyim?**

Evet. Sunumu açın, bir [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) içeren şekli bulun, [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) metodunu çağırın ve o paragraftaki matematik bloklarını güncelleyin.

**Denklikler düzenlenebilir PowerPoint matematiği olarak kaydediliyor mu?**

Evet. PPTX olarak kaydedildiğinde, Aspose.Slides denklemi düzenlenebilir Office matematik içeriği olarak yazar.

**Denklikleri LaTeX’e dışa aktarabilir miyim?**

Evet. Denklemin [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) nesnesini, içinde bulunduğu [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) üzerinden alın ve doğrudan dışa aktarmak için [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) metodunu çağırın. Tam bir örnek için [Export Math Equations from Presentations in Python](/slides/tr/python-java/exporting-math-equations/#export-math-equations-to-latex) sayfasına bakın.