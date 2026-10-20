---
title: Convertir PPT y PPTX a PDF en PHP [Funciones avanzadas incluidas]
linktitle: PowerPoint a PDF
type: docs
weight: 40
url: /es/php-java/convert-powerpoint-to-pdf/
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
- PHP
- Aspose.Slides
description: "Convierta presentaciones PowerPoint PPT/PPTX a PDFs de alta calidad y buscables en PHP usando Aspose.Slides, con ejemplos de código rápidos y opciones de conversión avanzadas."
---
## **Descripción general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP, etc.) a formato PDF en PHP ofrece varias ventajas, incluida la compatibilidad entre diferentes dispositivos y la preservación del diseño y formato de tu presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar diversas opciones para controlar la calidad de imágenes, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puedes convertir presentaciones en los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pasa el nombre del archivo como argumento a la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y luego guarda la presentación como PDF usando el método [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). La clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) expone el método [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) que se usa habitualmente para convertir una presentación a PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for PHP via Java inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides rellena el campo Application con "*Aspose.Slides*" y el campo PDF Producer con un valor en formato "*Aspose.Slides v XX.XX*". **Nota** que no puedes indicar a Aspose.Slides que cambie o elimine esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides permite convertir:

* Presentaciones enteras a PDF
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

El proceso estándar de conversión de PowerPoint a PDF usa opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF utilizando configuraciones óptimas en los niveles máximos de calidad.

El siguiente ejemplo carga una presentación y guarda todas las diapositivas visibles en PDF usando la configuración de exportación predeterminada.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose ofrece un [convertidor de PowerPoint a PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) en línea gratuito que muestra el proceso de conversión de presentación a PDF. Puedes ejecutar una prueba con este convertidor para ver una implementación en vivo del procedimiento descrito aquí.

{{% /alert %}}

## **Convertir PowerPoint a PDF con Opciones**

Aspose.Slides proporciona opciones personalizadas—propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—que te permiten personalizar el PDF resultante, bloquear el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con Opciones Personalizadas**

Con opciones de conversión personalizadas, puedes definir tu configuración de calidad preferida para imágenes raster, especificar cómo se deben manejar los metarchivos, establecer un nivel de compresión para texto, configurar DPI para imágenes y más.

El siguiente ejemplo exporta una presentación a PDF 1.5 con calidad JPEG establecida en 90, resolución de imagen en 300 DPI, metarchivos guardados como PNG y compresión de texto Flate.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Seleccionar automáticamente la compresión de imágenes**

Cuando una presentación contiene muchas fotos o capturas de pantalla, reducir el tamaño del PDF exportado puede facilitar su envío por correo o su descarga. Llama a [PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) con `true` para seleccionar automáticamente el algoritmo de compresión más apropiado para cada imagen durante la exportación a PDF.

El siguiente ejemplo carga una presentación existente, habilita la selección automática de compresión de imágenes y la guarda como documento PDF. Todas las demás configuraciones de exportación PDF conservan sus valores predeterminados.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Esta opción elige un algoritmo de compresión para cada imagen. Reducir el valor pasado a [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) disminuye la calidad JPEG, mientras que reducir el valor pasado a [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) permite que las imágenes se muestreen a una resolución inferior, lo que puede reducir los detalles. Habilitar la selección automática de compresión no disminuye por sí misma ninguno de estos ajustes.

Seleccionar algoritmos de compresión de imágenes requiere tiempo de procesamiento y memoria adicionales. La reducción de tamaño depende de las imágenes de la presentación y de la configuración de exportación; no se garantiza una reducción fija para todas las presentaciones.

### **Conservar archivos OLE incrustados como adjuntos PDF**

Si una presentación contiene un libro de Excel incrustado, puede que quieras que los destinatarios del PDF accedan a los datos del libro además de ver las diapositivas. Llama a [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) con `true` para conservar los archivos OLE incrustados como adjuntos en el PDF resultante.

El valor predeterminado es `false`: la vista previa de la imagen o el icono del objeto OLE se muestra en la página PDF, pero su archivo incrustado no se incluye como adjunto. Al establecer la opción en `true` también se incluye la información del archivo. La vista previa sigue siendo una representación visual; el adjunto permite a los destinatarios abrir o guardar el archivo incrustado por separado. El objeto OLE no se convierte en una hoja de cálculo interactiva en la página PDF.

El siguiente ejemplo carga una presentación que ya contiene un libro de Excel incrustado y la exporta a PDF con el libro adjunto.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Para comprobar el resultado:

1. Abre el PDF exportado en un visor que admita adjuntos de archivo, como Adobe Acrobat Reader.
2. Abre el panel **Attachments** del visor y localiza el libro incrustado.
3. Guarda el adjunto y ábrelo en Excel para inspeccionar sus datos, o ábrelo directamente si el visor lo permite. La vista previa en la página PDF es distinta del adjunto.

{{% alert color="info" title="Note" %}}

Las normas PDF/A imponen restricciones sobre los adjuntos: PDF/A-1 prohíbe archivos incrustados, PDF/A-2 permite solo adjuntos PDF/A y PDF/A-3 permite otros tipos de archivo, incluidos libros de Excel. Estas son exigencias de las normas, no restricciones específicas de Aspose.Slides. Este ejemplo usa la configuración de cumplimiento PDF predeterminada y no muestra exportación PDF/A.

{{% /alert %}}

### **Convertir PowerPoint a PDF con Diapositivas Ocultas**

Si una presentación contiene diapositivas ocultas, puedes usar el método [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) de la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para incluir las diapositivas ocultas como páginas en el PDF resultante.

El siguiente ejemplo exporta una presentación a PDF, incluyendo cualquier diapositiva oculta.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Convertir PowerPoint a un PDF protegido con contraseña**

El siguiente ejemplo exporta una presentación a un PDF que requiere la contraseña `password` para abrirse. Los permisos de acceso permiten la impresión, incluida la impresión de alta calidad.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Detectar sustituciones de fuentes**

Aspose.Slides proporciona el método [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) bajo la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) que permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

El siguiente ejemplo exporta una presentación a PDF e imprime advertencias de sustitución de fuentes en la consola. Se imprime una advertencia solo cuando se sustituye una fuente no disponible durante la exportación.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

Para más información sobre sustitución de fuentes, consulta el artículo [Sustitución de fuentes](/slides/es/php-java/font-substitution/).

{{% /alert %}} 

### **Manejar fuentes sin una variante negrita dedicada**

Una presentación puede aplicar formato negrita a texto aun cuando su fuente no tenga una variante negrita dedicada. El texto puede seguir apareciendo en negrita mediante negrita sintética, que espesa artificialmente los glifos regulares. Cuando ese texto se ve demasiado grueso o difiere de la apariencia deseada en el PDF, prueba a llamar a [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) con `true`. Esta opción renderiza el texto afectado como mapa de bits durante la exportación a PDF y puede mejorar su apariencia para ciertas fuentes. Su valor predeterminado es `false`.

La presentación de muestra contiene dos cuadros de texto: uno con texto normal y otro con formato negrita aplicado a la misma fuente, que no tiene variante negrita dedicada. El siguiente ejemplo carga la presentación, habilita la rasterización de estilos de fuente no compatibles y la exporta a PDF:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Las siguientes vistas previas muestran la salida deshabilitada y la salida habilitada. En este ejemplo, el texto en negrita tiene trazos más gruesos con la opción deshabilitada. Con la opción habilitada, sus trazos son más ligeros; el texto normal permanece sin cambios. Compara los resultados antes de elegir la configuración para tu presentación.

| Opción deshabilitada (`false`, predeterminado) | Opción habilitada (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

En este ejemplo, habilitar la opción convierte solo el texto en negrita en un mapa de bits: no puede seleccionarse, copiarse ni buscarse como texto sin OCR, y sus bordes aparecen más suaves al 800 % de zoom. El texto normal sigue siendo buscable. Con la opción deshabilitada, ambas cadenas permanecen como texto.

Esta opción rasteriza el texto formateado como negrita cuando su fuente no tiene una variante negrita dedicada. [Sustitución de fuentes](/slides/es/php-java/font-substitution/) en cambio selecciona otra fuente cuando la original no está disponible.

## **Convertir Diapositivas Seleccionadas de PowerPoint a PDF**

El siguiente ejemplo exporta las diapositivas 1 y 3 de una presentación a PDF. Los números de diapositiva en este array son base 1, y la presentación de entrada debe contener al menos tres diapositivas.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Convertir PowerPoint a PDF con Tamaño de Diapositiva Personalizado**

El siguiente ejemplo copia la primera diapositiva de una presentación a una nueva presentación con un tamaño de diapositiva de 612 × 792 puntos (8,5 × 11 pulgadas). Escala el contenido de la diapositiva para ajustarlo y exporta la diapositiva única a PDF.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // Eliminar la diapositiva vacía con la que se creó la nueva presentación.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Convertir PowerPoint a PDF en Vista de Notas de Diapositiva**

El siguiente ejemplo exporta una presentación a PDF, colocando las notas del presentador de cada diapositiva debajo de la misma. Usa una presentación que contenga notas del presentador para ver el resultado.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Estándares de Accesibilidad y Cumplimiento para PDF**

Aspose.Slides permite usar un procedimiento de conversión que cumple con las [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puedes exportar un documento PowerPoint a PDF usando cualquiera de estos estándares de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código demuestra un proceso de conversión de PowerPoint a PDF que produce varios PDF basados en diferentes estándares de cumplimiento:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

Aspose.Slides soporta operaciones de conversión de PDF, permitiendo convertir archivos PDF a formatos de archivo populares. Puedes realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF a image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) y [PDF a PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—también están soportadas.

{{% /alert %}}

> **Nota:** Al exportar a PDF/UA, Aspose.Slides trata gráficos complejos como SmartArt, diagramas y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se brinda solo para la figura completa.

## **FAQ**

**¿Puedo convertir varios archivos PowerPoint a PDF en lote?**

Sí, Aspose.Slides admite la conversión por lotes de varios archivos PPT o PPTX a PDF. Puedes iterar sobre tus archivos y aplicar el proceso de conversión programáticamente.

**¿Es posible proteger con contraseña el PDF convertido?**

Sí. Utiliza la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para establecer una contraseña y definir permisos de acceso durante el proceso de conversión.

**¿Cómo incluyo diapositivas ocultas en el PDF?**

Llama a [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) con `true` en la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para incluir diapositivas ocultas en el PDF resultante.

**¿Puede Aspose.Slides mantener alta calidad de imagen en el PDF?**

Sí, puedes controlar la calidad de imagen usando métodos como [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) y [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) en la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para asegurar imágenes de alta calidad en tu PDF.

**¿Aspose.Slides soporta normas de cumplimiento PDF/A?**

Sí, Aspose.Slides permite exportar PDFs que cumplen con [varios estándares](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), incluidos PDF/A1a, PDF/A1b y PDF/UA, garantizando que tus documentos cumplan con requisitos de accesibilidad y archivo.

## **Recursos adicionales**

- [Aspose.Slides for PHP via Java Documentation](/slides/es/php-java/)
- [Aspose.Slides for PHP via Java API Reference](https://reference.aspose.com/slides/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)