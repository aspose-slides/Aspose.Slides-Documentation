---
title: Beheer presentatie-eigenschappen op Android
linktitle: Presentatie-eigenschappen
type: docs
weight: 70
url: /nl/androidjava/presentation-properties/
keywords:
- PowerPoint-eigenschappen
- presentatie-eigenschappen
- documenteigenschappen
- ingebouwde eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- documentmetadata
- metadata bewerken
- controlertaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer presentatie-eigenschappen in Aspose.Slides voor Android via Java en stroomlijn zoeken, branding en workflow in uw PowerPoint- en OpenDocument-bestanden."
---
## **Inleiding**

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Built-in** en **Custom**. Beide soorten eigenschappen kunnen eenvoudig worden benaderd en beheerd met de Aspose.Slides API.

Aspose.Slides stelt je in staat om te werken met presentatie‑documenteigenschappen via de [IDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/) interface. Een instantie van deze interface wordt geretourneerd door [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). De volgende voorbeelden laten zien hoe je deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Opmerking" %}}
Let op dat de velden **Application** en **AppVersion** niet kunnen worden aangepast. Aspose.Slides herschrijft ze bij elke opslag, zodat een opgeslagen presentatie altijd de productnaam van Aspose.Slides en de versie van de bibliotheek die het heeft gegenereerd weergeeft. Elke waarde die aan `setNameOfApplication` wordt doorgegeven, wordt genegeerd wanneer de presentatie wordt weggeschreven.
{{% /alert %}} 

## **Documenteigenschappen in PowerPoint**

Microsoft PowerPoint 2007 maakt het mogelijk om de documenteigenschappen van de presentatiebestanden te beheren. Het enige wat je hoeft te doen is op het Office‑icoon te klikken en vervolgens het menu‑onderdeel **Prepare | Properties | Advanced Properties** van Microsoft PowerPoint 2007 te kiezen, zoals hieronder weergegeven:

|**Selectie van het menu‑onderdeel Geavanceerde eigenschappen**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Nadat je het menu‑onderdeel **Advanced Properties** hebt geselecteerd, verschijnt er een dialoogvenster waarmee je de documenteigenschappen van het PowerPoint‑bestand kunt beheren, zoals hieronder in de afbeelding wordt getoond:

|**Dialoogvenster Eigenschappen**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
In het bovenstaande **Dialoogvenster Eigenschappen** zie je dat er verschillende tabbladen zijn, zoals **General**, **Summary**, **Statistics**, **Contents** en **Custom**. Al deze tabbladen maken het mogelijk om verschillende soorten informatie over de PowerPoint‑bestanden te configureren. Het tabblad **Custom** wordt gebruikt om de aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.



## **Werken met documenteigenschappen met Aspose.Slides voor Android via Java**

Zoals eerder beschreven ondersteunt Aspose.Slides voor Android via Java twee soorten documenteigenschappen, namelijk **Built-in** en **Custom**. Ontwikkelaars kunnen dus beide soorten eigenschappen benaderen via de Aspose.Slides voor Android via Java API. Aspose.Slides voor Android via Java levert de klasse [IDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties) die de documenteigenschappen van een presentatiebestand vertegenwoordigt via de eigenschap **Presentation.DocumentProperties**.

Ontwikkelaars kunnen de **IDocumentProperties**‑eigenschap, blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation)‑object, gebruiken om de documenteigenschappen van de presentaties te benaderen zoals hieronder beschreven:

## **Openbare eigenschappen lezen van een versleutelde presentatie**

Een openings‑wachtwoord beschermt normaal zowel de inhoud van de presentatie als de documenteigenschappen. Wanneer een presentatie wordt versleuteld door `false` door te geven aan [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), blijven de documenteigenschappen openbaar. Een applicatie kan vervolgens `true` doorgeven aan [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) en de openbare metadata lezen zonder het openings‑wachtwoord op te geven.

De optie ‘document‑properties‑only’ bepaalt wat Aspose.Slides laadt; het ontsleutelt niets. Als de eigenschappen bij de versleuteling waren inbegrepen, mislukt het laden zonder wachtwoord. Is de presentatie niet versleuteld, dan wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het volgende voorbeeld controleert de laadmodus via [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) en leest vervolgens ingebouwde eigenschappen via [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

In deze modus wordt de inhoud van de dia’s niet geladen. Dia’s, masters, lay-outs, vormen, media en andere presentatie‑objecten zijn niet beschikbaar. Applicaties moeten altijd [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) controleren voordat ze een bewerking uitvoeren die het volledige presentatiemodel vereist.

{{% alert color="warning" title="Waarschuwing" %}}
Openbare metadata kan auteursnamen, titels, onderwerpen, sleutelwoorden, bedrijfsinformatie, opmerkingen en aangepaste waarden blootleggen. Versleutel gevoelige eigenschappen samen met de presentatie. Houd ze alleen openbaar wanneer indexering, classificatie, zoeken of document‑beheersystemen een specifieke vereiste hebben om ze zonder wachtwoord te benaderen.
{{% /alert %}}

## **Eigenschappen bijwerken van een versleutelde presentatie**

Voor een versleuteld PPTX‑bestand is een presentatie die in document‑properties‑only‑modus is geladen bedoeld om openbare metadata te lezen. Aspose.Slides kan gewijzigde eigenschappen van dat metadata‑enkel object niet opslaan omdat de openbare eigenschappen consistent moeten blijven met de bijbehorende gegevens in de versleutelde presentatie. Het bijwerken daarvan vereist daarom het juiste openings‑wachtwoord en een volledige load.

Het volgende voorbeeld opent de presentatie met [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), wijzigt openbare ingebouwde eigenschappen en slaat het resultaat op. Vervolgens wordt [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) gebruikt om te verifieren dat de versleuteling behouden blijft en wordt de openbare metadata opnieuw geopend zonder wachtwoord om de nieuwe waarden te controleren:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Als een applicatie niet is toegestaan om de presentatie‑inhoud te ontsleutelen of te laden, moet ze de openbare eigenschappen van een versleuteld PPTX‑bestand als alleen‑lezen behandelen.

## **Toegang tot ingebouwde eigenschappen**

Deze eigenschappen, blootgelegd door het [IDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties) object, omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Datum laatste afdruk), **LastModifiedBy**, **SharedDoc** (Gedeeld tussen verschillende makers?), **PresentationFormat**, **Subject** en **Title**

```java
import com.aspose.slides.*;

// Instantieer de Presentation‑klasse die de presentatie vertegenwoordigt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het IDocumentProperties‑object dat aan de presentatie is gekoppeld
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Toon de ingebouwde eigenschappen
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ingebouwde eigenschappen wijzigen**

Het wijzigen van de ingebouwde eigenschappen van presentaties is net zo eenvoudig als ze benaderen. Je kunt simpelweg een tekenreeks toewijzen aan elke gewenste eigenschap en de eigenschapswaarde wordt aangepast. In het onderstaande voorbeeld laten we zien hoe we de ingebouwde documenteigenschappen van het presentatie‑bestand kunnen wijzigen met Aspose.Slides voor Android via Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het IDocumentProperties‑object dat aan de presentatie is gekoppeld
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Stel de ingebouwde eigenschappen in
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Sla uw presentatie op in een bestand
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dit voorbeeld wijzigt de ingebouwde eigenschappen van de presentatie, zoals hieronder te zien is:

|**Ingebouwde documenteigenschappen na wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aangepaste documenteigenschappen toevoegen**

Aspose.Slides voor Android via Java maakt het ook mogelijk voor ontwikkelaars om aangepaste waarden voor presentatie‑documenteigenschappen toe te voegen. Het onderstaande voorbeeld voegt drie aangepaste eigenschappen toe, zoekt vervolgens de naam op die op index 2 is opgeslagen en verwijdert die eigenschap, zodat de opgeslagen presentatie er twee overhoudt. Aangepaste eigenschappen worden alfabetisch geïndexeerd, niet in de volgorde waarin ze zijn toegevoegd.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Documenteigenschappen ophalen
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Aangepaste eigenschappen toevoegen
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Eigenschapnaam ophalen op een bepaalde index
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Geselecteerde eigenschap verwijderen
    dProps.removeCustomProperty(getPropertyName);
    
    // Presentatie opslaan
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Aangepaste documenteigenschappen toegevoegd**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Aangepaste eigenschappen benaderen en wijzigen**

Aspose.Slides voor Android via Java maakt het ook mogelijk voor ontwikkelaars om de waarden van aangepaste eigenschappen te benaderen. Het volgende voorbeeld toont hoe je alle aangepaste eigenschappen van een presentatie kunt benaderen en wijzigen.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het DocumentProperties‑object dat aan de presentatie is gekoppeld
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Toegang tot en wijzigen van aangepaste eigenschappen
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Toon namen en waarden van aangepaste eigenschappen
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Wijzig waarden van aangepaste eigenschappen
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Sla uw presentatie op in een bestand
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dit voorbeeld wijzigt de aangepaste eigenschappen van de [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentatie. De onderstaande figuren tonen de aangepaste eigenschappen van de presentatie vóór en na wijziging:

|**Aangepaste eigenschappen vóór wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Aangepaste eigenschappen na wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Geavanceerde documenteigenschappen**

{{% alert color="info" title="Opmerking" %}}
Nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), en [WriteBindedPresentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) zijn toegevoegd aan [IPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo); de logica van de setter voor de eigenschap [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) is gewijzigd.
{{% /alert %}} 

De twee nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) en [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) zijn toegevoegd aan de [IPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo) interface. Ze bieden snelle toegang tot documenteigenschappen en maken het mogelijk eigenschappen te wijzigen en bij te werken zonder een volledige presentatie te laden.

Het typische scenario – eigenschappen laden, een waarde wijzigen en het document bijwerken – kan als volgt worden geïmplementeerd:

```java
import com.aspose.slides.*;

// lees de informatie van de presentatie
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Er is een alternatieve manier om de eigenschappen van een bepaalde presentatie als sjabloon te gebruiken om eigenschappen in andere presentaties bij te werken:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

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

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Een nieuw sjabloon kan van de grond af worden gemaakt en vervolgens worden gebruikt om meerdere presentaties bij te werken:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Controlertaal instellen**

Aspose.Slides biedt de eigenschap LanguageId (blootgelegd door de klasse PortionFormat) om de controlertaal voor een PowerPoint‑document in te stellen. De controlertaal is de taal waarvoor spelling en grammatica in de PowerPoint worden gecontroleerd.

Deze Java‑code toont hoe je de controlertaal voor een PowerPoint instelt:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // stel de Id van een controlertaal in

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standaardtaal instellen**

Deze Java‑code toont hoe je de standaardtaal voor een volledige PowerPoint‑presentatie instelt:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Voegt een nieuwe rechthoekvorm toe met tekst
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Controleert de taal van de eerste portion
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live‑voorbeeld**

Probeer de online app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe je met documenteigenschappen werkt via de Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## **Veelgestelde vragen**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. Je kunt echter hun waarden wijzigen of, indien de specifieke eigenschap dit toestaat, op een lege waarde zetten.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als je een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. Het is niet nodig om de eigenschap eerst te verwijderen of te controleren; Aspose.Slides werkt de eigenschapswaarde automatisch bij.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) en daarna [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/androidjava/examine-presentation/) voor een volledig rapportage‑voorbeeld en format‑specifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openings‑wachtwoord?**

Ja. De versleuteling van documenteigenschappen moet vóór het versleutelen van de presentatie zijn uitgeschakeld, en de presentatie moet worden geladen in document‑properties‑only‑modus.

**Kan ik een versleuteld PPTX‑bestand bijwerken in document‑properties‑only‑modus?**

Nee. Publieke en versleutelde eigenschapsdata moeten consistent blijven, dus het bijwerken van een versleuteld PPTX‑bestand vereist het volledige laden van de presentatie met het correcte openings‑wachtwoord.