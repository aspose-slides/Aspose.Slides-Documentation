---
title: Określ czcionki awaryjne dla prezentacji w .NET
linktitle: Czcionka awaryjna
type: docs
weight: 10
url: /pl/net/create-fallback-font/
keywords:
- czcionka awaryjna
- reguła awaryjna
- zastosowanie czcionki
- zastąpienie czcionki
- zakres Unicode
- brakujący glif
- odpowiedni glif
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Opanuj Aspose.Slides dla .NET, aby ustawić czcionki awaryjne w plikach PPT, PPTX i ODP, zapewniając spójne wyświetlanie tekstu na każdym urządzeniu lub systemie operacyjnym."
---
## **Przegląd**

Aspose.Slides umożliwia określenie czcionek awaryjnych (fallback) dla renderowania prezentacji i operacji eksportu. Czcionki awaryjne są używane, gdy podstawowa czcionka nie zawiera glifów dla konkretnych znaków.

Zachowanie awaryjne konfiguruje się za pomocą reguł awaryjnych. Każda reguła wiąże zakres Unicode z jedną lub większą liczbą czcionek, które mogą zawierać wymagane glify. Można definiować reguły dla różnych zakresów znaków, dodawać lub usuwać czcionki awaryjne w istniejących regułach oraz organizować wiele reguł w kolekcji reguł czcionek awaryjnych.

Reguły awaryjne są ustawieniami renderowania w czasie wykonywania. Nie modyfikują samego pliku prezentacji i nie są przechowywane wewnątrz pliku PPTX.

## **Reguły awaryjne**

Aspose.Slides obsługuje interfejs [IFontFallBackRule](https://reference.aspose.com/slides/pl/net/aspose.slides/iFontFallBackRule) oraz klasę [FontFallBackRule](https://reference.aspose.com/slides/pl/net/aspose.slides/FontFallBackRule), aby określić reguły stosowania czcionki awaryjnej. Klasa [FontFallBackRule](https://reference.aspose.com/slides/pl/net/aspose.slides/FontFallBackRule) reprezentuje powiązanie określonego zakresu Unicode, używanego do wyszukiwania brakujących glifów, oraz listy czcionek, które mogą zawierać właściwe glify:

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//Używając różnych sposobów, możesz dodać listę czcionek:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

Możliwe jest również [Remove()](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontfallbackrule/methods/remove) czcionkę awaryjną lub [AddFallBackFonts()](https://reference.aspose.com/slides/pl/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) w istniejącym obiekcie [FontFallBackRule](https://reference.aspose.com/slides/pl/net/aspose.slides/FontFallBackRule).

Kolekcję [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/fontfallbackrulescollection) można użyć do organizowania listy obiektów [FontFallBackRule](https://reference.aspose.com/slides/pl/net/aspose.slides/FontFallBackRule), gdy istnieje potrzeba określenia reguł zastępowania czcionek awaryjnych dla wielu zakresów Unicode.

{{% alert color="info" title="Zobacz także" %}} 
- [Utwórz kolekcję czcionek awaryjnych](/slides/pl/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

### Jaka jest różnica między czcionką awaryjną, substytucją czcionki a osadzaniem czcionki?

Czcionka awaryjna jest używana tylko dla znaków brakujących w podstawowej czcionce. [Font substitution](/slides/pl/net/font-substitution/) zastępuje całą określoną czcionkę inną czcionką. [Font embedding](/slides/pl/net/embedded-font/) pakuje czcionki wewnątrz pliku wyjściowego, aby odbiorcy mogli zobaczyć tekst zgodnie z zamierzeniem.

### Czy czcionki awaryjne są stosowane podczas eksportu, takiego jak PDF, PNG lub SVG, czy tylko podczas renderowania na ekranie?

Tak. Czcionki awaryjne wpływają na wszystkie [operacje renderowania i eksportu](/slides/pl/net/convert-presentation/), w których znaki muszą być rysowane, a w źródłowej czcionce ich brakuje.

### Czy konfigurowanie czcionek awaryjnych zmienia sam plik prezentacji i czy ustawienie będzie utrzymywane przy kolejnych otwarciach?

Nie. Reguły awaryjne są ustawieniami renderowania w czasie wykonywania w Twoim kodzie; nie są przechowywane w pliku .pptx i nie pojawią się w programie PowerPoint.

### Czy system operacyjny (Windows/Linux/macOS) oraz zestaw katalogów czcionek wpływają na wybór czcionki awaryjnej?

Tak. Silnik wyszukuje czcionki w dostępnych folderach systemowych oraz we wszelkich [dodatkowych ścieżkach](/slides/pl/net/custom-font/), które podasz. Jeśli czcionka nie jest fizycznie dostępna, reguła odwołująca się do niej nie może zostać zastosowana.

### Czy czcionki awaryjne działają dla WordArt, SmartArt i wykresów?

Tak. Gdy te obiekty zawierają tekst, stosowany jest ten sam mechanizm podmiany glifów do renderowania brakujących znaków.