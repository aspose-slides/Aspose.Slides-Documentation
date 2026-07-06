---
title: Pobierz granice akapitu z prezentacji w JavaScript
linktitle: Granice akapitu
type: docs
weight: 43
url: /pl/nodejs-java/paragraph-bounds/
keywords:
- granice akapitu
- współrzędne akapitu
- rozmiar akapitu
- ramka tekstowa
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak pobierać granice akapitu w Aspose.Slides dla Node.js przy użyciu Javy, aby zoptymalizować pozycjonowanie tekstu w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać granice, rozmiar i współrzędne akapitów w Aspose.Slides. Pokazuje, jak pobrać prostokąt akapitu z [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/) przy użyciu [Paragraph.getRect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/getrect/), jak uzyskać współrzędne akapitu wewnątrz ramki tekstowej komórki tabeli oraz podkreśla ważne szczegóły, takie jak jednostki miary, wpływ zawijania tekstu na granice, konwersja pikseli oraz efektywne wartości formatowania akapitu.

## **Uzyskaj prostokątne współrzędne akapitu**

Użyj [Paragraph.getRect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/getrect/), aby uzyskać prostokąt ograniczający akapit.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Uzyskaj rozmiar akapitu wewnątrz ramki tekstowej komórki tabeli**

Aby uzyskać rozmiar i współrzędne [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) w ramce tekstowej komórki tabeli, użyj [Paragraph.getRect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/getrect/). Zwrócony prostokąt jest względny względem ramki tekstowej komórki tabeli, więc dodaj pozycję tabeli i offset komórki, gdy potrzebujesz współrzędnych na poziomie slajdu.

Poniższy przykład pobiera granice akapitu wewnątrz komórki tabeli i rysuje prostokąty na slajdzie, aby zwizualizować te granice:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**W jakich jednostkach mierzone są współrzędne akapitu?**

Mierzone są w punktach, gdzie 1 cal = 72 punkty. Dotyczy to wszystkich współrzędnych i wymiarów na slajdzie.

**Czy zawijanie tekstu wpływa na granice akapitu?**

Tak. Jeśli [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/setwraptext/) jest włączone dla [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/), tekst jest dzielony tak, aby dopasować się do szerokości obszaru, co zmienia rzeczywiste granice akapitu.

**Czy współrzędne akapitu można niezawodnie przeliczyć na piksele w wyeksportowanym obrazie?**

Tak. Przelicz punkty na piksele za pomocą wzoru: piksele = punkty × (DPI / 72). Wynik zależy od wybranej rozdzielczości DPI podczas renderowania lub eksportu.

**Jak uzyskać „efektywne” parametry formatowania akapitu, uwzględniając dziedziczenie stylu?**

Użyj [effective paragraph formatting data structure](/slides/pl/nodejs-java/shape-effective-properties/); zwraca ona ostateczne, skonsolidowane wartości wcięć, odstępów, zawijania, RTL i innych.