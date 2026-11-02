---
title: Gestire le proprietà della presentazione in Java
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/java/presentation-properties/
keywords:
- Proprietà di PowerPoint
- Proprietà della presentazione
- Proprietà del documento
- Proprietà integrate
- Proprietà personalizzate
- Proprietà avanzate
- Gestire le proprietà
- Modificare le proprietà
- Metadati del documento
- Modificare i metadati
- Lingua di revisione
- Lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Gestisci le proprietà delle presentazioni in Aspose.Slides per Java e ottimizza la ricerca, il branding e il flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides per Java supporta le proprietà del documento **predefinite** e **personalizzate**. Utilizza queste proprietà per leggere e aggiornare i metadati della presentazione, come l'autore, il titolo e i valori definiti dall'utente.

Aspose.Slides consente di lavorare con le proprietà del documento della presentazione tramite l'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/). Un'istanza di questa interfaccia è restituita da [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--). I seguenti esempi mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Note" %}}
Aspose.Slides gestisce i metadati dell'applicazione e del produttore durante il salvataggio delle presentazioni; questi campi identificano il software che ha creato il risultato.
{{% /alert %}}

## **Gestire le proprietà della presentazione**

Le proprietà del documento memorizzano informazioni descrittive accanto al contenuto della presentazione. Si suddividono in due categorie:

- **Proprietà predefinite** contengono metadati standard, come il titolo, l'autore e le statistiche del documento.
- **Proprietà personalizzate** memorizzano coppie nome/valore definite dall'utente.

Aspose.Slides per Java fornisce l'accesso a entrambe le categorie. In PowerPoint, seleziona **File → Info → Proprietà → Proprietà avanzate** per ispezionare i metadati del documento. La finestra di dialogo raggruppa le informazioni in schede come **Riepilogo**, **Statistiche**, **Contenuti** e **Personalizzato**. Usa la scheda **Personalizzato** per gestire le proprietà definite dall'utente.

## **Leggere le proprietà pubbliche da una presentazione crittografata**

Una password di apertura normalmente protegge sia il contenuto della presentazione sia le proprietà del documento. Quando una presentazione è crittografata dopo aver chiamato [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) con `false`, le sue proprietà del documento rimangono pubbliche. Un'applicazione può quindi chiamare [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) con `true` e leggere i metadati pubblici senza fornire la password di apertura.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) controlla cosa Aspose.Slides carica; non decritta nulla. Se le proprietà fossero state incluse nella crittografia, il loro caricamento senza password fallisce. Se la presentazione non è crittografata, l'opzione viene ignorata e la presentazione completa viene caricata.

L'esempio richiede una presentazione crittografata le cui proprietà del documento sono state lasciate pubbliche. Verifica la modalità di caricamento tramite [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) e poi legge le proprietà predefinite tramite [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties documentProperties = presentation.getDocumentProperties();

        System.out.println("Author: " + documentProperties.getAuthor());
        System.out.println("Title: " + documentProperties.getTitle());
        System.out.println("Keywords: " + documentProperties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

In questa modalità, il contenuto delle diapositive non viene caricato. Diapositive, master, layout, forme, media e altri oggetti della presentazione non sono disponibili. Le applicazioni dovrebbero sempre verificare [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) prima di eseguire un'operazione che richiede il modello completo degli oggetti della presentazione.

{{% alert color="warning" title="Warning" %}}
I metadati pubblici possono rivelare nomi degli autori, titoli, soggetti, parole‑chiave, informazioni aziendali, commenti e valori personalizzati. Crittografa le proprietà sensibili insieme alla presentazione. Lasciale pubbliche solo quando indicizzazione, classificazione, ricerca o sistemi di gestione documentale hanno requisiti specifici per accedervi senza password.
{{% /alert %}}

## **Aggiornare le proprietà di una presentazione crittografata**

Per un file PPTX crittografato, una presentazione caricata dopo aver chiamato [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) con `true` è destinata alla lettura dei metadati pubblici. Aspose.Slides non può salvare le proprietà modificate da quell'oggetto a soli metadati perché le proprietà pubbliche devono rimanere coerenti con i dati corrispondenti all'interno della presentazione crittografata. L'aggiornamento richiede quindi la password di apertura corretta e un caricamento completo.

L'esempio richiede una presentazione PPTX crittografata con proprietà del documento pubbliche e una password di apertura nota. Apre la presentazione completa con [LoadOptions.setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), aggiorna le proprietà predefinite pubbliche e salva il risultato. Quindi utilizza [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) per verificare che la crittografia sia preservata e riapre i metadati pubblici senza password per verificare i nuovi valori:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");

    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Se un'applicazione non è autorizzata a decrittare o a caricare il contenuto della presentazione, deve trattare le proprietà pubbliche di un file PPTX crittografato come sola lettura.

## **Accedere alle proprietà predefinite**

L'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/) espone i metadati predefiniti tramite metodi getter, inclusi [getAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getAuthor--), [getTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getTitle--) e [getCreatedTime](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCreatedTime--). Questo esempio apre una presentazione esistente e stampa i metadati memorizzati sulla console. I valori dipendono dalla presentazione di input; alcuni campi possono essere vuoti.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    System.out.println("Category: " + documentProperties.getCategory());
    System.out.println("Content status: " + documentProperties.getContentStatus());
    System.out.println("Creation date: " + documentProperties.getCreatedTime());
    System.out.println("Author: " + documentProperties.getAuthor());
    System.out.println("Comments: " + documentProperties.getComments());
    System.out.println("Keywords: " + documentProperties.getKeywords());
    System.out.println("Last modified by: " + documentProperties.getLastSavedBy());
    System.out.println("Manager: " + documentProperties.getManager());
    System.out.println("Modified date: " + documentProperties.getLastSavedTime());
    System.out.println("Presentation format: " + documentProperties.getPresentationFormat());
    System.out.println("Last print date: " + documentProperties.getLastPrinted());
    System.out.println("Is shared between producers: " + documentProperties.getSharedDoc());
    System.out.println("Subject: " + documentProperties.getSubject());
    System.out.println("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Modificare le proprietà predefinite**

Per aggiornare i metadati predefiniti, utilizza i metodi setter sull'oggetto restituito da [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDocumentProperties--). Questo esempio apre una presentazione esistente, chiama [setAuthor](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setAuthor-java.lang.String-), [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setTitle-java.lang.String-), [setSubject](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setSubject-java.lang.String-), [setComments](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setComments-java.lang.String-), e [setManager](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setManager-java.lang.String-), quindi salva la presentazione aggiornata con [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Il PPTX salvato contiene i nuovi metadati.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gestire la base dei collegamenti ipertestuali**

[IDocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getHyperlinkBase--) restituisce la base a livello di documento per i collegamenti ipertestuali relativi. Usa [IDocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#setHyperlinkBase-java.lang.String-) per cambiarla o cancellarla. Questo è utile quando si sposta una presentazione e i file collegati in un'altra posizione. È separato dal collegamento ipertestuale individuale [IHyperlink.getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--): modificare la base non riscrive gli indirizzi dei collegamenti memorizzati né cambia le destinazioni assolute.

L'esempio richiede una presentazione contenente sia un collegamento relativo, ad esempio `target.html`, sia un collegamento assoluto, ad esempio `https://example.org/absolute.html`. Legge la base esistente, assegna un nuovo indirizzo di base e salva e riapre la presentazione per verificare il valore. Quindi cancella la base con una stringa vuota e verifica il valore vuoto in un file salvato separatamente. Sostituisci l'indirizzo di base di esempio con la posizione dei tuoi file collegati.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("hyperlinks.pptx");
try {
    System.out.println("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    final String newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx);

    Presentation updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        System.out.println("Base preserved: " + newBase.equals(updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

        Presentation clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            System.out.println("Base cleared: " + "".equals(clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

I due messaggi di verifica dovrebbero stampare `true`. Cancellare la base lascia intatti gli indirizzi dei collegamenti individuali.

Un collegamento relativo a `target.pptx` apriva `old/target.pptx` quando la base puntava alla cartella `old`. Dopo aver cambiato la base nella cartella `new`, salvato e riaperto la presentazione, lo stesso collegamento apriva `new/target.pptx`. Un collegamento assoluto ha continuato ad aprire lo stesso file. Prova i tuoi collegamenti relativi in PowerPoint prima e dopo aver spostato la presentazione o cambiato la sua base.

## **Aggiungere proprietà personalizzate alla presentazione**

Le proprietà personalizzate memorizzano metadati che non hanno un campo predefinito corrispondente. Il metodo [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-) consente di assegnare un valore mediante il nome della proprietà. Questo esempio crea una presentazione, aggiunge due valori di testo e un valore intero di versione, e salva la presentazione con [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Assegnare un valore a un nome esistente sostituisce il valore di quella proprietà.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Accedere e modificare le proprietà personalizzate**

Questo esempio apre una presentazione contenente proprietà personalizzate e usa [getCountOfCustomProperties](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCountOfCustomProperties--) per iterarle. [getCustomPropertyName](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#getCustomPropertyName-int-) accetta un indice basato su zero e restituisce il nome usato da [IDocumentProperties.set_Item](https://reference.aspose.com/slides/java/com.aspose.slides/idocumentproperties/#set-Item-java.lang.String-java.lang.Object-). L'esempio stampa ogni nome e valore originale, sostituisce ogni valore con una stringa numerata indipendentemente dal tipo originale e salva le modifiche. Se non ci sono proprietà personalizzate, il ciclo non apporta modifiche.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    for (int i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        String propertyName = documentProperties.getCustomPropertyName(i);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println("Custom property name: " + propertyName);
        System.out.println("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Esempio live**

Prova l'app online [**Visualizza e modifica i metadati PowerPoint**](https://products.aspose.app/slides/metadata) per vedere come lavorare con le proprietà del documento usando l'API Aspose.Slides:

[![Visualizza e modifica i metadati PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Come posso rimuovere una proprietà predefinita da una presentazione?**

Le proprietà predefinite fanno parte integrante della presentazione e non possono essere rimosse del tutto. Tuttavia, è possibile modificare i loro valori o impostarle vuote se la proprietà lo consente.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se aggiungi una proprietà personalizzata che esiste già, il valore esistente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì. Usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) e poi [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) per leggere i metadati del documento memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/). Vedi [Crea un inventario leggero della presentazione](/slides/it/java/examine-presentation/) per un esempio completo di reportistica e limitazioni specifiche del formato.

**Posso leggere le proprietà pubbliche di una presentazione crittografata senza la sua password di apertura?**

Sì. La presentazione deve essere stata crittografata dopo aver chiamato [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) con `false`, e deve essere caricata dopo aver chiamato [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) con `true`.

**Posso aggiornare un file PPTX crittografato in modalità solo proprietà del documento?**

No. I dati delle proprietà pubbliche e crittografate devono rimanere coerenti, quindi l'aggiornamento di un file PPTX crittografato richiede il caricamento della presentazione completa con la password di apertura corretta.