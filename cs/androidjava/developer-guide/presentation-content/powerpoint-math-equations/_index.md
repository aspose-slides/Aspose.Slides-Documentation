---
title: Přidat matematické rovnice do prezentací PowerPoint na Androidu
linktitle: Matematické rovnice v PowerPointu
type: docs
weight: 80
url: /cs/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "Vkládání a úprava matematických rovnic v PowerPoint PPT a PPTX pomocí Aspose.Slides pro Android, podpora OMML, formátovacích ovládacích prvků a přehledné ukázky kódu v jazyce Java."
---
## **Přehled**

PowerPoint ukládá rovnice ve formátu Office Math Markup Language (OMML). S Aspose.Slides pro Android pomocí Javy můžete programově vytvářet stejný typ matematického obsahu: zlomky, odmocniny, funkce, limity, N-ární operátory, matice, pole a formátované matematické bloky.

V PowerPointu uživatelé běžně vkládají rovnice pomocí **Insert > Equation**:

![Karta Insert v PowerPointu s vybraným příkazem Equation](powerpoint-math-equations_1.png)

Výsledkem je upravitelný matematický text na snímku:

![Snimek PowerPointu obsahující upravitelnou matematickou rovnici](powerpoint-math-equations_2.png)

Aspose.Slides vytváří tento matematický text pomocí tří hlavních objektů:

- Matematický tvar, vytvořený pomocí [addMathShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/), je tvar, který obsahuje rovnici.
- [MathPortion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathportion/) ukládá matematický obsah uvnitř textového rámečku tvaru.
- [MathParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathparagraph/) obsahuje jeden nebo více objektů [MathBlock](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathblock/).

Většina níže uvedených příkladů používá [MathematicalText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathematicaltext/) a plynulé metody z [IMathElement](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/), aby byl kód stručný a čitelný.

Pro scénáře exportu MathML viz [Export rovnic z prezentací na Androidu](/slides/cs/androidjava/exporting-math-equations/).

## **Vytvoření rovnice**

Tento příklad vytvoří matematický tvar a přidá Pythagorovu větu:

![Rovnice c na druhou rovná se a na druhou plus b na druhou](powerpoint-math-equations_3.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock equation = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));

    mathParagraph.add(equation);

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
`addMathShape` vytvoří tvar, který již obsahuje matematický odstavec. Získejte první `MathPortion`, načtěte jeho `MathParagraph` a přidejte do něj matematické bloky nebo matematické elementy.
{{% /alert %}}

## **Přidání zlomků**

Použijte `divide` pro vytvoření zlomku. Můžete zvolit styl zlomku pomocí [MathFractionTypes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathfractiontypes/).

![Zkosený matematický zlomek zobrazující 1 děleno x](powerpoint-math-equations_4.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFraction fraction = new MathematicalText("1")
            .divide("x", MathFractionTypes.Skewed);

    mathParagraph.add(new MathBlock(fraction));

    presentation.save("fraction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro zásobní (složený) zlomek použijte `MathFractionTypes.Bar`:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Přidání odmocnin**

Použijte `radical` pro vytvoření druhé odmocniny, třetí odmocniny nebo jiné odmocniny. Aktuální element se stane základnou a argument se stane stupněm.

![Výraz n-té odmocniny s x pod znakem odmocniny](powerpoint-math-equations_5.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathRadical radical = new MathematicalText("x")
            .radical("n");

    mathParagraph.add(new MathBlock(radical));

    presentation.save("radical.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání funkcí a limit**

Použijte `asArgumentOfFunction` nebo `function` pro funkce jako `sin(x)`, `log(x)` nebo vlastní názvy funkcí. Pro limity vložte `lim` do [MathLimit](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathlimit/) nebo použijte `setLowerLimit`.

![Limit x, když x směřuje k nekonečnu](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x→∞")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro vlastní název funkce nastavte název funkce jako aktuální element:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **Přidání N-árních operátorů a integrálů**

Použijte `nary` pro sumace, sjednocení, průniky a další velké operátory. Použijte `integral` pro integrály. Obě metody umožňují nastavit dolní a horní limity.

![Sumace s dolní a horní hranicí](powerpoint-math-equations_7.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBlock summationBase = new MathematicalText("x")
            .setSuperscript("k")
            .join(new MathematicalText("a").setSuperscript("n-k"));

    IMathNaryOperator summation = summationBase.nary(MathNaryOperatorTypes.Summation, "k=0", "n");

    mathParagraph.add(new MathBlock(summation));

    presentation.save("nary-operators.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

N-ární operátory slouží k velkým operátorům s volitelnými limity. Jednoduché operátory jako `+`, `-` a `=` se obvykle přidávají jako `MathematicalText` a spojují do výrazu.

Pro integrál použijte `integral`:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Přidání matic**

Použijte [MathMatrix](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathmatrix/) pro řádky a sloupce. Matice ve výchozím nastavení neobsahují závorky, takže je potřeba obalit matici, pokud potřebujete kulaté závorky, hranaté závorky nebo složené závorky.

![Matematická matice se dvěma řádky a jednou prázdnou buňkou](powerpoint-math-equations_10.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    MathMatrix matrix = new MathMatrix(2, 3);
    matrix.set_Item(0, 0, new MathematicalText("1"));
    matrix.set_Item(0, 1, new MathematicalText("x"));
    matrix.set_Item(1, 0, new MathematicalText("x"));
    matrix.set_Item(1, 1, new MathematicalText("2"));
    matrix.set_Item(1, 2, new MathematicalText("y"));

    mathParagraph.add(new MathBlock(matrix));

    presentation.save("matrix.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání polí rovnic**

Použijte `toMathArray`, když potřebujete zarovnané rovnice nebo svislý zásobník výrazů.

![Vertikální matematické pole s x nad y](powerpoint-math-equations_11.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 140);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathArray equationArray = new MathematicalText("x")
            .join("y")
            .toMathArray();

    mathParagraph.add(new MathBlock(equationArray));

    presentation.save("equation-array.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání trigonometrických funkcí**

Použijte `asArgumentOfFunction`, když je argumentem aktuální element a název funkce je znám.

![Trigonometrická funkce cos aplikovaná na 2x](powerpoint-math-equations_6.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction cosine = new MathematicalText("2x")
            .asArgumentOfFunction(MathFunctionsOfOneArgument.Cos);

    mathParagraph.add(new MathBlock(cosine));

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání dolních a horních indexů**

Použijte pomocníky pro dolní a horní indexy pro indexy a mocniny. Když musí být indexy na levé straně základny, použijte `setSubSuperscriptOnTheLeft`.

![Velké Y s levým dolním indexem 1 a horním indexem n](powerpoint-math-equations_9.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLeftSubSuperscriptElement scripts = new MathematicalText("Y")
            .setSubSuperscriptOnTheLeft("1", "n");

    mathParagraph.add(new MathBlock(scripts));

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání oddělovačů**

Použijte `enclose` k vložení výrazu do oddělovačů. Můžete také nastavit znak oddělovače pro výrazy s více prvky.

![Výraz s oddělovači obsahující x, y a z oddělené svislými čarami](powerpoint-math-equations_13.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathDelimiter delimiter = new MathematicalText("x")
            .join("y")
            .join("z")
            .enclose('<', '>');
    delimiter.setSeparatorCharacter('|');

    mathParagraph.add(new MathBlock(delimiter));

    presentation.save("delimiters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Přidání rámečkového pole**

Použijte `toBorderBox`, když má být rovnice sama o sobě ohraničená rámečkem.

![Rovnice v rámečku ukazující a na druhou rovná se b na druhou plus c na druhou](powerpoint-math-equations_12.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBorderBox boxedEquation = new MathematicalText("a")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("b").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("c").setSuperscript("2"))
            .toBorderBox();

    mathParagraph.add(new MathBlock(boxedEquation));

    presentation.save("border-box.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Seskupení členů**

Použijte `group` k umístění znaků seskupení nad nebo pod výraz. Přidejte limit pro označení seskupených členů.

![Výraz x plus y seskupený s popiskem libovolný text pod ním](powerpoint-math-equations_15.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 120);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathLimit grouped = new MathematicalText("x + y")
            .group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top)
            .setLowerLimit("any text");

    mathParagraph.add(new MathBlock(grouped));

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Formátování matematických elementů**

Používejte pomocníky formátování pouze tam, kde objasňují vzorec. Například `overbar` umístí čáru nad matematický element.

![Matematický výraz ABC s vodorovnou čarou nad ním](powerpoint-math-equations_14.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathBar overbar = new MathematicalText("ABC").overbar();

    mathParagraph.add(new MathBlock(overbar));

    presentation.save("overbar.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rychlý přehled**

| Úloha | Hlavní API |
| --- | --- |
| Vytvořit matematický text | [MathematicalText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathematicaltext/) |
| Kombinovat prvky | [IMathElement.join](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/) |
| Vytvořit zlomky | [IMathElement.divide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/) |
| Přidat horní nebo dolní index | [setSuperscript](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/) |
| Přidat funkce | [function](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/) |
| Přidat odmocniny | [IMathElement.radical](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/) |
| Přidat limity | [setLowerLimit](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/) |
| Přidat levé indexy | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/) |
| Přidat sumace a integrály | [nary](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/) |
| Přidat matice | [MathMatrix](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/mathmatrix/) |
| Přidat pole rovnic | [toMathArray](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/) |
| Přidat oddělovače | [enclose](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/) |
| Přidat čáry a rámečky | [overbar](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/) |
| Seskupit členy | [group](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imathelement/) |

## **Často kladené otázky**

**Mohu upravit existující rovnici v PowerPointu?**

Ano. Otevřete prezentaci, najděte tvar, který obsahuje `MathPortion`, získejte jeho `MathParagraph` a aktualizujte matematické bloky v tomto odstavci.

**Ukládají se rovnice jako upravitelná matematika v PowerPointu?**

Ano. Při uložení do PPTX Aspose.Slides zapíše rovnici jako upravitelný obsah Office math.

**Mohu exportovat rovnice do LaTeXu?**

Aspose.Slides exportuje matematické rovnice do MathML. Pokud potřebujete LaTeX, nejprve exportujte do MathML a poté jej převěďte pomocí nástroje, který podporuje požadovaný LaTeX dialekt.