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
- adjunto
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Convertir PowerPoint PPT/PPTX a PDFs de alta calidad y buscables en C++ usando Aspose.Slides, con ejemplos de código rápidos y opciones avanzadas de conversión."
---
## **Visión general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP, etc.) a formato PDF en C++ ofrece varias ventajas, incluida la compatibilidad entre diferentes dispositivos y la preservación del diseño y formato de su presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar diversas opciones para controlar la calidad de la imagen, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puede convertir presentaciones en los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pase el nombre del archivo como argumento a la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) y luego guarde la presentación como PDF usando el método [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). La clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) expone el método [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) que normalmente se usa para convertir una presentación a PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ inserta su información de API y el número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides completa el campo Application con "*Aspose.Slides*" y el campo PDF Producer con un valor en forma "*Aspose.Slides v XX.XX*". **Nota** que no puede instruir a Aspose.Slides para cambiar o eliminar esta información de los documentos de salida.
{{% /alert %}}

Aspose.Slides permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, asegurando que los PDFs resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluyendo:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Encabezados y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

La conversión estándar de PowerPoint a PDF utiliza opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando configuraciones óptimas en los niveles máximos de calidad.

El siguiente ejemplo carga una presentación y guarda todas las diapositivas visibles en PDF usando la configuración de exportación predeterminada.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose ofrece un [**Convertidor de PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratuito en línea que muestra el proceso de conversión de presentación a PDF. Puede ejecutar una prueba con este convertidor para una implementación en vivo del procedimiento descrito aquí.
{{% /alert %}}

## **Convertir PowerPoint a PDF con Opciones**

Aspose.Slides ofrece opciones personalizadas—propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)—que le permiten personalizar el PDF resultante, bloquear el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con Opciones Personalizadas**

Con opciones de conversión personalizadas, puede definir su configuración de calidad preferida para imágenes raster, especificar cómo deben manejarse los metafiles, establecer un nivel de compresión para texto, configurar DPI para imágenes y más.

El siguiente ejemplo exporta una presentación a PDF 1.5 con calidad JPEG establecida en 90, resolución de imagen a 300 DPI, metafiles guardados como PNG y compresión de texto Flate.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Conservar archivos OLE incrustados como adjuntos PDF**

Si una presentación contiene un libro de Excel incrustado, es posible que desee que los destinatarios del PDF accedan a los datos del libro además de ver las diapositivas. Llame a [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) con `true` para conservar los archivos OLE incrustados como adjuntos en el PDF resultante.

El valor predeterminado es `false`: la imagen de vista previa o el ícono del objeto OLE se renderiza en la página del PDF, pero su archivo incrustado no se incluye como adjunto. Configurar la opción a `true` incluye adicionalmente los datos del archivo. La vista previa sigue siendo una representación visual; el adjunto permite a los destinatarios abrir o guardar el archivo incrustado por separado. El objeto OLE no se convierte en una hoja de cálculo interactiva de Excel en la página del PDF.

El siguiente ejemplo carga una presentación que ya contiene un libro de Excel incrustado y lo exporta a PDF con el libro adjunto.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Para comprobar el resultado:

1. Abra el PDF exportado en un visor que admita archivos adjuntos, como Adobe Acrobat Reader.
2. Abra el panel de **Adjuntos** del visor y localice el libro incrustado.
3. Guarde el adjunto y ábralo en Excel para inspeccionar sus datos, o ábralo directamente si el visor lo permite. La vista previa en la página del PDF es independiente del adjunto.

{{% alert color="info" title="Note" %}}
Los estándares PDF/A imponen restricciones sobre los adjuntos: PDF/A-1 prohíbe archivos incrustados, PDF/A-2 permite solo adjuntos PDF/A, y PDF/A-3 permite otros tipos de archivos, incluidos libros de Excel. Estas son exigencias de los estándares, no restricciones específicas de Aspose.Slides. Este ejemplo usa la configuración de cumplimiento PDF por defecto y no muestra la exportación PDF/A.
{{% /alert %}}

### **Convertir PowerPoint a PDF con Diapositivas Ocultas**

Si una presentación contiene diapositivas ocultas, puede utilizar el método [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) de la clase [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) para incluir las diapositivas ocultas como páginas en el PDF resultante.

El siguiente ejemplo exporta una presentación a PDF, incluyendo cualquier diapositiva oculta.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Convertir PowerPoint a un PDF protegido con contraseña**

El siguiente ejemplo exporta una presentación a un PDF que requiere la contraseña `password` para abrirse. Los permisos de acceso permiten la impresión, incluida la impresión de alta calidad.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Detectar sustituciones de fuentes**

Aspose.Slides proporciona el método [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) bajo la clase [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), lo que le permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

El siguiente ejemplo exporta una presentación a PDF e imprime advertencias de sustitución de fuentes en la consola. Se imprime una advertencia solo cuando una fuente no disponible es sustituida durante la exportación.

```cpp
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

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Para obtener más información sobre la sustitución de fuentes, consulte el artículo [Sustitución de fuentes](/slides/es/cpp/font-substitution/).
{{% /alert %}} 

## **Convertir Diapositivas Seleccionadas de PowerPoint a PDF**

El siguiente ejemplo exporta las diapositivas 1 y 3 de una presentación a PDF. Los números de diapositiva en este arreglo comienzan en 1, y la presentación de entrada debe contener al menos tres diapositivas.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **Convertir PowerPoint a PDF con Tamaño de Diapositiva Personalizado**

El siguiente ejemplo copia la primera diapositiva de una presentación en una nueva presentación con un tamaño de diapositiva de 612 × 792 puntos (8,5 × 11 pulgadas). Escala el contenido de la diapositiva para ajustarlo y exporta la única diapositiva a PDF.

```cpp
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

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Convertir PowerPoint a PDF en Vista de Notas de Diapositiva**

El siguiente ejemplo exporta una presentación a PDF, colocando las notas del orador de cada diapositiva debajo de la misma. Use una presentación que contenga notas del orador para ver el resultado.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **Normas de Accesibilidad y Cumplimiento para PDF**

Aspose.Slides le permite utilizar un procedimiento de conversión que cumple con las [Directrices de Accesibilidad de Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puede exportar un documento de PowerPoint a PDF utilizando cualquiera de estos estándares de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este fragmento de código C++ muestra un proceso de conversión de PowerPoint a PDF que produce varios PDFs basados en diferentes estándares de cumplimiento:

```cpp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides admite operaciones de conversión de PDF, lo que le permite convertir archivos PDF a formatos de archivo populares. Puede realizar [PDF a HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) conversiones. Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—también son compatibles.
{{% /alert %}}

> **Nota:** Al exportar a PDF/UA, Aspose.Slides trata los gráficos complejos como SmartArt, diagramas y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se proporciona solo para la figura completa.

## **FAQ**

**¿Puedo convertir varios archivos PowerPoint a PDF en lote?**

Sí, Aspose.Slides admite la conversión por lotes de varios archivos PPT o PPTX a PDF. Puede iterar sus archivos y aplicar el proceso de conversión programáticamente.

**¿Es posible proteger con contraseña el PDF convertido?**

Sí. Utilice la clase [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) para establecer una contraseña y definir los permisos de acceso durante el proceso de conversión.

**¿Cómo incluir diapositivas ocultas en el PDF?**

Utilice el método [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) en la clase [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) para incluir diapositivas ocultas en el PDF resultante.

**¿Puede Aspose.Slides mantener alta calidad de imagen en el PDF?**

Sí, puede controlar la calidad de imagen usando métodos como [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) y [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) en la clase [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) para garantizar imágenes de alta calidad en su PDF.

**¿Aspose.Slides admite los estándares de cumplimiento PDF/A?**

Sí, Aspose.Slides le permite exportar PDFs que cumplen con varios estándares, incluidos PDF/A1a, PDF/A1b y PDF/UA, garantizando que sus documentos cumplan con requisitos de accesibilidad y archivado.

## **Recursos Adicionales**

- [Documentación de Aspose.Slides para C++](/slides/es/cpp/)
- [Referencia de API de Aspose.Slides para C++](https://reference.aspose.com/slides/cpp/)
- [Convertidores gratuitos en línea de Aspose](https://products.aspose.app/slides/conversion)