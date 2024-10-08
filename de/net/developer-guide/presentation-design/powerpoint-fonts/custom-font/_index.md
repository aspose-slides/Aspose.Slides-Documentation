---
title: Benutzerdefinierte PowerPoint-Schriftart in C#
linktitle: Benutzerdefinierte Schriftart
type: docs
weight: 20
url: /de/net/custom-font/
keywords: "Schriftarten, benutzerdefinierte Schriftarten, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint benutzerdefinierte Schriftarten in C#"
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht es Ihnen, diese Schriftarten mit der Methode [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) zu laden:

* TrueType (.ttf) und TrueType Collection (.ttc) Schriftarten. Siehe [TrueType](https://de.wikipedia.org/wiki/TrueType).

* OpenType (.otf) Schriftarten. Siehe [OpenType](https://de.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht es Ihnen, Schriftarten zu laden, die in Präsentationen gerendert werden, ohne dass diese Schriftarten installiert werden müssen. Die Schriftarten werden aus einem benutzerdefinierten Verzeichnis geladen.

1. Erstellen Sie eine Instanz der [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) Klasse und rufen Sie die Methode [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) auf.
2. Laden Sie die Präsentation, die gerendert werden soll.
3. Leeren Sie den Cache in der [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) Klasse.

Dieser C#-Code zeigt den Schriftartladeprozess:

``` csharp
// Der Pfad zum Dokumentenverzeichnis
string dataDir = "C:\\";

// Ordner, um nach Schriftarten zu suchen
String[] folders = new String[] { dataDir };

// Lädt die Schriftarten aus dem benutzerdefinierten Verzeichnis
FontsLoader.LoadExternalFonts(folders);

// Führen Sie einige Arbeiten durch und rendern Sie die Präsentation/Folien
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// Leert den Schriftarten-Cache
FontsLoader.ClearCache();
```

## **Benutzerdefinierten Schriftartenordner abrufen**

Aspose.Slides bietet die Methode [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/), um Ihnen zu ermöglichen, Schriftartenordner zu finden. Diese Methode gibt Ordner zurück, die über die Methode `LoadExternalFonts` hinzugefügt wurden, sowie systemweite Schriftartenordner.

Dieser C#-Code zeigt Ihnen, wie Sie [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) verwenden:

```c#
// Diese Zeile gibt die Ordner aus, die auf Schriftartdateien überprüft werden.
// Dies sind Ordner, die über die LoadExternalFonts-Methode und systemweite Schriftartenordner hinzugefügt wurden.
string[] fontFolders = FontsLoader.GetFontFolders();
```

## **Benutzerdefinierte Schriftarten für die Präsentation angeben**

Aspose.Slides bietet die Eigenschaft [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/), um externe Schriftarten anzugeben, die mit der Präsentation verwendet werden.

Dieser C#-Code zeigt Ihnen, wie Sie die Eigenschaft [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) verwenden:

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Arbeiten mit der Präsentation
    // CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts & global\fonts sowie deren Unterordnern sind der Präsentation verfügbar
}
```

## **Schriftarten extern verwalten**

Aspose.Slides bietet die Methode [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data), um externer Schriftarten aus binären Daten zu laden.

Dieser C#-Code demonstriert den Prozess des Ladens von Schriftarten aus Byte-Arrays: 

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // externe Schriftart, die während der Lebensdauer der Präsentation geladen wurde
    }
}
finally
{
    FontsLoader.ClearCache();
}
```