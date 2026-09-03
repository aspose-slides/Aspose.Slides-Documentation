---
title: Insluiten van lettertypen in presentaties in Java
linktitle: Ingesloten lettertypen
type: docs
weight: 40
url: /nl/java/embedded-font/
keywords:
- lettertype toevoegen
- lettertype insluiten
- insluiten van lettertype
- ingesloten lettertype ophalen
- ingesloten lettertype toevoegen
- ingesloten lettertype verwijderen
- ingesloten lettertype comprimeren
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Beheer ingesloten lettertypen in PowerPoint met Aspose.Slides voor Java. Voeg lettertypen toe, haal ze op, verwijder en comprimeer ze om de uitstraling van de tekst te behouden en de bestandsgrootte te verkleinen."
---
## **Inleiding**

Ingebedde lettertypen slaan lettertype‑gegevens op in een PowerPoint‑presentatie. Wanneer een viewer ingebedde lettertypen ondersteunt, kan hij tekst weergeven met die lettertypen, zelfs als ze niet op het doelsysteem geïnstalleerd zijn. Dit helpt de regeleinden, tekstspatiëring en lay‑out van de dia te behouden.

Aspose.Slides for Java laat je ingebedde lettertypen ophalen, toevoegen en verwijderen via de [IFontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/)‑interface die wordt geretourneerd door [Presentation.getFontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getFontsManager--). Je kunt ook de grootte van ingebedde lettertype‑gegevens verkleinen door tekens te verwijderen die de presentatie niet gebruikt.

De onderstaande voorbeelden werken met PPTX‑bestanden. Zorg er vóór het inbedden van een lettertype voor dat de lettertype‑gegevens beschikbaar zijn voor Aspose.Slides en dat de licentie het inbedden toestaat.

## **Ingebedde lettertypen ophalen en verwijderen**

Gebruik [getEmbeddedFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) om de lettertypen die in een presentatie zijn opgeslagen te tonen. Om er één te verwijderen, geef een lettertype uit die lijst door aan [removeEmbeddedFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-), en sla vervolgens de presentatie op.

Het volgende voorbeeld toont de ingebedde lettertypen in `EmbeddedFonts.pptx` en verwijdert Calibri als dat aanwezig is:

```java
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    for (IFontData font : embeddedFonts) {
        System.out.println(font.getFontName());
    }

    IFontData fontToRemove = null;
    for (IFontData font : embeddedFonts) {
        if ("Calibri".equalsIgnoreCase(font.getFontName())) {
            fontToRemove = font;
            break;
        }
    }

    if (fontToRemove != null) {
        fontsManager.removeEmbeddedFont(fontToRemove);
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Calibri is not embedded. No output file was created.");
    }
} finally {
    presentation.dispose();
}
```

Het verwijderen van een ingebed lettertype verwijdert de opgeslagen lettertype‑gegevens; het verandert het toegewezen lettertype van de tekst niet. Als het lettertype op het doelsysteem geïnstalleerd is, kan de tekst het nog steeds gebruiken. Anders kan er tijdens het weergeven [lettertypevervanging](/slides/nl/java/font-substitution/) nodig zijn, wat de lay‑out kan beïnvloeden.

## **Lettertype‑gegevens en inbed‑permissies inspecteren**

Gebruik de [IFontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/)‑interface om lettertypen te inspecteren voordat je ze inbedt. Roep [IFontsManager.getFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getFonts--) aan om de in de presentatie gebruikte lettertypen op te halen. Voor elk lettertype geef je een [IFontData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontdata/)‑object en de vereiste [FontStyleType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontstyletype/)‑waarde door aan [IFontsManager.getFontBytes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getFontBytes-com.aspose.slides.IFontData-int-). De methode retourneert de binaire gegevens voor die lettertype‑stijl, of `null` wanneer het gevraagde lettertype of de stijl niet beschikbaar is. Geef geen `null`‑resultaat door aan [IFontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getFontEmbeddingLevel-byte---java.lang.String-), omdat die methode een byte‑array vereist.

[EmbeddingLevel](https://reference.aspose.com/slides/nl/java/com.aspose.slides/embeddinglevel/) is een flags‑enumeratie die de inbed‑restricties in het lettertype meldt:

- `Installable` staat inbedden en permanente installatie op een ander systeem toe, afhankelijk van de licentie van het lettertype.
- `Restricted` verbiedt inbedden tenzij toestemming verkregen is van de juridische eigenaar van het lettertype wanneer het de enige permissie‑flag is.
- `PreviewPrint` staat tijdelijk gebruik toe voor weergave en afdrukken; een document dat dit lettertype bevat moet alleen‑lezen zijn.
- `Editable` staat tijdelijk gebruik toe en maakt het mogelijk het document te bewerken en op te slaan.
- `NoSubsetting` is een extra restrictie die het inbedden van slechts een deel van de glyphs verbiedt. Inbed alle tekens wanneer deze flag aanwezig is.
- `BitmapOnly` is een extra restrictie die alleen bitmap‑strikes toestaat om in te bedden, geen contour‑gegevens. Als het lettertype geen bitmap‑strikes heeft, kan het niet worden ingesloten.

De eerste vier waarden beschrijven de gebruikspermissie, terwijl `NoSubsetting` en `BitmapOnly` ermee gecombineerd kunnen worden. Controleer de modifiers met bitwise‑operaties. Omdat `Installable` nul is, maskeer je de gebruikspermissie‑bits en vergelijk je het resultaat met `Installable` in plaats van het als een flag te testen. Huidige lettertypen zouden hoogstens één gebruikspermissie‑bit moeten hebben. Voor compatibiliteit met oudere lettertypen die er meer dan één instellen, selecteert de helper hieronder de minst beperkende permissie: `Editable`, daarna `PreviewPrint`, daarna `Restricted`.

Het volgende voorbeeld controleert de gewone, vet, cursief en vet‑cursief‑gegevens die beschikbaar zijn voor elk lettertype dat wordt geretourneerd door `getFonts`. Het slaat onbeschikbare stijlen, beperkte lettertypen, alleen‑bitmap‑lettertypen, lettertypen beperkt tot preview en print (omdat de output bewerkbaar blijft) en al ingebedde lettertypen over. Als een beschikbare stijl `NoSubsetting` heeft, wordt voor die lettertypefamilie in alle tekens ingesloten.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.EmbeddingLevel;
import com.aspose.slides.FontStyleType;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Locale;
import java.util.Set;

class EmbeddingPermission {
    int getUsagePermission(int level) {
        int permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
        int permissions = level & permissionMask;

        if ((permissions & EmbeddingLevel.Editable) != 0) {
            return EmbeddingLevel.Editable;
        }

        if ((permissions & EmbeddingLevel.PreviewPrint) != 0) {
            return EmbeddingLevel.PreviewPrint;
        }

        if ((permissions & EmbeddingLevel.Restricted) != 0) {
            return EmbeddingLevel.Restricted;
        }

        return EmbeddingLevel.Installable;
    }
}

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    int[] fontStyles = {
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic
    };

    Set<String> embeddedFontNames = new HashSet<String>();
    for (IFontData embeddedFont : fontsManager.getEmbeddedFonts()) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    EmbeddingPermission permissionHelper = new EmbeddingPermission();
    List<IFontData> fontsToEmbed = new ArrayList<IFontData>();
    List<Integer> embeddingRules = new ArrayList<Integer>();
    for (IFontData font : fontsManager.getFonts()) {
        if (embeddedFontNames.contains(font.getFontName().toLowerCase(Locale.ROOT))) {
            System.out.println(font.getFontName() + ": already embedded.");
            continue;
        }

        boolean hasAvailableData = false;
        boolean allAvailableStylesCanBeEmbedded = true;
        boolean previewPrintOnly = false;
        boolean requiresFullFont = false;

        for (int fontStyle : fontStyles) {
            byte[] fontBytes = fontsManager.getFontBytes(font, fontStyle);
            if (fontBytes == null) {
                System.out.println(font.getFontName() + " (" + fontStyle + "): font data is unavailable.");
                continue;
            }

            hasAvailableData = true;
            int embeddingLevel = fontsManager.getFontEmbeddingLevel(fontBytes, font.getFontName());
            int usagePermission = permissionHelper.getUsagePermission(embeddingLevel);
            boolean noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
            boolean bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

            requiresFullFont |= noSubsetting;
            previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
            allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

            System.out.println(font.getFontName() + " (" + fontStyle + "): " + embeddingLevel + ".");
        }

        if (!hasAvailableData) {
            System.out.println(font.getFontName() + ": skipped because no requested style is available.");
        } else if (!allAvailableStylesCanBeEmbedded) {
            System.out.println(font.getFontName() + ": skipped because at least one available style does not permit outline embedding.");
        } else if (previewPrintOnly) {
            System.out.println(font.getFontName() + ": skipped because this example produces an editable presentation.");
        } else {
            int rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
            fontsToEmbed.add(font);
            embeddingRules.add(rule);
        }
    }

    for (int i = 0; i < fontsToEmbed.size(); i++) {
        fontsManager.addEmbeddedFont(fontsToEmbed.get(i), embeddingRules.get(i));
    }

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Deze inspectie rapporteert de beperkingen die in elk lettertype‑bestand gecodeerd zijn. Het verleent geen licentie, bewijst niet dat je het lettertype legaal verkregen hebt, en vervangt niet de controle van de licentieovereenkomst van het lettertype vóór het distribueren van een ingebed exemplaar.

## **Ingebedde lettertypen toevoegen**

Gebruik [addEmbeddedFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) om een lettertype in te sluiten. De overloads accepteren ofwel een [IFontData](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontdata/)‑object of een byte‑array met de lettertype‑gegevens. De [EmbedFontCharacters](https://reference.aspose.com/slides/nl/java/com.aspose.slides/embedfontcharacters/)‑enumeratie bepaalt welke tekens worden opgenomen:

- [All](https://reference.aspose.com/slides/nl/java/com.aspose.slides/embedfontcharacters/) sluit alle tekens in het lettertype in. Gebruik deze optie wanneer ontvangers de presentatie moeten kunnen bewerken en nieuwe tekst moeten invoeren.
- [OnlyUsed](https://reference.aspose.com/slides/nl/java/com.aspose.slides/embedfontcharacters/) sluit alleen de in de presentatie gebruikte tekens in om de bestandsgrootte te verkleinen. Kies deze optie voor een afgewerkte presentatie die primair bedoeld is voor weergave.

Het volgende voorbeeld gebruikt [getFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getFonts--) om de in `Fonts.pptx` gebruikte lettertypen op te halen en voegt die toe die nog niet ingebed zijn. De toe te voegen lettertypen moeten beschikbaar zijn op de machine die de code uitvoert. Bestaande ingebedde lettertypen behouden hun huidige tekenverzamelingen.

```java
import com.aspose.slides.EmbedFontCharacters;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontsManager;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.util.HashSet;
import java.util.Locale;
import java.util.Set;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontsManager fontsManager = presentation.getFontsManager();
    IFontData[] allFonts = fontsManager.getFonts();
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();
    Set<String> embeddedFontNames = new HashSet<String>();

    for (IFontData embeddedFont : embeddedFonts) {
        embeddedFontNames.add(embeddedFont.getFontName().toLowerCase(Locale.ROOT));
    }

    for (IFontData font : allFonts) {
        String fontName = font.getFontName().toLowerCase(Locale.ROOT);
        if (!embeddedFontNames.contains(fontName)) {
            fontsManager.addEmbeddedFont(font, EmbedFontCharacters.All);
            embeddedFontNames.add(fontName);
        }
    }

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ingebedde lettertypen comprimeren**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/nl/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) verkleint ingebedde lettertype‑gegevens door ongebruikte tekens te verwijderen. Het werkt op lettertypen die al ingebed zijn, dus de grootte‑reductie hangt af van hoeveel ongebruikte lettertype‑gegevens de presentatie bevat.

Het volgende voorbeeld comprimeert de lettertypen in `EmbeddedFonts.pptx` en slaat het resultaat op als een apart bestand:

```java
import com.aspose.slides.Compress;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress.compressEmbeddedFonts(presentation);
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bewaar het originele bestand als ontvangers later tekst moeten kunnen toevoegen. Tekens die tijdens compressie zijn verwijderd, zijn niet langer beschikbaar vanuit het ingebedde lettertype, zelfs als je oorspronkelijk alle tekens had ingesloten.

## **FAQ**

**Hoe kan ik controleren of een ingebed lettertype nog steeds wordt vervangen tijdens het renderen?**

Roep [getSubstitutions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) aan in de omgeving waarin je de presentatie rendert om te zien welke lettertypen Aspose.Slides zal vervangen. Controleer ook de instellingen voor [lettertypevervanging](/slides/nl/java/font-substitution/) en de regels voor [lettertypefallback](/slides/nl/java/fallback-font/). Fallback behandelt ontbrekende tekens, dus inbedden lost geen tekens op die het lettertype zelf niet bevat.

**Moet ik algemene lettertypen zoals Arial en Calibri inbedden?**

Baseer de beslissing op de doelomgeving. Als de vereiste lettertypen op elke machine die de presentatie opent of rendert beschikbaar zijn, kan inbedden onnodige bestandsgrootte toevoegen. Als ontvangers of servers die lettertypen mogelijk missen, kan inbedden helpen de beoogde weergave te behouden, mits hun licenties dit toestaan.