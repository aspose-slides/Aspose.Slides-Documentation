---
title: Správa placeholderů v prezentacích v .NET
linktitle: Spravovat placeholdery
type: docs
weight: 10
url: /cs/net/manage-placeholder/
keywords:
- placeholder
- textový placeholder
- obrázkový placeholder
- placeholder grafu
- obsahový placeholder
- výzva
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak prohlížet a upravovat textové, obrázkové, grafické a obsahové placeholdery a pochopit dědičnost placeholderů pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Placeholder je tvar, který vyhrazuje pozici pro určitý typ obsahu v šabloně prezentace. Běžnými příklady jsou placeholdery pro nadpis, tělo, obrázek, graf a obecné účely. Na rozdíl od běžného tvaru může placeholder dědit svou pozici, velikost, formátování a další nastavení z rozvržení snímku nebo z hlavního snímku.

Aspose.Slides poskytuje informace o placeholderu prostřednictvím vlastnosti [IShape.Placeholder](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/placeholder/). Vlastnost vrací objekt [IPlaceholder](https://reference.aspose.com/slides/cs/net/aspose.slides/iplaceholder/) nebo `null` pro normální tvar. K určení, co je placeholder určen k obsahu, použijte [IPlaceholder.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/iplaceholder/type/).

Rozhraní tvaru je stále důležité i po zjištění typu placeholderu:

- Prázdný textový, obrázkový, grafový nebo obsahový placeholder je obvykle reprezentován pomocí [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).
- Vyplněný obrázkový placeholder může být reprezentován pomocí [IPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe/).
- Vyplněný grafický placeholder může být reprezentován pomocí [IChart](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichart/).
- Obsahový placeholder může obsahovat několik typů obsahu. Zkontrolujte jak [IPlaceholder.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/iplaceholder/type/), tak runtime rozhraní tvaru, místo abyste předpokládali, že každý placeholder je [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).

{{% alert color="warning" title="Varování" %}}
[IPlaceholder.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/iplaceholder/type/) popisuje roli placeholderu; nezaručuje runtime typ tvaru. Vždy použijte kontrolu typu před přístupem k textovým, obrázkovým, grafovým, tabulkovým nebo mediálním členům.
{{% /alert %}}

## **Pochopení dědičnosti placeholderů**

Placeholdery tvoří hierarchii:

1. Hlavní snímek definuje znovupoužitelné styly a v některých případech placeholdery na úrovni masteru.
2. Rozvržení snímku určuje uspořádání používané jedním nebo více normálními snímky a může dědit z hlavního snímku.
3. Normální snímek obsahuje placeholdery pro tento snímek a může dědit z jeho rozvržení.

Voláním [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/getbaseplaceholder/) se posunete o jednu úroveň výš v této hierarchii. Placeholder snímku obvykle vrací svůj placeholder rozvržení; placeholder rozvržení může vrátit svůj placeholder masteru. Metoda vrací `null`, pokud tvar nemá základní placeholder.

Následující příklad vypíše placeholdery na prvním snímku a zobrazí jejich základní placeholdery:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;
    var typeName = shape.GetType().Name;
    Console.WriteLine($"Slide placeholder: {placeholderType}; shape interface: {typeName}");

    var layoutPlaceholder = shape.GetBasePlaceholder();
    if (layoutPlaceholder != null)
    {
        var layoutPlaceholderType = layoutPlaceholder.Placeholder?.Type;
        Console.WriteLine($"  Layout placeholder: {layoutPlaceholderType}");

        var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
        if (masterPlaceholder != null)
        {
            var masterPlaceholderType = masterPlaceholder.Placeholder?.Type;
            Console.WriteLine($"  Master placeholder: {masterPlaceholderType}");
        }
    }
}
```

Úprava placeholderu na normálním snímku vytvoří nebo změní lokální přepsání pro tento snímek. Úprava souvisejícího rozvržení nebo masteru může ovlivnit všechny snímky, které stále dědí toto nastavení. Lokální běžný tvar nemá základní placeholder a nezačne dědit jen proto, že zaujímá stejné souřadnice.

## **Změna textu v placeholderu**

Nadpisové, centrované nadpisové, podnadpisové, tělové a textové placeholdery obvykle podporují text. Před použitím vlastnosti [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/textframe/) zkontrolujte, zda se jedná o [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).

Tento příklad aktualizuje první placeholder nadpisu na prvním snímku a uloží výsledek:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
IAutoShape? titleShape = null;

foreach (var shape in slide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = autoShape.Placeholder.Type;
    if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle)
    {
        titleShape = autoShape;
        break;
    }
}

if (titleShape == null)
{
    throw new InvalidOperationException("The first slide does not contain a title placeholder.");
}

titleShape.TextFrame.Text = "Quarterly Business Review";
presentation.Save("title-placeholder-updated.pptx", SaveFormat.Pptx);
```

Tento vzor se vyhýbá přetypování obrázkových, grafových, tabulkových nebo mediálních placeholderů na [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/). Také identifikuje placeholder podle jeho účelu místo spoléhaní se na křehký index tvaru.

## **Nastavení výzvy v rozvržení**

Výzva (prompt text) je návrhová instrukce zobrazovaná v prázdném placeholderu, např. *Klikněte pro přidání nadpisu*. Nastavte vlastní výzvu na placeholderu rozvržení místo pokusu o dosažení skrze kolekci tvarů normálního snímku. Přístup k rozvržení získáte pomocí [ISlide.LayoutSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/islide/layoutslide/) a iterujte přes [ILayoutSlide.Shapes](https://reference.aspose.com/slides/cs/net/aspose.slides/ibaseslide/shapes/).

Následující příklad mění výzvy nadpisu a podnadpisu v rozvržení použitém na prvním snímku:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var layoutSlide = presentation.Slides[0].LayoutSlide;

foreach (var shape in layoutSlide.Shapes)
{
    if (shape is not IAutoShape autoShape || autoShape.Placeholder == null)
    {
        continue;
    }

    switch (autoShape.Placeholder.Type)
    {
        case PlaceholderType.Title:
        case PlaceholderType.CenteredTitle:
            autoShape.TextFrame.Text = "Enter a concise slide title";
            break;
        case PlaceholderType.Subtitle:
            autoShape.TextFrame.Text = "Enter a subtitle or reporting period";
            break;
    }
}

presentation.Save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
```

Výzva není běžný obsah snímku. Je určena pro prázdné placeholdery v editačních aplikacích, jako je PowerPoint. Jakmile uživatel nebo program dodá skutečný obsah, výzva se již nezobrazuje. Změna výzvy také nenahrazuje existující text na snímcích, které rozvržení používají.

## **Aktualizace obrázkového placeholderu**

Jsou dva případy k ošetření:

- Pokud je obrázkový placeholder již vyplněn a reprezentován pomocí [IPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe/), nahraďte obrázek přes [IPictureFillFormat.Picture](https://reference.aspose.com/slides/cs/net/aspose.slides/ipicturefillformat/picture/) a [ISlidesPicture.Image](https://reference.aspose.com/slides/cs/net/aspose.slides/islidespicture/image/).
- Pokud je stále prázdný placeholder, přidejte obrázkový rámec na souřadnice placeholderu pomocí [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addpictureframe/) a odstraňte prázdný placeholder.

Další příklad podporuje oba případy a uloží prezentaci:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("picture-template.pptx");
var slide = presentation.Slides[0];
IShape? picturePlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type == PlaceholderType.Picture)
    {
        picturePlaceholder = shape;
        break;
    }
}

if (picturePlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a picture placeholder.");
}

var imageBytes = File.ReadAllBytes("replacement.png");
var image = presentation.Images.AddImage(imageBytes);

if (picturePlaceholder is IPictureFrame pictureFrame)
{
    pictureFrame.PictureFormat.Picture.Image = image;
}
else
{
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, picturePlaceholder.X, picturePlaceholder.Y, picturePlaceholder.Width, picturePlaceholder.Height, image);
    slide.Shapes.Remove(picturePlaceholder);
}

presentation.Save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
```

Nahrazení vytvořené pro prázdný placeholder je lokální obrázkový rámec, nikoli nový placeholder, protože [IShape.Placeholder](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/placeholder/) je jen pro čtení. Uchovává vyhrazenou pozici, ale nezdědí již chování specifické pro placeholder. Pokud je zachování vztahu k placeholderu podstatné, připravte a vyplňte placeholder v PowerPointu nejprve a poté aktualizujte vzniklý [IPictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/ipictureframe/) pomocí Aspose.Slides.

Pro průhlednost obrázku, oříznutí a další efekty specifické pro obrázek viz [Manage Picture Frames](/slides/cs/net/picture-frame/). Tyto operace patří k obrázkovému rámci nebo výplni obrázku, nikoli k metadatům placeholderu.

## **Práce s grafovými a obsahovými placeholdery**

Vyplněný grafový placeholder může být reprezentován pomocí [IChart](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichart/). Tento příklad najde takový graf pomocí typu placeholderu i runtime rozhraní, změní jeho nadpis a uloží soubor:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-template.pptx");
var slide = presentation.Slides[0];
IChart? placeholderChart = null;

foreach (var shape in slide.Shapes)
{
    if (shape is IChart chart && shape.Placeholder?.Type == PlaceholderType.Chart)
    {
        placeholderChart = chart;
        break;
    }
}

if (placeholderChart == null)
{
    throw new InvalidOperationException("The first slide does not contain a populated chart placeholder.");
}

placeholderChart.HasTitle = true;
placeholderChart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
presentation.Save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
```

Obecný obsahový placeholder má obvykle [PlaceholderType.Object](https://reference.aspose.com/slides/cs/net/aspose.slides/placeholdertype/). V PowerPointu funguje jako spouštěč pro několik typů obsahu, včetně grafů, tabulek, diagramů, obrázků a médií. Po jeho vyplnění zkontrolujte skutečné rozhraní tvaru, abyste zjistili, co obsahuje. Specializovaná rozvržení mohou také vystavovat [PlaceholderType.Chart](https://reference.aspose.com/slides/cs/net/aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/cs/net/aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/cs/net/aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/cs/net/aspose.slides/placeholdertype/), nebo [PlaceholderType.Diagram](https://reference.aspose.com/slides/cs/net/aspose.slides/placeholdertype/).

Aspose.Slides nepřetvoří prázdný [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) placeholder na [IChart](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichart/) pouhým změněním [IPlaceholder.Type](https://reference.aspose.com/slides/cs/net/aspose.slides/iplaceholder/type/); typ je jen pro čtení. Pro naplnění prázdného grafu nebo obsahové oblasti programově přidejte požadovaný objekt na souřadnice placeholderu a potom odstraňte prázdný placeholder. Následující příklad to provádí pro graf:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("content-template.pptx");
var slide = presentation.Slides[0];
IShape? targetPlaceholder = null;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder?.Type is PlaceholderType.Chart or PlaceholderType.Object)
    {
        targetPlaceholder = shape;
        break;
    }
}

if (targetPlaceholder == null)
{
    throw new InvalidOperationException("The first slide does not contain a chart or content placeholder.");
}

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, targetPlaceholder.X, targetPlaceholder.Y, targetPlaceholder.Width, targetPlaceholder.Height);
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Quarterly Revenue");
slide.Shapes.Remove(targetPlaceholder);
presentation.Save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
```

Přidaný graf je obyčejný lokální graf. Zabírá oblast placeholderu, ale nezdědí z rozvržení placeholderu. Použijte specializované články o správě grafů [chart management articles](/slides/cs/net/powerpoint-charts/), když potřebujete nahradit kategorie, řady nebo data sešitu.

## **Kompletní příklad: Aktualizace textového nebo obrazového obsahu**

Následující end‑to‑end příklad otevře šablonu, prohledá první snímek a najde buď placeholder nadpisu nebo obrázku, zkontroluje typy placeholderu a tvaru, aktualizuje příslušný obsah a uloží výstup. Příklad úmyslně nepředpokládá index tvaru ani neprovádí přetypování všech placeholderů na stejné rozhraní.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var slide = presentation.Slides[0];
var updated = false;

foreach (var shape in slide.Shapes)
{
    if (shape.Placeholder == null)
    {
        continue;
    }

    var placeholderType = shape.Placeholder.Type;

    if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape is IAutoShape titleShape)
    {
        titleShape.TextFrame.Text = "Quarterly Business Review";
        updated = true;
        break;
    }

    if (placeholderType == PlaceholderType.Picture)
    {
        var imageBytes = File.ReadAllBytes("replacement.png");
        var image = presentation.Images.AddImage(imageBytes);

        if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.PictureFormat.Picture.Image = image;
        }
        else
        {
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, shape.X, shape.Y, shape.Width, shape.Height, image);
            slide.Shapes.Remove(shape);
        }

        updated = true;
        break;
    }
}

if (!updated)
{
    throw new InvalidOperationException("No supported title or picture placeholder was found on the first slide.");
}

presentation.Save("placeholder-content-updated.pptx", SaveFormat.Pptx);
```

## **Často kladené otázky**

**Co je základní placeholder?**

Základní placeholder je odpovídající tvar na rozvržení nebo masteru, ze kterého další placeholder dědí. Použijte [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/getbaseplaceholder/) k jeho získání. Běžný lokální tvar vrací `null`, protože není součástí hierarchie placeholderů.

**Mohu změnit všechny nadpisy snímků úpravou placeholderu v rozvržení?**

Můžete změnit děděné formátování nebo výzvu přes rozvržení, ale existující text nadpisu je uložen na normálních snímcích. Pro nahrazení skutečného textu nadpisu v celé prezentaci iterujte přes snímky a aktualizujte každý placeholder nadpisu.

**Jak spravovat placeholdery data, čísla snímku, záhlaví a zápatí?**

Použijte správce záhlaví a zápatí na úrovni příslušného snímku, rozvržení, masteru, poznámek nebo výstupu. Viz [Manage Presentation Header and Footer](/slides/cs/net/presentation-header-and-footer/) pro kompletní příklady.