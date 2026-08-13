---
title: Spara presentationer i skrivskyddat läge i .NET
linktitle: Skrivskyddad presentation
type: docs
weight: 30
url: /sv/net/read-only-presentation/
keywords:
- skrivskyddad
- skydda presentation
- förhindra redigering
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Läs in och spara PowerPoint-filer (PPT, PPTX) i skrivskyddat läge med Aspose.Slides för .NET, vilket ger exakta bildförhandsgranskningar utan att ändra dina presentationer."
---
## **Introduktion**

I PowerPoint 2019 introducerade Microsoft inställningen **Always Open Read-Only** som ett av de alternativ som användare kan använda för att skydda sina presentationer. Du kanske vill använda den här Read-Only‑inställningen för att skydda en presentation när

- Du vill förhindra oavsiktliga redigeringar och hålla innehållet i din presentation säkert. 
- Du vill meddela folk att den presentation du tillhandahåller är den slutgiltiga versionen. 

Efter att du har valt alternativet **Always Open Read-Only** för en presentation, när användare öppnar presentationen ser de rekommendationen **Read-Only** och kan se ett meddelande i följande form: *För att förhindra oavsiktliga ändringar har författaren ställt in att den här filen öppnas som skrivskyddad.*

Read-Only‑rekommendationen är ett enkelt men ändå effektivt avskräckningsmedel som avskräcker redigering eftersom användare måste utföra en åtgärd för att ta bort den innan de får redigera en presentation. Om du inte vill att användare ska göra ändringar i en presentation och vill meddela dem detta på ett artigt sätt, kan Read-Only‑rekommendationen vara ett bra alternativ för dig. 

> Om en presentation med **Read-Only**‑skydd öppnas i en äldre Microsoft PowerPoint‑applikation—som inte stöder den nyligen introducerade funktionen—ignoreras **Read-Only**‑rekommendationen (presentationen öppnas normalt).

## **Aktivera Läs‑bara‑läge**

Aspose.Slides for .NET gör det möjligt att ställa in en presentation till **Read-Only**, vilket betyder att användare (efter att de har öppnat presentationen) ser **Read-Only**‑rekommendationen. Detta exempel visar hur du ställer in en presentation till **Read-Only** i C# med Aspose.Slides:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**Obs**: **Read-Only**‑rekommendationen är helt enkelt avsedd att avskräcka redigering eller hindra användare från att göra oavsiktliga ändringar i en PowerPoint‑presentation. Om en motiverad person—som vet vad de gör—bestämmer sig för att redigera din presentation, kan de enkelt ta bort Read-Only‑inställningen. Om du verkligen behöver förhindra obehörig redigering är du bättre att använda [mer strikta skydd som innefattar kryptering och lösenord](https://docs.aspose.com/slides/sv/net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### Hur skiljer sig 'Read-Only recommended' från fullständigt lösenordsskydd?

'Read-Only recommended' visar bara ett förslag om att öppna filen i skrivskyddat läge och är enkelt att kringgå. [Lösenordsskydd](/slides/sv/net/password-protected-presentation/) begränsar faktiskt öppning eller redigering och är lämplig när du behöver verkliga säkerhetskontroller.

### Kan 'Read-Only recommended' kombineras med vattenstämplar för att ytterligare avskräcka redigeringar?

Ja. Rekommendationen kan kombineras med [vattenstämplar](/slides/sv/net/watermark/) som ett visuellt avskräckningsmedel; de är separata mekanismer och fungerar bra tillsammans.

### Kan ett makro eller ett externt verktyg fortfarande ändra filen när rekommendationen är aktiverad?

Ja. Rekommendationen blockerar inte programmässiga ändringar. För att förhindra automatiserade redigeringar, använd [lösenord och kryptering](/slides/sv/net/password-protected-presentation/).

### Hur relaterar 'Read-Only recommended' till flaggorna 'IsEncrypted' och 'IsWriteProtected'?

De är olika signaler. 'Read-Only recommended' är en mjuk, valfri uppmaning; [IsWriteProtected](https://reference.aspose.com/slides/sv/net/aspose.slides/protectionmanager/iswriteprotected/) och [IsEncrypted](https://reference.aspose.com/slides/sv/net/aspose.slides/protectionmanager/isencrypted/) indikerar faktiska skriv‑ eller läs‑restriktioner som beror på lösenord eller kryptering.