---
title: Określ czcionki zapasowe dla prezentacji w C++
linktitle: Czcionka zapasowa
type: docs
weight: 10
url: /pl/cpp/create-fallback-font/
keywords:
- czcionka zapasowa
- reguła zapasowa
- zastosuj czcionkę
- zastąp czcionkę
- zakres Unicode
- brakujący glif
- prawidłowy glif
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Opanuj Aspose.Slides dla C++, aby ustawić czcionki zapasowe w plikach PPT, PPTX i ODP, zapewniając spójne wyświetlanie tekstu na każdym urządzeniu lub systemie operacyjnym."
---
## **Przegląd**

Aspose.Slides umożliwia określenie czcionek zapasowych dla renderowania prezentacji i operacji eksportu. Czcionki zapasowe są używane, gdy główna czcionka nie zawiera glifów dla konkretnych znaków.

Zachowanie zapasowe jest konfigurowane poprzez reguły zapasowe. Każda reguła powiązuje zakres Unicode z jedną lub większą liczbą czcionek, które mogą zawierać wymagane glify. Możesz definiować reguły dla różnych zakresów znaków, dodawać lub usuwać czcionki zapasowe z istniejących reguł oraz organizować wiele reguł w kolekcji reguł czcionek zapasowych.

Reguły zapasowe są ustawieniami renderowania w czasie wykonywania. Nie modyfikują one samego pliku prezentacji i nie są przechowywane wewnątrz pliku PPTX.

## **Reguły zapasowe**

Aspose.Slides obsługuje interfejs [IFontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontfallbackrule/) oraz klasę [FontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/) do określania reguł stosowania czcionki zapasowej. Klasa [FontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/) reprezentuje powiązanie między określonym zakresem Unicode, używanym do wyszukiwania brakujących glifów, a listą czcionek, które mogą zawierać właściwe glify:

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Używając różnych sposobów możesz dodać listę czcionek:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Możliwe jest również [Remove()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontfallbackrule/remove/) czcionki zapasowej lub [AddFallBackFonts()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) w istniejącym obiekcie [FontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/) .

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrulescollection/) może być użyta do organizowania listy obiektów [FontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/) , gdy istnieje potrzeba określenia reguł zamiany czcionek zapasowych dla wielu zakresów Unicode.

{{% alert color="info" title="Zobacz także" %}} 
- [Utwórz kolekcję czcionek zapasowych](/slides/pl/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Jaka jest różnica między czcionką zapasową, podstawianiem czcionki a osadzaniem czcionki?

Czcionka zapasowa jest używana tylko dla znaków brakujących w głównej czcionce. [Font substitution](/slides/pl/cpp/font-substitution/) zastępuje całą określoną czcionkę inną czcionką. [Font embedding](/slides/pl/cpp/embedded-font/) pakietuje czcionki wewnątrz pliku wyjściowego, aby odbiorcy mogli wyświetlić tekst zgodnie z zamierzeniami.

### Czy czcionki zapasowe są stosowane podczas eksportu, takiego jak PDF, PNG lub SVG, czy tylko przy renderowaniu na ekranie?

Tak. Zapasowe wpływają na wszystkie [rendering and export operations](/slides/pl/cpp/convert-presentation/), w których znaki muszą być rysowane, ale nie ma ich w źródłowej czcionce.

### Czy konfigurowanie czcionek zapasowych zmienia sam plik prezentacji i czy ustawienie będzie trwało przy kolejnych otwarciach?

Nie. Reguły zapasowe są ustawieniami renderowania w czasie wykonywania w Twoim kodzie; nie są przechowywane wewnątrz .pptx i nie pojawią się w PowerPoint.

### Czy system operacyjny (Windows/Linux/macOS) oraz zestaw katalogów czcionek wpływają na wybór czcionki zapasowej?

Tak. Silnik rozwiązuje czcionki z dostępnych folderów systemowych oraz z dowolnych [additional paths](/slides/pl/cpp/custom-font/) podanych przez Ciebie. Jeśli czcionka nie jest fizycznie dostępna, reguła odwołująca się do niej nie może zostać zastosowana.

### Czy czcionki zapasowe działają dla WordArt, SmartArt i wykresów?

Tak. Gdy te obiekty zawierają tekst, stosowany jest ten sam mechanizm podmieniania glifów w celu renderowania brakujących znaków.