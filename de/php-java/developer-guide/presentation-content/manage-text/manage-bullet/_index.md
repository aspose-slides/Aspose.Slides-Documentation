---
title: Verwalten von Aufzählungs- und Nummerierungslisten in Präsentationen mit PHP
linktitle: Listen verwalten
type: docs
weight: 60
url: /de/php-java/manage-bullet/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- Nummerierte Liste
- Symbol-Aufzählungszeichen
- Bildaufzählungszeichen
- Benutzerdefiniertes Aufzählungszeichen
- Mehrstufige Liste
- Aufzählungszeichen erstellen
- Aufzählungszeichen hinzufügen
- Liste hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungs- und Nummerierungslisten in PowerPoint und OpenDocument Präsentationen mit Aspose.Slides für PHP via Java verwalten. Schritt-für-Schritt-Anleitung."
---

In **Microsoft PowerPoint** können Sie Aufzählungs‑ und Nummerierungslisten auf dieselbe Weise erstellen wie in Word und anderen Texteditoren. **Aspose.Slides for PHP via Java** ermöglicht ebenfalls die Verwendung von Aufzählungszeichen und Zahlen in Folien Ihrer Präsentationen.

## **Warum Aufzählungslisten verwenden?**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. 

**Beispiel für Aufzählungsliste**

In den meisten Fällen erfüllt eine Aufzählungsliste drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Betrachter auf wichtige Informationen
- ermöglicht es Ihren Lesern oder Betrachtern, Schlüsselthemen leicht zu überfliegen
- kommuniziert und übermittelt wichtige Details effizient.

## **Warum nummerierte Listen verwenden?**

Nummerierte Listen helfen ebenfalls beim Organisieren und Darstellen von Informationen. Idealerweise sollten Sie Zahlen (anstelle von Aufzählungszeichen) verwenden, wenn die Reihenfolge der Einträge (z. B. *Schritt 1, Schritt 2* usw.) wichtig ist oder wenn ein Eintrag referenziert werden muss (z. B. *siehe Schritt 3*).

**Beispiel für nummerierte Liste**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im nachfolgenden Verfahren **Creating Bullets**:

1. Erstellen Sie eine Instanz der Präsentationsklasse. 
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14).
3. Speichern Sie die Präsentation. 

## **Aufzählungen erstellen**

Dieses Thema ist ebenfalls Teil der Themenreihe zur Verwaltung von Textabsätzen. Diese Seite zeigt, wie wir Aufzählungszeichen in Absätzen verwalten können. Aufzählungszeichen sind besonders nützlich, wenn etwas Schritt für Schritt beschrieben wird. Darüber hinaus wirkt der Text durch die Verwendung von Aufzählungszeichen gut organisiert. Aufzählungsabsätze sind stets leichter zu lesen und zu verstehen. Wir werden sehen, wie Entwickler diese kleine, aber leistungsfähige Funktion von Aspose.Slides for PHP via Java nutzen können. Bitte folgen Sie den nachstehenden Schritten, um die Aufzählungszeichen von Absätzen mit Aspose.Slides for PHP via Java zu verwalten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Greifen Sie auf die gewünschte Folie in der Folienkollektion zu, indem Sie das Objekt [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) verwenden.
3. Fügen Sie in der ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) der hinzugefügten Form zu.
5. Entfernen Sie den Standardabsatz im TextFrame.
6. Erstellen Sie die erste Absatzinstanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) .
7. Legen Sie den Aufzählungstyp des Absatzes fest.
8. Setzen Sie den Aufzählungstyp auf [Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Symbol) und geben Sie das Aufzählungszeichen an.
9. Setzen Sie den Absatztext.
10. Stellen Sie den Absatz‑Einzug ein, um die Aufzählung zu setzen.
11. Legen Sie die Farbe der Aufzählung fest.
12. Legen Sie die Höhe der Aufzählungszeichen fest.
13. Fügen Sie den erstellten Absatz in die Absatzsammlung des TextFrames ein.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den Schritten **7 bis 13**.
15. Speichern Sie die Präsentation.

```php
  # Instanziieren einer Presentation-Klasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen und Zugriff auf AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Zugriff auf den Textrahmen des erstellten AutoShape
    $txtFrm = $aShp->getTextFrame();
    # Entfernen des standardmäßigen vorhandenen Absatzes
    $txtFrm->getParagraphs()->removeAt(0);
    # Erstellen eines Absatzes
    $para = new Paragraph();
    # Festlegen des Aufzählungsstils und Symbols für den Absatz
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Festlegen des Absatztexts
    $para->setText("Welcome to Aspose.Slides");
    # Festlegen des Aufzählungseinzuges
    $para->getParagraphFormat()->setIndent(25);
    # Festlegen der Aufzählungsfarbe
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # IsBulletHardColor auf true setzen, um eigene Aufzählungsfarbe zu verwenden
    $para->getParagraphFormat()->getBullet()->isBulletHardColor();
    # Festlegen der Aufzählungshöhe
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Hinzufügen des Absatzes zum Textrahmen
    $txtFrm->getParagraphs()->add($para);
    # Speichern der Präsentation als PPTX-Datei
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Bildaufzählungen erstellen**

Aspose.Slides for PHP via Java ermöglicht es Ihnen, die Aufzählungszeichen in Aufzählungslisten zu ändern. Sie können die Aufzählungszeichen durch benutzerdefinierte Symbole oder Bilder ersetzen. Wenn Sie einer Liste visuelles Interesse verleihen oder die Aufmerksamkeit auf Listeneinträge noch stärker lenken möchten, können Sie Ihr eigenes Bild als Aufzählungszeichen verwenden.

{{% alert color="primary" %}} 

Idealerweise, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, sollten Sie ein einfaches Grafikbild mit transparentem Hintergrund wählen. Solche Bilder eignen sich am besten als benutzerdefinierte Aufzählungssymbole. 

Auf jeden Fall wird das gewählte Bild stark verkleinert, daher empfehlen wir dringend, ein Bild auszuwählen, das in einer Liste (als Ersatz für das Aufzählungszeichen) gut aussieht. 

{{% /alert %}} 

Um ein Bildaufzählungszeichen zu erstellen, gehen Sie wie folgt vor:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Greifen Sie auf die gewünschte Folie in der Folienkollektion zu, indem Sie das Objekt [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) verwenden.
3. Fügen Sie in der ausgewählten Folie ein AutoShape hinzu.
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) der hinzugefügten Form zu.
5. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) .
6. Erstellen Sie die erste Absatzinstanz mit der Klasse Paragraph .
7. Laden Sie ein Bild von der Festplatte in [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) .
8. Setzen Sie den Aufzählungstyp auf Picture und legen Sie das Bild fest.
9. Setzen Sie den Absatztext.
10. Stellen Sie den Absatz‑Einzug ein, um die Aufzählung zu setzen.
11. Legen Sie die Farbe der Aufzählung fest.
12. Legen Sie die Höhe der Aufzählungszeichen fest.
13. Fügen Sie den erstellten Absatz in die Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) ein.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang der vorherigen Schritte.
15. Speichern Sie die Präsentation

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
    # Hinzufügen und Zugriff auf AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Zugriff auf den Textrahmen des erstellten AutoShape
    $txtFrm = $aShp->getTextFrame();
    # Entfernen des standardmäßigen vorhandenen Absatzes
    $txtFrm->getParagraphs()->removeAt(0);
    # Erstellen eines neuen Absatzes
    $para = new Paragraph();
    $para->setText("Welcome to Aspose.Slides");
    # Festlegen des Absatz-Auftzählungsstils und Bildes
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $para->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Festlegen der Aufzählungshöhe
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Hinzufügen des Absatzes zum Textrahmen
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


## **Mehrstufige Aufzählungen erstellen**

Um eine Aufzählungsliste zu erstellen, die Elemente auf verschiedenen Ebenen enthält – zusätzliche Listen unter der Hauptaufzählungsliste – gehen Sie die folgenden Schritte durch:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Greifen Sie auf die gewünschte Folie in der Folienkollektion zu, indem Sie das Objekt [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) verwenden.
3. Fügen Sie in der ausgewählten Folie ein AutoShape hinzu.
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) der hinzugefügten Form zu.
5. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) .
6. Erstellen Sie die erste Absatzinstanz mit der Klasse Paragraph und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatzinstanz mit der Klasse Paragraph und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatzinstanz mit der Klasse Paragraph und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatzinstanz mit der Klasse Paragraph und setzen Sie die Tiefe auf 3.
10. Fügen Sie die erstellten Absätze in die Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) ein.
11. Speichern Sie die Präsentation.

```php
  # Instanziieren einer Presentation-Klasse, die eine PPTX-Datei repräsentiert
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen und Zugriff auf AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Zugriff auf den Textrahmen des erstellten AutoShape
    $txtFrm = $aShp->addTextFrame("");
    # Entfernen des standardmäßigen vorhandenen Absatzes
    $txtFrm->getParagraphs()->clear();
    # Erstellen des ersten Absatzes
    $para1 = new Paragraph();
    # Festlegen des Absatz-Aufzählungsstils und Symbols
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Festlegen der Aufzählungsebene
    $para1->getParagraphFormat()->setDepth(0);
    # Erstellen des zweiten Absatzes
    $para2 = new Paragraph();
    # Festlegen des Absatz-Aufzählungsstils und Symbols
    $para2->setText("Second level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Festlegen der Aufzählungsebene
    $para2->getParagraphFormat()->setDepth(1);
    # Erstellen des dritten Absatzes
    $para3 = new Paragraph();
    # Festlegen des Absatz-Aufzählungsstils und Symbols
    $para3->setText("Third level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Festlegen der Aufzählungsebene
    $para3->getParagraphFormat()->setDepth(2);
    # Erstellen des vierten Absatzes
    $para4 = new Paragraph();
    # Festlegen des Absatz-Aufzählungsstils und Symbols
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Festlegen der Aufzählungsebene
    $para4->getParagraphFormat()->setDepth(3);
    # Hinzufügen des Absatzes zum Textrahmen
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


## **Benutzerdefinierte nummerierte Listen erstellen**

Aspose.Slides for PHP via Java bietet eine einfache API zur Verwaltung von Absätzen mit benutzerdefinierter Zahlenformatierung. Um einer Absatz eine benutzerdefinierte Nummernliste hinzuzufügen, folgen Sie bitte den nachstehenden Schritten:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Greifen Sie auf die gewünschte Folie in der Folienkollektion zu, indem Sie das Objekt [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) verwenden.
3. Fügen Sie in der ausgewählten Folie ein AutoShape hinzu.
4. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) der hinzugefügten Form zu.
5. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) .
6. Erstellen Sie die erste Absatzinstanz mit der Klasse Paragraph und setzen Sie **NumberedBulletStartWith** auf 2
7. Erstellen Sie die zweite Absatzinstanz mit der Klasse Paragraph und setzen Sie **NumberedBulletStartWith** auf 3
8. Erstellen Sie die dritte Absatzinstanz mit der Klasse Paragraph und setzen Sie **NumberedBulletStartWith** auf 7
9. Fügen Sie die erstellten Absätze in die Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) ein.
10. Speichern Sie die Präsentation.

```php
  # Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen und Zugriff auf AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Zugriff auf den Textrahmen des erstellten AutoShape
    $txtFrm = $aShp->addTextFrame("");
    # Entfernen des standardmäßigen vorhandenen Absatzes
    $txtFrm->getParagraphs()->clear();
    # Erste Liste
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $txtFrm->getParagraphs()->add($paragraph2);
    # Zweite Liste
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 5");
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


## **FAQ**

**Können mit Aspose.Slides erstellte Aufzählungs- und nummerierte Listen in andere Formate wie PDF oder Bilder exportiert werden?**

Ja, Aspose.Slides bewahrt die Formatierung und Struktur von Aufzählungs- und nummerierten Listen vollständig, wenn Präsentationen in Formate wie PDF, Bilder und andere exportiert werden, und sorgt für konsistente Ergebnisse.

**Ist es möglich, Aufzählungs- oder nummerierte Listen aus bestehenden Präsentationen zu importieren?**

Ja, Aspose.Slides ermöglicht das Importieren und Bearbeiten von Aufzählungs- oder nummerierten Listen aus bestehenden Präsentationen, wobei die ursprüngliche Formatierung und das Erscheinungsbild erhalten bleiben.

**Unterstützt Aspose.Slides Aufzählungs- und nummerierte Listen in Präsentationen, die in mehreren Sprachen erstellt wurden?**

Ja, Aspose.Slides unterstützt mehrsprachige Präsentationen vollständig und ermöglicht das Erstellen von Aufzählungs- und nummerierten Listen in jeder Sprache, einschließlich der Verwendung von Sonder- oder nicht‑lateinischen Zeichen.