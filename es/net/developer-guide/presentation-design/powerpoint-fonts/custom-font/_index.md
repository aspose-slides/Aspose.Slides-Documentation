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
- administrar fuentes
- carpeta de fuentes
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Personaliza las fuentes en diapositivas de PowerPoint con Aspose.Slides para .NET y mantiene tus presentaciones nítidas y consistentes en cualquier dispositivo."
---

{{% alert color="primary" %}} 

Aspose Slides le permite cargar estas fuentes usando el método [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/):

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Consulte [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Consulte [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides le permite cargar fuentes que se renderizan en presentaciones sin necesidad de instalar esas fuentes. Las fuentes se cargan desde un directorio personalizado. 

1. Cree una instancia de la clase [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) y llame al método [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/).
2. Cargue la presentación que se renderizará.
3. Borre la caché en la clase [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

Este código C# demuestra el proceso de carga de fuentes:
``` csharp
// La ruta al directorio de documentos
string dataDir = "C:\\";
 
// carpetas donde buscar fuentes
String[] folders = new String[] { dataDir };
 
// Carga las fuentes del directorio de fuentes personalizado
FontsLoader.LoadExternalFonts(folders);
 
// Realiza alguna tarea y renderiza la presentación/diapositiva
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);
 
// Borra la caché de fuentes
FontsLoader.ClearCache();
```


## **Obtener carpetas de fuentes personalizadas**
Aspose.Slides proporciona el método [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) para permitirle encontrar carpetas de fuentes. Este método devuelve las carpetas agregadas mediante el método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código C# le muestra cómo usar [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):
```c#
// Esta línea muestra las carpetas que se verifican para archivos de fuentes.
// Son carpetas añadidas mediante el método LoadExternalFonts y carpetas de fuentes del sistema.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **Especificar fuentes personalizadas usadas con una presentación**
Aspose.Slides proporciona la propiedad [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) para permitirle especificar fuentes externas que se usarán con la presentación.

Este código C# le muestra cómo usar la propiedad [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/):
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


## **Administrar fuentes externamente**

Aspose.Slides proporciona el método [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) para permitirle cargar fuentes externas a partir de datos binarios.

Este código C# demuestra el proceso de carga de fuentes desde una matriz de bytes: 
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

**¿Las fuentes personalizadas afectan la exportación a todos los formatos (PDF, PNG, SVG, HTML)?**

Sí. Las fuentes vinculadas son usadas por el motor de renderizado en todos los formatos de exportación.

**¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?**

No. Registrar una fuente para renderizado no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente esté dentro del archivo de la presentación, debe usar las [embedding features](/slides/es/net/embedded-font/).

**¿Puedo controlar el comportamiento de sustitución cuando una fuente personalizada carece de ciertos glifos?**

Sí. Configure la [font substitution](/slides/es/net/font-substitution/), las [replacement rules](/slides/es/net/font-replacement/) y los [fallback sets](/slides/es/net/fallback-font/) para definir exactamente qué fuente se usa cuando falta el glifo solicitado.

**¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?**

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde matrices de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

**¿Qué pasa con la licencia—puedo incrustar cualquier fuente personalizada sin restricciones?**

Usted es responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.