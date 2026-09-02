---
title: Gestire le proprietà della presentazione su Android
linktitle: Proprietà della presentazione
type: docs
weight: 70
url: /it/androidjava/presentation-properties/
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
- Android
- Java
- Aspose.Slides
description: "Gestisci le proprietà della presentazione in Aspose.Slides per Android via Java e semplifica la ricerca, il branding e il flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides supporta due tipi di proprietà del documento: **Built-in** e **Custom**. Entrambi i tipi di proprietà possono essere facilmente accessibili e gestiti utilizzando l'API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà del documento di una presentazione tramite l'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties/). Un'istanza di questa interfaccia è restituita dal metodo [Presentation.getDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) . Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Nota" %}}

Si noti che i campi **Application** e **AppVersion** non possono essere modificati. Aspose.Slides li riscrive ad ogni salvataggio, quindi una presentazione salvata riporta sempre il nome del prodotto Aspose.Slides e la versione della libreria che l'ha prodotta. Qualsiasi valore passato a `setNameOfApplication` viene scartato quando la presentazione viene scritta.

{{% /alert %}} 

## **Proprietà del documento in PowerPoint**

Microsoft PowerPoint 2007 consente di gestire le proprietà del documento dei file di presentazione. È sufficiente fare clic sull'icona Office e poi sul menu **Prepare | Properties | Advanced Properties** di Microsoft PowerPoint 2007, come mostrato sotto:

|**Selezionare voce di menu Proprietà avanzate**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Dopo aver selezionato la voce di menu **Advanced Properties**, compare una finestra di dialogo che permette di gestire le proprietà del documento del file PowerPoint, come mostrato nella figura seguente:

|**Dialogo proprietà**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Nel suddetto **Dialogo proprietà**, è possibile vedere molte schede come **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Tutte queste schede consentono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Custom** è utilizzata per gestire le proprietà personalizzate dei file PowerPoint.



Lavorare con le proprietà del documento usando Aspose.Slides per Android via Java

Come descritto in precedenza, Aspose.Slides per Android via Java supporta due tipologie di proprietà del documento, ovvero le proprietà **Built-in** e **Custom**. Pertanto, gli sviluppatori possono accedere a entrambe le tipologie di proprietà mediante l'API di Aspose.Slides per Android via Java. Aspose.Slides per Android via Java fornisce la classe [IDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties) che rappresenta le proprietà del documento associate a un file di presentazione tramite la proprietà **Presentation.DocumentProperties**.

Gli sviluppatori possono utilizzare la proprietà **IDocumentProperties** esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation) per accedere alle proprietà del documento dei file di presentazione come descritto di seguito:

## **Accedere alle proprietà Built-in**

Queste proprietà, esposte dall'oggetto [IDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties), includono: **Creator** (Autore), **Description**, **Keywords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data ultima stampa), **LastModifiedBy**, **Keywords**, **SharedDoc** (È condiviso tra diversi produttori?), **PresentationFormat**, **Subject** e **Title**.

```java
import com.aspose.slides.*;

// Istanziare la classe Presentation che rappresenta la presentazione
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Creare un riferimento all'oggetto IDocumentProperties associato alla presentazione
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

## **Modificare le proprietà Built-in**

Modificare le proprietà built-in dei file di presentazione è semplice come accedervi. È sufficiente assegnare un valore stringa a qualsiasi proprietà desiderata e il valore della proprietà verrà modificato. Nell'esempio seguente, abbiamo dimostrato come modificare le proprietà built-in del documento di una presentazione usando Aspose.Slides per Android via Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Creare un riferimento all'oggetto IDocumentProperties associato alla presentazione
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Impostare le proprietà integrate
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

Questo esempio modifica le proprietà built-in della presentazione, come mostrato di seguito:

|**Proprietà documento Built-in dopo la modifica**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aggiungere proprietà documento personalizzate**

Aspose.Slides per Android via Java consente inoltre agli sviluppatori di aggiungere valori personalizzati per le proprietà del documento della presentazione. L'esempio qui sotto aggiunge tre proprietà personalizzate, poi cerca il nome memorizzato all'indice 2 e rimuove quella proprietà, così la presentazione salvata ne conserva due. Le proprietà personalizzate vengono indicizzate in ordine alfabetico, non nell'ordine in cui sono state aggiunte.

```java
import com.aspose.slides.*;

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

|**Proprietà documento personalizzate aggiunte**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accedere e modificare le proprietà personalizzate**

Aspose.Slides per Android via Java consente inoltre agli sviluppatori di accedere ai valori delle proprietà personalizzate. Di seguito è riportato un esempio che mostra come accedere e modificare tutte queste proprietà personalizzate per una presentazione.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Creare un riferimento all'oggetto DocumentProperties associato alla presentazione
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

Questo esempio modifica le proprietà personalizzate della presentazione [PPTX ](https://docs.fileformat.com/presentation/pptx/). Le figure successive mostrano le proprietà personalizzate della presentazione prima e dopo la modifica:

|**Proprietà personalizzate prima della modifica**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Proprietà personalizzate dopo la modifica**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Proprietà documento avanzate**

{{% alert color="info" title="Nota" %}}

Sono stati aggiunti i nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), e [WriteBindedPresentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) a [IPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentationInfo); la logica del setter della proprietà [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) è stata modificata.

{{% /alert %}} 

I due nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) e [UpdateDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) sono stati aggiunti all'interfaccia [IPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/IPresentationInfo). Consentono un accesso rapido alle proprietà del documento e permettono di cambiare e aggiornare le proprietà senza caricare l'intera presentazione.

Lo scenario tipico consiste nel caricare le proprietà, modificare qualche valore e aggiornare il documento, come può essere implementato nel modo seguente:

```java
import com.aspose.slides.*;

// leggere le informazioni della presentazione
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

Esiste un altro modo per utilizzare le proprietà di una determinata presentazione come modello per aggiornare le proprietà in altre presentazioni:

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

updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
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

È possibile creare un nuovo modello da zero e poi usarlo per aggiornare più presentazioni:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **Impostare la lingua di correzione**

Aspose.Slides fornisce la proprietà LanguageId (esposta dalla classe PortionFormat) per consentire di impostare la lingua di correzione per un documento PowerPoint. La lingua di correzione è la lingua per cui vengono controllate ortografia e grammatica nel PowerPoint.

Questo codice Java mostra come impostare la lingua di correzione per un PowerPoint:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

    portionFormat.setLanguageId("zh-CN"); // impostare l'Id di una lingua di correzione

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Impostare la lingua predefinita**

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

## **Esempio dal vivo**

Prova l'app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà del documento tramite l'API di Aspose.Slides:

[![Visualizza e modifica metadati PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## **FAQ**

**Come posso rimuovere una proprietà built-in da una presentazione?**

Le proprietà built-in sono parte integrante della presentazione e non possono essere rimosse completamente. Tuttavia, è possibile modificarne i valori o impostarle a stringa vuota, se consentito dalla proprietà specifica.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se si aggiunge una proprietà personalizzata già esistente, il suo valore corrente verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore della proprietà.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì. Utilizza [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) e poi [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) per leggere i metadati del documento memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/). Consulta [Build a Lightweight Presentation Inventory](/slides/it/androidjava/examine-presentation/) per un esempio completo di reporting e per conoscere le limitazioni specifiche dei formati.