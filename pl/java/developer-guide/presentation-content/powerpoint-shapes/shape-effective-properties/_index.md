---
title: Pobieranie efektywnych właściwości kształtów z prezentacji w Javie
linktitle: Właściwości efektywne
type: docs
weight: 50
url: /pl/java/shape-effective-properties/
keywords:
- właściwości kształtu
- właściwości kamery
- zestaw świateł
- kształt skosu
- ramka tekstowa
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides for Java oblicza i stosuje efektywne właściwości kształtów dla precyzyjnego renderowania PowerPointa."
---
## **Przegląd**

Ten temat wyjaśnia różnicę między **lokalnymi** a **efektywnymi** właściwościami. Wartości lokalne są wartościami ustawionymi bezpośrednio na określonym poziomie formatowania, takimi jak:

1. Właściwości fragmentu (portion) na slajdzie.
1. Style tekstu prototypowego kształtu na układzie lub slajdzie głównym, gdy kształt ramki tekstu fragmentu posiada je.
1. Globalne ustawienia tekstu w prezentacji.

Wartości lokalne mogą być definiowane lub pomijane na dowolnym poziomie. Kiedy Aspose.Slides potrzebuje ostatecznego formatowania „tak jak jest renderowane”, rozwiązuje łańcuch dziedziczenia i zwraca **efektywne** wartości. Można je uzyskać, wywołując metodę `getEffective` na obiekcie formatu lokalnego.

Poniższy przykład pokazuje, jak uzyskać wartości efektywne. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape) z ramką tekstową i co najmniej jednym fragmentem.

```java
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

{{% alert color="primary" %}}
Dane formatowania efektywnego reprezentują bieżące wyliczone formatowanie po zastosowaniu dziedziczenia. W bieżącej implementacji niektóre obiekty danych efektywnych, takie jak [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPortionFormatEffectiveData), mogą być buforowane wewnętrznie. Ponowne wywołanie `getEffective` po zmianie formatowania rodzica lub odziedziczonego może odświeżyć buforowane dane, a wcześniej uzyskany obiekt może już nie odzwierciedlać wcześniejszego stanu. Jeśli musisz zachować wartości efektywne do późniejszego użycia, skopiuj wymagane właściwości, takie jak wysokość czcionki, kolor wypełnienia, styl czcionki lub wyrównanie, do własnego obiektu danych.
{{% /alert %}}

## **Pobieranie efektywnych właściwości kamery**

Aspose.Slides umożliwia pobranie efektywnych właściwości kamery. Interfejs [ICameraEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICameraEffectiveData) reprezentuje niezmienny obiekt zawierający efektywne właściwości kamery. Instancja [ICameraEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICameraEffectiveData) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IThreeDFormatEffectiveData), które zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IThreeDFormat).

Poniższy przykład kodu pokazuje, jak pobrać efektywne właściwości kamery. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

```java
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

## **Pobieranie efektywnych właściwości zestawu świateł**

Aspose.Slides umożliwia pobranie efektywnych właściwości zestawu świateł. Interfejs [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ILightRigEffectiveData) reprezentuje niezmienny obiekt zawierający efektywne właściwości zestawu świateł. Instancja [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ILightRigEffectiveData) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IThreeDFormatEffectiveData), które zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IThreeDFormat).

Poniższy przykład kodu pokazuje, jak pobrać efektywne właściwości zestawu świateł. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

```java
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

## **Pobieranie efektywnych właściwości skosu kształtu**

Aspose.Slides umożliwia pobranie efektywnych właściwości skosu kształtu. Interfejs [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeBevelEffectiveData) reprezentuje niezmienny obiekt zawierający efektywne właściwości wypukłości dla kształtu. Instancja [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeBevelEffectiveData) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IThreeDFormatEffectiveData), które zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IThreeDFormat).

Poniższy przykład kodu pokazuje, jak pobrać efektywne właściwości górnego skosu kształtu. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

```java
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

## **Pobieranie efektywnych właściwości ramki tekstowej**

Przy użyciu Aspose.Slides możesz pobrać efektywne właściwości ramki tekstowej. Interfejs [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextFrameFormatEffectiveData) zawiera efektywne właściwości formatowania ramki tekstowej.

Poniższy przykład kodu pokazuje, jak pobrać efektywne właściwości formatowania ramki tekstowej. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape) z ramką tekstową.

```java
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

## **Pobieranie efektywnych właściwości stylu tekstu**

Przy użyciu Aspose.Slides możesz pobrać efektywne właściwości stylu tekstu. Interfejs [ITextStyleEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextStyleEffectiveData) zawiera efektywne właściwości stylu tekstu.

Poniższy przykład kodu pokazuje, jak pobrać efektywne właściwości stylu tekstu. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape) z ramką tekstową.

```java
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

## **Pobranie efektywnej wartości wysokości czcionki**

Przy użyciu Aspose.Slides możesz pobrać efektywną wysokość czcionki. Poniższy kod demonstruje, jak efektywna wysokość czcionki fragmentu zmienia się po ustawieniu lokalnych wartości wysokości czcionki na różnych poziomach struktury prezentacji.

```java
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

## **Pobieranie efektywnego formatu wypełnienia tabeli**

Przy użyciu Aspose.Slides możesz pobrać efektywne formatowanie wypełnienia dla różnych części tabeli. Interfejs [IFillFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IFillFormatEffectiveData) zawiera efektywne właściwości formatowania wypełnienia. Formatowanie komórki ma wyższy priorytet niż formatowanie wiersza, formatowanie wiersza ma wyższy priorytet niż formatowanie kolumny, a formatowanie kolumny ma wyższy priorytet niż formatowanie całej tabeli.

W rezultacie właściwości [ICellFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ICellFormatEffectiveData) są używane do rysowania komórki tabeli. Poniższy przykład kodu pokazuje, jak pobrać efektywne formatowanie wypełnienia dla różnych części tabeli. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [ITable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITable).

```java
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

## **FAQ**

**Czy `getEffective` zwraca migawkę?**

Nie zawsze. Dane efektywne reprezentują wyliczone formatowanie po zastosowaniu dziedziczenia, ale niektóre obiekty danych efektywnych mogą być buforowane wewnętrznie. Kolejne wywołanie `getEffective` może ponownie przeliczyć formatowanie i odświeżyć buforowane dane, więc wcześniej uzyskany obiekt nie powinien być traktowany jako trwała migawka.

**Kiedy powinienem ponownie odczytać efektywne właściwości?**

Wywołaj `getEffective` ponownie po zmianie formatowania lokalnego, stylów nadrzędnych, formatowania układu, formatowania głównego lub domyślnych ustawień na poziomie prezentacji. Następne wywołanie ponownie ocenia hierarchię formatowania i zwraca bieżący wynik efektywny.

**Czy zmiana lub usunięcie slajdu układu/głównego wpływa na już pobrane efektywne właściwości?**

Tak, ale zmiana zostaje odzwierciedlona przy następnym wywołaniu `getEffective`. Jeśli źródło formatowania nadrzędnego zostanie zmienione lub usunięte, wcześniej uzyskane dane efektywne mogą stać się nieaktualne. Po ponownym wywołaniu `getEffective` Aspose.Slides ponownie oceni drzewo formatowania i wynikowe czcionki, kolory, rozmiary lub inne wartości mogą ulec zmianie.

**Czy mogę modyfikować wartości poprzez obiekty danych efektywnych?**

Nie. Obiekty danych efektywnych udostępniają wyliczone wartości. Wprowadzaj zmiany w obiektach formatowania lokalnego, a następnie ponownie pobierz wartości efektywne.

**Co się dzieje, jeśli właściwość nie jest ustawiona na poziomie kształtu, układu/głównego ani w ustawieniach globalnych?**

Wartość efektywna jest określana przez mechanizm domyślny, obejmujący ustawienia domyślne PowerPointa i Aspose.Slides. Ta rozpoznana wartość staje się częścią bieżących danych efektywnych.

**Czy na podstawie efektywnej wartości czcionki mogę określić, który poziom dostarczył rozmiar lub krój?**

Nie bezpośrednio. Dane efektywne zwracają końcową wartość. Aby znaleźć źródło, sprawdź wartości lokalne na poziomie fragmentu, akapitu, ramki tekstowej oraz stylów tekstu na poziomach układu, głównego i prezentacji, aby zobaczyć, gdzie pojawiła się pierwsza explicite definicja.

**Dlaczego wartości efektywne czasami wyglądają identycznie jak lokalne?**

Ponieważ wartość lokalna okazała się ostateczna (nie było potrzebne dziedziczenie z wyższego poziomu). W takich przypadkach wartość efektywna jest identyczna z lokalną.

**Kiedy powinienem używać właściwości efektywnych, a kiedy pracować tylko z lokalnymi?**

Używaj danych efektywnych, gdy potrzebny jest wynik „tak jak jest renderowane” po zastosowaniu całego dziedziczenia, np. aby dopasować kolory, wcięcia lub rozmiary. Jeśli musisz zachować te wartości niezależnie od późniejszych zmian formatowania, skopiuj wymagane właściwości do własnego obiektu. Jeśli chcesz zmienić formatowanie na określonym poziomie, zmodyfikuj właściwości lokalne, a następnie, w razie potrzeby, ponownie odczytaj dane efektywne, aby zweryfikować rezultat.