---
title: Schriften in Präsentationen in .NET einbetten
linktitle: Eingebettete Schriften
type: docs
weight: 40
url: /de/net/embedded-font/
keywords:
- Schrift hinzufügen
- Schrift einbetten
- Schrifteinbettung
- Eingebettete Schrift abrufen
- Eingebettete Schrift hinzufügen
- Eingebettete Schrift entfernen
- Eingebettete Schrift komprimieren
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie eingebettete Schriften in PowerPoint mit Aspose.Slides für .NET. Verwenden Sie C#, um Schriften hinzuzufügen, abzurufen, zu entfernen und zu komprimieren, um das Aussehen des Textes beizubehalten und die Dateigröße zu reduzieren."
---
## **Einleitung**

Einbetten von Schriften speichert Schriftartdaten innerhalb einer PowerPoint‑Präsentation. Wenn ein Betrachter eingebettete Schriften unterstützt, kann er den Text mit diesen Schriften anzeigen, selbst wenn sie nicht auf dem Zielsystem installiert sind. Das hilft, Zeilenumbrüche, Textabstände und das Folienlayout beizubehalten.

Aspose.Slides for .NET ermöglicht das Abrufen, Hinzufügen und Entfernen eingebetteter Schriften über die [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/)-Eigenschaft einer [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Sie können die Größe der eingebetteten Schriftartdaten auch reduzieren, indem Sie Zeichen entfernen, die von der Präsentation nicht verwendet werden.

Die folgenden Beispiele arbeiten mit PPTX‑Dateien. Vor dem Einbetten einer Schriftart stellen Sie sicher, dass deren Schriftartdaten für Aspose.Slides verfügbar sind und die Lizenz das Einbetten zulässt.

## **Abrufen und Entfernen eingebetteter Schriften**

Verwenden Sie [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/), um die in einer Präsentation gespeicherten Schriften aufzulisten. Um eine zu entfernen, übergeben Sie eine Schrift aus dieser Liste an [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/), und speichern Sie anschließend die Präsentation.

Das folgende Beispiel listet die eingebetteten Schriften in `EmbeddedFonts.pptx` auf und entfernt Calibri, falls sie vorhanden ist:

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

Das Entfernen einer eingebetteten Schrift entfernt deren gespeicherte Schriftartdaten; es ändert nicht die dem Text zugewiesene Schrift. Ist die Schrift auf dem Zielsystem installiert, kann der Text sie weiterhin verwenden. Andernfalls kann die Wiedergabe [Schriftersatz](/slides/de/net/font-substitution/) erfordern, was das Layout beeinflussen kann.

## **Schriftartdaten und Einbettungsberechtigungen prüfen**

Verwenden Sie die [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/)-Schnittstelle, um Schriften vor dem Einbetten zu prüfen. Rufen Sie [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) auf, um die in der Präsentation verwendeten Schriften zu erhalten. Für jede Schrift übergeben Sie ein [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/)-Objekt und den erforderlichen [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/)-Wert an [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/). Die Methode liefert die Binärdaten für diesen Schriftstil zurück oder `null`, wenn die angeforderte Schrift oder der Stil nicht verfügbar ist. Übergeben Sie kein `null`‑Ergebnis an [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), da diese Methode ein Byte‑Array erwartet.

`[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/)` ist eine Aufzählung von Flags, die die im Font gespeicherten Einbettungsbeschränkungen meldet:

- `Installable` erlaubt das Einbetten und die permanente Installation auf einem anderen System, vorbehaltlich der Schriftlizenz.
- `Restricted` verbietet das Einbetten, es sei denn, es wird die Erlaubnis des rechtlichen Eigentümers der Schriftart eingeholt, wenn es das einzige Nutzungsberechtigungs‑Flag ist.
- `PreviewPrint` erlaubt temporäre Nutzung zum Anzeigen und Drucken; ein Dokument, das die Schrift enthält, muss schreibgeschützt sein.
- `Editable` erlaubt temporäre Nutzung und ermöglicht das Bearbeiten und Speichern des Dokuments.
- `NoSubsetting` ist eine zusätzliche Beschränkung, die das Einbetten nur eines Teilsets der Glyphen untersagt. Betten Sie alle Zeichen ein, wenn dieses Flag gesetzt ist.
- `BitmapOnly` ist eine zusätzliche Beschränkung, die nur das Einbetten von Bitmap‑Strichen erlaubt, nicht von Kontur‑Daten. Hat die Schrift keine Bitmap‑Striche, kann sie nicht eingebettet werden.

Die ersten vier Werte beschreiben die Nutzungserlaubnis, während `NoSubsetting` und `BitmapOnly` mit ihnen kombiniert werden können. Prüfen Sie die Modifikatoren mittels bitweiser Operationen. Da `Installable` den Wert null hat, verwenden Sie nicht `HasFlag`, um es zu erkennen; maskieren Sie die Nutzungserlaubnis‑Bits und vergleichen Sie das Ergebnis mit `Installable`. Aktuelle Schriften sollten höchstens ein Nutzungserlaubnis‑Bit setzen. Für die Kompatibilität mit älteren Schriften, die mehr als ein Bit setzen, wählt die untenstehende Hilfsfunktion die am wenigsten restriktive Berechtigung aus: `Editable`, dann `PreviewPrint`, dann `Restricted`.

Das folgende Beispiel prüft die regulären, fett‑, kursiv‑ und fett‑kursiv‑Daten, die für jede von `GetFonts` zurückgegebene Schrift verfügbar sind. Es überspringt nicht verfügbare Stile, eingeschränkte Schriften, ausschließlich bitmap‑basierte Schriften, Schriften, die nur für Vorschau und Druck vorgesehen sind, weil die Ausgabe editierbar bleibt, sowie bereits eingebettete Schriften. Hat ein verfügbarer Stil das Flag `NoSubsetting`, werden alle Zeichen für diese Schriftfamilie eingebettet.

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

Diese Prüfung meldet die in jeder Schriftdatei kodierten Beschränkungen. Sie gewährt keine Lizenz, beweist nicht, dass Sie die Schrift legal erworben haben, und ersetzt nicht die Überprüfung der Lizenzvereinbarung der Schrift, bevor Sie eine eingebettete Kopie verbreiten.

## **Eingebettete Schriften hinzufügen**

Verwenden Sie [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/), um eine Schrift einzubetten. Die Überladungen akzeptieren entweder ein [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/)-Objekt oder ein Byte‑Array, das die Schriftartdaten enthält. Die [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/)-Aufzählung bestimmt, welche Zeichen eingeschlossen werden:

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) bettet alle Zeichen der Schrift ein. Verwenden Sie diese Option, wenn Empfänger die Präsentation bearbeiten und neuen Text eingeben müssen.
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) bettet nur die in der Präsentation verwendeten Zeichen ein, um die Dateigröße zu reduzieren. Wählen Sie diese Option für eine fertige Präsentation, die hauptsächlich zum Anzeigen gedacht ist.

Das folgende Beispiel verwendet [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/), um die in `Fonts.pptx` verwendeten Schriften zu ermitteln und bettet diejenigen ein, die noch nicht eingebettet sind. Die hinzuzufügenden Schriften müssen auf dem Rechner, auf dem der Code ausgeführt wird, verfügbar sein. Vorhandene eingebettete Schriften behalten ihre aktuellen Zeichensätze bei.

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

## **Eingebettete Schriften komprimieren**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) reduziert eingebettete Schriftartdaten, indem nicht verwendete Zeichen entfernt werden. Sie arbeitet an bereits eingebetteten Schriften, sodass die Größenreduktion davon abhängt, wie viele ungenutzte Schriftartdaten die Präsentation enthält.

Das folgende Beispiel komprimiert die Schriften in `EmbeddedFonts.pptx` und speichert das Ergebnis als separate Datei:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Behalten Sie die Originaldatei, falls Empfänger später Text hinzufügen müssen. Während der Kompression entfernte Zeichen stehen in der eingebetteten Schrift nicht mehr zur Verfügung, selbst wenn Sie ursprünglich alle Zeichen eingebettet haben.

Um einer passenden registrierten Schrift während des Exports Vorrang zu geben, ohne die eingebettete Schrift zu entfernen, siehe [Bevorzugen registrierter Schriften gegenüber eingebetteten Schriften](/slides/de/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 oder später).

## **FAQ**

**Wie kann ich prüfen, ob eine eingebettete Schriftart beim Rendern noch ersetzt wird?**

Rufen Sie [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) in der Umgebung auf, in der Sie die Präsentation rendern, um zu sehen, welche Schriften Aspose.Slides ersetzen wird. Prüfen Sie zudem die Einstellungen für [Schriftersatz](/slides/de/net/font-substitution/) und die Regeln für [Schriftfallback](/slides/de/net/fallback-font/). Fallback behandelt fehlende Zeichen, sodass das Einbetten einer Schrift nicht die Zeichen löst, die die Schrift selbst nicht enthält.

**Sollte ich gängige Schriften wie Arial und Calibri einbetten?**

Treffen Sie die Entscheidung basierend auf der Zielumgebung. Sind die erforderlichen Schriften auf jedem Gerät, das die Präsentation öffnet oder rendert, verfügbar, kann das Einbetten zu unnötiger Dateigröße führen. Fehlen die Schriften jedoch bei Empfängern oder Servern, kann das Einbetten helfen, das beabsichtigte Erscheinungsbild zu erhalten, sofern ihre Lizenzen dies zulassen.