---
title: Recuperare e aggiornare le informazioni della presentazione in PHP
linktitle: Informazioni presentazione
type: docs
weight: 30
url: /it/php-java/examine-presentation/
keywords:
- formato presentazione
- proprietà presentazione
- proprietà documento
- ottenere proprietà
- leggere proprietà
- modificare proprietà
- alterare proprietà
- aggiornare proprietà
- esaminare PPTX
- esaminare PPT
- esaminare ODP
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument usando Aspose.Slides per PHP per ottenere rapidamente approfondimenti e audit di contenuti più intelligenti."
---
## **Panoramica**

Questo articolo mostra come ispezionare le informazioni di una presentazione in Aspose.Slides. Spiega come determinare il formato attuale di una presentazione senza caricare l'intero file, leggere le sue proprietà del documento e aggiornare tali proprietà quando necessario.

Gli esempi si basano sulle API [PresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/) e [DocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/) e dimostrano le operazioni tipiche per lavorare con i metadati delle presentazioni.

## **Verificare il formato di una presentazione**

Prima di lavorare su una presentazione, potresti voler scoprire in quale formato (PPT, PPTX, ODP e altri) si trova al momento.

Puoi verificare il formato di una presentazione senza caricarla. Vedi questo codice PHP:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Ottenere le proprietà della presentazione**

Questo codice PHP mostra come ottenere le proprietà della presentazione (informazioni sulla presentazione):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

Potresti voler vedere le [proprietà nella classe DocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Aggiornare le proprietà della presentazione**

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

![Proprietà del documento modificate della presentazione PowerPoint](output_properties.png)

## **Link utili**

Per ottenere più informazioni su una presentazione e le sue proprietà di sicurezza, potresti trovare utili questi link:

- [Proteggere le presentazioni con password](/slides/it/php-java/password-protected-presentation/)
- [Proteggere le presentazioni in scrittura](/slides/it/php-java/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i caratteri sono incorporati e quali sono?**

Cerca le [informazioni sui caratteri incorporati](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/getembeddedfonts/) a livello di presentazione, quindi confronta tali voci con l'insieme dei [caratteri effettivamente utilizzati nel contenuto](https://reference.aspose.com/slides/it/php-java/aspose.slides/fontsmanager/getfonts/) per identificare quali caratteri sono fondamentali per il rendering.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Itera attraverso la [collezione di diapositive](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidecollection/) e ispeziona il [flag di visibilità](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/gethidden/) di ogni diapositiva.

**Posso rilevare se viene usata una dimensione e un'orientazione della diapositiva personalizzate, e se differiscono dai valori predefiniti?**

Sì. Confronta la corrente [dimensione della diapositiva](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/getslidesize/) e l'orientamento con le impostazioni predefinite; questo aiuta a prevedere il comportamento per la stampa e l'esportazione.

**Esiste un modo rapido per verificare se i grafici fanno riferimento a fonti di dati esterne?**

Sì. Scorri tutti i [grafici](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/), controlla la loro [fonte dati](https://reference.aspose.com/slides/it/php-java/aspose.slides/chartdata/getdatasourcetype/), e osserva se i dati sono interni o basati su collegamenti, inclusi eventuali collegamenti interrotti.

**Come posso valutare le diapositive 'pesanti' che potrebbero rallentare il rendering o l'esportazione PDF?**

Per ogni diapositiva, conta gli oggetti e cerca immagini grandi, trasparenza, ombre, animazioni e contenuti multimediali; assegna un punteggio di complessità approssimativo per segnalare potenziali punti critici di performance.