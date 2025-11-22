---
title: Fuente personalizada de PowerPoint en C#
linktitle: Fuente personalizada
type: docs
weight: 20
url: /es/net/custom-font/
keywords: "Fuentes, fuentes personalizadas, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Fuentes personalizadas de PowerPoint en C#"
---

{{% alert color="primary" %}} 

Aspose Slides permite cargar estas fuentes usando el método [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) :

* Fuentes TrueType (.ttf) y TrueType Collection (.ttc). Ver [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Fuentes OpenType (.otf). Ver [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Cargar fuentes personalizadas**

Aspose.Slides permite cargar fuentes que se renderizan en presentaciones sin necesidad de instalar esas fuentes. Las fuentes se cargan desde un directorio personalizado. 

1. Cree una instancia de la clase [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) y llame al método [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/).
2. Cargue la presentación que se va a renderizar.
3. Borre la caché en la clase [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

Este código C# demuestra el proceso de carga de fuentes:
``` csharp
// La ruta al directorio de documentos
string dataDir = "C:\\";
// carpetas donde buscar fuentes
String[] folders = new String[] { dataDir };
// Carga las fuentes del directorio de fuentes personalizadas
FontsLoader.LoadExternalFonts(folders);
// Realiza alguna tarea y renderiza la presentación/diapositiva
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);
// Borra la caché de fuentes
FontsLoader.ClearCache();
```


## **Obtener la carpeta de fuentes personalizadas**
Aspose.Slides proporciona el método [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) que le permite encontrar carpetas de fuentes. Este método devuelve las carpetas agregadas mediante el método `LoadExternalFonts` y las carpetas de fuentes del sistema.

Este código C# le muestra cómo usar [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):
```c#
 // Esta línea muestra las carpetas que se verifican para archivos de fuentes.
 // Esas son carpetas añadidas mediante el método LoadExternalFonts y carpetas de fuentes del sistema.
 string[] fontFolders = FontsLoader.GetFontFolders();
```


## **Especificar fuentes personalizadas usadas con la presentación**
Aspose.Slides proporciona la propiedad [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) que le permite especificar fuentes externas que se usarán con la presentación.

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

Aspose.Slides proporciona el método [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) que le permite cargar fuentes externas a partir de datos binarios.

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

Sí. Las fuentes conectadas son utilizadas por el motor de renderizado en todos los formatos de exportación.

**¿Se incrustan automáticamente las fuentes personalizadas en el PPTX resultante?**

No. Registrar una fuente para renderizado no es lo mismo que incrustarla en un PPTX. Si necesita que la fuente se incluya dentro del archivo de presentación, deberá usar las [funciones de incrustación](/slides/es/net/embedded-font/).

**¿Puedo controlar el comportamiento de sustitución cuando una fuente personalizada carece de ciertos glifos?**

Sí. Configure la [sustitución de fuentes](/slides/es/net/font-substitution/), las [reglas de reemplazo](/slides/es/net/font-replacement/) y los [conjuntos de fuentes de respaldo](/slides/es/net/fallback-font/) para definir exactamente qué fuente se usa cuando falta el glifo solicitado.

**¿Puedo usar fuentes en contenedores Linux/Docker sin instalarlas a nivel del sistema?**

Sí. Apunte a sus propias carpetas de fuentes o cargue fuentes desde matrices de bytes. Esto elimina cualquier dependencia de los directorios de fuentes del sistema en la imagen del contenedor.

**¿Qué pasa con la licencia—puedo incrustar cualquier fuente personalizada sin restricciones?**

Usted es responsable del cumplimiento de la licencia de la fuente. Los términos varían; algunas licencias prohíben la incrustación o el uso comercial. Siempre revise el EULA de la fuente antes de distribuir los resultados.