---
title: Rimuovere le diapositive dalle presentazioni in JavaScript
linktitle: Rimuovi diapositiva
type: docs
weight: 30
url: /it/nodejs-java/remove-slide-from-presentation/
keywords:
- rimuovere diapositiva
- eliminare diapositiva
- rimuovere diapositiva inutilizzata
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Rimuovi facilmente le diapositive da presentazioni PowerPoint e OpenDocument con Aspose.Slides per Node.js. Ottieni esempi di codice chiari e migliora il tuo flusso di lavoro."
---
## **Introduzione**

Se una diapositiva (o i suoi contenuti) diventa ridondante, è possibile eliminarla. Aspose.Slides fornisce la classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) che incapsula [SlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/), un repository per tutte le diapositive di una presentazione. Utilizzando puntatori (riferimento o indice) per un oggetto [Slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/) noto, è possibile specificare la diapositiva da rimuovere.

## **Rimuovi diapositiva per riferimento**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Ottieni un riferimento della diapositiva da rimuovere tramite il suo ID o indice.
1. Rimuovi la diapositiva referenziata dalla presentazione.
1. Salva la presentazione modificata. 

Questo codice JavaScript mostra come rimuovere una diapositiva tramite il suo riferimento:

```javascript
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Accede a una diapositiva tramite il suo indice nella collezione di diapositive
    var slide = pres.getSlides().get_Item(0);
    // Rimuove una diapositiva tramite il suo riferimento
    pres.getSlides().remove(slide);
    // Salva la presentazione modificata
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Rimuovi diapositiva per indice**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
1. Rimuovi la diapositiva dalla presentazione tramite la sua posizione di indice.
1. Salva la presentazione modificata. 

Questo codice JavaScript mostra come rimuovere una diapositiva tramite il suo indice:

```javascript
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Rimuove una diapositiva tramite il suo indice
    pres.getSlides().removeAt(0);
    // Salva la presentazione modificata
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Rimuovi layout diapositive inutilizzato**

Aspose.Slides fornisce il metodo [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides-aspose.slides.Presentation-) (della classe [Compress](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/)) per consentire la cancellazione di layout diapositive non desiderati e non utilizzati. Questo codice JavaScript mostra come rimuovere un layout diapositive da una presentazione PowerPoint:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rimuovi master slide inutilizzato**

Aspose.Slides fornisce il metodo [removeUnusedMasterSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) (della classe [Compress](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/)) per consentire la cancellazione di master slide non desiderati e non utilizzati. Questo codice JavaScript mostra come rimuovere un master slide da una presentazione PowerPoint:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Cosa succede agli indici delle diapositive dopo aver eliminato una diapositiva?**

Dopo l'eliminazione, la [collection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidecollection/) viene reindicizzata: ogni diapositiva successiva si sposta di una posizione verso sinistra, quindi i numeri di indice precedenti diventano obsoleti. Se è necessario un riferimento stabile, utilizza l'ID persistente di ogni diapositiva anziché il suo indice.

**L'ID di una diapositiva è diverso dal suo indice e cambia quando le diapositive vicine vengono eliminate?**

Sì. L'indice è la posizione della diapositiva e cambia quando le diapositive vengono aggiunte o rimosse. L'ID della diapositiva è un identificatore persistente e non cambia quando altre diapositive vengono eliminate.

**Come influisce l'eliminazione di una diapositiva sulle sezioni delle diapositive?**

Se la diapositiva apparteneva a una sezione, quella sezione conterrà semplicemente una diapositiva in meno. La struttura della sezione rimane; se una sezione diventa vuota, è possibile [rimuovere o riorganizzare le sezioni](/slides/it/nodejs-java/slide-section/) secondo necessità.

**Cosa succede a note e commenti associati a una diapositiva quando viene eliminata?**

[Notes](/slides/it/nodejs-java/presentation-notes/) e [comments](/slides/it/nodejs-java/presentation-comments/) sono legati a quella specifica diapositiva e vengono rimossi insieme ad essa. Il contenuto delle altre diapositive non viene influenzato.

**In che modo l'eliminazione delle diapositive differisce dalla pulizia di layout/master inutilizzati?**

L'eliminazione rimuove diapositive normali specifiche dal deck. La pulizia di layout/master inutilizzati rimuove layout o master slide a cui nulla fa riferimento, riducendo le dimensioni del file senza modificare il contenuto delle diapositive rimanenti. Queste azioni sono complementari: tipicamente si elimina prima, poi si puliscono.