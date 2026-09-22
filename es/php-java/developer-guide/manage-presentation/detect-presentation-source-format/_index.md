---
title: Determinar el formato original de la presentación en PHP
linktitle: Formato de origen
type: docs
weight: 35
url: /es/php-java/detect-presentation-source-format/
keywords:
- formato de origen
- detectar formato de presentación
- PowerPoint
- OpenDocument
- presentación
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Lea el formato original de una presentación cargada en PHP con Aspose.Slides para PHP mediante Java, compare las API de detección y gestione archivos, flujos y formatos heredados."
---
## **Visión general**

Después de cargar una presentación, llame al método [Presentation::getSourceFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getSourceFormat) para determinar su formato original. Úselo cuando el procesamiento posterior dependa del formato desde el que se cargó la instancia actual.

El formato de origen es distinto del [SaveFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/) seleccionado para un archivo de salida. Guardar en otro formato no modifica el formato de origen de la instancia existente.

## **Leer el Formato de Origen de un Archivo**

Este ejemplo necesita un archivo `sample.pptx` existente. Carga el archivo y selecciona una política de procesamiento de la aplicación usando [Presentation::getSourceFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getSourceFormat), en lugar del nombre de archivo. Cambie la ruta de entrada para probar otros formatos. El ejemplo muestra la política seleccionada; reemplace los mensajes con la lógica de su aplicación.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
        case SourceFormat::Pps:
        case SourceFormat::Pot:
            echo "Use the legacy PowerPoint processing policy." . PHP_EOL;
            break;
        case SourceFormat::Pptx:
            echo "Use the standard PPTX processing policy." . PHP_EOL;
            break;
        default:
            echo "Use the general policy for source format " . java_values($presentation->getSourceFormat()) . "." . PHP_EOL;
            break;
    }
} finally {
    $presentation->dispose();
}
```

## **Reconocer los Valores Admitidos**

La clase [SourceFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/sourceformat/) define constantes enteras que distinguen los siguientes formatos de presentación. Las extensiones a continuación son extensiones convencionales, no una reconstrucción del nombre de archivo original.

| Valor de SourceFormat | Extensión | Formato |
| --- | --- | --- |
| `Ppt` | `.ppt` | presentación PowerPoint 97–2003 |
| `Pptx` | `.pptx` | presentación Office Open XML |
| `Pptm` | `.pptm` | presentación Office Open XML con macros |
| `Pps` | `.pps` | presentación de diapositivas PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | presentación de diapositivas Office Open XML |
| `Ppsm` | `.ppsm` | presentación de diapositivas Office Open XML con macros |
| `Pot` | `.pot` | plantilla PowerPoint 97–2003 |
| `Potx` | `.potx` | plantilla Office Open XML |
| `Potm` | `.potm` | plantilla Office Open XML con macros |
| `Odp` | `.odp` | presentación OpenDocument |
| `Otp` | `.otp` | plantilla de presentación OpenDocument |
| `Fodp` | `.fodp` | presentación ODF XML plano |
| `Xml` | `.xml` | presentación PowerPoint XML |

## **Leer el Formato de Origen de un Flujo**

Este ejemplo necesita un archivo `sample.pps` existente. Leer sus bytes en un flujo de memoria modela una entrada recibida sin nombre de archivo, como un valor de base de datos o una matriz de bytes cargada. El constructor de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) recibe solo el flujo.

```php
use aspose\slides\Presentation;

$inputFile = new Java("java.io.File", "sample.pps");
$bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
$stream = new Java("java.io.ByteArrayInputStream", $bytes);
try {
    $presentation = new Presentation($stream);
    try {
        echo "Source format: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
    } finally {
        $presentation->dispose();
    }
} finally {
    $stream->close();
}
```

PPT, PPS y POT utilizan el mismo formato binario subyacente. Al cargar mediante ruta de archivo, la extensión puede ayudar a distinguir una presentación de diapositivas o una plantilla. Sin un nombre de archivo, el contenido heredado de PPS y POT puede informarse como `SourceFormat::Ppt`; el ejemplo de PPS anterior muestra el valor entero de `SourceFormat::Ppt`.

Si su aplicación debe preservar la distinción, conserve el nombre de archivo original o los metadatos del subtipo por separado. Una extensión es una pista útil para estos subtipos heredados, pero no debería ser la única base para identificar contenido de presentación arbitrario.

## **Comparar la Detección Antes y Después de Cargar**

Utilice [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationfactory/#getPresentationInfo) y [PresentationInfo::getLoadFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#getLoadFormat) cuando necesite inspeccionar un archivo antes de cargar su modelo de objeto de presentación completo. Utilice [Presentation::getSourceFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getSourceFormat) cuando la instancia ya exista.

Este ejemplo necesita `sample.pptx` y muestra los valores enteros de `LoadFormat::Pptx` y `SourceFormat::Pptx`, respectivamente. En producción, elija la API adecuada a la fase de procesamiento; una presentación ya cargada no necesita una segunda inspección solo para obtener su formato de origen.

```php
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$path = "sample.pptx";
$information = PresentationFactory::getInstance()->getPresentationInfo($path);
echo "Before loading: " . java_values($information->getLoadFormat()) . PHP_EOL;

$presentation = new Presentation($path);
try {
    echo "After loading: " . java_values($presentation->getSourceFormat()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Los resultados usan constantes de diferentes clases: [LoadFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadformat/) y [SourceFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/sourceformat/). No compare sus valores numéricos ni asuma que cada formato tiene resultados de detección idénticos. PowerPoint XML puede informarse como `LoadFormat::Unknown` antes de cargar y como `SourceFormat::Xml` después de cargar.

## **Mantener Separados los Formatos de Origen y Salida**

Este ejemplo necesita `sample.pptx` y escribe `converted.odp`. Muestra el valor entero de `SourceFormat::Pptx` tanto antes como después de guardar la instancia original. Solo la nueva instancia cargada desde la salida ODP informa `Odp`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    echo "Before saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $presentation->save("converted.odp", SaveFormat::Odp);
    echo "After saving: " . java_values($presentation->getSourceFormat()) . PHP_EOL;

    $reopened = new Presentation("converted.odp");
    try {
        echo "Reopened output: " . java_values($reopened->getSourceFormat()) . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Una presentación creada desde cero con `new Presentation()` informa `SourceFormat::Pptx`. No tiene archivo de entrada: este es el valor predeterminado para una instancia recién creada, no evidencia de que se haya cargado un archivo PPTX. Controle por separado si su aplicación creó o cargó la instancia si esa distinción es importante.

## **Mapear un Formato de Origen a una Extensión**

El siguiente ejemplo necesita `sample.pptx`. Mapea cada valor de [SourceFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/sourceformat/) actualmente admitido a una extensión convencional, sin analizar el nombre de archivo de entrada. El valor de respaldo evita asignar silenciosamente una extensión a un valor no reconocido.

```php
use aspose\slides\Presentation;
use aspose\slides\SourceFormat;

$presentation = new Presentation("sample.pptx");
try {
    $extension = null;
    switch (java_values($presentation->getSourceFormat())) {
        case SourceFormat::Ppt:
            $extension = ".ppt";
            break;
        case SourceFormat::Pptx:
            $extension = ".pptx";
            break;
        case SourceFormat::Pptm:
            $extension = ".pptm";
            break;
        case SourceFormat::Pps:
            $extension = ".pps";
            break;
        case SourceFormat::Ppsx:
            $extension = ".ppsx";
            break;
        case SourceFormat::Ppsm:
            $extension = ".ppsm";
            break;
        case SourceFormat::Pot:
            $extension = ".pot";
            break;
        case SourceFormat::Potx:
            $extension = ".potx";
            break;
        case SourceFormat::Potm:
            $extension = ".potm";
            break;
        case SourceFormat::Odp:
            $extension = ".odp";
            break;
        case SourceFormat::Otp:
            $extension = ".otp";
            break;
        case SourceFormat::Fodp:
            $extension = ".fodp";
            break;
        case SourceFormat::Xml:
            $extension = ".xml";
            break;
        default:
            $extension = null;
            break;
    }

    echo ($extension !== null ? $extension : "No extension mapping is available.") . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Este mapeo no convierte un archivo ni recupera un subtipo heredado PPS/POT perdido durante la carga del flujo. Para guardar realmente, seleccione explícitamente un [SaveFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/saveformat/) o utilice la conversión mostrada en [Save Presentations in Their Original Format](/slides/es/php-java/save-presentation/#save-presentations-in-their-original-format).

## **Verificar Formatos Guardando y Reabriendo**

Este ejemplo autocontenido crea una presentación y escribe tres archivos en el directorio de trabajo, sobrescribiendo archivos con los mismos nombres. Reabre cada salida tanto por ruta como a través de un flujo de memoria. Para PPTX y ODP, ambas rutas informan el formato guardado. Para PPS, cargar por ruta informa `Pps`, mientras que cargar los mismos bytes sin nombre de archivo informa `Ppt`.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $formats = [SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps];
    $extensions = ["pptx", "odp", "pps"];

    foreach ($formats as $index => $format) {
        $path = "roundtrip." . $extensions[$index];
        $presentation->save($path, $format);

        $fromFile = new Presentation($path);
        try {
            $inputFile = new Java("java.io.File", $path);
            $bytes = java("java.nio.file.Files")->readAllBytes($inputFile->toPath());
            $stream = new Java("java.io.ByteArrayInputStream", $bytes);
            try {
                $fromStream = new Presentation($stream);
                try {
                    echo $extensions[$index] . ": file=" . java_values($fromFile->getSourceFormat()) . ", stream=" . java_values($fromStream->getSourceFormat()) . PHP_EOL;
                } finally {
                    $fromStream->dispose();
                }
            } finally {
                $stream->close();
            }
        } finally {
            $fromFile->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

La tabla siguiente resume la identificación del formato de origen para presentaciones con extensiones coincidentes. Los nombres denotan constantes; los ejemplos en PHP muestran sus valores enteros:

| Formato guardado | SourceFormat desde una ruta de archivo | SourceFormat desde un flujo sin nombre |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectivamente | Igual que la ruta de archivo |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectivamente | Igual que la ruta de archivo |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectivamente | Igual que la ruta de archivo |
| ODP, OTP | `Odp`, `Otp` respectivamente | Igual que la ruta de archivo |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

El contenido PPS/POT se identifica como `Ppt` para flujos sin nombre. La tabla describe la identificación de formatos, no la preservación de todas las características de la presentación durante la conversión.

## **Preguntas frecuentes**

**¿Guardar en ODP cambia el formato de origen de una presentación cargada desde PPTX?**

No. La instancia existente sigue informando `Pptx`. Una instancia cargada desde el archivo ODP guardado informa `Odp`.

**¿Puede un flujo siempre distinguir una presentación heredada, una presentación de diapositivas y una plantilla?**

No. PPT, PPS y POT comparten el formato binario. Conserve el nombre de archivo o los metadatos del subtipo por separado cuando sea necesario distinguirlos.

**¿Qué API debo usar si la presentación ya está cargada?**

Lea [Presentation::getSourceFormat](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getSourceFormat). Utilice [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationfactory/#getPresentationInfo) para inspección antes de cargar.