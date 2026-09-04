---
title: "Beheer presentatie‑eigenschappen in JavaScript"
linktitle: "Presentatie‑eigenschappen"
type: docs
weight: 70
url: /nl/nodejs-java/presentation-properties/
keywords:
- "PowerPoint‑eigenschappen"
- "presentatie‑eigenschappen"
- "document‑eigenschappen"
- "ingebouwde eigenschappen"
- "aangepaste eigenschappen"
- "geavanceerde eigenschappen"
- "eigenschappen beheren"
- "eigenschappen wijzigen"
- "document‑metadata"
- "metadata bewerken"
- "controle‑taal"
- "standaardtaal"
- "PowerPoint"
- "OpenDocument"
- "presentatie"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Beheer presentatie‑eigenschappen in Aspose.Slides voor Node.js via Java en stroomlijn zoeken, branding en workflow in uw PowerPoint‑ en OpenDocument‑bestanden."
---
## **Inleiding**

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Ingebouwde** en **Aangepaste**. Beide eigenschappentypen kunnen eenvoudig benaderd en beheerd worden met de Aspose.Slides API.

Aspose.Slides stelt je in staat om met presentatiedocumenteigenschappen te werken via de [DocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/) klasse. Een instantie van deze klasse wordt geretourneerd door de [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getDocumentProperties) methode. De volgende voorbeelden tonen hoe deze eigenschappen gelezen, gewijzigd en beheerd kunnen worden.

{{% alert color="info" title="Opmerking" %}}
Houd er rekening mee dat de velden **Application** en **AppVersion** niet gewijzigd kunnen worden. Aspose.Slides herschrijft ze bij elke opslaan, zodat een opgeslagen presentatie altijd meldt "Aspose.Slides for Node.js via Java" en de versie van de bibliotheek die het heeft gemaakt. Elke waarde die aan `setNameOfApplication` wordt doorgegeven, wordt genegeerd wanneer de presentatie wordt weggeschreven.
{{% /alert %}} 

## **Beheer presentatie-eigenschappen**

Microsoft PowerPoint biedt een functie om enkele eigenschappen aan de presentatiebestanden toe te voegen. Deze documenteigenschappen maken het mogelijk om nuttige informatie op te slaan samen met de documenten (presentatiebestanden). Er zijn twee soorten documenteigenschappen:

- Systeemgedefinieerde (Ingebouwde) eigenschappen
- Door de gebruiker gedefinieerde (Aangepaste) eigenschappen

**Ingebouwde** eigenschappen bevatten algemene informatie over het document, zoals de documenttitel, de naam van de auteur, documentstatistieken enzovoort. **Aangepaste** eigenschappen zijn diegenen die door de gebruikers worden gedefinieerd als **Naam/Waarde**-paren, waarbij zowel naam als waarde door de gebruiker worden opgegeven. Met Aspose.Slides voor Node.js via Java kunnen ontwikkelaars zowel de waarden van ingebouwde eigenschappen als van aangepaste eigenschappen benaderen en wijzigen.

## **Documenteigenschappen in PowerPoint**

Microsoft PowerPoint 2007 maakt het mogelijk om de documenteigenschappen van de presentatiebestanden te beheren. Het enige wat je moet doen is op het Office‑pictogram klikken en vervolgens **Prepare | Properties | Advanced Properties** kiezen in Microsoft PowerPoint 2007, zoals hieronder getoond:

|**Selecteer menu-item Geavanceerde eigenschappen**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Na het selecteren van het menu‑item **Advanced Properties** verschijnt er een dialoogvenster waarmee je de documenteigenschappen van het PowerPoint‑bestand kunt beheren, zoals hieronder in de afbeelding weergegeven:

|**Eigenschappen‑dialoog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

In de bovenstaande **Eigenschappen‑dialoog** zie je dat er verschillende tabbladen zijn, zoals **General**, **Summary**, **Statistics**, **Contents** en **Custom**. Al deze tabbladen stellen je in staat om verschillende soorten informatie met betrekking tot de PowerPoint‑bestanden te configureren. Het **Custom**‑tabblad wordt gebruikt om de aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.

Werken met documenteigenschappen met Aspose.Slides voor Node.js via Java

As we have described earlier, Aspose.Slides voor Node.js via Java ondersteunt twee soorten documenteigenschappen, namelijk **Ingebouwde** en **Aangepaste** eigenschappen. Ontwikkelaars kunnen dus beide soorten eigenschappen benaderen via de Aspose.Slides voor Node.js via Java API. Aspose.Slides voor Node.js via Java levert een klasse [DocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties) die de documenteigenschappen vertegenwoordigt die gekoppeld zijn aan een presentatie‑bestand via de eigenschap **Presentation.DocumentProperties**.

Ontwikkelaars kunnen de eigenschap **DocumentProperties**, die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation) object, gebruiken om de documenteigenschappen van de presentatiebestanden te benaderen zoals hieronder beschreven:

## **Openbare eigenschappen lezen van een versleutelde presentatie**

Een openings‑wachtwoord beschermt normaal zowel de inhoud van de presentatie als de documenteigenschappen. Wanneer een presentatie versleuteld wordt door `false` door te geven aan [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), blijven de documenteigenschappen openbaar. Een applicatie kan vervolgens `true` doorgeven aan [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) en de openbare metadata lezen zonder het openings‑wachtwoord in te voeren.

De optie 'alleen documenteigenschappen laden' bepaalt wat Aspose.Slides laadt; het ontsleutelt niets. Als de eigenschappen zijn opgenomen in de encryptie, faalt het laden ervan zonder wachtwoord. Als de presentatie niet versleuteld is, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het onderstaande voorbeeld verifieert de laadmodus via [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) en leest vervolgens ingebouwde eigenschappen via [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

In deze modus wordt de inhoud van de dia's niet geladen. Dia's, masters, indelingen, vormen, media en andere presentatie‑objecten zijn niet beschikbaar. Applicaties moeten altijd [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) controleren voordat ze een bewerking uitvoeren die het volledige presentatiemodel vereist.

{{% alert color="warning" title="Waarschuwing" %}}
Openbare metadata kunnen auteursnamen, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden blootleggen. Versleutel gevoelige eigenschappen samen met de presentatie. Laat ze alleen openbaar wanneer indexering, classificatie, zoeken of document‑beheersystemen een specifieke eis hebben om ze zonder wachtwoord te benaderen.
{{% /alert %}}

## **Eigenschappen bijwerken van een versleutelde presentatie**

Voor een versleuteld PPTX‑bestand is een presentatie die in de modus 'alleen documenteigenschappen laden' is geopend, bedoeld om openbare metadata te lezen. Aspose.Slides kan de gewijzigde eigenschappen van dat alleen‑metadata‑object niet opslaan omdat de openbare eigenschappen consistent moeten blijven met de bijbehorende gegevens in de versleutelde presentatie. Het bijwerken ervan vereist daarom het juiste openings‑wachtwoord en een volledige load.

Het onderstaande voorbeeld opent de presentatie met [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/#setPassword), werkt openbare ingebouwde eigenschappen bij en slaat het resultaat op. Vervolgens wordt [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) gebruikt om te verifiëren dat de encryptie behouden blijft en wordt de openbare metadata zonder wachtwoord opnieuw geopend om de nieuwe waarden te controleren:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Als een applicatie niet is toegestaan de presentatie‑inhoud te ontsleutelen of te laden, moet deze de openbare eigenschappen van een versleuteld PPTX‑bestand als alleen‑lezen behandelen.

## **Toegang tot ingebouwde eigenschappen**

Deze eigenschappen, die worden blootgesteld door het [DocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties) object, omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Laatste afdrukdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is gedeeld tussen verschillende producenten?), **PresentationFormat**, **Subject** en **Title**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieer de Presentation-klasse die de presentatie vertegenwoordigt
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het IDocumentProperties-object dat aan de presentatie is gekoppeld
    var dp = pres.getDocumentProperties();
    // Toon de ingebouwde eigenschappen
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ingebouwde eigenschappen wijzigen**

Het wijzigen van de ingebouwde eigenschappen van presentatiebestanden is net zo eenvoudig als het benaderen ervan. Je kunt eenvoudig een stringwaarde toewijzen aan een gewenste eigenschap en de eigenschapswaarde wordt dan aangepast. In het onderstaande voorbeeld laten we zien hoe we de ingebouwde documenteigenschappen van het presentatiebestand kunnen wijzigen met Aspose.Slides voor Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het IDocumentProperties-object dat aan de presentatie is gekoppeld
    var dp = pres.getDocumentProperties();
    // Stel de ingebouwde eigenschappen in
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Sla je presentatie op in een bestand
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Dit voorbeeld wijzigt de ingebouwde eigenschappen van de presentatie, die hieronder te zien zijn:

|**Ingebouwde documenteigenschappen na wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aangepaste documenteigenschappen toevoegen**

Aspose.Slides voor Node.js via Java stelt ontwikkelaars ook in staat om aangepaste waarden toe te voegen aan de documenteigenschappen van een presentatie. Een voorbeeld wordt hieronder gegeven waarin wordt getoond hoe de aangepaste eigenschappen voor een presentatie ingesteld kunnen worden.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Documenteigenschappen ophalen
    var dProps = pres.getDocumentProperties();
    // Aangepaste eigenschappen toevoegen
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Naam van eigenschap ophalen op een specifieke index
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Geselecteerde eigenschap verwijderen
    dProps.removeCustomProperty(getPropertyName);
    // Presentatie opslaan
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Aangepaste documenteigenschappen toegevoegd**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Aangepaste eigenschappen benaderen en wijzigen**

Aspose.Slides voor Node.js via Java stelt ontwikkelaars ook in staat om de waarden van aangepaste eigenschappen te benaderen. Een voorbeeld wordt hieronder gegeven dat laat zien hoe je alle aangepaste eigenschappen van een presentatie kunt benaderen en wijzigen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het DocumentProperties-object dat aan de presentatie is gekoppeld
    var dp = pres.getDocumentProperties();
    // Toegang tot en wijziging van aangepaste eigenschappen
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Toon namen en waarden van aangepaste eigenschappen
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Wijzig waarden van aangepaste eigenschappen
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Sla uw presentatie op in een bestand
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Dit voorbeeld wijzigt de aangepaste eigenschappen van de [PPTX](https://docs.fileformat.com/presentation/pptx/) presentatie. De volgende figuren tonen de aangepaste eigenschappen van de presentatie vóór en na wijziging:

|**Aangepaste eigenschappen vóór wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Aangepaste eigenschappen na wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Geavanceerde documenteigenschappen**

{{% alert color="info" title="Opmerking" %}}
Nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) , [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) en [WriteBindedPresentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) zijn toegevoegd aan [PresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo), de logica van de eigenschapsetter [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) is aangepast.
{{% /alert %}} 

De twee nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) en [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) zijn toegevoegd aan de klasse [PresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo). Ze bieden snelle toegang tot documenteigenschappen en stellen je in staat eigenschappen te wijzigen en bij te werken zonder een volledige presentatie te laden.

Het typische scenario waarbij de eigenschappen worden geladen, een waarde wordt gewijzigd en het document wordt bijgewerkt, kan als volgt worden geïmplementeerd:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// lees de informatie van de presentatie
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// verkrijg de huidige eigenschappen
var props = info.readDocumentProperties();
// stel de nieuwe waarden van de velden Auteur en Titel in
props.setAuthor("New Author");
props.setTitle("New Title");
// werk de presentatie bij met nieuwe waarden
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Er is een andere manier om de eigenschappen van een specifieke presentatie als sjabloon te gebruiken om eigenschappen in andere presentaties bij te werken:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Een nieuw sjabloon kan vanaf nul worden gemaakt en vervolgens worden gebruikt om meerdere presentaties bij te werken:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Controlertaal instellen**

Aspose.Slides biedt de eigenschap LanguageId (exposeerd door de klasse PortionFormat) om de controle‑taal voor een PowerPoint‑document in te stellen. De controle‑taal is de taal waarvoor spelling en grammatica in PowerPoint worden gecontroleerd. Deze JavaScript‑code toont hoe je de controle‑taal voor een PowerPoint instelt: xxx Waarom ontbreekt LanguageId in de JavaScript‑PortionFormat‑klasse?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// stel de Id in van een controle-taal
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Standaardtaal instellen**

Deze JavaScript‑code toont hoe je de standaardtaal voor een volledige PowerPoint‑presentatie instelt:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Voegt een nieuwe rechthoekvorm toe met tekst
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Controleert de taal van de eerste portion
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Live‑voorbeeld**

Probeer de online app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe je met documenteigenschappen werkt via de Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## **FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. Je kunt echter wel hun waarden wijzigen of ze leeg maken als de specifieke eigenschap dat toestaat.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als je een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. Je hoeft de eigenschap niet eerst te verwijderen of te controleren, omdat Aspose.Slides de waarde automatisch bijwerkt.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) en vervolgens [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) om de opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instantie aan te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/nodejs-java/examine-presentation/) voor een volledig rapportage‑voorbeeld en formaat‑specifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openings‑wachtwoord?**

Ja. De encryptie van documenteigenschappen moet uitgeschakeld zijn voordat de presentatie werd versleuteld, en de presentatie moet in de modus 'alleen documenteigenschappen laden' worden geopend.

**Kan ik een versleuteld PPTX‑bestand bijwerken in de modus 'alleen documenteigenschappen laden'?**

Nee. Openbare en versleutelde eigenschapsgegevens moeten consistent blijven, dus het bijwerken van een versleuteld PPTX‑bestand vereist het volledig laden van de presentatie met het juiste openings‑wachtwoord.