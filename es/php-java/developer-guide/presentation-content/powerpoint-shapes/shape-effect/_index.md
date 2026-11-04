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
- efecto de brillo
- efecto de bordes suaves
- formato de efecto
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Transforma tus archivos PPT y PPTX con efectos de forma avanzados usando Aspose.Slides for PHP a través de Java: crea diapositivas impactantes y profesionales en segundos."
---
## **Introducción**

Aunque los efectos en PowerPoint pueden usarse para que una forma destaque, difieren de los [rellenos](/slides/es/php-java/shape-formatting/#gradient-fill) o contornos. Con los efectos de PowerPoint, puedes crear reflejos convincentes en una forma, difundir el brillo de una forma, etc.

![Efecto de forma](shape-effect.png)

PowerPoint proporciona seis efectos que pueden aplicarse a las formas. Puedes aplicar uno o varios efectos a una forma.

Algunas combinaciones de efectos se ven mejor que otras. Por esta razón, PowerPoint ofrece opciones bajo **Preset**. Las opciones Preset son combinaciones de dos o más efectos que se sabe que quedan bien. De este modo, al seleccionar un preset, no tendrás que perder tiempo probando o combinando diferentes efectos para encontrar una buena combinación.

Aspose.Slides proporciona propiedades y métodos bajo la clase [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) que permiten aplicar los mismos efectos a las formas en presentaciones de PowerPoint.

## **Aplicar un efecto de sombra**

Aspose.Slides for PHP a través de Java admite sombras externas e internas para las formas. Puedes personalizar su color, dirección, distancia y radio de desenfoque para que coincidan con el diseño de tu presentación.

### **Aplicar una sombra externa**

Utiliza una sombra externa para que una tarjeta o panel destaque sobre el fondo de la diapositiva. La sombra se extiende más allá de los bordes de la forma, creando la impresión de que la forma está elevada sobre la diapositiva. Ajusta su color, dirección, distancia y radio de desenfoque para que coincidan con la iluminación y el estilo de tu plantilla.

Este código PHP muestra cómo aplicar el [efecto de sombra externa](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getOuterShadowEffect) a un rectángulo:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableOuterShadowEffect();
    $shadowColor = new Java("java.awt.Color", 169, 169, 169);
    $shape->getEffectFormat()->getOuterShadowEffect()->getShadowColor()->setColor($shadowColor);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDistance(10);
    $shape->getEffectFormat()->getOuterShadowEffect()->setDirection(45);

    $presentation->save("shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Efecto de sombra](shadow_effect.png)

### **Aplicar una sombra interna**

Al reproducir el estilo visual de una plantilla, usa una sombra interna para dar a una tarjeta o panel un aspecto hundido. Una sombra externa se extiende fuera de la forma y la hace parecer elevada, mientras que una sombra interna sombrea el interior de sus bordes.

Llama a [enableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#enableInnerShadowEffect), luego configura la sombra devuelta por [getInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getInnerShadowEffect). Los valores mayores del radio de desenfoque producen bordes más suaves.

Este ejemplo PHP crea una tarjeta azul claro con una sombra interna gris oscuro y la guarda como un archivo PPTX. La dirección de la sombra es 225 grados, su distancia es 7 puntos y su radio de desenfoque es 6 puntos:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 173, 216, 230);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $shape->getEffectFormat()->enableInnerShadowEffect();
    $shadow = $shape->getEffectFormat()->getInnerShadowEffect();
    $shadowColor = new Java("java.awt.Color", 105, 105, 105);
    $shadow->getShadowColor()->setColor($shadowColor);
    $shadow->setDirection(225);
    $shadow->setDistance(7);
    $shadow->setBlurRadius(6);

    $presentation->save("inner_shadow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Rectángulo azul claro con sombra interna](inner_shadow_effect.png)

Para eliminar la sombra interna, llama a [disableInnerShadowEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableInnerShadowEffect) en el formato de efectos de la forma.

## **Aplicar un efecto de reflexión**

Para aplicar un efecto de reflexión en Aspose.Slides for PHP a través de Java, puedes añadir una reflexión similar a un espejo a las formas, ajustando parámetros como distancia, transparencia y tamaño. Este efecto mejora la estética de tus presentaciones al dar a las formas un aspecto más pulido y sofisticado. Es fácil de implementar con código sencillo, lo que permite una aplicación rápida en varios elementos para mantener un diseño coherente.

Este código PHP muestra cómo aplicar el [efecto de reflexión](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getReflectionEffect) a una forma:

```php
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableReflectionEffect();
    $shape->getEffectFormat()->getReflectionEffect()->setRectangleAlign(RectangleAlignment::Bottom);
    $shape->getEffectFormat()->getReflectionEffect()->setDirection(90);
    $shape->getEffectFormat()->getReflectionEffect()->setDistance(40);
    $shape->getEffectFormat()->getReflectionEffect()->setBlurRadius(2);

    $presentation->save("reflection_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Efecto de reflexión](reflection_effect.png)

## **Aplicar un efecto de brillo**

Para aplicar un efecto de brillo a una forma en Aspose.Slides for PHP a través de Java, puedes añadir un aura suave y luminosa alrededor de las formas, ajustando propiedades como el color y el tamaño. Este efecto ayuda a que las formas destaquen y aporta un elemento visual atractivo y llamativo a tu presentación. Es fácil de implementar con poco código, mejorando el aspecto general de tus diapositivas.

Este código PHP muestra cómo aplicar el [efecto de brillo](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getGlowEffect) a una forma:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 100);
    $shape->getEffectFormat()->enableGlowEffect();
    $shape->getEffectFormat()->getGlowEffect()->getColor()->setColor(java("java.awt.Color")->MAGENTA);
    $shape->getEffectFormat()->getGlowEffect()->setRadius(15);

    $presentation->save("glow_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Efecto de brillo](glow_effect.png)

## **Aplicar un efecto de bordes suaves**

Para aplicar un efecto de bordes suaves en Aspose.Slides for PHP a través de Java, puedes crear una transición lisa y difuminada alrededor de los bordes de una forma. Este efecto aporta un aspecto más sutil y refinado, perfecto para diseños que necesitan una apariencia suave y delicada. Puedes ajustar fácilmente parámetros como el radio para lograr el efecto deseado en varias formas de tu presentación.

Este código PHP muestra cómo aplicar el [efecto de bordes suaves](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#getSoftEdgeEffect) a una forma:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 20, 20, 200, 150);
    $shape->getEffectFormat()->enableSoftEdgeEffect();
    $shape->getEffectFormat()->getSoftEdgeEffect()->setRadius(8);

    $presentation->save("soft_edges_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Efecto de bordes suaves](soft_edges_effect.png)

## **Aplicar un efecto de desenfoque**

Utiliza el desenfoque de forma para suavizar el relleno y el contorno de una forma manteniéndola editable. Llama a [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect) en el formato de efectos de la forma. El radio se mide en puntos (1/72 de pulgada): usa un valor no negativo, con valores mayores que producen un desenfoque más intenso. Un radio de cero deja el aspecto sin cambios.

La configuración [getGrow](https://reference.aspose.com/slides/php-java/aspose.slides/blur/#getGrow) controla los límites visibles del efecto. Con `false`, el desenfoque se recorta a los límites pintados originales, incluido el contorno. Con `true`, el desenfoque puede extenderse más allá de esos límites. Ninguna de las configuraciones cambia la posición o las dimensiones de la forma.

La comparación a continuación usa el mismo relleno, contorno y dimensiones de forma en todo momento. La fila superior utiliza `grow = false`; la fila inferior utiliza `grow = true`.

![Rectángulo original comparado con radios de desenfoque de 5 y 15 puntos, con grow desactivado y activado](shape_blur_comparison.png)

Este ejemplo PHP crea un rectángulo naranja con un contorno azul oscuro, le aplica un desenfoque de 5 puntos y luego lo actualiza a un desenfoque de 15 puntos llamando nuevamente a [setBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#setBlurEffect). Guarda ambos estados desenfocados, luego llama a [disableBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/#disableBlurEffect) y guarda la forma sin desenfoque.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 80, 160, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 0, 0, 139);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(8);

    $shape->getEffectFormat()->setBlurEffect(5, false);
    $presentation->save("shape_blur_5.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->setBlurEffect(15, true);
    $presentation->save("shape_blur_15.pptx", SaveFormat::Pptx);

    $shape->getEffectFormat()->disableBlurEffect();
    $presentation->save("shape_blur_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

El desenfoque de forma afecta tanto al relleno como al contorno simultáneamente. Un efecto de bordes suaves desvanece los bordes de la forma, mientras que el desenfoque de sombra suaviza solo la sombra. Los efectos de transformación de imagen actúan sobre el contenido de la imagen; este ejemplo aplica el desenfoque directamente al formato de efectos de la forma sin convertirla a una imagen.

## **Preguntas frecuentes**

**¿Puedo aplicar varios efectos a la misma forma?**

Sí, puedes combinar diferentes efectos, como sombra, reflexión y brillo, en una única forma para crear una apariencia más dinámica.

**¿A qué formas puedo aplicar efectos?**

Puedes aplicar efectos a diversas formas, incluidas autoshapes, gráficos, tablas, imágenes, objetos SmartArt, objetos OLE y más.

**¿Puedo aplicar efectos a formas agrupadas?**

Sí, puedes aplicar efectos a formas agrupadas. El efecto se aplicará a todo el grupo.