---
title: Recupera e aggiorna le informazioni sulla presentazione su Android
linktitle: Informazioni sulla presentazione
type: docs
weight: 30
url: /it/androidjava/examine-presentation/
keywords:
- formato della presentazione
- proprietà della presentazione
- proprietà del documento
- ottenere le proprietà
- leggere le proprietà
- cambiare le proprietà
- modificare le proprietà
- aggiornare le proprietà
- esaminare PPTX
- esaminare PPT
- esaminare ODP
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati in presentazioni PowerPoint e OpenDocument usando Java per ottenere rapidamente informazioni e audit di contenuti più intelligenti."
---
## **Panoramica**

Questo articolo mostra come ispezionare le informazioni di una presentazione in Aspose.Slides. Spiega come determinare il formato corrente di una presentazione senza caricare l'intero file, leggere le sue proprietà del documento e aggiornare tali proprietà quando necessario.

Gli esempi si basano sulle API [PresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/documentproperties/) e dimostrano le operazioni tipiche per lavorare con i metadati della presentazione.

## **Verifica il formato di una presentazione**

Prima di lavorare su una presentazione, potresti voler scoprire in quale formato (PPT, PPTX, ODP e altri) si trova attualmente la presentazione.

Puoi verificare il formato di una presentazione senza caricarla. Consulta questo codice Java:

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

Potresti voler vedere le [proprietà nella classe DocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Aggiorna le proprietà della presentazione**

Aspose.Slides fornisce il metodo [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) che consente di apportare modifiche alle proprietà della presentazione.

Supponiamo di avere una presentazione PowerPoint con le proprietà del documento mostrate di seguito.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

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

![Proprietà modificate del documento della presentazione PowerPoint](output_properties.png)

## **Link utili**

Per ottenere ulteriori informazioni su una presentazione e sui suoi attributi di sicurezza, potresti trovare utili questi collegamenti:

- [Presentazioni protette da password](/slides/it/androidjava/password-protected-presentation/)
- [Presentazioni protette da scrittura](/slides/it/androidjava/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i caratteri sono incorporati e quali sono?**

Cerca le [informazioni sui caratteri incorporati](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) a livello di presentazione, poi confronta queste voci con l'insieme dei [caratteri effettivamente usati nel contenuto](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsmanager/#getFonts--) per identificare quali caratteri sono critici per il rendering.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Itera attraverso la [collezione di diapositive](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidecollection/) e controlla il [flag di visibilità](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slide/#getHidden--) di ogni diapositiva.

**Posso rilevare se è usata una dimensione e un orientamento della diapositiva personalizzati e se differiscono dalle impostazioni predefinite?**

Sì. Confronta la [dimensione della diapositiva](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSlideSize--) corrente e l'orientamento con le impostazioni standard; questo aiuta a prevedere il comportamento per la stampa e l'esportazione.

**Esiste un modo rapido per verificare se i grafici fanno riferimento a fonti dati esterne?**

Sì. Scorri tutti i [grafici](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chart/), controlla la loro [fonte dati](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) e verifica se i dati sono interni o basati su collegamenti, inclusi eventuali collegamenti interrotti.

**Come posso valutare le diapositive 'pesanti' che potrebbero rallentare il rendering o l'esportazione PDF?**

Per ogni diapositiva, conta gli oggetti e cerca immagini di grandi dimensioni, trasparenza, ombre, animazioni e contenuti multimediali; assegna un punteggio di complessità approssimativo per evidenziare potenziali punti critici di prestazioni.