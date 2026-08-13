---
title: Określ czcionki zastępcze dla prezentacji w Javie
linktitle: Czcionka zastępcza
type: docs
weight: 10
url: /pl/java/create-fallback-font/
keywords:
- czcionka zastępcza
- reguła zastępcza
- zastosuj czcionkę
- zamień czcionkę
- zakres Unicode
- brakujący glif
- właściwy glif
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Opanuj Aspose.Slides dla Javy, aby ustawić czcionki zastępcze w plikach PPT, PPTX i ODP, zapewniając spójne wyświetlanie tekstu na każdym urządzeniu lub systemie operacyjnym."
---
## **Przegląd**

Aspose.Slides pozwala określić czcionki zastępcze dla renderowania prezentacji i operacji eksportu. Czcionki zastępcze są używane, gdy podstawowa czcionka nie zawiera glifów dla określonych znaków.

Zachowanie czcionek zastępczych jest konfigurowane za pomocą reguł zastępczych. Każda reguła kojarzy zakres Unicode z jedną lub większą liczbą czcionek, które mogą zawierać wymagane glify. Można definiować reguły dla różnych zakresów znaków, dodawać lub usuwać czcionki zastępcze z istniejących reguł oraz organizować wiele reguł w kolekcji reguł czcionek zastępczych.

Reguły zastępcze są ustawieniami renderowania w czasie wykonywania. Nie modyfikują samego pliku prezentacji i nie są przechowywane w pliku PPTX.

## **Reguły zastępcze**

Aspose.Slides obsługuje interfejs [IFontFallBackRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IFontFallBackRule) oraz klasę [FontFallBackRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule), aby określić reguły zastosowania czcionki zastępczej. Klasa [FontFallBackRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule) reprezentuje powiązanie określonego zakresu Unicode, używanego do wyszukiwania brakujących glifów, oraz listy czcionek, które mogą zawierać właściwe glify:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Możliwe jest również [usunięcie](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) czcionki zastępczej lub [dodanie czcionek zastępczych](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) do istniejącego obiektu [FontFallBackRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRulesCollection) może być użyta do organizowania listy obiektów [FontFallBackRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule), gdy zachodzi potrzeba określenia reguł zamiany czcionek zastępczych dla wielu zakresów Unicode.

{{% alert color="info" title="Zobacz także" %}} 
- [Utwórz kolekcję czcionek zastępczych](/slides/pl/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Jaka jest różnica między czcionką zastępczą, podstawianiem czcionek a osadzaniem czcionek?

Czcionka zastępcza jest używana wyłącznie dla znaków brakujących w podstawowej czcionce. [Podstawianie czcionek](/slides/pl/java/font-substitution/) zastępuje całą określoną czcionkę inną czcionką. [Osadzanie czcionek](/slides/pl/java/embedded-font/) pakietuje czcionki wewnątrz pliku wyjściowego, dzięki czemu odbiorcy mogą wyświetlać tekst tak, jak zamierzono.

### Czy czcionki zastępcze są stosowane podczas eksportu, takiego jak PDF, PNG lub SVG, czy tylko podczas renderowania na ekranie?

Tak. Czcionki zastępcze wpływają na wszystkie [operacje renderowania i eksportu](/slides/pl/java/convert-presentation/), w których znaki muszą być rysowane, ale nie ma ich w źródłowej czcionce.

### Czy konfigurowanie czcionek zastępczych zmienia sam plik prezentacji i czy ustawienie będzie zachowane przy przyszłych otwarciach?

Nie. Reguły zastępcze są ustawieniami renderowania w czasie wykonywania w Twoim kodzie; nie są przechowywane w pliku .pptx i nie pojawią się w programie PowerPoint.

### Czy system operacyjny (Windows/Linux/macOS) oraz zestaw katalogów z czcionkami wpływają na wybór czcionek zastępczych?

Tak. Silnik wyszukuje czcionki w dostępnych folderach systemowych oraz w dowolnych [dodatkowych ścieżkach](/slides/pl/java/custom-font/), które podasz. Jeśli czcionka nie jest fizycznie dostępna, reguła odwołująca się do niej nie może zostać zastosowana.

### Czy czcionki zastępcze działają dla WordArt, SmartArt i wykresów?

Tak. Gdy te obiekty zawierają tekst, stosowany jest ten sam mechanizm podstawiania glifów, aby renderować brakujące znaki.