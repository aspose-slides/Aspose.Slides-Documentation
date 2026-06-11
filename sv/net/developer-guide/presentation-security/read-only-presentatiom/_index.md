---
title: Spara presentationer i Läs‑endast‑läge i .NET
linktitle: Läs‑endast‑presentation
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
description: "Läs in och spara PowerPoint‑filer (PPT, PPTX) i skrivskyddat läge med Aspose.Slides för .NET, vilket ger exakta förhandsgranskningar av bilder utan att ändra dina presentationer."
---
## **Introduktion**

I PowerPoint 2019 introducerade Microsoft inställningen **Always Open Read-Only** som ett av de alternativ som användare kan använda för att skydda sina presentationer. Du kanske vill använda denna Läs‑endast‑inställning för att skydda en presentation när

- Du vill förhindra oavsiktliga redigeringar och hålla innehållet i din presentation säkert.
- Du vill informera personer om att den presentation du tillhandahåller är den slutgiltiga versionen.

När du har valt alternativet **Always Open Read-Only** för en presentation, ser användarna **Read-Only**‑rekommendationen när de öppnar presentationen och kan få ett meddelande i följande form: *För att förhindra oavsiktliga ändringar har författaren ställt in att den här filen ska öppnas som skrivskyddad.*

Read-Only‑rekommendationen är ett enkelt men effektivt avskräckningsmedel som motverkar redigering eftersom användarna måste utföra en åtgärd för att ta bort den innan de får redigera en presentation. Om du inte vill att användare ska göra ändringar i en presentation och vill informera dem om detta på ett artigt sätt, kan Read-Only‑rekommendationen vara ett bra alternativ för dig.

> Om en presentation med **Read-Only**‑skydd öppnas i en äldre Microsoft PowerPoint‑applikation—som inte stödjer den nyintroduserade funktionen—ignoreras **Read-Only**‑rekommendationen (presentationen öppnas normalt).

## **Applicera Läs‑endast‑läge**

Aspose.Slides för .NET låter dig ställa in en presentation som **Read-Only**, vilket innebär att användare (efter att de öppnat presentationen) ser **Read-Only**‑rekommendationen. Detta exempel visar hur du ställer in en presentation som **Read-Only** i C# med Aspose.Slides:

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 
**Obs**: **Read-Only**‑rekommendationen är helt enkelt avsedd att avskräcka redigering eller hindra användare från att göra oavsiktliga ändringar i en PowerPoint‑presentation. Om en motiverad person—som vet vad de gör—bestämmer sig för att redigera din presentation, kan de enkelt ta bort Läs‑endast‑inställningen. Om du på allvar behöver förhindra obehörig redigering, är du bättre av att använda [mer strikta skydd som involverar kryptering och lösenord](https://docs.aspose.com/slides/sv/net/password-protected-presentation/). 
{{% /alert %}} 

## **FAQ**

**Hur skiljer sig 'Read-Only recommended' från fullständig lösenordsskydd?**

'Read-Only recommended' visar bara ett förslag att öppna filen i skrivskyddat läge och är lätt att kringgå. [Lösenordsskydd](/slides/sv/net/password-protected-presentation/) begränsar faktiskt öppning eller redigering och är lämpligt när du behöver verkliga säkerhetskontroller.

**Kan 'Read-Only recommended' kombineras med vattenmärken för att ytterligare avskräcka redigeringar?**

Ja. Rekommendationen kan paras ihop med [vattenmärken](/slides/sv/net/watermark/) som ett visuellt avskräckningsmedel; de är separata mekanismer och fungerar bra tillsammans.

**Kan ett makro eller ett externt verktyg fortfarande ändra filen när rekommendationen är aktiverad?**

Ja. Rekommendationen blockerar inte programatiska ändringar. För att förhindra automatiserade redigeringar, använd [lösenord och kryptering](/slides/sv/net/password-protected-presentation/).

**Hur relaterar 'Read-Only recommended' till flaggorna 'IsEncrypted' och 'IsWriteProtected'?**

De är olika signaler. 'Read-Only recommended' är en mjuk, valfri uppmaning; [IsWriteProtected](https://reference.aspose.com/slides/sv/net/aspose.slides/protectionmanager/iswriteprotected/) och [IsEncrypted](https://reference.aspose.com/slides/sv/net/aspose.slides/protectionmanager/isencrypted/) indikerar faktiska skriv- eller läsrestriktioner som beror på lösenord eller kryptering.