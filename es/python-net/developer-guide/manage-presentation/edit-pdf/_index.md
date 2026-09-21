---
title: Editar documentos PDF en Python
linktitle: Editar PDF
type: docs
weight: 65
url: /es/python-net/edit-pdf/
keywords:
- editar PDF
- reemplazar texto PDF
- PDF a PPTX
- PPTX a PDF
- Python
- Aspose.Slides
description: "Edite documentos PDF en Python importándolos en Aspose.Slides, reemplazando el texto y guardando la presentación modificada de nuevo en PDF."
---
## **Descripción general**

Aspose.Slides for Python via .NET le permite editar contenido PDF importando sus páginas como diapositivas, modificando la presentación y exportándola de nuevo a PDF. Este artículo muestra un reemplazo de texto simple. La presentación permanece en memoria, por lo que guardar un archivo PPTX intermedio es opcional.

## **Reemplazar texto en un PDF**

Utilice [add_from_pdf](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/add_from_pdf/) para importar las páginas, [replace_text](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/replace_text/) para actualizar el texto y [save](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/save/) para exportar el resultado.

El siguiente ejemplo asume que `input.pdf` contiene la palabra "Draft" como texto editable después de la importación. Reemplaza esa palabra por "Final" y escribe `edited.pdf`. Limpiar la diapositiva inicial antes de la importación evita una página en blanco adicional en la salida. La búsqueda coincide con palabras completas con el mismo caso de letras; `None` indica que no se necesita una devolución de resultados.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

Para más opciones, vea [Buscar y reemplazar texto](/slides/es/python-net/search-and-replace-text/) y [Convertir PowerPoint a PDF](/slides/es/python-net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
El reemplazo de texto funciona sobre texto importado, no sobre texto dentro de imágenes escaneadas. La conversión puede afectar el diseño y el formato, por lo que debe revisar la salida, especialmente cuando el texto de reemplazo es más largo que el original.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Necesito guardar un archivo PPTX antes de exportar el PDF?**

No. Puede editar y exportar la misma presentación en memoria. Guarde una copia PPTX sólo si también desea seguir editándola en PowerPoint; vea [Guardar presentaciones](/slides/es/python-net/save-presentation/).

**¿Por qué puede quedar algún texto sin cambios?**

El ejemplo coincide con la palabra completa "Draft" con mayúsculas exactas. El texto importado como imagen o dividido en varios marcos de texto no coincidirá necesariamente con la búsqueda. Revise el contenido importado y ajuste la búsqueda para su documento.