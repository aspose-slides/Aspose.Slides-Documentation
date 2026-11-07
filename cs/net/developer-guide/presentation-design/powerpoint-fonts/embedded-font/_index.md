---
title: Vkládání fontů do prezentací v .NET
linktitle: Vložené fonty
type: docs
weight: 40
url: /cs/net/embedded-font/
keywords:
- přidat font
- vložit font
- vkládání fontu
- získat vložený font
- přidat vložený font
- odstranit vložený font
- komprimovat vložený font
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spravujte vložené fonty v PowerPointu pomocí Aspose.Slides pro .NET. Použijte C# k přidání, načtení, odebrání a kompresi fontů pro zachování vzhledu textu a snížení velikosti souboru."
---
## **Úvod**

Vkládání fontů ukládá data fontu uvnitř prezentace PowerPoint. Když prohlížeč podporuje vložené fonty, může zobrazovat text pomocí těchto fontů, i když nejsou nainstalovány v cílovém systému. To pomáhá zachovat zalomení řádků, mezery mezi textem a rozložení snímků.

Aspose.Slides pro .NET vám umožňuje načíst, přidat a odstranit vložené fonty pomocí vlastnosti [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) objektu [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). Můžete také snížit velikost dat vložených fontů odstraněním znaků, které prezentace nepoužívá.

Níže uvedené příklady pracují se soubory PPTX. Před vložením fontu se ujistěte, že jeho data jsou k dispozici pro Aspose.Slides a že jeho licence povoluje vkládání.

## **Získání a odebrání vložených fontů**

Použijte [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) k vypsání fontů uložených v prezentaci. Chcete‑li některý odstranit, předajte font z tohoto seznamu metodě [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/) a poté prezentaci uložte.

Následující příklad vypíše vložené fonty v souboru `EmbeddedFonts.pptx` a odstraní Calibri, pokud je přítomen:
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

Odstranění vloženého fontu odstraní jeho uložená data fontu; nemění to přiřazený font textu. Pokud je font nainstalován v cílovém systému, text jej může nadále používat. V opačném případě může vykreslování vyžadovat [font substitution](/slides/cs/net/font-substitution/), což může ovlivnit rozložení.

## **Prozkoumání dat fontu a oprávnění k vkládání**

Použijte rozhraní [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) k prozkoumání fontů před jejich vložením. Zavolejte [IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) pro získání fontů použitých v prezentaci. Pro každý font předajte objekt [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) a požadovanou hodnotu [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) metodě [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/). Metoda vrací binární data pro daný styl fontu, nebo `null`, pokud požadovaný font či styl není dostupný. Nepředávejte výsledek `null` metodě [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), protože tato metoda vyžaduje pole bajtů.

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) je výčtová hodnota s příznaky, která uvádí omezení vkládání uložená ve fontu:

- `Installable` umožňuje vkládání a trvalou instalaci na jiném systému, pokud to licence fontu povoluje.
- `Restricted` zakazuje vkládání, pokud není získáno povolení od právního vlastníka fontu, a to pokud je to jediné oprávnění k užití.
- `PreviewPrint` povoluje dočasné použití pro prohlížení a tisk; dokument obsahující font musí být jen pro čtení.
- `Editable` povoluje dočasné použití a umožňuje dokument upravovat a ukládat.
- `NoSubsetting` je další omezení, které zakazuje vložit pouze podmnožinu glifů. V takovém případě vložte všechny znaky.
- `BitmapOnly` je další omezení, které umožňuje vložit pouze bitmapové sady, ne konturová data. Pokud font nemá bitmapové sady, nelze jej vložit.

Prvních čtyři hodnoty popisují oprávnění k použití, zatímco `NoSubsetting` a `BitmapOnly` lze kombinovat s nimi. Modifikátory kontrolujte pomocí bitových operací. Protože `Installable` má hodnotu nula, nepoužívejte `HasFlag` k jeho detekci; maskujte bity oprávnění k použití a porovnávejte výsledek s `Installable`. Aktuální fonty by měly nastavit nejvýše jeden bit oprávnění. Pro kompatibilitu se staršími fonty, které nastavily více než jeden, níže uvedený pomocník vybírá nejméně omezující oprávnění: `Editable`, poté `PreviewPrint`, poté `Restricted`.

Následující příklad kontroluje běžná, tučná, kurzívní a tučně‑kurzívní data dostupná pro každý font vrácený metodou `GetFonts`. Přeskakuje nedostupné styly, omezené fonty, fonty jen bitmapové, fonty omezené na náhled a tisk, protože výstup zůstává editovatelný, a fonty, které jsou již vloženy. Pokud má některý dostupný styl `NoSubsetting`, vloží všechny znaky pro danou rodinu fontů.
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

Toto prozkoumání hlásí omezení zakódovaná v každém souboru fontu. Nedává licence, neprokazuje, že jste font získali legálně, ani nenahrazuje kontrolu licenční smlouvy fontu před distribucí vložené kopie.

## **Přidání vložených fontů**

Použijte [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) k vložení fontu. Jeho přetížení přijímají buď objekt [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) nebo pole bajtů obsahující data fontu. Výčtová hodnota [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) určuje, které znaky jsou zahrnuty:

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) vloží všechny znaky fontu. Použijte tuto možnost, když příjemci potřebují prezentaci upravovat a zadávat nový text.
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) vloží pouze znaky použité v prezentaci, čímž se zmenší velikost souboru. Zvolte tuto možnost pro finální prezentaci určenou převážně k prohlížení.

Následující příklad používá [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) k získání fontů použité v souboru `Fonts.pptx` a vloží ty, které ještě nejsou vloženy. Fonty k přidání musí být dostupné na počítači, na kterém kód běží. Existující vložené fonty si zachovají své aktuální sady znaků.
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

## **Komprese vložených fontů**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) snižuje data vložených fontů odebráním nepoužitých znaků. Operuje na již vložených fontech, takže úspora velikosti závisí na tom, kolik nepoužitých dat fontu v prezentaci je.

Následující příklad komprimuje fonty v souboru `EmbeddedFonts.pptx` a výsledek uloží jako samostatný soubor:
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Uchovejte původní soubor, pokud příjemci mohou později potřebovat přidávat text. Znaky odebrané během komprese již nejsou dostupné z vloženého fontu, i když jste původně vložili všechny znaky.

Aby během exportu získal odpovídající registrovaný font přednost před vloženým fontem, aniž by byl odstraněn, viz [Prefer Registered Fonts over Embedded Fonts](/slides/cs/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 nebo novější).

## **Často kladené otázky**

**Jak mohu zjistit, zda bude vložený font při vykreslování stále nahrazen?**

Zavolejte [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) v prostředí, kde prezentaci vykreslujete, aby jste zjistili, které fonty Aspose.Slides nahradí. Také zkontrolujte nastavení [font substitution](/slides/cs/net/font-substitution/) a pravidla [font fallback](/slides/cs/net/fallback-font/). Fallback ošetřuje chybějící znaky, takže vložení fontu nevyřeší znaky, které font samotný neobsahuje.

**Mám vložit běžné fonty jako Arial a Calibri?**

Rozhodnutí vycházejte z cílového prostředí. Pokud jsou požadované fonty dostupné na každém počítači, který prezentaci otevírá nebo vykresluje, jejich vložení může zbytečně zvětšit velikost souboru. Pokud příjemci nebo servery mohou tyto fonty postrádat, jejich vložení může pomoci zachovat zamýšlený vzhled, pokud to licence fontů umožňují.