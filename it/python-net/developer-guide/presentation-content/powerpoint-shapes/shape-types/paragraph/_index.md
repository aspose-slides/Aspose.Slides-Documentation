---
title: Ottenere i limiti del paragrafo dalle presentazioni in Python
linktitle: Paragrafo
type: docs
weight: 60
url: /it/python-net/paragraph/
keywords:
- limiti del paragrafo
- limiti della porzione di testo
- coordinate del paragrafo
- coordinate della porzione
- dimensione del paragrafo
- dimensione della porzione di testo
- riquadro di testo
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come recuperare i limiti del paragrafo e della porzione di testo in Aspose.Slides per Python tramite .NET per ottimizzare il posizionamento del testo nelle presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Questo articolo spiega come ottenere i limiti, le dimensioni e le coordinate di paragrafi e porzioni di testo in Aspose.Slides. Mostra come recuperare il rettangolo di un paragrafo in un `TextFrame` utilizzando `get_rect()`, come ottenere le coordinate del paragrafo e della porzione all'interno di una cella di tabella e mette in evidenza dettagli importanti come le unità di misura, l'effetto dell'andare a capo del testo sui limiti, la conversione in pixel e i valori di formattazione del paragrafo effettivi.

## **Ottenere le Coordinate di Paragrafo e Porzione in TextFrame**
Utilizzando Aspose.Slides per Python tramite .NET, gli sviluppatori possono ora ottenere le coordinate rettangolari per il Paragraph all'interno della collezione di paragrafi di un TextFrame. Consente anche di ottenere le coordinate della porzione all'interno della collezione di porzioni di un paragrafo. In questo argomento, dimostreremo, con l'aiuto di un esempio, come ottenere le coordinate rettangolari per il paragrafo insieme alla posizione della porzione all'interno di un paragrafo.

## **Ottenere le Coordinate Rettangolari del Paragrafo**
È stato aggiunto il nuovo metodo **GetRect()**. Consente di ottenere il rettangolo dei limiti del paragrafo.

```py
import aspose.slides as slides

# Instanziare un oggetto Presentation che rappresenta un file di presentazione
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Ottenere le dimensioni del paragrafo e della porzione all'interno del text frame di una cella di tabella** ##

Per ottenere le dimensioni e le coordinate della [Porzione](https://reference.aspose.com/slides/it/python-net/aspose.slides/portion/) o del [Paragrafo](https://reference.aspose.com/slides/it/python-net/aspose.slides/paragraph/) in un text frame di una cella di tabella, è possibile utilizzare i metodi [IPortion.GetRect](https://reference.aspose.com/slides/it/python-net/aspose.slides/iportion/) e [IParagraph.GetRect](https://reference.aspose.com/slides/it/python-net/aspose.slides/iparagraph/).

Questo codice di esempio dimostra l'operazione descritta:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **FAQ**

**In quali unità vengono restituite le coordinate per un paragrafo e le porzioni di testo?**

In punti, dove 1 pollice = 72 punti. Questo vale per tutte le coordinate e le dimensioni nella diapositiva.

**Il ritorno a capo del testo influisce sui limiti di un paragrafo?**

Sì. Se [avvolgimento](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframeformat/wrap_text/) è abilitato nel [TextFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/textframe/), il testo si interrompe per adattarsi alla larghezza dell'area, modificando i limiti reali del paragrafo.

**Le coordinate del paragrafo possono essere mappate in modo affidabile a pixel nell'immagine esportata?**

Sì. Converti i punti in pixel usando: pixel = punti × (DPI / 72). Il risultato dipende dal DPI scelto per il rendering/esportazione.

**Come ottenere i parametri di formattazione "effettivi" del paragrafo, tenendo conto dell'ereditarietà dello stile?**

Utilizza la [struttura dati di formattazione del paragrafo effettiva](/slides/it/python-net/shape-effective-properties/); restituisce i valori finali consolidati per rientri, spaziatura, avvolgimento, RTL e altro.