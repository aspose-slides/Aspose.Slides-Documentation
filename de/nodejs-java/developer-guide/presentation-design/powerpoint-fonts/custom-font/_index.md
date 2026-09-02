---
title: PowerPoint-Schriftarten in JavaScript anpassen
linktitle: Benutzerdefinierte Schriftart
type: docs
weight: 20
url: /de/nodejs-java/custom-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Passen Sie Schriftarten in PowerPoint‑Folien mit JavaScript und Aspose.Slides für Node.js via Java an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---
## **Überblick**

Aspose.Slides ermöglicht es Ihnen, benutzerdefinierte Schriftarten in Präsentationen zu verwenden, ohne sie im Betriebssystem zu installieren. Sie können Schriftarten aus benutzerdefinierten Ordnern laden, Schriftarten für eine bestimmte Präsentation über dokumentebene Schriftquellen bereitstellen oder externe Schriftarten direkt aus Binärdaten laden.

Geladene Schriftarten werden verwendet, wenn eine Präsentation gerendert oder exportiert wird, zum Beispiel nach PDF, Bildern und anderen unterstützten Formaten. Dies trägt dazu bei, dass die Ausgabe der Präsentation über verschiedene Umgebungen hinweg konsistent bleibt. Der Artikel erklärt außerdem, wie Sie die von Aspose.Slides verwendeten Schriftordner untersuchen und den Schriftarten‑Cache nach der Arbeit mit externen Schriftarten leeren können.

Das Registrieren benutzerdefinierter Schriftarten zum Rendern ist getrennt vom Einbetten von Schriftarten in eine PPTX‑Datei. Wenn eine Schriftart innerhalb der Präsentation gespeichert werden muss, verwenden Sie die Funktionen zum Einbetten von Schriftarten explizit.

Ein Präsentationsthema kann für einzelne Schriftsysteme unterschiedliche Schriftfamilien referenzieren. Diese Zuordnungen speichern Schriftartnamen, installieren oder laden jedoch keine Schriftdateien. Siehe [Skriptspezifische Themen-Schriftarten](/slides/de/nodejs-java/script-specific-font-mappings/) zur Verwaltung der Zuordnungen und verwenden Sie die untenstehenden Ladeoptionen, um die referenzierten Schriftarten für einheitliches Rendern verfügbar zu machen.

{{% alert color="info" title="Hinweis" %}}
Aspose Slides ermöglicht das Laden dieser Schriftarten über die Methode [loadExternalFonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType‑(.ttf) und TrueType‑Collection‑(.ttc) Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType‑(.otf) Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht es Ihnen, Schriftarten zu laden, die in einer Präsentation verwendet werden, ohne sie im System zu installieren. Dies wirkt sich auf die Exportausgabe aus – etwa PDF, Bilder und andere unterstützte Formate – sodass die resultierenden Dokumente über verschiedene Umgebungen hinweg konsistent aussehen. Schriftarten werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.
2. Rufen Sie die statische Methode [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) auf, um Schriftarten aus diesen Ordnern zu laden.
3. Laden und rendern/exportieren Sie die Präsentation.
4. Rufen Sie [FontsLoader.clearCache](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsloader/clearcache/) auf, um den Schriftarten‑Cache zu leeren.

Das folgende Code‑Beispiel demonstriert den Schriftarten‑Ladevorgang:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Definieren Sie Ordner, die benutzerdefinierte Schriftdateien enthalten.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Laden Sie benutzerdefinierte Schriftarten aus den angegebenen Ordnern.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Rendern/Exportieren Sie die Präsentation (z. B. nach PDF, Bildern oder anderen Formaten) mithilfe der geladenen Schriftarten.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Löschen Sie den Schriftarten-Cache, nachdem die Arbeit abgeschlossen ist.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Hinweis" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) fügt zusätzliche Ordner zu den Schriftart‑Suchpfaden hinzu, ändert jedoch nicht die Initialisierungsreihenfolge der Schriftarten. Schriftarten werden in folgender Reihenfolge initialisiert:

1. Der standardmäßige Schriftartenpfad des Betriebssystems.
1. Die über [FontsLoader](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsloader/) geladenen Pfade.
{{%/alert %}}

## **Benutzerdefinierten Schriftarten‑Ordner abrufen**
Aspose.Slides stellt die Methode [getFontFolders](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) bereit, mit der Sie Schriftordner finden können. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode sowie Systemschriftordner hinzugefügt wurden.

Dieser JavaScript‑Code zeigt, wie Sie [getFontFolders](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) verwenden:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Diese Zeile gibt Ordner aus, in denen nach Schriftdateien gesucht wird.
// Das sind Ordner, die über die LoadExternalFonts-Methode und System-Schriftordner hinzugefügt wurden.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Benutzerdefinierte Schriftarten für die Präsentation festlegen**
Aspose.Slides stellt die Eigenschaft [setDocumentLevelFontSources](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) zur Verfügung, mit der Sie externe Schriftarten angeben können, die mit der Präsentation verwendet werden.

Dieser JavaScript‑Code zeigt, wie Sie die [setDocumentLevelFontSources](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-)‑Eigenschaft verwenden:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Arbeiten mit der Präsentation
    // CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts & global\fonts sowie deren Unterordner stehen der Präsentation zur Verfügung
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Schriftarten extern verwalten**

Aspose.Slides bietet die Methode [loadExternalFont](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) an, mit der Sie externe Schriftarten aus Binärdaten laden können.

Dieser JavaScript‑Code demonstriert den Ladevorgang einer Schriftart aus einem Byte‑Array:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // externe Schriftart, die während der Lebensdauer der Präsentation geladen wird
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

### Beeinflussen benutzerdefinierte Schriftarten den Export in alle Formate (PDF, PNG, SVG, HTML)?

Ja. Verbundene Schriftarten werden vom Renderer in allen Exportformaten verwendet.

### Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?

Nein. Das Registrieren einer Schriftart zum Rendern ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schriftart in der Präsentationsdatei enthalten sein soll, müssen Sie die expliziten [Einbettungs‑Funktionen](/slides/de/nodejs-java/embedded-font/) verwenden.

### Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?

Ja. Konfigurieren Sie [Schriftarten‑Substitution](/slides/de/nodejs-java/font-substitution/), [Ersetzungsregeln](/slides/de/nodejs-java/font-replacement/) und [Fallback‑Sätze](/slides/de/nodejs-java/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die gewünschte Glyphe fehlt.

### Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?

Ja. Verweisen Sie auf Ihre eigenen Schriftordner oder laden Sie Schriftarten aus Byte‑Arrays. Dadurch entfällt jede Abhängigkeit von systemeigenen Schriftverzeichnissen im Container‑Image.

### Wie sieht es mit Lizenzierung aus – kann ich irgendeine benutzerdefinierte Schriftart ohne Einschränkungen einbetten?

Sie sind für die Einhaltung der Schriftlizenzierung verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Überprüfen Sie stets die EULA der Schriftart, bevor Sie Ausgaben verbreiten.