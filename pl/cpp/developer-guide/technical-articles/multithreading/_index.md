---
title: Programowanie współbieżne w Aspose.Slides dla C++
linktitle: Programowanie współbieżne
type: docs
weight: 200
url: /pl/cpp/multithreading/
keywords:
- programowanie współbieżne
- wiele wątków
- równoległa praca
- konwersja slajdów
- slajdy na obrazy
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Programowanie współbieżne w Aspose.Slides dla C++ przyspiesza przetwarzanie PowerPoint i OpenDocument. Odkryj najlepsze praktyki efektywnego przepływu pracy z prezentacjami."
---
## **Wprowadzenie**

Chociaż równoległa praca z prezentacjami jest możliwa (poza parsowaniem/ładowaniem/kopiowaniem) i zazwyczaj wszystko działa poprawnie, istnieje małe ryzyko uzyskania nieprawidłowych wyników przy używaniu biblioteki w wielu wątkach.

Zdecydowanie zalecamy, aby **nie** używać jednej instancji [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) w środowisku wielowątkowym, ponieważ może to prowadzić do nieprzewidywalnych błędów lub awarii, które trudno wykryć. 

Ładowanie, zapisywanie i/lub klonowanie instancji klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation) w wielu wątkach nie jest bezpieczne. takie operacje nie są wspierane. Jeśli musisz wykonać takie zadania, musisz równolegle uruchomić je w kilku jednowątkowych procesach — każdy z tych procesów powinien używać własnej instancji prezentacji. 

## **Konwertowanie slajdów prezentacji na obrazy równolegle**

Załóżmy, że chcemy skonwertować wszystkie slajdy z prezentacji PowerPoint na obrazy PNG równolegle. Ponieważ użycie jednej instancji `Presentation` w wielu wątkach jest niebezpieczne, dzielimy slajdy prezentacji na oddzielne prezentacje i konwertujemy slajdy na obrazy równolegle, używając każdej prezentacji w osobnym wątku. Poniższy przykład kodu pokazuje, jak to zrobić.

```cpp
auto inputFilePath = u"sample.pptx";
auto outputFilePathTemplate = u"slide_{0}.png";
auto imageScale = 2;

auto presentation = MakeObject<Presentation>(inputFilePath);

auto slideCount = presentation->get_Slides()->get_Count();
auto slideSize = presentation->get_SlideSize()->get_Size();

std::vector<std::future<void>> conversionTasks;

for (auto slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Wyodrębnij slajd i do osobnej prezentacji.
    auto slidePresentation = MakeObject<Presentation>();
    slidePresentation->get_SlideSize()->SetSize(slideSize.get_Width(), slideSize.get_Height(), SlideSizeScaleType::DoNotScale);
    slidePresentation->get_Slides()->RemoveAt(0);
    slidePresentation->get_Slides()->AddClone(presentation->get_Slide(slideIndex));

    // Skonwertuj slajd na obraz w osobnym zadaniu.
    auto slideNumber = slideIndex + 1;
    conversionTasks.push_back(std::async(std::launch::async, [slidePresentation = std::move(slidePresentation), slideNumber, outputFilePathTemplate, imageScale]() {
        SharedPtr<IImage> image = nullptr;
        try {
            auto slide = slidePresentation->get_Slide(0);

            auto image = slide->GetImage(imageScale, imageScale);
            auto imageFilePath = String::Format(outputFilePathTemplate, slideNumber);
            image->Save(imageFilePath, ImageFormat::Png);
        }
        catch (Exception e) {
            if(image != nullptr) image->Dispose();
            slidePresentation->Dispose();
        }
    }));
}

// Poczekaj, aż wszystkie zadania się zakończą.
for (auto& task : conversionTasks) {
    task.get();
}

presentation->Dispose();
```

## **FAQ**

**Czy muszę wywoływać konfigurację licencji w każdym wątku?**

Nie. Wystarczy zrobić to raz na proces/domenę aplikacji przed uruchomieniem wątków. Jeśli [license setup](/slides/pl/cpp/licensing/) może być wywoływany jednocześnie (np. podczas leniwej inicjalizacji), należy zsynchronizować to wywołanie, ponieważ metoda konfiguracji licencji nie jest wątkowo‑bezpieczna.

**Czy mogę przekazywać obiekty `Presentation` lub `Slide` między wątkami?**

Przekazywanie „żywych” obiektów prezentacji między wątkami nie jest zalecane: używaj niezależnych instancji na każdy wątek lub wstępnie utwórz osobne kontenery prezentacji/slajdów dla każdego wątku. Takie podejście odpowiada ogólnej rekomendacji, aby nie udostępniać jednej instancji prezentacji między wątkami.

**Czy bezpieczne jest równoległe eksportowanie do różnych formatów (PDF, HTML, obrazy), pod warunkiem że każdy wątek ma własną instancję `Presentation`?**

Tak. Przy użyciu niezależnych instancji i osobnych ścieżek wyjściowych takie zadania zazwyczaj równolegle działają prawidłowo; unikaj współdzielenia obiektów prezentacji oraz współdzielonych strumieni I/O.

**Co powinienem zrobić z globalnymi ustawieniami czcionek (foldery, zamienniki) w środowisku wielowątkowym?**

Zainicjuj wszystkie globalne ustawienia czcionek przed uruchomieniem wątków i nie zmieniaj ich podczas równoległej pracy. Eliminuje to wyścigi przy dostępie do współdzielonych zasobów czcionek.