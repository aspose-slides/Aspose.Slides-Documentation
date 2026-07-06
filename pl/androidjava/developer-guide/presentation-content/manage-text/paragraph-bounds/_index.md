---
title: Pobierz granice akapitu z prezentacji na Androidzie
linktitle: Granice akapitu
type: docs
weight: 43
url: /pl/androidjava/paragraph-bounds/
keywords:
- granice akapitu
- współrzędne akapitu
- rozmiar akapitu
- ramka tekstowa
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice akapitu w Aspose.Slides dla Androida przy użyciu Javy, aby zoptymalizować pozycjonowanie tekstu w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać granice, rozmiar i współrzędne akapitów w Aspose.Slides. Pokazuje, jak pobrać prostokąt akapitu z [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/) przy użyciu [IParagraph.getRect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IParagraph#getRect--), jak uzyskać współrzędne akapitu wewnątrz ramki tekstowej komórki tabeli oraz podkreśla ważne szczegóły, takie jak jednostki miary, wpływ zawijania tekstu na granice, konwersję pikseli i wartości efektywnego formatowania akapitu.

## **Uzyskaj prostokątne współrzędne akapitu**

Użyj [IParagraph.getRect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IParagraph#getRect--) aby uzyskać prostokąt otaczający akapit.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Uzyskaj rozmiar akapitu wewnątrz ramki tekstowej komórki tabeli**

Aby uzyskać rozmiar i współrzędne [IParagraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph/) w ramce tekstowej komórki tabeli, użyj [IParagraph.getRect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IParagraph#getRect--). Zwrócony prostokąt jest względem ramki tekstowej komórki, więc dodaj pozycję tabeli i offset komórki, gdy potrzebujesz współrzędnych na poziomie slajdu.

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

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

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

Są mierzone w punktach, gdzie 1 cal to 72 punkty. Dotyczy to wszystkich współrzędnych i wymiarów na slajdzie.

**Czy zawijanie tekstu wpływa na granice akapitu?**

Tak. Jeśli [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) jest włączone dla [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/), tekst jest łamany, aby dopasować się do szerokości obszaru, co zmienia rzeczywiste granice akapitu.

**Czy współrzędne akapitu można wiarygodnie przeliczyć na piksele w wyeksportowanym obrazie?**

Tak. Przelicz punkty na piksele, używając wzoru: piksele = punkty × (DPI / 72). Wynik zależy od DPI wybranego przy renderowaniu lub eksporcie.

**Jak uzyskać „efektywne” parametry formatowania akapitu, uwzględniając dziedziczenie stylów?**

Użyj [efektywna struktura danych formatowania akapitu](/slides/pl/androidjava/shape-effective-properties/); zwraca ona ostateczne skonsolidowane wartości wcięć, odstępów, zawijania, RTL i innych.