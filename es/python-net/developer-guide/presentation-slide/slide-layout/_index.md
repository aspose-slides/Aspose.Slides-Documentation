---
title: Aplicar o cambiar un diseño de diapositiva en Python
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
  - visibilidad de pie de página
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
  - Python
  - Aspose.Slides
description: "Aprenda cómo gestionar y personalizar diseños de diapositivas en Aspose.Slides para Python a través de .NET. Explore los tipos de diseño, el control de marcadores de posición, la visibilidad del pie de página y la manipulación de diseños mediante ejemplos de código en Python."
---

Un diseño de diapositiva contiene los cuadros de marcador de posición y la información de formato para todo el contenido que aparece en una diapositiva. El diseño determina los marcadores de posición de contenido disponibles y dónde se colocan.

Los diseños de diapositivas te permiten crear y diseñar presentaciones rápidamente (ya sean simples o complejas). Estos son algunos de los diseños de diapositivas más populares que se utilizan en las presentaciones de PowerPoint:

* **Diseño de Diapositiva de Título**. Este diseño consiste en dos marcadores de posición de texto. Un marcador de posición es para el título y el otro es para el subtítulo.
* **Diseño de Título y Contenido**. Este diseño contiene un marcador de posición relativamente pequeño en la parte superior para el título y un marcador de posición más grande para el contenido principal (gráfico, párrafos, lista con viñetas, lista numerada, imágenes, etc.).
* **Diseño en Blanco**. Este diseño carece de marcadores de posición, por lo que te permite crear elementos desde cero.

Dado que un maestro de diapositivas es la diapositiva jerárquica superior que almacena información sobre los diseños de diapositivas, puedes usar la diapositiva maestra para acceder a los diseños de diapositivas y hacer cambios en ellos. Se puede acceder a una diapositiva de diseño por tipo o nombre. De manera similar, cada diapositiva tiene un id único, que se puede usar para acceder a ella.

Alternativamente, puedes hacer cambios directamente en un diseño de diapositiva específico en una presentación.

* Para permitirte trabajar con diseños de diapositivas (incluyendo aquellos en diapositivas maestras), Aspose.Slides proporciona propiedades como `layout_slides` y `masters` bajo la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
* Para realizar tareas relacionadas, Aspose.Slides proporciona [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/baseslideheaderfootermanager/), y muchos otros tipos.

{{% alert title="Info" color="info" %}}

Para más información sobre cómo trabajar con Diapositivas Maestras en particular, consulta el artículo [Slide Master](https://docs.aspose.com/slides/python-net/slide-master/).

{{% /alert %}}

## **Agregar Diseño de Diapositiva a Presentación**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accede a la [colección MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterlayoutslidecollection/).
1. Revisa los diseños de diapositivas existentes para confirmar que el diseño de diapositiva requerido ya existe en la colección de Diseños de Diapositivas. De lo contrario, añade el diseño de diapositiva que deseas.
1. Agrega una diapositiva vacía basada en el nuevo diseño de diapositiva.
1. Guarda la presentación.

Este código Python te muestra cómo agregar un diseño de diapositiva a una presentación de PowerPoint:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancia una clase Presentation que representa el archivo de presentación
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Revisa los tipos de diapositivas de diseño
    layoutSlides = presentation.masters[0].layout_slides
    layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)  
    if layoutSlide is None:
         layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE)

    if layoutSlide is None:
        # La situación donde una presentación no contiene algunos tipos de diseño.
        # El archivo de presentación solo contiene diseños en Blanco y Personalizados.
        # Pero las diapositivas de diseño con tipos personalizables tienen nombres de diapositiva diferentes,
        # como "Título", "Título y Contenido", etc. Y es posible usar estos
        # nombres para la selección de las diapositivas de diseño.
        # También puedes usar un conjunto de tipos de forma de marcador de posición. Por ejemplo,
        # el diseño de título debe tener solo el tipo de marcador de posición de Título, etc.
        for titleAndObjectLayoutSlide in layoutSlides:
            if titleAndObjectLayoutSlide.name == "Title and Object":
                layoutSlide = titleAndObjectLayoutSlide
                break

        if layoutSlide is None:
            for titleLayoutSlide in layoutSlides:
                if titleLayoutSlide.name == "Title":
                    layoutSlide = titleLayoutSlide
                    break

            if layoutSlide is None:
                layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.BLANK)
                if layoutSlide is None:
                    layoutSlide = layoutSlides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Agrega una diapositiva vacía con el diseño de diapositiva agregado
    presentation.slides.insert_empty_slide(0, layoutSlide)

    # Guarda la presentación en el disco
    presentation.save("AddLayoutSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Eliminar Diapositiva de Diseño No Utilizada**

Aspose.Slides proporciona el método `remove_unused_layout_slides` de la clase [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) para permitirte eliminar diapositivas de diseño no deseadas y no utilizadas. Este código Python te muestra cómo eliminar un diseño de diapositiva de una presentación de PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_layout_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Tamaño y Tipo para Diseño de Diapositiva**

Para permitirte establecer el tamaño y tipo para una diapositiva de diseño específica, Aspose.Slides proporciona las propiedades `type` y `size` (de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)). Este Python demuestra la operación:

```python
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo de presentación 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # Establece el tamaño de la diapositiva para la presentación generada igual al de la fuente
        auxPresentation.slide_size.set_size(presentation.slide_size.type, slides.SlideSizeScaleType.ENSURE_FIT)

        auxPresentation.slides.insert_clone(0, slide)
        auxPresentation.slides.remove_at(0)
        # Guarda la presentación en el disco
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Visibilidad del Pie de Página Dentro de la Diapositiva**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtén una referencia de la diapositiva a través de su índice.
1. Establece el marcador de posición del pie de página de la diapositiva como visible.
1. Establece el marcador de posición de fecha y hora como visible.
1. Guarda la presentación.

Este código Python te muestra cómo establecer la visibilidad para un pie de página de diapositiva (y realizar tareas relacionadas):

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    headerFooterManager = presentation.slides[0].header_footer_manager
    # La propiedad is_footer_visible se usa para especificar que falta un marcador de posición para el pie de página
    if not headerFooterManager.is_footer_visible: 
        # El método set_footer_visibility se usa para establecer un marcador de posición del pie de página de la diapositiva como visible
        headerFooterManager.set_footer_visibility(True) 
        # La propiedad is_slide_number_visible se usa para especificar que falta un marcador de posición del número de diapositiva
    if not headerFooterManager.is_slide_number_visible:  
        # El método set_slide_number_visibility se usa para establecer un marcador de posición del número de diapositiva como visible
        headerFooterManager.set_slide_number_visibility(True) 
        # La propiedad is_date_time_visible se usa para especificar que falta un marcador de posición de fecha y hora de la diapositiva
    if not headerFooterManager.is_date_time_visible: 
        # El método set_date_time_visibility se usa para establecer un marcador de posición de fecha y hora de la diapositiva como visible 
        headerFooterManager.set_date_time_visibility(True)

    # El método set_footer_text se usa para establecer un texto para un marcador de posición del pie de página de la diapositiva 
    headerFooterManager.set_footer_text("Texto del pie de página") 
    # El método set_date_time_text se usa para establecer un texto para un marcador de posición de fecha y hora de la diapositiva.
    headerFooterManager.set_date_time_text("Texto de fecha y hora") 

    # Guarda la presentación en el disco
    presentation.save("Presentation.ppt", slides.export.SaveFormat.PPT)
```

## **Establecer Visibilidad del Pie de Página Secundario Dentro de la Diapositiva**

1. Crea una instancia de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. Obtén una referencia para la diapositiva maestra a través de su índice.
1. Establece la visibilidad del pie de página maestro y todos los marcadores de posición de pie de página secundarios como visible.
1. Establece un texto para la diapositiva maestra y todos los marcadores de posición de pie de página secundarios.
1. Establece un texto para la diapositiva maestra y todos los marcadores de posición de fecha y hora secundarios.
1. Guarda la presentación.

Este código Python demuestra la operación:

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    manager = presentation.masters[0].header_footer_manager
    manager.set_footer_and_child_footers_visibility(True) # El método set_footer_and_child_footers_visibility se usa para establecer la visibilidad del pie de página maestro y todos los pie de página secundarios
    manager.set_slide_number_and_child_slide_numbers_visibility(True) # El método set_slide_number_and_child_slide_numbers_visibility se usa para establecer la visibilidad del número de página maestro y todos los números de página secundarios
    manager.set_date_time_and_child_date_times_visibility(True) # El método set_date_time_and_child_date_times_visibility se usa para establecer la visibilidad de la fecha y hora de la diapositiva maestra y todos los marcadores de posición secundarios

    manager.set_footer_and_child_footers_text("Texto del pie de página") # El método set_footer_and_child_footers_text se usa para establecer los textos para el pie de página maestro y todos los pies de página secundarios
    manager.set_date_time_and_child_date_times_text("Texto de fecha y hora") # El método set_date_time_and_child_date_times_text se usa para establecer un texto para la diapositiva maestra y todos los marcadores de posición secundarios de fecha y hora
```

## **Establecer Tamaño de Diapositiva con Respecto a la Escala de Contenido**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) y carga la presentación que contiene la diapositiva cuyo tamaño deseas establecer.
1. Crea otra instancia de la clase [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) para generar una nueva presentación.
1. Obtén la referencia de la diapositiva (de la primera presentación) a través de su índice.
1. Establece el marcador de posición del pie de página de la diapositiva como visible.
1. Establece el marcador de posición de fecha y hora como visible.
1. Guarda la presentación.

Este Python demuestra la operación:

```python
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo de presentación 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # Establece el tamaño de la diapositiva para las presentaciones generadas igual al de la fuente
        presentation.slide_size.set_size(540, 720, slides.SlideSizeScaleType.ENSURE_FIT) # El método set_size se usa para establecer el tamaño de la diapositiva con escala de contenido para asegurar un ajuste
        presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.MAXIMIZE) # El método set_size se usa para establecer el tamaño de la diapositiva con el tamaño máximo del contenido
                
        # Guarda la presentación en el disco
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Establecer Tamaño de Página al Generar PDF**

Ciertas presentaciones (como carteles) a menudo se convierten en documentos PDF. Si deseas convertir tu PowerPoint a PDF para acceder a las mejores opciones de impresión y accesibilidad, deseas establecer tus diapositivas en tamaños que se adapten a documentos PDF (A4, por ejemplo).

Aspose.Slides proporciona la clase [SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/) para permitirte especificar tus configuraciones preferidas para las diapositivas. Este código Python te muestra cómo usar la propiedad `type` (de la clase `SlideSize`) para establecer un tamaño de papel específico para las diapositivas en una presentación:

```python
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo de presentación  
with slides.Presentation() as presentation:
    # Establece la propiedad SlideSize.Type 
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.ENSURE_FIT)

    # Establece diferentes propiedades para las Opciones de PDF
    opts = slides.export.PdfOptions()
    opts.sufficient_resolution = 600

    # Guarda la presentación en el disco
    presentation.save("SetPDFPageSize_out.pdf", slides.export.SaveFormat.PDF, opts)
```