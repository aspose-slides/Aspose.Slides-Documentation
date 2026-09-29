---
title: Perché non automatizzare
type: docs
weight: 170
url: /it/java/why-not-automation/
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
- Java
- Aspose.Slides
description: "Scopri perché l'automazione di Office è rischiosa per server e servizi, e vedi come Aspose.Slides offre una modalità di elaborazione delle presentazioni più sicura e veloce per PowerPoint e OpenDocument."
---
## **Introduzione**

Ci sono diversi motivi per cui i componenti Aspose rappresentano un'alternativa migliore all'automazione. Alcuni dei motivi principali sono:

- Sicurezza
- Stabilità
- Scalabilità/Velocità
- Prezzo
- Funzionalità

Di seguito è una spiegazione più dettagliata di ciascun punto chiave.

## **Domande importanti**

Ci sono due domande che sentiamo spesso in Aspose:

- I vostri prodotti richiedono l'installazione di Microsoft Office per funzionare?

La risposta breve e semplice è **NO**.

- Perché dovremmo usare i prodotti Aspose invece dell'Automazione di Microsoft Office?

Prima, ci sono molti [i vantaggi che ottieni quando usi Aspose.Slides](/slides/it/java/product-overview/).

Secondo, Microsoft stessa sconsiglia fortemente **l'uso** dell'Automazione di Office nei software.

## **Sicurezza**

The following is a direct quote from a Microsoft Article:

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

I prodotti Aspose sono molto sicuri. I componenti Aspose non rappresentano un rischio potenziale per le risorse vitali del sistema. Inoltre, quando un documento viene aperto da un componente Aspose, le macro non vengono eseguite automaticamente. I componenti Aspose sono stati costruiti con l'obiettivo di consentire agli sviluppatori di creare, manipolare e salvare file Office. Nessuno dei rischi associati al pacchetto Microsoft Office è intrinseco ai componenti Aspose.

## **Stabilità**
The following is a direct quote from a Microsoft Article:

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

I componenti Aspose sono stati testati a fondo e sono estremamente stabili. I componenti Aspose sono utilizzati da [companies](https://about.aspose.com/customers/) come **Bank of America** e molti altri.

## **Scalabilità/Velocità**
The following is a direct quote from a Microsoft Article:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.*


I componenti Aspose sono altamente scalabili e rapidissimi. Le applicazioni Office non sono state progettate per essere utilizzate simultaneamente da centinaia o migliaia di utenti. Tuttavia, i componenti Aspose sono progettati proprio per questo. I nostri componenti funzionano perfettamente sia su un singolo server, alimentando una singola applicazione, sia su un farm di server web bilanciati che supportano un'applicazione enterprise.

## **Prezzo**
When an application utilizes Microsoft Office Automation, a copy of Microsoft Office must be purchased for each machine that runs the application. There are many times that an application may need to create or manipulate an office file but does not require the user to have Microsoft Office. Aspose offers a very [Conveniente](https://purchase.aspose.com/) and royalty free redistribution license that will allow deployment to an unlimited number of users with no licensing worries.

When creating web based applications it is important to know that Microsoft Office Automation components are not priced nor licensed for server side solutions; therefore, there is no good, licensing solution for deploying web applications that utilize the Microsoft Office components. Aspose offers a very Conveniente solution for server based applications as well.

## **Funzionalità**
I componenti Aspose forniscono tutto il necessario per gestire i file Office e molto di più. Sono progettati con la filosofia di consentire agli sviluppatori di ottenere i risultati migliori con il minimo sforzo. Diversamente dall'Automazione di Office, i componenti Aspose offrono molte funzioni potenti e che fanno risparmiare tempo. Ad esempio, [Aspose.Cells](https://products.aspose.com/cells/java/) offre agli sviluppatori la possibilità di importare dati da un **DataTable** o **DataView** direttamente in un file Excel. [Aspose.Words](https://products.aspose.com/words/java/) offre una funzionalità simile che consente agli sviluppatori di popolare un documento Word (cioè Mail Merge). [Every Component](https://products.aspose.com/total/java/) nella famiglia Aspose offre il proprio set di funzionalità uniche e potenti.

La parte migliore dell'acquistare un componente Aspose (o suite di componenti come [Aspose.Total](https://products.aspose.com/total/java/)) è avere accesso ai nostri team di sviluppo. I nostri team sanno che se c'è una funzionalità di cui la tua azienda ha bisogno, molto probabilmente anche altre aziende ne avranno bisogno. Anche se non tutte le richieste possono essere implementate, i nostri team cercano di essere molto aperti e flessibili nel fornire assistenza. Questa mentalità ha permesso ai componenti Aspose di diventare così potenti. Se ci sono funzionalità aggiuntive di cui hai bisogno dagli oggetti di Automazione di Office, le tue probabilità di vederle aggiunte sono molto, molto basse.

## **Conclusione**
{{% alert color="info" title="Note" %}}

While this article has covered many of the key points why Aspose components are a better choice than Office Automation, there are many, many more. This article primarily addresses only the most key points. All of the different Aspose components offer a risk free, no obligation [Evaluation Version](https://releases.aspose.com/slides/it/java/). We encourage you to take advantage of that Evaluation in order to better see what Aspose can do for your applications.

{{% /alert %}}