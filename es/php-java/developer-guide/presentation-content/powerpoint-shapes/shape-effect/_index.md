---
title: Aplicar efectos de forma en presentaciones usando PHP
linktitle: Efecto de forma
type: docs
weight: 30
url: /es/php-java/shape-effect/
keywords:
- efecto de forma
- efecto de sombra
- efecto de reflexión
- efecto de resplandor
- efecto de bordes suaves
- formato de efecto
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Transforma tus archivos PPT y PPTX con efectos de forma avanzados usando Aspose.Slides para PHP a través de Java — crea diapositivas impactantes y profesionales en segundos."
---

Mientras que los efectos en PowerPoint pueden usarse para que una forma destaque, difieren de los [rellenos](/slides/es/php-java/shape-formatting/#gradient-fill) o contornos. Con los efectos de PowerPoint, puedes crear reflejos convincentes en una forma, difundir el brillo de una forma, etc.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

* PowerPoint ofrece seis efectos que pueden aplicarse a las formas. Puedes aplicar uno o más efectos a una forma. 
* Algunas combinaciones de efectos se ven mejor que otras. Por esta razón, PowerPoint tiene opciones bajo **Preset**. Las opciones de **Preset** son esencialmente una combinación de dos o más efectos que se sabe que luce bien. De este modo, al seleccionar un preset, no tendrás que perder tiempo probando o combinando diferentes efectos para encontrar una buena combinación.

Aspose.Slides proporciona propiedades y métodos bajo la clase [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat) que permiten aplicar los mismos efectos a las formas en presentaciones de PowerPoint.

## **Aplicar un efecto de sombra**

Este código PHP muestra cómo aplicar el efecto de sombra externa ([OuterShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/EffectFormat#setOuterShadowEffect--)) a un rectángulo:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor(java("java.awt.Color")->DARK_GRAY);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Aplicar un efecto de reflexión**

Este código PHP muestra cómo aplicar el efecto de reflexión a una forma:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment->Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(55);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(4);
    $pres->save("reflection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Aplicar un efecto de resplandor**

Este código PHP muestra cómo aplicar el efecto de resplandor a una forma:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);
    $pres->save("glow.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Aplicar un efecto de bordes suaves**

Este código PHP muestra cómo aplicar los bordes suaves a una forma:
```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(15);
    $pres->save("softEdges.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Puedo aplicar varios efectos a la misma forma?**

Sí, puedes combinar diferentes efectos, como sombra, reflexión y resplandor, en una sola forma para crear una apariencia más dinámica.

**¿A qué formas puedo aplicar efectos?**

Puedes aplicar efectos a varias formas, incluyendo formas automáticas, gráficos, tablas, imágenes, objetos SmartArt, objetos OLE y más.

**¿Puedo aplicar efectos a formas agrupadas?**

Sí, puedes aplicar efectos a formas agrupadas. El efecto se aplicará a todo el grupo.