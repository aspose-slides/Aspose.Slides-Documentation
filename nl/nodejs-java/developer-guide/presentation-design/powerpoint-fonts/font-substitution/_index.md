---
title: Configureer lettertypevervanging in presentaties met JavaScript
linktitle: Lettertypevervanging
type: docs
weight: 70
url: /nl/nodejs-java/font-substitution/
keywords:
- lettertype
- vervangend lettertype
- lettertypevervanging
- lettertype vervangen
- vervanging van lettertype
- vervangingsregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Configureer lettertypevervangingsregels en controleer de vervangen lettertypen in Aspose.Slides voor Node.js via Java bij het renderen of converteren van PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Lettertypevervanging maakt het mogelijk voor Aspose.Slides om een beschikbaar lettertype te gebruiken in plaats van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De vervanging heeft invloed op de gerenderde uitvoer; het wijzigt niet het lettertype dat aan de presentatietekst is toegewezen.

U kunt definiëren welk lettertype gebruikt moet worden wanneer een bepaald lettertype niet beschikbaar is, en u kunt de vervangingen inspecteren die Aspose.Slides zal uitvoeren tijdens het renderen. Dit helpt om de uitvoer consistent te houden tussen omgevingen met verschillende geïnstalleerde lettertypen.

Als een lettertype beschikbaar is maar geen eigen vet teken­set heeft, zie dan [Lettertypen verwerken zonder een eigen vet teken­set](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Die sectie legt uit hoe de betreffende tekst kan worden gerasterd tijdens PDF-export en welke gevolgen dit heeft voor tekstopmaak, zoeken en schalen.

## **Lettervervangingen opvragen**

Gebruik de [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)‑methode om te bepalen welke lettertypen worden vervangen wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/)-objecten die de originele en vervangen lettertype‑namen identificeren.

Het volgende JavaScript‑voorbeeld geeft alle lettervervangingen voor een presentatie weer:

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

## **Lettervervangingen voor geselecteerde dia’s opvragen**

Gebruik de overload van [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) met een array van dia‑indexen om alleen de vervangingen te inspecteren die nodig zijn om specifieke dia’s te renderen. Dit is nuttig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia’s opzoekt die afhankelijk zijn van niet‑beschikbare lettertypen, een minimale lettertype‑package voor een server of container voorbereidt, of renderingsverschillen diagnosticeert zonder irrelevante dia’s te verwerken.

De overload verwacht een Java‑primitive `int[]`. Maak deze met `java.newArray("int", [...])`; een gewone JavaScript‑array wordt geconverteerd naar `Integer[]` en komt niet overeen met deze overload.

De array bevat één‑gebaseerde dia‑indexen: `1` identificeert de eerste dia. In tegenstelling tot de [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/)-collectietoegang die nul‑gebaseerde indexering gebruikt, wordt dezelfde dia benaderd als `presentation.getSlides().get_Item(0)`. Houd dit verschil in gedachten bij het samenstellen van de array om één‑off‑by‑one‑fouten te voorkomen.

Roep de overload aan via [Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/). Deze retourneert alleen de vervangingen die tijdens het renderen van de geselecteerde dia’s zijn bepaald. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/)-object dat de originele en vervangen lettertype‑namen bevat. Het resultaat weerspiegelt de huidige lettertype‑omgeving, geconfigureerde fallback‑regels, vervangingsregels opgeslagen in een [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/) en [extern geladen lettertypen](/slides/nl/nodejs-java/custom-font/).

Dezelfde vervanging kan door meer dan één geselecteerde dia vereist zijn. Dupliceer de resultaten niet wanneer u een lettertype‑inventaris of pre‑flight‑rapport maakt. Het volgende voorbeeld rapporteert elke teruggegeven vervanging en maakt vervolgens een gesorteerde lijst van unieke lettertype‑koppelingen:

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

De [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/)‑klasse biedt beide overloads. Kies er één op basis van de reikwijdte van de render‑operatie:

| Overload | Gebruik wanneer |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) zonder argumenten | U heeft vervangingen nodig voor de volledige presentatie. |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) met een Java `int[]` van dia‑indexen | U heeft vervangingen nodig voor een geselecteerd bereik, incrementele controle of gedeeltelijke export. |

## **Lettertype‑vervangingsregels instellen**

Om het lettertype op te geven dat Aspose.Slides moet gebruiken wanneer een bronlettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities aan voor het bron‑ en vervangende lettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) met de [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/)‑conditie.
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/).
5. Wijs de collectie toe met behulp van de [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/)‑methode.
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
Voor een onvoorwaardelijke wijziging van de lettertypen die door de hele presentatie heen worden gebruikt, zie [Lettertypevervanging](/slides/nl/nodejs-java/font-replacement/).
{{% /alert %}}

## **Beperkingen voor wiskundige vergelijking‑lettertypen**

Lettertypevervangingsregels maken deel uit van het standaard‑lettertype‑selectieproces dat tijdens renderen en converteren wordt gebruikt. Ze werken voor gewone tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat in een regel is opgegeven.

Office‑Math‑vergelijkingen hebben een extra vereiste. Als een vergelijking **Cambria Math** gebruikt, kan Aspose.Slides dat exacte lettertype nodig hebben om de lay‑out van de vergelijking te berekenen en te renderen. Een regel die een ander wiskundig lettertype vervangt, zoals **STIX Two Math**, kan **Cambria Math** niet vervangen voor dit doel, en het renderen kan nog steeds aangeven dat **Cambria Math** vereist is.

Om zo’n presentatie te renderen of te converteren, maak **Cambria Math** beschikbaar voor Aspose.Slides. Installeer het in het besturingssysteem of laad het als een [extern lettertype](/slides/nl/nodejs-java/custom-font/).

Deze beperking geldt voor de vergelijking‑lay‑out. De hierboven beschreven vervangingsregels blijven van toepassing op gewone presentatietekst.

## **FAQ**

**Wat is het verschil tussen font replacement en font substitution?**

[Font replacement](/slides/nl/nodejs-java/font-replacement/) wijzigt opzettelijk één lettertype naar een ander door de hele presentatie heen. Font substitution kiest een lettertype voor de gerenderde uitvoer wanneer aan de geconfigureerde voorwaarde is voldaan, bijvoorbeeld wanneer het originele lettertype niet beschikbaar is.

**Wanneer worden vervangingsregels toegepast?**

De regels nemen deel aan de [font selection sequence](/slides/nl/nodejs-java/font-selection-sequence/) tijdens renderen en converteren. Met `WhenInaccessible` wordt een regel alleen gebruikt wanneer Aspose.Slides geen toegang heeft tot het bronlettertype.

**Wat gebeurt er als een lettertype ontbreekt en er geen vervangingsregel is geconfigureerd?**

Aspose.Slides kiest het dichtstbijzijnde beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de lettertypen die beschikbaar zijn in de runtime‑omgeving.

**Kan ik externe lettertypen laden om vervanging te vermijden?**

Ja. U kunt [load external fonts](/slides/nl/nodejs-java/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens renderen en converteren.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U bent zelf verantwoordelijk voor het leveren van lettertypen en het naleven van hun licenties.

**Kunnen vervangingsresultaten verschillen tussen Windows, Linux en macOS?**

Ja. Geïnstalleerde lettertypen en zoek‑locaties verschillen per besturingssysteem, zodat een lettertype dat op de ene machine beschikbaar is, op een andere machine vervanging kan vereisen.

**Hoe kan ik de lettertype‑selectie consistent houden bij batch‑conversies?**

Gebruik dezelfde lettertype‑bestanden en -versies op elke machine of container, [load required external fonts](/slides/nl/nodejs-java/custom-font/), en [embed fonts](/slides/nl/nodejs-java/embedded-font/) wanneer de licentie dit toelaat. U kunt ook [FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) aanroepen vóór export om onverwachte vervangingen te identificeren.