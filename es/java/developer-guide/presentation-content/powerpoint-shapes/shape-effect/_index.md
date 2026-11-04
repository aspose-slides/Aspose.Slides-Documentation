---
title: Aplicar efectos de forma en presentaciones con Java
linktitle: Efecto de forma
type: docs
weight: 30
url: /es/java/shape-effect/
keywords:
- efecto de forma
- efecto de sombra
- efecto de reflejo
- efecto de resplandor
- efecto de bordes suaves
- formato de efecto
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Transforma tus archivos PPT y PPTX con efectos de forma avanzados usando Aspose.Slides for Java—crea diapositivas impactantes y profesionales en segundos."
---
## **Introducción**

Mientras los efectos en PowerPoint pueden usarse para que una forma destaque, difieren de los [rellenos](/slides/es/java/shape-formatting/#gradient-fill) o contornos. Usando los efectos de PowerPoint, puedes crear reflejos convincentes en una forma, difundir el resplandor de una forma, etc.

![Efecto de forma](shape-effect.png)

PowerPoint ofrece seis efectos que pueden aplicarse a las formas. Puedes aplicar uno o más efectos a una forma.

Algunas combinaciones de efectos se ven mejor que otras. Por esta razón, PowerPoint ofrece opciones bajo **Preajuste**. Las opciones de Preajuste son combinaciones de dos o más efectos que se sabe que lucen bien. De esta manera, al seleccionar un preajuste, no tendrás que perder tiempo probando o combinando diferentes efectos para encontrar una buena combinación.

Aspose.Slides proporciona propiedades y métodos bajo la clase [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) que te permiten aplicar los mismos efectos a las formas en presentaciones de PowerPoint.

## **Aplicar un efecto de sombra**

Aspose.Slides for Java admite sombras externas e internas para las formas. Puedes personalizar su color, dirección, distancia y radio de desenfoque para que coincida con el diseño de tu presentación.

### **Aplicar una sombra externa**

Utiliza una sombra externa para que una tarjeta o panel destaque sobre el fondo de la diapositiva. La sombra se extiende más allá de los bordes de la forma, creando la impresión de que la forma está elevada sobre la diapositiva. Ajusta su color, dirección, distancia y radio de desenfoque para que coincida con la iluminación y el estilo de tu plantilla.

Este código Java muestra cómo aplicar el [efecto de sombra externa](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) a un rectángulo:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efecto de sombra](shadow_effect.png)

### **Aplicar una sombra interna**

Al reproducir el estilo visual de una plantilla, utiliza una sombra interna para dar a una tarjeta o panel una apariencia hundida. Una sombra externa se extiende fuera de la forma y hace que parezca elevada, mientras que una sombra interna sombrea el interior de sus bordes.

Llama a [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--), luego configura la sombra devuelta por [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Los valores de radio de desenfoque más grandes producen bordes más suaves.

Este ejemplo Java crea una tarjeta azul clara con una sombra interna gris oscuro y la guarda como un archivo PPTX. La dirección de la sombra es 225 grados, su distancia es 7 puntos y su radio de desenfoque es 6 puntos:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Rectángulo azul claro con una sombra interna](inner_shadow_effect.png)

Para eliminar la sombra interna, llama a [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) en el formato de efectos de la forma.

## **Aplicar un efecto de reflejo**

Para aplicar un efecto de reflejo en Aspose.Slides for Java, puedes añadir una reflexión similar a un espejo a las formas, ajustando parámetros como distancia, transparencia y tamaño. Este efecto realza la estética de tus presentaciones al dar a las formas un aspecto más pulido y sofisticado. Es fácil de implementar con código simple, lo que permite una aplicación rápida en varios elementos para un diseño coherente.

Este código Java muestra cómo aplicar el [efecto de reflejo](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) a una forma:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efecto de reflejo](reflection_effect.png)

## **Aplicar un efecto de resplandor**

Para aplicar un efecto de resplandor a una forma en Aspose.Slides for Java, puedes añadir una aura suave y luminosa alrededor de las formas, ajustando propiedades como el color y el tamaño. Este efecto ayuda a que las formas destaquen y agrega un elemento visual atractivo y llamativo a tu presentación. Es fácil de implementar con código mínimo, mejorando el aspecto general de tus diapositivas.

Este código Java muestra cómo aplicar el [efecto de resplandor](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) a una forma:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efecto de resplandor](glow_effect.png)

## **Aplicar un efecto de bordes suaves**

Para aplicar un efecto de bordes suaves en Aspose.Slides for Java, puedes crear una transición lisa y difusa alrededor de los bordes de una forma. Este efecto añade una apariencia más sutil y refinada, perfecta para diseños que necesitan un aspecto delicado y más suave. Puedes ajustar fácilmente parámetros como el radio para conseguir el efecto deseado en varias formas de tu presentación.

Este código Java muestra cómo aplicar el [efecto de bordes suaves](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) a una forma:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Efecto de bordes suaves](soft_edges_effect.png)

## **Aplicar un efecto de desenfoque**

Utiliza el desenfoque de forma para suavizar el relleno y contorno de una forma manteniéndola editable. Llama a [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) en el formato de efectos de la forma. El radio se mide en puntos (1/72 de pulgada): usa un valor no negativo, con valores mayores que producen un desenfoque más fuerte. Un radio de cero deja la apariencia sin cambios.

La configuración [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) controla los límites visibles del efecto. Con `false`, el desenfoque se recorta a los límites pintados originales, incluido el contorno. Con `true`, el desenfoque puede extenderse más allá de esos límites. Ninguna de las dos configuraciones cambia la posición o dimensiones de la forma.

La comparación a continuación usa el mismo relleno, contorno y dimensiones de forma en todo momento. La fila superior usa `grow = false`; la fila inferior usa `grow = true`.

![Rectángulo original comparado con radios de desenfoque de 5 y 15 puntos, con grow deshabilitado y habilitado](shape_blur_comparison.png)

Este ejemplo Java crea un rectángulo naranja con un contorno azul oscuro, aplica un desenfoque de 5 puntos y luego lo actualiza a un desenfoque de 15 puntos llamando de nuevo a [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Guarda ambos estados desenfocados, luego llama a [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) y guarda la forma sin desenfoque.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El desenfoque de forma afecta al relleno y al contorno juntos. Un efecto de bordes suaves difumina los bordes de la forma, mientras que el desenfoque de sombra suaviza solo la sombra. Los efectos de transformación de imagen actúan sobre el contenido de la imagen; este ejemplo aplica el desenfoque directamente al formato de efectos de la forma sin convertirla en una imagen.

## **Preguntas frecuentes**

**¿Puedo aplicar varios efectos a la misma forma?**

Sí, puedes combinar diferentes efectos, como sombra, reflejo y resplandor, en una sola forma para crear una apariencia más dinámica.

**¿A qué formas puedo aplicar efectos?**

Puedes aplicar efectos a diversas formas, incluidas autoshapes, gráficos, tablas, imágenes, objetos SmartArt, objetos OLE y más.

**¿Puedo aplicar efectos a formas agrupadas?**

Sí, puedes aplicar efectos a formas agrupadas. El efecto se aplicará a todo el grupo.