---
title: Hantera SmartArt-formnoder i presentationer med Python
linktitle: SmartArt-formnod
type: docs
weight: 30
url: /sv/python-net/manage-smartart-shape-node/
keywords:
- SmartArt-nod
- undernod
- lägga till nod
- nodposition
- komma åt nod
- ta bort nod
- anpassad position
- assistentnod
- fyllningsformat
- rendera nod
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Hantera SmartArt-formnoder i PPT, PPTX och ODP med Aspose.Slides för Python via .NET. Få tydliga kodexempel och tips för att effektivisera dina presentationer."
---
## **Översikt**

SmartArt-grafik i PowerPoint-presentationer organiseras genom noder som innehåller text och definierar diagrammets struktur. Aspose.Slides låter dig arbeta med dessa SmartArt-noder programmässigt: lägga till nya noder och undernoder, infoga undernoder på en specifik position, komma åt befintliga noder och läsa deras text, nivå och position.

Denna artikel förklarar hur du hanterar SmartArt-formnodar. Den visar hur du tar bort noder, arbetar med undernoder efter index eller position, ändrar en assistentnod till en normal nod, justerar position, storlek och rotation för SmartArt-nodformer, anger nodens fyllningsformat och genererar en miniatyrbild för en SmartArt-undernod.

## **Lägg till SmartArt-nod**
Aspose.Slides för Python via .NET har tillhandahållit det enklaste API:et för att hantera SmartArt-former på det lättaste sättet. Följande exempelprogramkod hjälper dig att lägga till nod och undernod i en SmartArt-form.

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)-klassen och ladda presentationen med SmartArt-Form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form på den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
- Lägg till en ny Node i SmartArt-formens NodeCollection och ange texten i TextFrame.
- Lägg nu till en Child-Node i den nyinlagda SmartArt-Node och ange texten i TextFrame.
- Spara presentationen.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Ladda den önskade presentationen
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Iterera igenom alla former i den första bilden
    for shape in pres.slides[0].shapes:

        # Kontrollera om formen är av typen SmartArt
        if type(shape) is art.SmartArt:
            # Lägger till en ny SmartArt-nod
            node1 = shape.all_nodes.add_node()
            # Lägger till text
            node1.text_frame.text = "Test"

            # Lägger till en ny undernod i föräldranoden. Den kommer att läggas till i slutet av samlingen
            new_node = node1.child_nodes.add_node()

            # Lägger till text
            new_node.text_frame.text = "New Node Added"

    # Sparar presentationen
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Lägg till SmartArt-nod på specifik position**
I följande exempelprogramkod har vi förklarat hur man lägger till undernoder som tillhör respektive noder i SmartArt-formen på en viss position.

- Skapa en instans av `Presentation`-klassen.
- Hämta referensen till den första bilden genom att använda dess Index.
- Lägg till en SmartArt-form av typen StackedList på den åtkomna bilden.
- Kom åt den första noden i den tillagda SmartArt-formen.
- Lägg nu till en Child-Node för den valda noden på position 2 och ange dess text.
- Spara presentationen.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Skapar en presentationsinstans
with slides.Presentation() as pres:
    # Kom åt presentationsbilden
    slide = pres.slides[0]

    # Lägg till Smart Art IShape
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Åtkomst till SmartArt-noden på index 0
    node = smart.all_nodes[0]

    # Lägger till en ny undernod på position 2 i föräldranoden
    chNode = node.child_nodes.add_node_by_position(2)

    # Lägg till text
    chNode.text_frame.text = "Sample text Added"

    # spara presentationen
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kom åt SmartArt-nod**
Följande exempelprogramkod hjälper dig att komma åt noder i en SmartArt-form. Observera att du inte kan ändra LayoutType för SmartArt eftersom den är skrivskyddad och endast sätts när SmartArt-formen läggs till.

- Skapa en instans av `Presentation`-klassen och ladda presentationen med SmartArt-Form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form på den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
- Gå igenom alla Nodes i SmartArt-formen.
- Kom åt och visa information som SmartArt-nodens position, nivå och text.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Ladda den önskade presentationen
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Iterera igenom alla former på den första bilden
    for shape in pres.slides[0].shapes:
        # Kontrollera om formen är av typen SmartArt
        if type(shape) is art.SmartArt:
            # Iterera igenom alla noder i SmartArt
            for i in range(len(shape.all_nodes)):
                # Åtkomst till SmartArt-nod på index i
                node = shape.all_nodes[i]

                # Skriver ut SmartArt-nodens parametrar
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```

## **Kom åt SmartArt-undernod**
Följande exempelprogramkod hjälper dig att komma åt undernoder som tillhör respektive noder i SmartArt-formen.

- Skapa en instans av PresentationEx-klassen och ladda presentationen med SmartArt-Form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form på den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArtEx om den är SmartArt.
- Gå igenom alla Nodes i SmartArt-formen.
- För varje vald SmartArt-formnod, gå igenom alla Child-Nodes i den specifika noden.
- Kom åt och visa information som Child-nodens position, nivå och text.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Ladda den önskade presentationen
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Iterera igenom alla former på den första bilden
    for shape in pres.slides[0].shapes:
        # Kontrollera om formen är av typen SmartArt
        if type(shape) is art.SmartArt:
            # Iterera igenom alla noder i SmartArt
            for node0 in shape.all_nodes:
                # Iterera igenom undernoderna
                for j in range(len(node0.child_nodes)):
                    # Åtkomst till undernoden i SmartArt-noden
                    node = node0.child_nodes[j]

                    # Skriver ut parametrarna för SmartArt-undernoden
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```

## **Kom åt SmartArt-undernod på specifik position**
I det här exemplet kommer vi att lära oss att komma åt undernoder på en viss position som tillhör respektive noder i SmartArt-formen.

- Skapa en instans av `Presentation`-klassen.
- Hämta referensen till den första bilden genom att använda dess Index.
- Lägg till en SmartArt-form av typen StackedList.
- Kom åt den tillagda SmartArt-formen.
- Kom åt noden på index 0 för den åtkomna SmartArt-formen.
- Kom nu åt Child-Node på position 1 för den åtkomna SmartArt-noden med metoden GetNodeByPosition().
- Kom åt och visa information som Child-nodens position, nivå och text.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Instansiera presentationen
with slides.Presentation() as pres:
    # Åtkomst till den första bilden
    slide = pres.slides[0]
    # Lägger till SmartArt-formen på den första bilden
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Åtkomst till SmartArt-noden på index 0
    node = smart.all_nodes[0]
    # Åtkomst till undernoden på position 1 i föräldranoden
    position = 1
    chNode = node.child_nodes[position] 
    # Skriver ut parametrarna för SmartArt-undernoden
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```

## **Ta bort SmartArt-nod**
I det här exemplet kommer vi att lära oss att ta bort noder i SmartArt-formen.

- Skapa en instans av `Presentation`-klassen och ladda presentationen med SmartArt-Form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form på den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
- Kontrollera om SmartArt har fler än 0 noder.
- Välj den SmartArt-nod som ska tas bort.
- Nu, ta bort den valda noden med metoden RemoveNode()* Spara presentationen.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Ladda den önskade presentationen
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Iterera igenom alla former på den första bilden
    for shape in pres.slides[0].shapes:
        # Kontrollera om formen är av typen SmartArt
        if type(shape) is art.SmartArt:
            # Typkonvertera formen till SmartArtEx
            if len(shape.all_nodes) > 0:
                # Åtkomst till SmartArt-noden på index 0
                node = shape.all_nodes[0]

                # Ta bort den valda noden
                shape.all_nodes.remove_node(node)

    # Spara presentationen
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ta bort SmartArt-nod på specifik position**
I det här exemplet kommer vi att lära oss att ta bort noder i SmartArt-formen på en viss position.

- Skapa en instans av `Presentation`-klassen och ladda presentationen med SmartArt-Form.
- Hämta referensen till den första bilden genom att använda dess Index.
- Gå igenom varje form på den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArt om den är SmartArt.
- Välj SmartArt-formens nod på index 0.
- Kontrollera nu om den valda SmartArt-noden har fler än 2 undernoder.
- Ta nu bort noden på Position 1 med metoden RemoveNodeByPosition().
- Spara presentationen.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Ladda den önskade presentationen
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Iterera igenom alla former på den första bilden
    for shape in pres.slides[0].shapes:
        # Kontrollera om formen är av typen SmartArt
        if type(shape) is art.SmartArt:
            # Typkonvertera formen till SmartArt
            if len(shape.all_nodes) > 0:
                # Åtkomst till SmartArt-noden på index 0
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Tar bort undernoden på position 1
                    node.child_nodes.remove_node(1)

    # Spara presentationen
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange anpassad position för undernod i SmartArt**
Nu stöder Aspose.Slides för Python via .NET att ange X‑ och Y‑egenskaper för SmartArtShape. Kodsnutten nedan visar hur du anger en anpassad position, storlek och rotation för SmartArtShape, observera även att tillägg av nya noder orsakar en omräkning av positioner och storlekar för alla noder.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Ladda den önskade presentationen
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# Flytta SmartArt-formen till ny position
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# Ändra SmartArt-formens bredd
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# Ändra SmartArt-formens höjd
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# Ändra SmartArt-formens rotation
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```

## **Kontrollera assistentnod**
I följande exempelprogramkod kommer vi att undersöka hur man identifierar Assistant‑Nodes i SmartArt‑nodsamlingen och ändrar dem.

- Skapa en instans av PresentationEx-klassen och ladda presentationen med SmartArt-Form.
- Hämta referensen till den andra bilden genom att använda dess Index.
- Gå igenom varje form på den första bilden.
- Kontrollera om formen är av typen SmartArt och typkonvertera den valda formen till SmartArtEx om den är SmartArt.
- Gå igenom alla noder i SmartArt-formen och kontrollera om de är Assistant‑Nodes.
- Ändra statusen för Assistant‑Node till normal node.
- Spara presentationen.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Skapar en presentationsinstans
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Iterera igenom alla former på den första bilden
    for shape in pres.slides[0].shapes:
        # Kontrollera om formen är av typen SmartArt
        if type(shape) is art.SmartArt:
            # Iterera igenom alla noder i SmartArt-formen
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Kontrollera om noden är en assistentnod
                if node.is_assistant:
                    # Sätter assistentnod till false och gör den till en normal nod
                    node.is_assistant = False
    # Spara presentationen
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange nodens fyllningsformat**
Aspose.Slides för Python via .NET möjliggör att lägga till anpassade SmartArt‑former och ange deras fyllningsformat. Denna artikel förklarar hur man skapar och får åtkomst till SmartArt‑former samt anger deras fyllningsformat med Aspose.Slides för Python via .NET.

Följ stegen nedan:

- Skapa en instans av `Presentation`‑klassen.
- Hämta referensen till en bild med hjälp av dess index.
- Lägg till en SmartArt‑form genom att sätta dess LayoutType.
- Ange FillFormat för SmartArt-formens noder.
- Skriv den modifierade presentationen som en PPTX‑fil.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # Åtkomst till bilden
    slide = presentation.slides[0]

    # Lägger till SmartArt-form och noder
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Anger nodens fyllningsfärg
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Sparar presentationen
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Generera miniatyr av SmartArt-undernod**
Utvecklare kan generera en miniatyr av en Child‑node i en SmartArt genom att följa stegen nedan:

1. Instansiera `Presentation`‑klassen som representerar PPTX‑filen.
2. Lägg till SmartArt.
3. Hämta referensen till en node med hjälp av dess Index.
4. Hämta miniatyrbilden.
5. Spara miniatyrbilden i önskat bildformat.

Exemplet nedan genererar en miniatyr av SmartArt-child-node

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Instansiera Presentation-klass som representerar PPTX-filen 
with slides.Presentation() as presentation: 
    # Lägg till SmartArt 
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # Hämta referensen till en nod genom att använda dess index  
    node = smart.nodes[1]

    # Hämta miniatyr
    with node.shapes[0].get_image() as bmp:
        # spara miniatyr
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **FAQ**

**Stöds SmartArt‑animation?**

Ja. SmartArt behandlas som en vanlig form, så du kan [tillämpa standardanimationer](/slides/sv/python-net/shape-animation/) (ingång, utgång, betoning, rörelsespår) och justera tidpunkter. Du kan även animera former inuti SmartArt‑noder vid behov.

**Hur kan jag på ett pålitligt sätt hitta en specifik SmartArt på en bild om dess interna ID är okänt?**

Tilldela och sök efter [alternativ text](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartart/alternative_text/). Genom att sätta en tydlig AltText på SmartArt kan du hitta den programmässigt utan att förlita dig på interna identifierare.

**Kommer SmartArt‑utseendet att bevaras när presentationen konverteras till PDF?**

Ja. Aspose.Slides renderar SmartArt med hög visuell trohet vid [PDF‑export](/slides/sv/python-net/convert-powerpoint-to-pdf/), vilket bevarar layout, färger och effekter.

**Kan jag extrahera en bild av hela SmartArt (för förhandsgranskningar eller rapporter)?**

Ja. Du kan rendera en SmartArt‑form till [rasterformat](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartart/get_image/) eller till [SVG](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartart/write_as_svg/) för skalbar vektoroutput, vilket gör den lämplig för miniatyrer, rapporter eller webbbruk.