---
title: Rozvržení snímku
type: docs
weight: 20
url: /cs/net/examples/elements/layout-slide/
keywords:
- rozvržení snímku
- přidat rozvržení snímku
- přístup k rozvržení snímku
- odstranit rozvržení snímku
- nepoužité rozvržení snímku
- klonovat rozvržení snímku
- příklad kódu
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Hlavní rozvržení snímků v Aspose.Slides pro .NET: vyberte, použijte a přizpůsobte rozvržení snímků, zástupné objekty a hlavní šablony s příklady C# pro prezentace PPT, PPTX a ODP."
---
Tento článek demonstruje, jak pracovat s **Layout Slides** v Aspose.Slides pro .NET. Rozvržení snímku (layout slide) definuje design a formátování, které dědí běžné snímky. Můžete přidávat, přistupovat, klonovat a odstraňovat rozvržení snímků, a také čistit nepoužívané, aby se snížila velikost prezentace.

## **Přidat rozvržení snímku**

Můžete vytvořit vlastní rozvržení snímku pro definování opakovaně použitelného formátování. Například můžete přidat textové pole, které se zobrazí na všech snímcích používajících toto rozvržení.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Vytvořte rozvržení snímku s prázdným typem rozvržení a vlastním názvem.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Přidejte textové pole do rozvržení snímku.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Přidejte dva snímky pomocí tohoto rozvržení; oba zdědí text z rozvržení.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Note 1:** Rozvržení snímků fungují jako šablony pro jednotlivé snímky. Můžete definovat společné prvky jednou a znovu je použít na mnoha snímcích.

> 💡 **Note 2:** Když přidáte tvary nebo text do rozvržení snímku, všechny snímky založené na tomto rozvržení automaticky zobrazí tento sdílený obsah.
> Následující snímek ukazuje dva snímky, z nichž každý dědí textové pole ze stejného rozvržení snímku.

![Snímky dědící obsah rozvržení](layout-slide-result.png)

## **Přístup k rozvržení snímku**

Rozvržení snímků lze přistupovat podle indexu nebo podle typu rozvržení (např. `Blank`, `Title`, `SectionHeader` atd.).

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Přístup k rozvržení snímku podle indexu.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Přístup k rozvržení snímku podle typu.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Odstranit rozvržení snímku**

Můžete odstranit konkrétní rozvržení snímku, pokud již není potřeba.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Získejte rozvržení snímku podle typu a odstraňte jej.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Odstranit nepoužívaná rozvržení snímků**

Pro snížení velikosti prezentace můžete chtít odstranit rozvržení snímků, která nejsou použita žádnými běžnými snímky.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Automaticky odstraňuje všechna rozvržení snímků, která nejsou referencována žádným snímkem.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Klonovat rozvržení snímku**

Můžete duplikovat rozvržení snímku pomocí metody `AddClone`.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Získejte existující rozvržení snímku podle typu.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Klonujte rozvržení snímku na konec kolekce rozvržení snímků.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Summary:** Rozvržení snímků jsou výkonným nástrojem pro správu jednotného formátování napříč snímky. Aspose.Slides poskytuje plnou kontrolu nad vytvářením, správou a optimalizací rozvržení snímků.