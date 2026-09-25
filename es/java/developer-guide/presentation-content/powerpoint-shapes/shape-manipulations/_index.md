---
title: Gestionar formas de presentación en Java
linktitle: Manipulación de formas
type: docs
weight: 40
url: /es/java/shape-manipulations/
keywords:
- forma de PowerPoint
- forma de presentación
- forma en la diapositiva
- buscar forma
- clonar forma
- eliminar forma
- ocultar forma
- cambiar orden de forma
- obtener ID de forma interop
- texto alternativo de forma
- punto de ajuste de forma
- ajuste predefinido de forma
- geometría de forma
- formatos de diseño de forma
- forma como SVG
- forma a SVG
- alinear forma
- voltear forma
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda a identificar, ajustar, clonar, eliminar, ocultar, reordenar, exportar, alinear y voltear formas de presentación con Aspose.Slides para Java."
---
## **Visión general**

Aspose.Slides for Java representa las formas en una diapositiva como una [IShapeCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/) ordenada. La colección es tanto el lugar donde se encuentran y modifican las formas como la fuente de su orden de apilamiento: el índice `0` es la forma más trasera, mientras que el último índice es la forma más delantera.

Este artículo sigue ese modelo. Primero explica cómo identificar una forma de forma fiable y modificar los puntos de ajuste predefinidos de la forma, luego muestra cómo clonar, eliminar, ocultar y reordenar formas. Las secciones finales cubren el formato a nivel de diseño, la exportación a SVG, la alineación y la configuración de volteo. Cada ejemplo es independiente, por lo que puede usar solo las operaciones que requiera su flujo de trabajo.

## **Identificar y encontrar formas**

Los índices de la colección son convenientes al procesar un archivo conocido, pero no son identificadores estables. Añadir, eliminar o reordenar una forma puede cambiar su índice. Elija un identificador según cómo se autorice y mantenga la presentación:

- [Name](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getName--) es útil para plantillas controladas por desarrolladores y es fácil de inspeccionar en el Panel de selección de PowerPoint. Los nombres pueden editarse y no garantizan ser únicos, por lo que conviene establecer una convención de nombres si el código depende de ellos.
- [AlternativeText](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getAlternativeText--) es útil cuando una descripción de accesibilidad o una etiqueta suministrada por el autor ya identifica la forma. Es visible para los usuarios, puede localizarse o reescribirse para accesibilidad, y no garantiza ser único. No reutilice silenciosamente texto de accesibilidad significativo como clave de base de datos.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) es un identificador de solo lectura que es único dentro de una diapositiva y corresponde al ID de forma usado por la interoperabilidad de PowerPoint. Úselo al integrar con PowerPoint o cuando necesite una referencia inequívoca durante la vida útil de una forma. Una forma clonada o recreada es una forma diferente y recibe su propio ID.

El método relacionado [getUniqueId](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getUniqueId--) devuelve un identificador con alcance de presentación, pero ese identificador está pensado para complementos y puede reasignarse. No debe tratarse como una clave externa permanente. Si la identidad a largo plazo es esencial, mantenga el mapeo en datos de la aplicación y valide que la forma esperada siga existiendo.

Para un ejemplo práctico de lectura y actualización tanto del título como de la descripción del texto alternativo, consulte [Gestionar títulos y descripciones de texto alternativo](/slides/es/java/presentation-accessibility/). Use el texto alternativo para explicar el significado visual a los lectores, y manténgalo separado de los nombres de forma usados por el código para localizar formas.

El siguiente ejemplo busca por nombre con comparación exacta e informa el ID de interop con alcance de diapositiva. Cuando la plantilla no contiene la forma esperada, el código informa ese resultado en lugar de continuar con el objeto incorrecto.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Cuando una operación es específica de un tipo de forma, compruebe la interfaz antes de usar miembros específicos del tipo. Este ejemplo actualiza el texto y el texto alternativo solo si el objeto nombrado es un [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Identificar y modificar ajustes predefinidos de formas**

Las formas de geometría predefinida pueden exponer puntos de ajuste que controlan características como el tamaño de la esquina, las proporciones de la flecha o los ángulos del arco. Acceda a ellos a través de la colección de solo lectura [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/es/java/com.aspose.slides/igeometryshape/#getAdjustments--) . La colección en sí la suministra la forma, pero cada [IAdjustValue](https://reference.aspose.com/slides/es/java/com.aspose.slides/iadjustvalue/) contiene un valor que puede modificarse.

No confíe solo en un índice de colección fijo. Recorra los ajustes e inspeccione el método de solo lectura [getType](https://reference.aspose.com/slides/es/java/com.aspose.slides/iadjustvalue/#getType--) , cuyo valor [ShapeAdjustmentType](https://reference.aspose.com/slides/es/java/com.aspose.slides/shapeadjustmenttype/) describe qué controla el ajuste. El método de solo lectura [getName](https://reference.aspose.com/slides/es/java/com.aspose.slides/iadjustvalue/#getName--) proporciona información de identificación adicional y es especialmente útil cuando una predefinición contiene más de un ajuste con el mismo tipo semántico.

Use el método de valor que coincida con el significado del ajuste:

| Tipo de ajuste | Propósito | Valor a cambiar |
|---|---|---|
| `CornerSize` | Tamaño de las esquinas redondeadas | [setRawValue](https://reference.aspose.com/slides/es/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) |
| `ArrowTailThickness` | Grosor de la cola de una flecha | `setRawValue` |
| `ArrowheadLength` | Longitud de la punta de flecha | `setRawValue` |
| `ArrowheadWidth` | Ancho de la punta de flecha | `setRawValue` |
| `StartAngle` | Ángulo inicial de una porción o arco | [setAngleValue](https://reference.aspose.com/slides/es/java/com.aspose.slides/iadjustvalue/#setAngleValue-float-) |
| `EndAngle` | Ángulo final de una porción o arco | `setAngleValue` |

`getType` y `getName` devuelven información de solo lectura. `getRawValue` y `setRawValue` trabajan con un entero en las unidades nativas de la geometría predefinida, mientras que `getAngleValue` y `setAngleValue` trabajan con un ángulo en grados. El número, orden, significado y rango válido de los ajustes dependen del [ShapeType](https://reference.aspose.com/slides/es/java/com.aspose.slides/igeometryshape/#getShapeType--) predefinido. Un valor válido para una predefinición puede ser inválido o producir un efecto diferente en otra.

Cuando `getType` devuelve `ShapeAdjustmentType.Custom`, la API no reconoce un significado semántico estándar. Inspeccione `getName`, el tipo de predefinición y el valor existente, y deje el ajuste sin cambios a menos que se conozca el significado y rango esperados. Incluso para los tipos reconocidos, compruebe si el mismo tipo ocurre más de una vez antes de seleccionar un valor. El artículo [Connector](/slides/es/java/connector/) muestra esta situación con ajustes de doblez de conectores.

El siguiente ejemplo completo crea versiones predeterminadas y modificadas de tres formas predefinidas. Recorre cada ajuste, informa su nombre y tipo, cambia los valores relacionados con el tamaño mediante `setRawValue`, cambia los ángulos mediante `setAngleValue` y guarda el resultado. La columna izquierda conserva la geometría predeterminada; la columna derecha muestra el rectángulo redondeado, la flecha de cuatro puntas y la porción ajustados.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Añade encabezados para las columnas de forma predeterminada y ajustada.
    IAutoShape defaultColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    IAutoShape adjustedColumnLabel = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    IGeometryShape modifiedRoundedRectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
    IGeometryShape modifiedArrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130);
    IGeometryShape modifiedPie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    IGeometryShape[] shapesToAdjust = {
        modifiedRoundedRectangle,
        modifiedArrow,
        modifiedPie
    };

    for (IGeometryShape shape : shapesToAdjust) {
        for (int adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            IAdjustValue adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            System.out.println(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case ShapeAdjustmentType.Custom:
                    System.out.println("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Comprobar el tipo semántico antes de cambiar un valor hace que el código sea explícito respecto a su intención y evita asumir que un índice de colección concreto tiene el mismo significado en distintas formas predefinidas.

## **Modificar la colección de formas**

Los métodos de añadir, clonar, eliminar y reordenar actúan sobre la colección de inmediato. Si una operación cambia el número o el orden de las formas, no continúe basándose en índices capturados antes de esa operación.

### **Clonar una forma**

[addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) crea una copia independiente y la añade al final de la colección de destino. [insertClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) también crea una copia pero la inserta en un índice de z-order especificado. Las sobrecargas que aceptan coordenadas mueven el clon sin cambiar su tamaño; las sobrecargas con ancho y alto pueden redimensionarlo también.

El ejemplo crea una diapositiva de destino, clona un rectángulo etiquetado al frente e inserta un segundo clon detrás. Los cambios en cualquiera de los clones no modifican la forma original.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Clonar copia el contenido y el formato de la forma, incluido su nombre y texto alternativo. Asigne nuevos identificadores lógicos al clon cuando esos valores deban ser únicos. Los recursos usados por formas complejas son gestionados por la presentación, pero un clon sigue siendo un nuevo elemento de la colección con una nueva identidad de forma.

### **Eliminar formas**

[remove](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) elimina un objeto de forma específico de su colección. Al eliminar varias coincidencias durante una iteración indexada, recorra desde el final para que cada índice restante siga siendo válido.

Este ejemplo elimina cada forma con un nombre designado. Lee la forma en el índice actual, no un elemento de colección fijo, y no hace casting innecesario.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Después de la eliminación, el recuento de formas y los índices de las formas posteriores cambian. Las referencias a formas no afectadas siguen siendo más fiables que los índices guardados. También considere conectores, animaciones y otras características de la presentación que puedan referirse al objeto eliminado; eliminar una forma visible puede alterar más que la apariencia de la diapositiva.

### **Ocultar una forma**

Establecer [Hidden](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#setHidden-boolean-) a `true` mantiene la forma en la colección pero evita que aparezca en la presentación normal. Su índice, formato y contenido siguen disponibles para el código, por lo que ocultar es apropiado para elementos opcionales que pueden restaurarse más tarde.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ocultar no es eliminación ni seguridad. El objeto aún puede ser descubierto y desocultado por un usuario o por código, y sigue formando parte del archivo de la presentación.

### **Cambiar el orden Z**

Las formas que se superponen se pintan según el orden de la colección. [reorder](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) mueve una forma existente a un índice objetivo sin clonarla. El índice `0` está atrás; `size() - 1` está al frente.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El rectángulo se crea primero y inicialmente está detrás de la elipse. Moverlo al índice final lo coloca al frente. Finalice el orden Z después de añadir o clonar todas las formas relacionadas, porque esas operaciones añaden o insertan nuevos elementos en la colección y pueden alterar la pila prevista.

## **Inspeccionar formas en diapositivas de diseño**

Las diapositivas normales, de diseño y maestras tienen colecciones de formas separadas. Una forma en una colección de diseño no es el mismo objeto que una forma posicionada de modo similar en una diapositiva normal. Inspeccione las formas de diseño cuando necesite comprender o cambiar el formato suministrado por un diseño.

El siguiente ejemplo lee el [FillFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getFillFormat--) y el [LineFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getLineFormat--) de cada forma de diseño sin asumir que todas las formas son `AutoShape`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Editar un diseño puede afectar a múltiples diapositivas que lo utilicen. Antes de cambiar una forma de diseño, determine si una diapositiva normal hereda el objeto o contiene una sobrescritura local, y pruebe cada diapositiva que use ese diseño.

## **Exportar una forma a SVG**

[writeAsSvg](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) escribe el contenido renderizado de una sola forma a un flujo. El resultado contiene la forma, no el fondo completo de la diapositiva ni las formas vecinas.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

Mantenga la presentación abierta mientras renderiza. La salida depende del formato de la forma y de recursos como fuentes e imágenes. Si necesita la composición completa, exporte la diapositiva en lugar de una forma individual. El llamador es el propietario del flujo y debe cerrarlo.

## **Alinear formas**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/es/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) sobrecarga alinea ya sea todas las formas o los índices de colección seleccionados. [ShapesAlignmentType](https://reference.aspose.com/slides/es/java/com.aspose.slides/shapesalignmenttype/) especifica el borde, la línea central o el modo de distribución. Establezca `alignToSlide` a `true` para usar los bordes de la diapositiva; establézcalo a `false` para alinear las formas seleccionadas entre sí.

Este ejemplo alinea tres formas al borde superior de la diapositiva. Las referencias a formas devueltas se convierten a sus índices actuales inmediatamente antes de la alineación.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La alineación cambia posiciones, no el orden Z. La alineación relativa normalmente necesita al menos dos formas, mientras que la distribución horizontal o vertical requiere suficientes formas para definir el espaciado. Recalcule los índices si modifica la colección antes de llamar al método.

## **Voltear una forma**

La clase [ShapeFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/shapeframe/) almacena posición, tamaño, ajustes de volteo horizontal y vertical, y rotación. Sus valores `getFlipH` y `getFlipV` usan [NullableBool](https://reference.aspose.com/slides/es/java/com.aspose.slides/nullablebool/) : `True` habilita el volteo, `False` lo deshabilita, y `NotDefined` preserva el estado no especificado/predeterminado.

La presentación de entrada a continuación contiene una forma sin voltear.

![La forma antes de voltear](shape_to_be_flipped.png)

El ejemplo conserva todos los demás valores del marco y reemplaza solo los dos ajustes de volteo. Esto es importante porque asignar un nuevo [Frame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) sustituye todo el marco.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La forma guardada queda reflejada horizontal y verticalmente mientras mantiene su posición, tamaño y rotación.

![La forma después de voltear](flipped_shape.png)

## **Preguntas frecuentes**

**¿Debo usar un índice de colección como identificador de forma?**

Solo para procesamiento de corta duración cuando la colección no cambiará antes de usar el índice. Prefiera una convención validada de `Name` o `AlternativeText` para plantillas creadas, o `OfficeInteropShapeId` para trabajos de interoperabilidad con PowerPoint.

**¿Ocultar una forma la elimina del orden Z?**

No. Una forma oculta permanece en la colección en el mismo índice. Puede encontrarse, reordenarse, editarse o volver a mostrarse.

**¿Por qué una forma clonada apareció delante de otra forma?**

`addClone` añade el clon al final de la colección, que es el frente del orden Z. Use `insertClone` para elegir el índice inicial o `reorder` después de añadir todas las formas.

**¿Puedo usar un índice fijo para identificar un ajuste predefinido de forma?**

Solo después de validar la predefinición exacta y la disposición de la colección. Prefiera iterar a través de `IGeometryShape.getAdjustments` y comprobar `IAdjustValue.getType`; use `IAdjustValue.getName` como información adicional cuando el mismo tipo semántico aparezca más de una vez.