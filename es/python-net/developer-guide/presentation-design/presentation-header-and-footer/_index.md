---
title: Encabezado y Pie de Página de Presentación
type: docs
weight: 140
url: /es/python-net/presentation-header-and-footer/
keywords: "Encabezado, pie de página, establecer encabezado, establecer pie de página, establecer encabezado y pie de página, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Encabezado y pie de página de PowerPoint en Python"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/es/python-net/) proporciona soporte para trabajar con el texto de los encabezados y pies de página de las diapositivas que en realidad se mantienen a nivel de maestro de diapositivas.

{{% /alert %}} 

[Aspose.Slides para Python a través de .NET](/slides/es/python-net/) proporciona la característica para gestionar los encabezados y pies de página dentro de las diapositivas de presentación. Estos de hecho se gestionan a nivel de maestro de presentación.
## **Gestionar Texto de Encabezado y Pie de Página**
Las notas de una diapositiva específica podrían actualizarse como se muestra en el ejemplo a continuación:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Método para establecer texto de Encabezado/Pie de Página
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hola nuevo encabezado"

# Cargar Presentación
with slides.Presentation("combined_with_master.pptx") as pres:
    # Estableciendo Pie de Página
    pres.header_footer_manager.set_all_footers_text("Texto de mi pie de página")
    pres.header_footer_manager.set_all_footers_visibility(True)

    # Acceder y Actualizar Encabezado
    masterNotesSlide = pres.master_notes_slide_manager.master_notes_slide
    if masterNotesSlide is not None:
        update_header_footer_text(masterNotesSlide)

    # guardar presentación
    pres.save("HeaderFooter-out.pptx", slides.export.SaveFormat.PPTX)
```




## **Gestionar Encabezado y Pie de Página en Diapositivas de Entrega y Notas**
Aspose.Slides para Python a través de .NET soporta Encabezado y Pie de Página en diapositivas de entrega y notas. Por favor sigue los pasos a continuación:

- Cargar una [Presentación ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)que contenga un video.
- Cambiar configuraciones de Encabezado y Pie de Página para el maestro de notas y todas las diapositivas de notas.
- Hacer visibles el maestro de notas y todos los marcadores de Pie de Página hijos.
- Hacer visibles el maestro de notas y todos los marcadores de fecha y hora hijos.
- Cambiar configuraciones de Encabezado y Pie de Página solo para la primera diapositiva de notas.
- Hacer visible el marcador de Encabezado de la diapositiva de notas.
- Establecer texto en el marcador de Encabezado de la diapositiva de notas.
- Establecer texto en el marcador de Fecha-hora de la diapositiva de notas.
- Escribir el archivo de presentación modificado.

Fragmento de código proporcionado en el siguiente ejemplo.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("combined_with_master.pptx") as presentation:
	masterNotesSlide = presentation.master_notes_slide_manager.master_notes_slide
	if masterNotesSlide != None:
		headerFooterManager = masterNotesSlide.header_footer_manager

		# hacer visibles el maestro de notas y todos los marcadores de Pie de Página hijos
		headerFooterManager.set_header_and_child_headers_visibility(True) 
		headerFooterManager.set_footer_and_child_footers_visibility(True) 
		headerFooterManager.set_slide_number_and_child_slide_numbers_visibility(True) 
		headerFooterManager.set_date_time_and_child_date_times_visibility(True)

		# establecer texto al maestro de notas y todos los marcadores de Encabezado hijos
		headerFooterManager.set_header_and_child_headers_text("Texto del encabezado") 
		headerFooterManager.set_footer_and_child_footers_text("Texto del pie de página") 
		headerFooterManager.set_date_time_and_child_date_times_text("Texto de fecha y hora") 

	# Cambiar configuraciones de Encabezado y Pie de Página solo para la primera diapositiva de notas
	notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
	if notesSlide != None:
		headerFooterManager = notesSlide.header_footer_manager

		# hacer visible el marcador de Encabezado de la diapositiva de notas

		if not headerFooterManager.is_header_visible:
			headerFooterManager.set_header_visibility(True) 

		if not headerFooterManager.is_footer_visible:
			headerFooterManager.set_footer_visibility(True) 

		if not headerFooterManager.is_slide_number_visible:
			headerFooterManager.set_slide_number_visibility(True) 

		if not headerFooterManager.is_date_time_visible:
			headerFooterManager.set_date_time_visibility(True) 

		# establecer texto en el marcador de Encabezado de la diapositiva de notas
		headerFooterManager.set_header_text("Nuevo texto del encabezado") 
		headerFooterManager.set_footer_text("Nuevo texto del pie de página") 
		headerFooterManager.set_date_time_text("Nuevo texto de fecha y hora") 
	presentation.save("testresult.pptx",slides.export.SaveFormat.PPTX)
```