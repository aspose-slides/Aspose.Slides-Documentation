---
title: Zmienianie rozmiaru kształtów na slajdach prezentacji w .NET
type: docs
weight: 130
url: /pl/net/re-sizing-shapes-on-slide/
keywords:
- zmień rozmiar kształtu
- zmień rozmiar kształtu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Łatwo zmieniaj rozmiar kształtów na slajdach PowerPoint i OpenDocument za pomocą Aspose.Slides dla .NET—automatyzuj dostosowywanie układu slajdów i zwiększaj wydajność."
---
## **Przegląd**

Jednym z najczęściej zadawanych pytań przez klientów Aspose.Slides dla .NET jest, jak zmienić rozmiar kształtów, aby gdy zmieni się rozmiar slajdu, dane nie były obcięte. Ten krótki artykuł techniczny pokazuje, jak to zrobić.

## **Zmienianie rozmiaru kształtów**

Aby zapobiec nieprawidłowemu rozmieszczeniu kształtów po zmianie rozmiaru slajdu, zaktualizuj pozycję i wymiary każdego kształtu tak, aby odpowiadały nowemu układowi slajdu.

```c#
// Wczytaj plik prezentacji.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Pobierz pierwotny rozmiar slajdu.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Zmień rozmiar slajdu bez skalowania istniejących kształtów.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Pobierz nowy rozmiar slajdu.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Zmień rozmiar i przesuń kształty na każdym slajdzie.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Skaluj rozmiar kształtu.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Skaluj pozycję kształtu.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
Jeśli slajd zawiera tabelę, powyższy kod nie będzie działał prawidłowo. W takim przypadku każda komórka w tabeli musi zostać przeskalowana.
{{% /alert %}}

Użyj poniższego kodu po swojej stronie, aby zmienić rozmiar slajdów zawierających tabele. Dla tabel ustawianie szerokości lub wysokości jest przypadkiem szczególnym: musisz dostosować wysokość poszczególnych wierszy i szerokość kolumn, aby zmienić całkowity rozmiar tabeli.

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Pobierz pierwotny rozmiar slajdu.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Zmień rozmiar slajdu bez skalowania istniejących kształtów.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.SlideSize.Orientation = SlideOrienation.Portrait;

    // Pobierz nowy rozmiar slajdu.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    foreach (IMasterSlide master in presentation.Masters)
    {
        foreach (IShape shape in master.Shapes)
        {
            // Skaluj rozmiar kształtu.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Skaluj pozycję kształtu.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }

        foreach (ILayoutSlide layoutSlide in master.LayoutSlides)
        {
            foreach (IShape shape in layoutSlide.Shapes)
            {
                // Skaluj rozmiar kształtu.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;

                // Skaluj pozycję kształtu.
                shape.Y *= heightRatio;
                shape.X *= widthRatio;
            }
        }
    }

    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Skaluj rozmiar kształtu.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Skaluj pozycję kształtu.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;

            if (shape is ITable)
            {
                ITable table = (ITable)shape;
                foreach (IRow row in table.Rows)
                {
                    row.MinimalHeight *= heightRatio;
                }
                foreach (IColumn column in table.Columns)
                {
                    column.Width *= widthRatio;
                }
            }
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Dlaczego kształty są zniekształcone lub obcięte po zmianie rozmiaru slajdu?**

Podczas zmiany rozmiaru slajdu kształty zachowują swoją pierwotną pozycję i rozmiar, chyba że skala zostanie jawnie zmieniona. Może to skutkować przycięciem zawartości lub nieprawidłowym rozmieszczeniem kształtów.

**Czy dostarczony kod działa dla wszystkich typów kształtów?**

Podany przykład działa dla większości typów kształtów (pola tekstowe, obrazy, wykresy itp.). Jednak w przypadku tabel trzeba obsłużyć wiersze i kolumny osobno, ponieważ wysokość i szerokość tabeli są określane przez wymiary poszczególnych komórek.

**Jak zmienić rozmiar tabel przy zmianie rozmiaru slajdu?**

Należy przeiterować wszystkie wiersze i kolumny tabeli oraz proporcjonalnie zmienić ich wysokość i szerokość, jak pokazano w drugim przykładzie kodu.

**Czy to skalowanie działa dla slajdów mistrzowskich i układu?**

Tak, ale powinieneś również przejść przez [Masters](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/masters/) i [LayoutSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/layoutslides/) i zastosować tę samą logikę skalowania do ich kształtów, aby zapewnić spójność w całej prezentacji.

**Czy mogę zmienić orientację slajdu (pionowa/pozioma) wraz ze zmianą rozmiaru?**

Tak. Możesz ustawić [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/pl/net/aspose.slides/islidesize/orientation/), aby zmienić orientację. Upewnij się, że odpowiednio dostosujesz logikę skalowania, aby zachować układ.

**Czy istnieje limit rozmiaru slajdu, który mogę ustawić?**

Aspose.Slides obsługuje rozmiary niestandardowe, ale bardzo duże rozmiary mogą wpływać na wydajność lub kompatybilność z niektórymi wersjami PowerPointa.

**Jak zapobiec zniekształceniu kształtów o stałym współczynniku proporcji?**

Możesz sprawdzić właściwość `AspectRatioLocked` kształtu przed skalowaniem. Jeśli jest zablokowana, dostosuj szerokość lub wysokość proporcjonalnie, zamiast skalować je osobno.