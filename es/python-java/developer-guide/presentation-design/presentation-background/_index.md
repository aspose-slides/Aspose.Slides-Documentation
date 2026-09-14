---
title: Gestionar fondos de presentación en Python mediante Java
linktitle: Fondo de diapositiva
type: docs
weight: 20
url: /es/python-java/presentation-background/
keywords:
- fondo de presentación
- fondo de diapositiva
- color sólido
- color degradado
- fondo de imagen
- transparencia del fondo
- propiedades del fondo
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Aprende a establecer fondos dinámicos en archivos PowerPoint y OpenDocument usando Aspose.Slides para Python mediante Java, con consejos de código para mejorar tus presentaciones."
---
## **Introducción**

Los colores sólidos, los degradados y las imágenes se utilizan habitualmente como fondos de diapositivas. Puedes establecer el fondo para una **diapositiva normal** (una sola diapositiva) o una **diapositiva maestra** (se aplica a varias diapositivas a la vez).

![PowerPoint background](powerpoint-background.png)

## **Establecer un fondo de color sólido para una diapositiva normal**

Aspose.Slides permite establecer un color sólido como fondo de una diapositiva específica en una presentación, incluso si la presentación utiliza una diapositiva maestra. El cambio se aplica solo a la diapositiva seleccionada.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Establece el [BackgroundType](https://reference.aspose.com/slides/es/python-java/aspose.slides/backgroundtype/) de la diapositiva a `OwnBackground`.
3. Establece el [FillType](https://reference.aspose.com/slides/es/python-java/aspose.slides/filltype/) del fondo de la diapositiva a `Solid`.
4. Utiliza el método [getSolidFillColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/fillformat/#getsolidfillcolor) de [FillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/fillformat/) para especificar el color de fondo sólido.
5. Guarda la presentación modificada.

El siguiente ejemplo en Python muestra cómo establecer un color sólido azul como fondo de una diapositiva normal:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Crear una instancia de la clase Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Establecer el color de fondo de la diapositiva a azul.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # Guardar la presentación en disco.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer un fondo de color sólido para una diapositiva maestra**

Aspose.Slides permite establecer un color sólido como fondo de la diapositiva maestra en una presentación. La diapositiva maestra actúa como una plantilla que controla el formato de todas las diapositivas, por lo que al elegir un color sólido para el fondo de la diapositiva maestra, se aplica a todas las diapositivas.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Establece el [BackgroundType](https://reference.aspose.com/slides/es/python-java/aspose.slides/backgroundtype/) de la diapositiva maestra (a través de [getMasters](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getmasters)) a `OwnBackground`.
3. Establece el [FillType](https://reference.aspose.com/slides/es/python-java/aspose.slides/filltype/) del fondo de la diapositiva maestra a `Solid`.
4. Utiliza el método [getSolidFillColor](https://reference.aspose.com/slides/es/python-java/aspose.slides/fillformat/#getsolidfillcolor) para especificar el color de fondo sólido.
5. Guarda la presentación modificada.

El siguiente ejemplo en Python muestra cómo establecer un color sólido (verde) como fondo de una diapositiva maestra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

# Crear una instancia de la clase Presentation.
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Establecer el color de fondo de la diapositiva maestra a verde.
    master_slide.getBackground().setType(BackgroundType.OwnBackground)
    master_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    master_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Guardar la presentación en disco.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer un fondo degradado para una diapositiva**

Un degradado es un efecto gráfico creado mediante un cambio gradual de color. Cuando se utiliza como fondo de una diapositiva, los degradados pueden hacer que las presentaciones parezcan más artísticas y profesionales. Aspose.Slides permite establecer un color degradado como fondo de las diapositivas.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Establece el [BackgroundType](https://reference.aspose.com/slides/es/python-java/aspose.slides/backgroundtype/) de la diapositiva a `OwnBackground`.
3. Establece el [FillType](https://reference.aspose.com/slides/es/python-java/aspose.slides/filltype/) del fondo de la diapositiva a `Gradient`.
4. Utiliza el método [getGradientFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/fillformat/#getgradientformat) de [FillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/fillformat/) para configurar los ajustes de degradado que prefieras.
5. Guarda la presentación modificada.

El siguiente ejemplo en Python muestra cómo establecer un color degradado como fondo de una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, TileFlip
from java.awt import Color

# Crear una instancia de la clase Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Aplicar un efecto de degradado al fondo.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient)

    gradient_format = slide.getBackground().getFillFormat().getGradientFormat()
    gradient_format.setTileFlip(TileFlip.FlipBoth)

    # Añadir los colores del degradado. Sin paradas de degradado, el fondo recurre a una rampa predeterminada de negro a blanco.
    gradient_format.getGradientStops().add(0.0, Color.CYAN)
    gradient_format.getGradientStops().add(1.0, Color.BLUE)

    # Guardar la presentación en disco.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Establecer una imagen como fondo de diapositiva**

Además de los rellenos sólidos y degradados, Aspose.Slides permite usar imágenes como fondos de diapositivas.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/).
2. Establece el [BackgroundType](https://reference.aspose.com/slides/es/python-java/aspose.slides/backgroundtype/) de la diapositiva a `OwnBackground`.
3. Establece el [FillType](https://reference.aspose.com/slides/es/python-java/aspose.slides/filltype/) del fondo de la diapositiva a `Picture`.
4. Carga la imagen que deseas usar como fondo de la diapositiva.
5. Añade la imagen a la colección de imágenes de la presentación.
6. Utiliza el método [getPictureFillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/fillformat/#getpicturefillformat) de [FillFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/fillformat/) para asignar la imagen como fondo.
7. Guarda la presentación modificada.

El siguiente ejemplo en Python muestra cómo establecer una imagen como fondo de una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

# Crear una instancia de la clase Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Establecer propiedades de la imagen de fondo.
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)

    # Cargar la imagen.
    image = Images.fromFile("Tulips.jpg")
    # Añadir la imagen a la colección de imágenes de la presentación.
    presentation_image = presentation.getImages().addImage(image)
    image.dispose()

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    # Guardar la presentación en disco.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El siguiente fragmento de código muestra cómo establecer el tipo de relleno de fondo a una imagen en mosaico y modificar sus propiedades de mosaico:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, RectangleAlignment, SaveFormat, TileFlip

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    background = first_slide.getBackground()

    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Picture)

    new_image = Images.fromFile("image.png")
    presentation_image = presentation.getImages().addImage(new_image)
    new_image.dispose()

    # Establecer la imagen usada para el relleno del fondo.
    background_picture_fill_format = background.getFillFormat().getPictureFillFormat()
    background_picture_fill_format.getPicture().setImage(presentation_image)

    # Establecer el modo de relleno de imagen a Mosaico y ajustar las propiedades del mosaico.
    background_picture_fill_format.setPictureFillMode(PictureFillMode.Tile)
    background_picture_fill_format.setTileOffsetX(15.0)
    background_picture_fill_format.setTileOffsetY(15.0)
    background_picture_fill_format.setTileScaleX(46.0)
    background_picture_fill_format.setTileScaleY(87.0)
    background_picture_fill_format.setTileAlignment(RectangleAlignment.Center)
    background_picture_fill_format.setTileFlip(TileFlip.FlipY)

    presentation.save("TileBackground.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Nota" %}}
Read more: [Imagen de mosaico como textura](/slides/es/python-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Cambiar la transparencia de la imagen de fondo**

Es posible que desees ajustar la transparencia de la imagen de fondo de una diapositiva para que el contenido de la misma destaque. El siguiente código en Python muestra cómo cambiar la transparencia de la imagen de fondo de una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Presentation, SaveFormat

transparency_value = 30  # Por ejemplo.

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Obtener la colección de operaciones de transformación de imagen.
    image_transform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform()

    # Encontrar un efecto de transparencia fijo por porcentaje existente.
    transparency_operation = None
    for operation in image_transform:
        if isinstance(operation, AlphaModulateFixed):
            transparency_operation = operation
            break

    # Establecer el nuevo valor de transparencia.
    if transparency_operation is None:
        image_transform.addAlphaModulateFixedEffect(100 - transparency_value)
    else:
        transparency_operation.setAmount(100 - transparency_value)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obtener el valor del fondo de la diapositiva**

Aspose.Slides permite recuperar los valores efectivos del fondo de una diapositiva mediante el método [getEffective](https://reference.aspose.com/slides/es/python-java/aspose.slides/background/#geteffective) de [Background](https://reference.aspose.com/slides/es/python-java/aspose.slides/background/). Los datos devueltos exponen los formatos de relleno y efecto efectivos.

Utilizando el método [getBackground](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/#getbackground) de la clase [BaseSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslide/), puedes obtener el fondo de una diapositiva.

El siguiente ejemplo en Python muestra cómo obtener el valor efectivo del fondo de una diapositiva:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

# Crear una instancia de la clase Presentation.
presentation = Presentation("Sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Obtener el fondo efectivo, teniendo en cuenta maestro, diseño y tema.
    effective_background = slide.getBackground().getEffective()

    if effective_background.getFillFormat().getFillType() == FillType.Solid:
        print("Fill color:", effective_background.getFillFormat().getSolidFillColor())
    else:
        print("Fill type:", effective_background.getFillFormat().getFillType())
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Puedo restablecer un fondo personalizado y restaurar el fondo del tema/disposición?**

Sí. Elimina el relleno personalizado de la diapositiva y el fondo volverá a heredarse del correspondiente [layout](/slides/es/python-java/slide-layout/)/[master](/slides/es/python-java/slide-master/) (es decir, del [fondo del tema](/slides/es/python-java/presentation-theme/)).

**¿Qué ocurre con el fondo si cambio el tema de la presentación más adelante?**

Si una diapositiva tiene su propio relleno, permanecerá sin cambios. Si el fondo se hereda del [layout](/slides/es/python-java/slide-layout/)/[master](/slides/es/python-java/slide-master/), se actualizará para coincidir con el [nuevo tema](/slides/es/python-java/presentation-theme/).