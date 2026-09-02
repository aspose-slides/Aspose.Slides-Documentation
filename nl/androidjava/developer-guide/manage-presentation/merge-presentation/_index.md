---
title: Efficiënt Presentaties samenvoegen op Android
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
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties op Android kunt samenvoegen door dia's te klonen, masters en lay-outs te beheersen, dia-inhoud te schalen, secties te behouden en beschermde of grote bestanden te verwerken."
---
## **Overzicht**

Aspose.Slides for Android via Java voegt presentaties samen door dia's te klonen van één [Presentatie](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) naar een andere. De hoofdoperatie is [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), die de opmaak van de bron‑dia kan behouden of de gekloonde dia kan koppelen aan een master of lay‑out in de bestemmingspresentatie.

Dit artikel behandelt de meest voorkomende samenvoegwerkstromen:

- voeg alle dia's samen terwijl hun bronopmaak behouden blijft;
- voeg geselecteerde dia's samen;
- pas een master toe van de bestemmingspresentatie;
- pas een specifieke lay‑out toe van de bestemmingspresentatie;
- normaliseer verschillende diaformaten vóór het samenvoegen;
- voeg gekloonde dia's toe aan een sectie;
- voeg meerdere presentaties samen in één end-to-end workflow;
- verwerk masters, bronnen, notities, opmerkingen, media, lettertypen, wachtwoorden, grote bestanden en multithreading‑vraagstukken.

## **Hoe dia‑klonen masters en lay-outs beïnvloedt**

Een dia erft een groot deel van zijn uiterlijk van zijn lay‑out en master. Om die reden bepaalt de overload voor klonen die u kiest hoe de samengevoegde dia wordt geïntegreerd in de bestemmingspresentatie.

Gebruik [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/) op een van de volgende manieren:

- `addClone(sourceSlide)` — behoudt de lay‑out en opmaak van de bron‑dia. Indien nodig kan de bron‑master automatisch worden gekloond naar de bestemmingspresentatie. Aspose.Slides houdt automatisch gekloonde masters bij zodat herhaalde dia's die dezelfde bron‑master gebruiken deze master niet herhaaldelijk klonen.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — gekoppelt de gekloonde dia aan een specifieke bestemmings‑[IMasterSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/imasterslide/). Aspose.Slides zoekt een overeenkomstige lay‑out onder die master op lay‑outtype of naam.
- `addClone(sourceSlide, destinationLayout)` — gekoppelt de gekloonde dia rechtstreeks aan een specifieke bestemmings‑[ILayoutSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ilayoutslide/).

De master of lay‑out die aan een `addClone`‑overload wordt doorgegeven, moet behoren tot de **bestemmings**‑presentatie, niet tot de bron‑presentatie.

## **Volledige presentaties samenvoegen en bronopmaak behouden**

De eenvoudigste samenvoeging kopieert elke dia van de bron‑presentatie naar de bestemmingspresentatie. Dit is de juiste keuze wanneer de geïmporteerde dia's hun originele thema, master en lay‑outrelaties moeten behouden.

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

De resulterende presentatie kan meerdere masters bevatten wanneer de bron‑ en bestemmingspresentatie verschillende ontwerpen gebruiken. Dit is te verwachten wanneer de bronopmaak opzettelijk behouden wordt.

## **Geselecteerde dia's samenvoegen**

U hoeft niet elke dia te klonen. Het volgende voorbeeld importeert alleen geselecteerde dia‑indexen uit de bron‑presentatie.

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

Gebruik de [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) overload wanneer geïmporteerde dia's een master moeten volgen die al tot de bestemmingspresentatie behoort.

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

Aspose.Slides selecteert een passende lay‑out onder de opgegeven master door het type of de naam van de bron‑lay‑out te vergelijken. Als er geen geschikte lay‑out bestaat en `allowCloneMissingLayout` is `true`, wordt de bron‑lay‑out gekloond zodat de dia kan worden toegevoegd. Als deze `false` is, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/pptxeditexception/) gegooid.

Gebruik `false` wanneer u wilt dat de samenvoeging mislukt in plaats van een extra lay‑out toe te voegen aan de bestemmings‑master.

## **Dia's samenvoegen met een specifieke bestemmings‑lay-out**

Gebruik de [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) overload wanneer u exact weet welke bestemmings‑lay‑out de geïmporteerde dia's moeten gebruiken.

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

Het toepassen van een bestemmings‑lay‑out wijzigt de geërfde lay‑outrelatie; het herschept de inhoud van de bron‑dia niet. Als de bron‑ en bestemmings‑lay‑outs verschillende placeholder‑structuren hebben, inspecteer dan het resultaat om te bevestigen dat de geërfde opmaak en placeholder‑gedrag passend zijn.

## **Presentaties met verschillende diaformaten samenvoegen**

Presentaties met verschillende dia‑afmetingen kunnen worden samengevoegd, maar het klonen van een dia naar een presentatie met een andere dia‑grootte leidt niet automatisch tot een herontwerp van de inhoud voor het nieuwe canvas. Vormen kunnen daardoor verschoven, onverwacht geschaald of buiten het zichtbare dia‑gebied verschijnen.

Een praktische benadering is om de bron‑presentatie vóór het klonen van formaat te wijzigen. De [SlideSize.setSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) methode kan de bestaande inhoud schalen terwijl de dia‑afmetingen worden aangepast. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidesizescaletype/) schaalt de inhoud zodat deze past binnen de gevraagde grootte.

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

Schalen wijzigt het bron‑presentatie‑object in het geheugen. Als u de oorspronkelijke bron‑presentatie ongewijzigd wilt houden voor andere bewerkingen, open dan een aparte instantie voor de samenvoeging.

## **Dia's samenvoegen in een presentatiesectie**

De basis‑dia‑kloningslus maakt de sectie‑hiërarchie van de bron‑presentatie niet opnieuw aan. Als secties belangrijk zijn in de uitvoer, maak of selecteer dan secties in de bestemmingspresentatie en kloon dia's expliciet erin met [addClone(ISlide, ISection)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

De gekloonde dia's worden toegevoegd aan de opgegeven bestemmingssectie. Om verschillende bron‑secties te behouden, maakt u die secties opnieuw aan in de bestemming en koppelt elke bron‑dia aan de overeenkomstige bestemmingssectie.

## **Meerdere presentaties veilig samenvoegen**

Het volgende end-to-end voorbeeld gebruikt de eerste presentatie als bestemming, normaliseert de dia‑grootte van elke extra bron, houdt elke bron alleen geopend terwijl deze wordt gekopieerd, en slaat het uiteindelijke bestand eenmaal op.

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

Dit is een nuttige basis voor het behouden van de bronopmaak van geïmporteerde dia's. Als uw uitvoer een enkel bestemmings‑thema moet gebruiken, vervang dan de eenvoudige `addClone(slide)`‑aanroep door de juiste bestemmings‑master‑ of bestemmings‑lay‑out‑overload die eerder werd getoond.

## **Praktische overwegingen**

### **Masters, lay-outs en opmaak‑fideliteit**

Standaard dia‑klonen kan automatisch een benodigde bron‑master naar de bestemmingspresentatie brengen. Aspose.Slides houdt een interne register bij voor automatisch gekloonde masters om te voorkomen dat dezelfde master herhaaldelijk wordt gekloond. Handmatig gekloonde masters worden niet bijgehouden in dat register, dus vermijd het vooraf klonen van masters tenzij u expliciete controle over de masterstructuur nodig heeft.

Ga er niet van uit dat twee masters of lay‑outs met dezelfde naam visueel gelijk zijn. Als een corporate‑sjabloon de uiteindelijke weergave moet bepalen, kies dan expliciet een bestemmings‑master of -lay‑out en controleer het resultaat na het samenvoegen.

### **Notities en opmerkingen**

Sprekersnotities en dia‑opmerkingen zijn gekoppeld aan de inhoud van de dia en worden gekopieerd wanneer een dia wordt gekloond. Aspose.Slides biedt ook speciale API's voor [presentatienotities](https://docs.aspose.com/slides/nl/androidjava/presentation-notes/) en [presentatie‑opmerkingen](https://docs.aspose.com/slides/nl/androidjava/presentation-comments/).

Als de opmaak van de notitie‑pagina belangrijk is, controleer dan de samengevoegde presentatie omdat notitie‑masters objecten op presentatieniveau zijn en kunnen verschillen tussen bronbestanden. Voor beoordelings‑workflows controleer ook de auteurs van opmerkingen en geneste opmerkingen nadat bestanden van verschillende auteurs of sjablonen zijn gecombineerd.

### **Afbeeldingen, audio, video, OLE‑objecten en externe links**

Dia's kunnen verwijzen naar resources op presentatieniveau, zoals afbeeldingen, ingesloten audio, ingesloten video en OLE‑gegevens. Kloon de dia zelf in plaats van alleen de zichtbare vormen te kopiëren zodat Aspose.Slides de relaties van de dia met zijn resources kan behouden.

Ingesloten en gekoppelde resources moeten anders behandeld worden. Een gekoppelde audio, video, OLE‑object of hyperlink blijft afhankelijk van zijn externe doel; het klonen van een dia maakt van een externe link geen ingesloten content. Test de paden en URL's van gekoppelde resources in de omgeving waar de samengevoegde presentatie wordt geopend.

Aspose.Slides houdt expliciet automatisch gekloonde masters bij, maar dit moet niet worden gezien als een algemene garantie dat identieke binaire resources uit verschillende bron‑presentaties altijd worden gededupliceerd. Als de bestandsgrootte van de uitvoer belangrijk is, inspecteer dan het samengevoegde pakket en meet het resultaat in plaats van te vertrouwen op impliciete deduplicatie.

### **Ingesloten lettertypen en beschikbaarheid van lettertypen**

Lettertypen worden beheerd op presentatieniveau. Als typografie consistent moet blijven over verschillende machines, ga er dan niet van uit dat alleen dia’s klonen garandeert dat elk vereist lettertype beschikbaar is in de bestemmingsomgeving. U kunt ingesloten lettertypen inspecteren met [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) en het insluiten expliciet beheren zoals beschreven in [Lettertypen insluiten in presentaties](https://docs.aspose.com/slides/nl/androidjava/embedded-font/).

Controleer ook of u toestemming heeft om de lettertypen die in de bronbestanden worden gebruikt in te sluiten. Font‑licenties kunnen het insluiten beperken.

### **Wachtwoord‑beveiligde presentaties**

Een wachtwoord‑beveiligde bron moet succesvol worden geopend voordat de dia's kunnen worden gekloond. Lever het wachtwoord via [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Werk met de ontcijferde presentatie.
} finally {
    source.dispose();
}
```

Het openen van een versleutelde bron past dezelfde bescherming niet automatisch toe op de bestemmingspresentatie. Configureer de uitgaande bescherming afzonderlijk wanneer nodig.

### **Grote presentaties en geheugengebruik**

Grotere presentaties met afbeeldingen met hoge resolutie, audio, video of andere grote binaire objecten kunnen veel geheugen verbruiken. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) biedt bedieningselementen voor BLOB‑afhandeling en tijdelijk‑bestandgebruik. Zie [Presentatie‑BLOBs beheren](https://docs.aspose.com/slides/nl/androidjava/manage-blob/) voor strategieën voor grote bestanden.

Voor grote bestanden laadt bij voorkeur vanuit bestands‑paden wanneer mogelijk, verwijder elke bron‑presentatie zodra deze is samengevoegd, en vermijd herhaaldelijk opslaan van tussenresultaten tenzij de workflow controle‑punten vereist.

### **Thread‑veiligheid**

Laad, wijzig, sla niet op of kloon niet dezelfde [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie gelijktijdig vanuit meerdere threads. Houd elke presentati​e‑instantie beperkt tot één samenvoeg‑bewerking. Als u onafhankelijke taken paralleliseert, gebruik dan onafhankelijke presentati​e‑instanties en volg de [Aspose.Slides‑multithreading‑richtlijnen](https://docs.aspose.com/slides/nl/androidjava/multithreading/).

## **FAQ**

**Hoe houd ik het oorspronkelijke ontwerp van elke bronpresentatie behouden?**

Gebruik `addClone(sourceSlide)` zonder een bestemmings‑master of -lay‑out op te geven. Aspose.Slides kan de bron‑master automatisch klonen wanneer deze door de geïmporteerde dia nodig is.

**Hoe zorg ik dat geïmporteerde dia's het bestemmings‑thema gebruiken?**

Gebruik de overload die een bestemmings‑master accepteert. Geef een master uit de bestemmingspresentatie op, niet uit de bron. Aspose.Slides zal proberen elke bron‑dia te koppelen aan een passende lay‑out onder die master.

**Wanneer moet ik een specifieke bestemmings‑lay‑out gebruiken in plaats van een bestemmings‑master?**

Gebruik een specifieke lay‑out wanneer elke geïmporteerde dia één bekende lay‑out moet gebruiken. Gebruik een master wanneer u wilt dat Aspose.Slides kiest tussen de lay‑outs van die master op basis van het type of de naam van de bron‑lay‑out.

**Kunnen presentaties met verschillende diaformaten worden samengevoegd?**

Ja, maar de inhoud van de dia wordt niet automatisch opnieuw ontworpen voor de doelafmetingen. Schaal de bron‑presentatie eerst wanneer u predictieve positionering nodig heeft, bijvoorbeeld met [SlideSize.setSize](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) en [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidesizescaletype/).

**Kan ik PPT-, PPTX- en ODP‑presentaties in één bestand samenvoegen?**

Ja. Laad elke bron‑presentatie, kloon de vereiste dia's in één bestemmings‑presentatie en sla de bestemming op in een ondersteund uitvoerformaat. Omdat presentaties verschillende functiemogelijkheden hebben, controleer complexe inhoud na cross‑formaat‑samenvoegingen. Zie [Supported File Formats](https://docs.aspose.com/slides/nl/androidjava/supported-file-formats/).

**Worden bron‑secties automatisch behouden?**

Niet door een eenvoudige lus die alleen dia's kloont. Maak de benodigde secties in de bestemming opnieuw aan en gebruik de sectie‑overload van [addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) wanneer de sectiestructuur moet worden behouden.

**Worden sprekersnotities en opmerkingen behouden?**

Ze worden gekopieerd met de gekloonde dia. Voor werkstromen die afhankelijk zijn van notitie‑master‑styling, auteurs van opmerkingen of geneste review‑gegevens, controleer het samengevoegde resultaat omdat die scenario's presentatieniveau‑structuren én dia‑inhoud omvatten.

**Wat gebeurt er met audio, video, OLE‑objecten en hyperlinks?**

Ingesloten content wordt meegenomen als onderdeel van de gekloonde dia‑resource‑relaties. Externe links blijven extern, dus hun doel‑bestanden of URL's moeten nog steeds beschikbaar zijn na het samenvoegen.

**Worden ingesloten lettertypen van elke bron gegarandeerd beschikbaar in de samengevoegde presentatie?**

Vertrouw niet alleen op dia‑klonen voor font‑distributie. Inspecteer de ingesloten lettertypen van de bestemming en beheer het insluiten of de beschikbaarheid van externe lettertypen expliciet wanneer typografie belangrijk is.

**Hoe kan ik een wachtwoordbeveiligd bestand samenvoegen?**

Open het met het juiste [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) en kloon vervolgens de dia's normaal. Bescherming van de uitvoer wordt afzonderlijk geconfigureerd.

**Hoe ga ik om met zeer grote presentaties?**

Gebruik BLOB‑beheer wanneer grote binaire objecten het geheugen belasten, laad bij voorkeur vanuit bestands‑paden voor zeer grote bestanden, verwijder bron‑presentaties direct na samenvoegen, en sla het eindresultaat alleen op wanneer nodig.

**Kan ik dia's vanuit meerdere threads samenvoegen?**

Laad niet dezelfde [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie gelijktijdig vanuit meerdere threads. Houd elke samenvoeg‑bewerking geïsoleerd tot eigen presentati​e‑instanties.