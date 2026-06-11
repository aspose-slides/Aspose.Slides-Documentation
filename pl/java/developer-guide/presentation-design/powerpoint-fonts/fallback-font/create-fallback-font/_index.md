---
title: Określ czcionki zapasowe dla prezentacji w Javie
linktitle: Czcionka zapasowa
type: docs
weight: 10
url: /pl/java/create-fallback-font/
keywords:
- czcionka zapasowa
- reguła zapasowa
- zastosuj czcionkę
- zamień czcionkę
- zakres Unicode
- brakujący glif
- odpowiedni glif
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Opanuj Aspose.Slides for Java, aby ustawić czcionki zapasowe w plikach PPT, PPTX i ODP, zapewniając spójne wyświetlanie tekstu na każdym urządzeniu i systemie operacyjnym."
---
## **Przegląd**

Aspose.Slides umożliwia określenie czcionek zapasowych dla renderowania prezentacji i operacji eksportu. Czcionki zapasowe są używane, gdy podstawowa czcionka nie zawiera glifów dla określonych znaków.

Zachowanie zapasowe jest konfigurowane za pomocą reguł zapasowych. Każda reguła łączy zakres Unicode z jedną lub większą liczbą czcionek, które mogą zawierać wymagane glify. Możesz definiować reguły dla różnych zakresów znaków, dodawać lub usuwać czcionki zapasowe z istniejących reguł oraz organizować wiele reguł w kolekcji reguł czcionek zapasowych.

Reguły zapasowe są ustawieniami renderowania w czasie wykonywania. Nie modyfikują samego pliku prezentacji i nie są przechowywane wewnątrz pliku PPTX.

## **Reguły czcionek zapasowych**

Aspose.Slides obsługuje interfejs [IFontFallBackRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IFontFallBackRule) oraz klasę [FontFallBackRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule), aby określić reguły stosowania czcionki zapasowej. Klasa [FontFallBackRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule) reprezentuje powiązanie pomiędzy określonym zakresem Unicode, używanym do wyszukiwania brakujących glifów, a listą czcionek, które mogą zawierać odpowiednie glify:

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Używając różnych metod możesz dodać listę czcionek:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Możliwe jest również [usunięcie](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) czcionki zapasowej lub [addFallBackFonts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) do istniejącego obiektu [FontFallBackRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRulesCollection) może być użyta do organizowania listy obiektów [FontFallBackRule](https://reference.aspose.com/slides/pl/java/com.aspose.slides/FontFallBackRule), gdy istnieje potrzeba określenia reguł zastępowania czcionek zapasowych dla wielu zakresów Unicode.

{{% alert color="primary" title="See also" %}} 
- [Utwórz kolekcję czcionek zapasowych](/slides/pl/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między czcionką zapasową, substytucją czcionki a osadzaniem czcionki?**

Czcionka zapasowa jest używana tylko dla znaków brakujących w podstawowej czcionce. [Font substitution](/slides/pl/java/font-substitution/) zamienia całą określoną czcionkę na inną. [Font embedding](/slides/pl/java/embedded-font/) pakietuje czcionki wewnątrz pliku wyjściowego, aby odbiorcy mogli zobaczyć tekst zgodnie z zamierzeniami.

**Czy czcionki zapasowe są stosowane podczas eksportu, takiego jak PDF, PNG lub SVG, czy tylko podczas renderowania na ekranie?**

Tak. Zapasowe wpływają na wszystkie [operacje renderowania i eksportu](/slides/pl/java/convert-presentation/), w których znaki muszą być narysowane, ale są nieobecne w źródłowej czcionce.

**Czy konfigurowanie czcionek zapasowych zmienia sam plik prezentacji i czy ustawienie będzie utrzymywane przy kolejnych otwarciach?**

Nie. Reguły zapasowe są ustawieniami renderowania w czasie wykonywania w Twoim kodzie; nie są przechowywane w pliku .pptx i nie pojawią się w programie PowerPoint.

**Czy system operacyjny (Windows/Linux/macOS) oraz zestaw katalogów czcionek wpływają na wybór czcionek zapasowych?**

Tak. Silnik wyszukuje czcionki w dostępnych folderach systemowych oraz w [dodatkowych ścieżkach](/slides/pl/java/custom-font/), które podasz. Jeśli czcionka nie jest fizycznie dostępna, reguła odwołująca się do niej nie może zostać zastosowana.

**Czy czcionki zapasowe działają dla WordArt, SmartArt i wykresów?**

Tak. Gdy te obiekty zawierają tekst, zastosowany jest ten sam mechanizm podmiany glifów w celu renderowania brakujących znaków.