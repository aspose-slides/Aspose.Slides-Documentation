---
title: Dodaj kształty linii do prezentacji na Androidzie
linktitle: Linia
type: docs
weight: 50
url: /pl/androidjava/line/
keywords:
- linia
- tworzenie linii
- dodaj linię
- prosta linia
- konfiguracja linii
- dostosowanie linii
- styl kreski
- groty strzałki
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Naucz się manipulować formatowaniem linii w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Androida. Odkryj właściwości, metody i przykłady w języku Java."
---
## **Przegląd**

Aspose.Slides umożliwia programowe dodawanie kształtów linii do slajdów PowerPoint. Ten artykuł pokazuje, jak utworzyć prostą linię oraz jak dostosować linię, aby wyglądała jak strzałka.

Nauczysz się, jak dodać kształt linii do slajdu, zmienić jego wygląd i zapisać zaktualizowaną prezentację. Przykłady koncentrują się na praktycznych ustawieniach formatowania linii, takich jak styl, szerokość, wzór przerywania, opcje grotu strzałki i kolor wypełnienia.

## **Utworzenie prostej linii**

Aby dodać prostą linię do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [IShapeCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection).
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W przykładzie poniżej dodaliśmy linię do pierwszego slajdu prezentacji.

```java
// Utwórz instancję klasy PresentationEx, która reprezentuje plik PPTX
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

Aspose.Slides for Android via Java umożliwia także skonfigurowanie niektórych właściwości linii, aby wyglądała bardziej atrakcyjnie. Spróbujmy skonfigurować kilka właściwości linii, aby wyglądała jak strzałka. Postępuj według poniższych kroków:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [IShapeCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection).
- Ustaw [Line Style](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LineStyle) na jeden ze stylów oferowanych przez Aspose.Slides for Android via Java.
- Ustaw szerokość linii.
- Ustaw [Dash Style](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LineDashStyle) linii na jeden ze stylów oferowanych przez Aspose.Slides for Android via Java.
- Ustaw [Arrow Head Style](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LineArrowheadStyle) oraz [Length](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LineArrowheadLength) punktu początkowego linii.
- Ustaw [Arrow Head Style](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LineArrowheadStyle) oraz [Length](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LineArrowheadLength) punktu końcowego linii.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
// Utwórz instancję klasy PresentationEx, która reprezentuje plik PPTX
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

Nie. Zwykła linia (an [AutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/autoshape/) of type [Line](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shapetype/)) does not automatically become a connector. To make it snap to shapes, use the dedicated [Connector](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/connector/) type and the [odpowiednie API](/slides/pl/androidjava/connector/) for connections.

**Co zrobić, gdy właściwości linii są dziedziczone z motywu i trudno określić ostateczne wartości?**

[Przeczytaj właściwości efektywne](/slides/pl/androidjava/shape-effective-properties/) poprzez interfejsy [ILineFormatEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — już uwzględniają dziedziczenie i style motywu.

**Czy mogę zablokować linię przed edycją (przemieszczaniem, zmianą rozmiaru)?**

Tak. Shapes provide [lock objects](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) that let you disallow editing operations.