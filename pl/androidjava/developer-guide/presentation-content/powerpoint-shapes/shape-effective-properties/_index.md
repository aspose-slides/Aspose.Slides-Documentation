---
title: Pobieranie efektywnych właściwości kształtu z prezentacji na Androidzie
linktitle: Właściwości efektywne
type: docs
weight: 50
url: /pl/androidjava/shape-effective-properties/
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
- Android
- Java
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla Androida w Javie oblicza i stosuje efektywne właściwości kształtu dla precyzyjnego renderowania PowerPoint."
---
## **Przegląd**

Ten temat wyjaśnia różnicę między właściwościami **lokalnymi** i **efektywnymi**. Wartości lokalne to wartości ustawiane bezpośrednio na określonym poziomie formatowania, takich jak:

1. Właściwości fragmentu na slajdzie.  
1. Style tekstu prototypu kształtu na układzie lub slajdzie wzorcowym, gdy kształt ramki tekstowej fragmentu posiada je.  
1. Globalne ustawienia tekstu w prezentacji.  

Wartości lokalne mogą być definiowane lub pomijane na dowolnym poziomie. Gdy Aspose.Slides potrzebuje ostatecznego formatowania „tak jak zostanie wyświetlone”, rozwiązuje łańcuch dziedziczenia i zwraca wartości **efektywne**. Można je uzyskać, wywołując metodę `getEffective()` na obiekcie formatu lokalnego.

Poniższy przykład pokazuje, jak uzyskać wartości efektywne. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) z ramką tekstową i co najmniej jednym fragmentem.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Dane formatowania efektywnego reprezentują bieżące obliczone formatowanie po zastosowaniu dziedziczenia. W bieżącej implementacji niektóre obiekty danych efektywnych, takie jak [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportionformateffectivedata/), mogą być buforowane wewnętrznie. Ponowne wywołanie `getEffective()` po zmianie formatowania rodzica lub dziedziczonego może odświeżyć buforowane dane, a wcześniej uzyskany obiekt może już nie odzwierciedlać wcześniejszego stanu. Jeśli potrzebujesz zachować wartości efektywne do późniejszego użycia, skopiuj wymagane właściwości, takie jak wysokość czcionki, kolor wypełnienia, styl czcionki lub wyrównanie, do własnego obiektu danych.
{{% /alert %}}

## **Pobierz efektywne właściwości kamery**

Aspose.Slides umożliwia pobranie efektywnych właściwości kamery. Interfejs [ICameraEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icameraeffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości kamery. Instancja [ICameraEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icameraeffectivedata/) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformateffectivedata/), które zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/).

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości kamery. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **Pobierz efektywne właściwości zestawu oświetlenia**

Aspose.Slides umożliwia pobranie efektywnych właściwości zestawu oświetlenia. Interfejs [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilightrigeffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości zestawu oświetlenia. Instancja [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilightrigeffectivedata/) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformateffectivedata/), które zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/).

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości zestawu oświetlenia. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **Pobierz efektywne właściwości sfazowanego kształtu**

Aspose.Slides umożliwia pobranie efektywnych właściwości sfazowanego kształtu. Interfejs [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapebeveleffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości reliefu kształtu. Instancja [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapebeveleffectivedata/) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformateffectivedata/), które zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ithreedformat/).

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości górnego sfazowania kształtu. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **Pobierz efektywne właściwości ramki tekstowej**

Korzystając z Aspose.Slides, możesz uzyskać efektywne właściwości ramki tekstowej. Interfejs [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframeformateffectivedata/) zawiera efektywne właściwości formatowania ramki tekstowej.

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości formatowania ramki tekstowej. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) z ramką tekstową.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **Pobierz efektywne właściwości stylu tekstu**

Korzystając z Aspose.Slides, możesz uzyskać efektywne właściwości stylu tekstu. Interfejs [ITextStyleEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextstyleeffectivedata/) zawiera efektywne właściwości stylu tekstu.

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości stylu tekstu. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) z ramką tekstową.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **Pobierz efektywną wartość wysokości czcionki**

Korzystając z Aspose.Slides, możesz uzyskać efektywną wysokość czcionki. Poniższy kod demonstruje, jak efektywna wysokość czcionki fragmentu zmienia się po ustawieniu lokalnych wartości wysokości czcionki na różnych poziomach struktury prezentacji.

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

## **Pobierz efektywny format wypełnienia tabeli**

Korzystając z Aspose.Slides, możesz uzyskać efektywne formatowanie wypełnienia dla różnych części tabeli. Interfejs [IFillFormatEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ifillformateffectivedata/) zawiera efektywne właściwości formatowania wypełnienia. Formatowanie komórki ma wyższy priorytet niż formatowanie wiersza, formatowanie wiersza ma wyższy priorytet niż formatowanie kolumny, a formatowanie kolumny ma wyższy priorytet niż formatowanie całej tabeli.

W rezultacie właściwości [ICellFormatEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icellformateffectivedata/) są używane do rysowania komórki tabeli. Poniższy przykład kodu pokazuje, jak uzyskać efektywne formatowanie wypełnienia dla różnych części tabeli. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [ITable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itable/).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy `getEffective()` zwraca migawkę?**

Nie zawsze. Dane efektywne reprezentują obliczone formatowanie po zastosowaniu dziedziczenia, ale niektóre obiekty danych efektywnych mogą być buforowane wewnętrznie. Kolejne wywołanie `getEffective()` może ponownie obliczyć formatowanie i odświeżyć buforowane dane, dlatego wcześniej uzyskany obiekt nie powinien być traktowany jako trwała migawka.

**Kiedy powinienem ponownie odczytać efektywne właściwości?**

Wywołaj `getEffective()` ponownie po zmianie lokalnego formatowania, stylów rodzica, formatowania układu, formatowania wzorca lub domyślnych ustawień na poziomie prezentacji. Kolejne wywołanie ponownie ocenia hierarchię formatowania i zwraca bieżący wynik efektywny.

**Czy zmiana lub usunięcie slajdu układu/wzoru wpływa na już pobrane efektywne właściwości?**

Tak, ale zmiana zostanie odzwierciedlona przy następnym wywołaniu `getEffective()`. Jeśli źródło formatowania rodzica zostanie zmienione lub usunięte, wcześniej uzyskane dane efektywne mogą stać się nieaktualne. Po ponownym wywołaniu `getEffective()` Aspose.Slides ponownie ocenia drzewo formatowania i wynikowe czcionki, kolory, rozmiary lub inne wartości mogą ulec zmianie.

**Czy mogę modyfikować wartości poprzez obiekty danych efektywnych?**

Nie. Obiekty danych efektywnych udostępniają obliczone wartości. Wprowadzaj zmiany w obiektach lokalnego formatowania, a następnie ponownie pobierz wartości efektywne.

**Co się stanie, jeśli właściwość nie jest ustawiona na poziomie kształtu, ani w układzie/wzorcu, ani w ustawieniach globalnych?**

Wartość efektywna jest określana przez mechanizm domyślny, który obejmuje domyślne ustawienia PowerPoint i Aspose.Slides. Ta rozwiązana wartość staje się częścią bieżących danych efektywnych.

**Czy na podstawie efektywnej wartości czcionki mogę określić, który poziom dostarczył rozmiar lub krój?**

Nie bezpośrednio. Dane efektywne zwracają wartość finalną. Aby znaleźć źródło, sprawdź lokalne wartości w fragmencie, akapicie, ramce tekstowej oraz stylach tekstu na poziomie układu, wzorca i prezentacji, aby zobaczyć, gdzie pojawia się pierwsza explicite definicja.

**Dlaczego efektywne wartości czasami wyglądają identycznie jak lokalne?**

Ponieważ wartość lokalna okazała się ostateczna (nie była wymagana dziedziczenie z wyższego poziomu). W takich przypadkach wartość efektywna jest identyczna z lokalną.

**Kiedy powinienem używać właściwości efektywnych, a kiedy pracować wyłącznie z lokalnymi?**

Używaj danych efektywnych, gdy potrzebny jest wynik „tak jak zostanie wyświetlone” po zastosowaniu całego dziedziczenia, np. w celu dopasowania kolorów, wcięć lub rozmiarów. Jeśli musisz zachować te wartości niezależnie od późniejszych zmian formatowania, skopiuj wymagane właściwości do własnego obiektu. Jeśli potrzebujesz zmienić formatowanie na określonym poziomie, zmodyfikuj właściwości lokalne, a w razie potrzeby ponownie odczytaj dane efektywne, aby zweryfikować rezultat.