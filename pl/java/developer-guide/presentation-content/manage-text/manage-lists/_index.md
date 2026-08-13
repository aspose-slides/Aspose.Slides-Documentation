---
title: Zarządzanie listami wypunktowanymi i numerowanymi w prezentacjach w języku Java
linktitle: Zarządzaj listami
type: docs
weight: 60
url: /pl/java/manage-lists/
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
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować listy wypunktowane, graficzne, wielopoziomowe i numerowane w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla języka Java."
---
## **Przegląd**

Aspose.Slides dla języka Java umożliwia tworzenie i formatowanie list wypunktowanych oraz numerowanych w prezentacjach PowerPoint i OpenDocument. Element listy jest akapitem, którego ustawienia punktora są kontrolowane przez formatowanie akapitu.

Użyj metody [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iparagraph/#getParagraphFormat--) aby uzyskać dostęp do ustawień listy na poziomie akapitu. Głównym punktem wejścia jest [IParagraphFormat.getBullet](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iparagraphformat/#getBullet--), które zwraca obiekt [IBulletFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides.ibulletformat/). Dzięki temu obiektowi możesz ustawić typ punktora, symbol, obraz, kolor, rozmiar, styl numeracji oraz numer początkowy.

Ten artykuł pokazuje, jak:

- utworzyć listę wypunktowaną ze własnym symbolem
- utworzyć punktor graficzny
- utworzyć listę wielopoziomową, ustawiając głębokość akapitu
- utworzyć listę numerowaną
- sprawdzić i zmienić formatowanie listy w istniejącej prezentacji

## **Utworzenie listy wypunktowanej**

Aby utworzyć listę wypunktowaną, dodaj obiekty [IParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iparagraph/) do [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides.itextframe/) i ustaw [IBulletFormat.setType](https://reference.aspose.com/slides/pl/java/com.aspose.slides.ibulletformat/#setType-byte-) na [BulletType.Symbol](https://reference.aspose.com/slides/pl/java/com.aspose.slides.bullettype/#Symbol). Następnie możesz ustawić [IBulletFormat.setChar](https://reference.aspose.com/slides/pl/java/com.aspose.slides.ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides.ibulletformat/#getColor--) oraz [IBulletFormat.setHeight](https://reference.aspose.com/slides/pl/java/com.aspose.slides.ibulletformat/#setHeight-float-), aby kontrolować wygląd punktora.

Poniższy kod Java pokazuje, jak utworzyć listę wypunktowaną na slajdzie:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Symbole wypunktowane](symbol_bullets.png)

## **Utworzenie listy numerowanej**

Używaj list numerowanych, gdy kolejność elementów ma znaczenie. Ustaw [IBulletFormat.setType](https://reference.aspose.com/slides/pl/java/com.aspose.slides.ibulletformat/#setType-byte-) na [BulletType.Numbered](https://reference.aspose.com/slides/pl/java/com.aspose.slides.bullettype/#Numbered). Możesz także wybrać format numeracji przy pomocy [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/pl/java/com.aspose.slides.ibulletformat/#setNumberedBulletStyle-byte-) lub ustawić [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/pl/java/com.aspose.slides.ibulletformat/#setNumberedBulletStartWith-short-), gdy lista ma zaczynać się od wartości innej niż 1.

Poniższy kod Java pokazuje, jak utworzyć listę numerowaną na slajdzie:

```java
import com.aspose.slides.*;

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

![Numerowane wypunktowania](numbered_bullets.png)

## **Utworzenie punktora graficznego**

Aspose.Slides pozwala zamienić zwykły symbol punktora na obraz. Punktory graficzne najlepiej sprawdzają się przy prostych obrazach, które pozostają czytelne w małym rozmiarze, takich jak ikony lub małe przezroczyste pliki PNG.

{{% alert color="info" %}}
Idealnie, jeśli planujesz zamienić zwykły symbol punktora na obraz, wybierz prostą grafikę z przezroczystym tłem. Takie obrazy dobrze działają jako własne symbole punktora.
{{% /alert %}}

Aby utworzyć punktor graficzny, dodaj obraz do [Presentation.getImages](https://reference.aspose.com/slides/pl/java/com.aspose.slides.presentation/#getImages--) i przypisz zwrócony obiekt obrazu do [IBulletFormat.getPicture](https://reference.aspose.com/slides/pl/java/com.aspose.slides.ibulletformat/#getPicture--). Ustaw [IBulletFormat.setType](https://reference.aspose.com/slides/pl/java/com.aspose.slides.ibulletformat/#setType-byte-) na [BulletType.Picture](https://reference.aspose.com/slides/pl/java/com.aspose.slides.bullettype/#Picture) przed przypisaniem obrazu.

Załóżmy, że mamy plik "image.png":

![Obraz dla punktorów](picture_for_bullets.png)

Poniższy kod Java pokazuje, jak utworzyć graficzne punkty na slajdzie:

```java
import com.aspose.slides.*;

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

![Graficzne punkty](picture_bullets.png)

## **Utworzenie listy wielopoziomowej**

Użyj [IParagraphFormat.setDepth](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iparagraphformat/#setDepth-short-) aby umieścić elementy listy na różnych poziomach. Poziom 0 to najwyższy poziom, poziom 1 jest zagnieżdżony pod nim itd.

Poniższy kod Java pokazuje, jak utworzyć wielopoziomową listę wypunktowaną:

```java
import com.aspose.slides.*;

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

![Lista wielopoziomowa](multilevel_list.png)

## **Zmiana istniejącej listy**

Aby zmienić formatowanie listy w istniejącej prezentacji, uzyskaj dostęp do docelowego akapitu i zaktualizuj jego ustawienia [IParagraphFormat.getBullet](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iparagraphformat/#getBullet--). Te same właściwości użyte do tworzenia list można wykorzystać do sprawdzania lub modyfikowania list załadowanych z pliku PPT, PPTX lub ODP.

Poniższy kod Java zmienia pierwszy akapit w ramce tekstowej, aby używał stylu listy numerowanej:

```java
import com.aspose.slides.*;

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

### Czy listy wypunktowane i numerowane można eksportować do PDF lub obrazów?

Tak. Aspose.Slides zachowuje formatowanie list, gdy format docelowy obsługuje odpowiednie układy tekstu i funkcje punktora.

### Czy mogę edytować listy w istniejących prezentacjach?

Tak. Wczytaj prezentację, uzyskaj dostęp do docelowego akapitu, sprawdź lub zaktualizuj jego ustawienia [IParagraphFormat.getBullet](https://reference.aspose.com/slides/pl/java/com.aspose.slides.iparagraphformat/#getBullet--), a następnie zapisz prezentację.

### Czy listy mogą zawierać tekst niełaciński?

Tak. Tekst elementów listy może zawierać znaki Unicode, więc możesz tworzyć listy w wielojęzykowych prezentacjach. Upewnij się, że czcionki użyte w prezentacji obsługują potrzebne znaki.