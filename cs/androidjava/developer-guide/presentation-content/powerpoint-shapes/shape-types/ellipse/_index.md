---
title: Přidání elips do prezentací na Androidu
linktitle: Elipsa
type: docs
weight: 30
url: /cs/androidjava/ellipse/
keywords:
- elipsa
- tvar
- přidat elipsu
- vytvořit elipsu
- nakreslit elipsu
- formátovaná elipsa
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak vytvářet, formátovat a manipulovat s tvary elips v Aspose.Slides pro Android v prezentacích PPT a PPTX - včetně příkladů kódu v jazyce Java."
---
## **Přehled**

Tento článek ukazuje, jak pomocí Aspose.Slides přidat eliptické tvary do snímků PowerPointu. Popisuje vytvoření jednoduché elipsy, vytvoření formátované elipsy a uložení aktualizované prezentace jako souboru PPTX. Navíc se věnuje souvisejícím otázkám, jako je práce s pozicí a velikostí elipsy, řízení pořadí vrstvení a aplikace animačních efektů.

## **Vytvoření elipsy**
Chcete‑li přidat jednoduchou elipsu na vybraný snímek prezentace, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Ellipse pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposované objektem [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection).
- Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali elipsu na první snímek

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
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

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Ellipse pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposované objektem [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection).
- Nastavte typ výplně elipsy na Solid.
- Nastavte barvu elipsy pomocí vlastnosti SolidFillColor.Color exposované objektem [FillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IFillFormat) přidruženým k objektu [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape).
- Nastavte barvu čar elipsy.
- Nastavte šířku čar elipsy.
- Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali formátovanou elipsu na první snímek prezentace.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
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

**Jak nastavím přesnou pozici a velikost elipsy vzhledem k jednotkám snímku?**

Souřadnice a velikosti se obvykle uvádějí **v bodech**. Pro předvídatelné výsledky proveďte výpočty na základě velikosti snímku a před přiřazením hodnot převedete požadované milimetry nebo palce na body.

**Jak mohu umístit elipsu nad nebo pod jiné objekty (řídit pořadí vrstvení)?**

Upravte pořadí kreslení objektu tím, že jej přenesete dopředu nebo dozadu. To umožní elipse překrývat jiné objekty nebo odhalit objekty pod ní.

**Jak animuji vzhled nebo zdůraznění elipsy?**

[Apply](/slides/cs/androidjava/shape-animation/) vstupní, zvýrazňovací nebo ukončovací efekty na tvar a nakonfigurujte spouštěče a časování, aby bylo zajištěno, kdy a jak se animace přehrává.