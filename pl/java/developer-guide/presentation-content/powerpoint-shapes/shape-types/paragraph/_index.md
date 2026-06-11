---
title: Pobierz granice akapitu z prezentacji w Javie
linktitle: Akapit
type: docs
weight: 60
url: /pl/java/paragraph/
keywords:
- granice akapitu
- granice fragmentu tekstu
- współrzędne akapitu
- współrzędne fragmentu
- rozmiar akapitu
- rozmiar fragmentu tekstu
- ramka tekstowa
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice akapitu i fragmentu tekstu w Aspose.Slides dla Javy, aby zoptymalizować pozycjonowanie tekstu w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać granice, rozmiar i współrzędne akapitów oraz fragmentów tekstu w Aspose.Slides. Pokazuje, jak pobrać prostokąt akapitu w `TextFrame` przy użyciu `getRect()`, jak uzyskać współrzędne akapitu i fragmentu wewnątrz tekstu komórki tabeli oraz podkreśla ważne szczegóły, takie jak jednostki miary, wpływ zawijania tekstu na granice, konwersję pikseli oraz wartości efektywnego formatowania akapitu.

## **Pobierz współrzędne akapitu i fragmentu w TextFrame**
Używając Aspose.Slides for Java, programiści mogą teraz uzyskać prostokątne współrzędne akapitu w kolekcji akapitów TextFrame. Umożliwia to także pobranie [współrzędnych fragmentu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPortion#getCoordinates--) w kolekcji fragmentów akapitu. W tym temacie pokażemy na przykładzie, jak uzyskać prostokątne współrzędne akapitu wraz z pozycją fragmentu w akapicie.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **Pobierz prostokątne współrzędne akapitu**
Używając metody [**getRect()**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IParagraph#getRect--) programiści mogą uzyskać prostokąt granic akapitu.

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Pobierz rozmiar akapitu i fragmentu wewnątrz tekstu komórki tabeli**

Aby uzyskać rozmiar i współrzędne [Fragmentu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Portion) lub [Akapitu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Paragraph) w tekstowym obszarze komórki tabeli, można użyć metod [IPortion.getRect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPortion#getRect--) oraz [IParagraph.getRect](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IParagraph#getRect--).

Ten przykładowy kod demonstruje opisaną operację:

```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**W jakich jednostkach podawane są współrzędne akapitu i fragmentów tekstu?**

W punktach, gdzie 1 cal = 72 punkty. Dotyczy to wszystkich współrzędnych i wymiarów na slajdzie.

**Czy zawijanie wyrazów wpływa na granice akapitu?**

Tak. Jeśli [zawijanie](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textframeformat/#setWrapText-byte-) jest włączone w [TextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textframe/), tekst jest łamany, aby dopasować się do szerokości obszaru, co zmienia rzeczywiste granice akapitu.

**Czy można wiarygodnie przekształcić współrzędne akapitu na piksele w wyeksportowanym obrazie?**

Tak. Konwertuj punkty na piksele używając: piksele = punkty × (DPI / 72). Wynik zależy od wybranego DPI podczas renderowania/eksportu.

**Jak uzyskać „efektywne” parametry formatowania akapitu, uwzględniając dziedziczenie stylu?**

Użyj [struktur danych efektywnego formatowania akapitu](/slides/pl/java/shape-effective-properties/); zwraca ona ostateczne, scalone wartości wcięć, odstępów, zawijania, RTL i innych.