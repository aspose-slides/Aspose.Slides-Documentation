---
title: Editar documentos PDF en Android
linktitle: Editar PDF
type: docs
weight: 65
url: /es/androidjava/edit-pdf/
keywords:
- editar PDF
- reemplazar texto PDF
- PDF a PPTX
- PPTX a PDF
- Android
- Java
- Aspose.Slides
description: "Edite documentos PDF en Android con Java importándolos a Aspose.Slides, reemplazando texto y guardando la presentación modificada nuevamente en PDF."
---
## **Visión general**

Aspose.Slides for Android via Java le permite editar contenido PDF importando sus páginas como diapositivas, modificando la presentación y exportándola nuevamente a PDF. Este artículo muestra un reemplazo de texto sencillo. La presentación permanece en memoria, por lo que guardar un archivo PPTX intermedio es opcional.

## **Reemplazar texto en un PDF**

Use [addFromPdf](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) para importar las páginas, [replaceText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para actualizar el texto y [save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) para exportar el resultado.

El siguiente ejemplo asume que `input.pdf` contiene la palabra "Draft" como texto editable después de la importación. Reemplaza esa palabra por "Final" y escribe `edited.pdf`. Vaciar la diapositiva inicial antes de la importación evita una página en blanco adicional en la salida. La búsqueda coincide con palabras completas respetando mayúsculas y minúsculas; `null` indica que no se necesita una devolución de resultados.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Para más opciones, consulte [Buscar y reemplazar texto](/slides/es/androidjava/search-and-replace-text/) y [Convertir PowerPoint a PDF](/slides/es/androidjava/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}

El reemplazo de texto funciona sobre texto importado, no sobre texto dentro de imágenes escaneadas. La conversión puede afectar el diseño y el formato, por lo que es recomendable revisar la salida, especialmente cuando el texto de sustitución es más largo que el original.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Necesito guardar un archivo PPTX antes de exportar el PDF?**

No. Puede editar y exportar la misma presentación en memoria. Guarde una copia PPTX solo si también desea seguir editándola en PowerPoint; vea [Guardar presentaciones](/slides/es/androidjava/save-presentation/).

**¿Por qué puede quedar algún texto sin cambiar?**

El ejemplo coincide con la palabra completa "Draft" respetando mayúsculas y minúsculas. El texto importado como imagen o dividido en varios marcos de texto no coincidirá necesariamente con la búsqueda. Revise el contenido importado y ajuste la búsqueda para su documento.