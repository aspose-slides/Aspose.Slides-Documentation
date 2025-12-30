---
title: PowerPoint-Schriftarten in .NET anpassen
linktitle: Benutzerdefinierte Schriftart
type: docs
weight: 20
url: /de/net/custom-font/
keywords:
- Schriftart
- Benutzerdefinierte Schriftart
- Externe Schriftart
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

{{% alert color="primary" %}} 

Aspose Slides ermöglicht das Laden dieser Schriftarten über die Methode [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) :

* TrueType (.ttf)- und TrueType Collection (.ttc)-Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf)-Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht das Laden von in einer Präsentation verwendeten Schriftarten, ohne sie im System zu installieren. Dies wirkt sich auf die Exportausgabe aus – beispielsweise PDF, Bilder und andere unterstützte Formate – sodass die resultierenden Dokumente in verschiedenen Umgebungen konsistent aussehen. Schriftarten werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.
2. Rufen Sie die statische Methode [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) auf, um Schriftarten aus diesen Ordnern zu laden.
3. Laden und rendern/exportieren Sie die Präsentation.
4. Rufen Sie [FontsLoader.ClearCache](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/clearcache/) auf, um den Schriftart-Cache zu leeren.

Das folgende Codebeispiel demonstriert den Schriftarten‑Ladevorgang:
```cs
// Definieren Sie Ordner, die benutzerdefinierte Schriftdateien enthalten.
string[] fontFolders = { externalFontFolder1, externalFontFolder2 };

// Laden Sie benutzerdefinierte Schriftarten aus den angegebenen Ordnern.
FontsLoader.LoadExternalFonts(fontFolders);

using Presentation presentation = new Presentation("sample.pptx");

// Rendern/Exportieren Sie die Präsentation (z.B. nach PDF, Bildern oder anderen Formaten) mit den geladenen Schriftarten.
presentation.Save("output.pdf", SaveFormat.Pdf);

// Löschen Sie den Schriftart-Cache, nachdem die Arbeit abgeschlossen ist.
FontsLoader.ClearCache();
```


{{% alert color="info" title="Note" %}}

[FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) fügt zusätzliche Ordner zu den Schriftart‑Suchpfaden hinzu, ändert jedoch nicht die Reihenfolge der Schriftartinitialisierung.  
Schriftarten werden in dieser Reihenfolge initialisiert:

1. Der standardmäßige Schriftartenpfad des Betriebssystems.
1. Die über [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) geladenen Pfade.

{{%/alert %}}

## **Benutzerdefinierte Schriftordner abrufen**
Aspose.Slides stellt die Methode [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) bereit, mit der Sie Schriftordner finden können. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode hinzugefügt wurden, sowie System‑Schriftordner.

Dieser C#‑Code zeigt, wie Sie [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) verwenden können:
```c#
// Diese Zeile gibt die Ordner aus, die nach Schriftdateien durchsucht werden.
// Das sind Ordner, die über die Methode LoadExternalFonts hinzugefügt wurden, sowie System‑Schriftordner.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **Benutzerdefinierte Schriftarten für eine Präsentation festlegen**
Aspose.Slides stellt die Eigenschaft [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) bereit, mit der Sie externe Schriftarten angeben können, die in der Präsentation verwendet werden.

Dieser C#‑Code zeigt, wie Sie die Eigenschaft [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) verwenden:
```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Arbeiten mit der Präsentation
    // CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts & global\fonts sowie deren Unterordnern stehen der Präsentation zur Verfügung
}
```


## **Schriftarten extern verwalten**

Aspose.Slides stellt die Methode [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) bereit, mit der Sie externe Schriftarten aus Binärdaten laden können.

Dieser C#‑Code demonstriert den Ladevorgang einer Schriftart aus einem Byte‑Array: 
```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // extern geladene Schriftart während der Laufzeit der Präsentation
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

Nein. Das Registrieren einer Schriftart für das Rendering ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn Sie die Schriftart in der Präsentationsdatei benötigen, müssen Sie die expliziten [Einbettungs‑Features](/slides/de/net/embedded-font/) verwenden.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie [Schriftart‑Substitution](/slides/de/net/font-substitution/), [Ersetzungsregeln](/slides/de/net/font-replacement/) und [Fallback‑Sets](/slides/de/net/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die gewünschte Glyphe fehlt.

**Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf eigene Schriftordner oder laden Sie Schriftarten aus Byte‑Arrays. Dadurch wird jede Abhängigkeit von System‑Schriftverzeichnissen im Container‑Image eliminiert.

**Wie sieht es mit der Lizenzierung aus – kann ich jede benutzerdefinierte Schriftart ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenz verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Überprüfen Sie stets die EULA der Schriftart, bevor Sie Ausgaben verteilen.