---
title: Określenie czcionek zastępczych dla prezentacji w .NET
linktitle: Czcionka zastępcza
type: docs
weight: 10
url: /pl/net/create-fallback-font/
keywords:
- czcionka zastępcza
- reguła zastępowania
- zastosować czcionkę
- zamienić czcionkę
- zakres Unicode
- brakujący glif
- właściwy glif
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Opanuj Aspose.Slides dla .NET, aby ustawić czcionki zastępcze w plikach PPT, PPTX i ODP, zapewniając spójne wyświetlanie tekstu na każdym urządzeniu lub systemie operacyjnym."
---
## **Przegląd**

Aspose.Slides umożliwia określenie czcionek zastępczych dla renderowania prezentacji i operacji eksportu. Czcionki zastępcze są używane, gdy podstawowa czcionka nie zawiera glifów dla określonych znaków.

Zachowanie zastępcze konfigurowane jest za pomocą reguł zastępowania. Każda reguła łączy zakres Unicode z jedną lub większą liczbą czcionek, które mogą zawierać wymagane glify. Można definiować reguły dla różnych zakresów znaków, dodawać lub usuwać czcionki zastępcze w istniejących regułach oraz organizować wiele reguł w kolekcji reguł czcionek zastępczych.

Reguły zastępowania są ustawieniami renderowania w czasie wykonywania. Nie modyfikują samego pliku prezentacji i nie są przechowywane wewnątrz pliku PPTX.

## **Reguły zastępowania**

Aspose.Slides obsługuje interfejs [IFontFallBackRule](https://reference.aspose.com/slides/pl/net/aspose.slides/iFontFallBackRule) oraz klasę [FontFallBackRule](https://reference.aspose.com/slides/pl/net/aspose.slides/FontFallBackRule), aby określić reguły stosowania czcionki zastępczej. Klasa [FontFallBackRule](https://reference.aspose.com/slides/pl/net/aspose.slides/FontFallBackRule) reprezentuje powiązanie określonego zakresu Unicode, używanego do wyszukiwania brakujących glifów, oraz listy czcionek, które mogą zawierać odpowiednie glify:

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Używając różnych sposobów, możesz dodać listę czcionek:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Możliwe jest również [Remove()](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontfallbackrule/methods/remove) czcionki zastępczej lub [AddFallBackFonts()](https://reference.aspose.com/slides/pl/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) w istniejącym obiekcie [FontFallBackRule](https://reference.aspose.com/slides/pl/net/aspose.slides/FontFallBackRule).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/pl/net/aspose.slides/fontfallbackrulescollection) może być używana do organizowania listy obiektów [FontFallBackRule](https://reference.aspose.com/slides/pl/net/aspose.slides/FontFallBackRule), gdy zachodzi potrzeba określenia reguł zastępowania czcionek dla wielu zakresów Unicode.

{{% alert color="primary" title="See also" %}} 
- [Create Fallback Fonts Collection](/slides/pl/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między czcionką zastępczą, podstawianiem czcionki a osadzaniem czcionki?**

Czcionka zastępcza jest używana wyłącznie dla znaków brakujących w podstawowej czcionce. [Podstawianie czcionki](/slides/pl/net/font-substitution/) zastępuje całą określoną czcionkę inną czcionką. [Osadzanie czcionki](/slides/pl/net/embedded-font/) umieszcza czcionki wewnątrz pliku wyjściowego, aby odbiorcy mogli zobaczyć tekst zgodnie z zamierzeniem.

**Czy czcionki zastępcze są stosowane podczas eksportu, takiego jak PDF, PNG lub SVG, czy tylko podczas renderowania na ekranie?**

Tak. Zastępowanie wpływa na wszystkie [operacje renderowania i eksportu](/slides/pl/net/convert-presentation/), w których znaki muszą być narysowane, ale nie są obecne w źródłowej czcionce.

**Czy konfigurowanie zastępowania zmienia sam plik prezentacji i czy ustawienie będzie trwałe przy kolejnych otwarciach?**

Nie. Reguły zastępowania są ustawieniami renderowania w czasie wykonywania w kodzie; nie są przechowywane wewnątrz pliku .pptx i nie pojawią się w programie PowerPoint.

**Czy system operacyjny (Windows/Linux/macOS) i zestaw katalogów czcionek wpływają na wybór czcionek zastępczych?**

Tak. Silnik rozwiązuje czcionki z dostępnych folderów systemowych oraz z [dodatkowych ścieżek](/slides/pl/net/custom-font/), które podasz. Jeśli czcionka nie jest fizycznie dostępna, reguła odwołująca się do niej nie może zostać zastosowana.

**Czy zastępowanie działa dla WordArt, SmartArt i wykresów?**

Tak. Gdy te obiekty zawierają tekst, stosowany jest ten sam mechanizm podstawiania glifów w celu renderowania brakujących znaków.