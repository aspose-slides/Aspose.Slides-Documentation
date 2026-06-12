---
title: Introduzione e Configurazione dell'Ambiente
type: docs
weight: 10
url: /it/reportingservices/introduction-and-environment-setup/
---
{{% alert color="primary" %}} 

Ci sono state richieste in passato riguardo all'integrazione di Aspose.Slides per Reporting Services con SharePoint. In questo articolo ci concentreremo su SharePoint 2010. Si presume che si disponga già di un ambiente SharePoint Farm configurato. Gli esempi che seguirà in questo articolo saranno basati su un SharePoint Cloud completo, ma i passaggi saranno simili per un SharePoint Foundation Server. Prima di procedere, iniziamo con qualche documentazione chiave che potete usare come riferimento quando lo farete: 

- [Panoramica dell'integrazione di Reporting Services e SharePoint Technology](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))  
- [Configurazione di Reporting Services per l'integrazione con SharePoint 2010](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Configurazione dell'ambiente**
La configurazione che avremo consiste in **4 server**. Include un **Domain Controller**, un **SQL Server**, un **SharePoint Server** e un server per **Reporting Services**. È possibile scegliere di avere SharePoint e Reporting Services sulla stessa macchina.