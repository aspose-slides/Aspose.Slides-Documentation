---
title: Applicare o modificare i layout delle diapositive in JavaScript
linktitle: Layout diapositiva
type: docs
weight: 60
url: /it/nodejs-java/slide-layout/
keywords:
- layout diapositiva
- layout contenuto
- segnaposto
- progettazione presentazione
- progettazione diapositiva
- layout inutilizzato
- visibilità del piè di pagina
- diapositiva titolo
- titolo e contenuto
- intestazione sezione
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
description: "Applica, crea e modifica i layout delle diapositive in Aspose.Slides per Node.js tramite Java, aggiungi segnaposto, rimuovi layout inutilizzati e controlla la visibilità del piè di pagina."
---
## **Panoramica**

Un layout diapositive definisce le posizioni e la formattazione dei segnaposto come titoli, testo, immagini, grafici e tabelle. Applicare un layout conferisce alle diapositive una struttura coerente, consentendo a ciascuna diapositiva di contenere il proprio contenuto.

I layout più comuni includono:

- **Title Slide**: contiene segnaposto per titolo e sottotitolo.  
- **Title and Content**: contiene un segnaposto per il titolo e un segnaposto di contenuto di uso generale.  
- **Blank**: non contiene segnaposto di contenuto ed è utile quando ogni forma sarà posizionata manualmente.

## **Comprendere l’Ereditarietà dei Layout**

Una presentazione ha tre livelli correlati:

1. Un [master slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/) definisce il tema, la formattazione condivisa, gli sfondi e gli oggetti comuni.  
1. Un [layout slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/) appartiene a un master e definisce una particolare disposizione di segnaposto.  
1. Un [normal slide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/) utilizza un layout e memorizza il contenuto inserito per quella diapositiva.

Una diapositiva normale eredita tema e formattazione dal suo layout, e il layout eredita dal suo master. Un valore impostato direttamente su una diapositiva normale sovrascrive il valore ereditato a quel livello. Quando viene creata una diapositiva normale, le forme dei segnaposto vengono generate dal layout selezionato, mentre il contenuto inserito in quei segnaposto appartiene alla diapositiva normale.

Aggiungi i segnaposto richiesti a un layout prima di creare diapositive da esso. L’aggiunta successiva di un nuovo segnaposto a un layout non aggiunge automaticamente la corrispondente forma di segnaposto alle diapositive normali esistenti.

Questa relazione ha due importanti conseguenze:

- Modificare la formattazione ereditata o la geometria di un segnaposto esistente su un layout può aggiornare tutte le diapositive che dipendono da esso. Prima di modificare un layout già in uso, controlla le diapositive dipendenti e verifica la presentazione risultante.  
- Un layout che è ancora utilizzato da una diapositiva non può essere rimosso. Riassegna prima le diapositive dipendenti a un altro layout, oppure rimuovi solo i layout inutilizzati.

Per ulteriori informazioni sul livello superiore di questa gerarchia, consulta [Slide Master](/slides/it/nodejs-java/slide-master/).

Per nascondere loghi ereditati o forme decorative del master su una singola diapositiva o tramite un layout condiviso, vedi [Control the Visibility of Master Graphics](/slides/it/nodejs-java/slide-master/). L’esempio confronta due diapositive che usano lo stesso master.

## **Selezionare e Applicare un Layout di Diapositiva**

Usa un valore di [SlideLayoutType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slidelayouttype/) quando la presentazione segue le definizioni di layout standard di PowerPoint. I nomi dei layout sono modificabili dall’utente e possono essere localizzati, quindi la selezione basata sul nome è meno affidabile a meno che non si controlli il modello sorgente.

L’esempio seguente cerca **Title and Content** sul primo master. Se quel layout non è disponibile, ricade deliberatamente su **Blank**. Il secondo controllo null è necessario perché una presentazione può contenere solo layout personalizzati. Il layout selezionato viene quindi applicato alla prima diapositiva normale tramite il metodo [Slide.setLayoutSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/slide/#setLayoutSlide).

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

Modificare il layout di una diapositiva non rimuove le forme ordinarie aggiunte direttamente alla diapositiva. Tuttavia, le posizioni dei segnaposto, la formattazione ereditata e la corrispondenza tra i segnaposto esistenti e il nuovo layout possono cambiare, quindi esamina l’output quando si passa tra layout sostanzialmente diversi.

## **Aggiungere un Layout Slide**

Selezione e creazione sono operazioni separate. L’esempio precedente seleziona un layout esistente; non ne crea uno. Per creare un layout, chiama il metodo [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) sulla collezione di layout del master di destinazione.

L’esempio seguente aggiunge sempre un nuovo layout **Title and Content** denominato `Report Title and Content`, quindi aggiunge una diapositiva normale basata su di esso. I nomi dei layout devono essere unici all’interno della collezione.

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

Aggiungi un layout solo quando il modello necessita realmente di un’altra struttura riutilizzabile. Se esiste già un layout adatto, selezionalo e riutilizzalo invece di crearne un duplicato.

## **Aggiungere Segnaposto a un Layout Slide**

Il metodo [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) fornisce un [LayoutPlaceholderManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/) per aggiungere forme di segnaposto a un layout.

| Segnaposto PowerPoint              | Metodo `LayoutPlaceholderManager` |
| ----------------------------------- | --------------------------------- |
| ![Content](content.png)             | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Text](text.png)                   | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Text (Vertical)](textV.png)       | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Picture](picture.png)             | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Chart](chart.png)                 | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Table](table.png)                 | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                 | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Online Image](onlineImage.png)    | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

L’esempio seguente verifica che il layout **Blank** esista, aggiunge quattro segnaposto e poi crea una diapositiva normale che utilizza il layout modificato. L’ordine è intenzionale: i segnaposto vengono aggiunti prima della creazione della diapositiva normale, così Aspose.Slides può generare le forme di segnaposto corrispondenti su quella diapositiva.

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modificare la formattazione ereditata o la geometria dei segnaposto di un layout esistente può influire sulle diapositive dipendenti. Un segnaposto di layout appena aggiunto non viene retroattivamente inserito nelle diapositive normali esistenti. Verifica le modifiche al layout su una copia della presentazione e controlla ogni diapositiva dipendente.
{{% /alert %}}

## **Rimuovere Layout Slide Inutilizzati**

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

Per rimuovere un layout specifico, utilizza prima il suo metodo [hasDependingSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) o [getDependingSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Riassegna eventuali diapositive dipendenti prima di chiamare [LayoutSlide.remove](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#remove). Tentare di rimuovere un layout in uso genera una [PptxEditException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxeditexception/).

## **Controllare la Visibilità del Footer su un Layout Slide**

Un layout ha i propri segnaposto per footer, numero diapositiva e data/ora. Usa il metodo [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) per controllare quei segnaposto su un singolo layout. Questo è utile, ad esempio, quando i layout di contenuto devono mostrare i footer ma i layout di titolo no.

L’esempio seguente seleziona in modo sicuro un layout e rende visibili gli elementi del footer:

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

## **Controllare la Visibilità del Footer su un Master e sui Suoi Layout Figlio**

Per applicare impostazioni del footer coerenti lungo l’intera gerarchia del master, usa il metodo [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). I metodi di propagazione di [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterslideheaderfootermanager/) operano sul master e sui suoi layout dipendenti e sulle diapositive normali; non si rivolgono a una singola diapositiva normale.

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

**Qual è la differenza tra un Master Slide e un Layout Slide?**

Un master slide definisce il tema della presentazione e la formattazione condivisa. Un layout slide appartiene a un master e definisce una disposizione riutilizzabile di segnaposto. Le diapositive normali usano quei layout e memorizzano il contenuto specifico della diapositiva.

**Posso copiare un Layout Slide da una presentazione a un’altra?**

Sì. Aggiungi una copia alla collezione di destinazione con il metodo [addClone](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Quando copi tra presentazioni, verifica anche caratteri, temi, immagini e altre risorse usate dal layout di origine.

**Cosa succede se modifico un layout già in uso?**

Le diapositive dipendenti ereditano le modifiche al layout, a meno che non sovrascrivano localmente la formattazione o gli oggetti interessati. La geometria dei segnaposto e lo stile ereditato possono quindi cambiare su molte diapositive contemporaneamente. Usa [getDependingSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) per identificare le diapositive interessate prima di modificare il layout.

**Cosa accade se rimuovo un layout ancora in uso?**

Aspose.Slides genera una [PptxEditException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxeditexception/). Riassegna prima le diapositive dipendenti, oppure usa [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) per rimuovere solo i layout non referenziati.