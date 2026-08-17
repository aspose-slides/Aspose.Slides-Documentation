---
title: Gestire i segnaposti della presentazione in JavaScript
linktitle: Gestire i segnaposti
type: docs
weight: 10
url: /it/nodejs-java/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto grafico
- segnaposto di contenuto
- testo di prompt
- PowerPoint
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Scopri come ispezionare e modificare i segnaposti di testo, immagine, grafico e contenuto e comprendere l'eredità dei segnaposti con Aspose.Slides per Node.js tramite Java."
---
## **Panoramica**

Un segnaposto è una forma che riserva una posizione per un tipo particolare di contenuto in un modello di presentazione. Esempi comuni sono i segnaposti per titolo, corpo, immagine, grafico e contenuto generico. A differenza di una forma ordinaria, un segnaposto può ereditare la sua posizione, dimensione, formattazione e altre impostazioni da una diapositiva layout o da una diapositiva master.

Aspose.Slides espone le informazioni sui segnaposti tramite il metodo [Shape.getPlaceholder](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getPlaceholder). Il metodo restituisce un oggetto [Placeholder](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/placeholder/) o `null` per una forma normale. Usa [Placeholder.getType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/placeholder/#getType) per determinare cosa il segnaposto è destinato a contenere.

La classe della forma è ancora importante dopo aver conosciuto il tipo di segnaposto:

- Un segnaposto di testo, immagine, grafico o contenuto vuoto è comunemente rappresentato da un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/).
- Un segnaposto immagine popolato può essere rappresentato da un [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/).
- Un segnaposto grafico popolato può essere rappresentato da un [Chart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/).
- Un segnaposto di contenuto può contenere diversi tipi di contenuto. Controlla sia [Placeholder.getType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/placeholder/#getType) sia la classe della forma a tempo di esecuzione invece di presumere che ogni segnaposto sia un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/placeholder/#getType) descrive il ruolo di un segnaposto; non garantisce il tipo di forma a tempo di esecuzione. Usa sempre un controllo di tipo prima di accedere a membri specifici di testo, immagine, grafico, tabella o media.
{{% /alert %}}

## **Comprendere l'Eredità dei Segnaposti**

I segnaposti formano una gerarchia:

1. Una diapositiva master definisce stili riutilizzabili e, in alcuni casi, segnaposti a livello master.
2. Una diapositiva layout definisce la disposizione usata da una o più diapositive normali e può ereditare dal master.
3. Una diapositiva normale contiene i segnaposti per quella diapositiva e può ereditare dal suo layout.

Chiama [Shape.getBasePlaceholder](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getBasePlaceholder) per spostarti di un livello verso l'alto in questa gerarchia. Un segnaposto di diapositiva normalmente restituisce il suo segnaposto di layout; un segnaposto di layout può restituire il suo segnaposto master. Il metodo restituisce `null` quando la forma non ha un segnaposto base.

L'esempio seguente elenca i segnaposti sulla prima diapositiva e riporta i loro segnaposti base:

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

Modificare un segnaposto su una diapositiva normale crea o cambia una sovrascrittura locale per quella diapositiva. Modificare il layout o il master correlato può influenzare tutte le diapositive che ereditano ancora quell'impostazione. Una forma locale ordinaria non ha un segnaposto base e non inizia a ereditare solo perché occupa le stesse coordinate.

## **Modificare il Testo in un Segnaposto**

I segnaposti di titolo, titolo centrato, sottotitolo, corpo e testo normalmente supportano il testo. Verifica che sia un [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) prima di usare il suo metodo [getTextFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/#getTextFrame).

Questo esempio aggiorna il primo segnaposto di titolo sulla prima diapositiva e salva il risultato:

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

Questo modello evita di trattare segnaposti di immagine, grafico, tabella o media come oggetti [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/). Identifica inoltre il segnaposto per scopo invece di fare affidamento su un indice di forma fragile.

## **Impostare il Testo di Prompt su un Layout**

Il testo di prompt è l'istruzione di progettazione visualizzata in un segnaposto vuoto, ad esempio *Fai clic per aggiungere il titolo*. Imposta un testo di prompt personalizzato sul segnaposto del layout anziché cercare di raggiungerlo tramite la raccolta di forme di una diapositiva normale. Accedi al layout tramite [Slide.getLayoutSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#getLayoutSlide) e itera sulla raccolta restituita da [BaseSlide.getShapes](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/baseslide/#getShapes).

L'esempio seguente modifica i prompt di titolo e sottotitolo sul layout usato dalla prima diapositiva:

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

Il testo di prompt non è contenuto normale della diapositiva. È destinato ai segnaposti vuoti nelle applicazioni di modifica come PowerPoint. Una volta che un utente o un programma fornisce contenuto reale, il prompt non viene più visualizzato. Modificare un prompt non sostituisce nemmeno il testo esistente sulle diapositive che usano quel layout.

## **Aggiornare un Segnaposto Immagine**

Ci sono due casi da gestire:

- Se il segnaposto immagine è già popolato e rappresentato da un [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/), sostituisci l'immagine tramite [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picturefillformat/#getPicture) e [Picture.setImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/picture/#setImage).
- Se è ancora un segnaposto vuoto, aggiungi un frame immagine alle coordinate del segnaposto con [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) e rimuovi il segnaposto vuoto.

L'esempio successivo supporta entrambi i casi e salva la presentazione:

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

La sostituzione creata per un segnaposto vuoto è un frame immagine locale, non un nuovo segnaposto, perché [Shape.getPlaceholder](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getPlaceholder) non fornisce un setter. Mantiene la posizione riservata ma non eredita più il comportamento specifico del segnaposto. Se è essenziale mantenere la relazione del segnaposto, prepara e popola il segnaposto in PowerPoint prima, quindi aggiorna il [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/) risultante con Aspose.Slides.

Per la trasparenza dell'immagine, il ritaglio e altri effetti specifici dell'immagine, consulta [Manage Picture Frames](/slides/it/nodejs-java/picture-frame/). Quelle operazioni appartengono al frame immagine o al riempimento immagine, non ai metadati del segnaposto.

## **Lavorare con Segnaposti Grafico e Contenuto**

Un segnaposto grafico popolato può essere rappresentato da un [Chart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/). Questo esempio trova tale grafico sia per tipo di segnaposto sia per classe a tempo di esecuzione, ne modifica il titolo e salva il file:

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

Un segnaposto di contenuto generale di solito ha [PlaceholderType.Object](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/placeholdertype/#Object). In PowerPoint funge da avviatore per diversi tipi di contenuto, inclusi grafici, tabelle, diagrammi, immagini e media. Dopo che è stato popolato, ispeziona la classe reale della forma per scoprire cosa contiene. Layout specializzati possono anche esporre [PlaceholderType.Chart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/placeholdertype/#Media) o [PlaceholderType.Diagram](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides non converte un segnaposto vuoto [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) in un [Chart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/) semplicemente modificando [Placeholder.getType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/placeholder/#getType); il tipo non può essere modificato tramite l'oggetto. Per riempire programmaticamente un'area di grafico o contenuto vuota, aggiungi l'oggetto richiesto alle coordinate del segnaposto e poi rimuovi il segnaposto vuoto. L'esempio seguente lo fa per un grafico:

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

Il grafico aggiunto è un grafico locale ordinario. Occupa l'area del segnaposto ma non eredita dal segnaposto del layout. Usa gli articoli dedicati alla gestione dei grafici [chart management articles](/slides/it/nodejs-java/powerpoint-charts/) quando devi sostituire le categorie, le serie o i dati della cartella di lavoro.

## **Esempio Completo: Aggiornare Testo o Contenuto Immagine**

L'esempio end-to-end seguente apre un modello, cerca nella prima diapositiva un segnaposto titolo o immagine, controlla i tipi di segnaposto e di forma, aggiorna il contenuto appropriato e salva il risultato. L'esempio evita deliberatamente di presumere un indice di forma o di trattare ogni segnaposto come la stessa classe.

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

Un segnaposto base è la forma corrispondente sul layout o sul master da cui un altro segnaposto eredita. Usa [Shape.getBasePlaceholder](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/#getBasePlaceholder) per recuperarlo. Una forma locale ordinaria restituisce `null` perché non fa parte della gerarchia dei segnaposti.

**Posso modificare tutti i titoli delle diapositive modificando un segnaposto layout?**

Puoi modificare la formattazione ereditata o il testo di prompt tramite un layout, ma il contenuto del titolo esistente è memorizzato sulle diapositive normali. Per sostituire il testo del titolo in tutta la presentazione, itera sulle diapositive e aggiorna ciascun segnaposto titolo.

**Come gestisco i segnaposti data, numero diapositiva, intestazione e piè di pagina?**

Usa i gestori di intestazione e piè di pagina nello scope appropriato di diapositiva, layout, master, note o opuscolo. Vedi [Manage Presentation Header and Footer](/slides/it/nodejs-java/presentation-header-and-footer/) per esempi completi.