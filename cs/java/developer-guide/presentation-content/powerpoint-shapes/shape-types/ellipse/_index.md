---
title: Přidání elips do prezentací v Javě
linktitle: Elipsa
type: docs
weight: 30
url: /cs/java/ellipse/
keywords:
- elipsa
- tvar
- přidat elipsu
- vytvořit elipsu
- nakreslit elipsu
- formátovaná elipsa
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se vytvářet, formátovat a manipulovat s elipsovými tvary v Aspose.Slides pro Javu v prezentacích PPT a PPTX — příklady kódu v Javě jsou zahrnuty."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Slides přidat elipsové tvary do snímků PowerPointu. Popisuje vytvoření jednoduché elipsy, vytvoření formátované elipsy a uložení aktualizované prezentace jako soubor PPTX. Také se zabývá souvisejícími otázkami, jako je práce s pozicí a velikostí elipsy, řízení pořadí vrstvení a použití animačních efektů.

## **Vytvoření elipsy**
Chcete‑li přidat jednoduchou elipsu na vybraný snímek prezentace, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
- Získejte referenci na snímek pomocí jeho indexu.
- Přidejte AutoShape typu Ellipse pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) vystavené objektem [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection).
- Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali elipsu na první snímek

```java
// Vytvořte instanci třídy Presentation, která představuje PPTX
Presentation pres = new Presentation();
try {
    // Získejte první snímek
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Přidejte AutoShape typu elipsa
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // Uložte soubor PPTX na disk
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vytvoření formátované elipsy**
Chcete‑li přidat lépe formátovanou elipsu na snímek, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
- Získejte referenci na snímek pomocí jeho indexu.
- Přidejte AutoShape typu Ellipse pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) vystavené objektem [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection).
- Nastavte typ výplně elipsy na Solid.
- Nastavte barvu elipsy pomocí vlastnosti SolidFillColor.Color, kterou poskytuje objekt [FillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IFillFormat) spojený s objektem [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape).
- Nastavte barvu čar elipsy.
- Nastavte šířku čar elipsy.
- Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali formátovanou elipsu na první snímek prezentace.

```java
// Vytvořte instanci třídy Presentation, která představuje PPTX
Presentation pres = new Presentation();
try {
    // Získejte první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidejte AutoShape typu elipsa
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // Použijte nějaké formátování na tvar elipsy
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // Použijte nějaké formátování na čáru elipsy
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Uložte soubor PPTX na disk
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Jak nastavit přesnou pozici a velikost elipsy vzhledem k jednotkám snímku?**

Souřadnice a rozměry se obvykle uvádějí **v bodech**. Pro předvídatelné výsledky založte své výpočty na velikosti snímku a před přiřazením hodnot převádějte požadované milimetry nebo palce na body.

**Jak mohu umístit elipsu nad nebo pod jiné objekty (ovládání pořadí vrstvení)?**

Upravte pořadí kreslení objektu tím, že jej přenesete dopředu nebo dozadu. Tím umožníte, aby elipsa překryla jiné objekty nebo odhalila ty pod ní.

**Jak mohu animovat vzhled nebo zdůraznění elipsy?**

[Použít](/slides/cs/java/shape-animation/) vstupní, zvýrazňovací nebo ukončovací efekty na tvar a nakonfigurujte spouštěče a časování, aby bylo určeno, kdy a jak se animace přehraje.