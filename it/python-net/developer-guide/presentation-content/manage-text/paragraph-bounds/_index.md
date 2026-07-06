---
title: Ottenere i limiti dei paragrafi dalle presentazioni in Python
linktitle: Limiti del paragrafo
type: docs
weight: 43
url: /it/python-net/paragraph-bounds/
keywords:
- limiti del paragrafo
- coordinate del paragrafo
- dimensione del paragrafo
- frame di testo
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come recuperare i limiti dei paragrafi in Aspose.Slides per Python tramite .NET per ottimizzare il posizionamento del testo in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come ottenere i limiti, le dimensioni e le coordinate dei paragrafi in Aspose.Slides. Mostra come recuperare un rettangolo del paragrafo da un [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/) utilizzando [Paragraph.get_rect](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/get_rect/), come ottenere le coordinate del paragrafo all'interno di un text frame di cella di tabella e evidenzia dettagli importanti come le unità di misura, l'effetto del ritorno a capo sul limite, la conversione in pixel e i valori di formattazione del paragrafo effettiva.

## **Ottenere le coordinate rettangolari di un paragrafo**

Utilizza [Paragraph.get_rect](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/get_rect/) per ottenere il rettangolo di delimitazione di un paragrafo.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Ottenere le dimensioni di un paragrafo all'interno di un TextFrame di cella di tabella**

Per ottenere le dimensioni e le coordinate di un [Paragraph](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) in un text frame di cella di tabella, usa [Paragraph.get_rect](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/get_rect/). Il rettangolo restituito è relativo al text frame della cella di tabella, quindi aggiungi la posizione della tabella e l'offset della cella quando ti servono coordinate a livello di diapositiva.

L'esempio seguente ottiene i limiti del paragrafo all'interno di una cella di tabella e disegna rettangoli sulla diapositiva per visualizzare tali limiti:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**In quali unità sono misurate le coordinate del paragrafo?**

Sono misurate in punti, dove 1 pollice corrisponde a 72 punti. Questo vale per tutte le coordinate e dimensioni nella diapositiva.

**Il ritorno a capo del testo influisce sui limiti di un paragrafo?**

Sì. Se [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/wrap_text/) è abilitato per il [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/), il testo viene interrotto per adattarsi alla larghezza dell'area, il che modifica i limiti reali del paragrafo.

**È possibile mappare in modo affidabile le coordinate del paragrafo in pixel nell'immagine esportata?**

Sì. Converti i punti in pixel usando questa formula: pixel = punti x (DPI / 72). Il risultato dipende dal DPI scelto per il rendering o l'esportazione.

**Come ottenere i parametri di formattazione "effettiva" del paragrafo, tenendo conto dell'ereditarietà di stile?**

Utilizza la [effective paragraph formatting data structure](/slides/it/python-net/shape-effective-properties/); restituisce i valori finali consolidati per rientri, spaziature, a capo, RTL e altro.