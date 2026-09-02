---
title: Applicare o modificare i layout delle diapositive in JavaScript
linktitle: Layout della diapositiva
type: docs
weight: 60
url: /it/nodejs-java/slide-layout/
keywords:
- layout della diapositiva
- layout di contenuto
- segnaposto
- design della presentazione
- design della diapositiva
- layout non utilizzato
- visibilità del piè di pagina
- diapositiva titolo
- titolo e contenuto
- intestazione di sezione
- due contenuti
- confronto
- solo titolo
- layout vuoto
- contenuto con didascalia
- immagine con didascalia
- titolo e testo verticale
- titolo verticale e testo
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Applica, crea e modifica i layout delle diapositive in Aspose.Slides per Node.js tramite Java, aggiungi segnaposto, rimuovi i layout non utilizzati e controlla la visibilità del piè di pagina."
---
## **Panoramica**

Un layout di diapositiva definisce le posizioni e la formattazione dei segnaposto come titoli, testo, immagini, grafici e tabelle. Applicare un layout fornisce alle diapositive una struttura coerente consentendo a ciascuna diapositiva di contenere il proprio contenuto.

I layout più comuni includono:

- **Titolo diapositiva**: Contiene segnaposto per titolo e sottotitolo.
- **Titolo e contenuto**: Contiene un segnaposto per il titolo e un segnaposto di contenuto generico.
- **Vuoto**: Non contiene segnaposto di contenuto ed è utile quando ogni forma sarà posizionata manualmente.

## **Comprendere l'ereditarietà del layout**

Una presentazione ha tre livelli correlati:

1. Una [diapositiva master](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/) definisce il tema, la formattazione condivisa, gli sfondi e gli oggetti comuni.
2. Una [diapositiva di layout](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/) appartiene a una master e definisce una disposizione particolare di segnaposto.
3. Una [diapositiva normale](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/) utilizza un layout e memorizza il contenuto inserito per quella diapositiva.

Una diapositiva normale eredita il tema e la formattazione dal suo layout, e il layout eredita dalla sua master. Un valore impostato direttamente su una diapositiva normale sovrascrive il valore ereditato a quel livello. Quando una diapositiva normale viene creata, le forme dei segnaposto sono generate dal layout selezionato, mentre il contenuto inserito in quei segnaposto appartiene alla diapositiva normale.

Aggiungere i segnaposto richiesti a un layout prima di creare le diapositive da esso. Aggiungere un altro segnaposto a un layout in seguito non aggiunge automaticamente una forma segnaposto corrispondente alle diapositive normali esistenti.

Questa relazione ha due importanti conseguenze:

- Modificare la formattazione ereditata o la geometria dei segnaposto esistenti su un layout può aggiornare tutte le diapositive che dipendono da esso. Prima di modificare un layout già in uso, ispeziona le diapositive dipendenti e rivedi la presentazione risultante.
- Un layout ancora utilizzato da una diapositiva non può essere rimosso. Riassegna prima le sue diapositive dipendenti a un altro layout, oppure rimuovi solo i layout non usati.

Per maggiori informazioni sul livello superiore di questa gerarchia, vedi [Master diapositiva](/slides/it/nodejs-java/slide-master/).

## **Selezionare e applicare un layout di diapositiva**

Usa un valore [SlideLayoutType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidelayouttype/) quando la presentazione segue le definizioni di layout standard di PowerPoint. I nomi dei layout sono modificabili dall'utente e possono essere localizzati, quindi la selezione basata sul nome è meno affidabile a meno che non si controlli il modello di origine.

L'esempio seguente ricerca **Titolo e contenuto** nel primo master. Se quel layout non è disponibile, ricade deliberatamente su **Vuoto**. Il secondo controllo null è necessario perché una presentazione può contenere solo layout personalizzati. Il layout selezionato viene quindi applicato alla prima diapositiva normale tramite il metodo [Slide.setLayoutSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#setLayoutSlide).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Modificare il layout di una diapositiva non rimuove le forme ordinarie aggiunte direttamente alla diapositiva. Tuttavia, le posizioni dei segnaposto, la formattazione ereditata e la corrispondenza tra i segnaposto esistenti e il nuovo layout possono cambiare, quindi ispeziona l'output quando passi da layout sostanzialmente diversi.

## **Aggiungere una diapositiva di layout**

La selezione e la creazione sono operazioni separate. L'esempio precedente seleziona un layout esistente; non ne crea uno. Per creare un layout, chiama il metodo [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) sulla collezione di layout del master di destinazione.

L'esempio seguente aggiunge sempre un nuovo layout **Titolo e contenuto** denominato `Report Title and Content`, quindi aggiunge una diapositiva normale basata su di esso. I nomi dei layout devono essere unici nella collezione.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aggiungi un layout solo quando il modello necessita realmente di un'altra struttura riutilizzabile. Se esiste già un layout adatto, selezionalo e riutilizzalo invece di crearne un duplicato.

## **Aggiungere segnaposto a una diapositiva di layout**

Il metodo [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) fornisce un [LayoutPlaceholderManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/) per aggiungere forme segnaposto a un layout.

| Segnaposto PowerPoint              | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![Contenuto](content.png)           | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Contenuto (Verticale)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Testo](text.png)                 | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Testo (Verticale)](textV.png)    | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Immagine](picture.png)           | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Grafico](chart.png)              | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabella](table.png)              | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)          | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Immagine online](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

L'esempio seguente verifica che il layout **Vuoto** esista, aggiunge quattro segnaposto a esso e quindi crea una diapositiva normale che utilizza il layout modificato. L'ordine è intenzionale: i segnaposto vengono aggiunti prima che la diapositiva normale sia creata, così Aspose.Slides può generare le forme segnaposto corrispondenti su quella diapositiva.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![I segnaposto sulla diapositiva di layout](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modificare la formattazione ereditata o la geometria dei segnaposto di layout esistenti può influire sulle diapositive dipendenti. Un segnaposto di layout aggiunto di recente non viene retroalimentato nelle diapositive normali esistenti. Prova le modifiche al layout su una copia della presentazione e ispeziona ogni diapositiva dipendente.
{{% /alert %}}

## **Rimuovere le diapositive di layout non utilizzate**

Usa il metodo [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) per rimuovere i layout a cui nessuna diapositiva normale fa riferimento. Il metodo lascia intatti i layout ancora in uso.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Per rimuovere un layout specifico, usa prima il suo metodo [hasDependingSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) o [getDependingSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Riassegna eventuali diapositive dipendenti prima di chiamare [LayoutSlide.remove](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#remove). Tentare di rimuovere un layout in uso genera una [PptxEditException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxeditexception/).

## **Controllare la visibilità del piè di pagina su una diapositiva di layout**

Un layout ha i propri segnaposto di piè di pagina, numero diapositiva e data/ora. Usa il metodo [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) per controllare quei segnaposto per un layout. Questo è utile quando, ad esempio, i layout di contenuto devono mostrare i piè di pagina ma i layout di titolo no.

L'esempio seguente seleziona un layout in modo sicuro e rende visibili gli elementi del piè di pagina:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controllare la visibilità del piè di pagina su un master e i suoi layout figlio**

Per applicare impostazioni di piè di pagina coerenti su tutta la gerarchia di un master, usa il metodo [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). I metodi di propagazione di [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslideheaderfootermanager/) operano sul master e sui suoi layout dipendenti e sulle diapositive normali; non mirano a una sola diapositiva normale.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual è la differenza tra una diapositiva master e una diapositiva di layout?**

Una diapositiva master definisce il tema della presentazione e la formattazione condivisa. Una diapositiva di layout appartiene a un master e definisce una disposizione riutilizzabile di segnaposto. Le diapositive normali utilizzano quei layout e memorizzano contenuti specifici della diapositiva.

**Posso copiare una diapositiva di layout da una presentazione a un'altra?**

Sì. Aggiungi una copia alla collezione di destinazione con il metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Quando copi tra presentazioni, verifica anche i font, i temi, le immagini e le altre risorse utilizzate dal layout di origine.

**Cosa succede quando modifico un layout già in uso?**

Le diapositive dipendenti ereditano le modifiche al layout a meno che non sovrascrivano localmente la formattazione o gli oggetti interessati. La geometria dei segnaposto e lo stile ereditato possono quindi cambiare su molte diapositive contemporaneamente. Usa [getDependingSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) per identificare le diapositive interessate prima di modificare il layout.

**Cosa succede se rimuovo un layout ancora in uso?**

Aspose.Slides genera una [PptxEditException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxeditexception/). Riassegna prima le diapositive dipendenti, oppure usa [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) per rimuovere solo i layout non referenziati.