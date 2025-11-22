---
title: Aplicar o cambiar un diseño de diapositiva en C#
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
- C#
- .NET
- Aspose.Slides
description: "Aprenda a administrar y personalizar los diseños de diapositivas en Aspose.Slides para .NET. Explore los tipos de diseño, el control de marcadores de posición, la visibilidad del pie de página y la manipulación de diseños mediante ejemplos de código en C#."
---

## **Descripción general**

Un diseño de diapositiva define la disposición de los cuadros de marcadores de posición y el formato del contenido en una diapositiva. Controla qué marcadores de posición están disponibles y dónde aparecen. Los diseños de diapositiva le ayudan a crear presentaciones de forma rápida y coherente—ya sea que esté creando algo simple o más complejo. Algunos de los diseños de diapositiva más comunes en PowerPoint incluyen:

**Diseño de diapositiva de título** – Incluye dos marcadores de posición de texto: uno para el título y otro para el subtítulo.

**Diseño de título y contenido** – Presenta un marcador de posición de título más pequeño en la parte superior y uno más grande debajo para el contenido principal (como texto, viñetas, gráficos, imágenes y más).

**Diseño en blanco** – No contiene marcadores de posición, lo que le brinda control total para diseñar la diapositiva desde cero.

Los diseños de diapositiva forman parte de una diapositiva maestra, que es la diapositiva de nivel superior que define los estilos de diseño para la presentación. Puede acceder y modificar los diseños de diapositiva a través de la diapositiva maestra—ya sea por su tipo, nombre o ID único. Alternativamente, puede editar un diseño de diapositiva específico directamente dentro de la presentación.

Para trabajar con diseños de diapositiva en Aspose.Slides for .NET, puede usar:
- Propiedades como [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) y [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) bajo la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
- Tipos como [ILayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutplaceholdermanager/), y [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Para obtener más información sobre el trabajo con diapositivas maestras, consulte el artículo [Slide Master](/slides/es/net/slide-master/).
{{% /alert %}}

## **Agregar diseños de diapositiva a presentaciones**

Para personalizar la apariencia y la estructura de sus diapositivas, puede que necesite agregar nuevos diseños de diapositiva a una presentación. Aspose.Slides for .NET le permite comprobar si un diseño específico ya existe, agregar uno nuevo si es necesario y usarlo para insertar diapositivas basadas en ese diseño.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
1. Acceda a la [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterlayoutslidecollection/) .
1. Verifique si el diseño de diapositiva deseado ya existe en la colección. Si no, añada el diseño de diapositiva que necesita.
1. Añada una diapositiva en blanco basada en el nuevo diseño de diapositiva.
1. Guarde la presentación.

El siguiente código C# muestra cómo agregar un diseño de diapositiva a una presentación de PowerPoint:
```cs
// Instanciar la clase Presentation que representa un archivo PowerPoint.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // Recorrer los tipos de diapositivas de diseño para seleccionar una diapositiva de diseño.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // Una situación en la que la presentación no contiene todos los tipos de diseño.
        // El archivo de presentación contiene solo los tipos de diseño Blank y Custom.
        // Sin embargo, las diapositivas de diseño con tipos personalizados pueden tener nombres reconocibles,
        // como "Title", "Title and Content", etc., que pueden usarse para la selección de diapositivas de diseño.
        // También puedes basarte en un conjunto de tipos de forma de marcador de posición.
        // Por ejemplo, una diapositiva Title solo debe tener el tipo de marcador de posición Title, y así sucesivamente.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
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
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Agregar una diapositiva vacía usando la diapositiva de diseño añadida.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // Guardar la presentación en disco.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **Eliminar diseños de diapositiva no utilizados**

Aspose.Slides ofrece el método [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) de la clase [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) para permitirle eliminar diseños de diapositiva no deseados y no utilizados.

El siguiente código C# muestra cómo eliminar un diseño de diapositiva de una presentación de PowerPoint:
```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **Agregar marcadores de posición a los diseños de diapositiva**

Aspose.Slides proporciona la propiedad [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/placeholdermanager/), que permite agregar nuevos marcadores de posición a un diseño de diapositiva.

Este administrador contiene métodos para los siguientes tipos de marcadores de posición:

| Marcador de posición de PowerPoint | Método de [ILayoutPlaceholderManager](https://reference.aspose.com/slides/net/aspose.slides/ilayoutplaceholdermanager/) |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png)                   | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png)       | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png)             | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png)                 | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png)                 | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png)    | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

El siguiente código C# muestra cómo agregar nuevas formas de marcador de posición al diseño en blanco:
```cs
using (var presentation = new Presentation())
{
    // Obtener la diapositiva de diseño en blanco.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Obtener el administrador de marcadores de posición de la diapositiva de diseño.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // Añadir diferentes marcadores de posición a la diapositiva de diseño en blanco.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // Añadir una nueva diapositiva con el diseño en blanco.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```


El resultado:

![The placeholders on the layout slide](add_placeholders.png)

## **Establecer la visibilidad del pie de página para un diseño de diapositiva**

En presentaciones de PowerPoint, los elementos del pie de página como la fecha, el número de diapositiva y el texto personalizado pueden mostrarse u ocultarse según el diseño de la diapositiva. Aspose.Slides for .NET le permite controlar la visibilidad de estos marcadores de posición de pie de página. Esto es útil cuando desea que ciertos diseños muestren información del pie de página mientras que otros permanezcan limpios y minimalistas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtenga una referencia al diseño de diapositiva por su índice.
3. Establezca el marcador de posición del pie de página de la diapositiva como visible.
4. Establezca el marcador de posición del número de diapositiva como visible.
5. Establezca el marcador de posición de fecha y hora como visible.
6. Guarde la presentación.

El siguiente código C# muestra cómo establecer la visibilidad de un pie de página de diapositiva y realizar tareas relacionadas:
```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```


## **Establecer la visibilidad del pie de página hijo para una diapositiva**

En presentaciones de PowerPoint, los elementos del pie de página como la fecha, el número de diapositiva y el texto personalizado pueden controlarse a nivel de diapositiva maestra para garantizar la consistencia en todos los diseños de diapositiva. Aspose.Slides for .NET le permite establecer la visibilidad y el contenido de estos marcadores de posición de pie de página en la diapositiva maestra y propagar estos ajustes a todos los diseños de diapositiva hijos. Este enfoque garantiza una información de pie de página uniforme en toda su presentación.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Obtenga una referencia a la diapositiva maestra por su índice.
3. Establezca los marcadores de posición del pie de página de la maestra y de todos los hijos como visibles.
4. Establezca los marcadores de posición del número de diapositiva de la maestra y de todos los hijos como visibles.
5. Establezca los marcadores de posición de fecha y hora de la maestra y de todos los hijos como visibles.
6. Guarde la presentación.

El siguiente código C# muestra esta operación:
```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```


## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una diapositiva maestra y un diseño de diapositiva?**

Una diapositiva maestra define el tema general y el formato predeterminado, mientras que los diseños de diapositiva definen disposiciones específicas de marcadores de posición para diferentes tipos de contenido.

**¿Puedo copiar un diseño de diapositiva de una presentación a otra?**

Sí, puede clonar un diseño de diapositiva de la colección [LayoutSlides](https://reference.aspose.com/slides/net/aspose.slides/presentation/layoutslides/) de una presentación e insertarlo en otra usando el método `AddClone`.

**¿Qué ocurre si elimino un diseño de diapositiva que todavía es usado por una diapositiva?**

Si intenta eliminar un diseño de diapositiva que todavía está referenciado por al menos una diapositiva en la presentación, Aspose.Slides lanzará una [PptxEditException](https://reference.aspose.com/slides/net/aspose.slides/pptxeditexception/). Para evitarlo, use [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) que elimina de forma segura sólo los diseños de diapositiva que no están en uso.