---
title: Beheer SmartArt‑vormknooppunten in presentaties in .NET
linktitle: SmartArt‑vormknooppunt
type: docs
weight: 30
url: /nl/net/manage-smartart-shape-node/
keywords:
- SmartArt‑knooppunt
- kindknooppunt
- knooppunt toevoegen
- knooppuntpositie
- knooppunt benaderen
- knooppunt verwijderen
- aangepaste positie
- assistent‑knooppunt
- vullingsopmaak
- knooppunt renderen
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Beheer SmartArt‑vormknooppunten in PPT en PPTX met Aspose.Slides voor .NET. Krijg duidelijke code‑voorbeelden en tips om uw presentaties te stroomlijnen."
---
## **Overzicht**

SmartArt‑afbeeldingen in PowerPoint‑presentaties zijn georganiseerd via knooppunten die tekst bevatten en de structuur van het diagram bepalen. Aspose.Slides stelt u in staat om met deze SmartArt‑knooppunten programmatisch te werken: nieuwe knooppunten en kindknooppunten toevoegen, kindknooppunten op een specifieke positie invoegen, bestaande knooppunten benaderen en hun tekst, niveau en positie lezen.

Dit artikel legt uit hoe u SmartArt‑vormknooppunten beheert. Het laat zien hoe u knooppunten verwijdert, werkt met kindknooppunten op index of positie, een assistent‑knooppunt omzet naar een normaal knooppunt, de positie, grootte en rotatie van SmartArt‑knooppuntvormen aanpast, knooppunt‑vullingsopmaak instelt en een miniatuurafbeelding genereert voor een SmartArt‑kindknooppunt.

## **Een SmartArt‑knooppunt toevoegen**
Aspose.Slides voor .NET biedt de eenvoudigste API om SmartArt‑vormen op de gemakkelijkste manier te beheren. De volgende voorbeeldcode helpt u een knooppunt en een kindknooppunt toe te voegen binnen een SmartArt‑vorm.

- Maak een instantie van de [Presentatie](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse en laad de presentatie met een SmartArt‑vorm.  
- Verkrijg de referentie van de eerste dia via de index.  
- Doorloop elke vorm op de eerste dia.  
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArt als dat zo is.  
- Voeg een nieuw knooppunt toe aan de NodeCollection van de SmartArt‑vorm en stel de tekst in het TextFrame in.  
- Voeg nu een kindknooppunt toe aan het net toegevoegde SmartArt‑knooppunt en stel de tekst in het TextFrame in.  
- Sla de presentatie op.

```c#
// Laad de gewenste presentatie
Presentation pres = new Presentation("AddNodes.pptx");

// Doorloop elke vorm op de eerste dia
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Controleer of de vorm van het type SmartArt is
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Cast de vorm naar SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Een nieuw SmartArt‑knooppunt toevoegen
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Tekst toevoegen
        TemNode.TextFrame.Text = "Test";

        // Een nieuw kindknooppunt toevoegen aan het bovenliggende knooppunt. Het wordt aan het einde van de collectie toegevoegd
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Tekst toevoegen
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Presentatie opslaan
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Een SmartArt‑knooppunt op een specifieke positie toevoegen**
In de volgende voorbeeldcode leggen we uit hoe u de kindknooppunten die bij respectieve knooppunten van een SmartArt‑vorm horen, op een bepaalde positie kunt toevoegen.

- Maak een instantie van de `Presentation`‑klasse.  
- Verkrijg de referentie van de eerste dia via de index.  
- Voeg een SmartArt‑vorm van het type StackedList toe aan de verkregen dia.  
- Benader het eerste knooppunt in de toegevoegde SmartArt‑vorm.  
- Voeg nu het kindknooppunt voor het geselecteerde knooppunt toe op positie 2 en stel de tekst in.  
- Sla de presentatie op.

```c#
// Creating a presentation instance
Presentation pres = new Presentation();

// Access the presentation slide
ISlide slide = pres.Slides[0];

// Add Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Accessing the SmartArt node at index 0
ISmartArtNode node = smart.AllNodes[0];

// Adding new child node at position 2 in parent node
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Add Text
chNode.TextFrame.Text = "Sample Text Added";

// Save Presentation
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Een SmartArt‑knooppunt benaderen**
De volgende voorbeeldcode helpt u knooppunten binnen een SmartArt‑vorm te benaderen. Let op dat u het LayoutType van de SmartArt niet kunt wijzigen; deze is alleen‑lezen en wordt ingesteld wanneer de SmartArt‑vorm wordt toegevoegd.

- Maak een instantie van de `Presentation`‑klasse en laad de presentatie met een SmartArt‑vorm.  
- Verkrijg de referentie van de eerste dia via de index.  
- Doorloop elke vorm op de eerste dia.  
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArt als dat zo is.  
- Doorloop alle knooppunten binnen de SmartArt‑vorm.  
- Benader en toon informatie zoals de positie, het niveau en de tekst van het SmartArt‑knooppunt.

  ```c#
  // Laad de gewenste presentatie
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Doorloop elke vorm op de eerste dia
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Controleer of de vorm van het type SmartArt is
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Cast de vorm naar SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Doorloop alle knooppunten binnen SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Benaderen van SmartArt‑knooppunt op index i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // De parameters van het SmartArt‑knooppunt afdrukken
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```

## **Een SmartArt‑kindknooppunt benaderen**
De volgende voorbeeldcode helpt u de kindknooppunten die bij respectieve knooppunten van een SmartArt‑vorm horen, te benaderen.

- Maak een instantie van de `PresentationEx`‑klasse en laad de presentatie met een SmartArt‑vorm.  
- Verkrijg de referentie van de eerste dia via de index.  
- Doorloop elke vorm op de eerste dia.  
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar `SmartArtEx` als dat zo is.  
- Doorloop alle knooppunten binnen de SmartArt‑vorm.  
- Voor elk geselecteerd SmartArt‑knooppunt, doorloop alle kindknooppunten binnen dat specifieke knooppunt.  
- Benader en toon informatie zoals de positie, het niveau en de tekst van het kindknooppunt.

```c#
// Laad de gewenste presentatie
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Doorloop elke vorm op de eerste dia
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Controleer of de vorm van het type SmartArt is
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Cast de vorm naar SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Doorloop alle knooppunten binnen SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Benaderen van SmartArt‑knooppunt op index i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Doorloop de kindknooppunten in SmartArt‑knooppunt op index i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Benaderen van het kindknooppunt in SmartArt‑knooppunt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // De parameters van het SmartArt‑kindknooppunt afdrukken
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```

## **Een SmartArt‑kindknooppunt op een specifieke positie benaderen**
In dit voorbeeld leren we de kindknooppunten op een bepaalde positie die bij respectieve knooppunten van een SmartArt‑vorm horen, te benaderen.

- Maak een instantie van de `Presentation`‑klasse.  
- Verkrijg de referentie van de eerste dia via de index.  
- Voeg een SmartArt‑vorm van het type StackedList toe.  
- Benader de toegevoegde SmartArt‑vorm.  
- Benader het knooppunt met index 0 voor de verkregen SmartArt‑vorm.  
- Benader nu het kindknooppunt op positie 1 voor het verkregen SmartArt‑knooppunt met de methode `GetNodeByPosition()`.  
- Benader en toon informatie zoals de positie, het niveau en de tekst van het kindknooppunt.

```c#
// Instantieer de presentatie
Presentation pres = new Presentation();

// De eerste dia benaderen
ISlide slide = pres.Slides[0];

// SmartArt‑vorm toevoegen op de eerste dia
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// SmartArt‑knooppunt op index 0 benaderen
ISmartArtNode node = smart.AllNodes[0];

// Kindknooppunt op positie 1 in het bovenliggende knooppunt benaderen
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// De parameters van het SmartArt‑kindknooppunt afdrukken
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```

## **Een SmartArt‑knooppunt verwijderen**
In dit voorbeeld leren we knooppunten binnen een SmartArt‑vorm te verwijderen.

- Maak een instantie van de `Presentation`‑klasse en laad de presentatie met een SmartArt‑vorm.  
- Verkrijg de referentie van de eerste dia via de index.  
- Doorloop elke vorm op de eerste dia.  
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArt als dat zo is.  
- Controleer of de SmartArt meer dan 0 knooppunten bevat.  
- Selecteer het SmartArt‑knooppunt dat verwijderd moet worden.  
- Verwijder nu het geselecteerde knooppunt met de methode `RemoveNode()` en sla de presentatie op.

```c#
// Laad de gewenste presentatie
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Doorloop elke vorm op de eerste dia
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Controleer of de vorm van het type SmartArt is
        if (shape is ISmartArt)
        {
            // Cast de vorm naar SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Benaderen van SmartArt‑knooppunt op index 0
                ISmartArtNode node = smart.AllNodes[0];

                // Het geselecteerde knooppunt verwijderen
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Presentatie opslaan
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Een SmartArt‑knooppunt op een specifieke positie verwijderen**
In dit voorbeeld leren we knooppunten binnen een SmartArt‑vorm op een bepaalde positie te verwijderen.

- Maak een instantie van de `Presentation`‑klasse en laad de presentatie met een SmartArt‑vorm.  
- Verkrijg de referentie van de eerste dia via de index.  
- Doorloop elke vorm op de eerste dia.  
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArt als dat zo is.  
- Selecteer het SmartArt‑knooppunt met index 0.  
- Controleer nu of het geselecteerde SmartArt‑knooppunt meer dan 2 kindknooppunten bevat.  
- Verwijder nu het knooppunt op positie 1 met de methode `RemoveNodeByPosition()`.  
- Sla de presentatie op.

```c#
// Laad de gewenste presentatie
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Doorloop elke vorm op de eerste dia
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Controleer of de vorm van het type SmartArt is
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Cast de vorm naar SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Benaderen van SmartArt‑knooppunt op index 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Verwijderen van het kindknooppunt op positie 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Presentatie opslaan
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Een aangepaste positie instellen voor een kindknooppunt in een SmartArt‑object**
Aspose.Slides voor .NET ondersteunt nu het instellen van de X‑ en Y‑eigenschappen van SmartArtShape. De code‑fragment hieronder toont hoe u een aangepaste positie, grootte en rotatie van SmartArtShape instelt; let bovendien op dat het toevoegen van nieuwe knooppunten een herberekening van de posities en groottes van alle knooppunten veroorzaakt.

```c#
// Laad de gewenste presentatie
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Verplaats de SmartArt-vorm naar een nieuwe positie
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Wijzig de breedtes van de SmartArt-vorm
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Wijzig de hoogte van de SmartArt-vorm
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Wijzig de rotatie van de SmartArt-vorm
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```

## **Een assistent‑knooppunt controleren**
In de volgende voorbeeldcode onderzoeken we hoe we assistent‑knooppunten in de SmartArt‑knooppuntenverzameling kunnen identificeren en wijzigen.

- Maak een instantie van de `PresentationEx`‑klasse en laad de presentatie met een SmartArt‑vorm.  
- Verkrijg de referentie van de tweede dia via de index.  
- Doorloop elke vorm op de eerste dia.  
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar `SmartArtEx` als dat zo is.  
- Doorloop alle knooppunten binnen de SmartArt‑vorm en controleer of ze assistent‑knooppunten zijn.  
- Wijzig de status van het assistent‑knooppunt naar een normaal knooppunt.  
- Sla de presentatie op.

```c#
// Een presentatie‑instantie maken
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Doorloop elke vorm op de eerste dia
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Controleer of de vorm van het type SmartArt is
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Cast de vorm naar SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Doorloop alle knooppunten van de SmartArt‑vorm

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Controleer of het knooppunt een assistent‑knooppunt is
                if (node.IsAssistant)
                {
                    // Zet het assistent‑knooppunt op false en maak het een normaal knooppunt
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Presentatie opslaan
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Vullingsopmaak van een knooppunt instellen**
Aspose.Slides voor .NET maakt het mogelijk om aangepaste SmartArt‑vormen toe te voegen en hun vullingsopmaak in te stellen. Dit artikel legt uit hoe u SmartArt‑vormen maakt, benadert en de vullingsopmaak hiervan instelt met Aspose.Slides voor .NET.

Volg de onderstaande stappen:

- Maak een instantie van de `Presentation`‑klasse.  
- Verkrijg de referentie van een dia via de index.  
- Voeg een SmartArt‑vorm toe door het LayoutType in te stellen.  
- Stel de FillFormat in voor de knooppunten van de SmartArt‑vorm.  
- Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```c#
using (Presentation presentation = new Presentation())
{
    // De dia benaderen
    ISlide slide = presentation.Slides[0];

    // SmartArt‑vorm en knooppunten toevoegen
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Vullingskleur van het knooppunt instellen
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Presentatie opslaan
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```

## **Een miniatuur van een SmartArt‑kindknooppunt genereren**
Ontwikkelaars kunnen een miniatuur van een kindknooppunt van een SmartArt genereren door de onderstaande stappen te volgen:

1. Instantieer de `Presentation`‑klasse die het PPTX‑bestand voorstelt.  
2. Voeg een SmartArt‑vorm toe.  
3. Verkrijg de referentie van een knooppunt via de index.  
4. Haal de miniatuurafbeelding op.  
5. Sla de miniatuurafbeelding op in elk gewenst afbeeldingformaat.

Het voorbeeld hieronder genereert een miniatuur van een SmartArt‑kindknooppunt:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```

## **FAQ**

**Wordt animatie voor SmartArt ondersteund?**

Ja. SmartArt wordt behandeld als een gewone vorm, zodat u [standaardanimaties](/slides/nl/net/shape-animation/) (invoer, uitgang, nadruk, bewegingspaden) kunt toepassen en de timing kunt aanpassen. U kunt ook vormen binnen SmartArt‑knooppunten animeren wanneer nodig.

**Hoe kan ik een specifieke SmartArt op een dia betrouwbaar vinden als de interne ID onbekend is?**

Ken en zoek op [alternatieve tekst]https://reference.aspose.com/slides/nl/net/aspose.slides/shape/alternativetext/. Door een onderscheidende AltText aan de SmartArt toe te wijzen, kunt u deze programmatisch vinden zonder te vertrouwen op interne identificatoren.

**Blijft de weergave van SmartArt behouden bij het exporteren van de presentatie naar PDF?**

Ja. Aspose.Slides render SmartArt met hoge visuele nauwkeurigheid tijdens [PDF‑export](/slides/nl/net/convert-powerpoint-to-pdf/), waarbij lay-out, kleuren en effecten behouden blijven.

**Kan ik een afbeelding van de volledige SmartArt extraheren (voor voorbeeldweergaven of rapporten)?**

Ja. U kunt een SmartArt‑vorm renderen naar [rasterformaten]https://reference.aspose.com/slides/nl/net/aspose.slides/shape/getimage/ of naar [SVG]https://reference.aspose.com/slides/nl/net/aspose.slides/shape/writeassvg/ voor schaalbare vectoruitvoer, wat geschikt is voor miniaturen, rapporten of gebruik op het web.