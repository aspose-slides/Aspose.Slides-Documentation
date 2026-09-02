---
title: Gestire le proprietà della presentazione in PHP
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/php-java/presentation-properties/
keywords:
- Proprietà PowerPoint
- Proprietà della presentazione
- Proprietà del documento
- Proprietà integrate
- Proprietà personalizzate
- Proprietà avanzate
- Gestire le proprietà
- Modificare le proprietà
- Metadati del documento
- Modificare i metadati
- Lingua di correzione
- Lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci le proprietà della presentazione in Aspose.Slides per PHP via Java e ottimizza ricerca, branding e flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides supporta due tipologie di proprietà dei documenti: **Built-in** e **Custom**. Entrambi i tipi di proprietà possono essere facilmente accessibili e gestiti tramite l'API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà dei documenti di presentazione attraverso la classe [DocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/) . Un'istanza di questa classe viene restituita dal metodo [Presentation::getDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getDocumentProperties) . Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Note" %}}
La **Application** e il campo **AppVersion** non possono essere modificati. Aspose.Slides li riscrive ad ogni salvataggio, quindi una presentazione salvata riporta sempre "Aspose.Slides for PHP via Java" e la versione della libreria che l'ha generata. Qualsiasi valore passato a `setNameOfApplication` viene scartato quando la presentazione viene scritta.
{{% /alert %}} 

## **Gestire le proprietà della presentazione**

Microsoft PowerPoint offre una funzionalità per aggiungere alcune proprietà ai file di presentazione. Queste proprietà dei documenti consentono di memorizzare informazioni utili insieme ai documenti (file di presentazione). Esistono due tipologie di proprietà dei documenti come segue

- Proprietà definite dal sistema (**Built-in**)
- Proprietà definite dall'utente (**Custom**)

Le proprietà **Built-in** contengono informazioni generali sul documento, come titolo, nome dell'autore, statistiche del documento e così via. Le proprietà **Custom** sono quelle definite dagli utenti come coppie **Nome/Valore**, dove sia il nome sia il valore sono scelti dall'utente. Con Aspose.Slides for PHP via Java, gli sviluppatori possono accedere e modificare i valori delle proprietà built-in così come delle proprietà custom.

## **Proprietà dei documenti in PowerPoint**

Microsoft PowerPoint 2007 consente di gestire le proprietà dei documenti dei file di presentazione. Tutto quello che devi fare è cliccare sull'icona Office e quindi su **Prepare | Properties | Advanced Properties** nel menu di Microsoft PowerPoint 2007, come mostrato sotto:

|**Selezione della voce di menu Proprietà avanzate**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Dopo aver selezionato la voce di menu **Advanced Properties**, appare una finestra di dialogo che consente di gestire le proprietà del documento PowerPoint, come mostrato nella figura seguente:

|**Finestra Proprietà**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Nella suddetta **Finestra Proprietà**, si notano diverse schede come **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Tutte queste schede consentono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Custom** serve a gestire le proprietà personalizzate dei file PowerPoint.

### Lavorare con le proprietà dei documenti usando Aspose.Slides for PHP via Java

Come descritto in precedenza, Aspose.Slides for PHP via Java supporta due tipologie di proprietà dei documenti, ovvero le proprietà **Built-in** e **Custom**. Pertanto, gli sviluppatori possono accedere a entrambe le tipologie di proprietà tramite l'API di Aspose.Slides for PHP via Java. Aspose.Slides for PHP via Java fornisce la classe [DocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties) che rappresenta le proprietà del documento associate a un file di presentazione attraverso la proprietà **Presentation.DocumentProperties**.

Gli sviluppatori possono utilizzare la proprietà **DocumentProperties** esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation) per accedere alle proprietà del documento dei file di presentazione, come descritto di seguito:

## **Accesso alle proprietà Built-in**

Queste proprietà esposte dall'oggetto [DocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties) includono: **Creator** (Autore), **Description**, **Keywords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data ultima stampa), **LastModifiedBy**, **Keywords**, **SharedDoc** (Condiviso tra diversi produttori?), **PresentationFormat**, **Subject** e **Title**.

```php
  # Istanzia la classe Presentation che rappresenta la presentazione
  $pres = new Presentation("Presentation.pptx");
  try {
    # Crea un riferimento all'oggetto IDocumentProperties associato a Presentation
    $dp = $pres->getDocumentProperties();
    # Mostra le proprietà integrate
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Modifica delle proprietà Built-in**

Modificare le proprietà built-in dei file di presentazione è semplice come accedervi. È sufficiente assegnare una stringa a qualsiasi proprietà desiderata e il valore della proprietà verrà modificato. Nell'esempio riportato di seguito, viene mostrato come modificare le proprietà built-in di una presentazione utilizzando Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Crea un riferimento all'oggetto IDocumentProperties associato a Presentation
    $dp = $pres->getDocumentProperties();
    # Imposta le proprietà integrate
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Salva la tua presentazione in un file
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Questo esempio modifica le proprietà built-in della presentazione, come mostrato sotto:

|**Proprietà dei documenti Built-in dopo la modifica**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aggiungere proprietà personalizzate dei documenti**

Aspose.Slides for PHP via Java consente anche agli sviluppatori di aggiungere valori personalizzati per le proprietà del documento di presentazione. Di seguito è riportato un esempio che mostra come impostare le proprietà custom per una presentazione.

```php
  $pres = new Presentation();
  try {
    # Ottenere le proprietà del documento
    $dProps = $pres->getDocumentProperties();
    # Aggiunta di proprietà personalizzate
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Ottenere il nome della proprietà a un indice particolare
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Rimozione della proprietà selezionata
    $dProps->removeCustomProperty($getPropertyName);
    # Salvataggio della presentazione
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Proprietà dei documenti personalizzate aggiunte**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accedere e modificare le proprietà personalizzate**

Aspose.Slides for PHP via Java consente anche agli sviluppatori di accedere ai valori delle proprietà custom. Di seguito è riportato un esempio che mostra come accedere e modificare tutte queste proprietà custom per una presentazione.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Crea un riferimento all'oggetto DocumentProperties associato a Presentation
    $dp = $pres->getDocumentProperties();
    # Accedi e modifica le proprietà personalizzate
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Visualizza i nomi e i valori delle proprietà personalizzate
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Modifica i valori delle proprietà personalizzate
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Salva la tua presentazione in un file
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Questo esempio modifica le proprietà custom della [PPTX](https://docs.fileformat.com/presentation/pptx/) presentation. Le figure seguenti mostrano le proprietà custom della presentazione prima e dopo la modifica:

|**Proprietà personalizzate prima della modifica**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Proprietà personalizzate dopo la modifica**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Proprietà avanzate del documento**

{{% alert color="info" title="Note" %}}
Sono state aggiunte le nuove metodologie [readDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) e [writeBindedPresentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) alla classe [PresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/PresentationInfo); la logica del setter della proprietà [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#setLastSavedTime) è stata modificata.
{{% /alert %}} 

I due nuovi metodi [readDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) e [updateDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) sono stati aggiunti alla classe [PresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/PresentationInfo). Forniscono un accesso rapido alle proprietà del documento e consentono di modificare e aggiornare le proprietà senza caricare l'intera presentazione.

Lo scenario tipico di caricamento delle proprietà, modifica di qualche valore e aggiornamento del documento può essere implementato nel modo seguente:

```php
  # leggi le informazioni della presentazione
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # ottieni le proprietà correnti
  $props = $info->readDocumentProperties();
  # imposta i nuovi valori dei campi Author e Title
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # aggiorna la presentazione con i nuovi valori
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

Esiste un altro modo per utilizzare le proprietà di una presentazione specifica come modello per aggiornare le proprietà in altre presentazioni:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

È possibile creare un nuovo modello da zero e poi utilizzarlo per aggiornare più presentazioni:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **Impostare la lingua di correzione**

Aspose.Slides fornisce la proprietà LanguageId (esposta dalla classe PortionFormat) per consentire di impostare la lingua di correzione per un documento PowerPoint. La lingua di correzione è la lingua per la quale vengono controllati ortografia e grammatica nel PowerPoint.

Questo codice PHP mostra come impostare la lingua di correzione per un PowerPoint: xxx Perché LanguageId è assente nella classe Java PortionFormat?

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// imposta l'Id di una lingua di correzione

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Impostare la lingua predefinita**

Questo codice PHP mostra come impostare la lingua predefinita per un'intera presentazione PowerPoint:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # Aggiunge una nuova forma rettangolare con testo
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # Controlla la lingua della prima porzione
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Esempio dal vivo**

Prova l'app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà dei documenti tramite l'API di Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## **FAQ**

**Come posso rimuovere una proprietà built-in da una presentazione?**

Le proprietà built-in sono parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile modificarne i valori o impostarle su vuoto, se la specifica proprietà lo consente.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se aggiungi una proprietà personalizzata già presente, il suo valore attuale verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricarla completamente?**

Sì. Usa [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationfactory/) e poi [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#readDocumentProperties) per leggere i metadati del documento memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/). Vedi [Build a Lightweight Presentation Inventory](/slides/it/php-java/examine-presentation/) per un esempio completo di reporting e limitazioni specifiche del formato.