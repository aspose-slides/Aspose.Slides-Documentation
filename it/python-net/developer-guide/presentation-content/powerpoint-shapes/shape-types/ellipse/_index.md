---
title: Aggiungere ellissi alle presentazioni in Python
linktitle: Ellisse
type: docs
weight: 30
url: /it/python-net/ellipse/
keywords:
- ellisse
- forma
- aggiungere ellisse
- creare ellisse
- disegnare ellisse
- ellisse formattata
- PowerPoint
- OpenDocument
- presentazione
- Python
- Aspose.Slides
description: "Scopri come creare, formattare e manipolare forme ellittiche in Aspose.Slides per Python tramite .NET su presentazioni PPT, PPTX e ODP—esempi di codice inclusi."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme ellittiche alle diapositive PowerPoint utilizzando Aspose.Slides. Copre la creazione di un'ellisse semplice, la creazione di un'ellisse formattata e il salvataggio della presentazione aggiornata come file PPTX. Include anche domande correlate come la gestione della posizione e delle dimensioni dell'ellisse, il controllo dell'ordine di sovrapposizione e l'applicazione di effetti di animazione.

## **Crea ellisse**
In questo argomento introdurremo gli sviluppatori all'aggiunta di forme ellittiche alle proprie diapositive usando Aspose.Slides for Python via .NET. Aspose.Slides for Python via .NET fornisce un insieme più semplice di API per disegnare diversi tipi di forme con poche righe di codice. Per aggiungere un'ellisse semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation ](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) 
1. Ottieni il riferimento di una diapositiva usando il suo indice
1. Aggiungi un AutoShape di tipo Ellipse usando il metodo AddAutoShape esposto dall'oggetto IShapes
1. Scrivi la presentazione modificata come file PPTX

Nell'esempio mostrato di seguito, abbiamo aggiunto un'ellisse alla prima diapositiva.

```py
import aspose.slides as slides

# Instanzia la classe Presentation che rappresenta il PPTX
with slides.Presentation() as pres:
    # Ottieni la prima diapositiva
    sld = pres.slides[0]

    # Aggiungi un autoshape di tipo ellisse
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #Scrivi il file PPTX su disco
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Crea ellisse formattata**
Per aggiungere un'ellisse meglio formattata a una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation ](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/) 
1. Ottieni il riferimento di una diapositiva usando il suo indice.
1. Aggiungi un AutoShape di tipo Ellipse usando il metodo AddAutoShape esposto dall'oggetto IShapes.
1. Imposta il tipo di riempimento dell'ellisse su Solid.
1. Imposta il colore dell'ellisse usando la proprietà SolidFillColor.Color esposta dall'oggetto FillFormat associato all'oggetto IShape.
1. Imposta il colore delle linee dell'ellisse.
1. Imposta la larghezza delle linee dell'ellisse.
1. Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto un'ellisse formattata alla prima diapositiva della presentazione.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanzia la classe Presentation che rappresenta il PPTX
with slides.Presentation() as pres:
    # Ottieni la prima diapositiva
    sld = pres.slides[0]

    # Aggiungi un autoshape di tipo ellisse
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Applica una formattazione alla forma ellisse
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Applica una formattazione alla linea dell'ellisse
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Scrivi il file PPTX su disco
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Come impostare la posizione e le dimensioni esatte di un'ellisse rispetto alle unità della diapositiva?**

Le coordinate e le dimensioni sono solitamente specificate **in points**. Per risultati prevedibili, basa i calcoli sulla dimensione della diapositiva e converti i millimetri o i pollici richiesti in points prima di assegnare i valori.

**Come posizionare un'ellisse sopra o sotto altri oggetti (controllare l'ordine di sovrapposizione)?**

Regola l'ordine di disegno dell'oggetto portandolo in primo piano o inviandolo sullo sfondo. Questo consente all'ellisse di sovrapporsi ad altri oggetti o di rivelare quelli sottostanti.

**Come animare l'aspetto o l'enfasi di un'ellisse?**

[Applica](/slides/it/python-net/shape-animation/) effetti di ingresso, enfasi o uscita alla forma e configura trigger e tempistiche per orchestrare quando e come l'animazione viene eseguita.