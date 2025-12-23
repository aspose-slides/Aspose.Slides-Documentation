---
title: Verwalten von Aufzählungs‑ und nummerierten Listen in Präsentationen mit PHP
linktitle: Listen verwalten
type: docs
weight: 60
url: /de/php-java/manage-bullet/
keywords:
- Aufzählungszeichen
- Aufzählungsliste
- nummerierte Liste
- Symbol‑Aufzählungszeichen
- Bild‑Aufzählungszeichen
- benutzerdefiniertes Aufzählungszeichen
- mehrstufige Liste
- Aufzählung erstellen
- Aufzählung hinzufügen
- Liste hinzufügen
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Aufzählungs‑ und nummerierte Listen in PowerPoint‑ und OpenDocument‑Präsentationen mit Aspose.Slides für PHP via Java verwalten. Schritt‑für‑Schritt‑Anleitung."
---

In **Microsoft PowerPoint** können Sie Aufzählungs‑ und Nummerierungslisten genau so erstellen wie in Word und anderen Texteditoren. **Aspose.Slides for PHP via Java** ermöglicht ebenfalls die Verwendung von Aufzählungszeichen und Nummern in Folien Ihrer Präsentationen.

## **Warum Aufzählungslisten verwenden?**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. 

**Beispiel für eine Aufzählungsliste**

In den meisten Fällen erfüllt eine Aufzählungsliste drei Hauptfunktionen:

- lenkt die Aufmerksamkeit Ihrer Leser oder Zuschauer auf wichtige Informationen  
- ermöglicht es Ihren Lesern oder Zuschauern, Schlüssel­punkte leicht zu überfliegen  
- kommuniziert und vermittelt wichtige Details effizient.

## **Warum nummerierte Listen verwenden?**

Nummerierte Listen unterstützen ebenfalls die Strukturierung und Darstellung von Informationen. Idealerweise sollten Sie Zahlen (statt Aufzählungszeichen) verwenden, wenn die Reihenfolge der Einträge (z. B. *Schritt 1, Schritt 2* usw.) wichtig ist oder wenn ein Eintrag referenziert werden muss (z. B. *siehe Schritt 3*).

**Beispiel für eine nummerierte Liste**

Dies ist eine Zusammenfassung der Schritte (Schritt 1 bis Schritt 15) im **Erstellen von Aufzählungszeichen**‑Verfahren unten:

1. Erstellen Sie eine Instanz der Präsentations‑Klasse.  
2. Führen Sie mehrere Aufgaben aus (Schritt 3 bis Schritt 14).  
3. Speichern Sie die Präsentation.  

## **Aufzählungszeichen erstellen**
Dieses Thema ist ebenfalls Teil der Themenreihe zur Verwaltung von Textabsätzen. Auf dieser Seite wird gezeigt, wie wir Absatz‑Aufzählungszeichen verwalten können. Aufzählungszeichen sind besonders nützlich, wenn etwas in Schritten beschrieben werden soll. Außerdem wirkt der Text gut strukturiert, wenn Aufzählungszeichen verwendet werden. Aufgezählte Absätze sind stets leichter zu lesen und zu verstehen. Wir zeigen, wie Entwickler dieses kleine, aber leistungsstarke Feature von Aspose.Slides for PHP via Java nutzen können. Bitte folgen Sie den untenstehenden Schritten, um die Absatz‑Aufzählungszeichen mit Aspose.Slides for PHP via Java zu verwalten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse.  
1. Greifen Sie mit dem [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide)-Objekt auf die gewünschte Folie in der Folien‑Sammlung zu.  
1. Fügen Sie in der ausgewählten Folie eine [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationText) hinzu.  
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) der hinzugefügten Form zu.  
1. Entfernen Sie den Standardabsatz im TextFrame.  
1. Erstellen Sie die erste Absatz‑Instanz mit der [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/Paragraph)-Klasse.  
1. Legen Sie den Aufzählungstyp des Absatzes fest.  
1. Setzen Sie den Aufzählungstyp auf [Symbol](https://reference.aspose.com/slides/php-java/aspose.slides/BulletType#Symbol) und geben Sie das Aufzählungszeichen an.  
1. Setzen Sie den Absatz‑Text.  
1. Legen Sie den Absatz‑Einzug fest, um das Aufzählungszeichen zu positionieren.  
1. Setzen Sie die Farbe des Aufzählungszeichens.  
1. Legen Sie die Höhe der Aufzählungszeichen fest.  
1. Fügen Sie den erstellten Absatz zur Absatz‑Sammlung des TextFrames hinzu.  
1. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die Schritte **7 bis 13**.  
1. Speichern Sie die Präsentation.

Dieses Beispiel‑Code‑Snippet — eine Umsetzung der oben genannten Schritte — zeigt, wie Sie eine Aufzählungsliste in einer Folie erstellen:
```php
  # Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen und Zugriff auf AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Zugriff auf den TextFrame der erstellten AutoShape
    $txtFrm = $aShp->getTextFrame();
    # Entfernen des standardmäßigen vorhandenen Absatzes
    $txtFrm->getParagraphs()->removeAt(0);
    # Erstellen eines Absatzes
    $para = new Paragraph();
    # Festlegen des Absatz‑Aufzählungsstils und Symbols
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Festlegen des Absatztextes
    $para->setText("Welcome to Aspose.Slides");
    # Festlegen des Aufzählungs‑Einzugs
    $para->getParagraphFormat()->setIndent(25);
    # Festlegen der Aufzählungsfarbe
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    # IsBulletHardColor auf true setzen, um eigene Aufzählungsfarbe zu verwenden
    $para->getParagraphFormat()->getBullet()->isBulletHardColor();
    # Festlegen der Aufzählungshöhe
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Hinzufügen des Absatzes zum TextFrame
    $txtFrm->getParagraphs()->add($para);
    # Speichern der Präsentation als PPTX-Datei
    $pres->save("Bullet.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **Bild‑Aufzählungszeichen erstellen**

Aspose.Slides for PHP via Java ermöglicht es Ihnen, die Aufzählungszeichen in Aufzählungslisten zu ändern. Sie können die Aufzählungszeichen durch eigene Symbole oder Bilder ersetzen. Wenn Sie einer Liste visuelles Interesse verleihen oder die Aufmerksamkeit noch stärker auf einzelne Einträge lenken möchten, können Sie Ihr eigenes Bild als Aufzählungszeichen verwenden.

{{% alert color="primary" %}} 

Idealerweise wählen Sie, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, ein einfaches Grafikbild mit transparentem Hintergrund. Solche Bilder eignen sich am besten als benutzerdefinierte Aufzählungssymbole. 

In jedem Fall wird das gewählte Bild auf eine sehr kleine Größe reduziert, sodass wir dringend empfehlen, ein Bild zu wählen, das auch in stark verkleinertem Zustand gut aussieht (als Ersatz für das Aufzählungszeichen) in einer Liste. 

{{% /alert %}} 

So erstellen Sie ein Bild‑Aufzählungszeichen:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse  
1. Greifen Sie mit dem [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide)-Objekt auf die gewünschte Folie in der Folien‑Sammlung zu  
1. Fügen Sie in der ausgewählten Folie eine AutoShape hinzu  
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) der hinzugefügten Form zu  
1. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)  
1. Erstellen Sie die erste Absatz‑Instanz mit der Paragraph‑Klasse  
1. Laden Sie das Bild aus der Festplatte in [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/interfaces/IPPImage)  
1. Setzen Sie den Aufzählungstyp auf Bild und geben Sie das Bild an  
1. Setzen Sie den Absatz‑Text  
1. Legen Sie den Absatz‑Einzug fest, um das Aufzählungszeichen zu positionieren  
1. Setzen Sie die Farbe des Aufzählungszeichens  
1. Legen Sie die Höhe der Aufzählungszeichen fest  
1. Fügen Sie den erstellten Absatz zur [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)-Absatz‑Sammlung hinzu  
1. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den vorherigen Schritten  
1. Speichern Sie die Präsentation

Dieser PHP‑Code zeigt, wie Sie ein Bild‑Aufzählungszeichen in einer Folie erstellen:
```php
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Bild für Aufzählungszeichen instanziieren
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
    # Zugriff auf den TextFrame der erstellten AutoShape
    $txtFrm = $aShp->getTextFrame();
    # Entfernen des standardmäßigen vorhandenen Absatzes
    $txtFrm->getParagraphs()->removeAt(0);
    # Neuer Absatz erstellen
    $para = new Paragraph();
    $para->setText("Welcome to Aspose.Slides");
    # Festlegen des Absatz‑Aufzählungsstils und Bildes
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $para->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Festlegen der Aufzählungshöhe
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Absatz zum TextFrame hinzufügen
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


## **Mehrstufige Aufzählungszeichen erstellen**

Um eine Aufzählungsliste zu erstellen, die Elemente auf verschiedenen Ebenen enthält — zusätzliche Unterlisten unter der Hauptliste — folgen Sie diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse.  
1. Greifen Sie mit dem [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide)-Objekt auf die gewünschte Folie in der Folien‑Sammlung zu.  
1. Fügen Sie in der ausgewählten Folie eine AutoShape hinzu.  
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) der hinzugefügten Form zu.  
1. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).  
1. Erstellen Sie die erste Absatz‑Instanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 0.  
1. Erstellen Sie die zweite Absatz‑Instanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 1.  
1. Erstellen Sie die dritte Absatz‑Instanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 2.  
1. Erstellen Sie die vierte Absatz‑Instanz mit der Paragraph‑Klasse und setzen Sie die Tiefe auf 3.  
1. Fügen Sie die erstellten Absätze zur [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)-Absatz‑Sammlung hinzu.  
1. Speichern Sie die Präsentation.

Dieser Code, der die oben genannten Schritte implementiert, zeigt, wie Sie eine mehrstufige Aufzählungsliste erstellen:
```php
  # Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen und Zugriff auf AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Zugriff auf den TextFrame der erstellten AutoShape
    $txtFrm = $aShp->addTextFrame("");
    # Entfernen des standardmäßigen vorhandenen Absatzes
    $txtFrm->getParagraphs()->clear();
    # Erstellen des ersten Absatzes
    $para1 = new Paragraph();
    # Festlegen des Absatz‑Aufzählungsstils und Symbols
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Festlegen der Aufzählungsebene
    $para1->getParagraphFormat()->setDepth(0);
    # Erstellen des zweiten Absatzes
    $para2 = new Paragraph();
    # Festlegen des Absatz‑Aufzählungsstils und Symbols
    $para2->setText("Second level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Festlegen der Aufzählungsebene
    $para2->getParagraphFormat()->setDepth(1);
    # Erstellen des dritten Absatzes
    $para3 = new Paragraph();
    # Festlegen des Absatz‑Aufzählungsstils und Symbols
    $para3->setText("Third level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Festlegen der Aufzählungsebene
    $para3->getParagraphFormat()->setDepth(2);
    # Erstellen des vierten Absatzes
    $para4 = new Paragraph();
    # Festlegen des Absatz‑Aufzählungsstils und Symbols
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Festlegen der Aufzählungsebene
    $para4->getParagraphFormat()->setDepth(3);
    # Hinzufügen des Absatzes zum TextFrame
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
Aspose.Slides for PHP via Java bietet eine einfache API zur Verwaltung von Absätzen mit benutzerdefinierten Zahlenformaten. Um einer Absatz‑Liste eine benutzerdefinierte Nummerierung hinzuzufügen, folgen Sie bitte diesen Schritten:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Klasse.  
1. Greifen Sie mit dem [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/islide)-Objekt auf die gewünschte Folie in der Folien‑Sammlung zu.  
1. Fügen Sie in der ausgewählten Folie eine AutoShape hinzu.  
1. Greifen Sie auf den [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe) der hinzugefügten Form zu.  
1. Entfernen Sie den Standardabsatz im [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe).  
1. Erstellen Sie die erste Absatz‑Instanz mit der Paragraph‑Klasse und setzen Sie **NumberedBulletStartWith** auf 2  
1. Erstellen Sie die zweite Absatz‑Instanz mit der Paragraph‑Klasse und setzen Sie **NumberedBulletStartWith** auf 3  
1. Erstellen Sie die dritte Absatz‑Instanz mit der Paragraph‑Klasse und setzen Sie **NumberedBulletStartWith** auf 7  
1. Fügen Sie die erstellten Absätze zur [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe)-Absatz‑Sammlung hinzu.  
1. Speichern Sie die Präsentation.

Dieser PHP‑Code zeigt, wie Sie eine nummerierte Liste in einer Folie erstellen:
```php
  # Instanziieren einer Presentation-Klasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen und Zugriff auf AutoShape
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Zugriff auf den TextFrame der erstellten AutoShape
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

**Können mit Aspose.Slides erstellte Aufzählungs‑ und Nummerierungslisten in andere Formate wie PDF oder Bilder exportiert werden?**

Ja, Aspose.Slides bewahrt das Format und die Struktur von Aufzählungs‑ und Nummerierungslisten vollständig, wenn Präsentationen in Formate wie PDF, Bilder und andere exportiert werden, und sorgt für konsistente Ergebnisse.

**Ist es möglich, Aufzählungs‑ oder Nummerierungslisten aus bestehenden Präsentationen zu importieren?**

Ja, Aspose.Slides ermöglicht das Importieren und Bearbeiten von Aufzählungs‑ oder Nummerierungslisten aus bestehenden Präsentationen, wobei das ursprüngliche Format und Aussehen erhalten bleiben.

**Unterstützt Aspose.Slides Aufzählungs‑ und Nummerierungslisten in Präsentationen, die in mehreren Sprachen erstellt wurden?**

Ja, Aspose.Slides unterstützt mehrsprachige Präsentationen vollständig und erlaubt das Erstellen von Aufzählungs‑ und Nummerierungslisten in jeder Sprache, einschließlich der Verwendung von Sonder‑ oder nicht‑lateinischen Zeichen.