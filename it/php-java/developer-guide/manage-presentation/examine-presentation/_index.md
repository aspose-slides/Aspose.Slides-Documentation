---
title: Recupera e aggiorna le informazioni della presentazione in PHP
linktitle: Informazioni sulla presentazione
type: docs
weight: 30
url: /it/php-java/examine-presentation/
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
- PHP
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument usando Aspose.Slides per PHP per ottenere rapidamente approfondimenti e audit dei contenuti più intelligenti."
---
## **Panoramica**

Questo articolo mostra come ispezionare le informazioni di presentazione in Aspose.Slides. Spiega come determinare il formato corrente di una presentazione senza caricare l'intero file, leggere le sue proprietà del documento e aggiornare tali proprietà quando necessario.

Gli esempi si basano sulle API [PresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/) e dimostrano le operazioni tipiche per lavorare con i metadati della presentazione.

## **Verifica il formato di una presentazione**

Prima di lavorare su una presentazione, potresti voler scoprire in quale formato (PPT, PPTX, ODP e altri) si trovi attualmente la presentazione.

Puoi verificare il formato di una presentazione senza caricarla. Vedi questo codice PHP:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Ottieni le proprietà della presentazione**

Questo codice PHP mostra come ottenere le proprietà della presentazione (informazioni sulla presentazione):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

Potresti voler vedere le [proprietà nella classe DocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#DocumentProperties--).

## **Aggiorna le proprietà della presentazione**

Aspose.Slides fornisce il metodo [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) che consente di apportare modifiche alle proprietà della presentazione.

Supponiamo di avere una presentazione PowerPoint con le proprietà del documento mostrate di seguito.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

Questo esempio di codice mostra come modificare alcune proprietà della presentazione:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

I risultati della modifica delle proprietà del documento sono mostrati di seguito.

![Proprietà modificate del documento della presentazione PowerPoint](output_properties.png)

## **Link utili**

Per ottenere maggiori informazioni su una presentazione e sui suoi attributi di sicurezza, potresti trovare utili questi collegamenti:

- [Verifica se una presentazione è crittografata](https://docs.aspose.com/slides/it/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Verifica se una presentazione è protetta da scrittura (sola lettura)](https://docs.aspose.com/slides/it/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Verifica se una presentazione è protetta da password prima di caricarla](https://docs.aspose.com/slides/it/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confermare la password usata per proteggere una presentazione](https://docs.aspose.com/slides/it/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Come posso verificare se i caratteri sono incorporati e quali sono?**

Cerca le [informazioni sui caratteri incorporati](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/getembeddedfonts/) a livello di presentazione, quindi confronta tali voci con l'insieme dei [caratteri effettivamente utilizzati nei contenuti](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/getfonts/) per identificare quali caratteri sono critici per il rendering.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Itera attraverso la [collezione di diapositive](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/) e controlla il [flag di visibilità](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/gethidden/) di ciascuna diapositiva.

**Posso rilevare se vengono usate dimensioni e orientamento personalizzati della diapositiva, e se differiscono dalle impostazioni predefinite?**

Sì. Confronta le attuali [dimensioni della diapositiva](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getslidesize/) e l'orientamento con i preset standard; questo aiuta a prevedere il comportamento per la stampa e l'esportazione.

**Esiste un modo rapido per verificare se i grafici fanno riferimento a fonti dati esterne?**

Sì. Scorri tutti i [grafici](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/), controlla la loro [fonte dati](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/getdatasourcetype/) e annota se i dati sono interni o basati su collegamenti, includendo eventuali collegamenti interrotti.

**Come posso valutare le diapositive 'pesanti' che potrebbero rallentare il rendering o l'esportazione PDF?**

Per ogni diapositiva, conta gli oggetti e cerca immagini di grandi dimensioni, trasparenza, ombre, animazioni e contenuti multimediali; assegna un punteggio di complessità approssimativo per segnalare eventuali punti critici di prestazioni.