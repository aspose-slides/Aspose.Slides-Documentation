---
title: Accedi alle diapositive della presentazione su Android
linktitle: Accedi alla diapositiva
type: docs
weight: 20
url: /it/androidjava/access-slide-in-presentation/
keywords:
- accedi alla diapositiva
- indice diapositiva
- id diapositiva
- posizione diapositiva
- cambia posizione
- proprietà diapositiva
- numero diapositiva
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Scopri come accedere e gestire le diapositive in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Android. Incrementa la produttività con esempi di codice Java."
---
## **Panoramica**

Questo articolo spiega come accedere e gestire le diapositive in una presentazione utilizzando Aspose.Slides. Mostra come recuperare le diapositive tramite il loro indice basato su zero dalla collezione di diapositive e come accedere a una diapositiva tramite il suo ID univoco usando il metodo `getSlideById`.

Imparerai anche come modificare la posizione di una diapositiva utilizzando il metodo `setSlideNumber` e come definire il numero della diapositiva iniziale per una presentazione con il metodo `setFirstSlideNumber`. Gli esempi mostrano il caricamento di una presentazione, l'ottenimento di riferimenti alle diapositive, l'aggiornamento dell'ordine o della numerazione delle diapositive e il salvataggio della presentazione modificata.

## **Accedi a una diapositiva per indice**

Tutte le diapositive in una presentazione sono disposte numericamente in base alla posizione della diapositiva a partire da 0. La prima diapositiva è accessibile tramite l'indice 0; la seconda diapositiva è accessibile tramite l'indice 1; ecc.

La classe Presentation, che rappresenta un file di presentazione, espone tutte le diapositive come una collezione [ISlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidecollection/) (collezione di oggetti [ISlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/)). Questo codice Java mostra come accedere a una diapositiva tramite il suo indice:

```java
// Instanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("demo.pptx");
try {
    // Accede a una diapositiva usando il suo indice
    ISlide slide = pres.getSlides().get_Item(0);
} finally {
    pres.dispose();
}
```

## **Accedi a una diapositiva per ID**

Ogni diapositiva in una presentazione ha un ID univoco associato. Puoi utilizzare il metodo [getSlideById](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSlideById-long-) (esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/)) per puntare a quell'ID. Questo codice Java mostra come fornire un ID diapositiva valido e accedere a quella diapositiva tramite il metodo [getSlideById](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSlideById-long-):

```java
// Instanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("demo.pptx");
try {
    // Ottiene l'ID di una diapositiva
    int id = (int) pres.getSlides().get_Item(0).getSlideId();
    
    // Accede alla diapositiva tramite il suo ID
    IBaseSlide slide = pres.getSlideById(id);
} finally {
    pres.dispose();
}
```

## **Modifica la posizione della diapositiva**

Aspose.Slides consente di modificare la posizione di una diapositiva. Ad esempio, è possibile specificare che la prima diapositiva diventi la seconda diapositiva.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottieni il riferimento della diapositiva (la cui posizione vuoi modificare) tramite il suo indice
1. Imposta una nuova posizione per la diapositiva tramite la proprietà [setSlideNumber](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/#setSlideNumber-int-).
1. Salva la presentazione modificata.

Questo codice Java dimostra un'operazione in cui la diapositiva nella posizione 1 viene spostata nella posizione 2: 

```java
// Instanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Ottiene la diapositiva la cui posizione sarà cambiata
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Imposta la nuova posizione per la diapositiva
    sld.setSlideNumber(2);
    
    // Salva la presentazione modificata
    pres.save("helloworld_Pos.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

La prima diapositiva è diventata la seconda; la seconda diapositiva è diventata la prima. Quando modifichi la posizione di una diapositiva, le altre diapositive vengono regolate automaticamente.

## **Imposta il numero della diapositiva**

Utilizzando la proprietà [setFirstSlideNumber](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) (esposta dalla classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/)), è possibile specificare un nuovo numero per la prima diapositiva di una presentazione. Questa operazione fa sì che gli altri numeri delle diapositive vengano ricalcolati.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
1. Ottieni il numero della diapositiva.
1. Imposta il numero della diapositiva.
1. Salva la presentazione modificata.

Questo codice Java dimostra un'operazione in cui il numero della prima diapositiva è impostato a 10: 

```java
// Instanzia un oggetto Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    // Ottiene il numero della diapositiva
    int firstSlideNumber = pres.getFirstSlideNumber();

    // Imposta il numero della diapositiva
    pres.setFirstSlideNumber(10);
	
    // Salva la presentazione modificata
    pres.save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Se preferisci saltare la prima diapositiva, puoi avviare la numerazione dalla seconda diapositiva (e nascondere la numerazione per la prima diapositiva) in questo modo:

```java
Presentation presentation = new Presentation();
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    // Imposta il numero per la prima diapositiva della presentazione
    presentation.setFirstSlideNumber(0);

    // Mostra i numeri delle diapositive per tutte le diapositive
    presentation.getHeaderFooterManager().setAllSlideNumbersVisibility(true);

    // Nasconde il numero della diapositiva per la prima diapositiva
    presentation.getSlides().get_Item(0).getHeaderFooterManager().setSlideNumberVisibility(false);

    // Salva la presentazione modificata
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Il numero della diapositiva visualizzato dall'utente corrisponde all'indice basato su zero della collezione?**

Il numero mostrato su una diapositiva può iniziare da un valore arbitrario (ad es., 10) e non deve corrispondere all'indice; la relazione è controllata dall'impostazione [primo numero diapositiva](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-).

**Le diapositive nascoste influenzano l'indicizzazione?**

Sì. Una diapositiva nascosta rimane nella collezione e viene conteggiata nell'indicizzazione; "nascosta" si riferisce alla visualizzazione, non alla sua posizione nella collezione.

**L'indice di una diapositiva cambia quando altre diapositive vengono aggiunte o rimosse?**

Sì. Gli indici riflettono sempre l'ordine corrente delle diapositive e vengono ricalcolati al momento di inserimenti, eliminazioni e spostamenti.