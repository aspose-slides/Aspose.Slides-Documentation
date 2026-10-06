---
title: Modifica le dimensioni e l'orientamento della pagina delle note in Python
linktitle: Dimensione della pagina delle note
type: docs
weight: 10
url: /it/python-net/notes-size/
keywords:
- dimensione pagina note
- orientamento note
- note in orizzontale
- note in verticale
- dimensione del prospetto
- PowerPoint
- presentazione
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Leggi e modifica le dimensioni della pagina delle note in Aspose.Slides per Python tramite .NET, cambia l'orientamento, verifica le dimensioni salvate e esporta note o prospetti in PDF e immagini."
---
## **Panoramica**

Usa [Presentation.notes_size](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/notes_size/) per accedere alle impostazioni della pagina delle note della presentazione. Restituisce un oggetto [NotesSize](https://reference.aspose.com/slides/it/python-net/aspose.slides/notessize/) la cui proprietà [size](https://reference.aspose.com/slides/it/python-net/aspose.slides/notessize/size/) è scrivibile. Anche se l'oggetto delle impostazioni è in sola lettura, è possibile assegnare nuove dimensioni alla sua proprietà size.

Larghezza e altezza sono specificate in **punti**, con 72 punti per pollice. Per esempio, 900 × 600 punti corrispondono a 12,5 × 8⅓ pollici. Queste impostazioni si applicano all'intera presentazione, non alle note di una diapositiva singola.

| Setting | Purpose |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/notes_size/) | Controlla le dimensioni della pagina delle note e le dimensioni della pagina utilizzate per l'esportazione dei prospetti. |
| [Presentation.slide_size](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/slide_size/) | Controlla le dimensioni delle diapositive della presentazione mediante [SlideSize](https://reference.aspose.com/slides/it/python-net/aspose.slides/slidesize/). |

Modificare una delle impostazioni non cambia automaticamente l'altra. Cambiare l'orientamento della pagina delle note non ruota nemmeno le diapositive regolari. Vedi [Slide Size](/slides/it/python-net/slide-size/) per ridimensionare le diapositive regolari.

Gli esempi seguenti utilizzano un file `sample.pptx` esistente. Per gli esempi di esportazione, usa una presentazione con almeno una diapositiva contenente note del relatore. Ogni esempio può essere eseguito in modo indipendente.

## **Leggi le dimensioni e l'orientamento della pagina delle note**

Leggi la larghezza e l'altezza e confrontale per determinare l'orientamento: una pagina più larga è orizzontale, una più alta è verticale, e dimensioni uguali descrivono una pagina quadrata. Questo esempio stampa le dimensioni effettive in punti, senza presumere una dimensione carta standard.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **Passa a orizzontale senza modificare le dimensioni della carta**

Per cambiare solo l'orientamento, scambia la larghezza e l'altezza esistenti. Questo preserva le lunghezze di entrambi i lati, comprese quelle di una dimensione carta personalizzata. La condizione riportata di seguito impedisce che una pagina già orizzontale venga riportata a verticale e lascia invariata una pagina quadrata.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

Per l'orientamento verticale, usa la stessa assegnazione quando `size.width > size.height`. Non sostituire le dimensioni A4 o Letter a meno che tu non voglia anche modificare le dimensioni della carta.

## **Imposta e verifica una dimensione personalizzata della pagina delle note**

Assegna entrambe le dimensioni contemporaneamente, poi usa [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) per salvare la presentazione. Questo esempio imposta una pagina orizzontale di 900 × 600 punti, la salva come PPTX e riapre il file salvato per verificare i valori persistiti. Il confronto consente una tolleranza di 0,01 punti per i valori in virgola mobile; non è una garanzia di precisione per tutti i formati di file.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

Il risultato atteso è `900 x 600 points` e `Size preserved: True`. Verificare una presentazione appena aperta controlla il file salvato, anziché solo le impostazioni in memoria.

## **Esporta note e prospetti**

Le dimensioni della pagina definiscono l'area disponibile per layout di note o di prospetti. Esse non attivano tali layout da sole: è necessario configurare anche le opzioni di esportazione. L'esportazione delle diapositive regolari continua a utilizzare le dimensioni delle diapositive.

### **Esporta note in PDF e PNG**

Assegna [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/notescommentslayoutingoptions/) a [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) per includere le note nel PDF. Questo esempio rende anche la prima diapositiva con note in PNG usando [Slide.get_image](https://reference.aspose.com/slides/it/python-net/aspose.slides/slide/get_image/) e [RenderingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/renderingoptions/).

La modalità [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/notespositions/) mantiene le note su una singola pagina; le note che non entrano possono essere troncate. Il PDF utilizza pagine di 900 × 600 punti. Alla scala immagine di 1 × 1 usata di seguito, il PNG è di 900 × 600 pixel. I punti descrivono la geometria della pagina; i pixel descrivono l'output raster, le cui dimensioni dipendono anche dalla scala di rendering.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

Per l'esportazione PDF con note lunghe, [BOTTOM_FULL](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/notespositions/) consente pagine aggiuntive secondo necessità. Non utilizzare tale modalità con la chiamata immagine a diapositiva singola sopra, che non la supporta. Dopo il ridimensionamento, controlla l'output per note tagliate e la posizione degli oggetti notes-master esistenti; cambiare solo le dimensioni della pagina non dovrebbe essere considerato una garanzia che tutto il contenuto si adatti. Vedi [Convert PowerPoint to PDF with Notes](/slides/it/python-net/convert-powerpoint-to-pdf-with-notes/) per ulteriori informazioni sull'esportazione delle note.

### **Esporta prospetti in PDF**

Usa [HandoutLayoutingOptions](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/handoutlayoutingoptions/) per più miniature di diapositive su una pagina. L'esempio seguente imposta una pagina di 900 × 600 punti e utilizza [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/handouttype/) per disporre fino a quattro diapositive per pagina. Il preset orizzontale controlla l'ordine delle diapositive; l'orientamento della pagina deriva dalla sua larghezza e altezza.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Modificare le dimensioni della pagina cambia l'area disponibile per la griglia del prospetto senza alterare le dimensioni delle diapositive di origine. Per le immagini del prospetto, usa [Presentation.get_images](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/get_images/) con il layout del prospetto, anziché il metodo immagine di una singola diapositiva. In Aspose.Slides, il rendering del prospetto a livello di presentazione utilizza le dimensioni della pagina delle note, mentre la chiamata immagine di una singola diapositiva non produce la pagina del prospetto. Vedi [Handout Mode](/slides/it/python-net/convert-powerpoint-in-handout-mode/) per le opzioni di layout.

## **Dimensione della pagina in visualizzatori, esportazione e stampa**

Mantieni distinte la dimensione della presentazione memorizzata, la dimensione della pagina esportata e la dimensione della carta stampata:

- **Presentation viewers:** Un visualizzatore può visualizzare o stampare le note utilizzando le proprie regole di layout. Se un'altra applicazione salva il file, riaprilo e controlla nuovamente le dimensioni; la conversione di formato di quell'applicazione potrebbe normalizzarle.
- **Export formats:** Gli esempi di PDF di note e prospetti sopra usano le dimensioni di pagina configurate. Le immagini raster usano dimensioni di pixel interi e una scala di rendering, quindi i valori di punto frazionari possono essere arrotondati nell'output immagine. L'esportazione delle diapositive regolari non applica la dimensione della pagina delle note.
- **Printer drivers:** La selezione della carta, la rotazione automatica e le impostazioni adatta alla pagina possono modificare l'output fisico senza cambiare le dimensioni memorizzate nella presentazione o nel PDF. Per una dimensione carta specifica, corrispondi le impostazioni della stampante e controlla l'anteprima di stampa.

## **FAQ**

**Posso impostare la dimensione delle note per una sola diapositiva?**

La dimensione della pagina delle note è un'impostazione a livello di presentazione. Le diapositive individuali possono contenere contenuti di note diversi, ma questa proprietà non fornisce una dimensione di pagina separata per ciascuna diapositiva.

**Perché la modifica dell'orientamento delle note non ha cambiato le mie diapositive?**

Le pagine delle note e le diapositive regolari hanno dimensioni indipendenti. Usa le impostazioni delle dimensioni delle diapositive regolari quando vuoi ridimensionare le diapositive stesse.

**Perché il risultato salvato o stampato ha una dimensione diversa?**

Innanzitutto riapri la presentazione salvata e confronta le sue dimensioni delle note. Se sono cambiate, verifica se il salvataggio o la conversione del file in un'altra applicazione ha modificato le impostazioni della pagina. Se non è così, controlla il layout di esportazione, la scala dell'immagine, le impostazioni del visualizzatore e la selezione della carta della stampante.