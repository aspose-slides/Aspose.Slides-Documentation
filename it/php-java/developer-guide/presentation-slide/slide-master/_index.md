---
title: Gestire i master slide di presentazione in PHP
linktitle: Master diapositiva
type: docs
weight: 70
url: /it/php-java/slide-master/
keywords:
- master diapositiva
- master diapositiva
- master diapositiva PPT
- master slide multipli
- confrontare master slide
- sfondo
- segnaposto
- clonare master slide
- copiare master slide
- duplicare master slide
- master slide non utilizzato
- PowerPoint
- OpenDocument
- presentazione
- PHP
- Aspose.Slides
description: "Gestire i master slide in Aspose.Slides per PHP tramite Java: accedere, modificare, clonare, confrontare e rimuovere i master slide in presentazioni PowerPoint e OpenDocument."
---
## **Panoramica**

Un **slide master** definisce le impostazioni di design condivise per un gruppo di diapositive. Può contenere forme comuni, loghi, sfondi, stili di testo, impostazioni del tema e impostazioni del piè di pagina. In PowerPoint, modificare un slide master è il metodo consueto per mantenere una presentazione coerente senza ripetere la stessa formattazione su ogni diapositiva.

Aspose.Slides per PHP via Java supporta lo stesso modello. Una presentazione può contenere una o più master slide e ogni master slide può contenere diverse layout slide. Le diapositive normali di solito non si riferiscono direttamente a una master slide. Invece, una diapositiva normale utilizza una layout slide, e quella layout slide appartiene a una master slide.

La gerarchia è:

1. **Slide master** - definisce il design condiviso e il tema.  
1. **Layout slide** - definisce una disposizione specifica di segnaposto e formattazione a livello di layout.  
1. **Normal slide** - contiene il contenuto effettivo della presentazione e utilizza una layout slide.

![La gerarchia di master slide, layout slide e diapositive normali](slide-master_2.jpg)

In Aspose.Slides, un slide master è rappresentato dalla classe [MasterSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/). Tutti i master slide in una presentazione sono disponibili tramite il metodo [Presentation.getMasters](https://reference.aspose.com/slides/it/php-java/aspose.slides/presentation/#getMasters), che restituisce un oggetto [MasterSlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslidecollection/).

{{% alert color="info" title="Ereditarietà" %}}
Quando la stessa proprietà è definita a più di un livello, vince il livello più specifico. Per esempio, se una master slide e una layout slide definiscono entrambe uno sfondo, le diapositive basate su quel layout utilizzano lo sfondo del layout. Per ulteriori informazioni sulle layout slide, vedere [Applicare o modificare i layout delle diapositive](/slides/it/php-java/slide-layout/).
{{% /alert %}}

## **Accesso ai master delle diapositive**

In PowerPoint, è possibile aprire la visualizzazione Slide Master da **View** > **Slide Master**.

![Il comando Slide Master sulla scheda Visualizza di PowerPoint](slide-master_3.jpg)

In Aspose.Slides, utilizza il metodo `getMasters` per accedere ai master slide:

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

È anche possibile ottenere il master slide usato da una diapositiva normale attraverso il suo layout:

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

## **Cosa contiene un master diapositive**

Un master slide è un oggetto simile a una diapositiva. Estende [BaseSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/), quindi espone molte delle stesse proprietà di diapositiva utilizzate da diapositive normali e layout. I membri specifici del master sono elencati nella pagina API di [MasterSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/).

I membri del master slide più comunemente usati includono:

| Membro | Scopo |
| --- | --- |
| `getBackground` | Imposta lo sfondo della diapositiva a livello di master. |
| `getShapes` | Memorizza le forme posizionate sul master, come loghi, cornici di immagini e testo condiviso. |
| `getLayoutSlides` | Memorizza le layout slide appartenenti al master. |
| `getThemeManager` | Fornisce l'accesso alle API del tema master. |
| `getHeaderFooterManager` | Controlla intestazioni, piè di pagina, date e numeri di diapositiva per il master e i suoi layout figli. |
| `getDependingSlides` | Restituisce le diapositive normali che dipendono dal master tramite i loro layout. |

## **Aggiungere un'immagine a un master diapositive**

Quando si aggiunge un'immagine a un master slide, essa appare sulle diapositive che utilizzano layout da quel master. È utile per loghi, filigrane, bande decorative e altri elementi visuali ripetuti.

Il seguente esempio aggiunge un logo al primo master slide:

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

Per ulteriori informazioni sulle cornici immagine, vedere [Cornice immagine](/slides/it/php-java/picture-frame/).

## **Controllare la visibilità della grafica master**

Utilizza [BaseSlide::setShowMasterShapes](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/#setShowMasterShapes) per nascondere la grafica master ereditata, come loghi o forme decorative, senza eliminarla dal master. Passa `false` a [Slide::setShowMasterShapes](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#setShowMasterShapes) sulla diapositiva che deve omettere tali grafiche e mantienilo `true` sulle diapositive che devono mostrarle.

Il seguente esempio autonomo crea una banda decorativa blu su un master e due diapositive che utilizzano lo stesso layout vuoto. La banda è visibile sulla prima diapositiva e nascosta sulla seconda. Non è necessaria alcuna presentazione o immagine di input.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);
    $layoutSlide = $masterSlide->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $layoutSlide->setShowMasterShapes(true);

    $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
    $band = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 60, $slideHeight);
    $bandColor = new Java("java.awt.Color", 70, 130, 180);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor($bandColor);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $visibleSlide = $presentation->getSlides()->get_Item(0);
    $visibleSlide->setLayoutSlide($layoutSlide);
    $visibleSlide->getShapes()->clear();

    $hiddenSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $visibleSlide->setShowMasterShapes(true);
    $hiddenSlide->setShowMasterShapes(false);

    $presentation->save("master-graphics.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

L'esempio utilizza il layout **Blank** fornito con una nuova presentazione e rimuove i segnaposto della diapositiva iniziale.

### **Scegliere l'ambito dell'impostazione**

Una diapositiva normale utilizza il suo master tramite [Slide::getLayoutSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/slide/#getLayoutSlide) e [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/#getMasterSlide). Impostare la proprietà su una singola diapositiva influisce solo su quella diapositiva. Passare `false` a [LayoutSlide::setShowMasterShapes](https://reference.aspose.com/slides/it/php-java/aspose.slides/layoutslide/#setShowMasterShapes) nasconde la grafica master per le diapositive che utilizzano quel layout condiviso, anche se la loro impostazione è `true`. Per nascondere la grafica su una sola diapositiva, modificare la proprietà della diapositiva e lasciare invariato il layout condiviso.

L'impostazione non è supportata come controllo di visibilità sul master slide stesso. Su un master, [getShowMasterShapes](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/#getShowMasterShapes) restituisce sempre `false`, e passare `true` a [setShowMasterShapes](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslide/#setShowMasterShapes) genera un'eccezione. Applicala invece a una diapositiva normale o a un layout.

### **Distinguere la grafica dallo sfondo**

| Operazione | Effetto |
| --- | --- |
| Nascondere la grafica master | Controlla la visibilità delle forme master ereditate senza eliminarle o modificare le forme proprie della diapositiva. |
| Modificare il riempimento dello sfondo della diapositiva | Modifica il colore, il gradiente o l'immagine di sfondo. La grafica master è costituita da forme separate e può rimanere visibile sopra quello sfondo. Vedi [Sfondo della presentazione](/slides/it/php-java/presentation-background/). |
| Eliminare una forma dal master | Rimuove la forma sorgente condivisa, quindi non è più disponibile per alcuna diapositiva che utilizza quel master. |

## **Lavorare con i segnaposto**

I segnaposto sono normalmente definiti sulle layout slide. Il master slide fornisce lo stile e il tema condivisi che tali layout ereditano, mentre ogni layout decide quali segnaposto sono disponibili e dove vengono posizionati.

In PowerPoint, i comandi dei segnaposto sono disponibili nella visualizzazione Slide Master.

![Il comando Inserisci segnaposto nella visualizzazione Slide Master di PowerPoint](slide-master_5.png)

Per aggiungere nuovi segnaposto con Aspose.Slides, lavora con la layout slide appartenente al master:

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

Puoi anche formattare le forme dei segnaposto già presenti su un master slide. Il seguente esempio individua il segnaposto del titolo e applica un riempimento a gradiente lineare:

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

Per ulteriori opzioni di formattazione di segnaposto e testo, vedere [Imposta testo di prompt nel segnaposto](/slides/it/php-java/manage-placeholder/) e [Formattazione del testo](/slides/it/php-java/text-formatting/).

## **Modificare lo sfondo di un master diapositive**

Uno sfondo master è ereditato dai layout e dalle diapositive che non lo sovrascrivono. Il seguente esempio imposta un colore di sfondo solido per il primo master slide:

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

Per argomenti correlati, vedere [Sfondo della presentazione](/slides/it/php-java/presentation-background/) e [Tema della presentazione](/slides/it/php-java/presentation-theme/).

## **Clonare un master diapositive in un'altra presentazione**

Utilizza `addClone` da [MasterSlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslidecollection/) per copiare un master slide in un'altra presentazione. Il master copiato può poi essere utilizzato dai layout e dalle diapositive nella presentazione di destinazione.

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

Se devi clonare diapositive normali insieme al loro master, vedere [Clona diapositive](/slides/it/php-java/clone-slides/).

## **Aggiungere più master diapositive**

Una presentazione può contenere più master slide. È utile quando diverse sezioni richiedono brand, struttura di pagina o impostazioni di tema differenti.

![Comandi di PowerPoint per inserire e gestire i master slide](slide-master_9.jpg)

Il seguente esempio clona il master predefinito, assegna al clone uno sfondo diverso, crea un layout sotto quel master clonato e aggiunge una nuova diapositiva basata su quel layout:

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

## **Confrontare i master diapositive**

I master slide possono essere confrontati con il metodo `equals` ereditato da [BaseSlide](https://reference.aspose.com/slides/it/php-java/aspose.slides/baseslide/). Il confronto verifica la struttura e il contenuto statico, come forme, testo, formattazione, animazioni e altre impostazioni della diapositiva. Non confronta identificatori unici, come gli ID delle diapositive, né valori dinamici dei segnaposto, come la data corrente.

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

Per ulteriori informazioni, vedere [Confronta diapositive della presentazione](/slides/it/php-java/compare-slides/).

## **Impostare la visualizzazione Master diapositive come visualizzazione predefinita**

Utilizza il metodo `setLastView` su [ViewProperties](https://reference.aspose.com/slides/it/php-java/aspose.slides/viewproperties/) per controllare la visualizzazione che PowerPoint apre per prima. Il seguente esempio apre la presentazione in visualizzazione Slide Master:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    $presentation->save("presentation-master-view.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Per ulteriori impostazioni di visualizzazione, vedere [Salva presentazione](/slides/it/php-java/save-presentation/).

## **Rimuovere i master diapositive non utilizzati**

Le presentazioni a volte contengono master slide che non sono più usati da alcuna diapositiva normale. Rimuovere i master inutilizzati può ridurre la dimensione del file e semplificare la manutenzione del modello.

Utilizza `removeUnused` da [MasterSlideCollection](https://reference.aspose.com/slides/it/php-java/aspose.slides/masterslidecollection/) per rimuovere i master inutilizzati dalla raccolta `getMasters`:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getMasters()->removeUnused(true);
    $presentation->save("presentation-clean.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Puoi anche utilizzare il metodo a basso codice `removeUnusedMasterSlides` dalla classe [Compress](https://reference.aspose.com/slides/it/php-java/aspose.slides/compress/):

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

**Qual è la differenza tra un slide master e una layout slide?**

Un slide master definisce le impostazioni di design condivise come tema, sfondo, forme comuni e stili di testo. Una layout slide appartiene a un slide master e definisce una disposizione specifica di segnaposto. Una diapositiva normale utilizza una layout slide, quindi eredita sia dal layout sia dal master.

**Una presentazione può contenere diversi slide master?**

Sì. Una presentazione può contenere diversi slide master. Usa più master quando sezioni diverse necessitano di sistemi visivi o brand differenti.

**Devo aggiungere i segnaposto a un master slide o a una layout slide?**

Nella maggior parte dei casi, aggiungi i segnaposto alle layout slide. Inserisci gli elementi visuali condivisi e la formattazione condivisa sul master slide, poi posiziona i segnaposto di contenuto sulle layout che le diapositive normali utilizzeranno.

**Posso eliminare un master slide ancora in uso?**

No. Un master slide che ha diapositive dipendenti non può essere rimosso in modo sicuro direttamente. Prima sposta quelle diapositive a layout sotto un altro master, o utilizza un metodo di pulizia dei master non utilizzati che rimuove solo i master non in uso.