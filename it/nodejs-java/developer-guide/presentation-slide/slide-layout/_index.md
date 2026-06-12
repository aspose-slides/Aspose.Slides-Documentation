---
title: "Applicare o Modificare i Layout di Diapositiva in JavaScript"
linktitle: "Layout di Diapositiva"
type: docs
weight: 60
url: /it/nodejs-java/slide-layout/
keywords:
- layout di diapositiva
- layout di contenuto
- segnaposto
- progettazione presentazione
- progettazione diapositiva
- layout inutilizzato
- visibilità piè di pagina
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
description: "Gestisci e personalizza i layout di diapositiva in Aspose.Slides per Node.js. Esplora i tipi di layout, il controllo dei segnaposto e la visibilità del piè di pagina tramite esempi di codice."
---
## **Introduzione**

Un layout di diapositiva definisce la disposizione delle caselle segnaposto e la formattazione del contenuto su una diapositiva. Controlla quali segnaposto sono disponibili e dove appaiono. I layout di diapositiva ti aiutano a progettare presentazioni rapidamente e in modo coerente—che tu stia creando qualcosa di semplice o più complesso. Alcuni dei layout di diapositiva più comuni in PowerPoint includono:

**Layout Titolo Diapositiva** – Include due segnaposto di testo: uno per il titolo e uno per il sottotitolo.

**Layout Titolo e Contenuto** – Presenta un segnaposto del titolo più piccolo in alto e uno più grande sotto per il contenuto principale (come testo, elenchi puntati, grafici, immagini e altro).

**Layout Vuoto** – Non contiene segnaposto, dandoti il pieno controllo per progettare la diapositiva da zero.

I layout di diapositiva fanno parte di un master di diapositiva, che è la diapositiva di livello superiore che definisce gli stili di layout per la presentazione. Puoi accedere e modificare i layout di diapositiva attraverso il master di diapositiva—sia per tipo, nome o ID univoco. In alternativa, puoi modificare un layout di diapositiva specifico direttamente nella presentazione.

Per lavorare con i layout di diapositiva in Aspose.Slides per Node.js, è possibile utilizzare:
- Metodi come [getLayoutSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getLayoutSlides) e [getMasters](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getMasters) nella classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/)
- Tipi come [LayoutSlide](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/), e [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Per saperne di più sul lavoro con i master di diapositiva, consulta l'articolo [Slide Master](/slides/it/nodejs-java/slide-master/).
{{% /alert %}}

## **Aggiungere Layout di Diapositiva alle Presentazioni**

Per personalizzare l'aspetto e la struttura delle tue diapositive, potresti dover aggiungere nuovi layout di diapositiva a una presentazione. Aspose.Slides per Node.js ti consente di verificare se un layout specifico esiste già, aggiungerne uno nuovo se necessario e usarlo per inserire diapositive basate su quel layout.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Accedi alla [MasterLayoutSlideCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/masterlayoutslidecollection/).
3. Verifica se il layout di diapositiva desiderato esiste già nella collezione. In caso contrario, aggiungi il layout di diapositiva necessario.
4. Aggiungi una diapositiva vuota basata sul nuovo layout di diapositiva.
5. Salva la presentazione.

Il seguente codice JavaScript dimostra come aggiungere un layout di diapositiva a una presentazione PowerPoint:

```js
// Istanzia la classe Presentation che rappresenta un file PowerPoint.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // Scorri i tipi di layout di diapositiva per selezionare un layout di diapositiva.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // Una situazione in cui la presentazione non contiene tutti i tipi di layout.
        // Il file della presentazione contiene solo i tipi di layout Vuoto e Personalizzato.
        // Tuttavia, i layout di diapositiva con tipi personalizzati possono avere nomi riconoscibili,
        // come "Title", "Title and Content", ecc., che possono essere usati per la selezione del layout di diapositiva.
        // Puoi anche fare affidamento su un insieme di tipi di forma segnaposto.
        // Ad esempio, una diapositiva Titolo dovrebbe contenere solo il tipo di segnaposto Titolo, e così via.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // Aggiungi una diapositiva vuota usando il layout di diapositiva aggiunto.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Salva la presentazione su disco.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rimuovere Layout di Diapositiva Inutilizzati**

Aspose.Slides fornisce il metodo [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) della classe [Compress](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/) per consentire di eliminare i layout di diapositiva indesiderati e non utilizzati.

Il seguente codice JavaScript mostra come rimuovere un layout di diapositiva da una presentazione PowerPoint:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aggiungere Segnaposto ai Layout di Diapositiva**

Aspose.Slides fornisce il metodo [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) che consente di aggiungere nuovi segnaposto a un layout di diapositiva.

Questo gestore contiene metodi per i seguenti tipi di segnaposto:

| Segnaposto PowerPoint | [LayoutPlaceholderManager](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/layoutplaceholdermanager/) Metodo |
| --------------------- | ------------------------------------------------------------ |
| ![Contenuto](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Contenuto (Verticale)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Testo](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Testo (Verticale)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Immagine](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Grafico](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabella](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Immagine Online](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Il seguente codice JavaScript dimostra come aggiungere nuove forme segnaposto al layout Vuoto:

```js
let presentation = new aspose.slides.Presentation();
try {
    // Ottieni la diapositiva di layout Vuoto.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // Ottieni il gestore dei segnaposto della diapositiva di layout.
    let placeholderManager = layout.getPlaceholderManager();

    // Aggiungi diversi segnaposto al layout Vuoto.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Aggiungi una nuova diapositiva con il layout Vuoto.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![I segnaposto sul layout della diapositiva](add_placeholders.png)

## **Impostare la Visibilità del Piè di Pagina per un Layout di Diapositiva**

Nelle presentazioni PowerPoint, gli elementi del piè di pagina come data, numero della diapositiva e testo personalizzato possono essere mostrati o nascosti a seconda del layout della diapositiva. Aspose.Slides per Node.js ti consente di controllare la visibilità di questi segnaposto del piè di pagina. È utile quando desideri che alcuni layout mostrino le informazioni del piè di pagina mentre altri rimangono puliti e minimalisti.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Ottieni un riferimento al layout di diapositiva per il suo indice.
3. Imposta il segnaposto del piè di pagina della diapositiva su visibile.
4. Imposta il segnaposto del numero della diapositiva su visibile.
5. Imposta il segnaposto data-ora su visibile.
6. Salva la presentazione.

Il seguente codice JavaScript mostra come impostare la visibilità del piè di pagina di una diapositiva e svolgere operazioni correlate:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Impostare la Visibilità del Piè di Pagina Figlio per una Diapositiva**

Nelle presentazioni PowerPoint, gli elementi del piè di pagina come data, numero della diapositiva e testo personalizzato possono essere controllati a livello di master slide per garantire coerenza su tutti i layout di diapositiva. Aspose.Slides per Node.js consente di impostare la visibilità e il contenuto di questi segnaposto del piè di pagina nella master slide e di propagare queste impostazioni a tutti i layout di diapositiva figlio. Questo approccio garantisce informazioni uniformi del piè di pagina in tutta la presentazione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/).
2. Ottieni un riferimento alla master slide per il suo indice.
3. Imposta i segnaposto del piè di pagina della master e di tutti i layout figlio su visibili.
4. Imposta i segnaposto del numero della diapositiva della master e di tutti i layout figlio su visibili.
5. Imposta i segnaposto data-ora della master e di tutti i layout figlio su visibili.
6. Salva la presentazione.

Il seguente codice JavaScript dimostra questa operazione:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Domande frequenti**

**Qual è la differenza tra una master slide e un layout slide?**

Una master slide definisce il tema complessivo e la formattazione predefinita, mentre le layout slide definiscono disposizioni specifiche di segnaposto per diversi tipi di contenuto.

**Posso copiare un layout slide da una presentazione a un'altra?**

Sì, è possibile clonare un layout slide dalla collezione di layout slide di una presentazione, accessibile tramite il metodo [getLayoutSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/presentation/#getLayoutSlides), e inserirlo in un'altra presentazione utilizzando il metodo `addClone`.

**Cosa succede se elimino un layout slide ancora utilizzato da una diapositiva?**

Se provi a eliminare un layout slide che è ancora referenziato da almeno una diapositiva nella presentazione, Aspose.Slides lancerà una [PptxEditException](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pptxeditexception/). Per evitare ciò, utilizza [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) che rimuove in modo sicuro solo i layout slide non utilizzati.