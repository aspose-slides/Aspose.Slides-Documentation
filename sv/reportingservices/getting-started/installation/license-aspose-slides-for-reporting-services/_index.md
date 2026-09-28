---
title: Licens Aspose.Slides for Reporting Services
type: docs
weight: 70
url: /sv/reportingservices/license-aspose-slides-for-reporting-services/
keywords:
- licens
- licensiering
- utvärderingsvattenstämpel
- tillfällig licens
- Aspose.Slides for Reporting Services
description: "Applicera en licens på Aspose.Slides for Reporting Services genom att kopiera licensfilen till rapportservern, och kontrollera att exporterade presentationer inte längre innehåller utvärderingsvattenstämpeln."
---
## **Licensstöd**

Utvärderingsversionen av Aspose.Slides for Reporting Services är samma paket som den köpta, från dess nedladdningssida, och ger samma funktionalitet. Utan licens fungerar den i utvärderingsläge och lägger in ett utvärderingsvattenstämpel i exporterade presentationer.

Utvärderingsversionen blir licensierad när du kopierar en licensfil till rapportservern. Ingen kod krävs.

När du är nöjd med din utvärdering kan du köpa en licens. Vi rekommenderar att du går igenom de olika prenumerationstyperna. Om du har frågor, kontakta Aspose försäljningsteam.

## **Licensiering i Aspose.Slides for Reporting Services**

* Licensen är en vanlig text‑XML‑fil som innehåller detaljer såsom produktnamn, antalet utvecklare den är licensierad för, prenumerationens utgångsdatum osv.
* Licensfilen är digitalt signerad, så du får inte ändra den. Även ett oavsiktligt tillägg av en extra radbrytning i filens innehåll gör den ogiltig.

För att tillämpa licensen:

1. Kopiera licensfilen till *ReportServer\bin*-mappen för varje rapportserverinstans där *Aspose.Slides.ReportingServices.dll* är installerad — till exempel *C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer\bin*. [Installera manuellt](/slides/sv/reportingservices/install-manually/#find-the-report-server-folder) listar standardmapparna.
2. Se till att filen har ett av de namn som tillägget söker efter: *Aspose.Slides.ReportingServices.lic*, *Aspose.Slides.Reporting.Services.lic*, *Aspose.Slides.Product.Family.lic*, *Aspose.Total.ReportingServices.lic*, *Aspose.Total.Reporting.Services.lic*, *Aspose.Total.Product.Family.lic* eller *Aspose.Total.lic*.
3. Exportera någon rapport som en presentation. Om den inte innehåller ett vattenstämpel är licensen aktiv.

Tillägget söker också efter licensfilen i *%ProgramData%\Aspose\Slides* (vanligtvis *C:\ProgramData\Aspose\Slides*), så en kopia där räcker för alla instanser på maskinen.

**Licensierat läge**

När en giltig licensfil hittas innehåller exporterade presentationer ingen utvärderingsvattenstämpel.

![En rapport exporterad med en licens: ingen utvärderingsvattenstämpel](license-aspose-slides-for-reporting-services_2.png)

**Utvärderingsläge**

Utan licens lägger Aspose.Slides for Reporting Services till ett utvärderingsvattenstämpel i exporterade presentationer.

![En rapport exporterad i utvärderingsläge, med utvärderingsvattenstämpeln](license-aspose-slides-for-reporting-services_1.png)

{{% alert color="info" title="Obs" %}}
För att testa Aspose.Slides for Reporting Services utan begränsningar kan du begära en **30‑dagars tillfällig licens**. Se sidan [Hur man får en tillfällig licens](https://purchase.aspose.com/temporary-license) för mer information.
{{% /alert %}}