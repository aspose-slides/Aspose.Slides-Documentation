---
title: Hantera presentationsegenskaper i JavaScript
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/nodejs-java/presentation-properties/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för Node.js via Java och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides för Node.js via Java stödjer **inbyggda** och **anpassade** dokumentegenskaper. Använd dessa egenskaper för att läsa och uppdatera presentationsmetadata, såsom författare, titel och användardefinierade värden.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via klassen [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties). En instans av denna klass returneras av [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Följande exempel visar hur man läser, ändrar och hanterar dessa egenskaper.

{{% alert color="info" title="Obs" %}}
Aspose.Slides hanterar applikations- och producentmetadata när presentationer sparas; dessa fält identifierar den programvara som skapade utdata.
{{% /alert %}}

## **Hantera presentationsegenskaper**

Dokumentegenskaper lagrar beskrivande information tillsammans med presentationsinnehållet. De delas in i två kategorier:

- **Inbyggda egenskaper** innehåller standardmetadata, såsom titel, författare och dokumentstatistik.
- **Anpassade egenskaper** lagrar användardefinierade namn/värde‑par.

Aspose.Slides för Node.js via Java ger åtkomst till båda kategorierna. I PowerPoint, välj **File → Info → Properties → Advanced Properties** för att inspektera dokumentmetadata. Dialogrutan grupperar information i flikar såsom **Summary**, **Statistics**, **Contents** och **Custom**. Använd fliken **Custom** för att hantera användardefinierade egenskaper.

## **Läsa offentliga egenskaper från en krypterad presentation**

Ett öppningslösenord skyddar normalt både presentationsinnehåll och dokumentegenskaper. När en presentation krypteras efter att ha anropat [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) med `false`, förblir dess dokumentegenskaper offentliga. En applikation kan då anropa [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) med `true` och läsa den offentliga metadata utan att ange öppningslösenordet.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) styr vad Aspose.Slides laddar; den avkrypterar inget. Om egenskaperna inkluderades i krypteringen misslyckas laddning utan lösenord. Om presentationen inte är krypterad ignoreras alternativet och hela presentationen laddas.

Exemplet kräver en krypterad presentation vars dokumentegenskaper lämnats offentliga. Det verifierar laddningsläget via [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) och läser sedan inbyggda egenskaper via [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

I detta läge laddas inte bildinnehållet. Bildspel, master‑bilder, layouter, former, media och andra presentationsobjekt är otillgängliga. Applikationer bör alltid kontrollera [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) innan de utför en operation som kräver hela presentationsobjektmodellen.

{{% alert color="warning" title="Varning" %}}
Offentlig metadata kan exponera författarnamn, titlar, ämnen, nyckelord, företaginformation, kommentarer och anpassade värden. Kryptera känsliga egenskaper tillsammans med presentationen. Lämna dem offentliga endast när indexering, klassificering, sökning eller dokumenthanteringssystem har ett specifikt krav på åtkomst utan lösenord.
{{% /alert %}}

## **Uppdatera egenskaper för en krypterad presentation**

För en krypterad PPTX‑fil är en presentation som laddas efter att ha anropat [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) med `true` avsedd för att läsa offentlig metadata. Aspose.Slides kan inte spara ändrade egenskaper från det metadata‑endast‑objektet eftersom de offentliga egenskaperna måste vara konsistenta med motsvarande data i den krypterade presentationen. Att uppdatera dem kräver därför rätt öppningslösenord och en fullständig laddning.

Exemplet kräver en krypterad PPTX‑presentation med offentliga dokumentegenskaper och ett känt öppningslösenord. Det öppnar hela presentationen med [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword), uppdaterar offentliga inbyggda egenskaper och sparar resultatet. Därefter används [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) för att verifiera att krypteringen bevaras och den offentliga metadata öppnas utan lösenord för att bekräfta de nya värdena:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Om en applikation inte har rätt att avkryptera eller ladda presentationsinnehållet måste offentliga egenskaper för en krypterad PPTX‑fil behandlas som skrivskyddade.

## **Åtkomst till inbyggda egenskaper**

Klassen [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) exponerar inbyggd metadata via getter‑metoder, inklusive [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) och [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). Detta exempel öppnar en befintlig presentation och skriver ut dess lagrade metadata till konsolen. Värdena beror på den inlästa presentationen; vissa fält kan vara tomma.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Ändra inbyggda egenskaper**

För att uppdatera inbyggd metadata, använd setter‑metoderna på objektet som returneras av [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Detta exempel öppnar en befintlig presentation, anropar [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) och [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager), och sparar sedan den uppdaterade presentationen med [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Den sparade PPTX‑filen innehåller den nya metadata.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hantera hyperlänkbasen**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) returnerar dokumentnivåns bas för relativa hyperlänkar. Använd [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) för att ändra eller rensa den. Detta är användbart när en presentation och dess länkade filer flyttas till en annan plats. Det är separerat från en enskild hyperlänks [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl): att ändra basen skriver inte om de lagrade län sadresserna eller ändrar absoluta destinationer.

Exemplet kräver en presentation som innehåller både en relativ länk, t.ex. `target.html`, och en absolut länk, t.ex. `https://example.org/absolute.html`. Det läser den befintliga basen, tilldelar en ny basadress, och sparar och öppnar sedan presentationen igen för att kontrollera värdet. Därefter rensas basen med en tom sträng och den tomma värdet verifieras i en separat sparad fil. Ersätt exempelbasen med platsen för dina länkade filer.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

De två verifieringsmeddelandena bör skriva ut `true`. Att rensa basen lämnar de enskilda hyperlänkadresserna intakta.

En relativ länk till `target.pptx` öppnade `old/target.pptx` när basen pekade på mappen `old`. Efter att ha ändrat basen till mappen `new`, sparat och öppnat presentationen igen, öppnade samma länk `new/target.pptx`. En absolut länk fortsatte att öppna samma fil. Testa dina relativa länkar i PowerPoint före och efter att du flyttat presentationen eller ändrat dess bas.

## **Lägg till anpassade presentationsegenskaper**

Anpassade egenskaper lagrar metadata som saknar motsvarande inbyggt fält. Metoden [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) låter dig tilldela ett värde via egenskapsnamn. Detta exempel skapar en presentation, lägger till två textvärden och ett heltalsversionsvärde, och sparar presentationen med [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Att tilldela ett värde till ett befintligt namn ersätter den egenskapens värde.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Åtkomst till och ändra anpassade egenskaper**

Detta exempel öppnar en presentation som innehåller anpassade egenskaper och använder [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) för att iterera över dem. [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) accepterar ett nollbaserat index och returnerar namnet som används av [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item). Exemplet skriver ut varje originalnamn och värde, ersätter varje värde med en numrerad sträng oavsett dess ursprungliga typ, och sparar ändringarna. Om inga anpassade egenskaper finns gör loopen inga förändringar.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Live‑exempel**

Prova den [**Visa & redigera PowerPoint‑metadata**](https://products.aspose.app/slides/metadata) online‑appen för att se hur du arbetar med dokumentegenskaper med Aspose.Slides‑API:n:

[![Visa & redigera PowerPoint‑metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Vanliga frågor**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att helt ladda presentationen?**

Ja. Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) och sedan [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) för att läsa lagrad dokumentmetadata utan att skapa en [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)‑instans. Se [Build a Lightweight Presentation Inventory](/slides/sv/nodejs-java/examine-presentation/) för ett komplett rapportexempel och format‑specifika begränsningar.

**Kan jag läsa offentliga egenskaper från en krypterad presentation utan dess öppningslösenord?**

Ja. Presentationen måste ha krypterats efter att ha anropat [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) med `false`, och den måste laddas efter att ha anropat [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) med `true`.

**Kan jag uppdatera en krypterad PPTX‑fil i endast‑dokumentegenskaper‑läge?**

Nej. Offentliga och krypterade egenskapsdata måste vara konsistenta, så för att uppdatera en krypterad PPTX‑fil krävs en fullständig laddning av presentationen med rätt öppningslösenord.