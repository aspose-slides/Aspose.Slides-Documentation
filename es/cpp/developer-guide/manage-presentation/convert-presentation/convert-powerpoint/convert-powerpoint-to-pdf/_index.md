---
title: Convertir PowerPoint a PDF en C++
linktitle: Convertir PowerPoint a PDF
type: docs
weight: 40
url: /cpp/convert-powerpoint-to-pdf/
keywords:
- convertir PowerPoint
- presentación
- PowerPoint a PDF
- PPT a PDF
- PPTX a PDF
- guardar PowerPoint como PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides para C++
description: "Convierte presentaciones de PowerPoint a PDF en C++. Guarda PowerPoint como PDF cumpliendo con estándares de accesibilidad o conformidad."
---

## **Descripción general**

Convertir documentos de PowerPoint a formato PDF ofrece varias ventajas, incluida la garantía de compatibilidad en diferentes dispositivos y la preservación del diseño y formato de su presentación. Este artículo le muestra cómo convertir presentaciones a documentos PDF, utilizar diversas opciones para controlar la calidad de la imagen, incluir diapositivas ocultas, proteger documentos PDF con contraseña, detectar sustituciones de fuentes, seleccionar diapositivas para la conversión y aplicar estándares de conformidad a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Usando Aspose.Slides, puede convertir presentaciones en estos formatos a PDF:

* PPT
* PPTX
* ODP

Para convertir una presentación a PDF, simplemente debe pasar el nombre del archivo como un argumento en la clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) y luego guardar la presentación como PDF usando un método [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e). La clase [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) expone el método [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) que se utiliza típicamente para convertir una presentación a PDF.

{{%  alert title="NOTA"  color="warning"   %}} 

Aspose.Slides para C++ escribe directamente información de la API y el número de versión en los documentos de salida. Por ejemplo, cuando convierte una presentación a PDF, Aspose.Slides para C++ completa el campo Aplicación con el valor '*Aspose.Slides*' y el campo Productor de PDF con un valor en formato '*Aspose.Slides v XX.XX*'. **Nota** que no puede instruir a Aspose.Slides para C++ que cambie o elimine esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides permite convertir:

* una presentación completa a PDF
* diapositivas específicas en una presentación a PDF
* una presentación 

Aspose.Slides exporta presentaciones a PDF de tal manera que los contenidos de los PDFs resultantes son muy similares a los de las presentaciones originales. Estos elementos y atributos conocidos suelen renderizarse correctamente en las conversiones de presentación a PDF:

* imágenes
* cuadros de texto y otras formas
* textos y su formato
* párrafos y su formato
* hipervínculos
* encabezados y pies de página
* viñetas
* tablas

## **Convertir PowerPoint a PDF**

La operación estándar de conversión de PowerPoint a PDF se ejecuta utilizando opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando configuraciones óptimas en los niveles de calidad máximos.

<a name="cpp-powerpoint-to-pdf" id="cpp-powerpoint-to-pdf"><strong>Pasos: Convertir PowerPoint a PDF en C++</strong></a> |
<a name="cpp-ppt-to-pdf" id="cpp-ppt-to-pdf"><strong>Pasos: Convertir PPT a PDF en C++</strong></a> |
<a name="cpp-pptx-to-pdf" id="cpp-pptx-to-pdf"><strong>Pasos: Convertir PPTX a PDF en C++</strong></a> |
<a name="cpp-odp-to-pdf" id="cpp-odp-to-pdf"><strong>Pasos: Convertir ODP a PDF en C++</strong></a>

Este código C++ muestra cómo convertir un PowerPoint a PDF:

```c++
// Instancia una clase Presentation que representa un archivo de PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.ppt");

// Guarda la presentación como un PDF
presentation->Save(u"PPT-a-PDF.pdf", SaveFormat::Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose proporciona un [**convertidor de PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) en línea gratuito que demuestra el proceso de conversión de presentación a PDF. Para una implementación en vivo del procedimiento aquí descrito, puede hacer una prueba con el convertidor.

{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas—propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/)—que le permiten personalizar el PDF (resultante del proceso de conversión), bloquear el PDF con una contraseña, o incluso especificar cómo debe ir el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Usando opciones de conversión personalizadas, puede establecer su configuración de calidad preferida para imágenes rasterizadas, especificar cómo se deben manejar los metafiles, establecer un nivel de compresión para textos, establecer DPI para imágenes, etc.

El ejemplo de código a continuación demuestra una operación en la que se convierte una presentación de PowerPoint a PDF con varias opciones personalizadas:

```c++
// Instancia la clase PdfOptions
auto pdfOptions = System::MakeObject<PdfOptions>();

// Establece la calidad para las imágenes JPG
pdfOptions->set_JpegQuality(90);

// Establece DPI para imágenes
pdfOptions->set_SufficientResolution(300);

// Establece el comportamiento para los metafiles
pdfOptions->set_SaveMetafilesAsPng(true);

// Establece el nivel de compresión de texto para contenido textual
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Define el modo de conformidad PDF
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instancia la clase Presentation que representa un documento de PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// Guarda la presentación como un documento PDF
presentation->Save(u"PowerPoint-a-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Convertir PowerPoint a PDF con diapositivas ocultas**

Si una presentación contiene diapositivas ocultas, puede usar una opción personalizada—la propiedad [ShowHiddenSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options#ad11e5a17110d70456df91cc1a5dade23) de la clase [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/)—para instruir a Aspose.Slides que incluya las diapositivas ocultas como páginas en el PDF resultante.

Este código C++ muestra cómo convertir una presentación de PowerPoint a PDF con diapositivas ocultas incluidas:

```c++
// Instancia una clase Presentation que representa un archivo de PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// Instancia la clase PdfOptions
auto pdfOptions = System::MakeObject<PdfOptions>();

// Añade diapositivas ocultas
pdfOptions->set_ShowHiddenSlides(true);

// Guarda la presentación como un PDF
presentation->Save(u"PowerPoint-a-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### **Convertir PowerPoint a PDF protegido con contraseña**

Este código C++ muestra cómo convertir un PowerPoint a un PDF protegido con contraseña (usando parámetros de protección de la clase [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/)):

```c++
// Instancia un objeto Presentation que representa un archivo de PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

/// Instancia la clase PdfOptions
auto pdfOptions = System::MakeObject<PdfOptions>();

// Establece la contraseña PDF y los permisos de acceso
pdfOptions->set_Password(u"contraseña");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Guarda la presentación como un PDF
presentation->Save(u"PPTX-a-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### **Detectar sustituciones de fuentes**

Aspose.Slides proporciona el método [get_WarningCallback()](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/get_warningcallback/) bajo la clase [SaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/) para permitirle detectar sustituciones de fuentes en un proceso de conversión de presentación a PDF. 

Este código C++ muestra cómo detectar sustituciones de fuentes:

```c++
class FontSubstSendsWarningCallback : public Warnings::IWarningCallback
{
public:
    Warnings::ReturnAction Warning(System::SharedPtr<Warnings::IWarningInfo> warning) override;
};

Warnings::ReturnAction FontSubstSendsWarningCallback::Warning(System::SharedPtr<Warnings::IWarningInfo> warning)
{
    if (warning->get_WarningType() == Warnings::WarningType::CompatibilityIssue)
    {
        return Warnings::ReturnAction::Continue;
    }

    if (warning->get_WarningType() == Warnings::WarningType::DataLoss && warning->get_Description().StartsWith(u"La fuente será sustituida"))
    {
        System::Console::WriteLine(u"Advertencia de sustitución de fuente: {0}", warning->get_Description());
    }

    return Warnings::ReturnAction::Continue;
}
```

y el siguiente código C++ muestra cómo usar la clase anterior:

```c++
int main()
{
    System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    System::SharedPtr<FontSubstSendsWarningCallback> warningCallback = System::MakeObject<FontSubstSendsWarningCallback>();
    loadOptions->set_WarningCallback(warningCallback);

    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);
    return 0;
}
```

{{%  alert color="primary"  %}} 

Para más información sobre cómo obtener callbacks para sustituciones de fuentes en un proceso de renderizado, consulte [Obteniendo callbacks de advertencia para sustituciones de fuentes](https://docs.aspose.com/slides/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Para más información sobre la sustitución de fuentes, consulte el artículo [Sustitución de fuentes](https://docs.aspose.com/slides/cpp/font-substitution/).

{{% /alert %}} 

## **Convertir diapositivas seleccionadas en PowerPoint a PDF**

Este código C++ muestra cómo convertir diapositivas específicas en una presentación de PowerPoint a PDF:

```C++
// Instancia un objeto Presentation que representa un archivo de PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// Establece un array de posiciones de diapositivas
auto slides = System::MakeArray<int32_t>({1, 3});

// Guarda la presentación como un PDF
presentation->Save(u"PPTX-a-PDF.pdf", slides, SaveFormat::Pdf);
```

## **Convertir PowerPoint a PDF con tamaño de diapositiva personalizado**

Este código C++ muestra cómo convertir un PowerPoint cuando su tamaño de diapositiva está especificado a un PDF:

```C++
// La ruta al directorio de documentos.
String dataDir = GetDataPath()

// Instancia un objeto Presentation que representa un archivo de PowerPoint 
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// Establece el tipo y tamaño de la diapositiva 
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```

## **Convertir PowerPoint a PDF en vista de notas de diapositiva**

Este código C++ muestra cómo convertir un PowerPoint a notas PDF:

```C++
// La ruta al directorio de documentos.
System::String dataDir = u"";

// Instancia una clase Presentation que representa un archivo de PowerPoint
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Guarda la presentación a notas PDF
presentation->Save(dataDir + u"Pdf_Notes_out.tiff", SaveFormat::Pdf, pdfOptions);
```

## **Estándares de accesibilidad y conformidad para PDF**

Aspose.Slides le permite utilizar un procedimiento de conversión que cumple con las [Directrices de Accesibilidad para el Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puede exportar un documento de PowerPoint a PDF utilizando cualquiera de estos estándares de conformidad: **PDF/A1a**, **PDF/A1b**, y **PDF/UA**.

Este código C++ demuestra una operación de conversión de PowerPoint a PDF en la que se obtienen múltiples PDFs basados en diferentes estándares de conformidad:

```C++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = System::MakeObject<PdfOptions>();
pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
pres->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = System::MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
pres->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = System::MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);
pres->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);
```

{{% alert title="Nota" color="warning" %}} 

El soporte de Aspose.Slides para operaciones de conversión a PDF se extiende para permitirle convertir PDF a los formatos de archivo más populares. Puede realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—también son compatibles.

{{% /alert %}}