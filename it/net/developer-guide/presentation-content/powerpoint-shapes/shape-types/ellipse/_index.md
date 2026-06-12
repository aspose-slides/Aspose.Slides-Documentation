---
title: Aggiungere ellissi alle presentazioni in .NET
linktitle: Ellisse
type: docs
weight: 30
url: /it/net/ellipse/
keywords:
  - ellisse
  - forma
  - aggiungere ellisse
  - creare ellisse
  - disegnare ellisse
  - ellisse formattata
  - PowerPoint
  - presentazione
  - .NET
  - C#
  - Aspose.Slides
description: "Scopri come creare, formattare e manipolare forme ellittiche in Aspose.Slides per .NET nelle presentazioni PPT e PPTX—inclusi esempi di codice C#."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme ellittiche alle diapositive PowerPoint utilizzando Aspose.Slides. Copre la creazione di un'ellisse semplice, la creazione di un'ellisse formattata e il salvataggio della presentazione aggiornata come file PPTX. Include anche domande correlate come la gestione della posizione e delle dimensioni dell'ellisse, il controllo dell'ordine di sovrapposizione e l'applicazione di effetti di animazione.

## **Creare un'Ellisse**
Per aggiungere un'ellisse semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation)
1. Ottieni il riferimento di una diapositiva utilizzando il suo indice
1. Aggiungi un AutoShape di tipo Ellipse usando il metodo AddAutoShape esposto dall'oggetto IShapes
1. Scrivi la presentazione modificata come file PPTX

Nell'esempio riportato di seguito, abbiamo aggiunto un'ellisse alla prima diapositiva.

```c#
 // Istanzia la classe Presentation che rappresenta il PPTX
using (Presentation pres = new Presentation())
{
    // Ottieni la prima diapositiva
    ISlide sld = pres.Slides[0];

    // Aggiungi un autoshape di tipo ellisse
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //Scrivi il file PPTX su disco
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```

## **Creare un'Ellisse Formattata**
Per aggiungere un'ellisse meglio formattata a una diapositiva, segui i passaggi seguenti:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation)
1. Ottieni il riferimento di una diapositiva utilizzando il suo indice
1. Aggiungi un AutoShape di tipo Ellipse usando il metodo AddAutoShape esposto dall'oggetto IShapes
1. Imposta il tipo di riempimento dell'ellisse su Solido
1. Imposta il colore dell'ellisse tramite la proprietà SolidFillColor.Color esposta dall'oggetto FillFormat associato all'oggetto IShape
1. Imposta il colore delle linee dell'ellisse
1. Imposta la larghezza delle linee dell'ellisse
1. Scrivi la presentazione modificata come file PPTX

Nell'esempio riportato di seguito, abbiamo aggiunto un'ellisse formattata alla prima diapositiva della presentazione.

```c#
// Instanzia la classe Presentation che rappresenta il PPTX
using (Presentation pres = new Presentation())
{

    // Ottieni la prima diapositiva
    ISlide sld = pres.Slides[0];

    // Aggiungi un autoshape di tipo ellisse
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Applica qualche formattazione alla forma ellisse
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Applica qualche formattazione alla linea dell'ellisse
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Scrivi il file PPTX su disco
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Come imposto la posizione e le dimensioni esatte di un'ellisse rispetto alle unità della diapositiva?**

Le coordinate e le dimensioni sono tipicamente specificate **in punti**. Per risultati prevedibili, basa i calcoli sulla dimensione della diapositiva e converti i millimetri o i pollici necessari in punti prima di assegnare i valori.

**Come posso posizionare un'ellisse sopra o sotto altri oggetti (controllare l'ordine di sovrapposizione)?**

Regola l'ordine di disegno dell'oggetto portandolo in primo piano o inviandolo sullo sfondo. Questo consente all'ellisse di sovrapporsi ad altri oggetti o di rivelare quelli sottostanti.

**Come impulso l'animazione di comparsa o enfasi di un'ellisse?**

[Applica](/slides/it/net/shape-animation/) effetti di ingresso, enfasi o uscita alla forma e configura trigger e tempistiche per orchestrare quando e come l'animazione viene eseguita.