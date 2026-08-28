---
title: Zarządzanie akapitami tekstu PowerPoint w JavaScript
linktitle: Zarządzanie akapitem
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
- import HTML
- tekst do HTML
- akapit do HTML
- akapit do obrazu
- tekst do obrazu
- eksport akapitu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować akapity, fragmenty, wypunktowania, listy numerowane, wcięcia, treść HTML oraz obrazy akapitów przy użyciu Aspose.Slides dla Node.js via Java."
---
## **Przegląd**

Aspose.Slides for Node.js via Java reprezentuje tekst jako hierarchię ramek tekstowych, akapitów i fragmentów:

* [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) reprezentuje kontener tekstu w kształcie i zapewnia dostęp do jego kolekcji akapitów.
* [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) reprezentuje jeden akapit w ramce tekstowej i zapewnia dostęp do jego fragmentów oraz formatowania na poziomie akapitu.
* [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/) reprezentuje fragment tekstu w akapicie. Każdy fragment może mieć własny tekst i formatowanie znaków.

Akapit może więc zawierać tekst w różnych czcionkach, kolorach, rozmiarach i innym formatowaniu, korzystając z wielu fragmentów.

## **Tworzenie i formatowanie akapitów**

### **Tworzenie akapitów z wieloma fragmentami**

Poniższe kroki tworzą ramkę tekstową z trzema akapitami, z których każdy zawiera trzy fragmenty:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu przy użyciu jego indeksu.
3. Dodaj prostokątną [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) kształtu.
5. Użyj domyślnego akapitu i dodaj dwa dodatkowe obiekty [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) do ramki tekstowej.
6. Dodaj wystarczającą liczbę obiektów [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/) dla każdego akapitu, aby zawierał trzy fragmenty. Domyślny akapit już zawiera jeden pusty fragment.
7. Ustaw tekst każdego fragmentu.
8. Zastosuj formatowanie na poziomie znaków przy użyciu [Portion.getPortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/getportionformat/).
9. Zapisz zmodyfikowaną prezentację.

Ten przykład w JavaScript implementuje te kroki:

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

Wypunktowania i numeracje ułatwiają przegląd powiązanych elementów. W Aspose.Slides ustawienia listy są definiowane poprzez [BulletFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu przy użyciu jego indeksu.
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

Ten przykład w JavaScript tworzy symbol wypunktowania i numerowane wypunktowanie:

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

Wypunktowania obrazkowe pozwalają użyć własnego obrazu zamiast symbolu lub liczby.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do odpowiedniego slajdu przy użyciu jego indeksu.
3. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) i uzyskaj dostęp do jego [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/).
4. Usuń domyślny akapit z ramki tekstowej.
5. Wczytaj obraz wypunktowania i dodaj go do kolekcji obrazów prezentacji jako [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/).
6. Utwórz [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) i ustaw jego tekst.
7. Ustaw [BulletFormat.setType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/settype/) na [BulletType.Picture](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bullettype/).
8. Przypisz obraz przy użyciu [BulletFormat.getPicture](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/getpicture/) i ustaw wysokość wypunktowania.
9. Dodaj akapit do ramki tekstowej.
10. Zapisz zmodyfikowaną prezentację.

Ten przykład w JavaScript tworzy wypunktowanie obrazkowe:

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

Ustaw [ParagraphFormat.setDepth](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setdepth/) aby umieścić akapity na różnych poziomach listy. Najwyższy poziom ma głębokość `0`.

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i uzyskaj dostęp do slajdu.
2. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) i usuń domyślny akapit z jego ramki tekstowej.
3. Utwórz cztery akapity i skonfiguruj ich symbole wypunktowania.
4. Ustaw ich wartości [ParagraphFormat.setDepth](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setdepth/) na `0`, `1`, `2` i `3`.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

Ten przykład w JavaScript tworzy listę wypunktowaną czteropoziomową:

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

### **Rozpoczęcie numeracji elementów listy od własnych wartości**

Użyj [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) aby ustawić początkowy numer wyświetlany dla numerowanego akapitu.

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
2. Usuń domyślny akapit z ramki tekstowej kształtu.
3. Utwórz trzy numerowane akapity.
4. Ustaw [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) na `2`, `3` i `7` dla odpowiednich akapitów.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

Ten przykład w JavaScript przypisuje własny numer początkowy każdemu akapitowi:

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

Użyj [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/) aby kontrolować wcięcie pierwszej linii akapitu. Metoda ta przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Dodatnia wartość przesuwa pierwszą linię w prawo, natomiast pozostałe linie pozostają wyrównane do ciała akapitu.

Użyj [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) gdy potrzebujesz przesunąć cały akapit. Użyj [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/) gdy potrzebujesz przesunąć tylko pierwszą linię.

Poniższy przykład tworzy kilka akapitów i stosuje różne wartości [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/), aby pokazać, jak wcięcie pierwszej linii wpływa na układ akapitu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątną [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) kształtu i usuń domyślny akapit.
5. Utwórz kilka akapitów i ustaw różne wartości [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/) dla nich.
6. Dodaj akapity do ramki tekstowej.
7. Zapisz zmodyfikowaną prezentację.

Ten kod pokazuje, jak ustawić wcięcie akapitu:

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

Wcięcie wiszące to układ akapitu, w którym pierwsza linia zaczyna się po lewej stronie pozostałych linii. W Aspose.Slides tworzysz ten efekt przy pomocy [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/). Przekaż ujemną wartość, aby przesunąć pierwszą linię w lewo względem ciała akapitu.

W praktyce [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) definiuje lewą pozycję ciała akapitu, a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/) określa pozycję pierwszej linii względem tego marginesu. Aby stworzyć wcięcie wiszące, przekaż dodatnią wartość do `setMarginLeft` i ujemną wartość do `setIndent`.

To formatowanie jest przydatne w bibliografiach, przypisach, hasłach słownika i innych akapitach, gdzie linie zawijane muszą być wyrównane pod ciałem akapitu, a nie pod pierwszym znakiem pierwszej linii.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątną [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) kształtu i usuń domyślny akapit.
5. Utwórz akapity i przekaż dodatnią wartość do [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) dla każdego akapitu.
6. Przekaż ujemną wartość do [ParagraphFormat.setIndent](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setindent/), aby uzyskać efekt wcięcia wiszącego.
7. Dodaj akapity do ramki tekstowej.
8. Zapisz zmodyfikowaną prezentację.

Ten kod pokazuje, jak ustawić wcięcie wiszące dla akapitu:

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

Wynik:

![Wcięcie wiszące akapitów](hanging_indent.png)

### **Ustawienie właściwości końcowych akapitu**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) kontroluje formatowanie znaku końcowego akapitu. Poniższy przykład przypisuje rozmiar czcionki i czcionkę łacińską do znaku końcowego drugiego akapitu:

1. Utwórz lub wczytaj [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) i uzyskaj dostęp do slajdu.
2. Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) i usuń jego domyślny akapit.
3. Utwórz dwa akapity i dodaj do nich fragmenty tekstu.
4. Utwórz [PortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portionformat/) dla końcowego znaku drugiego akapitu.
5. Ustaw [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) i [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setLatinFont).
6. Przypisz format przy użyciu [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) i zapisz prezentację.

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

## **Import i eksport zawartości akapitu**

### **Importowanie tekstu HTML do akapitów**

Użyj [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) aby przekształcić kod HTML w akapity i fragmenty w ramce tekstowej.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do slajdu i dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/).
3. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) kształtu i usuń domyślny akapit.
4. Zdefiniuj lub odczytaj źródłowy ciąg HTML.
5. Przekaż ciąg HTML do [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/).
6. Zapisz zmodyfikowaną prezentację.

Ten przykład w JavaScript importuje HTML do ramki tekstowej:

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

### **Eksport tekstu akapitu do HTML**

Użyj [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) aby wyeksportować wybrany zakres akapitów jako HTML.

1. Utwórz lub wczytaj instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Uzyskaj dostęp do slajdu i znajdź [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/), który zawiera tekst.
3. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) kształtu.
4. Wywołaj [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) z indeksem początkowego akapitu i liczbą akapitów do wyeksportowania.
5. Zapisz zwrócony ciąg HTML do pliku.

Ten samodzielny przykład w JavaScript tworzy kształt tekstowy i eksportuje wszystkie jego akapity:

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

[Paragraph.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/#getImage) renderuje pojedynczy akapit bezpośrednio i zwraca [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/). Zapisz wynik do pliku przy użyciu [IImage.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/#save). Nie musisz renderować zawierającego kształtu ani ręcznie przycinać bitmapy.

[Paragraph.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/#getImage) może zwrócić `null`, jeśli akapit nie zostanie znaleziony w kolekcji nadrzędnej, nie ma prawidłowych granic renderowania lub nie może być renderowany. Sprawdź wynik przed zapisem i zwolnij zwrócony obraz po użyciu.

#### **Renderowanie akapitu w domyślnej skali**

Poniższe pole tekstowe zawiera trzy akapity:

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

Poniższy przykład renderuje drugi akapit w zwykłym kształcie tekstowym w domyślnej skali i zapisuje zwrócony obraz w formacie PNG. Blok `finally` zapewnia prawidłowe zwolnienie obrazu.

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

Użyj przeciążenia [Paragraph.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/#getImage), które przyjmuje parametry `scaleX` i `scaleY`, aby ustawić czynniki skali poziomej i pionowej. Poniższy przykład tworzy tabelę, renderuje akapit w jej pierwszej komórce dwukrotnie szerzej i wyżej niż domyślne rozmiary i zapisuje wynik jako obraz PNG.

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

Czynnik skali `1` pozostawia oś w jej domyślnym rozmiarze pikseli. Na przykład `2` dla obu czynników tworzy obraz, którego szerokość i wysokość są w przybliżeniu dwa razy większe od domyślnych wymiarów, co daje cztery razy więcej pikseli. Większe czynniki zazwyczaj dają ostrzejszy tekst przy powiększaniu lub wysokiej rozdzielczości, ale zwiększają zużycie pamięci i rozmiar pliku. Czynniki poniżej `1` tworzą mniejsze obrazy z mniejszą ilością szczegółów. Używaj równych czynników, aby zachować proporcje akapitu; różne czynniki poziome i pionowe rozciągają wynik niezależnie.

Renderowanie całego kształtu przy użyciu [Shape.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getImage) pozostaje przydatne, gdy wynik musi zawierać wypełnienie, obramowanie lub inne konteksty wizualne kształtu. Dla obrazu tylko z akapitu użyj [Paragraph.getImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Czy mogę całkowicie wyłączyć zawijanie tekstu w ramce tekstowej?**

Tak. Ustaw [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/setwraptext/) aby wyłączyć zawijanie, dzięki czemu linie nie będą łamane przy krawędziach ramki tekstowej.

**Jak mogę uzyskać dokładne granice na slajdzie konkretnego akapitu?**

Użyj [Paragraph.getRect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/getrect/), aby pobrać prostokąt otaczający akapit. [Portion.getRect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/#getRect) podaje granice pojedynczego fragmentu.

**Gdzie kontrolowane jest wyrównanie akapitu (lewe, prawe, wyśrodkowane lub wyjustowane)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/setalignment/) jest ustawieniem na poziomie akapitu i ma zastosowanie do całego akapitu, niezależnie od formatowania poszczególnych fragmentów.

**Czy mogę ustawić język sprawdzania pisowni dla części akapitu?**

Tak. Ustaw [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) dla poszczególnych fragmentów, aby jeden akapit mógł zawierać tekst w wielu językach.