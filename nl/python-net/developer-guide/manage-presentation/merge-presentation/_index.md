---
title: Efficiënt presentaties samenvoegen met Python
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
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties in Python kunt samenvoegen door dia's te klonen, masters en layouts te beheersen, dia-inhoud te herschalen, secties te behouden en beveiligde of grote bestanden af te handelen."
---
## **Overzicht**

Aspose.Slides for Python via .NET voegt presentaties samen door dia's te klonen van één [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) naar een andere. De belangrijkste bewerking is [SlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/), die de opmaak van de brondia kan behouden of de gekloonede dia kan koppelen aan een master of lay-out in de doelpresentatie.

Dit artikel behandelt de meest voorkomende samenvoeg‑workflows:

- alle dia's samenvoegen terwijl hun bronopmaak behouden blijft;
- geselecteerde dia's samenvoegen;
- een master uit de doelpresentatie toepassen;
- een specifieke lay-out uit de doelpresentatie toepassen;
- verschillende dia‑groottes normaliseren vóór het samenvoegen;
- gekloonede dia's toevoegen aan een sectie;
- meerdere presentaties samenvoegen in één end‑to‑end workflow;
- masters, bronnen, notities, opmerkingen, media, lettertypen, wachtwoorden, grote bestanden en multithreading‑aspecten afhandelen.

## **Hoe Slide‑Klonen Masters en Layouts Beïnvloedt**

Een dia erft een groot deel van zijn uiterlijk van zijn lay-out en master. Om die reden bepaalt de overload van het klonen die je kiest hoe de samengevoegde dia wordt geïntegreerd in de doelpresentatie.

Gebruik [SlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/) op één van de volgende manieren:

- `add_clone(source_slide)` — behoud de lay-out en opmaak van de brondia. Indien nodig kan de bronslave automatisch worden gekloneerd naar de doelpresentatie. Aspose.Slides houdt automatisch gekloonede masters bij zodat herhaalde dia's die dezelfde bron‑master gebruiken die master niet telkens opnieuw worden gekloond.
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — koppel de gekloonede dia aan een specifieke doel‑[IMasterSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imasterslide/). Aspose.Slides zoekt naar een overeenkomende lay-out onder die master op basis van lay‑outtype of naam.
- `add_clone(source_slide, destination_layout)` — koppel de gekloonede dia direct aan een specifieke doel‑[ILayoutSlide](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ilayoutslide/).

De master of lay‑out die aan een `add_clone`‑overload wordt doorgegeven, moet behoren tot de **doel**‑presentatie, niet tot de bronpresentatie.

## **Hele Presentaties Samenvoegen en Bronopmaak Behouden**

De eenvoudigste samenvoeging kopieert elke dia van de bronpresentatie naar de doelpresentatie. Dit is de juiste keuze wanneer de geïmporteerde dia's hun oorspronkelijke thema, master en lay‑outrelaties moeten behouden.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

De resulterende presentatie kan meerdere masters bevatten wanneer bron‑ en doelpresentatie verschillende ontwerpen gebruiken. Dit is normaal wanneer bronopmaak bewust behouden wordt.

## **Geselecteerde Dia's Samenvoegen**

Je hoeft niet elke dia te klonen. Het volgende voorbeeld importeert alleen de geselecteerde dia‑indexen uit de bronpresentatie.

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

## **Dia's Samenvoegen Met Een Doel‑Master**

Gebruik de overload [add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/) wanneer geïmporteerde dia's een master moeten volgen die al tot de doelpresentatie behoort.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides selecteert een passende lay‑out onder de opgegeven master door de bron‑lay‑outtype of -naam te matchen. Als er geen geschikte lay‑out bestaat en `allow_clone_missing_layout` is `True`, wordt de bron‑lay‑out gekloond zodat de dia kan worden toegevoegd. Als het `False` is, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pptxeditexception/) gegooid.

Gebruik `False` wanneer je wilt dat de samenvoeging faalt in plaats van een extra lay‑out aan de doel‑master toe te voegen.

## **Dia's Samenvoegen Met Een Specifieke Doel‑Lay‑out**

Gebruik de overload [add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/) wanneer je exact weet welke doel‑lay‑out de geïmporteerde dia's moeten gebruiken.

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

Het toepassen van een doel‑lay‑out wijzigt de geërfde lay‑outrelatie; het ontwerpt de inhoud van de bron‑dia niet opnieuw. Als bron‑ en doel‑lay‑outs verschillende placeholder‑structuren hebben, controleer dan het resultaat om te bevestigen dat de overgeërfde opmaak en placeholder‑gedrag correct zijn.

## **Presentaties Met Verschillende Dia‑Grootten Samenvoegen**

Presentaties met verschillende dia‑afmetingen kunnen worden samengevoegd, maar het klonen van een dia naar een presentatie met een andere dia‑grootte ontwerpt de inhoud niet automatisch opnieuw voor het nieuwe canvas. Vormen kunnen daardoor verschoven, onverwacht geschaald of buiten het zichtbare dia‑gebied terechtkomen.

Een praktische aanpak is om de bronpresentatie vóór het klonen te resize‑n. De methode [SlideSize.set_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidesize/set_size/) kan bestaande inhoud schalen terwijl de dia‑afmetingen worden gewijzigd. [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidesizescaletype/) schaalt de inhoud zodat deze binnen de gewenste grootte past.

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

Resizen wijzigt het bron‑presentatie‑object in het geheugen. Als je de originele bronpresentatie ongewijzigd wilt houden voor andere bewerkingen, open dan een aparte instantie voor de samenvoeging.

## **Dia's Samenvoegen Naar Een Presentatie‑Sectie**

De basis‑dia‑klonlus recreëert de sectie‑hiërarchie van de bronpresentatie niet. Als secties van belang zijn in de uitvoer, maak of selecteer dan secties in de doelpresentatie en kloon dia's expliciet erin met [SlideCollection.add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/).

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

De gekloonede dia's worden toegevoegd aan de opgegeven doel‑sectie. Om meerdere bron‑secties te behouden, recreateer die secties in de doelpresentatie met [SectionCollection.append_empty_section](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sectioncollection/append_empty_section/) en map elke bron‑dia naar de overeenkomstige doel‑sectie.

## **Meerdere Presentaties Veilig Samenvoegen**

Het volgende end‑to‑end voorbeeld gebruikt de eerste presentatie als doel, normaliseert de dia‑grootte van elke extra bron, houdt elke bron alleen open zolang deze wordt gekopieerd, en slaat het uiteindelijke bestand één keer op.

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

Dit is een nuttige basis voor het behouden van de bron‑opmaak van geïmporteerde dia's. Als je uitvoer een enkel doel‑thema moet gebruiken, vervang dan de eenvoudige `add_clone(slide)`‑aanroep door de eerder getoonde doel‑master‑ of doel‑lay‑out‑overload.

## **Praktische Overwegingen**

### **Masters, Lay‑outs en Opmaak‑Nauwkeurigheid**

Standaard dia‑klonen kan automatisch een benodigde bron‑master naar de doelpresentatie brengen. Aspose.Slides houdt een interne register bij voor automatisch gekloonede masters om te voorkomen dat dezelfde master meerdere keren wordt gekloond. Handmatig gekloonede masters worden niet bijgehouden door dat register, dus vermijd voor‑clonen van masters tenzij je expliciete controle over de master‑structuur nodig hebt.

Ga er niet van uit dat twee masters of lay‑outs met dezelfde naam visueel gelijk zijn. Als een bedrijfs‑template de uiteindelijke weergave moet bepalen, kies dan expliciet een doel‑master of -lay‑out en verifieer het resultaat na het samenvoegen.

### **Notities en Opmerkingen**

Spreker‑notities en dia‑commentaren zijn gekoppeld aan de dia‑inhoud en worden gekopieerd wanneer een dia wordt gekloond. Aspose.Slides biedt ook specifieke API’s voor [presentation notes](https://docs.aspose.com/slides/nl/python-net/presentation-notes/) en [presentation comments](https://docs.aspose.com/slides/nl/python-net/presentation-comments/).

Als de opmaak van de notitie‑pagina belangrijk is, controleer dan de samengevoegde presentatie omdat notitie‑masters presentatieniveau‑objecten zijn en kunnen verschillen tussen bronbestanden. Voor review‑workflows, controleer ook auteurs van opmerkingen en geneste commentaren nadat bestanden van verschillende auteurs of templates zijn gecombineerd.

### **Afbeeldingen, Audio, Video, OLE‑objecten en Externe Links**

Dia's kunnen verwijzen naar presentatieniveau‑bronnen zoals afbeeldingen, ingesloten audio, ingesloten video en OLE‑data. Kloon de dia zelf in plaats van alleen de zichtbare vormen zodat Aspose.Slides de relaties van de dia met zijn bronnen kan behouden.

Ingesloten en gelinkte bronnen moeten verschillend behandeld worden. Een gelinkte audio, video, OLE‑object of hyperlink blijft afhankelijk van zijn externe doel; het klonen van een dia verandert een externe link niet in ingesloten inhoud. Test gelinkte‑bron‑paden en URL‑s in de omgeving waarin de samengevoegde presentatie wordt geopend.

Aspose.Slides houdt automatisch gekloonede masters bij, maar dit moet niet worden gezien als een algemene garantie dat identieke binaire bronnen van verschillende bron‑presentaties altijd worden gededupliceerd. Als de grootte van het uitvoerbestand belangrijk is, inspecteer dan het samengevoegde pakket en meet het resultaat in plaats van te vertrouwen op impliciete deduplicatie.

### **Ingesloten Lettertypen en Beschikbaarheid van Lettertypen**

Lettertypen worden op presentatieniveau beheerd. Als typografie consistent moet blijven over machines, ga er niet van uit dat alleen dia‑klonen garandeert dat elk vereist lettertype beschikbaar is in de doelomgeving. Je kunt ingesloten lettertypen inspecteren met [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) en het insluiten expliciet beheren zoals beschreven in [Embed Fonts in Presentations](https://docs.aspose.com/slides/nl/python-net/embedded-font/).

Controleer ook of je toestemming hebt om de lettertypen die in de bronbestanden worden gebruikt in te sluiten. Lettertype‑licenties kunnen insluiten beperken.

### **Wachtwoord‑Beveiligde Presentaties**

Een wachtwoord‑beveiligde bron moet eerst succesvol worden geopend voordat de dia's kunnen worden gekloond. Lever het wachtwoord via [LoadOptions.password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/password/).

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

Het openen van een versleutelde bron past de bescherming niet automatisch toe op de doelpresentatie. Configureer uitvoerbeveiliging apart wanneer dat nodig is.

### **Grote Presentaties en Geheugengebruik**

Grote presentaties met hoge‑resolutie‑afbeeldingen, audio, video of andere grote binaire objecten kunnen veel geheugen verbruiken. [LoadOptions.blob_management_options](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/blob_management_options/) biedt controle over BLOB‑afhandeling en tijdelijk‑bestandgebruik. Zie [Manage Presentation BLOBs](https://docs.aspose.com/slides/nl/python-net/manage-blob/) voor strategieën voor grote bestanden.

Voor grote bestanden, laad bij voorkeur via bestandspaden, sluit elke bron‑presentatie zodra deze is samengevoegd, en vermijd herhaaldelijk opslaan van tussentijdse resultaten tenzij het workflow‑scenario checkpoints vereist. Het gebruik van `with slides.Presentation(...)` zorgt ervoor dat presentatieresources worden vrijgegeven wanneer de context wordt verlaten.

### **Thread‑Veiligheid**

Laad, sla op of kloon een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instantie niet gelijktijdig vanuit meerdere threads. Houd elke samenvoeg‑operatie enkel‑threaded. Als je onafhankelijke samenvoeg‑taken paralleliseert, gebruik dan aparte enkel‑threaded processen en onafhankelijke presentatiedinstanties zoals beschreven in de [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/nl/python-net/multithreading/).

## **FAQ**

**Hoe behoud ik het originele ontwerp van elke bronpresentatie?**

Gebruik [`add_clone(source_slide)`](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/) zonder een doel‑master of -lay‑out op te geven. Aspose.Slides kan de bron‑master automatisch klonen wanneer deze nodig is voor de geïmporteerde dia.

**Hoe laat ik geïmporteerde dia's het doel‑thema gebruiken?**

Gebruik de overload die een doel‑master accepteert. Geef een master uit de doelpresentatie door, niet uit de bron. Aspose.Slides probeert elke bron‑dia te koppelen aan een passende lay‑out onder die master.

**Wanneer moet ik een specifieke doel‑lay‑out gebruiken in plaats van een doel‑master?**

Gebruik een specifieke lay‑out wanneer elke geïmporteerde dia één bekende lay‑out moet gebruiken. Gebruik een master wanneer je wilt dat Aspose.Slides kiest uit de lay‑outs van die master op basis van het bron‑lay‑outtype of -naam.

**Kunnen presentaties met verschillende dia‑groottes worden samengevoegd?**

Ja, maar de dia‑inhoud wordt niet automatisch opnieuw ontworpen voor de doel‑dimensies. Resize de bronpresentatie eerst wanneer je voorspelbare plaatsing nodig hebt, bijvoorbeeld met [SlideSize.set_size](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidesize/set_size/) en [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidesizescaletype/).

**Kan ik PPT, PPTX en ODP‑presentaties in één bestand samenvoegen?**

Ja. Laad elke bronpresentatie, kloon de vereiste dia's naar één doelpresentatie en sla de doelpresentatie op in een ondersteund uitvoerformaat. Omdat presentaties verschillende functionaliteiten bieden, controleer complexe inhoud na cross‑format samenvoegingen. Zie [Supported File Formats](https://docs.aspose.com/slides/nl/python-net/supported-file-formats/).

**Worden bron‑secties automatisch behouden?**

Nee, niet door een eenvoudige lus die alleen dia's kloont. Maak de benodigde secties in de doelpresentatie opnieuw aan en gebruik de sectie‑overload van [add_clone](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/add_clone/) wanneer de sectiestructuur behouden moet blijven.

**Worden speaker‑notes en opmerkingen behouden?**

Ze worden meegekopieerd met de gekloonede dia. Voor workflows die afhankelijk zijn van notitie‑master‑styling, commentauteur‑informatie of geneste review‑data, controleer het samengevoegde resultaat omdat deze scenario's zowel presentatieniveau‑structuren als dia‑niveau‑inhoud betreffen.

**Wat gebeurt er met audio, video, OLE‑objecten en hyperlinks?**

Ingesloten inhoud wordt meegenomen als onderdeel van de gekloonede dia‑resource‑relaties. Externe links blijven extern, dus hun doel‑bestanden of URL‑s moeten nog steeds beschikbaar zijn na de samenvoeging.

**Zijn ingesloten lettertypen van elke bron gegarandeerd aanwezig in de samengevoegde presentatie?**

Vertrouw niet alleen op dia‑klonen voor lettertype‑distributie. Inspecteer de ingesloten lettertypen van de doelpresentatie en beheer het insluiten of de beschikbaarheid van externe lettertypen expliciet wanneer typografie belangrijk is.

**Hoe merge ik een wachtwoord‑beveiligd bestand?**

Open het met het juiste [LoadOptions.password](https://reference.aspose.com/slides/nl/python-net/aspose.slides/loadoptions/password/), kloon daarna de dia's normaal. Uitvoerbeveiliging wordt apart geconfigureerd.

**Hoe moet ik erg grote presentaties afhandelen?**

Gebruik BLOB‑beheer wanneer grote binaire objecten het geheugengebruik domineren, laad bij zeer grote bestanden bij voorkeur via bestandspad, sluit bron‑presentaties snel en sla het eindresultaat alleen op wanneer nodig.

**Kan ik dia's vanuit meerdere threads samenvoegen?**

Laad, sla op of kloon geen [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑instanties in meerdere threads. Houd elke samenvoeg‑operatie enkel‑threaded; gebruik onafhankelijke enkel‑threaded processen als je afzonderlijke merge‑taken wilt paralleliseren.