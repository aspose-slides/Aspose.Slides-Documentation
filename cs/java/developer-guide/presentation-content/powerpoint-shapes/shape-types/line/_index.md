---
title: Přidání čárových tvarů do prezentací v Javě
linktitle: Čára
type: docs
weight: 50
url: /cs/java/Line/
keywords:
- čára
- vytvořit čáru
- přidat čáru
- jednoduchá čára
- nastavit čáru
- přizpůsobit čáru
- čárkový styl
- šipková hlava
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se manipulovat s formátováním čar v prezentacích PowerPoint pomocí Aspose.Slides pro Java. Objevte vlastnosti, metody a příklady."
---
## **Přehled**

Aspose.Slides vám umožňuje programově přidávat čárové tvary do snímků PowerPoint. Tento článek ukazuje, jak vytvořit jednoduchou čáru a jak ji upravit tak, aby vypadala jako šipka.

Dozvíte se, jak přidat čárový tvar do snímku, upravit jeho vizuální vzhled a uložit aktualizovanou prezentaci. Příklady se zaměřují na praktické nastavení formátování čáry, jako je styl, šířka, čárkový vzor, možnosti špiček šipek a barva výplně.

## **Vytvoření jednoduché čáry**

Chcete-li přidat jednoduchou čáru do vybraného snímku prezentace, postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
- Získejte referenci na snímek pomocí jeho indexu.
- Přidejte AutoShape typu Line pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposované objektem [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection).
- Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali čáru do prvního snímku prezentace.

```java
// Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získejte první snímek
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Přidejte AutoShape typu čára
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Uložte PPTX na disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vytvoření čáry ve tvaru šipky**

Aspose.Slides pro Java také umožňuje vývojářům nastavit některé vlastnosti čáry, aby vypadala atraktivněji. Zkusme nastavit několik vlastností čáry, aby vypadala jako šipka. Postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
- Získejte referenci na snímek pomocí jeho indexu.
- Přidejte AutoShape typu Line pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exposované objektem [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection).
- Nastavte [Line Style](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LineStyle) na jeden ze stylů nabízených Aspose.Slides pro Java.
- Nastavte šířku čáry.
- Nastavte [Dash Style](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LineDashStyle) čáry na jeden ze stylů nabízených Aspose.Slides pro Java.
- Nastavte [Arrow Head Style](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LineArrowheadStyle) a [Length](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LineArrowheadLength) počátečního bodu čáry.
- Nastavte [Arrow Head Style](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LineArrowheadStyle) a [Length](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LineArrowheadLength) koncového bodu čáry.
- Uložte upravenou prezentaci jako soubor PPTX.

```java
// Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získejte první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidejte AutoShape typu čára
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Aplikujte formátování na čáru
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Uložte PPTX na disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Mohu převést běžnou čáru na spojku, aby se „přichytávala“ k objektům?**

Ne. Běžná čára ( [AutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shapetype/)) se automaticky nepřemění na spojku. Chcete-li, aby se přichytávala k objektům, použijte speciální typ [Connector](https://reference.aspose.com/slides/cs/java/com.aspose.slides/connector/) a [odpovídající API](/slides/cs/java/connector/) pro spojení.

**Co mám dělat, když jsou vlastnosti čáry zděděny z motivu a je obtížné určit konečné hodnoty?**

[Přečtěte si efektivní vlastnosti](/slides/cs/java/shape-effective-properties/) pomocí rozhraní [ILineFormatEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinefillformateffectivedata/) — tato rozhraní již zohledňují dědičnost a styly motivu.

**Mohu zablokovat čáru proti úpravám (přesouvání, změna velikosti)?**

Ano. Objekty poskytují [lock objects](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/#getAutoShapeLock--) které umožňují [zakázat operace úprav](/slides/cs/java/applying-protection-to-presentation/).