---
title: Převést snímky PowerPoint na PNG v .NET
linktitle: PowerPoint na PNG
type: docs
weight: 30
url: /cs/net/convert-powerpoint-to-png/
keywords:
- převést PowerPoint
- převést prezentaci
- převést snímek
- převést PPT
- převést PPTX
- PowerPoint na PNG
- prezentaci na PNG
- snímek na PNG
- PPT na PNG
- PPTX na PNG
- uložit PPT jako PNG
- uložit PPTX jako PNG
- exportovat PPT do PNG
- exportovat PPTX do PNG
- .NET
- C#
- Aspose.Slides
description: "Převádějte prezentace PowerPoint na vysoce kvalitní PNG obrázky rychle pomocí Aspose.Slides pro .NET, což zajišťuje přesné a automatizované výsledky."
---
## **Přehled**

Tento článek vysvětluje, jak pomocí Aspose.Slides převést prezentace PowerPoint na PNG obrázky. Ukazuje, jak načíst soubory prezentací v formátech jako PPT, PPTX a ODP, vykreslit snímky jako obrázky a uložit výsledky ve formátu PNG.

Článek také ukazuje, jak přizpůsobit vygenerované PNG obrázky nastavením měřítka nebo zadáním požadované šířky a výšky.

## **Převést PowerPoint na PNG**

Proveďte následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte objekt snímku z kolekce [Presentation.Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/properties/slides) pod rozhraním [ISlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide).
3. Použijte metodu [ISlide.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/getimage/) k získání náhledu pro každý snímek.
4. Použijte metodu [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/cs/net/aspose.slides.ipresentation/save/methods/5) k uložení náhledu snímku do formátu PNG.

Tento C# kód ukazuje, jak převést prezentaci PowerPoint na PNG. Objekt Presentation dokáže načíst PPT, PPTX, ODP atd., a poté je každý snímek v objektu Presentation převeden do formátu PNG nebo jiného formátu obrázku.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Převést PowerPoint na PNG s vlastním rozměrem**

Pokud chcete získat PNG soubory v určitém měřítku, můžete nastavit hodnoty `desiredX` a `desiredY`, které určují rozměry výsledného náhledu.

Tento C# kód demonstruje popsanou operaci:

```c#
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

## **Převést PowerPoint na PNG s vlastní velikostí**

Pokud chcete získat PNG soubory v určité velikosti, můžete předat požadované argumenty `width` a `height` pro `imageSize`.

Tento kód ukazuje, jak převést PowerPoint na PNG při specifikaci velikosti obrázků:

```c#
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

**Jak mohu exportovat pouze konkrétní tvar (např. graf nebo obrázek) místo celého snímku?**

Aspose.Slides podporuje [generování náhledů pro jednotlivé tvary](/slides/cs/net/create-shape-thumbnails/); můžete vykreslit tvar do PNG obrázku.

**Je paralelní převod podporován na serveru?**

Ano, ale [nesdílejte](/slides/cs/net/multithreading/) jedinou instanci prezentace mezi vlákny. Použijte samostatnou instanci pro každé vlákno nebo proces.

**Jaká jsou omezení trial verze při exportu do PNG?**

Režim hodnocení přidává vodoznak na výstupní obrázky a vynucuje další omezení, dokud není licence použita.