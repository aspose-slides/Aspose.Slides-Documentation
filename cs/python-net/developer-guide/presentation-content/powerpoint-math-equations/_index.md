---
title: Přidání matematických rovnic do prezentací PowerPoint v Pythonu
linktitle: Matematické rovnice PowerPoint
type: docs
weight: 80
url: /cs/python-net/powerpoint-math-equations/
keywords:
- matematická rovnice
- matematický symbol
- matematický vzorec
- matematický text
- přidat matematickou rovnici
- přidat matematický symbol
- přidat matematický vzorec
- přidat matematický text
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vkládejte a upravujte matematické rovnice v PowerPoint PPT a PPTX pomocí Aspose.Slides pro Python přes .NET, s podporou OMML, formátovacích kontrol a přehlednými ukázkami kódu v Pythonu."
---
## **Přehled**

PowerPoint ukládá rovnice jako Office Math Markup Language (OMML). S Aspose.Slides pro Python přes .NET můžete programově vytvářet stejný typ matematického obsahu: zlomky, odmocniny, funkce, limity, N‑ary operátory, matice, pole a formátované matematické bloky.

V PowerPointu uživatelé obvykle přidávají rovnice pomocí **Insert > Equation**:

![Panel Insert v PowerPointu s vybraným příkazem Equation](powerpoint-math-equations_1.png)

Výsledkem je editovatelný matematický text na snímku:

![Snímek PowerPointu obsahující editovatelnou matematickou rovnici](powerpoint-math-equations_2.png)

Aspose.Slides vytváří tento matematický text pomocí tří hlavních objektů:

- Matematický tvar, vytvořený pomocí [add_math_shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_math_shape/), je tvar, který obsahuje rovnici.
- [MathPortion](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathportion/) ukládá matematický obsah uvnitř textového rámce tvaru.
- [MathParagraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathparagraph/) obsahuje jeden nebo více objektů [MathBlock](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathblock/).

Většina příkladů níže používá [MathematicalText](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathematicaltext/) a plynulé metody z [IMathElement](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/) pro stručný a čitelný kód.

Pro scénáře exportu do MathML viz [Export Math Equations from Presentations in Python via .NET](/slides/cs/python-net/exporting-math-equations/).

## **Vytvoření rovnice**

Tento příklad vytvoří matematický tvar a přidá Pythagorovu větu:

![Rovnice c na druhou rovná se a na druhou plus b na druhou](powerpoint-math-equations_3.png)

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
`add_math_shape` vytvoří tvar, který již obsahuje matematický odstavec. Získejte první `MathPortion`, jeho `MathParagraph` a přidejte do něj matematické bloky nebo matematické elementy.
{{% /alert %}}

## **Přidání zlomků**

K vytvoření zlomku použijte [`divide`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/divide/). Můžete zvolit styl zlomku pomocí [MathFractionTypes](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Zkosený matematický zlomek zobrazující jeden děleno x](powerpoint-math-equations_4.png)

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

Pro vyšší zlomek použijte `MathFractionTypes.BAR`:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Přidání odmocnin**

K vytvoření druhé odmocniny, třetí odmocniny nebo jiné odmocniny použijte [`radical`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/radical/). Aktuální prvek se stane základem a argument se stane stupněm.

![Výraz n‑té odmocniny s x pod znakem odmocniny](powerpoint-math-equations_5.png)

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

## **Přidání funkcí a limit**

Použijte [`as_argument_of_function`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) nebo [`function`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/function/) pro funkce jako `sin(x)`, `log(x)` nebo vlastní názvy funkcí. Pro limity vložte `lim` do [MathLimit](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathlimit/) nebo použijte [`set_lower_limit`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![Limit x, když x směřuje k nekonečnu](powerpoint-math-equations_8.png)

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

Pro vlastní název funkce nastavte název funkce jako aktuální prvek:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **Přidání N‑ary operátorů a integrálů**

K součtům, sjednocením, průnikům a dalším velkým operátorům použijte [`nary`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/nary/). K integrálům použijte [`integral`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/integral/). Oba postupy umožňují nastavit dolní a horní limity.

![Součet s dolní a horní limitou](powerpoint-math-equations_7.png)

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

N‑ary operátory jsou určeny pro velké operátory s volitelnými limity. Jednoduché operátory jako `+`, `-` a `=` se obvykle přidávají jako `MathematicalText` a spojují do výrazu.

Pro integrál použijte `integral`:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Přidání matic**

Použijte [MathMatrix](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathmatrix/) pro řádky a sloupce. Matice ve výchozím nastavení neobsahují závorky, takže je obalte, když potřebujete závorky, hranaté závorky nebo složené závorky.

![Matematická matice se dvěma řádky a jednou prázdnou buňkou](powerpoint-math-equations_10.png)

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

## **Přidání polí rovnic**

Použijte [`to_math_array`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/to_math_array/) když potřebujete zarovnané rovnice nebo vertikální zásobník výrazů.

![Vertikální matematické pole s x nad y](powerpoint-math-equations_11.png)

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

## **Přidání trigonometrických funkcí**

Použijte [`as_argument_of_function`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) když je argument aktuální prvek a název funkce je známý.

![Trigonometrická funkce cos aplikovaná na 2x](powerpoint-math-equations_6.png)

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

## **Přidání dolních a horních indexů**

Použijte pomocníky pro dolní a horní indexy pro indexy a mocniny. Když musí být indexy zobrazeny na levé straně základu, použijte [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Velké Y s levým dolním indexem 1 a horním indexem n](powerpoint-math-equations_9.png)

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

## **Přidání oddělovačů**

Použijte [`enclose`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/enclose/) k umístění výrazu uvnitř oddělovačů. Můžete také nastavit oddělovací znak pro výrazy s oddělovači, které obsahují několik elementů.

![Výraz s oddělovači obsahující x, y a z oddělené svislými čarami](powerpoint-math-equations_13.png)

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

## **Přidání rámečkového boxu**

Použijte [`to_border_box`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/to_border_box/) když má být rovnice sama o sobě rámečkována.

![Rovnice v rámečku zobrazující a na druhou rovná se b na druhou plus c na druhou](powerpoint-math-equations_12.png)

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

## **Seskupení termínů**

Použijte [`group`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/group/) k umístění skupinového znaku nad nebo pod výraz. Přidejte limitu pro popisek seskupených termínů.

![Výraz x plus y seskupený s popiskem libovolný text pod ním](powerpoint-math-equations_15.png)

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

## **Formátování matematických elementů**

Používejte pomocníky pro formátování jen tam, kde objasňují vzorec. Například [`overbar`](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/overbar/) umístí čáru nad matematický element.

![Matematický výraz ABC s vodorovnou čarou nad ním](powerpoint-math-equations_14.png)

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

## **Rychlý přehled**

| Úkol | Hlavní API |
| --- | --- |
| Vytvořit matematický text | [MathematicalText](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Kombinovat elementy | [IMathElement.join](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/join/) |
| Vytvořit zlomky | [IMathElement.divide](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Přidat horní nebo dolní index | [set_superscript](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Přidat funkce | [function](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Přidat odmocniny | [radical](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Přidat limity | [set_lower_limit](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Přidat levé indexy | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Přidat součty a integrály | [nary](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Přidat matice | [MathMatrix](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/mathmatrix/) |
| Přidat pole rovnic | [to_math_array](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Přidat oddělovače | [enclose](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Přidat vodorovné čáry a rámy | [overbar](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Seskupit termíny | [group](https://reference.aspose.com/slides/cs/python-net/aspose.slides.mathtext/imathelement/group/) |

## **Často kladené otázky**

**Mohu upravit existující rovnici v PowerPointu?**

Ano. Otevřete prezentaci, najděte tvar, který obsahuje `MathPortion`, získejte jeho `MathParagraph` a aktualizujte matematické bloky v tomto odstavci.

**Ukládají se rovnice jako editovatelná matematika v PowerPointu?**

Ano. Při uložení do PPTX Aspose.Slides zapíše rovnici jako editovatelný Office matematický obsah.

**Mohu exportovat rovnice do LaTeXu?**

Aspose.Slides exportuje matematické rovnice do MathML. Pokud potřebujete LaTeX, nejprve exportujte do MathML a poté převodíte MathML pomocí nástroje, který podporuje váš cílový LaTeX dialekt.