---
title: Beheer presentatieweigenschappen in JavaScript
linktitle: Presentatieweigenschappen
type: docs
weight: 70
url: /nl/nodejs-java/presentation-properties/
keywords:
- PowerPoint-eigenschappen
- presentatieweigenschappen
- documenteigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- documentmetadata
- metadata bewerken
- proefleestaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer presentatieweigenschappen in Aspose.Slides voor Node.js via Java en vereenvoudig zoeken, branding en workflow in uw PowerPoint- en OpenDocument-bestanden."
---
## **Inleiding**

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Built-in** en **Custom**. Beide soorten eigenschappen kunnen eenvoudig worden benaderd en beheerd met behulp van de Aspose.Slides API.

Aspose.Slides stelt u in staat om met presentatiedocumenteigenschappen te werken via de [DocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties/) klasse. Een instantie van deze klasse wordt geretourneerd door de [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#getDocumentProperties) methode. De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="primary" %}} 
Let op dat u geen waarden kunt instellen voor de **Application** en **Producer** velden, omdat Aspose Ltd. en Aspose.Slides for Node.js via Java x.x.x in deze velden zullen worden weergegeven.
{{% /alert %}} 

## **Beheer Presentatie‑eigenschappen**

Microsoft PowerPoint biedt een functie om enkele eigenschappen aan de presentatiebestanden toe te voegen. Deze documenteigenschappen maken het mogelijk om nuttige informatie samen met de documenten (presentatiebestanden) op te slaan. Er zijn twee soorten documenteigenschappen:

- Systeemgedefinieerde (Built-in) Eigenschappen
- Gebruikersgedefinieerde (Custom) Eigenschappen

**Built-in** eigenschappen bevatten algemene informatie over het document, zoals de documenttitel, naam van de auteur, statistieken van het document, enzovoort. **Custom** eigenschappen zijn diegenen die door de gebruikers gedefinieerd worden als **Naam/Waarde** paren, waarbij zowel naam als waarde door de gebruiker worden opgegeven. Met Aspose.Slides for Node.js via Java kunnen ontwikkelaars zowel de waarden van ingebouwde eigenschappen als van aangepaste eigenschappen raadplegen en wijzigen.

## **Documenteigenschappen in PowerPoint**

Microsoft PowerPoint 2007 maakt het mogelijk om de documenteigenschappen van presentatiebestanden te beheren. Het enige wat u moet doen is op het Office‑pictogram klikken en vervolgens **Prepare | Properties | Advanced Properties** kiezen in Microsoft PowerPoint 2007, zoals hieronder weergegeven:

|**Advanced Properties menu‑item selecteren**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Nadat u het menu‑item **Advanced Properties** hebt geselecteerd, verschijnt er een dialoogvenster waarmee u de documenteigenschappen van het PowerPoint‑bestand kunt beheren, zoals hieronder in de afbeelding weergegeven:

|**Eigenschappen‑dialoog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

In de bovenstaande **Eigenschappen‑dialoog** ziet u dat er meerdere tabbladen zijn, zoals **General**, **Summary**, **Statistics**, **Contents** en **Custom**. Al deze tabbladen stellen u in staat verschillende soorten informatie met betrekking tot de PowerPoint‑bestanden te configureren. Het **Custom**‑tabblad wordt gebruikt om de aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.

### Werken met documenteigenschappen met Aspose.Slides for Node.js via Java

Zoals eerder beschreven ondersteunt Aspose.Slides for Node.js via Java twee soorten documenteigenschappen, namelijk **Built-in** en **Custom** eigenschappen. Ontwikkelaars kunnen dus beide soorten eigenschappen benaderen met behulp van de Aspose.Slides for Node.js via Java API. Aspose.Slides for Node.js via Java biedt een klasse [DocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties) die de documenteigenschappen van een presentatiebestand representeert via de **Presentation.DocumentProperties** eigenschap.

Ontwikkelaars kunnen de **DocumentProperties** eigenschap die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation) object gebruiken om de documenteigenschappen van presentatiebestanden te benaderen, zoals hieronder beschreven:

## **Toegang tot Built-in eigenschappen**

Deze eigenschappen, die worden blootgesteld door het [DocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties) object, omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Datum laatste afdruk), **LastModifiedBy**, **SharedDoc** (Wordt gedeeld tussen verschillende producenten?), **PresentationFormat**, **Subject** en **Title**.

```javascript
// Instantieer de Presentation-klasse die de presentatie vertegenwoordigt
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het IDocumentProperties-object dat gekoppeld is aan de Presentation
    var dp = pres.getDocumentProperties();
    // Geef de ingebouwde eigenschappen weer
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

## **Wijzigen van Built-in eigenschappen**

Het wijzigen van de ingebouwde eigenschappen van presentatiebestanden is even eenvoudig als het benaderen ervan. U kunt eenvoudig een tekenreeks toewijzen aan elke gewenste eigenschap en de eigenschapswaarde wordt dan aangepast. In het onderstaande voorbeeld laten we zien hoe we de ingebouwde documenteigenschappen van het presentatiebestand kunnen wijzigen met behulp van Aspose.Slides for Node.js via Java.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het IDocumentProperties-object dat aan de Presentation is gekoppeld
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

Dit voorbeeld wijzigt de ingebouwde eigenschappen van de presentatie, zoals hieronder te zien is:

|**Ingebouwde documenteigenschappen na wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aangepaste documenteigenschappen toevoegen**

Aspose.Slides for Node.js via Java stelt ontwikkelaars ook in staat om aangepaste waarden toe te voegen aan de documenteigenschappen van een presentatie. Hieronder staat een voorbeeld dat laat zien hoe u de aangepaste eigenschappen voor een presentatie kunt instellen.

```javascript
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

|**Aangepaste documenteigenschappen toegevoegd**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Toegang tot en wijzigen van aangepaste eigenschappen**

Aspose.Slides for Node.js via Java maakt het ook mogelijk om de waarden van aangepaste eigenschappen te benaderen. Hieronder staat een voorbeeld dat laat zien hoe u alle aangepaste eigenschappen van een presentatie kunt benaderen en wijzigen.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het DocumentProperties-object dat aan de Presentation is gekoppeld
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

Dit voorbeeld wijzigt de aangepaste eigenschappen van de [PPTX](https://docs.fileformat.com/presentation/pptx/) presentatie. De onderstaande afbeeldingen tonen de aangepaste eigenschappen van de presentatie vóór en na wijziging:

|**Aangepaste eigenschappen vóór wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Aangepaste eigenschappen na wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Geavanceerde documenteigenschappen**

{{% alert color="primary" %}} 
Nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), en [WriteBindedPresentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) zijn toegevoegd aan [PresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo), de logica van de [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) eigenschapssetter is aangepast.
{{% /alert %}} 

De twee nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) en [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) zijn toegevoegd aan de [PresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PresentationInfo) klasse. Ze bieden snelle toegang tot documenteigenschappen en stellen u in staat eigenschappen te wijzigen en bij te werken zonder een volledige presentatie te laden.

Het typische scenario van het laden van de eigenschappen, een waarde wijzigen en het document bijwerken kan op de volgende manier worden geïmplementeerd:

```javascript
// lees de informatie van de presentatie
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// obtain the current properties
var props = info.readDocumentProperties();
// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");
// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Er is een andere manier om de eigenschappen van een bepaalde presentatie als sjabloon te gebruiken om eigenschappen in andere presentaties bij te werken:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Er kan een nieuw sjabloon vanaf nul worden gemaakt en vervolgens worden gebruikt om meerdere presentaties bij te werken:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Proofing‑taal instellen**

Aspose.Slides levert de LanguageId eigenschap (beschikbaar via de PortionFormat‑klasse) waarmee u de proefleestaal voor een PowerPoint‑document kunt instellen. De proefleestaal is de taal waarvoor spelling en grammatica in PowerPoint worden gecontroleerd.

Deze JavaScript‑code laat zien hoe u de proefleestaal voor een PowerPoint instelt: xxx Waarom ontbreekt LanguageId in de JavaScript PortionFormat‑klasse?

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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
    portionFormat.setLanguageId("zh-CN");// stel het Id van een proefleestaal in
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

Probeer de online app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen kunt werken via de Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## ***FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of, indien door de specifieke eigenschap toegestaan, deze op een lege waarde zetten.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. Het is niet nodig om de eigenschap vooraf te verwijderen of te controleren, omdat Aspose.Slides de waarde van de eigenschap automatisch bijwerkt.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja, u kunt presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden door de `getPresentationInfo` methode van de [PresentationFactory](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationfactory/) klasse te gebruiken. Vervolgens kunt u de `readDocumentProperties` methode van de [PresentationInfo](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentationinfo/) klasse benutten om de eigenschappen efficiënt uit te lezen, waardoor geheugen wordt bespaard en de prestaties verbeteren.