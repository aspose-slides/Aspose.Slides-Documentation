---
title: Säkra presentationer med lösenord i JavaScript
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/nodejs-java/password-protected-presentation/
keywords:
- Låsa PowerPoint
- Låsa presentation
- Låsa upp PowerPoint
- Låsa upp presentation
- Skydda PowerPoint
- Skydda presentation
- Ange lösenord
- Lägg till lösenord
- Kryptera PowerPoint
- Kryptera presentation
- Dekryptera PowerPoint
- Dekryptera presentation
- Skrivskydd
- PowerPoint-säkerhet
- Presentationssäkerhet
- Ta bort lösenord
- Ta bort skydd
- Ta bort kryptering
- Inaktivera lösenord
- Inaktivera skydd
- Ta bort skrivskydd
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Låser och låser upp lösenordsskyddade PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js via Java utan ansträngning. Skydda dina presentationer."
---
## **Introduktion**

När du lösenordsskyddar en presentation betyder det att du ställer in ett lösenord som verkställar vissa begränsningar på presentationen. För att ta bort begränsningarna måste lösenordet anges. En lösenordsskyddad presentation anses vara en låst presentation.

Vanligtvis kan du ange ett lösenord för att verkställa dessa begränsningar på en presentation:

- **Modifiering**

  Om du vill att endast vissa användare ska kunna ändra din presentation kan du ange en ändringsbegränsning. Begränsningen här förhindrar att personer modifierar, ändrar eller kopierar saker i din presentation (såvida de inte anger lösenordet). 

  Dock kan en användare i detta fall, även utan lösenordet, komma åt ditt dokument och öppna det. I detta skrivskyddade läge kan användaren se innehållet eller saker – hyperlänkar, animationer, effekter och andra – i din presentation, men de kan inte kopiera objekt eller spara presentationen. 

- **Öppning**

  Om du vill att endast vissa användare ska kunna öppna din presentation kan du ange en öppningsbegränsning. Begränsningen här förhindrar att personer ens visar innehållet i din presentation (såvida de inte anger lösenordet).

  Tekniskt sett förhindrar öppningsbegränsningen också att användare modifierar dina presentationer: När personer inte kan öppna en presentation kan de inte göra ändringar i den. 

  **Obs** att när du lösenordsskyddar en presentation för att förhindra öppning blir presentationsfilen krypterad.

## **Hur du lösenordsskyddar en presentation online**

1. Gå till vår [**Aspose.Slides Lås**](https://products.aspose.app/slides/sv/lock) sida. 

   ![todo:image_alt_text](slides-lock.png)

2. Klicka på **Släpp eller ladda upp dina filer**.

3. Välj den fil du vill lösenordsskydda på din dator. 

4. Ange ditt föredragna lösenord för redigeringsskydd; Ange ditt föredragna lösenord för visningsskydd. 

5. Om du vill att användare ska se din presentation som den slutgiltiga kopian, markera kryssrutan **Markera som slutgiltig**.

6. Klicka på **SKYDDA NU.** 

7. Klicka på **LADDA NER NU.**

## **Lösenordsskydd för presentationer i Aspose.Slides**
**Stödda format**

Aspose.Slides stödjer lösenordsskydd, kryptering och liknande operationer för presentationer i följande format: 

- PPTX och PPT - Microsoft PowerPoint-presentation 
- ODP - OpenDocument-presentation 
- OTP -  OpenDocument-presentationmall 

**Stödda operationer**

Aspose.Slides låter dig använda lösenordsskydd på presentationer för att förhindra ändringar på följande sätt:

- Kryptera en presentation
- Ställa in skrivskydd för en presentation

**Övriga operationer**

Aspose.Slides låter dig utföra andra uppgifter som involverar lösenordsskydd och kryptering på följande sätt:

- Dekryptera en presentation; öppna en krypterad presentation
- Ta bort kryptering; inaktivera lösenordsskydd
- Ta bort skrivskydd från en presentation
- Hämta egenskaperna för en krypterad presentation
- Kontrollera om en presentation är krypterad
- Kontrollera om en presentation är lösenordsskyddad.

## **Kryptera en presentation**

Du kan kryptera en presentation genom att ange ett lösenord. För att ändra den låsta presentationen måste en användare ange lösenordet.

För att kryptera eller lösenordsskydda en presentation måste du använda encrypt‑metoden (från [ProtectionManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ProtectionManager)) för att ange ett lösenord för presentationen. Du skickar lösenordet till encrypt‑metoden och använder save‑metoden för att spara den nu krypterade presentationen.

Den här exempel‑koden visar hur du krypterar en presentation:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Ställa in skrivskydd för en presentation**

Du kan lägga till en markering som säger ”Do not modify” i en presentation. På så sätt kan du tala om för användarna att du inte vill att de ska göra ändringar i presentationen.  

**Obs** att skrivskyddsprocessen inte krypterar presentationen. Därför kan användare—om de faktiskt vill—modifiera presentationen, men för att spara ändringarna måste de skapa en presentation med ett annat namn. 

För att ställa in ett skrivskydd måste du använda metoden [setWriteProtection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-) . Den här exempel‑koden visar hur du sätter ett skrivskydd på en presentation:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Dekryptera en presentation; öppna en krypterad presentation**

Aspose.Slides låter dig läsa in en krypterad fil genom att ange dess lösenord. För att dekryptera en presentation måste du anropa metoden [removeEncryption](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) utan parametrar. Du måste sedan ange rätt lösenord för att läsa in presentationen.

Den här exempel‑koden visar hur du dekrypterar en presentation: 

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // arbeta med dekrypterad presentation
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Ta bort kryptering; inaktivera lösenordsskydd**

Du kan ta bort krypteringen eller lösenordsskyddet på en presentation. På så sätt kan användare få åtkomst till eller ändra presentationen utan begränsningar. 

För att ta bort kryptering eller lösenordsskydd måste du anropa metoden [removeEncryption](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) . Den här exempel‑koden visar hur du tar bort kryptering från en presentation:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Ta bort skrivskydd från en presentation**

Du kan använda Aspose.Slides för att ta bort skrivskyddet som använts på en presentationsfil. På så sätt kan användare modifiera som de vill—utan några varningar när de utför sådana uppgifter.

Du kan ta bort skrivskyddet från en presentation genom att använda metoden [removeWriteProtection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) . Den här exempel‑koden visar hur du tar bort skrivskyddet från en presentation:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Hämta egenskaper för en krypterad presentation**

Vanligtvis har användare svårt att hämta dokumentegenskaperna för en krypterad eller lösenordsskyddad presentation. Aspose.Slides erbjuder dock en mekanism som låter dig lösenordsskydda en presentation samtidigt som användarna fortfarande kan komma åt dess egenskaper.

**Obs:** Som standard, när Aspose.Slides krypterar en presentation, är presentationens dokumentegenskaper också lösenordsskyddade. Om du behöver göra dokumentegenskaperna tillgängliga även efter kryptering, möjliggör Aspose.Slides just det.

Om du vill att användare ska behålla möjligheten att komma åt egenskaperna för en krypterad presentation, skicka `false` till `setEncryptDocumentProperties` på [ProtectionManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/protectionmanager/). Den här exempel‑koden visar hur du krypterar en presentation samtidigt som du ger användarna åtkomst till dess dokumentegenskaper:

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Läs endast dokumentegenskaper från en krypterad presentation**

För att inspektera metadata för en krypterad presentation utan att läsa in dess bilder eller annat innehåll, skapa ett [LoadOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/)‑objekt och skicka `true` till `setOnlyLoadDocumentProperties`. I detta läge ignorerar Aspose.Slides lösenordet och läser endast de dokumentegenskaper som är offentligt tillgängliga.

Följande kodexempel läser inbyggda och anpassade dokumentegenskaper via `getDocumentProperties` på [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/):

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // Läs inbyggda dokumentegenskaper.
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // Läs anpassade dokumentegenskaper.
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Detta arbetsflöde fungerar endast när dokumentegenskaperna lämnades okrypterade (publika) när presentationen krypterades. Om dokumentegenskaperna är krypterade orsakar att skicka `true` till `LoadOptions.setOnlyLoadDocumentProperties` ett undantag eftersom lösenordet ignoreras i detta läge. För att få åtkomst till krypterade dokumentegenskaper eller läsa in hela presentationen, inklusive dess bilder och annat innehåll, ange rätt lösenord via `LoadOptions.setPassword` på [LoadOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/).

## **Kontrollera om en presentation är lösenordsskyddad innan den laddas**

Innan du laddar en presentation kan du vilja kontrollera och bekräfta att presentationen inte är skyddad med ett lösenord. På så sätt undviker du fel och liknande problem som uppstår när en lösenordsskyddad presentation laddas utan sitt lösenord.

Denna JavaScript‑kod visar hur du undersöker en presentation för att se om den är lösenordsskyddad (utan att läsa in själva presentationen):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Kontrollera om en presentation är krypterad**

Aspose.Slides låter dig kontrollera om en presentation är krypterad. För att utföra detta kan du använda egenskapen [isEncrypted](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) , som returnerar `true` om presentationen är krypterad eller `false` om den inte är krypterad.

Den här exempel‑koden visar hur du kontrollerar om en presentation är krypterad:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Kontrollera om en presentation är skrivskyddad**

Aspose.Slides låter dig kontrollera om en presentation är skrivskyddad. För att utföra detta kan du använda egenskapen [isWriteProtected](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) , som returnerar `true` om presentationen är skrivskyddad eller `false` om den inte är skrivskyddad.

Den här exempel‑koden visar hur du kontrollerar om en presentation är skrivskyddad:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Validera eller bekräfta att ett specifikt lösenord har använts för att skydda en presentation**

Du kanske vill kontrollera och bekräfta att ett specifikt lösenord har använts för att skydda ett presentationsdokument. Aspose.Slides erbjuder möjlighet att validera ett lösenord. 

Den här exempel‑koden visar hur du validerar ett lösenord:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // kontrollera om "pass" matchar
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Den returnerar `true` om presentationen har krypterats med det angivna lösenordet. Annars returnerar den `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/sv/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Vilka krypteringsmetoder stöds av Aspose.Slides?**

Aspose.Slides stödjer moderna krypteringsmetoder, inklusive AES‑baserade algoritmer, vilket säkerställer en hög nivå av dataskydd för dina presentationer.

**Vad händer om ett felaktigt lösenord anges när du försöker öppna en presentation?**

Ett undantag kastas om ett felaktigt lösenord används, vilket varnar dig att åtkomst till presentationen nekas. Detta hjälper till att förhindra obehörig åtkomst och skyddar presentationsinnehållet.

**Finns det några prestandapåverkan när du arbetar med lösenordsskyddade presentationer?**

Krypterings‑ och dekrypteringsprocessen kan medföra en liten extra belastning vid öppnings‑ och sparningsoperationer. I de flesta fall är denna prestandapåverkan minimal och påverkar inte nämnvärt den totala bearbetningstiden för dina presentationsuppgifter.