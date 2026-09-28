---
title: Installazione della licenza Aspose.Slides per SharePoint
type: docs
weight: 10
url: /it/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Installa la licenza Aspose.Slides per SharePoint su un farm SharePoint: aggiungi la soluzione di licenza allo store delle soluzioni, distribuiscila e verifica che i file convertiti non riportino più il watermark di valutazione."
---
{{% alert color="info" title="Note" %}}

Una volta che sei soddisfatto della tua valutazione, puoi [acquistare una licenza](https://purchase.aspose.com/pricing/slides/sharepoint/). Prima di acquistare, assicurati di comprendere e accettare i termini di abbonamento della licenza. La licenza ti viene inviata via email quando l'ordine è stato pagato.

La licenza è un archivio ZIP che contiene un pacchetto di soluzione SharePoint standard. L'archivio contiene:

- Aspose.Slides.SharePoint.License.wsp – il file del pacchetto di soluzione SharePoint. La licenza è confezionata come una soluzione SharePoint per rendere facile il dispiegamento e il ritiro su un farm di server.
- readme.txt – Istruzioni per l'installazione della licenza.

{{% /alert %}}

## **Distribuzione della licenza**

L'installazione della licenza viene eseguita dalla console del server tramite **stsadm.exe**.

{{% alert color="info" title="Note" %}}

I percorsi sono omessi nella sezione seguente per chiarezza.

{{% /alert %}}

Esegui i seguenti passaggi per distribuire la licenza di Aspose.Slides per SharePoint:

1. Esegui stsadm per aggiungere la soluzione allo store delle soluzioni SharePoint:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Distribuisci la soluzione su tutti i server del farm:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Esegui i job timer amministrativi per completare immediatamente la distribuzione:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

L'operazione `addsolution` accetta il percorso del file della soluzione in `-filename`; l'operazione `deploysolution` accetta il nome della soluzione già presente nello store in `-name`.

{{% alert color="info" title="Note" %}}

Ricevi un avviso durante l'esecuzione del passaggio di distribuzione se il servizio SharePoint Administration non è in esecuzione. **stsadm.exe** si basa su questo servizio e sul servizio SharePoint Timer per replicare i dati della soluzione sul farm. Se questi servizi non sono attivi sul tuo farm di server, potresti dover distribuire la licenza su ciascun server.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

Su SharePoint 2010 e versioni successive, i cmdlet della SharePoint Management Shell `Add-SPSolution`, `Install-SPSolution` e `Start-SPAdminJob` corrispondono alle operazioni `addsolution`, `deploysolution` e `execadmsvcjobs`. Vedi [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **Verifica della licenza**

Per verificare che la licenza sia stata installata correttamente, converti qualsiasi presentazione in un nuovo formato. Se nel file convertito non è presente alcun watermark di valutazione, la licenza è attiva.