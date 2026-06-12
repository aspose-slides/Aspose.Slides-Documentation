---
title: Gestire le proprietà della presentazione in Java
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/java/presentation-properties/
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
- lingua di revisione
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Gestisci le proprietà della presentazione in Aspose.Slides per Java e ottimizza ricerca, branding e flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides supporta due tipologie di proprietà del documento: **Integrate** e **Personalizzate**. Entrambi i tipi di proprietà possono essere facilmente accessi e gestiti tramite le API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà dei documenti di presentazione attraverso l'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/). Un'istanza di questa interfaccia è restituita dal metodo [Presentation.getDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getDocumentProperties--) . Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="primary" %}} 
Si noti che i campi **Application** e **Producer** non possono essere modificati, poiché mostreranno sempre "Aspose Ltd." e "Aspose.Slides for Java x.x.x".
{{% /alert %}} 

## **Proprietà del documento in PowerPoint**

Microsoft PowerPoint 2007 consente di gestire le proprietà del documento dei file di presentazione. È sufficiente fare clic sull'icona Office e quindi sulla voce di menu **Prepare | Properties | Advanced Properties** di Microsoft PowerPoint 2007, come mostrato di seguito:

|**Selezione voce di menu Proprietà avanzate**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Dopo aver selezionato la voce di menu **Advanced Properties**, verrà visualizzata una finestra di dialogo che permette di gestire le proprietà del documento del file PowerPoint, come mostrato nella figura seguente:

|**Finestra Proprietà**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Nella **Finestra Proprietà** è possibile vedere numerose schede come **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Tutte queste schede consentono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Custom** è usata per gestire le proprietà personalizzate dei file PowerPoint.

### Lavorare con le proprietà del documento usando Aspose.Slides per Java

Come descritto in precedenza, Aspose.Slides per Java supporta due categorie di proprietà del documento, ovvero **Integrate** e **Personalizzate**. Pertanto, gli sviluppatori possono accedere a entrambe le tipologie di proprietà tramite le API di Aspose.Slides per Java. Aspose.Slides per Java fornisce la classe [IDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties) che rappresenta le proprietà del documento associate a un file di presentazione attraverso la proprietà **Presentation.DocumentProperties**.

Gli sviluppatori possono utilizzare la proprietà **IDocumentProperties** esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) per accedere alle proprietà del documento dei file di presentazione, come descritto di seguito:

## **Accedere alle proprietà integrate**

Queste proprietà, esposte dall'oggetto [IDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties), includono: **Creator** (Autore), **Description**, **Keywords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data ultima stampa), **LastModifiedBy**, **SharedDoc** (È condiviso tra diversi produttori?), **PresentationFormat**, **Subject** e **Title**.

```java
// Instanzia la classe Presentation che rappresenta la presentazione
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crea un riferimento all'oggetto IDocumentProperties associato a Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Visualizza le proprietà integrate
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

## **Modificare le proprietà integrate**

Modificare le proprietà integrate dei file di presentazione è semplice quanto accedervi. È sufficiente assegnare una stringa a qualsiasi proprietà desiderata e il valore verrà aggiornato. Nell'esempio seguente, dimostriamo come modificare le proprietà integrate del documento di una presentazione utilizzando Aspose.Slides per Java.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crea un riferimento all'oggetto IDocumentProperties associato a Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Imposta le proprietà integrate
    dp.setAuthor("Aspose.Slides for Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // Salva la presentazione in un file
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Questo esempio modifica le proprietà integrate della presentazione, come mostrato di seguito:

|**Proprietà integrate del documento dopo la modifica**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aggiungere proprietà personalizzate al documento**

Aspose.Slides per Java consente anche agli sviluppatori di aggiungere valori personalizzati alle proprietà del documento della presentazione. Di seguito è riportato un esempio che mostra come impostare le proprietà personalizzate per una presentazione.

```java
Presentation pres = new Presentation();
try {
    // Ottenere le proprietà del documento
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Aggiungere proprietà personalizzate
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Ottenere il nome della proprietà a un indice particolare
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

Aspose.Slides per Java permette anche di accedere ai valori delle proprietà personalizzate. Di seguito è mostrato un esempio che illustra come accedere e modificare tutte queste proprietà personalizzate per una presentazione.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Crea un riferimento all'oggetto DocumentProperties associato a Presentation
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Accedi e modifica le proprietà personalizzate
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // Visualizza i nomi e i valori delle proprietà personalizzate
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // Modifica i valori delle proprietà personalizzate
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // Salva la tua presentazione in un file
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Questo esempio modifica le proprietà personalizzate della [PPTX ](https://docs.fileformat.com/presentation/pptx/)presentazione. Le figure seguenti mostrano le proprietà personalizzate della presentazione prima e dopo la modifica:

|**Proprietà personalizzate prima della modifica**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Proprietà personalizzate dopo la modifica**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Proprietà avanzate del documento**

{{% alert color="primary" %}} 
Sono stati aggiunti i nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), e [WriteBindedPresentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) all'interfaccia [IPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo); la logica del setter della proprietà [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) è stata modificata.
{{% /alert %}} 

I due nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) e [UpdateDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) sono stati aggiunti all'interfaccia [IPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo). Forniscono un accesso rapido alle proprietà del documento e consentono di modificare e aggiornare le proprietà senza caricare l'intera presentazione.

Lo scenario tipico consiste nel caricare le proprietà, modificare qualche valore e aggiornare il documento, come mostrato di seguito:

```java
// leggi le informazioni della presentazione
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// ottieni le proprietà attuali
IDocumentProperties props = info.readDocumentProperties();

// imposta i nuovi valori dei campi Autore e Titolo
props.setAuthor("New Author");
props.setTitle("New Title");

// aggiorna la presentazione con i nuovi valori
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

È possibile utilizzare le proprietà di una presentazione specifica come modello per aggiornare le proprietà in altre presentazioni:

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

Un nuovo modello può essere creato da zero e poi usato per aggiornare più presentazioni:

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

## **Impostare la lingua di revisione**

Aspose.Slides fornisce la proprietà LanguageId (esposta dalla classe PortionFormat) per consentire di impostare la lingua di revisione per un documento PowerPoint. La lingua di revisione è la lingua per la quale vengono controllati ortografia e grammatica nel PowerPoint.

Questo codice Java mostra come impostare la lingua di revisione per un PowerPoint: xxx Perché LanguageId è assente nella classe Java PortionFormat?

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

    portionFormat.setLanguageId("zh-CN"); // imposta l'Id di una lingua di revisione

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

Prova l'app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà del documento tramite le API di Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## ***FAQ**

**Come posso rimuovere una proprietà integrata da una presentazione?**

Le proprietà integrate sono parte integrante della presentazione e non possono essere rimosse completamente. È possibile però cambiarne il valore o impostarlo a vuoto, se consentito dalla specifica proprietà.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se aggiungi una proprietà personalizzata già esistente, il suo valore corrente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare interamente la presentazione?**

Sì, è possibile accedere alle proprietà della presentazione senza caricare l'intera presentazione utilizzando il metodo `getPresentationInfo` della classe [PresentationFactory](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationfactory/). Successivamente, utilizza il metodo `readDocumentProperties` fornito dall'interfaccia [IPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/) per leggere le proprietà in modo efficiente, risparmiando memoria e migliorando le prestazioni.