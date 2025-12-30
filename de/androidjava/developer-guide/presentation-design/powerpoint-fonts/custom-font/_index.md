---
title: PowerPoint-Schriften unter Android anpassen
linktitle: Benutzerdefinierte Schrift
type: docs
weight: 20
url: /de/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "Passen Sie Schriften in PowerPoint-Folien mit Aspose.Slides für Android über Java an, um Ihre Präsentationen auf allen Geräten scharf und konsistent zu halten."
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht das Laden dieser Schriften mithilfe der [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) Methode:

* TrueType (.ttf)- und TrueType Collection (.ttc)-Schriften. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf)-Schriften. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriften laden**

Aspose.Slides ermöglicht das Laden von Schriften, die in einer Präsentation verwendet werden, ohne sie im System zu installieren. Dies wirkt sich auf die Exportausgabe aus – z. B. PDF, Bilder und andere unterstützte Formate – sodass die resultierenden Dokumente in verschiedenen Umgebungen konsistent aussehen. Schriften werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.
2. Rufen Sie die statische [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) Methode auf, um Schriften aus diesen Ordnern zu laden.
3. Laden und rendern/exportieren Sie die Präsentation.
4. Rufen Sie [FontsLoader.clearCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) auf, um den Schrift-Cache zu leeren.

Das folgende Codebeispiel demonstriert den Schriftladevorgang:
```java
// Definieren Sie Ordner, die benutzerdefinierte Schriftdateien enthalten.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Laden Sie benutzerdefinierte Schriften aus den angegebenen Ordnern.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Präsentation rendern/exportieren (z. B. nach PDF, Bildern oder anderen Formaten) mit den geladenen Schriften.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Löschen Sie den Schrift-Cache, nachdem die Arbeit abgeschlossen ist.
    FontsLoader.clearCache();
}
```


{{% alert color="info" title="Hinweis" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) fügt zusätzliche Ordner zu den Schriftsuchpfaden hinzu, ändert jedoch nicht die Reihenfolge der Schriftinitialisierung.  
Schriften werden in dieser Reihenfolge initialisiert:

1. Der Standardschriftpfad des Betriebssystems.
1. Die Pfade, die über [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) geladen wurden.

{{%/alert %}}

## **Benutzerdefinierte Schriftordner abrufen**
Aspose.Slides stellt die [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) Methode zur Verfügung, mit der Sie Schriftordner finden können. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode hinzugefügt wurden, sowie System‑Schriftordner.

Dieser Java‑Code zeigt, wie Sie [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) verwenden:
```java
// Diese Zeile gibt die Ordner aus, in denen nach Schriftdateien gesucht wird.
// Das sind Ordner, die über die LoadExternalFonts-Methode und System-Schriftordner hinzugefügt wurden.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **Benutzerdefinierte Schriften für eine Präsentation festlegen**
Aspose.Slides bietet die [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) Eigenschaft, mit der Sie externe Schriften angeben können, die mit der Präsentation verwendet werden sollen.

Dieser Java‑Code zeigt, wie Sie die [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) Eigenschaft verwenden:
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Arbeiten mit der Präsentation
    // CustomFont1, CustomFont2 und Schriften aus den Ordnern assets\fonts & global\fonts sowie deren Unterordnern stehen der Präsentation zur Verfügung
} finally {
    if (pres != null) pres.dispose();
}
```


## **Schriften extern verwalten**

Aspose.Slides stellt die [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) Methode bereit, mit der Sie externe Schriften aus Binärdaten laden können.

Dieser Java‑Code demonstriert das Laden von Schriften aus einem Byte‑Array:
```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // extern geladene Schrift während der Lebensdauer der Präsentation
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```


## **FAQ**

**Beeinflussen benutzerdefinierte Schriften den Export in alle Formate (PDF, PNG, SVG, HTML)?**

Ja. Verbundene Schriften werden vom Renderer in allen Exportformaten verwendet.

**Werden benutzerdefinierte Schriften automatisch in die resultierende PPTX eingebettet?**

Nein. Das Registrieren einer Schrift zum Rendern ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn Sie die Schrift in der Präsentationsdatei behalten möchten, müssen Sie die expliziten [embedding features](/slides/de/androidjava/embedded-font/) verwenden.

**Kann ich das Fallback-Verhalten steuern, wenn einer benutzerdefinierten Schrift bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie [font substitution](/slides/de/androidjava/font-substitution/), [replacement rules](/slides/de/androidjava/font-replacement/) und [fallback sets](/slides/de/androidjava/fallback-font/), um genau festzulegen, welche Schrift verwendet wird, wenn die angeforderte Glyphe fehlt.

**Kann ich Schriften in Linux/Docker-Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Zeigen Sie auf Ihre eigenen Schriftordner oder laden Sie Schriften aus Byte‑Arrays. So entfällt jede Abhängigkeit von Systemschriftverzeichnissen im Container‑Image.

**Wie sieht es mit Lizenzierung aus – kann ich jede benutzerdefinierte Schrift ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenz verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Überprüfen Sie stets die EULA der Schrift, bevor Sie Ausgaben verbreiten.