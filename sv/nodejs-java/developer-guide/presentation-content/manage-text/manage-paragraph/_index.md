---
title: Hantera PowerPoint-textstycken i JavaScript
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- lägga till text
- lägga till stycke
- hantera text
- hantera stycke
- hantera punkt
- stycke indrag
- hängande indrag
- stycke punkt
- numrerad lista
- punktlista
- styckeegenskaper
- importera HTML
- text till HTML
- stycke till HTML
- stycke till bild
- text till bild
- exportera stycke
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du skapar och formaterar stycken, delar, punkter, numrerade listor, indrag, HTML‑innehåll och styckebilder med Aspose.Slides för Node.js via Java."
---
## **Översikt**

Aspose.Slides för Node.js via Java representerar text som en hierarki av textramar, stycken och delar:

* [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/) representerar textbehållaren i en form och ger åtkomst till dess stycke‑samling.
* [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/) representerar ett stycke i en textram och ger åtkomst till dess delar och styckes‑formatering.
* [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/) representerar ett textsegment inom ett stycke. Varje del kan ha egen text och tecken‑nivå formatering.

Ett stycke kan därför innehålla text med olika teckensnitt, färger, storlekar och annan formatering genom att använda flera delar.

## **Skapa och formatera stycken**

### **Skapa stycken med flera delar**

Följande steg skapar en textram med tre stycken, var och en innehållande tre delar:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Åtkom den relevanta bilden via dess index.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
4. Åtkom formens [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).
5. Använd standardstycket och lägg till två ytterligare [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/)‑objekt i textramen.
6. Lägg till tillräckligt många [Portion](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/)‑objekt så att varje stycke innehåller tre delar. Standardstycket innehåller redan en tom del.
7. Ställ in texten för varje del.
8. Applicera tecken‑nivå formatering via [Portion.getPortionFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portion/getportionformat/).
9. Spara den modifierade presentationen.

Detta JavaScript‑exempel implementerar stegen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Skapa punktlistor och numrerade listor**

### **Skapa en punkt- eller numrerad lista**

Punkter och numrering gör relaterade objekt enklare att skanna. I Aspose.Slides definieras listinställningar via [BulletFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/bulletformat/).

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Åtkom den relevanta bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på den valda bilden.
4. Åtkom formens [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).
5. Ta bort standardstycket från textramen.
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/) för en symbolpunkt.
7. Ställ in [BulletFormat.setType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/bulletformat/settype/) till [BulletType.Symbol](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/bullettype/) och ange punkttecknet.
8. Ställ in styckets text, indrag, punktfärg och punktens höjd.
9. Lägg till stycket i textramen.
10. Skapa ett andra stycke och sätt [BulletFormat.setType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/bulletformat/settype/) till [BulletType.Numbered](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/bullettype/).
11. Konfigurera den numrerade punktstilen och lägg till stycket i textramen.
12. Spara presentationen.

Detta JavaScript‑exempel skapar en symbolpunkt och en numrerad punkt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Använd bildpunkter**

Bildpunkter låter dig använda en anpassad bild istället för en symbol eller siffra.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
2. Åtkom den relevanta bilden via dess index.
3. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) och åtkom dess [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).
4. Ta bort standardstycket från textramen.
5. Läs in punktbilden och lägg till den i presentationens bildsamling som en [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/).
6. Skapa ett [Paragraph](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/) och ställ in dess text.
7. Ställ in [BulletFormat.setType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/bulletformat/settype/) till [BulletType.Picture](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/bullettype/).
8. Tilldela bilden via [BulletFormat.getPicture](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/bulletformat/getpicture/) och sätt punktens höjd.
9. Lägg till stycket i textramen.
10. Spara den modifierade presentationen.

Detta JavaScript‑exempel skapar en bildpunkt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **Skapa en flernivålista**

Ange [ParagraphFormat.setDepth] för att placera stycken på olika nivåer i en lista. Toppnivån har ett djup på `0`.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och åtkom en bild.
2. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) och rensa standardstycket från dess textram.
3. Skapa fyra stycken och konfigurera deras punkt‑symboler.
4. Sätt deras [ParagraphFormat.setDepth]-värden till `0`, `1`, `2` och `3`.
5. Lägg till styckena i textramen och spara presentationen.

Detta JavaScript‑exempel skapar en fyranivåpunktlista:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Starta numrerade listobjekt vid anpassade värden**

Använd [BulletFormat.setNumberedBulletStartWith] för att ange det initiala numret som visas för ett numrerat stycke.

1. Skapa en [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/) och lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på en bild.
2. Rensa standardstycket från formens textram.
3. Skapa tre numrerade stycken.
4. Ställ in [BulletFormat.setNumberedBulletStartWith] till `2`, `3` och `7` för respektive stycke.
5. Lägg till styckena i textramen och spara presentationen.

Detta JavaScript‑exempel tilldelar ett anpassat startnummer till varje stycke:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Styr stycke‑layout och slut‑egenskaper**

### **Ställ in indrag för första raden**

Använd [ParagraphFormat.setIndent] för att kontrollera indraget för den första raden i ett stycke. Denna metod flyttar endast den första raden i förhållande till styckets vänstra marginal. Ett positivt värde flyttar den första raden åt höger, medan de resterande raderna förblir justerade med styckets kropp.

Använd [ParagraphFormat.setMarginLeft] när du behöver flytta hela stycket. Använd [ParagraphFormat.setIndent] när du endast behöver flytta den första raden.

Exemplet nedan skapar flera stycken och applicerar olika [ParagraphFormat.setIndent]-värden för att demonstrera hur indraget för den första raden påverkar stycke‑layouten.

1. Skapa en instans av klassen [Presentation].
2. Åtkom mål‑bilden.
3. Lägg till en rektangulär [AutoShape] på bilden.
4. Åtkom formens [TextFrame] och ta bort standardstycket.
5. Skapa flera stycken och ange olika [ParagraphFormat.setIndent]-värden för dem.
6. Lägg till styckena i textramen.
7. Spara den modifierade presentationen.

Denna kod visar hur du sätter ett styckeindrag:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Första radens indrag i styckena](first_line_indent.png)

### **Ställ in ett hängande indrag**

Ett hängande indrag är en stycke‑layout där den första raden börjar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med [ParagraphFormat.setIndent]. Skicka ett negativt värde för att flytta den första raden åt vänster i förhållande till styckets kropp.

I praktiken definierar [ParagraphFormat.setMarginLeft] den vänstra positionen för styckets kropp, och [ParagraphFormat.setIndent] definierar positionen för den första raden relativt den marginalen. För att skapa ett hängande indrag skickar du ett positivt värde till `setMarginLeft` och ett negativt värde till `setIndent`.

Denna formatering är användbar för bibliografier, referenser, förklaringsordlistor och andra stycken där radbrytningar måste justeras under styckets kropp snarare än under första tecknet i den första raden.

1. Skapa en instans av klassen [Presentation].
2. Åtkom mål‑bilden.
3. Lägg till en rektangulär [AutoShape] på bilden.
4. Åtkom formens [TextFrame] och ta bort standardstycket.
5. Skapa stycken och skicka ett positivt värde till [ParagraphFormat.setMarginLeft] för varje stycke.
6. Skicka ett negativt värde till [ParagraphFormat.setIndent] för att skapa det hängande indragseffekten.
7. Lägg till styckena i textramen.
8. Spara den modifierade presentationen.

Denna kod visar hur du sätter ett hängande indrag för ett stycke:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Det hängande indraget i styckena](hanging_indent.png)

### **Ställ in slut‑stycke‑körningsegenskaper**

[Paragraph.setEndParagraphPortionFormat] styr formateringen av paragrafens sluttecken. Följande exempel tilldelar en teckenstorlek och ett latin‑teckensnitt till sluttecknet i det andra stycket:

1. Skapa eller läs in en [Presentation] och åtkom en bild.
2. Lägg till en [AutoShape] och rensa dess standardstycke.
3. Skapa två stycken och lägg till textdelar i dem.
4. Skapa ett [PortionFormat] för det andra styckets sluttecken.
5. Ställ in [BasePortionFormat.setFontHeight] och [BasePortionFormat.setLatinFont].
6. Tilldela formatet med [Paragraph.setEndParagraphPortionFormat] och spara presentationen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Importera och exportera styckeinnehåll**

### **Importera HTML‑text i stycken**

Använd [ParagraphCollection.addFromHtml] för att konvertera HTML‑markup till stycken och delar i en textram.

1. Skapa en instans av klassen [Presentation].
2. Åtkom en bild och lägg till en [AutoShape].
3. Åtkom formens [TextFrame] och rensa dess standardstycke.
4. Definiera eller läs in HTML‑strängen.
5. Skicka HTML‑strängen till [ParagraphCollection.addFromHtml].
6. Spara den modifierade presentationen.

Detta JavaScript‑exempel importerar HTML till en textram:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Exportera styckestext till HTML**

Använd [ParagraphCollection.exportToHtml] för att exportera ett valt intervall av stycken som HTML.

1. Skapa eller läs in en instans av klassen [Presentation].
2. Åtkom bilden och hitta den [AutoShape] som innehåller texten.
3. Åtkom formens [TextFrame].
4. Anropa [ParagraphCollection.exportToHtml] med startindex för stycket och antalet stycken som ska exporteras.
5. Skriv den returnerade HTML‑strängen till en fil.

Detta fristående JavaScript‑exempel skapar en textruta och exporterar alla dess stycken:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

### **Rendera ett stycke som en bild**

[Paragraph.getImage] renderar ett enskilt stycke direkt och returnerar ett [IImage]. Spara resultatet till en fil med [IImage.save]. Du behöver inte rendera den innehållande formen eller beskära en bitmap manuellt.

[Paragraph.getImage] kan returnera `null` om stycket inte kan hittas i sin föräldrasamling, saknar giltiga renderingsgränser, eller inte kan renderas. Kontrollera resultatet innan du sparar det och frigör den returnerade bilden efter användning.

#### **Rendera ett stycke i standardskala**

Följande textruta innehåller tre stycken:

![Textrutan med tre stycken](paragraph_to_image_input.png)

Följande exempel renderar det andra stycket i en vanlig textruta i standardskala och sparar den returnerade bilden i PNG‑format. `finally`‑blocket säkerställer att bilden frigörs korrekt.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

Resultatet:

![Styckebilden](paragraph_to_image_output.png)

#### **Rendera ett stycke i en tabellcell med skalning**

Använd [Paragraph.getImage]-översättningen som accepterar parametrarna `scaleX` och `scaleY` för att ange horisontella och vertikala skalningsfaktorer. Följande exempel skapar en tabell, renderar stycket i dess första cell med dubbelt så stor standardbredd och -höjd, och sparar resultatet som en PNG‑bild.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

En skalningsfaktor på `1` behåller den axeln vid sin standardpixelstorlek. Till exempel ger `2` för båda faktorer en bild vars bredd och höjd är ungefär dubbelt så stora som standardmåtten, vilket resulterar i fyra gånger så många pixlar. Större faktorer ger i allmänhet skarpare text för zoomning eller högupplöst output, men de ökar också minnesanvändning och filstorlek. Faktorer under `1` ger mindre bilder med mindre detalj. Använd lika faktorer för att bevara styckets bildförhållande; olika horisontella och vertikala faktorer sträcker outputen oberoende av varandra.

Att rendera en hel form med [Shape.getImage] är fortfarande användbart när outputen måste inkludera formens fyllning, kantlinje eller annan visuell kontext. För en bild som enbart innehåller ett stycke, använd [Paragraph.getImage].

## **FAQ**

**Kan jag helt inaktivera radbrytning i en textram?**

Ja. Ställ in [TextFrameFormat.setWrapText] för att inaktivera radbrytning så att rader inte bryts vid textramens kanter.

**Hur kan jag få de exakta gränserna på bilden för ett specifikt stycke?**

Använd [Paragraph.getRect] för att hämta styckets avgränsningsrektangel. [Portion.getRect] ger avgränsningarna för en enskild del.

**Var kontrolleras styckejusteringen (vänster, höger, centrerad eller marginaljusterad)?**

[ParagraphFormat.setAlignment] är en styckesnivåinställning och gäller hela stycket oavsett individuell del‑formatering.

**Kan jag ange korrekturspråket för en del av ett stycke?**

Ja. Ställ in [BasePortionFormat.setLanguageId] för enskilda delar, så att ett stycke kan innehålla text på flera språk.