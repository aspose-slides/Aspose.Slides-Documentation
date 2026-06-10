---
title: Matematika egyenletek hozzáadása PowerPoint előadásokhoz Java-ban
linktitle: PowerPoint matematikai egyenletek
type: docs
weight: 80
url: /hu/java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "Matematikai egyenletek beillesztése és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for Java segítségével, OMML támogatással, formázási beállításokkal és világos Java kódpéldákkal."
---
## **Áttekintés**

A PowerPoint egyenleteket az Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for Java-val programozottan hozhat létre ugyanolyan matematikai tartalmakat: törtöket, gyököket, függvényeket, határokat, N-áris operátorokat, mátrixokat, tömböket és formázott matematikai blokkokat.

PowerPointban a felhasználók általában a **Insert > Equation** menüből adnak hozzá egyenleteket:

![PowerPoint Insert lap az Equation parancs kiválasztva](powerpoint-math-equations_1.png)

Az eredmény szerkeszthető matematikai szöveg a dián:

![PowerPoint dia szerkeszthető matematikai egyenlettel](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektumon keresztül építi fel ezt a matematikai szöveget:

- Egy matematikai alakzat, amelyet az [addMathShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishapecollection/#addMathShape-float-float-float-float-) hívással hozunk létre, az az alakzat, amely tartalmazza az egyenletet.
- A [MathPortion](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mathportion/) tárolja a matematikai tartalmat az alakzat szövegkeretében.
- A [MathParagraph](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mathblock/) objektumot tartalmaz.

Az alábbi példák többsége a [MathematicalText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mathematicaltext/) és az [IMathElement](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/) folyékony metódusait használja a kód rövid és olvasható tartásához.

MathML export esetén lásd a [Export Math Equations from Presentations in Java](/slides/hu/java/exporting-math-equations/) oldalt.

## **Egyenlet létrehozása**

Ez a példa egy matematikai alakzatot hoz létre, és hozzáadja a Pitagorasz-tételt:

![A c négyzet egyenlő a a négyzet plusz b négyzet egyenlet](powerpoint-math-equations_3.png)

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

`addMathShape` olyan alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. Érje el az első `MathPortion`‑t, szerezze meg annak `MathParagraph`‑ját, és adjon hozzá matematikai blokkokat vagy elemeket.

{{% /alert %}}

## **Törtek hozzáadása**

Használja a `divide` függvényt tört létrehozásához. A tört stílusát a [MathFractionTypes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mathfractiontypes/) segítségével választhatja ki.

![Dőlt tört, amely egyet oszt el x‑szel](powerpoint-math-equations_4.png)

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

Halmozott tört esetén használja a `MathFractionTypes.Bar`‑t:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Gyökök hozzáadása**

Használja a `radical` függvényt négyzetgyök, köbgyök vagy más gyök létrehozásához. A jelenlegi elem lesz az alap, az argumentum pedig a kitevő.

![n-edik gyök x‑szel a gyökjel alatt](powerpoint-math-equations_5.png)

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

## **Függvények és határok hozzáadása**

Használja az `asArgumentOfFunction` vagy a `function` metódust olyan függvényekhez, mint a `sin(x)`, `log(x)` vagy egyedi függvénynevek. Határokhoz helyezze a `lim`‑et egy [MathLimit](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mathlimit/)‑ba, vagy használja a `setLowerLimit`‑et.

![Az x határa, amikor x a végtelen felé tart](powerpoint-math-equations_8.png)

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape mathShape = slide.getShapes().addMathShape(20, 20, 700, 100);
    IMathParagraph mathParagraph = ((MathPortion) mathShape.getTextFrame().getParagraphs()
            .get_Item(0).getPortions().get_Item(0)).getMathParagraph();

    IMathFunction limit = new MathematicalText("lim")
            .setLowerLimit("x\u2192\u221E")
            .function("x");

    mathParagraph.add(new MathBlock(limit));

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Egyedi függvénynév esetén tegye a függvény nevét a jelenlegi elemévé:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N-áris operátorok és integrálok hozzáadása**

Használja az `nary`‑t összegzésekhez, uniókhoz, metszetekhez és más nagy operátorokhoz. Az `integral`‑t integrálokhoz. Mindkét metódus lehetővé teszi a alsó és felső határ beállítását.

![Összegzés alsó és felső határral](powerpoint-math-equations_7.png)

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

Az N-áris operátorok nagy operátorok opcionális határokkal. Egyszerű operátorok, mint a `+`, `-`, és `=` általában `MathematicalText`‑ként kerülnek hozzáadásra, és összekapcsolódnak a kifejezésben.

Integrálhoz használja a `integral`‑t:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mathmatrix/)‑t sorok és oszlopok definiálásához. A mátrixok alapból nem tartalmaznak zárójeleket, ezért szükség esetén zárja őket zárójelek, szögletes zárójelek vagy kapcsos zárójelek közé.

![Két soros matematikai mátrix egy üres cellával](powerpoint-math-equations_10.png)

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

## **Egyenlet tömbök hozzáadása**

Használja a `toMathArray`‑t, ha igazított egyenletekre vagy függőleges kifejezéssorozatra van szükség.

![Függőleges matematikai tömb, ahol x az y fölött áll](powerpoint-math-equations_11.png)

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

## **Trigonometrikus függvények hozzáadása**

Használja az `asArgumentOfFunction`‑t, ha az argumentum a jelenlegi elem, és a függvény neve ismert.

![A cos függvény alkalmazva 2x‑re](powerpoint-math-equations_6.png)

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

## **Alsó- és felső indexek hozzáadása**

Használja az alsó- és felső index segédfüggvényeit indexek és hatványok megadásához. Ha az indexeknek a bázis bal oldalán kell megjelenniük, használja a `setSubSuperscriptOnTheLeft`‑t.

![Nagy Y baloldali alsó index 1 és felső index n](powerpoint-math-equations_9.png)

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

## **Határolók hozzáadása**

Használja az `enclose`‑t egy kifejezés határolók közé helyezéséhez. Szétválasztó karaktert is beállíthat több elemet tartalmazó határoló kifejezésekhez.

![Határoló kifejezés, amely x‑et, y‑t és z‑t függőleges vonalakkal választ el](powerpoint-math-equations_13.png)

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

## **Keretezett doboz hozzáadása**

Használja a `toBorderBox`‑t, ha maga az egyenlet keretezve kell legyen.

![Dobozba helyezett egyenlet, ahol c négyzet egyenlő b négyzet plusz a négyzet](powerpoint-math-equations_12.png)

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

## **Tagok csoportosítása**

Használja a `group`‑ot, hogy egy csoportosító karaktert helyezzen az egy kifejezés fölé vagy alá. Címkézze a csoportosított tagokat egy határral.

![x + y kifejezés csoportosítva, alatta egy tetszőleges szöveg címkével](powerpoint-math-equations_15.png)

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

## **Matematikai elemek formázása**

Csak ott használja a formázó segédfüggvényeket, ahol azok tisztábbá teszik a képletet. Például az `overbar` vonalat helyez egy matematikai elem fölé.

![ABC matematikai kifejezés overbar‑ral](powerpoint-math-equations_14.png)

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

## **Gyors referencia**

| Feladat | Fő API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mathematicaltext/) |
| Elemek kombinálása | [IMathElement.join](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#join-com.aspose.slides.IMathElement-) |
| Törtek létrehozása | [IMathElement.divide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#divide-com.aspose.slides.IMathElement-) |
| Felső- vagy alsó index hozzáadása | [setSuperscript](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#setSuperscript-com.aspose.slides.IMathElement-), [setSubscript](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#setSubscript-com.aspose.slides.IMathElement-) |
| Függvények hozzáadása | [function](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#function-com.aspose.slides.IMathElement-), [asArgumentOfFunction](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#asArgumentOfFunction-com.aspose.slides.IMathElement-) |
| Gyökök hozzáadása | [IMathElement.radical](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#radical-com.aspose.slides.IMathElement-) |
| Határok hozzáadása | [setLowerLimit](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#setLowerLimit-com.aspose.slides.IMathElement-), [setUpperLimit](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#setUpperLimit-com.aspose.slides.IMathElement-) |
| Baloldali indexek hozzáadása | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Összegzések és integrálok hozzáadása | [nary](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-), [integral](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/hu/java/com.aspose.slides/mathmatrix/) |
| Egyenlet tömbök hozzáadása | [toMathArray](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#toMathArray--) |
| Határolók hozzáadása | [enclose](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#enclose-char-char-) |
| Vízszintes vonalak és keretek | [overbar](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#overbar--), [toBorderBox](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#toBorderBox--) |
| Tagok csoportosítása | [group](https://reference.aspose.com/slides/hu/java/com.aspose.slides/imathelement/#group-char-int-int-) |

## **GYIK**

**Szerkeszthetem a meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amelyik `MathPortion`‑t tartalmaz, szerezze meg a `MathParagraph`‑ját, és frissítse a benne lévő matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint matematikaként kerülnek mentésre?**

Igen. PPTX mentésekor az Aspose.Slides az egyenletet szerkeszthető Office Math tartalomként írja ki.

**Exportálhatom az egyenleteket LaTeX‑be?**

Az Aspose.Slides a matematikai egyenleteket MathML‑be exportálja. Ha LaTeX‑re van szüksége, először exportáljon MathML‑be, majd konvertálja a MathML‑t egy olyan eszközzel, amely támogatja a kívánt LaTeX dialektust.