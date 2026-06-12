---
title: Přidání tvarů čar do prezentací na Androidu
linktitle: Čára
type: docs
weight: 50
url: /cs/androidjava/Line/
keywords:
- čára
- vytvořit čáru
- přidat čáru
- obyčejná čára
- konfigurovat čáru
- přizpůsobit čáru
- styl čárkování
- špička šipky
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se manipulovat s formátováním čar v prezentacích PowerPoint pomocí Aspose.Slides pro Android. Objevte vlastnosti, metody a příklady v jazyce Java."
---
## **Přehled**

Aspose.Slides vám umožňuje programově přidávat tvary čar do snímků PowerPoint. Tento článek ukazuje, jak vytvořit jednoduchou čáru a jak ji upravit tak, aby vypadala jako šipka.

Dozvíte se, jak přidat tvar čáry do snímku, upravit jeho vizuální vzhled a uložit aktualizovanou prezentaci. Příklady se zaměřují na praktická nastavení formátování čáry, jako je styl, šířka, vzor čárkování, možnosti špiček šipky a barva výplně.

## **Vytvoření obyčejné čáry**

Chcete‑li do vybraného snímku prezentace přidat jednoduchou obyčejnou čáru, postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Line pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) vystavené objektu [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection).
- Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali čáru na první snímek prezentace.

```java
// Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získat první snímek
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Přidejte AutoShape typu line
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Uložte PPTX na disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vytvoření čáry ve tvaru šipky**

Aspose.Slides pro Android přes Java také umožňuje vývojářům konfigurovat některé vlastnosti čáry, aby vypadala atraktivněji. Zkusíme nastavit několik vlastností čáry, aby připomínala šipku. Postupujte podle následujících kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
- Získejte odkaz na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Line pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) vystavené objektu [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection).
- Nastavte [Line Style](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/LineStyle) na jeden ze stylů nabízených Aspose.Slides pro Android přes Java.
- Nastavte šířku čáry.
- Nastavte [Dash Style](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/LineDashStyle) čáry na jeden ze stylů nabízených Aspose.Slides pro Android přes Java.
- Nastavte [Arrow Head Style](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/LineArrowheadStyle) a [Length](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/LineArrowheadLength) počátečního bodu čáry.
- Nastavte [Arrow Head Style](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/LineArrowheadStyle) a [Length](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/LineArrowheadLength) koncového bodu čáry.
- Zapište upravenou prezentaci jako soubor PPTX.

```java
// Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získat první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidat AutoShape typu line
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Aplikovat nějaké formátování na čáru
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Uložit PPTX na disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Mohu převést obyčejnou čáru na spojku, aby „zachytila“ tvary?**

Ne. Obyčejná čára ( [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shapetype/) ) se automaticky nepromění na spojku. Chcete‑li, aby se přichytávala k tvarům, použijte speciální typ [Connector](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/connector/) a [příslušná API](/slides/cs/androidjava/connector/) pro spojení.

**Co mám dělat, když jsou vlastnosti čáry zděděny z motivu a obtížně zjistím konečné hodnoty?**

Přečtěte si účinné vlastnosti [/slides/cs/androidjava/shape-effective-properties/](/slides/cs/androidjava/shape-effective-properties/) prostřednictvím rozhraní [ILineFormatEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilinefillformateffectivedata/), která již zohledňují dědičnost a styly motivu.

**Mohu zamknout čáru proti úpravám (přesouvání, změna velikosti)?**

Ano. Tvary poskytují [lock objects](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) umožňující zakázat operace úprav.