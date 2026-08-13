---
title: PowerPoint-Schriftarten auf Android anpassen
linktitle: Benutzerdefinierte Schriftart
type: docs
weight: 20
url: /de/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "Passen Sie Schriftarten in PowerPoint-Folien mit Aspose.Slides für Android via Java an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, benutzerdefinierte Schriftarten in Präsentationen zu verwenden, ohne sie im Betriebssystem zu installieren. Sie können Schriftarten aus benutzerdefinierten Ordnern laden, Schriftarten für eine bestimmte Präsentation über dokumentenbezogene Schriftquellen bereitstellen oder externe Schriftarten direkt aus Binärdaten laden.

Geladene Schriftarten werden verwendet, wenn eine Präsentation gerendert oder exportiert wird, beispielsweise nach PDF, Bildern und anderen unterstützten Formaten. Dadurch bleibt die Ausgabe der Präsentation in verschiedenen Umgebungen konsistent. Der Artikel erklärt außerdem, wie Sie die von Aspose.Slides verwendeten Schriftordner prüfen und den Schriftarten‑Cache nach der Arbeit mit externen Schriftarten leeren können.

Das Registrieren benutzerdefinierter Schriftarten für das Rendering ist getrennt vom Einbetten von Schriftarten in eine PPTX‑Datei. Wenn eine Schriftart innerhalb der Präsentation gespeichert werden muss, verwenden Sie die Schriftart‑Einbettungsfunktionen explizit.

{{% alert color="info" %}} 
Aspose Slides ermöglicht es Ihnen, diese Schriftarten mit der [loadExternalFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) Methode zu laden:

* TrueType (.ttf)- und TrueType Collection (.ttc)-Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf)-Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht es Ihnen, in einer Präsentation verwendete Schriftarten zu laden, ohne sie im System zu installieren. Dies wirkt sich auf die Exportausgabe aus – beispielsweise PDF, Bilder und andere unterstützte Formate –, sodass die resultierenden Dokumente in verschiedenen Umgebungen konsistent aussehen. Schriftarten werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.  
2. Rufen Sie die statische Methode [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) auf, um Schriftarten aus diesen Ordnern zu laden.  
3. Laden und rendern/exportieren Sie die Präsentation.  
4. Rufen Sie [FontsLoader.clearCache](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/FontsLoader#clearCache--) auf, um den Schriftarten‑Cache zu leeren.

Das folgende Codebeispiel demonstriert den Schriftarten‑Ladevorgang:

```java
import com.aspose.slides.*;

// Definieren Sie Ordner, die benutzerdefinierte Schriftdateien enthalten.
String externalFontFolder1 = "assets/fonts";
String externalFontFolder2 = "global/fonts";

String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

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

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) fügt zusätzliche Ordner zu den Schriftart‑Suchpfaden hinzu, ändert jedoch nicht die Initialisierungsreihenfolge der Schriftarten.  
Schriftarten werden in folgender Reihenfolge initialisiert:

1. Der standardmäßige Schriftartenpfad des Betriebssystems.  
2. Die über [FontsLoader](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsloader/) geladenen Pfade.  
{{%/alert %}}

## **Benutzerdefinierte Schriftordner abrufen**
Aspose.Slides stellt die Methode [getFontFolders](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) bereit, mit der Sie Schriftordner finden können. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode sowie System‑Schriftordner hinzugefügt wurden.

Dieser Java‑Code zeigt, wie Sie [getFontFolders](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) verwenden:

```java
import com.aspose.slides.*;

// Diese Zeile gibt Ordner aus, in denen nach Schriftdateien gesucht wird.
// Das sind Ordner, die über die LoadExternalFonts-Methode und System-Schriftordner hinzugefügt wurden.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Benutzerdefinierte Schriftarten für eine Präsentation angeben**
Aspose.Slides stellt die Eigenschaft [setDocumentLevelFontSources](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) bereit, mit der Sie externe Schriftarten angeben können, die mit der Präsentation verwendet werden.

Dieser Java‑Code zeigt, wie Sie die Eigenschaft [setDocumentLevelFontSources](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) verwenden:

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

Aspose.Slides stellt die Methode [loadExternalFont](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) bereit, mit der Sie externe Schriftarten aus Binärdaten laden können.

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
        // Externe Schriftart, die während der Lebensdauer der Präsentation geladen wird
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

Ja. Verbundene Schriftarten werden vom Renderer in allen Exportformaten verwendet.

### Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?

Nein. Das Registrieren einer Schriftart für das Rendering ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schriftart in der Präsentationsdatei enthalten sein muss, müssen Sie die expliziten [Einbettungs‑Funktionen](/slides/de/androidjava/embedded-font/) verwenden.

### Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?

Ja. Konfigurieren Sie [Schriftart‑Ersetzung](/slides/de/androidjava/font-substitution/), [Ersetzungsregeln](/slides/de/androidjava/font-replacement/) und [Fallback‑Sätze](/slides/de/androidjava/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die gewünschte Glyphe fehlt.

### Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?

Ja. Verweisen Sie auf eigene Schriftordner oder laden Sie Schriftarten aus Byte‑Arrays. Dadurch entfällt jede Abhängigkeit von systemweiten Schriftverzeichnissen im Container‑Image.

### Wie sieht es mit Lizenzen aus – kann ich jede benutzerdefinierte Schriftart ohne Einschränkungen einbetten?

Sie sind für die Einhaltung der Schriftlizenz verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Überprüfen Sie stets die EULA der Schriftart, bevor Sie Ausgaben verbreiten.