---
title: Aggiungi rettangoli alle presentazioni in JavaScript
linktitle: Rettangolo
type: docs
weight: 80
url: /it/nodejs-java/rectangle/
keywords:
- aggiungi rettangolo
- crea rettangolo
- forma rettangolare
- rettangolo semplice
- rettangolo formattato
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Migliora le tue presentazioni PowerPoint aggiungendo rettangoli con JavaScript e Aspose.Slides per Node.js—progetta e modifica facilmente le forme in modo programmatico."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme rettangolari alle diapositive PowerPoint utilizzando Aspose.Slides. Copre la creazione di un rettangolo semplice, la creazione di un rettangolo formattato e il salvataggio della presentazione aggiornata come file PPTX.

Vedrai anche come applicare la formattazione di base del rettangolo, come un colore di riempimento solido, il colore della linea e lo spessore della linea. Inoltre, le FAQ dell’articolo rimandano a attività correlate al rettangolo, inclusi angoli arrotondati, riempimenti con immagine, effetti visivi, collegamenti ipertestuali, blocchi della forma, opzioni di esportazione e proprietà effettive.

## **Aggiungi Rettangolo alla Diapositiva**

Come nei temi precedenti, anche questo riguarda l’aggiunta di una forma e, questa volta, la forma di cui parleremo è il Rettangolo. In questo argomento abbiamo descritto come gli sviluppatori possano aggiungere rettangoli semplici o formattati alle proprie diapositive usando Aspose.Slides.

Per aggiungere un rettangolo semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
- Ottieni il riferimento di una diapositiva usando il suo indice.
- Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape) di tipo Rectangle utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall’oggetto [ShapeCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection).
- Scrivi la presentazione modificata come file PPTX.

Nell’esempio riportato di seguito, abbiamo aggiunto un rettangolo semplice alla prima diapositiva della presentazione.

```javascript
// Istanzia la classe Presentation che rappresenta il PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Aggiungi AutoShape di tipo ellisse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Scrivi il file PPTX su disco
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aggiungi Rettangolo Formattato alla Diapositiva**
Per aggiungere un rettangolo formattato a una diapositiva, segui i passaggi seguenti:

- Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation).
- Ottieni il riferimento di una diapositiva usando il suo indice.
- Aggiungi un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/AutoShape) di tipo Rectangle utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall’oggetto [ShapeCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection).
- Imposta il [Fill Type](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FillType) del rettangolo su Solid.
- Imposta il colore del rettangolo usando il metodo [SolidFillColor.setColor](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) esposto dall’oggetto [FillFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/FillFormat) associato all’oggetto [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Shape).
- Imposta il colore delle linee del rettangolo.
- Imposta lo spessore delle linee del rettangolo.
- Scrivi la presentazione modificata come file PPTX.

I passaggi sopra sono implementati nell’esempio riportato di seguito.

```javascript
// Istanzia la classe Presentation che rappresenta il PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Aggiungi AutoShape di tipo ellisse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Applica qualche formattazione alla forma ellisse
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Applica qualche formattazione alla linea dell'ellisse
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Scrivi il file PPTX su disco
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Come faccio ad aggiungere un rettangolo con angoli arrotondati?**

Usa il tipo di forma [shape type](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapetype/) con angoli arrotondati e regola il raggio dell’angolo nelle proprietà della forma; l’arrotondamento può essere applicato anche per ciascun angolo tramite aggiustamenti geometrici.

**Come riempio un rettangolo con un’immagine (texture)?**

Seleziona il [fill type](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) immagine, fornisci la sorgente dell’immagine e configura le modalità di [stretching/tiling](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillmode/).

**Un rettangolo può avere ombra e bagliore?**

Sì. [Outer/inner shadow, glow, and soft edges](/slides/it/nodejs-java/shape-effect/) sono disponibili con parametri regolabili.

**Posso trasformare un rettangolo in un pulsante con un collegamento ipertestuale?**

Sì. [Assign a hyperlink](/slides/it/nodejs-java/manage-hyperlinks/) alla forma (salto a una diapositiva, file, indirizzo web o e‑mail).

**Come posso proteggere un rettangolo da spostamenti e modifiche?**

Usa i blocchi della forma: puoi vietare lo spostamento, il ridimensionamento, la selezione o la modifica del testo per preservare il layout.

**Posso convertire un rettangolo in un’immagine raster o SVG?**

Sì. Puoi [render the shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getImage) in un’immagine con dimensione/scala specificata oppure [export it as SVG](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/writeassvg/) per utilizzo vettoriale.

**Come ottengo rapidamente le proprietà effettive (effective) di un rettangolo considerando tema ed ereditarietà?**

[Use the shape’s effective properties](/slides/it/nodejs-java/shape-effective-properties/): l’API restituisce i valori calcolati che tengono conto degli stili del tema, del layout e delle impostazioni locali, semplificando l’analisi della formattazione.