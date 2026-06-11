---
title: FAQ
type: docs
weight: 340
url: /pl/java/faqs/
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
- Java
- Aspose.Slides
description: "Uzyskaj odpowiedzi na najczęściej zadawane pytania dotyczące Aspose.Slides for Java, obejmujące obsługę PowerPoint i OpenDocument, wskazówki instalacji, licencjonowanie oraz rozwiązywanie problemów."
---
## **Przegląd**

To FAQ zawiera odpowiedzi na najczęściej zadawane pytania dotyczące Aspose.Slides. Obejmuje obsługiwane formaty plików, obsługę wyjątków podczas pracy z dużymi prezentacjami, zmianę rozmiaru slajdów, podgląd slajdów, pobieranie tekstu z prezentacji, formatowanie krawędzi tabel, umieszczanie obrazów oraz rozwiązywanie problemów związanych z czcionkami podczas konwertowania prezentacji do PDF lub obrazów.

## **Obsługiwane formaty plików**

**Q: Jakie formaty plików obsługuje Aspose.Slides for Java?**

**A**: Aspose.Slides for Java obsługuje formaty plików opisane w [Obsługiwane formaty plików](/slides/pl/java/supported-file-formats/).

## **Wyjątki**

**Q: Podczas ładowania dużego pliku PPT z obrazami otrzymuję wyjątek braku pamięci. Czy Aspose.Slides ma ograniczenia dotyczące rozmiaru pliku?**

**A**: Nie istnieje konkretna formuła do obliczania rozmiaru prezentacji obsługiwanej przez Aspose.Slides. Powinna być dostępna wystarczająca ilość pamięci, aby pomieścić całą strukturę prezentacji oraz obrazy w pamięci. Zazwyczaj obrazy w pamięci zajmują więcej miejsca niż na dysku twardym, szczególnie gdy posiadają dodatkowe efekty.

Ogólnie rzecz biorąc, Aspose.Slides for Java może bez problemu obsługiwać pliki prezentacji o rozmiarze około 300 MB na serwerze z 4 GB RAM.

## **Praca ze slajdami**

**Q: Czy mogę zmienić rozmiar slajdów w prezentacji?**

**A**: Możesz użyć metody `getSlideSize` udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/), aby określić rozmiar slajdów w prezentacji.

**Q: Czy istnieje możliwość zdefiniowania slajdów o różnych rozmiarach w jednej prezentacji?**

**A**: Ponieważ rozmiar slajdów jest definiowany na poziomie prezentacji w dokumentach Microsoft PowerPoint, nie ma takiej możliwości.

**Q: Czy Aspose.Slides for Java obsługuje podgląd slajdu przed zapisaniem?**

**A**: Możesz renderować slajdy prezentacji do obrazów i używać ich do podglądu slajdów.

## **Praca z tekstem**

**Q: Czy można pobrać cały tekst z prezentacji?**

**A**: Aspose.Slides for Java udostępnia klasę [SlideUtil](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slideutil/), która zawiera różne metody umożliwiające pobranie całego tekstu z prezentacji.

**Q: Dlaczego rozmiary akapitów różnią się w systemach operacyjnych Windows i Linux?**

**A**: Obliczanie rozmiarów akapitów opiera się na wyliczaniu rozmiaru tekstu reprezentującego dany akapit. Obliczanie rozmiaru tekstu bazuje na metrykach czcionki określonej w prezentacji PowerPoint. Jeśli określona czcionka jest nieobecna, zostaje zastąpiona najbliższą czcionką, jednak jej metryki różnią się od oryginalnych. W rezultacie obliczanie rozmiarów akapitów w różnych systemach prowadzi do odmiennych wyników w zależności od zestawu zainstalowanych czcionek. Aby uzyskać jednakowy wynik na różnych systemach operacyjnych, należy zainstalować te same czcionki na wszystkich systemach lub wczytać je w czasie działania jako [zewnętrzne czcionki](/slides/pl/java/custom-font/).

## **Formatowanie i obrazy**

**Q: Jak mogę ustawić kolor obramowania tabeli?**

**A**: Możesz zmienić kolor wszystkich obramowań tabeli lub tylko obramowania wokół całej tabeli. Aby zmienić wszystkie obramowania, użyj metody `getCellFormat` z interfejsu [ICell](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icell/). Dla obramowania całej tabeli należy przeiterować komórki i zmienić kolor zewnętrznych obramowań.

**Q: Jaką jednostkę miary Aspose.Slides for Java używa do rozmieszczania obrazów?**

**A**: Współrzędne i rozmiary wszystkich kształtów na slajdach mierzone są w punktach (72 dpi).

## **Praca z czcionkami**

**Q: Podczas konwertowania PPT do PDF lub obrazów, dlaczego czcionki różnią się w dokumentach wyjściowych?**

**A**: Ten problem może wskazywać, że czcionki użyte w prezentacji nie są dostępne w systemie operacyjnym, na którym uruchomiono kod. Należy zainstalować czcionki w systemie operacyjnym lub wczytać je jako zewnętrzne czcionki przy użyciu klasy [FontsLoader](https://reference.aspose.com/slides/pl/java/com.aspose.slides/fontsloader/) jak pokazano poniżej:
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```