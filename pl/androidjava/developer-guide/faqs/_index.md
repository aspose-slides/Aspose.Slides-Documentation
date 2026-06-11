---
title: FAQ
type: docs
weight: 340
url: /pl/androidjava/faqs/
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
- Android
- Java
- Aspose.Slides
description: "Uzyskaj odpowiedzi na najczęściej zadawane pytania dotyczące Aspose.Slides dla Androida w Javie, obejmujące wsparcie dla PowerPoint i OpenDocument, wskazówki instalacyjne, licencjonowanie oraz rozwiązywanie problemów."
---
## **Przegląd**

To FAQ zawiera odpowiedzi na najczęściej zadawane pytania dotyczące Aspose.Slides. Omówiono obsługiwane formaty plików, obsługę wyjątków przy pracy z dużymi prezentacjami, zmianę rozmiaru slajdów, podgląd slajdów, pobieranie tekstu z prezentacji, formatowanie obramowań tabel, umieszczanie obrazów oraz rozwiązywanie problemów związanych z czcionkami podczas konwersji prezentacji do PDF lub obrazów.

## **Obsługiwane formaty plików**

**Q: Jakie formaty plików obsługuje Aspose.Slides for Android via Java?**

**A**: Aspose.Slides for Android via Java obsługuje formaty plików opisane w [Supported File Formats](/slides/pl/androidjava/supported-file-formats/).

## **Wyjątki**

**Q: Podczas ładowania dużego pliku PPT z obrazami pojawia się wyjątek „out of memory”. Czy Aspose.Slides ma ograniczenie rozmiaru pliku?**

**A**: Nie istnieje konkretna formuła pozwalająca obliczyć maksymalny rozmiar prezentacji obsługiwany przez Aspose.Slides. Należy zapewnić wystarczającą ilość pamięci, aby pomieścić całą strukturę prezentacji oraz obrazy w pamięci. Zazwyczaj obrazy w pamięci zajmują więcej miejsca niż na dysku, szczególnie gdy mają dodatkowe efekty.

Ogólnie Aspose.Slides for Android via Java może bez problemu obsłużyć pliki prezentacji o wielkości około 300 MB na serwerze z 4 GB RAM.

## **Praca ze slajdami**

**Q: Czy mogę zmienić rozmiar slajdów w prezentacji?**

**A**: Możesz użyć metody `getSlideSize` udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), aby określić rozmiar slajdów w prezentacji.

**Q: Czy istnieje możliwość definiowania slajdów o różnych rozmiarach w jednej prezentacji?**

**A**: Ponieważ rozmiar slajdów jest definiowany na poziomie prezentacji w dokumentach Microsoft PowerPoint, nie ma takiej możliwości.

**Q: Czy Aspose.Slides for Android via Java umożliwia podgląd slajdu przed zapisaniem?**

**A**: Możesz renderować slajdy prezentacji do obrazów i wykorzystać te obrazy do podglądu slajdów.

## **Praca z tekstem**

**Q: Czy można pobrać cały tekst z prezentacji?**

**A**: Aspose.Slides for Android via Java udostępnia klasę [SlideUtil](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slideutil/), która zawiera różne metody służące do pobierania pełnego tekstu z prezentacji.

**Q: Dlaczego rozmiary akapitów różnią się na komputerze PC i w systemie Android?**

**A**: Obliczanie rozmiarów akapitów opiera się na wielkości tekstu reprezentującego dany akapit. Wielkość tekstu jest określana na podstawie metrów czcionki określonej w prezentacji PowerPoint. Jeśli wymagana czcionka jest nieobecna, zostaje zastąpiona najbliższą czcionką, której metryki różnią się od oryginalnych. W rezultacie obliczenia rozmiarów akapitów w różnych systemach dają odrębne wyniki w zależności od zestawu zainstalowanych czcionek. Aby uzyskać identyczny efekt na różnych systemach operacyjnych, należy zainstalować te same czcionki na wszystkich systemach lub załadować je w czasie wykonywania jako [external fonts](/slides/pl/androidjava/custom-font/).

## **Formatowanie i obrazy**

**Q: Jak ustawić kolor obramowania tabeli?**

**A**: Możesz zmienić kolor wszystkich obramowań tabeli lub tylko obramowania obejmującego całą tabelę. Aby zmienić wszystkie obramowania, użyj metody `getCellFormat` z interfejsu [ICell](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icell/). W przypadku obramowania całej tabeli należy przeiterować komórki i zmienić kolor zewnętrznych krawędzi.

**Q: Jaką jednostkę miary używa Aspose.Slides for Android via Java do umieszczania obrazów?**

**A**: Współrzędne i rozmiary wszystkich kształtów na slajdach mierzone są w punktach (72 dpi).

## **Praca z czcionkami**

**Q: Dlaczego po konwersji PPT do PDF lub obrazów czcionki różnią się w dokumentach wyjściowych?**

**A**: Problem może wynikać z brakujących czcionek użytych w prezentacji w systemie operacyjnym, na którym uruchomiono kod. Należy zainstalować brakujące czcionki w systemie operacyjnym lub załadować je jako czcionki zewnętrzne przy użyciu klasy [FontsLoader](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/fontsloader/), jak pokazano poniżej:
```java
String[] folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```