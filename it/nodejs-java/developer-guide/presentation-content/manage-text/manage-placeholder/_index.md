---
title: Gestire i segnaposti della presentazione in JavaScript
linktitle: Gestire i segnaposti
type: docs
weight: 10
url: /it/nodejs-java/manage-placeholder/
keywords:
- segnaposto
- segnaposto testo
- segnaposto immagine
- segnaposto grafico
- segnaposto contenuto
- testo di suggerimento
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come ispezionare e modificare i segnaposti di testo, immagine, grafico e contenuto e comprendere l'eredità dei segnaposti con Aspose.Slides per Node.js tramite Java."
---
## **Panoramica**

Un segnaposto è una forma che riserva una posizione per un particolare tipo di contenuto in un modello di presentazione. Esempi comuni sono segnaposti titolo, corpo, immagine, grafico e segnaposti contenuto a scopo generico. A differenza di una forma ordinaria, un segnaposto può ereditare la sua posizione, dimensione, formattazione e altre impostazioni da una diapositiva di layout o da una diapositiva master.

Aspose.Slides espone le informazioni sul segnaposto tramite il metodo [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder). Il metodo restituisce un oggetto [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) o `null` per una forma normale. Usa [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) per determinare cosa il segnaposto è destinato a contenere.

La classe della forma è comunque importante dopo aver conosciuto il tipo di segnaposto:

- Un segnaposto vuoto di testo, immagine, grafico o contenuto è solitamente rappresentato da un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
- Un segnaposto immagine popolato può essere rappresentato da un [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).
- Un segnaposto grafico popolato può essere rappresentato da un [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/).
- Un segnaposto contenuto può contenere diversi tipi di contenuto. Controlla sia [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) sia la classe della forma a runtime invece di presumere che ogni segnaposto sia un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) descrive il ruolo di un segnaposto; non garantisce il tipo di forma a runtime. Usa sempre un controllo di tipo prima di accedere a membri specifici di testo, immagine, grafico, tabella o media.
{{% /alert %}}

## **Comprendere l'eredità dei segnaposti**

I segnaposti formano una gerarchia:

1. Una diapositiva master definisce stili riutilizzabili e, in alcuni casi, segnaposti a livello master.
2. Una diapositiva di layout definisce la disposizione utilizzata da una o più diapositive normali e può ereditare dal master.
3. Una diapositiva normale contiene i segnaposti per quella diapositiva e può ereditare dal suo layout.

Chiama [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) per spostarti di un livello verso l'alto in questa gerarchia. Un segnaposto diapositiva restituisce normalmente il suo segnaposto layout; un segnaposto layout può restituire il suo segnaposto master. Il metodo restituisce `null` quando la forma non ha un segnaposto base.

L'esempio seguente elenca i segnaposti nella prima diapositiva e segnala i loro segnaposti base:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Modificare un segnaposto su una diapositiva normale crea o modifica una sovrascrittura locale per quella diapositiva. Modificare il layout o il master correlato può influenzare tutte le diapositive che continuano a ereditare quell'impostazione. Una forma ordinaria locale non ha un segnaposto base e non inizia a ereditare solo perché occupa le stesse coordinate.

## **Rimuovere lo stato di segnaposto**

Quando si adatta un modello, usa [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder) per mantenere un oggetto esistente come forma ordinaria. Il suo metodo [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) restituisce `null`, ma la forma rimane nella collezione della diapositiva. In confronto, [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) elimina la forma da quella collezione.

L'esempio seguente richiede `template.pptx` con almeno una diapositiva e un segnaposto testo non vuoto sulla prima diapositiva. Usa un segnaposto con formattazione ereditata dal suo layout o master per vedere l'effetto della rimozione di quella relazione. L'esempio verifica che la stessa forma rimanga, richiama nuovamente il metodo sulla forma ora ordinaria e salva il risultato.

{{% alert color="warning" title="Warning" %}}
Rimuovere lo stato di segnaposto non preserva automaticamente le impostazioni di apparenza ereditate. L'esempio sotto lascia deliberatamente tali impostazioni invariate, quindi l'output potrebbe apparire diverso. Una forma la cui posizione e dimensione sono interamente ereditate può avere coordinate e dimensioni zero dopo la chiamata e diventare invisibile pur rimanendo nella collezione.
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // Chiamare il metodo su una forma ordinaria non ha alcun effetto.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

Per un segnaposto corrispondente, tutti e tre i controlli stampano `true`. Il testo rimane, ma posizione, dimensione, rotazione, carattere, allineamento del paragrafo, margini del riquadro di testo, ancoraggio verticale, riempimento e impostazioni di linea ereditate possono cambiare quando la relazione del segnaposto viene rimossa. Per esempio, la formattazione del titolo ereditata può tornare alla formattazione testo ordinaria. Vedi [Slide Layout](/slides/it/nodejs-java/slide-layout/) per ulteriori dettagli sui layout.

Per preservare l'aspetto previsto, cattura posizione, dimensione e rotazione risolte prima della chiamata e copia i valori di formattazione effettiva richiesti in variabili separate. Recupera tali valori tramite [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective) e [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective). Non fare affidamento solo sugli oggetti di formattazione effettiva, poiché i loro valori di formattazione del testo possono cambiare dopo la rimozione della relazione. Applica esplicitamente i valori catturati alla forma ordinaria successivamente, includendo famiglia, dimensione, stile, colore del carattere, impostazioni del paragrafo, impostazioni del riquadro di testo, riempimento e linea usati dal modello.

Anche la geometria della forma ereditata potrebbe dover essere assegnata esplicitamente tramite [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType). Per un segnaposto testo rettangolare, ciò significa assegnare [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle); il ripristino solo del riempimento e della linea potrebbe non ripristinare il rettangolo visibile. I modelli con effetti aggiuntivi o formattazioni più complesse richiedono la gestione di tali impostazioni.

## **Modificare il testo in un segnaposto**

I segnaposti titolo, titolo centrato, sottotitolo, corpo e testo supportano normalmente il testo. Verifica la presenza di un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) prima di usare il suo metodo [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame).

Questo esempio aggiorna il primo segnaposto titolo nella prima diapositiva e salva il risultato:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Questo schema evita di trattare segnaposti immagine, grafico, tabella o media come oggetti [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/). Identifica inoltre il segnaposto per scopo invece di basarsi su un indice di forma fragile.

## **Impostare il testo di suggerimento su un layout**

Il testo di suggerimento è l'istruzione di progetto visualizzata in un segnaposto vuoto, ad esempio *Fare clic per aggiungere titolo*. Imposta un testo di suggerimento personalizzato sul segnaposto di layout piuttosto che tentare di raggiungerlo tramite la collezione forme di una diapositiva normale. Accedi al layout tramite [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) e itera sulla collezione restituita da [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes).

L'esempio seguente modifica i suggerimenti titolo e sottotitolo sul layout usato dalla prima diapositiva:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il testo di suggerimento non è contenuto normale della diapositiva. È destinato ai segnaposti vuoti nelle applicazioni di editing come PowerPoint. Una volta che un utente o un programma fornisce contenuto reale, il suggerimento non è più visualizzato. Cambiare un suggerimento non sostituisce nemmeno il testo esistente sulle diapositive che usano il layout.

## **Aggiornare un segnaposto immagine**

Ci sono due casi da gestire:

- Se il segnaposto immagine è già popolato e rappresentato da un [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), sostituisci l'immagine tramite [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture) e [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage).
- Se è ancora un segnaposto vuoto, aggiungi un riquadro immagine alle coordinate del segnaposto con [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) e rimuovi il segnaposto vuoto.

Il prossimo esempio supporta entrambi i casi e salva la presentazione:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La sostituzione creata per un segnaposto vuoto è un riquadro immagine locale, non un nuovo segnaposto, perché [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) non fornisce un setter. Mantiene la posizione riservata ma non eredita più il comportamento specifico del segnaposto. Se mantenere la relazione del segnaposto è fondamentale, prepara e popola il segnaposto in PowerPoint prima, quindi aggiorna il [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) risultante con Aspose.Slides.

Per trasparenza dell'immagine, ritaglio e altri effetti specifici dell'immagine, vedi [Manage Picture Frames](/slides/it/nodejs-java/picture-frame/). quelle operazioni appartengono al riquadro immagine o al riempimento immagine, non ai metadati del segnaposto.

## **Lavorare con segnaposti grafico e contenuto**

Un segnaposto grafico popolato può essere rappresentato da un [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/). Questo esempio trova tale grafico sia per tipo di segnaposto sia per classe a runtime, ne cambia il titolo e salva il file:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Un segnaposto contenuto generico solitamente ha [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object). In PowerPoint funge da avviatore per diversi tipi di contenuto, inclusi grafici, tabelle, diagrammi, immagini e media. Dopo che è stato popolato, ispeziona la classe reale della forma per capire cosa contiene. I layout specializzati possono anche esporre [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media) o [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides non converte un segnaposto vuoto [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) in un [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) semplicemente cambiando [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType); il tipo non può essere modificato tramite l'oggetto. Per riempire programmaticamente un grafico vuoto o un'area di contenuto, aggiungi l'oggetto richiesto alle coordinate del segnaposto e poi rimuovi il segnaposto vuoto. L'esempio seguente lo fa per un grafico:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il grafico aggiunto è un grafico locale ordinario. Occupа l'area del segnaposto ma non eredita dal segnaposto di layout. Usa gli articoli dedicati alla [chart management articles](/slides/it/nodejs-java/powerpoint-charts/) quando devi sostituire le sue categorie, serie o dati della cartella di lavoro.

## **Esempio completo: aggiornare contenuto testo o immagine**

L'esempio end-to-end seguente apre un modello, cerca nella prima diapositiva un segnaposto titolo o immagine, verifica i tipi di segnaposto e di forma, aggiorna il contenuto appropriato e salva l'output. L'esempio evita deliberatamente di presumere un indice di forma o di trattare ogni segnaposto come la stessa classe.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Che cos'è un segnaposto base?**

Un segnaposto base è la forma corrispondente sul layout o sul master da cui un altro segnaposto eredita. Usa [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) per recuperarlo. Una forma locale ordinaria restituisce `null` perché non fa parte della gerarchia dei segnaposti.

**Posso cambiare tutti i titoli delle diapositive modificando un segnaposto di layout?**

Puoi modificare la formattazione ereditata o il testo di suggerimento tramite un layout, ma il contenuto del titolo esistente è memorizzato sulle diapositive normali. Per sostituire il testo reale del titolo in tutta la presentazione, itera sulle diapositive e aggiorna ciascun segnaposto titolo.

**Come gestisco i segnaposti data, numero diapositiva, intestazione e piè di pagina?**

Usa i gestori di intestazione e piè di pagina nella diapositiva, layout, master, note o foglio di stampa appropriati. Vedi [Manage Presentation Header and Footer](/slides/it/nodejs-java/presentation-header-and-footer/) per esempi completi.