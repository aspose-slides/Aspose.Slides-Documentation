---
title: Embed Fonts in Presentations Using PHP
linktitle: Schrift einbetten
type: docs
weight: 40
url: /de/php-java/embedded-font/
keywords:
- Schrift hinzufügen
- Schrift einbetten
- Schrifteinbettung
- eingebettete Schrift abrufen
- eingebettete Schrift hinzufügen
- eingebettete Schrift entfernen
- eingebettete Schrift komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "TrueType-Schriften in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP über Java einbetten, um eine genaue Wiedergabe auf allen Plattformen zu gewährleisten."
---

**Eingebettete Schriften in PowerPoint** sind nützlich, wenn Sie möchten, dass Ihre Präsentation auf jedem System oder Gerät korrekt angezeigt wird. Wenn Sie aufgrund kreativer Gestaltung eine Drittanbieter‑ oder nicht standardmäßige Schriftart verwendet haben, haben Sie noch mehr Gründe, Ihre Schriftart einzubetten. Andernfalls (ohne eingebettete Schriften) können sich Texte oder Zahlen auf Ihren Folien, das Layout, die Formatierung usw. ändern oder in unleserliche Rechtecke verwandeln.  

Die Klasse [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager), die Klasse [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) und die Klasse [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) enthalten die meisten Methoden, die Sie benötigen, um mit eingebetteten Schriften in PowerPoint‑Präsentationen zu arbeiten.

## **Eingebettete Schriften abrufen und entfernen**

Aspose.Slides stellt die Methode [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) (bereitgestellt von der Klasse [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)) zur Verfügung, mit der Sie die in einer Präsentation eingebetteten Schriften abrufen (oder herausfinden) können. Um Schriften zu entfernen, wird die Methode [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) (ebenfalls von derselben Klasse bereitgestellt) verwendet.

Dieser PHP‑Code zeigt Ihnen, wie Sie eingebettete Schriften aus einer Präsentation abrufen und entfernen:
```php
  # Instanziiert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Rendert eine Folie, die einen Textframe enthält, der die eingebettete "FunSized"-Schrift verwendet
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Speichert das Bild auf der Festplatte im JPEG-Format
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Lädt alle eingebetteten Schriften
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Findet die "Calibri"-Schrift
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # Entfernt die "Calibri"-Schrift
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Rendert die Präsentation; "Calibri"-Schrift wird durch eine vorhandene ersetzt
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Speichert das Bild auf der Festplatte im JPEG-Format
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Speichert die Präsentation ohne die eingebettete "Calibri"-Schrift auf der Festplatte
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eingebettete Schriften hinzufügen**

Durch die Verwendung der Klasse [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) und zweier Überladungen der Methode [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) können Sie die gewünschte Einbettungsregel auswählen, um Schriften in eine Präsentation einzubetten. Dieser PHP‑Code zeigt Ihnen, wie Sie Schriften in einer Präsentation einbetten und hinzufügen:
```php
  # Lädt die Präsentation
  $pres = new Presentation("Fonts.pptx");
  try {
    $allFonts = $pres->getFontsManager()->getFonts();
    $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
    $Array = new java_class("java.lang.reflect.Array");
    foreach($allFonts as $font) {
      $embeddedFontsContainsFont = false;
      for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
        if ($embeddedFonts[$i]->equals($font)) {
          $embeddedFontsContainsFont = true;
          break;
        }
      }
      if (!$embeddedFontsContainsFont) {
        $pres->getFontsManager()->addEmbeddedFont($font, EmbedFontCharacters->All);
        $embeddedFonts = $pres->getFontsManager()->getEmbeddedFonts();
      }
    }
    # Speichert die Präsentation auf der Festplatte
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eingebettete Schriften komprimieren**

Um Ihnen zu ermöglichen, die in einer Präsentation eingebetteten Schriften zu komprimieren und die Dateigröße zu reduzieren, bietet Aspose.Slides die Methode [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts) (bereitgestellt von der Klasse [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) an.

Dieser PHP‑Code zeigt Ihnen, wie Sie eingebettete PowerPoint‑Schriften komprimieren:
```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->compressEmbeddedFonts($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Wie kann ich erkennen, dass eine bestimmte Schrift in der Präsentation trotz Einbettung beim Rendern noch ersetzt wird?**

Überprüfen Sie die [substitution information](/slides/de/php-java/font-substitution/) im Font‑Manager und die [fallback/substitution rules](/slides/de/php-java/fallback-font/): Wenn die Schrift nicht verfügbar oder eingeschränkt ist, wird ein Fallback verwendet.

**Lohnt es sich, "System"-Schriften wie Arial/Calibri einzubetten?**

In der Regel nein – sie sind fast immer verfügbar. Aber für maximale Portabilität in „schlanken“ Umgebungen (Docker, ein Linux‑Server ohne vorinstallierte Schriften) kann das Einbetten von Systemschriften das Risiko unerwarteter Ersetzungen eliminieren.