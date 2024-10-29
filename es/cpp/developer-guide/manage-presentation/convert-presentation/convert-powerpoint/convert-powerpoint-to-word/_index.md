---
title: Convertir PowerPoint a Word
type: docs
weight: 110
url: /es/cpp/convert-powerpoint-to-word/
keywords: "Convertir PowerPoint, PPT, PPTX, Presentación, Word, DOCX, DOC, PPTX a DOCX, PPT a DOC, PPTX a DOC, PPT a DOCX, C++, Aspose.Slides"
description: "Convertir Presentación de PowerPoint a Word en C++ "
---

Si planeas utilizar contenido textual o información de una presentación (PPT o PPTX) de nuevas maneras, podrías beneficiarte al convertir la presentación a Word (DOC o DOCX).

* En comparación con Microsoft PowerPoint, la aplicación Microsoft Word está más equipada con herramientas o funcionalidades para el contenido.
* Además de las funciones de edición en Word, también podrías beneficiarte de características mejoradas de colaboración, impresión y compartición.

{{% alert color="primary" %}}

Podrías querer probar nuestro [**Convertidor de Presentación a Word en Línea**](https://products.aspose.app/slides/conversion/ppt-to-word) para ver lo que podrías ganar trabajando con contenido textual de las diapositivas.

{{% /alert %}}

### **Aspose.Slides y Aspose.Words**

Para convertir un archivo de PowerPoint (PPTX o PPT) a Word (DOCX o DOCX), necesitas tanto [Aspose.Slides para C++](https://products.aspose.com/slides/cpp/) como [Aspose.Words para C++](https://products.aspose.com/words/cpp/).

Como una API independiente, [Aspose.Slides](https://products.aspose.app/slides) para C++ proporciona funciones que te permiten extraer textos de presentaciones.

[Aspose.Words](https://docs.aspose.com/words/cpp/) es una API avanzada de procesamiento de documentos que permite a las aplicaciones generar, modificar, convertir, renderizar, imprimir archivos y realizar otras tareas con documentos sin utilizar Microsoft Word.

## **Convertir PowerPoint a Word**

Utiliza este fragmento de código para convertir PowerPoint a Word:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // genera e inserta imagen de la diapositiva
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