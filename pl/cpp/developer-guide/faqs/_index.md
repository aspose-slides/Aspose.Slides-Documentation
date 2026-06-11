---
title: Najczęściej zadawane pytania
type: docs
weight: 340
url: /pl/cpp/faqs/
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
- C++
- Aspose.Slides
description: "Uzyskaj odpowiedzi na najczęściej zadawane pytania dotyczące Aspose.Slides dla C++, obejmujące wsparcie dla formatu PowerPoint i OpenDocument, instrukcje instalacji, informacje o licencjonowaniu oraz rozwiązywanie problemów."
---
## **Przegląd**

To FAQ zawiera odpowiedzi na najczęściej zadawane pytania dotyczące Aspose.Slides. Obejmuje obsługiwane formaty plików, obsługę wyjątków przy pracy z dużymi prezentacjami, zmianę rozmiarów slajdów, podgląd slajdów, pobieranie tekstu z prezentacji, formatowanie obramowań tabel, umieszczanie obrazów oraz rozwiązywanie problemów z czcionkami przy konwertowaniu prezentacji do formatu PDF lub obrazów.

## **Obsługiwane formaty plików**

**Q: Jakie formaty plików obsługuje Aspose.Slides dla C++?**

**A**: Aspose.Slides for C++ obsługuje formaty plików opisane w [Obsługiwane formaty plików](/slides/pl/cpp/supported-file-formats/).

## **Wyjątki**

**Q: Podczas ładowania dużego pliku PPT z obrazami otrzymuję wyjątek out of memory. Czy istnieje ograniczenie w Aspose.Slides dotyczące rozmiaru pliku?**

**A**: Nie istnieje konkretna formuła do obliczania rozmiaru prezentacji obsługiwanej przez Aspose.Slides. Powinna być dostępna wystarczająca ilość pamięci, aby pomieścić całą strukturę prezentacji oraz obrazy w pamięci. Zwykle obrazy w pamięci zajmują więcej miejsca niż na dysku twardym, szczególnie gdy mają dodatkowe efekty.

Ogólnie rzecz biorąc, Aspose.Slides for C++ może bez problemu obsługiwać pliki prezentacji o wielkości około 300 MB na serwerze z 4 GB RAM.

## **Praca ze slajdami**

**Q: Czy mogę zmienić rozmiar slajdów w prezentacji?**

**A**: Możesz użyć metody `get_SlideSize` udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) w celu określenia rozmiaru slajdów w prezentacji.

**Q: Czy istnieje możliwość definiowania slajdów o różnych rozmiarach w jednej prezentacji?**

**A**: Ponieważ rozmiar slajdów jest definiowany na poziomie prezentacji w dokumentach Microsoft PowerPoint, nie ma możliwości wykonania tego.

**Q: Czy Aspose.Slides for C++ wspiera podgląd slajdu przed zapisaniem?**

**A**: Możesz renderować slajdy prezentacji do obrazów i używać tych obrazów do podglądu slajdów.

## **Praca z tekstem**

**Q: Czy możliwe jest pobranie całego tekstu z prezentacji?**

**A**: Aspose.Slides for C++ udostępnia klasę [SlideUtil](https://reference.aspose.com/slides/pl/cpp/aspose.slides.util/slideutil/) w przestrzeni nazw `Aspose::Slides::Util`, która oferuje różne metody pobierania całego tekstu z prezentacji.

**Q: Dlaczego rozmiary akapitów różnią się w systemach operacyjnych Windows i Linux?**

**A**: Obliczanie rozmiarów akapitów opiera się na obliczeniu rozmiaru tekstu reprezentującego dany akapit. Obliczanie rozmiaru tekstu bazuje na metrykach czcionki określonej w prezentacji PowerPoint. Jeśli określona czcionka jest nieobecna, zostaje zastąpiona najbardziej podobną czcionką, jednak ta czcionka ma inne metryki niż oryginalna. W rezultacie obliczanie rozmiarów akapitów w różnych systemach daje różne wyniki w zależności od zestawu zainstalowanych czcionek. Aby uzyskać taki sam efekt na różnych systemach operacyjnych, należy zainstalować te same czcionki na wszystkich systemach lub załadować je w czasie wykonywania jako [czcionki zewnętrzne](/slides/pl/cpp/custom-font/).

## **Formatowanie i obrazy**

**Q: Jak mogę ustawić kolor obramowania tabeli?**

**A**: Możesz zmienić kolor wszystkich obramowań tabeli lub tylko obramowania wokół całej tabeli. Aby zmienić wszystkie obramowania, użyj metody `get_CellFormat` z interfejsu [ICell](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icell/). Aby zmienić obramowanie całej tabeli, należy przeiterować komórki i zmienić kolor zewnętrznych obramowań.

**Q: Jaką jednostką miary Aspose.Slides for C++ posługuje się przy umieszczaniu obrazów?**

**A**: Współrzędne i rozmiary wszystkich kształtów na slajdach są mierzone w punktach (72 dpi).

## **Praca z czcionkami**

**Q: Podczas konwertowania PPT do PDF lub obrazów, dlaczego czcionki różnią się w dokumentach wyjściowych?**

**A**: Ten problem może wskazywać, że czcionki użyte w prezentacji są nieobecne w systemie operacyjnym, na którym uruchomiono kod. Należy zainstalować czcionki w systemie operacyjnym lub załadować je jako czcionki zewnętrzne przy użyciu klasy [FontsLoader](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/) jak pokazano poniżej:
```cpp
auto folders = MakeObject<Array<String>>(1, "path_to_a_folder_with_fonts");
FontsLoader::LoadExternalFonts(folders);
```