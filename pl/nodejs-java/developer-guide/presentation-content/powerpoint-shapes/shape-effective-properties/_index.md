---
title: Pobierz efektywne właściwości kształtu z prezentacji w JavaScript
linktitle: Efektywne właściwości
type: docs
weight: 50
url: /pl/nodejs-java/shape-effective-properties/
keywords:
- właściwości kształtu
- właściwości kamery
- oświetlenie
- kształt sfazowany
- ramka tekstowa
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides dla Node.js przy użyciu Javy oblicza i stosuje efektywne właściwości kształtów, aby precyzyjnie renderować prezentacje w PowerPoint."
---
## **Przegląd**

Ten temat wyjaśnia różnicę między właściwościami **lokalnymi** i **efektywnymi**. Wartości lokalne to wartości ustawiane bezpośrednio na określonym poziomie formatowania, np.:

1. Właściwości fragmentu na slajdzie.  
1. Style tekstu prototypu kształtu na układzie lub slajdzie mistrza, gdy kształt ramki tekstowej fragmentu posiada je.  
1. Globalne ustawienia tekstu w prezentacji.

Wartości lokalne mogą być definiowane lub pomijane na dowolnym poziomie. Gdy Aspose.Slides potrzebuje ostatecznego formatowania „takiego, jak jest renderowane”, rozwiązuje łańcuch dziedziczenia i zwraca **wartości efektywne**. Można je uzyskać, wywołując metodę `getEffective` na obiekcie formatu lokalnego.

Poniższy przykład pokazuje, jak pobrać wartości efektywne. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) z ramką tekstową i przynajmniej jednym fragmentem.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Dane formatowania efektywnego reprezentują bieżące obliczone formatowanie po zastosowaniu dziedziczenia. W bieżącej implementacji niektóre obiekty danych efektywnych mogą być przechowywane w pamięci podręcznej wewnętrznie. Ponowne wywołanie `getEffective` po zmianie formatowania rodzica lub dziedziczonego może odświeżyć pamięć podręczną, a wcześniej uzyskany obiekt może już nie odzwierciedlać wcześniejszego stanu. Jeśli potrzebujesz zachować wartości efektywne do późniejszego wykorzystania, skopiuj wymagane właściwości, takie jak wysokość czcionki, kolor wypełnienia, styl czcionki lub wyrównanie, do własnego obiektu danych.
{{% /alert %}}

## **Pobierz efektywne właściwości kamery**

Aspose.Slides umożliwia pobranie efektywnych właściwości kamery. Obiekt danych kamery efektywnej zawiera niezmienne właściwości kamery i jest udostępniany poprzez wartości efektywne zwracane dla [ThreeDFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/).

Poniższy przykład kodu pokazuje, jak pobrać efektywne właściwości kamery. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **Pobierz efektywne właściwości Light Rig**

Aspose.Slides umożliwia pobranie efektywnych właściwości Light Rig. Obiekt danych Light Rig efektywnego zawiera niezmienne właściwości oświetlenia i jest udostępniany poprzez wartości efektywne zwracane dla [ThreeDFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/).

Poniższy przykład kodu pokazuje, jak pobrać efektywne właściwości Light Rig. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **Pobierz efektywne właściwości kształtu Bevel**

Aspose.Slides umożliwia pobranie efektywnych właściwości kształtu Bevel. Obiekt danych kształtu Bevel efektywnego zawiera niezmienne właściwości wypukłości kształtu i jest udostępniany poprzez wartości efektywne zwracane dla [ThreeDFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/threedformat/).

Poniższy przykład kodu pokazuje, jak pobrać efektywne właściwości górnego bevelu kształtu. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **Pobierz efektywne właściwości ramki tekstowej**

Używając Aspose.Slides, możesz pobrać efektywne właściwości ramki tekstowej. Zwrócony obiekt danych efektywnych zawiera właściwości formatowania ramki tekstowej.

Poniższy przykład kodu pokazuje, jak pobrać efektywne właściwości formatowania ramki tekstowej. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) z ramką tekstową.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **Pobierz efektywne właściwości stylu tekstu**

Używając Aspose.Slides, możesz pobrać efektywne właściwości stylu tekstu. Zwrócony obiekt danych efektywnych zawiera właściwości stylu tekstu.

Poniższy przykład kodu pokazuje, jak pobrać efektywne właściwości stylu tekstu. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) z ramką tekstową.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **Pobierz efektywną wartość wysokości czcionki**

Używając Aspose.Slides, możesz pobrać efektywną wysokość czcionki. Poniższy kod demonstruje, jak efektywna wysokość czcionki fragmentu zmienia się po ustawieniu lokalnych wartości wysokości czcionki na różnych poziomach struktury prezentacji.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **Pobierz efektywny format wypełnienia tabeli**

Używając Aspose.Slides, możesz pobrać efektywne formatowanie wypełnienia dla różnych części tabeli. Zwrócony obiekt danych efektywnych zawiera właściwości formatowania wypełnienia. Formatowanie komórki ma wyższy priorytet niż formatowanie wiersza, formatowanie wiersza ma wyższy priorytet niż formatowanie kolumny, a formatowanie kolumny ma wyższy priorytet niż formatowanie całej tabeli.

W rezultacie używane są właściwości efektywnego formatowania komórki do rysowania komórki tabeli. Poniższy przykład kodu pokazuje, jak pobrać efektywne formatowanie wypełnienia dla różnych części tabeli. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/table/).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Czy `getEffective` zwraca migawkę?**

Nie zawsze. Dane efektywne reprezentują obliczone formatowanie po zastosowaniu dziedziczenia, ale niektóre obiekty danych efektywnych mogą być przechowywane w pamięci podręcznej wewnętrznie. Kolejne wywołanie `getEffective` może ponownie obliczyć formatowanie i odświeżyć pamięć podręczną, więc wcześniej uzyskany obiekt nie powinien być traktowany jako trwała migawka.

**Kiedy powinienem ponownie odczytać efektywne właściwości?**

Wywołaj ponownie `getEffective` po zmianie formatowania lokalnego, stylów rodzica, formatowania układu, formatowania mistrza lub domyślnych ustawień na poziomie prezentacji. Następne wywołanie ponownie oceni hierarchię formatowania i zwróci bieżący wynik efektywny.

**Czy zmiana lub usunięcie slajdu układu/mistrza wpływa na już pobrane efektywne właściwości?**

Tak, ale zmiana zostanie uwzględniona przy następnym wywołaniu `getEffective`. Jeśli źródło formatowania rodzica zostanie zmienione lub usunięte, wcześniej pobrane dane efektywne mogą być nieaktualne. Po ponownym wywołaniu `getEffective` Aspose.Slides ponownie oceni drzewo formatowania i wynikowe czcionki, kolory, rozmiary lub inne wartości mogą się zmienić.

**Czy mogę modyfikować wartości za pomocą obiektów danych efektywnych?**

Nie. Obiekty danych efektywnych udostępniają obliczone wartości. Wprowadzaj zmiany w obiektach formatowania lokalnego, a następnie ponownie pobierz wartości efektywne.

**Co się stanie, jeśli właściwość nie jest ustawiona na poziomie kształtu, ani w układzie/mistrzu, ani w ustawieniach globalnych?**

Wartość efektywna jest określana przez mechanizm domyślny, który obejmuje ustawienia domyślne PowerPointa i Aspose.Slides. Ta wyznaczona wartość staje się częścią bieżących danych efektywnych.

**Czy na podstawie efektywnej wartości czcionki mogę określić, który poziom podał rozmiar lub krój?**

Nie bezpośrednio. Dane efektywne zwracają wartość końcową. Aby znaleźć źródło, sprawdź wartości lokalne w fragmencie, akapicie, ramce tekstowej oraz stylach tekstu na poziomach układu, mistrza i prezentacji, aby zobaczyć, gdzie pojawia się pierwsza explicytna definicja.

**Dlaczego efektywne wartości czasami wyglądają identycznie jak lokalne?**

Ponieważ wartość lokalna okazała się ostateczna (nie wymagała dziedziczenia z wyższego poziomu). W takich przypadkach wartość efektywna jest taka sama jak lokalna.

**Kiedy powinienem używać właściwości efektywnych, a kiedy pracować tylko z lokalnymi?**

Używaj danych efektywnych, gdy potrzebny jest wynik „tak jak jest renderowany” po zastosowaniu całego dziedziczenia, np. do dopasowania kolorów, wcięć lub rozmiarów. Jeśli musisz zachować te wartości niezależnie od późniejszych zmian formatowania, skopiuj wymagane właściwości do własnego obiektu. Jeśli potrzebujesz zmienić formatowanie na określonym poziomie, zmodyfikuj właściwości lokalne, a następnie, w razie potrzeby, ponownie odczytaj dane efektywne, aby zweryfikować rezultat.