---  
title: Rimuovere diapositive dalle presentazioni su Android  
linktitle: Rimuovi diapositiva  
type: docs  
weight: 30  
url: /it/androidjava/remove-slide-from-presentation/  
keywords:  
- rimuovere diapositiva  
- eliminare diapositiva  
- rimuovere diapositiva inutilizzata  
- PowerPoint  
- OpenDocument  
- presentazione  
- Android  
- Java  
- Aspose.Slides  
description: "Rimuovi facilmente diapositive da presentazioni PowerPoint e OpenDocument con Aspose.Slides per Android. Ottieni esempi di codice Java chiari e migliora il tuo flusso di lavoro."  
---
## **Introduzione**

Se una diapositiva (o il suo contenuto) diventa ridondante, è possibile eliminarla. Aspose.Slides fornisce la classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) che incapsula [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidecollection/), un repository per tutte le diapositive di una presentazione. Utilizzando puntatori (riferimento o indice) per un oggetto [ISlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/) noto, è possibile specificare la diapositiva da rimuovere.

## **Rimuovere una diapositiva per riferimento**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottenere un riferimento alla diapositiva da rimuovere tramite il suo ID o indice.
1. Rimuovere la diapositiva di riferimento dalla presentazione.
1. Salvare la presentazione modificata. 

Questo codice Java mostra come rimuovere una diapositiva tramite il suo riferimento:

```java
// Instanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("demo.pptx");
try {
    // Accede a una diapositiva tramite il suo indice nella collezione di diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Rimuove una diapositiva tramite il suo riferimento
    pres.getSlides().remove(slide);
    
    // Salva la presentazione modificata
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Rimuovere una diapositiva per indice**

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Rimuovere la diapositiva dalla presentazione tramite la sua posizione di indice.
1. Salvare la presentazione modificata. 

Questo codice Java mostra come rimuovere una diapositiva tramite il suo indice:

```java
// Istanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("demo.pptx");
try {
    // Rimuove una diapositiva tramite il suo indice
    pres.getSlides().removeAt(0);
    
    // Salva la presentazione modificata
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Rimuovere le diapositive layout inutilizzate**

Aspose.Slides fornisce il metodo [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (dalla classe [Compress](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/)) per consentire l'eliminazione delle diapositive layout indesiderate e non utilizzate. Questo codice Java mostra come rimuovere una diapositiva layout da una presentazione PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Rimuovere le diapositive master inutilizzate**

Aspose.Slides fornisce il metodo [removeUnusedMasterSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (dalla classe [Compress](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/)) per consentire l'eliminazione delle diapositive master indesiderate e non utilizzate. Questo codice Java mostra come rimuovere una diapositiva master da una presentazione PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

## **FAQ**

**Cosa succede agli indici delle diapositive dopo aver eliminato una diapositiva?**

Dopo l'eliminazione, la [collection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidecollection/) si riorganizza: ogni diapositiva successiva si sposta di una posizione verso sinistra, quindi i numeri di indice precedenti diventano obsoleti. Se è necessario un riferimento stabile, utilizzare l'ID persistente di ciascuna diapositiva anziché il suo indice.

**L'ID di una diapositiva è diverso dal suo indice e cambia quando le diapositive vicine vengono eliminate?**

Sì. L'indice è la posizione della diapositiva e cambia quando vengono aggiunte o rimosse diapositive. L'ID della diapositiva è un identificatore persistente e non cambia quando altre diapositive vengono eliminate.

**In che modo l'eliminazione di una diapositiva influisce sulle sezioni delle diapositive?**

Se la diapositiva apparteneva a una sezione, quella sezione conterrà semplicemente una diapositiva in meno. La struttura della sezione rimane; se una sezione diventa vuota, è possibile [remove or reorganize sections](/slides/it/androidjava/slide-section/) secondo necessità.

**Cosa succede a note e commenti associati a una diapositiva quando viene eliminata?**

[Notes](/slides/it/androidjava/presentation-notes/) e [comments](/slides/it/androidjava/presentation-comments/) sono legati a quella specifica diapositiva e vengono rimossi insieme ad essa. Il contenuto delle altre diapositive non è influenzato.

**In che modo l'eliminazione delle diapositive differisce dalla pulizia di layout/master inutilizzati?**

L'eliminazione rimuove diapositive normali specifiche dal mazzo. La pulizia di layout/master inutilizzati rimuove diapositive layout o master a cui nulla fa riferimento, riducendo la dimensione del file senza modificare il contenuto delle diapositive rimanenti. Queste azioni sono complementari: tipicamente si elimina prima, poi si pulisce.