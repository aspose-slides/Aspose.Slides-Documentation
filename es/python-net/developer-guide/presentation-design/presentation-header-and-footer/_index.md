---
title: Administrar encabezados y pies de página de presentación con Python
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
- presentación
- Python
- Aspose.Slides
description: "Utilice Aspose.Slides para Python a través de .NET para agregar y personalizar encabezados y pies de página en presentaciones de PowerPoint y OpenDocument, logrando una apariencia profesional."
---

## **Resumen**

Aspose.Slides para Python le permite controlar los marcadores de posición de encabezado y pie de página en toda la presentación con un alcance preciso. El texto del pie de página, la fecha/hora y los números de diapositiva se gestionan a nivel de la diapositiva maestra y pueden aplicarse globalmente o ajustarse por diapositiva. Los encabezados son compatibles en notas y folletos, donde puede alternar su visibilidad y establecer texto para encabezado, pie de página, fecha/hora y número de página mediante el administrador de encabezado y pie de página dedicado en la diapositiva maestra de notas o en diapositivas de notas individuales. Este artículo describe los patrones clave para actualizar estos marcadores de posición y propagar los cambios de manera coherente en todo el conjunto de diapositivas.

## **Administrar texto de encabezado y pie de página**

En esta sección aprenderá a gestionar el contenido de encabezado y pie de página en una presentación: habilitar o modificar el pie de página, la fecha y hora, y los números de diapositiva. Describiremos brevemente los ámbitos de aplicación de estas configuraciones (toda la presentación, diapositivas individuales y vistas de notas/folletos) y mostraremos cómo usar la API de Aspose.Slides para actualizarlas rápida y consistentemente.

El ejemplo de código a continuación abre una presentación, habilita y establece el texto del pie de página, actualiza el texto del encabezado en la diapositiva maestra de notas y guarda el archivo.

```py
import aspose.slides as slides

# Función para establecer el texto del encabezado.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hola, aquí hay un encabezado"


# Cargar la presentación.
with slides.Presentation("sample.pptx") as presentation:
    # Establecer el pie de página.
    presentation.header_footer_manager.set_all_footers_text("Mi texto de pie de página")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Acceder y actualizar el encabezado.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Guardar la presentación.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Administrar encabezado y pie de página en diapositivas de notas**

En esta sección aprenderá a gestionar los encabezados y pies de página específicamente para las diapositivas de notas en Aspose.Slides. Cubriremos la habilitación de los marcadores de posición relevantes, la configuración de texto para pies de página, fecha/hora y números de página, y la aplicación consistente de estos cambios en la maestra de notas y en páginas de notas individuales.

Siga los pasos a continuación:

1. Cargue un archivo de presentación.  
2. Obtenga la diapositiva maestra de notas y su [administrador de encabezado y pie de página](https://reference.aspose.com/slides/python-net/aspose.slides/masternotesslideheaderfootermanager/).  
3. En la diapositiva maestra de notas, habilite la visibilidad de Encabezado, Pie de página, Número de diapositiva y Fecha/hora para la maestra y todas las diapositivas de notas hijas.  
4. En la diapositiva maestra de notas, establezca el texto para Encabezado, Pie de página y Fecha/hora para la maestra y todas las diapositivas de notas hijas.  
5. Obtenga la diapositiva de notas de la primera diapositiva de la presentación y su [administrador de encabezado y pie de página](https://reference.aspose.com/slides/python-net/aspose.slides/notesslideheaderfootermanager/).  
6. Solo para esta primera diapositiva de notas, asegúrese de que Encabezado, Pie de página, Número de diapositiva y Fecha/hora sean visibles (active los que estén desactivados).  
7. Solo para esta primera diapositiva de notas, establezca el texto para Encabezado, Pie de página y Fecha/hora.  
8. Guarde la presentación en formato PPTX.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Hacer visibles los marcadores de posición de encabezado, pie de página, número de diapositiva y fecha/hora en la maestra de notas y en todas sus diapositivas hijas.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Establecer texto en la maestra de notas y en todas sus diapositivas hijas para encabezado, pie de página y fecha/hora.
        header_footer_manager.set_header_and_child_headers_text("Texto del encabezado")
        header_footer_manager.set_footer_and_child_footers_text("Texto del pie de página")
        header_footer_manager.set_date_time_and_child_date_times_text("Texto de fecha y hora")

    # Cambiar la configuración de encabezado, pie de página, número de diapositiva y fecha/hora solo para la primera diapositiva de notas.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Asegurarse de que los marcadores de posición de encabezado, pie de página, número de diapositiva y fecha/hora sean visibles.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Establecer texto en los marcadores de posición de encabezado, pie de página y fecha/hora de la diapositiva de notas.
        header_footer_manager.set_header_text("Nuevo texto de encabezado")
        header_footer_manager.set_footer_text("Nuevo texto de pie de página")
        header_footer_manager.set_date_time_text("Nuevo texto de fecha y hora")

    # Guardar la presentación.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**¿Puedo agregar un "encabezado" a diapositivas normales?**

En PowerPoint, el "Encabezado" sólo existe para notas y folletos; en diapositivas normales, los elementos compatibles son el pie de página, la fecha/hora y el número de diapositiva. En Aspose.Slides esto coincide con las mismas limitaciones: encabezado solo para Notas/Folletos, y en diapositivas—Pie de página/FechaHora/NúmeroDeDiapositiva.

**¿Qué pasa si el diseño no contiene un área de pie de página—puedo "activar" su visibilidad?**

Sí. Verifique la visibilidad mediante el administrador de encabezado/pie de página y habilítela si es necesario. Estos indicadores y métodos de la API están diseñados para casos en los que el marcador de posición falta o está oculto.

**¿Cómo hago que la numeración de diapositivas comience en un valor distinto a 1?**

Establezca el [número de la primera diapositiva](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/first_slide_number/) de la presentación; a partir de ahí, toda la numeración se recalcula. Por ejemplo, puede iniciar en 0 o 10, y ocultar el número en la diapositiva de título.

**¿Qué ocurre con los encabezados/pies de página al exportar a PDF/imagenes/HTML?**

Se renderizan como elementos de texto normales de la presentación. Es decir, si los elementos son visibles en diapositivas/páginas de notas, también aparecerán en el formato de salida junto con el resto del contenido.