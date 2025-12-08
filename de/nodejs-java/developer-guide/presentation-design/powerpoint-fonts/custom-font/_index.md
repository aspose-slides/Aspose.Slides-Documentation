---
title: Benutzerdefinierte PowerPoint-Schriftart in JavaScript
linktitle: Benutzerdefinierte Schrift
type: docs
weight: 20
url: /de/nodejs-java/custom-font/
keywords: "Schriften, benutzerdefinierte Schriften, PowerPoint-Präsentation, Java, Aspose.Slides für Node.js via Java"
description: "PowerPoint‑benutzerdefinierte Schriften in JavaScript"
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht das Laden dieser Schriften mit der [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑Methode:

* TrueType‑Schriften (.ttf) und TrueType‑Sammlungen (.ttc). Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑Schriften (.otf). Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriften laden**

Aspose.Slides ermöglicht das Laden von Schriften, die in Präsentationen gerendert werden, ohne diese installieren zu müssen. Die Schriften werden aus einem benutzerdefinierten Verzeichnis geladen. 

1. Erstellen Sie eine Instanz der [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/)‑Klasse und rufen Sie die [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑Methode auf.  
2. Laden Sie die Präsentation, die gerendert werden soll.  
3. [Clear the cache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsLoader#clearCache--) in der [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsLoader)‑Klasse.

Dieser JavaScript‑Code demonstriert den Vorgang des Schriftartenladens:
```javascript
// Ordner zum Suchen von Schriftarten
var folders = java.newArray("java.lang.String", [externalFontsDir]);
// Lädt die Schriftarten aus dem benutzerdefinierten Schriftartenverzeichnis
aspose.slides.FontsLoader.loadExternalFonts(folders);
// Führt einige Aktionen aus und rendert die Präsentation/Folie
var pres = new aspose.slides.Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
    // Löscht den Schriftarten-Cache
    aspose.slides.FontsLoader.clearCache();
}
```


## **Benutzerdefinierten Schriftenordner abrufen**
Aspose.Slides stellt die [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--)‑Methode zur Verfügung, um Schriftordner zu finden. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode sowie System‑Schriftordner hinzugefügt wurden.

Dieser JavaScript‑Code zeigt, wie Sie [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) verwenden:
```javascript
// Diese Zeile gibt die Ordner aus, in denen nach Schriftdateien gesucht wird.
// Das sind Ordner, die über die LoadExternalFonts-Methode und System-Schriftordner hinzugefügt wurden.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```


## **Angeben benutzerdefinierter Schriften für die Präsentation**
Aspose.Slides bietet die [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-)‑Eigenschaft, mit der externe Schriften festgelegt werden können, die für die Präsentation verwendet werden.

Dieser JavaScript‑Code zeigt, wie Sie die [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-)‑Eigenschaft nutzen:
```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Arbeit mit der Präsentation
    // CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts & global\fonts sowie deren Unterordnern sind für die Präsentation verfügbar
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Schriften extern verwalten**

Aspose.Slides stellt die [loadExternalFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)‑Methode bereit, um externe Schriften aus Binärdaten zu laden.

Dieser JavaScript‑Code demonstriert das Laden von Schriftarten aus einem Byte‑Array:
```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // Externe Schriftart während der Laufzeit der Präsentation geladen
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```


## **FAQ**

**Wirken sich benutzerdefinierte Schriften auf den Export in alle Formate (PDF, PNG, SVG, HTML) aus?**

Ja. Eingebundene Schriften werden vom Renderer in allen Exportformaten verwendet.

**Werden benutzerdefinierte Schriften automatisch in die resultierende PPTX eingebettet?**

Nein. Das Registrieren einer Schrift für das Rendering ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schrift in der Präsentationsdatei enthalten sein soll, müssen Sie die expliziten [Embedding‑Features](/slides/de/nodejs-java/embedded-font/) nutzen.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schrift bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie [Font‑Substitution](/slides/de/nodejs-java/font-substitution/), [Replacement‑Rules](/slides/de/nodejs-java/font-replacement/) und [Fallback‑Sets](/slides/de/nodejs-java/fallback-font/), um genau festzulegen, welche Schrift verwendet wird, wenn die angeforderte Glyphe fehlt.

**Kann ich Schriften in Linux/Docker‑Containern nutzen, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf eigene Schriftordner oder laden Sie Schriften aus Byte‑Arrays. Dadurch entfällt jede Abhängigkeit von Systemschriftverzeichnissen im Container‑Image.

**Wie verhält es sich mit Lizenzierung – kann ich jede benutzerdefinierte Schrift ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenzierung verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Überprüfen Sie stets die EULA der jeweiligen Schrift, bevor Sie Ausgaben verbreiten.