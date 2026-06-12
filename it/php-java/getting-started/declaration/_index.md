---
title: Dichiarazione
type: docs
weight: 60
url: /it/php-java/declaration/
keywords:
- dichiarazione
- componenti
- Autorizzazione Full Trust
- impostazioni del registro
- file di sistema
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Scopri i requisiti di fiducia, le autorizzazioni e le limitazioni di hosting di Aspose.Slides per PHP, così potrai distribuire in sicurezza le applicazioni che elaborano PPT, PPTX e ODP sui server."
---
{{% alert color="primary" %}}

Tutti i componenti Aspose Java richiedono il set di autorizzazioni Full Trust. Il motivo è che i componenti Aspose Java devono accedere alle impostazioni del registro, ai file di sistema diversi dalla directory virtuale per alcune operazioni come l'analisi dei font, ecc. Inoltre, i componenti Aspose Java si basano su classi di sistema Java di base che in molti casi richiedono anch'essi il set di autorizzazioni Full Trust.

{{% /alert %}}

I provider di servizi Internet che ospitano più applicazioni di diverse aziende generalmente applicano il livello di sicurezza Medium Trust:

- OleDbPermission non è disponibile. Questo significa che non è possibile utilizzare il provider di dati OLE DB gestito ADO.NET per accedere ai database.
- EventLogPermission non è disponibile. Questo significa che non è possibile accedere al registro eventi di Windows.
- ReflectionPermission non è disponibile. Questo significa che non è possibile utilizzare il reflection.
- RegistryPermission non è disponibile. Questo significa che non è possibile accedere al registro.
- WebPermission è limitato. Questo significa che l'applicazione può comunicare solo con un indirizzo o un intervallo di indirizzi che si definisce nell'elemento <trust>.
- FileIOPermission è limitato. Questo significa che è possibile accedere solo ai file nella gerarchia della directory virtuale dell'applicazione.

{{% alert color="primary" %}}

Per i motivi specificati sopra, i componenti Aspose Java non possono essere utilizzati su server che concedono un set di autorizzazioni diverso da Full Trust.

{{% /alert %}}