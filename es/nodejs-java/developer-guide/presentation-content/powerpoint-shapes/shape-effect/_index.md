---
title: Aplicar efectos de forma en presentaciones usando JavaScript
linktitle: Efecto de forma
type: docs
weight: 30
url: /es/nodejs-java/shape-effect/
keywords:
- efecto de forma
- efecto de sombra
- efecto de reflexión
- efecto de resplandor
- efecto de bordes suaves
- formato de efecto
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Transforma tus archivos PPT y PPTX con efectos de forma avanzados usando JavaScript y Aspose.Slides para Node.js — crea diapositivas impactantes y profesionales en segundos."
---
## **Introducción**

Aunque los efectos en PowerPoint pueden usarse para resaltar una forma, difieren de los [rellenos](/slides/es/nodejs-java/shape-formatting/#gradient-fill) o de los contornos. Con los efectos de PowerPoint, puedes crear reflejos convincentes en una forma, difundir el resplandor de una forma, etc.

![Efecto de forma](shape-effect.png)

PowerPoint ofrece seis efectos que pueden aplicarse a las formas. Puedes aplicar uno o varios efectos a una forma.

Algunas combinaciones de efectos lucen mejor que otras. Por esta razón, PowerPoint ofrece opciones bajo **Preset**. Las opciones Predefinidas son combinaciones de dos o más efectos que se sabe que quedan bien. Así, al seleccionar una predefinida, no tendrás que perder tiempo probando o combinando diferentes efectos para encontrar una buena combinación.

Aspose.Slides proporciona propiedades y métodos bajo la clase [EffectFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/) que te permiten aplicar los mismos efectos a las formas en presentaciones de PowerPoint.

## **Aplicar un efecto de sombra**

Aspose.Slides for Node.js via Java admite sombras externas e internas para las formas. Puedes personalizar su color, dirección, distancia y radio de desenfoque para que coincidan con el diseño de tu presentación.

### **Aplicar una sombra externa**

Utiliza una sombra externa para que una tarjeta o panel destaque sobre el fondo de la diapositiva. La sombra se extiende más allá de los bordes de la forma, creando la impresión de que la forma está elevada sobre la diapositiva. Ajusta su color, dirección, distancia y radio de desenfoque para que coincidan con la iluminación y el estilo de tu plantilla.

Este código JavaScript muestra cómo aplicar el [efecto de sombra externa](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getOuterShadowEffect) a un rectángulo:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 169, 169, 169);
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(color);
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efecto de sombra](shadow_effect.png)

### **Aplicar una sombra interna**

Al reproducir el estilo visual de una plantilla, usa una sombra interna para dar a una tarjeta o panel una apariencia hundida. Una sombra externa se extiende fuera de la forma y hace que parezca elevada, mientras que una sombra interna sombrea el interior de sus bordes.

Llama a [enableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#enableInnerShadowEffect), luego configura la sombra devuelta por [getInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getInnerShadowEffect). Valores mayores de radio de desenfoque producen bordes más suaves.

Este ejemplo JavaScript crea una tarjeta azul claro con una sombra interna gris oscuro y la guarda como un archivo PPTX. La dirección de la sombra es de 225 grados, su distancia es 7 puntos y su radio de desenfoque es de 6 puntos:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 173, 216, 230);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    shape.getEffectFormat().enableInnerShadowEffect();
    const shadow = shape.getEffectFormat().getInnerShadowEffect();
    const color = java.newInstanceSync("java.awt.Color", 105, 105, 105);
    shadow.getShadowColor().setColor(color);
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Rectángulo azul claro con una sombra interna](inner_shadow_effect.png)

Para eliminar la sombra interna, llama a [disableInnerShadowEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableInnerShadowEffect) en el formato de efectos de la forma.

## **Aplicar un efecto de reflexión**

Para aplicar un efecto de reflexión en Aspose.Slides for Node.js via Java, puedes añadir una reflexión tipo espejo a las formas, ajustando parámetros como distancia, transparencia y tamaño. Este efecto mejora la estética de tus presentaciones al dar a las formas un aspecto más pulido y sofisticado. Es fácil de implementar con código simple, lo que permite una aplicación rápida en varios elementos para un diseño coherente.

Este código JavaScript muestra cómo aplicar el [efecto de reflexión](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getReflectionEffect) a una forma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.Bottom));
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efecto de reflexión](reflection_effect.png)

## **Aplicar un efecto de resplandor**

Para aplicar un efecto de resplandor a una forma en Aspose.Slides for Node.js via Java, puedes añadir un aura suave y luminosa alrededor de las formas, ajustando propiedades como color y tamaño. Este efecto ayuda a que las formas destaquen y añade un elemento visual atractivo y llamativo a tu presentación. Es fácil de implementar con un código mínimo, realzando el aspecto general de tus diapositivas.

Este código JavaScript muestra cómo aplicar el [efecto de resplandor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getGlowEffect) a una forma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    const color = java.getStaticFieldValue("java.awt.Color", "MAGENTA");
    shape.getEffectFormat().getGlowEffect().getColor().setColor(color);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efecto de resplandor](glow_effect.png)

## **Aplicar un efecto de bordes suaves**

Para aplicar un efecto de bordes suaves en Aspose.Slides for Node.js via Java, puedes crear una transición lisa y difusa alrededor de los bordes de una forma. Este efecto añade una apariencia más sutil y refinada, perfecta para diseños que requieren un aspecto delicado y más suave. Puedes ajustar fácilmente parámetros como el radio para conseguir el efecto deseado en varias formas de tu presentación.

Este código JavaScript muestra cómo aplicar el [efecto de bordes suaves](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#getSoftEdgeEffect) a una forma:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efecto de bordes suaves](soft_edges_effect.png)

## **Aplicar un efecto de desenfoque**

Usa el desenfoque de forma para suavizar el relleno y el contorno de una forma manteniéndola editable. Llama a [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect) en el formato de efectos de la forma. El radio se mide en puntos (1/72 de pulgada): usa un valor no negativo, siendo los valores mayores los que producen un desenfoque más fuerte. Un radio de cero deja la apariencia sin cambios.

La configuración [getGrow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/#getGrow) controla los límites visibles del efecto. Con `false`, el desenfoque se recorta a los límites pintados originales, incluyendo el contorno. Con `true`, el desenfoque puede extenderse más allá de esos límites. Ninguna de las dos configuraciones cambia la posición o dimensiones de la forma.

La comparativa a continuación usa el mismo relleno, contorno y dimensiones de forma en todo momento. La fila superior usa `grow = false`; la fila inferior usa `grow = true`.

![Rectángulo original comparado con radios de desenfoque de 5 y 15 puntos, con grow desactivado y activado](shape_blur_comparison.png)

Este ejemplo JavaScript crea un rectángulo naranja con un contorno azul oscuro, aplica un desenfoque de 5 puntos y luego lo actualiza a un desenfoque de 15 puntos llamando de nuevo a [setBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#setBlurEffect). Guarda ambos estados desenfocados, luego llama a [disableBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/effectformat/#disableBlurEffect) y guarda la forma sin desenfoque.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(lineColor);
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", aspose.slides.SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El desenfoque de forma afecta al relleno y al contorno juntos. Un efecto de bordes suaves difumina los bordes de la forma, mientras que el desenfoque de sombra suaviza solo la sombra. Los efectos de transformación de imagen operan sobre el contenido de la imagen; este ejemplo aplica el desenfoque directamente al formato de efectos de la forma sin convertirla en una imagen.

## **FAQ**

**¿Puedo aplicar varios efectos a la misma forma?**

Sí, puedes combinar diferentes efectos, como sombra, reflexión y resplandor, en una única forma para crear una apariencia más dinámica.

**¿A qué tipos de forma puedo aplicar efectos?**

Puedes aplicar efectos a diversas formas, incluidas autoshapes, gráficos, tablas, imágenes, objetos SmartArt, objetos OLE y más.

**¿Puedo aplicar efectos a formas agrupadas?**

Sí, puedes aplicar efectos a formas agrupadas. El efecto se aplicará a todo el grupo.