---
title: Pole tekstowe
type: docs
weight: 40
url: /pl/androidjava/examples/elements/text-box/
keywords:
- przykład kodu
- pole tekstowe
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Pracuj z polami tekstowymi w Aspose.Slides dla Androida: dodawaj, formatuj, wyrównuj, zawijaj, automatycznie dopasowuj i stylizuj tekst przy użyciu Javy dla prezentacji w formatach PPT, PPTX i ODP."
---
W bibliotece Aspose.Slides **pole tekstowe** jest reprezentowane przez `AutoShape`. Prawie każdy kształt może zawierać tekst, ale typowe pole tekstowe nie ma wypełnienia ani obramowania i wyświetla tylko tekst.

Ten przewodnik wyjaśnia, jak programowo dodawać, uzyskiwać dostęp i usuwać pola tekstowe.

## **Dodaj pole tekstowe**

Pole tekstowe to po prostu `AutoShape` bez wypełnienia i obramowania oraz z formatowanym tekstem. Oto jak je utworzyć:

```java
public static void addTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Utwórz prostokątny kształt (domyślnie wypełniony obramowaniem i bez tekstu).
        IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100);

        // Usuń wypełnienie i obramowanie, aby wyglądało jak typowe pole tekstowe.
        textBox.getFillFormat().setFillType(FillType.NoFill);
        textBox.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        // Ustaw formatowanie tekstu.
        IParagraph paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        IPortionFormat textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        textFormat.getFillFormat().setFillType(FillType.Solid);
        textFormat.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        // Przypisz rzeczywistą treść tekstu.
        textBox.getTextFrame().setText("Some text...");
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Uwaga:** Każdy `AutoShape`, który zawiera niepusty `TextFrame`, może pełnić funkcję pola tekstowego.

## **Uzyskiwanie dostępu do pól tekstowych na podstawie zawartości**

Aby znaleźć wszystkie pola tekstowe zawierające określone słowo kluczowe (np. "Slide"), przeiteruj kształty i sprawdź ich tekst:

```java
public static void accessTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        for (IShape shape : slide.getShapes()) {
            // Tylko AutoShape'y mogą zawierać edytowalny tekst.
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    // Zrób coś z pasującym polem tekstowym.
                }
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Usuwanie pól tekstowych na podstawie zawartości**

Ten przykład znajduje i usuwa wszystkie pola tekstowe na pierwszym slajdzie, które zawierają określone słowo kluczowe:

```java
public static void removeTextBox() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        List<IShape> shapesToRemove = new ArrayList<IShape>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                if (autoShape.getTextFrame().getText().contains("Slide")) {
                    shapesToRemove.add(shape);
                }
            }
        }

        for (IShape shape : shapesToRemove) {
            slide.getShapes().remove(shape);
        }
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Wskazówka:** Zawsze twórz kopię kolekcji kształtów przed modyfikacją podczas iteracji, aby uniknąć błędów modyfikacji kolekcji.