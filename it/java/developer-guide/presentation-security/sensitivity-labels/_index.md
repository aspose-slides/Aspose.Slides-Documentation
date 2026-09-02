---
title: Gestire le etichette di sensibilità nelle presentazioni PowerPoint in Java
linktitle: Etichette di sensibilità
type: docs
weight: 50
url: /it/java/sensitivity-labels/
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
- Java
- Aspose.Slides
description: "Leggi, aggiungi, aggiorna, rimuovi e migra le etichette di sensibilità Microsoft Purview nelle presentazioni PowerPoint PPTX con Aspose.Slides per Java."
---
## **Panoramica**

Microsoft Purview sensitivity labels aiutano le organizzazioni a classificare e gestire i documenti. Durante l'elaborazione automatica delle presentazioni, un'applicazione potrebbe dover preservare un'etichetta esistente, applicare un'etichetta selezionata da una politica, aggiornarne lo stato o migrare i metadati dell'etichetta scritti da un flusso di lavoro Microsoft Information Protection (MIP) più vecchio.

Aspose.Slides espone i metadati delle etichette di sensibilità moderne tramite [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Questo metodo restituisce una [ISensitivityLabelCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabelcollection/) che può essere ispezionata e modificata prima che la presentazione venga salvata come PPTX.

{{% alert color="primary" title="Note" %}}

Gli identificatori delle etichette di sensibilità e le informazioni sulla politica sono definiti dalla configurazione di Microsoft Purview. Convalida la disponibilità delle etichette e i requisiti della politica nel tuo ambiente prima di aggiungere o migrare i metadati. I valori di [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) descrivono le marcature di contenuto associate a un'etichetta; non aggiungono di per sé testo o forme visibili alle diapositive.

{{% /alert %}}

## **Comprendere le proprietà delle etichette di sensibilità**

Ogni [ISensitivityLabel](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/) contiene i seguenti metadati:

| Metodi | Scopo |
| --- | --- |
| [ISensitivityLabel.getId](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#getId--) e [ISensitivityLabel.setId](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#setId-java.lang.String-) | Recupera o imposta l'identificatore dell'etichetta di sensibilità nella politica Purview. |
| [ISensitivityLabel.getSiteId](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#getSiteId--) e [ISensitivityLabel.setSiteId](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#setSiteId-java.util.UUID-) | Recupera o imposta il sito associato alla politica dell'etichetta. |
| [ISensitivityLabel.isEnabled](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#isEnabled--) e [ISensitivityLabel.setEnabled](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#setEnabled-boolean-) | Recupera o imposta se l'etichetta è abilitata. |
| [ISensitivityLabel.isRemoved](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#isRemoved--) e [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) | Recupera o imposta se l'etichetta è stata rimossa. Imposta il valore su `true` quando lo stato di rimozione deve essere conservato nei metadati. |
| [ISensitivityLabel.getAssignmentMethodType](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#getAssignmentMethodType--) e [ISensitivityLabel.setAssignmentMethodType](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#setAssignmentMethodType-int-) | Recupera o imposta se l'etichetta è stata applicata automaticamente o tramite una decisione dell'utente. |
| [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) | Recupera i tipi di marcatura del contenuto associati all'etichetta. |

La classe [SensitivityLabelAssignmentType](https://reference.aspose.com/slides/it/java/com.aspose.slides/sensitivitylabelassignmenttype/) definisce come è stata assegnata un'etichetta:

- [SensitivityLabelAssignmentType.Standard](https://reference.aspose.com/slides/it/java/com.aspose.slides/sensitivitylabelassignmenttype/) rappresenta un'etichetta predefinita o applicata automaticamente.
- [SensitivityLabelAssignmentType.Privileged](https://reference.aspose.com/slides/it/java/com.aspose.slides/sensitivitylabelassignmenttype/) rappresenta un'etichetta applicata tramite una decisione dell'utente, inclusa l'applicazione manuale, le etichette consigliate e obbligatorie.

La classe [SensitivityLabelContentType](https://reference.aspose.com/slides/it/java/com.aspose.slides/sensitivitylabelcontenttype/) definisce la marcatura associata a un'etichetta:

| Valore | Significato |
| --- | --- |
| [SensitivityLabelContentType.None](https://reference.aspose.com/slides/it/java/com.aspose.slides/sensitivitylabelcontenttype/) | L'etichetta è stata applicata per impostazione predefinita o automaticamente. |
| [SensitivityLabelContentType.Header](https://reference.aspose.com/slides/it/java/com.aspose.slides/sensitivitylabelcontenttype/) | La marcatura del contenuto dell'intestazione è associata all'etichetta. |
| [SensitivityLabelContentType.Footer](https://reference.aspose.com/slides/it/java/com.aspose.slides/sensitivitylabelcontenttype/) | La marcatura del contenuto del piè di pagina è associata all'etichetta. |
| [SensitivityLabelContentType.Watermark](https://reference.aspose.com/slides/it/java/com.aspose.slides/sensitivitylabelcontenttype/) | La marcatura del contenuto del filigrana è associata all'etichetta. |
| [SensitivityLabelContentType.Encryption](https://reference.aspose.com/slides/it/java/com.aspose.slides/sensitivitylabelcontenttype/) | La protezione di crittografia è associata all'etichetta. |

È possibile associare più tipi di marcatura a un'unica etichetta.

## **Elencare le etichette di sensibilità esistenti**

Leggi la collezione di etichette moderne da [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#getSensitivityLabels--) e enumerala. L'esempio seguente elenca ogni proprietà e marcatura del contenuto memorizzata per ciascuna etichetta:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        System.out.println("Label ID: " + sensitivityLabel.getId());
        System.out.println("Site ID: " + sensitivityLabel.getSiteId());
        System.out.println("Enabled: " + sensitivityLabel.isEnabled());
        System.out.println("Removed: " + sensitivityLabel.isRemoved());
        System.out.println("Assignment method: " + sensitivityLabel.getAssignmentMethodType());

        for (Integer contentMarkType : sensitivityLabel.getContentMarkTypes()) {
            System.out.println("Content marking: " + contentMarkType);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Aggiungere un'etichetta di sensibilità con marcatura del contenuto**

Utilizza [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) con l'identificatore dell'etichetta, l'identificatore del sito, lo stato abilitato e il metodo di assegnazione. Dopo che il metodo restituisce il nuovo [ISensitivityLabel](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/), aggiungi i valori di marcatura richiesti tramite l'elenco restituito da [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--).

L'esempio seguente aggiunge un'etichetta selezionata manualmente associata a marcature di piè di pagina e filigrana, quindi salva il risultato come PPTX:

```java
import com.aspose.slides.*;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    String labelIdentifier = "{11111111-2222-3333-4444-555555555555}";
    UUID siteIdentifier = UUID.fromString("aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee");
    boolean isEnabled = true;
    int assignmentMethod = SensitivityLabelAssignmentType.Privileged;

    ISensitivityLabel sensitivityLabel = sensitivityLabels.add(
            labelIdentifier,
            siteIdentifier,
            isEnabled,
            assignmentMethod);

    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Footer);
    sensitivityLabel.getContentMarkTypes().addItem(SensitivityLabelContentType.Watermark);

    presentation.save("presentation_with_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aggiornare un'etichetta di sensibilità**

I valori di [ISensitivityLabel](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/) sono leggibili/scrivibili, eccetto che l'elenco restituito da [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) viene modificato tramite le sue operazioni di lista. Dopo aver individuato l'etichetta necessaria, è possibile aggiornare il suo identificatore, l'identificatore del sito, lo stato abilitato, il metodo di assegnazione, lo stato di rimozione e i tipi di marcatura del contenuto. Salva la presentazione per rendere permanenti le modifiche.

L'esempio seguente aggiorna lo stato abilitato e il metodo di assegnazione della prima etichetta:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();

    if (sensitivityLabels.getCount() > 0) {
        ISensitivityLabel sensitivityLabel = sensitivityLabels.get_Item(0);
        sensitivityLabel.setEnabled(true);
        sensitivityLabel.setAssignmentMethodType(SensitivityLabelAssignmentType.Privileged);
    }

    presentation.save("presentation_with_updated_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contrassegnare un'etichetta di sensibilità come rimossa**

Per preservare il fatto che un'etichetta è stata rimossa, trova l'etichetta e chiama [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) con `true`. Questo mantiene l'entrata dell'etichetta registrandone lo stato di rimozione. Se invece devi eliminare un'entrata dalla collezione moderna, usa [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-); usa [ISensitivityLabelCollection.clear](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabelcollection/#clear--) per cancellare tutte le voci.

L'esempio seguente contrassegna un'etichetta specifica come rimossa e salva la presentazione aggiornata:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISensitivityLabelCollection sensitivityLabels = presentation.getSensitivityLabels();
    String targetLabelIdentifier = "{11111111-2222-3333-4444-555555555555}";

    for (ISensitivityLabel sensitivityLabel : sensitivityLabels) {
        boolean isTargetLabel = sensitivityLabel.getId().equalsIgnoreCase(targetLabelIdentifier);

        if (isTargetLabel) {
            sensitivityLabel.setRemoved(true);
            break;
        }
    }

    presentation.save("presentation_with_removed_label.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Leggere e migrare le etichette di sensibilità legacy MIP**

I flussi di lavoro basati su MIP più vecchi possono archiviare i metadati delle etichette di sensibilità nelle proprietà personalizzate del documento invece della collezione di etichette moderne. Leggi tali metadati con [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--). Il metodo analizza le proprietà personalizzate legacy e restituisce un array di oggetti [ISensitivityLabel](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/).

Per migrare i metadati, aggiungi ogni etichetta restituita alla moderna [ISensitivityLabelCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabelcollection/) tramite [ISensitivityLabelCollection.add](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabelcollection/#add-com.aspose.slides.ISensitivityLabel-). Poiché aggiungere un identificatore di etichetta duplicato genera un'eccezione, l'esempio verifica la collezione di destinazione prima di copiare ciascuna etichetta. È possibile aggiungere ulteriori convalide per confermare che ogni etichetta legacy esista ancora nella politica Purview corrente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_legacy_labels.pptx");
try {
    ISensitivityLabel[] legacySensitivityLabels = presentation.getDocumentProperties().getSensitivityLabels();
    ISensitivityLabelCollection modernSensitivityLabels = presentation.getSensitivityLabels();

    for (ISensitivityLabel legacySensitivityLabel : legacySensitivityLabels) {
        boolean labelAlreadyExists = false;

        for (ISensitivityLabel modernSensitivityLabel : modernSensitivityLabels) {
            labelAlreadyExists = modernSensitivityLabel.getId().equalsIgnoreCase(
                    legacySensitivityLabel.getId());

            if (labelAlreadyExists) {
                break;
            }
        }

        if (!labelAlreadyExists) {
            modernSensitivityLabels.add(legacySensitivityLabel);
        }
    }

    presentation.save("presentation_with_modern_labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La migrazione copia gli oggetti etichetta analizzati nella collezione moderna. Non è necessario cancellare tutte le proprietà personalizzate del documento, quindi i metadati del documento non correlati rimangono intatti. Usa [IPresentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/java/com.aspose.slides/saveformat/) per scrivere i metadati delle etichette moderne in un file PPTX.

## **FAQ**

**Aggiungere un tipo di marcatura del contenuto crea un'intestazione, un piè di pagina o una filigrana visibile nelle diapositive?**

No. I valori aggiunti tramite l'elenco restituito da [ISensitivityLabel.getContentMarkTypes](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#getContentMarkTypes--) descrivono le marcature associate all'etichetta di sensibilità. Non creano testo o forme visibili nella presentazione. Aggiungi il contenuto della diapositiva corrispondente separatamente se il tuo flusso di lavoro deve renderizzare tali marcature.

**Qual è la differenza tra contrassegnare un'etichetta come rimossa e eliminarla dalla collezione?**

Chiamare [ISensitivityLabel.setRemoved](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#setRemoved-boolean-) con `true` mantiene l'entrata dell'etichetta e ne registra lo stato di rimozione. Chiamare [ISensitivityLabelCollection.removeAt](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabelcollection/#removeAt-int-) elimina l'entrata dalla collezione moderna. Scegli l'operazione che corrisponde ai requisiti di conservazione dei metadati della tua organizzazione.

**Una presentazione può contenere sia metadati MIP legacy che etichette di sensibilità moderne?**

Sì. Le etichette legacy possono rimanere nelle proprietà personalizzate del documento mentre le etichette moderne sono disponibili tramite [IPresentation.getSensitivityLabels](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#getSensitivityLabels--). Usa [IDocumentProperties.getSensitivityLabels](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/#getSensitivityLabels--) per leggere i metadati legacy e migrare solo le etichette valide che non sono già presenti nella collezione moderna.

**Cosa succede quando un'etichetta con lo stesso identificatore viene aggiunta più di una volta?**

[ISensitivityLabelCollection.add](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabelcollection/#add-java.lang.String-java.util.UUID-boolean-int-) genera un'eccezione quando la collezione contiene già un'etichetta con lo stesso identificatore. Verifica i valori esistenti restituiti da [ISensitivityLabel.getId](https://reference.aspose.com/slides/it/java/com.aspose.slides/isensitivitylabel/#getId--) prima di aggiungere o migrare le etichette.

**Quale formato di output dovrebbe essere utilizzato per preservare le etichette di sensibilità aggiornate?**

Salva la presentazione come PPTX chiamando [IPresentation.save](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-) con [SaveFormat.Pptx](https://reference.aspose.com/slides/it/java/com.aspose.slides/saveformat/), come mostrato negli esempi sopra.