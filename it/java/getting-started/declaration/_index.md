---
title: Dichiarazione
type: docs
weight: 60
url: /it/java/declaration/
keywords:
- dichiarazione
- componenti
- autorizzazione Full Trust
- impostazioni del registro
- file di sistema
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri i requisiti di fiducia, le autorizzazioni e le limitazioni di hosting di Aspose.Slides per Java, così da poter distribuire in sicurezza le applicazioni che elaborano PPT, PPTX e ODP sui server."
---
{{% alert color="primary" %}} 

Tutti i componenti Aspose Java richiedono l'impostazione di autorizzazione Full Trust. Il motivo è che i componenti Aspose Java devono accedere alle impostazioni del registro, ai file di sistema al di fuori della directory virtuale per alcune operazioni come l'analisi dei font ecc. Inoltre, i componenti Aspose Java si basano su classi di sistema Java di base che in molti casi richiedono l'impostazione di autorizzazione Full Trust. 

{{% /alert %}} 

I provider di servizi Internet che ospitano più applicazioni di diverse aziende applicano principalmente il livello di sicurezza Medium Trust: 

- OleDbPermission non è disponibile. Ciò significa che non è possibile utilizzare il provider di dati OLE DB gestito da ADO.NET per accedere ai database.
- EventLogPermission non è disponibile. Ciò significa che non è possibile accedere al registro eventi di Windows.
- ReflectionPermission non è disponibile. Ciò significa che non è possibile utilizzare la reflection.
- RegistryPermission non è disponibile. Ciò significa che non è possibile accedere al registro.
- WebPermission è limitato. Ciò significa che l'applicazione può comunicare solo con un indirizzo o un intervallo di indirizzi che si definisce nell'elemento <trust>.
- FileIOPermission è limitato. Ciò significa che è possibile accedere solo ai file nella gerarchia della directory virtuale dell'applicazione.

{{% alert color="primary" %}} 

Per i motivi specificati sopra, i componenti Aspose Java non possono essere utilizzati su server che concedono un'impostazione di autorizzazione diversa da Full Trust. 

{{% /alert %}}