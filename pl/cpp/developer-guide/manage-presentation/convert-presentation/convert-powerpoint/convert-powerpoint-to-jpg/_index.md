---
title: Konwertowanie PPT i PPTX do JPG w C++
linktitle: PowerPoint do JPG
type: docs
weight: 60
url: /pl/cpp/convert-powerpoint-to-jpg/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do JPG
- prezentacja do JPG
- slajd do JPG
- PPT do JPG
- PPTX do JPG
- zapisz PowerPoint jako JPG
- zapisz prezentację jako JPG
- zapisz slajd jako JPG
- zapisz PPT jako JPG
- zapisz PPTX jako JPG
- eksportuj PPT do JPG
- eksportuj PPTX do JPG
- C++
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint (PPT, PPTX) na wysokiej jakości obrazy JPG w C++ przy użyciu Aspose.Slides, korzystając z szybkich i niezawodnych przykładów kodu."
---
## **Wprowadzenie**

Konwertowanie prezentacji PowerPoint i OpenDocument na obrazy JPG pomaga w udostępnianiu slajdów, optymalizacji wydajności oraz osadzaniu treści w witrynach lub aplikacjach. Aspose.Slides dla C++ umożliwia przekształcenie plików PPTX, PPT i ODP w wysokiej jakości obrazy JPEG. Ten przewodnik wyjaśnia różne metody konwersji.

Dzięki tym funkcjom łatwo zaimplementować własną przeglądarkę prezentacji i utworzyć miniaturę każdego slajdu. Może to być przydatne, jeśli chcesz chronić slajdy przed kopiowaniem lub pokazać prezentację w trybie tylko do odczytu. Aspose.Slides pozwala konwertować całą prezentację lub wybrany slajd do formatów obrazu.

## **Konwertowanie slajdów prezentacji na obrazy JPG**

Oto kroki, aby skonwertować plik PPT, PPTX lub ODP do JPG:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Pobierz obiekt slajdu typu [ISlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/) z kolekcji slajdów prezentacji.
3. Utwórz obraz slajdu przy użyciu metody [ISlide.GetImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/getimage/).
4. Wywołaj metodę [IImage.Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/save/) na obiekcie obrazu. Przekaż nazwę pliku wyjściowego i format obrazu jako argumenty.

{{% alert color="primary" %}} 

**Uwaga:** Konwersja PPT, PPTX lub ODP do JPG różni się od konwersji do innych formatów w API Aspose.Slides for C++. Dla innych formatów zazwyczaj używasz metody [IPresentation.Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/save/). Jednak dla konwersji JPG musisz użyć metody [IImage.Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/save/).

{{% /alert %}} 

```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Utwórz obraz slajdu w określonej skali.
    auto image = slide->GetImage(scaleX, scaleY);

    // Zapisz obraz na dysku w formacie JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Konwertowanie slajdów do JPG z niestandardowymi wymiarami**

Aby zmienić wymiary wygenerowanych obrazów JPG, możesz ustawić rozmiar obrazu, przekazując go do metody [ISlide.GetImage(Size)](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). Umożliwia to tworzenie obrazów o określonej szerokości i wysokości, zapewniając, że wynik spełnia Twoje wymagania co do rozdzielczości i proporcji. Ta elastyczność jest szczególnie przydatna przy generowaniu obrazów dla aplikacji internetowych, raportów lub dokumentacji, gdzie wymagana jest precyzyjna wielkość obrazu.

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Utwórz obraz slajdu o określonym rozmiarze.
    auto image = slide->GetImage(imageSize);

    // Zapisz obraz na dysku w formacie JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Renderowanie komentarzy przy zapisywaniu slajdów jako obrazy**

Aspose.Slides dla C++ udostępnia funkcję, która pozwala renderować komentarze na slajdach prezentacji podczas konwersji ich do obrazów JPG. Funkcjonalność ta jest szczególnie przydatna do zachowania adnotacji, uwag lub dyskusji dodanych przez współpracowników w prezentacjach PowerPoint. Włączając tę opcję, zapewniasz widoczność komentarzy w wygenerowanych obrazach, co ułatwia przeglądanie i udostępnianie uwag bez konieczności otwierania oryginalnego pliku prezentacji.

Załóżmy, że mamy plik prezentacji „sample.pptx” z slajdem zawierającym komentarze:

![Slajd z komentarzami](slide_with_comments.png)

Poniższy kod C++ konwertuje slajd na obraz JPG, zachowując komentarze:

```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Ustaw opcje komentarzy slajdu.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Konwertuj pierwszy slajd na obraz.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

Wynik:

![Obraz JPG z komentarzami](image_with_comments.png)

## **Zobacz także**

Zobacz inne opcje konwertowania PPT, PPTX lub ODP na obrazy, takie jak:

- [Konwertowanie PowerPoint do GIF](/slides/pl/cpp/convert-powerpoint-to-animated-gif/)
- [Konwertowanie PowerPoint do PNG](/slides/pl/cpp/convert-powerpoint-to-png/)
- [Konwertowanie PowerPoint do TIFF](/slides/pl/cpp/convert-powerpoint-to-tiff/)
- [Konwertowanie PowerPoint do SVG](/slides/pl/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Aby zobaczyć, jak Aspose.Slides konwertuje PowerPoint na obrazy JPG, wypróbuj te darmowe konwertery online: PowerPoint [PPTX do JPG](https://products.aspose.app/slides/pl/conversion/pptx-to-jpg) i [PPT do JPG](https://products.aspose.app/slides/pl/conversion/ppt-to-jpg). 

{{% /alert %}}

![Darmowy konwerter online PPTX do JPG](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose udostępnia [DARMOWĄ aplikację internetową Collage](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz łączyć obrazy [JPG do JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG do PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid) i tak dalej. 

Stosując te same zasady opisane w tym artykule, możesz konwertować obrazy z jednego formatu na inny. Więcej informacji znajdziesz na tych stronach: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/cpp/conversion/image-to-jpg/); konwertuj [JPG na obraz](https://products.aspose.com/slides/pl/cpp/conversion/jpg-to-image/); konwertuj [JPG na PNG](https://products.aspose.com/slides/pl/cpp/conversion/jpg-to-png/), konwertuj [PNG na JPG](https://products.aspose.com/slides/pl/cpp/conversion/png-to-jpg/); konwertuj [PNG na SVG](https://products.aspose.com/slides/pl/cpp/conversion/png-to-svg/), konwertuj [SVG na PNG](https://products.aspose.com/slides/pl/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Czy ta metoda obsługuje konwersję wsadową?**

Tak, Aspose.Slides umożliwia konwersję wsadową wielu slajdów do JPG w jednej operacji.

**Czy konwersja obsługuje SmartArt, wykresy i inne złożone obiekty?**

Tak, Aspose.Slides renderuje całą zawartość, w tym SmartArt, wykresy, tabele, kształty i inne elementy. Jednak dokładność renderowania może nieco się różnić w porównaniu z PowerPoint, szczególnie przy użyciu niestandardowych lub brakujących czcionek.

**Czy istnieją ograniczenia dotyczące liczby slajdów, które można przetworzyć?**

Aspose.Slides nie narzuca sztywnych limitów liczby slajdów, które można przetworzyć. Jednak przy dużych prezentacjach lub obrazach wysokiej rozdzielczości możesz napotkać błędy braku pamięci.