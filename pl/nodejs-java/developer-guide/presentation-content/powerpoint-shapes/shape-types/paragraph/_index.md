---
title: Pobieranie granic akapitu z prezentacji w JavaScript
linktitle: Akapit
type: docs
weight: 60
url: /pl/nodejs-java/paragraph/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice akapitu i fragmentu tekstu w JavaScript przy użyciu Aspose.Slides dla Node.js, aby zoptymalizować pozycjonowanie tekstu w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać granice, rozmiar i współrzędne akapitów oraz fragmentów tekstu w Aspose.Slides. Pokazuje, jak pobrać prostokąt akapitu w `TextFrame` przy użyciu `getRect()`, jak uzyskać współrzędne akapitu i fragmentu wewnątrz ramki tekstowej komórki tabeli oraz podkreśla ważne szczegóły, takie jak jednostki miary, wpływ zawijania tekstu na granice, konwersję na piksele oraz wartości efektywnego formatowania akapitu.

## **Uzyskiwanie współrzędnych akapitu i fragmentu w TextFrame**
Korzystając z Aspose.Slides dla Node.js przy użyciu Javy, programiści mogą teraz uzyskać prostokątne współrzędne akapitu w kolekcji akapitów TextFrame. Umożliwia to także pobranie [the coordinates of portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Portion#getCoordinates--) w kolekcji fragmentów akapitu. W tym temacie pokażemy na przykładzie, jak uzyskać prostokątne współrzędne akapitu wraz z pozycją fragmentu wewnątrz akapitu.

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```

## **Uzyskiwanie prostokątnych współrzędnych akapitu**
Korzystając z metody [**getRect()**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Paragraph#getRect--) programiści mogą uzyskać prostokąt granic akapitu.

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Uzyskiwanie rozmiaru akapitu i fragmentu wewnątrz tekstowej ramki komórki tabeli**

Aby uzyskać rozmiar i współrzędne [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Portion) lub [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Paragraph) w tekstowej ramce komórki tabeli, możesz użyć metod [Portion.getRect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Portion#getRect--) oraz [Paragraph.getRect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Paragraph#getRect--).

Ten przykładowy kod demonstruje opisane działanie:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**W jakich jednostkach zwracane są współrzędne akapitu i fragmentów tekstu?**

W punktach, gdzie 1 cal = 72 punkty. Dotyczy to wszystkich współrzędnych i wymiarów na slajdzie.

**Czy zawijanie tekstu wpływa na granice akapitu?**

Tak. Jeśli [wrapping](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/setwraptext/) jest włączone w [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/), tekst jest łamany, aby dopasować się do szerokości obszaru, co zmienia rzeczywiste granice akapitu.

**Czy współrzędne akapitu można wiarygodnie przeliczyć na piksele w wyeksportowanym obrazie?**

Tak. Przelicz punkty na piksele używając: pixels = points × (DPI / 72). Wynik zależy od wybranej rozdzielczości DPI przy renderowaniu/eksportowaniu.

**Jak uzyskać „efektywne” parametry formatowania akapitu, uwzględniając dziedziczenie stylu?**

Użyj [effective paragraph formatting data structure](/slides/pl/nodejs-java/shape-effective-properties/); zwraca ona końcowe skonsolidowane wartości wcięć, odstępów, zawijania, RTL i innych.