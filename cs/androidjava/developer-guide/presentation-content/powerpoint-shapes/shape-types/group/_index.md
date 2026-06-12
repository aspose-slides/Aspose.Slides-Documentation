---
title: Skupinové tvary v prezentaci na Androidu
linktitle: Skupina tvarů
type: docs
weight: 40
url: /cs/androidjava/group/
keywords:
- skupinový tvar
- skupina tvarů
- přidat skupinu
- alternativní text
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se seskupovat a rozebírat tvary v prezentacích PowerPoint pomocí Aspose.Slides pro Android — rychlý, krok za krokem průvodce s volným Java kódem."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat se skupinovými tvary v Aspose.Slides. Ukazuje, jak přidat skupinový tvar do snímku, umístit do něj tvary a uložit aktualizovanou prezentaci. Také demonstruje, jak přistupovat k tvarům uloženým ve skupině a číst jejich hodnoty `AlternativeText`. Navíc článek stručně popisuje související možnosti skupinových tvarů, jako jsou vnořené skupiny, z‑pořadí a možnosti zamykání.

## **Přidání skupinového tvaru**
Aspose.Slides podporuje práci se skupinovými tvary na snímcích. Tato funkce pomáhá vývojářům vytvářet bohatší prezentace. Aspose.Slides for Android via Java podporuje přidávání a přístup ke skupinovým tvarům. Je možné přidávat tvary do přidaného skupinového tvaru, aby byl naplněn, nebo přistupovat k jakékoli jeho vlastnosti. Pro přidání skupinového tvaru do snímku pomocí Aspose.Slides for Android via Java:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Získejte referenci na snímek pomocí jeho Indexu.
1. Přidejte skupinový tvar do snímku.
1. Přidejte tvary do přidaného skupinového tvaru.
1. Uložte upravenou prezentaci jako soubor PPTX.

Příklad níže přidává skupinový tvar do snímku.

```java
// Vytvoření instance třídy Presentation
Presentation pres = new Presentation();
try {
    // Získání prvního snímku
    ISlide sld = pres.getSlides().get_Item(0);

    // Přístup ke kolekci tvarů snímků
    IShapeCollection slideShapes = sld.getShapes();

    // Přidání skupinového tvaru na snímek
    IGroupShape groupShape = slideShapes.addGroupShape();
    
    // Přidání tvarů do přidaného skupinového tvaru
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100);
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100);

    // Přidání rámce skupinového tvaru
    groupShape.setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool.False, NullableBool.False, 0));

    // Zapsání souboru PPTX na disk
    pres.save("GroupShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přístup k vlastnosti AltText**
Toto téma ukazuje jednoduché kroky, včetně ukázek kódu, pro přidání skupinového tvaru a přístup k vlastnosti AltText skupinových tvarů na snímcích. Pro přístup k AltText skupinového tvaru v snímku pomocí Aspose.Slides for Android via Java:

1. Instanciujte třídu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) reprezentující soubor PPTX.
1. Získejte referenci na snímek pomocí jeho Indexu.
1. Získejte kolekci tvarů snímků.
1. Získejte skupinový tvar.
1. Získejte vlastnost [AlternativeText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#getAlternativeText--).

Příklad níže přistupuje k alternativnímu textu skupinového tvaru.

```java
// Vytvoření instance třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation("AltText.pptx");
try {
    // Získání prvního snímku
    ISlide sld = pres.getSlides().get_Item(0);
    
    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        // Přístup ke kolekci tvarů snímků
        IShape shape = sld.getShapes().get_Item(i);
    
        if (shape instanceof GroupShape)
        {
            // Přístup ke skupinovému tvaru.
            IGroupShape grphShape = (IGroupShape)shape;
            for (int j = 0; j < grphShape.getShapes().size(); j++)
            {
                IShape shape2 = grphShape.getShapes().get_Item(j);
                
                // Přístup k vlastnosti AltText
                System.out.println(shape2.getAlternativeText());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Je podporováno vnořené seskupování (skupina uvnitř skupiny)?**

Ano. [GroupShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/groupshape/) má metodu [getParentGroup](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getParentGroup--) , která přímo naznačuje podporu hierarchie (skupina může být podřazená jiné skupině).

**Jak mohu ovládat z‑pořadí skupiny vzhledem k ostatním objektům na snímku?**

Použijte metodu [getZOrderPosition](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getZOrderPosition--) třídy [GroupShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/groupshape/) k prozkoumání její pozice v zásobníku zobrazení.

**Mohu zabránit přesunu/upravování/odskupování?**

Ano. Sekce zamykání skupiny je dostupná přes [getGroupShapeLock](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/groupshape/#getGroupShapeLock--) , což umožňuje omezit operace prováděné na objektu.