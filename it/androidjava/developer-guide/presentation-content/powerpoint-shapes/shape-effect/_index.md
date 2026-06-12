---
title: Applicare effetti di forma nelle presentazioni su Android
linktitle: Effetto forma
type: docs
weight: 30
url: /it/androidjava/shape-effect/
keywords:
- effetto forma
- effetto ombra
- effetto riflessione
- effetto bagliore
- effetto bordi morbidi
- formato effetto
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Trasforma i tuoi file PPT e PPTX con effetti di forma avanzati usando Aspose.Slides per Android via Java — crea diapositive sorprendenti e professionali in pochi secondi."
---
## **Introduzione**

Mentre gli effetti in PowerPoint possono essere usati per far risaltare una forma, differiscono da [riempimenti](/slides/it/androidjava/shape-formatting/#gradient-fill) o contorni. Utilizzando gli effetti di PowerPoint, è possibile creare riflessi convincenti su una forma, diffondere la luminosità di una forma, ecc.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint fornisce sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma. 

* Alcune combinazioni di effetti hanno un aspetto migliore di altre. Per questo motivo, PowerPoint offre le opzioni **Preset**. Le opzioni Preset sono essenzialmente una combinazione nota di due o più effetti dal risultato gradevole. In questo modo, selezionando un preset, non dovrai perdere tempo a testare o combinare effetti diversi per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/EffectFormat) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applicare un effetto ombra**

Questo codice Java mostra come applicare l'effetto ombra esterna ([OuterShadowEffect](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) a un rettangolo:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.DARK_GRAY);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Applicare un effetto riflessione**

Questo codice Java mostra come applicare l'effetto di riflessione a una forma:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(55);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(4);

    pres.save("reflection.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Applicare un effetto bagliore**

Questo codice Java mostra come applicare l'effetto di bagliore a una forma:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    pres.save("glow.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Applicare un effetto bordi morbidi**

Questo codice Java mostra come applicare i bordi morbidi a una forma:

```java
Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(15);

    pres.save("softEdges.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Posso applicare più effetti alla stessa forma?**

Sì, è possibile combinare effetti diversi, come ombra, riflessione e bagliore, su un'unica forma per ottenere un aspetto più dinamico.

**A quali forme posso applicare gli effetti?**

È possibile applicare gli effetti a varie forme, inclusi autoshape, grafici, tabelle, immagini, oggetti SmartArt, oggetti OLE e altro ancora.

**Posso applicare gli effetti a forme raggruppate?**

Sì, è possibile applicare gli effetti a forme raggruppate. L'effetto verrà applicato all'intero gruppo.