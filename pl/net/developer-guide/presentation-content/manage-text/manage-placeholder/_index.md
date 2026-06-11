---
title: Zarządzanie polami zastępczymi prezentacji w .NET
linktitle: Zarządzaj polami zastępczymi
type: docs
weight: 10
url: /pl/net/manage-placeholder/
keywords:
- pole zastępcze
- pole zastępcze tekstowe
- pole zastępcze obrazu
- pole zastępcze wykresu
- tekst podpowiedzi
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Bezproblemowo zarządzaj polami zastępczymi w Aspose.Slides dla .NET: zamieniaj tekst, dostosowuj podpowiedzi i ustaw przezroczystość obrazu w PowerPoint i OpenDocument."
---
## **Przegląd**

Aspose.Slides umożliwia programowe zarządzanie polami zastępczymi prezentacji. Ten artykuł wyjaśnia, jak wyszukiwać pola zastępcze na slajdach i zmieniać ich tekst, ustawiać własny tekst podpowiedzi dla układów pól zastępczych oraz regulować przezroczystość obrazu używanego jako tło pola zastępczego. Zawiera także krótkie FAQ, które wyjaśnia różnicę między podstawowymi polami zastępczymi a lokalnymi kształtami, opisuje, jak zmiany pól zastępczych mogą być stosowane poprzez układy lub wzorce, oraz wskazuje zarządzanie polami zastępczymi nagłówka i stopki.

## **Zmienianie tekstu w polu zastępczym**

Korzystając z [Aspose.Slides for .NET](/slides/pl/net/), można wyszukiwać i modyfikować pola zastępcze na slajdach w prezentacjach. Aspose.Slides umożliwia wprowadzanie zmian w tekście pola zastępczego.

**Wymaganie wstępne**: Potrzebujesz prezentacji zawierającej pole zastępcze. Taką prezentację możesz utworzyć w standardowej aplikacji Microsoft PowerPoint.

1. Utwórz instancję klasy [`Presentation`](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) i przekaż prezentację jako parametr.
2. Uzyskaj odwołanie do slajdu za pomocą jego indeksu.
3. Iteruj po kształtach, aby znaleźć pole zastępcze.
4. Rzutuj kształt pola zastępczego na [`AutoShape`](https://reference.aspose.com/slides/pl/net/aspose.slides/autoshape/) i zmień tekst przy użyciu [`TextFrame`](https://reference.aspose.com/slides/pl/net/aspose.slides/textframe/) powiązanego z [`AutoShape`](https://reference.aspose.com/slides/pl/net/aspose.slides/autoshape/).
5. Zapisz zmodyfikowaną prezentację.

Ten kod C# pokazuje, jak zmienić tekst w polu zastępczym:

```c#
// Tworzy instancję klasy Presentation
using (Presentation pres = new Presentation("ReplacingText.pptx"))
{

    // Uzyskuje dostęp do pierwszego slajdu
    ISlide sld = pres.Slides[0];

    // Iteruje po kształtach, aby znaleźć pole zastępcze
    foreach (IShape shp in sld.Shapes)
        if (shp.Placeholder != null)
        {
            // Zmienia tekst w każdym polu zastępczym
            ((IAutoShape)shp).TextFrame.Text = "This is a Placeholder";
        }

    // Zapisuje prezentację na dysku
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Ustawianie tekstu podpowiedzi w polu zastępczym**

Standardowe i wbudowane układy zawierają teksty podpowiedzi pól zastępczych, takie jak ***Kliknij, aby dodać tytuł*** lub ***Kliknij, aby dodać podtytuł***. Korzystając z Aspose.Slides, możesz wstawić własne teksty podpowiedzi do układów pól zastępczych.

Ten kod C# pokazuje, jak ustawić tekst podpowiedzi w polu zastępczym:

```c#
using (Presentation pres = new Presentation("Presentation2.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Slide.Shapes) // Iteruje po slajdzie
    {
        if (shape.Placeholder != null && shape is AutoShape)
        {
            string text = "";
            if (shape.Placeholder.Type == PlaceholderType.CenteredTitle) // PowerPoint wyświetla "Kliknij, aby dodać tytuł"
            {
                text = "Add Title";
            }
            else if (shape.Placeholder.Type == PlaceholderType.Subtitle) // Dodaje podtytuł
            {
                text = "Add Subtitle";
            }

            ((IAutoShape)shape).TextFrame.Text = text;

            Console.WriteLine($"Placeholder with text: {text}");
        }
    }

    pres.Save("Placeholders_PromptText.pptx", SaveFormat.Pptx);
}
```

## **Ustawianie przezroczystości obrazu pola zastępczego**

Aspose.Slides umożliwia ustawienie przezroczystości obrazu tła w polu zastępczym tekstu. Dostosowując przezroczystość obrazu w takim ramce, możesz uwydatnić tekst lub obraz (w zależności od kolorów tekstu i obrazu).

Ten kod C# pokazuje, jak ustawić przezroczystość tła obrazu (wewnątrz kształtu):

```c#
using (var presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    
    autoShape.FillFormat.FillType = FillType.Picture;
    autoShape.FillFormat.PictureFillFormat.Picture.Image = presentation.Images.AddImage(File.ReadAllBytes("image.png"));
    autoShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    autoShape.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(75);
}
```

## **FAQ**

**Czym jest podstawowe pole zastępcze i czym różni się od lokalnego kształtu na slajdzie?**

Podstawowe pole zastępcze to oryginalny kształt w układzie lub wzorcu, z którego dziedziczy kształt slajdu — typ, położenie i niektóre formatowania pochodzą z niego. Lokalny kształt jest niezależny; jeśli nie ma podstawowego pola zastępczego, dziedziczenie nie ma zastosowania.

**Jak zaktualizować wszystkie tytuły lub podpisy w całej prezentacji bez iteracji po każdym slajdzie?**

Edytuj odpowiednie pole zastępcze w układzie lub wzorcu. Slajdy oparte na tych układach/wzorcu automatycznie odziedziczą zmianę.

**Jak kontrolować standardowe pola zastępcze nagłówka/stopki — datę i godzinę, numer slajdu oraz tekst stopki?**

Użyj menedżerów HeaderFooter w odpowiednim zakresie (zwykłe slajdy, układy, wzorzec, notatki/ulotki), aby włączyć lub wyłączyć te pola zastępcze oraz ustawić ich zawartość.