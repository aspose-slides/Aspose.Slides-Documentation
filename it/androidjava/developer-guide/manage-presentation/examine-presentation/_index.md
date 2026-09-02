---
title: Recupera e Aggiorna le Informazioni della Presentazione su Android
linktitle: Informazioni sulla Presentazione
type: docs
weight: 30
url: /it/androidjava/examine-presentation/
keywords:
- formato della presentazione
- proprietà della presentazione
- proprietà del documento
- ottenere le proprietà
- leggere le proprietà
- modificare le proprietà
- modificare le proprietà
- aggiornare le proprietà
- esaminare PPTX
- esaminare PPT
- esaminare ODP
- PowerPoint
- OpenDocument
- presentazione
- Android
- Java
- Aspose.Slides
description: "Esplora diapositive, struttura e metadati nelle presentazioni PowerPoint e OpenDocument usando Java per approfondimenti più rapidi e audit di contenuto più intelligenti."
---
## **Panoramica**

Aspose.Slides può identificare il formato di una presentazione e leggere i metadati del documento senza creare un modello completo di oggetti della presentazione. Questo è utile quando è necessario classificare i file, creare un inventario o ispezionare le proprietà prima di decidere se caricare e elaborare il contenuto della presentazione.

Questo articolo dimostra l’ispezione leggera tramite [PresentationFactory](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationfactory/) e [IPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/), nonché gli aggiornamenti mirati tramite [IDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties/).

## **Verifica il formato di una presentazione**

Usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) per ispezionare un file senza creare un’istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/). Il metodo [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) restituisce il formato rilevato, ad esempio PPTX, PPT o ODP.

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

## **Costruisci un inventario leggero delle presentazioni**

Quando si elaborano molte presentazioni, può essere necessario un inventario compatto per convalida, indicizzazione o un sistema di gestione dei documenti. In questo scenario, usa [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) per ottenere un oggetto [IPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/), quindi chiama [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) per leggere i metadati del documento. Questo approccio non crea un’istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) né richiede di attraversare l’intero modello di oggetti della presentazione.

Le proprietà estese esposte da [IDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties/) forniscono i seguenti valori di inventario:

| Method | Inventory value |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties/#getSlides--) | Numero totale di diapositive. |
| [getHiddenSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) | Numero di diapositive nascoste. |
| [getNotes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties/#getNotes--) | Numero di diapositive che contengono note. |
| [getParagraphs](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties/#getParagraphs--) | Numero totale di paragrafi, se disponibili. |
| [getWords](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties/#getWords--) | Numero totale di parole. |
| [getMultimediaClips](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties/#getMultimediaClips--) | Numero totale di clip audio e video. |

L’esempio seguente legge questi valori senza creare un oggetto [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/) e stampa un inventario compatto. Combina inoltre [getHeadingPairs](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties/#getHeadingPairs--) con [getTitlesOfParts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) per visualizzare gruppi di contenuti come caratteri, temi e titoli delle diapositive.

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

Ogni [IHeadingPair](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iheadingpair/) fornisce un nome di gruppo e il numero di elementi in quel gruppo. [IDocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties/#getTitlesOfParts--) restituisce un array piatto e ordinato, quindi consumare il numero di titoli consecutivi specificato da ciascuna coppia di intestazione.

### **Metadati archiviati e limitazioni del formato**

Le proprietà di inventario restituite da [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) riflettono i metadati disponibili nel documento sorgente. Aspose.Slides non carica e non attraversa il modello di oggetti della presentazione per ricalcolare questi valori per questa chiamata. Le proprietà mancanti sono rappresentate da valori predefiniti e i valori memorizzati possono essere obsoleti se l’applicazione che ha salvato per ultima il file non ha aggiornato le proprietà del documento.

- **PPTX:** il formato fornisce proprietà di documento estese per conteggi di diapositive, note, diapositive nascoste, paragrafi, parole e multimedia, nonché coppie di intestazioni e titoli delle parti. La disponibilità dipende da quali proprietà sono state scritte dal produttore del documento.
- **PPT:** il formato binario può memorizzare le corrispondenti proprietà di riepilogo del documento. Se una proprietà è assente o non è stata aggiornata dal produttore del documento, Aspose.Slides restituisce il valore memorizzato o predefinito anziché calcolarlo dalle diapositive.
- **ODP:** i metadati OpenDocument forniscono statistiche generali del documento, come conteggi di pagine, paragrafi e parole, ma questi valori non corrispondono a tutte le proprietà estese specifiche di PowerPoint. I metadati relativi a diapositive nascoste, note, multimedia, coppie di intestazioni e titoli delle parti potrebbero non essere disponibili e le proprietà di inventario possono restituire valori predefiniti. Non trattare un valore zero o un array vuoto come prova autorevole dell’assenza del contenuto corrispondente.

Usa l’approccio di metadati leggeri per inventari e controlli preliminari. Carica la presentazione e ispeziona il suo modello di oggetti live quando il risultato deve riflettere modifiche in memoria o quando è necessario verificare il contenuto reale della presentazione.

## **Aggiorna le proprietà della presentazione**

Le proprietà restituite da [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--) possono anche essere modificate senza creare un’istanza di [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/). Applica le modifiche con [IPresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) e quindi scrivi la presentazione collegata con [IPresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#writeBindedPresentation-java.io.OutputStream-).

L’immagine seguente mostra le proprietà originali del documento.

![Original document properties of the PowerPoint presentation](input_properties.png)

L’esempio seguente modifica il titolo e l’orario di ultimo salvataggio e scrive il risultato in un nuovo file:

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

L’immagine seguente mostra le proprietà del documento aggiornate.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Link utili**

Per controlli di sicurezza correlati e impostazioni di protezione, vedere i seguenti articoli:

- [Password-Protect Presentations](/slides/it/androidjava/password-protected-presentation/)
- [Write-Protect Presentations](/slides/it/androidjava/write-protected-presentation/)

## **FAQ**

**Come posso verificare se i font sono incorporati e quali sono?**

Carica la presentazione e usa [Presentation.getFontsManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getFontsManager--). Chiama [IFontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifontsmanager/#getEmbeddedFonts--) per ottenere i font incorporati e [IFontsManager.getFonts](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ifontsmanager/#getFonts--) per ottenere i font utilizzati dalla presentazione. Confronta i due risultati per trovare i font richiesti per il rendering ma non incorporati.

**Come posso capire rapidamente se il file contiene diapositive nascoste e quante?**

Quando i metadati del documento memorizzati sono sufficienti, leggi [IDocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/idocumentproperties/#getHiddenSlides--) tramite [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) e [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipresentationinfo/#readDocumentProperties--). Questo è adatto per un inventario leggero. Se la presentazione è stata modificata in memoria, i metadati memorizzati potrebbero mancare o essere obsoleti, o se è necessario verificare i valori live, itera attraverso [Presentation.getSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSlides--) e ispeziona il metodo [ISlide.getHidden](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/#getHidden--) di ciascuna diapositiva.

**Posso rilevare se è stata usata una dimensione o un’orientazione personalizzata della diapositiva e se differiscono dalle impostazioni predefinite?**

Sì. Carica la presentazione e chiama [Presentation.getSlideSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSlideSize--). Usa [ISlideSize.getType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidesize/#getType--), [ISlideSize.getSize](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidesize/#getSize--) e [ISlideSize.getOrientation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidesize/#getOrientation--) per confrontare le impostazioni correnti con i valori predefiniti e le dimensioni attese.

**C’è un modo rapido per verificare se i grafici fanno riferimento a fonti dati esterne?**

Sì. Individua ogni [Chart](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/chart/) e chiama [IChartData.getDataSourceType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--). Per una cartella di lavoro esterna, chiama [IChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--). Il tipo di fonte dati e il percorso identificano un riferimento esterno, ma verificare la disponibilità del target richiede un controllo di risorse separato.

**Come posso valutare le diapositive “pesanti” che potrebbero rallentare il rendering o l’esportazione PDF?**

Non esiste una singola proprietà di complessità. Scorri [Presentation.getSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getSlides--) e la collezione [IBaseSlide.getShapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseslide/#getShapes--) di ciascuna diapositiva. Usa il conteggio delle forme e la presenza di immagini di grandi dimensioni, effetti, animazioni o multimedia come segnali di screening, e misura un rendering o un’esportazione rappresentativa prima di considerare una diapositiva come un collo di bottiglia confermato.