---
title: Installazione manuale
type: docs
weight: 30
url: /it/reportingservices/install-manually/
keywords:
- installazione manuale
- rsreportserver.config
- rssrvpolicy.config
- SQL Server Reporting Services
- Power BI Report Server
- Aspose.Slides for Reporting Services
description: "Installa manualmente Aspose.Slides per Reporting Services dal pacchetto ZIP solo DLL: quale assembly copiare e cosa aggiungere a rsreportserver.config e rssrvpolicy.config."
---
## **Panoramica**

Segui questi passaggi per installare Aspose.Slides per Reporting Services senza l'installer MSI, dal pacchetto ZIP *Aspose.Slides for Reporting Services XX.XX (DLLs Only)* sulla [pagina di download](https://releases.aspose.com/slides/it/reportingservices/). Registrano le stesse estensioni dell'[installer MSI](/slides/it/reportingservices/install-with-msi-installer/). Ripetili per ogni istanza del server di report.

Prima di iniziare, controlla i [requisiti di sistema](/slides/it/reportingservices/system-requirements/). Hai bisogno dei diritti di amministratore locale sul server di report.

## **Scegli l'assembly**

Il pacchetto ZIP contiene diverse build. Copia esattamente un *Aspose.Slides.ReportingServices.dll* nel server di report:

| File nel pacchetto ZIP | Uso |
| :- | :- |
| *Bin\Universal\Aspose.Slides.ReportingServices.dll* | SQL Server 2008 e versioni successive Reporting Services, e Power BI Report Server |
| *Bin\SSRS2005\Aspose.Slides.ReportingServices.dll* | SQL Server 2005 Reporting Services |
| *Bin\ReportViewer2010\Aspose.Slides.ReportingServices.dll* | Non per un server di report: applicazioni che esportano dal controllo ReportViewer 2010 o 2012, vedi [Utilizzando Aspose.Slides con ReportViewer 2010 e 2012](/slides/it/reportingservices/using-aspose-slides-with-reportviewer-2010-and-2012/) |
| *Bin\RplExport\Aspose.ReportingServices.Debug.Rpl.dll* | Opzionale: salva i report in formato RPL per segnalazioni di problemi, vedi [Esportazione di report in formato RPL](/slides/it/reportingservices/exporting-reports-to-rpl-format/) |

## **Trova la cartella del server di report**

I passaggi seguenti si riferiscono alla cartella *ReportServer* del server di report, che contiene *rsreportserver.config* e *rssrvpolicy.config*. In un'installazione predefinita, è:

| Server di report | Cartella predefinita *ReportServer* |
| :- | :- |
| SQL Server 2017 e versioni successive Reporting Services | `C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer` |
| Power BI Report Server | `C:\Program Files\Microsoft Power BI Report Server\PBIRS\ReportServer` |
| SQL Server 2016 e versioni precedenti Reporting Services | `C:\Program Files\Microsoft SQL Server\<instance folder>\Reporting Services\ReportServer`, dove la cartella dell'istanza è, ad esempio, `MSRS13.MSSQLSERVER` per SQL Server 2016 o `MSSQL.x` per SQL Server 2005 |

Per ulteriori posizioni, consulta l'articolo di Microsoft [File di configurazione RsReportServer.config](https://learn.microsoft.com/en-us/sql/reporting-services/report-server/rsreportserver-config-configuration-file).

## **Installa l'estensione**

1. Copia l'assembly scelto nella sottocartella *bin* della cartella *ReportServer*.

   Il file copiato non deve contenere permessi NTFS assegnati esplicitamente, altrimenti il server di report nega l'accesso quando carica l'assembly e i nuovi formati di esportazione non compaiono. Fai clic con il pulsante destro sul file, seleziona **Properties**, e nella scheda **Security** rimuovi eventuali permessi assegnati esplicitamente, lasciando solo quelli ereditati. Se nella scheda **General** è presente l'opzione **Unblock**, selezionala.

2. Salva una copia di *rsreportserver.config*, quindi apri il file in un editor di testo. Aggiungi queste voci all'interno dell'elemento `<Render>`:

   ```xml
   <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASXPSS" Type="Aspose.Slides.ReportingServices.XpsRenderer,Aspose.Slides.ReportingServices"/>
   <Extension Name="ASODP" Type="Aspose.Slides.ReportingServices.OdpRenderer,Aspose.Slides.ReportingServices"/>
   ```

   Ogni voce registra un formato di esportazione; `Name` deve essere univoco tra le estensioni di rendering. L'installer MSI registra gli stessi sei nomi e tipi. Ometti una voce se non desideri il suo formato nell'elenco di esportazione.

3. Salva una copia di *rssrvpolicy.config*, quindi apri il file in un editor di testo. Trova il gruppo di codice la cui `Description` è "This code group grants MyComputer code Execution permission." e aggiungi questo gruppo di codice come suo ultimo figlio:

   ```xml
   <CodeGroup class="UnionCodeGroup" version="1" PermissionSetName="FullTrust" Name="Aspose.Slides_for_Reporting_Services" Description="This code group grants full trust to the Aspose.Slides.ReportingServices.dll assembly.">
       <IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf"/>
   </CodeGroup>
   ```

   `PublicKeyBlob` è la chiave pubblica dell'assembly Aspose.Slides.ReportingServices. Mantenerla su una sola riga.

4. Salva entrambi i file. Il server di report legge nuovamente i file di configurazione ogni volta che vengono salvati. Se un file contiene XML non valido, il server di report lo ignora o non si avvia, quindi ripristina la tua copia se qualcosa va storto.

## **Verifica l'installazione**

Apri un report paginato nel portale web (Report Manager su SQL Server 2014 e versioni precedenti) e apri l'elenco **Export**. Ora include questi formati:

- PPT - Presentazione PowerPoint tramite Aspose.Slides
- PPS - SlideShow PowerPoint tramite Aspose.Slides
- PPTX - Presentazione PowerPoint 2007 tramite Aspose.Slides
- PPSX - SlideShow PowerPoint 2007 tramite Aspose.Slides
- ODP - Presentazione OpenDocument tramite Aspose.Slides
- XPS - tramite Aspose.Slides

Seleziona uno di essi per esportare il report. Il file si apre nell'applicazione associata al suo formato.

![Un report esportato in PowerPoint da Aspose.Slides for Reporting Services](install-manually_2.png)

Se i formati non compaiono, controlla i permessi NTFS dell'assembly copiato. Senza licenza, i file esportati presentano una filigrana di valutazione; vedi [Licenza](/slides/it/reportingservices/license-aspose-slides-for-reporting-services/).