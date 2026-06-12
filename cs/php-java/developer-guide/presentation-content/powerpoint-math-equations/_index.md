---
title: Přidání matematických rovnic do prezentací PowerPoint v PHP
linktitle: Matematické rovnice v PowerPointu
type: docs
weight: 80
url: /cs/php-java/powerpoint-math-equations/
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
- PHP
- Aspose.Slides
description: "Vkládejte a upravujte matematické rovnice v PowerPoint PPT a PPTX pomocí Aspose.Slides pro PHP přes Java, s podporou OMML, ovládání formátování a srozumitelných ukázek kódu v PHP."
---
## **Přehled**

PowerPoint ukládá rovnice jako Office Math Markup Language (OMML). Pomocí Aspose.Slides pro PHP přes Java můžete programově vytvářet stejný typ matematického obsahu: zlomky, radikály, funkce, limity, N-ární operátory, matice, pole a formátované matematické bloky.

V PowerPointu uživatelé obvykle přidávají rovnice přes **Insert > Equation**:

![Panel Insert v PowerPointu s vybraným příkazem Equation](powerpoint-math-equations_1.png)

Výsledek je editovatelný matematický text na snímku:

![Snímek PowerPointu obsahující editovatelnou matematickou rovnici](powerpoint-math-equations_2.png)

Aspose.Slides vytváří tento matematický text pomocí tří hlavních objektů:

- Matematický tvar, vytvořený pomocí [addMathShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#addMathShape), je tvar, který obsahuje rovnici.
- [MathPortion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathportion/) ukládá matematický obsah uvnitř textového rámce tvaru.
- [MathParagraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathparagraph/) obsahuje jeden nebo více objektů [MathBlock](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathblock/).

Většina níže uvedených příkladů používá [MathematicalText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathematicaltext/) a řetězené metody z [MathElementBase](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) pro stručný a čitelný kód.

Pro scénáře exportu do MathML viz [Export matematických rovnic z prezentací v PHP přes Java](/slides/cs/php-java/exporting-math-equations/).

## **Vytvoření rovnice**

Tento příklad vytvoří matematický tvar a přidá Pythagorovu větu:

![Rovnice c na druhou rovná se a na druhou plus b na druhou](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="primary" %}}
`addMathShape` vytváří tvar, který již obsahuje matematický odstavec. Přistupte k prvnímu `MathPortion`, získejte jeho `MathParagraph` a přidejte matematické bloky nebo matematické prvky.
{{% /alert %}}

## **Přidání zlomků**

Použijte [`divide`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) k vytvoření zlomku. Styl zlomku můžete zvolit pomocí [MathFractionTypes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathfractiontypes/).

![Šikmý matematický zlomek zobrazující 1 děleno x](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Pro svislý zlomek použijte `MathFractionTypes::Bar`:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Přidání radikálů**

Použijte [`radical`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) k vytvoření druhé odmocniny, třetí odmocniny nebo jiného kořene. Aktuální prvek se stane základem a argument se stane stupněm.

![Výraz n-tého kořene s x pod radikálovým znakem](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Přidání funkcí a limit**

Použijte [`asArgumentOfFunction`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) nebo [`function`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) pro funkce jako `sin(x)`, `log(x)` nebo vlastní názvy funkcí. Pro limity vložte `lim` do [MathLimit](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathlimit/) nebo použijte [`setLowerLimit`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/).

![Limita x, když x směřuje k nekonečnu](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Pro vlastní název funkce použijte název funkce jako aktuální prvek:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Přidání N-árních operátorů a integrálů**

Použijte [`nary`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) pro součty, sjednocení, průniky a další velké operátory. Použijte [`integral`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) pro integrály. Obě metody umožňují nastavit dolní a horní mez.

![Součet s dolní a horní mezí](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

N-ární operátory jsou určeny pro velké operátory s volitelnými mezemi. Jednoduché operátory jako `+`, `-` a `=` se obvykle přidávají jako `MathematicalText` a spojují do výrazu.

Pro integrál použijte `integral`:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Přidání matic**

Použijte [MathMatrix](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathmatrix/) pro řádky a sloupce. Matice ve výchozím nastavení neobsahují závorky, takže je obalte, pokud potřebujete závorky, hranaté závorky nebo složené závorky.

![Matematická matice se dvěma řádky a jednou prázdnou buňkou](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Přidání polí rovnic**

Použijte [`toMathArray`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) když potřebujete zarovnané rovnice nebo svislé uspořádání výrazů.

![Vertikální matematické pole s x nad y](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Přidání trigonometrických funkcí**

Použijte [`asArgumentOfFunction`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) když je argument aktuální prvek a název funkce je znám.

![Trigonometrická funkce cos aplikovaná na 2x](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Přidání indexů a exponentů**

Použijte pomocníky pro dolní a horní index pro indexy a mocniny. Když se indexy mají objevit vlevo od základu, použijte [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/).

![Velké Y s levým indexem 1 a exponentem n](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Přidání ohraničovačů**

Použijte [`enclose`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) k umístění výrazu mezi ohraničovače. Můžete také nastavit oddělovač pro výrazy s více prvky.

![Výraz s ohraničovači obsahující x, y a z oddělené svislými čarami](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Přidání ohraničeného rámečku**

Použijte [`toBorderBox`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) když má být rovnice ohraničena rámečkem.

![Rovnice v rámečku ukazující a na druhou rovná se b na druhou plus c na druhou](powerpoint-math-equations_12.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $boxedEquation = (new MathematicalText("a"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("b"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("c"))->setSuperscript("2"))
        - >toBorderBox();

    $mathParagraph->add(new MathBlock($boxedEquation));

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Seskupení výrazů**

Použijte [`group`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) k umístění skupinovacího znaku nad nebo pod výraz. Přidejte limitu pro popisek seskupených výrazů.

![Výraz x plus y seskupený s popiskem libovolný text pod ním](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Formátování matematických prvků**

Používejte pomocníky pro formátování jen tam, kde zjednodušují vzorec. Například [`overbar`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) umístí čáru nad matematický prvek.

![Matematický výraz ABC s horní čárou](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Rychlý přehled**

| Úkol | Hlavní API |
| --- | --- |
| Vytvořit matematický text | [MathematicalText](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathematicaltext/) |
| Kombinovat prvky | [join](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) |
| Vytvořit zlomky | [divide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) |
| Přidat horní index nebo dolní index | [setSuperscript](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) |
| Přidat funkce | [function](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) |
| Přidat radikály | [radical](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) |
| Přidat limity | [setLowerLimit](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) |
| Přidat skripty na levé straně | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) |
| Přidat součty a integrály | [nary](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) |
| Přidat matice | [MathMatrix](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathmatrix/) |
| Přidat pole rovnic | [toMathArray](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) |
| Přidat ohraničovače | [enclose](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) |
| Přidat čáry a rámečky | [overbar](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) |
| Seskupit výrazy | [group](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mathelementbase/) |

## **Často kladené otázky**

**Mohu editovat existující rovnici v PowerPointu?**

Ano. Otevřete prezentaci, najděte tvar, který obsahuje `MathPortion`, získejte jeho `MathParagraph` a aktualizujte matematické bloky v tomto odstavci.

**Ukládají se rovnice jako editovatelná matematika v PowerPointu?**

Ano. Při uložení do PPTX Aspose.Slides zapisuje rovnici jako editovatelný obsah Office Math.

**Mohu exportovat rovnice do LaTeXu?**

Aspose.Slides exportuje matematické rovnice do MathML. Pokud potřebujete LaTeX, nejprve exportujte do MathML a poté převěďte MathML pomocí nástroje, který podporuje požadovaný LaTeXový dialekt.