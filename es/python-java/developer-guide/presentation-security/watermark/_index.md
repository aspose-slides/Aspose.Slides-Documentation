---
title: Agregar marcas de agua a presentaciones en Python
linktitle: Marca de agua
type: docs
weight: 40
url: /es/python-java/watermark/
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
description: "Administre marcas de agua de texto e imagen en presentaciones de PowerPoint y OpenDocument con Python para indicar un borrador, información confidencial, derechos de autor y más."
---
## **Introducción**

**Una marca de agua** en una presentación es un sello de texto o imagen que se utiliza en una diapositiva o en todas las diapositivas de la presentación. Normalmente, una marca de agua se utiliza para indicar que la presentación es un borrador (p. ej., una marca de agua “Borrador”), que contiene información confidencial (p. ej., una marca de agua “Confidencial”), para especificar a qué empresa pertenece (p. ej., una marca de agua “Nombre de la empresa”), para identificar al autor de la presentación, etc. Una marca de agua ayuda a prevenir violaciones de derechos de autor al indicar que la presentación no debe copiarse. Las marcas de agua se usan tanto en los formatos de presentación de PowerPoint como de OpenOffice. En Aspose.Slides, puede añadir una marca de agua a los formatos de archivo PowerPoint PPT, PPTX y OpenOffice ODP.

En [**Aspose.Slides**](https://products.aspose.com/slides/es/python-java/), hay varias formas de crear marcas de agua en documentos PowerPoint u OpenOffice y modificar su diseño y comportamiento. El aspecto común es que, para añadir marcas de agua de texto, debe usar la clase [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/), y para añadir marcas de agua de imagen, use la clase [PictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/) o rellene una forma de marca de agua con una imagen. [PictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/) hereda de la clase [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/), lo que le permite usar todas las configuraciones flexibles del objeto forma. Dado que [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) no es una forma y sus configuraciones son limitadas, se envuelve en un objeto [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/).

Existen dos formas de aplicar una marca de agua: a una única diapositiva o a todas las diapositivas de la presentación. El Slide Master se utiliza para aplicar una marca de agua a todas las diapositivas — la marca de agua se añade al Slide Master, se diseña completamente allí y se aplica a todas las diapositivas sin afectar la posibilidad de modificar la marca de agua en diapositivas individuales.

Normalmente, una marca de agua se considera no disponible para su edición por otros usuarios. Para evitar que la marca de agua (o más bien la forma padre de la marca de agua) sea editada, Aspose.Slides ofrece funcionalidad de bloqueo de formas. Una forma específica puede bloquearse en una diapositiva normal o en un Slide Master. Cuando la forma de la marca de agua está bloqueada en el Slide Master, quedará bloqueada en todas las diapositivas de la presentación.

Puede asignar un nombre a la marca de agua para que, en el futuro, si desea eliminarla, pueda encontrarla entre las formas de la diapositiva por su nombre.

Puede diseñar la marca de agua de cualquier forma; sin embargo, suele haber características comunes en las marcas de agua, como alineación centrada, rotación, posición frontal, etc. Consideraremos cómo usar estas características en los ejemplos siguientes.

## **Marca de agua de texto**

### **Añadir una marca de agua de texto a una diapositiva**

Para añadir una marca de agua de texto en PPT, PPTX o ODP, puede primero añadir una forma a la diapositiva y luego agregar un marco de texto a esa forma. El marco de texto está representado por la clase [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/). Este tipo no hereda de [Shape](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/), que posee un amplio conjunto de propiedades para posicionar la marca de agua de manera flexible. Por lo tanto, el objeto [TextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/textframe/) se envuelve en un objeto [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/). Para añadir texto de marca de agua a la forma, use el método [addTextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/#addTextFrame) como se muestra a continuación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}} 
- [Cómo usar la clase TextFrame](/slides/es/python-java/text-formatting/)
{{% /alert %}}

### **Añadir una marca de agua de texto a una presentación**

Si desea agregar una marca de agua de texto a toda la presentación (es decir, a todas las diapositivas a la vez), agréguela al [MasterSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslide/). El resto de la lógica es idéntico al de agregar una marca de agua a una sola diapositiva: cree un objeto [AutoShape](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/) y luego añada la marca de agua mediante el método [addTextFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/#addTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}} 
- [Cómo usar el Slide Master](/slides/es/python-java/slide-master/)
{{% /alert %}}

### **Establecer la transparencia de la forma de la marca de agua**

De forma predeterminada, la forma rectangular tiene estilos de relleno y color de línea. Las siguientes líneas de código hacen que la forma sea transparente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **Establecer la fuente para una marca de agua de texto**

Puede cambiar la fuente de la marca de agua de texto como se muestra a continuación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **Establecer el color del texto de la marca de agua**

Para establecer el color del texto de la marca de agua, use este código:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **Centrar una marca de agua de texto**

Es posible centrar la marca de agua en una diapositiva y, para ello, puede hacer lo siguiente:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

![La marca de agua de texto](text_watermark.png)

## **Marca de agua de imagen**

### **Añadir una marca de agua de imagen a una presentación**

Para añadir una marca de agua de imagen a una diapositiva de la presentación, puede hacer lo siguiente:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **Bloquear una marca de agua para que no se edite**

Si es necesario impedir que una marca de agua sea editada, use el método [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/es/python-java/aspose.slides/autoshape/#getAutoShapeLock) sobre la forma. Con esta propiedad, puede proteger la forma contra la selección, el cambio de tamaño, el reposicionamiento, la agrupación con otros elementos, bloquear su texto para edición y mucho más:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # Bloquear la forma de la marca de agua contra la modificación.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **Traer una marca de agua al frente**

En Aspose.Slides, el orden Z de las formas se puede establecer mediante el método [ShapeCollection.reorder](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#reorder). Para ello, debe llamar a este método desde la colección de formas de la diapositiva y pasar la referencia de la forma y su número de orden al método. De este modo, es posible traer una forma al frente o enviarla al fondo de la diapositiva. Esta funcionalidad es especialmente útil si necesita colocar una marca de agua delante de la presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **Establecer la rotación de la marca de agua**

A continuación se muestra un ejemplo de código de cómo ajustar la rotación de la marca de agua para que quede posicionada diagonalmente a lo largo de la diapositiva:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **Establecer un nombre para una marca de agua**

Aspose.Slides permite asignar un nombre a una forma. Mediante el nombre de la forma, puede acceder a ella en el futuro para modificarla o eliminarla. Para establecer el nombre de la forma de la marca de agua, páselo al método [Shape.setName](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#setName):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **Eliminar una marca de agua**

Para eliminar la forma de la marca de agua, use el método [Shape.getName](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getName) para encontrarla entre las formas de la diapositiva. Luego, pase la forma de la marca de agua al método [ShapeCollection.remove](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#remove):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Qué es una marca de agua y por qué debería usarla?**

Una marca de agua es una superposición de texto o imagen aplicada a las diapositivas que ayuda a proteger la propiedad intelectual, mejorar el reconocimiento de la marca o evitar el uso no autorizado de presentaciones.

**¿Puedo añadir una marca de agua a todas las diapositivas de una presentación?**

Sí, Aspose.Slides le permite añadir programáticamente una marca de agua a cada diapositiva de una presentación. Puede iterar por todas las diapositivas y aplicar la configuración de la marca de agua individualmente.

**¿Cómo puedo ajustar la transparencia de la marca de agua?**

Puede ajustar la transparencia de la marca de agua modificando la configuración de relleno ([getFillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/shape/#getFillFormat)) de la forma. Esto garantiza que la marca de agua sea discreta y no distraiga del contenido de la diapositiva.

**¿Qué formatos de imagen son compatibles para marcas de agua?**

Aspose.Slides es compatible con diversos formatos de imagen como PNG, JPEG, GIF, BMP, SVG, entre otros.

**¿Puedo personalizar la fuente y el estilo de una marca de agua de texto?**

Sí, puede elegir cualquier fuente, tamaño y estilo para que coincidan con el diseño de su presentación y mantener la coherencia de la marca.

**¿Cómo cambio la posición o la orientación de una marca de agua?**

Puede ajustar la posición y orientación de la marca de agua programáticamente modificando las coordenadas, el tamaño y las propiedades de rotación de la forma.