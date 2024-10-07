---
title: Verwaltete PowerPoint-Absätze
type: docs
weight: 40
url: /php-java/manage-paragraph/
keywords: "Fügen Sie PowerPoint-Absatz hinzu, Verwalten Sie Absätze, Absatz Rückenmaß, Absatz Eigenschaften, HTML-Text, Absatztext exportieren, PowerPoint-Präsentation, Java, Aspose.Slides für PHP über Java"
description: "Erstellen und Verwalten von Absätzen, Text, Rückenmaß und Eigenschaften in PowerPoint-Präsentationen"
---

Aspose.Slides bietet alle Schnittstellen und Klassen, die Sie benötigen, um mit PowerPoint-Texten, Absätzen und Portionen zu arbeiten.

* Aspose.Slides bietet die [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) Schnittstelle, um Ihnen das Hinzufügen von Objekten zu ermöglichen, die einen Absatz darstellen. Ein `ITextFrame`-Objekt kann einen oder mehrere Absätze enthalten (jeder Absatz wird durch einen Zeilenumbruch erstellt).
* Aspose.Slides bietet die [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) Schnittstelle, um Ihnen das Hinzufügen von Objekten zu ermöglichen, die Portionen darstellen. Ein `IParagraph`-Objekt kann eine oder mehrere Portionen enthalten (Sammlung von iPortions-Objekten).
* Aspose.Slides bietet die [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) Schnittstelle, um Ihnen das Hinzufügen von Objekten zu ermöglichen, die Texte und deren Formatierungseigenschaften darstellen.

Ein `IParagraph`-Objekt ist in der Lage, Texte mit unterschiedlichen Formatierungseigenschaften über seine zugrunde liegenden `IPortion`-Objekte zu verwalten.

## **Fügen Sie mehrere Absätze mit mehreren Portionen hinzu**

Diese Schritte zeigen Ihnen, wie Sie ein Textfeld mit 3 Absätzen hinzufügen, wobei jeder Absatz 3 Portionen enthält:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie ein Rechteck [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) hinzu.
4. Holen Sie sich das mit der [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) verbundene ITextFrame.
5. Erstellen Sie zwei [IParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/iparagraph/) Objekte und fügen Sie sie der `IParagraphs`-Sammlung des [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) hinzu.
6. Erstellen Sie drei [IPortion](https://reference.aspose.com/slides/php-java/aspose.slides/iportion/) Objekte für jeden neuen `IParagraph` (zwei Portionenobjekte für den Standardabsatz) und fügen Sie jedes `IPortion`-Objekt der IPortion-Sammlung jedes `IParagraph` hinzu.
7. Setzen Sie für jede Portion einen Text.
8. Wenden Sie Ihre bevorzugten Formatierungsmerkmale auf jede Portion unter Verwendung der von dem `IPortion`-Objekt bereitgestellten Formatierungseigenschaften an.
9. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code ist eine Implementierung der Schritte zum Hinzufügen von Absätzen, die Portionen enthalten:

```php
  # Instanziieren Sie eine Präsentationsklasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine AutoShape vom Typ Rechteck hinzu
    $ashp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
    # Zugriff auf TextFrame der AutoShape
    $tf = $ashp->getTextFrame();
    # Erstellen Sie Absätze und Portionen mit unterschiedlichen Textformaten
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
    # Schreiben Sie PPTX auf die Festplatte
    $pres->save("multiParaPort_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Verwalten Sie Absatzpunkte**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Aufgezählte Absätze sind immer leichter zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf die entsprechende Folie zu.
3. Fügen Sie der ausgewählten Folie eine [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) der AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) Klasse.
7. Setzen Sie den Punkt `Type` für den Absatz auf `Symbol` und setzen Sie das Punktzeichen.
8. Setzen Sie den Absatz `Text`.
9. Setzen Sie den Absatz `Indent` für den Punkt.
10. Setzen Sie eine Farbe für den Punkt.
11. Setzen Sie eine Höhe für den Punkt.
12. Fügen Sie den neuen Absatz zur Absatzsammlung des `TextFrame` hinzu.
13. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Prozess in den Schritten 7 bis 13.
14. Speichern Sie die Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie einen Absatzpunkt hinzufügen:

```php
  # Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Zugriff auf die erste Folie
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt AutoShape hinzu und greift zu
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den TextFrame der AutoShape zu
    $txtFrm = $aShp->getTextFrame();
    # Entfernt den Standardabsatz
    $txtFrm->getParagraphs()->removeAt(0);
    # Erstellt einen Absatz
    $para = new Paragraph();
    # Setzt einen Absatzpunktstil und Symbol
    $para->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para->getParagraphFormat()->getBullet()->setChar(8226);
    # Setzt einen Absatztext
    $para->setText("Willkommen bei Aspose.Slides");
    # Setzt die Punkt Einrückung
    $para->getParagraphFormat()->setIndent(25);
    # Setzt die Punktfarbe
    $para->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// setze IsBulletHardColor auf true, um die eigene Punktfarbe zu verwenden

    # Setzt die Punkt Höhe
    $para->getParagraphFormat()->getBullet()->setHeight(100);
    # Fügt den Absatz zum Textfeld hinzu
    $txtFrm->getParagraphs()->add($para);
    # Erstellt den zweiten Absatz
    $para2 = new Paragraph();
    # Setzt den Absatzpunkttyp und -stil
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $para2->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle->BulletCircleNumWDBlackPlain);
    # Fügt Absatztext hinzu
    $para2->setText("Das ist ein nummerierter Punkt");
    # Setzt die Punkt Einrückung
    $para2->getParagraphFormat()->setIndent(25);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColorType(ColorType::RGB);
    $para2->getParagraphFormat()->getBullet()->getColor()->setColor(java("java.awt.Color")->BLACK);
    $para2->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);// setze IsBulletHardColor auf true, um die eigene Punktfarbe zu verwenden

    # Setzt die Punkt Höhe
    $para2->getParagraphFormat()->getBullet()->setHeight(100);
    # Fügt den Absatz zum Textfeld hinzu
    $txtFrm->getParagraphs()->add($para2);
    # Speichert die modifizierte Präsentation
    $pres->save("Bullet_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Verwalten Sie Bildpunkte**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Bildabsätze sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) der AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz mit der [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) Klasse.
7. Laden Sie das Bild in [IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/).
8. Setzen Sie den Punkt Typ auf [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/) und setzen Sie das Bild.
9. Setzen Sie den Absatz `Text`.
10. Setzen Sie die Absatz `Indent` für den Punkt.
11. Setzen Sie eine Farbe für den Punkt.
12. Setzen Sie eine Höhe für den Punkt.
13. Fügen Sie den neuen Absatz zur Absatzsammlung des `TextFrame` hinzu.
14. Fügen Sie den zweiten Absatz hinzu und wiederholen Sie den Prozess basierend auf den vorherigen Schritten.
15. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie Bildpunkte hinzufügen und verwalten:

```php
  # Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
  $presentation = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $slide = $presentation->getSlides()->get_Item(0);
    # Instanziiert das Bild für die Punkte
    $picture;
    $image = Images->fromFile("bullets.png");
    try {
      $picture = $presentation->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Fügt AutoShape hinzu und greift zu
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den TextFrame der AutoShape zu
    $textFrame = $autoShape->getTextFrame();
    # Entfernt den Standardabsatz
    $textFrame->getParagraphs()->removeAt(0);
    # Erstellt einen neuen Absatz
    $paragraph = new Paragraph();
    $paragraph->setText("Willkommen bei Aspose.Slides");
    # Legt den Absatzpunktstil und das Bild fest
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($picture);
    # Setzt die Punkt Höhe
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    # Fügt den Absatz zum Textfeld hinzu
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

## **Verwalten Sie mehrstufige Punkte**

Aufzählungslisten helfen Ihnen, Informationen schnell und effizient zu organisieren und zu präsentieren. Mehrstufige Punkte sind leicht zu lesen und zu verstehen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf die entsprechende Folie zu.
3. Fügen Sie ein [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) in der neuen Folie hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) der AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz über die [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) Klasse und setzen Sie die Tiefe auf 0.
7. Erstellen Sie die zweite Absatzinstanz über die `Paragraph` Klasse und setzen Sie die Tiefe auf 1.
8. Erstellen Sie die dritte Absatzinstanz über die `Paragraph` Klasse und setzen Sie die Tiefe auf 2.
9. Erstellen Sie die vierte Absatzinstanz über die `Paragraph` Klasse und setzen Sie die Tiefe auf 3.
10. Fügen Sie die neuen Absätze der Absatzsammlung des `TextFrame` hinzu.
11. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie mehrstufige Punkte hinzufügen und verwalten:

```php
  # Instanziiert eine Präsentationsklasse, die eine PPTX-Datei darstellt
  $pres = new Presentation();
  try {
    # Greift auf die erste Folie zu
    $slide = $pres->getSlides()->get_Item(0);
    # Fügt AutoShape hinzu und greift zu
    $aShp = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den Textframe der erstellten AutoShape zu
    $text = $aShp->addTextFrame("");
    # Löscht den Standardabsatz
    $text->getParagraphs()->clear();
    # Fügt den ersten Absatz hinzu
    $para1 = new Paragraph();
    $para1->setText("Inhalt");
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para1->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Setzt die Punktstufe
    $para1->getParagraphFormat()->setDepth(0);
    # Fügt den zweiten Absatz hinzu
    $para2 = new Paragraph();
    $para2->setText("Zweite Ebene");
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar('-');
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para2->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Setzt die Punktstufe
    $para2->getParagraphFormat()->setDepth(1);
    # Fügt den dritten Absatz hinzu
    $para3 = new Paragraph();
    $para3->setText("Dritte Ebene");
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para3->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Setzt die Punktstufe
    $para3->getParagraphFormat()->setDepth(2);
    # Fügt den vierten Absatz hinzu
    $para4 = new Paragraph();
    $para4->setText("Vierte Ebene");
    $para4->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para4->getParagraphFormat()->getBullet()->setChar('-');
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $para4->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Setzt die Punktstufe
    $para4->getParagraphFormat()->setDepth(3);
    # Fügt Absätze zur Sammlung hinzu
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

## **Verwalten Sie Absätze mit benutzerdefinierten nummerierten Listen**

Die [IBulletFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/) Schnittstelle bietet die Eigenschaft [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) und andere, mit denen Sie Absätze mit benutzerdefinierter Nummerierung oder Formatierung verwalten können.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
2. Greifen Sie auf die Folie zu, die den Absatz enthält.
3. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) hinzu.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) der AutoShape zu.
5. Entfernen Sie den Standardabsatz im `TextFrame`.
6. Erstellen Sie die erste Absatzinstanz über die [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) Klasse und setzen Sie [NumberedBulletStartWith](https://reference.aspose.com/slides/php-java/aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) auf 2.
7. Erstellen Sie die zweite Absatzinstanz über die `Paragraph` Klasse und setzen Sie `NumberedBulletStartWith` auf 3.
8. Erstellen Sie die dritte Absatzinstanz über die `Paragraph` Klasse und setzen Sie `NumberedBulletStartWith` auf 7.
9. Fügen Sie die neuen Absätze der Absatzsammlung des `TextFrame` hinzu.
10. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code zeigt Ihnen, wie Sie Absätze mit benutzerdefinierten Nummerierungen oder Formatierungen hinzufügen und verwalten:

```php
  $presentation = new Presentation();
  try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
    # Greift auf den TextFrame der erstellten AutoShape zu
    $textFrame = $shape->getTextFrame();
    # Entfernt den Standardabsatz
    $textFrame->getParagraphs()->removeAt(0);
    # Erste Liste
    $paragraph1 = new Paragraph();
    $paragraph1->setText("Punkt 2");
    $paragraph1->getParagraphFormat()->setDepth(4);
    $paragraph1->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(2);
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph1);
    $paragraph2 = new Paragraph();
    $paragraph2->setText("Punkt 3");
    $paragraph2->getParagraphFormat()->setDepth(4);
    $paragraph2->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(3);
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $textFrame->getParagraphs()->add($paragraph2);
    $paragraph5 = new Paragraph();
    $paragraph5->setText("Punkt 7");
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

## **Setzen Sie Absatz Einrückung**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
1. Greifen Sie über seinen Index auf die entsprechende Folie zu.
1. Fügen Sie der Folie eine Rechteck [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) hinzu.
1. Fügen Sie eine [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) mit drei Absätzen zur Rechteck-AutoShape hinzu.
1. Blenden Sie die Rechtecklinien aus.
1. Setzen Sie die Einrückung für jeden [Absatz](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) über deren BulletOffset-Eigenschaft.
1. Schreiben Sie die modifizierte Präsentation als PPT-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie eine Absatz Einrückung setzen:

```php
  # Instanziieren Sie die Präsentationsklasse
  $pres = new Presentation();
  try {
    # Holen Sie sich die erste Folie
    $sld = $pres->getSlides()->get_Item(0);
    # Fügen Sie eine Rechteckform hinzu
    $rect = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 150);
    # Fügen Sie TextFrame zur Rechteck hinzu
    $tf = $rect->addTextFrame("Dies ist die erste Zeile \rDies ist die zweite Zeile \rDies ist die dritte Zeile");
    # Setzen Sie den Text, um in die Form zu passen
    $tf->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);
    # Blenden Sie die Linien des Rechtecks aus
    $rect->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    # Holen Sie sich den ersten Absatz im TextFrame und setzen Sie dessen Einrückung
    $para1 = $tf->getParagraphs()->get_Item(0);
    # Setzen des Absatzpunktstils und Symbole
    $para1->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para1->getParagraphFormat()->getBullet()->setChar(8226);
    $para1->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para1->getParagraphFormat()->setDepth(2);
    $para1->getParagraphFormat()->setIndent(30);
    # Holen Sie sich den zweiten Absatz im TextFrame und setzen Sie dessen Einrückung
    $para2 = $tf->getParagraphs()->get_Item(1);
    $para2->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para2->getParagraphFormat()->getBullet()->setChar(8226);
    $para2->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para2->getParagraphFormat()->setDepth(2);
    $para2->getParagraphFormat()->setIndent(40);
    # Holen Sie sich den dritten Absatz im TextFrame und setzen Sie dessen Einrückung
    $para3 = $tf->getParagraphs()->get_Item(2);
    $para3->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $para3->getParagraphFormat()->getBullet()->setChar(8226);
    $para3->getParagraphFormat()->setAlignment(TextAlignment->Left);
    $para3->getParagraphFormat()->setDepth(2);
    $para3->getParagraphFormat()->setIndent(50);
    # Schreiben Sie die Präsentation auf die Festplatte
    $pres->save("InOutDent_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Setzen Sie hängende Einrückungen für Absätze**

Dieser PHP-Code zeigt Ihnen, wie Sie die hängende Einrückung für einen Absatz setzen:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 550, 150);
    $para1 = new Paragraph();
    $para1->setText("Beispiel");
    $para2 = new Paragraph();
    $para2->setText("Setzen Sie die hängende Einrückung für Absätze");
    $para3 = new Paragraph();
    $para3->setText("Dieser C#-Code zeigt Ihnen, wie Sie die hängende Einrückung für einen Absatz setzen:");
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

## **Verwalten Sie Endabsatzlauf-Eigenschaften für Absätze**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
1. Holen Sie sich das Referenz für die Folie, die den Absatz über seine Position enthält.
1. Fügen Sie der Folie eine Rechteck [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) hinzu.
1. Fügen Sie ein [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) mit zwei Absätzen zur Rechteck hinzu.
1. Setzen Sie die `FontHeight` und den Schriftarttyp für die Absätze.
1. Setzen Sie die End-Eigenschaften für die Absätze.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Dieser PHP-Code zeigt Ihnen, wie Sie die End-Eigenschaften für Absätze in PowerPoint setzen:

```php
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
    $para1 = new Paragraph();
    $para1->getPortions()->add(new Portion("Beispieltext"));
    $para2 = new Paragraph();
    $para2->getPortions()->add(new Portion("Beispieltext 2"));
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

## **Importieren Sie HTML-Text in Absätze**

Aspose.Slides bietet erweiterte Unterstützung für den Import von HTML-Text in Absätze.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse.
2. Greifen Sie über seinen Index auf die entsprechende Folie zu.
3. Fügen Sie der Folie eine [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/iautoshape/) hinzu.
4. Fügen Sie hinzu und greifen Sie auf [AutoShape] [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/itextframe/) zu.
5. Entfernen Sie den Standardabsatz im `ITextFrame`.
6. Lesen Sie die Quell-HTML-Datei in einem TextReader.
7. Erstellen Sie die erste Absatzinstanz über die [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) Klasse.
8. Fügen Sie den Inhalt der HTML-Datei im gelesenen TextReader zur ParagraphCollection des TextFrame hinzu.
9. Speichern Sie die modifizierte Präsentation.

Dieser PHP-Code ist eine Implementierung der Schritte zum Importieren von HTML-Text in Absätzen:

```php
  # Erstellen Sie eine leere Präsentationsinstanz
  $pres = new Presentation();
  try {
    # Greifen Sie auf die Standarderste Folie der Präsentation zu
    $slide = $pres->getSlides()->get_Item(0);
    # Fügen Sie die AutoShape hinzu, um den HTML-Inhalt unterzubringen
    $ashape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, $pres->getSlideSize()->getSize()->getWidth() - 20, $pres->getSlideSize()->getSize()->getHeight() - 10);
    $ashape->getFillFormat()->setFillType(FillType::NoFill);
    # Fügen Sie dem Shape einen TextFrame hinzu
    $ashape->addTextFrame("");
    # Löschen Sie alle Absätze im hinzugefügten TextFrame
    $ashape->getTextFrame()->getParagraphs()->clear();
    # Laden Sie die HTML-Datei mit dem Stream Reader
    $tr = new StreamReader("file.html");
    # Fügen Sie den Text aus dem HTML-Stream-Reader in den TextFrame ein
    $ashape->getTextFrame()->getParagraphs()->addFromHtml($tr->readToEnd());
    # Speichern der Präsentation
    $pres->save("output_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Exportieren Sie Absatztexte nach HTML**

Aspose.Slides bietet erweiterte Unterstützung für den Export von Texten (die in Absätzen enthalten sind) nach HTML.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) Klasse und laden Sie die gewünschte Präsentation.
2. Greifen Sie über seinen Index auf die entsprechende Folie zu.
3. Greifen Sie auf die Form zu, die den Text enthält, der nach HTML exportiert wird.
4. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) der Form zu.
5. Erstellen Sie eine Instanz von `StreamWriter` und fügen Sie die neue HTML-Datei hinzu.
6. Geben Sie einen Startindex für den StreamWriter an und exportieren Sie Ihre bevorzugten Absätze.

Dieser PHP-Code zeigt Ihnen, wie Sie PowerPoint-Absatztexte nach HTML exportieren:

```php
  # Laden Sie die Präsentationsdatei
  $pres = new Presentation("ExportingHTMLText.pptx");
  try {
    # Greifen Sie auf die Standarderste Folie der Präsentation zu
    $slide = $pres->getSlides()->get_Item(0);
    # Gewünschter Index
    $index = 0;
    # Zugriff auf die hinzugefügte Form
    $ashape = $slide->getShapes()->get_Item($index);
    # Erstellung der Ausgabedatei HTML
    $os = new Java("java.io.FileOutputStream", "output.html");
    $writer = new OutputStreamWriter($os, "UTF-8");
    # Extrahieren des ersten Absatzes als HTML
    # Schreiben der Absatzdaten in HTML durch Angabe des Startindex des Absatzes, insgesamt zu kopierender Absätze
    $writer->write($ashape->getTextFrame()->getParagraphs()->exportToHtml(0, $ashape->getTextFrame()->getParagraphs()->getCount(), null));
    $writer->close();
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```