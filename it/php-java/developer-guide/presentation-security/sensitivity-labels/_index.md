---
title: Gestire le etichette di sensibilità nelle presentazioni PowerPoint in PHP
linktitle: Etichette di sensibilità
type: docs
weight: 50
url: /it/php-java/sensitivity-labels/
keywords:
- etichetta di sensibilità
- Microsoft Purview
- Microsoft Information Protection
- metadati MIP
- marcatura del contenuto
- protezione delle informazioni
- governance dei documenti
- PowerPoint
- PPTX
- sicurezza della presentazione
- PHP
- Aspose.Slides
description: "Leggi, aggiungi, aggiorna, rimuovi e migra le etichette di sensibilità Microsoft Purview nelle presentazioni PowerPoint PPTX in PHP."
---
## **Panoramica**

Le etichette di sensibilità di Microsoft Purview aiutano le organizzazioni a classificare e governare i documenti. Durante l'elaborazione automatica delle presentazioni, un'applicazione può dover conservare un'etichetta esistente, applicare un'etichetta selezionata da una politica, aggiornare il suo stato o migrare i metadati delle etichette scritti da un flusso di lavoro Microsoft Information Protection (MIP) più vecchio.

Aspose.Slides per PHP via Java espone i metadati delle etichette di sensibilità moderne tramite [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSensitivityLabels). Questo metodo restituisce una [SensitivityLabelCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelcollection/) che può essere ispezionata e modificata prima che la presentazione venga salvata come PPTX.

{{% alert color="primary" title="Note" %}}
Gli identificatori delle etichette di sensibilità e le informazioni sulla politica sono definiti dalla configurazione di Microsoft Purview. Convalida la disponibilità delle etichette e i requisiti della politica nel tuo ambiente prima di aggiungere o migrare i metadati. I valori di [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) descrivono le marcature di contenuto associate a un'etichetta; non aggiungono direttamente testo visibile o forme alle diapositive.
{{% /alert %}}

## **Comprendere le proprietà delle etichette di sensibilità**

Ogni [SensitivityLabel](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/) contiene i seguenti metadati:

| Metodi | Scopo |
| --- | --- |
| [SensitivityLabel::getId](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#getId) e [SensitivityLabel::setId](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#setId) | Ottieni o imposta l'identificatore dell'etichetta di sensibilità nella politica Purview. |
| [SensitivityLabel::getSiteId](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#getSiteId) e [SensitivityLabel::setSiteId](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#setSiteId) | Ottieni o imposta il sito associato alla politica dell'etichetta. |
| [SensitivityLabel::isEnabled](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#isEnabled) e [SensitivityLabel::setEnabled](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#setEnabled) | Ottieni o imposta se l'etichetta è abilitata. |
| [SensitivityLabel::isRemoved](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#isRemoved) e [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#setRemoved) | Ottieni o imposta se l'etichetta è stata rimossa. Imposta il valore a `true` quando lo stato di rimozione deve essere conservato nei metadati. |
| [SensitivityLabel::getAssignmentMethodType](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) e [SensitivityLabel::setAssignmentMethodType](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Ottieni o imposta se l'etichetta è stata applicata automaticamente o tramite decisione dell'utente. |
| [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Ottieni i tipi di marcatura del contenuto associati all'etichetta. |

La classe [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelassignmenttype/) definisce come un'etichetta è stata assegnata:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelassignmenttype/) rappresenta un'etichetta predefinita o applicata automaticamente.
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelassignmenttype/) rappresenta un'etichetta applicata tramite decisione dell'utente, comprese le etichette applicate manualmente, consigliate e obbligatorie.

La classe [SensitivityLabelContentType](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelcontenttype/) definisce la marcatura associata a un'etichetta:

| Valore | Significato |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelcontenttype/) | L'etichetta è stata applicata per impostazione predefinita o automaticamente. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelcontenttype/) | La marcatura dell'intestazione è associata all'etichetta. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelcontenttype/) | La marcatura del piè di pagina è associata all'etichetta. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelcontenttype/) | La marcatura della filigrana è associata all'etichetta. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelcontenttype/) | La protezione di crittografia è associata all'etichetta. |

Più tipi di marcatura possono essere associati a una singola etichetta.

## **Elencare le etichette di sensibilità esistenti**

Leggi la collezione di etichette moderne da [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSensitivityLabels) ed enumerala. L'esempio seguente elenca ogni proprietà e marcatura di contenuto memorizzata per ciascuna etichetta:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);

        echo "Label ID: " . java_values($sensitivityLabel->getId()) . PHP_EOL;
        echo "Site ID: " . java_values($sensitivityLabel->getSiteId()->toString()) . PHP_EOL;
        echo "Enabled: " . (java_values($sensitivityLabel->isEnabled()) ? "true" : "false") . PHP_EOL;
        echo "Removed: " . (java_values($sensitivityLabel->isRemoved()) ? "true" : "false") . PHP_EOL;
        echo "Assignment method: " . java_values($sensitivityLabel->getAssignmentMethodType()) . PHP_EOL;

        $contentMarkIterator = $sensitivityLabel->getContentMarkTypes()->iterator();
        while (java_values($contentMarkIterator->hasNext())) {
            $contentMarkType = java_values($contentMarkIterator->next());
            echo "Content marking: " . $contentMarkType . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Aggiungere un'etichetta di sensibilità con marcatura del contenuto**

Usa [SensitivityLabelCollection::add](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelcollection/#add) con l'identificatore dell'etichetta, l'identificatore del sito, lo stato abilitato e il metodo di assegnazione. Dopo che il metodo restituisce la nuova [SensitivityLabel](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/), aggiungi i valori di marcatura richiesti tramite la lista restituita da [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

L'esempio seguente aggiunge un'etichetta selezionata manualmente associata a marcature di piè di pagina e filigrana, quindi salva il risultato come PPTX:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();

    $labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $UUID = new JavaClass("java.util.UUID");
    $siteIdentifier = $UUID->fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    $isEnabled = true;
    $assignmentMethod = SensitivityLabelAssignmentType::Privileged;

    $sensitivityLabel = $sensitivityLabels->add(
        $labelIdentifier,
        $siteIdentifier,
        $isEnabled,
        $assignmentMethod
    );

    $contentMarkTypes = $sensitivityLabel->getContentMarkTypes();
    $contentMarkTypes->addItem(SensitivityLabelContentType::Footer);
    $contentMarkTypes->addItem(SensitivityLabelContentType::Watermark);

    $presentation->save("presentation_with_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Aggiornare un'etichetta di sensibilità**

I valori di [SensitivityLabel](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/) sono leggibili e scrivibili, eccetto la lista restituita da [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) che viene modificata tramite le sue operazioni di lista. Dopo aver individuato l'etichetta richiesta, puoi aggiornare il suo identificatore, l'identificatore del sito, lo stato abilitato, il metodo di assegnazione, lo stato di rimozione e i tipi di marcatura del contenuto. Salva la presentazione per rendere persistenti le modifiche.

L'esempio seguente aggiorna lo stato abilitato e il metodo di assegnazione della prima etichetta:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    if ($sensitivityLabelCount > 0) {
        $sensitivityLabel = $sensitivityLabels->get_Item(0);
        $sensitivityLabel->setEnabled(true);
        $sensitivityLabel->setAssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
    }

    $presentation->save("presentation_with_updated_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Contrassegnare un'etichetta di sensibilità come rimossa**

Per conservare il fatto che un'etichetta è stata rimossa, individua l'etichetta e chiama [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#setRemoved) con `true`. Questo mantiene la voce dell'etichetta registrando il suo stato di rimozione. Se invece è necessario eliminare una voce dalla collezione moderna, usa [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelcollection/#removeAt); usa [SensitivityLabelCollection::clear](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelcollection/#clear) per cancellare tutte le voci.

L'esempio seguente contrassegna un'etichetta specifica come rimossa e salva la presentazione aggiornata:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $sensitivityLabels = $presentation->getSensitivityLabels();
    $targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    $sensitivityLabelCount = java_values($sensitivityLabels->getCount());

    for ($labelIndex = 0; $labelIndex < $sensitivityLabelCount; $labelIndex++) {
        $sensitivityLabel = $sensitivityLabels->get_Item($labelIndex);
        $labelIdentifier = java_values($sensitivityLabel->getId());
        $isTargetLabel = strcasecmp($labelIdentifier, $targetLabelIdentifier) === 0;

        if ($isTargetLabel) {
            $sensitivityLabel->setRemoved(true);
            break;
        }
    }

    $presentation->save("presentation_with_removed_label.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Leggere e migrare le etichette di sensibilità MIP legacy**

I flussi di lavoro più vecchi basati su MIP possono memorizzare i metadati delle etichette di sensibilità in proprietà personalizzate del documento anziché nella collezione di etichette moderne. Leggi tali metadati con [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#getSensitivityLabels). Il metodo analizza le proprietà personalizzate legacy e restituisce un array Java di oggetti [SensitivityLabel](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/).

Per migrare i metadati, aggiungi ogni etichetta restituita alla moderna [SensitivityLabelCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelcollection/) tramite [SensitivityLabelCollection::add](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelcollection/#add). Poiché aggiungere un identificatore di etichetta duplicato genera un'eccezione, l'esempio verifica la collezione di destinazione prima di copiare ogni etichetta. Puoi aggiungere ulteriori convalide per confermare che ogni etichetta legacy sia ancora presente nella politica Purview corrente.

```php
$presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    $legacySensitivityLabels = $presentation->getDocumentProperties()->getSensitivityLabels();
    $modernSensitivityLabels = $presentation->getSensitivityLabels();

    $Array = new JavaClass("java.lang.reflect.Array");
    $legacyLabelCount = java_values($Array->getLength($legacySensitivityLabels));

    for ($legacyLabelIndex = 0; $legacyLabelIndex < $legacyLabelCount; $legacyLabelIndex++) {
        $legacySensitivityLabel = $legacySensitivityLabels[$legacyLabelIndex];
        $legacyLabelIdentifier = java_values($legacySensitivityLabel->getId());
        $labelAlreadyExists = false;
        $modernLabelCount = java_values($modernSensitivityLabels->getCount());

        for ($modernLabelIndex = 0; $modernLabelIndex < $modernLabelCount; $modernLabelIndex++) {
            $modernSensitivityLabel = $modernSensitivityLabels->get_Item($modernLabelIndex);
            $modernLabelIdentifier = java_values($modernSensitivityLabel->getId());
            $labelAlreadyExists = strcasecmp(
                $modernLabelIdentifier,
                $legacyLabelIdentifier
            ) === 0;

            if ($labelAlreadyExists) {
                break;
            }
        }

        if (!$labelAlreadyExists) {
            $modernSensitivityLabels->add($legacySensitivityLabel);
        }
    }

    $presentation->save("presentation_with_modern_labels.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La migrazione copia gli oggetti etichetta analizzati nella collezione moderna. Non è necessario cancellare tutte le proprietà personalizzate del documento, così i metadati non correlati rimangono intatti. Usa [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save) con [SaveFormat::Pptx](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/) per scrivere i metadati delle etichette moderne in un file PPTX.

## **FAQ**

**L'aggiunta di un tipo di marcatura del contenuto crea un'intestazione, un piè di pagina o una filigrana visibile nelle diapositive?**

No. I valori aggiunti tramite la lista restituita da [SensitivityLabel::getContentMarkTypes](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) descrivono le marcature associate all'etichetta di sensibilità. Non creano testo o forme visibili nella presentazione. Aggiungi separatamente il contenuto della diapositiva corrispondente se il tuo flusso di lavoro deve renderizzare tali marcature.

**Qual è la differenza tra contrassegnare un'etichetta come rimossa e eliminarla dalla collezione?**

Chiamare [SensitivityLabel::setRemoved](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#setRemoved) con `true` mantiene la voce dell'etichetta e registra il suo stato di rimozione. Chiamare [SensitivityLabelCollection::removeAt](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelcollection/#removeAt) elimina la voce dalla collezione moderna. Scegli l'operazione che corrisponde ai requisiti di conservazione dei metadati della tua organizzazione.

**Una presentazione può contenere sia metadati MIP legacy sia etichette di sensibilità moderne?**

Sì. Le etichette legacy possono rimanere nelle proprietà personalizzate del documento mentre le etichette moderne sono disponibili tramite [Presentation::getSensitivityLabels](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getSensitivityLabels). Usa [DocumentProperties::getSensitivityLabels](https://reference.aspose.com/slides/it/php-java/aspose.slides/documentproperties/#getSensitivityLabels) per leggere i metadati legacy e migrare solo le etichette valide che non sono già presenti nella collezione moderna.

**Cosa succede quando un'etichetta con lo stesso identificatore viene aggiunta più di una volta?**

[SensitivityLabelCollection::add](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabelcollection/#add) genera un'eccezione quando la collezione contiene già un'etichetta con lo stesso identificatore. Controlla i valori esistenti restituiti da [SensitivityLabel::getId](https://reference.aspose.com/slides/it/php-java/aspose.slides/sensitivitylabel/#getId) prima di aggiungere o migrare le etichette.

**Quale formato di output dovrebbe essere usato per preservare le etichette di sensibilità aggiornate?**

Salva la presentazione come PPTX chiamando [Presentation::save](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#save) con [SaveFormat::Pptx](https://reference.aspose.com/slides/it/php-java/aspose.slides/saveformat/), come mostrato negli esempi sopra.