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
description: "Aspose.Slides voor .NET maakt het eenvoudig om tekstvakken te maken, te bewerken en te dupliceren in PowerPoint- en OpenDocument-bestanden, waardoor uw presentatiesautomatisering wordt verbeterd."
---
## **Introductie**

Teksten op dia's bestaan meestal in tekstvakken of vormen. Daarom moet je eerst een tekstvak toevoegen en vervolgens wat tekst in het tekstvak plaatsen.

Om je een vorm toe te voegen die tekst kan bevatten, biedt Aspose.Slides voor .NET de [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape) interface. 

{{% alert title="Note" color="warning" %}} 

Aspose.Slides biedt ook de [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape) interface om vormen toe te voegen aan dia's. Echter, niet alle vormen die via de `IShape`-interface worden toegevoegd, kunnen tekst bevatten. Vormen die via de [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape) interface worden toegevoegd, bevatten doorgaans tekst. 

Daarom wil je bij het werken met een bestaande vorm waaraan je tekst wilt toevoegen, controleren en bevestigen dat deze via de `IAutoShape`-interface is gecast. Alleen dan kun je werken met [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/properties/textframe), een eigenschap onder `IAutoShape`. Zie de sectie [Update Text](https://docs.aspose.com/slides/nl/net/manage-textbox/#update-text) op deze pagina. 

{{% /alert %}}

## **Maak een tekstvak op een dia**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse. 
2. Haal de referentie van de eerste dia op via de index. 
3. Voeg een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape) object toe met [ShapeType](https://reference.aspose.com/slides/nl/net/aspose.slides/igeometryshape/properties/shapetype) ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg de referentie voor het nieuw toegevoegde `IAutoShape` object. 
4. Voeg een `TextFrame`-eigenschap toe aan het `IAutoShape` object die tekst zal bevatten. In het onderstaande voorbeeld hebben we deze tekst toegevoegd: *Aspose TextBox* 
5. Schrijf tenslotte het PPTX‑bestand weg via het `Presentation` object. 

Deze C#‑code – een implementatie van de bovenstaande stappen – toont hoe je tekst aan een dia toevoegt:

```c#
using Aspose.Slides;

// Instancieert PresentationEx
using (Presentation pres = new Presentation())
{

    // Haalt de eerste dia op in de presentatie
    ISlide sld = pres.Slides[0];

    // Voegt een AutoShape toe met type ingesteld op Rectangle
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Voegt TextFrame toe aan de Rectangle
    ashp.AddTextFrame(" ");

    // Benadert het tekstframe
    ITextFrame txtFrame = ashp.TextFrame;

    // Creëert het Paragraph-object voor het tekstframe
    IParagraph para = txtFrame.Paragraphs[0];

    // Creëert een Portion-object voor de alinea
    IPortion portion = para.Portions[0];

    // Stelt de tekst in
    portion.Text = "Aspose TextBox";

    // Slaat de presentatie op schijf op
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Controleer op een tekstvakvorm**

Aspose.Slides biedt de [IsTextBox](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/istextbox/) eigenschap van de [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) interface, waarmee je vormen kunt onderzoeken en tekstvakken kunt identificeren.

![Text box and shape](istextbox.png)

Deze C#‑code laat zien hoe je controleert of een vorm is gemaakt als tekstvak: 

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

Let op dat wanneer je simpelweg een autoshape toevoegt met de `AddAutoShape`‑methode van de [IShapeCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/ishapecollection/) interface, de `IsTextBox`‑eigenschap van de autoshape `false` teruggeeft. Nadat je echter tekst aan de autoshape toevoegt met de `AddTextFrame`‑methode of de `Text`‑eigenschap, geeft de `IsTextBox`‑eigenschap `true` terug.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox is false
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox is true

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox is false
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox is true

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox is false
    shape3.AddTextFrame("");
    // shape3.IsTextBox is false

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox is false
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox is false
}
```

## **Vind de vorm die een TextFrame bezit**

In generieke tekstverwerkingscode kun je een [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) ontvangen zonder te weten welk presentatie‑object deze bevat. Gebruik de [ITextFrame.ParentShape](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/parentshape/) eigenschap om terug te navigeren naar de eigenaar‑[IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/).

Voor een tekstframe dat behoort tot een [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) of een andere tekstbevattende vorm, is [ITextFrame.ParentShape](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/parentshape/) ingesteld en is [ITextFrame.ParentCell](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/parentcell/) `null`. Beide eigenschappen zijn alleen‑lezen navigatie‑eigenschappen, dus het lezen ervan wijzigt het eigenaarschap niet. Controleer altijd de geretourneerde waarde op `null` voordat je de vorm benadert.

Voor een volledig voorbeeld dat vorm‑ en tabelcel‑eigenaren identificeert, inclusief vormen die gekoppeld zijn aan SmartArt‑knooppunten, zie [Search and Replace Text](/slides/nl/net/search-and-replace-text/).

## **Voeg kolommen toe aan een tekstvak**

Aspose.Slides biedt de [ColumnCount](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/properties/columncount) en [ColumnSpacing](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat/properties/columnspacing) eigenschappen (van de [ITextFrameFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat) interface en de [TextFrameFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat) klasse) om kolommen toe te voegen aan tekstvakken. Je kunt het aantal kolommen in een tekstvak opgeven en vervolgens de tussenruimte in punten tussen de kolommen bepalen. 

Deze C#‑code demonstreert de beschreven bewerking: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	// Haalt de eerste dia op in de presentatie
	ISlide slide = presentation.Slides[0];

	// Voegt een AutoShape toe met type ingesteld op Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Voegt TextFrame toe aan de Rectangle
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Haalt het tekstformaat van TextFrame op
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Specificeert het aantal kolommen in TextFrame
	format.ColumnCount = 3;

	// Specificeert de afstand tussen de kolommen
	format.ColumnSpacing = 10;

	// Slaat de presentatie op
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Voeg kolommen toe aan een TextFrame**

Aspose.Slides voor .NET biedt de [ColumnCount](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat/properties/columncount) eigenschap (van de [ITextFrameFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframeformat) interface) waarmee je kolommen kunt toevoegen in tekstframes. Via deze eigenschap kun je het gewenste aantal kolommen in een tekstframe opgeven. 

Deze C#‑code laat zien hoe je een kolom toevoegt binnen een tekstframe:

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

## **Tekst bijwerken**

Aspose.Slides stelt je in staat de tekst in een tekstvak of alle teksten in een presentatie te wijzigen of bij te werken. 

Deze C#‑code toont een bewerking waarbij alle teksten in een presentatie worden bijgewerkt of aangepast:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Controleert of vorm een tekstframe ondersteunt (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Itereert door alinea's in het tekstframe
               {
                   foreach (IPortion portion in paragraph.Portions) //Itereert door elk gedeelte in de alinea
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Wijzigt de tekst
                       portion.PortionFormat.FontBold = NullableBool.True; //Wijzigt opmaak
                   }
               }
           }
       }
   }
  
   //Slaat de aangepaste presentatie op
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Voeg een tekstvak met een hyperlink toe**

Je kunt een link invoegen in een tekstvak. Wanneer op het tekstvak wordt geklikt, worden gebruikers doorgestuurd naar de link. 

1. Maak een instantie van de `Presentation` klasse. 
2. Haal de referentie van de eerste dia op via de index.  
3. Voeg een `AutoShape` object toe met `ShapeType` ingesteld op `Rectangle` op een opgegeven positie op de dia en verkrijg een referentie naar het nieuw toegevoegde AutoShape‑object. 
4. Voeg een `TextFrame` toe aan het `AutoShape` object dat *Aspose TextBox* bevat als standaardtekst. 
5. Instantieer de `IHyperlinkManager` klasse. 
6. Wijs het `IHyperlinkManager` object toe aan de [HyperlinkClick](https://reference.aspose.com/slides/nl/net/aspose.slides/shape/properties/hyperlinkclick) eigenschap die verbonden is met het gewenste gedeelte van het `TextFrame`. 
7. Schrijf tenslotte het PPTX‑bestand weg via het `Presentation` object. 

Deze C#‑code – een implementatie van de bovenstaande stappen – laat zien hoe je een tekstvak met een hyperlink aan een dia toevoegt:

```c#
using Aspose.Slides;

// Instantieert een Presentation-klasse die een PPTX vertegenwoordigt
Presentation pptxPresentation = new Presentation();

// Haalt de eerste dia op in de presentatie
ISlide slide = pptxPresentation.Slides[0];

// Voegt een AutoShape-object toe met type ingesteld op Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Converteert de vorm naar AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Benadert de ITextFrame eigenschap die bij de AutoShape hoort
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Voegt wat tekst toe aan het frame
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Stelt de hyperlink in voor de tekst van het gedeelte
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Slaat de PPTX-presentatie op
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Wat is het verschil tussen een tekstvak en een tekst‑placeholder bij het werken met masterslides?**

Een [placeholder](/slides/nl/net/manage-placeholder/) erft stijl/positie van de [master](https://reference.aspose.com/slides/nl/net/aspose.slides/masterslide/) en kan worden overschreven op [layouts](https://reference.aspose.com/slides/nl/net/aspose.slides/layoutslide/), terwijl een regulier tekstvak een onafhankelijk object is op een specifieke dia en niet verandert wanneer je van layout wisselt.

**Hoe kan ik een bulk‑tekstvervanging uitvoeren in de hele presentatie zonder tekst in diagrammen, tabellen en SmartArt aan te raken?**

Beperk je iteratie tot autoshapes die tekstframes hebben en sluit ingesloten objecten ([charts](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/nl/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/nl/net/aspose.slides.smartart/smartart/)) uit door hun collecties apart te doorlopen of die objecttypen over te slaan.