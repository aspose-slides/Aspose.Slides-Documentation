---
title: Wielowątkowość w Aspose.Slides dla .NET
linktitle: Wielowątkowość
type: docs
weight: 310
url: /pl/net/multithreading/
keywords:
- wielowątkowość
- wiele wątków
- praca równoległa
- konwertowanie slajdów
- slajdy na obrazy
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Wielowątkowość w Aspose.Slides dla .NET przyspiesza przetwarzanie plików PowerPoint i OpenDocument. Odkryj najlepsze praktyki dla efektywnych przepływów pracy z prezentacjami."
---
## **Wprowadzenie**

Podczas gdy równoległa praca z prezentacjami jest możliwa (oprócz parsowania/ładowania/klonowania) i zazwyczaj wszystko działa prawidłowo (najczęściej), istnieje małe prawdopodobieństwo, że otrzymasz niepoprawne wyniki przy używaniu biblioteki w wielu wątkach.

Zalecamy zdecydowanie, aby **nie** używać pojedynczej instancji [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) w środowisku wielowątkowym, ponieważ może to prowadzić do nieprzewidywalnych błędów lub awarii, które nie są łatwe do wykrycia.

Nie jest **bezpieczne** ładować, zapisywać i/lub klonować instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) w wielu wątkach. Takie operacje nie są **obsługiwane**. Jeśli musisz wykonać takie zadania, musisz równolegle przetwarzać je, używając kilku jednowątkowych procesów — a każdy z tych procesów powinien używać własnej instancji prezentacji.

## **Konwertowanie slajdów prezentacji na obrazy równolegle**

Załóżmy, że chcemy równolegle przekonwertować wszystkie slajdy z prezentacji PowerPoint na obrazy PNG. Ponieważ użycie jednej instancji `Presentation` w wielu wątkach jest niebezpieczne, dzielimy slajdy prezentacji na oddzielne prezentacje i konwertujemy slajdy na obrazy równolegle, używając każdej prezentacji w osobnym wątku. Poniższy przykład kodu pokazuje, jak to zrobić.

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // Wyodrębnij slajd i do osobnej prezentacji.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Konwertuj slajd na obraz w osobnym zadaniu.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```

## **FAQ**

**Czy muszę wywoływać konfigurację licencji w każdym wątku?**

Nie. Wystarczy zrobić to raz na proces/domenę aplikacji przed uruchomieniem wątków. Jeśli [konfiguracja licencji](/slides/pl/net/licensing/) może być wywoływane jednocześnie (na przykład podczas leniwej inicjalizacji), należy zsynchronizować to wywołanie, ponieważ metoda konfiguracji licencji nie jest bezpieczna wątkowo.

**Czy mogę przekazywać obiekty `Presentation` lub `Slide` między wątkami?**

Przekazywanie „żywych” obiektów prezentacji między wątkami nie jest zalecane: używaj niezależnych instancji na każdy wątek lub wstępnie utwórz oddzielne prezentacje/kontenery slajdów dla każdego wątku. Takie podejście jest zgodne z ogólną rekomendacją, aby nie udostępniać jednej instancji prezentacji między wątkami.

**Czy bezpieczne jest równoległe eksportowanie do różnych formatów (PDF, HTML, obrazy), pod warunkiem że każdy wątek ma własną instancję `Presentation`?**

Tak. Przy niezależnych instancjach i osobnych ścieżkach wyjściowych takie zadania zazwyczaj równolegle działają poprawnie; unikaj współdzielenia obiektów prezentacji oraz wspólnych strumieni I/O.

**Co zrobić z globalnymi ustawieniami czcionek (foldery, zamienniki) w środowisku wielowątkowym?**

Zainicjuj wszystkie globalne ustawienia czcionek przed uruchomieniem wątków i nie zmieniaj ich podczas równoległej pracy. To eliminuje wyścigi przy dostępie do współdzielonych zasobów czcionek.