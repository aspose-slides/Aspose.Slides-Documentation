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
description: "Personaliza las fuentes en diapositivas de PowerPoint con Aspose.Slides para Java para mantener tus presentaciones nítidas y coherentes en cualquier dispositivo."
---

{{% alert color="primary" %}} 

Aspose Slides le permite cargar estas fuentes mediante el método [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides le permite cargar las fuentes utilizadas en una presentación sin instalarlas en el sistema. Esto afecta la salida de exportación—como PDF, imágenes y otros formatos compatibles—por lo que los documentos resultantes mantienen una apariencia coherente en diferentes entornos. Las fuentes se cargan desde directorios personalizados.

1. Especifique una o más carpetas que contengan los archivos de fuentes.
2. Llame al método estático [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) para cargar fuentes desde esas carpetas.
3. Cargue y renderice/exporte la presentación.
4. Llame a [FontsLoader.clearCache](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) para limpiar la caché de fuentes.

El siguiente ejemplo de código muestra el proceso de carga de fuentes:
```java
// Definir carpetas que contienen archivos de fuentes personalizadas.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Cargar fuentes personalizadas desde las carpetas especificadas.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Renderizar/exportar la presentación (p.ej., a PDF, imágenes u otros formatos) usando las fuentes cargadas.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Limpiar la caché de fuentes después de que se haya terminado el trabajo.
    FontsLoader.clearCache();
}
```


{{% alert color="info" title="Nota" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) añade carpetas adicionales a las rutas de búsqueda de fuentes, pero no cambia el orden de inicialización de las fuentes.  
Las fuentes se inicializan en este orden:

1. La ruta de fuentes predeterminada del sistema operativo.  
2. Las rutas cargadas a través de [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtener carpetas de fuentes personalizadas**

Aspose.Slides proporciona el método [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) para permitirle encontrar carpetas de fuentes. Este método devuelve las carpetas añadidas mediante el método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código Java muestra cómo usar [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--):
```java
// Esta línea muestra las carpetas donde se buscan los archivos de fuentes.
// Son carpetas añadidas mediante el método LoadExternalFonts y carpetas de fuentes del sistema.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **Especificar fuentes personalizadas usadas con una presentación**

Aspose.Slides proporciona la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) para permitirle especificar fuentes externas que se utilizarán con la presentación.

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
    // CustomFont1, CustomFont2 y fuentes de las carpetas assets\fonts & global\fonts y sus subcarpetas están disponibles para la presentación
} finally {
    if (pres != null) pres.dispose();
}
```


## **Administrar fuentes externamente**

Aspose.Slides proporciona el método [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) para permitirle cargar fuentes externas a partir de datos binarios.

Este código Java demuestra el proceso de carga de fuentes a partir de un array de bytes:
```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // fuente externa cargada durante la vida de la presentación
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

Sí. Las fuentes conectadas son usadas por el motor de renderizado en todos los formatos de exportación.

**¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?**

No. Registrar una fuente para su renderizado no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente forme parte del archivo de presentación, debe utilizar las funciones de incrustación explícitas.

**¿Puedo controlar el comportamiento de reserva cuando una fuente personalizada carece de ciertos glifos?**

Sí. Configure la [sustitución de fuentes](/slides/es/java/font-substitution/), las [reglas de reemplazo](/slides/es/java/font-replacement/) y los [conjuntos de reserva](/slides/es/java/fallback-font/) para definir exactamente qué fuente se usa cuando el glifo solicitado falta.

**¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?**

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde arrays de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

**¿Qué pasa con la licencia—puedo incrustar cualquier fuente personalizada sin restricciones?**

Usted es responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.