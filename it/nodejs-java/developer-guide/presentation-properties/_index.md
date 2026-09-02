---
title: Gestisci le proprietà della presentazione in JavaScript
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/nodejs-java/presentation-properties/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Gestisci le proprietà della presentazione in Aspose.Slides per Node.js via Java e semplifica ricerca, branding e flusso di lavoro nei tuoi file PowerPo​int e OpenDocument."
---
## **Introduzione**

Aspose.Slides supporta due tipologie di proprietà del documento: **Integrate** e **Personalizzate**. Entrambi i tipi di proprietà possono essere facilmente acceduti e gestiti tramite le API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà dei documenti di presentazione attraverso la classe [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/). Un’istanza di questa classe viene restituita dal metodo [Presentation.getDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getDocumentProperties). Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Note" %}}
Si noti che i campi **Application** e **AppVersion** non possono essere modificati. Aspose.Slides li sovrascrive ad ogni salvataggio, quindi una presentazione salvata riporta sempre “Aspose.Slides for Node.js via Java” e la versione della libreria che l’ha generata. Qualsiasi valore passato a `setNameOfApplication` viene scartato quando la presentazione viene scritta.
{{% /alert %}} 

## **Gestisci le proprietà della presentazione**

Microsoft PowerPoint offre una funzionalità per aggiungere alcune proprietà ai file di presentazione. Queste proprietà del documento consentono di memorizzare informazioni utili insieme ai documenti (file di presentazione). Esistono due tipologie di proprietà del documento:

- Proprietà definite dal sistema (Integrate)
- Proprietà definite dall'utente (Personalizzate)

Le proprietà **Integrate** contengono informazioni generali sul documento, come titolo, nome dell’autore, statistiche del documento e così via. Le proprietà **Personalizzate** sono quelle definite dagli utenti come coppie **Nome/Valore**, in cui sia il nome che il valore sono specificati dall’utente. Utilizzando Aspose.Slides per Node.js via Java, gli sviluppatori possono accedere e modificare i valori delle proprietà integrate così come quelle personalizzate.

## **Proprietà del documento in PowerPoint**

Microsoft PowerPoint 2007 consente di gestire le proprietà del documento dei file di presentazione. È sufficiente fare clic sull’icona Office e poi sul menu **Prepare | Properties | Advanced Properties** di Microsoft PowerPoint 2007, come mostrato di seguito:

|**Selezione voce di menu Proprietà avanzate**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

Dopo aver selezionato la voce di menu **Advanced Properties**, appare una finestra di dialogo che consente di gestire le proprietà del documento del file PowerPoint, come mostrato nella figura seguente:

|**Finestra di dialogo Proprietà**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

Nella suddetta **Finestra di dialogo Proprietà** è possibile vedere molte schede, come **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Tutte queste schede consentono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Custom** viene utilizzata per gestire le proprietà personalizzate dei file PowerPoint.

## **Lavorare con le proprietà del documento usando Aspose.Slides per Node.js via Java**

Come descritto in precedenza, Aspose.Slides per Node.js via Java supporta due tipologie di proprietà del documento: **Integrate** e **Personalizzate**. Pertanto, gli sviluppatori possono accedere a entrambe le tipologie di proprietà tramite le API di Aspose.Slides per Node.js via Java. Aspose.Slides per Node.js via Java fornisce la classe [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties) che rappresenta le proprietà del documento associate a un file di presentazione tramite la proprietà **Presentation.DocumentProperties**.

Gli sviluppatori possono utilizzare la proprietà **DocumentProperties** esposta dall’oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) per accedere alle proprietà del documento dei file di presentazione come descritto di seguito:

## **Accedi alle proprietà integrate**

Queste proprietà, esposte dall’oggetto [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties), includono: **Creator** (Autore), **Description**, **Keywords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data dell’ultima stampa), **LastModifiedBy**, **SharedDoc** (È condiviso tra diversi produttori?), **PresentationFormat**, **Subject** e **Title**.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanzia la classe Presentation che rappresenta la presentazione
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Crea un riferimento all'oggetto IDocumentProperties associato alla presentazione
    var dp = pres.getDocumentProperties();
    // Visualizza le proprietà integrate
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

## **Modifica le proprietà integrate**

Modificare le proprietà integrate dei file di presentazione è semplice quanto accedervi. È sufficiente assegnare un valore stringa a qualsiasi proprietà desiderata e il valore verrà modificato. Nell’esempio riportato di seguito, dimostriamo come modificare le proprietà integrate del documento di una presentazione usando Aspose.Slides per Node.js via Java.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Crea un riferimento all'oggetto IDocumentProperties associato alla presentazione
    var dp = pres.getDocumentProperties();
    // Imposta le proprietà integrate
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Salva la tua presentazione in un file
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Questo esempio modifica le proprietà integrate della presentazione, visualizzabili come mostrato di seguito:

|**Proprietà del documento integrate dopo la modifica**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aggiungi proprietà del documento personalizzate**

Aspose.Slides per Node.js via Java consente anche agli sviluppatori di aggiungere valori personalizzati per le proprietà del documento della presentazione. L’esempio seguente mostra come impostare le proprietà personalizzate per una presentazione.

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

## **Accedi e modifica le proprietà personalizzate**

Aspose.Slides per Node.js via Java consente anche agli sviluppatori di accedere ai valori delle proprietà personalizzate. L’esempio seguente mostra come è possibile accedere e modificare tutte queste proprietà personalizzate per una presentazione.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Crea un riferimento all'oggetto DocumentProperties associato alla presentazione
    var dp = pres.getDocumentProperties();
    // Accedi e modifica le proprietà personalizzate
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Visualizza i nomi e i valori delle proprietà personalizzate
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // Modifica i valori delle proprietà personalizzate
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // Salva la tua presentazione in un file
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

{{% alert color="info" title="Note" %}}
Sono stati aggiunti i nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), e [WriteBindedPresentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) alla classe [PresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo); la logica del setter della proprietà [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) è stata modificata.
{{% /alert %}} 

I due nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) e [UpdateDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) sono stati aggiunti alla classe [PresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo). Essi forniscono un accesso rapido alle proprietà del documento e consentono di modificare e aggiornare le proprietà senza caricare un’intera presentazione.

Lo scenario tipico consiste nel caricare le proprietà, modificare qualche valore e aggiornare il documento, come mostrato di seguito:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// leggi le informazioni della presentazione
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// ottieni le proprietà attuali
var props = info.readDocumentProperties();
// imposta i nuovi valori dei campi Author e Title
props.setAuthor("New Author");
props.setTitle("New Title");
// aggiorna la presentazione con nuovi valori
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Un altro modo consiste nell’utilizzare le proprietà di una presentazione specifica come modello per aggiornare le proprietà in altre presentazioni:

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

## **Imposta la lingua di correzione**

Aspose.Slides fornisce la proprietà LanguageId (esposta dalla classe PortionFormat) per consentire di impostare la lingua di correzione per un documento PowerPoint. La lingua di correzione è la lingua per la quale ortografia e grammatica vengono verificate in PowerPoint.

Questo codice JavaScript mostra come impostare la lingua di correzione per un PowerPoint: xxx Perché LanguageId è mancante nella classe JavaScript PortionFormat?

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
    portionFormat.setLanguageId("zh-CN");// imposta l'Id di una lingua di correzione
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Imposta la lingua predefinita**

Questo codice JavaScript mostra come impostare la lingua predefinita per un’intera presentazione PowerPoint:

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
    // Verifica la lingua della prima porzione
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Esempio live**

Prova l’app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà del documento tramite le API di Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## **FAQ**

**Come posso rimuovere una proprietà integrata da una presentazione?**

Le proprietà integrate sono parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile modificare i loro valori o impostarli su vuoto, se la proprietà lo consente.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se si aggiunge una proprietà personalizzata già esistente, il suo valore corrente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare interamente la presentazione?**

Sì. Utilizza [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) e poi [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) per leggere i metadati del documento memorizzati senza creare un’istanza di [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/). Vedi [Build a Lightweight Presentation Inventory](/slides/it/nodejs-java/examine-presentation/) per un esempio completo di reportistica e le limitazioni specifiche per formato.