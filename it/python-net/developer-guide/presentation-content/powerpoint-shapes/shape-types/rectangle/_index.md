---
title: Aggiungi rettangoli alle presentazioni in Python
linktitle: Rettangolo
type: docs
weight: 80
url: /it/python-net/rectangle/
keywords:
- aggiungi rettangolo
- crea rettangolo
- forma rettangolo
- rettangolo semplice
- rettangolo formattato
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Migliora le tue presentazioni PowerPoint e OpenDocument aggiungendo rettangoli con Aspose.Slides per Python tramite .NET—progetta e modifica facilmente le forme in modo programmatico."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme rettangolo alle diapositive PowerPoint utilizzando Aspose.Slides. Copre la creazione di un rettangolo semplice, la creazione di un rettangolo formattato e il salvataggio della presentazione aggiornata come file PPTX.

Vedrai anche come applicare formattazioni di base al rettangolo, come un colore di riempimento solido, colore della linea e spessore della linea. Inoltre, le FAQ dell'articolo indicano attività correlate al rettangolo, inclusi angoli arrotondati, riempimenti con immagini, effetti visivi, collegamenti ipertestuali, blocchi di forma, opzioni di esportazione e proprietà efficaci.

## **Creare rettangolo semplice**
Come nei temi precedenti, anche questo riguarda l'aggiunta di una forma e questa volta la forma di cui parleremo è Rettangolo. In questo argomento, abbiamo descritto come gli sviluppatori possono aggiungere rettangoli semplici o formattati alle loro diapositive utilizzando Aspose.Slides per Python tramite .NET. Per aggiungere un rettangolo semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation ](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni il riferimento di una diapositiva usando il suo indice.
3. Aggiungi un IAutoShape di tipo Rectangle utilizzando il metodo AddAutoShape esposto dall'oggetto IShapes.
4. Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto un rettangolo semplice alla prima diapositiva della presentazione.

```py
import aspose.slides as slides

# Instanzia la classe Presentation che rappresenta il PPTX
with slides.Presentation() as pres:
    # Ottieni la prima diapositiva
    sld = pres.slides[0]

    # Aggiungi una forma automatica di tipo rettangolo
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    #Scrivi il file PPTX su disco
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Creare rettangolo formattato**
Per aggiungere un rettangolo formattato a una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation ](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/).
2. Ottieni il riferimento di una diapositiva usando il suo indice.
3. Aggiungi un IAutoShape di tipo Rectangle utilizzando il metodo AddAutoShape esposto dall'oggetto IShapes.
4. Imposta il tipo di riempimento del rettangolo su Solido.
5. Imposta il colore del rettangolo usando la proprietà SolidFillColor.Color esposta dall'oggetto FillFormat associato all'oggetto IShape.
6. Imposta il colore delle linee del rettangolo.
7. Imposta la larghezza delle linee del rettangolo.
8. Scrivi la presentazione modificata come file PPTX.

I passaggi sopra sono implementati nell'esempio mostrato di seguito.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanzia la classe Presentation che rappresenta il PPTX
with slides.Presentation() as pres:
    # Ottieni la prima diapositiva
    sld = pres.slides[0]

    # Aggiungi una forma automatica di tipo rettangolo
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Applica alcune formattazioni alla forma rettangolo
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Applica alcune formattazioni alla linea del rettangolo
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Scrivi il file PPTX su disco
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Come aggiungo un rettangolo con angoli arrotondati?**

Usa il [shape type](https://reference.aspose.com/slides/it/python-net/aspose.slides/shapetype/) con angoli arrotondati e regola il raggio dell'angolo nelle proprietà della forma; l'arrotondamento può essere applicato anche per singolo angolo tramite aggiustamenti geometrici.

**Come riempio un rettangolo con un'immagine (texture)?**

Seleziona il [fill type](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/), fornisci la sorgente dell'immagine e configura le [stretching/tiling modes](https://reference.aspose.com/slides/it/python-net/aspose.slides/picturefillmode/).

**Un rettangolo può avere ombra e bagliore?**

Sì. Sono disponibili [Outer/inner shadow, glow, and soft edges](/slides/it/python-net/shape-effect/) con parametri regolabili.

**Posso trasformare un rettangolo in un pulsante con un collegamento ipertestuale?**

Sì. [Assign a hyperlink](/slides/it/python-net/manage-hyperlinks/) al clic della forma (vai a una diapositiva, file, indirizzo web o e‑mail).

**Come posso proteggere un rettangolo da spostamenti e modifiche?**

[Use shape locks](/slides/it/python-net/applying-protection-to-presentation/): puoi impedire lo spostamento, il ridimensionamento, la selezione o la modifica del testo per preservare il layout.

**Posso convertire un rettangolo in un'immagine raster o SVG?**

Sì. Puoi [render the shape](http://reference.aspose.com/slides/it/python-net/aspose.slides/shape/get_image/) in un'immagine con dimensione/scala specificata o [export it as SVG](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/write_as_svg/) per l'uso vettoriale.

**Come ottengo rapidamente le proprietà effettive di un rettangolo tenendo conto del tema e dell'ereditarietà?**

[Use the shape’s effective properties](/slides/it/python-net/shape-effective-properties/): l'API restituisce i valori calcolati che tengono conto degli stili del tema, del layout e delle impostazioni locali, semplificando l'analisi della formattazione.