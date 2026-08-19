---
title: Efficiënt Presentaties Samenvoegen in Java
linktitle: Presentaties Samenvoegen
type: docs
weight: 40
url: /nl/java/merge-presentation/
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
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint- en OpenDocument-presentaties in Java kunt samenvoegen door dia's te klonen, masters en lay-outs te beheersen, de inhoud van dia's te herschalen, secties te behouden en beveiligde of grote bestanden af te handelen."
---
## **Overzicht**

Aspose.Slides for Java voegt presentaties samen door dia's te klonen van een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/) naar een andere. De hoofdoperatie is [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), die de opmaak van de brondia kan behouden of de gekloonde dia kan koppelen aan een master of lay-out in de doeldocumentpresentatie.

Dit artikel behandelt de meest voorkomende samenvoeg‑workflows:

- alle dia's samenvoegen terwijl hun bronopmaak behouden blijft;
- geselecteerde dia's samenvoegen;
- een master van de doeldocumentpresentatie toepassen;
- een specifieke lay-out van de doeldocumentpresentatie toepassen;
- verschillende dia‑groottes normaliseren vóór het samenvoegen;
- gekloonde dia's toevoegen aan een sectie;
- meerdere presentaties samenvoegen in één end‑to‑end workflow;
- masters, resources, notities, opmerkingen, media, lettertypen, wachtwoorden, grote bestanden en multithreading‑aspecten afhandelen.

## **Hoe Slide‑klonen Masters en Layouts beïnvloedt**

Een dia erft een groot deel van zijn uiterlijk van de lay‑out en master. Om die reden bepaalt de overload van klonen die u kiest hoe de samengevoegde dia wordt geïntegreerd in de doeldocumentpresentatie.

Gebruik [ISlideCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/) op één van de volgende manieren:

- `addClone(sourceSlide)` — behoudt de lay‑out en opmaak van de brondia. Indien nodig kan de bron‑master automatisch in de doeldocumentpresentatie worden gekloond. Aspose.Slides volgt automatisch gekloonde masters zodat herhaalde dia's die dezelfde bron‑master gebruiken die master niet herhaaldelijk klonen.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — koppelt de gekloonde dia aan een specifieke doel‑[IMasterSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/imasterslide/). Aspose.Slides zoekt onder die master naar een overeenkomende lay‑out op type of naam.
- `addClone(sourceSlide, destinationLayout)` — koppelt de gekloonde dia direct aan een specifieke doel‑[ILayoutSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ilayoutslide/).

De master of lay‑out die aan een `addClone`‑overload wordt doorgegeven, moet behoren tot de **doel‑**presentatie, niet tot de bron‑presentatie.

## **Gehele Presentaties samenvoegen en Bronopmaak behouden**

De eenvoudigste samenvoeging kopieert elke dia van de bronpresentatie naar de doelpresentatie. Dit is de juiste keuze wanneer de geïmporteerde dia's hun oorspronkelijke thema, master en lay‑outrelaties moeten behouden.

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

De resulterende presentatie kan meerdere masters bevatten wanneer de bron‑ en doelpresentatie verschillende ontwerpen gebruiken. Dit is te verwachten wanneer bronopmaak opzettelijk behouden wordt.

## **Geselecteerde Dia's samenvoegen**

U hoeft niet elke dia te klonen. Het volgende voorbeeld importeert alleen geselecteerde dia‑indexen uit de bronpresentatie.

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

## **Dia's samenvoegen met een Doel‑Master**

Gebruik de overload [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) wanneer geïmporteerde dia's een master moeten volgen die al tot de doelpresentatie behoort.

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

Aspose.Slides selecteert een passende lay‑out onder de opgegeven master door de bron‑lay‑outtype of -naam te matchen. Als er geen geschikte lay‑out bestaat en `allowCloneMissingLayout` is `true`, wordt de bron‑lay‑out gekloond zodat de dia kan worden toegevoegd. Als het `false` is, wordt een [PptxEditException](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pptxeditexception/) gegooid.

Gebruik `false` wanneer u wilt dat de samenvoeging faalt in plaats van een extra lay‑out aan de doel‑master toe te voegen.

## **Dia's samenvoegen met een specifieke Doel‑Lay‑out**

Gebruik de overload [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) wanneer u precies weet welke doel‑lay‑out de geïmporteerde dia's moeten gebruiken.

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

Het toepassen van een doel‑lay‑out wijzigt de geërfde lay‑outrelatie; het herschept de inhoud van de bron‑dia niet. Als de bron‑ en doel‑lay‑outs verschillende placeholder‑structuren hebben, inspecteer dan het resultaat om te bevestigen dat de geërfde opmaak en placeholder‑gedrag passend zijn.

## **Presentaties met verschillende dia‑groottes samenvoegen**

Presentaties met verschillende dia‑afmetingen kunnen worden samengevoegd, maar het klonen van een dia naar een presentatie met een andere dia‑grootte herschept de inhoud niet automatisch voor het nieuwe canvas. Vormen kunnen daardoor verschoven, onverwacht geschaald of buiten het zichtbare dia‑gebied verschijnen.

Een praktische aanpak is om de bronpresentatie vóór het klonen te herschalen. De methode [SlideSize.setSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesize/#setSize-float-float-int-) kan bestaande inhoud schalen terwijl de dia‑afmetingen worden gewijzigd. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesizescaletype/) schaalt de inhoud zodat deze binnen de gevraagde afmeting past.

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

Het herschalen verandert het bron‑presentatie‑object in het geheugen. Als u de originele bronpresentatie ongewijzigd wilt houden voor andere bewerkingen, open dan een aparte instantie voor de samenvoeging.

## **Dia's samenvoegen in een Presentatie‑sectie**

De basis‑slide‑klonlus maakt de sectie‑hiërarchie van de bronpresentatie niet opnieuw. Als secties belangrijk zijn in de output, maak of selecteer dan secties in de doelpresentatie en kloon dia's expliciet daarin met [addClone(ISlide, ISection)](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

De gekloonde dia's worden toegevoegd aan de opgegeven doelsectie. Om meerdere bron‑secties te behouden, maak die secties in de doelpresentatie opnieuw aan en koppel elke bron‑dia aan de overeenkomstige doelsectie.

## **Meerdere Presentaties veilig samenvoegen**

Het volgende end‑to‑end voorbeeld gebruikt de eerste presentatie als doel, normaliseert de dia‑grootte van elke extra bron, houdt elke bron alleen open zolang deze wordt gekopieerd, en slaat het uiteindelijke bestand één keer op.

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

Dit vormt een nuttige basis voor het behouden van de bron‑opmaak van geïmporteerde dia's. Als uw output een enkel doel‑thema moet gebruiken, vervang dan de eenvoudige `addClone(slide)`‑aanroep door de eerder getoonde doel‑master‑ of doel‑lay‑out‑overload.

## **Praktische Overwegingen**

### **Masters, Layouts en Opmaak‑fideliteit**

Standaard slide‑klonen kan automatisch een vereiste bron‑master in de doelpresentatie brengen. Aspose.Slides houdt een interne registratie bij voor automatisch gekloonde masters om te voorkomen dat dezelfde master herhaaldelijk gekloond wordt. Handmatig gekloonde masters worden niet door die registratie gevolgd, dus vermijd voorafklonen van masters tenzij u expliciete controle over de master‑structuur nodig heeft.

Ga er niet van uit dat twee masters of layouts met dezelfde naam visueel gelijk zijn. Als een bedrijfs‑template de uiteindelijke uitstraling moet bepalen, kies dan expliciet een doel‑master of -layout en verifieer het resultaat na het samenvoegen.

### **Notities en Opmerkingen**

Sprekersnotities en dia‑commentaren zijn gekoppeld aan de dia‑inhoud en worden gekopieerd wanneer een dia wordt gekloond. Aspose.Slides biedt ook speciale API’s voor [presentation notes](https://docs.aspose.com/slides/nl/java/presentation-notes/) en [presentation comments](https://docs.aspose.com/slides/nl/java/presentation-comments/).

Als de opmaak van de notitie‑pagina belangrijk is, controleer dan de samengevoegde presentatie omdat notitie‑masters presentatieniveau‑objecten zijn en kunnen verschillen tussen bronbestanden. Voor review‑workflows verifieer ook de auteurs van opmerkingen en door elkaar lopende discussies na het combineren van bestanden van verschillende auteurs of templates.

### **Afbeeldingen, Audio, Video, OLE‑objecten en Externe Links**

Dia’s kunnen verwijzen naar resources op presentatieniveau, zoals afbeeldingen, ingesloten audio, ingesloten video en OLE‑data. Kloon de volledige dia in plaats van alleen de zichtbare shapes zodat Aspose.Slides de relaties van de dia met zijn resources kan behouden.

Ingesloten en gelinkte resources moeten verschillend behandeld worden. Een gelinkte audio‑, video‑, OLE‑object‑ of hyperlink blijft afhankelijk van het externe doel; het klonen van een dia verandert een externe link niet in ingesloten content. Test gelinkte pad‑ en URL‑referenties in de omgeving waarin de samengevoegde presentatie geopend zal worden.

Aspose.Slides volgt automatisch gekloonde masters, maar dit moet niet opgevat worden als een algemene garantie dat identieke binaire resources van niet‑gerelateerde bron‑presentaties altijd worden gededupliceerd. Als de bestandsgrootte van belang is, inspecteer dan het samengevoegde pakket en meet het resultaat in plaats van te vertrouwen op impliciete deduplicatie.

### **Ingesloten Lettertypen en Beschikbaarheid**

Lettertypen worden op presentatieniveau beheerd. Als typografie consistent moet blijven over verschillende machines, ga er niet van uit dat alleen dia‑klonen garandeert dat elk vereist lettertype beschikbaar is in de doenomgeving. U kunt ingesloten lettertypen inspecteren met [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) en het insluiten expliciet beheren zoals beschreven in [Embed Fonts in Presentations](https://docs.aspose.com/slides/nl/java/embedded-font/).

Controleer ook dat u toestemming heeft om de in de bronbestanden gebruikte lettertypen in te sluiten. Lettertype‑licenties kunnen insluiting beperken.

### **Wachtwoord‑beveiligde Presentaties**

Een wachtwoord‑beveiligde bron moet succesvol geopend worden voordat de dia’s gekloond kunnen worden. Geef het wachtwoord door via [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

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

Het openen van een versleutelde bron past de bescherming niet automatisch toe op de doelpresentatie. Configureer uitgaande bescherming apart wanneer dat nodig is.

### **Grote Presentaties en Geheugengebruik**

Grote presentaties met hoge‑resolutie‑afbeeldingen, audio, video of andere omvangrijke binaire objecten kunnen veel geheugen verbruiken. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) biedt instellingen voor BLOB‑afhandeling en tijdelijk‑bestandgebruik. Zie [Manage Presentation BLOBs](https://docs.aspose.com/slides/nl/java/manage-blob/) voor strategieën bij grote bestanden.

Voor grote bestanden heeft het de voorkeur om vanuit bestands‑paden te laden waar mogelijk, elke bronpresentatie te disposen zodra deze is samengevoegd, en het tussentijds opslaan van resultaten te vermijden tenzij de workflow checkpoints vereist.

### **Thread‑veiligheid**

Laad, wijzig, sla op of kloon niet dezelfde [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑instantie gelijktijdig vanuit meerdere threads. Houd elke presentatie‑instantie beperkt tot één samenvoeg‑operatie. Als u onafhankelijke taken paralleliseert, gebruik dan onafhankelijke presentatie‑instanties en volg de [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/nl/java/multithreading/).

## **FAQ**

**Hoe houd ik het oorspronkelijke ontwerp van elke bronpresentatie intact?**

Gebruik [`addClone(sourceSlide)`](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) zonder een doel‑master of -layout op te geven. Aspose.Slides kan de bron‑master automatisch klonen wanneer deze nodig is voor de geïmporteerde dia.

**Hoe laat ik geïmporteerde dia's het doel‑thema gebruiken?**

Gebruik de overload die een doel‑master accepteert. Geef een master uit de doelpresentatie door, niet uit de bron. Aspose.Slides zal proberen elke bron‑dia te koppelen aan een geschikte lay‑out onder die master.

**Wanneer moet ik een specifieke doel‑lay‑out gebruiken in plaats van een doel‑master?**

Gebruik een specifieke lay‑out wanneer elke geïmporteerde dia één bekende lay‑out moet gebruiken. Gebruik een master wanneer u wilt dat Aspose.Slides kiest uit de lay‑outs van die master op basis van het bron‑lay‑outtype of -naam.

**Kunnen presentaties met verschillende dia‑groottes samengevoegd worden?**

Ja, maar de dia‑inhoud wordt niet automatisch herschikt voor de doelafmetingen. Herschalen van de bronpresentatie eerst wanneer u voorspelbare plaatsing nodig heeft, bijvoorbeeld met [SlideSize.setSize](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesize/#setSize-float-float-int-) en [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/nl/java/com.aspose.slides/slidesizescaletype/).

**Kan ik PPT, PPTX en ODP presentaties in één bestand samenvoegen?**

Ja. Laad elke bronpresentatie, kloon de vereiste dia's naar één doelpresentatie, en sla de doelpresentatie op in een ondersteund uitvoerformaat. Omdat presentatie‑formaten niet exact dezelfde functionaliteit bieden, controleer complexe inhoud na cross‑formaat‑samenvoegingen. Zie [Supported File Formats](https://docs.aspose.com/slides/nl/java/supported-file-formats/).

**Worden bron‑secties automatisch behouden?**

Nee, niet door een eenvoudige lus die alleen dia's kloont. Maak de benodigde secties in de doelpresentatie opnieuw aan en gebruik de sectie‑overload van [addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) wanneer de sectiestructuur behouden moet blijven.

**Worden sprekersnotities en opmerkingen behouden?**

Ze worden gekopieerd met de gekloonde dia. Voor workflows die afhankelijk zijn van notitie‑master‑styling, commentauteur‑informatie of door elkaar lopende review‑data, verifieer het samengevoegde resultaat omdat deze scenario’s zowel presentatieniveau‑ als dia‑niveau‑structuren betreffen.

**Wat gebeurt er met audio, video, OLE‑objecten en hyperlinks?**

Ingesloten inhoud wordt meegenomen als onderdeel van de resource‑relaties van de gekloonde dia. Externe links blijven extern, dus hun doel‑bestanden of URL’s moeten nog steeds beschikbaar zijn na de samenvoeging.

**Zijn ingesloten lettertypen van elke bron gegarandeerd beschikbaar in de samengevoegde presentatie?**

Vertrouw niet uitsluitend op dia‑klonen voor lettertype‑distributie. Inspecteer de ingesloten lettertypen van de doelpresentatie en beheer het insluiten of de beschikbaarheid van externe lettertypen expliciet wanneer typografie belangrijk is.

**Hoe merge ik een wachtwoord‑beveiligd bestand?**

Open het met de juiste [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), kloon vervolgens de dia's zoals normaal. Uitgaande bescherming wordt afzonderlijk geconfigureerd.

**Hoe moet ik zeer grote presentaties behandelen?**

Gebruik BLOB‑beheer wanneer grote binaire objecten het geheugen belasten, laad grote bestanden bij voorkeur via bestands‑paden, dispose bronpresentaties zodra ze klaar zijn met samenvoegen, en sla het uiteindelijke resultaat alleen op wanneer nodig.

**Kan ik dia's vanuit meerdere threads samenvoegen?**

Gebruik niet één [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑instantie gelijktijdig vanuit meerdere threads. Houd elke samenvoeg‑operatie geïsoleerd in eigen presentatie‑instanties.