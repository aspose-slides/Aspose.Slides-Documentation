---
title: Pobieranie efektywnych właściwości kształtu z prezentacji w Javie
linktitle: Właściwości efektywne
type: docs
weight: 50
url: /pl/java/shape-effective-properties/
keywords:
- właściwości kształtu
- właściwości kamery
- zestaw oświetlenia
- kształt sfazowany
- ramka tekstowa
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla Javy oblicza i stosuje efektywne właściwości kształtu, zapewniając precyzyjne renderowanie PowerPoint."
---
## **Przegląd**

Ten temat wyjaśnia różnicę między **lokalnymi** a **efektywnymi** właściwościami. Lokalnymi wartościami są wartości ustawione bezpośrednio na określonym poziomie formatowania, na przykład:

1. Właściwości fragmentu na slajdzie.
1. Style tekstu prototypowego kształtu na układzie lub slajdzie‑mistrzu, gdy kształt ramki tekstowej fragmentu posiada je.
1. Globalne ustawienia tekstu w prezentacji.

Lokalne wartości mogą być zdefiniowane lub pominięte na dowolnym poziomie. Gdy Aspose.Slides potrzebuje ostatecznego formatowania „takiego jak wyświetlane”, rozwiązuje łańcuch dziedziczenia i zwraca **efektywne** wartości. Można je uzyskać, wywołując metodę `getEffective` na obiekcie formatu lokalnego.

Poniższy przykład pokazuje, jak uzyskać efektywne wartości. Zakłada, że pierwsza forma na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape) z ramką tekstową i co najmniej jednym fragmentem.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
Dane formatowania efektywnego reprezentują bieżące obliczone formatowanie po zastosowaniu dziedziczenia. W bieżącej implementacji niektóre obiekty danych efektywnych, takie jak [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPortionFormatEffectiveData), mogą być przechowywane w pamięci podręcznej wewnętrznie. Ponowne wywołanie `getEffective` po zmianie formatowania rodzica lub dziedziczonego może odświeżyć dane w pamięci podręcznej, a wcześniej uzyskany obiekt może nie odzwierciedlać wcześniejszego stanu. Jeśli potrzebujesz zachować efektywne wartości do późniejszego użycia, skopiuj wymagane właściwości, takie jak wysokość czcionki, kolor wypełnienia, styl czcionki lub wyrównanie, do własnego obiektu danych.
{{% /alert %}}

## **Uzyskaj efektywne właściwości kamery**

Aspose.Slides umożliwia uzyskanie efektywnych właściwości kamery. Interfejs [ICameraEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICameraEffectiveData) reprezentuje niezmienny obiekt zawierający efektywne właściwości kamery. Instancja [ICameraEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICameraEffectiveData) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IThreeDFormatEffectiveData), który zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IThreeDFormat).

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości kamery. Zakłada, że pierwsza forma na pierwszym slajdzie ma formatowanie 3D.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Uzyskaj efektywne właściwości zestawu oświetlenia**

Aspose.Slides umożliwia uzyskanie efektywnych właściwości zestawu oświetlenia. Interfejs [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ILightRigEffectiveData) reprezentuje niezmienny obiekt zawierający efektywne właściwości zestawu oświetlenia. Instancja [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ILightRigEffectiveData) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IThreeDFormatEffectiveData), który zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IThreeDFormat).

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości zestawu oświetlenia. Zakłada, że pierwsza forma na pierwszym slajdzie ma formatowanie 3D.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Uzyskaj efektywne właściwości kształtu ze sfazowaniem**

Aspose.Slides umożliwia uzyskanie efektywnych właściwości sfazowania kształtu. Interfejs [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeBevelEffectiveData) reprezentuje niezmienny obiekt zawierający efektywne właściwości reliefu powierzchni kształtu. Instancja [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeBevelEffectiveData) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IThreeDFormatEffectiveData), który zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IThreeDFormat).

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości górnego sfazowania kształtu. Zakłada, że pierwsza forma na pierwszym slajdzie ma formatowanie 3D.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Uzyskaj efektywne właściwości ramki tekstowej**

Korzystając z Aspose.Slides, możesz uzyskać efektywne właściwości ramki tekstowej. Interfejs [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextFrameFormatEffectiveData) zawiera efektywne właściwości formatowania ramki tekstowej.

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości formatowania ramki tekstowej. Zakłada, że pierwsza forma na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape) z ramką tekstową.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Uzyskaj efektywne właściwości stylu tekstu**

Korzystając z Aspose.Slides, możesz uzyskać efektywne właściwości stylu tekstu. Interfejs [ITextStyleEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextStyleEffectiveData) zawiera efektywne właściwości stylu tekstu.

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości stylu tekstu. Zakłada, że pierwsza forma na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape) z ramką tekstową.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Uzyskaj efektywną wartość wysokości czcionki**

Korzystając z Aspose.Slides, możesz uzyskać efektywną wysokość czcionki. Poniższy kod demonstruje, jak efektywna wysokość czcionki fragmentu zmienia się po ustawieniu lokalnych wartości wysokości czcionki na różnych poziomach struktury prezentacji.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Uzyskaj efektywny format wypełnienia tabeli**

Korzystając z Aspose.Slides, możesz uzyskać efektywne formatowanie wypełnienia dla różnych części tabeli. Interfejs [IFillFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IFillFormatEffectiveData) zawiera efektywne właściwości formatowania wypełnienia. Formatowanie komórki ma wyższy priorytet niż formatowanie wiersza, formatowanie wiersza ma wyższy priorytet niż formatowanie kolumny, a formatowanie kolumny ma wyższy priorytet niż formatowanie całej tabeli.

W wyniku tego właściwości [ICellFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICellFormatEffectiveData) są używane do rysowania komórki tabeli. Poniższy przykład kodu pokazuje, jak uzyskać efektywne formatowanie wypełnienia dla różnych części tabeli. Zakłada, że pierwsza forma na pierwszym slajdzie jest [ITable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITable).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **Najczęściej zadawane pytania**

### Czy `getEffective` zwraca migawkę?

Nie zawsze. Dane efektywne reprezentują obliczone formatowanie po zastosowaniu dziedziczenia, ale niektóre obiekty danych efektywnych mogą być przechowywane w pamięci podręcznej wewnętrznie. Kolejne wywołanie `getEffective` może ponownie obliczyć formatowanie i odświeżyć dane w pamięci podręcznej, więc wcześniej uzyskany obiekt nie powinien być traktowany jako trwała migawka.

### Kiedy powinienem ponownie odczytać efektywne właściwości?

Wywołaj `getEffective` ponownie po zmianie lokalnego formatowania, stylów nadrzędnych, formatowania układu, formatowania slajdu‑mistrza lub domyślnych ustawień na poziomie prezentacji. Kolejne wywołanie ponownie ocenia hierarchię formatowania i zwraca bieżący wynik efektywny.

### Czy zmiana lub usunięcie slajdu układu/mistrza wpływa na już pobrane efektywne właściwości?

Tak, ale zmiana zostanie odzwierciedlona przy następnym wywołaniu `getEffective`. Jeśli źródło formatowania nadrzędnego zostanie zmienione lub usunięte, wcześniej uzyskane dane efektywne mogą stać się nieaktualne. Po ponownym wywołaniu `getEffective` Aspose.Slides ponownie ocenia drzewo formatowania i wynikowe czcionki, kolory, rozmiary lub inne wartości mogą ulec zmianie.

### Czy mogę modyfikować wartości za pośrednictwem obiektów danych efektywnych?

Nie. Obiekty danych efektywnych udostępniają wyliczone wartości. Wprowadź zmiany w obiektach lokalnego formatowania, a następnie ponownie pobierz efektywne wartości.

### Co się dzieje, jeśli właściwość nie jest ustawiona na poziomie kształtu, ani w układzie/mistrzu, ani w ustawieniach globalnych?

Wartość efektywna jest określana przez mechanizm domyślny, który obejmuje domyślne ustawienia PowerPoint i Aspose.Slides. Ta ustalona wartość staje się częścią bieżących danych efektywnych.

### Czy z efektywnej wartości czcionki mogę określić, który poziom dostarczył rozmiar lub krój czcionki?

Nie bezpośrednio. Dane efektywne zwracają wartość końcową. Aby znaleźć źródło, sprawdź lokalne wartości w fragmencie, akapicie, ramce tekstowej oraz stylach tekstu na poziomach układu, mistrza i prezentacji, aby zobaczyć, gdzie pojawia się pierwsza jawna definicja.

### Dlaczego efektywne wartości czasami wyglądają identycznie jak lokalne?

Ponieważ wartość lokalna okazała się ostateczna (nie było potrzebne dziedziczenie z wyższego poziomu). W takich przypadkach wartość efektywna jest identyczna z lokalną.

### Kiedy powinienem używać efektywnych właściwości, a kiedy pracować wyłącznie z lokalnymi?

Używaj danych efektywnych, gdy potrzebny jest wynik „tak jak wyświetlane” po zastosowaniu całego dziedziczenia, na przykład w celu dopasowania kolorów, wcięć lub rozmiarów. Jeśli musisz zachować te wartości niezależnie od późniejszych zmian formatowania, skopiuj wymagane właściwości do własnego obiektu. Jeśli potrzebujesz zmienić formatowanie na określonym poziomie, zmodyfikuj właściwości lokalne, a następnie, w razie potrzeby, ponownie odczytaj dane efektywne, aby zweryfikować rezultat.