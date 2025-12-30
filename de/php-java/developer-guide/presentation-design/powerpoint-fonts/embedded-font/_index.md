---
title: Schriften in Präsentationen mit PHP einbetten
linktitle: Schrift einbetten
type: docs
weight: 40
url: /de/php-java/embedded-font/
keywords:
- Schrift hinzufügen
- Schrift einbetten
- Schrifteinbettung
- Eingebettete Schrift abrufen
- Eingebettete Schrift hinzufügen
- Eingebettete Schrift entfernen
- Eingebettete Schrift komprimieren
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Einbetten von TrueType-Schriften in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java, um eine genaue Darstellung auf allen Plattformen zu gewährleisten."
---

**Eingebettete Schriften in PowerPoint** sind nützlich, wenn Sie möchten, dass Ihre Präsentation auf jedem System oder Gerät korrekt angezeigt wird. Wenn Sie eine Drittanbieter‑ oder nicht‑standardmäßige Schrift verwendet haben, weil Sie kreativ waren, haben Sie noch mehr Gründe, Ihre Schrift einzubetten. Andernfalls (ohne eingebettete Schriften) können sich Texte oder Zahlen auf Ihren Folien, das Layout, das Styling usw. ändern oder in verwirrende Rechtecke verwandeln. 

Die Klasse [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager), die Klasse [FontData](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/), die Klasse [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) und ihre Schnittstellen enthalten die meisten Eigenschaften und Methoden, die Sie benötigen, um mit eingebetteten Schriften in PowerPoint‑Präsentationen zu arbeiten.

## **Eingebettete Schriften abrufen und entfernen**

Aspose.Slides stellt die Methode [getEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) (bereitgestellt von der Klasse [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/FontsManager)) zur Verfügung, mit der Sie die in einer Präsentation eingebetteten Schriften abrufen (oder herausfinden) können. Um Schriften zu entfernen, wird die Methode [removeEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) (ebenfalls von derselben Klasse) verwendet.

Dieser PHP‑Code zeigt, wie man eingebettete Schriften aus einer Präsentation abruft und entfernt:
```php
  # Instanziert ein Presentation-Objekt, das eine Präsentationsdatei darstellt
  $pres = new Presentation("EmbeddedFonts.pptx");
  try {
    # Rendert eine Folie, die einen Textframe enthält, der die eingebettete Schrift "FunSized" verwendet
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Speichert das Bild im JPEG-Format auf die Festplatte
    try {
      $slideImage->save("picture1_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    $fontsManager = $pres->getFontsManager();
    # Erhält alle eingebetteten Schriften
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    # Findet die Schrift "Calibri"
    $calibriEmbeddedFont = null;
    $Array = new java_class("java.lang.reflect.Array");
    for($i = 0; $i < java_values($Array->getLength($embeddedFonts)) ; $i++) {
      echo("" . $embeddedFonts[$i]->getFontName());
      if ("Calibri"->equals($embeddedFonts[$i]->getFontName())) {
        $calibriEmbeddedFont = $embeddedFonts[$i];
        break;
      }
    }
    # Entfernt die Schrift "Calibri"
    $fontsManager->removeEmbeddedFont($calibriEmbeddedFont);
    # Rendert die Präsentation; die Schrift "Calibri" wird durch eine vorhandene ersetzt
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 960, 720));
    # Speichert das Bild im JPEG-Format auf die Festplatte
    try {
      $slideImage->save("picture2_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Speichert die Präsentation ohne die eingebettete Schrift "Calibri" auf die Festplatte
    $pres->save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eingebettete Schriften hinzufügen**

Mit dem Enum [EmbedFontCharacters](https://reference.aspose.com/slides/php-java/aspose.slides/embedfontcharacters/) und zwei Überladungen der Methode [addEmbeddedFont](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) können Sie die gewünschte (Einbettungs‑)Regel auswählen, um die Schriften in einer Präsentation einzubetten. Dieser PHP‑Code zeigt, wie man Schriften in eine Präsentation einbettet und hinzufügt:
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
    # Speichert die Präsentation auf die Festplatte
    $pres->save("AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Eingebettete Schriften komprimieren**

Um Ihnen das Komprimieren der in einer Präsentation eingebetteten Schriften und die Reduzierung der Dateigröße zu ermöglichen, stellt Aspose.Slides die Methode [compressEmbeddedFonts](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) (bereitgestellt von der Klasse [Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)) zur Verfügung.

Dieser PHP‑Code zeigt, wie man eingebettete PowerPoint‑Schriften komprimiert:
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

**Wie kann ich erkennen, dass eine bestimmte Schrift in der Präsentation trotz Einbettung beim Rendern trotzdem substituiert wird?**

Prüfen Sie die [Substitutionsinformationen](/slides/de/php-java/font-substitution/) im Font‑Manager und die [Fallback‑/Substitutionsregeln](/slides/de/php-java/fallback-font/): Wenn die Schrift nicht verfügbar oder eingeschränkt ist, wird eine Ersatzschrift verwendet.

**Lohnt es sich, Systemschriften wie Arial/Calibri einzubetten?**

In der Regel nein – sie sind fast immer verfügbar. Für volle Portabilität in „dünnen“ Umgebungen (Docker, ein Linux‑Server ohne vorinstallierte Schriften) kann das Einbetten von Systemschriften jedoch das Risiko unerwarteter Substitutionen ausschalten.