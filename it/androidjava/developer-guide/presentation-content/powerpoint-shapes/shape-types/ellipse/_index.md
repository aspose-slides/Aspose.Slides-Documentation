---
title: Aggiungere ellissi a presentazioni su Android
linktitle: Ellisse
type: docs
weight: 30
url: /it/androidjava/ellipse/
keywords:
- ellisse
- forma
- aggiungi ellisse
- crea ellisse
- disegna ellisse
- ellisse formattata
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come creare, formattare e manipolare forme ellittiche in Aspose.Slides per Android in presentazioni PPT e PPTX—inclusi esempi di codice Java."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme ellittiche alle diapositive PowerPoint utilizzando Aspose.Slides. Copre la creazione di un'ellisse semplice, la creazione di un'ellisse formattata e il salvataggio della presentazione aggiornata come file PPTX. Inoltre tratta domande correlate come la gestione della posizione e delle dimensioni dell'ellisse, il controllo dell'ordine di sovrapposizione e l'applicazione di effetti di animazione.

## **Crea un'ellisse**
Per aggiungere un'ellisse semplice a una diapositiva selezionata della presentazione, seguire i passaggi seguenti:

- Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
- Ottenere il riferimento di una diapositiva usando il suo indice.
- Aggiungere un'AutoShape di tipo Ellisse utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [IShapeCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection).
- Scrivere la presentazione modificata come file PPTX.

Nell'esempio riportato di seguito, abbiamo aggiunto un'ellisse alla prima diapositiva

```java
// Istanzia la classe Presentation che rappresenta il PPTX
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Aggiungi AutoShape di tipo ellisse
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Scrivi il file PPTX su disco
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Crea un'ellisse formattata**
Per aggiungere un'ellisse meglio formattata a una diapositiva, seguire i passaggi seguenti:

- Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
- Ottenere il riferimento di una diapositiva usando il suo indice.
- Aggiungere un'AutoShape di tipo Ellisse utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [IShapeCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection).
- Impostare il tipo di riempimento dell'ellisse su Solido.
- Impostare il colore dell'ellisse utilizzando la proprietà SolidFillColor.Color esposta dall'oggetto [FillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IFillFormat) associato all'oggetto [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShape).
- Impostare il colore delle linee dell'ellisse.
- Impostare lo spessore delle linee dell'ellisse.
- Scrivere la presentazione modificata come file PPTX.

Nell'esempio riportato di seguito, abbiamo aggiunto un'ellisse formattata alla prima diapositiva della presentazione.

```java
// Istanzia la classe Presentation che rappresenta il PPTX
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiungi AutoShape di tipo ellisse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Applica alcune formattazioni alla forma ellisse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Applica alcune formattazioni alla linea dell'ellisse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Scrivi il file PPTX su disco
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Come impostare la posizione e le dimensioni esatte di un'ellisse rispetto alle unità della diapositiva?**

Le coordinate e le dimensioni vengono solitamente specificate **in punti**. Per risultati prevedibili, basare i calcoli sulle dimensioni della diapositiva e convertire i millimetri o i pollici richiesti in punti prima di assegnare i valori.

**Come posso posizionare un'ellisse sopra o sotto altri oggetti (controllare l'ordine di sovrapposizione)?**

Regolare l'ordine di disegno dell'oggetto portandolo in primo piano o inviandolo sullo sfondo. Questo consente all'ellisse di sovrapporsi ad altri oggetti o di rivelare quelli sottostanti.

**Come animare l'aspetto o l'enfasi di un'ellisse?**

[Applica](/slides/it/androidjava/shape-animation/) effetti di ingresso, enfasi o uscita alla forma, e configura trigger e tempistiche per orchestrare quando e come l'animazione viene riprodotta.