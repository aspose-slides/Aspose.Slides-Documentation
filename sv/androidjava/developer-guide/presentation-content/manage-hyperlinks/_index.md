---
title: Hantera presentationens hyperlänkar på Android
linktitle: Hantera hyperlänkar
type: docs
weight: 20
url: /sv/androidjava/manage-hyperlinks/
keywords:
- lägg till URL
- lägg till hyperlänk
- skapa hyperlänk
- formatera hyperlänk
- ta bort hyperlänk
- uppdatera hyperlänk
- text‑hyperlänk
- bild‑hyperlänk
- formhyperlänk
- bildhyperlänk
- video‑hyperlänk
- modifierbar hyperlänk
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Lägg till, formatera, uppdatera och ta bort hyperlänkar i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Android via Java, med Java‑exempel."
---
## **Introduktion**

En hyperlänk kopplar presentationsinnehåll till en webbplats eller en plats inom presentationen. I PowerPoint används hyperlänkar vanligtvis för två ändamål:

* Öppna en webbplats från text, en form eller en mediaram.
* Navigera till en annan bild, till exempel från en innehållsförteckning.

Aspose.Slides for Android via Java låter dig lägga till dessa länkar, kontrollera deras utseende och ljud, uppdatera deras egenskaper och ta bort dem. Exemplen nedan visar hur du arbetar med hyperlänkar på enskilda element och hur du får åtkomst till hyperlänkar på presentations-, bild- eller text‑ramnivå.

{{% alert color="info" title="Note" %}}

Du kan även redigera presentationer med den [gratis online Aspose PowerPoint‑redigeraren](https://products.aspose.app/slides/sv/editor).

{{% /alert %}} 

## **Lägg till URL‑hyperlänkar**

Du kan tilldela en webbplats‑URL till text, en form eller en mediaram. Det element du tilldelar hyperlänken bestämmer det klickbara området: en textdel länkar den markerade texten, medan en form eller ram länkar till bildobjektet.

### **Lägg till URL‑hyperlänkar till text**

För att länka text till en webbplats, skicka en [Hyperlink](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/hyperlink/) till textdelens [setHyperlinkClick](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metod, som visas nedan. Endast den delen av texten blir klickbar.

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

### **Lägg till URL‑hyperlänkar till former och mediaramar**

För att göra en form eller ram klickbar, anropa dess [setHyperlinkClick](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) metod. Hyperlänken tillhör själva objektet snarare än en textdel inuti det.

Samma tillvägagångssätt gäller för bild-, ljud‑ och videoram: tilldela hyperlänken till ramen och anropa [setTooltip](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) om det behövs.

Följande exempel gör en rektangel klickbar:

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

## **Använd hyperlänkar för att skapa en innehållsförteckning**

Interna hyperlänkar låter läsare hoppa från en innehållsförteckning till en specifik bild. Följande exempel använder [setInternalHyperlinkClick](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) för att länka texten ”Page 2” på den första bilden till den andra bilden.

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

## **Formatera hyperlänkar**

### **Färg**

Metoden [setColorSource](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) i [IHyperlink](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/) bestämmer om en hyperlänk använder presentationens hyperlänkfärg eller textdelens formatering. För att tillämpa en anpassad textfärg, välj [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/hyperlinkcolorsource/) och ange delens fyllningsfärg. Denna funktion introducerades i PowerPoint 2019; äldre versioner tillämpar inte denna inställning.

Följande exempel lägger till två text‑hyperlänkar på samma bild. Den första använder en röd textfyllning, medan den andra behåller standardhyperlänkfärgen.

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
### **Ljud**

En hyperlänk kan spela upp ett ljud när den aktiveras eller stoppa ett ljud som redan spelas. Använd följande metoder för att konfigurera dessa beteenden:

- [IHyperlink.setSound](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) anger det ljud som är kopplat till hyperlänken.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) styr om aktivering av hyperlänken stoppar det föregående ljudet.

#### **Lägg till ett hyperlänkljud**

Följande exempel läser in `sampleaudio.wav` och kopplar den till en knapp på den första bilden. När knappen klickas spelas ljudet upp och man navigerar till nästa bild. En annan form på samma bild stoppar det föregående ljudet när den klickas, utan att utföra någon navigationsåtgärd.

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

#### **Extrahera ett hyperlänkljud**

Följande exempel öppnar presentationen som skapades ovan och läser den första formens hyperlänkljud till minnet via [getSound](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/#getSound--) och [getBinaryData](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

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

### **Tooltip‑ och interaktionsinställningar**

Du kan anropa följande [IHyperlink](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/) metoder efter att du har tilldelat en hyperlänk till text eller en form:

- [setTooltip](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) anger den text som en betraktare kan visa som en ledtråd för länken.
- [setTargetFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) anger målramen inom ett föräldra‑HTML‑ramverk, när tillämpligt.
- [setHistory](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) styr om aktivering av länken lägger till dess destination i listan över visade hyperlänkar.
- [setHighlightClick](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) styr om hyperlänken markeras när den klickas.

## **Ta bort hyperlänkar från presentationer**

Använd [getAnyHyperlinks](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) för att samla hyperlänkbehållare, inklusive textdelslänkar, innan du ändrar dem. Följande exempel tar bort båda aktiveringstyperna från den första bilden. För att ta bort endast en typ, anropa bara [removeHyperlinkClick](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) eller [removeHyperlinkMouseOver](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); att ta bort en klickåtgärd tar inte bort motsvarande mus‑över‑åtgärd.

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

För villkorslös borttagning tar [removeAllHyperlinks](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) bort båda aktiveringstyperna i det valda omfånget i ett anrop. För selektiv rensning och täckning av master‑bilder, layouter och anteckningar, se [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Bygg ett komplett hyperlänk‑inventarium**

Innan du distribuerar en presentation, inventera dess interaktiva åtgärder samt dess webb‑länkar. [getAnyHyperlinks](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) returnerar [IHyperlinkContainer](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkcontainer/)‑objekt, inte en platt lista med URL‑strängar. Inspektera både [getHyperlinkClick](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) och [getHyperlinkMouseOver](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) för varje behållare. De är oberoende: samma behållare kan exponera båda åtgärderna, så en komplett rapport kan behöva upp till två rader per behållare.

Att bara skanna hyperlänkar på formnivå kan missa länkar som är kopplade till textdelar. Fråga istället rätt omfång, och behåll de returnerade behållarna så att du senare kan uppdatera eller ta bort deras åtgärder.

### **Fråga presentations‑, bild‑ och text‑ram‑omfång**

Gränssnittet [IHyperlinkQueries](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkqueries/) finns tillgängligt via [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) och [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Varje omfång stöder samma frågor:

- [getHyperlinkClicks](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) returnerar behållare med en klickåtgärd.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) returnerar behållare med en mus‑över‑åtgärd.
- [getAnyHyperlinks](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) returnerar behållare med antingen eller båda åtgärderna.

Följande exempel skapar `hyperlink-audit-input.pptx` med en extern klicklänk, en fil‑mus‑över‑länk, intern bildnavigering, en text‑mus‑över‑länk och en makroåtgärd. Det utför ingen av dessa åtgärder. Samma tre frågor fungerar i varje omfång; räknarna beskriver behållare, inte totalsummor av åtgärder. Text‑ram‑omfånget exkluderar den omgivande formens egna länkar.

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

För detta exempel rapporterar presentations‑ och bild‑frågor vardera tre klickbehållare, två mus‑över‑behållare och tre behållare med antingen åtgärd. Text‑ram‑frågan rapporterar en behållare i varje kategori.

### **Klassificera åtgärder och destinationer**

Använd [IHyperlink.getActionType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/#getActionType--) för att tolka en åtgärd innan du tolkar dess destination. Värdena i [HyperlinkActionType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/hyperlinkactiontype/) täcker mer än webbnavigation:

| Värden | Betydelse för en granskning |
| --- | --- |
| `Hyperlink` | Extern hyperlänk; inspektera URL:en och dess schema. |
| `JumpSpecificSlide` | Intern navigering till en specifik bild. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Inbyggd bildspelsnavigering, löses i bildspelskontext. |
| `JumpEndShow`, `StartCustomSlideShow` | Avsluta det aktuella bildspelet eller starta ett anpassat bildspel. |
| `StartMacro` | Kör ett makro. |
| `StartProgram` | Starta ett program. |
| `OpenFile`, `OpenPresentation` | Öppna en fil eller en annan presentation; granska separat från webbadresser. |
| `StartStopMedia` | Starta eller stoppa mediaplayback. |
| `NoAction`, `Unknown` | Ingen navigeringsåtgärd, eller en okänd åtgärd som kräver granskning. |

Läs externa destinationer från [getExternalUrl](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) och specifika interna destinationer från [getTargetSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Interna åtgärder och inbyggda kommandon kan sakna extern URL; en tom URL betyder inte att behållaren saknar åtgärd. Bevara värdet som returneras av [getExternalUrlOriginal](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) när det skiljer sig från den normaliserade URL:en, och inkludera tooltip‑texten som returneras av [getTooltip](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) när den finns.

### **Rapportera, sanera och verifiera hyperlänkar**

Följande Java‑exempel läser en befintlig presentation (använd filen som skapades ovan), skriver `hyperlink-audit.json`, tillämpar en policy, sparar `hyperlink-sanitized.pptx` och öppnar den igen för att kontrollera båda aktiveringstyperna igen. Det samlar behållare innan de ändras och använder referensjämförelse för att undvika att bearbeta samma behållare två gånger. Presentations‑frågor täcker vanliga bilder; för ett paketomfattande inventarium frågar det också explicit master‑bilder, layouter, anteckningar samt antecknings‑ och utdelnings‑master‑bilder när de finns.

Rapporten registrerar ett ett‑baserat bildindex och [getSlideId](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) där det finns. [ISlideComponent.getSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecomponent/#getSlide--) tillhandahåller den ägande bilden för stödda behållare. Master‑bilder, layouter och anteckningar har inget ordinärt bildindex och identifieras efter deras omfång. Formbehållare och text‑del‑formateringsbehållare märks separat; andra behållartyper behåller sitt kör‑tids‑typnamn. Varje behållare får ett rapport‑lokalt ID så att dess två åtgärder kan korreleras. Rapporten lagrar åtgärdstyper som de heltalskonstanter som definieras av Java‑enumerationen.

Denna medvetet restriktiva applikationspolicy tillåter endast absoluta HTTPS‑URL:er och giltiga interna bildmål. Den avvisar makron, program, filåtgärder, andra bildspelsåtgärder, okända åtgärder och andra URL‑scheman. Dessa avslag är policybeslut, inte ett Aspose.Slides‑säkerhetsbetyg. Enbart HTTPS etablerar inte förtroende: lägg till värd‑tillåtlistor och andra kontroller för din applikation. Både original‑ och normaliserade externa URL:er kontrolleras. Exemplet granskar metadata utan att följa länkar eller köra åtgärder.

För åtgärd, stödjer behållarens [getHyperlinkManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) [setExternalHyperlinkClick](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) och [removeHyperlinkMouseOver](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Här ersätts förbjudna externa klicklänkar med en fast HTTPS‑landningssida; andra förbjudna klick och förbjudna mus‑över‑åtgärder tas bort oberoende. Sätt `replaceExternalClicks` till `false` för att istället ta bort alla policyöverträdelser. Välj en applikationsägd ersättningssida innan distribution.

Rapportens exportflagga använder en konservativ PDF‑granskningspolicy: flagga mus‑över‑åtgärder och allt annat än en extern länk eller specifik bildhopprörelse som potentiellt icke‑stödd. Det är en granskningshint, inte ett kapacitetstest eller en garanti för att oflagade länkar överlever export. Stödda [PDF](/slides/sv/androidjava/convert-powerpoint-to-pdf/) och [HTML](/slides/sv/androidjava/convert-powerpoint-to-html/) exporter kan bevara hyperlänkar, beroende på åtgärd, exportalternativ och visare. Raster‑[images](/slides/sv/androidjava/convert-powerpoint-to-png/) och [video](/slides/sv/androidjava/convert-powerpoint-to-video/) kan inte bevara interaktiva hyperlänkar; flagga varje åtgärd vid granskning för dessa utdata.

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

    // Serialisera detta rapports platta rader utan ett extra JSON-beroende.
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

Med den input som skapades ovan innehåller rapporten fem åtgärdsrader. Fil‑mus‑över‑länken och makroklicken tas bort, medan HTTPS‑länkarna och intern bildnavigering förblir. Verifieringen skriver ut noll förbjudna åtgärder. En input som innehåller en förbjuden extern klick‑URL utnyttjar också ersättningsgrenen. En behållare med ett tillåtet klick och ett förbjudet mus‑över‑åtgärd behåller sin klickåtgärd.

Denna selektiva rensning skiljer sig från [removeAllHyperlinks](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) som tar bort båda aktiveringstyperna i hela det valda omfånget oavsett policy. Verifieringen här kontrollerar endast hyperlänkåtgärder; den tar inte bort inbäddade VBA‑projekt, OLE‑objekt eller annat aktivt innehåll, och den validerar inte en exporterad PDF‑ eller HTML‑fil.

## **FAQ**

**Hur kan jag länka till ett avsnitt eller dess första bild?**

Avsnitt i PowerPoint grupperar bilder, men en intern hyperlänk riktar sig till en enskild bild. För att skapa navigering till ett avsnitt, länka till den första bilden i det avsnittet.

**Kan jag fästa en hyperlänk till master‑bild‑element så att den fungerar på alla bilder?**

Ja. Master‑bild‑ och layout‑element stödjer hyperlänkar. Länkar på dessa element är tillgängliga under bildspelet på bilder som använder motsvarande master‑ eller layout.

**Kommer hyperlänkar att bevaras vid export till PDF, HTML, bilder eller video?**

Stödda PDF‑ och HTML‑exporter kan bevara hyperlänkar; raster‑bilder och video kan inte. Se export‑överväganden i [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).