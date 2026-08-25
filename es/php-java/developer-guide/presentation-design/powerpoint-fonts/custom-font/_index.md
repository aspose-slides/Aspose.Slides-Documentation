---
title: "Personalizar fuentes de PowerPoint en PHP"
linktitle: "Fuente personalizada"
type: docs
weight: 20
url: /es/php-java/custom-font/
keywords:
- fuente
- fuente personalizada
- fuente externa
- cargar fuente
- gestionar fuentes
- carpeta de fuentes
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Personaliza fuentes en diapositivas de PowerPoint con Aspose.Slides para PHP a través de Java para que tus presentaciones sean nítidas y coherentes en cualquier dispositivo."
---
## **Visión general**

Aspose.Slides le permite utilizar fuentes personalizadas en presentaciones sin instalarlas en el sistema operativo. Puede cargar fuentes desde carpetas personalizadas, proporcionar fuentes para una presentación específica a través de fuentes a nivel de documento, o cargar fuentes externas directamente desde datos binarios.

Las fuentes cargadas se utilizan cuando una presentación se renderiza o exporta, por ejemplo a PDF, imágenes y otros formatos compatibles. Esto ayuda a mantener la salida de la presentación coherente en diferentes entornos. El artículo también explica cómo inspeccionar las carpetas de fuentes usadas por Aspose.Slides y cómo borrar la caché de fuentes después de trabajar con fuentes externas.

Registrar fuentes personalizadas para el renderizado es independiente de incrustar fuentes en un archivo PPTX. Si una fuente debe almacenarse dentro de la propia presentación, utilice explícitamente las funciones de incrustación de fuentes.

Un tema de presentación puede hacer referencia a diferentes familias de fuentes para sistemas de escritura individuales. Estas asignaciones almacenan nombres de fuentes pero no instalan ni cargan los archivos de fuentes. Consulte [Script-Specific Theme Fonts](/slides/es/php-java/script-specific-font-mappings/) para gestionar las asignaciones y utilice las opciones de carga a continuación para que las fuentes referenciadas estén disponibles para un renderizado coherente.

{{% alert color="info" title="Nota" %}}
Aspose Slides le permite cargar estas fuentes mediante el método [loadExternalFonts](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides le permite cargar fuentes utilizadas en una presentación sin instalarlas en el sistema. Esto afecta la salida de exportación —como PDF, imágenes y otros formatos compatibles— de modo que los documentos resultantes se vean coherentes en distintos entornos. Las fuentes se cargan desde directorios personalizados.

1. Especifique una o más carpetas que contengan los archivos de fuentes.
2. Llame al método estático [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) para cargar fuentes desde esas carpetas.
3. Cargue y renderice/exporte la presentación.
4. Llame a [FontsLoader::clearCache](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsloader/#clearCache--) para borrar la caché de fuentes.

```php
// Definir carpetas que contienen archivos de fuentes personalizadas.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Cargar fuentes personalizadas desde las carpetas especificadas.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Renderizar/exportar la presentación (p.ej., a PDF, imágenes u otros formatos) usando las fuentes cargadas.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Borrar la caché de fuentes después de que el trabajo haya finalizado.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Nota" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) agrega carpetas adicionales a las rutas de búsqueda de fuentes, pero no modifica el orden de inicialización de fuentes.
Las fuentes se inicializan en este orden:

1. La ruta de fuentes predeterminada del sistema operativo.
1. Las rutas cargadas a través de [FontsLoader](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Obtener carpetas de fuentes personalizadas**
Aspose.Slides ofrece el método [getFontFolders](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsloader/#getFontFolders--) para permitirle encontrar carpetas de fuentes. Este método devuelve las carpetas añadidas mediante el método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código PHP le muestra cómo usar [getFontFolders](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# Esta línea muestra las carpetas donde se buscan los archivos de fuentes.
# Esas son carpetas añadidas mediante el método LoadExternalFonts y carpetas de fuentes del sistema.
$fontFolders = FontsLoader::getFontFolders();
```

## **Especificar fuentes personalizadas usadas con una presentación**
Aspose.Slides ofrece el método [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) para permitirle especificar fuentes externas que se utilizarán con la presentación.

Este código PHP le muestra cómo usar el método [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/es/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # Trabajar con la presentación
    # CustomFont1, CustomFont2 y fuentes de las carpetas assets\fonts y global\fonts y sus subcarpetas están disponibles para la presentación
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Gestionar fuentes externamente**
Aspose.Slides ofrece el método [loadExternalFont](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) para permitirle cargar fuentes externas a partir de datos binarios.

Este código PHP demuestra el proceso de carga de fuentes a partir de un arreglo de bytes:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # fuente externa cargada durante la vida de la presentación
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **Preguntas frecuentes**

### ¿Afectan las fuentes personalizadas la exportación a todos los formatos (PDF, PNG, SVG, HTML)?

Sí. Las fuentes conectadas son usadas por el motor de renderizado en todos los formatos de exportación.

### ¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?

No. Registrar una fuente para el renderizado no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente vaya dentro del archivo de la presentación, debe usar explícitamente las [funciones de incrustación](/slides/es/php-java/embedded-font/).

### ¿Puedo controlar el comportamiento de reserva cuando una fuente personalizada carece de ciertos glifos?

Sí. Configure la [sustitución de fuentes](/slides/es/php-java/font-substitution/), las [reglas de reemplazo](/slides/es/php-java/font-replacement/) y los [conjuntos de reserva](/slides/es/php-java/fallback-font/) para definir exactamente qué fuente se utiliza cuando el glifo solicitado falta.

### ¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde arreglos de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

### ¿Qué pasa con la licencia: puedo incrustar cualquier fuente personalizada sin restricciones?

Usted es responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.