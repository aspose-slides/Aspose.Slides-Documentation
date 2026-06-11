---
title: Pole tekstowe
type: docs
weight: 40
url: /pl/net/examples/elements/text-box/
keywords:
- pole tekstowe
- dodaj pole tekstowe
- uzyskaj dostęp do pola tekstowego
- usuń pole tekstowe
- przykład kodu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Pracuj z polami tekstowymi w Aspose.Slides dla .NET: dodawaj, formatuj, wyrównuj, zawijaj, automatycznie dopasowuj i stylizuj tekst przy użyciu C# dla prezentacji PPT, PPTX i ODP."
---
W Aspose.Slides **pole tekstowe** jest reprezentowane przez `AutoShape`. Prawie każdy kształt może zawierać tekst, ale typowe pole tekstowe nie ma wypełnienia ani obramowania i wyświetla tylko tekst.

Ten przewodnik wyjaśnia, jak programowo dodawać, uzyskiwać dostęp i usuwać pola tekstowe.

## **Dodaj pole tekstowe**

Pole tekstowe to po prostu `AutoShape` bez wypełnienia i obramowania oraz z sformatowanym tekstem. Oto jak je utworzyć:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Utwórz kształt prostokąta (domyślnie wypełniony z obramowaniem i bez tekstu).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Usuń wypełnienie i obramowanie, aby wyglądało jak typowe pole tekstowe.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Ustaw formatowanie tekstu.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Przypisz właściwą treść tekstu.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Uwaga:** Każdy `AutoShape`, który zawiera niepusty `TextFrame`, może działać jako pole tekstowe.

## **Uzyskaj dostęp do pól tekstowych według zawartości**

Aby znaleźć wszystkie pola tekstowe zawierające określone słowo kluczowe (np. "Slide"), przeiteruj kształty i sprawdź ich tekst:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Tylko AutoShapes mogą zawierać edytowalny tekst.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Wykonaj coś z pasującym polem tekstowym.
            }
        }
    }
}
```

## **Usuń pola tekstowe według zawartości**

Ten przykład znajduje i usuwa wszystkie pola tekstowe na pierwszym slajdzie, które zawierają określone słowo kluczowe:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **Wskazówka:** Zawsze twórz kopię kolekcji kształtów przed modyfikacją podczas iteracji, aby uniknąć błędów modyfikacji kolekcji.