---
title: Convertir PPT a PPTX en PHP
linktitle: PPT a PPTX
type: docs
weight: 20
url: /es/php-java/convert-ppt-to-pptx/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- PPT a PPTX
- guardar PPT como PPTX
- exportar PPT a PPTX
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Convertir archivos PPT heredados a PPTX en PHP con Aspose.Slides. Incluye ejemplos en PHP para conversión de un solo archivo y por lotes, manejo de errores y notas de fidelidad."
---
## **Descripción general**

PPT es el formato binario heredado de PowerPoint, mientras que PPTX es el formato Open XML más reciente. Aspose.Slides for PHP via Java puede cargar un archivo PPT y guardarlo como PPTX sin Microsoft PowerPoint. Este artículo muestra cómo convertir un archivo o un directorio de archivos y explica qué verificar después de la conversión.

## **Convertir un archivo PPT a PPTX**

Cargue el archivo de origen con la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/), luego llame a [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save) con [SaveFormat::Pptx](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/#Pptx). El bloque `finally` libera la presentación y sus recursos.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

// Cargar la presentación PPT heredada.
$presentation = new Presentation("presentation.ppt");
try {
    // Guardar la presentación en formato PPTX.
    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La extensión del archivo no selecciona el formato de salida por sí sola; el argumento [SaveFormat::Pptx](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/#Pptx) lo hace. Mantenga diferentes las rutas de entrada y salida si necesita conservar el archivo PPT original.

## **Convertir varios archivos PPT**

El siguiente ejemplo convierte cada archivo `.ppt` en un directorio. Cada archivo se procesa de forma independiente, por lo que una conversión fallida no detiene el resto del lote.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$inputDirectory = "input";
$outputDirectory = "output";
if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Cannot create the output directory: " . $outputDirectory);
}

$inputFiles = [];
foreach (new DirectoryIterator($inputDirectory) as $fileInfo) {
    if ($fileInfo->isFile() && strtolower($fileInfo->getExtension()) === "ppt") {
        $inputFiles[] = $fileInfo->getPathname();
    }
}

foreach ($inputFiles as $inputPath) {
    $outputFileName = pathinfo($inputPath, PATHINFO_FILENAME) . ".pptx";
    $outputPath = $outputDirectory . DIRECTORY_SEPARATOR . $outputFileName;
    $presentation = null;

    try {
        $presentation = new Presentation($inputPath);
        $presentation->save($outputPath, SaveFormat::Pptx);
        echo "Converted: " . $inputPath . PHP_EOL;
    } catch (Throwable $exception) {
        fwrite(STDERR, "Failed: " . $inputPath . " (" . $exception->getMessage() . ")" . PHP_EOL);
    } finally {
        if ($presentation !== null) {
            $presentation->dispose();
        }
    }
}
```

Para cargas de trabajo de producción, registre la excepción completa, decida si se puede sobrescribir un archivo de salida existente y escriba los nombres de los archivos que fallaron en una cola de reintento o revisión. Los archivos corruptos, los archivos protegidos con contraseña abiertos sin la contraseña requerida, las rutas inaccesibles y el contenido no compatible pueden causar que una conversión falle. Consulte [Presentaciones protegidas con contraseña](/php-java/password-protected-presentation/) para cargar archivos cifrados.

## **Fidelidad y características heredadas**

La conversión normalmente conserva diapositivas, patrones, diseños, texto, formas, imágenes, tablas y gráficos. Sin embargo, PPT y PPTX no representan todas las características de la misma manera exacta. Una característica heredada que no tiene equivalente en PPTX, o que no es compatible con la biblioteca, puede normalizarse, omitirse o mostrarse de forma diferente.

Verifique el archivo convertido cuando contenga animaciones, transiciones, objetos OLE incrustados o vinculados, controles ActiveX, medios incrustados, tipografías poco comunes o macros VBA. Un archivo PPTX sencillo no es un formato con macros habilitadas, por lo que debe usar un flujo de trabajo adecuado con macros cuando VBA deba mantenerse disponible. También compruebe que las fuentes requeridas y los recursos externos estén presentes en el entorno donde se abrirá o renderizará la presentación convertida.

Para documentos importantes, vuelva a abrir el PPTX generado programáticamente e inspeccione el número de diapositivas clave y su contenido, luego compare su apariencia y comportamiento de la presentación en el visor previsto. No considere que una llamada exitosa a [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save) sea prueba de que cada característica heredada tenga una representación exacta en PPTX.

## **Cuándo usar PPTX**

Utilice PPTX cuando la presentación se editará en versiones actuales de PowerPoint, se intercambie con sistemas que trabajen con paquetes Open XML, o se almacene en un formato más fácil de inspeccionar y recuperar que el PPT binario heredado. Mantenga el PPT original como una copia de archivo o de reversión hasta que la presentación convertida haya superado sus controles de fidelidad.

Si necesita PDF, HTML, imágenes, XPS u otro tipo de salida, utilice la guía específica de formato en [Convertir presentaciones a varios formatos](/php-java/convert-presentation/) en lugar de asumir que todos los objetivos conservan las funciones editables de PowerPoint.

## **Convertidor en línea**

Para un archivo ocasional o una comparación rápida, puede usar el [convertidor en línea de PPT a PPTX](https://products.aspose.app/slides/es/conversion/ppt-to-pptx). Para conversiones repetibles, procesamiento por lotes o manejo de errores a nivel de aplicación, utilice la API de PHP.

## **Artículos relacionados**

- [PPT vs PPTX](/php-java/ppt-vs-pptx/)
- [Guardar presentaciones en PHP](/php-java/save-presentation/)
- [Formatos de archivo compatibles](/php-java/supported-file-formats/)
- [Abrir presentaciones en PHP](/php-java/open-presentation/)

## **Preguntas frecuentes**

**¿Puedo convertir PPT a PPTX sin Microsoft PowerPoint instalado?**

Sí. Aspose.Slides for PHP via Java carga y guarda archivos de presentación sin requerir Microsoft PowerPoint.

**¿La conversión de PPT a PPTX preservará todo el contenido exactamente?**

Preserva el contenido común de las presentaciones, pero no se garantiza una fidelidad exacta para cada característica heredada o no compatible. Revise el archivo generado cuando contenga macros, objetos OLE o ActiveX, medios, animaciones especializadas o tipografías poco comunes.

**¿Puedo convertir un archivo PPT protegido con contraseña?**

Sí, si proporciona la contraseña correcta al cargar el archivo. Falta una contraseña o una contraseña incorrecta provocan que la operación de carga falle.

**¿Debo eliminar el archivo PPT después de la conversión?**

Conserve el original hasta que haya verificado el PPTX en los visores y flujos de trabajo que le importen. Esto proporciona una copia de reversión si una característica heredada se convierte de forma diferente.