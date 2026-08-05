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
- zamień czcionkę
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

Aspose.Slides umożliwia określenie czcionek zapasowych dla renderowania prezentacji oraz operacji eksportu. Czcionki zapasowe są używane, gdy podstawowa czcionka nie zawiera glifów dla określonych znaków.

Zachowanie zapasowe jest konfigurowane poprzez reguły zastępowania. Każda reguła kojarzy zakres Unicode z jedną lub większą liczbą czcionek, które mogą zawierać wymagane glify. Możesz definiować reguły dla różnych zakresów znaków, dodawać lub usuwać czcionki zapasowe w istniejących regułach oraz organizować wiele reguł w kolekcji reguł czcionek zapasowych.

Reguły zastępowania są ustawieniami renderowania w czasie wykonywania. Nie modyfikują samego pliku prezentacji i nie są przechowywane wewnątrz pliku PPTX.

## **Reguły zastępowania**

Aspose.Slides obsługuje interfejs [IFontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontfallbackrule/) oraz klasę [FontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/), aby określić reguły stosowania czcionki zapasowej. Klasa [FontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/) reprezentuje powiązanie pomiędzy określonym zakresem Unicode, używanym do wyszukiwania brakujących glifów, a listą czcionek, które mogą zawierać odpowiednie glify:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Możliwe jest również [Remove()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontfallbackrule/remove/) czcionkę zapasową lub [AddFallBackFonts()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) w istniejącym obiekcie [FontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/).

Kolekcję [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrulescollection/) można użyć do organizacji listy obiektów [FontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/), gdy istnieje potrzeba określenia reguł zastępowania czcionek zapasowych dla wielu zakresów Unicode.

{{% alert color="primary" title="See also" %}} 
- [Utwórz kolekcję czcionek zapasowych](/slides/pl/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między czcionką zapasową, podstawianiem czcionek a osadzaniem czcionek?**

Czcionka zapasowa jest używana wyłącznie dla znaków brakujących w podstawowej czcionce. [Font substitution](/slides/pl/cpp/font-substitution/) zastępuje całą określoną czcionkę inną czcionką. [Font embedding](/slides/pl/cpp/embedded-font/) pakietuje czcionki wewnątrz pliku wyjściowego, aby odbiorcy mogli wyświetlić tekst zgodnie z zamierzeniami.

**Czy czcionki zapasowe są stosowane podczas eksportu, takiego jak PDF, PNG lub SVG, czy tylko podczas renderowania na ekranie?**

Tak. Zapasowe wpływają na wszystkie [operacje renderowania i eksportu](/slides/pl/cpp/convert-presentation/), w których znaki muszą być narysowane, ale nie występują w źródłowej czcionce.

**Czy konfiguracja czcionek zapasowych zmienia sam plik prezentacji i czy ustawienie będzie zachowane przy późniejszych otwarciach?**

Nie. Reguły zastępowania są ustawieniami renderowania w czasie wykonywania w Twoim kodzie; nie są przechowywane w pliku .pptx i nie pojawią się w PowerPoint.

**Czy system operacyjny (Windows/Linux/macOS) oraz zestaw katalogów czcionek wpływają na wybór czcionek zapasowych?**

Tak. Silnik rozpoznaje czcionki z dostępnych folderów systemowych oraz z dowolnych [dodatkowych ścieżek](/slides/pl/cpp/custom-font/), które podasz. Jeśli czcionka nie jest fizycznie dostępna, reguła odwołująca się do niej nie może zostać zastosowana.

**Czy czcionki zapasowe działają dla WordArt, SmartArt i wykresów?**

Tak. Gdy te obiekty zawierają tekst, ten sam mechanizm podmiany glifów jest stosowany do renderowania brakujących znaków.