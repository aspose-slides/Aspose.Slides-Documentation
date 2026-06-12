---
title: Applicare effetti di forma nelle presentazioni con JavaScript
linktitle: Effetto forma
type: docs
weight: 30
url: /it/nodejs-java/shape-effect/
keywords:
- effetto forma
- effetto ombra
- effetto riflessione
- effetto bagliore
- effetto bordi morbidi
- formato effetto
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Trasforma i tuoi file PPT e PPTX con effetti di forma avanzati usando JavaScript e Aspose.Slides per Node.js—crea diapositive sorprendenti e professionali in pochi secondi."
---
## **Introduzione**

Mentre gli effetti in PowerPoint possono essere usati per far risaltare una forma, differiscono da [riempimenti](/slides/it/nodejs-java/shape-formatting/#gradient-fill) o contorni. Utilizzando gli effetti di PowerPoint, è possibile creare riflessi realistici su una forma, diffondere il bagliore di una forma, ecc.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint offre sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma. 

* Alcune combinazioni di effetti appaiono migliori di altre. Per questo motivo, le opzioni di PowerPoint si trovano sotto **Preset**. Le opzioni Preset sono essenzialmente una combinazione già nota e di bell'aspetto di due o più effetti. In questo modo, selezionando un preset, non dovrai perdere tempo a testare o combinare diversi effetti per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/EffectFormat) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applicare l'effetto ombra**

Questo codice JavaScript mostra come applicare l'effetto ombra esterna ([getOuterShadowEffect](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/EffectFormat#getOuterShadowEffect)) a un rettangolo:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "DARK_GRAY"));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Applicare l'effetto riflessione**

Questo codice JavaScript mostra come applicare l'effetto riflessione a una forma:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);
    pres.save("reflection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Applicare l'effetto bagliore**

Questo codice JavaScript mostra come applicare l'effetto bagliore a una forma:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    shape.getEffectFormat().getGlowEffect().setRadius(15);
    pres.save("glow.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Applicare l'effetto bordi morbidi**

Questo codice JavaScript mostra come applicare i bordi morbidi a una forma:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);
    pres.save("softEdges.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Posso applicare più effetti alla stessa forma?**

Sì, è possibile combinare diversi effetti, come ombra, riflessione e bagliore, su un'unica forma per creare un aspetto più dinamico.

**A quali forme posso applicare gli effetti?**

È possibile applicare effetti a varie forme, tra cui autoshapes, grafici, tabelle, immagini, oggetti SmartArt, oggetti OLE e altro.

**Posso applicare effetti a forme raggruppate?**

Sì, è possibile applicare effetti a forme raggruppate. L'effetto verrà applicato all'intero gruppo.