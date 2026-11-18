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
description: "Aspose.Slides for Python via .NET ile PowerPoint PPT ve PPTX dosyalarına matematik denklemleri ekleyin ve düzenleyin, OMML desteği, biçimlendirme kontrolleri ve net Python kod örnekleri sağlar."
---
## **Genel Bakış**

PowerPoint, denklemleri Office Math Markup Language (OMML) olarak depolar. Aspose.Slides for Python via .NET ile aynı türde matematik içeriğini programlı olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N-ary operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint'te kullanıcılar genellikle denklemleri **Insert > Equation** menüsünden ekler:

![PowerPoint Ekle sekmesinde Equation komutu seçili](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir matematik metnidir:

![Düzenlenebilir bir matematik denklemi içeren bir PowerPoint slaytı](powerpoint-math-equations_2.png)

Aspose.Slides bu matematik metnini üç ana nesne aracılığıyla oluşturur:

- Matematik şekli, [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) ile oluşturulan, denklemi içeren şekildir.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) şekil metin çerçevesi içinde matematik içeriğini depolar.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) nesnesi içerir.

Aşağıdaki çoğu örnek, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) ve [MathElementBase](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/) üzerindeki akıcı metodları kullanır.

MathML dışa aktarma senaryoları için, [Export Math Equations from Presentations in Python via .NET](/slides/tr/python-net/exporting-math-equations/) sayfasına bakın.

## **Denklem Oluşturma**

Bu örnek, [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) kullanarak bir matematik şekli oluşturur ve Pisagor teoremini ekler:

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

{{% alert color="info" title="Note" %}}
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) zaten bir matematik paragrafı içeren bir şekil oluşturur. İlk [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) erişin, onun [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) alın ve ona matematik blokları veya matematik öğeleri ekleyin.
{{% /alert %}}

## **Kesir Ekleme**

[divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) kullanarak bir kesir oluşturun. [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) ile bir kesir stili seçebilirsiniz.

![Bir kesir, bir bölü x gösteren eğik bir matematik kesiri](powerpoint-math-equations_4.png)

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

Dikey (yığılmış) bir kesir için, [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) kullanın:

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Kök Ekleme**

[radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) kullanarak karekök, küpkök veya diğer kökleri oluşturabilirsiniz. Mevcut öğe temel olur, argüman ise derece olur.

![Kök işareti altında x bulunan n'inci dereceden kök ifadesi](powerpoint-math-equations_5.png)

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

### **Karekökün Derecesini Gösterme veya Gizleme**

Karekök, açık bir 2 gösterebilir veya geleneksel √x gösterimini kullanabilir. [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) öğesinin [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/hide_degree/) özelliği hangi formun görüneceğini kontrol eder. Her iki form da düzenlenebilir denkleme derece 2 ve radikand x'i korur.

![x'in karekökü, sol tarafta derece 2 görünür, sağ tarafta gizli](square-root-degree.png)

Örnek aynı karekökü iki kez kaydeder. 2, `visible-degree.pptx` dosyasında görünür, `hidden-degree.pptx` dosyasında gizlidir.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    radical = math.MathematicalText("x").radical("2")

    shape = slide.shapes.add_math_shape(20, 20, 200, 100)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.math_paragraph.add(math.MathBlock(radical))

    radical.hide_degree = False
    presentation.save("visible-degree.pptx", slides.export.SaveFormat.PPTX)

    radical.hide_degree = True
    presentation.save("hidden-degree.pptx", slides.export.SaveFormat.PPTX)
```

## **Fonksiyon ve Limit Ekleme**

[as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) veya [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) kullanarak `sin(x)`, `log(x)` gibi fonksiyonlar veya özel fonksiyon adları ekleyebilirsiniz. Limitler için, `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) içine koyun veya [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/) kullanın.

![x'in sonsuza giderken limiti](powerpoint-math-equations_8.png)

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

Özel bir fonksiyon adı için, fonksiyon adını mevcut öğe yapın ve [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) metodunu argümanıyla çağırın:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N-ary Operatör ve İntegral Ekleme**

Toplamalar, birleşimler, kesişimler ve diğer büyük operatörler için [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/) kullanın. İntegraller için [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) kullanın. Her iki yöntem de alt ve üst limitleri ayarlamanıza olanak tanır.

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

N-ary operatörler, isteğe bağlı limitleri olan büyük operatörler içindir. `+`, `-`, `=` gibi basit operatörler genellikle [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) ile eklenir ve ifadeye birleştirilir.

İntegral için, [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) kullanın:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Matris Ekleme**

Satır ve sütunlar için [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) kullanın. Matrisler varsayılan olarak parantez içermez, bu yüzden parantez, köşeli parantez veya süslü parantez gerektiğinde matrisi bu işaretlerle çevreleyin.

![Bir boş hücreli iki satırlı bir matematik matrisi](powerpoint-math-equations_10.png)

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

### **Mevcut Bir Matrisi Düzenleme**

Önceki örnekle kaydedilmiş `matrix.pptx` dosyasındaki katsayı matrisini içeren bir lineer cebir dersi olduğunu varsayalım. Sonraki egzersiz için, ilk denklemi koruyun, ikincisini iki yeni denklemle değiştirin ve değişken setini güncelleyin. Mevcut matrise [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) olarak erişerek hâlâ geçerli olan katsayıları koruyabilirsiniz.

![İlk satırda 1, x ve boş hücre, ikinci satırda x, 2 ve y bulunan orijinal iki satırlı katsayı matrisi](matrix-before-edit.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation("matrix.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    portion = shape.text_frame.paragraphs[0].portions[0]
    matrix = portion.math_paragraph[0][0]

    matrix.insert_row_before(1)
    matrix.insert_row_after(2)
    matrix.delete_row(2)

    matrix.insert_column_before(1)
    matrix.insert_column_after(3)
    matrix.delete_column(3)

    matrix[1, 0] = math.MathematicalText("12")
    matrix[1, 1] = math.MathematicalText("1")
    matrix[2, 2] = math.MathematicalText("10")
    matrix[2, 3] = math.MathematicalText("1")
    for row in range(matrix.row_count):
        for column in range(matrix.column_count):
            if matrix[row, column] is None:
                matrix[row, column] = math.MathematicalText("0")

    matrix.set_column_alignment(0, math.MathHorizontalAlignment.LEFT)
    matrix.set_columns_alignment(1, 3, math.MathHorizontalAlignment.RIGHT)

    presentation.save("updated-matrix.pptx", slides.export.SaveFormat.PPTX)
```

[set_column_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_column_alignment/) ilk sütunu sola hizalar. [set_columns_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_columns_alignment/) ise indeks 1'den başlayarak üç ardışık sütunu sağa hizalar. `updated-matrix.pptx` dosyasında matris üç denklem ve dört değişkene sahiptir. Orijinal ilk satır katsayıları `1` ve `x` şimdi birinci ve üçüncü sütunlarda görünür.

![Güncellenmiş üç satırlı matris, satırları 1, 0, x, 0; 12, 1, 0, 0; ve 0, 0, 10, 1 gösterir](matrix-after-edit.png)

## **Denklem Dizileri Ekleme**

[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) kullanarak hizalanmış denklemler veya dikey ifadeler yığını oluşturabilirsiniz.

![x'in y üzerindeki dikey matematik dizisi](powerpoint-math-equations_11.png)

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

### **Diziyi Çevreleyen Öğelerle Hizalama**

[MathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/base_justification/) bir dizinin yanındaki matematik öğelerine göre dikey hizalamasını kontrol eder. Aşağıdaki örnek, hizalamayı ilk satır, dizi merkezi ve son satır ile karşılaştırır.

Aşağıdaki örnek, her biri üç satır ve komşu öğeler `A=` ve `=B` içeren üç aynı diziyi oluşturur. Tüm matematik metni Cambria Math 24 punto kullanır. Sadece dizi hizalaması değişir.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(780, 200, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    alignments = [math.MathVerticalAlignment.TOP, math.MathVerticalAlignment.CENTER, math.MathVerticalAlignment.BOTTOM]
    labels = ["Top", "Center", "Bottom"]

    for i, alignment in enumerate(alignments):
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20 + i * 260, 10, 240, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = labels[i]
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 16
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        math_shape = slide.shapes.add_math_shape(20 + i * 260, 60, 240, 130)
        math_shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = alignment
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", slides.export.SaveFormat.PPTX)
```

İşte PowerPoint'te kaydedilen sunumun karşılaştırması. `A=` ve `=B` öğelerinin her dizi yanındaki konumuna dikkat edin.

![PowerPoint'te Üst, Orta ve Alt hizalama ve aynı komşu öğelerle denklemler dizileri](equation-array-alignment.png)

### **Satır Boşluğunu Yapılandırma**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing_rule/) dizi içindeki satırların boşluk kuralını seçer. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing/) belirli bir boşluk kuralı için sayısal bir değer sağlar ve ön tanımlı kurallar tarafından yoksayılır.

Kesin boşluk için değer puan cinsinden ölçülür. Orantısal boşluk için yarım satır cinsinden ölçülür: örnekte `3` değeri 1,5 satır anlamına gelir. Belirli bir değer belirtirken her iki özelliği de ayarlayın; sadece sayısal değeri değiştirmek boşluk kuralını seçmez.

Aşağıdaki örnek aynı denklemler, hizalama ve yazı tipi ayarlarıyla beş sunum kaydeder. İlk üç ön ayarları kullanır; son iki belirli değerleri gösterir.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


settings = [
    (math.MathRowSpacingRule.SINGLE_LINE_GAP, 0),
    (math.MathRowSpacingRule.ONE_AND_A_HALF_LINE_GAP, 0),
    (math.MathRowSpacingRule.TWO_LINE_GAP, 0),
    (math.MathRowSpacingRule.EXACTLY, 20),
    (math.MathRowSpacingRule.MULTIPLE, 3)
]

for rule, spacing in settings:
    file_name = f"equation-array-{rule.name}.pptx"
    with slides.Presentation() as presentation:
        math_shape = presentation.slides[0].shapes.add_math_shape(20, 20, 600, 300)
        paragraph = math_shape.text_frame.paragraphs[0]
        paragraph.paragraph_format.space_before = 0
        paragraph.paragraph_format.space_after = 0
        math_paragraph = paragraph.portions[0].math_paragraph
        math_paragraph.justification = math.MathJustification.LEFT_JUSTIFIED

        rows = [create_text("x+y=3"), create_text("x-y=1"), create_text("x=2")]
        equation_array = math.MathArray(rows)
        equation_array.base_justification = math.MathVerticalAlignment.CENTER
        equation_array.row_spacing_rule = rule
        equation_array.row_spacing = spacing
        left_text = create_text("A=")
        right_text = create_text("=B")
        equation = math.MathBlock(left_text).join(equation_array).join(right_text)
        math_paragraph.add(equation)

        presentation.save(file_name, slides.export.SaveFormat.PPTX)
```

Dizi satır boşluğu, paragraf boşluğundan ayrıdır. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) ve [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/) dizi satırları arasında değil, içerik paragrafının etrafına boşluk ekler. Benzer şekilde, [MathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/justification/) tüm matematik paragrafını yatay olarak konumlandırır; dizi dikey hizalama ayarını değiştirmez.

## **Trigonometrik Fonksiyonlar Ekleme**

Argüman mevcut öğe ve fonksiyon adı bilindiğinde, [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) kullanın.

![2x'e uygulanmış cos trigonometrik fonksiyonu](powerpoint-math-equations_6.png)

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

## **Alt ve Üst İndeksler Ekleme**

İndeksler ve üsler için alt ve üst indeks yardımcılarını kullanın. İndekslerin temelin sol tarafında görünmesi gerektiğinde, [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) kullanın.

![Sol taraflı alt indeks 1 ve üst indeks n ile büyük Y](powerpoint-math-equations_9.png)

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

## **Sınırlayıcılar Ekleme**

[enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) bir ifadeyi sınırlayıcıların içine koymak için kullanılır. Birden fazla öğe içeren sınırlayıcı ifadeler için ayırıcı karakter de ayarlanabilir.

![x, y ve z'yi dikey çubuklarla ayıran bir sınırlayıcı ifade](powerpoint-math-equations_13.png)

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

### **Sınırlayıcıların Boyutu ve Hizalaması**

[grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/grow_to_match_operand_height/) parantezlerin yüksek bir işleme göre büyümesi için `True`, normal boyutta kalması için `False` olarak ayarlanır. [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/delimiter_shape/) iki [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) değerinden birini alır. `CENTERED`, parantezleri eşit işaretinin ortasından geçen matematik eksenine ortalar. `MATCH`, onları çevrelenen içerikle hizalar. Her iki ayar sadece sınırlayıcıları etkiler. İçerideki ifade aynı kalır.

Örnek, `x` üssüne bir kesir yerleştirir, böylece ifade temel çizginin üzerinde daha fazla uzanır. Dört denklem de aynı parantez ve yazı tipi ayarlarını kullanır.

```python
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_expression(slide, left, top, grow, shape):
    fraction = math.MathematicalText("a + b").divide("c + d")
    power = math.MathematicalText("x").set_superscript(fraction)
    delimiter = power.enclose("(", ")")
    delimiter.grow_to_match_operand_height = grow
    delimiter.delimiter_shape = shape

    math_shape = slide.shapes.add_math_shape(left, top, 300, 100)
    portion = math_shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 32
    equation = math.MathematicalText("y = ").join(delimiter)
    portion.math_paragraph.add(equation)


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    add_expression(slide, 20, 20, True, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 20, True, math.MathDelimiterShape.MATCH)
    add_expression(slide, 20, 140, False, math.MathDelimiterShape.CENTERED)
    add_expression(slide, 350, 140, False, math.MathDelimiterShape.MATCH)

    presentation.save("delimiter-sizing.pptx", slides.export.SaveFormat.PPTX)
```

PowerPoint'te, satırları karşılaştırarak büyüme etkisini görün. Üst satırda, parantezler üssü kapsayacak şekilde büyür ve iki şekil de benzer görünür. Alt satırda büyüme kapalıdır. Sol taraftaki daha küçük parantez (`CENTERED`) eşit işaretiyle hizalanırken, sağ taraftaki (`MATCH`) ifade etrafında daha yüksek durur.

![PowerPoint'te alt sınırlayıcı büyümesi açık ve kapalı dört denklem, sol tarafta Centered, sağ tarafta Match](delimiter-sizing.png)

## **Kenarlıklı Kutu Ekleme**

Bir kesir üzerinde [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) çağırarak tüm ifadeyi çerçeveleyin. Dönen [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) varsayılan olarak dört yanını gösterir. Tek tek kenarları kaldırmak için [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_left/), ve [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_right/) kullanın.

Örnek, aynı kesirin altı kopyasını bir slayta yerleştirir. İptali göstermek için, tüm dört kenarı gizleyin ve yükselen diyagonal (↗) için [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_bottom_left_to_top_right/) ayarlayın, düşen diyagonal (↘) için [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_top_left_to_bottom_right/) ayarlayın. Ayrıca, görünür kenarların herhangi bir kombinasyonuyla [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_horizontal/) veya [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_vertical/) da kullanılabilir.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def add_fraction(slide, x, y, hide_border=False):
    fraction = math.MathematicalText("x+1").divide("y+2")
    box = fraction.to_border_box()
    box.hide_top = box.hide_bottom = box.hide_left = box.hide_right = hide_border

    shape = slide.shapes.add_math_shape(x, y, 160, 90)
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.portion_format.font_height = 28
    portion.math_paragraph.add(math.MathBlock(box))
    return box


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(540, 220, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    add_fraction(slide, 10, 10)

    partial = add_fraction(slide, 190, 10)
    partial.hide_top = True
    partial.hide_right = True

    add_fraction(slide, 370, 10, hide_border=True).strikethrough_bottom_left_to_top_right = True
    add_fraction(slide, 10, 120, hide_border=True).strikethrough_top_left_to_bottom_right = True
    add_fraction(slide, 190, 120, hide_border=True).strikethrough_horizontal = True
    add_fraction(slide, 370, 120).strikethrough_vertical = True

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

![PowerPoint'te düzenlenebilir altı kesir. Üst satır: tam kenarlık, alt ve sol kenarlar, yükselen diyagonal. Alt satır: düşen diyagonal, yatay kesik, tam kenarlı dikey kesik](border-box-fractions.png)

Bu kesirde, yatay kesik kesir çubuğu ile çakışır. Dikey kesik hem payı hem de paydayı keserken çevre kenarlık görünür kalır. Bu çizgiler tüm ifadeyi süsler. Normal metin üzeri çizgisi bir metin çalışmasındaki karakterlere uygulanır. PowerPoint'te sunumu yeniden açtığınızda, pay ve payda hâlâ bağımsız olarak düzenlenebilir.

## **Phantom Öğelerle Görünürlük ve Düzeni Kontrol Etme**

[MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/) ile bir ifadeyi sararak görünürlüğünü ve denkleme katkıda bulunduğu alanı bağımsız olarak kontrol edebilirsiniz. Özellikleri şunları kontrol eder:

| Özellik | Etkisi |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) | İfadeyi gizlemek için `False` olarak ayarlayın. Aşağıdaki ilgili özellikler `True` olduğunda, boyutları hâlâ yerleşime katkıda bulunur. |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_width/) | İfadenin yatay genişliğini sıfır olarak kabul eder, komşu öğelerin birbirine daha yakın hareket etmesini sağlar. |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_asc/) | İfadenin yükselişini (baseline üstündeki yüksekliği) sıfır olarak kabul eder. Bu, komşu öğelerin üzerindeki ayrılan alanı azaltabilir. |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_desc/) | İfadenin alçalmasını (baseline altındaki derinliği) sıfır olarak kabul eder. Bu, kesir çubuğunu veya ifadenin altındaki diğer içeriği komşulara daha yakın konuma getirebilir. |

Baseline, normal matematiksel harflerin oturduğu referans çizgidir. İçeriği gizlemek boyutlarını kaldırmaz ve bir boyutu sıfır olarak kabul etmek ifadeyi silmez. Altındaki ifade [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/base/) aracılığıyla hâlâ kullanılabilir. [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) değerini tekrar `True` yaparak ifadeyi yeniden gösterin; boyut ayarları değişmeden kalır.

Aşağıdaki örnek, yan yana beş varyant oluşturur: görünür bir kesir, alan ayıran gizli bir kesir ve bir boyutu sıfır olarak kabul edilen üç gizli kesir. Her varyant aynı çevre ifadeyi ve Cambria Math 24 puntoyu kullanır. Tüm denklem şekilleri aynı üst konuma sahiptir, gri kılavuzla işaretlenmiştir. Phantom öğesini dış kesirin payına yerleştirmek dikey düzen değişikliklerini daha net görmeyi sağlar.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def create_text(value):
    text = math.MathematicalText(value)
    text.format.font_height = 24
    text.format.latin_font = slides.FontData("Cambria Math")
    return text


with slides.Presentation() as presentation:
    presentation.slide_size.set_size(1000, 180, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]
    labels = ["Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc"]

    guide = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 10, 60, 980, 0)
    guide.line_format.fill_format.fill_type = slides.FillType.SOLID
    guide.line_format.fill_format.solid_fill_color.color = slides.Color.light_gray

    for i, label_text in enumerate(labels):
        left = 10 + i * 200
        label = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, left, 10, 190, 30)
        label.fill_format.fill_type = slides.FillType.NO_FILL
        label.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        label.text_frame.text = label_text
        label_format = label.text_frame.paragraphs[0].portions[0].portion_format
        label_format.font_height = 14
        label_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.fill_format.solid_fill_color.color = slides.Color.black

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = math.MathFraction(fraction_numerator, fraction_denominator)
        phantom = math.MathPhantom(fraction)
        phantom.show = i == 0
        phantom.zero_width = i == 2
        phantom.zero_asc = i == 3
        phantom.zero_desc = i == 4

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = math.MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = math.MathFraction(numerator, denominator)

        shape = slide.shapes.add_math_shape(left, 60, 190, 100)
        shape.text_frame.text_frame_format.anchoring_type = slides.TextAnchorType.TOP
        math_paragraph = shape.text_frame.paragraphs[0].portions[0].math_paragraph
        math_paragraph.add(math.MathBlock(equation))

    presentation.save("math-phantom.pptx", slides.export.SaveFormat.PPTX)
```

![PowerPoint'te görünür kesir, alan ayıran gizli kesir ve ZeroWidth, ZeroAsc veya ZeroDesc etkin olan gizli kesirleri karşılaştıran beş denklem](math-phantom.png)

## **Terimleri Gruplama**

[group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) bir ifadeye grup karakterini üstüne veya altına yerleştirmek için kullanın. Gruplanmış terimleri etiketlemek için bir limit ekleyin.

![x + y ifadesi, altında herhangi bir metin etiketiyle gruplanmış](powerpoint-math-equations_15.png)

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

Biçimlendirme yardımcılarını yalnızca formülü netleştirdiği yerlerde kullanın. Örneğin, [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/), bir matematik öğesinin üzerine bir çubuk koyar.

![Üstü çizili ABC matematik ifadesi](powerpoint-math-equations_14.png)

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

### **Mevcut Bir Denklemde Metni Biçimlendirme**

Mevcut bir denklemin tüm metnini biçimlendirmek için her matematik bloğunun eleman ağacını dolaşın. [MathElementBase.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/get_children/) yalnızca doğrudan çocukları döndürür; bu yüzden kesir, üst/alt indeks, kök ve diğer iç içe yapılar içindeki metne ulaşmak için yinelemeli olarak çağırın. Başlangıç öğesi [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) olduğunda, mevcut öğeyi ve çocuklarını da kontrol edin.

Bu örnek, `input.pptx` dosyasının `z = xᵢ / ∛y` gibi bir denklem içerdiğini varsayar; bu denklem, payda kısmında alt indeks, pay kısmında kök içeren bir kesir içerir. Sadece bloğun üst düzey öğelerini işlemek, kesir içindeki metni kaçırır. Örnek, slayt metin çerçevelerindeki matematik bölümlerini bulur, bloklarına [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) üzerinden erişir ve her metin öğesinin [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) özelliği ile [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) değerini 28 puana ayarlar.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math


def format_math_text(element):
    if isinstance(element, math.MathematicalText):
        element.format.font_height = 28

    for child in element.get_children():
        format_math_text(child)


with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    if isinstance(portion, math.MathPortion):
                        for block in portion.math_paragraph:
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", slides.export.SaveFormat.PPTX)
```

Kaydedilen sunum, işlenen her denklemin her seviyesindeki güncellenmiş metin biçimlendirmesini, metin içeriğini ve matematik yapısını koruyarak içerir.

## **Hızlı Referans**

| Görev | Ana API |
| --- | --- |
| Matematik metni oluşturma | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Öğeleri birleştirme | [MathElementBase.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/join/) |
| Kesir oluşturma | [MathElementBase.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) |
| Üst veya alt indis ekleme | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_subscript/) |
| Fonksiyon ekleme | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) |
| Kök ekleme | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) |
| Limit ekleme | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_upper_limit/) |
| Sol taraflı script ekleme | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) |
| Toplam ve integral ekleme | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) |
| Matris ekleme | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Denklem dizileri ekleme | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) |
| Sınırlayıcı ekleme | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) |
| Çubuk ve kenarlık ekleme | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) |
| Terimleri gruplama | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) |

## **FAQ**

**Mevcut bir PowerPoint denklemine düzenleme yapabilir miyim?**

Evet. Sunumu açın, içinde bir [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) bulunan şekli bulun, onun [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) alın ve o paragraftaki matematik bloklarını güncelleyin.

**Denklikler düzenlenebilir PowerPoint matematiği olarak kaydediliyor mu?**

Evet. PPTX olarak kaydettiğinizde, Aspose.Slides denklemi düzenlenebilir Office matematik içeriği olarak yazar.

**Denklikleri LaTeX'e dışa aktarabilir miyim?**

Evet. Denklemin [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) üzerinden alın ve doğrudan dışa aktarmak için [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) çağırın. Tam bir örnek için, [Export Math Equations from Presentations in Python via .NET](/slides/tr/python-net/exporting-math-equations/#export-math-equations-to-latex) sayfasına bakın.