---
title: Określ czcionki zapasowe dla prezentacji na Androidzie
linktitle: Czcionka zapasowa
type: docs
weight: 10
url: /pl/androidjava/create-fallback-font/
keywords:
- czcionka zapasowa
- reguła zapasowa
- zastosuj czcionkę
- zastąp czcionkę
- zakres Unicode
- brakujący glif
- odpowiedni glif
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Opanuj Aspose.Slides dla Androida w Javie, aby ustawić czcionki zapasowe w plikach PPT, PPTX i ODP, zapewniając konsekwentne wyświetlanie tekstu na każdym urządzeniu lub systemie operacyjnym."
---
## **Przegląd**

Aspose.Slides umożliwia określenie czcionek zapasowych dla renderowania i operacji eksportu prezentacji. Czcionki zapasowe są używane, gdy czcionka podstawowa nie zawiera glifów dla określonych znaków.

Zachowanie zapasowe jest konfigurowane za pomocą reguł zapasowych. Każda reguła łączy zakres Unicode z jedną lub wieloma czcionkami, które mogą zawierać wymagane glify. Możesz definiować reguły dla różnych zakresów znaków, dodawać lub usuwać czcionki zapasowe z istniejących reguł oraz organizować wiele reguł w kolekcji reguł czcionek zapasowych.

Reguły zapasowe są ustawieniami renderowania w czasie wykonania. Nie modyfikują samego pliku prezentacji i nie są przechowywane w pliku PPTX.

## **Reguły zapasowe**

Aspose.Slides obsługuje interfejs [IFontFallBackRule](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IFontFallBackRule) oraz klasę [FontFallBackRule](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule), aby określić reguły stosowania czcionki zapasowej. Klasa [FontFallBackRule](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule) reprezentuje powiązanie między określonym zakresem Unicode, używanym do wyszukiwania brakujących glifów, a listą czcionek, które mogą zawierać odpowiednie glify:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Możliwe jest również [usunięcie](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) czcionki zapasowej lub [dodanie czcionek zapasowych](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) do istniejącego obiektu [FontFallBackRule](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRulesCollection) można użyć do zorganizowania listy obiektów [FontFallBackRule](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FontFallBackRule), gdy istnieje potrzeba określenia reguł zastępowania czcionek zapasowych dla wielu zakresów Unicode.

{{% alert color="primary" title="See also" %}} 
- [Utwórz kolekcję czcionek zapasowych](/slides/pl/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między czcionką zapasową, substytucją czcionki a osadzaniem czcionki?**

Czcionka zapasowa jest używana tylko dla znaków brakujących w czcionce podstawowej. [Substitucja czcionki](/slides/pl/androidjava/font-substitution/) zastępuje całą określoną czcionkę inną czcionką. [Osadzanie czcionki](/slides/pl/androidjava/embedded-font/) pakietuje czcionki wewnątrz pliku wyjściowego, aby odbiorcy mogli zobaczyć tekst tak, jak zamierzono.

**Czy czcionki zapasowe są stosowane podczas eksportu, takiego jak PDF, PNG lub SVG, czy tylko przy renderowaniu na ekranie?**

Tak. Zapasowe wpływają na wszystkie [operacje renderowania i eksportu](/slides/pl/androidjava/convert-presentation/), w których znaki muszą być rysowane, ale nie ma ich w czcionce źródłowej.

**Czy konfigurowanie czcionek zapasowych zmienia sam plik prezentacji i czy ustawienie będzie trwałe przy kolejnych otwarciach?**

Nie. Reguły zapasowe są ustawieniami renderowania w czasie wykonania w Twoim kodzie; nie są przechowywane w pliku .pptx i nie pojawią się w programie PowerPoint.

**Czy system operacyjny (Windows/Linux/macOS) oraz zestaw katalogów czcionek wpływają na wybór czcionki zapasowej?**

Tak. Silnik wyszukuje czcionki w dostępnych katalogach systemowych oraz w [dodatkowych ścieżkach](/slides/pl/androidjava/custom-font/), które podasz. Jeśli czcionka nie jest fizycznie dostępna, reguła odwołująca się do niej nie może zostać zastosowana.

**Czy czcionki zapasowe działają dla WordArt, SmartArt i wykresów?**

Tak. Gdy te obiekty zawierają tekst, stosowany jest ten sam mechanizm zastępowania glifów, aby renderować brakujące znaki.