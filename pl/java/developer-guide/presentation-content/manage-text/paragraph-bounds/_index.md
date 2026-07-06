---
title: Pobieranie granic akapitu z prezentacji w Javie
linktitle: Granice akapitu
type: docs
weight: 43
url: /pl/java/paragraph-bounds/
keywords:
- granice akapitu
- współrzędne akapitu
- rozmiar akapitu
- ramka tekstowa
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice akapitu w Aspose.Slides dla Javy, aby zoptymalizować pozycjonowanie tekstu w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać granice, rozmiar i współrzędne akapitów w Aspose.Slides. Pokazuje, jak pobrać prostokąt akapitu z [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) za pomocą [IParagraph.getRect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IParagraph#getRect--), jak uzyskać współrzędne akapitu wewnątrz ramki tekstowej komórki tabeli oraz podkreśla ważne szczegóły, takie jak jednostki miary, wpływ zawijania tekstu na granice, konwersję pikseli oraz efektywne wartości formatowania akapitu.

## **Pobierz prostokątne współrzędne akapitu**

Użyj [IParagraph.getRect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IParagraph#getRect--) aby uzyskać prostokąt ograniczający akapit.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Pobierz rozmiar akapitu wewnątrz ramki tekstowej komórki tabeli**

Aby uzyskać rozmiar i współrzędne [IParagraph](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph/) w ramce tekstowej komórki tabeli, użyj [IParagraph.getRect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IParagraph#getRect--). Zwrócony prostokąt jest względem ramki tekstowej komórki tabeli, więc dodaj pozycję tabeli i offset komórki, gdy potrzebne są współrzędne na poziomie slajdu.

Poniższy przykład pobiera granice akapitu wewnątrz komórki tabeli i rysuje prostokąty na slajdzie, aby zwizualizować te granice:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**W jakich jednostkach mierzone są współrzędne akapitu?**

Są one mierzone w punktach, gdzie 1 cal to 72 punkty. Dotyczy to wszystkich współrzędnych i wymiarów na slajdzie.

**Czy zawijanie tekstu wpływa na granice akapitu?**

Tak. Jeśli [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) jest włączone dla [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/), tekst jest łamany, aby dopasować się do szerokości obszaru, co zmienia rzeczywiste granice akapitu.

**Czy współrzędne akapitu można wiarygodnie zamapować na piksele w wyeksportowanym obrazie?**

Tak. Przekształć punkty na piksele używając wzoru: piksele = punkty x (DPI / 72). Wynik zależy od wybranej rozdzielczości DPI dla renderowania lub eksportu.

**Jak uzyskać „efektywne” parametry formatowania akapitu, uwzględniając dziedziczenie stylu?**

Użyj [efektywnej struktury danych formatowania akapitu](/slides/pl/java/shape-effective-properties/); zwraca ona ostateczne skonsolidowane wartości wcięć, odstępów, zawijania, RTL i innych.