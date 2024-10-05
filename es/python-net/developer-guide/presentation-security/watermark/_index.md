---
title: Marca de agua
type: docs
weight: 40
url: /python-net/watermark/
keywords:
- marca de agua
- añadir marca de agua
- marca de agua de texto
- marca de agua de imagen
- PowerPoint
- presentación
- Python
- Aspose.Slides para Python a través de .NET
description: "Añadir marcas de agua de texto e imagen a presentaciones de PowerPoint en Python"
---

## **Acerca de las Marcas de Agua**

**Una marca de agua** en una presentación es un sello de texto o imagen utilizado en una diapositiva o en todas las diapositivas de la presentación. Generalmente, una marca de agua se utiliza para indicar que la presentación es un borrador (por ejemplo, una marca de agua de "Borrador"), que contiene información confidencial (por ejemplo, una marca de agua de "Confidencial"), para especificar a qué empresa pertenece (por ejemplo, una marca de agua de "Nombre de la Empresa"), para identificar al autor de la presentación, etc. Una marca de agua ayuda a prevenir violaciones de derechos de autor al indicar que la presentación no debe ser copiada. Las marcas de agua se utilizan en los formatos de presentación de PowerPoint y OpenOffice. En Aspose.Slides, puedes agregar una marca de agua a los formatos de archivo PowerPoint PPT, PPTX y OpenOffice ODP.

En [**Aspose.Slides**](https://products.aspose.com/slides/python-net/), hay varias maneras de crear marcas de agua en documentos de PowerPoint o OpenOffice y modificar su diseño y comportamiento. El aspecto común es que para agregar marcas de agua de texto, debes usar la clase [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), y para agregar marcas de agua de imagen, utiliza la clase [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) o llena una forma de marca de agua con una imagen. `PictureFrame` implementa la clase [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), lo que te permite usar todas las configuraciones flexibles del objeto forma. Dado que `TextFrame` no es una forma y sus configuraciones son limitadas, se envuelve dentro de un objeto [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Hay dos maneras en las que se puede aplicar una marca de agua: a una sola diapositiva o a todas las diapositivas de la presentación. La Diapositiva Maestro se utiliza para aplicar una marca de agua a todas las diapositivas de la presentación: la marca de agua se añade al Diapositiva Maestro, se diseña completamente allí y se aplica a todas las diapositivas sin afectar la autorización para modificar la marca de agua en diapositivas individuales.

Se considera que una marca de agua generalmente no está disponible para ser editada por otros usuarios. Para evitar que la marca de agua (o más bien la forma principal de la marca de agua) sea editada, Aspose.Slides proporciona funcionalidad de bloqueo de formas. Una forma específica puede ser bloqueada en una diapositiva normal o en una Diapositiva Maestro. Cuando la forma de marca de agua está bloqueada en la Diapositiva Maestro, estará bloqueada en todas las diapositivas de la presentación.

Puedes establecer un nombre para la marca de agua de modo que en el futuro, si deseas eliminarla, puedas encontrarla en las formas de la diapositiva por su nombre.

Puedes diseñar la marca de agua de cualquier manera; sin embargo, generalmente hay características comunes en las marcas de agua, como la alineación al centro, la rotación, la posición al frente, etc. Consideraremos cómo usar estas características en los ejemplos a continuación.

## **Marca de Agua de Texto**

### **Agregar una Marca de Agua de Texto a una Diapositiva**

Para agregar una marca de agua de texto en PPT, PPTX o ODP, primero puedes agregar una forma a la diapositiva, luego agregar un marco de texto a esta forma. El marco de texto está representado por la clase [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). Este tipo no se hereda de [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), que tiene un amplio conjunto de propiedades para posicionar la marca de agua de manera flexible. Por lo tanto, el objeto [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) se envuelve en un objeto [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Para agregar texto de marca de agua a la forma, usa el método [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) como se muestra a continuación.

```py
watermark_text = "CONFIDENCIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar la clase TextFrame](/slides/python-net/text-formatting/)
{{% /alert %}}

### **Agregar una Marca de Agua de Texto a una Presentación**

Si deseas agregar una marca de agua de texto a toda la presentación (es decir, a todas las diapositivas a la vez), agrégala a la [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). El resto de la lógica es la misma que al agregar una marca de agua a una sola diapositiva: crea un objeto [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) y luego agrega la marca de agua utilizando el método [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENCIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar la Diapositiva Maestro](/slides/python-net/slide-master/)
{{% /alert %}}

### **Establecer la Transparencia de la Forma de Marca de Agua**

Por defecto, la forma rectangular está estilizada con colores de relleno y de línea. Las siguientes líneas de código hacen que la forma sea transparente.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Establecer la Fuente para una Marca de Agua de Texto**

Puedes cambiar la fuente de la marca de agua de texto como se muestra a continuación.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Establecer el Color del Texto de la Marca de Agua**

Para establecer el color del texto de la marca de agua, utiliza este código:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Centrar una Marca de Agua de Texto**

Es posible centrar la marca de agua en una diapositiva, y para eso, puedes hacer lo siguiente:

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

La imagen a continuación muestra el resultado final.

![La marca de agua de texto](text_watermark.png)

## **Marca de Agua de Imagen**

### **Agregar una Marca de Agua de Imagen a una Presentación**

Para agregar una marca de agua de imagen a una diapositiva de presentación, puedes hacer lo siguiente:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Bloquear una Marca de Agua para Editar**

Si es necesario prevenir que una marca de agua sea editada, utiliza la propiedad [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) en la forma. Con esta propiedad, puedes proteger la forma de ser seleccionada, redimensionada, reposicionada, agrupada con otros elementos, bloquear su texto de la edición, y mucho más:

```py
# Bloquear la forma de la marca de agua para modificar
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Traer una Marca de Agua al Frente**

En Aspose.Slides, el orden Z de las formas se puede establecer a través del método [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). Para hacer esto, debes llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De esta manera, es posible llevar una forma al frente o enviarla a la parte posterior de la diapositiva. Esta característica es especialmente útil si necesitas colocar una marca de agua frente a la presentación:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Establecer la Rotación de la Marca de Agua**

Aquí tienes un ejemplo de código sobre cómo ajustar la rotación de la marca de agua para que esté posicionada diagonalmente a través de la diapositiva:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Establecer un Nombre para una Marca de Agua**

Aspose.Slides te permite establecer el nombre de una forma. Usando el nombre de la forma, puedes acceder a ella en el futuro para modificarla o eliminarla. Para establecer el nombre de la forma de la marca de agua, asígnale a la propiedad [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) el siguiente valor:

```py
watermark_shape.name = "watermark"
```

## **Eliminar una Marca de Agua**

Para eliminar la forma de la marca de agua, utiliza el método [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) para encontrarla en las formas de la diapositiva. Luego, pasa la forma de la marca de agua al método [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Un Ejemplo en Vivo**

Tal vez quieras consultar las herramientas en línea **Aspose.Slides gratis** [Agregar Marca de Agua](https://products.aspose.app/slides/watermark) y [Eliminar Marca de Agua](https://products.aspose.app/slides/watermark/remove-watermark).

![Herramientas en línea para agregar y eliminar marcas de agua](online_tools.png)