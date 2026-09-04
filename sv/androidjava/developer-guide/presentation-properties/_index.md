---
title: Hantera presentations-egenskaper på Android
linktitle: Presentations-egenskaper
type: docs
weight: 70
url: /sv/androidjava/presentation-properties/
keywords:
- PowerPoint-egenskaper
- presentations-egenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- ändra egenskaper
- dokumentmetadata
- redigera metadata
- språkkontroll
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Behärska presentations-egenskaper i Aspose.Slides för Android via Java och förenkla sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med hjälp av Aspose.Slides API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via gränssnittet [IDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties/) . En instans av detta gränssnitt returneras av [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--). Följande exempel visar hur man läser, ändrar och hanterar dessa egenskaper.

{{% alert color="info" title="Note" %}}
Observera att fälten **Application** och **AppVersion** inte kan ändras. Aspose.Slides skriver om dem vid varje sparning, så en sparad presentation alltid visar Aspose.Slides produktnamn och versionen av biblioteket som skapade den. Eventuellt värde som skickas till `setNameOfApplication` kastas bort när presentationen skrivs.
{{% /alert %}} 

## **Dokumentegenskaper i PowerPoint**

Microsoft PowerPoint 2007 möjliggör hantering av dokumentegenskaper för presentationsfilerna. Allt du behöver göra är att klicka på Office‑ikonen och sedan på menyobjektet **Prepare | Properties | Advanced Properties** i Microsoft PowerPoint 2007 som visas nedan:

|**Välja menyobjektet Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

När du har valt menyobjektet **Advanced Properties** visas en dialogruta som låter dig hantera dokumentegenskaperna för PowerPoint‑filen, som visas nedan i bilden:

|**Egenskapsdialog**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

I dialogrutan **Properties Dialog** ovan kan du se att det finns många flikar såsom **General**, **Summary**, **Statistics**, **Contents** och **Custom**. Alla dessa flikar möjliggör konfiguration av olika typer av information relaterad till PowerPoint‑filerna. Fliken **Custom** används för att hantera de anpassade egenskaperna för PowerPoint‑filerna.

Arbeta med dokumentegenskaper med Aspose.Slides för Android via Java

Som vi tidigare har beskrivit stödjer Aspose.Slides för Android via Java två typer av dokumentegenskaper, nämligen **Built-in** och **Custom**. Så kan utvecklare komma åt båda typerna av egenskaper med Aspose.Slides för Android via Java API. Aspose.Slides för Android via Java tillhandahåller klassen [IDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties) som representerar dokumentegenskaperna som är kopplade till en presentationsfil via egenskapen **Presentation.DocumentProperties**.

Utvecklare kan använda egenskapen **IDocumentProperties** som exponeras av objektet [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation) för att komma åt dokumentegenskaperna för presentationsfilerna, enligt beskrivningen nedan:

## **Läs offentliga egenskaper från en krypterad presentation**

Ett öppningslösenord skyddar normalt både presentationsinnehåll och dokumentegenskaper. När en presentation krypteras genom att skicka `false` till [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), förblir dess dokumentegenskaper offentliga. En applikation kan då skicka `true` till [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) och läsa den offentliga metadata utan att ange öppningslösenordet.

Alternativet för endast dokumentegenskaper styr vad Aspose.Slides laddar; det dekrypterar ingenting. Om egenskaperna var inkluderade i krypteringen misslyckas laddning utan lösenordet. Om presentationen inte är krypterad ignoreras alternativet och hela presentationen laddas.

Följande exempel verifierar laddningsläget via [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) och läser sedan inbyggda egenskaper via [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

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

I detta läge laddas inte bildinnehållet. Bilder, masterbilder, layouter, former, media och andra presentationsobjekt är otillgängliga. Applikationer bör alltid kontrollera [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) innan de utför en operation som kräver hela presentationsobjektmodellen.

{{% alert color="warning" title="Warning" %}}
Offentlig metadata kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden. Kryptera känsliga egenskaper tillsammans med presentationen. Lämna dem offentliga endast när indexering, klassificering, sökning eller dokumenthanteringssystem har ett specifikt krav på att få åtkomst utan lösenord.
{{% /alert %}}

## **Uppdatera egenskaper för en krypterad presentation**

För en krypterad PPTX‑fil är en presentation som laddas i enbart dokumentegenskaps‑läge avsedd för att läsa offentlig metadata. Aspose.Slides kan inte spara förändrade egenskaper från det metadata‑endast‑objektet eftersom de offentliga egenskaperna måste vara konsekventa med motsvarande data i den krypterade presentationen. En uppdatering kräver därför rätt öppningslösenord och en fullständig laddning.

Följande exempel öppnar presentationen med [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), uppdaterar offentliga inbyggda egenskaper och sparar resultatet. Det använder sedan [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/#isEncrypted--) för att verifiera att krypteringen bevaras och öppnar den offentliga metadata igen utan lösenord för att verifiera de nya värdena:

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

Om en applikation inte får dekryptera eller ladda presentationsinnehållet måste den behandla offentliga egenskaper i en krypterad PPTX‑fil som skrivskyddade.

## **Komma åt inbyggda egenskaper**

Dessa egenskaper som exponeras av objektet [IDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties) omfattar: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** och **Title**.

```java
import com.aspose.slides.*;

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

Att ändra de inbyggda egenskaperna för presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till önskad egenskap så ändras egenskapens värde. I exemplet nedan har vi demonstrerat hur man kan ändra de inbyggda dokumentegenskaperna för presentationsfilen med Aspose.Slides för Android via Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Skapa en referens till IDocumentProperties-objektet som är associerat med Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Ställ in de inbyggda egenskaperna
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

Detta exempel ändrar de inbyggda egenskaperna för presentationen som kan visas nedan:

|**Inbyggda dokumentegenskaper efter ändring**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Lägg till anpassade dokumentegenskaper**

Aspose.Slides för Android via Java låter också utvecklare lägga till anpassade värden för presentationsdokumentegenskaper. Exemplet nedan lägger till tre anpassade egenskaper, söker sedan upp namnet lagrat på index 2 och tar bort den egenskapen, så den sparade presentationen behåller två av dem. Anpassade egenskaper indexeras i alfabetisk ordning, inte i den ordning de lades till.

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

## **Komma åt och ändra anpassade egenskaper**

Aspose.Slides för Android via Java låter också utvecklare komma åt värdena för anpassade egenskaper. Ett exempel ges nedan som visar hur du kan komma åt och ändra alla dessa anpassade egenskaper för en presentation.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Skapa en referens till DocumentProperties-objektet som är associerat med Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Åtkomst och ändring av anpassade egenskaper
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

{{% alert color="info" title="Note" %}}
Nya metoderna [ReadDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), och [WriteBindedPresentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) har lagts till i [IPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo), logiken i egenskapssättaren för [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) har ändrats.
{{% /alert %}} 

De två nya metoderna [ReadDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) och [UpdateDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) har lagts till i [IPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IPresentationInfo)‑gränssnittet. De ger snabb åtkomst till dokumentegenskaper och möjliggör att ändra och uppdatera egenskaper utan att ladda en hel presentation.

Det typiska scenariot att ladda egenskaperna, ändra ett värde och uppdatera dokumentet kan implementeras på följande sätt:

```java
import com.aspose.slides.*;

// Läs informationen om presentationen
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// Hämta de aktuella egenskaperna
IDocumentProperties props = info.readDocumentProperties();

// Sätt de nya värdena för författare och titel
props.setAuthor("New Author");
props.setTitle("New Title");

// Uppdatera presentationen med nya värden
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Det finns ett annat sätt att använda egenskaper från en viss presentation som mall för att uppdatera egenskaper i andra presentationer:

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

## **Ställ in språkgranskning**

Aspose.Slides tillhandahåller egenskapen LanguageId (exponerad av klassen PortionFormat) för att låta dig ställa in språkgranskning för ett PowerPoint‑dokument. Språkgranskning är det språk som stavning och grammatik i PowerPoint kontrolleras för.

Den här Java‑koden visar hur du ställer in språkgranskning för en PowerPoint:

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

    portionFormat.setLanguageId("zh-CN"); // ange ID för ett språkgranskningsspråk

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ställ in standardspråk**

Den här Java‑koden visar hur du ställer in standardspråket för en hel PowerPoint‑presentation:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Lägger till en ny rektangulär form med text
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Kontrollerar första portionsspråket
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Live‑exempel**

Prova [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) online‑appen för att se hur du arbetar med dokumentegenskaper via Aspose.Slides‑API:

[![Visa och redigera PowerPoint‑metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## **FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Däremot kan du antingen ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att helt ladda presentationen?**

Ja. Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) och sedan [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) för att läsa lagrad dokumentmetadata utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)‑instans. Se [Build a Lightweight Presentation Inventory](/slides/sv/androidjava/examine-presentation/) för ett komplett rapportexempel och format‑specifika begränsningar.

**Kan jag läsa offentliga egenskaper i en krypterad presentation utan dess öppningslösenord?**

Ja. Kryptering av dokumentegenskaper måste ha inaktiverats innan presentationen krypterades, och presentationen måste laddas i endast‑dokumentegenskaper‑läge.

**Kan jag uppdatera en krypterad PPTX‑fil i endast‑dokumentegenskaper‑läge?**

Nej. Offentliga och krypterade egenskapsdata måste vara konsekventa, så en uppdatering av en krypterad PPTX‑fil kräver att hela presentationen laddas med rätt öppningslösenord.