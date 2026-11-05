---
title: Modifica dimensione e orientamento della pagina delle note in Python tramite Java
linktitle: Dimensione pagina note
type: docs
weight: 10
url: /it/python-java/notes-size/
keywords:
- dimensione pagina note
- orientamento note
- note in orizzontale
- note in verticale
- dimensione foglio riassuntivo
- PowerPoint
- presentazione
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Leggi e modifica le dimensioni della pagina delle note in Aspose.Slides per Python tramite Java, cambia l'orientamento, verifica le dimensioni salvate e esporta note o fogli riassuntivi in PDF e immagini."
---
## **Panoramica**

Usa [Presentation.getNotesSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getNotesSize) per accedere alle impostazioni della pagina delle note della presentazione. Restituisce un oggetto [NotesSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/notessize/) il cui metodo [setSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/notessize/#setSize) imposta le dimensioni della pagina. Sebbene l'oggetto delle impostazioni non possa essere sostituito, è possibile assegnare nuove dimensioni tramite questo metodo.

Larghezza e altezza sono specificate in **punti**, con 72 punti per pollice. Per esempio, 900 × 600 punti corrispondono a 12,5 × 8⅓ pollici. Queste impostazioni si applicano all'intera presentazione, non alle note di una singola diapositiva.

| Impostazione | Scopo |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getNotesSize) | Controlla le dimensioni della pagina delle note e le dimensioni della pagina utilizzate per l'esportazione del foglio riassuntivo. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlideSize) | Controlla le dimensioni delle diapositive regolari della presentazione tramite [SlideSize](https://reference.aspose.com/slides/it/python-java/aspose.slides/slidesize/). |

Modificare una delle impostazioni non cambia automaticamente l'altra. Cambiare l'orientamento della pagina delle note non ruota nemmeno le diapositive regolari. Vedi [Slide Size](/slides/it/python-java/slide-size/) per ridimensionare le diapositive regolari.

Gli esempi seguenti usano un file `sample.pptx` esistente. Per gli esempi di esportazione, utilizza una presentazione con almeno una diapositiva contenente le note del relatore. Ogni esempio può essere eseguito indipendentemente.

## **Leggi le dimensioni e l'orientamento della pagina delle note**

Leggi la larghezza e l'altezza e confrontale per determinare l'orientamento: una pagina più larga è in orientamento orizzontale, una più alta è in orientamento verticale, e dimensioni uguali descrivono una pagina quadrata. Questo esempio stampa le dimensioni effettive in punti, senza assumere una dimensione di carta standard.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **Passa a orizzontale senza modificare le dimensioni della carta**

Per cambiare solo l'orientamento, scambia la larghezza e l'altezza esistenti. Questo preserva le lunghezze di entrambi i lati, comprese quelle di una dimensione di carta personalizzata. La condizione qui sotto impedisce che una pagina già in orizzontale venga riportata in verticale e mantiene invariata una pagina quadrata.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Per l'orientamento verticale, usa la stessa assegnazione quando `size.getWidth() > size.getHeight()`. Non sostituire le dimensioni A4 o Letter a meno che tu non voglia anche modificare le dimensioni della carta.

## **Imposta e verifica una dimensione personalizzata della pagina delle note**

Assegna entrambe le dimensioni contemporaneamente, quindi usa [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) per salvare la presentazione. Questo esempio imposta una pagina orizzontale di 900 × 600 punti, la salva come PPTX e riapre il file salvato per verificare i valori persistiti. Il confronto consente una tolleranza di 0,01 punti per i valori in virgola mobile; non è una garanzia di precisione per tutti i formati di file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Il risultato atteso è `900.0 x 600.0 points` e `Size preserved: True`. Verificare una presentazione appena aperta controlla il file salvato, anziché solo le impostazioni in memoria.

## **Esporta note e fogli riassuntivi**

Le dimensioni della pagina definiscono l'area disponibile per le note o i layout dei fogli riassuntivi. Esse non abilitano tali layout da sole: è necessario configurare anche le opzioni di esportazione. L'esportazione delle diapositive regolari continua a utilizzare le dimensioni della diapositiva.

### **Esporta note in PDF e PNG**

Assegna [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/) a [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) per includere le note nel PDF. Questo esempio rende anche la prima diapositiva con note in PNG utilizzando [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) e [RenderingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/renderingoptions/).

La modalità [BottomTruncated](https://reference.aspose.com/slides/it/python-java/aspose.slides/notespositions/) mantiene le note su una singola pagina; le note che non entrano possono essere troncate. Il PDF utilizza pagine di 900 × 600 punti. Con la scala dell'immagine di 1 × 1 usata di seguito, il PNG è di 900 × 600 pixel. I punti descrivono la geometria della pagina; i pixel descrivono l'output raster, le cui dimensioni dipendono anche dalla scala di rendering.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Per l'esportazione PDF con note lunghe, [BottomFull](https://reference.aspose.com/slides/it/python-java/aspose.slides/notespositions/) consente pagine aggiuntive se necessario. Non usare quella modalità con la chiamata immagine a diapositiva singola sopra, che non la supporta. Dopo il ridimensionamento, controlla l'output per note ritagliate e il posizionamento degli oggetti notes-master esistenti; modificare solo le dimensioni della pagina non dovrebbe essere considerato una garanzia che tutti i contenuti si adatteranno. Vedi [Convert PowerPoint to PDF with Notes](/slides/it/python-java/convert-powerpoint-to-pdf-with-notes/) per ulteriori informazioni sull'esportazione delle note.

### **Esporta fogli riassuntivi in PDF**

Usa [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/handoutlayoutingoptions/) per avere più miniature di diapositive su una singola pagina. L'esempio seguente imposta una pagina di 900 × 600 punti e utilizza [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/it/python-java/aspose.slides/handouttype/) per disporre fino a quattro diapositive per pagina. Il preset orizzontale controlla l'ordine delle diapositive; l'orientamento della pagina deriva dalla sua larghezza e altezza.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Modificare la dimensione della pagina cambia l'area disponibile per la griglia del foglio riassuntivo senza alterare le dimensioni delle diapositive originali. Per le immagini dei fogli riassuntivi, usa [Presentation.getImages](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getImages) con il layout del foglio riassuntivo, invece del metodo immagine di una singola diapositiva. In Aspose.Slides, il rendering dei fogli riassuntivi a livello di presentazione utilizza le dimensioni della pagina delle note, mentre la chiamata immagine di una diapositiva singola non genera la pagina del foglio riassuntivo. Vedi [Handoff Mode](/slides/it/python-java/convert-powerpoint-in-handout-mode/) per le opzioni di layout.

## **Dimensione della pagina in visualizzatori, esportazione e stampa**

Mantieni distinte la dimensione della presentazione memorizzata, la dimensione della pagina esportata e la dimensione della carta stampata:

- **Visualizzatori di presentazione:** Un visualizzatore può visualizzare o stampare le note usando le proprie regole di layout. Se un'altra applicazione salva il file, riaprilo e verifica nuovamente le dimensioni; la conversione di formato di quell'applicazione potrebbe normalizzarle.
- **Formati di esportazione:** Gli esempi di PDF di note e fogli riassuntivi sopra usano le dimensioni della pagina configurate. Le immagini raster usano dimensioni di pixel interi e una scala di rendering, quindi i valori frazionari dei punti possono essere arrotondati nell'output dell'immagine. L'esportazione delle diapositive regolari non applica le dimensioni della pagina delle note.
- **Driver della stampante:** La selezione della carta, la rotazione automatica e le impostazioni di adatta alla pagina possono modificare l'output fisico senza cambiare le dimensioni memorizzate nella presentazione o nel PDF. Per una dimensione di carta specifica, corrispondi le impostazioni della stampante e verifica l'anteprima di stampa.

## **FAQ**

**Posso impostare la dimensione delle note per una sola diapositiva?**

La dimensione della pagina delle note è un'impostazione a livello di presentazione. Le singole diapositive possono avere contenuti di note diversi, ma questa proprietà non fornisce una dimensione della pagina separata per ciascuna diapositiva.

**Perché la modifica dell'orientamento delle note non ha cambiato le mie diapositive?**

Le pagine delle note e le diapositive regolari hanno dimensioni indipendenti. Usa le impostazioni di dimensione delle diapositive regolari quando desideri ridimensionare le diapositive stesse.

**Perché il risultato salvato o stampato ha una dimensione diversa?**

Riapri prima la presentazione salvata e confronta le sue dimensioni delle note. Se sono cambiate, verifica se il salvataggio o la conversione del file in un'altra applicazione ha modificato le impostazioni della pagina. Se non è stato così, controlla il layout di esportazione, la scala dell'immagine, le impostazioni del visualizzatore e la selezione della carta della stampante.