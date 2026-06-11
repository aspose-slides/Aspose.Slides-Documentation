---
title: Pobieranie granic akapitu z prezentacji w .NET
linktitle: Akapit
type: docs
weight: 60
url: /pl/net/paragraph/
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
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak pobierać granice akapitu i fragmentu tekstu w Aspose.Slides dla .NET, aby zoptymalizować pozycjonowanie tekstu w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać granice, rozmiar i współrzędne akapitów oraz fragmentów tekstu w Aspose.Slides. Pokazuje, jak pobrać prostokąt akapitu w `TextFrame` przy użyciu `GetRect()`, jak uzyskać współrzędne akapitu i fragmentu wewnątrz ramki tekstowej komórki tabeli oraz podkreśla ważne szczegóły, takie jak jednostki miary, wpływ zawijania tekstu na granice, konwersję pikseli oraz wartości efektywnego formatowania akapitu.

## **Uzyskaj współrzędne akapitu i fragmentu w TextFrame**

Korzystając z Aspose.Slides dla .NET, programiści mogą teraz uzyskać prostokątne współrzędne akapitu w kolekcji akapitów TextFrame. Pozwala to także uzyskać współrzędne fragmentu w kolekcji fragmentów akapitu. W tym temacie pokażemy, przy pomocy przykładu, jak uzyskać prostokątne współrzędne akapitu wraz z pozycją fragmentu wewnątrz akapitu.

## **Uzyskaj prostokątne współrzędne akapitu**

Dodano nową metodę **GetRect()**. Umożliwia ona pobranie prostokąta granic akapitu.

```c#
 // Utwórz obiekt Presentation, który reprezentuje plik prezentacji
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
        var textFrame = (ITextFrame)shape.TextFrame;
        RectangleF rect = ((Paragraph)textFrame.Paragraphs[0]).GetRect();
}
```

## **Uzyskaj rozmiar akapitu i fragmentu wewnątrz ramki tekstowej komórki tabeli**

Aby uzyskać rozmiar i współrzędne [Fragmentu](https://reference.aspose.com/slides/pl/net/aspose.slides/portion) lub [Akapitu](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraph) w ramce tekstowej komórki tabeli, możesz użyć metod [IPortion.GetRect](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/methods/getrect) i [IParagraph.GetRect](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/methods/getrect).

Poniższy kod przykładowy demonstruje opisaną operację:

```csharp
using (Presentation pres = new Presentation("source.pptx"))
{
    Table tbl = pres.Slides[0].Shapes[0] as Table;

    ICell cell = tbl.Rows[1][1];


    double x = tbl.X + tbl.Rows[1][1].OffsetX;
    double y = tbl.Y + tbl.Rows[1][1].OffsetY;

    foreach (IParagraph para in cell.TextFrame.Paragraphs)
    {
        if (para.Text == "")
            continue;

        RectangleF rect = para.GetRect();
        IAutoShape shape =
            pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
        shape.LineFormat.FillFormat.FillType = FillType.Solid;


        foreach (IPortion portion in para.Portions)
        {
            if (portion.Text.Contains("0"))
            {
                rect = portion.GetRect();
                shape =
                    pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle,
                        rect.X + (float)x, rect.Y + (float)y, rect.Width, rect.Height);

                shape.FillFormat.FillType = FillType.NoFill;
            }
        }
    }
}
```

## **FAQ**

**W jakich jednostkach zwracane są współrzędne akapitu i fragmentów tekstu?**

W punktach, gdzie 1 cal = 72 punkty. Dotyczy to wszystkich współrzędnych i wymiarów na slajdzie.

**Czy zawijanie wyrazów wpływa na granice akapitu?**

Tak. Jeśli [zawijanie](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat/wraptext/) jest włączone w [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/textframe/), tekst jest dzielony, aby dopasować się do szerokości obszaru, co zmienia rzeczywiste granice akapitu.

**Czy współrzędne akapitu można wiarygodnie przeliczyć na piksele w wyeksportowanym obrazie?**

Tak. Przelicz punkty na piksele używając: piksele = punkty × (DPI / 72). Wynik zależy od wybranego DPI podczas renderowania/eksportu.

**Jak uzyskać „efektywne” parametry formatowania akapitu, uwzględniając dziedziczenie stylu?**

Użyj [efektywnej struktury danych formatowania akapitu](/slides/pl/net/shape-effective-properties/); zwraca ona ostateczne, skonsolidowane wartości wcięć, odstępów, zawijania, RTL i inne.