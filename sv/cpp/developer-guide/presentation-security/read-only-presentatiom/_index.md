---
title: Spara presentationer i Läs‑Endast‑läge med C++
linktitle: Läs‑Endast‑presentation
type: docs
weight: 30
url: /sv/cpp/read-only-presentation/
keywords:
- läs endast
- skydda presentation
- förhindra redigering
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Läs in och spara PowerPoint‑filer (PPT, PPTX) i läs‑endast‑läge med Aspose.Slides för C++, vilket ger exakta bildförhandsvisningar utan att ändra dina presentationer."
---
## **Introduktion**

I PowerPoint 2019 introducerade Microsoft inställningen **Always Open Read-Only** som ett av de alternativ som användare kan använda för att skydda sina presentationer. Du kanske vill använda den här Läs‑Endast‑inställningen för att skydda en presentation när

- Du vill förhindra oavsiktliga redigeringar och hålla innehållet i din presentation säkert. 
- Du vill meddela att den presentation du tillhandahåller är den slutgiltiga versionen. 

Efter att du har valt **Always Open Read-Only**‑alternativet för en presentation, när användare öppnar presentationen ser de **Read-Only**‑rekommendationen och kan se ett meddelande i denna form: *För att förhindra oavsiktliga ändringar har författaren ställt in att den här filen öppnas som skrivskyddad.*

Rekommendationen Läs‑Endast är ett enkelt men effektivt avskräckningsmedel som avråder från redigering eftersom användare måste utföra en åtgärd för att ta bort den innan de får redigera en presentation. Om du inte vill att användare ska göra ändringar i en presentation och vill meddela dem detta på ett artigt sätt, kan Läs‑Endast‑rekommendationen vara ett bra alternativ för dig. 

> Om en presentation med **Read-Only**‑skydd öppnas i en äldre Microsoft PowerPoint‑applikation — som inte stöder den nyligen introducerade funktionen — så ignoreras **Read-Only**‑rekommendationen (presentationen öppnas normalt).

## **Använd Läs‑Endast‑läge**

Aspose.Slides for C++ låter dig ställa in en presentation till **Read-Only**, vilket betyder att användare (efter att de öppnat presentationen) ser **Read-Only**‑rekommendationen. Detta exempel visar hur du ställer in en presentation till **Read-Only** i C++ med Aspose.Slides:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**Obs!**: **Read-Only**‑rekommendationen är bara avsedd att avskräcka redigering eller hindra användare från att göra oavsiktliga ändringar i en PowerPoint‑presentation. Om en motiverad person — som vet vad de gör — bestämmer sig för att redigera din presentation, kan de enkelt ta bort Läs‑Endast‑inställningen. Om du verkligen behöver förhindra obehörig redigering, är du bättre att använda [mer strikt skydd som involverar kryptering och lösenord](https://docs.aspose.com/slides/sv/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

### Hur skiljer sig 'Read-Only recommended' från fullständigt lösenordsskydd?

'Read-Only recommended' visar bara ett förslag att öppna filen i Läs‑Endast‑läge och är enkelt att kringgå. [Lösenordsskydd](/slides/sv/cpp/password-protected-presentation/) begränsar faktiskt öppning eller redigering och är lämplig när du behöver verkliga säkerhetskontroller.

### Kan 'Read-Only recommended' kombineras med vattenstämplar för att ytterligare avskräcka redigering?

Ja. Rekommendationen kan kombineras med [vattenstämplar](/slides/sv/cpp/watermark/) som ett visuellt avskräckningsmedel; de är separata mekanismer och fungerar bra ihop.

### Kan ett makro eller ett externt verktyg fortfarande ändra filen när rekommendationen är aktiverad?

Ja. Rekommendationen blockerar inte programmässiga ändringar. För att förhindra automatiserade redigeringar, använd [lösenord och kryptering](/slides/sv/cpp/password-protected-presentation/).

### Hur förhåller sig 'Read-Only recommended' till flaggorna 'is encrypted' och 'is write protected'?

De är olika signaler. 'Read-Only recommended' är en mjuk, valfri prompt; [get_IsWriteProtected](https://reference.aspose.com/slides/sv/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) och [get_IsEncrypted](https://reference.aspose.com/slides/sv/cpp/aspose.slides/protectionmanager/get_isencrypted/) indikerar faktiska skriv‑ eller läsrestriktioner som beror på lösenord eller kryptering.