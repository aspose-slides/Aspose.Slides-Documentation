---
title: Convertir presentaciones de PowerPoint a documentos Word en C++
linktitle: PowerPoint a Word
type: docs
weight: 110
url: /es/cpp/convert-powerpoint-to-word/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- convertir PPTX
- PowerPoint a Word
- presentación a Word
- diapositiva a Word
- PPT a Word
- PPTX a Word
- PowerPoint a DOCX
- presentación a DOCX
- diapositiva a DOCX
- PPT a DOCX
- PPTX a DOCX
- PowerPoint a DOC
- presentación a DOC
- diapositiva a DOC
- PPT a DOC
- PPTX a DOC
- guardar PPT como DOCX
- guardar PPTX como DOCX
- exportar PPT a DOCX
- exportar PPTX a DOCX
- C++
- Aspose.Slides
description: "Convertir diapositivas PowerPoint PPT y PPTX a documentos Word editables en C++ usando Aspose.Slides con preservación precisa del diseño, imágenes y formato."
---
## **Introducción**

Si planea utilizar contenido textual o información de una presentación (PPT o PPTX) de nuevas maneras, puede beneficiarse al convertir la presentación a Word (DOC o DOCX).

* En comparación con Microsoft PowerPoint, la aplicación Microsoft Word está más equipada con herramientas o funcionalidades para el contenido. 
* Además de las funciones de edición en Word, también puede beneficiarse de funciones mejoradas de colaboración, impresión y uso compartido. 

{{% alert color="info" %}} 
Puede probar nuestro [**Convertidor en línea de Presentación a Word**](https://products.aspose.app/slides/es/conversion/ppt-to-word) para ver qué puede obtener al trabajar con contenido textual de diapositivas. 
{{% /alert %}} 

## **Aspose.Slides y Aspose.Words**

Para convertir un archivo PowerPoint (PPTX o PPT) a Word (DOCX o DOCX), necesita tanto [Aspose.Slides for C++](https://products.aspose.com/slides/es/cpp/) como [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Como una API independiente, [Aspose.Slides](https://products.aspose.app/slides) for C++ proporciona funciones que le permiten extraer textos de presentaciones. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) es una API avanzada de procesamiento de documentos que permite a las aplicaciones generar, modificar, convertir, renderizar, imprimir archivos y realizar otras tareas con documentos sin utilizar Microsoft Word.

## **Convertir una presentación PowerPoint a un documento Word**

Utilice este fragmento de código para convertir el PowerPoint a Word:

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // generar una imagen de la diapositiva como flujo de bytes
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // inserta el texto de la diapositiva
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}

doc->Save(u"output.docx");
presentation->Dispose();
```

## **Preguntas frecuentes**

### ¿Qué componentes deben instalarse para convertir presentaciones de PowerPoint y OpenDocument a documentos Word?

Solo necesita agregar los paquetes correspondientes de [Aspose.Slides for C++](https://releases.aspose.com/slides/es/cpp/) y [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) a su proyecto. Ambas bibliotecas funcionan como APIs independientes y no es necesario tener Microsoft Office instalado.

### ¿Se admiten todos los formatos de presentación de PowerPoint y OpenDocument?

Aspose.Slides [supports all presentation formats](/slides/es/cpp/supported-file-formats/), incluidos PPT, PPTX, ODP y otros tipos de archivo comunes. Esto garantiza que pueda trabajar con presentaciones creadas en diversas versiones de Microsoft PowerPoint.