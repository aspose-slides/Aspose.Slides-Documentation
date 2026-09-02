---
title: Administrar fuentes temáticas específicas de script en C++
linktitle: Fuentes temáticas específicas de script
type: docs
weight: 15
url: /es/cpp/script-specific-font-mappings/
keywords:
- fuente específica de script
- asignación de fuente del tema
- presentación multilingüe
- sistema de escritura
- fuente cirílica
- fuente árabe
- fuente japonesa
- fuente georgiana
- fuente thaana
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Inspeccionar, añadir, reemplazar y eliminar asignaciones de fuentes específicas de script en temas de PowerPoint con Aspose.Slides para C++."
---
## **Descripción general**

Un tema de presentación puede seleccionar diferentes familias tipográficas para distintos sistemas de escritura. Esto permite que el texto multilingüe que sigue utilizando las fuentes del tema siga un esquema tipográfico coordinado mientras emplea fuentes adecuadas para cirílico, árabe, japonés, georgiano, thaana y otros scripts.

El IFontScheme del tema contiene una colección de fuentes principal, normalmente utilizada para encabezados, y una colección de fuentes secundaria, normalmente utilizada para el cuerpo del texto. Además de sus propiedades tipográficas latinas y de Asia oriental, ambas colecciones exponen asignaciones de etiquetas de sistemas de escritura a nombres de familias tipográficas a través de la interfaz IFonts.

Este artículo muestra cómo inspeccionar y modificar esas asignaciones en el tema maestro de la presentación y verificar que los cambios sobrevivan a un ciclo de guardar y volver a cargar.

## **Comprender las etiquetas de script**

Los métodos de fuentes de script utilizan subtags de script BCP 47 de cuatro letras para identificar los sistemas de escritura. Los valores más habituales son:

| Etiqueta de script | Sistema de escritura |
|---|---|
| `Cyrl` | Cirílico |
| `Arab` | Árabe |
| `Hans` | Chino simplificado |
| `Jpan` | Japonés |
| `Geor` | Georgiano |
| `Thaa` | Thaana |

Estas asignaciones pertenecen al esquema de fuentes del tema, no a porciones de texto individuales. Una presentación puede definir asignaciones diferentes para las colecciones principal y secundaria, y puede omitir asignaciones para algunos scripts.

## **Acceder e inspeccionar las asignaciones de fuentes de script**

Utilice [Presentation::get_MasterTheme](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_mastertheme/) para acceder al tema a nivel de presentación. Los métodos [FontScheme::get_Major](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/fontscheme/get_major/) y [FontScheme::get_Minor](https://reference.aspose.com/slides/es/cpp/aspose.slides.theme/fontscheme/get_minor/) devuelven las dos colecciones IFonts.

Llame a [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/es/cpp/aspose.slides/fonts/getscriptfontmap/) para obtener todas las asignaciones de una colección. Para buscar un sistema de escritura concreto, llame a [Fonts::GetScriptFont](https://reference.aspose.com/slides/es/cpp/aspose.slides/fonts/getscriptfont/) con su etiqueta de script. `GetScriptFont` devuelve una cadena nula cuando esa colección no define la asignación solicitada.

## **Modificar asignaciones y verificar persistencia**

Utilice [Fonts::SetScriptFont](https://reference.aspose.com/slides/es/cpp/aspose.slides/fonts/setscriptfont/) para crear una asignación o sustituir la familia tipográfica actual. Utilice [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/es/cpp/aspose.slides/fonts/removescriptfont/) para eliminar una asignación.

El siguiente ejemplo completo lee todas las asignaciones principales y secundarias existentes, busca la fuente principal japonesa, cambia la fuente principal cirílica, elimina la asignación secundaria de Thaana, guarda la presentación y la vuelve a abrir para verificar ambos cambios. Para que el paso de eliminación sea independiente del tema inicial, el ejemplo crea una asignación de Thaana solo cuando aún no está definida.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

La verificación usa el mismo comportamiento de cadena nula que una búsqueda ordinaria: tras guardar la eliminación, `GetScriptFont(u"Thaa")` devuelve una cadena nula para la colección secundaria.

## **Distinguir las asignaciones del tema de otros ajustes de fuentes**

Las asignaciones de tema específicas de script participan en la selección de fuentes, pero resuelven un problema distinto al formato de texto directo, la sustitución y el respaldo:

| Mecanismo | Propósito | Efecto de cambiar una asignación del tema |
|---|---|---|
| Asignación de fuente del tema específica de script | Selecciona una fuente de tema mayor o menor para un sistema de escritura. | El texto que sigue usando la fuente del tema correspondiente puede resolverse a la nueva familia asignada. |
| Fuente asignada explícitamente a una porción de texto | Fija la familia tipográfica solicitada en esa porción en lugar de depender del tema. | La porción puede permanecer sin cambios porque su formato directo anula la elección del tema. |
| Sustitución de fuentes | Reemplaza una fuente solicitada cuando esa fuente no está disponible o cuando se aplica una regla de sustitución. | Actúa después de que se ha solicitado una fuente; no redefine la asignación de script del tema. |
| Fuente de respaldo | Proporciona glifos que la fuente seleccionada no contiene, a menudo para rangos Unicode específicos. | Rellena la cobertura de glifos faltante; no cambia la asignación de tema almacenada. |

Para obtener más información sobre los dos últimos mecanismos, consulte [Sustitución de fuentes](/slides/es/cpp/font-substitution/) y [Fuentes de respaldo](/slides/es/cpp/fallback-font/).

Cambiar una asignación en [Presentation::get_MasterTheme](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_mastertheme/) afecta solo al contenido cuyo formato efectivo sigue dependiendo de ese tema. El texto puede, en su lugar, heredar una anulación de tema de una diapositiva maestra, de diseño o de la propia diapositiva, o usar una fuente asignada explícitamente. Inspeccione esos niveles cuando el resultado visible no siga la asignación a nivel de presentación.

## **Hacer que las fuentes asignadas estén disponibles y validar el resultado**

Una asignación de script almacena un nombre de familia tipográfica; no instala ni carga el archivo de fuente correspondiente. Para una renderización y exportación coherentes, cada fuente asignada debe estar instalada en el entorno o proporcionada a Aspose.Slides mediante una fuente personalizada, como [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontsloader/loadexternalfonts/) o [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/). Consulte [Fuentes personalizadas](/slides/es/cpp/custom-font/) para conocer las opciones de carga disponibles.

Verificar la asignación guardada solo confirma que la definición del tema se preservó. No prueba que la fuente esté disponible, que contenga todos los glifos requeridos o que produzca el diseño previsto. Renderice texto representativo para cada sistema de escritura necesario en una imagen o PDF y examine la salida. Así detectará fuentes ausentes, cobertura de glifos incompleta, comportamiento de respaldo y cambios de diseño antes de distribuir la presentación. Consulte [Convertir presentaciones de PowerPoint](/slides/es/cpp/convert-powerpoint/) para ejemplos de renderizado y exportación.

## **Preguntas frecuentes**

**¿Qué devuelve `GetScriptFont` cuando un script no está asignado?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/es/cpp/aspose.slides/fonts/getscriptfont/) devuelve una cadena nula cuando la asignación de script solicitada no está definida en esa colección de fuentes mayor o menor.

**¿`SetScriptFont` añade una segunda asignación cuando el script ya existe?**

No. [Fonts::SetScriptFont](https://reference.aspose.com/slides/es/cpp/aspose.slides/fonts/setscriptfont/) crea la asignación cuando falta y sustituye la familia tipográfica asignada cuando la misma etiqueta de script ya está presente.

**¿Por qué al cambiar una asignación del tema no se modificó algún texto?**

El texto puede tener una fuente asignada explícitamente, heredar un tema distinto mediante una anulación o verse afectado por sustitución o respaldo durante la renderización. Una asignación de script a nivel de presentación controla solo el texto cuyo formato efectivo todavía hace referencia a esa colección de fuentes del tema.

**¿Bastar guardar y volver a abrir para validar la salida multilingüe?**

No. Volver a abrir verifica la persistencia de los datos del tema. Además, renderice texto representativo de cada sistema de escritura requerido para confirmar que las fuentes asignadas están disponibles y contienen los glifos necesarios.