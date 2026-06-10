---
title: Prezentációs alakzatok kezelése .NET-ben
linktitle: Alakzatkezelés
type: docs
weight: 40
url: /hu/net/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentációs alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat ID lekérése
- alakzat alternatív szövege
- alakzat elrendezési formátumai
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tanulja meg, hogyan hozhat létre, szerkeszthet és optimalizálhat alakzatokat az Aspose.Slides for .NET-ben, és szállíthat nagy teljesítményű PowerPoint prezentációkat."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk alakzatokkal a bemutatókban az Aspose.Slides segítségével. Megmutatja, hogyan lehet alakzatot keresni egy dián, klónozni, eltávolítani, elrejteni, megváltoztatni a sorrendet, lekérni az Interop alakzat ID-ját, illetve alternatív szöveget beállítani az azonosításhoz és a további feldolgozáshoz.

A cikk továbbá azt is bemutatja, hogyan érhetők el az alakzatok elrendezési formátumai, hogyan renderelhető egy alakzat SVG-ként, hogyan igazíthatók az alakzatok egy dián, és hogyan használhatók a flip tulajdonságok vízszintes és függőleges tükrözéshez. Emellett rövid GYIK-ot tartalmaz az alakzatok egyesítéséről, rétegezési sorrendről és az alakzatok zárolásáról.

## **Alakzat keresése egy dián**
Ez a téma egy egyszerű technikát mutat be, amely megkönnyíti a fejlesztők számára egy adott alakzat megtalálását a dián anélkül, hogy a belső azonosítóját kellene használniuk. Fontos tudni, hogy a PowerPoint bemutató fájlok nem rendelkeznek olyan módszerrel, amellyel a dián lévő alakzatokat azonosítani lehetne, kivéve a belső egyedi azonosítót. A fejlesztőknek nehézséget okozhat egy alakzat megtalálása a belső egyedi azonosítóval. Minden diára hozzáadott alakzathoz van alternatív szöveg (Alt Text). Javasoljuk, hogy a fejlesztők az alternatív szöveget használják egy adott alakzat megtalálásához. A Microsoft PowerPoint segítségével megadhatja az objektumok alternatív szövegét, amelyeket később szeretne módosítani.

Miután beállította egy kívánt alakzat alternatív szövegét, megnyithatja a bemutatót az Aspose.Slides for .NET használatával, és végigiterálhat a dián található összes alakzaton. Minden iteráció során ellenőrizheti az alakzat alternatív szövegét, és a megfelelőt tartalmazó alakzat lesz a keresett. A technika jobb bemutatására létrehoztunk egy [FindShape](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/findshape/#findshape_1) metódust, amely megtalálja a specifikus alakzatot egy dián, és visszaadja azt.

```c#
public static void Run()
{
    // Példányosít egy Presentation osztályt, amely a bemutató fájlt képviseli
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // A megtalálni kívánt alakzat alternatív szövege
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Metódus implementációja, amely egy diában alakzatot keres az alternatív szövege alapján
public static IShape FindShape(ISlide slide, string alttext)
{
    // Az összes alakzat bejárása a dián belül
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Ha a dián lévő alternatív szöveg megegyezik a szükségesvel, akkor
        // Visszaadja az alakzatot
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```

## **Alakzat klónozása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból.
1. Szerezze meg egy dia referenciáját az indexének használatával.
1. Érje el a forrásdia alakzatgyűjteményét.
1. Adjon hozzá egy új diát a bemutatóhoz.
1. Klónozza az alakzatokat a forrásdia gyűjteményéből az új diára.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi példa egy csoportos alakzatot ad hozzá egy diához.

```c#
// Presentation osztály példányosítása
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// A PPTX fájl mentése lemezre
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```

## **Alakzat eltávolítása**
Aspose.Slides for .NET lehetővé teszi a fejlesztők számára, hogy bármely alakzatot eltávolítsanak. Az alakzat eltávolításához egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a `Presentation` osztályból.
1. Nyissa meg az első diát.
1. Keresse meg a megfelelő AlternativeText‑el rendelkező alakzatot.
1. Távolítsa el az alakzatot.
1. Mentse a fájlt a lemezre.

```c#
// Presentation objektum létrehozása
Presentation pres = new Presentation();

// Az első dia lekérése
ISlide sld = pres.Slides[0];

// Téglalap típusú autoshape hozzáadása
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

// A prezentáció mentése a lemezre
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```

## **Alakzat elrejtése**
Aspose.Slides for .NET lehetővé teszi a fejlesztők számára, hogy bármely alakzatot elrejtjenek. Az alakzat elrejtéséhez egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a `Presentation` osztályból.
1. Nyissa meg az első diát.
1. Keresse meg a megfelelő AlternativeText‑el rendelkező alakzatot.
1. Rejtse el az alakzatot.
1. Mentse a fájlt a lemezre.

```c#
// A PPTX-et képviselő Presentation osztály példányosítása
Presentation pres = new Presentation();

// Az első dia lekérése
ISlide sld = pres.Slides[0];

// Téglalap típusú autoshape hozzáadása
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

// A prezentáció mentése lemezre
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```

## **Alakzat sorrendjének módosítása**
Aspose.Slides for .NET lehetővé teszi a fejlesztők számára az alakzatok újrarendezését. A sorrend megadja, hogy melyik alakzat van elöl vagy hátul. Az alakzat újrarendezéséhez egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a `Presentation` osztályból.
1. Nyissa meg az első diát.
1. Adjon hozzá egy alakzatot.
1. Adjon szöveget az alakzat szövegkeretébe.
1. Adjon hozzá egy másik alakzatot ugyanazzal a koordinátával.
1. Rendezze át az alakzatokat.
1. Mentse a fájlt a lemezre.

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

## **Interop alakzat ID lekérése**
Az Aspose.Slides for .NET lehetővé teszi a fejlesztők számára, hogy egyedi alakzatazonosítót kapjanak a dia szintjén, szemben a UniqueId tulajdonsággal, amely a bemutató szintjén biztosít egyedi azonosítót. Az OfficeInteropShapeId tulajdonság az IShape interfészekhez és a Shape osztályhoz került hozzáadásra. Az OfficeInteropShapeId értéke megegyezik a Microsoft.Office.Interop.PowerPoint.Shape objektum Id értékével. Az alábbiakban egy példakód látható.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Egyedi alakzat azonosító lekérése a dia hatókörében
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```

## **Alakzat alternatív szövegének beállítása**
Az Aspose.Slides for .NET lehetővé teszi, hogy a fejlesztők beállítsák bármely alakzat AlternateText értékét. 
A bemutatóban lévő alakzatok megkülönböztethetők az AlternativeText vagy a Shape Name (alakzatnév) tulajdonság alapján. 
Az AlternativeText tulajdonságot olvashatja vagy beállíthatja az Aspose.Slides vagy a Microsoft PowerPoint segítségével. 
Ennek a tulajdonságnak a használatával címkézhet egy alakzatot, és különböző műveleteket végezhet, például alakzat eltávolítása, 
alakzat elrejtése vagy alakzatok átrendezése a dián. 
Az AlternateText beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a `Presentation` osztályból.
1. Nyissa meg az első diát.
1. Adjon hozzá bármilyen alakzatot a diához.
1. Végezzen némi műveletet az újonnan hozzáadott alakzattal.
1. Járja be az alakzatokat a keresett alakzat megtalálásához.
1. Állítsa be az AlternativeText értéket.
1. Mentse a fájlt a lemezre.

```c#
// A PPTX-et képviselő Presentation osztály példányosítása
Presentation pres = new Presentation();

// Az első dia lekérése
ISlide sld = pres.Slides[0];

// Téglalap típusú autoshape hozzáadása
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

// A prezentáció mentése lemezre
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```

## **Alakzat elrendezési formátumainak elérése**
Az Aspose.Slides for .NET egyszerű API-t biztosít az alakzat elrendezési formátumainak eléréséhez. Ez a cikk bemutatja, hogyan érheti el az elrendezési formátumokat.

Az alábbi példakód látható.

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

## **Alakzat renderelése SVG-ként**
Az Aspose.Slides for .NET most már támogatja az alakzat SVG-ként való renderelését. A WriteAsSvg metódus (és annak túlterhelése) a Shape osztályhoz és az IShape interfészhez került hozzáadásra. Ez a metódus lehetővé teszi az alakzat tartalmának SVG fájlba mentését. Az alábbi kódrészlet bemutatja, hogyan exportálhatja a dia alakzatát SVG fájlba.

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

## **Alakzat igazítása**
A [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/methods/alignshapes/index) túlterhelt metódus segítségével 

* igazíthatja az alakzatokat a dia margójához képest. Lásd Példa 1. 
* igazíthatja az alakzatokat egymáshoz képest. Lásd Példa 2. 

A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/net/aspose.slides/shapesalignmenttype) felsorolás meghatározza a rendelkezésre álló igazítási lehetőségeket.

**Példa 1**

Ez a C# kód megmutatja, hogyan igazíthatók a 1, 2 és 4 indexű alakzatok a dia felső szélén:
Az alábbi forráskód a 1, 2 és 4 indexű alakzatokat a dia felső szélén igazítja.

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

**Példa 2**

Ez a C# kód megmutatja, hogyan igazítható egy teljes alakzatsorozat a sorozat alján lévő alakzathoz képest:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **Flip tulajdonságok**
Az Aspose.Slides-ben a [ShapeFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/shapeframe/) osztály lehetővé teszi a alakzatok vízszintes és függőleges tükrözésének vezérlését a `FlipH` és `FlipV` tulajdonságokon keresztül. Mindkét tulajdonság a [NullableBool](https://reference.aspose.com/slides/hu/net/aspose.slides/nullablebool/) típusú, amely megengedi a `True` értéket a tükrözéshez, a `False` értéket a tükrözés hiányához, vagy a `NotDefined` értéket az alapértelmezett viselkedéshez. Ezek az értékek az alakzat [Frame](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/frame/) tulajdonságán keresztül érhetők el.

A flip beállítások módosításához egy új [ShapeFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/shapeframe/) példányt hozunk létre az alakzat aktuális pozíciójával és méretével, a kívánt `FlipH` és `FlipV` értékekkel, valamint a forgásszöggel. Ennek a példánynak a alakzat [Frame](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/frame/) tulajdonságához való hozzárendelése és a bemutató mentése alkalmazza a tükrözési transzformációkat, és a kimeneti fájlba menti őket.

Tegyük fel, hogy van egy sample.pptx fájlunk, amelynek az első diapont egyetlen alakzat tartalmazza alapértelmezett flip beállításokkal, az alábbiak szerint.

![A tükrözendő alakzat](shape_to_be_flipped.png)

Az alábbi kódrészlet lekéri az alakzat aktuális flip tulajdonságait, és vízszintesen és függőlegesen egyaránt tükrözi.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Az alakzat vízszintes flip tulajdonságának lekérése.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Az alakzat függőleges flip tulajdonságának lekérése.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Vízszintesen tükröz.
    NullableBool flipV = NullableBool.True; // Függőlegesen tükröz.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A tükrözött alakzat](flipped_shape.png)

## **GYIK**

**Összevonhatok-e alakzatokat (unió/metszet/kivonás) egy dián, mint egy asztali szerkesztőben?**

Nincs beépített Boolean művelet API. Körülbelül ugyanúgy elérhető, ha saját maga felépíti a kívánt körvonalat – például kiszámítja a keletkező geometriát (a [GeometryPath](https://reference.aspose.com/slides/hu/net/aspose.slides/geometrypath/) segítségével), és létrehoz egy új alakzatot ezzel a körvonallal, opcionálisan eltávolítva az eredetit.

**Hogyan szabályozhatom a rétegezési sorrendet (z-sorrendet), hogy egy alakzat mindig "felül" maradjon?**

Módosítsa a beszúrási/mozgatási sorrendet a dia [shapes](https://reference.aspose.com/slides/hu/net/aspose.slides/baseslide/shapes/) gyűjteményén belül. A kiszámítható eredmények érdekében a z-sorrendet a többi dia módosítás után fejezze be.

**Zárolhatok-e egy alakzatot, hogy a felhasználók ne tudják szerkeszteni PowerPointban?**

Igen. Állítsa be a [alakzatszintű védelmi zászlókat](/slides/hu/net/applying-protection-to-presentation/) (például a kiválasztás, mozgatás, átméretezés, szövegszerkesztés zárolását). Szükség esetén tükrözze a korlátozásokat a mester- vagy elrendezésre. Vegye figyelembe, hogy ez UI-szintű védelem, nem biztonsági funkció; erősebb védelemhez kombinálja fájlszintű korlátozásokkal, mint a [csak olvasható ajánlások vagy jelszavak](/slides/hu/net/password-protected-presentation/).