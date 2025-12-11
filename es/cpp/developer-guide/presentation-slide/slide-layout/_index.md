---
title: Aplicar o cambiar diseños de diapositivas en C++
linktitle: Diseño de diapositiva
type: docs
weight: 60
url: /es/cpp/slide-layout/
keywords:
- diseño de diapositiva
- diseño de contenido
- marcador de posición
- diseño de presentación
- diseño de la diapositiva
- diseño no usado
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
- C++
- Aspose.Slides
description: "Administrar y personalizar los diseños de diapositivas en Aspose.Slides para C++. Explore los tipos de diseño, el control de marcadores de posición y la visibilidad del pie de página mediante ejemplos de código en C++."
---

## **Descripción general**

Un diseño de diapositiva define la disposición de los cuadros de marcador de posición y el formato del contenido en una diapositiva. Controla qué marcadores de posición están disponibles y dónde aparecen. Los diseños de diapositiva le ayudan a crear presentaciones de forma rápida y coherente, ya sea que esté creando algo sencillo o más complejo. Algunos de los diseños de diapositiva más comunes en PowerPoint incluyen:

**Diseño de diapositiva de título** – Incluye dos marcadores de posición de texto: uno para el título y otro para el subtítulo.

**Diseño de título y contenido** – Presenta un marcador de posición de título más pequeño en la parte superior y uno más grande debajo para el contenido principal (como texto, viñetas, gráficos, imágenes y más).

**Diseño en blanco** – No contiene marcadores de posición, lo que le permite tener control total para diseñar la diapositiva desde cero.

Los diseños de diapositiva forman parte de una diapositiva maestra, que es la diapositiva de nivel superior que define los estilos de diseño para la presentación. Puede acceder y modificar las diapositivas de diseño a través de la diapositiva maestra—ya sea por su tipo, nombre o ID único. Alternativamente, puede editar una diapositiva de diseño específica directamente dentro de la presentación.

Para trabajar con diseños de diapositiva en Aspose.Slides para Android, puede usar:

- Métodos como [get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) y [get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) bajo la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)
- Tipos como [ILayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutplaceholdermanager/) y [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Para obtener más información sobre el trabajo con diapositivas maestras, consulte el artículo [Slide Master](/slides/es/cpp/slide-master/).
{{% /alert %}}

## **Agregar diseños de diapositiva a presentaciones**

Para personalizar la apariencia y la estructura de sus diapositivas, puede que necesite agregar nuevas diapositivas de diseño a una presentación. Aspose.Slides para Android le permite verificar si un diseño específico ya existe, agregar uno nuevo si es necesario y usarlo para insertar diapositivas basadas en ese diseño.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Acceder a la [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Verificar si la diapositiva de diseño deseada ya existe en la colección. Si no, agregar la diapositiva de diseño que necesite.
1. Agregar una diapositiva en blanco basada en la nueva diapositiva de diseño.
1. Guardar la presentación.

El siguiente código C++ muestra cómo agregar un diseño de diapositiva a una presentación de PowerPoint:
```cpp
// Instanciar la clase Presentation que representa un archivo PowerPoint.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Recorrer los tipos de diapositivas de diseño para seleccionar una diapositiva de diseño.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // Una situación en la que la presentación no contiene todos los tipos de diseño.
    // El archivo de presentación contiene solo los tipos de diseño Blank y Custom.
    // Sin embargo, las diapositivas de diseño con tipos personalizados pueden tener nombres reconocibles,
    // como "Title", "Title and Content", etc., que pueden usarse para la selección de diapositivas de diseño.
    // También puede basarse en un conjunto de tipos de forma de marcador de posición.
    // Por ejemplo, una diapositiva de título debe tener solo el tipo de marcador de posición Title, etc.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Agregar una diapositiva vacía usando la diapositiva de diseño añadida.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Guardar la presentación en disco.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Eliminar diseños de diapositiva no usados**

Aspose.Slides proporciona el método [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) de la clase [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) para permitirle eliminar diseños de diapositiva no deseados y sin uso.

El siguiente código C++ muestra cómo eliminar una diapositiva de diseño de una presentación de PowerPoint:
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Agregar marcadores de posición a diseños de diapositiva**

Aspose.Slides proporciona el método [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) que permite agregar nuevos marcadores de posición a una diapositiva de diseño.

Este gestor contiene métodos para los siguientes tipos de marcador de posición:

| Marcador de posición de PowerPoint | Método de [ILayoutPlaceholderManager](https://reference.aspose.com/slides/cpp/aspose.slides/ilayoutplaceholdermanager/) |
| ---------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------- |
| ![Contenido](content.png)          | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Contenido (Vertical)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Texto](text.png)                 | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Texto (Vertical)](textV.png)    | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Imagen](picture.png)             | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Gráfico](chart.png)              | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Tabla](table.png)                | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)          | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Medios](media.png)               | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Imagen en línea](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

El siguiente código C++ demuestra cómo agregar nuevas formas de marcador de posición al diseño en blanco:
```cpp
auto presentation = MakeObject<Presentation>();

// Obtener la diapositiva de diseño en blanco.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Obtener el administrador de marcadores de posición de la diapositiva de diseño.
auto placeholderManager = layout->get_PlaceholderManager();

// Añadir diferentes marcadores de posición a la diapositiva de diseño en blanco.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Añadir una nueva diapositiva con el diseño en blanco.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


El resultado:

![Los marcadores de posición en la diapositiva de diseño](add_placeholders.png)

## **Establecer visibilidad del pie de página para una diapositiva de diseño**

En presentaciones de PowerPoint, los elementos del pie de página como la fecha, el número de diapositiva y el texto personalizado pueden mostrarse u ocultarse según el diseño de la diapositiva. Aspose.Slides para Android le permite controlar la visibilidad de estos marcadores de posición de pie de página. Esto es útil cuando desea que ciertos diseños muestren información del pie de página mientras que otros permanezcan limpios y minimalistas.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtener una referencia a la diapositiva de diseño por su índice.
1. Establecer el marcador de posición del pie de página de la diapositiva como visible.
1. Establecer el marcador de posición del número de diapositiva como visible.
1. Establecer el marcador de posición de fecha y hora como visible.
1. Guardar la presentación.

El siguiente código C++ muestra cómo establecer la visibilidad de un pie de página de diapositiva y realizar tareas relacionadas:
```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```


## **Establecer visibilidad del pie de página hijo para una diapositiva**

En presentaciones de PowerPoint, los elementos del pie de página como la fecha, el número de diapositiva y el texto personalizado pueden controlarse a nivel de diapositiva maestra para garantizar la coherencia en todas las diapositivas de diseño. Aspose.Slides para Android le permite establecer la visibilidad y el contenido de estos marcadores de posición de pie de página en la diapositiva maestra y propagar estos ajustes a todas las diapositivas de diseño hijas. Este enfoque asegura información uniforme del pie de página en toda la presentación.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtener una referencia a la diapositiva maestra por su índice.
1. Establecer los marcadores de posición del pie de página de la maestra y de todas sus hijas como visibles.
1. Establecer los marcadores de posición del número de diapositiva de la maestra y de todas sus hijas como visibles.
1. Establecer los marcadores de posición de fecha y hora de la maestra y de todas sus hijas como visibles.
1. Guardar la presentación.

El siguiente código C++ demuestra esta operación:
```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una diapositiva maestra y una diapositiva de diseño?**

Una diapositiva maestra define el tema general y el formato predeterminado, mientras que las diapositivas de diseño definen disposiciones específicas de marcadores de posición para diferentes tipos de contenido.

**¿Puedo copiar una diapositiva de diseño de una presentación a otra?**

Sí, puede clonar una diapositiva de diseño de la colección de diseños de una presentación, accesible mediante el método [get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/), e insertarla en otra presentación usando el método `AddClone`.

**¿Qué ocurre si elimino una diapositiva de diseño que sigue siendo usada por una diapositiva?**

Si intenta eliminar una diapositiva de diseño que todavía está referenciada por al menos una diapositiva en la presentación, Aspose.Slides lanzará una [PptxEditException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxeditexception/). Para evitarlo, use [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/), que elimina de forma segura solo los diseños que no están en uso.