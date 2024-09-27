---
title: Эффект формы
type: docs
weight: 30
url: /ru/java/shape-effect
keywords: "Эффект формы, Презентация PowerPoint, Java, Aspose.Slides для Java"
description: "Примените эффект к форме PowerPoint на Java"
---

Хотя эффекты в PowerPoint могут использоваться для того, чтобы форма выделялась, они отличаются от [заливок](/slides/ru/java/shape-formatting/#gradient-fill) или контуров. Используя эффекты PowerPoint, вы можете создать убедительные отражения на форме, рассеять свечение формы и т.д.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint предоставляет шесть эффектов, которые можно применять к формам. Вы можете применить один или несколько эффектов к форме. 

* Некоторые комбинации эффектов выглядят лучше других. По этой причине в PowerPoint доступны параметры **Предустановленные**. Параметры Предустановленные представляют собой, по сути, известную хорошо выглядящую комбинацию двух или более эффектов. Таким образом, выбрав предустановку, вам не придется тратить время на тестирование или комбинирование различных эффектов для поиска хорошей комбинации.

Aspose.Slides предоставляет свойства и методы в классе [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat), которые позволяют вам применять те же эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Этот код на Java показывает, как применить эффект внешней тени ([OuterShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) к прямоугольнику:

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

## **Применить эффект отражения**

Этот код на Java показывает, как применить эффект отражения к форме:

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

## **Применить эффект свечения**

Этот код на Java показывает, как применить эффект свечения к форме:

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

## **Применить эффект мягких краев**

Этот код на Java показывает, как применить эффект мягких краев к форме:

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