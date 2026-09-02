---
title: Lettertypevervanging configureren in presentaties met JavaScript
linktitle: Lettertypevervanging
type: docs
weight: 70
url: /nl/nodejs-java/font-substitution/
keywords:
- lettertype
- vervangend lettertype
- lettertypevervanging
- lettertype vervangen
- lettertypevervanging
- vervangingsregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Configureer lettertypevervangingsregels en inspecteer vervangen lettertypen in Aspose.Slides voor Node.js via Java bij het renderen of converteren van PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Lettertypevervanging stelt Aspose.Slides in staat een beschikbaar lettertype te gebruiken in plaats van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De vervanging beïnvloedt de gegenereerde uitvoer; het verandert het toegewezen lettertype van de presentatie‑inhoud niet.

U kunt definiëren welk lettertype moet worden gebruikt wanneer een bepaald lettertype niet beschikbaar is, en u kunt de vervangingen bekijken die Aspose.Slides tijdens het renderen zal uitvoeren. Dit helpt om de uitvoer consistent te houden in omgevingen met verschillende geïnstalleerde lettertypen.

## **Lettertypevervanging ophalen**

Gebruik de [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)‑methode om te bepalen welke lettertypen worden vervangen wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsubstitutioninfo/)-objecten die de oorspronkelijke en de vervangen lettertype‑namen identificeren.

Het volgende JavaScript‑voorbeeld geeft alle lettertypevervangingen voor een presentatie weer:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **Lettertypevervanging voor geselecteerde dia’s ophalen**

Gebruik de [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)‑overload met een array van dia‑indexen om alleen de vervangingen te bekijken die nodig zijn om bepaalde dia’s te renderen. Handig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia’s zoekt die afhankelijk zijn van niet‑beschikbare lettertypen, een minimaal lettertype‑pakket voor een server of container voorbereidt, of render‑verschillen diagnosticeert zonder ongerelateerde dia’s te verwerken.

De overload verwacht een Java‑primitief `int[]`. Maak er een met `java.newArray("int", [...])`; een gewone JavaScript‑array wordt geconverteerd naar `Integer[]` en voldoet niet aan deze overload.

De array bevat één‑gebaseerde dia‑indexen: `1` identificeert de eerste dia. Het [Presentation.getSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getslides/)-collectietoegangselement gebruikt nul‑gebaseerde indexering, zodat dezelfde dia wordt benaderd met `presentation.getSlides().get_Item(0)`. Houd dit verschil in gedachten bij het bouwen van de array om off‑by‑one‑fouten te voorkomen.

Roep de overload aan via [Presentation.getFontsManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/getfontsmanager/). Deze retourneert alleen de vervangingen die zijn bepaald tijdens het renderen van de geselecteerde dia’s. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsubstitutioninfo/)-object met de oorspronkelijke en de vervangen lettertype‑namen. Het resultaat reflecteert de huidige lettertype‑omgeving, geconfigureerde fallback‑regels, vervangingsregels opgeslagen in een [FontSubstRuleCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsubstrulecollection/) en [extern geladen lettertypen](/slides/nl/nodejs-java/custom-font/).

Dezelfde vervanging kan vereist zijn door meer dan één geselecteerde dia. Dedupliceer de resultaten wanneer u een lettertype‑inventaris of preflight‑rapport maakt. Het volgende voorbeeld meldt elke geretourneerde vervanging en maakt vervolgens een gesorteerde lijst van unieke lettertype‑toewijzingen:

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

De [FontsManager](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/)‑klasse biedt beide overloads. Kies er één op basis van de reikwijdte van de render‑operatie:

| Overload | Wanneer te gebruiken |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) zonder argumenten | U hebt vervangingen nodig voor de volledige presentatie. |
| [getSubstitutions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) met een Java `int[]` van dia‑indexen | U hebt vervangingen nodig voor een geselecteerd bereik, incrementele controle of gedeeltelijke export. |

## **Lettertypevervangingsregels instellen**

Om op te geven welk lettertype Aspose.Slides moet gebruiken wanneer een bronlettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities voor het bron‑ en vervangende lettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsubstrule/) met de [WhenInaccessible](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsubstcondition/)‑conditie.
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsubstrulecollection/).
5. Wijs de collectie toe met de [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/)‑methode.
6. Render of converteer de presentatie.

Het volgende JavaScript‑voorbeeld vervangt `Arial` door `SomeRareFont` wanneer `SomeRareFont` niet beschikbaar is, en rendert vervolgens de eerste dia om het resultaat te verifiëren. Het vervangende lettertype moet beschikbaar zijn voor Aspose.Slides.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Voor een onvoorwaardelijke wijziging van de lettertypen die door een volledige presentatie worden gebruikt, zie [Lettertype‑vervanging](/slides/nl/nodejs-java/font-replacement/).
{{% /alert %}}

## **Beperkingen voor wiskundige vergelijking‑lettertypen**

Lettertypevervangingsregels maken deel uit van het standaard lettertype‑selectieproces dat wordt gebruikt tijdens renderen en converteren. Ze werken voor gewone tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat in een regel is opgegeven.

Office‑Math‑vergelijkingen hebben een extra vereiste. Als een vergelijking **Cambria Math** gebruikt, heeft Aspose.Slides dat exacte lettertype nodig om de lay‑out van de vergelijking te berekenen en weer te geven. Een regel die een ander wiskundig lettertype vervangt, zoals **STIX Two Math**, kan **Cambria Math** niet vervangen voor dit doel, en het renderen kan nog steeds melden dat **Cambria Math** vereist is.

Om zo’n presentatie te renderen of te converteren, zorg ervoor dat **Cambria Math** beschikbaar is voor Aspose.Slides. Installeer het in het besturingssysteem of laad het als een [extern lettertype](/slides/nl/nodejs-java/custom-font/).

Deze beperking heeft betrekking op de lay‑out van vergelijkingen. De hierboven beschreven vervangingsregels blijven wel van toepassing op gewone presentatie‑tekst.

## **FAQ**

**Wat is het verschil tussen lettertype‑vervanging en lettertype‑substitutie?**

[Lettertype‑vervanging](/slides/nl/nodejs-java/font-replacement/) verandert bewust één lettertype in een ander door de hele presentatie heen. Lettertype‑substitutie kiest een lettertype voor de gerenderde uitvoer wanneer aan de geconfigureerde voorwaarde wordt voldaan, bijvoorbeeld wanneer het originele lettertype niet beschikbaar is.

**Wanneer worden substitutieregels toegepast?**

De regels nemen deel aan de [lettertype‑selectiesequentie](/slides/nl/nodejs-java/font-selection-sequence/) tijdens renderen en converteren. Met `WhenInaccessible` wordt een regel alleen gebruikt wanneer Aspose.Slides geen toegang heeft tot het bronlettertype.

**Wat gebeurt er als een lettertype ontbreekt en er geen substitutieregel is geconfigureerd?**

Aspose.Slides kiest het meest geschikte beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de lettertypen die in de runtime‑omgeving beschikbaar zijn.

**Kan ik externe lettertypen laden om substitutie te voorkomen?**

Ja. U kunt [externe lettertypen laden](/slides/nl/nodejs-java/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens renderen en converteren.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U bent verantwoordelijk voor het voorzien van lettertypen en het naleven van hun licenties.

**Kunnen substitutieresultaten verschillen tussen Windows, Linux en macOS?**

Ja. Geïnstalleerde lettertypen en zoeklocaties voor lettertypen verschillen per besturingssysteem, zodat een lettertype dat op de ene machine beschikbaar is, op een andere machine substitutie kan vereisen.

**Hoe kan ik de lettertype‑selectie consistent maken bij batch‑conversies?**

Gebruik dezelfde lettertype‑bestanden en -versies op elke machine of container, [laad vereiste externe lettertypen](/slides/nl/nodejs-java/custom-font/) en [embed lettertypen](/slides/nl/nodejs-java/embedded-font/) wanneer de licentie dit toestaat. U kunt ook [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) aanroepen vóór export om onverwachte substituties te identificeren.