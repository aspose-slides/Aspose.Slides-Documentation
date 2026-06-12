---
title: Aggiungi Rettangoli alle Presentazioni su Android
linktitle: Rettangolo
type: docs
weight: 80
url: /it/androidjava/rectangle/
keywords:
- aggiungi rettangolo
- crea rettangolo
- forma rettangolare
- rettangolo semplice
- rettangolo formattato
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Potenzia le tue presentazioni PowerPoint aggiungendo rettangoli con Aspose.Slides per Android via Java—progetta e modifica facilmente le forme programmaticamente."
---
## **Panoramica**

Questo articolo mostra come aggiungere forme rettangolari alle diapositive di PowerPoint utilizzando Aspose.Slides. Copre la creazione di un rettangolo semplice, la creazione di un rettangolo formattato e il salvataggio della presentazione aggiornata come file PPTX.

Vedrai anche come applicare la formattazione di base del rettangolo, come un colore di riempimento solido, il colore della linea e lo spessore della linea. Inoltre, le FAQ dell'articolo rimandano a operazioni correlate al rettangolo, tra cui angoli arrotondati, riempimenti con immagine, effetti visivi, collegamenti ipertestuali, blocchi della forma, opzioni di esportazione e proprietà efficaci.

## **Aggiungere un Rettangolo a una Diapositiva**
Per aggiungere un rettangolo semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
- Ottieni il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAutoShape) di tipo rettangolo utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [IShapeCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection).
- Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto un rettangolo semplice alla prima diapositiva della presentazione.

```java
// Instanzia la classe Presentation che rappresenta il PPTX
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

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation).
- Ottieni il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungi un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IAutoShape) di tipo rettangolo utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [IShapeCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection).
- Imposta il [Fill Type](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/FillType) del rettangolo su Solid.
- Imposta il colore del rettangolo utilizzando il metodo [SolidFillColor.setColor](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) esposto dall'oggetto [IFillFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IFillFormat) associato all'oggetto [IShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShape).
- Imposta il colore delle linee del rettangolo.
- Imposta lo spessore delle linee del rettangolo.
- Scrivi la presentazione modificata come file PPTX.

I passaggi sopra indicati sono implementati nell'esempio mostrato di seguito.

```java
// Instanzia la classe Presentation che rappresenta il PPTX
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

Utilizza il tipo di forma a angoli arrotondati [shape type](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shapetype/) e regola il raggio degli angoli nelle proprietà della forma; l'arrotondamento può essere applicato anche per singolo angolo tramite regolazioni geometriche.

**Come riempire un rettangolo con un'immagine (texture)?**

Seleziona il [fill type](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/filltype/) dell'immagine, fornisci la sorgente dell'immagine e configura le [modalità di stretching/tiling](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/picturefillmode/).

**Un rettangolo può avere ombra e bagliore?**

Sì. [Ombra esterna/interna, bagliore e bordi morbidi](/slides/it/androidjava/shape-effect/) sono disponibili con parametri regolabili.

**Posso trasformare un rettangolo in un pulsante con un hyperlink?**

Sì. [Assegna un hyperlink](/slides/it/androidjava/manage-hyperlinks/) al clic della forma (passa a una diapositiva, file, indirizzo web o e-mail).

**Come posso proteggere un rettangolo dallo spostamento e dalle modifiche?**

Utilizza i blocchi della forma: puoi vietare lo spostamento, il ridimensionamento, la selezione o la modifica del testo per preservare il layout.

**Posso convertire un rettangolo in un'immagine raster o SVG?**

Sì. Puoi [renderizzare la forma](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) in un'immagine con dimensioni/scala specificate o [esportarla come SVG](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) per uso vettoriale.

**Come ottenere rapidamente le proprietà reali (efficaci) di un rettangolo considerando il tema e l'eredità?**

[Utilizza le proprietà efficaci della forma](/slides/it/androidjava/shape-effective-properties/): l'API restituisce valori calcolati che tengono conto degli stili del tema, del layout e delle impostazioni locali, semplificando l'analisi della formattazione.