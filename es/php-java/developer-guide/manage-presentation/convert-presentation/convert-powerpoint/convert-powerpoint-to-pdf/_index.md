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
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Convertir presentaciones PowerPoint PPT/PPTX a PDFs de alta calidad y buscables en PHP usando Aspose.Slides, con ejemplos de código rápidos y opciones de conversión avanzadas."
---

## **Descripción general**

Convertir presentaciones de PowerPoint (PPT, PPTX, ODP, etc.) a formato PDF en PHP ofrece varias ventajas, incluida la compatibilidad entre diferentes dispositivos y la preservación del diseño y formato de tu presentación. Esta guía muestra cómo convertir presentaciones a documentos PDF, usar diversas opciones para controlar la calidad de la imagen, incluir diapositivas ocultas, proteger con contraseña los archivos PDF, detectar sustituciones de fuentes, seleccionar diapositivas específicas para la conversión y aplicar normas de cumplimiento a los documentos de salida.

## **Conversiones de PowerPoint a PDF**

Con Aspose.Slides, puedes convertir presentaciones en los siguientes formatos a PDF:

* **PPT**
* **PPTX**
* **ODP**

Para convertir una presentación a PDF, pasa el nombre del archivo como argumento a la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) y luego guarda la presentación como PDF usando un método `save`. La clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) expone el método `save` que se utiliza típicamente para convertir una presentación a PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for PHP via Java inserta la información de su API y el número de versión en los documentos de salida. Por ejemplo, al convertir una presentación a PDF, Aspose.Slides rellena el campo Application con "*Aspose.Slides*" y el campo PDF Producer con un valor del tipo "*Aspose.Slides v XX.XX*". **Note** que no puedes indicar a Aspose.Slides que cambie o elimine esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides permite convertir:

* Presentaciones completas a PDF
* Diapositivas específicas de una presentación a PDF

Aspose.Slides exporta presentaciones a PDF, asegurando que los PDF resultantes coincidan estrechamente con las presentaciones originales. Los elementos y atributos se renderizan con exactitud durante la conversión, incluyendo:

* Imágenes
* Cuadros de texto y formas
* Formato de texto
* Formato de párrafo
* Hipervínculos
* Cabeceras y pies de página
* Viñetas
* Tablas

## **Convertir PowerPoint a PDF**

El proceso estándar de conversión de PowerPoint a PDF usa opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF usando ajustes óptimos en los niveles máximos de calidad.

Este código muestra cómo convertir una presentación (PPT, PPTX, ODP, etc.) a PDF:
```php
# Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Guardar la presentación como PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose ofrece un [**convertidor online gratuito de PowerPoint a PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) que muestra el proceso de conversión de presentación a PDF. Puedes probar este convertidor para una implementación en directo del procedimiento descrito aquí.

{{% /alert %}}

## **Convertir PowerPoint a PDF con Opciones**

Aspose.Slides proporciona opciones personalizadas —propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions)— que permiten personalizar el PDF resultante, bloquear el PDF con una contraseña o especificar cómo debe proceder el proceso de conversión.

### **Convertir PowerPoint a PDF con Opciones Personalizadas**

Usando opciones de conversión personalizadas, puedes definir tu configuración de calidad preferida para imágenes rasterizadas, especificar cómo deben manejarse los metafiles, establecer un nivel de compresión para el texto, configurar DPI para las imágenes y más.

El ejemplo de código a continuación muestra cómo convertir una presentación de PowerPoint a PDF con varias opciones personalizadas.
```php
# Instanciar la clase PdfOptions.
$pdfOptions = new PdfOptions();

# Establecer la calidad para imágenes JPG.
$pdfOptions->setJpegQuality(90);

# Establecer DPI para imágenes.
$pdfOptions->setSufficientResolution(300);

# Establecer el comportamiento de los metafiles.
$pdfOptions->setSaveMetafilesAsPng(true);

# Establecer el nivel de compresión de texto para el contenido textual.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# Definir el modo de cumplimiento PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Guardar la presentación como documento PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **Convertir PowerPoint a PDF con Diapositivas Ocultas**

Si una presentación contiene diapositivas ocultas, puedes usar el método [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) de la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) para incluir las diapositivas ocultas como páginas en el PDF resultante.

Este código muestra cómo convertir una presentación de PowerPoint a PDF con las diapositivas ocultas incluidas:
```php
# Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Instanciar la clase PdfOptions.
    $pdfOptions = new PdfOptions();

    # Añadir diapositivas ocultas.
    $pdfOptions->setShowHiddenSlides(true);

    # Guardar la presentación como PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **Convertir PowerPoint a PDF Protegido con Contraseña**

Este código demuestra cómo convertir una presentación de PowerPoint en un PDF protegido con contraseña usando los parámetros de protección de la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/):
```php
# Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Instanciar la clase PdfOptions.
    $pdfOptions = new PdfOptions();

    # Establecer una contraseña PDF y permisos de acceso.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Guardar la presentación como PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **Detectar Sustituciones de Fuentes**

Aspose.Slides proporciona el método [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) bajo la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) que permite detectar sustituciones de fuentes durante el proceso de conversión de presentación a PDF.

Este código muestra cómo detectar sustituciones de fuentes:
```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// Establecer la devolución de llamada de advertencia en las opciones PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
$presentation = new Presentation("sample.pptx");
try {
    // Guardar la presentación como PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


{{%  alert color="primary"  %}} 

Para más información sobre la sustitución de fuentes, consulta el artículo [Font Substitution](/slides/es/php-java/font-substitution/).

{{% /alert %}} 

## **Convertir Diapositivas Seleccionadas de PowerPoint a PDF**

Este código muestra cómo convertir solo diapositivas específicas de una presentación de PowerPoint a PDF:
```php
# Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Establecer el array de números de diapositivas.
    $slides = array(1, 3);

    # Guardar la presentación como PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```


## **Convertir PowerPoint a PDF con Tamaño de Diapositiva Personalizado**

Este código muestra cómo convertir una presentación de PowerPoint a PDF con un tamaño de diapositiva especificado:
```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");

# Crear una nueva presentación con un tamaño de diapositiva ajustado.
$resizedPresentation = new Presentation();

try {
    # Establecer el tamaño de diapositiva personalizado.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Clonar la primera diapositiva de la presentación original.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Guardar la presentación redimensionada en un PDF con notas.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```


## **Convertir PowerPoint a PDF en Vista de Diapositiva de Notas**

Este código muestra cómo convertir una presentación de PowerPoint a un PDF que incluye notas:
```php
# Instanciar la clase Presentation que representa un archivo PowerPoint o OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Configurar las opciones PDF con diseño de notas.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Guardar la presentación en un PDF con notas.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


## **Estándares de Accesibilidad y Cumplimiento para PDF**

Aspose.Slides permite usar un procedimiento de conversión que cumple con las [Directrices de Accesibilidad al Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puedes exportar un documento de PowerPoint a PDF utilizando cualquiera de estos estándares de cumplimiento: **PDF/A1a**, **PDF/A1b** y **PDF/UA**.

Este código demuestra un proceso de conversión de PowerPoint a PDF que genera varios PDF basados en diferentes estándares de cumplimiento:
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


{{% alert title="Note" color="warning" %}} 

Aspose.Slides admite operaciones de conversión a PDF, lo que permite convertir archivos PDF a formatos de archivo populares. Puedes realizar conversiones de [PDF a HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). Otras conversiones de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—también están soportadas.

{{% /alert %}}

## **FAQ**

**¿Puedo convertir varios archivos de PowerPoint a PDF en lote?**

Sí, Aspose.Slides soporta la conversión por lotes de múltiples archivos PPT o PPTX a PDF. Puedes iterar sobre tus archivos y aplicar el proceso de conversión programáticamente.

**¿Es posible proteger con contraseña el PDF convertido?**

Absolutamente. Usa la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para establecer una contraseña y definir permisos de acceso durante el proceso de conversión.

**¿Cómo incluyo diapositivas ocultas en el PDF?**

Utiliza el método `setShowHiddenSlides` en la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para incluir las diapositivas ocultas en el PDF resultante.

**¿Puede Aspose.Slides mantener alta calidad de imagen en el PDF?**

Sí, puedes controlar la calidad de la imagen usando métodos como `setJpegQuality` y `setSufficientResolution` en la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) para asegurar imágenes de alta calidad en tu PDF.

**¿Aspose.Slides soporta los estándares de cumplimiento PDF/A?**

Sí, Aspose.Slides permite exportar PDFs que cumplen con varios estándares, incluidos PDF/A1a, PDF/A1b y PDF/UA, garantizando que tus documentos cumplan con los requisitos de accesibilidad y archivo.

## **Recursos adicionales**

- [Documentación de Aspose.Slides for PHP via Java](/slides/es/php-java/)
- [Referencia de API de Aspose.Slides for PHP via Java](https://reference.aspose.com/slides/php-java/)
- [Convertidores Online Gratuitos de Aspose](https://products.aspose.app/slides/conversion)