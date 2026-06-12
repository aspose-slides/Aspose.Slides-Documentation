---
title: Hlavní snímek
type: docs
weight: 30
url: /cs/net/examples/elements/master-slide/
keywords:
- hlavní snímek
- přidat hlavní snímek
- přístup k hlavnímu snímku
- odstranit hlavní snímek
- nepoužitý hlavní snímek
- ukázka kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte příklady hlavních snímků Aspose.Slides pro .NET: vytvářejte, upravujte a stylizujte hlavní snímky, zástupné prvky a motivy v PPT, PPTX a ODP s přehledným kódem v C#."
---
Master slidey tvoří nejvyšší úroveň hierarchie dědičnosti snímků v PowerPointu. **master slide** definuje společné designové prvky, jako jsou pozadí, loga a formátování textu. **layout slidey** dědí z master slideů a **normální slidey** dědí z layout slideů.

Tento článek ukazuje, jak vytvořit, upravit a spravovat master slidey pomocí Aspose.Slides for .NET.

## **Přidat master slide**

Tento příklad ukazuje, jak vytvořit nový master slide klonováním výchozího. Poté přidá banner s názvem společnosti ke všem snímkům prostřednictvím dědičnosti layoutu.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // Klonujte výchozí hlavní snímek.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // Přidejte banner s názvem společnosti na horní část hlavního snímku.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Přiřaďte nový hlavní snímek k rozložení snímku.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // Přiřaďte rozložení snímku k prvnímu snímku v prezentaci.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Poznámka 1:** Master slidey poskytují způsob, jak aplikovat jednotné značení nebo sdílené designové prvky na všechny snímky. Jakékoli změny provedené v masteru se automaticky projeví na závislých layoutových a normálních slidech.
> 💡 **Poznámka 2:** Veškeré tvary nebo formátování přidané do master slide se dědí do layout slideů a následně do všech normálních slideů používajících tyto layouty.
> Obrázek níže ilustruje, jak je textové pole přidané do master slide automaticky vykresleno na finálním snímku.

![Příklad dědičnosti master slide](master-slide-banner.png)

## **Přístup k master slide**

K master slidlům můžete přistupovat pomocí kolekce `Presentation.Masters`. Zde je návod, jak je získat a pracovat s nimi:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // Přístup k prvnímu hlavnímu snímku.
    var firstMasterSlide = presentation.Masters[0];

    // Změnit typ pozadí.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Odstranit master slide**

Master slidey lze odstranit buď podle indexu, nebo podle reference.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // Odstraňte hlavní snímek podle indexu.
    presentation.Masters.RemoveAt(0);

    // Odstraňte hlavní snímek podle reference.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **Odstranit nepoužívané master slidey**

Některá prezentace obsahují master slidey, které nejsou používány. Odstranění těchto slideů může pomoci zmenšit velikost souboru.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // Odstraňte všechny nepoužívané hlavní snímky (i ty označené jako Preserve).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```