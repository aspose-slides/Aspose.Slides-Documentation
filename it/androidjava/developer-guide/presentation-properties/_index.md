---
title: Gestire le proprietà della presentazione su Android
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/androidjava/presentation-properties/
keywords:
- Proprietà PowerPoint
- Proprietà della presentazione
- Proprietà del documento
- Proprietà incorporate
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
- Android
- Java
- Aspose.Slides
description: "Gestisci le proprietà della presentazione in Aspose.Slides per Android via Java e semplifica la ricerca, il branding e il flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides supporta due tipi di proprietà del documento: **Incorporate** e **Custom**. Entrambi questi tipi di proprietà possono essere facilmente acceduti e gestiti utilizzando l'API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà del documento della presentazione tramite l'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties/) . Un'istanza di questa interfaccia è restituita dal metodo [Presentation.getDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) . Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="primary" %}} 
Si prega di notare che i campi **Application** e **Producer** non possono essere modificati, poiché questi campi mostreranno sempre "Aspose Ltd." e "Aspose.Slides for Android via Java x.x.x".
{{% /alert %}} 

## **Proprietà del documento in PowerPoint**

Microsoft PowerPoint 2007 consente di gestire le proprietà del documento dei file di presentazione. Tutto quello che devi fare è fare clic sull'icona di Office e poi sull'elemento di menu **Prepare | Properties | Advanced Properties** di Microsoft PowerPoint 2007 come mostrato di seguito:

|**Selezione della voce di menu Proprietà avanzate**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Dopo aver selezionato l'elemento di menu **Advanced Properties**, verrà visualizzata una finestra di dialogo che consente di gestire le proprietà del documento del file PowerPoint come mostrato nella figura seguente:

|**Finestra di dialogo Proprietà**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Nella suddetta **Finestra di dialogo Proprietà**, puoi vedere che ci sono molte schede come **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Tutte queste schede consentono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Custom** è utilizzata per gestire le proprietà personalizzate dei file PowerPoint.



Lavorare con le proprietà del documento utilizzando Aspose.Slides per Android via Java

Come abbiamo descritto in precedenza, Aspose.Slides per Android via Java supporta due tipi di proprietà del documento, ovvero proprietà **Incorporate** e **Custom**. Pertanto, gli sviluppatori possono accedere a entrambi i tipi di proprietà mediante l'API di Aspose.Slides per Android via Java. Aspose.Slides per Android via Java fornisce la classe [IDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties) che rappresenta le proprietà del documento associate a un file di presentazione tramite la proprietà **Presentation.DocumentProperties**.

Gli sviluppatori possono utilizzare la proprietà **IDocumentProperties** esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) per accedere alle proprietà del documento dei file di presentazione come descritto di seguito:

## **Accedere alle proprietà incorporate**

Queste proprietà esposte dall'oggetto [IDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties) includono: **Creator** (Autore), **Description**, **Keywords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data ultima stampa), **LastModifiedBy**, **Keywords**, **SharedDoc** (È condiviso tra diversi produttori?), **PresentationFormat**, **Subject** e **Title**.

```java
// Istanziare la classe Presentation che rappresenta la presentazione
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Creare un riferimento all'oggetto IDocumentProperties associato a Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Visualizzare le proprietà incorporate
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modificare le proprietà incorporate**

Modificare le proprietà incorporate dei file di presentazione è semplice quanto accedervi. È sufficiente assegnare una stringa a qualsiasi proprietà desiderata e il valore della proprietà verrà modificato. Nell'esempio riportato di seguito, abbiamo mostrato come modificare le proprietà incorporate del documento della presentazione utilizzando Aspose.Slides per Android via Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Creare un riferimento all'oggetto IDocumentProperties associato a Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Impostare le proprietà incorporate
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Salvare la presentazione in un file
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Questo esempio modifica le proprietà incorporate della presentazione, che possono essere visualizzate come mostrato di seguito:

|**Proprietà del documento incorporate dopo la modifica**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aggiungere proprietà personalizzate del documento**

Aspose.Slides per Android via Java consente inoltre agli sviluppatori di aggiungere valori personalizzati per le proprietà del documento della presentazione. Di seguito è riportato un esempio che mostra come impostare le proprietà personalizzate per una presentazione.

```java
Presentation pres = new Presentation();
try {
    // Ottenere le proprietà del documento
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Aggiungere proprietà personalizzate
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Ottenere il nome della proprietà a un indice specifico
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Rimuovere la proprietà selezionata
    dProps.removeCustomProperty(getPropertyName);
    
    // Salvare la presentazione
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Proprietà personalizzate del documento aggiunte**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accedere e modificare le proprietà personalizzate**

Aspose.Slides per Android via Java consente inoltre agli sviluppatori di accedere ai valori delle proprietà personalizzate. Di seguito è riportato un esempio che mostra come accedere e modificare tutte queste proprietà personalizzate per una presentazione.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Creare un riferimento all'oggetto DocumentProperties associato a Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Accedere e modificare le proprietà personalizzate
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Visualizzare i nomi e i valori delle proprietà personalizzate
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Modificare i valori delle proprietà personalizzate
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Salvare la presentazione in un file
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
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

{{% alert color="primary" %}} 
Sono stati aggiunti i nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), e [WriteBindedPresentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) a [IPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentationInfo), la logica del setter della proprietà [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) è stata modificata.
{{% /alert %}} 

I due nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) e [UpdateDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) sono stati aggiunti all'interfaccia [IPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentationInfo). Forniscono un accesso rapido alle proprietà del documento e consentono di modificare e aggiornare le proprietà senza caricare un'intera presentazione.

Lo scenario tipico di caricare le proprietà, modificare qualche valore e aggiornare il documento può essere implementato nel modo seguente:

```java
// leggere le informazioni della presentazione
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// ottenere le proprietà correnti
IDocumentProperties props = info.readDocumentProperties();

// impostare i nuovi valori dei campi Autore e Titolo
props.setAuthor("New Author");
props.setTitle("New Title");

// aggiornare la presentazione con nuovi valori
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Esiste un altro modo per utilizzare le proprietà di una presentazione specifica come modello per aggiornare le proprietà in altre presentazioni:

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

È possibile creare un nuovo modello da zero e poi usarlo per aggiornare più presentazioni:

```java
DocumentProperties template = new DocumentProperties();\

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

```java
private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Impostare la lingua di correzione**

Aspose.Slides fornisce la proprietà LanguageId (esposta dalla classe PortionFormat) per consentire di impostare la lingua di correzione per un documento PowerPoint. La lingua di correzione è la lingua per la quale vengono controllati ortografia e grammatica in PowerPoint.

Questo codice Java mostra come impostare la lingua di correzione per un PowerPoint: xxx Perché LanguageId è assente nella classe Java PortionFormat?

```java
Presentation pres = new Presentation(pptxFileName);
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // imposta l'Id di una lingua di correzione

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Impostare la lingua predefinita**

Questo codice Java mostra come impostare la lingua predefinita per un'intera presentazione PowerPoint:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Aggiunge una nuova forma rettangolare con testo
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Verifica la lingua della prima porzione
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Esempio live**

Prova l'app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà del documento tramite l'API di Aspose.Slides:

[![Visualizza e modifica i metadati di PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## ***FAQ**

**Come posso rimuovere una proprietà incorporata da una presentazione?**

Le proprietà incorporate sono una parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile cambiarne i valori o impostarle a vuoto, se consentito dalla proprietà specifica.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se aggiungi una proprietà personalizzata che esiste già, il suo valore corrente verrà sovrascritto con il nuovo. Non è necessario rimuovere o controllare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì, è possibile accedere alle proprietà della presentazione senza caricare completamente la presentazione utilizzando il metodo `getPresentationInfo` della classe [PresentationFactory](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationfactory/) . Quindi, utilizzare il metodo `readDocumentProperties` fornito dall'interfaccia [IPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/) per leggere le proprietà in modo efficiente, risparmiando memoria e migliorando le prestazioni.