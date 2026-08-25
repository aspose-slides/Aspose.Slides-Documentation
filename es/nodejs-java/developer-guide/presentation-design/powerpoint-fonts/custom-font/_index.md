---
title: Personalizar fuentes de PowerPoint en JavaScript
linktitle: Fuente personalizada
type: docs
weight: 20
url: /es/nodejs-java/custom-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Personaliza las fuentes en diapositivas de PowerPoint con JavaScript y Aspose.Slides para Node.js mediante Java para mantener tus presentaciones nítidas y coherentes en cualquier dispositivo."
---
## **Visión general**

Aspose.Slides permite utilizar fuentes personalizadas en presentaciones sin instalarlas en el sistema operativo. Puede cargar fuentes desde carpetas personalizadas, proporcionar fuentes para una presentación específica mediante fuentes a nivel de documento, o cargar fuentes externas directamente a partir de datos binarios.

Las fuentes cargadas se utilizan cuando una presentación se renderiza o exporta, por ejemplo a PDF, imágenes y otros formatos compatibles. Esto ayuda a que la salida de la presentación sea coherente en diferentes entornos. El artículo también explica cómo inspeccionar las carpetas de fuentes usadas por Aspose.Slides y cómo borrar la caché de fuentes después de trabajar con fuentes externas.

El registro de fuentes personalizadas para el renderizado es independiente de la incorporación de fuentes en un archivo PPTX. Si una fuente debe almacenarse dentro de la propia presentación, utilice explícitamente las funciones de incrustación de fuentes.

Un tema de presentación puede referenciar distintas familias tipográficas para sistemas de escritura individuales. Estas asignaciones almacenan nombres de fuentes pero no instalan ni cargan los archivos de fuentes. Consulte [Fuentes de tema específicas de script](/slides/es/nodejs-java/script-specific-font-mappings/) para gestionar las asignaciones y utilice las opciones de carga a continuación para que las fuentes referenciadas estén disponibles para un renderizado coherente.

{{% alert color="info" title="Nota" %}}

Aspose Slides le permite cargar estas fuentes utilizando el método [loadExternalFonts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Ver [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Fuentes OpenType (.otf). Ver [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides permite cargar las fuentes usadas en una presentación sin instalarlas en el sistema. Esto afecta la salida de exportación —como PDF, imágenes y otros formatos compatibles— para que los documentos resultantes tengan un aspecto coherente en todos los entornos. Las fuentes se cargan desde directorios personalizados.

1. Especifique una o más carpetas que contengan los archivos de fuentes.
2. Llame al método estático [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) para cargar fuentes desde esas carpetas.
3. Cargue y renderice/exporte la presentación.
4. Llame a [FontsLoader.clearCache](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsloader/clearcache/) para borrar la caché de fuentes.

El siguiente ejemplo de código muestra el proceso de carga de fuentes:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Define las carpetas que contienen archivos de fuentes personalizados.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Load custom fonts from the specified folders.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Renderizar/exportar la presentación (p.ej., a PDF, imágenes u otros formatos) usando las fuentes cargadas.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Borrar la caché de fuentes después de que el trabajo haya finalizado.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Nota" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) añade carpetas adicionales a las rutas de búsqueda de fuentes, pero no cambia el orden de inicialización de las fuentes.  
Las fuentes se inicializan en este orden:

1. La ruta de fuentes predeterminada del sistema operativo.  
1. Las rutas cargadas a través de [FontsLoader](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtener carpetas de fuentes personalizadas**

Aspose.Slides proporciona el método [getFontFolders](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) para que pueda localizar carpetas de fuentes. Este método devuelve las carpetas añadidas mediante el método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código JavaScript muestra cómo usar [getFontFolders](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Esta línea muestra las carpetas donde se buscan los archivos de fuentes.
// Estas son las carpetas añadidas mediante el método LoadExternalFonts y las carpetas de fuentes del sistema.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Especificar fuentes personalizadas usadas con la presentación**

Aspose.Slides proporciona la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) para que pueda especificar fuentes externas que se usarán con la presentación.

Este código JavaScript muestra cómo usar la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Trabajar con la presentación
    // CustomFont1, CustomFont2 y fuentes de las carpetas assets\fonts & global\fonts y sus subcarpetas están disponibles para la presentación
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestionar fuentes externamente**

Aspose.Slides proporciona el método [loadExternalFont](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) para que pueda cargar fuentes externas a partir de datos binarios.

Este código JavaScript muestra el proceso de carga de fuentes a partir de un arreglo de bytes:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // fuente externa cargada durante la vida útil de la presentación
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

### ¿Las fuentes personalizadas afectan la exportación a todos los formatos (PDF, PNG, SVG, HTML)?

Sí. Las fuentes conectadas son usadas por el motor de renderizado en todos los formatos de exportación.

### ¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?

No. Registrar una fuente para el renderizado no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente esté dentro del archivo de presentación, debe usar las [funciones de incrustación](/slides/es/nodejs-java/embedded-font/).

### ¿Puedo controlar el comportamiento de sustitución cuando una fuente personalizada carece de algunos glifos?

Sí. Configure la [sustitución de fuentes](/slides/es/nodejs-java/font-substitution/), las [reglas de reemplazo](/slides/es/nodejs-java/font-replacement/) y los [conjuntos de fuentes de respaldo](/slides/es/nodejs-java/fallback-font/) para definir exactamente qué fuente se usa cuando falta el glifo solicitado.

### ¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde arreglos de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

### ¿Qué ocurre con la licencia? ¿Puedo incrustar cualquier fuente personalizada sin restricciones?

Usted es responsable del cumplimiento de la licencia de las fuentes. Los términos varían; algunas licencias prohíben la incorporación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.