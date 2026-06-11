---
title: Najczęściej zadawane pytania
type: docs
weight: 340
url: /pl/python-net/faq/
keywords:
- FAQ
- format prezentacji
- błąd braku pamięci
- rozmiar slajdu
- wyodrębnianie tekstu
- pobieranie tekstu
- rozmiar akapitu
- formatowanie tabel
- czcionka
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Uzyskaj odpowiedzi na najczęściej zadawane pytania dotyczące Aspose.Slides for Python via .NET, obejmujące obsługę PowerPoint i OpenDocument, wskazówki instalacji, licencjonowanie oraz rozwiązywanie problemów."
---
## **Przegląd**

To FAQ zawiera odpowiedzi na najczęstsze pytania dotyczące Aspose.Slides. Obejmuje obsługiwane formaty plików, obsługę wyjątków przy pracy z dużymi prezentacjami, zmianę rozmiarów slajdów, podgląd slajdów, pobieranie tekstu z prezentacji, formatowanie obramowań tabel, umieszczanie obrazów oraz rozwiązywanie problemów związanych z czcionkami przy konwersji prezentacji do PDF lub obrazów.

## **Obsługiwane formaty plików**

**Q:** Jakie formaty plików obsługuje Aspose.Slides for Python via .NET?

**A:** Aspose.Slides for Python via .NET obsługuje formaty plików opisane w [Obsługiwane formaty plików](/slides/pl/python-net/supported-file-formats/).

## **Wyjątki**

**Q:** Podczas ładowania dużego pliku PPT z obrazami otrzymuję wyjątek „out of memory”. Czy Aspose.Slides ma ograniczenie odnośnie rozmiaru pliku?

**A:** Nie istnieje konkretna formuła obliczająca rozmiar prezentacji obsługiwany przez Aspose.Slides. Powinna być dostępna wystarczająca ilość pamięci, aby pomieścić całą strukturę prezentacji oraz obrazy w pamięci. Zwykle obrazy w pamięci zajmują więcej miejsca niż na dysku twardym, szczególnie gdy mają dodatkowe efekty.

Ogólnie rzecz biorąc, Aspose.Slides for Python via .NET może bez problemu obsługiwać pliki prezentacji o wielkości około 300 MB na serwerze z 4 GB RAM.

## **Praca ze slajdami**

**Q:** Czy mogę zmienić rozmiar slajdów w prezentacji?

**A:** Możesz użyć właściwości `slide_size` udostępnianej przez klasę [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) aby określić rozmiar slajdów w prezentacji.

**Q:** Czy istnieje sposób, aby zdefiniować slajdy o różnych rozmiarach w jednej prezentacji?

**A:** Ponieważ rozmiar slajdów jest definiowany na poziomie całej prezentacji w dokumentach Microsoft PowerPoint, nie ma możliwości zdefiniowania slajdów o różnych rozmiarach.

**Q:** Czy Aspose.Slides for Python via .NET obsługuje podgląd slajdu przed zapisaniem?

**A:** Możesz renderować slajdy prezentacji do obrazów i używać tych obrazów do podglądu slajdów.

## **Praca z tekstem**

**Q:** Czy istnieje możliwość pobrania całego tekstu z prezentacji?

**A:** Aspose.Slides for Python via .NET udostępnia klasę [SlideUtil](https://reference.aspose.com/slides/pl/python-net/aspose.slides.util/slideutil/) w przestrzeni nazw `aspose.slides.util`, która oferuje różne metody pobierania całego tekstu z prezentacji.

**Q:** Dlaczego rozmiary akapitów różnią się w systemach Windows i Linux?

**A:** Obliczanie rozmiarów akapitów opiera się na wyliczaniu wielkości tekstu reprezentującego dany akapit. Wielkość tekstu jest obliczana na podstawie metryk czcionki określonej w prezentacji PowerPoint. Jeśli określona czcionka jest nieobecna, zostaje zastąpiona najbliższą czcionką, lecz jej metryki różnią się od oryginalnych. W rezultacie obliczenia rozmiarów akapitów w różnych systemach dają odrębne wyniki w zależności od zestawu zainstalowanych czcionek. Aby uzyskać takie same wyniki na różnych systemach operacyjnych, należy zainstalować te same czcionki na wszystkich systemach lub ładować je w czasie działania jako [czcionki zewnętrzne](/slides/pl/python-net/custom-font/).

## **Formatowanie i obrazy**

**Q:** Jak mogę ustawić kolor obramowania tabeli?

**A:** Możesz zmienić kolor wszystkich obramowań tabeli lub jedynie obramowania wokół całej tabeli. Aby zmienić wszystkie obramowania, użyj właściwości `cell_format` z klasy [Cell](https://reference.aspose.com/slides/pl/python-net/aspose.slides/cell/). Aby zmienić obramowanie całej tabeli, należy przeiterować komórki i zmienić kolor obramowań zewnętrznych.

**Q:** Jaką jednostkę miary używa Aspose.Slides for Python via .NET do umieszczania obrazów?

**A:** Współrzędne i rozmiary wszystkich kształtów na slajdach są mierzone w punktach (72 dpi).

## **Praca z czcionkami**

**Q:** Podczas konwersji PPT do PDF lub obrazów czcionki w dokumentach wyjściowych są inne. Dlaczego?

**A:** Ten problem może wskazywać, że czcionki użyte w prezentacji nie znajdują się w systemie operacyjnym, na którym uruchomiono kod. Należy zainstalować czcionki w systemie operacyjnym lub załadować je jako czcionki zewnętrzne przy użyciu klasy [FontsLoader](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontsloader/) jak pokazano poniżej:
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```