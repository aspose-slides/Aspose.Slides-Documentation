---
title: Anpassen von PowerPoint-Schriftarten in JavaScript
linktitle: Benutzerdefinierte Schriftart
type: docs
weight: 20
url: /de/nodejs-java/custom-font/
keywords:
- Schriftart
- benutzerdefinierte Schriftart
- externe Schriftart
- Schrift laden
- Schriftarten verwalten
- Schriftordner
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Passen Sie Schriftarten in PowerPoint-Folien mit JavaScript und Aspose.Slides für Node.js über Java an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht das Laden dieser Schriften über die [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑Methode:

* TrueType‑Schriften (.ttf) und TrueType‑Sammlungen (.ttc). Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑Schriften (.otf). Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht das Laden von Schriften, die in einer Präsentation verwendet werden, ohne sie im System zu installieren. Dies wirkt sich auf die Exportausgabe – wie PDF, Bilder und andere unterstützte Formate – aus, sodass die resultierenden Dokumente in verschiedenen Umgebungen konsistent aussehen. Schriften werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.
2. Rufen Sie die statische [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/)‑Methode auf, um Schriften aus diesen Ordnern zu laden.
3. Laden und rendern/exportieren Sie die Präsentation.
4. Rufen Sie [FontsLoader.clearCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/clearcache/) auf, um den Schriftarten‑Cache zu leeren.

Das folgende Codebeispiel demonstriert den Schriftarten‑Ladevorgang:
```js
// Definieren Sie Ordner, die benutzerdefinierte Schriftdateien enthalten.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Laden Sie benutzerdefinierte Schriften aus den angegebenen Ordnern.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Rendern/Exportieren Sie die Präsentation (z. B. in PDF, Bilder oder andere Formate) mit den geladenen Schriften.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Löschen Sie den Schrift-Cache, nachdem die Arbeit abgeschlossen ist.
    aspose.slides.FontsLoader.clearCache();
}
```


{{% alert color="info" title="Hinweis" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) fügt zusätzliche Ordner zu den Schriftarten‑Suchpfaden hinzu, ändert jedoch nicht die Reihenfolge, in der Schriften initialisiert werden.  
Schriften werden in dieser Reihenfolge initialisiert:

1. Der standardmäßige Betriebssystem‑Schriftpfad.  
1. Die über [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/) geladenen Pfade.

{{%/alert %}}

## **Benutzerdefinierte Schriftarten‑Ordner abrufen**
Aspose.Slides stellt die [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--)‑Methode bereit, mit der Sie Schriftordner ermitteln können. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode sowie System‑Schriftordner hinzugefügt wurden.

Der folgende JavaScript‑Code zeigt, wie Sie [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) verwenden:
```javascript
// Diese Zeile gibt Ordner aus, in denen nach Schriftdateien gesucht wird.
// Das sind Ordner, die über die LoadExternalFonts Methode und System-Schriftordner hinzugefügt wurden.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```


## **Benutzerdefinierte Schriften für die Präsentation festlegen**
Aspose.Slides bietet die Eigenschaft [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) an, mit der Sie externe Schriften angeben können, die mit der Präsentation verwendet werden sollen.

Der folgende JavaScript‑Code zeigt, wie Sie die [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-)‑Eigenschaft nutzen:
```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Arbeiten mit der Präsentation
    // CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts & global\fonts sowie deren Unterordnern stehen der Präsentation zur Verfügung
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Schriften extern verwalten**

Aspose.Slides bietet die Methode [loadExternalFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) an, mit der Sie externe Schriften aus Binärdaten laden können.

Der folgende JavaScript‑Code demonstriert das Laden von Schriften aus einem Byte‑Array:
```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // Externe Schriftart wird während der Laufzeit der Präsentation geladen
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```


## **FAQ**

**Beeinflussen benutzerdefinierte Schriften den Export in alle Formate (PDF, PNG, SVG, HTML)?**

Ja. Angefügte Schriften werden vom Renderer bei allen Exportformaten verwendet.

**Werden benutzerdefinierte Schriften automatisch in die resultierende PPTX eingebettet?**

Nein. Das Registrieren einer Schrift für das Rendering ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schrift in der Präsentationsdatei enthalten sein soll, müssen Sie die expliziten [Einbettungs‑Funktionen](/slides/de/nodejs-java/embedded-font/) nutzen.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schrift bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie [Schriftarten‑Substitution](/slides/de/nodejs-java/font-substitution/), [Ersetzungs‑Regeln](/slides/de/nodejs-java/font-replacement/) und [Fallback‑Sets](/slides/de/nodejs-java/fallback-font/), um genau festzulegen, welche Schrift verwendet wird, wenn die angeforderte Glyphe fehlt.

**Kann ich Schriften in Linux/Docker‑Containern nutzen, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf eigene Schriftordner oder laden Sie Schriften aus Byte‑Arrays. Dadurch entfällt jede Abhängigkeit von System‑Schriftverzeichnissen im Container‑Image.

**Wie sieht es mit Lizenzen aus – kann ich jede benutzerdefinierte Schrift ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenz verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Prüfen Sie stets die Endbenutzer‑Lizenzvereinbarung (EULA) der Schrift, bevor Sie Ausgaben verbreiten.