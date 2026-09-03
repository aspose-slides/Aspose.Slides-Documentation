---
title: Vkládání písem do prezentací v .NET
linktitle: Vložená písma
type: docs
weight: 40
url: /cs/net/embedded-font/
keywords:
- přidat písmo
- vložit písmo
- vkládání písma
- získat vložené písmo
- přidat vložené písmo
- odebrat vložené písmo
- komprimovat vložené písmo
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Spravujte vložená písma v PowerPointu pomocí Aspose.Slides pro .NET. Použijte C# k přidání, získání, odebrání a kompresi písem, abyste zachovali vzhled textu a snížili velikost souboru."
---
## **Úvod**

Vkládání písem ukládá data písem uvnitř prezentace PowerPoint. Když prohlížeč podporuje vložená písma, může zobrazit text pomocí těchto písem, i když nejsou nainstalována v cílovém systému. To pomáhá zachovat konce řádků, rozestupy textu a rozvržení snímků.

Aspose.Slides pro .NET umožňuje získávat, přidávat a odstraňovat vložená písma pomocí vlastnosti [FontsManager](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/fontsmanager/) třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/). Můžete také zmenšit velikost dat vložených písem odstraněním znaků, které prezentace nepoužívá.

Níže uvedené příklady pracují se soubory PPTX. Před vložením písma se ujistěte, že data písma jsou dostupná pro Aspose.Slides a že licence umožňuje vložení.

## **Získání a odebrání vložených písem**

Použijte [GetEmbeddedFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getembeddedfonts/) k vypsání písem uložených v prezentaci. Chcete‑li odebrat některé, předejte písmo z tohoto seznamu metodě [RemoveEmbeddedFont](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/removeembeddedfont/), poté prezentaci uložte.

Následující příklad vypíše vložená písma v souboru `EmbeddedFonts.pptx` a pokud je přítomno, odstraní písmo Calibri:

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

Odstranění vloženého písma smaže jeho uložená data; nezmění to písmo přiřazené textu. Pokud je písmo nainstalováno v cílovém systému, text jej může nadále používat. V opačném případě může renderování vyžadovat [font substitution](/slides/cs/net/font-substitution/), což může ovlivnit rozvržení.

## **Kontrola dat písem a oprávnění k vkládání**

Použijte rozhraní [IFontsManager](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/) k prozkoumání písem před jejich vložením. Zavolejte [IFontsManager.GetFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/getfonts/) pro získání písem použitých v prezentaci. Pro každé písmo předávejte objekt [IFontData](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontdata/) a požadovanou hodnotu [FontStyleType](https://reference.aspose.com/slides/cs/net/aspose.slides/fontstyletype/) metodě [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/getfontbytes/). Metoda vrací binární data pro daný styl písma nebo `null`, pokud požadované písmo či styl nejsou dostupné. Výsledek `null` nepředávejte metodě [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontsmanager/getfontembeddinglevel/), protože tato metoda vyžaduje pole bytů.

[EmbeddingLevel](https://reference.aspose.com/slides/cs/net/aspose.slides/embeddinglevel/) je výčtový typ s příznaky, který uvádí omezení vkládání uložená v písmu:

- `Installable` umožňuje vkládání a trvalou instalaci na jiném systému, za předpokladu licence písma.
- `Restricted` zakazuje vkládání, pokud není získáno povolení od právního vlastníka písma, a to, když je to jediný příznak oprávnění k použití.
- `PreviewPrint` povoluje dočasné použití pro prohlížení a tisk; dokument obsahující písmo musí být jen pro čtení.
- `Editable` povoluje dočasné použití a umožňuje dokument upravovat a ukládat.
- `NoSubsetting` je další omezení, které zakazuje vkládání jen podmnožiny glifů. Pokud je tento příznak přítomen, vložte všechny znaky.
- `BitmapOnly` je další omezení, které umožňuje vkládat pouze bitmapové varianty, ne outline data. Pokud písmo nemá bitmapové varianty, nelze jej vložit.

Prvních čtyři hodnoty popisují oprávnění k použití, zatímco `NoSubsetting` a `BitmapOnly` lze s nimi kombinovat. Modifikátory kontrolujte pomocí bitových operací. Protože `Installable` má hodnotu nula, nepoužívejte `HasFlag` k jeho detekci; maskujte bity oprávnění k použití a porovnejte výsledek s `Installable`. Aktuální písma by měla nastavit nejvýše jeden bit oprávnění k použití. Pro kompatibilitu se staršími písmy, která nastavují více než jeden, níže uvedený pomocník vybírá nejméně restriktivní oprávnění: `Editable`, pak `PreviewPrint`, pak `Restricted`.

Následující příklad kontroluje data normálního, tučného, kurzívního a tučně‑kurzívního stylu dostupná pro každé písmo vrácené metodou `GetFonts`. Přeskakuje nedostupné styly, omezená písma, písma pouze bitmapová, písma omezená na náhled a tisk, protože výstup zůstává editovatelný, a písma, která jsou již vložená. Pokud má některý dostupný styl příznak `NoSubsetting`, vloží všechny znaky pro danou rodinu písem.

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

Tato kontrola hlásí omezení zakódovaná v každém souboru písma. Neposkytuje licenci, neprokazuje, že jste písmo získali legálně, a nenahrazuje kontrolu licenční smlouvy písma před distribucí vložené kopie.

## **Přidání vložených písem**

Použijte [AddEmbeddedFont](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/addembeddedfont/) k vložení písma. Jeho přetížení přijímají buď objekt [IFontData](https://reference.aspose.com/slides/cs/net/aspose.slides/ifontdata/), nebo pole bytů obsahující data písma. Výčtový typ [EmbedFontCharacters](https://reference.aspose.com/slides/cs/net/aspose.slides.export/embedfontcharacters/) určuje, které znaky jsou zahrnuty:

- [All](https://reference.aspose.com/slides/cs/net/aspose.slides.export/embedfontcharacters/) vloží všechny znaky písma. Použijte tuto možnost, když příjemci potřebují upravovat prezentaci a zadávat nový text.
- [OnlyUsed](https://reference.aspose.com/slides/cs/net/aspose.slides.export/embedfontcharacters/) vloží pouze znaky použité v prezentaci, aby se snížila velikost souboru. Zvolte tuto možnost pro hotovou prezentaci, která je primárně určena k prohlížení.

Následující příklad používá [GetFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getfonts/) k získání písem použitých v souboru `Fonts.pptx` a vloží ta, která nejsou již vložená. Písma k přidání musí být dostupná na počítači, na kterém kód běží. Stávající vložená písma si zachovají své aktuální sady znaků.

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

## **Komprese vložených písem**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/compressembeddedfonts/) snižuje data vložených písem odstraněním nepoužívaných znaků. Funguje na písmách, která jsou již vložená, takže úspora velikosti závisí na množství nepoužitých dat písma v prezentaci.

Následující příklad komprimuje písma v souboru `EmbeddedFonts.pptx` a výsledek uloží jako samostatný soubor:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

Ponechte původní soubor, pokud příjemci mohou později potřebovat přidávat text. Znaky odebrané během komprese již nejsou dostupné z vloženého písma, i když jste původně vložili všechny znaky.

## **Často kladené otázky**

**Jak mohu zjistit, zda bude vložené písmo během renderování stále nahrazeno?**

Zavolejte [GetSubstitutions](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getsubstitutions/) v prostředí, ve kterém renderujete prezentaci, abyste zjistili, která písma Aspose.Slides nahradí. Také zkontrolujte nastavení [font substitution](/slides/cs/net/font-substitution/) a pravidla [font fallback](/slides/cs/net/fallback-font/). Fallback se stará o chybějící znaky, takže vložení písma nevyřeší znaky, které samotné písmo neobsahuje.

**Mám vložit běžná písma jako Arial a Calibri?**

Rozhodnutí se odvíjí od cílového prostředí. Pokud jsou požadovaná písma dostupná na každém zařízení, které prezentaci otevírá nebo renderuje, jejich vložení může zbytečně zvětšit velikost souboru. Pokud příjemci nebo servery tato písma nemusí mít, jejich vložení může pomoci zachovat zamýšlený vzhled, za předpokladu, že licence to umožňují.