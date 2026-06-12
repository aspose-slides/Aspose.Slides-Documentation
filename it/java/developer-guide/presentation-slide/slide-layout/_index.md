---
title: Applicare o modificare i layout di diapositiva in Java
linktitle: Layout diapositiva
type: docs
weight: 60
url: /it/java/slide-layout/
keywords:
- layout diapositiva
- layout contenuto
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
- Java
- Aspose.Slides
description: "Gestisci e personalizza i layout di diapositiva in Aspose.Slides per Java. Esplora i tipi di layout, il controllo dei segnaposto e la visibilità del piè di pagina attraverso esempi di codice Java."
---
## **Introduzione**

Un layout di diapositiva definisce la disposizione dei riquadri segnaposto e la formattazione del contenuto su una diapositiva. Controlla quali segnaposto sono disponibili e dove appaiono. I layout di diapositiva ti aiutano a progettare presentazioni rapidamente e in modo coerente—che tu stia creando qualcosa di semplice o più complesso. Alcuni dei layout di diapositiva più comuni in PowerPoint includono:

**Title Slide layout** – Include due segnaposto di testo: uno per il titolo e uno per il sottotitolo.

**Title and Content layout** – Presenta un segnaposto titolo più piccolo in alto e uno più grande sotto per il contenuto principale (come testo, punti elenco, grafici, immagini e altro).

**Blank layout** – Non contiene segnaposti, offrendoti il pieno controllo per progettare la diapositiva da zero.

I layout di diapositiva fanno parte di uno slide master, che è la diapositiva di livello superiore che definisce gli stili di layout per la presentazione. Puoi accedere e modificare i layout tramite lo slide master—sia per tipo, nome o ID unico. In alternativa, puoi modificare direttamente un layout specifico all'interno della presentazione.

Per lavorare con i layout di diapositiva in Aspose.Slides for Java, è possibile utilizzare:

- Metodi come [getLayoutSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getLayoutSlides--) e [getMasters](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getMasters--) nella classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/)
- Tipi come [ILayoutSlide](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/), e [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}

Per saperne di più su come lavorare con le slide master, consulta l'articolo [Slide Master](/slides/it/java/slide-master/).

{{% /alert %}}

## **Aggiungere layout di diapositiva alle presentazioni**

Per personalizzare l'aspetto e la struttura delle tue diapositive, potresti dover aggiungere nuovi layout a una presentazione. Aspose.Slides for Java ti consente di verificare se un layout specifico esiste già, aggiungerne uno nuovo se necessario e usarlo per inserire diapositive basate su quel layout.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Accedi alla [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/it/java/com.aspose.slides/imasterlayoutslidecollection/).
1. Verifica se il layout desiderato esiste già nella collezione. In caso contrario, aggiungi il layout di cui hai bisogno.
1. Aggiungi una diapositiva vuota basata sul nuovo layout.
1. Salva la presentazione.

Il seguente codice Java dimostra come aggiungere un layout di diapositiva a una presentazione PowerPoint:

```java
// Istanziare la classe Presentation che rappresenta un file PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Scorrere i tipi di layout di diapositiva per selezionare un layout di diapositiva.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // Una situazione in cui la presentazione non contiene tutti i tipi di layout.
        // Il file della presentazione contiene solo i tipi di layout Blank e Custom.
        // Tuttavia, le diapositive di layout con tipi personalizzati possono avere nomi riconoscibili,
        // come "Title", "Title and Content", ecc., che possono essere usati per la selezione del layout di diapositiva.
        // È inoltre possibile basarsi su un insieme di tipi di forma segnaposto.
        // Ad esempio, una diapositiva Title dovrebbe avere solo il tipo di segnaposto Title, e così via.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Aggiungere una diapositiva vuota usando il layout di diapositiva aggiunto.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Salvare la presentazione su disco.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rimuovere layout di diapositiva inutilizzati**

Aspose.Slides fornisce il metodo [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) della classe [Compress](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/) per consentire di eliminare i layout di diapositiva indesiderati e non utilizzati.

Il seguente codice Java mostra come rimuovere un layout di diapositiva da una presentazione PowerPoint:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aggiungere segnaposti ai layout di diapositiva**

Aspose.Slides fornisce il metodo [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) che consente di aggiungere nuovi segnaposti a un layout di diapositiva.

Questo manager contiene metodi per i seguenti tipi di segnaposto:

| Segnaposto PowerPoint              | Metodo [ILayoutPlaceholderManager](https://reference.aspose.com/slides/it/java/com.aspose.slides/ilayoutplaceholdermanager/) |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Contenuto](content.png)          | addContentPlaceholder(float x, float y, float width, float height) |
| ![Contenuto (Verticale)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Testo](text.png)                 | addTextPlaceholder(float x, float y, float width, float height) |
| ![Testo (Verticale)](textV.png)    | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Immagine](picture.png)           | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Grafico](chart.png)              | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabella](table.png)              | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)          | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Immagine online](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Il seguente codice Java dimostra come aggiungere nuove forme segnaposto al layout vuoto:

```java
Presentation presentation = new Presentation();
try {
    // Ottieni la diapositiva di layout Blank.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Ottieni il gestore dei segnaposto della diapositiva di layout.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Aggiungi diversi segnaposto alla diapositiva di layout Blank.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Aggiungi una nuova diapositiva con il layout Blank.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Il risultato:

![I segnaposti sul layout della diapositiva](add_placeholders.png)

## **Impostare la visibilità del piè di pagina per un layout di diapositiva**

In presentazioni PowerPoint, gli elementi del piè di pagina come data, numero diapositiva e testo personalizzato possono essere mostrati o nascosti a seconda del layout della diapositiva. Aspose.Slides for Java consente di controllare la visibilità di questi segnaposto del piè di pagina. Questo è utile quando desideri che alcuni layout mostrino le informazioni del piè di pagina mentre altri rimangano puliti e minimi.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento al layout di diapositiva per indice.
1. Imposta il segnaposto del piè di pagina della diapositiva su visibile.
1. Imposta il segnaposto del numero diapositiva su visibile.
1. Imposta il segnaposto data‑ora su visibile.
1. Salva la presentazione.

Il seguente codice Java mostra come impostare la visibilità del piè di pagina di una diapositiva e svolgere le operazioni correlate:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **Impostare la visibilità del piè di pagina per le diapositive figlie**

In presentazioni PowerPoint, gli elementi del piè di pagina come data, numero diapositiva e testo personalizzato possono essere controllati a livello di slide master per garantire coerenza su tutti i layout di diapositiva. Aspose.Slides for Java consente di impostare la visibilità e il contenuto di questi segnaposto del piè di pagina sullo slide master e di propagare queste impostazioni a tutti i layout figlio. Questo approccio assicura informazioni uniformi sul piè di pagina in tutta la presentazione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/).
1. Ottieni un riferimento al master slide per indice.
1. Imposta tutti i segnaposto del piè di pagina del master e dei layout figlio su visibili.
1. Imposta tutti i segnaposto del numero diapositiva del master e dei layout figlio su visibili.
1. Imposta tutti i segnaposto data‑ora del master e dei layout figlio su visibili.
1. Salva la presentazione.

Il seguente codice Java dimostra questa operazione:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qual è la differenza tra una slide master e una slide layout?**

Una slide master definisce il tema complessivo e la formattazione predefinita, mentre le slide layout definiscono disposizioni specifiche di segnaposto per diversi tipi di contenuto.

**Posso copiare una slide layout da una presentazione all'altra?**

Sì, puoi clonare una slide layout dalla collezione di layout di una presentazione, accessibile tramite il metodo [getLayoutSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/presentation/#getLayoutSlides--), e inserirla in un'altra presentazione usando il metodo `addClone`.

**Cosa succede se elimino una slide layout ancora usata da una slide?**

Se tenti di eliminare una slide layout ancora referenziata da almeno una slide nella presentazione, Aspose.Slides genererà un'eccezione [PptxEditException](https://reference.aspose.com/slides/it/java/com.aspose.slides/pptxeditexception/). Per evitarlo, utilizza [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) che rimuove in sicurezza solo i layout non in uso.