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
- Schriftartordner
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Passen Sie Schriftarten in PowerPoint-Folien mit Aspose.Slides für Java an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, benutzerdefinierte Schriftarten in Präsentationen zu verwenden, ohne sie im Betriebssystem zu installieren. Sie können Schriftarten aus benutzerdefinierten Ordnern laden, Schriftarten für eine bestimmte Präsentation über dokumentbezogene Schriftquellen bereitstellen oder externe Schriftarten direkt aus Binärdaten laden.

Geladene Schriftarten werden verwendet, wenn eine Präsentation gerendert oder exportiert wird, zum Beispiel nach PDF, Bildern und anderen unterstützten Formaten. Dies hilft, die Ausgabe der Präsentation in verschiedenen Umgebungen konsistent zu halten. Der Artikel erklärt auch, wie Sie die von Aspose.Slides verwendeten Schriftordner inspizieren und wie Sie den Schriftarten‑Cache nach der Arbeit mit externen Schriftarten leeren können.

Das Registrieren benutzerdefinierter Schriftarten für das Rendering ist getrennt vom Einbetten von Schriftarten in eine PPTX‑Datei. Wenn eine Schriftart in der Präsentation selbst gespeichert werden muss, verwenden Sie die Schriftart‑Einbettungsfunktionen explizit.

{{% alert color="info" %}} 

Aspose Slides ermöglicht das Laden dieser Schriftarten über die [loadExternalFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑Methode:

* TrueType‑Schriftarten (.ttf) und TrueType‑Collection‑Schriftarten (.ttc). Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑Schriftarten (.otf). Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht es Ihnen, Schriftarten zu laden, die in einer Präsentation verwendet werden, ohne sie im System zu installieren. Dies wirkt sich auf das Export‑Ergebnis aus – etwa PDF, Bilder und andere unterstützte Formate – sodass die erzeugten Dokumente in verschiedenen Umgebungen konsistent aussehen. Schriftarten werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.  
2. Rufen Sie die statische [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑Methode auf, um Schriftarten aus diesen Ordnern zu laden.  
3. Laden und rendern/exportieren Sie die Präsentation.  
4. Rufen Sie [FontsLoader.clearCache](https://reference.aspose.com/slides/de/java/com.aspose.slides/FontsLoader#clearCache--) auf, um den Schriftarten‑Cache zu leeren.

Das folgende Code‑Beispiel demonstriert den Schriftarten‑Ladevorgang:

```java
import com.aspose.slides.*;

// Definieren Sie Ordner, die benutzerdefinierte Schriftdateien enthalten.
String[] fontFolders = new String[] { "assets/fonts", "global/fonts" };

// Laden Sie benutzerdefinierte Schriftarten aus den angegebenen Ordnern.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");

    // Rendern/Exportieren Sie die Präsentation (z. B. nach PDF, Bildern oder anderen Formaten) mit den geladenen Schriftarten.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Leeren Sie den Schriftarten-Cache, nachdem die Arbeit abgeschlossen ist.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Hinweis" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) fügt zusätzliche Ordner zu den Schriftarten‑Suchpfaden hinzu, ändert aber nicht die Reihenfolge der Schriftarten‑Initialisierung.  
Schriftarten werden in dieser Reihenfolge initialisiert:

1. Der Standardschriftpfad des Betriebssystems.  
1. Die über [FontsLoader](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/) geladenen Pfade.

{{%/alert %}}

## **Benutzerdefinierte Schriftordner abrufen**

Aspose.Slides stellt die [getFontFolders](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#getFontFolders--)‑Methode bereit, mit der Sie Schriftordner ermitteln können. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode hinzugefügt wurden, sowie System‑Schriftordner.

Dieser Java‑Code zeigt, wie Sie [getFontFolders](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#getFontFolders--) verwenden:

```java
import com.aspose.slides.*;

// Diese Zeile gibt Ordner aus, in denen nach Schriftdateien gesucht wird.
// Das sind Ordner, die über die LoadExternalFonts-Methode und System-Schriftordner hinzugefügt wurden.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Benutzerdefinierte Schriftarten für eine Präsentation festlegen**

Aspose.Slides bietet die [setDocumentLevelFontSources](https://reference.aspose.com/slides/de/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)‑Eigenschaft, mit der Sie externe Schriftarten angeben können, die mit der Präsentation verwendet werden sollen.

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
    // Arbeiten mit der Präsentation
    // CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts & global\fonts sowie deren Unterordnern stehen der Präsentation zur Verfügung
} finally {
    if (pres != null) pres.dispose();
}
```

## **Schriftarten extern verwalten**

Aspose.Slides stellt die [loadExternalFont](https://reference.aspose.com/slides/de/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)‑Methode bereit, mit der Sie externe Schriftarten aus Binärdaten laden können.

Dieser Java‑Code demonstriert den Ladevorgang einer Schriftart aus einem Byte‑Array:

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

### Wirken sich benutzerdefinierte Schriftarten auf den Export in alle Formate (PDF, PNG, SVG, HTML) aus?

Ja. Eingebundene Schriftarten werden vom Renderer in allen Export‑Formaten verwendet.

### Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?

Nein. Das Registrieren einer Schriftart zum Rendern ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schriftart in der Präsentationsdatei selbst enthalten sein soll, müssen Sie die expliziten [Einbettungs‑Features](/slides/de/java/embedded-font/) nutzen.

### Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?

Ja. Konfigurieren Sie die [Schriftart‑Substitution](/slides/de/java/font-substitution/), [Ersetzungsregeln](/slides/de/java/font-replacement/) und [Fallback‑Sets](/slides/de/java/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die angeforderte Glyphe fehlt.

### Kann ich Schriftarten in Linux/Docker‑Containern nutzen, ohne sie systemweit zu installieren?

Ja. Verweisen Sie auf Ihre eigenen Schriftordner oder laden Sie Schriftarten aus Byte‑Arrays. Damit entfällt jede Abhängigkeit von systemweiten Schriftverzeichnissen im Container‑Image.

### Wie sieht es mit Lizenzierung aus – kann ich beliebige benutzerdefinierte Schriftarten ohne Einschränkungen einbetten?

Sie sind für die Einhaltung der Schrift‑Lizenzbedingungen verantwortlich. Die Bedingungen variieren; einige Lizenzen untersagen das Einbetten oder die kommerzielle Nutzung. Prüfen Sie stets die EULA der jeweiligen Schriftart, bevor Sie Ausgaben verteilen.