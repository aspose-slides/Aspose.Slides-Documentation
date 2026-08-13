---
title: Gestionar fondos de presentación en C++
linktitle: Fondo de diapositiva
type: docs
weight: 20
url: /es/cpp/presentation-background/
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
- C++
- Aspose.Slides
description: "Aprenda a establecer fondos dinámicos en archivos PowerPoint y OpenDocument usando Aspose.Slides para C++, con consejos de código para mejorar sus presentaciones."
---
## **Introducción**

Los colores sólidos, los degradados y las imágenes se utilizan habitualmente como fondos de diapositiva. Puede establecer el fondo para una **diapositiva normal** (una sola diapositiva) o una **diapositiva maestra** (se aplica a varias diapositivas a la vez).

![PowerPoint background](powerpoint-background.png)

## **Establecer un fondo de color sólido para una diapositiva normal**

Aspose.Slides le permite establecer un color sólido como fondo de una diapositiva específica en una presentación, incluso si la presentación utiliza una diapositiva maestra. El cambio se aplica solo a la diapositiva seleccionada.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/es/cpp/aspose.slides/backgroundtype/) de la diapositiva a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/es/cpp/aspose.slides/filltype/) del fondo de la diapositiva a `Solid`.
4. Utilice el método [get_SolidFillColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/fillformat/get_solidfillcolor/) en [FillFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/fillformat/) para especificar el color sólido del fondo.
5. Guarde la presentación modificada.

El siguiente ejemplo en C++ muestra cómo establecer un color sólido azul como fondo de una diapositiva normal:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Crear una instancia de la clase Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Set the background color of the slide to blue.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save the presentation to disk.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Establecer un fondo de color sólido para una diapositiva maestra**

Aspose.Slides le permite establecer un color sólido como fondo de la diapositiva maestra en una presentación. La diapositiva maestra actúa como una plantilla que controla el formato de todas las diapositivas, por lo que cuando elige un color sólido para el fondo de la diapositiva maestra, se aplica a todas las diapositivas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/es/cpp/aspose.slides/backgroundtype/) de la diapositiva maestra (a través de `get_Masters`) a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/es/cpp/aspose.slides/filltype/) del fondo de la diapositiva maestra a `Solid`.
4. Utilice el método [get_SolidFillColor](https://reference.aspose.com/slides/es/cpp/aspose.slides/fillformat/get_solidfillcolor/) para especificar el color sólido del fondo.
5. Guarde la presentación modificada.

El siguiente ejemplo en C++ muestra cómo establecer un color sólido (verde bosque) como fondo de una diapositiva maestra:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// Crear una instancia de la clase Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Establecer el color de fondo de la diapositiva maestra a Verde bosque.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Guardar la presentación en disco.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Establecer un fondo degradado para una diapositiva**

Un degradado es un efecto gráfico creado por un cambio gradual de color. Cuando se utiliza como fondo de diapositiva, los degradados pueden hacer que las presentaciones parezcan más artísticas y profesionales. Aspose.Slides le permite establecer un color degradado como fondo de las diapositivas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/es/cpp/aspose.slides/backgroundtype/) de la diapositiva a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/es/cpp/aspose.slides/filltype/) del fondo de la diapositiva a `Gradient`.
4. Utilice el método [get_GradientFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/fillformat/get_gradientformat/) en [FillFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/fillformat/) para configurar sus ajustes de degradado preferidos.
5. Guarde la presentación modificada.

El siguiente ejemplo en C++ muestra cómo establecer un color degradado como fondo de una diapositiva:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Crear una instancia de la clase Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Aplicar un efecto degradado al fondo.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Guardar la presentación en disco.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Establecer una imagen como fondo de diapositiva**

Además de los rellenos sólidos y degradados, Aspose.Slides le permite usar imágenes como fondos de diapositiva.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/es/cpp/aspose.slides/backgroundtype/) de la diapositiva a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/es/cpp/aspose.slides/filltype/) del fondo de la diapositiva a `Picture`.
4. Cargue la imagen que desea usar como fondo de la diapositiva.
5. Añada la imagen a la colección de imágenes de la presentación.
6. Utilice el método [get_PictureFillFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/fillformat/get_picturefillformat/) en [FillFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/fillformat/) para asignar la imagen como fondo.
7. Guarde la presentación modificada.

El siguiente ejemplo en C++ muestra cómo establecer una imagen como fondo de una diapositiva:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Crear una instancia de la clase Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Establecer propiedades de la imagen de fondo.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Cargar la imagen.
auto image = Images::FromFile(u"Tulips.jpg");
// Añadir la imagen a la colección de imágenes de la presentación.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Guardar la presentación en disco.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

El siguiente fragmento de código muestra cómo establecer el tipo de relleno de fondo a una imagen en mosaico y modificar las propiedades de mosaico:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}}
Lea más: [**Imagen en mosaico como textura**](/slides/es/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Cambiar la transparencia de la imagen de fondo**

Es posible que desee ajustar la transparencia de la imagen de fondo de una diapositiva para que el contenido de la diapositiva resalte. El siguiente código en C++ le muestra cómo cambiar la transparencia de la imagen de fondo de una diapositiva:

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto transparencyValue = 30; // Por ejemplo.

 // Crear una instancia de la clase Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Obtener la colección de operaciones de transformación de imagen.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Buscar un efecto de transparencia de porcentaje fijo existente.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Establecer el nuevo valor de transparencia.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}

// Guardar la presentación en disco.
presentation->Save(u"TransparentBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Obtener el valor del fondo de la diapositiva**

Aspose.Slides proporciona la interfaz [IBackgroundEffectiveData](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibackgroundeffectivedata/) para recuperar los valores efectivos del fondo de una diapositiva. Esta interfaz expone el [FillFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) y el [EffectFormat](https://reference.aspose.com/slides/es/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) efectivos.

Utilizando el método `get_Background` de la clase [BaseSlide](https://reference.aspose.com/slides/es/cpp/aspose.slides/baseslide/), puede obtener el fondo efectivo de una diapositiva.

El siguiente ejemplo en C++ muestra cómo obtener el valor efectivo del fondo de una diapositiva:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

// Crear una instancia de la clase Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Retrieve the effective background, taking into account master, layout, and theme.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```

## **FAQ**

### ¿Puedo restablecer un fondo personalizado y recuperar el fondo del tema/diseño?

Sí. Elimine el relleno personalizado de la diapositiva y el fondo volverá a heredarse del correspondiente [diseño](/slides/es/cpp/slide-layout/)/[maestra](/slides/es/cpp/slide-master/) (es decir, del [fondo del tema](/slides/es/cpp/presentation-theme/)).

### ¿Qué ocurre con el fondo si modifico más tarde el tema de la presentación?

Si una diapositiva tiene su propio relleno, permanecerá sin cambios. Si el fondo se hereda del [diseño](/slides/es/cpp/slide-layout/)/[maestra](/slides/es/cpp/slide-master/), se actualizará para coincidir con el [nuevo tema](/slides/es/cpp/presentation-theme/).