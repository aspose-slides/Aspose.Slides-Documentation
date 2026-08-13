---
title: Převod snímků PowerPoint do PNG v .NET
linktitle: PowerPoint do PNG
type: docs
weight: 30
url: /cs/net/convert-powerpoint-to-png/
keywords:
- převod PowerPoint
- převod prezentace
- převod snímku
- převod PPT
- převod PPTX
- PowerPoint do PNG
- prezentace do PNG
- snímek do PNG
- PPT do PNG
- PPTX do PNG
- uložit PPT jako PNG
- uložit PPTX jako PNG
- exportovat PPT do PNG
- exportovat PPTX do PNG
- .NET
- C#
- Aspose.Slides
description: "Převádějte prezentace PowerPoint na vysoce kvalitní PNG obrázky rychle pomocí Aspose.Slides pro .NET a zajistěte přesné, automatizované výsledky."
---
## **Přehled**

Tento článek vysvětluje, jak převést prezentace PowerPoint na PNG obrázky pomocí Aspose.Slides. Ukazuje, jak načíst soubory prezentací ve formátech PPT, PPTX a ODP, vykreslit snímky jako obrázky a uložit výsledky ve formátu PNG.

Článek také demonstruje, jak přizpůsobit generované PNG obrázky nastavením hodnot měřítka nebo určením požadované šířky a výšky.

## **Převod PowerPointu na PNG**

Postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Prezentace](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte objekt snímku ze sbírky [Presentation.Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/properties/slides) pod rozhraním [ISlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide).
3. Použijte metodu [ISlide.GetImage(float, float)](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/) k vykreslení každého snímku v požadovaném měřítku.
4. Použijte metodu [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.ipresentation/save/methods/5) k uložení miniatury snímku do formátu PNG.

Tento C# kód ukazuje, jak převést prezentaci PowerPoint na PNG. Objekt Presentation dokáže načíst PPT, PPTX, ODP a další, poté je každý snímek v objektu prezentace převeden do formátu PNG nebo jiného obrazového formátu.

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(1f, 1f))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

{{% alert color="info" %}} 

**Poznámka:** Argumenty měřítka `1f, 1f` vykreslují každý snímek v plné velikosti, takže snímek 720 × 540 pt vytvoří obrázek 720 × 540 px. Přetížení [GetImage()](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/) bez parametrů vrací mnohem menší náhledovou miniaturu.

{{% /alert %}} 

## **Převod PowerPointu na PNG s vlastními rozměry**

Pokud chcete získat PNG soubory s určitým měřítkem, můžete nastavit hodnoty pro `desiredX` a `desiredY`, které určují rozměry výsledné miniatury.

Tento C# kód demonstruje popsanou operaci:

```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Převod PowerPointu na PNG s vlastní velikostí**

Pokud chcete získat PNG soubory s konkrétní velikostí, můžete předat požadované argumenty `width` a `height` pro `imageSize`.

Tento kód ukazuje, jak převést PowerPoint na PNG při specifikaci velikosti obrázků: 

```c#
using System.Drawing;
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Často kladené otázky**

### Jak mohu exportovat jen konkrétní tvar (např. graf nebo obrázek) místo celého snímku?

Aspose.Slides podporuje [generování miniatur pro jednotlivé tvary](/slides/cs/net/create-shape-thumbnails/); můžete vykreslit tvar do PNG obrázku.

### Je na serveru podporován paralelní převod?

Ano, ale [nesdílejte](/slides/cs/net/multithreading/) jednu instanci prezentace napříč vlákny. Použijte samostatnou instanci pro každé vlákno nebo proces.

### Jaká jsou omezení zkušební verze při exportu do PNG?

Režim hodnocení přidává vodoznak na výstupní obrázky a vynucuje [další omezení](/slides/cs/net/licensing/), dokud není aplikována licence.