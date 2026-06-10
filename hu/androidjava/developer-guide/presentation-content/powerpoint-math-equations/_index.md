---
title: Math egyenletek hozzáadása PowerPoint prezentációkhoz Androidon
linktitle: PowerPoint Matematikai Egyenletek
type: docs
weight: 80
url: /hu/androidjava/powerpoint-math-equations/
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
- Android
- Java
- Aspose.Slides
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for Android segítségével, OMML támogatással, formázási vezérlőkkel és tiszta Java kódrészletekkel."
---
## **Áttekintés**

A PowerPoint egyenleteket az Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for Android via Java segítségével programozottan hozhat létre hasonló matematika tartalmakat: törtöket, gyököket, függvényeket, határokat, N-értelmű operátorokat, mátrixokat, tömböket és formázott matematikai blokkokat.

A PowerPointban a felhasználók általában a **Beszúrás > Egyenlet** menüből adnak hozzá egyenleteket:

![PowerPoint Beszúrás lap az Egyenlet parancs kiválasztásával](powerpoint-math-equations_1.png)

Az eredmény szerkeszthető matematikai szöveg a dián:

![PowerPoint dia szerkeszthető matematikai egyenlettel](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektumon keresztül építi fel ezt a matematikai szöveget:

- A matematikai alakzat, amelyet a [addMathShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/) hívással hozunk létre, az az alakzat, amely az egyenletet tartalmazza.
- [MathPortion](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathportion/) tárolja a matematikai tartalmat az alakzat szövegkeretében.
- [MathParagraph](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathblock/) objektumot tartalmaz.

Az alábbi legtöbb példa a [MathematicalText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathematicaltext/) és az [IMathElement](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/) folyékony metódusait használja, hogy a kód rövid és olvasható maradjon.

MathML export esetén lásd a [Matematikai egyenletek exportálása prezentációkból Androidra](/slides/hu/androidjava/exporting-math-equations/).

## **Egyenlet létrehozása**

Ez a példa egy matematikai alakzatot hoz létre, és hozzáadja a Pitagorasz-tételt:

![Az egyenlet: c² = a² + b²](powerpoint-math-equations_3.png)

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

`addMathShape` egy olyan alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. Hozzáfér az első `MathPortion`-hez, lekéri annak `MathParagraph`-ját, és matematikai blokkokat vagy elemeket ad hozzá.

{{% /alert %}}

## **Törtek hozzáadása**

`divide` használatával hozhat létre törtet. A tört stílusát a [MathFractionTypes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathfractiontypes/) segítségével választhatja ki.

![Egy ferde tört, amely az 1-et osztja x-szel](powerpoint-math-equations_4.png)

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

Halmozott törthez használja a `MathFractionTypes.Bar`-t:

```java
IMathFraction stackedFraction = new MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar);
```

## **Gyökök hozzáadása**

`radical` használatával hozhat létre négyzetgyököt, köbgyököt vagy egyéb gyököt. A jelenlegi elem lesz az alap, az argumentum pedig a kitevő.

![n-dik gyök kifejezés, x a gyökjel alatt](powerpoint-math-equations_5.png)

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

`asArgumentOfFunction` vagy `function` használatával hozhat létre függvényeket, például `sin(x)`, `log(x)`, vagy egyedi függvényneveket. Határokhoz helyezze a `lim`-et egy [MathLimit](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathlimit/) elembe, vagy használja a `setLowerLimit`-et.

![x határa, amikor x a végtelen felé tart](powerpoint-math-equations_8.png)

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

Egyedi függvénynév esetén tegye a függvénynevet a jelenlegi elemmé:

```java
IMathFunction customFunction = new MathematicalText("f").function("x + 1");
```

## **N-értékű operátorok és integrálok hozzáadása**

`nary` használatával hozhat létre összegeket, uniókat, metszeteket és más nagy operátorokat. `integral` segítségével integrálokat hozhat létre. Mindkét metódus lehetővé teszi az alsó és felső határok beállítását.

![Összegzés alsó és felső határokkal](powerpoint-math-equations_7.png)

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

N-értelmű operátorok nagy operátorok opcionális határokkal. Egyszerű operátorok, mint a `+`, `-` és `=` általában `MathematicalText`‑ként kerülnek hozzáadásra, majd a kifejezésbe illesztésre.

Integrálhoz használja a `integral`‑t:

```java
IMathBlock integralBase = new MathematicalText("x").join(new MathematicalText("dx").toBox());
IMathNaryOperator integral = integralBase.integral(MathIntegralTypes.Simple, "0", "1");
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathmatrix/)‑t sorok és oszlopok létrehozásához. Alapértelmezés szerint a mátrixok nem tartalmaznak zárójeleket, ezért körül kell őket tenni, ha zárójelekre, szögletes vagy kapcsos zárókra van szükség.

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

Használja a `toMathArray`‑t, ha igazított egyenletekre vagy függőleges kifejezésstackre van szükség.

![Függőleges matematikai tömb, x felett y](powerpoint-math-equations_11.png)

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

Használja a `asArgumentOfFunction`‑t, ha az argumentum a jelenlegi elem, és a függvény neve ismert.

![A cos trigonometrikus függvény 2x-re alkalmazva](powerpoint-math-equations_6.png)

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

Használja az alsó- és felső index segédfüggvényeket indexek és hatványok létrehozásához. Ha az indexeknek a bázis bal oldalán kell megjelenniük, alkalmazza a `setSubSuperscriptOnTheLeft`‑t.

![Nagy Y baloldali alsó index 1-gyel és felső index n-vel](powerpoint-math-equations_9.png)

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

`enclose` használatával helyezhet kifejezést határolók közé. Több elemet tartalmazó határolókhoz beállíthat elválasztó karaktert is.

![Határoló kifejezés, amely x, y és z elemeket tartalmaz függőleges vonalakkal elválasztva](powerpoint-math-equations_13.png)

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

## **Keretdoboz hozzáadása**

`toBorderBox` használatával keretezhet egy egyenletet.

![Keretbe tett egyenlet: a² = b² + c²](powerpoint-math-equations_12.png)

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

`group` használatával egy csoportosító karaktert helyezhet egy kifejezés fölé vagy alá. A csoportosított tagok felcímkézéséhez adjon hozzá egy határt.

![Az x + y kifejezés csoportosítva az alatta lévő “bármilyen szöveg” felirattal](powerpoint-math-equations_15.png)

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

Formázó segédfüggvényeket csak akkor használjon, ha azok tisztábbá teszik a képletet. Például az `overbar` egy vonalat helyez egy matematikai elem fölé.

![ABC matematikai kifejezés felülvonallal](powerpoint-math-equations_14.png)

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

## **Gyorsreferencia**

| Feladat | Fő API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathematicaltext/) |
| Elemek összevonása | [IMathElement.join](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/) |
| Törtek létrehozása | [IMathElement.divide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/) |
| Felső- vagy alsó index hozzáadása | [setSuperscript](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/), [setSubscript](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/) |
| Függvények hozzáadása | [function](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/), [asArgumentOfFunction](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/) |
| Gyökök hozzáadása | [IMathElement.radical](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/) |
| Határok hozzáadása | [setLowerLimit](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/), [setUpperLimit](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/) |
| Baloldali indexek hozzáadása | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/) |
| Összegekkel és integrálok hozzáadása | [nary](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/), [integral](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/mathmatrix/) |
| Egyenlettömbök hozzáadása | [toMathArray](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/) |
| Határolók hozzáadása | [enclose](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/) |
| Vonalk és keret hozzáadása | [overbar](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/), [toBorderBox](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/) |
| Tagok csoportosítása | [group](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/imathelement/) |

## **GYIK**

**Szerkeszthetek meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amely `MathPortion`‑t tartalmaz, szerezze meg a `MathParagraph`‑ját, és frissítse a bekezdésben lévő matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint matematikaként vannak mentve?**

Igen. PPTX formátumba mentéskor az Aspose.Slides az egyenletet szerkeszthető Office matematikai tartalomként írja.

**Exportálhatok egyenleteket LaTeX formátumba?**

Az Aspose.Slides a matematikai egyenleteket MathML formátumba exportálja. Ha LaTeX‑re van szüksége, először exportáljon MathML‑be, majd egy olyan eszközzel konvertálja, amely támogatja a kívánt LaTeX dialektust.