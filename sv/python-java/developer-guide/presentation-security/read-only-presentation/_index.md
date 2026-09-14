---
title: Spara presentationer i läs-endast-läge med Python
linktitle: Läs-endast-presentation
type: docs
weight: 30
url: /sv/python-java/read-only-presentation/
keywords:
- läs-endast
- skydda presentation
- förhindra redigering
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Läs in och spara PowerPoint-filer (PPT, PPTX) i läs-endast-läge med Aspose.Slides för Python via Java, vilket ger exakta bildspelsförhandsvisningar utan att ändra dina presentationer."
---
## **Introduktion**

I PowerPoint 2019 introducerade Microsoft inställningen **Always Open Read-Only** som ett av de alternativ som användare kan använda för att skydda sina presentationer. Du kanske vill använda den här Läs‑endast‑inställningen för att skydda en presentation när:

- Du vill förhindra oavsiktliga redigeringar och hålla innehållet i din presentation säkert. 
- Du vill meddela att den presentation du tillhandahåller är den slutgiltiga versionen. 

När du har valt alternativet **Always Open Read-Only** för en presentation, ser användarna **Read-Only**‑rekommendationen när de öppnar presentationen och kan få ett meddelande i följande form: *För att förhindra oavsiktliga ändringar har författaren ställt in att den här filen ska öppnas som Läs‑endast.*

Read‑Only‑rekommendationen är ett enkelt men effektivt avskräckningsmedel som avskräcker redigering eftersom användare måste utföra en åtgärd för att ta bort den innan de får redigera en presentation. Om du inte vill att användare ska göra ändringar i en presentation och vill meddela detta på ett artigt sätt, kan Read‑Only‑rekommendationen vara ett bra alternativ för dig. 

> Om en presentation med **Read-Only**‑skydd öppnas i en äldre Microsoft PowerPoint‑applikation—som inte stödjer den nyintroducerade funktionen—ignoreras **Read-Only**‑rekommendationen (presentationen öppnas normalt).

## **Aktivera Läs‑endast‑läge**

Aspose.Slides för Python via Java låter dig ställa in en presentation till **Read-Only**, vilket innebär att användare (efter att de öppnat presentationen) ser **Read-Only**‑rekommendationen. Detta exempel visar hur du ställer in en presentation till **Read-Only** i Python med Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

**Read-Only**‑rekommendationen är helt enkelt avsedd att avskräcka redigering eller hindra användare från att göra oavsiktliga förändringar i en PowerPoint‑presentation. Om en motiverad person—som vet vad de gör—bestämmer sig för att redigera din presentation, kan de enkelt ta bort Läs‑endast‑inställningen. Om du på riktigt behöver förhindra obehörig redigering, är du bättre att använda [mer strikta skydd som involverar kryptering och lösenord](/slides/sv/python-java/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**Hur skiljer sig 'Read-Only recommended' från fullt lösenordsskydd?**

'Read-Only recommended' visar endast ett förslag att öppna filen i Läs‑endast‑läge och är lätt att kringgå. [Lösenordsskydd](/slides/sv/python-java/password-protected-presentation/) begränsar faktiskt öppning eller redigering och är lämplig när du behöver verkliga säkerhetskontroller.

**Kan 'Read-Only recommended' kombineras med vattenstämplar för att ytterligare avskräcka redigering?**

Ja. Rekommendationen kan kombineras med [vattenstämplar](/slides/sv/python-java/watermark/) som ett visuellt avskräckningsmedel; de är separata mekanismer och fungerar bra tillsammans.

**Kan ett makro eller ett externt verktyg fortfarande ändra filen när rekommendationen är aktiverad?**

Ja. Rekommendationen blockerar inte programatiska ändringar. För att förhindra automatiserade redigeringar, använd [lösenord och kryptering](/slides/sv/python-java/password-protected-presentation/).

**Hur förhåller sig 'Read-Only recommended' till metoderna [isEncrypted](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#isEncrypted) och [isWriteProtected](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#isWriteProtected)?**

De är olika signaler. 'Read-Only recommended' är en mjuk, valfri uppmaning; [isWriteProtected](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#isWriteProtected) och [isEncrypted](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#isEncrypted) indikerar faktiska skriv‑ eller läs‑restriktioner som beror på lösenord eller kryptering.