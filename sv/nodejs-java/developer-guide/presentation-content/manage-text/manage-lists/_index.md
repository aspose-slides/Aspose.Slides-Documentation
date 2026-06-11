---
title: Hantera punkt- och numrerade listor i presentationer med JavaScript
linktitle: Hantera listor
type: docs
weight: 60
url: /sv/nodejs-java/manage-lists/
keywords:
- punkt
- punktlista
- numrerad lista
- symbolpunkt
- bildpunkt
- anpassad punkt
- flernivålista
- skapa punkt
- lägg till punkt
- lägg till lista
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar punkt-, bild-, flernivå- och numrerade listor i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Aspose.Slides for Node.js via Java låter dig skapa och formatera punkt- och numrerade listor i PowerPoint- och OpenDocument-presentationer. Ett listobjekt är ett stycke vars punktinställningar kontrolleras via dess styckeformat.

Använd klassen [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/) för att komma åt listinställningar på styckennivå. Huvudinkörningspunkten är `Paragraph.getParagraphFormat().getBullet()`, som returnerar ett [BulletFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/bulletformat/)-objekt. Med detta objekt kan du ange punktens typ, symbol, bild, färg, storlek, numreringsstil och startnummer.

Den här artikeln visar hur du:

- skapar en punktlista med en anpassad symbol
- skapar en bildpunkt
- skapar en flernivålista genom att ange styckets djup
- skapar en numrerad lista
- inspekterar och ändrar listformatering i en befintlig presentation

## **Skapa en punktlista**

För att skapa en punktlista lägger du till [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/)-objekt i en [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) och sätter `BulletFormat.setType` till [BulletType.Symbol](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/bullettype/). Därefter kan du ställa in `BulletFormat.setChar`, `BulletFormat.getColor` och `BulletFormat.setHeight` för att kontrollera punktens utseende.

Följande JavaScript‑kod demonstrerar hur du skapar en punktlista i ett bildspel:

```javascript
function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Symbolpunkterna](symbol_bullets.png)

## **Skapa en numrerad lista**

Använd numrerade listor när ordningen på objekten är viktig. Sätt `BulletFormat.setType` till [BulletType.Numbered](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/bullettype/). Du kan även välja ett numreringsformat med `BulletFormat.setNumberedBulletStyle` eller ange `BulletFormat.setNumberedBulletStartWith` när listan ska börja med ett annat värde än 1.

Följande JavaScript‑kod visar hur du skapar en numrerad lista i ett bildspel:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Numrerade punkter](numbered_bullets.png)

## **Skapa en bildpunkt**

Aspose.Slides låter dig ersätta en vanlig punktsymbol med en bild. Bildpunkter fungerar bäst med enkla bilder som förblir läsbara i liten storlek, till exempel ikoner eller små transparenta PNG‑filer.

{{% alert color="primary" %}}
Idealiskt, om du planerar att ersätta den vanliga punktsymbolen med en bild, är det bäst att välja en enkel grafik med transparent bakgrund. Sådana bilder fungerar bra som anpassade punkt­symboler.

Kom ihåg att bilden kommer att skalas ner till en mycket liten storlek. Av den anledningen rekommenderar vi starkt att välja en bild som förblir tydlig och visuellt effektiv när den används som punkt i en lista.
{{% /alert %}}

För att skapa en bildpunkt lägger du till en bild i [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) med `Presentation.getImages().addImage` och tilldelar det returnerade [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/)-objektet till `BulletFormat.getPicture().setImage`. Sätt `BulletFormat.setType` till [BulletType.Picture](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/bullettype/) innan du tilldelar bilden.

Anta att vi har en "image.png":

![En bild för punkterna](picture_for_bullets.png)

Följande JavaScript‑kod visar hur du skapar bildpunkter i ett bildspel:

```javascript
function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

Resultatet:

![Bildpunkterna](picture_bullets.png)

## **Skapa en flernivålista**

Använd `ParagraphFormat.setDepth` för att placera listobjekt på olika nivåer. Nivå 0 är den översta nivån, nivå 1 är inbäddad under den, osv.

Följande JavaScript‑kod visar hur du skapar en flernivå punktlista:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Flernivålistan](multilevel_list.png)

## **Ändra en befintlig lista**

För att ändra listformatering i en befintlig presentation, nå det aktuella stycket och uppdatera dess `ParagraphFormat.getBullet`‑inställningar. Samma egenskaper som används för att skapa listor kan användas för att inspektera eller modifiera listor som lästs in från en PPT-, PPTX- eller ODP‑fil.

Följande JavaScript‑kod ändrar det första stycket i en textram för att använda en numrerad liststil:

```javascript
const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vanliga frågor**

**Kan punkt- och numrerade listor exporteras till PDF eller bilder?**

Ja. Aspose.Slides bevarar listformattering när måletformatet stödjer motsvarande textlayout och punktfunktioner.

**Kan jag redigera listor i befintliga presentationer?**

Ja. Läs in presentationen, få åtkomst till det aktuella stycket, inspektera eller uppdatera dess `ParagraphFormat.getBullet`‑inställningar och spara presentationen.

**Kan listor innehålla icke‑latinsk text?**

Ja. Text i listobjekt kan innehålla Unicode‑tecken, så du kan skapa listor i flerspråkiga presentationer. Se till att de teckensnitt som används i presentationen stödjer de tecken du behöver.