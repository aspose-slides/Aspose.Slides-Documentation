---
title: Zaawansowane wyodrębnianie tekstu z prezentacji w .NET
linktitle: Wyodrębnij tekst
type: docs
weight: 90
url: /pl/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/pl/
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
description: "Szybko wyodrębniaj tekst z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides for .NET. Postępuj zgodnie z naszym prostym przewodnikiem krok po kroku, aby zaoszczędzić czas."
---
## **Przegląd**

Wyodrębnianie tekstu z prezentacji jest powszechnym, a jednocześnie niezbędnym zadaniem dla programistów pracujących z zawartością slajdów. Niezależnie od tego, czy masz do czynienia z plikami Microsoft PowerPoint w formacie PPT lub PPTX, czy z prezentacjami OpenDocument (ODP), dostęp i pobieranie danych tekstowych może być kluczowe dla analizy, automatyzacji, indeksowania lub migracji zawartości.

Ten artykuł zawiera kompleksowy przewodnik, jak efektywnie wyodrębniać tekst z różnych formatów prezentacji, w tym PPT, PPTX i ODP, przy użyciu Aspose.Slides for .NET. Dowiesz się, jak systematycznie iterować po elementach prezentacji, aby dokładnie pobrać potrzebną zawartość tekstową.

## **Wyodrębnianie tekstu ze slajdu**

Aspose.Slides for .NET udostępnia przestrzeń nazw [Aspose.Slides.Util](https://reference.aspose.com/slides/pl/net/aspose.slides.util/), która zawiera klasę [SlideUtil](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/). Klasa ta udostępnia kilka przeciążonych metod statycznych służących do wyodrębniania całego tekstu z prezentacji lub slajdu. Aby wyodrębnić tekst ze slajdu w prezentacji, użyj metody [GetAllTextBoxes](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/getalltextboxes/). Metoda ta przyjmuje jako parametr obiekt typu [IBaseSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseslide/). Po jej wykonaniu metoda przeszukuje cały slajd w poszukiwaniu tekstu i zwraca tablicę obiektów typu [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/), zachowując formatowanie tekstu.

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

Aby przeszukać tekst w całej prezentacji, użyj statycznej metody [GetAllTextFrames](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/getalltextframes/) udostępnionej przez klasę [SlideUtil](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/). Przyjmuje ona dwa parametry:

1. Po pierwsze, obiekt [IPresentation](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentation/), reprezentujący prezentację PowerPoint lub OpenDocument, z której zostanie wyodrębniony tekst.  
1. Po drugie, wartość typu `Boolean` określająca, czy przy skanowaniu tekstu z prezentacji należy uwzględnić slajdy główne (master).

Metoda zwraca tablicę obiektów typu [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/), wraz z informacjami o formatowaniu tekstu. Poniższy kod skanuje tekst i szczegóły formatowania w prezentacji, włączając slajdy główne.

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

Argument wyliczeniowy [TextExtractionArrangingMode](https://reference.aspose.com/slides/pl/net/aspose.slides/textextractionarrangingmode/) określa tryb organizacji wyniku wyodrębniania tekstu i może przyjmować następujące wartości:
- `Unarranged` – Surowy tekst bez uwzględnienia jego pozycji na slajdzie.  
- `Arranged` – Tekst jest ułożony w takiej samej kolejności jak na slajdzie.

Tryb nieuporządkowany można używać, gdy kluczowa jest prędkość; jest szybszy niż tryb uporządkowany.

[IPresentationText](https://reference.aspose.com/slides/pl/net/aspose.slides/ipresentationtext/) reprezentuje surowy tekst wyodrębniony z prezentacji. Jego właściwość `SlidesText` zwraca tablicę obiektów typu [ISlideText](https://reference.aspose.com/slides/pl/net/aspose.slides/islidetext/). Każdy obiekt reprezentuje tekst na odpowiednim slajdzie. Obiekt typu [ISlideText](https://reference.aspose.com/slides/pl/net/aspose.slides/islidetext/) posiada następujące właściwości:

- `Text` – Tekst wewnątrz kształtów slajdu.  
- `MasterText` – Tekst wewnątrz kształtów slajdu głównego (master) powiązanego z tym slajdem.  
- `LayoutText` – Tekst wewnątrz kształtów slajdu układu (layout) powiązanego z tym slajdem.  
- `NotesText` – Tekst wewnątrz kształtów notatek powiązanych z tym slajdem.  
- `CommentsText` – Tekst w komentarzach powiązanych z tym slajdem.

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

Aspose.Slides jest zoptymalizowane pod kątem wysokiej wydajności i potrafi przetwarzać nawet [duże prezentacje](/slides/pl/net/open-presentation/), co czyni je odpowiednim do scenariuszy przetwarzania w czasie rzeczywistym lub wsadowego.

**Czy Aspose.Slides może wyodrębniać tekst z tabel i wykresów w prezentacjach?**

Tak. Aspose.Slides może wyodrębniać tekst z wielu elementów slajdu, w tym z tabel i obiektów powiązanych z wykresami, dzięki czemu możesz uzyskać dostęp i analizować treść tekstową w typowych strukturach prezentacji.

**Czy potrzebna jest specjalna licencja Aspose.Slides do wyodrębniania tekstu z prezentacji?**

Możesz wyodrębniać tekst przy użyciu bezpłatnej wersji próbnej Aspose.Slides, choć będzie ona miała [pewne ograniczenia](/slides/pl/net/licensing/), takie jak przetwarzanie tylko ograniczonej liczby slajdów. Dla nieograniczonego użytku i obsługi większych prezentacji zaleca się zakup pełnej licencji.