---
title: Diseño de Diapositivas
type: docs
weight: 60
url: /es/net/slide-layout/
keyword: "Establecer tamaño de diapositiva, configurar opciones de diapositiva, especificar tamaño de diapositiva, visibilidad del pie de página, pie de página secundario, escalado de contenido, tamaño de página, C#, Csharp, .NET, Aspose.Slides"
description: "Establecer el tamaño y las opciones de diapositivas de PowerPoint en C# o .NET"
---

Un diseño de diapositiva contiene los cuadros de marcador de posición y la información de formato para todo el contenido que aparece en una diapositiva. El diseño determina los marcadores de posición de contenido disponibles y dónde se colocan.

Los diseños de diapositivas permiten crear y diseñar presentaciones rápidamente (ya sean simples o complejas). Estos son algunos de los diseños de diapositivas más populares utilizados en presentaciones de PowerPoint: 

* **Diseño de Diapositiva de Título**. Este diseño consta de dos marcadores de posición de texto. Un marcador de posición es para el título y el otro es para el subtítulo. 
* **Diseño de Título y Contenido**. Este diseño contiene un marcador de posición relativamente pequeño en la parte superior para el título y un marcador de posición más grande para el contenido principal (gráfico, párrafos, lista con viñetas, lista numerada, imágenes, etc).
* **Diseño en Blanco**. Este diseño carece de marcadores de posición, por lo que permite crear elementos desde cero.

Dado que un maestro de diapositivas es la diapositiva jerárquica superior que almacena información sobre diseños de diapositivas, puede usar la diapositiva maestra para acceder a los diseños de diapositivas y realizarlos. Un diseño de diapositiva se puede acceder por tipo o nombre. De manera similar, cada diapositiva tiene un id único, que se puede utilizar para acceder a ella.

Alternativamente, puede realizar cambios directamente en un diseño de diapositiva específico en una presentación.

* Para permitirle trabajar con diseños de diapositivas (incluidos los de las diapositivas maestras), Aspose.Slides proporciona propiedades como [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) y [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) bajo la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
* Para realizar tareas relacionadas, Aspose.Slides proporciona [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/baseslideheaderfootermanager/), y muchos otros tipos.

{{% alert title="Info" color="info" %}}

Para obtener más información sobre cómo trabajar con Diapositivas Maestras en particular, consulte el artículo [Slide Master](https://docs.aspose.com/slides/net/slide-master/).

{{% /alert %}}

## **Agregar Diseño de Diapositiva a la Presentación**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. Acceda a la [colección MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/).
1. Recorrer los diseños de diapositivas existentes para confirmar que el diseño de diapositiva requerido ya existe en la colección de Diseño de Diapositivas. De lo contrario, agregue el diseño de diapositiva que desea. 
1. Agregue una diapositiva vacía basada en el nuevo diseño de diapositiva.
1. Guarde la presentación.

Este código C# le muestra cómo agregar un diseño de diapositiva a una presentación de PowerPoint:

```c#
// Instancia una clase Presentation que representa el archivo de presentación
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // Recorre los tipos de diapositivas de diseño
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // La situación donde una presentación no contiene algunos tipos de diseño.
        // El archivo de presentación solo contiene tipos de diseño en blanco y personalizados.
        // Pero las diapositivas de diseño con tipos personalizados tienen diferentes nombres de diapositivas,
        // como "Título", "Título y Contenido", etc. Y es posible utilizar estos
        // nombres para la selección de la diapositiva de diseño.
        // También puede usar un conjunto de tipos de forma de marcador de posición. Por ejemplo,
        // La diapositiva de título debe tener solo el tipo de marcador de posición Título, etc.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Título y Objeto")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Título")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Título y Objeto");
                }
            }
        }
    }

    // Agrega una diapositiva vacía con el diseño agregado
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Guarda la presentación en el disco  
    presentation.Save("AddLayoutSlides_out.pptx", SaveFormat.Pptx);
}
```

## **Eliminar Diseño de Diapositiva No Utilizado**

Aspose.Slides proporciona el método [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) de la clase [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) para permitirle eliminar diapositivas de diseño no deseadas y no utilizadas. Este código C# le muestra cómo eliminar un diseño de diapositiva de una presentación de PowerPoint:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Establecer Tamaño y Tipo para Diseño de Diapositiva**

Para permitirle establecer el tamaño y tipo para un diseño de diapositiva específico, Aspose.Slides proporciona las propiedades [Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/type) y [Size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/properties/size) (de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)). Este C# demuestra la operación:

```c#
// Instancia un objeto Presentation que representa un archivo de presentación 
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Establece el tamaño de diapositivas para la presentación generada al de la fuente
auxPresentation.SlideSize.SetSize(presentation.SlideSize.Type,SlideSizeScaleType.EnsureFit);

auxPresentation.Slides.InsertClone(0, slide);
auxPresentation.Slides.RemoveAt(0);
// Guarda la presentación en el disco
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **Establecer Visibilidad del Pie de Página Dentro de la Diapositiva**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenga la referencia de una diapositiva a través de su índice.
1. Establezca el marcador de posición del pie de página de la diapositiva como visible. 
1. Establezca el marcador de posición de fecha y hora como visible. 
1. Guarde la presentación. 

Este código C# le muestra cómo establecer la visibilidad para un pie de página de la diapositiva (y realizar tareas relacionadas):

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IBaseSlideHeaderFooterManager headerFooterManager = presentation.Slides[0].HeaderFooterManager;
    if (!headerFooterManager.IsFooterVisible) // La propiedad IsFooterVisible se usa para especificar que falta un marcador de posición de pie de página de la diapositiva
    {
        headerFooterManager.SetFooterVisibility(true); // El método SetFooterVisibility se usa para establecer un marcador de posición de pie de página de la diapositiva como visible
    }
    if (!headerFooterManager.IsSlideNumberVisible) // La propiedad IsSlideNumberVisible se usa para especificar que falta un marcador de posición de número de página de la diapositiva
    {
        headerFooterManager.SetSlideNumberVisibility(true); // El método SetSlideNumberVisibility se usa para establecer un marcador de posición de número de página de la diapositiva como visible
    }
    if (!headerFooterManager.IsDateTimeVisible) // La propiedad IsDateTimeVisible se usa para especificar que falta un marcador de posición de fecha y hora de la diapositiva
    {
        headerFooterManager.SetDateTimeVisibility(true); // El método SetFooterVisibility se usa para establecer un marcador de posición de fecha y hora de la diapositiva como visible
    }
    headerFooterManager.SetFooterText("Texto del pie de página"); // El método SetFooterText se usa para establecer un texto para un marcador de posición de pie de página de la diapositiva
    headerFooterManager.SetDateTimeText("Texto de fecha y hora"); // El método SetDateTimeText se usa para establecer un texto para un marcador de posición de fecha y hora de la diapositiva.

	presentation.Save("Presentation.ppt",SaveFormat.ppt);
}
```

## **Establecer Visibilidad del Pie de Página Secundario Dentro de la Diapositiva**

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class.
1. Obtenga una referencia para la diapositiva maestra a través de su índice. 
1. Establezca la diapositiva maestra y todos los marcadores de posición de pie de página secundarios como visibles.
1. Establezca un texto para la diapositiva maestra y todos los marcadores de posición de pie de página secundarios. 
1. Establezca un texto para la diapositiva maestra y todos los marcadores de posición de fecha y hora secundarios. 
1. Guarde la presentación. 

Este código C# demuestra la operación:

```c#
using (Presentation presentation = new Presentation("presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;
    headerFooterManager.SetFooterAndChildFootersVisibility(true); // El método SetFooterAndChildFootersVisibility se usa para establecer que el pie de página de la diapositiva maestra y todos los marcadores de posición de pie de página secundarios sean visibles
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // El método SetSlideNumberAndChildSlideNumbersVisibility se usa para establecer que el número de página de la diapositiva maestra y todos los marcadores de posición de número de página secundarios sean visibles
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // El método SetDateTimeAndChildDateTimesVisibility se usa para establecer que la diapositiva maestra y todos los marcadores de posición de fecha y hora secundarios sean visibles

    headerFooterManager.SetFooterAndChildFootersText("Texto del pie de página"); // El método SetFooterAndChildFootersText se usa para establecer textos para la diapositiva maestra y todos los marcadores de posición de pie de página secundarios
    headerFooterManager.SetDateTimeAndChildDateTimesText("Texto de fecha y hora"); // El método SetDateTimeAndChildDateTimesText se usa para establecer texto para la diapositiva maestra y todos los marcadores de posición de fecha y hora secundarios
}
```

## **Establecer Tamaño de Diapositiva con Respecto al Escalado del Contenido**

1. Cree una instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class y cargue la presentación que contiene la diapositiva cuyo tamaño desea establecer. 
1. Cree otra instancia de la [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class para generar una nueva presentación. 
1. Obtenga la referencia de la diapositiva (de la primera presentación) a través de su índice.
1. Establezca el marcador de posición del pie de página de la diapositiva como visible. 
1. Establezca el marcador de posición de fecha y hora como visible. 
1. Guarde la presentación. 

Este C# demuestra la operación: 

```c#
// Instancia un objeto Presentation que representa un archivo de presentación 
Presentation presentation = new Presentation("AccessSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

// Establece el tamaño de diapositivas para las presentaciones generadas al de la fuente
presentation.SlideSize.SetSize(540, 720, SlideSizeScaleType.EnsureFit); // El método SetSize se usa para establecer el tamaño de la diapositiva con escalado de contenido para asegurar ajuste
presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.Maximize); // El método SetSize se usa para establecer el tamaño de la diapositiva con el tamaño máximo de contenido
           
// Guarda la presentación en el disco
auxPresentation.Save("Set_Size&Type_out.pptx", SaveFormat.Pptx);
```

## **Establecer Tamaño de Página al Generar PDF**

Ciertas presentaciones (como carteles) a menudo se convierten en documentos PDF. Si está buscando convertir su PowerPoint a PDF para acceder a las mejores opciones de impresión y accesibilidad, desea establecer sus diapositivas en tamaños que se adapten a documentos PDF (A4, por ejemplo).

Aspose.Slides proporciona la clase [SlideSize](https://reference.aspose.com/slides/net/aspose.slides/slidesize/) para permitirle especificar sus ajustes preferidos para las diapositivas. Este código C# le muestra cómo usar la propiedad [Type](https://reference.aspose.com/slides/net/aspose.slides/slidesize/type/) (de la clase `SlideSize`) para establecer un tamaño de papel específico para las diapositivas en una presentación:

```c#
// Instancia un objeto Presentation que representa un archivo de presentación 
Presentation presentation = new Presentation();

// Establece la propiedad SlideSize.Type 
presentation.SlideSize.SetSize(SlideSizeType.A4Paper,SlideSizeScaleType.EnsureFit);

// Establece diferentes propiedades para Opciones de PDF
PdfOptions opts = new  PdfOptions();
opts.SufficientResolution = 600;

// Guarda la presentación en el disco
presentation.Save("SetPDFPageSize_out.pdf", SaveFormat.Pdf, opts);
```