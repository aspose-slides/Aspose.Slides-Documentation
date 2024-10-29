---
title: Fuente personalizada de PowerPoint en C#
linktitle: Fuente personalizada
type: docs
weight: 20
url: /es/net/custom-font/
keywords: "Fuentes, fuentes personalizadas, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Fuentes personalizadas de PowerPoint en C#"
---

{{% alert color="primary" %}} 

Aspose Slides te permite cargar estas fuentes usando el método [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/):

* Fuentes TrueType (.ttf) y Colección TrueType (.ttc). Ver [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Ver [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar Fuentes Personalizadas**

Aspose.Slides te permite cargar fuentes que se renderizan en presentaciones sin necesidad de instalar esas fuentes. Las fuentes se cargan desde un directorio personalizado.

1. Crea una instancia de la clase [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) y llama al método [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/).
2. Carga la presentación que será renderizada.
3. Limpia la caché en la clase [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

Este código C# demuestra el proceso de carga de fuentes:

``` csharp
// La ruta al directorio de documentos
string dataDir = "C:\\";

// carpetas para buscar fuentes
String[] folders = new String[] { dataDir };

// Carga las fuentes del directorio de fuentes personalizadas
FontsLoader.LoadExternalFonts(folders);

// Realiza algunas tareas y realiza la renderización de la presentación/diapositiva
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// Limpia la caché de fuentes
FontsLoader.ClearCache();
```

## **Obtener Carpeta de Fuentes Personalizadas**
Aspose.Slides proporciona el método [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) para permitirte encontrar carpetas de fuentes. Este método devuelve carpetas añadidas a través del método `LoadExternalFonts` y carpetas de fuentes del sistema.

Este código C# te muestra cómo usar [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):

```c#
// Esta línea muestra las carpetas que se verifican para archivos de fuentes.
// Esas son carpetas añadidas a través del método LoadExternalFonts y carpetas de fuentes del sistema.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **Especificar Fuentes Personalizadas Usadas Con la Presentación**
Aspose.Slides proporciona la propiedad [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) para permitirte especificar fuentes externas que se utilizarán con la presentación.

Este código C# te muestra cómo usar la propiedad [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Trabaja con la presentación
    // CustomFont1, CustomFont2, y fuentes de las carpetas assets\fonts y global\fonts y sus subcarpetas están disponibles para la presentación
}
```

## **Gestionar Fuentes Externamente**

Aspose.Slides proporciona el método [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) para permitirte cargar fuentes externas desde datos binarios.

Este código C# demuestra el proceso de carga de fuentes desde un arreglo de bytes: 

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