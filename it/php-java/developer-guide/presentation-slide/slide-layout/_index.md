---
title: Applica o Modifica Layout Diapositive in PHP
linktitle: Layout Diapositiva
type: docs
weight: 60
url: /it/php-java/slide-layout/
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
- PHP
- Aspose.Slides
description: "Gestisci e personalizza i layout delle diapositive in Aspose.Slides per PHP tramite Java. Esplora i tipi di layout, il controllo dei segnaposto e la visibilità del piè di pagina attraverso esempi di codice."
---
## **Introduzione**

Un layout diapositive definisce la disposizione delle caselle segnaposto e la formattazione del contenuto su una diapositiva. Controlla quali segnaposto sono disponibili e dove appaiono. I layout diapositive ti aiutano a progettare presentazioni rapidamente e in modo coerente, sia che tu stia creando qualcosa di semplice o più complesso. Alcuni dei layout diapositive più comuni in PowerPoint includono:

**Layout Titolo Diapositiva** – Include due segnaposto di testo: uno per il titolo e uno per il sottotitolo.

**Layout Titolo e Contenuto** – Presenta un segnaposto titolo più piccolo in alto e uno più grande sotto per il contenuto principale (come testo, elenchi puntati, grafici, immagini e altro).

**Layout Vuoto** – Non contiene segnaposto, offrendoti pieno controllo per progettare la diapositiva da zero.

I layout diapositive fanno parte di un master slide, che è la diapositiva di livello superiore che definisce gli stili di layout per la presentazione. Puoi accedere e modificare i layout diapositive tramite il master slide, sia per tipo, nome o ID univoco. In alternativa, puoi modificare un layout diapositiva specifico direttamente nella presentazione.

Per lavorare con i layout diapositive in Aspose.Slides per PHP, puoi utilizzare:

- Metodi come [getLayoutSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getLayoutSlides) e [getMasters](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getMasters) nella classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/)
- Tipi come [LayoutSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutplaceholdermanager/), e [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Per saperne di più sul lavoro con i master slide, consulta l'articolo [Slide Master](/slides/it/php-java/slide-master/).
{{% /alert %}}

## **Aggiungere Layout Diapositive alle Presentazioni**

Per personalizzare l'aspetto e la struttura delle tue diapositive, potresti dover aggiungere nuovi layout diapositive a una presentazione. Aspose.Slides per PHP ti consente di verificare se un layout specifico esiste già, aggiungerne uno nuovo se necessario e usarlo per inserire diapositive basate su quel layout.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Accedi alla [MasterLayoutSlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterlayoutslidecollection/).
3. Verifica se il layout diapositive desiderato esiste già nella collezione. In caso contrario, aggiungi il layout diapositive di cui hai bisogno.
4. Aggiungi una diapositiva vuota basata sul nuovo layout diapositive.
5. Salva la presentazione.

Il seguente codice PHP dimostra come aggiungere un layout diapositiva a una presentazione PowerPoint:

```php
// Istanziare la classe Presentation che rappresenta un file PowerPoint.
$presentation = new Presentation("Sample.pptx");
try {
    // Scorrere i tipi di layout diapositiva per selezionare un layout diapositiva.
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
        $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }

    if (java_is_null($layoutSlide)) {
        // Una situazione in cui la presentazione non contiene tutti i tipi di layout.
        // Il file della presentazione contiene solo i tipi di layout Vuoto e Personalizzato.
        // Tuttavia, i layout diapositive con tipi personalizzati possono avere nomi riconoscibili,
        // come "Title", "Title and Content", ecc., che possono essere usati per la selezione del layout diapositiva.
        // Puoi inoltre fare affidamento su un insieme di tipi di forme segnaposto.
        // Ad esempio, una diapositiva Titolo dovrebbe contenere solo il tipo di segnaposto Titolo, e così via.
        foreach($layoutSlides as $titleAndObjectLayoutSlide) {
            if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
                $layoutSlide = $titleAndObjectLayoutSlide;
                break;
            }
        }

        if (java_is_null($layoutSlide)) {
            foreach($layoutSlides as $titleLayoutSlide) {
                if (java_values($titleLayoutSlide->getName()) == "Title") {
                    $layoutSlide = $titleLayoutSlide;
                    break;
                }
            }

            if (java_is_null($layoutSlide)) {
                $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
                if (java_is_null($layoutSlide)) {
                    $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // Aggiungi una diapositiva vuota utilizzando il layout diapositiva aggiunto.
    $presentation->getSlides()->insertEmptySlide(0, $layoutSlide);

    // Salva la presentazione su disco.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Rimuovere Layout Diapositive Non Utilizzati**

Aspose.Slides fornisce il metodo [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) della classe [Compress](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/) per consentire di eliminare i layout diapositive indesiderati e non utilizzati.

Il seguente codice PHP mostra come rimuovere un layout diapositiva da una presentazione PowerPoint:

```php
$presentation = new Presentation("Presentation.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Aggiungere Segnaposto ai Layout Diapositive**

Aspose.Slides fornisce il metodo [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/#getPlaceholderManager), che consente di aggiungere nuovi segnaposto a un layout diapositiva.

Questo gestore contiene metodi per i seguenti tipi di segnaposto:

| PowerPoint Placeholder              | [LayoutPlaceholderManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutplaceholdermanager/) Method |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Contenuto](content.png)           | addContentPlaceholder(float x, float y, float width, float height) |
| ![Contenuto (Verticale)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Testo](text.png)                  | addTextPlaceholder(float x, float y, float width, float height) |
| ![Testo (Verticale)](textV.png)     | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Immagine](picture.png)            | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Grafico](chart.png)               | addChartPlaceholder(float x, float y, float width, float height) |
| ![Tabella](table.png)               | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)           | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png)                 | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Immagine Online](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

Il seguente codice PHP dimostra come aggiungere nuove forme segnaposto al layout Vuoto:

```php
$presentation = new Presentation();
try {
    // Ottieni la diapositiva di layout Vuoto.
    $layout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Ottieni il gestore dei segnaposto della diapositiva di layout.
    $placeholderManager = $layout->getPlaceholderManager();

    // Aggiungi diversi segnaposto alla diapositiva di layout Vuoto.
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    // Aggiungi una nuova diapositiva con il layout Vuoto.
    $newSlide = $presentation->getSlides()->addEmptySlide($layout);

    $presentation->save("Placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![I segnaposto sul layout diapositiva](add_placeholders.png)

## **Impostare la Visibilità del Piè di Pagina per un Layout Diapositiva**

In PowerPoint, gli elementi del piè di pagina come data, numero diapositiva e testo personalizzato possono essere mostrati o nascosti a seconda del layout della diapositiva. Aspose.Slides per PHP consente di controllare la visibilità di questi segnaposto del piè di pagina. Questo è utile quando si desidera che alcuni layout mostrino le informazioni del piè di pagina mentre altri rimangano puliti e minimalisti.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni un riferimento al layout diapositiva per indice.
3. Imposta il segnaposto del piè di pagina della diapositiva su visibile.
4. Imposta il segnaposto del numero diapositiva su visibile.
5. Imposta il segnaposto data/ora su visibile.
6. Salva la presentazione.

Il seguente codice PHP mostra come impostare la visibilità di un piè di pagina diapositiva e eseguire operazioni correlate:

```php
$presentation = new Presentation("Presentation.ppt");
try {
    $headerFooterManager = $presentation->getLayoutSlides()->get_Item(0)->getHeaderFooterManager();

    if (!$headerFooterManager->isFooterVisible()) {
        $headerFooterManager->setFooterVisibility(true);
    }

    if (!$headerFooterManager->isSlideNumberVisible()) {
        $headerFooterManager->setSlideNumberVisibility(true);
    }

    if (!$headerFooterManager->isDateTimeVisible()) {
        $headerFooterManager->setDateTimeVisibility(true);
    }

    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("Presentation.ppt", SaveFormat::Ppt);
} finally {
    $presentation->dispose();
}
```

## **Impostare la Visibilità del Piè di Pagina Figlio per una Diapositiva**

In PowerPoint, gli elementi del piè di pagina come data, numero diapositiva e testo personalizzato possono essere controllati a livello di master slide per garantire coerenza su tutti i layout diapositive. Aspose.Slides per PHP ti permette di impostare la visibilità e il contenuto di questi segnaposto del piè di pagina sulla master slide e propagare queste impostazioni a tutti i layout diapositive figlio. Questo approccio assicura informazioni uniformi del piè di pagina in tutta la presentazione.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/).
2. Ottieni un riferimento alla master slide per indice.
3. Imposta i segnaposto del piè di pagina della master e di tutti i figli su visibili.
4. Imposta i segnaposto del numero diapositiva della master e di tutti i figli su visibili.
5. Imposta i segnaposto data/ora della master e di tutti i figli su visibili.
6. Salva la presentazione.

Il seguente codice PHP dimostra questa operazione:

```php
$presentation = new Presentation("presentation.ppt");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();

    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);

    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("Output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Qual è la differenza tra una master slide e una layout slide?**

Una master slide definisce il tema generale e la formattazione predefinita, mentre le layout slide definiscono disposizioni specifiche di segnaposto per diversi tipi di contenuto.

**Posso copiare una layout slide da una presentazione all'altra?**

Sì, è possibile clonare una layout slide dalla collezione di layout slide di una presentazione, accessibile tramite il metodo [getLayoutSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getLayoutSlides), e inserirla in un'altra presentazione usando il metodo `addClone`.

**Cosa succede se elimino una layout slide ancora utilizzata da una diapositiva?**

Se tenti di eliminare una layout slide che è ancora referenziata da almeno una diapositiva nella presentazione, Aspose.Slides genererà un'eccezione [PptxEditException](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxeditexception/). Per evitarlo, usa [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) che rimuove in modo sicuro solo le layout slide non utilizzate.