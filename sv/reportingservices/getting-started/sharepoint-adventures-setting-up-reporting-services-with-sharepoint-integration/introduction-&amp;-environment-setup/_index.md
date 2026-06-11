---
title: Introduktion &amp; Miljöuppsättning
type: docs
weight: 10
url: /sv/reportingservices/introduction-&amp;-environment-setup/
---
{{% alert color="primary" %}}

Det har tidigare funnits frågor om Aspose.Slides för Reporting Services‑integration med SharePoint. I den här artikeln fokuserar vi på SharePoint 2010. Det förutsätts att en redan har en SharePoint‑farmmiljö upprättad. Exemplen vi kommer att följa i den här artikeln är en fullständig SharePoint‑molnmiljö, men stegen är liknande för en SharePoint Foundation‑server. Innan vi fortsätter, låt oss börja med lite viktig dokumentation som du kan använda som referens när du gör detta:

- [Overview of Reporting Services and SharePoint Technology Integration](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Configuring Reporting Services for SharePoint 2010 Integration](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}}
#### **Miljöuppsättning**
Den konfiguration vi kommer att ha består av **4 servrar**. Det inkluderar en **Domain Controller**, en **SQL Server**, en **SharePoint Server** och en server för **Reporting Services**. Du kan välja att ha SharePoint och Reporting Services på samma maskin.