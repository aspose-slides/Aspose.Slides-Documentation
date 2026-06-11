---
title: Hantera punkt- och numrerade listor i presentationer med PHP
linktitle: Hantera listor
type: docs
weight: 60
url: /sv/php-java/manage-lists/
keywords:
- punkt
- punktlista
- numrerad lista
- symbolpunkt
- bildpunkt
- anpassad punkt
- flernivålista
- skapa punkt
- lägga till punkt
- lägga till lista
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar punkt-, bild-, flernivå- och numrerade listor i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP via Java."
---
## **Översikt**

Aspose.Slides för PHP via Java låter dig skapa och formatera punktlistor och numrerade listor i PowerPoint‑ och OpenDocument‑presentationer. Ett listobjekt är ett stycke vars punktinställningar styrs via dess styckeformat.

Använd metoden [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/#getParagraphFormat--) för att komma åt listinställningar på styckelnivå. Huvudingångspunkten är [ParagraphFormat.getBullet](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#getBullet--) som returnerar ett [BulletFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/)-objekt. Med detta objekt kan du ange puntktyp, symbol, bild, färg, storlek, numreringsstil och startnummer.

Denna artikel visar hur du:

- skapar en punktlista med en anpassad symbol
- skapar en bildpunkt
- skapar en flernivålista genom att ange styckedjup
- skapar en numrerad lista
- granskar och ändrar listformatering i en befintlig presentation

## **Skapa en punktlista**

För att skapa en punktlista, lägg till [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/)-objekt i en [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/) och sätt [BulletFormat.setType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/#setType-int-) till [BulletType.Symbol](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bullettype/#Symbol). Du kan sedan ange [BulletFormat.setChar](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/#setChar-char-), [BulletFormat.getColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/#getColor--) och [BulletFormat.setHeight](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/#setHeight-float-) för att styra punktens utseende.

Följande PHP‑kod demonstrerar hur du skapar en punktlista i en bild:

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

Resultatet:

![Symbolpunkterna](symbol_bullets.png)

## **Skapa en numrerad lista**

Använd numrerade listor när ordningen på objekten är viktig. Sätt [BulletFormat.setType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/#setType-int-) till [BulletType.Numbered](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bullettype/#Numbered). Du kan också välja ett nummerformat med [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/#setNumberedBulletStyle-int-) eller sätta [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) när listan ska börja på ett annat värde än 1.

Följande PHP‑kod visar hur du skapar en numrerad lista i en bild:

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

Resultatet:

![Numrerade punkter](numbered_bullets.png)

## **Skapa en bildpunkt**

Aspose.Slides låter dig ersätta en vanlig punkt‑symbol med en bild. Bildpunkter fungerar bäst med enkla bilder som förblir läsbara i liten storlek, exempelvis ikoner eller små transparenta PNG‑filer.

{{% alert color="primary" %}}

Om du planerar att ersätta den vanliga punkt‑symbolen med en bild är det bäst att välja en enkel grafik med transparent bakgrund. Sådana bilder fungerar bra som anpassade punkt‑symboler.

Kom ihåg att bilden kommer att skalas ner till en mycket liten storlek. Av den anledningen rekommenderar vi starkt att välja en bild som förblir klar och visuellt effektiv när den används som punkt i en lista.

{{% /alert %}}

För att skapa en bildpunkt, lägg till en bild i [Presentation.getImages](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/#getImages--) och tilldela det returnerade [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)-objektet till [BulletFormat.getPicture](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/#getPicture--). Sätt [BulletFormat.setType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bulletformat/#setType-int-) till [BulletType.Picture](https://reference.aspose.com/slides/sv/php-java/aspose.slides/bullettype/#Picture) innan du tilldelar bilden.

Låt oss säga att vi har en "image.png":

![En bild för punkterna](picture_for_bullets.png)

Följande PHP‑kod visar hur du skapar bildpunkter i en bild:

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

Resultatet:

![Bildpunkterna](picture_bullets.png)

## **Skapa en flernivålista**

Använd [ParagraphFormat.setDepth](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#setDepth-short-) för att placera listobjekt på olika nivåer. Nivå 0 är den översta nivån, nivå 1 ligger nestlad under den, och så vidare.

Följande PHP‑kod visar hur du skapar en flernivå punktlista:

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

Resultatet:

![Flernivålistan](multilevel_list.png)

## **Ändra en befintlig lista**

För att ändra listformatering i en befintlig presentation, hämta målstycket och uppdatera dess [ParagraphFormat.getBullet](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#getBullet--)‑inställningar. Samma egenskaper som används för att skapa listor kan också användas för att granska eller modifiera listor som lästs in från en PPT, PPTX eller ODP‑fil.

Följande PHP‑kod ändrar det första stycket i en textram i en bild så att det använder en numrerad liststil:

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

**Kan punkt‑ och numrerade listor exporteras till PDF eller bilder?**

Ja. Aspose.Slides behåller listformatering när målformatet stödjer motsvarande textlayout och punkt‑funktioner.

**Kan jag redigera listor i befintliga presentationer?**

Ja. Läs in presentationen, hämta målstycket, granska eller uppdatera dess [ParagraphFormat.getBullet](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/#getBullet--)‑inställningar och spara presentationen.

**Kan listor innehålla icke‑latinsk text?**

Ja. Text i listobjekt kan innehålla Unicode‑tecken, så du kan skapa listor i flerspråkiga presentationer. Se till att de typsnitt som används i presentationen stöder de tecken du behöver.