---
title: Přidání čarových tvarů do prezentací v Javě
linktitle: Čára
type: docs
weight: 50
url: /cs/java/line/
keywords:
- čára
- vytvořit čáru
- přidat čáru
- prostá čára
- konfigurovat čáru
- přizpůsobit čáru
- styl čerchování
- hlava šipky
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se manipulovat s formátováním čar v prezentacích PowerPoint pomocí Aspose.Slides pro Java. Objevte vlastnosti, metody a příklady."
---
## **Přehled**

Aspose.Slides vám umožňuje programově přidávat čárové objekty do snímků PowerPointu. Tento článek ukazuje, jak vytvořit jednoduchou čáru a jak ji přizpůsobit tak, aby vypadala jako šipka.

Dozvíte se, jak přidat čárový objekt do snímku, upravit jeho vizuální vzhled a uložit aktualizovanou prezentaci. Příklady se zaměřují na praktická nastavení formátování čáry, jako jsou styl, šířka, vzor čerchování, možnosti šípky a barva výplně.

## **Vytvoření prosté čáry**

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) .
- Získejte odkaz na snímek pomocí jeho indexu.
- Přidejte AutoShape typu Line pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) vystavené objektem [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection) .
- Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali čáru na první snímek prezentace.

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

## **Vytvoření čáry se šipkou**

Aspose.Slides pro Java také umožňuje vývojářům konfigurovat některé vlastnosti čáry, aby vypadala atraktivněji. Zkusme nakonfigurovat několik vlastností čáry, aby vypadala jako šipka. Postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation) .
- Získejte odkaz na snímek pomocí jeho indexu.
- Přidejte AutoShape typu Line pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) vystavené objektem [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection) .
- Nastavte [Line Style](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LineStyle) na jeden ze stylů nabízených Aspose.Slides pro Java.
- Nastavte šířku čáry.
- Nastavte [Dash Style](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LineDashStyle) čáry na jeden ze stylů nabízených Aspose.Slides pro Java.
- Nastavte [Arrow Head Style](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LineArrowheadStyle) a [Length](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LineArrowheadLength) počátečního bodu čáry.
- Nastavte [Arrow Head Style](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LineArrowheadStyle) a [Length](https://reference.aspose.com/slides/cs/java/com.aspose.slides/LineArrowheadLength) koncového bodu čáry.
- Zapište upravenou prezentaci jako soubor PPTX.

```java
// Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získejte první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidejte AutoShape typu čára
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Použijte některé formátování na čáru
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

## **Často kladené dotazy**

**Mohu převést běžnou čáru na konektor, aby se "přichytával" k objektům?**

Ne. Běžná čára ([AutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shapetype/)) se automaticky nepřemění na konektor. Pro přichytávání k objektům použijte dedikovaný typ [Connector](https://reference.aspose.com/slides/cs/java/com.aspose.slides/connector/) a [příslušná API](/slides/cs/java/connector/) pro spojení.

**Co mám dělat, pokud jsou vlastnosti čáry zděděny z motivu a je obtížné určit konečné hodnoty?**

[Přečtěte si efektivní vlastnosti](/slides/cs/java/shape-effective-properties/) prostřednictvím rozhraní [ILineFormatEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilinefillformateffectivedata/), která již zohledňují dědičnost a styly motivu.

**Mohu zamknout čáru proti úpravám (posunu, změně velikosti)?**

Ano. Objekty poskytují [lock objects](https://reference.aspose.com/slides/cs/java/com.aspose.slides/autoshape/#getAutoShapeLock--) , které vám umožní [zakázat operace úprav](/slides/cs/java/applying-protection-to-presentation/).