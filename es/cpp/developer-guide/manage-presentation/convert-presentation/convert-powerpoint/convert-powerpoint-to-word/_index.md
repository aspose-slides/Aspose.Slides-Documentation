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
description: "Convertir diapositivas PPT y PPTX de PowerPoint a documentos Word editables en C++ usando Aspose.Slides con diseño preciso, imágenes y formato preservados."
---

Si planea usar contenido textual o información de una presentación (PPT o PPTX) de nuevas maneras, puede beneficiarse al convertir la presentación a Word (DOC o DOCX).

* En comparación con Microsoft PowerPoint, la aplicación Microsoft Word está más equipada con herramientas o funcionalidades para el contenido.
* Además de las funciones de edición en Word, también puede beneficiarse de funciones mejoradas de colaboración, impresión y uso compartido.

{{% alert color="primary" %}}
Es posible que desee probar nuestro [**Convertidor en línea de Presentación a Word**](https://products.aspose.app/slides/conversion/ppt-to-word) para ver qué puede obtener al trabajar con el contenido textual de las diapositivas.
{{% /alert %}}

## **Aspose.Slides y Aspose.Words**

Para convertir un archivo PowerPoint (PPTX o PPT) a Word (DOCX o DOC), necesita tanto [Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) como [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Como una API independiente, [Aspose.Slides](https://products.aspose.app/slides) para C++ proporciona funciones que le permiten extraer textos de las presentaciones.

[Aspose.Words](https://docs.aspose.com/words/cpp/) es una API avanzada de procesamiento de documentos que permite a las aplicaciones generar, modificar, convertir, renderizar, imprimir archivos y realizar otras tareas con documentos sin utilizar Microsoft Word.

## **Convertir una presentación PowerPoint a un documento Word**

Utilice este fragmento de código para convertir el PowerPoint a Word:
```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // genera e inserta la imagen de la diapositiva
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // inserta los textos de la diapositiva
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
```


## **Preguntas frecuentes**

**¿Qué componentes deben instalarse para convertir presentaciones PowerPoint y OpenDocument a documentos Word?**

Solo necesita agregar los paquetes correspondientes de [Aspose.Slides for C++](https://releases.aspose.com/slides/cpp/) y [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) a su proyecto. Ambas bibliotecas funcionan como APIs independientes y no se requiere que Microsoft Office esté instalado.

**¿Se admiten todos los formatos de presentaciones PowerPoint y OpenDocument?**

Aspose.Slides [soporta todos los formatos de presentación](/slides/es/cpp/supported-file-formats/), incluidos PPT, PPTX, ODP y otros tipos de archivo comunes. Esto garantiza que pueda trabajar con presentaciones creadas en diversas versiones de Microsoft PowerPoint.