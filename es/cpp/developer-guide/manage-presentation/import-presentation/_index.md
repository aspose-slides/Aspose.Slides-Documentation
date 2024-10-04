---
title: Importar Presentación - API de PowerPoint C++
linktitle: Importar Presentación
type: docs
weight: 60
url: /cpp/import-presentation/
keywords: "Importar PowerPoint, PDF a Presentación, PDF a PPTX, PDF a PPT, C++, Aspose.Slides para C++"
description: "Importar presentación de PowerPoint desde PDF. Convertir PDF a PowerPoint"
---

Usando [**Aspose.Slides para C++**](https://products.aspose.com/slides/cpp/), puedes importar presentaciones desde archivos en otros formatos. Aspose.Slides proporciona la clase [SlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection) para permitirte importar presentaciones desde PDF, documentos HTML, etc.

## **Importar PowerPoint desde PDF**

En este caso, puedes convertir un PDF en una presentación de PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Instancia un objeto de la clase de presentación. 
2. Llama al método [AddFromPdf()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) y pasa el archivo PDF. 
3. Usa el método [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) para guardar el archivo en formato PowerPoint.

Este código C++ demuestra la operación de PDF a PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Consejo" color="primary" %}} 

Es posible que desees consultar la aplicación web gratuita de **Aspose** [PDF a PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) porque es una implementación en vivo del proceso descrito aquí. 

{{% /alert %}} 

## **Importar PowerPoint desde HTML**

En este caso, puedes convertir un documento HTML en una presentación de PowerPoint.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). 
2. Llama al método [AddFromHtml()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) y pasa el archivo HTML. 
3. Usa el método [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) para guardar el archivo en formato PowerPoint.

Este código C++ demuestra la operación de HTML a PowerPoint:

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Nota" color="warning" %}} 

También puedes usar Aspose.Slides para convertir HTML a otros formatos de archivo populares: 

* [HTML a imagen](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML a JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML a XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML a TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}