---
title: Administrar fondos de presentación en Python
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

Los colores sólidos, los degradados y las imágenes se utilizan comúnmente como fondos de diapositiva. Puede establecer el fondo para una **diapositiva normal** (una sola diapositiva) o una **diapositiva maestra** (se aplica a varias diapositivas a la vez).

![PowerPoint background](powerpoint-background.png)

## **Establecer un fondo de color sólido para una diapositiva normal**

Aspose.Slides le permite establecer un color sólido como fondo para una diapositiva específica en una presentación—incluso si la presentación usa una diapositiva maestra. El cambio se aplica solo a la diapositiva seleccionada.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Establecer el [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) de la diapositiva a `OWN_BACKGROUND`.
3. Establecer el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) del fondo de la diapositiva a `SOLID`.
4. Utilizar la propiedad `solid_fill_color` en [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) para especificar el color de fondo sólido.
5. Guardar la presentación modificada.

El siguiente ejemplo en Python muestra cómo establecer un color sólido azul como fondo para una diapositiva normal:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crear una instancia de la clase Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Establecer el color de fondo de la diapositiva a azul.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.blue

    # Guardar la presentación en disco.
    presentation.save("SolidColorBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer un fondo de color sólido para la diapositiva maestra**

Aspose.Slides le permite establecer un color sólido como fondo para la diapositiva maestra en una presentación. La diapositiva maestra actúa como una plantilla que controla el formato de todas las diapositivas, por lo que al elegir un color sólido para el fondo de la diapositiva maestra, se aplicará a cada diapositiva.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Establecer el [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) de la diapositiva maestra (a través de `masters`) a `OWN_BACKGROUND`.
3. Establecer el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) del fondo de la diapositiva maestra a `SOLID`.
4. Utilizar la propiedad `solid_fill_color` en [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) para especificar el color de fondo sólido.
5. Guardar la presentación modificada.

El siguiente ejemplo en Python muestra cómo establecer un color sólido (verde bosque) como fondo para una diapositiva maestra:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crear una instancia de la clase Presentation.
with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]

    # Establecer el color de fondo de la diapositiva maestra a verde bosque.
    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Guardar la presentación en disco.
    presentation.save("MasterSlideBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer un fondo degradado para una diapositiva**

Un degradado es un efecto gráfico creado por un cambio gradual de color. Cuando se utiliza como fondo de diapositiva, los degradados pueden hacer que las presentaciones se vean más artísticas y profesionales. Aspose.Slides permite establecer un color degradado como fondo para las diapositivas.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Establecer el [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) de la diapositiva a `OWN_BACKGROUND`.
3. Establecer el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) del fondo de la diapositiva a `GRADIENT`.
4. Utilizar la propiedad `gradient_format` en [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) para configurar los ajustes de degradado deseados.
5. Guardar la presentación modificada.

El siguiente ejemplo en Python muestra cómo establecer un color degradado como fondo para una diapositiva:

```python
import aspose.slides as slides

# Crear una instancia de la clase Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Aplicar un efecto de degradado al fondo.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.GRADIENT
    slide.background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Guardar la presentación en disco.
    presentation.save("GradientBackground.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer una imagen como fondo de diapositiva**

Además de los rellenos sólidos y degradados, Aspose.Slides permite usar imágenes como fondos de diapositiva.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Establecer el [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) de la diapositiva a `OWN_BACKGROUND`.
3. Establecer el [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) del fondo de la diapositiva a `PICTURE`.
4. Cargar la imagen que desea usar como fondo de la diapositiva.
5. Añadir la imagen a la colección de imágenes de la presentación.
6. Utilizar la propiedad `picture_fill_format` en [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) para asignar la imagen como fondo.
7. Guardar la presentación modificada.

El siguiente ejemplo en Python muestra cómo establecer una imagen como fondo para una diapositiva:

```python
import aspose.slides as slides

# Crear una instancia de la clase Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Establecer propiedades de la imagen de fondo.
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Cargar la imagen.
    with slides.Images.from_file("Tulips.jpg") as image:
        # Añadir la imagen a la colección de imágenes de la presentación.
        pp_image = presentation.images.add_image(image)

    slide.background.fill_format.picture_fill_format.picture.image = pp_image

    # Guardar la presentación en disco.
    presentation.save("ImageAsBackground.pptx", slides.export.SaveFormat.PPTX)
```

El siguiente fragmento de código muestra cómo establecer el tipo de relleno de fondo a una imagen en mosaico y modificar sus propiedades de mosaico:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

    first_slide = presentation.slides[0]

    background = first_slide.background

    background.type = slides.BackgroundType.OWN_BACKGROUND
    background.fill_format.fill_type = slides.FillType.PICTURE

    with slides.Images.from_file("image.png") as new_image:
        pp_image = presentation.images.add_image(new_image)

    # Establecer la imagen utilizada para el relleno de fondo.
    back_picture_fill_format = background.fill_format.picture_fill_format
    back_picture_fill_format.picture.image = pp_image

    # Establecer el modo de relleno de imagen a Mosaico y ajustar las propiedades del mosaico.
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
Leer más: [**Imagen de mosaico como textura**](/slides/es/python-net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Cambiar la transparencia de la imagen de fondo**

Puede que desee ajustar la transparencia de la imagen de fondo de una diapositiva para que el contenido de la misma destaque. El siguiente código en Python muestra cómo cambiar la transparencia de la imagen de fondo de una diapositiva:

```python
transparency_value = 30  # Por ejemplo.

# Obtener la colección de operaciones de transformación de imagen.
image_transform = slide.background.fill_format.picture_fill_format.picture.image_transform

transparency_operation = None

# Buscar un efecto de transparencia de porcentaje fijo existente.
for operation in image_transform:
    if type(operation) is slides.AlphaModulateFixed:
        transparency_operation = operation
        break

# Establecer el nuevo valor de transparencia.
if transparency_operation is None:
    image_transform.add_alpha_modulate_fixed_effect(100 - transparency_value)
else:
    transparency_operation.amount = 100 - transparency_value
```

## **Obtener el valor del fondo de la diapositiva**

Aspose.Slides proporciona la clase [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) para recuperar los valores efectivos del fondo de una diapositiva. Esta clase expone el [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) y el [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/effectformat/) efectivos.

Usando la propiedad `background` de la clase [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/), puede obtener el fondo efectivo de una diapositiva.

El siguiente ejemplo en Python muestra cómo obtener el valor efectivo del fondo de una diapositiva:

```python
import aspose.slides as slides

# Crear una instancia de la clase Presentation.
with slides.Presentation("Sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Obtener el fondo efectivo, teniendo en cuenta la maestra, el diseño y el tema.
    effective_background = slide.background.get_effective()

    if effective_background.fill_format.fill_type == slides.FillType.SOLID:
        color = effective_background.fill_format.solid_fill_color
        print(f"Fill color: Color [A={color.a}, R={color.r}, G={color.g}, B={color.b}]")
    else:
        print("Fill type:", str(effective_background.fill_format.fill_type))
```

## **FAQ**

**¿Puedo restablecer un fondo personalizado y volver al fondo del tema/diseño?**

Sí. Elimine el relleno personalizado de la diapositiva y el fondo se heredará nuevamente del [diseño](/slides/es/python-net/slide-layout/)/[maestra](/slides/es/python-net/slide-master/) correspondiente (es decir, del [fondo del tema](/slides/es/python-net/presentation-theme/)).

**¿Qué ocurre con el fondo si cambio el tema de la presentación más adelante?**

Si una diapositiva tiene su propio relleno, permanecerá sin cambios. Si el fondo se hereda del [diseño](/slides/es/python-net/slide-layout/)/[maestra](/slides/es/python-net/slide-master/), se actualizará para coincidir con el [nuevo tema](/slides/es/python-net/presentation-theme/).