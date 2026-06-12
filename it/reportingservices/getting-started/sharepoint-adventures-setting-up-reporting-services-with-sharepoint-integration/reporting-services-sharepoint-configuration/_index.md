---
title: Configurazione di Reporting Services SharePoint
type: docs
weight: 50
url: /it/reportingservices/reporting-services-sharepoint-configuration/
---
{{% alert color="primary" %}} 

Ora che SharePoint è installato e configurato sul server RS e RS è impostato tramite il Reporting Services Configuration Manager, possiamo passare alla configurazione in Central Admin. RS 2008 R2 ha davvero semplificato questo processo. In passato era necessario eseguire un processo a 3 passaggi per farlo funzionare. Ora ne basta uno solo. 

Dobbiamo andare al sito Central Administrator e poi in General Application Settings. Verso il fondo vedremo Reporting Services. 

{{% /alert %}} 

![todo:image_alt_text](reporting-services-sharepoint-configuration_1.png)


**Figura 17**: Configurazione di SharePoint 

{{% alert color="primary" %}} 

Fare clic su **Reporting Services Integration**. 

{{% /alert %}} 
## **URL del servizio Web**
Forniremo l'URL per il Report Server che abbiamo trovato nel Reporting Services Configuration Manager. 
## **Modalità di autenticazione**
Selezioneremo anche una Modalità di autenticazione. Il seguente link MSDN spiega in dettaglio di cosa si tratta. 
[Security Overview for Reporting Services in SharePoint Integrated Mode](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb283324(v=sql.105)) 

In breve, se il tuo sito utilizza **Claims Authentication**, verrà sempre usata la Trusted Authentication indipendentemente da quanto scelto qui. Se vuoi trasmettere credenziali Windows, scegli Windows Authentication. Per Trusted Authentication, passeremo il token SPUser e non faremo affidamento sulle credenziali Windows. 

Dovrai usare Trusted Authentication anche se hai configurato i siti Classic Mode per NTLM e RS è impostato per NTLM. Kerberos sarebbe necessario per usare Windows Authentication e per trasmettere le credenziali alla tua origine dati. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_2.png)


**Figura 18**: Impostazione delle credenziali di Reporting Services Integration
## **Attiva funzionalità**
Questa opzione consente di attivare Reporting Services su tutte le raccolte di siti, oppure di scegliere su quali attivarlo. In pratica definisce quali siti potranno utilizzare Reporting Services. 
Una volta completato, dovrebbe comparire la figura seguente. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_3.png)


**Figura 19**: Integrazione riuscita di Reporting Services con l'ambiente SharePoint 

Tornando all'URL del Report Server mostrato nella Figura 14, dovremmo vedere qualcosa di simile alla figura seguente. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_4.png)


**Figura 20**: Verifica riuscita di Reporting Services con l'ambiente SharePoint 

{{% alert color="primary" %}} 

Se il tuo sito SharePoint è configurato per SSL, non apparirà in questo elenco. È un problema noto e non indica alcun malfunzionamento. I tuoi report dovrebbero comunque funzionare. 

{{% /alert %}} 

Ora siamo pronti a usare Reporting Services in SharePoint 2010. Come nella versione precedente, abbiamo una funzionalità (attivata quando configuriamo Reporting Services Integration) nella “Site Collection Feature”. Inoltre l'installazione ha aggiunto 3 tipi di contenuto da utilizzare nel nostro sito. Nella Figura 21 possiamo vedere 2 di questi tipi di contenuto aggiunti a una libreria documenti per creare un report personalizzato, come mostrato nella Figura 21. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_5.png)


**Figura 21**: Report Builder 

Il “**Reporter Builder**” è un ActiveX che dobbiamo scaricare sul server, come mostra la Figura 22. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_6.png)


**Figura 22**: Download e installazione di Report Builder 

Al termine del download, avviare il **“Report Builder”**. Ora siamo pronti a progettare il nostro primo report, come mostrato nella Figura 23. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_7.png)

**Figura 23**: Wizard di generazione di un nuovo report in Report Builder 

Dopo aver creato il report, possiamo salvarlo nella libreria documenti creata per inserire i report nel nostro SharePoint 2010. 


L'altro tipo di contenuto deve essere usato per creare connessioni condivise come origine dati e salvarle in una libreria documenti in SharePoint. Possiamo creare una libreria documenti, aggiungere questo tipo di contenuto e, successivamente, avere le connessioni disponibili per modificare l'origine dati dei report. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_8.png)


**Figura 24**: Esportazione riuscita del report sul Report Server