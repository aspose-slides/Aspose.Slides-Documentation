---
title: Správa textových rámečků v prezentacích v .NET
linktitle: Správa textového rámečku
type: docs
weight: 20
url: /cs/net/manage-textbox/
keywords:
- textový rámeček
- textový rámec
- přidat text
- aktualizovat text
- vytvořit textový rámeček
- zkontrolovat textový rámeček
- přidat textový sloupec
- přidat hyperodkaz
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides pro .NET usnadňuje vytváření, úpravu a klonování textových rámečků v souborech PowerPoint a OpenDocument, čímž vylepšuje automatizaci vašich prezentací."
---
## **Úvod**

Texty na snímcích jsou obvykle v textových rámečcích nebo tvarech. Proto musíte nejprve přidat textový rámeček a poté do něj vložit text. 

Chcete‑li přidat tvar, který může obsahovat text, poskytuje Aspose.Slides pro .NET rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape) interface. 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides také poskytuje rozhraní [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape), které umožňuje přidávat tvary na snímky. Nicméně ne všechny tvary přidané přes rozhraní `IShape` mohou obsahovat text. Tvary přidané přes rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape) obvykle obsahují text. 

Proto, když pracujete s existujícím tvarem, ke kterému chcete přidat text, můžete chtít zkontrolovat a potvrdit, že byl přetypován na rozhraní `IAutoShape`. Teprve poté budete moci pracovat s [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/properties/textframe), který je vlastností pod `IAutoShape`. Viz sekce [Update Text](https://docs.aspose.com/slides/cs/net/manage-textbox/#update-text) na této stránce. 

{{% /alert %}}

## **Vytvoření textového rámečku na snímku**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation). 
2. Získejte referenci na první snímek pomocí jeho indexu. 
3. Přidejte objekt [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape) s [ShapeType](https://reference.aspose.com/slides/cs/net/aspose.slides/igeometryshape/properties/shapetype) nastaveným na `Rectangle` na určené pozici na snímku a získejte referenci na nově přidaný objekt `IAutoShape`. 
4. Přidejte vlastnost `TextFrame` k objektu `IAutoShape`, která bude obsahovat text. V níže uvedeném příkladu jsme přidali tento text: *Aspose TextBox*
5. Nakonec zapište soubor PPTX pomocí objektu `Presentation`. 

Tento kód v jazyce C# — implementace výše uvedených kroků — ukazuje, jak přidat text na snímek:

```c#
// Vytvoří instanci PresentationEx
using (Presentation pres = new Presentation())
{

    // Získá první snímek v prezentaci
    ISlide sld = pres.Slides[0];

    // Přidá AutoShape s typem nastaveným na Obdélník
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Přidá TextFrame do Obdélníku
    ashp.AddTextFrame(" ");

    // Získá přístup k textovému rámci
    ITextFrame txtFrame = ashp.TextFrame;

    // Vytvoří objekt Paragraph pro textový rámec
    IParagraph para = txtFrame.Paragraphs[0];

    // Vytvoří objekt Portion pro odstavec
    IPortion portion = para.Portions[0];

    // Nastaví text
    portion.Text = "Aspose TextBox";

    // Uloží prezentaci na disk
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Kontrola, zda jde o textový rámeček**

Aspose.Slides poskytuje vlastnost [IsTextBox](https://reference.aspose.com/slides/cs/net/aspose.slides/autoshape/istextbox/) z rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/), která umožňuje zkoumat tvary a identifikovat textové rámečky.

![Textový rámeček a tvar](istextbox.png)

Tento kód v jazyce C# ukazuje, jak zkontrolovat, zda byl tvar vytvořen jako textový rámeček: 

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

Všimněte si, že pokud jednoduše přidáte autoshape pomocí metody `AddAutoShape` z rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/), vlastnost `IsTextBox` tohoto autoshape vrátí `false`. Po přidání textu do autoshape pomocí metody `AddTextFrame` nebo vlastnosti `Text` však vlastnost `IsTextBox` vrátí `true`.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox je nepravda
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox je pravda

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox je nepravda
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox je pravda

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox je nepravda
    shape3.AddTextFrame("");
    // shape3.IsTextBox je nepravda

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox je nepravda
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox je nepravda
}
```

## **Přidání sloupců do textového rámečku**

Aspose.Slides poskytuje vlastnosti [ColumnCount](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/properties/columncount) a [ColumnSpacing](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat/properties/columnspacing) (z rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat) a třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat)), které umožňují přidávat sloupce do textových rámečků. Můžete zadat počet sloupců v textovém rámečku a následně vzdálenost v bodech mezi sloupci. 

Tento kód v jazyce C# demonstruje popsanou operaci: 

```c#
using (Presentation presentation = new Presentation())
{
	// Získá první snímek v prezentaci
	ISlide slide = presentation.Slides[0];

	// Přidá AutoShape s typem nastaveným na Obdélník
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Přidá TextFrame do Obdélníku
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Získá formát textu TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Určuje počet sloupců v TextFrame
	format.ColumnCount = 3;

	// Určuje mezery mezi sloupci
	format.ColumnSpacing = 10;

	// Uloží prezentaci
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Přidání sloupců do textového rámce**

Aspose.Slides pro .NET poskytuje vlastnost [ColumnCount](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/properties/columncount) (z rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat)), která umožňuje přidávat sloupce v textových rámcích. Touto vlastností můžete nastavit požadovaný počet sloupců v textovém rámci. 

Tento kód v jazyce C# ukazuje, jak přidat sloupec do textového rámce:

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

## **Aktualizace textu**

Aspose.Slides vám umožňuje změnit nebo aktualizovat text obsažený v textovém rámečku nebo veškerý text v celé prezentaci. 

Tento kód v jazyce C# demonstruje operaci, při níž je aktualizován nebo změněn veškerý text v prezentaci:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Kontroluje, zda tvar podporuje textový rámec (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Iteruje přes odstavce v textovém rámci
               {
                   foreach (IPortion portion in paragraph.Portions) //Iteruje přes každou část v odstavci
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Mění text
                       portion.PortionFormat.FontBold = NullableBool.True; //Mění formátování
                   }
               }
           }
       }
   }
  
   //Uloží upravenou prezentaci
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Přidání textového rámečku s hyperodkazem** 

Do textového rámečku můžete vložit odkaz. Když je na textový rámeček kliknuto, uživatelé jsou přesměrováni k otevření odkazu. 

1. Vytvořte instanci třídy `Presentation`. 
2. Získejte referenci na první snímek pomocí jeho indexu.  
3. Přidejte objekt `AutoShape` s `ShapeType` nastaveným na `Rectangle` na určené pozici na snímku a získejte referenci na nově přidaný objekt AutoShape.
4. Přidejte `TextFrame` k objektu `AutoShape`, který obsahuje *Aspose TextBox* jako výchozí text. 
5. Vytvořte instanci třídy `IHyperlinkManager`. 
6. Přiřaďte objekt `IHyperlinkManager` k vlastnosti [HyperlinkClick](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/properties/hyperlinkclick) spojené s požadovanou částí `TextFrame`. 
7. Nakonec zapište soubor PPTX pomocí objektu `Presentation`. 

Tento kód v jazyce C# — implementace výše uvedených kroků — ukazuje, jak přidat textový rámeček s hyperodkazem na snímek:

```c#
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pptxPresentation = new Presentation();

// Získá první snímek v prezentaci
ISlide slide = pptxPresentation.Slides[0];

// Přidá objekt AutoShape s typem nastaveným na Obdélník
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Přetypuje tvar na AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Získá přístup k vlastnosti ITextFrame spojené s AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Přidá nějaký text do rámce
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Nastaví hyperodkaz pro text části
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Uloží PPTX prezentaci
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Jaký je rozdíl mezi textovým rámečkem a textovým zástupcem při práci s hlavními snímky?**

Zástupce [placeholder](/slides/cs/net/manage-placeholder/) dědí styl/pozici z [masteru](https://reference.aspose.com/slides/cs/net/aspose.slides/masterslide/) a může být přepsán na [rozvrzích](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutslide/), zatímco běžný textový rámeček je nezávislý objekt na konkrétním snímku a nemění se při přepínání rozvržení.

**Jak mohu provést hromadnou výměnu textu v celé prezentaci, aniž by byly dotčeny texty v grafech, tabulkách a SmartArt?**

Omezte iteraci na autoshapes, které mají textové rámce, a vyloučte vložené objekty ([grafy](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chart/), [tabulky](https://reference.aspose.com/slides/cs/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/smartart/)) tím, že jejich kolekce projdete samostatně nebo tyto typy objektů přeskočíte.