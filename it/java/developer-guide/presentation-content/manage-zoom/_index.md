---
title: Gestire lo Zoom della presentazione in Java
linktitle: Gestisci Zoom
type: docs
weight: 60
url: /it/java/manage-zoom/
keywords:
- zoom
- frame zoom
- zoom diapositiva
- zoom sezione
- zoom riepilogo
- aggiungi zoom
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Crea e personalizza lo Zoom con Aspose.Slides per Java — passa tra le sezioni, aggiungi miniature e transizioni nei file PPT, PPTX e ODP."
---
## **Introduzione**

Gli Zoom in PowerPoint consentono di passare da e verso diapositive, sezioni e parti specifiche di una presentazione. Quando si presenta, questa capacità di navigare rapidamente tra i contenuti può risultare molto utile. 

![overview_image](overview.png)

* Per riassumere un'intera presentazione su una singola diapositiva, utilizza uno [Summary Zoom](#Summary-Zoom).
* Per mostrare solo le diapositive selezionate, utilizza uno [Slide Zoom](#Slide-Zoom).
* Per mostrare una sola sezione, utilizza uno [Section Zoom](#Section-Zoom).

## **Zoom diapositiva**
Uno zoom diapositiva può rendere la tua presentazione più dinamica, consentendo di navigare liberamente tra le diapositive in qualsiasi ordine tu scelga senza interrompere il flusso della presentazione. Gli zoom diapositiva sono ottimi per presentazioni brevi senza molte sezioni, ma possono comunque essere utilizzati in diversi scenari di presentazione.

Gli zoom diapositiva ti aiutano a approfondire più informazioni contemporaneamente, facendo sembrare di essere su un'unica tela. 

![overview_image](slidezoomsel.png)

Per gli oggetti zoom diapositiva, Aspose.Slides fornisce l'enumerazione [ZoomImageType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ZoomImageType), l'interfaccia [IZoomFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/IZoomFrame) e alcuni metodi dell'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection).

### **Creare frame zoom**

Puoi aggiungere un frame zoom su una diapositiva in questo modo:

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2.	Crea nuove diapositive a cui desideri collegare i frame zoom. 
3.	Aggiungi un testo di identificazione e uno sfondo alle diapositive create.
4.	Aggiungi i frame zoom (contenenti i riferimenti alle diapositive create) alla prima diapositiva.
5.	Salva la presentazione modificata come file PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Aggiunge nuove diapositive alla presentazione
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Crea uno sfondo per la seconda diapositiva
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Crea una casella di testo per la seconda diapositiva
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Crea uno sfondo per la terza diapositiva
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Crea una casella di testo per la terza diapositiva
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Aggiunge oggetti ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Salva la presentazione
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Creare frame zoom con immagini personalizzate**
Con Aspose.Slides per Java, puoi creare un frame zoom con un'immagine di anteprima della diapositiva diversa in questo modo: 
1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2.	Crea una nuova diapositiva a cui desideri collegare il frame zoom. 
3.	Aggiungi un testo di identificazione e uno sfondo alla diapositiva.
4.	Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPPImage) aggiungendo un'immagine alla collezione Images associata all'oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) che verrà utilizzata per riempire il frame.
5.	Aggiungi i frame zoom (contenenti il riferimento alla diapositiva creata) alla prima diapositiva.
6.	Salva la presentazione modificata come file PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Aggiunge una nuova diapositiva alla presentazione
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Crea uno sfondo per la seconda diapositiva
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Crea una casella di testo per la terza diapositiva
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Crea una nuova immagine per l'oggetto zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Aggiunge l'oggetto ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Salva la presentazione
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formattare i frame zoom**
Nelle sezioni precedenti, ti abbiamo mostrato come creare semplici frame zoom. Per creare frame zoom più complessi, è necessario modificare la formattazione di un semplice frame. Sono disponibili diverse opzioni di formattazione che puoi applicare a un frame zoom. 

Puoi controllare la formattazione di un frame zoom su una diapositiva in questo modo:

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2.	Crea nuove diapositive a cui desideri collegare il frame zoom. 
3.	Aggiungi del testo di identificazione e uno sfondo alle diapositive create.
4.	Aggiungi i frame zoom (contenenti i riferimenti alle diapositive create) alla prima diapositiva.
5.	Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPPImage) aggiungendo un'immagine alla collezione Images associata all'oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) che verrà utilizzata per riempire il frame.
6.	Imposta un'immagine personalizzata per il primo oggetto frame zoom.
7.	Modifica il formato della linea per il secondo oggetto frame zoom.
8.	Rimuovi lo sfondo da un'immagine del secondo oggetto frame zoom.
9.	Scrivi la presentazione modificata come file PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Aggiunge nuove diapositive alla presentazione
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Crea uno sfondo per la seconda diapositiva
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Crea una casella di testo per la seconda diapositiva
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Crea uno sfondo per la terza diapositiva
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Crea una casella di testo per la terza diapositiva
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Aggiunge oggetti ZoomFrame
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Crea una nuova immagine per l'oggetto zoom
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Imposta un'immagine personalizzata per l'oggetto zoomFrame1
    zoomFrame1.setImage(picture);

    // Imposta un formato di frame zoom per l'oggetto zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Impostazione per non mostrare lo sfondo per l'oggetto zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Salva la presentazione
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zoom sezione**

Uno zoom sezione è un collegamento a una sezione della tua presentazione. Puoi utilizzare lo zoom sezione per tornare a sezioni che desideri enfatizzare davvero. Oppure puoi usarlo per evidenziare come certe parti della tua presentazione si collegano. 

![overview_image](seczoomsel.png)

Per gli oggetti zoom sezione, Aspose.Slides fornisce l'interfaccia [ISectionZoomFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISectionZoomFrame) e alcuni metodi dell'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection).

### **Creare frame zoom sezione**

Puoi aggiungere un frame zoom sezione a una diapositiva in questo modo:

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2.	Crea una nuova diapositiva. 
3.	Aggiungi uno sfondo di identificazione alla diapositiva creata.
4.	Crea una nuova sezione a cui desideri collegare il frame zoom. 
5.	Aggiungi un frame zoom sezione (contenente i riferimenti alla sezione creata) alla prima diapositiva.
6.	Scrivi la presentazione modificata come file PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Aggiunge una nuova diapositiva alla presentazione
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Aggiunge una nuova sezione alla presentazione
    pres.getSections().addSection("Section 1", slide);

    // Aggiunge un oggetto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Salva la presentazione
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Creare frame zoom sezione con immagini personalizzate**

Usando Aspose.Slides per Java, puoi creare un frame zoom sezione con un'immagine di anteprima della diapositiva diversa in questo modo: 

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2.	Crea una nuova diapositiva.
3.	Aggiungi uno sfondo di identificazione alla diapositiva creata.
4.	Crea una nuova sezione a cui desideri collegare il frame zoom. 
5.	Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPPImage) aggiungendo un'immagine alla collezione Images associata all'oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) che verrà utilizzata per riempire il frame.
6.	Aggiungi un frame zoom sezione (contenente un riferimento alla sezione creata) alla prima diapositiva.
7.	Scrivi la presentazione modificata come file PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Aggiunge una nuova diapositiva alla presentazione
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Aggiunge una nuova sezione alla presentazione
    pres.getSections().addSection("Section 1", slide);

    // Crea una nuova immagine per l'oggetto zoom
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Aggiunge un oggetto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Salva la presentazione
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formattare i frame zoom sezione**

Per creare frame zoom sezione più complessi, è necessario modificare la formattazione di un semplice frame. Sono disponibili diverse opzioni di formattazione che puoi applicare a un frame zoom sezione. 

Puoi controllare la formattazione di un frame zoom sezione su una diapositiva in questo modo:

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2.	Crea una nuova diapositiva.
3.	Aggiungi uno sfondo di identificazione alla diapositiva creata.
4.	Crea una nuova sezione a cui desideri collegare il frame zoom. 
5.	Aggiungi un frame zoom sezione (contenente i riferimenti alla sezione creata) alla prima diapositiva.
6.	Modifica la dimensione e la posizione dell'oggetto zoom sezione creato.
7.	Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPPImage) aggiungendo un'immagine alla collezione images associata all'oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) che verrà utilizzata per riempire il frame.
8.	Imposta un'immagine personalizzata per l'oggetto frame zoom sezione creato.
9.	Imposta la funzionalità *ritorno alla diapositiva originale dalla sezione collegata*.
10.	Rimuovi lo sfondo da un'immagine dell'oggetto frame zoom sezione.
11.	Modifica il formato della linea per il secondo oggetto frame zoom.
12.	Modifica la durata della transizione.
13.	Scrivi la presentazione modificata come file PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Aggiunge una nuova diapositiva alla presentazione
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Aggiunge una nuova sezione alla presentazione
    pres.getSections().addSection("Section 1", slide);

    // Aggiunge oggetto SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Formattazione per SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // Salva la presentazione
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Zoom riepilogo**

Uno zoom riepilogo è simile a una pagina di destinazione dove tutti gli elementi della tua presentazione sono visualizzati contemporaneamente. Quando presenti, puoi usare lo zoom per passare da un punto della presentazione a un altro in qualsiasi ordine desideri. Puoi essere creativo, saltare avanti o rivisitare parti della tua presentazione senza interrompere il flusso.

![overview_image](sumzoomsel.png)

Per gli oggetti zoom riepilogo, Aspose.Slides fornisce le interfacce [ISummaryZoomFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISummaryZoomSection) e [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISummaryZoomSectionCollection) e alcuni metodi dell'interfaccia [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection).

### **Creare uno Zoom riepilogo**

Puoi aggiungere un frame zoom riepilogo a una diapositiva in questo modo:

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2.	Crea nuove diapositive con sfondo di identificazione e nuove sezioni per le diapositive create.
3.	Aggiungi il frame zoom riepilogo alla prima diapositiva.
4.	Scrivi la presentazione modificata come file PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Aggiunge una nuova diapositiva alla presentazione
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Aggiunge una nuova sezione alla presentazione
    pres.getSections().addSection("Section 1", slide);

    //Aggiunge una nuova diapositiva alla presentazione
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Aggiunge una nuova sezione alla presentazione
    pres.getSections().addSection("Section 2", slide);

    //Aggiunge una nuova diapositiva alla presentazione
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Aggiunge una nuova sezione alla presentazione
    pres.getSections().addSection("Section 3", slide);

    //Aggiunge una nuova diapositiva alla presentazione
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Aggiunge una nuova sezione alla presentazione
    pres.getSections().addSection("Section 4", slide);

    // Aggiunge un oggetto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Salva la presentazione
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Aggiungere e rimuovere una sezione Zoom riepilogo**

Tutte le sezioni in un frame zoom riepilogo sono rappresentate da oggetti [ISummaryZoomSection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISummaryZoomSection), che sono memorizzati nell'oggetto [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/ISummaryZoomSectionCollection). Puoi aggiungere o rimuovere un oggetto sezione zoom riepilogo tramite l'interfaccia [ISummaryZoomSectionCollection] in questo modo:

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2.	Crea nuove diapositive con sfondo di identificazione e nuove sezioni per le diapositive create.
3.	Aggiungi un frame zoom riepilogo nella prima diapositiva.
4.	Aggiungi una nuova diapositiva e una nuova sezione alla presentazione.
5.	Aggiungi la sezione creata al frame zoom riepilogo.
6.	Rimuovi la prima sezione dal frame zoom riepilogo.
7.	Scrivi la presentazione modificata come file PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Aggiunge una nuova diapositiva alla presentazione
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Aggiunge una nuova sezione alla presentazione
    pres.getSections().addSection("Section 1", slide);

    //Aggiunge una nuova diapositiva alla presentazione
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Aggiunge una nuova sezione alla presentazione
    pres.getSections().addSection("Section 2", slide);

    //Aggiunge un oggetto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Aggiunge una nuova diapositiva alla presentazione
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Aggiunge una nuova sezione alla presentazione
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    //Aggiunge una sezione allo Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    //Rimuove una sezione dallo Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    //Salva la presentazione
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formattare le sezioni Zoom riepilogo**

Per creare oggetti sezione zoom riepilogo più complessi, è necessario modificare la formattazione di un semplice frame. Sono disponibili diverse opzioni di formattazione che puoi applicare a un oggetto sezione zoom riepilogo. 

Puoi controllare la formattazione di un oggetto sezione zoom riepilogo in un frame zoom riepilogo in questo modo:

1.	Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
2.	Crea nuove diapositive con sfondo di identificazione e nuove sezioni per le diapositive create.
3.	Aggiungi un frame zoom riepilogo alla prima diapositiva.
4.	Recupera un oggetto sezione zoom riepilogo per il primo oggetto dalla `ISummaryZoomSectionCollection`.
5.	Crea un oggetto [IPPImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPPImage) aggiungendo un'immagine alla collezione images associata all'oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation) che verrà utilizzata per riempire il frame.
6.	Imposta un'immagine personalizzata per l'oggetto frame zoom sezione creato.
7.	Imposta la funzionalità *ritorno alla diapositiva originale dalla sezione collegata*. 
8.	Modifica il formato della linea per il secondo oggetto frame zoom.
9.	Modifica la durata della transizione.
10.	Scrivi la presentazione modificata come file PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Aggiunge una nuova diapositiva alla presentazione
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Aggiunge una nuova sezione alla presentazione
    pres.getSections().addSection("Section 1", slide);

    //Aggiunge una nuova diapositiva alla presentazione
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Aggiunge una nuova sezione alla presentazione
    pres.getSections().addSection("Section 2", slide);

    //Aggiunge un oggetto SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Ottiene il primo oggetto SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    //Formattazione per l'oggetto SummaryZoomSection
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    //Salva la presentazione
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso controllare il ritorno alla diapositiva 'genitore' dopo aver mostrato il target?**

Sì. Il [Zoom frame](https://reference.aspose.com/slides/it/java/com.aspose.slides/zoomframe/) o la [section](https://reference.aspose.com/slides/it/java/com.aspose.slides/sectionzoomframe/) ha un comportamento `ReturnToParent` che, quando abilitato, riporta gli spettatori alla diapositiva di origine dopo aver visualizzato il contenuto target.

**Posso regolare la 'velocità' o la durata della transizione Zoom?**

Sì. Lo Zoom supporta l'impostazione di `TransitionDuration` così puoi controllare quanto tempo dura l'animazione di salto.

**Ci sono limiti al numero di oggetti Zoom che una presentazione può contenere?**

Non è documentato un limite rigido dell'API. I limiti pratici dipendono dalla complessità complessiva della presentazione e dalle prestazioni del visualizzatore. È possibile aggiungere molti frame Zoom, ma è bene considerare la dimensione del file e i tempi di rendering.