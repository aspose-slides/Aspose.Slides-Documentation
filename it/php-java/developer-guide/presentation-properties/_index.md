---
title: Gestire le proprietà della presentazione in PHP
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/php-java/presentation-properties/
keywords:
- Proprietà di PowerPoint
- Proprietà della presentazione
- Proprietà del documento
- Proprietà incorporate
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
description: "Gestisci le proprietà di presentazione in Aspose.Slides per PHP via Java e ottimizza ricerca, branding e flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides supporta due tipi di proprietà del documento: **Built-in** e **Custom**. Entrambi i tipi di proprietà possono essere facilmente accessibili e gestiti tramite l'API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà dei documenti di presentazione attraverso la classe [DocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/) . Un'istanza di questa classe è restituita dal metodo [Presentation::getDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getDocumentProperties) . I seguenti esempi mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Note" %}}
Si noti che i campi **Application** e **AppVersion** non possono essere modificati. Aspose.Slides li riscrive ad ogni salvataggio, quindi una presentazione salvata riporta sempre "Aspose.Slides for PHP via Java" e la versione della libreria che l'ha prodotta. Qualsiasi valore passato a `setNameOfApplication` viene scartato quando la presentazione viene scritta.
{{% /alert %}} 

## **Gestire le Proprietà della Presentazione**

Microsoft PowerPoint fornisce una funzione per aggiungere alcune proprietà ai file di presentazione. Queste proprietà del documento consentono di archiviare informazioni utili insieme ai documenti (file di presentazione). Esistono due tipi di proprietà del documento:

- System Defined (Built-in) Properties
- User-Defined (Custom) Properties

Le proprietà **Built-in** contengono informazioni generali sul documento, come titolo del documento, nome dell'autore, statistiche del documento e così via. Le proprietà **Custom** sono quelle definite dagli utenti come coppie **Name/Value**, dove sia il nome sia il valore sono definiti dall'utente. Utilizzando Aspose.Slides per PHP via Java, gli sviluppatori possono accedere e modificare i valori delle proprietà built-in così come delle proprietà custom.

## **Proprietà del Documento in PowerPoint**

Microsoft PowerPoint 2007 consente di gestire le proprietà del documento dei file di presentazione. Basta fare clic sull'icona Office e quindi sul menu **Prepare | Properties | Advanced Properties** di Microsoft PowerPoint 2007, come mostrato di seguito:

|**Seleziona voce di menu Proprietà avanzate**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Dopo aver selezionato la voce di menu **Advanced Properties**, appare una finestra di dialogo che consente di gestire le proprietà del documento del file PowerPoint, come mostrato nella figura seguente:

|**Finestra Proprietà**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Nella suddetta **Finestra Proprietà**, è possibile vedere molte schede come **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Tutte queste schede consentono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Custom** è utilizzata per gestire le proprietà personalizzate dei file PowerPoint.

### Lavorare con le Proprietà del Documento utilizzando Aspose.Slides per PHP via Java

Come descritto in precedenza, Aspose.Slides per PHP via Java supporta due tipi di proprietà del documento, ovvero **Built-in** e **Custom**. Pertanto, gli sviluppatori possono accedere a entrambi i tipi di proprietà tramite l'API di Aspose.Slides per PHP via Java. Aspose.Slides per PHP via Java fornisce una classe [DocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties) che rappresenta le proprietà del documento associate a un file di presentazione attraverso la proprietà **Presentation.DocumentProperties**.

Gli sviluppatori possono utilizzare la proprietà **DocumentProperties** esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation) per accedere alle proprietà del documento dei file di presentazione come descritto di seguito:

## **Leggere le Proprietà Pubbliche da una Presentazione Cifrata**

Una password di apertura normalmente protegge sia il contenuto della presentazione sia le proprietà del documento. Quando una presentazione è cifrata passando `false` a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), le sue proprietà del documento rimangono pubbliche. Un'applicazione può quindi passare `true` a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) e leggere i metadati pubblici senza fornire la password di apertura.

L'opzione solo‑document‑properties controlla cosa Aspose.Slides carica; non decritta nulla. Se le proprietà fossero incluse nella cifratura, il loro caricamento senza password fallisce. Se la presentazione non è cifrata, l'opzione viene ignorata e l'intera presentazione viene caricata.

Il seguente esempio verifica la modalità di caricamento mediante [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) e poi legge le proprietà built-in tramite [Presentation::getDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

In questa modalità, il contenuto delle diapositive non viene caricato. Diapositive, master, layout, forme, media e altri oggetti della presentazione non sono disponibili. Le applicazioni dovrebbero sempre verificare [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/it/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) prima di eseguire un'operazione che richiede l'intero modello oggetti della presentazione.

{{% alert color="warning" title="Warning" %}}
I metadati pubblici possono esporre nomi degli autori, titoli, soggetti, parole‑chiave, informazioni aziendali, commenti e valori personalizzati. Cifra le proprietà sensibili insieme alla presentazione. Lasciale pubbliche solo quando indicizzazione, classificazione, ricerca o sistemi di gestione documentale hanno requisiti specifici per accedervi senza password.
{{% /alert %}}

## **Aggiornare le Proprietà di una Presentazione Cifrata**

Per un file PPTX cifrato, una presentazione caricata in modalità solo‑document‑properties è destinata alla lettura dei metadati pubblici. Aspose.Slides non può salvare le proprietà modificate da quell'oggetto a metadati‑solo perché le proprietà pubbliche devono rimanere coerenti con i dati corrispondenti all'interno della presentazione cifrata. L'aggiornamento richiede quindi la password di apertura corretta e un caricamento completo.

Il seguente esempio apre la presentazione con [LoadOptions::setPassword](https://reference.aspose.com/slides/it/php-java/aspose.slides/loadoptions/#setPassword), aggiorna le proprietà built‑in pubbliche e salva il risultato. Quindi utilizza [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#isEncrypted) per verificare che la cifratura sia preservata e riapre i metadati pubblici senza password per verificare i nuovi valori:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

Se a un'applicazione non è consentito decifrare o caricare il contenuto della presentazione, deve trattare le proprietà pubbliche di un file PPTX cifrato come di sola lettura.

## **Accedere alle Proprietà Built-in**

Queste proprietà, così come esposte dall'oggetto [DocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties) includono: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** e **Title**.

```php
  # Istanziare la classe Presentation che rappresenta la presentazione
  $pres = new Presentation("Presentation.pptx");
  try {
    # Creare un riferimento all'oggetto IDocumentProperties associato a Presentation
    $dp = $pres->getDocumentProperties();
    # Mostrare le proprietà integrate
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

## **Modificare le Proprietà Built-in**

Modificare le proprietà built‑in dei file di presentazione è semplice come accedervi. È sufficiente assegnare una stringa a qualsiasi proprietà desiderata e il valore verrà modificato. Nell'esempio riportato di seguito, abbiamo dimostrato come modificare le proprietà built‑in del documento di una presentazione usando Aspose.Slides per PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Creare un riferimento all'oggetto IDocumentProperties associato a Presentation
    $dp = $pres->getDocumentProperties();
    # Impostare le proprietà integrate
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # Salvare la presentazione in un file
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Questo esempio modifica le proprietà built‑in della presentazione, come mostrato di seguito:

|**Proprietà documenti built‑in dopo la modifica**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aggiungere Proprietà Documenti Personalizzate**

Aspose.Slides per PHP via Java consente anche agli sviluppatori di aggiungere valori personalizzati alle proprietà del documento della presentazione. Di seguito è riportato un esempio che mostra come impostare le proprietà personalizzate per una presentazione.

```php
  $pres = new Presentation();
  try {
    # Ottenere le proprietà del documento
    $dProps = $pres->getDocumentProperties();
    # Aggiungere proprietà personalizzate
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # Ottenere il nome della proprietà a indice specifico
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # Rimuovere la proprietà selezionata
    $dProps->removeCustomProperty($getPropertyName);
    # Salvare la presentazione
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**Proprietà Documenti Personalizzate Aggiunte**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accedere e Modificare le Proprietà Personalizzate**

Aspose.Slides per PHP via Java consente anche agli sviluppatori di accedere ai valori delle proprietà personalizzate. Di seguito è riportato un esempio che mostra come accedere e modificare tutte queste proprietà personalizzate per una presentazione.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Creare un riferimento all'oggetto DocumentProperties associato a Presentation
    $dp = $pres->getDocumentProperties();
    # Accedere e modificare le proprietà personalizzate
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # Visualizzare i nomi e i valori delle proprietà personalizzate
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # Modificare i valori delle proprietà personalizzate
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # Salvare la presentazione in un file
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Questo esempio modifica le proprietà personalizzate della presentazione [PPTX](https://docs.fileformat.com/presentation/pptx/). Le figure seguenti mostrano le proprietà personalizzate della presentazione prima e dopo la modifica:

|**Proprietà Personalizzate prima della Modifica**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Proprietà Personalizzate dopo la Modifica**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Proprietà Documenti Avanzate**

{{% alert color="info" title="Note" %}}
Sono stati aggiunti i nuovi metodi [readDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/PresentationInfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) e [writeBindedPresentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) alla classe [PresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/PresentationInfo), la logica del setter della proprietà [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#setLastSavedTime) è stata modificata.
{{% /alert %}} 

I due nuovi metodi [readDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) e [updateDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) sono stati aggiunti alla classe [PresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/PresentationInfo). Forniscono un accesso rapido alle proprietà del documento e consentono di modificare e aggiornare le proprietà senza caricare l'intera presentazione.

Lo scenario tipico di caricare le proprietà, modificare qualche valore e aggiornare il documento può essere implementato nel seguente modo:

```php
  # leggere le informazioni della presentazione
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # ottenere le proprietà correnti
  $props = $info->readDocumentProperties();
  # impostare i nuovi valori dei campi Autore e Titolo
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # aggiornare la presentazione con i nuovi valori
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

È possibile creare un nuovo modello da zero e poi usarlo per aggiornare più presentazioni:

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

## **Impostare la Lingua di Correzione**

Aspose.Slides fornisce la proprietà LanguageId (esposta dalla classe PortionFormat) per consentire di impostare la lingua di correzione per un documento PowerPoint. La lingua di correzione è la lingua per la quale vengono controllate ortografia e grammatica in PowerPoint.

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

## **Impostare la Lingua Predefinita**

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

## **Esempio Live**

Prova l'app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà del documento tramite l'API di Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## **FAQ**

**Come posso rimuovere una proprietà built‑in da una presentazione?**

Le proprietà built‑in sono parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile modificarne i valori o impostarle a vuoto, se la specifica proprietà lo consente.

**Cosa succede se aggiungo una proprietà custom che esiste già?**

Se aggiungi una proprietà custom già esistente, il suo valore corrente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare l'intera presentazione?**

Sì. Usa [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationfactory/) e poi [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentationinfo/#readDocumentProperties) per leggere i metadati del documento memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/) . Vedi [Build a Lightweight Presentation Inventory](/slides/it/php-java/examine-presentation/) per un esempio completo di reporting e limitazioni specifiche del formato.

**Posso leggere le proprietà pubbliche di una presentazione cifrata senza la sua password di apertura?**

Sì. La cifratura delle proprietà del documento deve essere stata disabilitata prima che la presentazione fosse cifrata, e la presentazione deve essere caricata in modalità solo‑document‑properties.

**Posso aggiornare un file PPTX cifrato in modalità solo‑document‑properties?**

No. I dati delle proprietà pubbliche e cifrate devono rimanere coerenti, quindi l'aggiornamento di un file PPTX cifrato richiede il caricamento completo della presentazione con la password di apertura corretta.