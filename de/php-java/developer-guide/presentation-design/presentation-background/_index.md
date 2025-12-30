---
title: Verwalten von Präsentationshintergründen in PHP
linktitle: Folienhintergrund
type: docs
weight: 20
url: /de/php-java/presentation-background/
keywords:
- Präsentationshintergrund
- Folienhintergrund
- Einfarbige Farbe
- Farbverlauf
- Bildhintergrund
- Hintergrundtransparenz
- Hintergrundeigenschaften
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie dynamische Hintergründe in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für PHP über Java festlegen, einschließlich Code-Tipps zur Verbesserung Ihrer Präsentationen."
---

## **Übersicht**

Einfarbige Farben, Verläufe und Bilder werden häufig für Folienhintergründe verwendet. Sie können den Hintergrund für eine **normale Folie** (eine einzelne Folie) oder eine **Master‑Folie** (gilt für mehrere Folien gleichzeitig) festlegen.

![PowerPoint background](powerpoint-background.png)

## **Einfarbigen Hintergrund für eine normale Folie festlegen**

Aspose.Slides ermöglicht es, für eine bestimmte Folie in einer Präsentation eine einfarbige Farbe als Hintergrund festzulegen – selbst wenn die Präsentation eine Master‑Folie verwendet. Die Änderung wirkt nur auf die ausgewählte Folie.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
2. Setzen Sie den Folien-[BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) auf `OwnBackground`.
3. Setzen Sie den Folienhintergrund-[FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) auf `Solid`.
4. Verwenden Sie die Methode [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) von [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/), um die einfarbige Hintergrundfarbe festzulegen.
5. Speichern Sie die geänderte Präsentation.

```php
// Erstellen Sie eine Instanz der Presentation-Klasse.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Setzen Sie die Hintergrundfarbe der Folie auf Blau.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // Speichern Sie die Präsentation auf dem Datenträger.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Einfarbigen Hintergrund für eine Master‑Folie festlegen**

Aspose.Slides ermöglicht es, für die Master‑Folie einer Präsentation eine einfarbige Farbe als Hintergrund festzulegen. Die Master‑Folie dient als Vorlage, die die Formatierung aller Folien steuert, sodass die Wahl einer einfarbigen Hintergrundfarbe für die Master‑Folie auf jede Folie angewendet wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) der Master‑Folie (über `getMasters`) auf `OwnBackground`.
3. Setzen Sie den Hintergrund-[FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) der Master‑Folie auf `Solid`.
4. Verwenden Sie die Methode [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor), um die einfarbige Hintergrundfarbe festzulegen.
5. Speichern Sie die geänderte Präsentation.

```php
// Erstellen Sie eine Instanz der Presentation-Klasse.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // Setzen Sie die Hintergrundfarbe der Master-Folie auf Waldgrün.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // Speichern Sie die Präsentation auf dem Datenträger.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Verlaufshintergrund für eine Folie festlegen**

Ein Verlauf ist ein grafischer Effekt, der durch eine allmähliche Farbänderung entsteht. Als Folienhintergrund verwendet, können Verläufe Präsentationen kunstvoller und professioneller wirken lassen. Aspose.Slides ermöglicht es, eine Farbverlauf als Hintergrund für Folien festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
2. Setzen Sie den Folien-[BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) auf `OwnBackground`.
3. Setzen Sie den Folienhintergrund-[FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) auf `Gradient`.
4. Verwenden Sie die Methode [getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat) von [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/), um Ihre gewünschten Verlaufseinstellungen zu konfigurieren.
5. Speichern Sie die geänderte Präsentation.

```php
// Erstellen Sie eine Instanz der Presentation-Klasse.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Einen Verlaufseffekt auf den Hintergrund anwenden.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // Speichern Sie die Präsentation auf dem Datenträger.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Bild als Folienhintergrund festlegen**

Zusätzlich zu einfarbigen und Verlauffüllungen ermöglicht Aspose.Slides die Verwendung von Bildern als Folienhintergrund.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
2. Setzen Sie den Folien-[BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) auf `OwnBackground`.
3. Setzen Sie den Folienhintergrund-[FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) auf `Picture`.
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild der Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die Methode [getPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getPictureFillFormat) von [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/), um das Bild als Hintergrund zuzuweisen.
7. Speichern Sie die geänderte Präsentation.

```php
// Erstellen Sie eine Instanz der Presentation-Klasse.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Legen Sie die Eigenschaften des Hintergrundbildes fest.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // Laden Sie das Bild.
    $image = Images::fromFile("Tulips.jpg");
    // Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // Speichern Sie die Präsentation auf dem Datenträger.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // Legen Sie das für die Hintergrundfüllung verwendete Bild fest.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // Setzen Sie den Bildfüllmodus auf Kachel und passen Sie die Kacheleigenschaften an.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


{{% alert color="primary" %}}
Weiterlesen: [**Tile Picture As Texture**](/slides/de/php-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparenz des Hintergrundbildes ändern**

Möglicherweise möchten Sie die Transparenz des Hintergrundbildes einer Folie anpassen, um den Inhalt der Folie hervorzuheben. Der folgende PHP‑Code zeigt, wie Sie die Transparenz eines Folienhintergrundbildes ändern können:

```php
$transparencyValue = 30; // Zum Beispiel.

// Get the collection of picture transform operations.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Find an existing fixed-percentage transparency effect.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Set the new transparency value.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```


## **Den Hintergrundwert der Folie abrufen**

Aspose.Slides stellt die Klasse `BackgroundEffectiveData` zur Verfügung, um die effektiven Hintergrundwerte einer Folie abzurufen. Diese Klasse gibt das effektive [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) und [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) zurück.

Mit der Methode `getBackground` der Klasse [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/) können Sie den effektiven Hintergrund einer Folie erhalten.

```php
// Erstellen Sie eine Instanz der Presentation-Klasse.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Rufen Sie den effektiven Hintergrund ab, wobei Master, Layout und Theme berücksichtigt werden.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**Kann ich einen benutzerdefinierten Hintergrund zurücksetzen und den Theme-/Layout‑Hintergrund wiederherstellen?**

Ja. Entfernen Sie die benutzerdefinierte Füllung der Folie, und der Hintergrund wird wieder vom entsprechenden [layout](/slides/de/php-java/slide-layout)/[master](/slides/de/php-java/slide-master)‑Folie geerbt (d.h. vom [theme background](/slides/de/php-java/presentation-theme)).

**Was passiert mit dem Hintergrund, wenn ich später das Theme der Präsentation ändere?**

Wenn eine Folie ihre eigene Füllung hat, bleibt diese unverändert. Wird der Hintergrund vom [layout](/slides/de/php-java/slide-layout)/[master](/slides/de/php-java/slide-master) geerbt, wird er aktualisiert, um dem [new theme](/slides/de/php-java/presentation-theme) zu entsprechen.