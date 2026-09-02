---
title: Convertir presentaciones de PowerPoint a XML en PHP
linktitle: PowerPoint a XML
type: docs
weight: 145
url: /es/php-java/convert-powerpoint-to-xml/
keywords:
- convertir PowerPoint a XML
- convertir presentación a XML
- PPT a XML
- PPTX a XML
- ODP a XML
- Presentación PowerPoint XML
- SaveFormat.Xml
- guardar presentación como XML
- exportar presentación a XML
- flujo XML
- PHP
- Aspose.Slides
description: "Convertir presentaciones de PowerPoint y OpenDocument a archivos o flujos XML de PowerPoint en PHP con Aspose.Slides para PHP a través de Java."
---
## **Visión general**

Aspose.Slides for PHP via Java puede convertir presentaciones de PowerPoint al formato PowerPoint XML Presentation. La salida XML es útil cuando necesita una representación basada en texto para inspeccionar la estructura de la presentación, solucionar problemas de documentos generados, comparar la salida en pruebas automatizadas o integrar con un flujo de trabajo que consume XML en lugar de un paquete de presentación.

Use el método [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) con el valor `Xml` del enumerado [SaveFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/). Puede escribir el resultado directamente a un archivo o a un flujo.

{{% alert color="info" title="Nota" %}}

`SaveFormat::Xml` crea una PowerPoint XML Presentation. No extrae las partes individuales de Office Open XML almacenadas dentro de un paquete PPTX. Si necesita las partes exactas del paquete PPTX, como `ppt/presentation.xml` o los archivos XML de diapositivas individuales, inspeccione el propio paquete PPTX.

{{% /alert %}}

## **Convertir una presentación a un archivo XML**

Cargue una presentación origen con la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) y, a continuación, pase la ruta de salida y `SaveFormat::Xml` a [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/). El origen puede ser cualquier formato de presentación compatible para cargar, como PPT, PPTX u ODP.

El siguiente ejemplo convierte una presentación PPTX a un archivo XML:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$outputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.xml";
$presentation = new Presentation($inputPath);
try {
    $presentation->save($outputPath, SaveFormat::Xml);
} finally {
    $presentation->dispose();
}
```

## **Escribir la salida XML a un flujo**

Utilice la sobrecarga de flujo de [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) cuando el XML deba permanecer en memoria o pasar a otro componente, como un servicio web, proveedor de almacenamiento o canal de procesamiento XML. El siguiente ejemplo escribe el resultado a un [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) y obtiene el XML generado como un arreglo de bytes:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputPath = __DIR__ . DIRECTORY_SEPARATOR . "presentation.pptx";
$presentation = new Presentation($inputPath);
try {
    $xmlStream = new Java("java.io.ByteArrayOutputStream");
    try {
        $presentation->save($xmlStream, SaveFormat::Xml);
        $xmlBytes = $xmlStream->toByteArray();

        // Pase $xmlBytes al siguiente componente en el flujo de trabajo.
    } finally {
        $xmlStream->close();
    }
} finally {
    $presentation->dispose();
}
```

Un `ByteArrayOutputStream` almacena todos los datos generados en memoria, por lo que no se requiere restablecer la posición antes de llamar a `toByteArray`.

## **Comparar XML con formatos de presentación y exportación**

Elija el formato de salida según cómo se utilizará el resultado:

| Formato | Salida | Uso típico |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Una PowerPoint XML Presentation | Inspección de la estructura, solución de problemas, comparación de salida generada e integración basada en XML |
| PPT (`.ppt`) | Un archivo de presentación binario legado | Compatibilidad con flujos de trabajo de PowerPoint antiguos |
| PPTX (`.pptx`) | Un paquete Office Open XML que contiene múltiples partes | Edición habitual de PowerPoint e intercambio de presentaciones |
| PDF o TIFF | Páginas de diseño fijo o una imagen multipágina | Visualización, impresión y archivado |
| PNG, JPEG o SVG | Una representación renderizada de una diapositiva individual | Miniaturas, vistas previas y recursos de imagen |
| HTML o HTML5 | Salida de presentación orientada a la web | Visualización en navegadores y publicación web |

A diferencia de PPT y PPTX, la salida XML está destinada principalmente a la inspección y a flujos de trabajo orientados a datos. A diferencia de PDF, TIFF, HTML y los formatos de imagen de diapositivas, representa datos de la presentación en lugar de renderizar diapositivas como páginas o recursos visuales. La tabla de [formatos de archivo compatibles](/slides/es/php-java/supported-file-formats/) enumera PowerPoint XML Presentation como un formato solo de guardado, por lo que no lo utilice cuando un flujo de trabajo necesite cargar el archivo exportado nuevamente en Aspose.Slides para continuar editándolo.

## **Preguntas frecuentes**

**¿`SaveFormat::Xml` es lo mismo que guardar un archivo PPTX?**

No. PPTX es un paquete que contiene múltiples partes de Office Open XML, mientras que `SaveFormat::Xml` crea un archivo PowerPoint XML Presentation.

**¿Puedo guardar la salida XML sin crear un archivo en disco?**

Sí. Pase un flujo escribible a [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/). Por ejemplo, use un [ByteArrayOutputStream](https://docs.oracle.com/javase/8/docs/api/java/io/ByteArrayOutputStream.html) para procesamiento en memoria.

**¿Aspose.Slides puede volver a cargar el archivo XML exportado?**

No. PowerPoint XML Presentation está soportado actualmente solo para guardado, no para carga. Use PPTX u otro formato de presentación compatible cuando se requiera edición bidireccional.

**¿La conversión a XML genera cada diapositiva como una página o imagen?**

No. La conversión a XML escribe datos estructurados de la presentación. Use PDF o TIFF para salida orientada a páginas, o PNG, JPEG y SVG para imágenes de diapositivas individuales.