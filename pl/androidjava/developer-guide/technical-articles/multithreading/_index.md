---
title: Wielowątkowość w Aspose.Slides dla Androida za pośrednictwem Java
linktitle: Wielowątkowość
type: docs
weight: 310
url: /pl/androidjava/multithreading/
keywords:
- wielowątkowość
- wiele wątków
- praca równoległa
- konwersja slajdów
- slajdy na obrazy
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Wielowątkowość w Aspose.Slides dla Androida za pośrednictwem Java przyspiesza przetwarzanie PowerPoint i OpenDocument. Odkryj najlepsze praktyki dla efektywnych przepływów pracy z prezentacjami."
---
## **Wprowadzenie**

Podczas gdy równoległa praca z prezentacjami jest możliwa (oprócz parsowania/ładowania/kopiowania) i zazwyczaj wszystko przebiega pomyślnie (w większości przypadków), istnieje małe prawdopodobieństwo otrzymania niepoprawnych wyników przy użyciu biblioteki w wielu wątkach.

Zalecamy stanowczo, aby **nie** używać pojedynczej instancji [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) w środowisku wielowątkowym, ponieważ może to prowadzić do nieprzewidywalnych błędów lub awarii, które nie są łatwe do wykrycia.

Nie jest **bezpieczne** ładowanie, zapisywanie i/lub klonowanie instancji klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation) w wielu wątkach. Takie operacje **nie** są wspierane. Jeśli musisz wykonać takie zadania, musisz równolegle wykonywać operacje przy użyciu kilku jednowątkowych procesów — i każdy z tych procesów powinien używać własnej instancji prezentacji.

## **Konwertowanie slajdów prezentacji na obrazy równolegle**

Załóżmy, że chcemy równolegle przekonwertować wszystkie slajdy z prezentacji PowerPoint na obrazy PNG. Ponieważ użycie jednej instancji `Presentation` w wielu wątkach jest niebezpieczne, dzielimy slajdy prezentacji na oddzielne prezentacje i konwertujemy slajdy na obrazy równolegle, używając każdej prezentacji w osobnym wątku. Poniższy przykład kodu pokazuje, jak to zrobić.

```java
String inputFilePath = "sample.pptx";
final String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
SizeF slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<Thread> threads = new ArrayList<Thread>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
	// Wyodrębnij slajd i do osobnej prezentacji.
	final Presentation slidePresentation = new Presentation();
	slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
	slidePresentation.getSlides().removeAt(0);
	slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

	// Konwertuj slajd na obraz w osobnym zadaniu.
	final int slideNumber = slideIndex + 1;
	threads.add(new Thread(new Runnable() {
		@Override
		public void run() {
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
		}
	}));
}

// Poczekaj, aż wszystkie zadania zostaną zakończone.
try {
	for (Thread t : threads) {
		t.join();
	}
} catch (InterruptedException e) {
	e.printStackTrace();
}

presentation.dispose();
```

## **FAQ**

**Czy muszę wywoływać konfigurację licencji w każdym wątku?**

Nie. Wystarczy zrobić to raz na proces/domenę aplikacji przed uruchomieniem wątków. Jeśli [license setup](/slides/pl/androidjava/licensing/) może być wywoływany jednocześnie (na przykład podczas leniwej inicjalizacji), należy zsynchronizować to wywołanie, ponieważ metoda konfiguracji licencji nie jest bezpieczna wątkowo.

**Czy mogę przekazywać obiekty `Presentation` lub `Slide` między wątkami?**

Przekazywanie „żywych” obiektów prezentacji między wątkami nie jest zalecane: używaj niezależnych instancji dla każdego wątku lub wstępnie utwórz osobne prezentacje/kontenery slajdów dla każdego wątku. Takie podejście jest zgodne z ogólną rekomendacją, aby nie udostępniać jednej instancji prezentacji pomiędzy wątkami.

**Czy bezpieczne jest równoległe eksportowanie do różnych formatów (PDF, HTML, obrazy), pod warunkiem że każdy wątek ma własną instancję `Presentation`?**

Tak. Przy użyciu niezależnych instancji i oddzielnych ścieżek wyjściowych takie zadania zwykle równolegle działają prawidłowo; unikaj współdzielonych obiektów prezentacji oraz współdzielonych strumieni I/O.

**Co powinienem zrobić z globalnymi ustawieniami czcionek (foldery, zamienniki) w środowisku wielowątkowym?**

Zainicjalizuj wszystkie globalne [font settings](/slides/pl/androidjava/powerpoint-fonts/) przed uruchomieniem wątków i nie zmieniaj ich podczas równoległej pracy. Eliminujesz w ten sposób wyścigi przy dostępie do współdzielonych zasobów czcionek.