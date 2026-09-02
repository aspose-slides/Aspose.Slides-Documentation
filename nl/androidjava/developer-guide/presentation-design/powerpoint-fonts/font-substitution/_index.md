---
title: Lettertypevervanging configureren in presentaties op Android
linktitle: Lettertypevervanging
type: docs
weight: 70
url: /nl/androidjava/font-substitution/
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
- Android
- Java
- Aspose.Slides
description: "Configureer lettertype‑substitutieregels en controleer de vervangen lettertypen in Aspose.Slides voor Android via Java bij het renderen of converteren van presentaties."
---
## **Overzicht**

Lettertypevervanging maakt het mogelijk voor Aspose.Slides om een beschikbaar lettertype te gebruiken ter vervanging van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De vervanging heeft invloed op de gerenderde output; het wijzigt niet het lettertype dat aan de inhoud van de presentatie is toegewezen.

U kunt het te gebruiken lettertype definiëren wanneer een bepaald lettertype niet beschikbaar is, en u kunt de vervangingen inspecteren die Aspose.Slides zal uitvoeren tijdens het renderen. Dit helpt om de output consistent te houden op Android-apparaten en in omgevingen met verschillende beschikbare lettertypen.

## **Lettertypevervangingen ophalen**

Gebruik de [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) methode om te bepalen welke lettertypen zullen worden vervangen wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsubstitutioninfo/) objecten die de oorspronkelijke en vervangende lettertype‑namen identificeren.

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

## **Lettertypevervangingen ophalen voor geselecteerde dia's**

Gebruik de [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) overload met een `int[] slides`‑argument om alleen de vervangingen te inspecteren die nodig zijn om specifieke dia's te renderen. Dit is nuttig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia's zoekt die afhankelijk zijn van niet‑beschikbare lettertypen, een minimaal lettertype‑pakket voor een Android‑app voorbereidt, of renderingsverschillen diagnosticeert zonder niet‑relevante dia's te verwerken.

De `slides`‑array bevat één‑gebaseerde dia‑indexen: `1` identificeert de eerste dia. In tegenstelling tot de [Presentation.getSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getSlides--) collectie‑toegangs­methode die nul‑gebaseerde indexering gebruikt, wordt diezelfde dia bereikt via `presentation.getSlides().get_Item(0)`. Houd dit verschil in gedachten bij het samenstellen van de array om off‑by‑one‑fouten te vermijden.

Roep de overload aan via de [Presentation.getFontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getFontsManager--) methode. Deze retourneert alleen de vervangingen die tijdens het renderen van de geselecteerde dia's werden bepaald. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsubstitutioninfo/) object dat de oorspronkelijke en vervangende lettertype‑namen bevat. Het resultaat weerspiegelt de huidige lettertype‑omgeving, geconfigureerde fallback‑regels, vervangingsregels opgeslagen in een [IFontSubstRuleCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontsubstrulecollection/), en [extern geladen lettertypen](/slides/nl/androidjava/custom-font/).

Dezelfde vervanging kan nodig zijn voor meer dan één geselecteerde dia. Dupliceer de resultaten niet wanneer u een lettertype‑inventaris of preflight‑rapport opstelt. Het volgende voorbeeld rapporteert elke geretourneerde vervanging en maakt vervolgens een gesorteerde lijst van unieke lettertype‑toewijzingen:

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

De [IFontsManager](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontsmanager/) interface biedt beide overloads. Kies er één op basis van de reikwijdte van de render‑operatie:

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) with no arguments | U heeft vervangingen nodig voor de gehele presentatie. |
| [getSubstitutions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions-int---) with `int[] slides` | U heeft vervangingen nodig voor een geselecteerd bereik, incrementele controle, of gedeeltelijke export. |

## **Lettertypevervangingsregels instellen**

Om het lettertype op te geven dat Aspose.Slides moet gebruiken wanneer een bronlettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities voor het bron‑ en vervangende lettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsubstrule/) met de [WhenInaccessible](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsubstcondition/) voorwaarde.
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsubstrulecollection/).
5. Wijs de collectie toe via de [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/fontsmanager/#setFontSubstRuleList-com.aspose.slides.IFontSubstRuleCollection-) methode.
6. Render of converteer de presentatie.

Het volgende Java‑voorbeeld vervangt `SomeRareFont` door `Arial` wanneer `SomeRareFont` niet beschikbaar is, en rendert vervolgens de eerste dia om het resultaat te verifiëren. Het vervangende lettertype moet beschikbaar zijn voor Aspose.Slides.

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
Voor een onvoorwaardelijke wijziging van de lettertypen die in een volledige presentatie worden gebruikt, zie [Lettertypevervanging](/slides/nl/androidjava/font-replacement/).
{{% /alert %}}

## **Beperkingen voor wiskundige vergelijking‑lettertypen**

Lettertypevervangingsregels maken onderdeel uit van het standaard lettertype‑selectieproces dat tijdens het renderen en converteren wordt gebruikt. Ze werken voor gewone tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat in een regel is gespecificeerd.

Office‑Math‑vergelijkingen hebben een extra vereiste. Als een vergelijking **Cambria Math** gebruikt, kan Aspose.Slides dat exacte lettertype nodig hebben om de lay‑out van de vergelijking te berekenen en te renderen. Een regel die een ander wiskundig lettertype vervangt, zoals **STIX Two Math**, kan **Cambria Math** niet vervangen voor dit doel, en het renderen kan nog steeds melden dat **Cambria Math** vereist is.

Om zo'n presentatie te renderen of te converteren, maak **Cambria Math** beschikbaar voor Aspose.Slides. Laad het als een [extern lettertype](/slides/nl/androidjava/custom-font/) zodat de applicatie het tijdens het renderen en converteren kan gebruiken.

Deze beperking geldt voor de lay‑out van de vergelijking. De hierboven beschreven vervangingsregels blijven van toepassing op gewone presentatietekst.

## **Veelgestelde vragen**

**Wat is het verschil tussen lettertypevervanging en lettertype‑substitutie?**

[Lettertypevervanging](/slides/nl/androidjava/font-replacement/) verandert bewust één lettertype in de hele presentatie naar een ander. Lettertype‑substitutie kiest een lettertype voor de gerenderde output wanneer aan de geconfigureerde voorwaarde is voldaan, bijvoorbeeld wanneer het oorspronkelijke lettertype niet beschikbaar is.

**Wanneer worden substitutieregels toegepast?**

De regels nemen deel aan de [lettertype‑selectiesequentie](/slides/nl/androidjava/font-selection-sequence/) tijdens het renderen en converteren. Met `WhenInaccessible` wordt een regel alleen gebruikt wanneer Aspose.Slides geen toegang heeft tot het bronlettertype.

**Wat gebeurt er wanneer een lettertype ontbreekt en er geen substitutieregel is geconfigureerd?**

Aspose.Slides kiest het dichtstbijzijnde beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de lettertypen die beschikbaar zijn in de runtime‑omgeving.

**Kan ik externe lettertypen laden om substitutie te voorkomen?**

Ja. U kunt [externe lettertypen laden](/slides/nl/androidjava/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens het renderen en converteren.

**Distributeert Aspose lettertypen met de bibliotheek?**

Nee. U bent verantwoordelijk voor het leveren van lettertypen en het naleven van hun licenties.

**Kunnen substitutieresultaten verschillen tussen Android‑apparaten?**

Ja. Beschikbare systeemlettertypen kunnen verschillen tussen Android‑versies, apparaten en leveranciers, dus een lettertype dat in de ene omgeving beschikbaar is, kan in een andere omgeving substitutie vereisen.

**Hoe kan ik de lettertype‑selectie consistent maken over Android‑apparaten heen?**

Pakketteer dezelfde vereiste lettertypebestanden met de applicatie, [laad ze als externe lettertypen](/slides/nl/androidjava/custom-font/), en [lettertypen insluiten](/slides/nl/androidjava/embedded-font/) wanneer de licentie dit toestaat. U kunt ook [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ifontsmanager/#getSubstitutions--) aanroepen vóór export om onverwachte substituties te identificeren.