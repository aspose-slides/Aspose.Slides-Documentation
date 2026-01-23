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
- SmartArt-Zugriff
- SmartArt-Layouttyp
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Automatisieren Sie die Erstellung, Bearbeitung und Gestaltung von PowerPoint-SmartArt in PHP mit Aspose.Slides, einschließlich kompakter Codebeispiele und leistungsorientierter Anleitung."
---

## **SmartArt-Form erstellen**
Aspose.Slides für PHP via Java hat eine API bereitgestellt, um SmartArt‑Formen zu erstellen. Um eine SmartArt‑Form in einer Folie zu erstellen, folgen Sie bitte den untenstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Holen Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
3. [SmartArt‑Form hinzufügen](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSmartArt) durch Festlegen des [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType).
4. Speichern Sie die geänderte Präsentation als PPTX‑Datei.
```php
  # Instanziieren der Presentation-Klasse
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
|**Abbildung: SmartArt-Form, die der Folie hinzugefügt wurde**|

## **Zugriff auf eine SmartArt-Form auf einer Folie**
Der folgende Code wird verwendet, um auf die in der Präsentationsfolie hinzugefügten SmartArt‑Formen zuzugreifen. Im Beispielcode durchlaufen wir jede Form in der Folie und prüfen, ob es sich um eine [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)-Form handelt. Wenn die Form vom Typ SmartArt ist, casten wir sie zu einer [**SmartArt**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)-Instanz.
```php
  # Lade die gewünschte Präsentation
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Durchlaufe jede Form in der ersten Folie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Überprüfe, ob die Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typumwandlung von shape zu SmartArtEx
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


## **Zugriff auf eine SmartArt-Form mit einem bestimmten Layouttyp**
Der folgende Beispielcode hilft dabei, die [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)-Form mit einem bestimmten LayoutType zu erreichen. Bitte beachten Sie, dass Sie den LayoutType von SmartArt nicht ändern können, da er schreibgeschützt ist und nur festgelegt wird, wenn die [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt)-Form hinzugefügt wird.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) und laden Sie die Präsentation mit einer SmartArt‑Form.
2. Holen Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
3. Durchlaufen Sie jede Form in der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
5. Überprüfen Sie die SmartArt‑Form mit dem bestimmten LayoutType und führen Sie danach die erforderlichen Aktionen aus.
```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Durchlaufe jede Form in der ersten Folie
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Überprüfe, ob die Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typumwandlung von shape zu SmartArtEx
        $smart = $shape;
        # Überprüfe das SmartArt-Layout
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


## **Stil einer SmartArt-Form ändern**
In diesem Beispiel lernen wir, den Schnellstil für eine beliebige SmartArt‑Form zu ändern.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) und laden Sie die Präsentation mit einer SmartArt‑Form.
2. Holen Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
3. Durchlaufen Sie jede Form in der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
5. Suchen Sie die SmartArt‑Form mit einem bestimmten Stil.
6. Legen Sie den neuen Stil für die SmartArt‑Form fest.
7. Speichern Sie die Präsentation.
```php
  # Instanziieren der Presentation-Klasse
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Erste Folie abrufen
    $slide = $pres->getSlides()->get_Item(0);
    # Durchlaufe jede Form in der ersten Folie
    foreach($slide->getShapes() as $shape) {
      # Überprüfe, ob die Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typumwandlung von shape zu SmartArtEx
        $smart = $shape;
        # Überprüfe den SmartArt-Stil
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
|**Abbildung: SmartArt-Form mit geändertem Stil**|

## **Farbstil einer SmartArt-Form ändern**
In diesem Beispiel lernen wir, den Farbstil für eine beliebige SmartArt‑Form zu ändern. Der folgende Beispielcode greift auf die SmartArt‑Form mit einem bestimmten Farbstil zu und ändert deren Stil.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) und laden Sie die Präsentation mit einer SmartArt‑Form.
2. Holen Sie die Referenz der ersten Folie, indem Sie ihren Index verwenden.
3. Durchlaufen Sie jede Form in der ersten Folie.
4. Prüfen Sie, ob die Form vom Typ [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) ist, und casten Sie die ausgewählte Form zu SmartArt, falls sie SmartArt ist.
5. Suchen Sie die SmartArt‑Form mit einem bestimmten Farbstil.
6. Legen Sie den neuen Farbstil für die SmartArt‑Form fest.
7. Speichern Sie die Präsentation.
```php
  # Instanziieren der Presentation-Klasse
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Erste Folie abrufen
    $slide = $pres->getSlides()->get_Item(0);
    # Durchlaufe jede Form in der ersten Folie
    foreach($slide->getShapes() as $shape) {
      # Überprüfe, ob die Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typumwandlung von shape zu SmartArtEx
        $smart = $shape;
        # Überprüfe den SmartArt-Farbtyp
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
|**Abbildung: SmartArt-Form mit geändertem Farbstil**|

## **FAQ**

**Kann ich SmartArt als einzelnes Objekt animieren?**

Ja. SmartArt ist eine Form, sodass Sie über die Animations‑API [Standardanimationen](/slides/de/php-java/powerpoint-animation/) (Eingang, Ausgang, Betonung, Bewegungsbahnen) wie bei anderen Formen anwenden können.

**Wie kann ich ein bestimmtes SmartArt auf einer Folie finden, wenn ich seine interne ID nicht kenne?**

Legen Sie den Alternativtext (AltText) fest und verwenden Sie ihn zur Suche nach der Form – dies ist ein empfohlener Weg, die Ziel‑Form zu finden.

**Kann ich SmartArt mit anderen Formen gruppieren?**

Ja. Sie können SmartArt mit anderen Formen (Bildern, Tabellen usw.) gruppieren und anschließend die [Gruppe manipulieren](/slides/de/php-java/group/).

**Wie erhalte ich ein Bild eines bestimmten SmartArt (z. B. für eine Vorschau oder einen Bericht)?**

Exportieren Sie ein Miniaturbild/Bild der Form; die Bibliothek kann [einzelne Formen rendern](/slides/de/php-java/create-shape-thumbnails/) in Rasterdateien (PNG/JPG/TIFF).

**Wird das Aussehen von SmartArt beim Konvertieren der gesamten Präsentation in PDF beibehalten?**

Ja. Die Rendering‑Engine zielt bei der [PDF‑Export](/slides/de/php-java/convert-powerpoint-to-pdf/) auf hohe Treue ab und bietet verschiedene Qualitäts‑ und Kompatibilitätsoptionen.