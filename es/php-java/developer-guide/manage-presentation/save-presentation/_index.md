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
- refrescar miniatura
- progreso de guardado
- PHP
- Aspose.Slides
description: "Descubra cómo guardar presentaciones usando Aspose.Slides para PHP a través de Java — exporte a PowerPoint u OpenDocument manteniendo diseños, fuentes y efectos."
---
## **Visión general**

[Open Presentations in PHP](/slides/es/php-java/open-presentation/) describió cómo usar la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) para abrir una presentación. Este artículo explica cómo crear y guardar presentaciones. La clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) contiene el contenido de una presentación. Tanto si está creando una presentación desde cero como si está modificando una existente, querrá guardarla cuando haya terminado. Con Aspose.Slides para PHP, puede guardar en un **archivo** o **flujo**. Este artículo explica las diferentes formas de guardar una presentación.

## **Guardar presentaciones en archivos**

Guarde una presentación en un archivo llamando al método `save` de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/). Pase el nombre del archivo y el formato de guardado al método. El siguiente ejemplo muestra cómo guardar una presentación con Aspose.Slides.

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

Puede guardar una presentación en un flujo pasando un flujo de salida al método `save` de la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/). Una presentación puede escribirse en muchos tipos de flujo. En el ejemplo siguiente, creamos una nueva presentación y la guardamos en un flujo de archivo.

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

Aspose.Slides le permite establecer la vista inicial que PowerPoint utiliza cuando se abre la presentación generada a través de la clase [ViewProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/viewproperties/). Utilice el método [setLastView](https://reference.aspose.com/slides/es/php-java/aspose.slides/viewproperties/#setLastView) con un valor de la enumeración [ViewType](https://reference.aspose.com/slides/es/php-java/aspose.slides/viewtype/).

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

Aspose.Slides le permite guardar una presentación en el formato Strict Office Open XML. Utilice la clase [PptxOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxoptions/) y establezca su propiedad `conformance` al guardar. Si establece [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/es/php-java/aspose.slides/conformance/#Iso29500_2008_Strict), el archivo de salida se guarda en el formato Strict Office Open XML.

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

## **Guardar presentaciones en formato Office Open XML en modo Zip64**

Un archivo Office Open XML es un archivo ZIP que impone límites de 4 GB (2^32 bytes) al tamaño sin comprimir de cualquier archivo, al tamaño comprimido de cualquier archivo y al tamaño total del archivo, y también limita el archivo a 65 535 (2^16‑1) archivos. Las extensiones de formato ZIP64 elevan estos límites a 2^64.

El método [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxoptions/#setZip64Mode) le permite elegir cuándo usar las extensiones de formato ZIP64 al guardar un archivo Office Open XML.

Este método puede usarse con los siguientes modos:

- [IfNecessary](https://reference.aspose.com/slides/es/php-java/aspose.slides/zip64mode/#IfNecessary) utiliza las extensiones ZIP64 solo si la presentación supera las limitaciones anteriores. Este es el modo predeterminado.
- [Never](https://reference.aspose.com/slides/es/php-java/aspose.slides/zip64mode/#Never) nunca utiliza las extensiones ZIP64.
- [Always](https://reference.aspose.com/slides/es/php-java/aspose.slides/zip64mode/#Always) siempre utiliza las extensiones ZIP64.

El siguiente fragmento de código muestra cómo guardar una presentación como archivo PPTX con las extensiones ZIP64 activadas:

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
Cuando guarda con [Zip64Mode.Never](https://reference.aspose.com/slides/es/php-java/aspose.slides/zip64mode/#Never), se lanza una [PptxException](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxexception/) si la presentación no puede guardarse en formato ZIP32.
{{% /alert %}}

## **Guardar presentaciones en formato Office Open XML con niveles de compresión**

Al trabajar con presentaciones grandes, puede ajustar el nivel de compresión para equilibrar el tamaño del archivo y el tiempo de procesamiento. Según sus requisitos, puede preferir un procesamiento más rápido o archivos de salida más pequeños.

Aspose.Slides proporciona el método [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxoptions/#setCompressionLevel), que permite especificar el nivel de compresión utilizado al guardar una presentación en formato Office Open XML.

Los siguientes niveles de compresión están disponibles:

- [**None**](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#None): No se aplica compresión. Los archivos se almacenan tal cual.
- [**Level1**](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level1): Compresión más rápida con la relación de compresión más baja.
- [**Level2**](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level2): Compresión rápida con una relación ligeramente mejor que **Level1**.
- [**Level3**](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level3): Ofrece mejor compresión que **Level2** con un impacto moderado en el tiempo de procesamiento.
- [**Level4**](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level4): Proporciona mejor compresión que **Level3**.
- [**Level5**](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level5): Mejora la compresión con respecto a **Level4** a costa de mayor tiempo de procesamiento.
- [**Level6**](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level6): Compresión estándar que ofrece un buen equilibrio entre velocidad de procesamiento y tamaño de archivo. Este es el *nivel de compresión predeterminado*.
- [**Level7**](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level7): Proporciona mejor compresión que **Level6** pero con procesamiento más lento.
- [**Level8**](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level8): Proporciona mejor compresión que **Level7**.
- [**Level9**](https://reference.aspose.com/slides/es/php-java/aspose.slides/compressionlevel/#Level9): Compresión máxima. Produce el archivo más pequeño al costo del mayor tiempo de procesamiento.

El siguiente ejemplo demuestra cómo guardar una presentación como archivo PPTX *sin compresión*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::None);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-out.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

Este ejemplo muestra cómo guardar una presentación como archivo PPTX con *compresión máxima*:

```php
$pptxOptions = new PptxOptions();
$pptxOptions->setCompressionLevel(CompressionLevel::Level9);

$presentation = new Presentation("Sample.pptx");
try {
    $presentation->save("Sample-level9.pptx", SaveFormat::Pptx, $pptxOptions);
} finally {
    $presentation->dispose();
}
```

## **Guardar presentaciones sin refrescar la miniatura**

El método [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/es/php-java/aspose.slides/pptxoptions/#setRefreshThumbnail) controla la generación de miniaturas al guardar una presentación en PPTX:

- Si se establece en `true`, la miniatura se refresca durante el guardado. Este es el valor predeterminado.
- Si se establece en `false`, se preserva la miniatura actual. Si la presentación no tiene miniatura, no se genera ninguna.

En el código a continuación, la presentación se guarda en PPTX sin refrescar su miniatura.

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

Los informes de progreso de guardado se configuran mediante el método [setProgressCallback](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveoptions/#setProgressCallback) en [SaveOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveoptions/) y sus subclases. Proporcione un proxy Java que implemente la interfaz [IProgressCallback](https://reference.aspose.com/slides/es/java/com.aspose.slides/iprogresscallback/); durante la exportación, la devolución de llamada recibe actualizaciones periódicas de porcentaje.

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
Aspose ha desarrollado una [aplicación gratuita PowerPoint Splitter](https://products.aspose.app/slides/es/splitter) usando su propia API. La aplicación le permite dividir una presentación en varios archivos guardando diapositivas seleccionadas como nuevos archivos PPTX o PPT.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se admite el "guardado rápido" (guardado incremental) para que solo se escriban los cambios?**

No. Cada guardado crea el archivo completo de destino; el guardado incremental "rápido" no está soportado.

**¿Es seguro guardar la misma instancia de Presentation desde varios hilos?**

No. Una instancia de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) **no es segura para subprocesos** (/slides/es/php-java/multithreading/); guárdela desde un solo hilo.

**¿Qué ocurre con los hipervínculos y los archivos vinculados externamente al guardar?**

Los [hipervínculos](/slides/es/php-java/manage-hyperlinks/) se conservan. Los archivos vinculados externamente (por ejemplo, videos mediante rutas relativas) no se copian automáticamente; asegúrese de que las rutas referenciadas sigan siendo accesibles.

**¿Puedo establecer/guardar metadatos del documento (Autor, Título, Empresa, Fecha)?**

Sí. Las [propiedades estándar del documento](/slides/es/php-java/presentation-properties/) son compatibles y se escribirán en el archivo al guardarlo.