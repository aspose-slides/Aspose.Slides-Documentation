---
title: Matematikai egyenletek hozzáadása PowerPoint prezentációkhoz PHP-ben
linktitle: PowerPoint matematikai egyenletek
type: docs
weight: 80
url: /hu/php-java/powerpoint-math-equations/
keywords:
- matematikai egyenlet
- matematikai szimbólum
- matematikai képlet
- matematikai szöveg
- matematikai egyenlet hozzáadása
- matematikai szimbólum hozzáadása
- matematikai képlet hozzáadása
- matematikai szöveg hozzáadása
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for PHP via Java segítségével, OMML támogatással, formázási vezérlőkkel és áttekinthető PHP kódmintákkal."
---
## **Áttekintés**

A PowerPoint egyenleteket az Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for PHP via Java segítségével programozottan hozhat létre ugyanilyen matematikai tartalmakat: törtöket, gyököket, függvényeket, határokat, N‑áris operátorokat, mátrixokat, tömböket és formázott matematikai blokkokat.

A PowerPointban a felhasználók általában az **Insert > Equation** menüpontból adnak hozzá egyenleteket:

![PowerPoint Beszúrás fül, a Képlet parancs kijelölve](powerpoint-math-equations_1.png)

Az eredmény egy szerkeszthető matematikai szöveg a dián:

![PowerPoint diavetítés szerkeszthető matematikai egyenlettel](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektumon keresztül építi fel ezt a matematikai szöveget:

- A matematikai alakzat, amelyet a [addMathShape](https://reference.aspose.com/slides/hu/php-java/aspose.slides/shapecollection/#addMathShape) metódussal hozunk létre, az az alakzat, amely tartalmazza az egyenletet.
- A [MathPortion](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathportion/) tárolja a matematikai tartalmat az alakzat szövegkeretében.
- A [MathParagraph](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathblock/) objektumot tartalmaz.

Az alábbi legtöbb példa a [MathematicalText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathematicaltext/) és a [MathElementBase](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) fluent metódusait használja, hogy a kód rövid és olvasható maradjon.

MathML export esetén lásd a [Matematikai egyenletek exportálása prezentációkból PHP via Java](/slides/hu/php-java/exporting-math-equations/) oldalt.

## **Egyenlet létrehozása**

Ez a példa létrehoz egy matematikai alakzatot és hozzáadja a Pitagorasz‑tételt:

![Az egyenlet: c² = a² + b²](powerpoint-math-equations_3.png)

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
`addMathShape` egy olyan alakzatot hoz létre, amely már tartalmaz matematikai bekezdést. Hozzáférhet az első `MathPortion`‑höz, megszerezheti a `MathParagraph`‑ját, és hozzáadhat matematikai blokkokat vagy elemeket.
{{% /alert %}}

## **Törtök hozzáadása**

Használja a [`divide`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) metódust egy tört létrehozásához. A tört stílusát a [MathFractionTypes](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathfractiontypes/) segítségével választhatja ki.

![Egy ferdén ábrázolt tört, amely 1-et oszt x-szel](powerpoint-math-equations_4.png)

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

Halmozott tört esetén használja a `MathFractionTypes::Bar`‑t:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Gyökök hozzáadása**

Használja a [`radical`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) metódust négyzetgyök, köbgyök vagy egyéb gyök létrehozásához. A jelenlegi elem lesz az alap, a paraméter pedig a gyök fokszáma.

![Egy n‑edik gyök kifejezés, ahol az x a gyökjel alatt áll](powerpoint-math-equations_5.png)

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

## **Függvények és határok hozzáadása**

Használja a [`asArgumentOfFunction`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) vagy a [`function`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) metódust `sin(x)`, `log(x)` vagy egyedi függvénynevek esetén. Határokhoz helyezze a `lim`‑et egy [MathLimit](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathlimit/)‑be, vagy használja a [`setLowerLimit`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/)‑t.

![Az x határa, amikor x a végtelen felé tart](powerpoint-math-equations_8.png)

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

Egyedi függvénynév esetén tegye a függvény nevét a jelenlegi elemnek:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N‑áris operátorok és integrálok hozzáadása**

Használja a [`nary`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) metódust összegzések, uniók, metszetek és egyéb nagy operátorok létrehozásához. Az integrálokhoz használja a [`integral`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) metódust. Mindkét metódus lehetővé teszi az alsó és felső határok beállítását.

![Összegzés alsó és felső határokkal](powerpoint-math-equations_7.png)

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

Az N‑áris operátorok nagy operátorok opcionális határokkal. Egyszerű operátorokat, például `+`, `-` és `=` általában `MathematicalText`‑ként adunk hozzá, és a kifejezésbe illesztjük.

Integrálhoz használja az `integral`‑t:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathmatrix/)‑t sorok és oszlopok kezeléséhez. Alapértelmezés szerint a mátrixok nem tartalmaznak zárójeleket, ezért ha zárójelekre, szögletes vagy kapcsos zárókra van szükség, tekerje be a mátrixot.

![Két soros matematikai mátrix, egy üres cellával](powerpoint-math-equations_10.png)

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

## **Egyenlet tömbök hozzáadása**

Használja a [`toMathArray`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/)‑t, ha igazított egyenletekre vagy függőleges kifejezés‑kupacra van szükség.

![Függőleges matematikai tömb, ahol x a y felett](powerpoint-math-equations_11.png)

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

## **Trigonometrikus függvények hozzáadása**

Használja a [`asArgumentOfFunction`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/)‑t, amikor az argumentum a jelenlegi elem, és a függvény neve ismert.

![A trigonometrikus cos függvény alkalmazva 2x-re](powerpoint-math-equations_6.png)

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

## **Alsó- és felső indexek hozzáadása**

Használja az alsó‑ és felső index segédfüggvényeit indexek és hatványok létrehozásához. Ha az indexeknek az alap bal oldalán kell megjelenniük, használja a [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/)‑t.

![Egy nagy Y baloldali alsó indexszel 1 és felső indexszel n](powerpoint-math-equations_9.png)

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

## **Elválasztók hozzáadása**

Használja a [`enclose`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/)‑t egy kifejezés elválasztók közé helyezéséhez. Több elemet tartalmazó elválasztó kifejezésekhez beállíthatja a szeparátor karaktert is.

![Egy elválasztó kifejezés, amely x-et, y-t és z-t függőleges vonalakkal választ el](powerpoint-math-equations_13.png)

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

## **Keret doboz hozzáadása**

Használja a [`toBorderBox`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/)‑t, ha az egyenletet magát keretbe szeretné helyezni.

![Keretbe helyezett egyenlet, amely a² = b² + c²](powerpoint-math-equations_12.png)

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

## **Tagok csoportosítása**

Használja a [`group`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/)‑t egy csoportosító karakter fel- vagy alulra helyezéséhez egy kifejezésben. Hozzáadhat egy határt a csoportosított tagok feliratozásához.

![Az x + y kifejezés csoportosítva, alatta tetszőleges szöveges felirat](powerpoint-math-equations_15.png)

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

## **Matematikai elemek formázása**

Használja a formázó segédfüggvényeket csak ott, ahol a képletet tisztábbá teszik. Például a [`overbar`](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) egy vonalat helyez egy matematikai elem fölé.

![ABC matematikai kifejezés felül vonallal](powerpoint-math-equations_14.png)

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

## **Gyors referencia**

| Feladat | Fő API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathematicaltext/) |
| Elemek egyesítése | [join](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) |
| Törtök létrehozása | [divide](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) |
| Felső vagy alsó index hozzáadása | [setSuperscript](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) |
| Függvények hozzáadása | [function](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) |
| Gyökök hozzáadása | [radical](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) |
| Határok hozzáadása | [setLowerLimit](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) |
| Bal oldalú indexek hozzáadása | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) |
| Összegzések és integrálok hozzáadása | [nary](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathmatrix/) |
| Egyenlet tömbök hozzáadása | [toMathArray](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) |
| Elválasztók hozzáadása | [enclose](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) |
| Vonalak és keretek hozzáadása | [overbar](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) |
| Tagok csoportosítása | [group](https://reference.aspose.com/slides/hu/php-java/aspose.slides/mathelementbase/) |

## **GYIK**

**Szerkeszthetek egy meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amely `MathPortion`‑t tartalmaz, szerezze meg a `MathParagraph`‑ját, és frissítse a bekezdésben lévő matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint matematikaként kerülnek mentésre?**

Igen. PPTX formátumba mentéskor az Aspose.Slides az egyenletet szerkeszthető Office‑math tartalomként írja.

**Exportálhatok egyenleteket LaTeX‑be?**

Az Aspose.Slides a matematikai egyenleteket MathML‑be exportálja. Ha LaTeX‑re van szüksége, először exportálja MathML‑be, majd egy olyan eszközzel konvertálja, amely támogatja a kívánt LaTeX dialektust.