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
description: "Personaliza las fuentes en diapositivas de PowerPoint con Aspose.Slides para Android mediante Java para que tus presentaciones se vean nítidas y consistentes en cualquier dispositivo."
---
## **Descripción general**

Aspose.Slides le permite utilizar fuentes personalizadas en presentaciones sin instalarlas en el sistema operativo. Puede cargar fuentes desde carpetas personalizadas, proporcionar fuentes para una presentación específica mediante fuentes a nivel de documento, o cargar fuentes externas directamente desde datos binarios.

Las fuentes cargadas se utilizan cuando una presentación se renderiza o exporta, por ejemplo a PDF, imágenes y otros formatos compatibles. Esto ayuda a mantener la salida de la presentación coherente en diferentes entornos. El artículo también explica cómo inspeccionar las carpetas de fuentes usadas por Aspose.Slides y cómo borrar la caché de fuentes después de trabajar con fuentes externas.

Registrar fuentes personalizadas para el renderizado es independiente de incrustar fuentes en un archivo PPTX. Si una fuente debe almacenarse dentro de la propia presentación, utilice explícitamente las funciones de incrustación de fuentes.

Un tema de presentación puede referenciar diferentes familias tipográficas para sistemas de escritura individuales. Estas asignaciones almacenan nombres de fuentes pero no instalan ni cargan los archivos de fuentes. Consulte [Fuentes de tema específicas por script](/slides/es/androidjava/script-specific-font-mappings/) para gestionar las asignaciones, y utilice las opciones de carga a continuación para que las fuentes referenciadas estén disponibles para un renderizado coherente.

{{% alert color="info" title="Note" %}}
Aspose Slides le permite cargar estas fuentes usando el método [loadExternalFonts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}
## **Cargar fuentes personalizadas**

Aspose.Slides le permite cargar fuentes usadas en una presentación sin instalarlas en el sistema. Esto afecta la salida de exportación —como PDF, imágenes y otros formatos compatibles— de modo que los documentos resultantes tengan un aspecto coherente en diferentes entornos. Las fuentes se cargan desde directorios personalizados.

1. Especifique una o más carpetas que contengan los archivos de fuentes.
2. Llame al método estático [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) para cargar fuentes desde esas carpetas.
3. Cargue y renderice/exporte la presentación.
4. Llame a [FontsLoader.clearCache](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/FontsLoader#clearCache--) para borrar la caché de fuentes.

El siguiente ejemplo de código muestra el proceso de carga de fuentes:

```java
import com.aspose.slides.*;

// Definir carpetas que contengan archivos de fuentes personalizados.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Load custom fonts from the specified folders.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Renderizar/exportar la presentación (p.ej., a PDF, imágenes u otros formatos) usando las fuentes cargadas.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Borrar la caché de fuentes después de que el trabajo haya finalizado.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) añade carpetas adicionales a las rutas de búsqueda de fuentes, pero no cambia el orden de inicialización de fuentes.
Las fuentes se inicializan en este orden:

1. La ruta de fuentes predeterminada del sistema operativo.
1. Las rutas cargadas mediante [FontsLoader](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}
## **Obtener carpetas de fuentes personalizadas**
Aspose.Slides ofrece el método [getFontFolders](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) para permitirle encontrar carpetas de fuentes. Este método devuelve las carpetas añadidas mediante el método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código Java le muestra cómo usar [getFontFolders](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
import com.aspose.slides.*;

// Esta línea muestra las carpetas donde se buscan los archivos de fuentes.
// Son carpetas añadidas mediante el método LoadExternalFonts y las carpetas de fuentes del sistema.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Especificar fuentes personalizadas utilizadas con una presentación**
Aspose.Slides ofrece la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) para permitirle especificar fuentes externas que se usarán con la presentación.

Este código Java le muestra cómo usar la propiedad [setDocumentLevelFontSources](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    // CustomFont1, CustomFont2 y fuentes de las carpetas assets\fonts y global\fonts y sus subcarpetas están disponibles para la presentación
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gestionar fuentes externamente**

Aspose.Slides ofrece el método [loadExternalFont](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) para permitirle cargar fuentes externas a partir de datos binarios.

Este código Java muestra el proceso de carga de fuentes a partir de una matriz de bytes:

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

### ¿Afectan las fuentes personalizadas la exportación a todos los formatos (PDF, PNG, SVG, HTML)?

Sí. Las fuentes conectadas son utilizadas por el motor de renderizado en todos los formatos de exportación.

### ¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?

No. Registrar una fuente para el renderizado no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente esté contenida dentro del archivo de presentación, debe utilizar las [funciones de incrustación](/slides/es/androidjava/embedded-font/).

### ¿Puedo controlar el comportamiento de sustitución cuando una fuente personalizada carece de ciertos glifos?

Sí. Configure la [sustitución de fuentes](/slides/es/androidjava/font-substitution/), las [reglas de sustitución](/slides/es/androidjava/font-replacement/) y los [conjuntos de fuentes de reserva](/slides/es/androidjava/fallback-font/) para definir exactamente qué fuente se utiliza cuando el glifo solicitado no está disponible.

### ¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde matrices de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

### ¿Qué pasa con la licencia: puedo incrustar cualquier fuente personalizada sin restricciones?

Usted es responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.