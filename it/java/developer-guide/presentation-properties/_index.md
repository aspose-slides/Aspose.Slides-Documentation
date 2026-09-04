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
- lingua di correzione
- lingua predefinita
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Gestisci le proprietà delle presentazioni in Aspose.Slides per Java e semplifica la ricerca, il branding e il flusso di lavoro nei tuoi file PowerPoint e OpenDocument."
---
## **Introduzione**

Aspose.Slides supporta due tipi di proprietà del documento: **Integrate** e **Personalizzate**. Entrambi i tipi di proprietà possono essere facilmente acceduti e gestiti tramite l'API di Aspose.Slides.

Aspose.Slides consente di lavorare con le proprietà del documento della presentazione attraverso l'interfaccia [IDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/). Un'istanza di questa interfaccia viene restituita da [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#getDocumentProperties--). Gli esempi seguenti mostrano come leggere, modificare e gestire queste proprietà.

{{% alert color="info" title="Note" %}}
Si noti che i campi **Application** e **AppVersion** non possono essere modificati. Aspose.Slides li riscrive ad ogni salvataggio, quindi una presentazione salvata riporta sempre "Aspose.Slides for Java" e la versione della libreria che l'ha generata. Qualsiasi valore passato a `setNameOfApplication` viene scartato quando la presentazione viene scritta.
{{% /alert %}} 

## **Proprietà del Documento in PowerPoint**

Microsoft PowerPoint 2007 consente di gestire le proprietà del documento dei file di presentazione. È sufficiente fare clic sull'icona Office e poi sul menu **Prepare | Properties | Advanced Properties** di Microsoft PowerPoint 2007, come mostrato di seguito:

|**Selezione voce di menu Proprietà avanzate**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Dopo aver selezionato la voce di menu **Advanced Properties**, appare una finestra di dialogo che consente di gestire le proprietà del documento del file PowerPoint, come mostrato nella figura seguente:

|**Finestra Proprietà**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
Nella suddetta **Finestra Proprietà** è possibile vedere molte schede come **General**, **Summary**, **Statistics**, **Contents** e **Custom**. Tutte queste schede consentono di configurare diversi tipi di informazioni relative ai file PowerPoint. La scheda **Custom** viene utilizzata per gestire le proprietà personalizzate dei file PowerPoint.

## **Lavorare con le Proprietà del Documento usando Aspose.Slides for Java**

Come descritto in precedenza, Aspose.Slides for Java supporta due tipi di proprietà del documento, ovvero **Integrate** e **Personalizzate**. Pertanto, gli sviluppatori possono accedere a entrambi i tipi di proprietà mediante l'API di Aspose.Slides for Java. Aspose.Slides for Java fornisce la classe [IDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties) che rappresenta le proprietà del documento associate a un file di presentazione tramite la proprietà **Presentation.DocumentProperties**.

Gli sviluppatori possono utilizzare la proprietà **IDocumentProperties** esposta dall'oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation) per accedere alle proprietà del documento dei file di presentazione, come descritto di seguito:

## **Leggi le Proprietà Pubbliche da una Presentazione Cifrata**

Una password di apertura protegge normalmente sia il contenuto della presentazione sia le proprietà del documento. Quando una presentazione è cifrata passando `false` a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-), le sue proprietà del documento rimangono pubbliche. Un'applicazione può quindi passare `true` a [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-) e leggere i metadati pubblici senza fornire la password di apertura.

L'opzione che carica solo le proprietà del documento controlla cosa Aspose.Slides carica; non decritta nulla. Se le proprietà erano incluse nella cifratura, il loro caricamento senza password fallisce. Se la presentazione non è cifrata, l'opzione viene ignorata e viene caricata l'intera presentazione.

L'esempio seguente verifica la modalità di caricamento tramite [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) e quindi legge le proprietà integrate tramite [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

In questa modalità, il contenuto delle diapositive non viene caricato. Diapositive, master, layout, forme, media e altri oggetti della presentazione non sono disponibili. Le applicazioni dovrebbero sempre verificare [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/it/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--) prima di eseguire un'operazione che richiede il modello di oggetti completo della presentazione.

{{% alert color="warning" title="Warning" %}}
I metadati pubblici possono esporre nomi degli autori, titoli, soggetti, parole chiave, informazioni aziendali, commenti e valori personalizzati. Cifrare le proprietà sensibili insieme alla presentazione. Mantenerle pubbliche solo quando sistemi di indicizzazione, classificazione, ricerca o gestione documentale richiedono specificamente l'accesso senza password.
{{% /alert %}}

## **Aggiorna le Proprietà di una Presentazione Cifrata**

Per un file PPTX cifrato, una presentazione caricata in modalità solo‑proprietà‑documento è destinata alla lettura dei metadati pubblici. Aspose.Slides non può salvare le proprietà modificate da quell'oggetto solo‑metadati perché le proprietà pubbliche devono rimanere coerenti con i dati corrispondenti all'interno della presentazione cifrata. Pertanto, l'aggiornamento richiede la password di apertura corretta e un caricamento completo.

L'esempio seguente apre la presentazione con [LoadOptions.setPassword](https://reference.aspose.com/slides/it/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), aggiorna le proprietà integrate pubbliche e salva il risultato. Successivamente utilizza [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#isEncrypted--) per verificare che la cifratura sia preservata e riapre i metadati pubblici senza password per verificare i nuovi valori:

```java
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
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
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

Se un'applicazione non è autorizzata a decifrare o caricare il contenuto della presentazione, deve trattare le proprietà pubbliche di un file PPTX cifrato come sola lettura.

## **Accedi alle Proprietà Integrate**

Queste proprietà, esposte dall'oggetto [IDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties), includono: **Creator** (Autore), **Description**, **Keywords**, **Created** (Data di creazione), **Modified** (Data di modifica), **Printed** (Data ultima stampa), **LastModifiedBy**, **SharedDoc** (È condiviso tra diversi produttori?), **PresentationFormat**, **Subject** e **Title**.

```java
import com.aspose.slides.*;

// Istanziare la classe Presentation che rappresenta la presentazione
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Creare un riferimento all'oggetto IDocumentProperties associato alla Presentation
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

## **Modifica le Proprietà Integrate**

Modificare le proprietà integrate dei file di presentazione è semplice quanto accedervi. È sufficiente assegnare una stringa a qualsiasi proprietà desiderata e il valore verrà modificato. Nell'esempio sottostante mostriamo come modificare le proprietà integrate del documento di una presentazione utilizzando Aspose.Slides for Java.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Creare un riferimento all'oggetto IDocumentProperties associato alla Presentation
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

|**Proprietà del documento integrate dopo la modifica**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Aggiungi Proprietà Documentali Personalizzate**

Aspose.Slides for Java consente anche agli sviluppatori di aggiungere valori personalizzati per le proprietà del documento della presentazione. L'esempio sottostante aggiunge tre proprietà personalizzate, poi cerca il nome memorizzato all'indice 2 e rimuove quella proprietà, così la presentazione salvata ne conserva due. Le proprietà personalizzate sono indicizzate in ordine alfabetico, non nell'ordine di aggiunta.

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

|**Proprietà Documentali Personalizzate Aggiunte**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Accedi e Modifica Proprietà Personalizzate**

Aspose.Slides for Java consente inoltre agli sviluppatori di accedere ai valori delle proprietà personalizzate. Di seguito è mostrato un esempio che illustra come accedere e modificare tutte queste proprietà personalizzate per una presentazione.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Creare un riferimento all'oggetto DocumentProperties associato alla Presentation
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

|**Proprietà Personalizzate prima della Modifica**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**Proprietà Personalizzate dopo la Modifica**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **Proprietà Documentali Avanzate**

{{% alert color="info" title="Note" %}}
Sono stati aggiunti i nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), e [WriteBindedPresentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) a [IPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo); la logica del setter della proprietà [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) è stata modificata.
{{% /alert %}} 

I due nuovi metodi [ReadDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--) e [UpdateDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) sono stati aggiunti all'interfaccia [IPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/IPresentationInfo). Forniscono un accesso rapido alle proprietà del documento e consentono di cambiare e aggiornare le proprietà senza caricare tutta la presentazione.

Lo scenario tipico di caricamento delle proprietà, modifica di qualche valore e aggiornamento del documento può essere implementato nel seguente modo:

```java
import com.aspose.slides.*;

// leggi le informazioni della presentazione
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

È possibile utilizzare le proprietà di una presentazione specifica come modello per aggiornare le proprietà in altre presentazioni:

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

## **Imposta la Lingua di Correzione**

Aspose.Slides fornisce la proprietà LanguageId (esposta dalla classe PortionFormat) per consentire di impostare la lingua di correzione per un documento PowerPoint. La lingua di correzione è quella per cui vengono controllati ortografia e grammatica nel PowerPoint.

Questo codice Java mostra come impostare la lingua di correzione per un PowerPoint:

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

    portionFormat.setLanguageId("zh-CN"); // imposta l'Id di una lingua di correzione

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Imposta la Lingua Predefinita**

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

    // Verifica la lingua della prima porzione
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Esempio Live**

Prova l'app online [**Aspose.Slides Metadata**](https://products.aspose.app/slides/it/metadata) per vedere come lavorare con le proprietà del documento tramite l'API di Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/it/metadata)

## **FAQ**

**Come posso rimuovere una proprietà integrata da una presentazione?**

Le proprietà integrate fanno parte integrante della presentazione e non possono essere rimosse del tutto. Tuttavia, è possibile cambiarne i valori o impostarle a vuoto, se la proprietà lo consente.

**Cosa succede se aggiungo una proprietà personalizzata che esiste già?**

Se si aggiunge una proprietà personalizzata già esistente, il suo valore verrà sovrascritto con quello nuovo. Non è necessario rimuovere o verificare la proprietà in anticipo, poiché Aspose.Slides aggiorna automaticamente il valore.

**Posso accedere alle proprietà della presentazione senza caricare completamente la presentazione?**

Sì. Utilizza [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) e poi [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) per leggere i metadati del documento memorizzati senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/). Vedi [Build a Lightweight Presentation Inventory](/slides/it/java/examine-presentation/) per un esempio completo di reportistica e le limitazioni specifiche del formato.

**Posso leggere le proprietà pubbliche di una presentazione cifrata senza la password di apertura?**

Sì. La cifratura delle proprietà del documento deve essere stata disabilitata prima della cifratura della presentazione, e la presentazione deve essere caricata in modalità solo‑proprietà‑documento.

**Posso aggiornare un file PPTX cifrato in modalità solo‑proprietà‑documento?**

No. I dati delle proprietà pubbliche e cifrate devono rimanere coerenti, quindi l'aggiornamento di un file PPTX cifrato richiede il caricamento completo della presentazione con la password di apertura corretta.