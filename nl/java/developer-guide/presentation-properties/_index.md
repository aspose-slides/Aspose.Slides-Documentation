---
title: Beheer presentatie-eigenschappen in Java
linktitle: Presentatie‑eigenschappen
type: docs
weight: 70
url: /nl/java/presentation-properties/
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
- controletaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer presentatie‑eigenschappen in Aspose.Slides voor Java en stroomlijn zoeken, branding en workflow in uw PowerPoint‑ en OpenDocument‑bestanden."
---
## **Inleiding**

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Ingebouwd** en **Aangepast**. Beide soorten eigenschappen kunnen eenvoudig worden benaderd en beheerd via de Aspose.Slides‑API.

Aspose.Slides stelt u in staat om met documenteigenschappen van presentaties te werken via de interface [IDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties/) . Een instantie van deze interface wordt geretourneerd door de methode [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getDocumentProperties--) . De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" %}} 
Let op dat de velden **Application** en **AppVersion** niet kunnen worden gewijzigd. Aspose.Slides herschrijft ze bij elke opslag, zodat een opgeslagen presentatie altijd “Aspose.Slides for Java” en de versie van de gebruikte bibliotheek rapporteert. Elke waarde die aan `setNameOfApplication` wordt doorgegeven, wordt genegeerd wanneer de presentatie wordt weggeschreven.
{{% /alert %}} 

## **Documenteigenschappen in PowerPoint**

Microsoft PowerPoint 2007 maakt het beheer van de documenteigenschappen van presentaties mogelijk. U hoeft alleen op het Office‑pictogram te klikken en vervolgens **Prepare | Properties | Advanced Properties** te kiezen in Microsoft PowerPoint 2007, zoals hieronder weergegeven:

|**Selecting Advanced Properties menu item**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Nadat u het menu‑item **Advanced Properties** hebt geselecteerd, verschijnt een dialoogvenster waarmee u de documenteigenschappen van het PowerPoint‑bestand kunt beheren, zoals hieronder in de afbeelding wordt weergegeven:

|**Properties Dialog**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
In de bovenstaande **Properties Dialog** ziet u verschillende tabbladen, zoals **General**, **Summary**, **Statistics**, **Contents** en **Custom**. Al deze tabbladen stellen u in staat verschillende soorten informatie over de PowerPoint‑bestanden te configureren. Het tabblad **Custom** wordt gebruikt om de aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.

### Werken met documenteigenschappen met Aspose.Slides for Java

Zoals eerder beschreven ondersteunt Aspose.Slides for Java twee soorten documenteigenschappen: **Built-in** en **Custom**. Ontwikkelaars kunnen beide soorten eigenschappen benaderen via de Aspose.Slides for Java‑API. Aspose.Slides for Java biedt de klasse [IDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties) die de documenteigenschappen van een presentatiedocument vertegenwoordigt via de eigenschap **Presentation.DocumentProperties**.

Ontwikkelaars kunnen de eigenschap **IDocumentProperties**, die beschikbaar wordt gesteld door het object [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) gebruiken om de documenteigenschappen van presentaties te benaderen, zoals hieronder beschreven:

## **Ingebouwde eigenschappen benaderen**

Deze eigenschappen, die beschikbaar zijn via het object [IDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties) , omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Laatste afdrukdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wordt gedeeld tussen verschillende makers?), **PresentationFormat**, **Subject** en **Title**.

```java
import com.aspose.slides.*;

// Instantieer de Presentation‑klasse die de presentatie vertegenwoordigt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een verwijzing naar het IDocumentProperties‑object dat aan de presentatie is gekoppeld
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Geef de ingebouwde eigenschappen weer
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

Het wijzigen van de ingebouwde eigenschappen van presentaties is net zo eenvoudig als ze te benaderen. U kunt eenvoudig een tekenreeks toewijzen aan een gewenste eigenschap en de waarde wordt aangepast. In het onderstaande voorbeeld laten we zien hoe de ingebouwde documenteigenschappen van een presentatie kunnen worden gewijzigd met Aspose.Slides for Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het IDocumentProperties‑object dat aan de presentatie is gekoppeld
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

Dit voorbeeld wijzigt de ingebouwde eigenschappen van de presentatie, zoals hieronder wordt weergegeven:

|**Ingebouwde documenteigenschappen na wijziging**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aangepaste documenteigenschappen toevoegen**

Aspose.Slides for Java stelt ontwikkelaars bovendien in staat om aangepaste waarden toe te voegen aan de documenteigenschappen van een presentatie. Het onderstaande voorbeeld voegt drie aangepaste eigenschappen toe, zoekt vervolgens de naam op die op index 2 is opgeslagen en verwijdert die eigenschap, zodat de opgeslagen presentatie er twee overhoudt. Aangepaste eigenschappen worden alfabetisch geïndexeerd, niet in de volgorde waarin ze zijn toegevoegd.

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
    
    // Eigenschapnaam op een bepaalde index ophalen
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

Aspose.Slides for Java stelt ontwikkelaars ook in staat om de waarden van aangepaste eigenschappen te benaderen. Hieronder staat een voorbeeld dat laat zien hoe u alle aangepaste eigenschappen van een presentatie kunt benaderen en wijzigen.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het DocumentProperties‑object dat aan de presentatie is gekoppeld
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Toegang tot en wijziging van aangepaste eigenschappen
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Namen en waarden van aangepaste eigenschappen tonen
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Waarden van aangepaste eigenschappen wijzigen
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Sla uw presentatie op naar een bestand
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dit voorbeeld wijzigt de aangepaste eigenschappen van de [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentatie. De volgende afbeeldingen tonen de aangepaste eigenschappen van de presentatie vóór en na de wijziging:

|**Aangepaste eigenschappen vóór wijziging**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Aangepaste eigenschappen na wijziging**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Geavanceerde documenteigenschappen**

{{% alert color="info" %}} 
Nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), en [WriteBindedPresentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) zijn toegevoegd aan [IPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo), de logica van de eigenschapsetter [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) is aangepast.
{{% /alert %}} 

De twee nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) en [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) zijn toegevoegd aan de interface [IPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo). Ze bieden snelle toegang tot documenteigenschappen en maken het mogelijk om eigenschappen te wijzigen en bij te werken zonder een volledige presentatie te laden.

Een typisch scenario waarbij de eigenschappen worden geladen, een waarde wordt gewijzigd en het document wordt bijgewerkt, kan op de volgende manier worden geïmplementeerd:

```java
import com.aspose.slides.*;

// lees de info van de presentatie
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// verkrijg de huidige eigenschappen
IDocumentProperties props = info.readDocumentProperties();

// stel de nieuwe waarden van de velden Auteur en Titel in
props.setAuthor("New Author");
props.setTitle("New Title");

// werk de presentatie bij met nieuwe waarden
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Er is een andere manier om de eigenschappen van een bepaalde presentatie als sjabloon te gebruiken om eigenschappen in andere presentaties bij te werken:

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

Er kan een nieuw sjabloon vanaf nul worden gemaakt en vervolgens worden gebruikt om meerdere presentaties bij te werken:

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

## **Controletaal instellen**

Aspose.Slides biedt de eigenschap LanguageId (beschikbaar via de klasse PortionFormat) waarmee u de controletaal voor een PowerPoint‑document kunt instellen. De controletaal is de taal waarvoor de spelling en grammatica in PowerPoint worden gecontroleerd.

Deze Java‑code laat zien hoe u de controletaal voor een PowerPoint kunt instellen:

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

    portionFormat.setLanguageId("zh-CN"); // stel de Id van een controletaal in

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standaardtaal instellen**

Deze Java‑code laat zien hoe u de standaardtaal voor een volledige PowerPoint‑presentatie kunt instellen:

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

Probeer de online‑app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen kunt werken via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## ***FAQ**

### Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt ze echter wel wijzigen of, indien de specifieke eigenschap dat toelaat, op een lege waarde zetten.

### Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. Het is niet nodig de eigenschap eerst te verwijderen of te controleren, omdat Aspose.Slides de waarde automatisch bijwerkt.

### Kan ik presentatie‑eigenschappen benaderen zonder de presentatie volledig te laden?

Ja, u kunt presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden door de methode `getPresentationInfo` van de klasse [PresentationFactory](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentationfactory/) te gebruiken. Vervolgens kunt u de methode `readDocumentProperties` van de interface [IPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/) gebruiken om de eigenschappen efficiënt uit te lezen, wat geheugen bespaart en de prestaties verbetert.