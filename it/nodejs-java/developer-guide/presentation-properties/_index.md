---
title: Gestire le proprietà della presentazione in JavaScript
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/nodejs-java/presentation-properties/
keywords:
- Proprietà PowerPoint
- proprietà della presentazione
- proprietà del documento
- proprietà predefinite
- proprietà personalizzate
- proprietà avanzate
- gestire le proprietà
- modificare le proprietà
- metadati del documento
- modificare i metadati
- lingua di correzione
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci le proprietà della presentazione in Aspose.Slides per Node.js via Java e ottimizza la ricerca, il branding e il flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides per Node.js tramite Java supporta le proprietà del documento **predefinite** e **personalizzate**. Utilizza queste proprietà per leggere e aggiornare i metadati della presentazione, come l'autore, il titolo e i valori definiti dall'utente.

Aspose.Slides ti consente di lavorare con le proprietà del documento della presentazione tramite la classe [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties). Un'istanza di questa classe è restituita da [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). I seguenti esempi mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Note" %}}
Aspose.Slides gestisce i metadati dell'applicazione e del produttore durante il salvataggio delle presentazioni; questi campi identificano il software che ha creato l'output.
{{% /alert %}}

## **Gestire le proprietà della presentazione**

Le proprietà del documento memorizzano informazioni descrittive accanto al contenuto della presentazione. Si dividono in due categorie:

- **Proprietà predefinite** contengono metadati standard, come titolo, autore e statistiche del documento.
- **Proprietà personalizzate** memorizzano coppie nome/valore definite dall'utente.

Aspose.Slides per Node.js tramite Java offre accesso a entrambe le categorie. In PowerPoint, seleziona **File → Info → Properties → Advanced Properties** per ispezionare i metadati del documento. La finestra raggruppa le informazioni in schede come **Riepilogo**, **Statistiche**, **Contenuti** e **Personalizzato**. Usa la scheda **Personalizzato** per gestire le proprietà definite dall'utente.

## **Leggere le proprietà pubbliche da una presentazione crittografata**

Una password di apertura normalmente protegge sia il contenuto della presentazione sia le proprietà del documento. Quando una presentazione viene crittografata dopo aver chiamato [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) con `false`, le sue proprietà del documento rimangono pubbliche. Un'applicazione può quindi chiamare [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) con `true` e leggere i metadati pubblici senza fornire la password di apertura.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) controlla cosa Aspose.Slides carica; non decritta nulla. Se le proprietà sono state incluse nella crittografia, il loro caricamento senza password fallisce. Se la presentazione non è crittografata, l'opzione viene ignorata e viene caricata la presentazione completa.

Il esempio richiede una presentazione crittografata le cui proprietà del documento sono state lasciate pubbliche. Verifica la modalità di caricamento tramite [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) e quindi legge le proprietà predefinite tramite [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

In questa modalità, il contenuto delle diapositive non viene caricato. Diapositive, master, layout, forme, media e altri oggetti della presentazione non sono disponibili. Le applicazioni dovrebbero sempre verificare [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) prima di eseguire un'operazione che richiede il modello di oggetti completo della presentazione.

{{% alert color="warning" title="Warning" %}}
I metadati pubblici possono esporre nomi degli autori, titoli, soggetti, parole‑chiave, informazioni aziendali, commenti e valori personalizzati. Crittografa le proprietà sensibili insieme alla presentazione. Lasciale pubbliche solo quando sistemi di indicizzazione, classificazione, ricerca o gestione documentale hanno un requisito specifico per accedervi senza password.
{{% /alert %}}

## **Aggiornare le proprietà di una presentazione crittografata**

Per un file PPTX crittografato, una presentazione caricata dopo aver chiamato [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) con `true` è destinata alla lettura dei metadati pubblici. Aspose.Slides non può salvare le proprietà modificate da quell'oggetto in sola lettura perché le proprietà pubbliche devono rimanere coerenti con i dati corrispondenti all'interno della presentazione crittografata. L'aggiornamento richiede quindi la password di apertura corretta e un caricamento completo.

L'esempio richiede una presentazione PPTX crittografata con proprietà del documento pubbliche e una password di apertura nota. Apre la presentazione completa con [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword), aggiorna le proprietà predefinite pubbliche e salva il risultato. Usa quindi [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) per verificare che la crittografia sia preservata e riapre i metadati pubblici senza password per verificare i nuovi valori:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

Se un'applicazione non è autorizzata a decrittare o a caricare il contenuto della presentazione, deve trattare le proprietà pubbliche di un file PPTX crittografato come di sola lettura.

## **Accedere alle proprietà predefinite**

La classe [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) espone i metadati predefiniti tramite metodi getter, inclusi [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor), [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) e [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). Questo esempio apre una presentazione esistente e stampa i metadati memorizzati sulla console. I valori dipendono dalla presentazione di input; alcuni campi possono essere vuoti.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **Modificare le proprietà predefinite**

Per aggiornare i metadati predefiniti, usa i metodi setter sull'oggetto restituito da [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties). Questo esempio apre una presentazione esistente, chiama [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor), [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) e [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager), quindi salva la presentazione aggiornata con [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Il PPTX salvato contiene i nuovi metadati.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gestire la base dei collegamenti ipertestuali**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) restituisce la base a livello di documento per i collegamenti ipertestuali relativi. Usa [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) per modificarla o cancellarla. È utile quando si sposta una presentazione e i file collegati in un'altra posizione. È separata dal metodo [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) di un singolo collegamento: cambiare la base non riscrive gli indirizzi dei collegamenti né modifica le destinazioni assolute.

L'esempio richiede una presentazione contenente sia un collegamento relativo, ad esempio `target.html`, sia un collegamento assoluto, ad esempio `https://example.org/absolute.html`. Legge la base esistente, assegna una nuova base, salva e riapre la presentazione per controllare il valore. Poi cancella la base con una stringa vuota e verifica il valore vuoto in un file salvato separato. Sostituisci la base di esempio con la posizione dei tuoi file collegati.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
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

I due messaggi di verifica dovrebbero stampare `true`. Cancellare la base lascia intatti gli indirizzi dei singoli collegamenti.

Un collegamento relativo a `target.pptx` apriva `old/target.pptx` quando la base puntava alla cartella `old`. Dopo aver cambiato la base nella cartella `new`, salvato e riaperto la presentazione, lo stesso collegamento apriva `new/target.pptx`. Un collegamento assoluto continuava ad aprire lo stesso file. Prova i tuoi collegamenti relativi in PowerPoint prima e dopo aver spostato la presentazione o cambiato la sua base.

## **Aggiungere proprietà personalizzate alla presentazione**

Le proprietà personalizzate memorizzano metadati che non hanno un campo predefinito corrispondente. Il metodo [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) consente di assegnare un valore per nome di proprietà. Questo esempio crea una presentazione, aggiunge due valori di testo e un valore intero di versione, e salva la presentazione con [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save). Assegnare un valore a un nome esistente sostituisce il valore della proprietà.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Accedere e modificare le proprietà personalizzate**

Questo esempio apre una presentazione contenente proprietà personalizzate e usa [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) per iterarle. [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) accetta un indice basato su zero e restituisce il nome usato da [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item). L'esempio stampa ogni nome e valore originale, sostituisce ogni valore con una stringa numerata indipendentemente dal tipo originale e salva le modifiche. Se non ci sono proprietà personalizzate, il ciclo non effettua modifiche.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Esempio live**

Prova l'app online [**Visualizza & Modifica Metadati PowerPoint**](https://products.aspose.app/slides/metadata) per vedere come lavorare con le proprietà del documento usando l'API Aspose.Slides:

[![Visualizza & Modifica Metadati PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Come posso rimuovere una proprietà predefinita da una presentazione?**

Le proprietà predefinite sono parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile cambiarne i valori o impostarle a vuoto, se la specifica proprietà lo consente.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se aggiungi una proprietà personalizzata già presente, il suo valore esistente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì. Usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) e poi [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) per leggere i metadati memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation). Vedi [Creare un inventario leggero delle presentazioni](/slides/it/nodejs-java/examine-presentation/) per un esempio completo di reportistica e per le limitazioni specifiche di formato.

**Posso leggere le proprietà pubbliche di una presentazione crittografata senza la sua password di apertura?**

Sì. La presentazione deve essere stata crittografata dopo aver chiamato [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) con `false`, e deve essere caricata dopo aver chiamato [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) con `true`.

**Posso aggiornare un file PPTX crittografato in modalità sola proprietà del documento?**

No. I dati delle proprietà pubbliche e crittografate devono rimanere coerenti, quindi l'aggiornamento di un file PPTX crittografato richiede il caricamento completo della presentazione con la password di apertura corretta.