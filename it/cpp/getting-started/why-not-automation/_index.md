---
title: Perché non automatizzare
type: docs
weight: 50
url: /it/cpp/why-not-automation/
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
- C++
- Aspose.Slides
description: "Scopri perché l'automazione di Office è rischiosa per server e servizi, e vedi come Aspose.Slides offre una gestione delle presentazioni più sicura e veloce per PowerPoint e OpenDocument."
---
## **Introduzione**

Ci sono diversi motivi per cui i componenti Aspose sono un’alternativa migliore all’automazione. Alcuni dei motivi principali sono:

- Sicurezza
- Stabilità
- Scalabilità/Velocità
- Prezzo
- Funzionalità

Di seguito è una spiegazione più dettagliata di ciascun punto chiave.

## **Domande importanti**
- Perché i componenti Aspose sono un’opzione molto migliore rispetto all’automazione di Microsoft Office?

Ci sono due domande che sentiamo più spesso qui in Aspose :

- I vostri prodotti richiedono che Microsoft Office sia installato per funzionare?

La risposta breve e semplice è **NO**. Aspose e i componenti Aspose sono totalmente indipendenti e non sono affiliati, né autorizzati, sponsorizzati o altrimenti approvati da Microsoft Corporation.

- Perché dovremmo utilizzare i prodotti Aspose invece di utilizzare l’automazione di Microsoft Office?

La risposta più breve che possiamo dare è che ci sono molte ragioni, la principale delle quali è che *Microsoft stessa sconsiglia fortemente l’automazione di Office da soluzioni software: [Microsoft Article

## **Sicurezza**
Quanto segue è una citazione diretta dall’«Microsoft Article» sopra citato :

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

I prodotti Aspose sono molto sicuri. Pertanto, i componenti Aspose non costituiscono un rischio potenziale per risorse di sistema vitali. Inoltre, quando un documento è aperto da un componente Aspose, le macro non vengono eseguite automaticamente. I componenti Aspose sono stati costruiti con l’obiettivo di consentire agli sviluppatori di creare, modificare e salvare file Office. Nessuno dei rischi associati al pacchetto Microsoft Office è intrinseco ai componenti Aspose.

## **Stabilità**
Quanto segue è una citazione diretta dall’«Microsoft Article» sopra citato :

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

Poiché i componenti Aspose sono confezionati in un unico DLL, non sarà mai necessario installare parti aggiuntive per farli funzionare. I componenti Aspose sono utilizzati solo da applicazioni C++ e non contengono codice progettato per attendere una risposta umana. I componenti Aspose sono stati testati approfonditamente e sono estremamente stabili. I componenti Aspose sono utilizzati da [Aziende](https://about.aspose.com/customers) come **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** e molte altre.

## **Scalabilità/Velocità**
Quanto segue è una citazione diretta dall’«Microsoft Article» sopra citato :

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

I componenti Aspose sono altamente scalabili e velocissimi. Le applicazioni Office non sono state progettate per essere utilizzate contemporaneamente da centinaia o migliaia di utenti. Tuttavia, i componenti Aspose sono pensati proprio per questo. I nostri componenti sono una vera soluzione C++ e funzionano perfettamente sia su un singolo server, alimentando una singola applicazione, sia su un Web Form bilanciato che supporta un’applicazione aziendale estesa.

## **Prezzo**
Quando un’applicazione utilizza l’automazione di Microsoft Office, è necessario acquistare una copia di Microsoft Office per ogni macchina su cui l’applicazione viene eseguita. Molte volte un’applicazione può dover creare o manipolare un file Office senza richiedere all’utente di possedere Microsoft Office. Aspose offre una licenza molto **Conveniente**(https://purchase.aspose.com/) e royalty‑free che consente la distribuzione a un numero illimitato di utenti senza preoccupazioni di licenza. Quando si creano applicazioni web è importante sapere che i componenti di automazione di Microsoft Office non hanno un prezzo né una licenza per soluzioni server‑side; quindi non esiste una soluzione di licenza adeguata per distribuire applicazioni web che utilizzano i componenti Microsoft Office. Aspose offre una soluzione molto **Conveniente**(https://purchase.aspose.com/) anche per applicazioni basate su server.

## **Funzionalità**
I componenti Aspose forniscono tutto il necessario per gestire i file Office e molto di più. Sono progettati secondo la filosofia di permettere agli sviluppatori di ottenere i migliori risultati con il minimo sforzo. Diversamente dall’automazione di Office, i componenti Aspose offrono molte funzioni potenti e che fanno risparmiare tempo. Per esempio, [Aspose.Cells](https://products.aspose.com/cells/cpp/) consente agli sviluppatori di importare dati da un **DataTable** o **DataView** direttamente in un file Excel. [Aspose.Words](https://products.aspose.com/words/net/) offre una funzione simile che permette di popolare un documento Word (Mail Merge) direttamente da qualsiasi oggetto dati C++. [Ogni Componente](https://products.aspose.com/total/cpp/) della famiglia Aspose offre il proprio set di funzionalità uniche e potenti. La parte migliore dell’acquistare un componente Aspose è avere accesso ai nostri team di sviluppo. I nostri team sanno che se una funzionalità è necessaria alla tua azienda, molto probabilmente è necessaria anche ad altre. Sebbene non tutte le richieste possano essere implementate, i nostri team cercano di essere molto aperti e flessibili nell’offrire assistenza. Questo approccio ha aiutato i componenti Aspose a diventare così potenti. Se ci sono funzionalità aggiuntive di cui hai bisogno dagli oggetti di automazione Office, le probabilità che vengano aggiunte sono molto, molto basse.

## **Conclusione**
{{% alert color="primary" %}} 

Mentre questo articolo ha trattato molti dei punti chiave per cui i componenti Aspose sono una scelta migliore rispetto all’automazione di Office, ce ne sono molti altri. Questo articolo si concentra principalmente sui punti più importanti. Tutti i diversi componenti Aspose offrono una versione di valutazione senza rischi e senza obblighi [Versione di valutazione](https://downloads.aspose.com/slides/it/cpp). Ti invitiamo a sfruttare questa [Valutazione](https://downloads.aspose.com/slides/it/cpp) per vedere meglio cosa Aspose può fare per le tue applicazioni. 
{{% /alert %}}