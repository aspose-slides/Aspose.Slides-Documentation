---
title: Aggiungere forme di linea alle presentazioni in Java
linktitle: Linea
type: docs
weight: 50
url: /it/java/Line/
keywords:
- linea
- creare linea
- aggiungere linea
- linea semplice
- configurare linea
- personalizzare linea
- stile tratteggiato
- punta di freccia
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Impara a manipolare la formattazione delle linee nelle presentazioni PowerPoint con Aspose.Slides per Java. Scopri proprietà, metodi ed esempi."
---
## **Panoramica**

Aspose.Slides consente di aggiungere forme di linea alle diapositive PowerPoint in modo programmatico. Questo articolo mostra come creare una linea semplice e come personalizzarla in modo che appaia come una freccia.

Imparerai come aggiungere una forma di linea a una diapositiva, regolare il suo aspetto visivo e salvare la presentazione aggiornata. Gli esempi si concentrano su impostazioni pratiche di formattazione della linea come stile, larghezza, pattern tratteggiato, opzioni di punta di freccia e colore di riempimento.

## **Creare una linea semplice**

- Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
- Ottenere il riferimento di una diapositiva usando il suo indice.
- Aggiungere un'AutoShape di tipo Line utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection).
- Scrivere la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto una linea alla prima diapositiva della presentazione.

```java
// Instanzia la classe PresentationEx che rappresenta il file PPTX
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

## **Creare una linea a forma di freccia**

- Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
- Ottenere il riferimento di una diapositiva usando il suo indice.
- Aggiungere un'AutoShape di tipo Line utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection).
- Impostare lo [Line Style](https://reference.aspose.com/slides/it/java/com.aspose.slides/LineStyle) su uno degli stili offerti da Aspose.Slides per Java.
- Impostare la larghezza della linea.
- Impostare lo [Dash Style](https://reference.aspose.com/slides/it/java/com.aspose.slides/LineDashStyle) della linea su uno degli stili offerti da Aspose.Slides per Java.
- Impostare lo [Arrow Head Style](https://reference.aspose.com/slides/it/java/com.aspose.slides/LineArrowheadStyle) e la [Length](https://reference.aspose.com/slides/it/java/com.aspose.slides/LineArrowheadLength) del punto di inizio della linea.
- Impostare lo [Arrow Head Style](https://reference.aspose.com/slides/it/java/com.aspose.slides/LineArrowheadStyle) e la [Length](https://reference.aspose.com/slides/it/java/com.aspose.slides/LineArrowheadLength) del punto di fine della linea.
- Scrivere la presentazione modificata come file PPTX.

```java
// Instanzia la classe PresentationEx che rappresenta il file PPTX
Presentation pres = new Presentation();
try {
    // Ottieni la prima diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Aggiungi un'AutoShape di tipo linea
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Applica alcune formattazioni sulla linea
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

No. Una linea regolare (un [AutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/) di tipo [Line](https://reference.aspose.com/slides/it/java/com.aspose.slides/shapetype/)) non diventa automaticamente un connettore. Per farla agganciare alle forme, utilizzare il tipo [Connector](https://reference.aspose.com/slides/it/java/com.aspose.slides/connector/) dedicato e le [API corrispondenti](/slides/it/java/connector/) per le connessioni.

**Cosa devo fare se le proprietà di una linea sono ereditate dal tema e risulta difficile determinare i valori finali?**

Leggi le [proprietà effettive](/slides/it/java/shape-effective-properties/) tramite le interfacce [ILineFormatEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinefillformateffectivedata/)—queste tengono già conto dell'ereditarietà e degli stili del tema.

**Posso bloccare una linea contro le modifiche (spostamento, ridimensionamento)?**

Sì. Le forme forniscono [lock objects](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/#getAutoShapeLock--) che consentono di [disallow editing operations](/slides/it/java/applying-protection-to-presentation/).