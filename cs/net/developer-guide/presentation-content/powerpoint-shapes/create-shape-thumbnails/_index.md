---
title: Vytvoření miniatur tvarů prezentace v .NET
linktitle: Miniatury tvarů
type: docs
weight: 70
url: /cs/net/create-shape-thumbnails/
keywords:
- miniatura tvaru
- obrázek tvaru
- renderování tvaru
- vykreslování tvaru
- vizuální ohraničení
- ohraničení tvaru
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Generujte vysoce kvalitní miniatury tvarů z PowerPoint snímků pomocí Aspose.Slides pro .NET – snadno vytvořte a exportujte miniatury prezentací."
---
## **Úvod**

Aspose.Slides for .NET se používá k vytváření souborů prezentací, kde je každá stránka snímkem. Tyto snímky lze zobrazit otevřením souborů prezentace v Microsoft PowerPointu. Někdy však mohou vývojáři potřebovat zobrazit obrázky tvarů samostatně v prohlížeči obrázků. V takových případech vám Aspose.Slides for .NET pomůže vygenerovat miniatury obrázků snímků. Jak tuto funkci použít, je popsáno v tomto článku.
Tento článek vysvětluje, jak generovat miniatury snímků různými způsoby:

- Vytvoření miniatury tvaru uvnitř snímku.
- Vytvoření miniatury tvaru pro tvar snímku s uživatelem definovanými rozměry.
- Vytvoření miniatury tvaru v rámci hranic vzhledu tvaru.

## **Vytvoření miniatury tvaru ze snímku**
Jak vygenerovat miniaturu tvaru z libovolného snímku pomocí Aspose.Slides for .NET:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. Získejte obrázek miniatury tvaru referencovaného snímku v základním měřítku.
4. Uložte obrázek miniatury do libovolného požadovaného formátu obrázku.

Níže uvedený příklad generuje miniaturu tvaru.

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

## **Vytvoření miniatury s uživatelsky definovaným měřítkem**
Jak vygenerovat miniaturu tvaru libovolného tvaru snímku pomocí Aspose.Slides for .NET:

1. Vytvořte instanci třídy `Presentation`.
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. Získejte obrázek miniatury referencovaného snímku s ohraničením tvaru.
4. Uložte obrázek miniatury do libovolného požadovaného formátu obrázku.

Níže uvedený příklad generuje miniaturu s uživatelsky definovaným měřítkem.

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

## **Vytvoření miniatury vzhledu tvaru založené na ohraničeních**
Tento způsob vytváření miniatur tvarů umožňuje vývojářům generovat miniaturu v rámci ohraničení vzhledu tvaru. Zohledňuje všechny efekty tvaru. Vygenerovaná miniatura tvaru je omezena ohraničením snímku. Pro vygenerování miniatury libovolného tvaru snímku v rámci jeho vzhledu použijte následující ukázkový kód:

1. Vytvořte instanci třídy `Presentation`.
2. Získejte odkaz na libovolný snímek pomocí jeho ID nebo indexu.
3. Získejte obrázek miniatury referencovaného snímku s ohraničením tvaru jako vzhledu.
4. Uložte obrázek miniatury do libovolného požadovaného formátu obrázku.

Níže uvedený příklad vytváří miniaturu s uživatelsky definovaným měřítkem.

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

## **Získání skutečných vizuálních ohraničení tvaru**

Vlastnosti rámce [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/)—její `X`, `Y`, `Width` a `Height`—popisují obdélník uložený v modelu prezentace. Obsah, který je skutečně vykreslen, může přesahovat tento rámec nebo zabírat jiný osově zarovnaný obdélník. Rotace, obrysy, šipky, rozvržení a přetečení textu, generovaná geometrie SmartArt a další efekty vykreslování mohou změnit obsazenou oblast.

Použijte [GetVisualBounds](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/getvisualbounds/) k vypočítání této obsazené oblasti bez vytváření obrázku. Metoda vrací objekt [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) ve souřadnicích snímku. Vrácený obdélník není oříznut na snímek, takže jeho souřadnice mohou být záporné, pokud obsah přesahuje počátek snímku.

[GetVisualBounds](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/getvisualbounds/) není v současné době deklarována v rozhraní [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/). Proto uchovávejte tvar získaný ze sbírky tvarů snímku jako hodnotu rozhraní a přetypujte jej až při volání metody.

Následující příklad získá a porovná rámec a vizuální ohraničení:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

Stejný [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) lze použít k zarovnání sousedních tvarů k jeho hraně `Left`, `Right`, `Top` nebo `Bottom`; k rezervaci dostatečného prostoru v generovaném rozložení; nebo k detekci obsahu mimo povolenou oblast. Vizuální ohraničení jsou zvláště užitečná pro SmartArt, textová pole, šipky, obrázky, otočené tvary a skupinové tvary, kde uložený rámec nemusí představovat celý vykreslený výsledek.

Použijte [GetVisualBounds](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/getvisualbounds/), když potřebujete souřadnice pro rozvržení nebo validaci a nepotřebujete bitmapu. Použijte [IShape.GetImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/getimage/), když potřebujete tvar vykreslit. S [ShapeThumbnailBounds](https://reference.aspose.com/slides/cs/net/aspose.slides/shapethumbnailbounds/) parametr `ShapeThumbnailBounds.Shape` určuje velikost obrázku podle ohraničení tvaru, včetně nastavení obrysu, zatímco `ShapeThumbnailBounds.Appearance` určuje velikost podle vzhledu tvaru a omezuje výsledek na ohraničení snímku. Naopak [GetVisualBounds](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/getvisualbounds/) vrací pouze vypočítaný obdélník a neorezuje jej na snímek.

## **Často kladené otázky**

**Jaké formáty obrázků lze použít při ukládání miniatur tvarů?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cs/net/aspose.slides/imageformat/), a další. Tvary lze také [exportovat jako vektorové SVG](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/writeassvg/) uložením obsahu tvaru jako SVG.

**Jaký je rozdíl mezi ohraničením Shape a Appearance při renderování miniatury?**

`Shape` používá geometrii tvaru; `Appearance` zohledňuje [vizuální efekty](/slides/cs/net/shape-effect/) (stíny, záře atd.).

**Co se stane, když je tvar označen jako skrytý? Bude se stále renderovat jako miniatura?**

Skrytý tvar zůstává součástí modelu a může být vykreslen; příznak skrytí ovlivňuje zobrazení prezentace, ale nebrání generování obrázku tvaru.

**Jsou podporovány skupinové tvary, grafy, SmartArt a další složité objekty?**

Ano. Jakýkoli objekt reprezentovaný jako [Shape](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/) (včetně [GroupShape](https://reference.aspose.com/slides/cs/net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chart/), a [SmartArt](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/smartart/)) lze uložit jako miniaturu nebo jako SVG.

**Ovlivňují systémově nainstalované fonty kvalitu miniatur textových tvarů?**

Ano. Měli byste [poskytnout požadované fonty](/slides/cs/net/custom-font/) (nebo [nastavit náhrady fontů](/slides/cs/net/font-substitution/)), aby se předešlo nechtěným náhradám a přelámování textu.