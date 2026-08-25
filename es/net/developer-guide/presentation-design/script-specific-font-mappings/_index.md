---
title: Administrar fuentes temáticas específicas de script en .NET
linktitle: Fuentes temáticas específicas de script
type: docs
weight: 15
url: /es/net/script-specific-font-mappings/
keywords:
- fuente específica de script
- mapeo de fuente temática
- presentación multilingüe
- sistema de escritura
- fuente cirílica
- fuente árabe
- fuente japonesa
- fuente georgiana
- fuente thaana
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Inspeccionar, añadir, reemplazar y eliminar mapeos de fuentes específicas de script en temas de PowerPoint con Aspose.Slides para .NET."
---
## **Visión general**

Un tema de presentación puede seleccionar diferentes familias tipográficas para distintos sistemas de escritura. Esto permite que el texto multilingüe que sigue usando las fuentes del tema siga un esquema tipográfico coordinado mientras utiliza fuentes adecuadas para cirílico, árabe, japonés, georgiano, thaana y otras escrituras.

El tema's [IFontScheme](https://reference.aspose.com/slides/es/net/aspose.slides.theme/ifontscheme/) contiene una colección de fuentes principales, normalmente utilizada para títulos, y una colección de fuentes secundarias, normalmente utilizada para el cuerpo del texto. Además de sus propiedades tipográficas latinas y de Asia Oriental, ambas colecciones exponen mapeos de etiquetas de sistemas de escritura a nombres de familias tipográficas a través de la interfaz [IFonts](https://reference.aspose.com/slides/es/net/aspose.slides/ifonts/).

Este artículo muestra cómo inspeccionar y modificar esos mapeos en el tema maestro de la presentación y verificar que los cambios sobrevivan a un ciclo de guardar y recargar.

## **Comprender las etiquetas de escritura**

Los métodos de fuentes de escritura utilizan subtags de script BCP 47 de cuatro letras para identificar los sistemas de escritura. Los valores más comunes incluyen:

| Etiqueta de script | Sistema de escritura |
|---|---|
| `Cyrl` | Cirílico |
| `Arab` | Árabe |
| `Hans` | Chino simplificado |
| `Jpan` | Japonés |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Estos mapeos pertenecen al esquema tipográfico del tema, no a porciones individuales de texto. Una presentación puede definir diferentes mapeos para las colecciones principales y secundarias, y puede omitir mapeos para algunos scripts.

## **Acceder e inspeccionar los mapeos de fuentes de script**

Utilice [Presentation.MasterTheme](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/mastertheme/) para acceder al tema a nivel de presentación. Las propiedades [FontScheme.Major](https://reference.aspose.com/slides/es/net/aspose.slides.theme/fontscheme/major/) y [FontScheme.Minor](https://reference.aspose.com/slides/es/net/aspose.slides.theme/fontscheme/minor/) devuelven las dos colecciones [IFonts](https://reference.aspose.com/slides/es/net/aspose.slides/ifonts/).

Llame a [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/es/net/aspose.slides/fonts/getscriptfontmap/) para obtener todos los mapeos de una colección. Para buscar un sistema de escritura, llame a [IFonts.GetScriptFont](https://reference.aspose.com/slides/es/net/aspose.slides/fonts/getscriptfont/) con su etiqueta de script. `GetScriptFont` devuelve `null` cuando esa colección no define el mapeo solicitado.

## **Modificar los mapeos y verificar la persistencia**

Utilice [IFonts.SetScriptFont](https://reference.aspose.com/slides/es/net/aspose.slides/fonts/setscriptfont/) para crear un mapeo o reemplazar la familia tipográfica actual. Utilice [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/es/net/aspose.slides/fonts/removescriptfont/) para eliminar un mapeo.

El siguiente ejemplo de extremo a extremo lee todos los mapeos principales y secundarios existentes, busca la fuente principal japonesa, cambia la fuente principal cirílica, elimina el mapeo secundario Thaana, guarda la presentación y la vuelve a abrir para verificar ambos cambios. Para que el paso de eliminación sea independiente del tema inicial, el ejemplo primero crea un mapeo Thaana solo cuando no está ya definido.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

La verificación utiliza el mismo comportamiento `null` que una búsqueda ordinaria: después de guardar la eliminación, `GetScriptFont("Thaa")` devuelve `null` para la colección secundaria.

## **Distinguir los mapeos del tema de otras configuraciones tipográficas**

Los mapeos temáticos específicos de script participan en la selección de fuentes, pero resuelven un problema diferente al formato de texto directo, sustitución y reserva:

| Mecanismo | Propósito | Efecto de cambiar un mapeo del tema |
|---|---|---|
| Mapeo de fuente temático específico de script | Selecciona una fuente de tema mayor o menor para un sistema de escritura. | El texto que sigue usando la fuente temática correspondiente puede resolverse a la nueva familia mapeada. |
| Fuente asignada explícitamente a una porción de texto | Fija la familia tipográfica solicitada en esa porción en lugar de depender del tema. | La porción puede permanecer sin cambios porque su formato directo anula la elección del tema. |
| Sustitución de fuentes | Reemplaza una fuente solicitada cuando esa fuente no está disponible o cuando se aplica una regla de sustitución. | Actúa después de que se ha solicitado una fuente; no redefinela mapeo de script del tema. |
| Reserva de fuentes | Proporciona glifos que la fuente seleccionada no contiene, a menudo para rangos Unicode específicos. | Rellena la cobertura de glifos faltantes; no modifica el mapeo del tema almacenado. |

Para obtener más información sobre los dos últimos mecanismos, consulte [Font Substitution](/slides/es/net/font-substitution/) y [Fallback Fonts](/slides/es/net/fallback-font/).

Cambiar un mapeo en [Presentation.MasterTheme](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/mastertheme/) afecta solo al contenido cuyo formato efectivo todavía depende de ese tema. El texto puede, en su lugar, heredar una sobrescritura del tema de una diapositiva maestra, de diseño o de la propia diapositiva, o usar una fuente asignada explícitamente. Inspeccione esos niveles cuando el resultado visible no siga el mapeo a nivel de presentación.

## **Hacer que las fuentes mapeadas estén disponibles y validar el resultado**

Un mapeo de script almacena el nombre de una familia tipográfica; no instala ni carga el archivo de fuente correspondiente. Para una renderización y exportación coherentes, cada fuente mapeada debe estar instalada en el entorno o ser suministrada a Aspose.Slides mediante una fuente personalizada como [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/es/net/aspose.slides/fontsloader/loadexternalfonts/) o [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/documentlevelfontsources/). Consulte [Custom Fonts](/slides/es/net/custom-font/) para conocer las opciones de carga disponibles.

Verificar el mapeo guardado solo confirma que la definición del tema se conservó. No prueba que la fuente esté disponible, que contenga todos los glifos necesarios o que produzca el diseño previsto. Renderice texto representativo para cada sistema de escritura requerido en una imagen o PDF y examine el resultado. Esto detecta fuentes faltantes, cobertura de glifos incompleta, comportamiento de reserva y cambios de diseño antes de distribuir la presentación. Consulte [Convert PowerPoint Presentations](/slides/es/net/convert-powerpoint/) para ejemplos de renderizado y exportación.

## **Preguntas frecuentes**

**¿Qué devuelve `GetScriptFont` cuando un script no está mapeado?**

[IFonts.GetScriptFont](https://reference.aspose.com/slides/es/net/aspose.slides/fonts/getscriptfont/) devuelve `null` cuando el mapeo de script solicitado no está definido en esa colección de fuentes principal o secundaria.

**¿`SetScriptFont` añade un segundo mapeo cuando el script ya existe?**

No. [IFonts.SetScriptFont](https://reference.aspose.com/slides/es/net/aspose.slides/fonts/setscriptfont/) crea el mapeo cuando falta y reemplaza la familia tipográfica mapeada cuando la misma etiqueta de script ya está presente.

**¿Por qué cambiar un mapeo del tema no modificó algún texto?**

El texto puede tener una fuente asignada explícitamente, heredar un tema diferente mediante una sobrescritura, o verse afectado por sustitución o reserva durante la renderización. Un mapeo de script a nivel de presentación controla solo el texto cuyo formato efectivo aún hace referencia a esa colección de fuentes del tema.

**¿Bastar guardar y volver a abrir para validar la salida multilingüe?**

No. Volver a abrir verifica la persistencia de los datos del tema. Además, renderice texto representativo de cada sistema de escritura requerido para confirmar que las fuentes mapeadas estén disponibles y contengan los glifos necesarios.