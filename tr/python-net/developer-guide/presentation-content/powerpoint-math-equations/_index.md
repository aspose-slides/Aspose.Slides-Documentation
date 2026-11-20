---
title: Python'da PowerPoint Sunumlarına Matematik Denklemleri Ekle
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
description: "Aspose.Slides for Python via .NET ile PowerPoint PPT ve PPTX dosyalarına matematik denklemleri ekleyin ve düzenleyin; OMML desteği, biçimlendirme kontrolleri ve net Python kod örnekleri sunar."
---
## **Genel Bakış**

PowerPoint, denklemleri Office Math Markup Language (OMML) olarak saklar. .NET üzerinden Python için Aspose.Slides ile aynı tür matematik içeriğini programatik olarak oluşturabilirsiniz: kesirler, kökler, fonksiyonlar, limitler, N-ary operatörler, matrisler, diziler ve biçimlendirilmiş matematik blokları.

PowerPoint, kullanıcılar genellikle denklemleri **Ekle > Denklem** yoluyla ekler:

![PowerPoint Ekle sekmesi, Denklem komutu seçili](powerpoint-math-equations_1.png)

Sonuç, slaytta düzenlenebilir matematik metni olur:

![Düzenlenebilir bir matematik denklemi içeren bir PowerPoint slaytı](powerpoint-math-equations_2.png)

Aspose.Slides, bu matematik metnini üç ana nesne aracılığıyla oluşturur:

- Bir matematik şekli, [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) ile oluşturulan, denklemi içeren şekildir.
- [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) şekil metin çerçevesi içinde matematik içeriğini depolar.
- [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) bir veya daha fazla [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) nesnesi içerir.

Aşağıdaki çoğu örnek, kodu kısa ve okunabilir tutmak için [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) ve [MathElementBase](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/) üzerinden akıcı metodları kullanır.

MathML dışa aktarma senaryoları için, [Export Math Equations from Presentations in Python via .NET](/slides/tr/python-net/exporting-math-equations/) sayfasına bakın.

## **Bir Denklem Oluşturun**

Bu örnek, bir matematik şekli oluşturmak için [add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) kullanır ve Pisagor teoremini ekler:

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

{{% alert color="info" title="Not" %}}
[add_math_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/) zaten bir math paragrafı içeren bir şekil oluşturur. İlk [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) erişin, onun [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) alın ve ona math blokları ya da math öğeleri ekleyin.
{{% /alert %}}

### **Math Bloklarını Birleştirin**

Bir denklemin bölümleri bağımsız olarak [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) nesneleri olarak oluşturulduğunda, bunları birleştirmek için [join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) kullanın. Örnek, sol blokta `c² =` ve sağ blokta `a² + b²` oluşturur. [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/) üç üssün hepsi için düzenlenebilir matematik üst simgeleri oluşturur.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_math_shape(20, 20, 600, 100)
    math_paragraph = shape.text_frame.paragraphs[0].portions[0].math_paragraph

    left_block = math.MathBlock()
    left_block.add(math.MathematicalText("c").set_superscript("2"))
    left_block.add(math.MathematicalText("="))

    right_block = math.MathBlock()
    right_block.add(math.MathematicalText("a").set_superscript("2"))
    right_block.add(math.MathematicalText("+"))
    right_block.add(math.MathematicalText("b").set_superscript("2"))

    combined_block = left_block.join_block(right_block)
    math_paragraph.add(combined_block)

    presentation.save("equation.pptx", slides.export.SaveFormat.PPTX)
```

[join_block](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/join_block/) `left_block` nesnesini kendisi olarak döndürür, artık iki bölümü sırayla içerir ve `right_block` boş bırakır. Birleştirilmiş bloğu sadece bir kez [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) içine ekleyin. `equation.pptx` yeniden açıldıktan sonra paragraf, `c² = a² + b²` ifadesini temsil eden tek bir blok içerir ve üç üssü de matematiksel üst simge olarak korunur.

`left_block.add(right_block)` şeklinde [add](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/add/) çağırmak, bir bloğu doğrudan diğerinin içine yerleştirmeye çalışır ve .NET `InvalidOperationException` saran bir `RuntimeError` ortaya çıkar.

## **Kesir Ekle**

[divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) kullanarak bir kesir oluşturun. Kesir stilini [MathFractionTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) ile seçebilirsiniz.

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

Yığılmış bir kesir için [MathFractionTypes.BAR](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfractiontypes/) kullanın:

```py
import aspose.slides.mathtext as math

stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Kökler Ekle**

[radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) kullanarak karekök, küpkök veya diğer kökleri oluşturun. Mevcut öğe taban olur, argüman ise derecesi olur.

![x kök işareti altında bulunan n'inci dereceli bir kök ifadesi](powerpoint-math-equations_5.png)

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

### **Karekökün Derecesini Göster veya Gizle**

Karekök açık bir 2 gösterebilir ya da geleneksel √x gösterimini kullanabilir. [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/)’ın [hide_degree](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/hide_degree/) özelliği hangi şeklin görüneceğini kontrol eder. Her iki form da düzenlenebilir denklemde derece 2 ve radikand x'i korur.

![x'in karekökü, solda derecesi 2 görünür, sağda gizli](square-root-degree.png)

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

## **Fonksiyonlar ve Limitler Ekle**

[as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) veya [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) kullanarak `sin(x)`, `log(x)` veya özel fonksiyon adları gibi fonksiyonlar ekleyin. Limitler için `lim` ifadesini bir [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) içine koyun veya [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/) kullanın.

![x'in x sonsuza giderken limiti](powerpoint-math-equations_8.png)

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

Özel bir fonksiyon adı için, fonksiyon adını mevcut öğe yapın ve argümanıyla birlikte [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/) çağırın:

```py
import aspose.slides.mathtext as math

custom_function = math.MathematicalText("f").function("x + 1")
```

## **N-ary Operatörler ve İntegraller Ekle**

Toplamalar, birleşimler, kesişimler ve diğer büyük operatörler için [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/) kullanın. İntegraller için [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) kullanın. Her iki yöntem de alt ve üst limitleri ayarlamanıza izin verir.

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

N-ary operatörler, isteğe bağlı limitleri olan büyük operatörler içindir. `+`, `-`, `=` gibi basit operatörler genellikle [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) olarak eklenir ve ifadeye birleştirilir.

İntegral için [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) kullanın:

```py
import aspose.slides.mathtext as math

integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Matrisler Ekle**

Satırlar ve sütunlar için [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) kullanın. Matrisler varsayılan olarak parantez içermez, bu yüzden parantez, köşeli parantez veya süslü parantez gerektiğinde matrisi dışa alın.

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

### **Var Olan Bir Matrisi Düzenle**

Lineer cebir dersi, önceki örnek tarafından kaydedilen `matrix.pptx` içindeki katsayı matrisiyle başlar. Sonraki alıştırmada, ilk denklemi tutun, ikincisini iki yeni denklemle değiştirin ve değişken setini revize edin. Hâlâ geçerli katsayıları korumak için mevcut matrise bir [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) olarak erişin.

![Orijinal iki satırlı katsayı matrisi, birinci satırda 1, x ve bir boş hücre, ikinci satırda x, 2 ve y içerir](matrix-before-edit.png)

Satır ve sütun indeksleri sıfırdan başlar ve her çağrıda mevcut matris durumuna başvurur. 1. indeks öncesinde bir satır eklemek, orijinal ikinci satırı 2. indekse taşır. 2. indeks sonrasında eklemek bir satır ekler. Satır 2’yi silmek orijinal ikinci denklemi kaldırır ve eklenen satırı bir üst konuma kaydırır. Sütunlar da aynı şekilde kayar.

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

[set_column_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_column_alignment/) ilk sütunu sola hizalar. [set_columns_alignment](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/set_columns_alignment/) birden fazla sütunu aynı anda hizalar; örnekte 1. indeksten başlayarak üç ardışık sütunu sağa hizalar. `updated-matrix.pptx` içinde matris üç denklem ve dört değişken içerir. Orijinal birinci satır katsayıları `1` ve `x` şimdi birinci ve üçüncü sütunlarda görünür.

![Güncellenmiş üç satırlı matris, satırları 1, 0, x, 0; 12, 1, 0, 0; ve 0, 0, 10, 1 gösterir](matrix-after-edit.png)

## **Denklem Dizileri Ekle**

Hizalanmış denklemlere ya da dikey bir ifade yığınına ihtiyaç duyduğunuzda [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) kullanın.

![x'in y'nin üstünde olduğu dikey bir matematik dizisi](powerpoint-math-equations_11.png)

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

### **Bir Diziyi Çevresindeki Öğelerle Hizalayın**

[MathArray.base_justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/base_justification/) bir dizinin, yanındaki matematik öğelerine göre dikey hizalamasını kontrol eder. Aşağıdaki örnek, birinci satır, dizinin ortası ve son satır hizalamasını karşılaştırır.

Aşağıdaki örnek, her biri üç satır ve komşu öğeleri `A=` ve `=B` olan üç aynı diziyi oluşturur. Tüm matematik metni Cambria Math 24 punto ile yazılmıştır. Sadece dizi hizalaması değişir.

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

Aşağıdaki karşılaştırma, kaydedilmiş sunumu PowerPoint’te gösterir. `A=` ve `=B` öğelerinin her dizi yanında konumuna dikkat edin.

![PowerPoint'te Üst, Orta ve Alt hizalama ve aynı komşu öğelerle denklemler dizileri](equation-array-alignment.png)

### **Satır Aralığını Yapılandır**

[row_spacing_rule](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing_rule/) bir dizideki satırlar için aralık kuralını seçer. [row_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/row_spacing/) açık bir aralık kuralı için sayısal bir değer sağlar ve ön tanımlı kurallar tarafından yok sayılır.

Kesin aralık için değer punto olarak ölçülür. Orantısal aralık için değer yarım satırda ölçülür: örnekteki `3` değeri 1,5 satır anlamına gelir. Açık bir değer belirtirken her iki özelliği de ayarlayın; sadece sayısal değeri değiştirmek bir aralık kuralı seçmez.

Aşağıdaki örnek aynı denklemler, hizalama ve yazı tipi ayarlarıyla beş sunum kaydeder. İlk üçü ön ayarları, son ikisi açık değerleri gösterir.

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

Dizi satır aralığı, paragraf aralığından ayrıktır. [space_before](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_before/) ve [space_after](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/space_after/) içeren paragrafta boşluk ekler, dizi satırları arasında değil. Benzer şekilde, [MathParagraph.justification](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/justification/) bütün matematik paragrafını yatay konumlandırır; dizi dikey hizalama ayarını değiştirmez.

## **Trigonometrik Fonksiyonlar Ekle**

Argüman mevcut öğe olduğunda ve fonksiyon adı bilindiğinde, [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) kullanın.

![2x'e uygulanan trigonometrik fonksiyon cos](powerpoint-math-equations_6.png)

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

## **Alt ve Üst Simge Ekle**

İndeks ve üsler için alt ve üst simge yardımcılarını kullanın. İndeksler tabanın sol tarafında görünmeliyse, [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) kullanın.

![Sol taraflı alt simge 1 ve üst simge n içeren büyük harf Y](powerpoint-math-equations_9.png)

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

### **Sağ Alt ve Üst Simgeyi Hizala**

Aynı tabana ait iki simgeyi yan yana kullanırken, [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/) kullanın. Özelliği [align_scripts](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/align_scripts/) simgelerin yatay konumlarını denetler: `False` (öntanımlı) onları taban konturuna göre yerleştirirken, `True` simgeleri yatay olarak hizalar.

Bu örnek aynı düzenlenebilir ifadeyi iki kopya yan yana koyar. Her ikisi de matematik eğik f (U+1D453), alt simge 1, üst simge 2 ve Cambria Math 72 punto kullanır. Eğimli taban farkı PowerPoint’te görünür kılar. Örneği çalıştırmadan önce Cambria Math’ı kurun.

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(900, 250, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    text_format = slides.PortionFormat()
    text_format.font_height = 72
    text_format.latin_font = slides.FontData("Cambria Math")

    for i in range(2):
        left = 40 + i * 440
        shape = slide.shapes.add_math_shape(left, 75, 380, 150)

        base_text = math.MathematicalText("\U0001D453", text_format)
        subscript = math.MathematicalText("1", text_format)
        superscript = math.MathematicalText("2", text_format)
        scripts = math.MathRightSubSuperscriptElement(base_text, subscript, superscript)
        scripts.align_scripts = i == 1

        portion = shape.text_frame.paragraphs[0].portions[0]
        portion.portion_format.font_height = text_format.font_height
        portion.portion_format.latin_font = text_format.latin_font
        portion.math_paragraph.add(math.MathBlock(scripts))

    presentation.save("aligned-scripts.pptx", slides.export.SaveFormat.PPTX)
```

![PowerPoint'te sol tarafta align_scripts False, sağ tarafta True ayarlı iki düzenlenebilir ifade](aligned-scripts.png)

Sol tarafta alt simge, üst simgeden daha sola başlar ve taban konturunu takip eder. Sağ tarafta iki simge yatay olarak hizalanır.

## **Sınırlayıcılar Ekle**

Bir ifadeyi sınırlayıcıların içine koymak için [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) kullanın. Birden fazla öğe içeren sınırlayıcı ifadeler için ayırıcı karakter de ayarlayabilirsiniz.

![x, y ve z'yi dikey çubuklarla ayıran bir sınırlayıcı ifadesi](powerpoint-math-equations_13.png)

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

### **Sınırlayıcıları Boyutlandır ve Hizala**

Parantezlerin uzun bir operand etrafında büyümesine izin vermek için `True` yapın, normal boyutta kalmasını isterseniz `False` yapın: [grow_to_match_operand_height](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/grow_to_match_operand_height/). [delimiter_shape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/delimiter_shape/) iki [MathDelimiterShape](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimitershape/) değerinden birini alır. `CENTERED` parantezleri matematik eksenine (eşittir işaretinin ortasından geçen) ortalar. `MATCH` ise içerikle hizalar. Bu ayarlar yalnızca sınırlayıcıları etkiler; içteki ifade aynı kalır.

Örnek, `x`'in üssüne bir kesir koyar, böylece ifade alt çizgiden daha yukarı uzanır. Dört denklem aynı parantez ve yazı tipi ayarlarını kullanır.

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

PowerPoint’te satırları karşılaştırarak büyüme etkisini görün. Üst satırda parantezler üssü kapsayacak şekilde büyür ve iki şekil de benzer görünür. Alt satırda büyüme kapalıdır. Soldaki daha küçük parantez (`CENTERED`) eşittir işaretiyle hizalanırken, sağdaki (`MATCH`) ifade etrafında daha yüksekte durur.

![PowerPoint'te dört denklem, üstte sınırlayıcı büyümesi etkin, aşağıda devre dışı; solda CENTERED, sağda MATCH](delimiter-sizing.png)

## **Kenarlıklı Kutular Ekle**

Bir kesire [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) uygulayarak bütün ifadeyi çerçeveleyin. Dönen [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) varsayılan olarak dört kenarı gösterir. Tek tek kenarları kaldırmak için [hide_top](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_top/), [hide_bottom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_bottom/), [hide_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_left/), [hide_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/hide_right/) kullanın.

Örnek, aynı kesirin altı kopyasını bir slayta koyar. İptal göstermek için bütün kenarları gizler ve yükselen köşegen (↗) için [strikethrough_bottom_left_to_top_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_bottom_left_to_top_right/) veya düşen köşegen (↘) için [strikethrough_top_left_to_bottom_right](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_top_left_to_bottom_right/) ayarlar. Ayrıca herhangi bir kombinasyonda görünür kenarlarla birlikte [strikethrough_horizontal](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_horizontal/) veya [strikethrough_vertical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/strikethrough_vertical/) kullanılabilir.

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

![PowerPoint'te altı düzenlenebilir kesir: Üst satır tam kenar, alt ve sol kenarlar, yükselen köşegen. Alt satır düşen köşegen, yatay çizgi, dikey çizgi ve tam kenar](border-box-fractions.png)

Bu kesirde yatay çizgi kesir çubuğunu üst üste bindirir. Dikey çizgi hem payı hem de paydayı keserken çevre kenar hâlâ görünür. Bu çizgiler bütün ifadeyi süsler. Normal metin üzerindeki üst çizgi karakterleri içinde uygulanır. Sunum PowerPoint’te yeniden açıldığında pay ve payda hâlâ bağımsız olarak düzenlenebilir.

## **Phantom Öğelerle Görünürlük ve Yerleşimi Kontrol Et**

Bir ifadeyi [MathPhantom](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/) içinde sararak görünürlüğünü ve bir denkleme katkı sağladığı alanı bağımsız olarak kontrol edebilirsiniz. Özellikleri şunları denetler:

| Property | Effect |
| --- | --- |
| [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) | `False` olarak ayarlandığında ifadeyi gizler. Alt özellikler `True` yapılmadığı sürece boyutları hâlâ yerleşime katkıda bulunur. |
| [zero_width](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_width/) | İfadenin yatay genişliğini sıfır olarak kabul eder, komşu öğelerin daha yakına gelmesini sağlar. |
| [zero_asc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_asc/) | Üst kenarını (baseline’ın üzerindeki yükseklik) sıfır olarak kabul eder. Bu, komşu öğelerin üzerindeki ayrılan alanı azaltabilir. |
| [zero_desc](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/zero_desc/) | Alt kenarını (baseline’ın altındaki derinlik) sıfır olarak kabul eder. Bu, bir kesir çubuğu ya da ifadeyi altındaki içeriklerin komşulara daha yakın olmasını sağlar. |

Baseline, normal matematik harflerinin oturduğu referans çizgidir. İçeriği gizlemek boyutlarını kaldırmaz; bir boyutu sıfır yapmak ifadeyi silmez. Alttaki [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/base/) üzerinden temel ifade hâlâ erişilebilir. [show](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathphantom/show/) değerini `True` yaparak ifadeyi tekrar gösterebilirsiniz; boyut ayarları değişmeden kalır.

Aşağıdaki örnek, yan yana beş varyant oluşturur: görünür bir kesir, alan ayıran gizli bir kesir ve bir boyutu sıfır olan üç gizli kesir. Her varyant aynı çevre ifadesi ve Cambria Math 24 punto ile aynı konumda, gri kılavuzla işaretlenmiş üst konumda bulunur. Phantom’u dış kesirin payına koymak, dikey yerleşim değişikliklerini görmeyi kolaylaştırır.

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

![PowerPoint'te beş denklem; görünür kesir, alan ayıran gizli kesir ve ZeroWidth, ZeroAsc veya ZeroDesc etkin gizli kesirler](math-phantom.png)

## **Terimleri Gruplandır**

[group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) kullanarak bir ifadeyi üzerine ya da altına bir gruplayıcı karakter yerleştirin. Gruplanan terimleri etiketlemek için bir limit ekleyin.

![x + y ifadesi, altında herhangi bir metin etiketi ile gruplandırılmış](powerpoint-math-equations_15.png)

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

## **Matematik Öğelerini Biçimlendir**

Biçimlendirme yardımcılarını yalnızca formülü netleştirdiği durumlarda kullanın. Örneğin, [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/) bir matematik öğesinin üzerine bir çubuk ekler.

![Üst çizgili ABC matematik ifadesi](powerpoint-math-equations_14.png)

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

### **Mevcut Bir Denklemede Metni Biçimlendir**

Mevcut bir denklemi bütünsel olarak biçimlendirmek için, her math bloğunun öğe ağacını dolaşın. [MathElementBase.get_children](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/get_children/) yalnızca doğrudan çocukları döndürür; bu yüzden kesirler, üst/alt simgeler, kökler ve diğer iç içe yapılar içindeki metne ulaşmak için özyinelemeli olarak çağırın. Başlangıç öğesini de kontrol edin; başlangıç öğesi [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) olduğunda da dahil edin.

Bu örnek, `input.pptx` dosyasının `z = xᵢ / ∛y` gibi bir denklem içerdiğini varsayar; bu denklemde payda içinde bir alt simge ve payda içinde bir kök bulunur. Sadece bloğun üst düzey öğelerini işlemek, kesir içindeki metni atlayacaktır. Örnek, slayt metin çerçevelerindeki matematik bölümlerini bulur, bloklarına [MathPortion.math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) üzerinden erişir ve her metin öğesinin [format](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/format/) özelliği aracılığıyla [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) değerini 28 punto olarak ayarlar.

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

Kaydedilen sunum, işlenen her denklemin her seviyesindeki metin biçimlendirmesini günceller, ancak metin içeriği ve matematik yapısını korur.

## **Hızlı Referans**

| Görev | Ana API |
| --- | --- |
| Create math text | [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Combine elements | [MathElementBase.join](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/join/) |
| Create fractions | [MathElementBase.divide](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/divide/) |
| Add superscript or subscript | [set_superscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_superscript/), [set_subscript](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_subscript/) |
| Add functions | [function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/function/), [as_argument_of_function](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/as_argument_of_function/) |
| Add radicals | [radical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/radical/) |
| Add limits | [set_lower_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_upper_limit/) |
| Add left-side scripts | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/set_sub_superscript_on_the_left/) |
| Add summations and integrals | [nary](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/nary/), [integral](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/integral/) |
| Add matrices | [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) |
| Add equation arrays | [to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_math_array/) |
| Add delimiters | [enclose](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/enclose/) |
| Add bars and borders | [overbar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/overbar/), [to_border_box](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/to_border_box/) |
| Group terms | [group](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathelementbase/group/) |

## **SSS**

**Mevcut bir PowerPoint denklemine düzenleme yapabilir miyim?**

Evet. Sunumu açın, bir [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) içeren şekli bulun, onun [math_paragraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) alın ve o paragraftaki math bloklarını güncelleyin.

**Denklikler düzenlenebilir PowerPoint matematiği olarak kaydedilir mi?**

Evet. PPTX olarak kaydettiğinizde, Aspose.Slides denklemi düzenlenebilir Office math içeriği olarak yazar.

**Denklikleri LaTeX'e dışa aktarabilir miyim?**

Evet. Denklemin [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) nesnesini [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) üzerinden alıp doğrudan [MathParagraph.to_latex](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/to_latex/) ile dışa aktarın. Tam bir örnek için [Export Math Equations from Presentations in Python via .NET](/slides/tr/python-net/exporting-math-equations/#export-math-equations-to-latex) sayfasına bakın.