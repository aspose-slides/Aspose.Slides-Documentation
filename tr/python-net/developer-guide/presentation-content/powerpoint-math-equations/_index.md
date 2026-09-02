---
title: Python ile PowerPoint Sunumlarına Matematik Denklemleri Ekleme
linktitle: PowerPoint Matematik Denklemleri
type: docs
weight: 80
url: /tr/python-net/powerpoint-math-equations/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET kullanarak PowerPoint PPT ve PPTX dosyalarında matematik denklemlerini ekleyin ve düzenleyin, OMML desteği, biçimlendirme kontrolleri ve açıklayıcı Python kod örnekleri sunar."
---
## **Genel Bakış**

PowerPoint denklemleri Office Math Markup Language (OMML) olarak depolar. Aspose.Slides for Python via .NET ile aynı tür matematik içeriğini programlı olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N-ary operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint'te kullanıcılar genellikle denklemleri **Ekle > Denklem** menüsünden ekler:

![PowerPoint Ekle sekmesi, Denklem komutu seçili](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir bir matematik metnidir:

![Düzenlenebilir bir matematik denklemi içeren bir PowerPoint slaytı](powerpoint-math-equations_2.png)

Aspose.Slides bu matematik metnini üç ana nesne üzerinden oluşturur:

- [add_math_shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shapecollection/add_math_shape/) ile oluşturulan bir matematik şekli, denklemi içerir.
- [MathPortion](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathportion/) şeklin metin çerçevesindeki matematik içeriğini saklar.
- [MathParagraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathblock/) nesnesi içerir.

Aşağıdaki çoğu örnek, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathematicaltext/) ve [IMathElement](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/) akıcı metodlarını kullanır.

MathML dışa aktarma senaryoları için, [Export Math Equations from Presentations in Python via .NET](/slides/tr/python-net/exporting-math-equations/) bölümüne bakın.

## **Bir Denklem Oluşturma**

Bu örnek bir matematik şekli oluşturur ve Pisagor teoremini ekler:

![c² = a² + b² denklemi](powerpoint-math-equations_3.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation = (
        math.MathematicalText("c")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("a").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("b").set_superscript("2"))
    )

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
`add_math_shape` zaten bir matematik paragrafı içeren bir şekil oluşturur. İlk `MathPortion`a erişin, `MathParagraph`ını alın ve ona matematik blokları veya matematik öğeleri ekleyin.
{{% /alert %}}

## **Kesir Ekleme**

Kesir oluşturmak için [`divide`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/divide/) kullanın. Kesir stilini [MathFractionTypes](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathfractiontypes/) ile seçebilirsiniz.

![x'e bölünmüş bir kesiri gösteren eğik bir matematik kesiri](powerpoint-math-equations_4.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("1").divide("x", math.MathFractionTypes.SKEWED)

    math_paragraph.add(math.MathBlock(fraction))

    presentation.save("fraction.pptx", slides.export.SaveFormat.PPTX)
```

Katmanlı bir kesir için `MathFractionTypes.BAR` kullanın:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Kök Ekleme**

Kök (kare kök, küp kök veya başka bir kök) oluşturmak için [`radical`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/radical/) kullanın. Mevcut öğe taban olur, argüman derece olur.

![x kök işareti altında n‑inci kök ifadesi](powerpoint-math-equations_5.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    radical = math.MathematicalText("x").radical("n")

    math_paragraph.add(math.MathBlock(radical))

    presentation.save("radical.pptx", slides.export.SaveFormat.PPTX)
```

## **Fonksiyonlar ve Limitler Ekleme**

`sin(x)`, `log(x)` gibi fonksiyonlar için [`as_argument_of_function`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) veya [`function`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/function/) kullanın. Limitler için `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathlimit/) içine koyun veya [`set_lower_limit`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/) kullanın.

![x'in sınırı, x sonsuza yaklaştıkça](powerpoint-math-equations_8.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    limit = (
        math.MathematicalText("lim")
        .set_lower_limit("x\u2192\u221E")
        .function("x")
    )

    math_paragraph.add(math.MathBlock(limit))

    presentation.save("functions-and-limits.pptx", slides.export.SaveFormat.PPTX)
```

Özel bir fonksiyon adı için, fonksiyon adını mevcut öğe yapın:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **N-ary Operatörler ve İntegraller Ekleme**

Toplamalar, birleşimler, kesişimler ve diğer büyük operatörler için [`nary`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/nary/) kullanın. İntegraller için [`integral`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/integral/) kullanın. Her iki yöntem de alt ve üst limitleri ayarlamanıza izin verir.

![Alt ve üst limitli bir toplam](powerpoint-math-equations_7.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    summation_base = (
        math.MathematicalText("x")
        .set_superscript("k")
        .join(math.MathematicalText("a").set_superscript("n-k"))
    )

    summation = summation_base.nary(math.MathNaryOperatorTypes.SUMMATION, "k=0", "n")

    math_paragraph.add(math.MathBlock(summation))

    presentation.save("nary-operators.pptx", slides.export.SaveFormat.PPTX)
```

N-ary operatörler, isteğe bağlı limitleri olan büyük operatörler içindir. `+`, `-`, `=` gibi basit operatörler genellikle `MathematicalText` olarak eklenir ve ifadeye katılır.

İntegral için `integral` kullanın:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Matrisler Ekleme**

Satır ve sütunlar için [MathMatrix](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathmatrix/) kullanın. Matrisler varsayılan olarak parantez içermez, bu yüzden parantez, köşeli ayraç veya süslü parantez gerektiğinde matrisi çevreleyin.

![Bir boş hücresi olan iki satırlı bir matematik matrisi](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)
    matrix[0, 0] = math.MathematicalText("1")
    matrix[0, 1] = math.MathematicalText("x")
    matrix[1, 0] = math.MathematicalText("x")
    matrix[1, 1] = math.MathematicalText("2")
    matrix[1, 2] = math.MathematicalText("y")

    math_paragraph.add(math.MathBlock(matrix))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

## **Denklem Dizileri Ekleme**

Hizalanmış denklemlere veya dikey yığılmış ifadeler gerektiğinde [`to_math_array`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/to_math_array/) kullanın.

![x'in y üstünde olduğu dikey bir matematik dizisi](powerpoint-math-equations_11.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 140)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation_array = (
        math.MathematicalText("x")
        .join("y")
        .to_math_array()
    )

    math_paragraph.add(math.MathBlock(equation_array))

    presentation.save("equation-array.pptx", slides.export.SaveFormat.PPTX)
```

## **Trigonometrik Fonksiyonlar Ekleme**

Argüman mevcut öğe ve fonksiyon adı biliniyorsa [`as_argument_of_function`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) kullanın.

![2x'e uygulanan cos trigonometrik fonksiyonu](powerpoint-math-equations_6.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    cosine = math.MathematicalText("2x").as_argument_of_function(
        math.MathFunctionsOfOneArgument.COS
    )

    math_paragraph.add(math.MathBlock(cosine))

    presentation.save("trigonometric-function.pptx", slides.export.SaveFormat.PPTX)
```

## **Alt Simge ve Üst Simge Ekleme**

İndeksler ve üsler için alt simge ve üst simge yardımcılarını kullanın. İndeksler tabanın sol tarafında görünmeli ise [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) kullanın.

![Sol tarafta alt simge 1 ve üst simge n olan büyük Y](powerpoint-math-equations_9.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    scripts = math.MathematicalText("Y").set_sub_superscript_on_the_left("1", "n")

    math_paragraph.add(math.MathBlock(scripts))

    presentation.save("subscript-superscript.pptx", slides.export.SaveFormat.PPTX)
```

## **Ayraçlar Ekleme**

İfadenin etrafına ayraç koymak için [`enclose`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/enclose/) kullanın. Birden fazla öğe içeren ayraç ifadeleri için ayrıcı karakter de ayarlayabilirsiniz.

![x, y ve z öğelerini dikey çubuklarla ayıran bir ayraç ifadesi](powerpoint-math-equations_13.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    delimiter = (
        math.MathematicalText("x")
        .join("y")
        .join("z")
        .enclose("<", ">")
    )
    delimiter.separator_character = "|"

    math_paragraph.add(math.MathBlock(delimiter))

    presentation.save("delimiters.pptx", slides.export.SaveFormat.PPTX)
```

## **Kutu Kenarlığı Ekleme**

Denklik kendisi bir çerçeve içinde gösterilmek isteniyorsa [`to_border_box`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/to_border_box/) kullanın.

![a² = b² + c² gösteren kutu içinde bir denklem](powerpoint-math-equations_12.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    boxed_equation = (
        math.MathematicalText("a")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("b").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("c").set_superscript("2"))
        .to_border_box()
    )

    math_paragraph.add(math.MathBlock(boxed_equation))

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

## **Terimleri Gruplama**

Bir ifade üzerine veya altına bir grup karakteri yerleştirmek için [`group`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/group/) kullanın. Gruplanan terimleri etiketlemek için bir limit ekleyin.

![x + y ifadesi, altına “any text” etiketiyle gruplandı](powerpoint-math-equations_15.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    grouped = (
        math.MathematicalText("x + y")
        .group(chr(0x23DF), math.MathTopBotPositions.BOTTOM, math.MathTopBotPositions.TOP)
        .set_lower_limit("any text")
    )

    math_paragraph.add(math.MathBlock(grouped))

    presentation.save("grouped-terms.pptx", slides.export.SaveFormat.PPTX)
```

## **Matematik Öğelerini Biçimlendirme**

Yalnızca formülü netleştiren yerlerde biçimlendirme yardımcılarını kullanın. Örneğin, [`overbar`](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/overbar/) bir matematik öğesinin üzerine çubuk ekler.

![Üzerinde üst çizgi olan ABC matematik ifadesi](powerpoint-math-equations_14.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    overbar = math.MathematicalText("ABC").overbar()

    math_paragraph.add(math.MathBlock(overbar))

    presentation.save("overbar.pptx", slides.export.SaveFormat.PPTX)
```

## **Hızlı Referans**

| Görev | Ana API |
| --- | --- |
| Matematik metni oluşturma | [MathematicalText](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Öğeleri birleştirme | [IMathElement.join](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/join/) |
| Kesir oluşturma | [IMathElement.divide](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Üst simge veya alt simge ekleme | [set_superscript](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Fonksiyon ekleme | [function](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Kök ekleme | [radical](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Limit ekleme | [set_lower_limit](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Sol taraflı alt/üst simgeler ekleme | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Toplam ve integral ekleme | [nary](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Matris ekleme | [MathMatrix](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathmatrix/) |
| Denklem dizileri ekleme | [to_math_array](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Ayraç ekleme | [enclose](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Çizgi ve kenarlık ekleme | [overbar](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Terimleri gruplama | [group](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/imathelement/group/) |

## **SSS**

**Mevcut bir PowerPoint denklemini düzenleyebilir miyim?**

Evet. Sunumu açın, `MathPortion` içeren şekli bulun, `MathParagraph`ını alın ve o paragraftaki matematik bloklarını güncelleyin.

**Denklikler düzenlenebilir PowerPoint matematiği olarak kaydediliyor mu?**

Evet. PPTX olarak kaydettiğinizde Aspose.Slides denklemi düzenlenebilir Office matematik içeriği olarak yazar.

**Denklikleri LaTeX'e dışa aktarabilir miyim?**

Evet. Denklemin [MathParagraph](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathparagraph/) nesnesini [MathPortion](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathportion/) üzerinden alın ve doğrudan dışa aktarmak için [MathParagraph.to_latex](https://reference.aspose.com/slides/tr/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) metodunu çağırın. Tam bir örnek için, [Export Math Equations from Presentations in Python via .NET](/slides/tr/python-net/exporting-math-equations/#export-math-equations-to-latex) bölümüne bakın.