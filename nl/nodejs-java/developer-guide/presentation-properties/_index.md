---
title: Beheer presentatie-eigenschappen in JavaScript
linktitle: Presentatie-eigenschappen
type: docs
weight: 70
url: /nl/nodejs-java/presentation-properties/
keywords:
- PowerPoint-eigenschappen
- presentatie-eigenschappen
- document-eigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- document-metadata
- metadata bewerken
- controlertaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer presentatie-eigenschappen in Aspose.Slides voor Node.js via Java en stroomlijn zoeken, branding en workflow in uw PowerPoint- en OpenDocument-bestanden."
---
## **Inleiding**

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Ingebouwd** en **Aangepast**. Beide soorten eigenschappen kunnen eenvoudig worden benaderd en beheerd via de Aspose.Slides API.

Aspose.Slides stelt u in staat om met de presentatiedocumenteigenschappen te werken via de klasse [DocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/) . Een instantie van deze klasse wordt geretourneerd door de methode [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . De onderstaande voorbeelden tonen hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}
Houd er rekening mee dat de velden **Application** en **AppVersion** niet kunnen worden gewijzigd. Aspose.Slides overschrijft ze bij elke opslag, zodat een opgeslagen presentatie altijd rapporteert "Aspose.Slides for Node.js via Java" en de versie van de bibliotheek die het heeft gegenereerd. Elke waarde die aan `setNameOfApplication` wordt doorgegeven, wordt genegeerd wanneer de presentatie wordt weggeschreven.
{{% /alert %}} 

## **Presentatie‑eigenschappen beheren**

Microsoft PowerPoint biedt een functie om enkele eigenschappen aan de presentatiebestanden toe te voegen. Deze documenteigenschappen stellen u in staat nuttige informatie op te slaan samen met de documenten (presentatiebestanden). Er zijn twee soorten documenteigenschappen als volgt

- Systeem‑gedefinieerde (Ingebouwde) eigenschappen
- Door gebruiker gedefinieerde (Aangepaste) eigenschappen

**Ingebouwde** eigenschappen bevatten algemene informatie over het document, zoals de documenttitel, de naam van de auteur, statistieken van het document enzovoort. **Aangepaste** eigenschappen zijn diegenen die door de gebruikers worden gedefinieerd als **Naam/Waarde**‑paren, waarbij zowel naam als waarde door de gebruiker worden opgegeven. Met Aspose.Slides voor Node.js via Java kunnen ontwikkelaars de waarden van zowel ingebouwde als aangepaste eigenschappen benaderen en wijzigen.

## **Documenteigenschappen in PowerPoint**

Microsoft PowerPoint 2007 maakt het beheer van de documenteigenschappen van presentaties mogelijk. Het enige wat u hoeft te doen is op het Office‑icoon klikken en vervolgens **Voorbereiden | Eigenschappen | Geavanceerde Eigenschappen** te kiezen, zoals hieronder weergegeven:

|**Geavanceerde Eigenschappen selecteren**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)||
Nadat u **Geavanceerde Eigenschappen** hebt geselecteerd, verschijnt er een dialoogvenster waarmee u de documenteigenschappen van het PowerPoint‑bestand kunt beheren, zoals in de onderstaande afbeelding:

|**Eigenschappen‑dialoog**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)||
In de bovenstaande **Eigenschappen‑dialoog** ziet u verschillende tabbladen, zoals **Algemeen**, **Samenvatting**, **Statistieken**, **Inhoud** en **Aangepast**. Al deze tabbladen stellen u in staat verschillende soorten informatie over de PowerPoint‑bestanden te configureren. Het tabblad **Aangepast** wordt gebruikt om de aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.

## Werken met documenteigenschappen met Aspose.Slides voor Node.js via Java

Zoals eerder beschreven ondersteunt Aspose.Slides voor Node.js via Java twee soorten documenteigenschappen, namelijk **Ingebouwde** en **Aangepaste** eigenschappen. Ontwikkelaars kunnen beide soorten eigenschappen benaderen via de Aspose.Slides for Node.js via Java API. Aspose.Slides voor Node.js via Java biedt de klasse [DocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties) die de documenteigenschappen van een presentatiedocument weergeeft via de eigenschap **Presentation.DocumentProperties**.

Ontwikkelaars kunnen de eigenschap **DocumentProperties** die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation)‑object gebruiken om de documenteigenschappen van presentaties te benaderen, zoals hieronder beschreven:

## **Toegang tot ingebouwde eigenschappen**

Deze eigenschappen die worden blootgesteld door het object [DocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties) omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Datum van laatste afdruk), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is gedeeld tussen verschillende producers?), **PresentationFormat**, **Subject** en **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instantieer de Presentation-klasse die de presentatie vertegenwoordigt
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het IDocumentProperties-object dat aan de Presentation is gekoppeld
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

Het wijzigen van de ingebouwde eigenschappen van presentaties is net zo eenvoudig als ze te benaderen. U kunt eenvoudig een tekenreekswaarde toewijzen aan een gewenste eigenschap en de waarde wordt aangepast. In het onderstaande voorbeeld laten we zien hoe we de ingebouwde documenteigenschappen van een presentatiedocument kunnen wijzigen met behulp van Aspose.Slides voor Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het IDocumentProperties-object dat bij de Presentation hoort
    var dp = pres.getDocumentProperties();
    // Stel de ingebouwde eigenschappen in
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Sla uw presentatie op in een bestand
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Dit voorbeeld wijzigt de ingebouwde eigenschappen van de presentatie zoals hieronder te zien is:

|**Ingebouwde documenteigenschappen na wijziging**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)||

## **Aangepaste documenteigenschappen toevoegen**

Aspose.Slides voor Node.js via Java stelt ontwikkelaars ook in staat om aangepaste waarden voor presentatiedocumenteigenschappen toe te voegen. Hieronder vindt u een voorbeeld dat laat zien hoe u aangepaste eigenschappen voor een presentatie kunt instellen.

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
    // Eigenschapsnaam ophalen op een bepaalde index
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

|**Aangepaste documenteigenschappen toegevoegd**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)||

## **Aangepaste eigenschappen benaderen en wijzigen**

Aspose.Slides voor Node.js via Java maakt het ook mogelijk om de waarden van aangepaste eigenschappen te benaderen. Hieronder staat een voorbeeld dat laat zien hoe u alle aangepaste eigenschappen van een presentatie kunt benaderen en wijzigen.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het DocumentProperties-object dat aan de Presentation is gekoppeld
    var dp = pres.getDocumentProperties();
    // Toegang tot en wijzigen van aangepaste eigenschappen
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

Dit voorbeeld wijzigt de aangepaste eigenschappen van de [PPTX](https://docs.fileformat.com/presentation/pptx/)‑presentatie. De volgende afbeeldingen tonen de aangepaste eigenschappen van de presentatie vóór en na wijziging:

|**Aangepaste eigenschappen vóór wijziging**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)||

|**Aangepaste eigenschappen na wijziging**|**|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)||

## **Geavanceerde documenteigenschappen**

{{% alert color="info" title="Note" %}}
Nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), en [WriteBindedPresentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) zijn toegevoegd aan [PresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo); de logica van de eigenschapssetter [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) is veranderd.
{{% /alert %}} 

De twee nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) en [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) zijn toegevoegd aan de klasse [PresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo). Ze bieden snelle toegang tot documenteigenschappen en stellen u in staat om eigenschappen te wijzigen en bij te werken zonder een volledige presentatie te laden.

Het typische scenario – eigenschappen laden, een waarde wijzigen en het document bijwerken – kan als volgt worden geïmplementeerd:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// lees de info van de presentatie
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

Een nieuw sjabloon kan vanaf nul worden aangemaakt en vervolgens worden gebruikt om meerdere presentaties bij te werken:

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

Aspose.Slides levert de eigenschap LanguageId (blootgesteld door de klasse PortionFormat) waarmee u de controlertaal voor een PowerPoint‑document kunt instellen. De controlertaal is de taal waarvoor spelling en grammatica in de PowerPoint worden gecontroleerd.

Deze JavaScript‑code toont hoe u de controlertaal voor een PowerPoint‑presentatie kunt instellen: xxx Waarom ontbreekt LanguageId in de JavaScript‑klasse PortionFormat?

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
    portionFormat.setLanguageId("zh-CN");// stel de Id in van een controlertaal
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Standaardtaal instellen**

Deze JavaScript‑code laat zien hoe u de standaardtaal voor een volledige PowerPoint‑presentatie kunt instellen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Voeg een nieuwe rechthoekige vorm toe met tekst
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Controleer de taal van de eerste portion
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Live‑voorbeeld**

Probeer de online app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen kunt werken via de Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## **FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter de waarden wijzigen of, indien de specifieke eigenschap dat toestaat, deze op een lege tekenreeks zetten.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. Het is niet nodig de eigenschap vooraf te verwijderen of te controleren, omdat Aspose.Slides de waarde automatisch bijwerkt.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) en vervolgens [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instance aan te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/nodejs-java/examine-presentation/) voor een volledig rapportage‑voorbeeld en formaatspecifieke beperkingen.