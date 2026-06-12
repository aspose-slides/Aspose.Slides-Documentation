---
title: Crea forme di linea nelle presentazioni con Python
linktitle: Linea
type: docs
weight: 50
url: /it/python-net/line/
keywords:
- linea
- crea linea
- aggiungi linea
- linea semplice
- configura linea
- personalizza linea
- stile tratteggiato
- punta di freccia
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Impara a manipolare la formattazione delle linee in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python via .NET. Scopri proprietà, metodi ed esempi."
---
## **Panoramica**

Aspose.Slides for Python via .NET supporta l’aggiunta di diversi tipi di forme alle diapositive. In questo argomento inizieremo a lavorare con le forme aggiungendo linee alle diapositive. Usando Aspose.Slides, gli sviluppatori possono non solo creare linee semplici, ma anche disegnare linee più elaborate sulle diapositive.

## **Crea linee semplici**

Utilizza Aspose.Slides per aggiungere una linea semplice a una diapositiva come separatore o connettore. Per aggiungere una linea semplice a una diapositiva selezionata in una presentazione, segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento alla diapositiva per indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) di tipo `LINE` usando il metodo `add_auto_shape` sull'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/).
1. Salva la presentazione come file PPTX.

Nell’esempio sottostante, una linea viene aggiunta alla prima diapositiva della presentazione.

```py
import aspose.slides as slides

# Istanzia la classe Presentation.
with slides.Presentation() as presentation:

    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi una forma automatica di tipo LINE.
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Salva la presentazione come file PPTX.
    presentation.save("line_shape.pptx", slides.export.SaveFormat.PPTX)
```

## **Crea linee a forma di freccia**

Aspose.Slides ti consente di configurare le proprietà della linea per renderla più accattivante visivamente. Di seguito, configuriamo alcune proprietà di una linea per farla apparire come una freccia. Segui questi passaggi:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
1. Ottieni un riferimento a una diapositiva per indice.
1. Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) di tipo `LINE` usando il metodo `add_auto_shape` sull'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapecollection/).
1. Imposta lo [stile della linea](https://reference.aspose.com/slides/it/python-net/aspose.slides/linestyle/).
1. Imposta lo spessore della linea.
1. Imposta lo [stile tratteggiato della linea](https://reference.aspose.com/slides/it/python-net/aspose.slides/linedashstyle/).
1. Imposta lo [stile della punta della freccia](https://reference.aspose.com/slides/it/python-net/aspose.slides/linearrowheadstyle/) e la lunghezza per il punto di inizio della linea.
1. Imposta lo stile della punta della freccia e la lunghezza per il punto finale della linea.
1. Salva la presentazione come file PPTX.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Istanzia la classe Presentation che rappresenta il file PPTX.
with slides.Presentation() as presentation:
    # Ottieni la prima diapositiva.
    slide = presentation.slides[0]

    # Aggiungi una forma automatica di tipo LINE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    # Applica la formattazione alla linea.
    shape.line_format.style = slides.LineStyle.THICK_BETWEEN_THIN
    shape.line_format.width = 10

    shape.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    shape.line_format.begin_arrowhead_length = slides.LineArrowheadLength.SHORT
    shape.line_format.begin_arrowhead_style = slides.LineArrowheadStyle.OVAL

    shape.line_format.end_arrowhead_length = slides.LineArrowheadLength.LONG
    shape.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE

    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.maroon

    # Salva la presentazione come file PPTX.
    presentation.save("line_shape_2.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso convertire una linea regolare in un connettore in modo che si "agganci" alle forme?**

No. Una linea regolare (un [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) di tipo [LINE](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapetype/)) non diventa automaticamente un connettore. Per farla agganciare alle forme, usa il tipo dedicato [Connector](https://reference.aspose.com/slides/it/python-net/aspose.slides/connector/) e le [API corrispondenti](/slides/it/python-net/connector/) per le connessioni.

**Cosa devo fare se le proprietà di una linea sono ereditate dal tema e risulta difficile determinare i valori finali?**

[Leggi le proprietà effettive](/slides/it/python-net/shape-effective-properties/) mediante le classi [ILineFormatEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/it/python-net/aspose.slides/ilinefillformateffectivedata/) — queste tengono già conto dell’eredità e degli stili del tema.

**Posso bloccare una linea contro la modifica (spostamento, ridimensionamento)?**

Sì. Le forme forniscono [oggetti di blocco](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/auto_shape_lock/) che ti consentono di [disabilitare le operazioni di modifica](/slides/it/python-net/applying-protection-to-presentation/).