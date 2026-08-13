---
title: Zmiana rozmiaru kształtów na slajdach prezentacji w .NET
type: docs
weight: 130
url: /pl/net/re-sizing-shapes-on-slide/
keywords:
- zmiana rozmiaru kształtu
- zmień rozmiar kształtu
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Łatwo zmień rozmiar kształtów na slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET — automatyzuj dostosowywanie układu slajdów i zwiększ wydajność."
---
## **Przegląd**

Jednym z najczęstszych pytań klientów Aspose.Slides dla .NET jest, jak zmienić rozmiar kształtów, tak aby przy zmianie rozmiaru slajdu dane nie były obcinane. Ten krótki artykuł techniczny pokazuje, jak to zrobić.

## **Zmienianie rozmiaru kształtów**

Aby zapobiec nieprawidłowemu rozmieszczeniu kształtów po zmianie rozmiaru slajdu, zaktualizuj położenie i wymiary każdego kształtu, aby dopasować je do nowego układu slajdu.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Load the presentation file.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Get the original slide size.
    float currentHeight = presentation.SlideSize.Size.Height;
    float currentWidth = presentation.SlideSize.Size.Width;

    // Change the slide size without scaling existing shapes.
    presentation.SlideSize.SetSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Get the new slide size.
    float newHeight = presentation.SlideSize.Size.Height;
    float newWidth = presentation.SlideSize.Size.Width;

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Resize and reposition shapes on every slide.
    foreach (ISlide slide in presentation.Slides)
    {
        foreach (IShape shape in slide.Shapes)
        {
            // Scale the shape size.
            shape.Height *= heightRatio;
            shape.Width *= widthRatio;

            // Scale the shape position.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
Jeśli slajd zawiera tabelę, powyższy kod nie będzie działał poprawnie. W takim przypadku każdy komórka tabeli musi zostać przeskalowana.
{{% /alert %}}

Użyj poniższego kodu, aby zmienić rozmiar slajdów zawierających tabele. W przypadku tabel skaluj wysokości poszczególnych wierszy i szerokości kolumn zamiast szerokości i wysokości kształtu – zastosowanie obu spowodowałoby podwójne skalowanie tabeli i przesunięcie jej poza slajd.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Pobierz oryginalny rozmiar slajdu.
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
            if (shape is ITable)
            {
                // Skaluj rozmiar tabeli poprzez jej wiersze i kolumny.
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
            else
            {
                // Skaluj rozmiar kształtu.
                shape.Height *= heightRatio;
                shape.Width *= widthRatio;
            }

            // Skaluj pozycję kształtu.
            shape.Y *= heightRatio;
            shape.X *= widthRatio;
        }
    }

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Dlaczego kształty są zniekształcone lub obcięte po zmianie rozmiaru slajdu?

Podczas zmiany rozmiaru slajdu kształty zachowują swoje pierwotne położenie i rozmiar, chyba że skala zostanie wyraźnie zmieniona. Może to skutkować przycięciem treści lub nieprawidłowym rozmieszczeniem kształtów.

### Czy podany kod działa dla wszystkich typów kształtów?

Podstawowy przykład działa dla większości typów kształtów (pola tekstowe, obrazy, wykresy itp.). Jednak dla tabel należy obsłużyć wiersze i kolumny osobno, ponieważ wysokość i szerokość tabeli są określane przez wymiary poszczególnych komórek.

### Jak zmienić rozmiar tabel przy zmianie rozmiaru slajdu?

Należy przejść przez wszystkie wiersze i kolumny tabeli oraz proporcjonalnie zmienić ich wysokość i szerokość, jak pokazano w drugim przykładzie kodu.

### Czy to skalowanie działa dla slajdów nadrzędnych i układów slajdów?

Tak, ale należy również przejść przez [Masters](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/masters/) i [LayoutSlides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/layoutslides/) oraz zastosować tę samą logikę skalowania do ich kształtów, aby zapewnić spójność w całej prezentacji.

### Czy mogę zmienić orientację slajdu (pionowa/pozioma) wraz ze zmianą rozmiaru?

Tak. Można ustawić [presentation.SlideSize.Orientation](https://reference.aspose.com/slides/pl/net/aspose.slides/islidesize/orientation/), aby zmienić orientację. Upewnij się, że logika skalowania jest odpowiednio dostosowana, aby zachować układ.

### Czy istnieje limit rozmiaru slajdu, który mogę ustawić?

Aspose.Slides obsługuje rozmiary niestandardowe, ale bardzo duże rozmiary mogą wpływać na wydajność lub kompatybilność z niektórymi wersjami PowerPointa.

### Jak zapobiec zniekształceniu kształtów o stałym stosunku proporcji?

Można sprawdzić właściwość `AspectRatioLocked` kształtu przed skalowaniem. Jeśli jest zablokowana, należy proporcjonalnie dostosować szerokość lub wysokość zamiast skalować je osobno.