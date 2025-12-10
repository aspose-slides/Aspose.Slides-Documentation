---
title: Применение эффектов фигур в презентациях с использованием Java
linktitle: Эффект фигуры
type: docs
weight: 30
url: /ru/java/shape-effect/
keywords:
- эффект фигуры
- эффект тени
- эффект отражения
- эффект свечения
- эффект мягких краев
- формат эффекта
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Преобразуйте свои файлы PPT и PPTX с помощью передовых эффектов фигур, используя Aspose.Slides для Java — создайте яркие, профессиональные слайды за секунды."
---

В то время как эффекты в PowerPoint можно использовать, чтобы выделить форму, они отличаются от [fills](/slides/ru/java/shape-formatting/#gradient-fill) или контуров. С помощью эффектов PowerPoint вы можете создавать убедительные отражения на форме, распространять светящееся свечение формы и т.д.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint предоставляет шесть эффектов, которые можно применять к формам. Вы можете применять один или несколько эффектов к форме. 
* Некоторые комбинации эффектов выглядят лучше, чем другие. По этой причине в PowerPoint есть параметры **Preset**. Параметры Preset представляют собой известную хорошо выглядящую комбинацию двух и более эффектов. Таким образом, выбирая предустановку, вам не придётся тратить время на тестирование или комбинирование разных эффектов, чтобы найти хорошую комбинацию.

Aspose.Slides предоставляет свойства и методы класса [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat), которые позволяют применять те же эффекты к формам в презентациях PowerPoint.

## **Применить эффект тени**

Этот Java‑код показывает, как применить внешний эффект тени ([OuterShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/EffectFormat#setOuterShadowEffect--)) к прямоугольнику:
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

Этот Java‑код показывает, как применить эффект отражения к форме:
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

Этот Java‑код показывает, как применить эффект свечения к форме:
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


## **Применить эффект мягких краёв**

Этот Java‑код показывает, как применить мягкие края к форме:
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

**Могу ли я применить несколько эффектов к одной форме?**

Да, вы можете комбинировать различные эффекты, такие как тень, отражение и свечения, на одной форме, чтобы создать более динамичный внешний вид.

**К каким формам можно применять эффекты?**

Эффекты можно применять к различным формам, включая автофигуры, диаграммы, таблицы, изображения, объекты SmartArt, OLE‑объекты и т.д.

**Могу ли я применять эффекты к сгруппированным формам?**

Да, вы можете применять эффекты к сгруппированным формам. Эффект будет применён ко всей группе.