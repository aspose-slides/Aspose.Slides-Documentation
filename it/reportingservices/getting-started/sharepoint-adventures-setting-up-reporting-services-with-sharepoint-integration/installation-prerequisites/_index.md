---
title: Prerequisiti di installazione
type: docs
weight: 20
url: /it/reportingservices/installation-prerequisites/
---
{{% alert color="primary" %}} 

I seguenti requisiti devono essere soddisfatti prima di procedere con l'installazione. 

{{% /alert %}} 
## **Reporting Services Add‑In per SharePoint**
Il **Reporting Services Add‑In per SharePoint** è uno dei componenti chiave per far funzionare correttamente l'integrazione. L'Add‑In deve essere installato su uno qualsiasi dei **Web Front End (WFE)** presenti nella tua farm di SharePoint insieme al server Central Admin. Una delle novità con SQL 2008 R2 e SharePoint 2010 è che l'Add‑In 2008 R2 è ora un prerequisito per l'installazione di SharePoint. Questo significa che l'Add‑In RS verrà installato automaticamente quando avvierai l'installazione di SharePoint. È stato mostrato e evidenziato nella figura sottostante. Questo evita molti problemi riscontrati con SP 2007 e RS 2008 durante l'installazione dell'Add‑In. 

![todo:image_alt_text](installation-prerequisites_1.png)


**Figura 1**: Reporting Services Add‑In per SharePoint 
## **Autenticazione di SharePoint**
Prima di approfondire gli aspetti dell'integrazione RS, è importante considerare come configuri il tuo **Sito** nella farm di SharePoint. In particolare, come imposti l'autenticazione per il sito; se sarà **Classic** o **Claims**. Questa scelta è importante fin dall'inizio. Non credo sia possibile modificare questa opzione una volta impostata; se lo si può fare, non sarebbe un processo semplice. 

{{% alert color="primary" %}} 

Reporting Services 2008 R2 NON è compatibile con Claims 

{{% /alert %}} 

Anche se scegli il sito SharePoint per utilizzare **Claims**, Reporting Services di per sé non è compatibile con Claims. Ciò influisce sul funzionamento dell'autenticazione con Reporting Services. Qual è quindi la differenza dal punto di vista di Reporting Services? Dipende dal fatto che tu voglia inoltrare le credenziali utente al datasource. 

***Classic*** ‑ Può utilizzare Kerberos e inoltrare le credenziali dell'utente al datasource di back‑end (sarà necessario usare Kerberos per questo). 

***Claims*** ‑ Viene usato un token Claims e non un token Windows. RS userà sempre Trusted Authentication in questo scenario e avrà accesso solo al token SPUser. Dovrai memorizzare le tue credenziali all'interno del datasource. 

Per ora, ci concentriamo solo sulla configurazione di RS. A questo punto SharePoint è installato nella SharePoint Box e configurato con un **Sito di autenticazione Classic** sulla **porta 80**. Inoltre, sul server RS ho **appena installato Reporting Services** e basta.