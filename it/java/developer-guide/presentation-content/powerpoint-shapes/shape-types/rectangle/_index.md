---
title: Aggiungi rettangoli alle presentazioni in Java
linktitle: Rettangolo
type: docs
weight: 80
url: /it/java/rectangle/
keywords:
- aggiungere rettangolo
- creare rettangolo
- forma rettangolare
- rettangolo semplice
- rettangolo formattato
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Migliora le tue presentazioni PowerPoint aggiungendo rettangoli con Aspose.Slides per Java—progetta e modifica facilmente le forme in modo programmatico."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme rettangolari alle diapositive PowerPoint utilizzando Aspose.Slides. Copre la creazione di un rettangolo semplice, la creazione di un rettangolo formattato e il salvataggio della presentazione aggiornata come file PPTX.

Vedrai anche come applicare una formattazione di base del rettangolo, come un colore di riempimento solido, il colore della linea e lo spessore della linea. Inoltre, la sezione FAQ dell'articolo indica attività correlate al rettangolo, inclusi angoli arrotondati, riempimenti con immagine, effetti visivi, collegamenti ipertestuali, blocchi della forma, opzioni di esportazione e proprietà effettive.

## **Aggiungere un Rettangolo a una Diapositiva**
Per aggiungere un rettangolo semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
- Ottieni il riferimento di una diapositiva usando il suo indice.
- Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAutoShape) di tipo Rectangle utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection).
- Scrivi la presentazione modificata come file PPTX.

Nell'esempio riportato di seguito, abbiamo aggiunto un rettangolo semplice alla prima diapositiva della presentazione.

```java
// Istanzia la classe Presentation che rappresenta il PPTX
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiungi AutoShape di tipo ellisse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Scrivi il file PPTX su disco
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aggiungere un Rettangolo Formattato a una Diapositiva**
Per aggiungere un rettangolo formattato a una diapositiva, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentazione](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation).
- Ottieni il riferimento di una diapositiva usando il suo indice.
- Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IAutoShape) di tipo Rectangle utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection).
- Imposta il [Fill Type](https://reference.aspose.com/slides/it/java/com.aspose.slides/FillType) del Rectangle a Solid.
- Imposta il colore del Rectangle utilizzando il metodo [SolidFillColor.setColor](https://reference.aspose.com/slides/it/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) esposto dall'oggetto [IFillFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/IFillFormat) associato all'oggetto [IShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShape).
- Imposta il colore delle linee del Rectangle.
- Imposta lo spessore delle linee del Rectangle.
- Scrivi la presentazione modificata come file PPTX.

I passaggi sopra sono implementati nell'esempio riportato di seguito.

```java
// Istanzia la classe Presentation che rappresenta il PPTX
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiungi AutoShape di tipo ellisse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Applica una formattazione alla forma ellisse
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Applica una formattazione alla linea dell'ellisse
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Scrivi il file PPTX su disco
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Come aggiungere un rettangolo con angoli arrotondati?**

Utilizza il [shape type](https://reference.aspose.com/slides/it/java/com.aspose.slides/shapetype/) con angolo arrotondato e regola il raggio dell'angolo nelle proprietà della forma; l'arrotondamento può essere applicato anche per singolo angolo tramite aggiustamenti geometrici.

**Come riempire un rettangolo con un'immagine (texture)?**

Seleziona il [fill type](https://reference.aspose.com/slides/it/java/com.aspose.slides/filltype/) immagine, fornisci la sorgente dell'immagine e configura le [stretching/tiling modes](https://reference.aspose.com/slides/it/java/com.aspose.slides/picturefillmode/).

**Un rettangolo può avere ombra e bagliore?**

Sì. Sono disponibili [Outer/inner shadow, glow, and soft edges](/slides/it/java/shape-effect/) con parametri regolabili.

**Posso trasformare un rettangolo in un pulsante con un collegamento ipertestuale?**

Sì. [Assign a hyperlink](/slides/it/java/manage-hyperlinks/) al clic della forma (salto a una diapositiva, file, indirizzo web o e‑mail).

**Come posso proteggere un rettangolo da spostamenti e modifiche?**

[Use shape locks](/slides/it/java/applying-protection-to-presentation/): è possibile vietare lo spostamento, il ridimensionamento, la selezione o la modifica del testo per preservare il layout.

**Posso convertire un rettangolo in un'immagine raster o SVG?**

Sì. È possibile [render the shape](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#getImage-int-float-float-) in un'immagine con dimensione/scala specificata oppure [export it as SVG](https://reference.aspose.com/slides/it/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) per uso vettoriale.

**Come ottenere rapidamente le proprietà effettive (effective) di un rettangolo considerando tema ed ereditarietà?**

[Use the shape’s effective properties](/slides/it/java/shape-effective-properties/): l'API restituisce valori calcolati che tengono conto di stili del tema, layout e impostazioni locali, semplificando l'analisi della formattazione.