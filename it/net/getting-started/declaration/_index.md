---
title: Dichiarazione
type: docs
weight: 110
url: /it/net/declaration/
keywords:
- dichiarazione
- componenti
- autorizzazione Full Trust
- impostazioni del registro
- file di sistema
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri i requisiti di fiducia, le autorizzazioni e le limitazioni di hosting di Aspose.Slides per .NET, così da poter distribuire in sicurezza le applicazioni che elaborano PPT, PPTX e ODP sui server."
---
{{% alert color="primary" %}} 

Tutte le componenti Aspose .NET richiedono l'impostazione di autorizzazione Full Trust perché a volte devono accedere alle impostazioni del registro, ai file di sistema e ai file archiviati in altre posizioni (oltre alla directory virtuale) per alcune operazioni (ad esempio l'analisi dei caratteri). Inoltre, le componenti Aspose .NET si basano su classi di sistema .NET di base, le quali richiedono l'impostazione Full Trust in molti casi. 

{{% /alert %}} 

I provider di servizi Internet, che ospitano più applicazioni di diverse aziende, in genere applicano il livello di sicurezza Medium Trust. In un caso .NET 2.0, tale livello di sicurezza impone queste restrizioni: 

- OleDbPermission non è disponibile. Questo significa che non è possibile utilizzare il provider dati OLE DB gestito da ADO.NET per accedere ai database.
- EventLogPermission non è disponibile. Questo significa che non è possibile accedere al registro eventi di Windows.
- ReflectionPermission non è disponibile. Questo significa che non è possibile utilizzare la riflessione.
- RegistryPermission non è disponibile. Questo significa che non è possibile accedere al registro.
- WebPermission è limitato. Questo significa che la tua applicazione può comunicare solo con un indirizzo o l'intervallo di indirizzi definito nell'elemento <trust>.
- FileIOPermission è limitato. Questo significa che è possibile accedere solo ai file nella gerarchia della directory virtuale dell'applicazione.

{{% alert color="primary" %}} 

Per i motivi sopra indicati, le componenti Aspose .NET possono essere utilizzate solo su server che concedono l'impostazione di autorizzazione Full Trust. 

{{% /alert %}}