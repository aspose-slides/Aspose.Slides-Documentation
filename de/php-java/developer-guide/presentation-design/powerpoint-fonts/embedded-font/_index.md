---
title: Eingebettete Schriftarten - PowerPoint Java API
linktitle: Eingebettete Schriftarten
type: docs
weight: 40
url: /de/php-java/embedded-font/
keywords: "Schriftarten, eingebettete Schriftarten, Schriftarten hinzufügen, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Verwenden Sie eingebettete Schriftarten in PowerPoint-Präsentationen"

---

**Eingebettete Schriftarten in PowerPoint** sind nützlich, wenn Sie möchten, dass Ihre Präsentation auf jedem System oder Gerät korrekt angezeigt wird. Wenn Sie eine Schriftart von Drittanbietern oder eine nicht-standardmäßige Schriftart verwendet haben, weil Sie kreativ mit Ihrer Arbeit umgegangen sind, haben Sie noch mehr Gründe, Ihre Schriftart einzubetten. Andernfalls (ohne eingebettete Schriftarten) können sich die Texte oder Zahlen auf Ihren Folien, das Layout, das Styling usw. ändern oder in verwirrende Rechtecke umwandeln. 

Die Klasse [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager), die Klasse [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/), die Klasse [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) und deren Schnittstellen enthalten die meisten Eigenschaften und Methoden, die Sie benötigen, um mit eingebetteten Schriftarten in PowerPoint-Präsentationen zu arbeiten.

## **Eingebettete Schriftarten aus der Präsentation abrufen oder entfernen**

Aspose.Slides bietet die Methode [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (bereitgestellt durch die Klasse [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)), um Ihnen zu ermöglichen, die in einer Präsentation eingebetteten Schriftarten abzurufen (oder herauszufinden). Um Schriftarten zu entfernen, wird die Methode [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (die ebenfalls von der gleichen Klasse bereitgestellt wird) verwendet.

Dieser PHP-Code zeigt Ihnen, wie Sie eingebettete Schriftarten aus einer Präsentation abrufen und entfernen:

```php
  # Erstellt ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Rendert eine Folie mit einem Textfeld, das die eingebettete Schriftart "FunSized" verwendet
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
    # Holt alle eingebetteten Schriftarten
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Findet die Schriftart "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # Entfernt die Schriftart "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Rendert die Präsentation; die Schriftart "Calibri" wird durch eine vorhandene ersetzt
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Speichert das Bild auf der Festplatte im JPEG-Format
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Speichert die Präsentation ohne eingebettete "Calibri"-Schriftart auf der Festplatte
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Eingebettete Schriftarten zur Präsentation hinzufügen**

Mit dem Enum [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) und zwei Überladungen der Methode [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) können Sie Ihre bevorzugte (Einbettungs-) Regel auswählen, um die Schriftarten in einer Präsentation einzubetten. Dieser PHP-Code zeigt Ihnen, wie Sie Schriftarten in eine Präsentation einbetten und hinzufügen:

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

## **Eingebettete Schriftarten komprimieren**

Um Ihnen zu ermöglichen, die in einer Präsentation eingebetteten Schriftarten zu komprimieren und die Dateigröße zu reduzieren, bietet Aspose.Slides die Methode [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (bereitgestellt durch die Klasse [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)).

Dieser PHP-Code zeigt Ihnen, wie Sie eingebettete Schriftarten in PowerPoint komprimieren:

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