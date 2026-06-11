---
title: Najczęściej zadawane pytania
type: docs
weight: 340
url: /pl/net/faqs/
keywords:
- FAQ
- PowerPoint
- format prezentacji
- błąd braku pamięci
- rozmiar slajdu
- wyodrębnianie tekstu
- pobieranie tekstu
- rozmiar akapitu
- formatowanie tabel
- czcionka
- .NET
- C#
- Aspose.Slides
description: "Uzyskaj odpowiedzi na najczęściej zadawane pytania dotyczące Aspose.Slides dla .NET, obejmujące obsługę PowerPoint i OpenDocument, wskazówki instalacji, licencjonowanie oraz rozwiązywanie problemów."
---
## **Przegląd**

To FAQ zawiera odpowiedzi na najczęstsze pytania dotyczące Aspose.Slides. Obejmuje obsługiwane formaty plików, obsługę wyjątków przy pracy z dużymi prezentacjami, zmianę rozmiaru slajdów, podgląd slajdów, pobieranie tekstu z prezentacji, formatowanie obramowań tabel, umieszczanie obrazów oraz rozwiązywanie problemów związanych z czcionkami podczas konwertowania prezentacji do formatu PDF lub obrazów.

## **Obsługiwane formaty plików**

**Q: Jakie formaty plików obsługuje Aspose.Slides dla .NET?**
**A:** Aspose.Slides dla .NET obsługuje formaty plików opisane w [Supported File Formats](/slides/pl/net/supported-file-formats/).

## **Wyjątki**

**Q: Otrzymuję wyjątek OutOfMemoryException podczas ładowania dużego pliku PPT z obrazami. Czy w Aspose.Slides istnieje ograniczenie rozmiaru pliku?**
**A:** Nie ma konkretnej formuły do obliczania rozmiaru prezentacji obsługiwanej przez Aspose.Slides. Powinna istnieć wystarczająca ilość pamięci, aby pomieścić całą strukturę prezentacji oraz obrazy w pamięci. Zazwyczaj obrazy w pamięci zajmują więcej miejsca niż na dysku twardym, szczególnie gdy mają dodatkowe efekty.

Ogólnie, Aspose.Slides dla .NET może łatwo obsługiwać pliki prezentacji o wielkości około 300 MB na serwerze z 4 GB RAM.

## **Praca ze slajdami**

**Q: Czy mogę zmienić rozmiar slajdów w prezentacji?**
**A:** Możesz użyć właściwości `SlideSize` udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/), aby zdefiniować rozmiar slajdów w prezentacji.

**Q: Czy istnieje możliwość zdefiniowania slajdów o różnych rozmiarach w jednej prezentacji?**
**A:** Ponieważ rozmiar slajdów jest definiowany na poziomie prezentacji w dokumentach Microsoft PowerPoint, nie ma możliwości takiego działania.

**Q: Czy Aspose.Slides dla .NET obsługuje podgląd slajdu przed zapisaniem?**
**A:** Możesz renderować slajdy prezentacji do obrazów i używać tych obrazów do podglądu slajdów.

## **Praca z tekstem**

**Q: Czy można pobrać cały tekst z prezentacji?**
**A:** Aspose.Slides dla .NET udostępnia klasę [SlideUtil](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/) w przestrzeni nazw `Aspose.Slides.Util`, która oferuje różne metody pobierania całego tekstu z prezentacji.

**Q: Dlaczego rozmiary akapitów różnią się w systemach operacyjnych Windows i Linux?**
**A:** Obliczanie rozmiarów akapitów opiera się na wyliczaniu rozmiaru tekstu reprezentującego dany akapit. Rozmiar tekstu jest obliczany na podstawie metryk czcionki określonej w prezentacji PowerPoint. Jeśli określona czcionka jest nieobecna, zostaje zastąpiona najbardziej podobną czcionką, ale jej metryki różnią się od oryginalnych. W rezultacie obliczanie rozmiarów akapitów w różnych systemach prowadzi do odmiennych wyników w zależności od zestawu zainstalowanych czcionek. Aby uzyskać taki sam efekt na różnych systemach operacyjnych, należy zainstalować te same czcionki na systemach lub wczytać je w czasie wykonywania jako [external fonts](/slides/pl/net/custom-font/).

## **Formatowanie i obrazy**

**Q: Jak mogę ustawić kolor obramowania tabeli?**
**A:** Możesz zmienić kolor wszystkich obramowań tabeli lub tylko obramowania całej tabeli. Aby zmienić wszystkie obramowania, użyj właściwości `CellFormat` z interfejsu [ICell](https://reference.aspose.com/slides/pl/net/aspose.slides/icell/). Aby zmienić obramowanie całej tabeli, należy przejść przez komórki i zmienić kolor zewnętrznych obramowań.

**Q: Jaką jednostkę miary używa Aspose.Slides dla .NET przy umieszczaniu obrazów?**
**A:** Współrzędne i rozmiary wszystkich kształtów na slajdach mierzone są w punktach (72 dpi).

## **Praca z czcionkami**

**Q: Podczas konwertowania PPT do PDF lub obrazów, dlaczego czcionki w dokumentach wyjściowych są inne?**
**A:** Ten problem może wskazywać, że czcionki użyte w prezentacji są nieobecne w systemie operacyjnym, na którym uruchomiono kod. Należy zainstalować czcionki w systemie operacyjnym lub wczytać je jako czcionki zewnętrzne przy użyciu klasy [FontsLoader](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/) jak pokazano poniżej:
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```