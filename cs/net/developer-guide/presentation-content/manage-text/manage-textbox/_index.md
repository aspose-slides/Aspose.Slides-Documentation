---
title: Správa textových polí v prezentacích v .NET
linktitle: Správa textového pole
type: docs
weight: 20
url: /cs/net/manage-textbox/
keywords:
- textové pole
- textový rámec
- přidat text
- aktualizovat text
- vytvořit textové pole
- zkontrolovat textové pole
- přidat sloupec textu
- přidat hyperodkaz
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides pro .NET usnadňuje vytváření, úpravu a klonování textových polí v souborech PowerPoint a OpenDocument, což zvyšuje efektivitu automatizace vašich prezentací."
---
## **Úvod**

Texty na snímcích jsou obvykle umístěny v textových polích nebo tvarech. Proto musíte nejprve přidat textové pole a teprve potom do něj vložit text. 

Chcete‑li přidat tvar, který může obsahovat text, poskytuje Aspose.Slides pro .NET rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape). 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides také poskytuje rozhraní [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape), které umožňuje přidávat tvary na snímky. Ne všechny tvary přidané pomocí rozhraní `IShape` mohou obsahovat text. Tvary přidané pomocí rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape) obvykle text obsahují. 

Proto při práci s existujícím tvarem, ke kterému chcete přidat text, byste měli ověřit, že byl převeden pomocí rozhraní `IAutoShape`. Teprve pak můžete pracovat s [TextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/properties/textframe), který je vlastností rozhraní `IAutoShape`. Viz sekce [Update Text](https://docs.aspose.com/slides/cs/net/manage-textbox/#update-text) na této stránce. 

{{% /alert %}}

## **Vytvoření textového pole na snímku**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation). 
2. Získejte odkaz na první snímek pomocí jeho indexu. 
3. Přidejte objekt [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape) s nastavením [ShapeType](https://reference.aspose.com/slides/cs/net/aspose.slides/igeometryshape/properties/shapetype) na `Rectangle` na zadané pozici na snímku a získejte odkaz na nově přidaný objekt `IAutoShape`. 
4. Přidejte vlastnost `TextFrame` k objektu `IAutoShape`, která bude obsahovat text. V níže uvedeném příkladu jsme přidali tento text: *Aspose TextBox* 
5. Nakonec uložte soubor PPTX pomocí objektu `Presentation`. 

Tento C# kód – implementace výše uvedených kroků – ukazuje, jak přidat text na snímek:

```c#
using Aspose.Slides;

// Vytvoří instanci PresentationEx
using (Presentation pres = new Presentation())
{

    // Získá první snímek v prezentaci
    ISlide sld = pres.Slides[0];

    // Přidá AutoShape s typem nastaveným na Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Přidá TextFrame do obdélníku
    ashp.AddTextFrame(" ");

    // Přistupuje k textovému rámci
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

## **Kontrola, zda se jedná o tvar textového pole**

Aspose.Slides poskytuje vlastnost [IsTextBox](https://reference.aspose.com/slides/cs/net/aspose.slides/autoshape/istextbox/) rozhraní [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/), která umožňuje prozkoumat tvary a identifikovat textová pole.

![Textové pole a tvar](istextbox.png)

Tento C# kód ukazuje, jak zkontrolovat, zda byl tvar vytvořen jako textové pole: 

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

Všimněte si, že pokud pouze přidáte automatický tvar pomocí metody `AddAutoShape` rozhraní [IShapeCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/), vlastnost `IsTextBox` automatického tvaru vrátí `false`. Po přidání textu do automatického tvaru pomocí metody `AddTextFrame` nebo vlastnosti `Text` se pak `IsTextBox` vrátí `true`.

```cs
using Aspose.Slides;

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

## **Vyhledání tvaru, který vlastní TextFrame**

V obecné kódu pro zpracování textu můžete obdržet objekt [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/) aniž byste věděli, který objekt prezentace jej obsahuje. Použijte vlastnost [ITextFrame.ParentShape](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/parentshape/) k návratu k vlastnímu [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/).

Pro TextFrame, který patří k [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) nebo jinému tvaru obsahujícímu text, je nastavena vlastnost [ITextFrame.ParentShape](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/parentshape/) a [ITextFrame.ParentCell](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/parentcell/) je `null`. Obě vlastnosti jsou jen pro čtení, takže jejich čtení nemění vlastnictví. Vždy před přístupem k tvaru zkontrolujte, zda vrácená hodnota není `null`.

Kompletní příklad, který identifikuje vlastníky tvarů a buněk tabulek, včetně tvarů spojených s uzly SmartArt, najdete v sekci [Search and Replace Text](/slides/cs/net/search-and-replace-text/).

## **Přidání sloupců do textového pole**

Aspose.Slides poskytuje vlastnosti [ColumnCount](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/properties/columncount) a [ColumnSpacing](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat/properties/columnspacing) (z rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat) a třídy [TextFrameFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/textframeformat)), které umožňují přidat sloupce do textových polí. Můžete zadat počet sloupců v textovém poli a poté mezeru v bodech mezi sloupci. 

Tento C# kód demonstruje popsanou operaci: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// Získá první snímek v prezentaci
	ISlide slide = presentation.Slides[0];

	// Přidá AutoShape s typem nastaveným na Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Přidá TextFrame do obdélníku
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

## **Přidání sloupců do TextFrame**

Aspose.Slides for .NET poskytuje vlastnost [ColumnCount](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat/properties/columncount) (z rozhraní [ITextFrameFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframeformat)), která umožňuje přidat sloupce v TextFrame. Pomocí této vlastnosti můžete určit požadovaný počet sloupců v TextFrame. 

 Tento C# kód ukazuje, jak přidat sloupec do TextFrame:

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

## **Aktualizace textu**

Aspose.Slides vám umožňuje změnit nebo aktualizovat text obsažený v textovém poli nebo veškerý text v celé prezentaci. 

Tento C# kód demonstruje operaci, při níž jsou aktualizovány nebo změněny všechny texty v prezentaci:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Kontroluje, zda tvar podporuje textový rámec (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Prochází odstavce v textovém rámci
               {
                   foreach (IPortion portion in paragraph.Portions) //Prochází každou část v odstavci
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Mění text
                       portion.PortionFormat.FontBold = NullableBool.True; //Mění formátování
                   }
               }
           }
       }
   }
  
   //Ukládá upravenou prezentaci
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Přidání textového pole s hyperodkazem** 

Do textového pole můžete vložit odkaz. Po kliknutí na textové pole se uživatelé přesměrují na tento odkaz. 

1. Vytvořte instanci třídy `Presentation`. 
2. Získejte odkaz na první snímek pomocí jeho indexu.  
3. Přidejte objekt `AutoShape` s nastavením `ShapeType` na `Rectangle` na zadané pozici na snímku a získejte odkaz na nově přidaný objekt AutoShape. 
4. Přidejte `TextFrame` k objektu `AutoShape`, který bude obsahovat *Aspose TextBox* jako výchozí text. 
5. Vytvořte instanci třídy `IHyperlinkManager`. 
6. Přiřaďte objekt `IHyperlinkManager` k vlastnosti [HyperlinkClick](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/properties/hyperlinkclick) spojené s požadovanou částí `TextFrame`. 
7. Nakonec uložte soubor PPTX pomocí objektu `Presentation`. 

Tento C# kód – implementace výše uvedených kroků – ukazuje, jak přidat textové pole s hyperodkazem na snímek:

```c#
using Aspose.Slides;

// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
Presentation pptxPresentation = new Presentation();

// Získá první snímek v prezentaci
ISlide slide = pptxPresentation.Slides[0];

// Přidá objekt AutoShape s nastaveným typem na Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Přetypuje tvar na AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Přistupuje k vlastnosti ITextFrame spojené s AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Přidá text do rámce
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Nastaví hyperodkaz pro text části
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Uloží PPTX prezentaci
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Časté dotazy**

**Jaký je rozdíl mezi textovým polem a textovým zástupcem při práci s master snímky?**

[Placeholder](/slides/cs/net/manage-placeholder/) dědí styl/pozici z [masteru](https://reference.aspose.com/slides/cs/net/aspose.slides/masterslide/) a může být přepsán na [layoutách](https://reference.aspose.com/slides/cs/net/aspose.slides/layoutslide/), zatímco běžné textové pole je samostatný objekt na konkrétním snímku a nezmění se při přepínání layoutů.

**Jak provést hromadnou výměnu textu v celé prezentaci, aniž bych zasáhl do textu v diagramech, tabulkách a SmartArt?**

Omezte iteraci na automatické tvary, které mají TextFrame, a vyloučte vložené objekty ([grafy](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chart/), [tabulky](https://reference.aspose.com/slides/cs/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/cs/net/aspose.slides.smartart/smartart/)) tím, že projdete jejich kolekce samostatně nebo přeskočíte tyto typy objektů.