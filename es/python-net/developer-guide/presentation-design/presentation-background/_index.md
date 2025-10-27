---
title: Gestionar fondos de presentación en Python
linktitle: Fondo de diapositiva
type: docs
weight: 20
url: /es/python-net/presentation-background/
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
- Aspose.Slides
description: "Aprenda a establecer fondos dinámicos en archivos PowerPoint y OpenDocument usando Aspose.Slides para Python a través de .NET, con consejos de código para mejorar sus presentaciones."
---

## **Visión general**

Los colores sólidos, los degradados y las imágenes se utilizan con frecuencia como fondos de diapositiva. Puede establecer el fondo para una **diapositiva normal** (una sola diapositiva) o una **diapositiva maestra** (se aplica a varias diapositivas a la vez).

![Fondo de PowerPoint](powerpoint-background.png)

## **Establecer un fondo de color sólido para una diapositiva normal**

Aspose.Slides le permite establecer un color sólido como fondo para una diapositiva específica en una presentación, incluso si la presentación utiliza una diapositiva maestra. El cambio se aplica solo a la diapositiva seleccionada.

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) de la diapositiva a `OWN_BACKGROUND`.
3. Establezca el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) del fondo de la diapositiva a `SOLID`.
4. Utilice la propiedad `solid_fill_color` en [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) para especificar el color de fondo sólido.
5. Guarde la presentación modificada.

El siguiente ejemplo en Python muestra cómo establecer un color sólido azul como fondo para una diapositiva normal:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Set the background color of the slide to blue.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Save the presentation to disk.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer un fondo de color sólido para la diapositiva maestra**

Aspose.Slides le permite establecer un color sólido como fondo para la diapositiva maestra de una presentación. La diapositiva maestra actúa como una plantilla que controla el formato de todas las diapositivas, por lo que al elegir un color sólido para el fondo de la diapositiva maestra, se aplica a cada diapositiva.

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) de la diapositiva maestra (a través de `masters`) a `OWN_BACKGROUND`.
3. Establezca el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) del fondo de la diapositiva maestra a `SOLID`.
4. Utilice la propiedad `solid_fill_color` en [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) para especificar el color de fondo sólido.
5. Guarde la presentación modificada.

El siguiente ejemplo en Python muestra cómo establecer un color sólido (verde bosque) como fondo para una diapositiva maestra:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Set the background color for the Master slide to Forest Green.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Save the presentation to disk.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer un fondo degradado para una diapositiva**

Un degradado es un efecto gráfico creado por un cambio gradual del color. Cuando se usa como fondo de diapositiva, los degradados pueden hacer que las presentaciones parezcan más artísticas y profesionales. Aspose.Slides le permite establecer un color degradado como fondo para las diapositivas.

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) de la diapositiva a `OWN_BACKGROUND`.
3. Establezca el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) del fondo de la diapositiva a `GRADIENT`.
4. Utilice la propiedad `gradient_format` en [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) para configurar sus ajustes de degradado preferidos.
5. Guarde la presentación modificada.

El siguiente ejemplo en Python muestra cómo establecer un color degradado como fondo para una diapositiva:

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Apply a gradient effect to the background.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Save the presentation to disk.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer una imagen como fondo de diapositiva**

Además de los rellenos sólidos y degradados, Aspose.Slides le permite usar imágenes como fondos de diapositiva.

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) clase.
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) de la diapositiva a `OWN_BACKGROUND`.
3. Establezca el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) del fondo de la diapositiva a `PICTURE`.
4. Cargue la imagen que desea usar como fondo de la diapositiva.
5. Añada la imagen a la colección de imágenes de la presentación.
6. Utilice la propiedad `picture_fill_format` en [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) para asignar la imagen como fondo.
7. Guarde la presentación modificada.

El siguiente ejemplo en Python muestra cómo establecer una imagen como fondo para una diapositiva:

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Set background image properties.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Load the image.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Add the image to the presentation's image collection.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Save the presentation to disk.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

El siguiente fragmento de código muestra cómo establecer el tipo de relleno de fondo a una imagen en mosaico y modificar las propiedades de teselado:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Set the image used for the background fill.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Set the picture fill mode to Tile and adjust the tile properties.
    back_picture_fill_format.picture_fill_mode = slides.PictureFillMode.TILE
    back_picture_fill_format.tile_offset_x = 15.0
    back_picture_fill_format.tile_offset_y = 15.0
    back_picture_fill_format.tile_scale_x = 46.0
    back_picture_fill_format.tile_scale_y = 87.0
    back_picture_fill_format.tile_alignment = slides.RectangleAlignment.CENTER
    back_picture_fill_format.tile_flip = slides.TileFlip.FLIP_Y

    presentation.save("TileBackground.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}

Lea más: [**Imagen en mosaico como textura**](/slides/es/python-net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Cambiar la transparencia de la imagen de fondo**

Puede que desee ajustar la transparencia de la imagen de fondo de una diapositiva para que el contenido de la misma destaque. El siguiente código Python le muestra cómo cambiar la transparencia de una imagen de fondo de diapositiva:

```python
transparency_value = 30  # For example.

# Get the collection of picture transform operations.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Find an existing fixed-percentage transparency effect.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Set the new transparency value.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **Obtener el valor del fondo de la diapositiva**

Aspose.Slides proporciona la clase [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) para recuperar los valores de fondo efectivos de una diapositiva. Esta clase expone el [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) y [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) efectivos.

Usando la propiedad `background` de la clase [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/), puede obtener el fondo efectivo de una diapositiva.

El siguiente ejemplo en Python muestra cómo obtener el valor del fondo efectivo de una diapositiva:

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Retrieve the effective background, taking into account master, layout, and theme.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **Preguntas frecuentes**

**¿Puedo restablecer un fondo personalizado y restaurar el fondo del tema/disposición?**

Sí. Elimine el relleno personalizado de la diapositiva y el fondo volverá a heredarse del correspondiente [layout](/slides/es/python-net/slide-layout/)/[master](/slides/es/python-net/slide-master/) (es decir, del [fondo del tema](/slides/es/python-net/presentation-theme/)).

**¿Qué ocurre con el fondo si cambio el tema de la presentación más adelante?**

Si una diapositiva tiene su propio relleno, permanecerá sin cambios. Si el fondo se hereda del [layout](/slides/es/python-net/slide-layout/)/[master](/slides/es/python-net/slide-master/), se actualizará para coincidir con el [nuevo tema](/slides/es/python-net/presentation-theme/).