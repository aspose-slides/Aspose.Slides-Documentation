---
title: Określ czcionki zastępcze dla prezentacji na Androidzie
linktitle: Czcionka zastępcza
type: docs
weight: 10
url: /pl/androidjava/create-fallback-font/
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
- Android
- Java
- Aspose.Slides
description: "Opanuj Aspose.Slides dla Androida w Javie, aby ustawiać czcionki zastępcze w plikach PPT, PPTX i ODP, zapewniając spójne wyświetlanie tekstu na każdym urządzeniu lub systemie operacyjnym."
---
## **Przegląd**

Aspose.Slides umożliwia określenie czcionek zastępczych dla renderowania prezentacji i operacji eksportu. Czcionki zastępcze są używane, gdy czcionka podstawowa nie zawiera glifów dla konkretnych znaków.

Zachowanie czcionek zastępczych jest konfigurowane za pomocą reguł zastępczych. Każda reguła wiąże zakres Unicode z jedną lub wieloma czcionkami, które mogą zawierać wymagane glify. Możesz definiować reguły dla różnych zakresów znaków, dodawać lub usuwać czcionki zastępcze w istniejących regułach oraz organizować wiele reguł w kolekcji reguł czcionek zastępczych.

Reguły zastępcze są ustawieniami renderowania w czasie wykonywania. Nie modyfikują samego pliku prezentacji i nie są przechowywane wewnątrz pliku PPTX.

## **Reguły zastępcze**

Aspose.Slides obsługuje interfejs [IFontFallBackRule](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IFontFallBackRule) oraz klasę [FontFallBackRule](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule), aby określić reguły stosowania czcionki zastępczej. Klasa [FontFallBackRule](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule) reprezentuje powiązanie między określonym zakresem Unicode, używanym do wyszukiwania brakujących glifów, a listą czcionek, które mogą zawierać odpowiednie glify:

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Używając różnych sposobów możesz dodać listę czcionek:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Możliwe jest również [remove](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) czcionkę zastępczą lub [addFallBackFonts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) w istniejącym obiekcie [FontFallBackRule](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRulesCollection) może być użyta do zorganizowania listy obiektów [FontFallBackRule](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule), gdy istnieje potrzeba określenia reguł zastąpienia czcionek zastępczych dla wielu zakresów Unicode.

{{% alert color="info" title="Zobacz również" %}} 
- [Utwórz kolekcję czcionek zastępczych](/slides/pl/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Jaka jest różnica między czcionką zastępczą, zastąpieniem czcionki a osadzaniem czcionki?

Czcionka zastępcza jest używana wyłącznie dla znaków brakujących w czcionce podstawowej. [Zastąpienie czcionki](/slides/pl/androidjava/font-substitution/) zastępuje całą określoną czcionkę inną czcionką. [Osadzanie czcionki](/slides/pl/androidjava/embedded-font/) pakietuje czcionki wewnątrz pliku wyjściowego, dzięki czemu odbiorcy mogą wyświetlić tekst zgodnie z zamierzeniami.

### Czy czcionki zastępcze są stosowane podczas eksportu, takiego jak PDF, PNG lub SVG, czy tylko podczas renderowania na ekranie?

Tak. Zastępcze wpływają na wszystkie [operacje renderowania i eksportu](/slides/pl/androidjava/convert-presentation/), w których znaki muszą być narysowane, ale nie występują w czcionce źródłowej.

### Czy konfigurowanie czcionek zastępczych zmienia sam plik prezentacji i czy ustawienie będzie utrzymywane przy kolejnych otwarciach?

Nie. Reguły zastępcze są ustawieniami renderowania w czasie wykonywania w Twoim kodzie; nie są przechowywane w pliku .pptx i nie pojawią się w programie PowerPoint.

### Czy system operacyjny (Windows/Linux/macOS) oraz zestaw katalogów czcionek wpływają na wybór czcionek zastępczych?

Tak. Silnik rozwiązuje czcionki z dostępnych folderów systemowych oraz z dowolnych [dodatkowych ścieżek](/slides/pl/androidjava/custom-font/), które podasz. Jeśli czcionka nie jest fizycznie dostępna, reguła ją odwołująca nie może zostać zastosowana.

### Czy czcionki zastępcze działają dla WordArt, SmartArt i wykresów?

Tak. Gdy te obiekty zawierają tekst, stosowany jest ten sam mechanizm zastępowania glifów, aby renderować brakujące znaki.