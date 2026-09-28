---
title: Installa con l'installer MSI
type: docs
weight: 20
url: /it/reportingservices/install-with-msi-installer/
keywords:
- installatore MSI
- installazione
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Installa Aspose.Slides per Reporting Services con il suo installer MSI: cosa richiede l'installer, cosa modifica su ogni istanza del server di report e come verificare il risultato."
---
## **Installazione**

Il programma di installazione MSI è il modo più semplice per installare Aspose.Slides per Reporting Services. Richiede .NET Framework 3.5 e diritti di amministratore sul server di reporting; vedere [Requisiti di sistema](/slides/it/reportingservices/system-requirements/).

1. Scarica il programma di installazione MSI, *Aspose.Slides for Reporting Services XX.XX*, dalla [pagina di download](https://releases.aspose.com/slides/it/reportingservices/) e copialo sul server di reporting.  
2. Eseguilo come amministratore. Se .NET Framework 3.5 è mancante, l'installatore si interrompe con un messaggio; installa le funzionalità di .NET Framework 3.5 ed eseguilo nuovamente.  
3. Accetta il contratto di licenza.  
4. Nella pagina **Custom Setup**, l’albero delle funzionalità elenca ogni istanza di SQL Server Reporting Services e Power BI Report Server rilevata sulla macchina. Per lasciare un’istanza invariata, clicca sulla sua icona e seleziona **Entire feature will be unavailable**. Le edizioni Express non supportano le estensioni di rendering, quindi non selezionare un’istanza Express. L'installatore nasconde le istanze Express di SQL Server 2016 e precedenti.  
5. Seleziona **Next**, quindi **Install**.

La funzionalità opzionale **Rpl Export** non è selezionata per impostazione predefinita. Aggiunge un’estensione nascosta che salva i report in formato RPL, utile quando invii un report di problema ad Aspose; vedere [Esportazione dei report in formato RPL](/slides/it/reportingservices/exporting-reports-to-rpl-format/).

## **Cosa modifica l'installatore**

L'installatore conserva i file in *Aspose\Aspose.Slides for Reporting Services* nella cartella Program Files — *Program Files (x86)* su Windows a 64 bit, poiché il pacchetto è a 32 bit. Poi, per ogni istanza selezionata, esegue le seguenti operazioni:

- copia *Aspose.Slides.ReportingServices.dll* nella cartella *ReportServer\bin* dell'istanza — la build per SQL Server 2005, o la build per SQL Server 2008 e versioni successive e Power BI Report Server;  
- aggiunge sei estensioni di rendering — ASPPT, ASPPS, ASPPTX, ASPPSX, ASXPSS e ASODP — all'elemento `<Render>` di *rsreportserver.config*;  
- aggiunge un gruppo di codice che concede piena fiducia all'assembly in *rssrvpolicy.config*;  
- salva una copia di ogni file di configurazione modificato, aggiungendo *.bak* al nome del file.

[Install Manually](/slides/it/reportingservices/install-manually/) mostra questi cambiamenti passo passo.

Se un'istanza non può essere configurata, l'installatore la segnala in un messaggio e scrive i dettagli in *rserrors<date>.log* nella cartella di installazione. Installa l'estensione su quell'istanza manualmente.

## **Verifica dell'installazione**

Apri un report paginato nel portale web (Report Manager su SQL Server 2014 e versioni precedenti) e apri l’elenco **Export**. Ora include questi formati:

- PPT – Presentazione PowerPoint tramite Aspose.Slides  
- PPS – Presentazione PowerPoint SlideShow tramite Aspose.Slides  
- PPTX – Presentazione PowerPoint 2007 tramite Aspose.Slides  
- PPSX – SlideShow PowerPoint 2007 tramite Aspose.Slides  
- ODP – Presentazione OpenDocument tramite Aspose.Slides  
- XPS – tramite Aspose.Slides  

Senza licenza, i file esportati riportano una filigrana di valutazione; vedere [Licensing](/slides/it/reportingservices/license-aspose-slides-for-reporting-services/).

## **Quando installare manualmente**

Installa l’estensione [manually](/slides/it/reportingservices/install-manually/) invece quando:

- l’installatore non riesce a configurare un’istanza, ad esempio per impostazioni di sicurezza sul server;  
- dopo un aggiornamento, desideri sostituire solo l'assembly invece di disinstallare la versione precedente ed eseguire il nuovo installatore.

Disinstallare il prodotto rimuove l'assembly e le voci di configurazione da ogni istanza.