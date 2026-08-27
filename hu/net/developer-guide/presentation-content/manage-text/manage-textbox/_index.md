---
title: Szövegdobozok kezelése prezentációkban .NET-ben
linktitle: Szövegdoboz kezelése
type: docs
weight: 20
url: /hu/net/manage-textbox/
keywords:
- szövegdoboz
- szövegkeret
- szöveg hozzáadása
- szöveg frissítése
- szövegdoboz létrehozása
- szövegdoboz ellenőrzése
- szöveg oszlop hozzáadása
- hiperhivatkozás hozzáadása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Az Aspose.Slides for .NET megkönnyíti a szövegdobozok létrehozását, szerkesztését és klónozását PowerPoint és OpenDocument fájlokban, így javítva a prezentáció automatizálását."
---
## **Bevezetés**

A diákon lévő szövegek általában szövegdobozokban vagy alakzatokban vannak. Ezért a diára szöveget hozzáadni előbb egy szövegdobozt kell létrehozni, majd szöveget helyezni a szövegdobozba. 

Ahhoz, hogy olyan alakzatot adj hozzá, amely szöveget tartalmazhat, az Aspose.Slides for .NET biztosítja a [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape) interfészt. 

{{% alert title="Note" color="warning" %}} 

Az Aspose.Slides emellett biztosítja a [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape) interfészt, hogy alakzatokat adhass a diákhoz. Azonban nem minden, az `IShape` interfészen keresztül hozzáadott alakzat képes szöveget tartalmazni. Az [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape) interfészen keresztül hozzáadott alakzatok általában szöveget tartalmaznak. 

Ezért, amikor egy már létező alakzattal dolgozol, amelyhez szöveget szeretnél adni, ellenőrizned kell, hogy azt az `IAutoShape` interfészen keresztül castolták-e. csak ekkor tudsz a `IAutoShape` alatti [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/properties/textframe) tulajdonsággal dolgozni. Lásd a [Update Text](https://docs.aspose.com/slides/hu/net/manage-textbox/#update-text) szekciót ezen az oldalon. 

{{% /alert %}}

## **Szövegdoboz létrehozása a dián**

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból. 
2. Szerezd meg az első dia referenciaját az indexén keresztül. 
3. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape) objektumot, amelynek a [ShapeType](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometryshape/properties/shapetype) értéke `Rectangle`, a dián egy megadott pozícióban, és kapj referenciát az újonnan hozzáadott `IAutoShape` objektumhoz. 
4. Adj egy `TextFrame` tulajdonságot az `IAutoShape` objektumhoz, amely szöveget fog tartalmazni. Az alábbi példában ezt a szöveget adtuk hozzá: *Aspose TextBox* 
5. Végül írd ki a PPTX fájlt a `Presentation` objektumon keresztül. 

Ez a C# kód – a fenti lépések megvalósítása – megmutatja, hogyan adj szöveget egy diához:

```c#
using Aspose.Slides;

// Példányosítja a PresentationEx-et
using (Presentation pres = new Presentation())
{

    // Lekéri az első diát a prezentációból
    ISlide sld = pres.Slides[0];

    // Hozzáad egy AutoShape-et, amelynek típusa Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Hozzáad egy TextFrame-et a Rectangle-hez
    ashp.AddTextFrame(" ");

    // Hozzáfér a szövegkerethez
    ITextFrame txtFrame = ashp.TextFrame;

    // Létrehozza a Paragraph objektumot a szövegkerethez
    IParagraph para = txtFrame.Paragraphs[0];

    // Létrehozza a Portion objektumot a bekezdéshez
    IPortion portion = para.Portions[0];

    // Beállítja a szöveget
    portion.Text = "Aspose TextBox";

    // Mentés a prezentációt lemezre
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Szövegdoboz alakzat ellenőrzése**

Az Aspose.Slides biztosítja az [IsTextBox](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/istextbox/) tulajdonságot az [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) interfészen, amely lehetővé teszi az alakzatok vizsgálatát és a szövegdobozok azonosítását.

![Szövegdoboz és alakzat](istextbox.png)

Ez a C# kód megmutatja, hogyan ellenőrizd, hogy egy alakzat szövegdobozként lett-e létrehozva: 

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```

Vedd figyelembe, hogy ha egyszerűen egy autoshapet adsz hozzá az [IShapeCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/) interfész `AddAutoShape` metódusával, akkor az autoshape `IsTextBox` tulajdonsága `false` értéket ad. Azonban miután szöveget adsz az autoshapehöz az `AddTextFrame` metódussal vagy a `Text` tulajdonsággal, az `IsTextBox` tulajdonság `true` értéket ad.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox hamis
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox igaz

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox hamis
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox igaz

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox hamis
    shape3.AddTextFrame("");
    // shape3.IsTextBox hamis

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox hamis
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox hamis
}
```

## **A szövegkeretet tartalmazó alakzat megtalálása**

Általános szövegfeldolgozó kódban előfordulhat, hogy egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumot kapsz anélkül, hogy tudnád, melyik prezentációs objektum tartalmazza. Használd az [ITextFrame.ParentShape](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/parentshape/) tulajdonságot a tulajdonos [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/) objektumra való visszavezetéshez.

Egy szövegkeret, amely egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) vagy egy másik szöveget tartalmazó alakzat része, esetén az [ITextFrame.ParentShape](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/parentshape/) be van állítva, míg az [ITextFrame.ParentCell](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/parentcell/) `null`. Mindkét tulajdonság csak olvasható navigációs tulajdonság, ezért olvasásuk nem változtatja meg a tulajdonjogot. Mindig ellenőrizd a visszaadott értéket `null` ellen, mielőtt hozzáférnél az alakzathoz.

A teljes példáért, amely az alakzat- és táblacella-tulajdonosokat, valamint a SmartArt csomópontokhoz tartozó alakzatokat azonosítja, lásd a [Szöveg keresése és cseréje](/slides/hu/net/search-and-replace-text/) oldalt.

## **Oszlopok hozzáadása egy szövegdobozhoz**

Az Aspose.Slides biztosítja a [ColumnCount](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/properties/columncount) és a [ColumnSpacing](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat/properties/columnspacing) tulajdonságokat (az [ITextFrameFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat) interfész és a [TextFrameFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat) osztály részeként), hogy oszlopokat adhass a szövegdobozokhoz. Megadhatod a szövegdoboz oszlopainak számát, majd a pontokban megadott távolságot az oszlopok között.

Ez a C# kód bemutatja a leírt műveletet: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// Lekéri az első diát a prezentációból
	ISlide slide = presentation.Slides[0];

	// Hozzáad egy AutoShape-et, amelynek típusa Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Hozzáad egy TextFrame-et a Rectangle-hez
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Lekéri a TextFrame szövegformátumát
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Megadja a oszlopok számát a TextFrame-ben
	format.ColumnCount = 3;

	// Megadja az oszlopok közti távolságot
	format.ColumnSpacing = 10;

	// Mentés a prezentáció
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Oszlopok hozzáadása egy szövegkerethez**

Az Aspose.Slides for .NET biztosítja a [ColumnCount](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/properties/columncount) tulajdonságot (az [ITextFrameFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat) interfész részeként), amely lehetővé teszi oszlopok hozzáadását a szövegkeretekhez. Ezzel a tulajdonsággal megadhatod a kívánt oszlopszámot egy szövegkeretben. 

Ez a C# kód megmutatja, hogyan adj egy oszlopot egy szövegkerethez:

```c#
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.IsNaN(((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing));
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **Szöveg frissítése**

Az Aspose.Slides lehetővé teszi, hogy módosítsd vagy frissítsd a szövegdobozban vagy a prezentációban lévő összes szöveget. 

Ez a C# kód bemutat egy műveletet, amelyben a prezentáció összes szövegét frissítik vagy módosítják:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Ellenőrzi, hogy az alakzat támogatja-e a szövegkeretet (IAutoShape).
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Végigiterál a szövegkeret bekezdésein.
               {
                   foreach (IPortion portion in paragraph.Portions) //Végigiterál a bekezdés minden részén.
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Módosítja a szöveget.
                       portion.PortionFormat.FontBold = NullableBool.True; //Módosítja a formázást.
                   }
               }
           }
       }
   }
  
   //Mentés a módosított prezentáció.
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Szövegdoboz hozzáadása hiperhivatkozással** 

Egy linket szúrhatsz be egy szövegdobozba. Amikor a szövegdobozra kattintanak, a felhasználók a hivatkozás megnyitására kerülnek. 

1. Hozz létre egy `Presentation` osztálypéldányt. 
2. Szerezd meg az első dia referenciaját az indexén keresztül.  
3. Adj hozzá egy `AutoShape` objektumot, amelynek a `ShapeType` értéke `Rectangle`, a dián egy megadott pozícióban, és kapj referenciát az újonnan hozzáadott AutoShape objektumra. 
4. Adj egy `TextFrame` elemet az `AutoShape` objektumhoz, amely alapértelmezett szövegként a *Aspose TextBox* szöveget tartalmazza. 
5. Hozd létre az `IHyperlinkManager` osztályt. 
6. Rendeld az `IHyperlinkManager` objektumot a [HyperlinkClick](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/properties/hyperlinkclick) tulajdonsághoz, amely az általad választott `TextFrame` részhez kapcsolódik. 
7. Végül írd ki a PPTX fájlt a `Presentation` objektumon keresztül. 

Ez a C# kód – a fenti lépések megvalósítása – megmutatja, hogyan adj hiperhivatkozással rendelkező szövegdobozt egy diához:

```c#
using Aspose.Slides;

// Példányosít egy Presentation osztályt, amely egy PPTX-et képvisel
Presentation pptxPresentation = new Presentation();

// Lekéri az első diát a prezentációból
ISlide slide = pptxPresentation.Slides[0];

// Hozzáad egy AutoShape objektumot, amelynek típusa Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Átkonvertálja az alakzatot AutoShape-re
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Hozzáfér az AutoShape-hez kapcsolódó ITextFrame tulajdonsághoz
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Szöveget ad hozzá a kerethez
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Beállítja a hiperhivatkozást a rész szövegéhez
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Mentés a PPTX prezentációként
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Gyakran ismételt kérdések**

**Mi a különbség egy szövegdoboz és egy szöveghelyőrző között, amikor fő diákon dolgozol?**

Egy [placeholder](/slides/hu/net/manage-placeholder/) örökli a stílust/pozíciót a [master](https://reference.aspose.com/slides/hu/net/aspose.slides/masterslide/) diától, és felülírható a [layouts](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutslide/)-on, míg egy hagyományos szövegdoboz egy önálló objektum egy adott dián, és nem változik, ha elrendezést cserélsz.

**Hogyan lehet tömeges szövegcserét végrehajtani a teljes prezentáción anélkül, hogy a diagramok, táblázatok és SmartArt szövegét érintenénk?**

Korlátozd az iterációt azokra az automatikus alakzatokra, amelyek szövegkeretekkel rendelkeznek, és vedd ki a beágyazott objektumokat ([charts](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/hu/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/smartart/)) úgy, hogy külön gyűjteményeiken végigsétálsz, vagy kihagyod ezeket az objektumtípusokat.