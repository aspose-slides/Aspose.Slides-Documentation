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
description: "Convertir PowerPoint PPT/PPTX a PDFs de alta calidad y buscables en PHP usando Aspose.Slides, con ejemplos de código rápidos y opciones de conversión avanzadas."
---
## **Visión general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP, etc.) a formato PDF en PHP ofrece varias ventajas, entre ellas la compatibilidad con diferentes dispositivos y la preservación del diseño y formato de su presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar diversas opciones para controlar la calidad de las imágenes, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puede convertir presentaciones en los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pase el nombre del archivo como argumento a la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y luego guarde la presentación como PDF usando el método [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). La clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) expone el método [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) que se utiliza típicamente para convertir una presentación a PDF.

{{% alert color="info" title="Note" %}}

Aspose.Slides for PHP via Java inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides completa el campo Application con "*Aspose.Slides*" y el campo PDF Producer con un valor en forma "*Aspose.Slides v XX.XX*". **Note** que no puede indicar a Aspose.Slides que cambie o elimine esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, garantizando que los PDFs resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con precisión en la conversión, incluidos:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Encabezados y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

El proceso estándar de conversión de PowerPoint a PDF utiliza opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando configuraciones óptimas con los niveles máximos de calidad.

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

Aspose ofrece un [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) en línea gratuito que muestra el proceso de conversión de presentación a PDF. Puede probar este conversor para ver una implementación en tiempo real del procedimiento descrito aquí.

{{% /alert %}}

## **Convertir PowerPoint a PDF con opciones**

Aspose.Slides proporciona opciones personalizadas—propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/)—que le permiten personalizar el PDF resultante, bloquear el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con opciones personalizadas**

Con opciones de conversión personalizadas, puede definir su configuración de calidad preferida para imágenes raster, especificar cómo se deben manejar los metafiles, establecer un nivel de compresión para el texto, configurar DPI para imágenes y más.

El siguiente ejemplo exporta una presentación a PDF 1.5 con calidad JPEG establecida en 90, resolución de imagen en 300 DPI, metafiles guardados como PNG y compresión de texto Flate.

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

### **Conservar archivos OLE incrustados como adjuntos PDF**

Si una presentación contiene un libro de Excel incrustado, puede que desee que los destinatarios del PDF accedan a los datos del libro y también vean las diapositivas. Llame a [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) con `true` para conservar los archivos OLE incrustados como adjuntos en el PDF resultante.

El valor predeterminado es `false`: la imagen de vista previa o el ícono del objeto OLE se renderiza en la página PDF, pero su archivo incrustado no se incluye como adjunto. Establecer la opción en `true` incluye además los datos del archivo. La vista previa sigue siendo una representación visual; el adjunto permite a los destinatarios abrir o guardar el archivo incrustado por separado. El objeto OLE no se convierte en una hoja de cálculo interactiva en la página PDF.

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

1. Abra el PDF exportado en un visor que admita adjuntos de archivo, como Adobe Acrobat Reader.
2. Abra el panel **Attachments** del visor y localice el libro de trabajo incrustado.
3. Guarde el adjunto y ábralo en Excel para inspeccionar sus datos, o ábralo directamente si el visor lo permite. La vista previa en la página PDF es independiente del adjunto.

{{% alert color="info" title="Note" %}}

Las normas PDF/A imponen restricciones sobre los adjuntos: PDF/A-1 prohíbe archivos incrustados, PDF/A-2 permite solo adjuntos PDF/A y PDF/A-3 permite otros tipos de archivo, incluidos libros de Excel. Estas son exigencias de las normas, no restricciones específicas de Aspose.Slides. Este ejemplo usa la configuración de cumplimiento PDF predeterminada y no muestra la exportación PDF/A.

{{% /alert %}}

### **Convertir PowerPoint a PDF con diapositivas ocultas**

Si una presentación contiene diapositivas ocultas, puede usar el método [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) de la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para incluir las diapositivas ocultas como páginas en el PDF resultante.

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

Aspose.Slides proporciona el método [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) bajo la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/), lo que le permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

El siguiente ejemplo exporta una presentación a PDF e imprime advertencias de sustitución de fuentes en la consola. Sólo se imprime una advertencia cuando una fuente no disponible es sustituida durante la exportación.

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

Para obtener más información sobre sustitución de fuentes, consulte el artículo [Font Substitution](/slides/es/php-java/font-substitution/).

{{% /alert %}} 

### **Gestionar fuentes sin una variante negrita dedicada**

Una presentación puede aplicar formato en negrita a un texto aunque su fuente no tenga una variante de negrita dedicada. El texto puede seguir apareciendo en negrita mediante un “synthetic bold”, que engrosa artificialmente los glifos normales. Cuando ese texto resulta demasiado grueso o difiere de la apariencia deseada en el PDF, pruebe a llamar a [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) con `true`. Esta opción renderiza el texto afectado como mapa de bits durante la exportación a PDF y puede mejorar su apariencia para ciertas fuentes. Su valor predeterminado es `false`.

La muestra de presentación contiene dos cuadros de texto: uno con texto normal y otro con formato en negrita aplicado a la misma fuente, que no tiene variante de negrita dedicada. El siguiente ejemplo carga la presentación, habilita la rasterización de estilos de fuente no soportados y la exporta a PDF:

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

Las siguientes vistas previas muestran la salida desactivada y la salida activada. En este ejemplo, el texto en negrita tiene trazos más gruesos con la opción desactivada. Con la opción activada, sus trazos son más ligeros; el texto regular permanece sin cambios. Compare los resultados antes de decidir la configuración para su presentación.

| Opción desactivada (`false`, por defecto) | Opción activada (`true`) |
|---|---|
| ![PDF con rasterización de estilo de fuente no compatible desactivada](unsupported-bold-disabled.png) | ![PDF con rasterización de estilo de fuente no compatible activada](unsupported-bold-enabled.png) |

En este ejemplo, habilitar la opción convierte solo el texto en negrita en un mapa de bits: no puede seleccionarse, copiarse ni buscarse como texto sin OCR, y sus bordes aparecen más suaves al 800 % de zoom. El texto regular sigue siendo buscable. Con la opción desactivada, ambas cadenas permanecen como texto.

Esta opción rasteriza el texto formateado en negrita cuando su fuente no dispone de una variante de negrita dedicada. La [Font substitution](/slides/es/php-java/font-substitution/) en su lugar selecciona otra fuente cuando la original no está disponible.

## **Convertir diapositivas seleccionadas de PowerPoint a PDF**

El siguiente ejemplo exporta las diapositivas 1 y 3 de una presentación a PDF. Los números de diapositiva en esta matriz son basados en 1, y la presentación de entrada debe contener al menos tres diapositivas.

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

## **Convertir PowerPoint a PDF con tamaño de diapositiva personalizado**

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

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Convertir PowerPoint a PDF en vista de diapositivas de notas**

El siguiente ejemplo exporta una presentación a PDF, colocando las notas del orador de cada diapositiva debajo de la misma. Use una presentación que contenga notas del orador para ver el resultado.

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

## **Accesibilidad y normas de cumplimiento para PDF**

Aspose.Slides le permite usar un procedimiento de conversión que cumple con las [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puede exportar un documento PowerPoint a PDF usando cualquiera de estas normas de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código demuestra un proceso de conversión de PowerPoint a PDF que genera varios PDFs basados en diferentes normas de cumplimiento:

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

Aspose.Slides admite operaciones de conversión de PDF, permitiendo convertir archivos PDF a formatos de archivo populares. Puede realizar conversiones de [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) y [PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados—[PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), y [PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—también son compatibles.

{{% /alert %}}

> **Note:** Cuando se exporta a PDF/UA, Aspose.Slides trata los gráficos complejos como SmartArt, diagramas y fórmulas como una única figura. Los elementos de ruta individuales no se conservan como contenido separado y pueden marcarse como artefactos; el texto alternativo se proporciona solo para la figura completa.

## **Preguntas frecuentes**

**¿Puedo convertir varios archivos PowerPoint a PDF de forma masiva?**

Sí, Aspose.Slides admite la conversión por lotes de múltiples archivos PPT o PPTX a PDF. Puede iterar sobre sus archivos y aplicar el proceso de conversión mediante código.

**¿Es posible proteger con contraseña el PDF convertido?**

Sí. Utilice la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para establecer una contraseña y definir permisos de acceso durante el proceso de conversión.

**¿Cómo incluyo diapositivas ocultas en el PDF?**

Llame a [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) con `true` en la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para incluir las diapositivas ocultas en el PDF resultante.

**¿Aspose.Slides mantiene alta calidad de imagen en el PDF?**

Sí, puede controlar la calidad de imagen utilizando métodos como [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) y [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) en la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para garantizar imágenes de alta calidad en su PDF.

**¿Aspose.Slides soporta normas de cumplimiento PDF/A?**

Sí, Aspose.Slides le permite exportar PDFs que cumplen con [varias normas](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), incluidas PDF/A1a, PDF/A1b y PDF/UA, garantizando que sus documentos cumplan con los requisitos de accesibilidad y archivo.

## **Recursos adicionales**

- [Aspose.Slides for PHP via Java Documentation](/slides/es/php-java/)
- [Aspose.Slides for PHP via Java API Reference](https://reference.aspose.com/slides/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)