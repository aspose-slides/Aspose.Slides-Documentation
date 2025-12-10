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
description: "Importe sin esfuerzo documentos PDF y HTML a presentaciones PowerPoint y OpenDocument en C++ con Aspose.Slides para un procesamiento de diapositivas sin fisuras y de alto rendimiento."
---

Usando [**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/), puede importar presentaciones desde archivos en otros formatos. Aspose.Slides proporciona la clase [SlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection) para permitirle importar presentaciones desde PDF, documentos HTML, etc.

## **Importar PowerPoint desde PDF**

En este caso, convierte un PDF a una presentación PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Instancie un objeto de la clase Presentation. 
2. Llame al método [AddFromPdf()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) y pase el archivo PDF. 
3. Utilice el método [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) para guardar el archivo en formato PowerPoint.

Este código C++ demuestra la operación de PDF a PowerPoint:
```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```


{{% alert  title="Tip" color="primary" %}} 
Es posible que desee probar la aplicación web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) porque es una implementación en vivo del proceso descrito aquí. 
{{% /alert %}} 

## **Importar PowerPoint desde HTML**

En este caso, convierte un documento HTML a una presentación PowerPoint.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) . 
2. Llame al método [AddFromHtml()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) y pase el archivo HTML. 
3. Utilice el método [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) para guardar el archivo en formato PowerPoint.

Este código C++ demuestra la operación de HTML a PowerPoint:
```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 
También puede usar Aspose.Slides para convertir HTML a otros formatos de archivo populares: 

* [HTML a imagen](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **Preguntas frecuentes**

**¿Se conservan las tablas al importar un PDF y se puede mejorar su detección?**

Las tablas pueden detectarse durante la importación; [PdfImportOptions](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/) incluye un método [set_DetectTables](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) que permite el reconocimiento de tablas. La efectividad depende de la estructura del PDF.