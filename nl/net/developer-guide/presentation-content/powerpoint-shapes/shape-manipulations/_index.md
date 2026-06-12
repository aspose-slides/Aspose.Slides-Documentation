---
title: Beheer presentatievormen in .NET
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/net/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatie-vorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- volgorde van vorm wijzigen
- Interop-vorm-ID ophalen
- alternatieve tekst van vorm
- layoutformaten van vorm
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: Leer hoe u vormen maakt, bewerkt en optimaliseert in Aspose.Slides voor .NET en lever hoogwaardige PowerPoint-presentaties.
---
## **Overzicht**

Dit artikel legt uit hoe u met vormen in presentaties kunt werken met Aspose.Slides. Het toont hoe u een vorm op een dia kunt vinden, dupliceren, verwijderen, verbergen, de volgorde kunt wijzigen, de Interop‑vorm‑ID kunt ophalen en alternatieve tekst kunt instellen voor herkenning en verdere verwerking.

Het behandelt ook hoe u layout‑formaten voor vormen kunt benaderen, een vorm als SVG kunt renderen, vormen op een dia kunt uitlijnen en flip‑eigenschappen kunt gebruiken voor horizontaal en verticaal spiegelen. Daarnaast bevat het een korte FAQ over het combineren van vormen, stapelvolgorde en het vergrendelen van vormen.

## **Zoek een vorm op een dia**
Dit onderwerp beschrijft een eenvoudige techniek om het voor ontwikkelaars makkelijker te maken een specifieke vorm op een dia te vinden zonder de interne Id te gebruiken. Het is belangrijk te weten dat PowerPoint‑presentatiebestanden geen andere manier bieden om vormen op een dia te identificeren dan een interne unieke Id. Het blijkt moeilijk voor ontwikkelaars om een vorm te vinden met die interne unieke Id. Alle vormen die aan dia’s worden toegevoegd hebben enige alternatieve tekst. We raden ontwikkelaars aan de alternatieve tekst te gebruiken om een specifieke vorm te vinden. U kunt MS PowerPoint gebruiken om de alternatieve tekst voor objecten te definiëren die u later wilt wijzigen.

Nadat u de alternatieve tekst van een gewenste vorm hebt ingesteld, kunt u die presentatie openen met Aspose.Slides for .NET en door alle vormen op een dia itereren. Tijdens elke iteratie kunt u de alternatieve tekst van de vorm controleren; de vorm met de overeenkomende alternatieve tekst is de vorm die u zoekt. Om deze techniek beter te demonstreren, hebben we de methode [FindShape](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/findshape/#findshape_1) gemaakt die de truc uitvoert om een specifieke vorm in een dia te vinden en vervolgens die vorm teruggeeft.

```c#
public static void Run()
{
    // Instantieer een Presentation-klasse die het presentatiebestand vertegenwoordigt
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Alternatieve tekst van de te vinden vorm
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Methode-implementatie om een vorm in een dia te vinden met behulp van de alternatieve tekst
public static IShape FindShape(ISlide slide, string alttext)
{
    // Itereren door alle vormen binnen de dia
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Als de alternatieve tekst van de dia overeenkomt met de vereiste, dan
        // Geef de vorm terug
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```



## **Dupliceer een vorm**
Om een vorm naar een dia te dupliceren met Aspose.Slides for .NET:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse.
1. Verkrijg de referentie van een dia via de index.
1. Benader de vormverzameling van de bron‑dia.
1. Voeg een nieuwe dia toe aan de presentatie.
1. Dupliceer vormen uit de bron‑dia‑verzameling naar de nieuwe dia.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Het voorbeeld hieronder voegt een groepvorm toe aan een dia.

```c#
// Instantieer Presentation-klasse
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Schrijf het PPTX-bestand naar schijf
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```



## **Verwijder een vorm**
Aspose.Slides for .NET maakt het voor ontwikkelaars mogelijk elke vorm te verwijderen. Volg de onderstaande stappen om een vorm van een dia te verwijderen:

1. Maak een instantie van de `Presentation`‑klasse.
1. Benader de eerste dia.
1. Zoek de vorm met de specifieke AlternativeText.
1. Verwijder de vorm.
1. Sla het bestand op schijf.

```c#
// Maak Presentation-object
Presentation pres = new Presentation();

// Verkrijg de eerste dia
ISlide sld = pres.Slides[0];

// Voeg een AutoShape van het type rechthoek toe
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

// Sla de presentatie op naar schijf
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```



## **Verberg een vorm**
Aspose.Slides for .NET maakt het voor ontwikkelaars mogelijk elke vorm te verbergen. Volg de onderstaande stappen om een vorm op een dia te verbergen:

1. Maak een instantie van de `Presentation`‑klasse.
1. Benader de eerste dia.
1. Zoek de vorm met de specifieke AlternativeText.
1. Verberg de vorm.
1. Sla het bestand op schijf.

```c#
// Instantieer Presentation-klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();

// Verkrijg de eerste dia
ISlide sld = pres.Slides[0];

// Voeg een autoshape van het type rechthoek toe
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

// Sla de presentatie op naar schijf
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```



## **Wijzig de volgorde van een vorm**
Aspose.Slides for .NET maakt het voor ontwikkelaars mogelijk de volgorde van vormen te wijzigen. Het wijzigen van de volgorde bepaalt welke vorm voorop of op de achtergrond staat. Volg de onderstaande stappen om de volgorde van vormen op een dia te wijzigen:

1. Maak een instantie van de `Presentation`‑klasse.
1. Benader de eerste dia.
1. Voeg een vorm toe.
1. Voeg tekst toe in het tekstframe van de vorm.
1. Voeg een tweede vorm toe op dezelfde coördinaten.
1. Wijzig de volgorde van de vormen.
1. Sla het bestand op schijf.

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


## **Haal de Interop‑vorm‑ID op**
Aspose.Slides for .NET maakt het voor ontwikkelaars mogelijk een unieke vorm‑identificatie op dia‑niveau op te halen, in tegenstelling tot de UniqueId‑eigenschap die een unieke identifier op presentatieniveau biedt. De eigenschap OfficeInteropShapeId is toegevoegd aan de IShape‑interfaces en de Shape‑klasse. De waarde die OfficeInteropShapeId teruggeeft correspondeert met de Id‑waarde van het Microsoft.Office.Interop.PowerPoint.Shape‑object. Hieronder staat een voorbeeldcode.

```c#
public static void Run()
{
    using (Presentation presentation = new Presentation("Presentation.pptx"))
    {
        // Unieke vorm‑ID ophalen in dia‑scope
        long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
    }
}
```



## **Stel alternatieve tekst in voor een vorm**
Aspose.Slides for .NET maakt het voor ontwikkelaars mogelijk de AlternateText van elke vorm in te stellen. 
Vormen in een presentatie kunnen worden onderscheiden aan de hand van de AlternativeText‑ of Shape‑Name‑eigenschap. 
De AlternativeText‑eigenschap kan zowel gelezen als ingesteld worden via Aspose.Slides en Microsoft PowerPoint. 
Door deze eigenschap te gebruiken, kunt u een vorm taggen en verschillende bewerkingen uitvoeren zoals het verwijderen, verbergen of herschikken van vormen op een dia.
Volg de onderstaande stappen om de AlternateText van een vorm in te stellen:

1. Maak een instantie van de `Presentation`‑klasse.
1. Benader de eerste dia.
1. Voeg een willekeurige vorm toe aan de dia.
1. Voer wat bewerkingen uit met de nieuw toegevoegde vorm.
1. Doorloop de vormen om de gewenste vorm te vinden.
1. Stel de AlternativeText in.
1. Sla het bestand op schijf.

```c#
// Instantieer Presentation-klasse die de PPTX vertegenwoordigt
Presentation pres = new Presentation();

// Verkrijg de eerste dia
ISlide sld = pres.Slides[0];

// Voeg een autoshape van het type rechthoek toe
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

// Sla de presentatie op naar schijf
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```




## **Benader layout‑formaten voor een vorm**
Aspose.Slides for .NET biedt een eenvoudige API om layout‑formaten voor een vorm te benaderen. Dit artikel toont hoe u layout‑formaten kunt benaderen.

Hieronder staat een voorbeeldcode.

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

## **Render een vorm als SVG**
Nu ondersteunt Aspose.Slides for .NET het renderen van een vorm als SVG. De WriteAsSvg‑methode (en zijn overload) is toegevoegd aan de Shape‑klasse en IShape‑interface. Deze methode maakt het mogelijk de inhoud van de vorm op te slaan als een SVG‑bestand. De code‑snippet hieronder laat zien hoe u de vorm van een dia exporteert naar een SVG‑bestand.

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

## **Lijn een vorm uit**

Via de [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/nl/net/aspose.slides.util/slideutil/methods/alignshapes/index)‑overload kunt u 

* vormen uitlijnen ten opzichte van de marges van een dia. Zie Voorbeeld 1. 
* vormen uitlijnen ten opzichte van elkaar. Zie Voorbeeld 2. 

De enumeratie [ShapesAlignmentType](https://reference.aspose.com/slides/nl/net/aspose.slides/shapesalignmenttype) definieert de beschikbare uitlijnopties.

**Voorbeeld 1**

Deze C#‑code toont hoe u vormen met index 1, 2 en 4 langs de bovenrand van een dia uitlijnt:
De broncode hieronder lijnt vormen met index 1, 2 en 4 uit langs de bovenrand van de dia. 

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

**Voorbeeld 2**

Deze C#‑code toont hoe u een volledige collectie vormen uitlijnt ten opzichte van de onderste vorm in de collectie:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **Flip‑eigenschappen**

In Aspose.Slides biedt de [ShapeFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/shapeframe/)‑klasse controle over horizontaal en verticaal spiegelen van vormen via de `FlipH`‑ en `FlipV`‑eigenschappen. Beide eigenschappen zijn van het type [NullableBool](https://reference.aspose.com/slides/nl/net/aspose.slides/nullablebool/), waarmee `True` een flip aangeeft, `False` geen flip, of `NotDefined` om het standaardgedrag te gebruiken. Deze waarden zijn toegankelijk via het [Frame](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/frame/) van een vorm. 

Om de flip‑instellingen te wijzigen, wordt een nieuw [ShapeFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/shapeframe/)‑object gecreëerd met de huidige positie en grootte van de vorm, de gewenste waarden voor `FlipH` en `FlipV`, en de rotatiehoek. Door dit object toe te wijzen aan het [Frame](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/frame/) van de vorm en de presentatie op te slaan, worden de spiegeltransformaties toegepast en in het uitvoerbestand vastgelegd.

Stel dat we een bestand sample.pptx hebben waarin de eerste dia één vorm bevat met de standaard flip‑instellingen, zoals hieronder weergegeven.

![The shape to be flipped](shape_to_be_flipped.png)

De volgende code‑voorbeeld haalt de huidige flip‑eigenschappen op en draait de vorm zowel horizontaal als verticaal.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Haal de horizontale flip-eigenschap van de vorm op.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Haal de verticale flip-eigenschap van de vorm op.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Flip horizontaal.
    NullableBool flipV = NullableBool.True; // Flip verticaal.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Het resultaat:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Kan ik vormen (union/intersect/subtract) combineren op een dia zoals in een desktop‑editor?**

Er is geen ingebouwde Boolean‑operatie‑API. U kunt het benaderen door zelf de gewenste omtrek te construeren — bijvoorbeeld door de resulterende geometrie te berekenen (via [GeometryPath](https://reference.aspose.com/slides/nl/net/aspose.slides/geometrypath/)) en een nieuwe vorm met die contour te maken, eventueel de oorspronkelijke vormen te verwijderen.

**Hoe kan ik de stapelvolgorde (z‑order) regelen zodat een vorm altijd “bovenop” blijft?**

Wijzig de invoeg‑/verplaatsvolgorde binnen de [shapes](https://reference.aspose.com/slides/nl/net/aspose.slides/baseslide/shapes/)‑collectie van de dia. Voor voorspelbare resultaten, finaliseer de z‑order nadat alle andere dia‑aanpassingen zijn uitgevoerd.

**Kan ik een vorm “vergrendelen” zodat gebruikers deze niet kunnen bewerken in PowerPoint?**

Ja. Stel [shape‑level protection flags](/slides/nl/net/applying-protection-to-presentation/) in (bijv. vergrendel selectie, verplaatsing, grootte‑aanpassing, tekstbewerkingen). Indien nodig, spiegel de beperkingen op de master‑ of layout‑dia. Let op: dit is bescherming op UI‑niveau, geen beveiligingsfunctie; voor sterkere bescherming combineert u dit met bestands‑niveau restricties zoals [aanbevelingen voor alleen‑lezen of wachtwoorden](/slides/nl/net/password-protected-presentation/).