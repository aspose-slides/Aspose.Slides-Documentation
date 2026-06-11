---
title: Wielowątkowość w Aspose.Slides dla PHP poprzez Java
linktitle: Wielowątkowość
type: docs
weight: 310
url: /pl/php-java/multithreading/
keywords:
- wielowątkowość
- wiele wątków
- równoległa praca
- konwertowanie slajdów
- slajdy na obrazy
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Wielowątkowość w Aspose.Slides dla PHP poprzez Java zwiększa wydajność przetwarzania PowerPoint i OpenDocument. Odkryj najlepsze praktyki efektywnych przepływów pracy z prezentacjami."
---
## **Wstęp**

Choć równoległa praca z prezentacjami jest możliwa (oprócz parsowania/ładowania/klonowania) i zazwyczaj wszystko działa prawidłowo (większość czasu), istnieje niewielka szansa, że otrzymasz nieprawidłowe wyniki przy użyciu biblioteki w wielu wątkach.

Zdecydowanie zalecamy, aby **nie** używać pojedynczej instancji [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) w środowisku wielowątkowym, ponieważ może to prowadzić do nieprzewidywalnych błędów lub awarii, które nie są łatwe do wykrycia.

Nie jest **bezpieczne** ładowanie, zapisywanie i/lub klonowanie instancji klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) w wielu wątkach. Takie operacje nie są **obsługiwane**. Jeśli musisz wykonać takie zadania, musisz równolegle przetwarzać je przy użyciu kilku jednowątkowych procesów — każdy z tych procesów powinien używać własnej instancji prezentacji.

Nie gwarantujemy wielowątkowości w PHP przy użyciu rozszerzeń. Jeśli je używasz, rób to na własne ryzyko.

## **FAQ**

**Czy muszę wywoływać konfigurację licencji w każdym wątku?**

Nie. Wystarczy zrobić to raz na proces/domenę aplikacji przed uruchomieniem wątków. Jeśli [license setup](/slides/pl/php-java/licensing/) może być wywoływany jednocześnie (na przykład podczas leniwej inicjalizacji), zsynchronizuj to wywołanie, ponieważ metoda konfiguracji licencji nie jest wątkowo‑bezpieczna.

**Czy mogę przekazywać obiekty `Presentation` lub `Slide` między wątkami?**

Przekazywanie „żywych” obiektów prezentacji między wątkami nie jest zalecane: używaj niezależnych instancji na wątek lub wstępnie twórz osobne kontenery prezentacji/slajdów dla każdego wątku. Takie podejście jest zgodne z ogólną rekomendacją, aby nie udostępniać jednej instancji prezentacji w wielu wątkach.

**Czy bezpieczne jest równoległe eksportowanie do różnych formatów (PDF, HTML, obrazy), pod warunkiem że każdy wątek ma własną instancję `Presentation`?**

Tak. Przy użyciu niezależnych instancji i oddzielnych ścieżek wyjściowych takie zadania zazwyczaj równolegle działają poprawnie; unikaj współdzielenia obiektów prezentacji oraz współdzielonych strumieni I/O.

**Co zrobić z globalnymi ustawieniami czcionek (foldery, zamienniki) w środowisku wielowątkowym?**

Zainicjalizuj wszystkie globalne [font settings](/slides/pl/php-java/powerpoint-fonts/) przed uruchomieniem wątków i nie zmieniaj ich podczas pracy równoległej. To eliminuje wyścigi przy dostępie do współdzielonych zasobów czcionek.