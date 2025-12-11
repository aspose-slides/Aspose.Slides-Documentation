---
title: Administrar fondos de presentación en C++
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
description: "Aprenda cómo establecer fondos dinámicos en archivos PowerPoint y OpenDocument usando Aspose.Slides para C++, con consejos de código para mejorar sus presentaciones."
---

## **Visión general**

Los colores sólidos, los degradados y las imágenes se usan habitualmente como fondos de diapositivas. Puede establecer el fondo para una **diapositiva normal** (una sola diapositiva) o una **diapositiva maestra** (se aplica a varias diapositivas a la vez).

![Fondo de PowerPoint](powerpoint-background.png)

## **Establecer un color sólido como fondo para una diapositiva normal**

Aspose.Slides le permite establecer un color sólido como fondo para una diapositiva específica en una presentación, incluso si la presentación utiliza una diapositiva maestra. El cambio se aplica solo a la diapositiva seleccionada.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) de la diapositiva en `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) del fondo de la diapositiva en `Solid`.
4. Utilice el método [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/) de [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) para especificar el color sólido del fondo.
5. Guarde la presentación modificada.

El siguiente ejemplo en C++ muestra cómo establecer un color sólido azul como fondo para una diapositiva normal:
```cpp
// Crear una instancia de la clase Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Establecer el color de fondo de la diapositiva a azul.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Guardar la presentación en disco.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Establecer un color sólido como fondo para una diapositiva maestra**

Aspose.Slides le permite establecer un color sólido como fondo para la diapositiva maestra en una presentación. La diapositiva maestra actúa como una plantilla que controla el formato de todas las diapositivas, de modo que cuando elige un color sólido para el fondo de la diapositiva maestra, se aplica a todas las diapositivas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) de la diapositiva maestra (a través de `get_Masters`) en `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) del fondo de la diapositiva maestra en `Solid`.
4. Utilice el método [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/) para especificar el color sólido del fondo.
5. Guarde la presentación modificada.

El siguiente ejemplo en C++ muestra cómo establecer un color sólido (verde bosque) como fondo para una diapositiva maestra:
```cpp
// Crear una instancia de la clase Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Establecer el color de fondo de la diapositiva maestra a Verde Bosque.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Guardar la presentación en disco.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Establecer un fondo degradado para una diapositiva**

Un degradado es un efecto gráfico creado por un cambio gradual de color. Cuando se utiliza como fondo de diapositiva, los degradados pueden hacer que las presentaciones se vean más artísticas y profesionales. Aspose.Slides le permite establecer un color degradado como fondo para las diapositivas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) de la diapositiva en `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) del fondo de la diapositiva en `Gradient`.
4. Utilice el método [get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_gradientformat/) de [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) para configurar los ajustes de degradado que prefiera.
5. Guarde la presentación modificada.

El siguiente ejemplo en C++ muestra cómo establecer un color degradado como fondo para una diapositiva:
```cpp
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


## **Establecer una imagen como fondo de la diapositiva**

Además de los rellenos sólidos y degradados, Aspose.Slides le permite usar imágenes como fondos de diapositivas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) de la diapositiva en `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) del fondo de la diapositiva en `Picture`.
4. Cargue la imagen que desea usar como fondo de la diapositiva.
5. Agregue la imagen a la colección de imágenes de la presentación.
6. Utilice el método [get_PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_picturefillformat/) de [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) para asignar la imagen como fondo.
7. Guarde la presentación modificada.

El siguiente ejemplo en C++ muestra cómo establecer una imagen como fondo para una diapositiva:
```cpp
// Crear una instancia de la clase Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Establecer las propiedades de la imagen de fondo.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Cargar la imagen.
auto image = Images::FromFile(u"Tulips.jpg");
// Agregar la imagen a la colección de imágenes de la presentación.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Guardar la presentación en disco.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


El siguiente fragmento de código muestra cómo establecer el tipo de relleno del fondo a una imagen en mosaico y modificar las propiedades del mosaico:
```cpp
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


{{% alert color="primary" %}}
Leer más: [**Imagen de mosaico como textura**](/slides/es/cpp/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Cambiar la transparencia de la imagen de fondo**

Puede que desee ajustar la transparencia de la imagen de fondo de una diapositiva para que el contenido de la diapositiva destaque. El siguiente código en C++ le muestra cómo cambiar la transparencia de la imagen de fondo de una diapositiva:
```cpp
auto transparencyValue = 30; // Por ejemplo.

// Get the collection of picture transform operations.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Find an existing fixed-percentage transparency effect.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```


## **Obtener el valor del fondo de la diapositiva**

Aspose.Slides proporciona la interfaz [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/) para obtener los valores efectivos del fondo de una diapositiva. Esta interfaz expone el [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) y el [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) efectivos.

Usando el método `get_Background` de la clase [BaseSlide](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/), puede obtener el fondo efectivo de una diapositiva.

El siguiente ejemplo en C++ muestra cómo obtener el valor efectivo del fondo de una diapositiva:
```cpp
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


## **Preguntas frecuentes**

**¿Puedo restablecer un fondo personalizado y recuperar el fondo del tema/diseño?**

Sí. Elimine el relleno personalizado de la diapositiva y el fondo volverá a heredarse del [layout](/slides/es/cpp/slide-layout/)/[master](/slides/es/cpp/slide-master/) correspondiente (es decir, del [theme background](/slides/es/cpp/presentation-theme/)).

**¿Qué ocurre con el fondo si cambio el tema de la presentación más tarde?**

Si una diapositiva tiene su propio relleno, permanecerá sin cambios. Si el fondo se hereda del [layout](/slides/es/cpp/slide-layout/)/[master](/slides/es/cpp/slide-master/), se actualizará para coincidir con el [nuevo tema](/slides/es/cpp/presentation-theme/).