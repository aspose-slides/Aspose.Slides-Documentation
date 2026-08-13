---
title: Dichiarazione
type: docs
weight: 60
url: /it/java/declaration/
keywords:
- dichiarazione
- componenti
- permesso Full Trust
- impostazioni del registro
- file di sistema
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Scopri i requisiti di trust, i permessi e le limitazioni di hosting di Aspose.Slides per Java, così da poter distribuire in sicurezza le applicazioni che elaborano PPT, PPTX e ODP sui server."
---
{{% alert color="info" %}} 

Tutti i componenti Aspose Java richiedono il set di permessi Full Trust. Il motivo è che i componenti Aspose Java devono accedere a impostazioni del registro, file di sistema al di fuori della directory virtuale per alcune operazioni come l'analisi dei font, ecc. Inoltre, i componenti Aspose Java si basano su classi di sistema Java di base che in molti casi richiedono anche il set di permessi Full Trust. 

{{% /alert %}} 

I provider di servizi Internet che ospitano più applicazioni di diverse aziende applicano per lo più il livello di sicurezza Medium Trust: 

- OleDbPermission non è disponibile. Ciò significa che non è possibile utilizzare il provider di dati OLE DB gestito da ADO.NET per accedere ai database.
- EventLogPermission non è disponibile. Ciò significa che non è possibile accedere al registro eventi di Windows.
- ReflectionPermission non è disponibile. Ciò significa che non è possibile utilizzare la reflection.
- RegistryPermission non è disponibile. Ciò significa che non è possibile accedere al registro.
- WebPermission è limitato. Ciò significa che la tua applicazione può comunicare solo con un indirizzo o un intervallo di indirizzi definito nell'elemento <trust>.
- FileIOPermission è limitato. Ciò significa che è possibile accedere solo ai file nella gerarchia della directory virtuale dell'applicazione.

{{% alert color="info" %}} 

A causa dei motivi specificati sopra, i componenti Aspose Java non possono essere utilizzati sui server che concedono un set di permessi diverso da Full Trust. 

{{% /alert %}}