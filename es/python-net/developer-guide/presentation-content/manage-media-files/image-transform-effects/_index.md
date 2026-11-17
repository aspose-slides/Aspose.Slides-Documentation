---
title: Gestionar efectos de transformación de imagen en presentaciones con Python
linktitle: Efectos de transformación de imagen
type: docs
weight: 11
url: /es/python-net/image-transform-effects/
keywords:
- transformación de imagen
- efecto de imagen
- brillo
- contraste
- escala de grises
- duotono
- tinte
- HSL
- sustitución de color
- desenfoque
- transparencia
- efecto alfa
- cadena de efectos
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aplicar, encadenar, inspeccionar, eliminar y verificar efectos de transformación de imagen para marcos de imagen con Aspose.Slides para Python vía .NET."
---
## **Descripción general**

Aspose.Slides representa los ajustes de imágenes como una colección ordenada de operaciones de transformación de imágenes. Para un marco de imagen, comience con el [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) del marco y acceda a su propiedad [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) devuelta le permite añadir, enumerar, inspeccionar, eliminar y borrar efectos sin reescribir los bytes originales de la imagen.

Este artículo muestra un flujo de trabajo completo para brillo y contraste, transformaciones de color, desenfoque, transparencia, cadenas de efectos ordenadas, valores efectivos, eliminación y verificación de ida y vuelta de PPTX.

## **Comprender la propiedad de los efectos y la reutilización de imágenes**

Un recurso de imagen y la imagen que lo muestra son objetos diferentes:

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) almacena o hace referencia a los datos de la imagen fuente que pertenece a la presentación.
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) pertenece a un relleno de imagen y se refiere a un recurso de imagen mientras almacena la colección de transformaciones de la imagen.
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) es la forma de diapositiva que posee el relleno de imagen correspondiente, la geometría, la configuración de recorte y otro formato a nivel de marco.

Por lo tanto, las operaciones de transformación de imagen no modifican los bytes en [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/). Cuando el mismo `PPImage` se pasa a [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) más de una vez, cada nuevo marco de imagen recibe su propio `Picture` y su propia colección de transformaciones. Aplicar escala de grises a un marco no hace que los demás marcos tengan escala de grises, aunque todos reutilicen el mismo recurso de imagen incrustado.

El mismo modelo `Picture.image_transform` también lo usan otros rellenos de imagen, como el fondo de una forma o de una diapositiva. Los ejemplos a continuación se centran en los marcos de imagen.

## **Utilizar rangos y unidades de parámetros válidos**

Los métodos demostrados usan los siguientes rangos semánticos y unidades. Mantenga los valores dentro de estos rangos aunque una versión particular de la biblioteca no rechace inmediatamente cada valor fuera de rango; el formato de presentación de destino puede normalizar, omitir o rechazar datos no válidos durante el guardado o cuando PowerPoint abre el archivo.

| Operación | Parámetros | Rango válido y unidad |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` hasta `100`, por ciento; `0` deja el componente sin cambios. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | Sin parámetros numéricos. Alfa permanece sin cambios. |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Dos colores para píxeles oscuros y claros. Los canales RGB y alfa usan `0` hasta `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | Matiz es `0` inclusive hasta `360` exclusivo, en grados; la cantidad es `-100` hasta `100`, por ciento. |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | Matiz es `0` inclusive hasta `360` exclusivo, en grados; saturación y luminancia son `-100` hasta `100`, por ciento. |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | El color de sustitución usa valores de canal de `0` hasta `255`. Los valores alfa existentes permanecen sin cambios. |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | El radio es no negativo y se mide en puntos; `grow` es un Boolean que controla si el contenido borroso puede extenderse fuera de los límites originales. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Porcentaje no negativo. Use `0` hasta `100` para una escala de opacidad ordinaria: `0` es completamente transparente y `100` conserva el alfa existente. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` hasta `100`, por ciento de opacidad. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` hasta `100`, umbral alfa en por ciento. Los valores por debajo se vuelven transparentes; los valores iguales o superiores se vuelven opacos. |

Para la modulación alfa fija, la transparencia y la opacidad son complementarias. Por ejemplo, un 35 % de transparencia corresponde a una cantidad de modulación alfa del 65 %.

## **Aplicar brillo y contraste**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) devuelve una operación [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/). Sus ajustes escalares se proporcionan al crear la operación. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) devuelve valores calculados de solo lectura que pueden inspeccionarse o registrarse.

El siguiente ejemplo aumenta el brillo un 15 % y el contraste un 20 %, y luego renderiza una vista previa sin modificar la imagen incrustada:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) es una extensión de efecto de imagen de Office 2010 y es menos portátil que el efecto de luminancia estándar de DrawingML. Cuando el brillo y el contraste deben seguir siendo editables después de un viaje de ida y vuelta de PPTX, use [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) y verifique el resultado tras volver a abrir el archivo. La sección de limitaciones de formato explica esta distinción con mayor detalle.

## **Aplicar transformaciones de color**

Los efectos de color pueden aplicarse de forma independiente a diferentes marcos de imagen que reutilizan un recurso de imagen. El siguiente ejemplo crea cinco marcos y aplica escala de grises, duotono, tono, ajuste HSL y sustitución de color.

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) contiene dos parámetros de color editables de forma independiente: `color1` asigna los píxeles oscuros, mientras que `color2` asigna los píxeles claros. Esto lo convierte en un ejemplo útil de un efecto cuyas configuraciones son más complejas que un único valor escalar.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) sustituye el color de cada píxel por un color fijo mientras conserva alfa. Es diferente de [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), que asigna un color fuente a otro y expone ambos formatos de color fuente y destino.

### **Aplicar un umbral de luminancia**

Un umbral de luminancia puede facilitar la distinción de marcas tenues en una página escaneada respecto al fondo. [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) conserva los tonos intermedios de gris. [add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) asigna la luminancia a negro o blanco, mientras que [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) aplica un umbral a la opacidad.

El umbral de luminancia va del 0 % al 100 %, inclusive. Los píxeles por debajo del umbral se vuelven negros. Los píxeles iguales o superiores se vuelven blancos. Aumentar el umbral vuelve más tonos negros porque más de ellos quedan por debajo del corte.

Descargue [grayscale-swatches.png](grayscale-swatches.png) en el directorio de trabajo. Cada etiqueta indica el nivel de gris original en una escala de 0 a 255. El ejemplo coloca el original junto a dos copias y guarda el umbral de cada copia en la presentación.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 150, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    with slides.Images.from_file("grayscale-swatches.png") as source_image:
        image = presentation.images.add_image(source_image)

    def add_frame(x, caption):
        label = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 12, 216, 36)
        label.text_frame.text = caption
        return shapes.add_picture_frame(slides.ShapeType.RECTANGLE, x, 60, 216, 72, image)

    add_frame(12, "Original")

    low_threshold = add_frame(252, "Threshold 20%")
    low_threshold.picture_format.picture.image_transform.add_bi_level_effect(20)
    
    high_threshold = add_frame(492, "Threshold 60%")
    high_threshold.picture_format.picture.image_transform.add_bi_level_effect(60)

    presentation.save("luminance-threshold.pptx", slides.export.SaveFormat.PPTX)
```

Abra la presentación resultante en PowerPoint para comparar los tres marcos. La muestra etiquetada 96 tiene aproximadamente un 38 % de luminancia (96 de 255). Se vuelve blanca con el umbral del 20 % y negra con el umbral del 60 %.

![Muestras de escala de grises original junto a los resultados en blanco y negro con umbrales de luminancia del 20 % y 60 %](luminance-threshold.png)

## **Añadir desenfoque, transparencia y efectos alfa**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) afecta a todos los canales de color, incluido alfa. Establezca `grow` a `True` cuando el borde borroso pueda extenderse más allá de los límites originales de la imagen.

Para una transparencia uniforme, use [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Multiplica cada valor alfa existente, de modo que los píxeles parcialmente transparentes conservan sus diferencias proporcionales. [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) asigna en su lugar un único valor alfa a todos los píxeles. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) convierte alfa a dos niveles basados en un umbral.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

Otras operaciones alfa sin parámetros incluyen [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), que hace que cada alfa distinto de cero sea completamente opaco; [add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), que hace que cada alfa por debajo del 100 % sea completamente transparente; y [add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), que cambia alfa a `100% - alpha`.

## **Construir una cadena de efectos ordenada**

Cada método `add_..._effect` añade una nueva operación al final de la colección. El renderizador usa la colección como una canalización ordenada: la salida de la operación 0 se convierte en la entrada de la operación 1, y así sucesivamente. En consecuencia, las mismas operaciones en un orden diferente pueden producir una imagen distinta.

Por ejemplo, aplicar escala de grises seguido de tono elimina primero la información cromática y luego recolorea el resultado de luminancia. Aplicar tono seguido de escala de grises elimina nuevamente el tono. De manera similar, la sustitución alfa puede sobrescribir valores alfa calculados por operaciones anteriores, mientras que la modulación alfa conserva sus diferencias relativas.

El siguiente ejemplo construye una cadena de cuatro operaciones, la guarda como PPTX, vuelve a abrir la presentación, comprueba tanto los tipos de operación como su orden, y renderiza el resultado reabierto:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

La colección no impone una matriz de compatibilidad que restrinja las operaciones de color, alfa y desenfoque a cadenas separadas. Pueden combinarse, pero no siempre resultan útiles. Una sustitución de color fija elimina la variación RGB producida por efectos de color anteriores; la escala de grises después del duotono elimina los dos colores seleccionados; y las operaciones alfa de techo, piso, sustitución o bi‑nivel pueden descartar el detalle alfa creado antes. Construya la cadena según la secuencia de procesamiento de píxeles deseada en lugar de tratar sus elementos como indicadores de formato sin orden.

<!-- visual-explanation:image-transform-effects:start -->
[![La misma imagen pasa primero por escala de grises y luego por tono, y en el otro caso por tono y luego por escala de grises. Las dos imágenes finales en escala de grises tienen tonos diferentes.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*En esta ilustración de Aspose.Slides for .NET 26.11, un tono de 220° al 25 % deja la imagen en escala de grises sin cambios. Aplicar el mismo tono antes de la escala de grises produce tonos diferentes.*
<!-- visual-explanation:image-transform-effects:end -->

## **Inspeccionar valores editables y efectivos**

Una operación editable es el objeto almacenado en `Picture.image_transform`. Según el efecto, puede exponer miembros grabables directamente. Por ejemplo, [Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) expone propiedades grabables `radius` y `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) expone una propiedad grabable `amount`, y [AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) expone una propiedad grabable `threshold`. Los efectos de color como [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) exponen objetos [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/) mutables.

Algunas operaciones, incluidos [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/), y [AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/), no exponen sus escalares de creación como propiedades grabables. Para cambiar esas configuraciones, elimine la operación y añada una de reemplazo en la posición requerida.

Los datos efectivos devueltos por `get_effective()` se calculan y son de solo lectura. Son útiles para resolver colores dependientes del tema y leer los valores normalizados que usa el renderizador, pero no constituyen otra superficie de edición. El siguiente ejemplo enumera la cadena e inspecciona los valores efectivos donde la API correspondiente los proporciona:

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

Los efectos sin parámetros, como escala de grises, techo alfa e inverso alfa, también disponen de un objeto de datos efectivos, pero no hay configuraciones escalares que imprimir. Su presencia y posición en la colección son la información importante.

## **Eliminar o borrar transformaciones de imagen**

Use [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) para eliminar una operación por índice. Como los índices cambian después de una eliminación, busque el objetivo primero y elimínelo después de la enumeración. Use `clear()` para eliminar toda la cadena.

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

Eliminar o borrar transformaciones solo cambia el formato de la imagen. No elimina, recomprime ni altera de otro modo el recurso [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) reutilizado.

## **Considerar formatos de presentación y destinos de exportación**

Las transformaciones de imagen se originan en DrawingML, por lo que PPTX es el formato editable preferido para cadenas de efectos. Incluso con PPTX, no todas las operaciones tienen la misma portabilidad:

- Las operaciones estándar de DrawingML como luminancia, escala de grises, duotono, tono, HSL, desenfoque y operaciones alfa comunes tienen mayor probabilidad de sobrevivir a un viaje de ida y vuelta de PPTX. Siempre vuelva a abrir el archivo generado e inspeccione la colección cuando la preservación sea un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) es una extensión de Office 2010 más que la operación estándar de luminancia de DrawingML. Puede usarse para renderizado en memoria, pero no hay garantía de que permanezca como una operación editable `BrightnessContrast` tras guardar y volver a abrir PPTX. Prefiera [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) para ajustes persistentes de brillo y contraste.
- El formato binario PPT es anterior al modelo completo de efectos DrawingML. Guardar en PPT puede omitir operaciones no admitidas, reducir una cadena a un subconjunto soportado o aproximar la apariencia. No use PPT como formato de verificación para una cadena editable compleja.
- Renderizar a PNG, JPEG, TIFF, PDF, SVG, HTML u otro salida visual aplica la cadena admitida a la apariencia renderizada. esas salidas no contienen una `ImageTransformOperationCollection` editable; los formatos raster aplanan el resultado en píxeles, y las exportaciones de documento o vector almacenan su propia representación de renderizado.
- Los efectos no hacen que una imagen vinculada sea autosuficiente. Renderizar una imagen vinculada sigue dependiendo de que el recurso vinculado esté disponible cuando se cargue la presentación.

Diferentes consumidores de presentaciones pueden renderizar casos límite de forma distinta, sobre todo cuando se combinan varias operaciones alfa o de cuantización de color. Para resultados críticos, pruebe tanto el viaje de ida y vuelta editable como el formato de exportación final con la misma versión de Aspose.Slides usada en producción.

## **Preguntas frecuentes**

**¿Los efectos de transformación de imagen modifican los datos de la imagen incrustada?**

No. Las operaciones pertenecen al `Picture` utilizado por el relleno de imagen. Los bytes subyacentes de `PPImage` permanecen sin cambios.

**¿Dos marcos de imagen que reutilizan la misma imagen compartirán sus efectos?**

No. Reutilizar un `PPImage` evita datos de imagen duplicados, pero cada marco de imagen normalmente tiene un `Picture` y una colección de transformaciones de imagen separados.

**¿Se pueden combinar efectos de color, desenfoque y alfa?**

Sí. La colección los acepta en una única cadena ordenada. Considere lo que cada operación hace a la salida de la anterior, ya que las operaciones de sustitución y umbral pueden descartar detalles de color o alfa anteriores.

**¿Por qué los valores efectivos son de solo lectura?**

Los datos efectivos representan valores calculados utilizados para renderizar, incluidos los colores resueltos. Edite la operación almacenada en la colección de transformaciones donde existan miembros grabables; de lo contrario, elimínela y añada una de reemplazo con nuevos parámetros de creación.

**¿Qué formato debo usar para preservar una cadena de transformaciones?**

Use PPTX y verifique el archivo volviéndolo a abrir. PPT heredado no puede representar el modelo completo de efectos DrawingML, y los formatos de exportación renderizados conservan la apariencia más que las operaciones de transformación editables.