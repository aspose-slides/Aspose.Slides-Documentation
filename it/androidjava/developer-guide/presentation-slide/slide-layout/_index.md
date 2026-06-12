---
title: "Applica o Modifica Layout di Diapositiva su Android"
linktitle: "Layout di Diapositiva"
type: docs
weight: 60
url: /it/androidjava/slide-layout/
keywords:
- "layout di diapositiva"
- "layout di contenuto"
- "segnaposto"
- "progettazione della presentazione"
- "progettazione della diapositiva"
- "layout non utilizzato"
- "visibilità del piè di pagina"
- "diapositiva titolo"
- "titolo e contenuto"
- "intestazione sezione"
- "due contenuti"
- "confronto"
- "solo titolo"
- "layout vuoto"
- "contenuto con didascalia"
- "immagine con didascalia"
- "titolo e testo verticale"
- "titolo verticale e testo"
- "PowerPoint"
- "OpenDocument"
- "presentazione"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Gestisci e personalizza i layout di diapositiva in Aspose.Slides per Android. Esplora i tipi di layout, il controllo dei segnaposto e la visibilità del piè di pagina tramite esempi di codice Java."
---
## **Introduzione**

Un layout di diapositiva definisce la disposizione delle caselle segnaposto e la formattazione del contenuto su una diapositiva. Controlla quali segnaposto sono disponibili e dove appaiono. I layout di diapositiva ti aiutano a progettare presentazioni rapidamente e in modo coerente, sia che tu stia creando qualcosa di semplice sia di più complesso. Alcuni dei layout di diapositiva più comuni in PowerPoint includono:

**Layout Titolo** – Include due segnaposto di testo: uno per il titolo e uno per il sottotitolo.

**Layout Titolo e Contenuto** – Presenta un segnaposto titolo più piccolo in alto e uno più grande sotto per il contenuto principale (testo, punti elenco, grafici, immagini e altro).

**Layout Vuoto** – Non contiene segnaposto, offrendoti il pieno controllo per progettare la diapositiva da zero.

I layout di diapositiva fanno parte di un master di diapositiva, che è la diapositiva di livello superiore che definisce gli stili di layout per la presentazione. Puoi accedere e modificare i layout di diapositiva attraverso il master di diapositiva, sia per tipo, nome o ID univoco. In alternativa, puoi modificare direttamente un layout di diapositiva specifico all’interno della presentazione.

Per lavorare con i layout di diapositiva in Aspose.Slides per Android, puoi utilizzare:

- Metodi come [getLayoutSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) e [getMasters](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getMasters--) nella classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/)
- Tipi come [ILayoutSlide](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilayoutplaceholdermanager/), e [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Per approfondire l’uso dei master di diapositiva, consulta l’articolo [Slide Master](/slides/it/androidjava/slide-master/).
{{% /alert %}}

## **Aggiungi layout di diapositiva alle presentazioni**

Per personalizzare l’aspetto e la struttura delle tue diapositive, potresti aver bisogno di aggiungere nuovi layout di diapositiva a una presentazione. Aspose.Slides per Android ti consente di verificare se un layout specifico esiste già, aggiungerne uno nuovo se necessario e usarlo per inserire diapositive basate su quel layout.

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Accedi a [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/imasterlayoutslidecollection/).
3. Verifica se il layout di diapositiva desiderato esiste già nella collezione. In caso contrario, aggiungi il layout di cui hai bisogno.
4. Aggiungi una diapositiva vuota basata sul nuovo layout di diapositiva.
5. Salva la presentazione.

Il seguente codice Java dimostra come aggiungere un layout di diapositiva a una presentazione PowerPoint:

```java
// Istanzia la classe Presentation che rappresenta un file PowerPoint.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // Scorri i tipi di layout di diapositiva per selezionare un layout di diapositiva.
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
        // Puoi anche fare affidamento su un insieme di tipi di forma segnaposto.
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

    // Aggiungi una diapositiva vuota usando il layout di diapositiva aggiunto.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // Salva la presentazione su disco.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Rimuovi layout di diapositiva non utilizzati**

Aspose.Slides fornisce il metodo [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) della classe [Compress](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/) per consentirti di eliminare i layout di diapositiva indesiderati e non usati.

Il codice Java seguente mostra come rimuovere un layout di diapositiva da una presentazione PowerPoint:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Aggiungi segnaposto ai layout di diapositiva**

Aspose.Slides fornisce il metodo [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) che consente di aggiungere nuovi segnaposto a un layout di diapositiva.

Questo gestore contiene metodi per i seguenti tipi di segnaposto:

| Segnaposto PowerPoint | Metodo di [ILayoutPlaceholderManager](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) |
| ---------------------- | ----------------------------------------------------------------------------------------------------------------------------------- |
| ![Content](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Il codice Java seguente dimostra come aggiungere nuove forme segnaposto al layout Vuoto:

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

![The placeholders on the layout slide](add_placeholders.png)

## **Imposta la visibilità del piè di pagina per un layout di diapositiva**

Nelle presentazioni PowerPoint, gli elementi di piè di pagina come data, numero diapositiva e testo personalizzato possono essere mostrati o nascosti a seconda del layout di diapositiva. Aspose.Slides per Android permette di controllare la visibilità di questi segnaposto di piè di pagina. È utile quando vuoi che alcuni layout mostrino le informazioni di piè di pagina mentre altri rimangano sobri.

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Ottieni un riferimento al layout di diapositiva per indice.
3. Imposta il segnaposto del piè di pagina della diapositiva come visibile.
4. Imposta il segnaposto del numero diapositiva come visibile.
5. Imposta il segnaposto della data/ora come visibile.
6. Salva la presentazione.

Il seguente codice Java mostra come impostare la visibilità del piè di pagina di una diapositiva e le operazioni correlate:

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

## **Imposta la visibilità del piè di pagina figlio per una diapositiva**

​Nelle presentazioni PowerPoint, gli elementi di piè di pagina come data, numero diapositiva e testo personalizzato possono essere controllati a livello di master per garantire coerenza su tutti i layout di diapositiva. Aspose.Slides per Android consente di impostare visibilità e contenuto di questi segnaposto di piè di pagina sul master e di propagare le impostazioni a tutti i layout di diapositiva figlio. Questo approccio assicura informazioni di piè di pagina uniformi in tutta la presentazione.​

1. Crea un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/).
2. Ottieni un riferimento al master per indice.
3. Imposta tutti i segnaposto di piè di pagina del master e dei layout figlio come visibili.
4. Imposta tutti i segnaposto del numero diapositiva del master e dei layout figlio come visibili.
5. Imposta tutti i segnaposto della data/ora del master e dei layout figlio come visibili.
6. Salva la presentazione.

Il codice Java seguente dimostra questa operazione:

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

**Qual è la differenza tra un master di diapositiva e un layout di diapositiva?**

Un master di diapositiva definisce il tema generale e la formattazione predefinita, mentre i layout di diapositiva definiscono disposizioni specifiche di segnaposto per diversi tipi di contenuto.

**Posso copiare un layout di diapositiva da una presentazione all’altra?**

Sì, puoi clonare un layout di diapositiva dalla collezione dei layout di una presentazione, accessibile tramite il metodo [getLayoutSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/presentation/#getLayoutSlides--), e inserirlo in un’altra presentazione usando il metodo `addClone`.

**Cosa succede se elimino un layout di diapositiva ancora utilizzato da una diapositiva?**

Se tenti di eliminare un layout di diapositiva ancora referenziato da almeno una diapositiva nella presentazione, Aspose.Slides solleverà una [PptxEditException](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/pptxeditexception/). Per evitare ciò, usa [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) che rimuove in sicurezza solo i layout non in uso.