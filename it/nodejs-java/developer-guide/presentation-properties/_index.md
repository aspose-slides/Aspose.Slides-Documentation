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
- proprietà integrate
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

Aspose.Slides supporta due tipi di proprietà del documento: **Built-in** e **Custom**. Entrambi i tipi di proprietà possono essere facilmente accessi e gestiti utilizzando l'API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà del documento di una presentazione attraverso la classe [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties/) . Un'istanza di questa classe è restituita dal metodo [Presentation.getDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getDocumentProperties) . Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="primary" %}} 

Si prega di notare che non è possibile impostare valori per i campi **Application** e **Producer**, perché Aspose Ltd. e Aspose.Slides for Node.js via Java x.x.x verranno visualizzati in questi campi.

{{% /alert %}} 

## **Gestire le proprietà della presentazione**

Microsoft PowerPoint fornisce una funzionalità per aggiungere alcune proprietà ai file di presentazione. Queste proprietà del documento consentono di memorizzare informazioni utili insieme ai documenti (file di presentazione). Esistono due categorie di proprietà del documento:

- Proprietà di sistema (Built-in)
- Proprietà definite dall'utente (Custom)

Le proprietà **Built-in** contengono informazioni generali sul documento come titolo, nome dell'autore, statistiche del documento e così via. Le proprietà **Custom** sono quelle definite dagli utenti come coppie **Nome/Valore**, dove sia il nome sia il valore sono specificati dall'utente. Utilizzando Aspose.Slides for Node.js via Java, gli sviluppatori possono accedere e modificare i valori delle proprietà built-in così come delle proprietà custom.

## **Proprietà del documento in PowerPoint**

Microsoft PowerPoint 2007 consente di gestire le proprietà del documento dei file di presentazione. Tutto quello che devi fare è fare clic sull'icona Office e poi sul menu **Prepare | Properties | Advanced Properties** di Microsoft PowerPoint 2007, come mostrato di seguito:

|**Selezione della voce di menu Proprietà avanzate**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Dopo aver selezionato la voce di menu **Advanced Properties**, appare una finestra di dialogo che consente di gestire le proprietà del documento del file PowerPoint, come mostrato nella figura seguente:

|**Finestra di dialogo Proprietà**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Nella **Finestra di dialogo Proprietà** sopra, è possibile vedere molte schede come **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Tutte queste schede consentono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Custom** è utilizzata per gestire le proprietà custom dei file PowerPoint.

## **Lavorare con le proprietà del documento usando Aspose.Slides for Node.js via Java**

Come descritto in precedenza, Aspose.Slides for Node.js via Java supporta due tipi di proprietà del documento, ovvero **Built-in** e **Custom**. Pertanto, gli sviluppatori possono accedere a entrambi i tipi di proprietà mediante l'API di Aspose.Slides for Node.js via Java. Aspose.Slides for Node.js via Java fornisce una classe [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties) che rappresenta le proprietà del documento associate a un file di presentazione tramite la proprietà **Presentation.DocumentProperties**.

Gli sviluppatori possono utilizzare la proprietà **DocumentProperties** esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation) per accedere alle proprietà del documento dei file di presentazione, come descritto di seguito:

## **Accedere alle proprietà Built-in**

Queste proprietà esposte dall'oggetto [DocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties) includono: **Creator** (Author), **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** e **Title**.

```javascript
// Istanzia la classe Presentation che rappresenta la presentazione
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Crea un riferimento all'oggetto IDocumentProperties associato alla Presentazione
    var dp = pres.getDocumentProperties();
    // Mostra le proprietà integrate
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

## **Modificare le proprietà Built-in**

Modificare le proprietà built-in dei file di presentazione è semplice come accedervi. È sufficiente assegnare un valore stringa a qualsiasi proprietà desiderata e il valore della proprietà verrà modificato. Nell'esempio riportato di seguito, dimostriamo come modificare le proprietà built-in del documento di una presentazione utilizzando Aspose.Slides for Node.js via Java.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Crea un riferimento all'oggetto IDocumentProperties associato alla Presentazione
    var dp = pres.getDocumentProperties();
    // Imposta le proprietà integrate
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // Salva la presentazione in un file
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Questo esempio modifica le proprietà built-in della presentazione, come mostrato di seguito:

|**Proprietà del documento Built-in dopo la modifica**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aggiungere proprietà documento Custom**

Aspose.Slides for Node.js via Java consente anche agli sviluppatori di aggiungere valori custom alle proprietà del documento di una presentazione. Un esempio è mostrato di seguito per impostare le proprietà custom per una presentazione.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Ottenere le proprietà del documento
    var dProps = pres.getDocumentProperties();
    // Aggiungere proprietà personalizzate
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // Ottenere il nome della proprietà a un indice particolare
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

|**Proprietà documento Custom aggiunte**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accedere e modificare le proprietà Custom**

Aspose.Slides for Node.js via Java consente anche agli sviluppatori di accedere ai valori delle proprietà custom. Un esempio è fornito di seguito per mostrare come accedere e modificare tutte queste proprietà custom per una presentazione.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // Crea un riferimento all'oggetto DocumentProperties associato alla Presentazione
    var dp = pres.getDocumentProperties();
    // Accedi e modifica le proprietà personalizzate
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Mostra i nomi e i valori delle proprietà personalizzate
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

Questo esempio modifica le proprietà custom della presentazione [PPTX](https://docs.fileformat.com/presentation/pptx/). Le figure seguenti mostrano le proprietà custom della presentazione prima e dopo la modifica:

|**Proprietà Custom prima della modifica**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**Proprietà Custom dopo la modifica**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Proprietà documento avanzate**

{{% alert color="primary" %}} 

Sono stati aggiunti i nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), e [WriteBindedPresentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-) alla classe [PresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo) ; la logica del setter della proprietà [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) è stata modificata.

{{% /alert %}} 

I due nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) e [UpdateDocumentProperties](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) sono stati aggiunti alla classe [PresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/PresentationInfo). Forniscono un accesso rapido alle proprietà del documento e consentono di modificare e aggiornare le proprietà senza caricare l'intera presentazione.

Lo scenario tipico consiste nel caricare le proprietà, cambiare qualche valore e aggiornare il documento, come mostrato di seguito:

```javascript
// leggi le informazioni della presentazione
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// obtain the current properties
var props = info.readDocumentProperties();
// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");
// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Esiste un altro modo per utilizzare le proprietà di una presentazione specifica come modello per aggiornare le proprietà in altre presentazioni:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Un nuovo modello può essere creato da zero e poi usato per aggiornare più presentazioni:

```javascript
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
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Impostare la lingua di correzione**

Aspose.Slides fornisce la proprietà LanguageId (esposta dalla classe PortionFormat) per consentire di impostare la lingua di correzione per un documento PowerPoint. La lingua di correzione è la lingua per la quale ortografia e grammatica vengono verificate in PowerPoint.

Questo codice JavaScript mostra come impostare la lingua di correzione per un PowerPoint: xxx Why is LanguageId missing from JavaScript PortionFormat class?

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
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

## **Impostare la lingua predefinita**

Questo codice JavaScript mostra come impostare la lingua predefinita per un'intera presentazione PowerPoint:

```javascript
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

## ***FAQ**

**Come posso rimuovere una proprietà built-in da una presentazione?**

Le proprietà built-in fanno parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile modificare i loro valori o impostarli a vuoto se la proprietà specifica lo consente.

**Cosa succede se aggiungo una proprietà custom che esiste già?**

Se aggiungi una proprietà custom che esiste già, il suo valore esistente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì, è possibile accedere alle proprietà della presentazione senza caricare completamente la presentazione utilizzando il metodo `getPresentationInfo` della classe [PresentationFactory](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationfactory/) . Quindi, utilizza il metodo `readDocumentProperties` fornito dalla classe [PresentationInfo](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentationinfo/) per leggere le proprietà in modo efficiente, risparmiando memoria e migliorando le prestazioni.