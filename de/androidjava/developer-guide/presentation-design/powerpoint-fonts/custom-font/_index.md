---
title: PowerPoint-Schriftarten auf Android anpassen
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
description: "Passen Sie Schriftarten in PowerPoint-Folien mit Aspose.Slides für Android über Java an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht das Laden dieser Schriften über die [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑Methode:

* TrueType (.ttf)- und TrueType Collection (.ttc)-Schriften. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf)-Schriften. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriften laden**

Aspose.Slides ermöglicht das Laden von Schriften, die in Präsentationen gerendert werden, ohne dass diese Schriften installiert werden müssen. Die Schriften werden aus einem benutzerdefinierten Verzeichnis geladen. 

1. Erstellen Sie eine Instanz der [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/)‑Klasse und rufen Sie die [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑Methode auf.
2. Laden Sie die zu rendernde Präsentation.
3. [Cache leeren](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) in der [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader)‑Klasse.

This Java code demonstrates the font loading process:
```java
// Ordner, in denen nach Schriften gesucht wird
String[] folders = new String[] { externalFontsDir };

// Lädt die Schriften aus dem benutzerdefinierten Schriftordner
FontsLoader.loadExternalFonts(folders);

// Führt einige Arbeiten aus und rendert die Präsentation/Folie
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // Löscht den Schrift-Cache
    FontsLoader.clearCache();
}
```


## **Benutzerdefinierte Schriftordner abrufen**
Aspose.Slides stellt die [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--)‑Methode bereit, mit der Sie Schriftordner finden können. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode hinzugefügt wurden, sowie System‑Schriftordner.

This Java code shows you how to use [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):
```java
// Diese Zeile gibt Ordner aus, in denen nach Schriftdateien gesucht wird.
// Dies sind Ordner, die über die LoadExternalFonts-Methode hinzugefügt wurden und System-Schriftordner.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **Benutzerdefinierte Schriften für eine Präsentation angeben**
Aspose.Slides stellt die Eigenschaft [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) bereit, mit der Sie externe Schriften angeben können, die in der Präsentation verwendet werden.

This Java code shows you how to use the [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) property:
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

Aspose.Slides stellt die [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)‑Methode bereit, mit der Sie externe Schriften aus Binärdaten laden können.

This Java code demonstrates the byte array font loading process:
```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // externe Schrift während der Lebensdauer der Präsentation geladen
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

Nein. Das Registrieren einer Schrift für das Rendering ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schrift in der Präsentationsdatei enthalten sein soll, müssen Sie die expliziten [Einbettungsfunktionen](/slides/de/androidjava/embedded-font/) verwenden.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schrift bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie die [Schrift‑Substitution](/slides/de/androidjava/font-substitution/), [Ersatz‑Regeln](/slides/de/androidjava/font-replacement/) und [Fallback‑Sets](/slides/de/androidjava/fallback-font/), um genau festzulegen, welche Schrift verwendet wird, wenn die gewünschte Glyphe fehlt.

**Kann ich Schriften in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf Ihre eigenen Schrift‑Ordner oder laden Sie Schriften aus Byte‑Arrays. Dadurch entfällt jede Abhängigkeit von System‑Schriftverzeichnissen im Container‑Image.

**Wie sieht es mit der Lizenzierung aus – kann ich jede benutzerdefinierte Schrift ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schrift‑Lizenzbedingungen verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Prüfen Sie stets die Endbenutzerlizenz (EULA) der Schrift, bevor Sie Ausgaben verbreiten.