---
title: "Introduzione & Configurazione dell'ambiente"
type: docs
weight: 10
url: /it/reportingservices/introduction-&amp;-environment-setup/
---
{{% alert color="primary" %}} 

In passato ci sono state richieste riguardo l'integrazione di Aspose.Slides per Reporting Services con SharePoint. In questo articolo ci concentreremo su SharePoint 2010. Si presume che sia già configurato un ambiente SharePoint Farm. Gli esempi che seguirà in questo articolo saranno in un SharePoint Cloud completo, ma i passaggi saranno simili per un server SharePoint Foundation. Prima di procedere, iniziamo con una documentazione chiave che puoi utilizzare come riferimento:

- [Panoramica dell'integrazione di Reporting Services e SharePoint Technology](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Configurazione di Reporting Services per l'integrazione con SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Configurazione dell'ambiente**
L'ambiente che utilizzeremo consiste in **4 server**. Include un **Domain Controller**, un **SQL Server**, un **SharePoint Server** e un server per **Reporting Services**. È possibile scegliere di avere SharePoint e Reporting Services sulla stessa macchina.