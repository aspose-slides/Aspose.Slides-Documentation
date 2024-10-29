---
title: Fondo de Presentación
type: docs
weight: 20
url: /es/net/presentation-background/
keywords:
- fondo de PowerPoint
- establecer fondo
- C#
- Csharp
- Aspose.Slides para .NET
description: "Establecer fondo en una presentación de PowerPoint en C# o .NET"
---

Los colores sólidos, los colores de degradado y las imágenes se utilizan a menudo como imágenes de fondo para las diapositivas. Puedes establecer el fondo tanto para una **diapositiva normal** (diapositiva única) como para una **diapositiva maestra** (varias diapositivas a la vez).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Establecer Color Sólido como Fondo para Diapositiva Normal**

Aspose.Slides te permite establecer un color sólido como fondo para una diapositiva específica en una presentación (incluso si esa presentación contiene una diapositiva maestra). El cambio de fondo afecta solo a la diapositiva seleccionada.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) para la diapositiva en `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) para el fondo de la diapositiva en `Solid`.
4. Utiliza la propiedad [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) expuesta por [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) para especificar un color sólido para el fondo.
5. Guarda la presentación modificada.

Este código C# te muestra cómo establecer un color sólido (azul) como fondo para una diapositiva normal:

```c#
// Crea una instancia de la clase Presentation
using (Presentation pres = new Presentation())
{

    // Establece el color de fondo para la primera ISlide en Azul
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Solid;
    pres.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.Blue;
    
    // Escribe la presentación en disco
    pres.Save("ContentBG_out.pptx", SaveFormat.Pptx);
}
```

## **Establecer Color Sólido como Fondo para Diapositiva Maestra**

Aspose.Slides te permite establecer un color sólido como fondo para la diapositiva maestra en una presentación. La diapositiva maestra actúa como una plantilla que contiene y controla las configuraciones de formato para todas las diapositivas. Por lo tanto, cuando seleccionas un color sólido como fondo para la diapositiva maestra, ese nuevo fondo se utilizará para todas las diapositivas.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) para la diapositiva maestra (`Masters`) en `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) para el fondo de la diapositiva maestra en `Solid`.
4. Utiliza la propiedad [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) expuesta por [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) para especificar un color sólido para el fondo.
5. Guarda la presentación modificada.

Este código C# te muestra cómo establecer un color sólido (verde bosque) como fondo para una diapositiva maestra en una presentación:

```c#
// Crea una instancia de la clase Presentation
using (Presentation pres = new Presentation())
{

    // Establece el color de fondo para la Master ISlide en Verde Bosque
    pres.Masters[0].Background.Type = BackgroundType.OwnBackground;
    pres.Masters[0].Background.FillFormat.FillType = FillType.Solid;
    pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Escribe la presentación en disco
    pres.Save("SetSlideBackgroundMaster_out.pptx", SaveFormat.Pptx);

}
```

## **Establecer Color de Degradado como Fondo para Diapositiva**

Un degradado es un efecto gráfico basado en un cambio gradual de color. Los colores de degradado, cuando se utilizan como fondos para diapositivas, hacen que las presentaciones se vean artísticas y profesionales. Aspose.Slides te permite establecer un color de degradado como fondo para las diapositivas en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) para la diapositiva en `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) para el fondo de la diapositiva maestra en `Gradient`.
4. Utiliza la propiedad [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) expuesta por [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) para especificar tu configuración de degradado preferida.
5. Guarda la presentación modificada.

Este código C# te muestra cómo establecer un color de degradado como fondo para una diapositiva:

```c#
// Crea una instancia de la clase Presentation
using (Presentation pres = new Presentation("SetBackgroundToGradient.pptx"))
{

    // Aplica efecto de Degradado al Fondo
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Gradient;
    pres.Slides[0].Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Escribe la presentación en disco
    pres.Save("ContentBG_Grad_out.pptx", SaveFormat.Pptx);
}
```

## **Establecer Imagen como Fondo para Diapositiva**

Además de los colores sólidos y los colores de degradado, Aspose.Slides también te permite establecer imágenes como fondo para las diapositivas en presentaciones.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Establece el enum [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) para la diapositiva en `OwnBackground`.
3. Establece el enum [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) para el fondo de la diapositiva maestra en `Picture`.
4. Carga la imagen que deseas usar como fondo de la diapositiva.
5. Agrega la imagen a la colección de imágenes de la presentación.
6. Utiliza la propiedad [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) expuesta por [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) para establecer la imagen como fondo.
7. Guarda la presentación modificada.

Este código C# te muestra cómo establecer una imagen como fondo para una diapositiva:

```c#
// Crea una instancia de la clase Presentation
using (Presentation pres = new Presentation("SetImageAsBackground.pptx"))
{
    // Establece condiciones para la imagen de fondo
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Picture;
    pres.Slides[0].Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Carga una imagen y la agrega a la colección de imágenes de la presentación
    IImage image = Images.FromFile("Tulips.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    pres.Slides[0].Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Escribe la presentación en disco
    pres.Save("ContentBG_Img_out.pptx", SaveFormat.Pptx);
}
```

### **Cambiar Transparencia de la Imagen de Fondo**

Puede que desees ajustar la transparencia de la imagen de fondo de una diapositiva para que el contenido de la diapositiva sea más prominente. Este código C# te muestra cómo cambiar la transparencia para una imagen de fondo de diapositiva:

```c#
var transparencyValue = 30; // por ejemplo

// Obtiene una colección de operaciones de transformación de imagen
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Encuentra un efecto de transparencia con un porcentaje fijo.
var transparencyOperation = null as AlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is AlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Establece el nuevo valor de transparencia.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```

## **Obtener Valor del Fondo de Diapositiva**

Aspose.Slides proporciona la interfaz [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) para permitirte obtener los valores efectivos de los fondos de las diapositivas. Esta interfaz contiene información sobre el [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat) efectivo y el [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/) efectivo.

Usando la propiedad [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/background/) de la clase [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/), puedes obtener el valor efectivo para el fondo de una diapositiva.

Este código C# te muestra cómo obtener el valor efectivo del fondo de una diapositiva:

```c#
// Crea una instancia de la clase Presentation
Presentation pres = new Presentation("SamplePresentation.pptx");

IBackgroundEffectiveData effBackground = pres.Slides[0].Background.GetEffective();

if (effBackground.FillFormat.FillType == FillType.Solid)
    Console.WriteLine("Color de relleno: " + effBackground.FillFormat.SolidFillColor);
else
    Console.WriteLine("Tipo de relleno: " + effBackground.FillFormat.FillType);
```