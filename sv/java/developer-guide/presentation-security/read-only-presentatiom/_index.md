---
title: Spara presentationer i skrivskyddat läge med Java
linktitle: Skrivskyddad presentation
type: docs
weight: 30
url: /sv/java/read-only-presentation/
keywords:
- skrivskyddad
- skydda presentation
- förhindra redigering
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Läs in och spara PowerPoint-filer (PPT, PPTX) i skrivskyddat läge med Aspose.Slides för Java, vilket ger exakta bildförhandsvisningar utan att ändra dina presentationer."
---
## **Introduktion**

I PowerPoint 2019 introducerade Microsoft inställningen **Always Open Read-Only** som ett av alternativen som användare kan använda för att skydda sina presentationer. Du kanske vill använda detta skrivskyddade läge för att skydda en presentation när

- Du vill förhindra oavsiktliga redigeringar och hålla innehållet i din presentation säkert. 
- Du vill informera folk om att den presentation du tillhandahåller är den slutgiltiga versionen. 

När du har valt alternativet **Always Open Read-Only** för en presentation, ser användarna **Read-Only**‑rekommendationen när de öppnar presentationen och kan få ett meddelande i följande form: *För att förhindra oavsiktliga ändringar har författaren ställt in att den här filen ska öppnas som skrivskyddad.*

Read-Only‑rekommendationen är ett enkelt men effektivt avskräckningsmedel som motverkar redigering eftersom användarna måste utföra en åtgärd för att ta bort den innan de får redigera en presentation. Om du inte vill att användarna ska göra ändringar i en presentation och vill meddela detta på ett artigt sätt, kan Read-Only‑rekommendationen vara ett bra alternativ för dig. 

> Om en presentation med **Read-Only**‑skydd öppnas i en äldre Microsoft PowerPoint‑applikation—som inte stöder den nyligen introducerade funktionen—ignoreras **Read-Only**‑rekommendationen (presentationen öppnas normalt).

## **Applicera skrivskyddat läge**

Aspose.Slides for Java gör det möjligt att sätta en presentation till **Read-Only**, vilket betyder att användare (efter att de öppnat presentationen) ser **Read-Only**‑rekommendationen. Detta exempel visar hur du sätter en presentation till **Read-Only** i Java med Aspose.Slides:

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

**Obs**: **Read-Only**‑rekommendationen är avsedd att avskräcka redigering eller hindra användare från att göra oavsiktliga ändringar i en PowerPoint‑presentation. Om en motiverad person—som vet vad de gör—bestämmer sig för att redigera din presentation kan de enkelt ta bort skrivskyddet. Om du verkligen behöver förhindra obehörig redigering är det bättre att använda [Lösenordsskydd](/slides/sv/java/password-protected-presentation/). 

{{% /alert %}} 

## **Vanliga frågor**

**Hur skiljer sig 'Read-Only recommended' från fullständigt lösenordsskydd?**

'Read-Only recommended' visar endast ett förslag att öppna filen i skrivskyddat läge och är lätt att kringgå. [Lösenordsskydd](/slides/sv/java/password-protected-presentation/) begränsar faktiskt öppning eller redigering och är lämplig när du behöver verkliga säkerhetskontroller.

**Kan 'Read-Only recommended' kombineras med vattenstämplar för att ytterligare avskräcka redigering?**

Ja. Rekommendationen kan kombineras med [vattenstämplar](/slides/sv/java/watermark/) som ett visuellt avskräckningsmedel; de är separata mekanismer och fungerar bra ihop.

**Kan ett makro eller ett externt verktyg fortfarande ändra filen när rekommendationen är aktiverad?**

Ja. Rekommendationen blockerar inte programatiska ändringar. För att förhindra automatiserade redigeringar, använd [lösenord och kryptering](/slides/sv/java/password-protected-presentation/).

**Hur relaterar 'Read-Only recommended' till metoderna 'isEncrypted' och 'isWriteProtected'?**

De är olika signaler. 'Read-Only recommended' är en mjuk, valfri prompt; [isWriteProtected](https://reference.aspose.com/slides/sv/java/com.aspose.slides/protectionmanager/#isWriteProtected--) och [isEncrypted](https://reference.aspose.com/slides/sv/java/com.aspose.slides/protectionmanager/#isEncrypted--) indikerar faktiska skriv‑ eller läsrestriktioner som beror på lösenord eller kryptering.