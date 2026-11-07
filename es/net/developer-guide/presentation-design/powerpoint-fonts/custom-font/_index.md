---
title: Personalizar fuentes de PowerPoint en .NET
linktitle: Fuente personalizada
type: docs
weight: 20
url: /es/net/custom-font/
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
- .NET
- C#
- Aspose.Slides
description: "Personaliza las fuentes en diapositivas de PowerPoint con Aspose.Slides para .NET para que tus presentaciones sean nítidas y consistentes en cualquier dispositivo."
---
## **Visión general**

Aspose.Slides le permite usar fuentes personalizadas en presentaciones sin instalarlas en el sistema operativo. Puede cargar fuentes desde carpetas personalizadas, proporcionar fuentes para una presentación específica a través de fuentes a nivel de documento, o cargar fuentes externas directamente desde datos binarios.

Las fuentes cargadas se utilizan cuando una presentación se renderiza o exporta, por ejemplo a PDF, imágenes y otros formatos compatibles. Esto ayuda a mantener la salida de la presentación consistente en diferentes entornos. El artículo también explica cómo inspeccionar las carpetas de fuentes usadas por Aspose.Slides y cómo limpiar la caché de fuentes después de trabajar con fuentes externas.

Registrar fuentes personalizadas para el renderizado es independiente de incrustar fuentes en un archivo PPTX. Si una fuente debe almacenarse dentro de la propia presentación, utilice explícitamente las características de incrustación de fuentes.

Un tema de presentación puede hacer referencia a diferentes familias tipográficas para sistemas de escritura individuales. Estas asignaciones almacenan nombres de fuentes pero no instalan ni cargan los archivos de fuentes. Consulte [Script-Specific Theme Fonts](/slides/es/net/script-specific-font-mappings/) para gestionar las asignaciones, y use las opciones de carga a continuación para que las fuentes referenciadas estén disponibles para un renderizado consistente.

{{% alert color="info" title="Note" %}}
Aspose Slides le permite cargar estas fuentes mediante el método [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/):

* Fuentes TrueType (.ttf) y colecciones TrueType (.ttc). Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Fuentes OpenType (.otf). Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides le permite cargar las fuentes utilizadas en una presentación sin instalarlas en el sistema. Esto afecta la salida de exportación —como PDF, imágenes y otros formatos compatibles— de modo que los documentos resultantes se vean consistentes en todos los entornos. Las fuentes se cargan desde directorios personalizados.

1. Especifique una o más carpetas que contengan los archivos de fuentes.
2. Llame al método estático [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) para cargar fuentes desde esas carpetas.
3. Cargue y renderice/exporte la presentación.
4. Llame a [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) para limpiar la caché de fuentes.

El siguiente ejemplo de código demuestra el proceso de carga de fuentes:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definir carpetas que contienen archivos de fuentes personalizadas.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Cargar fuentes personalizadas desde las carpetas especificadas.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderizar/exportar la presentación (p.ej., a PDF, imágenes u otros formatos) usando las fuentes cargadas.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Limpiar la caché de fuentes después de que se haya terminado el trabajo.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) agrega carpetas adicionales a las rutas de búsqueda de fuentes, pero no cambia el orden de inicialización de fuentes.
Las fuentes se inicializan en este orden:

1. La ruta de fuentes predeterminada del sistema operativo.
1. Las rutas cargadas a través de [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).
{{%/alert %}}

## **Obtener carpetas de fuentes personalizadas**
Aspose.Slides proporciona el método [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) para permitirle encontrar carpetas de fuentes. Este método devuelve las carpetas añadidas mediante el método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código C# muestra cómo usar [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Esta línea muestra las carpetas que se verifican para los archivos de fuentes.
// Esas son carpetas añadidas mediante el método LoadExternalFonts y las carpetas de fuentes del sistema.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Especificar fuentes personalizadas usadas con una presentación**
Aspose.Slides proporciona la propiedad [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) para permitir especificar fuentes externas que se utilizarán con la presentación.

Este código C# muestra cómo usar la propiedad [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Trabajar con la presentación
    // CustomFont1, CustomFont2 y las fuentes de las carpetas assets\fonts & global\fonts y sus subcarpetas están disponibles para la presentación
}
```

## **Gestionar fuentes externamente**

Aspose.Slides proporciona el método [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) para permitir cargar fuentes externas a partir de datos binarios.

Este código C# demuestra el proceso de carga de fuentes a partir de un array de bytes: 

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // fuente externa cargada durante la vida útil de la presentación
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

Para que una fuente registrada coincidente tenga prioridad durante la exportación sin eliminar la fuente incrustada, consulte [Prefer Registered Fonts over Embedded Fonts](/slides/es/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 o posterior).

## **Preguntas frecuentes**

**¿Afectan las fuentes personalizadas la exportación a todos los formatos (PDF, PNG, SVG, HTML)?**

Sí. Las fuentes conectadas son utilizadas por el motor de renderizado en todos los formatos de exportación.

**¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?**

No. Registrar una fuente para el renderizado no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente se incluya dentro del archivo de presentación, debe usar las [características de incrustación](/slides/es/net/embedded-font/).

**¿Puedo controlar el comportamiento de reserva cuando una fuente personalizada carece de ciertos glifos?**

Sí. Configure la [sustitución de fuentes](/slides/es/net/font-substitution/), las [reglas de reemplazo](/slides/es/net/font-replacement/) y los [conjuntos de reserva](/slides/es/net/fallback-font/) para definir exactamente qué fuente se usa cuando el glifo solicitado falta.

**¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?**

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde arrays de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

> **Nota para Linux/Docker**: Al llamar a `FontsLoader.LoadExternalFonts`, asegúrese de que cada entrada en el array `directories` contenga una ruta no vacía a un directorio existente. Si una variable de entorno usada para construir una ruta de fuentes está indefinida o vacía, Aspose.Slides puede intentar resolver el valor vacío como una ruta completa, lo que produce `System.ArgumentException`.

**¿Qué pasa con la licencia—puedo incrustar cualquier fuente personalizada sin restricciones?**

Usted es responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.