---
title: Dodawanie prostokątów do prezentacji w JavaScript
linktitle: Prostokąt
type: docs
weight: 80
url: /pl/nodejs-java/rectangle/
keywords:
- dodaj prostokąt
- utwórz prostokąt
- kształt prostokąta
- prosty prostokąt
- sformatowany prostokąt
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Zwiększ atrakcyjność swoich prezentacji PowerPoint, dodając prostokąty za pomocą JavaScript i Aspose.Slides dla Node.js — łatwo projektuj i modyfikuj kształty programowo."
---
## **Przegląd**

Ten artykuł pokazuje, jak dodawać kształty prostokątów do slajdów PowerPoint przy użyciu Aspose.Slides. Omawia tworzenie prostego prostokąta, tworzenie sformatowanego prostokąta oraz zapisywanie zaktualizowanej prezentacji jako pliku PPTX.  
Zobaczysz także, jak zastosować podstawowe formatowanie prostokąta, takie jak jednolity kolor wypełnienia, kolor linii i grubość linii. Ponadto sekcja FAQ artykułu wskazuje powiązane zadania związane z prostokątami, w tym zaokrąglone rogi, wypełnienia obrazem, efekty wizualne, hiperłącza, blokady kształtów, opcje eksportu oraz właściwości efektywne.

## **Dodaj prostokąt do slajdu**

Podobnie jak w poprzednich tematach, ten również dotyczy dodawania kształtu, a tym razem omawiamy prostokąt. W tym temacie opisaliśmy, jak programiści mogą dodawać proste lub sformatowane prostokąty do swoich slajdów przy użyciu Aspose.Slides.  

Aby dodać prosty prostokąt do wybranego slajdu prezentacji, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape) typu Rectangle przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection).
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy prosty prostokąt do pierwszego slajdu prezentacji.

```javascript
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd
    var sld = pres.getSlides().get_Item(0);
    // Dodaj AutoShape typu elipsa
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Zapisz plik PPTX na dysku
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dodaj sformatowany prostokąt do slajdu**

Aby dodać sformatowany prostokąt do slajdu, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/AutoShape) typu Rectangle przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection).
- Ustaw [Fill Type](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FillType) prostokąta na Solid.
- Ustaw kolor prostokąta przy użyciu metody [SolidFillColor.setColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) udostępnionej przez obiekt [FillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FillFormat) powiązany z obiektem [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape).
- Ustaw kolor linii prostokąta.
- Ustaw szerokość linii prostokąta.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

Powyższe kroki zostały zrealizowane w poniższym przykładzie.

```javascript
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd
    var sld = pres.getSlides().get_Item(0);
    // Dodaj AutoShape typu elipsa
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // Zastosuj formatowanie do kształtu elipsy
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // Zastosuj formatowanie do linii elipsy
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Zapisz plik PPTX na dysku
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jak dodać prostokąt z zaokrąglonymi rogami?**

Użyj typu kształtu [shape type](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapetype/) z zaokrąglonymi rogami i dostosuj promień rogów w właściwościach kształtu; zaokrąglenie można także zastosować indywidualnie dla każdego rogu za pomocą modyfikacji geometrii.

**Jak wypełnić prostokąt obrazem (teksturą)?**

Wybierz [fill type](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) obrazu, podaj źródło obrazu i skonfiguruj [tryby rozciągania/układania](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillmode/).

**Czy prostokąt może mieć cień i poświatę?**

Tak. Dostępne są [zewnętrzny/wnętrzny cień, poświata i miękkie krawędzie](/slides/pl/nodejs-java/shape-effect/) z możliwością dostosowania parametrów.

**Czy mogę przekształcić prostokąt w przycisk z hiperłączem?**

Tak. [Przypisz hiperłącze](/slides/pl/nodejs-java/manage-hyperlinks/) do kliknięcia kształtu (przejście do slajdu, pliku, adresu internetowego lub e‑maila).

**Jak mogę zabezpieczyć prostokąt przed przemieszczaniem i zmianami?**

Użyj blokad kształtu: możesz zablokować przemieszczanie, zmianę rozmiaru, zaznaczanie lub edycję tekstu, aby zachować układ.

**Czy mogę konwertować prostokąt na obraz rastrowy lub SVG?**

Tak. Możesz [renderować kształt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getImage) do obrazu o określonym rozmiarze/skali lub [wyeksportować go jako SVG](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/writeassvg/) do wykorzystania wektorowego.

**Jak szybko uzyskać rzeczywiste (efektywne) właściwości prostokąta, uwzględniając motyw i dziedziczenie?**

[Użyj efektywnych właściwości kształtu](/slides/pl/nodejs-java/shape-effective-properties/): API zwraca wyliczone wartości, które uwzględniają style motywu, układ i ustawienia lokalne, upraszczając analizę formatowania.