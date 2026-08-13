---
title: Hantera presentationsegenskaper i Java
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/java/presentation-properties/
keywords:
- PowerPoint‑egenskaper
- presentations‑egenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- ändra egenskaper
- dokumentmetadata
- redigera metadata
- korrekturläsningsspråk
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för Java och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint‑ och OpenDocument‑filer."
---
## **Introduktion**

Aspose.Slides stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med hjälp av Aspose.Slides API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idocumentproperties/) . En instans av detta gränssnitt returneras av metoden [Presentation.getDocumentProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getDocumentProperties--) . Följande exempel visar hur man läser, ändrar och hanterar dessa egenskaper.

{{% alert color="info" %}} 

Observera att fälten **Application** och **AppVersion** inte kan ändras. Aspose.Slides skriver om dem vid varje sparning, så en sparad presentation alltid rapporterar "Aspose.Slides for Java" och versionen av biblioteket som skapade den. Alla värden som skickas till `setNameOfApplication` ignoreras när presentationen skrivs.

{{% /alert %}} 

## **Dokumentegenskaper i PowerPoint**

Microsoft PowerPoint 2007 möjliggör hantering av dokumentegenskaper i presentationsfilerna. Allt du behöver göra är att klicka på Office‑ikonen och sedan på menyalternativet **Prepare | Properties | Advanced Properties** i Microsoft PowerPoint 2007, som visas nedan:

|**Välja menyalternativet Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Efter att du har valt menyalternativet **Advanced Properties** visas en dialogruta som låter dig hantera dokumentegenskaperna för PowerPoint‑filen, som visas nedan i figuren:

|**Egendomsdialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

I dialogrutan **Properties Dialog** ovan kan du se att det finns många flikar som **General**, **Summary**, **Statistics**, **Contents** och **Custom**. Alla dessa flikar möjliggör konfiguration av olika typer av information relaterad till PowerPoint‑filerna. Fliken **Custom** används för att hantera de anpassade egenskaperna i PowerPoint‑filerna.

### Arbeta med dokumentegenskaper med Aspose.Slides för Java

Som vi beskrivit tidigare stödjer Aspose.Slides för Java två typer av dokumentegenskaper, nämligen **Inbyggda** och **Anpassade** egenskaper. Så kan utvecklare få åtkomst till båda typerna med hjälp av Aspose.Slides för Java‑API. Aspose.Slides för Java tillhandahåller klassen [IDocumentProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idocumentproperties) som representerar dokumentegenskaperna som är associerade med en presentationsfil via egenskapen **Presentation.DocumentProperties**.

Utvecklare kan använda egenskapen **IDocumentProperties** som exponeras av objektet [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation) för att komma åt dokumentegenskaperna i presentationsfilerna enligt beskrivningen nedan:

## **Åtkomst till inbyggda egenskaper**

Dessa egenskaper, som exponeras av objektet [IDocumentProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idocumentproperties) , inkluderar: **Creator** (Författare), **Description**, **Keywords**, **Created** (Skapelsedatum), **Modified** (Ändringsdatum), **Printed** (Senaste utskriftsdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Delas mellan olika producenter?), **PresentationFormat**, **Subject** och **Title**

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar presentationen
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

Att ändra de inbyggda egenskaperna i presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till önskad egenskap så kommer egenskapsvärdet att ändras. I exemplet nedan visar vi hur vi kan ändra de inbyggda dokumentegenskaperna i presentationsfilen med hjälp av Aspose.Slides för Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Skapa en referens till IDocumentProperties-objektet som är associerat med Presentation
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

Detta exempel ändrar de inbyggda egenskaperna i presentationen som kan ses nedan:

|**Inbyggda dokumentegenskaper efter ändring**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Lägg till anpassade dokumentegenskaper**

Aspose.Slides för Java låter också utvecklare lägga till anpassade värden för presentationens dokumentegenskaper. Exemplet nedan lägger till tre anpassade egenskaper, hämtar sedan namnet som lagras på index 2 och tar bort den egenskapen, så den sparade presentationen behåller två av dem. Anpassade egenskaper indexeras i alfabetisk ordning, inte i den ordning de lades till.

```java
import com.aspose.slides.*;

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

|**Anpassade dokumentegenskaper tillagda**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Åtkomst till och ändring av anpassade egenskaper**

Aspose.Slides för Java låter också utvecklare komma åt värdena för anpassade egenskaper. Ett exempel ges nedan som visar hur du kan komma åt och ändra alla dessa anpassade egenskaper för en presentation.

```java
import com.aspose.slides.*;

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

Detta exempel ändrar de anpassade egenskaperna för [PPTX](https://docs.fileformat.com/presentation/pptx/)‑presentationen. Följande figurer visar presentationens anpassade egenskaper före och efter ändring:

|**Anpassade egenskaper före ändring**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Anpassade egenskaper efter ändring**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Avancerade dokumentegenskaper**

{{% alert color="info" %}} 

Nya metoder [ReadDocumentProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), och [WriteBindedPresentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) har lagts till i [IPresentationInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentationInfo), logiken för egenskapsinställaren [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/sv/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) har ändrats.

{{% /alert %}} 

De två nya metoderna [ReadDocumentProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) och [UpdateDocumentProperties](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) har lagts till i gränssnittet [IPresentationInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IPresentationInfo). De ger snabb åtkomst till dokumentegenskaper och möjliggör att ändra och uppdatera egenskaper utan att ladda in hela presentationen.

Det vanliga scenariot där man laddar egenskaperna, ändrar ett värde och uppdaterar dokumentet kan implementeras på följande sätt:

```java
import com.aspose.slides.*;

// läs informationen om presentationen
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// hämta de aktuella egenskaperna
IDocumentProperties props = info.readDocumentProperties();

// ange de nya värdena för fälten Author och Title
props.setAuthor("New Author");
props.setTitle("New Title");

// uppdatera presentationen med nya värden
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Det finns ett annat sätt att använda egenskaperna från en viss presentation som en mall för att uppdatera egenskaper i andra presentationer:

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

En ny mall kan skapas från grunden och sedan användas för att uppdatera flera presentationer:

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

## **Ställ in korrekturläsningsspråk**

Aspose.Slides tillhandahåller egenskapen LanguageId (exponerad av klassen PortionFormat) för att låta dig ange korrekturläsningsspråket för ett PowerPoint‑dokument. Korrekturläsningsspråket är det språk för vilket stavning och grammatik i PowerPoint kontrolleras.

Denna Java‑kod visar hur du ställer in korrekturläsningsspråket för en PowerPoint:

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

    portionFormat.setLanguageId("zh-CN"); // sätt ID för ett korrekturläsningsspråk

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ställ in standardspråk**

Denna Java‑kod visar hur du ställer in standardspråket för en hel PowerPoint‑presentation:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Lägger till en ny rektangulär form med text
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Kontrollerar språket för den första portionen
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live‑exempel**

Prova den online‑appen [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) för att se hur man arbetar med dokumentegenskaper via Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## ***Vanliga frågor**

### Hur kan jag ta bort en inbyggd egenskap från en presentation?

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Däremot kan du antingen ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

### Vad händer om jag lägger till en anpassad egenskap som redan finns?

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

### Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?

Ja, du kan komma åt presentationsegenskaper utan att ladda hela presentationen genom att använda metoden `getPresentationInfo` från klassen [PresentationFactory](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationfactory/) . Använd sedan metoden `readDocumentProperties` som tillhandahålls av gränssnittet [IPresentationInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationinfo/) , för att läsa egenskaperna effektivt, spara minne och förbättra prestanda.