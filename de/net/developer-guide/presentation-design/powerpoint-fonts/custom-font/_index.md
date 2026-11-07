---
title: PowerPoint-Schriften in .NET anpassen
linktitle: Benutzerdefinierte Schrift
type: docs
weight: 20
url: /de/net/custom-font/
keywords:
- Schrift
- benutzerdefinierte Schrift
- externe Schrift
- Schrift laden
- Schriften verwalten
- Schriftordner
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Passen Sie Schriften in PowerPoint‑Folien mit Aspose.Slides für .NET an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, benutzerdefinierte Schriften in Präsentationen zu verwenden, ohne sie im Betriebssystem zu installieren. Sie können Schriften aus benutzerdefinierten Ordnern laden, Schriften für eine bestimmte Präsentation über dokumentenbezogene Schriftquellen bereitstellen oder externe Schriften direkt aus Binärdaten laden.

Geladene Schriften werden verwendet, wenn eine Präsentation gerendert oder exportiert wird, beispielsweise zu PDF, Bildern und anderen unterstützten Formaten. Dies trägt dazu bei, die Ausgabe der Präsentation in verschiedenen Umgebungen konsistent zu halten. Der Artikel erklärt außerdem, wie Sie die von Aspose.Slides verwendeten Schriftordner inspizieren und wie Sie den Schrift-Cache nach der Arbeit mit externen Schriften leeren können.

Die Registrierung benutzerdefinierter Schriften für das Rendern ist von der Einbettung von Schriften in eine PPTX‑Datei getrennt. Wenn eine Schrift innerhalb der Präsentation selbst gespeichert werden muss, verwenden Sie die Schrift‑Einbettungs‑Features explizit.

Ein Präsentationsthema kann für einzelne Schriftsysteme unterschiedliche Schriftfamilien referenzieren. Diese Zuordnungen speichern Schrift­namen, installieren oder laden jedoch nicht die Schriftdateien. Siehe [Skriptspezifische Design‑Schriften](/slides/de/net/script-specific-font-mappings/), um die Zuordnungen zu verwalten, und verwenden Sie die untenstehenden Ladeoptionen, um die referenzierten Schriften für ein konsistentes Rendering verfügbar zu machen.

{{% alert color="info" title="Note" %}}
Aspose Slides ermöglicht das Laden dieser Schriften über die [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) Methode:

* TrueType (.ttf) und TrueType Collection (.ttc) Schriften. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) Schriften. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Laden benutzerdefinierter Schriften**

Aspose.Slides ermöglicht das Laden von Schriften, die in einer Präsentation verwendet werden, ohne sie auf dem System zu installieren. Dies beeinflusst die Exportausgabe – wie PDF, Bilder und andere unterstützte Formate – so dass die resultierenden Dokumente in verschiedenen Umgebungen konsistent aussehen. Schriften werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.
2. Rufen Sie die statische [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) Methode auf, um Schriften aus diesen Ordnern zu laden.
3. Laden und rendern/exportieren Sie die Präsentation.
4. Rufen Sie [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) auf, um den Schrift-Cache zu leeren.

Das folgende Code‑Beispiel demonstriert den Schrift‑Ladevorgang:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definieren Sie Ordner, die benutzerdefinierte Schriftdateien enthalten.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Laden Sie benutzerdefinierte Schriften aus den angegebenen Ordnern.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Rendern/Exportieren Sie die Präsentation (z.B. zu PDF, Bildern oder anderen Formaten) mit den geladenen Schriften.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Leeren Sie den Schrift-Cache, nachdem die Arbeit abgeschlossen ist.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Note" %}}
[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) fügt zusätzliche Ordner zu den Schrift‑Suchpfaden hinzu, ändert jedoch nicht die Reihenfolge der Schrift‑Initialisierung. Schriften werden in dieser Reihenfolge initialisiert:

1. Der standardmäßige Schriftpfad des Betriebssystems.
1. Die über [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) geladenen Pfade.
{{%/alert %}}

## **Abrufen benutzerdefinierter Schriftordner**
Aspose.Slides stellt die [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) Methode bereit, mit der Sie Schriftordner ermitteln können. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode hinzugefügt wurden, sowie System‑Schriftordner.

Dieser C#‑Code zeigt, wie Sie [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) verwenden:

```c#
using Aspose.Slides;

// Diese Zeile gibt die Ordner aus, die auf Schriftdateien geprüft werden.
// Das sind Ordner, die über die LoadExternalFonts‑Methode und System‑Schriftordner hinzugefügt wurden.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Angeben benutzerdefinierter Schriften, die mit einer Präsentation verwendet werden**
Aspose.Slides stellt die [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) Eigenschaft bereit, mit der Sie externe Schriften festlegen können, die mit der Präsentation verwendet werden sollen.

Dieser C#‑Code zeigt, wie Sie die [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) Eigenschaft verwenden:

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Arbeiten mit der Präsentation
    // CustomFont1, CustomFont2 und Schriften aus den Ordnern assets\fonts & global\fonts und deren Unterordnern stehen der Präsentation zur Verfügung
}
```

## **Externe Schriftverwaltung**

Aspose.Slides stellt die [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) Methode bereit, mit der Sie externe Schriften aus Binärdaten laden können.

Dieser C#‑Code demonstriert den Schrift‑Ladevorgang aus einem Byte‑Array:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // externe Schrift, die während der Lebensdauer der Präsentation geladen wird
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

Um einer passenden registrierten Schrift während des Exports Vorrang zu geben, ohne die eingebettete Schrift zu entfernen, siehe [Bevorzugen von registrierten Schriften gegenüber eingebetteten Schriften](/slides/de/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 oder später).

## **FAQ**

**Beeinflussen benutzerdefinierte Schriften den Export in alle Formate (PDF, PNG, SVG, HTML)?**

Ja. Verbundene Schriften werden vom Renderer in allen Exportformaten verwendet.

**Werden benutzerdefinierte Schriften automatisch in die resultierende PPTX eingebettet?**

Nein. Das Registrieren einer Schrift für das Rendern ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn Sie die Schrift in der Präsentationsdatei benötigen, müssen Sie die expliziten [Einbettungs‑Features](/slides/de/net/embedded-font/) verwenden.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schrift bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie [font substitution](/slides/de/net/font-substitution/), [replacement rules](/slides/de/net/font-replacement/) und [fallback sets](/slides/de/net/fallback-font/), um exakt festzulegen, welche Schrift verwendet wird, wenn die angeforderte Glyphe fehlt.

**Kann ich Schriften in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Zeigen Sie auf Ihre eigenen Schriftordner oder laden Sie Schriften aus Byte‑Arrays. Dadurch wird jede Abhängigkeit von System‑Schriftverzeichnissen im Container‑Image entfernt.

> **Hinweis für Linux/Docker**: Beim Aufruf von `FontsLoader.LoadExternalFonts` stellen Sie sicher, dass jeder Eintrag im `directories`‑Array einen nicht‑leeren Pfad zu einem bestehenden Verzeichnis enthält. Wenn eine Umgebungsvariable, die zum Erstellen eines Schriftpfads verwendet wird, nicht definiert oder leer ist, kann Aspose.Slides versuchen, den leeren Wert als vollständigen Pfad aufzulösen, was zu `System.ArgumentException` führt.

**Wie sieht es mit Lizenzierung aus – kann ich beliebige benutzerdefinierte Schriften ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schrift‑Lizenzbedingungen verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Überprüfen Sie stets die EULA der Schrift, bevor Sie Ausgaben verbreiten.