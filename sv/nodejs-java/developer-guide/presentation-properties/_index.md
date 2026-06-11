---
title: Hantera presentations egenskaper i JavaScript
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/nodejs-java/presentation-properties/
keywords:
- PowerPoint egenskaper
- presentations egenskaper
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för Node.js via Java och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint‑ och OpenDocument‑filer."
---
## **Introduktion**

Aspose.Slides stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med hjälp av Aspose.Slides API.

Aspose.Slides låter dig arbeta med presentationens dokumentegenskaper via klassen [DocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties/) . En instans av denna klass returneras av metoden [Presentation.getDocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . Följande exempel visar hur man läser, modifierar och hanterar dessa egenskaper.

{{% alert color="primary" %}} 
Observera att du inte kan ange värden för fälten **Application** och **Producer**, eftersom Aspose Ltd. och Aspose.Slides för Node.js via Java x.x.x kommer att visas i dessa fält.
{{% /alert %}} 

## **Hantera presentationsegenskaper**

Microsoft PowerPoint erbjuder en funktion för att lägga till vissa egenskaper i presentationsfilerna. Dessa dokumentegenskaper gör det möjligt att lagra användbar information tillsammans med dokumenten (presentationsfiler). Det finns två typer av dokumentegenskaper enligt följande

- Systemdefinierade (Inbyggda) egenskaper
- Användardefinierade (Anpassade) egenskaper

**Inbyggda** egenskaper innehåller allmän information om dokumentet såsom dokumenttitel, författarens namn, dokumentstatistik med mera. **Anpassade** egenskaper är de som definieras av användarna som **Namn/Värde**‑par, där både namn och värde anges av användaren. Med Aspose.Slides för Node.js via Java kan utvecklare komma åt och modifiera värdena för både inbyggda och anpassade egenskaper.

## **Dokumentegenskaper i PowerPoint**

Microsoft PowerPoint 2007 möjliggör hantering av dokumentegenskaperna för presentationsfilerna. Allt du behöver göra är att klicka på Office‑ikonen och sedan på menyalternativet **Prepare | Properties | Advanced Properties** i Microsoft PowerPoint 2007 som visas nedan:

|**Välja menyalternativet Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Efter att du har valt menyalternativet **Advanced Properties** visas en dialogruta som låter dig hantera dokumentegenskaperna för PowerPoint‑filen, som visas nedan i bilden:

|**Egenskapsdialog**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

I dialogrutan **Properties Dialog** ovan kan du se att det finns många flikar såsom **General**, **Summary**, **Statistics**, **Contents** och **Custom**. Alla dessa flikar möjliggör konfiguration av olika typer av information relaterad till PowerPoint‑filerna. Fliken **Custom** används för att hantera de anpassade egenskaperna för PowerPoint‑filerna.

### Arbeta med dokumentegenskaper med Aspose.Slides för Node.js via Java

Som vi tidigare har beskrivit stödjer Aspose.Slides för Node.js via Java två typer av dokumentegenskaper, nämligen **Inbyggda** och **Anpassade** egenskaper. Således kan utvecklare komma åt båda typerna av egenskaper via Aspose.Slides för Node.js via Java‑API. Aspose.Slides för Node.js via Java tillhandahåller klassen [DocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties) som representerar dokumentegenskaperna som är kopplade till en presentationsfil via egenskapen **Presentation.DocumentProperties**.

Utvecklare kan använda egenskapen **DocumentProperties** som exponeras av objektet [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation) för att komma åt dokumentegenskaperna för presentationsfilerna enligt nedan:

## **Åtkomst till inbyggda egenskaper**

Dessa egenskaper som exponeras av objektet [DocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties) inkluderar: **Creator** (Författare), **Description**, **Keywords**, **Created** (Skapandedatum), **Modified** (Ändringsdatum), **Printed** (Senaste utskriftsdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Delas mellan olika producenter?), **PresentationFormat**, **Subject** och **Title**.

```javascript
// Instansiera Presentation‑klassen som representerar presentationen
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Skapa en referens till IDocumentProperties‑objektet som är associerat med Presentation
    var dp = pres.getDocumentProperties();
    // Visa de inbyggda egenskaperna
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modifiera inbyggda egenskaper**

Att modifiera de inbyggda egenskaperna i presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till önskad egenskap så ändras egenskapsvärdet. I exemplet nedan har vi demonstrerat hur vi kan modifiera de inbyggda dokumentegenskaperna för presentationsfilen med Aspose.Slides för Node.js via Java.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Skapa en referens till IDocumentProperties‑objektet som är associerat med Presentation
    var dp = pres.getDocumentProperties();
    // Ställ in de inbyggda egenskaperna
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Save your presentation to a file
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Detta exempel modifierar de inbyggda egenskaperna för presentationen som kan visas som nedan:

|**Inbyggda dokumentegenskaper efter modifiering**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Lägg till anpassade dokumentegenskaper**

Aspose.Slides för Node.js via Java låter även utvecklare lägga till anpassade värden för presentationsdokumentets egenskaper. Ett exempel ges nedan som visar hur man anger de anpassade egenskaperna för en presentation.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Hämtar dokumentegenskaper
    var dProps = pres.getDocumentProperties();
    // Lägger till anpassade egenskaper
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Hämtar egenskapsnamn på specifikt index
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Tar bort vald egenskap
    dProps.removeCustomProperty(getPropertyName);
    // Sparar presentation
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Anpassade dokumentegenskaper tillagda**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Åtkomst och modifiering av anpassade egenskaper**

Aspose.Slides för Node.js via Java låter även utvecklare läsa värdena för anpassade egenskaper. Ett exempel ges nedan som visar hur du kan komma åt och modifiera alla dessa anpassade egenskaper för en presentation.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Skapa en referens till DocumentProperties-objektet som är associerat med Presentation
    var dp = pres.getDocumentProperties();
    // Åtkomst till och modifiera anpassade egenskaper
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Visa namn och värden för anpassade egenskaper
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Modifiera värden för anpassade egenskaper
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Spara din presentation till en fil
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Detta exempel modifierar de anpassade egenskaperna för [PPTX ](https://docs.fileformat.com/presentation/pptx/) presentationen. Följande figurer visar presentationens anpassade egenskaper före och efter modifiering:

|**Anpassade egenskaper före modifiering**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Anpassade egenskaper efter modifiering**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Avancerade dokumentegenskaper**

{{% alert color="primary" %}} 
Nya metoder [ReadDocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), och [WriteBindedPresentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) har lagts till i [PresentationInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PresentationInfo), logiken för egenskapsättaren [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) har ändrats.
{{% /alert %}} 

De två nya metoderna [ReadDocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) och [UpdateDocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) har lagts till i klassen [PresentationInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PresentationInfo). De ger snabb åtkomst till dokumentegenskaper och möjliggör att ändra och uppdatera egenskaper utan att ladda in hela presentationen.

Det typiska scenariot att läsa egenskaperna, ändra ett värde och uppdatera dokumentet kan implementeras på följande sätt:

```javascript
// läs informationen om presentationen
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
var props = info.readDocumentProperties();
props.setAuthor("New Author");
props.setTitle("New Title");
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Det finns ett annat sätt att använda egenskaperna i en specifik presentation som en mall för att uppdatera egenskaper i andra presentationer:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
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

```javascript
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

En ny mall kan skapas från grunden och sedan användas för att uppdatera flera presentationer:

```javascript
var template = new aspose.slides.DocumentProperties();
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

```javascript
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Ställ in korrekturläsningsspråk**

Aspose.Slides tillhandahåller egenskapen LanguageId (exponerad av klassen PortionFormat) för att låta dig ange korrekturläsningsspråket för ett PowerPoint‑dokument. Korrekturläsningsspråket är det språk för vilket stavning och grammatik i PowerPoint kontrolleras.

Den här JavaScript‑koden visar hur du ställer in korrekturläsningsspråket för en PowerPoint: xxx Varför saknas LanguageId i JavaScript‑klassen PortionFormat?

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// sätt ID för ett korrekturläsningsspråk
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ställ in standardspråk**

Den här JavaScript‑koden visar hur du anger standardspråket för en hel PowerPoint‑presentation:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Lägger till en ny rektangelform med text
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Kontrollerar språk för den första delen
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Live‑exempel**

Prova den online‑app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) för att se hur man arbetar med dokumentegenskaper via Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## ***FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Däremot kan du antingen ändra deras värden eller sätta dem till tomma, om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att helt ladda presentationen?**

Ja, du kan komma åt presentationsegenskaper utan att helt ladda presentationen genom att använda metoden `getPresentationInfo` från klassen [PresentationFactory](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationfactory/). Använd sedan metoden `readDocumentProperties` som tillhandahålls av klassen [PresentationInfo](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentationinfo/) för att läsa egenskaperna på ett effektivt sätt, vilket sparar minne och förbättrar prestanda.