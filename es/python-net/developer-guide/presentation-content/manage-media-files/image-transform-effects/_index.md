---
title: Gestionar los efectos de transformación de imagen en presentaciones con Python
linktitle: Efectos de Transformación de Imagen
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
- reemplazo de color
- desenfoque
- transparencia
- efecto alfa
- cadena de efectos
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aplicar, encadenar, inspeccionar, eliminar y verificar los efectos de transformación de imagen para marcos de imagen con Aspose.Slides para Python via .NET."
---
## **Visión general**

Aspose.Slides representa los ajustes de imagen como una colección ordenada de operaciones de transformación de imágenes. Para un marco de imagen, comience con el [Picture](https://reference.aspose.com/slides/es/python-net/aspose.slides/picture/) del marco y acceda a su propiedad [image_transform](https://reference.aspose.com/slides/es/python-net/aspose.slides/picture/image_transform/). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/effects/imagetransformoperationcollection/) devuelta le permite añadir, enumerar, inspeccionar, eliminar y borrar efectos sin volver a escribir los bytes originales de la imagen.

Este artículo muestra un flujo de trabajo completo para brillo y contraste, transformaciones de color, desenfoque, transparencia, cadenas de efectos ordenadas, valores efectivos, eliminación y verificación de ida y vuelta de PPTX.

## **Comprender la propiedad de los efectos y la reutilización de imágenes**

Un recurso de imagen y la imagen que la muestra son objetos diferentes:

- [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) almacena o hace referencia a los datos de imagen origen propiedad de la presentación.
- [Picture](https://reference.aspose.com/slides/es/python-net/aspose.slides/picture/) pertenece a un relleno de imagen y hace referencia a un recurso de imagen mientras almacena la colección de transformaciones de imagen.
- [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) es la forma de diapositiva que posee el relleno de imagen correspondiente, la geometría, la configuración de recorte y otro formato a nivel de marco.

Por lo tanto, las operaciones de transformación de imágenes no modifican los bytes en [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/). Cuando el mismo `PPImage` se pasa a [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/es/python-net/aspose.slides/shapecollection/add_picture_frame/) más de una vez, cada nuevo marco de imagen recibe su propio `Picture` y su propia colección de transformaciones. Aplicar escala de grises a un marco no hace que los demás marcos tengan escala de grises, aunque todos reutilicen el mismo recurso de imagen incrustado.

El mismo modelo `Picture.image_transform` también se usa en otros rellenos de imagen, como una forma o el fondo de una diapositiva. Los ejemplos a continuación se centran en los marcos de imagen.

## **Utilizar rangos y unidades de parámetro válidos**

Los métodos demostrados usan los siguientes rangos semánticos y unidades. Mantenga los valores dentro de estos rangos incluso si una versión concreta de la biblioteca no rechaza inmediatamente cada valor fuera de rango; el formato de presentación de destino puede normalizar, omitir o rechazar datos inválidos durante el guardado o cuando PowerPoint abre el archivo.

| Operación | Parámetros | Rango y unidad válidos |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` a `100`, porcentaje; `0` deja el componente sin cambios. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | Ninguno | Ningún parámetro numérico. Alfa permanece sin cambios. |
| [add_duotone_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Dos colores para píxeles oscuros y claros. Los canales RGB y alfa usan valores de `0` a `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | El tono es de `0` inclusive a `360` exclusivo, en grados; la cantidad es de `-100` a `100`, porcentaje. |
| [add_hsl_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | El tono es de `0` inclusive a `360` exclusivo, en grados; la saturación y la luminancia son de `-100` a `100`, porcentaje. |
| [add_color_replace_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | El color de reemplazo usa valores de canal de `0` a `255`. Los valores alfa existentes permanecen sin cambios. |
| [add_blur_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | El radio es no negativo y se mide en puntos; `grow` es un Boolean que controla si el contenido desenfocado puede extenderse fuera de los límites originales. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Porcentaje no negativo. Use `0` a `100` para escalar la opacidad habitual: `0` es completamente transparente y `100` conserva el alfa existente. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` a `100`, porcentaje de opacidad. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` a `100`, umbral de alfa en porcentaje. Los valores por debajo se vuelven transparentes; los valores en o por encima se vuelven opacos. |

Para la modulación alfa fija, la transparencia y la opacidad son complementarias. Por ejemplo, un 35 % de transparencia corresponde a una cantidad de modulación alfa del 65 %.

## **Aplicar brillo y contraste**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) devuelve una operación [BrightnessContrast](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/brightnesscontrast/). Sus ajustes escalares se proporcionan cuando se crea la operación. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) devuelve valores calculados de solo lectura que pueden inspeccionarse o registrarse.

El siguiente ejemplo incrementa el brillo en un 15 % y el contraste en un 20 %, luego genera una vista previa sin modificar la imagen incrustada:

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

[BrightnessContrast](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/brightnesscontrast/) es una extensión de efecto de imagen de Office 2010 y es menos portátil que el efecto de luminancia estándar de DrawingML. Cuando el brillo y el contraste deben permanecer editables después de un viaje de ida y vuelta en PPTX, use [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) y verifique el resultado tras volver a abrir el archivo. La sección de limitaciones de formato explica esta distinción con más detalle.

## **Aplicar transformaciones de color**

Los efectos de color pueden aplicarse de forma independiente a diferentes marcos de imagen que reutilizan un recurso de imagen. El siguiente ejemplo crea cinco marcos y aplica escala de grises, duotono, tono, ajuste HSL y reemplazo de color.

[Duotone](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/duotone/) contiene dos parámetros de color editables de forma independiente: `color1` asigna los píxeles oscuros, mientras que `color2` asigna los píxeles claros. Esto lo convierte en un ejemplo útil de un efecto cuyas configuraciones son más complejas que un solo valor escalar.

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

[add_color_replace_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) sustituye el color de cada píxel por un color fijo mientras conserva el alfa. Es diferente de [add_color_change_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), que asigna un color de origen a otro y expone los formatos de color tanto de origen como de destino.

## **Añadir desenfoque, transparencia y efectos alfa**

[add_blur_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) afecta a todos los canales de color, incluido el alfa. Establezca `grow` a `True` cuando el borde desenfocado pueda extenderse más allá de los límites originales de la imagen.

Para una transparencia uniforme, use [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Multiplica cada valor alfa existente, de modo que los píxeles parcialmente transparentes siguen siendo proporcionalmente diferentes. [add_alpha_replace_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) en cambio asigna un único valor alfa a todos los píxeles. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) convierte el alfa a dos niveles basados en un umbral.

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

Otras operaciones alfa sin parámetros incluyen [add_alpha_ceiling_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), que hace que todo alfa distinto de cero sea completamente opaco; [add_alpha_floor_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), que hace que todo alfa por debajo del 100 % sea totalmente transparente; y [add_alpha_inverse_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), que cambia el alfa a `100% - alpha`.

## **Construir una cadena de efectos ordenada**

Cada método `add_..._effect` añade una nueva operación al final de la colección. El renderizador usa la colección como una tubería ordenada: la salida de la operación 0 se convierte en la entrada de la operación 1, y así sucesivamente. En consecuencia, las mismas operaciones en un orden diferente pueden producir una imagen distinta.

Por ejemplo, aplicar escala de grises seguida de tono elimina primero la información cromática y luego recolorea el resultado de luminancia. Aplicar tono seguido de escala de grises elimina el tono nuevamente. De forma similar, el reemplazo alfa puede sobrescribir los valores alfa calculados por operaciones anteriores, mientras que la modulación alfa conserva sus diferencias relativas.

El siguiente ejemplo construye una cadena de cuatro operaciones, la guarda como PPTX, vuelve a abrir la presentación, verifica tanto los tipos de operación como su orden, y renderiza el resultado reabierto:

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

La colección no impone una matriz de compatibilidad que restrinja las operaciones de color, alfa y desenfoque a cadenas separadas. Pueden combinarse, pero las combinaciones no siempre son útiles. Un reemplazo de color fijo elimina la variación RGB producida por efectos de color anteriores; la escala de grises después del duotono elimina los dos colores seleccionados; y las operaciones alfa de techo, suelo, reemplazo o bi‑nivel pueden descartar el detalle alfa creado anteriormente. Construya la cadena según la secuencia de procesamiento de píxeles deseada en lugar de tratar sus elementos como indicadores de formato desordenados.

## **Inspeccionar valores editables y efectivos**

Una operación editable es el objeto almacenado en `Picture.image_transform`. Dependiendo del efecto, puede exponer miembros escribibles directamente. Por ejemplo, [Blur](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/blur/) expone las propiedades `radius` y `grow` escribibles, [AlphaModulateFixed](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/alphamodulatefixed/) expone la propiedad `amount` escribible, y [AlphaBiLevel](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/alphabilevel/) expone la propiedad `threshold` escribible. Los efectos de color como [Duotone](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/duotone/) exponen objetos mutables [ColorFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides/colorformat/).

Algunas operaciones, incluyendo [BrightnessContrast](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/tint/), y [AlphaReplace](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/alphareplace/), no exponen sus escalares de creación como propiedades escribibles. Para cambiar esas configuraciones, elimine la operación y añada una de sustitución en la posición requerida.

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

Los efectos sin parámetros como escala de grises, techo alfa e inverso alfa aún tienen un objeto de datos efectivo, pero no hay ajustes escalares que imprimir. Su presencia y posición en la colección son la información importante.

## **Eliminar o borrar transformaciones de imagen**

Use [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) para eliminar una operación por índice. Debido a que los índices cambian tras la eliminación, busque el objetivo primero y elimínelo después de la enumeración. Use `clear()` para eliminar toda la cadena.

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

Eliminar o borrar transformaciones solo cambia el formato de la imagen. No elimina, recomprime ni altera de otro modo el recurso [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) reutilizado.

## **Considerar formatos de presentación y objetivos de exportación**

Las transformaciones de imagen se originan en DrawingML, por lo que PPTX es el formato editable preferido para cadenas de efectos. Incluso con PPTX, no todas las operaciones tienen la misma portabilidad:

- Las operaciones estándar de DrawingML como luminancia, escala de grises, duotono, tono, HSL, desenfoque y operaciones alfa comunes tienen la mayor probabilidad de sobrevivir a un viaje de ida y vuelta de PPTX. Siempre vuelva a abrir el archivo generado e inspeccione la colección cuando la preservación sea un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/brightnesscontrast/) es una extensión de Office 2010 en lugar de la operación estándar de luminancia de DrawingML. Puede usarse para renderizado en memoria, pero no se garantiza que permanezca como una operación editable `BrightnessContrast` después de guardar y volver a abrir PPTX. Prefiera [add_luminance_effect](https://reference.aspose.com/slides/es/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) para ajustes persistentes de brillo y contraste.
- El formato binario PPT precede al modelo completo de efectos DrawingML. Guardar en PPT puede omitir operaciones no admitidas, reducir una cadena a un subconjunto soportado o aproximar la apariencia. No use PPT como formato de verificación para una cadena editable compleja.
- Renderizar a PNG, JPEG, TIFF, PDF, SVG, HTML u otro salida visual aplica la cadena admitida a la apariencia renderizada. esas salidas no contienen una `ImageTransformOperationCollection` editable; los formatos rasterizados aplanan el resultado en píxeles, y las exportaciones de documento o vectoriales almacenan su propia representación de renderizado.
- Los efectos no hacen que una imagen vinculada sea autónoma. Renderizar una imagen vinculada sigue dependiendo de que el recurso vinculado esté disponible cuando se cargue la presentación.

Diferentes consumidores de presentaciones pueden renderizar casos límite de forma distinta, especialmente cuando se combinan varias operaciones alfa o de cuantización de color. Para salidas críticas, pruebe tanto el viaje de ida y vuelta editable como el formato de exportación final con la misma versión de Aspose.Slides utilizada en producción.

## **Preguntas frecuentes**

**¿Los efectos de transformación de imagen modifican los datos de la imagen incrustada?**

No. Las operaciones pertenecen al `Picture` usado por el relleno de imagen. Los bytes subyacentes de `PPImage` permanecen sin cambios.

**¿Dos marcos de imagen que reutilizan la misma imagen compartirán sus efectos?**

No. Reutilizar un `PPImage` evita datos de imagen duplicados, pero cada marco de imagen normalmente tiene un `Picture` y una colección de transformaciones de imagen separados.

**¿Se pueden combinar efectos de color, desenfoque y alfa?**

Sí. La colección los acepta en una única cadena ordenada. Considere lo que cada operación hace a la salida de la anterior, ya que las operaciones de sustitución y umbral pueden descartar detalles de color o alfa anteriores.

**¿Por qué los valores efectivos son de solo lectura?**

Los datos efectivos representan valores calculados utilizados para el renderizado, incluidos los colores resueltos. Edite la operación almacenada en la colección de transformaciones donde existan miembros escribibles; de lo contrario, elimínela y añada una de sustitución con nuevos parámetros de creación.

**¿Qué formato debo usar para preservar una cadena de transformaciones?**

Utilice PPTX y verifique el archivo volviéndolo a abrir. El PPT heredado no puede representar el modelo completo de efectos DrawingML, y los formatos de exportación renderizados preservan la apariencia en lugar de las operaciones de transformación editables.