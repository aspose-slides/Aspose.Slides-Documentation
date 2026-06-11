---
title: Hantera presentationssegenskaper i Java
linktitle: Presentationssegenskaper
type: docs
weight: 70
url: /sv/java/presentation-properties/
keywords:
- PowerPoint-egenskaper
- presentationssegenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- modifiera egenskaper
- dokumentmetadata
- redigera metadata
- korrekturläsningsspråk
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för Java och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med Aspose.Slides API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idocumentproperties/). En instans av detta gränssnitt returneras av metoden [Presentation.getDocumentProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getDocumentProperties--) . Följande exempel visar hur man läser, modifierar och hanterar dessa egenskaper.

{{% alert color="primary" %}} 

Observera att fälten **Application** och **Producer** inte kan ändras, eftersom dessa alltid visar "Aspose Ltd." och "Aspose.Slides for Java x.x.x".

{{% /alert %}} 

## **Dokumentegenskaper i PowerPoint**

Microsoft PowerPoint 2007 möjliggör hantering av dokumentegenskaper för presentationsfiler. Allt du behöver göra är att klicka på Office‑ikonen och sedan menyalternativet **Prepare | Properties | Advanced Properties** i Microsoft PowerPoint 2007 som visas nedan:

|**Välja menyobjektet Avancerade egenskaper**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

När du väljer menyobjektet **Advanced Properties** visas en dialogruta som låter dig hantera dokumentegenskaperna för PowerPoint‑filen, som visas i figuren nedan:

|**Egenskapsdialog**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
I dialogrutan **Egenskapsdialog** ser du flera flikar såsom **General**, **Summary**, **Statistics**, **Contents** och **Custom**. Alla dessa flikar låter dig konfigurera olika typer av information relaterad till PowerPoint‑filerna. Fliken **Custom** används för att hantera anpassade egenskaper för PowerPoint‑filerna.

### Arbeta med dokumentegenskaper med Aspose.Slides för Java

Som vi nämnde tidigare stöder Aspose.Slides för Java två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Utvecklare kan komma åt båda typerna via Aspose.Slides för Java API. Aspose.Slides för Java tillhandahåller klassen [IDocumentProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idocumentproperties) som representerar dokumentegenskaperna som är associerade med en presentationsfil genom egenskapen **Presentation.DocumentProperties**.

Utvecklare kan använda egenskapen **IDocumentProperties** som exponeras av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation)‑objektet för att komma åt dokumentegenskaperna för presentationsfilerna enligt följande:

## **Kom åt inbyggda egenskaper**

De egenskaper som exponeras av objektet [IDocumentProperties] inkluderar: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** och **Title**.

```java
// Instansiera Presentation‑klassen som representerar presentationen
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Skapa en referens till IDocumentProperties‑objektet som är associerat med Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Visa de inbyggda egenskaperna
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

## **Modifiera inbyggda egenskaper**

Att modifiera de inbyggda egenskaperna för presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till önskad egenskap så uppdateras värdet. I exemplet nedan demonstreras hur man kan modifiera de inbyggda dokumentegenskaperna för en presentation med Aspose.Slides för Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Skapa en referens till IDocumentProperties‑objektet som är associerat med Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Ställ in de inbyggda egenskaperna
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Spara din presentation till en fil
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Detta exempel ändrar de inbyggda egenskaperna för presentationen och visas som följer:

|**Inbyggda dokumentegenskaper efter modifiering**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Lägg till anpassade dokumentegenskaper**

Aspose.Slides för Java låter även utvecklare lägga till anpassade värden för presentationsdokumentegenskaper. Exemplet nedan visar hur man sätter anpassade egenskaper för en presentation.

```java
Presentation pres = new Presentation();
try {
    // Hämtar dokumentegenskaper
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Lägger till anpassade egenskaper
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Hämtar egenskapsnamn på ett specifikt index
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Tar bort vald egenskap
    dProps.removeCustomProperty(getPropertyName);
    
    // Sparar presentation
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Anpassade dokumentegenskaper tillagda**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Kom åt och modifiera anpassade egenskaper**

Aspose.Slides för Java låter också utvecklare komma åt värdena för anpassade egenskaper. Exemplet nedan visar hur du kan komma åt och ändra alla dessa anpassade egenskaper för en presentation.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Skapa en referens till DocumentProperties-objektet som är associerat med Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Kom åt och ändra anpassade egenskaper
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Visa namn och värden för anpassade egenskaper
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Ändra värden på anpassade egenskaper
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Spara din presentation till en fil
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Detta exempel modifierar de anpassade egenskaperna för [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentationen. Följande figurer visar de anpassade egenskaperna före och efter modifiering:

|**Anpassade egenskaper före modifiering**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Anpassade egenskaper efter modifiering**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Avancerade dokumentegenskaper**

{{% alert color="primary" %}} 

Nya metoder [ReadDocumentProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), och [WriteBindedPresentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) har lagts till i [IPresentationInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentationInfo); logiken för egenskaps­settern [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) har ändrats.

{{% /alert %}} 

De två nya metoderna [ReadDocumentProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) och [UpdateDocumentProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) har lagts till i gränssnittet [IPresentationInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentationInfo). De ger snabb åtkomst till dokumentegenskaper och möjliggör ändring och uppdatering utan att ladda in hela presentationen.

Det typiska scenariot – ladda egenskaperna, ändra ett värde och uppdatera dokumentet – kan implementeras på följande sätt:

```java
// Läs informationen om presentationen
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// Hämta aktuella egenskaper
IDocumentProperties props = info.readDocumentProperties();

// Ange de nya värdena för Author- och Title-fälten
props.setAuthor("New Author");
props.setTitle("New Title");

// Uppdatera presentationen med nya värden
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Ett alternativ är att använda egenskaperna från en specifik presentation som mall för att uppdatera egenskaper i andra presentationer:

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

En ny mall kan skapas från grunden och sedan användas för att uppdatera flera presentationer:

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

## **Ange korrekturläsningsspråk**

Aspose.Slides tillhandahåller egenskapen LanguageId (exponerad av klassen PortionFormat) för att låta dig ange korrekturläsningsspråket för ett PowerPoint‑dokument. Korrekturläsningsspråket är det språk som stavning och grammatik kontrolleras för i PowerPoint.

Denna Java‑kod visar hur du ställer in korrekturläsningsspråket för en PowerPoint: xxx Varför saknas LanguageId i Java‑klassen PortionFormat?

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

    portionFormat.setLanguageId("zh-CN"); // sätt Id för ett korrekturläsningsspråk

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ange standardspråk**

Denna Java‑kod visar hur du ställer in standardspråket för en hel PowerPoint‑presentation:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Lägger till en ny rektangelform med text
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Kontrollerar första portionsspråket
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live‑exempel**

Prova [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) online‑app för att se hur du arbetar med dokumentegenskaper via Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## ***FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller, om det är tillåtet för den specifika egenskapen, sätta dem till tomma.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar värdet.

**Kan jag komma åt presentationsegenskaper utan att ladda in hela presentationen?**

Ja, du kan komma åt presentationsegenskaper utan att ladda in hela presentationen genom att använda `getPresentationInfo`‑metoden från klassen [PresentationFactory](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationfactory/). Använd sedan `readDocumentProperties`‑metoden som erbjuds av gränssnittet [IPresentationInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationinfo/) för att läsa egenskaperna effektivt, vilket sparar minne och förbättrar prestanda.