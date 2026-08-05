---
title: Aggiungi forme di linea alle presentazioni in Java
linktitle: Linea
type: docs
weight: 50
url: /it/java/line/
keywords:
- linea
- creare linea
- aggiungere linea
- linea semplice
- configurare linea
- personalizzare linea
- stile tratteggiato
- testa di freccia
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Impara a manipolare la formattazione delle linee nelle presentazioni PowerPoint con Aspose.Slides per Java. Scopri proprietà, metodi ed esempi."
---
## **Panoramica**

Aspose.Slides consente di aggiungere forme di linea alle diapositive PowerPoint in modo programmatico. Questo articolo mostra come creare una semplice linea e come personalizzarla affinché appaia come una freccia.

Imparerai come aggiungere una forma di linea a una diapositiva, regolare l’aspetto visivo e salvare la presentazione aggiornata. Gli esempi si concentrano su impostazioni pratiche di formattazione della linea come stile, larghezza, schema tratteggiato, opzioni di estremità della freccia e colore di riempimento.

## **Creare una linea semplice**

- Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
- Ottieni il riferimento di una diapositiva usando il suo indice.
- Aggiungi un’AutoShape di tipo Line usando il metodo [addAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall’oggetto [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection).
- Scrivi la presentazione modificata come file PPTX.

Nell’esempio mostrato di seguito, abbiamo aggiunto una linea alla prima diapositiva della presentazione.

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

## **Creare una linea a forma di freccia**

Aspose.Slides for Java consente anche agli sviluppatori di configurare alcune proprietà della linea per renderla più accattivante. Proviamo a configurare alcune proprietà della linea per farla sembrare una freccia. Segui i passaggi seguenti:

- Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/Presentation).
- Ottieni il riferimento di una diapositiva usando il suo indice.
- Aggiungi un’AutoShape di tipo Line usando il metodo [addAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall’oggetto [IShapeCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/IShapeCollection).
- Imposta lo [Line Style](https://reference.aspose.com/slides/it/java/com.aspose.slides/LineStyle) su uno degli stili offerti da Aspose.Slides for Java.
- Imposta la larghezza della linea.
- Imposta lo [Dash Style](https://reference.aspose.com/slides/it/java/com.aspose.slides/LineDashStyle) della linea su uno degli stili offerti da Aspose.Slides for Java.
- Imposta lo [Arrow Head Style](https://reference.aspose.com/slides/it/java/com.aspose.slides/LineArrowheadStyle) e la [Length](https://reference.aspose.com/slides/it/java/com.aspose.slides/LineArrowheadLength) del punto di inizio della linea.
- Imposta lo [Arrow Head Style](https://reference.aspose.com/slides/it/java/com.aspose.slides/LineArrowheadStyle) e la [Length](https://reference.aspose.com/slides/it/java/com.aspose.slides/LineArrowheadLength) del punto finale della linea.
- Scrivi la presentazione modificata come file PPTX.

```java
// Istanzia la classe PresentationEx che rappresenta il file PPTX
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

**Posso convertire una linea normale in un connettore in modo che si "agganci" alle forme?**

No. Una linea normale (un [AutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/) di tipo [Line](https://reference.aspose.com/slides/it/java/com.aspose.slides/shapetype/)) non diventa automaticamente un connettore. Per farla agganciare alle forme, utilizza il tipo dedicato [Connector](https://reference.aspose.com/slides/it/java/com.aspose.slides/connector/) e le [API corrispondenti](/slides/it/java/connector/) per le connessioni.

**Che cosa devo fare se le proprietà di una linea sono ereditate dal tema e risulta difficile determinare i valori finali?**

Leggi le [proprietà effettive](/slides/it/java/shape-effective-properties/) tramite le interfacce [ILineFormatEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilinefillformateffectivedata/)—queste tengono già conto dell’ereditarietà e degli stili del tema.

**Posso bloccare una linea contro la modifica (spostamento, ridimensionamento)?**

Sì. Le forme forniscono [lock objects](https://reference.aspose.com/slides/it/java/com.aspose.slides/autoshape/#getAutoShapeLock--) che consentono di [impedire operazioni di modifica](/slides/it/java/applying-protection-to-presentation/).