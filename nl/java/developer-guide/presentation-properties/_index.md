---
title: Beheer presentatie‑eigenschappen in Java
linktitle: Presentatie‑eigenschappen
type: docs
weight: 70
url: /nl/java/presentation-properties/
keywords:
- PowerPoint‑eigenschappen
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
- Java
- Aspose.Slides
description: "Beheer presentatie‑eigenschappen in Aspose.Slides for Java en stroomlijn zoeken, branding en workflow in uw PowerPoint‑ en OpenDocument‑bestanden."
---
## **Inleiding**

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Ingebouwde** en **Aangepaste**. Beide eigenschapstypen kunnen gemakkelijk worden benaderd en beheerd via de Aspose.Slides‑API.

Aspose.Slides stelt u in staat om met presentatie‑documenteigenschappen te werken via de [IDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides.idocumentproperties/) interface. Een instantie van deze interface wordt teruggegeven door de [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#getDocumentProperties--) methode. De volgende voorbeelden laten zien hoe u deze eigenschappen kunt lezen, wijzigen en beheren.

{{% alert color="primary" %}} 
Houd er rekening mee dat de velden **Application** en **Producer** niet kunnen worden gewijzigd; deze velden tonen altijd “Aspose Ltd.” en “Aspose.Slides for Java x.x.x”.
{{% /alert %}} 

## **Documenteigenschappen in PowerPoint**

Microsoft PowerPoint 2007 maakt het mogelijk de documenteigenschappen van presentaties te beheren. Klik gewoon op het Office‑pictogram en vervolgens op **Voorbereiden | Eigenschappen | Geavanceerde eigenschappen** in Microsoft PowerPoint 2007 zoals hieronder weergegeven:

|**Selectie van “Geavanceerde eigenschappen”**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Nadat u het menu‑item **Geavanceerde eigenschappen** hebt gekozen, verschijnt er een dialoogvenster waarin u de documenteigenschappen van het PowerPoint‑bestand kunt beheren, zie onderstaande weergave:

|**Eigenschappen‑dialoog**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
In het bovenstaande **Eigenschappen‑dialoog** ziet u verschillende tabbladen zoals **Algemeen**, **Samenvatting**, **Statistieken**, **Inhoud** en **Aangepast**. Al deze tabbladen maken het mogelijk verschillende soorten informatie over de PowerPoint‑bestanden in te stellen. Het tabblad **Aangepast** wordt gebruikt om de aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.

### Werken met documenteigenschappen met Aspose.Slides for Java

Zoals eerder beschreven ondersteunt Aspose.Slides for Java twee soorten documenteigenschappen: **Ingebouwde** en **Aangepaste**. Ontwikkelaars kunnen beide soorten eigenschappen benaderen via de Aspose.Slides for Java API. Aspose.Slides for Java biedt een klasse [IDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides.idocumentproperties) die de documenteigenschappen van een presentatiedocument vertegenwoordigt via de eigenschap **Presentation.DocumentProperties**.

Ontwikkelaars kunnen de **IDocumentProperties**‑eigenschap, blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation)‑object, gebruiken om de documenteigenschappen van presentaties te benaderen, zoals hieronder beschreven:

## **Toegang tot ingebouwde eigenschappen**

De door het [IDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides.idocumentproperties)‑object blootgestelde eigenschappen omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (creatiedatum), **Modified** (wijzigingsdatum), **Printed** (laatste afdrukdatum), **LastModifiedBy**, **SharedDoc** (Is gedeeld tussen verschillende producenten?), **PresentationFormat**, **Subject** en **Title**.

```java
// Instantieer de Presentation‑klasse die de presentatie vertegenwoordigt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een verwijzing naar het IDocumentProperties‑object dat bij de presentatie hoort
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

Het wijzigen van de ingebouwde eigenschappen van presentaties is net zo eenvoudig als ze te benaderen. U kunt simpelweg een tekenreeks toewijzen aan een gewenste eigenschap; de eigenschapswaarde wordt dan aangepast. In het onderstaande voorbeeld tonen we hoe u de ingebouwde documenteigenschappen van een presentatie kunt wijzigen met Aspose.Slides for Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een verwijzing naar het IDocumentProperties object dat bij de presentatie hoort
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Stel de ingebouwde eigenschappen in
    dp.setAuthor("Aspose.Slides for Java");
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

Dit voorbeeld wijzigt de ingebouwde eigenschappen van de presentatie, zoals hieronder weergegeven:

|**Ingebouwde documenteigenschappen na wijziging**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aangepaste documenteigenschappen toevoegen**

Aspose.Slides for Java stelt ontwikkelaars ook in staat aangepaste waarden toe te voegen aan de documenteigenschappen van een presentatie. Het voorbeeld hieronder laat zien hoe u aangepaste eigenschappen voor een presentatie kunt instellen.

```java
Presentation pres = new Presentation();
try {
    // Documenteigenschappen ophalen
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Aangepaste eigenschappen toevoegen
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Eigenschapsnaam op bepaalde index ophalen
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Geselecteerde eigenschap verwijderen
    dProps.removeCustomProperty(getPropertyName);
    
    // Presentatie opslaan
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Toegevoegde aangepaste documenteigenschappen**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Aangepaste eigenschappen benaderen en wijzigen**

Aspose.Slides for Java maakt het tevens mogelijk de waarden van aangepaste eigenschappen te benaderen. Het voorbeeld hieronder laat zien hoe u alle aangepaste eigenschappen van een presentatie kunt openen en aanpassen.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het DocumentProperties‑object dat bij de presentatie hoort
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Toegang tot en wijziging van aangepaste eigenschappen
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

Dit voorbeeld wijzigt de aangepaste eigenschappen van de [PPTX](https://docs.fileformat.com/presentation/pptx/) presentatie. De volgende afbeeldingen tonen de aangepaste eigenschappen vóór en na de wijziging:

|**Aangepaste eigenschappen vóór wijziging**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Aangepaste eigenschappen na wijziging**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Geavanceerde documenteigenschappen**

{{% alert color="primary" %}} 
Nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), en [WriteBindedPresentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) zijn toegevoegd aan [IPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo); de logica van de [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nl/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) setter is aangepast.
{{% /alert %}} 

De twee nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) en [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) zijn toegevoegd aan de interface [IPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/IPresentationInfo). Ze bieden snelle toegang tot documenteigenschappen en maken het mogelijk om eigenschappen te wijzigen zonder een volledige presentatie in te laden.

Het typische scenario – eigenschappen laden, een waarde wijzigen en vervolgens het document bijwerken – kan als volgt worden geïmplementeerd:

```java
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
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Een nieuw sjabloon kan van nul af aan worden gemaakt en vervolgens worden gebruikt om meerdere presentaties bij te werken:

```java
DocumentProperties template = new DocumentProperties();\

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
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Proefleestaal instellen**

Aspose.Slides biedt de eigenschap LanguageId (beschikbaar via de klasse PortionFormat) om de proefleestaal voor een PowerPoint‑document in te stellen. De proefleestaal is de taal waarvoor spelling en grammatica in PowerPoint worden gecontroleerd.

Deze Java‑code laat zien hoe u de proefleestaal voor een PowerPoint‑document instelt:

```java
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

    portionFormat.setLanguageId("zh-CN"); // stel de Id in van een proefleestaal

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standaardtaal instellen**

Deze Java‑code laat zien hoe u de standaardtaal voor een volledige PowerPoint‑presentatie instelt:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Voeg een nieuw rechthoekvorm toe met tekst
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Controleert de taal van de eerste portie
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Livevoorbeeld**

Probeer de online app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe u met documenteigenschappen werkt via de Aspose.Slides‑API:

[![Bekijk & bewerk PowerPoint‑metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## ***FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen maken een integraal onderdeel van de presentatie uit en kunnen niet volledig worden verwijderd. U kunt ze echter wel aanpassen of, indien de eigenschap dat toestaat, leegmaken.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als u een aangepaste eigenschap toevoegt die al aanwezig is, wordt de bestaande waarde overschreven met de nieuwe. U hoeft de eigenschap niet eerst te verwijderen of te controleren; Aspose.Slides werkt de waarde automatisch bij.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja. U kunt de presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden door de `getPresentationInfo`‑methode van de [PresentationFactory](https://reference.aspose.com/slides/nl/java/com.aspose.slides.presentationfactory/) klasse te gebruiken. Vervolgens kunt u de `readDocumentProperties`‑methode van de [IPresentationInfo](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ipresentationinfo/) interface aanroepen om de eigenschappen efficiënt te lezen, waardoor geheugen wordt bespaard en de prestaties verbeteren.