---
title: Úvod &amp; nastavení prostředí
type: docs
weight: 10
url: /cs/reportingservices/introduction-&amp;-environment-setup/
---
{{% alert color="primary" %}}

V minulosti se objevily dotazy ohledně integrace Aspose.Slides pro Reporting Services se SharePoint. V tomto článku se zaměříme na SharePoint 2010. Předpokládá se, že máte již nastavené prostředí SharePoint Farm. Příklady, které v tomto článku použijeme, budou založeny na plné instalaci SharePoint Cloud, ale kroky budou podobné pro SharePoint Foundation Server. Před pokračováním si projděme některou klíčovou dokumentaci, kterou můžete použít jako referenci:

- [Přehled integrace Reporting Services a SharePoint Technology](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Konfigurace Reporting Services pro integraci se SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}}
#### **Nastavení prostředí**
Nastavení bude zahrnovat **4 servery**. Patří sem **Domain Controller**, **SQL Server**, **SharePoint Server** a server pro **Reporting Services**. Můžete zvolit, aby SharePoint a Reporting Services běžely na stejném serveru.