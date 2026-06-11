---
title: Dodaj prostokąty do prezentacji w Pythonie
linktitle: Prostokąt
type: docs
weight: 80
url: /pl/python-net/rectangle/
keywords:
- dodaj prostokąt
- utwórz prostokąt
- kształt prostokąta
- prosty prostokąt
- formatowany prostokąt
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Zwiększ możliwości swoich prezentacji PowerPoint i OpenDocument, dodając prostokąty za pomocą Aspose.Slides for Python via .NET — łatwo projektuj i modyfikuj kształty programowo."
---
## **Przegląd**

Ten artykuł pokazuje, jak dodać kształty prostokątne do slajdów PowerPoint przy użyciu Aspose.Slides. Obejmuje tworzenie prostego prostokąta, tworzenie formatowanego prostokąta oraz zapisywanie zaktualizowanej prezentacji jako plik PPTX.

Zobaczysz także, jak zastosować podstawowe formatowanie prostokąta, takie jak jednolity kolor wypełnienia, kolor linii oraz szerokość linii. Dodatkowo, w sekcji FAQ artykułu znajdują się odnośniki do powiązanych zadań związanych z prostokątami, w tym zaokrąglone rogi, wypełnienia obrazem, efekty wizualne, hiperłącza, blokady kształtów, opcje eksportu i właściwości efektywne.

## **Utwórz prosty prostokąt**
Podobnie jak w poprzednich tematach, ten również dotyczy dodawania kształtu, a tym razem omawiamy prostokąt. W tym temacie opisujemy, jak programiści mogą dodawać proste lub formatowane prostokąty do swoich slajdów przy użyciu Aspose.Slides for Python via .NET. Aby dodać prosty prostokąt do wybranego slajdu prezentacji, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu, używając jego indeksu.
1. Dodaj IAutoShape typu Rectangle za pomocą metody AddAutoShape udostępnionej przez obiekt IShapes.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy prosty prostokąt do pierwszego slajdu prezentacji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
with slides.Presentation() as pres:
    # Pobierz pierwszy slajd
    sld = pres.slides[0]

    # Dodaj autokształt typu prostokąt
    sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Zapisz plik PPTX na dysk
    pres.save("RectShp1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Utwórz formatowany prostokąt**
Aby dodać formatowany prostokąt do slajdu, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odniesienie do slajdu, używając jego indeksu.
1. Dodaj IAutoShape typu Rectangle za pomocą metody AddAutoShape udostępnionej przez obiekt IShapes.
1. Ustaw typ wypełnienia prostokąta na Solid.
1. Ustaw kolor prostokąta, korzystając z właściwości SolidFillColor.Color udostępnionej przez obiekt FillFormat powiązany z obiektem IShape.
1. Ustaw kolor linii prostokąta.
1. Ustaw szerokość linii prostokąta.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.
   Powyższe kroki zostały zaimplementowane w poniższym przykładzie.

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
with slides.Presentation() as pres:
    # Pobierz pierwszy slajd
    sld = pres.slides[0]

    # Dodaj autokształt typu prostokąt
    shp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 150, 50)

    # Zastosuj formatowanie do kształtu prostokąta
    shp.fill_format.fill_type = slides.FillType.SOLID
    shp.fill_format.solid_fill_color.color = draw.Color.chocolate

    # Zastosuj formatowanie do linii prostokąta
    shp.line_format.fill_format.fill_type = slides.FillType.SOLID
    shp.line_format.fill_format.solid_fill_color.color = draw.Color.black
    shp.line_format.width = 5

    #Zapisz plik PPTX na dysk
    pres.save("RectShp2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jak dodać prostokąt z zaokrąglonymi rogami?**

Użyj typu kształtu [shape type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shapetype/) z zaokrąglonymi rogami i dostosuj promień rogu w właściwościach kształtu; zaokrąglenie można także zastosować osobno dla każdego rogu za pomocą modyfikacji geometrii.

**Jak wypełnić prostokąt obrazem (teksturą)?**

Wybierz typ wypełnienia [fill type](https://reference.aspose.com/slides/pl/python-net/aspose.slides/filltype/), podaj źródło obrazu i skonfiguruj tryby [stretching/tiling](https://reference.aspose.com/slides/pl/python-net/aspose.slides/picturefillmode/).

**Czy prostokąt może mieć cień i poświatę?**

Tak. [Outer/inner shadow, glow, and soft edges](/slides/pl/python-net/shape-effect/) są dostępne i mają regulowane parametry.

**Czy mogę zamienić prostokąt w przycisk z hiperłączem?**

Tak. [Assign a hyperlink](/slides/pl/python-net/manage-hyperlinks/) do kliknięcia kształtu (przejście do slajdu, pliku, adresu internetowego lub e‑maila).

**Jak zabezpieczyć prostokąt przed przemieszczaniem i zmianami?**

[Use shape locks](/slides/pl/python-net/applying-protection-to-presentation/): możesz zabronić przemieszczania, zmiany rozmiaru, zaznaczania lub edycji tekstu, aby zachować układ.

**Czy mogę przekonwertować prostokąt na obraz rastrowy lub SVG?**

Tak. Możesz [render the shape](http://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/get_image/) do obrazu o określonym rozmiarze/skali albo [export it as SVG](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/write_as_svg/) do użytku wektorowego.

**Jak szybko uzyskać rzeczywiste (efektywne) właściwości prostokąta z uwzględnieniem motywu i dziedziczenia?**

[Use the shape’s effective properties](/slides/pl/python-net/shape-effective-properties/): API zwraca wartości obliczone, które uwzględniają style motywu, układ i ustawienia lokalne, upraszczając analizę formatowania.