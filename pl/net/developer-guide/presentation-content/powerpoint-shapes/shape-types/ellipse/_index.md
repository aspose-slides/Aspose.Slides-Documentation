---
title: Dodawanie elips do prezentacji w .NET
linktitle: Elipsa
type: docs
weight: 30
url: /pl/net/ellipse/
keywords:
- elipsa
- kształt
- dodaj elipsę
- utwórz elipsę
- narysuj elipsę
- sformatowana elipsa
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak tworzyć, formatować i manipulować kształtami elips w Aspose.Slides dla .NET w prezentacjach PPT i PPTX — przykłady kodu w C#."
---
## **Przegląd**

Ten artykuł pokazuje, jak dodać kształty elipsy do slajdów PowerPoint przy użyciu Aspose.Slides. Omówiono tworzenie prostej elipsy, tworzenie sformatowanej elipsy oraz zapisywanie zaktualizowanej prezentacji jako pliku PPTX. Poruszono także powiązane zagadnienia, takie jak pozycjonowanie i rozmiar elipsy, kontrolowanie kolejności nakładania oraz stosowanie efektów animacji.

## **Utwórz elipsę**
Aby dodać prostą elipsę do wybranego slajdu prezentacji, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation)class
1. Uzyskaj odniesienie do slajdu, używając jego indeksu
1. Dodaj AutoShape typu Ellipse przy użyciu metody AddAutoShape udostępnionej przez obiekt IShapes
1. Zapisz zmodyfikowaną prezentację jako plik PPTX

W poniższym przykładzie dodaliśmy elipsę do pierwszego slajdu.

```c#
// Utwórz instancję klasy Presentation reprezentującej plik PPTX
using (Presentation pres = new Presentation())
{

    // Pobierz pierwszy slajd
    ISlide sld = pres.Slides[0];

    // Dodaj kształt automatyczny typu elipsa
    sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    //Zapisz plik PPTX na dysku
    pres.Save("EllipseShp1_out.pptx", SaveFormat.Pptx);
}
```



## **Utwórz sformatowaną elipsę**
Aby dodać lepiej sformatowaną elipsę do slajdu, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation)class.
1. Uzyskaj odniesienie do slajdu, używając jego indeksu.
1. Dodaj AutoShape typu Ellipse przy użyciu metody AddAutoShape udostępnionej przez obiekt IShapes.
1. Ustaw typ wypełnienia elipsy na Solid.
1. Ustaw kolor elipsy, używając właściwości SolidFillColor.Color udostępnionej przez obiekt FillFormat powiązany z obiektem IShape.
1. Ustaw kolor linii elipsy.
1. Ustaw szerokość linii elipsy.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy sformatowaną elipsę do pierwszego slajdu prezentacji.

```c#
// Utwórz instancję klasy Presentation reprezentującej plik PPTX
using (Presentation pres = new Presentation())
{

    // Pobierz pierwszy slajd
    ISlide sld = pres.Slides[0];

    // Dodaj kształt automatyczny typu elipsa
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Zastosuj pewne formatowanie do kształtu elipsy
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // Zastosuj pewne formatowanie do linii elipsy
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //Zapisz plik PPTX na dysku
    pres.Save("EllipseShp2_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Jak ustawić dokładną pozycję i rozmiar elipsy względem jednostek slajdu?**

Współrzędne i rozmiary podaje się zazwyczaj **w punktach**. Aby uzyskać przewidywalne wyniki, bazuj obliczenia na rozmiarze slajdu i przelicz wymagane milimetry lub cale na punkty przed przypisaniem wartości.

**Jak umieścić elipsę nad lub pod innymi obiektami (kontrola kolejności nakładania)?**

Dostosuj kolejność rysowania obiektu, przenosząc go na wierzch lub wysyłając na spód. Dzięki temu elipsa może nakładać się na inne obiekty lub odsłaniać te znajdujące się pod nią.

**Jak animować pojawienie się lub podkreślenie elipsy?**

[Apply](/slides/pl/net/shape-animation/) efekty wejścia, podkreślenia lub wyjścia do kształtu oraz skonfiguruj wyzwalacze i timing, aby określić, kiedy i w jaki sposób animacja ma się odtworzyć.