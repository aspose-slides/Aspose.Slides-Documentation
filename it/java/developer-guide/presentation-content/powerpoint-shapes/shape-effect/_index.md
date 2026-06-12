---
title: Applica effetti di forma nelle presentazioni usando Java
linktitle: Effetto Forma
type: docs
weight: 30
url: /it/java/shape-effect/
keywords:
- effetto forma
- effetto ombra
- effetto riflessione
- effetto bagliore
- effetto bordi morbidi
- formato effetto
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Trasforma i tuoi file PPT e PPTX con effetti di forma avanzati usando Aspose.Slides per Java—crea diapositive sorprendenti e professionali in pochi secondi."
---
## **Introduzione**

Mentre gli effetti in PowerPoint possono essere usati per far risaltare una forma, differiscono da [riempimenti](/slides/it/java/shape-formatting/#gradient-fill) o contorni. Utilizzando gli effetti di PowerPoint, è possibile creare riflessi convincenti su una forma, diffondere il bagliore di una forma, ecc.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint fornisce sei effetti che possono essere applicati alle forme. È possibile applicare uno o più effetti a una forma. 

* Alcune combinazioni di effetti appaiono migliori di altre. Per questo motivo, PowerPoint offre opzioni sotto **Preset**. Le opzioni Preset sono essenzialmente una combinazione già nota e gradevole di due o più effetti. In questo modo, selezionando un preset, non dovrai perdere tempo a provare o combinare effetti diversi per trovare una buona combinazione.

Aspose.Slides fornisce proprietà e metodi nella classe [EffectFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/EffectFormat) che consentono di applicare gli stessi effetti alle forme nelle presentazioni PowerPoint.

## **Applica un effetto ombra**

Questo codice Java mostra come applicare l'effetto ombra esterna ([OuterShadowEffect](https://reference.aspose.com/slides/it/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) a un rettangolo:

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

## **Applica un effetto di riflessione**

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

## **Applica un effetto di bagliore**

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

## **Applica un effetto di bordi morbidi**

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

Sì, è possibile combinare diversi effetti, come ombra, riflessione e bagliore, su un'unica forma per creare un aspetto più dinamico.

**Su quali forme posso applicare gli effetti?**

È possibile applicare effetti a diverse forme, comprese forme automatiche, grafici, tabelle, immagini, oggetti SmartArt, oggetti OLE e altro.

**Posso applicare effetti a forme raggruppate?**

Sì, è possibile applicare effetti a forme raggruppate. L'effetto verrà applicato all'intero gruppo.