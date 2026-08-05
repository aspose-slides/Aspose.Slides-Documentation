---
title: Dodawanie kształtów linii do prezentacji w Javie
linktitle: Linia
type: docs
weight: 50
url: /pl/java/line/
keywords:
- linia
- tworzenie linii
- dodaj linię
- zwykła linia
- konfiguracja linii
- dostosowanie linii
- styl kreski
- główka strzałki
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Poznaj manipulację formatowaniem linii w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Javy. Odkryj właściwości, metody i przykłady."
---
## **Przegląd**

Aspose.Slides umożliwia programowe dodawanie kształtów linii do slajdów PowerPoint. Ten artykuł pokazuje, jak utworzyć prostą linię oraz jak dostosować linię, aby wyglądała jak strzałka.

Nauczysz się, jak dodać kształt linii do slajdu, dostosować jego wygląd oraz zapisać zaktualizowaną prezentację. Przykłady koncentrują się na praktycznych ustawieniach formatowania linii, takich jak styl, szerokość, wzór kreski, opcje końcówek strzałki i kolor wypełnienia.

## **Utworzenie prostej linii**

Aby dodać prostą, zwykłą linię do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [IShapeCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection).
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy linię do pierwszego slajdu prezentacji.

```java
// Utwórz instancję klasy PresentationEx reprezentującej plik PPTX
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Dodaj AutoShape typu linia
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Zapisz plik PPTX na dysk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Utworzenie linii w kształcie strzałki**

Aspose.Slides for Java umożliwia również programistom konfigurowanie niektórych właściwości linii, aby wyglądała bardziej atrakcyjnie. Spróbujmy skonfigurować kilka właściwości linii, aby przypominała strzałkę. Postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [IShapeCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection).
- Ustaw [Line Style](https://reference.aspose.com/slides/pl/java/com.aspose.slides/LineStyle) na jeden ze stylów dostępnych w Aspose.Slides for Java.
- Ustaw szerokość linii.
- Ustaw [Dash Style](https://reference.aspose.com/slides/pl/java/com.aspose.slides/LineDashStyle) linii na jeden ze stylów oferowanych przez Aspose.Slides for Java.
- Ustaw [Arrow Head Style](https://reference.aspose.com/slides/pl/java/com.aspose.slides/LineArrowheadStyle) oraz [Length](https://reference.aspose.com/slides/pl/java/com.aspose.slides/LineArrowheadLength) punktu początkowego linii.
- Ustaw [Arrow Head Style](https://reference.aspose.com/slides/pl/java/com.aspose.slides/LineArrowheadStyle) oraz [Length](https://reference.aspose.com/slides/pl/java/com.aspose.slides/LineArrowheadLength) punktu końcowego linii.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
// Utwórz instancję klasy PresentationEx reprezentującej plik PPTX
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);

    // Dodaj AutoShape typu linia
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Zastosuj pewne formatowanie linii
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Zapisz plik PPTX na dysk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę przekształcić zwykłą linię w łącznik, aby „przyciągała” się do kształtów?**

Nie. Zwykła linia ( [AutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shapetype/)) nie zmienia się automatycznie w łącznik. Aby przyciągała się do kształtów, użyj dedykowanego typu [Connector](https://reference.aspose.com/slides/pl/java/com.aspose.slides/connector/) oraz [odpowiednich interfejsów API](/slides/pl/java/connector/) do połączeń.

**Co zrobić, jeśli właściwości linii są dziedziczone z motywu i trudno określić ostateczne wartości?**

[Przeczytaj właściwości efektywne](/slides/pl/java/shape-effective-properties/) za pomocą interfejsów [ILineFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ilinefillformateffectivedata/) — już uwzględniają one dziedziczenie i style motywu.

**Czy mogę zablokować linię przed edycją (przesuwaniem, zmianą rozmiaru)?**

Tak. Kształty udostępniają [obiekty blokady](https://reference.aspose.com/slides/pl/java/com.aspose.slides/autoshape/#getAutoShapeLock--) pozwalające [zablokować operacje edycji](/slides/pl/java/applying-protection-to-presentation/).