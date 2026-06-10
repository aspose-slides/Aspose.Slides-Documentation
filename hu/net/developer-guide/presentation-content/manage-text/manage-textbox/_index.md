---
title: Szövegdobozok kezelése prezentációkban .NET környezetben
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
- szövegoszlop hozzáadása
- hiperhivatkozás hozzáadása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Az Aspose.Slides for .NET megkönnyíti a szövegdobozok létrehozását, szerkesztését és klónozását PowerPoint és OpenDocument fájlokban, ezáltal javítva a prezentáció automatizálását."
---
## **Bevezetés**

A diákon a szövegek általában szövegdobozokban vagy alakzatokban találhatók. Ezért a szöveg hozzáadásához egy diára először szövegdobozt kell létrehozni, majd szöveget beilleszteni a szövegdobozba. 

Ahhoz, hogy szöveget tartalmazó alakzatot adhassunk hozzá, az Aspose.Slides for .NET a [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape) interfészt biztosítja. 

{{% alert title="Note" color="warning" %}} 

Az Aspose.Slides emellett a [IShape](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape) interfészt is biztosítja, amely lehetővé teszi alakzatok hozzáadását a diákhoz. Azonban a `IShape` interfészen keresztül hozzáadott nem minden alakzat képes szöveget tartalmazni. A [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape) interfészen keresztül hozzáadott alakzatok általában szöveget tartalmaznak. 

Ezért, ha egy már létező alakzattal dolgozik, amelyhez szöveget szeretne hozzáadni, ellenőrizni kell, hogy az `IAutoShape` interfészen keresztül lett-e konvertálva. csak ekkor lesz lehetőség a [TextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/properties/textframe) használatára, amely az `IAutoShape` része. Lásd a [Update Text](https://docs.aspose.com/slides/hu/net/manage-textbox/#update-text) részt ezen az oldalon. 

{{% /alert %}}

## **Szövegdoboz létrehozása egy dián**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztályból. 
2. Szerezze meg az első dia hivatkozását az indexe alapján. 
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape) objektumot, ahol a [ShapeType](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometryshape/properties/shapetype) `Rectangle` értékre van állítva, a dia meghatározott pozíciójában, és szerezze meg az újonnan hozzáadott `IAutoShape` objektum hivatkozását. 
4. Adjon egy `TextFrame` tulajdonságot az `IAutoShape` objektumhoz, amely szöveget fog tartalmazni. Az alábbi példában ezt a szöveget adtuk hozzá: *Aspose TextBox*
5. Végül írja ki a PPTX fájlt a `Presentation` objektumon keresztül. 

Ez a C# kód – a fenti lépések megvalósítása – megmutatja, hogyan adhat szöveget egy diához:

```c#
// Létrehozza a PresentationEx példányt
using (Presentation pres = new Presentation())
{

    // Lekéri az első diát a prezentációban
    ISlide sld = pres.Slides[0];

    // AutoShape-ot ad hozzá, típusként Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // TextFrame-et ad a Rectangle-hez
    ashp.AddTextFrame(" ");

    // Hozzáfér a szövegkerethez
    ITextFrame txtFrame = ashp.TextFrame;

    // Létrehozza a Paragraph objektumot a szövegkerethez
    IParagraph para = txtFrame.Paragraphs[0];

    // Létrehozza a Portion objektumot a bekezdéshez
    IPortion portion = para.Portions[0];

    // Beállítja a szöveget
    portion.Text = "Aspose TextBox";

    // Mentés a prezentáció a lemezre
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Szövegdoboz alakzat ellenőrzése**

Az Aspose.Slides a [IsTextBox](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/istextbox/) tulajdonságot biztosítja a [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) interfészen keresztül, lehetővé téve az alakzatok vizsgálatát és a szövegdobozok azonosítását.

![Text box and shape](istextbox.png)

Ez a C# kód megmutatja, hogyan ellenőrizheti, hogy egy alakzat szövegdobozként jött-e létre:

```c#
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

Vegye figyelembe, hogy ha egyszerűen csak egy autoshape‑t ad hozzá az [IShapeCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/) interfész `AddAutoShape` metódusával, az autoshape `IsTextBox` tulajdonsága `false` értéket ad vissza. Azonban ha szöveget ad hozzá az autoshape‑hez a `AddTextFrame` metódussal vagy a `Text` tulajdonsággal, az `IsTextBox` tulajdonság `true` értéket ad vissza.

```cs
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

## **Oszlopok hozzáadása egy szövegdobozhoz**

Az Aspose.Slides a [ColumnCount](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/properties/columncount) és a [ColumnSpacing](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat/properties/columnspacing) tulajdonságokat (az [ITextFrameFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat) interfész és a [TextFrameFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/textframeformat) osztály része) biztosítja, amelyekkel oszlopokat adhat a szövegdobozokhoz. Megadhatja a szövegdobozban lévő oszlopok számát, majd a pontokban megadott távolságot az oszlopok között. 

Ez a C# kód bemutatja a leírt műveletet:

```c#
using (Presentation presentation = new Presentation())
{
	// Lekéri az első diát a prezentációban
	ISlide slide = presentation.Slides[0];

	// AutoShape-ot ad hozzá, típusként Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// TextFrame-et ad a Rectangle-hez
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Lekéri a TextFrame szövegformátumát
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Megadja az oszlopok számát a TextFrame-ben
	format.ColumnCount = 3;

	// Megadja az oszlopok közötti távolságot
	format.ColumnSpacing = 10;

	// Mentés a prezentáció
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Oszlopok hozzáadása egy szövegkerethez**

Az Aspose.Slides for .NET a [ColumnCount](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/properties/columncount) tulajdonságot (az [ITextFrameFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat) interfész része) biztosítja, amely lehetővé teszi oszlopok hozzáadását a szövegkeretekhez. Ezzel a tulajdonsággal megadhatja a kívánt oszlopszámot egy szövegkeretben. 

Ez a C# kód megmutatja, hogyan adhat oszlopot egy szövegkeretbe:

```c#
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
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
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

Az Aspose.Slides lehetővé teszi egy szövegdobozban vagy egy teljes prezentációban lévő szöveg módosítását vagy frissítését. 

Ez a C# kód bemutat egy olyan műveletet, amelyben egy prezentáció összes szövegét frissítik vagy módosítják:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Ellenőrzi, hogy a forma támogatja-e a szövegkeretet (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Végigiterál a szövegkeret bekezdésein
               {
                   foreach (IPortion portion in paragraph.Portions) //Végigiterál a bekezdés minden részletén
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Módosítja a szöveget
                       portion.PortionFormat.FontBold = NullableBool.True; //Módosítja a formázást
                   }
               }
           }
       }
   }
  
   //Elmenti a módosított prezentációt
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Szövegdoboz hozzáadása hiperhivatkozással** 

Egy szövegdobozba beilleszthet linket. Amikor a szövegdobozt rákattintják, a felhasználók a hivatkozás megnyitására kerülnek. 

1. Hozzon létre egy példányt a `Presentation` osztályból. 
2. Szerezze meg az első dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy `AutoShape` objektumot, ahol a `ShapeType` `Rectangle` értékre van állítva, a dia meghatározott pozíciójában, és szerezze meg az újonnan hozzáadott AutoShape objektum hivatkozását.
4. Adjon egy `TextFrame`‑et az `AutoShape` objektumhoz, amely az alapértelmezett szövegként a *Aspose TextBox* szöveget tartalmazza. 
5. Hozza létre az `IHyperlinkManager` osztályt. 
6. Rendelje hozzá az `IHyperlinkManager` objektumot a [HyperlinkClick](https://reference.aspose.com/slides/hu/net/aspose.slides/shape/properties/hyperlinkclick) tulajdonsághoz, amely a `TextFrame` kívánt részéhez kapcsolódik. 
7. Végül írja ki a PPTX fájlt a `Presentation` objektumon keresztül. 

Ez a C# kód – a fenti lépések megvalósítása – megmutatja, hogyan adhat hiperhivatkozással ellátott szövegdobozt egy diához:

```c#
// Példányosít egy Presentation osztályt, amely egy PPTX-et képvisel
Presentation pptxPresentation = new Presentation();

// Lekéri a prezentáció első diáját
ISlide slide = pptxPresentation.Slides[0];

// AutoShape objektumot ad hozzá, típus beállítva Rectangle-re
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Átkonvertálja a formát AutoShape-re
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Eléri az AutoShape-hez tartozó ITextFrame tulajdonságot
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Néhány szöveget ad a kerethez
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Beállítja a hiperhivatkozást a részlet szövegéhez
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Elmenti a PPTX prezentációt
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **GYIK**

**Mi a különbség egy szövegdoboz és egy szöveghelytartó között a mesterdia használatakor?**

A [placeholder](/slides/hu/net/manage-placeholder/) az [mester](https://reference.aspose.com/slides/hu/net/aspose.slides/masterslide/) stílusát/pozícióját örökli, és a [layoutok](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutslide/) során felülírható, míg egy szabályos szövegdoboz egy adott dián önálló objektum, amely nem változik a layout váltásakor.

**Hogyan hajthatok végre tömeges szövegcsere műveletet a teljes prezentáción anélkül, hogy a diagramok, táblázatok és SmartArt szövegét érinteném?**

Korlátozza az iterációt azokra az autoshape‑okra, amelyek szövegkeretekkel rendelkeznek, és hagyja ki a beágyazott objektumokat ([diagramok](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/chart/), [táblázatok](https://reference.aspose.com/slides/hu/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/smartart/)) úgy, hogy külön gyűjteményeken keresztül járja be őket, vagy kihagyja ezeket az objektumtípusokat.