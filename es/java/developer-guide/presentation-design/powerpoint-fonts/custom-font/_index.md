---
title: Personalizar fuentes de PowerPoint en Java
linktitle: Fuente personalizada
type: docs
weight: 20
url: /es/java/custom-font/
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
- Java
- Aspose.Slides
description: "Personaliza las fuentes en las diapositivas de PowerPoint con Aspose.Slides para Java para mantener tus presentaciones nítidas y coherentes en cualquier dispositivo."
---

{{% alert color="primary" %}} 

Aspose Slides le permite cargar estas fuentes mediante el método [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides le permite cargar fuentes que se renderizan en presentaciones sin necesidad de instalarlas. Las fuentes se cargan desde un directorio personalizado. 

1. Cree una instancia de la clase [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) y llame al método [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Cargue la presentación que se va a renderizar.
3. [Clear the cache](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) en la clase [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader).

Este código Java muestra el proceso de carga de fuentes:
```java
// Carpetas para buscar fuentes
String[] folders = new String[] { externalFontsDir };

// Carga las fuentes del directorio de fuentes personalizado
FontsLoader.loadExternalFonts(folders);

// Do Some work and perform presentation/slide rendering
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // Borra la caché de fuentes
    FontsLoader.clearCache();
}
```


## **Obtener carpetas de fuentes personalizadas**
Aspose.Slides proporciona el método [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) para permitirle encontrar carpetas de fuentes. Este método devuelve las carpetas añadidas mediante el método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código Java muestra cómo usar [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--):
```java
// Esta línea muestra las carpetas donde se buscan los archivos de fuentes.
// Estas son carpetas añadidas mediante el método LoadExternalFonts y carpetas de fuentes del sistema.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **Especificar fuentes personalizadas usadas en una presentación**
Aspose.Slides proporciona la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) para permitirle especificar fuentes externas que se usarán con la presentación. 

Este código Java muestra cómo usar la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Trabajar con la presentación
    // CustomFont1, CustomFont2, y fuentes de las carpetas assets\fonts & global\fonts y sus subcarpetas están disponibles para la presentación
} finally {
    if (pres != null) pres.dispose();
}
```


## **Administrar fuentes externamente**

Aspose.Slides proporciona el método [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) para permitirle cargar fuentes externas a partir de datos binarios.

Este código Java demuestra el proceso de carga de fuentes a partir de un arreglo de bytes:
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


## **FAQ**

**¿Las fuentes personalizadas afectan la exportación a todos los formatos (PDF, PNG, SVG, HTML)?**

Sí. Las fuentes conectadas son usadas por el motor de renderizado en todos los formatos de exportación.

**¿Las fuentes personalizadas se incrustan automáticamente en el PPTX resultante?**

No. Registrar una fuente para renderizar no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente forme parte del archivo de presentación, debe usar las [funcionalidades de incrustación](/slides/es/java/embedded-font/).

**¿Puedo controlar el comportamiento de sustitución cuando una fuente personalizada carece de ciertos glifos?**

Sí. Configure la [sustitución de fuentes](/slides/es/java/font-substitution/), las [reglas de reemplazo](/slides/es/java/font-replacement/) y los [conjuntos de sustitución](/slides/es/java/fallback-font/) para definir exactamente qué fuente se usa cuando falta el glifo solicitado.

**¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?**

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde arreglos de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

**¿Qué pasa con la licencia—puedo incrustar cualquier fuente personalizada sin restricciones?**

Usted es responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.