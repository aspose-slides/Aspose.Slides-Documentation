---
title: Efficiënt presentaties samenvoegen op Android
linktitle: Presentaties samenvoegen
type: docs
weight: 40
url: /nl/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties op Android kunt samenvoegen door dia's te klonen, masters en lay-outs te beheren, dia-inhoud te schalen, secties te behouden en beveiligde of grote bestanden af te handelen."
---
## **Overzicht**

Aspose.Slides for Android via Java voegt presentaties samen door dia's te klonen van één [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) naar een andere. De belangrijkste bewerking is [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), die de opmaak van de bron‑dia kan behouden of de gekloonde dia kan koppelen aan een master of lay‑out in de bestemmingspresentatie.

Dit artikel behandelt de meest voorkomende samenvoeg‑workflows:

- alle dia's samenvoegen terwijl de bron‑opmaak behouden blijft;
- geselecteerde dia's samenvoegen;
- een master uit de bestemmingspresentatie toepassen;
- een specifieke lay‑out uit de bestemmingspresentatie toepassen;
- verschillende dia‑groottes normaliseren vóór het samenvoegen;
- gekloonde dia's aan een sectie toevoegen;
- meerdere presentaties in één end‑to‑end workflow samenvoegen;
- masters, resources, notities, commentaren, media, lettertypen, wachtwoorden, grote bestanden en multithreading‑aspecten afhandelen.

## **Hoe het klonen van dia's masters en lay‑outs beïnvloedt**

Een dia erft veel van zijn uiterlijk van de lay‑out en de master. Daarom bepaalt de overload die je kiest hoe de samengevoegde dia in de bestemmingspresentatie wordt geïntegreerd.

Gebruik [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/) op één van de volgende manieren:

- `addClone(sourceSlide)` — behoudt de lay‑out en opmaak van de bron‑dia. Indien nodig kan de bron‑master automatisch in de bestemmingspresentatie worden gekloond. Aspose.Slides houdt automatisch gekloonde masters bij zodat herhaalde dia's die dezelfde bron‑master gebruiken die master niet opnieuw klonen.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — koppelt de gekloonde dia aan een specifieke bestemmings-[IMasterSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslide/). Aspose.Slides zoekt onder die master naar een overeenkomende lay‑out op type of naam.
- `addClone(sourceSlide, destinationLayout)` — koppelt de gekloonde dia direct aan een specifieke bestemmings-[ILayoutSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/).

De master of lay‑out die aan een `addClone`‑overload wordt doorgegeven, moet toebehoren aan de **bestemmings**‑presentatie, niet aan de bron‑presentatie.

## **Gehele presentaties samenvoegen en bron‑opmaak behouden**

De eenvoudigste samenvoeging kopieert elke dia van de bron‑presentatie naar de bestemmingspresentatie. Dit is de juiste keuze wanneer de geïmporteerde dia's hun oorspronkelijke thema, master en lay‑outrelaties moeten behouden.

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

De resulterende presentatie kan meerdere masters bevatten wanneer de bron‑ en bestemmingspresentatie verschillende ontwerpen gebruiken. Dit is te verwachten wanneer de bron‑opmaak expres behouden blijft.

## **Geselecteerde dia's samenvoegen**

Je hoeft niet elke dia te klonen. Het volgende voorbeeld importeert alleen geselecteerde dia‑indexen uit de bron‑presentatie.

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

Valideer dia‑indexen vóór het klonen wanneer ze afkomstig zijn van gebruikersinvoer of externe configuratie.

## **Dia's samenvoegen met een bestemmings‑master**

Gebruik de overload [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) wanneer geïmporteerde dia's een master moeten volgen die al tot de bestemmingspresentatie behoort.

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

Aspose.Slides selecteert een passende lay‑out onder de opgegeven master door het type of de naam van de bron‑lay‑out te vergelijken. Als er geen geschikte lay‑out bestaat en `allowCloneMissingLayout` `true` is, wordt de bron‑lay‑out gekloond zodat de dia kan worden toegevoegd. Als het `false` is, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxeditexception/) gegooid.

Gebruik `false` wanneer je wilt dat de samenvoeging faalt in plaats van een extra lay‑out aan de bestemmings‑master toe te voegen.

## **Dia's samenvoegen met een specifieke bestemmings‑lay‑out**

Gebruik de overload [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) wanneer je precies weet welke bestemmings‑lay‑out de geïmporteerde dia's moeten gebruiken.

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

Toepassing van een bestemmings‑lay‑out wijzigt de geërfde lay‑outrelatie; het ontwerpt de inhoud van de bron‑dia niet opnieuw. Als de bron‑ en bestemmings‑lay‑outs verschillende placeholder‑structuren hebben, controleer dan het resultaat om te bevestigen dat de geërfde opmaak en placeholder‑gedrag geschikt zijn.

## **Presentaties met verschillende dia‑groottes samenvoegen**

Presentaties met verschillende dia‑afmetingen kunnen worden samengevoegd, maar een dia klonen naar een presentatie met een andere dia‑grootte herontwerpt de inhoud niet automatisch voor het nieuwe canvas. Vormen kunnen daardoor verschoven, onverwacht geschaald of buiten het zichtbare dia‑gebied terechtkomen.

Een praktische aanpak is om de bron‑presentatie vóór het klonen te schalen. De methode [SlideSize.setSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) kan bestaande inhoud schalen terwijl de dia‑afmetingen worden aangepast. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidesizescaletype/) schaalt de inhoud zodat deze binnen de gewenste grootte past.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
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

Schalen wijzigt het bron‑presentatie‑object in het geheugen. Als je de originele bron‑presentatie ongewijzigd wilt houden voor andere bewerkingen, open dan een aparte instantie voor de samenvoeging.

## **Dia's in een presentatiesectie samenvoegen**

De basis‑klonlus hercreëert de sectie‑hiërarchie van de bron‑presentatie niet. Als secties van belang zijn in de output, maak of selecteer dan secties in de bestemmingspresentatie en kloon dia's expliciet naar hen met [addClone(ISlide, ISection)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

De gekloonde dia's worden toegevoegd aan de opgegeven bestemmingssectie. Om meerdere bron‑secties te behouden, doorloop je [Presentation.getSections](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSections--), haal je de huidige dia's van elke bron‑sectie op met [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--), recreëer je de secties in de bestemming en kloon je elke opgehaalde dia naar de corresponderende bestemmingssectie. Zie [Manage Slide Sections](/slides/nl/androidjava/slide-section/) voor een volledig voorbeeld van sectie‑enumeratie, inclusief lege secties en structurele wijzigingen.

## **Meerdere presentaties veilig samenvoegen**

Het volgende end‑to‑end voorbeeld gebruikt de eerste presentatie als bestemming, normaliseert de dia‑grootte van elke extra bron, houdt elke bron alleen geopend zolang deze wordt gekopieerd, en slaat het uiteindelijke bestand eenmaal op.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
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

Dit is een nuttige basis voor het behouden van de bron‑opmaak van geïmporteerde dia's. Als je output een enkel bestemmings‑thema moet gebruiken, vervang dan de eenvoudige `addClone(slide)`‑aanroep door de eerder getoonde overload voor bestemmings‑master of -lay‑out.

## **Praktische overwegingen**

### **Masters, lay‑outs en trouw aan opmaak**

Standaard kan het klonen van dia's automatisch een benodigde bron‑master in de bestemmingspresentatie brengen. Aspose.Slides houdt een interne register bij voor automatisch gekloonde masters om te voorkomen dat dezelfde master herhaaldelijk wordt geklond. Handmatig gekloonde masters worden niet bijgehouden, dus vermijd vooraf klonen van masters tenzij je expliciete controle over de master‑structuur nodig hebt.

Ga er niet van uit dat twee masters of lay‑outs met dezelfde naam visueel gelijk zijn. Als een bedrijfs‑template de uiteindelijke uitstraling moet bepalen, kies dan expliciet een bestemmings‑master of -lay‑out en controleer het resultaat na het samenvoegen.

### **Notities en commentaren**

Sprekersnotities en dia‑commentaren zijn gekoppeld aan de inhoud van de dia en worden gekopieerd wanneer een dia wordt gekloond. Aspose.Slides biedt bovendien speciale API’s voor [presentation notes](/slides/nl/androidjava/presentation-notes/) en [presentation comments](/slides/nl/androidjava/presentation-comments/).

Als de opmaak van de notitie‑pagina belangrijk is, controleer dan de samengevoegde presentatie omdat notitie‑masters objecten op presentatieniveau zijn en kunnen verschillen tussen bron‑bestanden. Controleer bij review‑workflows ook de auteurs van commentaren en ingesprongen commentaren nadat bestanden van verschillende auteurs of templates zijn gecombineerd.

### **Afbeeldingen, audio, video, OLE‑objecten en externe koppelingen**

Dia's kunnen verwijzen naar resources op presentatieniveau, zoals afbeeldingen, ingesloten audio, ingesloten video en OLE‑data. Kloon de dia zelf in plaats van alleen de zichtbare vormen te kopiëren zodat Aspose.Slides de relaties van de dia met zijn resources kan behouden.

Ingesloten en gekoppelde resources moeten verschillend behandeld worden. Een gekoppelde audio, video, OLE‑object of hyperlink blijft afhankelijk van zijn externe doel; het klonen van een dia verandert een externe link niet in ingesloten content. Test gekoppelde‑resource‑paden en URL’s in de omgeving waar de samengevoegde presentatie wordt geopend.

Aspose.Slides houdt automatisch gekloonde masters bij, maar dit moet niet worden opgevat als een algemene garantie dat identieke binaire resources uit niet‑gerelateerde bron‑presentaties altijd worden gededupliceerd. Als de bestandsgrootte van de output belangrijk is, inspecteer dan het samengevoegde pakket en meet het resultaat in plaats van te vertrouwen op impliciete deduplicatie.

### **Ingesloten lettertypen en beschikbaarheid van letters**

Lettertypen worden beheerd op presentatieniveau. Als typografie consistent moet blijven over verschillende machines, ga er niet van uit dat alleen het klonen van dia's garandeert dat elk benodigd lettertype beschikbaar is in de bestemmingsomgeving. Je kunt ingesloten lettertypen inspecteren met [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) en expliciet beheer van insluiting toepassen zoals beschreven in [Embed Fonts in Presentations](/slides/nl/androidjava/embedded-font/).

Controleer ook dat je toestemming hebt om de lettertypen van de bron‑bestanden in te sluiten. Licenties voor lettertypen kunnen insluiting beperken.

### **Wachtwoord‑beveiligde presentaties**

Een wachtwoord‑beveiligde bron moet eerst succesvol worden geopend voordat de dia's kunnen worden gekloond. Lever het wachtwoord aan via [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Werk met de gedecrypteerde presentatie.
} finally {
    source.dispose();
}
```

Het openen van een versleutelde bron past dezelfde bescherming niet automatisch toe op de bestemmingspresentatie. Configureer de output‑beveiliging afzonderlijk wanneer dat vereist is.

### **Grote presentaties en geheugen‑gebruik**

Grote presentaties met hoge‑resolutie‑afbeeldingen, audio, video of andere omvangrijke binaire objecten kunnen veel geheugen verbruiken. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) biedt controles voor BLOB‑afhandeling en tijdelijk‑bestand gebruik. Zie [Manage Presentation BLOBs](/slides/nl/androidjava/manage-blob/) voor strategieën met grote bestanden.

Voor grote bestanden, laad bij voorkeur via bestandspaden, verwijder elke bron‑presentatie zodra deze is samengevoegd, en vermijd het herhaaldelijk opslaan van tussenresultaten tenzij de workflow checkpoints vereist.

### **Thread‑veiligheid**

Laad, wijzig, sla op of kloon dezelfde [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie niet gelijktijdig vanuit meerdere threads. Houd elke presentatie‑instantie beperkt tot één samenvoeg‑operatie. Als je onafhankelijke taken paralleliseert, gebruik dan onafhankelijke presentatie‑instanties en volg de [Aspose.Slides multithreading guidance](/slides/nl/androidjava/multithreading/).

## **FAQ**

**Hoe houd ik het oorspronkelijke ontwerp van elke bron‑presentatie intact?**

Gebruik [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) zonder een bestemmings‑master of -lay‑out op te geven. Aspose.Slides kan automatisch de bron‑master klonen wanneer deze nodig is voor de geïmporteerde dia.

**Hoe laat ik geïmporteerde dia's het bestemmings‑thema gebruiken?**

Gebruik de overload die een bestemmings‑master accepteert. Geef een master uit de bestemmingspresentatie op, niet uit de bron. Aspose.Slides probeert elke bron‑dia te koppelen aan een passende lay‑out onder die master.

**Wanneer moet ik een specifieke bestemmings‑lay‑out gebruiken in plaats van een bestemmings‑master?**

Gebruik een specifieke lay‑out wanneer elke geïmporteerde dia één bekende lay‑out moet gebruiken. Gebruik een master wanneer je wilt dat Aspose.Slides kiest uit de lay‑outs van die master op basis van het type of de naam van de bron‑lay‑out.

**Kunnen presentaties met verschillende dia‑groottes worden samengevoegd?**

Ja, maar de dia‑inhoud wordt niet automatisch opnieuw ontworpen voor de bestemmings‑dimensies. Schaal de bron‑presentatie eerst wanneer je voorspelbare positionering nodig hebt, bijvoorbeeld met [SlideSize.setSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) en [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidesizescaletype/).

**Kan ik PPT, PPTX en ODP presentaties samenvoegen in één bestand?**

Ja. Laad elke bron‑presentatie, kloon de benodigde dia's naar één bestemming, en sla de bestemming op in een ondersteund uitvoerformaat. Omdat bestandsformaten niet exact dezelfde functie‑set ondersteunen, controleer je complexe inhoud na cross‑format samenvoegingen. Zie [Supported File Formats](/slides/nl/androidjava/supported-file-formats/).

**Worden bron‑secties automatisch behouden?**

Niet door een eenvoudige lus die alleen dia's kloont. Maak de vereiste secties opnieuw aan in de bestemming en gebruik de sectie‑overload van [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) wanneer sectiestructuur behouden moet blijven.

**Worden spreker‑notities en commentaren behouden?**

Ze worden meegekopieerd met de gekloonde dia. Voor workflows die afhankelijk zijn van notitie‑master‑stijlen, commentaarauteurs of ingesprongen review‑data, controleer het samengevoegde resultaat omdat die scenario's zowel presentatieniveau‑structuren als dia‑niveau‑inhoud omvatten.

**Wat gebeurt er met audio, video, OLE‑objecten en hyperlinks?**

Ingesloten content wordt meegenomen als onderdeel van de resource‑relaties van de gekloonde dia. Externe links blijven extern, dus hun doel‑bestanden of URL’s moeten nog steeds beschikbaar zijn na de samenvoeging.

**Zijn ingesloten lettertypen van elke bron gegarandeerd beschikbaar in de samengevoegde presentatie?**

Vertrouw niet alleen op het klonen van dia's voor lettertype‑distributie. Inspecteer de ingesloten lettertypen van de bestemming en beheer expliciet lettertype‑insluiting of externe beschikbaarheid wanneer typografie belangrijk is.

**Hoe voeg ik een wachtwoord‑beveiligd bestand samen?**

Open het met de juiste [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), kloon vervolgens de dia's normaal. Output‑beveiliging wordt afzonderlijk geconfigureerd.

**Hoe moet ik omgaan met zeer grote presentaties?**

Gebruik BLOB‑beheer wanneer grote binaire objecten het geheugen belasten, geef de voorkeur aan laden via bestandspaden voor zeer grote bestanden, verwijder bron‑presentaties direct na gebruik, en sla het eindresultaat alleen op wanneer nodig.

**Kan ik dia's vanuit meerdere threads samenvoegen?**

Gebruik geen enkele [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie gelijktijdig vanuit meerdere threads. Houd elke samenvoeg‑operatie geïsoleerd in eigen presentatie‑instanties.