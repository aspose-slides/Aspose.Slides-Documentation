---
title: Dodaj elipsy do prezentacji w JavaScript
linktitle: Elipsa
type: docs
weight: 30
url: /pl/nodejs-java/ellipse/
keywords:
- elipsa
- kształt
- dodaj elipsę
- utwórz elipsę
- rysuj elipsę
- sformatowana elipsa
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak tworzyć, formatować i manipulować kształtami elips w Aspose.Slides dla Node.js w prezentacjach PPT i PPTX — przykłady kodu JavaScript włączone."
---
## **Przegląd**

Ten artykuł pokazuje, jak dodać kształty elipsy do slajdów PowerPoint przy użyciu Aspose.Slides. Omówiono tworzenie prostej elipsy, tworzenie sformatowanej elipsy oraz zapisywanie zaktualizowanej prezentacji jako plik PPTX. Poruszono także powiązane pytania, takie jak pracowanie z pozycją i rozmiarem elipsy, kontrolowanie kolejności warstw oraz stosowanie efektów animacji.

## **Utwórz elipsę**
Aby dodać prostą elipsę do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Ellipse używając metody [addAutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection).
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy elipsę do pierwszego slajdu

```javascript
// Utwórz instancję klasy Presentation reprezentującej plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd
    var sld = pres.getSlides().get_Item(0);
    // Dodaj AutoShape typu elipsa
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Zapisz plik PPTX na dysku
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Utwórz sformatowaną elipsę**
Aby dodać lepiej sformatowaną elipsę do slajdu, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
- Uzyskaj referencję do slajdu, używając jego indeksu.
- Dodaj AutoShape typu Ellipse używając metody [addAutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) udostępnionej przez obiekt [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection).
- Ustaw typ wypełnienia elipsy na jednolite.
- Ustaw kolor elipsy, używając właściwości SolidFillColor.Color udostępnionej przez obiekt [FillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FillFormat) powiązany z obiektem [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Shape).
- Ustaw kolor linii elipsy.
- Ustaw szerokość linii elipsy.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie dodaliśmy sformatowaną elipsę do pierwszego slajdu prezentacji.

```javascript
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd
    var sld = pres.getSlides().get_Item(0);
    // Dodaj AutoShape typu elipsa
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // Zastosuj pewne formatowanie do kształtu elipsy
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // Zastosuj pewne formatowanie do linii elipsy
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // Zapisz plik PPTX na dysku
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **FAQ**

**Jak ustawić dokładną pozycję i rozmiar elipsy względem jednostek slajdu?**

Współrzędne i rozmiary są zazwyczaj podawane **w punktach**. Aby uzyskać przewidywalne wyniki, opieraj obliczenia na rozmiarze slajdu i przed przypisaniem wartości przelicz wymagane milimetry lub cale na punkty.

**Jak umieścić elipsę nad lub pod innymi obiektami (kontrola kolejności warstw)?**

Dostosuj kolejność rysowania obiektu, przenosząc go na wierzch lub wysyłając na spód. Dzięki temu elipsa może nakładać się na inne obiekty lub odsłaniać znajdujące się pod nią.

**Jak animować pojawienie się lub podkreślenie elipsy?**

[Zastosuj](/slides/pl/nodejs-java/shape-animation/) efekty wejścia, podkreślenia lub wyjścia do kształtu oraz skonfiguruj wyzwalacze i synchronizację, aby określić, kiedy i jak animacja ma się odtworzyć.