---
title: Konwertuj slajdy PowerPoint do PNG w .NET
linktitle: PowerPoint do PNG
type: docs
weight: 30
url: /pl/net/convert-powerpoint-to-png/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do PNG
- prezentacja do PNG
- slajd do PNG
- PPT do PNG
- PPTX do PNG
- zapisz PPT jako PNG
- zapisz PPTX jako PNG
- eksportuj PPT do PNG
- eksportuj PPTX do PNG
- .NET
- C#
- Aspose.Slides
description: "Konwertuj prezentacje PowerPoint do wysokiej jakości obrazów PNG szybko przy użyciu Aspose.Slides dla .NET, zapewniając precyzyjne, zautomatyzowane wyniki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na obrazy PNG przy użyciu Aspose.Slides. Pokazuje, jak ładować pliki prezentacji w formatach takich jak PPT, PPTX i ODP, renderować slajdy jako obrazy oraz zapisywać wyniki w formacie PNG.

Artykuł również demonstruje, jak dostosować wygenerowane obrazy PNG, ustawiając wartości skalowania lub określając żądaną szerokość i wysokość.

## **Konwertuj PowerPoint do PNG**

Wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Pobierz obiekt slajdu z kolekcji [Presentation.Slides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/properties/slides) przy użyciu interfejsu [ISlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide).
3. Użyj metody [ISlide.GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/getimage/), aby uzyskać miniaturkę każdego slajdu.
4. Użyj metody [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.ipresentation/save/methods/5), aby zapisać miniaturkę slajdu w formacie PNG.

Ten kod w języku C# pokazuje, jak konwertować prezentację PowerPoint na PNG. Obiekt Presentation może wczytać pliki PPT, PPTX, ODP itp., a następnie każdy slajd w obiekcie Presentation jest konwertowany na format PNG lub inne formaty obrazów.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Konwertuj PowerPoint do PNG z niestandardowymi wymiarami**

Jeśli chcesz uzyskać pliki PNG o określonej skali, możesz ustawić wartości `desiredX` i `desiredY`, które określają wymiary wynikowej miniaturki.

Ten kod w języku C# demonstruje opisaną operację:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Konwertuj PowerPoint do PNG z niestandardowym rozmiarem**

Jeśli chcesz uzyskać pliki PNG o określonym rozmiarze, możesz przekazać wybrane argumenty `width` i `height` dla `imageSize`.

Ten kod pokazuje, jak konwertować PowerPoint na PNG, określając rozmiar obrazów:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **FAQ**

**Jak mogę wyeksportować tylko określony kształt (np. wykres lub obraz), a nie cały slajd?**

Aspose.Slides obsługuje [generowanie miniatur dla pojedynczych kształtów](/slides/pl/net/create-shape-thumbnails/); możesz renderować kształt do obrazu PNG.

**Czy konwersja równoległa jest obsługiwana na serwerze?**

Tak, ale [nie udostępniaj](/slides/pl/net/multithreading/) jednej instancji prezentacji w wielu wątkach. Użyj osobnej instancji dla każdego wątku lub procesu.

**Jakie są ograniczenia wersji próbnej przy eksportowaniu do PNG?**

Tryb oceny dodaje znak wodny do wyjściowych obrazów i narzuca [inne ograniczenia](/slides/pl/net/licensing/), dopóki nie zostanie zastosowana licencja.