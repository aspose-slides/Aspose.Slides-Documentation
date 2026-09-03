---
title: "Einbetten von Schriftarten in Präsentationen in .NET"
linktitle: "Eingebettete Schriftarten"
type: docs
weight: 40
url: /de/net/embedded-font/
keywords:
- Schriftart hinzufügen
- Schriftart einbetten
- Schriftarteinbettung
- eingebettete Schriftart abrufen
- eingebettete Schriftart hinzufügen
- eingebettete Schriftart entfernen
- eingebettete Schriftart komprimieren
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie eingebettete Schriftarten in PowerPoint mit Aspose.Slides für .NET. Verwenden Sie C#, um Schriftarten hinzuzufügen, abzurufen, zu entfernen und zu komprimieren, um das Erscheinungsbild des Textes beizubehalten und die Dateigröße zu reduzieren."
---
## **Einführung**

Das Einbetten von Schriftarten speichert Schriftartdaten innerhalb einer PowerPoint‑Präsentation. Wenn ein Betrachter eingebettete Schriftarten unterstützt, kann er Text mit diesen Schriftarten anzeigen, selbst wenn sie nicht auf dem Zielsystem installiert sind. Dies hilft, Zeilenumbrüche, Textabstände und das Folienlayout beizubehalten.

Aspose.Slides für .NET ermöglicht das Abrufen, Hinzufügen und Entfernen eingebetteter Schriftarten über die [FontsManager](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/fontsmanager/)‑Eigenschaft einer [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/). Sie können die Größe der eingebetteten Schriftartdaten auch reduzieren, indem Sie Zeichen entfernen, die die Präsentation nicht verwendet.

Die nachstehenden Beispiele arbeiten mit PPTX‑Dateien. Stellen Sie vor dem Einbetten einer Schriftart sicher, dass deren Schriftartdaten für Aspose.Slides verfügbar sind und die Lizenz das Einbetten zulässt.

## **Abrufen und Entfernen eingebetteter Schriftarten**

Verwenden Sie [GetEmbeddedFonts](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/getembeddedfonts/), um die in einer Präsentation gespeicherten Schriftarten aufzulisten. Um eine zu entfernen, übergeben Sie eine Schriftart aus dieser Liste an [RemoveEmbeddedFont](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/removeembeddedfont/), und speichern Sie anschließend die Präsentation.

Das folgende Beispiel listet die eingebetteten Schriftarten in `EmbeddedFonts.pptx` auf und entfernt Calibri, falls sie vorhanden ist:
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

Das Entfernen einer eingebetteten Schriftart löscht deren gespeicherte Schriftartdaten; sie ändert nicht die dem Text zugewiesene Schriftart. Ist die Schriftart auf dem Zielsystem installiert, kann der Text sie weiterhin verwenden. Andernfalls kann beim Rendern eine [Schriftart-Substitution](/slides/de/net/font-substitution/) erforderlich sein, was das Layout beeinflussen kann.

## **Untersuchen von Schriftartdaten und Einbettungsrechten**

Verwenden Sie das [IFontsManager](https://reference.aspose.com/slides/de/net/aspose.slides/ifontsmanager/)‑Interface, um Schriftarten vor dem Einbetten zu untersuchen. Rufen Sie [IFontsManager.GetFonts](https://reference.aspose.com/slides/de/net/aspose.slides/ifontsmanager/getfonts/) auf, um die in der Präsentation verwendeten Schriftarten abzurufen. Für jede Schriftart übergeben Sie ein [IFontData](https://reference.aspose.com/slides/de/net/aspose.slides/ifontdata/)-Objekt und den erforderlichen [FontStyleType](https://reference.aspose.com/slides/de/net/aspose.slides/fontstyletype/)-Wert an [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/de/net/aspose.slides/ifontsmanager/getfontbytes/). Die Methode gibt die Binärdaten für diesen Schriftstil zurück oder `null`, wenn die angeforderte Schriftart oder der Stil nicht verfügbar ist. Übergeben Sie kein `null`‑Ergebnis an [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/de/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), da diese Methode ein Byte‑Array erwartet.

[EmbeddingLevel](https://reference.aspose.com/slides/de/net/aspose.slides/embeddinglevel/) ist eine Flag‑Aufzählung, die die im Font gespeicherten Einbettungsbeschränkungen meldet:

- `Installable` erlaubt das Einbetten und die dauerhafte Installation auf einem anderen System, vorbehaltlich der Font‑Lizenz.
- `Restricted` verbietet das Einbetten, es sei denn, es wird eine Erlaubnis vom rechtlichen Eigentümer der Schriftart eingeholt, wenn es das einzige Nutzungs‑Erlaubnis‑Flag ist.
- `PreviewPrint` erlaubt die temporäre Nutzung zum Anzeigen und Drucken; ein Dokument, das die Schriftart enthält, muss schreibgeschützt sein.
- `Editable` erlaubt die temporäre Nutzung und gestattet das Bearbeiten und Speichern des Dokuments.
- `NoSubsetting` ist eine zusätzliche Beschränkung, die das Einbetten nur eines Teilbereichs der Glyphen untersagt. Betten Sie alle Zeichen ein, wenn dieses Flag gesetzt ist.
- `BitmapOnly` ist eine zusätzliche Beschränkung, die nur das Einbetten von Bitmap‑Strichen erlaubt, nicht von Konturdaten. Hat die Schriftart keine Bitmap‑Striche, kann sie nicht eingebettet werden.

Die ersten vier Werte beschreiben die Nutzungsberechtigung, während `NoSubsetting` und `BitmapOnly` mit ihnen kombiniert werden können. Prüfen Sie die Modifikatoren mit bitweisen Operationen. Da `Installable` null ist, verwenden Sie `HasFlag` nicht, um es zu erkennen; maskieren Sie die Bits der Nutzungsberechtigung und vergleichen Sie das Ergebnis mit `Installable`. Aktuelle Schriftarten sollten höchstens ein Nutzungs‑Berechtigungs‑Bit setzen. Zur Kompatibilität mit älteren Schriftarten, die mehr als eines setzen, wählt die untenstehende Hilfsfunktion die am wenigsten restriktive Berechtigung: `Editable`, dann `PreviewPrint`, dann `Restricted`.

Das folgende Beispiel prüft die regulären, fett, kursiv und fett‑kursiv Daten, die für jede durch `GetFonts` zurückgegebene Schriftart verfügbar sind. Es überspringt nicht verfügbare Stile, eingeschränkte Schriftarten, ausschließlich Bitmap‑Schriftarten, Schriftarten, die nur für Vorschau und Druck gedacht sind, da die Ausgabe editierbar bleibt, und bereits eingebettete Schriftarten. Wenn ein verfügbarer Stil `NoSubsetting` aufweist, bettet es alle Zeichen für diese Schriftfamilie ein.
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

Diese Untersuchung meldet die in jeder Schriftdatei kodierten Beschränkungen. Sie gewährt keine Lizenz, beweist nicht, dass Sie die Schriftart legal erworben haben, und ersetzt nicht die Prüfung der Lizenzvereinbarung der Schriftart, bevor Sie eine eingebettete Kopie verbreiten.

## **Hinzufügen eingebetteter Schriftarten**

Verwenden Sie [AddEmbeddedFont](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/addembeddedfont/), um eine Schriftart einzubetten. Die Überladungen akzeptieren entweder ein [IFontData](https://reference.aspose.com/slides/de/net/aspose.slides/ifontdata/)‑Objekt oder ein Byte‑Array, das die Schriftartdaten enthält. Die Aufzählung [EmbedFontCharacters](https://reference.aspose.com/slides/de/net/aspose.slides.export/embedfontcharacters/) bestimmt, welche Zeichen eingeschlossen werden:

- `All` bettet alle Zeichen der Schriftart ein. Verwenden Sie diese Option, wenn Empfänger die Präsentation bearbeiten und neuen Text eingeben sollen.
- `OnlyUsed` bettet nur die in der Präsentation verwendeten Zeichen ein, um die Dateigröße zu reduzieren. Wählen Sie diese Option für eine fertige Präsentation, die hauptsächlich zum Anzeigen bestimmt ist.

Das folgende Beispiel verwendet [GetFonts](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/getfonts/), um die in `Fonts.pptx` verwendeten Schriftarten abzurufen und bettet jene ein, die noch nicht eingebettet sind. Die hinzuzufügenden Schriftarten müssen auf dem ausführenden Rechner verfügbar sein. Vorhandene eingebettete Schriftarten behalten ihre aktuellen Zeichensätze bei.
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

## **Komprimieren eingebetteter Schriftarten**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/de/net/aspose.slides.lowcode/compress/compressembeddedfonts/) reduziert die eingebetteten Schriftartdaten, indem nicht verwendete Zeichen entfernt werden. Es wirkt auf bereits eingebettete Schriftarten, sodass die Größenreduktion vom Umfang der nicht genutzten Schriftartdaten in der Präsentation abhängt.

Das folgende Beispiel komprimiert die Schriftarten in `EmbeddedFonts.pptx` und speichert das Ergebnis als separate Datei:
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Bewahren Sie die Originaldatei auf, falls Empfänger später Text hinzufügen müssen. Während der Komprimierung entfernte Zeichen stehen aus der eingebetteten Schriftart nicht mehr zur Verfügung, selbst wenn Sie ursprünglich alle Zeichen eingebettet hatten.

## **FAQ**

**Wie kann ich prüfen, ob eine eingebettete Schriftart beim Rendern noch substituiert wird?**

Rufen Sie [GetSubstitutions](https://reference.aspose.com/slides/de/net/aspose.slides/fontsmanager/getsubstitutions/) in der Umgebung auf, in der Sie die Präsentation rendern, um zu sehen, welche Schriftarten Aspose.Slides ersetzen wird. Prüfen Sie außerdem die Einstellungen zur [Schriftart-Substitution](/slides/de/net/font-substitution/) und die Regeln zum [Schriftfallback](/slides/de/net/fallback-font/). Fallback behandelt fehlende Zeichen, sodass das Einbetten einer Schriftart nicht die Zeichen löst, die die Schriftart selbst nicht enthält.

**Sollte ich gängige Schriftarten wie Arial und Calibri einbetten?**

Treffen Sie die Entscheidung basierend auf der Zielumgebung. Sind die benötigten Schriftarten auf jedem Computer, der die Präsentation öffnet oder rendert, verfügbar, kann das Einbetten zu unnötiger Dateigröße führen. Fehlen die Schriftarten bei Empfängern oder Servern, kann das Einbetten helfen, das gewünschte Erscheinungsbild zu erhalten, vorausgesetzt, die Lizenzen erlauben es.