---
title: Configurazione di Reporting Services
type: docs
weight: 30
url: /it/reportingservices/setting-up-reporting-services/
---
{{% alert color="primary" %}} 

La nostra prima tappa sul server RS è il Reporting Services Configuration Manager. 

{{% /alert %}} 
## **Account di servizio**
Assicurati di capire quale account di servizio stai usando per Reporting Services. Se incontriamo problemi, potrebbero essere collegati all'account di servizio che stai usando. L'impostazione predefinita è Network Service. Ogni volta che distribuisco nuove versioni, utilizzo sempre account di dominio, perché è lì che è più probabile incontrare problemi. Per questa configurazione sul mio server, ho usato un account di dominio chiamato **RSService**. 
## **URL del servizio Web**
Dobbiamo configurare l'URL del servizio Web. Questa è la directory virtuale **ReportServer** (vdir) che ospita i servizi Web utilizzati da Reporting Services e con cui SharePoint comunicherà. A meno che tu non voglia personalizzare le proprietà della vdir (ad es. SSL, porte, intestazioni host, ecc…), dovresti poter semplicemente fare clic su Applica qui e tutto dovrebbe funzionare. 

![todo:image_alt_text](setting-up-reporting-services_1.png)

![todo:image_alt_text](setting-up-reporting-services_2.png)

**Figura 3**: Configurazione URL del servizio Web 

Una volta completato, dovresti vedere la figura seguente. 

![todo:image_alt_text](setting-up-reporting-services_3.png)

**Figura 4**: Configurazione riuscita dell'URL del servizio Web 
## **Database**
Dobbiamo creare il database del catalogo di Reporting Services. Può essere collocato su qualsiasi istanza di SQL 2008 o SQL 2008 R2 Database Engine. SQL11 funzionerebbe altrettanto bene, ma è ancora in BETA. Questa operazione creerà due database, **ReportServer** e **ReportServerTempDB**, per impostazione predefinita.  
L'altro passaggio importante è assicurarsi di scegliere **SharePoint Integrated** per il tipo di database. Una volta fatta questa scelta, non può più essere modificata. Consulta le Figure 5, 6 e 7 per riferimento. 

![todo:image_alt_text](setting-up-reporting-services_4.png)

**Figura 5**: Creazione del database del Report Server 

![todo:image_alt_text](setting-up-reporting-services_5.png)

**Figura 6**: Configurazione del server di database e del tipo di autenticazione 

![todo:image_alt_text](setting-up-reporting-services_6.png)

**Figura 7**: Configurazione del nome e della modalità del database 

Per le credenziali, questo è il modo in cui il Report Server comunicherà con il SQL Server. Qualsiasi account tu selezioni, avrà determinati diritti nel database del catalogo così come in alcuni dei database di sistema tramite il ruolo RSExecRole. MSDB è uno di questi database per l'uso delle sottoscrizioni, poiché utilizziamo SQL Agent. 

![todo:image_alt_text](setting-up-reporting-services_7.png)

**Figura 8**: Configurazione delle credenziali del database del Report Server 

Una volta completato, dovrebbe apparire la figura seguente. 

![todo:image_alt_text](setting-up-reporting-services_8.png)

**Figura 9**: Avanzamento per completare la configurazione del database del Report Server 
## **URL di Report Manager**
Possiamo saltare l'URL di Report Manager, poiché non viene utilizzato quando siamo in modalità SharePoint Integrated. SharePoint è il nostro frontend. Report Manager non funziona. 
## **Chiavi di crittografia**
Esegui il backup delle chiavi di crittografia e assicurati di sapere dove le conservi. Se ti trovi nella situazione di dover migrare o ripristinare il database, avrai bisogno di queste chiavi. 

![todo:image_alt_text](setting-up-reporting-services_9.png)

Questo è tutto per il Reporting Services Configuration Manager. Se navighi all'URL nella scheda URL del servizio Web, dovrebbe comparire qualcosa di simile alla figura seguente. 

![todo:image_alt_text](setting-up-reporting-services_10.png)

**Figura 12**: Accesso al Report Server dopo l'installazione 

Cosa è successo? SharePoint è installato sul mio WFE e ho terminato la configurazione di Reporting Services. In questo esempio, Reporting Services e SharePoint sono su macchine diverse. Se fossero sulla stessa macchina, non avresti visto questo errore. In pratica è necessario installare SharePoint sul server RS, il che abilita anche IIS.