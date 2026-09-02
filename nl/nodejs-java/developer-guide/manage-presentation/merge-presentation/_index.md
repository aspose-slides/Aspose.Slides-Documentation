---
title: Efficiënt Presentaties Samenvoegen in JavaScript
linktitle: Presentaties Samenvoegen
type: docs
weight: 40
url: /nl/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u PowerPoint en OpenDocument presentaties in JavaScript kunt samenvoegen door dia's te klonen, masters en layouts te beheren, dia-inhoud te schalen, secties te behouden en beveiligde of grote bestanden af te handelen."
---
## **Overzicht**

Aspose.Slides voor Node.js via Java voegt presentaties samen door dia's te klonen van één [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) naar een andere. De hoofdoperatie is [SlideCollection.addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), die de opmaak van de bron‑dia kan behouden of de gekloonde dia kan koppelen aan een master of layout in de doelpresentatie.

Dit artikel behandelt de meest voorkomende samenvoeg‑workflows:

- alle dia's samenvoegen terwijl hun bron‑opmaak behouden blijft;
- geselecteerde dia's samenvoegen;
- een master uit de doelpresentatie toepassen;
- een specifieke layout uit de doelpresentatie toepassen;
- verschillende dia‑groottes normaliseren vóór het samenvoegen;
- gekloonde dia's aan een sectie toevoegen;
- meerdere presentaties in één end‑to‑end workflow samenvoegen;
- masters, resources, notities, commentaren, media, lettertypen, wachtwoorden, grote bestanden en multithreading‑aspecten afhandelen.

## **Hoe dia‑klonen masters en layouts beïnvloedt**

Een dia erft een groot deel van zijn uiterlijk van zijn layout en master. Om die reden bepaalt de door jou gekozen overload voor het klonen hoe de samengevoegde dia wordt geïntegreerd in de doelpresentatie.

Gebruik [SlideCollection.addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/) op één van de volgende manieren:

- `addClone(sourceSlide)` — behoudt de layout en opmaak van de bron‑dia. Indien nodig kan de bron‑master automatisch in de doelpresentatie worden gekloond. Aspose.Slides houdt automatisch gekloonde masters bij zodat herhaalde dia’s die dezelfde bron‑master gebruiken die master niet steeds opnieuw klonen.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — koppelt de gekloonde dia aan een specifieke doel‑[MasterSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/). Aspose.Slides zoekt onder die master naar een overeenkomende layout op basis van layouttype of naam.
- `addClone(sourceSlide, destinationLayout)` — koppelt de gekloonde dia direct aan een specifieke doel‑[LayoutSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/).

De master of layout die aan een `addClone`‑overload wordt doorgegeven, moet tot de **doel**‑presentatie behoren, niet tot de bron‑presentatie.

## **Gehele presentaties samenvoegen en bron‑opmaak behouden**

De eenvoudigste manier om te combineren kopieert elke dia van de bron‑presentatie naar de doelpresentatie. Dit is de juiste keuze wanneer de geïmporteerde dia's hun oorspronkelijke thema, master en layout‑relaties moeten behouden.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

De resulterende presentatie kan meerdere masters bevatten wanneer bron‑ en doelpresentatie verschillende ontwerpen gebruiken. Dit is te verwachten wanneer bron‑opmaak bewust wordt behouden.

## **Geselecteerde dia's samenvoegen**

Je hoeft niet elke dia te klonen. Het volgende voorbeeld importeert alleen geselecteerde dia‑indexen uit de bron‑presentatie.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Valideer dia‑indexen vóór het klonen wanneer ze afkomstig zijn van gebruikersinvoer of externe configuratie.

## **Dia's samenvoegen met een doel‑master**

Gebruik de overload [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) wanneer geïmporteerde dia's een master moeten volgen die al tot de doelpresentatie behoort.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides selecteert een passende layout onder de opgegeven master door te zoeken naar een layout met hetzelfde type of dezelfde naam als de bron‑layout. Als er geen geschikte layout bestaat en `allowCloneMissingLayout` is `true`, wordt de bron‑layout gekloond zodat de dia kan worden toegevoegd. Als het `false` is, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxeditexception/) gegooid.

Gebruik `false` wanneer je wilt dat de samenvoeg‑operatie faalt in plaats van een extra layout aan de doel‑master toe te voegen.

## **Dia's samenvoegen met een specifieke doel‑layout**

Gebruik de overload [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) wanneer je precies weet welke doel‑layout de geïmporteerde dia's moeten gebruiken.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Het toepassen van een doel‑layout verandert de geërfde layout‑relatie; het rediseigne de inhoud van de bron‑dia niet. Als de bron‑ en doel‑layouts verschillende placeholder‑structuren hebben, inspecteer dan het resultaat om te bevestigen dat de geërfde opmaak en placeholder‑gedrag passend zijn.

## **Presentaties met verschillende dia‑groottes samenvoegen**

Presentaties met verschillende dia‑afmetingen kunnen worden samengevoegd, maar het klonen van een dia in een presentatie met een andere dia‑grootte rediseint de inhoud niet automatisch voor het nieuwe canvas. Vormen kunnen daardoor verschoven, onverwacht geschaald of buiten het zichtbare dia‑gebied terechtkomen.

Een praktische aanpak is om de bron‑presentatie vóór het klonen te schalen. De methode [SlideSize.setSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) kan bestaande inhoud schalen terwijl de dia‑afmetingen worden aangepast. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesizescaletype/) schaalt de inhoud zodat deze binnen de opgegeven grootte past.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Het schalen wijzigt het bron‑presentatie‑object in het geheugen. Als je de oorspronkelijke bron‑presentatie ongewijzigd wilt houden voor andere bewerkingen, open dan een aparte instantie voor de samenvoeg‑operatie.

## **Dia's in een presentatie‑sectie samenvoegen**

De basis‑dia‑klonlus legt de sectie‑hiërarchie van de bron‑presentatie niet opnieuw aan. Als secties belangrijk zijn in de uitvoer, maak of selecteer dan secties in de doelpresentatie en kloon dia's expliciet in die secties met [addClone(Slide, Section)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

De gekloonde dia's worden toegevoegd aan de opgegeven doel‑sectie. Om meerdere bron‑secties te behouden, doorloop je [Presentation.getSections](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getSections), haal je de huidige dia's van elke bron‑sectie op met [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/section/#getSlidesListOfSection), maak je de secties opnieuw aan in de doel‑presentatie en kloon je elke opgehaalde dia naar de overeenkomstige doel‑sectie. Zie [Manage Slide Sections](/slides/nl/nodejs-java/slide-section/) voor een volledig voorbeeld van sectie‑enumeratie, inclusief lege secties en structurele wijzigingen.

## **Meerdere presentaties veilig samenvoegen**

Het volgende end‑to‑end voorbeeld gebruikt de eerste presentatie als doel, normaliseert de dia‑grootte van elke extra bron, houdt elke bron alleen geopend zolang deze wordt gekopieerd, en slaat het uiteindelijke bestand één keer op.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Dit is een handig startpunt om de bron‑opmaak van geïmporteerde dia's te behouden. Als je uitvoer een enkel doel‑thema moet gebruiken, vervang dan de eenvoudige `addClone(sourceSlide)`‑aanroep door de eerder getoonde overload met doel‑master of doel‑layout.

## **Praktische overwegingen**

### **Masters, layouts en nauwkeurigheid van opmaak**

Standaard dia‑klonen kan automatisch een vereiste bron‑master in de doelpresentatie brengen. Aspose.Slides houdt een intern register bij van automatisch gekloonde masters om te voorkomen dat dezelfde master meerdere keren wordt gekloond. Handmatig gekloonde masters worden niet in dat register bijgehouden, dus vermijd het vooraf klonen van masters tenzij je expliciete controle over de master‑structuur nodig hebt.

Ga er niet van uit dat twee masters of layouts met dezelfde naam visueel gelijk zijn. Als een bedrijfs‑template de uiteindelijke uitstraling moet bepalen, kies dan expliciet een doel‑master of layout en verifieer het resultaat na het samenvoegen.

### **Notities en commentaren**

Sprekersnotities en dia‑commentaren zijn gekoppeld aan de inhoud van de dia en worden gekopieerd wanneer een dia wordt gekloond. Aspose.Slides biedt tevens specifieke API’s voor [presentation notes](/slides/nl/nodejs-java/presentation-notes/) en [presentation comments](/slides/nl/nodejs-java/presentation-comments/).

Als de opmaak van de notitie‑pagina belangrijk is, controleer dan de samengevoegde presentatie omdat notitie‑masters op presentatieniveau objecten zijn en tussen bron‑bestanden kunnen verschillen. Voor review‑workflows controleer ook de auteurs van commentaren en eventuele thread‑commentaren na het combineren van bestanden van verschillende auteurs of templates.

### **Afbeeldingen, audio, video, OLE‑objecten en externe koppelingen**

Dia's kunnen refereren naar resources op presentatieniveau, zoals afbeeldingen, ingebedde audio, ingebedde video en OLE‑data. Kloon de volledige dia in plaats van alleen de zichtbare vormen zodat Aspose.Slides de relaties van de dia met haar resources kan behouden.

Ingebedde en gekoppelde resources moeten verschillend worden behandeld. Een gekoppelde audio, video, OLE‑object of hyperlink blijft afhankelijk van het externe doel; het klonen van een dia maakt van een externe link geen ingebedde inhoud. Test paden en URL’s van gekoppelde resources in de omgeving waarin de samengevoegde presentatie geopend wordt.

Aspose.Slides houdt automatisch gekloonde masters bij, maar dit vormt geen algemene garantie dat identieke binaire resources uit verschillende bron‑presentaties altijd worden gede‑dubleerd. Als de omvang van het output‑bestand belangrijk is, inspecteer dan het samengevoegde pakket en meet het resultaat in plaats van te vertrouwen op impliciete deduplicatie.

### **Ingebedde lettertypen en beschikbaarheid**

Lettertypen worden op presentatieniveau beheerd. Als typografie consistent moet blijven over verschillende machines, ga er niet van uit dat het klonen van dia's alleen garandeert dat elk vereist lettertype beschikbaar is in de doelomgeving. Je kunt ingebedde lettertypen inspecteren met [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) en het inbedden expliciet beheren zoals beschreven in [Embed Fonts in Presentations](/slides/nl/nodejs-java/embedded-font/).

Controleer ook of je toestemming hebt om de lettertypen die in de bron‑bestanden worden gebruikt, in te bedden. Licenties kunnen het inbedden beperken.

### **Wachtwoord‑beveiligde presentaties**

Een bron die met een wachtwoord beveiligd is, moet succesvol worden geopend voordat de dia's kunnen worden gekloond. Geef het wachtwoord door via [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Werk met de ontcijferde presentatie.
} finally {
    source.dispose();
}
```

Het openen van een versleutelde bron past de bescherming niet automatisch toe op de doelpresentatie. Configureer de output‑beveiliging apart wanneer dat nodig is.

### **Grote presentaties en geheugengebruik**

Grote presentaties met hoge‑resolutie‑afbeeldingen, audio, video of andere omvangrijke binaire objecten kunnen aanzienlijk veel geheugen verbruiken. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) biedt instellingen voor BLOB‑afhandeling en tijdelijk‑bestand gebruik. Zie [Manage Presentation BLOBs](/slides/nl/nodejs-java/manage-blob/) voor strategieën met grote bestanden.

Voor grote bestanden kun je het liefst laden vanaf bestandspaden, elke bron‑presentatie zo snel mogelijk vrijgeven nadat deze is samengevoegd, en vermijden dat tussenresultaten herhaaldelijk worden opgeslagen tenzij de workflow checkpoints vereist.

### **Thread‑veiligheid**

Laad, sla op of kloon een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instantie niet in meerdere threads. Deze bewerkingen worden niet ondersteund voor multithreaded gebruik. Als je onafhankelijk samenvoeg‑taken wilt paralleliseren, gebruik dan meerdere single‑threaded processen, elk met hun eigen presentaties, en volg de [Aspose.Slides multithreading‑richtlijnen](/slides/nl/nodejs-java/multithreading/).

## **FAQ**

**Hoe behoud ik het oorspronkelijke ontwerp van elke bron‑presentatie?**

Gebruik [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) zonder een doel‑master of layout op te geven. Aspose.Slides kan de bron‑master automatisch klonen wanneer deze nodig is voor de geïmporteerde dia.

**Hoe laat ik geïmporteerde dia's het doel‑thema gebruiken?**

Gebruik de overload die een doel‑master accepteert. Geef een master uit de doelpresentatie op, niet uit de bron. Aspose.Slides probeert elke bron‑dia te koppelen aan een passende layout onder die master.

**Wanneer moet ik een specifieke doel‑layout gebruiken in plaats van een doel‑master?**

Gebruik een specifieke layout wanneer iedere geïmporteerde dia één bekende layout moet gebruiken. Gebruik een master wanneer je wilt dat Aspose.Slides een passende layout onder die master selecteert op basis van het type of de naam van de bron‑layout.

**Kunnen presentaties met verschillende dia‑groottes worden samengevoegd?**

Ja, maar de inhoud van de dia wordt niet automatisch herontworpen voor de nieuwe afmetingen. Schaal de bron‑presentatie eerst wanneer je voorspelbare plaatsing nodig hebt, bijvoorbeeld met [SlideSize.setSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) en [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesizescaletype/).

**Kan ik PPT, PPTX en ODP presentaties in één bestand samenvoegen?**

Ja. Laad elke bron‑presentatie, kloon de benodigde dia's in één doel‑presentatie en sla de doel‑presentatie op in een ondersteund uitvoerformaat. Omdat presentaties verschillende functieverzamelingen hebben, controleer je complexe inhoud na een cross‑format samenvoeging. Zie [Supported File Formats](/slides/nl/nodejs-java/supported-file-formats/).

**Worden bron‑secties automatisch behouden?**

Niet door een eenvoudige lus die alleen dia's kloont. Maak de vereiste secties opnieuw aan in de doel‑presentatie en gebruik de sectie‑overload van [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) wanneer de sectiestructuur behouden moet blijven.

**Worden sprekersnotities en commentaren behouden?**

Ze worden meegekopieerd met de gekloonde dia. Voor workflows die afhankelijk zijn van notitie‑master‑styling, commentaarauteurs of thread‑review‑data, controleer je het samengevoegde resultaat omdat die scenario's zowel presentatieniveau‑structuren als dia‑inhoud betreffen.

**Wat gebeurt er met audio, video, OLE‑objecten en hyperlinks?**

Ingebedde inhoud wordt meegenomen als onderdeel van de resource‑relaties van de gekloonde dia. Externe links blijven extern, dus hun doel‑bestanden of URL’s moeten nog steeds beschikbaar zijn na het samenvoegen.

**Zijn ingebedde lettertypen van elke bron gegarandeerd beschikbaar in de samengevoegde presentatie?**

Vertrouw niet alleen op dia‑klonen voor lettertype‑distributie. Inspecteer de ingebedde lettertypen van de doel‑presentatie en beheer het inbedden of de beschikbaarheid van externe lettertypen expliciet wanneer typografie belangrijk is.

**Hoe merge ik een wachtwoord‑beveiligd bestand?**

Open het met de juiste [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), kloon vervolgens de dia's normaal. De bescherming van de output wordt apart geconfigureerd.

**Hoe ga ik om met zeer grote presentaties?**

Gebruik BLOB‑beheer wanneer grote binaire objecten veel geheugen verbruiken, laad bij zeer grote bestanden bij voorkeur via bestandspaden, maak bron‑presentaties direct vrij na het samenvoegen, en sla het eindresultaat alleen op wanneer nodig.

**Kan ik dia's vanuit meerdere threads samenvoegen?**

Laad, sla op of kloon geen presentatie‑instanties in meerdere threads. Voor parallelle merge‑taken gebruik je aparte single‑threaded processen met onafhankelijke presentatie‑instanties.