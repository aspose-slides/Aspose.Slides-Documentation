---
title: Gestionar los efectos de transformación de imagen en presentaciones con C++
linktitle: Efectos de transformación de imagen
type: docs
weight: 11
url: /es/cpp/image-transform-effects/
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
- C++
- Aspose.Slides
description: "Aplicar, encadenar, inspeccionar, eliminar y verificar los efectos de transformación de imagen para marcos de imagen con Aspose.Slides para C++."
---
## **Visión general**

Aspose.Slides representa los ajustes de imagen como una colección ordenada de operaciones de transformación de imagen. Para un marco de imagen, comience con el [ISlidesPicture](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidespicture/) del marco y acceda a [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidespicture/get_imagetransform/). La [IImageTransformOperationCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/) devuelta le permite añadir, enumerar, inspeccionar, eliminar y borrar efectos sin reescribir los bytes originales de la imagen.

Este artículo muestra un flujo de trabajo completo para brillo y contraste, transformaciones de color, desenfoque, transparencia, cadenas de efectos ordenadas, valores efectivos, eliminación y verificación de ida y vuelta en PPTX.

## **Entender la propiedad de los efectos y la reutilización de imágenes**

Un recurso de imagen y la imagen que lo muestra son objetos diferentes:

- [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) almacena o hace referencia a los datos de la imagen fuente que pertenece a la presentación.
- [ISlidesPicture](https://reference.aspose.com/slides/es/cpp/aspose.slides/islidespicture/) pertenece a un relleno de imagen y se refiere a un recurso de imagen mientras almacena la colección de transformaciones de imagen.
- [IPictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipictureframe/) es la forma de diapositiva que posee el relleno de imagen correspondiente, la geometría, la configuración de recorte y otros formatos a nivel de marco.

Por lo tanto, las operaciones de transformación de imagen no modifican los bytes en [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/). Cuando el mismo `IPPImage` se pasa a [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/es/cpp/aspose.slides/ishapecollection/addpictureframe/) más de una vez, cada nuevo marco de imagen recibe su propio `ISlidesPicture` y su propia colección de transformaciones. Aplicar escala de grises a un marco no hace que los demás marcos sean en escala de grises, aunque todos reutilicen el mismo recurso de imagen incrustado.

El mismo modelo `ISlidesPicture::get_ImageTransform` también lo utilizan otros rellenos de imagen, como una forma o el fondo de la diapositiva. Los ejemplos a continuación se centran en los marcos de imagen.

## **Usar rangos y unidades de parámetro válidos**

Los métodos demostrados usan los siguientes rangos semánticos y unidades. Mantenga los valores dentro de estos rangos incluso si una versión concreta de la biblioteca no rechaza inmediatamente cada valor fuera de rango; el formato de presentación de destino puede normalizar, omitir o rechazar datos no válidos durante el guardado o cuando PowerPoint abra el archivo.

| Operación | Parámetros | Rango y unidad válidos |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` a `100`, porcentaje; `0` deja el componente sin cambios. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Ninguno | Sin parámetros numéricos. Alpha no cambia. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Dos colores para píxeles oscuros y claros. Los canales RGB y alfa en `System::Drawing::Color` usan valores de `0` a `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Hue es de `0` inclusive a `360` exclusivo, en grados; amount es de `-100` a `100`, porcentaje. |
| [AddHSLEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Hue es de `0` inclusive a `360` exclusivo, en grados; saturación y luminancia son de `-100` a `100`, porcentaje. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | El color de reemplazo usa valores de canal de `0` a `255`. Los valores alfa existentes no cambian. |
| [AddBlurEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Radius es no negativo y se mide en puntos; `grow` controla si el contenido desenfocado puede extenderse fuera de los límites originales. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Porcentaje no negativo. Use `0` a `100` para escalar la opacidad normal: `0` es totalmente transparente y `100` preserva el alfa existente. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` a `100`, porcentaje de opacidad. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` a `100`, porcentaje de umbral alfa. Los valores por debajo se vuelven transparentes; los valores en o por encima se vuelven opacos. |

Para la modulación alfa fija, la transparencia y la opacidad son complementarias. Por ejemplo, un 35 % de transparencia corresponde a una cantidad de modulación alfa del 65 %.

## **Aplicar brillo y contraste**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) devuelve una operación [IBrightnessContrast](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/ibrightnesscontrast/). Sus ajustes escalares se proporcionan cuando se crea la operación. El método `IBrightnessContrast::GetEffective` devuelve valores calculados de solo lectura que pueden inspeccionarse o registrarse.

El siguiente ejemplo incrementa el brillo un 15 % y el contraste un 20 %, y luego genera una vista previa sin modificar la imagen incrustada:

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/brightnesscontrast/) es una extensión de efecto de imagen de Office 2010 y es menos portable que el efecto de luminancia estándar de DrawingML. Cuando el brillo y el contraste deben seguir siendo editables después de una ida y vuelta en PPTX, use [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) y verifique el resultado después de volver a abrir el archivo. La sección de limitaciones de formato explica esta distinción con más detalle.

## **Aplicar transformaciones de color**

Los efectos de color pueden aplicarse de forma independiente a diferentes marcos de imagen que reutilizan un mismo recurso de imagen. El siguiente ejemplo crea cinco marcos y aplica escala de grises, duotono, tinte, ajuste HSL y reemplazo de color.

[IDuotone](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iduotone/) contiene dos parámetros de color editables de forma independiente: `get_Color1` asigna los píxeles oscuros, mientras que `get_Color2` asigna los píxeles claros. Esto lo convierte en un ejemplo útil de un efecto cuyas configuraciones son más complejas que un solo valor escalar.

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) reemplaza el color de cada píxel por un color fijo manteniendo el alfa. Es diferente de [AddColorChangeEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), que asigna un color fuente a otro y expone ambos formatos de color origen y destino.

## **Añadir desenfoque, transparencia y efectos alfa**

[AddBlurEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) afecta a todos los canales de color, incluido el alfa. Establezca `grow` en `true` cuando el borde desenfocado pueda extenderse más allá de los límites originales de la imagen.

Para una transparencia uniforme, use [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Multiplica cada valor alfa existente, de modo que los píxeles parcialmente transparentes siguen siendo proporcionalmente diferentes. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) en cambio asigna un único valor alfa a todos los píxeles. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) convierte el alfa en dos niveles basándose en un umbral.

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Otras operaciones alfa sin parámetros incluyen [AddAlphaCeilingEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), que hace que todo alfa distinto de cero sea totalmente opaco; [AddAlphaFloorEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), que hace que todo alfa por debajo del 100 % sea totalmente transparente; y [AddAlphaInverseEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), que cambia el alfa a `100% - alpha`.

## **Construir una cadena de efectos ordenada**

Cada método `Add...Effect` añade una nueva operación al final de la colección. El renderizador utiliza la colección como una canalización ordenada: la salida de la operación 0 se convierte en la entrada de la operación 1, y así sucesivamente. En consecuencia, las mismas operaciones en un orden diferente pueden producir una imagen distinta.

Por ejemplo, escala de grises seguida de tinte primero elimina la información cromática y luego recolorea el resultado de luminancia. Tinte seguido de escala de grises elimina de nuevo el tinte. De modo similar, el reemplazo alfa puede sobrescribir los valores alfa calculados por operaciones anteriores, mientras que la modulación alfa preserva sus diferencias relativas.

El siguiente ejemplo construye una cadena de cuatro operaciones, la guarda como PPTX, vuelve a abrir la presentación, comprueba tanto los tipos de operación como su orden, y genera el resultado reabierto:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

La colección no impone una matriz de compatibilidad que restrinja los efectos de color, alfa y desenfoque a cadenas separadas. Pueden combinarse, pero no siempre son útiles. Un reemplazo de color fijo elimina la variación RGB producida por efectos de color anteriores; la escala de grises después del duotono elimina los dos colores seleccionados; y las operaciones alfa de techo, suelo, reemplazo o bi‑nivel pueden descartar el detalle alfa creado antes. Construya la cadena de acuerdo con la secuencia de procesamiento de píxeles deseada en lugar de tratar sus elementos como banderas de formato sin orden.

## **Inspeccionar valores editables y efectivos**

Una operación editable es el objeto almacenado en `ISlidesPicture::get_ImageTransform`. Según el efecto, puede exponer miembros escribibles directamente. Por ejemplo, [IBlur](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iblur/) expone `set_Radius` y `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/ialphamodulatefixed/) expone `set_Amount`, y [IAlphaBiLevel](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/ialphabilevel/) expone `set_Threshold`. Los efectos de color como [IDuotone](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iduotone/) exponen objetos mutables [IColorFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/icolorformat/).

Algunas interfaces de operación, incluidas [IBrightnessContrast](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/itint/), y [IAlphaReplace](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/ialphareplace/), no exponen sus escalares de creación como propiedades escribibles. Para cambiar esas configuraciones, elimine la operación y añada una de reemplazo en la posición requerida.

Los datos efectivos devueltos por `GetEffective()` se calculan y son de solo lectura. Son útiles para resolver colores dependientes del tema y leer los valores normalizados que utiliza el renderizador, pero no constituyen otra superficie de edición. El siguiente ejemplo enumera la cadena e inspecciona los valores efectivos de varias operaciones habituales:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

Los efectos sin parámetros como escala de grises, techo alfa e inverso alfa también tienen un objeto de datos efectivos, pero no hay ajustes escalares que imprimir. Su presencia y posición en la colección son la información importante.

## **Eliminar o borrar transformaciones de imagen**

Utilice [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) para eliminar una operación por índice. Como los índices cambian tras una eliminación, busque primero el objetivo y elimínelo después de la enumeración. Use `Clear()` para eliminar toda la cadena.

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Eliminar o borrar transformaciones sólo cambia el formato de la imagen. No elimina, recompresión ni altera de otro modo el recurso [IPPImage](https://reference.aspose.com/slides/es/cpp/aspose.slides/ippimage/) reutilizado.

## **Considerar formatos de presentación y destinos de exportación**

Las transformaciones de imagen se originan en DrawingML, por lo que PPTX es el formato editable preferido para cadenas de efectos. Incluso con PPTX, no todas las operaciones tienen la misma portabilidad:

- Las operaciones estándar de DrawingML como luminancia, escala de grises, duotono, tinte, HSL, desenfoque y operaciones alfa comunes tienen más probabilidades de sobrevivir a una ida y vuelta en PPTX. Siempre vuelva a abrir el archivo generado e inspeccione la colección cuando la preservación sea un requisito.
- [BrightnessContrast](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/brightnesscontrast/) es una extensión de Office 2010 más que la operación estándar de luminancia de DrawingML. Puede usarse para renderizado en memoria, pero no está garantizado que siga siendo un [IBrightnessContrast](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/ibrightnesscontrast/) editable tras guardar y volver a abrir PPTX. Prefiera [AddLuminanceEffect](https://reference.aspose.com/slides/es/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) para ajustes persistentes de brillo y contraste.
- El formato binario PPT es anterior al modelo completo de efectos DrawingML. Guardar en PPT puede omitir operaciones no compatibles, reducir la cadena a un subconjunto soportado o aproximar la apariencia. No utilice PPT como formato de verificación para una cadena editable compleja.
- Renderizar a PNG, JPEG, TIFF, PDF, SVG, HTML u otro formato visual aplica la cadena soportada a la apariencia renderizada. Esas salidas no contienen una `IImageTransformOperationCollection` editable; los formatos raster aplanan el resultado en píxeles, y las exportaciones de documento o vector almacenan su propia representación de renderizado.
- Los efectos no hacen que una imagen enlazada sea autónoma. Renderizar una imagen enlazada sigue dependiendo de que el recurso enlazado esté disponible cuando se cargue la presentación.

Los distintos consumidores de presentaciones pueden renderizar casos límite de forma diferente, sobre todo cuando se combinan varias operaciones alfa o de cuantización de color. Para resultados críticos, pruebe tanto la ida y vuelta editable como el formato de exportación final con la misma versión de Aspose.Slides utilizada en producción.

## **Preguntas frecuentes**

**¿Los efectos de transformación de imagen modifican los datos de la imagen incrustada?**

No. Las operaciones pertenecen al `ISlidesPicture` utilizado por el relleno de imagen. Los bytes subyacentes de `IPPImage` permanecen sin cambios.

**¿Dos marcos de imagen que reutilizan la misma imagen comparten sus efectos?**

No. Reutilizar un `IPPImage` evita datos de imagen duplicados, pero cada marco de imagen normalmente tiene su propio `ISlidesPicture` y su propia colección de transformaciones de imagen.

**¿Se pueden combinar efectos de color, desenfoque y alfa?**

Sí. La colección los acepta en una única cadena ordenada. Considere lo que cada operación hace sobre la salida de la anterior, ya que las operaciones de reemplazo y umbral pueden descartar detalle de color o alfa previo.

**¿Por qué los valores efectivos son de solo lectura?**

Los datos efectivos representan los valores calculados que se usan para el renderizado, incluidos los colores resueltos. Edite la operación almacenada en la colección de transformaciones donde existan miembros escribibles; de lo contrario, elimínela y añada una de sustitución con los nuevos parámetros de creación.

**¿Qué formato debo usar para preservar una cadena de transformaciones?**

Utilice PPTX y verifique el archivo volviéndolo a abrir. PPT heredado no puede representar el modelo completo de efectos DrawingML, y los formatos de exportación renderizados conservan solo la apariencia, no las operaciones de transformación editables.