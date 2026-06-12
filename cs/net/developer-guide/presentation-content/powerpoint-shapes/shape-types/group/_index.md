---
title: Skupinové tvary v prezentaci .NET
linktitle: Skupina tvarů
type: docs
weight: 40
url: /cs/net/group/
keywords:
- skupinový tvar
- skupina tvarů
- přidat skupinu
- alternativní text
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se seskupovat a rozdělovat tvary v prezentacích PowerPoint pomocí Aspose.Slides pro .NET—rychlý, krok za krokem průvodce s ukázkovým C# kódem zdarma."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat se skupinovými tvary v Aspose.Slides. Ukazuje, jak přidat skupinový tvar do snímku, umístit do něj další tvary a uložit aktualizovanou prezentaci. Také demonstruje, jak získat přístup k tvarům uloženým ve skupině a přečíst jejich hodnoty `AlternativeText`. Navíc článek stručně popisuje související možnosti skupinových tvarů, jako jsou vnořené skupiny, z‑order a možnosti zamčení.

## **Přidat skupinový tvar**
Aspose.Slides podporuje práci se skupinovými tvary na snímcích. Tato funkce pomáhá vývojářům vytvářet bohatší prezentace. Aspose.Slides pro .NET podporuje přidávání a přístup ke skupinovým tvarům. Je možné přidávat tvary do přidaného skupinového tvaru, aby se naplnil, nebo přistupovat k jakékoli jeho vlastnosti. Pro přidání skupinového tvaru do snímku pomocí Aspose.Slides pro .NET:

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Získejte referenci na snímek pomocí jeho Index.
1. Přidejte skupinový tvar do snímku.
1. Přidejte tvary do přidaného skupinového tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Příklad níže přidá skupinový tvar do snímku.

```c#
// Instancujte třídu Presentation 
using (Presentation pres = new Presentation())
{
    // Získejte první snímek 
    ISlide sld = pres.Slides[0];

    // Přístup ke kolekci tvarů snímku 
    IShapeCollection slideShapes = sld.Shapes;

    // Přidání skupinového tvaru do snímku 
    IGroupShape groupShape = slideShapes.AddGroupShape();

    // Přidání tvarů do přidaného skupinového tvaru 
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Přidání rámce skupinového tvaru 
    groupShape.Frame = new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0);

    // Zapište soubor PPTX na disk 
    pres.Save("GroupShape_out.pptx", SaveFormat.Pptx);
}
```

## **Přístup k vlastnosti AltText**
Toto téma ukazuje jednoduché kroky, doplněné ukázkami kódu, pro přidání skupinového tvaru a přístup k vlastnosti AltText skupinových tvarů na snímcích. Pro přístup k AltTextu skupinového tvaru ve snímku pomocí Aspose.Slides pro .NET:

1. Vytvořte instanci třídy `Presentation`, která představuje soubor PPTX.
1. Získejte referenci na snímek pomocí jeho Index.
1. Přístup ke kolekci tvarů snímků.
1. Přístup ke skupinovému tvaru.
1. Přístup k vlastnosti AltText.

Příklad níže získá alternativní text skupinového tvaru.

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation("AltText.pptx");

// Získejte první snímek
ISlide sld = pres.Slides[0];

for (int i = 0; i < sld.Shapes.Count; i++)
{
    // Přístup ke kolekci tvarů snímku
    IShape shape = sld.Shapes[i];

    if (shape is GroupShape)
    {
        // Přístup ke skupinovému tvaru.
        IGroupShape grphShape = (IGroupShape)shape;
        for (int j = 0; j < grphShape.Shapes.Count; j++)
        {
            IShape shape2 = grphShape.Shapes[j];
            // Přístup k vlastnosti AltText
            Console.WriteLine(shape2.AlternativeText);
        }
    }
}
```

## **Často kladené otázky**

**Je podporováno vnořené seskupování (skupina uvnitř skupiny)?**

Ano. [GroupShape](https://reference.aspose.com/slides/cs/net/aspose.slides/groupshape/) má vlastnost [ParentGroup](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/parentgroup/), která přímo naznačuje podporu hierarchie (skupina může být podřízena jiné skupině).

**Jak mohu řídit z‑order skupiny vzhledem k ostatním objektům na snímku?**

Použijte vlastnost [ZOrderPosition](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/zorderposition/) třídy [GroupShape](https://reference.aspose.com/slides/cs/net/aspose.slides/groupshape/) k prozkoumání její pozice v zásobníku zobrazení.

**Mohu zabránit přesunu/úpravám/rozbalení skupiny?**

Ano. Sekce zamčení skupiny je přístupná přes [GroupShapeLock](https://reference.aspose.com/slides/cs/net/aspose.slides/groupshape/groupshapelock/), která vám umožní omezit operace s objektem.