---
title: Formattazione del Testo della Presentazione in Python via Java
linktitle: Formattazione del Testo
type: docs
weight: 50
url: /it/python-java/text-formatting/
keywords:
- allineare paragrafo
- stile del testo
- sfondo del testo
- trasparenza del testo
- spaziatura dei caratteri
- proprietà del carattere
- famiglia del carattere
- rotazione del testo
- angolo di rotazione
- riquadro di testo
- interlinea
- proprietà di adattamento automatico
- ancora del riquadro di testo
- tabulazione del testo
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Python
- Java
- Aspose.Slides
description: "Formatta e stila il testo in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Python via Java. Personalizza caratteri, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo nelle presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Python via Java. Copre i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà dei caratteri, la rotazione, la spaziatura dei paragrafi, il comportamento di adattamento automatico, l'ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Salvo indicazione contraria, gli esempi utilizzano [sample.pptx](sample.pptx). La prima forma nella sua prima diapositiva è una casella di testo e il suo primo paragrafo contiene il testo mostrato di seguito. Sia gli indici delle diapositive sia quelli delle forme partono da zero. Gli esempi che selezionano porzioni in grassetto usano la formattazione effettiva, includendo la formattazione in grassetto ereditata:

![Testo di esempio](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze di espressioni regolari, vedi [Cerca e Sostituisci Testo](/slides/it/python-java/search-and-replace-text/).

## **Imposta il Colore di Sfondo del Testo**

Usa [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) per impostare il colore di evidenziazione predefinito per un paragrafo, oppure utilizzare [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#getHighlightColor) per singole porzioni di testo.

Il seguente esempio imposta un'evidenziazione grigio chiaro come predefinita per il primo paragrafo. I colori di evidenziazione espliciti sulle singole porzioni hanno la precedenza su questo valore predefinito:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Imposta il colore di evidenziazione per l'intero paragrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Il paragrafo grigio](gray_paragraph.png)

Il seguente esempio di codice dimostra come impostare il colore di sfondo per **porzioni di testo con carattere in grassetto**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Imposta il colore di evidenziazione per la porzione di testo.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Le porzioni di testo grigie](gray_text_portions.png)

## **Allinea i Paragrafi di Testo**

Usa [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setAlignment) per impostare l'allineamento del paragrafo all'interno di un riquadro di testo. Il valore può essere centrato, allineato a sinistra, allineato a destra, giustificato, ecc.

Il seguente esempio di codice mostra come allineare il paragrafo al **centro**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Imposta l'allineamento del paragrafo al centro.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Il paragrafo allineato](aligned_paragraph.png)

## **Imposta la Trasparenza del Testo**

La trasparenza del testo è controllata tramite la componente alfa del colore assegnato a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#getFillFormat). Nelle seguenti esemplificazioni, `alpha = 50` è un valore alfa ARGB su scala 0‑255, non una percentuale di trasparenza.

Il seguente esempio di codice mostra come applicare la trasparenza all'**intero paragrafo**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Imposta il colore di riempimento del testo su colore trasparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Il paragrafo trasparente](transparent_paragraph.png)

Il seguente esempio di codice mostra come applicare la trasparenza a **porzioni di testo con carattere in grassetto**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Imposta la trasparenza della porzione di testo.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Le porzioni di testo trasparenti](transparent_text_portions.png)

## **Imposta la Spaziatura dei Caratteri per il Testo**

Usa [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setSpacing) per espandere o comprimere la spaziatura tra i caratteri in una casella di testo. Gli esempi aggiungono 3 punti di spaziatura; valori negativi comprimono il testo.

Il seguente codice Python mostra come espandere la spaziatura dei caratteri nell'**intero paragrafo**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Nota: usa valori negativi per comprimere la spaziatura dei caratteri.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Espandi la spaziatura dei caratteri.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La spaziatura dei caratteri nel paragrafo](character_spacing_in_paragraph.png)

Il seguente esempio di codice mostra come espandere la spaziatura dei caratteri in **porzioni di testo con carattere in grassetto**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Nota: usa valori negativi per comprimere la spaziatura dei caratteri.
            portion.getPortionFormat().setSpacing(3) # Espandi la spaziatura dei caratteri.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La spaziatura dei caratteri nelle porzioni di testo](character_spacing_in_text_portions.png)

### **Disabilita il Kerning per Font Specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Ciò può accadere perché PowerPoint potrebbe ignorare i dati di kerning per alcuni font, anche quando il font contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per avvicinare l'output renderizzato a PowerPoint in tali casi, è possibile disabilitare il kerning per le porzioni di testo che usano il font interessato. Imposta [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) a un valore superiore alla dimensione effettiva del font. Questo esempio richiede "presentation.pptx" con una casella di testo come prima forma nella prima diapositiva. Controlla i nomi dei font effettivi, includendo i font ereditati, e imposta una soglia di 100 punti per le porzioni che usano Roboto. Questo disabilita il kerning per le porzioni corrispondenti con una dimensione del font inferiore a 100 punti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per il testo corrispondente al di sotto della soglia, questa impostazione previene il kerning e può aiutare ad allineare il rendering di Aspose.Slides all'output visivo di PowerPoint per i font influenzati da questo comportamento specifico di PowerPoint.

## **Gestisci le Proprietà dei Caratteri del Testo**

Le proprietà dei caratteri possono essere impostate a livello di paragrafo tramite [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) o su singole porzioni tramite [PortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/).

Il seguente esempio imposta il font predefinito del primo paragrafo a Times New Roman 12 punti con formattazione in grassetto, corsivo e sottolineatura puntinata. La formattazione esplicita sulle singole porzioni ha la precedenza su questi valori predefiniti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Imposta le proprietà del carattere per il paragrafo.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Le proprietà del carattere per il paragrafo](font_properties_for_paragraph.png)

Il seguente esempio applica Times New Roman 13 punti, formattazione corsiva e una sottolineatura puntinata alle porzioni la cui formattazione effettiva è in grassetto:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Imposta le proprietà del carattere per la porzione di testo.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Le proprietà del carattere per le porzioni di testo](font_properties_for_text_portions.png)

## **Imposta la Rotazione del Testo**

Usa [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setTextVerticalType) per impostare un orientamento predefinito del testo all'interno di una forma.

Il seguente esempio di codice imposta l'orientamento del testo nella forma su [TextVerticalType.Vertical270](https://reference.aspose.com/slides/it/python-java/aspose.slides/textverticaltype/), che ruota il testo **90 gradi in senso antiorario**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La rotazione del testo](text_rotation.png)

## **Imposta Rotazione Personalizzata per i Riquadri di Testo**

Usa [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setRotationAngle) per impostare un angolo di rotazione personalizzato per un [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/).

Il seguente esempio di codice ruota il riquadro di testo di 3 gradi in senso orario all'interno della forma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La rotazione personalizzata del testo](custom_text_rotation.png)

## **Imposta l'Interlinea dei Paragrafi**

Aspose.Slides fornisce [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setSpaceBefore) e [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setSpaceWithin) per controllare la spaziatura dei paragrafi. Queste proprietà si usano come segue:

* Usa un valore positivo per specificare l'interlinea come percentuale dell'altezza della linea.  
* Usa un valore negativo per specificare l'interlinea in punti.

Il seguente esempio imposta la spaziatura all'interno del primo paragrafo al 200 % dell'altezza della linea (doppia interlinea):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![L'interlinea all'interno del paragrafo](line_spacing.png)

## **Controlla l'Interruzione di Linea**

Le regole di interruzione di linea dei paragrafi sono utili in blocchi di testo stretti e in presentazioni che mescolano testo latino e dell'Est asiatico. I seguenti metodi appartengono a [ParagraphFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/), quindi si applicano all'intero paragrafo:

- [setLatinLineBreak](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) controlla le regole di interruzione di linea per il latino. In testo misto, modificarlo può anche cambiare dove avviene l'avvolgimento del testo e della punteggiatura dell'Est asiatico adiacente.  
- [setEastAsianLineBreak](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) controlla le regole di interruzione di linea per l'Est asiatico, includendo restrizioni sui caratteri all'inizio e alla fine di una linea.

Queste regole non sostituiscono [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setWrapText), che abilita l'avvolgimento automatico all'interno di un riquadro di testo. Esse influenzano il layout quando avviene l'avvolgimento; non inseriscono caratteri di interruzione di linea. Un'interruzione di linea esplicita forza una nuova linea all'interno del paragrafo indipendentemente dalla larghezza disponibile.

Il seguente esempio autonomo crea un blocco di testo stretto contenente cinese e latino. Imposta esplicitamente entrambe le opzioni di interruzione di linea e salva "line_breaking.pptx". Per sperimentare con una delle regole, cambia il valore corrispondente mantenendo l'altro impostato. L'esempio usa Arial 24 pt e SimSun con una larghezza del riquadro di 160 pt e margini orizzontali del riquadro a zero. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setAutofitType) è chiamato con [TextAutofitType.None_](https://reference.aspose.com/slides/it/python-java/aspose.slides/textautofittype/) affinché la dimensione del testo e le dimensioni del riquadro rimangano fisse:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Controlla la Punteggiatura Sospesa**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) consente alla punteggiatura ammissibile di estendersi oltre il bordo destro della linea di testo invece di occupare la linea successiva. Si applica all'intero paragrafo ed è diverso da un rientro sospeso.

Il seguente esempio autonomo abilita la punteggiatura sospesa in un riquadro di testo largo 100 pt e salva "hanging_punctuation.pptx". Con Arial 24 pt e margini orizzontali del riquadro a zero, il punto finale resta dopo "sentence" ed è oltre il bordo destro del testo. Imposta la proprietà su [NullableBool.False_](https://reference.aspose.com/slides/it/python-java/aspose.slides/nullablebool/) per confrontare: con queste impostazioni, il punto occupa una linea separata. L'avvolgimento è abilitato e l'adattamento automatico è disabilitato per mantenere la larghezza disponibile fissa:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Non tutte le marche di punteggiatura possono sospendersi. Il risultato visibile dipende dalla disponibilità dei font e dal layout: modificare il font, la larghezza disponibile, i margini o le impostazioni di adattamento automatico può rimuovere la differenza visibile.

## **Imposta il Tipo di Adattamento Automatico per i Riquadri di Testo**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setAutofitType) determina come il testo si comporta quando supera i confini del contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma. Il seguente esempio configura la forma per ridimensionarsi in base al testo e salva il risultato in "autofit_type.pptx".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per contare le linee dopo l'avvolgimento automatico e vedere come la dimensione del testo o della forma influisce sul risultato, vedi [Count Rendered Lines](/slides/it/python-java/manage-paragraph/). Il conteggio delle linee da solo non indica se il testo trabocca dal contenitore.

## **Imposta l'Ancora dei Riquadri di Testo**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setAnchoringType) definisce come il testo è posizionato verticalmente all'interno di una forma, ad esempio in alto, al centro o in basso. Il seguente esempio ancora il testo nella parte inferiore della prima forma e salva il risultato in "text_anchor.pptx".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta la Tabulazione del Testo**

Usa [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) e [ParagraphFormat.getTabs](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#getTabs) per configurare le tabulazioni in un paragrafo. Il seguente esempio imposta l'intervallo di tabulazione predefinito a 100 punti e aggiunge una tabulazione allineata a sinistra a 30 punti. Queste impostazioni influenzano il testo contenente caratteri di tabulazione.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Le tabulazioni del paragrafo](paragraph_tabs.png)

## **Imposta la Lingua di Revisione**

Aspose.Slides fornisce [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#setLanguageId), che consente di impostare la lingua di revisione per una porzione di testo. La lingua di revisione determina la lingua usata per il controllo ortografico e grammaticale in PowerPoint.

Il seguente esempio richiede "presentation.pptx" con una casella di testo come prima forma nella prima diapositiva e almeno un paragrafo. Sostituisce il contenuto del primo paragrafo con "1。", imposta SimSun come il suo font e assegna la lingua di revisione Cinese semplificato (`zh-CN`). Salva il risultato in "proofing_language.pptx":

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # Imposta l'Id della lingua di revisione.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta la Lingua Predefinita**

Usa [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione. Il seguente esempio crea una presentazione con l'inglese USA come lingua di testo predefinita, aggiunge una casella di testo e stampa `en-US` per la sua prima porzione di testo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # Aggiungi una forma rettangolare con testo.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Controlla la lingua della prima porzione.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Imposta lo Stile di Testo Predefinito**

Per applicare la formattazione di testo predefinita a livello di presentazione, usa [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Il seguente esempio imposta un font grassetto da 14 pt come predefinito per i paragrafi di livello superiore in una nuova presentazione e lo salva in "default_text_style.pptx". Il testo può ereditare questi valori predefiniti a meno che una formattazione più specifica non li sovrascriva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Ottieni il formato del paragrafo di livello superiore.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Estrai il Testo con l'Effetto Tutte Maiuscole**

In PowerPoint, l'applicazione dell'effetto carattere **All Caps** rende il testo visualizzato in maiuscolo sulla diapositiva anche se originariamente digitato in minuscolo. Quando recuperi una tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come inserito. Per corrispondere al testo visualizzato, controlla [TextCapType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textcaptype/) e converti la stringa restituita in maiuscolo quando il valore è `All`.

Questo esempio richiede "sample2.pptx" con una casella di testo come prima forma nella prima diapositiva. La prima porzione del primo paragrafo contiene "Hello, Aspose!" con l'effetto All Caps applicato, come mostrato di seguito.

![L'effetto Tutte Maiuscole](all_caps_effect.png)

Il codice esempio di seguito mostra come estrarre il testo con l'effetto **All Caps** applicato:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Come posso modificare il testo in una tabella su una diapositiva?**

Per modificare il testo in una tabella su una diapositiva, usa [Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/). Itera attraverso le celle e aggiorna ogni cella tramite [Cell.getTextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/cell/#getTextFrame) e la formattazione dei paragrafi tramite [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Come posso applicare un colore gradiente al testo su una diapositiva PowerPoint?**

Per applicare un colore gradiente al testo, usa [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/baseportionformat/#getFillFormat). Imposta [FillFormat.setFillType](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/#setFillType) su [FillType.Gradient](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/) e configura le fermate del gradiente, la direzione e la trasparenza.