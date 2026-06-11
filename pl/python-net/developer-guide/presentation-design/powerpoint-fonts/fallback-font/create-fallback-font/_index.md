---
title: Określ czcionki zapasowe dla prezentacji w Pythonie
linktitle: Czcionka zapasowa
type: docs
weight: 10
url: /pl/python-net/create-fallback-font/
keywords:
- czcionka zapasowa
- reguła zapasowa
- zastosowanie czcionki
- zamiana czcionki
- zakres Unicode
- brakujący glif
- odpowiedni glif
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Opanuj Aspose.Slides dla Pythona poprzez .NET, aby ustawiać czcionki zapasowe w plikach PPT, PPTX i ODP, zapewniając spójne wyświetlanie tekstu na każdym urządzeniu lub systemie operacyjnym."
---
## **Przegląd**

Aspose.Slides pozwala określić czcionki zapasowe do renderowania prezentacji i operacji eksportu. Czcionki zapasowe są używane, gdy czcionka podstawowa nie zawiera glifów dla konkretnych znaków.

Zachowanie czcionek zapasowych jest konfigurowane za pomocą reguł zapasowych. Każda reguła wiąże zakres Unicode z jedną lub wieloma czcionkami, które mogą zawierać wymagane glify. Możesz definiować reguły dla różnych zakresów znaków, dodawać lub usuwać czcionki zapasowe z istniejących reguł oraz organizować wiele reguł w kolekcji reguł czcionek zapasowych.

Reguły zapasowe są ustawieniami renderowania w czasie wykonywania. Nie modyfikują samego pliku prezentacji i nie są przechowywane w pliku PPTX.

## **Określanie czcionek zapasowych**

Aspose.Slides obsługuje klasę [FontFallBackRule](https://reference.aspose.com/slides/pl/python-net/aspose.slides/FontFallBackRule/) do określania reguł stosowania czcionki zapasowej. Klasa [FontFallBackRule](https://reference.aspose.com/slides/pl/python-net/aspose.slides/FontFallBackRule/) reprezentuje powiązanie pomiędzy określonym zakresem Unicode, używanym do wyszukiwania brakujących glifów, a listą czcionek, które mogą zawierać odpowiednie glify:

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#Używając różnych metod możesz dodać listę czcionek:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```

Możliwe jest również [usunięcie](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontfallbackrule/remove/) czcionki zapasowej lub [add_fall_back_fonts](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) w istniejącym obiekcie [FontFallBackRule](https://reference.aspose.com/slides/pl/python-net/aspose.slides/FontFallBackRule/).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/fontfallbackrulescollection/) może być użyta do organizowania listy obiektów [FontFallBackRule](https://reference.aspose.com/slides/pl/python-net/aspose.slides/FontFallBackRule/), gdy istnieje potrzeba określenia reguł zastępowania czcionek zapasowych dla wielu zakresów Unicode.

{{% alert color="primary" title="Zobacz także" %}} 
- [Utwórz kolekcję czcionek zapasowych](/slides/pl/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między czcionką zapasową, podstawianiem czcionki a osadzaniem czcionki?**

Czcionka zapasowa jest używana wyłącznie dla znaków brakujących w czcionce podstawowej. [Font substitution](/slides/pl/python-net/font-substitution/) zastępuje całą określoną czcionkę inną czcionką. [Font embedding](/slides/pl/python-net/embedded-font/) pakietuje czcionki wewnątrz pliku wyjściowego, dzięki czemu odbiorcy mogą wyświetlać tekst zgodnie z zamierzeniem.

**Czy czcionki zapasowe są stosowane podczas eksportu, takiego jak PDF, PNG lub SVG, czy tylko podczas renderowania na ekranie?**

Tak. Czcionki zapasowe wpływają na wszystkie [renderowanie i operacje eksportu](/slides/pl/python-net/convert-presentation/), gdzie znaki muszą zostać narysowane, ale nie ma ich w czcionce źródłowej.

**Czy konfigurowanie czcionek zapasowych zmienia sam plik prezentacji i czy ustawienie będzie zachowane przy przyszłych otwarciach?**

Nie. Reguły zapasowe są ustawieniami renderowania w czasie wykonywania w Twoim kodzie; nie są przechowywane w pliku .pptx i nie pojawią się w programie PowerPoint.

**Czy system operacyjny (Windows/Linux/macOS) oraz zestaw katalogów czcionek wpływają na wybór czcionek zapasowych?**

Tak. Silnik wyszukuje czcionki w dostępnych folderach systemowych oraz w dowolnych [dodatkowych ścieżkach](/slides/pl/python-net/custom-font/), które podasz. Jeśli czcionka nie jest fizycznie dostępna, reguła odwołująca się do niej nie może zostać zastosowana.

**Czy czcionki zapasowe działają dla WordArt, SmartArt i wykresów?**

Tak. Gdy te obiekty zawierają tekst, stosowany jest ten sam mechanizm zastępowania glifów, aby renderować brakujące znaki.