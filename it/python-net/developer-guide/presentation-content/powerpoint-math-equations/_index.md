---
title: Aggiungi Equazioni Matematiche a Presentazioni PowerPoint in Python
linktitle: Equazioni Matematiche PowerPoint
type: docs
weight: 80
url: /it/python-net/powerpoint-math-equations/
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
- Python
- Aspose.Slides
description: "Inserisci e modifica equazioni matematiche in PowerPoint PPT e PPTX con Aspose.Slides per Python via .NET, supportando OMML, controlli di formattazione e chiari esempi di codice Python."
---
## **Panoramica**

PowerPoint archivia le equazioni come Office Math Markup Language (OMML). Con Aspose.Slides per Python tramite .NET, è possibile creare lo stesso tipo di contenuto matematico in modo programmatico: frazioni, radici, funzioni, limiti, operatori N-ario, matrici, array e blocchi matematici formattati.

In PowerPoint, gli utenti aggiungono normalmente le equazioni da **Inserisci > Equazione**:

![Scheda Inserisci di PowerPoint con il comando Equazione selezionato](powerpoint-math-equations_1.png)

Il risultato è testo matematico modificabile sulla diapositiva:

![Una diapositiva PowerPoint contenente un'equazione matematica modificabile](powerpoint-math-equations_2.png)

Aspose.Slides costruisce quel testo matematico attraverso tre oggetti principali:

- Una forma matematica, creata con [add_math_shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/add_math_shape/), è la forma che contiene l'equazione.
- [MathPortion](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathportion/) memorizza il contenuto matematico all'interno del frame di testo della forma.
- [MathParagraph](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathparagraph/) contiene uno o più oggetti [MathBlock](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathblock/).

La maggior parte degli esempi seguenti utilizza [MathematicalText](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathematicaltext/) e i metodi fluenti di [IMathElement](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/) per mantenere il codice breve e leggibile.

Per gli scenari di esportazione MathML, vedi [Esporta Equazioni Matematiche dalle Presentazioni in Python tramite .NET](/slides/it/python-net/exporting-math-equations/).

## **Crea un'equazione**

Questo esempio crea una forma matematica e aggiunge il teorema di Pitagora:

![L'equazione c al quadrato uguale a a al quadrato più b al quadrato](powerpoint-math-equations_3.png)

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
`add_math_shape` crea una forma che contiene già un paragrafo matematico. Accedi al primo `MathPortion`, ottieni il suo `MathParagraph` e aggiungi blocchi matematici o elementi matematici.
{{% /alert %}}

## **Aggiungi Frazioni**

Utilizza [`divide`](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/divide/) per creare una frazione. È possibile scegliere uno stile di frazione con [MathFractionTypes](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Una frazione matematica inclinata che mostra uno diviso x](powerpoint-math-equations_4.png)

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

Per una frazione impilata, utilizza `MathFractionTypes.BAR`:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Aggiungi Radicali**

Utilizza [`radical`](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/radical/) per creare una radice quadrata, cubica o di altro tipo. L'elemento corrente diventa la base e l'argomento diventa il grado.

![Un'espressione radicale di n-esima radice con x sotto il segno della radice](powerpoint-math-equations_5.png)

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

## **Aggiungi Funzioni e Limiti**

Utilizza [`as_argument_of_function`](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) o [`function`](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/function/) per funzioni come `sin(x)`, `log(x)` o nomi di funzione personalizzati. Per i limiti, inserisci `lim` in un [MathLimit](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathlimit/) o utilizza [`set_lower_limit`](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![Il limite di x quando x tende a infinito](powerpoint-math-equations_8.png)

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

Per un nome di funzione personalizzato, rendi il nome della funzione l'elemento corrente:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **Aggiungi Operatori N-ari e Integrali**

Utilizza [`nary`](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/nary/) per sommatorie, unioni, intersezioni e altri operatori di grandi dimensioni. Utilizza [`integral`](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/integral/) per gli integrali. Entrambi i metodi consentono di impostare i limiti inferiore e superiore.

![Una sommatoria con limiti inferiore e superiore](powerpoint-math-equations_7.png)

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

Gli operatori N-ari sono per operatori di grandi dimensioni con limiti opzionali. Gli operatori semplici come `+`, `-` e `=` sono solitamente aggiunti come `MathematicalText` e uniti all'espressione.

Per un integrale, utilizza `integral`:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Aggiungi Matrici**

Utilizza [MathMatrix](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathmatrix/) per righe e colonne. Le matrici non includono parentesi graffe per impostazione predefinita, quindi racchiudi la matrice quando hai bisogno di parentesi tonde, quadre o graffe.

![Una matrice matematica a due righe con una cella vuota](powerpoint-math-equations_10.png)

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

## **Aggiungi Array di Equazioni**

Utilizza [`to_math_array`](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/to_math_array/) quando ti servono equazioni allineate o una pila verticale di espressioni.

![Un array matematico verticale con x sopra y](powerpoint-math-equations_11.png)

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

## **Aggiungi Funzioni Trigonometriche**

Utilizza [`as_argument_of_function`](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) quando l'argomento è l'elemento corrente e il nome della funzione è noto.

![La funzione trigonometrica cos applicata a 2x](powerpoint-math-equations_6.png)

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

## **Aggiungi Pedici e Apici**

Usa gli assistenti per pedici e apici per indici e potenze. Quando gli indici devono apparire sul lato sinistro della base, utilizza [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Una Y maiuscola con pedice 1 a sinistra e apice n](powerpoint-math-equations_9.png)

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

## **Aggiungi Delimitatori**

Utilizza [`enclose`](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/enclose/) per inserire un'espressione all'interno di delimitatori. È inoltre possibile impostare un carattere separatore per espressioni delimitate che contengono più elementi.

![Un'espressione delimitata contenente x, y e z separati da barre verticali](powerpoint-math-equations_13.png)

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

## **Aggiungi un Riquadro con Bordo**

Utilizza [`to_border_box`](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/to_border_box/) quando l'equazione stessa dovrebbe essere incorniciata.

![Un'equazione in riquadro che mostra a al quadrato uguale a b al quadrato più c al quadrato](powerpoint-math-equations_12.png)

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

## **Raggruppa Termini**

Utilizza [`group`](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/group/) per posizionare un carattere di raggruppamento sopra o sotto un'espressione. Aggiungi un limite per etichettare i termini raggruppati.

![L'espressione x più y raggruppata con l'etichetta qualsiasi testo sotto di essa](powerpoint-math-equations_15.png)

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

## **Formatta Elementi Matematici**

Utilizza gli assistenti di formattazione solo dove chiariscono la formula. Per esempio, [`overbar`](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/overbar/) posiziona una barra sopra un elemento matematico.

![Un'espressione matematica ABC con una barra sopra](powerpoint-math-equations_14.png)

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

## **Riferimento Rapido**

| Attività | API Principale |
| --- | --- |
| Crea testo matematico | [MathematicalText](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Combina elementi | [IMathElement.join](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/join/) |
| Crea frazioni | [IMathElement.divide](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Aggiungi apice o pedice | [set_superscript](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Aggiungi funzioni | [function](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Aggiungi radicali | [radical](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Aggiungi limiti | [set_lower_limit](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Aggiungi script a sinistra | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Aggiungi sommatorie e integrali | [nary](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Aggiungi matrici | [MathMatrix](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/mathmatrix/) |
| Aggiungi array di equazioni | [to_math_array](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Aggiungi delimitatori | [enclose](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Aggiungi barre e bordi | [overbar](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Raggruppa termini | [group](https://reference.aspose.com/slides/it/python-net/aspose.slides.mathtext/imathelement/group/) |

## **Domande frequenti**

**Posso modificare un'equazione PowerPoint esistente?**

Sì. Apri la presentazione, trova la forma che contiene un `MathPortion`, ottieni il suo `MathParagraph` e aggiorna i blocchi matematici in quel paragrafo.

**Le equazioni vengono salvate come matematica PowerPoint modificabile?**

Sì. Quando salvi in PPTX, Aspose.Slides scrive l'equazione come contenuto matematico Office modificabile.

**Posso esportare le equazioni in LaTeX?**

Aspose.Slides esporta le equazioni matematiche in MathML. Se hai bisogno di LaTeX, esporta prima in MathML e poi convertilo in LaTeX con uno strumento che supporta il dialetto LaTeX desiderato.