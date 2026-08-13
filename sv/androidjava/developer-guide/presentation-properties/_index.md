---
title: Hantera presentationsegenskaper på Android
linktitle: Presentationssegenskaper
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

Aspose.Slides låter dig arbeta med dokumentegenskaper för presentationer via gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/). En instans av detta gränssnitt returneras av metoden [Presentation.getDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) . Följande exempel visar hur du läser, modifierar och hanterar dessa egenskaper.

{{% alert color="info" %}} 
Observera att fälten **Application** och **AppVersion** inte kan ändras. Aspose.Slides skriver om dem vid varje sparning, så en sparad presentation alltid visar Aspose.Slides produktnamn och versionen av biblioteket som skapade den. Eventuellt värde som skickas till `setNameOfApplication` ignoreras när presentationen skrivs.
{{% /alert %}} 

## **Dokumentegenskaper i PowerPoint**

Microsoft PowerPoint 2007 möjliggör hantering av dokumentegenskaper för presentationsfiler. Allt du behöver göra är att klicka på Office‑ikonen och därefter **Prepare | Properties | Advanced Properties** i Microsoft PowerPoint 2007 som visas nedan:

|**Välja menyalternativet Avancerade egenskaper**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
När du har valt menyalternativet **Advanced Properties** visas en dialog som låter dig hantera dokumentegenskaperna för PowerPoint‑filen, som visas i figuren nedan:

|**Egendomsdialog**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
I ovanstående **Egendomsdialog** kan du se många flikar som **General**, **Summary**, **Statistics**, **Contents** och **Custom**. Alla dessa flikar möjliggör konfiguration av olika typer av information relaterad till PowerPoint‑filer. Fliken **Custom** används för att hantera anpassade egenskaper för PowerPoint‑filer.



Arbeta med dokumentegenskaper med Aspose.Slides för Android via Java

Som vi beskrev tidigare stödjer Aspose.Slides för Android via Java två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Därför kan utvecklare komma åt båda typerna med Aspose.Slides för Android via Java API. Aspose.Slides för Android via Java tillhandahåller klassen [IDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties) som representerar dokumentegenskaperna som är associerade med en presentationsfil via egenskapen **Presentation.DocumentProperties**.

Utvecklare kan använda egenskapen **IDocumentProperties** som exponeras av objektet [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) för att komma åt dokumentegenskaperna för presentationsfilerna enligt nedan:

## **Åtkomst till inbyggda egenskaper**

De egenskaper som exponeras av objektet [IDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties) inkluderar: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** och **Title**.

```java
import com.aspose.slides.*;

// Instansiera Presentation-klassen som representerar presentationen
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Skapa en referens till IDocumentProperties-objektet som är associerat med presentationen
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

Att modifiera de inbyggda egenskaperna för presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till någon önskad egenskap så uppdateras egenskapsvärdet. I exemplet nedan demonstreras hur vi kan modifiera de inbyggda dokumentegenskaperna för presentationsfilen med Aspose.Slides för Android via Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Skapa en referens till IDocumentProperties-objektet som är associerat med presentationen
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Sätt de inbyggda egenskaperna
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Spara presentationen till en fil
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Detta exempel modifierar de inbyggda egenskaperna för presentationen som visas nedan:

|**Inbyggda dokumentegenskaper efter modifiering**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Lägg till anpassade dokumentegenskaper**

Aspose.Slides för Android via Java låter även utvecklare lägga till anpassade värden för presentationsdokumentegenskaper. Exemplet nedan lägger till tre anpassade egenskaper, söker sedan upp namnet som lagras på index 2 och tar bort den egenskapen, så den sparade presentationen behåller två av dem. Anpassade egenskaper indexeras i alfabetisk ordning, inte i den ordning de lades till.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Hämta dokumentegenskaper
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Lägga till anpassade egenskaper
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Hämta egenskapsnamn på ett specifikt index
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Ta bort vald egenskap
    dProps.removeCustomProperty(getPropertyName);
    
    // Spara presentation
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Anpassade dokumentegenskaper tillagda**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Åtkomst till och modifiera anpassade egenskaper**

Aspose.Slides för Android via Java låter även utvecklare åtkomst till värdena för anpassade egenskaper. Ett exempel ges nedan som visar hur du kan komma åt och modifiera alla dessa anpassade egenskaper för en presentation.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Skapa en referens till DocumentProperties-objektet som är associerat med presentationen
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Åtkomst till och modifiera anpassade egenskaper
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Visa namn och värden för anpassade egenskaper
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Modifiera värden för anpassade egenskaper
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Spara din presentation till en fil
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Detta exempel modifierar de anpassade egenskaperna för [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentationen. Följande figurer visar presentationens anpassade egenskaper före och efter modifiering:

|**Anpassade egenskaper före modifiering**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Anpassade egenskaper efter modifiering**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Avancerade dokumentegenskaper**

{{% alert color="info" %}} 
Nya metoder [ReadDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), och [WriteBindedPresentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) har lagts till i [IPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo), logiken för egenskapsättaren [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) har ändrats.
{{% /alert %}} 

De två nya metoderna [ReadDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) och [UpdateDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) har lagts till i gränssnittet [IPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo). De ger snabb åtkomst till dokumentegenskaper och möjliggör ändring och uppdatering av egenskaper utan att ladda en hel presentation.

Det typiska scenariot ladda egenskaperna, ändra ett värde och uppdatera dokumentet kan implementeras på följande sätt:

```java
import com.aspose.slides.*;

// läs informationen om presentationen
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

Det finns ett annat sätt att använda egenskaperna för en viss presentation som mall för att uppdatera egenskaper i andra presentationer:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Ställ in korrekturspråk**

Aspose.Slides tillhandahåller egenskapen LanguageId (exponerad av klassen PortionFormat) för att låta dig ange korrekturspråk för ett PowerPoint‑dokument. Korrekturspråket är det språk för vilket stavning och grammatik i PowerPoint kontrolleras.

Denna Java‑kod visar hur du anger korrekturspråk för ett PowerPoint‑dokument:

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

    portionFormat.setLanguageId("zh-CN"); // ange ID för ett korrekturspråk

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ställ in standardspråk**

Denna Java‑kod visar hur du anger standardspråk för en hel PowerPoint‑presentation:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Lägger till en ny rektangelform med text
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Kontrollerar språket för den första delen
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live‑exempel**

Prova [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) online‑app för att se hur du arbetar med dokumentegenskaper via Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## ***FAQ**

### Hur kan jag ta bort en inbyggd egenskap från en presentation?

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

### Vad händer om jag lägger till en anpassad egenskap som redan finns?

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, då Aspose.Slides automatiskt uppdaterar egenskapens värde.

### Kan jag komma åt presentationsegenskaper utan att ladda in hela presentationen?

Ja, du kan komma åt presentationsegenskaper utan att ladda in hela presentationen genom att använda metoden `getPresentationInfo` från klassen [PresentationFactory](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentationfactory/). Använd sedan metoden `readDocumentProperties` som tillhandahålls av gränssnittet [IPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/) för att läsa egenskaperna effektivt, vilket sparar minne och förbättrar prestanda.