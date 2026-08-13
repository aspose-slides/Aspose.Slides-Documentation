---
title: Convertir PPT y PPTX a PDF en C++ [Características avanzadas incluidas]
linktitle: PowerPoint a PDF
type: docs
weight: 40
url: /es/cpp/convert-powerpoint-to-pdf/
keywords:
- convertir PowerPoint
- convertir presentación
- PowerPoint a PDF
- presentación a PDF
- PPT a PDF
- convertir PPT a PDF
- PPTX a PDF
- convertir PPTX a PDF
- guardar PowerPoint como PDF
- guardar PPT como PDF
- guardar PPTX como PDF
- exportar PPT a PDF
- exportar PPTX a PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Convertir presentaciones PowerPoint PPT/PPTX a PDFs de alta calidad y buscables en C++ usando Aspose.Slides, con ejemplos de código rápidos y opciones avanzadas de conversión."
---
## **Descripción general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP, etc.) a formato PDF en C++ ofrece varias ventajas, como la compatibilidad entre diferentes dispositivos y la conservación del diseño y formato de su presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar diversas opciones para controlar la calidad de imagen, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar estándares de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puede convertir presentaciones en los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pase el nombre del archivo como argumento a la clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) y luego guarde la presentación como PDF mediante el método `Save`. La clase [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) expone el método `Save` que se utiliza habitualmente para convertir una presentación a PDF.

{{%  alert title="NOTA"  color="warning"   %}} 

Aspose.Slides para C++ inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides rellena el campo Application con "*Aspose.Slides*" y el campo PDF Producer con un valor en formato "*Aspose.Slides v XX.XX*". **Nota** que no puede indicar a Aspose.Slides que cambie o elimine esta información de los documentos generados.

{{% /alert %}}

Aspose.Slides le permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, garantizando que los PDF resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluidos:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Encabezados y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

El proceso estándar de conversión de PowerPoint a PDF utiliza opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF empleando la configuración óptima en los niveles máximos de calidad.

Este código C++ muestra cómo convertir una presentación (PPT, PPTX, ODP, etc.) a PDF:

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Save the presentation as a PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 

Aspose ofrece un convertidor en línea gratuito de [**PowerPoint a PDF**](https://products.aspose.app/slides/es/conversion/ppt-to-pdf) que muestra el proceso de conversión de presentación a PDF. Puede probar este convertidor para obtener una implementación en tiempo real del procedimiento descrito aquí.

{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas —propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pdfoptions/)— que le permiten personalizar el PDF resultante, proteger el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Con opciones de conversión personalizadas, puede definir la configuración de calidad preferida para imágenes rasterizadas, especificar cómo se deben manejar los metafiles, establecer un nivel de compresión para el texto, configurar DPI para imágenes y más.

El ejemplo de código a continuación muestra cómo convertir una presentación de PowerPoint a PDF con varias opciones personalizadas.

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar la clase PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Establecer la calidad de las imágenes JPG.
pdfOptions->set_JpegQuality(90);

// Establecer DPI para imágenes.
pdfOptions->set_SufficientResolution(300);

// Establecer el comportamiento de los metaficheros.
pdfOptions->set_SaveMetafilesAsPng(true);

// Establecer el nivel de compresión de texto para el contenido textual.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Definir el modo de cumplimiento PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Guardar la presentación como documento PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Convertir PowerPoint a PDF con diapositivas ocultas**

Si una presentación contiene diapositivas ocultas, puede utilizar el método [set_ShowHiddenSlides](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) de la clase [PdfOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pdfoptions/) para incluir las diapositivas ocultas como páginas en el PDF resultante.

Este código C++ muestra cómo convertir una presentación de PowerPoint a PDF incluyendo las diapositivas ocultas:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instanciar la clase PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Añadir diapositivas ocultas.
pdfOptions->set_ShowHiddenSlides(true);

// Guardar la presentación como PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Convertir PowerPoint a PDF protegido con contraseña**

Este código C++ demuestra cómo convertir una presentación de PowerPoint en un PDF protegido con contraseña mediante los parámetros de protección de la clase [PdfOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pdfoptions/):

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instanciar la clase PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Establecer una contraseña PDF y permisos de acceso.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Guardar la presentación como PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Detectar sustituciones de fuentes**

Aspose.Slides ofrece el método [set_WarningCallback](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/saveoptions/set_warningcallback/) bajo la clase [PdfOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pdfoptions/) que le permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

Este código C++ muestra cómo detectar sustituciones de fuentes:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

// Implementación de la devolución de aviso.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss &&
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Establecer la devolución de aviso en las opciones PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Guardar la presentación como PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);

    presentation->Dispose();

    return 0;
}
```

{{%  alert color="info"  %}} 

Para obtener más información sobre cómo recibir devoluciones de llamada por sustituciones de fuentes durante el proceso de renderizado, consulte [Getting Warning Callbacks for Fonts Substitution](/slides/es/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Para más información sobre sustitución de fuentes, consulte el artículo [Font Substitution](/slides/es/cpp/font-substitution/).

{{% /alert %}} 

## **Convertir diapositivas seleccionadas de PowerPoint a PDF**

Este código C++ muestra cómo convertir solo diapositivas específicas de una presentación de PowerPoint a PDF:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Establecer el array de números de diapositiva.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Guardar la presentación como PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **Convertir PowerPoint a PDF con tamaño de diapositiva personalizado**

Este código C++ muestra cómo convertir una presentación de PowerPoint a PDF con un tamaño de diapositiva especificado:

```C++
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Crear una nueva presentación con un tamaño de diapositiva ajustado.
auto resizedPresentation = MakeObject<Presentation>();

// Establecer el tamaño de diapositiva personalizado.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clonar la primera diapositiva de la presentación original.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Guardar la presentación redimensionada en un PDF con notas.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Convertir PowerPoint a PDF en vista de notas de diapositiva**

Este código C++ muestra cómo convertir una presentación de PowerPoint a un PDF que incluya las notas:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Configurar las opciones PDF con diseño de notas.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Guardar la presentación en un PDF con notas.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **Accesibilidad y estándares de cumplimiento para PDF**

Aspose.Slides le permite usar un procedimiento de conversión que cumple con las [Directrices de Accesibilidad al Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puede exportar un documento de PowerPoint a PDF utilizando cualquiera de estos estándares de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código C++ muestra un proceso de conversión de PowerPoint a PDF que genera varios PDF basados en distintos estándares de cumplimiento:

```C++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="Nota" color="warning" %}} 

Aspose.Slides admite operaciones de conversión a PDF, lo que le permite convertir archivos PDF a formatos de archivo populares. Puede realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/es/cpp/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/es/cpp/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/es/cpp/conversion/pdf-to-jpg/) y [PDF a PNG](https://products.aspose.com/slides/es/cpp/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados —[PDF a SVG](https://products.aspose.com/slides/es/cpp/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/es/cpp/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/es/cpp/conversion/pdf-to-xml/)— también son compatibles.

{{% /alert %}}

> **Nota:** Al exportar a PDF/UA, Aspose.Slides trata a gráficos complejos como SmartArt, diagramas y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se proporciona solo para la figura completa.

## **Preguntas frecuentes**

### ¿Puedo convertir varios archivos PowerPoint a PDF de forma masiva?

Sí, Aspose.Slides admite la conversión por lotes de varios archivos PPT o PPTX a PDF. Puede iterar sobre sus archivos y aplicar el proceso de conversión mediante código.

### ¿Es posible proteger con contraseña el PDF convertido?

Absolutamente. Utilice la clase [PdfOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pdfoptions/) para establecer una contraseña y definir los permisos de acceso durante el proceso de conversión.

### ¿Cómo incluyo diapositivas ocultas en el PDF?

Use el método `set_ShowHiddenSlides` en la clase [PdfOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pdfoptions/) para incluir las diapositivas ocultas en el PDF resultante.

### ¿Puede Aspose.Slides mantener alta calidad de imagen en el PDF?

Sí, puede controlar la calidad de imagen mediante métodos como `set_JpegQuality` y `set_SufficientResolution` en la clase [PdfOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/pdfoptions/) para garantizar imágenes de alta calidad en su PDF.

### ¿Aspose.Slides admite los estándares de cumplimiento PDF/A?

Sí, Aspose.Slides le permite exportar PDFs que cumplen con varios estándares, incluidos PDF/A1a, PDF/A1b y PDF/UA, asegurando que sus documentos cumplan con los requisitos de accesibilidad y archivo.

## **Recursos adicionales**

- [Documentación de Aspose.Slides para C++](/slides/es/cpp/)
- [Referencia de API de Aspose.Slides para C++](https://reference.aspose.com/slides/es/cpp/)
- [Convertidores en línea gratuitos de Aspose](https://products.aspose.app/slides/es/conversion)