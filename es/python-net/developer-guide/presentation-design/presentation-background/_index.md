---
title: Fondo de Presentación
type: docs
weight: 20
url: /python-net/presentation-background/
keywords: "fondo de PowerPoint, establecer fondo, Python, Aspose.Slides para Python a través de .NET"
description: "Establecer fondo en presentación de PowerPoint en Python"
---

Los colores sólidos, colores degradados e imágenes se utilizan a menudo como imágenes de fondo para las diapositivas. Puedes establecer el fondo tanto para una **diapositiva normal** (diapositiva única) como para una **diapositiva maestra** (varias diapositivas a la vez).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Establecer Color Sólido como Fondo para Diapositiva Normal**

Aspose.Slides te permite establecer un color sólido como fondo para una diapositiva específica en una presentación (incluso si esa presentación contiene una diapositiva maestra). El cambio de fondo afecta solo a la diapositiva seleccionada.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) para la diapositiva en `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) para el fondo de la diapositiva en `Solid`.
4. Utiliza la propiedad [SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) expuesta por [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) para especificar un color sólido para el fondo.
5. Guarda la presentación modificada.

Este código en Python te muestra cómo establecer un color sólido (azul) como fondo para una diapositiva normal:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crea una instancia de la clase Presentation
with slides.Presentation() as pres:
    # Establece el color de fondo para la primera ISlide en azul
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.slides[0].background.fill_format.solid_fill_color.color = draw.Color.blue
    # Escribe la presentación en disco
    pres.save("ContentBG_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Color Sólido como Fondo para Diapositiva Maestra**

Aspose.Slides te permite establecer un color sólido como fondo para la diapositiva maestra en una presentación. La diapositiva maestra actúa como una plantilla que contiene y controla las configuraciones de formato para todas las diapositivas. Por lo tanto, cuando seleccionas un color sólido como el fondo para la diapositiva maestra, ese nuevo fondo se utilizará para todas las diapositivas.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) para la diapositiva maestra (`Masters`) en `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) para el fondo de la diapositiva maestra en `Solid`.
4. Utiliza la propiedad [SolidFillColor](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) expuesta por [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) para especificar un color sólido para el fondo.
5. Guarda la presentación modificada.

Este código en Python te muestra cómo establecer un color sólido (verde bosque) como fondo para una diapositiva maestra en una presentación:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crea una instancia de la clase Presentation
with slides.Presentation() as pres:
    # Establece el color de fondo para la Master ISlide en Verde Bosque
    pres.masters[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.masters[0].background.fill_format.fill_type = slides.FillType.SOLID
    pres.masters[0].background.fill_format.solid_fill_color.color = draw.Color.forest_green

    # Escribe la presentación en disco
    pres.save("SetSlideBackgroundMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Color Degradado como Fondo para Diapositiva**

Un degradado es un efecto gráfico basado en un cambio gradual de color. Los colores degradados, cuando se utilizan como fondos para diapositivas, hacen que las presentaciones se vean artísticas y profesionales. Aspose.Slides te permite establecer un color degradado como fondo para las diapositivas en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) para la diapositiva en `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) para el fondo de la diapositiva maestra en `Gradient`.
4. Utiliza la propiedad [GradientFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) expuesta por [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) para especificar tu configuración de degradado preferida.
5. Guarda la presentación modificada.

Este código en Python te muestra cómo establecer un color degradado como fondo para una diapositiva:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crea una instancia de la clase Presentation
with slides.Presentation(path + "SetBackgroundToGradient.pptx") as pres:
    # Aplica el efecto de degradado al fondo
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.GRADIENT
    pres.slides[0].background.fill_format.gradient_format.tile_flip = slides.TileFlip.FLIP_BOTH

    # Escribe la presentación en disco
    pres.save("ContentBG_Grad_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Imagen como Fondo para Diapositiva**

Además de colores sólidos y colores degradados, Aspose.Slides también te permite establecer imágenes como fondo para las diapositivas en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/python-net/aspose.slides/backgroundtype/) para la diapositiva en `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) para el fondo de la diapositiva maestra en `Picture`.
4. Carga la imagen que deseas usar como fondo de la diapositiva.
5. Agrega la imagen a la colección de imágenes de la presentación.
6. Utiliza la propiedad [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/#properties) expuesta por [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/) para establecer la imagen como fondo.
7. Guarda la presentación modificada.

Este código en Python te muestra cómo establecer una imagen como fondo para una diapositiva:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crea una instancia de la clase Presentation
with slides.Presentation(path + "SetImageAsBackground.pptx") as pres:
    # Establece condiciones para la imagen de fondo
    pres.slides[0].background.type = slides.BackgroundType.OWN_BACKGROUND
    pres.slides[0].background.fill_format.fill_type = slides.FillType.PICTURE
    pres.slides[0].background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

    # Carga la imagen
    img = draw.Bitmap(path + "Tulips.jpg")

    # Agrega la imagen a la colección de imágenes de la presentación
    imgx = pres.images.add_image(img)

    pres.slides[0].background.fill_format.picture_fill_format.picture.image = imgx

    # Escribe la presentación en disco
    pres.save("ContentBG_Img_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Cambiar Transparencia de la Imagen de Fondo**

Puede que quieras ajustar la transparencia de la imagen de fondo de una diapositiva para que los contenidos de la diapositiva se destaquen. Este código en Python te muestra cómo cambiar la transparencia para una imagen de fondo de diapositiva:

```python
transparencyValue = 30 # por ejemplo

# Obtiene una colección de operaciones de transformación de imagen
imageTransform = pres.slides[0].background.fill_format.picture_fill_format.picture.image_transform

transparencyOperation = None
# Busca un efecto de transparencia con porcentaje fijo.
for operation in imageTransform:
    if type(operation) is slides.AlphaModulateFixed:
        transparencyOperation = operation
        break

# Establece el nuevo valor de transparencia.
if transparencyOperation is None:
    imageTransform.add_alpha_modulate_fixed_effect(100 - transparencyValue)
else:
    transparencyOperation.amount = (100 - transparencyValue)
```

## **Obtener Valor del Fondo de Diapositiva**

Aspose.Slides proporciona la interfaz [IBackgroundEffectiveData](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/) para permitirte obtener los valores efectivos de los fondos de las diapositivas. Esta interfaz contiene información sobre el [FillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties) efectivo y el [EffectFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ibackgroundeffectivedata/#properties) efectivo.

Utilizando la propiedad [Background](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/#properties) de la clase [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/), puedes obtener el valor efectivo para el fondo de una diapositiva.

Este código en Python te muestra cómo obtener el valor efectivo del fondo de una diapositiva:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Crea una instancia de la clase Presentation
with slides.Presentation(path + "SamplePresentation.pptx") as pres:

    effBackground = pres.slides[0].background.get_effective()

    if effBackground.fill_format.fill_type == slides.FillType.SOLID:
        print("Color de relleno: " + str(effBackground.fill_format.solid_fill_color))
    else:
        print("Tipo de relleno: " + str(effBackground.fill_format.fill_type))
```