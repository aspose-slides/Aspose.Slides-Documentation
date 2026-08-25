---
title: Presentaties efficiënt samenvoegen met Python
linktitle: Presentaties samenvoegen
type: docs
weight: 40
url: /nl/python-net/merge-presentation/
keywords:
- PowerPoint samenvoegen
- presentaties samenvoegen
- dia's samenvoegen
- PPT samenvoegen
- PPTX samenvoegen
- ODP samenvoegen
- PowerPoint combineren
- presentaties combineren
- dia's combineren
- PPT combineren
- PPTX combineren
- ODP combineren
- Python
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument‑presentaties in Python kunt samenvoegen door dia's te klonen, masters en lay‑outs te beheren, dia‑inhoud te schalen, secties te behouden en beschermde of grote bestanden af te handelen."
---
## **Overzicht**

Aspose.Slides for Python via .NET voegt presentaties samen door dia's te klonen van één [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) naar een andere. De hoofdoperatie is [SlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/), die de opmaak van de bron‑dia kan behouden of de gekloonde dia kan koppelen aan een master of lay‑out in de bestemmingspresentatie.

Dit artikel behandelt de meest voorkomende samenvoeg‑workflows:

- alle dia's samenvoegen met behoud van hun bronopmaak;
- geselecteerde dia's samenvoegen;
- een master van de bestemmingspresentatie toepassen;
- een specifieke lay‑out van de bestemmingspresentatie toepassen;
- verschillende dia‑groottes normaliseren vóór het samenvoegen;
- gekloonde dia's toevoegen aan een sectie;
- meerdere presentaties samenvoegen in één end‑to‑end workflow;
- masters, bronnen, notities, opmerkingen, media, lettertypen, wachtwoorden, grote bestanden en multithreading‑aspecten afhandelen.

## **Hoe dia‑klonen masters en lay‑outs beïnvloedt**

Een dia erft veel van zijn uiterlijk van zijn lay‑out en master. Om die reden bepaalt de overload van klonen die u kiest hoe de samengevoegde dia wordt geïntegreerd in de bestemmingspresentatie.

Gebruik [SlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/) op één van de volgende manieren:

- `add_clone(source_slide)` — behoud de lay‑out en opmaak van de bron‑dia. Indien nodig kan de bron‑master automatisch in de bestemmingspresentatie worden gekloond. Aspose.Slides houdt automatisch gekloonde masters bij zodat herhaalde dia's die dezelfde bron‑master gebruiken niet telkens die master opnieuw klonen.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — koppel de gekloonde dia aan een specifieke bestemmings‑[IMasterSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imasterslide/). Aspose.Slides zoekt onder die master naar een overeenkomende lay‑out op basis van lay‑outtype of naam.
- `add_clone(source_slide, destination_layout)` — koppel de gekloonde dia direct aan een specifieke bestemmings‑[ILayoutSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ilayoutslide/).

De master of lay‑out die aan een `add_clone`‑overload wordt doorgegeven, moet behoren tot de **bestemmings**‑presentatie, niet tot de bron‑presentatie.

## **Gehele presentaties samenvoegen en bronopmaak behouden**

De eenvoudigste samenvoeging kopieert elke dia van de bron‑presentatie naar de bestemmingspresentatie. Dit is de juiste keuze wanneer de geïmporteerde dia's hun oorspronkelijke thema, master en lay‑outrelaties moeten behouden.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

De resulterende presentatie kan meerdere masters bevatten wanneer bron‑ en bestemmingspresentatie verschillende ontwerpen gebruiken. Dit is te verwachten wanneer bronopmaak bewust behouden wordt.

## **Geselecteerde dia's samenvoegen**

U hoeft niet elke dia te klonen. Het volgende voorbeeld importeert alleen geselecteerde dia‑indexen uit de bron‑presentatie.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

Valideer dia‑indexen vóór het klonen wanneer ze afkomstig zijn van gebruikersinvoer of externe configuratie.

## **Dia's samenvoegen met een bestemmings‑master**

Gebruik de [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/)‑overload wanneer geïmporteerde dia's een master moeten volgen die al tot de bestemmingspresentatie behoort.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides selecteert een geschikte lay‑out onder de opgegeven master door de lay‑outtype of -naam van de bron‑lay‑out te vergelijken. Als er geen passende lay‑out bestaat en `allow_clone_missing_layout` is `True`, wordt de bron‑lay‑out gekloond zodat de dia kan worden toegevoegd. Als het `False` is, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pptxeditexception/) gegooid.

Gebruik `False` wanneer u wilt dat het samenvoegen faalt in plaats van een extra lay‑out aan de bestemmings‑master toe te voegen.

## **Dia's samenvoegen met een specifieke bestemmings‑lay‑out**

Gebruik de [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/)‑overload wanneer u precies weet welke bestemmings‑lay‑out de geïmporteerde dia's moeten gebruiken.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

Toepassing van een bestemmings‑lay‑out verandert de geërfde lay‑outrelatie; het herontwerpt de inhoud van de bron‑dia niet. Als bron‑ en bestemmings‑lay‑outs verschillende placeholder‑structuren hebben, inspecteer dan het resultaat om te bevestigen dat de overgenomen opmaak en placeholder‑gedrag passend zijn.

## **Presentaties met verschillende dia‑groottes samenvoegen**

Presentaties met verschillende dia‑afmetingen kunnen worden samengevoegd, maar een dia klonen naar een presentatie met een andere dia‑grootte herontwerpt de inhoud niet automatisch voor het nieuwe canvas. Vormen kunnen daardoor verschoven, onverwacht geschaald of buiten het zichtbare dia‑gebied verschijnen.

Een praktische aanpak is om de bron‑presentatie vóór het klonen te schalen. De [SlideSize.set_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidesize/set_size/)‑methode kan bestaande inhoud schalen terwijl de dia‑afmetingen worden aangepast. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidesizescaletype/) schaalt inhoud zodat deze past binnen de opgegeven grootte.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        if (
            source.slide_size.size.width != destination.slide_size.size.width
            or source.slide_size.size.height != destination.slide_size.size.height
        ):
            source.slide_size.set_size(
                destination.slide_size.size.width,
                destination.slide_size.size.height,
                slides.SlideSizeScaleType.ENSURE_FIT)

        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged-same-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

Schalen wijzigt het bron‑presentatie‑object in het geheugen. Als u de oorspronkelijke bron‑presentatie ongewijzigd wilt behouden voor andere bewerkingen, open dan een aparte instantie voor de samenvoeging.

## **Dia's samenvoegen in een presentatiesectie**

De basis‑dia‑klonlus maakt de sectiehiearchie van de bron‑presentatie niet opnieuw. Als secties van belang zijn in de output, maak of selecteer dan secties in de bestemmingspresentatie en kloon dia's expliciet naar hen met [SlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/).

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

De gekloonde dia's worden toegevoegd aan de opgegeven bestemmingssectie. Om meerdere bron‑secties te behouden, doorloop [Presentation.sections](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/sections/), haal de huidige dia's van elke bron‑sectie op met [Section.get_slides_list_of_section](https://reference.aspose.com/slides/nl/python-net/aspose.slides/section/get_slides_list_of_section/), recreate de secties in de bestemming, en kloon elke teruggegeven dia naar de overeenkomstige bestemmingssectie. Zie [Manage Slide Sections](/slides/nl/python-net/slide-section/) voor een volledig sectie‑enumeratie‑voorbeeld, inclusief lege secties en structurele wijzigingen.

## **Meerdere presentaties veilig samenvoegen**

Het volgende end‑to‑end voorbeeld gebruikt de eerste presentatie als bestemming, normaliseert de dia‑grootte van elke extra bron, houdt elke bron slechts open zolang deze gekopieerd wordt, en slaat het uiteindelijke bestand pas op het einde op.

```python
import aspose.slides as slides

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

with slides.Presentation(input_files[0]) as merged:
    for file_index in range(1, len(input_files)):
        with slides.Presentation(input_files[file_index]) as source:
            if (
                source.slide_size.size.width != merged.slide_size.size.width
                or source.slide_size.size.height != merged.slide_size.size.height
            ):
                source.slide_size.set_size(
                    merged.slide_size.size.width,
                    merged.slide_size.size.height,
                    slides.SlideSizeScaleType.ENSURE_FIT)

            for slide in source.slides:
                merged.slides.add_clone(slide)

    merged.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

Dit is een nuttige basis om de bronopmaak van geïmporteerde dia's te behouden. Als uw output een enkel bestemmings‑thema moet gebruiken, vervang dan de eenvoudige `add_clone(slide)`‑aanroep door de eerder getoonde overload met bestemmings‑master of -lay‑out.

## **Praktische overwegingen**

### **Masters, lay‑outs en nauwkeurigheid van opmaak**

Standaard dia‑klonen kan automatisch een benodigde bron‑master in de bestemmingspresentatie brengen. Aspose.Slides houdt een interne registratie bij van automatisch gekloonde masters om te voorkomen dat dezelfde master herhaaldelijk wordt gekloond. Handmatig gekloonde masters worden niet in die registratie bijgehouden, dus vermijd voorklonen van masters tenzij u expliciete controle over de master‑structuur nodig hebt.

Ga er niet vanuit dat twee masters of lay‑outs met dezelfde naam visueel gelijk zijn. Als een corporate‑template de uiteindelijke uitstraling moet bepalen, kies dan expliciet een bestemmings‑master of -lay‑out en verifieer het resultaat na het samenvoegen.

### **Notities en opmerkingen**

Sprekers‑notities en dia‑opmerkingen zijn gekoppeld aan de dia‑inhoud en worden gekopieerd wanneer een dia wordt gekloond. Aspose.Slides biedt tevens speciale API’s voor [presentation notes](/slides/nl/python-net/presentation-notes/) en [presentation comments](/slides/nl/python-net/presentation-comments/).

Als de opmaak van de notitie‑pagina belangrijk is, controleer dan de samengevoegde presentatie omdat notitie‑masters objecten op presentatieniveau zijn en kunnen verschillen tussen bronbestanden. Controleer bij review‑workflows ook de auteurs van opmerkingen en geneste discussies na het combineren van bestanden van verschillende auteurs of templates.

### **Afbeeldingen, audio, video, OLE‑objecten en externe koppelingen**

Dia's kunnen verwijzen naar resources op presentatieniveau, zoals afbeeldingen, ingesloten audio, video en OLE‑data. Kloon de volledige dia in plaats van alleen de zichtbare vormen zodat Aspose.Slides de relaties van de dia met zijn resources kan behouden.

Ingesloten en gekoppelde resources dienen verschillend behandeld te worden. Een gekoppeld audio‑, video‑, OLE‑object of hyperlink blijft afhankelijk van zijn externe doel; het klonen van een dia maakt een externe link niet tot ingesloten content. Test de paden en URL’s van gekoppelde resources in de omgeving waarin de samengevoegde presentatie wordt geopend.

Aspose.Slides houdt automatisch gekloonde masters bij, maar dit moet niet worden opgevat als een algemene garantie dat identieke binaire resources van uiteenlopende bron‑presentaties altijd worden gededupliceerd. Als de bestandsgrootte van belang is, inspecteer dan het samengevoegde pakket en meet het resultaat in plaats van te vertrouwen op impliciete deduplicatie.

### **Ingesloten lettertypen en beschikbaarheid van fonts**

Lettertypen worden beheerd op presentatieniveau. Als typografie consistent moet blijven over machines, ga er niet vanzelfsprekend van uit dat het klonen van dia's alleen garandeert dat elk benodigd lettertype beschikbaar is in de bestemmingsomgeving. U kunt ingesloten lettertypen bekijken met [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) en expliciet beheren zoals beschreven in [Embed Fonts in Presentations](/slides/nl/python-net/embedded-font/).

Controleer ook dat u toestemming heeft om de lettertypen die in de bronbestanden worden gebruikt in te sluiten. Licenties voor lettertypen kunnen insluit‑rechten beperken.

### **Wachtwoord‑beveiligde presentaties**

Een wachtwoord‑beveiligde bron moet eerst succesvol worden geopend voordat de dia's kunnen worden gekloond. Geef het wachtwoord door via [LoadOptions.password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/password/).

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

Het openen van een versleutelde bron past de dezelfde bescherming niet automatisch toe op de bestemmingspresentatie. Configureer de output‑beveiliging apart wanneer dat nodig is.

### **Grote presentaties en geheugenverbruik**

Grote presentaties met hoge‑resolutie‑afbeeldingen, audio, video of andere omvangrijke binaire objecten kunnen aanzienlijk geheugen verbruiken. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/blob_management_options/) biedt controle over BLOB‑afhandeling en het gebruik van tijdelijke bestanden. Zie [Manage Presentation BLOBs](/slides/nl/python-net/manage-blob/) voor strategieën voor grote bestanden.

Voor grote bestanden, laad bij voorkeur vanaf bestandspaden, sluit elke bron‑presentatie zodra deze is samengevoegd, en vermijd herhaaldelijk opslaan van tussenresultaten tenzij de workflow checkpoints vereist. Het gebruik van `with slides.Presentation(...)` zorgt ervoor dat presentatie‑resources worden vrijgegeven wanneer de context wordt verlaten.

### **Thread‑veiligheid**

Laad, sla op of kloon een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instantie niet gelijktijdig vanuit meerdere threads. Houd elke samenvoegbewerking single‑threaded. Als u onafhankelijke samenvoeg‑taken paralleliseert, gebruik dan afzonderlijke single‑threaded processen en onafhankelijke presentatie‑instanties zoals beschreven in de [Aspose.Slides multithreading guidance](/slides/nl/python-net/multithreading/).

## **FAQ**

**Hoe behoud ik het oorspronkelijke ontwerp van elke bron‑presentatie?**

Gebruik [add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/) zonder een bestemmings‑master of -lay‑out op te geven. Aspose.Slides kan de bron‑master automatisch klonen wanneer deze nodig is voor de geïmporteerde dia.

**Hoe laat ik geïmporteerde dia's het thema van de bestemming gebruiken?**

Gebruik de overload die een bestemmings‑master accepteert. Geef een master uit de bestemmingspresentatie op, niet uit de bron. Aspose.Slides probeert vervolgens elke bron‑dia te koppelen aan een passende lay‑out onder die master.

**Wanneer moet ik een specifieke bestemmings‑lay‑out gebruiken in plaats van een bestemmings‑master?**

Gebruik een specifieke lay‑out wanneer elke geïmporteerde dia één bekende lay‑out moet gebruiken. Gebruik een master wanneer u wilt dat Aspose.Slides kiest uit de lay‑outs van die master op basis van het type of de naam van de bron‑lay‑out.

**Kunnen presentaties met verschillende dia‑groottes worden samengevoegd?**

Ja, maar de dia‑inhoud wordt niet automatisch herontworpen voor de doelafmetingen. Schaal de bron‑presentatie eerst wanneer u voorspelbare plaatsing nodig heeft, bijvoorbeeld met [SlideSize.set_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidesize/set_size/) en [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidesizescaletype/).

**Kan ik PPT, PPTX en ODP presentaties in één bestand samenvoegen?**

Ja. Laad elke bron‑presentatie, kloon de vereiste dia's naar één bestemming, en sla de bestemming op in een ondersteund output‑formaat. Omdat bestandsformaten niet exact dezelfde functionaliteit bieden, controleer complexe content na cross‑format samenvoegingen. Zie [Supported File Formats](/slides/nl/python-net/supported-file-formats/).

**Worden bron‑secties automatisch behouden?**

Niet door een eenvoudige lus die alleen dia's kloont. Maak de benodigde secties in de bestemming aan en gebruik de sectie‑overload van [add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/) wanneer de sectiestructuur behouden moet blijven.

**Worden spreker‑notities en opmerkingen behouden?**

Ze worden gekopieerd met de gekloonde dia. Voor workflows die afhankelijk zijn van notitie‑master‑styling, auteurs van opmerkingen of geneste review‑data, controleer het samengevoegde resultaat omdat die scenario’s zowel presentatieniveau‑structuren als dia‑niveau‑content omvatten.

**Wat gebeurt er met audio, video, OLE‑objecten en hyperlinks?**

Ingesloten content wordt meegenomen als onderdeel van de resource‑relaties van de gekloonde dia. Externe links blijven extern, dus hun doel‑bestanden of URL’s moeten nog steeds beschikbaar zijn na het samenvoegen.

**Zijn ingesloten lettertypen van elke bron gegarandeerd beschikbaar in de samengevoegde presentatie?**

Vertrouw niet uitsluitend op dia‑klonen voor font‑distributie. Inspecteer de ingesloten lettertypen van de bestemming en beheer het insluiten of de beschikbaarheid van externe lettertypen expliciet wanneer typografie belangrijk is.

**Hoe combineer ik een wachtwoord‑beveiligd bestand?**

Open het met het juiste [LoadOptions.password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/password/), kloon vervolgens de dia's zoals gewoonlijk. De output‑beveiliging wordt apart geconfigureerd.

**Hoe moet ik zeer grote presentaties afhandelen?**

Gebruik BLOB‑beheer wanneer grote binaire objecten het geheugenbelast, laad bij voorkeur vanaf bestandspaden voor zeer grote bestanden, sluit bron‑presentaties direct na gebruik, en sla het eindresultaat pas op wanneer nodig.

**Kan ik dia's uit meerdere threads samenvoegen?**

Laad, sla op of kloon geen [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instanties in meerdere threads. Houd elke samenvoegbewerking single‑threaded; gebruik afzonderlijke single‑threaded processen als u onafhankelijke samenvoeg‑taken parallel wilt uitvoeren.