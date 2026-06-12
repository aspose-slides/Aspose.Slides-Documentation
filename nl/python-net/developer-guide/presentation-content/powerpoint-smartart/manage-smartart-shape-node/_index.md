---
title: SmartArt‑vormknooppunten beheren in presentaties met Python
linktitle: SmartArt‑vormknooppunt
type: docs
weight: 30
url: /nl/python-net/manage-smartart-shape-node/
keywords:
- SmartArt‑knooppunt
- onderliggend knooppunt
- knooppunt toevoegen
- knooppuntpositie
- knooppunt benaderen
- knooppunt verwijderen
- aangepaste positie
- assistentknooppunt
- vulopmaak
- knooppunt weergeven
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Beheer SmartArt‑vormknooppunten in PPT, PPTX en ODP met Aspose.Slides voor Python via .NET. Ontvang duidelijke codevoorbeelden en tips om uw presentaties te stroomlijnen."
---
## **Overzicht**

SmartArt-afbeeldingen in PowerPoint‑presentaties worden georganiseerd via knooppunten die tekst bevatten en de structuur van het diagram bepalen. Aspose.Slides stelt u in staat om programmatic met deze SmartArt‑knooppunten te werken: nieuwe knooppunten en onderliggende knooppunten toe te voegen, onderliggende knooppunten op een specifieke positie in te voegen, bestaande knooppunten te benaderen en hun tekst, niveau en positie uit te lezen.

Dit artikel legt uit hoe u SmartArt‑vormknooppunten beheert. Het toont hoe u knooppunten verwijdert, werkt met onderliggende knooppunten op index of positie, een assistent‑knooppunt verandert in een normaal knooppunt, de positie, grootte en rotatie van SmartArt‑knooppuntvormen aanpast, vulopmaak voor knooppunten instelt en een miniatuurafbeelding genereert voor een SmartArt‑onderliggend knooppunt.

## **SmartArt‑knooppunt toevoegen**
Aspose.Slides for Python via .NET biedt de eenvoudigste API om SmartArt‑vormen op de gemakkelijkste manier te beheren. De onderstaande voorbeeldcode helpt bij het toevoegen van een knooppunt en een onderliggend knooppunt binnen een SmartArt‑vorm.

- Maak een instantie van de class [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) en laad de presentatie met een SmartArt‑vorm.  
- Haal de referentie van de eerste dia op met behulp van de Index.  
- Doorloop elke vorm op de eerste dia.  
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArt indien dit het geval is.  
- Voeg een nieuw knooppunt toe aan de NodeCollection van de SmartArt‑vorm en stel de tekst in het TextFrame in.  
- Voeg nu een onderliggend knooppunt toe aan het zojuist toegevoegde SmartArt‑knooppunt en stel de tekst in het TextFrame in.  
- Sla de presentatie op.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laad de gewenste presentatie
with slides.Presentation(path + "AddNodes.pptx") as pres:
    # Doorloop elke vorm op de eerste dia
    for shape in pres.slides[0].shapes:

        # Controleer of de vorm van het type SmartArt is
        if type(shape) is art.SmartArt:
            # Een nieuw SmartArt‑knooppunt toevoegen
            node1 = shape.all_nodes.add_node()
            # Tekst toevoegen
            node1.text_frame.text = "Test"

            # Een nieuw onderliggend knooppunt toevoegen in het bovenliggende knooppunt. Het wordt aan het einde van de collectie toegevoegd
            new_node = node1.child_nodes.add_node()

            # Tekst toevoegen
            new_node.text_frame.text = "New Node Added"

    # Presentatie opslaan
    pres.save("AddSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt‑knooppunt toevoegen op specifieke positie**
In de onderstaande voorbeeldcode leggen we uit hoe u onderliggende knooppunten die bij respectieve knooppunten van een SmartArt‑vorm horen, op een bepaalde positie toevoegt.

- Maak een instantie van de class `Presentation`.  
- Haal de referentie van de eerste dia op met behulp van de Index.  
- Voeg een SmartArt‑vorm van het type StackedList toe aan de benaderde dia.  
- Benader het eerste knooppunt in de toegevoegde SmartArt‑vorm.  
- Voeg nu een onderliggend knooppunt toe voor het geselecteerde knooppunt op positie 2 en stel de tekst in.  
- Sla de presentatie op.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Een presentatie‑instantie maken
with slides.Presentation() as pres:
    # De presentatiedia benaderen
    slide = pres.slides[0]

    # SmartArt‑IShape toevoegen
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)

    # Het SmartArt‑knooppunt op index 0 benaderen
    node = smart.all_nodes[0]

    # Een nieuw onderliggend knooppunt toevoegen op positie 2 in het bovenliggende knooppunt
    chNode = node.child_nodes.add_node_by_position(2)

    # Tekst toevoegen
    chNode.text_frame.text = "Sample text Added"

    # Presentatie opslaan
    pres.save("AddSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt‑knooppunt benaderen**
De onderstaande voorbeeldcode helpt bij het benaderen van knooppunten binnen een SmartArt‑vorm. Let op: u kunt het LayoutType van de SmartArt niet wijzigen, omdat dit alleen‑lezen is en alleen wordt ingesteld wanneer de SmartArt‑vorm wordt toegevoegd.

- Maak een instantie van de class `Presentation` en laad de presentatie met een SmartArt‑vorm.  
- Haal de referentie van de eerste dia op met behulp van de Index.  
- Doorloop elke vorm op de eerste dia.  
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArt indien dit het geval is.  
- Doorloop alle knooppunten binnen de SmartArt‑vorm.  
- Benader en toon informatie zoals de positie, het niveau en de tekst van het SmartArt‑knooppunt.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laad de gewenste presentatie
with slides.Presentation(path + "AccessSmartArt.pptx") as pres:
    # Doorloop elke vorm op de eerste dia
    for shape in pres.slides[0].shapes:
        # Controleer of de vorm van het type SmartArt is
        if type(shape) is art.SmartArt:
            # Doorloop alle knooppunten binnen SmartArt
            for i in range(len(shape.all_nodes)):
                # SmartArt‑knooppunt op index i benaderen
                node = shape.all_nodes[i]

                # De parameters van het SmartArt‑knooppunt afdrukken
                print("i = {0}, text = {1},  level = {2}, position = {3}".format(i, node.text_frame.text, node.level, node.position))
```

## **SmartArt‑onderliggend knooppunt benaderen**
De onderstaande voorbeeldcode helpt bij het benaderen van onderliggende knooppunten die bij respectieve knooppunten van een SmartArt‑vorm horen.

- Maak een instantie van de class PresentationEx en laad de presentatie met een SmartArt‑vorm.  
- Haal de referentie van de eerste dia op met behulp van de Index.  
- Doorloop elke vorm op de eerste dia.  
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArtEx indien dit het geval is.  
- Doorloop alle knooppunten binnen de SmartArt‑vorm.  
- Voor elk geselecteerd SmartArt‑vormknooppunt, doorloop alle onderliggende knooppunten binnen dat specifieke knooppunt.  
- Benader en toon informatie zoals de positie, het niveau en de tekst van het onderliggende knooppunt.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laad de gewenste presentatie
with slides.Presentation(path + "AccessChildNodes.pptx") as pres:
    # Doorloop elke vorm op de eerste dia
    for shape in pres.slides[0].shapes:
        # Controleer of de vorm van het type SmartArt is
        if type(shape) is art.SmartArt:
            # Doorloop alle knooppunten binnen SmartArt
            for node0 in shape.all_nodes:
                # Doorloop de onderliggende knooppunten
                for j in range(len(node0.child_nodes)):
                    # Het onderliggende knooppunt in het SmartArt‑knooppunt benaderen
                    node = node0.child_nodes[j]

                    # De parameters van het SmartArt‑onderliggende knooppunt afdrukken
                    print("j = {0}, text = {1},  level = {2}, position = {3}".format(j, node.text_frame.text, node.level, node.position))

```

## **SmartArt‑onderliggend knooppunt benaderen op specifieke positie**
In dit voorbeeld leren we hoe we onderliggende knooppunten op een bepaalde positie kunnen benaderen die bij respectieve knooppunten van een SmartArt‑vorm horen.

- Maak een instantie van de class `Presentation`.  
- Haal de referentie van de eerste dia op met behulp van de Index.  
- Voeg een SmartArt‑vorm van het type StackedList toe.  
- Benader de toegevoegde SmartArt‑vorm.  
- Benader het knooppunt op index 0 van de benaderde SmartArt‑vorm.  
- Benader nu het onderliggende knooppunt op positie 1 van het benaderde SmartArt‑knooppunt met behulp van de methode GetNodeByPosition().  
- Benader en toon informatie zoals de positie, het niveau en de tekst van het onderliggende knooppunt.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Een presentatie‑instantie maken
with slides.Presentation() as pres:
    # De eerste dia benaderen
    slide = pres.slides[0]
    # De SmartArt‑vorm toevoegen op de eerste dia
    smart = slide.shapes.add_smart_art(0, 0, 400, 400, art.SmartArtLayoutType.STACKED_LIST)
    # Het SmartArt‑knooppunt op index 0 benaderen
    node = smart.all_nodes[0]
    # Het onderliggende knooppunt op positie 1 in het bovenliggende knooppunt benaderen
    position = 1
    chNode = node.child_nodes[position] 
    # De parameters van het SmartArt‑onderliggende knooppunt afdrukken
    print("j = {0}, text = {1},  level = {2}, position = {3}".format(position, chNode.text_frame.text, chNode.level, chNode.position))

```

## **SmartArt‑knooppunt verwijderen**
In dit voorbeeld leren we hoe we knooppunten binnen een SmartArt‑vorm kunnen verwijderen.

- Maak een instantie van de class `Presentation` en laad de presentatie met een SmartArt‑vorm.  
- Haal de referentie van de eerste dia op met behulp van de Index.  
- Doorloop elke vorm op de eerste dia.  
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArt indien dit het geval is.  
- Controleer of de SmartArt meer dan 0 knooppunten heeft.  
- Selecteer het SmartArt‑knooppunt dat verwijderd moet worden.  
- Verwijder nu het geselecteerde knooppunt met de methode RemoveNode()* Sla de presentatie op.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laad de gewenste presentatie
with slides.Presentation(path + "RemoveNode.pptx") as pres:
    # Doorloop elke vorm op de eerste dia
    for shape in pres.slides[0].shapes:
        # Controleer of de vorm van het type SmartArt is
        if type(shape) is art.SmartArt:
            # Cast de vorm naar SmartArtEx
            if len(shape.all_nodes) > 0:
                # SmartArt‑knooppunt op index 0 benaderen
                node = shape.all_nodes[0]

                # Het geselecteerde knooppunt verwijderen
                shape.all_nodes.remove_node(node)

    # Presentatie opslaan
    pres.save("RemoveSmartArtNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **SmartArt‑knooppunt verwijderen op specifieke positie**
In dit voorbeeld leren we hoe we knooppunten binnen een SmartArt‑vorm op een specifieke positie kunnen verwijderen.

- Maak een instantie van de class `Presentation` en laad de presentatie met een SmartArt‑vorm.  
- Haal de referentie van de eerste dia op met behulp van de Index.  
- Doorloop elke vorm op de eerste dia.  
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArt indien dit het geval is.  
- Selecteer het SmartArt‑vormknooppunt op index 0.  
- Controleer nu of het geselecteerde SmartArt‑knooppunt meer dan 2 onderliggende knooppunten heeft.  
- Verwijder nu het knooppunt op positie 1 met de methode RemoveNodeByPosition().  
- Sla de presentatie op.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laad de gewenste presentatie
with slides.Presentation(path + "RemoveNodeSpecificPosition.pptx") as pres:             
    # Doorloop elke vorm op de eerste dia
    for shape in pres.slides[0].shapes:
        # Controleer of de vorm van het type SmartArt is
        if type(shape) is art.SmartArt:
            # Cast de vorm naar SmartArt
            if len(shape.all_nodes) > 0:
                # SmartArt‑knooppunt op index 0 benaderen
                node = shape.all_nodes[0]
                if len(node.child_nodes) >= 2:
                    # Het onderliggende knooppunt op positie 1 verwijderen
                    node.child_nodes.remove_node(1)

    # Presentatie opslaan
    pres.save("RemoveSmartArtNodeByPosition_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aangepaste positie instellen voor onderliggend knooppunt in SmartArt**
Nu ondersteunt Aspose.Slides for Python via .NET het instellen van de X‑ en Y‑eigenschappen van SmartArtShape. Het onderstaande code‑fragment toont hoe u een aangepaste positie, grootte en rotatie van SmartArtShape instelt; let ook op dat het toevoegen van nieuwe knooppunten een herberekening van de posities en afmetingen van alle knooppunten veroorzaakt.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Laad de gewenste presentatie
with slides.Presentation(path + "AccessChildNodes.pptx") as pres: 
	smart = pres.slides[0].shapes.add_smart_art(20, 20, 600, 500, art.SmartArtLayoutType.ORGANIZATION_CHART)

	# SmartArt‑vorm naar een nieuwe positie verplaatsen
	node = smart.all_nodes[1]
	shape = node.shapes[1]
	shape.x += (shape.width * 2)
	shape.y -= (shape.height / 2)

	# De breedtes van de SmartArt‑vorm wijzigen
	node = smart.all_nodes[2]
	shape = node.shapes[1]
	shape.width += (shape.width / 2)

	# De hoogte van de SmartArt‑vorm wijzigen
	node = smart.all_nodes[3]
	shape = node.shapes[1]
	shape.height += (shape.height / 2)

	# De rotatie van de SmartArt‑vorm wijzigen
	node = smart.all_nodes[4]
	shape = node.shapes[1]
	shape.rotation = 90

	pres.save("SmartArt.pptx", slides.export.SaveFormat.PPTX)
```

## **Assistentknooppunt controleren**
In de onderstaande voorbeeldcode onderzoeken we hoe we Assistant‑knooppunten in de SmartArt‑knooppuntenverzameling kunnen identificeren en aanpassen.

- Maak een instantie van de class PresentationEx en laad de presentatie met een SmartArt‑vorm.  
- Haal de referentie van de tweede dia op met behulp van de Index.  
- Doorloop elke vorm op de eerste dia.  
- Controleer of de vorm van het type SmartArt is en cast de geselecteerde vorm naar SmartArtEx indien dit het geval is.  
- Doorloop alle knooppunten binnen de SmartArt‑vorm en controleer of ze Assistant‑knooppunten zijn.  
- Verander de status van het Assistant‑knooppunt naar een normaal knooppunt.  
- Sla de presentatie op.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

# Een presentatie‑instantie maken
with slides.Presentation(path + "AssistantNode.pptx") as pres: 
    # Doorloop elke vorm op de eerste dia
    for shape in pres.slides[0].shapes:
        # Controleer of de vorm van het type SmartArt is
        if type(shape) is art.SmartArt:
            # Doorloop alle knooppunten van de SmartArt‑vorm
            for node in shape.all_nodes:
                tc = node.text_frame.text
                # Controleer of het knooppunt een assistentknooppunt is
                if node.is_assistant:
                    # Stel het assistentknooppunt in op false en maak er een normaal knooppunt van
                    node.is_assistant = False
    # Presentatie opslaan
    pres.save("ChangeAssitantNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Vulopmaak van knooppunt instellen**
Aspose.Slides for Python via .NET maakt het mogelijk om aangepaste SmartArt‑vormen toe te voegen en hun vulopmaak in te stellen. Dit artikel legt uit hoe u SmartArt‑vormen maakt en benadert en hun vulopmaak instelt met behulp van Aspose.Slides for Python via .NET.

Volg de onderstaande stappen:

- Maak een instantie van de class `Presentation`.  
- Haal de referentie van een dia op met behulp van de index.  
- Voeg een SmartArt‑vorm toe door het LayoutType in te stellen.  
- Stel de FillFormat in voor de knooppunten van de SmartArt‑vorm.  
- Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

```py
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.smartart as art

with slides.Presentation() as presentation: 
    # De dia benaderen
    slide = presentation.slides[0]

    # SmartArt‑vorm en knooppunten toevoegen
    chevron = slide.shapes.add_smart_art(10, 10, 800, 60, art.SmartArtLayoutType.CLOSED_CHEVRON_PROCESS)
    node = chevron.all_nodes.add_node()
    node.text_frame.text = "Some text"

    # Vulkleur van knooppunt instellen
    for item in node.shapes:
        item.fill_format.fill_type = slides.FillType.SOLID
        item.fill_format.solid_fill_color.color = draw.Color.red

    # Presentatie opslaan
    presentation.save("FillFormat_SmartArt_ShapeNode_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Miniatuur genereren van SmartArt‑onderliggend knooppunt**
Ontwikkelaars kunnen een miniatuur van een onderliggend knooppunt van een SmartArt genereren door de onderstaande stappen te volgen:

1. Instantieer de class `Presentation` die het PPTX‑bestand vertegenwoordigt.  
2. Voeg SmartArt toe.  
3. Haal de referentie van een knooppunt op met behulp van de Index.  
4. Haal de miniatuurafbeelding op.  
5. Sla de miniatuurafbeelding op in elk gewenst afbeelding‑formaat.

Het voorbeeld hieronder genereert een miniatuur van een SmartArt‑onderliggend knooppunt

```py
import aspose.slides as slides
import aspose.slides.smartart as art

# Een instantie van de Presentation‑klasse maken die het PPTX‑bestand vertegenwoordigt
with slides.Presentation() as presentation: 
    # SmartArt toevoegen
    smart = pres.slides[0].shapes.add_smart_art(10, 10, 400, 300, art.SmartArtLayoutType.BASIC_CYCLE)

    # De referentie van een knooppunt verkrijgen met behulp van de index  
    node = smart.nodes[1]

    # Miniatuur ophalen
    with node.shapes[0].get_image() as bmp:
        # miniatuur opslaan
        bmp.save("SmartArt_ChildNote_Thumbnail_out.jpeg", slides.ImageFormat.JPEG)
```

## **Veelgestelde vragen**

**Wordt SmartArt‑animatie ondersteund?**

Ja. SmartArt wordt behandeld als een gewone vorm, zodat u [standaardanimaties](/slides/nl/python-net/shape-animation/) (invoeren, verlaten, nadruk, bewegingspaden) kunt toepassen en de timing kunt aanpassen. U kunt ook vormen binnen SmartArt‑knooppunten animeren wanneer nodig.

**Hoe kan ik een specifiek SmartArt op een dia betrouwbaar vinden als de interne ID onbekend is?**

Ken een [alternatieve tekst](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartart/alternative_text/) toe en zoek daarop. Het instellen van een onderscheidende AltText op het SmartArt stelt u in staat het programmatisch te vinden zonder te vertrouwen op interne identificatoren.

**Blijft het uiterlijk van SmartArt behouden bij het converteren van de presentatie naar PDF?**

Ja. Aspose.Slides rendert SmartArt met een hoge visuele nauwkeurigheid tijdens de [PDF‑export](/slides/nl/python-net/convert-powerpoint-to-pdf/), waarbij lay-out, kleuren en effecten behouden blijven.

**Kan ik een afbeelding van de volledige SmartArt extraheren (voor voorbeeldweergaven of rapporten)?**

Ja. U kunt een SmartArt‑vorm renderen naar [rasterformaten](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartart/get_image/) of naar [SVG](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartart/write_as_svg/) voor schaalbare vectoruitvoer, waardoor het geschikt is voor miniaturen, rapporten of webgebruik.