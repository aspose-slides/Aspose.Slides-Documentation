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
description: "Personaliza las fuentes en diapositivas de PowerPoint con Aspose.Slides para Android mediante Java para que tus presentaciones se vean nítidas y coherentes en cualquier dispositivo."
---
## **Visión general**

Aspose.Slides permite usar fuentes personalizadas en presentaciones sin instalarlas en el sistema operativo. Puedes cargar fuentes desde carpetas personalizadas, proporcionar fuentes para una presentación específica a través de fuentes a nivel de documento, o cargar fuentes externas directamente desde datos binarios.

Las fuentes cargadas se utilizan cuando una presentación se renderiza o exporta, por ejemplo a PDF, imágenes y otros formatos compatibles. Esto ayuda a mantener la salida de la presentación coherente en diferentes entornos. El artículo también explica cómo inspeccionar las carpetas de fuentes usadas por Aspose.Slides y cómo borrar la caché de fuentes después de trabajar con fuentes externas.

Registrar fuentes personalizadas para el renderizado es independiente de incrustar fuentes en un archivo PPTX. Si una fuente debe almacenarse dentro de la propia presentación, usa explícitamente las funciones de incrustación de fuentes.

{{% alert color="info" %}} 
Aspose Slides permite cargar estas fuentes mediante el método [loadExternalFonts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Ver [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Ver [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides permite cargar fuentes utilizadas en una presentación sin instalarlas en el sistema. Esto afecta la salida de exportación —como PDF, imágenes y otros formatos compatibles— de modo que los documentos resultantes se vean consistentes en todos los entornos. Las fuentes se cargan desde directorios personalizados.

1. Especifica una o más carpetas que contengan los archivos de fuentes.
2. Llama al método estático [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) para cargar fuentes desde esas carpetas.
3. Carga y renderiza/expórta la presentación.
4. Llama a [FontsLoader.clearCache](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontsLoader#clearCache--) para borrar la caché de fuentes.

El siguiente ejemplo de código muestra el proceso de carga de fuentes:

```java
import com.aspose.slides.*;

// Definir carpetas que contienen archivos de fuentes personalizadas.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Cargar fuentes personalizadas desde las carpetas especificadas.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Renderizar/exportar la presentación (p. ej., a PDF, imágenes u otros formatos) usando las fuentes cargadas.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Vaciar la caché de fuentes después de que el trabajo haya finalizado.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Nota" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) añade carpetas adicionales a las rutas de búsqueda de fuentes, pero no cambia el orden de inicialización de las fuentes.  
Las fuentes se inicializan en este orden:

1. La ruta predeterminada de fuentes del sistema operativo.
1. Las rutas cargadas a través de [FontsLoader](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtener carpetas de fuentes personalizadas**
Aspose.Slides proporciona el método [getFontFolders](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) para permitirte encontrar carpetas de fuentes. Este método devuelve las carpetas añadidas mediante el método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código Java muestra cómo usar [getFontFolders](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Esta línea muestra las carpetas donde se buscan los archivos de fuentes.
// Esas son carpetas añadidas mediante el método LoadExternalFonts y las carpetas de fuentes del sistema.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Especificar fuentes personalizadas usadas con una presentación**
Aspose.Slides proporciona la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) para permitirte especificar fuentes externas que se usarán con la presentación.

Este código Java muestra cómo usar la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Trabajar con la presentación
    // CustomFont1, CustomFont2 y las fuentes de las carpetas assets\fonts & global\fonts y sus subcarpetas están disponibles para la presentación
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestionar fuentes externamente**

Aspose.Slides proporciona el método [loadExternalFont](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) para permitirte cargar fuentes externas a partir de datos binarios.

Este código Java demuestra el proceso de carga de fuentes desde un arreglo de bytes:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

### ¿Afectan las fuentes personalizadas a la exportación a todos los formatos (PDF, PNG, SVG, HTML)?

Sí. Las fuentes conectadas son utilizadas por el motor de renderizado en todos los formatos de exportación.

### ¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?

No. Registrar una fuente para renderizado no es lo mismo que incrustarla en un PPTX. Si necesitas que la fuente se incluya dentro del archivo de presentación, debes usar explícitamente las [funciones de incrustado](/slides/es/androidjava/embedded-font/).

### ¿Puedo controlar el comportamiento de sustitución cuando una fuente personalizada carece de ciertos glifos?

Sí. Configura [font substitution](/slides/es/androidjava/font-substitution/), [replacement rules](/slides/es/androidjava/font-replacement/) y [fallback sets](/slides/es/androidjava/fallback-font/) para definir exactamente qué fuente se usa cuando el glifo solicitado falta.

### ¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?

Sí. Apunta a tus propias carpetas de fuentes o carga fuentes desde matrices de bytes. Esto elimina cualquier dependencia de las carpetas de fuentes del sistema en la imagen del contenedor.

### ¿Qué pasa con la licencia? ¿Puedo incrustar cualquier fuente personalizada sin restricciones?

Eres responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revisa el EULA de la fuente antes de distribuir los resultados.