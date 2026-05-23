---
title: Gestionar maestros de diapositivas de presentación en .NET
linktitle: Maestro de diapositiva
type: docs
weight: 80
url: /es/net/slide-master/
keywords:
- maestro de diapositiva
- diapositiva maestra
- diapositiva maestra PPT
- múltiples maestros de diapositivas
- comparar maestros de diapositivas
- fondo
- marcador de posición
- clonar diapositiva maestra
- copiar diapositiva maestra
- duplicar diapositiva maestra
- maestro de diapositiva sin usar
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Gestiona los maestros de diapositivas en Aspose.Slides para .NET: accede, edita, clona, compara y elimina maestros de diapositivas en presentaciones PowerPoint y OpenDocument."
---
## **Visión general**

Un **maestro de diapositivas** define ajustes de diseño compartidos para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, ajustes de tema y ajustes de pie de página. En PowerPoint, editar un maestro de diapositivas es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides para .NET admite el mismo modelo. Una presentación puede contener una o más diapositivas maestras, y cada diapositiva maestra puede contener varias diapositivas de diseño. Las diapositivas normales no suelen referirse directamente a una diapositiva maestra. En su lugar, una diapositiva normal usa una diapositiva de diseño, y esa diapositiva de diseño pertenece a una diapositiva maestra.

La jerarquía es:

1. **Maestro de diapositiva** - define el diseño y tema compartidos.  
1. **Diapositiva de diseño** - define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Diapositiva normal** - contiene el contenido real de la presentación y usa una diapositiva de diseño.

![La jerarquía de los maestros de diapositivas, diapositivas de diseño y diapositivas normales](slide-master_2.jpg)

En Aspose.Slides, un maestro de diapositivas está representado por la interfaz [IMasterSlide](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslide/). Todos los maestros de diapositivas de una presentación están disponibles a través de la colección [Presentation.Masters](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/masters/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Cuando la misma propiedad se define en más de un nivel, el nivel más específico gana. Por ejemplo, si una diapositiva maestra y una diapositiva de diseño ambas definen un fondo, las diapositivas basadas en ese diseño usan el fondo del diseño. Para obtener más información sobre las diapositivas de diseño, consulte [Apply or Change Slide Layouts](/slides/es/net/slide-layout/).
{{% /alert %}}

## **Acceso a maestros de diapositivas**

En PowerPoint, puedes abrir la vista de Maestro de diapositivas desde **View** > **Slide Master**.

![El comando Maestro de diapositivas en la pestaña Vista de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, use la colección `Masters` para acceder a los maestros de diapositivas:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

También puede obtener la diapositiva maestra usada por una diapositiva normal a través de su diseño:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Qué contiene un maestro de diapositivas**

Una diapositiva maestra es un objeto similar a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/), por lo que expone muchas de las mismas propiedades de diapositiva utilizadas por diapositivas normales y de diseño. Los miembros específicos del maestro se enumeran en la página de API [IMasterSlide](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslide/).

Los miembros del maestro de diapositivas más utilizados incluyen:

| Miembro | Propósito |
| --- | --- |
| `Background` | Establece el fondo a nivel de maestro. |
| `Shapes` | Almacena las formas colocadas en el maestro, como logotipos, marcos de imagen y texto compartido. |
| `LayoutSlides` | Almacena las diapositivas de diseño que pertenecen al maestro. |
| `ThemeManager` | Proporciona acceso a las API de tema del maestro. |
| `HeaderFooterManager` | Controla encabezados, pies de página, fechas y números de diapositiva para el maestro y sus diseños secundarios. |
| `GetDependingSlides` | Devuelve las diapositivas normales que dependen del maestro a través de sus diseños. |

## **Añadir una imagen a un maestro de diapositivas**

Cuando añades una imagen a una diapositiva maestra, aparece en las diapositivas que usan diseños de ese maestro. Esto es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo añade un logotipo a la primera diapositiva maestra:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

Para obtener más información sobre los marcos de imagen, consulte [Picture Frame](/slides/es/net/picture-frame/).

## **Trabajar con marcadores de posición**

Los marcadores de posición se definen normalmente en las diapositivas de diseño. La diapositiva maestra proporciona el estilo y tema compartidos que esos diseños heredan, mientras que cada diseño decide qué marcadores están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista Maestro de diapositivas.

![El comando Insertar marcador de posición en la vista Maestro de diapositivas de PowerPoint](slide-master_5.png)

Para añadir nuevos marcadores de posición con Aspose.Slides, trabaje con la diapositiva de diseño que pertenece al maestro:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

También puede dar formato a las formas de marcador de posición que ya existen en una diapositiva maestra. El siguiente ejemplo encuentra el marcador de posición de título y le aplica un relleno de degradado lineal:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Marcador de posición de título formateado heredado por diapositivas normales](slide-master_8.png)

Para obtener más opciones de formato de marcadores y de texto, consulte [Set Prompt Text in Placeholder](/slides/es/net/manage-placeholder/) y [Text Formatting](/slides/es/net/text-formatting/).

## **Cambiar el fondo de un maestro de diapositivas**

Un fondo de maestro se hereda por los diseños y diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera diapositiva maestra:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Para temas relacionados, consulte [Presentation Background](/slides/es/net/presentation-background/) y [Presentation Theme](/slides/es/net/presentation-theme/).

## **Clonar un maestro de diapositivas a otra presentación**

Use [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslidecollection/addclone/) para copiar una diapositiva maestra a otra presentación. El maestro copiado puede entonces ser usado por los diseños y diapositivas en la presentación de destino.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Si necesita clonar diapositivas normales junto con su maestro, consulte [Clone Slides](/slides/es/net/clone-slides/).

## **Añadir varios maestros de diapositivas**

Una presentación puede contener varios maestros de diapositivas. Esto es útil cuando diferentes secciones requieren distintas marcas, estructuras de página o ajustes de tema.

![Comandos de PowerPoint para insertar y gestionar maestros de diapositivas](slide-master_9.jpg)

El siguiente ejemplo clona el maestro predeterminado, asigna al clon un fondo diferente, crea un diseño bajo ese maestro clonado y añade una nueva diapositiva basada en ese diseño:

```csharp
using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **Comparar maestros de diapositivas**

Los maestros de diapositivas pueden compararse con el método `Equals` heredado de [IBaseSlide](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otras configuraciones de diapositiva. No compara identificadores únicos, como los IDs de diapositiva, ni valores dinámicos de marcadores, como la fecha actual.

```csharp
using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

Para más información, consulte [Compare Presentation Slides](/slides/es/net/compare-slides/).

## **Establecer la vista de maestro de diapositivas como vista predeterminada**

Use la propiedad `LastView` en [ViewProperties](https://reference.aspose.com/slides/es/net/aspose.slides/viewproperties/) para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Maestro de diapositivas:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Para más configuraciones de vista, consulte [Save Presentation](/slides/es/net/save-presentation/).

## **Eliminar maestros de diapositivas no utilizados**

Las presentaciones a veces contienen maestros de diapositivas que ya no son usados por ninguna diapositiva normal. Eliminar maestros no utilizados puede reducir el tamaño del archivo y simplificar el mantenimiento de la plantilla.

Use [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/es/net/aspose.slides/masterslidecollection/removeunused/) para eliminar los maestros no utilizados de la colección `Masters`:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

También puede usar el método de bajo código [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un maestro de diapositivas y una diapositiva de diseño?**

Un maestro de diapositivas define ajustes de diseño compartidos como tema, fondo, formas comunes y estilos de texto. Una diapositiva de diseño pertenece a un maestro de diapositivas y define una disposición específica de marcadores de posición. Una diapositiva normal usa una diapositiva de diseño, por lo que hereda tanto del diseño como del maestro.

**¿Puede una presentación contener varios maestros de diapositivas?**

Sí. Una presentación puede contener varios maestros de diapositivas. Utilice varios maestros cuando diferentes secciones necesiten sistemas visuales o marcas distintas.

**¿Debo añadir marcadores de posición a un maestro de diapositivas o a una diapositiva de diseño?**

En la mayoría de los casos, añada marcadores de posición a las diapositivas de diseño. Coloque los elementos visuales compartidos y el formato común en el maestro de diapositivas, y luego coloque los marcadores de contenido en los diseños que usarán las diapositivas normales.

**¿Puedo eliminar un maestro de diapositivas que aún está en uso?**

No. Un maestro de diapositivas que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueva esas diapositivas a diseños bajo otro maestro, o utilice un método de limpieza de maestros no usados que elimine solo los maestros que no están en uso.