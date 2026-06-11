---
title: Wielowątkowość w Aspose.Slides dla Node.js poprzez Java
linktitle: Wielowątkowość
type: docs
weight: 310
url: /pl/nodejs-java/multithreading/
keywords:
- wielowątkowość
- wiele wątków
- praca równoległa
- konwersja slajdów
- slajdy na obrazy
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Wielowątkowość w Aspose.Slides dla Node.js poprzez Java przyspiesza przetwarzanie PowerPoint i OpenDocument. Odkryj najlepsze praktyki efektywnych przepływów pracy z prezentacjami."
---
## **Wprowadzenie**

Podczas gdy równoległa praca z prezentacjami jest możliwa (poza parsowaniem/ładowaniem/klonowaniem) i zazwyczaj wszystko działa poprawnie (większość przypadków), istnieje niewielka szansa, że otrzymasz nieprawidłowe wyniki przy używaniu biblioteki w wielu wątkach.

Zdecydowanie zalecamy, aby **nie** używać pojedynczej instancji [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) w środowisku wielowątkowym, ponieważ może to prowadzić do nieprzewidywalnych błędów lub awarii, które trudno wykryć.

Nie jest **bezpieczne** ładowanie, zapisywanie i/lub klonowanie instancji klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) w wielu wątkach. Takie operacje **nie** są wspierane. Jeśli musisz wykonać takie zadania, musisz równolegle uruchamiać operacje przy użyciu kilku procesów jednowątkowych — i każdy z tych procesów powinien używać własnej instancji prezentacji.

## **Konwersja slajdów prezentacji na obrazy równolegle**

Załóżmy, że chcemy przekonwertować wszystkie slajdy z prezentacji PowerPoint na obrazy PNG równolegle. Ponieważ użycie jednej instancji `Presentation` w wielu wątkach jest niebezpieczne, dzielimy slajdy prezentacji na osobne prezentacje i konwertujemy slajdy na obrazy równolegle, używając każdej prezentacji w osobnym wątku. Poniższy przykład kodu pokazuje, jak to zrobić.

```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // Wyodrębnij slajd i do osobnej prezentacji.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // Poczekaj na zakończenie wszystkich zadań.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```

## **Najczęściej zadawane pytania**

**Czy muszę wywoływać konfigurację licencji w każdym wątku?**

Nie. Wystarczy zrobić to raz na proces/domenę aplikacji przed uruchomieniem wątków. Jeśli [license setup](/slides/pl/nodejs-java/licensing/) może być wywoływany równocześnie (na przykład podczas leniwej inicjalizacji), należy zsynchronizować to wywołanie, ponieważ metoda konfiguracji licencji nie jest bezpieczna wątkowo.

**Czy mogę przekazywać obiekty `Presentation` lub `Slide` między wątkami?**

Przekazywanie "żywych" obiektów prezentacji między wątkami nie jest zalecane: używaj niezależnych instancji na wątek lub wstępnie utwórz osobne prezentacje/kontenery slajdów dla każdego wątku. Takie podejście jest zgodne z ogólną rekomendacją, aby nie udostępniać jednej instancji prezentacji w wielu wątkach.

**Czy bezpieczne jest równoległe eksportowanie do różnych formatów (PDF, HTML, obrazy), pod warunkiem że każdy wątek ma własną instancję `Presentation`?**

Tak. Przy użyciu niezależnych instancji i osobnych ścieżek wyjściowych takie zadania zazwyczaj równolegle działają prawidłowo; unikaj udostępniania obiektów prezentacji oraz wspólnych strumieni I/O.

**Co powinienem zrobić z globalnymi ustawieniami czcionek (katalogi, zamienniki) w środowisku wielowątkowym?**

Zainicjalizuj wszystkie globalne ustawienia czcionek przed uruchomieniem wątków i nie zmieniaj ich podczas pracy równoległej. To eliminuje wyścigi przy dostępie do współdzielonych zasobów czcionek.