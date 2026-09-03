---
title: Osadzanie czcionek w prezentacjach w C++
linktitle: Osadzone czcionki
type: docs
weight: 40
url: /pl/cpp/embedded-font/
keywords:
- dodaj czcionkę
- osadź czcionkę
- osadzanie czcionki
- pobierz osadzoną czcionkę
- dodaj osadzoną czcionkę
- usuń osadzoną czcionkę
- kompresuj osadzoną czcionkę
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj osadzonymi czcionkami w PowerPoint przy użyciu Aspose.Slides dla C++. Dodawaj, pobieraj, usuwaj i kompresuj czcionki, aby zachować wygląd tekstu i zmniejszyć rozmiar pliku."
---
## **Wprowadzenie**

Osadzanie czcionek zapisuje dane czcionki wewnątrz prezentacji PowerPoint. Gdy przeglądarka obsługuje osadzone czcionki, może wyświetlać tekst przy użyciu tych czcionek, nawet jeśli nie są one zainstalowane w docelowym systemie. Pomaga to zachować podziały linii, odstępy tekstu i układ slajdów.

Aspose.Slides for C++ umożliwia pobieranie, dodawanie i usuwanie osadzonych czcionek za pośrednictwem metody [Presentation::get_FontsManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_fontsmanager/) klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/). Można także zmniejszyć rozmiar danych osadzonych czcionek, usuwając znaki, których prezentacja nie używa.

Poniższe przykłady działają na plikach PPTX. Przed osadzeniem czcionki upewnij się, że jej dane są dostępne dla Aspose.Slides i że jej licencja zezwala na osadzanie.

## **Pobieranie i usuwanie osadzonych czcionek**

Użyj [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) aby wyświetlić listę czcionek zapisanych w prezentacji. Aby usunąć jedną z nich, przekaż czcionkę z tej listy do [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontsmanager/removeembeddedfont/), a następnie zapisz prezentację.

Poniższy przykład wyświetla osadzone czcionki w pliku `EmbeddedFonts.pptx` i usuwa Calibri, jeśli jest obecna:
```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

Usunięcie osadzonej czcionki usuwa jej zapisane dane; nie zmienia to czcionki przypisanej do tekstu. Jeśli czcionka jest zainstalowana w docelowym systemie, tekst nadal może jej używać. W przeciwnym razie renderowanie może wymagać [substitucji czcionek](/slides/pl/cpp/font-substitution/), co może wpłynąć na układ.

## **Sprawdzanie danych czcionki i uprawnień do osadzania**

Użyj interfejsu [IFontsManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontsmanager/) do sprawdzenia czcionek przed ich osadzeniem. Wywołaj [IFontsManager::GetFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontsmanager/getfonts/), aby pobrać czcionki użyte w prezentacji. Dla każdej czcionki przekaż obiekt [IFontData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontdata/) oraz wymaganą wartość [FontStyleType](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fontstyletype/) do [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontsmanager/getfontbytes/). Metoda zwraca dane binarne dla tego stylu czcionki lub `nullptr`, gdy żądana czcionka lub styl jest niedostępny. Nie przekazuj wyniku `nullptr` do [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/), ponieważ ta metoda wymaga tablicy bajtów.

[EmbeddingLevel](https://reference.aspose.com/slides/pl/cpp/aspose.slides/embeddinglevel/) jest wyliczeniem flag, które raportuje ograniczenia osadzania zapisane w czcionce:

- `Installable` zezwala na osadzanie i trwałą instalację w innym systemie, zgodnie z licencją czcionki.
- `Restricted` zabrania osadzania, chyba że uzyskano pozwolenie od prawowitego właściciela czcionki, gdy jest jedyną flagą uprawnienia do użycia.
- `PreviewPrint` zezwala na tymczasowe użycie do podglądu i drukowania; dokument zawierający czcionkę musi być tylko do odczytu.
- `Editable` zezwala na tymczasowe użycie oraz umożliwia edycję i zapis dokumentu.
- `NoSubsetting` jest dodatkowym ograniczeniem, które zabrania osadzania tylko podzbioru glifów. Gdy ta flaga jest obecna, osadzaj wszystkie znaki.
- `BitmapOnly` jest dodatkowym ograniczeniem, które pozwala na osadzanie tylko bitmapowych wersji czcionki, a nie danych konturów. Jeśli czcionka nie posiada bitmapowych wersji, nie może być osadzona.

Pierwsze cztery wartości opisują zezwolenie na użycie, podczas gdy `NoSubsetting` i `BitmapOnly` mogą być z nimi łączone. Sprawdzaj modyfikatory za pomocą operacji bitowych. Ponieważ `Installable` ma wartość zero, maskuj bity zezwolenia na użycie i porównaj wynik z `Installable`. Aktualne czcionki powinny ustawiać co najwyżej jeden bit zezwolenia na użycie. Dla zachowania zgodności ze starszymi czcionkami, które ustawiają więcej niż jeden, poniższy pomocniczy wybiera najmniej restrykcyjne zezwolenie: `Editable`, potem `PreviewPrint`, potem `Restricted`.

Poniższy przykład audytuje dane zwykłe, pogrubione, pochylone i pogrubiono‑pochyłe dostępne dla każdej czcionki zwróconej przez `GetFonts`. Pomija style niedostępne, czcionki ograniczone, czcionki tylko bitmapowe, czcionki ograniczone do podglądu i druku, ponieważ wynik pozostaje edytowalny, oraz czcionki już osadzone. Jeśli jakikolwiek dostępny styl ma `NoSubsetting`, osadza wszystkie znaki dla tej rodziny czcionek.
```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

To sprawdzenie raportuje ograniczenia zakodowane w każdym pliku czcionki. Nie przyznaje licencji, nie dowodzi, że czcionka została uzyskana legalnie, ani nie zastępuje weryfikacji umowy licencyjnej czcionki przed rozpowszechnieniem jej osadzonej kopii.

## **Dodawanie osadzonych czcionek**

Użyj [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontsmanager/addembeddedfont/) aby osadzić czcionkę. Jego przeciążenia przyjmują albo obiekt [IFontData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontdata/), albo tablicę bajtów zawierającą dane czcionki. Wyliczenie [EmbedFontCharacters](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/embedfontcharacters/) określa, które znaki zostaną uwzględnione:

- [All](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/embedfontcharacters/) osadza wszystkie znaki w czcionce. Użyj tej opcji, gdy odbiorcy muszą edytować prezentację i wprowadzać nowy tekst.
- [OnlyUsed](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/embedfontcharacters/) osadza tylko znaki użyte w prezentacji, aby zmniejszyć rozmiar pliku. Wybierz tę opcję dla gotowej prezentacji przeznaczonej głównie do podglądu.

Poniższy przykład używa [IFontsManager::GetFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontsmanager/getfonts/) aby pobrać czcionki użyte w `Fonts.pptx` i osadzić te, które nie są jeszcze osadzone. Czcionki do dodania muszą być dostępne na maszynie uruchamiającej kod. Istniejące osadzone czcionki zachowują swoje bieżące zestawy znaków.
```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Kompresowanie osadzonych czcionek**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/pl/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) zmniejsza dane osadzonych czcionek, usuwając nieużywane znaki. Działa na czcionkach już osadzonych, więc redukcja rozmiaru zależy od ilości nieużywanych danych czcionki w prezentacji.

Poniższy przykład kompresuje czcionki w pliku `EmbeddedFonts.pptx` i zapisuje wynik jako osobny plik:
```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Zachowaj oryginalny plik, jeśli odbiorcy mogą potrzebować dodać tekst później. Znaki usunięte podczas kompresji nie są już dostępne w osadzonej czcionce, nawet jeśli pierwotnie osadzono wszystkie znaki.

## **FAQ**

**Jak mogę sprawdzić, czy osadzona czcionka będzie nadal podstawiana podczas renderowania?**

Wywołaj [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifontsmanager/getsubstitutions/) w środowisku, w którym renderujesz prezentację, aby zobaczyć, które czcionki Aspose.Slides zastąpi. Sprawdź także ustawienia [substitucji czcionek](/slides/pl/cpp/font-substitution/) oraz zasady [fallback czcionek](/slides/pl/cpp/fallback-font/). Fallback obsługuje brakujące znaki, więc osadzenie czcionki nie rozwiązuje znaków, których sama czcionka nie zawiera.

**Czy powinienem osadzać popularne czcionki, takie jak Arial i Calibri?**

Decyzję należy podejmować w oparciu o docelowe środowisko. Jeśli wymagane czcionki są dostępne na każdym komputerze, który otwiera lub renderuje prezentację, ich osadzanie może zwiększyć niepotrzebnie rozmiar pliku. Jeśli odbiorcy lub serwery mogą nie mieć tych czcionek, ich osadzenie może pomóc zachować zamierzony wygląd, pod warunkiem że licencje na nie pozwalają.