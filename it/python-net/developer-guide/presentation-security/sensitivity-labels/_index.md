---
title: Gestire le etichette di sensibilità nelle presentazioni PowerPoint in Python
linktitle: Etichette di sensibilità
type: docs
weight: 50
url: /it/python-net/sensitivity-labels/
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
description: "Leggi, aggiungi, aggiorna, rimuovi e migra le etichette di sensibilità Microsoft Purview nelle presentazioni PowerPoint PPTX con Aspose.Slides per Python tramite .NET."
---
## **Panoramica**

Le etichette di sensibilità di Microsoft Purview aiutano le organizzazioni a classificare e gestire i documenti. Durante l'elaborazione automatica delle presentazioni, un'applicazione potrebbe dover preservare un'etichetta esistente, applicare un'etichetta selezionata da una policy, aggiornare il suo stato o migrare i metadati dell'etichetta scritti da un flusso di lavoro Microsoft Information Protection (MIP) più vecchio.

Aspose.Slides for Python via .NET espone i metadati delle etichette di sensibilità moderne tramite [Presentation.sensitivity_labels](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/sensitivity_labels/). Questa proprietà restituisce una [SensitivityLabelCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelcollection/) che può essere esaminata e modificata prima che la presentazione sia salvata come PPTX.

{{% alert color="primary" title="Note" %}}
Gli identificatori delle etichette di sensibilità e le informazioni sulla policy sono definiti dalla configurazione di Microsoft Purview. Convalida la disponibilità delle etichette e i requisiti della policy nel tuo ambiente prima di aggiungere o migrare i metadati. I valori di [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/content_mark_types/) descrivono i marcatori di contenuto associati a un'etichetta; non aggiungono da soli testo o forme visibili alle diapositive.
{{% /alert %}}

## **Comprendere le proprietà dell'etichetta di sensibilità**

Ogni [SensitivityLabel](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/) contiene i seguenti metadati:

| Proprietà | Scopo |
| --- | --- |
| [SensitivityLabel.id](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/id/) | Identifica l'etichetta di sensibilità nella policy di Purview. |
| [SensitivityLabel.site_id](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/site_id/) | Identifica il sito associato alla policy dell'etichetta. |
| [SensitivityLabel.is_enabled](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/is_enabled/) | Indica se l'etichetta è abilitata. |
| [SensitivityLabel.is_removed](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/is_removed/) | Indica che l'etichetta è stata rimossa. Imposta questa proprietà a `True` quando lo stato di rimozione deve essere conservato nei metadati. |
| [SensitivityLabel.assignment_method_type](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/assignment_method_type/) | Specifica se l'etichetta è stata applicata automaticamente o tramite decisione dell'utente. |
| [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/content_mark_types/) | Elenca i tipi di marcatori di contenuto associati all'etichetta. |

L'enumerazione [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelassignmenttype/) descrive come è stata assegnata un'etichetta:

- [SensitivityLabelAssignmentType.STANDARD](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelassignmenttype/) rappresenta un'etichetta predefinita o applicata automaticamente.  
- [SensitivityLabelAssignmentType.PRIVILEGED](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelassignmenttype/) rappresenta un'etichetta applicata tramite decisione dell'utente, inclusi etichette applicate manualmente, consigliate e obbligatorie.  

L'enumerazione [SensitivityLabelContentType](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelcontenttype/) identifica il marcatore associato a un'etichetta:

| Valore | Significato |
| --- | --- |
| [SensitivityLabelContentType.NONE](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelcontenttype/) | L'etichetta è stata applicata per impostazione predefinita o automaticamente. |
| [SensitivityLabelContentType.HEADER](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelcontenttype/) | Il marcatore di contenuto dell'intestazione è associato all'etichetta. |
| [SensitivityLabelContentType.FOOTER](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelcontenttype/) | Il marcatore di contenuto del piè di pagina è associato all'etichetta. |
| [SensitivityLabelContentType.WATERMARK](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelcontenttype/) | Il marcatore di contenuto della filigrana è associato all'etichetta. |
| [SensitivityLabelContentType.ENCRYPTION](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelcontenttype/) | La protezione di crittografia è associata all'etichetta. |

È possibile associare più tipi di marcatori a una singola etichetta.

## **Elencare le etichette di sensibilità esistenti**

Leggi la raccolta di etichette moderne da [Presentation.sensitivity_labels](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/sensitivity_labels/) e iterala. L'esempio seguente elenca ogni proprietà e marcatore di contenuto memorizzato per ciascuna etichetta:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    for sensitivity_label in sensitivity_labels:
        print("Label ID:", sensitivity_label.id)
        print("Site ID:", sensitivity_label.site_id)
        print("Enabled:", sensitivity_label.is_enabled)
        print("Removed:", sensitivity_label.is_removed)
        print("Assignment method:", sensitivity_label.assignment_method_type)

        for content_mark_type in sensitivity_label.content_mark_types:
            print("Content marking:", content_mark_type)
```

## **Aggiungere un'etichetta di sensibilità con marcatore di contenuto**

Usa [SensitivityLabelCollection.add](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelcollection/add/) con l'identificatore dell'etichetta, l'identificatore del sito, lo stato abilitato e il metodo di assegnazione. Passa l'identificatore del sito come oggetto Python `uuid.UUID`. Dopo che il metodo restituisce il nuovo [SensitivityLabel](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/), aggiungi i valori di marcatura richiesti a [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/content_mark_types/).

L'esempio seguente aggiunge un'etichetta selezionata manualmente associata a marcatori di piè di pagina e filigrana, quindi salva il risultato come PPTX:

```python
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    label_identifier = "{11111111-2222-3333-4444-555555555555}"
    site_identifier = uuid.UUID("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee")
    is_enabled = True
    assignment_method = slides.SensitivityLabelAssignmentType.PRIVILEGED

    sensitivity_label = sensitivity_labels.add(
        label_identifier,
        site_identifier,
        is_enabled,
        assignment_method
    )

    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.FOOTER)
    sensitivity_label.content_mark_types.append(slides.SensitivityLabelContentType.WATERMARK)

    presentation.save("presentation_with_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Aggiornare un'etichetta di sensibilità**

Le proprietà del [SensitivityLabel](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/) sono leggibili e scrivibili, eccetto che la lista restituita da [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/content_mark_types/) viene modificata tramite le sue operazioni di lista. Dopo aver individuato l'etichetta necessaria, è possibile aggiornare il suo identificatore, l'identificatore del sito, lo stato abilitato, il metodo di assegnazione, lo stato di rimozione e i tipi di marcatura del contenuto. Salva la presentazione per rendere permanenti le modifiche.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels

    if sensitivity_labels.count > 0:
        sensitivity_label = sensitivity_labels[0]
        sensitivity_label.is_enabled = True
        sensitivity_label.assignment_method_type = (
            slides.SensitivityLabelAssignmentType.PRIVILEGED
        )

    presentation.save("presentation_with_updated_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Contrassegnare un'etichetta di sensibilità come rimossa**

Per conservare il fatto che un'etichetta è stata rimossa, trova l'etichetta e imposta [SensitivityLabel.is_removed](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/is_removed/) su `True`. Questo mantiene la voce dell'etichetta registrando il suo stato di rimozione. Se invece è necessario eliminare una voce dalla raccolta moderna, usa [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelcollection/remove_at/); usa [SensitivityLabelCollection.clear](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelcollection/clear/) per eliminare tutte le voci.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    sensitivity_labels = presentation.sensitivity_labels
    target_label_identifier = "{11111111-2222-3333-4444-555555555555}"

    for sensitivity_label in sensitivity_labels:
        identifiers_match = (
            sensitivity_label.id.casefold() == target_label_identifier.casefold()
        )

        if identifiers_match:
            sensitivity_label.is_removed = True
            break

    presentation.save("presentation_with_removed_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Leggere e migrare le etichette di sensibilità MIP legacy**

I flussi di lavoro basati su MIP più vecchi possono memorizzare i metadati delle etichette di sensibilità in proprietà personalizzate del documento anziché nella raccolta di etichette moderne. Leggi quei metadati con [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/get_sensitivity_labels/). Il metodo analizza le proprietà personalizzate legacy e restituisce oggetti [SensitivityLabel](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/).

Per migrare i metadati, aggiungi ciascuna etichetta restituita alla moderna [SensitivityLabelCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelcollection/) tramite [SensitivityLabelCollection.add](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelcollection/add/). Poiché l'aggiunta di un identificatore di etichetta duplicato genera un'eccezione, l'esempio controlla la raccolta di destinazione prima di copiare ogni etichetta. È possibile aggiungere ulteriori convalide per confermare che ogni etichetta legacy esista ancora nella policy di Purview corrente.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_legacy_labels.pptx") as presentation:
    legacy_sensitivity_labels = (
        presentation.document_properties.get_sensitivity_labels()
    )
    modern_sensitivity_labels = presentation.sensitivity_labels

    for legacy_sensitivity_label in legacy_sensitivity_labels:
        label_already_exists = False

        for modern_sensitivity_label in modern_sensitivity_labels:
            label_already_exists = (
                modern_sensitivity_label.id.casefold()
                == legacy_sensitivity_label.id.casefold()
            )

            if label_already_exists:
                break

        if not label_already_exists:
            modern_sensitivity_labels.add(legacy_sensitivity_label)

    presentation.save("presentation_with_modern_labels.pptx", slides.export.SaveFormat.PPTX)
```

La migrazione copia gli oggetti etichetta analizzati nella raccolta moderna. Non è necessario cancellare tutte le proprietà personalizzate del documento, quindi i metadati non correlati rimangono intatti. Usa [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) con [SaveFormat.PPTX](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/saveformat/) per scrivere i metadati delle etichette moderne in un file PPTX.

## **FAQ**

**L'aggiunta di un tipo di marcatore di contenuto crea un'intestazione, un piè di pagina o una filigrana visibile nelle diapositive?**

No. I valori aggiunti tramite [SensitivityLabel.content_mark_types](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/content_mark_types/) descrivono i marcatori associati all'etichetta di sensibilità. Non creano testo o forme visibili nella presentazione. Aggiungi separatamente il contenuto della diapositiva corrispondente se il tuo flusso di lavoro deve renderizzare tali marcatori.

**Qual è la differenza tra contrassegnare un'etichetta come rimossa e eliminarla dalla raccolta?**

Impostare [SensitivityLabel.is_removed](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/is_removed/) su `True` mantiene la voce dell'etichetta e registra il suo stato di rimozione. Chiamare [SensitivityLabelCollection.remove_at](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelcollection/remove_at/) elimina la voce dalla raccolta moderna. Scegli l'operazione che corrisponde ai requisiti di conservazione dei metadati della tua organizzazione.

**Una presentazione può contenere sia metadati MIP legacy che etichette di sensibilità moderne?**

Sì. Le etichette legacy possono rimanere nelle proprietà personalizzate del documento, mentre le etichette moderne sono disponibili tramite [Presentation.sensitivity_labels](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/sensitivity_labels/). Usa [DocumentProperties.get_sensitivity_labels](https://reference.aspose.com/slides/it/python-net/aspose.slides/documentproperties/get_sensitivity_labels/) per leggere i metadati legacy e migrare solo le etichette valide che non sono già presenti nella raccolta moderna.

**Cosa succede quando la stessa etichetta viene aggiunta più volte?**

[SensitivityLabelCollection.add](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabelcollection/add/) genera un'eccezione se la raccolta contiene già un'etichetta con lo stesso identificatore. Controlla i valori di [SensitivityLabel.id](https://reference.aspose.com/slides/it/python-net/aspose.slides/sensitivitylabel/id/) prima di aggiungere o migrare le etichette.

**Quale formato di output dovrebbe essere usato per conservare le etichette di sensibilità aggiornate?**

Salva la presentazione come PPTX chiamando [Presentation.save](https://reference.aspose.com/slides/it/python-net/aspose.slides/presentation/save/) con [SaveFormat.PPTX](https://reference.aspose.com/slides/it/python-net/aspose.slides.export/saveformat/), come mostrato negli esempi precedenti.