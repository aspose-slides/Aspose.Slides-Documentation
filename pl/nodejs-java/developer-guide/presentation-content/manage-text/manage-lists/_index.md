---
title: Zarządzanie listami wypunktowanymi i numerowanymi w prezentacjach przy użyciu JavaScript
linktitle: Zarządzaj listami
type: docs
weight: 60
url: /pl/nodejs-java/manage-lists/
keywords:
- punktor
- lista wypunktowana
- lista numerowana
- symbol punktora
- punktor graficzny
- niestandardowy punktor
- lista wielopoziomowa
- utwórz punktor
- dodaj punktor
- dodaj listę
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować listy wypunktowane, graficzne, wielopoziomowe oraz numerowane w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js za pośrednictwem Java."
---
## **Przegląd**

Aspose.Slides dla Node.js za pośrednictwem Java umożliwia tworzenie i formatowanie list wypunktowanych oraz numerowanych w prezentacjach PowerPoint i OpenDocument. Element listy jest akapitem, którego ustawienia punktora są kontrolowane przez formatowanie akapitu.

Użyj klasy [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) aby uzyskać dostęp do ustawień listy na poziomie akapitu. Głównym punktem wejścia jest `Paragraph.getParagraphFormat().getBullet()`, który zwraca obiekt [BulletFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bulletformat/). Dzięki temu obiektowi możesz ustawić typ punktora, symbol, obraz, kolor, rozmiar, styl numeracji oraz numer początkowy.

Ten artykuł pokazuje, jak:

- utworzyć listę wypunktowaną z niestandardowym symbolem
- utworzyć punktor graficzny
- utworzyć listę wielopoziomową, ustawiając głębokość akapitu
- utworzyć listę numerowaną
- sprawdzić i zmienić formatowanie listy w istniejącej prezentacji

## **Utworzyć listę wypunktowaną**

Aby utworzyć listę wypunktowaną, dodaj obiekty [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) do [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) i ustaw `BulletFormat.setType` na [BulletType.Symbol](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bullettype/). Następnie możesz ustawić `BulletFormat.setChar`, `BulletFormat.getColor` i `BulletFormat.setHeight`, aby kontrolować wygląd punktora.

Poniższy kod JavaScript demonstruje, jak utworzyć listę wypunktowaną na slajdzie:

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

Wynik:

![Kropki symboliczne](symbol_bullets.png)

## **Utworzyć listę numerowaną**

Używaj list numerowanych, gdy kolejność elementów ma znaczenie. Ustaw `BulletFormat.setType` na [BulletType.Numbered](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bullettype/). Możesz także wybrać format numeracji za pomocą `BulletFormat.setNumberedBulletStyle` lub ustawić `BulletFormat.setNumberedBulletStartWith`, gdy lista ma zaczynać się od wartości innej niż 1.

Poniższy kod JavaScript pokazuje, jak utworzyć listę numerowaną na slajdzie:

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

Wynik:

![Kropki numerowane](numbered_bullets.png)

## **Utworzyć punktor graficzny**

Aspose.Slides pozwala zastąpić standardowy symbol punktora obrazem. Punktory graficzne działają najlepiej z prostymi grafikami, które pozostają czytelne w małym rozmiarze, takimi jak ikony lub małe przeźroczyste pliki PNG.

{{% alert color="primary" %}}
Ideálně, jeśli planujesz zastąpić standardowy symbol punktora obrazem, najlepiej wybrać prostą grafikę z przeźroczystym tłem. Takie obrazy dobrze sprawdzają się jako niestandardowe symbole punktora.

Pamiętaj, że obraz zostanie przeskalowany do bardzo małego rozmiaru. Z tego powodu zdecydowanie zalecamy wybranie obrazu, który pozostaje wyraźny i wizualnie efektywny, gdy jest używany jako punktor na liście.
{{% /alert %}}

Aby utworzyć punktor graficzny, dodaj obraz do [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) przy pomocy `Presentation.getImages().addImage` i przypisz zwrócony obiekt [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) do `BulletFormat.getPicture().setImage`. Ustaw `BulletFormat.setType` na [BulletType.Picture](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/bullettype/) przed przypisaniem obrazu.

Załóżmy, że mamy plik "image.png":

![Obraz dla punktorów](picture_for_bullets.png)

Poniższy kod JavaScript pokazuje, jak utworzyć punktory graficzne na slajdzie:

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

Wynik:

![Kropki graficzne](picture_bullets.png)

## **Utworzyć listę wielopoziomową**

Użyj `ParagraphFormat.setDepth`, aby umieścić elementy listy na różnych poziomach. Poziom 0 to najwyższy poziom, poziom 1 jest zagnieżdżony pod nim i tak dalej.

Poniższy kod JavaScript pokazuje, jak utworzyć wielopoziomową listę wypunktowaną:

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

Wynik:

![Lista wielopoziomowa](multilevel_list.png)

## **Zmiana istniejącej listy**

Aby zmienić formatowanie listy w istniejącej prezentacji, uzyskaj dostęp do docelowego akapitu i zaktualizuj jego ustawienia `ParagraphFormat.getBullet`. Te same właściwości używane do tworzenia list mogą być użyte do sprawdzania lub modyfikacji list załadowanych z pliku PPT, PPTX lub ODP.

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

## **FAQ**

**Czy listy wypunktowane i numerowane mogą być eksportowane do PDF lub obrazów?**

Tak. Aspose.Slides zachowuje formatowanie list, gdy format docelowy obsługuje odpowiednie rozmieszczenie tekstu i funkcje punktora.

**Czy mogę edytować listy w istniejących prezentacjach?**

Tak. Załaduj prezentację, uzyskaj dostęp do docelowego akapitu, sprawdź lub zaktualizuj jego ustawienia `ParagraphFormat.getBullet` i zapisz prezentację.

**Czy listy mogą zawierać tekst niełaciński?**

Tak. Tekst elementu listy może zawierać znaki Unicode, więc możesz tworzyć listy w wielojęzycznych prezentacjach. Upewnij się, że użyte w prezentacji czcionki obsługują potrzebne znaki.