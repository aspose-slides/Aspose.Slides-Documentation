---
title: Beheer presentatie‑eigenschappen op Android
linktitle: Presentatie‑eigenschappen
type: docs
weight: 70
url: /nl/androidjava/presentation-properties/
keywords:
- PowerPoint‑eigenschappen
- presentatie‑eigenschappen
- document‑eigenschappen
- ingebouwde‑eigenschappen
- aangepaste‑eigenschappen
- geavanceerde‑eigenschappen
- eigenschappen beheren
- eigenschappen wijzigen
- document‑metadata
- metadata bewerken
- correctietaal
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer presentatie‑eigenschappen in Aspose.Slides for Android via Java en stroomlijn zoeken, branding en workflow in uw PowerPoint‑ en OpenDocument‑bestanden."
---
## **Introductie**

Aspose.Slides ondersteunt twee soorten documenteigenschappen: **Ingebouwd** en **Aangepast**. Beide soorten eigenschappen kunnen eenvoudig worden benaderd en beheerd via de Aspose.Slides API.

Aspose.Slides maakt het mogelijk om te werken met de documenteigenschappen van een presentatie via de [IDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties/) interface. Een instantie van deze interface wordt teruggegeven door de [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) methode. De volgende voorbeelden tonen hoe deze eigenschappen gelezen, gewijzigd en beheerd kunnen worden.

{{% alert color="primary" %}} 
Let op dat de velden **Application** en **Producer** niet kunnen worden aangepast, aangezien deze velden altijd "Aspose Ltd." en "Aspose.Slides for Android via Java x.x.x" weergeven.
{{% /alert %}} 

## **Documenteigenschappen in PowerPoint**

Microsoft PowerPoint 2007 maakt het mogelijk om de documenteigenschappen van presentaties te beheren. Het enige wat je moet doen, is op het Office‑pictogram klikken en vervolgens **Prepare | Properties | Advanced Properties** kiezen in het menu van Microsoft PowerPoint 2007, zoals hieronder weergegeven:

|**Selecteer het menu‑item Geavanceerde eigenschappen**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Na het selecteren van het menu‑item **Advanced Properties** verschijnt er een dialoogvenster waarmee je de documenteigenschappen van het PowerPoint‑bestand kunt beheren, zoals in de onderstaande afbeelding weergegeven:

|**Dialoogvenster Eigenschappen**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
In het bovenstaande **Dialoogvenster Eigenschappen** zie je verschillende tabbladen, zoals **General**, **Summary**, **Statistics**, **Contents** en **Custom**. Al deze tabbladen laten toe verschillende soorten informatie over de PowerPoint‑bestanden in te stellen. Het tabblad **Custom** wordt gebruikt om de aangepaste eigenschappen van de PowerPoint‑bestanden te beheren.



Werken met documenteigenschappen met Aspose.Slides for Android via Java

Zoals eerder beschreven ondersteunt Aspose.Slides for Android via Java twee soorten documenteigenschappen, namelijk **Built-in** en **Custom**. Ontwikkelaars kunnen beide soorten eigenschappen benaderen via de Aspose.Slides for Android via Java API. Aspose.Slides for Android via Java biedt de klasse [IDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties) die de documenteigenschappen van een presentatiesbestand vertegenwoordigt via de eigenschap **Presentation.DocumentProperties**.

Ontwikkelaars kunnen de eigenschap **IDocumentProperties**, die wordt blootgesteld door het [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) object, gebruiken om de documenteigenschappen van presentaties op te vragen, zoals hieronder beschreven:

## **Toegang tot ingebouwde eigenschappen**

Deze eigenschappen, die worden blootgesteld via het [IDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties) object, omvatten: **Creator** (Auteur), **Description**, **Keywords**, **Created** (Aanmaakdatum), **Modified** (Wijzigingsdatum), **Printed** (Datum laatste afdruk), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is gedeeld tussen verschillende producenten?), **PresentationFormat**, **Subject** en **Title**

```java
// Instantieer de Presentation‑klasse die de presentatie vertegenwoordigt
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het IDocumentProperties‑object dat aan de Presentation is gekoppeld
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

Het wijzigen van de ingebouwde eigenschappen van presentaties is net zo eenvoudig als het benaderen ervan. Je kunt eenvoudig een tekenreeks toewijzen aan een gewenste eigenschap en de waarde wordt aangepast. In het onderstaande voorbeeld tonen we hoe we de ingebouwde documenteigenschappen van een presentatiedocument kunnen wijzigen met Aspose.Slides for Android via Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het IDocumentProperties‑object dat aan de Presentation is gekoppeld
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Stel de ingebouwde eigenschappen in
    dp.setAuthor("Aspose.Slides for Android via Java");
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

Dit voorbeeld wijzigt de ingebouwde eigenschappen van de presentatie, zoals hieronder te zien is:

|**Ingebouwde documenteigenschappen na wijziging**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aangepaste documenteigenschappen toevoegen**

Aspose.Slides for Android via Java stelt ontwikkelaars bovendien in staat om aangepaste waarden toe te voegen aan de documenteigenschappen van een presentatie. Hieronder staat een voorbeeld dat laat zien hoe je aangepaste eigenschappen voor een presentatie kunt instellen.

```java
Presentation pres = new Presentation();
try {
    // Documenteigenschappen ophalen
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Aangepaste eigenschappen toevoegen
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Eigenschapsnaam ophalen op bepaalde index
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

Aspose.Slides for Android via Java maakt het ook mogelijk om de waarden van aangepaste eigenschappen te benaderen. Hieronder staat een voorbeeld dat laat zien hoe je alle aangepaste eigenschappen van een presentatie kunt benaderen en wijzigen.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Maak een referentie naar het DocumentProperties‑object dat aan de Presentation is gekoppeld
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Toegang tot en wijziging van aangepaste eigenschappen
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Toon de namen en waarden van aangepaste eigenschappen
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Wijzig de waarden van aangepaste eigenschappen
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Sla uw presentatie op naar een bestand
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Dit voorbeeld wijzigt de aangepaste eigenschappen van de [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentatie. De onderstaande afbeeldingen tonen de aangepaste eigenschappen vóór en na wijziging:

|**Aangepaste eigenschappen vóór wijziging**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Aangepaste eigenschappen na wijziging**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Geavanceerde documenteigenschappen**

{{% alert color="primary" %}} 
Nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), en [WriteBindedPresentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) zijn toegevoegd aan [IPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo), de logica van de setter van de eigenschap [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) is aangepast.
{{% /alert %}} 

De twee nieuwe methoden [ReadDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) en [UpdateDocumentProperties](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) zijn toegevoegd aan de interface [IPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/IPresentationInfo). Ze bieden snelle toegang tot documenteigenschappen en maken het mogelijk om eigenschappen te wijzigen en bij te werken zonder een volledige presentatie te laden.

Het typische scenario waarbij de eigenschappen worden geladen, een waarde wordt aangepast en het document wordt bijgewerkt, kan op de volgende manier worden geïmplementeerd:

```java
// lees de info van de presentatie
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// verkrijg de huidige eigenschappen
IDocumentProperties props = info.readDocumentProperties();

// stel de nieuwe waarden van de Auteur- en Titel-velden in
props.setAuthor("New Author");
props.setTitle("New Title");

// werk de presentatie bij met nieuwe waarden
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Er is een alternatieve manier om de eigenschappen van een specifieke presentatie als sjabloon te gebruiken om eigenschappen in andere presentaties bij te werken:

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

Er kan een nieuw sjabloon vanaf nul worden aangemaakt en vervolgens worden gebruikt om meerdere presentaties bij te werken:

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

## **Controlertaal instellen**

Aspose.Slides biedt de eigenschap LanguageId (beschikbaar via de PortionFormat‑klasse) waarmee je de controlertaal voor een PowerPoint‑document kunt instellen. De controlertaal is de taal waarvoor de spelling en grammatica in PowerPoint worden gecontroleerd.

Deze Java‑code toont hoe je de controlertaal voor een PowerPoint kunt instellen: xxx Waarom ontbreekt LanguageId in de Java‑klasse PortionFormat?

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

    portionFormat.setLanguageId("zh-CN"); // stel de Id van een correctietaal in

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Standaardtaal instellen**

Deze Java‑code toont hoe je de standaardtaal voor een volledige PowerPoint‑presentatie kunt instellen:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Voegt een nieuwe rechthoekvorm met tekst toe
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Controleert de taal van de eerste portion
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live‑voorbeeld**

Probeer de online‑app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/nl/metadata) om te zien hoe je met documenteigenschappen kunt werken via de Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/nl/metadata)

## ***FAQ**

**Hoe kan ik een ingebouwde eigenschap uit een presentatie verwijderen?**

Ingebouwde eigenschappen vormen een integraal onderdeel van de presentatie en kunnen niet volledig worden verwijderd. Je kunt ze echter wel aanpassen of, indien de specifieke eigenschap dat toestaat, leeg maken.

**Wat gebeurt er als ik een aangepaste eigenschap toevoeg die al bestaat?**

Als je een aangepaste eigenschap toevoegt die al bestaat, wordt de bestaande waarde overschreven door de nieuwe. Je hoeft de eigenschap niet eerst te verwijderen of te controleren; Aspose.Slides werkt de eigenschapswaarde automatisch bij.

**Kan ik presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden?**

Ja, je kunt presentatie‑eigenschappen benaderen zonder de volledige presentatie te laden door de `getPresentationInfo`‑methode van de klasse [PresentationFactory](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentationfactory/) te gebruiken. Vervolgens kun je de `readDocumentProperties`‑methode van de interface [IPresentationInfo](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ipresentationinfo/) gebruiken om de eigenschappen efficiënt uit te lezen, waardoor geheugen wordt bespaard en de prestaties worden verbeterd.