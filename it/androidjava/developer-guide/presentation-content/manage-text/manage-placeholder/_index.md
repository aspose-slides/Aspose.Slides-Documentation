---
title: Gestire i segnaposto della presentazione su Android
linktitle: Gestire i segnaposto
type: docs
weight: 10
url: /it/androidjava/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto grafico
- segnaposto di contenuto
- testo di prompt
- PowerPoint
- presentazione
- Android
- Java
- Aspose.Slides
description: "Impara a ispezionare e modificare i segnaposto di testo, immagine, grafico e contenuto e a comprendere l'eredità dei segnaposto con Aspose.Slides per Android tramite Java."
---
## **Panoramica**

Un segnaposto è una forma che riserva una posizione per un particolare tipo di contenuto in un modello di presentazione. Esempi comuni sono segnaposti per titolo, corpo, immagine, grafico e contenuto generico. A differenza di una forma ordinaria, un segnaposto può ereditare la sua posizione, dimensione, formattazione e altre impostazioni da una diapositiva di layout o da una diapositiva master.

Aspose.Slides espone le informazioni sui segnaposto tramite il metodo [IShape.getPlaceholder](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/). Il metodo restituisce un oggetto [IPlaceholder](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/placeholder/) o `null` per una forma normale. Utilizzare [IPlaceholder.getType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/placeholder/) per determinare cosa il segnaposto è destinato a contenere.

L'interfaccia della forma rimane importante dopo aver conosciuto il tipo di segnaposto:

- Un segnaposto vuoto di testo, immagine, grafico o contenuto è comunemente rappresentato da un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/).
- Un segnaposto immagine popolato può essere rappresentato da un [IPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/).
- Un segnaposto grafico popolato può essere rappresentato da un [IChart](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichart/).
- Un segnaposto di contenuto può contenere diversi tipi di contenuto. Controllare sia [IPlaceholder.getType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/placeholder/) sia l'interfaccia della forma a runtime invece di presumere che ogni segnaposto sia un [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/placeholder/) descrive il ruolo di un segnaposto; non garantisce il tipo di forma a runtime. Utilizzare sempre un controllo del tipo prima di accedere a membri specifici di testo, immagine, grafico, tabella o media.
{{% /alert %}}

## **Comprendere l'Ereditarietà dei Segnaposto**

I segnaposto formano una gerarchia:

1. Una diapositiva master definisce stili riutilizzabili e, in alcuni casi, segnaposti a livello master.
2. Una diapositiva layout definisce la disposizione usata da una o più diapositive normali e può ereditare dal master.
3. Una diapositiva normale contiene i segnaposto per quella diapositiva e può ereditare dal suo layout.

Chiamare [IShape.getBasePlaceholder](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/) per spostarsi un livello più in alto in questa gerarchia. Un segnaposto di diapositiva normalmente restituisce il suo segnaposto di layout; un segnaposto di layout può restituire il suo segnaposto master. Il metodo restituisce `null` quando la forma non ha un segnaposto base.

Il seguente esempio elenca i segnaposto nella prima diapositiva e segnala i loro segnaposto base:

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

Modificare un segnaposto su una diapositiva normale crea o modifica un'override locale per quella diapositiva. Modificare il layout o il master correlato può influenzare tutte le diapositive che ereditano ancora quella impostazione. Una forma locale ordinaria non ha un segnaposto base e non inizia a ereditare solo perché occupa le stesse coordinate.

## **Modificare il Testo in un Segnaposto**

I segnaposto titolo, titolo centrato, sottotitolo, corpo e testo supportano normalmente il testo. Verificare la presenza di [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) prima di utilizzare il suo [getTextFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) metodo.

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

Questo modello evita il cast di segnaposto immagine, grafico, tabella o media a [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/). Identifica inoltre il segnaposto per scopo invece di fare affidamento su un indice di forma fragile.

## **Impostare il Testo di Prompt in un Layout**

Il testo di prompt è l'istruzione di progettazione visualizzata in un segnaposto vuoto, ad esempio *Fare clic per aggiungere il titolo*. Impostare un testo di prompt personalizzato sul segnaposto del layout anziché tentare di accedervi tramite la raccolta di forme di una diapositiva normale. Accedere al layout tramite [ISlide.getLayoutSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islide/) e iterare sulla raccolta restituita da [ILayoutSlide.getShapes](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ibaseslide/).

Il seguente esempio modifica i prompt di titolo e sottotitolo nel layout usato dalla prima diapositiva:

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

Il testo di prompt non è contenuto di una diapositiva normale. È destinato ai segnaposto vuoti in applicazioni di modifica come PowerPoint. Una volta che un utente o un programma fornisce contenuto reale, il prompt non è più visualizzato. Modificare un prompt non sostituisce inoltre il testo esistente sulle diapositive che usano il layout.

## **Aggiornare un Segnaposto Immagine**

Ci sono due casi da gestire:

- Se il segnaposto immagine è già popolato e rappresentato da un [IPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/), sostituire l'immagine tramite [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipicturefillformat/) e [ISlidesPicture.setImage](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/islidespicture/).
- Se è ancora un segnaposto vuoto, aggiungere un frame immagine alle coordinate del segnaposto con [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishapecollection/) e rimuovere il segnaposto vuoto.

Il prossimo esempio supporta entrambi i casi e salva la presentazione:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

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

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

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

La sostituzione creata per un segnaposto vuoto è un frame immagine locale, non un nuovo segnaposto, perché [IShape.getPlaceholder](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/) non fornisce un setter. Mantiene la posizione riservata ma non eredita più il comportamento specifico del segnaposto. Se mantenere la relazione del segnaposto è essenziale, preparare e popolare prima il segnaposto in PowerPoint, quindi aggiornare il [IPictureFrame](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ipictureframe/) risultante con Aspose.Slides.

Per la trasparenza dell'immagine, il ritaglio e altri effetti specifici dell'immagine, vedere [Manage Picture Frames](/slides/it/androidjava/picture-frame/). Quelle operazioni appartengono al frame immagine o al riempimento immagine, non ai metadati del segnaposto.

## **Lavorare con Segnaposti Grafico e Contenuto**

Un segnaposto grafico popolato può essere rappresentato da un [IChart](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichart/). Questo esempio trova tale grafico sia per tipo di segnaposto sia per interfaccia a runtime, ne modifica il titolo e salva il file:

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

Un segnaposto di contenuto generico di solito ha [PlaceholderType.Object](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/placeholdertype/). In PowerPoint agisce come avviatore per diversi tipi di contenuto, inclusi grafici, tabelle, diagrammi, immagini e media. Dopo che è stato popolato, ispezionare l'interfaccia della forma reale per capire cosa contiene. I layout specializzati possono anche esporre [PlaceholderType.Chart](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/placeholdertype/), o [PlaceholderType.Diagram](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/placeholdertype/).

Aspose.Slides non converte un segnaposto [IAutoShape](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/iautoshape/) vuoto in un [IChart](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ichart/) semplicemente modificando [IPlaceholder.getType](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/placeholder/); il tipo non può essere cambiato tramite l'interfaccia. Per riempire programmaticamente un'area grafico o contenuto vuota, aggiungere l'oggetto richiesto alle coordinate del segnaposto e poi rimuovere il segnaposto vuoto. Il seguente esempio lo fa per un grafico:

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

Il grafico aggiunto è un grafico locale ordinario. Occupta l'area del segnaposto ma non eredita dal segnaposto del layout. Utilizzare gli articoli dedicati alla [chart management articles](/slides/it/androidjava/powerpoint-charts/) quando è necessario sostituire le sue categorie, serie o dati della cartella di lavoro.

## **Esempio Completo: Aggiornare Testo o Contenuto Immagine**

Il seguente esempio end-to-end apre un modello, ricerca nella prima diapositiva un segnaposto titolo o immagine, verifica i tipi di segnaposto e forma, aggiorna il contenuto appropriato e salva l'output. L'esempio evita deliberatamente di presumere un indice di forma o di castare ogni segnaposto alla stessa interfaccia.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

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
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

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

**Che cos'è un segnaposto base?**

Un segnaposto base è la forma corrispondente sul layout o master da cui un altro segnaposto eredita. Utilizzare [IShape.getBasePlaceholder](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ishape/) per recuperarlo. Una forma locale ordinaria restituisce `null` perché non fa parte della gerarchia dei segnaposti.

**Posso cambiare tutti i titoli delle diapositive modificando un segnaposto di layout?**

È possibile modificare la formattazione o il testo di prompt ereditati tramite un layout, ma il contenuto del titolo esistente è memorizzato sulle diapositive normali. Per sostituire il testo reale del titolo in tutta la presentazione, iterare sulle diapositive e aggiornare ogni segnaposto titolo.

**Come gestisco i segnaposto data, numero diapositiva, intestazione e piè di pagina?**

Utilizzare i gestori di intestazione e piè di pagina nello scopo appropriato (diapositiva, layout, master, note o dispense). Vedere [Manage Presentation Header and Footer](/slides/it/androidjava/presentation-header-and-footer/) per esempi completi.