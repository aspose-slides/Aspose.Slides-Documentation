---
title: Convertir PowerPoint a PDF
linktitle: Convertir PowerPoint a PDF
type: docs
weight: 40
url: /php-java/convert-powerpoint-to-pdf/
keywords: "Convertir PowerPoint, Presentación, PowerPoint a PDF, PPT a PDF, PPTX a PDF, Guardar PowerPoint como PDF, PDF/A1a, PDF/A1b, PDF/UA, Java"
description: "Convertir Presentación de PowerPoint a PDF. Guardar PowerPoint como PDF cumpliendo con estándares de conformidad o accesibilidad"

---
## **Descripción general**

Este artículo explica cómo se pueden convertir los formatos de archivo de PowerPoint a PDF utilizando PHP. Cubre una amplia gama de temas, por ejemplo:

- Convertir PPT a PDF
- Convertir PPTX a PDF
- Convertir ODP a PDF
- Convertir PowerPoint a PDF

## **Conversiones de PowerPoint a PDF en Java**

Usando Aspose.Slides, puedes convertir presentaciones en estos formatos a PDF:

* PPT
* PPTX
* ODP

Para convertir una presentación a PDF, simplemente tienes que pasar el nombre del archivo como un argumento en la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) y luego guardar la presentación como un PDF usando un método [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-). La clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) expone el método [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) que se utiliza típicamente para convertir una presentación a PDF.

{{%  alert title="NOTA"  color="warning"   %}} 

Aspose.Slides para PHP a través de Java escribe directamente la información de la API y el número de versión en los documentos de salida. Por ejemplo, cuando convierte una presentación a PDF, Aspose.Slides para PHP a través de Java llena el campo de aplicación con el valor '*Aspose.Slides*' y el campo de productor PDF con un valor en forma de '*Aspose.Slides v XX.XX*'. **Nota** que no puedes instruir a Aspose.Slides para PHP a través de Java para cambiar o eliminar esta información de los documentos de salida.

{{% /alert %}}

Aspose.Slides te permite convertir:

* una presentación completa a PDF
* diapositivas específicas en una presentación a PDF
* una presentación 

Aspose.Slides exporta presentaciones a PDF de una manera que hace que el contenido de los PDFs resultantes sea muy similar al de las presentaciones originales. Estos elementos y atributos conocidos a menudo se representan correctamente en las conversiones de presentación a PDF:

* imágenes
* cuadros de texto y otras formas
* textos y su formato
* párrafos y su formato
* hiperenlaces
* encabezados y pies de página
* viñetas
* tablas

## **Convertir PowerPoint a PDF**

La operación estándar de conversión de PowerPoint a PDF se ejecuta utilizando opciones predeterminadas. En este caso, Aspose.Slides intenta convertir la presentación proporcionada a PDF utilizando configuraciones óptimas en los niveles de calidad máximos.

Este código PHP te muestra cómo convertir un PowerPoint a PDF:

```php
  # Instancia una clase Presentation que representa un archivo PowerPoint
  $pres = new Presentation("PowerPoint.ppt");
  try {
    # Guarda la presentación como un PDF
    $pres->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  color="primary"  %}} 

Aspose proporciona un [**convertidor de PowerPoint a PDF gratis**](https://products.aspose.app/slides/conversion/ppt-to-pdf) que demuestra el proceso de conversión de presentación a PDF. Para una implementación en vivo del procedimiento descrito aquí, puedes hacer una prueba con el convertidor.

{{% /alert %}}

## **Convertir PowerPoint a PDF con Opciones**

Aspose.Slides proporciona opciones personalizadas—propiedades bajo la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions)—que te permiten personalizar el PDF (resultante del proceso de conversión), bloquear el PDF con una contraseña, o incluso especificar cómo debería desarrollarse el proceso de conversión.

### **Convertir PowerPoint a PDF con Opciones Personalizadas**

Usando opciones de conversión personalizadas, puedes establecer tu configuración de calidad preferida para imágenes JPG, especificar cómo deberían manejarse los metafiles, establecer un nivel de compresión para los textos, etc.

Este código PHP demuestra una operación en la que un PowerPoint se convierte a PDF con varias opciones personalizadas:

```php
// Instancia una clase Presentation que representa un archivo PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # Instancia la clase PdfOptions
    $pdfOptions = new PdfOptions();
    # Establece la calidad de Jpeg
    $pdfOptions->setJpegQuality(90);
    # Establece el comportamiento para los metafiles
    $pdfOptions->setSaveMetafilesAsPng(true);
    # Establece el nivel de compresión de textos
    $pdfOptions->setTextCompression(PdfTextCompression::Flate);
    # Define el estándar PDF
    $pdfOptions->setCompliance(PdfCompliance::Pdf15);
    # Guarda la presentación como un PDF
    $pres->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Convertir PowerPoint a PDF con Diapositivas Ocultas**

Si una presentación contiene diapositivas ocultas, puedes usar una opción personalizada—la propiedad [ShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IPdfOptions#getShowHiddenSlides--) de la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions)—para instruir a Aspose.Slides que incluya las diapositivas ocultas como páginas en el PDF resultante.

Este código PHP te muestra cómo convertir una presentación de PowerPoint a PDF incluyendo diapositivas ocultas:

```php
// Instancia una clase Presentation que representa un archivo PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # Instancia la clase PdfOptions
    $pdfOptions = new PdfOptions();
    # Agrega diapositivas ocultas
    $pdfOptions->setShowHiddenSlides(true);
    # Guarda la presentación como un PDF
    $pres->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Convertir PowerPoint a PDF Protegido con Contraseña**

Este código PHP te muestra cómo convertir un PowerPoint a un PDF protegido con contraseña (usando parámetros de protección de la clase [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions)):

```php
// Instancia un objeto Presentation que representa un archivo PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # Instancia la clase PdfOptions
    $pdfOptions = new PdfOptions();
    # Establece la contraseña PDF y permisos de acceso
    $pdfOptions->setPassword("contraseña");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);
    # Guarda la presentación como un PDF
    $pres->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### Detectar Sustituciones de Fuentes**

Aspose.Slides proporciona el método [getWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#getWarningCallback--) bajo la clase [SaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) para permitirte detectar sustituciones de fuentes en un proceso de conversión de presentación a PDF.

Este código PHP te muestra cómo detectar sustituciones de fuentes:

```php

class FontSubstSendsWarningCallback {
    function warning($warning)
    {
          if (java_values($warning->getWarningType() == WarningType::CompatibilityIssue)) {
            return ReturnAction::Continue;
          }
          if (java_values($warning->getWarningType() == WarningType::DataLoss && $warning->getDescription()->startsWith("Se sustituirá la fuente"))) {
            echo ("Advertencia de sustitución de fuente: " . $warning->getDescription());
          }
          return ReturnAction::Continue;
    }
}

  $loadOptions = new LoadOptions();
  $warningCallback = java_closure(new FontSubstSendsWarningCallback(), null, java("com.aspose.slides.IWarningCallback"));
  $loadOptions->setWarningCallback($warningCallback);
  $pres = new Presentation("pres.pptx", $loadOptions);
  try {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

Para más información sobre cómo obtener devoluciones de llamada para sustituciones de fuentes en un proceso de renderización, consulta [Obteniendo devoluciones de llamada de advertencia para sustitución de fuentes](https://docs.aspose.com/slides/php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Para más información sobre la sustitución de fuentes, consulta el artículo [Sustitución de Fuentes](https://docs.aspose.com/slides/php-java/font-substitution/).

{{% /alert %}} 

## **Convertir Diapositivas Seleccionadas en PowerPoint a PDF**

Este código PHP te muestra cómo convertir diapositivas específicas en una presentación de PowerPoint a PDF:

```php
// Instancia un objeto Presentation que representa un archivo PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # Establece un array de posiciones de diapositivas
    $slides = array(1, 3 );
    # Guarda la presentación como un PDF
    $pres->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertir PowerPoint a PDF con Tamaño de Diapositiva Personalizado**

Este código PHP te muestra cómo convertir un PowerPoint cuando su tamaño de diapositiva está especificado a un PDF:

```php
// Instancia un objeto Presentation que representa un archivo PowerPoint 
  $pres = new Presentation("SelectedSlides.pptx");
  try {
    $outPres = new Presentation();
    try {
      $slide = $pres->getSlides()->get_Item(0);
      $outPres->getSlides()->insertClone(0, $slide);
      # Establece el tipo y tamaño de la diapositiva
      $outPres->getSlideSize()->setSize(612.0, 792.0, SlideSizeScaleType::EnsureFit);
      $pdfOptions = new PdfOptions();
      $options = $pdfOptions->getNotesCommentsLayouting();
      $options->setNotesPosition(NotesPositions::BottomFull);
      $outPres->save("PDFnotes_out.pdf", SaveFormat::Pdf, $pdfOptions);
    } finally {
      if (!java_is_null($pres)) {
        $pres->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertir PowerPoint a PDF en Vista de Diapositivas de Notas**

Este código PHP te muestra cómo convertir un PowerPoint a PDF con notas:

```php
// Instancia una clase Presentation que representa un archivo PowerPoint
  $pres = new Presentation("SelectedSlides.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $options = $pdfOptions->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    $pres->save("Pdf_With_Notes.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Estándares de Accesibilidad y Conformidad para PDF**

Aspose.Slides te permite usar un procedimiento de conversión que cumple con las [Directrices de Accesibilidad al Contenido Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Puedes exportar un documento de PowerPoint a PDF usando cualquiera de estos estándares de conformidad: **PDF/A1a**, **PDF/A1b**, y **PDF/UA**.

Este código PHP demuestra una operación de conversión de PowerPoint a PDF en la que se obtienen múltiples PDFs basados en diferentes estándares de conformidad:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $pres->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $pres->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $pres->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Nota" color="warning" %}} 

El soporte de Aspose.Slides para operaciones de conversión a PDF se extiende a permitirte convertir PDFs a los formatos de archivo más populares. Puedes hacer conversiones de [PDF a HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF a imagen](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF a JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), y [PDF a PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). Otras operaciones de conversión de PDF a formatos especializados—[PDF a SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF a TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), y [PDF a XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—también son compatibles.

{{% /alert %}}