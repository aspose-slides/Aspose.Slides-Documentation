---
title: Gestionar formas de presentación en Java
linktitle: Manipulación de formas
type: docs
weight: 40
url: /es/java/shape-manipulations/
keywords:
- forma PowerPoint
- forma de presentación
- forma en diapositiva
- encontrar forma
- clonar forma
- eliminar forma
- ocultar forma
- cambiar orden de forma
- obtener ID de forma interop
- texto alternativo de forma
- formatos de diseño de forma
- forma como SVG
- forma a SVG
- alinear forma
- voltear forma
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Aprenda cómo identificar, clonar, eliminar, ocultar, reordenar, exportar, alinear y voltear formas de presentación con Aspose.Slides para Java."
---
## **Visión general**

Aspose.Slides for Java representa las formas en una diapositiva como una [IShapeCollection](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/). La colección es tanto el lugar donde se encuentran y modifican las formas como la fuente de su orden de apilamiento: el índice `0` corresponde a la forma más atrás, mientras que el último índice corresponde a la forma más al frente.

Este artículo sigue ese modelo. Primero explica cómo identificar una forma de manera fiable, luego muestra cómo clonar, eliminar, ocultar y reordenar formas. Las secciones finales cubren el formato a nivel de diseño, la exportación a SVG, la alineación y la configuración de volteo. Cada ejemplo es independiente, de modo que puedes usar solo las operaciones que requiera tu flujo de trabajo.

## **Identificar y encontrar formas**

Los índices de la colección son convenientes al procesar un archivo conocido, pero no son identificadores estables. Añadir, eliminar o reordenar una forma puede cambiar su índice. Elige un identificador según cómo se crea y mantiene la presentación:

- [Name](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getName--) es útil para plantillas controladas por el desarrollador y es fácil de inspeccionar en el panel de selección de PowerPoint. Los nombres pueden editarse y no garantizan unicidad, por lo que deberías establecer una convención de nombres si el código depende de ellos.
- [AlternativeText](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getAlternativeText--) es útil cuando una descripción de accesibilidad o una etiqueta proporcionada por el autor ya identifica la forma. Es visible para los usuarios, puede localizarse o reescribirse para accesibilidad, y no garantiza unicidad. No reutilices silenciosamente texto de accesibilidad significativo como clave de base de datos.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--) es un identificador de solo lectura que es único dentro de una diapositiva y corresponde al ID de forma utilizado por la interoperabilidad de PowerPoint. Utilízalo al integrar con PowerPoint o cuando necesites una referencia inequívoca durante la vida útil de una forma. Una forma clonada o recreada es una forma diferente y recibe su propio ID.

El método relacionado [getUniqueId](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getUniqueId--) devuelve un identificador con alcance de presentación, pero ese identificador está pensado para complementos y puede reasignarse. No debe tratarse como una clave externa permanente. Si la identidad a largo plazo es esencial, mantén el mapeo en datos de la aplicación y valida que la forma esperada siga existiendo.

El siguiente ejemplo busca por nombre con una comparación exacta e informa el ID de interop con alcance de diapositiva. Cuando la plantilla no contiene la forma esperada, el código informa ese resultado en lugar de continuar con el objeto incorrecto.

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

Cuando una operación es específica de un tipo de forma, comprueba la interfaz antes de usar miembros específicos del tipo. Este ejemplo actualiza el texto y el texto alternativo solo si el objeto nombrado es una [IAutoShape](https://reference.aspose.com/slides/es/java/com.aspose.slides/iautoshape/).

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

## **Modificar la colección de formas**

Los métodos de añadir, clonar, eliminar y reordenar operan sobre la colección inmediatamente. Si una operación cambia el número o el orden de las formas, no continúes confiando en índices capturados antes de esa operación.

### **Clonar una forma**

[addClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) crea una copia independiente y la agrega al final de la colección de destino. [insertClone](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) también crea una copia pero la coloca en un índice de orden z especificado. Las sobrecargas que aceptan coordenadas mueven el clon sin cambiar su tamaño; las sobrecargas con ancho y alto pueden redimensionarlo también.

El ejemplo crea una diapositiva de destino, clona un rectángulo etiquetado hacia el frente e inserta un segundo clon detrás. Los cambios en cualquiera de los clones no modifican la forma original.

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

Clonar copia el contenido y el formato de la forma, incluido su nombre y texto alternativo. Asigna nuevos identificadores lógicos al clon cuando esos valores deben ser únicos. Los recursos utilizados por formas complejas son gestionados por la presentación, pero un clon sigue siendo un nuevo elemento de la colección con una nueva identidad de forma.

### **Eliminar formas**

[remove](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) elimina un objeto de forma específico de su colección. Al eliminar varias coincidencias durante una iteración indexada, recorre la colección desde el final para que cada índice restante siga siendo válido.

Este ejemplo elimina cada forma con un nombre designado. Lee la forma en el índice actual, no un elemento de colección fijo, y no realiza conversiones de tipo innecesarias.

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

Después de la eliminación, el recuento de formas y los índices de las formas posteriores cambian. Las referencias a formas no afectadas siguen siendo más fiables que los índices guardados. También considera conectores, animaciones y otras características de la presentación que pueden referirse al objeto eliminado; eliminar una forma visible puede cambiar más que la apariencia de la diapositiva.

### **Ocultar una forma**

Establecer [Hidden](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#setHidden-boolean-) a `true` mantiene la forma en la colección pero evita que aparezca en la presentación normal. Su índice, formato y contenido siguen disponibles para el código, por lo que ocultar es adecuado para elementos opcionales que pueden restaurarse más tarde.

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

Ocultar no es eliminar ni es una medida de seguridad. El objeto aún puede ser descubierto y desocultado por un usuario o por código, y sigue formando parte del archivo de la presentación.

### **Cambiar el orden Z**

Las formas superpuestas se pintan en el orden de la colección. [reorder](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) mueve una forma existente a un índice objetivo sin clonarla. El índice `0` es el fondo; `size() - 1` es el frente.

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

El rectángulo se crea primero y inicialmente se sitúa detrás de la elipse. Moverlo al índice final lo coloca al frente. Finaliza el orden Z después de añadir o clonar todas las formas relacionadas, porque esas operaciones añaden o insertan nuevos elementos en la colección y pueden alterar la pila prevista.

## **Inspeccionar formas en diapositivas de diseño**

Las diapositivas normales, las diapositivas de diseño y las diapositivas maestras tienen colecciones de formas separadas. Una forma en una colección de diseño no es el mismo objeto que una forma situada de forma similar en una diapositiva normal. Inspecciona las formas de diseño cuando necesites comprender o cambiar el formato provisto por un diseño.

El siguiente ejemplo lee el [FillFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getFillFormat--) y el [LineFormat](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#getLineFormat--) de cada forma de diseño sin asumir que cada forma es una `AutoShape`.

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

Editar un diseño puede afectar a múltiples diapositivas que lo utilicen. Antes de cambiar una forma de diseño, determina si una diapositiva normal hereda el objeto o contiene una anulación local, y prueba cada diapositiva que use ese diseño.

## **Exportar una forma a SVG**

[writeAsSvg](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) escribe el contenido renderizado de una forma a un flujo. El resultado contiene la forma, no el fondo completo de la diapositiva ni las formas vecinas.

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

Mantén la presentación abierta mientras se renderiza. La salida depende del formato de la forma y de recursos como fuentes e imágenes. Si necesitas la composición completa, exporta la diapositiva en lugar de una forma individual. El llamador es quien posee el flujo y debe cerrarlo.

## **Alinear formas**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/es/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) sobrecarga alinear todas las formas o índices de colección seleccionados. [ShapesAlignmentType](https://reference.aspose.com/slides/es/java/com.aspose.slides/shapesalignmenttype/) especifica el borde, la línea central o el modo de distribución. Establece `alignToSlide` a `true` para usar los bordes de la diapositiva; establézcalo a `false` para alinear las formas seleccionadas entre sí.

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

La alineación cambia posiciones, no el orden Z. La alineación relativa normalmente necesita al menos dos formas, mientras que la distribución horizontal o vertical requiere suficientes formas para definir el espaciado. Recalcula los índices si modificas la colección antes de llamar al método.

## **Voltear una forma**

La clase [ShapeFrame](https://reference.aspose.com/slides/es/java/com.aspose.slides/shapeframe/) almacena la posición, el tamaño, las configuraciones de volteo horizontal y vertical, y la rotación. Sus valores `getFlipH` y `getFlipV` usan [NullableBool](https://reference.aspose.com/slides/es/java/com.aspose.slides/nullablebool/): `True` habilita el volteo, `False` lo deshabilita, y `NotDefined` conserva el estado no especificado/predeterminado.

La presentación de entrada a continuación contiene una forma sin voltear.

![La forma antes de voltearla](shape_to_be_flipped.png)

El ejemplo conserva todos los demás valores del marco y reemplaza solo las dos configuraciones de volteo. Esto es importante porque asignar un nuevo [Frame](https://reference.aspose.com/slides/es/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) reemplaza el marco completo.

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

![La forma después de voltearla](flipped_shape.png)

## **FAQ**

**¿Debo usar un índice de colección como identificador de forma?**

Solo para procesamiento de corta duración cuando la colección no cambiará antes de usar el índice. Prefiere una convención validada de `Name` o `AlternativeText` para plantillas creadas, o `OfficeInteropShapeId` para trabajos de interop con alcance de diapositiva.

**¿Ocultar una forma la elimina del orden Z?**

No. Una forma oculta permanece en la colección en el mismo índice. Puede encontrarse, reordenarse, editarse o volver a hacerse visible.

**¿Por qué una forma clonada apareció delante de otra forma?**

`addClone` agrega el clon al final de la colección, que es el frente del orden Z. Usa `insertClone` para elegir el índice inicial o `reorder` después de haber añadido todas las formas.