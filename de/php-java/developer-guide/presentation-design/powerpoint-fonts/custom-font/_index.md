---
title: PowerPoint-Schriften in PHP anpassen
linktitle: Benutzerdefinierte Schrift
type: docs
weight: 20
url: /de/php-java/custom-font/
keywords:
- Schrift
- benutzerdefinierte Schrift
- externe Schrift
- Schrift laden
- Schriften verwalten
- Schriftordner
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Passen Sie Schriften in PowerPoint-Folien mit Aspose.Slides für PHP über Java an, um Ihre Präsentationen auf jedem Gerät scharf und konsistent zu halten."
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht das Laden dieser Schriftarten mit der [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑Methode:

* TrueType (.ttf) und TrueType Collection (.ttc) Schriftarten. Siehe [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) Schriftarten. Siehe [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht das Laden von Schriftarten, die in Präsentationen gerendert werden, ohne diese Schriftarten installieren zu müssen. Die Schriftarten werden aus einem benutzerdefinierten Verzeichnis geladen. 

1. Erstellen Sie eine Instanz der [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/)‑Klasse und rufen Sie die [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---)‑Methode auf.
2. Laden Sie die zu rendernde Präsentation.
3. [Clear the cache](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader#clearCache--) in der [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader)‑Klasse.

Dieser PHP‑Code demonstriert den Schriftarten‑Ladevorgang:
```php
  # Ordner, in denen nach Schriften gesucht wird
  $folders = array($externalFontsDir );
  # Lädt die Schriften aus dem benutzerdefinierten Schriftverzeichnis
  FontsLoader->loadExternalFonts($folders);
  # Führe einige Arbeiten aus und rendere die Präsentation/Folien
  $pres = new Presentation("DefaultFonts.pptx");
  try {
    $pres->save("NewFonts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
    # Leert den Schrift-Cache
    FontsLoader->clearCache();
  }
```


## **Benutzerdefinierte Schriftordner abrufen**
Aspose.Slides stellt die [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--)‑Methode bereit, mit der Sie Schriftordner finden können. Diese Methode gibt Ordner zurück, die über die `LoadExternalFonts`‑Methode sowie System‑Schriftordner hinzugefügt wurden.

Dieser PHP‑Code zeigt, wie Sie [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) verwenden:
```php
  # Diese Zeile gibt die Ordner aus, in denen nach Schriftdateien gesucht wird.
  # Dies sind Ordner, die über die LoadExternalFonts-Methode und System-Schriftordner hinzugefügt wurden.
  $fontFolders = FontsLoader->getFontFolders();
```


## **Benutzerdefinierte Schriftarten für eine Präsentation festlegen**
Aspose.Slides stellt die [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)‑Eigenschaft zur Verfügung, mit der Sie externe Schriftarten festlegen können, die in der Präsentation verwendet werden.

Dieser PHP‑Code zeigt, wie Sie die [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-)‑Eigenschaft verwenden:
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


## **Schriftarten extern verwalten**

Aspose.Slides stellt die [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data)‑Methode bereit, mit der Sie externe Schriftarten aus Binärdaten laden können.

Dieser PHP‑Code demonstriert den Ladevorgang von Schriftarten aus einem Byte‑Array:
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
      # externe Schriftart wird während der Lebensdauer der Präsentation geladen
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```


## **FAQ**

**Beeinflussen benutzerdefinierte Schriftarten den Export in alle Formate (PDF, PNG, SVG, HTML)?**

Ja. Verbundene Schriftarten werden vom Renderer in allen Exportformaten verwendet.

**Werden benutzerdefinierte Schriftarten automatisch in die resultierende PPTX eingebettet?**

Nein. Das Registrieren einer Schriftart zum Rendern ist nicht dasselbe wie das Einbetten in eine PPTX. Wenn die Schriftart in der Präsentationsdatei enthalten sein soll, müssen Sie die expliziten Einbettungs‑Funktionen verwenden.

**Kann ich das Fallback‑Verhalten steuern, wenn einer benutzerdefinierten Schriftart bestimmte Glyphen fehlen?**

Ja. Konfigurieren Sie die Schriftart‑Substitution, Ersetzungsregeln und Fallback‑Sätze, um exakt zu bestimmen, welche Schriftart verwendet wird, wenn die angeforderte Glyphe fehlt.

**Kann ich Schriftarten in Linux/Docker‑Containern verwenden, ohne sie systemweit zu installieren?**

Ja. Zeigen Sie auf Ihre eigenen Schriftordner oder laden Sie Schriftarten aus Byte‑Arrays. So entfällt jede Abhängigkeit von System‑Schriftverzeichnissen im Container‑Image.

**Wie sieht es mit Lizenzierung aus – kann ich jede benutzerdefinierte Schriftart ohne Einschränkungen einbetten?**

Sie sind für die Einhaltung der Schriftlizenz verantwortlich. Die Bedingungen variieren; einige Lizenzen verbieten das Einbetten oder die kommerzielle Nutzung. Prüfen Sie stets die EULA der Schriftart, bevor Sie Ausgaben verbreiten.