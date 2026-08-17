---
title: Aplicar o cambiar diseños de diapositiva en .NET
linktitle: Diseño de diapositiva
type: docs
weight: 60
url: /es/net/slide-layout/
keywords:
- diseño de diapositiva
- diseño de contenido
- marcador de posición
- diseño de presentación
- diseño de diapositiva
- diseño sin usar
- visibilidad del pie de página
- diapositiva de título
- título y contenido
- encabezado de sección
- dos contenidos
- comparación
- solo título
- diseño en blanco
- contenido con leyenda
- imagen con leyenda
- título y texto vertical
- título vertical y texto
- PowerPoint
- OpenDocument
- presentación
- C#
- .NET
- Aspose.Slides
description: "Aplicar, crear y modificar diseños de diapositiva en Aspose.Slides para .NET, añadir marcadores de posición, eliminar diseños sin usar y controlar la visibilidad del pie de página."
---
## **Visión general**

Un diseño de diapositiva define las posiciones y el formato de los marcadores de posición, como títulos, texto, imágenes, gráficos y tablas. Aplicar un diseño otorga a las diapositivas una estructura coherente mientras permite que cada una contenga su propio contenido.

Los diseños más comunes son:

- **Diapositiva de título**: contiene marcadores de posición para el título y el subtítulo.
- **Título y contenido**: contiene un marcador de posición para el título y otro de contenido de uso general.
- **En blanco**: no contiene marcadores de posición y es útil cuando cada forma se posicionará manualmente.

## **Comprender la herencia de diseños**

Una presentación tiene tres niveles relacionados:

1. Una [diapositiva maestra](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslide/) define el tema, el formato compartido, los fondos y los objetos comunes.
1. Una [diapositiva de diseño](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/) pertenece a una maestra y define una disposición concreta de marcadores de posición.
1. Una [diapositiva normal](https://reference.aspose.com/slides/es/net/aspose.slides/islide/) utiliza un diseño y almacena el contenido introducido para esa diapositiva.

Una diapositiva normal hereda el tema y el formato de su diseño, y el diseño hereda de su maestra. Un valor establecido directamente en una diapositiva normal anula el valor heredado en ese nivel. Cuando se crea una diapositiva normal, sus formas de marcador de posición se generan a partir del diseño seleccionado, mientras que el contenido introducido en esos marcadores pertenece a la diapositiva normal.

Añada los marcadores de posición requeridos a un diseño antes de crear diapositivas a partir de él. Añadir otro marcador de posición a un diseño más tarde no añade automáticamente una forma correspondiente a las diapositivas normales existentes.

Esta relación tiene dos consecuencias importantes:

- Cambiar el formato heredado o la geometría de los marcadores de posición existentes en un diseño puede actualizar todas las diapositivas que dependen de él. Antes de editar un diseño que ya está en uso, inspeccione sus diapositivas dependientes y revise la presentación resultante.
- Un diseño que aún está siendo usado por una diapositiva no puede eliminarse. Reasigne primero sus diapositivas dependientes a otro diseño, o elimine solo los diseños que no se utilizan.

Para obtener más información sobre el nivel superior de esta jerarquía, consulte [Slide Master](/slides/es/net/slide-master/).

## **Seleccionar y aplicar un diseño de diapositiva**

Utilice un tipo de diseño cuando la presentación sigue las definiciones estándar de diseños de PowerPoint. Los nombres de los diseños son editables por el usuario y pueden localizarse, por lo que la selección basada en el nombre es menos fiable a menos que controle la plantilla de origen.

El siguiente ejemplo busca **Título y contenido** en la primera maestra. Si ese diseño no está disponible, recurre deliberadamente a **En blanco**. La segunda comprobación de nulo es necesaria porque una presentación puede contener solo diseños personalizados. El diseño seleccionado se aplica entonces a la primera diapositiva normal mediante la propiedad [ISlide.LayoutSlide](https://reference.aspose.com/slides/es/net/aspose.slides/islide/layoutslide/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

Cambiar el diseño de una diapositiva no elimina las formas ordinarias añadidas directamente a la diapositiva. Sin embargo, las posiciones de los marcadores de posición, el formato heredado y la correspondencia entre los marcadores existentes y el nuevo diseño pueden variar, por lo que debe inspeccionar la salida al cambiar entre diseños sustancialmente diferentes.

## **Añadir una diapositiva de diseño**

La selección y la creación son operaciones separadas. El ejemplo anterior selecciona un diseño existente; no lo crea. Para crear un diseño, llame al método [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/es/net/aspose.slides/masterlayoutslidecollection/add/) de la colección de diseños de la maestra objetivo.

El siguiente ejemplo siempre añade un nuevo diseño **Título y contenido** llamado `Report Title and Content`, y luego añade una diapositiva normal basada en él. Los nombres de los diseños deben ser únicos dentro de la colección.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Añada un diseño solo cuando la plantilla realmente necesite otra estructura reutilizable. Si ya existe un diseño adecuado, selecciónelo y reutilícelo en lugar de crear un duplicado.

## **Añadir marcadores de posición a una diapositiva de diseño**

La propiedad [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/placeholdermanager/) proporciona un [ILayoutPlaceholderManager](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutplaceholdermanager/) para añadir formas de marcador de posición a un diseño.

| Marcador de posición de PowerPoint | Método `ILayoutPlaceholderManager` |
| ----------------------------------- | ----------------------------------- |
| ![Content](content.png)             | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Content (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Text](text.png)                   | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Text (Vertical)](textV.png)       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Picture](picture.png)             | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Chart](chart.png)                 | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Table](table.png)                 | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Media](media.png)                 | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Online Image](onlineImage.png)    | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

El siguiente ejemplo verifica que el diseño **En blanco** exista, añade cuatro marcadores de posición a él y luego crea una diapositiva normal que utiliza el diseño modificado. El orden es intencional: los marcadores de posición se añaden antes de crear la diapositiva normal, de modo que Aspose.Slides pueda generar las formas de marcador correspondientes en esa diapositiva.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

El resultado:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}

Cambiar el formato heredado o la geometría de los marcadores de posición existentes en un diseño puede afectar a las diapositivas dependientes. Un marcador de posición añadido recientemente no se retro‑rellena en las diapositivas normales existentes. Pruebe los cambios de diseño en una copia de la presentación e inspeccione cada diapositiva dependiente.

{{% /alert %}}

## **Eliminar diseños de diapositiva no usados**

Utilice el método [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) para eliminar los diseños a los que ninguna diapositiva normal hace referencia. El método deja intactos los diseños que siguen en uso.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Para eliminar un diseño específico, primero use su propiedad [HasDependingSlides](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/hasdependingslides/) o el método [GetDependingSlides](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/getdependingslides/). Reasigne cualquier diapositiva dependiente antes de llamar a [ILayoutSlide.Remove](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/remove/). Intentar eliminar un diseño en uso lanza una [PptxEditException](https://reference.aspose.com/slides/es/net/aspose.slides/pptxeditexception/).

## **Controlar la visibilidad del pie de página en una diapositiva de diseño**

Un diseño tiene sus propios marcadores de posición de pie de página, número de diapositiva y fecha/hora. Utilice la propiedad [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/headerfootermanager/) para controlar esos marcadores en un diseño. Esto es útil cuando, por ejemplo, los diseños de contenido deben mostrar pies de página y los diseños de título no.

El siguiente ejemplo selecciona un diseño de forma segura y hace visibles sus elementos de pie de página:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **Controlar la visibilidad del pie de página en una maestra y sus diseños hijos**

Para aplicar configuraciones de pie de página coherentes en toda la jerarquía de la maestra, utilice la propiedad [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslide/headerfootermanager/). Los métodos de propagación de [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslideheaderfootermanager/) actúan sobre la maestra y sus diseños y diapositivas normales; no se aplican solo a una diapositiva normal.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una diapositiva maestra y una diapositiva de diseño?**

Una diapositiva maestra define el tema y el formato compartido de la presentación. Una diapositiva de diseño pertenece a una maestra y define una disposición reutilizable de marcadores de posición. Las diapositivas normales usan esos diseños y almacenan el contenido específico de cada diapositiva.

**¿Puedo copiar una diapositiva de diseño de una presentación a otra?**

Sí. Añada una copia a la colección de destino con el método [AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/globallayoutslidecollection/addclone/). Al copiar entre presentaciones, también compruebe fuentes, temas, imágenes y otros recursos utilizados por el diseño de origen.

**¿Qué ocurre si modifico un diseño que ya está en uso?**

Las diapositivas dependientes heredan los cambios del diseño, a menos que anulen localmente el formato o los objetos afectados. Por ello, la geometría de los marcadores y el estilo heredado pueden cambiar en muchas diapositivas a la vez. Utilice [GetDependingSlides](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/getdependingslides/) para identificar las diapositivas afectadas antes de editar el diseño.

**¿Qué ocurre si elimino un diseño que sigue en uso?**

Aspose.Slides lanza una [PptxEditException](https://reference.aspose.com/slides/es/net/aspose.slides/pptxeditexception/). Reasigne primero las diapositivas dependientes o use [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) para eliminar solo los diseños no referenciados.