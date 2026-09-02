---
title: Aplicar o cambiar distribuciones de diapositivas en Python
linktitle: Distribución de diapositiva
type: docs
weight: 60
url: /es/python-net/slide-layout/
keywords:
- distribución de diapositiva
- distribución de contenido
- marcador de posición
- diseño de presentación
- diseño de diapositiva
- distribución no usada
- visibilidad del pie de página
- diapositiva de título
- título y contenido
- encabezado de sección
- dos contenidos
- comparación
- solo título
- distribución en blanco
- contenido con leyenda
- imagen con leyenda
- título y texto vertical
- título vertical y texto
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aplicar, crear y modificar distribuciones de diapositivas en Aspose.Slides para Python mediante .NET, añadir marcadores de posición, eliminar distribuciones no usadas y controlar la visibilidad del pie de página."
---
## **Visión general**

Una distribución de diapositiva define la posición y el formato de los marcadores de posición, como títulos, texto, imágenes, gráficos y tablas. Aplicar una distribución otorga a las diapositivas una estructura coherente mientras permite que cada diapositiva contenga su propio contenido.

Las distribuciones más habituales son:

- **Diapositiva de título**: Contiene marcadores de posición para el título y el subtítulo.  
- **Título y contenido**: Contiene un marcador de posición para el título y otro de contenido de uso general.  
- **En blanco**: No contiene marcadores de posición y resulta útil cuando cada forma se posicionará manualmente.

## **Comprender la herencia de distribuciones**

Una presentación tiene tres niveles relacionados:

1. Una [diapositiva maestra](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslide/) define el tema, el formato compartido, los fondos y los objetos comunes.  
1. Una [diapositiva de distribución](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/) pertenece a una maestra y define una disposición concreta de marcadores de posición.  
1. Una [diapositiva normal](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/) utiliza una distribución y almacena el contenido introducido para esa diapositiva.

Una diapositiva normal hereda el tema y el formato de su distribución, y la distribución hereda de su maestra. Un valor establecido directamente en una diapositiva normal sobrescribe el valor heredado en ese nivel. Cuando se crea una diapositiva normal, sus formas de marcador de posición se generan a partir de la distribución seleccionada, mientras que el contenido introducido en esos marcadores pertenece a la diapositiva normal.

Añada los marcadores de posición necesarios a una distribución antes de crear diapositivas a partir de ella. Añadir otro marcador de posición a una distribución más adelante no añade automáticamente una forma de marcador correspondiente a las diapositivas normales ya existentes.

Esta relación tiene dos consecuencias importantes:

- Cambiar el formato heredado o la geometría de un marcador de posición existente en una distribución puede actualizar todas las diapositivas que dependen de ella. Antes de editar una distribución que ya está en uso, inspeccione sus diapositivas dependientes y revise la presentación resultante.  
- Una distribución que aún sea utilizada por alguna diapositiva no puede eliminarse. Reasigne primero sus diapositivas dependientes a otra distribución, o elimine sólo las distribuciones no usadas.

Para obtener más información sobre el nivel superior de esta jerarquía, consulte [Maestra de diapositivas](/slides/es/python-net/slide-master/).

## **Seleccionar y aplicar una distribución de diapositiva**

Utilice un tipo de distribución cuando la presentación siga las definiciones estándar de PowerPoint. Los nombres de las distribuciones son editables por el usuario y pueden localizarse, de modo que la selección basada en nombres es menos fiable a menos que controle la plantilla fuente.

El siguiente ejemplo busca **Título y contenido** en la primera maestra. Si esa distribución no está disponible, recurre deliberadamente a **En blanco**. La segunda comprobación de nulo es necesaria porque una presentación puede contener sólo distribuciones personalizadas. La distribución seleccionada se aplica entonces a la primera diapositiva normal mediante la propiedad [Slide.layout_slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/layout_slide/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

Cambiar la distribución de una diapositiva no elimina las formas ordinarias añadidas directamente a la diapositiva. Sin embargo, las posiciones de los marcadores de posición, el formato heredado y la correspondencia entre los marcadores existentes y la nueva distribución pueden cambiar, por lo que se debe inspeccionar el resultado al alternar entre distribuciones sustancialmente diferentes.

## **Añadir una distribución de diapositiva**

La selección y la creación son operaciones distintas. El ejemplo anterior selecciona una distribución existente; no la crea. Para crear una distribución, invoque el método [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterlayoutslidecollection/add/) sobre la colección de distribuciones de la maestra de destino.

El siguiente ejemplo siempre añade una nueva distribución **Título y contenido** llamada `Report Title and Content`, y después añade una diapositiva normal basada en ella. Los nombres de las distribuciones deben ser únicos dentro de la colección.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Añada una distribución solo cuando la plantilla necesite realmente otra estructura reutilizable. Si ya existe una distribución adecuada, selecciónela y reutilícela en lugar de crear un duplicado.

## **Añadir marcadores de posición a una distribución de diapositiva**

La propiedad [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/placeholder_manager/) proporciona un [LayoutPlaceholderManager](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/) para agregar formas de marcador de posición a una distribución.

| Marcador de posición de PowerPoint | Método `LayoutPlaceholderManager` |
| ----------------------------------- | --------------------------------- |
| ![Contenido](content.png)           | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Contenido (Vertical)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Texto](text.png)                 | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Texto (Vertical)](textV.png)     | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Imagen](picture.png)             | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Gráfico](chart.png)               | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Tabla](table.png)                 | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)           | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Multimedia](media.png)            | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Imagen en línea](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

El siguiente ejemplo verifica que la distribución **En blanco** exista, añade cuatro marcadores de posición a ella y, a continuación, crea una diapositiva normal que utiliza la distribución modificada. El orden es intencional: los marcadores se añaden antes de crear la diapositiva normal, de modo que Aspose.Slides pueda generar las formas de marcador correspondientes en esa diapositiva.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

El resultado:

![Los marcadores de posición en la diapositiva de distribución](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Cambiar el formato heredado o la geometría de los marcadores de posición existentes en una distribución puede afectar a las diapositivas dependientes. Un marcador de posición recién añadido a una distribución no se retropropaga a las diapositivas normales ya existentes. Pruebe los cambios de distribución en una copia de la presentación y examine cada diapositiva dependiente.
{{% /alert %}}

## **Eliminar distribuciones de diapositiva no usadas**

Utilice el método [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) para eliminar las distribuciones que no están referenciadas por ninguna diapositiva normal. El método deja intactas las distribuciones que siguen en uso.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Para eliminar una distribución concreta, primero use su propiedad [has_depending_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/has_depending_slides/) o el método [get_depending_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/get_depending_slides/). Reasigne cualquier diapositiva dependiente antes de llamar a [LayoutSlide.remove](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/remove/). Intentar eliminar una distribución que está en uso genera una [PptxEditException](https://reference.aspose.com/slides/es/python-net/aspose.slides/pptxeditexception/).

## **Controlar la visibilidad del pie de página en una distribución de diapositiva**

Una distribución tiene sus propios marcadores de posición de pie de página, número de diapositiva y fecha/hora. Utilice la propiedad [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/header_footer_manager/) para controlar esos marcadores en una distribución concreta. Esto resulta útil, por ejemplo, cuando las distribuciones de contenido deben mostrar pies de página pero las de título no.

El siguiente ejemplo selecciona una distribución de forma segura y hace visibles sus elementos de pie de página:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Controlar la visibilidad del pie de página en una maestra y sus distribuciones hijas**

Para aplicar configuraciones de pie de página coherentes en toda la jerarquía de una maestra, utilice la propiedad [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslide/header_footer_manager/). Los métodos de propagación de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslideheaderfootermanager/) actúan sobre la maestra y sus diapositivas de distribución y diapositivas normales; no se centran únicamente en una diapositiva normal.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una diapositiva maestra y una diapositiva de distribución?**

Una diapositiva maestra define el tema y el formato compartido de la presentación. Una diapositiva de distribución pertenece a una maestra y define una disposición reutilizable de marcadores de posición. Las diapositivas normales utilizan esas distribuciones y almacenan el contenido específico de cada diapositiva.

**¿Puedo copiar una diapositiva de distribución de una presentación a otra?**

Sí. Añada una copia a la colección de destino con el método [add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/globallayoutslidecollection/add_clone/). Al copiar entre presentaciones, también verifique fuentes, temas, imágenes y demás recursos que utilice la distribución origen.

**¿Qué ocurre si modifico una distribución que ya está en uso?**

Las diapositivas dependientes heredan los cambios en la distribución, salvo que anulen localmente el formato o los objetos afectados. La geometría de los marcadores y el estilo heredado pueden, por tanto, cambiar en muchas diapositivas a la vez. Use [get_depending_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/get_depending_slides/) para identificar las diapositivas afectadas antes de editar la distribución.

**¿Qué ocurre si elimino una distribución que sigue en uso?**

Aspose.Slides genera una [PptxEditException](https://reference.aspose.com/slides/es/python-net/aspose.slides/pptxeditexception/). Reasigne primero las diapositivas dependientes o utilice [remove_unused_layout_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) para eliminar solo las distribuciones no referenciadas.