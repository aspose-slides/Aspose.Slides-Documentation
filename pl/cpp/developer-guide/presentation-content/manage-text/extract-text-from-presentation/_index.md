---
title: Zaawansowane wyodrębnianie tekstu z prezentacji w C++
linktitle: Wyodrębnij tekst
type: docs
weight: 90
url: /pl/cpp/extract-text-from-presentation/
keywords:
- wyodrębnij tekst
- wyodrębnij tekst ze slajdu
- wyodrębnij tekst z prezentacji
- wyodrębnij tekst z PowerPoint
- wyodrębnij tekst z OpenDocument
- wyodrębnij tekst z PPT
- wyodrębnij tekst z PPTX
- wyodrębnij tekst z ODP
- pobierz tekst
- pobierz tekst ze slajdu
- pobierz tekst z prezentacji
- pobierz tekst z PowerPoint
- pobierz tekst z OpenDocument
- pobierz tekst z PPT
- pobierz tekst z PPTX
- pobierz tekst z ODP
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Szybko wyodrębnij tekst z prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++. Postępuj zgodnie z naszym prostym, krok po kroku przewodnikiem, aby zaoszczędzić czas."
---
## **Przegląd**

Ekstrakcja tekstu z prezentacji jest powszechnym, ale istotnym zadaniem dla programistów pracujących z zawartością slajdów. Niezależnie od tego, czy masz do czynienia z plikami Microsoft PowerPoint w formacie PPT lub PPTX, czy prezentacjami OpenDocument (ODP), dostęp i pobieranie danych tekstowych może być kluczowe dla analizy, automatyzacji, indeksowania lub migracji treści.

Ten artykuł przedstawia kompleksowy przewodnik, jak efektywnie wyodrębniać tekst z różnych formatów prezentacji, w tym PPT, PPTX i ODP, przy użyciu Aspose.Slides for C++. Dowiesz się, jak systematycznie iterować po elementach prezentacji, aby dokładnie pobrać potrzebną treść tekstową.

## **Wyodrębnianie tekstu ze slajdu**

Aspose.Slides for C++ udostępnia przestrzeń nazw [Aspose.Slides.Util](https://reference.aspose.com/slides/pl/cpp/aspose.slides.util/), która zawiera klasę [SlideUtil](https://reference.aspose.com/slides/pl/cpp/aspose.slides.util/slideutil/). Klasa ta udostępnia kilka przeciążonych metod statycznych do wyodrębniania całego tekstu z prezentacji lub slajdu. Aby wyodrębnić tekst ze slajdu w prezentacji, użyj metody [GetAllTextBoxes](https://reference.aspose.com/slides/pl/cpp/aspose.slides.util/slideutil/getalltextboxes/). Metoda ta przyjmuje jako parametr obiekt typu [IBaseSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ibaseslide/). Po wywołaniu metoda przeszukuje cały slajd w poszukiwaniu tekstu i zwraca tablicę obiektów typu [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/), zachowując formatowanie tekstu.

Poniższy fragment kodu wyodrębnia cały tekst z pierwszego slajdu prezentacji:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Wyodrębnianie tekstu z prezentacji**

Aby przeszukać tekst w całej prezentacji, użyj statycznej metody [GetAllTextFrames](https://reference.aspose.com/slides/pl/cpp/aspose.slides.util/slideutil/getalltextframes/) udostępnionej przez klasę [SlideUtil](https://reference.aspose.com/slides/pl/cpp/aspose.slides.util/slideutil/). Przyjmuje ona dwa parametry:

1. Pierwszy, obiekt [IPresentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/) reprezentujący prezentację PowerPoint lub OpenDocument, z której ma zostać wyodrębniony tekst.
1. Drugi, wartość `Boolean` określająca, czy slajdy wzorcowe mają być uwzględnione podczas skanowania tekstu w prezentacji.

Metoda zwraca tablicę obiektów typu [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/), zawierającą informacje o formatowaniu tekstu. Poniższy kod skanuje tekst i szczegóły formatowania w prezentacji, w tym slajdy wzorcowe.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Kategoryzowane i szybkie wyodrębnianie tekstu**

Klasa [PresentationFactory](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentationfactory/) również udostępnia metody do wyodrębniania całego tekstu z prezentacji:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

Argument wyliczeniowy [TextExtractionArrangingMode](https://reference.aspose.com/slides/pl/cpp/aspose.slides/textextractionarrangingmode/) określa tryb organizacji wyniku wyodrębniania tekstu i może przyjmować następujące wartości:
- `Unarranged` – surowy tekst bez uwzględnienia jego pozycji na slajdzie.
- `Arranged` – tekst jest ułożony w tej samej kolejności, co na slajdzie.

Tryb `Unarranged` można stosować, gdy kluczowa jest szybkość; jest szybszy niż tryb `Arranged`.

[IPresentationText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentationtext/) reprezentuje surowy tekst wyodrębniony z prezentacji. Jej metoda `get_SlidesText()` zwraca tablicę obiektów typu [ISlideText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidetext/). Każdy obiekt reprezentuje tekst na odpowiadającym mu slajdzie. Obiekt typu [ISlideText](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidetext/) posiada następujące metody:

- `get_Text()` – tekst znajdujący się w kształtach slajdu.
- `get_MasterText()` – tekst znajdujący się w kształtach slajdu wzorcowego powiązanego z tym slajdem.
- `get_LayoutText()` – tekst znajdujący się w kształtach slajdu układu powiązanego z tym slajdem.
- `get_NotesText()` – tekst znajdujący się w kształtach slajdu notatek powiązanego z tym slajdem.
- `get_CommentsText()` – tekst znajdujący się w komentarzach powiązanych z tym slajdem.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **FAQ**

**Jak szybko Aspose.Slides przetwarza duże prezentacje podczas wyodrębniania tekstu?**

Aspose.Slides jest zoptymalizowane pod kątem wysokiej wydajności i może przetwarzać nawet [duże prezentacje](/slides/pl/cpp/open-presentation/), co czyni je odpowiednim do scenariuszy przetwarzania w czasie rzeczywistym lub wsadowego.

**Czy Aspose.Slides może wyodrębniać tekst z tabel i wykresów w prezentacjach?**

Tak. Aspose.Slides może wyodrębniać tekst z wielu elementów slajdu, w tym z tabel i obiektów powiązanych z wykresami, dzięki czemu możesz uzyskać dostęp i analizować treść tekstową w typowych strukturach prezentacji.

**Czy potrzebuję specjalnej licencji Aspose.Slides, aby wyodrębniać tekst z prezentacji?**

Możesz wyodrębniać tekst przy użyciu bezpłatnej wersji próbnej Aspose.Slides, choć będzie ona posiadać [pewne ograniczenia](/slides/pl/cpp/licensing/), takie jak przetwarzanie jedynie ograniczonej liczby slajdów. W celu nieograniczonego użytkowania i obsługi większych prezentacji zaleca się zakup pełnej licencji.