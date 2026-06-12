---
title: Aggiungi forme di linea alle presentazioni su Android
linktitle: Linea
type: docs
weight: 50
url: /it/androidjava/Line/
keywords:
- linea
- crea linea
- aggiungi linea
- linea semplice
- configura linea
- personalizza linea
- stile tratteggio
- punta freccia
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Impara a manipolare la formattazione delle linee nelle presentazioni PowerPoint con Aspose.Slides per Android. Scopri proprietà, metodi ed esempi Java."
---
## **Panoramica**

Aspose.Slides consente di aggiungere forme di linea alle diapositive PowerPoint in modo programmatico. Questo articolo mostra come creare una semplice linea e come personalizzare una linea affinché appaia come una freccia.

Imparerai come aggiungere una forma di linea a una diapositiva, regolare il suo aspetto visivo e salvare la presentazione aggiornata. Gli esempi si concentrano su impostazioni pratiche di formattazione della linea come stile, larghezza, modello di tratteggio, opzioni della punta della freccia e colore di riempimento.

## **Crea una Linea Semplice**

Per aggiungere una semplice linea a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
- Ottieni il riferimento di una diapositiva usando il suo indice.
- Aggiungi un'AutoShape di tipo Linea usando il metodo [addAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [IShapeCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection).
- Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto una linea alla prima diapositiva della presentazione.

```java
// Istanzia la classe PresentationEx che rappresenta il file PPTX
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Aggiungi un'AutoShape di tipo line
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Scrivi il PPTX su disco
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Crea una Linea a Forma di Freccia**

Aspose.Slides per Android via Java consente inoltre agli sviluppatori di configurare alcune proprietà della linea per renderla più accattivante. Proviamo a configurare alcune proprietà di una linea per farla sembrare una freccia. Segui i passaggi seguenti per farlo:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation).
- Ottieni il riferimento di una diapositiva usando il suo indice.
- Aggiungi un'AutoShape di tipo Linea usando il metodo [addAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [IShapeCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IShapeCollection).
- Imposta lo [Line Style](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LineStyle) su uno degli stili forniti da Aspose.Slides per Android via Java.
- Imposta la larghezza della linea.
- Imposta lo [Dash Style](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LineDashStyle) della linea su uno degli stili offerti da Aspose.Slides per Android via Java.
- Imposta lo [Arrow Head Style](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LineArrowheadStyle) e la [Length](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LineArrowheadLength) del punto iniziale della linea.
- Imposta lo [Arrow Head Style](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LineArrowheadStyle) e la [Length](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/LineArrowheadLength) del punto finale della linea.
- Scrivi la presentazione modificata come file PPTX.

```java
// Istanzia la classe PresentationEx che rappresenta il file PPTX
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiungi un'AutoShape di tipo line
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Applica qualche formattazione sulla linea
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

**Posso convertire una linea normale in un connettore così si aggancia alle forme?**

No. Una linea normale (un [AutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/) di tipo [Line](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/shapetype/)) non diventa automaticamente un connettore. Per farla agganciare alle forme, utilizza il tipo dedicato [Connector](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/connector/) e le [API corrispondenti](/slides/it/androidjava/connector/) per le connessioni.

**Cosa devo fare se le proprietà di una linea sono ereditate dal tema e risulta difficile determinarne i valori finali?**

[Leggi le proprietà effettive](/slides/it/androidjava/shape-effective-properties/) attraverso le interfacce [ILineFormatEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — queste tengono già conto dell'ereditarietà e degli stili del tema.

**Posso bloccare una linea contro la modifica (spostamento, ridimensionamento)?**

Sì. Le forme forniscono [lock objects](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) che consentono di vietare le operazioni di modifica.