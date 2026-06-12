---
title: Vytvoření náhledových obrázků tvarů prezentace v .NET
linktitle: Náhledy tvarů
type: docs
weight: 70
url: /cs/net/create-shape-thumbnails/
keywords:
- náhled tvaru
- obrázek tvaru
- vykreslit tvar
- renderování tvaru
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Generujte vysoce kvalitní náhledy tvarů z PowerPoint snímků pomocí Aspose.Slides pro .NET – snadno vytvářejte a exportujte náhledy prezentací."
---
## **Úvod**

Aspose.Slides pro .NET se používá k vytváření prezentačních souborů, kde je každá stránka snímkem. Tyto snímky lze zobrazit otevřením prezentačních souborů v Microsoft PowerPoint. Někdy však vývojáři potřebují zobrazit obrázky tvarů odděleně v prohlížeči obrázků. V takových případech Aspose.Slides pro .NET pomáhá generovat náhledové obrázky tvarů snímků. Jak tuto funkci použít, je popsáno v tomto článku.

Tento článek vysvětluje, jak generovat náhledy snímků různými způsoby:

- Generování náhledového obrázku tvaru uvnitř snímku.
- Generování náhledového obrázku tvaru snímku s uživatelem definovanými rozměry.
- Generování náhledového obrázku tvaru v mezích vzhledu tvaru.

## **Vytvoření náhledového obrázku tvaru ze snímku**
Jak vygenerovat náhledový obrázek tvaru z libovolného snímku pomocí Aspose.Slides pro .NET:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Získejte referenci libovolného snímku pomocí jeho ID nebo indexu.
1. Získejte náhledový obrázek tvaru referencovaného snímku v základním měřítku.
1. Uložte náhledový obrázek do libovolného požadovaného formátu obrázku.

Níže uvedený příklad generuje náhled tvaru.

```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Generování náhledu s uživatelem definovaným měřítkovým faktorem**
Jak vygenerovat náhledový obrázek tvaru libovolného tvaru snímku pomocí Aspose.Slides pro .NET:

1. Vytvořte instanci třídy `Presentation`.
1. Získejte referenci libovolného snímku pomocí jeho ID nebo indexu.
1. Získejte náhledový obrázek referencovaného snímku s ohraničením tvaru.
1. Uložte náhledový obrázek do libovolného požadovaného formátu obrázku.

Níže uvedený příklad generuje náhled s uživatelem definovaným měřítkovým faktorem.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // Škálování podél os X a Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```

## **Vytvoření náhledu tvaru na základě ohraničení vzhledu**
Cílová metoda pro vytváření náhledů tvarů umožňuje vývojářům generovat náhled v mezích vzhledu tvaru. Zohledňuje všechny efekty tvaru. Vygenerovaný náhled tvaru je omezen mezemi snímku. Pro generování náhledu libovolného tvaru snímku v mezích jeho vzhledu použijte následující ukázkový kód:

1. Vytvořte instanci třídy `Presentation`.
1. Získejte referenci libovolného snímku pomocí jeho ID nebo indexu.
1. Získejte náhledový obrázek referencovaného snímku s ohraničením tvaru jako vzhled.
1. Uložte náhledový obrázek do libovolného požadovaného formátu obrázku.

Níže uvedený příklad vytváří náhled s uživatelem definovaným měřítkovým faktorem.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // Škálování podél os X a Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```

## **Často kladené otázky**

**Jaké formáty obrázků lze použít při ukládání náhledů tvarů?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cs/net/aspose.slides/imageformat/), a další. Tvary lze také [exportovat jako vektorové SVG](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/writeassvg/) uložením obsahu tvaru jako SVG.

**Jaký je rozdíl mezi ohraničením Shape a Appearance při renderování náhledu?**

`Shape` používá geometrii tvaru; `Appearance` zohledňuje [vizuální efekty](/slides/cs/net/shape-effect/) (stíny, záře atd.).

**Co se stane, pokud je tvar označen jako skrytý? Bude se stále vykreslovat jako náhled?**

Skrytý tvar zůstává součástí modelu a lze jej vykreslit; příznak skrytí ovlivňuje zobrazení v prezentaci, ale nebrání generování obrázku tvaru.

**Jsou podporovány skupinové tvary, grafy, SmartArt a další složité objekty?**

Ano. Jakýkoli objekt reprezentovaný jako [Shape](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/) (včetně [GroupShape](https://reference.aspose.com/slides/cs/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chart/) a [SmartArt](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/smartart/)) lze uložit jako náhled nebo jako SVG.

**Ovlivňují systémové fonty kvalitu náhledů textových tvarů?**

Ano. Měli byste [poskytnout požadované fonty](/slides/cs/net/custom-font/) (nebo [nastavit náhrady fontů](/slides/cs/net/font-substitution/)), aby nedošlo k nechtěným náhradám a přelomu textu.