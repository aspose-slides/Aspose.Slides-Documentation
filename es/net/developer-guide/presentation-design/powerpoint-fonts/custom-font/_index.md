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
description: "Personaliza las fuentes en diapositivas de PowerPoint con Aspose.Slides para .NET y mantén tus presentaciones nítidas y consistentes en cualquier dispositivo."
---
## **Descripción general**

Aspose.Slides le permite utilizar fuentes personalizadas en presentaciones sin instalarlas en el sistema operativo. Puede cargar fuentes desde carpetas personalizadas, proporcionar fuentes para una presentación concreta mediante fuentes a nivel de documento o cargar fuentes externas directamente a partir de datos binarios.

Las fuentes cargadas se utilizan cuando una presentación se renderiza o se exporta, por ejemplo a PDF, imágenes y otros formatos admitidos. Esto ayuda a que la salida de la presentación sea coherente en diferentes entornos. El artículo también explica cómo inspeccionar las carpetas de fuentes utilizadas por Aspose.Slides y cómo borrar la caché de fuentes después de trabajar con fuentes externas.

El registro de fuentes personalizadas para la renderización es independiente de la incrustación de fuentes en un archivo PPTX. Si una fuente debe almacenarse dentro de la propia presentación, utilice explícitamente las funciones de incrustación de fuentes.

Un tema de presentación puede hacer referencia a distintas familias tipográficas para sistemas de escritura individuales. Estas asignaciones almacenan los nombres de las fuentes pero no instalan ni cargan los archivos de fuentes. Consulte [Fuentes temáticas específicas de script](/slides/es/net/script-specific-font-mappings/) para gestionar las asignaciones y utilice las opciones de carga a continuación para que las fuentes referenciadas estén disponibles para una renderización coherente.

{{% alert color="info" title="Note" %}}

Aspose Slides le permite cargar estas fuentes mediante el método [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/es/net/aspose.slides/fontsloader/loadexternalfonts/):

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Véase [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Véase [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides le permite cargar fuentes usadas en una presentación sin instalarlas en el sistema. Esto afecta a la salida de exportación —como PDF, imágenes y otros formatos admitidos— de modo que los documentos resultantes se vean consistentes en todos los entornos. Las fuentes se cargan desde directorios personalizados.

1. Especifique una o más carpetas que contengan los archivos de fuentes.
2. Llame al método estático [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/es/net/aspose.slides/fontsloader/loadexternalfonts/) para cargar fuentes desde esas carpetas.
3. Cargue y renderice/exporte la presentación.
4. Llame a [FontsLoader.ClearCache](https://reference.aspose.com/slides/es/net/aspose.slides/fontsloader/clearcache/) para borrar la caché de fuentes.

El siguiente ejemplo de código muestra el proceso de carga de fuentes:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definir carpetas que contienen archivos de fuentes personalizadas.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Cargar fuentes personalizadas desde las carpetas especificadas.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderizar/exportar la presentación (p.ej., a PDF, imágenes u otros formatos) usando las fuentes cargadas.
presentation.Save("output.pdf", SaveFormat.Pdf");

// Borrar la caché de fuentes después de que se haya finalizado el trabajo.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/es/net/aspose.slides/fontsloader/loadexternalfonts/) añade carpetas adicionales a las rutas de búsqueda de fuentes, pero no cambia el orden de inicialización de las fuentes.
Las fuentes se inicializan en este orden:

1. La ruta de fuentes predeterminada del sistema operativo.
1. Las rutas cargadas mediante [FontsLoader](https://reference.aspose.com/slides/es/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtener carpetas de fuentes personalizadas**

Aspose.Slides proporciona el método [GetFontFolders](https://reference.aspose.com/slides/es/net/aspose.slides/fontsloader/getfontfolders/) para permitirle encontrar carpetas de fuentes. Este método devuelve las carpetas añadidas a través del método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código C# le muestra cómo usar [GetFontFolders](https://reference.aspose.com/slides/es/net/aspose.slides/fontsloader/getfontfolders/):

```c#
using Aspose.Slides;

// Esta línea muestra las carpetas que se comprueban para archivos de fuentes.
// Estas son carpetas añadidas mediante el método LoadExternalFonts y carpetas de fuentes del sistema.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Especificar fuentes personalizadas usadas con una presentación**

Aspose.Slides proporciona la propiedad [DocumentLevelFontSources](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/documentlevelfontsources/) para permitirle especificar fuentes externas que se utilizarán con la presentación.

Este código C# le muestra cómo usar la propiedad [DocumentLevelFontSources](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/documentlevelfontsources/):

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

## **Gestión externa de fuentes**

Aspose.Slides proporciona el método [LoadExternalFont](https://reference.aspose.com/slides/es/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) para permitirle cargar fuentes externas a partir de datos binarios.

Este código C# demuestra el proceso de carga de fuentes a partir de una matriz de bytes:

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

## **Preguntas frecuentes**

**¿Las fuentes personalizadas afectan a la exportación a todos los formatos (PDF, PNG, SVG, HTML)?**

Sí. Las fuentes conectadas son usadas por el motor de renderizado en todos los formatos de exportación.

**¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?**

No. Registrar una fuente para la renderización no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente permanezca dentro del archivo de presentación, debe utilizar las [funciones de incrustación](/slides/es/net/embedded-font/).

**¿Puedo controlar el comportamiento de sustitución cuando una fuente personalizada carece de ciertos glifos?**

Sí. Configure la [sustitución de fuentes](/slides/es/net/font-substitution/), las [reglas de reemplazo](/slides/es/net/font-replacement/) y los [conjuntos de fuentes de reserva](/slides/es/net/fallback-font/) para definir exactamente qué fuente se usa cuando falta el glifo solicitado.

**¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?**

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde matrices de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

> **Nota para Linux/Docker**: al llamar a `FontsLoader.LoadExternalFonts`, asegúrese de que cada elemento del array `directories` contenga una ruta no vacía a un directorio existente. Si una variable de entorno utilizada para construir una ruta de fuente está indefinida o vacía, Aspose.Slides podría intentar resolver el valor vacío como una ruta completa, lo que producirá `System.ArgumentException`.

**¿Qué pasa con la licencia? ¿Puedo incrustar cualquier fuente personalizada sin restricciones?**

Usted es responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.