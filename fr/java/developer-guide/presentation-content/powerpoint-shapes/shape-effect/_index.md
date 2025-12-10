---
title: Appliquer des effets de forme dans les présentations avec Java
linktitle: Effet de forme
type: docs
weight: 30
url: /fr/java/shape-effect/
keywords:
- effet de forme
- effet d'ombre
- effet de réflexion
- effet de lueur
- effet de bords doux
- format d'effet
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Transformez vos fichiers PPT et PPTX avec des effets de forme avancés à l'aide d'Aspose.Slides pour Java — créez des diapositives frappantes et professionnelles en quelques secondes."
---

Alors que les effets dans PowerPoint peuvent être utilisés pour faire ressortir une forme, ils diffèrent des [remplissages](/slides/fr/java/shape-formatting/#gradient-fill) ou des contours. En utilisant les effets PowerPoint, vous pouvez créer des reflets convaincants sur une forme, diffuser la lueur d'une forme, etc.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint propose six effets qui peuvent être appliqués aux formes. Vous pouvez appliquer un ou plusieurs effets à une forme. 

* Certaines combinaisons d'effets sont plus esthétiques que d'autres. Pour cette raison, PowerPoint propose les options sous **Preset**. Les options Preset sont essentiellement une combinaison reconnue comme esthétique de deux effets ou plus. Ainsi, en sélectionnant un preset, vous n'aurez pas à perdre du temps à tester ou combiner différents effets pour trouver une bonne combinaison.

Aspose.Slides fournit des propriétés et des méthodes dans la classe [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat) qui vous permettent d'appliquer les mêmes effets aux formes dans les présentations PowerPoint.

## **Appliquer un effet d'ombre**

Ce code Java vous montre comment appliquer l'effet d'ombre externe ([OuterShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) à un rectangle:
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


## **Appliquer un effet de réflexion**

Ce code Java vous montre comment appliquer l'effet de réflexion à une forme:
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


## **Appliquer un effet de lueur**

Ce code Java vous montre comment appliquer l'effet de lueur à une forme:
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


## **Appliquer un effet de bords doux**

Ce code Java vous montre comment appliquer les bords doux à une forme:
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

**Puis-je appliquer plusieurs effets à la même forme ?**

Oui, vous pouvez combiner différents effets, tels que l'ombre, la réflexion et la lueur, sur une seule forme pour obtenir un rendu plus dynamique.

**À quelles formes puis-je appliquer des effets ?**

Vous pouvez appliquer des effets à diverses formes, notamment les formes automatiques, les graphiques, les tableaux, les images, les objets SmartArt, les objets OLE, etc.

**Puis-je appliquer des effets à des formes groupées ?**

Oui, vous pouvez appliquer des effets aux formes groupées. L'effet sera appliqué à l'ensemble du groupe.