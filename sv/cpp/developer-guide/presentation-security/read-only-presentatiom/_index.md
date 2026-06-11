---
title: Spara presentationer i skrivskyddat läge med C++
linktitle: Skrivskyddad presentation
type: docs
weight: 30
url: /sv/cpp/read-only-presentation/
keywords:
- skrivskyddad
- skydda presentation
- förhindra redigering
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Läs in och spara PowerPoint‑filer (PPT, PPTX) i skrivskyddat läge med Aspose.Slides för C++, vilket ger exakt förhandsgranskning av bilder utan att ändra dina presentationer."
---
## **Introduktion**

I PowerPoint 2019 introducerade Microsoft inställningen **Always Open Read-Only** som ett av de alternativ som användare kan använda för att skydda sina presentationer. Du kanske vill använda den här Read-Only‑inställningen för att skydda en presentation när

- Du vill förhindra oavsiktliga redigeringar och hålla innehållet i din presentation säkert. 
- Du vill informera personer om att den presentation du levererat är den slutgiltiga versionen. 

När du har valt alternativet **Always Open Read-Only** för en presentation, ser användarna **Read-Only**‑rekommendationen när de öppnar presentationen och kan få ett meddelande i följande form: *To prevent accidental changes, the author has set this file to open as read-only.*

Read-Only‑rekommendationen är ett enkelt men effektivt avskräckningsmedel som avskräcker redigering eftersom användarna måste utföra en åtgärd för att ta bort den innan de får redigera en presentation. Om du inte vill att användare ska göra ändringar i en presentation och vill meddela detta på ett vänligt sätt, kan Read-Only‑rekommendationen vara ett bra alternativ för dig. 

> Om en presentation med **Read-Only**‑skydd öppnas i en äldre Microsoft PowerPoint‑applikation — som inte stöder den nyligen introducerade funktionen — ignoreras **Read-Only**‑rekommendationen (presentationen öppnas som vanligt).

## **Tillämpa skrivskyddat läge**

Aspose.Slides för C++ låter dig ställa in en presentation till **Read-Only**, vilket innebär att användare (efter att de öppnat presentationen) ser **Read-Only**‑rekommendationen. Detta exempel visar hur du sätter en presentation till **Read-Only** i C++ med Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

**Obs**: **Read-Only**‑rekommendationen är enbart avsedd att avskräcka redigering eller hindra användare från att göra oavsiktliga ändringar i en PowerPoint‑presentation. Om en motiverad person — som vet vad de gör — bestämmer sig för att redigera din presentation, kan de enkelt ta bort Read-Only‑inställningen. Om du verkligen behöver förhindra obehörig redigering är du bättre med att använda [mer strikta skydd som involverar kryptering och lösenord](https://docs.aspose.com/slides/sv/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **Vanliga frågor**

**Hur skiljer sig 'Read-Only recommended' från fullständigt lösenordsskydd?**

'Read-Only recommended' visar bara ett förslag att öppna filen i skrivskyddat läge och är lätt att kringgå. [Lösenordsskydd](/slides/sv/cpp/password-protected-presentation/) begränsar faktiskt öppning eller redigering och är lämpligt när du behöver verkliga säkerhetskontroller.

**Kan 'Read-Only recommended' kombineras med vattenmärken för att ytterligare avskräcka redigering?**

Ja. Rekommendationen kan kombineras med [vattenmärken](/slides/sv/cpp/watermark/) som ett visuellt avskräckningsmedel; de är separata mekanismer och fungerar bra tillsammans.

**Kan ett makro eller ett externt verktyg fortfarande ändra filen när rekommendationen är aktiverad?**

Ja. Rekommendationen blockerar inte programatiska ändringar. För att förhindra automatiserade redigeringar, använd [lösenord och kryptering](/slides/sv/cpp/password-protected-presentation/).

**Hur förhåller sig 'Read-Only recommended' till flaggorna 'is encrypted' och 'is write protected'?**

De är olika signaler. 'Read-Only recommended' är en mjuk, valfri prompt; [get_IsWriteProtected](https://reference.aspose.com/slides/sv/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) och [get_IsEncrypted](https://reference.aspose.com/slides/sv/cpp/aspose.slides/protectionmanager/get_isencrypted/) indikerar faktiska skriv- eller lässkydd som beror på lösenord eller kryptering.