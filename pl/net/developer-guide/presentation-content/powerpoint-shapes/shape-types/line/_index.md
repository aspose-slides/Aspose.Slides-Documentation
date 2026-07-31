---
title: Dodawanie kształtów linii do prezentacji w .NET
linktitle: Linia
type: docs
weight: 50
url: /pl/net/line/
keywords:
- linia
- tworzenie linii
- dodawanie linii
- prosta linia
- konfigurowanie linii
- dostosowywanie linii
- styl kreski
- grot strzałki
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Naucz się manipulować formatowaniem linii w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET. Odkryj właściwości, metody i przykłady."
---
## **Przegląd**

Aspose.Slides umożliwia programowe dodawanie kształtów linii do slajdów PowerPoint. Ten artykuł pokazuje, jak utworzyć prostą linię i jak dostosować linię, aby wyglądała jak strzałka.

Nauczysz się, jak dodać kształt linii do slajdu, dostosować jego wygląd oraz zapisać zmienioną prezentację. Przykłady koncentrują się na praktycznych ustawieniach formatowania linii, takich jak styl, szerokość, wzór kreski, opcje grotu strzałki i kolor wypełnienia.

## **Utworzenie prostej linii**
Aby dodać prostą linię do wybranego slajdu prezentacji, wykonaj następujące kroki:

- Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
- Pobierz odwołanie do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line za pomocą metody [AddAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/methods/addautoshape/index) udostępnionej przez obiekt Shapes.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy linię do pierwszego slajdu prezentacji.

```c#
 // Utwórz instancję klasy PresentationEx reprezentującej plik PPTX
using (Presentation pres = new Presentation())
{
    // Pobierz pierwszy slajd
    ISlide sld = pres.Slides[0];

    // Dodaj autoshape typu linia
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Zapisz plik PPTX na dysku
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Utworzenie linii w kształcie strzałki**
Aspose.Slides dla .NET umożliwia również programistom konfigurowanie niektórych właściwości linii, aby wyglądała bardziej atrakcyjnie. Spróbujmy skonfigurować kilka właściwości linii, aby przypominała strzałkę. Postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/pl/aspose.slides/)[](http://www.aspose.com/api/net/slides/pl/aspose.slides/).
- Pobierz odwołanie do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line za pomocą metody AddAutoShape udostępnionej przez obiekt Shapes.
- Ustaw styl linii na jeden z oferowanych przez Aspose.Slides dla .NET.
- Ustaw szerokość linii.
- Ustaw [Dash Style](https://reference.aspose.com/slides/pl/net/aspose.slides/linedashstyle) linii na jeden z stylów oferowanych przez Aspose.Slides dla .NET.
- Ustaw [Arrow Head Style](https://reference.aspose.com/slides/pl/net/aspose.slides/linearrowheadstyle) oraz długość grotu początkowego linii.
- Ustaw styl i długość grotu końcowego linii.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

```c#
 // Utwórz instancję klasy PresentationEx reprezentującej plik PPTX
using (Presentation pres = new Presentation())
{

    // Pobierz pierwszy slajd
    ISlide sld = pres.Slides[0];

    // Dodaj autoshape typu linia
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Zastosuj pewne formatowanie linii
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    // Zapisz plik PPTX na dysku
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy mogę zamienić zwykłą linię w łącznik, aby „przyciągała” się do kształtów?**

Nie. Zwykła linia ( [AutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/pl/net/aspose.slides/shapetype/) ) nie staje się automatycznie łącznikiem. Aby umożliwić przyciąganie do kształtów, użyj dedykowanego typu [Connector](https://reference.aspose.com/slides/pl/net/aspose.slides/connector/) oraz [odpowiednich interfejsów API](/slides/pl/net/connector/) do połączeń.

**Co zrobić, gdy właściwości linii są dziedziczone z motywu i trudno określić ich ostateczne wartości?**

[Przeczytaj właściwości efektywne](/slides/pl/net/shape-effective-properties/) za pośrednictwem interfejsów [ILineFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ilinefillformateffectivedata/) — te już uwzględniają dziedziczenie oraz style motywu.

**Czy mogę zablokować linię przed edycją (przemieszczaniem, zmianą rozmiaru)?**

Tak. Kształty udostępniają [obiekty blokady](https://reference.aspose.com/slides/pl/net/aspose.slides/autoshape/autoshapelock/), które pozwalają [zabronić operacji edycyjnych](/slides/pl/net/applying-protection-to-presentation/).