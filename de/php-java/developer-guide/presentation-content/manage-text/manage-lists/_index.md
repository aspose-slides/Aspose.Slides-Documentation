---
title: Aufzählungs- und nummerierte Listen in Präsentationen mit PHP verwalten
linktitle: Listen verwalten
type: docs
weight: 60
url: /de/php-java/manage-lists/
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
description: "Erfahren Sie, wie Sie Aufzählungs-, Bild-, Mehrstufen- und nummerierte Listen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für PHP via Java erstellen und formatieren."
---
## **Übersicht**

Aspose.Slides für PHP via Java ermöglicht das Erstellen und Formatieren von Aufzählungs- und nummerierten Listen in PowerPoint- und OpenDocument-Präsentationen. Ein Listenelement ist ein Absatz, dessen Aufzählungseinstellungen über das Absatzformat gesteuert werden.

Verwenden Sie die [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/#getParagraphFormat--) Methode, um die listenbezogenen Einstellungen auf Absatzebene zuzugreifen. Der Haupteinstiegspunkt ist [ParagraphFormat.getBullet](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/#getBullet--) , der ein [BulletFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/bulletformat/) Objekt zurückgibt. Mit diesem Objekt können Sie den Aufzählungstyp, das Symbol, das Bild, die Farbe, die Größe, den Nummerierungsstil und die Startnummer festlegen.

Dieser Artikel zeigt, wie man:

- eine Aufzählungsliste mit einem benutzerdefinierten Symbol erstellen
- ein Bild-Aufzählungszeichen erstellen
- eine mehrstufige Liste erstellen, indem die Absatz-Tiefe festgelegt wird
- eine nummerierte Liste erstellen
- das Listenformat in einer bestehenden Präsentation untersuchen und ändern

## **Aufzählungsliste erstellen**

Um eine Aufzählungsliste zu erstellen, fügen Sie [Paragraph](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraph/) Objekte zu einem [TextFrame](https://reference.aspose.com/slides/de/php-java/aspose.slides/textframe/) hinzu und setzen Sie [BulletFormat.setType](https://reference.aspose.com/slides/de/php-java/aspose.slides/bulletformat/#setType-int-) auf [BulletType.Symbol](https://reference.aspose.com/slides/de/php-java/aspose.slides/bullettype/#Symbol). Anschließend können Sie [BulletFormat.setChar](https://reference.aspose.com/slides/de/php-java/aspose.slides/bulletformat/#setChar-char-), [BulletFormat.getColor](https://reference.aspose.com/slides/de/php-java/aspose.slides/bulletformat/#getColor--) und [BulletFormat.setHeight](https://reference.aspose.com/slides/de/php-java/aspose.slides/bulletformat/#setHeight-float-) festlegen, um das Aussehen der Aufzählungszeichen zu steuern.

Der folgende PHP-Code demonstriert, wie man in einer Folie eine Aufzählungsliste erstellt:

```php
function createParagraph($paragraphText)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Symbol);
    $paragraph->getParagraphFormat()->getBullet()->setChar("*");
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setBulletHardColor(NullableBool::True);
    $bulletColor = new Java("java.awt.Color", 205, 92, 92);
    $paragraph->getParagraphFormat()->getBullet()->getColor()->setColor($bulletColor);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = createParagraph("The first paragraph");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph");
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("symbol_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Das Ergebnis:

![The symbol bullets](symbol_bullets.png)

## **Nummerierte Liste erstellen**

Verwenden Sie nummerierte Listen, wenn die Reihenfolge der Elemente wichtig ist. Setzen Sie [BulletFormat.setType](https://reference.aspose.com/slides/de/php-java/aspose.slides/bulletformat/#setType-int-) auf [BulletType.Numbered](https://reference.aspose.com/slides/de/php-java/aspose.slides/bullettype/#Numbered). Sie können außerdem ein Nummerierungsformat mit [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/de/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) wählen oder [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/de/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) festlegen, wenn die Liste nicht bei 1 beginnen soll.

Der folgende PHP-Code zeigt, wie man in einer Folie eine nummerierte Liste erstellt:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 90, 80);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph1->setText("Apple");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph2->setText("Orange");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph3->setText("Banana");
    $textFrame->getParagraphs()->add($paragraph3);

    $presentation->save("numbered_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Das Ergebnis:

![The numbered bullets](numbered_bullets.png)

## **Bild‑Aufzählungszeichen erstellen**

Aspose.Slides ermöglicht es, ein reguläres Aufzählungszeichen durch ein Bild zu ersetzen. Bild‑Aufzählungszeichen funktionieren am besten mit einfachen Bildern, die auch in kleiner Größe lesbar bleiben, wie Icons oder kleine transparente PNG‑Dateien.

{{% alert color="primary" %}}
Idealerweise, wenn Sie das reguläre Aufzählungszeichen durch ein Bild ersetzen möchten, sollten Sie eine einfache Grafik mit transparentem Hintergrund wählen. Solche Bilder eignen sich gut als benutzerdefinierte Aufzählungszeichen.

Beachten Sie, dass das Bild auf eine sehr kleine Größe herunter skaliert wird. Aus diesem Grund empfehlen wir dringend, ein Bild auszuwählen, das auch in verkleinerter Form klar und visuell wirksam bleibt, wenn es als Aufzählungszeichen in einer Liste verwendet wird.
{{% /alert %}}

Um ein Bild‑Aufzählungszeichen zu erstellen, fügen Sie ein Bild zu [Presentation.getImages](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/#getImages--) hinzu und weisen Sie das zurückgegebene [PPImage](https://reference.aspose.com/slides/de/php-java/aspose.slides/ppimage/) Objekt [BulletFormat.getPicture](https://reference.aspose.com/slides/de/php-java/aspose.slides/bulletformat/#getPicture--) zu. Setzen Sie [BulletFormat.setType](https://reference.aspose.com/slides/de/php-java/aspose.slides/bulletformat/#setType-int-) auf [BulletType.Picture](https://reference.aspose.com/slides/de/php-java/aspose.slides/bullettype/#Picture), bevor Sie das Bild zuweisen.

Angenommen, wir haben eine "image.png":

![A picture for the bullets](picture_for_bullets.png)

Der folgende PHP-Code zeigt, wie man Bild‑Aufzählungszeichen in einer Folie erstellt:

```php
function createParagraph($paragraphText, $bulletImage)
{
    $paragraph = new Paragraph();
    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Picture);
    $paragraph->getParagraphFormat()->getBullet()->getPicture()->setImage($bulletImage);
    $paragraph->getParagraphFormat()->setIndent(15);
    $paragraph->getParagraphFormat()->getBullet()->setHeight(100);
    $paragraph->setText($paragraphText);
    return $paragraph;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 200, 50);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $image = Images::fromFile("image.png");
    $bulletImage = $presentation->getImages()->addImage($image);

    $paragraph1 = createParagraph("The first paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = createParagraph("The second paragraph", $bulletImage);
    $textFrame->getParagraphs()->add($paragraph2);

    $presentation->save("picture_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Das Ergebnis:

![The picture bullets](picture_bullets.png)

## **Mehrstufige Liste erstellen**

Verwenden Sie [ParagraphFormat.setDepth](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/#setDepth-short-), um Listenelemente auf verschiedenen Ebenen zu platzieren. Ebene 0 ist die oberste Ebene, Ebene 1 ist darunter verschachtelt usw.

Der folgende PHP-Code zeigt, wie man eine mehrstufige Aufzählungsliste erstellt:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 260, 110);

    $textFrame = $autoShape->getTextFrame();
    $textFrame->getParagraphs()->clear();

    $paragraph1 = new Paragraph();
    $paragraph1->getParagraphFormat()->setDepth(0);
    $paragraph1->setText("My text - Depth 0");
    $textFrame->getParagraphs()->add($paragraph1);

    $paragraph2 = new Paragraph();
    $paragraph2->getParagraphFormat()->setDepth(1);
    $paragraph2->setText("My text - Depth 1");
    $textFrame->getParagraphs()->add($paragraph2);

    $paragraph3 = new Paragraph();
    $paragraph3->getParagraphFormat()->setDepth(2);
    $paragraph3->setText("My text - Depth 2");
    $textFrame->getParagraphs()->add($paragraph3);

    $paragraph4 = new Paragraph();
    $paragraph4->getParagraphFormat()->setDepth(3);
    $paragraph4->setText("My text - Depth 3");
    $textFrame->getParagraphs()->add($paragraph4);

    $presentation->save("multilevel_bullets.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Das Ergebnis:

![The multilevel list](multilevel_list.png)

## **Vorhandene Liste ändern**

Um das Listenformat in einer vorhandenen Präsentation zu ändern, greifen Sie auf den Zielabsatz zu und aktualisieren dessen [ParagraphFormat.getBullet](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/#getBullet--) Einstellungen. Die gleichen Eigenschaften, die zum Erstellen von Listen verwendet werden, können zum Untersuchen oder Ändern von aus einer PPT-, PPTX- oder ODP‑Datei geladenen Listen verwendet werden.

```php
$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->getBullet()->setType(BulletType::Numbered);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStyle(NumberedBulletStyle::BulletRomanUCPeriod);
    $paragraph->getParagraphFormat()->getBullet()->setNumberedBulletStartWith(1);
    $paragraph->getParagraphFormat()->setMarginLeft(30);
    $paragraph->getParagraphFormat()->setIndent(-20);

    $presentation->save("updated_list.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **FAQ**

**Können Aufzählungs- und nummerierte Listen in PDF oder Bilder exportiert werden?**

Ja. Aspose.Slides bewahrt das Listenformat, wenn das Zielformat die entsprechenden Textlayout- und Aufzählungs-Funktionen unterstützt.

**Kann ich Listen in bestehenden Präsentationen bearbeiten?**

Ja. Laden Sie die Präsentation, greifen Sie auf den Zielabsatz zu, prüfen oder aktualisieren Sie dessen [ParagraphFormat.getBullet](https://reference.aspose.com/slides/de/php-java/aspose.slides/paragraphformat/#getBullet--) Einstellungen und speichern Sie die Präsentation.

**Können Listen nicht‑lateinischen Text enthalten?**

Ja. Der Text von Listenelementen kann Unicode‑Zeichen enthalten, sodass Sie Listen in mehrsprachigen Präsentationen erstellen können. Stellen Sie sicher, dass die in der Präsentation verwendeten Schriftarten die benötigten Zeichen unterstützen.