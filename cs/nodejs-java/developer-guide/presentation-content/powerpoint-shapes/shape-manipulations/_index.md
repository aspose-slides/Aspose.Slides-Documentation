---
title: Správa tvarů prezentace v JavaScriptu
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/nodejs-java/shape-manipulations/
keywords:
- tvar PowerPoint
- tvar prezentace
- tvar na snímku
- najít tvar
- klonovat tvar
- odstranit tvar
- skrýt tvar
- změnit pořadí tvaru
- získat Interop ID tvaru
- alternativní text tvaru
- formáty rozvržení tvaru
- tvar jako SVG
- tvar na SVG
- zarovnat tvar
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se vytvářet, upravovat a optimalizovat tvary pomocí JavaScriptu a Aspose.Slides pro Node.js prostřednictvím Javy a dodávejte výkonné prezentace v PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s tvary v prezentacích pomocí Aspose.Slides. Ukazuje, jak najít tvar na snímku, klonovat jej, odstranit jej, skrýt jej, změnit jeho pořadí, získat jeho Interop ID tvaru a nastavit alternativní text pro identifikaci a další zpracování.

Dále pokrývá, jak získat přístup k formátům rozvržení pro tvary, vykreslit tvar jako SVG, zarovnat tvary na snímku a použít vlastnosti překlápění pro vodorovné a svislé zrcadlení. Navíc článek obsahuje krátké FAQ o kombinaci tvarů, pořadí vrstev a zamykání tvarů.

## **Najít tvar na snímku**
Toto téma popisuje jednoduchou techniku, která usnadní vývojářům najít konkrétní tvar na snímku bez použití jeho vnitřního Id. Je důležité vědět, že soubory PowerPoint prezentací nemají žádný způsob, jak identifikovat tvary na snímku, kromě vnitřního jedinečného Id. Pro vývojáře je obtížné najít tvar pomocí jeho vnitřního jedinečného Id. Všechny tvary přidané na snímky mají nějaký alternativní text. Doporučujeme vývojářům použít alternativní text pro vyhledání konkrétního tvaru. Můžete použít MS PowerPoint k definování alternativního textu pro objekty, které plánujete v budoucnu měnit.

Po nastavení alternativního textu libovolného požadovaného tvaru můžete otevřít tuto prezentaci pomocí Aspose.Slides pro Node.js prostřednictvím Javy a projít všechny tvary přidané na snímek. Během každé iterace můžete zkontrolovat alternativní text tvaru a tvar s odpovídajícím alternativním textem bude tvar, který potřebujete. Pro lepší demonstraci této techniky jsme vytvořili metodu, [findShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-), která umožňuje najít konkrétní tvar na snímku a jednoduše jej vrátí.

```javascript
// Vytvořte třídu Presentation, která představuje soubor prezentace
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Alternativní text tvaru, který má být nalezen
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **Klonovat tvar**
Pro klonování tvaru na snímek pomocí Aspose.Slides pro Node.js prostřednictvím Javy:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přistupte ke kolekci tvarů zdrojového snímku.
1. Přidejte nový snímek do prezentace.
1. Klonujte tvary z kolekce tvarů zdrojového snímku do nového snímku.
1. Uložte upravenou prezentaci jako soubor PPTX.

Níže uvedený příklad přidává skupinový tvar na snímek.

```javascript
// Vytvořte instanci třídy Presentation
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // Uložte soubor PPTX na disk
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Odstranit tvar**
Aspose.Slides pro Node.js prostřednictvím Javy umožňuje vývojářům odstranit libovolný tvar. Pro odebrání tvaru z libovolného snímku postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Získejte první snímek.
1. Najděte tvar s konkrétním AlternativeText.
1. Odstraňte tvar.
1. Uložte soubor na disk.

```javascript
// Vytvořte objekt Presentation
var pres = new aspose.slides.Presentation();
try {
    // Získejte první snímek
    var sld = pres.getSlides().get_Item(0);
    // Přidejte autoshape typu obdélník
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // Uložte prezentaci na disk
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Skrýt tvar**
Aspose.Slides pro Node.js prostřednictvím Javy umožňuje vývojářům skrýt libovolný tvar. Pro skrytí tvaru na libovolném snímku postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Získejte první snímek.
1. Najděte tvar s konkrétním AlternativeText.
1. Skrýt tvar.
1. Uložte soubor na disk.

```javascript
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získejte první snímek
    var sld = pres.getSlides().get_Item(0);
    // Přidejte autoshape typu obdélník
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // Uložte prezentaci na disk
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Změnit pořadí tvarů**
Aspose.Slides pro Node.js prostřednictvím Javy umožňuje vývojářům změnit pořadí tvarů. Přesunutí tvaru určuje, který tvar je v popředí a který v pozadí. Pro změnu pořadí tvarů na libovolném snímku postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Získejte první snímek.
1. Přidejte tvar.
1. Přidejte nějaký text do textového rámce tvaru.
1. Přidejte další tvar se stejnými souřadnicemi.
1. Změňte pořadí tvarů.
1. Uložte soubor na disk.

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Získat Interop Shape ID**
Aspose.Slides pro Node.js prostřednictvím Javy umožňuje vývojářům získat jedinečný identifikátor tvaru v rozsahu snímku na rozdíl od metody [getUniqueId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getUniqueId--) , která umožňuje získat jedinečný identifikátor v rozsahu celé prezentace. Metoda [getOfficeInteropShapeId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) byla přidána do třídy [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape) a [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape). Hodnota vrácená metodou [getOfficeInteropShapeId](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) odpovídá hodnotě Id objektu Microsoft.Office.Interop.PowerPoint.Shape. Níže je uveden ukázkový kód.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Získání jedinečného identifikátoru tvaru v rámci snímku
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavit alternativní text pro tvar**
Aspose.Slides pro Node.js prostřednictvím Javy umožňuje vývojářům nastavit AlternateText libovolného tvaru. Tvary v prezentaci lze odlišit pomocí metody [AlternativeText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) nebo [Shape Name](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#setName-java.lang.String-). Metody [setAlternativeText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) a [getAlternativeText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getAlternativeText--) lze číst nebo nastavovat pomocí Aspose.Slides i Microsoft PowerPoint. Použitím této metody můžete označit tvar a provádět různé operace, jako je odstraňování tvaru, skrytí tvaru nebo změna pořadí tvarů na snímku. Pro nastavení AlternateText tvaru postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
1. Získejte první snímek.
1. Přidejte libovolný tvar na snímek.
1. Proveďte nějakou práci s nově přidaným tvarem.
1. Projděte tvary a najděte tvar.
1. Nastavte AlternativeText.
1. Uložte soubor na disk.

```javascript
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation();
try {
    // Získejte první snímek
    var sld = pres.getSlides().get_Item(0);
    // Přidejte autoshape typu obdélník
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // Uložte prezentaci na disk
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přístup k formátům rozvržení pro tvar**
Aspose.Slides pro Node.js prostřednictvím Javy poskytuje jednoduché API pro přístup k formátům rozvržení pro tvar. Tento článek ukazuje, jak můžete získat přístup k formátům rozvržení.

Níže je uveden ukázkový kód.

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vykreslit tvar jako SVG**
Nyní Aspose.Slides pro Node.js prostřednictvím Javy podporuje vykreslení tvaru jako SVG. Metoda [writeAsSvg](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) (a její přetížení) byla přidána do třídy [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape). Tato metoda umožňuje uložit obsah tvaru jako soubor SVG. Níže uvedený úryvek kódu ukazuje, jak exportovat tvar ze snímku do SVG souboru.

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zarovnání tvarů**
Aspose.Slides umožňuje zarovnat tvary buď relativně k okrajům snímku, nebo relativně k sobě navzájem. Za tímto účelem byla přidána přetížená metoda [SlidesUtil.alignShape()](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-). Výčtový typ [ShapesAlignmentType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapesAlignmentType) definuje možné možnosti zarovnání.

**Příklad 1**

Níže uvedený zdrojový kód zarovnává tvary s indexy 1, 2 a 4 podél horního okraje snímku.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**Příklad 2**

Níže uvedený příklad ukazuje, jak zarovnat celou kolekci tvarů relativně k nejnižšímu tvaru v kolekci.

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Vlastnosti překlápění**

V Aspose.Slides třída [ShapeFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapeframe/) poskytuje řízení vodorovného a svislého zrcadlení tvarů pomocí vlastností `flipH` a `flipV`. Obě vlastnosti jsou typu `byte` a umožňují hodnoty `1` pro překlápění, `0` pro žádné překlápění nebo `-1` pro výchozí chování. Tyto hodnoty jsou přístupné z [Frame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getFrame) tvaru.

Pro úpravu nastavení překlápění se vytvoří nová instance [ShapeFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapeframe/) s aktuální pozicí a velikostí tvaru, požadovanými hodnotami pro `flipH` a `flipV` a úhlem rotace. Přiřazením této instance k [Frame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getFrame) tvaru a uložením prezentace se aplikují zrcadlové transformace a zapíšou do výstupního souboru.

Předpokládejme, že máme soubor sample.pptx, ve kterém první snímek obsahuje jediný tvar s výchozím nastavením překlápění, jak je zobrazeno níže.

![Tvar k překlopení](shape_to_be_flipped.png)

Následující ukázka kódu získá aktuální vlastnosti překlápění tvaru a přeloží jej vodorovně i svisle.

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // Získejte horizontální překlápěcí vlastnost tvaru.
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // Získejte vertikální překlápěcí vlastnost tvaru.
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // Překlopit vodorovně.
    var flipV = java.newByte(asposeSlides.NullableBool.True); // Překlopit svisle.
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Přeložený tvar](flipped_shape.png)

## **FAQ**

**Mohu kombinovat tvary (sjednocení/průnik/odčerpání) na snímku podobně jako v desktopovém editoru?**

Neexistuje vestavěné API pro Booleovské operace. Můžete to přibližovat vytvořením požadovaného obrysu sami – např. vypočítat výslednou geometrii (pomocí [GeometryPath](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/geometrypath/)) a vytvořit nový tvar s tímto konturem, volitelně odstranit původní.

**Jak mohu řídit pořadí vrstev (z-order), aby tvar vždy zůstával „nahoře“?**

Změňte pořadí vložení/přesunu v kolekci [shapes](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/baseslide/#getShapes) snímku. Pro předvídatelné výsledky dokončete nastavení z-order po všech ostatních úpravách snímku.

**Mohu „uzamknout“ tvar, aby uživatelé v PowerPointu nemohli upravovat?**

Ano. Nastavte ochranné příznaky na úrovni tvaru (např. zamknutí výběru, pohybu, změny velikosti, úprav textu). V případě potřeby aplikujte omezení na master nebo rozvržení. Upozorňujeme, že se jedná o ochranu na úrovni uživatelského rozhraní, nikoli o bezpečnostní funkci; pro silnější ochranu kombinujte s omezeními na úrovni souboru, jako jsou [doporučení pro pouze čtení nebo hesla](/slides/cs/nodejs-java/password-protected-presentation/).