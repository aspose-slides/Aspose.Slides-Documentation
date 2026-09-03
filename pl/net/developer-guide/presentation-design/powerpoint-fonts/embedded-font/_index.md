---
title: Osadzanie czcionek w prezentacjach w .NET
linktitle: Osadzone czcionki
type: docs
weight: 40
url: /pl/net/embedded-font/
keywords:
- dodaj czcionkę
- osadź czcionkę
- osadzanie czcionek
- pobierz osadzoną czcionkę
- dodaj osadzoną czcionkę
- usuń osadzoną czcionkę
- kompresuj osadzoną czcionkę
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj osadzonymi czcionkami w PowerPoint przy użyciu Aspose.Slides dla .NET. Używaj C#, aby dodawać, pobierać, usuwać i kompresować czcionki, zachowując wygląd tekstu i zmniejszając rozmiar pliku."
---
## **Wstęp**

Osadzanie czcionek zapisuje dane czcionki wewnątrz prezentacji PowerPoint. Gdy przeglądarka obsługuje osadzone czcionki, może wyświetlać tekst przy użyciu tych czcionek, nawet jeśli nie są one zainstalowane w systemie docelowym. Pomaga to zachować podziały linii, odstępy tekstu i układ slajdów.

Aspose.Slides for .NET umożliwia pobieranie, dodawanie i usuwanie osadzonych czcionek za pośrednictwem właściwości [FontsManager](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/fontsmanager/) obiektu [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/). Możesz także zmniejszyć rozmiar danych osadzonych czcionek, usuwając znaki, których prezentacja nie używa.

Poniższe przykłady działają na plikach PPTX. Przed osadzeniem czcionki upewnij się, że jej dane są dostępne dla Aspose.Slides i że jej licencja zezwala na osadzanie.

## **Pobieranie i usuwanie osadzonych czcionek**

Użyj [GetEmbeddedFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/getembeddedfonts/) , aby wyświetlić listę czcionek zapisanych w prezentacji. Aby usunąć jedną z nich, przekaż czcionkę z tej listy do [RemoveEmbeddedFont](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/removeembeddedfont/), a następnie zapisz prezentację.

Poniższy przykład wymienia osadzone czcionki w pliku `EmbeddedFonts.pptx` i usuwa Calibri, jeśli jest obecna:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

Usunięcie osadzonej czcionki usuwa jej zapisane dane; nie zmienia to czcionki przypisanej do tekstu. Jeśli czcionka jest zainstalowana w systemie docelowym, tekst może ją nadal używać. W przeciwnym razie renderowanie może wymagać [font substitution](/slides/pl/net/font-substitution/), co może wpłynąć na układ.

## **Inspekcja danych czcionki i uprawnień do osadzania**

Użyj interfejsu [IFontsManager](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/) , aby sprawdzić czcionki przed ich osadzeniem. Wywołaj [IFontsManager.GetFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/getfonts/) , aby pobrać czcionki użyte w prezentacji. Dla każdej czcionki przekaż obiekt [IFontData](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontdata/) oraz wymaganą wartość [FontStyleType](https://reference.aspose.com/slides/pl/net/aspose.slides/fontstyletype/) do [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/getfontbytes/). Metoda zwraca dane binarne dla tego stylu czcionki lub `null`, gdy żądana czcionka lub styl są niedostępne. Nie przekazuj wyniku `null` do [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), ponieważ ta metoda wymaga tablicy bajtów.

[EmbeddingLevel](https://reference.aspose.com/slides/pl/net/aspose.slides/embeddinglevel/) jest wyliczeniem flagowym, które raportuje ograniczenia osadzania zapisane w czcionce:

- `Installable` zezwala na osadzanie i trwałą instalację w innym systemie, zgodnie z licencją czcionki.
- `Restricted` zabrania osadzania, chyba że uzyskano pozwolenie od prawnego właściciela czcionki, gdy jest to jedyna flaga uprawnień użytkowania.
- `PreviewPrint` zezwala na tymczasowe użycie do podglądu i drukowania; dokument zawierający czcionkę musi być tylko do odczytu.
- `Editable` zezwala na tymczasowe użycie i umożliwia edytowanie oraz zapisywanie dokumentu.
- `NoSubsetting` jest dodatkowym ograniczeniem, które zabrania osadzania tylko podzbioru glifów. Gdy flaga jest obecna, osadzaj wszystkie znaki.
- `BitmapOnly` jest dodatkowym ograniczeniem, które zezwala jedynie na osadzanie bitmapowych wariantów czcionki, nie danych wektorowych. Jeśli czcionka nie ma bitmapowych wariantów, nie może być osadzona.

Pierwsze cztery wartości opisują uprawnienia użytkowania, natomiast `NoSubsetting` i `BitmapOnly` mogą być z nimi łączone. Sprawdzaj modyfikatory przy użyciu operacji bitowych. Ponieważ `Installable` ma wartość zero, nie używaj `HasFlag` do wykrywania tej flagi; zastosuj maskę bitów uprawnień użytkowania i porównaj wynik z `Installable`. Aktualne czcionki powinny ustawiać co najwyżej jedną flagę uprawnień użytkowania. Dla zgodności ze starszymi czcionkami, które ustawiają więcej niż jedną, poniższy pomocnik wybiera najmniej restrykcyjne uprawnienie: `Editable`, potem `PreviewPrint`, potem `Restricted`.

Poniższy przykład audytuje dane zwykłe, pogrubione, pochylone i pogrubione‑pochylone dostępne dla każdej czcionki zwróconej przez `GetFonts`. Pomija style niedostępne, czcionki ograniczone, czcionki tylko bitmapowe, czcionki ograniczone do podglądu i druku, ponieważ wynik pozostaje edytowalny, oraz czcionki już osadzone. Jeśli jakikolwiek dostępny styl ma flagę `NoSubsetting`, zostają osadzone wszystkie znaki danej rodziny czcionek.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

Ta inspekcja raportuje ograniczenia zakodowane w każdym pliku czcionki. Nie przyznaje licencji, nie dowodzi, że uzyskałeś czcionkę legalnie, ani nie zastępuje sprawdzania umowy licencyjnej czcionki przed rozpowszechnianiem osadzonej kopii.

## **Dodawanie osadzonych czcionek**

Użyj [AddEmbeddedFont](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/addembeddedfont/) , aby osadzić czcionkę. Przeciążenia przyjmują albo obiekt [IFontData](https://reference.aspose.com/slides/pl/net/aspose.slides/ifontdata/) , albo tablicę bajtów zawierającą dane czcionki. Wyliczenie [EmbedFontCharacters](https://reference.aspose.com/slides/pl/net/aspose.slides.export/embedfontcharacters/) kontroluje, które znaki są uwzględniane:

- [All](https://reference.aspose.com/slides/pl/net/aspose.slides.export/embedfontcharacters/) osadza wszystkie znaki w czcionce. Użyj tej opcji, gdy odbiorcy muszą edytować prezentację i wprowadzać nowy tekst.
- [OnlyUsed](https://reference.aspose.com/slides/pl/net/aspose.slides.export/embedfontcharacters/) osadza tylko znaki użyte w prezentacji, aby zmniejszyć rozmiar pliku. Wybierz tę opcję dla gotowej prezentacji przeznaczonej głównie do podglądu.

Poniższy przykład używa [GetFonts](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/getfonts/) , aby pobrać czcionki użyte w `Fonts.pptx` i osadzi te, które nie są jeszcze osadzone. Czcionki do dodania muszą być dostępne na maszynie uruchamiającej kod. Istniejące osadzone czcionki zachowują swoje bieżące zestawy znaków.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **Kompresja osadzonych czcionek**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/pl/net/aspose.slides.lowcode/compress/compressembeddedfonts/) zmniejsza dane osadzonych czcionek, usuwając nieużywane znaki. Działa na czcionkach, które już są osadzone, więc redukcja rozmiaru zależy od ilości nieużywanych danych czcionki w prezentacji.

Poniższy przykład kompresuje czcionki w `EmbeddedFonts.pptx` i zapisuje wynik jako osobny plik:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Zachowaj oryginalny plik, jeśli odbiorcy mogą później potrzebować dodać tekst. Znaki usunięte podczas kompresji nie będą już dostępne w osadzonej czcionce, nawet jeśli pierwotnie osadzono wszystkie znaki.

## **FAQ**

**Jak mogę sprawdzić, czy osadzona czcionka będzie nadal podstawiana podczas renderowania?**

Wywołaj [GetSubstitutions](https://reference.aspose.com/slides/pl/net/aspose.slides/fontsmanager/getsubstitutions/) w środowisku, w którym renderujesz prezentację, aby zobaczyć, które czcionki Aspose.Slides zamieni. Sprawdź także ustawienia [font substitution](/slides/pl/net/font-substitution/) oraz reguły [font fallback](/slides/pl/net/fallback-font/). Fallback obsługuje brakujące znaki, więc osadzenie czcionki nie rozwiązuje znaków, których sama czcionka nie zawiera.

**Czy powinienem osadzać popularne czcionki, takie jak Arial i Calibri?**

Decyzję należy podjąć w oparciu o docelowe środowisko. Jeśli wymagane czcionki są dostępne na każdym komputerze, który otwiera lub renderuje prezentację, ich osadzanie może niepotrzebnie zwiększyć rozmiar pliku. Jeśli odbiorcy lub serwery mogą nie mieć tych czcionek, ich osadzenie może pomóc zachować zamierzony wygląd, pod warunkiem że licencje na nie to dopuszczają.