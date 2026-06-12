---
title: Přidání tvarů čar do prezentací v JavaScriptu
linktitle: Čára
type: docs
weight: 50
url: /cs/nodejs-java/line/
keywords:
- čára
- vytvořit čáru
- přidat čáru
- prostá čára
- konfigurovat čáru
- přizpůsobit čáru
- styl čárkování
- šipka
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se manipulovat s formátováním čar v prezentacích PowerPoint pomocí JavaScriptu a Aspose.Slides pro Node.js. Objevte vlastnosti, metody a příklady."
---
## **Přehled**

Aspose.Slides vám umožňuje programově přidávat tvary čar do snímků PowerPoint. Tento článek ukazuje, jak vytvořit jednoduchou čáru a jak ji přizpůsobit tak, aby vypadala jako šipka.

Dozvíte se, jak přidat tvar čáry do snímku, upravit jeho vizuální podobu a uložit aktualizovanou prezentaci. Příklady se zaměřují na praktická nastavení formátování čáry, jako jsou styl, šířka, vzor čárkování, možnosti šípky a barva výplně.

## **Vytvoření prosté čáry**

Chcete-li do vybraného snímku prezentace přidat jednoduchou prostou čáru, postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
- Získejte referenci na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Line pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) poskytované objektem [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection).
- Uložte upravenou prezentaci jako soubor PPTX.

V níže uvedeném příkladu jsme přidali čáru na první snímek prezentace.

```javascript
// Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získejte první snímek
    var sld = pres.getSlides().get_Item(0);
    // Přidejte AutoShape typu čáry
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Uložte PPTX na disk
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vytvoření čáry ve tvaru šipky**

Aspose.Slides pro Node.js přes Java také umožňuje vývojářům konfigurovat některé vlastnosti čáry, aby vypadala atraktivněji. Zkusme nakonfigurovat několik vlastností čáry, aby vypadala jako šipka. Postupujte podle níže uvedených kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
- Získejte referenci na snímek pomocí jeho Indexu.
- Přidejte AutoShape typu Line pomocí metody [addAutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) poskytované objektem [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection).
- Nastavte [Line Style](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/LineStyle) na jeden ze stylů nabízených v Aspose.Slides pro Node.js přes Java.
- Nastavte šířku čáry.
- Nastavte [Dash Style](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/LineDashStyle) čáry na jeden ze stylů nabízených v Aspose.Slides pro Node.js přes Java.
- Nastavte [Arrow Head Style](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/LineArrowheadStyle) a [Length](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/LineArrowheadLength) počátečního bodu čáry.
- Nastavte [Arrow Head Style](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/LineArrowheadStyle) a [Length](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/LineArrowheadLength) koncového bodu čáry.
- Uložte upravenou prezentaci jako soubor PPTX.

```javascript
// Vytvořte instanci třídy PresentationEx, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získejte první snímek
    var sld = pres.getSlides().get_Item(0);
    // Přidejte AutoShape typu čáry
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    // Aplikujte nějaké formátování na čáru
    shp.getLineFormat().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);
    shp.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    shp.getLineFormat().setBeginArrowheadLength(aspose.slides.LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(aspose.slides.LineArrowheadStyle.Oval);
    shp.getLineFormat().setEndArrowheadLength(aspose.slides.LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Maroon));
    // Uložte PPTX na disk
    pres.save("LineShape.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Mohu běžnou čáru převést na spojku, aby se „přichytávala“ k objektům?**

Ne. Běžná čára ([AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapetype/)) se automaticky nepřemění na spojku. Chcete‑li, aby se přichytávala k objektům, použijte speciální typ [Connector](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/connector/) a [odpovídající API](/slides/cs/nodejs-java/connector/) pro spojení.

**Co mám dělat, pokud jsou vlastnosti čáry zděděny z motivu a je obtížné určit konečné hodnoty?**

[Přečtěte si efektivní vlastnosti](/slides/cs/nodejs-java/shape-effective-properties/) pomocí tříd `ILineFormatEffectiveData`/`ILineFillFormatEffectiveData` — ty již zohledňují dědičnost a styly motivu.

**Mohu čáru uzamknout proti úpravám (přesunu, změně velikosti)?**

Ano. Objekty poskytují [lock objects](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/getautoshapelock/), které umožňují zakázat operace úprav.