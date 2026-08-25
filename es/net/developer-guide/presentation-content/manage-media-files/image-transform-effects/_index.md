---
title: Gestionar efectos de transformación de imagen en presentaciones con .NET
linktitle: Efectos de transformación de imagen
type: docs
weight: 11
url: /es/net/image-transform-effects/
keywords:
- transformación de imagen
- efecto de imagen
- brillo
- contraste
- escala de grises
- duotono
- tono
- HSL
- sustitución de color
- desenfoque
- transparencia
- efecto alfa
- cadena de efectos
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aplicar, encadenar, inspeccionar, eliminar y verificar los efectos de transformación de imagen para marcos de imagen con Aspose.Slides para .NET."
---
## **Descripción general**

Aspose.Slides representa los ajustes de imagen como una colección ordenada de operaciones de transformación de imagen. Para un marco de imagen, comience con el [ISlidesPicture](https://reference.aspose.com/slides/es/net/aspose.slides/islidespicture/) del marco y acceda a [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/es/net/aspose.slides/islidespicture/imagetransform/). La [IImageTransformOperationCollection](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/) devuelta le permite añadir, enumerar, inspeccionar, eliminar y borrar efectos sin reescribir los bytes originales de la imagen.

Este artículo muestra un flujo de trabajo completo para brillo y contraste, transformaciones de color, desenfoque, transparencia, cadenas de efectos ordenadas, valores efectivos, eliminación y verificación de ida y vuelta de PPTX.

## **Comprender la propiedad del efecto y la reutilización de imágenes**

Un recurso de imagen y la imagen que la muestra son objetos diferentes:

- [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) almacena o hace referencia a los datos de imagen fuente que posee la presentación.
- [ISlidesPicture](https://reference.aspose.com/slides/es/net/aspose.slides/islidespicture/) pertenece a un relleno de imagen y se refiere a un recurso de imagen mientras almacena la colección de transformaciones de imagen.
- [IPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ipictureframe/) es la forma de diapositiva que posee el relleno de imagen correspondiente, la geometría, la configuración de recorte y demás formato a nivel de marco.

Por lo tanto, las operaciones de transformación de imagen no modifican los bytes en [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/). Cuando el mismo `IPPImage` se pasa a [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/addpictureframe/) más de una vez, cada nuevo marco de imagen recibe su propio `ISlidesPicture` y su propia colección de transformaciones. Aplicar escala de grises a un marco no hace que los demás marcos sean en escala de grises, aunque todos reutilicen el mismo recurso de imagen incrustado.

El mismo modelo `ISlidesPicture.ImageTransform` también se utiliza en otros rellenos de imagen, como el fondo de una forma o de una diapositiva. Los ejemplos a continuación se centran en marcos de imagen.

## **Utilizar rangos y unidades de parámetros válidos**

Los métodos demostrados utilizan los siguientes rangos semánticos y unidades. Mantenga los valores en estos rangos incluso si una versión particular de la biblioteca no rechaza inmediatamente cada valor fuera de rango; el formato de presentación de destino puede normalizar, omitir o rechazar datos no válidos al guardar o cuando PowerPoint abra el archivo.

| Operación | Parámetros | Rango y unidad válidos |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` a `100`, por ciento; `0` deja el componente sin cambios. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Ninguno | No hay parámetros numéricos. Alfa permanece sin cambios. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Dos colores para píxeles oscuros y claros. Los canales RGB y alfa en `System.Drawing.Color` usan valores de `0` a `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | `hue` es de `0` inclusive a `360` exclusive, en grados; `amount` es de `-100` a `100`, por ciento. |
| [AddHSLEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | `hue` es de `0` inclusive a `360` exclusive, en grados; `saturation` y `luminance` son de `-100` a `100`, por ciento. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | El color de sustitución usa valores de canal de `0` a `255`. Los valores alfa existentes permanecen sin cambios. |
| [AddBlurEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | `radius` es no negativo y se mide en puntos; `grow` es un Boolean que controla si el contenido desenfocado puede extenderse fuera de los límites originales. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Porcentaje no negativo. Use `0` a `100` para escalar la opacidad ordinaria: `0` es totalmente transparente y `100` conserva el alfa existente. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` a `100`, por ciento de opacidad. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` a `100`, por ciento de umbral alfa. Los valores por debajo se vuelven transparentes; los valores en o por encima se vuelven opacos. |

Para la modulación alfa fija, la transparencia y la opacidad son complementarias. Por ejemplo, un 35 % de transparencia corresponde a una cantidad de modulación alfa del 65 %.

## **Aplicar brillo y contraste**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) devuelve una operación [IBrightnessContrast](https://reference.aspose.com/slides/es/net/aspose.slides.effects/ibrightnesscontrast/). Sus configuraciones escalares se suministran cuando se crea la operación. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/es/net/aspose.slides.effects/brightnesscontrast/geteffective/) devuelve valores calculados de solo lectura que pueden inspeccionarse o registrarse.

El siguiente ejemplo aumenta el brillo en un 15 % y el contraste en un 20 %, luego genera una vista previa sin modificar la imagen incrustada:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/es/net/aspose.slides.effects/brightnesscontrast/) es una extensión de efecto de imagen de Office 2010 y es menos portable que el efecto estándar de luminancia de DrawingML. Cuando el brillo y el contraste deben permanecer editables después de una ida y vuelta de PPTX, use [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) y verifique el resultado tras volver a abrir el archivo. La sección de limitaciones de formato explica esta distinción con más detalle.

## **Aplicar transformaciones de color**

Los efectos de color pueden aplicarse de forma independiente a diferentes marcos de imagen que reutilizan un mismo recurso de imagen. El siguiente ejemplo crea cinco marcos y aplica escala de grises, duotono, tono, ajuste HSL y sustitución de color.

[IDuotone](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iduotone/) contiene dos parámetros de color editables de forma independiente: `Color1` asigna los píxeles oscuros, mientras que `Color2` asigna los píxeles claros. Esto lo convierte en un ejemplo útil de un efecto cuyas configuraciones son más complejas que un único valor escalar.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) sustituye el color de cada píxel por un color fijo mientras preserva el alfa. Es diferente de [AddColorChangeEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), que asigna un color fuente a otro y expone ambos formatos de color fuente y destino.

## **Agregar desenfoque, transparencia y efectos alfa**

[AddBlurEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) afecta a todos los canales de color, incluido el alfa. Establezca `grow` en `true` cuando el borde desenfocado pueda extenderse más allá de los límites originales de la imagen.

Para una transparencia uniforme, use [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Multiplica cada valor alfa existente, de modo que los píxeles parcialmente transparentes permanecen proporcionalmente diferentes. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) asigna en su lugar un único valor alfa a todos los píxeles. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) convierte el alfa a dos niveles basándose en un umbral.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

Otras operaciones alfa sin parámetros incluyen [AddAlphaCeilingEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), que hace que todo alfa distinto de cero sea totalmente opaco; [AddAlphaFloorEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), que hace que todo alfa por debajo del 100 % sea totalmente transparente; y [AddAlphaInverseEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), que cambia el alfa a `100% - alpha`.

## **Construir una cadena de efectos ordenada**

Cada método `Add...Effect` añade una nueva operación al final de la colección. El motor de renderizado utiliza la colección como una tubería ordenada: la salida de la operación 0 se convierte en la entrada de la operación 1, y así sucesivamente. En consecuencia, las mismas operaciones en un orden diferente pueden producir una imagen distinta.

Por ejemplo, aplicar escala de grises seguida de tono primero elimina la información cromática y luego recolorea el resultado de luminancia. Aplicar tono seguido de escala de grises elimina nuevamente el tono. De forma similar, la sustitución alfa puede sobrescribir los valores alfa calculados por operaciones anteriores, mientras que la modulación alfa preserva sus diferencias relativas.

El siguiente ejemplo construye una cadena de cuatro operaciones, la guarda como PPTX, vuelve a abrir la presentación, comprueba tanto los tipos de operación como su orden, y renderiza el resultado reabierto:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

La colección no impone una matriz de compatibilidad que restrinja operaciones de color, alfa y desenfoque a cadenas separadas. Pueden combinarse, pero las combinaciones no siempre son útiles. Una sustitución de color fija elimina la variación RGB producida por efectos de color anteriores; la escala de grises después del duotono elimina los dos colores seleccionados; y las operaciones de techo, suelo, sustitución o bi‑nivel alfa pueden descartar detalle alfa creado antes. Construya la cadena según la secuencia de procesamiento de píxeles deseada en lugar de tratar sus elementos como indicadores de formato desordenados.

## **Inspeccionar valores editables y efectivos**

Una operación editable es el objeto almacenado en `ISlidesPicture.ImageTransform`. Según el efecto, puede exponer miembros escribibles directamente. Por ejemplo, [IBlur](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iblur/) expone `Radius` y `Grow` escribibles, [IAlphaModulateFixed](https://reference.aspose.com/slides/es/net/aspose.slides.effects/ialphamodulatefixed/) expone `Amount` escribible, y [IAlphaBiLevel](https://reference.aspose.com/slides/es/net/aspose.slides.effects/ialphabilevel/) expone `Threshold` escribible. Los efectos de color como [IDuotone](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iduotone/) exponen objetos [IColorFormat](https://reference.aspose.com/slides/es/net/aspose.slides/icolorformat/) mutables.

Algunas interfaces de operación, incluidas [IBrightnessContrast](https://reference.aspose.com/slides/es/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/es/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/es/net/aspose.slides.effects/itint/), y [IAlphaReplace](https://reference.aspose.com/slides/es/net/aspose.slides.effects/ialphareplace/), no exponen sus escalares de creación como propiedades escribibles. Para cambiar esas configuraciones, elimine la operación y añada una de reemplazo en la posición requerida.

Los datos efectivos devueltos por `GetEffective()` se calculan y son de solo lectura. Son útiles para resolver colores dependientes del tema y leer los valores normalizados que utiliza el motor de renderizado, pero no constituyen otra superficie de edición. El siguiente ejemplo enumera la cadena e inspecciona los valores efectivos donde la API correspondiente los proporciona:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

Los efectos sin parámetros, como escala de grises, techo alfa y alfa inversa, todavía poseen un objeto de datos efectivos, pero no hay configuraciones escalares que imprimir. Su presencia y posición en la colección son la información importante.

## **Eliminar o borrar transformaciones de imagen**

Utilice [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) para eliminar una operación por índice. Como los índices cambian después de una eliminación, busque primero el objetivo y elimínelo después de la enumeración. Use `Clear()` para eliminar toda la cadena.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

Eliminar o borrar transformaciones solo cambia el formato de la imagen. No elimina, recompresión ni altera de otro modo el recurso [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) reutilizado.

## **Considerar formatos de presentación y objetivos de exportación**

Las transformaciones de imagen se originan en DrawingML, por lo que PPTX es el formato editable preferido para cadenas de efectos. Incluso con PPTX, no todas las operaciones tienen la misma portabilidad:

- Las operaciones estándar de DrawingML como luminancia, escala de grises, duotono, tono, HSL, desenfoque y operaciones alfa comunes tienen la mayor probabilidad de sobrevivir a una ida y vuelta de PPTX. Siempre vuelva a abrir el archivo generado e inspeccione la colección cuando la preservación sea un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/es/net/aspose.slides.effects/brightnesscontrast/) es una extensión de Office 2010 más que la operación estándar de luminancia de DrawingML. Puede usarse para renderizado en memoria, pero no hay garantía de que siga siendo un [IBrightnessContrast](https://reference.aspose.com/slides/es/net/aspose.slides.effects/ibrightnesscontrast/) editable después de guardar y volver a abrir el PPTX. Prefiera [AddLuminanceEffect](https://reference.aspose.com/slides/es/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) para ajustes de brillo y contraste persistentes.
- El formato binario PPT es anterior al modelo completo de efectos DrawingML. Guardar en PPT puede omitir operaciones no compatibles, reducir una cadena a un subconjunto admitido o aproximar la apariencia. No use PPT como formato de verificación para una cadena editable compleja.
- Renderizar a PNG, JPEG, TIFF, PDF, SVG, HTML u otro salida visual aplica la cadena admitida a la apariencia renderizada. esas salidas no contienen una [IImageTransformOperationCollection] editable; los formatos raster aplanan el resultado en píxeles, y las exportaciones de documento/vector almacenan su propia representación de renderizado.
- Los efectos no hacen que una imagen enlazada sea autónoma. Renderizar una imagen enlazada sigue dependiendo de que el recurso enlazado esté disponible cuando se cargue la presentación.

Diferentes consumidores de presentaciones pueden renderizar casos límite de forma distinta, sobre todo cuando se combinan varias operaciones alfa o de cuantización de color. Para una salida crítica, pruebe tanto la ida y vuelta editable como el formato de exportación final con la misma versión de Aspose.Slides que se usa en producción.

## **Preguntas frecuentes**

**¿Los efectos de transformación de imagen modifican los datos de la imagen incrustada?**

No. Las operaciones pertenecen al `ISlidesPicture` utilizado por el relleno de imagen. Los bytes subyacentes de `IPPImage` permanecen sin cambios.

**¿Dos marcos de imagen que reutilizan la misma imagen comparten sus efectos?**

No. Reutilizar un `IPPImage` evita datos duplicados de imagen, pero cada marco de imagen normalmente tiene un `ISlidesPicture` y una colección de transformaciones de imagen independientes.

**¿Se pueden combinar efectos de color, desenfoque y alfa?**

Sí. La colección los acepta en una única cadena ordenada. Considere lo que cada operación hace a la salida de la anterior, ya que las operaciones de sustitución y umbral pueden descartar detalle de color o alfa previo.

**¿Por qué los valores efectivos son de solo lectura?**

Los datos efectivos representan valores calculados usados para el renderizado, incluidos los colores resueltos. Edite la operación almacenada en la colección de transformaciones donde existan miembros escribibles; de lo contrario, elimínela y añada una de reemplazo con nuevos parámetros de creación.

**¿Qué formato debo usar para conservar una cadena de transformaciones?**

Use PPTX y verifique el archivo volviéndolo a abrir. El legado PPT no puede representar el modelo completo de efectos DrawingML, y los formatos de exportación renderizados conservan la apariencia más que las operaciones de transformación editables.