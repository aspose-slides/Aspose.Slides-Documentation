---
title: Gestire i Master delle Diapositive della Presentazione in PHP
linktitle: Master di Diapositiva
type: docs
weight: 70
url: /it/php-java/slide-master/
keywords:
- master di diapositiva
- slide master
- master slide PPT
- più master slide
- confronta master slide
- sfondo
- segnaposto
- clona master slide
- copia master slide
- duplica master slide
- master slide inutilizzato
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Gestisci i master delle diapositive in Aspose.Slides per PHP via Java: accedi, modifica, clona, confronta e rimuovi i master slide in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **slide master** definisce le impostazioni di design condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare un slide master è il metodo consueto per mantenere una presentazione coerente senza ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides per PHP via Java supporta lo stesso modello. Una presentazione può contenere una o più slide master, e ogni slide master può contenere diverse layout slide. Le diapositive normali di solito non fanno riferimento direttamente a una slide master. Invece, una diapositiva normale utilizza una layout slide, e quella layout slide appartiene a una slide master.

La gerarchia è:

1. **Slide master** – definisce il design e il tema condivisi.  
1. **Layout slide** – definisce una disposizione specifica di segnaposti e formattazioni a livello di layout.  
1. **Normal slide** – contiene il contenuto effettivo della presentazione e utilizza una layout slide.

![La gerarchia di slide master, layout slide e normal slide](slide-master_2.jpg)

In Aspose.Slides, una slide master è rappresentata dalla classe [MasterSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/). Tutte le slide master in una presentazione sono disponibili tramite il metodo [Presentation.getMasters](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getMasters), che restituisce un oggetto [MasterSlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Ereditarietà" %}}

Quando la stessa proprietà è definita a più di un livello, prevale il livello più specifico. Per esempio, se una slide master e una layout slide definiscono entrambe uno sfondo, le diapositive basate su quel layout usano lo sfondo del layout. Per ulteriori informazioni sulle layout slide, vedere [Applica o modifica layout diapositive](/slides/it/php-java/slide-layout/).

{{% /alert %}}

## **Accedere alle Slide Master**

In PowerPoint, è possibile aprire la visualizzazione Slide Master da **Visualizza** > **Slide Master**.

![Il comando Slide Master nella scheda Visualizza di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, utilizzare il metodo `getMasters` per accedere alle slide master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlideCount = $presentation->getMasters()->size();
    $firstMasterLayoutSlideCount = $firstMasterSlide->getLayoutSlides()->size();

    echo "Master slides: " . $masterSlideCount . PHP_EOL;
    echo "Layouts in the first master: " . $firstMasterLayoutSlideCount . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

È inoltre possibile ottenere la slide master usata da una diapositiva normale tramite il suo layout:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $slide->getLayoutSlide();
    $masterSlide = $layoutSlide->getMasterSlide();
    $masterSlideName = $masterSlide->getName();

    echo $masterSlideName . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Cosa Contiene una Slide Master**

Una slide master è un oggetto simile a una diapositiva. Estende [BaseSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/), quindi espone molte delle stesse proprietà di diapositiva utilizzate da diapositive normali e layout. I membri specifici della master sono elencati nella pagina API [MasterSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/).

I membri più comuni della slide master includono:

| Membro | Scopo |
| --- | --- |
| `getBackground` | Imposta lo sfondo della diapositiva a livello master. |
| `getShapes` | Contiene le forme posizionate sul master, come loghi, cornici di immagine e testo condiviso. |
| `getLayoutSlides` | Contiene le layout slide che appartengono al master. |
| `getThemeManager` | Fornisce l'accesso alle API del tema master. |
| `getHeaderFooterManager` | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per il master e i suoi layout figli. |
| `getDependingSlides` | Restituisce le diapositive normali che dipendono dal master tramite i loro layout. |

## **Aggiungere un'Immagine a una Slide Master**

Quando si aggiunge un'immagine a una slide master, essa appare nelle diapositive che usano layout appartenenti a quel master. Questo è utile per loghi, filigrane, bande decorative e altri elementi visivi ripetuti.

L'esempio seguente aggiunge un logo alla prima slide master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $logoImage = Images::fromFile("logo.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($logoImage);
    } finally {
        $logoImage->dispose();
    }

    $masterSlide->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        80,
        80,
        $presentationImage
    );

    $presentation->save("presentation-with-logo.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Per ulteriori informazioni sulle cornici immagine, vedere [Picture Frame](/slides/it/php-java/picture-frame/).

## **Lavorare con i Segnaposti**

I segnaposti sono normalmente definiti sulle layout slide. La slide master fornisce lo stile e il tema condivisi che quei layout ereditano, mentre ogni layout decide quali segnaposti sono disponibili e dove sono posizionati.

In PowerPoint, i comandi dei segnaposti sono disponibili nella visualizzazione Slide Master.

![Il comando Inserisci segnaposto nella visualizzazione Slide Master di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposti con Aspose.Slides, lavorare sulla layout slide che appartiene al master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $blankLayoutSlideName = "Custom Blank";
    $blankLayoutSlide = $masterSlide->getLayoutSlides()->add(
        SlideLayoutType::Blank,
        $blankLayoutSlideName
    );

    $blankLayoutSlide->getPlaceholderManager()->addTextPlaceholder(
        60,
        120,
        600,
        80
    );

    $presentation->getSlides()->addEmptySlide($blankLayoutSlide);
    $presentation->save("presentation-with-placeholder.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

È inoltre possibile formattare le forme segnaposto già esistenti su una slide master. L'esempio seguente trova il segnaposto del titolo e applica un riempimento a gradiente lineare:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $titlePlaceholder = findPlaceholder($masterSlide, PlaceholderType::Title);

    if (!java_is_null($titlePlaceholder)) {
        $redGradientColor = java("java.awt.Color")->RED;
        $purpleGradientColor = new Java("java.awt.Color", 128, 0, 128);

        $fillFormat = $titlePlaceholder->getFillFormat();
        $fillFormat->setFillType(FillType::Gradient);
        $gradientFormat = $fillFormat->getGradientFormat();
        $gradientFormat->setGradientShape(GradientShape::Linear);
        $gradientStops = $gradientFormat->getGradientStops();
        $gradientStops->add(0, $redGradientColor);
        $gradientStops->add(255, $purpleGradientColor);
    }

    $presentation->save("presentation-title-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

function findPlaceholder($masterSlide, $placeholderType)
{
    $shapesCount = java_values($masterSlide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapesCount; $shapeIndex++) {
        $shape = $masterSlide->getShapes()->get_Item($shapeIndex);
        $placeholder = $shape->getPlaceholder();

        if (!java_is_null($placeholder) && java_values($placeholder->getType()) == $placeholderType) {
            return $shape;
        }
    }

    return null;
}
```

![Segnaposto del titolo formattato ereditato dalle diapositive normali](slide-master_8.png)

Per ulteriori opzioni di formattazione di segnaposti e testo, vedere [Imposta testo di prompt nel segnaposto](/slides/it/php-java/manage-placeholder/) e [Formattazione del testo](/slides/it/php-java/text-formatting/).

## **Modificare lo Sfondo di una Slide Master**

Uno sfondo master è ereditato da layout e diapositive che non lo sovrascrivono. L'esempio seguente imposta un colore di sfondo solido per la prima slide master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $forestGreenColor = new Java("java.awt.Color", 34, 139, 34);

    $background = $masterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($forestGreenColor);

    $presentation->save("presentation-master-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Per argomenti correlati, vedere [Presentation Background](/slides/it/php-java/presentation-background/) e [Presentation Theme](/slides/it/php-java/presentation-theme/).

## **Clonare una Slide Master in un'Altra Presentazione**

Utilizzare `addClone` da [MasterSlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslidecollection/) per copiare una slide master in un'altra presentazione. Il master copiato può quindi essere usato da layout e diapositive nella presentazione di destinazione.

```php
$sourcePresentation = new Presentation("source.pptx");
$destinationPresentation = new Presentation("destination.pptx");
try {
    $sourceMasterSlide = $sourcePresentation->getMasters()->get_Item(0);
    $clonedMasterSlide = $destinationPresentation->getMasters()->addClone($sourceMasterSlide);

    $destinationPresentation->save("destination-with-master.pptx", SaveFormat::Pptx);
} finally {
    $destinationPresentation->dispose();
    $sourcePresentation->dispose();
}
```

Se è necessario clonare le diapositive normali insieme al loro master, vedere [Clone Slides](/slides/it/php-java/clone-slides/).

## **Aggiungere più Slide Master**

Una presentazione può contenere più slide master. Ciò è utile quando diverse sezioni richiedono branding, struttura di pagina o impostazioni del tema differenti.

![Comandi PowerPoint per inserire e gestire le slide master](slide-master_9.jpg)

L'esempio seguente clona il master predefinito, assegna al clone uno sfondo diverso, crea un layout sotto quel master clonato e aggiunge una nuova diapositiva basata su quel layout:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
    $sectionMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);
    $lightSteelBlueColor = new Java("java.awt.Color", 176, 196, 222);

    $background = $sectionMasterSlide->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $fillFormat = $background->getFillFormat();
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor($lightSteelBlueColor);

    $sourceBlankLayout = $defaultMasterSlide->getLayoutSlides()->get_Item(0);
    $sectionBlankLayout = $sectionMasterSlide->getLayoutSlides()->addClone($sourceBlankLayout);

    $presentation->getSlides()->addEmptySlide($sectionBlankLayout);
    $presentation->save("presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Confrontare le Slide Master**

Le slide master possono essere confrontate con il metodo `equals` ereditato da [BaseSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/). Il confronto verifica struttura e contenuto statico, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta identificatori unici, come gli ID delle diapositive, né valori dinamici dei segnaposti, come la data corrente.

```php
$firstPresentation = new Presentation("first.pptx");
$secondPresentation = new Presentation("second.pptx");
try {
    $firstPresentationMasterCount = java_values($firstPresentation->getMasters()->size());
    $secondPresentationMasterCount = java_values($secondPresentation->getMasters()->size());

    for ($firstMasterIndex = 0; $firstMasterIndex < $firstPresentationMasterCount; $firstMasterIndex++) {
        for ($secondMasterIndex = 0; $secondMasterIndex < $secondPresentationMasterCount; $secondMasterIndex++) {
            $firstMasterSlide = $firstPresentation->getMasters()->get_Item($firstMasterIndex);
            $secondMasterSlide = $secondPresentation->getMasters()->get_Item($secondMasterIndex);
            $areMasterSlidesEqual = $firstMasterSlide->equals($secondMasterSlide);

            if ($areMasterSlidesEqual) {
                echo "first.pptx master #" . $firstMasterIndex .
                    " equals second.pptx master #" . $secondMasterIndex . PHP_EOL;
            }
        }
    }
} finally {
    $secondPresentation->dispose();
    $firstPresentation->dispose();
}
```

Per ulteriori informazioni, vedere [Confronta diapositive di presentazione](/slides/it/php-java/compare-slides/).

## **Impostare la Vista Slide Master come Vista Predefinita**

Utilizzare il metodo `setLastView` su [ViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/) per controllare la vista che PowerPoint apre per prima. L'esempio seguente apre la presentazione nella vista Slide Master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Per altre impostazioni della vista, vedere [Save Presentation](/slides/it/php-java/save-presentation/).

## **Rimuovere le Slide Master Inutilizzate**

Le presentazioni a volte contengono slide master che non sono più utilizzate da alcuna diapositiva normale. Rimuovere i master inutilizzati può ridurre la dimensione del file e semplificare la manutenzione del modello.

Utilizzare `removeUnused` da [MasterSlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslidecollection/) per rimuovere i master inutilizzati dalla collezione `getMasters`:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

È anche possibile utilizzare il metodo low‑code `removeUnusedMasterSlides` della classe [Compress](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/):

```php
$presentation = new Presentation("presentation.pptx");
try {
    Compress::removeUnusedMasterSlides($presentation);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Qual è la differenza tra una slide master e una layout slide?**

Una slide master definisce impostazioni di design condivise come tema, sfondo, forme comuni e stili di testo. Una layout slide appartiene a una slide master e definisce una disposizione specifica di segnaposti. Una diapositiva normale utilizza una layout slide, quindi eredita sia dal layout sia dal master.

**Una presentazione può contenere più slide master?**

Sì. Una presentazione può contenere più slide master. Utilizzare più master quando sezioni diverse richiedono sistemi visivi o branding differenti.

**Devo aggiungere segnaposti a una slide master o a una layout slide?**

Nella maggior parte dei casi, aggiungere i segnaposti alle layout slide. Posizionare gli elementi visivi condivisi e la formattazione comune sulla slide master, quindi inserire i segnaposti di contenuto sui layout che le diapositive normali utilizzeranno.

**Posso eliminare una slide master ancora in uso?**

No. Una slide master che ha diapositive dipendenti non può essere rimossa in modo sicuro direttamente. Spostare prima quelle diapositive su layout sotto un altro master, oppure utilizzare un metodo di pulizia dei master inutilizzati che rimuove solo i master non in uso.