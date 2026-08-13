---
title: PowerPoint-Schriftarten in .NET anpassen
linktitle: Benutzerdefinierte Schriftart
type: docs
weight: 20
url: /de/net/custom-font/
keywords:
- Schriftart
- benutzerdefinierte Schriftart
- externe Schriftart
- Schriftart laden
- Schriftarten verwalten
- Schriftordner
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Passen Sie Schriftarten in PowerPoint‑Folien mit Aspose.Slides für .NET an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, benutzerdefinierte Schriftarten in Präsentationen zu verwenden, ohne sie im Betriebssystem installieren zu müssen. Sie können Schriftarten aus benutzerdefinierten Ordnern laden, Schriftarten für eine bestimmte Präsentation über dokumentbezogene Schriftquellen bereitstellen oder externe Schriftarten direkt aus Binärdaten laden.

Geladene Schriftarten werden verwendet, wenn eine Präsentation gerendert oder exportiert wird, zum Beispiel nach PDF, Bildern und anderen unterstützten Formaten. Dadurch bleibt die Ausgabe der Präsentation in verschiedenen Umgebungen konsistent. Der Artikel erklärt außerdem, wie Sie die von Aspose.Slides verwendeten Schriftordner inspizieren und den Schriftarten‑Cache nach der Arbeit mit externen Schriftarten leeren können.

Die Registrierung benutzerdefinierter Schriftarten zum Rendern ist von der Einbettung von Schriftarten in eine PPTX‑Datei zu unterscheiden. Wenn eine Schriftart innerhalb der Präsentation selbst gespeichert werden muss, verwenden Sie die Funktionen zur Schriftarteinbettung ausdrücklich.

{{% alert color="info" %}} 

Aspose Slides ermöglicht das Laden dieser Schriftarten über die [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/de/net/aspose.slides/fontsloader/loadexternalfonts/)‑Methode:

* TrueType‑ (.ttf) und TrueType‑Collection‑ (.ttc) Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑ (.otf) Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht es Ihnen, in einer Präsentation verwendete Schriftarten zu laden, ohne sie im System zu installieren. Dies wirkt sich auf die Exportausgabe – z. B. PDF, Bilder und andere unterstützte Formate – aus, sodass die resultierenden Dokumente in verschiedenen Umgebungen einheitlich aussehen. Schriftarten werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftartdateien enthalten.
2. Rufen Sie die statische [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/de/net/aspose.slides/fontsloader/loadexternalfonts/)‑Methode auf, um die Schriftarten aus diesen Ordnern zu laden.
3. Laden und rendern/exportieren Sie die Präsentation.
4. Rufen Sie [FontsLoader.ClearCache](https://reference.aspose.com/slides/de/net/aspose.slides/fontsloader/clearcache/) auf, um den Schriftarten‑Cache zu leeren.

Das folgende Codebeispiel demonstriert den Vorgang des Schriftartenladens:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Definieren Sie Ordner, die benutzerdefinierte Schriftdateien enthalten.
string[] fontFolders = { @"C:\MyFonts", @"D:\Fonts" };

// Laden Sie benutzerdefinierte Schriftarten aus den angegebenen Ordnern.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Rendern/Exportieren Sie die Präsentation (z. B. nach PDF, Bildern oder anderen Formaten) mit den geladenen Schriftarten.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Leeren Sie den Schriftarten-Cache, nachdem die Arbeit abgeschlossen ist.
FontsLoader.ClearCache();
```

{{% alert color="info" title="Hinweis" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/de/net/aspose.slides/fontsloader/loadexternalfonts/) fügt zusätzliche Ordner zu den Schriftart‑Suchpfaden hinzu, ändert jedoch nicht die Initialisierungsreihenfolge der Schriftarten.
Schriftarten werden in folgender Reihenfolge initialisiert:

1. Der standardmäßige Schriftartpfad des Betriebssystems.
1. Die über [FontsLoader](https://reference.aspose.com/slides/de/net/aspose.slides/fontsloader/) geladenen Pfade.

{{%/alert %}}

## **Benutzerdefinierte Schriftordner abrufen**
Aspose.Slides stellt die [GetFontFolders](https://reference.aspose.com/slides/de/net/aspose.slides/fontsloader/getfontfolders/)‑Methode bereit, mit der Sie Schriftordner finden können. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode hinzugefügt wurden, sowie System‑Schriftordner.

Der folgende C#‑Code zeigt, wie Sie [GetFontFolders](https://reference.aspose.com/slides/de/net/aspose.slides/fontsloader/getfontfolders/) verwenden:

```c#
using Aspose.Slides;

// Diese Zeile gibt die Ordner aus, die auf Schriftdateien überprüft werden.
// Das sind Ordner, die über die LoadExternalFonts-Methode und System-Schriftordner hinzugefügt wurden.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Benutzerdefinierte Schriftarten für eine Präsentation festlegen**
Aspose.Slides stellt die [DocumentLevelFontSources](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/documentlevelfontsources/)‑Eigenschaft bereit, mit der Sie externe Schriftarten angeben können, die mit der Präsentation verwendet werden sollen.

Der folgende C#‑Code zeigt, wie Sie die [DocumentLevelFontSources](https://reference.aspose.com/slides/de/net/aspose.slides/loadoptions/documentlevelfontsources/)‑Eigenschaft verwenden:

```c#
using Aspose.Slides;

byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Arbeiten Sie mit der Präsentation
    // CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts & global\fonts sowie deren Unterordnern stehen der Präsentation zur Verfügung
}
```

## **Schriftarten extern verwalten**

Aspose.Slides bietet die [LoadExternalFont](https://reference.aspose.com/slides/de/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data)‑Methode, mit der Sie externe Schriftarten aus Binärdaten laden können.

Der folgende C#‑Code demonstriert das Laden von Schriftarten aus einem Byte‑Array:

```c#
using Aspose.Slides;

FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // externe Schriftart während der Lebensdauer der Präsentation geladen
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **FAQ**

**Beeinflussen benutzerdefinierte Schriftarten den Export in alle Formate (PDF, PNG, SVG, HTML)?**

Ja. Verbundene Schriftarten werden vom Renderer in allen Exportformaten verwendet.

**Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?**

Nein. Die Registrierung einer Schriftart zum Rendern ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schriftart in der Präsentationsdatei enthalten sein soll, müssen Sie die expliziten [Einbettungs‑Features](/slides/de/net/embedded-font/) verwenden.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie die [Schriftart‑Substitution](/slides/de/net/font-substitution/), [Ersetzungsregeln](/slides/de/net/font-replacement/) und [Fallback‑Sätze](/slides/de/net/fallback-font/), um exakt festzulegen, welche Schriftart verwendet wird, wenn die gewünschte Glyphe fehlt.

**Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf Ihre eigenen Schriftordner oder laden Sie Schriftarten aus Byte‑Arrays. Damit entfällt jede Abhängigkeit von System‑Schriftordnern im Container‑Image.

> **Hinweis für Linux/Docker**: Beim Aufruf von `FontsLoader.LoadExternalFonts` stellen Sie sicher, dass jeder Eintrag im `directories`‑Array einen nicht leeren Pfad zu einem vorhandenen Verzeichnis enthält. Wenn eine Umgebungsvariable, die zum Aufbau eines Schriftartpfads verwendet wird, undefiniert oder leer ist, versucht Aspose.Slides möglicherweise, den leeren Wert als vollständigen Pfad aufzulösen, was zu `System.ArgumentException` führt.

**Wie sieht es mit Lizenzierung aus – kann ich jede benutzerdefinierte Schriftart ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenzierung verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Prüfen Sie stets die Endbenutzer‑Lizenzvereinbarung (EULA) der Schriftart, bevor Sie Ausgaben verbreiten.