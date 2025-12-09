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
- Schriftartenordner
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Passen Sie Schriftarten in PowerPoint-Folien mit Aspose.Slides für .NET an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht das Laden dieser Schriftarten mit der [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/)‑Methode:

* TrueType (.ttf) und TrueType Collection (.ttc) Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht das Laden von Schriftarten, die in Präsentationen gerendert werden, ohne diese Schriftarten installieren zu müssen. Die Schriftarten werden aus einem benutzerdefinierten Verzeichnis geladen. 

1. Erstellen Sie eine Instanz der Klasse [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) und rufen Sie die Methode [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) auf.
2. Laden Sie die Präsentation, die gerendert werden soll.
3. Leeren Sie den Cache in der Klasse [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).

Dieser C#-Code demonstriert den Schriftarten-Ladevorgang:
``` csharp
// Der Pfad zum Dokumentenverzeichnis
string dataDir = "C:\\";
// Ordner, in denen nach Schriftarten gesucht wird
String[] folders = new String[] { dataDir };
// Lädt die Schriftarten aus dem benutzerdefinierten Schriftartenverzeichnis
FontsLoader.LoadExternalFonts(folders);
// Führt einige Arbeiten aus und rendert Präsentation/Folie
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);
// Löscht den Schriftart-Cache
FontsLoader.ClearCache();
```


## **Benutzerdefinierten Schriftarten-Ordner ermitteln**
Aspose.Slides stellt die Methode [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) bereit, mit der Sie Schriftartenordner finden können. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`-Methode hinzugefügt wurden, sowie System-Schriftartenordner.

Dieser C#-Code zeigt, wie Sie [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) verwenden:
```c#
// Diese Zeile gibt die Ordner aus, die auf Schriftdateien überprüft werden.
// Das sind Ordner, die über die LoadExternalFonts-Methode hinzugefügt wurden sowie System-Schriftordner.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **Benutzerdefinierte Schriftarten für die Präsentation festlegen**
Aspose.Slides stellt die Eigenschaft [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) bereit, mit der Sie externe Schriftarten angeben können, die mit der Präsentation verwendet werden.

Dieser C#-Code zeigt, wie Sie die Eigenschaft [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) verwenden:
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

Dieser C#-Code demonstriert den Ladevorgang von Schriftarten aus einem Byte-Array: 
```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // extern geladene Schriftart während der Lebensdauer der Präsentation
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

Nein. Das Registrieren einer Schriftart zum Rendern ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn Sie die Schriftart innerhalb der Präsentationsdatei benötigen, müssen Sie die expliziten [Embedding-Features](/slides/de/net/embedded-font/) verwenden.

**Kann ich das Fallback-Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie [Font-Substitution](/slides/de/net/font-substitution/), [Ersatzregeln](/slides/de/net/font-replacement/) und [Fallback-Sets](/slides/de/net/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die gewünschte Glyphe fehlt.

**Kann ich Schriftarten in Linux-/Docker-Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf Ihre eigenen Schriftartenordner oder laden Sie Schriftarten aus Byte-Arrays. Dadurch entfällt jede Abhängigkeit von den System-Schriftartenverzeichnissen im Container-Image.

**Wie sieht es mit Lizenzierung aus – kann ich jede benutzerdefinierte Schriftart ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenz verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Überprüfen Sie stets die Endbenutzer-Lizenzvereinbarung (EULA) der Schriftart, bevor Sie Ausgaben verbreiten.