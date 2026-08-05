---
title: Přidání tvarů čar do prezentací na Androidu
linktitle: Čára
type: docs
weight: 50
url: /cs/androidjava/line/
keywords:
- čára
- vytvořit čáru
- přidat čáru
- prostá čára
- konfigurovat čáru
- přizpůsobit čáru
- styl čárkování
- hlava šipky
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se manipulovat s formátováním čar v prezentacích PowerPoint pomocí Aspose.Slides pro Android. Objevte vlastnosti, metody a ukázky v jazyce Java."
---
## **Přehled**

Aspose.Slides vám umožňuje programově přidávat tvary čar do snímků PowerPoint. Tento článek ukazuje, jak vytvořit jednoduchou čáru a jak ji přizpůsobit tak, aby vypadala jako šipka.

Dozvíte se, jak přidat tvar čáry do snímku, upravit jeho vizuální vzhled a uložit aktualizovanou prezentaci. Příklady se soustředí na praktická nastavení formátování čar, jako jsou styl, šířka, vzor čárkování, možnosti špičky šipky a barva výplně.

## **Vytvoření prosté čáry**

Chcete-li do vybraného snímku prezentace přidat jednoduchou prostou čáru, postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
- Získejte referenci na snímek pomocí jeho indexu.
- Přidejte AutoShape typu Line pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exponované objektem [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection).
- Zapište upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali čáru na první snímek prezentace.

```java
// Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získat první snímek
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Přidat AutoShape typu čára
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // Zapsat PPTX na disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vytvoření čáry ve tvaru šipky**

Aspose.Slides pro Android přes Java také umožňuje vývojářům konfigurovat některé vlastnosti čáry, aby vypadala atraktivněji. Zkusme nakonfigurovat několik vlastností čáry, aby vypadala jako šipka. Postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
- Získejte referenci na snímek pomocí jeho indexu.
- Přidejte AutoShape typu Line pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) exponované objektem [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection).
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

    // Přidat AutoShape typu čára
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // Použít některé formátování na čáru
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // Zapsat PPTX na disk
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Mohu převést běžnou čáru na konektor, aby se „přichytával“ k tvarům?**

Ne. Běžná čára ( [AutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shapetype/)) se automaticky nepřemění na konektor. Chcete-li, aby se přichytávala k tvarům, použijte speciální typ [Connector](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/connector/) a [corresponding APIs](/slides/cs/androidjava/connector/) pro spojení.

**Co mám dělat, pokud jsou vlastnosti čáry zděděny z motivu a je obtížné určit konečné hodnoty?**

[Read the effective properties](/slides/cs/androidjava/shape-effective-properties/) prostřednictvím rozhraní [ILineFormatEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilinefillformateffectivedata/) — tato již zohledňují dědičnost a styly motivu.

**Mohu zamknout čáru proti úpravám (přesunutí, změna velikosti)?**

Ano. Tvary poskytují [lock objects](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) , které umožňují zakázat operace úprav.