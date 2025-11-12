---
title: Añadir marcas de agua a presentaciones en Python
linktitle: Marca de agua
type: docs
weight: 40
url: /es/python-net/watermark/
keywords:
- marca de agua
- marca de agua de texto
- marca de agua de imagen
- añadir marca de agua
- cambiar marca de agua
- eliminar marca de agua
- borrar marca de agua
- añadir marca de agua a PPT
- añadir marca de agua a PPTX
- añadir marca de agua a ODP
- eliminar marca de agua de PPT
- eliminar marca de agua de PPTX
- eliminar marca de agua de ODP
- borrar marca de agua de PPT
- borrar marca de agua de PPTX
- borrar marca de agua de ODP
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a gestionar marcas de agua de texto e imagen en presentaciones de PowerPoint y OpenDocument con Python para indicar un borrador, información confidencial, derechos de autor y más."
---

## **Acerca de las marcas de agua**

**Una marca de agua** en una presentación es un sello de texto o imagen que se usa en una diapositiva o en todas las diapositivas de la presentación. Normalmente, una marca de agua se utiliza para indicar que la presentación es un borrador (p. ej., una marca de agua “Borrador”), que contiene información confidencial (p. ej., una marca de agua “Confidencial”), para especificar a qué empresa pertenece (p. ej., una marca de agua “Nombre de la empresa”), para identificar al autor de la presentación, etc. Una marca de agua ayuda a prevenir violaciones de derechos de autor al indicar que la presentación no debe ser copiada. Las marcas de agua se utilizan tanto en los formatos de presentación de PowerPoint como de OpenOffice. En Aspose.Slides, puede añadir una marca de agua a los formatos de archivo PowerPoint PPT, PPTX y OpenOffice ODP.

En [**Aspose.Slides**](https://products.aspose.com/slides/python-net/), existen diversas formas de crear marcas de agua en documentos PowerPoint o OpenOffice y de modificar su diseño y comportamiento. El aspecto común es que, para añadir marcas de agua de texto, debe usar la clase [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/), y para añadir marcas de agua de imagen, use la clase [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) o rellene una forma de marca de agua con una imagen. `PictureFrame` implementa la clase [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), lo que le permite usar todas las configuraciones flexibles del objeto forma. Dado que `TextFrame` no es una forma y sus configuraciones son limitadas, se envuelve dentro de un objeto [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Hay dos modos de aplicar una marca de agua: a una sola diapositiva o a todas las diapositivas de la presentación. El Slide Master se usa para aplicar una marca de agua a todas las diapositivas — la marca de agua se agrega al Slide Master, se diseña completamente allí y se aplica a todas las diapositivas sin afectar el permiso de modificar la marca de agua en diapositivas individuales.

Una marca de agua normalmente se considera no editable por otros usuarios. Para evitar que la marca de agua (o más bien la forma principal de la marca de agua) sea editada, Aspose.Slides proporciona funcionalidad de bloqueo de formas. Una forma específica puede bloquearse en una diapositiva normal o en un Slide Master. Cuando la forma de la marca de agua está bloqueada en el Slide Master, quedará bloqueada en todas las diapositivas de la presentación.

Puede establecer un nombre para la marca de agua de modo que, en el futuro, si desea eliminarla, pueda encontrarla entre las formas de la diapositiva por nombre.

Puede diseñar la marca de agua de cualquier forma; sin embargo, suelen existir características comunes en las marcas de agua, como alineación centrada, rotación, posición frontal, etc. Consideraremos cómo usar estas características en los ejemplos a continuación.

## **Marca de agua de texto**

### **Añadir una marca de agua de texto a una diapositiva**

Para añadir una marca de agua de texto en PPT, PPTX o ODP, primero puede agregar una forma a la diapositiva y luego añadir un cuadro de texto a esa forma. El cuadro de texto está representado por la clase [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). Este tipo no hereda de [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/), que dispone de un amplio conjunto de propiedades para posicionar la marca de agua de forma flexible. Por ello, el objeto [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) se envuelve en un objeto [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Para añadir texto de marca de agua a la forma, use el método [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str) como se muestra a continuación.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{%alert color="primary" title="Ver también"%}}
- [Cómo usar la clase TextFrame](/slides/es/python-net/text-formatting/)
{{%/alert%}}

### **Añadir una marca de agua de texto a una presentación**

Si desea añadir una marca de agua de texto a toda la presentación (es decir, a todas las diapositivas a la vez), agréguela al [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). El resto de la lógica es idéntico al de añadir una marca de agua a una sola diapositiva: cree un objeto [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) y luego añada la marca de agua mediante el método [add_text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{%alert color="primary" title="Ver también"%}}
- [Cómo usar el Slide Master](/slides/es/python-net/slide-master/)
{{%/alert%}}

### **Establecer la transparencia de la forma de la marca de agua**

De forma predeterminada, la forma rectangular tiene colores de relleno y de línea. Las siguientes líneas de código hacen que la forma sea transparente.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Establecer la fuente para una marca de agua de texto**

Puede cambiar la fuente del texto de la marca de agua como se muestra a continuación.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Establecer el color del texto de la marca de agua**

Para establecer el color del texto de la marca de agua, use este código:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Centrar una marca de agua de texto**

Es posible centrar la marca de agua en una diapositiva; para ello, puede hacer lo siguiente:

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

![The text watermark](text_watermark.png)

## **Marca de agua de imagen**

### **Añadir una marca de agua de imagen a una presentación**

Para añadir una marca de agua de imagen a una diapositiva de la presentación, puede hacer lo siguiente:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Bloquear una marca de agua para que no se edite**

Si es necesario evitar que una marca de agua sea editada, use la propiedad [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/auto_shape_lock/) de la forma. Con esta propiedad, puede proteger la forma de ser seleccionada, redimensionada, reposicionada, agrupada con otros elementos, bloquear su texto de edición y mucho más:

```py
# Bloquear la forma de la marca de agua de ser modificada
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Traer una marca de agua al frente**

En Aspose.Slides, el orden Z de las formas puede establecerse mediante el método [ShapeCollection.reorder](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). Para hacerlo, debe llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De este modo, es posible llevar una forma al frente o enviarla al fondo de la diapositiva. Esta característica es especialmente útil si necesita colocar una marca de agua delante de la presentación:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Establecer la rotación de la marca de agua**

A continuación se muestra un ejemplo de código sobre cómo ajustar la rotación de la marca de agua para que quede diagonalmente posicionada a través de la diapositiva:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Establecer un nombre para una marca de agua**

Aspose.Slides le permite establecer el nombre de una forma. Mediante el nombre de la forma, puede acceder a ella en el futuro para modificarla o eliminarla. Para establecer el nombre de la forma de la marca de agua, asígnele el valor a la propiedad [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "watermark"
```

## **Eliminar una marca de agua**

Para eliminar la forma de la marca de agua, use el método [AutoShape.name](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/name/) para encontrarla entre las formas de la diapositiva. Luego, pase la forma de la marca de agua al método [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Un ejemplo en vivo**

Puede probar las herramientas en línea gratuitas de **Aspose.Slides** [Add Watermark](https://products.aspose.app/slides/watermark) y [Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark).

![Online tools to add and remove watermarks](online_tools.png)

## **Preguntas frecuentes**

**¿Qué es una marca de agua y por qué debería usarla?**  
Una marca de agua es una superposición de texto o imagen aplicada a las diapositivas que ayuda a proteger la propiedad intelectual, mejorar el reconocimiento de la marca o impedir el uso no autorizado de presentaciones.

**¿Puedo añadir una marca de agua a todas las diapositivas de una presentación?**  
Sí, Aspose.Slides le permite añadir una marca de agua a cada diapositiva de una presentación. Puede iterar a través de todas las diapositivas y aplicar la configuración de la marca de agua individualmente.

**¿Cómo puedo ajustar la transparencia de la marca de agua?**  
Puede ajustar la transparencia de la marca de agua modificando la configuración de relleno ([FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/)) de la forma. Esto garantiza que la marca de agua sea sutil y no distraiga del contenido de la diapositiva.

**¿Qué formatos de imagen son compatibles para las marcas de agua?**  
Aspose.Slides admite varios formatos de imagen como PNG, JPEG, GIF, BMP, SVG y otros.

**¿Puedo personalizar la fuente y el estilo de una marca de agua de texto?**  
Sí, puede elegir cualquier fuente, tamaño y estilo para que coincidan con el diseño de su presentación y mantengan la coherencia de la marca.

**¿Cómo cambio la posición o la orientación de una marca de agua?**  
Puede ajustar la posición y la orientación de la marca de agua modificando las coordenadas, el tamaño y las propiedades de rotación de la [forma]((https://reference.aspose.com/slides/python-net/aspose.slides/shape/)).