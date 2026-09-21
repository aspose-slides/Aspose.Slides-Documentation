---
title: Editar documentos PDF en Python mediante Java
linktitle: Editar PDF
type: docs
weight: 65
url: /es/python-java/edit-pdf/
keywords:
- editar PDF
- reemplazar texto PDF
- PDF a PPTX
- PPTX a PDF
- Python
- Java
- Aspose.Slides
description: "Edite documentos PDF en Python mediante Java importándolos en Aspose.Slides, reemplazando texto y guardando la presentación modificada nuevamente en PDF."
---
## **Visión general**

Aspose.Slides for Python via Java le permite editar contenido PDF importando sus páginas como diapositivas, modificando la presentación y exportándola nuevamente a PDF. Este artículo muestra un reemplazo de texto sencillo. La presentación permanece en memoria, por lo que guardar un archivo PPTX intermedio es opcional.

## **Reemplazar texto en un PDF**

Utilice [addFromPdf](https://reference.aspose.com/slides/es/python-java/aspose.slides/slidecollection/#addFromPdf) para importar las páginas, [replaceText](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#replaceText) para actualizar el texto y [save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) para exportar el resultado.

El siguiente ejemplo supone que `input.pdf` contiene la palabra "Draft" como texto editable después de la importación. Reemplaza esa palabra por "Final" y escribe `edited.pdf`. Vaciar la diapositiva inicial antes de la importación evita una página en blanco extra en la salida. La búsqueda coincide con palabras completas respetando mayúsculas y minúsculas; `None` indica que no se necesita una devolución de llamada de resultado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Para obtener más opciones, consulte [Search and Replace Text](/slides/es/python-java/search-and-replace-text/) y [Convert PowerPoint to PDF](/slides/es/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}

El reemplazo de texto funciona sobre el texto importado, no sobre el texto dentro de imágenes escaneadas. La conversión puede afectar el diseño y el formato, por lo que es conveniente revisar la salida, especialmente cuando el texto de reemplazo es más largo que el original.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Necesito guardar un archivo PPTX antes de exportar el PDF?**

No. Puede editar y exportar la misma presentación en memoria. Guarde una copia PPTX solo si también desea continuar editándola en PowerPoint; vea [Save Presentations](/slides/es/python-java/save-presentation/).

**¿Por qué puede quedar algún texto sin cambiar?**

El ejemplo coincide con la palabra completa "Draft" respetando mayúsculas y minúsculas. El texto importado como imagen o dividido en varios marcos de texto no coincidirá necesariamente con la búsqueda. Revise el contenido importado y ajuste la búsqueda para su documento.