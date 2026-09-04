---
title: Beheer presentatie-eigenschappen in Java
linktitle: Presentatie-eigenschappen
type: docs
weight: 70
url: /nl/java/presentation-properties/
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
- Java
- Aspose.Slides
description: "Beheer presentatie-eigenschappen in Aspose.Slides for Java en stroomlijn zoeken, branding en workflows in uw PowerPoint- en OpenDocument-bestanden."
---
## **Inleiding**

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Ingebouwd** en **Aangepast**. Beide typen eigenschappen kunnen eenvoudig worden benaderd en beheerd met behulp van de Aspose.Slides‑API.

Aspose.Slides stelt u in staat om presentatie‑documenteigenschappen te gebruiken via de interface [IDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/) . Een instantie van deze interface wordt geretourneerd door [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getDocumentProperties--) . De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}

Houd er rekening mee dat de velden **Application** en **AppVersion** niet kunnen worden gewijzigd. Aspose.Slides herschrijft ze bij elke opslaan, zodat een opgeslagen presentatie altijd “Aspose.Slides for Java” en de versie van de bibliotheek vermeldt die het heeft gegenereerd. Elke waarde die aan `setNameOfApplication` wordt doorgegeven, wordt genegeerd wanneer de presentatie wordt weggeschreven.

{{% /alert %}} 

## **Documenteigenschappen in PowerPoint**

Microsoft PowerPoint 2007 maakt het mogelijk de documenteigenschappen van presentaties te beheren. Klik simpelweg op het Office‑pictogram en kies vervolgens **Prepare | Properties | Advanced Properties** in het menu van Microsoft PowerPoint 2007, zoals hieronder weergegeven:

|**Geavanceerde eigenschappen selecteren**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Nadat u **Advanced Properties** hebt gekozen, verschijnt een dialoogvenster waarmee u de documenteigenschappen van het PowerPoint‑bestand kunt beheren, zie de afbeelding hieronder:

|**Eigenschappen‑dialoog**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
In het bovenstaande **Eigenschappen‑dialoog** ziet u verschillende tabbladen zoals **General**, **Summary**, **Statistics**, **Contents** en **Custom**. Elk tabblad stelt u in staat andere soorten informatie over het PowerPoint‑bestand te configureren. Het **Custom**‑tabblad wordt gebruikt om aangepaste eigenschappen van PowerPoint‑bestanden te beheren.

### Werken met documenteigenschappen met Aspose.Slides for Java

Zoals eerder beschreven ondersteunt Aspose.Slides for Java twee soorten documenteigenschappen: **Ingebouwd** en **Aangepast**. Ontwikkelaars kunnen beide soorten via de Aspose.Slides for Java‑API benaderen. Aspose.Slides for Java levert de klasse [IDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties) die de documenteigenschappen van een presentatie representeert via de eigenschap **Presentation.DocumentProperties**.

Ontwikkelaars kunnen de eigenschap **IDocumentProperties** die door het object [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) wordt blootgesteld, gebruiken om de documenteigenschappen van presentatie‑bestanden te benaderen, zoals hieronder beschreven:

## **Openbare eigenschappen lezen uit een versleutelde presentatie**

Een openingswachtwoord beschermt normaal zowel de inhoud als de documenteigenschappen. Wanneer een presentatie wordt versleuteld door `false` door te geven aan [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), blijven de documenteigenschappen openbaar. Een applicatie kan vervolgens `true` doorgeven aan [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) en de openbare metadata lezen zonder een openingswachtwoord.

De optie “alleen documenteigenschappen laden” bepaalt wat Aspose.Slides laadt; er wordt niets gedecrypteerd. Als de eigenschappen wel versleuteld waren, faalt het laden zonder wachtwoord. Als de presentatie niet versleuteld is, wordt de optie genegeerd en wordt de volledige presentatie geladen.

Het volgende voorbeeld verifieert de laadmodus via [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) en leest vervolgens de ingebouwde eigenschappen via [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentation/#getDocumentProperties--) :

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

In deze modus wordt de slide‑inhoud niet geladen. Slides, masters, layouts, shapes, media en andere presentatie‑objecten zijn niet beschikbaar. Applicaties moeten altijd [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) controleren voordat ze een bewerking uitvoeren die het volledige objectmodel vereist.

{{% alert color="warning" title="Warning" %}}
Openbare metadata kan namen van auteurs, titels, onderwerpen, trefwoorden, bedrijfsinformatie, commentaren en aangepaste waarden onthullen. Versleutel gevoelige eigenschappen samen met de presentatie. Houd ze alleen openbaar wanneer indexering, classificatie, zoeken of document‑beheersystemen een specifieke eis hebben om ze zonder wachtwoord te benaderen.
{{% /alert %}}

## **Eigenschappen bijwerken van een versleutelde presentatie**

Voor een versleuteld PPTX‑bestand is een presentatie die in “alleen documenteigenschappen‑laden” modus is geopend bedoeld om openbare metadata te lezen. Aspose.Slides kan gewijzigde eigenschappen van dat metadata‑alleen object niet opslaan, omdat de openbare eigenschappen consistent moeten blijven met de corresponderende gegevens in de versleutelde presentatie. Bijwerken vereist daarom het juiste openingswachtwoord en een volledige laden.

Het volgende voorbeeld opent de presentatie met [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), werkt openbare ingebouwde eigenschappen bij en slaat het resultaat op. Vervolgens wordt met [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) geverifieerd dat de versleuteling behouden blijft en wordt de openbare metadata opnieuw zonder wachtwoord geopend om de nieuwe waarden te controleren:

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

Als een applicatie niet is toegestaan de presentatie‑inhoud te ontsleutelen of te laden, moet zij de openbare eigenschappen van een versleuteld PPTX‑bestand als alleen‑lezen behandelen.

## **Toegang tot ingebouwde eigenschappen**

De door [IDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties) blootgestelde eigenschappen omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Laatste afdrukdatum), **LastModifiedBy**, **SharedDoc** (Is gedeeld tussen verschillende makers?), **PresentationFormat**, **Subject** en **Title**

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die de presentatie representeert
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het IDocumentProperties-object dat bij de presentatie is gekoppeld
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

Het wijzigen van de ingebouwde eigenschappen van presentaties is even eenvoudig als ze te benaderen. U kunt eenvoudig een tekenreeks toewijzen aan de gewenste eigenschap en de waarde wordt aangepast. In het onderstaande voorbeeld laten we zien hoe de ingebouwde documenteigenschappen van een presentatie kunnen worden gewijzigd met Aspose.Slides for Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het IDocumentProperties-object dat bij de presentatie hoort
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Stel de ingebouwde eigenschappen in
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Sla uw presentatie op naar een bestand
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dit voorbeeld wijzigt de ingebouwde eigenschappen van de presentatie; het resultaat ziet er als volgt uit:

|**Ingebouwde documenteigenschappen na wijziging**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aangepaste documenteigenschappen toevoegen**

Aspose.Slides for Java stelt ontwikkelaars ook in staat aangepaste waarden toe te voegen aan de documenteigenschappen van een presentatie. Het onderstaande voorbeeld voegt drie aangepaste eigenschappen toe, zoekt vervolgens de naam op die op index 2 staat en verwijdert die eigenschap, zodat de opgeslagen presentatie er twee overhoudt. Aangepaste eigenschappen worden alfabetisch geïndexeerd, niet in de volgorde van toevoegen.

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
    
    // Eigenschapsnaam ophalen op een bepaalde index
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Geselecteerde eigenschap verwijderen
    dProps.removeCustomProperty(getPropertyName);
    
    // Presentatie opslaan
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Aangepaste documenteigenschappen toegevoegd**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Aangepaste eigenschappen benaderen en wijzigen**

Aspose.Slides for Java maakt het ook mogelijk de waarden van aangepaste eigenschappen te benaderen. Hieronder staat een voorbeeld dat laat zien hoe u alle aangepaste eigenschappen van een presentatie kunt benaderen en wijzigen.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het DocumentProperties-object dat aan de presentatie gekoppeld is
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Toegang tot en wijziging van aangepaste eigenschappen
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Toon namen en waarden van aangepaste eigenschappen
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Wijzig waarden van aangepaste eigenschappen
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Sla uw presentatie op naar een bestand
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dit voorbeeld wijzigt de aangepaste eigenschappen van de [PPTX](https://docs.fileformat.com/presentation/pptx/)‑presentatie. De onderstaande figuren tonen de aangepaste eigenschappen vóór en na de wijziging:

|**Aangepaste eigenschappen vóór wijziging**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Aangepaste eigenschappen na wijziging**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Geavanceerde documenteigenschappen**

{{% alert color="info" title="Note" %}}

Nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), en [WriteBindedPresentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) zijn toegevoegd aan [IPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo) ; de logica van de setter van [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) is gewijzigd.

{{% /alert %}} 

De twee nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) en [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) zijn toegevoegd aan de interface [IPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo). Ze bieden snelle toegang tot documenteigenschappen en maken het mogelijk eigenschappen te wijzigen zonder de volledige presentatie te laden.

Het typische scenario – eigenschappen laden, een waarde wijzigen en het document bijwerken – kan als volgt worden geïmplementeerd:

```java
import com.aspose.slides.*;

// lees de informatie van de presentatie
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// verkrijg de huidige eigenschappen
IDocumentProperties props = info.readDocumentProperties();

// stel de nieuwe waarden van de Auteur- en Titelvelden in
props.setAuthor("New Author");
props.setTitle("New Title");

// werk de presentatie bij met nieuwe waarden
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Er is een andere manier om de eigenschappen van een specifieke presentatie als sjabloon te gebruiken om eigenschappen in andere presentaties bij te werken:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
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

Een nieuw sjabloon kan van nul af aan worden gemaakt en vervolgens worden gebruikt om meerdere presentaties bij te werken:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Controlertaal instellen**

Aspose.Slides biedt de eigenschap LanguageId (geëxposeerd door de klasse PortionFormat) om de controlertaal voor een PowerPoint‑document in te stellen. De controlertaal is de taal waarvoor spelling‑ en grammaticacontrole in PowerPoint wordt uitgevoerd.

Deze Java‑code toont hoe u de controlertaal voor een PowerPoint‑presentatie instelt:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

Presentation pres = new Presentation(pptxFileName);
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

Deze Java‑code laat zien hoe u de standaardtaal voor een volledige PowerPoint‑presentatie instelt:

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

Probeer de online app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen werkt via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## **FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal deel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter de waarden wijzigen of, indien de specifieke eigenschap dat toestaat, deze op een lege waarde zetten.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. U hoeft de eigenschap niet eerst te verwijderen of te controleren; Aspose.Slides werkt de waarde automatisch bij.

**Kan ik presentatieweigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) en vervolgens [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/)‑instantie te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/java/examine-presentation/) voor een volledig rapportage‑voorbeeld en format‑specifieke beperkingen.

**Kan ik openbare eigenschappen van een versleutelde presentatie lezen zonder het openingswachtwoord?**

Ja. De versleuteling van documenteigenschappen moet vóór het versleutelen van de presentatie zijn uitgeschakeld, en de presentatie moet in de modus “alleen documenteigenschappen laden” worden geopend.

**Kan ik een versleuteld PPTX‑bestand bijwerken in de modus “alleen documenteigenschappen laden”?**

Nee. Publieke en versleutelde eigenschapsdata moeten consistent blijven; daarom vereist het bijwerken van een versleuteld PPTX‑bestand het volledige laden van de presentatie met het juiste openingswachtwoord.