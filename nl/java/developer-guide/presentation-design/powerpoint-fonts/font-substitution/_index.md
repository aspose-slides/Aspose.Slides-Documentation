---
title: Lettertype‑substitutie configureren in presentaties met Java
linktitle: Lettertype‑substitutie
type: docs
weight: 70
url: /nl/java/font-substitution/
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
- Java
- Aspose.Slides
description: "Configureer regels voor lettertype‑substitutie en inspecteer gesubstitueerde lettertypen in Aspose.Slides voor Java bij het renderen of converteren van PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Lettertype‑substitutie maakt het mogelijk dat Aspose.Slides een beschikbaar lettertype gebruikt ter vervanging van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De substitutie heeft invloed op de gegenereerde uitvoer; het verandert het toegewezen lettertype van de presentatie‑inhoud niet.

U kunt het te gebruiken lettertype definiëren wanneer een bepaald lettertype niet beschikbaar is, en u kunt de substituties bekijken die Aspose.Slides tijdens het renderen zal uitvoeren. Dit helpt om de uitvoer consistent te houden tussen omgevingen met verschillende geïnstalleerde lettertypen.

## **Lettertype‑substituties ophalen**

Gebruik de [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) methode om te bepalen welke lettertypen worden gesubstitueerd wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsubstitutioninfo/) objecten die de oorspronkelijke en gesubstitueerde lettertype­namen identificeren.

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

## **Lettertype‑substituties voor geselecteerde dia's ophalen**

Gebruik de [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) overload met een `int[] slides` argument om alleen de substituties te bekijken die nodig zijn om specifieke dia's te renderen. Dit is handig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia's zoekt die afhankelijk zijn van niet‑beschikbare lettertypen, een minimaal lettertype‑pakket voor een server of container voorbereidt, of rendering‑verschillen diagnosticeert zonder ongerelateerde dia's te verwerken.

De `slides`‑array bevat één‑gebaseerde dia‑indexen: `1` verwijst naar de eerste dia. Daarentegen gebruikt de [Presentation.getSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSlides--) collectietoegang nul‑gebaseerde indexering, zodat dezelfde dia wordt opgevraagd als `presentation.getSlides().get_Item(0)`. Houd dit verschil in gedachten bij het opbouwen van de array om off‑by‑one‑fouten te voorkomen.

Roep de overload aan via de [Presentation.getFontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getFontsManager--) methode. Deze retourneert alleen de substituties die zijn bepaald tijdens het renderen van de geselecteerde dia's. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsubstitutioninfo/) object dat de oorspronkelijke en gesubstitueerde lettertype­namen bevat. Het resultaat weerspiegelt de huidige lettertype‑omgeving, geconfigureerde fallback‑regels, en [extern geladen lettertypen](/slides/nl/java/custom-font/). Substitutieregels die zijn opgeslagen in een [IFontSubstRuleCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsubstrulecollection/) worden toegepast wanneer de presentatie wordt gerenderd, maar het resultaat toont ze niet; controleer in plaats daarvan de lettertypen in het uitvoerbestand.

Dezelfde substitutie kan door meer dan één geselecteerde dia vereist zijn. De‑duplicateer de resultaten wanneer u een lettertype‑inventaris of preflight‑rapport maakt. Het volgende voorbeeld rapporteert elke teruggegeven substitutie en maakt vervolgens een gesorteerde lijst van unieke lettertype‑koppelingen:

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

De [IFontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/) interface biedt beide overload‑varianten. Kies er één afhankelijk van de reikwijdte van de render‑operatie:

| Overload | Gebruik wanneer |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | U heeft substituties nodig voor de volledige presentatie. |
| [getSubstitutions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | U heeft substituties nodig voor een geselecteerd bereik, incrementele controle, of gedeeltelijke export. |

## **Lettertype‑substitutieregels instellen**

Om het lettertype op te geven dat Aspose.Slides moet gebruiken wanneer een bronlettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities voor het bron‑ en vervangende lettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsubstrule/) met de [WhenInaccessible](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsubstcondition/) voorwaarde.
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsubstrulecollection/).
5. Wijs de collectie toe met de [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) methode.
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
Voor een onvoorwaardelijke wijziging van de lettertypen die door de hele presentatie worden gebruikt, zie [Font Replacement](/slides/nl/java/font-replacement/).
{{% /alert %}}

## **Beperkingen voor wiskundige vergelijking‑lettertypen**

Lettertype‑substitutieregels maken deel uit van het standaard lettertype‑selectieproces dat wordt gebruikt tijdens renderen en converteren. Ze werken voor gewone tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat door een regel is gespecificeerd.

Office‑Math‑vergelijkingen hebben een extra vereiste. Als een vergelijking **Cambria Math** gebruikt, kan Aspose.Slides dat exacte lettertype nodig hebben om de lay‑out van de vergelijking te berekenen en te renderen. Een regel die een ander wiskundig lettertype vervangt, zoals **STIX Two Math**, kan **Cambria Math** voor dit doel niet vervangen, en het renderen kan nog steeds melden dat **Cambria Math** vereist is.

Om zo’n presentatie te renderen of te converteren, maak **Cambria Math** beschikbaar voor Aspose.Slides. Installeer het in het besturingssysteem of laad het als een [extern lettertype](/slides/nl/java/custom-font/).

Deze beperking is van toepassing op de layout van vergelijkingen. De hierboven beschreven substitutieregels blijven van toepassing op gewone presentatie‑tekst.

## **FAQ**

**Wat is het verschil tussen lettertype‑vervanging en lettertype‑substitutie?**

[Font replacement](/slides/nl/java/font-replacement/) wijzigt opzettelijk een lettertype door een ander gedurende de hele presentatie. Lettertype‑substitutie selecteert een lettertype voor de gerenderde uitvoer wanneer aan de geconfigureerde voorwaarde wordt voldaan, bijvoorbeeld wanneer het originele lettertype niet beschikbaar is.

**Wanneer worden substitutieregels toegepast?**

De regels nemen deel aan de [font selection sequence](/slides/nl/java/font-selection-sequence/) tijdens renderen en converteren. Met `WhenInaccessible` wordt een regel alleen gebruikt wanneer Aspose.Slides geen toegang heeft tot het bronlettertype.

**Wat gebeurt er wanneer een lettertype ontbreekt en er geen substitutieregel is geconfigureerd?**

Aspose.Slides selecteert het meest passende beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de lettertypen die beschikbaar zijn in de runtime‑omgeving.

**Kan ik externe lettertypen laden om substitutie te voorkomen?**

Ja. U kunt [extern lettertypen laden](/slides/nl/java/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens het renderen en converteren.

**Levert Aspose lettertypen mee met de bibliotheek?**

Nee. U bent zelf verantwoordelijk voor het leveren van lettertypen en het respecteren van hun licenties.

**Kunnen substitutieresultaten verschillen tussen Windows, Linux en macOS?**

Ja. Geïnstalleerde lettertypen en locaties waarnaar gezocht wordt verschillen per besturingssysteem, waardoor een lettertype dat op de ene machine beschikbaar is, op een andere mogelijk moet worden gesubstitueerd.

**Hoe kan ik de lettertype‑selectie consistent maken bij batch‑conversies?**

Gebruik dezelfde lettertype‑bestanden en -versies op elke machine of container, [vereiste externe lettertypen laden](/slides/nl/java/custom-font/), en [lettertypen insluiten](/slides/nl/java/embedded-font/) wanneer de licentie dat toestaat. U kunt ook [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) aanroepen vóór het exporteren om onverwachte substituties te identificeren.