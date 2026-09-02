---
title: Zarządzanie czcionkami tematu specyficznymi dla skryptu w C++
linktitle: Czcionki tematu specyficzne dla skryptu
type: docs
weight: 15
url: /pl/cpp/script-specific-font-mappings/
keywords:
- czcionka specyficzna dla skryptu
- mapowanie czcionek tematu
- wielojęzyczna prezentacja
- system pisma
- czcionka cyrylicy
- czcionka arabska
- czcionka japońska
- czcionka gruzińska
- czcionka thaana
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Sprawdzaj, dodawaj, zamieniaj i usuwaj mapowania czcionek specyficzne dla skryptu w tematach PowerPoint przy użyciu Aspose.Slides dla C++."
---
## **Przegląd**

Motyw prezentacji może wybierać różne rodziny czcionek dla różnych systemów pisma. Umożliwia to wielojęzyczny tekst, który nadal korzysta z czcionek tematu, zachowując spójny schemat czcionek, a jednocześnie używając odpowiednich czcionek dla cyrylicy, arabskiego, japońskiego, gruzińskiego, thaany i innych skryptów.

[IFontScheme](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/ifontscheme/) tematu zawiera główną kolekcję czcionek, zazwyczaj używaną w nagłówkach, oraz poboczną kolekcję czcionek, zazwyczaj używaną w treści. Oprócz własności czcionek łacińskich i wschodnioazjatyckich, obie kolekcje udostępniają mapowania z tagów systemu pisma na nazwy rodzin czcionek za pośrednictwem interfejsu [IFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifonts/).

Ten artykuł pokazuje, jak przeglądać i modyfikować te mapowania w głównym temacie prezentacji oraz zweryfikować, że zmiany przetrwają cykl zapisu i ponownego wczytania.

## **Zrozumienie znaczników skryptu**

Metody czcionek skryptu używają czteroliterowych podtagów BCP 47, aby identyfikować systemy pisma. Typowe wartości to:

| Znacznik skryptu | System pisma |
|---|---|
| `Cyrl` | Cyrylica |
| `Arab` | Arabski |
| `Hans` | Chiński uproszczony |
| `Jpan` | Japoński |
| `Geor` | Gruziński |
| `Thaa` | Thaana |

Te mapowania należą do schematu czcionek tematu, a nie do poszczególnych fragmentów tekstu. Prezentacja może definiować różne mapowania dla kolekcji głównej i pobocznej oraz może pomijać mapowania dla niektórych skryptów.

## **Dostęp i przeglądanie mapowań czcionek skryptu**

Użyj [Presentation::get_MasterTheme](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_mastertheme/), aby uzyskać dostęp do tematu na poziomie prezentacji. Metody [FontScheme::get_Major](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/fontscheme/get_major/) i [FontScheme::get_Minor](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/fontscheme/get_minor/) zwracają dwie kolekcje [IFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifonts/).

Wywołaj [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fonts/getscriptfontmap/), aby pobrać wszystkie mapowania z kolekcji. Aby odszukać konkretny system pisma, wywołaj [Fonts::GetScriptFont](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fonts/getscriptfont/) z odpowiednim tagiem skryptu. `GetScriptFont` zwraca pusty ciąg, gdy dana kolekcja nie definiuje żądanego mapowania.

## **Modyfikowanie mapowań i weryfikacja trwałości**

Użyj [Fonts::SetScriptFont](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fonts/setscriptfont/), aby utworzyć mapowanie lub zastąpić bieżącą rodzinę czcionek. Użyj [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fonts/removescriptfont/), aby usunąć mapowanie.

Poniższy przykład end‑to‑end odczytuje wszystkie istniejące mapowania główne i poboczne, odszukuje japońską czcionkę główną, zmienia czcionkę cyrylicy głównej, usuwa mapowanie thaany pobocznego, zapisuje prezentację i ponownie ją otwiera, aby zweryfikować oba zmiany. Aby krok usuwania był niezależny od początkowego tematu, przykład najpierw tworzy mapowanie thaany tylko wtedy, gdy nie jest ono już zdefiniowane.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

Weryfikacja używa tego samego zachowania zwracania pustego ciągu co zwykłe odszukiwanie: po zapisaniu usunięcia, `GetScriptFont(u"Thaa")` zwraca pusty ciąg dla kolekcji pobocznej.

## **Rozróżnianie mapowań tematu od innych ustawień czcionek**

Mapowania tematu specyficzne dla skryptu uczestniczą w wyborze czcionki, ale rozwiązują inny problem niż bezpośrednie formatowanie tekstu, podstawianie i fallback:

| Mechanizm | Cel | Skutek zmiany mapowania tematu |
|---|---|---|
| Mapowanie czcionki tematu specyficzne dla skryptu | Wybiera główną lub poboczną czcionkę tematu dla danego systemu pisma. | Tekst, który nadal używa odpowiadającej czcionki tematu, może zostać zmapowany na nową rodzinę. |
| Czcionka przypisana explicite do fragmentu tekstu | Ustawia żądaną rodzinę czcionek na tym fragmencie, zamiast polegać na temacie. | Fragment może pozostać niezmieniony, ponieważ bezpośrednie formatowanie nadpisuje wybór tematu. |
| Podstawianie czcionek | Zastępuje żądaną czcionkę, gdy jest ona niedostępna lub gdy obowiązuje reguła podstawiania. | Działa po żądaniu czcionki; nie redefiniuje mapowania skryptu w temacie. |
| Fallback czcionek | Dostarcza glify, których wybrana czcionka nie zawiera, często dla określonych zakresów Unicode. | Uzupełnia brakujące glify; nie zmienia zapisanego mapowania tematu. |

Po więcej informacji o ostatnich dwóch mechanizmach zobacz [Font Substitution](/slides/pl/cpp/font-substitution/) i [Fallback Fonts](/slides/pl/cpp/fallback-font/).

Zmiana mapowania w [Presentation::get_MasterTheme](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_mastertheme/) wpływa tylko na treść, której efektywne formatowanie nadal zależy od tego tematu. Tekst może zamiast tego dziedziczyć nadpisanie tematu z mastera, układu lub slajdu, albo używać explicite przypisanej czcionki. Sprawdź te poziomy, gdy widoczny wynik nie podąża za mapowaniem na poziomie prezentacji.

## **Udostępnianie mapowanych czcionek i weryfikacja wyniku**

Mapowanie skryptu przechowuje jedynie nazwę rodziny czcionki; nie instalować ani nie ładuje ono odpowiedniego pliku czcionki. Dla spójnego renderowania i eksportu każda mapowana czcionka musi być zainstalowana w środowisku lub dostarczona do Aspose.Slides za pośrednictwem niestandardowego źródła, takiego jak [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontsloader/loadexternalfonts/) lub [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/pl/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/). Zobacz [Custom Fonts](/slides/pl/cpp/custom-font/) po dostępne opcje ładowania.

Weryfikacja zapisanego mapowania potwierdza jedynie, że definicja tematu została zachowana. Nie dowodzi to, że czcionka jest dostępna, zawiera wszystkie wymagane glify ani że generuje zamierzony układ. Wyrenderuj reprezentatywny tekst dla każdego wymaganego systemu pisma do obrazu lub PDF i sprawdź wynik. Dzięki temu wykryjesz brakujące czcionki, niepełne pokrycie glifów, zachowanie fallback oraz zmiany układu przed dystrybucją prezentacji. Zobacz [Convert PowerPoint Presentations](/slides/pl/cpp/convert-powerpoint/) po przykłady renderowania i eksportu.

## **FAQ**

**Co zwraca `GetScriptFont`, gdy skrypt nie jest zamapowany?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fonts/getscriptfont/) zwraca pusty ciąg, gdy żądane mapowanie skryptu nie jest zdefiniowane w danej kolekcji głównej lub pobocznej.

**Czy `SetScriptFont` dodaje drugie mapowanie, gdy skrypt już istnieje?**

Nie. [Fonts::SetScriptFont](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fonts/setscriptfont/) tworzy mapowanie, gdy go brak, i zastępuje istniejącą rodzinę czcionek, gdy ten sam znacznik skryptu jest już obecny.

**Dlaczego zmiana mapowania tematu nie zmieniła niektórego tekstu?**

Tekst może mieć explicite przypisaną czcionkę, dziedziczyć inny temat przez nadpisanie lub być poddany podstawianiu lub fallbackowi podczas renderowania. Mapowanie skryptu na poziomie prezentacji kontroluje wyłącznie tekst, którego efektywne formatowanie nadal odwołuje się do tej kolekcji czcionek tematu.

**Czy zapis i ponowne otwarcie wystarczą do walidacji wielojęzycznego wyjścia?**

Nie. Ponowne otwarcie weryfikuje jedynie trwałość danych tematu. Należy także wyrenderować reprezentatywny tekst z każdego wymaganego systemu pisma, aby potwierdzić dostępność mapowanych czcionek i ich pełne pokrycie glifami.