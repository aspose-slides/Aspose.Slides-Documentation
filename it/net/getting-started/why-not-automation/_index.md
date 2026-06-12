---
title: "Perché non l'automazione"
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
description: "Scopri perché l'automazione di Office è rischiosa per server e servizi, e scopri come Aspose.Slides offre una gestione delle presentazioni più sicura e veloce per PowerPoint e OpenDocument."
---
## **Introduzione**

Ci sono diversi motivi per cui i componenti Aspose sono un’alternativa migliore all'automazione. Alcuni dei motivi principali sono:

- Sicurezza
- Stabilità
- Scalabilità/Velocità
- Prezzo
- Caratteristiche

Di seguito trovi una spiegazione più dettagliata di ciascun punto chiave.

## **Domande importanti**

Ci sono due domande che sentiamo spesso in Aspose:

- I vostri prodotti richiedono l'installazione di Microsoft Office per poter funzionare?

La risposta breve e semplice è **NO**.

I componenti Aspose sono completamente indipendenti e non sono affiliati, autorizzati, sponsorizzati o in altro modo approvati da Microsoft Corporation.

- Perché dovremmo utilizzare i prodotti Aspose invece di Microsoft Office Automation?

In primo luogo, ci sono molti [i vantaggi di cui godi quando usi Aspose.Slides](/slides/it/net/product-overview/).

In secondo luogo, Microsoft stessa **sconsiglia vivamente** l'uso di Office Automation da soluzioni software.

## **Sicurezza**
Il seguente è un estratto diretto da un articolo Microsoft:

> "Le applicazioni Office non sono mai state progettate per l'uso lato server e, pertanto, non tengono conto dei problemi di sicurezza affrontati dai componenti distribuiti. Office non autentica le richieste in ingresso e non ti protegge dall'esecuzione involontaria di macro, né dall'avvio di un altro server che potrebbe eseguire macro, dal tuo codice lato server. Non aprire file caricati sul server da un Web anonimo! In base alle impostazioni di sicurezza impostate per ultime, il server può eseguire macro con il contesto di un Amministratore o del Sistema con privilegi completi, compromettendo la tua rete! Inoltre, Office utilizza molti componenti client‑side (come Simple MAPI, WinInet, MSDAIPP) che possono memorizzare nella cache le informazioni di autenticazione del client per velocizzare l'elaborazione. Se Office viene automatizzato lato server, un'istanza può servire più di un client e, poiché le informazioni di autenticazione sono state memorizzate nella cache per quella sessione, è possibile che un client utilizzi le credenziali memorizzate di un altro client, ottenendo così permessi di accesso non concessi impersonando altri utenti."

I prodotti Aspose sono molto **sicuri**. I componenti Aspose vengono eseguiti nello stesso contesto utente di tutte le applicazioni ASP.NET (sotto l'utente ASPNET). Pertanto, i componenti Aspose **non** rappresentano un rischio per la sicurezza. Inoltre, non consumano risorse di sistema critiche. Inoltre, quando un componente Aspose apre un documento, le macro non vengono eseguite automaticamente. I componenti Aspose sono stati creati per consentire agli sviluppatori di creare, manipolare e salvare file Office. 

{{% alert color="primary" %}} 
Nessuno dei rischi associati al pacchetto Microsoft Office si applica ai componenti Aspose.
{{% /alert %}} 

## **Stabilità**
Questo testo è un estratto diretto dall'articolo Microsoft precedentemente citato:

> "Office 2000, Office XP e Office 2003 utilizzano la tecnologia Microsoft Windows Installer (MSI) per semplificare l'installazione e l'autoriparazione per l'utente finale. MSI introduce il concetto di \"installazione al primo utilizzo\", che consente di installare o configurare dinamicamente le funzionalità durante l'esecuzione (per il sistema, o più spesso per un singolo utente). In un ambiente lato server ciò rallenta le prestazioni e aumenta la probabilità che compaia una finestra di dialogo che richiede all'utente di approvare l'installazione o di fornire un disco di installazione appropriato. Sebbene sia progettato per aumentare la resilienza di Office come prodotto per l'utente finale, l'implementazione delle funzionalità MSI di Office è controproducente in un ambiente lato server. Inoltre, la stabilità di Office in generale non può essere garantita quando viene eseguito lato server perché non è stato progettato né testato per questo tipo di utilizzo. Utilizzare Office come componente di servizio su un server di rete può ridurre la stabilità di quella macchina e, di conseguenza, della rete nel suo complesso. Se prevedi di automatizzare Office lato server, cerca di isolare il programma su un computer dedicato che non possa influire su funzioni critiche e che possa essere riavviato secondo necessità."

Poiché i componenti Aspose sono confezionati in un unico DLL, i loro utenti non devono mai installare parti o componenti aggiuntivi per farli funzionare. I componenti Aspose sono utilizzati solo da applicazioni .NET e non esiste alcuna parte del codice del componente progettata per attendere una risposta umana. 

{{% alert color="primary" %}} 
I componenti Aspose sono stati testati a fondo e confermati come molto stabili. I componenti Aspose sono usati da [aziende](http://www.aspose.com/Corporate/Aspose/Customerlist.html) come **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** e molte altre organizzazioni leader in diversi settori e ambiti. 
{{% /alert %}} 

## **Scalabilità/Velocità**
Il seguente è un estratto diretto da un articolo Microsoft:

> "I componenti lato server devono essere altamente ri‑entranti, componenti COM multithread con minimo overhead e alta capacità di elaborazione per più client. Le applicazioni Office sono quasi esattamente il contrario. Sono server di automazione non ri‑entranti, basati su STA, progettati per fornire funzionalità diversificate ma intensive in termini di risorse per un singolo client. Offrono poca scalabilità come soluzione lato server e hanno limiti fissi per elementi importanti, come la memoria, che non possono essere modificati tramite configurazione. Inoltre, utilizzano risorse globali (come file mappati in memoria, componenti aggiuntivi o template globali e server di automazione condivisi), il che può limitare il numero di istanze che possono essere eseguite contemporaneamente e causare condizioni di race se configurati in un ambiente multi‑client. Gli sviluppatori che prevedono di eseguire più di un'istanza di qualsiasi applicazione Office contemporaneamente devono considerare il pooling o la serializzazione dell'accesso all'applicazione Office per evitare potenziali deadlock o corruzione dei dati."

I componenti Aspose sono incredibilmente scalabili e velocissimi. Le applicazioni Office non sono state progettate per essere utilizzate simultaneamente da centinaia o migliaia di utenti, ma i componenti Aspose sono progettati proprio per questo. I nostri componenti sono una vera soluzione .NET. 

{{% alert color="primary" %}} 
Le prestazioni dei componenti Aspose sono impeccabili su un singolo server (alimentando una singola applicazione) o su una web‑form bilanciata (alimentando un'applicazione aziendale). 
{{% /alert %}} 

## **Prezzo**
Quando un’applicazione utilizza Microsoft Office Automation, è necessario acquistare una copia di Microsoft Office per ogni macchina che esegue l’app. Esistono molte istanze in cui un’applicazione deve creare o manipolare un file Office, ma il processo non richiede Microsoft Office. 

{{% alert color="primary" %}} 
Aspose offre una licenza di distribuzione molto [costo‑efficace](https://purchase.aspose.com/) e priva di royalty, che consente il deployment su un numero illimitato di utenti senza preoccupazioni di licenza. 
{{% /alert %}} 

Quando si creano applicazioni web‑based, è importante ricordare che i componenti Microsoft Office Automation non sono né prezzati né licenziati per soluzioni lato server. Pertanto, non esiste una buona soluzione di licenza per il deployment di applicazioni web che utilizzano componenti Microsoft Office. Aspose, invece, fornisce una soluzione molto [costo‑efficace](https://purchase.aspose.com/) anche per le applicazioni basate su server.

## **Caratteristiche**
I componenti Aspose forniscono tutto il necessario per gestire i file Office e molto di più. Li abbiamo progettati secondo la nostra filosofia di aiutare gli sviluppatori a ottenere i risultati migliori con il minimo sforzo. 

{{% alert color="primary" %}} 
Diversamente da Office Automation, i componenti Aspose offrono molte funzioni potenti e che fanno risparmiare tempo. 
{{% /alert %}} 

Ad esempio, [Aspose.Cells](https://products.aspose.com/cells/net/) consente agli sviluppatori di importare dati da una **DataTable** o **DataView** direttamente in un file Excel. [Aspose.Words](https://products.aspose.com/words/net/) fornisce una funzionalità simile che permette di popolare un documento Word (cioè Mail Merge) direttamente da qualsiasi oggetto dati .NET. [Ogni componente](https://products.aspose.com/total/net/) della famiglia Aspose offre il proprio set unico e potente di funzionalità. 

Il miglior aspetto dell’acquisto di un componente Aspose è avere accesso ai nostri team di sviluppo. Per esempio, se usi oggetti Office Automation e hai bisogno di certe funzionalità, le probabilità di vedere quelle funzionalità aggiunte sono molto, molto basse. Tuttavia, le cose sono diverse con i componenti Aspose. 

{{% alert color="primary" %}} 
I nostri team di sviluppo comprendono che se la tua azienda ha bisogno di una funzionalità, è probabile che anche altre imprese la richiedano. Pur sapendo di non poter implementare ogni funzionalità richiesta, ci impegniamo ad aggiungere quante più funzionalità possibile in base al feedback dei nostri clienti. 
{{% /alert %}} 

I nostri team sono sempre aperti e flessibili nell’offrire assistenza—e questo è il motivo per cui i componenti Aspose sono cresciuti fino a diventare così potenti.

## **Conclusione**
{{% alert color="primary" %}} 
Sebbene questo articolo abbia trattato alcuni dei punti chiave per cui i componenti Aspose sono una scelta migliore rispetto a Office Automation, devi sapere che i benefici sono molti, molti più. Abbiamo presentato solo alcuni dei principali vantaggi. 

Inoltre, tutti i prodotti e i componenti Aspose offrono una [Versione di valutazione](https://downloads.aspose.com/slides/it/net) senza rischi e senza obblighi. Ti invitiamo a sfruttare la valutazione per vedere cosa Aspose può fare per le tue applicazioni o per il tuo business. 
{{% /alert %}}