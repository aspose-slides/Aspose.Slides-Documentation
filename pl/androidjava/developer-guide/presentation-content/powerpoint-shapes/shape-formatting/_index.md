---
title: Formatowanie kształtów PowerPoint na Androidzie
linktitle: Formatowanie kształtów
type: docs
weight: 20
url: /pl/androidjava/shape-formatting/
keywords:
- formatowanie kształtu
- formatowanie linii
- efekt szkicowy
- linia szkicowa kształtu
- formatowanie stylu połączenia
- wypełnienie gradientem
- wypełnienie wzorem
- wypełnienie obrazem
- wypełnienie teksturą
- wypełnienie kolorem stałym
- przezroczystość kształtu
- renderowanie kształtu w czerni i bieli
- renderowanie kształtu w odcieniach szarości
- obracanie kształtu
- efekt wybruszenia 3D
- efekt obrotu 3D
- resetowanie formatowania
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak formatować kształty PowerPoint na Androidzie przy użyciu Aspose.Slides — ustawiaj style wypełnień, linii i efektów dla plików PPT i PPTX z precyzją i pełną kontrolą."
---
## **Wprowadzenie**

Formatuj kształty w programie PowerPoint, dostosowując ich kontury, wypełnienia i efekty. Aspose.Slides for Android via Java umożliwia programowe sterowanie tymi ustawieniami, w tym przezroczystością, obrotem i formatowaniem 3D.

![Opcje formatowania kształtów w programie PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java udostępnia interfejsy i metody, które pozwalają formatować kształty przy użyciu tych samych opcji dostępnych w programie PowerPoint.

## **Formatowanie linii**

Użyj [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) aby kontrolować obrys kształtu. Ten przykład tworzy prostokąt bez wypełnienia z niebieskim, przerywanym obrysem. [ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) wybiera linię złożoną z grubej i cienkiej części, podczas gdy [ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) ustawia jej szerokość na 7 punktów, a [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) wybiera wzór przerywania.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Sformatowane linie w prezentacji](formatted-lines.png)

### **Ustaw własne wzory przerywania linii**

Użyj [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) gdy wstępnie zdefiniowane style linii nie zapewniają potrzebnych długości przerywań i przerw, na przykład dla znaków firmowych lub diagramów technicznych. Przypisanie wzoru automatycznie zmienia styl przerywania linii na [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/).

Wpisy w tablicy naprzemiennie określają długości przerywań i przerw, zaczynając od przerywania. Każda wartość jest wielokrotnością szerokości linii: `{ 4, 2 }` przy szerokości 3 punktów daje 12‑punktowe przerywanie, po którym następuje 6‑punktowa przerwa. Używaj par skończonych, nieujemnych wartości, aby definiować pełne segmenty przerywania‑przerwy. Przykład używa dodatnich wartości, aby każdy przerywanie i przerwa były widoczne.

Ten przykład tworzy pięć niebieskich linii o tej samej długości i płaskich zakończeniach. Pierwsze trzy porównują wzory przy szerokości 3 punktów. Czwarta powtarza pierwszy wzór przy dwukrotnej szerokości, podwajając zarówno długości przerywań, jak i przerw. Piąta przełącza się z własnego wzoru na linię ciągłą.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Ustaw ostatnią linię na styl ciągły.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby powrócić do wstępnie zdefiniowanego stylu przerywanego, przekaż [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) do [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-). Wybrany styl kontroluje wygląd linii.

Wynik w programie PowerPoint, od góry do dołu: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; oraz **Solid, 3 pt**.

![Trzy własne wzory przerywania, szersza linia używająca pierwszego wzoru i linia ciągła w programie PowerPoint](custom-dash-patterns.png)

### **Ustaw style zakończeń linii**

Użyj [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) aby ustawić zakończenia otwartej linii. Klasa [LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) udostępnia trzy wyraźne style zakończeń:

- `Flat`: Pędzel zatrzymuje się na końcowym punkcie.
- `Round`: Półokrągłe zakończenie wykracza poza punkt końcowy o połowę szerokości linii.
- `Square`: Kwadratowe zakończenie wykracza poza punkt końcowy o połowę szerokości linii.

Klasa zawiera także `NotDefined`, co oznacza, że żaden styl zakończenia nie został wyraźnie przypisany.

Zakończenia różnią się od grotów strzałek, które dodają symbole do końców linii, oraz od połączeń, które kontrolują narożniki między segmentami linii. Ten przykład wyłącza groty strzałek poprzez [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) i [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-), tak aby porównywane były tylko kształty zakończeń.

Poniższy przykład tworzy trzy w pozostałych aspektach identyczne poziome linie o szerokości 20 punktów. Od góry do dołu używają płaskich, okrągłych i kwadratowych zakończeń. Ich końcowe punkty mają te same współrzędne poziome; okrągłe i kwadratowe zakończenia wykraczają 10 punktów poza każdy punkt końcowy.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik w programie PowerPoint, od góry do dołu: **Flat**, **Round**, i **Square**.

![Płaskie, okrągłe i kwadratowe zakończenia na identycznych grubych liniach w programie PowerPoint](line-caps.png)

## **Zastosuj efekty szkicowe do linii kształtu**

Efekt szkicowy sprawia, że linia kształtu wygląda jak narysowana ręcznie. Użyj [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) aby uzyskać dostęp do ustawień linii, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) aby uzyskać dostęp do ustawień szkicu oraz [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) aby wybrać wartość z klasy [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/).

Poniższy kod w języku Java pokazuje, jak zastosować efekt [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/), odczytać jawnie przypisaną wartość i usunąć efekt przy użyciu [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Wartość zwracana przez [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) reprezentuje ustawienie przypisane bezpośrednio do kształtu. Jeśli formatowanie linii może być dziedziczone z motywu, wzorca slajdu lub układu slajdu, użyj [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--), uzyskaj [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--), i odczytaj [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--). Wartość skuteczna odzwierciedla formatowanie faktycznie zastosowane po rozwiązaniu dziedziczenia. Ten przykład wymaga istniejącej prezentacji z co najmniej jednym kształtem na pierwszym slajdzie i wypisuje obie wartości:

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

* Round
* Miter
* Bevel

Styl połączenia kontroluje, jak dwa segmenty obrysu spotykają się w narożniku. Użyj **Round** dla zaokrąglonych narożników, **Miter** dla ostrych narożników lub **Bevel** dla spłaszczonych narożników.

![Styl połączenia w prezentacji](join-style-powerpoint.png)

Ten przykład tworzy trzy czarne prostokąty z niebieskimi obrysami o szerokości 15 punktów. Używa [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) aby zastosować kolejno wartości miter, bevel i round z klasy [LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/), aby porównać, jak rysowane są narożniki.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ogranicz połączenia miter przy ostrych narożnikach**

Użyj [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) wraz z [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) ustawionym na [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) aby ograniczyć, jak daleko ostry narożnik może wystawać.

Limit jest stosunkiem odległości między wewnętrznym a zewnętrznym narożnikiem połączenia do szerokości linii. Na przykład wartość `8` pozwala na długość miteru do ośmiu razy szerokości linii; nie jest to pomiar w punktach. Jeśli narożnik przekroczyłby limit, PowerPoint zastosuje połączenie z fazą (bevel) w tym miejscu. Większy limit pozwala na ostrzejsze punkty. Ustawienie wpływa tylko na połączenia miter i nie ma widocznego efektu, gdy narożnik pozostaje w granicach limitu.

Ten przykład tworzy dwa identyczne, nie wypełnione trójkąty z obrysami o szerokości 20 punktów. Lewy trójkąt używa limitu `2`, a prawy `8`. Każdy trójkąt ma szerokość 80 punktów i wysokość 160 punktów, co daje stosunek długości miteru do szerokości linii w górnym narożniku około `4.12`. W konsekwencji PowerPoint przycina lewy wierzchołek i zachowuje prawy.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik w PowerPoint: **Miter limit 2** po lewej i **miter limit 8** po prawej.

![Wierzchołek z fazą przy limicie miter 2 i ostry wierzchołek przy limicie miter 8 w programie PowerPoint](miter-limits.png)

## **Wypełnienie gradientem**

Wypełnienie gradientem miesza kolory w obrębie kształtu. Ten przykład wypełnia elipsę gradientem liniowym pod kątem 45 stopni od czerwonego do fioletowego przy użyciu [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--). Metoda [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) umieszcza kolory przystankowe na pozycjach 0 i 1, czyli na początku i końcu gradientu. Usunięcie istniejących przystanków zapewnia, że użyte zostaną tylko te dwa kolory.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Elipsa z wypełnieniem gradientowym](gradient-fill.png)

Jeśli gradient wygląda inaczej w wyeksportowanym obrazie niż w programie PowerPoint, zobacz [Choose a Gradient Rendering Style](/slides/pl/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Można wybrać styl renderowania bez zmieniania gradientu zapisanego w prezentacji.

### **Ustaw kąt gradientu liniowego**

Użyj [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) aby kontrolować orientację wypełnienia [GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/). Kąt mierzony jest w stopniach i rośnie zgodnie z ruchem wskazówek zegara: `0` biegnie od lewej do prawej, `90` od góry do dołu, `180` od prawej do lewej, a `270` od dołu do góry. Obsługiwane są kąty ułamkowe. Kąty skończone poza zakresem `[0, 360)` są normalizowane do jednego obrotu; na przykład `-45` staje się `315`, a `360` staje się `0`.

Ten przykład tworzy sześć prostokątów z identycznymi przystankami czerwonego, zielonego i niebieskiego w pozycjach `0`, `0.5` i `1`. Skalowanie jest wyłączone, aby kąt można było porównać niezależnie od proporcji prostokątów. Kąty, od lewej do prawej, to `0`, `45` i `90` w pierwszym wierszu oraz `135`, `180` i `270` w drugim wierszu.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik w PowerPoint:

![Gradienty liniowe pod kątami 0, 45 i 90 stopni w pierwszym wierszu oraz 135, 180 i 270 stopni w drugim wierszu](linear-gradient-angles.png)

### **Skaluj gradient liniowy wraz z kształtem**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) przyjmuje wartość [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/). Ustaw ją jawnie na `False`, aby zachować geometryczny kąt gradientu przy zmianie proporcji kształtu, lub na `True`, aby skalować gradient wraz z szerokością i wysokością kształtu. Przy włączonej skalowaniu widoczny kąt może różnić się od przypisanego kąta w przypadku kształtu, który nie jest kwadratem.

Poniższy przykład używa kąta `45` stopni i tych samych przystanków kolorowych co porównanie kątów. Lewa kolumna używa `False`; prawa kolumna używa `True`. Każda kolumna zawiera szeroki prostokąt nad wysokim prostokątem. Oba zaczynają się od tych samych szerokich wymiarów; zmiana szerokości i wysokości drugiego prostokąta pokazuje, jak wypełnienie reaguje na zmianę rozmiaru bez zmiany ustawień gradientu.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik w PowerPoint, przy wyłączonej skalowaniu po lewej i włączonej po prawej:

![Szerokie i wysokie prostokąty z gradientem 45‑stopni, porównujące LinearGradientScaled False po lewej i True po prawej](linear-gradient-scaling.png)

Przy wyłączonej skalowaniu, skośne pasma kolorów zachowują tę samą orientację w obu prostokątach. Przy włączonej skalowaniu, pasma rozciągają się wraz z proporcjami kształtu. Pomaga to odtworzyć gradient szablonu przy dostosowywaniu kształtu do innego rozmiaru. Na kwadracie włączenie skalowania nie zmienia wyglądu tego gradientu `45`‑stopniowego.

Zarówno kąt, jak i ustawienie skalowania dotyczą gradientów liniowych. Nie kontrolują wypełnień [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/).

### **Połącz kąt z kierunkiem gradientu**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) wybiera styl gradientu z klasy [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/); nie jest to zamiennik dla kąta liczbowego. Dla gradientu liniowego style narożników mogą zmienić obszar, na którym kolory są rozłożone, bez zmiany kąta przypisanego przez [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). Zachowaj niezmieniony kierunek przy porównywaniu kątów lub skalowania.

Poniższy przykład stosuje te same ustawienia w odwrotnej kolejności. Dwa prostokąty mają ten sam wygląd: ustawienie najpierw kierunku, a potem kąta nie zmienia wyniku.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wypełnienie wzorem**

Wypełnienie wzorem nakłada dwukolorowy wzór, taki jak kropki, paski lub szachownica. Ten przykład używa [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) aby wybrać wzór kratki. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) dostarcza jasnoszare tło, a [IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) dostarcza żółty kolor wzoru.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.rgb(192, 192, 192));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Prostokąt z wypełnieniem wzorem](pattern-fill.png)

## **Wypełnienie obrazem**

Wypełnienie obrazem używa obrazu wewnątrz kształtu. Ten przykład wymaga lokalnego obrazu i używa [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) aby załadować go do kolekcji obrazów prezentacji. Ustawienie [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) na tryb kafelkowy powtarza obraz w prostokącie. Źródłowy obraz użyty tutaj jest pokazany poniżej:

![Obraz lotosu](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Kształt z wypełnieniem obrazem](picture-fill.png)

### **Kafelkowanie obrazu jako tekstura**

Jeśli chcesz ustawić obraz kafelkowy jako teksturę i dostosować zachowanie kafelkowania, możesz użyć następujących metod interfejsu [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) i klasy [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Ustawia tryb wypełnienia obrazu — `Tile` lub `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Określa wyrównanie kafelków w obrębie kształtu.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Kontroluje, czy kafelek jest odbity poziomo, pionowo, czy w obu kierunkach.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Ustawia poziomy offset kafelka (w punktach) od początku kształtu.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Ustawia pionowy offset kafelka (w punktach) od początku kształtu.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definiuje poziomą skalę kafelka jako procent.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definiuje pionową skalę kafelka jako procent.

Ten przykład wymaga lokalnego obrazu i konfiguruje [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) aby powtórzyć go w 50 % oryginalnego rozmiaru. Przesunięcia o −32 punkty przesuwają kafelki poziomo i pionowo; wyrównanie w prawym dolnym rogu i odbicie w obu kierunkach określają, jak powtarzana tekstura jest rozmieszczona.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Opcje kafelkowania](tile-options.png)

## **Wypełnienie kolorem stałym**

Wypełnienie stałe nadaje kształtowi jednolity kolor. Ten przykład używa [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) aby wybrać tryb wypełnienia stałego i przypisuje żółty kolor za pomocą [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--), po czym zapisuje prostokąt w prezentacji.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Kształt z wypełnieniem kolorem stałym](solid-color-fill.png)

## **Użyj tła slajdu jako wypełnienia kształtu**

Użyj [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) gdy kształt ma odpowiadać tłu slajdu, na przykład w szablonie prezentacji. Użyj [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) z [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) najpierw, aby usunąć wszelkie jawne wypełnienie. Dzięki tej kombinacji kształt używa tła slajdu zamiast swojego stylu wypełnienia. Samo włączenie flagi nie usuwa istniejącego jawnego wypełnienia.

Różni się to od [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/): wypełnienie tła zakrywa obiekty znajdujące się za kształtem odpowiednim obszarem tła slajdu, podczas gdy brak wypełnienia pozostawia te obiekty widoczne. Wypełnienie gradientowe pozostaje wyrównane do slajdu, a nie rozpoczyna się wewnątrz każdego kształtu.

Ten poniższy przykład tworzy tło główne dziedziczone przez slajd i umieszcza magentowy pasek za trzema prostokątami. Lewy prostokąt używa tła, środkowy prostokąt nie ma wypełnienia, a prawy prostokąt przełącza się z wypełnienia tła na jawne pomarańczowe wypełnienie.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dziedzicz gradient z mastera.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, Color.rgb(0, 0, 139));
    gradient.getGradientStops().add(1, Color.rgb(135, 206, 250));

    // Dodaj ten obiekt najpierw, aby znajdował się za prostokątami.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // Wyłącz wypełnienie tłem przed zastosowaniem jawnego wypełnienia.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik, od lewej do prawej: **tło wypełnienia**, **brak wypełnienia** i **jawne wypełnienie**. Magentowy pasek jest ukryty przez lewy i prawy prostokąt, ale pozostaje widoczny przez środkowy prostokąt.

![Wypełnienie tłem, brak wypełnienia i jawne pomarańczowe wypełnienie nad magentowym paskiem](background-fill.png)

To samo zachowanie dotyczy tła określonego bezpośrednio na slajdzie lub dziedziczonego z układu. Kształt używa rozwiązanego tła slajdu; przykład pozostawia zarówno tło slajdu, jak i układu nieokreślone, więc master je dostarcza.

## **Ustaw przezroczystość**

W przypadku wypełnienia stałego komponent alfa koloru kontroluje nieprzezroczystość: 0 oznacza całkowitą przezroczystość, a 255 całkowitą nieprzezroczystość. Ten przykład używa wartości alfa 128 dla żółtego prostokąta, co czyni go w przybliżeniu w 50 % przezroczystym, tak aby prostokąt pod nim był widoczny. Kolor jest przypisywany poprzez [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(Color.argb(128, 255, 255, 0));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Przezroczysty kształt](shape-transparency.png)

## **Obróć kształty**

Użyj [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) aby obrócić kształt w płaszczyźnie slajdu. Kąt mierzony jest w stopniach; ten przykład obraca prostokąt o 5 stopni zgodnie z ruchem wskazówek zegara i zapisuje prezentację.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Obrót kształtu](shape-rotation.png)

## **Dodaj efekty krawędzi 3D**

Użyj [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) aby nadać kształtowi głębię i wybrzuszone krawędzie. Ten przykład tworzy zieloną elipsę z pomarańczowym obrysem, używa [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) aby ustawić głębokość na 4 punkty oraz stosuje okrągłe górne wybruszenie o szerokości i wysokości 6 punktów poprzez [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--). Kamera ortograficzna skierowana na przód oraz oświetlenie trójpunktowe uwidaczniają wybruszenie.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Efekt wybruszenia 3D](3D-bevel-effect.png)

## **Dodaj efekty obrotu 3D**

Widok 3D kształtu kontrolowany jest przez ustawienia kamery. Ten przykład używa [ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) z kątami szerokości, długości i obrotu wynoszącymi odpowiednio 40, 35 i 20 stopni. Wybiera kamery izometryczną przez [ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) oraz zrównoważone oświetlenie przez [ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-), po czym zapisuje sformatowany prostokąt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Efekt obrotu 3D](3D-rotation-effect.png)

## **Kontroluj renderowanie czarno‑białe dla kształtów**

Metoda [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) określa, jak pojedynczy kształt jest renderowany, gdy prezentacja jest wyświetlana lub przetwarzana w trybie czarno‑białym. Nie włącza ona samej prezentacji w trybie czarno‑białym i nie zmienia wypełnienia, linii ani innych formatów w normalnym trybie kolorowym.

Użyj wartości z klasy [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) aby wybrać pożądane zachowanie. Na przykład `Automatic` pozwala aplikacji renderującej wybrać konwersję, `Gray` i `LightGray` używają odcieni szarości, `BlackWhite` używa wyłącznie czerni i bieli, `Black` i `White` wymuszają pojedynczy kolor, `Color` zachowuje normalne kolory, a `Hidden` pomija kształt w trybie czarno‑białym. `NotDefined` oznacza, że nie przypisano trybu na poziomie kształtu.

Ten przykład tworzy pomarańczowy prostokąt i używa [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) aby wybrać szare renderowanie. Zapisany kształt zachowuje pomarańczowe wypełnienie w normalnym trybie kolorowym i żąda szarego renderowania w aplikacjach respektujących ustawienia czarno‑białego wyświetlania:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

W normalnym trybie kolorowym prostokąt zachowuje pomarańczowe wypełnienie. W przepływie pracy czarno‑białego używa szarego renderowania, ponieważ jego tryb ustawiono na `Gray`. Umożliwia to zachowanie slajdu w pełnym kolorze przy definiowaniu odrębnego wyglądu dla drukowania, podglądu lub innych przepływów respektujących ustawienia czarno‑białego wyświetlania prezentacji.

## **Resetuj formatowanie**

Użyj [ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) aby przywrócić pozycję, rozmiar i formatowanie placeholderów slajdu z ich odpowiednimi placeholderami układu. Ten przykład wymaga istniejącej prezentacji z placeholderami powiązanymi z układem i resetuje każdy slajd przed zapisaniem. Kształty bez odpowiadających placeholderów układu nie są resetowane.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy formatowanie kształtu wpływa na rozmiar pliku finalnej prezentacji?**

Kolory, style linii i ustawienia efektów zazwyczaj dodają niewiele danych w porównaniu z osadzonymi obrazami i multimediami. Wypełnienia obrazem mogą zwiększyć rozmiar pliku, ponieważ ich obrazy są przechowywane w prezentacji.

**Jak mogę wykryć kształty na slajdzie, które mają identyczne formatowanie, aby je grupować?**

Porównaj kluczowe właściwości formatowania każdego kształtu — wypełnienie, linię i ustawienia efektów. Jeśli wszystkie odpowiadające wartości się zgadzają, traktuj ich style jako identyczne i logicznie grupuj te kształty, co upraszcza późniejsze zarządzanie stylami.

**Czy mogę zapisać zestaw własnych stylów kształtów do oddzielnego pliku, aby używać ich w innych prezentacjach?**

Tak. Zachowaj przykładowe kształty z pożądanymi stylami w szablonie prezentacji lub pliku szablonu .POTX. Tworząc nową prezentację, otwórz szablon, sklonuj potrzebne stylowane kształty i ponownie zastosuj ich formatowanie tam, gdzie jest to wymagane.