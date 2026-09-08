---
title: Gestionar efectos de transformación de imagen en presentaciones con Python
linktitle: Efectos de Transformación de Imagen
type: docs
weight: 11
url: /es/python-java/image-transform-effects/
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
- Java
- Aspose.Slides
description: "Aplicar, encadenar, inspeccionar, eliminar y verificar los efectos de transformación de imagen para marcos de imagen con Aspose.Slides para Python a través de Java."
---
## **Visión general**

Aspose.Slides representa los ajustes de imagen como una colección ordenada de operaciones de transformación de imagen. Para un marco de imagen, comience con el [Picture](https://reference.aspose.com/slides/es/python-java/aspose.slides/picture/) del marco y acceda a [Picture.getImageTransform](https://reference.aspose.com/slides/es/python-java/aspose.slides/picture/#getImageTransform). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/) devuelta le permite añadir, enumerar, inspeccionar, eliminar y limpiar efectos sin reescribir los bytes originales de la imagen.

Este artículo muestra un flujo de trabajo completo para brillo y contraste, transformaciones de color, desenfoque, transparencia, cadenas de efectos ordenadas, valores efectivos, eliminación y verificación de ida y vuelta de PPTX.

## **Comprender la propiedad de los efectos y la reutilización de imágenes**

Un recurso de imagen y la imagen que la muestra son objetos diferentes:

- [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) almacena o hace referencia a los datos de imagen fuente que pertenecen a la presentación.
- [Picture](https://reference.aspose.com/slides/es/python-java/aspose.slides/picture/) pertenece a un relleno de imagen y se refiere a un recurso de imagen mientras almacena la colección de transformaciones de imagen.
- [PictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/pictureframe/) es la forma de diapositiva que posee el relleno de imagen pertinente, la geometría, la configuración de recorte y demás formato a nivel de marco.

Por lo tanto, las operaciones de transformación de imagen no modifican los bytes en [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/). Cuando el mismo `PPImage` se pasa a [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/es/python-java/aspose.slides/shapecollection/#addPictureFrame) más de una vez, cada nuevo marco de imagen recibe su propio `Picture` y su propia colección de transformaciones. Aplicar escala de grises a un marco no hace que los demás marcos queden en escala de grises, aunque todos reutilicen el mismo recurso de imagen incrustado.

El mismo modelo `Picture.getImageTransform` también lo emplean otros rellenos de imagen, como el fondo de una forma o de una diapositiva. Los ejemplos siguientes se centran en marcos de imagen.

## **Utilizar rangos y unidades de parámetro válidos**

Los métodos demostrados usan los siguientes rangos semánticos y unidades. Mantenga los valores dentro de esos rangos aunque una versión concreta de la biblioteca no rechace inmediatamente cada valor fuera de rango; el formato de presentación de destino puede normalizar, omitir o rechazar datos no válidos al guardar o cuando PowerPoint abre el archivo.

| Operación | Parámetros | Rango válido y unidad |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | de `-100` a `100`, por ciento; `0` deja el componente sin cambios. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | Ninguno | Sin parámetros numéricos. El alfa permanece sin cambios. |
| [addDuotoneEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Dos colores para píxeles oscuros y claros. Los canales RGB y alfa en `java.awt.Color` usan valores de `0` a `255`. |
| [addTintEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | `hue` de `0` (inclusive) a `360` (exclusive), en grados; `amount` de `-100` a `100`, por ciento. |
| [addHSLEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | `hue` de `0` (inclusive) a `360` (exclusive), en grados; `saturation` y `luminance` de `-100` a `100`, por ciento. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | El color de reemplazo usa valores de canal de `0` a `255`. Los valores alfa existentes no se modifican. |
| [addBlurEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | `radius` es no negativo y se mide en puntos; `grow` es un Boolean que controla si el contenido desenfocado puede extenderse fuera de los límites originales. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | Porcentaje no negativo. Use `0` a `100` para escalar la opacidad ordinaria: `0` es totalmente transparente y `100` conserva el alfa existente. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | De `0` a `100`, por ciento de opacidad. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | De `0` a `100`, por ciento de umbral alfa. Los valores por debajo se vuelven transparentes; los valores en o sobre el umbral se vuelven opacos. |

Para la modulación alfa fija, la transparencia y la opacidad son complementarias. Por ejemplo, un 35 % de transparencia corresponde a una cantidad de modulación alfa del 65 %.

## **Aplicar brillo y contraste**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) devuelve una operación [BrightnessContrast](https://reference.aspose.com/slides/es/python-java/aspose.slides/brightnesscontrast/). Sus ajustes escalares se proporcionan cuando se crea la operación. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/es/python-java/aspose.slides/brightnesscontrast/#getEffective) devuelve valores de solo lectura calculados que pueden inspeccionarse o registrarse.

El siguiente ejemplo incrementa el brillo en un 15 % y el contraste en un 20 %, luego genera una vista previa sin modificar la imagen incrustada:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/es/python-java/aspose.slides/brightnesscontrast/) es una extensión de efecto de imagen de Office 2010 y es menos portátil que el efecto estándar de luminancia DrawingML. Cuando el brillo y el contraste deben seguir siendo editables después de una ida y vuelta de PPTX, utilice [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) y verifique el resultado después de volver a abrir el archivo. La sección de limitaciones de formato explica esta distinción con más detalle.

## **Aplicar transformaciones de color**

Los efectos de color pueden aplicarse de forma independiente a diferentes marcos de imagen que reutilizan un mismo recurso de imagen. El siguiente ejemplo crea cinco marcos y aplica escala de grises, duotono, tinte, ajuste HSL y sustitución de color.

[Duotone](https://reference.aspose.com/slides/es/python-java/aspose.slides/duotone/) contiene dos parámetros de color editables de forma independiente: `color1` asigna los píxeles oscuros, mientras que `color2` asigna los píxeles claros. Esto lo convierte en un ejemplo útil de un efecto cuyas configuraciones son más complejas que un único valor escalar.

```python
import jpile
import asposeslides
from pathlib import Path

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpile.JArray(jpile.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) sustituye el color de cada píxel por un color fijo manteniendo el alfa. Es diferente de [addColorChangeEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), que asigna un color de origen a otro y expone ambos formatos de color origen y destino.

## **Añadir desenfoque, transparencia y efectos alfa**

[addBlurEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) afecta a todos los canales de color, incluido el alfa. Establezca `grow` a `True` cuando el borde desenfocado pueda extenderse más allá de los límites originales de la imagen.

Para una transparencia uniforme, use [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Multiplica cada valor alfa existente, de modo que los píxeles parcialmente transparentes siguen siendo proporcionalmente diferentes. [addAlphaReplaceEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) en su lugar asigna un único valor alfa a todos los píxeles. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) convierte el alfa a dos niveles basándose en un umbral.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Otras operaciones alfa sin parámetros incluyen [addAlphaCeilingEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), que hace que cualquier alfa distinto de cero sea totalmente opaco; [addAlphaFloorEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), que hace que cualquier alfa inferior al 100 % sea totalmente transparente; y [addAlphaInverseEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), que cambia el alfa a `100% - alfa`.

## **Construir una cadena de efectos ordenada**

Cada método `add...Effect` añade una nueva operación al final de la colección. El renderizador utiliza la colección como una tubería ordenada: la salida de la operación 0 pasa a ser la entrada de la operación 1, y así sucesivamente. En consecuencia, las mismas operaciones en distinto orden pueden producir una imagen diferente.

Por ejemplo, escala de grises seguida de tinte primero elimina la información cromática y luego recolorea el resultado de luminancia. Tinte seguido de escala de grises elimina el tinte de nuevo. De forma similar, la sustitución alfa puede sobrescribir los valores alfa calculados por operaciones anteriores, mientras que la modulación alfa conserva sus diferencias relativas.

El siguiente ejemplo construye una cadena de cuatro operaciones, la guarda como PPTX, vuelve a abrir la presentación, comprueba tanto los tipos de operación como su orden, y renderiza el resultado reabierto:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

La colección no impone una matriz de compatibilidad que restrinja operaciones de color, alfa y desenfoque a cadenas separadas. Pueden combinarse, pero las combinaciones no siempre son útiles. Una sustitución de color fija elimina la variación RGB producida por efectos de color anteriores; la escala de grises después de duotono elimina los dos colores seleccionados; y las operaciones alfa de techo, suelo, sustitución o bi‑nivel pueden descartar detalle alfa creado antes. Construya la cadena según la secuencia de procesamiento de píxeles deseada en lugar de tratar sus elementos como indicadores de formato sin orden.

## **Inspeccionar valores editables y efectivos**

Una operación editable es el objeto almacenado en `Picture.getImageTransform`. Según el efecto, puede exponer miembros escribibles directamente. Por ejemplo, [Blur](https://reference.aspose.com/slides/es/python-java/aspose.slides/blur/) expone valores escribibles `radius` y `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/es/python-java/aspose.slides/alphamodulatefixed/) expone un `amount` escribible, y [AlphaBiLevel](https://reference.aspose.com/slides/es/python-java/aspose.slides/alphabilevel/) expone un `threshold` escribible. Los efectos de color como [Duotone](https://reference.aspose.com/slides/es/python-java/aspose.slides/duotone/) exponen objetos mutables [ColorFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/colorformat/).

Algunas clases de operación, incluidos [BrightnessContrast](https://reference.aspose.com/slides/es/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/es/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/es/python-java/aspose.slides/tint/) y [AlphaReplace](https://reference.aspose.com/slides/es/python-java/aspose.slides/alphareplace/), no exponen sus escalares de creación como propiedades escribibles. Para cambiar esos ajustes, elimine la operación y añada una de reemplazo en la posición requerida.

Los datos efectivos devueltos por `getEffective` se calculan y son de solo lectura. Son útiles para resolver colores dependientes del tema y leer los valores normalizados que utiliza el renderizador, pero no constituyen otra superficie de edición. El siguiente ejemplo enumera la cadena e inspecciona los valores efectivos donde la API correspondiente los proporciona:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

Los efectos sin parámetros como escala de grises, techo alfa e inverso alfa también poseen un objeto de datos efectivos, pero no hay ajustes escalares que imprimir. Su presencia y posición en la colección son la información importante.

## **Eliminar o limpiar transformaciones de imagen**

Utilice [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) para eliminar una operación por índice. Como los índices cambian después de una eliminación, busque primero el objetivo y elimínelo tras la enumeración. Use [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#clear) para eliminar toda la cadena.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Eliminar o limpiar transformaciones solo modifica el formato de la imagen. No elimina, recomprime ni altera de otro modo el recurso [PPImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/ppimage/) reutilizado.

## **Considerar formatos de presentación y destinos de exportación**

Las transformaciones de imagen se originan en DrawingML, por lo que PPTX es el formato editable preferido para cadenas de efectos. Incluso con PPTX, no todas las operaciones tienen la misma portabilidad:

- Las operaciones estándar de DrawingML como luminancia, escala de grises, duotono, tinte, HSL, desenfoque y operaciones alfa comunes tienen mayor probabilidad de sobrevivir a una ida y vuelta de PPTX. Siempre vuelva a abrir el archivo generado e inspeccione la colección cuando la preservación sea un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/es/python-java/aspose.slides/brightnesscontrast/) es una extensión de Office 2010 más que la operación estándar de luminancia DrawingML. Puede usarse para renderizado en memoria, pero no hay garantía de que siga siendo un [BrightnessContrast](https://reference.aspose.com/slides/es/python-java/aspose.slides/brightnesscontrast/) editable después de guardar y volver a abrir PPTX. Prefiera [addLuminanceEffect](https://reference.aspose.com/slides/es/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) para ajustes persistentes de brillo y contraste.
- El formato binario PPT precede al modelo completo de efectos DrawingML. Guardar en PPT puede omitir operaciones no compatibles, reducir una cadena a un subconjunto soportado o aproximar la apariencia. No use PPT como formato de verificación para una cadena editable compleja.
- Renderizar a PNG, JPEG, TIFF, PDF, SVG, HTML u otro salida visual aplica la cadena soportada a la apariencia renderizada. esas salidas no contienen una `ImageTransformOperationCollection` editable; los formatos raster aplanan el resultado en píxeles, y las exportaciones de documento/vector almacenan su propia representación de renderizado.
- Los efectos no hacen que una imagen enlazada sea autónoma. Renderizar una imagen enlazada sigue dependiendo de que el recurso enlazado esté disponible cuando se cargue la presentación.

Diferentes consumidores de presentaciones pueden renderizar casos límite de forma distinta, especialmente cuando se combinan varias operaciones alfa o de cuantización de color. Para resultados críticos, pruebe tanto la ida y vuelta editable como el formato de exportación final con la misma versión de Aspose.Slides utilizada en producción.

## **FAQ**

**¿Los efectos de transformación de imagen modifican los datos de la imagen incrustada?**

No. Las operaciones pertenecen al `Picture` usado por el relleno de imagen. Los bytes subyacentes de `PPImage` permanecen sin cambios.

**¿Dos marcos de imagen que reutilizan la misma imagen compartirán sus efectos?**

No. Reutilizar un `PPImage` evita datos de imagen duplicados, pero cada marco de imagen normalmente tiene su propio `Picture` y su propia colección de transformaciones de imagen.

**¿Se pueden combinar efectos de color, desenfoque y alfa?**

Sí. La colección los acepta en una única cadena ordenada. Considere lo que cada operación hace sobre la salida de la anterior, ya que las operaciones de sustitución y umbral pueden descartar detalle de color o alfa creados antes.

**¿Por qué los valores efectivos son de solo lectura?**

Los datos efectivos representan valores calculados usados para el renderizado, incluidos los colores resueltos. Edite la operación almacenada en la colección de transformaciones donde existan miembros escribibles; de lo contrario elimínela y añada una de reemplazo con nuevos parámetros de creación.

**¿Qué formato debo usar para preservar una cadena de transformaciones?**

Use PPTX y verifique el archivo volviéndolo a abrir. El formato PPT heredado no puede representar el modelo completo de efectos DrawingML, y los formatos de exportación renderizados conservan la apariencia pero no las operaciones editables de transformación de imagen.