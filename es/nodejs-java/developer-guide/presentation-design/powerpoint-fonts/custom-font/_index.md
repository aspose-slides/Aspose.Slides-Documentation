---
title: Fuente personalizada de PowerPoint en JavaScript
linktitle: Fuente personalizada
type: docs
weight: 20
url: /es/nodejs-java/custom-font/
keywords: "Fuentes, fuentes personalizadas, presentación PowerPoint, Java, Aspose.Slides para Node.js via Java"
description: "Fuentes personalizadas de PowerPoint en JavaScript"
---

{{% alert color="primary" %}} 
Aspose Slides le permite cargar estas fuentes usando el método [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**
Aspose.Slides le permite cargar fuentes que se renderizan en presentaciones sin necesidad de instalarlas. Las fuentes se cargan desde un directorio personalizado. 

1. Cree una instancia de la clase [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/) y llame al método [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Cargue la presentación que se renderizará.
3. [Clear the cache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsLoader#clearCache--) en la clase [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsLoader).

Este código JavaScript demuestra el proceso de carga de fuentes:
```javascript
// Carpetas para buscar fuentes
var folders = java.newArray("java.lang.String", [externalFontsDir]);
// Carga las fuentes del directorio de fuentes personalizado
aspose.slides.FontsLoader.loadExternalFonts(folders);
// Realiza algún trabajo y renderiza la presentación/diapositiva
var pres = new aspose.slides.Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
    // Borra la caché de fuentes
    aspose.slides.FontsLoader.clearCache();
}
```


## **Get Custom Fonts Folder**
Aspose.Slides proporciona el método [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) para permitirle encontrar carpetas de fuentes. Este método devuelve las carpetas añadidas mediante el método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código JavaScript le muestra cómo usar [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):
```javascript
// Esta línea muestra las carpetas donde se buscan los archivos de fuentes.
// Son carpetas añadidas mediante el método LoadExternalFonts y carpetas de fuentes del sistema.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```


## **Specify Custom Fonts Used With Presentation**
Aspose.Slides proporciona la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) para permitirle especificar fuentes externas que se utilizarán con la presentación.

Este código JavaScript le muestra cómo usar la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):
```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Trabaje con la presentación
    // CustomFont1, CustomFont2 y las fuentes de las carpetas assets\fonts & global\fonts y sus subcarpetas están disponibles para la presentación
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Manage Fonts Externally**
Aspose.Slides proporciona el método [loadExternalFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) para permitirle cargar fuentes externas desde datos binarios.

Este código JavaScript demuestra el proceso de carga de fuentes a partir de un arreglo de bytes:
```javascript
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

**¿Las fuentes personalizadas afectan la exportación a todos los formatos (PDF, PNG, SVG, HTML)?**

Sí. Las fuentes conectadas son usadas por el renderizador en todos los formatos de exportación.

**¿Las fuentes personalizadas se incrustan automáticamente en el PPTX resultante?**

No. Registrar una fuente para renderizar no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente se incluya dentro del archivo de presentación, debe usar las funciones de [embedding features](/slides/es/nodejs-java/embedded-font/).

**¿Puedo controlar el comportamiento de reserva cuando una fuente personalizada carece de ciertos glifos?**

Sí. Configure la [font substitution](/slides/es/nodejs-java/font-substitution/), las [replacement rules](/slides/es/nodejs-java/font-replacement/) y los [fallback sets](/slides/es/nodejs-java/fallback-font/) para definir exactamente qué fuente se usa cuando el glifo solicitado falta.

**¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?**

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde arreglos de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

**¿Qué pasa con la licencia—puedo incrustar cualquier fuente personalizada sin restricciones?**

Usted es responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.