---
title: Dichiarazione
type: docs
weight: 110
url: /it/net/declaration/
keywords:
- dichiarazione
- componenti
- permesso Full Trust
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
{{% alert color="info" %}} 

Tutti i componenti Aspose .NET richiedono il set di autorizzazioni Full Trust perché a volte devono accedere alle impostazioni del registro, ai file di sistema e ai file memorizzati in altre posizioni (oltre alla directory virtuale) per alcune operazioni (ad esempio l'analisi dei caratteri). Inoltre, i componenti Aspose .NET si basano su classi di sistema .NET core, le quali richiedono il set di autorizzazioni Full Trust in molti casi. 

{{% /alert %}} 

I provider di servizi Internet, che ospitano più applicazioni provenienti da diverse aziende, applicano per lo più il livello di sicurezza Medium Trust. In un contesto .NET 2.0, tale livello di sicurezza impone queste restrizioni: 

- OleDbPermission non è disponibile. Ciò significa che non è possibile utilizzare il provider di dati OLE DB gestito da ADO.NET per accedere ai database.
- EventLogPermission non è disponibile. Ciò significa che non è possibile accedere al registro eventi di Windows.
- ReflectionPermission non è disponibile. Ciò significa che non è possibile utilizzare la reflection.
- RegistryPermission non è disponibile. Ciò significa che non è possibile accedere al registro.
- WebPermission è limitato. Ciò significa che la tua applicazione può comunicare solo con un indirizzo o un intervallo di indirizzi definito nell'elemento <trust>.
- FileIOPermission è limitato. Ciò significa che è possibile accedere solo ai file nella gerarchia della directory virtuale della tua applicazione.

{{% alert color="info" %}} 

Per i motivi sopra indicati, i componenti Aspose .NET possono essere utilizzati solo su server che concedono il set di autorizzazioni Full Trust. 

{{% /alert %}}