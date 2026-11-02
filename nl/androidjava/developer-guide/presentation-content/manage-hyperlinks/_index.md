---
title: Hyperlinks in presentatie beheren op Android
linktitle: Hyperlinks beheren
type: docs
weight: 20
url: /nl/androidjava/manage-hyperlinks/
keywords:
- URL toevoegen
- hyperlink toevoegen
- hyperlink maken
- hyperlink opmaken
- hyperlink verwijderen
- hyperlink bijwerken
- tekst‑hyperlink
- dia‑hyperlink
- vorm‑hyperlink
- afbeelding‑hyperlink
- video‑hyperlink
- bewerkbare hyperlink
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Voeg hyperlinks toe, formatteer, werk bij en verwijder hyperlinks in PowerPoint- en OpenDocument‑presentaties met Aspose.Slides voor Android via Java, met Java‑voorbeelden."
---
## **Introductie**

Een hyperlink verbindt presentatiewaarde met een website of een locatie binnen de presentatie. In PowerPoint dienen hyperlinks doorgaans twee doelen:

* Open een website vanuit tekst, een vorm of een mediakader.
* Navigeer naar een andere dia, bijvoorbeeld vanuit een inhoudsopgave.

Aspose.Slides for Android via Java laat u deze koppelingen toevoegen, hun uiterlijk en geluid regelen, hun eigenschappen bijwerken en ze verwijderen. De onderstaande voorbeelden tonen hoe u met hyperlinks werkt op afzonderlijke elementen en hoe u hyperlinks benadert op presentatieniveau, dia‑niveau of tekstkader‑niveau.

{{% alert color="info" title="Note" %}}
U kunt ook presentaties bewerken met de [gratis online Aspose PowerPoint editor](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **URL‑hyperlinks toevoegen**

U kunt een website‑URL toewijzen aan tekst, een vorm of een mediakader. Het element waaraan u de hyperlink toewijst bepaalt het klikbare gebied: een tekstgedeelte koppelt de geselecteerde tekst, terwijl een vorm of kader het dia‑object koppelt.

Voor presentaties met relatieve hyperlinks, zie [Beheer de hyperlinkbasis](/slides/nl/androidjava/presentation-properties/#manage-the-hyperlink-base) om de document‑niveau basis te lezen, te wijzigen of te wissen.

### **URL‑hyperlinks toevoegen aan tekst**

Om tekst te koppelen aan een website, geeft u een [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlink/) door aan de tekstgedeelte’s [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) methode, zoals hieronder weergegeven. Alleen dat tekstgedeelte wordt klikbaar.

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

Om een vorm of kader klikbaar te maken, roept u de [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) methode aan. De hyperlink behoort tot het object zelf en niet tot een tekstgedeelte erin.

Dezelfde aanpak geldt voor foto‑, audio‑ en videokaders: wijs de hyperlink toe aan het kader en roep [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) aan indien nodig.

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

Interne hyperlinks laten lezers springen van een inhoudsopgave naar een specifieke dia. Het volgende voorbeeld gebruikt [setInternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) om de tekst “Page 2” op de eerste dia te koppelen aan de tweede dia.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

De [setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) methode van [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) bepaalt of een hyperlink de hyperlinkkleur van de presentatie of de opmaak van het tekstgedeelte gebruikt. Om een aangepaste tekstkleur toe te passen, selecteert u [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkcolorsource/) en stelt u de vulkleur van het gedeelte in. Deze functie werd geïntroduceerd in PowerPoint 2019; oudere versies passen deze instelling niet toe.

Het volgende voorbeeld voegt twee tekst‑hyperlinks toe aan dezelfde dia. De eerste gebruikt een rode tekstvulling, terwijl de tweede de standaard hyperlinkkleur behoudt.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Een hyperlink kan een geluid afspelen wanneer hij wordt geactiveerd of een al afspelend geluid stoppen. Gebruik de volgende methoden om dit gedrag te configureren:

- [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) specificeert het audio dat aan de hyperlink is gekoppeld.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) bepaalt of het activeren van de hyperlink het vorige geluid stopt.

#### **Hyperlinksound toevoegen**

Het volgende voorbeeld laadt `sampleaudio.wav` en koppelt het aan een knop op de eerste dia. Klikken op de knop speelt het geluid af en navigeert naar de volgende dia. Een tweede vorm op die dia stopt het vorige geluid wanneer erop geklikt wordt, zonder een navigatie‑actie uit te voeren.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

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

#### **Hyperlinksound extraheren**

Het volgende voorbeeld opent de hierboven gemaakte presentatie en leest het hyperlink‑audio van de eerste vorm in het geheugen via [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getSound--) en [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

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

### **Tooltip‑ en interactiesettings**

U kunt de volgende [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) methoden aanroepen nadat u een hyperlink aan tekst of een vorm hebt toegewezen:

- [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) stelt de tekst in die een kijker kan weergeven als hint voor de link.
- [setTargetFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) specificeert het doelframe binnen een bovenliggend HTML‑frameset, indien van toepassing.
- [setHistory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) bepaalt of het activeren van de link de bestemming toevoegt aan de lijst met bekeken hyperlinks.
- [setHighlightClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) bepaalt of de hyperlink gemarkeerd wordt wanneer erop geklikt wordt.

## **Hyperlinks uit presentaties verwijderen**

Gebruik [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) om hyperlink‑containers, inclusief tekstgedeelte‑links, te verzamelen voordat u ze wijzigt. Het volgende voorbeeld verwijdert beide activatietypen van de eerste dia. Om slechts één type te verwijderen, roep alleen [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) of [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) aan; het verwijderen van een klik‑actie verwijdert de muis‑over‑tegenhanger niet.

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

Voor onvoorwaardelijke verwijdering verwijdert [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) beide activatietypen in de geselecteerde scope in één oproep. Voor selectieve opschoning en dekking van masters, lay‑outs en notities, zie [Rapporteren, saneren en verifiëren van hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Een volledige hyperlinkinventaris opbouwen**

Voordat u een presentatie verspreidt, dient u de interactieve acties en de web‑links te inventariseren. [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) levert [IHyperlinkContainer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/) objecten op, niet een platte lijst van URL‑strings. Inspecteer zowel [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) als [getHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) op elke container. Ze zijn onafhankelijk: dezelfde container kan beide acties bevatten, dus een volledig rapport heeft tot twee rijen per container nodig.

Het scannen van alleen shape‑niveau hyperlinks kan links die aan tekstgedeelten zijn gekoppeld missen. Vraag in plaats daarvan de juiste scope op en bewaar de teruggegeven containers zodat u later hun acties kunt bijwerken of verwijderen.

### **Scope van presentatie, dia en tekstkader opvragen**

De [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/) interface is beschikbaar via [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), en [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Elke scope ondersteunt dezelfde queries:

- [getHyperlinkClicks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) geeft containers terug met een klikactie.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) geeft containers terug met een muis‑over‑actie.
- [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) geeft containers terug met een van beide of beide acties.

Het volgende voorbeeld maakt `hyperlink-audit-input.pptx` met een externe klik‑link, een bestand‑muisto‑over‑link, interne dia‑navigatie, een tekst‑muisto‑over‑link en een macro‑actie. Het voert geen van deze acties uit. Dezelfde drie queries werken in elke scope; de tellingen beschrijven containers, niet het aantal acties. De tekstkader‑scope sluit de eigen links van de omvattende vorm uit.

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

Voor dit voorbeeld rapporteren presentatie‑ en dia‑queries elk drie klik‑containers, twee muisto‑over‑containers en drie containers met een van beide acties. De tekstkader‑query rapporteert één container in elke categorie.

### **Acties en bestemmingen classificeren**

Gebruik [IHyperlink.getActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getActionType--) om een actie te interpreteren vóór het interpreteren van de bestemming. De [HyperlinkActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkactiontype/) waarden bestrijken meer dan web‑navigatie:

| Waarden | Betekenis voor een audit |
| --- | --- |
| `Hyperlink` | Externe hyperlink; inspecteer de URL en het schema. |
| `JumpSpecificSlide` | Interne navigatie naar een specifieke dia. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ingebouwde diavoorstellingsnavigatie, opgelost in de context van de diavoorstelling. |
| `JumpEndShow`, `StartCustomSlideShow` | Beëindig de huidige show of start een aangepaste show. |
| `StartMacro` | Voer een macro uit. |
| `StartProgram` | Start een programma. |
| `OpenFile`, `OpenPresentation` | Open een bestand of een andere presentatie; bekijk apart van web‑URL’s. |
| `StartStopMedia` | Start of stop het afspelen van media. |
| `NoAction`, `Unknown` | Geen navigatieactie, of een niet‑herkende actie die beoordeling vereist. |

Lees externe bestemmingen uit [getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) en specifieke interne bestemmingen uit [getTargetSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Interne acties en ingebouwde opdrachten kunnen geen externe URL hebben; een lege URL betekent niet dat de container geen actie heeft. Bewaar de waarde die wordt geretourneerd door [getExternalUrlOriginal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) wanneer die verschilt van de genormaliseerde URL, en neem de tooltip mee die door [getTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) wordt geretourneerd wanneer beschikbaar.

### **Rapporteren, saneren en verifiëren van hyperlinks**

Het volgende Java‑voorbeeld leest een bestaande presentatie (gebruik het bestand dat hierboven is gemaakt), schrijft `hyperlink-audit.json`, past een beleid toe, slaat `hyperlink-sanitized.pptx` op en opent het opnieuw om beide activatietypen opnieuw te controleren. Het verzamelt containers voordat ze worden gewijzigd en gebruikt referentie‑gelijkheid om te voorkomen dat dezelfde container twee keer wordt verwerkt. Presentatie‑queries bestrijken gewone dia’s; voor een pakket‑brede inventaris vraagt het ook expliciet masters, lay‑outs, notities en de notitie‑ en handout‑masters wanneer aanwezig.

Het rapport registreert een één‑gebaseerde dia‑index en [getSlideId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) waar beschikbaar. [ISlideComponent.getSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecomponent/#getSlide--) levert de bijbehorende dia voor ondersteunde containers. Masters, lay‑outs en notities hebben geen gewone dia‑index en worden geïdentificeerd door hun scope. Shape‑containers en tekst‑gedeelte‑opmaak‑containers worden apart gelabeld; andere containertypen behouden hun runtime‑type‑naam. Elke container krijgt een rapport‑lokale ID zodat de twee acties kunnen worden gecorreleerd. Het rapport slaat actietypen op als de gehele constante‑waarden gedefinieerd door de Java‑enumeratie.

Dit opzettelijk restrictieve toepassingsbeleid staat alleen absolute HTTPS‑URL’s en geldige interne dia‑doelen toe. Het wijst macro’s, programma’s, bestand‑acties, andere diavoorstellingsacties, onbekende acties en andere URL‑schema’s af. Deze afwijzingen zijn beleids‑beslissingen, geen veiligheids‑beoordeling van Aspose.Slides. HTTPS alleen legt geen vertrouwen; voeg host‑allow‑lists en andere controles toe voor uw toepassing. Zowel originele als genormaliseerde externe URL’s worden gecontroleerd. Het voorbeeld controleert metadata zonder links te volgen of acties uit te voeren.

Voor herstel ondersteunt de container’s [getHyperlinkManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) [setExternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) en [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Hier worden verboden externe klik‑links vervangen door een vaste HTTPS‑landingspagina; andere verboden klikken en verboden muisto‑over‑acties worden onafhankelijk verwijderd. Stel `replaceExternalClicks` in op `false` om alle beleids­schendingen te verwijderen. Kies een door de applicatie beheerde vervangingspagina vóór implementatie.

De export‑vlag van het rapport gebruikt een conservatief PDF‑review‑beleid: markeer muisto‑over‑acties en alles behalve een externe link of een specifieke dia‑sprong als potentieel on‑ondersteund. Het is een beoordelingshint, geen capaciteits‑test of garantie dat niet‑gemarkeerde links de export overleven. Ondersteunde [PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/) en [HTML](/slides/nl/androidjava/convert-powerpoint-to-html/) exports kunnen hyperlinks behouden, afhankelijk van de actie, exportopties en viewer. Raster [afbeeldingen](/slides/nl/androidjava/convert-powerpoint-to-png/) en [video](/slides/nl/androidjava/convert-powerpoint-to-video/) kunnen interactieve hyperlinks niet behouden; markeer elke actie bij het auditen voor die uitvoerformaten.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
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

    // Serialiseer de platte rijen van dit rapport zonder extra JSON‑afhankelijkheid.
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
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
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
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

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

Met de hierboven gemaakte invoer bevat het rapport vijf actierijen. De bestand‑muisto‑over‑link en macro‑klik worden verwijderd, terwijl de HTTPS‑links en interne dia‑navigatie blijven. De verificatie geeft nul verboden acties weer. Een invoer met een verboden externe klik‑URL doorloopt ook de vervangings‑tak. Een container met een toegestane klik en een verboden muisto‑over behoudt zijn klik‑actie.

Deze selectieve opschoning verschilt van [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), dat beide activatietypen verwijdert in de geselecteerde scope ongeacht het beleid. Verificatie hier controleert alleen hyperlink‑acties; het verwijdert geen ingebedde VBA‑projecten, OLE‑objecten of andere actieve inhoud, en het valideert geen geëxporteerde PDF‑ of HTML‑bestanden.

## **FAQ**

**Hoe kan ik linken naar een sectie of de eerste dia ervan?**

Secties in PowerPoint groeperen dia’s, maar een interne hyperlink richt zich op een individuele dia. Om navigatie naar een sectie te maken, linkt u naar de eerste dia in die sectie.

**Kan ik een hyperlink toevoegen aan elementen van de masterdia zodat deze werkt op alle dia’s?**

Ja. Master‑dia‑ en lay‑outelementen ondersteunen hyperlinks. Links op deze elementen zijn beschikbaar tijdens de diavoorstelling op dia’s die de corresponderende master of lay‑out gebruiken.

**Worden hyperlinks behouden bij export naar PDF, HTML, afbeeldingen of video?**

Ondersteunde PDF‑ en HTML‑exports kunnen hyperlinks behouden; raster‑afbeeldingen en video kunnen dat niet. Zie de export‑overwegingen in [Rapporteren, saneren en verifiëren van hyperlinks](#report-sanitize-and-verify-hyperlinks).