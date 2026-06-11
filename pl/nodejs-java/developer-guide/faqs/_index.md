---
title: FAQ
type: docs
weight: 340
url: /pl/nodejs-java/faqs/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Uzyskaj odpowiedzi na najczęściej zadawane pytania dotyczące Aspose.Slides dla Node.js via Java, obejmujące wsparcie dla PowerPoint i OpenDocument, wskazówki instalacji, licencjonowanie oraz rozwiązywanie problemów."
---
## **Przegląd**

To FAQ zawiera odpowiedzi na najczęstsze pytania dotyczące Aspose.Slides. Obejmuje obsługiwane formaty plików, obsługę wyjątków podczas pracy z dużymi prezentacjami, zmianę rozmiaru slajdów, podgląd slajdów, pobieranie tekstu z prezentacji, formatowanie obramowań tabel, umieszczanie obrazów oraz rozwiązywanie problemów związanych z czcionkami przy konwertowaniu prezentacji do formatu PDF lub obrazów.

## **Obsługiwane formaty plików**

**Q: Jakie formaty plików obsługuje Aspose.Slides for Node.js via Java?**

**A**: Aspose.Slides for Node.js via Java obsługuje formaty plików opisane w [Obsługiwane formaty plików](/slides/pl/nodejs-java/supported-file-formats/).

## **Wyjątki**

**Q: Występuje u mnie wyjątek out of memory podczas ładowania dużego pliku PPT z obrazami. Czy Aspose.Slides ma ograniczenie co do rozmiaru pliku?**

**A**: Nie istnieje konkretna formuła obliczania rozmiaru prezentacji obsługiwanej przez Aspose.Slides. Musi być wystarczająco dużo pamięci, aby pomieścić całą strukturę prezentacji oraz obrazy w pamięci. Zwykle obrazy w pamięci zajmują więcej miejsca niż na dysku twardym, szczególnie gdy mają dodatkowe efekty.

Ogólnie rzecz biorąc, Aspose.Slides for Node.js via Java może bez problemu obsłużyć pliki prezentacji o rozmiarze około 300 MB na serwerze z 4 GB RAM.

## **Praca ze slajdami**

**Q: Czy mogę zmienić rozmiar slajdów w prezentacji?**

**A**: Możesz użyć metody `getSlideSize` udostępnionej przez klasę [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) aby określić rozmiar slajdów w prezentacji.

**Q: Czy istnieje sposób, aby zdefiniować slajdy o różnych rozmiarach w jednej prezentacji?**

**A**: Ponieważ rozmiar slajdów jest definiowany na poziomie prezentacji w dokumentach Microsoft PowerPoint, nie ma możliwości zrobienia tego.

**Q: Czy Aspose.Slides for Node.js via Java obsługuje podgląd slajdu przed zapisaniem?**

**A**: Możesz renderować slajdy prezentacji do obrazów i używać tych obrazów do podglądu slajdów.

## **Praca z tekstem**

**Q: Czy możliwe jest pobranie całego tekstu z prezentacji?**

**A**: Aspose.Slides for Node.js via Java udostępnia klasę [SlideUtil](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slideutil/), która zawiera różne metody umożliwiające pobranie całego tekstu z prezentacji.

**Q: Dlaczego rozmiary akapitów różnią się w systemach operacyjnych Windows i Linux?**

**A**: Obliczanie rozmiarów akapitów opiera się na wyliczaniu rozmiaru tekstu reprezentującego dany akapit. Rozmiar tekstu jest obliczany na podstawie metryk czcionki określonej w prezentacji PowerPoint. Jeśli określona czcionka jest nieobecna, zostaje zastąpiona najbardziej podobną czcionką, jednak jej metryki różnią się od oryginalnych. W rezultacie obliczenia rozmiarów akapitów w różnych systemach dają różne wyniki w zależności od zestawu zainstalowanych czcionek. Aby uzyskać taki sam wynik na różnych systemach operacyjnych, należy zainstalować te same czcionki na wszystkich systemach lub wczytać je w czasie działania jako [zewnętrzne czcionki](/slides/pl/nodejs-java/custom-font/).

## **Formatowanie i obrazy**

**Q: Jak mogę ustawić kolor obramowania tabeli?**

**A**: Możesz zmienić kolor wszystkich obramowań tabeli lub tylko obramowania wokół całej tabeli. Aby zmienić wszystkie obramowania, użyj metody `getCellFormat` z klasy [Cell](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/cell/). W przypadku obramowania całej tabeli powinieneś iterować po komórkach i zmienić kolor obramowań zewnętrznych.

**Q: Jaką jednostkę miary używa Aspose.Slides for Node.js via Java do umieszczania obrazów?**

**A**: Współrzędne i rozmiary wszystkich kształtów na slajdach mierzone są w punktach (72 dpi).

## **Praca z czcionkami**

**Q: Podczas konwertowania PPT do PDF lub obrazów, dlaczego czcionki różnią się w dokumentach wyjściowych?**

**A**: Ten problem może wskazywać, że czcionki użyte w prezentacji są nieobecne w systemie operacyjnym, na którym uruchomiono kod. Należy zainstalować czcionki w systemie operacyjnym lub wczytać je jako zewnętrzne czcionki przy użyciu klasy [FontsLoader](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fontsloader/) jak pokazano poniżej:
```javascript
var folders = java.newArray("java.lang.String", ["path_to_a_folder_with_fonts"]));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", folders);
```