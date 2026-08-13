---
title: Perché non l'automazione
type: docs
weight: 40
url: /it/net/why-not-automation/
keywords:
- automazione
- Microsoft Office
- confronto
- sicurezza
- stabilità
- scalabilità
- funzionalità
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri perché l'automazione di Office è rischiosa per server e servizi, e vedi come Aspose.Slides offre una gestione delle presentazioni più sicura e veloce per PowerPoint e OpenDocument."
---
## **Introduzione**

Ci sono diversi motivi per cui i componenti Aspose sono un'alternativa migliore all'automazione. Alcuni dei motivi principali sono:

- Sicurezza
- Stabilità
- Scalabilità/Velocità
- Prezzo
- Funzionalità

Di seguito una spiegazione più dettagliata di ciascun punto chiave.

## **Domande importanti**

Ci sono due domande che sentiamo spesso in Aspose:

- I vostri prodotti richiedono l'installazione di Microsoft Office per funzionare?

La risposta breve e semplice è **NO**.

I componenti Aspose sono completamente indipendenti e non sono affiliati, autorizzati, sponsorizzati o in altro modo approvati da Microsoft Corporation.

- Perché dovremmo utilizzare i prodotti Aspose invece dell'Automazione di Microsoft Office?

Prima, ci sono i numerosi [vantaggi di cui benefici quando utilizzi Aspose.Slides](/slides/it/net/product-overview/).

Secondo, Microsoft stessa sconsiglia fortemente **l'uso** dell'Automazione di Office nei soluzioni software.

## **Sicurezza**
Di seguito una citazione diretta da un articolo Microsoft: 

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

I prodotti Aspose sono molto **sicuri**. I componenti Aspose girano nello stesso contesto utente di tutte le applicazioni ASP.NET (sotto l'utente ASPNET). Pertanto, i componenti Aspose **non** rappresentano un rischio per la sicurezza. Non consumano inoltre risorse di sistema critiche. Inoltre, quando un componente Aspose apre un documento, le macro non vengono eseguite automaticamente. I componenti Aspose sono stati costruiti per consentire agli sviluppatori di creare, manipolare e salvare file Office.

{{% alert color="info" %}} 

Nessuno dei rischi associati al pacchetto Microsoft Office si applica ai componenti Aspose.

{{% /alert %}} 

## **Stabilità**
Questo testo è una citazione diretta dall'articolo Microsoft precedentemente citato: 

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Poiché i componenti Aspose sono confezionati in un unico DLL, i loro utenti non devono mai installare parti o componenti aggiuntivi per farli funzionare. I componenti Aspose sono utilizzati solo da applicazioni .NET e non vi è alcuna porzione del codice del componente pensata per attendere una risposta umana. 

{{% alert color="info" %}} 

I componenti Aspose sono stati testati approfonditamente e confermati come molto stabili. I componenti Aspose sono usati da [companies](http://www.aspose.com/Corporate/Aspose/Customerlist.html) come **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, e molte altre organizzazioni leader in diversi settori e ambiti. 

{{% /alert %}} 

## **Scalabilità/Velocità**
Di seguito una citazione diretta da un articolo Microsoft: 

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

I componenti Aspose sono incredibilmente scalabili e fulminei. Le applicazioni Office non sono state progettate per essere utilizzate simultaneamente da centinaia o migliaia di utenti, mentre i componenti Aspose sono progettati proprio per questo. I nostri componenti sono una vera soluzione .NET. 

{{% alert color="info" %}} 

Le prestazioni dei componenti Aspose sono impeccabili su un singolo server (alimentando una singola applicazione) o su un web farm bilanciato (alimentando un'applicazione a livello aziendale).

{{% /alert %}} 

## **Prezzo**
Quando un'applicazione utilizza l'Automazione di Microsoft Office, è necessario acquistare una copia di Microsoft Office per ogni macchina che esegue l'app. Ci sono molte istanze in cui un'applicazione può dover creare o manipolare un file Office, ma il processo non richiede Microsoft Office. 

{{% alert color="info" %}} 

Aspose fornisce una licenza di ridistribuzione molto [cost-effective](https://purchase.aspose.com/) e priva di royalty che consente la distribuzione a un numero illimitato di utenti senza preoccupazioni di licenza. 

{{% /alert %}} 

Quando si creano applicazioni web, è importante ricordare che i componenti di Automazione di Microsoft Office non sono né prezzi né licenziati per soluzioni server-side. Pertanto, non esiste una buona soluzione di licenza per la distribuzione di applicazioni web che utilizzano componenti Microsoft Office. Aspose, al contrario, offre una soluzione molto [cost-effective](https://purchase.aspose.com/) anche per applicazioni basate su server.

## **Funzionalità**
I componenti Aspose forniscono tutto il necessario per gestire i file Office e molto di più. Li abbiamo progettati sulla base della nostra filosofia di aiutare gli sviluppatori a ottenere i risultati migliori con il minimo sforzo. 

{{% alert color="info" %}} 

A differenza dell'Automazione di Office, i componenti Aspose offrono molte funzioni potenti e che fanno risparmiare tempo. 

{{% /alert %}} 

Ad esempio, [Aspose.Cells](https://products.aspose.com/cells/net/) consente agli sviluppatori di importare dati da una **DataTable** o **DataView** direttamente in un file Excel. [Aspose.Words](https://products.aspose.com/words/net/) fornisce una funzionalità simile che permette agli sviluppatori di popolare un documento Word (cioè Mail Merge) direttamente da qualsiasi oggetto dati .NET. [Every component](https://products.aspose.com/total/net/) della famiglia Aspose offre il proprio set unico e potente di funzionalità. 

La parte migliore dell'acquistare un componente Aspose è avere accesso ai nostri team di sviluppo. Ad esempio, se utilizzi oggetti di Automazione di Office e hai bisogno di funzionalità specifiche, le probabilità di vederle aggiunte sono molto, molto basse. Tuttavia, le cose sono diverse con i componenti Aspose. 

{{% alert color="info" %}} 

I nostri team di sviluppo comprendono che se esiste una funzionalità di cui la tua azienda ha bisogno, è probabile che altre aziende ne abbiano bisogno allo stesso modo. Sebbene sappiamo di non poter implementare ogni funzionalità richiesta, ci impegniamo ad aggiungere il maggior numero possibile di funzionalità basate sul feedback dei nostri clienti. 

{{% /alert %}} 

I nostri team sono sempre aperti e flessibili nel fornire assistenza—e questo è il motivo per cui i componenti Aspose sono cresciuti fino a diventare così potenti. 

## **Conclusione**
{{% alert color="info" %}} 

Sebbene questo articolo abbia trattato alcuni dei punti chiave sul perché i componenti Aspose siano una scelta migliore rispetto all'Automazione di Office, devi capire che ci sono molti, molti altri vantaggi. Abbiamo solo mostrato alcune delle principali ragioni. 

Inoltre, tutti i prodotti e componenti Aspose offrono una [Evaluation Version](https://downloads.aspose.com/slides/it/net) senza rischi e senza obblighi. Ti invitiamo a sfruttare la versione di valutazione per vedere cosa Aspose può fare per le tue applicazioni o per il tuo business. 

{{% /alert %}}