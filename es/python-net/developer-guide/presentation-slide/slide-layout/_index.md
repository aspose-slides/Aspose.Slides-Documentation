---
title: Aplicar o cambiar diseños de diapositivas en Python
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
- Python
- Aspose.Slides
description: "Aplicar, crear y modificar diseños de diapositivas en Aspose.Slides para Python mediante .NET, añadir marcadores de posición, eliminar diseños sin usar y controlar la visibilidad del pie de página."
---
## **Visión general**

Un diseño de diapositiva define las posiciones y el formato de los marcadores de posición, como títulos, texto, imágenes, gráficos y tablas. Aplicar un diseño aporta una estructura coherente a las diapositivas al tiempo que permite que cada diapositiva contenga su propio contenido.

Los diseños más habituales incluyen:

- **Diapositiva de título**: Contiene marcadores de posición de título y subtítulo.
- **Título y contenido**: Contiene un marcador de posición de título y un marcador de posición de contenido de propósito general.
- **En blanco**: No contiene marcadores de posición de contenido y resulta útil cuando cada forma se posicionará manualmente.

## **Comprender la herencia de diseños**

Una presentación tiene tres niveles relacionados:

1. Una [diapositiva maestra](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslide/) define el tema, el formato compartido, los fondos y los objetos comunes.
1. Un [diseño de diapositiva](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/) pertenece a una maestra y define una disposición determinada de marcadores de posición.
1. Una [diapositiva normal](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/) utiliza un diseño y almacena el contenido introducido para esa diapositiva.

Una diapositiva normal hereda el tema y el formato de su diseño, y el diseño hereda de su maestra. Un valor establecido directamente en una diapositiva normal sobrescribe el valor heredado en ese nivel. Cuando se crea una diapositiva normal, sus formas de marcador de posición se generan a partir del diseño seleccionado, mientras que el contenido introducido en esos marcadores pertenece a la diapositiva normal.

Añada los marcadores de posición necesarios a un diseño antes de crear diapositivas a partir de él. Añadir otro marcador de posición a un diseño más tarde no añade automáticamente una forma de marcador de posición correspondiente a las diapositivas normales existentes.

Esta relación tiene dos consecuencias importantes:

- Cambiar el formato heredado o la geometría de los marcadores de posición existentes en un diseño puede actualizar todas las diapositivas que dependen de él. Antes de editar un diseño que ya está en uso, inspeccione sus diapositivas dependientes y revise la presentación resultante.
- Un diseño que todavía es utilizado por una diapositiva no puede eliminarse. Reasigne sus diapositivas dependientes a otro diseño primero, o elimine solo los diseños no usados.

Para obtener más información sobre el nivel superior de esta jerarquía, consulte la [Maestra de diapositivas](/slides/es/python-net/slide-master/).

Para ocultar logotipos heredados o formas decorativas de la maestra en una diapositiva o mediante un diseño compartido, consulte el artículo [Controlar la visibilidad de los gráficos de la maestra](/slides/es/python-net/slide-master/). El ejemplo compara dos diapositivas que utilizan la misma maestra.

## **Seleccionar y aplicar un diseño de diapositiva**

Utilice un tipo de diseño cuando la presentación sigue las definiciones estándar de diseños de PowerPoint. Los nombres de los diseños son editables por el usuario y pueden localizarse, por lo que la selección basada en el nombre es menos fiable a menos que usted controle la plantilla de origen.

El siguiente ejemplo busca **Título y contenido** en la primera maestra. Si ese diseño no está disponible, recurre deliberadamente a **En blanco**. La segunda comprobación de nulo es necesaria porque una presentación puede contener solo diseños personalizados. El diseño seleccionado se aplica luego a la primera diapositiva normal mediante la propiedad [Slide.layout_slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/layout_slide/).

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

Cambiar el diseño de una diapositiva no elimina las formas normales añadidas directamente a la diapositiva. Sin embargo, las posiciones de los marcadores de posición, el formato heredado y la correspondencia entre los marcadores existentes y el nuevo diseño pueden cambiar, por lo que debe inspeccionar el resultado al intercambiar entre diseños sustancialmente diferentes.

## **Añadir una diapositiva de diseño**

Seleccionar y crear son operaciones separadas. El ejemplo anterior selecciona un diseño existente; no lo crea. Para crear un diseño, llame al método [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterlayoutslidecollection/add/) en la colección de diseños de la maestra de destino.

El siguiente ejemplo siempre añade un nuevo diseño **Título y contenido** llamado `Report Title and Content`, y luego añade una diapositiva normal basada en él. Los nombres de los diseños deben ser únicos dentro de la colección.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Añada un diseño solo cuando la plantilla realmente necesite otra estructura reutilizable. Si ya existe un diseño adecuado, selecciónelo y reutilícelo en lugar de crear un duplicado.

## **Añadir marcadores de posición a una diapositiva de diseño**

La propiedad [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/placeholder_manager/) proporciona un [LayoutPlaceholderManager](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/) para añadir formas de marcador de posición a un diseño.

| Marcador de posición de PowerPoint | `LayoutPlaceholderManager` método |
| ----------------------------------- | --------------------------------- |
| ![Contenido](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Contenido (vertical)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Texto](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Texto (vertical)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Imagen](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Gráfico](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Tabla](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Multimedia](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Imagen en línea](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

El siguiente ejemplo verifica que el diseño **En blanco** exista, añade cuatro marcadores de posición a él y luego crea una diapositiva normal que utiliza el diseño modificado. El orden es intencional: los marcadores de posición se añaden antes de crear la diapositiva normal, de modo que Aspose.Slides pueda generar las formas de marcador de posición correspondientes en esa diapositiva.

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

![Los marcadores de posición en la diapositiva de diseño](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Cambiar el formato heredado o la geometría de los marcadores de posición del diseño existente puede afectar a las diapositivas dependientes. Un marcador de posición de diseño añadido recientemente no se retropropaga a las diapositivas normales existentes. Pruebe los cambios de diseño en una copia de la presentación e inspeccione cada diapositiva dependiente.
{{% /alert %}}

## **Eliminar diseños de diapositiva no utilizados**

Utilice el método [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) para eliminar los diseños que no son referenciados por ninguna diapositiva normal. El método deja intactos los diseños que aún están en uso.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Para eliminar un diseño específico, primero use su propiedad [has_depending_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/has_depending_slides/) o el método [get_depending_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/get_depending_slides/). Reasigne cualquier diapositiva dependiente antes de llamar a [LayoutSlide.remove](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/remove/). Intentar eliminar un diseño en uso genera una [PptxEditException](https://reference.aspose.com/slides/es/python-net/aspose.slides/pptxeditexception/).

## **Controlar la visibilidad del pie de página en una diapositiva de diseño**

Un diseño tiene sus propios marcadores de posición de pie de página, número de diapositiva y fecha/hora. Utilice la propiedad [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/header_footer_manager/) para controlar esos marcadores de posición en un diseño. Esto es útil cuando, por ejemplo, los diseños de contenido deben mostrar pies de página pero los diseños de título no.

El siguiente ejemplo selecciona un diseño de forma segura y hace visibles sus elementos de pie de página:

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

## **Controlar la visibilidad del pie de página en una maestra y sus diseños hijos**

Para aplicar configuraciones de pie de página coherentes en toda una jerarquía de maestra, utilice la propiedad [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslide/header_footer_manager/). Los métodos de propagación de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslideheaderfootermanager/) actúan sobre la maestra y sus diapositivas de diseño y diapositivas normales dependientes; no se dirigen a una sola diapositiva normal.

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

**¿Cuál es la diferencia entre una diapositiva maestra y una diapositiva de diseño?**

Una diapositiva maestra define el tema de la presentación y el formato compartido. Una diapositiva de diseño pertenece a una maestra y define una disposición reutilizable de marcadores de posición. Las diapositivas normales utilizan esos diseños y almacenan el contenido específico de cada diapositiva.

**¿Puedo copiar una diapositiva de diseño de una presentación a otra?**

Sí. Añada una copia a la colección de destino con el método [add_clone](https://reference.aspose.com/slides/es/python-net/aspose.slides/globallayoutslidecollection/add_clone/). Al copiar entre presentaciones, también verifique fuentes, temas, imágenes y otros recursos utilizados por el diseño origen.

**¿Qué ocurre cuando modifico un diseño que ya está en uso?**

Las diapositivas dependientes heredan los cambios del diseño a menos que sobrescriban localmente el formato u objetos afectados. La geometría de los marcadores de posición y el estilo heredado pueden, por tanto, cambiar en muchas diapositivas a la vez. Utilice [get_depending_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslide/get_depending_slides/) para identificar las diapositivas afectadas antes de editar el diseño.

**¿Qué ocurre si elimino un diseño que todavía está en uso?**

Aspose.Slides genera una [PptxEditException](https://reference.aspose.com/slides/es/python-net/aspose.slides/pptxeditexception/). Reasigne primero las diapositivas dependientes, o utilice [remove_unused_layout_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) para eliminar solo los diseños sin referencias.