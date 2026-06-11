---
title: Spara presentationer i skrivskyddat läge på Android
linktitle: Skrivskyddad presentation
type: docs
weight: 30
url: /sv/androidjava/read-only-presentation/
keywords:
- skrivskyddad
- skydda presentation
- förhindra redigering
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Spara PowerPoint-filer (PPT, PPTX) i skrivskyddat läge med Aspose.Slides för Android via Java, vilket ger exakta bildspelsförhandsvisningar utan att ändra dina presentationer."
---
## **Introduktion**

I PowerPoint 2019 introducerade Microsoft inställningen **Always Open Read-Only** som ett av de alternativ som användare kan använda för att skydda sina presentationer. Du kanske vill använda den här Read-Only‑inställningen för att skydda en presentation när

- Du vill förhindra oavsiktliga redigeringar och hålla innehållet i din presentation säkert. 
- Du vill meddela att presentationen du levererat är den slutgiltiga versionen. 

När du har valt alternativet **Always Open Read-Only** för en presentation, ser användarna **Read-Only**‑rekommendationen när de öppnar presentationen och kan få ett meddelande i följande form: *För att förhindra oavsiktliga ändringar har författaren ställt in att den här filen öppnas som skrivskyddad.*

Read‑Only‑rekommendationen är ett enkelt men effektivt avskräckningsmedel som motverkar redigering eftersom användarna måste utföra en åtgärd för att ta bort den innan de får redigera en presentation. Om du inte vill att användare ska göra ändringar i en presentation och vill meddela detta på ett artigt sätt, kan Read‑Only‑rekommendationen vara ett bra alternativ för dig. 

> Om en presentation med **Read-Only**‑skydd öppnas i en äldre Microsoft PowerPoint‑applikation—som inte stödjer den nyligen introducerade funktionen—ignoreras **Read-Only**‑rekommendationen (presentationen öppnas normalt).

## **Tillämpa Läs‑skyddsläge**

Aspose.Slides för Android via Java låter dig ställa in en presentation till **Read-Only**, vilket innebär att användare (efter att de öppnat presentationen) ser **Read-Only**‑rekommendationen. Detta exempel visar hur du ställer in en presentation till **Read-Only** i Java med Aspose.Slides:

```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 

**Obs**: **Read-Only**‑rekommendationen är bara avsedd att avskräcka redigering eller stoppa användare från att göra oavsiktliga ändringar i en PowerPoint‑presentation. Om en motiverad person—som vet vad de gör—bestämmer sig för att redigera din presentation, kan de enkelt ta bort Read‑Only‑inställningen. Om du seriöst behöver förhindra obehörig redigering, är du bättre med att använda [mer strikta skydd som involverar kryptering och lösenord](https://docs.aspose.com/slides/sv/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **Vanliga frågor**

**Hur skiljer sig 'Read-Only recommended' från fullt lösenordsskydd?**

'Read-Only recommended' visar bara ett förslag att öppna filen i skrivskyddat läge och är lätt att kringgå. [Lösenordsskydd](/slides/sv/androidjava/password-protected-presentation/) begränsar faktiskt öppning eller redigering och är lämpligt när du behöver verkliga säkerhetskontroller.

**Kan 'Read-Only recommended' kombineras med vattenstämplar för att ytterligare avskräcka redigering?**

Ja. Rekommendationen kan kombineras med [vattenstämplar](/slides/sv/androidjava/watermark/) som ett visuellt avskräckningsmedel; de är separata mekanismer och fungerar bra ihop.

**Kan ett makro eller ett externt verktyg fortfarande ändra filen när rekommendationen är aktiverad?**

Ja. Rekommendationen blockerar inte programmässiga ändringar. För att förhindra automatiserade redigeringar, använd [lösenord och kryptering](/slides/sv/androidjava/password-protected-presentation/).

**Hur förhåller sig 'Read-Only recommended' till metoderna 'isEncrypted' och 'isWriteProtected'?**

De är olika signaler. 'Read-Only recommended' är en mjuk, valfri uppmaning; [isWriteProtected](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) och [isEncrypted](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) indikerar faktiska skriv- eller läsrestriktioner som beror på lösenord eller kryptering.