---
title: Editar documentos PDF en PHP
linktitle: Editar PDF
type: docs
weight: 65
url: /es/php-java/edit-pdf/
keywords:
- editar PDF
- reemplazar texto PDF
- PDF a PPTX
- PPTX a PDF
- PHP
- Aspose.Slides
description: "Editar documentos PDF en PHP importándolos en Aspose.Slides, reemplazando el texto y guardando la presentación modificada de nuevo en PDF."
---
## **Resumen**

Aspose.Slides for PHP a través de Java le permite editar el contenido de PDF importando sus páginas como diapositivas, modificando la presentación y exportándola de nuevo a PDF. Este artículo muestra un reemplazo de texto sencillo. La presentación permanece en memoria, por lo que guardar un archivo PPTX intermedio es opcional.

## **Reemplazar texto en un PDF**

Utilice [SlideCollection::addFromPdf](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/#addFromPdf) para importar las páginas, [Presentation::replaceText](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#replaceText) para actualizar el texto y [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save) para exportar el resultado.

El siguiente ejemplo supone que `input.pdf` contiene la palabra "Draft" como texto editable después de la importación. Reemplaza esa palabra por "Final" y escribe `edited.pdf`. Vaciar la diapositiva inicial antes de la importación evita una página en blanco adicional en la salida. La búsqueda coincide con palabras completas respetando mayúsculas y minúsculas; `null` indica que no se necesita una devolución de llamada de resultado.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

Para más opciones, consulte [Search and Replace Text](/slides/es/php-java/search-and-replace-text/) y [Convert PowerPoint to PDF](/slides/es/php-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Nota" %}}

El reemplazo de texto funciona sobre el texto importado, no sobre el texto dentro de imágenes escaneadas. La conversión puede afectar al diseño y formato, por lo que es necesario revisar la salida, sobre todo cuando el texto de reemplazo es más largo que el original.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Necesito guardar un archivo PPTX antes de exportar el PDF?**

No. Puede editar y exportar la misma presentación en memoria. Guarde una copia PPTX solo si también desea seguir editándola en PowerPoint; vea [Save Presentations](/slides/es/php-java/save-presentation/).

**¿Por qué puede que algún texto permanezca sin cambios?**

El ejemplo coincide con la palabra completa "Draft" respetando mayúsculas y minúsculas. El texto importado como imagen o dividido en marcos de texto separados no coincidirá necesariamente con la búsqueda. Revise el contenido importado y ajuste la búsqueda para su documento.