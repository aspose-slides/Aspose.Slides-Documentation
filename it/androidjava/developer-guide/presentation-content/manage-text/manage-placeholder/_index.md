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
description: "Impara come ispezionare e modificare segnaposto di testo, immagine, grafico e contenuto e comprendere l'eredità dei segnaposto con Aspose.Slides per Android tramite Java."
---
## **Panoramica**

Un segnaposto è una forma che riserva una posizione per un particolare tipo di contenuto in un modello di presentazione. Esempi comuni sono segnaposto per titolo, corpo, immagine, grafico e segnaposto di contenuto generico. A differenza di una forma ordinaria, un segnaposto può ereditare la sua posizione, dimensione, formattazione e altre impostazioni da una diapositiva di layout o da una diapositiva master.

Aspose.Slides espone le informazioni di segnaposto tramite il [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) metodo. Il metodo restituisce un oggetto [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) o `null` per una forma normale. Usa [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) per determinare cosa il segnaposto è destinato a contenere.

L’interfaccia della forma è comunque importante dopo aver conosciuto il tipo di segnaposto:

- Un segnaposto vuoto di testo, immagine, grafico o contenuto è tipicamente rappresentato da un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
- Un segnaposto immagine popolato può essere rappresentato da un [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/).
- Un segnaposto grafico popolato può essere rappresentato da un [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/).
- Un segnaposto di contenuto può contenere diversi tipi di contenuto. Controlla sia [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) sia l’interfaccia della forma a runtime invece di presumere che ogni segnaposto sia un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) descrive il ruolo di un segnaposto; non garantisce il tipo di forma a runtime. Usa sempre un controllo di tipo prima di accedere a membri specifici di testo, immagine, grafico, tabella o media.
{{% /alert %}}

## **Comprendere l'eredità dei segnaposto**

I segnaposto formano una gerarchia:

1. Una diapositiva master definisce stili riutilizzabili e, in alcuni casi, segnaposto a livello master.
2. Una diapositiva di layout definisce la disposizione usata da una o più diapositive normali e può ereditare dal master.
3. Una diapositiva normale contiene i segnaposto per quella diapositiva e può ereditare dal suo layout.

Chiama [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) per spostarti di un livello verso l’alto in questa gerarchia. Un segnaposto di diapositiva normalmente restituisce il suo segnaposto di layout; un segnaposto di layout può restituire il suo segnaposto master. Il metodo restituisce `null` quando la forma non ha un segnaposto di base.

L’esempio seguente elenca i segnaposto sulla prima diapositiva e riporta i loro segnaposto di base:

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

Modificare un segnaposto su una diapositiva normale crea o modifica una sovrascrittura locale per quella diapositiva. Modificare il layout o il master correlato può influenzare tutte le diapositive che ereditano ancora quell’impostazione. Una forma ordinaria locale non ha un segnaposto di base e non inizia a ereditare semplicemente perché occupa le stesse coordinate.

## **Rimuovere lo Stato del Segnaposto**

Quando si adatta un modello, usa [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--) per mantenere un oggetto esistente come forma ordinaria. Il suo metodo [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--) restituisce `null`, ma la forma rimane nella collezione della diapositiva. Al contrario, [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) elimina la forma da quella collezione.

L’esempio seguente richiede `template.pptx` con almeno una diapositiva e un segnaposto di testo non vuoto sulla prima diapositiva. Usa un segnaposto con formattazione ereditata dal suo layout o master per vedere l’effetto della rimozione di quella relazione. L’esempio verifica che la stessa forma rimanga, chiama di nuovo il metodo sulla forma ora ordinaria e salva il risultato.

{{% alert color="warning" title="Warning" %}}
Rimuovere lo stato di segnaposto non preserva automaticamente le impostazioni di aspetto ereditate. L’esempio sotto lascia deliberatamente queste impostazioni invariate, quindi l’output potrebbe apparire differente. Una forma la cui posizione e dimensione sono interamente ereditate può avere coordinate e dimensioni zero dopo la chiamata e diventare invisibile anche se rimane nella collezione.
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null ||
            textFrame == null ||
            textFrame.getText() == null ||
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // Chiamare il metodo su una forma normale non ha alcun effetto.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Per un segnaposto corrispondente, tutti e tre i controlli stampano `true`. Il testo rimane, ma posizione, dimensione, rotazione, carattere, allineamento del paragrafo, margini del riquadro di testo, ancoraggio verticale, riempimento e impostazioni di linea ereditate possono cambiare quando la relazione di segnaposto viene rimossa. Per esempio, la formattazione del titolo ereditata può tornare alla formattazione di testo ordinario. Vedi [Slide Layout](/slides/it/androidjava/slide-layout/) per ulteriori informazioni sui layout.

Per preservare l’aspetto desiderato, cattura posizione, dimensione e rotazione risolte prima della chiamata e copia i valori di formattazione efficace richiesti in variabili separate. Recupera questi valori tramite [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--), [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--), [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--), [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--), e [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--). Non fare affidamento solo sugli oggetti di formattazione efficace, poiché i loro valori di formattazione del testo possono cambiare dopo la rimozione della relazione. Applica esplicitamente i valori catturati alla forma ordinaria successivamente, includendo famiglia, dimensione, stile, colore del carattere, impostazioni del paragrafo, impostazioni del riquadro di testo, riempimento e linea usati dal tuo modello.

La geometria della forma ereditata potrebbe dover essere assegnata esplicitamente tramite [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-). Per un segnaposto di testo rettangolare, ciò significa assegnare [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle); il ripristino solo del riempimento e della linea potrebbe non ripristinare il rettangolo visibile. I modelli con effetti aggiuntivi o formattazioni più complesse richiedono la gestione di tali impostazioni.

## **Modificare il Testo in un Segnaposto**

Titolo, titolo centrato, sottotitolo, corpo e segnaposto di testo supportano normalmente il testo. Controlla la presenza di un [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) prima di usare il suo metodo [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).

Questo esempio aggiorna il primo segnaposto di titolo sulla prima diapositiva e salva il risultato:

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

Questo modello evita di castare segnaposto immagine, grafico, tabella o media a [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/). Identifica inoltre il segnaposto per scopo invece di fare affidamento su un indice di forma fragile.

## **Impostare il Testo di Prompt su un Layout**

Il testo di prompt è l’istruzione di design-time visualizzata in un segnaposto vuoto, ad esempio *Fai clic per aggiungere il titolo*. Imposta un testo di prompt personalizzato sul segnaposto del layout anziché tentare di raggiungerlo attraverso la collezione di forme di una diapositiva normale. Accedi al layout tramite [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) e itera sulla collezione restituita da [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/).

L’esempio seguente modifica i prompt del titolo e del sottotitolo sul layout usato dalla prima diapositiva:

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

Il testo di prompt non è contenuto normale della diapositiva. È destinato a segnaposto vuoti in applicazioni di editing come PowerPoint. Una volta che un utente o un programma fornisce contenuto reale, il prompt non viene più visualizzato. Modificare un prompt non sostituisce il testo esistente sulle diapositive che usano il layout.

## **Aggiornare un Segnaposto Immagine**

Ci sono due casi da gestire:

- Se il segnaposto immagine è già popolato e rappresentato da un [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/), sostituisci l’immagine tramite [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) e [ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/).
- Se è ancora un segnaposto vuoto, aggiungi un riquadro immagine alle coordinate del segnaposto con [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) e rimuovi il segnaposto vuoto.

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

La sostituzione creata per un segnaposto vuoto è un riquadro immagine locale, non un nuovo segnaposto, perché [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) non fornisce un setter. Mantiene la posizione riservata ma non eredita più il comportamento specifico del segnaposto. Se mantenere la relazione di segnaposto è essenziale, prepara e popola il segnaposto in PowerPoint prima, quindi aggiorna il [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) risultante con Aspose.Slides.

Per trasparenza dell’immagine, ritaglio e altri effetti specifici dell’immagine, vedi [Manage Picture Frames](/slides/it/androidjava/picture-frame/). Queste operazioni appartengono al riquadro immagine o al riempimento immagine, non ai metadati del segnaposto.

## **Lavorare con Segnaposto Grafico e di Contenuto**

Un segnaposto grafico popolato può essere rappresentato da un [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/). Questo esempio trova tale grafico sia per tipo di segnaposto sia per interfaccia a runtime, ne modifica il titolo e salva il file:

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

Un segnaposto di contenuto generale di solito ha [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/). In PowerPoint funge da avviatore per diversi tipi di contenuto, inclusi grafici, tabelle, diagrammi, immagini e media. Dopo che è stato popolato, ispeziona l’interfaccia della forma reale per capire cosa contiene. Layout specializzati possono anche esporre [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), [PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/), o [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/).

Aspose.Slides non converte un segnaposto [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) vuoto in un [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) cambiando semplicemente [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/); il tipo non può essere modificato tramite l’interfaccia. Per riempire programmaticamente un’area grafico o di contenuto vuota, aggiungi l’oggetto richiesto alle coordinate del segnaposto e poi rimuovi il segnaposto vuoto. L’esempio seguente lo fa per un grafico:

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

Il grafico aggiunto è un grafico locale ordinario. Occupa l’area del segnaposto ma non eredita dal segnaposto di layout. Usa gli articoli dedicati alla [gestione dei grafici](/slides/it/androidjava/powerpoint-charts/) quando devi sostituire categorie, serie o dati del workbook.

## **Esempio Completo: Aggiornare Testo o Contenuto Immagine**

L’esempio end‑to‑end seguente apre un modello, ricerca nella prima diapositiva un segnaposto titolo o immagine, controlla i tipi di segnaposto e di forma, aggiorna il contenuto appropriato e salva il risultato. L’esempio evita deliberatamente di presumere un indice di forma o di castare ogni segnaposto alla stessa interfaccia.

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

**Che cos'è un segnaposto di base?**

Un segnaposto di base è la forma corrispondente sul layout o master da cui un altro segnaposto eredita. Usa [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) per recuperarlo. Una forma locale ordinaria restituisce `null` perché non fa parte della gerarchia dei segnaposto.

**Posso modificare tutti i titoli delle diapositive modificando un segnaposto di layout?**

Puoi modificare la formattazione ereditata o il testo di prompt tramite un layout, ma il contenuto del titolo esistente è memorizzato sulle diapositive normali. Per sostituire il titolo reale in tutta la presentazione, itera sulle diapositive e aggiorna ciascun segnaposto titolo.

**Come gestisco i segnaposto data, numero diapositiva, intestazione e piè di pagina?**

Usa i gestori di intestazione e piè di pagina allo scope appropriato (diapositiva, layout, master, note o handout). Vedi [Manage Presentation Header and Footer](/slides/it/androidjava/presentation-header-and-footer/) per esempi completi.