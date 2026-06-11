---
title: Zaawansowane wyodrębnianie tekstu z prezentacji w .NET
linktitle: Wyodrębnij tekst
type: docs
weight: 90
url: /pl/net/extract-text-from-presentation/
keywords:
- wyodrębnić tekst
- wyodrębnić tekst ze slajdu
- wyodrębnić tekst z prezentacji
- wyodrębnić tekst z PowerPoint
- wyodrębnić tekst z OpenDocument
- wyodrębnić tekst z PPT
- wyodrębnić tekst z PPTX
- wyodrębnić tekst z ODP
- pobrać tekst
- pobrać tekst ze slajdu
- pobrać tekst z prezentacji
- pobrać tekst z PowerPoint
- pobrać tekst z OpenDocument
- pobrać tekst z PPT
- pobrać tekst z PPTX
- pobrać tekst z ODP
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Szybko wyodrębnij tekst z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET. Postępuj zgodnie z naszym prostym, krok po kroku przewodnikiem, aby zaoszczędzić czas."
---
## **Przegląd**

Wyodrębnianie tekstu z prezentacji to powszechne, a jednocześnie istotne zadanie dla programistów pracujących z treścią slajdów. Niezależnie od tego, czy masz do czynienia z plikami Microsoft PowerPoint w formacie PPT lub PPTX, czy z prezentacjami OpenDocument (ODP), dostęp i pobieranie danych tekstowych może być kluczowe dla analiz, automatyzacji, indeksowania lub migracji treści.

Ten artykuł zawiera kompleksowy przewodnik, jak efektywnie wyodrębniać tekst z różnych formatów prezentacji, w tym PPT, PPTX i ODP, przy użyciu Aspose.Slides dla .NET. Dowiesz się, jak systematycznie iterować po elementach prezentacji, aby dokładnie pobrać potrzebną treść tekstową.

## **Wyodrębnianie tekstu ze slajdu**

Aspose.Slides dla .NET udostępnia przestrzeń nazw [Aspose.Slides.Util](https://reference.aspose.com/slides/pl/net/aspose.slides.util/), która zawiera klasę [SlideUtil](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/). Klasa ta udostępnia kilka przeciążonych metod statycznych do wyodrębniania całego tekstu z prezentacji lub slajdu. Aby wyodrębnić tekst ze slajdu w prezentacji, użyj metody [GetAllTextBoxes](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/getalltextboxes/). Metoda ta przyjmuje jako parametr obiekt typu [IBaseSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseslide/). Po wykonaniu metoda przeszukuje cały slajd pod kątem tekstu i zwraca tablicę obiektów typu [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/), zachowując formatowanie tekstu.

Poniższy fragment kodu wyodrębnia cały tekst z pierwszego slajdu prezentacji:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Wyodrębnianie tekstu z prezentacji**

Do skanowania tekstu z całej prezentacji użyj statycznej metody [GetAllTextFrames](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/getalltextframes/) udostępnianej przez klasę [SlideUtil](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/). Przyjmuje ona dwa parametry:

1. Po pierwsze, obiekt [IPresentation](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/) reprezentujący prezentację PowerPoint lub OpenDocument, z której zostanie wyodrębniony tekst.
1. Po drugie, wartość typu `Boolean` określająca, czy slajdy główne (master) mają być uwzględnione podczas skanowania tekstu z prezentacji.

Metoda zwraca tablicę obiektów typu [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/), zawierającą informacje o formatowaniu tekstu. Poniższy kod skanuje tekst i szczegóły formatowania z prezentacji, w tym slajdy główne.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Kategoryzowane i szybkie wyodrębnianie tekstu**

Klasa [PresentationFactory](https://reference.aspose.com/slides/pl/net/aspose.slides/presentationfactory/) również udostępnia metody do wyodrębniania całego tekstu z prezentacji:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

Argument wyliczenia [TextExtractionArrangingMode](https://reference.aspose.com/slides/pl/net/aspose.slides/textextractionarrangingmode/) określa tryb organizacji wyniku wyodrębniania tekstu i może przyjmować następujące wartości:
- `Unarranged` – surowy tekst bez uwzględnienia jego położenia na slajdzie.
- `Arranged` – tekst uporządkowany w takiej samej kolejności, jak na slajdzie.

Tryb `Unarranged` można używać, gdy kluczowa jest szybkość; jest szybszy niż tryb `Arranged`.

[IPresentationText](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationtext/) reprezentuje surowy tekst wyodrębniony z prezentacji. Jego właściwość `SlidesText` zwraca tablicę obiektów typu [ISlideText](https://reference.aspose.com/slides/pl/net/aspose.slides/islidetext/). Każdy obiekt reprezentuje tekst na odpowiadającym mu slajdzie. Obiekt typu [ISlideText](https://reference.aspose.com/slides/pl/net/aspose.slides/islidetext/) posiada następujące właściwości:

- `Text` – tekst wewnątrz kształtów slajdu.
- `MasterText` – tekst wewnątrz kształtów slajdu głównego powiązanego z tym slajdem.
- `LayoutText` – tekst wewnątrz kształtów slajdu układu powiązanego z tym slajdem.
- `NotesText` – tekst wewnątrz kształtów slajdu notatek powiązanego z tym slajdem.
- `CommentsText` – tekst w komentarzach powiązanych z tym slajdem.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **FAQ**

**Jak szybko Aspose.Slides przetwarza duże prezentacje podczas wyodrębniania tekstu?**

Aspose.Slides jest zoptymalizowany pod kątem wysokiej wydajności i może przetwarzać nawet [duże prezentacje](/slides/pl/net/open-presentation/), co czyni go odpowiednim do scenariuszy przetwarzania w czasie rzeczywistym lub hurtowego.

**Czy Aspose.Slides może wyodrębniać tekst z tabel i wykresów w prezentacjach?**

Tak. Aspose.Slides może wyodrębniać tekst z wielu elementów slajdu, w tym z tabel i obiektów związanych z wykresami, dzięki czemu możesz uzyskać dostęp do treści tekstowych i analizować je w typowych strukturach prezentacji.

**Czy potrzebuję specjalnej licencji Aspose.Slides, aby wyodrębniać tekst z prezentacji?**

Możesz wyodrębniać tekst przy użyciu bezpłatnej wersji próbnej Aspose.Slides, choć będzie ona miała [pewne ograniczenia](/slides/pl/net/licensing/), takie jak przetwarzanie jedynie ograniczonej liczby slajdów. Dla nieograniczonego użytku i obsługi większych prezentacji zaleca się zakup pełnej licencji.