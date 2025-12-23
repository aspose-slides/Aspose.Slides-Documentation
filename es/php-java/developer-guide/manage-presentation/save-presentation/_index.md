---
title: Guardar presentaciones en PHP
linktitle: Guardar presentación
type: docs
weight: 80
url: /es/php-java/save-presentation/
keywords:
- guardar PowerPoint
- guardar OpenDocument
- guardar presentación
- guardar diapositiva
- guardar PPT
- guardar PPTX
- guardar ODP
- presentación a archivo
- presentación a flujo
- tipo de vista predefinido
- formato Strict Office Open XML
- modo Zip64
- actualizar miniatura
- progreso de guardado
- PHP
- Aspose.Slides
description: "Descubra cómo guardar presentaciones usando Aspose.Slides para PHP a través de Java — exporte a PowerPoint u OpenDocument mientras conserva diseños, fuentes y efectos."
---

## **Descripción general**

[Open Presentations in PHP](/slides/es/php-java/open-presentation/) describió cómo usar la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones. La clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) contiene el contenido de una presentación. Ya sea que esté creando una presentación desde cero o modificando una existente, querrá guardarla cuando termine. Con Aspose.Slides para PHP, puede guardar en un **archivo** o **flujo**. Este artículo explica las diferentes formas de guardar una presentación.

## **Guardar presentaciones en archivos**

Guarde una presentación en un archivo llamando al método `save` de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Pase el nombre del archivo y el formato de guardado al método. El siguiente ejemplo muestra cómo guardar una presentación con Aspose.Slides.
```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Realizar algún trabajo aquí...

    // Guardar la presentación en un archivo.
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Guardar presentaciones en flujos**

Puede guardar una presentación en un flujo pasando un flujo de salida al método `save` de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Una presentación puede escribirse en muchos tipos de flujo. En el ejemplo a continuación, creamos una nueva presentación y la guardamos en un flujo de archivo.
```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    $fileStream = new Java("java.io.FileOutputStream", "Output.pptx");
    try {
        // Guardar la presentación en el flujo.
        $presentation->save($fileStream, SaveFormat::Pptx);
    } finally {
        $fileStream->close();
    }
} finally {
    $presentation->dispose();
}
```


## **Guardar presentaciones con un tipo de vista predefinido**

Aspose.Slides le permite establecer la vista inicial que PowerPoint usa cuando la presentación generada se abre mediante la clase [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/). Utilice el método [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/#setLastView) con un valor de la enumeración [ViewType](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/).
```php
$presentation = new Presentation();
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("SlideMasterView.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Guardar presentaciones en el formato Strict Office Open XML**

Aspose.Slides le permite guardar una presentación en el formato Strict Office Open XML. Utilice la clase [PptxOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/) y establezca su propiedad `conformance` al guardar. Si establece [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), el archivo de salida se guarda en el formato Strict Office Open XML.

El ejemplo a continuación crea una presentación y la guarda en el formato Strict Office Open XML.
```php
$options = new PptxOptions();
$options->setConformance(Conformance::Iso29500_2008_Strict);

// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation();
try {
    // Guardar la presentación en el formato Strict Office Open XML.
    $presentation->save("StrictOfficeOpenXml.pptx", SaveFormat::Pptx, $options);
} finally {
    $presentation->dispose();
}
```


## **Guardar presentaciones en Office Open XML en modo Zip64**

Un archivo Office Open XML es un archivo ZIP que impone límites de 4 GB (2^32 bytes) en el tamaño sin comprimir de cualquier archivo, el tamaño comprimido de cualquier archivo y el tamaño total del archivo, y también limita el archivo a 65 535 (2^16‑1) archivos. Las extensiones del formato ZIP64 elevan estos límites a 2^64.

El método [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setZip64Mode) le permite elegir cuándo usar extensiones de formato ZIP64 al guardar un archivo Office Open XML.

Este método se puede usar con los siguientes modos:

- [IfNecessary](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#IfNecessary) usa extensiones ZIP64 solo si la presentación supera las limitaciones anteriores. Es el modo predeterminado.
- [Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never) nunca usa extensiones ZIP64.
- [Always](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Always) siempre usa extensiones ZIP64.

El siguiente código demuestra cómo guardar una presentación como PPTX con extensiones ZIP64 habilitadas:
```php
$pptxOptions = new PptxOptions();
$pptxOptions->setZip64Mode(Zip64Mode::Always);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("OutputZip64.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="NOTE" color="warning" %}}

Cuando guarda con [Zip64Mode.Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never), se lanza una [PptxException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxexception/) si la presentación no puede guardarse en formato ZIP32.

{{% /alert %}}

## **Guardar presentaciones sin actualizar la miniatura**

El método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controla la generación de miniaturas al guardar una presentación en PPTX:

- Si se establece en `true`, la miniatura se actualiza durante el guardado. Es el valor predeterminado.
- Si se establece en `false`, se conserva la miniatura actual. Si la presentación no tiene miniatura, no se genera ninguna.

En el código a continuación, la presentación se guarda en PPTX sin actualizar su miniatura.
```php
$pptxOptions = new PptxOptions();
$pptxOptions->setRefreshThumbnail(false);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pptx", SaveFormat::Pptx, $pptxOptions);
}
finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}

Esta opción ayuda a reducir el tiempo necesario para guardar una presentación en formato PPTX.

{{% /alert %}}

## **Guardar actualizaciones de progreso en porcentaje**

Los informes de progreso de guardado se configuran mediante el método [setProgressCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setProgressCallback) en [SaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) y sus subclases. Proporcione un proxy Java que implemente la interfaz [IProgressCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iprogresscallback/); durante la exportación, la devolución de llamada recibe actualizaciones periódicas de porcentaje.

Los fragmentos de código siguientes muestran cómo usar `IProgressCallback`.
```php
class ExportProgressHandler {
    function reporting($progressValue) {
        // Utilice aquí el valor del porcentaje de progreso.
        $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
        echo($progress . "% of the file has been converted.");
    }
}

$progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));

$saveOptions = new PdfOptions();
$saveOptions->setProgressCallback($progressHandler);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Output.pdf", SaveFormat::Pdf, $saveOptions);
} finally {
    $presentation->dispose();
}
```


{{% alert title="Info" color="info" %}}

Aspose ha desarrollado una aplicación gratuita [PowerPoint Splitter](https://products.aspose.app/slides/splitter) utilizando su propia API. La aplicación le permite dividir una presentación en varios archivos guardando diapositivas seleccionadas como nuevos archivos PPTX o PPT.

{{% /alert %}}

## **Preguntas frecuentes**

**¿Se admite el “guardado rápido” (guardado incremental) para que solo se escriban los cambios?**

No. Cada guardado crea el archivo completo de destino; el “guardado rápido” incremental no está soportado.

**¿Es seguro desde varios subprocesos guardar la misma instancia de Presentation?**

No. Una instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) **no es segura para subprocesos**; guárdela desde un solo subproceso.

**¿Qué ocurre con los hipervínculos y los archivos vinculados externamente al guardar?**

Los [hipervínculos](/slides/es/php-java/manage-hyperlinks/) se conservan. Los archivos vinculados externamente (p. ej., videos mediante rutas relativas) no se copian automáticamente; asegúrese de que las rutas referenciadas sigan siendo accesibles.

**¿Puedo establecer/guardar metadatos del documento (Autor, Título, Compañía, Fecha)?**

Sí. Las [propiedades del documento](/slides/es/php-java/presentation-properties/) estándar son compatibles y se escribirán en el archivo al guardarse.