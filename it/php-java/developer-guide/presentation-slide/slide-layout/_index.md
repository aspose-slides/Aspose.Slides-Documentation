---
title: Applicare o modificare i layout delle diapositive in PHP
linktitle: Layout diapositiva
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
description: "Applica, crea e modifica i layout delle diapositive in Aspose.Slides per PHP tramite Java, aggiungi segnaposti, rimuovi layout inutilizzati e controlla la visibilità del piè di pagina."
---
## **Panoramica**

Un layout di diapositiva definisce le posizioni e la formattazione dei segnaposto come titoli, testo, immagini, grafici e tabelle. Applicare un layout conferisce alle diapositive una struttura coerente consentendo a ciascuna diapositiva di contenere il proprio contenuto.

I layout più comuni includono:

- **Title Slide**: Contiene segnaposto per titolo e sottotitolo.
- **Title and Content**: Contiene un segnaposto per il titolo e un segnaposto di contenuto generico.
- **Blank**: Non contiene segnaposti di contenuto ed è utile quando ogni forma sarà posizionata manualmente.

## **Comprendere l'Eredità dei Layout**

Una presentazione ha tre livelli correlati:

1. Una [master slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/) definisce il tema, la formattazione condivisa, gli sfondi e gli oggetti comuni.
1. Una [layout slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/) appartiene a un master e definisce una particolare disposizione dei segnaposto.
1. Una [normal slide](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/) utilizza un layout e memorizza il contenuto inserito per quella diapositiva.

Una normal slide eredita il tema e la formattazione dal suo layout, e il layout eredita dal suo master. Un valore impostato direttamente su una normal slide sovrascrive il valore ereditato a quel livello. Quando una normal slide viene creata, le sue forme segnaposto vengono generate dal layout selezionato, mentre il contenuto inserito in quei segnaposto appartiene alla normal slide.

Aggiungi i segnaposto richiesti a un layout prima di creare diapositive da esso. L'aggiunta successiva di un altro segnaposto a un layout non aggiunge automaticamente una forma segnaposto corrispondente alle diapositive normali esistenti.

Questa relazione ha due importanti conseguenze:

- Modificare la formattazione ereditata o la geometria dei segnaposto esistenti su un layout può aggiornare tutte le diapositive che dipendono da esso. Prima di modificare un layout già in uso, controlla le diapositive dipendenti e revisiona la presentazione risultante.
- Un layout ancora utilizzato da una diapositiva non può essere rimosso. Riassegna prima le sue diapositive dipendenti a un altro layout, oppure rimuovi solo i layout inutilizzati.

Per ulteriori informazioni sul livello superiore di questa gerarchia, vedere [Slide Master](/slides/it/php-java/slide-master/).

Per nascondere loghi ereditati o forme decorative del master su una singola diapositiva o attraverso un layout condiviso, vedere [Control the Visibility of Master Graphics](/slides/it/php-java/slide-master/). L'esempio confronta due diapositive che usano lo stesso master.

## **Selezionare e Applicare un Layout di Diapositiva**

Usa un tipo di layout quando la presentazione segue le definizioni standard dei layout di PowerPoint. I nomi dei layout sono modificabili dall'utente e possono essere localizzati, quindi la selezione basata sul nome è meno affidabile a meno che non si controlli il modello di origine.

L'esempio seguente cerca **Title and Content** nel primo master. Se quel layout non è disponibile, ricade deliberatamente su **Blank**. Il secondo controllo null è necessario perché una presentazione può contenere solo layout personalizzati. Il layout selezionato viene quindi applicato alla prima normal slide tramite il metodo [Slide.setLayoutSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#setLayoutSlide).

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getMasters()->get_Item(0)->getLayoutSlides();
    $targetLayout = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($targetLayout)) {
        $targetLayout = $layoutSlides->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($targetLayout)) {
        throw new \RuntimeException("The first master does not contain a suitable layout slide.");
    }

    $presentation->getSlides()->get_Item(0)->setLayoutSlide($targetLayout);
    $presentation->save("output-with-new-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Modificare il layout di una diapositiva non rimuove le forme ordinarie aggiunte direttamente alla diapositiva. Tuttavia, le posizioni dei segnaposto, la formattazione ereditata e la corrispondenza tra i segnaposto esistenti e il nuovo layout possono cambiare, quindi verifica l'output quando passi da layout sostanzialmente diversi.

## **Aggiungere una Diapositiva Layout**

La selezione e la creazione sono operazioni separate. L'esempio precedente seleziona un layout esistente; non ne crea uno. Per creare un layout, chiama il metodo [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterlayoutslidecollection/#add) sulla collezione di layout del master di destinazione.

L'esempio seguente aggiunge sempre un nuovo layout **Title and Content** denominato `Report Title and Content`, quindi aggiunge una normal slide basata su di esso. I nomi dei layout devono essere univoci all'interno della collezione.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $reportLayout = $masterSlide->getLayoutSlides()->add(SlideLayoutType::TitleAndObject, "Report Title and Content");
    $presentation->getSlides()->addEmptySlide($reportLayout);

    $presentation->save("output-with-report-layout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Aggiungi un layout solo quando il modello ha realmente bisogno di un'altra struttura riutilizzabile. Se esiste già un layout adatto, selezionalo e riusalo invece di crearne un duplicato.

## **Aggiungere Segnaposto a una Diapositiva Layout**

Il metodo [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/#getPlaceholderManager) fornisce un [LayoutPlaceholderManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutplaceholdermanager/) per aggiungere forme segnaposto a un layout.

| Segnaposto PowerPoint              | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![Contenuto](content.png)          | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Contenuto (Verticale)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Testo](text.png)                 | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Testo (Verticale)](textV.png)    | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Immagine](picture.png)           | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Grafico](chart.png)              | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tabella](table.png)              | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)          | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Media](media.png)                | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Immagine Online](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

L'esempio seguente verifica che il layout **Blank** esista, aggiunge quattro segnaposto a esso e poi crea una normal slide che utilizza il layout modificato. L'ordine è intenzionale: i segnaposto vengono aggiunti prima della creazione della normal slide, così Aspose.Slides può generare le forme segnaposto corrispondenti su quella diapositiva.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    if (java_is_null($blankLayout)) {
        throw new \RuntimeException("The presentation does not contain a Blank layout slide.");
    }

    $placeholderManager = $blankLayout->getPlaceholderManager();
    $placeholderManager->addContentPlaceholder(20, 20, 310, 270);
    $placeholderManager->addVerticalTextPlaceholder(350, 20, 350, 270);
    $placeholderManager->addChartPlaceholder(20, 310, 310, 180);
    $placeholderManager->addTablePlaceholder(350, 310, 350, 180);

    $presentation->getSlides()->addEmptySlide($blankLayout);
    $presentation->save("output-with-placeholders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il risultato:

![I segnaposti sulla diapositiva layout](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modificare la formattazione ereditata o la geometria dei segnaposto esistenti su un layout può influire sulle diapositive dipendenti. Un segnaposto layout aggiunto di recente non viene retrocompatibilmente inserito nelle diapositive normali esistenti. Prova le modifiche al layout su una copia della presentazione e controlla ogni diapositiva dipendente.
{{% /alert %}}

## **Rimuovere Diapositive Layout Inutilizzate**

Usa il metodo [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) per rimuovere i layout a cui non fa riferimento alcuna normal slide. Il metodo lascia intatti i layout ancora in uso.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    $presentation->save("output-without-unused-layouts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Per rimuovere uno specifico layout, usa prima il suo metodo [hasDependingSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/#hasDependingSlides) o [getDependingSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/#getDependingSlides). Riassegna le diapositive dipendenti prima di chiamare [LayoutSlide.remove](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/#remove). Tentare di rimuovere un layout in uso genera una [PptxEditException](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxeditexception/).

## **Controllare la Visibilità del Piè di Pagina su una Diapositiva Layout**

Un layout ha i propri segnaposto per piè di pagina, numero diapositiva e data/ora. Usa il metodo [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/#getHeaderFooterManager) per controllare questi segnaposto per un singolo layout. È utile, ad esempio, quando i layout di contenuto devono mostrare i piè di pagina ma i layout di titolo no.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::TitleAndObject);

    if (java_is_null($layoutSlide)) {
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    }

    if (java_is_null($layoutSlide)) {
        throw new \RuntimeException("The presentation does not contain a suitable layout slide.");
    }

    $headerFooterManager = $layoutSlide->getHeaderFooterManager();
    $headerFooterManager->setFooterVisibility(true);
    $headerFooterManager->setSlideNumberVisibility(true);
    $headerFooterManager->setDateTimeVisibility(true);
    $headerFooterManager->setFooterText("Footer text");
    $headerFooterManager->setDateTimeText("Date and time text");

    $presentation->save("output-with-layout-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Controllare la Visibilità del Piè di Pagina su un Master e sui Suoi Layout Figlio**

Per applicare impostazioni di piè di pagina coerenti su tutta la gerarchia del master, usa il metodo [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/#getHeaderFooterManager). I metodi di propagazione di [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslideheaderfootermanager/) operano sul master e sui suoi layout dipendenti e sulle diapositive normali; non hanno effetto su una singola diapositiva normale.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true);
    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true);
    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true);
    $headerFooterManager->setFooterAndChildFootersText("Footer text");
    $headerFooterManager->setDateTimeAndChildDateTimesText("Date and time text");

    $presentation->save("output-with-master-footers.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Qual è la differenza tra una Master Slide e una Layout Slide?**

Una master slide definisce il tema della presentazione e la formattazione condivisa. Una layout slide appartiene a un master e definisce una disposizione riutilizzabile di segnaposto. Le normal slide utilizzano questi layout e memorizzano il contenuto specifico della diapositiva.

**Posso copiare una Layout Slide da una presentazione all'altra?**

Sì. Aggiungi una copia alla collezione di destinazione con il metodo [addClone](https://reference.aspose.com/slides/it/php-java/aspose.slides/globallayoutslidecollection/#addClone). Quando copi tra presentazioni, verifica anche i caratteri, i temi, le immagini e le altre risorse utilizzate dal layout di origine.

**Cosa succede quando modifico un layout già in uso?**

Le diapositive dipendenti ereditano le modifiche al layout, a meno che non sovrascrivano localmente la formattazione o gli oggetti interessati. La geometria dei segnaposto e lo stile ereditato possono quindi cambiare su molte diapositive contemporaneamente. Usa [getDependingSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/#getDependingSlides) per identificare le diapositive interessate prima di modificare il layout.

**Cosa succede se rimuovo un layout ancora in uso?**

Aspose.Slides genera una [PptxEditException](https://reference.aspose.com/slides/it/php-java/aspose.slides/pptxeditexception/). Riassegna prima le diapositive dipendenti, oppure usa [removeUnusedLayoutSlides](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) per rimuovere solo i layout non referenziati.