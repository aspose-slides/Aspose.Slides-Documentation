---
title: PowerPoint-Schriftarten in Java anpassen
linktitle: Benutzerdefinierte Schriftart
type: docs
weight: 20
url: /de/java/custom-font/
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
- Java
- Aspose.Slides
description: "Passen Sie Schriftarten in PowerPoint-Folien mit Aspose.Slides für Java an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht das Laden dieser Schriftarten mithilfe der [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) Methode:

* TrueType- (.ttf) und TrueType Collection- (.ttc) Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType- (.otf) Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht das Laden von Schriftarten, die in Präsentationen gerendert werden, ohne dass diese Schriftarten installiert werden müssen. Die Schriftarten werden aus einem benutzerdefinierten Verzeichnis geladen. 

1. Erstellen Sie eine Instanz der [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/)‑Klasse und rufen Sie die [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑Methode auf.  
2. Laden Sie die Präsentation, die gerendert werden soll.  
3. [Clear the cache](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) in der [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader)‑Klasse.

Dieser Java‑Code demonstriert den Schriftarten‑Ladevorgang:
```java
// Ordner, in denen nach Schriftarten gesucht wird
String[] folders = new String[] { externalFontsDir };

// Lädt die Schriftarten aus dem benutzerdefinierten Schriftverzeichnis
FontsLoader.loadExternalFonts(folders);

// Führen Sie einige Arbeiten aus und rendern Sie die Präsentation/Folie
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // Löscht den Schriftarten-Cache
    FontsLoader.clearCache();
}
```


## **Benutzerdefinierte Schriftordner abrufen**

Aspose.Slides stellt die [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--)‑Methode bereit, mit der Sie Schriftordner finden können. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode und System‑Schriftordner hinzugefügt wurden.

Dieser Java‑Code zeigt, wie Sie [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) verwenden:
```java
// Diese Zeile gibt Ordner aus, in denen Schriftdateien gesucht werden.
// Dies sind Ordner, die über die LoadExternalFonts‑Methode und System‑Schriftordner hinzugefügt wurden.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **Benutzerdefinierte Schriftarten für eine Präsentation angeben**

Aspose.Slides bietet die Eigenschaft [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) an, mit der Sie externe Schriftarten festlegen können, die mit der Präsentation verwendet werden.

Dieser Java‑Code zeigt, wie Sie die [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)‑Eigenschaft verwenden:
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Arbeiten mit der Präsentation
    // CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts & global\fonts sowie deren Unterordnern stehen der Präsentation zur Verfügung
} finally {
    if (pres != null) pres.dispose();
}
```


## **Schriftarten extern verwalten**

Aspose.Slides stellt die Methode [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) bereit, mit der Sie externe Schriftarten aus Binärdaten laden können.

Dieser Java‑Code demonstriert den Ladevorgang einer Schriftart aus einem Byte‑Array:
```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // Externe Schriftart wird während der Lebensdauer der Präsentation geladen
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```


## **FAQ**

**Beeinflussen benutzerdefinierte Schriftarten den Export in alle Formate (PDF, PNG, SVG, HTML)?**

Ja. Verknüpfte Schriftarten werden vom Renderer in allen Exportformaten verwendet.

**Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?**

Nein. Das Registrieren einer Schriftart zum Rendern ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schriftart innerhalb der Präsentationsdatei enthalten sein soll, müssen Sie die expliziten [Einbettungsfunktionen](/slides/de/java/embedded-font/) verwenden.

**Kann ich das Fallback-Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie [Schriftartenersetzung](/slides/de/java/font-substitution/), [Ersetzungsregeln](/slides/de/java/font-replacement/) und [Fallback‑Sätze](/slides/de/java/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die angeforderte Glyphe fehlt.

**Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf eigene Schriftordner oder laden Sie Schriftarten aus Byte‑Arrays. Dadurch entfällt jede Abhängigkeit von System‑Schriftverzeichnissen im Container‑Image.

**Wie sieht es mit Lizenzierung aus – kann ich irgendeine benutzerdefinierte Schriftart ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenzbedingungen verantwortlich. Die Bedingungen variieren; einige Lizenzen untersagen das Einbetten oder die kommerzielle Nutzung. Überprüfen Sie stets die EULA der Schriftart, bevor Sie Ausgaben verbreiten.