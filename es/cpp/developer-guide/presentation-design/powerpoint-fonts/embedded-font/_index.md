---
title: Incorporar fuentes en presentaciones con C++
linktitle: Fuentes incorporadas
type: docs
weight: 40
url: /es/cpp/embedded-font/
keywords:
- añadir fuente
- fuente incorporada
- incorporación de fuentes
- obtener fuente incorporada
- añadir fuente incorporada
- eliminar fuente incorporada
- comprimir fuente incorporada
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Gestiona fuentes incorporadas en PowerPoint con Aspose.Slides para C++. Añade, recupera, elimina y comprime fuentes para preservar la apariencia del texto y reducir el tamaño del archivo."
---
## **Introducción**

Incorporar fuentes almacena los datos de la fuente dentro de una presentación de PowerPoint. Cuando un visor admite fuentes incorporadas, puede mostrar el texto usando esas fuentes aunque no estén instaladas en el sistema de destino. Esto ayuda a preservar los saltos de línea, el espaciado del texto y el diseño de la diapositiva.

Aspose.Slides para C++ le permite obtener, añadir y eliminar fuentes incorporadas mediante el método [Presentation::get_FontsManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/get_fontsmanager/) de una [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/). También puede reducir el tamaño de los datos de fuentes incorporadas eliminando los caracteres que la presentación no utiliza.

Los ejemplos a continuación funcionan con archivos PPTX. Antes de incorporar una fuente, asegúrese de que sus datos de fuente estén disponibles para Aspose.Slides y de que su licencia permita la incorporación.

## **Obtener y eliminar fuentes incorporadas**

Utilice [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) para enumerar las fuentes almacenadas en una presentación. Para eliminar una, pase una fuente de esa lista a [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/removeembeddedfont/), y luego guarde la presentación.

El siguiente ejemplo enumera las fuentes incorporadas en `EmbeddedFonts.pptx` y elimina Calibri si está presente:
```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

Eliminar una fuente incorporada elimina sus datos de fuente almacenados; no cambia la fuente asignada al texto. Si la fuente está instalada en el sistema de destino, el texto aún puede usarla. De lo contrario, el renderizado puede requerir [sustitución de fuentes](/slides/es/cpp/font-substitution/), lo que puede afectar el diseño.

## **Inspeccionar datos de fuentes y permisos de incorporación**

Utilice la interfaz [IFontsManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/) para inspeccionar las fuentes antes de incorporarlas. Llame a [IFontsManager::GetFonts](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/getfonts/) para obtener las fuentes usadas en la presentación. Para cada fuente, pase un objeto [IFontData](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontdata/) y el valor [FontStyleType](https://reference.aspose.com/slides/es/cpp/aspose.slides/fontstyletype/) requerido a [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/getfontbytes/). El método devuelve los datos binarios de ese estilo de fuente, o `nullptr` cuando la fuente o el estilo solicitados no están disponibles. No pase un resultado `nullptr` a [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/), porque ese método requiere una matriz de bytes.

[EmbeddingLevel](https://reference.aspose.com/slides/es/cpp/aspose.slides/embeddinglevel/) es una enumeración de banderas que indica las restricciones de incorporación almacenadas en la fuente:
- `Installable` permite la incorporación y la instalación permanente en otro sistema, sujeto a la licencia de la fuente.
- `Restricted` prohíbe la incorporación a menos que se obtenga permiso del propietario legal de la fuente cuando es la única bandera de permiso de uso.
- `PreviewPrint` permite el uso temporal para visualización e impresión; un documento que contenga la fuente debe ser de solo lectura.
- `Editable` permite el uso temporal y permite que el documento sea editado y guardado.
- `NoSubsetting` es una restricción adicional que prohíbe la incorporación de solo un subconjunto de los glifos. Incorpore todos los caracteres cuando esta bandera esté presente.
- `BitmapOnly` es una restricción adicional que permite incorporar solo versiones bitmap, no datos de contorno. Si la fuente no tiene versiones bitmap, no puede incorporarse.

Los primeros cuatro valores describen el permiso de uso, mientras que `NoSubsetting` y `BitmapOnly` pueden combinarse con ellos. Verifique los modificadores con operaciones bit a bit. Dado que `Installable` es cero, enmascare los bits de permiso de uso y compare el resultado con `Installable`. Las fuentes actuales deben establecer como máximo un bit de permiso de uso. Para compatibilidad con fuentes antiguas que establezcan más de uno, el asistente a continuación selecciona el permiso menos restrictivo: `Editable`, luego `PreviewPrint`, luego `Restricted`.

El siguiente ejemplo audita los datos regular, negrita, cursiva y negrita‑cursiva disponibles para cada fuente devuelta por `GetFonts`. Omite los estilos no disponibles, fuentes restringidas, fuentes solo‑bitmap, fuentes limitadas a vista previa e impresión porque la salida sigue siendo editable, y fuentes que ya están incorporadas. Si algún estilo disponible tiene `NoSubsetting`, incorpora todos los caracteres para esa familia de fuentes.
```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Esta inspección informa de las restricciones codificadas en cada archivo de fuente. No otorga una licencia, no demuestra que haya obtenido la fuente legalmente, ni sustituye la verificación del acuerdo de licencia de la fuente antes de distribuir una copia incorporada.

## **Añadir fuentes incorporadas**

Utilice [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/addembeddedfont/) para incorporar una fuente. Sus sobrecargas aceptan ya sea un objeto [IFontData](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontdata/) o una matriz de bytes que contiene los datos de la fuente. La enumeración [EmbedFontCharacters](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/embedfontcharacters/) controla qué caracteres se incluyen:
- [All](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/embedfontcharacters/) incorpora todos los caracteres de la fuente. Use esta opción cuando los destinatarios necesiten editar la presentación e introducir texto nuevo.
- [OnlyUsed](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/embedfontcharacters/) incorpora solo los caracteres usados en la presentación para reducir el tamaño del archivo. Elija esta opción para una presentación final que está dirigida principalmente a la visualización.

El siguiente ejemplo usa [IFontsManager::GetFonts](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/getfonts/) para obtener las fuentes usadas en `Fonts.pptx` y incorpora aquellas que aún no están incorporadas. Las fuentes a añadir deben estar disponibles en la máquina que ejecuta el código. Las fuentes incorporadas existentes conservan sus conjuntos de caracteres actuales.
```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Comprimir fuentes incorporadas**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/es/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) reduce los datos de fuentes incorporadas eliminando los caracteres no usados. Funciona sobre fuentes que ya están incorporadas, por lo que la reducción de tamaño depende de cuántos datos de fuente sin usar contenga la presentación.

El siguiente ejemplo comprime las fuentes en `EmbeddedFonts.pptx` y guarda el resultado como un archivo separado:
```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Conserve el archivo original si los destinatarios pueden necesitar añadir texto más adelante. Los caracteres eliminados durante la compresión ya no están disponibles en la fuente incorporada, aun si originalmente se incorporaron todos los caracteres.

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si una fuente incorporada seguirá siendo sustituida durante el renderizado?**

Llama a [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/es/cpp/aspose.slides/ifontsmanager/getsubstitutions/) en el entorno donde renderiza la presentación para ver qué fuentes reemplazará Aspose.Slides. También compruebe la configuración de [sustitución de fuentes](/slides/es/cpp/font-substitution/) y las reglas de [fallback de fuentes](/slides/es/cpp/fallback-font/). El fallback gestiona los caracteres faltantes, por lo que incorporar una fuente no resuelve los caracteres que la propia fuente no contiene.

**¿Debo incorporar fuentes comunes como Arial y Calibri?**

Base la decisión en el entorno de destino. Si las fuentes requeridas están disponibles en cada máquina que abre o renderiza la presentación, incorporarlas puede añadir un tamaño de archivo innecesario. Si los destinatarios o servidores pueden carecer de esas fuentes, incorporarlas puede ayudar a preservar la apariencia prevista, siempre que sus licencias lo permitan.