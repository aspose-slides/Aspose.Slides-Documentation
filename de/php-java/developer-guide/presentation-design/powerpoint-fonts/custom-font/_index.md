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
description: "Passen Sie Schriftarten in PowerPoint-Folien mit Aspose.Slides für PHP über Java an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht das Laden dieser Schriftarten über die [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑Methode:

* TrueType‑Schriftarten (.ttf) und TrueType‑Sammlungen (.ttc). Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType‑Schriftarten (.otf). Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides ermöglicht das Laden von in einer Präsentation verwendeten Schriftarten, ohne sie im System zu installieren. Dies wirkt sich auf Exportausgaben – etwa PDF, Bilder und andere unterstützte Formate – aus, sodass die resultierenden Dokumente in verschiedenen Umgebungen konsistent aussehen. Schriftarten werden aus benutzerdefinierten Verzeichnissen geladen.

1. Geben Sie einen oder mehrere Ordner an, die die Schriftdateien enthalten.
2. Rufen Sie die statische [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/)‑Methode auf, um Schriftarten aus diesen Ordnern zu laden.
3. Laden und rendern/exportieren Sie die Präsentation.
4. Rufen Sie [FontsLoader::clearCache](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/clearcache/) auf, um den Schriftarten‑Cache zu leeren.

Das folgende Codebeispiel demonstriert den Schriftarten‑Ladevorgang:
```php
// Definieren Sie Ordner, die benutzerdefinierte Schriftartdateien enthalten.
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Laden Sie benutzerdefinierte Schriftarten aus den angegebenen Ordnern.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentation = new Presentation("sample.pptx");
    
    // Rendern/Exportieren Sie die Präsentation (z. B. nach PDF, Bildern oder anderen Formaten) mit den geladenen Schriftarten.
    $presentation->save("output.pdf", SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Löschen Sie den Schriftarten-Cache, nachdem die Arbeit abgeschlossen ist.
    FontsLoader::clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/loadexternalfonts/) fügt zusätzliche Ordner zu den Schriftarten‑Suchpfaden hinzu, ändert jedoch nicht die Initialisierungsreihenfolge der Schriftarten.
Schriftarten werden in folgender Reihenfolge initialisiert:

1. Der standardmäßige Betriebssystem‑Schriftpfad.
1. Die über [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) geladenen Pfade.

{{%/alert %}}

## **Get Custom Font Folders**
Aspose.Slides stellt die [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--)‑Methode bereit, mit der Sie Schriftordner ermitteln können. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode und System‑Schriftordner hinzugefügt wurden.

Der folgende PHP‑Code zeigt, wie Sie [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) verwenden:
```php
  # Diese Zeile gibt die Ordner aus, in denen nach Schriftdateien gesucht wird.
  # Das sind Ordner, die über die LoadExternalFonts-Methode und System-Schriftordner hinzugefügt wurden.
  $fontFolders = FontsLoader->getFontFolders();
```


## **Specify Custom Fonts Used with a Presentation**
Aspose.Slides stellt die [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDocumentLevelFontSources)‑Methode bereit, mit der Sie externe Schriftarten festlegen können, die mit der Präsentation verwendet werden sollen.

Der folgende PHP‑Code zeigt, wie Sie die [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDocumentLevelFontSources)‑Methode einsetzen:
```php
  $Array = new JavaClass("java.lang.reflect.Array");
  $Byte = new JavaClass("java.lang.Byte");
  $file1 = new Java("java.io.File", "customfonts/CustomFont1.ttf");
  $memoryFont1 = $Array->newInstance($Byte, $Array->getLength($file1));
  try {
      $dis1 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file1));
      $dis1->readFully($memoryFont1);
  } finally {
      if (!java_is_null($dis1)) $dis1->close();
  }
  $file2 = new Java("java.io.File", "customfonts/CustomFont2.ttf");
  $memoryFont2 = $Array->newInstance($Byte, $Array->getLength($file2));
  try {
        $dis2 = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file2));
        $dis2->readFully($memoryFont2);
  } finally {
        if (!java_is_null($dis2)) $dis2->close();
  }
  $loadOptions = new LoadOptions();
  $loadOptions->getDocumentLevelFontSources()->setFontFolders(array("assets/fonts", "global/fonts" ));
  $loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));
  $pres = new Presentation("MyPresentation.pptx", $loadOptions);
  try {
    # Arbeiten mit der Präsentation
    # CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts & global\fonts sowie deren Unterordnern stehen der Präsentation zur Verfügung
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Manage Fonts Externally**

Aspose.Slides stellt die [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)‑Methode bereit, mit der Sie externe Schriftarten aus Binärdaten laden können.

Der folgende PHP‑Code demonstriert das Laden von Schriftarten aus einem Byte‑Array:
```php
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALN.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNBI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "ARIALNI.TTF"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
  FontsLoader->loadExternalFont($bytes);

  try {
    $pres = new Presentation("");
    try {
      # externe Schriftart, die während der Laufzeit der Präsentation geladen wird
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```


## **FAQ**

**Wirken sich benutzerdefinierte Schriftarten auf den Export in alle Formate (PDF, PNG, SVG, HTML) aus?**

Ja. Verbundene Schriftarten werden vom Renderer bei allen Exportformaten verwendet.

**Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?**

Nein. Das Registrieren einer Schriftart zum Rendern ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schriftart in der Präsentationsdatei enthalten sein soll, müssen Sie die expliziten [Embedding‑Funktionen](/slides/de/php-java/embedded-font/) nutzen.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie [Font‑Substitution](/slides/de/php-java/font-substitution/), [Replacement‑Rules](/slides/de/php-java/font-replacement/) und [Fallback‑Sets](/slides/de/php-java/fallback-font/), um exakt festzulegen, welche Schriftart verwendet wird, wenn die gewünschte Glyphe fehlt.

**Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Zeigen Sie auf Ihre eigenen Schriftordner oder laden Sie Schriftarten aus Byte‑Arrays. Das eliminiert jede Abhängigkeit von systemweiten Schriftverzeichnissen im Container‑Image.

**Wie steht es um die Lizenzierung – kann ich jede benutzerdefinierte Schriftart ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenz verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Prüfen Sie stets die EULA der jeweiligen Schriftart, bevor Sie Ausgaben verbreiten.