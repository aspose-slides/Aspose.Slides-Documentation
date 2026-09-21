---
title: Editar documentos PDF en C++
linktitle: Editar PDF
type: docs
weight: 65
url: /es/cpp/edit-pdf/
keywords:
- editar PDF
- reemplazar texto PDF
- PDF a PPTX
- PPTX a PDF
- C++
- Aspose.Slides
description: "Edite documentos PDF en C++ importándolos en Aspose.Slides, reemplazando texto y guardando la presentación modificada de nuevo en PDF."
---
## **Visión general**

Aspose.Slides for C++ le permite editar contenido PDF importando sus páginas como diapositivas, modificando la presentación y exportándola de nuevo a PDF. Este artículo muestra un reemplazo de texto sencillo. La presentación permanece en memoria, por lo que guardar un archivo PPTX intermedio es opcional.

## **Reemplazar texto en un PDF**

Utilice [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/es/cpp/aspose.slides/slidecollection/addfrompdf/) para importar las páginas, [Presentation::ReplaceText](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/replacetext/) para actualizar el texto y [Presentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/save/) para exportar el resultado.

El siguiente ejemplo asume que `input.pdf` contiene la palabra "Draft" como texto editable tras la importación. Reemplaza esa palabra por "Final" y escribe `edited.pdf`. Vaciar la diapositiva inicial antes de la importación evita una página en blanco adicional en la salida. La búsqueda coincide con palabras completas respetando mayúsculas y minúsculas; `nullptr` indica que no se necesita una devolución de llamada de resultado.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

Para más opciones, consulte [Buscar y reemplazar texto](/slides/es/cpp/search-and-replace-text/) y [Convertir PowerPoint a PDF](/slides/es/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
El reemplazo de texto funciona sobre el texto importado, no sobre el texto dentro de imágenes escaneadas. La conversión puede afectar el diseño y el formato, por lo que es necesario revisar la salida, especialmente cuando el texto de reemplazo es más largo que el original.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Necesito guardar un archivo PPTX antes de exportar el PDF?**

No. Puede editar y exportar la misma presentación en memoria. Guarde una copia PPTX solo si también desea seguir editándola en PowerPoint; consulte [Guardar presentaciones](/slides/es/cpp/save-presentation/).

**¿Por qué puede que parte del texto quede sin cambios?**

El ejemplo coincide con la palabra completa "Draft" respetando mayúsculas y minúsculas. El texto importado como imagen o dividido en varios marcos de texto no necesariamente coincidirá con la búsqueda. Revise el contenido importado y ajuste la búsqueda para su documento.