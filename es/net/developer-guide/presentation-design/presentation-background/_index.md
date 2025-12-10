---
title: Gestionar fondos de presentación en .NET
linktitle: Fondo de diapositiva
type: docs
weight: 20
url: /es/net/presentation-background/
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
- .NET
- C#
- Aspose.Slides
description: "Aprende a establecer fondos dinámicos en archivos PowerPoint y OpenDocument usando Aspose.Slides para .NET, con consejos de código para mejorar tus presentaciones."
---

## **Descripción general**

Los colores sólidos, los degradados y las imágenes se usan comúnmente como fondos de diapositivas. Puede establecer el fondo para una **diapositiva normal** (una sola diapositiva) o una **diapositiva maestra** (se aplica a varias diapositivas a la vez).

![Fondo de PowerPoint](powerpoint-background.png)

## **Establecer un fondo de color sólido para una diapositiva normal**

Aspose.Slides le permite establecer un color sólido como fondo para una diapositiva específica en una presentación, incluso si la presentación usa una diapositiva maestra. El cambio se aplica solo a la diapositiva seleccionada.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) de la diapositiva a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) del fondo de la diapositiva a `Solid`.
4. Utilice la propiedad [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) en [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) para especificar el color sólido del fondo.
5. Guarde la presentación modificada.

El siguiente ejemplo en C# muestra cómo establecer un color sólido azul como fondo para una diapositiva normal:
```cs
// Crear una instancia de la clase Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Establecer el color de fondo de la diapositiva a azul.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Guardar la presentación en disco.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```


## **Establecer un fondo de color sólido para una diapositiva maestra**

Aspose.Slides le permite establecer un color sólido como fondo para la diapositiva maestra en una presentación. La diapositiva maestra actúa como una plantilla que controla el formato de todas las diapositivas, por lo que cuando elige un color sólido para el fondo de la diapositiva maestra, se aplica a todas las diapositivas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) de la diapositiva maestra (a través de `masters`) a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) del fondo de la diapositiva maestra a `Solid`.
4. Utilice la propiedad [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) para especificar el color sólido del fondo.
5. Guarde la presentación modificada.

El siguiente ejemplo en C# muestra cómo establecer un color sólido (verde bosque) como fondo para una diapositiva maestra:
```cs
// Crear una instancia de la clase Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Establecer el color de fondo de la diapositiva maestra a verde bosque.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Guardar la presentación en disco.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```


## **Establecer un fondo degradado para una diapositiva**

Un degradado es un efecto gráfico creado por un cambio gradual de color. Cuando se usa como fondo de diapositiva, los degradados pueden hacer que las presentaciones se vean más artísticas y profesionales. Aspose.Slides le permite establecer un color degradado como fondo para las diapositivas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) de la diapositiva a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) del fondo de la diapositiva a `Gradient`.
4. Utilice la propiedad [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) en [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) para configurar sus ajustes de degradado preferidos.
5. Guarde la presentación modificada.

El siguiente ejemplo en C# muestra cómo establecer un color degradado como fondo para una diapositiva:
```cs
// Crear una instancia de la clase Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Aplicar un efecto de degradado al fondo.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Guardar la presentación en disco.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```


## **Establecer una imagen como fondo de diapositiva**

Además de los rellenos sólidos y degradados, Aspose.Slides le permite usar imágenes como fondos de diapositiva.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Establezca el [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) de la diapositiva a `OwnBackground`.
3. Establezca el [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) del fondo de la diapositiva a `Picture`.
4. Cargue la imagen que desea usar como fondo de la diapositiva.
5. Añada la imagen a la colección de imágenes de la presentación.
6. Utilice la propiedad [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) en [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) para asignar la imagen como fondo.
7. Guarde la presentación modificada.

El siguiente ejemplo en C# muestra cómo establecer una imagen como fondo para una diapositiva:
```c#
// Crear una instancia de la clase Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Establecer propiedades de la imagen de fondo.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Cargar la imagen.
    IImage image = Images.FromFile("Tulips.jpg");
    // Añadir la imagen a la colección de imágenes de la presentación.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Guardar la presentación en disco.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```


El siguiente fragmento de código muestra cómo establecer el tipo de relleno de fondo a una imagen en mosaico y modificar las propiedades de mosaico:
```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Establecer la imagen usada para el relleno de fondo.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Establecer el modo de relleno de imagen a Mosaico y ajustar las propiedades del mosaico.
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}
Leer más: [**Tile Picture As Texture**](/slides/es/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Cambiar la transparencia de la imagen de fondo**

Puede que desee ajustar la transparencia de la imagen de fondo de una diapositiva para que el contenido de la diapositiva resalte. El siguiente código C# le muestra cómo cambiar la transparencia de la imagen de fondo de una diapositiva:
```cs
var transparencyValue = 30; // Por ejemplo.

// Obtener la colección de operaciones de transformación de imagen.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Encontrar un efecto de transparencia de porcentaje fijo existente.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Establecer el nuevo valor de transparencia.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```


## **Obtener el valor del fondo de la diapositiva**

Aspose.Slides proporciona la interfaz [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) para recuperar los valores efectivos del fondo de una diapositiva. Esta interfaz expone el [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat/) y [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/) efectivos.

Usando la propiedad `background` de la clase [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/), puede obtener el fondo efectivo de una diapositiva.

El siguiente ejemplo en C# muestra cómo obtener el valor efectivo del fondo de una diapositiva:
```cs
// Crear una instancia de la clase Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Obtener el fondo efectivo, teniendo en cuenta la diapositiva maestra, la disposición y el tema.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```


## **FAQ**

**¿Puedo restablecer un fondo personalizado y restaurar el fondo del tema/disposición?**

Sí. Elimine el relleno personalizado de la diapositiva y el fondo volverá a heredarse del [layout](/slides/es/net/slide-layout/)/[master](/slides/es/net/slide-master/) correspondiente (es decir, del [fondo del tema](/slides/es/net/presentation-theme/)).

**¿Qué ocurre con el fondo si cambio el tema de la presentación más tarde?**

Si una diapositiva tiene su propio relleno, permanecerá sin cambios. Si el fondo se hereda del [layout](/slides/es/net/slide-layout/)/[master](/slides/es/net/slide-master/), se actualizará para coincidir con el [nuevo tema](/slides/es/net/presentation-theme/).