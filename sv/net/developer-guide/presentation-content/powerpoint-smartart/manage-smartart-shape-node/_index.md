---
title: Hantera SmartArt-formnoder i presentationer i .NET
linktitle: SmartArt-formnod
type: docs
weight: 30
url: /sv/net/manage-smartart-shape-node/
keywords:
- SmartArt-nod
- barnnod
- lägg till nod
- nodposition
- åtkomstnod
- ta bort nod
- anpassad position
- assistentnod
- fyllningsformat
- rendera nod
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Hantera SmartArt-formnoder i PPT och PPTX med Aspose.Slides för .NET. Få tydliga kodexempel och tips för att effektivisera dina presentationer."
---
## **Översikt**

SmartArt-grafik i PowerPoint-presentationer organiseras via noder som innehåller text och definierar diagrammets struktur. Aspose.Slides låter dig arbeta med dessa SmartArt‑noder programmässigt: lägga till nya noder och barnnoder, infoga barnnoder på en specifik position, komma åt befintliga noder och läsa deras text, nivå och position.

Den här artikeln förklarar hur du hanterar SmartArt‑formnoder. Den visar hur du tar bort noder, arbetar med barnnoder efter index eller position, ändrar en assistentnod till en normal nod, justerar position, storlek och rotation för SmartArt‑nodformer, ställer in nodens fyllningsformat och genererar en miniatyrbild för en SmartArt‑barnnod.

## **Lägg till en SmartArt‑nod**
Aspose.Slides för .NET har tillhandahållit det enklaste API:et för att hantera SmartArt‑former på det lättaste sättet. Följande exempelkod hjälper dig att lägga till en nod och en barnnod i en SmartArt‑form.

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)-klassen och läs in presentationen med en SmartArt‑form.
- Hämta referensen till den första bilden genom att använda dess index.
- Gå igenom varje form på den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
- Lägg till en ny Nod i SmartArt‑formens NodeCollection och sätt texten i TextFrame.
- Lägg nu till en Barnnod i den nyss tillagda SmartArt‑noden och sätt texten i TextFrame.
- Spara presentationen.

```c#
 // Ladda den önskade presentationen
 Presentation pres = new Presentation("AddNodes.pptx");

 // Gå igenom varje form i den första bilden
 foreach (IShape shape in pres.Slides[0].Shapes)
 {

     // Kontrollera om formen är av typen SmartArt
     if (shape is Aspose.Slides.SmartArt.SmartArt)
     {

         // Typkonvertera formen till SmartArt
         Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

         // Lägg till en ny SmartArt-nod
         Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

         // Lägg till text
         TemNode.TextFrame.Text = "Test";

         // Lägg till en ny barnnod i föräldranoden. Den kommer att läggas till i slutet av samlingen
         Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

         // Lägg till text
         newNode.TextFrame.Text = "New Node Added";

     }
 }

 // Spara presentationen
 pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **Lägg till en SmartArt‑nod på en specifik position**
I följande exempelkod har vi förklarat hur du lägger till barnnoder som tillhör respektive noder i en SmartArt‑form på en specifik position.

- Skapa en instans av `Presentation`-klassen.
- Hämta referensen till den första bilden genom att använda dess index.
- Lägg till en SmartArt‑form av typen StackedList på den åtkomstade bilden.
- Kom åt den första noden i den tillagda SmartArt‑formen.
- Lägg nu till en barnnod för den valda noden på position 2 och sätt dess text.
- Spara presentationen.

```c#
// Skapa ett presentationsobjekt
Presentation pres = new Presentation();

// Åtkomst till presentationsbilden
ISlide slide = pres.Slides[0];

// Lägg till Smart Art IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Åtkomst till SmartArt-noden vid index 0
ISmartArtNode node = smart.AllNodes[0];

// Lägg till ny barnnod på position 2 i föräldranoden
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Lägg till text
chNode.TextFrame.Text = "Sample Text Added";

// Spara presentationen
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **Kom åt en SmartArt‑nod**
Följande exempelkod hjälper dig att komma åt noder i en SmartArt‑form. Observera att du inte kan ändra LayoutType för SmartArt eftersom den är skrivskyddad och endast sätts när SmartArt‑formen läggs till.

- Skapa en instans av `Presentation`-klassen och läs in presentationen med en SmartArt‑form.
- Hämta referensen till den första bilden genom att använda dess index.
- Gå igenom varje form på den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
- Gå igenom alla noder i SmartArt‑formen.
- Kom åt och visa information som SmartArt‑nodens position, nivå och text.

```c#
  // Ladda den önskade presentationen
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Gå igenom varje form i den första bilden
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Kontrollera om formen är av typen SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Typkonvertera formen till SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Gå igenom alla noder i SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Åtkomst till SmartArt-nod vid index i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Skriver ut SmartArt-nodens parametrar
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
```



## **Kom åt en SmartArt‑barnnod**
Följande exempelkod hjälper dig att komma åt barnnoder som tillhör respektive noder i en SmartArt‑form.

- Skapa en instans av PresentationEx‑klassen och läs in presentationen med en SmartArt‑form.
- Hämta referensen till den första bilden genom att använda dess index.
- Gå igenom varje form på den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArtEx om den är SmartArt.
- Gå igenom alla noder i SmartArt‑formen.
- För varje vald SmartArt‑formnod, gå igenom alla barnnoder i den specifika noden.
- Kom åt och visa information som barnnodens position, nivå och text.

```c#
// Ladda den önskade presentationen
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Gå igenom varje form i den första bilden
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Kontrollera om formen är av typen SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Typkonvertera formen till SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Gå igenom alla noder i SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Åtkomst till SmartArt-nod vid index i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Gå igenom barnnoderna i SmartArt-noden vid index i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Åtkomst till barnnoden i SmartArt-noden
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Skriver ut parametrarna för SmartArt-barnnoden
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```



## **Kom åt en SmartArt‑barnnod på en specifik position**
I detta exempel kommer vi att lära oss att komma åt barnnoder på en viss position som tillhör respektive noder i en SmartArt‑form.

- Skapa en instans av `Presentation`-klassen.
- Hämta referensen till den första bilden genom att använda dess index.
- Lägg till en SmartArt‑form av typen StackedList.
- Kom åt den tillagda SmartArt‑formen.
- Kom åt noden med index 0 för den åtkomstade SmartArt‑formen.
- Kom nu åt barnnoden på position 1 för den åtkomstade SmartArt‑noden med metoden GetNodeByPosition().
- Kom åt och visa information som barnnodens position, nivå och text.

```c#
// Instansiera presentationen
Presentation pres = new Presentation();

// Åtkomst till den första bilden
ISlide slide = pres.Slides[0];

// Lägger till SmartArt-formen på första bilden
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Åtkomst till SmartArt-noden vid index 0
ISmartArtNode node = smart.AllNodes[0];

// Åtkomst till barnnoden på position 1 i föräldranoden
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// Skriver ut parametrarna för SmartArt-barnnoden
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```



## **Ta bort en SmartArt‑nod**
I detta exempel kommer vi att lära oss att ta bort noder i en SmartArt‑form.

- Skapa en instans av `Presentation`-klassen och läs in presentationen med en SmartArt‑form.
- Hämta referensen till den första bilden genom att använda dess index.
- Gå igenom varje form på den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
- Kontrollera om SmartArt har fler än 0 noder.
- Välj den SmartArt‑nod som ska tas bort.
- Nu tar du bort den valda noden med metoden RemoveNode() och sparar presentationen.

```c#
// Ladda den önskade presentationen
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Gå igenom varje form i den första bilden
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Kontrollera om formen är av typen SmartArt
        if (shape is ISmartArt)
        {
            // Typkonvertera formen till SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Åtkomst till SmartArt-nod vid index 0
                ISmartArtNode node = smart.AllNodes[0];

                // Tar bort den valda noden
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Spara presentationen
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Ta bort en SmartArt‑nod på en specifik position**
I detta exempel kommer vi att lära oss att ta bort noder i en SmartArt‑form på en viss position.

- Skapa en instans av `Presentation`-klassen och läs in presentationen med en SmartArt‑form.
- Hämta referensen till den första bilden genom att använda dess index.
- Gå igenom varje form på den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
- Välj SmartArt‑formens nod med index 0.
- Kontrollera nu om den valda SmartArt‑noden har fler än 2 barnnoder.
- Ta nu bort noden på position 1 med metoden RemoveNodeByPosition().
- Spara presentationen.

```c#
// Ladda den önskade presentationen
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Gå igenom varje form i den första bilden
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Kontrollera om formen är av typen SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Typkonvertera formen till SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Åtkomst till SmartArt-nod vid index 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Tar bort barnnoden på position 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Spara presentationen
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **Ställ in en egen position för en barnnod i ett SmartArt‑objekt**
Nu har Aspose.Slides för .NET stöd för att ange X‑ och Y‑egenskaper för SmartArt‑form. Kodsnutten nedan visar hur du ställer in en anpassad position, storlek och rotation för SmartArt‑formen; observera också att tillägg av nya noder orsakar en omberäkning av alla noders positioner och storlekar.

```c#
// Ladda den önskade presentationen
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Flytta SmartArt-formen till ny position
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Ändra SmartArt-formens bredd
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Ändra SmartArt-formens höjd
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Ändra SmartArt-formens rotation
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```



## **Kontrollera en assistentnod**
I följande exempelkod kommer vi att undersöka hur man identifierar assistentnoder i SmartArt‑nodsamlingen och ändrar dem.

- Skapa en instans av PresentationEx‑klassen och läs in presentationen med en SmartArt‑form.
- Hämta referensen till den andra bilden genom att använda dess index.
- Gå igenom varje form på den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArtEx om den är SmartArt.
- Gå igenom alla noder i SmartArt‑formen och kontrollera om de är assistentnoder.
- Ändra status för assistentnod till en normal nod.
- Spara presentationen.

```c#
// Skapa ett presentationsobjekt
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Gå igenom varje form i den första bilden
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Kontrollera om formen är av typen SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Typkonvertera formen till SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Gå igenom alla noder i SmartArt-formen

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Kontrollera om noden är en assistentnod
                if (node.IsAssistant)
                {
                    // Sätter assistentnod till false och gör den till en normal nod
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Spara presentationen
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Ställ in en nods fyllningsformat**
Aspose.Slides för .NET gör det möjligt att lägga till anpassade SmartArt‑former och ange deras fyllningsformat. Denna artikel förklarar hur du skapar och får åtkomst till SmartArt‑former samt ställer in deras fyllningsformat med Aspose.Slides för .NET.

Följ stegen nedan:

- Skapa en instans av `Presentation`‑klassen.
- Hämta referensen till en bild med dess index.
- Lägg till en SmartArt‑form genom att ange dess LayoutType.
- Ställ in FillFormat för SmartArt‑formens noder.
- Skriv den modifierade presentationen som en PPTX‑fil.

```c#
using (Presentation presentation = new Presentation())
{
    // Åtkomst till bilden
    ISlide slide = presentation.Slides[0];

    // Lägger till SmartArt-form och noder
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Anger nodens fyllningsfärg
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Sparar presentationen
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```



## **Generera en miniatyrbild av en SmartArt‑barnnod**
Utvecklare kan generera en miniatyrbild av en SmartArt‑barnnod genom att följa stegen nedan:

1. Instansiera `Presentation`‑klassen som representerar PPTX‑filen.
2. Lägg till SmartArt.
3. Hämta referensen till en nod genom att använda dess index
4. Hämta miniatyrbilden.
5. Spara miniatyrbilden i önskat bildformat.

Exemplet nedan genererar en miniatyrbild av en SmartArt‑barnnod

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

**Stöds SmartArt‑animation?**

Ja. SmartArt behandlas som en vanlig form, så du kan [tillämpa standardanimationer](/slides/sv/net/shape-animation/) (ingång, avslutning, betoning, rörelsebanor) och justera tidpunkter. Du kan även animera former inuti SmartArt‑noder vid behov.

**Hur kan jag på ett tillförlitligt sätt hitta en specifik SmartArt på en bild om dess interna ID är okänt?**

Tilldela och sök via [alternativ text](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/alternativetext/). Genom att sätta en unik AltText på SmartArt kan du hitta den programmässigt utan att förlita dig på interna identifierare.

**Kommer SmartArt‑utseendet att bevaras när presentationen konverteras till PDF?**

Ja. Aspose.Slides renderar SmartArt med hög visuell trohet vid [PDF‑export](/slides/sv/net/convert-powerpoint-to-pdf/), vilket bevarar layout, färger och effekter.

**Kan jag extrahera en bild av hela SmartArt (för förhandsvisningar eller rapporter)?**

Ja. Du kan rendera en SmartArt‑form till [rasterformat](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/getimage/) eller till [SVG](https://reference.aspose.com/slides/sv/net/aspose.slides/shape/writeassvg/) för skalbar vektorutmatning, vilket gör den lämplig för miniatyrbilder, rapporter eller webbbruk.