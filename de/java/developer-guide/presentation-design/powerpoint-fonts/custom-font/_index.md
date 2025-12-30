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

Aspose Slides ermöglicht das Laden dieser Schriftarten über die Methode [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) und TrueType Collection (.ttc) Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht das Laden von Schriftarten, die in einer Präsentation verwendet werden, ohne sie im System zu installieren. Dies wirkt sich auf die Exportausgabe aus – beispielsweise PDF, Bilder und andere unterstützte Formate – sodass die resultierenden Dokumente in verschiedenen Umgebungen konsistent aussehen. Schriftarten werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.  
2. Rufen Sie die statische Methode [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) auf, um Schriftarten aus diesen Ordnern zu laden.  
3. Laden und rendern/exportieren Sie die Präsentation.  
4. Rufen Sie [FontsLoader.clearCache](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) auf, um den Schriftarten‑Cache zu leeren.

Das folgende Codebeispiel demonstriert den Schriftarten‑Ladevorgang:
```java
// Definieren Sie Ordner, die benutzerdefinierte Schriftdateien enthalten.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Laden Sie benutzerdefinierte Schriftarten aus den angegebenen Ordnern.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Rendern/Exportieren Sie die Präsentation (z. B. zu PDF, Bildern oder anderen Formaten) mit den geladenen Schriftarten.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Löschen Sie den Schriftarten-Cache, nachdem die Arbeit abgeschlossen ist.
    FontsLoader.clearCache();
}
```


{{% alert color="info" title="Hinweis" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) fügt zusätzliche Ordner zu den Schriftart‑Suchpfaden hinzu, ändert jedoch nicht die Initialisierungsreihenfolge der Schriftarten.  
Schriftarten werden in dieser Reihenfolge initialisiert:

1. Der standardmäßige Schriftartenpfad des Betriebssystems.  
1. Die über [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) geladenen Pfade.

{{%/alert %}}

## **Benutzerdefinierte Schriftartenordner abrufen**
Aspose.Slides stellt die Methode [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) bereit, mit der Sie Schriftartenordner finden können. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode und System‑Schriftordner hinzugefügt wurden.

Dieser Java‑Code zeigt, wie Sie [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) verwenden:
```java
// Diese Zeile gibt Ordner aus, in denen nach Schriftdateien gesucht wird.
// Dies sind Ordner, die über die Methode LoadExternalFonts und System-Schriftordner hinzugefügt wurden.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **Benutzerdefinierte Schriftarten für eine Präsentation festlegen**
Aspose.Slides stellt die Eigenschaft [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) bereit, mit der Sie externe Schriftarten angeben können, die mit der Präsentation verwendet werden. 

Dieser Java‑Code zeigt, wie Sie die Eigenschaft [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) verwenden:
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

Dieser Java‑Code demonstriert den Ladevorgang von Schriftarten aus einem Byte‑Array:
```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // während der Laufzeit der Präsentation geladene externe Schriftart
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```


## **FAQ**

**Wirken sich benutzerdefinierte Schriftarten auf den Export in alle Formate (PDF, PNG, SVG, HTML) aus?**

Ja. Verbundene Schriftarten werden vom Renderer in allen Exportformaten verwendet.

**Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?**

Nein. Das Registrieren einer Schriftart für das Rendering ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn Sie die Schriftart in der Präsentationsdatei benötigen, müssen Sie die expliziten [Einbettungsfunktionen](/slides/de/java/embedded-font/) verwenden.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie die [Schriftart‑Substitution](/slides/de/java/font-substitution/), [Ersetzungsregeln](/slides/de/java/font-replacement/) und [Fallback‑Sätze](/slides/de/java/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die angeforderte Glyphe fehlt.

**Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Verweisen Sie auf Ihre eigenen Schriftartenordner oder laden Sie Schriftarten aus Byte‑Arrays. Dadurch entfällt jede Abhängigkeit von System‑Schriftordnern im Container‑Image.

**Wie sieht es mit der Lizenzierung aus – kann ich beliebige benutzerdefinierte Schriftarten ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenzierung verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Überprüfen Sie stets die EULA der Schriftart, bevor Sie Ausgaben verbreiten.