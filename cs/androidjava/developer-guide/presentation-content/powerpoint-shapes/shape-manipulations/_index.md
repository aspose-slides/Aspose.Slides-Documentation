---
title: Správa tvarů prezentace na Androidu
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/androidjava/shape-manipulations/
keywords:
- PowerPoint tvar
- tvar prezentace
- tvar na snímku
- najít tvar
- klonovat tvar
- odstranit tvar
- skrýt tvar
- změnit pořadí tvaru
- získat Interop Shape ID
- alternativní text tvaru
- formáty rozvržení tvaru
- tvar jako SVG
- tvar do SVG
- zarovnat tvar
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se vytvářet, upravovat a optimalizovat tvary v Aspose.Slides pro Android pomocí Javy a dodávejte vysoce výkonné PowerPoint prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s tvary v prezentacích pomocí Aspose.Slides. Ukazuje, jak najít tvar na snímku, klonovat jej, odstranit jej, skrýt jej, změnit jeho pořadí, získat jeho Interop Shape ID a nastavit alternativní text pro identifikaci a další zpracování.

Popisuje také, jak získat přístup k formátům rozvržení pro tvary, renderovat tvar jako SVG, zarovnat tvary na snímku a použít vlastnosti překlápění pro horizontální a vertikální zrcadlení. Navíc článek obsahuje krátkou sekci FAQ o kombinování tvarů, pořadí vrstev a zamykání tvarů.

## **Najít tvar na snímku**
Toto téma popisuje jednoduchou techniku, která vývojářům usnadní nalezení konkrétního tvaru na snímku bez použití jeho vnitřního Id. Je důležité vědět, že soubory PowerPoint prezentací nemají žádný způsob, jak identifikovat tvary na snímku kromě vnitřního unikátního Id. Pro vývojáře může být obtížné najít tvar pomocí tohoto interního unikátního Id. Všechny tvary přidané do snímků mají nějaký alternativní text. Doporučujeme vývojářům používat alternativní text pro vyhledávání konkrétního tvaru. Můžete v MS PowerPoint definovat alternativní text pro objekty, které plánujete v budoucnu měnit.

Po nastavení alternativního textu požadovaného tvaru můžete otevřít tuto prezentaci pomocí Aspose.Slides pro Android via Java a iterovat přes všechny tvary přidané na snímek. Během každé iterace můžete zkontrolovat alternativní text tvaru a tvar s odpovídajícím alternativním textem bude ten, který potřebujete. Pro lepší demonstraci této techniky jsme vytvořili metodu [findShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) , která provede vyhledání konkrétního tvaru na snímku a jednoduše vrátí tento tvar.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // Alternativní text tvaru, který se má najít
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
// Implementace metody pro nalezení tvaru ve snímku pomocí jeho alternativního textu
public static IShape findShape(ISlide slide, String alttext)
{
    // Procházení všech tvarů uvnitř snímku
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Pokud se alternativní text snímku shoduje s požadovaným, pak
        // Vraťte tvar
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Klonovat tvar**
Jak klonovat tvar na snímek pomocí Aspose.Slides pro Android via Java:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přistupte ke kolekci tvarů zdrojového snímku.
1. Přidejte nový snímek do prezentace.
1. Klonujte tvary z kolekce tvarů zdrojového snímku do nového snímku.
1. Uložte upravenou prezentaci jako soubor PPTX.

Níže uvedený příklad přidává skupinový tvar na snímek.

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

    // Uložte soubor PPTX na disk
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Odstranit tvar**
Aspose.Slides pro Android via Java umožňuje vývojářům odstranit libovolný tvar. Chcete-li odstranit tvar z libovolného snímku, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
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

    // Přidejte autoshape typu obdélník
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

    // Uložte prezentaci na disk
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Skrýt tvar**
Aspose.Slides pro Android via Java umožňuje vývojářům skrýt libovolný tvar. Chcete-li skrýt tvar na libovolném snímku, postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Přistupte k prvnímu snímku.
1. Najděte tvar s konkrétním AlternativeText.
1. Skrývejte tvar.
1. Uložte soubor na disk.

```java
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Získejte první snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidejte autoshape typu obdélník
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

    // Uložte prezentaci na disk
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Změnit pořadí tvaru**
Aspose.Slides pro Android via Java umožňuje vývojářům změnit pořadí tvarů. Změna pořadí určuje, který tvar je vpředu a který v pozadí. Pro změnu pořadí tvaru na libovolném snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Přistupte k prvnímu snímku.
1. Přidejte tvar.
1. Přidejte text do textového rámce tvaru.
1. Přidejte další tvar se stejnými souřadnicemi.
1. Změňte pořadí tvarů.
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

## **Získat Interop Shape ID**
Aspose.Slides pro Android via Java umožňuje vývojářům získat unikátní identifikátor tvaru v rozsahu snímku na rozdíl od metody [getUniqueId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#getUniqueId--) , která umožňuje získat unikátní identifikátor v rozsahu celé prezentace. Metoda [getOfficeInteropShapeId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) byla přidána do rozhraní [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape) a třídy [Shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Shape). Hodnota vrácená metodou [getOfficeInteropShapeId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) odpovídá hodnotě Id objektu Microsoft.Office.Interop.PowerPoint.Shape. Níže je uveden ukázkový kód.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Získání unikátního identifikátoru tvaru v rozsahu snímku
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Nastavit alternativní text pro tvar**
Aspose.Slides pro Android via Java umožňuje vývojářům nastavit AlternateText libovolného tvaru.
Tvary v prezentaci lze rozlišovat pomocí metody [AlternativeText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) nebo [Shape Name](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#setName-java.lang.String-).
Metody [setAlternativeText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) a [getAlternativeText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#getAlternativeText--) lze číst i nastavovat pomocí Aspose.Slides i Microsoft PowerPoint.
Pomocí této metody můžete označit tvar a provádět různé operace, jako je odstranění tvaru, skrytí tvaru nebo změna pořadí tvarů na snímku.
Pro nastavení AlternateText tvaru postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
1. Přistupte k prvnímu snímku.
1. Přidejte libovolný tvar na snímek.
1. Proveďte požadované operace s nově přidaným tvarem.
1. Procházejte tvary a najděte požadovaný tvar.
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
Aspose.Slides pro Android via Java poskytuje jednoduché API pro přístup k formátům rozvržení pro tvar. Tento článek ukazuje, jak můžete přistupovat k formátům rozvržení.

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

## **Renderovat tvar jako SVG**
Aspose.Slides pro Android via Java nyní podporuje renderování tvaru jako SVG. Metoda [writeAsSvg](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (a její přetížení) byla přidána do třídy [Shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Shape) a rozhraní [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShape). Tato metoda umožňuje uložit obsah tvaru jako soubor SVG. Níže uvedený úryvek kódu ukazuje, jak exportovat tvar snímku do SVG souboru.

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
Aspose.Slides umožňuje zarovnávat tvary buď vzhledem k okrajům snímku, nebo vzhledem k sobě navzájem. Pro tento účel byla přidána přetížená metoda [SlidesUtil.alignShape()](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-). Výčtový typ [ShapesAlignmentType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ShapesAlignmentType) definuje možné možnosti zarovnání.

**Příklad 1**

Zdrojový kód níže zarovnává tvary s indexy 1, 2 a 4 podél horního okraje snímku.

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

Následující příklad ukazuje, jak zarovnat celou kolekci tvarů vzhledem k nejspodnějšímu tvaru v kolekci.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vlastnosti překlápění**

V Aspose.Slides třída [ShapeFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shapeframe/) poskytuje řízení horizontálního a vertikálního zrcadlení tvarů pomocí vlastností `flipH` a `flipV`. Obě vlastnosti jsou typu `byte` a mohou nabývat hodnot `1` (překlopit), `0` (nepřeklopit) nebo `-1` (výchozí chování). Tyto hodnoty jsou přístupné z [Frame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getFrame--) tvaru.

Pro úpravu nastavení překlápění se vytvoří nová instance [ShapeFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shapeframe/) s aktuální pozicí a velikostí tvaru, požadovanými hodnotami pro `flipH` a `flipV` a úhlem otáčení. Přidělením této instance k [Frame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getFrame--) tvaru a uložením prezentace se aplikují zrcadlové transformace a zapíšou do výstupního souboru.

Předpokládejme, že máme soubor sample.pptx, ve kterém první snímek obsahuje jediný tvar s výchozím nastavením překlápění, jak je znázorněno níže.

![Tvar, který má být přeložen](shape_to_be_flipped.png)

Následující ukázka kódu získá aktuální vlastnosti překlápění tvaru a přeloží jej jak horizontálně, tak vertikálně.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Získat horizontální vlastnost překlápění tvaru.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Získat vertikální vlastnost překlápění tvaru.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Překlopit horizontálně.
    byte flipV = NullableBool.True; // Překlopit horizontálně.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Přeložený tvar](flipped_shape.png)

## **FAQ**

**Mohu kombinovat tvary (union/intersect/subtract) na snímku jako v desktopovém editoru?**

Neexistuje vestavěné API pro Boolovské operace. Můžete si je napodobit vytvořením požadovaného obrysu sami – např. vypočítat výslednou geometrii (pomocí [GeometryPath](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/geometrypath/)) a vytvořit nový tvar s tímto konturem, volitelně odstranit původní tvary.

**Jak mohu řídit pořadí vrstev (z‑order), aby tvar vždy zůstával „navrchu“?**

Změňte pořadí vložení/přesunu v kolekci [shapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseslide/#getShapes--) snímku. Pro předvídatelné výsledky dokončete z‑order po všech ostatních úpravách snímku.

**Mohu „uzamknout“ tvar, aby uživatelé v PowerPointu nemohli upravovat?**

Ano. Nastavte ochranné příznaky na úrovni tvaru (např. zamknout výběr, přesun, změnu velikosti, úpravy textu). V případě potřeby aplikujte omezení i na master nebo rozvržení. Upozorňujeme, že se jedná o ochranu na úrovni UI, nikoli o bezpečnostní funkci; pro silnější ochranu kombinujte s omezeními na úrovni souboru, jako jsou [doporučení pro pouze čtení nebo hesla](/slides/cs/androidjava/password-protected-presentation/).