---
title: Zarządzanie akapitami tekstu PowerPoint w JavaScript
linktitle: Zarządzaj akapitem
type: docs
weight: 40
url: /pl/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- dodaj tekst
- dodaj akapit
- zarządzaj tekstem
- zarządzaj akapitem
- zarządzaj wypunktowaniem
- wcięcie akapitu
- wcięcie wiszące
- wypunktowanie akapitu
- lista numerowana
- lista wypunktowana
- właściwości akapitu
- importuj HTML
- tekst na HTML
- akapit na HTML
- akapit na obraz
- tekst na obraz
- eksportuj akapit
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować akapity, fragmenty, wypunktowania, listy numerowane, wcięcia, treść HTML oraz obrazy akapitów przy użyciu Aspose.Slides dla Node.js w środowisku Java."
---
## **Przegląd**

Aspose.Slides for Node.js via Java represents text as a hierarchy of text frames, paragraphs, and portions:

* [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) represents the text container in a shape and provides access to its paragraph collection.
* [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) represents one paragraph in a text frame and provides access to its portions and paragraph-level formatting.
* [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/) represents a text run within a paragraph. Each portion can have its own text and character-level formatting.

A paragraph can therefore contain text with different fonts, colors, sizes, and other formatting by using multiple portions.

## **Tworzenie i formatowanie akapitów**

### **Tworzenie akapitów z wieloma fragmentami**

The following steps create a text frame with three paragraphs, each containing three portions:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj prostokątny [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) kształtu.
5. Użyj domyślnego akapitu i dodaj dwa dodatkowe obiekty [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) do ramki tekstowej.
6. Dodaj wystarczającą liczbę obiektów [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/) dla każdego akapitu, aby zawierały trzy fragmenty. Domyślny akapit już zawiera jeden pusty fragment.
7. Ustaw tekst dla każdego fragmentu.
8. Zastosuj formatowanie na poziomie znaków za pomocą [Portion.getPortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/getportionformat/).
9. Zapisz zmodyfikowaną prezentację.

Poniższy przykład JavaScript realizuje te kroki:

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

## **Tworzenie list wypunktowanych i numerowanych**

### **Tworzenie listy wypunktowanej lub numerowanej**

Bullets and numbering make related items easier to scan. In Aspose.Slides, list settings are defined through [BulletFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do wybranego slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) kształtu.
5. Usuń domyślny akapit z ramki tekstowej.
6. Utwórz [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) dla symbolu wypunktowania.
7. Ustaw [BulletFormat.setType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/settype/) na [BulletType.Symbol](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bullettype/) i określ znak wypunktowania.
8. Ustaw tekst akapitu, wcięcie, kolor wypunktowania i wysokość wypunktowania.
9. Dodaj akapit do ramki tekstowej.
10. Utwórz drugi akapit i ustaw [BulletFormat.setType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/settype/) na [BulletType.Numbered](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bullettype/).
11. Skonfiguruj styl numerowanego wypunktowania i dodaj akapit do ramki tekstowej.
12. Zapisz prezentację.

Poniższy przykład JavaScript tworzy wypunktowanie symboliczne oraz numerowane:

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

### **Użycie wypunktowania obrazkowego**

Picture bullets let you use a custom image instead of a symbol or number.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) i uzyskaj dostęp do jego [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/).
4. Usuń domyślny akapit z ramki tekstowej.
5. Załaduj obraz wypunktowania i dodaj go do kolekcji obrazów prezentacji jako [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/).
6. Utwórz [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) i ustaw jego tekst.
7. Ustaw [BulletFormat.setType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/settype/) na [BulletType.Picture](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bullettype/).
8. Przypisz obraz za pomocą [BulletFormat.getPicture](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/getpicture/) i ustaw wysokość wypunktowania.
9. Dodaj akapit do ramki tekstowej.
10. Zapisz zmodyfikowaną prezentację.

Poniższy przykład JavaScript tworzy wypunktowanie obrazkowe:

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

### **Tworzenie listy wielopoziomowej**

Set [ParagraphFormat.setDepth](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setdepth/) to place paragraphs at different levels of a list. The top level has a depth of `0`.

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i uzyskaj dostęp do slajdu.
2. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) i usuń domyślny akapit z jego ramki tekstowej.
3. Utwórz cztery akapity i skonfiguruj ich symbole wypunktowania.
4. Ustaw ich wartości [ParagraphFormat.setDepth](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setdepth/) na `0`, `1`, `2` i `3`.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

Poniższy przykład JavaScript tworzy czteropoziomową listę wypunktowaną:

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

### **Rozpoczęcie numerowanej listy od niestandardowych wartości**

Use [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) to set the initial number displayed for a numbered paragraph.

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
2. Wyczyść domyślny akapit z ramki tekstowej kształtu.
3. Utwórz trzy numerowane akapity.
4. Ustaw [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) na `2`, `3` i `7` dla odpowiednich akapitów.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

Poniższy przykład JavaScript przypisuje niestandardowy numer początkowy do każdego akapitu:

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

## **Kontrola układu akapitu i właściwości końcowych**

### **Ustawienie wcięcia pierwszej linii**

Use [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/) to control the first-line indent of a paragraph. This method moves only the first line relative to the paragraph's left margin. A positive value shifts the first line to the right, while the remaining lines stay aligned to the paragraph body.

Use [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) when you need to move the whole paragraph. Use [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/) when you need to move only the first line.

The example below creates several paragraphs and applies different [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/) values to demonstrate how the first-line indent affects paragraph layout.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątny [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) kształtu i usuń domyślny akapit.
5. Utwórz kilka akapitów i ustaw różne wartości [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/) dla nich.
6. Dodaj akapity do ramki tekstowej.
7. Zapisz zmodyfikowaną prezentację.

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

Wynik:

![Wcięcie pierwszej linii akapitów](first_line_indent.png)

### **Ustawienie wcięcia wiszącego**

A hanging indent is a paragraph layout in which the first line starts to the left of the remaining lines. In Aspose.Slides, you create this effect with [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/). Pass a negative value to move the first line to the left relative to the paragraph body.

In practice, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) defines the left position of the paragraph body, and [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/) defines the position of the first line relative to that margin. To create a hanging indent, pass a positive value to `setMarginLeft` and a negative value to `setIndent`.

This formatting is useful for bibliographies, references, glossary entries, and other paragraphs where wrapped lines must align under the paragraph body rather than under the first character of the first line.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątny [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) kształtu i usuń domyślny akapit.
5. Utwórz akapity i podaj dodatnią wartość do [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) dla każdego akapitu.
6. Podaj ujemną wartość do [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/) aby uzyskać efekt wcięcia wiszącego.
7. Dodaj akapity do ramki tekstowej.
8. Zapisz zmodyfikowaną prezentację.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 52, 52, 420, 220);
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

Wynik:

![Wcięcie wiszące akapitów](hanging_indent.png)

### **Ustawienie właściwości końcowego fragmentu akapitu**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) controls the formatting of the paragraph end mark. The following example assigns a font size and Latin font to the end mark of the second paragraph:

1. Utwórz lub wczytaj [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i uzyskaj dostęp do slajdu.
2. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) i wyczyść jego domyślny akapit.
3. Utwórz dwa akapity i dodaj do nich fragmenty tekstu.
4. Utwórz [PortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portionformat/) dla końcowego znaku drugiego akapitu.
5. Ustaw [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) i [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setLatinFont).
6. Przypisz format za pomocą [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) i zapisz prezentację.

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

## **Liczenie renderowanych linii**

Use [Paragraph.getLinesCount](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/#getLinesCount) to count the lines occupied by a paragraph after text layout, including automatic wrapping. This is useful when checking text length and layout in presentation templates.

A paragraph is one item in [TextFrame.getParagraphs](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/#getParagraphs), and it can occupy several rendered lines. An explicit line break within a paragraph forces a new line without creating another paragraph. Automatic wrapping creates lines based on the available width without inserting explicit line breaks into the text. Counting paragraphs or line-break characters therefore does not give the rendered line count.

The following example creates a text shape, counts its lines, narrows the shape, and then replaces the text with a shorter string. Wrapping is enabled and autofit is disabled so that the shape width controls wrapping without automatically shrinking the text or resizing the shape. Shape dimensions are in points. Finally, the example adds another paragraph and sums the line counts across the text frame.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

With this text and these dimensions, narrowing the shape increases the line count, while replacing the text with the short string reduces it. Exact counts can vary with font availability and substitution, font size, margins, indentation, wrapping, and autofit settings. Use the fonts and layout settings intended for the target environment when checking a template.

The line count alone does not determine whether text overflows its container. The available height, line heights, paragraph and line spacing, and autofit behavior also matter; even a single line can exceed the available width when wrapping is disabled.

## **Import i eksport treści akapitu**

### **Importowanie tekstu HTML do akapitów**

Use [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) to convert HTML markup into paragraphs and portions in a text frame.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do slajdu i dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/).
3. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) kształtu i wyczyść jego domyślny akapit.
4. Zdefiniuj lub wczytaj źródłowy ciąg HTML.
5. Przekaż ciąg HTML do [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. Zapisz zmodyfikowaną prezentację.

Poniższy przykład JavaScript importuje HTML do ramki tekstowej:

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

### **Eksportowanie tekstu akapitu do HTML**

Use [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) to export a selected range of paragraphs as HTML.

1. Utwórz lub wczytaj instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do slajdu i znajdź [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) zawierający tekst.
3. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/).
4. Wywołaj [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) podając indeks początkowego akapitu oraz liczbę akapitów do wyeksportowania.
5. Zapisz zwrócony ciąg HTML do pliku.

Poniższy, samodzielny przykład JavaScript tworzy kształt tekstowy i eksportuje wszystkie jego akapity:

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

### **Renderowanie akapitu jako obrazu**

[Paragraph.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/#getImage) renders an individual paragraph directly and returns an [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/). Save the result to a file with [IImage.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/#save). You do not need to render the containing shape or crop a bitmap manually.

[Paragraph.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/#getImage) can return `null` if the paragraph cannot be found in its parent collection, has no valid rendering bounds, or cannot be rendered. Check the result before saving it and dispose of the returned image after use.

#### **Renderowanie akapitu w domyślnej skali**

The following text box contains three paragraphs:

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

The following example renders the second paragraph in a regular text shape at the default scale and saves the returned image in PNG format. The `finally` block ensures that the image is disposed of correctly.

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

Wynik:

![Obraz akapitu](paragraph_to_image_output.png)

#### **Renderowanie akapitu w komórce tabeli ze skalowaniem**

Use the [Paragraph.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/#getImage) overload that accepts `scaleX` and `scaleY` parameters to set the horizontal and vertical scale factors. The following example creates a table, renders the paragraph in its first cell at twice its default width and height, and saves the result as a PNG image.

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

A scale factor of `1` keeps that axis at its default pixel size. For example, `2` for both factors produces an image whose width and height are approximately twice the default dimensions, resulting in four times as many pixels. Larger factors generally produce sharper text for zooming or high-resolution output, but they also increase memory use and file size. Factors below `1` produce smaller images with less detail. Use equal factors to preserve the paragraph's aspect ratio; different horizontal and vertical factors stretch the output independently.

Rendering a whole shape with [Shape.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getImage) remains useful when the output must include the shape's fill, border, or other visual context. For a paragraph-only image, use [Paragraph.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Czy mogę całkowicie wyłączyć zawijanie linii wewnątrz ramki tekstowej?**

Tak. Ustaw [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/setwraptext/) aby wyłączyć zawijanie, dzięki czemu linie nie będą łamane przy krawędziach ramki tekstowej.

**Jak mogę uzyskać dokładne granice na slajdzie konkretnego akapitu?**

Użyj [Paragraph.getRect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/getrect/) aby pobrać prostokąt otaczający akapit. [Portion.getRect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/#getRect) dostarcza granice pojedynczego fragmentu.

**Gdzie kontrolowane jest wyrównanie akapitu (lewe, prawe, wyśrodkowane lub wyjustowane)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setalignment/) jest ustawieniem na poziomie akapitu i ma zastosowanie do całego akapitu, niezależnie od formatowania poszczególnych fragmentów.

**Czy mogę ustawić język sprawdzania pisowni dla części akapitu?**

Tak. Ustaw [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) dla pojedynczych fragmentów, dzięki czemu jeden akapit może zawierać tekst w wielu językach.