---
title: Aggiungi equazioni matematiche alle presentazioni PowerPoint in PHP
linktitle: Equazioni matematiche PowerPoint
type: docs
weight: 80
url: /it/php-java/powerpoint-math-equations/
keywords:
- equazione matematica
- simbolo matematico
- formula matematica
- testo matematico
- aggiungi equazione matematica
- aggiungi simbolo matematico
- aggiungi formula matematica
- aggiungi testo matematico
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Inserisci e modifica equazioni matematiche in PowerPoint PPT e PPTX con Aspose.Slides per PHP via Java, supportando OMML, controlli di formattazione e chiari esempi di codice PHP."
---
## **Panoramica**

PowerPoint memorizza le equazioni come Office Math Markup Language (OMML). Con Aspose.Slides per PHP tramite Java, è possibile creare lo stesso tipo di contenuto matematico programmaticamente: frazioni, radici, funzioni, limiti, operatori N‑ari, matrici, array e blocchi matematici formattati.

In PowerPoint, gli utenti aggiungono normalmente le equazioni da **Insert > Equation**:

![Scheda Inserisci di PowerPoint con il comando Equazione selezionato](powerpoint-math-equations_1.png)

Il risultato è del testo matematico modificabile nella diapositiva:

![Una diapositiva PowerPoint contenente un'equazione matematica modificabile](powerpoint-math-equations_2.png)

Aspose.Slides costruisce quel testo matematico attraverso tre oggetti principali:

- Una forma matematica, creata con [addMathShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/#addMathShape), è la forma che contiene l'equazione.
- [MathPortion](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathportion/) memorizza il contenuto matematico all'interno del riquadro di testo della forma.
- [MathParagraph](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathparagraph/) contiene uno o più oggetti [MathBlock](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathblock/).

Per la maggior parte degli esempi seguenti vengono usati [MathematicalText](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathematicaltext/) e i metodi fluenti di [MathElementBase](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) per mantenere il codice breve e leggibile.

Per scenari di esportazione MathML, vedere [Esporta equazioni matematiche dalle presentazioni in PHP via Java](/slides/it/php-java/exporting-math-equations/).

## **Crea un'equazione**

Questo esempio crea una forma matematica e aggiunge il teorema di Pitagora:

![L'equazione c al quadrato uguale a a al quadrato più b al quadrato](powerpoint-math-equations_3.png)

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
`addMathShape` crea una forma che contiene già un paragrafo matematico. Accedi al primo `MathPortion`, ottieni il suo `MathParagraph` e aggiungi blocchi matematici o elementi matematici.
{{% /alert %}}

## **Aggiungi frazioni**

Usa [`divide`](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) per creare una frazione. Puoi scegliere uno stile di frazione con [MathFractionTypes](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathfractiontypes/).

![Una frazione matematica inclinata che mostra 1 diviso x](powerpoint-math-equations_4.png)

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

Per una frazione impilata, usa `MathFractionTypes::Bar`:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Aggiungi radici**

Usa [`radical`](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) per creare una radice quadrata, cubica o altra radice. L'elemento corrente diventa la base e l'argomento diventa il grado.

![Un'espressione radice n‑esima con x sotto il segno di radice](powerpoint-math-equations_5.png)

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

## **Aggiungi funzioni e limiti**

Usa [`asArgumentOfFunction`](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) o [`function`](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) per funzioni come `sin(x)`, `log(x)` o nomi di funzioni personalizzate. Per i limiti, inserisci `lim` in un [MathLimit](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathlimit/) o usa [`setLowerLimit`](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/).

![Il limite di x quando x tende all'infinito](powerpoint-math-equations_8.png)

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

Per un nome di funzione personalizzato, rendi il nome della funzione l'elemento corrente:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Aggiungi operatori N‑ari e integrali**

Usa [`nary`](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) per sommatorie, unioni, intersezioni e altri grandi operatori. Usa [`integral`](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) per gli integrali. Entrambi i metodi consentono di impostare limiti inferiori e superiori.

![Una sommatoria con limiti inferiori e superiori](powerpoint-math-equations_7.png)

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

Gli operatori N‑ari sono per grandi operatori con limiti opzionali. Operatori semplici come `+`, `-` e `=` vengono solitamente aggiunti come `MathematicalText` e uniti all'espressione.

Per un integrale, usa `integral`:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Aggiungi matrici**

Usa [MathMatrix](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathmatrix/) per righe e colonne. Le matrici non includono parentes di default, quindi racchiudi la matrice quando ti servono parentesi tonde, quadre o graffe.

![Una matrice matematica a due righe con una cella vuota](powerpoint-math-equations_10.png)

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

## **Aggiungi array di equazioni**

Usa [`toMathArray`](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) quando ti servono equazioni allineate o una pila verticale di espressioni.

![Un array matematico verticale con x sopra y](powerpoint-math-equations_11.png)

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

## **Aggiungi funzioni trigonometriche**

Usa [`asArgumentOfFunction`](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) quando l'argomento è l'elemento corrente e il nome della funzione è noto.

![La funzione trigonometrica cos applicata a 2x](powerpoint-math-equations_6.png)

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

## **Aggiungi pedici e apici**

Usa gli helper per pedici e apici per indici e potenze. Quando gli indici devono apparire a sinistra della base, usa [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/).

![Una Y maiuscola con pedice sinistro 1 e apice n](powerpoint-math-equations_9.png)

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

## **Aggiungi delimitatori**

Usa [`enclose`](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) per racchiudere un'espressione tra delimitatori. Puoi anche impostare un carattere separatore per espressioni delimitate che contengono diversi elementi.

![Un'espressione delimitata contenente x, y e z separati da barre verticali](powerpoint-math-equations_13.png)

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

## **Aggiungi una scatola bordata**

Usa [`toBorderBox`](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) quando l'equazione stessa deve essere incorniciata.

![Un'equazione incorniciata che mostra c al quadrato uguale a b al quadrato più c al quadrato](powerpoint-math-equations_12.png)

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

## **Raggruppa termini**

Usa [`group`](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) per posizionare un carattere di raggruppamento sopra o sotto un'espressione. Aggiungi un limite per etichettare i termini raggruppati.

![L'espressione x più y raggruppata con l'etichetta testo qualsiasi sotto di essa](powerpoint-math-equations_15.png)

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

## **Formato degli elementi matematici**

Usa gli helper di formattazione solo dove chiariscono la formula. Per esempio, [`overbar`](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) posiziona una barra sopra un elemento matematico.

![Un'espressione matematica ABC con una barra sopra](powerpoint-math-equations_14.png)

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

## **Riferimento rapido**

| Attività | API principale |
| --- | --- |
| Crea testo matematico | [MathematicalText](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathematicaltext/) |
| Combina elementi | [join](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) |
| Crea frazioni | [divide](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) |
| Aggiungi apice o pedice | [setSuperscript](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) |
| Aggiungi funzioni | [function](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) |
| Aggiungi radici | [radical](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) |
| Aggiungi limiti | [setLowerLimit](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) |
| Aggiungi script a sinistra | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) |
| Aggiungi sommatorie e integrali | [nary](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) |
| Aggiungi matrici | [MathMatrix](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathmatrix/) |
| Aggiungi array di equazioni | [toMathArray](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) |
| Aggiungi delimitatori | [enclose](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) |
| Aggiungi barre e bordi | [overbar](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) |
| Raggruppa termini | [group](https://reference.aspose.com/slides/it/php-java/aspose.slides/mathelementbase/) |

## **FAQ**

**Posso modificare un'equazione PowerPoint esistente?**

Sì. Apri la presentazione, individua la forma che contiene un `MathPortion`, ottieni il suo `MathParagraph` e aggiorna i blocchi matematici in quel paragrafo.

**Le equazioni vengono salvate come matematica PowerPoint modificabile?**

Sì. Quando salvi in PPTX, Aspose.Slides scrive l'equazione come contenuto di Office Math modificabile.

**Posso esportare le equazioni in LaTeX?**

Aspose.Slides esporta le equazioni matematiche in MathML. Se hai bisogno di LaTeX, esporta prima in MathML e poi converti il MathML con uno strumento che supporti il dialetto LaTeX desiderato.