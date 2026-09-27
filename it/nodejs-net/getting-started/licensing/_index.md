---
title: Licenza
description: "Applica un file di licenza ad Aspose.Slides per Node.js via .NET, scopri i limiti della versione di valutazione e ottieni una licenza temporanea gratuita di 30 giorni per i test."
type: docs
weight: 80
url: /it/nodejs-net/licensing/
---
## **Panoramica**

Aspose.Slides per Node.js via .NET è un pacchetto npm sia per valutazione che per produzione. Senza licenza, viene eseguito in modalità di valutazione. Dopo aver acquistato una licenza, o ottenuto una licenza temporanea gratuita di 30 giorni, la si applica con poche righe di codice e le limitazioni di valutazione non si applicano più.

{{% alert color="info" title="Note" %}}
Le politiche generali su come valutare, licenziare e acquistare i prodotti Aspose sono raccolte in [Politiche di acquisto e FAQ](https://purchase.aspose.com/policies). I prezzi sono elencati nella pagina [Informazioni sui prezzi](https://purchase.aspose.com/pricing/slides/it/family).
{{% /alert %}}

## **Limitazioni della versione di valutazione**

La versione di valutazione fornisce la funzionalità completa del prodotto, con due limitazioni:

- **Filigrana.** Ogni diapositiva di ogni presentazione che salvi ottiene una filigrana di valutazione: una casella di testo bloccata al centro della diapositiva con la scritta "Evaluation only." La stessa filigrana è applicata alle esportazioni PDF, XPS e HTML e alle immagini delle diapositive.
- **Testo troncato.** Il testo che il tuo codice legge da un riquadro di testo, paragrafo o porzione viene tagliato ai primi cinque caratteri, seguito dall'avviso "... text has been truncated due to evaluation version limitation." Le esportazioni Markdown e HTML5 sono troncate allo stesso modo. Il testo che il tuo codice scrive viene salvato per intero.

[Valuta Aspose.Slides](/slides/it/nodejs-net/evaluate-aspose-slides/) descrive entrambe le limitazioni in dettaglio e include uno script che le mostra.

{{% alert color="success" title="Tip" %}}
Per testare Aspose.Slides senza le limitazioni di valutazione, richiedi una **licenza temporanea gratuita di 30 giorni**. Consulta [Come ottenere una licenza temporanea?](https://purchase.aspose.com/temporary-license) per i dettagli.
{{% /alert %}}

## **Informazioni sulla licenza**

La licenza è un file XML di testo semplice che contiene dettagli come il nome del prodotto, il numero di sviluppatori a cui è concessa la licenza e la data di scadenza dell'abbonamento. Il file è firmato digitalmente, quindi non modificarlo: anche una riga aggiuntiva inserita per errore la invalida.

## **Applicare una licenza**

Applica la licenza con il metodo `setLicense` della classe `License`. Chiamalo una sola volta per processo, prima di creare qualsiasi oggetto `Presentation`. Richiamarlo nuovamente non provoca danni, ma ripete un lavoro già svolto.

Lo script seguente applica una licenza da un file chiamato `Aspose.Slides.lic`. Sostituisci il nome con il nome o il percorso completo del tuo file di licenza; il file può avere qualsiasi nome.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

Un nome file o percorso relativo viene risolto rispetto alla cartella corrente, quella da cui avvii `node`. Mantieni il file di licenza nella cartella del progetto ed esegui gli script da lì, oppure passa il percorso completo.

Se il file non viene trovato, o non è una licenza valida, `setLicense` genera un errore e Aspose.Slides rimane in modalità di valutazione. Lo script intercetta l'errore e ne stampa il messaggio. Per un file mancante, il messaggio inizia con `License "Aspose.Slides.lic" doesn't exist or access is restricted.` e elenca ogni posizione cercata.

In questo pacchetto, una licenza è applicata solo da un file. `License` non accetta uno stream e il pacchetto non espone licenze a consumo. Per la classe che il pacchetto avvolge, vedi [Licenza](https://reference.aspose.com/slides/it/net/aspose.slides/license/) nella documentazione API di Aspose.Slides per .NET.