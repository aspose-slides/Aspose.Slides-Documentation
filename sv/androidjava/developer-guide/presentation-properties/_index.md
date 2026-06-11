---
title: "Hantera presentationsegenskaper på Android"
linktitle: "Presentationsegenskaper"
type: docs
weight: 70
url: /sv/androidjava/presentation-properties/
keywords:
- PowerPoint-egenskaper
- presentationsegenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- modifiera egenskaper
- dokumentmetadata
- redigera metadata
- korrekturspråk
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för Android via Java och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med Aspose.Slides API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/). En instans av detta gränssnitt returneras av metoden [Presentation.getDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) . Följande exempel visar hur man läser, ändrar och hanterar dessa egenskaper.

{{% alert color="primary" %}} 
Observera att fälten **Application** och **Producer** inte kan ändras, eftersom dessa fält alltid kommer att visa "Aspose Ltd." och "Aspose.Slides for Android via Java x.x.x".
{{% /alert %}} 

## **Dokumentegenskaper i PowerPoint**

Microsoft PowerPoint 2007 gör det möjligt att hantera dokumentegenskaperna för presentationsfilerna. Allt du behöver göra är att klicka på Office‑ikonen och sedan på menyalternativet **Prepare | Properties | Advanced Properties** i Microsoft PowerPoint 2007 som visas nedan:

|**Välja menyalternativet Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Efter att du har valt menyalternativet **Advanced Properties** visas en dialogruta som låter dig hantera dokumentegenskaperna för PowerPoint‑filen, som visas nedan i figuren:

|**Egenskapsdialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

I ovanstående **Egenskapsdialog** kan du se att det finns många flikar såsom **General**, **Summary**, **Statistics**, **Contents** och **Custom**. Alla dessa flikar låter dig konfigurera olika typer av information relaterad till PowerPoint‑filerna. Fliken **Custom** används för att hantera de anpassade egenskaperna för PowerPoint‑filerna.

Arbeta med dokumentegenskaper med Aspose.Slides för Android via Java

Som vi beskrev tidigare stödjer Aspose.Slides för Android via Java två typer av dokumentegenskaper, nämligen **Inbyggda** och **Anpassade** egenskaper. Så kan utvecklare komma åt båda typerna av egenskaper med Aspose.Slides för Android via Java API. Aspose.Slides för Android via Java tillhandahåller klassen [IDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties) som representerar dokumentegenskaperna som är kopplade till en presentationsfil via egenskapen **Presentation.DocumentProperties**.

Utvecklare kan använda egenskapen **IDocumentProperties** som exponeras av objektet [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) för att komma åt dokumentegenskaperna för presentationsfilerna enligt beskrivningen nedan:

## **Kom åt inbyggda egenskaper**

Dessa egenskaper som exponeras av objektet [IDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties) inkluderar: **Creator** (Författare), **Description**, **Keywords**, **Created** (Skapandedatum), **Modified** (Ändringsdatum), **Printed** (Senaste utskriftsdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Delas mellan olika producenter?), **PresentationFormat**, **Subject** och **Title**

```java
// Skapa en instans av Presentation-klassen som representerar presentationen
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Skapa en referens till IDocumentProperties-objektet som är associerat med Presentation
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

## **Ändra inbyggda egenskaper**

Att ändra de inbyggda egenskaperna för presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till någon önskad egenskap så ändras egenskapens värde. I exemplet nedan har vi demonstrerat hur vi kan ändra de inbyggda dokumentegenskaperna för presentationsfilen med Aspose.Slides för Android via Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Skapa en referens till IDocumentProperties-objektet som är associerat med Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Ange de inbyggda egenskaperna
    dp.setAuthor("Aspose.Slides for Android via Java");
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

Detta exempel ändrar de inbyggda egenskaperna för presentationen som kan ses nedan:

|**Inbyggda dokumentegenskaper efter ändring**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Lägg till anpassade dokumentegenskaper**

Aspose.Slides för Android via Java låter även utvecklare lägga till anpassade värden för presentationsdokumentegenskaper. Ett exempel ges nedan som visar hur man sätter de anpassade egenskaperna för en presentation.

```java
Presentation pres = new Presentation();
try {
    // Hämtar dokumentegenskaper
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Lägger till anpassade egenskaper
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Hämtar egenskapsnamn på specifikt index
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Tar bort vald egenskap
    dProps.removeCustomProperty(getPropertyName);
    
    // Sparar presentation
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Anpassade dokumentegenskaper tillagda**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Kom åt och ändra anpassade egenskaper**

Aspose.Slides för Android via Java låter även utvecklare komma åt värdena för anpassade egenskaper. Ett exempel ges nedan som visar hur du kan komma åt och ändra alla dessa anpassade egenskaper för en presentation.

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
    
        // Ändra värden för anpassade egenskaper
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Spara din presentation till en fil
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Detta exempel ändrar de anpassade egenskaperna för [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentationen. Följande figurer visar presentationens anpassade egenskaper före och efter ändring:

|**Anpassade egenskaper före ändring**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Anpassade egenskaper efter ändring**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Avancerade dokumentegenskaper**

{{% alert color="primary" %}} 
Nya metoder [ReadDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) , [UpdateDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) och [WriteBindedPresentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) har lagts till i [IPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo), logiken för egenskapssättaren [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) har ändrats.
{{% /alert %}} 

De två nya metoderna [ReadDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) och [UpdateDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) har lagts till i [IPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo)‑gränssnittet. De ger snabb åtkomst till dokumentegenskaper och möjliggör att ändra och uppdatera egenskaper utan att ladda en hel presentation.

Det typiska scenariot att ladda egenskaperna, ändra ett värde och uppdatera dokumentet kan implementeras på följande sätt:

```java
// läs informationen om presentationen
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// hämta de aktuella egenskaperna
IDocumentProperties props = info.readDocumentProperties();

// sätt de nya värdena för författare och titel-fälten
props.setAuthor("New Author");
props.setTitle("New Title");

// uppdatera presentationen med nya värden
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Det finns ett annat sätt att använda egenskaperna för en viss presentation som en mall för att uppdatera egenskaper i andra presentationer:

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

## **Ställ in korrekturspråk**

Aspose.Slides tillhandahåller egenskapen LanguageId (exponerad av klassen PortionFormat) för att låta dig ställa in korrekturspråket för ett PowerPoint-dokument. Korrekturspråket är det språk för vilket stavning och grammatik i PowerPoint kontrolleras.

Den här Java‑koden visar hur du ställer in korrekturspråket för en PowerPoint: xxx Varför saknas LanguageId i Java‑klassen PortionFormat?

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

    portionFormat.setLanguageId("zh-CN"); // ange ID för ett korrekturspråk

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ställ in standardspråk**

Den här Java‑kod visar hur du ställer in standardspråket för en hel PowerPoint‑presentation:

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

Prova den online‑appen [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) för att se hur du arbetar med dokumentegenskaper via Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## ***FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja, du kan komma åt presentationsegenskaper utan att ladda hela presentationen genom att använda metoden `getPresentationInfo` från klassen [PresentationFactory](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentationfactory/). Använd sedan `readDocumentProperties`‑metoden som tillhandahålls av gränssnittet [IPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/) för att läsa egenskaperna effektivt, vilket sparar minne och förbättrar prestanda.