---
title: Beheer presentatie‑eigenschappen in JavaScript
linktitle: Presentatie‑eigenschappen
type: docs
weight: 70
url: /nl/nodejs-java/presentation-properties/
keywords:
- PowerPoint‑eigenschappen
- presentatie‑eigenschappen
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
description: "Beheer presentatieweigenschappen in Aspose.Slides voor Node.js via Java en stroomlijn zoeken, branding en workflow in uw PowerPoint‑ en OpenDocument‑bestanden."
---
## **Inleiding**

Aspose.Slides voor Node.js via Java ondersteunt **ingebouwde** en **aangepaste** documenteigenschappen. Gebruik deze eigenschappen om presentatiemetadata te lezen en bij te werken, zoals de auteur, titel en door‑gebruiker‑gedefinieerde waarden.

Aspose.Slides stelt u in staat om met presentatiedocumenteigenschappen te werken via de [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) klasse. Een instantie van deze klasse wordt geretourneerd door [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}
Aspose.Slides beheert de toepassings‑ en producentmetadata bij het opslaan van presentaties; deze velden identificeren de software die de output heeft gemaakt.
{{% /alert %}}

## **Presentatie‑eigenschappen Beheren**

Documenteigenschappen slaan beschrijvende informatie op naast de presentatie‑inhoud. Ze vallen in twee categorieën:

- **Ingebouwde eigenschappen** bevatten standaardmetadata, zoals de titel, auteur en documentstatistieken.
- **Aangepaste eigenschappen** slaan door de gebruiker gedefinieerde naam/waarde‑paren op.

Aspose.Slides voor Node.js via Java biedt toegang tot beide categorieën. In PowerPoint selecteert u **Bestand → Info → Eigenschappen → Geavanceerde Eigenschappen** om documentmetadata te inspecteren. Het dialoogvenster groepeert informatie in tabbladen zoals **Samenvatting**, **Statistieken**, **Inhoud** en **Aangepast**. Gebruik het tabblad **Aangepast** om door‑gebruiker‑gedefinieerde eigenschappen te beheren.

## **Openbare Eigenschappen Lezen van een Versleutelde Presentatie**

Een openingswachtwoord beschermt normaal zowel de presentatie‑inhoud als documenteigenschappen. Wanneer een presentatie wordt versleuteld na het aanroepen van [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) met `false`, blijven de documenteigenschappen openbaar. Een applicatie kan vervolgens [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) aanroepen met `true` en de openbare metadata lezen zonder het openingswachtwoord op te geven.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) bepaalt wat Aspose.Slides laadt; het ontsleutelt niets. Als de eigenschappen waren opgenomen in de versleuteling, mislukt het laden zonder wachtwoord. Als de presentatie niet versleuteld is, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het voorbeeld vereist een versleutelde presentatie waarvan de documenteigenschappen openbaar zijn gelaten. Het verifieert de laadmodus via [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) en leest vervolgens ingebouwde eigenschappen via [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

In deze modus wordt de slide‑inhoud niet geladen. Slides, masters, lay-outs, vormen, media en andere presentatie‑objecten zijn niet beschikbaar. Applicaties moeten altijd [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) controleren voordat ze een bewerking uitvoeren die het volledige presentatiemodel vereist.

{{% alert color="warning" title="Warning" %}}
Openbare metadata kan auteursnamen, titels, onderwerpen, trefwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden blootleggen. Versleutel gevoelige eigenschappen samen met de presentatie. Laat ze alleen openbaar wanneer indexering, classificatie, zoeken of document‑beheersystemen een specifieke vereiste hebben om er zonder wachtwoord toegang toe te krijgen.
{{% /alert %}}

## **Eigenschappen van een Versleutelde Presentatie Bijwerken**

Voor een versleuteld PPTX‑bestand is een presentatie die is geladen na het aanroepen van [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) met `true` bedoeld om openbare metadata te lezen. Aspose.Slides kan de gewijzigde eigenschappen niet opslaan vanuit dat alleen‑metadata‑object omdat de openbare eigenschappen consistent moeten blijven met de bijbehorende gegevens in de versleutelde presentatie. Het bijwerken ervan vereist daarom het juiste openingswachtwoord en een volledige load.

Het voorbeeld vereist een versleutelde PPTX‑presentatie met openbare documenteigenschappen en een bekend openingswachtwoord. Het opent de volledige presentatie met [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword), werkt openbare ingebouwde eigenschappen bij, en slaat het resultaat op. Vervolgens gebruikt het [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) om te verifiëren dat de versleuteling behouden blijft en opent de openbare metadata opnieuw zonder wachtwoord om de nieuwe waarden te controleren:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
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

Als een applicatie niet is toegestaan om de presentatie‑inhoud te ontsleutelen of te laden, moet deze de openbare eigenschappen van een versleuteld PPTX‑bestand als alleen‑lezen behandelen.

## **Toegang tot Ingebouwde Eigenschappen**

De [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) klasse biedt ingebouwde metadata via getter‑methoden, waaronder [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle), en [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). Dit voorbeeld opent een bestaande presentatie en drukt de opgeslagen metadata af naar de console. Waarden hangen af van de invoerpresentatie; sommige velden kunnen leeg zijn.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

### **Revisienummer en Bewerkingstijd Rapporteren**

Om het revisienummer en de totale bewerkingstijd voor elk PPTX‑bestand in de map `presentations` te rapporteren, gebruikt u [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties). Het retourneert de [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) van het bestand zonder de slides te laden voor bewerking. Het voorbeeld zet de geregistreerde duur om van milliseconden naar uren, minuten en seconden. Voor duur van 24 uur of meer, wordt de tijd voorafgegaan door het aantal volledige dagen.

```javascript
const fs = require("fs");
const path = require("path");
const slides = require("aspose.slides.via.java");

const folder = "presentations";
const files = fs.readdirSync(folder, { withFileTypes: true });
const factory = slides.PresentationFactory.getInstance();

console.log("File | RevisionNumber | TotalEditingTime");
for (const file of files) {
    if (!file.isFile() || path.extname(file.name).toLowerCase() !== ".pptx") {
        continue;
    }
    const filePath = path.join(folder, file.name);
    const info = factory.getPresentationInfo(filePath);
    const properties = info.readDocumentProperties();
    const totalSeconds = Math.floor(properties.getTotalEditingTime() / 1000);
    const days = Math.floor(totalSeconds / 86400);
    const hours = Math.floor(totalSeconds / 3600) % 24;
    const minutes = Math.floor(totalSeconds / 60) % 60;
    const seconds = totalSeconds % 60;
    const time = [hours, minutes, seconds].map(value => String(value).padStart(2, "0")).join(":");
    const editingTime = days > 0 ? `${days}.${time}` : time;
    console.log(`${file.name} | ${properties.getRevisionNumber()} | ${editingTime}`);
}
```

Voor een presentatie met een geregistreerde bewerkingstijd van 1 dag, 2 uur en 5 minuten, toont het rapport de volgende uitvoer.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getRevisionNumber) leest een waarde die applicaties kunnen wijzigen met [setRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setRevisionNumber). Het revisienummer alleen kan niet bepalen hoe vaak de presentatie is opgeslagen of de versiegeschiedenis reconstrueren.

[getTotalEditingTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTotalEditingTime) leest de bewerkingstijd die in het bestand is geregistreerd. Een waarde van `00:00:00` betekent dat de opgeslagen duur nul is, zelfs als iemand de presentatie heeft bewerkt.

## **Ingebouwde Eigenschappen Wijzigen**

Om ingebouwde metadata bij te werken, gebruikt u de setter‑methoden op het object dat wordt geretourneerd door [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Dit voorbeeld opent een bestaande presentatie, roept [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) en [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager) aan, en slaat vervolgens de bijgewerkte presentatie op met [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). De opgeslagen PPTX bevat de nieuwe metadata.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **De Hyperlink‑basis Beheren**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) geeft de document‑niveau basis terug voor relatieve hyperlinks. Gebruik [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) om deze te wijzigen of te wissen. Dit is nuttig bij het verplaatsen van een presentatie en de gekoppelde bestanden naar een andere locatie. Het is gescheiden van de individuele hyperlink‑[Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl): het wijzigen van de basis herschrijft niet de opgeslagen linkadressen of verandert absolute bestemmingen.

Het voorbeeld vereist een presentatie die zowel een relatieve link bevat, zoals `target.html`, als een absolute link, zoals `https://example.org/absolute.html`. Het leest de bestaande basis, wijst een nieuw basisadres toe, en slaat de presentatie op en opent deze opnieuw om de waarde te controleren. Vervolgens wist het de basis met een lege string en verifieert de lege waarde in een apart opgeslagen bestand. Vervang het voorbeeldbasisadres door de locatie van uw gekoppelde bestanden.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

De twee verificatie‑berichten moeten `true` afdrukken. Het wissen van de basis laat de individuele hyperlink‑adressen ongewijzigd.

Een relatieve link naar `target.pptx` opende `old/target.pptx` toen de basis naar de `old`‑map verwees. Na het wijzigen van de basis naar de `new`‑map, opslaan en de presentatie opnieuw openen, opende dezelfde link `new/target.pptx`. Een absolute link bleef hetzelfde bestand openen. Test uw relatieve links in PowerPoint vóór en na het verplaatsen van de presentatie of het wijzigen van de basis.

## **Aangepaste Presentatie‑eigenschappen Toevoegen**

Aangepaste eigenschappen slaan metadata op die geen overeenkomstig ingebouwd veld hebben. De [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) methode stelt u in staat een waarde toe te wijzen op basis van de eigenschapsnaam. Dit voorbeeld maakt een presentatie, voegt twee tekstwaarden en een integer versie‑waarde toe, en slaat de presentatie op met [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Het toewijzen van een waarde aan een bestaande naam vervangt de waarde van die eigenschap.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aangepaste Eigenschappen Toegang en Wijziging**

Dit voorbeeld opent een presentatie die aangepaste eigenschappen bevat en gebruikt [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) om erover te itereren. [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) accepteert een nulgebaseerde index en retourneert de naam die wordt gebruikt door [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item). Het voorbeeld drukt elke oorspronkelijke naam en waarde af, vervangt elke waarde door een genummerde tekenreeks ongeacht het oorspronkelijke type, en slaat de wijzigingen op. Als er geen aangepaste eigenschappen zijn, voert de lus geen wijzigingen uit.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Live‑voorbeeld**

Probeer de [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) online‑app om te zien hoe u met documenteigenschappen kunt werken via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een onlosmakelijk onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of ze leeg maken als de specifieke eigenschap dat toestaat.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. U hoeft de eigenschap niet vooraf te verwijderen of te controleren, omdat Aspose.Slides de waarde automatisch bijwerkt.

**Kan ik presentatieweigenschappen benaderen zonder de presentatie volledig te laden?**

Ja. Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) en vervolgens [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)‑instantie te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/nodejs-java/examine-presentation/) voor een volledig rapportage‑voorbeeld en formaat‑specifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openingswachtwoord?**

Ja. De presentatie moet zijn versleuteld nadat [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) is aangeroepen met `false`, en moet worden geladen nadat [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) is aangeroepen met `true`.

**Kan ik een versleuteld PPTX‑bestand bijwerken in de modus alleen‑document‑eigenschappen?**

Nee. Openbare en versleutelde eigenschapsgegevens moeten consistent blijven, dus het bijwerken van een versleuteld PPTX‑bestand vereist het volledige laden van de presentatie met het juiste openingswachtwoord.