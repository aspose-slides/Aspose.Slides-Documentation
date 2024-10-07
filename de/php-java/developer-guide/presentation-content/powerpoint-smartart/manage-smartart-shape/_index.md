---
title: SmartArt-Form verwalten
type: docs
weight: 20
url: /php-java/manage-smartart-shape/
---


## **SmartArt-Form erstellen**
Aspose.Slides für PHP über Java hat eine API bereitgestellt, um SmartArt-Formen zu erstellen. Um eine SmartArt-Form in einer Folie zu erstellen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse.
1. Erhalten Sie die Referenz auf eine Folie, indem Sie ihren Index verwenden.
1. [Fügen Sie eine SmartArt-Form hinzu](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) und setzen Sie den [Layouttyp](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType).
1. Speichern Sie die modifizierte Präsentation als PPTX-Datei.

```php
  # Instanziieren der Präsentationsklasse
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
|**Abbildung: SmartArt-Form zur Folie hinzugefügt**|

## **Zugriff auf SmartArt-Form in der Folie**
Der folgende Code wird verwendet, um auf die in der Präsentationsfolie hinzugefügten SmartArt-Formen zuzugreifen. Im Beispielcode durchlaufen wir jede Form innerhalb der Folie und überprüfen, ob sie eine [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) Form ist. Wenn die Form vom Typ SmartArt ist, casten wir sie zur [**SmartArt**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) Instanz.

```php
  # Die gewünschte Präsentation laden
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Jede Form innerhalb der ersten Folie durchlaufen
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Überprüfen, ob die Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArtEx casten
        $smart = $shape;
        echo("Formname: " . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zugriff auf SmartArt-Form mit speziellem Layouttyp**
Der folgende Beispielcode hilft dabei, auf die [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) Form mit einem speziellen Layouttyp zuzugreifen: Bitte beachten Sie, dass Sie den Layouttyp der SmartArt nicht ändern können, da er schreibgeschützt ist und nur festgelegt wird, wenn die [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) Form hinzugefügt wird.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie die Referenz auf die erste Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) Typ ist, und casten Sie die ausgewählte Form zu SmartArt, wenn sie SmartArt ist.
1. Überprüfen Sie die SmartArt-Form mit einem bestimmten Layouttyp und führen Sie aus, was danach erforderlich ist.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Jede Form innerhalb der ersten Folie durchlaufen
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Überprüfen, ob die Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArtEx casten
        $smart = $shape;
        # Überprüfen des SmartArt-Layouts
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Hier etwas tun....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SmartArt-Formstil ändern**
In diesem Beispiel lernen wir, den Schnellstil für eine beliebige SmartArt-Form zu ändern.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie die Referenz auf die erste Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) Typ ist und casten Sie die ausgewählte Form zu SmartArt, wenn sie SmartArt ist.
1. Suchen Sie die SmartArt-Form mit einem bestimmten Stil.
1. Setzen Sie den neuen Stil für die SmartArt-Form.
1. Speichern Sie die Präsentation.

```php
  # Instanziieren der Präsentationsklasse
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Erste Folie abrufen
    $slide = $pres->getSlides()->get_Item(0);
    # Jede Form innerhalb der ersten Folie durchlaufen
    foreach($slide->getShapes() as $shape) {
      # Überprüfen, ob die Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArtEx casten
        $smart = $shape;
        # Überprüfen des SmartArt-Stils
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Ändern des SmartArt-Stils
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

## **SmartArt-Formfarbstil ändern**
In diesem Beispiel lernen wir, den Farbstil für eine beliebige SmartArt-Form zu ändern. Im folgenden Beispielcode greifen wir auf die SmartArt-Form mit einem bestimmten Farbstil zu und ändern ihren Stil.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse und laden Sie die Präsentation mit der SmartArt-Form.
1. Erhalten Sie die Referenz auf die erste Folie, indem Sie ihren Index verwenden.
1. Durchlaufen Sie jede Form innerhalb der ersten Folie.
1. Überprüfen Sie, ob die Form vom [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) Typ ist und casten Sie die ausgewählte Form zu SmartArt, wenn sie SmartArt ist.
1. Suchen Sie die SmartArt-Form mit einem bestimmten Farbstil.
1. Setzen Sie den neuen Farbstil für die SmartArt-Form.
1. Speichern Sie die Präsentation.

```php
  # Instanziieren der Präsentationsklasse
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Erste Folie abrufen
    $slide = $pres->getSlides()->get_Item(0);
    # Jede Form innerhalb der ersten Folie durchlaufen
    foreach($slide->getShapes() as $shape) {
      # Überprüfen, ob die Form vom Typ SmartArt ist
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Form zu SmartArtEx casten
        $smart = $shape;
        # Überprüfen des SmartArt-Farbstils
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Ändern des SmartArt-Farbstils
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