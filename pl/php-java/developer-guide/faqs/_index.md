---
title: FAQ
type: docs
weight: 340
url: /pl/php-java/faqs/
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
- PHP
- Aspose.Slides
description: "Uzyskaj odpowiedzi na najczęściej zadawane pytania dotyczące Aspose.Slides for PHP via Java, obejmujące obsługę PowerPoint i OpenDocument, wskazówki instalacji, licencjonowanie oraz rozwiązywanie problemów."
---
## **Przegląd**

To FAQ zawiera odpowiedzi na najczęściej zadawane pytania dotyczące Aspose.Slides. Obejmuje obsługiwane formaty plików, obsługę wyjątków przy pracy z dużymi prezentacjami, zmianę rozmiarów slajdów, podgląd slajdów, pobieranie tekstu z prezentacji, formatowanie obramowań tabel, umieszczanie obrazów oraz rozwiązywanie problemów związanych z czcionkami przy konwertowaniu prezentacji na PDF lub obrazy.

## **Obsługiwane formaty plików**

**Q:** Jakie formaty plików obsługuje Aspose.Slides for PHP via Java?

**A**: Aspose.Slides for PHP via Java obsługuje formaty plików opisane w [Obsługiwane formaty plików](/slides/pl/php-java/supported-file-formats/).

## **Wyjątki**

**Q:** Podczas ładowania dużego pliku PPT z obrazami otrzymuję wyjątek out of memory. Czy Aspose.Slides ma ograniczenie rozmiaru pliku?

**A**: Nie ma konkretnej formuły do obliczania rozmiaru prezentacji obsługiwanego przez Aspose.Slides. Powinna być dostępna wystarczająca ilość miejsca, aby pomieścić całą strukturę prezentacji i obrazy w pamięci. Zazwyczaj obrazy w pamięci zajmują więcej miejsca niż na dysku twardym, szczególnie gdy obrazy mają dodatkowe efekty.

Generalnie Aspose.Slides for PHP via Java może bez problemu obsługiwać pliki prezentacji o rozmiarze około 300 MB na serwerze z 4 GB RAM.

## **Praca ze slajdami**

**Q:** Czy mogę zmienić rozmiar slajdów w prezentacji?

**A**: Możesz użyć metody `getSlideSize` udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation/), aby określić rozmiar slajdów w prezentacji.

**Q:** Czy istnieje sposób na definiowanie slajdów o różnych rozmiarach w jednej prezentacji?

**A**: Ponieważ rozmiar slajdów jest definiowany na poziomie prezentacji w dokumentach Microsoft PowerPoint, nie ma możliwości wykonania tego.

**Q:** Czy Aspose.Slides for PHP via Java obsługuje podgląd slajdu przed zapisaniem?

**A**: Możesz renderować slajdy prezentacji do obrazów i używać tych obrazów do podglądu slajdów.

## **Praca z tekstem**

**Q:** Czy możliwe jest pobranie całego tekstu z prezentacji?

**A**: Aspose.Slides for PHP via Java udostępnia klasę [SlideUtil](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slideutil/), która zawiera różne metody umożliwiające pobranie całego tekstu z prezentacji.

**Q:** Dlaczego rozmiary akapitów różnią się w systemach operacyjnych Windows i Linux?

**A**: Obliczanie rozmiarów akapitów opiera się na obliczaniu wielkości tekstu reprezentującego dany akapit. Wielkość tekstu jest obliczana na podstawie metryk czcionki określonej w prezentacji PowerPoint. Jeśli określona czcionka jest nieobecna, zostaje zastąpiona najbliższą czcionką, lecz ta czcionka ma metryki różne od oryginalnych. W rezultacie, obliczanie rozmiarów akapitów w różnych systemach prowadzi do różnych wyników w zależności od zestawu zainstalowanych czcionek. Aby uzyskać taki sam rezultat na różnych systemach operacyjnych, należy zainstalować te same czcionki na systemach lub załadować je w czasie wykonywania jako [czcionki zewnętrzne](/slides/pl/php-java/custom-font/).

## **Formatowanie i obrazy**

**Q:** Jak mogę ustawić kolor obramowania tabeli?

**A**: Możesz zmienić kolor wszystkich obramowań tabeli lub tylko obramowania wokół całej tabeli. Aby zmienić wszystkie obramowania, użyj metody `getCellFormat` z klasy [Cell](https://reference.aspose.com/slides/pl/php-java/aspose.slides/cell/). Aby zmienić obramowanie całej tabeli, należy przeiterować komórki i zmienić kolor zewnętrznych obramowań.

**Q:** Jaką jednostkę miary Aspose.Slides for PHP via Java używa do rozmieszczania obrazów?

**A**: Współrzędne i rozmiary wszystkich kształtów na slajdach mierzone są w punktach (72 dpi).

## **Praca z czcionkami**

**Q:** Podczas konwertowania PPT na PDF lub obrazy, dlaczego czcionki w dokumentach wynikowych są inne?

**A**: Ten problem może wskazywać, że czcionki użyte w prezentacji są nieobecne w systemie operacyjnym, na którym uruchomiono kod. Należy zainstalować czcionki w systemie operacyjnym lub załadować je jako czcionki zewnętrzne przy użyciu klasy [FontsLoader](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontsloader/), jak pokazano poniżej:
```php
$folders = ["path_to_a_folder_with_fonts"];
FontsLoader::loadExternalFonts($folders);
```