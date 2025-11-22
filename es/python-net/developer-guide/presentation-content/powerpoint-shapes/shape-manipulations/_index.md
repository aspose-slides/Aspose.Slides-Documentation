---
title: Gestionar formas en presentaciones usando Python
linktitle: Manipulación de formas
type: docs
weight: 40
url: /es/python-net/shape-manipulations/
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
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a crear, editar y optimizar formas en Aspose.Slides para Python mediante .NET y ofrecer presentaciones de alto rendimiento en PowerPoint y OpenDocument."
---

## **Visión general**

Esta guía introduce la manipulación de formas en Aspose.Slides para Python mediante .NET. Aprenda patrones prácticos para encontrar formas (incluido por Texto Alternativo), duplicar, eliminar u ocultar, reordenar, alinear y voltear, leer IDs y formato guiado por el diseño, y exportar formas individuales a SVG usando las API de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

## **Buscar formas en diapositivas**

PowerPoint identifica las formas solo por IDs internos. Asigne un Texto Alternativo único a la forma objetivo en PowerPoint, luego abra la presentación con Aspose.Slides para Python, recorra las formas de la diapositiva y seleccione la que coincida con el Texto Alternativo. El método `find_shape` implementa este enfoque y devuelve la forma coincidente.
```py
import aspose.slides as slides

# Busca una forma en una diapositiva por su texto alternativo.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Instancia la clase Presentation que representa un archivo de presentación.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Encuentra la forma con Alt Text "Shape1".
    shape = find_shape(slide, "Shape1")
    if shape is not None:
        print("Shape name:", shape.name)
```


## **Clonar formas**

Para clonar formas de una diapositiva origen a una nueva diapositiva en Aspose.Slides, siga estos pasos:

1. Cree una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) a partir del archivo origen.  
1. Obtenga la diapositiva origen por índice y su colección de formas.  
1. Recupere un diseño en blanco de la diapositiva maestra.  
1. Añada una diapositiva vacía usando ese diseño y obtenga sus formas.  
1. Clone las formas en la diapositiva destino.  
1. Guarde la presentación como PPTX.

El siguiente ejemplo de código clona formas de una diapositiva a otra.
```py
import aspose.slides as slides

# Instanciar la clase Presentation.
with slides.Presentation("sample.pptx") as presentation:
    source_shapes = presentation.slides[0].shapes
    blank_layout = presentation.masters[0].layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    target_slide = presentation.slides.add_empty_slide(blank_layout)
    target_shapes = target_slide.shapes

    target_shapes.add_clone(source_shapes[1], 50, 150 + source_shapes[0].height)
    target_shapes.add_clone(source_shapes[2])
    target_shapes.insert_clone(0, source_shapes[0], 50, 150)

    # Guardar la presentación en disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Eliminar formas**

Aspose.Slides le permite eliminar cualquier forma de una diapositiva. Por ejemplo, para borrar una forma de la primera diapositiva por su Texto Alternativo, siga estos pasos:

1. Cree una instancia de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargue el archivo.  
1. Acceda a la primera diapositiva de la colección de diapositivas.  
1. Encuentre la forma por el valor del Texto Alternativo.  
1. Elimine la forma de la colección de formas de la diapositiva.  
1. Guarde la presentación en disco en formato PPTX.
```py
import aspose.slides as slides

# Busca una forma en una diapositiva por su texto alternativo.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Instancia la clase Presentation que representa un archivo de presentación.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Busca la forma con Alt Text "User Defined".
    shape = find_shape(slide, "User Defined")
    # Elimina la forma.
    slide.shapes.remove(shape)
    # Guarda la presentación en disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Ocultar formas**

Aspose.Slides le permite ocultar cualquier forma en una diapositiva. Por ejemplo, para ocultar una forma en la primera diapositiva por su Texto Alternativo, siga estos pasos:

1. Cree una instancia de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y cargue el archivo.  
1. Acceda a la primera diapositiva de la colección de diapositivas.  
1. Encuentre la forma por el valor del Texto Alternativo.  
1. Oculte la forma.  
1. Guarde la presentación en disco en formato PPTX.
```py
# Busca una forma en una diapositiva por su texto alternativo.
def find_shape(slide, alt_text):
    for slide_shape in slide.shapes:
        if slide_shape.alternative_text == alt_text:
            return slide_shape
    return None


# Instancia la clase Presentation que representa un archivo de presentación.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Busca la forma con Alt Text "User Defined".
    shape = find_shape(slide, "User Defined")
    # Oculta la forma.
    shape.hidden = True
    # Guarda la presentación en disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Cambiar el orden de las formas**

Aspose.Slides permite a los desarrolladores reordenar formas (cambiar su orden z). El reordenamiento determina qué forma aparece delante o detrás. Por ejemplo, para reordenar dos formas en la primera diapositiva, siga los pasos a continuación:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Acceda a la primera diapositiva.  
1. Añada la primera forma (por ejemplo, un rectángulo).  
1. Añada la segunda forma (por ejemplo, un triángulo).  
1. Reordene las formas moviendo la segunda forma a la primera posición en la colección.  
1. Guarde la presentación en disco.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    # Añadir dos formas a la diapositiva.
    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 200, 150)
    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 20, 200, 200, 150)
    # Mover la segunda forma a la primera posición.
    slide.shapes.reorder(0, shape2)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Obtener el ID de forma Interop**

Aspose.Slides le permite obtener el identificador único de una forma en el ámbito de la diapositiva, a diferencia de la propiedad `unique_id`, que es única en toda la presentación. La propiedad `office_interop_shape_id` está disponible en la clase [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/). Su valor corresponde al `Id` del objeto `Microsoft.Office.Interop.PowerPoint.Shape`. A continuación se muestra un fragmento de código de ejemplo.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Obtener el identificador único de la forma dentro de la diapositiva.
    officeInteropShapeId = presentation.slides[0].shapes[0].office_interop_shape_id
```


## **Establecer el texto alternativo para las formas**

Aspose.Slides permite a los desarrolladores establecer texto alternativo para cualquier forma. Puede usar el texto alternativo para identificar y localizar formas en una presentación. La propiedad de texto alternativo puede leerse y modificarse tanto a través de Aspose.Slides como de Microsoft PowerPoint. Al etiquetar las formas con esta propiedad, podrá eliminarlas, ocultarlas o reordenarlas posteriormente en una diapositiva.

Para establecer el texto alternativo de una forma, siga estos pasos:

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).  
1. Acceda a la primera diapositiva.  
1. Añada una forma a la diapositiva.  
1. Establezca el texto alternativo.  
1. Guarde la presentación en disco.
```py
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo PPTX.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    # Añadir una forma.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 40, 150, 50)
    # Establecer el texto alternativo de la forma.
    shape.alternative_text = "User Defined"
    # Guardar la presentación en disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Acceder a formatos de diseño para las formas**

Aspose.Slides proporciona una API simple para acceder a los formatos de diseño de las formas. Esta sección muestra cómo acceder a dichos formatos.
```py
import aspose.slides as slides

with slides.Presentation(folder_path + "sample.pptx") as presentation:
    for layout_slide in presentation.layout_slides:
        fill_formats = list(map(lambda shape: shape.fill_format, layout_slide.shapes))
        line_formats = list(map(lambda shape: shape.line_format, layout_slide.shapes))
```


## **Renderizar formas como SVG**

Aspose.Slides admite la renderización de formas como SVG. El método `write_as_svg` (y sus sobrecargas) en la clase [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) le permite guardar el contenido de una forma como una imagen SVG. El fragmento de código a continuación muestra cómo exportar una forma a un archivo SVG.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    with open("output.svg", "wb") as image_stream:
        # Obtener la primera forma en la primera diapositiva.
        shape = presentation.slides[0].shapes[0]
        shape.write_as_svg(image_stream)
```


## **Alinear forma**

Usando el método `align_shape` en la clase [SlidesUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/), puede:

* Alinear formas respecto a los márgenes de una diapositiva (ver Ejemplo 1).  
* Alinear formas respecto a otras (ver Ejemplo 2).

La enumeración [ShapesAlignmentType](https://reference.aspose.com/slides/python-net/aspose.slides/shapesalignmenttype/) define las opciones de alineación disponibles.

**Ejemplo 1**

Este código Python muestra cómo alinear las formas con índices 1, 2 y 4 al borde superior de la diapositiva:
```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_TOP
slide_indices = [1, 2, 4]

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    slides.util.SlideUtil.align_shapes(align_type, True, slide, slide_indices)
```


**Ejemplo 2**

Este ejemplo Python muestra cómo alinear todas las formas de una colección respecto a la forma más baja de esa colección:
```py
import aspose.slides as slides

align_type = slides.ShapesAlignmentType.ALIGN_BOTTOM

with slides.Presentation("sample.pptx") as presentation:
    slides.util.SlideUtil.align_shapes(align_type, False, presentation.slides[0])
```


## **Propiedades de volteo**

En Aspose.Slides, la clase [ShapeFrame](https://reference.aspose.com/slides/python-net/aspose.slides/shapeframe/) proporciona control sobre el espejo horizontal y vertical de las formas mediante sus propiedades `flip_h` y `flip_v`. Ambas propiedades son del tipo [NullableBool](https://reference.aspose.com/slides/python-net/aspose.slides/nullablebool/), permitiendo valores `TRUE` para indicar un volteo, `FALSE` para no voltear, o `NOT_DEFINED` para usar el comportamiento predeterminado. Estos valores son accesibles desde el [Frame](https://reference.aspose.com/slides/python-net/aspose.slides/shape/frame/) de una forma.

Para modificar la configuración de volteo, se construye una nueva instancia de [ShapeFrame](https://reference.aspose.com/slides/python-net/aspose.slides/shapeframe/) con la posición y tamaño actuales de la forma, los valores deseados para `flip_h` y `flip_v`, y el ángulo de rotación. Asignar esta instancia al [Frame](https://reference.aspose.com/slides/python-net/aspose.slides/shape/frame/) de la forma y guardar la presentación aplica las transformaciones de espejo y las grava en el archivo de salida.

Supongamos que tenemos un archivo sample.pptx en el que la primera diapositiva contiene una única forma con la configuración de volteo predeterminada, como se muestra a continuación.

![The shape to be flipped](shape_to_be_flipped.png)

El siguiente ejemplo de código recupera las propiedades de volteo actuales de la forma y la voltea tanto horizontal como verticalmente.
```py
with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    # Recuperar la propiedad de volteo horizontal de la forma.
    horizontal_flip = shape.frame.flip_h
    print("Horizontal flip:", horizontal_flip)

    # Recuperar la propiedad de volteo vertical de la forma.
    vertical_flip = shape.frame.flip_v
    print("Vertical flip:", vertical_flip)

    x, y = shape.frame.x, shape.frame.y
    width, height = shape.frame.width, shape.frame.height
    flip_h, flip_v = slides.NullableBool.TRUE, slides.NullableBool.TRUE  # Voltear horizontal y verticalmente.
    rotation = shape.frame.rotation

    shape.frame = slides.ShapeFrame(x, y, width, height, flip_h, flip_v, rotation)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


El resultado:

![The flipped shape](flipped_shape.png)

## **Preguntas frecuentes**

**¿Puedo combinar formas (unión/intersección/resta) en una diapositiva como en un editor de escritorio?**

No existe una API de operación booleanas incorporada. Puede aproximarse construyendo el contorno deseado usted mismo—p. ej., calcule la geometría resultante (mediante [GeometryPath](https://reference.aspose.com/slides/python-net/aspose.slides/geometrypath/)) y cree una nueva forma con ese contorno, opcionalmente eliminando las originales.

**¿Cómo puedo controlar el orden de apilamiento (z-order) para que una forma siempre quede “encima”?**

Cambie el orden de inserción/movimiento dentro de la colección [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) de la diapositiva. Para resultados predecibles, finalice el z-order después de todas las demás modificaciones de la diapositiva.

**¿Puedo “bloquear” una forma para evitar que los usuarios la editen en PowerPoint?**

Sí. Establezca los [banderas de protección a nivel de forma](/slides/es/python-net/applying-protection-to-presentation/) (p. ej., bloquear selección, movimiento, cambio de tamaño, edición de texto). Si es necesario, replique las restricciones en la diapositiva maestra o de diseño. Tenga en cuenta que esta es una protección a nivel de UI, no una característica de seguridad; para una protección más robusta, combínela con restricciones a nivel de archivo como [recomendaciones de solo lectura o contraseñas](/slides/es/python-net/password-protected-presentation/).