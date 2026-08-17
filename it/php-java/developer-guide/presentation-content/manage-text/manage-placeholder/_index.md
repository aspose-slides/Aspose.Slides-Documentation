---
title: Gestisci i segnaposti della presentazione in PHP
linktitle: Gestisci segnaposti
type: docs
weight: 10
url: /it/php-java/manage-placeholder/
keywords:
- segnaposto
- segnaposto di testo
- segnaposto immagine
- segnaposto grafico
- segnaposto contenuto
- testo di suggerimento
- PowerPoint
- presentazione
- PHP
- Aspose.Slides
description: "Scopri come ispezionare e modificare segnaposti di testo, immagine, grafico e contenuto e comprendere l'eredità dei segnaposti con Aspose.Slides per PHP tramite Java."
---
## **Panoramica**

Un segnaposto è una forma che riserva una posizione per un tipo particolare di contenuto in un modello di presentazione. Esempi comuni sono segnaposto per titolo, corpo, immagine, grafico e segnaposti di contenuto a scopo generale. A differenza di una forma ordinaria, un segnaposto può ereditare posizione, dimensione, formattazione e altre impostazioni da una diapositiva layout o master.

Aspose.Slides espone le informazioni sui segnaposto tramite il metodo [Shape::getPlaceholder](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getplaceholder/). Il metodo restituisce un oggetto [Placeholder](https://reference.aspose.com/slides/it/php-java/aspose.slides/placeholder/) o `null` per una forma normale. Utilizza [Placeholder::getType](https://reference.aspose.com/slides/it/php-java/aspose.slides/placeholder/gettype/) per determinare cosa è destinato a contenere il segnaposto.

La classe della forma rimane importante dopo aver conosciuto il tipo di segnaposto:

- Un segnaposto vuoto di testo, immagine, grafico o contenuto è comunemente rappresentato da un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/).
- Un segnaposto di immagine popolato può essere rappresentato da un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/).
- Un segnaposto di grafico popolato può essere rappresentato da un [Chart](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/).
- Un segnaposto di contenuto può contenere diversi tipi di contenuto. Controlla sia [Placeholder::getType](https://reference.aspose.com/slides/it/php-java/aspose.slides/placeholder/gettype/) sia la classe di forma a runtime invece di presumere che ogni segnaposto sia un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder::getType](https://reference.aspose.com/slides/it/php-java/aspose.slides/placeholder/gettype/) descrive il ruolo di un segnaposto; non garantisce la classe di forma a runtime. Usa sempre un controllo di tipo prima di accedere a membri specifici di testo, immagine, grafico, tabella o media.
{{% /alert %}}

## **Comprendere l'eredità dei segnaposto**

I segnaposto formano una gerarchia:

1. Una diapositiva master definisce stili riutilizzabili e, in alcuni casi, segnaposti a livello master.
2. Una diapositiva layout definisce la disposizione usata da una o più diapositive normali e può ereditare dal master.
3. Una diapositiva normale contiene i segnaposto per quella diapositiva e può ereditare dal suo layout.

Chiama [Shape::getBasePlaceholder](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getbaseplaceholder/) per spostarti di un livello verso l'alto in questa gerarchia. Un segnaposto diapositiva normalmente restituisce il suo segnaposto layout; un segnaposto layout può restituire il suo segnaposto master. Il metodo restituisce `null` quando la forma non ha un segnaposto base.

L'esempio seguente elenca i segnaposto sulla prima diapositiva e segnala i loro segnaposto base:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        $shapeClass = $shape->getClass();
        $shapeClassNameValue = $shapeClass->getSimpleName();
        $shapeClassName = java_values($shapeClassNameValue);
        echo "Slide placeholder: " . $placeholderType . "; shape class: " . $shapeClassName . PHP_EOL;

        $layoutPlaceholder = $shape->getBasePlaceholder();
        if (!java_is_null($layoutPlaceholder)) {
            $layoutPlaceholderInfo = $layoutPlaceholder->getPlaceholder();
            if (!java_is_null($layoutPlaceholderInfo)) {
                $layoutPlaceholderTypeValue = $layoutPlaceholderInfo->getType();
                $layoutPlaceholderType = java_values($layoutPlaceholderTypeValue);
                echo "  Layout placeholder: " . $layoutPlaceholderType . PHP_EOL;
            }

            $masterPlaceholder = $layoutPlaceholder->getBasePlaceholder();
            if (!java_is_null($masterPlaceholder)) {
                $masterPlaceholderInfo = $masterPlaceholder->getPlaceholder();
                if (!java_is_null($masterPlaceholderInfo)) {
                    $masterPlaceholderTypeValue = $masterPlaceholderInfo->getType();
                    $masterPlaceholderType = java_values($masterPlaceholderTypeValue);
                    echo "  Master placeholder: " . $masterPlaceholderType . PHP_EOL;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Modificare un segnaposto su una diapositiva normale crea o modifica una sovrascrittura locale per quella diapositiva. Modificare il layout o il master correlato può influenzare tutte le diapositive che continuano a ereditare quella impostazione. Una forma ordinaria locale non ha un segnaposto base e non inizia a ereditare solo perché occupa le stesse coordinate.

## **Modificare il testo in un segnaposto**

I segnaposto di titolo, titolo centrato, sottotitolo, corpo e testo normalmente supportano il testo. Verifica la presenza di un [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) prima di utilizzare il suo metodo [getTextFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/gettextframe/).

Questo esempio aggiorna il primo segnaposto titolo sulla prima diapositiva e salva il risultato:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $titleShape = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $titleShape = $shape;
            break;
        }
    }

    if ($titleShape === null) {
        throw new RuntimeException("The first slide does not contain a title placeholder.");
    }

    $titleShape->getTextFrame()->setText("Quarterly Business Review");
    $presentation->save("title-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Questo modello evita di trattare segnaposti di immagine, grafico, tabella o media come oggetti [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/). Identifica inoltre il segnaposto per scopo invece di basarsi su un indice di forma fragile.

## **Impostare il testo di suggerimento su un layout**

Il testo di suggerimento è l'istruzione di design-time visualizzata in un segnaposto vuoto, ad esempio *Fare clic per aggiungere il titolo*. Imposta un testo di suggerimento personalizzato sul segnaposto del layout anziché cercare di raggiungerlo attraverso la collezione di forme di una diapositiva normale. Accedi al layout tramite [Slide::getLayoutSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getLayoutSlide) e itera sulla collezione restituita da [BaseSlide::getShapes](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/#getShapes).

L'esempio seguente modifica i suggerimenti di titolo e sottotitolo sul layout usato dalla prima diapositiva:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $shapes = $layoutSlide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $autoShapeClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) {
            $shape->getTextFrame()->setText("Enter a concise slide title");
        } elseif ($placeholderType === PlaceholderType::Subtitle) {
            $shape->getTextFrame()->setText("Enter a subtitle or reporting period");
        }
    }

    $presentation->save("custom-placeholder-prompts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il testo di suggerimento non è contenuto normale di una diapositiva. È destinato ai segnaposto vuoti nelle applicazioni di modifica come PowerPoint. Una volta che un utente o un programma fornisce contenuto reale, il suggerimento non viene più visualizzato. Modificare un suggerimento non sostituisce nemmeno il testo esistente sulle diapositive che usano il layout.

## **Aggiornare un segnaposto immagine**

Ci sono due casi da gestire:

- Se il segnaposto immagine è già popolato e rappresentato da un [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/), sostituisci l'immagine tramite [PictureFillFormat::getPicture](https://reference.aspose.com/slides/it/php-java/aspose.slides/picturefillformat/getpicture/) e [SlidesPicture::setImage](https://reference.aspose.com/slides/it/php-java/aspose.slides/slidespicture/setimage/).
- Se è ancora un segnaposto vuoto, aggiungi un picture frame alle coordinate del segnaposto con [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/shapecollection/addpictureframe/) e rimuovi il segnaposto vuoto.

Il prossimo esempio supporta entrambi i casi e salva la presentazione:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("picture-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $picturePlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Picture) {
            $picturePlaceholder = $shape;
            break;
        }
    }

    if ($picturePlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a picture placeholder.");
    }

    $imageData = file_get_contents("replacement.png");
    $image = $presentation->getImages()->addImage($imageData);

    if (java_instanceof($picturePlaceholder, $pictureFrameClass)) {
        $picture = $picturePlaceholder->getPictureFormat()->getPicture();
        $picture->setImage($image);
    } else {
        $x = $picturePlaceholder->getX();
        $y = $picturePlaceholder->getY();
        $width = $picturePlaceholder->getWidth();
        $height = $picturePlaceholder->getHeight();
        $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
        $shapes->remove($picturePlaceholder);
    }

    $presentation->save("picture-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La sostituzione creata per un segnaposto vuoto è un picture frame locale, non un nuovo segnaposto, perché [Shape::getPlaceholder](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getplaceholder/) non fornisce un setter. Mantiene la posizione riservata ma non eredita più il comportamento specifico del segnaposto. Se mantenere la relazione con il segnaposto è essenziale, prepara e popola il segnaposto in PowerPoint prima, poi aggiorna il [PictureFrame](https://reference.aspose.com/slides/it/php-java/aspose.slides/pictureframe/) risultante con Aspose.Slides.

Per la trasparenza dell'immagine, il ritaglio e altri effetti specifici dell'immagine, consulta [Gestire i picture frame](/slides/it/php-java/picture-frame/). Queste operazioni appartengono al picture frame o al picture fill, non ai metadati del segnaposto.

## **Lavorare con segnaposto grafico e di contenuto**

Un segnaposto grafico popolato può essere rappresentato da un [Chart](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/). Questo esempio trova tale grafico sia per tipo di segnaposto sia per classe a runtime, ne cambia il titolo e salva il file:

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $chartClass = new JavaClass("com.aspose.slides.Chart");
    $placeholderChart = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        if (!java_instanceof($shape, $chartClass)) {
            continue;
        }

        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart) {
            $placeholderChart = $shape;
            break;
        }
    }

    if ($placeholderChart === null) {
        throw new RuntimeException("The first slide does not contain a populated chart placeholder.");
    }

    $placeholderChart->setTitle(true);
    $placeholderChart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $presentation->save("chart-placeholder-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Un segnaposto di contenuto generale ha solitamente [PlaceholderType::Object](https://reference.aspose.com/slides/it/php-java/aspose.slides/placeholdertype/). In PowerPoint funge da lanciatore per diversi tipi di contenuto, inclusi grafici, tabelle, diagrammi, immagini e media. Dopo che è stato popolato, ispeziona la classe di forma reale per capire cosa contiene. I layout specializzati possono anche esporre [PlaceholderType::Chart](https://reference.aspose.com/slides/it/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Table](https://reference.aspose.com/slides/it/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Picture](https://reference.aspose.com/slides/it/php-java/aspose.slides/placeholdertype/), [PlaceholderType::Media](https://reference.aspose.com/slides/it/php-java/aspose.slides/placeholdertype/), o [PlaceholderType::Diagram](https://reference.aspose.com/slides/it/php-java/aspose.slides/placeholdertype/).

Aspose.Slides non converte un segnaposto [AutoShape](https://reference.aspose.com/slides/it/php-java/aspose.slides/autoshape/) vuoto in un [Chart](https://reference.aspose.com/slides/it/php-java/aspose.slides/chart/) semplicemente modificando [Placeholder::getType](https://reference.aspose.com/slides/it/php-java/aspose.slides/placeholder/gettype/); il tipo non può essere modificato tramite la classe. Per riempire programmaticamente un'area grafico o contenuto vuota, aggiungi l'oggetto richiesto alle coordinate del segnaposto e poi rimuovi il segnaposto vuoto. L'esempio seguente lo fa per un grafico:

```php
use aspose\slides\ChartType;
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("content-template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $targetPlaceholder = null;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);
        if ($placeholderType === PlaceholderType::Chart || $placeholderType === PlaceholderType::Object) {
            $targetPlaceholder = $shape;
            break;
        }
    }

    if ($targetPlaceholder === null) {
        throw new RuntimeException("The first slide does not contain a chart or content placeholder.");
    }

    $x = $targetPlaceholder->getX();
    $y = $targetPlaceholder->getY();
    $width = $targetPlaceholder->getWidth();
    $height = $targetPlaceholder->getHeight();
    $chart = $shapes->addChart(ChartType::ClusteredColumn, $x, $y, $width, $height);
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Quarterly Revenue");
    $shapes->remove($targetPlaceholder);
    $presentation->save("content-placeholder-replaced-with-chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Il grafico aggiunto è un grafico locale ordinario. Occupava l'area del segnaposto ma non eredita dal segnaposto layout. Usa gli articoli dedicati alla [gestione dei grafici](/slides/it/php-java/powerpoint-charts/) quando devi sostituire categorie, serie o dati del workbook.

## **Esempio completo: aggiornare testo o contenuto immagine**

Il seguente esempio end‑to‑end apre un modello, ricerca nella prima diapositiva un segnaposto titolo o immagine, controlla i tipi di segnaposto e forma, aggiorna il contenuto appropriato e salva il risultato. L'esempio evita deliberatamente di presumere un indice di forma o di trattare tutti i segnaposto come la stessa classe.

```php
use aspose\slides\PlaceholderType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation("template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $shapeCountValue = $shapes->size();
    $shapeCount = java_values($shapeCountValue);
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $pictureFrameClass = new JavaClass("com.aspose.slides.PictureFrame");
    $updated = false;

    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();
        if (java_is_null($placeholder)) {
            continue;
        }

        $placeholderTypeValue = $placeholder->getType();
        $placeholderType = java_values($placeholderTypeValue);

        if (($placeholderType === PlaceholderType::Title || $placeholderType === PlaceholderType::CenteredTitle) && java_instanceof($shape, $autoShapeClass)) {
            $shape->getTextFrame()->setText("Quarterly Business Review");
            $updated = true;
            break;
        }

        if ($placeholderType === PlaceholderType::Picture) {
            $imageData = file_get_contents("replacement.png");
            $image = $presentation->getImages()->addImage($imageData);

            if (java_instanceof($shape, $pictureFrameClass)) {
                $picture = $shape->getPictureFormat()->getPicture();
                $picture->setImage($image);
            } else {
                $x = $shape->getX();
                $y = $shape->getY();
                $width = $shape->getWidth();
                $height = $shape->getHeight();
                $shapes->addPictureFrame(ShapeType::Rectangle, $x, $y, $width, $height, $image);
                $shapes->remove($shape);
            }

            $updated = true;
            break;
        }
    }

    if (!$updated) {
        throw new RuntimeException("No supported title or picture placeholder was found on the first slide.");
    }

    $presentation->save("placeholder-content-updated.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Che cos'è un segnaposto base?**

Un segnaposto base è la forma corrispondente sul layout o sul master da cui un altro segnaposto eredita. Usa [Shape::getBasePlaceholder](https://reference.aspose.com/slides/it/php-java/aspose.slides/shape/getbaseplaceholder/) per recuperarlo. Una forma locale ordinaria restituisce `null` perché non fa parte della gerarchia dei segnaposto.

**Posso cambiare tutti i titoli delle diapositive modificando un segnaposto layout?**

Puoi modificare la formattazione ereditata o il testo di suggerimento tramite un layout, ma il contenuto del titolo esistente è memorizzato sulle diapositive normali. Per sostituire il testo del titolo reale in tutta la presentazione, itera sulle diapositive e aggiorna ogni segnaposto titolo.

**Come gestisco i segnaposto data, numero diapositiva, intestazione e piè di pagina?**

Usa i gestori di intestazione e piè di pagina nello scope appropriato (diapositiva, layout, master, note o handout). Consulta [Gestire intestazione e piè di pagina della presentazione](/slides/it/php-java/presentation-header-and-footer/) per esempi completi.