---
title: Beheer tekstvakken in presentaties in .NET
linktitle: Beheer tekstvak
type: docs
weight: 20
url: /nl/net/manage-textbox/
keywords:
- tekstvak
- tekstframe
- tekst toevoegen
- tekst bijwerken
- tekstvak maken
- tekstvak controleren
- tekstkolom toevoegen
- hyperlink toevoegen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides voor .NET maakt het gemakkelijk om tekstvakken te maken, bewerken en klonen in PowerPoint- en OpenDocument‑bestanden, waardoor uw presentatietautomatisering wordt verbeterd."
---
## **Inleiding**

Teksten op dia’s staan meestal in tekstvakken of vormen. Daarom moet je eerst een tekstvak toevoegen aan een dia en vervolgens tekst in dat tekstvak plaatsen. 

Om een vorm toe te voegen die tekst kan bevatten, biedt Aspose.Slides voor .NET de [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape)‑interface. 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides biedt ook de [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape)‑interface om vormen toe te voegen aan dia’s. Niet alle vormen die via de `IShape`‑interface worden toegevoegd, kunnen echter tekst bevatten. Vormen die via de [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape)‑interface worden toegevoegd, bevatten doorgaans tekst. 

Wanneer je met een bestaande vorm werkt waaraan je tekst wilt toevoegen, wil je mogelijk eerst controleren of deze via de `IAutoShape`‑interface is gecast. Alleen dan kun je werken met [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/properties/textframe), een eigenschap van `IAutoShape`. Zie de sectie [Update Text](https://docs.aspose.com/slides/nl/net/manage-textbox/#update-text) op deze pagina. 

{{% /alert %}}

## **Een tekstvak op een dia maken**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.  
2. Haal de referentie naar de eerste dia op via de index.  
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape)‑object toe met [ShapeType](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometryshape/properties/shapetype) ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg de referentie naar het nieuw toegevoegde `IAutoShape`‑object.  
4. Voeg de eigenschap `TextFrame` toe aan het `IAutoShape`‑object zodat het tekst bevat. In het voorbeeld hieronder hebben we de tekst *Aspose TextBox* toegevoegd.  
5. Schrijf tenslotte het PPTX‑bestand weg via het `Presentation`‑object.  

Deze C#‑code—een implementatie van de bovenstaande stappen—laat zien hoe je tekst aan een dia toevoegt:

```c#
// Instantieert PresentationEx
using (Presentation pres = new Presentation())
{

    // Haalt de eerste dia op in de presentatie
    ISlide sld = pres.Slides[0];

    // Voegt een AutoShape toe met type ingesteld op Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Voegt een TextFrame toe aan de rechthoek
    ashp.AddTextFrame(" ");

    // Toegang tot het tekstframe
    ITextFrame txtFrame = ashp.TextFrame;

    // Creëert het Paragraph‑object voor het tekstframe
    IParagraph para = txtFrame.Paragraphs[0];

    // Creëert een Portion‑object voor de alinea
    IPortion portion = para.Portions[0];

    // Stelt de tekst in
    portion.Text = "Aspose TextBox";

    // Slaat de presentatie op schijf
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Controleren op een tekstvakvorm**

Aspose.Slides biedt de eigenschap [IsTextBox](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/istextbox/) van de [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/)‑interface, waarmee je vormen kunt onderzoeken en tekstvakken kunt identificeren.

![Text box and shape](istextbox.png)

Deze C#‑code toont hoe je kunt controleren of een vorm als tekstvak is aangemaakt: 

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

Merk op dat wanneer je eenvoudigweg een AutoShape toevoegt met de `AddAutoShape`‑methode van de [IShapeCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/)‑interface, de `IsTextBox`‑eigenschap van de AutoShape `false` retourneert. Nadat je echter tekst toevoegt aan de AutoShape met de `AddTextFrame`‑methode of de `Text`‑eigenschap, geeft `IsTextBox` `true` terug.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox is onwaar
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox is waar

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox is onwaar
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox is waar

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox is onwaar
    shape3.AddTextFrame("");
    // shape3.IsTextBox is onwaar

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox is onwaar
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox is onwaar
}
```

## **Kolommen toevoegen aan een tekstvak**

Aspose.Slides biedt de eigenschappen [ColumnCount](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/properties/columncount) en [ColumnSpacing](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat/properties/columnspacing) (van de [ITextFrameFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat)‑interface en de [TextFrameFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat)‑klasse) om kolommen aan tekstvakken toe te voegen. Je kunt het aantal kolommen in een tekstvak opgeven en vervolgens de afstand in punten tussen de kolommen bepalen. 

Deze C#‑code demonstreert de beschreven bewerking: 

```c#
using (Presentation presentation = new Presentation())
{
	// Haalt de eerste dia op in de presentatie
	ISlide slide = presentation.Slides[0];

	// Voeg een AutoShape toe met type ingesteld op Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Voeg een TextFrame toe aan de rechthoek
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Haalt het tekstformaat van TextFrame op
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Bepaalt het aantal kolommen in TextFrame
	format.ColumnCount = 3;

	// Bepaalt de afstand tussen kolommen
	format.ColumnSpacing = 10;

	// Slaat de presentatie op
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Kolommen toevoegen aan een tekstframe**

Aspose.Slides for .NET biedt de eigenschap [ColumnCount](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/properties/columncount) (van de [ITextFrameFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat)‑interface) waarmee je kolommen in tekstframes kunt toevoegen. Via deze eigenschap kun je het gewenste aantal kolommen in een tekstframe opgeven. 

Deze C#‑code laat zien hoe je een kolom toevoegt binnen een tekstframe:

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

## **Tekst bijwerken**

Aspose.Slides stelt je in staat de tekst in een tekstvak of alle teksten in een presentatie te wijzigen of bij te werken. 

Deze C#‑code demonstreert een bewerking waarbij alle teksten in een presentatie worden bijgewerkt of veranderd:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Controleert of de vorm een tekstframe ondersteunt (IAutoShape).
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Itereert door alinea's in het tekstframe
               {
                   foreach (IPortion portion in paragraph.Portions) //Itereert door elke portion in de alinea
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Wijzigt de tekst
                       portion.PortionFormat.FontBold = NullableBool.True; //Wijzigt de opmaak
                   }
               }
           }
       }
   }
  
   //Slaat de gewijzigde presentatie op
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Een tekstvak met een hyperlinks toevoegen** 

Je kunt een koppeling in een tekstvak invoegen. Wanneer op het tekstvak wordt geklikt, wordt de gebruiker naar de koppeling geleid. 

1. Maak een instantie van de `Presentation`‑klasse.  
2. Haal de referentie naar de eerste dia op via de index.  
3. Voeg een `AutoShape`‑object toe met `ShapeType` ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg een referentie naar het nieuw toegevoegde AutoShape‑object.  
4. Voeg een `TextFrame` toe aan het `AutoShape`‑object dat *Aspose TextBox* als standaardtekst bevat.  
5. Instantieer de `IHyperlinkManager`‑klasse.  
6. Koppel het `IHyperlinkManager`‑object aan de [HyperlinkClick](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/properties/hyperlinkclick)‑eigenschap die bij het gewenste gedeelte van het `TextFrame` hoort.  
7. Schrijf tenslotte het PPTX‑bestand weg via het `Presentation`‑object. 

Deze C#‑code—een implementatie van de bovenstaande stappen—laat zien hoe je een tekstvak met een hyperlink aan een dia toevoegt:

```c#
// Instantieert een Presentation‑klasse die een PPTX voorstelt
Presentation pptxPresentation = new Presentation();

// Haalt de eerste dia op in de presentatie
ISlide slide = pptxPresentation.Slides[0];

// Voegt een AutoShape‑object toe met type ingesteld op Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Cast de vorm naar AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Benadert de ITextFrame‑eigenschap die bij de AutoShape hoort
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Voegt tekst toe aan het frame
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Stelt de hyperlink in voor de portion‑tekst
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Slaat de PPTX‑presentatie op
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Wat is het verschil tussen een tekstvak en een tekstopvulling wanneer je met masterdia’s werkt?**

Een [placeholder](/slides/nl/net/manage-placeholder/) erft stijl/positie van de [master](https://reference.aspose.com/slides/nl/net/aspose.slides/masterslide/) en kan worden overschreven op [layouts](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutslide/), terwijl een regulier tekstvak een onafhankelijk object op een specifieke dia is en niet verandert wanneer je van layout wisselt.

**Hoe kan ik een massale tekstvervanging uitvoeren in de hele presentatie zonder tekst in grafieken, tabellen en SmartArt aan te passen?**

Beperk de iteratie tot auto‑shapes die tekstframes bevatten en sluit ingesloten objecten ([charts](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/nl/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/smartart/)) uit door hun collecties apart te doorlopen of die objecttypen over te slaan.