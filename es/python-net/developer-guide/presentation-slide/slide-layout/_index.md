---
title: Aplicar o cambiar diseños de diapositiva en Python
linktitle: Diseño de diapositiva
type: docs
weight: 60
url: /es/python-net/slide-layout/
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
- contenido con leyenda
- imagen con leyenda
- título y texto vertical
- título vertical y texto
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aprenda cómo gestionar y personalizar los diseños de diapositiva en Aspose.Slides para Python a través de .NET. Explore los tipos de diseños, el control de marcadores de posición, la visibilidad del pie de página y la manipulación de diseños mediante ejemplos de código en Python."
---

## **Resumen**

Un diseño de diapositiva define la disposición de los cuadros de marcador de posición y el formato del contenido en una diapositiva. Controla qué marcadores de posición están disponibles y dónde aparecen. Los diseños de diapositiva le ayudan a crear presentaciones rápida y consistentemente, ya sea que esté creando algo sencillo o más complejo. Algunos de los diseños de diapositiva más comunes en PowerPoint incluyen:

**Diseño de diapositiva de título** – Incluye dos marcadores de posición de texto: uno para el título y otro para el subtítulo.

**Diseño de título y contenido** – Presenta un marcador de posición de título más pequeño en la parte superior y uno más grande debajo para el contenido principal (texto, viñetas, gráficos, imágenes y más).

**Diseño en blanco** – No contiene marcadores de posición, dándole control total para diseñar la diapositiva desde cero.

Los diseños de diapositiva forman parte de una diapositiva maestra, que es la diapositiva de nivel superior que define los estilos de diseño para la presentación. Puede acceder y modificar las diapositivas de diseño a través de la diapositiva maestra, ya sea por su tipo, nombre o ID único. Alternativamente, puede editar una diapositiva de diseño específica directamente dentro de la presentación.

Para trabajar con diseños de diapositiva en Aspose.Slides for Python, puede usar:

- Propiedades como [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) y [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) bajo la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
- Tipos como [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/) y [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Para obtener más información sobre el uso de diapositivas maestras, consulte el artículo [Administrar diapositivas maestras de PowerPoint en Python](/slides/es/python-net/slide-master/).
{{% /alert %}}

## **Agregar diseños de diapositiva a presentaciones**

Para personalizar la apariencia y la estructura de sus diapositivas, puede que necesite agregar nuevos diseños a una presentación. Aspose.Slides for Python le permite comprobar si un diseño específico ya existe, agregar uno nuevo si es necesario y usarlo para insertar diapositivas basadas en ese diseño.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Acceda a la [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/).
1. Verifique si el diseño de diapositiva deseado ya existe en la colección. Si no, añada el diseño que necesita.
1. Agregue una diapositiva en blanco basada en el nuevo diseño.
1. Guarde la presentación.

El siguiente código Python muestra cómo agregar un diseño de diapositiva a una presentación de PowerPoint:
```python
import aspose.slides as slides

# Instanciar la clase Presentation para abrir el archivo de presentación.
with slides.Presentation("sample.pptx") as presentation:
    # Recorrer los tipos de diapositivas de diseño para seleccionar una diapositiva de diseño.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # Una situación en la que la presentación no contiene todos los tipos de diseño.
        # El archivo de presentación contiene solo los tipos de diseño Blank y Custom.
        # Sin embargo, las diapositivas de diseño con tipos personalizados pueden tener nombres reconocibles,
        # como "Title", "Title and Content", etc., que pueden usarse para la selección de la diapositiva de diseño.
        # También puede basarse en un conjunto de tipos de formas de marcador de posición.
        # Por ejemplo, una diapositiva Title debería tener solo el tipo de marcador de posición Title, y así sucesivamente.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Add an empty slide using the added layout slide.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # Save the presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Eliminar diseños de diapositiva no utilizados**

Aspose.Slides proporciona el método [remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) de la clase [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) para permitirle eliminar diseños de diapositiva no deseados y no utilizados.

El siguiente código Python muestra cómo eliminar un diseño de diapositiva de una presentación de PowerPoint:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Agregar marcadores de posición a diseños de diapositiva**

Aspose.Slides proporciona la propiedad [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/placeholder_manager/), que le permite agregar nuevos marcadores de posición a un diseño de diapositiva.

Este administrador contiene métodos para los siguientes tipos de marcadores de posición:

| Marcador de posición de PowerPoint | Método de [LayoutPlaceholderManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/) |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Contenido](content.png) | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Contenido (Vertical)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Texto](text.png) | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Texto (Vertical)](textV.png) | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Imagen](picture.png) | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Gráfico](chart.png) | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Tabla](table.png) | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png) | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Medios](media.png) | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Imagen en línea](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

El siguiente código Python muestra cómo agregar nuevas formas de marcador de posición al diseño en blanco:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Obtener la diapositiva de diseño en blanco.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Obtener el administrador de marcadores de posición de la diapositiva de diseño.
    placeholder_manager = layout.placeholder_manager

    # Añadir diferentes marcadores de posición a la diapositiva de diseño en blanco.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Añadir una nueva diapositiva con el diseño en blanco.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```


El resultado:

![Los marcadores de posición en el diseño de diapositiva](add_placeholders.png)

## **Establecer visibilidad del pie de página para un diseño de diapositiva**

En presentaciones de PowerPoint, los elementos de pie de página como la fecha, el número de diapositiva y el texto personalizado pueden mostrarse u ocultarse según el diseño de la diapositiva. Aspose.Slides for Python le permite controlar la visibilidad de estos marcadores de posición de pie de página. Esto es útil cuando desea que ciertos diseños muestren información de pie de página mientras que otros se mantengan limpios y minimalistas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga una referencia al diseño de diapositiva por su índice.
1. Establezca el marcador de posición del pie de página como visible.
1. Establezca el marcador de posición del número de diapositiva como visible.
1. Establezca el marcador de posición de fecha y hora como visible.
1. Guarde la presentación.

El siguiente código Python muestra cómo establecer la visibilidad del pie de página de una diapositiva y realizar tareas relacionadas:
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```


## **Establecer visibilidad del pie de página hijo para una diapositiva**

​En presentaciones de PowerPoint, los elementos de pie de página como la fecha, el número de diapositiva y el texto personalizado pueden controlarse a nivel de diapositiva maestra para garantizar consistencia en todas las diapositivas de diseño. Aspose.Slides for Python le permite establecer la visibilidad y el contenido de estos marcadores de posición de pie de página en la diapositiva maestra y propagar estos ajustes a todas las diapositivas de diseño hijas. Esta abordagem garantiza información de pie de página uniforme en toda la presentación.​

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenga una referencia a la diapositiva maestra por su índice.
1. Establezca los marcadores de posición de pie de página de la maestra y de todas sus hijas como visibles.
1. Establezca los marcadores de posición de número de diapositiva de la maestra y de todas sus hijas como visibles.
1. Establezca los marcadores de posición de fecha y hora de la maestra y de todas sus hijas como visibles.
1. Guarde la presentación.

El siguiente código Python demuestra esta operación:
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una diapositiva maestra y una diapositiva de diseño?**

Una diapositiva maestra define el tema general y el formato predeterminado, mientras que las diapositivas de diseño definen disposiciones específicas de marcadores de posición para diferentes tipos de contenido.

**¿Puedo copiar una diapositiva de diseño de una presentación a otra?**

Sí, puede clonar una diapositiva de diseño de la colección [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) de una presentación e insertarla en otra usando el método `add_clone`.

**¿Qué ocurre si elimino una diapositiva de diseño que aún está siendo usada por una diapositiva?**

Si intenta eliminar una diapositiva de diseño que aún es referenciada por al menos una diapositiva en la presentación, Aspose.Slides lanzará una [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/). Para evitarlo, use [remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/), que elimina de forma segura solo los diseños que no están en uso.