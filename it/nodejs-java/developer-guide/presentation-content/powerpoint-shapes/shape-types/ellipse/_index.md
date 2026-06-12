---
title: Aggiungere ellissi alle presentazioni in JavaScript
linktitle: Ellisse
type: docs
weight: 30
url: /it/nodejs-java/ellipse/
keywords:
- ellisse
- forma
- aggiungere ellisse
- creare ellisse
- disegnare ellisse
- ellisse formattata
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come creare, formattare e manipolare forme ellittiche in Aspose.Slides per Node.js su presentazioni PPT e PPTX—inclusi esempi di codice JavaScript."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme ellittiche alle diapositive PowerPoint utilizzando Aspose.Slides. Copre la creazione di un'ellisse semplice, la creazione di un'ellisse formattata e il salvataggio della presentazione aggiornata come file PPTX. Include anche domande correlate come la gestione della posizione e delle dimensioni dell'ellisse, il controllo dell'ordine di sovrapposizione e l'applicazione di effetti di animazione.

## **Crea ellisse**
Per aggiungere un'ellisse semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
- Ottenere il riferimento di una diapositiva usando il suo indice.
- Aggiungere un AutoShape di tipo Ellisse utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection).
- Scrivere la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto un'ellisse alla prima diapositiva

```javascript
// Instanzia la classe Presentation che rappresenta il PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Aggiungi AutoShape di tipo ellisse
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Scrivi il file PPTX su disco
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Crea ellisse formattata**
Per aggiungere un'ellisse migliore formattata a una diapositiva, segui i passaggi seguenti:

- Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
- Ottenere il riferimento di una diapositiva usando il suo indice.
- Aggiungere un AutoShape di tipo Ellisse utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection).
- Impostare il tipo di riempimento dell'ellisse su Solido.
- Impostare il colore dell'ellisse utilizzando la proprietà SolidFillColor.Color esposta dall'oggetto [FillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FillFormat) associato all'oggetto [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape).
- Impostare il colore delle linee dell'ellisse.
- Impostare lo spessore delle linee dell'ellisse.
- Scrivere la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto un'ellisse formattata alla prima diapositiva della presentazione.

```javascript
// Instanzia la classe Presentation che rappresenta il PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Aggiungi AutoShape di tipo ellisse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Applica qualche formattazione alla forma ellisse
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Applica qualche formattazione alla linea dell'Ellisse
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Scrivi il file PPTX su disco
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **FAQ**

**Come impostare la posizione esatta e le dimensioni di un'ellisse rispetto alle unità della diapositiva?**

Le coordinate e le dimensioni sono tipicamente specificate **in punti**. Per risultati prevedibili, basa i calcoli sulla dimensione della diapositiva e converte i millimetri o i pollici richiesti in punti prima di assegnare i valori.

**Come posizionare un'ellisse sopra o sotto altri oggetti (controllare l'ordine di sovrapposizione)?**

Regola l'ordine di disegno dell'oggetto portandolo in primo piano o mandandolo sullo sfondo. Questo consente all'ellisse di sovrapporsi ad altri oggetti o di rivelare quelli sottostanti.

**Come animare l'aspetto o l'enfasi di un'ellisse?**

[Applica](/slides/it/nodejs-java/shape-animation/) effetti di ingresso, enfatizzazione o uscita alla forma, e configurare trigger e tempistiche per orchestrare quando e come viene eseguita l'animazione.