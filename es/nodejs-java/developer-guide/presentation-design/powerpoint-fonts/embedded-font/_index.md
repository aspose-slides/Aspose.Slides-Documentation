---
title: Incrustar fuentes en presentaciones en JavaScript
linktitle: Fuentes incrustadas
type: docs
weight: 40
url: /es/nodejs-java/embedded-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestiona fuentes incrustadas en PowerPoint con Aspose.Slides para Node.js a través de Java. Añade, recupera, elimina y comprime fuentes para preservar la apariencia del texto y reducir el tamaño del archivo."
---
## **Introducción**

Incrustar fuentes almacena los datos de la fuente dentro de una presentación de PowerPoint. Cuando un visor admite fuentes incrustadas, puede mostrar el texto usando esas fuentes aun si no están instaladas en el sistema de destino. Esto ayuda a preservar los saltos de línea, el espaciado del texto y el diseño de la diapositiva.

Aspose.Slides para Node.js a través de Java le permite obtener, añadir y eliminar fuentes incrustadas mediante la clase [FontsManager](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/) devuelta por [Presentation.getFontsManager](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/getfontsmanager/). También puede reducir el tamaño de los datos de la fuente incrustada eliminando los caracteres que la presentación no utiliza.

Los ejemplos a continuación funcionan con archivos PPTX. Antes de incrustar una fuente, asegúrese de que sus datos estén disponibles para Aspose.Slides y de que su licencia permita la incrustación.

## **Obtener y eliminar fuentes incrustadas**

Utilice [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) para listar las fuentes almacenadas en una presentación. Para eliminar una, pase una fuente de esa lista a [FontsManager.removeEmbeddedFont](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/removeembeddedfont/), y luego guarde la presentación.

El siguiente ejemplo enumera las fuentes incrustadas en `EmbeddedFonts.pptx` y elimina Calibri si está presente:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var embeddedFonts = fontsManager.getEmbeddedFonts();

    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log(embeddedFonts[i].getFontName());
    }

    var fontToRemove = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        if (String(embeddedFonts[i].getFontName()).toLowerCase() === "calibri") {
            fontToRemove = embeddedFonts[i];
            break;
        }
    }

    if (fontToRemove !== null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Eliminar una fuente incrustada suprime sus datos almacenados; no cambia la fuente asignada al texto. Si la fuente está instalada en el sistema de destino, el texto puede seguir utilizándola. De lo contrario, el renderizado puede requerir [font substitution](/slides/es/nodejs-java/font-substitution/), lo que puede afectar al diseño.

## **Inspeccionar datos de fuentes y permisos de incrustación**

Utilice la clase [FontsManager](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/) para inspeccionar las fuentes antes de incrustarlas. Llame a [FontsManager.getFonts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/getfonts/) para obtener las fuentes usadas en la presentación. Para cada fuente, pase un objeto [FontData](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontdata/) y el valor requerido de [FontStyleType](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontstyletype/) a [FontsManager.getFontBytes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/#getFontBytes). El método devuelve los datos binarios de ese estilo de fuente, o `null` cuando la fuente o el estilo solicitado no está disponible. No pase un resultado `null` a [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), porque ese método requiere un arreglo de bytes. En Node.js, convierta el arreglo de JavaScript devuelto a un arreglo de bytes de Java con `java.newArray` antes de pasarlo a `getFontEmbeddingLevel`.

[EmbeddingLevel](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/embeddinglevel/) informa las restricciones de incrustación almacenadas en la fuente como un conjunto de indicadores:

- `Installable` permite la incrustación y la instalación permanente en otro sistema, sujeto a la licencia de la fuente.
- `Restricted` prohíbe la incrustación a menos que se obtenga permiso del propietario legal de la fuente cuando es el único indicador de permiso de uso.
- `PreviewPrint` permite el uso temporal para visualización e impresión; un documento que contenga la fuente debe ser de solo lectura.
- `Editable` permite el uso temporal y permite que el documento se edite y guarde.
- `NoSubsetting` es una restricción adicional que prohíbe incrustar solo un subconjunto de los glifos. Incruste todos los caracteres cuando este indicador esté presente.
- `BitmapOnly` es una restricción adicional que permite incrustar solo versiones bitmap, no datos de contorno. Si la fuente no tiene versiones bitmap, no puede incrustarse.

Los cuatro primeros valores describen el permiso de uso, mientras que `NoSubsetting` y `BitmapOnly` pueden combinarse con ellos. Verifique los modificadores con operaciones bit a bit. Como `Installable` es cero, enmascare los bits de permiso de uso y compare el resultado con `Installable` en lugar de comprobarlo como un indicador. Las fuentes actuales deben establecer como máximo un bit de permiso de uso. Para compatibilidad con fuentes más antiguas que establecen más de uno, el asistente a continuación selecciona el permiso menos restrictivo: `Editable`, luego `PreviewPrint`, luego `Restricted`.

El siguiente ejemplo audita los datos regular, negrita, cursiva y negrita‑cursiva disponibles para cada fuente devuelta por `getFonts`. Omite estilos no disponibles, fuentes restringidas, fuentes solo bitmap, fuentes limitadas a vista previa e impresión porque la salida sigue siendo editable, y fuentes que ya están incrustadas. Si algún estilo disponible tiene `NoSubsetting`, incrusta todos los caracteres de esa familia de fuentes.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
var java = require("java");

function getUsagePermission(level) {
    var permissionMask = aspose.slides.EmbeddingLevel.Restricted | aspose.slides.EmbeddingLevel.PreviewPrint | aspose.slides.EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & aspose.slides.EmbeddingLevel.Editable) !== 0) {
        return aspose.slides.EmbeddingLevel.Editable;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.PreviewPrint) !== 0) {
        return aspose.slides.EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & aspose.slides.EmbeddingLevel.Restricted) !== 0) {
        return aspose.slides.EmbeddingLevel.Restricted;
    }

    return aspose.slides.EmbeddingLevel.Installable;
}

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    var embeddedFontNames = new Set();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    var fontsToEmbed = [];
    var embeddingRules = [];
    var fonts = fontsManager.getFonts();
    for (var i = 0; i < fonts.length; i++) {
        var font = fonts[i];
        var fontName = String(font.getFontName());
        if (embeddedFontNames.has(fontName.toLowerCase())) {
            console.log(fontName + ": already embedded.");
            continue;
        }

        var hasAvailableData = false;
        var allAvailableStylesCanBeEmbedded = true;
        var previewPrintOnly = false;
        var requiresFullFont = false;

        for (var j = 0; j < fontStyles.length; j++) {
            var fontStyle = fontStyles[j];
            var fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes === null) {
                console.log(fontName + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            var fontByteValues = Array.from(fontBytes);
            var javaFontBytes = java.newArray("byte", fontByteValues);
            var embeddingLevel = fontsManager.getFontEmbeddingLevel(javaFontBytes, fontName);
            var usagePermission = getUsagePermission(embeddingLevel);
            var noSubsetting = (embeddingLevel & aspose.slides.EmbeddingLevel.NoSubsetting) !== 0;
            var bitmapOnly = (embeddingLevel & aspose.slides.EmbeddingLevel.BitmapOnly) !== 0;

            requiresFullFont = requiresFullFont || noSubsetting;
            previewPrintOnly = previewPrintOnly || usagePermission === aspose.slides.EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded = allAvailableStylesCanBeEmbedded && usagePermission !== aspose.slides.EmbeddingLevel.Restricted && !bitmapOnly;

            console.log(fontName + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            console.log(fontName + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            console.log(fontName + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            console.log(fontName + ": skipped because this example produces an editable presentation.");
        } else {
            var rule = requiresFullFont ? aspose.slides.EmbedFontCharacters.All : aspose.slides.EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.push(font);
            embeddingRules.push(rule);
        }
    }

    for (var i = 0; i < fontsToEmbed.length; i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed[i], embeddingRules[i]);
    }

    presentation.save("WithAuditedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Esta inspección informa las restricciones codificadas en cada archivo de fuente. No otorga una licencia, no prueba que haya obtenido la fuente legalmente, ni sustituye la comprobación del acuerdo de licencia de la fuente antes de distribuir una copia incrustada.

## **Añadir fuentes incrustadas**

Utilice [FontsManager.addEmbeddedFont](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/addembeddedfont/) para incrustar una fuente. Sus sobrecargas aceptan ya sea un objeto [FontData](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontdata/) o un arreglo de bytes que contenga los datos de la fuente. [EmbedFontCharacters](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/embedfontcharacters/) controla qué caracteres se incluyen:

- `All` incrusta todos los caracteres de la fuente. Use esta opción cuando los destinatarios necesiten editar la presentación e introducir texto nuevo.
- `OnlyUsed` incrusta solo los caracteres utilizados en la presentación para reducir el tamaño del archivo. Elija esta opción para una presentación final que se destine principalmente a la visualización.

El siguiente ejemplo usa [FontsManager.getFonts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/getfonts/) para obtener las fuentes usadas en `Fonts.pptx` e incrusta aquellas que aún no están incrustadas. Las fuentes a añadir deben estar disponibles en la máquina que ejecuta el código. Las fuentes ya incrustadas conservan sus conjuntos de caracteres actuales.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("Fonts.pptx");
try {
    var fontsManager = presentation.getFontsManager();
    var allFonts = fontsManager.getFonts();
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    var embeddedFontNames = new Set();
    var fontStyles = [aspose.slides.FontStyleType.Regular, aspose.slides.FontStyleType.Bold, aspose.slides.FontStyleType.Italic, aspose.slides.FontStyleType.Bold | aspose.slides.FontStyleType.Italic];

    for (var i = 0; i < embeddedFonts.length; i++) {
        embeddedFontNames.add(String(embeddedFonts[i].getFontName()).toLowerCase());
    }

    for (var i = 0; i < allFonts.length; i++) {
        var font = allFonts[i];
        var fontName = String(font.getFontName()).toLowerCase();
        if (!embeddedFontNames.has(fontName)) {
            var hasAvailableData = false;
            for (var j = 0; j < fontStyles.length; j++) {
                if (fontsManager.getFontBytes(font, fontStyles[j]) !== null) {
                    hasAvailableData = true;
                    break;
                }
            }

            if (hasAvailableData) {
                fontsManager.addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
                embeddedFontNames.add(fontName);
            } else {
                console.log(font.getFontName() + ": skipped because its font data is unavailable.");
            }
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comprimir fuentes incrustadas**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/compress/compressembeddedfonts/) reduce los datos de fuentes incrustadas eliminando los caracteres no utilizados. Actúa sobre fuentes que ya están incrustadas, por lo que la reducción de tamaño depende de cuántos datos de fuente no utilizados contenga la presentación.

El siguiente ejemplo comprime las fuentes en `EmbeddedFonts.pptx` y guarda el resultado como un archivo separado:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Conserve el archivo original si los destinatarios pueden necesitar añadir texto más adelante. Los caracteres eliminados durante la compresión ya no estarán disponibles en la fuente incrustada, incluso si originalmente incrustó todos los caracteres.

## **FAQ**

**¿Cómo puedo comprobar si una fuente incrustada seguirá siendo sustituida durante el renderizado?**

Llame a [FontsManager.getSubstitutions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) en el entorno donde renderiza la presentación para ver qué fuentes reemplazará Aspose.Slides. También revise la configuración de [font substitution](/slides/es/nodejs-java/font-substitution/) y las reglas de [font fallback](/slides/es/nodejs-java/fallback-font/). El fallback gestiona los caracteres que faltan, por lo que incrustar una fuente no resuelve los caracteres que la propia fuente no contiene.

**¿Debo incrustar fuentes comunes como Arial y Calibri?**

Base su decisión en el entorno de destino. Si las fuentes requeridas están disponibles en cada máquina que abre o renderiza la presentación, incrustarlas puede añadir un tamaño de archivo innecesario. Si los destinatarios o servidores pueden carecer de esas fuentes, incrustarlas puede ayudar a preservar la apariencia prevista, siempre que sus licencias lo permitan.