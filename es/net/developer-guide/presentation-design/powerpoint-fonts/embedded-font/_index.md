---
title: Incrustar fuentes en presentaciones en .NET
linktitle: Fuentes incrustadas
type: docs
weight: 40
url: /es/net/embedded-font/
keywords:
- añadir fuente
- incrustar fuente
- incrustación de fuentes
- obtener fuente incrustada
- añadir fuente incrustada
- eliminar fuente incrustada
- comprimir fuente incrustada
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Gestiona fuentes incrustadas en PowerPoint con Aspose.Slides para .NET. Usa C# para añadir, obtener, eliminar y comprimir fuentes y así preservar la apariencia del texto y reducir el tamaño del archivo."
---
## **Introducción**

Incrustar fuentes almacena los datos de la fuente dentro de una presentación de PowerPoint. Cuando un visor admite fuentes incrustadas, puede mostrar el texto usando esas fuentes aunque no estén instaladas en el sistema de destino. Esto ayuda a conservar los saltos de línea, el espaciado del texto y el diseño de la diapositiva.

Aspose.Slides para .NET le permite obtener, añadir y eliminar fuentes incrustadas a través de la propiedad [FontsManager](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/fontsmanager/) de una [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/). También puede reducir el tamaño de los datos de fuentes incrustadas eliminando los caracteres que la presentación no utiliza.

Los ejemplos siguientes trabajan con archivos PPTX. Antes de incrustar una fuente, asegúrese de que sus datos de fuente estén disponibles para Aspose.Slides y de que su licencia permita la incrustación.

## **Obtener y eliminar fuentes incrustadas**

Utilice [GetEmbeddedFonts](https://reference.aspose.com/slides/es/net/aspose.slides/fontsmanager/getembeddedfonts/) para enumerar las fuentes almacenadas en una presentación. Para eliminar una, pase una fuente de esa lista a [RemoveEmbeddedFont](https://reference.aspose.com/slides/es/net/aspose.slides/fontsmanager/removeembeddedfont/), y luego guarde la presentación.

El siguiente ejemplo enumera las fuentes incrustadas en `EmbeddedFonts.pptx` y elimina Calibri si está presente:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

Eliminar una fuente incrustada elimina sus datos de fuente almacenados; no cambia la fuente asignada al texto. Si la fuente está instalada en el sistema de destino, el texto aún puede usarla. De lo contrario, la renderización puede requerir [sustitución de fuentes](/slides/es/net/font-substitution/), lo que puede afectar el diseño.

## **Inspeccionar datos de fuentes y permisos de incrustación**

Utilice la interfaz [IFontsManager](https://reference.aspose.com/slides/es/net/aspose.slides/ifontsmanager/) para inspeccionar las fuentes antes de incrustarlas. Llame a [IFontsManager.GetFonts](https://reference.aspose.com/slides/es/net/aspose.slides/ifontsmanager/getfonts/) para obtener las fuentes utilizadas en la presentación. Para cada fuente, pase un objeto [IFontData](https://reference.aspose.com/slides/es/net/aspose.slides/ifontdata/) y el valor requerido de [FontStyleType](https://reference.aspose.com/slides/es/net/aspose.slides/fontstyletype/) a [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/es/net/aspose.slides/ifontsmanager/getfontbytes/). El método devuelve los datos binarios de ese estilo de fuente, o `null` cuando la fuente o estilo solicitado no está disponible. No pase un resultado `null` a [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/es/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), ya que ese método requiere un array de bytes.

[EmbeddingLevel](https://reference.aspose.com/slides/es/net/aspose.slides/embeddinglevel/) es una enumeración de banderas que informa de las restricciones de incrustación almacenadas en la fuente:

- `Installable` permite la incrustación y la instalación permanente en otro sistema, sujeto a la licencia de la fuente.
- `Restricted` prohíbe la incrustación a menos que se obtenga permiso del propietario legal de la fuente cuando es la única bandera de permiso de uso.
- `PreviewPrint` permite el uso temporal para visualización e impresión; un documento que contiene la fuente debe ser de solo lectura.
- `Editable` permite el uso temporal y permite que el documento se edite y guarde.
- `NoSubsetting` es una restricción adicional que prohíbe incrustar solo un subconjunto de los glifos. Incruste todos los caracteres cuando esta bandera está presente.
- `BitmapOnly` es una restricción adicional que permite incrustar solo versiones bitmap, no datos de contorno. Si la fuente no tiene versiones bitmap, no puede ser incrustada.

Los primeros cuatro valores describen el permiso de uso, mientras que `NoSubsetting` y `BitmapOnly` pueden combinarse con ellos. Verifique los modificadores con operaciones a nivel de bits. Como `Installable` es cero, no utilice `HasFlag` para detectarlo; enmascare los bits de permiso de uso y compare el resultado con `Installable`. Las fuentes actuales deben establecer como máximo un bit de permiso de uso. Para compatibilidad con fuentes antiguas que establecen más de uno, el ayudante a continuación selecciona el permiso menos restrictivo: `Editable`, luego `PreviewPrint`, luego `Restricted`.

El siguiente ejemplo revisa los datos regular, negrita, cursiva y negrita‑cursiva disponibles para cada fuente devuelta por `GetFonts`. Omite estilos no disponibles, fuentes restringidas, fuentes solo bitmap, fuentes limitadas a vista previa e impresión porque la salida sigue siendo editable, y fuentes que ya están incrustadas. Si algún estilo disponible tiene `NoSubsetting`, incrusta todos los caracteres para esa familia de fuentes.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

Esta inspección informa de las restricciones codificadas en cada archivo de fuente. No concede una licencia, no prueba que haya obtenido la fuente legalmente, ni sustituye la verificación del acuerdo de licencia de la fuente antes de distribuir una copia incrustada.

## **Añadir fuentes incrustadas**

Utilice [AddEmbeddedFont](https://reference.aspose.com/slides/es/net/aspose.slides/fontsmanager/addembeddedfont/) para incrustar una fuente. Sus sobrecargas aceptan ya sea un objeto [IFontData](https://reference.aspose.com/slides/es/net/aspose.slides/ifontdata/) o un array de bytes que contiene los datos de la fuente. La enumeración [EmbedFontCharacters](https://reference.aspose.com/slides/es/net/aspose.slides.export/embedfontcharacters/) controla qué caracteres se incluyen:

- [All] incrusta todos los caracteres de la fuente. Use esta opción cuando los destinatarios necesiten editar la presentación e introducir texto nuevo.
- [OnlyUsed] incrusta solo los caracteres usados en la presentación para reducir el tamaño del archivo. Elija esta opción para una presentación terminada que se destine principalmente a la visualización.

El siguiente ejemplo utiliza [GetFonts](https://reference.aspose.com/slides/es/net/aspose.slides/fontsmanager/getfonts/) para obtener las fuentes usadas en `Fonts.pptx` e incrusta aquellas que aún no están incrustadas. Las fuentes a añadir deben estar disponibles en la máquina que ejecuta el código. Las fuentes incrustadas existentes conservan sus juegos de caracteres actuales.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **Comprimir fuentes incrustadas**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/es/net/aspose.slides.lowcode/compress/compressembeddedfonts/) reduce los datos de fuentes incrustadas eliminando los caracteres no usados. Actúa sobre fuentes que ya están incrustadas, por lo que la reducción de tamaño depende de cuánto datos de fuente sin usar contenga la presentación.

El siguiente ejemplo comprime las fuentes en `EmbeddedFonts.pptx` y guarda el resultado como un archivo separado:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Conserve el archivo original si los destinatarios pueden necesitar añadir texto más tarde. Los caracteres eliminados durante la compresión ya no están disponibles en la fuente incrustada, incluso si inicialmente se incrustaron todos los caracteres.

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si una fuente incrustada seguirá siendo sustituida durante la renderización?**

Llame a [GetSubstitutions](https://reference.aspose.com/slides/es/net/aspose.slides/fontsmanager/getsubstitutions/) en el entorno donde renderiza la presentación para ver qué fuentes reemplazará Aspose.Slides. También revise la configuración de [sustitución de fuentes](/slides/es/net/font-substitution/) y las reglas de [fuentes de reserva](/slides/es/net/fallback-font/). El fallback gestiona los caracteres faltantes, por lo que incrustar una fuente no soluciona los caracteres que la propia fuente no contiene.

**¿Debo incrustar fuentes comunes como Arial y Calibri?**

Base la decisión en el entorno de destino. Si las fuentes requeridas están disponibles en cada máquina que abre o renderiza la presentación, incrustarlas puede añadir un tamaño de archivo innecesario. Si los destinatarios o los servidores pueden carecer de esas fuentes, incrustarlas puede ayudar a preservar la apariencia prevista, siempre que sus licencias lo permitan.