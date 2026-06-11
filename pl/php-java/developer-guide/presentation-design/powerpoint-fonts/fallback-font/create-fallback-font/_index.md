---
title: Określanie czcionek awaryjnych dla prezentacji w PHP
linktitle: Czcionka awaryjna
type: docs
weight: 10
url: /pl/php-java/create-fallback-font/
keywords:
- czcionka awaryjna
- reguła awaryjna
- zastosuj czcionkę
- zastąp czcionkę
- zakres Unicode
- brakujący glif
- odpowiedni glif
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Opanuj Aspose.Slides dla PHP poprzez Java, aby ustawić czcionki awaryjne w plikach PPT, PPTX i ODP, zapewniając spójne wyświetlanie tekstu na każdym urządzeniu i systemie operacyjnym."
---
## **Przegląd**

Aspose.Slides pozwala określić czcionki awaryjne (fallback) dla renderowania prezentacji i operacji eksportu. Czcionki awaryjne są używane, gdy podstawowa czcionka nie zawiera glifów dla konkretnych znaków.

Zachowanie awaryjne konfiguruje się poprzez reguły fallback. Każda reguła łączy zakres Unicode z jedną lub wieloma czcionkami, które mogą zawierać wymagane glify. Można definiować reguły dla różnych zakresów znaków, dodawać lub usuwać czcionki awaryjne z istniejących reguł oraz organizować wiele reguł w kolekcji reguł czcionek awaryjnych.

Reguły fallback są ustawieniami renderowania w czasie wykonywania. Nie modyfikują samego pliku prezentacji i nie są przechowywane wewnątrz pliku PPTX.

## **Reguły fallback**

Aspose.Slides obsługuje klasę [FontFallBackRule](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontFallBackRule), aby określić reguły stosowania czcionki awaryjnej. Klasa [FontFallBackRule](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontFallBackRule) reprezentuje powiązanie pomiędzy określonym zakresem Unicode, używanym do wyszukiwania brakujących glifów, a listą czcionek, które mogą zawierać odpowiednie glify:

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # Używając różnych sposobów możesz dodać listę czcionek:
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

Możliwe jest również [remove](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontfallbackrule/remove/) czcionki awaryjnej lub [addFallBackFonts](https://reference.aspose.com/slides/pl/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) w istniejącym obiekcie [FontFallBackRule](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontFallBackRulesCollection) może być użyta do organizowania listy obiektów [FontFallBackRule](https://reference.aspose.com/slides/pl/php-java/aspose.slides/FontFallBackRule), gdy istnieje potrzeba określenia reguł zamiany czcionek awaryjnych dla wielu zakresów Unicode.

{{% alert color="primary" title="Zobacz również" %}} 
- [Utwórz kolekcję czcionek awaryjnych](/slides/pl/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między czcionką awaryjną, podstawieniem czcionki a osadzaniem czcionki?**

Czcionka awaryjna jest używana tylko dla znaków brakujących w podstawowej czcionce. [Font substitution](/slides/pl/php-java/font-substitution/) zastępuje całą określoną czcionkę inną czcionką. [Font embedding](/slides/pl/php-java/embedded-font/) pakietuje czcionki wewnątrz pliku wyjściowego, aby odbiorcy mogli wyświetlić tekst zgodnie z zamierzeniami.

**Czy czcionki awaryjne są stosowane podczas eksportu, takiego jak PDF, PNG lub SVG, czy tylko podczas renderowania na ekranie?**

Tak. Fallback wpływa na wszystkie [operacje renderowania i eksportu](/slides/pl/php-java/convert-presentation/) gdzie znaki muszą być narysowane, ale nie występują w źródłowej czcionce.

**Czy konfiguracja fallback zmienia sam plik prezentacji i czy ustawienie będzie utrzymywane przy przyszłych otwarciach?**

Nie. Reguły fallback są ustawieniami renderowania w czasie wykonywania w twoim kodzie; nie są przechowywane wewnątrz .pptx i nie pojawią się w PowerPoint.

**Czy system operacyjny (Windows/Linux/macOS) oraz zestaw katalogów czcionek wpływają na wybór fallback?**

Tak. Silnik rozwiązuje czcionki z dostępnych folderów systemowych oraz wszelkich [dodatkowych ścieżek](/slides/pl/php-java/custom-font/), które podasz. Jeżeli czcionka nie jest fizycznie dostępna, reguła odwołująca się do niej nie może działać.

**Czy fallback działa dla WordArt, SmartArt i wykresów?**

Tak. Gdy te obiekty zawierają tekst, stosowany jest ten sam mechanizm podstawiania glifów w celu renderowania brakujących znaków.