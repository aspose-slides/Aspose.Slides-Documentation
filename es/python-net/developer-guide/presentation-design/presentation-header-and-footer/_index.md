---
title: Gestionar encabezados y pies de página de la presentación con Python
linktitle: Encabezado y pie de página
type: docs
weight: 140
url: /es/python-net/presentation-header-and-footer/
keywords:
- encabezado
- texto de encabezado
- pie de página
- texto de pie de página
- establecer encabezado
- establecer pie de página
- folleto
- notas
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda cómo gestionar los marcadores de posición de pie de página, fecha y hora, número de diapositiva y encabezado en diapositivas, páginas de notas y folletos con Aspose.Slides para Python mediante .NET."
---
## **Descripción general**

PowerPoint utiliza diferentes marcadores de posición de encabezado y pie de página según el tipo de página. Aspose.Slides for Python via .NET le permite controlar el texto y la visibilidad de estos marcadores de posición mediante clases de gestión de encabezado/pie de página.

Los marcadores de posición disponibles dependen del ámbito:

| Ámbito | Encabezado | Pie de página | Fecha/hora | Número de diapositiva/página |
|---|---|---|---|---|
| Diapositiva normal | No | Sí | Sí | Sí |
| Patrón de notas | Sí | Sí | Sí | Sí |
| Diapositiva de notas | Sí | Sí | Sí | Sí |
| Patrón de folleto | Sí | Sí | Sí | Sí |

Una diapositiva de presentación normal no tiene un marcador de posición de encabezado. Los encabezados están disponibles en las páginas de notas y en los folletos. Para diapositivas normales, utilice los marcadores de posición de pie de página, fecha/hora y número de diapositiva en su lugar.

El alcance de un cambio depende del gestor que utilice. La clase [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/es/python-net/aspose.slides/slideheaderfootermanager/) controla una diapositiva normal. La clase [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/python-net/aspose.slides/notesslideheaderfootermanager/) controla una diapositiva de notas. Los gestores de patrón y de diseño también pueden propagar la configuración a diapositivas dependientes, mientras que la clase [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) controla el patrón de folleto.

## **Establecer pie de página, fecha/hora y números de diapositiva en diapositivas normales**

Para diapositivas normales, el flujo de trabajo básico consiste en acceder al gestor de encabezado/pie de página de cada diapositiva, establecer el texto del pie de página y de fecha/hora, habilitar los marcadores de posición necesarios y guardar la presentación. Los números de diapositiva son generados por la presentación, por lo que solo necesita controlar su visibilidad.

Utilice [`set_footer_text`](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) y [`set_date_time_text`](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/) para establecer el texto, y utilice [`set_footer_visibility`](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/), y [`set_slide_number_visibility`](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/) para mostrar los marcadores de posición correspondientes.

El siguiente ejemplo completo aplica el mismo pie de página, texto de fecha/hora y visibilidad del número de diapositiva a todas las diapositivas normales:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

Si necesita actualizar solo una diapositiva, acceda a esa diapositiva directamente a través de la colección [`slides`](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/slides/es/) en lugar de iterar por toda la colección.

## **Establecer encabezados y pies de página en el patrón de notas**

El patrón de notas define el formato común y el comportamiento de los marcadores de posición para las páginas de notas. Utilice la clase [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/python-net/aspose.slides/masternotesslideheaderfootermanager/) cuando desee modificar solo el propio patrón de notas.

El siguiente ejemplo establece el texto de encabezado, pie de página y fecha/hora en el patrón de notas y hace visibles todos los marcadores de posición compatibles en ese patrón:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

Una presentación puede no contener un patrón de notas, por lo que debe comprobar el valor devuelto por `None` antes de modificarlo.

## **Aplicar la configuración del patrón de notas a diapositivas de notas hijas**

Un patrón de notas puede aplicar la configuración de encabezado y pie de página a sí mismo y a todas las diapositivas de notas dependientes. Utilice los métodos de propagación dedicados en [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/python-net/aspose.slides/masternotesslideheaderfootermanager/) cuando la misma configuración deba aplicarse a lo largo de la jerarquía de notas.

Por ejemplo, [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/es/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) y [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/es/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) actualizan el encabezado del patrón de notas y todos los encabezados hijos. Existen métodos equivalentes para pies de página, fecha/hora y números de diapositiva.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Los métodos de propagación utilizados anteriormente son [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/es/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/es/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/es/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/es/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), y [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/es/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **Establecer encabezados y pies de página en una diapositiva de notas individual**

Una diapositiva de notas pertenece a una diapositiva regular específica. Utilice su clase [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/python-net/aspose.slides/notesslideheaderfootermanager/) cuando desee personalizar solo esa página de notas.

El método [`add_notes_slide`](https://reference.aspose.com/slides/es/python-net/aspose.slides/notesslidemanager/add_notes_slide/) devuelve la diapositiva de notas para la diapositiva actual y crea una si aún no existe. El siguiente ejemplo configura la página de notas asociada a la primera diapositiva de la presentación:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Si primero propaga la configuración desde el patrón de notas y luego modifica una diapositiva de notas individual, la configuración posterior por diapositiva le permite personalizar esa página de notas de forma independiente.

## **Establecer encabezados y pies de página en el patrón de folleto**

Las páginas de folleto utilizan el patrón de folleto para sus marcadores de posición de encabezado, pie de página, fecha/hora y número de página. A diferencia de las páginas de notas, la configuración de los folletos se gestiona a través del patrón de folleto y no mediante diapositivas de folleto individuales.

Utilice la propiedad [`master_handout_slide`](https://reference.aspose.com/slides/es/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/) para acceder al patrón de folleto. Si no está presente, llame a [`set_default_master_handout_slide`](https://reference.aspose.com/slides/es/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) para crear el patrón de folleto predeterminado.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Entender el alcance y la herencia**

Elija el gestor de encabezado/pie de página que coincida con el alcance que desea cambiar:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/es/python-net/aspose.slides/slideheaderfootermanager/) cambia la configuración de pie de página, fecha/hora y número de diapositiva para una diapositiva normal.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/python-net/aspose.slides/layoutslideheaderfootermanager/) controla una diapositiva de diseño y puede propagar la configuración compatible a diapositivas dependientes.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterslideheaderfootermanager/) controla un patrón de diapositiva normal y puede propagar la configuración compatible a diapositivas dependientes.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/python-net/aspose.slides/masternotesslideheaderfootermanager/) controla el patrón de notas y puede propagar la configuración a todas las diapositivas de notas dependientes.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/python-net/aspose.slides/notesslideheaderfootermanager/) modifica una diapositiva de notas y admite un marcador de posición de encabezado además del pie de página, fecha/hora y número de diapositiva.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/es/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) modifica el patrón de folleto y admite los cuatro tipos de marcadores de posición.

Utilice la propagación desde un patrón o diseño cuando la misma configuración deba aplicarse a lo largo de su jerarquía. Utilice un gestor de diapositiva individual o de diapositiva de notas cuando necesite una configuración local para una página.

## **Preguntas frecuentes**

**¿Puedo añadir un encabezado a una diapositiva normal?**

No. PowerPoint no define un marcador de posición de encabezado para diapositivas normales. En las diapositivas normales, use los marcadores de posición de pie de página, fecha/hora y número de diapositiva. Los marcadores de posición de encabezado están disponibles en las páginas de notas y en los folletos.

**¿Qué ocurre si un marcador de posición de pie de página, fecha/hora o número de diapositiva no es visible?**

Utilice el gestor de encabezado/pie de página correspondiente para comprobar su visibilidad y habilitarlo cuando sea necesario. Por ejemplo, [`is_footer_visible`](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) indica si hay un marcador de posición de pie de página, y [`set_footer_visibility`](https://reference.aspose.com/slides/es/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) cambia su visibilidad.

**¿Cómo inicio la numeración de diapositivas a partir de un valor distinto de 1?**

Establezca la propiedad [`first_slide_number`](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/first_slide_number/) de la presentación. Los marcadores de posición de número de diapositiva usarán entonces la secuencia de numeración actualizada.

**¿Qué ocurre con los encabezados y pies de página al exportar a PDF, imágenes o HTML?**

Los elementos de encabezado y pie de página visibles se renderizan junto con el resto del contenido de la presentación en el formato de salida. Su apariencia depende del tipo de página que se exporta y de la configuración de visibilidad de los marcadores de posición correspondientes.