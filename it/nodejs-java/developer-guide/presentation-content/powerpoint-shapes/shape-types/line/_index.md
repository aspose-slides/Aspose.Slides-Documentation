---
title: Aggiungi forme di linea alle presentazioni in JavaScript
linktitle: Linea
type: docs
weight: 50
url: /it/nodejs-java/line/
keywords:
- linea
- crea linea
- aggiungi linea
- linea semplice
- configura linea
- personalizza linea
- stile tratto
- punta della freccia
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Impara a manipolare la formattazione delle linee nelle presentazioni PowerPoint con JavaScript e Aspose.Slides per Node.js. Scopri proprietà, metodi ed esempi."
---
## **Panoramica**

Aspose.Slides consente di aggiungere forme lineari alle diapositive PowerPoint in modo programmatico. Questo articolo mostra come creare una linea semplice e come personalizzare una linea in modo che appaia come una freccia.

Imparerai come aggiungere una forma a linea a una diapositiva, regolare il suo aspetto visivo e salvare la presentazione aggiornata. Gli esempi si concentrano su impostazioni pratiche di formattazione della linea come stile, larghezza, pattern di trattini, opzioni di punta della freccia e colore di riempimento.

## **Crea linea semplice**

Per aggiungere una linea semplice a una diapositiva selezionata della presentazione, segui i passaggi seguenti:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
- Ottieni il riferimento di una diapositiva usando il suo indice.
- Aggiungi un'AutoShape di tipo Linea utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection).
- Scrivi la presentazione modificata come file PPTX.

Nell'esempio mostrato di seguito, abbiamo aggiunto una linea alla prima diapositiva della presentazione.

```javascript
// Instanzia la classe PresentationEx che rappresenta il file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Recupera la prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Aggiungi un'AutoShape di tipo linea
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Scrivi il PPTX su disco
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Crea linea a forma di freccia**

Aspose.Slides per Node.js tramite Java consente inoltre agli sviluppatori di configurare alcune proprietà della linea per renderla più gradevole. Proviamo a configurare alcune proprietà di una linea per farla sembrare una freccia. Segui i passaggi seguenti per farlo:

- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/Presentation).
- Ottieni il riferimento di una diapositiva usando il suo indice.
- Aggiungi un'AutoShape di tipo Linea utilizzando il metodo [addAutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) esposto dall'oggetto [ShapeCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ShapeCollection).
- Imposta lo [Stile della linea](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/LineStyle) su uno dei modelli offerti da Aspose.Slides per Node.js tramite Java.
- Imposta la larghezza della linea.
- Imposta lo [Stile del tratto](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/LineDashStyle) della linea su uno dei modelli offerti da Aspose.Slides per Node.js tramite Java.
- Imposta lo [Stile della punta della freccia](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/LineArrowheadStyle) e la [Lunghezza](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/LineArrowheadLength) del punto iniziale della linea.
- Imposta lo [Stile della punta della freccia](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/LineArrowheadStyle) e la [Lunghezza](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/LineArrowheadLength) del punto finale della linea.
- Scrivi la presentazione modificata come file PPTX.

```javascript
// Instanzia la classe PresentationEx che rappresenta il file PPTX
var pres = new aspose.slides.Presentation();
try {
    // Ottieni la prima diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Aggiungi un'AutoShape di tipo linea
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Applica alcune formattazioni alla linea
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Scrivi il PPTX su disco
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso convertire una linea normale in un connettore in modo che si "agganci" alle forme?**

No. Una linea normale (un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) di tipo [Line](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapetype/)) non diventa automaticamente un connettore. Per farla agganciare alle forme, utilizza il tipo [Connector](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/connector/) dedicato e le [API corrispondenti](/slides/it/nodejs-java/connector/) per le connessioni.

**Cosa devo fare se le proprietà di una linea sono ereditate dal tema e risulta difficile determinare i valori finali?**

[Leggi le proprietà effettive](/slides/it/nodejs-java/shape-effective-properties/) tramite le classi `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` — queste tengono già conto dell'ereditarietà e degli stili del tema.

**Posso bloccare una linea contro la modifica (spostamento, ridimensionamento)?**

Sì. Le forme forniscono [oggetti di blocco](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/getautoshapelock/) che consentono di impedire operazioni di modifica.