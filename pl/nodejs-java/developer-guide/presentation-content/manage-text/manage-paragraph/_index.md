---
title: Zarządzaj akapitami tekstu PowerPoint w JavaScript
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
- tekst do HTML
- akapit do HTML
- akapit do obrazu
- tekst do obrazu
- eksportuj akapit
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować akapity, fragmenty, wypunktowania, listy numerowane, wcięcia, treść HTML oraz obrazy akapitów przy użyciu Aspose.Slides dla Node.js via Java."
---
## **Przegląd**

Aspose.Slides for Node.js via Java reprezentuje tekst jako hierarchię ramek tekstowych, akapitów i fragmentów:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) reprezentuje pojemnik tekstu w kształcie i zapewnia dostęp do jego kolekcji akapitów.
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) reprezentuje jeden akapit w ramce tekstowej i zapewnia dostęp do jego fragmentów oraz formatowania na poziomie akapitu.
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) reprezentuje fragment tekstu w akapicie. Każdy fragment może mieć własny tekst i formatowanie na poziomie znaków.

Dlatego akapit może zawierać tekst o różnych czcionkach, kolorach, rozmiarach i innych formatowaniach, wykorzystując wiele fragmentów.

## **Tworzenie i formatowanie akapitów**

Twórz akapity w ramce tekstowej kształtu i używaj fragmentów do formatowania poszczególnych fragmentów tekstu. Ta sekcja pokazuje, jak łączyć wiele fragmentów w każdym akapicie oraz stosować różne kolory, rozmiary czcionek i style.

### **Tworzenie akapitów z wieloma fragmentami**

Poniższy przykład JavaScript tworzy trzy akapity, z których każdy zawiera trzy fragmenty tekstu w kolekcji zwróconej przez [Paragraph.getPortions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getportions/). Ponownie wykorzystuje domyślny akapit i jego pusty fragment, a następnie dodaje pozostałe akapity i fragmenty. Formatowanie jest stosowane przez [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/): pierwszy fragment w każdym akapicie jest czerwony, pogrubiony i ma 15 punktów; drugi jest niebieski, pochylony i ma 18 punktów. Trzeci fragment zachowuje domyślne formatowanie:

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

Organizuj tekst akapitu w listy z symbolami, numerami lub niestandardowymi obrazami. Przykłady w tej sekcji obejmują formatowanie wypunktowań, listy wielopoziomowe i niestandardowe numery początkowe.

### **Tworzenie listy wypunktowanej lub numerowanej**

Wypunktowania i numeracje ułatwiają przeglądanie powiązanych elementów. W Aspose.Slides ustawienia listy definiowane są przez [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/).

Ten przykład JavaScript dodaje wypunktowanie symboliczne i element numerowany do tej samej ramki tekstowej. [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) wybiera typ wypunktowania, podczas gdy [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) podaje symbol, a [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstyle/) wybiera styl numeracji. Oba elementy używają czarnych wypunktowań o wysokości 100 % i wcięciu akapitu 25 punktów:

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

Wypunktowania obrazkowe pozwalają użyć własnego obrazu zamiast symbolu lub numeru.

Ten przykład JavaScript wczytuje `image.png` z katalogu roboczego aplikacji, dodaje obraz do kolekcji obrazów prezentacji jako [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) i używa go jako wypunktowania akapitu. Wywołuje [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) aby użyć wypunktowania obrazkowego i przypisuje obraz poprzez [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/). [BulletFormat.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setheight/) jest ustawione na 100 % aby dopasować rozmiar wypunktowania względem tekstu akapitu:

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

Ustaw [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) aby umieścić akapity na różnych poziomach listy. Najwyższy poziom ma głębokość `0`.

Ten przykład JavaScript przypisuje wartości [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) od 0 do 3 czterem akapitom, tworząc hierarchię w jednej ramce tekstowej. Każdy akapit używa wypunktowania symbolicznego, przy czym [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) przełącza się między okrągłym wypunktowaniem a myślnikiem, aby odróżnić sąsiadujące poziomy:

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

### **Rozpoczęcie numerowanych elementów listy od wartości własnych**

Użyj [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) aby ustawić początkowy numer wyświetlany dla numerowanego akapitu.

Ten przykład JavaScript ustawia [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) na numerację dla trzech akapitów i przypisuje wartości [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) 2, 3 i 7. Wartość początkowa jest konfigurowana osobno dla każdego akapitu, co pozwala pomijać numery:

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

Dostosuj marginesy i wcięcia akapitu, aby kontrolować pozycję pierwszej linii oraz linii złamanych. Możesz także formatować znak końca akapitu oddzielnie od widocznych fragmentów tekstu.

### **Ustawienie wcięcia pierwszej linii**

Użyj metody [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) aby kontrolować wcięcie pierwszej linii akapitu. To ustawienie przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Wartość dodatnia przesuwa pierwszą linię w prawo, podczas gdy pozostałe linie pozostają wyrównane do ciała akapitu.

Użyj [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) gdy potrzebujesz przesunąć cały akapit. Użyj [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) gdy potrzebujesz przesunąć tylko pierwszą linię.

Poniższy przykład nadaje trzem akapitom identyczny [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) = 20 punktów oraz wartości [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) = 0, 20 i 40 punktów. Pierwsze linie zaczynają się w coraz większych odstępach, podczas gdy linie złamane zachowują ten sam lewy margines:

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

Wcięcie wiszące to układ akapitu, w którym pierwsza linia zaczyna się po lewej stronie pozostałych linii. W Aspose.Slides tworzysz ten efekt metodą [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/). Ustaw wcięcie na wartość ujemną, aby przesunąć pierwszą linię w lewo względem ciała akapitu.

W praktyce [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) definiuje lewą pozycję ciała akapitu, a [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) określa pozycję pierwszej linii względem tego marginesu. Aby utworzyć wcięcie wiszące, ustaw dodatni lewy margines i ujemne wcięcie.

To formatowanie jest przydatne w bibliografiach, odnośnikach, hasłach słownika i innych akapitach, gdzie linie złamane muszą być wyrównane pod ciałem akapitu, a nie pod pierwszym znakiem pierwszej linii.

Poniższy przykład JavaScript łączy wartości [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) = 40 i 60 punktów z wartościami [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) = -20 i -30 punktów. W każdym akapicie pierwsza linia zaczyna się po lewej stronie linii złamanych; drugi akapit ma głębsze wcięcie wiszące:

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

### **Ustawienie właściwości końcowego uruchomienia akapitu**

Metoda [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) kontroluje formatowanie znaku końca akapitu. Poniższy przykład tworzy [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) z [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) = 48 punktów oraz [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) ustawioną na Times New Roman. Przypisuje ten format do znaku końcowego drugiego akapitu, pozostawiając niezmienione widoczne fragmenty tekstu:

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

## **Zliczanie renderowanych linii**

Dla reguł akapitu wpływających na automatyczne zawijanie i interpunkcję przy końcach linii, zobacz [Kontrola łamania linii](/slides/pl/nodejs-java/text-formatting/#control-line-breaking) i [Kontrola interpunkcji wiszącej](/slides/pl/nodejs-java/text-formatting/#control-hanging-punctuation).

Użyj [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) aby policzyć linie zajmowane przez akapit po rozmieszczeniu tekstu, w tym automatyczne zawijanie. Jest to przydatne przy sprawdzaniu długości tekstu i układu w szablonach prezentacji.

Akapit jest jednym elementem w [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/getparagraphs/), i może zajmować kilka renderowanych linii. Jawne znakowanie nowej linii w akapicie wymusza nową linię bez tworzenia kolejnego akapitu. Automatyczne zawijanie tworzy linie na podstawie dostępnej szerokości, nie wstawiając jawnych znaków końca linii do tekstu. Dlatego liczenie akapitów lub znaków nowej linii nie daje rzeczywistej liczby renderowanych linii.

Poniższy przykład tworzy kształt tekstowy, liczy jego linie, zwęża kształt, a następnie zastępuje tekst krótszym ciągiem. Przykład włącza zawijanie przy pomocy [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) i wyłącza autofit przy pomocy [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setautofittype/), tak aby szerokość kształtu kontrolowała zawijanie bez automatycznego zmniejszania tekstu lub zmiany rozmiaru kształtu. Każdy pomiar używa [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount). Wymiary kształtu podawane są w punktach. Na końcu przykład dodaje kolejny akapit i sumuje liczbę linii w całej ramce tekstowej.

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

Przy podanym tekście i wymiarach, zwężenie kształtu zwiększa liczbę linii, natomiast zastąpienie tekstu krótkim ciągiem ją zmniejsza. Dokładne liczby mogą się różnić w zależności od dostępności i podstawiania czcionek, rozmiaru czcionki, marginesów, wcięć, zawijania i ustawień autofitu. Używaj czcionek i ustawień układu przeznaczonych dla docelowego środowiska przy weryfikacji szablonu.

Sam licznik linii nie decyduje o tym, czy tekst wykracza poza pojemnik. Ważne są także dostępna wysokość, wysokość linii, odstępy między akapitami i liniami oraz zachowanie autofitu; nawet pojedyncza linia może przekroczyć dostępną szerokość, gdy zawijanie jest wyłączone.

## **Import i eksport treści akapitu**

Użyj HTML, aby wprowadzić tekst do prezentacji lub wyeksportować istniejące akapity do wykorzystania poza nią. Ta sekcja pokazuje także, jak renderować pojedyncze akapity jako obrazy, w tym akapity w komórkach tabel.

### **Importowanie tekstu HTML do akapitów**

Użyj [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) aby przekształcić znacznik HTML w akapity i fragmenty w ramce tekstowej.

Ten przykład JavaScript odczytuje HTML z `file.html` w katalogu roboczym aplikacji i przekazuje znacznik do [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/). Czyści domyślny akapit ramki tekstowej, tak aby ramka zawierała wyłącznie zaimportowaną zawartość. Prostokątny kształt pozostawia margines 10 punktów po każdej stronie slajdu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = fs.readFileSync("file.html", "utf8");
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Eksport tekstu akapitu do HTML**

Użyj [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) aby wyeksportować wybrany zakres akapitów jako HTML. Przy ponownym wykorzystaniu tekstu prezentacji na stronie internetowej możesz chcieć zachować lokalne wyróżnienia bez przenoszenia stylów czcionki, rozmiaru czy stylu pola tekstowego. Ustaw [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/settextinheritancelimit/) aby kontrolować, jak daleko eksporter podąża za dziedziczeniem formatowania.

Pobierz [przykładową prezentację](text-inheritance.pptx) i umieść ją w katalogu roboczym aplikacji. Jej pierwszy slajd zawiera jeden kształt tekstowy z tekstem „Inherited text; explicit red 18pt”. Dane wejściowe celowo używają kilku poziomów formatowania:

- Domyślny styl tekstu prezentacji dostarcza czcionkę Calibri i rozmiar 28 pt.
- Styl tekstu pierwszego poziomu ramki tekstowej dostarcza niebieski tekst i kursywę.
- Akapit jawnie ustawia pogrubiony tekst.
- Drugi fragment, „explicit red 18pt”, jawnie ustawia czerwony tekst i rozmiar 18 pt.

Poniższy kompletny przykład eksportuje te same akapity trzykrotnie. Przekazuje [TextToHtmlConversionOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/) do metody eksportu i zapisuje każdy wynik jako osobny plik HTML w kodowaniu UTF‑8:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("text-inheritance.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();

            const modes = [aspose.slides.TextInheritanceLimit.All, aspose.slides.TextInheritanceLimit.TextBox, aspose.slides.TextInheritanceLimit.ParagraphOnly];
            const fileNames = ["All.html", "TextBox.html", "ParagraphOnly.html"];

            for (let i = 0; i < modes.length; i++) {
                const options = new aspose.slides.TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                const html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                fs.writeFileSync(fileNames[i], html, "utf8");
            }
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

Wygenerowany HTML zawiera następujący CSS dla pierwszego fragmentu, „Inherited text; ”. Tabela wymienia odpowiednie deklaracje; pozostałe wygenerowane właściwości zostały pominięte dla przejrzystości.

| Wyjście | Odpowiedni CSS dla pierwszego fragmentu | Wygląd |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Niebieski, pogrubiony, pochylony tekst o rozmiarze 28 pt w Calibri, jeśli ta czcionka jest dostępna. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Niebieski, pogrubiony, pochylony tekst; otaczająca strona lub przeglądarka dostarcza rodzinę czcionki i rozmiar. |
| `ParagraphOnly.html` | `font-weight:bold` | Pogrubiony tekst; otaczająca strona lub przeglądarka dostarcza rodzinę czcionki, rozmiar, kolor i styl kursywy. |

Drugi fragment zachowuje `color:#ff0000`, `font-size:18pt` i `font-weight:bold` we wszystkich trzech wynikach. Zachowuje także kursywę w `All` i `TextBox`, ale nie w `ParagraphOnly`. Ograniczenie dziedziczenia nie usuwa więc formatowania przypisanego explicite do akapitu lub fragmentu.

Otwórz pliki w tej samej przeglądarce, aby je porównać. W dwóch trybach ograniczonych pominięte właściwości CSS są rozwiązywane przez style strony docelowej lub domyślne przeglądarki, więc ostateczny wygląd zależy od miejsca użycia HTML.

### **Renderowanie akapitu jako obrazu**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) renderuje pojedynczy akapit bezpośrednio i zwraca [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/). Zapisz wynik do pliku lub strumienia przy pomocy [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). Nie musisz renderować całego kształtu ani ręcznie przycinać bitmapy.

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) może zwrócić `null`, jeśli akapit nie zostanie znaleziony w kolekcji nadrzędnej, nie ma prawidłowych granic renderowania lub nie może być renderowany. Sprawdź wynik przed zapisem i zwolnij zwrócony obraz po użyciu.

#### **Renderowanie akapitu w domyślnej skali**

Przykład tworzy prezentację z jednym slajdem, którego pierwszy kształt jest polem tekstowym zawierającym trzy akapity.

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

Poniższy przykład wybiera drugi akapit o indeksie 1 i wywołuje [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) bez parametrów skali. Sprawdza, czy kształt zawiera wymagany akapit i czy renderowanie zwróciło obraz przed wywołaniem [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) w formacie PNG. W bloku `finally` obraz jest zwalniany po użyciu.

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

Użyj przeciążenia [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) przyjmującego parametry `scaleX` i `scaleY`, aby ustawić czynniki skali poziomej i pionowej. Poniższy przykład tworzy tabelę, renderuje akapit w jej pierwszej komórce przy dwukrotności domyślnej szerokości i wysokości oraz zapisuje wynik jako obraz PNG.

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

Współczynnik skali `1` utrzymuje dany oś w domyślnym rozmiarze pikseli. Na przykład `2` dla obu współczynników tworzy obraz, którego szerokość i wysokość są w przybliżeniu dwa razy większe od domyślnych wymiarów, co daje cztery razy więcej pikseli. Wyższe współczynniki zazwyczaj dają ostrzejszy tekst przy powiększaniu lub wyjściu wysokiej rozdzielczości, ale zwiększają także zużycie pamięci i rozmiar pliku. Współczynniki poniżej `1` tworzą mniejsze obrazy z mniejszą szczegółowością. Używaj równych współczynników, aby zachować proporcje akapitu; różne współczynniki poziome i pionowe rozciągają obraz niezależnie.

Renderowanie całego kształtu metodą [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) pozostaje przydatne, gdy wyjście musi obejmować wypełnienie, obramowanie lub inny kontekst wizualny kształtu. Dla obrazu wyłącznie akapitu użyj [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage).

## **FAQ**

**Czy mogę całkowicie wyłączyć zawijanie linii w ramce tekstowej?**

Tak. Ustaw [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) aby wyłączyć zawijanie, dzięki czemu linie nie będą łamane przy krawędziach ramki tekstowej.

**Jak mogę uzyskać dokładne granice akapitu na slajdzie?**

Użyj [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/) aby pobrać prostokąt graniczy akapitu. [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getrect/) zapewnia granice pojedynczego fragmentu.

**Gdzie kontrolowane jest wyrównanie akapitu (lewe, prawe, wyśrodkowane lub justowane)?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) jest ustawieniem na poziomie akapitu i obowiązuje cały akapit, niezależnie od formatowania poszczególnych fragmentów.

Aby pionowo wyrównać fragmenty o różnych rozmiarach czcionki w każdej linii, zobacz [Align Fonts Within a Line](/slides/pl/nodejs-java/text-formatting/#align-fonts-within-a-line).

**Czy mogę ustawić język korekty dla części akapitu?**

Tak. Ustaw [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) dla poszczególnych fragmentów, aby jeden akapit mógł zawierać tekst w wielu językach.