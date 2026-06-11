---
title: Spara presentationer i skrivskyddat läge med JavaScript
linktitle: Skrivskyddad presentation
type: docs
weight: 30
url: /sv/nodejs-java/read-only-presentation/
keywords:
- skrivskyddad
- skydda presentation
- förhindra redigering
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Läs in och spara PowerPoint-filer i skrivskyddat läge med Aspose.Slides för Node.js via Java, vilket ger precisa bildförhandsvisningar utan att ändra dina presentationer."
---
## **Introduktion**

I PowerPoint 2019 introducerade Microsoft inställningen **Always Open Read-Only** som ett av de alternativ som användare kan använda för att skydda sina presentationer. Du kan vilja använda den här Read-Only‑inställningen för att skydda en presentation när

- Du vill förhindra oavsiktliga redigeringar och hålla innehållet i din presentation säkert. 
- Du vill informera personer om att den presentation du tillhandahåller är den slutgiltiga versionen. 

När du har valt alternativet **Always Open Read-Only** för en presentation, ser användarna **Read-Only**‑rekommendationen när de öppnar presentationen och kan få ett meddelande i följande form: *To prevent accidental changes, the author has set this file to open as read-only.*

Read-Only‑rekommendationen är ett enkelt men effektivt avskräckningsmedel som avskräcker redigering eftersom användarna måste utföra en åtgärd för att ta bort den innan de får redigera en presentation. Om du inte vill att användare ska göra ändringar i en presentation och vill meddela detta på ett artigt sätt, kan Read-Only‑rekommendationen vara ett bra alternativ för dig. 

> Om en presentation med **Read-Only**‑skydd öppnas i en äldre Microsoft PowerPoint‑applikation – som inte stöder den nyligen introducerade funktionen – ignoreras **Read-Only**‑rekommendationen (presentationen öppnas normalt).

## **Tillämpa Read-Only‑läge**

Aspose.Slides för Node.js via Java låter dig ställa in en presentation till **Read-Only**, vilket betyder att användare (efter att de öppnat presentationen) ser **Read-Only**‑rekommendationen. Detta exempel visar hur du ställer in en presentation till **Read-Only** i JavaScript med Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

**Obs**: **Read-Only**‑rekommendationen är enbart avsedd att avskräcka redigering eller hindra användare från att göra oavsiktliga ändringar i en PowerPoint‑presentation. Om en motiverad person – som vet vad de gör – bestämmer sig för att redigera din presentation, kan de enkelt ta bort Read-Only‑inställningen. Om du på allvar behöver förhindra obehörig redigering är det bättre att använda [mer stringenta skydd som innefattar kryptering och lösenord](https://docs.aspose.com/slides/sv/nodejs-java/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**Hur skiljer sig 'Read-Only recommended' från full lösenordsskydd?**

'Read-Only recommended' visar bara ett förslag att öppna filen i skrivskyddat läge och är lätt att kringgå. [Lösenordsskydd](/slides/sv/nodejs-java/password-protected-presentation/) begränsar faktiskt öppning eller redigering och är lämplig när du behöver verkliga säkerhetskontroller.

**Kan 'Read-Only recommended' kombineras med vattenstämplar för att ytterligare avskräcka redigering?**

Ja. Rekommendationen kan kombineras med [vattenstämplar](/slides/sv/nodejs-java/watermark/) som ett visuellt avskräckningsmedel; de är separata mekanismer och fungerar bra tillsammans.

**Kan ett makro eller ett externt verktyg fortfarande ändra filen när rekommendationen är aktiverad?**

Ja. Rekommendationen blockerar inte programatiska ändringar. För att förhindra automatiserade redigeringar, använd [lösenord och kryptering](/slides/sv/nodejs-java/password-protected-presentation/).

**Hur relaterar 'Read-Only recommended' till flaggorna 'IsEncrypted' och 'IsWriteProtected'?**

De är olika signaler. 'Read-Only recommended' är en mjuk, valfri uppmaning; [isWriteProtected](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) och [isEncrypted](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/protectionmanager/isencrypted/) indikerar faktiska skriv- eller läsrestriktioner som beror på lösenord eller kryptering.