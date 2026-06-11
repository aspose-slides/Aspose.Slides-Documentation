---
title: Spara presentationer i skrivskyddat läge med Python
linktitle: Skrivskyddad presentation
type: docs
weight: 30
url: /sv/python-net/read-only-presentation/
keywords:
- skrivskyddad
- skydda presentation
- förhindra redigering
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Läs in och spara PowerPoint-filer (PPT, PPTX) i skrivskyddat läge med Aspose.Slides för Python via .NET, vilket ger exakta bildförhandsgranskningar utan att ändra dina presentationer."
---
## **Introduktion**

I PowerPoint 2019 introducerade Microsoft inställningen **Always Open Read-Only** som ett av de alternativ som användare kan använda för att skydda sina presentationer. Du kanske vill använda den här Read-Only‑inställningen för att skydda en presentation när

- Du vill förhindra oavsiktliga redigeringar och hålla innehållet i din presentation säkert. 
- Du vill informera folk om att den presentation du levererat är den slutgiltiga versionen. 

När du har valt alternativet **Always Open Read-Only** för en presentation, så ser användarna **Read-Only**‑rekommendationen när de öppnar presentationen och kan se ett meddelande i denna form: *För att förhindra oavsiktliga ändringar har författaren ställt in att filen ska öppnas som skrivskyddad.*

Read-Only‑rekommendationen är ett enkelt men effektivt avskräckningsmedel som avskräcker redigering eftersom användarna måste utföra en åtgärd för att ta bort den innan de får redigera en presentation. Om du inte vill att användare ska göra ändringar i en presentation och vill meddela dem detta på ett artigt sätt, kan Read-Only‑rekommendationen vara ett bra alternativ för dig. 

> Om en presentation med **Read-Only**‑skydd öppnas i en äldre Microsoft PowerPoint‑applikation — som inte stöder den nyligen införda funktionen — så ignoreras **Read-Only**‑rekommendationen (presentationen öppnas normalt).

## **Aktivera Läs‑endläge**

Aspose.Slides for Python via .NET låter dig ställa in en presentation till **Read-Only**, vilket innebär att användare (efter att de öppnat presentationen) ser **Read-Only**‑rekommendationen. Denna exempelkod visar hur du ställer in en presentation till **Read-Only** i Python med Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Obs!**: **Read-Only**‑rekommendationen är avsedd att avskräcka redigering eller hindra användare från att göra oavsiktliga ändringar i en PowerPoint‑presentation. Om en motiverad person — som vet vad den gör — bestämmer sig för att redigera din presentation, kan den enkelt ta bort Read-Only‑inställningen. Om du på allvar behöver förhindra obehörig redigering, är du bättre betjänt med att använda [mer restriktiva skydd som involverar kryptering och lösenord](https://docs.aspose.com/slides/sv/python-net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Hur skiljer sig 'Read-Only recommended' från fullständigt lösenordsskydd?**

'Read-Only recommended' visar bara ett förslag att öppna filen i skrivskyddat läge och är enkelt att kringgå. [Lösenordsskydd](/slides/sv/python-net/password-protected-presentation/) begränsar faktiskt öppning eller redigering och är lämpligt när du behöver verkliga säkerhetskontroller.

**Kan 'Read-Only recommended' kombineras med vattenmärken för att ytterligare avskräcka redigering?**

Ja. Rekommendationen kan kombineras med [vattenmärken](/slides/sv/python-net/watermark/) som ett visuellt avskräckningsmedel; de är separata mekanismer och fungerar bra tillsammans.

**Kan ett makro eller ett externt verktyg fortfarande ändra filen när rekommendationen är aktiverad?**

Ja. Rekommendationen blockerar inte programatiska förändringar. För att förhindra automatiska redigeringar, använd [lösenord och kryptering](/slides/sv/python-net/password-protected-presentation/).

**Hur relaterar 'Read-Only recommended' till flaggorna 'is_encrypted' och 'is_write_protected'?**

De är olika signaler. 'Read-Only recommended' är en mjuk, valfri prompt; [is_write_protected](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/is_write_protected/) och [is_encrypted](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/is_encrypted/) indikerar faktiska skrivrättighets‑ eller läsrättighetsrestriktioner som beror på lösenord eller kryptering.