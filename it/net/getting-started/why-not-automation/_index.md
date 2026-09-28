---
title: Perché non automatizzare
type: docs
weight: 170
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
description: "Scopri perché l'automazione di Office è rischiosa per server e servizi, e vedi come Aspose.Slides offre una elaborazione di presentazioni più sicura e veloce per PowerPoint e OpenDocument."
---
## **Introduzione**

Ci sono diversi motivi per cui i componenti Aspose sono un'alternativa migliore all'automazione. Alcuni dei motivi principali sono:

- Sicurezza
- Stabilità
- Scalabilità/Velocità
- Prezzo
- Funzionalità

Di seguito è una spiegazione più dettagliata di ciascun punto chiave.

## **Domande importanti**

Ci sono due domande che sentiamo spesso su Aspose:

- I tuoi prodotti richiedono l'installazione di Microsoft Office per funzionare?

La risposta breve e semplice è **NO**.

I componenti Aspose sono completamente indipendenti e non sono affiliati a, autorizzati da, sponsorizzati da, o altrimenti approvati da Microsoft Corporation.

- Perché dovremmo utilizzare i prodotti Aspose invece dell'automazione di Microsoft Office?

First, there are many [vantaggi che ottieni quando usi Aspose.Slides](/slides/it/net/product-overview/).

Secondo, Microsoft stessa consiglia fortemente **di non utilizzare** l'automazione di Office da soluzioni software.

## **Sicurezza**
La seguente è una citazione diretta da un articolo di Microsoft:

> "Le applicazioni di Office non sono mai state concepite per l'uso lato server e, pertanto, non tengono conto dei problemi di sicurezza affrontati dai componenti distribuiti. Office non autentica le richieste in ingresso e non ti protegge dall'esecuzione involontaria di macro, né dall'avvio di un altro server che potrebbe eseguire macro, dal tuo codice lato server. Non aprire i file caricati sul server da un Web anonimo! In base alle impostazioni di sicurezza impostate per ultime, il server può eseguire macro con un contesto Administrator o System con privilegi completi e compromettere la tua rete! Inoltre, Office utilizza molti componenti lato client (come Simple MAPI, WinInet, MSDAIPP) che possono memorizzare nella cache le informazioni di autenticazione del client per velocizzare l'elaborazione. Se Office viene automatizzato lato server, un'istanza può servire più di un client e, poiché le informazioni di autenticazione sono state memorizzate nella cache per quella sessione, è possibile che un client utilizzi le credenziali memorizzate di un altro client, ottenendo così permessi di accesso non concessi impersonando altri utenti."

I prodotti Aspose sono molto **sicuri**. I componenti Aspose vengono eseguiti nello stesso contesto utente di tutte le applicazioni ASP.NET (sotto l'utente ASPNET). Pertanto, i componenti Aspose **non** costituiscono un rischio per la sicurezza. Non consumano inoltre risorse di sistema critiche. Inoltre, quando un componente Aspose apre un documento, le macro non vengono eseguite automaticamente. I componenti Aspose sono stati creati per consentire agli sviluppatori di creare, manipolare e salvare file Office.

{{% alert color="info" title="Note" %}}
Nessuno dei rischi associati al pacchetto Microsoft Office si applica ai componenti Aspose.
{{% /alert %}}

## **Stabilità**
Il seguente è una citazione diretta dal precedente articolo Microsoft:

> "Office 2000, Office XP e Office 2003 utilizzano la tecnologia Microsoft Windows Installer (MSI) per semplificare l'installazione e l'autoriparazione per l'utente finale. MSI introduce il concetto di \"installazione al primo utilizzo\", che consente alle funzionalità di essere installate o configurate dinamicamente a runtime (per il sistema, o più spesso per un particolare utente). In un ambiente lato server ciò rallenta le prestazioni e aumenta la probabilità che compaia una finestra di dialogo che richiede all'utente di approvare l'installazione o di fornire un disco di installazione appropriato. Sebbene sia progettato per aumentare la resilienza di Office come prodotto per l'utente finale, l'implementazione delle capacità MSI di Office è controproducente in un ambiente lato server. Inoltre, la stabilità di Office in generale non può essere garantita quando viene eseguita lato server perché non è stata progettata o testata per questo tipo di utilizzo. Utilizzare Office come componente di servizio su un server di rete può ridurre la stabilità di quella macchina e, di conseguenza, della rete nel suo complesso. Se prevedi di automatizzare Office lato server, tenta di isolare il programma su un computer dedicato che non possa influire su funzioni critiche e che possa essere riavviato secondo necessità."

Poiché i componenti Aspose sono confezionati in un unico DLL, i loro utenti non devono mai installare parti o componenti aggiuntivi per farli funzionare. I componenti Aspose sono utilizzati esclusivamente dalle applicazioni .NET e non esiste alcuna porzione del codice del componente progettata per attendere una risposta umana.

{{% alert color="info" title="Note" %}}
I componenti Aspose sono stati testati accuratamente e confermati come molto stabili. I componenti Aspose sono utilizzati da [aziende](https://about.aspose.com/customers/) come **Bank of America** e molte altre organizzazioni leader in diversi settori e campi.
{{% /alert %}}

## **Scalabilità/Velocità**
La seguente è una citazione diretta da un articolo Microsoft:

> "I componenti lato server devono essere componenti COM altamente ri-entranti, multithread, con minimo overhead e elevata capacità di gestione per più client. Le applicazioni Office sono in quasi tutti gli aspetti l'esatto opposto. Sono server di automazione basati su STA, non ri-entranti, progettati per fornire funzionalità diversificate ma ad alta intensità di risorse per un singolo client. Offrono poca scalabilità come soluzione lato server e hanno limiti fissi su elementi importanti, come la memoria, che non possono essere modificati tramite configurazione. Inoltre, utilizzano risorse globali (come file mappati in memoria, componenti aggiuntivi o modelli globali e server di automazione condivisi), che possono limitare il numero di istanze che possono essere eseguite simultaneamente e portare a condizioni di gara se configurati in un ambiente multi-client. Gli sviluppatori che prevedono di eseguire più di un'istanza di qualsiasi applicazione Office contemporaneamente devono considerare il pooling o la serializzazione dell'accesso all'applicazione Office per evitare potenziali deadlock o corruzione dei dati."

I componenti Aspose sono incredibilmente scalabili e rapidissimi. Le applicazioni Office non sono state progettate per essere utilizzate contemporaneamente da centinaia o migliaia di utenti, ma i componenti Aspose sono progettati proprio per questo. I nostri componenti sono una vera soluzione .NET.

{{% alert color="info" title="Note" %}}
La performance dei componenti Aspose è impeccabile su un singolo server (alimentando una singola applicazione) o su una forma web bilanciata (alimentando un'applicazione aziendale su larga scala).
{{% /alert %}}

## **Prezzo**
Quando un'applicazione utilizza l'automazione di Microsoft Office, è necessario acquistare una copia di Microsoft Office per ogni macchina che esegue l'applicazione. Ci sono molti casi in cui un'applicazione deve creare o manipolare un file Office, ma il processo non richiede Microsoft Office.

{{% alert color="info" title="Note" %}}
Aspose fornisce una licenza di ridistribuzione molto [economica](https://purchase.aspose.com/) e priva di royalty che consente la distribuzione a un numero illimitato di utenti senza preoccupazioni di licenza.
{{% /alert %}}

Quando si creano applicazioni web, è importante ricordare che i componenti di automazione di Microsoft Office non sono né prezzati né concessi in licenza per soluzioni lato server. Pertanto, non esiste una buona soluzione di licenza per la distribuzione di applicazioni web che utilizzano i componenti Microsoft Office. Aspose, invece, offre una soluzione molto [economica](https://purchase.aspose.com/) per le applicazioni basate su server.

## **Funzionalità**
I componenti Aspose forniscono tutto il necessario per gestire i file Office e molto di più. Li abbiamo progettati sulla base della nostra filosofia di aiutare gli sviluppatori a ottenere i migliori risultati possibili con il minor sforzo.

{{% alert color="info" title="Note" %}}
A differenza dell'automazione di Office, i componenti Aspose offrono molte funzioni potenti e che fanno risparmiare tempo.
{{% /alert %}}

Ad esempio, [Aspose.Cells](https://products.aspose.com/cells/net/) consente agli sviluppatori di importare dati da una **DataTable** o **DataView** direttamente in un file Excel. [Aspose.Words](https://products.aspose.com/words/net/) offre una funzionalità simile che permette agli sviluppatori di popolare un documento Word (cioè, Mail Merge) direttamente da qualsiasi oggetto dati .NET. [Ogni componente](https://products.aspose.com/total/net/) della famiglia Aspose offre il proprio insieme di funzionalità uniche e potenti.

Il vantaggio principale nell'acquistare un componente Aspose è ottenere l'accesso ai nostri team di sviluppo. Ad esempio, se utilizzi oggetti di automazione Office e hai bisogno di determinate funzionalità, le probabilità di vederle aggiunte sono molto, molto basse. Tuttavia, la situazione è diversa con i componenti Aspose.

{{% alert color="info" title="Note" %}}
I nostri team di sviluppo comprendono che se esiste una funzionalità di cui la tua azienda ha bisogno, è probabile che altre aziende la richiedano. Sebbene sappiamo che non possiamo implementare ogni funzionalità richiesta, ci impegniamo ad aggiungere il maggior numero possibile di funzionalità basandoci sul feedback dei nostri clienti.
{{% /alert %}}

I nostri team sono sempre aperti e flessibili nell'offrire assistenza—e questo è il motivo per cui i componenti Aspose sono cresciuti fino a diventare così potenti.

## **Conclusione**
{{% alert color="info" title="Note" %}}
Anche se questo articolo ha trattato alcuni dei punti chiave del perché i componenti Aspose sono una scelta migliore rispetto all'automazione di Office, devi capire che ci sono molti, molti altri vantaggi. Abbiamo coperto solo alcuni dei principali benefici.

Inoltre, tutti i prodotti e componenti Aspose offrono una [Versione di valutazione](https://releases.aspose.com/slides/net/) senza rischi e senza obblighi. Ti incoraggiamo a sfruttare la valutazione per vedere cosa Aspose può fare per le tue applicazioni o per il tuo business.
{{% /alert %}}