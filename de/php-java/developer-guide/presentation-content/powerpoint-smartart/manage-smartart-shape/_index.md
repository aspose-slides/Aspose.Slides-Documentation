---
title: SmartArt-Grafiken in Präsentationen mit PHP verwalten
linktitle: SmartArt-Grafiken
type: docs
weight: 20
url: /de/php-java/manage-smartart-shape/
keywords:
- SmartArt-Objekt
- SmartArt-Grafik
- SmartArt-Stil
- SmartArt-Farbe
- SmartArt erstellen
- SmartArt hinzufügen
- SmartArt bearbeiten
- SmartArt ändern
- SmartArt zugreifen
- SmartArt-Layouttyp
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Automatisieren Sie die Erstellung, Bearbeitung und Gestaltung von PowerPoint‑SmartArt in PHP mit Aspose.Slides, inklusive knapper Code‑Beispiele und leistung‑orientierter Anleitung."
---

## **Eine SmartArt‑Form erstellen**
Aspose.Slides for PHP via Java stellt eine API zum Erstellen von SmartArt‑Formen bereit. So erstellen Sie eine SmartArt‑Form in einer Folie:

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Holen Sie sich die Referenz einer Folie über deren Index.
1. [Fügen Sie eine SmartArt‑Form hinzu](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) und setzen Sie den [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType).
1. Speichern Sie die geänderte Präsentation als PPTX‑Datei.
```php
  # Präsentationsklasse instanziieren
  $pres = new Presentation();
  try {
    # Erste Folie abrufen
    $slide = $pres->getSlides()->get_Item(0);
    # SmartArt-Form hinzufügen
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Präsentation speichern
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Abbildung: SmartArt‑Form zur Folie hinzugefügt**|

## **Auf eine SmartArt‑Form in einer Folie zugreifen**
Im folgenden Code wird auf die in der Präsentationsfolie hinzugefügten SmartArt‑Formen zugegriffen. Im Beispielcode durchlaufen wir jede Form in der Folie und prüfen, ob es sich um eine [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)‑Form handelt. Ist die Form vom Typ SmartArt, wird sie zu einer [**SmartArt**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)‑Instanz gecastet.
```php
  # Gewünschte Präsentation laden
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Durch alle Formen der ersten Folie traversieren
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Prüfen, ob die Form vom SmartArt-Typ ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArtEx typisieren
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Auf eine SmartArt‑Form mit einem bestimmten Layouttyp zugreifen**
Der folgende Beispielcode zeigt, wie Sie die [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)‑Form mit einem bestimmten LayoutType abrufen können. Beachten Sie, dass Sie den LayoutType der SmartArt nicht ändern können, da er nur beim Hinzufügen der [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)‑Form festgelegt wird und schreibgeschützt ist.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) und laden Sie die Präsentation mit SmartArt‑Form.
1. Holen Sie sich die Referenz der ersten Folie über deren Index.
1. Durchlaufen Sie jede Form in der ersten Folie.
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
1. Prüfen Sie die SmartArt‑Form mit dem gewünschten LayoutType und führen Sie die erforderlichen Aktionen danach aus.
```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Durch alle Formen der ersten Folie traversieren
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Prüfen, ob die Form vom SmartArt-Typ ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArtEx typisieren
        $smart = $shape;
        # SmartArt-Layout prüfen
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Den Stil einer SmartArt‑Form ändern**
In diesem Beispiel lernen wir, wie der Schnellstil einer beliebigen SmartArt‑Form geändert wird.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) und laden Sie die Präsentation mit SmartArt‑Form.
1. Holen Sie sich die Referenz der ersten Folie über deren Index.
1. Durchlaufen Sie jede Form in der ersten Folie.
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
1. Finden Sie die SmartArt‑Form mit dem gewünschten Stil.
1. Setzen Sie den neuen Stil für die SmartArt‑Form.
1. Speichern Sie die Präsentation.
```php
  # Präsentationsklasse instanziieren
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Erste Folie abrufen
    $slide = $pres->getSlides()->get_Item(0);
    # Durch alle Formen der ersten Folie traversieren
    foreach($slide->getShapes() as $shape) {
      # Prüfen, ob die Form vom SmartArt-Typ ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArtEx typisieren
        $smart = $shape;
        # SmartArt-Stil prüfen
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # SmartArt-Stil ändern
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Präsentation speichern
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Abbildung: SmartArt‑Form mit geändertem Stil**|

## **Die Farbformatierung einer SmartArt‑Form ändern**
In diesem Beispiel lernen wir, wie die Farbformatierung einer beliebigen SmartArt‑Form geändert wird. Der folgende Beispielcode greift auf die SmartArt‑Form mit einer bestimmten Farbformatierung zu und ändert ihren Stil.

1. Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) und laden Sie die Präsentation mit SmartArt‑Form.
1. Holen Sie sich die Referenz der ersten Folie über deren Index.
1. Durchlaufen Sie jede Form in der ersten Folie.
1. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
1. Finden Sie die SmartArt‑Form mit der gewünschten Farbformatierung.
1. Setzen Sie die neue Farbformatierung für die SmartArt‑Form.
1. Speichern Sie die Präsentation.
```php
  # Präsentationsklasse instanziieren
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Erste Folie abrufen
    $slide = $pres->getSlides()->get_Item(0);
    # Durch alle Formen der ersten Folie traversieren
    foreach($slide->getShapes() as $shape) {
      # Prüfen, ob die Form vom SmartArt-Typ ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArtEx typisieren
        $smart = $shape;
        # SmartArt-Farbtyp prüfen
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # SmartArt-Farbtyp ändern
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Präsentation speichern
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Abbildung: SmartArt‑Form mit geänderter Farbformatierung**|

## **FAQ**

**Kann ich SmartArt als ein einziges Objekt animieren?**

Ja. SmartArt ist eine Form, sodass Sie über die Animations‑API [Standardanimationen](/slides/de/php-java/powerpoint-animation/) (Einstieg, Ausgang, Hervorhebung, Bewegungsbahnen) genauso wie bei anderen Formen anwenden können.

**Wie finde ich ein bestimmtes SmartArt‑Objekt auf einer Folie, wenn ich seine interne ID nicht kenne?**

Verwenden Sie den Alternativtext (AltText) und suchen Sie die Form nach diesem Wert – dies ist ein empfohlener Weg, um die Ziel‑Form zu lokalisieren.

**Kann ich SmartArt mit anderen Formen gruppieren?**

Ja. Sie können SmartArt mit anderen Formen (Bildern, Tabellen usw.) gruppieren und dann die [Gruppe manipulieren](/slides/de/php-java/group/).

**Wie erhalte ich ein Bild eines bestimmten SmartArt‑Objekts (z. B. für eine Vorschau oder einen Bericht)?**

Exportieren Sie ein Miniatur‑/Bild der Form; die Bibliothek kann [einzelne Formen](/slides/de/php-java/create-shape-thumbnails/) als Rasterdateien (PNG/JPG/TIFF) rendern.

**Wird das Aussehen von SmartArt beim Konvertieren der gesamten Präsentation in PDF erhalten bleiben?**

Ja. Die Rendering‑Engine strebt eine hohe Treue beim [PDF‑Export](/slides/de/php-java/convert-powerpoint-to-pdf/) an und bietet verschiedene Qualitäts‑ und Kompatibilitätsoptionen.