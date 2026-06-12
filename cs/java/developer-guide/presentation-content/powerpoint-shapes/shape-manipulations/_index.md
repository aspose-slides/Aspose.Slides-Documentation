---
title: Spravovat tvary prezentace v Javě
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/java/shape-manipulations/
keywords:
- PowerPoint tvar
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
- tvar do SVG
- zarovnat tvar
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se vytvářet, upravovat a optimalizovat tvary v Aspose.Slides pro Java a vytvářet vysoce výkonné PowerPoint prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s tvary v prezentacích pomocí Aspose.Slides. Ukazuje, jak najít tvar na snímku, klonovat jej, odstranit jej, skrýt jej, změnit jeho pořadí, získat jeho Interop ID tvaru a nastavit alternativní text pro identifikaci a další zpracování.

Také pokrývá, jak získat přístup k formátům rozvržení pro tvary, vykreslit tvar jako SVG, zarovnat tvary na snímku a používat vlastnosti převrácení pro horizontální a vertikální zrcadlení. Navíc článek obsahuje krátké FAQ o kombinaci tvarů, pořadí vrstvení a zamykání tvarů.

## **Najít tvar na snímku**
Toto téma popisuje jednoduchou techniku, která vývojářům usnadní nalezení konkrétního tvaru na snímku bez použití jeho interního Id. Je důležité vědět, že soubory PowerPoint prezentací nemají žádný způsob, jak identifikovat tvary na snímku kromě interního jedinečného Id. Pro vývojáře se může zdát obtížné najít tvar pomocí jeho interního jedinečného Id. Všechny tvary přidané na snímky mají nějaký alternativní text. Navrhujeme vývojářům použít alternativní text pro vyhledání konkrétního tvaru. Můžete v MS PowerPoint definovat alternativní text pro objekty, které plánujete v budoucnu měnit.

Po nastavení alternativního textu libovolného požadovaného tvaru můžete prezentaci otevřít pomocí Aspose.Slides pro Java a projít všechny tvary přidané na snímek. Při každé iteraci můžete zkontrolovat alternativní text tvaru a tvar s odpovídajícím alternativním textem bude tvar, který potřebujete. Pro lepší demonstraci této techniky jsme vytvořili metodu, [findShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) , která umožní najít konkrétní tvar na snímku a jednoduše jej vrátí.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Alternativní text tvaru, který má být nalezen
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Implementace metody pro nalezení tvaru na snímku pomocí jeho alternativního textu
public static IShape findShape(ISlide slide, String alttext)
{
    // Iterace přes všechny tvary v snímku
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Pokud se alternativní text tvaru shoduje s požadovaným
        // Vrátit tvar
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Klonovat tvar**
Pro klonování tvaru na snímek pomocí Aspose.Slides pro Java:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přistupte ke sbírce tvarů zdrojového snímku.
1. Přidejte nový snímek do prezentace.
1. Klonujte tvary ze sbírky tvarů zdrojového snímku do nového snímku.
1. Uložte upravenou prezentaci jako soubor PPTX.

Příklad níže přidá skupinový tvar na snímek.

```java
// Vytvořte instanci třídy Presentation
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // Zapište soubor PPTX na disk
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Odstranit tvar**
Aspose.Slides pro Java umožňuje vývojářům odstranit libovolný tvar. Pro odstranění tvaru z libovolného snímku postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Přistupte k prvnímu snímku.
1. Najděte tvar s konkrétním AlternativeText.
1. Odstraňte tvar.
1. Uložte soubor na disk.

```java
// Vytvořte objekt Presentation
Presentation pres = new Presentation();
try {
    // Získejte první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidat autoshape typu obdélník
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Uložit prezentaci na disk
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Skrýt tvar**
Aspose.Slides pro Java umožňuje vývojářům skrýt libovolný tvar. Pro skrytí tvaru na libovolném snímku postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Přistupte k prvnímu snímku.
1. Najděte tvar s konkrétním AlternativeText.
1. Skrýt tvar.
1. Uložte soubor na disk.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získejte první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidat autoshape typu obdélník
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Uložit prezentaci na disk
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Změnit pořadí tvaru**
Aspose.Slides pro Java umožňuje vývojářům přeuspořádat tvary. Přeuspořádání tvaru určuje, který tvar je vpředu a který vzadu. Pro přeuspořádání tvaru na libovolném snímku postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Přistupte k prvnímu snímku.
1. Přidejte tvar.
1. Přidejte nějaký text do textového rámce tvaru.
1. Přidejte další tvar se stejnými souřadnicemi.
1. Přeuspořádejte tvary.
1. Uložte soubor na disk.

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Získat Interop ID tvaru**
Aspose.Slides pro Java umožňuje vývojářům získat jedinečný identifikátor tvaru v kontextu snímku na rozdíl od metody [getUniqueId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape#getUniqueId--) , která poskytuje jedinečný identifikátor v kontextu celé prezentace. Metoda [getOfficeInteropShapeId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) byla přidána do rozhraní [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape) a třídy [Shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Shape). Hodnota vrácená metodou [getOfficeInteropShapeId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) odpovídá hodnotě Id objektu Microsoft.Office.Interop.PowerPoint.Shape. Níže je uveden ukázkový kód.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Získání jedinečného identifikátoru tvaru v kontextu snímku
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavit alternativní text pro tvar**
Aspose.Slides pro Java umožňuje vývojářům nastavit AlternateText libovolného tvaru.
Tvary v prezentaci lze rozlišit pomocí metody [AlternativeText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) nebo [Shape Name](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape#setName-java.lang.String-).
Metody [setAlternativeText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) a [getAlternativeText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape#getAlternativeText--) lze číst nebo nastavovat pomocí Aspose.Slides i Microsoft PowerPoint.
Použitím této metody můžete označit tvar a provádět různé operace, jako je odstranění tvaru,
skrývání tvaru nebo přeuspořádání tvarů na snímku.
Pro nastavení AlternateText tvaru postupujte podle níže uvedených kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
1. Přistupte k prvnímu snímku.
1. Přidejte libovolný tvar na snímek.
1. Proveďte nějakou práci s nově přidaným tvarem.
1. Projděte tvary, abyste našli požadovaný tvar.
1. Nastavte AlternativeText.
1. Uložte soubor na disk.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získejte první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidejte autoshape typu obdélník
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // Uložte prezentaci na disk
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přístup k formátům rozvržení pro tvar**
Aspose.Slides pro Java poskytuje jednoduché API pro přístup k formátům rozvržení tvaru. Tento článek ukazuje, jak můžete získat přístup k formátům rozvržení.

Níže je uveden ukázkový kód.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vykreslit tvar jako SVG**
Nyní Aspose.Slides pro Java podporuje vykreslování tvaru jako SVG. Metoda [writeAsSvg](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (a její přetížení) byla přidána do třídy [Shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Shape) a rozhraní [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShape). Tato metoda umožňuje uložit obsah tvaru jako soubor SVG. Níže je ukázkový kód, který ukazuje, jak exportovat tvar snímku do souboru SVG.

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zarovnat tvar**
Aspose.Slides umožňuje zarovnat tvary buď vzhledem k okrajům snímku, nebo vzhledem k sobě navzájem. K tomuto účelu byla přidána přetížená metoda [SlidesUtil.alignShape()](https://reference.aspose.com/slides/cs/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) . Výčtové typy [ShapesAlignmentType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ShapesAlignmentType) definují možné možnosti zarovnání.

**Příklad 1**

Přiložený zdrojový kód zarovnává tvary s indexy 1, 2 a 4 podél horní hranice snímku.

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```

**Příklad 2**

Příklad níže ukazuje, jak zarovnat celou kolekci tvarů vzhledem k úplně spodnímu tvaru v kolekci.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vlastnosti převrácení**
V Aspose.Slides třída [ShapeFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shapeframe/) poskytuje kontrolu nad horizontálním a vertikálním zrcadlením tvarů pomocí vlastností `flipH` a `flipV`. Obě vlastnosti jsou typu `byte` a umožňují hodnoty `1` pro převrácení, `0` pro žádné převrácení nebo `-1` pro výchozí chování. Tyto hodnoty jsou přístupné z [Frame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getFrame--) tvaru.

Pro úpravu nastavení převrácení se vytvoří nová instance [ShapeFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shapeframe/) s aktuální pozicí a velikostí tvaru, požadovanými hodnotami pro `flipH` a `flipV` a úhlem otáčení. Přiřazením této instance k [Frame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getFrame--) tvaru a uložením prezentace se aplikují zrcadlové transformace a zapíší se do výstupního souboru.

Řekněme, že máme soubor sample.pptx, ve kterém první snímek obsahuje jediný tvar s výchozím nastavením převrácení, jak je ukázáno níže.

![Tvar, který má být převrácen](shape_to_be_flipped.png)

Následující ukázkový kód získá aktuální vlastnosti převrácení tvaru a převrátí jej jak horizontálně, tak vertikálně.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Získání horizontálního flipu (převrácení) tvaru.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Získání vertikálního flipu (převrácení) tvaru.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Převrátit horizontálně.
    byte flipV = NullableBool.True; // Převrátit horizontálně.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Převrácený tvar](flipped_shape.png)

## **FAQ**

**Mohu kombinovat tvary (sjednocení/průnik/odečtení) na snímku jako v desktopovém editoru?**

Neexistuje vestavěné API pro Boolean operace. Můžete to přibližně napodobit vytvořením požadovaného obrysu sami – např. vypočítat vzniklou geometrii (pomocí [GeometryPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/geometrypath/)) a vytvořit nový tvar s tímto konturem, případně odstranit původní.

**Jak mohu řídit pořadí vrstvení (z-order), aby tvar vždy zůstal "nahoru"?**

Změňte pořadí vkládání/přesunu v kolekci [shapes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseslide/#getShapes--) snímku. Pro předvídatelné výsledky dokončete z-order po všech ostatních úpravách snímku.

**Mohu "zamknout" tvar, aby uživatelé nemohli v PowerPointu provádět úpravy?**

Ano. Nastavte [značky ochrany na úrovni tvaru](/slides/cs/java/applying-protection-to-presentation/) (např. zamknout výběr, přesun, změnu velikosti, úpravy textu). V případě potřeby můžete omezení aplikovat i na master nebo rozvržení. Upozorňujeme, že se jedná o ochranu na úrovni uživatelského rozhraní, nikoli o bezpečnostní prvek; pro silnější ochranu kombinujte s omezeními na úrovni souboru, jako jsou [doporučení pro režim jen pro čtení nebo hesla](/slides/cs/java/password-protected-presentation/).