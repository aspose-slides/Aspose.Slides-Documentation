---
title: Hyperlinks in presentaties beheren in Java
linktitle: Hyperlinks beheren
type: docs
weight: 20
url: /nl/java/manage-hyperlinks/
keywords:
- URL toevoegen
- hyperlink toevoegen
- hyperlink maken
- hyperlink opmaken
- hyperlink verwijderen
- hyperlink bijwerken
- teksthyperlink
- diahyperlink
- vormhyperlink
- afbeeldingshyperlink
- video-hyperlink
- aanpasbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Hyperlinks toevoegen, opmaken, bijwerken en verwijderen in PowerPoint en OpenDocument-presentaties met Aspose.Slides for Java, met Java-voorbeelden."
---
## **Introductie**

Een hyperlink verbindt presentatiew inhoud met een website of een locatie binnen de presentatie. In PowerPoint dienen hyperlinks doorgaans twee doelen:

* Een website openen vanuit tekst, een vorm of een mediaraam.
* Navigeren naar een andere dia, bijvoorbeeld vanuit een inhoudsopgave.

Aspose.Slides for Java stelt je in staat om deze koppelingen toe te voegen, hun uiterlijk en geluid te regelen, hun eigenschappen bij te werken en ze te verwijderen. De voorbeelden hieronder laten zien hoe je werkt met hyperlinks op individuele elementen en hoe je hyperlinks benadert op presentatieniveau, dia‑niveau of tekst‑frame‑niveau.

{{% alert color="info" title="Note" %}}

Je kunt ook presentaties bewerken met de [gratis online Aspose PowerPoint‑editor](https://products.aspose.app/slides/nl/editor).

{{% /alert %}} 

## **URL‑hyperlinks toevoegen**

Je kunt een website‑URL toewijzen aan tekst, een vorm of een mediaraam. Het element waaraan je de hyperlink toewijst bepaalt het klikbare gebied: een tekstdeel linkt de geselecteerde tekst, terwijl een vorm of frame het dia‑object linkt.

### **URL‑hyperlinks toevoegen aan tekst**

Om tekst naar een website te linken, geef je een [Hyperlink](https://reference.aspose.com/slides/nl/java/com.aspose.slides/hyperlink/) door aan de [setHyperlinkClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-)‑methode van het tekstdeel, zoals hieronder getoond. Alleen dat tekstdeel wordt klikbaar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **URL‑hyperlinks toevoegen aan vormen en mediakaders**

Om een vorm of kader klikbaar te maken, roep je haar [setHyperlinkClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-)‑methode aan. De hyperlink behoort tot het object zelf in plaats van tot een tekstdeel erin.

Dezelfde aanpak geldt voor afbeelding‑, audio‑ en videokaders: ken de hyperlink toe aan het kader en roep, indien nodig, [setTooltip](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) aan.

Het volgende voorbeeld maakt een rechthoek klikbaar:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hyperlinks gebruiken om een inhoudsopgave te maken**

Interne hyperlinks laten lezers springen van een inhoudsopgave naar een specifieke dia. Het volgende voorbeeld gebruikt [setInternalHyperlinkClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) om de tekst “Pagina 2” op de eerste dia te linken naar de tweede dia.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hyperlinks opmaken**

### **Kleur**

De [setColorSource](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/#setColorSource-int-)‑methode van [IHyperlink](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/) bepaalt of een hyperlink de hyperlink‑kleur van de presentatie gebruikt of de opmaak van het tekstdeel. Om een aangepaste tekstkleur toe te passen, selecteer je [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/hyperlinkcolorsource/) en stel je de vulkleur van het deel in. Deze functie werd geïntroduceerd in PowerPoint 2019; oudere versies passen deze instelling niet toe.

Het volgende voorbeeld voegt twee tekst‑hyperlinks toe aan dezelfde dia. De eerste gebruikt een rode tekstvulling, de tweede behoudt de standaard hyperlink‑kleur.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Geluid**

Een hyperlink kan een geluid afspelen wanneer die wordt geactiveerd of een al lopend geluid stoppen. Gebruik de volgende methoden om dit gedrag te configureren:

- [IHyperlink.setSound](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) specificeert het audio‑bestand dat aan de hyperlink is gekoppeld.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) bepaalt of het activeren van de hyperlink het vorige geluid stopt.

#### **Een hyperlink‑geluid toevoegen**

Het volgende voorbeeld laadt `sampleaudio.wav` en koppelt het aan een knop op de eerste dia. Klikken op de knop speelt het geluid af en navigeert naar de volgende dia. Een tweede vorm op die dia stopt het vorige geluid bij een klik, zonder een navigatie‑actie uit te voeren.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.wav"));
    IAudio hyperlinkSound = presentation.getAudios().addAudio(audioData);

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **Een hyperlink‑geluid extraheren**

Het volgende voorbeeld opent de presentatie die hierboven is aangemaakt en leest het audio‑bestand van de eerste vorm via [getSound](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/#getSound--) en [getBinaryData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iaudio/#getBinaryData--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Tooltip‑ en interactie‑instellingen**

Na het toewijzen van een hyperlink aan tekst of een vorm kun je de volgende [IHyperlink](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/)‑methoden aanroepen:

- [setTooltip](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) stelt de tekst in die een kijker kan zien als hint voor de link.
- [setTargetFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) geeft het doel‑frame binnen een bovenliggende HTML‑frameset aan, indien van toepassing.
- [setHistory](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) bepaalt of het activeren van de link de bestemming toevoegt aan de lijst met bekeken hyperlinks.
- [setHighlightClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) bepaalt of de hyperlink gemarkeerd wordt bij een klik.

## **Hyperlinks uit presentaties verwijderen**

Gebruik [getAnyHyperlinks](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) om hyperlink‑containers, inclusief tekst‑deel‑links, te verzamelen voordat je ze wijzigt. Het volgende voorbeeld verwijdert beide activatietypen van de eerste dia. Om slechts één type te verwijderen, roep je alleen [removeHyperlinkClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) of [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) aan; het verwijderen van een klik‑actie verwijdert niet de bijbehorende muis‑over‑actie.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Voor onvoorwaardelijke verwijdering verwijdert [removeAllHyperlinks](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) beide activatietypen in de geselecteerde scope in één oproep. Voor selectieve opschoning en dekking van masters, lay-outs en notities, zie [Rapporteren, saniteren en verifiëren van hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Een volledige hyperlink‑inventaris opbouwen**

Voordat je een presentatie verspreidt, inventariseer je de interactieve acties en web‑koppelingen. [getAnyHyperlinks](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) retourneert [IHyperlinkContainer](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkcontainer/)‑objecten, geen platte lijst van URL‑strings. Inspecteer zowel [getHyperlinkClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) als [getHyperlinkMouseOver](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) op elke container. Ze zijn onafhankelijk: dezelfde container kan beide acties blootstellen, dus een volledig rapport heeft tot twee rijen per container nodig.

Alleen hyperlinks op vorm‑niveau scannen kan links die aan tekstdelen zijn gekoppeld missen. Vraag in plaats daarvan de juiste scope op en bewaar de teruggegeven containers zodat je later hun acties kunt bijwerken of verwijderen.

### **Presentatie‑, dia‑ en tekst‑frame‑scopes bevragen**

De [IHyperlinkQueries](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkqueries/)‑interface is beschikbaar via [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) en [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#getHyperlinkQueries--). Elke scope ondersteunt dezelfde bevragingen:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) retourneert containers met een klik‑actie.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) retourneert containers met een muis‑over‑actie.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) retourneert containers met een van beide acties.

Het volgende voorbeeld maakt `hyperlink-audit-input.pptx` met een externe klik‑link, een bestand‑muis‑over‑link, interne dia‑navigatie, een tekst‑muis‑over‑link en een macro‑actie. Het voert geen van deze acties uit. Dezelfde drie bevragingen werken op elke scope; de tellingen beschrijven containers, niet het totale aantal acties. De tekst‑frame‑scope sluit de eigen links van de omvattende vorm uit.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor dit voorbeeld geven presentatiew‑ en dia‑bevragingen elk drie klik‑containers, twee muis‑over‑containers en drie containers met een van beide acties terug. De tekst‑frame‑bevraging geeft één container in elke categorie weer.

### **Acties en bestemmingen classificeren**

Gebruik [IHyperlink.getActionType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/#getActionType--) om een actie te interpreteren voordat je de bestemming interpreteert. De waarden van [HyperlinkActionType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/hyperlinkactiontype/) omvatten meer dan alleen web‑navigatie:

| Waarden | Betekenis voor een audit |
| --- | --- |
| `Hyperlink` | Externe hyperlink; inspecteer de URL en diens schema. |
| `JumpSpecificSlide` | Interne navigatie naar een specifieke dia. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ingebouwde diavoorstelling‑navigatie, opgelost in de diavoorstelling‑context. |
| `JumpEndShow`, `StartCustomSlideShow` | Huidige show beëindigen of een aangepaste show starten. |
| `StartMacro` | Een macro uitvoeren. |
| `StartProgram` | Een programma starten. |
| `OpenFile`, `OpenPresentation` | Een bestand of een andere presentatie openen; afzonderlijk van web‑URL’s beoordelen. |
| `StartStopMedia` | Media‑afspelen starten of stoppen. |
| `NoAction`, `Unknown` | Geen navigatie‑actie, of een niet‑herkende actie die herzien moet worden. |

Lees externe bestemmingen uit via [getExternalUrl](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/#getExternalUrl--) en specifieke interne bestemmingen via [getTargetSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/#getTargetSlide--). Interne acties en ingebouwde commando’s kunnen geen externe URL hebben; een lege URL betekent niet dat de container geen actie heeft. Bewaar de waarde die wordt geretourneerd door [getExternalUrlOriginal](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) wanneer die afwijkt van de genormaliseerde URL, en voeg de tooltip toe die wordt geretourneerd door [getTooltip](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlink/#getTooltip--) indien beschikbaar.

### **Hyperlinks rapporteren, saniteren en verifiëren**

Het volgende Java‑voorbeeld leest een bestaande presentatie (gebruik het bestand dat hierboven is aangemaakt), schrijft `hyperlink-audit.json`, past een beleid toe, slaat `hyperlink-sanitized.pptx` op en opent deze opnieuw om beide activatietypen opnieuw te controleren. Het verzamelt containers vóór wijziging en gebruikt referentie‑gelijkheid om dubbele verwerking te voorkomen. Presentatie‑bevragingen bestrijken gewone dia’s; voor een volledige inventaris binnen een pakket wordt expliciet ook master‑, layout‑, notitie‑ en handout‑master‑scopes bevraagd wanneer aanwezig.

Het rapport noteert een één‑gebaseerde dia‑index en [getSlideId](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ibaseslide/#getSlideId--) waar beschikbaar. [ISlideComponent.getSlide](https://reference.aspose.com/slides/nl/java/com.aspose.slides/islidecomponent/#getSlide--) levert de bijbehorende dia voor ondersteunde containers. Masters, lay‑outs en notities hebben geen gewone dia‑index en worden geïdentificeerd door hun scope. Vorm‑containers en tekst‑deel‑opmaak‑containers worden apart gelabeld; andere containertypen behouden hun runtime‑type‑naam. Elke container krijgt een rapport‑lokale ID zodat zijn twee acties kunnen worden gekoppeld. Het rapport slaat actietypen op als de gehele getallen‑constanten gedefinieerd door de Java‑enumeratie.

Dit opzettelijk restrictieve toepassingsbeleid staat alleen absolute HTTPS‑URL’s en geldige interne dia‑doelen toe. Het wijst macro’s, programma’s, bestand‑acties, andere diavoorstelling‑acties, onbekende acties en andere URL‑schema’s af. Deze afwijzingen zijn beleids‑beslissingen, geen veiligheids­beoordeling van Aspose.Slides. Alleen HTTPS garandeert geen vertrouwen: voeg host‑allowlists en andere controles toe voor jouw toepassing. Zowel originele als genormaliseerde externe URL’s worden gecontroleerd. Het voorbeeld controleert metadata zonder links te volgen of acties uit te voeren.

Voor remediering ondersteunt de [getHyperlinkManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager-) van de container [setExternalHyperlinkClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) en [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Hier worden verboden externe klik‑links vervangen door een vaste HTTPS‑landingspagina; andere verboden klikken en verboden muis‑over‑acties worden onafhankelijk verwijderd. Stel `replaceExternalClicks` in op `false` om alle beleids‑schendingen te verwijderen. Kies een door de toepassing geleverde vervangingspagina voordat je implementeert.

De export‑vlag van het rapport hanteert een conservatief PDF‑review‑beleid: markeer muis‑over‑acties en alles wat geen externe link of specifieke dia‑sprong is als potentieel niet‑ondersteund. Het is een review‑hint, geen capaciteits‑test of garantie dat ongemarkeerde links behouden blijven bij export. Ondersteunde [PDF](/slides/nl/java/convert-powerpoint-to-pdf/)‑ en [HTML](/slides/nl/java/convert-powerpoint-to-html/)‑exporten kunnen hyperlinks behouden, afhankelijk van de actie, export‑opties en viewer. Raster‑[images](/slides/nl/java/convert-powerpoint-to-png/) en [video](/slides/nl/java/convert-powerpoint-to-video/) kunnen geen interactieve hyperlinks behouden; markeer elke actie bij audit voor die uitvoerformaten.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // Serialiseer de platte rijen van dit rapport zonder een extra JSON dependency.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + String.join(",\n", fields) + "\n  }");
        }
        return "[\n" + String.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    Files.write(Paths.get("hyperlink-audit.json"), jsonData);

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Met de hierboven gemaakte invoer bevat het rapport vijf actierijen. De bestand‑muis‑over‑link en macro‑klik worden verwijderd, terwijl de HTTPS‑links en interne dia‑navigatie behouden blijven. De verificatie geeft nul verboden acties weer. Een invoer met een verboden externe klik‑URL test ook de vervangings‑tak. Een container met een toegestane klik en een verboden muis‑over behoudt haar klik‑actie.

Deze selectieve opschoning verschilt van [removeAllHyperlinks](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), die beide activatietypen in de geselecteerde scope verwijdert ongeacht beleid. Verificatie hier controleert uitsluitend hyperlink‑acties; het verwijdert geen ingebedde VBA‑projecten, OLE‑objecten of andere actieve content, en het valideert geen geëxporteerd PDF‑ of HTML‑bestand.

## **FAQ**

**Hoe kan ik naar een sectie of de eerste dia daarvan linken?**

Secties in PowerPoint groeperen dia’s, maar een interne hyperlink richt zich op een afzonderlijke dia. Om naar een sectie te navigeren, link je naar de eerste dia in die sectie.

**Kan ik een hyperlink aan master‑dia‑elementen koppelen zodat deze op alle dia’s werkt?**

Ja. Elementen van master‑dia’s en lay‑outs ondersteunen hyperlinks. Links op deze elementen zijn beschikbaar tijdens de diavoorstelling op dia’s die de betreffende master of lay‑out gebruiken.

**Worden hyperlinks behouden bij export naar PDF, HTML, afbeeldingen of video?**

Ondersteunde PDF‑ en HTML‑exporten kunnen hyperlinks behouden; raster‑afbeeldingen en video kunnen dat niet. Zie de export‑overwegingen in [Rapporteren, saniteren en verifiëren van hyperlinks](#report-sanitize-and-verify-hyperlinks).