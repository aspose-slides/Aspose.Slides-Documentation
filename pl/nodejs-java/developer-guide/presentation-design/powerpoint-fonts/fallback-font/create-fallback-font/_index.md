---
title: Określanie czcionek zastępczych w prezentacjach w JavaScript
linktitle: Czcionka zastępcza
type: docs
weight: 10
url: /pl/nodejs-java/create-fallback-font/
keywords:
  - czcionka zastępcza
  - reguła zastępcza
  - zastosowanie czcionki
  - zastąpienie czcionki
  - zakres Unicode
  - brakujący glif
  - odpowiedni glif
  - PowerPoint
  - OpenDocument
  - prezentacja
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Opanuj Aspose.Slides dla Node.js, aby ustawiać czcionki zastępcze w plikach PPT, PPTX i ODP w JavaScript, zapewniając spójne wyświetlanie tekstu na każdym urządzeniu i systemie operacyjnym."
---
## **Przegląd**

Aspose.Slides umożliwia określenie czcionek zastępczych do renderowania prezentacji i operacji eksportu. Czcionki zastępcze są używane, gdy podstawowa czcionka nie zawiera glifów dla określonych znaków.

Zachowanie czcionek zastępczych konfigurowane jest za pomocą reguł zastępczych. Każda reguła łączy zakres Unicode z jedną lub większą liczbą czcionek, które mogą zawierać wymagane glify. Możesz definiować reguły dla różnych zakresów znaków, dodawać lub usuwać czcionki zastępcze z istniejących reguł oraz organizować wiele reguł w kolekcji reguł czcionek zastępczych.

Reguły zastępcze są ustawieniami renderowania w czasie wykonywania. Nie modyfikują samego pliku prezentacji i nie są przechowywane w pliku PPTX.

## **Reguły zastępcze**

Biblioteka Aspose.Slides obsługuje klasę [FontFallBackRule](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontFallBackRule) do określenia reguł stosowania czcionki zastępczej. Klasa [FontFallBackRule](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontFallBackRule) reprezentuje powiązanie określonego zakresu Unicode, używanego do wyszukiwania brakujących glifów, z listą czcionek, które mogą zawierać właściwe glify:

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// Korzystając z wielu sposobów, możesz dodać listę czcionek:
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

Można również [remove](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) czcionkę zastępczą lub [addFallBackFonts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) w istniejącym obiekcie [FontFallBackRule](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontFallBackRule).

Kolekcja [FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontFallBackRulesCollection) może być używana do organizowania listy obiektów [FontFallBackRule](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/FontFallBackRule), gdy istnieje potrzeba określenia reguł zastępowania czcionek zastępczych dla wielu zakresów Unicode.

{{% alert color="primary" title="See also" %}} 
- [Utwórz kolekcję czcionek zastępczych](/slides/pl/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między czcionką zastępczą, zamianą czcionki a osadzaniem czcionki?**

Czcionka zastępcza jest używana wyłącznie dla znaków brakujących w podstawowej czcionce. [Zamiana czcionki](/slides/pl/nodejs-java/font-substitution/) zastępuje całą określoną czcionkę inną czcionką. [Osadzanie czcionki](/slides/pl/nodejs-java/embedded-font/) pakietuje czcionki wewnątrz pliku wyjściowego, aby odbiorcy mogli wyświetlić tekst zgodnie z zamierzeniami.

**Czy czcionki zastępcze są stosowane podczas eksportu, takiego jak PDF, PNG lub SVG, czy tylko przy renderowaniu na ekranie?**

Tak. Czcionki zastępcze wpływają na wszystkie [operacje renderowania i eksportu](/slides/pl/nodejs-java/convert-presentation/), w których znaki muszą być rysowane, ale nie ma ich w źródłowej czcionce.

**Czy konfigurowanie czcionek zastępczych zmienia sam plik prezentacji i czy ustawienie będzie utrzymywać się przy kolejnych otwarciach?**

Nie. Reguły zastępcze są ustawieniami renderowania w czasie wykonywania w Twoim kodzie; nie są przechowywane w pliku .pptx i nie pojawią się w programie PowerPoint.

**Czy system operacyjny (Windows/Linux/macOS) oraz zestaw katalogów czcionek wpływają na wybór czcionek zastępczych?**

Tak. Silnik wyszukuje czcionki w dostępnych folderach systemowych oraz w wszelkich [dodatkowe ścieżki](/slides/pl/nodejs-java/custom-font/) które podasz. Jeśli czcionka nie jest fizycznie dostępna, reguła odwołująca się do niej nie może zostać zastosowana.

**Czy czcionki zastępcze działają dla WordArt, SmartArt i wykresów?**

Tak. Gdy te obiekty zawierają tekst, stosowany jest ten sam mechanizm podstawiania glifów do renderowania brakujących znaków.