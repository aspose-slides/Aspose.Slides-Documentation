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
description: "Meistern Sie die Absatzformatierung mit Aspose.Slides für PHP über Java — Optimieren Sie Ausrichtung, Abstand und Stil in PPT-, PPTX- und ODP-Präsentationen."
---

Aspose.Slides stellt alle Klassen zur Verfügung, die Sie benötigen, um mit PowerPoint‑Texten, Absätzen und Portionen zu arbeiten.

* Aspose.Slides stellt die Klasse [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) bereit, mit der Sie Objekte hinzufügen können, die einen Absatz darstellen. Ein `TextFame`‑Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erstellt).
* Aspose.Slides stellt die Klasse [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) bereit, mit der Sie Objekte hinzufügen können, die Portionen darstellen. Ein `Paragraph`‑Objekt kann eine oder mehrere Portionen enthalten (eine Sammlung von Portion‑Objekten).
* Aspose.Slides stellt die Klasse [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) bereit, mit der Sie Objekte hinzufügen können, die Texte und deren Formatierungseigenschaften darstellen.

Ein `Paragraph`‑Objekt ist in der Lage, Texte mit unterschiedlichen Formatierungseigenschaften über die zugrunde liegenden `Portion`‑Objekte zu verarbeiten.

## **Mehrere Absätze hinzufügen, die mehrere Portionen enthalten**

Diese Schritte zeigen, wie Sie einen Text‑Frame mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Portionen enthält:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der gewünschten Folie zu.
3. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
4. Holen Sie das `ITextFrame`, das mit dem [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) verknüpft ist.
5. Erstellen Sie zwei [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/)‑Objekte und fügen Sie sie der Absatz‑Sammlung des [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) hinzu.
6. Erstellen Sie für jedes neue `Paragraph` drei [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/portion/)‑Objekte (zwei Portion‑Objekte für einen Standard‑Paragraph) und fügen Sie jedes `Portion`‑Objekt der Portion‑Sammlung des jeweiligen `Paragraph` hinzu.
7. Setzen Sie für jede Portion einen Text.
8. Wenden Sie die gewünschten Formatierungsoptionen auf jede Portion über die vom `Portion`‑Objekt bereitgestellten Formatierungseigenschaften an.
9. Speichern Sie die geänderte Präsentation.

Dieser PHP‑Code implementiert die Schritte zum Hinzufügen von Absätzen mit Portionen:
```php
# Instanziieren Sie eine Presentation-Klasse, die eine PPTX-Datei darstellt
$pres = new Presentation();
try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Ein AutoShape vom Typ Rechteck hinzufügen
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Zugriff auf das TextFrame des AutoShape
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
    # PPTX auf Festplatte schreiben
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Absatz‑Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu strukturieren und zu präsentieren. Aufzählungs‑Absätze sind stets leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der gewünschten Folie zu.
3. Fügen Sie der ausgewählten Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Setzen Sie den Aufzählungs‑`Type` des Absatzes auf `Symbol` und definieren Sie das Aufzählungszeichen.
8. Setzen Sie den Absatz‑`Text`.
9. Setzen Sie den Absatz‑`Indent` für die Aufzählung.
10. Legen Sie eine Farbe für das Aufzählungszeichen fest.
11. Bestimmen Sie die Höhe des Aufzählungszeichens.
12. Fügen Sie den neuen Absatz zur Absatz‑Sammlung des `TextFrame` hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie die Schritte 7 bis 13.
14. Speichern Sie die Präsentation.

Dieser PHP‑Code zeigt, wie Sie eine Absatz‑Aufzählung hinzufügen:
```php
# Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
$pres = new Presentation();
try {
    # Greift auf die erste Folie zu
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt ein AutoShape hinzu und greift darauf zu
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den TextFrame des AutoShape zu
    $txtFrm = $aShp->getTextFrame();
    # Entfernt den Standardabsatz
    $txtFrm->getParagraphs()->removeAt(0);
    # Erstellt einen Absatz
    $para = new Paragraph();
    # Legt einen Absatz-Aufzählungsstil und Symbol fest
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Legt den Absatztext fest
    $para->setText("Welcome to Aspose.Slides");
    # Legt den Aufzählungs-Einzug fest
    $para->getParagraphFormat()->setIndent(25);
    # Legt die Aufzählungsfarbe fest
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// setzt IsBulletHardColor auf true, um eine eigene Aufzählungsfarbe zu verwenden

    # Legt die Aufzählungshöhe fest
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Fügt den Absatz dem TextFrame hinzu
    $txtFrm->getParagraphs()->add($para);
    # Erstellt den zweiten Absatz
    $para2 = new Paragraph();
    # Legt den Aufzählungstyp und -stil des Absatzes fest
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Fügt den Absatztext hinzu
    $para2->setText("This is numbered bullet");
    # Legt den Aufzählungs-Einzug fest
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// setzt IsBulletHardColor auf true, um eine eigene Aufzählungsfarbe zu verwenden

    # Legt die Aufzählungshöhe fest
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


## **Bild‑Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu strukturieren und zu präsentieren. Bild‑Absätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der gewünschten Folie zu.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz mit der Klasse [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
7. Laden Sie das Bild in [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/).
8. Setzen Sie den Aufzählungs‑Typ auf [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/bullettype/#Picture) und legen Sie das Bild fest.
9. Setzen Sie den Absatz‑`Text`.
10. Setzen Sie den Absatz‑`Indent` für die Aufzählung.
11. Legen Sie eine Farbe für das Aufzählungszeichen fest.
12. Bestimmen Sie die Höhe des Aufzählungszeichens.
13. Fügen Sie den neuen Absatz zur Absatz‑Sammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Vorgang anhand der vorherigen Schritte.
15. Speichern Sie die geänderte Präsentation.

Dieser PHP‑Code zeigt, wie Sie Bild‑Aufzählungen hinzufügen und verwalten:
```php
# Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
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
    # Fügt ein AutoShape hinzu und greift darauf zu
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den Textframe des AutoShape zu
    $textFrame = $autoShape->getTextFrame();
    # Entfernt den Standardabsatz
    $textFrame->getParagraphs()->removeAt(0);
    # Erstellt einen neuen Absatz
    $paragraph = new Paragraph();
    $paragraph->setText("Welcome to Aspose.Slides");
    # Legt den Aufzählungsstil und das Bild des Absatzes fest
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Legt die Aufzählungshöhe fest
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Fügt den Absatz dem Textframe hinzu
    $textFrame->getParagraphs()->add($paragraph);
    # Schreibt die Präsentation als PPTX-Datei
    $presentation->save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);
    # Schreibt die Präsentation als PPT-Datei
    $presentation->save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
} catch (JavaException $e) {
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


## **Mehrstufige Aufzählungen verwalten**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu strukturieren und zu präsentieren. Mehrstufige Aufzählungen sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie über den Index auf die Referenz der gewünschten Folie zu.
3. Fügen Sie in der neuen Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze zur Absatz‑Sammlung des `TextFrame` hinzu.
11. Speichern Sie die geänderte Präsentation.

Dieser PHP‑Code zeigt, wie Sie mehrstufige Aufzählungen hinzufügen und verwalten:
```php
# Instanziert eine Presentation-Klasse, die eine PPTX-Datei darstellt
$pres = new Presentation();
try {
    # Greift auf die erste Folie zu
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt ein AutoShape hinzu und greift darauf zu
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den Textrahmen des erstellten AutoShapes zu
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
    # Schreibt die Präsentation als PPTX-Datei
    $pres->save("MultilevelBullet.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Absatz mit benutzerdefinierter nummerierter Liste verwalten**

Die Klasse [BulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/) stellt die Methode [setNumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) und weitere zur Verfügung, mit denen Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung verwalten können.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) zur Folie hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) des AutoShape zu.
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Erstellen Sie die erste Absatz‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) auf 2.
7. Erstellen Sie die zweite Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatz‑Instanz über die Klasse `Paragraph` und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze zur Absatz‑Sammlung des `TextFrame` hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieser PHP‑Code zeigt, wie Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung hinzufügen und verwalten:
```php
$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den Textframe des erstellten AutoShapes zu
    $textFrame = $shape->getTextFrame();
    # Entfernt den standardmäßigen vorhandenen Absatz
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
1. Greifen Sie über den Index auf die Referenz der gewünschten Folie zu.
1. Fügen Sie einem rechteckigen [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) der Folie hinzu.
1. Fügen Sie dem rechteckigen AutoShape ein [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) mit drei Absätzen hinzu.
1. Blenden Sie die Rechtecklinien aus.
1. Setzen Sie den Einzug für jedes [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) über dessen `BulletOffset`‑Eigenschaft.
1. Schreiben Sie die geänderte Präsentation als PPT‑Datei.

Dieser PHP‑Code zeigt, wie Sie einen Absatzeinzug festlegen:
```php
# Instanziiert die Presentation-Klasse
$pres = new Presentation();
try {
    # Greift auf die erste Folie zu
    $sld = $pres->getSlides()->get_Item(0);
    # Fügt ein Rechteck-Shape hinzu
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # Fügt dem Rechteck einen TextFrame hinzu
    $tf = $rect->addTextFrame("This is first line \rThis is second line \rThis is third line");
    # Setzt den Text passend zur Form
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Versteckt die Linien des Rechtecks
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # Holt den ersten Absatz im TextFrame und setzt dessen Einzug
    $para1 = $tf->getParagraphs()->get_Item(0);
    # Setzt den Absatz-Aufzählungsstil und das Symbol
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


## **End‑Absatz‑Run‑Eigenschaften verwalten**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Holen Sie die Referenz der Folie, die den Absatz enthält, über deren Position.
1. Fügen Sie der Folie ein rechteckiges [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
1. Fügen Sie dem Rechteck ein [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) mit zwei Absätzen hinzu.
1. Setzen Sie die Schriftgröße und den Schriftsatz für die Absätze.
1. Setzen Sie die End‑Eigenschaften für die Absätze.
1. Schreiben Sie die geänderte Präsentation als PPTX‑Datei.

Dieser PHP‑Code zeigt, wie Sie die End‑Eigenschaften für Absätze in PowerPoint festlegen:
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
2. Greifen Sie über den Index auf die Referenz der gewünschten Folie zu.
3. Fügen Sie der Folie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) hinzu.
4. Fügen Sie das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) des AutoShape hinzu und greifen Sie darauf zu.
5. Entfernen Sie den Standard‑Absatz im `TextFrame`.
6. Lesen Sie die Quell‑HTML‑Datei mit einem `TextReader`.
7. Erstellen Sie die erste Absatz‑Instanz über die Klasse [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/).
8. Fügen Sie den HTML‑Dateiinhalt aus dem gelesenen `TextReader` zur [ParagraphCollection](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphcollection/) des TextFrames hinzu.
9. Speichern Sie die geänderte Präsentation.

Dieser PHP‑Code implementiert die Schritte zum Importieren von HTML‑Texten in Absätze:
```php
# Leere Präsentationsinstanz erstellen
$pres = new Presentation();
try {
    # Greift auf die standardmäßige erste Folie der Präsentation zu
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt das AutoShape hinzu, um den HTML-Inhalt aufzunehmen
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Fügt dem Shape ein Textfeld hinzu
    $ashape->addTextFrame("");
    # Löscht alle Absätze im hinzugefügten Textfeld
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Lädt die HTML-Datei mit einem StreamReader
    $tr = new StreamReader("file.html");
    # Fügt Text aus dem HTML-StreamReader in das Textfeld ein
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Speichert die Präsentation
    $pres->save("output_out.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Absatz‑Text nach HTML exportieren**

Aspose.Slides bietet erweiterte Unterstützung für das Exportieren von Texten (die in Absätzen enthalten sind) nach HTML.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) und laden Sie die gewünschte Präsentation.
2. Greifen Sie über den Index auf die Referenz der gewünschten Folie zu.
3. Greifen Sie auf die Form zu, die den zu exportierenden Text enthält.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) der Form zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML‑Datei hinzu.
6. Geben Sie einen Start‑Index an den `StreamWriter` weiter und exportieren Sie die gewünschten Absätze.

Dieser PHP‑Code zeigt, wie Sie PowerPoint‑Absatz‑Texte nach HTML exportieren:
```php
# Präsentationsdatei laden
$pres = new Presentation("ExportingHTMLText.pptx");
try {
    # Greift auf die standardmäßige erste Folie der Präsentation zu
    $slide = $pres->getSlides()->get_Item(0);
    # Gewünschter Index
    $index = 0;
    # Greift auf das hinzugefügte Shape zu
    $ashape = $slide->getShapes()->get_Item($index);
    # Ausgabedatei HTML erstellen
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Extrahiert den ersten Absatz als HTML
    # Schreiben von Absatzdaten nach HTML durch Angabe des Startindexes und der zu kopierenden Absatzanzahl
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
} catch (JavaException $e) {
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **Absatz als Bild speichern**

In diesem Abschnitt zeigen wir zwei Beispiele, die demonstrieren, wie ein Text‑Absatz, repräsentiert durch die Klasse [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/), als Bild gespeichert werden kann. Beide Beispiele umfassen das Abrufen des Bildes einer Form, die den Absatz enthält, mittels der `getImage`‑Methoden der Klasse [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/), das Berechnen der Grenzen des Absatzes innerhalb der Form und das Exportieren als Bitmap‑Bild. Diese Ansätze ermöglichen das Extrahieren spezifischer Textteile aus PowerPoint‑Präsentationen und das Speichern als separate Bilder, was in verschiedenen Szenarien nützlich sein kann.

Nehmen wir an, wir haben eine Präsentationsdatei namens **sample.pptx** mit einer Folie, wobei die erste Form ein Textfeld mit drei Absätzen ist.

![Das Textfeld mit drei Absätzen](paragraph_to_image_input.png)

**Beispiel 1**

In diesem Beispiel holen wir den zweiten Absatz als Bild. Dazu extrahieren wir das Bild der Form von der ersten Folie der Präsentation und berechnen anschließend die Grenzen des zweiten Absatzes im Text‑Frame der Form. Der Absatz wird dann auf ein neues Bitmap‑Bild gezeichnet und im PNG‑Format gespeichert. Diese Methode ist besonders nützlich, wenn ein bestimmter Absatz als separates Bild gespeichert werden soll, während die exakten Abmessungen und Formatierungen des Textes erhalten bleiben.
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

    // Berechne die Koordinaten und Größe für das Ausgabebild (Mindestgröße - 1x1 Pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Schneide das Shape-Bitmap zu, um nur das Absatz-Bitmap zu erhalten.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


Das Ergebnis:

![Das Absatz‑Bild](paragraph_to_image_output.png)

**Beispiel 2**

In diesem Beispiel erweitern wir den vorherigen Ansatz, indem wir Skalierungsfaktoren zum Absatz‑Bild hinzufügen. Die Form wird aus der Präsentation extrahiert und mit einem Skalierungsfaktor von `2` als Bild gespeichert. Dadurch entsteht ein Bild mit höherer Auflösung beim Exportieren des Absatzes. Die Absatz‑Grenzen werden anschließend unter Berücksichtigung des Skalierungsfaktors berechnet. Skalierung kann besonders dann hilfreich sein, wenn ein detaillierteres Bild benötigt wird, beispielsweise für den Einsatz in hochwertigen Druckmaterialien.
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

    // Berechne die Koordinaten und Größe für das Ausgabebild (Mindestgröße - 1x1 Pixel).
    $imageX = floor(java_values($paragraphRectangle->getX()));
    $imageY = floor(java_values($paragraphRectangle->getY()));
    $imageWidth = max(1, ceil(java_values($paragraphRectangle->getWidth())));
    $imageHeight = max(1, ceil(java_values($paragraphRectangle->getHeight())));

    // Schneide das Shape-Bitmap zu, um nur das Absatz-Bitmap zu erhalten.
    $paragraphBitmap = $shapeBitmap->getSubimage($imageX, $imageY, $imageWidth, $imageHeight);

    $imageIO->write($paragraphBitmap, "png", new Java("java.io.File", "paragraph.png"));
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```


## **FAQ**

**Kann ich das Zeilen‑Umbruchverhalten innerhalb eines Text‑Frames vollständig deaktivieren?**

Ja. Verwenden Sie die Umbruch‑Einstellung des Text‑Frames ([setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/setwraptext/)), um den Umbruch auszuschalten, sodass Zeilen nicht an den Rändern des Frames umbrechen.

**Wie kann ich die genauen On‑Slide‑Grenzen eines bestimmten Absatzes ermitteln?**

Sie können das Begrenzungsrechteck des Absatzes (und sogar eines einzelnen Portion) abrufen, um dessen genaue Position und Größe auf der Folie zu kennen.

**Wo wird die Absatz‑Ausrichtung (links/rechts/zentriert/Blocksatz) gesteuert?**

[Alignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) ist eine Absatz‑Ebene‑Einstellung in [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/); sie gilt für den gesamten Absatz, unabhängig von der Formatierung einzelner Portionen.

**Kann ich eine Rechtschreib‑Sprache nur für einen Teil eines Absatzes (z. B. ein Wort) festlegen?**

Ja. Die Sprache wird auf Portion‑Ebene festgelegt ([PortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId)), sodass mehrere Sprachen innerhalb eines einzelnen Absatzes koexistieren können.