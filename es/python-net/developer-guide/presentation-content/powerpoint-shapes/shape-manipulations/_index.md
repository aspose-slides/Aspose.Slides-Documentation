---
title: Manipulaciones de Formas
type: docs
weight: 40
url: /es/python-net/shape-manipulations/
keywords: "forma de PowerPoint, forma en la diapositiva, encontrar forma, clonar forma, eliminar forma, ocultar forma, cambiar orden de forma, obtener ID de forma interop, texto alternativo de forma, formatos de diseño de forma, forma como SVG, alinear forma, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Manipular formas de PowerPoint en Python"
---

## **Encontrar Forma en Diapositiva**
Este tema describirá una técnica simple para facilitar a los desarrolladores encontrar una forma específica en una diapositiva sin utilizar su Id interno. Es importante saber que los archivos de presentación de PowerPoint no tienen ninguna forma de identificar formas en una diapositiva excepto por un Id único interno. Parece ser difícil para los desarrolladores encontrar una forma utilizando su Id único interno. Todas las formas añadidas a las diapositivas tienen algún texto alternativo. Sugerimos a los desarrolladores que utilicen texto alternativo para encontrar una forma específica. Puede utilizar MS PowerPoint para definir el texto alternativo para los objetos que planea cambiar en el futuro.

Después de establecer el texto alternativo de cualquier forma deseada, puede abrir esa presentación utilizando Aspose.Slides para Python a través de .NET y recorrer todas las formas añadidas a una diapositiva. Durante cada iteración, puede verificar el texto alternativo de la forma y la forma con el texto alternativo coincidente sería la forma requerida por usted. Para demostrar esta técnica de una mejor manera, hemos creado un método, [FindShape](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) que hace el truco para encontrar una forma específica en una diapositiva y luego simplemente devuelve esa forma.

```py
import aspose.slides as slides

# Implementación del método para encontrar una forma en una diapositiva utilizando su texto alternativo
def find_shape(slide, alttext):
    for i in range(len(slide.shapes)):
        if slide.shapes[i].alternative_text == alttext:
            return slide.shapes[i]
    return None
    
# Instanciar una clase Presentation que representa el archivo de presentación
with slides.Presentation(path + "FindingShapeInSlide.pptx") as p:
    slide = p.slides[0]
    # Texto alternativo de la forma a encontrar
    shape = find_shape(slide, "Shape1")
    if shape != None:
        print("Nombre de la forma: " + shape.name)
```



## **Clonar Forma**
Para clonar una forma en una diapositiva utilizando Aspose.Slides para Python a través de .NET:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga la referencia de una diapositiva utilizando su índice.
1. Acceda a la colección de formas de la diapositiva fuente.
1. Agregue una nueva diapositiva a la presentación.
1. Clone formas de la colección de formas de la diapositiva fuente a la nueva diapositiva.
1. Guarde la presentación modificada como un archivo PPTX.

El ejemplo a continuación agrega una forma de grupo a una diapositiva.

```py
import aspose.slides as slides

# Instanciar la clase Presentation
with slides.Presentation(path + "Source Frame.pptx") as srcPres:
	sourceShapes = srcPres.slides[0].shapes
	blankLayout = srcPres.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
	destSlide = srcPres.slides.add_empty_slide(blankLayout)
	destShapes = destSlide.shapes
	destShapes.add_clone(sourceShapes[1], 50, 150 + sourceShapes[0].height)
	destShapes.add_clone(sourceShapes[2])                 
	destShapes.insert_clone(0, sourceShapes[0], 50, 150)

	# Escribir el archivo PPTX en el disco
	srcPres.save("CloneShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Eliminar Forma**
Aspose.Slides para Python a través de .NET permite a los desarrolladores eliminar cualquier forma. Para eliminar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase `Presentation`.
1. Acceda a la primera diapositiva.
1. Encuentre la forma con un TextoAlternativo específico.
1. Elimine la forma.
1. Guarde el archivo en el disco.

```py
import aspose.slides as slides

# Crear objeto Presentation
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Agregar forma automática de tipo rectángulo
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "Definido por el Usuario"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[0]
        if ashp.alternative_text == alttext:
            sld.shapes.remove(ashp)

    # Guardar la presentación en el disco
    pres.save("RemoveShape_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Ocultar Forma**
Aspose.Slides para Python a través de .NET permite a los desarrolladores ocultar cualquier forma. Para ocultar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase `Presentation`.
1. Acceda a la primera diapositiva.
1. Encuentre la forma con un TextoAlternativo específico.
1. Oculte la forma.
1. Guarde el archivo en el disco.

```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa el PPTX
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Agregar forma automática de tipo rectángulo
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    alttext = "Definido por el Usuario"
    for i in range(len(sld.shapes)):
        ashp = sld.shapes[i]
        if ashp.alternative_text == alttext:
            ashp.hidden = True

    # Guardar la presentación en el disco
    pres.save("Hiding_Shapes_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Cambiar Orden de Formas**
Aspose.Slides para Python a través de .NET permite a los desarrolladores reordenar las formas. Reordenar la forma especifica qué forma está al frente o qué forma está al fondo. Para reordenar la forma de cualquier diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase `Presentation`.
1. Acceda a la primera diapositiva.
1. Agregue una forma.
1. Agregue algún texto en el marco de texto de la forma.
1. Agregue otra forma con las mismas coordenadas.
1. Reordenar las formas.
1. Guarde el archivo en el disco.

```py
import aspose.slides as slides

with slides.Presentation(path + "HelloWorld.pptx") as presentation1:
    slide = presentation1.slides[0]
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 365, 400, 150)
    shp3.fill_format.fill_type = slides.FillType.NO_FILL
    shp3.add_text_frame(" ")

    txtFrame = shp3.text_frame
    para = txtFrame.paragraphs[0]
    portion = para.portions[0]
    portion.text="Texto de Marca de Agua Texto de Marca de Agua Texto de Marca de Agua"
    shp3 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 200, 365, 400, 150)
    slide.shapes.reorder(2, shp3)
    presentation1.save( "Reshape_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Obtener ID de Forma Interop**
Aspose.Slides para Python a través de .NET permite a los desarrolladores obtener un identificador único de forma en el ámbito de la diapositiva en contraste con la propiedad UniqueId, que permite obtener un identificador único en el ámbito de la presentación. La propiedad OfficeInteropShapeId fue añadida a las interfaces IShape y a la clase Shape respectivamente. El valor devuelto por la propiedad OfficeInteropShapeId corresponde al valor del Id del objeto Microsoft.Office.Interop.PowerPoint.Shape. A continuación se muestra un código de muestra.

```py
import aspose.slides as slides

with slides.Presentation(path + "Presentation.pptx") as presentation:
    # Obtener identificador único de forma en el ámbito de la diapositiva
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```



## **Establecer Texto Alternativo para Forma**
Aspose.Slides para Python a través de .NET permite a los desarrolladores establecer AlternateText de cualquier forma. 
Las formas en una presentación podrían ser diferenciadas por el texto alternativo o el nombre de la forma. 
La propiedad AlternativeText podría ser leída o establecida utilizando Aspose.Slides así como Microsoft PowerPoint. 
Al utilizar esta propiedad, puede etiquetar una forma y realizar diferentes operaciones como eliminar una forma, 
ocultar una forma o reordenar formas en una diapositiva.
Para establecer el texto alternativo de una forma, siga los pasos a continuación:

1. Cree una instancia de la clase `Presentation`.
1. Acceda a la primera diapositiva.
1. Agregue cualquier forma a la diapositiva.
1. Realice algún trabajo con la forma recién añadida.
1. Recorra las formas para encontrar una forma.
1. Establezca el texto alternativo.
1. Guarde el archivo en el disco.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Instanciar la clase Presentation que representa el PPTX
with slides.Presentation() as pres:
    # Obtener la primera diapositiva
    sld = pres.slides[0]

    # Agregar forma automática de tipo rectángulo
    shp1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    shp2 = sld.shapes.add_auto_shape(slides.ShapeType.MOON, 160, 40, 150, 50)
    shp2.fill_format.fill_type = slides.FillType.SOLID
    shp2.fill_format.solid_fill_color.color = draw.Color.gray

    for i in range(len(sld.shapes)):
        shape = sld.shapes[i]
        if shape != None:
            shape.alternative_text = "Definido por el Usuario"

    # Guardar la presentación en el disco
    pres.save("Set_AlternativeText_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Acceder a Formatos de Diseño para Forma**
 Aspose.Slides para Python a través de .NET proporciona una API simple para acceder a formatos de diseño para una forma. Este artículo demuestra cómo puede acceder a los formatos de diseño.

A continuación se muestra un código de muestra.

```py
import aspose.slides as slides

with slides.Presentation("Set_AlternativeText_out.pptx") as pres:
    for layoutSlide in pres.layout_slides:
        fillFormats = list(map(lambda shape: shape.fill_format, layoutSlide.shapes))
        lineFormats = list(map(lambda shape: shape.line_format, layoutSlide.shapes))
```

## **Renderizar Forma como SVG**
Ahora Aspose.Slides para Python a través de .NET soporta la renderización de una forma como svg. El método WriteAsSvg (y su sobrecarga) ha sido añadido a la clase Shape y a la interfaz IShape. Este método permite guardar el contenido de la forma como un archivo SVG. El fragmento de código a continuación muestra cómo exportar la forma de la diapositiva a un archivo SVG.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    with open("SingleShape.svg", "wb") as stream:
        pres.slides[0].shapes[0].write_as_svg(stream)
```

## Alinear Forma

A través del método sobrecargado [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/), puede 

* alinear formas en relación con los márgenes de una diapositiva. Vea el Ejemplo 1. 
* alinear formas entre sí. Vea el Ejemplo 2. 

La enumeración [ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) define las opciones de alineación disponibles.

### Ejemplo 1

Este código Python le muestra cómo alinear formas con índices 1, 2 y 4 a lo largo del borde en la parte superior de una diapositiva:
El código fuente a continuación alinea las formas con índices 1, 2 y 4 a lo largo del borde superior de la diapositiva. 

```py
import aspose.slides as slides

with slides.Presentation("OutputPresentation.pptx") as pres:
     slide = pres.slides[0]
     shape1 = slide.shapes[1]
     shape2 = slide.shapes[2]
     shape3 = slide.shapes[4]
     slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_TOP, True, pres.slides[0], [
            slide.shapes.index_of(shape1),
            slide.shapes.index_of(shape2),
            slide.shapes.index_of(shape3)])
```

### Ejemplo 2

Este código Python le muestra cómo alinear toda una colección de formas en relación con la forma inferior de la colección:

```py
import aspose.slides as slides

with slides.Presentation("example.pptx") as pres:
    slides.util.SlideUtil.align_shapes(slides.ShapesAlignmentType.ALIGN_BOTTOM, False, pres.slides[0].shapes)
```