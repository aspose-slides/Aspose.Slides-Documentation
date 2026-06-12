---
title: Converti ODP in PPTX su Android
linktitle: ODP in PPTX
type: docs
weight: 10
url: /it/androidjava/convert-odp-to-pptx/
keywords:
- converti OpenDocument
- converti presentazione
- converti diapositiva
- converti ODP
- OpenDocument in PPTX
- ODP in PPTX
- salva ODP come PPTX
- esporta ODP in PPTX
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Converti ODP in PPTX con Aspose.Slides per Android. Esempi di codice Java puliti, suggerimenti per batch e risultati di alta qualità—non è necessario PowerPoint."
---
## **Panoramica**

Questo articolo spiega come convertire una presentazione ODP in formato PPTX utilizzando Aspose.Slides.

## **Convertire ODP in Presentazione PPTX/PPT**

Aspose.Slides per Android tramite Java offre la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) che rappresenta un file di presentazione. La classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation) può ora anche accedere a ODP tramite il costruttore [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/Presentation#Presentation-java.lang.String-) quando l'oggetto viene istanziato. L'esempio seguente mostra come convertire una presentazione ODP in una presentazione PPTX.

```java
// Apri il file ODP
Presentation pres = new Presentation("AccessOpenDoc.odp");
try {}
// Salvataggio della presentazione ODP in formato PPTX
    pres.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Esempio dal vivo**

È possibile visitare l'app web [**Aspose.Slides Conversion**](https://products.aspose.app/slides/it/conversion/) costruita con **Aspose.Slides API.** L'app dimostra come la conversione da ODP a PPTX può essere implementata con l'Aspose.Slides API.

## **FAQ**

**Devo installare Microsoft PowerPoint o LibreOffice per convertire ODP in PPTX?**

No. Aspose.Slides funziona in modalità autonoma e non richiede applicazioni di terze parti per leggere o scrivere ODP/PPTX.

**Le diapositive master, i layout e i temi vengono preservati durante la conversione?**

Sì. La libreria utilizza un modello object completo della presentazione e conserva la struttura, incluse le diapositive master e i layout, così il design rimane corretto dopo la conversione.

**Posso convertire file ODP protetti da password?**

Sì. Aspose.Slides supporta il rilevamento della protezione, l'apertura e la gestione di [presentazioni protette](/slides/it/androidjava/password-protected-presentation/) (inclusi ODP) quando si fornisce la password, oltre a configurare la crittografia e l'accesso alle proprietà del documento.

**Aspose.Slides è adatto per servizi di conversione basati su cloud o REST?**

Sì. È possibile utilizzare la libreria locale nel proprio backend o [Aspose.Slides Cloud](https://products.aspose.cloud/slides/it/family/) (REST API); entrambe le opzioni supportano la conversione ODP → PPTX.