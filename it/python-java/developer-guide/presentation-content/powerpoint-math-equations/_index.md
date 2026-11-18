---
title: Aggiungi equazioni matematiche alle presentazioni PowerPoint in Python
linktitle: Equazioni matematiche PowerPoint
type: docs
weight: 80
url: /it/python-java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "Inserisci e modifica equazioni matematiche in PowerPoint PPT e PPTX con Aspose.Slides per Python tramite Java, supportando OMML, controlli di formattazione e chiari esempi di codice Python."
---
## **Panoramica**

PowerPoint memorizza le equazioni come Office Math Markup Language (OMML). Con Aspose.Slides per Python tramite Java, è possibile creare lo stesso tipo di contenuto matematico in modo programmatico: frazioni, radicali, funzioni, limiti, operatori N-ari, matrici, array e blocchi matematici formattati.

In PowerPoint, gli utenti normalmente aggiungono equazioni da **Insert > Equation**:

![Scheda Inserisci di PowerPoint con il comando Equazione selezionato](powerpoint-math-equations_1.png)

Il risultato è del testo matematico modificabile nella diapositiva:

![Una diapositiva PowerPoint contenente un'equazione matematica modificabile](powerpoint-math-equations_2.png)

Aspose.Slides costruisce quel testo matematico attraverso tre oggetti principali:

- Una forma matematica, creata con [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape), è la forma che contiene l'equazione.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) memorizza il contenuto matematico all'interno del riquadro di testo della forma.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) contiene uno o più oggetti [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/).

La maggior parte degli esempi sotto usa [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) e i metodi fluenti di [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) per mantenere il codice breve e leggibile.

Per scenari di esportazione MathML, vedere [Export Math Equations from Presentations in Python](/slides/it/python-java/exporting-math-equations/).

## **Creare un'equazione**

Questo esempio utilizza [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) per creare una forma matematica e aggiunge il teorema di Pitagora:

![L'equazione c al quadrato uguale a a al quadrato più b al quadrato](powerpoint-math-equations_3.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    equation = MathematicalText("c").setSuperscript("2").join("=").join(a_squared).join("+").join(b_squared)

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) crea una forma che contiene già un paragrafo matematico. Accedi al primo [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), chiama [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) e aggiungi blocchi matematici o elementi matematici ad esso.
{{% /alert %}}

## **Aggiungere frazioni**

Usa [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) per creare una frazione. Puoi scegliere uno stile di frazione con [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/).

![Una frazione matematica inclinata che mostra uno diviso per x](powerpoint-math-equations_4.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFractionTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    fraction = MathematicalText("1").divide("x", MathFractionTypes.Skewed)

    math_block = MathBlock(fraction)
    math_paragraph.add(math_block)

    presentation.save("fraction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per una frazione impilata, usa [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **Aggiungere radicali**

Usa [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) per creare una radice quadrata, cubica o altra radice. L'elemento corrente diventa la base e l'argomento il grado.

![Un'espressione radice n-esima con x sotto il segno radicale](powerpoint-math-equations_5.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    radical = MathematicalText("x").radical("n")

    math_block = MathBlock(radical)
    math_paragraph.add(math_block)

    presentation.save("radical.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Mostrare o nascondere il grado di una radice quadrata**

Una radice quadrata può visualizzare un 2 esplicito o usare la notazione convenzionale √x. Il metodo [setHideDegree](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/#setHideDegree) di [MathRadical](https://reference.aspose.com/slides/python-java/aspose.slides/mathradical/) controlla quale forma appare. Entrambe le forme conservano il grado 2 e il radicando x nell'equazione modificabile.

![La stessa radice quadrata con il grado visibile a sinistra e nascosto a destra](square-root-degree.png)

L'esempio salva la stessa radice quadrata due volte. In `visible-degree.pptx`, il 2 è visibile. In `hidden-degree.pptx`, è nascosto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    radical = MathematicalText("x").radical("2")
    math_block = MathBlock(radical)

    math_shape = slide.getShapes().addMathShape(20, 20, 200, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()
    math_paragraph.add(math_block)

    radical.setHideDegree(False)
    presentation.save("visible-degree.pptx", SaveFormat.Pptx)

    radical.setHideDegree(True)
    presentation.save("hidden-degree.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aggiungere funzioni e limiti**

Usa [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) o [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) per funzioni come `sin(x)`, `log(x)` o nomi di funzioni personalizzate. Per i limiti, inserisci `lim` in un [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) o usa [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit).

![Il limite di x quando x tende all'infinito](powerpoint-math-equations_8.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    limit = MathematicalText("lim").setLowerLimit("x\u2192\u221E").function("x")

    math_block = MathBlock(limit)
    math_paragraph.add(math_block)

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per un nome di funzione personalizzato, rendi il nome della funzione l'elemento corrente e chiama [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) con il suo argomento:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **Aggiungere operatori N-ari e integrali**

Usa [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) per sommatorie, unioni, intersezioni e altri grandi operatori. Usa [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) per gli integrali. Entrambi i metodi consentono di impostare limiti inferiori e superiori.

![Una sommatoria con limiti inferiori e superiori](powerpoint-math-equations_7.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathNaryOperatorTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_power = MathematicalText("a").setSuperscript("n-k")
    summation_base = MathematicalText("x").setSuperscript("k").join(a_power)

    summation = summation_base.nary(MathNaryOperatorTypes.Summation, "k=0", "n")

    math_block = MathBlock(summation)
    math_paragraph.add(math_block)

    presentation.save("nary-operators.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Gli operatori N-ari sono per grandi operatori con limiti opzionali. Operatori semplici come `+`, `-` e `=` vengono solitamente aggiunti come [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) e uniti all'espressione.

Per un integrale, usa [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathIntegralTypes, MathematicalText

differential = MathematicalText("dx").toBox()
integral_base = MathematicalText("x").join(differential)
integral = integral_base.integral(MathIntegralTypes.Simple, "0", "1")
```

## **Aggiungere matrici**

Usa [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) per righe e colonne. Le matrici non includono parentesi per impostazione predefinita, quindi racchiudi la matrice quando ti servono parentesi tonde, quadre o graffe.

![Una matrice matematica a due righe con una cella vuota](powerpoint-math-equations_10.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathMatrix, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    matrix = MathMatrix(2, 3)
    cell_0_0 = MathematicalText("1")
    matrix.set_Item(0, 0, cell_0_0)
    cell_0_1 = MathematicalText("x")
    matrix.set_Item(0, 1, cell_0_1)
    cell_1_0 = MathematicalText("x")
    matrix.set_Item(1, 0, cell_1_0)
    cell_1_1 = MathematicalText("2")
    matrix.set_Item(1, 1, cell_1_1)
    cell_1_2 = MathematicalText("y")
    matrix.set_Item(1, 2, cell_1_2)

    math_block = MathBlock(matrix)
    math_paragraph.add(math_block)

    presentation.save("matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Modificare una matrice esistente**

Supponiamo che una lezione di algebra lineare inizi con la matrice dei coefficienti in `matrix.pptx`, salvata dall'esempio precedente. Per il prossimo esercizio, mantieni la prima equazione, sostituisci la seconda con due nuove equazioni e revisiona l'insieme di variabili. Apri la matrice esistente tramite [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) per conservare i coefficienti ancora validi.

![Matrice di coefficiente a due righe originale con voci 1, x e una cella vuota nella prima riga e x, 2 e y nella seconda](matrix-before-edit.png)

Gli indici di righe e colonne partono da zero e fanno riferimento alla matrice così com'è in ogni chiamata. Inserire una riga prima dell'indice 1 sposta la riga originale seconda all'indice 2. Inserire dopo l'indice 2 aggiunge una riga. Eliminare la riga 2 rimuove l'equazione originale seconda e sposta la riga aggiunta su di una posizione. Le colonne si spostano allo stesso modo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathHorizontalAlignment, MathematicalText, Presentation, SaveFormat

presentation = Presentation("matrix.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    matrix = portion.getMathParagraph().get_Item(0).get_Item(0)

    matrix.insertRowBefore(1)
    matrix.insertRowAfter(2)
    matrix.deleteRow(2)

    matrix.insertColumnBefore(1)
    matrix.insertColumnAfter(3)
    matrix.deleteColumn(3)

    # Nuove celle sono inizialmente vuote. Imposta prima i coefficienti diversi da zero.
    matrix.set_Item(1, 0, MathematicalText("12"))
    matrix.set_Item(1, 1, MathematicalText("1"))
    matrix.set_Item(2, 2, MathematicalText("10"))
    matrix.set_Item(2, 3, MathematicalText("1"))
    for row in range(matrix.getRowCount()):
        for column in range(matrix.getColumnCount()):
            if matrix.get_Item(row, column) is None:
                matrix.set_Item(row, column, MathematicalText("0"))

    matrix.setColumnAlignment(0, MathHorizontalAlignment.Left)
    matrix.setColumnsAlignment(1, 3, MathHorizontalAlignment.Right)
    
    presentation.save("updated-matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[setColumnAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnAlignment) allinea la prima colonna a sinistra. [setColumnsAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/#setColumnsAlignment) allinea le tre colonne rimanenti a destra, a partire dall'indice 1. In `updated-matrix.pptx`, la matrice ha tre equazioni e quattro variabili. I coefficienti originali della prima riga `1` e `x` ora appaiono nella prima e nella terza colonna.

![Matrice aggiornata a tre righe che mostra le righe 1, 0, x, 0; 12, 1, 0, 0; e 0, 0, 10, 1](matrix-after-edit.png)

## **Aggiungere array di equazioni**

Usa [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) quando ti servono equazioni allineate o uno stack verticale di espressioni.

![Un array matematico verticale con x sopra y](powerpoint-math-equations_11.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 140)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    equation_array = MathematicalText("x").join("y").toMathArray()

    math_block = MathBlock(equation_array)
    math_paragraph.add(math_block)

    presentation.save("equation-array.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Allineare un array con gli elementi circostanti**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) controlla l'allineamento verticale di un array rispetto agli elementi matematici a fianco. L'esempio sotto confronta l'allineamento con la prima riga, il centro dell'array e l'ultima riga.

L'esempio seguente crea tre array identici, ognuno con tre righe e gli elementi vicini `A=` e `=B`. Tutto il testo matematico usa Cambria Math a 24 pt. Solo l'allineamento dell'array varia.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathVerticalAlignment, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)
    
    alignments = (("Top", MathVerticalAlignment.Top), ("Center", MathVerticalAlignment.Center), ("Bottom", MathVerticalAlignment.Bottom))
    for index, (name, alignment) in enumerate(alignments):
        x = 20 + index * 260
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 10, 240, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(16)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        math_shape = slide.getShapes().addMathShape(x, 60, 240, 130)
        math_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(alignment)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il confronto seguente mostra la presentazione salvata in PowerPoint. Nota la posizione di `A=` e `=B` accanto a ciascun array.

![Array di equazioni in PowerPoint con allineamento Superiore, Centrato e Inferiore e elementi vicini identici](equation-array-alignment.png)

### **Configurare la spaziatura delle righe**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) seleziona la regola di spaziatura per le righe all'interno dell'array. [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) fornisce un valore numerico per una regola esplicita e viene ignorato dalle regole predefinite.

Per spaziatura esatta, il valore è misurato in punti. Per spaziatura proporzionale, è misurato in mezze linee: il valore `3` nell'esempio specifica 1,5 linee. Imposta entrambe le proprietà quando specifichi un valore esplicito; cambiare solo il valore numerico non seleziona una regola di spaziatura.

L'esempio sotto salva cinque presentazioni con le stesse equazioni, allineamento e impostazioni di carattere. Le prime tre usano impostazioni predefinite; le ultime due mostrano valori espliciti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathRowSpacingRule, MathVerticalAlignment, Presentation, SaveFormat

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


settings = (("SingleLineGap", MathRowSpacingRule.SingleLineGap, 0), ("OneAndAHalfLineGap", MathRowSpacingRule.OneAndAHalfLineGap, 0), ("TwoLineGap", MathRowSpacingRule.TwoLineGap, 0), ("Exactly", MathRowSpacingRule.Exactly, 20), ("Multiple", MathRowSpacingRule.Multiple, 3))
for name, rule, spacing in settings:
    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        math_shape = slide.getShapes().addMathShape(20, 20, 600, 300)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(MathVerticalAlignment.Center)
        equation_array.setRowSpacingRule(rule)
        equation_array.setRowSpacing(spacing)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

        presentation.save(f"equation-array-{name}.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

La spaziatura delle righe dell'array è separata dalla spaziatura dei paragrafi. [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) e [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) aggiungono spazio intorno al paragrafo contenitore, non tra le righe dell'array. Allo stesso modo, [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) posiziona l'intero paragrafo matematico orizzontalmente; non sostituisce l'impostazione di allineamento verticale dell'array.

## **Aggiungere funzioni trigonometriche**

Usa [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) quando l'argomento è l'elemento corrente e il nome della funzione è noto.

![La funzione trigonometrica cos applicata a 2x](powerpoint-math-equations_6.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFunctionsOfOneArgument, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    cosine = MathematicalText("2x").asArgumentOfFunction(MathFunctionsOfOneArgument.Cos)

    math_block = MathBlock(cosine)
    math_paragraph.add(math_block)

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aggiungere apici e pedici**

Usa gli helper per apici e pedici per indici e potenze. Quando gli indici devono apparire sul lato sinistro della base, usa [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Una Y maiuscola con pedice 1 a sinistra e apice n](powerpoint-math-equations_9.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    scripts = MathematicalText("Y").setSubSuperscriptOnTheLeft("1", "n")

    math_block = MathBlock(scripts)
    math_paragraph.add(math_block)

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aggiungere delimitatori**

Usa [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) per inserire un'espressione all'interno di delimitatori. Puoi anche impostare un carattere separatore per espressioni delimitate che contengono più elementi.

![Un'espressione delimitatore contenente x, y e z separati da barre verticali](powerpoint-math-equations_13.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    delimiter = MathematicalText("x").join("y").join("z").enclose('<', '>')
    delimiter.setSeparatorCharacter('|')

    math_block = MathBlock(delimiter)
    math_paragraph.add(math_block)

    presentation.save("delimiters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Dimensionare e allineare i delimitatori**

Passa `True` a [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) per far crescere le parentesi attorno a un operando alto, o `False` per mantenerle alla dimensione normale. Usa [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) con uno dei valori [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/). `Centered` centra le parentesi sull'asse matematico, che attraversa il centro del segno di uguale. `Match` le allinea al contenuto racchiuso. Entrambe le impostazioni influiscono solo sui delimitatori. L'espressione interna rimane la stessa.

L'esempio inserisce una frazione nell'esponente di `x` così l'espressione si estende più sopra la linea di base di quanto non faccia sotto. Tutte e quattro le equazioni usano le stesse parentesi e impostazioni di carattere.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathDelimiterShape, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    for row, grow in enumerate((True, False)):
        for column, shape in enumerate((MathDelimiterShape.Centered, MathDelimiterShape.Match)):
            fraction = MathematicalText("a + b").divide("c + d")
            power = MathematicalText("x").setSuperscript(fraction)
            delimiter = power.enclose("(", ")")
            delimiter.setGrowToMatchOperandHeight(grow)
            delimiter.setDelimiterShape(shape)

            math_shape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100)
            portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            portion.getPortionFormat().setFontHeight(32)
            equation = MathematicalText("y = ").join(delimiter)
            portion.getMathParagraph().add(equation)

    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In PowerPoint, confronta le righe per vedere l'effetto della crescita. Nella riga superiore, le parentesi crescono per racchiudere l'esponente e sono uguali per entrambe le forme. Nella riga inferiore, la crescita è disattivata. Le parentesi più piccole a sinistra (`Centered`) si allineano al segno di uguale, mentre quelle a destra (`Match`) si posizionano più in alto attorno all'espressione.

![Quattro equazioni in PowerPoint con crescita del delimitatore abilitata sopra e disabilitata sotto, e Centrado a sinistra e Corrispondente a destra](delimiter-sizing.png)

## **Aggiungere una casella con bordi**

Chiama [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) su una frazione per inquadrare l'intera espressione. Il [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) restituito mostra tutti e quattro i lati per impostazione predefinita. Usa [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft) e [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) per rimuovere singoli lati.

L'esempio posiziona sei copie della stessa frazione su una diapositiva. Per mostrare la cancellazione, nascondi tutti e quattro i lati e passa `True` a [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) per una diagonale ascendente (↗) o [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) per una diagonale discendente (↘). È inoltre possibile usare [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) o [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) con qualsiasi combinazione di lati visibili.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    def add_fraction(x, y, hide_border):
        fraction = MathematicalText("x+1").divide("y+2")
        box = fraction.toBorderBox()
        box.setHideTop(hide_border)
        box.setHideBottom(hide_border)
        box.setHideLeft(hide_border)
        box.setHideRight(hide_border)

        shape = slide.getShapes().addMathShape(x, y, 160, 90)
        portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        portion.getPortionFormat().setFontHeight(28)
        math_block = MathBlock(box)
        portion.getMathParagraph().add(math_block)
        return box

    add_fraction(10, 10, False)

    partial = add_fraction(190, 10, False)
    partial.setHideTop(True)
    partial.setHideRight(True)

    add_fraction(370, 10, True).setStrikethroughBottomLeftToTopRight(True)
    add_fraction(10, 120, True).setStrikethroughTopLeftToBottomRight(True)
    add_fraction(190, 120, True).setStrikethroughHorizontal(True)
    add_fraction(370, 120, False).setStrikethroughVertical(True)

    presentation.save("border-box.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Sei frazioni modificabili in PowerPoint. Riga superiore: bordo completo, lati inferiore e sinistro, diagonale ascendente. Riga inferiore: diagonale discendente, barra orizzontale, barra verticale con bordo completo](border-box-fractions.png)

Su questa frazione, la barra orizzontale sovrappone la barra della frazione. La barra verticale attraversa sia il numeratore sia il denominatore mentre il bordo circostante rimane visibile. Queste linee decorano l'intera espressione. Il barrato di testo normale si applica ai caratteri di una run di testo. Dopo aver riaperto la presentazione in PowerPoint, è ancora possibile modificare il numeratore e il denominatore in modo indipendente.

## **Controllare la visibilità e il layout con elementi fantasma**

Avvolgi un'espressione in [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) per controllare la sua visibilità e lo spazio che contribuisce a un'equazione in modo indipendente. I metodi di [MathPhantom](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/) controllano quanto segue:

| Metodo | Effetto |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) | Passa `False` per nascondere l'espressione. Le sue dimensioni contribuiscono ancora al layout a meno che i metodi corrispondenti qui sotto non ricevano `True`. |
| [setZeroWidth](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroWidth) | Tratta la larghezza orizzontale dell'espressione come zero, consentendo agli elementi vicini di avvicinarsi. |
| [setZeroAsc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroAsc) | Tratta l'ascesa, l'altezza sopra la linea di base, come zero. Questo può ridurre lo spazio riservato sopra gli elementi vicini. |
| [setZeroDesc](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setZeroDesc) | Tratta la discesa, la profondità sotto la linea di base, come zero. Questo può avvicinare una barra di frazione o altro contenuto sotto l'espressione ai suoi vicini. |

La linea di base è la linea di riferimento su cui si trovano i normali caratteri matematici. Nascondere il contenuto non ne elimina le dimensioni, e trattare una dimensione come zero non elimina l'espressione. L'espressione sottostante rimane disponibile tramite [getBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#getBase). Passa `True` a [setShow](https://reference.aspose.com/slides/python-java/aspose.slides/mathphantom/#setShow) per visualizzarla nuovamente; le impostazioni di dimensione rimangono invariate.

L'esempio sotto crea cinque varianti affiancate: una frazione visibile, una frazione nascosta che riserva spazio e tre frazioni nascoste con una dimensione trattata come zero. Ogni variante usa la stessa espressione circostante e Cambria Math a 24 pt. Tutte le forme di equazione hanno la stessa posizione superiore, segnata dalla guida grigia. Posizionare il fantasma nel numeratore di una frazione esterna rende più facile vedere le modifiche al layout verticale.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathBlock, MathFraction, MathematicalText, MathPhantom, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color


def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(1000, 180, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    labels = ("Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc")

    guide = slide.getShapes().addAutoShape(ShapeType.Line, 10, 60, 980, 0)
    guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.LIGHT_GRAY)

    for index, name in enumerate(labels):
        left = 10 + index * 200
        
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, left, 10, 190, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(14)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        fraction_numerator = create_text("a+b")
        fraction_denominator = create_text("c+d")
        fraction = MathFraction(fraction_numerator, fraction_denominator)
        phantom = MathPhantom(fraction)
        phantom.setShow(index == 0)
        phantom.setZeroWidth(index == 2)
        phantom.setZeroAsc(index == 3)
        phantom.setZeroDesc(index == 4)

        left_text = create_text("x+")
        right_text = create_text("+y")
        numerator = MathBlock(left_text).join(phantom).join(right_text)
        denominator = create_text("z")
        equation = MathFraction(numerator, denominator)

        shape = slide.getShapes().addMathShape(left, 60, 190, 100)
        shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        math_portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        math_paragraph = math_portion.getMathParagraph()
        math_block = MathBlock(equation)
        math_paragraph.add(math_block)

    presentation.save("math-phantom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Cinque equazioni in PowerPoint confrontano una frazione visibile, una frazione nascosta che riserva spazio e frazioni nascoste con ZeroWidth, ZeroAsc o ZeroDesc attivati](math-phantom.png)

## **Raggruppare termini**

Usa [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) per posizionare un carattere di raggruppamento sopra o sotto un'espressione. Aggiungi un limite per etichettare i termini raggruppati.

![L'espressione x più y raggruppata con l'etichetta qualsiasi testo sotto di essa](powerpoint-math-equations_15.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathTopBotPositions, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    grouped = MathematicalText("x + y").group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top).setLowerLimit("any text")

    math_block = MathBlock(grouped)
    math_paragraph.add(math_block)

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Formattare gli elementi matematici**

Usa gli helper di formattazione solo dove chiariscono la formula. Per esempio, [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) posiziona una barra sopra un elemento matematico.

![Un'espressione matematica ABC con una barra sopra](powerpoint-math-equations_14.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    overbar = MathematicalText("ABC").overbar()

    math_block = MathBlock(overbar)
    math_paragraph.add(math_block)

    presentation.save("overbar.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Formattare il testo in un'equazione esistente**

Per formattare il testo in un'equazione esistente, attraversa l'albero degli elementi di ciascun blocco matematico. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) restituisce solo i figli immediati, quindi chiamalo ricorsivamente per raggiungere il testo all'interno di frazioni, script, radicali e altre strutture nidificate. Controlla l'elemento corrente così come i suoi figli per includere l'elemento di partenza quando è [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/).

Questo esempio presuppone che `input.pptx` contenga un'equazione come `z = xᵢ / ∛y`, con una frazione contenente un pedice nel numeratore e un radicale nel denominatore. Elaborare solo gli elementi di livello superiore del blocco mancherebbe il testo dentro la frazione. L'esempio trova le porzioni matematiche nei riquadri di testo delle diapositive, accede ai loro blocchi tramite [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) e usa [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) per impostare l'altezza del carattere a 28 pt attraverso il metodo [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat) di ciascun elemento di testo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathematicalText, MathPortion, Presentation, SaveFormat


def format_math_text(element):
    if isinstance(element, MathematicalText):
        element.getFormat().setFontHeight(28)

    for child in element.getChildren():
        format_math_text(child)


presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    if isinstance(portion, MathPortion):
                        for block in portion.getMathParagraph():
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La presentazione salvata contiene la formattazione del testo aggiornata a ogni livello di ciascuna equazione elaborata, mantenendo intatti contenuto testuale e struttura matematica.

## **Riferimento rapido**

| Attività | API principale |
| --- | --- |
| Creare testo matematico | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| Combinare elementi | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| Creare frazioni | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| Aggiungere apice o pedice | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| Aggiungere funzioni | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| Aggiungere radicali | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| Aggiungere limiti | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| Aggiungere script sul lato sinistro | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| Aggiungere sommatorie e integrali | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| Aggiungere matrici | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| Aggiungere array di equazioni | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| Aggiungere delimitatori | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| Aggiungere barre e bordi | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| Raggruppare termini | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **Domande frequenti**

**Posso modificare un'equazione PowerPoint esistente?**

Sì. Apri la presentazione, trova la forma che contiene un [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), chiama [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph) e aggiorna i blocchi matematici in quel paragrafo.

**Le equazioni vengono salvate come math modificabile di PowerPoint?**

Sì. Quando salvi in PPTX, Aspose.Slides scrive l'equazione come contenuto Office math modificabile.

**Posso esportare le equazioni in LaTeX?**

Sì. Ottieni il [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) dell'equazione dal suo [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) e chiama [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) per esportarlo direttamente. Per un esempio completo, vedi [Export Math Equations from Presentations in Python](/slides/it/python-java/exporting-math-equations/#export-math-equations-to-latex).