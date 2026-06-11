---
title: Säkra presentationer med lösenord i JavaScript
linktitle: Lösenordsskydd
type: docs
weight: 20
url: /sv/nodejs-java/password-protected-presentation/
keywords:
- lås PowerPoint
- lås presentation
- lås upp PowerPoint
- lås upp presentation
- skydda PowerPoint
- skydda presentation
- ange lösenord
- lägg till lösenord
- kryptera PowerPoint
- kryptera presentation
- dekryptera PowerPoint
- dekryptera presentation
- skrivskydd
- PowerPoint-säkerhet
- presentationssäkerhet
- ta bort lösenord
- ta bort skydd
- ta bort kryptering
- inaktivera lösenord
- inaktivera skydd
- ta bort skrivskydd
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lås och lås upp lösenordsskyddade PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js via Java utan ansträngning. Skydda dina presentationer."
---
## **Introduktion**

När du lösenordsskyddar en presentation innebär det att du anger ett lösenord som inför vissa begränsningar på presentationen. För att ta bort begränsningarna måste lösenordet anges. En lösenordsskyddad presentation anses vara en låst presentation.

Vanligtvis kan du ange ett lösenord för att påtvinga dessa begränsningar på en presentation:

- **Modifiering**

  Om du vill att endast vissa användare ska kunna modifiera din presentation kan du ange en modifieringsbegränsning. Begränsningen förhindrar att personer modifierar, ändrar eller kopierar innehåll i din presentation (såvida de inte anger lösenordet).

  I detta fall kan en användare dock, utan lösenord, komma åt ditt dokument och öppna det. I detta skrivskyddade läge kan användaren visa innehållet eller element – hyperlänkar, animationer, effekter och annat – i din presentation, men de kan inte kopiera objekt eller spara presentationen.

- **Öppning**

  Om du vill att endast vissa användare ska kunna öppna din presentation kan du ange en öppningsbegränsning. Begränsningen förhindrar att personer ens ser innehållet i din presentation (såvida de inte anger lösenordet).

  Tekniskt sett förhindrar öppningsbegränsningen även att användare modifierar dina presentationer: När personer inte kan öppna en presentation kan de inte göra ändringar i den.  
  
  **Obs!** När du lösenordsskyddar en presentation för att förhindra öppning blir presentationsfilen krypterad.

## **Hur du lösenordsskyddar en presentation online**

1. Gå till vår [**Aspose.Slides Lock**](https://products.aspose.app/slides/sv/lock)‑sida. 

   ![todo:image_alt_text](slides-lock.png)

2. Klicka **Drop or upload your files**.

3. Välj den fil du vill lösenordsskydda på din dator. 

4. Ange ditt föredragna lösenord för redigeringsskydd; ange ditt föredragna lösenord för visningsskydd. 

5. Om du vill att användare ska se din presentation som den slutgiltiga kopian markerar du kryssrutan **Mark as final**.

6. Klicka **PROTECT NOW.** 

7. Klicka **DOWNLOAD NOW.**

## **Lösenordsskydd för presentationer i Aspose.Slides**
**Understödda format**

Aspose.Slides stödjer lösenordsskydd, kryptering och liknande operationer för presentationer i följande format: 

- PPTX och PPT – Microsoft PowerPoint‑presentation 
- ODP – OpenDocument‑presentation 
- OTP – OpenDocument‑presentationsmall 

**Understödda operationer**

Aspose.Slides låter dig använda lösenordsskydd på presentationer för att förhindra modifieringar på dessa sätt:

- Kryptera en presentation
- Ställa in skrivskydd för en presentation

**Övriga operationer**

Aspose.Slides låter dig utföra andra uppgifter som involverar lösenordsskydd och kryptering på dessa sätt:

- Dekryptera en presentation; öppna en krypterad presentation
- Ta bort kryptering; inaktivera lösenordsskydd
- Ta bort skrivskydd från en presentation
- Hämta egenskaperna för en krypterad presentation
- Kontrollera om en presentation är krypterad
- Kontrollera om en presentation är lösenordsskyddad.

## **Kryptera en presentation**

Du kan kryptera en presentation genom att ange ett lösenord. För att modifiera den låsta presentationen måste en användare ange lösenordet. 

För att kryptera eller lösenordsskydda en presentation använder du encrypt‑metoden (från [ProtectionManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ProtectionManager)) för att ange ett lösenord för presentationen. Du skickar lösenordet till encrypt‑metoden och använder save‑metoden för att spara den nu krypterade presentationen.

Detta exempel visar hur du krypterar en presentation:

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

**Obs!** Skrivskyddsprocessen krypterar inte presentationen. Därför kan användare – om de så vill – modifiera presentationen, men för att spara ändringarna måste de skapa en presentation med ett annat namn. 

För att ange skrivskydd använder du metoden [setWriteProtection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-). Detta exempel visar hur du ställer in skrivskydd för en presentation:

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

Aspose.Slides låter dig läsa in en krypterad fil genom att ange dess lösenord. För att dekryptera en presentation måste du anropa [removeEncryption](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--)‑metoden utan parametrar. Du måste sedan ange rätt lösenord för att läsa in presentationen.

Detta exempel visar hur du dekrypterar en presentation: 

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

Du kan ta bort krypteringen eller lösenordsskyddet på en presentation. På så sätt kan användare komma åt eller modifiera presentationen utan begränsningar. 

För att ta bort kryptering eller lösenordsskydd måste du anropa [removeEncryption](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--)‑metoden. Detta exempel visar hur du tar bort kryptering från en presentation:

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

Du kan använda Aspose.Slides för att ta bort skrivskyddet som använts på en presentationsfil. På så sätt kan användare modifiera fritt – och de får inga varningar när de utför sådana åtgärder.

Du kan ta bort skrivskyddet från en presentation genom att använda metoden [removeWriteProtection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--)​. Detta exempel visar hur du tar bort skrivskyddet från en presentation:

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

## **Hämta egenskaperna för en krypterad presentation**

Vanligtvis har användare svårt att hämta dokumentegenskaperna för en krypterad eller lösenordsskyddad presentation. Aspose.Slides erbjuder dock en mekanism som gör det möjligt att lösenordsskydda en presentation samtidigt som användarna kan komma åt dess egenskaper.

**Obs!** När Aspose.Slides krypterar en presentation blir dokumentegenskaperna också lösenordsskyddade som standard. Men om du vill göra presentationens egenskaper åtkomliga (även efter att presentationen har krypterats) låter Aspose.Slides dig göra just det. 

Om du vill att användare ska behålla möjligheten att komma åt egenskaperna för en presentation du krypterat kan du sätta egenskapen [encryptDocumentProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--) till `true`. Detta exempel visar hur du krypterar en presentation samtidigt som du ger användarna möjlighet att komma åt dokumentegenskaperna:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Kontrollera om en presentation är lösenordsskyddad innan den laddas**

Innan du laddar en presentation kan du vilja kontrollera och bekräfta att presentationen inte är skyddad med ett lösenord. På så sätt undviker du fel och liknande problem som uppstår när en lösenordsskyddad presentation laddas utan sitt lösenord.

Denna JavaScript‑kod visar hur du undersöker en presentation för att se om den är lösenordsskyddad (utan att själva presentationen laddas):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Kontrollera om en presentation är krypterad**

Aspose.Slides låter dig kontrollera om en presentation är krypterad. För att utföra detta kan du använda egenskapen [isEncrypted](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) som returnerar `true` om presentationen är krypterad eller `false` om den inte är krypterad.

Detta exempel visar hur du kontrollerar om en presentation är krypterad:

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

Aspose.Slides låter dig kontrollera om en presentation är skrivskyddad. För att utföra detta kan du använda egenskapen [isWriteProtected](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) som returnerar `true` om presentationen är krypterad eller `false` om den inte är krypterad.

Detta exempel visar hur du kontrollerar om en presentation är skrivskyddad:

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

Du kanske vill kontrollera och bekräfta att ett specifikt lösenord har använts för att skydda ett presentationsdokument. Aspose.Slides tillhandahåller medel för att validera ett lösenord. 

Detta exempel visar hur du validerar ett lösenord:

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

Det returnerar `true` om presentationen har krypterats med det angivna lösenordet. Annars returnerar det `false`. 

{{% alert color="primary" title="Se även" %}} 
- [Digital Signatur i PowerPoint](/slides/sv/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Vilka krypteringsmetoder stöds av Aspose.Slides?**

Aspose.Slides stödjer moderna krypteringsmetoder, inklusive AES‑baserade algoritmer, vilket säkerställer en hög nivå av datasäkerhet för dina presentationer.

**Vad händer om ett felaktigt lösenord anges när man försöker öppna en presentation?**

Ett undantag kastas om ett felaktigt lösenord används, vilket varnar dig om att åtkomst till presentationen nekas. Detta hjälper till att förhindra obehörig åtkomst och skyddar presentationsinnehållet.

**Finns det några prestandapåverkan när man arbetar med lösenordsskyddade presentationer?**

Krypterings‑ och dekrypteringsprocessen kan medföra en liten overhead under öppnings‑ och sparningsoperationer. I de flesta fall är prestandapåverkan minimal och påverkar inte avsevärt den totala bearbetningstiden för dina presentationsuppgifter.