---
title: Introduktion och miljöuppsättning
type: docs
weight: 10
url: /sv/reportingservices/introduction-and-environment-setup/
---
{{% alert color="primary" %}}

Det har tidigare funnits förfrågningar om Aspose.Slides för Reporting Services-integration med SharePoint. I den här artikeln kommer vi att fokusera på SharePoint 2010. Det antas att man redan har en SharePoint-farmmiljö konfigurerad. Exemplen som vi kommer att följa i den här artikeln är en komplett SharePoint-moln, men stegen kommer att vara liknande för en SharePoint Foundation-server. Innan vi fortsätter, låt oss börja med lite viktig dokumentation som du kan använda som referens när du gör detta:

- [Översikt av Reporting Services och SharePoint-teknikintegration](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Konfigurering av Reporting Services för SharePoint 2010-integration](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}}
#### **Miljöuppsättning**
Inställningen vi kommer att ha består av **4 servrar**. Det inkluderar en **Domain Controller**, en **SQL Server**, en **SharePoint Server** och en server för **Reporting Services**. Du kan välja att ha SharePoint och Reporting Services på samma maskin.