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
description: "Passen Sie Schriftarten in PowerPoint‑Folien mit Aspose.Slides für .NET an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht das Laden dieser Schriftarten mit der Methode [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) :

* TrueType (.ttf) und TrueType Collection (.ttc) Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht das Laden von Schriftarten, die in Präsentationen gerendert werden, ohne dass diese Schriftarten installiert werden müssen. Die Schriftarten werden aus einem benutzerdefinierten Verzeichnis geladen. 

1. Erstellen Sie eine Instanz der Klasse [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) und rufen Sie die Methode [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) auf.  
2. Laden Sie die Präsentation, die gerendert werden soll.  
3. Leeren Sie den Cache in der Klasse [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/).  

Dieser C#‑Code demonstriert den Schriftarten‑Ladevorgang:
``` csharp
// Der Pfad zum Dokumentenverzeichnis
string dataDir = "C:\\";

// Ordner, in denen nach Schriften gesucht wird
String[] folders = new String[] { dataDir };

// Lädt die Schriften aus dem benutzerdefinierten Schriftverzeichnis
FontsLoader.LoadExternalFonts(folders);

// Führt einige Arbeiten aus und rendert die Präsentation/Folie
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// Löscht den Schrift-Cache
FontsLoader.ClearCache();
```


## **Benutzerdefinierte Schriftordner abrufen**
Aspose.Slides stellt die Methode [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) zur Verfügung, mit der Sie Schriftordner finden können. Diese Methode gibt Ordner zurück, die über die Methode `LoadExternalFonts` hinzugefügt wurden, sowie Systemschriftordner.

Dieser C#‑Code zeigt, wie Sie [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) verwenden:
```c#
 // Diese Zeile gibt die Ordner aus, die auf Schriftdateien überprüft werden.
 // Dabei handelt es sich um Ordner, die über die Methode LoadExternalFonts hinzugefügt wurden, sowie Systemschriftordner.
 string[] fontFolders = FontsLoader.GetFontFolders();
```


## **Benutzerdefinierte Schriftarten für eine Präsentation angeben**
Aspose.Slides stellt die Eigenschaft [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) bereit, mit der Sie externe Schriftarten angeben können, die mit der Präsentation verwendet werden.

Dieser C#‑Code zeigt, wie Sie die Eigenschaft [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) verwenden:
```c#
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

Aspose.Slides stellt die Methode [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) zur Verfügung, mit der Sie externe Schriftarten aus binären Daten laden können.

Dieser C#‑Code demonstriert das Laden von Schriftarten aus einem Byte‑Array: 
```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // Externe Schriftart, die während der Lebensdauer der Präsentation geladen wird
    }
}
finally
{
    FontsLoader.ClearCache();
}
```


## **FAQ**

**Wirken sich benutzerdefinierte Schriftarten auf den Export in alle Formate (PDF, PNG, SVG, HTML) aus?**

Ja. Verbundene Schriftarten werden vom Renderer in allen Exportformaten verwendet.

**Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?**

Nein. Das Registrieren einer Schriftart zum Rendern ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn Sie die Schriftart in der Präsentationsdatei benötigen, müssen Sie die expliziten [Einbettungsfunktionen](/slides/de/net/embedded-font/) verwenden.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie [font substitution](/slides/de/net/font-substitution/), [replacement rules](/slides/de/net/font-replacement/) und [fallback sets](/slides/de/net/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die angeforderte Glyphe fehlt.

**Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf Ihre eigenen Schriftordner oder laden Sie Schriftarten aus Byte‑Arrays. Dadurch wird jede Abhängigkeit von Systemschriftverzeichnissen im Container‑Image entfernt.

**Wie sieht es mit der Lizenzierung aus – kann ich beliebige benutzerdefinierte Schriftarten ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenz verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Überprüfen Sie stets die EULA der Schriftart, bevor Sie Ausgaben verbreiten.