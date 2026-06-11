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
- odpowiedni glif
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Opanuj Aspose.Slides dla C++ aby ustawić czcionki zapasowe w plikach PPT, PPTX i ODP, zapewniając spójne wyświetlanie tekstu na dowolnym urządzeniu lub systemie operacyjnym."
---
## **Przegląd**

Aspose.Slides umożliwia określenie czcionek zapasowych do renderowania prezentacji i operacji eksportu. Czcionki zapasowe są używane, gdy podstawowa czcionka nie zawiera glifów dla konkretnych znaków.

Zachowanie czcionek zapasowych konfiguruje się za pomocą reguł zapasowych. Każda reguła wiąże zakres Unicode z jedną lub wieloma czcionkami, które mogą zawierać wymagane glify. Możesz definiować reguły dla różnych zakresów znaków, dodawać lub usuwać czcionki zapasowe z istniejących reguł oraz organizować wiele reguł w kolekcji reguł czcionek zapasowych.

Reguły zapasowe są ustawieniami renderowania w czasie wykonywania. Nie modyfikują samego pliku prezentacji i nie są przechowywane w pliku PPTX.

## **Reguły zapasowe**

Aspose.Slides obsługuje interfejs [IFontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontfallbackrule/) oraz klasę [FontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/), aby określić reguły stosowania czcionki zapasowej. Klasa [FontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/) reprezentuje powiązanie określonego zakresu Unicode, używanego do wyszukiwania brakujących glifów, oraz listy czcionek, które mogą zawierać odpowiednie glify:

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Używając różnych metod możesz dodać listę czcionek:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

Można również [Remove()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontfallbackrule/remove/) czcionkę zapasową lub [AddFallBackFonts()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) w istniejącym obiekcie [FontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrulescollection/) może być użyta do organizowania listy obiektów [FontFallBackRule](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontfallbackrule/), gdy istnieje potrzeba określenia reguł zastępowania czcionek zapasowych dla wielu zakresów Unicode.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/pl/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między czcionką zapasową, zamianą czcionki a osadzaniem czcionki?**

Czcionka zapasowa jest używana tylko dla znaków brakujących w podstawowej czcionce. [Font substitution](/slides/pl/cpp/font-substitution/) zastępuje całą określoną czcionkę inną czcionką. [Font embedding](/slides/pl/cpp/embedded-font/) pakietuje czcionki wewnątrz pliku wyjściowego, aby odbiorcy mogli wyświetlić tekst zgodnie z zamierzeniami.

**Czy czcionki zapasowe są stosowane podczas eksportu, takiego jak PDF, PNG lub SVG, czy tylko podczas renderowania na ekranie?**

Tak. Czcionki zapasowe wpływają na wszystkie [operacje renderowania i eksportu](/slides/pl/cpp/convert-presentation/) gdzie znaki muszą być narysowane, ale nie ma ich w źródłowej czcionce.

**Czy konfigurowanie czcionek zapasowych zmienia sam plik prezentacji i czy ustawienie będzie trwałe przy przyszłych otwarciach?**

Nie. Reguły zapasowe są ustawieniami renderowania w czasie wykonywania w Twoim kodzie; nie są przechowywane w pliku .pptx i nie pojawią się w programie PowerPoint.

**Czy system operacyjny (Windows/Linux/macOS) oraz zestaw katalogów czcionek wpływają na wybór czcionek zapasowych?**

Tak. Silnik wyszukuje czcionki w dostępnych folderach systemowych oraz w dowolnych [dodatkowych ścieżkach](/slides/pl/cpp/custom-font/), które podasz. Jeśli czcionka nie jest fizycznie dostępna, reguła odwołująca się do niej nie może zostać zastosowana.

**Czy czcionki zapasowe działają dla WordArt, SmartArt i wykresów?**

Tak. Gdy te obiekty zawierają tekst, stosowany jest ten sam mechanizm substytucji glifów, aby renderować brakujące znaki.