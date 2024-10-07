---
title: Präsentationshintergrund
type: docs
weight: 20
url: /php-java/presentation-background/
keywords: "PowerPoint Hintergrund, Hintergrund setzen"
description: "Hintergrund in PowerPoint-Präsentation setzen"
---

Einfache Farben, Farbverläufe und Bilder werden oft als Hintergrundbilder für Folien verwendet. Sie können den Hintergrund entweder für eine **normale Folie** (einzelne Folie) oder eine **Masterfolie** (mehrere Folien gleichzeitig) setzen.

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Einfache Farbe als Hintergrund für normale Folie setzen**

Aspose.Slides ermöglicht es Ihnen, eine einfache Farbe als Hintergrund für eine bestimmte Folie in einer Präsentation festzulegen (auch wenn diese Präsentation eine Masterfolie enthält). Die Hintergrundänderung wirkt sich nur auf die ausgewählte Folie aus.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) Enum für die Folie auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) Enum für den Folienhintergrund auf `Solid`.
4. Verwenden Sie die [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) bereitgestellt wird, um eine einfache Farbe für den Hintergrund anzugeben.
5. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie eine einfache Farbe (blau) als Hintergrund für eine normale Folie setzen:

```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation("MasterBG.pptx");
  try {
    # Setzt die Hintergrundfarbe für die erste ISlide auf Blau
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Schreibt die Präsentation auf die Festplatte
    $pres->save("ContentBG.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Einfache Farbe als Hintergrund für Masterfolie setzen**

Aspose.Slides ermöglicht es Ihnen, eine einfache Farbe als Hintergrund für die Masterfolie einer Präsentation festzulegen. Die Masterfolie fungiert als Vorlage, die Formatierungseinstellungen für alle Folien enthält und steuert. Daher wird, wenn Sie eine einfache Farbe als Hintergrund für die Masterfolie auswählen, dieser neue Hintergrund für alle Folien verwendet.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) Enum für die Masterfolie (`Masters`) auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) Enum für den Masterfolienhintergrund auf `Solid`.
4. Verwenden Sie die [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) bereitgestellt wird, um eine einfache Farbe für den Hintergrund anzugeben.
5. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie eine einfache Farbe (forest green) als Hintergrund für eine Masterfolie in einer Präsentation setzen:

```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Setzt die Hintergrundfarbe für die Master ISlide auf Forest Green
    $pres->getMasters()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Schreibt die Präsentation auf die Festplatte
    $pres->save("MasterBG.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Farbverlauf als Hintergrund für Folie setzen**

Ein Farbverlauf ist ein grafischer Effekt, der auf einer allmählichen Farbänderung basiert. Farbverläufe, die als Hintergründe für Folien verwendet werden, lassen Präsentationen künstlerisch und professionell aussehen. Aspose.Slides ermöglicht es Ihnen, eine Farbverlauffarbe als Hintergrund für Folien in Präsentationen festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) Enum für die Folie auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) Enum für den Masterfolienhintergrund auf `Gradient`.
4. Verwenden Sie die [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat--) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) bereitgestellt wird, um Ihre bevorzugten Verlaufseinstellungen anzugeben.
5. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie eine Farbverlauffarbe als Hintergrund für eine Folie setzen:

```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation("MasterBG.pptx");
  try {
    # Wendet den Verlaufseffekt auf den Hintergrund an
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip->FlipBoth);
    # Schreibt die Präsentation auf die Festplatte
    $pres->save("ContentBG_Grad.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Bild als Hintergrund für Folie setzen**

Neben einfachen Farben und Farbverläufen ermöglicht Aspose.Slides auch das Setzen von Bildern als Hintergrund für Folien in Präsentationen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) Enum für die Folie auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) Enum für den Masterfolienhintergrund auf `Picture`.
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getPictureFillFormat--) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) bereitgestellt wird, um das Bild als Hintergrund zu setzen.
7. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie ein Bild als Hintergrund für eine Folie setzen:

```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Setzt die Bedingungen für das Hintergrundbild
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Lädt das Bild
    $imgx;
    $image = Images->fromFile("Desert.jpg");
    try {
      $imgx = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Bild zur Bildsammlung der Präsentation hinzufügen
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($imgx);
    # Schreibt die Präsentation auf die Festplatte
    $pres->save("ContentBG_Img.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Transparenz des Hintergrundbildes ändern**

Möglicherweise möchten Sie die Transparenz des Hintergrundbildes einer Folie anpassen, um den Inhalt der Folie hervorzuheben. Dieser PHP-Code zeigt Ihnen, wie Sie die Transparenz für ein Folienhintergrundbild ändern:

```php
  $transparencyValue = 30;// Zum Beispiel

  # Erlangt eine Sammlung von Bildtransformationsoperationen
  $imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  # Findet einen Transparenzeffekt mit festem Prozentsatz.
  $transparencyOperation = null;
  foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $transparencyOperation = $operation;
      break;
    }
  }
  # Setzt den neuen Transparenzwert.
  if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
  } else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
  }
```

## **Wert des Folienhintergrunds abrufen**

Aspose.Slides bietet das [IBackgroundEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/) Interface, um Ihnen zu ermöglichen, die effektiven Werte der Folienhintergründe abzurufen. Dieses Interface enthält Informationen über das effektive [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getFillFormat--) und das effektive [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Durch die Verwendung der [Background](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getBackground--) Eigenschaft der [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/) Klasse können Sie den effektiven Wert für einen Folienhintergrund abrufen.

Dieser PHP-Code zeigt Ihnen, wie Sie den effektiven Hintergrundwert einer Folie abrufen:

```php
  # Erstellt eine Instanz der Presentation-Klasse
  $pres = new Presentation("SamplePresentation.pptx");
  try {
    $effBackground = $pres->getSlides()->get_Item(0)->getBackground()->getEffective();
    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid) {
      echo("Füllfarbe: " . $effBackground->getFillFormat()->getSolidFillColor());
    } else {
      echo("Fülltyp: " . $effBackground->getFillFormat()->getFillType());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```