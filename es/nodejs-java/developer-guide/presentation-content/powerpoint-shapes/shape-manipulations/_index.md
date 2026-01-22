---
title: Gestionar formas de presentación en JavaScript
linktitle: Manipulación de formas
type: docs
weight: 40
url: /es/nodejs-java/shape-manipulations/
keywords:
- forma PowerPoint
- forma de presentación
- forma en diapositiva
- buscar forma
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
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a crear, editar y optimizar formas usando JavaScript y Aspose.Slides para Node.js a través de Java y ofrecer presentaciones PowerPoint de alto rendimiento."
---

## **Buscar forma en la diapositiva**
Este tema describirá una técnica sencilla para facilitar a los desarrolladores la búsqueda de una forma específica en una diapositiva sin usar su Id interno. Es importante saber que los archivos de PowerPoint no disponen de ninguna forma de identificar las formas en una diapositiva salvo por un Id interno único. Resulta complicado para los desarrolladores encontrar una forma mediante su Id interno único. Todas las formas añadidas a las diapositivas tienen algún Texto Alternativo. Sugerimos a los desarrolladores que usen Texto Alternativo para encontrar una forma específica. Puede usar MS PowerPoint para definir el Texto Alternativo de los objetos que planea cambiar en el futuro.

Después de establecer el Texto Alternativo de cualquier forma deseada, puede abrir esa presentación usando Aspose.Slides for Node.js via Java e iterar a través de todas las formas añadidas a una diapositiva. Durante cada iteración, puede comprobar el Texto Alternativo de la forma y la forma con el Texto Alternativo coincidente será la forma que necesita. Para demostrar esta técnica de forma más clara, hemos creado un método, [findShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-) que realiza la búsqueda de una forma específica en una diapositiva y simplemente devuelve esa forma.
```javascript
// Instanciar una clase Presentation que representa el archivo de presentación
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Texto alternativo de la forma a buscar
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```


## **Clonar forma**
Para clonar una forma en una diapositiva usando Aspose.Slides for Node.js via Java:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Obtener la referencia de una diapositiva mediante su índice.
1. Acceder a la colección de formas de la diapositiva de origen.
1. Añadir una nueva diapositiva a la presentación.
1. Clonar formas de la colección de formas de la diapositiva de origen a la nueva diapositiva.
1. Guardar la presentación modificada como archivo PPTX.

El ejemplo a continuación añade una forma de grupo a una diapositiva.
```javascript
// Instanciar la clase Presentation
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // Guardar el archivo PPTX en disco
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Eliminar forma**
Aspose.Slides for Node.js via Java permite a los desarrolladores eliminar cualquier forma. Para eliminar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Acceder a la primera diapositiva.
1. Encontrar la forma con un Texto Alternativo específico.
1. Eliminar la forma.
1. Guardar el archivo en disco.
```javascript
// Crear objeto Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Agregar autoshape de tipo rectángulo
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // Guardar la presentación en disco
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Ocultar forma**
Aspose.Slides for Node.js via Java permite a los desarrolladores ocultar cualquier forma. Para ocultar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Acceder a la primera diapositiva.
1. Encontrar la forma con un Texto Alternativo específico.
1. Ocultar la forma.
1. Guardar el archivo en disco.
```javascript
// Instanciar la clase Presentation que representa el PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Agregar autoshape de tipo rectángulo
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // Guardar la presentación en disco
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Cambiar orden de las formas**
Aspose.Slides for Node.js via Java permite a los desarrolladores reordenar las formas. Reordenar una forma especifica cuál está al frente o cuál está detrás. Para reordenar las formas de cualquier diapositiva, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Acceder a la primera diapositiva.
1. Añadir una forma.
1. Añadir algo de texto en el marco de texto de la forma.
1. Añadir otra forma con las mismas coordenadas.
1. Reordenar las formas.
1. Guardar el archivo en disco.
```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Obtener ID de forma Interop**
Aspose.Slides for Node.js via Java permite a los desarrolladores obtener un identificador de forma único en el ámbito de la diapositiva, a diferencia del método [getUniqueId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getUniqueId--) que permite obtener un identificador único en el ámbito de la presentación. El método [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) se añadió a la clase [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) y a la clase [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) respectivamente. El valor devuelto por el método [getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) corresponde al valor del Id del objeto Microsoft.Office.Interop.PowerPoint.Shape. A continuación se muestra un fragmento de código de ejemplo.
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Obtener el identificador único de forma en el ámbito de la diapositiva
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Establecer Texto Alternativo para la forma**
Aspose.Slides for Node.js via Java permite a los desarrolladores establecer el AlternateText de cualquier forma. Las formas en una presentación pueden distinguirse mediante el método [AlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) o el método [Shape Name](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setName-java.lang.String-). Los métodos [setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) y [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getAlternativeText--) pueden leerse o establecerse usando Aspose.Slides así como Microsoft PowerPoint. Mediante este método, puede etiquetar una forma y realizar diferentes operaciones como eliminar una forma, ocultar una forma o reordenar formas en una diapositiva. Para establecer el AlternateText de una forma, siga los pasos a continuación:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. Acceder a la primera diapositiva.
1. Añadir cualquier forma a la diapositiva.
1. Realizar alguna operación con la forma recién añadida.
1. Recorrer las formas para encontrar una forma.
1. Establecer el AlternativeText.
1. Guardar el archivo en disco.
```javascript
// Instanciar la clase Presentation que representa el PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtener la primera diapositiva
    var sld = pres.getSlides().get_Item(0);
    // Agregar autoshape de tipo rectángulo
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // Guardar la presentación en disco
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Acceder a los formatos de diseño para la forma**
Aspose.Slides for Node.js via Java proporciona una API sencilla para acceder a los formatos de diseño de una forma. Este artículo demuestra cómo puede acceder a los formatos de diseño.

A continuación se muestra un fragmento de código de ejemplo.
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Renderizar forma como SVG**
Ahora Aspose.Slides for Node.js via Java soporta la renderización de una forma como SVG. El método [writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (y su sobrecarga) se ha añadido a la clase [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape) y a la clase [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape). Este método permite guardar el contenido de la forma como un archivo SVG. El fragmento de código a continuación muestra cómo exportar la forma de una diapositiva a un archivo SVG.
```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Alineación de formas**
Aspose.Slides permite alinear formas ya sea en relación con los márgenes de la diapositiva o entre sí. Con este fin, se ha añadido el método sobrecargado [SlidesUtil.alignShape()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-). La enumeración [ShapesAlignmentType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapesAlignmentType) define las posibles opciones de alineación.

**Ejemplo 1**

El código fuente a continuación alinea las formas con índices 1,2 y 4 a lo largo del borde superior de la diapositiva.
```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


**Ejemplo 2**

El ejemplo a continuación muestra cómo alinear toda la colección de formas en relación con la forma más baja de la colección.
```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Propiedades de volteo**
En Aspose.Slides, la clase [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) proporciona control sobre el espejo horizontal y vertical de las formas mediante sus propiedades `flipH` y `flipV`. Ambas propiedades son de tipo `byte`, permitiendo valores de `1` para indicar un volteo, `0` para no voltear, o `-1` para usar el comportamiento predeterminado. Estos valores son accesibles desde el [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) de una forma.

Para modificar la configuración de volteo, se construye una nueva instancia de [ShapeFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapeframe/) con la posición y tamaño actuales de la forma, los valores deseados para `flipH` y `flipV`, y el ángulo de rotación. Asignar esta instancia al [Frame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getFrame) de la forma y guardar la presentación aplica las transformaciones de espejo y las registra en el archivo de salida.

Supongamos que tenemos un archivo sample.pptx en el que la primera diapositiva contiene una sola forma con la configuración de volteo predeterminada, como se muestra a continuación.

![The shape to be flipped](shape_to_be_flipped.png)

El siguiente ejemplo de código recupera las propiedades de volteo actuales de la forma y la voltea tanto horizontal como verticalmente.
```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // Obtener la propiedad de volteo horizontal de la forma.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // Obtener la propiedad de volteo vertical de la forma.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Voltear horizontalmente.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Voltear verticalmente.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


El resultado:

![The flipped shape](flipped_shape.png)

## **Preguntas frecuentes**

**¿Puedo combinar formas (unir/intersectar/restar) en una diapositiva como en un editor de escritorio?**

No existe una API de operación booleana incorporada. Puede aproximarse construyendo el contorno deseado usted mismo—por ejemplo, calculando la geometría resultante (mediante [GeometryPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometrypath/)) y creando una nueva forma con ese contorno, opcionalmente eliminando las originales.

**¿Cómo puedo controlar el orden de apilamiento (z-order) para que una forma siempre permanezca «encima»?**

Cambie el orden de inserción/movimiento dentro de la colección de [shapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) de la diapositiva. Para obtener resultados predecibles, finalice el z-order después de todas las demás modificaciones de la diapositiva.

**¿Puedo «bloquear» una forma para evitar que los usuarios la editen en PowerPoint?**

Sí. Establezca banderas de protección a nivel de forma (por ejemplo, bloquear selección, movimiento, redimensionado, edición de texto). Si es necesario, refleje las restricciones en la diapositiva maestra o de diseño. Tenga en cuenta que esto es una protección a nivel de UI, no una característica de seguridad; para una protección más fuerte, combine con restricciones a nivel de archivo como recomendaciones de solo lectura o contraseñas [/slides/nodejs-java/password-protected-presentation/]( /slides/nodejs-java/password-protected-presentation/).