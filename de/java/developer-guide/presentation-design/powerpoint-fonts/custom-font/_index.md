---
title: Schriftarten in PowerPoint mit Java anpassen
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
- Schriftartenordner
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Passen Sie Schriftarten in PowerPoint-Folien mit Aspose.Slides für Java an, um Ihre Präsentationen klar und konsistent auf jedem Gerät zu halten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, benutzerdefinierte Schriftarten in Präsentationen zu verwenden, ohne sie im Betriebssystem zu installieren. Sie können Schriftarten aus benutzerdefinierten Ordnern laden, Schriftarten für eine bestimmte Präsentation über Dokument‑Ebene‑Schriftquellen bereitstellen oder externe Schriftarten direkt aus Binärdaten laden.

Geladene Schriftarten werden verwendet, wenn eine Präsentation gerendert oder exportiert wird, beispielsweise in PDF, Bilder und andere unterstützte Formate. Dies trägt dazu bei, dass die Ausgabe der Präsentation in verschiedenen Umgebungen konsistent bleibt. Der Artikel erklärt außerdem, wie Sie die von Aspose.Slides verwendeten Schriftartenordner untersuchen und wie Sie den Schriftarten‑Cache nach der Arbeit mit externen Schriftarten leeren können.

Das Registrieren benutzerdefinierter Schriftarten für das Rendering ist von der Einbettung von Schriftarten in eine PPTX‑Datei getrennt. Wenn eine Schriftart innerhalb der Präsentation selbst gespeichert werden muss, verwenden Sie die Schriftart‑Einbettungs‑Funktionen ausdrücklich.

Ein Präsentationsthema kann für einzelne Schriftsysteme unterschiedliche Schriftfamilien referenzieren. Diese Zuordnungen speichern Schriftartnamen, installieren oder laden jedoch nicht die Schriftdateien. Siehe [Script-Specific Theme Fonts](/slides/de/java/script-specific-font-mappings/) zur Verwaltung der Zuordnungen und verwenden Sie die unten genannten Ladeoptionen, um die referenzierten Schriftarten für ein konsistentes Rendering verfügbar zu machen.

{{% alert color="info" title="Note" %}}
Aspose Slides ermöglicht das Laden dieser Schriftarten mit der Methode [loadExternalFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType‑(.ttf)‑ und TrueType‑Collection‑(.ttc)‑Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType‑(.otf)‑Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht das Laden von Schriftarten, die in einer Präsentation verwendet werden, ohne sie im System zu installieren. Dies wirkt sich auf die Exportausgabe aus – z. B. PDF, Bilder und andere unterstützte Formate – sodass die resultierenden Dokumente in verschiedenen Umgebungen konsistent aussehen. Schriftarten werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.
2. Rufen Sie die statische Methode [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) auf, um Schriftarten aus diesen Ordnern zu laden.
3. Laden und rendern/exportieren Sie die Präsentation.
4. Rufen Sie [FontsLoader.clearCache](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#clearCache--) auf, um den Schriftarten‑Cache zu leeren.

Das folgende Codebeispiel demonstriert den Schriftarten‑Ladevorgang:

```java
import com.aspose.slides.*;

// Ordner definieren, die benutzerdefinierte Schriftdateien enthalten.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Load custom fonts from the specified folders.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Präsentation rendern/exportieren (z. B. nach PDF, Bildern oder anderen Formaten) mit den geladenen Schriftarten.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Schriftarten-Cache leeren, nachdem die Arbeit abgeschlossen ist.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) fügt zusätzliche Ordner zu den Schriftart‑Suchpfaden hinzu, ändert jedoch nicht die Reihenfolge der Schriftart‑Initialisierung. Schriftarten werden in folgender Reihenfolge initialisiert:

1. Der standardmäßige Schriftartenpfad des Betriebssystems.
1. Die über [FontsLoader](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/) geladenen Pfade.
{{%/alert %}}

## **Benutzerdefinierte Schriftartenordner abrufen**

Aspose.Slides stellt die Methode [getFontFolders](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#getFontFolders--) bereit, mit der Sie Schriftordner finden können. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode sowie System‑Schriftordner hinzugefügt wurden.

Dieser Java‑Code zeigt, wie Sie [getFontFolders](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#getFontFolders--) verwenden:

```java
import com.aspose.slides.*;

// Diese Zeile gibt Ordner aus, in denen nach Schriftdateien gesucht wird.
// Das sind Ordner, die über die LoadExternalFonts-Methode und System-Schriftordner hinzugefügt wurden.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Angeben benutzerdefinierter Schriftarten, die mit einer Präsentation verwendet werden**

Aspose.Slides stellt die Eigenschaft [setDocumentLevelFontSources](https://reference.aspose.com/slides/de/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) bereit, mit der Sie externe Schriftarten angeben können, die mit der Präsentation verwendet werden.

Dieser Java‑Code zeigt, wie Sie die [setDocumentLevelFontSources](https://reference.aspose.com/slides/de/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)‑Eigenschaft verwenden:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

byte[] memoryFont1 = Files.readAllBytes(Paths.get("customfonts/CustomFont1.ttf"));
byte[] memoryFont2 = Files.readAllBytes(Paths.get("customfonts/CustomFont2.ttf"));

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Mit der Präsentation arbeiten
    // CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts & global\fonts sowie deren Unterordnern stehen der Präsentation zur Verfügung
} finally {
    if (pres != null) pres.dispose();
}
```

## **Schriftarten extern verwalten**

Aspose.Slides stellt die Methode [loadExternalFont](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) bereit, mit der Sie externe Schriftarten aus Binärdaten laden können.

Dieser Java‑Code demonstriert den Ladevorgang von Schriftarten aus einem Byte‑Array:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // externe Schriftart, die während der Lebensdauer der Präsentation geladen wird
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

### Beeinflussen benutzerdefinierte Schriftarten den Export in alle Formate (PDF, PNG, SVG, HTML)?

Ja. Verknüpfte Schriftarten werden vom Renderer in allen Exportformaten verwendet.

### Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?

Nein. Das Registrieren einer Schriftart für das Rendering ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schriftart in der Präsentationsdatei enthalten sein muss, müssen Sie die expliziten [Einbettungs‑Funktionen](/slides/de/java/embedded-font/) verwenden.

### Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?

Ja. Konfigurieren Sie [Schriftart‑Substitution](/slides/de/java/font-substitution/), [Ersetzungsregeln](/slides/de/java/font-replacement/) und [Fallback‑Sets](/slides/de/java/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die gewünschte Glyphe fehlt.

### Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?

Teilweise. Aspose.Slides kann Schriftarten aus eigenen Ordnern oder aus Byte‑Arrays verwenden, ohne sie zu installieren, aber die Java‑Schriftunterstützung benötigt dennoch mindestens eine installierte Schriftart im Image. Ohne diese schlägt das Laden mit dem Fehler „Fontconfig head is null, check your fonts or fonts configuration“ fehl. Siehe [Deploy Fonts](/slides/de/java/deploy-fonts/).

### Wie sieht es mit dem Lizenzieren aus – kann ich jede benutzerdefinierte Schriftart ohne Einschränkungen einbetten?

Sie sind für die Einhaltung der Schriftlizenz verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Überprüfen Sie stets die EULA der Schriftart, bevor Sie Ausgaben verbreiten.