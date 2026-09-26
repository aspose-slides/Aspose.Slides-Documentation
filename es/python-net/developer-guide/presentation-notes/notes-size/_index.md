---
title: Cambiar el tamaño y la orientación de la página de notas en Python
linktitle: Tamaño de la página de notas
type: docs
weight: 10
url: /es/python-net/notes-size/
keywords:
- tamaño de la página de notas
- orientación de notas
- notas en paisaje
- notas en retrato
- tamaño del folleto
- PowerPoint
- presentación
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Lea y cambie las dimensiones de la página de notas en Aspose.Slides para Python a través de .NET, cambie la orientación, verifique los tamaños guardados y exporte notas o folletos a PDF e imágenes."
---
## **Visión general**

Utilice [Presentation.notes_size](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/notes_size/) para acceder a la configuración de la página de notas de la presentación. Devuelve un objeto [NotesSize](https://reference.aspose.com/slides/es/python-net/aspose.slides/notessize/) cuyo la propiedad [size](https://reference.aspose.com/slides/es/python-net/aspose.slides/notessize/size/) es editable. Aunque el objeto de configuración es de solo lectura, puede asignar nuevas dimensiones a su propiedad size.

El ancho y la altura se especifican en **puntos**, con 72 puntos por pulgada. Por ejemplo, 900 × 600 puntos equivale a 12,5 × 8⅓ pulgadas. Estas configuraciones se aplican a la presentación, en lugar de a las notas de una diapositiva individual.

| Configuración | Propósito |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/notes_size/) | Controla las dimensiones de la página de notas y las dimensiones de página usadas para la exportación de folletos. |
| [Presentation.slide_size](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/slide_size/) | Controla las dimensiones de las diapositivas regulares de la presentación a través de [SlideSize](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidesize/). |

Cambiar cualquiera de las configuraciones no altera automáticamente la otra. Cambiar la orientación de la página de notas tampoco gira las diapositivas regulares. Consulte [Slide Size](/slides/es/python-net/slide-size/) para redimensionar las diapositivas regulares.

Los ejemplos a continuación usan un archivo `sample.pptx` existente. Para los ejemplos de exportación, utilice una presentación que contenga al menos una diapositiva con notas del orador. Cada ejemplo puede ejecutarse de forma independiente.

## **Leer el tamaño y la orientación de la página de notas**

Lea el ancho y la altura y compárelos para determinar la orientación: una página más ancha es horizontal, una página más alta es vertical, y dimensiones iguales describen una página cuadrada. Este ejemplo muestra las dimensiones reales en puntos, sin suponer un tamaño de papel estándar.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **Cambiar a horizontal sin modificar el tamaño del papel**

Para cambiar solo la orientación, intercambie el ancho y la altura existentes. Esto preserva las longitudes de ambos lados, incluidos los de un tamaño de papel personalizado. La condición a continuación evita que una página ya horizontal se vuelva a cambiar a vertical y deja una página cuadrada sin cambios.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

Para orientación vertical, utilice la misma asignación cuando `size.width > size.height`. No sustituya dimensiones de A4 o Letter a menos que también quiera cambiar el tamaño del papel.

## **Establecer y verificar un tamaño de página de notas personalizado**

Asigne ambas dimensiones juntas, luego use [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/save/) para guardar la presentación. Este ejemplo establece una página horizontal de 900 × 600 puntos, la guarda como PPTX y vuelve a abrir el archivo guardado para comprobar los valores persistidos. La comparación permite una tolerancia de 0,01 puntos para valores de punto flotante; no garantiza precisión para cada formato de archivo.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

El resultado esperado es `900 x 600 points` y `Size preserved: True`. Verificar una presentación recién abierta confirma el archivo guardado, en lugar de solo las configuraciones en memoria.

## **Exportar notas y folletos**

Las dimensiones de la página definen el área disponible para los diseños de notas o folletos. No activan esos diseños por sí mismas: también debe configurar las opciones de exportación. La exportación de diapositivas regulares sigue utilizando las dimensiones de la diapositiva.

### **Exportar notas a PDF y PNG**

Asigne [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/notescommentslayoutingoptions/) a [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) para incluir notas en el PDF. Este ejemplo también renderiza la primera diapositiva con notas a PNG usando [Slide.get_image](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/get_image/) y [RenderingOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/renderingoptions/).

El modo [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/notespositions/) mantiene las notas en una sola página; las notas que no quepan pueden truncarse. El PDF utiliza páginas de 900 × 600 puntos. Con la escala de imagen 1 × 1 usada a continuación, el PNG tiene 900 × 600 píxeles. Los puntos describen la geometría de la página; los píxeles describen la salida raster, cuyas dimensiones también dependen de la escala de renderizado.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

Para la exportación a PDF con notas largas, [BOTTOM_FULL](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/notespositions/) permite páginas adicionales según sea necesario. No utilice ese modo con la llamada de imagen de una sola diapositiva anterior, que no lo admite. Después de redimensionar, inspeccione la salida en busca de notas recortadas y la ubicación de los objetos notes‑master existentes; cambiar solo las dimensiones de la página no debe considerarse una garantía de que todo el contenido encajará. Consulte [Convert PowerPoint to PDF with Notes](/slides/es/python-net/convert-powerpoint-to-pdf-with-notes/) para obtener más información sobre la exportación de notas.

### **Exportar folletos a PDF**

Utilice [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/handoutlayoutingoptions/) para varias miniaturas de diapositivas en una página. El siguiente ejemplo establece una página de 900 × 600 puntos y usa [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/handouttype/) para organizar hasta cuatro diapositivas por página. El preset horizontal controla el orden de las diapositivas; la orientación de la página proviene de su ancho y altura.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Cambiar el tamaño de la página modifica el área disponible para la cuadrícula de folletos sin cambiar las dimensiones de las diapositivas origen. Para imágenes de folletos, use [Presentation.get_images](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/get_images/) con el diseño de folletos, en lugar del método de imagen de una diapositiva individual. En Aspose.Slides, el renderizado de folletos a nivel de presentación utiliza las dimensiones de la página de notas, mientras que la llamada de imagen de diapositiva individual no produce la página de folleto. Consulte [Handout Mode](/slides/es/python-net/convert-powerpoint-in-handout-mode/) para opciones de diseño.

## **Tamaño de página en visores, exportación e impresión**

- **Visores de presentaciones:** Un visor puede mostrar o imprimir notas usando sus propias reglas de diseño. Si otra aplicación guarda el archivo, vuelva a abrirlo y compruebe las dimensiones nuevamente; la conversión de formato de esa aplicación puede normalizarlas.
- **Formatos de exportación:** Los ejemplos de PDF de notas y folletos anteriores usan las dimensiones de página configuradas. Las imágenes raster utilizan dimensiones de píxel enteras y una escala de renderizado, por lo que los valores fraccionarios de puntos pueden redondearse en la salida de imagen. Exportar diapositivas regulares no aplica el tamaño de página de notas.
- **Controladores de impresora:** La selección de papel, la rotación automática y la configuración de ajustar al papel pueden cambiar la salida física sin modificar las dimensiones almacenadas en la presentación o PDF. Para un tamaño de papel específico, ajuste la configuración de la impresora y revise la vista previa de impresión.

## **Preguntas frecuentes**

**¿Puedo establecer el tamaño de notas solo para una diapositiva?**

El tamaño de la página de notas es una configuración a nivel de presentación. Las diapositivas individuales pueden tener contenido de notas diferente, pero esta propiedad no proporciona un tamaño de página separado para cada diapositiva.

**¿Por qué al cambiar la orientación de las notas no cambiaron mis diapositivas?**

Las páginas de notas y las diapositivas regulares tienen dimensiones independientes. Utilice la configuración de tamaño de diapositiva regular cuando desee redimensionar las propias diapositivas.

**¿Por qué mi resultado guardado o impreso tiene un tamaño diferente?**

Primero vuelva a abrir la presentación guardada y compare sus dimensiones de notas. Si esas cambiaron, compruebe si al guardar o convertir el archivo en otra aplicación se modificaron los ajustes de página. Si no fue así, revise el diseño de exportación, la escala de imagen, la configuración del visor y la selección de papel de la impresora.