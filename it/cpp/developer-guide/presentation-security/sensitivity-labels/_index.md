---
title: Gestire le etichette di sensibilità nelle presentazioni PowerPoint in C++
linktitle: Etichette di sensibilità
type: docs
weight: 50
url: /it/cpp/sensitivity-labels/
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
- sicurezza delle presentazioni
- C++
- Aspose.Slides
description: "Leggi, aggiungi, aggiorna, rimuovi e migra le etichette di sensibilità di Microsoft Purview nelle presentazioni PPTX PowerPoint con Aspose.Slides per C++."
---
## **Panoramica**

Le etichette di sensibilità di Microsoft Purview aiutano le organizzazioni a classificare e governare i documenti. Durante l'elaborazione automatizzata delle presentazioni, un'applicazione potrebbe dover conservare un'etichetta esistente, applicare un'etichetta selezionata da un criterio, aggiornare il suo stato o migrare i metadati dell'etichetta scritti da un flusso di lavoro Microsoft Information Protection (MIP) più vecchio.

Aspose.Slides espone i metadati delle etichette di sensibilità moderne tramite [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Questo metodo restituisce un [ISensitivityLabelCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabelcollection/) che può essere ispezionato e modificato prima che la presentazione venga salvata come PPTX.

{{% alert color="primary" title="Note" %}}
Gli identificatori delle etichette di sensibilità e le informazioni di criterio sono definiti dalla tua configurazione di Microsoft Purview. Convalida la disponibilità delle etichette e i requisiti di criterio nel tuo ambiente prima di aggiungere o migrare i metadati. I valori di [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) descrivono le marcature di contenuto associate a un'etichetta; non aggiungono di per sé testo o forme visibili alle diapositive.
{{% /alert %}}

## **Comprendere le proprietà delle etichette di sensibilità**

Ogni [ISensitivityLabel](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/) contiene i seguenti metadati:

| Accessors | Scopo |
| --- | --- |
| [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/get_id/), [ISensitivityLabel::set_Id](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/set_id/) | Identifica l'etichetta di sensibilità nella politica di Purview. |
| [ISensitivityLabel::get_SiteId](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/get_siteid/), [ISensitivityLabel::set_SiteId](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/set_siteid/) | Identifica il sito associato al criterio dell'etichetta. |
| [ISensitivityLabel::get_IsEnabled](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/get_isenabled/), [ISensitivityLabel::set_IsEnabled](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/set_isenabled/) | Indica se l'etichetta è abilitata. |
| [ISensitivityLabel::get_IsRemoved](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/get_isremoved/), [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/set_isremoved/) | Indica che l'etichetta è stata rimossa. Imposta il valore su `true` quando lo stato di rimozione deve essere conservato nei metadati. |
| [ISensitivityLabel::get_AssignmentMethodType](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/get_assignmentmethodtype/), [ISensitivityLabel::set_AssignmentMethodType](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/set_assignmentmethodtype/) | Specifica se l'etichetta è stata applicata automaticamente o tramite una decisione dell'utente. |
| [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) | Elenca i tipi di marcatura del contenuto associati all'etichetta. |

L'enumerazione [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/it/cpp/aspose.slides/sensitivitylabelassignmenttype/) descrive come un'etichetta è stata assegnata:

- [SensitivityLabelAssignmentType::Standard](https://reference.aspose.com/slides/it/cpp/aspose.slides/sensitivitylabelassignmenttype/) rappresenta un'etichetta predefinita o applicata automaticamente.  
- [SensitivityLabelAssignmentType::Privileged](https://reference.aspose.com/slides/it/cpp/aspose.slides/sensitivitylabelassignmenttype/) rappresenta un'etichetta applicata tramite una decisione dell'utente, includendo etichette applicate manualmente, consigliate e obbligatorie.

L'enumerazione [SensitivityLabelContentType](https://reference.aspose.com/slides/it/cpp/aspose.slides/sensitivitylabelcontenttype/) identifica la marcatura associata a un'etichetta:

| Valore | Significato |
| --- | --- |
| [SensitivityLabelContentType::None](https://reference.aspose.com/slides/it/cpp/aspose.slides/sensitivitylabelcontenttype/) | L'etichetta è stata applicata per impostazione predefinita o automaticamente. |
| [SensitivityLabelContentType::Header](https://reference.aspose.com/slides/it/cpp/aspose.slides/sensitivitylabelcontenttype/) | La marcatura del contenuto dell'intestazione è associata all'etichetta. |
| [SensitivityLabelContentType::Footer](https://reference.aspose.com/slides/it/cpp/aspose.slides/sensitivitylabelcontenttype/) | La marcatura del contenuto del piè di pagina è associata all'etichetta. |
| [SensitivityLabelContentType::Watermark](https://reference.aspose.com/slides/it/cpp/aspose.slides/sensitivitylabelcontenttype/) | La marcatura del contenuto della filigrana è associata all'etichetta. |
| [SensitivityLabelContentType::Encryption](https://reference.aspose.com/slides/it/cpp/aspose.slides/sensitivitylabelcontenttype/) | La protezione di crittografia è associata all'etichetta. |

Tipi di marcatura multipli possono essere associati a un'unica etichetta.

## **Elencare le etichette di sensibilità esistenti**

Leggi la collezione di etichette moderne da [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/get_sensitivitylabels/) e enumerala. L'esempio seguente elenca ogni proprietà e marcatura del contenuto memorizzata per ciascuna etichetta:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <system/collections/ilist.h>
#include <system/console.h>
#include <system/guid.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Presentation;
using System::Console;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    auto siteIdentifier = sensitivityLabel->get_SiteId();
    auto isEnabled = sensitivityLabel->get_IsEnabled();
    auto isRemoved = sensitivityLabel->get_IsRemoved();
    auto assignmentMethod = sensitivityLabel->get_AssignmentMethodType();

    Console::WriteLine(u"Label ID: {0}", labelIdentifier);
    Console::WriteLine(u"Site ID: {0}", siteIdentifier);
    Console::WriteLine(u"Enabled: {0}", isEnabled);
    Console::WriteLine(u"Removed: {0}", isRemoved);
    Console::WriteLine(u"Assignment method: {0}", assignmentMethod);

    for (auto contentMarkType : sensitivityLabel->get_ContentMarkTypes())
    {
        Console::WriteLine(u"Content marking: {0}", contentMarkType);
    }
}

presentation->Dispose();
```

## **Aggiungere un'etichetta di sensibilità con marcatura del contenuto**

Utilizza [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabelcollection/add/) con l'identificatore dell'etichetta, l'identificatore del sito, lo stato abilitato e il metodo di assegnazione. Dopo che il metodo restituisce il nuovo [ISensitivityLabel](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/), aggiungi i valori di marcatura richiesti tramite [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/).

L'esempio seguente aggiunge un'etichetta selezionata manualmente associata a marcature di piè di pagina e filigrana, quindi salva il risultato come PPTX:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <DOM/SensitivityLabelContentType.h>
#include <Export/SaveFormat.h>
#include <system/collections/ilist.h>
#include <system/guid.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::SensitivityLabelContentType;
using Aspose::Slides::Export::SaveFormat;
using System::Guid;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();

auto labelIdentifier = u"{11111111-2222-3333-4444-555555555555}";
auto siteIdentifier = Guid::Parse(u"{aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee}");
bool isEnabled = true;
auto assignmentMethod = SensitivityLabelAssignmentType::Privileged;

auto sensitivityLabel = sensitivityLabels->Add(
    labelIdentifier,
    siteIdentifier,
    isEnabled,
    assignmentMethod);

sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Footer);
sensitivityLabel->get_ContentMarkTypes()->Add(SensitivityLabelContentType::Watermark);

presentation->Save(u"presentation_with_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Aggiornare un'etichetta di sensibilità**

I valori di [ISensitivityLabel](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/) sono leggibili/scrivibili tramite i loro metodi getter e setter, eccetto che la collezione restituita da [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) è modificata attraverso le sue operazioni di lista. Dopo aver individuato l'etichetta necessaria, puoi aggiornare il suo identificatore, l'identificatore del sito, lo stato abilitato, il metodo di assegnazione, lo stato di rimozione e i tipi di marcatura del contenuto. Salva la presentazione per rendere permanenti le modifiche.

L'esempio seguente aggiorna lo stato abilitato e il metodo di assegnazione della prima etichetta:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <DOM/SensitivityLabelAssignmentType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::SensitivityLabelAssignmentType;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
int labelCount = sensitivityLabels->get_Count();

if (labelCount > 0)
{
    auto sensitivityLabel = sensitivityLabels->idx_get(0);
    sensitivityLabel->set_IsEnabled(true);
    sensitivityLabel->set_AssignmentMethodType(SensitivityLabelAssignmentType::Privileged);
}

presentation->Save(u"presentation_with_updated_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Contrassegnare un'etichetta di sensibilità come rimossa**

Per conservare il fatto che un'etichetta è stata rimossa, individua l'etichetta e chiama [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/set_isremoved/) con `true`. Questo mantiene la voce dell'etichetta registrando il suo stato di rimozione. Se invece devi eliminare una voce dalla collezione moderna, usa [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabelcollection/removeat/); usa [ISensitivityLabelCollection::Clear](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabelcollection/clear/) per cancellare tutte le voci.

L'esempio seguente contrassegna un'etichetta specifica come rimossa e salva la presentazione aggiornata:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto sensitivityLabels = presentation->get_SensitivityLabels();
auto targetLabelIdentifier = u"{11111111-2222-3333-4444-555555555555}";

for (auto&& sensitivityLabel : sensitivityLabels)
{
    auto labelIdentifier = sensitivityLabel->get_Id();
    bool isTargetLabel = String::Equals(
        labelIdentifier,
        targetLabelIdentifier,
        StringComparison::OrdinalIgnoreCase);

    if (isTargetLabel)
    {
        sensitivityLabel->set_IsRemoved(true);
        break;
    }
}

presentation->Save(u"presentation_with_removed_label.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Leggere e migrare le etichette di sensibilità MIP legacy**

I flussi di lavoro basati su MIP più vecchi possono memorizzare i metadati delle etichette di sensibilità in proprietà personalizzate del documento anziché nella collezione di etichette moderna. Leggi tali metadati con [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/it/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/). Il metodo analizza le proprietà personalizzate legacy e restituisce un array di oggetti [ISensitivityLabel](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/).

Per migrare i metadati, aggiungi ciascuna etichetta restituita alla moderna [ISensitivityLabelCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabelcollection/) tramite [ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabelcollection/add/). Poiché l'aggiunta di un identificatore di etichetta duplicato genera un'eccezione, l'esempio controlla la collezione di destinazione prima di copiare ogni etichetta. Puoi aggiungere ulteriori validazioni per confermare che ogni etichetta legacy esista ancora nella politica Purview corrente.

```cpp
#include <DOM/Presentation.h>
#include <DOM/IDocumentProperties.h>
#include <DOM/ISensitivityLabel.h>
#include <DOM/ISensitivityLabelCollection.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;
using System::String;
using System::StringComparison;

auto presentation = MakeObject<Presentation>(u"presentation_with_legacy_labels.pptx");
auto documentProperties = presentation->get_DocumentProperties();
auto legacySensitivityLabels = documentProperties->GetSensitivityLabels();
auto modernSensitivityLabels = presentation->get_SensitivityLabels();

for (auto&& legacySensitivityLabel : legacySensitivityLabels)
{
    bool labelAlreadyExists = false;
    auto legacyLabelIdentifier = legacySensitivityLabel->get_Id();

    for (auto&& modernSensitivityLabel : modernSensitivityLabels)
    {
        auto modernLabelIdentifier = modernSensitivityLabel->get_Id();
        labelAlreadyExists = String::Equals(
            modernLabelIdentifier,
            legacyLabelIdentifier,
            StringComparison::OrdinalIgnoreCase);

        if (labelAlreadyExists)
        {
            break;
        }
    }

    if (!labelAlreadyExists)
    {
        modernSensitivityLabels->Add(legacySensitivityLabel);
    }
}

presentation->Save(u"presentation_with_modern_labels.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La migrazione copia gli oggetti etichetta analizzati nella collezione moderna. Non è necessario cancellare tutte le proprietà personalizzate del documento, quindi i metadati non correlati rimangono intatti. Usa [IPresentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/save/) con [SaveFormat::Pptx](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveformat/) per scrivere i metadati delle etichette moderne in un file PPTX.

## **FAQ**

**Aggiungere un tipo di marcatura del contenuto crea un'intestazione, un piè di pagina o una filigrana visibile nelle diapositive?**

No. I valori aggiunti tramite [ISensitivityLabel::get_ContentMarkTypes](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/get_contentmarktypes/) descrivono le marcature associate all'etichetta di sensibilità. Non creano testo o forme visibili nella presentazione. Aggiungi il contenuto delle diapositive corrispondente separatamente se il tuo flusso di lavoro deve visualizzare quelle marcature.

**Qual è la differenza tra contrassegnare un'etichetta come rimossa e eliminarla dalla collezione?**

Chiamare [ISensitivityLabel::set_IsRemoved](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/set_isremoved/) con `true` mantiene la voce dell'etichetta e registra il suo stato di rimozione. Chiamare [ISensitivityLabelCollection::RemoveAt](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabelcollection/removeat/) elimina la voce dalla collezione moderna. Scegli l'operazione che corrisponde ai requisiti di conservazione dei metadati della tua organizzazione.

**Una presentazione può contenere sia metadati MIP legacy sia etichette di sensibilità moderne?**

Sì. Le etichette legacy possono rimanere nelle proprietà personalizzate del documento mentre le etichette moderne sono disponibili tramite [IPresentation::get_SensitivityLabels](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/get_sensitivitylabels/). Usa [IDocumentProperties::GetSensitivityLabels](https://reference.aspose.com/slides/it/cpp/aspose.slides/idocumentproperties/getsensitivitylabels/) per leggere i metadati legacy e migrare solo le etichette valide che non sono già presenti nella collezione moderna.

**Cosa succede quando un'etichetta con lo stesso identificatore viene aggiunta più volte?**

[ISensitivityLabelCollection::Add](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabelcollection/add/) genera un'eccezione di argomento quando la collezione contiene già un'etichetta con lo stesso identificatore. Controlla i valori esistenti di [ISensitivityLabel::get_Id](https://reference.aspose.com/slides/it/cpp/aspose.slides/isensitivitylabel/get_id/) prima di aggiungere o migrare le etichette.

**Quale formato di output dovrebbe essere usato per conservare le etichette di sensibilità aggiornate?**

Salva la presentazione come PPTX chiamando [IPresentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/ipresentation/save/) con [SaveFormat::Pptx](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveformat/), come mostrato negli esempi sopra.