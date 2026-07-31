---
title: Aggiungi forme di linea alle presentazioni su Android
linktitle: Linea
type: docs
weight: 50
url: /it/androidjava/line/
keywords:
- linea
- crea linea
- aggiungi linea
- linea semplice
- configura linea
- personalizza linea
- stile tratteggio
- punta di freccia
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Impara a manipolare la formattazione delle linee nelle presentazioni PowerPoint con Aspose.Slides per Android. Scopri proprietà, metodi ed esempi Java."
---
## **Panoramica**

Aspose.Slides consente di aggiungere forme di linea alle diapositive PowerPoint in modo programmatico. Questo articolo mostra come creare una linea semplice e come personalizzare una linea in modo che appaia come una freccia.

Imparerai come aggiungere una forma di linea a una diapositiva, regolare il suo aspetto visivo e salvare la presentazione aggiornata. Gli esempi si concentrano su impostazioni pratiche di formattazione della linea come stile, spessore, modello di tratteggio, opzioni della punta della freccia e colore di riempimento.

## **Crea una linea semplice**

Per aggiungere una semplice linea semplice a una diapositiva selezionata della presentazione, segui i passaggi riportati di seguito:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
- Ottieni il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungi un'AutoShape di tipo Line utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [IShapeCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection).
- Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto una linea alla prima diapositiva della presentazione.

```java
// Istanzia la classe PresentationEx che rappresenta il file PPTX
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Aggiungi un'AutoShape di tipo linea
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Scrivi il PPTX su disco
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Crea una linea con punta a freccia**

Aspose.Slides for Android via Java consente inoltre agli sviluppatori di configurare alcune proprietà della linea per renderla più gradevole. Proviamo a configurare alcune proprietà della linea in modo che assomigli a una freccia. Segui i passaggi riportati di seguito per farlo:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
- Ottieni il riferimento di una diapositiva utilizzando il suo indice.
- Aggiungi un'AutoShape di tipo Line utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [IShapeCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection).
- Imposta lo [Line Style](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LineStyle) a uno degli stili offerti da Aspose.Slides per Android via Java.
- Imposta la larghezza della linea.
- Imposta lo [Dash Style](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LineDashStyle) della linea a uno degli stili offerti da Aspose.Slides per Android via Java.
- Imposta lo [Arrow Head Style](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LineArrowheadStyle) e la [Length](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LineArrowheadLength) del punto di inizio della linea.
- Imposta lo [Arrow Head Style](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LineArrowheadStyle) e la [Length](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LineArrowheadLength) del punto finale della linea.
- Scrivi la presentazione modificata come file PPTX.

```java
// Instanzia la classe PresentationEx che rappresenta il file PPTX
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiungi un'AutoShape di tipo linea
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Applica alcune formattazioni alla linea
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Scrivi il PPTX su disco
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso convertire una linea regolare in un connettore in modo che si "agganci" alle forme?**

No. Una linea regolare (un [AutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/) di tipo [Line](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shapetype/)) non diventa automaticamente un connettore. Per farla agganciare alle forme, utilizza il tipo dedicato [Connector](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/connector/) e le [corresponding APIs](/slides/it/androidjava/connector/) per le connessioni.

**Cosa devo fare se le proprietà di una linea sono ereditate dal tema e risulta difficile determinare i valori finali?**

[Leggi le proprietà effettive](/slides/it/androidjava/shape-effective-properties/) tramite le interfacce [ILineFormatEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — queste tengono già conto dell’eredità e degli stili del tema.

**Posso bloccare una linea contro modifiche (spostamento, ridimensionamento)?**

Sì. Le forme forniscono [lock objects](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) che consentono di impedire le operazioni di modifica.