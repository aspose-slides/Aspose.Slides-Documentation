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
description: "Personaliza las fuentes en diapositivas de PowerPoint con Aspose.Slides para .NET y mantiene tus presentaciones nítidas y coherentes en cualquier dispositivo."
---

{{% alert color="primary" %}} 

Aspose Slides le permite cargar estas fuentes mediante el método [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/):

* Fuentes TrueType (.ttf) y colecciones TrueType (.ttc). Véase [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Véase [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides le permite cargar fuentes utilizadas en una presentación sin instalarlas en el sistema. Esto afecta la salida de exportación —como PDF, imágenes y otros formatos compatibles—, de modo que los documentos resultantes se vean consistentes en diferentes entornos. Las fuentes se cargan desde directorios personalizados.

1. Especifique una o más carpetas que contengan los archivos de fuentes.
2. Llame al método estático [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) para cargar las fuentes desde esas carpetas.
3. Cargue y renderice/exporte la presentación.
4. Llame a [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) para borrar la caché de fuentes.

El siguiente ejemplo de código muestra el proceso de carga de fuentes:
```cs
// Definir carpetas que contienen archivos de fuentes personalizadas.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// Cargar fuentes personalizadas desde las carpetas especificadas.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Renderizar/exportar la presentación (p.ej., a PDF, imágenes u otros formatos) usando las fuentes cargadas.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Borrar la caché de fuentes después de que el trabajo haya finalizado.
FontsLoader.ClearCache();
```


{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) añade carpetas adicionales a las rutas de búsqueda de fuentes, pero no cambia el orden de inicialización de fuentes.
Las fuentes se inicializan en este orden:

1. La ruta de fuentes predeterminada del sistema operativo.
1. Las rutas cargadas mediante [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtener carpetas de fuentes personalizadas**
Aspose.Slides provee el método [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) que le permite encontrar carpetas de fuentes. Este método devuelve las carpetas añadidas mediante el método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código C# muestra cómo usar [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):
```c#
// Esta línea muestra las carpetas que se verifican para archivos de fuentes.
// Son carpetas añadidas mediante el método LoadExternalFonts y carpetas de fuentes del sistema.
string[] fontFolders = FontsLoader.GetFontFolders();
```



## **Especificar fuentes personalizadas usadas con una presentación**
Aspose.Slides provee la propiedad [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) que permite especificar fuentes externas que se usarán con la presentación.

Este código C# muestra cómo usar la propiedad [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):
```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Trabajar con la presentación
    // CustomFont1, CustomFont2 y fuentes de las carpetas assets\fonts & global\fonts y sus subcarpetas están disponibles para la presentación
}
```


## **Gestionar fuentes externamente**

Aspose.Slides provee el método [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) que le permite cargar fuentes externas a partir de datos binarios.

Este código C# demuestra el proceso de carga de fuentes a partir de un array de bytes: 
```c#
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

**¿Afectan las fuentes personalizadas a la exportación a todos los formatos (PDF, PNG, SVG, HTML)?**

Sí. Las fuentes conectadas son utilizadas por el motor de renderizado en todos los formatos de exportación.

**¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?**

No. Registrar una fuente para renderizado no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente esté dentro del archivo de la presentación, debe usar las [funciones de incrustación](/slides/es/net/embedded-font/).

**¿Puedo controlar el comportamiento de reserva cuando una fuente personalizada carece de ciertos glifos?**

Sí. Configure la [sustitución de fuentes](/slides/es/net/font-substitution/), las [reglas de reemplazo](/slides/es/net/font-replacement/) y los [conjuntos de reserva](/slides/es/net/fallback-font/) para definir exactamente qué fuente se usará cuando el glifo solicitado no exista.

**¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas en todo el sistema?**

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde arrays de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

**¿Qué pasa con la licencia—puedo incrustar cualquier fuente personalizada sin restricciones?**

Usted es responsable del cumplimiento de la licencia de las fuentes. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise la EULA de la fuente antes de distribuir los resultados.