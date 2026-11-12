---
title: Matematikai egyenletek hozzáadása PowerPoint bemutatókhoz PHP-ben
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
- bemutató
- PHP
- Aspose.Slides
description: "Matematikai egyenletek beszúrása és szerkesztése PowerPoint PPT és PPTX fájlokban az Aspose.Slides for PHP via Java segítségével, támogatja az OMML-t, a formázási beállításokat és a tiszta PHP kódpéldákat."
---
## **Áttekintés**

A PowerPoint egyenleteket az Office Math Markup Language (OMML) formátumban tárolja. Az Aspose.Slides for PHP via Java segítségével programozottan hozhatja létre ugyanazt a típusú matematikai tartalmat: törtek, gyökök, függvények, határok, N-áris operátorok, mátrixok, tömbök és formázott matematikai blokkok.

PowerPointban a felhasználók általában a **Insert > Equation** menüből adnak hozzá egyenleteket:

![PowerPoint beszúrási lap a Képlet parancs kiválasztott állapottal](powerpoint-math-equations_1.png)

Az eredmény egy szerkeszthető matematikai szöveg a dián:

![PowerPoint dia szerkeszthető matematikai egyenlettel](powerpoint-math-equations_2.png)

Az Aspose.Slides három fő objektumon keresztül építi fel ezt a matematikai szöveget:

- Egy matematikai alakzat, amelyet a [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) hoz létre, az a forma, amely a képletet tartalmazza.
- A [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) tárolja a matematikai tartalmat az alakzat szövegdobozában.
- A [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) egy vagy több [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) objektumot tartalmaz.

Az alábbi legtöbb példában a [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) és a [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) folyékony metódusai szerepelnek, hogy a kód rövid és olvasható legyen.

MathML export esetén lásd a [Export Math Equations from Presentations in PHP via Java](/slides/hu/php-java/exporting-math-equations/).

## **Egyenlet létrehozása**

Ez a példa a [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) használatával hoz létre egy matematikai alakzatot, és hozzáadja a Pitagorasz-tételt:

![A c négyzet egyenlő a a négyzet plusz b négyzettel](powerpoint-math-equations_3.png)

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

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) olyan alakzatot hoz létre, amely már tartalmaz egy matematikai bekezdést. Érje el az első [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), hívja meg a [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) metódust, és adjon hozzá matematikai blokkokat vagy elemeket.
{{% /alert %}}

## **Törtek hozzáadása**

Használja a [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) metódust a tört létrehozásához. A [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/) segítségével választhat tömtípusok közül.

![Dőlt matematikai tört, amelyben 1 osztva x-szel szerepel](powerpoint-math-equations_4.png)

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

Összeállított tört létrehozásához használja a [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar) értéket:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Gyökök hozzáadása**

Használja a [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) metódust négyzetgyök, köbgyök vagy egyéb gyök létrehozásához. Az aktuális elem lesz az alap, az argumentum pedig a fok.

![n-dik gyök, ahol x a gyökjel alatti kifejezés](powerpoint-math-equations_5.png)

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

Használja az [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) vagy a [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) metódust olyan függvényekhez, mint a `sin(x)`, `log(x)` vagy egyedi függvénynevek. Határokhoz helyezze a `lim`-et egy [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) elembe, vagy használja a [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit) metódust.

![Az x határa, amikor x a végtelenhez közelít](powerpoint-math-equations_8.png)

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

Egyedi függvénynév esetén tegye a függvénynevet az aktuális elemmé, majd hívja meg a [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) metódust a paraméterrel:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **N-áris operátorok és integrálok hozzáadása**

Használja a [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) metódust összegekkel, uniókkal, metszetekkel és más nagy operátorokkal. Az integrálokhoz a [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) metódus áll rendelkezésre. Mindkét metódus lehetővé teszi a alsó és felső határok megadását.

![Összegzés alsó és felső határral](powerpoint-math-equations_7.png)

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

Az N-áris operátorok nagy operátorok opcionális határokkal. Az egyszerű operátorok, mint a `+`, `-`, és `=` általában a [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) segítségével kerülnek a kifejezésbe.

Integrálhoz használja a [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) metódust:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Mátrixok hozzáadása**

Használja a [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) elemet a sorok és oszlopok definiálásához. Alapértelmezetten a mátrixok nem tartalmaznak zárójeleket, ezért szükség esetén zárja őket zárójelek, szögletes zárójelek vagy kapcsos zárójelek közé.

![Két soros matematikai mátrix egy üres cellával](powerpoint-math-equations_10.png)

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

## **Egyenlet-tömbök hozzáadása**

Használja a [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) metódust, ha igazított egyenletekre vagy függőlegesen egymásra rakott kifejezésekre van szükség.

![Függőleges matematikai tömb, ahol az x az y fölött helyezkedik el](powerpoint-math-equations_11.png)

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

Használja az [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) metódust, amikor az argumentum az aktuális elem, és a függvény neve ismert.

![A trigonometrikus cos függvény 2x-re alkalmazva](powerpoint-math-equations_6.png)

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

Használja a fel- és alindexsegítőket indexek és hatványok létrehozásához. Ha az indexeknek a bázis bal oldalán kell megjelenniük, alkalmazza a [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) metódust.

![Nagy Y betű bal oldali alindexel 1 és felső indexszel n](powerpoint-math-equations_9.png)

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

## **Határolók hozzáadása**

Használja az [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) metódust, hogy egy kifejezést határolók közé helyezzen. Több elemet tartalmazó határoló kifejezéseknél beállíthatja az elválasztó karaktert is.

![Határoló kifejezés, amely x, y és z elemeket tartalmaz, függőleges vonalakkal elválasztva](powerpoint-math-equations_13.png)

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

### **Határolók mérete és igazítása**

A [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) `true` értékkel hívása lehetővé teszi, hogy a zárójelek egy magas operandus köré nőjenek, `false` értékkel a normál méretben maradnak. A [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) metódussal választhat a két [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/) közül. A `Centered` a zárójeleket a matematikai tengely közepére helyezi, ami az egyenlőségjel középvonala. A `Match` a tartalomhoz igazítja őket. Mindkét beállítás csak a határolókat érinti; a kifejezés belseje változatlan marad.

Az alábbi példa a `x` kitevőjébe helyez egy törtet, így a kifejezés a bázisvonal fölött nagyobb, mint alatta. Mind a négy egyenlet ugyanazokat a zárójeleket és betűtípust használja.

```php
use aspose\slides\MathDelimiterShape;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $opening = new Java("java.lang.Character", "(");
    $closing = new Java("java.lang.Character", ")");
    for ($row = 0; $row < 2; $row++) {
        for ($column = 0; $column < 2; $column++) {
            $fraction = (new MathematicalText("a + b"))->divide("c + d");
            $power = (new MathematicalText("x"))->setSuperscript($fraction);
            $delimiter = $power->enclose($opening, $closing);
            $delimiter->setGrowToMatchOperandHeight($row === 0);
            $delimiter->setDelimiterShape($column === 0 ? MathDelimiterShape::Centered : MathDelimiterShape::Match);

            $mathShape = $slide->getShapes()->addMathShape(20 + 330 * $column, 20 + 120 * $row, 300, 100);
            $portion = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $portion->getPortionFormat()->setFontHeight(32);
            $equation = (new MathematicalText("y = "))->join($delimiter);
            $portion->getMathParagraph()->add($equation);
        }
    }
    $presentation->save("delimiter-sizing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

PowerPointban hasonlítsa össze a sorokat, hogy lássa a növekedés hatását. A felső sorban a zárójelek a kitevő köré nőnek és mindkét alakzatnál egységesek. Az alsó sorban a növekedés ki van kapcsolva. A bal oldali kisebb zárójelek (`Centered`) az egyenlőségjelhez igazodnak, míg a jobb oldali (`Match`) magasabban helyezkednek el a kifejezés körül.

![Négy egyenlet PowerPointban, ahol a határolók növekedése be van kapcsolva felül és ki van kapcsolva alul; balra `Centered`, jobbra `Match`](delimiter-sizing.png)

## **Határdoboz hozzáadása**

Hívja meg a [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) metódust egy törtön, hogy az egész kifejezést keretbe helyezze. A visszakapott [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) alapértelmezés szerint mind a négy oldalát megjeleníti. A [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft) és [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) metódusokkal egyes oldalakat elrejthet.

A példa hat ugyanazon tört másolatát helyezi egy diára. A törlés jelezéséhez rejtse el mind a négy oldalt, és adja át `true` értéket a [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) metódusnak egy felfelé emelkedő átló (↗) létrehozásához, vagy a [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) metódusnak egy lefelé irányuló átló (↘) esetén. Használhatja továbbá a [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) vagy a [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) metódust bármely kombinációban a látható oldalakkal.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(540, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $addFraction = function ($x, $y, $hideBorder) use ($slide) {
        $fraction = (new MathematicalText("x+1"))->divide("y+2");
        $box = $fraction->toBorderBox();
        $box->setHideTop($hideBorder);
        $box->setHideBottom($hideBorder);
        $box->setHideLeft($hideBorder);
        $box->setHideRight($hideBorder);

        $shape = $slide->getShapes()->addMathShape($x, $y, 160, 90);
        $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(28);
        $mathBlock = new MathBlock($box);
        $portion->getMathParagraph()->add($mathBlock);
        return $box;
    };

    $addFraction(10, 10, false);

    $partial = $addFraction(190, 10, false);
    $partial->setHideTop(true);
    $partial->setHideRight(true);

    $addFraction(370, 10, true)->setStrikethroughBottomLeftToTopRight(true);
    $addFraction(10, 120, true)->setStrikethroughTopLeftToBottomRight(true);
    $addFraction(190, 120, true)->setStrikethroughHorizontal(true);
    $addFraction(370, 120, false)->setStrikethroughVertical(true);

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Hat szerkeszthető tört PowerPointban. Felső sor: teljes keret, alsó és bal oldali vonalak, felfelé emelkedő átló. Alsó sor: lefelé irányuló átló, vízszintes vonal, függőleges vonal teljes kerettel.](border-box-fractions.png)

Ezen tört esetén a vízszintes vonal átfedi a tört vonalát. A függőleges vonal mind a számlálót, mind a nevezőt átszeli, miközben a körülötte lévő keret látható marad. Ezek a vonalak az egész kifejezést díszítik. A hagyományos szövegátvonás a szövegfuttatban lévő karakterekre vonatkozik. A prezentáció újra megnyitása után a PowerPointban még mindig szerkeszthető a számláló és a nevező külön-külön.

## **Kifejezések csoportosítása**

Használja a [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) metódust, hogy egy csoportosító karaktert tegyen egy kifejezés fölé vagy alá. Adjunk határt a csoportosított tagok felcímkézéséhez.

![Az x + y kifejezés csoportosítva, a címke "bármilyen szöveg" alatta](powerpoint-math-equations_15.png)

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

Csak ott használjon formázó segédfüggvényeket, ahol azok tisztázzák a képletet. Például az [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) egy sávot helyez a matematikai elem fölé.

![ABC matematikai kifejezés vonallal a tetején](powerpoint-math-equations_14.png)

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

### **Szöveg formázása meglévő egyenletben**

A szöveg formázásához egy létező egyenletben járja be minden matematikai blokk elemfáját. A [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) csak a közvetlen gyerekeket adja vissza, ezért rekurzívan kell hívni, hogy elérje a törtek, indexek, gyökök és egyéb beágyazott struktúrák belső szövegét. Ellenőrizze az aktuális elemet és gyermekeit is, hogy a kiinduló elem, ha [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/), szintén bele legyen véve.

Ez a példa azt feltételezi, hogy a `input.pptx` egy olyan egyenletet tartalmaz, mint például `z = xᵢ / ∛y`, ahol a tört számlálójában alindex, a nevezőben pedig gyök szerepel. Ha csak a blokk felső szintű elemeit dolgozza fel, a tört belső szövegét figyelmen kívül hagyja. A példa megtalálja a matematikai részeket a dia szövegdobozaiban, eléri blokkjait a [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) segítségével, és a [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) metódussal 28 pont magasságra állítja a betűméretet minden szövegelem [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) metódusán keresztül.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function formatMathText($element, $mathematicalTextClass) {
    if (java_instanceof($element, $mathematicalTextClass)) {
        $element->getFormat()->setFontHeight(28);
    }

    foreach ($element->getChildren() as $child) {
        formatMathText($child, $mathematicalTextClass);
    }
}

$mathematicalTextClass = new JavaClass("com.aspose.slides.MathematicalText");
$autoShapeClass = new JavaClass("com.aspose.slides.IAutoShape");
$mathPortionClass = new JavaClass("com.aspose.slides.IMathPortion");

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (java_instanceof($portion, $mathPortionClass)) {
                        for ($blockIndex = 0; $blockIndex < java_values($portion->getMathParagraph()->getCount()); $blockIndex++) {
                            $block = $portion->getMathParagraph()->get_Item($blockIndex);
                            formatMathText($block, $mathematicalTextClass);
                        }
                    }
                }
            }
        }
    }

    $presentation->save("formatted-equations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Az elmentett prezentáció minden szintjén frissített szövegformázást tartalmaz a feldolgozott egyenletekben, miközben megőrzi a szövegtartalmat és a matematikai struktúrát.

## **Gyors referenciák**

| Feladat | Fő API |
| --- | --- |
| Matematikai szöveg létrehozása | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| Elemek kombinálása | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Törtek létrehozása | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Felső- vagy alsó index hozzáadása | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Függvények hozzáadása | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Gyökök hozzáadása | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Határok hozzáadása | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Baloldali indexek hozzáadása | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Összegzések és integrálok hozzáadása | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Mátrixok hozzáadása | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| Egyenlet-tömbök hozzáadása | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Határolók hozzáadása | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Vonalak és keretek hozzáadása | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Kifejezések csoportosítása | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **GYIK**

**Szerkeszthetem-e a meglévő PowerPoint egyenletet?**

Igen. Nyissa meg a prezentációt, keresse meg azt az alakzatot, amelyik [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) tartalmaz, hívja meg a [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph) metódust, és frissítse a benne lévő matematikai blokkokat.

**Az egyenletek szerkeszthető PowerPoint matematikaként vannak-e mentve?**

Igen. PPTX formátumba mentéskor az Aspose.Slides a képletet szerkeszthető Office math tartalomként írja ki.

**Exportálhatók-e az egyenletek LaTeX formátumba?**

Igen. Szerezze be az egyenlet [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) objektumát a [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) segítségével, majd hívja meg a [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) metódust a közvetlen exportáláshoz. Teljes példáért tekintse meg a [Export Math Equations from Presentations in PHP via Java](/slides/hu/php-java/exporting-math-equations/#export-math-equations-to-latex) oldalt.