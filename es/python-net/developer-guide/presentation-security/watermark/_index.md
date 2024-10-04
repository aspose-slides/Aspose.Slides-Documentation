---
title: Marca de agua
type: docs
weight: 40
url: /es/python-net/watermark/
keywords: "Marca de agua, agregar marca de agua, marca de agua de texto, marca de agua de imagen, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Agregar marca de agua de texto e imagen a la presentación de PowerPoint en Python"
---


## **Acerca de la Marca de Agua**
La **Marca de agua** en una presentación es un sello de texto o imagen, utilizado en una diapositiva o en todas las diapositivas de la presentación. Generalmente, la marca de agua se utiliza para indicar que la presentación es un borrador (por ejemplo, "Borrador" como marca de agua); que contiene información confidencial (por ejemplo, "Confidencial" como marca de agua); especificar a qué empresa pertenece (por ejemplo, "Nombre de la empresa" como marca de agua); identificar al autor de la presentación, etc. La marca de agua ayuda a prevenir la violación de derechos de autor de la presentación, indicando que no debe ser copiada. Las marcas de agua se utilizan tanto en formatos de presentación de PowerPoint como de OpenOffice. En Aspose.Slides puedes agregar marcas de agua a los formatos de archivo PPT, PPTX y ODP de PowerPoint.

En [**Aspose.Slides**](https://products.aspose.com/slides/python-net/) hay varias formas en que puedes crear marcas de agua en PowerPoint o OpenOffice, para envolverla en diferentes formas, cambiar el diseño y el comportamiento, etc. Lo común es que para agregar marcas de agua de texto debes usar la clase [**TextFrame**](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) y para agregar marca de agua de imagen - [**PictureFrame**](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/). PictureFrame implementa la interfaz [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) y puede usar todo el poder de la configuración flexible del objeto de forma. TextFrame no es una forma y sus configuraciones son limitadas. Por lo tanto, se recomienda envolver TextFrame en un objeto [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/).

Hay dos formas en que se puede aplicar una marca de agua: a una sola diapositiva y a todas las diapositivas de la presentación. El patrón de diapositiva se utiliza para aplicar marcas de agua a todas las diapositivas de la presentación: la marca de agua se agrega al patrón de diapositiva, se diseña completamente allí y se aplica a todas las diapositivas sin modificar el permiso para modificar la marca de agua en las diapositivas.

La marca de agua generalmente se considera no editable por otros usuarios. Para prevenir la edición de la marca de agua (o más bien del objeto de forma padre de la marca de agua), Aspose.Slides proporciona funcionalidad de bloqueo de forma. Una forma determinada puede ser bloqueada en una diapositiva normal o en un patrón de diapositiva. Al bloquear la forma de la marca de agua en un patrón de diapositiva, estará bloqueada en todas las diapositivas de la presentación.

Puedes establecer el nombre de la marca de agua, por lo que en el futuro, si deseas eliminar la marca de agua, puedes encontrarla en las formas de la diapositiva por nombre.

Puedes diseñar la marca de agua de cualquier manera, sin embargo, generalmente hay características comunes dentro de las marcas de agua, como: alineación centrada, rotación, posición al frente, etc. Consideraremos cómo usarlas en los ejemplos a continuación.
## **Marca de Agua de Texto**
### **Agregar Marca de Agua de Texto a la Diapositiva**
Para agregar una marca de agua de texto en PPT, PPTX o ODP, primero puedes agregar una forma a la diapositiva y luego agregar un marco de texto a esta forma. El marco de texto se representa con el tipo [**TextFrame**](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/). Este tipo no se hereda de [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/), que tiene un conjunto amplio de propiedades para establecer la marca de agua de manera flexible. Por lo tanto, se aconseja envolver el objeto [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) en un objeto [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/). Para agregar la marca de agua a la forma, usa el método [**add_text_frame**](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) con el texto de la marca de agua pasado en él:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    watermarkShape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 0, 0, 0, 0)
    watermarkTextFrame = watermarkShape.add_text_frame("Marca de agua")
    presentation.save("watermark-1.pptx", slides.export.SaveFormat.PPTX)

```



{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar ](/slides/es/python-net/slide-master/)[TextFrame](/slides/es/python-net/adding-and-formatting-text/)
{{% /alert %}}

### **Agregar Marca de Agua de Texto a la Presentación**
Si deseas agregar una marca de agua en toda la presentación (es decir, todas las diapositivas a la vez), agrégala al [**MasterSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/). Toda la lógica es la misma que al agregar una marca de agua a una sola diapositiva: crea un objeto [IAutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/) y luego agrega la marca de agua en él con el método [**add_text_frame**](https://reference.aspose.com/slides/python-net/aspose.slides/iautoshape/):

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    master = pres.masters[0]
    watermarkShape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, 0, 0, 0, 0)
    watermarkTextFrame = watermarkShape.add_text_frame("Marca de agua")
    presentation.save("watermark-2.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" title="Ver también" %}} 
- [Cómo usar ](/slides/es/python-net/slide-master/)[Patrón de Diapositiva](/slides/es/python-net/slide-master/)
{{% /alert %}}

### **Establecer Fuente de la Marca de Agua de Texto**
Puedes cambiar la fuente de la marca de agua de texto:

```py
watermarkPortion = watermarkTextFrame.paragraphs[0].portions[0]
watermarkPortion.portion_format.font_height = 52
```


### **Establecer Transparencia de la Marca de Agua de Texto**
Para establecer la transparencia de la marca de agua de texto, usa este código:

```py
watermarkPortion = watermarkTextFrame.paragraphs[0].portions[0]
watermarkPortion.portion_format.fill_format.fill_type = slides.FillType.SOLID
watermarkPortion.portion_format.fill_format.solid_fill_color.color = draw.Color.from_argb(150, 200, 200, 200)
```


### **Centrar la Marca de Agua de Texto**
Es posible centrar la marca de agua en una diapositiva y para ello puedes hacer lo siguiente:



```py
center = draw.PointF(presentation.slide_size.size.width / 2, presentation.slide_size.size.height / 2)

width = 300
height = 300

x = center.x - width / 2
y = center.y - height / 2

# ... código ...
watermarkShape = slide.shapes.add_auto_shape(slides.ShapeType.TRIANGLE, x, y, width, height)
```


## **Marca de Agua de Imagen**
### **Agregar Marca de Agua de Imagen a la Presentación**
Para agregar una marca de agua de imagen en todas las diapositivas de la presentación, puedes hacer lo siguiente:

```py
with slides.Presentation() as presentation:
    with open("image.png", "rb") as fs:
        data = fs.read()
        image = presentation.images.add_image(data)

# ...

watermarkShape.fill_format.fill_type = slides.FillType.PICTURE
watermarkShape.fill_format.picture_fill_format.picture.image = image
watermarkShape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
```




## **Bloquear Marca de Agua de Edición**
Si es necesario evitar la edición de la marca de agua, usa la propiedad [**AutoShape.shape_lock**](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) en la forma que la envuelve. Con esta propiedad puedes proteger la forma de selección, cambio de tamaño, cambio de posición, agrupación con otros elementos, bloquear su texto de edición y muchas otras:

```py
# Bloquear formas de modificar
watermarkShape.shape_lock.select_locked = True
watermarkShape.shape_lock.size_locked = True
watermarkShape.shape_lock.text_locked = True
watermarkShape.shape_lock.position_locked = True
watermarkShape.shape_lock.grouping_locked = True
```



{{% alert color="primary" title="Ver también" %}} 
- [Cómo bloquear formas de edición](/slides/es/python-net/presentation-locking/)
{{% /alert %}}

## **Traer Marca de Agua al Frente**
En Aspose.Slides, el orden Z de las formas se puede establecer mediante el método [**reorder**](https://reference.aspose.com/slides/python-net/aspose.slides.slidecollection/). Para ello, necesitas llamar a este método desde la lista de diapositivas de la presentación y pasar la referencia de la forma y su número de orden al método. De esta manera, es posible colocar la forma al frente o atrás de la diapositiva. Esta característica es especialmente útil si necesitas colocar la marca de agua al frente de la presentación:

```py
slide.shapes.reorder(len(slide.shapes) - 1, watermarkShape)
```


## **Establecer Rotación de la Marca de Agua**
Aquí hay un ejemplo de cómo establecer la rotación de la marca de agua (y su forma padre):

```py
def calculate_rotation(height, width):
	rotation = math.atan(height / width) * 180 / math.pi
	return rotation

h = presentation.slide_size.size.height
w = presentation.slide_size.size.width

watermarkShape.x = (w - watermarkShape.width) / 2
watermarkShape.y = (h - watermarkShape.height) / 2
watermarkShape.rotation = calculate_rotation(h, w)
```


## **Establecer Nombre a la Marca de Agua**
Aspose.Slides permite establecer el nombre de la forma. Por el nombre de la forma puedes acceder a ella en el futuro para modificarla o eliminarla. Para establecer el nombre de la forma padre de la marca de agua, configúralo en la propiedad [**name**](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) :

```py
watermarkShape.name = "marca de agua"
```


## **Eliminar Marca de Agua**
Para eliminar la forma de marca de agua y sus controles secundarios de la diapositiva, usa la propiedad [name](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) para encontrarla en las formas de la diapositiva. Luego, pasa la forma de la marca de agua al método [**remove**](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/):

```py
for i in range(len(slide.shapes)):
    shape = slide.shapes[i]

    if shape.name == "marca de agua":
        slide.shapes.remove(shape)
```


## **Ejemplo en Vivo**
Puede que desees consultar las herramientas en línea **gratuitas** de **Aspose.Slides** [**Agregar Marca de Agua**](https://products.aspose.app/slides/watermark) y [**Eliminar Marca de Agua**](https://products.aspose.app/slides/watermark/remove-watermark). 

![todo:texto_alt_imagen](slides-watermark.png)