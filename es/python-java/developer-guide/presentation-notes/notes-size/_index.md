---
title: Cambiar el tamaño y la orientación de la página de notas en Python mediante Java
linktitle: Tamaño de página de notas
type: docs
weight: 10
url: /es/python-java/notes-size/
keywords:
- tamaño de página de notas
- orientación de notas
- notas en horizontal
- notas en vertical
- tamaño de folleto
- PowerPoint
- presentación
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Leer y cambiar las dimensiones de la página de notas en Aspose.Slides para Python mediante Java, cambiar la orientación, verificar los tamaños guardados y exportar notas o folletos a PDF e imágenes."
---
## **Descripción general**

Utilice [Presentation.getNotesSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getNotesSize) para acceder a la configuración de la página de notas de la presentación. Devuelve un objeto [NotesSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/notessize/) cuyo método [setSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/notessize/#setSize) establece las dimensiones de la página. Aunque el objeto de configuración no puede ser reemplazado, puede asignar nuevas dimensiones mediante este método.

El ancho y la altura se especifican en **puntos**, con 72 puntos por pulgada. Por ejemplo, 900 × 600 puntos equivalen a 12,5 × 8⅓ pulgadas. Estas configuraciones se aplican a la presentación, en lugar de a las notas de una diapositiva individual.

| Configuración | Propósito |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getNotesSize) | Controla las dimensiones de la página de notas y las dimensiones de página usadas para la exportación de folletos. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSlideSize) | Controla las dimensiones de las diapositivas regulares de la presentación a través de [SlideSize](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidesize/). |

Cambiar cualquiera de las configuraciones no modifica automáticamente la otra. Cambiar la orientación de la página de notas tampoco rota las diapositivas regulares. Consulte [Slide Size](/slides/es/python-java/slide-size/) para cambiar el tamaño de las diapositivas regulares.

Los ejemplos siguientes usan un `sample.pptx` existente. Para los ejemplos de exportación, utilice una presentación con al menos una diapositiva que contenga notas del orador. Cada ejemplo puede ejecutarse de forma independiente.

## **Leer el tamaño y la orientación de la página de notas**

Lea el ancho y la altura y compárelos para determinar la orientación: una página más ancha es horizontal, una página más alta es vertical, y dimensiones iguales describen una página cuadrada. Este ejemplo muestra las dimensiones reales en puntos, sin suponer un tamaño de papel estándar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **Cambiar a horizontal sin cambiar el tamaño del papel**

Para cambiar solo la orientación, intercambie el ancho y la altura existentes. Esto conserva la longitud de ambos lados, incluidas las de un tamaño de papel personalizado. La condición a continuación impide que una página ya horizontal se vuelva a cambiar a vertical y deja una página cuadrada sin modificar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para orientación vertical, utilice la misma asignación cuando `size.getWidth() > size.getHeight()`. No sustituya dimensiones A4 o Letter a menos que también desee cambiar el tamaño del papel.

## **Establecer y verificar un tamaño de página de notas personalizado**

Asigne ambas dimensiones a la vez, y luego use [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) para escribir la presentación. Este ejemplo establece una página horizontal de 900 × 600 puntos, la guarda como PPTX y vuelve a abrir el archivo guardado para comprobar los valores persistidos. La comparación permite una tolerancia de 0,01 puntos para valores de punto flotante; no garantiza precisión para todos los formatos de archivo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

El resultado esperado es `900.0 x 600.0 points` y `Size preserved: True`. Comprobar una presentación recién abierta verifica el archivo guardado, en lugar de solo la configuración en memoria.

## **Exportar notas y folletos**

Las dimensiones de la página definen el área disponible para los diseños de notas o folletos. No habilitan esos diseños por sí mismas: configure también las opciones de exportación. La exportación de diapositivas regulares continúa usando las dimensiones de la diapositiva.

### **Exportar notas a PDF y PNG**

Asigne [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/notescommentslayoutingoptions/) a [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) para incluir notas en el PDF. Este ejemplo también renderiza la primera diapositiva con notas a PNG usando [Slide.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage) y [RenderingOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/renderingoptions/).

El modo [BottomTruncated](https://reference.aspose.com/slides/es/python-java/aspose.slides/notespositions/) mantiene las notas en una sola página; las notas que no caben pueden truncarse. El PDF usa páginas de 900 × 600 puntos. Con la escala de imagen 1 × 1 utilizada a continuación, el PNG es de 900 × 600 píxeles. Los puntos describen la geometría de la página; los píxeles describen la salida raster, cuyas dimensiones también dependen de la escala de renderizado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Para la exportación a PDF con notas largas, [BottomFull](https://reference.aspose.com/slides/es/python-java/aspose.slides/notespositions/) permite páginas adicionales según sea necesario. No use ese modo con la llamada de imagen de una sola diapositiva anterior, que no lo admite. Después de cambiar el tamaño, inspeccione la salida en busca de notas recortadas y la ubicación de los objetos maestros de notas existentes; cambiar solo las dimensiones de la página no garantiza que todo el contenido quepa. Consulte [Convert PowerPoint to PDF with Notes](/slides/es/python-java/convert-powerpoint-to-pdf-with-notes/) para obtener más información sobre la exportación de notas.

### **Exportar folletos a PDF**

Utilice [HandoutLayoutingOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/handoutlayoutingoptions/) para varias miniaturas de diapositivas en una página. El ejemplo siguiente establece una página de 900 × 600 puntos y usa [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/es/python-java/aspose.slides/handouttype/) para organizar hasta cuatro diapositivas por página. La preconfiguración horizontal controla el orden de las diapositivas; la orientación de la página proviene de su ancho y altura.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Cambiar el tamaño de la página modifica el área disponible para la cuadrícula de folletos sin cambiar las dimensiones de las diapositivas de origen. Para imágenes de folletos, use [Presentation.getImages](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getImages) con el diseño de folletos, en lugar del método de imagen de una diapositiva individual. En Aspose.Slides, la renderización de folletos a nivel de presentación usa las dimensiones de la página de notas, mientras que la llamada de imagen de diapositiva individual no produce la página de folletos. Consulte [Handout Mode](/slides/es/python-java/convert-powerpoint-in-handout-mode/) para opciones de diseño.

## **Tamaño de página en visores, exportación e impresión**

Mantenga el tamaño de la presentación almacenado, el tamaño de página exportado y el tamaño de papel impreso por separado:

- **Visores de presentaciones:** Un visor puede mostrar o imprimir notas usando sus propias reglas de diseño. Si otra aplicación guarda el archivo, ábralo nuevamente y compruebe las dimensiones; la conversión de formato de esa aplicación puede normalizarlas.
- **Formatos de exportación:** Los ejemplos de PDF de notas y folletos anteriores usan las dimensiones de página configuradas. Las imágenes raster utilizan dimensiones de píxel enteras y una escala de renderizado, por lo que los valores fraccionarios de puntos pueden redondearse en la salida de la imagen. Exportar diapositivas regulares no aplica el tamaño de la página de notas.
- **Controladores de impresora:** La selección de papel, la rotación automática y la configuración de ajuste a página pueden cambiar la salida física sin modificar las dimensiones almacenadas en la presentación o en el PDF. Para un tamaño de papel específico, coincida con la configuración de la impresora y revise la vista previa de impresión.

## **Preguntas frecuentes**

**¿Puedo establecer el tamaño de las notas solo para una diapositiva?**

El tamaño de la página de notas es una configuración a nivel de presentación. Cada diapositiva puede contener contenido de notas diferente, pero esta propiedad no proporciona un tamaño de página separado para cada diapositiva.

**¿Por qué cambiar la orientación de las notas no cambió mis diapositivas?**

Las páginas de notas y las diapositivas regulares tienen dimensiones independientes. Use la configuración del tamaño de diapositiva regular cuando desee cambiar el tamaño de las propias diapositivas.

**¿Por qué mi resultado guardado o impreso tiene un tamaño diferente?**

Primero abra nuevamente la presentación guardada y compare sus dimensiones de notas. Si estas cambiaron, verifique si guardar o convertir el archivo en otra aplicación modificó la configuración de página. Si no lo hizo, revise el diseño de exportación, la escala de imagen, la configuración del visor y la selección de papel de la impresora.