---
title: Dodawanie prostokątów do prezentacji w .NET
linktitle: Prostokąt
type: docs
weight: 80
url: /pl/net/rectangle/
keywords:
- dodaj prostokąt
- utwórz prostokąt
- kształt prostokąta
- prosty prostokąt
- sformatowany prostokąt
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zwiększ jakość swoich prezentacji PowerPoint, dodając prostokąty przy użyciu Aspose.Slides dla .NET - łatwo projektuj i modyfikuj kształty programowo."
---
## **Przegląd**

Ten artykuł pokazuje, jak dodawać prostokątne kształty do slajdów PowerPoint przy użyciu Aspose.Slides. Omówiono tworzenie prostego prostokąta, tworzenie sformatowanego prostokąta oraz zapisywanie zaktualizowanej prezentacji jako plik PPTX.

Zobaczysz także, jak zastosować podstawowe formatowanie prostokąta, takie jak jednolity kolor wypełnienia, kolor linii i grubość linii. Dodatkowo sekcja FAQ artykułu wskazuje powiązane zadania związane z prostokątami, w tym zaokrąglone rogi, wypełnienia obrazem, efekty wizualne, hiperlinki, blokady kształtów, opcje eksportu i właściwości efektywne.

## **Utworzenie prostego prostokąta**
Podobnie jak w poprzednich tematach, i tutaj chodzi o dodanie kształtu, a konkretnie prostokąta. W tym temacie opisaliśmy, jak programiści mogą dodawać proste lub sformatowane prostokąty do swoich slajdów przy użyciu Aspose.Slides dla .NET. Aby dodać prosty prostokąt do wybranego slajdu prezentacji, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję [Prezentacja ](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation)class.
2. Uzyskaj odniesienie do slajdu, używając jego indeksu.
3. Dodaj IAutoShape typu Rectangle za pomocą metody AddAutoShape udostępnionej przez obiekt IShapes.
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy prosty prostokąt do pierwszego slajdu prezentacji.

```c#
// Utwórz instancję klasy Presentation reprezentującej plik PPTX
using (Presentation pres = new Presentation())
{
    // Pobierz pierwszy slajd
    ISlide sld = pres.Slides[0];

    // Dodaj kształt autogenerowany typu prostokąt
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //Zapisz plik PPTX na dysku
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```

## **Utworzenie sformatowanego prostokąta**
Aby dodać sformatowany prostokąt do slajdu, wykonaj następujące kroki:

1. Utwórz instancję [Prezentacja ](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation)class.
2. Uzyskaj odniesienie do slajdu, używając jego indeksu.
3. Dodaj IAutoShape typu Rectangle za pomocą metody AddAutoShape udostępnionej przez obiekt IShapes.
4. Ustaw typ wypełnienia prostokąta na Solid.
5. Ustaw kolor prostokąta, korzystając z właściwości SolidFillColor.Color udostępnionej przez obiekt FillFormat powiązany z obiektem IShape.
6. Ustaw kolor linii prostokąta.
7. Ustaw szerokość linii prostokąta.
8. Zapisz zmodyfikowaną prezentację jako plik PPTX.
   Powyższe kroki są zaimplementowane w przykładzie poniżej.

```c#
 // Utwórz instancję klasy Presentation reprezentującej plik PPTX
 using (Presentation pres = new Presentation())
 {
 
     // Pobierz pierwszy slajd
     ISlide sld = pres.Slides[0];
 
     // Dodaj autokształt typu prostokąt
     IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);
 
     // Zastosuj pewne formatowanie do kształtu prostokąta
     shp.FillFormat.FillType = FillType.Solid;
     shp.FillFormat.SolidFillColor.Color = Color.Chocolate;
 
     // Zastosuj pewne formatowanie do linii prostokąta
     shp.LineFormat.FillFormat.FillType = FillType.Solid;
     shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
     shp.LineFormat.Width = 5;
 
     //Zapisz plik PPTX na dysku
     pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **FAQ**

**Jak dodać prostokąt z zaokrąglonymi rogami?**

Użyj typu kształtu [shape type](https://reference.aspose.com/slides/pl/net/aspose.slides/shapetype/) z zaokrąglonymi rogami i dostosuj promień rogu w właściwościach kształtu; zaokrąglenie można również zastosować dla każdego rogu osobno za pomocą modyfikacji geometrii.

**Jak wypełnić prostokąt obrazem (teksturą)?**

Wybierz typ wypełnienia [fill type](https://reference.aspose.com/slides/pl/net/aspose.slides/filltype/), podaj źródło obrazu i skonfiguruj tryby [stretching/tiling modes](https://reference.aspose.com/slides/pl/net/aspose.slides/picturefillmode/).

**Czy prostokąt może mieć cień i poświatę?**

Tak. [Outer/inner shadow, glow, and soft edges](/slides/pl/net/shape-effect/) są dostępne z regulowanymi parametrami.

**Czy mogę zamienić prostokąt w przycisk z hiperlinkiem?**

Tak. [Assign a hyperlink](/slides/pl/net/manage-hyperlinks/) do kliknięcia kształtu (przejście do slajdu, pliku, adresu internetowego lub e‑maila).

**Jak zabezpieczyć prostokąt przed przenoszeniem i zmianami?**

[Use shape locks](/slides/pl/net/applying-protection-to-presentation/): możesz zabronić przenoszenia, zmiany rozmiaru, zaznaczania lub edycji tekstu, aby zachować układ.

**Czy mogę przekonwertować prostokąt na obraz rastrowy lub SVG?**

Tak. Możesz [render the shape](http://reference.aspose.com/slides/pl/net/aspose.slides/shape/getimage/) do obrazu o określonym rozmiarze/skali lub [export it as SVG](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/writeassvg/) w celu użycia wektorowego.

**Jak szybko uzyskać rzeczywiste (efektywne) właściwości prostokąta, uwzględniając motyw i dziedziczenie?**

[Use the shape’s effective properties](/slides/pl/net/shape-effective-properties/): API zwraca obliczone wartości, które uwzględniają style motywu, układ i ustawienia lokalne, upraszczając analizę formatowania.