---
title: Manipulaciones de Formas
type: docs
weight: 40
url: /androidjava/shape-manipulations/
---

## **Encontrar Forma en la Diapositiva**
Este tema describirá una técnica simple para facilitar a los desarrolladores encontrar una forma específica en una diapositiva sin usar su Id interno. Es importante saber que los archivos de presentación de PowerPoint no tienen ninguna forma de identificar formas en una diapositiva excepto por un Id único interno. Parece ser difícil para los desarrolladores encontrar una forma usando su Id único interno. Todas las formas añadidas a las diapositivas tienen algún Texto Alternativo. Sugerimos a los desarrolladores que usen texto alternativo para encontrar una forma específica. Puede usar MS PowerPoint para definir el texto alternativo para los objetos que planea cambiar en el futuro.

Después de establecer el texto alternativo de cualquier forma deseada, puede abrir esa presentación utilizando Aspose.Slides para Android a través de Java e iterar a través de todas las formas añadidas a una diapositiva. Durante cada iteración, puede comprobar el texto alternativo de la forma y la forma con el texto alternativo coincidente sería la forma requerida por usted. Para demostrar esta técnica de una mejor manera, hemos creado un método, [findShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-), que hace el truco de encontrar una forma específica en una diapositiva y luego simplemente devuelve esa forma.

```java
// Instanciar una clase de Presentación que representa el archivo de presentación
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Texto alternativo de la forma a encontrar
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Nombre de la Forma: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Implementación del método para encontrar una forma en una diapositiva usando su texto alternativo
public static IShape findShape(ISlide slide, String alttext)
{
    // Iterando a través de todas las formas dentro de la diapositiva
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Si el texto alternativo de la diapositiva coincide con el requerido entonces
        // Devolver la forma
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Clonar Forma**
Para clonar una forma a una diapositiva utilizando Aspose.Slides para Android a través de Java:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Obtenga la referencia de una diapositiva usando su índice.
1. Acceda a la colección de formas de la diapositiva fuente.
1. Agregue una nueva diapositiva a la presentación.
1. Clone formas de la colección de formas de la diapositiva fuente a la nueva diapositiva.
1. Guarde la presentación modificada como un archivo PPTX.

El siguiente ejemplo agrega una forma de grupo a una diapositiva.

```java
// Instanciar la clase Presentación
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Escribir el archivo PPTX en el disco
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Eliminar Forma**
Aspose.Slides para Android a través de Java permite a los desarrolladores eliminar cualquier forma. Para eliminar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Encuentre la forma con Texto Alternativo específico.
1. Elimine la forma.
1. Guarde el archivo en el disco.

```java
// Crear un objeto Presentación
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agregar una forma automática de tipo rectángulo
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "Definido por el Usuario";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Guardar la presentación en el disco
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ocultar Forma**
Aspose.Slides para Android a través de Java permite a los desarrolladores ocultar cualquier forma. Para ocultar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Encuentre la forma con Texto Alternativo específico.
1. Oculte la forma.
1. Guarde el archivo en el disco.

```java
// Instanciar la clase Presentación que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agregar una forma automática de tipo rectángulo
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "Definido por el Usuario";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Guardar la presentación en el disco
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Cambiar el Orden de las Formas**
Aspose.Slides para Android a través de Java permite a los desarrolladores reordenar las formas. Reordenar la forma especifica qué forma está al frente o qué forma está atrás. Para reordenar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Agregue una forma.
1. Agregue algo de texto en el marco de texto de la forma.
1. Agregue otra forma con las mismas coordenadas.
1. Reordene las formas.
1. Guarde el archivo en el disco.

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Texto de Marca de Agua Texto de Marca de Agua Texto de Marca de Agua");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Obtener ID de Forma Interop**
Aspose.Slides para Android a través de Java permite a los desarrolladores obtener un identificador único de forma en el ámbito de la diapositiva en contraste con el método [getUniqueId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getUniqueId--), que permite obtener un identificador único en el ámbito de la presentación. El método [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) fue añadido a las interfaces [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape) y la clase [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape). El valor devuelto por el método [getOfficeInteropShapeId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) corresponde al valor del Id del objeto Microsoft.Office.Interop.PowerPoint.Shape. A continuación se da un código de muestra.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Obtener identificador único de forma en el ámbito de la diapositiva
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Establecer Texto Alternativo para la Forma**
Aspose.Slides para Android a través de Java permite a los desarrolladores establecer el Texto Alternativo de cualquier forma. 
Las formas en una presentación podrían distinguirse por el método [AlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) o [Nombre de la Forma](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setName-java.lang.String-).
Los métodos [setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) y [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getAlternativeText--) se pueden leer o establecer usando Aspose.Slides así como Microsoft PowerPoint. 
Usando este método, puede etiquetar una forma y realizar diferentes operaciones como eliminar una forma, ocultar una forma o reordenar formas en una diapositiva. 
Para establecer el Texto Alternativo de una forma, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Acceda a la primera diapositiva.
1. Agregue cualquier forma a la diapositiva.
1. Realice alguna acción con la forma recién agregada.
1. Recorra las formas para encontrar una forma.
1. Establezca el Texto Alternativo.
1. Guarde el archivo en el disco.

```java
// Instanciar la clase Presentación que representa el PPTX
Presentation pres = new Presentation();
try {
    // Obtener la primera diapositiva
    ISlide sld = pres.getSlides().get_Item(0);

    // Agregar una forma automática de tipo rectángulo
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("Definido por el Usuario");
        }
    }

    // Guardar la presentación en el disco
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Acceder a Formatos de Diseño para la Forma**
Aspose.Slides para Android a través de Java proporciona una API simple para acceder a los formatos de diseño para una forma. Este artículo demuestra cómo puede acceder a los formatos de diseño.

A continuación se presenta un código de muestra.

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

## **Renderizar Forma como SVG**
Ahora Aspose.Slides para Android a través de Java admite renderizar una forma como SVG. Se ha añadido el método [writeAsSvg](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (y su sobrecarga) a la clase [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Shape) y la interfaz [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape). Este método permite guardar el contenido de la forma como un archivo SVG. El siguiente fragmento de código muestra cómo exportar la forma de una diapositiva a un archivo SVG.

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

## **Alineación de Formas**
Aspose.Slides permite alinear formas ya sea en relación con los márgenes de la diapositiva o en relación entre sí. Para este propósito, se ha agregado el método sobrecargado [SlidesUtil.alignShape()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). La enumeración [ShapesAlignmentType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ShapesAlignmentType) define las posibles opciones de alineación.

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
```

**Ejemplo 2**

El ejemplo a continuación muestra cómo alinear toda la colección de formas en relación con la forma más baja en la colección.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```