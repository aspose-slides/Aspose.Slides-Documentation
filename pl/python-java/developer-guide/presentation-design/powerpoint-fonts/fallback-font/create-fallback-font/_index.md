---
title: Określ czcionki zastępcze dla prezentacji w Python via Java
linktitle: Czcionka zastępcza
type: docs
weight: 10
url: /pl/python-java/create-fallback-font/
keywords:
- czcionka zastępcza
- reguła zastępcza
- zastosuj czcionkę
- zamień czcionkę
- zakres Unicode
- brakujący glif
- prawidłowy glif
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Opanuj Aspose.Slides dla Pythona via Java, aby ustawiać czcionki zastępcze w plikach PPT, PPTX i ODP, zapewniając spójne wyświetlanie tekstu na każdym urządzeniu lub systemie operacyjnym."
---
## **Przegląd**

Aspose.Slides umożliwia określenie czcionek zastępczych dla renderowania prezentacji i operacji eksportu. Czcionki zastępcze są używane, gdy główna czcionka nie zawiera glifów dla określonych znaków.

Zachowanie czcionek zastępczych konfiguruje się za pomocą reguł zastępczych. Każda reguła wiąże zakres Unicode z jedną lub większą liczbą czcionek, które mogą zawierać wymagane glify. Możesz definiować reguły dla różnych zakresów znaków, dodawać lub usuwać czcionki zastępcze z istniejących reguł oraz organizować wiele reguł w kolekcji reguł czcionek zastępczych.

Reguły zastępcze są ustawieniami renderowania w czasie wykonywania. Nie modyfikują samego pliku prezentacji i nie są przechowywane w pliku PPTX.

## **Reguły zastępcze**

Aspose.Slides udostępnia klasę [FontFallBackRule](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontfallbackrule/) , służącą do określania reguł stosowania czcionek zastępczych. Klasa ta reprezentuje powiązanie zakresu Unicode używanego do wyszukiwania brakujących glifów z listą czcionek, które mogą zawierać wymagane glify:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# Użyj wielu sposobów, aby określić listę czcionek.
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

Możesz również usunąć czcionkę zastępczą przy użyciu [remove](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontfallbackrule/#remove) lub dodać czcionki zastępcze przy użyciu [addFallBackFonts](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) w istniejącym obiekcie [FontFallBackRule](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontfallbackrule/).

[FontFallBackRulesCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontfallbackrulescollection/) może organizować listę obiektów [FontFallBackRule](https://reference.aspose.com/slides/pl/python-java/aspose.slides/fontfallbackrule/), gdy potrzebujesz określić reguły zamiany czcionek zastępczych dla wielu zakresów Unicode.

{{% alert color="info" title="Zobacz także" %}} 
- [Utwórz kolekcję czcionek zastępczych](/slides/pl/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **FAQ**

**Jaka jest różnica między czcionką zastępczą, podstawianiem czcionki a osadzaniem czcionki?**

Czcionka zastępcza jest używana wyłącznie dla znaków brakujących w głównej czcionce. [Font substitution](/slides/pl/python-java/font-substitution/) zastępuje całą określoną czcionkę inną czcionką. [Font embedding](/slides/pl/python-java/embedded-font/) umieszcza czcionki w pliku wyjściowym, aby odbiorcy mogli wyświetlać tekst zgodnie z zamierzeniem.

**Czy czcionki zastępcze są stosowane podczas eksportu, takiego jak PDF, PNG lub SVG, czy tylko podczas renderowania na ekranie?**

Tak. Czcionki zastępcze wpływają na wszystkie [operacje renderowania i eksportu](/slides/pl/python-java/convert-presentation/), w których znaki muszą zostać narysowane, ale nie ma ich w czcionce źródłowej.

**Czy konfigurowanie czcionek zastępczych zmienia sam plik prezentacji i czy ustawienie będzie utrzymywane przy kolejnych otwarciach?**

Nie. Reguły zastępcze są ustawieniami renderowania w czasie wykonywania w Twoim kodzie; nie są przechowywane w pliku .pptx i nie pojawią się w programie PowerPoint.

**Czy system operacyjny (Windows/Linux/macOS) oraz zestaw katalogów czcionek wpływają na wybór czcionek zastępczych?**

Tak. Silnik wyszukuje czcionki w dostępnych folderach systemowych oraz w [dodatkowych ścieżkach](/slides/pl/python-java/custom-font/), które podasz. Jeśli czcionka nie jest fizycznie dostępna, reguła odwołująca się do niej nie może zostać zastosowana.

**Czy czcionki zastępcze działają dla WordArt, SmartArt i wykresów?**

Tak. Gdy te obiekty zawierają tekst, stosowany jest ten sam mechanizm podstawiania glifów, aby renderować brakujące znaki.