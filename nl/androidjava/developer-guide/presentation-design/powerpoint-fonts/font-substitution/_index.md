---
title: Lettertype‑substitutie configureren in presentaties op Android
linktitle: Lettertype‑substitutie
type: docs
weight: 70
url: /nl/androidjava/font-substitution/
keywords:
- lettertype
- vervangend lettertype
- lettertype‑substitutie
- lettertype vervangen
- lettertype‑vervanging
- substitutieregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Configureer regels voor lettertype‑substitutie en inspecteer ge‑substitueerde lettertypen in Aspose.Slides voor Android via Java bij het renderen of converteren van presentaties."
---
## **Overzicht**

Lettertype‑substitutie stelt Aspose.Slides in staat een beschikbaar lettertype te gebruiken in plaats van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De substitutie heeft invloed op de gegenereerde uitvoer; het wijzigt niet het lettertype dat aan de presentatietekst is toegewezen.

U kunt het te gebruiken lettertype definiëren wanneer een specifiek lettertype niet beschikbaar is, en u kunt de substituties bekijken die Aspose.Slides tijdens het renderen zal uitvoeren. Dit helpt om de uitvoer consistent te houden op Android‑apparaten en omgevingen met verschillende beschikbare lettertypen.

Als een lettertype beschikbaar is maar geen eigen vet typeface heeft, zie dan [Lettertypen zonder eigen vet typeface](/slides/nl/androidjava/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Die sectie legt uit hoe u de betreffende tekst rastert tijdens PDF‑export en welke gevolgen dat heeft voor tekstselectie, zoeken en schalen.

## **Lettertype‑substituties ophalen**

Gebruik de [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--)‑methode om te bepalen welke lettertypen worden vervangen wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/)‑objecten die de oorspronkelijke en vervangende lettertype‑namen identificeren.

Het volgende Java‑voorbeeld geeft alle lettertype‑substituties voor een presentatie weer:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Lettertype‑substituties ophalen voor geselecteerde dia’s**

Gebruik de [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---)‑overload met een `int[] slides`‑argument om alleen de substituties te inspecteren die nodig zijn om specifieke dia’s te renderen. Dit is nuttig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia’s zoekt die afhankelijk zijn van ontbrekende lettertypen, een minimale lettertype‑package voor een Android‑app voorbereidt, of weergaveverschillen diagnosticeert zonder ongerelateerde dia’s te verwerken.

De `slides`‑array bevat één‑gebaseerde dia‑indexen: `1` identificeert de eerste dia. Daarentegen gebruikt de [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--)‑collectietoegang nulgebaseerde indexering, zodat dezelfde dia wordt benaderd als `presentation.getSlides().get_Item(0)`. Houd dit verschil in gedachten bij het bouwen van de array om “off‑by‑one” fouten te vermijden.

Roep de overload aan via de [Presentation.getFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getFontsManager--)‑methode. Deze retourneert alleen de substituties die zijn bepaald tijdens het renderen van de geselecteerde dia’s. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstitutioninfo/)‑object dat de oorspronkelijke en vervangende lettertype‑namen bevat. Het resultaat weerspiegelt de huidige lettertype‑omgeving, geconfigureerde fallback‑regels, substitutieregels opgeslagen in een [IFontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsubstrulecollection/), en [extern geladen lettertypen](/slides/nl/androidjava/custom-font/).

Dezelfde substitutie kan vereist zijn door meer dan één geselecteerde dia. Dupliceer de resultaten niet wanneer u een lettertype‑inventaris of pre‑flight‑rapport maakt. Het volgende voorbeeld geeft elke geretourneerde substitutie weer en maakt vervolgens een gesorteerde lijst van unieke lettertype‑koppelingen:

```java
import com.aspose.slides.FontSubstitutionInfo;
import com.aspose.slides.Presentation;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.TreeSet;

Presentation presentation = new Presentation("Presentation.pptx");
try {
    int[] selectedSlides = { 1, 3, 5 };
    List<FontSubstitutionInfo> substitutions = new ArrayList<>();
    for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions(selectedSlides)) {
        substitutions.add(substitution);
    }

    System.out.println("Substitutions for the selected slides:");
    for (FontSubstitutionInfo substitution : substitutions) {
        System.out.println(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }

    Set<String> sortedPreflightEntries = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
    for (FontSubstitutionInfo substitution : substitutions) {
        String entry = substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
        sortedPreflightEntries.add(entry);
    }

    System.out.println("Deduplicated font preflight report:");
    for (String entry : sortedPreflightEntries) {
        System.out.println(entry);
    }
} finally {
    presentation.dispose();
}
```

De [IFontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/)‑interface biedt beide overloads. Kies er één op basis van de reikwijdte van de render‑operatie:

| Overload | Gebruik wanneer |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) zonder argumenten | U hebt substituties nodig voor de volledige presentatie. |
| [getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) met `int[] slides` | U hebt substituties nodig voor een geselecteerd bereik, incrementele controle of gedeeltelijke export. |

## **Lettertype‑substitutieregels instellen**

Om het lettertype op te geven dat Aspose.Slides moet gebruiken wanneer een bronlettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities voor het bron‑ en vervangende lettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/) met de [WhenInaccessible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstcondition/)‑conditie.
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrulecollection/).
5. Wijs de collectie toe via de [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-)‑methode.
6. Render of converteer de presentatie.

Het volgende Java‑voorbeeld vervangt `Arial` door `SomeRareFont` wanneer `SomeRareFont` niet beschikbaar is, en rendert vervolgens de eerste dia om het resultaat te verifiëren. Het vervangende lettertype moet beschikbaar zijn voor Aspose.Slides.

```java
import com.aspose.slides.FontData;
import com.aspose.slides.FontSubstCondition;
import com.aspose.slides.FontSubstRule;
import com.aspose.slides.FontSubstRuleCollection;
import com.aspose.slides.IFontData;
import com.aspose.slides.IFontSubstRule;
import com.aspose.slides.IFontSubstRuleCollection;
import com.aspose.slides.IImage;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("Fonts.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData substituteFont = new FontData("Arial");
    IFontSubstRule substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection substitutionRules = new FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    IImage image = presentation.getSlides().get_Item(0).getImage(1f, 1f);
    try {
        image.save("slide.jpg", ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Voor een onvoorwaardelijke wijziging van de lettertypen die door de hele presentatie worden gebruikt, zie [Lettertypevervanging](/slides/nl/androidjava/font-replacement/).
{{% /alert %}}

## **Beperkingen voor wiskundige‑equatie‑lettertypen**

Lettertype‑substitutieregels maken deel uit van het standaardlettertype‑selectieproces dat wordt gebruikt tijdens renderen en converteren. Ze werken voor gewone tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat in een regel is opgegeven.

Office‑Math‑equaties hebben een extra eis. Als een vergelijking **Cambria Math** gebruikt, heeft Aspose.Slides dat exacte lettertype nodig om de lay‑out van de vergelijking te berekenen en te renderen. Een regel die een ander wiskundig lettertype vervangt, zoals **STIX Two Math**, kan **Cambria Math** hiervoor niet vervangen, en de rendering kan nog steeds melden dat **Cambria Math** vereist is.

Om zo’n presentatie te renderen of te converteren, maakt u **Cambria Math** beschikbaar voor Aspose.Slides. Laad het als een [extern lettertype](/slides/nl/androidjava/custom-font/) zodat de toepassing het kan gebruiken tijdens renderen en converteren.

Deze beperking heeft betrekking op de lay‑out van vergelijkingen. De hierboven beschreven substitutieregels blijven wel van toepassing op reguliere presentatietekst.

## **FAQ**

**Wat is het verschil tussen lettertypevervanging en lettertype‑substitutie?**

[Lettertypevervanging](/slides/nl/androidjava/font-replacement/) verandert bewust één lettertype in een ander door de hele presentatie heen. Lettertype‑substitutie kiest een lettertype voor de gerenderde uitvoer wanneer aan de geconfigureerde voorwaarde wordt voldaan, bijvoorbeeld wanneer het oorspronkelijke lettertype niet beschikbaar is.

**Wanneer worden substitutieregels toegepast?**

De regels nemen deel aan de [lettertype‑selectiesequentie](/slides/nl/androidjava/font-selection-sequence/) tijdens renderen en converteren. Met `WhenInaccessible` wordt een regel alleen gebruikt wanneer Aspose.Slides geen toegang heeft tot het bronlettertype.

**Wat gebeurt er als een lettertype ontbreekt en er geen substitutieregel is geconfigureerd?**

Aspose.Slides selecteert het meest overeenkomende beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de lettertypen die beschikbaar zijn in de runtime‑omgeving.

**Kan ik externe lettertypen laden om substitutie te voorkomen?**

Ja. U kunt [externe lettertypen laden](/slides/nl/androidjava/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens renderen en converteren.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U bent verantwoordelijk voor het leveren van lettertypen en het naleven van hun licenties.

**Kunnen substitutieresultaten verschillen tussen Android‑apparaten?**

Ja. Beschikbare systeemlettertypen kunnen verschillen tussen Android‑versies, apparaten en fabrikanten, waardoor een lettertype dat in de ene omgeving beschikbaar is, in een andere moet worden vervangen.

**Hoe kan ik de lettertype‑selectie consistent maken over Android‑apparaten heen?**

Pakte dezelfde vereiste lettertype‑bestanden met de toepassing, [laadt ze als externe lettertypen](/slides/nl/androidjava/custom-font/), en [embed lettertypen](/slides/nl/androidjava/embedded-font/) wanneer licenties dit toelaten. U kunt ook [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) aanroepen vóór export om onverwachte substituties te identificeren.