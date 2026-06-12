---
title: Správa tvarů prezentace v .NET
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/net/shape-manipulations/
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
- formáty rozložení tvaru
- tvar jako SVG
- tvar do SVG
- zarovnat tvar
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se vytvářet, upravovat a optimalizovat tvary v Aspose.Slides pro .NET a vytvářet vysoce výkonné PowerPoint prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s tvary v prezentacích pomocí Aspose.Slides. Ukazuje, jak najít tvar na snímku, klonovat jej, odstranit, skrýt, změnit jeho pořadí, získat jeho Interop Shape ID a nastavit alternativní text pro identifikaci a další zpracování.

Také popisuje, jak přistupovat k formátům rozložení pro tvary, vykreslovat tvar jako SVG, zarovnávat tvary na snímku a používat vlastnosti překlápění pro vodorovné a svislé zrcadlení. Navíc článek obsahuje krátké FAQ o kombinaci tvarů, pořadí vrstev a uzamčení tvaru.

## **Najít tvar na snímku**
Tento odstavec popisuje jednoduchou techniku, která vývojářům usnadní nalezení konkrétního tvaru na snímku bez použití jeho interního Id. Je důležité vědět, že soubory PowerPoint prezentací nemají žádný způsob, jak identifikovat tvary na snímku kromě interního jedinečného Id. Vývojářům se může zdát obtížné najít tvar pomocí tohoto interního Id. Všechny tvary přidané do snímků mají nějaký alternativní text. Doporučujeme vývojářům používat alternativní text pro hledání konkrétního tvaru. Pomocí MS PowerPoint můžete definovat alternativní text pro objekty, které plánujete v budoucnu měnit.

Po nastavení alternativního textu libovolného požadovaného tvaru můžete otevřít tuto prezentaci pomocí Aspose.Slides pro .NET a iterovat přes všechny tvary přidané do snímku. Během každé iterace můžete zkontrolovat alternativní text tvaru a tvar s odpovídajícím alternativním textem bude tvar, který potřebujete. Pro lepší demonstraci této techniky jsme vytvořili metodu [FindShape](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/findshape/#findshape_1), která umožňuje najít konkrétní tvar na snímku a jednoduše jej vrátí.

```c#
public static void Run()
{
    // Vytvoření instance třídy Presentation, která představuje soubor prezentace
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Alternativní text tvaru, který má být nalezen
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Implementace metody pro nalezení tvaru ve snímku pomocí jeho alternativního textu
public static IShape FindShape(ISlide slide, string alttext)
{
    // Procházení všech tvarů uvnitř snímku
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Pokud se alternativní text snímku shoduje s požadovaným, pak
        // Vrátí tvar
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```



## **Klonovat tvar**
Pro klonování tvaru na snímek pomocí Aspose.Slides pro .NET:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přistupte ke kolekci tvarů zdrojového snímku.
1. Přidejte nový snímek do prezentace.
1. Klonujte tvary z kolekce tvarů zdrojového snímku na nový snímek.
1. Uložte upravenou prezentaci jako soubor PPTX.

Níže uvedený příklad přidává skupinový tvar na snímek.

```c#
// Vytvoření instance třídy Presentation
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Zapsání souboru PPTX na disk
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```



## **Odstranit tvar**
Aspose.Slides pro .NET umožňuje vývojářům odstranit libovolný tvar. Pro odebrání tvaru z libovolného snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy `Presentation`.
1. Přistupte k prvnímu snímku.
1. Najděte tvar s konkrétním AlternativeText.
1. Odeberte tvar.
1. Uložte soubor na disk.

```c#
// Vytvoření objektu Presentation
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = pres.Slides[0];

// Add autoshape of rectangle type
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// Uložit prezentaci na disk
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```



## **Skrýt tvar**
Aspose.Slides pro .NET umožňuje vývojářům skrýt libovolný tvar. Pro skrytí tvaru na libovolném snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy `Presentation`.
1. Přistupte k prvnímu snímku.
1. Najděte tvar s konkrétním AlternativeText.
1. Skryjte tvar.
1. Uložte soubor na disk.

```c#
// Vytvoření instance třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();

// Získání prvního snímku
ISlide sld = pres.Slides[0];

// Přidání automatického tvaru typu obdélník
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// Uložit prezentaci na disk
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```



## **Změnit pořadí tvaru**
Aspose.Slides pro .NET umožňuje vývojářům změnit pořadí tvarů. Přesunutí tvaru určuje, který tvar je vpředu a který v pozadí. Pro změnu pořadí tvaru na libovolném snímku postupujte podle následujících kroků:

1. Vytvořte instanci třídy `Presentation`.
1. Přistupte k prvnímu snímku.
1. Přidejte tvar.
1. Přidejte text do textového rámce tvaru.
1. Přidejte další tvar se stejnými souřadnicemi.
1. Změňte pořadí tvarů.
1. Uložte soubor na disk.

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```


## **Získat Interop Shape ID**
Aspose.Slides pro .NET umožňuje vývojářům získat jedinečný identifikátor tvaru v rámci snímku na rozdíl od vlastnosti UniqueId, která poskytuje jedinečný identifikátor v rámci celé prezentace. Vlastnost OfficeInteropShapeId byla přidána do rozhraní IShape a třídy Shape. Hodnota vrácená vlastností OfficeInteropShapeId odpovídá hodnotě Id objektu Microsoft.Office.Interop.PowerPoint.Shape. Níže je uveden ukázkový kód.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Získání jedinečného identifikátoru tvaru v rámci snímku
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```



## **Nastavit alternativní text pro tvar**
Aspose.Slides pro .NET umožňuje vývojářům nastavit AlternateText libovolného tvaru. 
Tvary v prezentaci lze rozlišovat pomocí AlternativeText nebo vlastnosti Shape Name. 
Vlastnost AlternativeText lze číst i nastavit pomocí Aspose.Slides i Microsoft PowerPoint. 
Pomocí této vlastnosti můžete označit tvar a provádět různé operace, jako je odstranění tvaru, 
skrytí tvaru nebo změna pořadí tvarů na snímku.
Pro nastavení AlternateText tvaru postupujte podle následujících kroků:

1. Vytvořte instanci třídy `Presentation`.
1. Přistupte k prvnímu snímku.
1. Přidejte libovolný tvar na snímek.
1. Proveďte požadované operace s nově přidaným tvarem.
1. Procházejte tvary a najděte požadovaný tvar.
1. Nastavte AlternativeText.
1. Uložte soubor na disk.

```c#
// Vytvoření instance třídy Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();

// Získání prvního snímku
ISlide sld = pres.Slides[0];

// Add autoshape of rectangle type
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// Uložit prezentaci na disk
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```




## **Přístup k formátům rozložení pro tvar**
Aspose.Slides pro .NET poskytuje jednoduché API pro přístup k formátům rozložení pro tvar. Tento článek demonstruje, jak můžete přistupovat k těmto formátům.

Níže je uveden ukázkový kód.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```

## **Vykreslit tvar jako SVG**
Nyní Aspose.Slides pro .NET podporuje vykreslování tvaru jako SVG. Metoda WriteAsSvg (a její přetížení) byla přidána do třídy Shape a rozhraní IShape. Tato metoda umožňuje uložit obsah tvaru jako soubor SVG. Níže uvedený úryvek kódu ukazuje, jak exportovat tvar ze snímku do souboru SVG.

```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```

## **Zarovnat tvar**

Pomocí přetížené metody [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/methods/alignshapes/index) můžete 

* zarovnat tvary vzhledem k okrajům snímku. Viz Příklad 1. 
* zarovnat tvary vzhledem k sobě navzájem. Viz Příklad 2. 

Výčtová hodnota [ShapesAlignmentType](https://reference.aspose.com/slides/cs/net/aspose.slides/shapesalignmenttype) definuje dostupné možnosti zarovnání.

**Příklad 1**

Tento C# kód ukazuje, jak zarovnat tvary s indexy 1, 2 a 4 podél horního okraje snímku:
Zdrojový kód níže zarovnává tvary s indexy 1, 2 a 4 podél horního okraje snímku. 

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```

**Příklad 2**

Tento C# kód ukazuje, jak zarovnat celou kolekci tvarů vzhledem k dolnímu tvaru v kolekci:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **Vlastnosti Flip**

V Aspose.Slides třída [ShapeFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/shapeframe/) poskytuje kontrolu nad vodorovným a svislým zrcadlením tvarů prostřednictvím vlastností `FlipH` a `FlipV`. Obě vlastnosti jsou typu [NullableBool](https://reference.aspose.com/slides/cs/net/aspose.slides/nullablebool/), přičemž hodnota `True` označuje překlápění, `False` žádné překlápění a `NotDefined` použije výchozí chování. Tyto hodnoty jsou přístupné z [Frame](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/frame/) tvaru.

Pro úpravu nastavení překlápění se vytvoří nová instance [ShapeFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/shapeframe/) s aktuální pozicí a velikostí tvaru, požadovanými hodnotami `FlipH` a `FlipV` a úhlem otáčení. Přiřazením této instance k [Frame](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/frame/) tvaru a uložením prezentace se aplikují zrcadlové transformace a zapíšou do výstupního souboru.

Předpokládejme, že máme soubor sample.pptx, ve kterém první snímek obsahuje jediný tvar s výchozím nastavením překlápění, jak je znázorněno níže.

![The shape to be flipped](shape_to_be_flipped.png)

Následující ukázka kódu získá aktuální vlastnosti překlápění tvaru a překlápí jej jak horizontálně, tak vertikálně.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Získání vodorovné vlastnosti překlápění tvaru.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Získání svislé vlastnosti překlápění tvaru.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Překlopit vodorovně.
    NullableBool flipV = NullableBool.True; // Překlopit svisle.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Mohu na snímku spojovat tvary (union/intersect/subtract) jako v desktopovém editoru?**

Neexistuje vestavěné API pro Booleovské operace. Můžete jej aproximovat vytvořením požadovaného obrysu sami – např. vypočítat výslednou geometrii (pomocí [GeometryPath](https://reference.aspose.com/slides/cs/net/aspose.slides/geometrypath/)) a vytvořit nový tvar s tímto obrysem, případně odstranit originály.

**Jak mohu ovládat pořadí vrstev (z-order), aby tvar vždy zůstával „nahoře“?**

Změňte pořadí vložení/přesunu uvnitř kolekce [shapes](https://reference.aspose.com/slides/cs/net/aspose.slides/baseslide/shapes/) snímku. Pro předvídatelné výsledky finalizeujte z-order po všech ostatních úpravách snímku.

**Mohu „uzamknout“ tvar, aby ho uživatelé nemohli v PowerPointu upravovat?**

Ano. Nastavte [flagy ochrany na úrovni tvaru](/slides/cs/net/applying-protection-to-presentation/) (např. zamknout výběr, pohyb, změnu velikosti, úpravy textu). Pokud je potřeba, aplikujte omezení i na master nebo rozložení. Upozorňujeme, že jde o ochranu na úrovni UI, ne o bezpečnostní funkci; pro silnější ochranu kombinujte s omezeními na úrovni souboru, jako jsou doporučení pro pouze čtení nebo hesla [/slides/cs/net/password-protected-presentation/](https://reference.aspose.com/slides/cs/net/password-protected-presentation/).