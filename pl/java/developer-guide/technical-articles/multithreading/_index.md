---
title: Wielowątkowość w Aspose.Slides dla Javy
linktitle: Wielowątkowość
type: docs
weight: 310
url: /pl/java/multithreading/
keywords:
- wielowątkowość
- wiele wątków
- równoległa praca
- konwertowanie slajdów
- slajdy na obrazy
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Wielowątkowość w Aspose.Slides dla Javy przyspiesza przetwarzanie PowerPoint i OpenDocument. Odkryj najlepsze praktyki dla efektywnych przepływów pracy z prezentacjami."
---
## **Wprowadzenie**

Choć równoległa praca z prezentacjami jest możliwa (oprócz analizowania/ładowania/klonowania) i zazwyczaj wszystko działa prawidłowo, istnieje niewielka szansa, że przy użyciu biblioteki w wielu wątkach otrzymasz nieprawidłowe wyniki.

Zdecydowanie zalecamy, aby **nie** używać jednej instancji [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) w środowisku wielowątkowym, ponieważ może to prowadzić do nieprzewidywalnych błędów lub awarii, które trudno wykryć. 

Ładowanie, zapisywanie i/lub klonowanie instancji klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation) w wielu wątkach **nie** jest bezpieczne. Takie operacje **nie** są obsługiwane. Jeśli musisz wykonać takie zadania, musisz równolegle uruchamiać operacje w kilku jedno‑wątkowych procesach – każdy z nich powinien używać własnej instancji prezentacji. 

## **Konwertowanie slajdów prezentacji na obrazy równolegle**

Załóżmy, że chcemy równolegle przekonwertować wszystkie slajdy z prezentacji PowerPoint na obrazy PNG. Ponieważ użycie jednej instancji `Presentation` w wielu wątkach jest niebezpieczne, dzielimy slajdy prezentacji na osobne prezentacje i konwertujemy je na obrazy równolegle, używając każdej prezentacji w osobnym wątku. Poniższy przykład kodu pokazuje, jak to zrobić.

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Wyodrębnij slajd i do osobnej prezentacji.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // Skonwertuj slajd na obraz w osobnym zadaniu.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// Poczekaj, aż wszystkie zadania zakończą się.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **FAQ**

**Czy muszę wywoływać konfigurację licencji w każdym wątku?**

Nie. Wystarczy zrobić to raz na proces/domenę aplikacji przed uruchomieniem wątków. Jeśli [konfiguracja licencji](/slides/pl/java/licensing/) może być wywoływane jednocześnie (np. podczas leniwej inicjalizacji), należy zsynchronizować to wywołanie, ponieważ sama metoda konfiguracji licencji nie jest wątkowo‑bezpieczna.

**Czy mogę przekazywać obiekty `Presentation` lub `Slide` między wątkami?**

Przekazywanie „żywych” obiektów prezentacji między wątkami nie jest zalecane: używaj niezależnych instancji na wątek lub wstępnie twórz oddzielne prezentacje/kontenery slajdów dla każdego wątku. Takie podejście wynika z ogólnej rekomendacji, aby nie udostępniać jednej instancji prezentacji w wielu wątkach.

**Czy bezpieczne jest równoległe eksportowanie do różnych formatów (PDF, HTML, obrazy), pod warunkiem że każdy wątek posiada własną instancję `Presentation`?**

Tak. Przy użyciu niezależnych instancji i oddzielnych ścieżek wyjściowych takie zadania zazwyczaj działają równolegle poprawnie; unikaj współdzielenia obiektów prezentacji oraz współdzielonych strumieni I/O.

**Co powinienem zrobić z globalnymi ustawieniami czcionek (foldery, zamienniki) w środowisku wielowątkowym?**

Zainicjalizuj wszystkie globalne [ustawienia czcionek](/slides/pl/java/powerpoint-fonts/) przed uruchomieniem wątków i nie zmieniaj ich podczas równoległej pracy. Dzięki temu unikniesz wyścigów przy dostępie do współdzielonych zasobów czcionek.