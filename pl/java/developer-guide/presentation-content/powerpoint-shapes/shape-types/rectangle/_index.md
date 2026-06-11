---
title: Dodaj prostokąty do prezentacji w Javie
linktitle: Prostokąt
type: docs
weight: 80
url: /pl/java/rectangle/
keywords:
- dodaj prostokąt
- utwórz prostokąt
- kształt prostokąta
- prosty prostokąt
- sformatowany prostokąt
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Zwiększ atrakcyjność swoich prezentacji PowerPoint, dodając prostokąty za pomocą Aspose.Slides dla Javy - łatwo projektuj i modyfikuj kształty programowo."
---
## **Przegląd**

Ten artykuł pokazuje, jak dodać kształty prostokątów do slajdów PowerPoint przy użyciu Aspose.Slides. Zawiera tworzenie prostego prostokąta, tworzenie sformatowanego prostokąta oraz zapisywanie zaktualizowanej prezentacji jako pliku PPTX.

Zobaczysz także, jak zastosować podstawowe formatowanie prostokąta, takie jak jednolity kolor wypełnienia, kolor linii i grubość linii. Ponadto sekcja FAQ artykułu odwołuje się do powiązanych zadań związanych z prostokątami, w tym zaokrąglonych rogów, wypełnień obrazem, efektów wizualnych, hiperłączy, blokad kształtu, opcji eksportu oraz właściwości efektywnych.

## **Dodaj prostokąt do slajdu**
Aby dodać prosty prostokąt do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape) typu Rectangle przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [IShapeCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection).
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy prosty prostokąt do pierwszego slajdu prezentacji.

```java
// Utwórz klasę Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);

    // Dodaj AutoShape typu elipsa
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Zapisz plik PPTX na dysku
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dodaj sformatowany prostokąt do slajdu**
Aby dodać sformatowany prostokąt do slajdu, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape) typu Rectangle przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [IShapeCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection).
- Ustaw [Fill Type] prostokąta na Solid.
- Ustaw kolor prostokąta przy użyciu metody [SolidFillColor.setColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) udostępnionej przez obiekt [IFillFormat] powiązany z obiektem [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape).
- Ustaw kolor linii prostokąta.
- Ustaw szerokość linii prostokąta.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

Powyższe kroki zostały zaimplementowane w poniższym przykładzie.

```java
// Utwórz klasę Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);

    // Dodaj AutoShape typu elipsa
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Zastosuj formatowanie do kształtu elipsy
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Zastosuj formatowanie do linii elipsy
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Zapisz plik PPTX na dysku
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jak dodać prostokąt z zaokrąglonymi rogami?**

Użyj typu kształtu z zaokrąglonymi rogami [shape type](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shapetype/) i dostosuj promień rogów w właściwościach kształtu; zaokrąglenie można także zastosować osobno dla każdego rogu przy pomocy ustawień geometrycznych.

**Jak wypełnić prostokąt obrazem (teksturą)?**

Wybierz rodzaj wypełnienia [fill type](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/), podaj źródło obrazu i skonfiguruj tryby [stretching/tiling modes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/picturefillmode/).

**Czy prostokąt może mieć cień i poświatę?**

Tak. [Outer/inner shadow, glow, and soft edges](/slides/pl/java/shape-effect/) są dostępne z parametrami, które można regulować.

**Czy mogę zamienić prostokąt w przycisk z hiperłączem?**

Tak. [Assign a hyperlink](/slides/pl/java/manage-hyperlinks/) do kliknięcia kształtu (przejście do slajdu, pliku, adresu internetowego lub e‑maila).

**Jak mogę zabezpieczyć prostokąt przed przemieszczaniem i zmianami?**

[Use shape locks](/slides/pl/java/applying-protection-to-presentation/): możesz zabronić przemieszczania, zmiany rozmiaru, zaznaczania lub edycji tekstu, aby zachować układ.

**Czy mogę przekonwertować prostokąt na obraz rastrowy lub SVG?**

Tak. Możesz [render the shape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getImage-int-float-float-) do obrazu o określonym rozmiarze/skali lub [export it as SVG](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) do wykorzystania wektorowego.

**Jak szybko uzyskać rzeczywiste (efektywne) właściwości prostokąta uwzględniając motyw i dziedziczenie?**

[Use the shape’s effective properties](/slides/pl/java/shape-effective-properties/): API zwraca obliczone wartości, które uwzględniają style motywu, układ i ustawienia lokalne, upraszczając analizę formatowania.