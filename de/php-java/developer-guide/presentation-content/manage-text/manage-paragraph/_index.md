---
title: PowerPoint-Textabsätze in PHP verwalten
linktitle: Absatz verwalten
type: docs
weight: 40
url: /de/php-java/manage-paragraph/
keywords:
- Text hinzufügen
- Absatz hinzufügen
- Text verwalten
- Absatz verwalten
- Aufzählungszeichen verwalten
- Absatzeinrückung
- Hängende Einrückung
- Absatzaufzählungszeichen
- Nummerierte Liste
- Aufzählungsliste
- Absatzeigenschaften
- HTML importieren
- Text zu HTML
- Absatz zu HTML
- Absatz zu Bild
- Text zu Bild
- Absatz exportieren
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Meistern Sie die Absatzformatierung mit Aspose.Slides für PHP über Java — optimieren Sie Ausrichtung, Abstand und Stil in PPT-, PPTX- und ODP‑Präsentationen."
---
Aspose.Slides stellt alle Klassen bereit, die Sie benötigen, um mit PowerPoint-Texten, Absätzen und Portionen zu arbeiten.

* Aspose.Slides bietet die Klasse [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) an, mit der Sie Objekte hinzufügen können, die einen Absatz darstellen. Ein `TextFame`-Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erstellt).
* Aspose.Slides bietet die Klasse [Paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/) an, mit der Sie Objekte hinzufügen können, die Portionen darstellen. Ein `Paragraph`-Objekt kann eine oder mehrere Portionen enthalten (eine Sammlung von Portion-Objekten).
* Aspose.Slides bietet die Klasse [Portion](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/) an, mit der Sie Objekte hinzufügen können, die Texte und deren Formatierungseigenschaften darstellen.

Ein `Paragraph`-Objekt kann Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `Portion`-Objekte verarbeiten.

## **Mehrere Absätze mit mehreren Portionen hinzufügen**

Diese Schritte zeigen, wie Sie einen Textframe mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Portionen enthält:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
4. Rufen Sie das mit dem [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) verbundene ITextFrame ab.
5. Erstellen Sie zwei [Paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/)-Objekte und fügen Sie sie zur Absatzsammlung des [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) hinzu.
6. Erstellen Sie für jeden neuen `Paragraph` drei [Portion](https://reference.aspose.com/slides/de/php-java/aspose.slides/portion/)-Objekte (zwei Portion-Objekte für den Standard-Paragraph) und fügen Sie jedes `Portion`-Objekt der Portionensammlung des jeweiligen `Paragraph` hinzu.
7. Legen Sie für jede Portion einen Text fest.
8. Wenden Sie Ihre bevorzugten Formatierungsoptionen auf jede Portion an, indem Sie die vom `Portion`‑Objekt bereitgestellten Formatierungseigenschaften nutzen.
9. Speichern Sie die geänderte Präsentation.

```php
# Instanziieren Sie eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
$pres = new Presentation();
try {
    # Erste Folie abrufen
    $slide = $pres->getSlides()->get_Item(0);
    # Ein AutoShape vom Typ Rechteck hinzufügen
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # TextFrame des AutoShape zugreifen
    $tf = $ashp->getTextFrame();
    # Absätze und Portionen mit verschiedenen Textformaten erstellen
    $para0 = $tf->getParagraphs()->get_Item(0);
    $port01 = new Portion();
    $port02 = new Portion();
    $para0->getPortions()->add($port01);
    $para0->getPortions()->add($port02);
    $para1 = new Paragraph();
    $tf->getParagraphs()->add($para1);
    $port10 = new Portion();
    $port11 = new Portion();
    $port12 = new Portion();
    $para1->getPortions()->add($port10);
    $para1->getPortions()->add($port11);
    $para1->getPortions()->add($port12);
    $para2 = new Paragraph();
    $tf->getParagraphs()->add($para2);
    $port20 = new Portion();
    $port21 = new Portion();
    $port22 = new Portion();
    $para2->getPortions()->add($port20);
    $para2->getPortions()->add($port21);
    $para2->getPortions()->add($port22);
    for($i = 0; $i < 3; $i++) {
        for($j = 0; $j < 3; $j++) {
            $portion = $tf->getParagraphs()->get_Item($i)->getPortions()->get_Item($j);
            $portion->setText("Portion0" . $j);
            if ($j == 0) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
                $portion->getPortionFormat()->setFontBold(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(15);
            } else if ($j == 1) {
                $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
                $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
                $portion->getPortionFormat()->setFontItalic(NullableBool::True);
                $portion->getPortionFormat()->setFontHeight(18);
            }
        }
    }
    # PPTX auf die Festplatte schreiben
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Absatzaufzählungszeichen verwalten**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie dem ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mithilfe der Klasse [Paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/).
7. Setzen Sie den Aufzählungszeichen-`Type` des Absatzes auf `Symbol` und legen Sie das Aufzählungszeichen-Zeichen fest.
8. Legen Sie den Absatz-`Text` fest.
9. Setzen Sie den Absatz-`Indent` für das Aufzählungszeichen.
10. Legen Sie eine Farbe für das Aufzählungszeichen fest.
11. Legen Sie die Höhe des Aufzählungszeichens fest.
12. Fügen Sie den neuen Absatz zur Absatzsammlung des `TextFrame` hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den Schritten 7 bis 13.
14. Speichern Sie die Präsentation.

```php
# Instanziiert eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
$pres = new Presentation();
try {
    # Greift auf die erste Folie zu
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt ein Autoshape hinzu und greift darauf zu
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den Textframe des Autoshapes zu
    $txtFrm = $aShp->getTextFrame();
    # Entfernt den Standardabsatz
    $txtFrm->getParagraphs()->removeAt(0);
    # Erstellt einen Absatz
    $para = new Paragraph();
    # Legt den Aufzählungszeichenstil und das Symbol für den Absatz fest
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Legt den Absatztext fest
    $para->setText("Welcome to Aspose.Slides");
    # Legt die Einrückung des Aufzählungszeichens fest
    $para->getParagraphFormat()->setIndent(25);
    # Legt die Farbe des Aufzählungszeichens fest
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// set IsBulletHardColor auf true, um eigene Aufzählungszeichenfarbe zu verwenden

    # Legt die Aufzählungszeichenhöhe fest
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Fügt den Absatz dem Textframe hinzu
    $txtFrm->getParagraphs()->add($para);
    # Erstellt den zweiten Absatz
    $para2 = new Paragraph();
    # Legt den Aufzählungszeichen-Typ und -Stil des Absatzes fest
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Fügt den Absatztext hinzu
    $para2->setText("This is numbered bullet");
    # Legt die Einrückung des Aufzählungszeichens fest
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// set IsBulletHardColor auf true, um eigene Aufzählungszeichenfarbe zu verwenden

    # Legt die Aufzählungszeichenhöhe fest
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Fügt den Absatz dem Textframe hinzu
    $txtFrm->getParagraphs()->add($para2);
    # Speichert die geänderte Präsentation
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Bildaufzählungszeichen verwalten**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie dem Folie ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mithilfe der Klasse [Paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/).
7. Laden Sie das Bild in [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/).
8. Setzen Sie den Aufzählungszeichen-Typ auf [Picture](https://reference.aspose.com/slides/de/php-java/aspose.slides/bullettype/#Picture) und legen Sie das Bild fest.
9. Legen Sie den Absatz-`Text` fest.
10. Setzen Sie den Absatz-`Indent` für das Aufzählungszeichen.
11. Legen Sie eine Farbe für das Aufzählungszeichen fest.
12. Legen Sie die Höhe des Aufzählungszeichens fest.
13. Fügen Sie den neuen Absatz zur Absatzsammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang basierend auf den vorherigen Schritten.
15. Speichern Sie die geänderte Präsentation.

```php
# Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
$presentation = new Presentation();
try {
    # Greift auf die erste Folie zu
    $slide = $presentation->getSlides()->get_Item(0);
    # Instanziert das Bild für Aufzählungszeichen
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Fügt ein Autoshape hinzu und greift darauf zu
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den Textframe des Autoshapes zu
    $textFrame = $autoShape->getTextFrame();
    # Entfernt den Standardabsatz
    $textFrame->getParagraphs()->removeAt(0);
    # Erstellt einen neuen Absatz
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Legt den Aufzählungszeichenstil und das Bild des Absatzes fest
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Legt die Aufzählungszeichenhöhe fest
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Fügt den Absatz dem Textframe hinzu
    $textFrame->getParagraphs()->add($paragraph);
    # Speichert die Präsentation als PPTX-Datei
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Speichert die Präsentation als PPT-Datei
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Mehrstufige Aufzählungszeichen verwalten**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der neuen Folie ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz über die Klasse [Paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/) und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatzinstanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatzinstanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatzinstanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze zur Absatzsammlung des `TextFrame` hinzu.
11. Speichern Sie die geänderte Präsentation.

```php
# Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
$pres = new Presentation();
try {
    # Greift auf die erste Folie zu
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt ein Autoshape hinzu und greift darauf zu
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den Textframe des erstellten Autoshapes zu
    $text = $aShp->addTextFrame("");
    # Löscht den Standardabsatz
    $text->getParagraphs()->clear();
    # Fügt den ersten Absatz hinzu
    $para1 = new Paragraph();
    $para1->setText("Content");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Legt die Aufzählungsebene fest
    $para1->getParagraphFormat()->setDepth(0);
    # Fügt den zweiten Absatz hinzu
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Legt die Aufzählungsebene fest
    $para2->getParagraphFormat()->setDepth(1);
    # Fügt den dritten Absatz hinzu
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Legt die Aufzählungsebene fest
    $para3->getParagraphFormat()->setDepth(2);
    # Fügt den vierten Absatz hinzu
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Legt die Aufzählungsebene fest
    $para4->getParagraphFormat()->setDepth(3);
    # Fügt die Absätze zur Sammlung hinzu
    $text->getParagraphs()->add($para1);
    $text->getParagraphs()->add($para2);
    $text->getParagraphs()->add($para3);
    $text->getParagraphs()->add($para4);
    # Speichert die Präsentation als PPTX-Datei
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Einen Absatz mit einer benutzerdefinierten nummerierten Liste verwalten**

Die Klasse [BulletFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/bulletformat/) stellt die Methode [setNumberedBulletStartWith](https://reference.aspose.com/slides/de/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) und weitere Methoden bereit, mit denen Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung verwalten können.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie dem Folie ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz über die Klasse [Paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/) und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/de/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) auf 2.
7. Erstellen Sie die zweite Absatzinstanz über die Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatzinstanz über die Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze zur Absatzsammlung des `TextFrame` hinzu.
10. Speichern Sie die geänderte Präsentation.

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den Textframe des erzeugten Autoshapes zu
    $textFrame = $shape->getTextFrame();
    # Entfernt den vorhandenen Standardabsatz
    $textFrame->getParagraphs()->removeAt(0);
    # Erste Liste
    $paragraph1 = new Paragraph();
    $paragraph1->setText("bullet 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("bullet 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("bullet 7");
    $paragraph5->getParagraphFormat()->setDepth(4);
    $paragraph5->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(7);
    $paragraph5->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph5);
    $presentation->save("SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Einrückung der ersten Zeile für einen Absatz festlegen**

Verwenden Sie die Methode [ParagraphFormat::setIndent](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/setindent/) um die Erstzeileneinrückung eines Absatzes zu steuern. Diese Methode verschiebt nur die erste Zeile relativ zum linken Rand des Absatzes. Ein positiver Wert verschiebt die erste Zeile nach rechts, während die übrigen Zeilen am Absatzkörper ausgerichtet bleiben.

Verwenden Sie [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/setmarginleft/), wenn Sie den gesamten Absatz verschieben müssen. Verwenden Sie [ParagraphFormat::setIndent](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/setindent/), wenn Sie nur die erste Zeile verschieben möchten.

Das nachstehende Beispiel erstellt mehrere Absätze und wendet verschiedene Einrückungswerte an, um zu zeigen, wie die Erstzeileneinrückung das Absatzlayout beeinflusst.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Shape ein leeres [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) hinzu und entfernen Sie den Standardabsatz.
5. Erstellen Sie mehrere Absätze und setzen Sie unterschiedliche [Indent](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/setindent/)‑Werte dafür.
6. Fügen Sie die Absätze dem TextFrame hinzu.
7. Speichern Sie die geänderte Präsentation.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $firstParagraph->getParagraphFormat()->setIndent(0.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $secondParagraph->getParagraphFormat()->setIndent(20.0);

    $thirdParagraph = new Paragraph();
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $thirdParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $thirdParagraph->setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    $thirdParagraph->getParagraphFormat()->setMarginLeft(20.0);
    $thirdParagraph->getParagraphFormat()->setIndent(40.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);
    $textFrame->getParagraphs()->add($thirdParagraph);

    $presentation->save("paragraph_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Hängende Einrückung für einen Absatz festlegen**

Eine hängende Einrückung ist ein Absatzlayout, bei dem die erste Zeile links von den übrigen Zeilen beginnt. In Aspose.Slides erzeugen Sie diesen Effekt mit der Methode [ParagraphFormat::setIndent](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/setindent/). Setzen Sie die Einrückung auf einen negativen Wert, um die erste Zeile nach links relativ zum Absatzkörper zu verschieben.

In der Praxis definiert [ParagraphFormat::setMarginLeft](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/setmarginleft/), die linke Position des Absatzkörpers, und [ParagraphFormat::setIndent](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/setindent/), die Position der ersten Zeile relativ zu diesem Rand. Um eine hängende Einrückung zu erzeugen, setzen Sie einen positiven `MarginLeft`‑Wert und einen negativen `Indent`‑Wert.

Diese Formatierung ist nützlich für Bibliografien, Verweise, Glossareinträge und andere Absätze, bei denen umgebrochene Zeilen unter dem Absatzkörper ausgerichtet sein müssen und nicht unter dem ersten Zeichen der ersten Zeile.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
2. Greifen Sie auf die Ziel‑Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Shape ein leeres [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) hinzu und entfernen Sie den Standardabsatz.
5. Erstellen Sie Absätze und setzen Sie für jeden Absatz einen positiven [MarginLeft](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/setmarginleft/)‑Wert.
6. Setzen Sie einen negativen [Indent](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/setindent/)‑Wert, um den hängenden Einrückungseffekt zu erzeugen.
7. Fügen Sie die Absätze dem TextFrame hinzu.
8. Speichern Sie die geänderte Präsentation.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $rectangleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle,50,50,420,220);
    $rectangleShape->getFillFormat()->setFillType(FillType::NoFill);
    $rectangleShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $rectangleShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);

    $textFrame = $rectangleShape->addTextFrame("");
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    $textFrame->getParagraphs()->removeAt(0);

    $firstParagraph = new Paragraph();
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $firstParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $firstParagraph->setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    $firstParagraph->getParagraphFormat()->setMarginLeft(40.0);
    $firstParagraph->getParagraphFormat()->setIndent(-20.0);

    $secondParagraph = new Paragraph();
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $secondParagraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $secondParagraph->setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    $secondParagraph->getParagraphFormat()->setMarginLeft(60.0);
    $secondParagraph->getParagraphFormat()->setIndent(-30.0);

    $textFrame->getParagraphs()->add($firstParagraph);
    $textFrame->getParagraphs()->add($secondParagraph);

    $presentation->save("hanging_indent.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Das Ergebnis:

![The hanging indent of the paragraphs](hanging_indent.png)

## **End‑Paragraph‑Run‑Eigenschaften verwalten**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
2. Holen Sie die Referenz der Folie, die den Absatz enthält, über deren Position.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) mit zwei Absätzen hinzu.
5. Setzen Sie die Schriftgröße und den Schriftarttyp für die Absätze.
6. Setzen Sie die End‑Eigenschaften für die Absätze.
7. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

```php
$pres = new Presentation();
try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Sample text"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Sample text 2"));
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(48);
    $portionFormat::setLatinFont(new FontData("Times New Roman"));
    $para2->setEndParagraphPortionFormat($portionFormat);
    $shape->getTextFrame()->getParagraphs()->add($para1);
    $shape->getTextFrame()->getParagraphs()->add($para2);
    $pres->save($resourcesOutputPath . "pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **HTML‑Text in Absätze importieren**

Aspose.Slides bietet erweiterte Unterstützung für das Importieren von HTML‑Text in Absätze.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie dem Folie ein [AutoShape](https://reference.aspose.com/slides/de/php-java/aspose.slides/autoshape/) hinzu.
4. Fügen Sie dem `AutoShape` ein [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Lesen Sie die Quell‑HTML‑Datei mit einem TextReader.
7. Erstellen Sie die erste Absatzinstanz über die Klasse [Paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/).
8. Fügen Sie den HTML‑Dateiinhalt aus dem gelesenen TextReader zur [ParagraphCollection](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphcollection/) des TextFrame hinzu.
9. Speichern Sie die geänderte Präsentation.

```php
# Leere Präsentationsinstanz erstellen
$pres = new Presentation();
try {
    # Auf die standardmäßige erste Folie der Präsentation zugreifen
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape hinzufügen, um den HTML-Inhalt aufzunehmen
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Textframe zum Shape hinzufügen
    $ashape->addTextFrame("");
    # Alle Absätze im hinzugefügten Textframe löschen
    $ashape->getTextFrame()->getParagraphs()->clear();
    # HTML-Datei mit StreamReader laden
    $tr = new StreamReader("file.html");
    # Text aus dem HTML-StreamReader in den Textframe hinzufügen
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Präsentation speichern
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Absatztext nach HTML exportieren**

Aspose.Slides bietet erweiterte Unterstützung für das Exportieren von Texten (die in Absätzen enthalten sind) nach HTML.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Greifen Sie auf das Shape zu, das den zu HTML zu exportierenden Text enthält.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) des Shape zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML‑Datei hinzu.
6. Geben Sie einen Start‑Index an den StreamWriter weiter und exportieren Sie die gewünschten Absätze.

```php
# Präsentationsdatei laden
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Auf die standardmäßige erste Folie der Präsentation zugreifen
    $slide = $pres->getSlides()->get_Item(0);
    # Gewünschter Index
    $index = 0;
    # Auf das hinzugefügte Shape zugreifen
    $ashape = $slide->getShapes()->get_Item($index);
    # Ausgabedatei HTML erstellen
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Ersten Absatz als HTML extrahieren
    # Absatzdaten in HTML schreiben, indem der Startindex des Absatzes und die zu kopierenden Gesamtabsaetze angegeben werden
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```

## **Einen Absatz als Bild speichern**

In diesem Abschnitt werden wir zwei Beispiele untersuchen, die zeigen, wie ein Textabsatz, dargestellt durch die Klasse [Paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/), als Bild gespeichert werden kann. Beide Beispiele beinhalten das Abrufen des Bildes eines Shapes, das den Absatz enthält, mithilfe der `getImage`‑Methoden der Klasse [Shape](https://reference.aspose.com/slides/de/php-java/aspose.slides/shape/), das Berechnen der Grenzen des Absatzes innerhalb des Shapes und das Exportieren als Bitmap‑Bild. Diese Vorgehensweisen ermöglichen es, bestimmte Textteile aus PowerPoint‑Präsentationen zu extrahieren und als separate Bilder zu speichern, was in verschiedenen Szenarien nützlich sein kann.

Angenommen, wir haben eine Präsentationsdatei namens sample.pptx mit einer Folie, bei der das erste Shape ein Textfeld mit drei Absätzen ist.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Beispiel 1**

In diesem Beispiel erhalten wir den zweiten Absatz als Bild. Dazu extrahieren wir das Bild des Shapes von der ersten Folie der Präsentation und berechnen anschließend die Grenzen des zweiten Absatzes im TextFrame des Shapes. Der Absatz wird dann auf ein neues Bitmap‑Bild redgezeichnet, das im PNG‑Format gespeichert wird. Diese Methode ist besonders nützlich, wenn Sie einen bestimmten Absatz als separates Bild speichern möchten und dabei die genauen Abmessungen und die Formatierung des Textes beibehalten wollen.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Forme das Shape im Speicher als Bitmap.
    $shapeImage = $firstShape->getImage();
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Erstelle ein Shape-Bitmap aus dem Speicher.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Berechne die Grenzen des zweiten Absatzes.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();

    // Berechne die Koordinaten und Größe für das Ausgabebild (Mindestgröße - 1x1 Pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Schneide das Shape-Bitmap zu, um ausschließlich das Absatz-Bitmap zu erhalten.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Das Ergebnis:

![The paragraph image](paragraph_to_image_output.png)

**Beispiel 2**

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir Skalierungsfaktoren zum Absatzbild hinzufügen. Das Shape wird aus der Präsentation extrahiert und mit einem Skalierungsfaktor von `2` als Bild gespeichert. Dadurch wird beim Export des Absatzes eine höhere Auflösung erzielt. Die Absatzgrenzen werden anschließend unter Berücksichtigung der Skalierung berechnet. Skalierung kann besonders nützlich sein, wenn ein detaillierteres Bild benötigt wird, beispielsweise für den Einsatz in hochwertigen Druckmaterialien.

```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Shape im Speicher als Bitmap mit Skalierung speichern.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Shape-Bitmap aus dem Speicher erstellen.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Grenzen des zweiten Absatzes berechnen.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Koordinaten und Größe für das Ausgabebild berechnen (Mindestgröße - 1x1 Pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Shape-Bitmap zuschneiden, um ausschließlich das Absatz-Bitmap zu erhalten.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Kann ich das Zeilenumbruch innerhalb eines TextFrames vollständig deaktivieren?**

Ja. Verwenden Sie die Zeilenumbruch‑Einstellung des TextFrames ([setWrapText](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframeformat/setwraptext/)), um den Umbruch zu deaktivieren, sodass Zeilen nicht an den Rändern des Frames umbrechen.

**Wie kann ich die genauen Folien‑Grenzen eines bestimmten Absatzes ermitteln?**

Sie können das Begrenzungsrechteck des Absatzes (und sogar eines einzelnen Portions) abrufen, um seine genaue Position und Größe auf der Folie zu kennen.

**Wo wird die Absatz‑Ausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[Alignment](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/setalignment/) ist eine Einstellung auf Absatz‑Ebene in [ParagraphFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/); sie gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

**Kann ich eine Rechtschreibprüfungs‑Sprache nur für einen Teil eines Absatzes festlegen (z. B. ein Wort)?**

Ja. Die Sprache wird auf Portion‑Ebene festgelegt ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setLanguageId)), sodass mehrere Sprachen innerhalb eines einzigen Absatzes koexistieren können.