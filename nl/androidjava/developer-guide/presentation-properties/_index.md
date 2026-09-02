---
title: Beheer presentatie-eigenschappen op Android
linktitle: Presentatie-eigenschappen
type: docs
weight: 70
url: /nl/androidjava/presentation-properties/
keywords:
- PowerPoint-eigenschappen
- presentatie-eigenschappen
- document-eigenschappen
- standaard-eigenschappen
- aangepaste eigenschappen
- geavanceerde eigenschappen
- eigenschappen beheren
- eigenschappen aanpassen
- document-metadata
- metadata bewerken
- controletaal
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

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Built-in** en **Custom**. Beide soorten eigenschappen kunnen eenvoudig worden benaderd en beheerd met behulp van de Aspose.Slides API.

Aspose.Slides stelt u in staat om met de documenteigenschappen van een presentatie te werken via de [IDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/) interface. Een instantie van deze interface wordt geretourneerd door de [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) methode. De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="info" title="Note" %}}
Let op dat de velden **Application** en **AppVersion** niet gewijzigd kunnen worden. Aspose.Slides schrijft ze bij elke opslag opnieuw, zodat een opgeslagen presentatie altijd de productnaam Aspose.Slides en de versie van de bibliotheek die het heeft geproduceerd meldt. Elke waarde die aan `setNameOfApplication` wordt doorgegeven, wordt genegeerd wanneer de presentatie wordt weggeschreven.
{{% /alert %}} 

## **Documenteigenschappen in PowerPoint**

Microsoft PowerPoint 2007 maakt het mogelijk om de documenteigenschappen van presentatiebestanden te beheren. Het enige dat u hoeft te doen is op het Office-pictogram te klikken en vervolgens het menu‑onderdeel **Prepare | Properties | Advanced Properties** van Microsoft PowerPoint 2007 te selecteren, zoals hieronder weergegeven:

|**Selecteren van menu‑item Geavanceerde eigenschappen**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Nadat u het menu‑item **Advanced Properties** hebt geselecteerd, verschijnt er een dialoogvenster waarmee u de documenteigenschappen van het PowerPoint‑bestand kunt beheren, zoals hieronder in de afbeelding wordt weergegeven:

|**Dialoogvenster Eigenschappen**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
In het bovenstaande **Properties Dialog** kunt u zien dat er veel tabbladen zijn, zoals **General**, **Summary**, **Statistics**, **Contents** en **Custom**. Al deze tabbladen stellen u in staat verschillende soorten informatie over de PowerPoint‑bestanden te configureren. Het tabblad **Custom** wordt gebruikt om de aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.

## **Werken met documenteigenschappen met Aspose.Slides voor Android via Java**

Zoals eerder beschreven ondersteunt Aspose.Slides voor Android via Java twee soorten documenteigenschappen, namelijk **Built-in** en **Custom** eigenschappen. Ontwikkelaars kunnen dus beide soorten eigenschappen benaderen met behulp van de Aspose.Slides voor Android via Java API. Aspose.Slides voor Android via Java biedt een klasse [IDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties) die de documenteigenschappen van een presentatiebestand voorstelt via de eigenschap **Presentation.DocumentProperties**.

Ontwikkelaars kunnen de eigenschap **IDocumentProperties**, die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) object, gebruiken om de documenteigenschappen van presentatiebestanden te benaderen zoals hieronder beschreven:

## **Toegang tot Built-in eigenschappen**

Deze eigenschappen, zoals blootgesteld door het [IDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties) object, omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Datum laatste afdruk), **LastModifiedBy**, **Keywords**, **SharedDoc** (Wordt gedeeld tussen verschillende producenten?), **PresentationFormat**, **Subject** en **Title**

```java
import com.aspose.slides.*;

// Instantieer de Presentation-klasse die de presentatie vertegenwoordigt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het IDocumentProperties-object dat is gekoppeld aan de presentatie
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

## **Built-in eigenschappen wijzigen**

Het wijzigen van de built-in eigenschappen van presentatiebestanden is net zo eenvoudig als het benaderen ervan. U kunt eenvoudig een tekenreeks aan een gewenste eigenschap toewijzen en de eigenschapswaarde zal worden aangepast. In het onderstaande voorbeeld laten we zien hoe we de built-in documenteigenschappen van een presentatiebestand kunnen wijzigen met Aspose.Slides voor Android via Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het IDocumentProperties-object dat gekoppeld is aan de presentatie
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

Dit voorbeeld wijzigt de built-in eigenschappen van de presentatie, zoals hieronder weergegeven:

|**Built-in documenteigenschappen na wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aangepaste documenteigenschappen toevoegen**

Aspose.Slides voor Android via Java stelt ontwikkelaars ook in staat om aangepaste waarden toe te voegen aan de documenteigenschappen van een presentatie. Het onderstaande voorbeeld voegt drie aangepaste eigenschappen toe, zoekt vervolgens de naam op die op index 2 is opgeslagen en verwijdert die eigenschap, zodat de opgeslagen presentatie er twee overhoudt. Aangepaste eigenschappen worden op alfabetische volgorde geïndexeerd, niet in de volgorde waarin ze zijn toegevoegd.

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
    
    // Naam van eigenschap op een specifieke index ophalen
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

Aspose.Slides voor Android via Java stelt ontwikkelaars ook in staat om de waarden van aangepaste eigenschappen te benaderen. Hieronder staat een voorbeeld dat laat zien hoe u alle aangepaste eigenschappen van een presentatie kunt benaderen en wijzigen.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het DocumentProperties-object dat aan de presentatie is gekoppeld
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Toegang tot en wijziging van aangepaste eigenschappen
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Weergave van namen en waarden van aangepaste eigenschappen
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

Dit voorbeeld wijzigt de aangepaste eigenschappen van de [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentatie. De onderstaande afbeeldingen tonen de aangepaste eigenschappen van de presentatie vóór en na de wijziging:

|**Aangepaste eigenschappen vóór wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Aangepaste eigenschappen na wijziging**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Geavanceerde documenteigenschappen**

{{% alert color="info" title="Note" %}}
Nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), en [WriteBindedPresentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) zijn toegevoegd aan [IPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo); de logica van de setter van de eigenschap [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) is gewijzigd.
{{% /alert %}} 

De twee nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) en [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) zijn toegevoegd aan de [IPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo) interface. Ze bieden snelle toegang tot documenteigenschappen en stellen u in staat eigenschappen te wijzigen en bij te werken zonder een volledige presentatie te laden.

Het typische scenario waarbij de eigenschappen worden geladen, een waarde wordt gewijzigd en het document wordt bijgewerkt, kan op de volgende manier worden geïmplementeerd:

```java
import com.aspose.slides.*;

// lees de informatie van de presentatie
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

Er kan een nieuw sjabloon vanaf nul worden aangemaakt en vervolgens worden gebruikt om meerdere presentaties bij te werken:

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

## **Spellings‑ en grammaticataal instellen**

Aspose.Slides biedt de eigenschap LanguageId (toegankelijk via de PortionFormat‑klasse) waarmee u de spellings‑ en grammaticataal voor een PowerPoint‑document kunt instellen. De spellings‑ en grammaticataal is de taal waarvoor spelling en grammatica in PowerPoint worden gecontroleerd.

Deze Java‑code laat zien hoe u de spellings‑ en grammaticataal voor een PowerPoint instelt:

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
    // Voegt een nieuwe rechthoekvorm met tekst toe
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Controleert de taal van de eerste sectie
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live‑voorbeeld**

Probeer de online app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen kunt werken via de Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## **Veelgestelde vragen**

**Hoe kan ik een built-in eigenschap uit een presentatie verwijderen?**

Built-in eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt echter hun waarden wijzigen of, indien de specifieke eigenschap dit toestaat, ze leeg laten.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. U hoeft de eigenschap niet vooraf te verwijderen of te controleren, omdat Aspose.Slides de waarde automatisch bijwerkt.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. Gebruik [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) en vervolgens [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) om opgeslagen documentmetadata te lezen zonder een [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/)‑instantie te maken. Zie [Build a Lightweight Presentation Inventory](/slides/nl/androidjava/examine-presentation/) voor een volledig rapportage‑voorbeeld en format‑specifieke beperkingen.