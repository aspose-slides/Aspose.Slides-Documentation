---
title: Gestionar maestros de diapositiva de presentación en .NET
linktitle: Maestro de diapositiva
type: docs
weight: 80
url: /es/net/slide-master/
keywords:
- maestro de diapositiva
- diapositiva maestra
- diapositiva maestra PPT
- varias diapositivas maestras
- comparar diapositivas maestras
- fondo
- marcador de posición
- clonar diapositiva maestra
- copiar diapositiva maestra
- duplicar diapositiva maestra
- diapositiva maestra no utilizada
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Gestionar maestros de diapositiva en Aspose.Slides para .NET: acceder, editar, clonar, comparar y eliminar diapositivas maestras en presentaciones PowerPoint y OpenDocument."
---
## **Visión general**

Un **maestro de diapositiva** define configuraciones de diseño compartidas para un grupo de diapositivas. Puede contener formas comunes, logotipos, fondos, estilos de texto, configuraciones de tema y de pie de página. En PowerPoint, editar un maestro de diapositiva es la forma habitual de mantener una presentación coherente sin repetir el mismo formato en cada diapositiva.

Aspose.Slides for .NET admite el mismo modelo. Una presentación puede contener una o más diapositivas maestras, y cada diapositiva maestra puede contener varias diapositivas de diseño. Las diapositivas normales no suelen referirse directamente a una diapositiva maestra. En su lugar, una diapositiva normal utiliza una diapositiva de diseño, y esa diapositiva de diseño pertenece a una diapositiva maestra.

La jerarquía es:

1. **Maestro de diapositiva** - define el diseño y tema compartidos.  
1. **Diapositiva de diseño** - define una disposición específica de marcadores de posición y formato a nivel de diseño.  
1. **Diapositiva normal** - contiene el contenido real de la presentación y utiliza una diapositiva de diseño.

![Jerarquía de maestros de diapositiva, diseños de diapositiva y diapositivas normales](slide-master_2.jpg)

En Aspose.Slides, un maestro de diapositiva está representado por la interfaz [IMasterSlide](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslide/). Todas las diapositivas maestras de una presentación están disponibles a través de la colección [Presentation.Masters](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/masters/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Cuando la misma propiedad se define en más de un nivel, gana el nivel más específico. Por ejemplo, si una diapositiva maestra y una diapositiva de diseño ambas definen un fondo, las diapositivas basadas en ese diseño usan el fondo del diseño. Para más información sobre diapositivas de diseño, vea [Aplicar o cambiar diseños de diapositiva](/slides/es/net/slide-layout/).
{{% /alert %}}

## **Acceder a los maestros de diapositiva**

En PowerPoint, puede abrir la vista Patrón de diapositiva desde **Ver** > **Patrón de diapositiva**.

![El comando Patrón de diapositiva en la pestaña Vista de PowerPoint](slide-master_3.jpg)

En Aspose.Slides, use la colección `Masters` para acceder a las diapositivas maestras:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

También puede obtener la diapositiva maestra utilizada por una diapositiva normal a través de su diseño:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Qué contiene un maestro de diapositiva**

Una diapositiva maestra es un objeto similar a una diapositiva. Implementa [IBaseSlide](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/), por lo que expone muchas de las mismas propiedades de diapositiva usadas por diapositivas normales y de diseño. Los miembros específicos del maestro se enumeran en la página de API [IMasterSlide](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslide/).

Los miembros de maestro de diapositiva más usados incluyen:

| Miembro | Propósito |
| --- | --- |
| `Background` | Establece el fondo de la diapositiva a nivel de maestro. |
| `Shapes` | Almacena las formas colocadas en el maestro, como logotipos, marcos de imagen y texto compartido. |
| `LayoutSlides` | Almacena las diapositivas de diseño que pertenecen al maestro. |
| `ThemeManager` | Proporciona acceso a las API de tema del maestro. |
| `HeaderFooterManager` | Controla encabezados, pies de página, fechas y números de diapositiva para el maestro y sus diseños hijos. |
| `GetDependingSlides` | Devuelve las diapositivas normales que dependen del maestro a través de sus diseños. |

## **Agregar una imagen a un maestro de diapositiva**

Al agregar una imagen a una diapositiva maestra, aparece en las diapositivas que usan diseños de ese maestro. Esto es útil para logotipos, marcas de agua, bandas decorativas y otros elementos visuales repetidos.

El siguiente ejemplo agrega un logotipo a la primera diapositiva maestra:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

Para más información sobre marcos de imagen, vea [Marco de imagen](/slides/es/net/picture-frame/).

## **Controlar la visibilidad de los gráficos del maestro**

Use [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/showmastershapes/) para ocultar los gráficos heredados del maestro, como logotipos o formas decorativas, sin eliminarlos del maestro. Establezca [Slide.ShowMasterShapes](https://reference.aspose.com/slides/es/net/aspose.slides/slide/showmastershapes/) a `false` en la diapositiva que debe omitir esos gráficos y manténgalo `true` en las diapositivas que deben mostrarlos.

El siguiente ejemplo autoconstruido crea una banda decorativa azul en un maestro y dos diapositivas que usan el mismo diseño en blanco. La banda es visible en la primera diapositiva y está oculta en la segunda. No se necesita una presentación de entrada ni una imagen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

El ejemplo usa el diseño **Blank** suministrado con una nueva presentación y elimina los marcadores de posición propios de la diapositiva inicial.

### **Elegir el alcance de la configuración**

Una diapositiva normal usa su maestro a través de [ISlide.LayoutSlide](https://reference.aspose.com/slides/es/net/aspose.slides/islide/layoutslide/) y [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/masterslide/). Establecer la propiedad en una diapositiva individual afecta solo a esa diapositiva. Establecer [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/es/net/aspose.slides/layoutslide/showmastershapes/) a `false` oculta los gráficos del maestro para todas las diapositivas que usan ese diseño compartido, aunque su propia configuración sea `true`. Para ocultar gráficos solo en una diapositiva, cambie la propiedad de la diapositiva y deje el diseño compartido sin modificar.

La configuración no se admite como control de visibilidad en la propia diapositiva maestra. En un maestro siempre devuelve `false`, y asignar `true` genera `NotSupportedException`. Aplíquelo a una diapositiva normal o a un diseño.

### **Distinguir los gráficos del fondo**

| Operación | Efecto |
| --- | --- |
| Ocultar los gráficos del maestro | controla la visibilidad de las formas heredadas del maestro sin eliminarlas ni cambiar las propias formas de la diapositiva. |
| Cambiar el relleno del fondo de la diapositiva | cambia el color, degradado o imagen de fondo. Los gráficos del maestro son formas separadas y pueden seguir visibles sobre ese fondo. Consulte [Presentation Background](/slides/es/net/presentation-background/). |
| Eliminar una forma del maestro | elimina la forma fuente compartida, de modo que ya no esté disponible para ninguna diapositiva que use ese maestro. |

## **Trabajar con marcadores de posición**

Los marcadores de posición se definen normalmente en las diapositivas de diseño. La diapositiva maestra proporciona el estilo y tema compartidos que esos diseños heredan, mientras que cada diseño decide qué marcadores están disponibles y dónde se colocan.

En PowerPoint, los comandos de marcador de posición están disponibles en la vista Patrón de diapositiva.

![El comando Insertar marcador de posición en la vista Patrón de diapositiva de PowerPoint](slide-master_5.png)

Para agregar nuevos marcadores de posición con Aspose.Slides, trabaje con la diapositiva de diseño que pertenece al maestro:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

También puede dar formato a las formas de marcador de posición que ya existen en una diapositiva maestra. El siguiente ejemplo busca el marcador de posición de título y le aplica un relleno de degradado lineal:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

Para más opciones de formato de marcadores y de texto, vea [Establecer texto de sugerencia en marcador de posición](/slides/es/net/manage-placeholder/) y [Formato de texto](/slides/es/net/text-formatting/).

## **Cambiar el fondo de un maestro de diapositiva**

Un fondo de maestro se hereda por los diseños y las diapositivas que no lo sobrescriben. El siguiente ejemplo establece un color de fondo sólido para la primera diapositiva maestra:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Para temas relacionados, vea [Presentation Background](/slides/es/net/presentation-background/) y [Presentation Theme](/slides/es/net/presentation-theme/).

## **Clonar un maestro de diapositiva a otra presentación**

Use [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslidecollection/addclone/) para copiar una diapositiva maestra a otra presentación. El maestro copiado puede entonces ser usado por diseños y diapositivas en la presentación de destino.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Si necesita clonar diapositivas normales junto con su maestro, vea [Clone Slides](/slides/es/net/clone-slides/).

## **Agregar varios maestros de diapositiva**

Una presentación puede contener varios maestros de diapositiva. Esto es útil cuando diferentes secciones requieren distintas marcas, estructuras de página o configuraciones de tema.

![Comandos de PowerPoint para insertar y gestionar maestros de diapositiva](slide-master_9.jpg)

El siguiente ejemplo clona el maestro predeterminado, le da al clon un fondo diferente, crea un diseño bajo ese maestro clonado y agrega una nueva diapositiva basada en ese diseño:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Comparar maestros de diapositiva**

Los maestros de diapositiva pueden compararse con el método `Equals` heredado de [IBaseSlide](https://reference.aspose.com/slides/es/net/aspose.slides/ibaseslide/). La comparación verifica la estructura y el contenido estático, como formas, texto, formato, animaciones y otras configuraciones de diapositiva. No compara identificadores únicos, como IDs de diapositiva, o valores dinámicos de marcadores, como la fecha actual.

```csharp
using Aspose.Slides;

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

Para más información, vea [Compare Presentation Slides](/slides/es/net/compare-slides/).

## **Establecer la vista de maestro de diapositiva como vista predeterminada**

Use la propiedad `LastView` en [ViewProperties](https://reference.aspose.com/slides/es/net/aspose.slides/viewproperties/) para controlar la vista que PowerPoint abre primero. El siguiente ejemplo abre la presentación en la vista Patrón de diapositiva:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Para más configuraciones de vista, vea [Save Presentation](/slides/es/net/save-presentation/).

## **Eliminar maestros de diapositiva no utilizados**

A veces las presentaciones contienen maestros de diapositiva que ya no son usados por ninguna diapositiva normal. Eliminar los maestros no utilizados puede reducir el tamaño del archivo y simplificar el mantenimiento de la plantilla.

Use [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/es/net/aspose.slides/masterslidecollection/removeunused/) para eliminar los maestros no utilizados de la colección `Masters`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

También puede usar el método de bajo código [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/compress/removeunusedmasterslides/):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**¿Cuál es la diferencia entre un maestro de diapositiva y una diapositiva de diseño?**

Un maestro de diapositiva define configuraciones de diseño compartidas como tema, fondo, formas comunes y estilos de texto. Una diapositiva de diseño pertenece a un maestro de diapositiva y define una disposición específica de marcadores de posición. Una diapositiva normal usa una diapositiva de diseño, por lo que hereda tanto del diseño como del maestro.

**¿Puede una presentación contener varios maestros de diapositiva?**

Sí. Una presentación puede contener varios maestros de diapositiva. Use varios maestros cuando diferentes secciones necesiten distintos sistemas visuales o de marca.

**¿Debo agregar marcadores de posición a un maestro de diapositiva o a una diapositiva de diseño?**

En la mayoría de los casos, agregue los marcadores de posición a las diapositivas de diseño. Coloque los elementos visuales compartidos y el formato común en el maestro de diapositiva y los marcadores de contenido en los diseños que usarán las diapositivas normales.

**¿Puedo eliminar un maestro de diapositiva que todavía se usa?**

No. Un maestro de diapositiva que tiene diapositivas dependientes no puede eliminarse de forma segura directamente. Primero mueva esas diapositivas a diseños bajo otro maestro, o use un método de limpieza de maestros no usados que elimine solo los maestros que no están en uso.