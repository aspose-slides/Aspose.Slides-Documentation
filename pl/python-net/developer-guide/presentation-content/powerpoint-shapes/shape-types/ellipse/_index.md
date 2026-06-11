---
title: Dodawanie elips do prezentacji w Pythonie
linktitle: Elipsa
type: docs
weight: 30
url: /pl/python-net/ellipse/
keywords:
- elipsa
- kształt
- dodaj elipsę
- utwórz elipsę
- narysuj elipsę
- sformatowana elipsa
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak tworzyć, formatować i manipulować kształtami elips w Aspose.Slides for Python via .NET w prezentacjach PPT, PPTX i ODP — przykłady kodu w zestawie."
---
## **Przegląd**

Ten artykuł pokazuje, jak dodać kształty elipsy do slajdów programu PowerPoint przy użyciu Aspose.Slides. Omówiono tworzenie prostej elipsy, tworzenie sformatowanej elipsy oraz zapisywanie zaktualizowanej prezentacji jako pliku PPTX. Poruszono także powiązane zagadnienia, takie jak położenie i rozmiar elipsy, kontrolowanie kolejności nakładania oraz stosowanie efektów animacji.

## **Utwórz elipsę**
W tym temacie przedstawimy programistom, jak dodawać kształty elipsy do ich slajdów przy użyciu Aspose.Slides for Python via .NET. Aspose.Slides for Python via .NET udostępnia prostszy zestaw interfejsów API do rysowania różnych rodzajów kształtów w kilku wierszach kodu. Aby dodać prostą elipsę do wybranego slajdu prezentacji, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/)
1. Uzyskaj odniesienie do slajdu, używając jego indeksu
1. Dodaj AutoShape typu Ellipse przy użyciu metody AddAutoShape udostępnionej przez obiekt IShapes
1. Zapisz zmodyfikowaną prezentację jako plik PPTX

W poniższym przykładzie dodaliśmy elipsę do pierwszego slajdu.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
with slides.Presentation() as pres:
    # Pobierz pierwszy slajd
    sld = pres.slides[0]

    # Dodaj autoshape typu elipsa
    sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    #Zapisz plik PPTX na dysku
    pres.save("EllipseShp1_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Utwórz sformatowaną elipsę**
Aby dodać lepiej sformatowaną elipsę do slajdu, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu, używając jego indeksu.
1. Dodaj AutoShape typu Ellipse przy użyciu metody AddAutoShape udostępnionej przez obiekt IShapes.
1. Ustaw typ wypełnienia elipsy na Solid.
1. Ustaw kolor elipsy, używając właściwości SolidFillColor.Color udostępnionej przez obiekt FillFormat powiązany z obiektem IShape.
1. Ustaw kolor linii elipsy.
1. Ustaw szerokość linii elipsy.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy sformatowaną elipsę do pierwszego slajdu prezentacji.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
with slides.Presentation() as pres:
    # Pobierz pierwszy slajd
    sld = pres.slides[0]

    # Dodaj autoshape typu elipsa
    shp = sld.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 150, 150, 50)

    # Zastosuj formatowanie do kształtu elipsy
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Zastosuj formatowanie do linii elipsy
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Zapisz plik PPTX na dysku
    pres.save("EllipseShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jak ustawić dokładne położenie i rozmiar elipsy względem jednostek slajdu?**

Współrzędne i rozmiary są zazwyczaj podawane **w punktach**. Aby uzyskać przewidywalne wyniki, opieraj obliczenia na rozmiarze slajdu i przelicz wymagane milimetry lub cale na punkty przed przypisaniem wartości.

**Jak umieścić elipsę nad lub pod innymi obiektami (kontrola kolejności nakładania)?**

Dostosuj kolejność rysowania obiektu, przenosząc go na wierzch lub wysyłając na spód. Dzięki temu elipsa może zachodzić na inne obiekty lub odsłaniać te znajdujące się pod nią.

**Jak animować pojawienie się lub podkreślenie elipsy?**

[Apply](/slides/pl/python-net/shape-animation/) efekty wejścia, podkreślenia lub wyjścia do kształtu oraz skonfiguruj wyzwalacze i czasowanie, aby określić, kiedy i jak animacja ma się odtworzyć.