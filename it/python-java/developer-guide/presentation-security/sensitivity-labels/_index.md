---
title: Gestire le etichette di sensibilità nelle presentazioni PowerPoint in Python
linktitle: Etichette di sensibilità
type: docs
weight: 50
url: /it/python-java/sensitivity-labels/
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
- Python
- Aspose.Slides
description: "Leggi, aggiungi, aggiorna, rimuovi e migra le etichette di sensibilità Microsoft Purview nelle presentazioni PowerPoint PPTX con Aspose.Slides per Python tramite Java."
---
## **Panoramica**

Microsoft Purview sensitivity labels aiutano le organizzazioni a classificare e governare i documenti. Durante l'elaborazione automatica delle presentazioni, un'applicazione può dover conservare un'etichetta esistente, applicare un'etichetta selezionata da una politica, aggiornare il suo stato o migrare i metadati dell'etichetta scritti da un flusso di lavoro Microsoft Information Protection (MIP) più vecchio.

Aspose.Slides espone i metadati delle etichette di sensibilità moderne tramite [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSensitivityLabels). Questo metodo restituisce una [SensitivityLabelCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelcollection/) che può essere ispezionata e modificata prima che la presentazione venga salvata come PPTX.

{{% alert color="info" title="Nota" %}}

Gli identificatori delle etichette di sensibilità e le informazioni sulla politica sono definiti dalla configurazione di Microsoft Purview. Convalida la disponibilità delle etichette e i requisiti della politica nel tuo ambiente prima di aggiungere o migrare i metadati. I valori di [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) descrivono le marcature di contenuto associate a un'etichetta; non aggiungono di per sé testo o forme visibili alle diapositive.

{{% /alert %}}

## **Comprendere le proprietà delle etichette di sensibilità**

Ogni [SensitivityLabel](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/) contiene i seguenti metadati:

| Metodi | Scopo |
| --- | --- |
| [getId](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#getId) e [setId](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#setId) | Ottieni o imposta l'identificatore dell'etichetta di sensibilità nella politica Purview. |
| [getSiteId](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#getSiteId) e [setSiteId](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#setSiteId) | Ottieni o imposta il sito associato alla politica dell'etichetta. |
| [isEnabled](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#isEnabled) e [setEnabled](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#setEnabled) | Ottieni o imposta se l'etichetta è abilitata. |
| [isRemoved](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#isRemoved) e [setRemoved](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#setRemoved) | Ottieni o imposta se l'etichetta è stata rimossa. Imposta il valore a `True` quando lo stato di rimozione deve essere conservato nei metadati. |
| [getAssignmentMethodType](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#getAssignmentMethodType) e [setAssignmentMethodType](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#setAssignmentMethodType) | Ottieni o imposta se l'etichetta è stata applicata automaticamente o tramite decisione dell'utente. |
| [getContentMarkTypes](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) | Ottieni i tipi di marcatura di contenuto associati all'etichetta. |

La classe [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelassignmenttype/) definisce come un'etichetta è stata assegnata:

- [Standard](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelassignmenttype/) rappresenta un'etichetta predefinita o applicata automaticamente.
- [Privileged](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelassignmenttype/) rappresenta un'etichetta applicata tramite decisione dell'utente, comprese quelle applicate manualmente, consigliate e obbligatorie.

La classe [SensitivityLabelContentType](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelcontenttype/) definisce la marcatura associata a un'etichetta:

| Valore | Significato |
| --- | --- |
| [None](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelcontenttype/) | L'etichetta è stata applicata per impostazione predefinita o automaticamente. |
| [Header](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelcontenttype/) | La marcatura di contenuto dell'intestazione è associata all'etichetta. |
| [Footer](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelcontenttype/) | La marcatura di contenuto del piè di pagina è associata all'etichetta. |
| [Watermark](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelcontenttype/) | La marcatura di contenuto della filigrana è associata all'etichetta. |
| [Encryption](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelcontenttype/) | La protezione crittografica è associata all'etichetta. |

Più tipi di marcatura possono essere associati a una singola etichetta.

## **Elencare le etichette di sensibilità esistenti**

Leggi la raccolta di etichette moderne da [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSensitivityLabels) ed elencala. L'esempio seguente elenca ogni proprietà e marcatura di contenuto memorizzata per ciascuna etichetta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.getId())
        print("Site ID:", sensitivity_label.getSiteId())
        print("Enabled:", sensitivity_label.isEnabled())
        print("Removed:", sensitivity_label.isRemoved())
        print("Assignment method:", sensitivity_label.getAssignmentMethodType())

        for content_mark_type in sensitivity_label.getContentMarkTypes():
            print("Content marking:", content_mark_type)
finally:
    presentation.dispose()
```

## **Aggiungere un'etichetta di sensibilità con marcatura del contenuto**

Usa [SensitivityLabelCollection.add](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelcollection/#add) con l'identificatore dell'etichetta, l'identificatore del sito, lo stato abilitato e il metodo di assegnazione. Dopo che il metodo restituisce la nuova [SensitivityLabel](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/), aggiungi i valori di marcatura richiesti tramite l'elenco restituito da [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes).

L'esempio seguente aggiunge un'etichetta selezionata manualmente associata a marcature di piè di pagina e filigrana, quindi salva il risultato come PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpame.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType, SensitivityLabelContentType
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = SensitivityLabelAssignmentType.Privileged

    sensitivity_label = sensitivity_labels.add(label_identifier, site_identifier, is_enabled, assignment_method)

    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Footer))
    sensitivity_label.getContentMarkTypes().addItem(jpype.JInt(SensitivityLabelContentType.Watermark))

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aggiornare un'etichetta di sensibilità**

I valori di [SensitivityLabel](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/) sono leggibili/scrivibili, eccetto l'elenco restituito da [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) che si modifica tramite le operazioni della sua lista. Dopo aver individuato l'etichetta richiesta, puoi aggiornare il suo identificatore, l'identificatore del sito, lo stato abilitato, il metodo di assegnazione, lo stato di rimozione e i tipi di marcatura del contenuto. Salva la presentazione per rendere persistenti le modifiche.

L'esempio seguente aggiorna lo stato abilitato e il metodo di assegnazione della prima etichetta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SensitivityLabelAssignmentType

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()

    if sensitivity_labels.getCount() > 0:
        sensitivity_label = sensitivity_labels.get_Item(0)
        sensitivity_label.setEnabled(True)
        sensitivity_label.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged)

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Contrassegnare un'etichetta di sensibilità come rimossa**

Per conservare il fatto che un'etichetta è stata rimossa, trova l'etichetta e chiama [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#setRemoved) con `True`. Questo mantiene la voce dell'etichetta registrando il suo stato rimosso. Se invece devi eliminare una voce dalla raccolta moderna, usa [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelcollection/#removeAt); usa [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelcollection/#clear) per cancellare tutte le voci.

L'esempio seguente contrassegna un'etichetta specifica come rimossa e salva la presentazione aggiornata:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    sensitivity_labels = presentation.getSensitivityLabels()
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        is_target_label = str(sensitivity_label.getId()).casefold() == target_label_identifier.casefold()

        if is_target_label:
            sensitivity_label.setRemoved(True)
            break

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Leggere e migrare le etichette di sensibilità MIP legacy**

I flussi di lavoro più vecchi basati su MIP possono memorizzare i metadati delle etichette di sensibilità in proprietà personalizzate del documento invece della raccolta di etichette moderne. Leggi quei metadati con [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#getSensitivityLabels). Il metodo analizza le proprietà personalizzate legacy e restituisce un array di oggetti [SensitivityLabel](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/).

Per migrare i metadati, aggiungi ogni etichetta restituita alla moderna [SensitivityLabelCollection](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelcollection/) tramite [SensitivityLabelCollection.add](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelcollection/#add). Poiché l'aggiunta di un identificatore di etichetta duplicato genera un'eccezione, l'esempio controlla la raccolta di destinazione prima di copiare ciascuna etichetta. È possibile aggiungere ulteriori convalide per confermare che ogni etichetta legacy esista ancora nella politica Purview corrente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation_with_legacy_labels.pptx")
try:
    legacy_sensitivity_labels = presentation.getDocumentProperties().getSensitivityLabels()
    modern_sensitivity_labels = presentation.getSensitivityLabels()

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = str(modern_sensitivity_label.getId()).casefold() == str(legacy_sensitivity_label.getId()).casefold()

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La migrazione copia gli oggetti etichetta analizzati nella raccolta moderna. Non è necessario cancellare tutte le proprietà personalizzate del documento, così i metadati non correlati rimangono intatti. Usa [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/) per scrivere i metadati delle etichette moderne in un file PPTX.

## **FAQ**

**L'aggiunta di un tipo di marcatura del contenuto crea un'intestazione, un piè di pagina o una filigrana visibile sulle diapositive?**

No. I valori aggiunti tramite l'elenco restituito da [SensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#getContentMarkTypes) descrivono le marcature associate all'etichetta di sensibilità. Non creano testo o forme visibili nella presentazione. Aggiungi separatamente il contenuto della diapositiva corrispondente se il tuo flusso di lavoro deve renderizzare tali marcature.

**Qual è la differenza tra contrassegnare un'etichetta come rimossa e cancellarla dalla raccolta?**

Chiamare [SensitivityLabel.setRemoved](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#setRemoved) con `True` mantiene la voce dell'etichetta e registra il suo stato rimosso. Chiamare [SensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelcollection/#removeAt) elimina la voce dalla raccolta moderna. Scegli l'operazione che corrisponde ai requisiti di conservazione dei metadati della tua organizzazione.

**Una presentazione può contenere sia metadati MIP legacy che etichette di sensibilità moderne?**

Sì. Le etichette legacy possono rimanere nelle proprietà personalizzate del documento, mentre le etichette moderne sono disponibili tramite [Presentation.getSensitivityLabels](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#getSensitivityLabels). Usa [DocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/it/python-java/aspose.slides/documentproperties/#getSensitivityLabels) per leggere i metadati legacy e migrare solo le etichette valide che non sono già presenti nella raccolta moderna.

**Cosa accade quando un'etichetta con lo stesso identificatore viene aggiunta più di una volta?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabelcollection/#add) genera un'eccezione quando la raccolta contiene già un'etichetta con lo stesso identificatore. Controlla i valori esistenti restituiti da [SensitivityLabel.getId](https://reference.aspose.com/slides/it/python-java/aspose.slides/sensitivitylabel/#getId) prima di aggiungere o migrare le etichette.

**Quale formato di output dovrebbe essere usato per preservare le etichette di sensibilità aggiornate?**

Salva la presentazione come PPTX chiamando [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/), come mostrato negli esempi sopra.