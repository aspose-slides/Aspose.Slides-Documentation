---
title: Formatear formas de PowerPoint en Android
linktitle: Formato de forma
type: docs
weight: 20
url: /es/androidjava/shape-formatting/
keywords:
- formato de forma
- formato de línea
- efecto de boceto
- línea de forma boceto
- formato de estilo de unión
- relleno degradado
- relleno de patrón
- relleno de imagen
- relleno de textura
- relleno de color sólido
- transparencia de forma
- representación en blanco y negro de forma
- representación en escala de grises de forma
- rotar forma
- efecto de bisel 3D
- efecto de rotación 3D
- restablecer formato
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda cómo formatear formas de PowerPoint en Android usando Aspose.Slides: establezca rellenos, líneas y estilos de efecto para archivos PPT y PPTX con precisión y control total."
---
## **Introducción**

Formatee formas en PowerPoint ajustando sus contornos, rellenos y efectos. Aspose.Slides for Android a través de Java le permite controlar estos ajustes mediante programación, incluida la transparencia, la rotación y el formato 3D.

![Opciones de formato de forma en PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java proporciona interfaces y métodos que le permiten dar formato a las formas utilizando las mismas opciones disponibles en PowerPoint.

## **Formato de líneas**

Utilice [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) para controlar el contorno de una forma. Este ejemplo crea un rectángulo sin relleno con un contorno azul y de trazos discontinuos. [ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) selecciona una línea compuesta gruesa‑delgada, mientras que [ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) establece su ancho en 7 puntos y [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) selecciona el patrón de guiones.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Las líneas formateadas en la presentación](formatted-lines.png)

### **Establecer patrones de guiones personalizados para líneas**

Utilice [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) cuando los estilos de línea predefinidos no proporcionan las longitudes de guiones y espacios que necesita, por ejemplo para contornos con marca o diagramas técnicos. Asignar un patrón cambia automáticamente el estilo de guiones de la línea a [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/).

Las entradas del array se alternan entre longitudes de guión y de espacio, comenzando por un guión. Cada valor es un múltiplo del ancho de la línea: `{ 4, 2 }` con un ancho de 3 puntos produce un guión de 12 puntos seguido de un espacio de 6 puntos. Use pares de valores finitos y no negativos para definir segmentos completos de guión‑y‑espacio. El ejemplo utiliza valores positivos para que cada guión y espacio sean visibles.

Este ejemplo crea cinco líneas azules con la misma longitud y terminaciones planas. Las tres primeras comparan patrones con un ancho de 3 puntos. La cuarta repite el primer patrón al doble de ancho, duplicando tanto la longitud del guión como del espacio. La quinta cambia de un patrón personalizado a una línea continua.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Restaurar la última línea a un estilo sólido.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para volver a un estilo de guión predefinido, pase [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) a [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-). El estilo seleccionado controla la apariencia de la línea.

El resultado en PowerPoint, de arriba a abajo: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; y **Solid, 3 pt**.

![Tres patrones de guiones personalizados, una línea más ancha usando el primer patrón y una línea continua en PowerPoint](custom-dash-patterns.png)

### **Establecer terminaciones de línea**

Utilice [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) para establecer los extremos de una línea abierta. La clase [LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) ofrece tres estilos de terminación explícitos:

- `Flat`: El trazo termina en el punto final.
- `Round`: Una terminación semicircular se extiende más allá del punto final la mitad del ancho de la línea.
- `Square`: Una terminación cuadrada se extiende más allá del punto final la mitad del ancho de la línea.

La clase también incluye `NotDefined`, que indica que no se ha asignado ningún estilo de terminación explícitamente.

Las terminaciones son diferentes de las puntas de flecha, que añaden símbolos a los extremos de la línea, y de las uniones, que controlan las esquinas entre segmentos de línea. Este ejemplo desactiva las puntas de flecha mediante [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) y [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) para que solo se comparen las formas de terminación.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado en PowerPoint, de arriba a abajo: **Flat**, **Round** y **Square**.

![Terminaciones plana, redonda y cuadrada en líneas gruesas idénticas en PowerPoint](line-caps.png)

## **Aplicar efectos de boceto a las líneas de forma**

Un efecto de boceto hace que la línea de una forma parezca dibujada a mano. Utilice [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) para acceder a la configuración de la línea, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) para acceder a la configuración del boceto, y [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) para seleccionar un valor de la clase [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/).

El siguiente código Java muestra cómo aplicar un efecto [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/), leer el valor asignado explícitamente y eliminar el efecto con [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

El valor devuelto por [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) representa la configuración asignada directamente a la forma. Si el formato de línea puede heredarse de un tema, diapositiva maestra o diapositiva de diseño, utilice [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--), acceda a [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--), y lea [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--). El valor efectivo refleja el formato que realmente se aplica después de resolver la herencia. Este ejemplo requiere una presentación existente con al menos una forma en la primera diapositiva y muestra ambos valores:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    ILineFormat lineFormat = shape.getLineFormat();
    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formato de estilos de unión**

A continuación se presentan las tres opciones de tipo de unión:

* Round
* Miter
* Bevel

El estilo de unión controla cómo se encuentran dos segmentos de contorno en una esquina. Use **Round** para esquinas redondeadas, **Miter** para esquinas agudas o **Bevel** para esquinas aplanadas.

![El estilo de unión en la presentación](join-style-powerpoint.png)

Este ejemplo crea tres rectángulos negros con contornos azules de 15 puntos de ancho. Utiliza [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) para aplicar los valores miter, bevel y round de [LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/), respectivamente, y comparar cómo se dibujan las esquinas.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Limitar uniones de inglete en esquinas agudas**

Utilice [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) junto con [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) establecido en [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) para limitar la extensión que puede tener una esquina aguda.

El límite es una proporción entre la distancia de la esquina interior y la exterior de la unión respecto al ancho de la línea. Por ejemplo, un valor de `8` permite una longitud de inglete de hasta ocho veces el ancho de la línea; no es una medida en puntos. Si la esquina excediera el límite, PowerPoint utiliza una unión biselada en esa esquina. Un límite mayor permite puntas más agudas. La configuración afecta solo a las uniones de inglete y no produce ningún efecto visible cuando la esquina se mantiene dentro de ambos límites.

Este ejemplo crea dos triángulos idénticos sin relleno con contornos de 20 puntos de ancho. El triángulo izquierdo usa un límite de `2`, y el derecho usa `8`. Cada triángulo mide 80 puntos de ancho y 160 puntos de alto, lo que da a su esquina superior una proporción longitud‑de‑inglete‑a‑ancho‑de‑línea de aproximadamente `4.12`. En consecuencia, PowerPoint bisela la cúspide izquierda y conserva la cúspide derecha.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado en PowerPoint: **Límite de inglete 2** a la izquierda y **límite de inglete 8** a la derecha.

![Una cúspide biselada con límite de inglete 2 y una cúspide puntiaguda con límite de inglete 8 en PowerPoint](miter-limits.png)

## **Relleno degradado**

Un relleno degradado mezcla colores a lo largo de una forma. Este ejemplo rellena una elipse con un degradado lineal a 45 grados de rojo a púrpura mediante [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--). El método [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) coloca las paradas de color en 0 y 1, el inicio y el final del degradado. Eliminar las paradas existentes garantiza que solo se usen estos dos colores.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![La elipse con relleno degradado](gradient-fill.png)

Si un degradado se ve diferente en una imagen exportada respecto a PowerPoint, consulte [Choose a Gradient Rendering Style](/slides/es/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Puede seleccionar un estilo de renderizado sin cambiar el degradado almacenado en la presentación.

### **Establecer el ángulo del degradado lineal**

Utilice [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) para controlar la orientación de un relleno [GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/). El ángulo se mide en grados y aumenta en sentido horario: `0` va de izquierda a derecha, `90` de arriba a abajo, `180` de derecha a izquierda y `270` de abajo a arriba. Se admiten ángulos fraccionarios. Los ángulos finitos fuera del intervalo `[0, 360)` se normalizan a una revolución; por ejemplo, `-45` pasa a `315` y `360` pasa a `0`.

Este ejemplo crea seis rectángulos con paradas de color rojo, verde y azul idénticas en las posiciones `0`, `0.5` y `1`. La escala está desactivada para que el ángulo pueda compararse independientemente de las proporciones de los rectángulos. Los ángulos, de izquierda a derecha, son `0`, `45` y `90` en la primera fila, y `135`, `180` y `270` en la segunda fila.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado en PowerPoint:

![Degradados lineales a 0, 45 y 90 grados en la fila superior, y a 135, 180 y 270 grados en la fila inferior](linear-gradient-angles.png)

### **Escalar un degradado lineal con la forma**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) acepta un valor [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/). Establézcalo explícitamente en `False` para mantener constante el ángulo geométrico del degradado cuando cambien las proporciones de la forma, o en `True` para escalar el degradado con el ancho y alto de la forma. Con la escala activada, el ángulo visible puede diferir del ángulo asignado en una forma no cuadrada.

El siguiente ejemplo usa un ángulo de `45` grados y las mismas paradas de color que en la comparación de ángulos. La columna izquierda usa `False`; la derecha usa `True`. Cada columna contiene un rectángulo ancho encima de un rectángulo alto. Ambos empiezan con las mismas dimensiones anchas; al cambiar el ancho y alto del segundo rectángulo se muestra cómo responde el relleno al redimensionado sin cambiar su configuración de degradado.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado en PowerPoint, con la escala desactivada a la izquierda y habilitada a la derecha:

![Rectángulos anchos y altos con un degradado de 45 grados, comparando LinearGradientScaled False a la izquierda con True a la derecha](linear-gradient-scaling.png)

Con la escala desactivada, las bandas de color diagonal mantienen la misma orientación en ambos rectángulos. Con la escala activada, las bandas se estiran con las proporciones de la forma. Esto ayuda a reproducir el degradado de una plantilla al adaptar una forma a un tamaño diferente. En una forma cuadrada, activar la escala no modifica la apariencia de este degradado de `45` grados.

Tanto el ángulo como la configuración de escala se aplican a degradados lineales. No controlan los rellenos [GradientShape.Radial o GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/).

### **Combinar el ángulo con la dirección del degradado**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) selecciona un estilo de degradado de la clase [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/); no sustituye a un ángulo numérico. Para un degradado lineal, los estilos de esquina pueden cambiar el área sobre la que se distribuyen los colores sin modificar el ángulo asignado mediante [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). Mantenga la dirección sin cambios al comparar ángulos o escalas.

El siguiente ejemplo aplica los mismos ajustes en orden inverso. Los dos rectángulos tienen el mismo aspecto: asignar la dirección antes o después del ángulo no cambia el resultado.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Relleno de patrón**

Un relleno de patrón aplica un diseño de dos colores, como puntos, rayas o cuadros. Este ejemplo utiliza [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) para seleccionar un patrón de celosía. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) proporciona el fondo gris claro, y [IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) suministra el color amarillo del patrón.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.rgb(192, 192, 192));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![El rectángulo con relleno de patrón](pattern-fill.png)

## **Relleno de imagen**

Un relleno de imagen usa una foto dentro de una forma. Este ejemplo necesita una imagen local y utiliza [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) para cargarla en la colección de imágenes de la presentación. Establecer [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) en modo mosaico repite la imagen dentro del rectángulo. La imagen origen usada aquí se muestra a continuación:

![La imagen del loto](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![La forma con relleno de imagen](picture-fill.png)

### **Mosaico de imagen como textura**

Si desea establecer una imagen en mosaico como textura y personalizar el comportamiento del mosaico, puede usar los siguientes métodos de la interfaz [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) y la clase [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Establece el modo de relleno de imagen — `Tile` o `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Especifica la alineación de los mosaicos dentro de la forma.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Controla si el mosaico se voltea horizontalmente, verticalmente o en ambas direcciones.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Establece el desplazamiento horizontal del mosaico (en puntos) desde el origen de la forma.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Establece el desplazamiento vertical del mosaico (en puntos) desde el origen de la forma.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Define la escala horizontal del mosaico como porcentaje.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Define la escala vertical del mosaico como porcentaje.

Este ejemplo necesita una imagen local y configura [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) para repetirla al 50 % de su tamaño original. Desplazamientos de −32 puntos mueven los mosaicos horizontal y verticalmente; la alineación inferior‑derecha y la inversión en ambas direcciones determinan cómo se organiza la textura repetida.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Opciones de mosaico](tile-options.png)

## **Relleno de color sólido**

Un relleno sólido da a una forma un único color uniforme. Este ejemplo utiliza [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) para seleccionar el modo de relleno sólido y asigna amarillo mediante [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--), luego guarda el rectángulo en una presentación.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![La forma con relleno de color sólido](solid-color-fill.png)

### **Copiar colores conservando referencias de tema**

Utilice [IColorFormat.copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) para copiar una definición de color, incluida su tipo de color, referencia de tema y transformaciones. Esto es útil al transferir el color de relleno entre formas que deben seguir el tema de la presentación. El método copia solo el color: no copia el tipo de relleno, el contorno ni otro formato de forma. Establezca explícitamente el tipo de relleno del destino con [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-).

Este ejemplo crea tres rectángulos, de izquierda a derecha: la fuente, una copia con conciencia de tema y una copia RGB fija. La fuente usa [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setSchemeColor-int-) para referenciar el primer color de acento y añade un tono mediante [IColorOperationCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icoloroperationcollection/#add-int-float-). La copia RGB usa el color de relleno efectivo de la fuente, de modo que los tres inicialmente se vean idénticos. Llamar a [IColorFormat.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setColor-java.lang.Integer-) asigna un valor RGB fijo y elimina cualquier transformación de color existente.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // Las referencias de tema siguen el nuevo color de acento; el valor RGB fijo no lo hace.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Antes del cambio de tema, los tres rellenos coinciden:

![Fuente, copia de destino y copia RGB fija con rellenos azules idénticos](color-copy-before.png)

Después del cambio de tema, la fuente y la copia con conciencia de tema siguen el nuevo color de acento y conservan su tono. La copia RGB fija sigue siendo azul:

![Fuente y copia de destino con rellenos naranjas, mientras que la copia RGB fija permanece azul](color-copy-after.png)

La definición copiada es independiente de la fuente. Cambiar posteriormente la referencia de tema de la fuente, asignar otro color o añadir o quitar sus transformaciones no modifica el destino. Un cambio de tema sigue afectando a ambas formas porque cada una hace referencia independientemente al mismo color del tema.

Al guardar y volver a abrir el PPTX se preserva el tipo de color devuelto por [IColorFormat.getColorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorType--), la referencia de tema y la colección de transformaciones devuelta por [IColorFormat.getColorTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorTransform--); no se aplana la definición a RGB.

Al copiar entre diferentes contextos de tema, como presentaciones con paletas de acento distintas, la referencia copiada se resuelve contra el tema del destino. Por lo tanto, la misma referencia y transformaciones pueden producir un color visible diferente. Consulte [Presentation Theme](/slides/es/androidjava/presentation-theme/) para obtener más información sobre la configuración de colores de tema.

## **Usar el fondo de la diapositiva como relleno de forma**

Utilice [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) cuando una forma debe coincidir con el fondo de la diapositiva, por ejemplo en una plantilla de presentación. Establezca el tipo de relleno con [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) a [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) primero para eliminar cualquier relleno explícito. Con esta combinación, la forma usa el fondo de la diapositiva en lugar de su propio relleno de estilo. Activar solo la bandera no elimina un relleno explícito existente.

Esto difiere de [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/): el relleno de fondo cubre los objetos que están detrás de la forma con el área correspondiente del fondo de la diapositiva, mientras que sin relleno deja esos objetos visibles. Un degradado permanece alineado con la diapositiva en lugar de reiniciarse dentro de cada forma.

El siguiente ejemplo crea un fondo maestro heredado por la diapositiva y coloca una banda magenta detrás de tres rectángulos. El rectángulo izquierdo usa el fondo, el del medio no tiene relleno y el derecho cambia de relleno de fondo a un relleno naranja explícito.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Heredar el degradado del maestro.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, Color.rgb(0, 0, 139));
    gradient.getGradientStops().add(1, Color.rgb(135, 206, 250));

    // Añadir este objeto primero para que aparezca detrás de los rectángulos.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // Desactivar el relleno de fondo antes de aplicar un relleno explícito.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado, de izquierda a derecha: **relleno de fondo**, **sin relleno** y **relleno explícito**. La banda magenta queda oculta tras los rectángulos izquierdo y derecho pero sigue visible a través del rectángulo del medio.

![Relleno de fondo, sin relleno y relleno naranja explícito sobre una banda magenta](background-fill.png)

El mismo comportamiento se aplica a un fondo definido directamente en la diapositiva o heredado de un diseño. La forma usa el fondo resuelto de la diapositiva; el ejemplo deja ambos fondos, de diapositiva y de diseño, sin definir para que el maestro los suministre.

## **Establecer transparencia**

Para un relleno sólido, el componente alfa del color controla la opacidad: 0 es totalmente transparente y 255 es totalmente opaco. Este ejemplo usa un valor alfa de 128 para un rectángulo amarillo, haciéndolo aproximadamente un 50 % transparente de modo que el rectángulo inferior siga siendo visible. El color se asigna mediante [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(Color.argb(128, 255, 255, 0));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![La forma transparente](shape-transparency.png)

## **Rotar formas**

Utilice [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) para rotar una forma en el plano de la diapositiva. El ángulo se mide en grados; este ejemplo rota un rectángulo 5 grados en sentido horario y guarda la presentación.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![Rotación de la forma](shape-rotation.png)

## **Añadir efectos de bisel 3D**

Utilice [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) para dar profundidad y bordes biselados a una forma. Este ejemplo crea una elipse verde con contorno naranja, usa [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) para establecer la profundidad en 4 puntos y aplica un bisel superior circular con ancho y alto de 6 puntos mediante [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--). Una cámara ortográfica frontal y una iluminación de tres puntos hacen visible el bisel.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![El efecto de bisel 3D](3D-bevel-effect.png)

## **Añadir efectos de rotación 3D**

La vista 3D de una forma se controla mediante la configuración de su cámara. Este ejemplo utiliza [ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) con ángulos de latitud, longitud y revolución de 40, 35 y 20 grados, respectivamente. Selecciona una cámara isométrica mediante [ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) y una iluminación equilibrada mediante [ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-), y luego guarda el rectángulo formateado.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El resultado:

![El efecto de rotación 3D](3D-rotation-effect.png)

## **Controlar la representación en blanco y negro para formas**

El método [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) especifica cómo se representa una forma individual cuando una presentación se visualiza o procesa en modo blanco y negro. No habilita la visualización en blanco y negro por sí mismo, y no cambia el relleno, contorno u otro formato de la forma en modo de color normal.

Utilice un valor de la clase [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) para seleccionar el comportamiento deseado. Por ejemplo, `Automatic` permite que la aplicación de renderizado elija la conversión, `Gray` y `LightGray` usan tonos de gris, `BlackWhite` usa solo negro y blanco, `Black` y `White` fuerzan un único color, `Color` conserva el color normal, y `Hidden` omite la forma en modo blanco y negro. `NotDefined` indica que no se ha asignado ningún modo a nivel de forma.

Este ejemplo crea un rectángulo naranja y utiliza [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) para seleccionar el color gris. La forma guardada conserva su relleno naranja para la visualización en color normal y solicita un color gris a las aplicaciones que respeten la configuración de visualización en blanco y negro:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

En modo de color normal, el rectángulo mantiene su relleno naranja. En un flujo de trabajo de visualización en blanco y negro, utiliza el color gris porque su modo está establecido en `Gray`. Esto permite preservar una diapositiva a todo color definiendo al mismo tiempo una apariencia distinta para impresión, vista previa u otros flujos que respeten la configuración de visualización en blanco y negro de la presentación.

## **Restablecer formato**

Utilice [ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) para restaurar la posición, el tamaño y el formato de los marcadores de posición de la diapositiva a partir de sus marcadores de posición correspondientes del diseño. Este ejemplo requiere una presentación existente con marcadores vinculados al diseño y restablece cada diapositiva antes de guardarla. Las formas sin marcadores de posición correspondientes en el diseño no se restablecen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**¿El formato de una forma afecta al tamaño final del archivo de la presentación?**

Los colores, estilos de línea y configuraciones de efectos añaden generalmente pocos datos en comparación con imágenes y medios incrustados. Los rellenos de imagen pueden aumentar el tamaño del archivo porque sus imágenes se almacenan en la presentación.

**¿Cómo puedo detectar formas en una diapositiva que compartan el mismo formato para agruparlas?**

Compare las propiedades clave de formato de cada forma—relleno, línea y configuraciones de efectos. Si todos los valores correspondientes coinciden, trate sus estilos como idénticos y agrupe lógicamente esas formas, lo que simplifica la gestión de estilos posterior.

**¿Puedo guardar un conjunto de estilos de forma personalizados en un archivo separado para reutilizarlos en otras presentaciones?**

Sí. Guarde formas de ejemplo con los estilos deseados en una plantilla de diapositivas o en un archivo .POTX. Al crear una nueva presentación, abra la plantilla, clone las formas con estilo que necesite y vuelva a aplicar su formato donde sea necesario.