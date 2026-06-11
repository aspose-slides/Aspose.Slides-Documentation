---
title: Dodaj kształty linii do prezentacji na Androidzie
linktitle: Linia
type: docs
weight: 50
url: /pl/androidjava/Line/
keywords:
- linia
- tworzenie linii
- dodawanie linii
- prosta linia
- konfigurowanie linii
- dostosowywanie linii
- styl przerywany
- grot strzałki
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak manipulować formatowaniem linii w prezentacjach PowerPoint przy użyciu Aspose.Slides for Android. Odkryj właściwości, metody i przykłady w języku Java."
---
## **Przegląd**

Aspose.Slides pozwala programowo dodawać kształty linii do slajdów PowerPoint. Ten artykuł pokazuje, jak utworzyć prostą linię oraz jak dostosować linię, aby wyglądała jak strzałka.

Nauczysz się, jak dodać kształt linii do slajdu, dostosować jego wygląd oraz zapisać zaktualizowaną prezentację. Przykłady koncentrują się na praktycznych ustawieniach formatowania linii, takich jak styl, grubość, wzór przerywania, opcje grotu strzałki oraz kolor wypełnienia.

## **Utwórz prostą linię**

Aby dodać prostą linię do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line, używając metody [addAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [IShapeCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection).
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy linię do pierwszego slajdu prezentacji.

```java
// Utwórz klasę PresentationEx, która reprezentuje plik PPTX
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

## **Utwórz linię w kształcie strzałki**

Aspose.Slides for Android via Java pozwala również programistom konfigurować niektóre właściwości linii, aby wyglądała bardziej atrakcyjnie. Spróbujmy skonfigurować kilka właściwości linii, aby wyglądała jak strzałka. Postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line, używając metody [addAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [IShapeCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection).
- Ustaw [Line Style](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LineStyle) na jeden ze stylów oferowanych przez Aspose.Slides for Android via Java.
- Ustaw szerokość (Width) linii.
- Ustaw [Dash Style](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LineDashStyle) linii na jeden ze stylów oferowanych przez Aspose.Slides for Android via Java.
- Ustaw [Arrow Head Style](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LineArrowheadStyle) i [Length](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LineArrowheadLength) punktu początkowego linii.
- Ustaw [Arrow Head Style](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LineArrowheadStyle) i [Length](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LineArrowheadLength) punktu końcowego linii.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
// Utwórz klasę PresentationEx, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);

    // Dodaj AutoShape typu linia
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Zastosuj formatowanie linii
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

**Czy mogę zamienić zwykłą linię w łącznik, aby „przyczepiała się” do kształtów?**

Nie. Zwykła linia ( [AutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shapetype/)) nie przekształca się automatycznie w łącznik. Aby przyczepić ją do kształtów, użyj dedykowanego typu [Connector](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/connector/) oraz [corresponding APIs](/slides/pl/androidjava/connector/) do połączeń.

**Co zrobić, gdy właściwości linii są dziedziczone z motywu i trudno określić ostateczne wartości?**

[Read the effective properties](/slides/pl/androidjava/shape-effective-properties/) poprzez interfejsy [ILineFormatEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — już uwzględniają dziedziczenie i style motywu.

**Czy mogę zablokować linię przed edycją (przemieszczaniem, zmianą rozmiaru)?**

Tak. Kształty udostępniają [lock objects](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) , które umożliwiają blokowanie operacji edycji.