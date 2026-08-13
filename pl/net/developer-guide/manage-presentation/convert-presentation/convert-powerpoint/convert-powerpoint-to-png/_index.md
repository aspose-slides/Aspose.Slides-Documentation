---
title: Konwertowanie slajdów PowerPoint na PNG w .NET
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
description: "Konwertuj prezentacje PowerPoint na wysokiej jakości obrazy PNG szybko przy użyciu Aspose.Slides dla .NET, zapewniając precyzyjne, zautomatyzowane wyniki."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak konwertować prezentacje PowerPoint na obrazy PNG przy użyciu Aspose.Slides. Pokazuje, jak wczytywać pliki prezentacji w formatach takich jak PPT, PPTX i ODP, renderować slajdy jako obrazy oraz zapisywać wyniki w formacie PNG.

Artykuł demonstruje również, jak dostosować wygenerowane obrazy PNG, ustawiając wartości skali lub określając żądaną szerokość i wysokość.

## **Konwertowanie PowerPoint na PNG**

Postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Pobierz obiekt slajdu z kolekcji [Presentation.Slides](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/properties/slides) znajdującej się pod interfejsem [ISlide](https://reference.aspose.com/slides/pl/net/aspose.slides/islide).
3. Użyj metody [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/getimage/) aby wyrenderować każdy slajd w wymaganej skali.
4. Użyj metody [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/pl/net/aspose.slides.ipresentation/save/methods/5) aby zapisać miniaturkę slajdu w formacie PNG.

Ten kod w C# pokazuje, jak przekonwertować prezentację PowerPoint na PNG. Obiekt Presentation może wczytywać pliki PPT, PPTX, ODP itp., a każdy slajd w obiekcie prezentacji jest konwertowany na format PNG lub inny format obrazu.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 
**Uwaga:** Argumenty skali `1f, 1f` renderują każdy slajd w jego pełnym rozmiarze, więc slajd 720×540 pt daje obraz 720×540 px. Przeciążenie bez parametrów [GetImage()](https://reference.aspose.com/slides/pl/net/aspose.slides/islide/getimage/) zwraca znacznie mniejszą miniaturę podglądu. 
{{% /alert %}} 

## **Konwertowanie PowerPoint na PNG z niestandardowymi wymiarami**

Jeśli chcesz uzyskać pliki PNG o określonej skali, możesz ustawić wartości `desiredX` i `desiredY`, które określają wymiary powstałej miniatury. 

Ten kod w C# demonstruje opisaną operację:

```c#
using Aspose.Slides;

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

## **Konwertowanie PowerPoint na PNG z niestandardowym rozmiarem**

Jeśli chcesz uzyskać pliki PNG o określonym rozmiarze, możesz podać preferowane argumenty `width` i `height` dla `imageSize`. 

Ten kod pokazuje, jak przekonwertować PowerPoint na PNG, określając rozmiar obrazów: 

```c#
using System.Drawing;
using Aspose.Slides;

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

### Jak mogę wyeksportować tylko określony kształt (np. wykres lub obraz), a nie cały slajd?

Aspose.Slides obsługuje [generating thumbnails for individual shapes](/slides/pl/net/create-shape-thumbnails/); możesz wyrenderować wybrany kształt do obrazu PNG.

### Czy konwersja równoległa jest obsługiwana na serwerze?

Tak, ale [don’t share](/slides/pl/net/multithreading/) jednej instancji prezentacji pomiędzy wątkami. Użyj osobnej instancji na każdy wątek lub proces.

### Jakie są ograniczenia wersji próbnej przy eksporcie do PNG?

Tryb ewaluacji dodaje znak wodny do wyjściowych obrazów i wymusza [other restrictions](/slides/pl/net/licensing/), dopóki nie zostanie zastosowana licencja.