---
title: Recupera e aggiorna le informazioni della presentazione in Java
linktitle: Informazioni sulla presentazione
type: docs
weight: 30
url: /it/java/examine-presentation/
keywords:
- formato della presentazione
- proprietà della presentazione
- proprietà del documento
- ottenere proprietà
- leggere proprietà
- modificare proprietà
- modificare proprietà
- aggiornare proprietà
- esaminare PPTX
- esaminare PPT
- esaminare ODP
- PowerPoint
- OpenDocument
- presentazione
- Java
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument usando Java per approfondimenti più rapidi e audit di contenuto più intelligenti."
---
## **Panoramica**

Aspose.Slides può identificare il formato di una presentazione e leggere i metadati del documento senza creare un modello completo di oggetti della presentazione. Questo è utile quando è necessario classificare i file, creare un inventario o esaminare le proprietà prima di decidere se caricare ed elaborare il contenuto della presentazione.

Questo articolo dimostra l'ispezione leggera tramite [PresentationFactory](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationfactory/) e [IPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/), nonché gli aggiornamenti mirati tramite [IDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/).

## **Verificare il formato di una presentazione**

Utilizza [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) per ispezionare un file senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/). Il metodo [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) restituisce il formato rilevato, ad esempio PPTX, PPT o ODP.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;

String[] fileNames = { "pres.pptx", "pres.ppt", "pres.odp" };

for (String fileName : fileNames) {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(fileName);
    int loadFormat = presentationInfo.getLoadFormat();
    String formatName = "Other (" + loadFormat + ")";

    if (loadFormat == LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat == LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat == LoadFormat.Odp) {
        formatName = "ODP";
    }

    System.out.println(fileName + ": " + formatName);
}
```

## **Creare un inventario leggero di presentazioni**

Quando elabori molti file di presentazione, potresti aver bisogno di un inventario compatto per la convalida, l'indicizzazione o un sistema di gestione documentale. In questo scenario, utilizza [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) per ottenere un oggetto [IPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/), quindi chiama [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) per leggere i metadati del documento. Questo approccio non crea un'istanza di [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) né richiede di attraversare l'intero modello di oggetti della presentazione.

Le proprietà estese esposte da [IDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/) forniscono i seguenti valori di inventario:

| Metodo | Valore dell'inventario |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/#getSlides--) | Numero totale di diapositive. |
| [getHiddenSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Numero di diapositive nascoste. |
| [getNotes](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/#getNotes--) | Numero di diapositive che contengono note. |
| [getParagraphs](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/#getParagraphs--) | Numero totale di paragrafi, se disponibile. |
| [getWords](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/#getWords--) | Numero totale di parole. |
| [getMultimediaClips](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Numero totale di clip audio e video. |

Il seguente esempio legge questi valori senza creare un oggetto [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/) e stampa un inventario compatto. Combina inoltre [getHeadingPairs](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/#getHeadingPairs--) con [getTitlesOfParts](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) per visualizzare gruppi di contenuto come caratteri, temi e titoli di diapositive.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IHeadingPair;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadFormat;
import com.aspose.slides.PresentationFactory;
import java.nio.file.Paths;

String filePath = "sample.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

int loadFormat = presentationInfo.getLoadFormat();
String formatName = "Other (" + loadFormat + ")";

if (loadFormat == LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat == LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat == LoadFormat.Odp) {
    formatName = "ODP";
}

System.out.println("File: " + Paths.get(filePath).getFileName());
System.out.println("Format: " + formatName);
System.out.println("Title: " + documentProperties.getTitle());
System.out.println("Author: " + documentProperties.getAuthor());
System.out.println("Statistics:");
System.out.println("  Slides: " + documentProperties.getSlides());
System.out.println("  Hidden slides: " + documentProperties.getHiddenSlides());
System.out.println("  Slides with notes: " + documentProperties.getNotes());
System.out.println("  Paragraphs: " + documentProperties.getParagraphs());
System.out.println("  Words: " + documentProperties.getWords());
System.out.println("  Multimedia clips: " + documentProperties.getMultimediaClips());

IHeadingPair[] headingPairs = documentProperties.getHeadingPairs();
String[] titlesOfParts = documentProperties.getTitlesOfParts();
headingPairs = headingPairs != null ? headingPairs : new IHeadingPair[0];
titlesOfParts = titlesOfParts != null ? titlesOfParts : new String[0];
int partIndex = 0;

if (headingPairs.length == 0 || titlesOfParts.length == 0) {
    System.out.println("Content groups: not available");
} else {
    System.out.println("Content groups:");

    for (IHeadingPair headingPair : headingPairs) {
        System.out.println("  " + headingPair.getName() + " (" + headingPair.getCount() + ")");

        for (int partOffset = 0; partOffset < headingPair.getCount() && partIndex < titlesOfParts.length; partOffset++) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        System.out.println("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            System.out.println("    - " + titlesOfParts[partIndex]);
            partIndex++;
        }
    }
}
```

Ogni [IHeadingPair](https://reference.aspose.com/slides/it/java/com.aspose.slides/iheadingpair/) fornisce un nome di gruppo e il numero di elementi in quel gruppo. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) restituisce un array piatto e ordinato, quindi consumare il numero di titoli consecutivi specificati da ciascuna coppia di intestazione.

### **Metadati memorizzati e limitazioni del formato**

Le proprietà di inventario restituite da [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) riflettono i metadati disponibili nel documento di origine. Aspose.Slides non carica e attraversa il modello di oggetti della presentazione per ricalcolare questi valori in questa chiamata. Le proprietà mancanti sono rappresentate da valori predefiniti e i valori memorizzati potrebbero essere obsoleti se l'applicazione che ha salvato l'ultimo file non ha aggiornato le proprie proprietà del documento.

- **PPTX:** Il formato fornisce proprietà documentali estese per il conteggio di diapositive, note, diapositive nascoste, paragrafi, parole e contenuti multimediali, nonché coppie di intestazioni e titoli di parti. La disponibilità dipende da quali proprietà sono state scritte dal produttore del documento.
- **PPT:** Il formato binario può memorizzare le corrispondenti proprietà di riepilogo del documento. Se una proprietà è assente o non è stata aggiornata dal produttore del documento, Aspose.Slides restituisce il valore memorizzato o predefinito invece di calcolarlo dalle diapositive.
- **ODP:** I metadati OpenDocument forniscono statistiche generali del documento, come conteggi di pagine, paragrafi e parole, ma questi valori non corrispondono a tutte le proprietà estese specifiche di PowerPoint. I metadati di diapositive nascoste, diapositive con note, multimediali, coppie di intestazioni e titoli di parti potrebbero non essere disponibili, e le proprietà di inventario potrebbero restituire valori predefiniti. Non considerare un valore zero o un array vuoto come prova autorevole dell'assenza del contenuto corrispondente.

Utilizza l'approccio dei metadati leggeri per inventari e controlli preliminari. Carica la presentazione e ispeziona il suo modello di oggetti live quando il risultato deve riflettere le modifiche in memoria o quando è necessario verificare il contenuto effettivo della presentazione.

## **Aggiornare le proprietà della presentazione**

Le proprietà restituite da [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) possono anche essere modificate senza creare un'istanza di [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/). Applica le modifiche con [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), e quindi scrivi la presentazione associata con [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

L'immagine seguente mostra le proprietà originali del documento.

![Proprietà originali del documento della presentazione PowerPoint](input_properties.png)

Il seguente esempio modifica il titolo e l'ora dell'ultimo salvataggio e scrive il risultato in un nuovo file:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;
import java.io.FileOutputStream;
import java.io.OutputStream;
import java.util.Date;

String sourceFile = "sample.pptx";
String outputFile = "sample_with_updated_properties.pptx";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(sourceFile);
IDocumentProperties documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(new Date());

presentationInfo.updateDocumentProperties(documentProperties);
try (OutputStream outputStream = new FileOutputStream(outputFile)) {
    presentationInfo.writeBindedPresentation(outputStream);
}
```

L'immagine seguente mostra le proprietà del documento modificate della presentazione PowerPoint.

![Proprietà del documento modificate della presentazione PowerPoint](output_properties.png)

## **Link utili**

Per controlli di sicurezza correlati e impostazioni di protezione, vedere i seguenti articoli:

- [Presentazioni protette da password](/slides/it/java/password-protected-presentation/)
- [Presentazioni protette in scrittura](/slides/it/java/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i caratteri sono incorporati e quali sono?**

Carica la presentazione e utilizza [Presentation.getFontsManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getFontsManager--). Chiama [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) per ottenere i caratteri incorporati e [IFontsManager.getFonts](https://reference.aspose.com/slides/it/java/com.aspose.slides/ifontsmanager/#getFonts--) per ottenere i caratteri utilizzati dalla presentazione. Confronta i due risultati per trovare i caratteri necessari per il rendering ma non incorporati.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Quando i metadati del documento memorizzati sono sufficienti, leggi [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/idocumentproperties/#getHiddenSlides--) tramite [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) e [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Questo è adatto per un inventario leggero. Se la presentazione è stata modificata in memoria, i metadati memorizzati potrebbero mancare o essere obsoleti, o se devi verificare i valori live, itera su [Presentation.getSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getSlides--) e ispeziona il metodo [ISlide.getHidden](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/#getHidden--) di ciascuna diapositiva.

**Posso rilevare se è utilizzata una dimensione e orientamento personalizzati della diapositiva e se differiscono dai valori predefiniti?**

Sì. Carica la presentazione e chiama [Presentation.getSlideSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getSlideSize--). Usa [ISlideSize.getType](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidesize/#getSize--) e [ISlideSize.getOrientation](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidesize/#getOrientation--) per confrontare le impostazioni attuali con il preset e le dimensioni previste.

**Esiste un modo rapido per verificare se i grafici fanno riferimento a fonti dati esterne?**

Sì. Individua ciascun [Chart](https://reference.aspose.com/slides/it/java/com.aspose.slides/chart/) e chiama [IChartData.getDataSourceType](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#getDataSourceType--). Per una cartella di lavoro esterna, chiama [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). Il tipo di origine dati e il percorso identificano un riferimento esterno, ma verificare se il target è disponibile richiede un controllo di risorse separato.

**Come posso valutare le diapositive 'pesanti' che potrebbero rallentare il rendering o l'esportazione PDF?**

Non esiste una singola proprietà di complessità. Attraversa [Presentation.getSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getSlides--) e la collezione [IBaseSlide.getShapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseslide/#getShapes--) di ciascuna diapositiva. Usa il conteggio delle forme e la presenza di immagini grandi, effetti, animazioni o contenuti multimediali come segnali di screening, e misura un rendering o un'esportazione rappresentativa prima di considerare una diapositiva come un colletto di bottiglia di prestazioni confermato.