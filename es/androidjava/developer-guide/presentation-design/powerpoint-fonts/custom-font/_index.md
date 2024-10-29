---
title: Fuente Personalizada de PowerPoint en Java
linktitle: Fuente Personalizada
type: docs
weight: 20
url: /es/androidjava/custom-font/
keywords: "Fuentes, fuentes personalizadas, presentación de PowerPoint, Java, Aspose.Slides para Android a través de Java"
description: "Fuentes personalizadas de PowerPoint en Java"
---

{{% alert color="primary" %}} 

Aspose Slides permite cargar estas fuentes utilizando el método [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Fuentes TrueType (.ttf) y Colección TrueType (.ttc). Ver [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Ver [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar Fuentes Personalizadas**

Aspose.Slides permite cargar fuentes que se renderizan en presentaciones sin necesidad de instalar esas fuentes. Las fuentes se cargan desde un directorio personalizado. 

1. Crea una instancia de la clase [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) y llama al método [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Carga la presentación que se renderizará.
3. [Limpia la caché](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) en la clase [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader).

Este código en Java demuestra el proceso de carga de fuentes:

```java
// Carpetas para buscar fuentes
String[] folders = new String[] { externalFontsDir };

// Carga las fuentes del directorio de fuentes personalizadas
FontsLoader.loadExternalFonts(folders);

// Realiza algún trabajo y realiza la renderización de la presentación/diapositiva
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // Limpia la caché de fuentes
    FontsLoader.clearCache();
}
```

## **Obtener Carpeta de Fuentes Personalizadas**
Aspose.Slides proporciona el método [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) para permitirte encontrar carpetas de fuentes. Este método devuelve carpetas añadidas a través del método `LoadExternalFonts` y carpetas de fuentes del sistema.

Este código en Java te muestra cómo usar [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Esta línea muestra las carpetas donde se buscan los archivos de fuentes.
// Esas son carpetas añadidas a través del método LoadExternalFonts y carpetas de fuentes del sistema.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Especificar Fuentes Personalizadas Utilizadas con la Presentación**
Aspose.Slides proporciona la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) para permitirte especificar fuentes externas que se utilizarán con la presentación.

Este código en Java te muestra cómo usar la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Trabaja con la presentación
    // CustomFont1, CustomFont2 y fuentes de las carpetas assets\fonts & global\fonts y sus subcarpetas están disponibles para la presentación
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestionar Fuentes Externamente**

Aspose.Slides proporciona el método [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) para permitirte cargar fuentes externas desde datos binarios.

Este código en Java demuestra el proceso de carga de fuentes desde un arreglo de bytes:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // fuente externa cargada durante la vida útil de la presentación
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```