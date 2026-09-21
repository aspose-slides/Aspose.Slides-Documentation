---
title: Editar documentos PDF en JavaScript
linktitle: Editar PDF
type: docs
weight: 65
url: /es/nodejs-java/edit-pdf/
keywords:
- editar PDF
- reemplazar texto PDF
- PDF a PPTX
- PPTX a PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "Editar documentos PDF en JavaScript importándolos a Aspose.Slides, reemplazando texto y guardando la presentación modificada de nuevo en PDF."
---
## **Resumen**

Aspose.Slides for Node.js a través de Java le permite editar el contenido de PDF importando sus páginas como diapositivas, modificando la presentación y exportándola nuevamente a PDF. Este artículo muestra un reemplazo de texto simple. La presentación permanece en memoria, por lo que guardar un archivo PPTX intermedio es opcional.

## **Reemplazar texto en un PDF**

Utilice [addFromPdf](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slidecollection/#addFromPdf) para importar las páginas, [replaceText](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#replaceText) para actualizar el texto y [save](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#save) para exportar el resultado.

El siguiente ejemplo asume que `input.pdf` contiene la palabra "Draft" como texto editable después de la importación. Reemplaza esa palabra por "Final" y escribe `edited.pdf`. Vaciar la diapositiva inicial antes de la importación evita una página en blanco adicional en el resultado. La búsqueda coincide con palabras completas respetando mayúsculas y minúsculas; `null` indica que no se necesita una devolución de llamada de resultados.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Para más opciones, consulte [Buscar y Reemplazar Texto](/slides/es/nodejs-java/search-and-replace-text/) y [Convertir PowerPoint a PDF](/slides/es/nodejs-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
El reemplazo de texto funciona sobre el texto importado, no sobre el texto dentro de imágenes escaneadas. La conversión puede afectar el diseño y el formato, por lo que debe revisar el resultado, sobre todo cuando el texto de reemplazo es más largo que el original.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Necesito guardar un archivo PPTX antes de exportar el PDF?**

No. Puede editar y exportar la misma presentación en memoria. Guarde una copia en PPTX solo si también desea seguir editándola en PowerPoint; consulte [Guardar presentaciones](/slides/es/nodejs-java/save-presentation/).

**¿Por qué puede quedar algún texto sin cambiar?**

El ejemplo coincide con la palabra completa "Draft" respetando mayúsculas y minúsculas. El texto importado como imagen o dividido en varios marcos de texto no coincidirá necesariamente con la búsqueda. Revise el contenido importado y ajuste la búsqueda para su documento.