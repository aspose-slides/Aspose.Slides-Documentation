---
title: Exportar presentaciones a XAML en .NET
linktitle: Presentación a XAML
type: docs
weight: 30
url: /es/net/export-to-xaml/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar presentación
- convertir PowerPoint
- convertir OpenDocument
- convertir presentación
- PowerPoint a XAML
- OpenDocument a XAML
- presentación a XAML
- PPT a XAML
- PPTX a XAML
- ODP a XAML
- guardar PPT como XAML
- guardar PPTX como XAML
- guardar ODP como XAML
- exportar PPT a XAML
- exportar PPTX a XAML
- exportar ODP a XAML
- .NET
- C#
- Aspose.Slides
description: "Convertir diapositivas de PowerPoint y OpenDocument a XAML en .NET usando Aspose.Slides—solución rápida y sin Office que mantiene intacto tu diseño."
---
## **Visión general**

Este artículo explica cómo exportar presentaciones de PowerPoint a XAML usando Aspose.Slides. Incluye una breve introducción a XAML, muestra cómo guardar una presentación en XAML con la configuración predeterminada y demuestra cómo personalizar la exportación a través de [XamlOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export.xaml/xamloptions/), incluida la exportación de diapositivas ocultas. El artículo también responde a algunas preguntas frecuentes relacionadas con fuentes de reserva, compatibilidad de pilas XAML y el comportamiento de exportación de diapositivas ocultas.

## **Acerca de XAML**

XAML es un lenguaje de marcado basado en XML que se utiliza para describir interfaces de usuario en frameworks como WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin.Forms.

Puedes trabajar con archivos XAML en un diseñador visual o escribir y editar el marcado directamente.

## **Exportar presentaciones a XAML con opciones predeterminadas**

El siguiente ejemplo en C# muestra cómo exportar una presentación a XAML con la configuración predeterminada:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

De forma predeterminada, las diapositivas exportadas se guardan en una subcarpeta `pres` del directorio de trabajo actual del proceso, devuelto por [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory). La carpeta se crea automáticamente y cualquier imagen requerida también se guarda allí.

El nombre de la carpeta de salida se toma del nombre del archivo fuente sin su extensión. Para `pres.pptx`, los archivos de salida se nombran `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, etc. Incluso si proporcionas una ruta absoluta a la presentación de entrada, la carpeta de salida se crea de forma relativa al directorio de trabajo actual, en lugar de junto al archivo de entrada.

## **Exportar presentaciones a XAML con opciones personalizadas**

Utiliza la interfaz [IXamlOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export.xaml/ixamloptions/) para controlar cómo Aspose.Slides exporta una presentación a XAML.

Para guardar la salida en una ubicación personalizada, implementa [IXamlOutputSaver](https://reference.aspose.com/slides/es/net/aspose.slides.export.xaml/ixamloutputsaver/) y asigna una instancia de tu implementación a la propiedad [OutputSaver](https://reference.aspose.com/slides/es/net/aspose.slides.export.xaml/xamloptions/outputsaver/) de [XamlOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export.xaml/xamloptions/).

Para incluir diapositivas ocultas en la salida XAML, establece la propiedad [ExportHiddenSlides](https://reference.aspose.com/slides/es/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) en `true`, como se muestra en el siguiente ejemplo en C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Capturar todos los artefactos XAML generados**

Una exportación XAML puede producir un documento XAML por cada diapositiva exportada más imágenes y recursos de soporte independientes. Asigna un [IXamlOutputSaver](https://reference.aspose.com/slides/es/net/aspose.slides.export.xaml/ixamloutputsaver/) personalizado a [XamlOptions.OutputSaver](https://reference.aspose.com/slides/es/net/aspose.slides.export.xaml/xamloptions/outputsaver/) para recibir estos artefactos en lugar de usar el guardador de sistema de archivos predeterminado. Inicia la exportación con la sobrecarga específica de XAML de [Presentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/save/) que acepta opciones XAML.

### **Comprender el ciclo de vida de la devolución de llamada**

El exportador llama a [IXamlOutputSaver.Save](https://reference.aspose.com/slides/es/net/aspose.slides.export.xaml/ixamloutputsaver/save/) por separado para cada artefacto generado:

- `path` identifica el artefacto y puede incluir directorios relativos. Conserva esta información porque XAML puede referenciar recursos mediante rutas relativas.
- `data` contiene los bytes del artefacto. Las imágenes y otros recursos binarios no deben decodificarse como texto.
- El guardador es responsable de retener o persistir los datos antes de devolver. Los ejemplos copian cada matriz de bytes en memoria propia de la aplicación.
- Considera la exportación como exitosa solo cuando la operación de guardado de la presentación devuelve y cada devolución de llamada se ha completado con éxito. No suprimas errores de almacenamiento ni inicies escrituras en segundo plano sin observar. Si la persistencia ocurre posteriormente, informa el éxito global solo después de que ese paso también haya tenido éxito.

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/es/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) también se aplica a un guardador personalizado. Su valor predeterminado, `false`, excluye los documentos XAML de diapositivas ocultas. Establecerlo en `true` los incluye junto con cualquier recurso necesario para su exportación. El recuento de recursos depende de la presentación; no asumas una devolución de llamada por diapositiva o un orden de devolución de llamada fijo.

### **Exportar a memoria e inspeccionar los artefactos**

Este ejemplo completo carga `pres.pptx`, recopila cada artefacto en un [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) y muestra su nombre, tipo y recuento de bytes. Conserva exactamente los nombres suministrados. Los nombres duplicados hacen que la colección falle en lugar de sobrescribir silenciosamente un artefacto.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // Decodificar solo XAML, y solo cuando se necesita inspección textual.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Llama a `InMemoryXamlExample.Run` desde tu aplicación. Las comprobaciones de extensión son útiles para la inspección; conserva todos los artefactos, incluidos los tipos de recurso desconocidos. Deja los bytes sin modificar al almacenarlos o transmitirlos. Utiliza [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) solo para XAML que necesite procesamiento textual.

### **Empaquetar los artefactos recopilados en un archivo ZIP**

Este ejemplo independiente recopila la exportación, valida sus nombres y escribe los bytes originales en un archivo ZIP. Un nombre de archivo único separa trabajos de exportación concurrentes. Las entradas ZIP usan barras diagonales y conservan los directorios relativos. Los nombres inseguros o que colisionen tras la normalización se rechazan antes de escribir todo el paquete.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // El directorio ZIP se ha finalizado al descartarse antes de informar del éxito.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Llama a `ZipXamlExample.Run` desde tu aplicación. El ejemplo usa [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) para escribir un archivo local; el exportador en sí no escribe archivos XAML o de imagen sueltos. Para almacenamiento remoto, sustituye la fase de escritura del archivo por cargas de los arrays de bytes recopilados. Usa un identificador de trabajo de exportación más el nombre relativo completo del artefacto como clave de blob, o almacena el identificador del trabajo, el nombre relativo y los datos binarios en una fila de base de datos. Publica el trabajo solo después de que todas las cargas hayan finalizado o la transacción de la base de datos se haya confirmado. Elimina la salida parcial si la persistencia falla.

Para presentaciones grandes, un guardador personalizado puede persistir cada artefacto directamente en el almacenamiento de la aplicación para evitar mantener una copia adicional de toda la exportación en memoria. El exportador sigue recopilando todos los artefactos generados en memoria antes de llamar al guardador. Mantén cada devolución de llamada sincrónica desde la perspectiva del exportador: devuelve solo después de que el destino haya aceptado los bytes y permite que los fallos lleguen al llamador.

### **Conservar los nombres de recurso y verificar referencias**

- Normaliza los separadores de ruta cuando el destino lo requiera, pero conserva los directorios relativos. No utilices solo [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename) a menos que cada nombre generado sea único y las referencias de recurso sigan siendo válidas.
- Aplica la validación de nombres específica del destino. Al escribir archivos sueltos, rechaza rutas absolutas y segmentos de traversa, resuelve el destino con [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) y verifica que permanezca bajo el directorio de exportación previsto, incluido el separador de directorio en la comprobación de contención. Usa un directorio controlado por la aplicación sin enlaces simbólicos que puedan redirigir escrituras.
- Utiliza un guardador y un espacio de nombres de almacenamiento separados para cada trabajo de exportación. Detecta colisiones después de la normalización de separadores y según las reglas de sensibilidad a mayúsculas del destino.
- Antes de publicar, analiza cada documento XAML como XML e inspecciona sus referencias a recursos basados en archivos, como atributos `Source` o `ImageSource` de imágenes. Resuelve cada URI relativa contra el directorio del artefacto XAML contenedor, normaliza el nombre de almacenamiento resultante y confirma que la clave correspondiente del diccionario, la entrada ZIP o el objeto almacenado exista. Trata las URIs externas y las expresiones de marcado XAML por separado de los nombres de archivo relativos.

Por ejemplo, si `pres/Slide_1.xaml` hace referencia a `images/image1.png`, el recurso almacenado debe estar disponible como `pres/images/image1.png`. Conservar solo `image1.png` rompería esa relación. Para almacenamiento de objetos, conserva la misma estructura bajo el prefijo del trabajo y haz que esas URLs de recurso estén accesibles para el consumidor de XAML. Vuelve a abrir el ZIP completado para verificar los nombres de entrada y los bytes de recurso, y carga diapositivas representativas en el entorno XAML de destino para confirmar que las imágenes se resuelven correctamente.

## **FAQ**

**¿Cómo puedo garantizar fuentes predecibles si la fuente original no está disponible en el equipo?**

Establece [DefaultRegularFont](https://reference.aspose.com/slides/es/net/aspose.slides.export/saveoptions/defaultregularfont/) en [XamlOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export.xaml/xamloptions/) — se usa como fuente de reserva durante la exportación cuando falta la original. Esto no garantiza que el XAML generado haga referencia a la fuente de reserva o que la fuente esté disponible en el equipo de destino. Asegúrate de que las fuentes referenciadas por el XAML estén disponibles en el entorno donde se mostrará.

**¿El XAML exportado está pensado solo para WPF o también puede usarse en otras pilas XAML?**

Aspose.Slides exporta XAML de WPF a través de su API pública. La compatibilidad con otras pilas XAML, como UWP y Xamarin.Forms, no está garantizada. Prueba el marcado generado en tu entorno objetivo.

**¿Se admiten diapositivas ocultas y cómo puedo evitar que se exporten por defecto?**

Por defecto, las diapositivas ocultas no se incluyen. Puedes controlar este comportamiento mediante [ExportHiddenSlides](https://reference.aspose.com/slides/es/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) en [XamlOptions](https://reference.aspose.com/slides/es/net/aspose.slides.export.xaml/xamloptions/) — mantenlo desactivado si no necesitas exportarlas.