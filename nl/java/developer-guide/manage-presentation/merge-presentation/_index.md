---
title: "Efficiënt presentaties samenvoegen in Java"
linktitle: "Presentaties samenvoegen"
type: docs
weight: 40
url: /nl/java/merge-presentation/
keywords:
- "PowerPoint samenvoegen"
- "presentaties samenvoegen"
- "dia's samenvoegen"
- "PPT samenvoegen"
- "PPTX samenvoegen"
- "ODP samenvoegen"
- "PowerPoint combineren"
- "presentaties combineren"
- "dia's combineren"
- "PPT combineren"
- "PPTX combineren"
- "ODP combineren"
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties in Java kunt samenvoegen door dia's te klonen, masters en lay-outs te beheren, dia-inhoud te schalen, secties te behouden en beschermd of grote bestanden af te handelen."
---
## **Overzicht**

Aspose.Slides for Java voegt presentaties samen door dia's te klonen van één [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) naar een andere. De hoofdoperatie is [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), die de opmaak van de bron‑dia kan behouden of de gekloonde dia kan koppelen aan een master‑ of lay‑out in de doeldocumentatie.

Dit artikel behandelt de meest voorkomende samenvoeg‑workflows:

- alle dia's samenvoegen met behoud van hun bronopmaak;
- geselecteerde dia's samenvoegen;
- een master uit de doeldocumentatie toepassen;
- een specifieke lay‑out uit de doeldocumentatie toepassen;
- verschillende dia‑groottes normaliseren vóór het samenvoegen;
- gekloonde dia's toevoegen aan een sectie;
- meerdere presentaties samenvoegen in één end‑to‑end workflow;
- masters, bronnen, notities, commentaren, media, lettertypen, wachtwoorden, grote bestanden en multithreading‑aspecten afhandelen.

## **Hoe dia‑klonen masters en lay‑outs beïnvloedt**

Een dia erft een groot deel van zijn uiterlijk van zijn lay‑out en master. Daarom bepaalt de gekozen overload van het klonen hoe de samengevoegde dia wordt geïntegreerd in de doeldocumentatie.

Gebruik [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/) op één van de volgende manieren:

- `addClone(sourceSlide)` — behoudt de lay‑out en opmaak van de bron‑dia. Wanneer nodig kan de bron‑master automatisch naar de doeldocumentatie worden gekloond. Aspose.Slides houdt automatisch gekloonde masters bij zodat herhaalde dia's die dezelfde bron‑master gebruiken die master niet telkens opnieuw klonen.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — koppelt de gekloonde dia aan een specifieke doeldocumentatie‑[IMasterSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/). Aspose.Slides zoekt onder die master naar een overeenkomende lay‑out op type of naam.
- `addClone(sourceSlide, destinationLayout)` — koppelt de gekloonde dia direct aan een specifieke doeldocumentatie‑[ILayoutSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/).

De master of lay‑out die aan een `addClone`‑overload wordt meegegeven, moet behoren tot de **doeldocumentatie**, niet tot de brondocumentatie.

## **Gehele presentaties samenvoegen en bronopmaak behouden**

De eenvoudigste samenvoeging kopieert elke dia van de brondocumentatie naar de doeldocumentatie. Dit is de juiste keuze wanneer de geïmporteerde dia's hun oorspronkelijke thema, master en lay‑outrelaties moeten behouden.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

De resulterende presentatie kan meerdere masters bevatten wanneer bron‑ en doeldocumentatie verschillende designs gebruiken. Dit is te verwachten wanneer bronopmaak bewust wordt behouden.

## **Geselecteerde dia's samenvoegen**

U hoeft niet elke dia te klonen. Het volgende voorbeeld importeert alleen geselecteerde dia‑indexen uit de brondocumentatie.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Valideer dia‑indexen vóór het klonen wanneer ze afkomstig zijn van gebruikersinvoer of een externe configuratie.

## **Dia's samenvoegen met een doeldocumentatie‑master**

Gebruik de overload [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) wanneer geïmporteerde dia's een master moeten volgen die al tot de doeldocumentatie behoort.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides selecteert een passende lay‑out onder de opgegeven master door het type of de naam van de bron‑lay‑out te matchen. Als er geen geschikte lay‑out bestaat en `allowCloneMissingLayout` is `true`, wordt de bron‑lay‑out gekloond zodat de dia kan worden toegevoegd. Als het `false` is, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxeditexception/) gegooid.

Gebruik `false` wanneer u wilt dat de samenvoeging faalt in plaats van een extra lay‑out aan de doeldocumentatie‑master toe te voegen.

## **Dia's samenvoegen met een specifieke doeldocumentatie‑lay‑out**

Gebruik de overload [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) wanneer u precies weet welke doeldocumentatie‑lay‑out de geïmporteerde dia's moeten gebruiken.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Het toepassen van een doeldocumentatie‑lay‑out verandert de geërfde lay‑outrelatie; het rediseigne de bron‑dia‑inhoud niet. Als de bron‑ en doeldocumentatie‑lay‑outs verschillende placeholder‑structuren hebben, controleer dan het resultaat om te bevestigen dat de geërfde opmaak en placeholder‑gedrag passend zijn.

## **Presentaties samenvoegen met verschillende dia‑groottes**

Presentaties met verschillende dia‑afmetingen kunnen worden samengevoegd, maar het klonen van een dia naar een presentatie met een andere dia‑grootte rediseigne de inhoud niet automatisch voor het nieuwe canvas. Vormen kunnen daardoor verschoven, onverwacht geschaald of buiten het zichtbare dia‑gebied komen te liggen.

Een praktische aanpak is om de brondocumentatie vóór het klonen te herschalen. De methode [SlideSize.setSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesize/#setSize-float-float-int-) kan bestaande inhoud schalen terwijl de dia‑dimensies worden aangepast. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesizescaletype/) schaalt de inhoud zodat deze binnen de gevraagde grootte past.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Het herschalen wijzigt het brondocumentsobject in het geheugen. Als u de originele brondocumentatie ongewijzigd wilt houden voor andere bewerkingen, open dan een aparte instantie voor de samenvoeging.

## **Dia's samenvoegen in een sectie van een presentatie**

De basis‑loop voor dia‑klonen recreëert de sectie‑hiërarchie van de brondocumentatie niet. Als secties belangrijk zijn in de output, maak of selecteer dan secties in de doeldocumentatie en kloon de dia's expliciet naar deze secties met [addClone(ISlide, ISection)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

De gekloonde dia's worden toegevoegd aan de opgegeven doelsectie. Om meerdere bronsecties te behouden, doorloop [Presentation.getSections](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSections--) , haal de huidige dia's van elke bronsectie op met [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/isection/#getSlidesListOfSection--), recreateer de secties in de doeldocumentatie, en kloon elke opgehaalde dia naar de overeenkomstige doelsectie. Zie [Manage Slide Sections](/slides/nl/java/slide-section/) voor een volledig voorbeeld van sectie‑enumeratie, inclusief lege secties en structurele wijzigingen.

## **Meerdere presentaties veilig samenvoegen**

Het volgende end‑to‑end voorbeeld gebruikt de eerste presentatie als bestemming, normaliseert de dia‑grootte van elke extra bron, houdt elke bron alleen open zolang deze wordt gekopieerd, en slaat het uiteindelijke bestand pas op wanneer alles klaar is.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Dit is een nuttige basislijn om de bronopmaak van geïmporteerde dia's te behouden. Als uw output een enkel doeldocumentatie‑thema moet gebruiken, vervang dan de eenvoudige `addClone(slide)`‑aanroep door de juiste master‑ of lay‑out‑overload die eerder is getoond.

## **Praktische overwegingen**

### **Masters, lay‑outs en nauwkeurigheid van opmaak**

Standaard dia‑klonen kan een benodigde bron‑master automatisch naar de doeldocumentatie brengen. Aspose.Slides houdt een interne register bij voor automatisch gekloonde masters om te voorkomen dat dezelfde master keer op keer wordt gekloond. Handmatig gekloonde masters worden niet door dat register bijgehouden, dus voorkom voorafklonen van masters tenzij u expliciete controle over de master‑structuur nodig heeft.

Ga er niet van uit dat twee masters of lay‑outs met dezelfde naam visueel identiek zijn. Als een corporate‑template het uiteindelijke uiterlijk moet bepalen, kies dan expliciet een doeldocumentatie‑master of -lay‑out en controleer het resultaat na het samenvoegen.

### **Notities en commentaren**

Sprekersnotities en dia‑commentaren zijn gekoppeld aan de dia‑inhoud en worden gekopieerd wanneer een dia wordt gekloond. Aspose.Slides biedt ook speciale API’s voor [presentation notes](/slides/nl/java/presentation-notes/) en [presentation comments](/slides/nl/java/presentation-comments/).

Als de opmaak van de notitiepagina belangrijk is, controleer dan de samengevoegde presentatie omdat notitie‑masters objecten op presentatieniveau zijn en kunnen verschillen tussen bron‑bestanden. Voor review‑workflows controleer tevens de auteurs van commentaren en eventuele threaded commentaren na het combineren van bestanden van verschillende auteurs of templates.

### **Afbeeldingen, audio, video, OLE‑objecten en externe koppelingen**

Dia’s kunnen refereren naar resources op presentatieniveau, zoals afbeeldingen, ingesloten audio, ingesloten video en OLE‑data. Kloon de dia zelf in plaats van alleen de zichtbare vormen te kopiëren zodat Aspose.Slides de relaties van de dia met zijn resources kan behouden.

Ingesloten en gekoppelde resources moeten anders worden behandeld. Een gekoppelde audio, video, OLE‑object of hyperlink blijft afhankelijk van het externe doel; het klonen van een dia maakt van een externe koppeling geen ingesloten content. Test de paden en URL’s van gekoppelde resources in de omgeving waarin de samengevoegde presentatie wordt geopend.

Aspose.Slides houdt automatisch gekloonde masters bij, maar dit moet niet worden gezien als een algemene garantie dat identieke binaire resources van niet‑gerelateerde brondocumentaties altijd worden gede‑duplicated. Als de bestandsgrootte van belang is, inspecteer dan het samengevoegde pakket en meet het resultaat in plaats van te vertrouwen op impliciete deduplicatie.

### **Ingesloten lettertypen en beschikbaarheid van lettertypen**

Lettertypen worden op presentatieniveau beheerd. Als typografie consistent moet blijven over verschillende machines, ga er niet van uit dat alleen dia‑klonen garandeert dat elk vereist lettertype beschikbaar is in de doeldocumentatie. U kunt ingesloten lettertypen inspecteren met [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) en het insluiten expliciet beheren zoals beschreven in [Embed Fonts in Presentations](/slides/nl/java/embedded-font/).

Controleer bovendien of u toestemming heeft om de lettertypen die in de bron‑bestanden worden gebruikt in te sluiten. Licenties voor lettertypen kunnen het insluiten beperken.

### **Wachtwoord‑beveiligde presentaties**

Een wachtwoord‑beveiligde bron moet eerst succesvol worden geopend voordat de dia’s kunnen worden gekloond. Geef het wachtwoord door via [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Werk met de ontsleutelde presentatie.
} finally {
    source.dispose();
}
```

Het openen van een versleutelde bron past de bescherming niet automatisch toe op de doeldocumentatie. Configureer de uitgangsbeveiliging afzonderlijk indien nodig.

### **Grote presentaties en geheugenverbruik**

Grote presentaties met hoge‑resolutie‑afbeeldingen, audio, video of andere grote binaire objecten kunnen veel geheugen verbruiken. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) biedt controle over BLOB‑afhandeling en tijdelijk‑bestandgebruik. Zie [Manage Presentation BLOBs](/slides/nl/java/manage-blob/) voor strategieën voor grote bestanden.

Voor grote bestanden heeft het de voorkeur om van bestandspaden te laden wanneer mogelijk, elke bron‑presentatie zo snel mogelijk te ontladen nadat deze is samengevoegd, en herhaaldelijk opslaan van tussentijdse resultaten te vermijden tenzij het workflow‑scenario checkpoints vereist.

### **Thread‑veiligheid**

Laad, wijzig, sla op of kloon niet dezelfde [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑instantie gelijktijdig vanuit meerdere threads. Houd elke presentatiet instantie beperkt tot één samenvoeg‑operatie. Als u onafhankelijke taken paralleliseert, gebruik dan aparte presentatie‑instanties en volg de [Aspose.Slides multithreading guidance](/slides/nl/java/multithreading/).

## **FAQ**

**Hoe behoud ik het oorspronkelijke ontwerp van elke bron‑presentatie?**

Gebruik [addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) zonder een doel‑master of -lay‑out op te geven. Aspose.Slides kan de bron‑master automatisch klonen wanneer deze door de geïmporteerde dia nodig is.

**Hoe laat ik geïmporteerde dia's het thema van de bestemming gebruiken?**

Gebruik de overload die een doel‑master accepteert. Geef een master uit de doeldocumentatie op, niet uit de bron. Aspose.Slides probeert elke bron‑dia te koppelen aan een passende lay‑out onder die master.

**Wanneer moet ik een specifieke doel‑lay‑out gebruiken in plaats van een doel‑master?**

Gebruik een specifieke lay‑out wanneer elke geïmporteerde dia één bekende lay‑out moet gebruiken. Gebruik een master wanneer u wilt dat Aspose.Slides een lay‑out selecteert uit die master op basis van het type of de naam van de bron‑lay‑out.

**Kunnen presentaties met verschillende dia‑groottes worden samengevoegd?**

Ja, maar de inhoud van de dia wordt niet automatisch opnieuw ontworpen voor de nieuwe afmetingen. Schaal de brondocumentatie eerst wanneer u voorspelbare plaatsing nodig heeft, bijvoorbeeld met [SlideSize.setSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesize/#setSize-float-float-int-) en [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesizescaletype/).

**Kan ik PPT, PPTX en ODP presentaties samenvoegen in één bestand?**

Ja. Laad elke bron‑presentatie, kloon de vereiste dia's naar één bestemming, en sla de bestemming op in een ondersteund uitvoerformaat. Omdat presentatie‑formaten niet exact dezelfde functionaliteit bieden, controleer complexe inhoud na cross‑format samenvoegingen. Zie [Supported File Formats](/slides/nl/java/supported-file-formats/).

**Worden bron‑secties automatisch behouden?**

Niet door een basis‑loop die alleen dia's kloont. Maak de benodigde secties in de bestemming opnieuw en gebruik de sectie‑overload van [addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) wanneer de sectiestructuur behouden moet blijven.

**Worden spreker‑notities en commentaren behouden?**

Ze worden gekopieerd met de gekloonde dia. Voor workflows die afhankelijk zijn van notitie‑master‑styling, commentaarauteurs of threaded review‑data, controleer het samengevoegde resultaat omdat deze scenario's zowel presentatieniveau‑structuren als dia‑niveau‑inhoud omvatten.

**Wat gebeurt er met audio, video, OLE‑objecten en hyperlinks?**

Ingesloten content wordt meegenomen als onderdeel van de resource‑relaties van de gekloonde dia. Externe links blijven extern, dus hun doelbestanden of URL’s moeten nog steeds beschikbaar zijn na de samenvoeging.

**Zijn ingesloten lettertypen van elke bron gegarandeerd beschikbaar in de samengevoegde presentatie?**

Vertrouw niet alleen op dia‑klonen voor lettertype‑distributie. Inspecteer de ingesloten lettertypen van de bestemming en beheer het insluiten of de beschikbaarheid van externe lettertypen expliciet wanneer typografie belangrijk is.

**Hoe merge ik een wachtwoord‑beveiligd bestand?**

Open het met het juiste [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), kloon vervolgens de dia's zoals gewoonlijk. Uitgangsbeveiliging wordt apart geconfigureerd.

**Hoe moet ik zeer grote presentaties afhandelen?**

Gebruik BLOB‑beheer wanneer grote binaire objecten het geheugen belasten, laad grote bestanden bij voorkeur via pad‑laden, ontlaad bron‑presentaties direct na gebruik, en sla het eindresultaat pas op wanneer dat nodig is.

**Kan ik dia's vanuit meerdere threads samenvoegen?**

Gebruik niet één [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑instantie gelijktijdig vanuit meerdere threads. Houd elke samenvoeg‑operatie geïsoleerd in eigen presentatiet instanties.