---
title: Incrustar fuentes en presentaciones usando PHP
linktitle: Fuentes incrustadas
type: docs
weight: 40
url: /es/php-java/embedded-font/
keywords:
- añadir fuente
- incrustar fuente
- incrustación de fuentes
- obtener fuente incrustada
- añadir fuente incrustada
- eliminar fuente incrustada
- comprimir fuente incrustada
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Administre fuentes incrustadas en PowerPoint con Aspose.Slides para PHP a través de Java. Añada, recupere, elimine y comprima fuentes para preservar la apariencia del texto y reducir el tamaño del archivo."
---
## **Introducción**

Incrustar fuentes almacena los datos de la fuente dentro de una presentación de PowerPoint. Cuando un visor admite fuentes incrustadas, puede mostrar el texto usando esas fuentes aun si no están instaladas en el sistema de destino. Esto ayuda a conservar los saltos de línea, el espaciado del texto y el diseño de la diapositiva.

Aspose.Slides for PHP via Java le permite recuperar, añadir y eliminar fuentes incrustadas a través de la clase [FontsManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/) devuelta por [Presentation::getFontsManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getFontsManager). También puede reducir el tamaño de los datos de la fuente incrustada eliminando los caracteres que la presentación no utiliza.

Los ejemplos a continuación funcionan con archivos PPTX. Antes de incrustar una fuente, asegúrese de que sus datos estén disponibles para Aspose.Slides y de que su licencia permita la incrustación.

## **Obtener y eliminar fuentes incrustadas**

Utilice [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) para enumerar las fuentes almacenadas en una presentación. Para eliminar una, pase una fuente de esa lista a [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) y luego guarde la presentación.

El siguiente ejemplo enumera las fuentes incrustadas en `EmbeddedFonts.pptx` y elimina Calibri si está presente:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Eliminar una fuente incrustada quita sus datos almacenados; no cambia la fuente asignada al texto. Si la fuente está instalada en el sistema de destino, el texto aún puede usarla. En caso contrario, la representación puede requerir [font substitution](/slides/es/php-java/font-substitution/), lo que puede afectar el diseño.

## **Inspeccionar datos de fuentes y permisos de incrustación**

Utilice la clase [FontsManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/) para inspeccionar las fuentes antes de incrustarlas. Llame a [FontsManager::getFonts](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/#getFonts) para obtener las fuentes usadas en la presentación. Para cada fuente, pase un objeto [FontData](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontdata/) y el valor requerido de [FontStyleType](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontstyletype/) a [FontsManager::getFontBytes](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/#getFontBytes). El método devuelve los datos binarios para ese estilo de fuente, o `null` cuando la fuente o el estilo solicitado no están disponibles. No pase un resultado `null` a [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), porque ese método requiere una matriz de bytes.

[EmbeddingLevel](https://reference.aspose.com/slides/es/php-java/aspose.slides/embeddinglevel/) es una enumeración de banderas que informa de las restricciones de incrustación almacenadas en la fuente:

- `Installable` permite la incrustación y la instalación permanente en otro sistema, sujeto a la licencia de la fuente.
- `Restricted` prohíbe la incrustación a menos que se obtenga permiso del propietario legal de la fuente cuando es la única bandera de permiso de uso.
- `PreviewPrint` permite el uso temporal para visualización e impresión; un documento que contenga la fuente debe ser de solo lectura.
- `Editable` permite el uso temporal y permite que el documento se edite y guarde.
- `NoSubsetting` es una restricción adicional que prohíbe incrustar solo un subconjunto de los glifos. Incruste todos los caracteres cuando esta bandera está presente.
- `BitmapOnly` es una restricción adicional que permite incrustar solo versiones bitmap, no datos de contorno. Si la fuente no tiene versiones bitmap, no puede ser incrustada.

Los primeros cuatro valores describen el permiso de uso, mientras que `NoSubsetting` y `BitmapOnly` pueden combinarse con ellos. Compruebe los modificadores mediante operaciones bit a bit. Debido a que `Installable` es cero, enmascare los bits de permiso de uso y compare el resultado con `Installable` en lugar de comprobarlo como una bandera. Las fuentes actuales deberían establecer como máximo un bit de permiso de uso. Para compatibilidad con fuentes más antiguas que establecen más de uno, el asistente a continuación selecciona el permiso menos restrictivo: `Editable`, luego `PreviewPrint`, luego `Restricted`.

El siguiente ejemplo audita los datos regular, negrita, cursiva y negrita‑cursiva disponibles para cada fuente devuelta por `FontsManager::getFonts`. Omite estilos no disponibles, fuentes restringidas, fuentes solo‑bitmap, fuentes limitadas a vista previa e impresión porque la salida sigue siendo editable, y fuentes que ya están incrustadas. Si algún estilo disponible tiene `NoSubsetting`, incrusta todos los caracteres para esa familia de fuentes.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Esta inspección informa de las restricciones codificadas en cada archivo de fuente. No concede una licencia, no prueba que haya obtenido la fuente legalmente, ni sustituye la comprobación del acuerdo de licencia de la fuente antes de distribuir una copia incrustada.

## **Agregar fuentes incrustadas**

Utilice [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) para incrustar una fuente. Sus sobrecargas aceptan ya sea un objeto [FontData](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontdata/) o una matriz de bytes que contiene los datos de la fuente. La enumeración [EmbedFontCharacters](https://reference.aspose.com/slides/es/php-java/aspose.slides/embedfontcharacters/) controla qué caracteres se incluyen:

- [All](https://reference.aspose.com/slides/es/php-java/aspose.slides/embedfontcharacters/) incrusta todos los caracteres de la fuente. Use esta opción cuando los destinatarios necesiten editar la presentación e introducir texto nuevo.
- [OnlyUsed](https://reference.aspose.com/slides/es/php-java/aspose.slides/embedfontcharacters/) incrusta solo los caracteres usados en la presentación para reducir el tamaño del archivo. Elija esta opción para una presentación final que está destinada principalmente a la visualización.

El siguiente ejemplo usa [FontsManager::getFonts](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/#getFonts) para obtener las fuentes usadas en `Fonts.pptx` y incrusta las que no estén ya incrustadas. Las fuentes a agregar deben estar disponibles en la máquina que ejecuta el código. Las fuentes ya incrustadas conservan sus conjuntos de caracteres actuales.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Comprimir fuentes incrustadas**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/es/php-java/aspose.slides/compress/#compressEmbeddedFonts) reduce los datos de fuentes incrustadas eliminando los caracteres no usados. Actúa sobre fuentes que ya están incrustadas, por lo que la reducción de tamaño depende de cuántos datos de fuente no utilizados contenga la presentación.

El siguiente ejemplo comprime las fuentes en `EmbeddedFonts.pptx` y guarda el resultado como un archivo independiente:

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Conserve el archivo original si los destinatarios pueden necesitar añadir texto más adelante. Los caracteres eliminados durante la compresión ya no están disponibles en la fuente incrustada, incluso si originalmente incrustó todos los caracteres.

## **FAQ**

**¿Cómo puedo comprobar si una fuente incrustada seguirá siendo sustituida durante la representación?**

Llame a [FontsManager::getSubstitutions](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/#getSubstitutions) en el entorno donde renderiza la presentación para ver qué fuentes reemplazará Aspose.Slides. También revise la configuración de [font substitution](/slides/es/php-java/font-substitution/) y las reglas de [font fallback](/slides/es/php-java/fallback-font/). El fallback gestiona los caracteres faltantes, por lo que incrustar una fuente no resuelve los caracteres que la propia fuente no contiene.

**¿Debo incrustar fuentes comunes como Arial y Calibri?**

Base la decisión en el entorno de destino. Si las fuentes necesarias están disponibles en cada máquina que abre o renderiza la presentación, incrustarlas puede añadir un tamaño de archivo innecesario. Si los destinatarios o servidores pueden carecer de esas fuentes, incrustarlas puede ayudar a preservar la apariencia prevista, siempre que sus licencias lo permitan.