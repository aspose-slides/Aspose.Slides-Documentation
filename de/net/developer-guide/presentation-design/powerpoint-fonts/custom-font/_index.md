---
title: Benutzerdefinierte PowerPoint-Schrift in C#
linktitle: Benutzerdefinierte Schrift
type: docs
weight: 20
url: /de/net/custom-font/
keywords: "Schriften, benutzerdefinierte Schriften, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint-Benutzerdefinierte Schriften in C#"
---

{{% alert color="primary" %}}

Aspose Slides ermöglicht das Laden dieser Schriften über die [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/)‑Methode:

* TrueType‑Schriften (.ttf) und TrueType‑Collection‑Schriften (.ttc). Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑Schriften (.otf). Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriften laden**

Aspose.Slides ermöglicht das Laden von Schriften, die in Präsentationen gerendert werden, ohne diese Schriften installieren zu müssen. Die Schriften werden aus einem benutzerdefinierten Verzeichnis geladen.

1. Erstellen Sie eine Instanz der Klasse [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) und rufen Sie die Methode [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) auf.
2. Laden Sie die Präsentation, die gerendert werden soll.
3. Löschen Sie den Cache in der Klasse [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) .

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

// Leert den Schrift-Cache
FontsLoader.ClearCache();
```


## **Ordner für benutzerdefinierte Schriften abrufen**
Aspose.Slides stellt die Methode [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) zur Verfügung, mit der Sie Schriftordner finden können. Diese Methode gibt Ordner zurück, die über die Methode `LoadExternalFonts` hinzugefügt wurden, sowie Systemschriftordner.

```c#
 // Diese Zeile gibt die Ordner aus, die auf Schriftdateien überprüft werden.
 // Es handelt sich um Ordner, die über die LoadExternalFonts‑Methode und Systemschriftordner hinzugefügt wurden.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **Benutzerdefinierte Schriften angeben, die mit der Präsentation verwendet werden**
Aspose.Slides stellt die Eigenschaft [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) zur Verfügung, mit der Sie externe Schriften angeben können, die mit der Präsentation verwendet werden.

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Arbeit mit der Präsentation
    // CustomFont1, CustomFont2 und Schriften aus den Ordnern assets\fonts & global\fonts sowie deren Unterordnern stehen der Präsentation zur Verfügung
}
```


## **Schriften extern verwalten**
Aspose.Slides stellt die Methode [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) zur Verfügung, mit der Sie externe Schriften aus Binärdaten laden können.

```c#
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


## **FAQ**

**Beeinflussen benutzerdefinierte Schriften den Export in alle Formate (PDF, PNG, SVG, HTML)?**

Ja. Verbundene Schriften werden vom Renderer in allen Exportformaten verwendet.

**Werden benutzerdefinierte Schriften automatisch in die resultierende PPTX eingebettet?**

Nein. Das Registrieren einer Schrift für das Rendering ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn Sie die Schrift im Präsentationsdatei tragen lassen wollen, müssen Sie die expliziten [Einbettungsfunktionen](/slides/de/net/embedded-font/) verwenden.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schrift bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie [Schrift‑substitution](/slides/de/net/font-substitution/), [Ersetzungsregeln](/slides/de/net/font-replacement/) und [Fallback‑Sets](/slides/de/net/fallback-font/), um genau festzulegen, welche Schrift verwendet wird, wenn die angeforderte Glyphe fehlt.

**Kann ich Schriften in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf eigene Schriftordner oder laden Sie Schriften aus Byte‑Arrays. Dadurch entfällt jede Abhängigkeit von Systemschriftverzeichnissen im Container‑Image.

**Wie sieht es mit Lizenzierung aus – kann ich beliebige benutzerdefinierte Schriften ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenzierung verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Prüfen Sie immer die EULA der Schrift, bevor Sie Ausgaben verbreiten.