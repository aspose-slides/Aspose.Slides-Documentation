---
title: PowerPoint-Schriftarten in PHP anpassen
linktitle: Benutzerdefinierte Schriftart
type: docs
weight: 20
url: /de/php-java/custom-font/
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
- PHP
- Aspose.Slides
description: "Passen Sie Schriftarten in PowerPoint-Folien mit Aspose.Slides für PHP via Java an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, benutzerdefinierte Schriftarten in Präsentationen zu verwenden, ohne sie im Betriebssystem zu installieren. Sie können Schriftarten aus benutzerdefinierten Ordnern laden, Schriftarten für eine bestimmte Präsentation über dokumentbezogene Schriftquellen bereitstellen oder externe Schriftarten direkt aus Binärdaten laden.

Geladene Schriftarten werden verwendet, wenn eine Präsentation gerendert oder exportiert wird, beispielsweise nach PDF, Bildern und anderen unterstützten Formaten. Dies trägt dazu bei, die Ausgabe der Präsentation in verschiedenen Umgebungen konsistent zu halten. Der Artikel erklärt außerdem, wie Sie die von Aspose.Slides verwendeten Schriftartenordner inspizieren und wie Sie den Schriftarten-Cache nach der Arbeit mit externen Schriftarten leeren können.

Die Registrierung benutzerdefinierter Schriftarten für das Rendering ist von der Einbettung von Schriftarten in eine PPTX-Datei getrennt. Wenn eine Schriftart innerhalb der Präsentation selbst gespeichert werden muss, verwenden Sie die Einbettungsfunktionen ausdrücklich.

Ein Präsentationsthema kann für einzelne Schriftsysteme verschiedene Schriftfamilien referenzieren. Diese Zuordnungen speichern Schriftartnamen, installieren oder laden jedoch nicht die Schriftartdateien. Siehe [Skript-spezifische Design-Schriftarten](/slides/de/php-java/script-specific-font-mappings/), um die Zuordnungen zu verwalten, und verwenden Sie die unten stehenden Ladeoptionen, um die referenzierten Schriftarten für ein konsistentes Rendering verfügbar zu machen.

{{% alert color="info" title="Hinweis" %}}
Aspose Slides ermöglicht das Laden dieser Schriftarten über die Methode [loadExternalFonts](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf)- und TrueType Collection (.ttc)-Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf)-Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht es Ihnen, Schriftarten, die in einer Präsentation verwendet werden, zu laden, ohne sie im System zu installieren. Dies wirkt sich auf die Exportausgabe aus – beispielsweise PDF, Bilder und andere unterstützte Formate – sodass die resultierenden Dokumente in verschiedenen Umgebungen konsistent aussehen. Schriftarten werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftartdateien enthalten.
2. Rufen Sie die statische Methode [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) auf, um Schriftarten aus diesen Ordnern zu laden.
3. Laden und rendern/exportieren Sie die Präsentation.
4. Rufen Sie [FontsLoader::clearCache](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsloader/#clearCache--) auf, um den Schriftarten-Cache zu leeren.

Das folgende Codebeispiel demonstriert den Schriftarten‑Ladeprozess:

```php
// Definieren Sie Ordner, die benutzerdefinierte Schriftartdateien enthalten.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Laden Sie benutzerdefinierte Schriftarten aus den angegebenen Ordnern.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Rendern/Exportieren Sie die Präsentation (z.B. nach PDF, Bildern oder anderen Formaten) mit den geladenen Schriftarten.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Leeren Sie den Schriftarten-Cache, nachdem die Arbeit abgeschlossen ist.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Hinweis" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) fügt zusätzliche Ordner zu den Schriftarten‑Suchpfaden hinzu, ändert jedoch nicht die Initialisierungsreihenfolge der Schriftarten.
Schriftarten werden in folgender Reihenfolge initialisiert:

1. Der standardmäßige Schriftartpfad des Betriebssystems.
1. Die über [FontsLoader](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsloader/) geladenen Pfade.
{{%/alert %}}

## **Benutzerdefinierte Schriftartenordner abrufen**
Aspose.Slides stellt die Methode [getFontFolders](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsloader/#getFontFolders--) bereit, mit der Sie Schriftartenordner ermitteln können. Diese Methode gibt Ordner zurück, die über die Methode `LoadExternalFonts` hinzugefügt wurden, sowie System‑Schriftartenordner.

Der folgende PHP‑Code zeigt, wie Sie [getFontFolders](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsloader/#getFontFolders--) verwenden:

```php
# Diese Zeile gibt die Ordner aus, in denen nach Schriftartdateien gesucht wird.
# Das sind Ordner, die über die Methode LoadExternalFonts hinzugefügt wurden, sowie System-Schriftartenordner.
$fontFolders = FontsLoader::getFontFolders();
```

## **Benutzerdefinierte Schriftarten für eine Präsentation festlegen**
Aspose.Slides stellt die Methode [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) bereit, mit der Sie externe Schriftarten angeben können, die mit der Präsentation verwendet werden sollen.

Der folgende PHP‑Code zeigt, wie Sie die Methode [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) verwenden:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # Arbeiten mit der Präsentation
    # CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts & global\fonts sowie deren Unterordnern stehen der Präsentation zur Verfügung
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Schriftarten extern verwalten**

Aspose.Slides stellt die Methode [loadExternalFont](https://reference.aspose.com/slides/de/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) bereit, mit der Sie externe Schriftarten aus Binärdaten laden können.

Der folgende PHP‑Code demonstriert den Ladevorgang einer Schriftart aus einem Byte‑Array:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # externe Schriftart während der Laufzeit der Präsentation geladen
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **FAQ**

### Beeinflussen benutzerdefinierte Schriftarten den Export in alle Formate (PDF, PNG, SVG, HTML)?

Ja. Verknüpfte Schriftarten werden vom Renderer bei allen Exportformaten verwendet.

### Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?

Nein. Das Registrieren einer Schriftart zum Rendern ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn Sie die Schriftart in der Präsentationsdatei benötigen, müssen Sie die expliziten [Einbettungsfunktionen](/slides/de/php-java/embedded-font/) verwenden.

### Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?

Ja. Konfigurieren Sie die [Schriftartenersetzung](/slides/de/php-java/font-substitution/), [Ersetzungsregeln](/slides/de/php-java/font-replacement/) und [Fallback‑Sätze](/slides/de/php-java/fallback-font/), um genau festzulegen, welche Schriftart verwendet wird, wenn die angeforderte Glyphe fehlt.

### Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?

Ja. Verweisen Sie auf Ihre eigenen Schriftartenordner oder laden Sie Schriftarten aus Byte‑Arrays. Dadurch entfällt jede Abhängigkeit von systemweiten Schriftartenverzeichnissen im Container‑Image.

### Was ist mit der Lizenzierung – kann ich jede benutzerdefinierte Schriftart ohne Einschränkungen einbetten?

Sie sind für die Einhaltung der Schriftlizenz verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Prüfen Sie stets die Endbenutzerlizenz (EULA) der Schriftart, bevor Sie Ausgaben verteilen.