---
title: Presentaties efficiënt samenvoegen in JavaScript
linktitle: Presentaties samenvoegen
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
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties in JavaScript kunt samenvoegen door dia's te klonen, masters en lay-outs te beheren, de inhoud van dia's te schalen, secties te behouden en beveiligde of grote bestanden te verwerken."
---
## **Overzicht**

Aspose.Slides for Node.js via Java voegt presentaties samen door dia's van één [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/) te klonen naar een andere. De hoofdoperatie is [SlideCollection.addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), die de opmaak van de bron‑dia kan behouden of de gekloonde dia kan koppelen aan een master of lay‑out in de doelpresentatie.

Dit artikel behandelt de meest voorkomende workflows voor samenvoegen:

- voeg alle dia's samen terwijl hun bronopmaak behouden blijft;
- voeg geselecteerde dia's samen;
- pas een master toe uit de doelpresentatie;
- pas een specifieke lay‑out toe uit de doelpresentatie;
- normaliseer verschillende dia‑groottes vóór het samenvoegen;
- voeg gekloonde dia's toe aan een sectie;
- voeg meerdere presentaties samen in één end‑to‑end workflow;
- behandel masters, resources, notities, opmerkingen, media, lettertypen, wachtwoorden, grote bestanden en multithreading‑kwesties.

## **Hoe dia‑klonen masters en lay‑outs beïnvloedt**

Een dia erft een groot deel van zijn uiterlijk van zijn lay‑out en master. Om die reden bepaalt de door u gekozen overload van het klonen hoe de samengevoegde dia in de doelpresentatie wordt geïntegreerd.

Gebruik [SlideCollection.addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/) op één van de volgende manieren:

- `addClone(sourceSlide)` — behoudt de lay‑out en opmaak van de bron‑dia. Indien nodig kan de bron‑master automatisch in de doelpresentatie worden gekloond. Aspose.Slides houdt automatisch gekloonde masters bij zodat herhaalde dia's die dezelfde bron‑master gebruiken die master niet telkens opnieuw klonen.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — koppelt de gekloonde dia aan een specifieke doel-[MasterSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/). Aspose.Slides zoekt onder die master naar een overeenkomende lay‑out op basis van lay‑outtype of -naam.
- `addClone(sourceSlide, destinationLayout)` — koppelt de gekloonde dia rechtstreeks aan een specifieke doel-[LayoutSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/).

De master of lay‑out die aan een `addClone`‑overload wordt doorgegeven, moet behoren tot de **doel**‑presentatie, niet tot de bron‑presentatie.

## **Volledige presentaties samenvoegen en bronopmaak behouden**

De eenvoudigste samenvoeging kopieert elke dia van de bron‑presentatie naar de doel‑presentatie. Dit is de juiste keuze wanneer de geïmporteerde dia's hun oorspronkelijke thema, master en lay‑outrelaties moeten behouden.

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

De resulterende presentatie kan meerdere masters bevatten wanneer bron‑ en doelpresentatie verschillende ontwerpen gebruiken. Dit is te verwachten wanneer de bron‑opmaak opzettelijk behouden blijft.

## **Geselecteerde dia's samenvoegen**

U hoeft niet elke dia te klonen. Het volgende voorbeeld importeert alleen geselecteerde dia‑indexen uit de bron‑presentatie.

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

Valideer dia‑indexen vóór het klonen wanneer ze afkomstig zijn van gebruikersinvoer of een externe configuratie.

## **Dia's samenvoegen met een doel‑master**

Gebruik de [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) overload wanneer geïmporteerde dia's een master moeten volgen die al tot de doel‑presentatie behoort.

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

Aspose.Slides selecteert een passende lay‑out onder de opgegeven master door het type of de naam van de bron‑lay‑out te vergelijken. Als er geen geschikte lay‑out bestaat en `allowCloneMissingLayout` `true` is, wordt de bron‑lay‑out gekloond zodat de dia kan worden toegevoegd. Als deze `false` is, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pptxeditexception/) gegooid.

Gebruik `false` wanneer u wilt dat de samenvoeging faalt in plaats van een extra lay‑out aan de doel‑master toe te voegen.

## **Dia's samenvoegen met een specifieke doel‑lay‑out**

Gebruik de [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) overload wanneer u precies weet welke doel‑lay‑out de geïmporteerde dia's moeten gebruiken.

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

Het toepassen van een doel‑lay‑out wijzigt de geërfde lay‑outrelatie; het herontwerpt de inhoud van de bron‑dia niet. Als de bron‑ en doel‑lay‑outs verschillende placeholder‑structuren hebben, inspecteer dan het resultaat om te bevestigen dat de geërfde opmaak en placeholder‑gedrag passend zijn.

## **Presentaties met verschillende dia‑groottes samenvoegen**

Presentaties met verschillende dia‑afmetingen kunnen worden samengevoegd, maar het klonen van een dia naar een presentatie met een andere dia‑grootte herziet de inhoud niet automatisch voor het nieuwe canvas. Vormen kunnen daarom verschoven, onverwacht geschaald of buiten het zichtbare dia‑gebied verschijnen.

Een praktische aanpak is om de bron‑presentatie vóór het klonen te schalen. De methode [SlideSize.setSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) kan bestaande inhoud schalen terwijl de dia‑afmetingen worden aangepast. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesizescaletype/) schaalt de inhoud zodat deze binnen de gewenste afmeting past.

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

Schalen wijzigt het bron‑presentatie‑object in het geheugen. Als u de originele bron‑presentatie ongewijzigd wilt houden voor andere bewerkingen, open dan een aparte instantie voor de samenvoeging.

## **Dia's samenvoegen in een presentatiesectie**

De basis‑dia‑klonen‑lus maakt de sectie‑hiërarchie van de bron‑presentatie niet opnieuw aan. Als secties belangrijk zijn in de output, maak of selecteer dan secties in de doel‑presentatie en kloon dia's er expliciet in met [addClone(Slide, Section)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

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

De gekloonde dia's worden aan de opgegeven doel‑sectie toegevoegd. Om meerdere bron‑secties te behouden, maak die secties opnieuw aan in de doel‑presentatie en koppel elke bron‑dia aan de overeenkomstige doel‑sectie.

## **Meerdere presentaties veilig samenvoegen**

Het volgende end‑to‑end‑voorbeeld gebruikt de eerste presentatie als doel, normaliseert de dia‑grootte van elke extra bron, houdt elke bron alleen geopend zolang die gekopieerd wordt, en slaat het uiteindelijke bestand één keer op.

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

Dit is een handige basis om de bron‑opmaak van geïmporteerde dia's te behouden. Als uw output een enkel doel‑thema moet gebruiken, vervang dan de eenvoudige `addClone(sourceSlide)`‑aanroep door de eerder getoonde passende doel‑master‑ of doel‑lay‑overload.

## **Praktische overwegingen**

### **Masters, lay‑outs en opmaak‑fideliteit**

Standaard dia‑klonen kan automatisch een vereiste bron‑master in de doel‑presentatie brengen. Aspose.Slides houdt een interne registratie bij voor automatisch gekloonde masters om te voorkomen dat dezelfde master herhaaldelijk wordt gekloond. Handmatig gekloonde masters worden niet bijgehouden in die registratie, dus vermijd het vooraf klonen van masters tenzij u expliciete controle over de master‑structuur nodig hebt.

Ga er niet vanuit dat twee masters of lay‑outs met dezelfde naam visueel gelijk zijn. Als een corporate‑template de uiteindelijke weergave moet bepalen, kies dan expliciet een doel‑master of lay‑out en verifieer het resultaat na het samenvoegen.

### **Notities en opmerkingen**

Sprekersnotities en dia‑opmerkingen zijn gekoppeld aan de dia‑inhoud en worden gekopieerd wanneer een dia wordt gekloond. Aspose.Slides biedt ook speciale API's voor [presentation notes](https://docs.aspose.com/slides/nl/nodejs-java/presentation-notes/) en [presentation comments](https://docs.aspose.com/slides/nl/nodejs-java/presentation-comments/).

Als de opmaak van de notitie‑pagina belangrijk is, controleer dan de samengevoegde presentatie omdat notitie‑masters objecten op presentatie‑niveau zijn en kunnen verschillen tussen bron‑bestanden. Voor review‑workflows verifieer ook de auteurs van opmerkingen en thread‑opmerkingen na het combineren van bestanden van verschillende auteurs of templates.

### **Afbeeldingen, audio, video, OLE‑objecten en externe koppelingen**

Dia's kunnen refereren aan resources op presentatieniveau zoals afbeeldingen, ingebedde audio, ingebedde video en OLE‑data. Kloon de dia zelf in plaats van alleen de zichtbare objecten te kopiëren zodat Aspose.Slides de relaties van de dia met haar resources kan behouden.

Ingebedde en gekoppelde resources moeten verschillend behandeld worden. Een gekoppelde audio, video, OLE‑object of hyperlink blijft afhankelijk van het externe doel; het klonen van een dia maakt van een externe link geen ingebedde inhoud. Test paden en URL's van gekoppelde resources in de omgeving waarin de samengevoegde presentatie wordt geopend.

Aspose.Slides houdt expliciet automatisch gekloonde masters bij, maar dit moet niet worden gezien als een algemene garantie dat identieke binaire resources uit niet‑gerelateerde bron‑presentaties altijd worden gededupliceerd. Als de grootte van het uitvoerbestand belangrijk is, inspecteer dan het samengevoegde pakket en meet het resultaat in plaats van te vertrouwen op impliciete deduplicatie.

### **Ingebedde lettertypen en beschikbaarheid van lettertypen**

Lettertypen worden beheerd op presentatieniveau. Als typografie consistent moet blijven over verschillende machines, ga er niet van uit dat het alleen klonen van dia's garandeert dat elk vereist lettertype beschikbaar is in de doelomgeving. U kunt ingebedde lettertypen inspecteren met [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) en het inbedden expliciet beheren zoals beschreven in [Embed Fonts in Presentations](https://docs.aspose.com/slides/nl/nodejs-java/embedded-font/).

Controleer ook of u toestemming heeft om de lettertypen die in de bron‑bestanden worden gebruikt in te bedden. Lettertype‑licenties kunnen het inbedden beperken.

### **Wachtwoord‑beveiligde presentaties**

Een wachtwoord‑beveiligde bron moet succesvol worden geopend voordat de dia's kunnen worden gekloond. Geef het wachtwoord door via [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Werk met de ontsleutelde presentatie.
} finally {
    source.dispose();
}
```

Het openen van een versleutelde bron brengt de bescherming niet automatisch over op de doel‑presentatie. Stel de uitvoerbeveiliging apart in wanneer nodig.

### **Grote presentaties en geheugengebruik**

Grote presentaties met hoge‑resolutie‑afbeeldingen, audio, video of andere grote binaire objecten kunnen veel geheugen verbruiken. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) biedt controle over BLOB‑afhandeling en het gebruik van tijdelijke bestanden. Zie [Manage Presentation BLOBs](https://docs.aspose.com/slides/nl/nodejs-java/manage-blob/) voor strategieën voor grote bestanden.

Voor grote bestanden, laad bij voorkeur vanaf bestandspaden, ruim elke bron‑presentatie op zodra deze is samengevoegd, en vermijd herhaaldelijk opslaan van tussentijdse resultaten tenzij de workflow checkpoints vereist.

### **Thread‑veiligheid**

Laad, sla op of kloon een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instantie niet in meerdere threads. Deze bewerkingen worden niet ondersteund voor multithreaded gebruik. Als u onafhankelijke samenvoeg‑taken moet paralleliseren, gebruik dan meerdere single‑threaded processen, elk met eigen presentatietinstanties, en volg de [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/nl/nodejs-java/multithreading/).

## **FAQ**

**Hoe houd ik het originele ontwerp van elke bron‑presentatie behouden?**

Gebruik [`addClone(sourceSlide)`](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) zonder een doel‑master of lay‑out op te geven. Aspose.Slides kan de bron‑master automatisch klonen wanneer deze door de geïmporteerde dia nodig is.

**Hoe laat ik geïmporteerde dia's het doel‑thema gebruiken?**

Gebruik de overload die een doel‑master accepteert. Geef een master uit de doel‑presentatie door, niet uit de bron. Aspose.Slides zal proberen elke bron‑dia aan een geschikte lay‑out onder die master te koppelen.

**Wanneer moet ik een specifieke doel‑lay‑out gebruiken in plaats van een doel‑master?**

Gebruik een specifieke lay‑out wanneer elke geïmporteerde dia één bekende lay‑out moet gebruiken. Gebruik een master wanneer u wilt dat Aspose.Slides een lay‑out uit die master selecteert op basis van het type of de naam van de bron‑lay‑out.

**Kunnen presentaties met verschillende dia‑groottes worden samengevoegd?**

Ja, maar de dia‑inhoud wordt niet automatisch herontworpen voor de afmetingen van de bestemming. Schaal de bron‑presentatie eerst wanneer u een voorspelbare plaatsing nodig heeft, bijvoorbeeld met [SlideSize.setSize](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) en [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidesizescaletype/).

**Kan ik PPT-, PPTX- en ODP‑presentaties in één bestand samenvoegen?**

Ja. Laad elke bron‑presentatie, kloon de benodigde dia's naar één bestemming, en sla de bestemming op in een ondersteund uitvoerformaat. Omdat presentatieformaten niet exact dezelfde functionaliteit bieden, controleer complexe inhoud na cross‑format samenvoegingen. Zie [Supported File Formats](https://docs.aspose.com/slides/nl/nodejs-java/supported-file-formats/).

**Worden bron‑secties automatisch behouden?**

Niet door een basale lus die alleen dia's kloont. Maak de vereiste secties opnieuw aan in de bestemming en gebruik de sectie‑overload van [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) wanneer de sectiestructuur behouden moet blijven.

**Worden sprekersnotities en opmerkingen behouden?**

Ze worden mee gekopieerd met de gekloonde dia. Voor workflows die afhankelijk zijn van notitie‑master‑styling, auteurs van opmerkingen of thread‑reviewdata, controleer het samengevoegde resultaat omdat deze scenario's zowel presentatieniveau‑ als dia‑niveau‑structuren betreffen.

**Wat gebeurt er met audio, video, OLE‑objecten en hyperlinks?**

Ingebedde inhoud wordt meegenomen als onderdeel van de resource‑relaties van de gekloonde dia. Externe links blijven extern, dus hun doel‑bestanden of URL's moeten nog steeds beschikbaar zijn na de samenvoeging.

**Zijn ingebedde lettertypen van elke bron gegarandeerd beschikbaar in de samengevoegde presentatie?**

Vertrouw niet alleen op dia‑klonen voor lettertype‑distributie. Inspecteer de ingebedde lettertypen van de bestemming en beheer het inbedden van lettertypen of de beschikbaarheid van externe lettertypen expliciet wanneer typografie belangrijk is.

**Hoe voeg ik een wachtwoord‑beveiligd bestand samen?**

Open het met de juiste [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), en kloon vervolgens de dia's normaal. Uitvoerbeveiliging wordt apart geconfigureerd.

**Hoe moet ik zeer grote presentaties behandelen?**

Gebruik BLOB‑beheer wanneer grote binaire objecten het geheugen domineren, laad bij zeer grote bestanden bij voorkeur via bestandspaden, maak bron‑presentaties snel vrij, en sla het uiteindelijke resultaat alleen op wanneer nodig.

**Kan ik dia's vanuit meerdere threads samenvoegen?**

Laad, sla op of kloon presentatie‑instanties niet in meerdere threads. Voor parallelle samenvoeg‑taken, gebruik afzonderlijke single‑threaded processen met onafhankelijke presentatie‑instanties.