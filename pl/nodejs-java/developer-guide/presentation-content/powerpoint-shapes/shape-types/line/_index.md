---
title: Dodaj kształty linii do prezentacji w JavaScript
linktitle: Linia
type: docs
weight: 50
url: /pl/nodejs-java/line/
keywords:
- linia
- utwórz linię
- dodaj linię
- prosta linia
- konfiguruj linię
- dostosuj linię
- styl kreski
- końcówka strzałki
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Naucz się manipulować formatowaniem linii w prezentacjach PowerPoint przy użyciu JavaScript i Aspose.Slides dla Node.js. Odkryj właściwości, metody i przykłady."
---
## **Przegląd**

Aspose.Slides umożliwia programowe dodawanie kształtów linii do slajdów PowerPoint. Ten artykuł pokazuje, jak utworzyć prostą linię oraz jak dostosować linię, aby wyglądała jak strzałka.

Nauczysz się, jak dodać kształt linii do slajdu, dostosować jej wygląd oraz zapisać zaktualizowaną prezentację. Przykłady koncentrują się na praktycznych ustawieniach formatowania linii, takich jak styl, szerokość, wzór przerywania, opcje zakończenia strzałką oraz kolor wypełnienia.

## **Utwórz prostą linię**

Aby dodać prostą linię do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line za pomocą metody [addAutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection).
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy linię do pierwszego slajdu prezentacji.

```javascript
// Utwórz instancję klasy PresentationEx, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd
    var sld = pres.getSlides().get_Item(0);
    // Dodaj AutoShape typu linia
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Zapisz plik PPTX na dysku
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Utwórz linię w kształcie strzałki**

Aspose.Slides for Node.js via Java umożliwia także programistom konfigurowanie niektórych właściwości linii, aby wyglądała bardziej atrakcyjnie. Spróbujmy skonfigurować kilka właściwości linii, aby przypominała strzałkę. Wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line za pomocą metody [addAutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection).
- Ustaw [Line Style](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/LineStyle) na jeden ze stylów oferowanych przez Aspose.Slides for Node.js via Java.
- Ustaw Width linii.
- Ustaw [Dash Style](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/LineDashStyle) linii na jeden ze stylów oferowanych przez Aspose.Slides for Node.js via Java.
- Ustaw [Arrow Head Style](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/LineArrowheadStyle) oraz [Length](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/LineArrowheadLength) punktu początkowego linii.
- Ustaw [Arrow Head Style](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/LineArrowheadStyle) oraz [Length](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/LineArrowheadLength) punktu końcowego linii.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

```javascript
// Utwórz instancję klasy PresentationEx, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd
    var sld = pres.getSlides().get_Item(0);
    // Dodaj AutoShape typu linia
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Zastosuj formatowanie linii
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Zapisz plik PPTX na dysku
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę przekształcić zwykłą linię w łącznik, aby „przyciągała” się do kształtów?**

Nie. Zwykła linia ( [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapetype/) ) nie staje się automatycznie łącznikiem. Aby przyciągała się do kształtów, użyj dedykowanego typu [Connector](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/connector/) oraz [odpowiednich interfejsów API](/slides/pl/nodejs-java/connector/) do połączeń.

**Co zrobić, gdy właściwości linii są dziedziczone z motywu i trudno określić ostateczne wartości?**

[Read the effective properties](/slides/pl/nodejs-java/shape-effective-properties/) za pomocą klas `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` — klasy te już uwzględniają dziedziczenie i style motywu.

**Czy mogę zablokować linię przed edycją (przemieszczaniem, zmianą rozmiaru)?**

Tak. Kształty udostępniają [lock objects](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/getautoshapelock/), które pozwalają uniemożliwić operacje edycji.