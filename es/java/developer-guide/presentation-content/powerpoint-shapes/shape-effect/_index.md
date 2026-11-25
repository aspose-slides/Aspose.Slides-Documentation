---
title: Aplicar efectos de forma en presentaciones usando Java
linktitle: Efecto de forma
type: docs
weight: 30
url: /es/java/shape-effect/
keywords:
- efecto de forma
- efecto de sombra
- efecto de reflexión
- efecto de resplandor
- efecto de bordes suaves
- formato de efecto
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Transforma tus archivos PPT y PPTX con efectos de forma avanzados usando Aspose.Slides para Java — crea diapositivas impactantes y profesionales en segundos."
---
## **Introducción**

Mientras que los efectos en PowerPoint pueden usarse para que una forma destaque, difieren de los [rellenos](/slides/es/java/shape-formatting/#gradient-fill) o contornos. Usando los efectos de PowerPoint, puedes crear reflejos convincentes en una forma, difundir el resplandor de una forma, etc.

![Efecto de forma](shape-effect.png)

PowerPoint ofrece seis efectos que pueden aplicarse a las formas. Puedes aplicar uno o más efectos a una forma.

Algunas combinaciones de efectos se ven mejor que otras. Por esta razón, PowerPoint proporciona opciones bajo **Preset**. Las opciones de Preset son combinaciones de dos o más efectos que se sabe que quedan bien. De este modo, al seleccionar un preset, no tendrás que perder tiempo probando o combinando diferentes efectos para encontrar una buena combinación.

Aspose.Slides ofrece propiedades y métodos bajo la clase [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/) que permiten aplicar los mismos efectos a las formas en presentaciones de PowerPoint.

## **Aplicar un efecto de sombra**

Aspose.Slides para Java admite sombras exteriores e interiores para las formas. Puedes personalizar su color, dirección, distancia y radio de desenfoque para que coincidan con el diseño de tu presentación.

### **Aplicar una sombra exterior**

Utiliza una sombra exterior para que una tarjeta o panel destaque sobre el fondo de la diapositiva. La sombra se extiende más allá de los bordes de la forma, creando la impresión de que la forma está elevada sobre la diapositiva. Ajusta su color, dirección, distancia y radio de desenfoque para que coincidan con la iluminación y el estilo de tu plantilla.

Este código Java muestra cómo aplicar el [efecto de sombra exterior](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) a un rectángulo:

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

### **Aplicar una sombra interior**

Al reproducir el estilo visual de una plantilla, utiliza una sombra interior para dar a una tarjeta o panel una apariencia hundida. Una sombra exterior se extiende fuera de la forma y hace que parezca elevada, mientras que una sombra interior sombrea el interior de sus bordes.

Llama a [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--), luego configura la sombra devuelta por [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Valores mayores de radio de desenfoque producen bordes más suaves.

Este ejemplo Java crea una tarjeta azul claro con una sombra interior gris oscuro y la guarda como archivo PPTX. La dirección de la sombra es 225 grados, su distancia es 7 puntos y su radio de desenfoque es 6 puntos:

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

![Rectángulo azul claro con una sombra interior](inner_shadow_effect.png)

Para eliminar la sombra interior, llama a [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) en el formato de efectos de la forma.

### **Aplicar, cambiar y eliminar una sombra predefinida**

Llama a [enablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#enablePresetShadowEffect--) y usa [setPreset](https://reference.aspose.com/slides/java/com.aspose.slides/ipresetshadow/#setPreset-int-) para seleccionar un [PresetShadowType](https://reference.aspose.com/slides/java/com.aspose.slides/presetshadowtype/). Para cambiar estilos, modifica el preset en la misma forma. Llama a [disablePresetShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disablePresetShadowEffect--) para eliminar la sombra conservando el relleno y el contorno.

Este ejemplo muestra cuatro etapas una al lado de la otra en una diapositiva. Ambas sombras están desplazadas 10 puntos. Una dirección de 225° coloca la primera sombra arriba y a la izquierda del rectángulo, y 45° coloca la segunda abajo y a la derecha.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(800, 120, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IAutoShape shape = shapes.addAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(70, 130, 180));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    shape.getTextFrame().setText("No shadow");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().enablePresetShadowEffect();
    IPresetShadow shadow = shape.getEffectFormat().getPresetShadowEffect();
    shadow.setPreset(PresetShadowType.TopLeftDropShadow);
    shadow.setDistance(10);
    shadow.setDirection(225);
    shape.getTextFrame().setText("TopLeftDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shadow.setPreset(PresetShadowType.BottomRightDropShadow);
    shadow.setDirection(45);
    shape.getTextFrame().setText("BottomRightDropShadow");
    shapes.addClone(shape);

    shape.setX(shape.getX() + 200);
    shape.getEffectFormat().disablePresetShadowEffect();
    shape.getTextFrame().setText("No shadow");

    presentation.save("preset_shadows.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Original | Primer predefinido | Segundo predefinido | Después de la eliminación |
| :---: | :---: | :---: | :---: |
| ![Sin sombra](preset_shadow_original.png) | ![Sombra superior izquierda](preset_shadow_top_left.png) | ![Sombra inferior derecha](preset_shadow_bottom_right.png) | ![Sin sombra después de la eliminación](preset_shadow_removed.png) |

## **Aplicar un efecto de reflexión**

Para aplicar un efecto de reflexión en Aspose.Slides para Java, puedes añadir una reflexión tipo espejo a las formas, ajustando parámetros como distancia, transparencia y tamaño. Este efecto mejora la estética de tus presentaciones al dar a las formas un aspecto más pulido y sofisticado. Es fácil de implementar con código sencillo, lo que permite una aplicación rápida en varios elementos para lograr un diseño coherente.

Este código Java muestra cómo aplicar el [efecto de reflexión](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) a una forma:

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

![Efecto de reflexión](reflection_effect.png)

## **Aplicar un efecto de resplandor**

Para aplicar un efecto de resplandor a una forma en Aspose.Slides para Java, puedes añadir un aura suave y luminosa alrededor de las formas, ajustando propiedades como el color y el tamaño. Este efecto ayuda a que las formas destaquen y añade un elemento visual atractivo y llamativo a tu presentación. Es fácil de implementar con código mínimo, mejorando el aspecto general de tus diapositivas.

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

Para aplicar un efecto de bordes suaves en Aspose.Slides para Java, puedes crear una transición lisa y difuminada alrededor de los bordes de una forma. Este efecto aporta un aspecto más sutil y refinado, perfecto para diseños que requieren una apariencia delicada y más suave. Puedes ajustar fácilmente parámetros como el radio para conseguir el efecto deseado en varias formas de tu presentación.

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

Utiliza el desenfoque de forma para suavizar el relleno y el contorno de una forma mientras mantiene la forma editable. Llama a [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) en el formato de efectos de la forma. El radio se mide en puntos (1/72 de pulgada): usa un valor no negativo, y valores mayores producen un desenfoque más intenso. Un radio de cero deja la apariencia sin cambios.

La configuración [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--) controla los límites visibles del efecto. Con `false`, el desenfoque se recorta a los límites pintados originales, incluido el contorno. Con `true`, el desenfoque puede extenderse más allá de esos límites. Ninguna de las dos opciones cambia la posición o dimensiones de la forma.

La comparación a continuación utiliza el mismo relleno, contorno y dimensiones de forma en todo momento. La fila superior usa `grow = false`; la fila inferior usa `grow = true`.

![Rectángulo original comparado con radios de desenfoque de 5 y 15 puntos, con grow desactivado y activado](shape_blur_comparison.png)

Este ejemplo Java crea un rectángulo naranja con un contorno azul oscuro, aplica un desenfoque de 5 puntos y luego lo actualiza a un desenfoque de 15 puntos llamando nuevamente a [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-). Guarda ambos estados con desenfoque, luego llama a [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) y guarda la forma sin desenfoque.

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

El desenfoque de forma afecta al relleno y al contorno conjuntamente. Un efecto de bordes suaves difumina los bordes de la forma, mientras que el desenfoque de sombra suaviza solo la sombra. Los efectos de transformación de imagen operan sobre el contenido de la imagen; este ejemplo aplica el desenfoque directamente al formato de efectos de la forma sin convertirla en una imagen.

## **Preguntas frecuentes**

**¿Puedo aplicar varios efectos a la misma forma?**

Sí, puedes combinar diferentes efectos, como sombra, reflexión y resplandor, en una sola forma para crear una apariencia más dinámica.

**¿A qué tipos de forma puedo aplicar efectos?**

Puedes aplicar efectos a diversas formas, incluidas autoshapes, gráficos, tablas, imágenes, objetos SmartArt, objetos OLE y más.

**¿Puedo aplicar efectos a formas agrupadas?**

Sí, puedes aplicar efectos a formas agrupadas. El efecto se aplicará a todo el grupo.