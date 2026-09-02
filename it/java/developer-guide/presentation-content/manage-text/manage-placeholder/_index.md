---
title: Gestire i segnaposti della presentazione in Java
linktitle: Gestire i segnaposti
type: docs
weight: 10
url: /it/java/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto grafico
- segnaposto di contenuto
- testo di prompt
- PowerPoint
- presentazione
- Java
- Aspose.Slides
description: "Scopri come ispezionare e modificare i segnaposti di testo, immagine, grafico e contenuto e comprendere l'eredità dei segnaposti con Aspose.Slides per Java."
---
## **Panoramica**

Un segnaposto è una forma che riserva una posizione per un particolare tipo di contenuto in un modello di presentazione. Esempi comuni sono segnaposti per titolo, corpo, immagine, grafico e contenuti di uso generale. A differenza di una forma ordinaria, un segnaposto può ereditare la sua posizione, dimensione, formattazione e altre impostazioni da una diapositiva di layout o da una diapositiva master.

Aspose.Slides espone le informazioni sui segnaposti tramite il metodo [IShape.getPlaceholder](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/). Il metodo restituisce un oggetto [IPlaceholder](https://reference.aspose.com/slides/it/java/com.aspose.slides/placeholder/) o `null` per una forma normale. Usa [IPlaceholder.getType](https://reference.aspose.com/slides/it/java/com.aspose.slides/placeholder/) per determinare cosa il segnaposto è destinato a contenere.

L'interfaccia della forma è ancora importante dopo aver conosciuto il tipo di segnaposto:

- Un segnaposto vuoto di testo, immagine, grafico o contenuto è comunemente rappresentato da un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/).
- Un segnaposto immagine popolato può essere rappresentato da un [IPictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipictureframe/).
- Un segnaposto grafico popolato può essere rappresentato da un [IChart](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichart/).
- Un segnaposto di contenuto può contenere diversi tipi di contenuto. Verifica sia [IPlaceholder.getType](https://reference.aspose.com/slides/it/java/com.aspose.slides/placeholder/) sia l'interfaccia della forma al runtime anziché presumere che ogni segnaposto sia un [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/it/java/com.aspose.slides/placeholder/) descrive il ruolo di un segnaposto; non garantisce il tipo di forma al runtime. Usa sempre un controllo di tipo prima di accedere a membri specifici di testo, immagine, grafico, tabella o media.
{{% /alert %}}

## **Comprendere l'eredità dei segnaposti**

I segnaposti formano una gerarchia:

1. Una diapositiva master definisce stili riutilizzabili e, in alcuni casi, segnaposti a livello master.
2. Una diapositiva di layout definisce la disposizione usata da una o più diapositive normali e può ereditare dal master.
3. Una diapositiva normale contiene i segnaposti per quella diapositiva e può ereditare dal suo layout.

Chiama [IShape.getBasePlaceholder](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/) per spostarsi di un livello verso l'alto in questa gerarchia. Un segnaposto di diapositiva normalmente restituisce il suo segnaposto di layout; un segnaposto di layout può restituire il suo segnaposto master. Il metodo restituisce `null` quando la forma non ha un segnaposto di base.

Il seguente esempio elenca i segnaposti nella prima diapositiva e riporta i loro segnaposti di base:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Modificare un segnaposto su una diapositiva normale crea o cambia una sovrascrittura locale per quella diapositiva. Modificare il layout o il master correlato può influenzare tutte le diapositive che continuano a ereditare tale impostazione. Una forma locale ordinaria non ha un segnaposto di base e non inizia a ereditare solo perché occupa le stesse coordinate.

## **Modificare il testo in un segnaposto**

I segnaposti titolo, titolo centrato, sottotitolo, corpo e testo normalmente supportano il testo. Verifica la presenza di [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) prima di usare il suo [getTextFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) metodo.

Questo esempio aggiorna il primo segnaposto titolo nella prima diapositiva e salva il risultato:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Questo schema evita di castare i segnaposti immagine, grafico, tabella o media a [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/). Identifica inoltre il segnaposto per scopo anziché fare affidamento su un indice di forma fragile.

## **Impostare il testo di prompt su un layout**

Il testo di prompt è l'istruzione di design-time visualizzata in un segnaposto vuoto, ad esempio *Fai clic per aggiungere il titolo*. Imposta un testo di prompt personalizzato sul segnaposto del layout invece di cercare di raggiungerlo tramite la collezione di forme di una diapositiva normale. Accedi al layout tramite [ISlide.getLayoutSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/islide/) e itera sulla collezione restituita da [ILayoutSlide.getShapes](https://reference.aspose.com/slides/it/java/com.aspose.slides/ibaseslide/).

Il seguente esempio modifica i prompt del titolo e del sottotitolo sul layout utilizzato dalla prima diapositiva:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il testo di prompt non è contenuto di diapositiva normale. È destinato ai segnaposti vuoti nelle applicazioni di modifica come PowerPoint. Una volta che un utente o un programma fornisce contenuto reale, il prompt non è più visualizzato. Modificare un prompt non sostituisce neanche il testo esistente sulle diapositive che usano il layout.

## **Aggiornare un segnaposto immagine**

Ci sono due casi da gestire:

- Se il segnaposto immagine è già popolato e rappresentato da un [IPictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipictureframe/), sostituisci l'immagine tramite [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipicturefillformat/) e [ISlidesPicture.setImage](https://reference.aspose.com/slides/it/java/com.aspose.slides/islidespicture/).
- Se è ancora un segnaposto vuoto, aggiungi un frame immagine alle coordinate del segnaposto con [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishapecollection/) e rimuovi il segnaposto vuoto.

Il prossimo esempio supporta entrambi i casi e salva la presentazione:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La sostituzione creata per un segnaposto vuoto è un frame immagine locale, non un nuovo segnaposto, perché [IShape.getPlaceholder](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/) non fornisce un setter. Mantiene la posizione riservata ma non eredita più il comportamento specifico del segnaposto. Se conservare la relazione del segnaposto è essenziale, prepara e popola il segnaposto in PowerPoint prima, quindi aggiorna il risultato [IPictureFrame](https://reference.aspose.com/slides/it/java/com.aspose.slides/ipictureframe/) con Aspose.Slides.

Per la trasparenza dell'immagine, il ritaglio e altri effetti specifici delle immagini, vedi [Gestire i frame immagine](/slides/it/java/picture-frame/). Quelle operazioni appartengono al frame immagine o al riempimento immagine, non ai metadati del segnaposto.

## **Lavorare con segnaposti grafico e contenuto**

Un segnaposto grafico popolato può essere rappresentato da un [IChart](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichart/). Questo esempio trova un tale grafico sia tramite il tipo di segnaposto sia tramite l'interfaccia al runtime, ne modifica il titolo e salva il file:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Un segnaposto di contenuto generale solitamente ha [PlaceholderType.Object](https://reference.aspose.com/slides/it/java/com.aspose.slides/placeholdertype/). In PowerPoint funge da avviatore per diversi tipi di contenuto, inclusi grafici, tabelle, diagrammi, immagini e media. Dopo che è stato popolato, ispeziona l'effettiva interfaccia della forma per capire cosa contiene. Layout specializzati possono inoltre esporre [PlaceholderType.Chart](https://reference.aspose.com/slides/it/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/it/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/it/java/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/it/java/com.aspose.slides/placeholdertype/), o [PlaceholderType.Diagram](https://reference.aspose.com/slides/it/java/com.aspose.slides/placeholdertype/).

Aspose.Slides non converte un segnaposto [IAutoShape](https://reference.aspose.com/slides/it/java/com.aspose.slides/iautoshape/) vuoto in un [IChart](https://reference.aspose.com/slides/it/java/com.aspose.slides/ichart/) semplicemente cambiando [IPlaceholder.getType](https://reference.aspose.com/slides/it/java/com.aspose.slides/placeholder/); il tipo non può essere modificato tramite l'interfaccia. Per riempire programmaticamente un'area grafico o contenuto vuota, aggiungi l'oggetto richiesto alle coordinate del segnaposto e poi rimuovi il segnaposto vuoto. Il seguente esempio lo fa per un grafico:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il grafico aggiunto è un grafico locale ordinario. Occupa l'area del segnaposto ma non eredita dal segnaposto del layout. Usa gli articoli dedicati alla [gestione dei grafici](/slides/it/java/powerpoint-charts/) quando devi sostituire categorie, serie o dati della cartella di lavoro.

## **Esempio completo: Aggiornare contenuto testuale o immagine**

Il seguente esempio end-to-end apre un modello, cerca nella prima diapositiva un segnaposto titolo o immagine, verifica i tipi di segnaposto e forma, aggiorna il contenuto appropriato e salva l'output. L'esempio evita deliberatamente di presumere un indice di forma o di castare tutti i segnaposti alla stessa interfaccia.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Che cos'è un segnaposto di base?**

Un segnaposto di base è la forma corrispondente nel layout o nel master da cui un altro segnaposto eredita. Usa [IShape.getBasePlaceholder](https://reference.aspose.com/slides/it/java/com.aspose.slides/ishape/) per recuperarlo. Una forma locale ordinaria restituisce `null` perché non fa parte della gerarchia dei segnaposti.

**Posso modificare tutti i titoli delle diapositive modificando un segnaposto di layout?**

Puoi cambiare la formattazione ereditata o il testo di prompt tramite un layout, ma il contenuto del titolo esistente è memorizzato sulle diapositive normali. Per sostituire il testo reale del titolo in tutta la presentazione, itera sulle diapositive e aggiorna ogni segnaposto titolo.

**Come gestisco i segnaposti data, numero diapositiva, intestazione e piè di pagina?**

Usa i gestori di intestazione e piè di pagina nello scope appropriato di diapositiva, layout, master, note o handout. Vedi [Gestire intestazione e piè di pagina della presentazione](/slides/it/java/presentation-header-and-footer/) per esempi completi.