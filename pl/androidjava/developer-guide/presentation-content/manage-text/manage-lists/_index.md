---
title: Zarządzanie listami wypunktowanymi i numerowanymi w prezentacjach na Androidzie
linktitle: Zarządzaj listami
type: docs
weight: 60
url: /pl/androidjava/manage-lists/
keywords:
- punkt
- lista wypunktowana
- lista numerowana
- symbol wypunktowania
- wypunktowanie obrazkowe
- niestandardowe wypunktowanie
- lista wielopoziomowa
- utwórz wypunktowanie
- dodaj wypunktowanie
- dodaj listę
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować listy wypunktowane, obrazkowe, wielopoziomowe i numerowane w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida w języku Java."
---
## **Przegląd**

Aspose.Slides for Android via Java umożliwia tworzenie i formatowanie list wypunktowanych i numerowanych w prezentacjach PowerPoint i OpenDocument. Element listy to akapit, którego ustawienia wypunktowania są kontrolowane przez format akapitu.

Użyj metody [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) aby uzyskać dostęp do ustawień listy na poziomie akapitu. Głównym punktem wejścia jest [IParagraphFormat.getBullet](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), który zwraca obiekt [IBulletFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/). Dzięki temu obiektowi możesz ustawić typ wypunktowania, symbol, obraz, kolor, rozmiar, styl numeracji oraz początkowy numer.

Ten artykuł pokazuje, jak:

- utworzyć listę wypunktowaną z niestandardowym symbolem
- utworzyć wypunktowanie obrazkowe
- utworzyć listę wielopoziomową ustawiając głębokość akapitu
- utworzyć listę numerowaną
- przejrzeć i zmienić formatowanie listy w istniejącej prezentacji

## **Utworzenie listy wypunktowanej**

Aby utworzyć listę wypunktowaną, dodaj akapity do [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/) i ustaw [IBulletFormat.setType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) na [BulletType.Symbol](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/bullettype/). Następnie możesz ustawić [IBulletFormat.setChar](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/#getColor--) oraz [IBulletFormat.setHeight](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) aby kontrolować wygląd wypunktowania.

Poniższy kod Java demonstruje, jak utworzyć listę wypunktowaną na slajdzie:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Symboliczne wypunktowanie](symbol_bullets.png)

## **Utworzenie listy numerowanej**

Używaj list numerowanych, gdy kolejność elementów ma znaczenie. Ustaw [IBulletFormat.setType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) na [BulletType.Numbered](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/bullettype/). Możesz również wybrać format numeracji przy pomocy [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) lub ustawić [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-), gdy lista ma zaczynać się od wartości innej niż 1.

Poniższy kod Java pokazuje, jak utworzyć listę numerowaną na slajdzie:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Numerowane wypunktowanie](numbered_bullets.png)

## **Utworzenie wypunktowania obrazkowego**

Aspose.Slides umożliwia zastąpienie standardowego symbolu wypunktowania obrazem. Wypunktowanie obrazkowe działa najlepiej z prostymi obrazami, które pozostają czytelne w małym rozmiarze, takimi jak ikony lub małe przezroczyste pliki PNG.

{{% alert color="primary" %}}
Idealnie, jeśli planujesz zastąpić zwykły symbol wypunktowania obrazem, najlepiej wybrać prostą grafikę z przezroczystym tłem. Takie obrazy dobrze sprawdzają się jako niestandardowe symbole wypunktowania.
{{% /alert %}}

Aby utworzyć wypunktowanie obrazkowe, dodaj obraz do [Presentation.getImages](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#getImages--) i przypisz zwrócony obiekt [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/) do [IBulletFormat.getPicture](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/#getPicture--). Przed przypisaniem obrazu ustaw [IBulletFormat.setType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) na [BulletType.Picture](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/bullettype/).

Załóżmy, że mamy plik "image.png":

![Obraz dla wypunktowania](picture_for_bullets.png)

Poniższy kod Java pokazuje, jak utworzyć wypunktowanie obrazkowe na slajdzie:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Wypunktowanie obrazkowe](picture_bullets.png)

## **Utworzenie listy wielopoziomowej**

Użyj [IParagraphFormat.setDepth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-), aby umieścić elementy listy na różnych poziomach. Poziom 0 to najwyższy poziom, poziom 1 jest zagnieżdżony pod nim i tak dalej.

Poniższy kod Java pokazuje, jak utworzyć wielopoziomową listę wypunktowaną:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Wielopoziomowa lista](multilevel_list.png)

## **Zmiana istniejącej listy**

Aby zmienić formatowanie listy w istniejącej prezentacji, uzyskaj dostęp do docelowego akapitu i zaktualizuj jego ustawienia [IParagraphFormat.getBullet](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#getBullet--). Te same metody używane do tworzenia list mogą być użyte do przeglądania lub modyfikowania list załadowanych z pliku PPT, PPTX lub ODP.

Poniższy kod Java zmienia pierwszy akapit w ramce tekstowej, aby używał stylu listy numerowanej:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy listy wypunktowane i numerowane mogą być eksportowane do PDF lub obrazów?**

Tak. Aspose.Slides zachowuje formatowanie list, gdy format docelowy obsługuje odpowiednie układy tekstu i funkcje wypunktowania.

**Czy mogę edytować listy w istniejących prezentacjach?**

Tak. Wczytaj prezentację, uzyskaj dostęp do docelowego akapitu, przejrzyj lub zaktualizuj jego ustawienia [IParagraphFormat.getBullet](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), a następnie zapisz prezentację.

**Czy listy mogą zawierać tekst niełaciński?**

Tak. Tekst elementów listy może zawierać znaki Unicode, więc możesz tworzyć listy w wielojęzycznych prezentacjach. Upewnij się, że czcionki użyte w prezentacji obsługują potrzebne znaki.