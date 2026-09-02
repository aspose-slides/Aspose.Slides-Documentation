---
title: Gestire le proprietà della presentazione in Java
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/java/presentation-properties/
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
- Lingua di revisione
- Lingua predefinita
- PowerPoint
- OpenDocument
- Presentazione
- Java
- Aspose.Slides
description: "Gestisci al meglio le proprietà della presentazione in Aspose.Slides per Java e semplifica la ricerca, il branding e il flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides supporta due tipologie di proprietà del documento: **Integrate** e **Personalizzate**. Entrambi i tipi di proprietà possono essere facilmente accessed e gestite tramite l'API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà dei documenti di una presentazione attraverso l'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides.idocumentproperties/) . Un'istanza di questa interfaccia è restituita dal metodo [Presentation.getDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getDocumentProperties--) . Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Note" %}}
Si noti che i campi **Application** e **AppVersion** non possono essere modificati. Aspose.Slides li riscrive ad ogni salvataggio, quindi una presentazione salvata riporterà sempre "Aspose.Slides for Java" e la versione della libreria che l'ha generata. Qualsiasi valore passato a `setNameOfApplication` viene scartato quando la presentazione viene scritta.
{{% /alert %}} 

## **Proprietà del documento in PowerPoint**

Microsoft PowerPoint 2007 permette di gestire le proprietà del documento dei file di presentazione. È sufficiente fare clic sull'icona Office e quindi sull'opzione **Prepare | Properties | Advanced Properties** di Microsoft PowerPoint 2007, come mostrato di seguito:

|**Selezione voce menu Proprietà avanzate**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Dopo aver selezionato la voce **Advanced Properties**, appare una finestra di dialogo che consente di gestire le proprietà del documento del file PowerPoint, come mostrato nella figura seguente:

|**Finestra Proprietà**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Nella **Finestra Proprietà** è possibile osservare diverse schede come **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Tutte queste schede consentono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Custom** è utilizzata per gestire le proprietà personalizzate dei file PowerPoint.

### Lavorare con le proprietà del documento usando Aspose.Slides per Java

Come descritto in precedenza, Aspose.Slides per Java supporta due tipologie di proprietà del documento, cioè **Integrate** e **Personalizzate**. Pertanto gli sviluppatori possono accedere a entrambe le tipologie mediante l'API di Aspose.Slides per Java. Aspose.Slides per Java fornisce la classe [IDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides.idocumentproperties) che rappresenta le proprietà del documento associate a un file di presentazione tramite la proprietà **Presentation.DocumentProperties**.

Gli sviluppatori possono utilizzare la proprietà **IDocumentProperties** esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) per accedere alle proprietà del documento dei file di presentazione, come descritto di seguito:

## **Accesso alle proprietà integrate**

Queste proprietà, esposte dall'oggetto [IDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides.idocumentproperties), includono: **Creator** (Autore), **Description**, **Keywords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data ultima stampa), **LastModifiedBy**, **SharedDoc** (È condiviso tra più produttori?), **PresentationFormat**, **Subject** e **Title**.

```java
import com.aspose.slides.*;

// Istanziare la classe Presentation che rappresenta la presentazione
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Creare un riferimento all'oggetto IDocumentProperties associato alla Presentazione
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Visualizzare le proprietà integrate
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

## **Modifica delle proprietà integrate**

Modificare le proprietà integrate dei file di presentazione è semplice quanto accedervi. Basta assegnare una stringa a qualsiasi proprietà desiderata e il valore verrà modificato. Nell'esempio riportato di seguito, dimostriamo come modificare le proprietà integrate del documento di una presentazione usando Aspose.Slides per Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Creare un riferimento all'oggetto IDocumentProperties associato alla Presentazione
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Impostare le proprietà integrate
    dp.setAuthor("Aspose.Slides for Java");
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

Questo esempio modifica le proprietà integrate della presentazione, visualizzabili come mostrato di seguito:

|**Proprietà integrate del documento dopo la modifica**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aggiunta di proprietà personalizzate del documento**

Aspose.Slides per Java consente anche agli sviluppatori di aggiungere valori personalizzati alle proprietà del documento della presentazione. L'esempio seguente aggiunge tre proprietà personalizzate, quindi ricerca il nome memorizzato all'indice 2 e rimuove tale proprietà; così la presentazione salvata ne conserva due. Le proprietà personalizzate sono ordinate alfabeticamente, non nell'ordine di aggiunta.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Recupero delle proprietà del documento
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // Aggiunta di proprietà personalizzate
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // Recupero del nome della proprietà a un indice specifico
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // Rimozione della proprietà selezionata
    dProps.removeCustomProperty(getPropertyName);
    
    // Salvataggio della presentazione
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**Proprietà personalizzate del documento aggiunte**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accesso e modifica delle proprietà personalizzate**

Aspose.Slides per Java permette anche di accedere ai valori delle proprietà personalizzate. L'esempio seguente mostra come accedere e modificare tutte queste proprietà personalizzate per una presentazione.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Creare un riferimento all'oggetto DocumentProperties associato alla Presentazione
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

{{% alert color="info" title="Note" %}}
Sono stati aggiunti i nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) , [UpdateDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) e [WriteBindedPresentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) all'interfaccia [IPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo) ; la logica del setter della proprietà [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/it/java/com.aspose.slides.idocumentproperties#setLastSavedTime-java.util.Date-) è stata modificata.
{{% /alert %}} 

I due nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) e [UpdateDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) sono stati aggiunti all'interfaccia [IPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo). Forniscono un rapido accesso alle proprietà del documento e consentono di modificare e aggiornare le proprietà senza caricare l'intera presentazione.

Lo scenario tipico prevede di caricare le proprietà, modificare qualche valore e aggiornare il documento, come mostrato di seguito:

```java
import com.aspose.slides.*;

// leggere le informazioni della presentazione
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// ottenere le proprietà attuali
IDocumentProperties props = info.readDocumentProperties();

// impostare i nuovi valori dei campi Author e Title
props.setAuthor("New Author");
props.setTitle("New Title");

// aggiornare la presentazione con nuovi valori
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Esiste anche un modo per usare le proprietà di una determinata presentazione come modello per aggiornare le proprietà di altre presentazioni:

```java
import com.aspose.slides.*;

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

Un nuovo modello può essere creato da zero e poi utilizzato per aggiornare più presentazioni:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Impostazione della lingua di revisione**

Aspose.Slides fornisce la proprietà LanguageId (esposta dalla classe PortionFormat) per consentire di impostare la lingua di revisione per un documento PowerPoint. La lingua di revisione è quella in cui vengono controllate ortografia e grammatica nel PowerPoint.

Questo codice Java mostra come impostare la lingua di revisione per un PowerPoint:

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

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

    portionFormat.setLanguageId("zh-CN"); // imposta l'ID di una lingua di revisione

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Impostazione della lingua predefinita**

Questo codice Java mostra come impostare la lingua predefinita per un'intera presentazione PowerPoint:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // Aggiunge una nuova forma rettangolare con testo
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // Controlla la lingua della prima porzione
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Esempio live**

Prova l'app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà del documento tramite l'API di Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## **FAQ**

**Come posso rimuovere una proprietà integrata da una presentazione?**

Le proprietà integrate sono parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia è possibile modificarne i valori o impostarle a stringa vuota, se la proprietà lo consente.

**Cosa accade se aggiungo una proprietà personalizzata già esistente?**

Se si aggiunge una proprietà personalizzata già presente, il suo valore esistente viene sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì. Utilizza [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) e poi [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) per leggere i metadati del documento memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation). Consulta [Build a Lightweight Presentation Inventory](/slides/it/java/examine-presentation/) per un esempio completo di reportistica e le limitazioni specifiche per formato.