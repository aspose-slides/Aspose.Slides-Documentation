---
title: Dodawanie elips do prezentacji w Javie
linktitle: Elipsa
type: docs
weight: 30
url: /pl/java/ellipse/
keywords:
- elipsa
- kształt
- dodaj elipsę
- utwórz elipsę
- narysuj elipsę
- sformatowana elipsa
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć, formatować i manipulować kształtami elips w Aspose.Slides dla Javy w prezentacjach PPT i PPTX — dołączone przykłady kodu w Javie."
---
## **Przegląd**

Ten artykuł pokazuje, jak dodać kształty elipsy do slajdów PowerPoint przy użyciu Aspose.Slides. Obejmuje tworzenie prostej elipsy, tworzenie sformatowanej elipsy oraz zapisywanie zaktualizowanej prezentacji jako pliku PPTX. Porusza również powiązane pytania, takie jak praca z pozycją i rozmiarem elipsy, kontrolowanie kolejności warstw oraz stosowanie efektów animacji.

## **Utworzenie elipsy**
Aby dodać prostą elipsę do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Ellipse przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [IShapeCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection).
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy elipsę do pierwszego slajdu

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Dodaj AutoShape typu elipsa
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Zapisz plik PPTX na dysku
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Utworzenie sformatowanej elipsy**
Aby dodać lepiej sformatowaną elipsę do slajdu, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Ellipse przy użyciu metody [addAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [IShapeCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection).
- Ustaw typ wypełnienia elipsy na Solid.
- Ustaw kolor elipsy, używając właściwości SolidFillColor.Color udostępnionej przez obiekt [FillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IFillFormat) powiązany z obiektem [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape).
- Ustaw kolor linii elipsy.
- Ustaw szerokość linii elipsy.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy sformatowaną elipsę do pierwszego slajdu prezentacji.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);

    // Dodaj AutoShape typu elipsa
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Zastosuj pewne formatowanie do kształtu elipsy
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Zastosuj pewne formatowanie do linii elipsy
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Zapisz plik PPTX na dysku
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jak ustawić dokładną pozycję i rozmiar elipsy względem jednostek slajdu?**

Współrzędne i rozmiary są zazwyczaj określane **w punktach**. Aby uzyskać przewidywalne wyniki, opieraj obliczenia na rozmiarze slajdu i przed przypisaniem wartości przelicz wymagane milimetry lub cale na punkty.

**Jak umieścić elipsę nad lub pod innymi obiektami (kontrola kolejności warstw)?**

Dostosuj kolejność rysowania obiektu, przenosząc go na wierzch lub wysyłając na tył. Dzięki temu elipsa może zachodzić na inne obiekty lub odsłaniać te znajdujące się pod nią.

**Jak animować pojawienie się lub podkreślenie elipsy?**

[Apply](/slides/pl/java/shape-animation/) efekty wejścia, podkreślenia lub wyjścia do kształtu oraz skonfiguruj wyzwalacze i timing, aby określić, kiedy i jak animacja ma się odtwarzać.