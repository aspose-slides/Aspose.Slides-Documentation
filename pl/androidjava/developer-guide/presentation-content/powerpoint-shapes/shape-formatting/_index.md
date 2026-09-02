---
title: Formatowanie kształtów PowerPoint na Androidzie
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/androidjava/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- efekt szkicu
- linia szkicu kształtu
- formatowanie stylu połączenia
- wypełnienie gradientowe
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- jednokolorowe wypełnienie
- przezroczystość kształtu
- renderowanie kształtu czarno-białe
- renderowanie kształtu w odcieniach szarości
- obracanie kształtu
- efekt 3D bevel
- efekt 3D obrotu
- resetowanie formatowania
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint na Androidzie przy użyciu Aspose.Slides — ustawiaj style wypełnień, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz formatować je, modyfikując lub stosując efekty do ich konturów. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące sposób wypełniania ich wnętrz.

![formatowanie‑kształtu‑w‑PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java zapewnia interfejsy i metody, które umożliwiają formatowanie kształtów przy użyciu tych samych opcji dostępnych w programie PowerPoint.

## **Formatowanie linii**

Używając Aspose.Slides, możesz określić niestandardowy styl linii dla kształtu. Poniższe kroki opisują procedurę:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu według jego indeksu.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
4. Ustaw [line style](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/linestyle/) kształtu.
5. Ustaw szerokość linii.
6. Ustaw [dash style](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/linedashstyle/) linii.
7. Ustaw kolor linii dla kształtu.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod demonstruje, jak sformatować prostokąt `AutoShape`:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Prostokąt.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Usuń wypełnienie z prostokątnego kształtu, aby widoczne były tylko jego linie.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Zastosuj formatowanie do linii prostokąta.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Ustaw kolor linii prostokąta.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Zapisz plik PPTX na dysk.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Sformatowane linie w prezentacji](formatted-lines.png)

## **Zastosuj efekty szkicu do linii kształtu**

Efekt szkicu sprawia, że linia kształtu wygląda na odręczną. Użyj [IShape.getLineFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/) aby uzyskać dostęp do ustawień linii, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilineformat/) aby uzyskać dostęp do ustawień szkicu oraz [ISketchFormat.setSketchType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isketchformat/) aby wybrać wartość z wyliczenia [LineSketchType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/linesketchtype/).

Poniższy kod w Javie pokazuje, jak zastosować efekt [LineSketchType.Curved](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/linesketchtype/), odczytać wyraźnie przypisaną wartość oraz usunąć efekt przy użyciu [LineSketchType.None](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Uzyskaj dostęp do formatu linii kształtu oraz jego formatu szkicu.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Zastosuj efekt szkicu.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Odczytaj efekt szkicu przypisany bezpośrednio do kształtu.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Usuń efekt szkicu.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Wartość zwracana przez [ISketchFormat.getSketchType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isketchformat/) reprezentuje ustawienie przypisane bezpośrednio do kształtu. Jeśli formatowanie linii może być dziedziczone z motywu, slajdu głównego lub slajdu układu, użyj [ILineFormat.getEffective](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilineformat/), uzyskaj dostęp do [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilineformateffectivedata/), i odczytaj [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isketchformateffectivedata/). Wartość efektywna odzwierciedla formatowanie faktycznie zastosowane po rozwiązaniu dziedziczenia:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formatowanie stylów połączeń**

Oto trzy dostępne opcje typu połączenia:

* Zaokrąglony
* Kątowy
* Fazowany

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (np. w rogu kształtu), używa ustawienia **Round**. Jednak przy rysowaniu kształtu o ostrych kątach możesz preferować opcję **Miter**.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

Poniższy kod w Javie demonstruje, jak trzy prostokąty (jak na powyższym obrazku) zostały utworzone przy użyciu ustawień typu połączenia Miter, Bevel i Round:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj trzy automatyczne kształty typu Prostokąt.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Ustaw kolor wypełnienia dla każdego prostokątnego kształtu.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Ustaw szerokość linii.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Ustaw kolor linii dla każdego prostokąta.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Ustaw styl łączenia.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Dodaj tekst do każdego prostokąta.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Zapisz plik PPTX na dysk.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wypełnienie gradientowe**

W programie PowerPoint wypełnienie gradientowe jest opcją formatowania, która umożliwia zastosowanie ciągłego przejścia kolorów w kształcie. Na przykład możesz zastosować dwa lub więcej kolorów w taki sposób, że jeden stopniowo przechodzi w drugi.

Oto jak zastosować wypełnienie gradientowe do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu według jego indeksu.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
4. Ustaw [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) kształtu na `Gradient`.
5. Dodaj dwa wybrane kolory z określonymi pozycjami, używając metod `add` kolekcji zatrzymań gradientu udostępnionej przez interfejs [IGradientFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/igradientformat/).
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Elipsa.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Zastosuj formatowanie gradientowe do elipsy.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Ustaw kierunek gradientu.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Dodaj dwa przystanki gradientu.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Zapisz plik PPTX na dysk.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

## **Wypełnienie wzorem**

W programie PowerPoint wypełnienie wzorem jest opcją formatowania, która pozwala zastosować dwukolorowy wzór — np. kropki, paski, krzyżowe kreskowanie lub kratkę — do kształtu. Możesz wybrać własne kolory dla pierwszego planu i tła wzoru.

Aspose.Slides udostępnia ponad 45 wstępnie zdefiniowanych stylów wzorów, które możesz zastosować do kształtów, aby zwiększyć atrakcyjność wizualną prezentacji. Nawet po wybraniu wstępnego wzoru możesz nadal określić dokładne kolory, które ma on używać.

Oto jak zastosować wypełnienie wzorem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu według jego indeksu.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
4. Ustaw [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) kształtu na `Pattern`.
5. Wybierz styl wzoru spośród wstępnie zdefiniowanych opcji.
6. Ustaw [Background Color](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/patternformat/#getBackColor--) wzoru.
7. Ustaw [Foreground Color](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/patternformat/#getForeColor--) wzoru.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Prostokąt.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Ustaw styl wzoru.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Ustaw kolory tła i pierwszego planu wzoru.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Zapisz plik PPTX na dysk.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Wypełnienie obrazem**

W programie PowerPoint wypełnienie obrazem jest opcją formatowania, która pozwala wstawić obraz wewnątrz kształtu — efektywnie używając obrazu jako tła kształtu.

Oto jak użyć Aspose.Slides do zastosowania wypełnienia obrazem w kształcie:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu według jego indeksu.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
4. Ustaw [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) kształtu na `Picture`.
5. Ustaw tryb wypełnienia obrazu na `Tile` (lub inny preferowany tryb).
6. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/) z obrazu, który chcesz użyć.
7. Przekaż obraz do metody `ISlidesPicture.setImage`.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Załóżmy, że mamy plik „lotus.png” z następującym obrazem:

![Obraz lotosu](lotus.png)

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Prostokąt.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ustaw typ wypełnienia na Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Ustaw tryb wypełnienia obrazem.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Wczytaj obraz i dodaj go do zasobów prezentacji.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Ustaw obraz.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Zapisz plik PPTX na dysk.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Kafelkowanie obrazu jako tekstura**

Jeśli chcesz ustawić obraz kafelkowany jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod interfejsu [IPictureFillFormat] i klasy [PictureFillFormat]:

- [setPictureFillMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ustawia tryb wypełnienia obrazu — `Tile` lub `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Określa wyrównanie kafelków w obrębie kształtu.
- [setTileFlip](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Kontroluje, czy kafelek jest odbijany w poziomie, pionie, czy w obu kierunkach.
- [setTileOffsetX](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ustawia poziomy odstęp kafelka (w punktach) od początkowego punktu kształtu.
- [setTileOffsetY](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ustawia pionowy odstęp kafelka (w punktach) od początkowego punktu kształtu.
- [setTileScaleX](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definiuje poziomą skalę kafelka jako procent.
- [setTileScaleY](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definiuje pionową skalę kafelka jako procent.

Poniższy przykład kodu pokazuje, jak dodać prostokątny kształt z kafelkowanym wypełnieniem obrazem i skonfigurować opcje kafelkowania:

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt prostokąta.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Ustaw typ wypełnienia kształtu na Picture.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Wczytaj obraz i dodaj go do zasobów prezentacji.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Przypisz obraz do kształtu.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Skonfiguruj tryb wypełnienia obrazem i właściwości kafelkowania.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Zapisz plik PPTX na dysk.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Opcje kafelkowania](tile-options.png)

## **Jednokolorowe wypełnienie**

W programie PowerPoint jednokolorowe wypełnienie jest opcją formatowania, która wypełnia kształt jednym, jednolitym kolorem. Ten jednolity kolor tła jest stosowany bez żadnych gradientów, tekstur ani wzorów.

Aby zastosować jednokolorowe wypełnienie do kształtu przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu według jego indeksu.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
4. Ustaw [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) kształtu na `Solid`.
5. Przypisz wybrany kolor wypełnienia do kształtu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Prostokąt.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Ustaw kolor wypełnienia.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Zapisz plik PPTX na dysk.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Kształt z jednokolorowym wypełnieniem](solid-color-fill.png)

## **Ustaw przezroczystość**

W programie PowerPoint, gdy zastosujesz jednokolorowe, gradientowe, obrazowe lub teksturowane wypełnienie do kształtów, możesz także ustawić poziom przezroczystości, aby kontrolować nieprzezroczystość wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt jest bardziej przejrzysty, umożliwiając częściowe widzenie tła lub ukrytych obiektów.

Aspose.Slides pozwala ustawić poziom przezroczystości, regulując wartość alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu według jego indeksu.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
4. Ustaw [FillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/filltype/) na `Solid`.
5. Użyj `Color`, aby zdefiniować kolor z przezroczystością (składnik `alpha` kontroluje przezroczystość).
6. Zapisz prezentację.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt prostokątny wypełniony.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dodaj przezroczysty prostokątny kształt automatyczny nad wypełnionym kształtem.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Zapisz plik PPTX na dysk.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Przezroczysty kształt](shape-transparency.png)

## **Obracanie kształtów**

Aspose.Slides pozwala obracać kształty w prezentacjach PowerPoint. Może to być przydatne przy pozycjonowaniu elementów wizualnych z określonym wyrównaniem lub wymaganiami projektowymi.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu według jego indeksu.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
4. Ustaw właściwość obrotu kształtu na żądany kąt.
5. Zapisz prezentację.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Pobierz pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj automatyczny kształt typu Prostokąt.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Obróć kształt o 5 stopni.
    shape.setRotation(5);

    // Zapisz plik PPTX na dysk.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Obrót kształtu](shape-rotation.png)

## **Dodaj efekty 3D Bevel**

Aspose.Slides umożliwia zastosowanie efektów 3D Bevel do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/threedformat/).

Aby dodać efekty 3D Bevel do kształtu, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu według jego indeksu.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
4. Skonfiguruj [ThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/threedformat/) kształtu, definiując ustawienia bevel.
5. Zapisz prezentację.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Utwórz instancję klasy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj kształt do slajdu.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Ustaw właściwości ThreeDFormat kształtu.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Zapisz prezentację jako plik PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Efekt 3D Bevel](3D-bevel-effect.png)

## **Dodaj efekty 3D Obracania**

Aspose.Slides umożliwia zastosowanie efektów 3D obrotu do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/threedformat/).

Aby zastosować 3D obrót do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu według jego indeksu.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) do slajdu.
4. Użyj [setCameraType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icamera/#setCameraType-int-) i [setLightType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) aby określić obrót 3D.
5. Zapisz prezentację.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Zapisz prezentację jako plik PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Efekt 3D obrotu](3D-rotation-effect.png)

## **Kontrola renderowania czarno-białego dla kształtów**

Metoda [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) określa, jak indywidualny kształt jest renderowany, gdy prezentacja jest wyświetlana lub przetwarzana w trybie czarno‑białym. Nie włącza ona samodzielnie trybu czarno‑białego i nie zmienia wypełnienia, linii ani innych formatowań kształtu w normalnym trybie kolorowym.

Użyj wartości z klasy [BlackWhiteMode](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/blackwhitemode/) aby wybrać pożądane zachowanie. Na przykład `Automatic` pozwala aplikacji renderującej wybrać konwersję, `Gray` i `LightGray` używają szarości, `BlackWhite` używa tylko czerni i bieli, `Black` i `White` wymuszają pojedynczy kolor, `Color` zachowuje normalne kolorowanie, a `Hidden` pomija kształt w trybie czarno‑białym. `NotDefined` oznacza, że nie przypisano trybu na poziomie kształtu.

Poniższy kod Java tworzy kolorowy kształt i sprawia, że w trybie wyświetlania czarno‑białego pojawia się szary:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Zachowaj pomarańczowe wypełnienie w trybie kolorowym, ale renderuj kształt w odcieniach szarości w trybie czarno-białym.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

W normalnym trybie kolorowym prostokąt zachowuje pomarańczowe wypełnienie. W przepływie pracy wyświetlania czarno‑białego używa szarego koloru, ponieważ jego tryb jest ustawiony na `Gray`. Dzięki temu możesz zachować slajd w pełnym kolorze, definiując jednocześnie odrębny wygląd dla drukowania, podglądu lub innych przepływów, które respektują ustawienia wyświetlania czarno‑białego prezentacji.

## **Resetowanie formatowania**

Poniższy kod w Javie pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z symbolami zastępczymi na [LayoutSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/layoutslide/) do ustawień domyślnych:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Zresetuj każdy kształt na slajdzie, który ma symbol zastępczy w układzie.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy formatowanie kształtów wpływa na ostateczny rozmiar pliku prezentacji?**

Tylko w niewielkim stopniu. Osadzone obrazy i multimedia zajmują większość przestrzeni pliku, podczas gdy parametry kształtów, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i nie dodają praktycznie żadnego dodatkowego rozmiaru.

**Jak wykryć kształty na slajdzie, które mają identyczne formatowanie, aby móc je pogrupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — ustawienia wypełnienia, linii i efektów. Jeśli wszystkie odpowiadające wartości są zgodne, uznaj ich style za identyczne i logicznie pogrupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw niestandardowych stylów kształtów do osobnego pliku w celu ponownego użycia w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w zestawie slajdów szablonu lub pliku szablonu .POTX. Przy tworzeniu nowej prezentacji otwórz szablon, sklonuj potrzebne kształty ze stylami i ponownie zastosuj ich formatowanie w wymaganych miejscach.