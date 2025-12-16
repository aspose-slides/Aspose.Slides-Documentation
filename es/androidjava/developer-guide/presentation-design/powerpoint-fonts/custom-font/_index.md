---
title: Personalizar fuentes de PowerPoint en Android
linktitle: Fuente personalizada
type: docs
weight: 20
url: /es/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "Personaliza fuentes en diapositivas de PowerPoint con Aspose.Slides para Android mediante Java para mantener tus presentaciones nítidas y coherentes en cualquier dispositivo."
---

{{% alert color="primary" %}} 

Aspose Slides permite cargar estas fuentes usando el método [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) y TrueType Collection (.ttc). Ver [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf). Ver [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides permite cargar fuentes que se renderizan en presentaciones sin necesidad de instalarlas. Las fuentes se cargan desde un directorio personalizado. 

1. Crear una instancia de la clase [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) y llamar al método [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Cargar la presentación que se va a renderizar.
3. [Borrar la caché](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) en la clase [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader).

Este código Java demuestra el proceso de carga de fuentes:
```java
// Carpetas para buscar fuentes
String[] folders = new String[] { externalFontsDir };

// Carga las fuentes del directorio de fuentes personalizadas
FontsLoader.loadExternalFonts(folders);

// Realiza alguna tarea y renderiza la presentación/diapositiva
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
Aspose.Slides proporciona el método [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) para permitirle encontrar carpetas de fuentes. Este método devuelve carpetas añadidas a través del método `LoadExternalFonts` y carpetas de fuentes del sistema.

Este código Java le muestra cómo usar [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):
```java
// Esta línea muestra las carpetas donde se buscan los archivos de fuentes.
// Esas son carpetas agregadas mediante el método LoadExternalFonts y carpetas de fuentes del sistema.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **Especificar fuentes personalizadas usadas con una presentación**
Aspose.Slides proporciona la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) para permitirle especificar fuentes externas que se usarán con la presentación.

Este código Java le muestra cómo usar la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Trabajar con la presentación
    // CustomFont1, CustomFont2, y las fuentes de las carpetas assets\fonts & global\fonts y sus subcarpetas están disponibles para la presentación
} finally {
    if (pres != null) pres.dispose();
}
```


## **Gestionar fuentes externamente**

Aspose.Slides proporciona el método [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) para permitirle cargar fuentes externas a partir de datos binarios.

Este código Java demuestra el proceso de carga de fuentes a partir de un array de bytes:
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


## **Preguntas frecuentes**

**¿Afectan las fuentes personalizadas a la exportación a todos los formatos (PDF, PNG, SVG, HTML)?**

Sí. Las fuentes conectadas se utilizan por el renderizador en todos los formatos de exportación.

**¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?**

No. Registrar una fuente para renderizar no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente forme parte del archivo de la presentación, debe usar las [características de incrustación](/slides/es/androidjava/embedded-font/).

**¿Puedo controlar el comportamiento de sustitución cuando una fuente personalizada carece de ciertos glifos?**

Sí. Configure la [sustitución de fuentes](/slides/es/androidjava/font-substitution/), las [reglas de reemplazo](/slides/es/androidjava/font-replacement/), y los [conjuntos de sustitución](/slides/es/androidjava/fallback-font/) para definir exactamente qué fuente se usa cuando falta el glifo solicitado.

**¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?**

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde arrays de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

**¿Qué pasa con la licencia—puedo incrustar cualquier fuente personalizada sin restricciones?**

Usted es responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.