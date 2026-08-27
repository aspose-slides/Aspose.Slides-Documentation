---
title: Gestionar formas de presentación en JavaScript
linktitle: Manipulación de formas
type: docs
weight: 40
url: /es/nodejs-java/shape-manipulations/
keywords:
- Forma de PowerPoint
- Forma de presentación
- Forma en diapositiva
- Encontrar forma
- Clonar forma
- Eliminar forma
- Ocultar forma
- Cambiar orden de forma
- Obtener ID de forma interop
- Texto alternativo de forma
- Punto de ajuste de forma
- Ajuste de forma predefinido
- Geometría de forma
- Formatos de diseño de forma
- Forma como SVG
- Forma a SVG
- Alinear forma
- Voltear forma
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a identificar, ajustar, clonar, eliminar, ocultar, reordenar, exportar, alinear y voltear formas de presentación con Aspose.Slides for Node.js via Java."
---
## **Visión general**

Aspose.Slides for Node.js via Java representa las formas en una diapositiva como una [ShapeCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/) ordenada. La colección es tanto el lugar donde se encuentran y modifican las formas como la fuente de su orden de apilamiento: el índice `0` es la forma más trasera, mientras que el último índice es la forma más delantera.

Este artículo sigue ese modelo. Primero explica cómo identificar una forma de forma fiable y modificar los puntos de ajuste predefinidos, luego muestra cómo clonar, eliminar, ocultar y reordenar formas. Las secciones finales cubren el formato a nivel de diseño, exportación a SVG, alineación y configuraciones de volteo. Cada ejemplo es independiente, por lo que puedes usar solo las operaciones que tu flujo de trabajo requiera.

## **Identificar y encontrar formas**

Los índices de la colección son cómodos al procesar un archivo conocido, pero no son identificadores estables. Añadir, eliminar o reordenar una forma puede cambiar su índice. Elige un identificador según cómo se autorice y mantenga la presentación:

- [Name](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/getname/) es útil para plantillas controladas por desarrolladores y es fácil de inspeccionar en el Panel de selección de PowerPoint. Los nombres pueden editarse y no están garantizados como únicos, así que establece una convención de nombres si el código depende de ellos.
- [AlternativeText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/getalternativetext/) es útil cuando una descripción de accesibilidad o una etiqueta proporcionada por el autor ya identifica la forma. Es visible para los usuarios, puede localizarse o reescribirse para accesibilidad, y no está garantizado como único. No reutilices silenciosamente texto de accesibilidad significativo como clave de base de datos.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) es un identificador de solo lectura que es único dentro de una diapositiva y corresponde al ID de forma usado por la interoperabilidad de PowerPoint. Úsalo al integrar con PowerPoint o cuando necesites una referencia inequívoca durante la vida útil de una forma. Una forma clonada o recreada es una forma diferente y recibe su propio ID.

El método relacionado [getUniqueId](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/getuniqueid/) devuelve un identificador con alcance de presentación, pero ese identificador está pensado para complementos y puede reasignarse. No debe tratarse como una clave externa permanente. Si la identidad a largo plazo es esencial, conserva el mapeo en datos de la aplicación y valida que la forma esperada siga existiendo.

El siguiente ejemplo busca por nombre con una comparación exacta y muestra el ID de interoperabilidad con ámbito de diapositiva. Cuando la plantilla no contiene la forma esperada, el código informa ese resultado en lugar de continuar con el objeto incorrecto.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

Cuando una operación es específica de un tipo de forma, verifica la clase en tiempo de ejecución antes de usar miembros específicos del tipo. Este ejemplo actualiza el texto y el texto alternativo solo si el objeto con nombre es un [AutoShape](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/autoshape/).

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Identificar y modificar ajustes predefinidos de forma**

Las formas de geometría predefinida pueden exponer puntos de ajuste que controlan características como el tamaño de la esquina, proporciones de flechas o ángulos de arco. Accede a ellos mediante la colección de solo lectura [GeometryShape.getAdjustments](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/geometryshape/). La colección en sí es suministrada por la forma, pero cada [AdjustValue](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/adjustvalue/) contiene un valor que puede modificarse.

No te limites a un índice de colección fijo. Itera a través de los ajustes e inspecciona el método de solo lectura [getType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/adjustvalue/) cuyo valor [ShapeAdjustmentType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapeadjustmenttype/) describe qué controla el ajuste. El método de solo lectura [getName](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/adjustvalue/getname/) aporta información de identificación adicional y es especialmente útil cuando un preajuste contiene más de un ajuste con el mismo tipo semántico.

Usa el método de valor que coincida con el significado del ajuste:

| Tipo de ajuste | Propósito | Valor a cambiar |
|---|---|---|
| `CornerSize` | Tamaño de las esquinas redondeadas | [setRawValue](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | Espesor de la cola de una flecha | `setRawValue` |
| `ArrowheadLength` | Longitud de la punta de flecha | `setRawValue` |
| `ArrowheadWidth` | Ancho de la punta de flecha | `setRawValue` |
| `StartAngle` | Ángulo inicial de una porción o arco | [setAngleValue](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | Ángulo final de una porción o arco | `setAngleValue` |

`getType` y `getName` devuelven información de solo lectura. `getRawValue` y `setRawValue` trabajan con un entero en las unidades nativas de geometría del preajuste, mientras que `getAngleValue` y `setAngleValue` trabajan con un ángulo en grados. El número, orden, significado y rango válido de ajustes dependen del preajuste [GeometryShape.getShapeType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/geometryshape/). Un valor válido para un preajuste puede ser inválido o tener un efecto diferente para otro.

Cuando `getType` devuelve `ShapeAdjustmentType.Custom`, la API no reconoce un significado semántico estándar. Inspecciona `getName`, el tipo de preajuste y el valor existente, y deja el ajuste sin cambios a menos que se conozca el significado y rango esperados. Incluso para tipos reconocidos, comprueba si el mismo tipo aparece más de una vez antes de seleccionar un valor. El artículo [Connector](/slides/es/nodejs-java/connector/) muestra esta situación con ajustes de doblez de conectores.

El siguiente ejemplo completo crea versiones predeterminadas y modificadas de tres formas predefinidas. Itera por cada ajuste, informa su nombre y tipo, cambia los valores relacionados con el tamaño mediante `setRawValue`, cambia los ángulos mediante `setAngleValue` y guarda el resultado. La columna izquierda conserva la geometría predeterminada; la columna derecha muestra el rectángulo redondeado, la flecha de cuatro direcciones y la porción ajustadas.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // Añade cabeceras para las columnas de forma predeterminada y ajustada.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Comprobar el tipo semántico antes de cambiar un valor hace que el código sea explícito sobre su intención y evita asumir que un índice de colección particular tiene el mismo significado en diferentes formas predefinidas.

## **Modificar la colección de formas**

Los métodos de añadir, clonar, eliminar y reordenar actúan sobre la colección inmediatamente. Si una operación cambia el número o el orden de las formas, no continúes confiando en índices capturados antes de esa operación.

### **Clonar una forma**

[addClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/addclone/) crea una copia independiente y la añade al final de la colección de destino. [insertClone](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/insertclone/) también crea una copia pero la coloca en un índice de orden Z especificado. Las sobrecargas que aceptan coordenadas mueven el clon sin cambiar su tamaño; las sobrecargas con ancho y alto pueden redimensionarlo también.

El ejemplo crea una diapositiva de destino, clona un rectángulo etiquetado al frente e inserta un segundo clon en la parte trasera. Los cambios en cualquiera de los clones no modifican la forma origen.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Clonar copia el contenido y el formato de la forma, incluido su nombre y texto alternativo. Asigna nuevos identificadores lógicos al clon cuando esos valores deban ser únicos. Los recursos usados por formas complejas son gestionados por la presentación, pero un clon sigue siendo un nuevo elemento de la colección con una nueva identidad de forma.

### **Eliminar formas**

[remove](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/remove/) elimina un objeto forma específico de su colección. Al eliminar varias coincidencias durante una iteración indexada, recorre desde el final para que cada índice restante siga siendo válido.

Este ejemplo elimina cada forma con un nombre designado. Lee la forma en el índice actual y no asume un tipo de forma específico.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Después de la eliminación, el recuento de formas y los índices de las formas posteriores cambian. Las referencias a formas no afectadas siguen siendo más fiables que los índices guardados. También considera conectores, animaciones y otras características de la presentación que puedan referirse al objeto eliminado; eliminar una forma visible puede cambiar más que la apariencia de la diapositiva.

### **Ocultar una forma**

Establecer [Hidden](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/sethidden/) a `true` mantiene la forma en la colección pero impide que aparezca en la presentación normal. Su índice, formato y contenido siguen disponibles para el código, por lo que ocultar es apropiado para elementos opcionales que pueden restaurarse más adelante.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ocultar no es eliminación ni seguridad. El objeto aún puede ser descubierto y desocultado por un usuario o por código, y sigue formando parte del archivo de presentación.

### **Cambiar el orden Z**

Las formas superpuestas se pintan según el orden de la colección. [reorder](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapecollection/reorder/) mueve una forma existente a un índice objetivo sin clonarla. El índice `0` es la parte trasera; `size() - 1` es la parte delantera.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

El rectángulo se crea primero y inicialmente queda detrás de la elipse. Moverlo al índice final lo coloca al frente. Finaliza el orden Z después de añadir o clonar todas las formas relacionadas, porque esas operaciones añaden o insertan nuevos elementos en la colección y pueden alterar la pila prevista.

## **Inspeccionar formas en diapositivas de diseño**

Las diapositivas normales, las diapositivas de diseño y las diapositivas maestras tienen colecciones de formas independientes. Una forma en una colección de diseño no es el mismo objeto que una forma posicionada de forma similar en una diapositiva normal. Inspecciona las formas de diseño cuando necesites comprender o cambiar el formato suministrado por un diseño.

El siguiente ejemplo lee el [FillFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/getfillformat/) y el [LineFormat](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/getlineformat/) de cada forma de diseño sin asumir que toda forma sea un `AutoShape`.

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

Editar un diseño puede afectar a múltiples diapositivas que lo utilizan. Antes de cambiar una forma de diseño, determina si una diapositiva normal hereda el objeto o contiene una anulación local, y prueba cada diapositiva que use ese diseño.

## **Exportar una forma a SVG**

[writeAsSvg](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/writeassvg/) escribe el contenido renderizado de una forma en un flujo. El resultado contiene la forma, no el fondo completo de la diapositiva ni las formas vecinas.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Mantén la presentación abierta mientras se renderiza. La salida depende del formato de la forma y de recursos como fuentes e imágenes. Si necesitas toda la composición, exporta la diapositiva en lugar de una forma individual. El llamador es quien posee el flujo y debe cerrarlo.

## **Alinear formas**

Los sobrecargas de [SlideUtil.alignShapes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideutil/alignshapes/) alinean ya sea todas las formas o los índices de colección seleccionados. [ShapesAlignmentType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapesalignmenttype/) especifica el borde, la línea central o el modo de distribución. Establece `alignToSlide` a `true` para usar los bordes de la diapositiva; establézcalo a `false` para alinear las formas seleccionadas entre sí.

Este ejemplo alinea tres formas al borde superior de la diapositiva. Las referencias a formas devueltas se convierten en sus índices actuales inmediatamente antes de la alineación.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La alineación cambia posiciones, no el orden Z. La alineación relativa normalmente necesita al menos dos formas, mientras que la distribución horizontal o vertical necesita suficientes formas para definir el espaciado. Recalcula los índices si modificas la colección antes de llamar al método.

## **Voltear una forma**

La clase [ShapeFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shapeframe/) almacena posición, tamaño, ajustes de volteo horizontal y vertical, y rotación. Sus valores `getFlipH` y `getFlipV` usan [NullableBool](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/nullablebool/): `True` habilita el volteo, `False` lo deshabilita, y `NotDefined` conserva el estado no especificado/de fábrica.

La presentación de entrada a continuación contiene una forma sin voltear.

![La forma antes de voltear](shape_to_be_flipped.png)

El ejemplo conserva todos los demás valores del marco y sustituye solo los dos ajustes de volteo. Esto es importante porque asignar un nuevo [Frame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/shape/setframe/) reemplaza el marco completo.

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La forma guardada se refleja horizontal y verticalmente mientras mantiene su posición, tamaño y rotación.

![La forma después de voltear](flipped_shape.png)

## **Preguntas frecuentes**

**¿Debo usar un índice de colección como identificador de forma?**

Solo para procesamiento de corta duración cuando la colección no cambiará antes de que se use el índice. Prefiere una convención validada de `Name` o `AlternativeText` para plantillas autoras, o `OfficeInteropShapeId` para trabajos de interoperabilidad con alcance de diapositiva.

**¿Ocultar una forma la elimina del orden Z?**

No. Una forma oculta permanece en la colección en el mismo índice. Puede encontrarse, reordenarse, editarse o volver a hacerse visible.

**¿Por qué una forma clonada apareció delante de otra forma?**

`addClone` añade el clon al final de la colección, que es el frente del orden Z. Usa `insertClone` para elegir el índice inicial o `reorder` después de que se hayan añadido todas las formas.

**¿Puedo usar un índice fijo para identificar un ajuste predefinido de forma?**

Solo después de validar el preajuste exacto y la disposición de la colección. Prefiere iterar a través de `GeometryShape.getAdjustments` y comprobar `AdjustValue.getType`; usa `AdjustValue.getName` como información adicional cuando el mismo tipo semántico aparece más de una vez.