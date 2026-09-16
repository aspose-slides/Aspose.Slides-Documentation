---
title: Beheer presentatielinks op Android
linktitle: Beheer hyperlinks
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
  - tekshyperlink
  - diahyperlink
  - vormhyperlink
  - afbeeldingshyperlink
  - videohyperlink
  - wijzigbare hyperlink
  - PowerPoint
  - OpenDocument
  - presentatie
  - Android
  - Java
  - Aspose.Slides
description: "Voeg hyperlinks toe, formatteer, werk bij en verwijder hyperlinks in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android via Java, met Java-voorbeelden."
---
## **Inleiding**

Een hyperlink verbindt presentatiewaarde aan een website of een locatie binnen de presentatie. In PowerPoint dienen hyperlinks meestal twee doeleinden:

* Een website openen vanuit tekst, een vorm of een mediaraam.
* Navigeren naar een andere dia, bijvoorbeeld vanuit een inhoudsopgave.

Aspose.Slides for Android via Java stelt u in staat om deze links toe te voegen, hun uiterlijk en geluid te beheren, hun eigenschappen bij te werken en ze te verwijderen. De onderstaande voorbeelden laten zien hoe u met hyperlinks op afzonderlijke elementen kunt werken en hoe u hyperlinks kunt benaderen op presentatieniveau, dia- of tekstkaderniveau.

{{% alert color="info" title="Note" %}}
U kunt presentaties ook bewerken met de [gratis online Aspose PowerPoint-editor](https://products.aspose.app/slides/nl/editor).
{{% /alert %}} 

## **URL-hyperlinks toevoegen**

U kunt een website‑URL toewijzen aan tekst, een vorm of een mediaraam. Het element waaraan u de hyperlink toekent, bepaalt het klikbare gebied: een tekstdelen koppelt de geselecteerde tekst, terwijl een vorm of raam het dia‑object koppelt.

### **URL-hyperlinks toevoegen aan tekst**

Om tekst aan een website te koppelen, geeft u een [Hyperlink](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/hyperlink/) door aan de [setHyperlinkClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) methode van het tekstdelen, zoals hieronder weergegeven. Alleen dat tekstdelen wordt klikbaar.

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

### **URL-hyperlinks toevoegen aan vormen en mediakaders**

Om een vorm of kader klikbaar te maken, roept u de [setHyperlinkClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) methode aan. De hyperlink behoort tot het object zelf in plaats van tot een tekstdelen erin.

Dezelfde aanpak geldt voor afbeelding-, audio- en videokaders: wijs de hyperlink toe aan het kader en roep indien nodig [setTooltip](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) aan.

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

Interne hyperlinks stellen lezers in staat om van een inhoudsopgave naar een specifieke dia te springen. Het volgende voorbeeld gebruikt [setInternalHyperlinkClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) om de tekst “Page 2” op de eerste dia te koppelen aan de tweede dia.

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

De [setColorSource](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) methode van [IHyperlink](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/) bepaalt of een hyperlink de hyperlink‑kleur van de presentatie gebruikt of de opmaak van het tekstdelen. Om een aangepaste tekstkleur toe te passen, selecteert u [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/hyperlinkcolorsource/) en stelt u de opvulkleur van het deel in. Deze functie werd geïntroduceerd in PowerPoint 2019; oudere versies passen deze instelling niet toe.

Het volgende voorbeeld voegt twee tekshyperlinks toe aan dezelfde dia. De eerste gebruikt een rode tekstopvulling, terwijl de tweede de standaard hyperlink‑kleur behoudt.

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

Een hyperlink kan een geluid afspelen wanneer geactiveerd of een reeds afspelend geluid stoppen. Gebruik de volgende methoden om dit gedrag te configureren:

- [IHyperlink.setSound](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) specificeert het audio‑bestand dat aan de hyperlink is gekoppeld.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) bepaalt of het activeren van de hyperlink het eerdere geluid stopt.

#### **Een hyperlinkgeluid toevoegen**

Het volgende voorbeeld laadt `sampleaudio.wav` en koppelt het aan een knop op de eerste dia. Klikken op de knop speelt het geluid af en navigeert naar de volgende dia. Een tweede vorm op die dia stopt het eerdere geluid bij een klik, zonder een navigatie‑actie uit te voeren.

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

#### **Een hyperlinkgeluid extraheren**

Het volgende voorbeeld opent de hierboven gemaakte presentatie en leest het hyperlink‑audio van de eerste vorm in het geheugen via [getSound](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/#getSound--) en [getBinaryData](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

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

U kunt de volgende [IHyperlink](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/) methoden aanroepen nadat u een hyperlink aan tekst of een vorm hebt toegewezen:

- [setTooltip](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) stelt de tekst in die een kijker als hint voor de link kan weergeven.
- [setTargetFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) specificeert het doel‑frame binnen een bovenliggend HTML‑frameset, indien van toepassing.
- [setHistory](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) bepaalt of het activeren van de link de bestemming toevoegt aan de lijst van bekeken hyperlinks.
- [setHighlightClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) bepaalt of de hyperlink wordt gemarkeerd bij een klik.

## **Hyperlinks uit presentaties verwijderen**

Gebruik [getAnyHyperlinks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) om hyperlink‑containers te verzamelen, inclusief tekst‑deel‑links, voordat u ze wijzigt. Het volgende voorbeeld verwijdert beide activerings‑typen van de eerste dia. Om slechts één type te verwijderen, roep alleen [removeHyperlinkClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) of [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) aan; het verwijderen van een klik‑actie verwijdert niet de bijbehorende muis‑over‑actie.

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

Voor onvoorwaardelijke verwijdering verwijdert [removeAllHyperlinks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) beide activerings‑typen in de geselecteerde reikwijdte in één oproep. Voor selectieve opschoning en dekking van masters, lay-outs en notities, zie [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Een volledige hyperlink‑inventaris bouwen**

Voordat u een presentatie verspreidt, maakt u een inventaris van de interactieve acties en web‑links. [getAnyHyperlinks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) retourneert objecten van het type [IHyperlinkContainer](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkcontainer/), niet een platte lijst met URL‑strings. Inspecteer zowel [getHyperlinkClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) als [getHyperlinkMouseOver](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) op elke container. Ze zijn onafhankelijk: dezelfde container kan beide acties bevatten, dus een volledig rapport heeft tot twee rijen per container nodig.

Alleen hyperlinks op vormniveau scannen kan links die aan tekstdelen zijn gekoppeld missen. Vraag in plaats daarvan de juiste scope op en bewaar de geretourneerde containers zodat u later hun acties kunt bijwerken of verwijderen.

### **Presentatie‑, dia‑ en tekstkader‑scopes bevragen**

De [IHyperlinkQueries](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkqueries/) interface is beschikbaar via [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) en [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Elke scope ondersteunt dezelfde queries:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) retourneert containers met een klik‑actie.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) retourneert containers met een muis‑over‑actie.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) retourneert containers met één of beide acties.

Het volgende voorbeeld maakt `hyperlink-audit-input.pptx` met een externe klik‑link, een bestands‑muistoever‑link, interne diavernavigatie, een tekst‑muistoever‑link en een macro‑actie. Het voert geen van deze acties uit. Dezelfde drie queries werken in elke scope; de tellingen beschrijven containers, niet het aantal acties. De tekst‑kader‑scope sluit de eigen links van het omvattende vorm uit.

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

Voor dit voorbeeld rapporteren presentatie‑ en dia‑queries elk drie klik‑containers, twee muis‑over‑containers en drie containers met een van beide acties. De tekst‑kader‑query rapporteert één container in elke categorie.

### **Acties en bestemmingen classificeren**

Gebruik [IHyperlink.getActionType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/#getActionType--) om een actie te interpreteren voordat u de bestemming interpreteert. De waarden van [HyperlinkActionType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/hyperlinkactiontype/) omvatten meer dan web‑navigatie:

| Waarden | Betekenis voor een audit |
| --- | --- |
| `Hyperlink` | Externe hyperlink; inspecteer de URL en het schema. |
| `JumpSpecificSlide` | Interne navigatie naar een specifieke dia. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Ingebouwde diavoorstelling‑navigatie, opgelost in de diavoorstelling‑context. |
| `JumpEndShow`, `StartCustomSlideShow` | Beëindig de huidige show of start een aangepaste show. |
| `StartMacro` | Voer een macro uit. |
| `StartProgram` | Start een programma. |
| `OpenFile`, `OpenPresentation` | Open een bestand of een andere presentatie; bekijk apart van web‑URL’s. |
| `StartStopMedia` | Start of stop mediaplayback. |
| `NoAction`, `Unknown` | Geen navigatie‑actie, of een niet‑herkende actie die herzien moet worden. |

Lees externe bestemmingen uit via [getExternalUrl](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) en specifieke interne bestemmingen via [getTargetSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Interne acties en ingebouwde commando’s hebben mogelijk geen externe URL; een lege URL betekent niet dat de container geen actie heeft. Bewaar de waarde die [getExternalUrlOriginal](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) retourneert wanneer deze afwijkt van de genormaliseerde URL, en neem de tooltip op die [getTooltip](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) teruggeeft wanneer beschikbaar.

### **Hyperlinks rapporteren, zuiveren en verifiëren**

Het volgende Java‑voorbeeld leest een bestaande presentatie (gebruik het hierboven gemaakte bestand), schrijft `hyperlink-audit.json`, past een beleid toe, slaat `hyperlink-sanitized.pptx` op en opent het opnieuw om beide activerings‑typen opnieuw te controleren. Het verzamelt containers vóór dat ze worden gewijzigd en gebruikt referentie‑gelijkheid om te voorkomen dat dezelfde container tweemaal wordt verwerkt. Presentatie‑queries omvatten gewone dia’s; voor een pakket‑brede inventarisie queryt het bovendien expliciet masters, lay-outs, notities en de notitie‑ en handout‑masters indien aanwezig.

Het rapport legt een één‑gebaseerde dia‑index en [getSlideId](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) vast waar beschikbaar. [ISlideComponent.getSlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecomponent/#getSlide--) levert de bezit‑dia voor ondersteunde containers. Masters, lay-outs en notities hebben geen gewone dia‑index en worden geïdentificeerd op basis van hun scope. Vorm‑containers en tekstdelen‑opmaak‑containers worden apart gelabeld; andere containertypen behouden hun runtime‑typenaam. Elke container krijgt een rapport‑lokale ID zodat de twee acties kunnen worden gecorreleerd. Het rapport slaat actietypen op als de gehele getal‑constanten gedefinieerd door de Java‑enumeratie.

Dit opzettelijk restrictieve toepassingsbeleid staat alleen absolute HTTPS‑URL’s en geldige interne dia‑doelen toe. Het wijst macro’s, programma’s, bestandsacties, andere diavoorstelling‑acties, onbekende acties en andere URL‑schema’s af. Deze afwijzingen zijn beleidsbeslissingen, geen veiligheids‑beoordeling van Aspose.Slides. Alleen HTTPS biedt geen vertrouwen: voeg host‑toelatingslijsten en andere controles toe voor uw toepassing. Zowel originele als genormaliseerde externe URL’s worden gecontroleerd. Het voorbeeld auditeert metadata zonder links te volgen of acties uit te voeren.

Voor correctie ondersteunt de container's [getHyperlinkManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) [setExternalHyperlinkClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) en [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Hier worden verboden externe klik‑links vervangen door een vaste HTTPS‑landingspagina; andere verboden klikken en verboden muis‑over‑acties worden onafhankelijk verwijderd. Stel `replaceExternalClicks` in op `false` om alle beleids­schendingen te verwijderen. Kies een door de applicatie beheerde vervangingspagina vóór implementatie.

De export‑vlag van het rapport gebruikt een conservatief PDF‑review‑beleid: markeer muis‑over‑acties en alles wat geen externe link of specifieke diavlucht is als potentieel onondersteund. Het is een review‑hint, geen test van mogelijkheden of garantie dat ongemarkeerde links behouden blijven bij export. Ondersteunde [PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/) en [HTML](/slides/nl/androidjava/convert-powerpoint-to-html/) exports kunnen hyperlinks behouden, afhankelijk van de actie, exportopties en viewer. Raster‑[beelden](/slides/nl/androidjava/convert-powerpoint-to-png/) en -[video](/slides/nl/androidjava/convert-powerpoint-to-video/) kunnen geen interactieve hyperlinks behouden; markeer elke actie bij het auditen voor die output.

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

    // Serialiseer de platte rijen van dit rapport zonder extra JSON afhankelijkheid.
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

Met de hierboven gemaakte invoer bevat het rapport vijf actierijen. De bestands‑muistoever‑link en de macro‑klik worden verwijderd, terwijl de HTTPS‑links en interne dia‑navigatie behouden blijven. De verificatie geeft nul verboden acties weer. Een invoer met een verboden externe klik‑URL doorloopt ook de vervangings‑tak. Een container met een toegestane klik en een verboden muis‑over behoudt zijn klik‑actie.

Deze selectieve opschoning verschilt van [removeAllHyperlinks](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), die beide activerings‑typen verwijdert in de geselecteerde scope, ongeacht het beleid. Verificatie controleert hier alleen hyperlink‑acties; het verwijdert geen ingesloten VBA‑projecten, OLE‑objecten of andere actieve inhoud, en valideert geen geëxporteerd PDF‑ of HTML‑bestand.

## **FAQ**

**Hoe kan ik naar een sectie of de eerste dia ervan linken?**

Secties in PowerPoint groeperen dia’s, maar een interne hyperlink richt zich op één enkele dia. Om navigatie naar een sectie te maken, linkt u naar de eerste dia in die sectie.

**Kan ik een hyperlink aan elementen van de masterslide koppelen zodat deze op alle dia’s werkt?**

Ja. Elementen van de masterslide en lay-out ondersteunen hyperlinks. Links op deze elementen zijn beschikbaar tijdens de diavoorstelling op dia’s die de overeenkomstige master of lay-out gebruiken.

**Worden hyperlinks behouden wanneer geëxporteerd naar PDF, HTML, afbeeldingen of video?**

Ondersteunde PDF‑ en HTML‑exports kunnen hyperlinks behouden; raster‑afbeeldingen en video kunnen dat niet. Zie de export‑overwegingen in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).