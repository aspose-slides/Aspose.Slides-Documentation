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
- lingua di revisione
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci le proprietà delle presentazioni in Aspose.Slides per Node.js via Java e semplifica la ricerca, il branding e il flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides supporta due tipi di proprietà del documento: **Predefinite** e **Personalizzate**. Entrambi i tipi di proprietà possono essere facilmente accessi e gestiti utilizzando l'API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà del documento di una presentazione tramite la classe [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/) . Un'istanza di questa classe è restituita dal metodo [Presentation.getDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Nota" %}}

Si noti che i campi **Application** e **AppVersion** non possono essere modificati. Aspose.Slides li sovrascrive ad ogni salvataggio, quindi una presentazione salvata riporterà sempre "Aspose.Slides for Node.js via Java" e la versione della libreria che l'ha generata. Qualsiasi valore passato a `setNameOfApplication` viene scartato quando la presentazione viene scritta.

{{% /alert %}} 

## **Gestire le proprietà della presentazione**

Microsoft PowerPoint fornisce una funzionalità per aggiungere alcune proprietà ai file di presentazione. Queste proprietà del documento consentono di memorizzare informazioni utili insieme ai documenti (file di presentazione). Esistono due tipologie di proprietà del documento:

- Proprietà di sistema (Predefinite)
- Proprietà definite dall'utente (Personalizzate)

Le proprietà **Predefinite** contengono informazioni generali sul documento, come titolo del documento, nome dell'autore, statistiche del documento e così via. Le proprietà **Personalizzate** sono quelle definite dagli utenti come coppie **Nome/Valore**, dove sia il nome che il valore sono definiti dall'utente. Utilizzando Aspose.Slides for Node.js via Java, gli sviluppatori possono accedere e modificare i valori delle proprietà predefinite così come quelle personalizzate.

## **Proprietà del documento in PowerPoint**

Microsoft PowerPoint 2007 permette di gestire le proprietà del documento dei file di presentazione. Basta cliccare sull'icona di Office e poi sul comando **Prepare | Properties | Advanced Properties** di Microsoft PowerPoint 2007 come mostrato di seguito:

|**Selezionare il comando Proprietà avanzate**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Dopo aver selezionato il comando **Advanced Properties**, verrà visualizzata una finestra di dialogo che consente di gestire le proprietà del documento del file PowerPoint, come mostrato nella figura seguente:

|**Finestra Proprietà**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Nella **Finestra Proprietà** sopra, è possibile osservare molte schede come **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Tutte queste schede consentono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Custom** è utilizzata per gestire le proprietà personalizzate dei file PowerPoint.

Lavorare con le proprietà del documento usando Aspose.Slides for Node.js via Java

Come descritto in precedenza, Aspose.Slides for Node.js via Java supporta due tipologie di proprietà del documento: **Predefinite** e **Personalizzate**. Gli sviluppatori possono accedere a entrambe le tipologie di proprietà mediante l'API di Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java fornisce la classe [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties) che rappresenta le proprietà del documento associate a un file di presentazione tramite la proprietà **Presentation.DocumentProperties**.

Gli sviluppatori possono utilizzare la proprietà **DocumentProperties** esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) per accedere alle proprietà del documento dei file di presentazione come descritto sotto:

## **Leggere le proprietà pubbliche da una presentazione crittografata**

Una password di apertura normalmente protegge sia il contenuto della presentazione sia le proprietà del documento. Quando una presentazione è crittografata passando `false` a [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), le sue proprietà del documento rimangono pubbliche. Un'applicazione può quindi passare `true` a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) e leggere i metadati pubblici senza fornire la password di apertura.

L'opzione **document-properties-only** controlla ciò che Aspose.Slides carica; non decritta nulla. Se le proprietà fossero state incluse nella cifratura, il loro caricamento senza password fallisce. Se la presentazione non è crittografata, l'opzione è ignorata e l'intera presentazione viene caricata.

L'esempio seguente verifica la modalità di caricamento tramite [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) e poi legge le proprietà predefinite tramite [Presentation.getDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getDocumentProperties):

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const properties = presentation.getDocumentProperties();

        console.log("Author: " + properties.getAuthor());
        console.log("Title: " + properties.getTitle());
        console.log("Keywords: " + properties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

In questa modalità, il contenuto delle diapositive non viene caricato. Diapositive, master, layout, forme, media e altri oggetti della presentazione non sono disponibili. Le applicazioni dovrebbero sempre verificare [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) prima di eseguire un'operazione che richieda il modello completo dell'oggetto presentazione.

{{% alert color="warning" title="Attenzione" %}}
I metadati pubblici possono esporre nomi degli autori, titoli, soggetti, parole chiave, informazioni aziendali, commenti e valori personalizzati. Crittografare le proprietà sensibili insieme alla presentazione. Lasciarle pubbliche solo quando sistemi di indicizzazione, classificazione, ricerca o gestione dei documenti richiedono esplicitamente l'accesso senza password.
{{% /alert %}}

## **Aggiornare le proprietà di una presentazione crittografata**

Per un file PPTX crittografato, una presentazione caricata in modalità **document-properties-only** è destinata alla lettura dei metadati pubblici. Aspose.Slides non può salvare le proprietà modificate da quell'oggetto a sola metadata perché le proprietà pubbliche devono rimanere coerenti con i dati corrispondenti all'interno della presentazione crittografata. Pertanto, l'aggiornamento richiede la password di apertura corretta e un caricamento completo.

L'esempio seguente apre la presentazione con [LoadOptions.setPassword](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/loadoptions/#setPassword), aggiorna le proprietà predefinite pubbliche e salva il risultato. Successivamente utilizza [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/#isEncrypted) per verificare che la crittografia sia preservata e riapre i metadati pubblici senza password per verificare i nuovi valori:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

Se a un'applicazione non è consentito decrittare o caricare il contenuto della presentazione, deve trattare le proprietà pubbliche di un file PPTX crittografato come di sola lettura.

## **Accedere alle proprietà predefinite**

Queste proprietà esposte dall'oggetto [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties) includono: **Creator** (Autore), **Description**, **Keywords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data ultima stampa), **LastModifiedBy**, **Keywords**, **SharedDoc** (È condiviso tra diversi produttori?), **PresentationFormat**, **Subject** e **Title**

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Istanziare la classe Presentation che rappresenta la presentazione
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Creare un riferimento all'oggetto IDocumentProperties associato alla presentazione
    var dp = pres.getDocumentProperties();
    // Visualizzare le proprietà predefinite
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modificare le proprietà predefinite**

Modificare le proprietà predefinite dei file di presentazione è semplice quanto accedervi. È sufficiente assegnare una stringa a qualsiasi proprietà desiderata e il valore verrà modificato. Nell'esempio seguente, dimostriamo come modificare le proprietà predefinite del documento della presentazione usando Aspose.Slides for Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Creare un riferimento all'oggetto IDocumentProperties associato alla presentazione
    var dp = pres.getDocumentProperties();
    // Impostare le proprietà predefinite
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Salvare la presentazione in un file
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Questo esempio modifica le proprietà predefinite della presentazione, come mostrato di seguito:

|**Proprietà del documento predefinite dopo la modifica**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aggiungere proprietà del documento personalizzate**

Aspose.Slides for Node.js via Java consente inoltre agli sviluppatori di aggiungere valori personalizzati per le proprietà del documento della presentazione. Di seguito è riportato un esempio che mostra come impostare le proprietà personalizzate per una presentazione.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    // Ottenere le proprietà del documento
    var dProps = pres.getDocumentProperties();
    // Aggiungere proprietà personalizzate
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Ottenere il nome della proprietà a un indice specifico
    var getPropertyName = dProps.getCustomPropertyName(2);
    // Rimuovere la proprietà selezionata
    dProps.removeCustomProperty(getPropertyName);
    // Salvare la presentazione
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**Proprietà del documento personalizzate aggiunte**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accedere e modificare le proprietà personalizzate**

Aspose.Slides for Node.js via Java consente inoltre agli sviluppatori di accedere ai valori delle proprietà personalizzate. Di seguito è riportato un esempio che mostra come accedere e modificare tutte queste proprietà personalizzate per una presentazione.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Creare un riferimento all'oggetto DocumentProperties associato alla presentazione
    var dp = pres.getDocumentProperties();
    // Accedere e modificare le proprietà personalizzate
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Visualizzare i nomi e i valori delle proprietà personalizzate
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Modificare i valori delle proprietà personalizzate
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Salvare la presentazione in un file
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Questo esempio modifica le proprietà personalizzate della presentazione [PPTX](https://docs.fileformat.com/presentation/pptx/). Le figure seguenti mostrano le proprietà personalizzate della presentazione prima e dopo la modifica:

|**Proprietà personalizzate prima della modifica**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Proprietà personalizzate dopo la modifica**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Proprietà avanzate del documento**

{{% alert color="info" title="Nota" %}}

Sono stati aggiunti i nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) , [UpdateDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) e [WriteBindedPresentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) a [PresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo); la logica del setter della proprietà [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) è stata modificata.

{{% /alert %}} 

I due nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) e [UpdateDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) sono stati aggiunti alla classe [PresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo). Offrono un accesso rapido alle proprietà del documento e consentono di modificare e aggiornare le proprietà senza caricare un'intera presentazione.

Lo scenario tipico di caricamento delle proprietà, modifica di qualche valore e aggiornamento del documento può essere implementato nel seguente modo:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// leggere le informazioni della presentazione
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// ottenere le proprietà correnti
var props = info.readDocumentProperties();
// impostare i nuovi valori dei campi Autore e Titolo
props.setAuthor("New Author");
props.setTitle("New Title");
// aggiornare la presentazione con nuovi valori
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Esiste un altro modo per utilizzare le proprietà di una presentazione specifica come modello per aggiornare le proprietà in altre presentazioni:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

È possibile creare un nuovo modello da zero e poi usarlo per aggiornare più presentazioni:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) {
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}

var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Impostare la lingua di revisione**

Aspose.Slides fornisce la proprietà LanguageId (esposta dalla classe PortionFormat) per consentire di impostare la lingua di revisione per un documento PowerPoint. La lingua di revisione è quella per la quale ortografia e grammatica del PowerPoint vengono controllate.

Questo codice JavaScript mostra come impostare la lingua di revisione per un PowerPoint: xxx Perché LanguageId è assente dalla classe JavaScript PortionFormat?

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// imposta l'Id di una lingua di revisione
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Impostare la lingua predefinita**

Questo codice JavaScript mostra come impostare la lingua predefinita per un'intera presentazione PowerPoint:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // Aggiunge una nuova forma rettangolare con testo
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // Controlla la lingua della prima porzione
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Esempio live**

Prova l'app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà del documento tramite l'API di Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## **FAQ**

**Come posso rimuovere una proprietà predefinita da una presentazione?**

Le proprietà predefinite fanno parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile modificarne i valori o impostarle a vuoto, se la proprietà lo consente.

**Cosa succede se aggiungo una proprietà personalizzata già esistente?**

Se si aggiunge una proprietà personalizzata già presente, il valore esistente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì. Usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) e poi [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) per leggere i metadati del documento memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/) . Vedi [Build a Lightweight Presentation Inventory](/slides/it/nodejs-java/examine-presentation/) per un esempio completo di reportistica e limitazioni specifiche per formato.

**Posso leggere le proprietà pubbliche di una presentazione crittografata senza la sua password di apertura?**

Sì. La crittografia delle proprietà del documento deve essere stata disattivata prima che la presentazione fosse crittografata e la presentazione deve essere caricata in modalità **document-properties-only**.

**Posso aggiornare un file PPTX crittografato in modalità **document-properties-only**?**

No. I dati delle proprietà pubbliche e crittografate devono rimanere coerenti, quindi l'aggiornamento di un file PPTX crittografato richiede il caricamento completo della presentazione con la corretta password di apertura.