---
title: Editar documentos PDF en .NET
linktitle: Editar PDF
type: docs
weight: 65
url: /es/net/edit-pdf/
keywords:
- editar PDF
- reemplazar texto PDF
- PDF a PPTX
- PPTX a PDF
- .NET
- C#
- Aspose.Slides
description: "Edite documentos PDF en C# importándolos en Aspose.Slides, reemplazando texto y guardando la presentación modificada de nuevo en PDF."
---
## **Visión general**

Aspose.Slides for .NET le permite editar el contenido de PDF importando sus páginas como diapositivas, modificando la presentación y exportándola de nuevo a PDF. Este artículo muestra un reemplazo de texto sencillo. La presentación permanece en memoria, por lo que guardar un archivo PPTX intermedio es opcional.

## **Reemplazar texto en un PDF**

Use [AddFromPdf](https://reference.aspose.com/slides/es/net/aspose.slides/slidecollection/addfrompdf/) para importar las páginas, [ReplaceText](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/replacetext/) para actualizar el texto y [Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) para exportar el resultado.

El siguiente ejemplo supone que `input.pdf` contiene la palabra "Draft" como texto editable tras la importación. Reemplaza esa palabra por "Final" y escribe `edited.pdf`. Vaciar la diapositiva inicial antes de la importación evita una página en blanco adicional en el resultado. La búsqueda coincide con palabras completas con el mismo uso de mayúsculas; `null` indica que no se necesita una devolución de llamada de resultado.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

Para más opciones, consulte [Buscar y reemplazar texto](/slides/es/net/search-and-replace-text/) y [Convertir PowerPoint a PDF](/slides/es/net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
El reemplazo de texto funciona con texto importado, no con texto dentro de imágenes escaneadas. La conversión puede afectar el diseño y el formato, por lo que es recomendable revisar el resultado, especialmente cuando el texto de sustitución es más largo que el original.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Necesito guardar un archivo PPTX antes de exportar el PDF?**

No. Puedes editar y exportar la misma presentación en memoria. Guarda una copia en PPTX solo si también deseas seguir editándola en PowerPoint; vea [Guardar presentaciones](/slides/es/net/save-presentation/).

**¿Por qué puede quedar algún texto sin cambiar?**

El ejemplo coincide con la palabra completa "Draft" respetando el caso exacto. El texto importado como imagen o dividido en varios marcos de texto no coincidirá necesariamente con la búsqueda. Revise el contenido importado y ajuste la búsqueda para su documento.