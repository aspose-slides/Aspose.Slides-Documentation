---
title: Importar presentaciones desde PDF o HTML en C++
linktitle: Importar presentación
type: docs
weight: 60
url: /es/cpp/import-presentation/
keywords:
- importar presentación
- importar diapositiva
- importar PDF
- importar HTML
- PDF a presentación
- PDF a PPT
- PDF a PPTX
- PDF a ODP
- HTML a presentación
- HTML a PPT
- HTML a PPTX
- HTML a ODP
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Importa sin esfuerzo documentos PDF y HTML en presentaciones PowerPoint y OpenDocument en C++ con Aspose.Slides para un procesamiento de diapositivas fluido y de alto rendimiento."
---
## **Introducción**

Usando [**Aspose.Slides para C++**](https://products.aspose.com/slides/es/cpp/), puedes importar presentaciones desde archivos en otros formatos. Aspose.Slides proporciona la clase [SlideCollection](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.slide_collection) para permitirte importar presentaciones desde PDF, documentos HTML, etc.

## **Importar PowerPoint desde PDF**

En este caso, conviertes un PDF a una presentación PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Instanciar un objeto de la clase Presentation.  
2. Llamar al método [AddFromPdf()](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) y pasar el archivo PDF.  
3. Usar el método [Save()](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) para guardar el archivo en formato PowerPoint.

Este código C++ muestra la operación de PDF a PowerPoint:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="info" %}} 

Puede que quieras probar la aplicación web gratuita **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/es/import/pdf-to-powerpoint) ya que es una implementación en vivo del proceso descrito aquí. 

{{% /alert %}} 

## **Importar PowerPoint desde HTML**

En este caso, conviertes un documento HTML a una presentación PowerPoint.

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation/).  
2. Llamar al método [AddFromHtml()](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) y pasar el archivo HTML.  
3. Usar el método [Save()](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) para guardar el archivo en formato PowerPoint.

Este código C++ muestra la operación de HTML a PowerPoint:

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

También puedes usar Aspose.Slides para convertir HTML a otros formatos de archivo populares: 

* [HTML to image](https://products.aspose.com/slides/es/cpp/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/es/cpp/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/es/cpp/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/es/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

### ¿Se conservan las tablas al importar un PDF y se puede mejorar su detección?

Las tablas pueden detectarse durante la importación; [PdfImportOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.import/pdfimportoptions/) incluye un método [set_DetectTables](https://reference.aspose.com/slides/es/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) que permite reconocer tablas. La efectividad depende de la estructura del PDF.