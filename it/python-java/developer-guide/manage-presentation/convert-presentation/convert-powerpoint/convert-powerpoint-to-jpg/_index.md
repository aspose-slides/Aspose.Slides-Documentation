---
title: Converti PPT e PPTX in JPG con Python
linktitle: PowerPoint in JPG
type: docs
weight: 60
url: /it/python-java/convert-powerpoint-to-jpg/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- PowerPoint in JPG
- PPT in JPG
- PPTX in JPG
- salva diapositiva come JPG
- esporta PPT in JPG
- esporta PPTX in JPG
- Python
- Java
- Aspose.Slides
description: "Converti le diapositive PowerPoint (PPT, PPTX) in immagini JPG con Python tramite Java. Imposta dimensioni immagine personalizzate e renderizza note e commenti con Aspose.Slides."
---
## **Introduzione**

Aspose.Slides for Python via Java ti consente di convertire presentazioni PowerPoint e OpenDocument (PPT, PPTX e ODP) in immagini JPEG. Puoi esportare ogni diapositiva o una diapositiva selezionata per creare miniature, creare un visualizzatore di presentazioni o incorporare anteprime delle diapositive in un sito web o in un'applicazione.

## **Converti PowerPoint PPT/PPTX in JPG**

1. Carica la presentazione con [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/).
2. Recupera le diapositive usando [getSlides](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSlides).
3. Chiama [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage) con i fattori di scala orizzontale e verticale per renderizzare ogni diapositiva.
4. Salva ogni immagine renderizzata come JPEG usando [ImageFormat.Jpeg](https://reference.aspose.com/slides/it/python-java/aspose.slides/imageformat/#Jpeg), poi rilascia le risorse dell'immagine.

{{% alert color="info" title="Note" %}}
L'esportazione in JPG crea un'immagine separata per ogni diapositiva. Salva l'immagine renderizzata invece di salvare direttamente la presentazione in un formato immagine.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Converti PowerPoint PPT/PPTX in JPG con dimensioni personalizzate**

Calcola i fattori di scala orizzontale e verticale dalle dimensioni in pixel desiderate e dalla dimensione originale della diapositiva, poi passali a [Slide.getImage](https://reference.aspose.com/slides/it/python-java/aspose.slides/slide/#getImage). L'esempio seguente genera un'immagine di 1200 × 800 per ogni diapositiva.

Usare fattori di scala diversi può allungare la diapositiva. Per preservarne le proporzioni, usa lo stesso fattore di scala per entrambi gli assi; larghezza e altezza risultanti seguiranno allora le proporzioni originali della diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Renderizza i commenti quando salvi le diapositive come immagini**

Usa [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/notescommentslayoutingoptions/) per configurare note e commenti, e applica il layout tramite [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/it/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions). Questo esempio posiziona le note in basso, troncando le note che non stanno, e mostra i commenti a destra in un'area larga 200 pixel. Salva ogni diapositiva renderizzata come immagine JPG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Posso convertire più diapositive o presentazioni in JPG?**

Sì. Gli esempi ciclando attraverso tutte le diapositive salvano un JPG per diapositiva. Per elaborare più presentazioni, ripeti la conversione per ogni file di input e utilizza cartelle di output separate o nomi file unici per evitare di sovrascrivere le immagini.

**I grafici, SmartArt, tabelle e forme sono inclusi nelle immagini?**

Questi oggetti sono renderizzati come parte della diapositiva. Rendi disponibili i caratteri usati nella presentazione nell'ambiente di conversione per ridurre le differenze causate dalla sostituzione dei caratteri.

**Come posso ridurre l'uso di memoria durante l'esportazione di presentazioni di grandi dimensioni?**

Elabora le immagini una alla volta, rilascia ogni immagine dopo averla salvata e evita dimensioni di output eccessivamente grandi. I requisiti di memoria dipendono dal contenuto della diapositiva e dalla dimensione dell'immagine.

## **Vedi anche**

- [Converti PowerPoint in PNG](/slides/it/python-java/convert-powerpoint-to-png/).
- [Renderizza una diapositiva come immagine SVG](/slides/it/python-java/render-a-slide-as-an-svg-image/).