---
title: Recupera e aggiorna le informazioni della presentazione su Android
linktitle: Informazioni sulla presentazione
type: docs
weight: 30
url: /it/androidjava/examine-presentation/
keywords:
- formato presentazione
- proprietà della presentazione
- proprietà del documento
- ottenere proprietà
- leggere proprietà
- cambiare proprietà
- modificare proprietà
- aggiornare proprietà
- esaminare PPTX
- esaminare PPT
- esaminare ODP
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument usando Java per ottenere rapidamente informazioni e audit intelligenti dei contenuti."
---
## **Panoramica**

Questo articolo mostra come ispezionare le informazioni di una presentazione in Aspose.Slides. Spiega come determinare il formato corrente di una presentazione senza caricare l'intero file, leggere le sue proprietà del documento e aggiornare tali proprietà quando necessario.

Gli esempi si basano sulle API [PresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/documentproperties/) e dimostrano le operazioni tipiche per lavorare con i metadati della presentazione.

## **Verifica il formato di una presentazione**

Prima di lavorare su una presentazione, potresti voler scoprire in quale formato (PPT, PPTX, ODP e altri) si trovi la presentazione al momento.

Puoi verificare il formato di una presentazione senza caricarla. Vedi questo codice Java:

```java
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
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ...
```

Potresti voler vedere le [proprietà nella classe DocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/documentproperties/#DocumentProperties--) .

## **Aggiorna le proprietà della presentazione**

Aspose.Slides fornisce il metodo [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) che consente di modificare le proprietà della presentazione.

Supponiamo di avere una presentazione PowerPoint con le proprietà del documento mostrate di seguito.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

Questo esempio di codice mostra come modificare alcune proprietà della presentazione:

```java
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

Per ottenere maggiori informazioni su una presentazione e i suoi attributi di sicurezza, potresti trovare utili questi collegamenti:

- [Verifica se una presentazione è crittata](https://docs.aspose.com/slides/it/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Verifica se una presentazione è protetta da scrittura (sola lettura)](https://docs.aspose.com/slides/it/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Verifica se una presentazione è protetta da password prima di caricarla](https://docs.aspose.com/slides/it/androidjava/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Conferma della password utilizzata per proteggere una presentazione](https://docs.aspose.com/slides/it/androidjava/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Come posso verificare se i caratteri sono incorporati e quali sono?**

Cerca le [informazioni sui caratteri incorporati](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) a livello di presentazione, quindi confronta tali voci con l'insieme dei [caratteri effettivamente utilizzati nei contenuti](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/fontsmanager/#getFonts--) per identificare quali caratteri sono critici per il rendering.

**Come posso rapidamente capire se il file contiene diapositive nascoste e quante?**

Itera attraverso la [collezione di diapositive](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slidecollection/) e ispeziona il [flag di visibilità](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/slide/#getHidden--) di ciascuna diapositiva.

**Posso rilevare se sono utilizzate dimensioni e orientamento personalizzati delle diapositive e se differiscono dalle impostazioni predefinite?**

Sì. Confronta le attuali [dimensioni della diapositiva](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSlideSize--) e l'orientamento con le impostazioni predefinite; questo aiuta a prevedere il comportamento per la stampa e l'esportazione.

**Esiste un modo rapido per verificare se i grafici fanno riferimento a fonti dati esterne?**

Sì. Scorri tutti i [grafici](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chart/), verifica la loro [fonte dati](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chartdata/#getDataSourceType--), e nota se i dati sono interni o basati su collegamenti, inclusi eventuali collegamenti interrotti.

**Come posso valutare le diapositive 'pesanti' che potrebbero rallentare il rendering o l'esportazione PDF?**

Per ogni diapositiva, conta gli oggetti e cerca immagini di grandi dimensioni, trasparenze, ombre, animazioni e contenuti multimediali; assegna un punteggio di complessità approssimativo per segnalare potenziali colli di bottiglia di prestazioni.