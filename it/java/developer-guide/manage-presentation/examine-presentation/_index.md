---
title: Recuperare e aggiornare le informazioni della presentazione in Java
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
- modificare proprietà
- modificare proprietà
- aggiornare proprietà
- esaminare PPTX
- esaminare PPT
- esaminare ODP
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument utilizzando Java per ottenere approfondimenti più rapidi e audit dei contenuti più intelligenti."
---
## **Panoramica**

Questo articolo mostra come analizzare le informazioni di presentazione in Aspose.Slides. Spiega come determinare il formato corrente di una presentazione senza caricare l’intero file, leggere le sue proprietà del documento e aggiornare tali proprietà quando necessario.

Gli esempi si basano sulle API [PresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/documentproperties/) e dimostrano le operazioni tipiche per lavorare con i metadati della presentazione.

## **Verificare il formato di una presentazione**

Prima di lavorare su una presentazione, potresti voler scoprire in quale formato (PPT, PPTX, ODP e altri) si trovi attualmente.

Puoi verificare il formato di una presentazione senza caricarla. Vedi questo codice Java:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **Ottenere le proprietà della presentazione**

Questo codice Java mostra come ottenere le proprietà della presentazione (informazioni sulla presentazione):

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ...
```

Potresti voler consultare le [properties under the DocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/documentproperties/#DocumentProperties--) class.

## **Aggiornare le proprietà della presentazione**

Aspose.Slides fornisce il metodo [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) che consente di modificare le proprietà della presentazione.

Supponiamo di avere una presentazione PowerPoint con le proprietà del documento illustrate di seguito.

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

Per ottenere ulteriori informazioni su una presentazione e sui suoi attributi di sicurezza, potresti trovare utili questi collegamenti:

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/it/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/it/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Checking whether a Presentation is Password Protected Before Loading it](https://docs.aspose.com/slides/it/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/it/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Come posso verificare se i caratteri sono incorporati e quali sono?**

Cerca le informazioni sui [embedded-font](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) a livello di presentazione, quindi confronta tali voci con l'insieme dei [fonts actually used across content](https://reference.aspose.com/slides/it/java/com.aspose.slides/fontsmanager/#getFonts--) per identificare quali caratteri siano critici per il rendering.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Itera attraverso la [slide collection](https://reference.aspose.com/slides/it/java/com.aspose.slides/slidecollection/) e ispeziona il [visibility flag](https://reference.aspose.com/slides/it/java/com.aspose.slides/slide/#getHidden--) di ogni diapositiva.

**Posso rilevare se sono state usate dimensioni e orientamento personalizzati della diapositiva e se differiscono dalle impostazioni predefinite?**

Sì. Confronta le attuali [slide size](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getSlideSize--) e orientamento con i preset standard; questo aiuta a prevedere il comportamento per la stampa e l'esportazione.

**Esiste un modo rapido per vedere se i grafici fanno riferimento a fonti dati esterne?**

Sì. Scorri tutti i [charts](https://reference.aspose.com/slides/it/java/com.aspose.slides/chart/), controlla il loro [data source](https://reference.aspose.com/slides/it/java/com.aspose.slides/chartdata/#getDataSourceType--) e nota se i dati sono interni o basati su collegamenti, inclusi eventuali collegamenti interrotti.

**Come posso valutare le diapositive “pesanti” che potrebbero rallentare il rendering o l'esportazione PDF?**

Per ogni diapositiva, conta gli oggetti e cerca immagini di grandi dimensioni, trasparenze, ombre, animazioni e contenuti multimediali; assegna un punteggio di complessità approssimativo per segnalare potenziali colli di bottiglia delle prestazioni.