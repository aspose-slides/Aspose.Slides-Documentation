---
title: Úvod a nastavení prostředí
type: docs
weight: 10
url: /cs/reportingservices/introduction-and-environment-setup/
---
{{% alert color="primary" %}} 

V minulosti se objevily dotazy ohledně integrace Aspose.Slides pro Reporting Services se SharePointem. V tomto článku se budeme soustředit na SharePoint 2010. Předpokládá se, že již máte nastavené prostředí SharePoint Farm. Příklady, které v tomto článku použijeme, budou ve full SharePoint Cloud, ale kroky budou podobné pro SharePoint Foundation Server. Než budeme pokračovat, začněme s klíčovou dokumentací, kterou můžete použít jako referenci:

- [Přehled integrace Reporting Services a SharePoint Technology](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Konfigurace Reporting Services pro integraci se SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Nastavení prostředí**
Nastavení, které budeme mít, se skládá ze **4 serverů**. To zahrnuje **Domain Controller**, **SQL Server**, **SharePoint Server** a server pro **Reporting Services**. Můžete si zvolit mít SharePoint a Reporting Services na stejném serveru.