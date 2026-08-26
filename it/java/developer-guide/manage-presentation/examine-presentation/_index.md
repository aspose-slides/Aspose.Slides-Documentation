---
title: Recupera e aggiorna le informazioni della presentazione in Java
linktitle: Informazioni sulla presentazione
type: docs
weight: 30
url: /it/java/examine-presentation/
keywords:
- formato della presentazione
- proprietà della presentazione
- proprietà del documento
- ottenere proprietà
- leggere proprietà
- cambiare proprietà
- alterare proprietà
- aggiornare proprietà
- esaminare PPTX
- esaminare PPT
- esaminare ODP
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument con Java per ottenere analisi più rapide e audit dei contenuti più intelligenti."
---
## **Panoramica**

Questo articolo mostra come ispezionare le informazioni di presentazione in Aspose.Slides. Spiega come determinare il formato corrente di una presentazione senza caricare l'intero file, leggere le sue proprietà del documento e aggiornare tali proprietà quando necessario.

Gli esempi si basano sulle API [PresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/documentproperties/) e dimostrano le operazioni tipiche per lavorare con i metadati delle presentazioni.

## **Verifica il formato di una presentazione**

Prima di lavorare su una presentazione, potresti voler scoprire in quale formato (PPT, PPTX, ODP e altri) si trovi attualmente la presentazione.

Puoi verificare il formato di una presentazione senza caricarla. Vedi questo codice Java:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Ottieni le proprietà della presentazione**

Questo codice Java mostra come ottenere le proprietà della presentazione (informazioni sulla presentazione):

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// .. 
```

Potresti voler vedere le [proprietà sotto la classe DocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Aggiorna le proprietà della presentazione**

Aspose.Slides fornisce il metodo [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) che consente di apportare modifiche alle proprietà della presentazione.

Supponiamo di avere una presentazione PowerPoint con le proprietà del documento mostrate di seguito.

![Proprietà del documento originali della presentazione PowerPoint](input_properties.png)

Questo esempio di codice mostra come modificare alcune proprietà della presentazione:

```java
import com.aspose.slides.*;
import java.util.Date;

String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

I risultati della modifica delle proprietà del documento sono mostrati di seguito.

![Proprietà del documento modificate della presentazione PowerPoint](output_properties.png)

## **Collegamenti utili**

Per ottenere maggiori informazioni su una presentazione e sui suoi attributi di sicurezza, potresti trovare utili questi collegamenti:

- [Presentazioni con protezione password](/slides/it/java/password-protected-presentation/)
- [Presentazioni con protezione scrittura](/slides/it/java/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i caratteri sono incorporati e quali sono?**

Cerca le [informazioni sui caratteri incorporati](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) a livello di presentazione, quindi confronta tali voci con l'insieme dei [caratteri effettivamente utilizzati nel contenuto](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsmanager/#getFonts--) per identificare quali caratteri sono critici per il rendering.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante ne sono?**

Itera attraverso la [collezione di diapositive](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidecollection/) e ispeziona il [flag di visibilità](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#getHidden--) di ciascuna diapositiva.

**Posso rilevare se è utilizzata una dimensione e orientamento personalizzati della diapositiva e se differiscono dalle impostazioni predefinite?**

Sì. Confronta l'attuale [dimensione della diapositiva](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getSlideSize--) e l'orientamento con i preset standard; questo aiuta a prevedere il comportamento per la stampa e l'esportazione.

**Esiste un modo rapido per verificare se i grafici fanno riferimento a fonti di dati esterne?**

Sì. Scorri tutti i [grafici](https://reference.aspose.com/slides/it/java/com.aspose.slides/chart/), verifica la loro [fonte dati](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#getDataSourceType--), e annota se i dati sono interni o basati su collegamenti, includendo eventuali collegamenti interrotti.

**Come posso valutare le diapositive 'pesanti' che potrebbero rallentare il rendering o l'esportazione in PDF?**

Per ogni diapositiva, conta gli oggetti e cerca immagini di grandi dimensioni, trasparenza, ombre, animazioni e contenuti multimediali; assegna un punteggio di complessità approssimativo per evidenziare i potenziali punti critici di prestazioni.