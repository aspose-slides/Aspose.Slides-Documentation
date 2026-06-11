---
title: Wielowątkowość w Aspose.Slides dla Pythona
linktitle: Wielowątkowość
type: docs
weight: 200
url: /pl/python-net/multithreading/
keywords:
- wielowątkowość
- wiele wątków
- praca równoległa
- konwertowanie slajdów
- slajdy na obrazy
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Wielowątkowość w Aspose.Slides dla Pythona działająca na platformie .NET przyspiesza przetwarzanie plików PowerPoint i OpenDocument. Odkryj najlepsze praktyki efektywnych przepływów pracy z prezentacjami."
---
## **Wprowadzenie**

Choć równoległa praca z prezentacjami jest możliwa (poza parsowaniem/ładowaniem/klonowaniem) i zazwyczaj wszystko działa poprawnie (większość przypadków), istnieje niewielka szansa, że otrzymasz nieprawidłowe wyniki przy używaniu biblioteki w wielu wątkach.

Zdecydowanie zalecamy, aby **nie** używać pojedynczej instancji [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) w środowisku wielowątkowym, ponieważ może to prowadzić do nieprzewidywalnych błędów lub awarii, które nie są łatwe do wykrycia.

Nie jest **bezpieczne** ładowanie, zapisywanie i/lub klonowanie instancji klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) w wielu wątkach. Takie operacje **nie** są obsługiwane. Jeśli musisz wykonać takie zadania, musisz równolegle uruchamiać operacje w kilku procesach jednowątkowych — każdy z tych procesów powinien używać własnej instancji prezentacji.

## **Konwertowanie slajdów prezentacji na obrazy równolegle**

Załóżmy, że chcemy równolegle konwertować wszystkie slajdy z prezentacji PowerPoint na obrazy PNG. Ponieważ niebezpieczne jest używanie jednej instancji `Presentation` w wielu wątkach, dzielimy slajdy prezentacji na osobne prezentacje i konwertujemy je równolegle, używając każdej prezentacji w osobnym wątku. Poniższy przykład kodu pokazuje, jak to zrobić.

```py
input_file_path = "sample.pptx"
output_file_path_template = "slide_{0}.png"
image_scale = 2

presentation = Presentation(input_file_path)

slide_count = len(presentation.slides)
slide_size = presentation.slide_size.size

conversion_tasks = []


def convert_slide(slide_index):
    # Wyodrębnij slajd i do osobnej prezentacji.
    with Presentation() as slide_presentation:
        slide_presentation.slide_size.set_size(slide_size.width, slide_size.height, SlideSizeScaleType.DO_NOT_SCALE)
        slide_presentation.slides.remove_at(0)
        slide_presentation.slides.add_clone(presentation.slides[slide_index])

        slide_number = slide_index + 1
        slide = slide_presentation.slides[0]

        # Konwertuj slajd na obraz.
        with slide.get_image(image_scale, image_scale) as image:
            image_file_path = output_file_path_template.format(slide_number)
            image.save(image_file_path, ImageFormat.PNG)


with ThreadPoolExecutor() as thread_executor:
    for index in range(slide_count):
        conversion_tasks.append(thread_executor.submit(convert_slide, index))

# Poczekaj, aż wszystkie zadania zostaną zakończone.
for task in conversion_tasks:
    task.result()

del presentation
```

## **FAQ**

**Czy muszę wywoływać konfigurację licencji w każdym wątku?**

Nie. Wystarczy zrobić to raz na proces/domenę aplikacji przed uruchomieniem wątków. Jeśli [license setup](/slides/pl/python-net/licensing/) może być wywoływane jednocześnie (np. podczas leniwej inicjalizacji), zsynchronizuj to wywołanie, ponieważ metoda konfiguracji licencji nie jest wątkowo‑bezpieczna.

**Czy mogę przekazywać obiekty `Presentation` lub `Slide` między wątkami?**

Przekazywanie „żywych” obiektów prezentacji między wątkami nie jest zalecane: używaj niezależnych instancji na każdy wątek lub wstępnie twórz osobne kontenery prezentacji/slajdów dla każdego wątku. Takie podejście jest zgodne z ogólną rekomendacją, aby nie współdzielić jednej instancji prezentacji pomiędzy wątkami.

**Czy bezpieczne jest równoległe eksportowanie do różnych formatów (PDF, HTML, obrazy), o ile każdy wątek ma własną instancję `Presentation`?**

Tak. Przy niezależnych instancjach i oddzielnych ścieżkach wyjściowych takie zadania zazwyczaj działają poprawnie równolegle; unikaj współdzielenia obiektów prezentacji oraz wspólnych strumieni I/O.

**Co powinienem zrobić z globalnymi ustawieniami czcionek (foldery, zamienniki) w środowisku wielowątkowym?**

Zainicjuj wszystkie globalne ustawienia czcionek przed uruchomieniem wątków i nie zmieniaj ich podczas pracy równoległej. Eliminujesz w ten sposób wyścigi przy dostępie do współdzielonych zasobów czcionek.