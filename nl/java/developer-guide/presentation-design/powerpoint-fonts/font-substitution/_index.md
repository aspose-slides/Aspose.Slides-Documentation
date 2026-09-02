---
title: Lettertypevervanging configureren in presentaties met Java
linktitle: Lettertypevervanging
type: docs
weight: 70
url: /nl/java/font-substitution/
keywords:
- lettertype
- vervangend lettertype
- lettertypevervanging
- lettertype vervangen
- lettertypevervanging
- substitutieregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Configureer lettertype‑substitutieregels en inspecteer vervangen lettertypen in Aspose.Slides voor Java bij het renderen of converteren van PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Lettertypevervanging stelt Aspose.Slides in staat een beschikbaar lettertype te gebruiken in plaats van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De vervanging heeft invloed op de gerenderde output; het verandert het aan de presentatietekst toegewezen lettertype niet.

U kunt het te gebruiken lettertype definiëren wanneer een bepaald lettertype niet beschikbaar is, en u kunt de substituties inspecteren die Aspose.Slides tijdens het renderen zal uitvoeren. Dit helpt om de output consistent te houden tussen omgevingen met verschillende geïnstalleerde lettertypen.

## **Lettertypevervangingen ophalen**

Gebruik de [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) methode om te bepalen welke lettertypen worden vervangen wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsubstitutioninfo/) objecten die de oorspronkelijke en vervangende lettertypenamen identificeren.

Het volgende Java‑voorbeeld geeft alle lettertypevervangingen voor een presentatie weer:

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

## **Lettertypevervangingen voor geselecteerde dia's ophalen**

Gebruik de overload van [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) met een `int[] slides` argument om alleen de substituties te inspecteren die nodig zijn om specifieke dia's te renderen. Dit is handig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia's zoekt die afhankelijk zijn van niet‑beschikbare lettertypen, een minimaal lettertype‑pakket voor een server of container voorbereidt, of renderingsverschillen diagnosticeert zonder ongerelateerde dia's te verwerken.

De `slides`‑array bevat één‑gebaseerde diacijfers: `1` identificeert de eerste dia. In tegenstelling tot de [Presentation.getSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getSlides--) collectie‑accessor die nul‑gebaseerde indexering gebruikt, wordt dezelfde dia benaderd als `presentation.getSlides().get_Item(0)`. Houd dit verschil in gedachten bij het samenstellen van de array om off‑by‑one‑fouten te voorkomen.

Roep de overload aan via de [Presentation.getFontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getFontsManager--) methode. Deze retourneert alleen de substituties die tijdens het renderen van de geselecteerde dia's zijn bepaald. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsubstitutioninfo/) object dat de oorspronkelijke en vervangende lettertypenamen bevat. Het resultaat weerspiegelt de huidige lettertype‑omgeving, geconfigureerde fallback‑regels, substitutieregels opgeslagen in een [IFontSubstRuleCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsubstrulecollection/), en [extern geladen lettertypen](/slides/nl/java/custom-font/).

Dezelfde substitutie kan door meer dan één geselecteerde dia vereist zijn. Verwijder dubbele resultaten wanneer u een lettertype‑inventaris of preflight‑rapport maakt. Het volgende voorbeeld meldt elke geretourneerde substitutie en maakt vervolgens een gesorteerde lijst van unieke lettertype‑toewijzingen:

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

De [IFontsManager](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/) interface biedt beide overloads. Kies er één op basis van de reikwijdte van de renderingsbewerking:

| Overload | Gebruik wanneer |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) zonder argumenten | U hebt substituties nodig voor de volledige presentatie. |
| [getSubstitutions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) met `int[] slides` | U hebt substituties nodig voor een geselecteerd bereik, een incrementele controle of een gedeeltelijke export. |

## **Lettertype‑substitutieregels instellen**

Om het lettertype op te geven dat Aspose.Slides moet gebruiken wanneer een bron‑lettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities voor het bron‑ en vervangende lettertype.
3. Creëer een [FontSubstRule](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsubstrule/) met de [WhenInaccessible](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsubstcondition/) conditie.
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsubstrulecollection/).
5. Wijs de collectie toe via de [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nl/java/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) methode.
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

Lettertype‑substitutieregels maken deel uit van het standaard lettertype‑selectieproces dat tijdens het renderen en converteren wordt gebruikt. Ze werken voor gewone tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat door een regel is gespecificeerd.

Office Math‑vergelijkingen hebben een extra vereiste. Als een vergelijking **Cambria Math** gebruikt, kan Aspose.Slides dat exacte lettertype nodig hebben om de lay-out van de vergelijking te berekenen en te renderen. Een regel die een ander wiskundig lettertype, zoals **STIX Two Math**, vervangt, kan **Cambria Math** hiervoor niet vervangen, en renderen kan nog steeds aangeven dat **Cambria Math** vereist is.

Om zo’n presentatie te renderen of te converteren, zorg ervoor dat **Cambria Math** beschikbaar is voor Aspose.Slides. Installeer het in het besturingssysteem of laad het als een [external font](/slides/nl/java/custom-font/).

Deze beperking is van toepassing op de lay‑out van vergelijkingen. De hierboven beschreven substitutieregels blijven wel van toepassing op gewone presentatietekst.

## **FAQ**

**Wat is het verschil tussen lettertypevervanging en lettertype‑substitutie?**

[Font replacement](/slides/nl/java/font-replacement/) verandert opzettelijk één lettertype in een ander gedurende de hele presentatie. Lettertype‑substitutie kiest een lettertype voor de gerenderde output wanneer aan de geconfigureerde voorwaarde is voldaan, bijvoorbeeld wanneer het oorspronkelijke lettertype niet beschikbaar is.

**Wanneer worden substitutieregels toegepast?**

De regels nemen deel aan de [font selection sequence](/slides/nl/java/font-selection-sequence/) tijdens het renderen en converteren. Met `WhenInaccessible` wordt een regel alleen gebruikt wanneer Aspose.Slides geen toegang heeft tot het bron‑lettertype.

**Wat gebeurt er als een lettertype ontbreekt en er geen substitutieregel is geconfigureerd?**

Aspose.Slides selecteert het dichtstbijzijnde beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de lettertypen die beschikbaar zijn in de runtime‑omgeving.

**Kan ik externe lettertypen laden om substitutie te vermijden?**

Ja. U kunt [load external fonts](/slides/nl/java/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens het renderen en converteren.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U bent verantwoordelijk voor het leveren van lettertypen en het naleven van hun licenties.

**Kunnen substitutieresultaten verschillen tussen Windows, Linux en macOS?**

Ja. Geïnstalleerde lettertypen en zoeklocaties voor lettertypen verschillen per besturingssysteem, zodat een lettertype dat op één machine beschikbaar is, op een andere machine substitutie kan vereisen.

**Hoe kan ik de lettertype‑selectie consistent maken bij batch‑conversies?**

Gebruik dezelfde lettertypebestanden en versies op elke machine of container, [load required external fonts](/slides/nl/java/custom-font/), en [embed fonts](/slides/nl/java/embedded-font/) wanneer de licentie dit toestaat. U kunt ook [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) aanroepen vóór export om onverwachte substituties te identificeren.