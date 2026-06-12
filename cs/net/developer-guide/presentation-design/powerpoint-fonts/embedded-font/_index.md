---
title: Vkládání písem do prezentací v .NET
linktitle: Vkládání písma
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
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vkládejte TrueType písma do prezentací PowerPoint a OpenDocument pomocí Aspose.Slides pro .NET, čímž zajistíte přesné vykreslování na všech platformách."
---
## **Úvod**

**Vkládání písem do PowerPointu** zajišťuje, že vaše prezentace si zachová zamýšlený vzhled na různých systémech. Ať už používáte jedinečná písma pro kreativitu nebo standardní, vkládání písem zabraňuje narušení textu a rozvržení.

Pokud jste použili písmo od třetí strany nebo nestandardní písmo, protože jste byli kreativní ve své práci, máte ještě více důvodů písmo vložit. Jinak (bez vložených písem) se texty nebo čísla na snímcích, rozvržení, stylování atd. mohou změnit nebo se proměnit v matoucí obdélníky.

Využijte třídy [FontsManager](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/cs/net/aspose.slides/fontdata/) a [Compress](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/) k správě vložených písem.

## **Získání a odebrání vložených písem**

Získejte nebo odeberte vložená písma z prezentace snadno pomocí metod [GetEmbeddedFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getembeddedfonts) a [RemoveEmbeddedFont](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/removeembeddedfont).

Tento C# kód vám ukazuje, jak získat a odebrat vložená písma z prezentace:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Renderuje snímek obsahující textový rámec, který používá vložené "FunSized"
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Vyhledá písmo "Calibri"
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Odstraní písmo "Calibri"
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Renderuje prezentaci; písmo "Calibri" je nahrazeno existujícím
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Uloží prezentaci bez vloženého písma "Calibri" na disk
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Přidání vložených písem**

Pomocí výčtu [EmbedFontCharacters](https://reference.aspose.com/slides/cs/net/aspose.slides.export/embedfontcharacters/) a dvou přetížení metody [AddEmbeddedFont](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/addembeddedfont/) můžete vybrat preferované (vkládací) pravidlo pro vložení písem do prezentace. Tento C# kód vám ukazuje, jak vložit a přidat písma do prezentace:

```c#
 // Načte prezentaci
 Presentation presentation = new Presentation("Fonts.pptx");

 IFontData[] allFonts = presentation.FontsManager.GetFonts();
 IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
 foreach (IFontData font in allFonts)
 {
     if (!embeddedFonts.Contains(font))
     {
         presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
     }
 }

 // Uloží prezentaci na disk
 presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Komprimace vložených písem**

Optimalizujte velikost souboru komprimací vložených písem pomocí [CompressEmbeddedFonts](https://reference.aspose.com/slides/cs/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

Příklad kódu pro kompresi:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Jak mohu zjistit, že konkrétní písmo v prezentaci bude i přes vložení při vykreslování nahrazeno?**

Zkontrolujte [informace o substituci](/slides/cs/net/font-substitution/) ve správci písem a [pravidla pro náhradu/záložní písma](/slides/cs/net/fallback-font/): pokud není písmo dostupné nebo je omezené, bude použito záložní písmo.

**Stojí za to vkládat „systémová“ písma jako Arial/Calibri?**

Obvykle ne – jsou téměř vždy dostupná. Ale pro úplnou přenositelnost v „štíhlých“ prostředích (Docker, Linux server bez předinstalovaných písem) může vkládání systémových písem eliminovat riziko neočekávaných substitucí.