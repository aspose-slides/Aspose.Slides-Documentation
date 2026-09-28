---
title: Aplicar o cambiar diseños de diapositivas en .NET
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
- diseño no utilizado
- visibilidad del pie de página
- diapositiva de título
- título y contenido
- encabezado de sección
- dos contenidos
- comparación
- solo título
- diseño en blanco
- contenido con subtítulo
- imagen con subtítulo
- título y texto vertical
- título vertical y texto
- PowerPoint
- OpenDocument
- presentación
- C#
- .NET
- Aspose.Slides
description: "Aplicar, crear y modificar diseños de diapositivas en Aspose.Slides para .NET, añadir marcadores de posición, eliminar diseños no utilizados y controlar la visibilidad del pie de página."
---
## **Resumen**

Un diseño de diapositiva define las posiciones y el formato de los marcadores de posición, como títulos, texto, imágenes, gráficos y tablas. Aplicar un diseño brinda a las diapositivas una estructura coherente mientras permite que cada diapositiva contenga su propio contenido.

Los diseños más comunes incluyen:

- **Diapositiva de título**: Contiene marcadores de posición de título y subtítulo.
- **Título y contenido**: Contiene un marcador de posición de título y un marcador de posición de contenido de uso general.
- **En blanco**: No contiene marcadores de posición de contenido y es útil cuando cada forma se posicionará manualmente.

## **Entender la herencia de diseños**

Una presentación tiene tres niveles relacionados:

1. Una [diapositiva maestra](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslide/) define el tema, el formato compartido, los fondos y los objetos comunes.
2. Una [diapositiva de diseño](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/) pertenece a una maestra y define una disposición específica de marcadores de posición.
3. Una [diapositiva normal](https://reference.aspose.com/slides/es/net/aspose.slides/islide/) usa un diseño y almacena el contenido introducido para esa diapositiva.

Una diapositiva normal hereda el tema y el formato de su diseño, y el diseño hereda de su maestra. Un valor establecido directamente en una diapositiva normal sobrescribe el valor heredado en ese nivel. Cuando se crea una diapositiva normal, sus formas de marcador de posición se generan a partir del diseño seleccionado, mientras que el contenido introducido en esos marcadores pertenece a la diapositiva normal.

Añada los marcadores de posición necesarios a un diseño antes de crear diapositivas a partir de él. Añadir otro marcador de posición a un diseño posteriormente no añade automáticamente una forma de marcador correspondiente a las diapositivas normales existentes.

Esta relación tiene dos consecuencias importantes:

- Cambiar el formato heredado o la geometría de los marcadores de posición existentes en un diseño puede actualizar todas las diapositivas que dependen de él. Antes de editar un diseño que ya está en uso, inspeccione sus diapositivas dependientes y revise la presentación resultante.
- Un diseño que sigue siendo usado por alguna diapositiva no puede eliminarse. Reasigne sus diapositivas dependientes a otro diseño primero, o elimine solo los diseños no utilizados.

Para obtener más información sobre el nivel superior de esta jerarquía, consulte [Slide Master](/slides/es/net/slide-master/).

Para ocultar logotipos heredados o formas decorativas de la maestra en una diapositiva o mediante un diseño compartido, vea [Control the Visibility of Master Graphics](/slides/es/net/slide-master/). El ejemplo compara dos diapositivas que utilizan la misma maestra.

## **Seleccionar y aplicar un diseño de diapositiva**

Utilice un tipo de diseño cuando la presentación siga las definiciones estándar de diseños de PowerPoint. Los nombres de los diseños son editables por el usuario y pueden localizarse, por lo que la selección basada en el nombre es menos fiable a menos que controle la plantilla de origen.

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

Cambiar el diseño de una diapositiva no elimina las formas ordinarias añadidas directamente a la diapositiva. Sin embargo, las posiciones de los marcadores, el formato heredado y la correspondencia entre los marcadores existentes y el nuevo diseño pueden cambiar, por lo que se debe inspeccionar la salida al alternar entre diseños sustancialmente diferentes.

## **Añadir una diapositiva de diseño**

La selección y la creación son operaciones separadas. El ejemplo anterior selecciona un diseño existente; no lo crea. Para crear un diseño, llame al método [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/es/net/aspose.slides/masterlayoutslidecollection/add/) de la colección de diseños de la maestra de destino.

El siguiente ejemplo siempre añade un nuevo diseño **Título y contenido** llamado `Report Title and Content`, y después añade una diapositiva normal basada en él. Los nombres de los diseños deben ser únicos dentro de la colección.

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

| Marcador de posición de PowerPoint | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![Contenido](content.png)           | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Contenido (vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Texto](text.png)                  | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Texto (vertical)](textV.png)      | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Imagen](picture.png)              | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Gráfico](chart.png)               | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Tabla](table.png)                 | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Medios](media.png)                | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Imagen en línea](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/es/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

El siguiente ejemplo verifica que el diseño **En blanco** exista, añade cuatro marcadores de posición a él y después crea una diapositiva normal que usa el diseño modificado. El orden es intencional: los marcadores se añaden antes de crear la diapositiva normal, de modo que Aspose.Slides pueda generar las formas de marcador correspondientes en esa diapositiva.

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

![Los marcadores de posición en la diapositiva de diseño](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Cambiar el formato heredado o la geometría de los marcadores de posición existentes en un diseño puede afectar a las diapositivas dependientes. Un marcador de posición añadido recientemente no se retro‑pobla en las diapositivas normales existentes. Pruebe los cambios de diseño en una copia de la presentación e inspeccione cada diapositiva dependiente.
{{% /alert %}}

## **Eliminar diapositivas de diseño no utilizadas**

Utilice el método [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) para eliminar los diseños a los que ninguna diapositiva normal hace referencia. El método deja intactos los diseños que siguen en uso.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Para eliminar un diseño concreto, primero use su propiedad [HasDependingSlides](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/hasdependingslides/) o el método [GetDependingSlides](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/getdependingslides/). Reasigne cualquier diapositiva dependiente antes de llamar a [ILayoutSlide.Remove](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/remove/). Intentar eliminar un diseño en uso genera una [PptxEditException](https://reference.aspose.com/slides/es/net/aspose.slides/pptxeditexception/).

## **Controlar la visibilidad del pie de página en una diapositiva de diseño**

Un diseño tiene sus propios marcadores de pie de página, número de diapositiva y fecha/hora. Utilice la propiedad [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/headerfootermanager/) para controlar esos marcadores en un diseño. Es útil cuando, por ejemplo, los diseños de contenido deben mostrar pies de página pero los diseños de título no.

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

## **Controlar la visibilidad del pie de página en una maestra y sus diseños secundarios**

Para aplicar configuraciones de pie de página consistentes en toda la jerarquía de una maestra, utilice la propiedad [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslide/headerfootermanager/). Los métodos de propagación de [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/es/net/aspose.slides/imasterslideheaderfootermanager/) actúan sobre la maestra y sus diapositivas de diseño y normales dependientes; no están dirigidos a una sola diapositiva normal.

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

Una diapositiva maestra define el tema y el formato compartido de la presentación. Una diapositiva de diseño pertenece a una maestra y define una disposición reutilizable de marcadores de posición. Las diapositivas normales utilizan esos diseños y almacenan el contenido específico de cada diapositiva.

**¿Puedo copiar una diapositiva de diseño de una presentación a otra?**

Sí. Añada una copia a la colección de destino con el método [AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/globallayoutslidecollection/addclone/). Al copiar entre presentaciones, también verifique fuentes, temas, imágenes y otros recursos usados por el diseño de origen.

**¿Qué ocurre cuando modifico un diseño que ya está en uso?**

Las diapositivas dependientes heredan los cambios del diseño salvo que sobrescriban localmente el formato u objetos afectados. La geometría de los marcadores y el estilo heredado pueden cambiar en muchas diapositivas a la vez. Use [GetDependingSlides](https://reference.aspose.com/slides/es/net/aspose.slides/ilayoutslide/getdependingslides/) para identificar las diapositivas afectadas antes de editar el diseño.

**¿Qué ocurre si elimino un diseño que aún está en uso?**

Aspose.Slides lanza una [PptxEditException](https://reference.aspose.com/slides/es/net/aspose.slides/pptxeditexception/). Reasigne primero las diapositivas dependientes, o utilice [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) para eliminar solo los diseños no referenciados.