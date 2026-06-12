---
title: Installazione della licenza Aspose.Slides per SharePoint
type: docs
weight: 10
url: /it/sharepoint/installing-aspose-slides-for-sharepoint-license/
---
{{% alert color="primary" %}} 

Una volta che sei soddisfatto della tua valutazione, puoi [acquistare una licenza](https://purchase.aspose.com/buy). Prima di acquistare, assicurati di comprendere e accettare i termini di abbonamento della licenza. La licenza ti viene inviata via e-mail quando l'ordine è stato pagato.

La licenza è un archivio ZIP contenente un normale pacchetto di soluzioni SharePoint. L'archivio contiene:

- Aspose.Slides.SharePoint.License.wsp – il file del pacchetto di soluzioni SharePoint. La licenza è confezionata come una soluzione SharePoint per semplificare la distribuzione e il ritiro su un server farm.
- readme.txt – Istruzioni per l'installazione della licenza.

{{% /alert %}} 
## **Distribuzione della licenza**
L'installazione della licenza viene eseguita dalla console del server tramite **stsadm.exe**.

{{% alert color="primary" %}} 

I percorsi sono stati omessi nella sezione seguente per chiarezza.

{{% /alert %}} 

Esegui i seguenti passaggi per distribuire la licenza di Aspose.Slides per SharePoint:

1. Esegui stsadm per aggiungere la soluzione allo store delle soluzioni SharePoint: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. Distribuisci la soluzione su tutti i server del farm: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. Esegui i timer job amministrativi per completare immediatamente la distribuzione: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

Riceverai un avviso durante l'esecuzione del passaggio di distribuzione se il servizio Windows SharePoint Services Administration non è in esecuzione. **stsadm.exe** si basa su questo servizio e sul Windows SharePoint Timer Service per replicare i dati della soluzione sul farm. Se questi servizi non sono in esecuzione nel tuo farm di server, potresti dover distribuire la licenza su ogni server. 

{{% /alert %}} 
## **Test della licenza**
Per verificare che la licenza sia stata installata correttamente, converti qualsiasi documento in un nuovo formato. Se non è presente alcuna filigrana di valutazione nel documento, la licenza è stata attivata con successo.