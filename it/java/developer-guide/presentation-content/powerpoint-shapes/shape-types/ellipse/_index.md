---
title: Aggiungere ellissi alle presentazioni in Java
linktitle: Ellisse
type: docs
weight: 30
url: /it/java/ellipse/
keywords:
- ellisse
- forma
- aggiungere ellisse
- creare ellisse
- disegnare ellisse
- ellisse formattata
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come creare, formattare e manipolare forme ellittiche in Aspose.Slides per Java in presentazioni PPT e PPTX—esempi di codice Java inclusi."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme ellittiche alle diapositive PowerPoint utilizzando Aspose.Slides. Copre la creazione di un'ellisse semplice, la creazione di un'ellisse formattata e il salvataggio della presentazione aggiornata come file PPTX. Tratta anche domande correlate come la gestione della posizione e delle dimensioni dell'ellisse, il controllo dell'ordine di sovrapposizione e l'applicazione di effetti di animazione.

## **Creare un'ellisse**
Per aggiungere un'ellisse semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
- Ottieni il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungi un AutoShape di tipo Ellipse utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection).
- Salva la presentazione modificata come file PPTX.

Nel esempio mostrato qui sotto, abbiamo aggiunto un'ellisse alla prima diapositiva

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

## **Creare un'ellisse formattata**
Per aggiungere un'ellisse meglio formattata a una diapositiva, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
- Ottieni il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungi un AutoShape di tipo Ellipse utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection).
- Imposta il tipo di riempimento dell'ellisse su Solid.
- Imposta il colore dell'ellisse usando la proprietà SolidFillColor.Color esposta dall'oggetto [FillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/IFillFormat) associato all'oggetto [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape).
- Imposta il colore delle linee dell'ellisse.
- Imposta la larghezza delle linee dell'ellisse.
- Salva la presentazione modificata come file PPTX.

Nel esempio mostrato qui sotto, abbiamo aggiunto un'ellisse formattata alla prima diapositiva della presentazione.

```java
// Istanzia la classe Presentation che rappresenta il PPTX
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiungi AutoShape di tipo ellisse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Applica una formattazione alla forma ellisse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Applica una formattazione alla linea dell'ellisse
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

**Come posso impostare la posizione e le dimensioni esatte di un'ellisse rispetto alle unità della diapositiva?**

Le coordinate e le dimensioni sono tipicamente specificate **in punti**. Per risultati prevedibili, basa i calcoli sulla dimensione della diapositiva e converti i millimetri o i pollici necessari in punti prima di assegnare i valori.

**Come posso posizionare un'ellisse sopra o sotto altri oggetti (controllare l'ordine di sovrapposizione)?**

Regola l'ordine di disegno dell'oggetto portandolo in primo piano o mandandolo sullo sfondo. Questo consente all'ellisse di sovrapporsi ad altri oggetti o di rivelare quelli sottostanti.

**Come posso animare l'apparizione o l'enfasi di un'ellisse?**

[Apply](/slides/it/java/shape-animation/) effetti di ingresso, enfasi o uscita alla forma e configura trigger e tempistiche per coordinare quando e come viene eseguita l'animazione.