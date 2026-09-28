---
title: Licenza Aspose.Slides per Reporting Services
type: docs
weight: 70
url: /it/reportingservices/license-aspose-slides-for-reporting-services/
keywords:
- licenza
- licenze
- filigrana di valutazione
- licenza temporanea
- Aspose.Slides for Reporting Services
description: "Applica una licenza a Aspose.Slides for Reporting Services copiando il file di licenza sul server di report e verifica che le presentazioni esportate non contengano più la filigrana di valutazione."
---
## **Supporto Licenza**

La versione di valutazione di Aspose.Slides for Reporting Services è lo stesso pacchetto di quello acquistato, dalla sua pagina di download, e fornisce le stesse funzionalità. Senza licenza, funziona in modalità di valutazione e inserisce una filigrana di valutazione nelle presentazioni esportate.

La versione di valutazione diventa licenziata quando copi un file di licenza sul server di reporting. Non è necessario alcun codice.

Quando sei soddisfatto della tua valutazione, puoi [acquistare una licenza](https://purchase.aspose.com/pricing/slides/reporting-services/). Ti consigliamo di esaminare i diversi tipi di abbonamento. Se hai domande, contatta il team di vendita di Aspose.

## **Licenza in Aspose.Slides for Reporting Services**

* La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa, la data di scadenza dell'abbonamento, ecc.
* Il file di licenza è firmato digitalmente, quindi non devi modificarlo. Anche l'aggiunta involontaria di un'interruzione di riga extra al contenuto del file lo invaliderà.

1. Copia il file di licenza nella cartella *ReportServer\bin* di ogni istanza del server di report, dove è installato *Aspose.Slides.ReportingServices.dll* — ad esempio, *C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer\bin*. [Installa manualmente](/slides/it/reportingservices/install-manually/#find-the-report-server-folder) elenca le cartelle predefinite.
2. Assicurati che il file abbia uno dei nomi che l'estensione ricerca: *Aspose.Slides.ReportingServices.lic*, *Aspose.Slides.Reporting.Services.lic*, *Aspose.Slides.Product.Family.lic*, *Aspose.Total.ReportingServices.lic*, *Aspose.Total.Reporting.Services.lic*, *Aspose.Total.Product.Family.lic* o *Aspose.Total.lic*.
3. Esporta qualsiasi report come presentazione. Se non contiene una filigrana, la licenza è attiva.

L'estensione ricerca anche il file di licenza in *%ProgramData%\Aspose\Slides* (di solito *C:\ProgramData\Aspose\Slides*), quindi una copia lì serve a tutte le istanze sulla macchina.

**Modalità Licenziata**

Quando viene trovato un file di licenza valido, le presentazioni esportate non contengono alcuna filigrana di valutazione.

![Un report esportato con licenza: nessuna filigrana di valutazione](license-aspose-slides-for-reporting-services_2.png)

**Modalità di Valutazione**

Senza licenza, Aspose.Slides for Reporting Services inserisce una filigrana di valutazione nelle presentazioni esportate.

![Un report esportato in modalità valutazione, con la filigrana di valutazione](license-aspose-slides-for-reporting-services_1.png)

{{% alert color="info" title="Nota" %}}
Per testare Aspose.Slides for Reporting Services senza limitazioni, puoi richiedere una **Licenza Temporanea di 30 giorni**. Vedi la pagina [Come ottenere una licenza temporanea](https://purchase.aspose.com/temporary-license) per ulteriori informazioni.
{{% /alert %}}