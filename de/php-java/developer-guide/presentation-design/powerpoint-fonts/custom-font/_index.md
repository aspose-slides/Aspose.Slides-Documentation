---
title: Benutzerdefinierte PowerPoint-Schriftart
linktitle: Benutzerdefinierte Schriftart
type: docs
weight: 20
url: /de/php-java/custom-font/
keywords: "Schriftarten, benutzerdefinierte Schriftarten, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "PowerPoint benutzerdefinierte Schriftarten"
---

{{% alert color="primary" %}} 

Aspose Slides ermöglicht es Ihnen, diese Schriftarten mit der Methode [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) zu laden:

* TrueType (.ttf) und TrueType Collection (.ttc) Schriftarten. Siehe [TrueType](https://de.wikipedia.org/wiki/TrueType).

* OpenType (.otf) Schriftarten. Siehe [OpenType](https://de.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Benutzerdefinierte Schriftarten laden**

Aspose.Slides ermöglicht es Ihnen, Schriftarten zu laden, die in Präsentationen gerendert werden, ohne dass diese Schriftarten installiert werden müssen. Die Schriftarten werden aus einem benutzerdefinierten Verzeichnis geladen.

1. Erstellen Sie eine Instanz der Klasse [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) und rufen Sie die Methode [loadExternalFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) auf.
2. Laden Sie die Präsentation, die gerendert werden soll.
3. [Leeren Sie den Cache](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader#clearCache--) in der Klasse [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader).

Dieser PHP-Code demonstriert den Schriftartladeprozess:

```php
  # Ordner, in denen nach Schriftarten gesucht wird
  $folders = array($externalFontsDir );
  # Lädt die Schriftarten aus dem benutzerdefinierten Schriftartverzeichnis
  FontsLoader->loadExternalFonts($folders);
  # Führen Sie einige Arbeiten aus und rendern Sie die Präsentation/Folien
  $pres = new Presentation("DefaultFonts.pptx");
  try {
    $pres->save("NewFonts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
    # Löscht den Schriftart-Cache
    FontsLoader->clearCache();
  }
```

## **Ordner für benutzerdefinierte Schriftarten abrufen**

Aspose.Slides bietet die Methode [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) an, um Schriftartenordner zu finden. Diese Methode gibt Ordner zurück, die über die Methode `LoadExternalFonts` hinzugefügt wurden, sowie Systemschriftartenordner.

Dieser PHP-Code zeigt Ihnen, wie Sie [getFontFolders](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#getFontFolders--) verwenden:

```php
  # Diese Zeile gibt Ordner aus, in denen nach Schriftdateien gesucht wird.
  # Das sind Ordner, die über die Methode LoadExternalFonts hinzugefügt wurden und Systemschriftartenordner.
  $fontFolders = FontsLoader->getFontFolders();

```

## **Benutzerdefinierte Schriftarten für die Präsentation festlegen**

Aspose.Slides bietet die Eigenschaft [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) an, um externe Schriftarten anzugeben, die mit der Präsentation verwendet werden.

Dieser PHP-Code zeigt Ihnen, wie Sie die Eigenschaft [setDocumentLevelFontSources](https://reference.aspose.com/slides/php-java/aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) verwenden:

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
    # Arbeiten Sie mit der Präsentation
    # CustomFont1, CustomFont2 und Schriftarten aus den Ordnern assets\fonts & global\fonts sowie deren Unterordnern sind für die Präsentation verfügbar
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Schriftarten extern verwalten**

Aspose.Slides bietet die Methode [loadExternalFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) an, um externe Schriftarten aus binären Daten zu laden.

Dieser PHP-Code demonstriert den Schriftartladeprozess für ein Byte-Array:

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
      # externe Schriftart während der Lebensdauer der Präsentation geladen
    } finally {
    }
  } finally {
    FontsLoader->clearCache();
  }
```