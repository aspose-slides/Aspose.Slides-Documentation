---
title: Zarządzanie czcionkami motywu specyficznymi dla skryptu w .NET
linktitle: Czcionki motywu specyficzne dla skryptu
type: docs
weight: 15
url: /pl/net/script-specific-font-mappings/
keywords:
- czcionka specyficzna dla skryptu
- mapowanie czcionki motywu
- prezentacja wielojęzyczna
- system pisma
- czcionka cyrylica
- czcionka arabska
- czcionka japońska
- czcionka gruzińska
- czcionka thaana
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przeglądaj, dodawaj, zamieniaj i usuwaj mapowania czcionek specyficznych dla skryptu w motywach PowerPoint przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Motyw prezentacji może wybierać różne rodziny czcionek dla różnych systemów pisma. Umożliwia to wielojęzyczny tekst, który nadal używa czcionek motywu, podążając za jednym skoordynowanym schematem czcionek, jednocześnie używając odpowiednich czcionek dla cyrylicy, arabskiego, japońskiego, gruzińskiego, thaany i innych pism.

Motyw zawiera [IFontScheme](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/ifontscheme/) z główną kolekcją czcionek, zwykle używaną do nagłówków, oraz drugorzędną kolekcją czcionek, zwykle używaną do tekstu głównego. Oprócz ich właściwości czcionek łacińskich i wschodnioazjatyckich, obie kolekcje udostępniają mapowania z tagów systemu pisma na nazwy rodzin czcionek poprzez interfejs [IFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/ifonts/).

Ten artykuł pokazuje, jak przeglądać i modyfikować te mapowania w głównym motywie prezentacji oraz zweryfikować, że zmiany przetrwają cykl zapisu i ponownego wczytania.

## **Zrozumienie tagów skryptów**

Metody czcionek skryptowych używają czteroliterowych subtagów skryptu BCP 47 do identyfikacji systemów pisma. Typowe wartości obejmują:

| Tag skryptu | System pisma |
|---|---|
| `Cyrl` | Cyrylica |
| `Arab` | Arabski |
| `Hans` | Chiński uproszczony |
| `Jpan` | Japoński |
| `Geor` | Gruziński |
| `Thaa` | Thaana |

Te mapowania należą do schematu czcionek motywu, a nie do pojedynczych fragmentów tekstu. Prezentacja może definiować różne mapowania dla głównej i drugorzędnej kolekcji oraz może pomijać mapowania dla niektórych skryptów.

## **Dostęp i przeglądanie mapowań czcionek skryptowych**

Użyj [Presentation.MasterTheme](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/mastertheme/), aby uzyskać dostęp do motywu na poziomie prezentacji. Właściwości [FontScheme.Major](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/fontscheme/major/) i [FontScheme.Minor](https://reference.aspose.com/slides/pl/net/aspose.slides.theme/fontscheme/minor/) zwracają dwie kolekcje [IFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/ifonts/).

Wywołaj [IFonts.GetScriptFontMap](https://reference.aspose.com/slides/pl/net/aspose.slides/fonts/getscriptfontmap/), aby pobrać wszystkie mapowania z kolekcji. Aby wyszukać jeden system pisma, wywołaj [IFonts.GetScriptFont](https://reference.aspose.com/slides/pl/net/aspose.slides/fonts/getscriptfont/) z jego tagiem skryptu. `GetScriptFont` zwraca `null`, gdy ta kolekcja nie definiuje żądanego mapowania.

## **Modyfikacja mapowań i weryfikacja trwałości**

Użyj [IFonts.SetScriptFont](https://reference.aspose.com/slides/pl/net/aspose.slides/fonts/setscriptfont/), aby utworzyć mapowanie lub zastąpić istniejącą rodzinę czcionek. Użyj [IFonts.RemoveScriptFont](https://reference.aspose.com/slides/pl/net/aspose.slides/fonts/removescriptfont/), aby usunąć mapowanie.

Poniższy przykład end‑to‑end odczytuje wszystkie istniejące główne i drugorzędne mapowania, wyszukuje główną czcionkę japońską, zmienia główną czcionkę cyrylicy, usuwa drugorzędne mapowanie Thaana, zapisuje prezentację i otwiera ją ponownie, aby zweryfikować obie zmiany. Aby krok usuwania był niezależny od początkowego motywu, przykład najpierw tworzy mapowanie Thaana tylko wtedy, gdy nie jest jeszcze zdefiniowane.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

Weryfikacja używa takiego samego zachowania `null` jak zwykłe wyszukiwanie: po zapisaniu usunięcia, `GetScriptFont("Thaa")` zwraca `null` dla drugorzędnej kolekcji.

## **Rozróżnienie mapowań motywu od innych ustawień czcionek**

Mapowania motywu specyficzne dla skryptu uczestniczą w wyborze czcionki, ale rozwiązują inny problem niż bezpośrednie formatowanie tekstu, substytucja i fallback:

| Mechanizm | Cel | Efekt zmiany mapowania motywu |
|---|---|---|
| Mapowanie czcionki motywu specyficzne dla skryptu | Wybiera główną lub drugorzędną czcionkę motywu dla systemu pisma. | Tekst, który nadal używa odpowiadającej czcionki motywu, może zostać przypisany do nowej zmapowanej rodziny. |
| Czcionka przypisana wyraźnie do fragmentu tekstu | Ustala żądaną rodzinę czcionek dla tego fragmentu zamiast polegać na motywie. | Fragment może pozostać niezmieniony, ponieważ jego bezpośrednie formatowanie nadpisuje wybór motywu. |
| Substytucja czcionek | Zastępuje żądaną czcionkę, gdy nie jest dostępna lub gdy obowiązuje reguła substytucji. | Działa po żądaniu czcionki; nie redefiniuje mapowania skryptu w motywie. |
| Zapasowa czcionka (fallback) | Dostarcza glify, których wybrana czcionka nie zawiera, często dla określonych zakresów Unicode. | Uzupełnia brakujące glify; nie zmienia zapisanego mapowania motywu. |

Aby uzyskać więcej informacji o ostatnich dwóch mechanizmach, zobacz [Font Substitution](/slides/pl/net/font-substitution/) i [Fallback Fonts](/slides/pl/net/fallback-font/).

Zmiana mapowania w [Presentation.MasterTheme](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/mastertheme/) wpływa tylko na treść, której efektywne formatowanie nadal zależy od tego motywu. Tekst może zamiast tego dziedziczyć nadpisanie motywu z mastera, układu lub slajdu, lub używać wyraźnie przypisanej czcionki. Sprawdź te poziomy, gdy widoczny wynik nie podąża za mapowaniem na poziomie prezentacji.

## **Udostępnienie zmapowanych czcionek i walidacja wyniku**

Mapowanie skryptu przechowuje nazwę rodziny czcionek; nie instaluje ani nie ładuje odpowiadającego pliku czcionki. Aby zapewnić spójne renderowanie i eksport, każda zmapowana czcionka musi być zainstalowana w środowisku lub dostarczona do Aspose.Slides za pomocą własnego źródła, takiego jak [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsloader/loadexternalfonts/) lub [LoadOptions.DocumentLevelFontSources](https://reference.aspose.com/slides/pl/net/aspose.slides/loadoptions/documentlevelfontsources/). Zobacz [Custom Fonts](/slides/pl/net/custom-font/) aby poznać dostępne opcje ładowania.

Weryfikacja zapisanego mapowania potwierdza jedynie, że definicja motywu została zachowana. Nie dowodzi, że czcionka jest dostępna, zawiera wszystkie wymagane glify lub generuje zamierzony układ. Wyrenderuj reprezentatywny tekst dla każdego wymaganego systemu pisma do obrazu lub PDF i sprawdź wynik. To wykrywa brakujące czcionki, niekompletną pokrywalność glifów, zachowanie fallback oraz zmiany układu przed dystrybucją prezentacji. Zobacz [Convert PowerPoint Presentations](/slides/pl/net/convert-powerpoint/) aby uzyskać przykłady renderowania i eksportu.

## **FAQ**

**Co zwraca `GetScriptFont`, gdy skrypt nie jest zmapowany?**

`[IFonts.GetScriptFont](https://reference.aspose.com/slides/pl/net/aspose.slides/fonts/getscriptfont/)` zwraca `null`, gdy żądane mapowanie skryptu nie jest zdefiniowane w tej głównej lub drugorzędnej kolekcji czcionek.

**Czy `SetScriptFont` dodaje drugie mapowanie, gdy skrypt już istnieje?**

Nie. `[IFonts.SetScriptFont](https://reference.aspose.com/slides/pl/net/aspose.slides/fonts/setscriptfont/)` tworzy mapowanie, gdy brak, i zastępuje zmapowaną rodzinę czcionek, gdy ten sam tag skryptu już istnieje.

**Dlaczego zmiana mapowania motywu nie zmieniła niektórych tekstów?**

Tekst może mieć wyraźnie przypisaną czcionkę, dziedziczyć inny motyw poprzez nadpisanie lub być wpływany przez substytucję lub fallback podczas renderowania. Mapowanie skryptu na poziomie prezentacji kontroluje tylko tekst, którego efektywne formatowanie nadal odwołuje się do tej kolekcji czcionek motywu.

**Czy zapis i ponowne otwarcie wystarczą, aby zweryfikować wielojęzyczny wynik?**

Nie. Ponowne otwarcie weryfikuje trwałość danych motywu. Należy także wyrenderować reprezentatywny tekst z każdego wymaganego systemu pisma, aby potwierdzić, że zmapowane czcionki są dostępne i zawierają niezbędne glify.