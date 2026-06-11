---
title: Dodaj kształty linii do prezentacji w .NET
linktitle: Linia
type: docs
weight: 50
url: /pl/net/Line/
keywords:
- linia
- utwórz linię
- dodaj linię
- prosta linia
- skonfiguruj linię
- dostosuj linię
- styl kreski
- grot strzałki
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Naucz się manipulować formatowaniem linii w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET. Poznaj właściwości, metody i przykłady."
---
## **Przegląd**

Aspose.Slides umożliwia programowe dodawanie kształtów linii do slajdów PowerPoint. Ten artykuł pokazuje, jak utworzyć prostą linię oraz jak dostosować linię, aby wyglądała jak strzałka.

Dowiesz się, jak dodać kształt linii do slajdu, zmienić jej wygląd oraz zapisać zaktualizowaną prezentację. Przykłady koncentrują się na praktycznych ustawieniach formatowania linii, takich jak styl, szerokość, wzór kreski, opcje grotów i kolor wypełnienia.

## **Utwórz prostą linię**
Aby dodać prostą, nieozdobioną linię do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję [Prezentacja](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation)class.
- Uzyskaj odniesienie do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line za pomocą metody [AddAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/methods/addautoshape/index) udostępnionej przez obiekt Shapes.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy linię do pierwszego slajdu prezentacji.

```c#
// Utwórz klasę PresentationEx reprezentującą plik PPTX
using (Presentation pres = new Presentation())
{
    // Pobierz pierwszy slajd
    ISlide sld = pres.Slides[0];

    // Dodaj autoshape typu line
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Zapisz plik PPTX na dysk
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **Utwórz linię w kształcie strzałki**
Aspose.Slides for .NET umożliwia również konfigurację niektórych właściwości linii, aby wyglądała bardziej atrakcyjnie. Spróbujmy skonfigurować kilka właściwości linii, aby przypominała strzałkę. Postępuj zgodnie z poniższymi krokami:

- Utwórz instancję [Prezentacja](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/pl/aspose.slides/)[](http://www.aspose.com/api/net/slides/pl/aspose.slides/).
- Uzyskaj odniesienie do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Line za pomocą metody AddAutoShape udostępnionej przez obiekt Shapes.
- Ustaw styl linii na jeden ze stylów oferowanych przez Aspose.Slides for .NET.
- Ustaw szerokość linii.
- Ustaw [Dash Style](https://reference.aspose.com/slides/pl/net/aspose.slides/linedashstyle) linii na jeden ze stylów oferowanych przez Aspose.Slides for .NET.
- Ustaw [Arrow Head Style](https://reference.aspose.com/slides/pl/net/aspose.slides/linearrowheadstyle) i długość punktu początkowego linii.
- Ustaw Arrow Head Style i długość punktu końcowego linii.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

```c#
 // Utwórz klasę PresentationEx reprezentującą plik PPTX
using (Presentation pres = new Presentation())
{

    // Pobierz pierwszy slajd
    ISlide sld = pres.Slides[0];

    // Dodaj autoshape typu line
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Zastosuj formatowanie linii
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    // Zapisz plik PPTX na dysk
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Czy mogę zamienić zwykłą linię w łącznik, aby „przyczepiała” się do kształtów?**

Nie. Zwykła linia (AutoShape typu Line) nie przekształca się automatycznie w łącznik. Aby przyczepić ją do kształtów, użyj dedykowanego typu [Connector](https://reference.aspose.com/slides/pl/net/aspose.slides/connector/) oraz [odpowiednich interfejsów API](/slides/pl/net/connector/) do połączeń.

**Co zrobić, gdy właściwości linii są dziedziczone z motywu i trudno określić ich ostateczne wartości?**

[Przeczytaj właściwości efektywne](/slides/pl/net/shape-effective-properties/) za pomocą interfejsów [ILineFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/pl/net/aspose.slides/ilinefillformateffectivedata/); już one uwzględniają dziedziczenie i style motywu.

**Czy mogę zablokować linię przed edycją (przemieszczaniem, zmianą rozmiaru)?**

Tak. Kształty udostępniają [obiekty blokady](https://reference.aspose.com/slides/pl/net/aspose.slides/autoshape/autoshapelock/), które pozwalają [zablokować operacje edycji](/slides/pl/net/applying-protection-to-presentation/).