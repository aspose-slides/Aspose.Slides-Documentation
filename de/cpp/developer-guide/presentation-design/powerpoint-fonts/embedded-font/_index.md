---
title: "Schriftarten in Präsentationen in C++ einbetten"
linktitle: "Eingebettete Schriftarten"
type: docs
weight: 40
url: /de/cpp/embedded-font/
keywords:
- "Schrift hinzufügen"
- "Schriftart einbetten"
- "Schriftart-Einbettung"
- "Eingebettete Schriftart abrufen"
- "Eingebettete Schriftart hinzufügen"
- "Eingebettete Schriftart entfernen"
- "Eingebettete Schriftart komprimieren"
- "PowerPoint"
- "Präsentation"
- "C++"
- "Aspose.Slides"
description: "Verwalten Sie eingebettete Schriftarten in PowerPoint mit Aspose.Slides für C++. Fügen Sie Schriftarten hinzu, rufen Sie sie ab, entfernen und komprimieren Sie sie, um das Erscheinungsbild des Textes zu erhalten und die Dateigröße zu reduzieren."
---
## **Einführung**

Das Einbetten von Schriftarten speichert Schriftartdaten in einer PowerPoint-Präsentation. Wenn ein Betrachter eingebettete Schriftarten unterstützt, kann er Text mit diesen Schriftarten anzeigen, selbst wenn sie nicht auf dem Zielsystem installiert sind. Dies hilft, Zeilenumbrüche, Textabstände und das Folienlayout beizubehalten.

Aspose.Slides for C++ ermöglicht das Abrufen, Hinzufügen und Entfernen eingebetteter Schriftarten über die [Presentation::get_FontsManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/get_fontsmanager/) Methode einer [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/). Sie können die Größe eingebetteter Schriftartdaten auch reduzieren, indem Sie Zeichen entfernen, die in der Präsentation nicht verwendet werden.

Die nachfolgenden Beispiele arbeiten mit PPTX-Dateien. Vor dem Einbetten einer Schriftart stellen Sie sicher, dass deren Schriftartdaten für Aspose.Slides verfügbar sind und die Lizenz das Einbetten erlaubt.

## **Abrufen und Entfernen eingebetteter Schriftarten**

Verwenden Sie [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) um die in einer Präsentation gespeicherten Schriftarten aufzulisten. Um eine zu entfernen, übergeben Sie eine Schriftart aus dieser Liste an [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/removeembeddedfont/) und speichern anschließend die Präsentation.

Das folgende Beispiel listet die eingebetteten Schriftarten in `EmbeddedFonts.pptx` auf und entfernt Calibri, falls sie vorhanden ist:

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

Das Entfernen einer eingebetteten Schriftart löscht deren gespeicherte Schriftartdaten; es ändert nicht die dem Text zugewiesene Schriftart. Ist die Schriftart auf dem Zielsystem installiert, kann der Text sie weiterhin verwenden. Andernfalls kann die Darstellung eine [font substitution](/slides/de/cpp/font-substitution/) erfordern, was das Layout beeinträchtigen kann.

## **Untersuchen von Schriftartdaten und Einbettungsberechtigungen**

Verwenden Sie die [IFontsManager](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/) Schnittstelle, um Schriftarten vor dem Einbetten zu prüfen. Rufen Sie [IFontsManager::GetFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/getfonts/) auf, um die in der Präsentation verwendeten Schriftarten zu erhalten. Für jede Schriftart übergeben Sie ein [IFontData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontdata/) Objekt und den erforderlichen [FontStyleType](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontstyletype/) Wert an [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/getfontbytes/). Die Methode liefert die Binärdaten für diesen Schriftschnitt zurück oder `nullptr`, wenn die angeforderte Schriftart oder der Stil nicht verfügbar ist. Übergeben Sie das Ergebnis `nullptr` nicht an [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/), da diese Methode ein Byte‑Array erwartet.

[EmbeddingLevel](https://reference.aspose.com/slides/de/cpp/aspose.slides/embeddinglevel/) ist eine Aufzählung mit Flags, die die im Schriftart gespeicherten Einbettungsbeschränkungen angibt:

- `Installable` erlaubt das Einbetten und die permanente Installation auf einem anderen System, vorbehaltlich der Lizenz der Schriftart.
- `Restricted` verbietet das Einbetten, es sei denn, die Erlaubnis des rechtlichen Eigentümers der Schriftart wird eingeholt, wenn es das einzige Nutzungsberechtigung‑Flag ist.
- `PreviewPrint` erlaubt die temporäre Nutzung zum Anzeigen und Drucken; ein Dokument, das die Schriftart enthält, muss schreibgeschützt sein.
- `Editable` erlaubt die temporäre Nutzung und ermöglicht das Bearbeiten und Speichern des Dokuments.
- `NoSubsetting` ist eine zusätzliche Beschränkung, die das Einbetten nur eines Teilbereichs der Glyphen verbietet. Betten Sie alle Zeichen ein, wenn dieses Flag gesetzt ist.
- `BitmapOnly` ist eine zusätzliche Beschränkung, die nur das Einbetten von Bitmap‑Schriftschnitten erlaubt, nicht jedoch von Konturdaten. Wenn die Schriftart keine Bitmap‑Schriftschnitte besitzt, kann sie nicht eingebettet werden.

Die ersten vier Werte beschreiben die Nutzungsberechtigung, während `NoSubsetting` und `BitmapOnly` mit ihnen kombiniert werden können. Prüfen Sie die Modifikatoren mittels bitweiser Operationen. Da `Installable` den Wert null hat, maskieren Sie die Nutzungs‑Berechtigungs‑Bits und vergleichen das Ergebnis mit `Installable`. Aktuelle Schriftarten sollten höchstens ein Nutzungs‑Berechtigungs‑Bit setzen. Zur Kompatibilität mit älteren Schriftarten, die mehr als eines setzen, wählt die untenstehende Hilfsfunktion die am wenigsten restriktive Berechtigung aus: `Editable`, dann `PreviewPrint`, dann `Restricted`.

Das folgende Beispiel prüft die regulären, fetten, kursiven und fett‑kursiven Daten, die für jede von `GetFonts` zurückgegebene Schriftart verfügbar sind. Es überspringt nicht verfügbare Stile, eingeschränkte Schriftarten, ausschließlich bitmap‑basierte Schriftarten, Schriftarten, die nur für Vorschau und Druck beschränkt sind, weil die Ausgabe editierbar bleibt, sowie bereits eingebettete Schriftarten. Hat ein verfügbarer Stil das Flag `NoSubsetting`, werden alle Zeichen für diese Schriftfamilie eingebettet.

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

Diese Überprüfung gibt die in jeder Schriftdatei codierten Beschränkungen aus. Sie gewährt keine Lizenz, beweist nicht, dass Sie die Schriftart legal erworben haben, und ersetzt nicht die Prüfung der Lizenzvereinbarung der Schriftart, bevor Sie eine eingebettete Kopie verteilen.

## **Hinzufügen eingebetteter Schriftarten**

Verwenden Sie [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/addembeddedfont/), um eine Schriftart einzubetten. Die Überladungen akzeptieren entweder ein [IFontData](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontdata/) Objekt oder ein Byte‑Array, das die Schriftardaten enthält. Die Aufzählung [EmbedFontCharacters](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/embedfontcharacters/) bestimmt, welche Zeichen eingeschlossen werden:

- [All](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/embedfontcharacters/) bettet alle Zeichen der Schriftart ein. Verwenden Sie diese Option, wenn Empfänger die Präsentation bearbeiten und neuen Text eingeben müssen.
- [OnlyUsed](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/embedfontcharacters/) bettet nur die in der Präsentation verwendeten Zeichen ein, um die Dateigröße zu reduzieren. Wählen Sie diese Option für eine fertige Präsentation, die hauptsächlich zum Anzeigen gedacht ist.

Das folgende Beispiel verwendet [IFontsManager::GetFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/getfonts/), um die in `Fonts.pptx` verwendeten Schriftarten zu erhalten und bettet jene ein, die noch nicht eingebettet sind. Die hinzuzufügenden Schriftarten müssen auf dem ausführenden Rechner verfügbar sein. Bereits eingebettete Schriftarten behalten ihren aktuellen Zeichensatz bei.

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

## **Komprimieren eingebetteter Schriftarten**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/de/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) reduziert eingebettete Schriftartdaten, indem nicht verwendete Zeichen entfernt werden. Sie arbeitet mit bereits eingebetteten Schriftarten, sodass die Größenreduktion vom Umfang der nicht genutzten Schriftartdaten in der Präsentation abhängt.

Das folgende Beispiel komprimiert die Schriftarten in `EmbeddedFonts.pptx` und speichert das Ergebnis als separate Datei:

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

Bewahren Sie die Originaldatei auf, falls Empfänger später Text hinzufügen müssen. Während der Komprimierung entfernte Zeichen stehen aus der eingebetteten Schriftart nicht mehr zur Verfügung, selbst wenn Sie ursprünglich alle Zeichen eingebettet haben.

## **FAQ**

**Wie kann ich überprüfen, ob eine eingebettete Schriftart bei der Darstellung noch substituiert wird?**

Rufen Sie [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/de/cpp/aspose.slides/ifontsmanager/getsubstitutions/) in der Umgebung auf, in der Sie die Präsentation rendern, um zu sehen, welche Schriftarten Aspose.Slides ersetzen wird. Prüfen Sie außerdem die Einstellungen für [font substitution](/slides/de/cpp/font-substitution/) und die Regeln für [font fallback](/slides/de/cpp/fallback-font/). Fallback behandelt fehlende Zeichen, sodass das Einbetten einer Schriftart Zeichen, die die Schriftart selbst nicht enthält, nicht löst.

**Sollte ich gängige Schriftarten wie Arial und Calibri einbetten?**

Treffen Sie die Entscheidung basierend auf der Zielumgebung. Sind die benötigten Schriftarten auf jedem Rechner, der die Präsentation öffnet oder rendert, verfügbar, kann das Einbetten zu unnötiger Dateigröße führen. Wenn Empfänger oder Server diese Schriftarten möglicherweise nicht haben, kann das Einbetten helfen, das beabsichtigte Erscheinungsbild zu bewahren, vorausgesetzt, ihre Lizenzen erlauben es.