---
title: Dodawanie równań matematycznych do prezentacji PowerPoint w PHP
linktitle: Równania matematyczne PowerPoint
type: docs
weight: 80
url: /pl/php-java/powerpoint-math-equations/
keywords:
- równanie matematyczne
- symbol matematyczny
- formuła matematyczna
- tekst matematyczny
- dodaj równanie matematyczne
- dodaj symbol matematyczny
- dodaj formułę matematyczną
- dodaj tekst matematyczny
- PowerPoint
- prezentacja
- PHP
- Aspose.Slides
description: "Wstawianie i edytowanie równań matematycznych w PowerPoint PPT i PPTX za pomocą Aspose.Slides for PHP via Java, obsługa OMML, kontrola formatowania i przejrzyste przykłady kodu PHP."
---
## **Przegląd**

PowerPoint przechowuje równania jako Office Math Markup Language (OMML). Dzięki Aspose.Slides for PHP via Java możesz programowo tworzyć ten sam rodzaj treści matematycznych: ułamki, pierwiastki, funkcje, granice, operatory N-ary, macierze, tablice i sformatowane bloki matematyczne.

W PowerPoint użytkownicy zazwyczaj dodają równania z **Wstaw > Równanie**:

![Zakładka Wstaw w PowerPoint z wybraną komendą Równanie](powerpoint-math-equations_1.png)

Wynikiem jest edytowalny tekst matematyczny na slajdzie:

![Slajd PowerPoint zawierający edytowalny równanie matematyczne](powerpoint-math-equations_2.png)

Aspose.Slides tworzy ten tekst matematyczny za pomocą trzech głównych obiektów:

- Kształt matematyczny, tworzony przy pomocy [addMathShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#addMathShape), jest kształtem, który zawiera równanie.
- [MathPortion](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathportion/) przechowuje zawartość matematyczną w ramce tekstowej kształtu.
- [MathParagraph](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathparagraph/) zawiera jeden lub więcej obiektów [MathBlock](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathblock/).

Większość przykładów poniżej używa [MathematicalText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathematicaltext/) oraz płynnych metod z [MathElementBase](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/), aby kod był krótki i czytelny.

Dla scenariuszy eksportu MathML zobacz [Eksportowanie równań matematycznych z prezentacji w PHP przez Java](/slides/pl/php-java/exporting-math-equations/).

## **Utworzenie równania**

Ten przykład tworzy kształt matematyczny i dodaje twierdzenie Pitagorasa:

![Równanie c kwadrat równa się a kwadrat plus b kwadrat](powerpoint-math-equations_3.png)

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
`addMathShape` tworzy kształt, który już zawiera akapit matematyczny. Uzyskaj dostęp do pierwszego `MathPortion`, pobierz jego `MathParagraph` i dodaj bloki matematyczne lub elementy matematyczne.
{{% /alert %}}

## **Dodawanie ułamków**

Użyj [`divide`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) aby utworzyć ułamek. Możesz wybrać styl ułamka za pomocą [MathFractionTypes](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathfractiontypes/).

![Skośny ułamek matematyczny pokazujący jeden podzielone przez x](powerpoint-math-equations_4.png)

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

Aby uzyskać ułamek w formie stosu, użyj `MathFractionTypes::Bar`:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Dodawanie pierwiastków**

Użyj [`radical`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) aby utworzyć pierwiastek kwadratowy, sześcienny lub inny. Bieżący element staje się podstawą, a argument określa stopień.

![Wyrażenie pierwiastka n‑tego z x pod znakiem pierwiastka](powerpoint-math-equations_5.png)

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

## **Dodawanie funkcji i granic**

Użyj [`asArgumentOfFunction`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) lub [`function`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/), aby dodać funkcje takie jak `sin(x)`, `log(x)` lub własne nazwy funkcji. Dla granic umieść `lim` w [MathLimit](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathlimit/) lub użyj [`setLowerLimit`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/).

![Granica x gdy x dąży do nieskończoności](powerpoint-math-equations_8.png)

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

Aby użyć własnej nazwy funkcji, ustaw nazwę funkcji jako bieżący element:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Dodawanie operatorów N-ary i całek**

Użyj [`nary`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) aby dodać sumy, unie, przecięcia i inne duże operatory. Użyj [`integral`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) aby dodać całki. Obie metody pozwalają ustawić dolne i górne granice.

![Sumowanie z dolną i górną granicą](powerpoint-math-equations_7.png)

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

Operatory N-ary służą do dużych operatorów z opcjonalnymi granicami. Proste operatory takie jak `+`, `-` i `=` zwykle dodaje się jako `MathematicalText` i łączy w wyrażeniu.

Aby dodać całkę, użyj `integral`:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Dodawanie macierzy**

Użyj [MathMatrix](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathmatrix/) aby definiować wiersze i kolumny. Macierze domyślnie nie zawierają nawiasów, więc otocz macierz, gdy potrzebujesz nawiasów okrągłych, kwadratowych lub klamrowych.

![Matematyczna macierz z dwoma wierszami i jedną pustą komórką](powerpoint-math-equations_10.png)

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

## **Dodawanie tablic równań**

Użyj [`toMathArray`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) gdy potrzebujesz wyrównanych równań lub pionowego stosu wyrażeń.

![Pionowa tablica matematyczna z x nad y](powerpoint-math-equations_11.png)

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

## **Dodawanie funkcji trygonometrycznych**

Użyj [`asArgumentOfFunction`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) gdy argument jest bieżącym elementem, a nazwa funkcji jest znana.

![Funkcja trygonometryczna cos zastosowana do 2x](powerpoint-math-equations_6.png)

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

## **Dodawanie indeksów dolnych i górnych**

Użyj pomocników indeksów dolnych i górnych dla indeksów i potęg. Gdy indeksy mają znajdować się po lewej stronie podstawy, użyj [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/).

![Wielka litera Y z lewostronnym indeksem dolnym 1 i górnym n](powerpoint-math-equations_9.png)

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

## **Dodawanie ograniczników**

Użyj [`enclose`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) aby umieścić wyrażenie w obrębie ograniczników. Możesz również ustawić znak separatora dla wyrażeń ograniczonych, które zawierają kilka elementów.

![Wyrażenie z ogranicznikami zawierające x, y i z oddzielone pionowymi kreskami](powerpoint-math-equations_13.png)

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

## **Dodawanie ramki obramowania**

Użyj [`toBorderBox`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) gdy samo równanie ma być otoczone ramką.

![Równanie w ramce pokazujące a kwadrat równa się b kwadrat plus c kwadrat](powerpoint-math-equations_12.png)

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

## **Grupowanie terminów**

Użyj [`group`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) aby umieścić znak grupujący nad lub pod wyrażeniem. Dodaj granicę, aby opisać pogrupowane terminy.

![Wyrażenie x plus y pogrupowane z etykietą dowolny tekst pod nim](powerpoint-math-equations_15.png)

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

## **Formatowanie elementów matematycznych**

Używaj pomocników formatowania tylko tam, gdzie wyjaśniają formułę. Na przykład, [`overbar`](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) umieszcza pasek nad elementem matematycznym.

![Wyrażenie matematyczne ABC z nadkreśleniem](powerpoint-math-equations_14.png)

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

## **Szybkie odwołanie**

| Zadanie | Główne API |
| --- | --- |
| Utworzenie tekstu matematycznego | [MathematicalText](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathematicaltext/) |
| Łączenie elementów | [join](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) |
| Tworzenie ułamków | [divide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) |
| Dodawanie indeksu górnego lub dolnego | [setSuperscript](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) |
| Dodawanie funkcji | [function](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) |
| Dodawanie pierwiastków | [radical](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) |
| Dodawanie granic | [setLowerLimit](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) |
| Dodawanie skryptów po lewej stronie | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) |
| Dodawanie sum i całek | [nary](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) |
| Dodawanie macierzy | [MathMatrix](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathmatrix/) |
| Dodawanie tablic równań | [toMathArray](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) |
| Dodawanie ograniczników | [enclose](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) |
| Dodawanie kresek i ramek | [overbar](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) |
| Grupowanie terminów | [group](https://reference.aspose.com/slides/pl/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Czy mogę edytować istniejące równanie w PowerPoint?**

Tak. Otwórz prezentację, znajdź kształt zawierający `MathPortion`, pobierz jego `MathParagraph` i zaktualizuj bloki matematyczne w tym akapicie.

**Czy równania są zapisywane jako edytowalna matematyka PowerPoint?**

Tak. Gdy zapisujesz do PPTX, Aspose.Slides zapisuje równanie jako edytowalną zawartość Office Math.

**Czy mogę eksportować równania do LaTeX?**

Aspose.Slides eksportuje równania matematyczne do MathML. Jeśli potrzebujesz LaTeX, najpierw wyeksportuj do MathML, a następnie przekonwertuj MathML przy użyciu narzędzia obsługującego wybrany dialekt LaTeX.