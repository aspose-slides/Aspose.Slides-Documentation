---
title: Gestionar encabezados y pies de página de la presentación en Python vía Java
linktitle: Encabezado y pie de página
type: docs
weight: 140
url: /es/python-java/presentation-header-and-footer/
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
- Java
- Aspose.Slides
description: "Aprenda a gestionar los marcadores de posición de pie de página, fecha y hora, número de diapositiva y encabezado en diapositivas, páginas de notas y folletos con Aspose.Slides para Python a través de Java."
---
## **Visión general**

PowerPoint utiliza diferentes marcadores de posición de encabezado y pie de página según el tipo de página. Aspose.Slides for Python via Java le permite controlar el texto y la visibilidad de estos marcadores de posición mediante clases de administrador de encabezado/pie de página.

Los marcadores de posición disponibles dependen del alcance:

| Alcance | Encabezado | Pie de página | Fecha/hora | Número de diapositiva/página |
|---|---|---|---|---|
| Diapositiva normal | No | Sí | Sí | Sí |
| Patrón de notas | Sí | Sí | Sí | Sí |
| Diapositiva de notas | Sí | Sí | Sí | Sí |
| Patrón de folletos | Sí | Sí | Sí | Sí |

Una diapositiva normal de la presentación no tiene un marcador de posición de encabezado. Los encabezados están disponibles en las páginas de notas y en los folletos. En las diapositivas normales, utilice los marcadores de posición de pie de página, fecha/hora y número de diapositiva.

El alcance de un cambio depende del administrador que utilice. La clase [SlideHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideheaderfootermanager/) controla una diapositiva normal. La clase [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/notesslideheaderfootermanager/) controla una diapositiva de notas. Los administradores de patrón y diseño también pueden propagar la configuración a las diapositivas dependientes, mientras que la clase [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) controla el patrón de folletos.

## **Establecer pie de página, fecha/hora y números de diapositiva en diapositivas normales**

Para diapositivas normales, el flujo de trabajo básico consiste en acceder al administrador de encabezado/pie de página de cada diapositiva, establecer el texto del pie de página y de la fecha/hora, habilitar los marcadores de posición requeridos y guardar la presentación. Los números de diapositiva son generados por la presentación, por lo que solo necesita controlar su visibilidad.

Utilice [setFooterText](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) y [setDateTimeText](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText) para establecer el texto, y [setFooterVisibility](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) y [setSlideNumberVisibility](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility) para mostrar los marcadores de posición correspondientes.

El siguiente ejemplo integral aplica el mismo pie de página, texto de fecha/hora y visibilidad del número de diapositiva a todas las diapositivas normales:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Si necesita actualizar solo una diapositiva, acceda a esa diapositiva directamente mediante el método [getSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getSlides) en lugar de iterar por toda la colección.

## **Establecer encabezados y pies de página en el patrón de notas**

El patrón de notas define el formato común y el comportamiento de los marcadores de posición para las páginas de notas. Utilice la clase [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/masternotesslideheaderfootermanager/) cuando desee modificar solo el propio patrón de notas.

El siguiente ejemplo establece el encabezado, pie de página y texto de fecha/hora en el patrón de notas y hace visibles todos los marcadores de posición compatibles en ese patrón:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

El método `getMasterNotesSlide` devuelve `None` cuando la presentación no contiene un patrón de notas.

## **Aplicar la configuración del patrón de notas a las diapositivas de notas hijas**

Un patrón de notas puede aplicar la configuración de encabezado y pie de página a sí mismo y a todas las diapositivas de notas dependientes. Utilice los métodos de propagación dedicados en [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/masternotesslideheaderfootermanager/) cuando los mismos ajustes deban aplicarse a toda la jerarquía de notas.

Por ejemplo, [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/es/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) y [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/es/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) actualizan el encabezado del patrón de notas y todos los encabezados hijos. Existen métodos equivalentes para pies de página, fecha/hora y números de diapositiva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Los métodos de propagación utilizados anteriormente son [setFooterAndChildFootersText](https://reference.aspose.com/slides/es/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/es/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/es/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/es/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) y [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/es/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Establecer encabezados y pies de página en una diapositiva de notas individual**

Una diapositiva de notas pertenece a una diapositiva normal específica. Utilice su clase [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/notesslideheaderfootermanager/) cuando desee personalizar solo esa página de notas.

El método [addNotesSlide](https://reference.aspose.com/slides/es/python-java/aspose.slides/notesslidemanager/#addNotesSlide) devuelve la diapositiva de notas para la diapositiva actual y crea una si aún no existe. El siguiente ejemplo configura la página de notas asociada a la primera diapositiva de la presentación:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Si primero propaga la configuración desde el patrón de notas y luego modifica una diapositiva de notas individual, la configuración posterior por diapositiva le permite personalizar esa página de notas de forma independiente.

## **Establecer encabezados y pies de página en el patrón de folletos**

Las páginas de folletos utilizan el patrón de folletos para sus marcadores de posición de encabezado, pie de página, fecha/hora y número de página. A diferencia de las páginas de notas, la configuración de los folletos se gestiona a través del patrón de folletos y no mediante diapositivas de folleto individuales.

Utilice el método `getMasterHandoutSlide` para acceder al patrón de folletos. Si no está presente, llame a `setDefaultMasterHandoutSlide` para crear el patrón de folletos predeterminado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Comprender el alcance y la herencia**

Elija el administrador de encabezado/pie de página que coincida con el alcance que desea modificar:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/slideheaderfootermanager/) cambia la configuración de pie de página, fecha/hora y número de diapositiva para una diapositiva normal.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/layoutslideheaderfootermanager/) controla una diapositiva de diseño y puede propagar la configuración compatible a diapositivas dependientes.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterslideheaderfootermanager/) controla un patrón de diapositivas normal y puede propagar la configuración compatible a diapositivas dependientes.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/masternotesslideheaderfootermanager/) controla el patrón de notas y puede propagar la configuración a todas las diapositivas de notas dependientes.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/notesslideheaderfootermanager/) cambia una diapositiva de notas y admite un marcador de posición de encabezado además del pie de página, fecha/hora y número de diapositiva.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/es/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) cambia el patrón de folletos y admite los cuatro tipos de marcadores de posición.

Utilice la propagación desde un patrón o diseño cuando el mismo ajuste deba aplicarse a toda su jerarquía. Use un administrador de diapositiva individual o de diapositiva de notas cuando necesite una configuración local para una sola página.

## **Preguntas frecuentes**

**¿Puedo añadir un encabezado a una diapositiva normal?**

No. PowerPoint no define un marcador de posición de encabezado para las diapositivas normales. En las diapositivas normales, utilice los marcadores de posición de pie de página, fecha/hora y número de diapositiva. Los marcadores de posición de encabezado están disponibles en las páginas de notas y en los folletos.

**¿Qué ocurre si un marcador de posición de pie de página, fecha/hora o número de diapositiva no es visible?**

Utilice el administrador de encabezado/pie de página correspondiente para comprobar su visibilidad y habilitarlo cuando sea necesario. Por ejemplo, [isFooterVisible](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) indica si hay un marcador de posición de pie de página, y [setFooterVisibility](https://reference.aspose.com/slides/es/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) cambia su visibilidad.

**¿Cómo inicio la numeración de diapositivas a partir de un valor distinto de 1?**

Llame al método [setFirstSlideNumber](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#setFirstSlideNumber) de la presentación. Los marcadores de posición de número de diapositiva utilizarán entonces la secuencia de numeración actualizada.

**¿Qué sucede con los encabezados y pies de página al exportar a PDF, imágenes o HTML?**

Los elementos visibles de encabezado y pie de página se renderizan junto con el resto del contenido de la presentación en el formato de salida. Su apariencia depende del tipo de página que se exporta y de la configuración de visibilidad de los marcadores de posición correspondientes.