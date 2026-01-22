---
title: Gestionar formas de presentación en Android
linktitle: Manipulación de formas
type: docs
weight: 40
url: /es/androidjava/shape-manipulations/
keywords:
- Forma de PowerPoint
- Forma de presentación
- Forma en diapositiva
- Buscar forma
- Clonar forma
- Eliminar forma
- Ocultar forma
- Cambiar orden de forma
- Obtener ID de forma Interop
- Texto alternativo de forma
- Formatos de diseño de forma
- Forma como SVG
- Forma a SVG
- Alinear forma
- PowerPoint
- Presentación
- Android
- Java
- Aspose.Slides
description: "Aprenda a crear, editar y optimizar formas en Aspose.Slides para Android mediante Java y entregar presentaciones de PowerPoint de alto rendimiento."
---

## **Buscar una forma en una diapositiva**
Este tema describirá una técnica sencilla para facilitar a los desarrolladores la búsqueda de una forma específica en una diapositiva sin utilizar su Id interno. Es importante saber que los archivos de PowerPoint no tienen forma de identificar las formas en una diapositiva salvo por un Id interno único. Resulta complicado para los desarrolladores localizar una forma usando su Id interno único. Todas las formas añadidas a las diapositivas tienen algún Texto alternativo. Sugerimos a los desarrolladores que utilicen el texto alternativo para encontrar una forma concreta. Puede usar MS PowerPoint para definir el texto alternativo de los objetos que planea modificar en el futuro.

Después de establecer el texto alternativo de la forma deseada, puede abrir esa presentación con Aspose.Slides for Android via Java e iterar por todas las formas añadidas a una diapositiva. En cada iteración, puede comprobar el texto alternativo de la forma y la forma con el texto alternativo coincidente será la que necesita. Para demostrar esta técnica de forma más clara, hemos creado un método, [findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) que realiza la operación de buscar una forma específica en una diapositiva y simplemente devuelve esa forma.
```java
// Instanciar una clase Presentation que representa el archivo de presentación
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Texto alternativo de la forma a encontrar
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
// Implementación del método para encontrar una forma en una diapositiva usando su texto alternativo
public static IShape findShape(ISlide slide, String alttext)
{
    // Iterando por todas las formas dentro de la diapositiva
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Si el texto alternativo de la forma coincide con el solicitado entonces
        // Devolver la forma
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```


## **Clonar una forma**
Para clonar una forma en una diapositiva usando Aspose.Slides for Android via Java:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtener la referencia de una diapositiva mediante su índice.
1. Acceder a la colección de formas de la diapositiva origen.
1. Añadir una nueva diapositiva a la presentación.
1. Clonar las formas de la colección de la diapositiva origen a la nueva diapositiva.
1. Guardar la presentación modificada como un archivo PPTX.

El ejemplo a continuación añade una forma de grupo a una diapositiva.
```java
// Instanciar la clase Presentation
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Escribir el archivo PPTX en disco
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Eliminar una forma**
Aspose.Slides for Android via Java permite a los desarrolladores eliminar cualquier forma. Para eliminar la forma de cualquier diapositiva, siga los pasos siguientes:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Acceder a la primera diapositiva.
1. Encontrar la forma con un Texto alternativo específico.
1. Eliminar la forma.
1. Guardar el archivo en disco.
```java
// Crear objeto Presentation
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Añadir forma automática de tipo rectángulo
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Guardar la presentación en disco
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Ocultar una forma**
Aspose.Slides for Android via Java permite a los desarrolladores ocultar cualquier forma. Para ocultar la forma de cualquier diapositiva, siga los pasos siguientes:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Acceder a la primera diapositiva.
1. Encontrar la forma con un Texto alternativo específico.
1. Ocultar la forma.
1. Guardar el archivo en disco.
```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Añadir forma automática de tipo rectángulo
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Guardar la presentación en disco
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Cambiar el orden de las formas**
Aspose.Slides for Android via Java permite a los desarrolladores reordenar las formas. Reordenar una forma determina cuál está al frente y cuál está detrás. Para reordenar las formas de cualquier diapositiva, siga los pasos siguientes:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Acceder a la primera diapositiva.
1. Añadir una forma.
1. Añadir texto al marco de texto de la forma.
1. Añadir otra forma con las mismas coordenadas.
1. Reordenar las formas.
1. Guardar el archivo en disco.
```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Obtener el Id de forma Interop**
Aspose.Slides for Android via Java permite a los desarrolladores obtener un identificador de forma único en el ámbito de la diapositiva, en contraste con el método [getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--) que permite obtener un identificador único a nivel de presentación. El método [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) se añadió a las interfaces [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) y a la clase [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape). El valor devuelto por el método [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) corresponde al valor del Id del objeto Microsoft.Office.Interop.PowerPoint.Shape. A continuación se muestra un fragmento de código de ejemplo.
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Obteniendo el identificador único de forma en el alcance de la diapositiva
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```


## **Establecer Texto alternativo para una forma**
Aspose.Slides for Android via Java permite a los desarrolladores establecer el AlternateText de cualquier forma. Las formas en una presentación pueden distinguirse mediante el método [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) o el método [Shape Name](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-). Los métodos [setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) y [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) pueden leerse o establecerse tanto con Aspose.Slides como con Microsoft PowerPoint. Mediante este método, puede etiquetar una forma y realizar diferentes operaciones como eliminar una forma, ocultar una forma o reordenar formas en una diapositiva. Para establecer el AlternateText de una forma, siga los pasos siguientes:

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Acceder a la primera diapositiva.
1. Añadir cualquier forma a la diapositiva.
1. Realizar alguna operación con la forma recién añadida.
1. Recorrer las formas para encontrar una forma.
1. Establecer el AlternativeText.
1. Guardar el archivo en disco.
```java
// Instanciar la clase Presentation que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Añadir forma automática de tipo rectángulo
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // Guardar la presentación en disco
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Acceder a formatos de diseño para una forma**
Aspose.Slides for Android via Java proporciona una API sencilla para acceder a los formatos de diseño de una forma. Este artículo muestra cómo puede acceder a dichos formatos.

A continuación se muestra un fragmento de código de ejemplo.
```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Renderizar una forma como SVG**
Ahora Aspose.Slides for Android via Java admite la renderización de una forma como SVG. El método [writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (y sus sobrecargas) se ha añadido a la clase [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) y a la interfaz [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape). Este método permite guardar el contenido de la forma como un archivo SVG. El fragmento de código a continuación muestra cómo exportar la forma de una diapositiva a un archivo SVG.
```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Alinear una forma**
Aspose.Slides permite alinear formas ya sea en relación con los márgenes de la diapositiva o en relación entre sí. Con este fin, se ha añadido el método sobrecargado [SlidesUtil.alignShape()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). La enumeración [ShapesAlignmentType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapesAlignmentType) define las posibles opciones de alineación.

**Ejemplo 1**

El código fuente a continuación alinea las formas con índices 1, 2 y 4 a lo largo del borde superior de la diapositiva.
```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```


**Ejemplo 2**

El ejemplo a continuación muestra cómo alinear toda la colección de formas en relación con la forma más inferior de la colección.
```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```


## **Propiedades de volteo**

En Aspose.Slides, la clase [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) ofrece control sobre el espejo horizontal y vertical de las formas a través de sus propiedades `flipH` y `flipV`. Ambas propiedades son de tipo `byte`, permitiendo valores de `1` para voltear, `0` para no voltear, o `-1` para usar el comportamiento predeterminado. Estos valores son accesibles desde el [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) de una forma.

Para modificar la configuración de volteo, se construye una nueva instancia de [ShapeFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapeframe/) con la posición y tamaño actuales de la forma, los valores deseados para `flipH` y `flipV`, y el ángulo de rotación. Asignar esta instancia al [Frame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getFrame--) de la forma y guardar la presentación aplica las transformaciones de espejo y las incorpora al archivo de salida.

Supongamos que tenemos un archivo sample.pptx en el que la primera diapositiva contiene una única forma con la configuración de volteo predeterminada, como se muestra a continuación.

![The shape to be flipped](shape_to_be_flipped.png)

El siguiente ejemplo de código recupera las propiedades de volteo actuales de la forma y la voltea tanto horizontal como verticalmente.
```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Obtener la propiedad de volteo horizontal de la forma.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Obtener la propiedad de volteo vertical de la forma.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Voltear horizontalmente.
    byte flipV = NullableBool.True; // Voltear horizontalmente.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


El resultado:

![The flipped shape](flipped_shape.png)

## **FAQ**

**¿Puedo combinar formas (unir/intersectar/restar) en una diapositiva como en un editor de escritorio?**

No existe una API incorporada de operaciones booleanas. Puede aproximarse construyendo el contorno deseado usted mismo—p. ej., calculando la geometría resultante (mediante [GeometryPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/geometrypath/)) y creando una nueva forma con ese contorno, opcionalmente eliminando las originales.

**¿Cómo puedo controlar el orden de apilamiento (z-order) para que una forma siempre quede «encima»?**

Cambie el orden de inserción/movimiento dentro de la colección de [shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) de la diapositiva. Para obtener resultados predecibles, finalice el z-order después de todas las demás modificaciones de la diapositiva.

**¿Puedo «bloquear» una forma para impedir que los usuarios la editen en PowerPoint?**

Sí. Establezca banderas de protección a nivel de forma (p. ej., bloquear selección, movimiento, redimensionado, edición de texto). Si es necesario, refleje las restricciones en la diapositiva maestra o de diseño. Tenga en cuenta que esta es una protección a nivel de UI, no una característica de seguridad; para una protección más fuerte, combine con restricciones a nivel de archivo como [recomendaciones de solo lectura o contraseñas](/slides/es/androidjava/password-protected-presentation/).