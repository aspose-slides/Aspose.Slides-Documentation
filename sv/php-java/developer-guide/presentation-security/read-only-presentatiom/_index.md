---
title: Spara presentationer i skrivskyddat läge med PHP
linktitle: Skrivskyddad presentation
type: docs
weight: 30
url: /sv/php-java/read-only-presentation/
keywords:
- skrivskyddad
- skydda presentation
- förhindra redigering
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Läs in och spara PowerPoint-filer (PPT, PPTX) i skrivskyddat läge med Aspose.Slides för PHP, vilket ger exakta bildförhandsvisningar utan att ändra dina presentationer."
---
## **Introduktion**

I PowerPoint 2019 introducerade Microsoft inställningen **Always Open Read-Only** som ett av de alternativ som användare kan använda för att skydda sina presentationer. Du kanske vill använda den här Read-Only‑inställningen för att skydda en presentation när

- Du vill förhindra oavsiktliga redigeringar och hålla innehållet i din presentation säkert. 
- Du vill informera folk om att presentationen du tillhandahåller är den slutgiltiga versionen. 

Efter att du har valt alternativet **Always Open Read-Only** för en presentation, så ser användarna **Read-Only**‑rekommendationen när de öppnar presentationen och kan se ett meddelande i följande form: *För att förhindra oavsiktliga ändringar har författaren ställt in så att filen öppnas som skrivskyddad.*

Read-Only‑rekommendationen är ett enkelt men effektivt avskräckningsmedel som avskräcker redigering eftersom användarna måste utföra en åtgärd för att ta bort den innan de får redigera en presentation. Om du inte vill att användare ska göra ändringar i en presentation och vill meddela dem detta på ett artigt sätt, kan Read-Only‑rekommendationen vara ett bra alternativ för dig. 

> Om en presentation med **Read-Only**‑skydd öppnas i en äldre Microsoft PowerPoint‑applikation—som inte stödjer den nyligen introducerade funktionen—ignoreras **Read-Only**‑rekommendationen (presentationen öppnas normalt).

## **Aktivera skrivskyddat läge**

Aspose.Slides for PHP via Java låter dig ställa in en presentation som **Read-Only**, vilket betyder att användare (efter att de öppnat presentationen) ser **Read-Only**‑rekommendationen. Detta exempel visar hur du ställer in en presentation som **Read-Only** med hjälp av Aspose.Slides:

```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 

**Observera**: **Read-Only**‑rekommendationen är avsedd att avskräcka redigering eller hindra användare från att göra oavsiktliga ändringar i en PowerPoint‑presentation. Om en motiverad person—som vet vad de gör—bestämmer sig för att redigera din presentation kan de enkelt ta bort Read-Only‑inställningen. Om du verkligen behöver förhindra obehörig redigering är du bättre att använda [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/sv/php-java/password-protected-presentation/).

{{% /alert %}} 

## **Vanliga frågor**

**Hur skiljer sig 'Read-Only recommended' från fullständigt lösenordsskydd?**

'Read-Only recommended' visar bara ett förslag på att öppna filen i skrivskyddat läge och är enkelt att kringgå. [Password protection](/slides/sv/php-java/password-protected-presentation/) begränsar faktiskt öppning eller redigering och är lämplig när du behöver verkliga säkerhetskontroller.

**Kan 'Read-Only recommended' kombineras med vattenstämplar för att ytterligare avskräcka redigering?**

Ja. Rekommendationen kan kombineras med [watermarks](/slides/sv/php-java/watermark/) som ett visuellt avskräckningsmedel; de är separata mekanismer och fungerar bra tillsammans.

**Kan ett makro eller ett externt verktyg fortfarande ändra filen när rekommendationen är aktiverad?**

Ja. Rekommendationen blockerar inte programatiska förändringar. För att förhindra automatiska redigeringar, använd [passwords and encryption](/slides/sv/php-java/password-protected-presentation/).

**Hur förhåller sig 'Read-Only recommended' till metoderna 'isEncrypted' och 'isWriteProtected'?**

De är olika signaler. 'Read-Only recommended' är en mjuk, valfri uppmaning; [isWriteProtected](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/iswriteprotected/) och [isEncrypted](https://reference.aspose.com/slides/sv/php-java/aspose.slides/protectionmanager/isencrypted/) indikerar faktiska skriv‑ eller läsrestriktioner som beror på lösenord eller kryptering.