---
title: Verwalten von PowerPoint-Textabsätzen in PHP
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
- Absatzeinzug
- Hängender Einzug
- Absatzaufzählung
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
description: "Beherrschen Sie die Absatzformatierung mit Aspose.Slides für PHP via Java — optimieren Sie Ausrichtung, Abstand und Stil in PPT-, PPTX- und ODP-Präsentationen."
---

Aspose.Slides bietet alle Schnittstellen und Klassen, die Sie benötigen, um mit PowerPoint-Texten, Absätzen und Portionen zu arbeiten.

* Aspose.Slides stellt die [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) Schnittstelle bereit, um Objekte hinzuzufügen, die einen Absatz repräsentieren. Ein `ITextFame`‑Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erzeugt).
* Aspose.Slides stellt die [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) Schnittstelle bereit, um Objekte hinzuzufügen, die Portionen repräsentieren. Ein `IParagraph`‑Objekt kann eine oder mehrere Portionen enthalten (Sammlung von iPortions‑Objekten).
* Aspose.Slides stellt die [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) Schnittstelle bereit, um Objekte hinzuzufügen, die Texte und deren Formatierungseigenschaften repräsentieren.

Ein `IParagraph`‑Objekt kann Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `IPortion`‑Objekte verarbeiten.

## **Mehrere Absätze mit mehreren Portionen hinzufügen**

Diese Schritte zeigen, wie Sie einen Textrahmen mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Portionen enthält:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie der Folie ein Rechteck‑[IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) hinzu.
4. Rufen Sie das mit dem [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) verknüpfte `ITextFrame` ab.
5. Erstellen Sie zwei [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/)‑Objekte und fügen Sie sie der `IParagraphs`‑Sammlung des [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) hinzu.
6. Erstellen Sie für jedes neue `IParagraph` drei [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/)‑Objekte (zwei Portion‑Objekte für den Standardabsatz) und fügen Sie jedes `IPortion`‑Objekt der IPortion‑Sammlung jedes `IParagraph` hinzu.
7. Legen Sie für jede Portion etwas Text fest.
8. Wenden Sie die gewünschten Formatierungsoptionen auf jede Portion an, indem Sie die vom `IPortion`‑Objekt bereitgestellten Formatierungseigenschaften nutzen.
9. Speichern Sie die geänderte Präsentation.

```php
# Instanziieren einer Presentation-Klasse, die eine PPTX-Datei repräsentiert
$pres = new Presentation();
try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Hinzufügen einer AutoShape vom Typ Rechteck
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Zugriff auf TextFrame der AutoShape
    $tf = $ashp->getTextFrame();
    # Erstellen von Absätzen und Portionen mit verschiedenen Textformaten
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
    # Schreiben der PPTX auf die Festplatte
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Absatzaufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Aufgezählte Absätze sind stets leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie dem ausgewählten Folie ein [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) des autoshape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Setzen Sie den Aufzählungs‑`Type` des Absatzes auf `Symbol` und legen Sie das Aufzählungszeichen fest.
8. Legen Sie den Absatz‑`Text` fest.
9. Setzen Sie die Absatz‑`Indent` für die Aufzählung.
10. Legen Sie eine Farbe für die Aufzählung fest.
11. Setzen Sie die Höhe der Aufzählung.
12. Fügen Sie den neuen Absatz zur Absatzsammlung des `TextFrame` hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang aus den Schritten 7 bis 13.
14. Speichern Sie die Präsentation.

```php
# Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
$pres = new Presentation();
try {
    # Greift auf die erste Folie zu
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt eine AutoShape hinzu und greift darauf zu
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den TextFrame der AutoShape zu
    $txtFrm = $aShp->getTextFrame();
    # Entfernt den Standardabsatz
    $txtFrm->getParagraphs()->removeAt(0);
    # Erstellt einen Absatz
    $para = new Paragraph();
    # Setzt den Aufzählungsstil und das Symbol für den Absatz
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Setzt den Absatztext
    $para->setText("Welcome to Aspose.Slides");
    # Setzt den Einzug des Aufzählungszeichens
    $para->getParagraphFormat()->setIndent(25);
    # Setzt die Farbe des Aufzählungszeichens
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// setzt IsBulletHardColor auf true, um die eigene Aufzählungsfarbe zu verwenden
    # Setzt die Höhe des Aufzählungszeichens
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Fügt den Absatz dem TextFrame hinzu
    $txtFrm->getParagraphs()->add($para);
    # Erstellt einen zweiten Absatz
    $para2 = new Paragraph();
    # Setzt den Aufzählungstyp und -stil für den Absatz
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Fügt dem Absatz Text hinzu
    $para2->setText("This is numbered bullet");
    # Setzt den Einzug des Aufzählungszeichens
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// setzt IsBulletHardColor auf true, um die eigene Aufzählungsfarbe zu verwenden
    # Setzt die Höhe des Aufzählungszeichens
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Fügt den Absatz dem TextFrame hinzu
    $txtFrm->getParagraphs()->add($para2);
    # Speichert die geänderte Präsentation
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Bildaufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Bildabsätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie dem Folie ein [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) des autoshape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Laden Sie das Bild in [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/).
8. Setzen Sie den Aufzählungstyp auf [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/) und legen Sie das Bild fest.
9. Legen Sie den Absatz‑`Text` fest.
10. Setzen Sie die Absatz‑`Indent` für die Aufzählung.
11. Legen Sie eine Farbe für die Aufzählung fest.
12. Setzen Sie die Höhe der Aufzählung.
13. Fügen Sie den neuen Absatz zur Absatzsammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang anhand der vorherigen Schritte.
15. Speichern Sie die geänderte Präsentation.

```php
# Instanziiert eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
$presentation = new Presentation();
try {
    # Greift auf die erste Folie zu
    $slide = $presentation->getSlides()->get_Item(0);
    # Instanziiert das Bild für Aufzählungszeichen
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }
    # Fügt eine AutoShape hinzu und greift darauf zu
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den TextFrame der AutoShape zu
    $textFrame = $autoShape->getTextFrame();
    # Entfernt den Standardabsatz
    $textFrame->getParagraphs()->removeAt(0);
    # Erstellt einen neuen Absatz
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Setzt den Aufzählungsstil und das Bild für den Absatz
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Setzt die Höhe des Aufzählungszeichens
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Fügt den Absatz dem TextFrame hinzu
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


## **Mehrstufige Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und darzustellen. Mehrstufige Aufzählungen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie dem neuen Folie ein [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) des autoshape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz über die Klasse [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatzinstanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatzinstanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatzinstanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze zur Absatzsammlung des `TextFrame` hinzu.
11. Speichern Sie die geänderte Präsentation.

```php
# Instanziiert eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
$pres = new Presentation();
try {
    # Greift auf die erste Folie zu
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt eine AutoShape hinzu und greift darauf zu
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den TextFrame der erstellten AutoShape zu
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
    # Setzt die Aufzählungsebene
    $para1->getParagraphFormat()->setDepth(0);
    # Fügt den zweiten Absatz hinzu
    $para2 = new Paragraph();
    $para2->setText("Second Level");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Setzt die Aufzählungsebene
    $para2->getParagraphFormat()->setDepth(1);
    # Fügt den dritten Absatz hinzu
    $para3 = new Paragraph();
    $para3->setText("Third Level");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Setzt die Aufzählungsebene
    $para3->getParagraphFormat()->setDepth(2);
    # Fügt den vierten Absatz hinzu
    $para4 = new Paragraph();
    $para4->setText("Fourth Level");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Setzt die Aufzählungsebene
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

Die [IBulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/) Schnittstelle stellt die [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) Eigenschaft und weitere bereit, die es ermöglichen, Absätze mit benutzerdefinierter Nummerierung oder Formatierung zu verwalten.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie dem Folie ein [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) des autoshape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) auf 2.
7. Erstellen Sie die zweite Absatzinstanz über die Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatzinstanz über die Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze zur Absatzsammlung des `TextFrame` hinzu.
10. Speichern Sie die geänderte Präsentation.

```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den TextFrame der erstellten AutoShape zu
    $textFrame = $shape->getTextFrame();
    # Entfernt den standardmäßig vorhandenen Absatz
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


## **Absatzeinzug festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
1. Fügen Sie dem Rechteck‑autoshape ein [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) hinzu.
1. Fügen Sie dem Rechteck‑autoshape ein [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) mit drei Absätzen hinzu.
1. Blenden Sie die Rechtecklinien aus.
1. Setzen Sie den Einzug für jeden [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) über dessen BulletOffset‑Eigenschaft.
1. Schreiben Sie die geänderte Präsentation als PPT‑Datei.

```php
# Instanziert Presentation-Klasse
$pres = new Presentation();
try {
    # Ruft die erste Folie ab
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt ein Rechteck-Shape hinzu
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # Fügt dem Rechteck ein TextFrame hinzu
    $tf = $rect->addTextFrame("This is first line \rThis is second line \rThis is third line");
    # Setzt den Text passend zur Form
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Versteckt die Linien des Rechtecks
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # Holt den ersten Absatz im TextFrame und setzt dessen Einzug
    $para1 = $tf->getParagraphs()->get_Item(0);
    # Setzt den Aufzählungsstil und das Symbol des Absatzes
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para1->getParagraphFormat()->setDepth(2);
    $para1->getParagraphFormat()->setIndent(30);
    # Holt den zweiten Absatz im TextFrame und setzt dessen Einzug
    $para2 = $tf->getParagraphs()->get_Item(1);
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar(8226);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para2->getParagraphFormat()->setDepth(2);
    $para2->getParagraphFormat()->setIndent(40);
    # Holt den dritten Absatz im TextFrame und setzt dessen Einzug
    $para3 = $tf->getParagraphs()->get_Item(2);
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para3->getParagraphFormat()->setDepth(2);
    $para3->getParagraphFormat()->setIndent(50);
    # Schreibt die Präsentation auf die Festplatte
    $pres->save("InOutDent_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Hängenden Einzug für einen Absatz festlegen**

Dieser PHP‑Code zeigt, wie Sie den hängenden Einzug für einen Absatz festlegen:
```php
$pres = new Presentation();
try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 550, 150);
    $para1 = new Paragraph();
    $para1->setText("Example");
    $para2 = new Paragraph();
    $para2->setText("Set Hanging Indent for Paragraph");
    $para3 = new Paragraph();
    $para3->setText("This code shows you how to set the hanging indent for a paragraph: ");
    $para2->getParagraphFormat()->setMarginLeft(10.0);
    $para3->getParagraphFormat()->setMarginLeft(20.0);
    $autoShape->getTextFrame()->getParagraphs()->add($para1);
    $autoShape->getTextFrame()->getParagraphs()->add($para2);
    $autoShape->getTextFrame()->getParagraphs()->add($para3);
    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **End‑Absatz‑Lauf‑Eigenschaften verwalten**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Holen Sie die Referenz für die Folie, die den Absatz enthält, über deren Position.
1. Fügen Sie dem Folie ein Rechteck‑[autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) hinzu.
1. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) mit zwei Absätzen hinzu.
1. Setzen Sie die `FontHeight` und den Schriftarttyp für die Absätze.
1. Setzen Sie die End‑Eigenschaften für die Absätze.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

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

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Fügen Sie dem Folie ein [autoshape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) hinzu.
4. Fügen Sie dem `autoshape` ein [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standardabsatz im `ITextFrame`.
6. Lesen Sie die Quell‑HTML‑Datei mit einem TextReader.
7. Erstellen Sie die erste Absatzinstanz über die Klasse [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
8. Fügen Sie den HTML‑Dateiinhalt aus dem gelesenen TextReader zur [ParagraphCollection](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/) des TextFrames hinzu.
9. Speichern Sie die geänderte Präsentation.

```php
# Leere Präsentationsinstanz erstellen
$pres = new Presentation();
try {
    # Zugriff auf die standardmäßige erste Folie der Präsentation
    $slide = $pres->getSlides()->get_Item(0);
    # AutoShape hinzufügen, um den HTML-Inhalt aufzunehmen
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Textframe zur Form hinzufügen
    $ashape->addTextFrame("");
    # Alle Absätze im hinzugefügten Textframe löschen
    $ashape->getTextFrame()->getParagraphs()->clear();
    # HTML-Datei mit StreamReader laden
    $tr = new StreamReader("file.html");
    # Text aus dem HTML-StreamReader in den Textframe einfügen
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

Aspose.Slides bietet erweiterte Unterstützung für das Exportieren von Texten (in Absätzen enthalten) nach HTML.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf die Referenz der entsprechenden Folie zu.
3. Greifen Sie auf die Form zu, die den Text enthält, der nach HTML exportiert werden soll.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) der Form zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML‑Datei hinzu.
6. Geben Sie dem `StreamWriter` einen Start‑Index und exportieren Sie die gewünschten Absätze.

```php
# Lade die Präsentationsdatei
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Zugriff auf die standardmäßige erste Folie der Präsentation
    $slide = $pres->getSlides()->get_Item(0);
    # Gewünschter Index
    $index = 0;
    # Zugriff auf das hinzugefügte Shape
    $ashape = $slide->getShapes()->get_Item($index);
    # Erstelle die HTML-Ausgabedatei
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Extrahiere den ersten Absatz als HTML
    # Schreibe Paragraphendaten nach HTML, indem der Startindex des Paragraphen und die Gesamtzahl zu kopierenden Paragraphen angegeben wird
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

In diesem Abschnitt untersuchen wir zwei Beispiele, die zeigen, wie ein Textabsatz, dargestellt durch die [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)‑Klasse, als Bild gespeichert wird. Beide Beispiele umfassen das Abrufen des Bildes einer Form, die den Absatz enthält, über die `getImage`‑Methoden der [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/)-Klasse, das Berechnen der Begrenzungsrechtecke des Absatzes innerhalb der Form und das Exportieren als Bitmap‑Bild. Diese Ansätze ermöglichen das Extrahieren bestimmter Textteile aus PowerPoint‑Präsentationen und das Speichern als separate Bilder, was in verschiedenen Szenarien nützlich sein kann.

Nehmen wir an, wir haben eine Präsentationsdatei namens sample.pptx mit einer Folie, wobei die erste Form ein Textfeld mit drei Absätzen ist.

![Das Textfeld mit drei Absätzen](paragraph_to_image_input.png)

**Beispiel 1**

In diesem Beispiel erhalten wir den zweiten Absatz als Bild. Dazu extrahieren wir das Bild der Form aus der ersten Folie der Präsentation und berechnen anschließend die Begrenzungsrechtecke des zweiten Absatzes im TextFrame der Form. Der Absatz wird dann auf ein neues Bitmap‑Bild gezeichnet, das im PNG‑Format gespeichert wird. Diese Methode ist besonders nützlich, wenn ein bestimmter Absatz als separates Bild gespeichert werden soll, wobei die genauen Abmessungen und die Formatierung des Textes erhalten bleiben.
```php
$imageIO = new Java("javax.imageio.ImageIO");

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Speichere das Shape im Speicher als Bitmap.
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

    // Berechne die Koordinaten und die Größe für das Ausgabebild (Mindestgröße - 1x1 Pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Beschneide das Shape-Bitmap, um nur das Absatz-Bitmap zu erhalten.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


Das Ergebnis:

![Das Absatzbild](paragraph_to_image_output.png)

**Beispiel 2**

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir Skalierungsfaktoren zum Absatzbild hinzufügen. Die Form wird aus der Präsentation extrahiert und mit einem Skalierungsfaktor von `2` als Bild gespeichert. Dadurch wird bei der Exportierung des Absatzes eine höhere Auflösung erzielt. Die Absatzgrenzen werden anschließend unter Berücksichtigung des Skalierungsfaktors berechnet. Skalierung kann besonders nützlich sein, wenn ein detaillierteres Bild benötigt wird, etwa für hochwertige Druckmaterialien.
```php
$imageIO = new Java("javax.imageio.ImageIO");

$imageScaleX = 2;
$imageScaleY = $imageScaleX;

$presentation = new Presentation("sample.pptx");
try {
    $firstShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Speichere das Shape im Speicher als Bitmap mit Skalierung.
    $shapeImage = $firstShape->getImage(ShapeThumbnailBounds::Shape, $imageScaleX, $imageScaleY);
    $shapeImageStream = new Java("java.io.ByteArrayOutputStream");
    $shapeImage->save($shapeImageStream, ImageFormat::Png);
    $shapeImage->dispose();

    // Erstelle ein Shape-Bitmap aus dem Speicher.
    $shapeImageInputStream = new Java("java.io.ByteArrayInputStream", $shapeImageStream->toByteArray());
    $shapeBitmap = $imageIO->read($shapeImageInputStream);

    // Berechne die Grenzen des zweiten Absatzes.
    $secondParagraph = $firstShape->getTextFrame()->getParagraphs()->get_Item(1);
    $paragraphRectangle = $secondParagraph->getRect();
    $paragraphRectangle->setRect(
            java_values($paragraphRectangle->getX()) * $imageScaleX,
            java_values($paragraphRectangle->getY()) * $imageScaleY,
            java_values($paragraphRectangle->getWidth()) * $imageScaleX,
            java_values($paragraphRectangle->getHeight()) * $imageScaleY
    );

    // Berechne die Koordinaten und die Größe für das Ausgabebild (Mindestgröße - 1x1 Pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Beschneide das Shape-Bitmap, um nur das Absatz-Bitmap zu erhalten.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


## **FAQ**

**Kann ich das Zeilenumbruch im Textrahmen komplett deaktivieren?**

Ja. Verwenden Sie die Umbruch‑Einstellung des TextFrames ([setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/)), um den Umbruch auszuschalten, sodass Zeilen nicht am Rand des Rahmens umbrechen.

**Wie kann ich die genauen Begrenzungsrechtecke eines bestimmten Absatzes auf der Folie erhalten?**

Sie können das Begrenzungsrechteck des Absatzes (und sogar eines einzelnen Portions) abrufen, um seine genaue Position und Größe auf der Folie zu kennen.

**Wo wird die Absatz‑Ausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[Alignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) ist eine Absatz‑Einstellung in [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/); sie gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

**Kann ich eine Rechtschreib‑Sprache nur für einen Teil eines Absatzes (z. B. ein Wort) festlegen?**

Ja. Die Sprache wird auf Portionsebene festgelegt ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId)), sodass mehrere Sprachen innerhalb eines Absatzes coexistieren können.