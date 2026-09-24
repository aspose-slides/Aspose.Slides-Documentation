---
title: Formattare il testo della presentazione in Python via Java
linktitle: Formattazione del testo
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
- famiglia di caratteri
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
description: "Formattare e stilizzare il testo in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per Python via Java. Personalizzare caratteri, colori, allineamento e altro."
---
## **Panoramica**

Questo articolo mostra come formattare il testo in presentazioni PowerPoint e OpenDocument utilizzando Aspose.Slides per Python via Java. Copre i colori di sfondo, la trasparenza, la spaziatura dei caratteri, le proprietà del carattere, la rotazione, la spaziatura dei paragrafi, il comportamento di autofit, l’ancoraggio del testo, le tabulazioni e le impostazioni della lingua.

Negli esempi seguenti, utilizzeremo un file denominato "sample.pptx", che contiene una singola casella di testo nella prima diapositiva con il seguente contenuto:

![Testo di esempio](sample_text.png)

Per trovare e evidenziare testo letterale o corrispondenze di espressioni regolari, vedere [Cerca e sostituisci testo](/slides/it/python-java/search-and-replace-text/).

## **Imposta colore di sfondo del testo**

Utilizzare [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) per impostare il colore di evidenziazione predefinito per un paragrafo, oppure usare [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/) per singole porzioni di testo.

Il seguente esempio di codice mostra come impostare il colore di sfondo per l'**intero paragrafo**:

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

Il codice seguente dimostra come impostare il colore di sfondo per **porzioni di testo con un carattere grassetto**:

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

## **Allinea paragrafi di testo**

Usare [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setAlignment) per impostare l’allineamento del paragrafo all'interno di un riquadro di testo. Il valore può essere centrato, allineato a sinistra, a destra, giustificato, ecc.

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

## **Imposta trasparenza del testo**

La trasparenza del testo è controllata attraverso la componente alfa del colore assegnato a [PortionFormat.getFillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/). Negli esempi seguenti, `alpha = 50` è un valore alfa ARGB su scala 0–255, non una percentuale di trasparenza.

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

    # Imposta il colore di riempimento del testo a colore trasparente.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![Il paragrafo trasparente](transparent_paragraph.png)

Il seguente esempio di codice mostra come applicare la trasparenza a **porzioni di testo con un carattere grassetto**:

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

## **Imposta spaziatura dei caratteri del testo**

Usare [PortionFormat.setSpacing](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/) per espandere o comprimere la spaziatura tra i caratteri in una casella di testo.

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

    # Nota: Usa valori negativi per comprimere la spaziatura dei caratteri.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Espandi la spaziatura dei caratteri.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Il risultato:

![La spaziatura dei caratteri nel paragrafo](character_spacing_in_paragraph.png)

Il codice seguente mostra come espandere la spaziatura dei caratteri in **porzioni di testo con un carattere grassetto**:

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

### **Disabilita il kerning per caratteri specifici**

In alcuni casi, il testo renderizzato da Aspose.Slides può apparire leggermente più stretto rispetto allo stesso testo visualizzato in PowerPoint. Ciò può accadere perché PowerPoint potrebbe ignorare i dati di kerning per determinati caratteri, anche quando il carattere contiene informazioni di kerning valide e il kerning è abilitato nelle impostazioni di PowerPoint.

Per rendere l'output più simile a PowerPoint in tali casi, è possibile disabilitare il kerning per le porzioni di testo che utilizzano il carattere interessato. Impostare [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/) su un valore significativamente più grande della dimensione reale del carattere:

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
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Questa impostazione impedisce l'applicazione del kerning alle porzioni di testo corrispondenti e può contribuire a allineare il rendering di Aspose.Slides a quello visivo di PowerPoint per i caratteri interessati da questo comportamento specifico di PowerPoint.

## **Gestisci le proprietà del carattere del testo**

Le proprietà del carattere possono essere impostate a livello di paragrafo tramite [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) o su singole porzioni tramite [PortionFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/).

Il seguente codice imposta il carattere e lo stile del testo per l'intero paragrafo: applica la dimensione del carattere, grassetto, corsivo, sottolineatura puntinata e il carattere Times New Roman a tutte le porzioni del paragrafo.

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

Il codice seguente applica proprietà simili a **porzioni di testo con un carattere grassetto**:

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

## **Imposta rotazione del testo**

Usare [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setTextVerticalType) per impostare un orientamento del testo predefinito all'interno di una forma.

Il seguente esempio di codice imposta l'orientamento del testo nella forma su `Vertical270`, che ruota il testo **di 90 gradi in senso antiorario**:

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

## **Imposta rotazione personalizzata per i riquadri di testo**

Usare [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setRotationAngle) per impostare un angolo di rotazione personalizzato per un [TextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframe/).

Il codice seguente ruota il riquadro di testo di 3 gradi in senso orario all'interno della forma:

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

## **Imposta interlinea dei paragrafi**

Aspose.Slides fornisce [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setSpaceBefore) e [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setSpaceWithin) per controllare la spaziatura dei paragrafi. Queste proprietà vengono utilizzate come segue:

* Usare un valore positivo per specificare l’interlinea come percentuale dell’altezza della riga.
* Usare un valore negativo per specificare l’interlinea in punti.

Il seguente esempio di codice mostra come specificare l’interlinea all'interno del paragrafo:

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

![L’interlinea all'interno del paragrafo](line_spacing.png)

## **Imposta tipo di adattamento automatico per i riquadri di testo**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setAutofitType) determina come il testo si comporta quando supera i confini del suo contenitore. Usalo per controllare se il testo si riduce, trabocca o ridimensiona automaticamente la forma.

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

Per contare le righe dopo l'adattamento automatico e vedere come il testo o la larghezza della forma influiscono sul risultato, vedere [Conta le righe renderizzate](/slides/it/python-java/manage-paragraph/). Il conteggio delle righe da solo non indica se il testo supera il contenitore.

## **Imposta ancoraggio dei riquadri di testo**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textframeformat/#setAnchoringType) definisce come il testo è posizionato verticalmente all’interno di una forma, ad esempio in alto, al centro o in basso.

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

## **Imposta tabulazione del testo**

Usare [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) e [ParagraphFormat.getTabs](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraphformat/#getTabs) per configurare le tabulazioni in un paragrafo.

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

## **Imposta lingua di correzione**

Aspose.Slides fornisce [PortionFormat.setLanguageId](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/), che consente di impostare la lingua di correzione per una porzione di testo. La lingua di correzione determina la lingua utilizzata per il controllo ortografico e grammaticale in PowerPoint.

Il seguente esempio di codice mostra come impostare la lingua di correzione per una porzione di testo:

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

    # Imposta l'Id della lingua di correzione.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Imposta lingua predefinita**

Usare [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/it/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) per definire la lingua predefinita per il testo creato durante il caricamento o la creazione di una presentazione.

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

## **Imposta stile di testo predefinito**

Per applicare la formattazione del testo predefinita a livello di presentazione, usare [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getDefaultTextStyle).

Il seguente esempio di codice mostra come impostare un carattere grassetto predefinito con dimensione 14 pt per tutto il testo nelle diapositive di una nuova presentazione.

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

## **Estrai testo con l'effetto tutte maiuscole**

In PowerPoint, l'applicazione dell'effetto **All Caps** al carattere fa apparire il testo in maiuscolo nella diapositiva anche se è stato originariamente digitato in minuscolo. Quando si recupera tale porzione di testo con Aspose.Slides, la libreria restituisce il testo esattamente come è stato inserito. Per ottenere il testo visualizzato, controllare [TextCapType](https://reference.aspose.com/slides/it/python-java/aspose.slides/textcaptype/) e convertire la stringa restituita in maiuscolo quando il valore è `All`.

Supponiamo di avere la seguente casella di testo nella prima diapositiva del file sample2.pptx.

![L'effetto tutte maiuscole](all_caps_effect.png)

Il codice seguente mostra come estrarre il testo con l'effetto **All Caps** applicato:

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

**Come modificare il testo in una tabella su una diapositiva?**

Per modificare il testo in una tabella su una diapositiva, usare [Table](https://reference.aspose.com/slides/it/python-java/aspose.slides/table/). Iterare attraverso le celle e aggiornare ciascuna cella tramite [Cell.getTextFrame](https://reference.aspose.com/slides/it/python-java/aspose.slides/cell/#getTextFrame) e la formattazione del paragrafo tramite [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/paragraph/#getParagraphFormat).

**Come applicare un colore sfumato al testo su una diapositiva PowerPoint?**

Per applicare un colore sfumato al testo, usare [PortionFormat.getFillFormat](https://reference.aspose.com/slides/it/python-java/aspose.slides/portionformat/). Impostare [FillFormat.setFillType](https://reference.aspose.com/slides/it/python-java/aspose.slides/fillformat/#setFillType) su [FillType.Gradient](https://reference.aspose.com/slides/it/python-java/aspose.slides/filltype/#Gradient) e configurare le fermate del gradiente, la direzione e la trasparenza.