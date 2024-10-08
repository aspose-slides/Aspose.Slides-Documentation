---
title: Bullet verwalten
type: docs
weight: 60
url: /de/php-java/manage-bullet/
keywords: "Aufzählungszeichen, Aufzählungslisten, Zahlen, nummerierte Listen, Bildaufzählungszeichen, mehrstufige Aufzählungszeichen, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Erstellen Sie Aufzählungs- und nummerierte Listen in PowerPoint-Präsentationen"
---

In **Microsoft PowerPoint** können Sie Aufzählungs- und nummerierte Listen genauso erstellen wie in Word und anderen Texteditoren. **Aspose.Slides für PHP über Java** ermöglicht es Ihnen auch, Aufzählungszeichen und Zahlen in Folien Ihrer Präsentationen zu verwenden.

## Warum Aufzählungslisten verwenden?

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren.

**Beispiel für eine Aufzählungsliste**

In den meisten Fällen erfüllt eine Aufzählungsliste diese drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Informationen
- ermöglicht es Ihren Lesern oder Zuschauern, schnell nach Schlüsselpunkten zu suchen
- kommuniziert und liefert wichtige Details effizient.

## Warum nummerierte Listen verwenden?

Nummerierte Listen helfen ebenfalls, Informationen zu organisieren und zu präsentieren. Idealerweise sollten Sie Zahlen (anstatt von Aufzählungszeichen) verwenden, wenn die Reihenfolge der Einträge (zum Beispiel *Schritt 1, Schritt 2* usw.) wichtig ist oder wenn auf einen Eintrag verwiesen werden muss (zum Beispiel *siehe Schritt 3*).

**Beispiel für eine nummerierte Liste**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im **Erstellen von Aufzählungszeichen** Verfahren unten:

1. Erstellen Sie eine Instanz der Präsentationsklasse.
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14).
3. Speichern Sie die Präsentation.

## Aufzählungszeichen erstellen
Dieses Thema ist auch Teil der Themenreihe zur Verwaltung von Textabsätzen. Diese Seite wird verdeutlichen, wie wir die Aufzählungszeichen von Absätzen verwalten können. Aufzählungszeichen sind nützlicher, wenn etwas in Schritten beschrieben werden soll. Darüber hinaus sieht Text mit der Verwendung von Aufzählungszeichen gut organisiert aus. Aufzählungsabsätze sind immer einfacher zu lesen und zu verstehen. Wir werden sehen, wie Entwickler dieses kleine, aber leistungsstarke Feature von Aspose.Slides für PHP über Java nutzen können. Bitte folgen Sie den folgenden Schritten, um die Absatzaufzählungszeichen mit Aspose.Slides für PHP über Java zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Greifen Sie auf die gewünschte Folie in der Folienkollektion mit dem [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide) Objekt zu.
1. Fügen Sie eine [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) in die ausgewählte Folie ein.
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) der hinzugefügten Form zu.
1. Entfernen Sie den Standardabsatz im TextFrame.
1. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph) Klasse.
1. Legen Sie den Aufzählungstyp des Absatzes fest.
1. Setzen Sie den Aufzählungstyp auf [Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/BulletType#Symbol) und den Aufzählungszeichenzeichen.
1. Legen Sie den Absatztext fest.
1. Stellen Sie die Absatz-Einrückung ein, um das Aufzählungszeichen zu setzen.
1. Legen Sie die Farbe des Aufzählungszeichens fest.
1. Legen Sie die Höhe der Aufzählungszeichen fest.
1. Fügen Sie den erstellten Absatz zur TextFrame-Absatzkollektion hinzu.
1. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den in den Schritten **7 bis 13** angegebenen Vorgang.
1. Speichern Sie die Präsentation.

Dieser Beispielcode — eine Implementierung der obigen Schritte — zeigt Ihnen, wie Sie eine Aufzählungsliste in einer Folie erstellen:

```php
  # Erstellen Sie eine Präsentationsinstanz, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Auf die erste Folie zugreifen
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen und Zugreifen auf die AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Zugriff auf den Textframe der erstellten AutoShape
    $txtFrm = $aShp->getTextFrame();
    # Entfernen des standardmäßigen bestehenden Absatzes
    $txtFrm->getParagraphs()->removeAt(0);
    # Erstellen eines Absatzes
    $para = new Paragraph();
    # Setzen des Aufzählungszeichenstils und Symbols
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Setzen des Absatztextes
    $para->setText("Willkommen bei Aspose.Slides");
    # Einstellen der Aufzählungszeigeneinrückung
    $para->getParagraphFormat()->setIndent(25);
    # Farbe des Aufzählungszeichens festlegen
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # set IsBulletHardColor auf true setzen, um die eigene Aufzählungszeichenfarbe zu verwenden
    $para->getParagraphFormat()->getBullet()->isBulletHardColor();
    # Höhe des Aufzählungszeichens festlegen
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Absatz zum Textframe hinzufügen
    $txtFrm->getParagraphs()->add($para);
    # Speichern der Präsentation als PPTX-Datei
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## Bildaufzählungszeichen erstellen

Aspose.Slides für PHP über Java ermöglicht es Ihnen, die Aufzählungszeichen in Aufzählungslisten zu ändern. Sie können die Aufzählungszeichen durch benutzerdefinierte Symbole oder Bilder ersetzen. Wenn Sie einer Liste visuelles Interesse verleihen oder noch mehr Aufmerksamkeit auf Einträge in einer Liste lenken möchten, können Sie Ihr eigenes Bild als Aufzählungszeichen verwenden.

{{% alert color="primary" %}} 

Idealerweise, wenn Sie beabsichtigen, das reguläre Aufzählungszeichensymbol durch ein Bild zu ersetzen, sollten Sie ein einfaches Grafikbild mit transparentem Hintergrund auswählen. Solche Bilder eignen sich am besten als benutzerdefinierte Aufzählungszeichen-Symbole.

In jedem Fall wird das von Ihnen gewählte Bild auf eine sehr kleine Größe reduziert, daher empfehlen wir dringend, ein Bild auszuwählen, das gut aussieht (als Ersatz für das Aufzählungszeichensymbol) in einer Liste.

{{% /alert %}} 

Um ein Bildaufzählungszeichen zu erstellen, gehen Sie durch die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Greifen Sie auf die gewünschte Folie in der Folienkollektion mit dem [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide) Objekt zu.
1. Fügen Sie eine AutoShape in die ausgewählte Folie ein.
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Erstellen Sie die erste Absatzinstanz mit der Paragraph-Klasse.
1. Laden Sie das Bild von der Festplatte in [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPPImage).
1. Setzen Sie den Aufzählungstyp auf Bild und setzen Sie das Bild.
1. Setzen Sie den Absatztext.
1. Stellen Sie die Absatz-Einrückung ein, um das Aufzählungszeichen zu setzen.
1. Legen Sie die Farbe des Aufzählungszeichens fest.
1. Legen Sie die Höhe der Aufzählungszeichen fest.
1. Fügen Sie den erstellten Absatz in die [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) Absatzkollektion ein.
1. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den in den vorherigen Schritten angegebenen Vorgang.
1. Speichern Sie die Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie ein Bildaufzählungszeichen in einer Folie erstellen:

```php
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Instanziieren des Bildes für Aufzählungszeichen
    $picture;
    $image = Images->fromFile("asp1.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Hinzufügen und Zugreifen auf die AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Zugriff auf den Textframe der erstellten AutoShape
    $txtFrm = $aShp->getTextFrame();
    # Entfernen des standardmäßigen bestehenden Absatzes
    $txtFrm->getParagraphs()->removeAt(0);
    # Erstellen eines neuen Absatzes
    $para = new Paragraph();
    $para->setText("Willkommen bei Aspose.Slides");
    # Setzen des Absatzaufzählungszeichenstils und Bildes
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $para->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Höhe des Aufzählungszeichens festlegen
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Absatz zum Textframe hinzufügen
    $txtFrm->getParagraphs()->add($para);
    # Schreiben der Präsentation als PPTX-Datei
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Mehrstufige Aufzählungszeichen erstellen

Um eine Aufzählungsliste zu erstellen, die Elemente auf verschiedenen Ebenen enthält—zusätzliche Listen unter der Haupt-Aufzählungsliste—gehen Sie durch die folgenden Schritte:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Greifen Sie auf die gewünschte Folie in der Folienkollektion mit dem [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide) Objekt zu.
1. Fügen Sie eine AutoShape in die ausgewählte Folie ein.
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Erstellen Sie die erste Absatzinstanz mit der Paragraph-Klasse und setzen Sie die Tiefe auf 0.
1. Erstellen Sie die zweite Absatzinstanz mit der Paragraph-Klasse und setzen Sie die Tiefe auf 1.
1. Erstellen Sie die dritte Absatzinstanz mit der Paragraph-Klasse und setzen Sie die Tiefe auf 2.
1. Erstellen Sie die vierte Absatzinstanz mit der Paragraph-Klasse und setzen Sie die Tiefe auf 3.
1. Fügen Sie die erstellten Absätze zur [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) Absatzkollektion hinzu.
1. Speichern Sie die Präsentation.

Dieser Code, der eine Implementierung der obigen Schritte ist, zeigt Ihnen, wie Sie eine mehrstufige Aufzählungsliste erstellen:

```php
  # Erstellen Sie eine Präsentationsinstanz, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen und Zugreifen auf die AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Zugriff auf den Textframe der erstellten AutoShape
    $txtFrm = $aShp->addTextFrame("");
    # Entfernen des standardmäßigen bestehenden Absatzes
    $txtFrm->getParagraphs()->clear();
    # Erstellen des ersten Absatzes
    $para1 = new Paragraph();
    # Setzen des Absatzaufzählungszeichenstils und Symbols
    $para1->setText("Inhalt");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Festlegen der Aufzählungsebene
    $para1->getParagraphFormat()->setDepth(0);
    # Erstellen des zweiten Absatzes
    $para2 = new Paragraph();
    # Setzen des Absatzaufzählungszeichenstils und Symbols
    $para2->setText("Zweite Ebene");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Festlegen der Aufzählungsebene
    $para2->getParagraphFormat()->setDepth(1);
    # Erstellen des dritten Absatzes
    $para3 = new Paragraph();
    # Setzen des Absatzaufzählungszeichenstils und Symbols
    $para3->setText("Dritte Ebene");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Festlegen der Aufzählungsebene
    $para3->getParagraphFormat()->setDepth(2);
    # Erstellen des vierten Absatzes
    $para4 = new Paragraph();
    # Setzen des Absatzaufzählungszeichenstils und Symbols
    $para4->setText("Vierte Ebene");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Festlegen der Aufzählungsebene
    $para4->getParagraphFormat()->setDepth(3);
    # Absatz zum Textframe hinzufügen
    $txtFrm->getParagraphs()->add($para1);
    $txtFrm->getParagraphs()->add($para2);
    $txtFrm->getParagraphs()->add($para3);
    $txtFrm->getParagraphs()->add($para4);
    # Speichern der Präsentation als PPTX-Datei
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## Benutzerdefinierte nummerierte Liste erstellen
Aspose.Slides für PHP über Java bietet eine einfache API, um Absätze mit benutzerdefinierten Zahlenformatierungen zu verwalten. Um eine benutzerdefinierte Zahlenliste in einem Absatz hinzuzufügen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Klasse.
1. Greifen Sie auf die gewünschte Folie in der Folienkollektion mit dem [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide) Objekt zu.
1. Fügen Sie eine AutoShape in die ausgewählte Folie ein.
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) der hinzugefügten Form zu.
1. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).
1. Erstellen Sie die erste Absatzinstanz mit der Paragraph-Klasse und setzen Sie **NumberedBulletStartWith** auf 2.
1. Erstellen Sie die zweite Absatzinstanz mit der Paragraph-Klasse und setzen Sie **NumberedBulletStartWith** auf 3.
1. Erstellen Sie die dritte Absatzinstanz mit der Paragraph-Klasse und setzen Sie **NumberedBulletStartWith** auf 7.
1. Fügen Sie die erstellten Absätze zur [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) Absatzkollektion hinzu.
1. Speichern Sie die Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie eine nummerierte Liste in einer Folie erstellen:

```php
  # Erstellen Sie eine Präsentationsinstanz, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen und Zugreifen auf die AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Zugriff auf den Textframe der erstellten AutoShape
    $txtFrm = $aShp->addTextFrame("");
    # Entfernen des standardmäßigen bestehenden Absatzes
    $txtFrm->getParagraphs()->clear();
    # Erste Liste
    $paragraph1 = new Paragraph();
    $paragraph1->setText("Aufzählung 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("Aufzählung 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph2);
    # Zweite Liste
    $paragraph5 = new Paragraph();
    $paragraph5->setText("Aufzählung 5");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(5);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph5);
    $pres->save($resourcesOutputPath . "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```