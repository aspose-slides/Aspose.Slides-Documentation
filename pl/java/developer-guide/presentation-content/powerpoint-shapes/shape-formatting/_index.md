---
title: Formatowanie kształtów PowerPoint w języku Java
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/java/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- efekt szkicu
- linia szkicu kształtu
- formatowanie stylu połączenia
- wypełnienie gradientem
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie jednolitym kolorem
- przezroczystość kształtu
- renderowanie kształtu czarno-białe
- renderowanie kształtu w odcieniach szarości
- obrót kształtu
- efekt 3D bevel
- efekt obrotu 3D
- resetowanie formatowania
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint w języku Java przy użyciu Aspose.Slides — ustawiaj style wypełnienia, linii i efektów dla plików PPT, PPTX i ODP z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

W programie PowerPoint możesz dodawać kształty do slajdów. Ponieważ kształty składają się z linii, możesz je formatować, modyfikując lub stosując efekty na ich konturach. Dodatkowo możesz formatować kształty, określając ustawienia kontrolujące sposób wypełniania ich wnętrz.

![formatowanie-kształtu-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java udostępnia interfejsy i metody, które pozwalają formatować kształty przy użyciu tych samych opcji dostępnych w programie PowerPoint.

## **Formatowanie linii**

Używając Aspose.Slides, możesz określić niestandardowy styl linii dla kształtu. Poniższe kroki opisują procedurę:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu na podstawie jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [styl linii](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/) kształtu.
1. Ustaw szerokość linii.
1. Ustaw [styl kreski](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) linii.
1. Ustaw kolor linii dla kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy kod demonstruje, jak sformatować prostokąt `AutoShape`:

```java
import com.aspose.slides.*;
import java.awt.Color;

//    Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
Presentation presentation = new Presentation();
try {
    //    Uzyskaj pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    //    Dodaj auto-kształt typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    //    Ustaw kolor wypełnienia dla prostokątnego kształtu.
    shape.getFillFormat().setFillType(FillType.NoFill);

    //    Zastosuj formatowanie linii prostokąta.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    //    Ustaw kolor linii prostokąta.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    //    Zapisz plik PPTX na dysku.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Sformatowane linie w prezentacji](formatted-lines.png)

## **Zastosuj efekty szkicu do linii kształtu**

Efekt szkicu sprawia, że linia kształtu wygląda jak narysowana ręcznie. Użyj [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) aby uzyskać dostęp do ustawień linii, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) aby uzyskać dostęp do ustawień szkicu oraz [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) aby wybrać wartość z wyliczenia [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

Poniższy kod Java pokazuje, jak zastosować efekt [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/), odczytać wyraźnie przypisaną wartość i usunąć efekt za pomocą [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

```java
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

Wartość zwracana przez [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) reprezentuje ustawienie przypisane bezpośrednio do kształtu. Jeśli formatowanie linii może być dziedziczone z motywu, slajdu-mistrza lub slajdu układu, użyj [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/), uzyskaj dostęp do [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/), i odczytaj [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/). Efektywna wartość odzwierciedla formatowanie faktycznie zastosowane po rozwiązaniu dziedziczenia:

```java
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
* Ścięty

Domyślnie, gdy PowerPoint łączy dwie linie pod kątem (np. w rogu kształtu), używa ustawienia **Round**. Jednakże, jeśli rysujesz kształt o ostrych kątach, może Ci bardziej odpowiadać opcja **Miter**.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

Poniższy kod Java demonstruje, jak trzy prostokąty (widoczne na powyższym obrazie) zostały utworzone przy użyciu ustawień typu połączenia Miter, Bevel i Round:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Uzyskaj pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj trzy auto-kształty typu Rectangle.
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

    // Ustaw styl połączenia.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Dodaj tekst do każdego prostokąta.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Zapisz plik PPTX na dysku.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wypełnienie gradientem**

W programie PowerPoint wypełnienie gradientem jest opcją formatowania, która pozwala zastosować ciągłe przejście kolorów w kształcie. Na przykład możesz użyć dwóch lub więcej kolorów, tak aby jeden stopniowo przechodził w drugi.

Aby zastosować wypełnienie gradientem do kształtu przy użyciu Aspose.Slides:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu na podstawie jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) kształtu na `Gradient`.
1. Dodaj dwa wybrane kolory wraz z określonymi pozycjami, używając metod `add` kolekcji punktów stop gradientu udostępnianej przez interfejs [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Uzyskaj pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj auto‑kształt typu Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Zastosuj formatowanie gradientowe do elipsy.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Ustaw kierunek gradientu.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Dodaj dwa przystanki gradientu.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Zapisz plik PPTX na dysku.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

Jeśli gradient wygląda inaczej w wyeksportowanym obrazie niż w programie PowerPoint, zobacz [Choose a Gradient Rendering Style](/slides/pl/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Możesz wybrać styl renderowania bez zmiany wypełnienia gradientowego zapisanego w prezentacji.

## **Wypełnienie wzorem**

W programie PowerPoint wypełnienie wzorem jest opcją formatowania, która pozwala zastosować dwukolorowy wzór — np. kropki, paski, krzyżówki lub szachownicę — do kształtu. Możesz wybrać własne kolory pierwszego planu i tła wzoru.

Aspose.Slides udostępnia ponad 45 wstępnie zdefiniowanych stylów wzorów, które możesz zastosować do kształtów, aby zwiększyć atrakcyjność wizualną prezentacji. Nawet po wybraniu gotowego wzoru, możesz dokładnie określić kolory, które mają być użyte.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu na podstawie jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) kształtu na `Pattern`.
1. Wybierz styl wzoru spośród predefiniowanych opcji.
1. Ustaw [Kolor tła](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) wzoru.
1. Ustaw [Kolor pierwszego planu](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) wzoru.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Uzyskaj pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj auto‑kształt typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Pattern.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Ustaw styl wzoru.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Ustaw kolory tła i pierwszego planu wzoru.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Zapisz plik PPTX na dysku.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Wypełnienie obrazem**

W programie PowerPoint wypełnienie obrazem jest opcją formatowania, która pozwala wstawić obraz wewnątrz kształtu — skutecznie używając obrazu jako tła kształtu.

Jak używać Aspose.Slides do zastosowania wypełnienia obrazem:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu na podstawie jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) kształtu na `Picture`.
1. Ustaw tryb wypełnienia obrazem na `Tile` (lub inny preferowany tryb).
1. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) z obrazu, który chcesz użyć.
1. Przekaż obraz do metody `ISlidesPicture.setImage`.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Załóżmy, że mamy plik „lotus.png” z następującym obrazem:

![Obraz lotosu](lotus.png)

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Uzyskaj pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj auto‑kształt typu Rectangle.
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

    // Zapisz plik PPTX na dysku.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Użyj obrazu jako tekstury kafelkowej**

Jeśli chcesz ustawić kafelkowy obraz jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod interfejsu [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) i klasy [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ustawia tryb wypełnienia obrazu — `Tile` lub `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Określa wyrównanie kafelków wewnątrz kształtu.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Kontroluje, czy kafelek jest odbity w poziomie, w pionie lub w obu kierunkach.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ustawia poziomy offset kafelka (w punktach) względem pochodzenia kształtu.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ustawia pionowy offset kafelka (w punktach) względem pochodzenia kształtu.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definiuje poziomą skalę kafelka jako procent.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definiuje pionową skalę kafelka jako procent.

Poniższy przykład kodu pokazuje, jak dodać prostokątny kształt z kafelkowym wypełnieniem obrazem i skonfigurować opcje kafelkowania:

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Uzyskaj pierwszy slajd.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Dodaj prostokątny auto‑kształt.
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

    // Zapisz plik PPTX na dysku.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Opcje kafelkowania](tile-options.png)

## **Wypełnienie jednolitym kolorem**

W programie PowerPoint wypełnienie jednolitym kolorem jest opcją formatowania, która wypełnia kształt jednym, jednorodnym kolorem. Ten jednolity kolor tła jest stosowany bez gradientów, tekstur ani wzorów.

Aby zastosować wypełnienie jednolitym kolorem do kształtu przy użyciu Aspose.Slides, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu na podstawie jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) kształtu na `Solid`.
1. Przypisz wybrany kolor wypełnienia do kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Uzyskaj pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj auto‑kształt typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Ustaw typ wypełnienia na Solid.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Ustaw kolor wypełnienia.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Zapisz plik PPTX na dysku.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Kształt z jednolitym wypełnieniem kolorem](solid-color-fill.png)

## **Ustaw przezroczystość**

W programie PowerPoint, kiedy stosujesz jednolity, gradientowy, obrazowy lub teksturowany wypełnienie kształtów, możesz także ustawić poziom przezroczystości, aby kontrolować nieprzezroczystość wypełnienia. Wyższa wartość przezroczystości sprawia, że kształt staje się bardziej przezroczysty, umożliwiając częściowe widzenie tła lub obiektów leżących pod nim.

Aspose.Slides pozwala ustawić poziom przezroczystości, dostosowując wartość alfa w kolorze używanym do wypełnienia. Oto jak to zrobić:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu na podstawie jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) na `Solid`.
1. Użyj `Color`, aby zdefiniować kolor z przezroczystością (składnik `alpha` steruje przezroczystością).
1. Zapisz prezentację.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Uzyskaj pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj prostokątny auto-kształt wypełniony.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Dodaj przezroczysty prostokątny auto-kształt nad wypełnionym kształtem.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Zapisz plik PPTX na dysku.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Przezroczysty kształt](shape-transparency.png)

## **Obracanie kształtów**

Aspose.Slides pozwala obracać kształty w prezentacjach PowerPoint. Może to być przydatne przy pozycjonowaniu elementów wizualnych wymagających konkretnego wyrównania lub projektu.

Aby obrócić kształt na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu na podstawie jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) do slajdu.
1. Ustaw właściwość rotacji kształtu na żądany kąt.
1. Zapisz prezentację.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
Presentation presentation = new Presentation();
try {
    // Uzyskaj pierwszy slajd.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj auto-kształt typu Rectangle.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Obróć kształt o 5 stopni.
    shape.setRotation(5);

    // Zapisz plik PPTX na dysku.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Obrót kształtu](shape-rotation.png)

## **Dodaj efekty 3D Bevel**

Aspose.Slides umożliwia zastosowanie efektów 3D bevel do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

Aby dodać efekty 3D bevel do kształtu, wykonaj następujące kroki:

1. Zainicjuj klasę [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu na podstawie jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) do slajdu.
1. Skonfiguruj [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) kształtu, aby określić ustawienia krawędzi.
1. Zapisz prezentację.

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

![Efekt 3D bevel](3D-bevel-effect.png)

## **Dodaj efekty obrotu 3D**

Aspose.Slides umożliwia zastosowanie efektów obrotu 3D do kształtów poprzez konfigurowanie ich właściwości [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/).

Aby zastosować obrót 3D do kształtu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Uzyskaj referencję do slajdu na podstawie jego indeksu.
1. Dodaj [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) do slajdu.
1. Użyj metod [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) i [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-), aby zdefiniować obrót 3D.
1. Zapisz prezentację.

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

![Efekt obrotu 3D](3D-rotation-effect.png)

## **Kontrola renderowania czarno-białego dla kształtów**

Metoda [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) określa, jak pojedynczy kształt jest renderowany, gdy prezentacja jest wyświetlana lub przetwarzana w trybie czarno-białym. Nie włącza ona samodzielnie trybu czarno-białego i nie zmienia wypełnienia, linii ani innych formatowań w normalnym trybie kolorowym.

Użyj wartości z klasy [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/), aby wybrać pożądane zachowanie. Na przykład `Automatic` pozwala aplikacji renderującej wybrać konwersję, `Gray` i `LightGray` używają odcieni szarości, `BlackWhite` używa wyłącznie czerni i bieli, `Black` i `White` wymuszają pojedynczy kolor, `Color` zachowuje normalne kolory, a `Hidden` pomija kształt w trybie czarno-białym. `NotDefined` oznacza, że nie przypisano trybu na poziomie kształtu.

Poniższy kod Java tworzy kolorowy kształt i sprawia, że w trybie wyświetlania czarno-białego pojawia się jako szary:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Utrzymaj pomarańczowe wypełnienie w trybie kolorowym, ale renderuj kształt w odcieniach szarości w trybie czarno-białym.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Resetowanie formatowania**

Poniższy kod Java pokazuje, jak zresetować formatowanie slajdu i przywrócić pozycję, rozmiar oraz formatowanie wszystkich kształtów z placeholderami na [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) do ich domyślnych ustawień:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Zresetuj każdy kształt na slajdzie, który ma placeholder w układzie.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy formatowanie kształtów wpływa na rozmiar końcowego pliku prezentacji?**

Tylko w niewielkim stopniu. Osadzone obrazy i multimedia zajmują większość miejsca w pliku, podczas gdy parametry kształtów, takie jak kolory, efekty i gradienty, są przechowywane jako metadane i praktycznie nie zwiększają rozmiaru.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby móc je grupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — wypełnienie, linię i ustawienia efektów. Jeśli wszystkie odpowiadające sobie wartości są takie same, traktuj ich style jako identyczne i logicznie grupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw niestandardowych stylów kształtów w osobnym pliku w celu ponownego użycia w innych prezentacjach?**

Tak. Przechowuj przykładowe kształty z pożądanymi stylami w szablonie prezentacji lub pliku .POTX. Przy tworzeniu nowej prezentacji otwórz szablon, sklonuj potrzebne stylizowane kształty i ponownie zastosuj ich formatowanie tam, gdzie jest to wymagane.