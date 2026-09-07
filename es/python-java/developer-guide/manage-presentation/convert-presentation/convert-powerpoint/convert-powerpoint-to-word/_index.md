---
title: Convertir presentaciones de PowerPoint a documentos Word en Python mediante Java
linktitle: PowerPoint a Word
type: docs
weight: 110
url: /es/python-java/convert-powerpoint-to-word/
keywords:
- convertir PowerPoint
- convertir presentación
- PowerPoint a Word
- presentación a Word
- PPT a Word
- PPTX a Word
- ODP a Word
- PowerPoint a DOCX
- PPT a DOCX
- PPTX a DOCX
- PowerPoint a DOC
- guardar PPT como DOCX
- guardar PPTX como DOCX
- exportar PPT a DOCX
- exportar PPTX a DOCX
- Python
- Java
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint y OpenDocument a Word en Python mediante Java con Aspose.Slides y Aspose.Words, combinando imágenes de diapositivas con texto editable."
---
## **Descripción general**

Este artículo explica cómo convertir presentaciones de PowerPoint y OpenDocument a documentos Word utilizando Aspose.Slides for Python via Java junto con Aspose.Words for Java. Aspose.Slides renderiza cada diapositiva y lee su texto, mientras que Aspose.Words crea el documento Word mediante JPype. No se requiere Microsoft Office.

El documento resultante contiene una imagen de la diapositiva seguida del texto editable extraído de las formas automáticas de nivel superior de esa diapositiva. La imagen conserva la apariencia visual de la diapositiva; las formas individuales, gráficos y tablas no se convierten en objetos editables de Word. El texto extraído no conserva el formato ni la posición original del texto.

## **Convertir PowerPoint a Word**

1. Instale [Aspose.Slides for Python via Java](/slides/es/python-java/installation/) y un runtime de Java compatible.
2. Descargue [Aspose.Words for Java](https://releases.aspose.com/words/java/). Coloque su archivo JAR principal en un directorio `lib` junto a su script y renómbrelo a `aspose-words.jar`, o ajuste la ruta en el ejemplo para que coincida con el archivo descargado.
3. Coloque la presentación de entrada, `sample.pptx`, en el directorio de trabajo. La ruta `lib/aspose-words.jar` también es relativa a ese directorio.
4. Ejecute el siguiente código Python para crear `output.docx`.

El ejemplo carga la fuente con [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) y renderiza las diapositivas con [Slide.getImage](https://reference.aspose.com/slides/es/python-java/aspose.slides/slide/#getImage). Utiliza [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) de Aspose.Words para insertar las imágenes y el texto en el documento Word.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # Ajustar la imagen de la diapositiva al ancho del área de texto, preservando su relación de aspecto.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Agregar texto plano de las formas automáticas de nivel superior, incluidas las cajas de texto.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

Cada diapositiva comienza en una nueva página. Un texto extraído largo o imágenes de diapositivas inusualmente altas pueden requerir páginas adicionales. El código agrega saltos de página solo entre diapositivas y libera la presentación y las imágenes renderizadas en bloques `finally`. La JVM permanece disponible para conversiones posteriores en el mismo proceso Python.

## **Preguntas frecuentes**

**¿Qué bibliotecas son necesarias?**

Utilice Aspose.Slides for Python via Java, JPype, un runtime de Java compatible y Aspose.Words for Java. Ambas bibliotecas Aspose se ejecutan en la misma JVM. Aspose.Slides se encarga de la presentación; Aspose.Words escribe el documento Word.

**¿Puedo convertir archivos PPT y ODP además de PPTX?**

Sí. Reemplace `sample.pptx` por un archivo PPT u ODP. Consulte [Supported File Formats](/slides/es/python-java/supported-file-formats/) para los formatos de entrada de presentaciones.

**¿Todo el contenido de la diapositiva es editable en Word?**

No. Cada diapositiva se inserta como una imagen estática, con texto plano de las formas automáticas de nivel superior añadido debajo. El texto dentro de grupos, tablas, SmartArt y gráficos, así como las notas del presentador, no se extrae en este ejemplo. Las animaciones y transiciones no se reproducen en el documento Word.

**¿Puedo guardar como DOC en lugar de DOCX?**

Sí. Cambie el nombre del archivo de salida a `output.doc`. Aspose.Words selecciona el formato de salida a partir de la extensión del nombre de archivo cuando se utiliza esta sobrecarga de guardado.